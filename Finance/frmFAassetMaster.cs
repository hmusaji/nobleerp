
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmFAAssetMaster
		: System.Windows.Forms.Form
	{

		public frmFAAssetMaster()
{
InitializeComponent();
} 
 public  void frmFAAssetMaster_old()
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


		private void frmFAAssetMaster_Activated(System.Object eventSender, System.EventArgs eventArgs)
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


		private string mTimeStamp = "";
		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;
		private clsToolbar oThisFormToolBar = null;

		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private bool mEnableCostCenter = false;

		private const int conTxtAssetCode = 0;
		private const int conTxtLAssetName = 1;
		private const int conTxtAAssetName = 2;
		private const int conTxtCatCd = 3;
		private const int conTxtSupplierCd = 4;
		private const int conTxtUnitCd = 5;
		private const int conTxtInvoiceNo = 6;
		private const int conTxtQty = 7;
		private const int conTxtReceiptNo = 8;
		private const int conTxtExpensesCd = 9;
		private const int conTxtExpensesCCCd = 10;
		private const int conTxtLocationCd = 11;
		private const int conTxtDeprMethodCd = 12;
		private const int conTxtGroupCd = 13;

		private const int conDlblCatName = 0;
		private const int conDlblSupplierName = 1;
		private const int conDlblUnitName = 2;
		private const int conDlblExpensesName = 3;
		private const int conDlblExpensesCCName = 4;
		private const int conDlblLocationName = 5;
		private const int conDlblBookValue = 6;
		private const int conDlblLastDeprAmt = 7;
		private const int conDlblWriteOffQty = 8;
		private const int conDlblLastWriteOffDate = 9;
		private const int conDlblLastAdjustedDate = 10;
		private const int conDlblAdjustedValue = 11;
		private const int conDlblDeprMethod = 12;
		private const int conDlblWriteoffValue = 13;
		private const int conDlblGroupName = 14;

		private const int conNumExchangeRate = 0;
		private const int conNumInvoiceAmt = 1;
		private const int conNumExpensesAmt = 2;
		private const int conNumDeprPercent = 3;
		private const int conNumAccumDeprAmt = 4;

		private const int conTabBasicDetails = 0;
		private const int conTabPurchaseHistory = 1;
		private const int conTabGLLinks = 2;

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

		private DataSet rsLedgerList = null;
		private DataSet rsCostList = null;

		private const int grdAccountType = 0;
		private const int grdLedgerCode = 1;
		private const int grdLedgerName = 2;
		private const int grdApplyCostCenter = 3;
		private const int grdCCNo = 4;
		private const int grdCCName = 5;
		private const int grdGroupCodeFilterOnLedger = 6;

		private const int mMaxArrayCols = 6;
		private const int mMaxArrayRows = 5;

		private bool mCategoryDefaultSet = false;
		private bool mLocationDefaultSet = false;



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
			FirstFocusObject = txtCommon[conTxtAssetCode];

			try
			{

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
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowGLTranButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEnableCostCenter = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center"));

				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, "&H98AFDA", "&H98AFDA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "GL Account Type", 2200, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Code", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Name", 2700, false, SystemConstants.gDisableColumnBackColor);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Apply cost center", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Code", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), (0x913DA3).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon", false, mEnableCostCenter, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Name", 1800, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, mEnableCostCenter);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "GroupCodeFilterList", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);


				//Setting for the standard Listbox used on the grid
				SystemGrid.DefineSystemGridCombo(cmbCommon);
				cmbCommon.Height = 100;
				cmbCommon.Width = 280;

				ResetGridArray();

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
				{
					GenerateRecordSet();
					GetAccountInfo(0);
				}
				else
				{
					tabMaster.set_TabVisible(Convert.ToInt16(conTabGLLinks), false);
				}

				SystemProcedure.SetLabelCaption(this);
				txtCommon[conTxtAssetCode].Text = SystemProcedure2.GetNewNumber("fa_items", "asset_No", 2);
				tabMaster.CurrTab = Convert.ToInt16(conTabBasicDetails);

				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, frmFAAssetMaster.DefInstance, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Asset Master" : "Asset Master");
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
				if (KeyCode == ((int) Keys.Return) && this.ActiveControl.Name != "grdVoucherDetails")
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
			//Add a record
			SystemProcedure2.ClearTextBox(this);


			txtCommonNumber[conNumExchangeRate].Value = 1;
			txtCommonNumber[conNumInvoiceAmt].Value = 0;
			txtCommonNumber[conNumExpensesAmt].Value = 0;
			txtCommonNumber[conNumDeprPercent].Value = 0;
			txtCommonNumber[conNumAccumDeprAmt].Value = 0;

			txtCommon[conTxtAssetCode].Text = SystemProcedure2.GetNewNumber("fa_items", "asset_No", 2);


			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Asset Master" : "Asset Master");
			mSearchValue = "";

			if (ControlHelper.GetEnabled(FirstFocusObject))
			{
				FirstFocusObject.Focus();
			}

			ResetGridArray();
			//**--commented by : Moiz Hakimi
			//**--comment date : 15-nov-2005
			//**--Moiz Hakimipls check this line
			//btnFormToolBar(10).Enabled = False


			EnableDisableAllControls(true);

			mCategoryDefaultSet = false;
			mLocationDefaultSet = false;

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord(bool pPost = false)
		{
			bool result = false;
			int mLocatCd = 0;
			int mCatCd = 0;
			int mGroupCd = 0;
			int mCurrCD = 0;
			int mUnitCd = 0;
			string mSupplierCd = "";
			string mExpensesCd = "";
			int mExpensesCCCd = 0;
			int mDeprMethodCd = 0;
			string mCheckTimeStamp = "";

			int mEntryId = 0;

			//On Error GoTo eFoundError

			string mysql = " select locat_cd from fa_location ";
			mysql = mysql + " where locat_no=" + txtCommon[conTxtLocationCd].Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mLocatCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}
			else
			{
				MessageBox.Show("Invalid Location Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto mError;
			}

			mysql = " select cat_cd from fa_category ";
			mysql = mysql + " where cat_no=" + txtCommon[conTxtCatCd].Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCatCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}
			else
			{
				MessageBox.Show("Invalid Category Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto mError;
			}

			mysql = " select group_cd from fa_group ";
			mysql = mysql + " where group_no=" + txtCommon[conTxtGroupCd].Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mGroupCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}
			else
			{
				MessageBox.Show("Invalid Group Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto mError;
			}

			mysql = " select unit_cd from fa_unit ";
			mysql = mysql + " where unit_no=" + txtCommon[conTxtUnitCd].Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mUnitCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}
			else
			{
				MessageBox.Show("Invalid Unit Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto mError;
			}

			mysql = " select depr_method_cd from fa_depr_method ";
			mysql = mysql + " where depr_method_no=" + txtCommon[conTxtDeprMethodCd].Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mDeprMethodCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}
			else
			{
				MessageBox.Show("Invalid Depreciation Method !", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto mError;
			}

			mysql = " select ldgr_cd, curr_cd from gl_ledger ";
			mysql = mysql + " where ldgr_no='" + txtCommon[conTxtSupplierCd].Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSupplierCd = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrCD = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
			}
			else
			{
				MessageBox.Show("Invalid Category Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto mError;
			}

			if (ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNumExpensesAmt].Value) > 0 && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
			{
				mysql = " select ldgr_cd from gl_ledger ";
				mysql = mysql + " where ldgr_no='" + txtCommon[conTxtExpensesCd].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mExpensesCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
					{
						mysql = " select cost_cd from gl_cost_centers ";
						mysql = mysql + " where cost_no='" + txtCommon[conTxtExpensesCCCd].Text + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mExpensesCCCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
						}
						else
						{
							MessageBox.Show("Invalid Cost Center Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							goto mError;
						}
					}
					else
					{
						mExpensesCCCd = 0;
					}
				}
				else
				{
					MessageBox.Show("Invalid Expenses Account Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					goto mError;
				}
			}
			else
			{
				mExpensesCd = "0";
				mExpensesCCCd = 0;
			}

			SystemVariables.gConn.BeginTransaction();

			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				mysql = " insert into fa_items ";
				mysql = mysql + " (locat_cd, cat_cd, group_cd, curr_cd, asset_no, l_asset_name ";
				mysql = mysql + " , a_asset_name, supplier_accnt_cd, voucher_date, voucher_no ";
				mysql = mysql + " , unit_cd, qty, exchange_rate, voucher_amt_fc ";
				mysql = mysql + " , depr_method_cd, depr_percent ";
				mysql = mysql + " , last_depr_date, accumulated_depr_amt ";
				mysql = mysql + " , expense_amt , expense_accnt_cd, expense_cc_cd, start_depr_date ";
				mysql = mysql + " , receipt_no ";
				mysql = mysql + " , user_cd ";
				mysql = mysql + " ) ";
				mysql = mysql + " values(";
				mysql = mysql + mLocatCd.ToString();
				mysql = mysql + ", " + mCatCd.ToString();
				mysql = mysql + ", " + mGroupCd.ToString();
				mysql = mysql + ", " + mCurrCD.ToString();
				mysql = mysql + ", '" + txtCommon[conTxtAssetCode].Text + "'";
				mysql = mysql + ", '" + txtCommon[conTxtLAssetName].Text + "'";
				mysql = mysql + ", N'" + txtCommon[conTxtAAssetName].Text + "'";
				mysql = mysql + ", '" + mSupplierCd + "'";
				mysql = mysql + ", '" + ReflectionHelper.GetPrimitiveValue<string>(txtPurchaseDate.Value) + "'";
				mysql = mysql + ", '" + txtCommon[conTxtInvoiceNo].Text + "'";
				mysql = mysql + ", " + mUnitCd.ToString();
				mysql = mysql + ", " + txtCommon[conTxtQty].Text;
				mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumExchangeRate].Value);
				mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumInvoiceAmt].Value);
				mysql = mysql + ", " + mDeprMethodCd.ToString(); //& cmbCommon(0).ItemData(cmbCommon(0).ListIndex)
				mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumDeprPercent].Value);
				if (ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNumAccumDeprAmt].Value) > 0)
				{
					mysql = mysql + ", '" + ReflectionHelper.GetPrimitiveValue<string>(txtLastDeprDate.Value) + "'";
					mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumAccumDeprAmt].Value);
				}
				else
				{
					mysql = mysql + ", '" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDeprDate.Value) + "'";
					mysql = mysql + ", 0 ";
				}

				if (ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNumExpensesAmt].Value) > 0)
				{
					mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumExpensesAmt].Value);
					mysql = mysql + ", '" + mExpensesCd + "'";
					if (mExpensesCCCd != 0)
					{
						mysql = mysql + ", " + mExpensesCCCd.ToString();
					}
					else
					{
						mysql = mysql + ", NULL ";
					}
				}
				else
				{
					mysql = mysql + ", 0 ";
					mysql = mysql + ", NULL ";
					mysql = mysql + ", NULL ";
				}

				mysql = mysql + ", '" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDeprDate.Value) + "'";
				mysql = mysql + ", '" + txtCommon[conTxtReceiptNo].Text + "'";
				mysql = mysql + ", " + Conversion.Str(SystemVariables.gLoggedInUserCode);
				mysql = mysql + " ) ";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mysql = " select scope_identity() ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));

			}
			else
			{
				//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);

				if (mOldVoucherStatus == SystemVariables.VoucherStatus.stActive)
				{
					mysql = " select time_stamp from fa_items where asset_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}
					else
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						FirstFocusObject.Focus();
						return result;
					}

					if (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp))
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						FirstFocusObject.Focus();
						return result;
					}
					if (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(1)))
					{
						MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}


					mysql = " update fa_items set ";
					mysql = mysql + " locat_cd =" + mLocatCd.ToString();
					mysql = mysql + " , cat_cd =" + mCatCd.ToString();
					mysql = mysql + " , group_cd =" + mGroupCd.ToString();
					mysql = mysql + " , curr_cd =" + mCurrCD.ToString();
					mysql = mysql + " , asset_no ='" + txtCommon[conTxtAssetCode].Text + "'";
					mysql = mysql + " , l_asset_name ='" + txtCommon[conTxtLAssetName].Text + "'";
					mysql = mysql + " , a_asset_name = N'" + txtCommon[conTxtAAssetName].Text + "'";
					mysql = mysql + " , supplier_accnt_cd ='" + mSupplierCd + "'";
					mysql = mysql + " , voucher_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtPurchaseDate.Value) + "'";
					mysql = mysql + " , voucher_no ='" + txtCommon[conTxtInvoiceNo].Text + "'";
					mysql = mysql + " , unit_cd =" + mUnitCd.ToString();
					mysql = mysql + " , qty =" + txtCommon[conTxtQty].Text;
					mysql = mysql + " , exchange_rate = " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumExchangeRate].Value);
					mysql = mysql + " , voucher_amt_fc =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumInvoiceAmt].Value);
					mysql = mysql + " , depr_method_cd = " + mDeprMethodCd.ToString(); //& cmbCommon(0).ItemData(cmbCommon(0).ListIndex)
					mysql = mysql + " , depr_percent =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumDeprPercent].Value);

					if (ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNumAccumDeprAmt].Value) > 0)
					{
						mysql = mysql + " , last_depr_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtLastDeprDate.Value) + "'";
						mysql = mysql + " , accumulated_depr_amt =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumAccumDeprAmt].Value);
					}
					else
					{
						mysql = mysql + " , last_depr_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDeprDate.Value) + "'";
						mysql = mysql + " , accumulated_depr_amt = 0";
					}

					if (ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNumExpensesAmt].Value) > 0)
					{
						mysql = mysql + ", expense_amt =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumExpensesAmt].Value);
						mysql = mysql + ", expense_accnt_cd ='" + mExpensesCd + "'";
						if (mExpensesCCCd != 0)
						{
							mysql = mysql + ", expense_cc_cd =" + mExpensesCCCd.ToString();
						}
						else
						{
							mysql = mysql + ", expense_cc_cd = NULL ";
						}
						mysql = mysql + ", start_depr_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDeprDate.Value) + "'";
					}
					mysql = mysql + " , receipt_no ='" + txtCommon[conTxtReceiptNo].Text + "'";
					mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where asset_cd =" + Conversion.Str(mEntryId);

					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}
				else
				{

					mysql = " update fa_items set ";
					mysql = mysql + " cat_cd =" + mCatCd.ToString();
					mysql = mysql + " , group_cd =" + mGroupCd.ToString();
					mysql = mysql + " , asset_no ='" + txtCommon[conTxtAssetCode].Text + "'";
					mysql = mysql + " , l_asset_name ='" + txtCommon[conTxtLAssetName].Text + "'";
					mysql = mysql + " , a_asset_name = N'" + txtCommon[conTxtAAssetName].Text + "'";
					mysql = mysql + " , depr_method_cd = " + mDeprMethodCd.ToString();
					mysql = mysql + " , depr_percent =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumDeprPercent].Value);
					mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where asset_cd =" + Conversion.Str(mEntryId);

					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();
				}
			}

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
			{
				if (!SaveGLLinks(mEntryId))
				{
					tabMaster.CurrTab = Convert.ToInt16(conTabGLLinks);
					grdVoucherDetails.Focus();
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					goto mError;
				}
			}

			if (pPost)
			{
				if (!PostAssetMaster(mEntryId))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					goto mError;
				}
			}

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			result = true;
			if (ControlHelper.GetEnabled(FirstFocusObject))
			{
				FirstFocusObject.Focus();
			}

			return result;

			mError:
			//gConn.RollbackTrans
			return false;


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

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 1);
				result = false;
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				return result;
			}


			SystemVariables.gConn.BeginTransaction();

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "delete from fa_items where asset_cd=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Asset cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			//On Error GoTo eFoundError

			string mysql = " select fa.*, fal.locat_no, fal.l_locat_name, fal.a_locat_name ";
			mysql = mysql + " , gl_ledger.ldgr_no supplier_no, gl_ledger.l_ldgr_name l_supplier_name, gl_ledger.a_ldgr_name a_supplier_name ";
			mysql = mysql + " , ledger1.ldgr_no exp_no, ledger1.l_ldgr_name l_exp_name, ledger1.a_ldgr_name a_exp_name ";
			mysql = mysql + " , fu.unit_no, fu.l_unit_name, fu.a_unit_name ";
			mysql = mysql + " , cc.cost_no, cc.l_cost_name, cc.a_cost_name ";
			mysql = mysql + " , fac.cat_no, fac.l_cat_name, fac.a_cat_name ";
			mysql = mysql + " , fag.group_no, fag.l_group_name, fag.a_group_name ";
			mysql = mysql + " , fdm.depr_method_no, fdm.l_depr_method, fdm.a_depr_method ";
			mysql = mysql + " from fa_items fa ";
			mysql = mysql + " inner join fa_category fac on fa.cat_cd = fac.cat_cd ";
			mysql = mysql + " inner join fa_group fag on fa.group_cd = fag.group_cd ";
			mysql = mysql + " inner join fa_location fal on fal.locat_cd = fa.locat_cd ";
			mysql = mysql + " inner join gl_ledger on fa.supplier_accnt_cd = gl_ledger.ldgr_cd ";
			mysql = mysql + " inner join fa_depr_method fdm on fa.depr_method_cd = fdm.depr_method_cd ";
			mysql = mysql + " left join gl_ledger ledger1 on fa.expense_accnt_cd = ledger1.ldgr_cd ";
			mysql = mysql + " left join gl_cost_centers cc on fa.expense_cc_cd = cc.cost_cd ";
			mysql = mysql + " inner join fa_unit fu on fa.unit_cd = fu.unit_cd ";
			mysql = mysql + " where asset_cd= " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

			DataSet localRec = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			localRec.Tables.Clear();
			adap.Fill(localRec);
			if (localRec.Tables[0].Rows.Count != 0)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mSearchValue = localRec.Tables[0].Rows[0]["asset_cd"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mTimeStamp = Convert.ToString(localRec.Tables[0].Rows[0]["time_stamp"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conTxtLocationCd].Text = Convert.ToString(localRec.Tables[0].Rows[0]["locat_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conTxtCatCd].Text = Convert.ToString(localRec.Tables[0].Rows[0]["cat_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conTxtGroupCd].Text = Convert.ToString(localRec.Tables[0].Rows[0]["group_no"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conTxtAssetCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["asset_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conTxtLAssetName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["l_asset_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conTxtAAssetName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["a_asset_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conTxtSupplierCd].Text = Convert.ToString(localRec.Tables[0].Rows[0]["supplier_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conTxtDeprMethodCd].Text = Convert.ToString(localRec.Tables[0].Rows[0]["depr_method_no"]);

				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblLocationName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["l_locat_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblCatName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["l_cat_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblGroupName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["l_group_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblSupplierName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["l_supplier_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblUnitName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["l_unit_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblDeprMethod].Text = Convert.ToString(localRec.Tables[0].Rows[0]["l_depr_method"]);
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblLocationName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["a_locat_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblCatName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["a_cat_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblGroupName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["a_group_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblSupplierName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["a_supplier_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblUnitName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["a_unit_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblDeprMethod].Text = Convert.ToString(localRec.Tables[0].Rows[0]["a_depr_method"]);
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtPurchaseDate.Value = localRec.Tables[0].Rows[0]["voucher_date"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conTxtInvoiceNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["voucher_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conTxtUnitCd].Text = Convert.ToString(localRec.Tables[0].Rows[0]["unit_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conTxtQty].Text = Convert.ToString(localRec.Tables[0].Rows[0]["qty"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNumExchangeRate].Value = localRec.Tables[0].Rows[0]["exchange_rate"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNumInvoiceAmt].Value = localRec.Tables[0].Rows[0]["voucher_amt_fc"];

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conTxtReceiptNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["receipt_no"]) + "";

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!localRec.Tables[0].Rows[0].IsNull("last_adjustment_date"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblLastAdjustedDate].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["last_adjustment_date"], SystemVariables.gSystemDateFormat);
				}
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDisplay[conDlblAdjustedValue].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["adjusted_value"], "###,###,###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDisplay[conDlblLastDeprAmt].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["last_depr_amt"], "###,###,###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDisplay[conDlblBookValue].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["book_value"], "###,###,###,###,##0.000");

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!localRec.Tables[0].Rows[0].IsNull("writeoff_date"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblLastWriteOffDate].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["writeoff_date"], SystemVariables.gSystemDateFormat);
				}
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDisplay[conDlblWriteOffQty].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["writeoff_qty"], "###,###,###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDisplay[conDlblWriteoffValue].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["writeoff_value"], "###,###,###,###,##0.000");


				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNumDeprPercent].Value = localRec.Tables[0].Rows[0]["depr_percent"];

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtLastDeprDate.Value = localRec.Tables[0].Rows[0]["last_depr_date"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNumAccumDeprAmt].Value = localRec.Tables[0].Rows[0]["accumulated_depr_amt"];

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtStartDeprDate.Value = localRec.Tables[0].Rows[0]["start_depr_date"];

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToDouble(localRec.Tables[0].Rows[0]["expense_amt"]) > 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[conNumExpensesAmt].Value = localRec.Tables[0].Rows[0]["expense_amt"];

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (!localRec.Tables[0].Rows[0].IsNull("exp_no"))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommon[conTxtExpensesCd].Text = Convert.ToString(localRec.Tables[0].Rows[0]["exp_no"]);
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (!localRec.Tables[0].Rows[0].IsNull("cost_no"))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommon[conTxtExpensesCCCd].Text = Convert.ToString(localRec.Tables[0].Rows[0]["cost_no"]);
					}
					else
					{
						txtCommon[conTxtExpensesCCCd].Text = "";
					}

					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conDlblExpensesName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["l_exp_name"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conDlblExpensesCCName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["l_cost_name"]) + "";
					}
					else
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conDlblExpensesName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["a_exp_name"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conDlblExpensesCCName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["a_cost_name"]) + "";
					}
				}


				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
				{
					GetAccountInfo(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));
				}

				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, frmFAAssetMaster.DefInstance, Convert.ToInt32(localRec.Tables[0].Rows[0]["status"]), CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Asset Master" : "Asset Master");

				if (mOldVoucherStatus == SystemVariables.VoucherStatus.stPosted)
				{
					EnableDisableAllControls(false);

					//**--commented by : Moiz Hakimi
					//**--comment date : 15-nov-2005
					//**--Moiz Hakimipls check this line
					//btnFormToolBar(10).Enabled = True
				}
				else
				{
					EnableDisableAllControls(true);

					//**--commented by : Moiz Hakimi
					//**--comment date : 15-nov-2005
					//**--Moiz Hakimipls check this line
					//btnFormToolBar(10).Enabled = False
				}

				mCategoryDefaultSet = false;
				mLocationDefaultSet = false;

			}
			localRec = null;

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void PrintReport()
		{

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(8004000));
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

			if (SystemProcedure2.IsItEmpty(txtCommon[conTxtLAssetName].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Asset Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommon[conTxtAAssetName].Focus();
				goto mError;
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[conTxtAssetCode].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Asset Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstFocusObject.Focus();
				goto mError;
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[conTxtCatCd].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Category Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = Convert.ToInt16(conTabBasicDetails);
				txtCommon[conTxtCatCd].Focus();
				goto mError;
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[conTxtGroupCd].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Group Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = Convert.ToInt16(conTabBasicDetails);
				txtCommon[conTxtGroupCd].Focus();
				goto mError;
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[conTxtSupplierCd].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Supplier Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = Convert.ToInt16(conTabPurchaseHistory);
				txtCommon[conTxtSupplierCd].Focus();
				goto mError;
			}

			if (!Information.IsDate(txtPurchaseDate.Value))
			{
				MessageBox.Show("Enter Purchase Date.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = Convert.ToInt16(conTabPurchaseHistory);
				txtPurchaseDate.Focus();
				goto mError;
			}

			//If ValidDateRange(txtPurchaseDate.Value) = False Then
			//    MsgBox "Invalid Date Range, Check the current financial year", vbInformation, "Required"
			//    tabMaster.CurrTab = conTabPurchaseHistory
			//    txtPurchaseDate.SetFocus
			//    GoTo mError
			//End If

			if (!Information.IsDate(txtStartDeprDate.Value))
			{
				MessageBox.Show("Enter Depreciation Start Date.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = Convert.ToInt16(conTabBasicDetails);
				txtStartDeprDate.Focus();
				goto mError;
			}

			if (ReflectionHelper.IsLessThan(txtPurchaseDate.Value, txtStartDeprDate.Value))
			{
				MessageBox.Show("Purchase Date cannot be less than Start Depreciation Date!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = Convert.ToInt16(conTabBasicDetails);
				txtStartDeprDate.Focus();
				goto mError;
			}

			if (ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNumExpensesAmt].Value) > 0 && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
			{
				if (SystemProcedure2.IsItEmpty(txtCommon[conTxtExpensesCd].Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Expenses Account Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					tabMaster.CurrTab = Convert.ToInt16(conTabPurchaseHistory);
					txtCommon[conTxtExpensesCd].Focus();
					goto mError;
				}

				//    If IsItEmpty(txtCommon(conTxtExpensesCCCd).Text, NumberType) Then
				//        MsgBox "Enter Cost Center Code", vbInformation, "Required"
				//        tabMaster.CurrTab = conTabPurchaseHistory
				//        txtCommon(conTxtExpensesCCCd).SetFocus
				//        GoTo mError
				//    End If
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[conTxtLocationCd].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Location Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = Convert.ToInt16(conTabBasicDetails);
				txtCommon[conTxtLocationCd].Focus();
				goto mError;
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[conTxtInvoiceNo].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Invoice No.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = Convert.ToInt16(conTabPurchaseHistory);
				txtCommon[conTxtInvoiceNo].Focus();
				goto mError;
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[conTxtUnitCd].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Unit!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = Convert.ToInt16(conTabBasicDetails);
				txtCommon[conTxtUnitCd].Focus();
				goto mError;
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[conTxtQty].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Qty!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = Convert.ToInt16(conTabPurchaseHistory);
				txtCommon[conTxtQty].Focus();
				goto mError;
			}

			if (ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNumInvoiceAmt].Value) <= 0)
			{
				MessageBox.Show("Enter Invoice Amount", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = Convert.ToInt16(conTabPurchaseHistory);
				txtCommonNumber[conNumInvoiceAmt].Focus();
				goto mError;
			}

			if (ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNumAccumDeprAmt].Value) > 0)
			{
				if (!Information.IsDate(txtLastDeprDate.Value))
				{
					MessageBox.Show("Enter Last Depreciation Date.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					tabMaster.CurrTab = Convert.ToInt16(conTabPurchaseHistory);
					txtLastDeprDate.Focus();
					goto mError;
				}

				if (ReflectionHelper.IsLessThan(txtLastDeprDate.Value, txtStartDeprDate.Value))
				{
					MessageBox.Show("Last Depreciation Date cannot be less than Start Depreciation Date!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					tabMaster.CurrTab = Convert.ToInt16(conTabPurchaseHistory);
					txtLastDeprDate.Focus();
					goto mError;
				}
			}


			return true;

			mError:
			return false;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				//If mGLLinkInitialised = True Then
				//    Unload mForm
				//    Set mForm = Nothing
				//End If

				aLedger = null;
				rsLedgerList = null;
				rsCostList = null;

				frmFAAssetMaster.DefInstance.Close();
				frmFAAssetMaster.DefInstance = null;
				oThisFormToolBar = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
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
					case conTxtCatCd : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(8003000, "1124")); 
						break;
					case conTxtGroupCd : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(8003500, "1460")); 
						break;
					case conTxtSupplierCd : 
						//mFilterCondition = " ( ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" 
						//mFilterCondition = mFilterCondition & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" & ")" 
						mFilterCondition = " ( l.type_cd in ( " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("fa_supplier_filter_string")) + " )) "; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFilterCondition)); 
						break;
					case conTxtUnitCd : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(8001000, "1116")); 
						break;
					case conTxtExpensesCd : 
						mFilterCondition = " ( l.type_cd in ( " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("fa_expenses_filter_string")) + " )) "; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFilterCondition)); 
						break;
					case conTxtExpensesCCCd : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000110, "882")); 
						break;
					case conTxtLocationCd : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(8002000, "1120")); 
						break;
					case conTxtDeprMethodCd : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(8005000, "1151")); 
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
			if (Index == conTxtAssetCode)
			{
				txtCommon[conTxtAssetCode].Text = SystemProcedure2.GetNewNumber("fa_items", "asset_No", 2);
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

				switch(Index)
				{
					case conTxtCatCd : 
						mysql = "select l_cat_name, a_cat_name, cat_cd from fa_category where cat_no=" + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conDlblCatName; 
						break;
					case conTxtGroupCd : 
						mysql = "select l_group_name, a_group_name, group_cd from fa_group where group_no=" + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conDlblGroupName; 
						break;
					case conTxtSupplierCd : 
						mysql = "select l_ldgr_name, a_ldgr_name, ldgr_cd, curr_cd from gl_ledger where show = 1 and ldgr_no='" + txtCommon[Index].Text + "'"; 
						mysql = mysql + " and ( type_cd in ( " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("fa_supplier_filter_string")) + " )) "; 
						mLinkedTextBoxIndex = conDlblSupplierName; 
						break;
					case conTxtUnitCd : 
						mysql = "select l_unit_name, a_unit_name, unit_cd from fa_unit where show = 1 and unit_no=" + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conDlblUnitName; 
						break;
					case conTxtExpensesCd : 
						mysql = "select l_ldgr_name, a_ldgr_name, ldgr_cd from gl_ledger where show = 1 and ldgr_no='" + txtCommon[Index].Text + "'"; 
						mysql = mysql + " and ( type_cd in ( " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("fa_expenses_filter_string")) + " )) "; 
						mLinkedTextBoxIndex = conDlblExpensesName; 
						break;
					case conTxtExpensesCCCd : 
						mysql = "select l_cost_name, a_cost_name, cost_cd from gl_cost_centers where show = 1 and cost_no=" + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conDlblExpensesCCName; 
						break;
					case conTxtLocationCd : 
						mysql = "select l_locat_name, a_locat_name, locat_cd from fa_location where show = 1 and locat_no=" + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conDlblLocationName; 
						break;
					case conTxtDeprMethodCd : 
						mysql = "select  l_depr_method, a_depr_method, depr_method_cd from fa_depr_method where depr_method_no=" + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conDlblDeprMethod; 
						 
						break;
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
						txtCommonDisplay[mLinkedTextBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1));
						txtCommon[Index].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));

						if (Index == conTxtSupplierCd)
						{
							if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(3)) == SystemGLConstants.gDefaultCurrencyCd)
							{
								txtCommonNumber[conNumExchangeRate].Value = 1;
								txtCommonNumber[conNumExchangeRate].Enabled = false;
							}
							else
							{
								txtCommonNumber[conNumExchangeRate].Value = 1;
								txtCommonNumber[conNumExchangeRate].Enabled = true;
							}
						}

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
						{
							if (Index == conTxtCatCd && CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
							{
								if (!mCategoryDefaultSet)
								{
									GetAccountInfoFromCategory(ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(2)));
									mCategoryDefaultSet = true;
								}
							}

							if (Index == conTxtLocationCd && CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
							{
								if (!mLocationDefaultSet)
								{
									GetCCInformationFromLocation(ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(2)));
									mLocationDefaultSet = true;
								}
							}
						}
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

		private bool CalculateBookValue(int pIndex)
		{

			//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
			bool result = false;
			decimal mBookValue = (decimal) ((Convert.ToDouble(ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNumInvoiceAmt].Value) + ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNumExpensesAmt].Value))) - (ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNumAccumDeprAmt].Value) - Conversion.Val(StringsHelper.Format(txtCommonDisplay[conDlblAdjustedValue].Text, "###,###,###,###,##0.000"))));

			if (mBookValue < 0)
			{
				MessageBox.Show("BookValue cannot be negative!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = false;
				txtCommonNumber[conNumInvoiceAmt].Focus();
			}
			else
			{
				txtCommonDisplay[conDlblBookValue].Text = StringsHelper.Format(mBookValue, "###,###,###,##0.000");
				result = true;
			}
			return result;
		}

		private void txtCommonNumber_Validating(Object eventSender, CancelEventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonNumber, eventSender);
			bool Cancel = eventArgs.Cancel;
			try
			{
				if (Index == conNumInvoiceAmt || Index == conNumExpensesAmt || Index == conNumAccumDeprAmt)
				{
					Cancel = !CalculateBookValue(Index);
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel;
			}
		}

		public bool Post()
		{
			bool result = false;
			DialogResult ans = (DialogResult) 0;
			frmSysOnlinePosting frmTemp = frmSysOnlinePosting.CreateInstance();

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 2);
				result = false;
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				return result;
			}


			frmTemp.ShowDialog();

			//if the user clicks on OK button in the frmPost form
			if (frmTemp.mApprove)
			{

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					//Display this message if status is active, which will require to save the record first
					ans = MessageBox.Show(SystemConstants.msg19 + "\r" + "\r" + SystemConstants.msg7, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				}
				else
				{
					//Display this message if status is not active, which will not require to save the record first
					ans = MessageBox.Show("                         Do you want to Post the Record ?                          " + "\r" + "\r" + "\r" + " NOTE :            Yes : To post after saving. " + "\r" + "                         No : To post without saving " + "\r" + "                         Cancel : To exit without posting ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
				}

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						goto mend;
					}
				}
				else
				{
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						goto mend;
					}
					else if (ans == System.Windows.Forms.DialogResult.No)
					{ 
						if (frmTemp.mApprove)
						{
							SystemVariables.gConn.BeginTransaction();

							if (!PostAssetMaster(ReflectionHelper.GetPrimitiveValue<int>(SearchValue)))
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								result = false;
								goto mDestroy;
							}
							else
							{
							}

							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.CommitTrans();
						}
					}

					result = true;
					goto mDestroy;
				}
			}

			goto mDestroy;

			mend:
			//This goto will only come if the voucherstatus is still active
			if (CheckDataValidity())
			{
				if (saveRecord(frmTemp.mApprove))
				{
					result = true;
					goto mDestroy;
				}
			}
			result = false;

			mDestroy:
			frmTemp.Close();
			return result;
		}

		private bool PostAssetMaster(int pAssetCd)
		{
			object[, ] mArr = new object[6, 3];
			object mDefaultGlVoucherType = null;
			int mVoucherNo = 0;
			int mVoucherEntryId = 0;
			decimal mAssetPrchAmt = 0;
			int mLinkedPrchEntryId = 0;
			int mLinkedOpngEntryId = 0;

			//''check if gl link is enabled
			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
			{
				if (!SystemFAProcedure.GetFAGLLinks(mArr, pAssetCd))
				{
					return false;
				}
				else
				{

				}
			}

			//''''GL entry to generated as follows
			//        Asset Debit Account         Dr
			//            To Supplier A/C
			//            To Expenses A/C
			string mysql = " select * from fa_items ";
			mysql = mysql + " where asset_cd =" + pAssetCd.ToString();
			DataSet rsTempRec = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsTempRec.Tables.Clear();
			adap.Fill(rsTempRec);

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
			{
				//''if the purchase date is within the financial year
				//''then only generate the GL entry.
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (SystemProcedure2.ValidDateRange(Convert.ToDateTime(rsTempRec.Tables[0].Rows[0]["voucher_date"])))
				{

					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDefaultGlVoucherType = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetSystemPreferenceSetting("fa_default_gl_voucher_type"));

					mysql = " voucher_type = " + Conversion.Str(mDefaultGlVoucherType);
					mVoucherNo = Convert.ToInt32(Double.Parse(SystemProcedure2.GetNewNumber("gl_accnt_trans", "voucher_no", 0, mysql, " tablock(xlock) ")));

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mVoucherEntryId = SystemFAProcedure.FAInsertGLHeaderEntry(ReflectionHelper.GetPrimitiveValue<int>(mDefaultGlVoucherType), StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat), mVoucherNo, Convert.ToString(rsTempRec.Tables[0].Rows[0]["asset_no"]), Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsTempRec.Tables[0].Rows[0]["l_asset_name"] : rsTempRec.Tables[0].Rows[0]["a_asset_name"]), 2, SystemVariables.gLoggedInUserCode);


					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
					mAssetPrchAmt = Convert.ToDecimal(Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["voucher_amt_lc"]) + Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["expense_amt"]));

					//'''''''Asset A/C Dr.
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFADebitAccntCd, 0]), (SystemProcedure2.IsItEmpty(mArr[SystemFAProcedure.gFADebitAccntCd, 1], SystemVariables.DataType.NumberType)) ? "" : ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFADebitAccntCd, 1]), 1, mAssetPrchAmt, 1 * mAssetPrchAmt, "D", StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat), 1, 1);


					//'''''''Supplier A/C Cr.
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, Convert.ToString(rsTempRec.Tables[0].Rows[0]["supplier_accnt_cd"]), (SystemProcedure2.IsItEmpty(mArr[SystemFAProcedure.gFADebitAccntCd, 1], SystemVariables.DataType.NumberType)) ? "" : ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFADebitAccntCd, 1]), Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["exchange_rate"]), (decimal) (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["voucher_amt_fc"]) * -1), (decimal) (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["exchange_rate"]) * (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["voucher_amt_fc"]) * -1)), "C", StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat), 1, 1);


					//'''''''Expenses A/C Cr.
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["expense_amt"]) > 0)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, Convert.ToString(rsTempRec.Tables[0].Rows[0]["expense_accnt_cd"]), (rsTempRec.Tables[0].Rows[0].IsNull("expense_cc_cd")) ? "" : Convert.ToString(rsTempRec.Tables[0].Rows[0]["expense_cc_cd"]), 1, (decimal) (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["expense_amt"]) * -1), (decimal) (1 * (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["expense_amt"]) * -1)), "C", StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat), 2, 1);
					}
				}
			}

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mLinkedPrchEntryId = SystemFAProcedure.FAInsertDeprTransHeader(StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat), SystemFAProcedure.gFAPurchaseVoucherType, true, pAssetCd);

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			SystemFAProcedure.FAInsertDeprTransDetails(mLinkedPrchEntryId, pAssetCd, StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["last_depr_date"], SystemVariables.gSystemDateFormat), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["last_depr_amt"]), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["accumulated_depr_amt"]), Convert.ToInt32(rsTempRec.Tables[0].Rows[0]["depr_method_cd"]), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["depr_percent"]), StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat), mAssetPrchAmt);

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			if (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["accumulated_depr_amt"]) > 0)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mLinkedOpngEntryId = SystemFAProcedure.FAInsertDeprTransHeader(StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat), SystemFAProcedure.gFAOpeningVoucherType, true, pAssetCd);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemFAProcedure.FAInsertDeprTransDetails(mLinkedOpngEntryId, pAssetCd, StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["last_depr_date"], SystemVariables.gSystemDateFormat), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["last_depr_amt"]), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["accumulated_depr_amt"]), Convert.ToInt32(rsTempRec.Tables[0].Rows[0]["depr_method_cd"]), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["depr_percent"]), StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["accumulated_depr_amt"]));
			}

			mysql = " update fa_items";
			mysql = mysql + " set ";
			mysql = mysql + "   status = 2 ";
			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
			{
				mysql = mysql + " , posted_gl = 1 ";
				if (mVoucherEntryId != 0)
				{
					mysql = mysql + " , gl_generated_voucher_type =" + ReflectionHelper.GetPrimitiveValue<string>(mDefaultGlVoucherType);
					mysql = mysql + " , gl_generated_entry_id =" + mVoucherEntryId.ToString();
				}
			}
			mysql = mysql + " where asset_cd =" + pAssetCd.ToString();
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();



			return true;
		}

		private void EnableDisableAllControls(bool pEnabled)
		{
			Control txtTextCtr = null;

			//UPGRADE_WARNING: (2065) Form property frmFAAssetMaster.Controls has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
			foreach (Control txtTextCtrIterator in ContainerHelper.Controls(frmFAAssetMaster.DefInstance))
			{
				txtTextCtr = txtTextCtrIterator;
				if ((txtTextCtr is System.Windows.Forms.TextBox) || (txtTextCtr is TextBox) || (txtTextCtr is System.Windows.Forms.TextBox) || (txtTextCtr is Syncfusion.WinForms.Input.SfDateTimeEdit))
				{
					ControlHelper.SetEnabled(txtTextCtr, pEnabled);
				}
				txtTextCtr = default(Control);
			}

			//''these control can be changed after posting
			txtCommon[conTxtDeprMethodCd].Enabled = true;
			txtCommonNumber[conNumDeprPercent].Enabled = true;
			txtCommon[conTxtAssetCode].Enabled = true;
			txtCommon[conTxtLAssetName].Enabled = true;
			txtCommon[conTxtAAssetName].Enabled = true;
			txtCommon[conTxtCatCd].Enabled = true;
			txtCommon[conTxtGroupCd].Enabled = true;

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbCommon.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbCommon_DataSourceChanged()
		{
			int Cnt = 0;
			cmbCommon.Width = 0;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			switch(grdVoucherDetails.Col)
			{
				case grdLedgerCode : 
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
									//.Order = IIf(grdVoucherDetails.Col = grdLedgerCode, 0, 1) 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdLedgerCode].Width; 
									withVar.Visible = true; 
									break;
								case 1 : 
									//.Order = IIf(grdVoucherDetails.Col = grdLedgerCode, 0, 1) 
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
				case grdCCNo : 
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
							}
							else if (Cnt == 1)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.DisplayColumns[Cnt].Width = grdVoucherDetails.Splits[0].DisplayColumns[grdCCName].Width;
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.Width += grdVoucherDetails.Splits[0].DisplayColumns[grdCCName].Width;
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
				default:
					cmbCommon.Width = 0; 
					break;
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbCommon.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbCommon_DropDownClose()
		{
			if (tabMaster.CurrTab == 1)
			{
				grdVoucherDetails.UpdateData();
				grdVoucherDetails.RefreshRow(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Bookmark)));
				grdVoucherDetails_RowColChange(grdVoucherDetails, new C1.Win.C1TrueDBGrid.RowColChangeEventArgs());

				if (grdVoucherDetails.Col == grdLedgerCode)
				{
					grdVoucherDetails.Col = grdCCNo;
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbCommon.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbCommon_RowChange()
		{
			if (grdVoucherDetails.Col == grdLedgerCode)
			{
				grdVoucherDetails.Columns[grdLedgerName].Value = cmbCommon.Columns[1].Value;
				grdVoucherDetails.Columns[grdApplyCostCenter].Value = cmbCommon.Columns[2].Value;
			}
			else if (grdVoucherDetails.Col == grdCCNo)
			{ 
				grdVoucherDetails.Columns[grdCCName].Value = cmbCommon.Columns[1].Value;
			}
		}

		private bool SaveGLLinks(int pAssetCd)
		{
			bool result = false;
			bool _eFoundError2Flag = false;
			string mysql = "";
			string mGroupFilterClause = "";
			//On Error GoTo eFoundError

			int Cnt = 0;

			object mTempValue = null;
			object[, ] mLedger = new object[mMaxArrayRows + 1, 2];
			grdVoucherDetails.UpdateData();
			for (Cnt = 0; Cnt <= mMaxArrayRows; Cnt++)
			{
				if (SystemProcedure2.IsItEmpty(aLedger.GetValue(Cnt, grdLedgerCode), SystemVariables.DataType.StringType))
				{
					goto eFoundError1;
				}

				mGroupFilterClause = FilterGroupCodeOnLedgerSql(Convert.ToString(aLedger.GetValue(Cnt, grdGroupCodeFilterOnLedger)), true);
				mysql = "select ldgr_cd from gl_ledger ";
				mysql = mysql + " where ldgr_no='" + Convert.ToString(aLedger.GetValue(Cnt, grdLedgerCode)) + "'";
				mysql = mysql + " and ( " + mGroupFilterClause + ")";
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

				if (mEnableCostCenter == (TriState.True != TriState.False))
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
			}


			mysql = " update fa_items set ";
			mysql = mysql + " debit_accnt_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[0, 0]) + ",";
			mysql = mysql + " accum_depr_accnt_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[1, 0]) + ",";
			mysql = mysql + " depr_accnt_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[2, 0]) + ",";
			mysql = mysql + " adjustment_accnt_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[3, 0]) + ",";
			mysql = mysql + " writeoff_accnt_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[4, 0]) + ",";
			mysql = mysql + " sales_accnt_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[5, 0]);

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
			{
				mysql = mysql + " , debit_cc_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[0, 1]) + ",";
				mysql = mysql + " accum_depr_cc_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[1, 1]) + ",";
				mysql = mysql + " depr_cc_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[2, 1]) + ",";
				mysql = mysql + " adjustment_cc_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[3, 1]) + ",";
				mysql = mysql + " writeoff_cc_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[4, 1]) + ",";
				mysql = mysql + " sales_cc_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[5, 1]);
			}

			mysql = mysql + " where asset_cd =" + Conversion.Str(pAssetCd);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();


			return true;

			eFoundError1:
			eFoundError2TryBlock:
			MessageBox.Show("Invalid Ledger Account", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			tabMaster.CurrTab = Convert.ToInt16(conTabGLLinks);
			grdVoucherDetails.Col = grdLedgerCode;
			grdVoucherDetails.Bookmark = Cnt;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069


			try
			{
				if (_eFoundError2Flag)
				{
					goto eFoundError2;
				}
				grdVoucherDetails.Focus();
				return false;

				eFoundError2:
				MessageBox.Show("Invalid Cost Center ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = Convert.ToInt16(conTabGLLinks);
				grdVoucherDetails.Bookmark = Cnt;
				grdVoucherDetails.Col = grdCCNo;
				grdVoucherDetails.Focus();
				return false;



				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "savegllinks", SystemConstants.msg10);
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
			if (grdVoucherDetails.Col > 0)
			{ //And mFirstGridFocus = True Then
				switch(grdVoucherDetails.Col)
				{
					case grdLedgerCode : 
						//''''Change the filter on the listbox 
						 
						mFilterClause = FilterGroupCodeOnLedgerSql(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdGroupCodeFilterOnLedger].Value)); 
						//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						rsLedgerList.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone(); 
						rsLedgerList.Tables[0].DefaultView.RowFilter = mFilterClause; 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbCommon.setDataSource((msdatasrc.DataSource) rsLedgerList); 
						break;
					case grdCCNo : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbCommon.setDataSource((msdatasrc.DataSource) rsCostList); 
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
			//    'If mFirstGridFocus = True And aLedger.Count(1) > 0 And IsNull(LastRow) = True Then
			//    If aLedger.Count(1) > 0 And IsNull(LastRow) = True Then
			//        If Val(grdVoucherDetails.Columns(grdApplyCostCenter).Value) = True Then
			//            grdVoucherDetails.Columns(grdCCNo).AllowFocus = True
			//        Else
			//            grdVoucherDetails.Columns(grdCCNo).AllowFocus = False
			//        End If
			//    End If
			//End If
		}

		private void GenerateRecordSet()
		{

			string mysql = "select ldgr_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name as ldgr_name" : "a_ldgr_name as ldgr_name");
			mysql = mysql + " , type_cd from gl_ledger order by 1";
			rsLedgerList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsLedgerList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsLedgerList.Tables.Clear();
			adap.Fill(rsLedgerList);

			mysql = "select cost_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cost_name as cost_name" : "a_cost_name as cost_name");
			mysql = mysql + " from gl_cost_centers order by 1";
			rsCostList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCostList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsCostList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsCostList.Tables.Clear();
			adap_2.Fill(rsCostList);
		}

		private string FilterGroupCodeOnLedgerSql(string pGroupCodeList, bool pUseLeftClause = false)
		{
			int Cnt = 0;
			StringBuilder mFilterClause = new StringBuilder();

			string[] mGroupCodeFilterList = pGroupCodeList.Split(',');

			int tempForEndVar = mGroupCodeFilterList.GetUpperBound(0);
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				if (Cnt > 0)
				{
					mFilterClause.Append(" or ");
				}
				//If pUseLeftClause = True Then
				//    mFilterClause = mFilterClause & " left(group_cd,4) = '" & Trim(mGroupCodeFilterList(cnt)) & "'"
				//Else
				mFilterClause.Append(" type_cd =" + mGroupCodeFilterList[Cnt].Trim());
				//End If
			}

			return mFilterClause.ToString();
		}

		private void GetAccountInfo(int pAssetCd)
		{

			ResetGridArray();

			string mysql = " select ";
			mysql = mysql + " Ledger_1.Ldgr_No AS Expr1";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_1.L_Ldgr_Name " : "Ledger_1.a_ldgr_Name") + " AS Expr2 ";
			//mySql = mySql & " , Ledger_1.apply_cost_center AS inventory_apply_cost "

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

			mysql = mysql + " , cc_1.cost_No AS Expr31 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_1.L_cost_Name " : "cc_1.a_cost_Name") + " AS Expr32 ";
			mysql = mysql + " , cc_2.cost_No AS Expr33 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_2.L_cost_Name " : "cc_2.a_cost_Name") + " AS Expr34 ";
			mysql = mysql + " , cc_3.cost_No AS Expr35 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_3.L_cost_Name " : "cc_3.a_cost_Name") + " AS Expr36 ";
			mysql = mysql + " , cc_4.cost_No AS Expr37 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_4.L_cost_Name " : "cc_4.a_cost_Name") + " AS Expr38 ";
			mysql = mysql + " , cc_5.cost_No AS Expr39 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_5.L_cost_Name " : "cc_5.a_cost_Name") + " AS Expr40 ";
			mysql = mysql + " , cc_6.cost_No AS Expr41 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_6.L_cost_Name " : "cc_6.a_cost_Name") + " AS Expr42 ";

			mysql = mysql + " FROM fa_items fa ";
			mysql = mysql + " INNER JOIN gl_ledger Ledger_1 ON fa.debit_accnt_cd = Ledger_1.Ldgr_Cd";
			mysql = mysql + " INNER JOIN gl_ledger ledger_2 ON fa.accum_depr_accnt_Cd = ledger_2.Ldgr_Cd";
			mysql = mysql + " INNER JOIN gl_ledger ledger_3 ON fa.depr_accnt_Cd = ledger_3.Ldgr_Cd";
			mysql = mysql + " INNER JOIN gl_ledger ledger_4 ON fa.adjustment_accnt_cd = ledger_4.Ldgr_Cd";
			mysql = mysql + " INNER JOIN gl_ledger ledger_5 ON fa.writeoff_accnt_Cd = ledger_5.Ldgr_Cd";
			mysql = mysql + " INNER JOIN gl_ledger ledger_6 ON fa.sales_accnt_Cd = ledger_6.Ldgr_Cd";

			mysql = mysql + " left JOIN gl_cost_centers cc_1 ON fa.debit_cc_cd = cc_1.cost_Cd ";
			mysql = mysql + " left JOIN gl_cost_centers cc_2 ON fa.accum_depr_cc_Cd = cc_2.cost_Cd ";
			mysql = mysql + " left JOIN gl_cost_centers cc_3 ON fa.depr_cc_Cd = cc_3.cost_Cd ";
			mysql = mysql + " left JOIN gl_cost_centers cc_4 ON fa.adjustment_cc_cd = cc_4.cost_Cd";
			mysql = mysql + " left JOIN gl_cost_centers cc_5 ON fa.writeoff_cc_Cd = cc_5.cost_Cd";
			mysql = mysql + " left JOIN gl_cost_centers cc_6 ON fa.sales_cc_Cd = cc_6.cost_Cd ";

			if (pAssetCd > 0)
			{
				mysql = mysql + " where fa.asset_cd=" + Conversion.Str(pAssetCd);
			}
			else
			{
				mysql = mysql + " where fa.asset_cd = 1 ";
			}

			DataSet tempRec = new DataSet();
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
				//aLedger(0, grdApplyCostCenter) = .Fields("inventory_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr31"], 0, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr32"], 0, grdCCName);


				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr3"], 1, grdLedgerCode);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr4"], 1, grdLedgerName);
				//aLedger(1, grdApplyCostCenter) = .Fields("adjustment_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr33"], 1, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr34"], 1, grdCCName);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr5"], 2, grdLedgerCode);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr6"], 2, grdLedgerName);
				//aLedger(2, grdApplyCostCenter) = .Fields("cost_of_sale_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr35"], 2, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr36"], 2, grdCCName);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr7"], 3, grdLedgerCode);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr8"], 3, grdLedgerName);
				//aLedger(3, grdApplyCostCenter) = .Fields("pdis_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr37"], 3, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr38"], 3, grdCCName);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr9"], 4, grdLedgerCode);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr10"], 4, grdLedgerName);
				//aLedger(4, grdApplyCostCenter) = .Fields("cash_sale_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr39"], 4, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr40"], 4, grdCCName);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr11"], 5, grdLedgerCode);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr12"], 5, grdLedgerName);
				//aLedger(5, grdApplyCostCenter) = .Fields("credit_sale_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr41"], 5, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr42"], 5, grdCCName);

				grdVoucherDetails.Rebind(true);
			}
			tempRec = null;

			grdVoucherDetails.Col = 1;

			try
			{
				grdVoucherDetails.Focus();
			}
			catch
			{
			}

		}

		private void ResetGridArray()
		{
			//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aLedger.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			aLedger.Clear();
			aLedger.RedimXArray(new int[]{mMaxArrayRows, mMaxArrayCols}, new int[]{0, 0});
			aLedger.SetValue("Debit Account", 0, grdAccountType);
			aLedger.SetValue(SystemProcedure2.GetSystemPreferenceSetting("fa_debit_filter_string"), 0, grdGroupCodeFilterOnLedger);

			aLedger.SetValue("Accumulated Depreciation A/c", 1, grdAccountType);
			aLedger.SetValue(SystemProcedure2.GetSystemPreferenceSetting("fa_accum_depr_filter_string"), 1, grdGroupCodeFilterOnLedger);

			aLedger.SetValue("Depreciation A/c", 2, grdAccountType);
			aLedger.SetValue(SystemProcedure2.GetSystemPreferenceSetting("fa_depr_filter_string"), 2, grdGroupCodeFilterOnLedger);

			aLedger.SetValue("Adjustment A/c", 3, grdAccountType);
			aLedger.SetValue(SystemProcedure2.GetSystemPreferenceSetting("fa_adjustment_filter_string"), 3, grdGroupCodeFilterOnLedger);

			aLedger.SetValue("WriteOff A/c", 4, grdAccountType);
			aLedger.SetValue(SystemProcedure2.GetSystemPreferenceSetting("fa_writeoff_filter_string"), 4, grdGroupCodeFilterOnLedger);

			aLedger.SetValue("Sales Account A/c", 5, grdAccountType);
			aLedger.SetValue(SystemProcedure2.GetSystemPreferenceSetting("fa_sales_filter_string"), 5, grdGroupCodeFilterOnLedger);

			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aLedger);
			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Refresh();
		}


		private void GetAccountInfoFromCategory(int pCatCd)
		{

			ResetGridArray();

			string mysql = " select ";
			mysql = mysql + " Ledger_1.Ldgr_No AS Expr1";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_1.L_Ldgr_Name " : "Ledger_1.a_ldgr_Name") + " AS Expr2 ";
			//mySql = mySql & " , Ledger_1.apply_cost_center AS inventory_apply_cost "

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

			mysql = mysql + " , cc_1.cost_No AS Expr31 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_1.L_cost_Name " : "cc_1.a_cost_Name") + " AS Expr32 ";
			mysql = mysql + " , cc_2.cost_No AS Expr33 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_2.L_cost_Name " : "cc_2.a_cost_Name") + " AS Expr34 ";
			mysql = mysql + " , cc_3.cost_No AS Expr35 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_3.L_cost_Name " : "cc_3.a_cost_Name") + " AS Expr36 ";
			mysql = mysql + " , cc_4.cost_No AS Expr37 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_4.L_cost_Name " : "cc_4.a_cost_Name") + " AS Expr38 ";
			mysql = mysql + " , cc_5.cost_No AS Expr39 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_5.L_cost_Name " : "cc_5.a_cost_Name") + " AS Expr40 ";
			mysql = mysql + " , cc_6.cost_No AS Expr41 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_6.L_cost_Name " : "cc_6.a_cost_Name") + " AS Expr42 ";

			mysql = mysql + " FROM fa_category fa ";
			mysql = mysql + " left JOIN gl_ledger Ledger_1 ON fa.debit_accnt_cd = Ledger_1.Ldgr_Cd";
			mysql = mysql + " left JOIN gl_ledger ledger_2 ON fa.accum_depr_accnt_Cd = ledger_2.Ldgr_Cd";
			mysql = mysql + " left JOIN gl_ledger ledger_3 ON fa.depr_accnt_Cd = ledger_3.Ldgr_Cd";
			mysql = mysql + " left JOIN gl_ledger ledger_4 ON fa.adjustment_accnt_cd = ledger_4.Ldgr_Cd";
			mysql = mysql + " left JOIN gl_ledger ledger_5 ON fa.writeoff_accnt_Cd = ledger_5.Ldgr_Cd";
			mysql = mysql + " left JOIN gl_ledger ledger_6 ON fa.sales_accnt_Cd = ledger_6.Ldgr_Cd";

			mysql = mysql + " left JOIN gl_cost_centers cc_1 ON fa.debit_cc_cd = cc_1.cost_Cd ";
			mysql = mysql + " left JOIN gl_cost_centers cc_2 ON fa.accum_depr_cc_Cd = cc_2.cost_Cd ";
			mysql = mysql + " left JOIN gl_cost_centers cc_3 ON fa.depr_cc_Cd = cc_3.cost_Cd ";
			mysql = mysql + " left JOIN gl_cost_centers cc_4 ON fa.adjustment_cc_cd = cc_4.cost_Cd";
			mysql = mysql + " left JOIN gl_cost_centers cc_5 ON fa.writeoff_cc_Cd = cc_5.cost_Cd";
			mysql = mysql + " left JOIN gl_cost_centers cc_6 ON fa.sales_cc_Cd = cc_6.cost_Cd ";

			if (pCatCd > 0)
			{
				mysql = mysql + " where fa.cat_cd =" + Conversion.Str(pCatCd);
			}
			else
			{
				mysql = mysql + " where fa.cat_cd = 1 ";
			}

			DataSet tempRec = new DataSet();
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
				//aLedger(0, grdApplyCostCenter) = .Fields("inventory_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr31"], 0, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr32"], 0, grdCCName);


				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr3"], 1, grdLedgerCode);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr4"], 1, grdLedgerName);
				//aLedger(1, grdApplyCostCenter) = .Fields("adjustment_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr33"], 1, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr34"], 1, grdCCName);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr5"], 2, grdLedgerCode);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr6"], 2, grdLedgerName);
				//aLedger(2, grdApplyCostCenter) = .Fields("cost_of_sale_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr35"], 2, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr36"], 2, grdCCName);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr7"], 3, grdLedgerCode);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr8"], 3, grdLedgerName);
				//aLedger(3, grdApplyCostCenter) = .Fields("pdis_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr37"], 3, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr38"], 3, grdCCName);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr9"], 4, grdLedgerCode);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr10"], 4, grdLedgerName);
				//aLedger(4, grdApplyCostCenter) = .Fields("cash_sale_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr39"], 4, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr40"], 4, grdCCName);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr11"], 5, grdLedgerCode);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr12"], 5, grdLedgerName);
				//aLedger(5, grdApplyCostCenter) = .Fields("credit_sale_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr41"], 5, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr42"], 5, grdCCName);

				grdVoucherDetails.Rebind(true);
			}
			tempRec = null;

			grdVoucherDetails.Col = 1;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			//grdVoucherDetails.SetFocus

		}

		public void GRoutine()
		{

			//''Check the GL module is enabled
			string mysql = " select show from SM_MODULES ";
			mysql = mysql + " where module_id = 2";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
			{
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					mysql = " select gl_generated_voucher_type, gl_generated_entry_id from fa_items ";
					mysql = mysql + " where asset_cd =" + Conversion.Str(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(0)))
						{
							if (SystemForms.GetSystemForm(310000, 2, ((Array) mReturnValue).GetValue(1), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0))))
							{
								//user has got access to the form
								//DoReportDrillDown = True
							}
							else
							{
								//access on the form is denied
								MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								//DoReportDrillDown = False
								//oReportGrid.SetFocus
							}
						}
						else
						{
							MessageBox.Show("No GL entry generated, due to Purchase date out of Current financial period range ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
				}
			}
		}

		private void GetCCInformationFromLocation(int pLocatCd)
		{
			int Cnt = 0;

			if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
			{
				return;
			}

			string mysql = " select cc.cost_no ";
			mysql = mysql + "," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_cost_name" : "a_cost_name") + " as cost_name ";
			mysql = mysql + " from fa_location l ";
			mysql = mysql + " inner join gl_cost_centers cc on l.cc_cd = cc.cost_cd ";
			mysql = mysql + " where l.locat_cd=" + pLocatCd.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				int tempForEndVar = aLedger.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					if (Convert.ToBoolean(aLedger.GetValue(Cnt, grdApplyCostCenter)))
					{
						aLedger.SetValue(((Array) mReturnValue).GetValue(0), Cnt, grdCCNo);
						aLedger.SetValue(((Array) mReturnValue).GetValue(1), Cnt, grdCCName);
					}
				}
			}

			grdVoucherDetails.Rebind(true);

		}
	}
}