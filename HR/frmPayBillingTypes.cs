
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayBillingTypes
		: System.Windows.Forms.Form
	{

		public frmPayBillingTypes()
{
InitializeComponent();
} 
 public  void frmPayBillingTypes_old()
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


		private void frmPayBillingTypes_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
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

		public Control FirstFocusObject = null;
		private string mTimeStamp = "";

		private DataSet _rsBillingCodeList = null;
		private DataSet rsBillingCodeList
		{
			get
			{
				if (_rsBillingCodeList is null)
				{
					_rsBillingCodeList = new DataSet();
				}
				return _rsBillingCodeList;
			}
			set
			{
				_rsBillingCodeList = value;
			}
		}

		private bool mFirstGridFocus = false;
		private XArrayHelper _aVoucherDetails = null;
		private XArrayHelper aVoucherDetails
		{
			get
			{
				if (_aVoucherDetails is null)
				{
					_aVoucherDetails = new XArrayHelper();
				}
				return _aVoucherDetails;
			}
			set
			{
				_aVoucherDetails = value;
			}
		}

		private const int conMaxColumns = 3;

		private int mThisFormID = 0;
		private object mSearchValue = null;
		private clsToolbar oThisFormToolBar = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private const int conCmbBillingTypes = 0;
		private const int conCmbBillingMethod = 1;

		private const int conTxtLedgerCode = 0;
		private const int conTxtCostCode = 1;

		private const int conDlblLedgerName = 0;
		private const int conDlblCostName = 1;

		private const int mconBillNo = 1;
		private const int mconBillName = 2;
		private const int mconbillCode = 3;

		private const int tabBillingDetails = 0;
		private const int tabBillingsSubDetails = 1;


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
			FirstFocusObject = txtLBillName;

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
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				mFirstGridFocus = true;

				//''Asssign Earnings Details Grid
				SystemGrid.DefineSystemVoucherGrid(grdLeaveEarningDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&H00C4B8CD", "&H00C4B8CD");
				SystemGrid.DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "LN", 400, false, "&HC4B8CD", ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "Billing No.", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "Billing Name", 3250, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "BillCd", 2500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdLeaveEarningDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdLeaveEarningDetails.setArray(aVoucherDetails);
				grdLeaveEarningDetails.Rebind(true);
				//grdLeaveEarningDetails.Enabled = True

				SystemProcedure.SetLabelCaption(this);

				//assign a next code
				txtBillNo.Text = SystemProcedure2.GetNewNumber("Pay_Billing_Type", "Bill_no");
				OptNone.Checked = true;
				txtNoOfMonths.Enabled = false;
				txtRoundDigit.Text = "3";
				CHKIncludeInBankTransfer.CheckState = CheckState.Checked;
				chkIncludeInBudget.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("HR_Budget"));

				object[] mObjectId = new object[2];
				mObjectId[conCmbBillingTypes] = 1010;
				mObjectId[conCmbBillingMethod] = 1028;
				SystemCombo.FillComboWithSystemObjects(cmbCommon, mObjectId);
				//Me.tabBillingType.TabVisible(tabBillingsSubDetails) = GetSystemPreferenceSetting("Enable_Computed_Billing")
				this.tabBillingType.set_TabVisible(Convert.ToInt16(tabBillingDetails), true);
				this.tabBillingType.CurrTab = Convert.ToInt16(tabBillingDetails);
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}
		}

		private void DefineVoucherArray(int pMaximumRows, bool pClearArray = false)
		{
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
			}
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, conMaxColumns}, new int[]{0, 0});
		}

		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, SystemICSConstants.grdLineNoColumn);
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
			DefineVoucherArray(-1, true);
			AssignGridLineNumbers();
			grdLeaveEarningDetails.Rebind(true);
			//grdLeaveEarningDetails.Enabled = True

			txtBillNo.Text = SystemProcedure2.GetNewNumber("Pay_Billing_Type", "Bill_no");
			txtNoOfMonths.Enabled = false;
			txtNoOfMonths.Value = 0;
			OptNone.Checked = true;

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			//chkOverTime.Value = 0
			chkIncludeInDefaultBillingTypes.CheckState = CheckState.Unchecked;
			//chkCalculated.Value = 0
			//FirstFocusObject.SetFocus
			this.tabBillingType.set_TabVisible(Convert.ToInt16(tabBillingDetails), true);
			this.tabBillingType.CurrTab = Convert.ToInt16(tabBillingDetails);
			txtRoundDigit.Text = "3";
			mFirstGridFocus = true;
			CHKIncludeInBankTransfer.CheckState = CheckState.Checked;
			chkIncludeInBudget.CheckState = CheckState.Unchecked;

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord()
		{
			bool result = false;
			object mReturnValue = null;
			//Dim mParentBillCode As Integer
			//Save a record
			//During save check for the mode
			//If in addmode then insert a record
			//else update the record in the recordset

			string mysql = "";
			try
			{

				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " INSERT INTO Pay_Billing_Type(user_cd, Bill_no, l_Bill_name";
					mysql = mysql + " , a_Bill_name, bill_type_id ";
					//mySql = mySql & " , include_in_default_billing_types, over_time, comments)"
					mysql = mysql + " , include_in_default_billing_types,is_calculate";
					mysql = mysql + " ,rounding_method,bill_type_method, comments,Is_Period,No_Of_Month,Include_In_Bank_Transfer , Include_In_Budget)";
					mysql = mysql + " VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " , " + txtBillNo.Text;
					mysql = mysql + ",'" + txtLBillName.Text + "'";
					mysql = mysql + ",N'" + txtABillName.Text + "'";
					mysql = mysql + ", " + cmbCommon[conCmbBillingTypes].GetItemData(cmbCommon[conCmbBillingTypes].ListIndex).ToString();
					mysql = mysql + " , " + ((int) chkIncludeInDefaultBillingTypes.CheckState).ToString();
					//mySql = mySql & " , " & chkOverTime.Value
					mysql = mysql + " , " + ((OptChkCalculate.Checked) ? 1 : 0).ToString();
					mysql = mysql + " , " + Convert.ToInt32(Double.Parse(txtRoundDigit.Text)).ToString();
					mysql = mysql + " , " + cmbCommon[conCmbBillingMethod].GetItemData(cmbCommon[conCmbBillingMethod].ListIndex).ToString();
					mysql = mysql + ", N'" + txtComment.Text + "'";
					mysql = mysql + ", " + ((OptPriodWise.Checked) ? 1 : 0).ToString();
					mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtNoOfMonths.Value);
					mysql = mysql + ", " + ((CHKIncludeInBankTransfer.CheckState != CheckState.Unchecked) ? 1 : 0).ToString();
					mysql = mysql + ", " + ((chkIncludeInBudget.CheckState != CheckState.Unchecked) ? 1 : 0).ToString();
					mysql = mysql + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));
				}
				else
				{
					mysql = " select time_stamp,protected from Pay_Billing_Type where Bill_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
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

					mysql = "UPDATE Pay_Billing_Type SET ";
					mysql = mysql + " Bill_No =" + txtBillNo.Text;
					mysql = mysql + " , L_Bill_Name ='" + txtLBillName.Text + "'";
					mysql = mysql + " , A_Bill_Name =N'" + txtABillName.Text + "'";
					mysql = mysql + " , bill_type_id=" + cmbCommon[conCmbBillingTypes].GetItemData(cmbCommon[conCmbBillingTypes].ListIndex).ToString();
					mysql = mysql + " , include_in_default_billing_types=" + ((int) chkIncludeInDefaultBillingTypes.CheckState).ToString();
					//mySql = mySql & " , over_time =" & chkOverTime.Value
					mysql = mysql + " , Comments =N'" + txtComment.Text + "'";
					mysql = mysql + " , User_Cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " , is_calculate=" + ((OptChkCalculate.Checked) ? 1 : 0).ToString();
					mysql = mysql + " , Include_In_Bank_Transfer = " + ((CHKIncludeInBankTransfer.CheckState != CheckState.Unchecked) ? 1 : 0).ToString();
					mysql = mysql + " , Include_In_Budget = " + ((chkIncludeInBudget.CheckState != CheckState.Unchecked) ? 1 : 0).ToString();
					mysql = mysql + " , rounding_method=" + Convert.ToInt32(Double.Parse(txtRoundDigit.Text)).ToString();
					mysql = mysql + " , bill_type_method=" + cmbCommon[conCmbBillingMethod].GetItemData(cmbCommon[conCmbBillingMethod].ListIndex).ToString();
					mysql = mysql + " , Is_Period = " + ((OptPriodWise.Checked) ? 1 : 0).ToString();
					mysql = mysql + " , No_Of_Month = " + ReflectionHelper.GetPrimitiveValue<string>(txtNoOfMonths.Value);
					mysql = mysql + " where Bill_cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}
				mysql = " delete from pay_billing_type_details where bill_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();
				grdLeaveEarningDetails.UpdateData();

				int mCnt = 0;
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (mCnt = 0; mCnt <= tempForEndVar; mCnt++)
				{
					mysql = " insert into pay_billing_type_details(bill_cd,linked_bill_cd)";
					mysql = mysql + " values(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(mCnt, mconbillCode));
					mysql = mysql + ")";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				return true;
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
		{

			bool result = false;
			string mysql = " select protected from Pay_Billing_Type where Bill_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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

				//If an error occurs, trap the error and dispaly a valid message
				SystemVariables.gConn.BeginTransaction();

				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					mysql = "delete from Pay_Billing_Type where Bill_cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (Information.Err().Number != 0)
					{
						MessageBox.Show("Billing Type cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

			try
			{
				string mysql = "";
				object mReturnValue = null;
				DataSet localRec = null;

				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdLeaveEarningDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdLeaveEarningDetails.setArray(aVoucherDetails);
				grdLeaveEarningDetails.Rebind(true);

				mysql = " select * from Pay_Billing_Type where Bill_cd= " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				localRec = new DataSet();
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				localRec.Tables.Clear();
				adap.Fill(localRec);
				if (localRec.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mSearchValue = localRec.Tables[0].Rows[0]["Bill_cd"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mTimeStamp = Convert.ToString(localRec.Tables[0].Rows[0]["time_stamp"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtBillNo.Text = Convert.ToString(localRec.Tables[0].Rows[0]["Bill_no"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtLBillName.Text = Convert.ToString(localRec.Tables[0].Rows[0]["l_Bill_Name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtABillName.Text = Convert.ToString(localRec.Tables[0].Rows[0]["a_Bill_Name"]) + "";

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemCombo.SearchCombo(cmbCommon[conCmbBillingTypes], Convert.ToInt32(localRec.Tables[0].Rows[0]["bill_type_id"]));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemCombo.SearchCombo(cmbCommon[conCmbBillingMethod], Convert.ToInt32(localRec.Tables[0].Rows[0]["bill_type_method"]));

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkIncludeInDefaultBillingTypes.CheckState = (CheckState) ((Convert.ToBoolean(localRec.Tables[0].Rows[0]["include_in_default_billing_types"])) ? 1 : 0);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					CHKIncludeInBankTransfer.CheckState = (CheckState) ((Convert.ToBoolean(localRec.Tables[0].Rows[0]["Include_In_Bank_Transfer"])) ? 1 : 0);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkIncludeInBudget.CheckState = (CheckState) ((Convert.ToBoolean(localRec.Tables[0].Rows[0]["Include_In_Budget"])) ? 1 : 0);
					//chkOverTime.Value = IIf(.Fields("over_time") = True, 1, 0)
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtComment.Text = Convert.ToString(localRec.Tables[0].Rows[0]["Comments"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					OptChkCalculate.Checked = ((Convert.ToBoolean(localRec.Tables[0].Rows[0]["is_calculate"])) ? 1 : 0) != 0;
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					OptPriodWise.Checked = ((Convert.ToBoolean(localRec.Tables[0].Rows[0]["is_period"])) ? 1 : 0) != 0;
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (!Convert.ToBoolean(localRec.Tables[0].Rows[0]["is_period"]) && !Convert.ToBoolean(localRec.Tables[0].Rows[0]["is_period"]))
					{
						OptNone.Checked = true;
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtNoOfMonths.Value = localRec.Tables[0].Rows[0]["No_of_Month"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtRoundDigit.Text = Convert.ToString(localRec.Tables[0].Rows[0]["Rounding_Method"]);
					//Change the form mode to edit
					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				}
				localRec = null;

				int mCntRow = 0;
				mysql = " select pbt.bill_no ,pbt.bill_cd ,  " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pbt.l_bill_name" : " pbt.a_bill_name") + " as bill_Name";
				mysql = mysql + " from pay_billing_type_details pbtd";
				mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = pbtd.linked_bill_cd";
				mysql = mysql + " where pbtd.bill_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				localRec = new DataSet();
				SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				localRec.Tables.Clear();
				adap_2.Fill(localRec);
				aVoucherDetails.RedimXArray(new int[]{localRec.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
				mCntRow = 0;
				foreach (DataRow iteration_row in localRec.Tables[0].Rows)
				{
					aVoucherDetails.SetValue(iteration_row["bill_no"], mCntRow, mconBillNo);
					aVoucherDetails.SetValue(iteration_row["bill_Name"], mCntRow, mconBillName);
					aVoucherDetails.SetValue(iteration_row["bill_cd"], mCntRow, mconbillCode);
					mCntRow++;
				}
				AssignGridLineNumbers();
				grdLeaveEarningDetails.Rebind(true);
				grdLeaveEarningDetails.Refresh();
				localRec = null;

				mFirstGridFocus = true;
				if (mFirstGridFocus)
				{
					grdLeaveEarningDetails_GotFocus(grdLeaveEarningDetails, new EventArgs());
				}

				this.tabBillingType.set_TabVisible(Convert.ToInt16(tabBillingDetails), true);
				this.tabBillingType.CurrTab = Convert.ToInt16(tabBillingDetails);
				Application.DoEvents();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}

		}

		public void PrintReport()
		{

		}

		public void findRecord()
		{
			//Call the find window
			string mysql = " pbt.show =  1 ";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7008000, "", mysql));
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
			if (!Information.IsNumeric(txtBillNo.Text))
			{
				MessageBox.Show("Enter Bill Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstFocusObject.Focus();
				return false;
			}

			if (!Information.IsNumeric(txtRoundDigit.Text))
			{
				MessageBox.Show("Enter Digits to Round", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtRoundDigit.Focus();
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
				oThisFormToolBar = null;
				frmPayBillingTypes.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}



		private bool isInitializingComponent;
		private void OptChkCalculate_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				txtNoOfMonths.Enabled = false;
			}
		}

		private void OptNone_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				txtNoOfMonths.Enabled = false;
			}
		}

		private void OptPriodWise_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				txtNoOfMonths.Enabled = OptPriodWise.Checked;
			}
		}

		private void txtBillNo_DropButtonClick(Object Sender, EventArgs e)
		{
			//Get the maximum + 1 product_category code
			GetNextNumber();
		}

		private void GetNextNumber()
		{
			txtBillNo.Text = SystemProcedure2.GetNewNumber("Pay_Billing_Type", "Bill_no");
			FirstFocusObject.Focus();
		}

		//'''' For Calculated field

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdLeaveEarningDetails.Col)
			{
				case mconBillNo : case mconBillName : 
					if (grdLeaveEarningDetails.Col == mconBillNo)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("bill_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("bill_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("bill_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("bill_name");
					} 
					 
					int tempForEndVar = cmbMastersList.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersList.Splits[0].DisplayColumns[cnt];
						if (cnt < 4)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdLeaveEarningDetails.Col == mconBillNo) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdLeaveEarningDetails.Splits[0].DisplayColumns[mconBillNo].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdLeaveEarningDetails.Col == mconBillNo) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdLeaveEarningDetails.Splits[0].DisplayColumns[mconBillName].Width;
							}
							withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							withVar.Visible = true;
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
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			if (grdLeaveEarningDetails.Col == mconBillNo || grdLeaveEarningDetails.Col == mconBillName)
			{
				grdLeaveEarningDetails.Columns[mconBillNo].Value = cmbMastersList.Columns[0].Value;
				grdLeaveEarningDetails.Columns[mconBillName].Value = cmbMastersList.Columns[1].Value;
				grdLeaveEarningDetails.Columns[mconbillCode].Value = cmbMastersList.Columns[4].Value;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			switch(grdLeaveEarningDetails.Col)
			{
				case mconBillNo : case mconBillName : 
					if (grdLeaveEarningDetails.Col == mconBillNo)
					{
						grdLeaveEarningDetails.Col = mconBillNo;
					}
					else
					{
						grdLeaveEarningDetails.Col = mconBillName;
					} 
					break;
			}
		}

		private void DefineMasterRecordset()
		{
			string mysql = "";

			//If IsItEmpty(mSearchValue, NumberType) = True Then
			//    Exit Sub
			//End If

			if (mFirstGridFocus)
			{
				mysql = " select bill_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_bill_name as bill_name" : "a_bill_name as bill_name");
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					mysql = mysql + " , (select l_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) ";
				}
				else
				{
					mysql = mysql + " , (select a_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) ";
				}
				mysql = mysql + " , pbt.bill_type_id as bill_type_id, pbt.bill_cd "; //''''''
				mysql = mysql + " from pay_billing_type pbt ";
				mysql = mysql + " where Is_Calculate = 0";
				// mysql = mysql & " and protected <> 1 "
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					mysql = mysql + " and bill_cd <> " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				}
				mysql = mysql + " order by 1 ";


				rsBillingCodeList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsBillingCodeList.Tables.Clear();
				adap.Fill(rsBillingCodeList);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsBillingCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList.Requery(-1);
			}
		}

		private void grdLeaveEarningDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			if (mFirstGridFocus)
			{
				if (Convert.ToString(cmbMastersList.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList);
					cmbMastersList.Tag = "OK";
				}

				DefineMasterRecordset();
				mFirstGridFocus = false;
				grdLeaveEarningDetails_Post(grdLeaveEarningDetails, new AxTrueOleDBGrid80.TrueDBGridEvents_PostEventEvent(1));
			}
		}

		private void grdLeaveEarningDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdLeaveEarningDetails.Col > 0 && LastCol > 0 && !mFirstGridFocus)
			{
				switch(grdLeaveEarningDetails.Col)
				{
					case mconBillNo : case mconBillName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList); 
						break;
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdLeaveEarningDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdLeaveEarningDetails_PostEvent(int MsgId)
		{
			int Col = 0;

			if (MsgId == 1)
			{
				grdLeaveEarningDetails.Col = mconBillNo;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList);
			}
		}

		public void IRoutine()
		{
			int mCurrentLineNo = 0;

			if (ActiveControl.Name != "grdLeaveEarningDetails" && grdLeaveEarningDetails.Enabled)
			{
				grdLeaveEarningDetails.Focus();
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdLeaveEarningDetails.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdLeaveEarningDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdLeaveEarningDetails.Columns[SystemICSConstants.grdLineNoColumn].Value);
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdLeaveEarningDetails.Bookmark), 1);
				AssignGridLineNumbers();
				grdLeaveEarningDetails.Rebind(true);
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdLeaveEarningDetails" && grdLeaveEarningDetails.Enabled)
			{
				grdLeaveEarningDetails.Focus();
			}

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdLeaveEarningDetails.Delete();
				AssignGridLineNumbers();
				grdLeaveEarningDetails.Rebind(true);
			}
		}

		//
		//Private Sub txtCommon_DropButtonClick(Index As Integer)
		//    Call FindRoutine("txtCommon#" & Trim(Index))
		//End Sub
		//
		//Private Sub txtCommon_LostFocus(Index As Integer)
		//Dim mTempValue As Variant
		//Dim mysql As String
		//Dim mLinkedTextBoxIndex As Integer
		//
		//On Error GoTo eFoundError
		//
		//Select Case Index
		//    Case conTxtLedgerCode
		//        mysql = "select l_ldgr_name, a_ldgr_name, ldgr_cd, curr_cd from ledger where show = 1 and ldgr_no='" & txtCommon(Index).Text & "'"
		//'        mysql = mysql & " and ( ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'"
		//'        mysql = mysql & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" & ")"
		//
		//        mLinkedTextBoxIndex = conDlblLedgerName
		//    Case conTxtCostCode
		//        mysql = "select l_cost_name, a_cost_name, cost_cd from gl_cost_centers where show = 1 and cost_no=" & txtCommon(Index).Text
		//        mLinkedTextBoxIndex = conDlblCostName
		//    Case Else
		//        Exit Sub
		//End Select
		//
		//If Not IsItEmpty(txtCommon(Index).Text, StringType) Then
		//    mTempValue = GetMasterCode(mysql)
		//    If IsNull(mTempValue) Then
		//        txtDisplayLabel(mLinkedTextBoxIndex).Text = ""
		//        txtCommon(Index).Tag = ""
		//        Err.Raise -9990002
		//    Else
		//        txtDisplayLabel(mLinkedTextBoxIndex).Text = IIf(gPreferedLanguage = english, mTempValue(0), mTempValue(1))
		//        txtCommon(Index).Tag = mTempValue(2)
		//    End If
		//Else
		//    txtCommonDisplay(mLinkedTextBoxIndex).Text = ""
		//    txtCommon(Index).Tag = ""
		//End If
		//Exit Sub
		//
		//
		//eFoundError:
		//Dim mReturnErrorType As Integer
		//mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord", msg10)
		//If mReturnErrorType = 1 Then
		//'
		//ElseIf mReturnErrorType = 2 Then
		//'
		//ElseIf mReturnErrorType = 3 Then
		//'
		//ElseIf mReturnErrorType = 4 Then
		//    'if the code is not found
		//    On Error Resume Next
		//    txtCommon(Index).SetFocus
		//Else
		//    '
		//End If
		//
		//End Sub
	}
}