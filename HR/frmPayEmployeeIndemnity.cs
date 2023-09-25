
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayEmployeeIndemnity
		: System.Windows.Forms.Form
	{

		private clsAccessAllowed _UserAccess = null;
		public frmPayEmployeeIndemnity()
{
InitializeComponent();
} 
 public  void frmPayEmployeeIndemnity_old()
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

		private const int conTxtNIndemnityDaysBeforeSOP = 0;
		private const int conTxtNWDPerMonthBeforeSOP = 1;
		private const int conTxtNIndemnityDaysAfterSOP = 2;
		private const int conTxtNWDPerMonthAfterSOP = 3;
		private const int conTxtNOpeningIndemnityBalanceDays = 4;
		//Private Const conTxtNOpeningIndemnityBalAmount As Integer = 5

		private const int conTxtIndemnitySwitchOverPeriod = 0;

		private const int conDlblEmpCode = 0;
		private const int conDlblEmpName = 1;
		//Private Const conDlblIndemnityBalAsOf As Integer = 4
		//Private Const conDlblIndemnityAmtAsOf As Integer = 5

		private const int conDlblIndemnityBalAsOf = 4;
		private const int conDlblIndemnityAmtAsOf = 5;

		private const int conCmbDeductPaidDays = 0;
		private const int conCmbDeductUnPaidDays = 1;
		private const int conCmbDeductAbsentDays = 2;


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


		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					FirstFocusObject.Focus();
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
				clsHourGlass myHourGlass = null;

				myHourGlass = new clsHourGlass();

				FirstFocusObject = txtCommon[conTxtIndemnitySwitchOverPeriod];
				//picFormToolbar.Visible = False
				this.Top = 0;
				this.Left = 0;
				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = false;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				//'Assign the Image for the toolbar
				//'Imagelist are kept on the main form and refered by their key
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture

				SystemProcedure.SetLabelCaption(this);

				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(1))
				//picFormToolbar.Visible = True


				object[] mObjectId = new object[3];
				mObjectId[conCmbDeductPaidDays] = 1009;
				mObjectId[conCmbDeductUnPaidDays] = 1009;
				mObjectId[conCmbDeductAbsentDays] = 1009;

				SystemCombo.FillComboWithSystemObjects(CmbCommon, mObjectId);
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

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmPayEmployeeIndemnity.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void btnFormToolBar_Click(int Index)
		{
			//Call grdVoucherDetails_LostFocus

			//**--commented by : abbas
			//**--comment date : 15-nov-2005
			//**--hakim pls check this line
			//Call ToolBarButtonClick(Me, btnFormToolBar(Index).Tag)
		}

		public bool saveRecord(bool pApprove = false)
		{

			//On Error GoTo eFoundError

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				return false;
			}

			SystemVariables.gConn.BeginTransaction();

			//mysql = " select emp_cd from pay_employee "
			//mysql = mysql & " where emp_cd=" & mSearchValue

			//mReturnValue = GetMasterCode(mysql)
			//If Not IsNull(mReturnValue) Then
			string mysql = " update pay_employee set ";
			mysql = mysql + " indemnity_switch_over_period =" + txtCommon[conTxtIndemnitySwitchOverPeriod].Text;
			mysql = mysql + " , indemnity_days_before_sop =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conTxtNIndemnityDaysBeforeSOP].Value);
			mysql = mysql + " , indemnity_days_after_sop =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conTxtNIndemnityDaysAfterSOP].Value);
			mysql = mysql + " , indemnity_working_days_per_month_before_sop =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conTxtNWDPerMonthBeforeSOP].Value);
			mysql = mysql + " , indemnity_working_days_per_month_after_sop =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conTxtNWDPerMonthAfterSOP].Value);
			mysql = mysql + " , indemnity_deduct_paid_days =" + CmbCommon[conCmbDeductPaidDays].GetItemData(CmbCommon[conCmbDeductPaidDays].ListIndex).ToString();
			mysql = mysql + " , indemnity_deduct_unpaid_days =" + CmbCommon[conCmbDeductUnPaidDays].GetItemData(CmbCommon[conCmbDeductUnPaidDays].ListIndex).ToString();
			mysql = mysql + " , indemnity_deduct_absent_days =" + CmbCommon[conCmbDeductAbsentDays].GetItemData(CmbCommon[conCmbDeductAbsentDays].ListIndex).ToString();
			mysql = mysql + " , opening_indemnity_balance_days =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conTxtNOpeningIndemnityBalanceDays].Value);
			//mysql = mysql & " , opening_indemnity_balance_amount=" & txtCommonNumber(conTxtNOpeningIndemnityBalAmount).Value
			//mysql = mysql & " , opening_indemnity_as_on='" & txtOpeningBalanceAsOn.DisplayText & "'"
			mysql = mysql + " , user_cd=" + Conversion.Str(SystemVariables.gLoggedInUserCode);
			mysql = mysql + " where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();
			//End If

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

			return true;



			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			//If mReturnErrorType = 1 Then
			//    mSearchValue = GetMasterCode("vgl_accnt_group", "group_no", txtGroupNo.Text, "group_cd")
			//    Call GetRecord("vaccnt_group", "group_cd", mSearchValue, StringType)
			//    saveRecord = False
			//ElseIf mReturnErrorType = 2 Then
			//    Call AddRecord
			//    saveRecord = False
			//ElseIf mReturnErrorType = 3 Then
			//    Call AddRecord
			//    saveRecord = False
			//Else
			//    saveRecord = False
			//End If
			return false;
		}

		public bool CheckDataValidity()
		{

			if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Select an employee!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			//If Not IsDate(txtOpeningBalanceAsOn.Value) Then
			//    MsgBox "Invalid Date!", vbInformation
			//    CheckDataValidity = False
			//    'txtOpeningBalanceAsOn.SetFocus
			//    Exit Function
			//End If

			return true;
		}

		public void AddRecord()
		{

			try
			{

				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
				SystemProcedure2.ClearTextBox(this);
				mSearchValue = ""; //Change the msearchvalue to blank
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}


		}

		public void GetRecord(object pSearchValue)
		{
			object mReturnValue = null;
			System.DateTime mPayrollDate = DateTime.FromOADate(0);
			SqlDataReader rsLocalRec = null;

			double mIndemnityBalanceDays = 0;
			decimal mIndemnitySalary = 0;
			int mDaysPerMonth = 0;

			//On Error GoTo eFoundError

			string mysql = " select pay_emp.* ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name as emp_name";
			}
			else
			{
				mysql = mysql + " , a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name as emp_name ";
			}
			mysql = mysql + " from pay_employee pay_emp ";
			mysql = mysql + " where pay_emp.emp_cd = " + Conversion.Str(pSearchValue);

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			if (rsLocalRec.Read())
			{
				mSearchValue = rsLocalRec["emp_cd"];
				txtDisplayLabel[conDlblEmpCode].Text = Convert.ToString(rsLocalRec["emp_no"]);
				txtDisplayLabel[conDlblEmpName].Text = Convert.ToString(rsLocalRec["emp_name"]);

				txtCommon[conTxtIndemnitySwitchOverPeriod].Text = Convert.ToString(rsLocalRec["indemnity_switch_over_period"]);
				txtCommonNumber[conTxtNIndemnityDaysBeforeSOP].Value = rsLocalRec["indemnity_days_before_sop"];
				txtCommonNumber[conTxtNIndemnityDaysAfterSOP].Value = rsLocalRec["indemnity_days_after_sop"];
				txtCommonNumber[conTxtNWDPerMonthBeforeSOP].Value = rsLocalRec["indemnity_working_days_per_month_before_sop"];
				txtCommonNumber[conTxtNWDPerMonthAfterSOP].Value = rsLocalRec["indemnity_working_days_per_month_after_sop"];
				SystemCombo.SearchCombo(CmbCommon[conCmbDeductPaidDays], (Convert.ToBoolean(rsLocalRec["indemnity_deduct_paid_days"])) ? 1 : 0);
				SystemCombo.SearchCombo(CmbCommon[conCmbDeductUnPaidDays], (Convert.ToBoolean(rsLocalRec["indemnity_deduct_unpaid_days"])) ? 1 : 0);
				SystemCombo.SearchCombo(CmbCommon[conCmbDeductAbsentDays], (Convert.ToBoolean(rsLocalRec["indemnity_deduct_absent_days"])) ? 1 : 0);
				txtCommonNumber[conTxtNOpeningIndemnityBalanceDays].Value = rsLocalRec["opening_indemnity_balance_days"];
				//txtCommonNumber(conTxtNOpeningIndemnityBalAmount).Value = .Fields("opening_indemnity_balance_amount")
				if (!Convert.IsDBNull(rsLocalRec["opening_indemnity_as_on"]))
				{
					txtOpeningBalanceAsOn.Value = rsLocalRec["opening_indemnity_as_on"];
				}
				else
				{
					txtOpeningBalanceAsOn.Text = "";
				}

				mIndemnitySalary = Convert.ToDecimal(rsLocalRec["indemnity_salary"]);
				mDaysPerMonth = Convert.ToInt32(rsLocalRec["days_per_month"]);

				mIndemnityBalanceDays = SystemHRProcedure.IndemnityBalanceDays(Convert.ToInt32(rsLocalRec["emp_cd"]), DateTime.Parse(StringsHelper.Format(DateTime.Today, SystemVariables.gSystemDateFormat)));
				txtDisplayLabel[conDlblIndemnityBalAsOf].Text = StringsHelper.Format(mIndemnityBalanceDays, "###,###,##0.000");

				//'' Changed By Burhan
				//'' Date: 22-Jul-2007
				//'' Desc: Get Indemnity Amount from SQL funtion PayIndemnityAmount

				mysql = " select  round( dbo.payIndemnityAmount( ";
				mysql = mysql + Convert.ToString(rsLocalRec["emp_cd"]);
				mysql = mysql + " , " + mIndemnityBalanceDays.ToString();
				mysql = mysql + " , '" + StringsHelper.Format(DateTime.Today, SystemVariables.gSystemDateFormat) + "'), 3, 1 )";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue) && ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) != 0)
				{
					txtDisplayLabel[conDlblIndemnityAmtAsOf].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(mReturnValue), "###,###,##0.000");
				}
				else
				{
					txtDisplayLabel[conDlblIndemnityAmtAsOf].Text = "0.000";
				}

				//End


				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			}
			else
			{
				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				return;
			}

			//FirstFocusObject.SetFocus




			rsLocalRec.Close();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void CloseForm()
		{
			this.Close();
		}

		public void findRecord()
		{
			//Call the find window

			//mySql = " pay_emp.status_cd=1 "
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000)); //  ,  , mySql) altered by burhan coz all employees record should load regardless its active or not
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}
	}
}