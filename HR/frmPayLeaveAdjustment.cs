
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayLeaveAdjustment
		: System.Windows.Forms.Form
	{

		public frmPayLeaveAdjustment()
{
InitializeComponent();
} 
 public  void frmPayLeaveAdjustment_old()
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


		private void frmPayLeaveAdjustment_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private const int conTxtVoucherNo = 0;
		private const int conTxtEmpCode = 1;
		private const int conTXTReferenceNo = 2;
		private const int conTxtLeaveCode = 3;
		private const int conTxtComments = 4;

		private const int conDlblDeptCode = 0;
		private const int conDlblDeptName = 1;
		private const int conDlblDesgCode = 2;
		private const int conDlblDesgName = 3;
		private const int conDlblBasicSalary = 4;
		private const int conDlblTotalSalary = 5;
		private const int conDlblLeaveName = 6;
		private const int conDlblPaidDays = 7;
		private const int conDlblTotalDays = 8;
		private const int conDlblEmpName = 9;
		private const int conDlblUnpaidDays = 10;
		private const int conDlblTotalUnpaidDays = 11;
		private const int conDlblLeaveBalanceDay = 12;
		private const int conDlblLeaveAmount = 13;
		private const int conDlblLeaveSalary = 14;

		private const int conDTxtVoucheDate = 0;
		private const int conDTxtLeaveFrom = 1;
		private const int conDTxtLeaveTo = 2;

		private const int conNTxtAdjustDays = 0;
		private const int conNTxtAdjustUnpaidDays = 1;


		private clsToolbar oThisFormToolBar = null;
		private string mTimeStamp = "";
		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;
		int mTransType = 0;
		int mEmployeeTypeCd = 0;
		private frmPayLeaveAmount _frmLeaveAmount = null;
		frmPayLeaveAmount frmLeaveAmount
		{
			get
			{
				if (_frmLeaveAmount is null)
				{
					_frmLeaveAmount = frmPayLeaveAmount.CreateInstance();
				}
				return _frmLeaveAmount;
			}
			set
			{
				_frmLeaveAmount = value;
			}
		}



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


		private void cmbCommon_Click(Object Sender, EventArgs e)
		{
			mTransType = cmbCommon[0].GetItemData(cmbCommon[0].ListIndex);
			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				return;
			}

			if (mTransType == 150)
			{
				if (mEmployeeTypeCd == 148)
				{
					//cmdLeaveAmount.Visible = True
				}
				else
				{
					cmdLeaveAmount.Visible = false;
				}
			}
			else
			{
				cmdLeaveAmount.Visible = false;
			}
		}

		private void cmdLeaveAmount_Click(Object eventSender, EventArgs eventArgs)
		{
			if (ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtAdjustDays].Value) == 0)
			{
				MessageBox.Show("Please Put Encashment Days and then Click Here!", "Encashment", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonNumber[conNTxtAdjustDays].Focus();
				return;
			}
			//UPGRADE_WARNING: (1068) txtCommonDate().Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			frmLeaveAmount.mFromDate = ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtVoucheDate].Value);
			frmLeaveAmount.mSearchValue = SystemHRProcedure.GetEmpCd(txtCommonTextBox[conTxtEmpCode].Text);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			frmLeaveAmount.mLeaveCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select leave_cd from pay_leave where leave_no=" + txtCommonTextBox[conTxtLeaveCode].Text));
			frmLeaveAmount.mPaidDays = Math.Abs(ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtAdjustDays].Value));
			frmLeaveAmount.mCalltype = 2;
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mSearchValue))
			{
				//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				frmLeaveAmount.mLeaveEntID = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);
			}
			else
			{
				frmLeaveAmount.mLeaveEntID = 0;
			}
			frmLeaveAmount.ShowDialog();
			double mLeaveAmountForLTD = frmLeaveAmount.mTotalLeaveAmount;
			txtDisplayLabel[conDlblLeaveAmount].Text = mLeaveAmountForLTD.ToString();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			FirstFocusObject = txtCommonTextBox[conTxtVoucherNo];

			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
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
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowUnpostButton = true;
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
				//Set btnFormToolBar(7).Picture = frmSysMain.imlSystemIcons.ListImages("imgPostingTransactions").Picture

				SystemProcedure.SetLabelCaption(this);

				object[] mObjectId = new object[1];
				mObjectId[0] = 1032;
				SystemCombo.FillComboWithSystemObjects(cmbCommon, mObjectId);

				//assign a next code
				txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_leave_Adjustment", "voucher_no");
				txtCommonDate[conDTxtVoucheDate].Value = SystemHRProcedure.GetPayrollGenerateStartDate();
				txtCommonDate[conDTxtLeaveFrom].Value = SystemHRProcedure.GetPayrollGenerateStartDate();
				txtCommonDate[conDTxtLeaveTo].Value = SystemHRProcedure.GetPayrollGenerateStartDate();
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
				if (this.ActiveControl.Name == "txtCommonTextBox")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommonTextBox#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
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
			//mCheck = False
			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearNumberBox(this);
			txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_leave_adjustment", "voucher_no");

			txtCommonDate[conDTxtVoucheDate].Value = SystemHRProcedure.GetPayrollGenerateStartDate();
			txtCommonDate[conDTxtLeaveFrom].Value = SystemHRProcedure.GetPayrollGenerateStartDate();
			txtCommonDate[conDTxtLeaveTo].Value = SystemHRProcedure.GetPayrollGenerateStartDate();

			txtCommonTextBox[conTxtEmpCode].Enabled = true;
			txtCommonTextBox[conTxtLeaveCode].Enabled = true;

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			FirstFocusObject.Focus();
			mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
			mEmployeeTypeCd = 0;
			//mCheck = True
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord(bool pApprove = false)
		{
			bool result = false;
			int mEmpCode = 0;
			int mDeptCode = 0;
			int mDesgCode = 0;
			int mLeaveCode = 0;
			decimal mBasicSalary = 0;
			decimal mTotalSalary = 0;

			//On Error GoTo eFoundError

			string mysql = "select pemp.emp_cd , pemp.dept_cd, pemp.desg_cd , pemp.basic_salary ";
			mysql = mysql + " , pemp.total_salary, pleave.leave_cd ";
			mysql = mysql + " from pay_employee_leave_details peld ";
			mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = peld.emp_cd ";
			mysql = mysql + " inner join pay_leave pleave on peld.leave_cd = pleave.leave_cd ";
			mysql = mysql + " where ";
			mysql = mysql + " emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
			mysql = mysql + " and leave_no = " + txtCommonTextBox[conTxtLeaveCode].Text;

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				MessageBox.Show("Invalid Employee Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = false;
				txtCommonTextBox[conTxtEmpCode].Focus();
				return result;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEmpCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mDeptCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mDesgCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mBasicSalary = ReflectionHelper.GetPrimitiveValue<decimal>(((Array) mReturnValue).GetValue(3));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTotalSalary = ReflectionHelper.GetPrimitiveValue<decimal>(((Array) mReturnValue).GetValue(4));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mLeaveCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(5));
			}


			SystemVariables.gConn.BeginTransaction();
			string mCheckTimeStamp = "";
			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				mysql = " insert into pay_leave_adjustment ";
				mysql = mysql + " (emp_cd, dept_cd, desg_cd, leave_cd, voucher_no, voucher_date, reference_no ";
				mysql = mysql + " , basic_salary, total_salary, Paid_Leave_Days, Adjust_Paid_Leave_Days";
				mysql = mysql + " , unpaid_Leave_Days , Adjust_unpaid_Leave_Days ";
				mysql = mysql + " , comments, user_cd,leave_balance,leave_amount,trans_type,leave_salary ,Leave_From , Leave_To) ";
				mysql = mysql + " values ( ";
				mysql = mysql + mEmpCode.ToString();
				mysql = mysql + " , " + mDeptCode.ToString();
				mysql = mysql + " , " + mDesgCode.ToString();
				mysql = mysql + " , " + mLeaveCode.ToString();
				mysql = mysql + " , " + txtCommonTextBox[conTxtVoucherNo].Text;
				mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtVoucheDate].DisplayText) + "'";
				mysql = mysql + " , '" + txtCommonTextBox[conTXTReferenceNo].Text + "'";
				mysql = mysql + " , " + mBasicSalary.ToString();
				mysql = mysql + " , " + mTotalSalary.ToString();
				mysql = mysql + " , " + ((txtDisplayLabel[conDlblPaidDays].Text.Trim() != "") ? StringsHelper.Format(txtDisplayLabel[conDlblPaidDays].Text, "##########0.000") : "0");
				mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtAdjustDays].Value);
				mysql = mysql + " , " + ((txtDisplayLabel[conDlblUnpaidDays].Text.Trim() != "") ? StringsHelper.Format(txtDisplayLabel[conDlblUnpaidDays].Text, "##########0.000") : "0");
				mysql = mysql + " , " + Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtAdjustUnpaidDays].Value)).ToString();
				mysql = mysql + " , '" + txtCommonTextBox[conTxtComments].Text + "'";
				mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
				mysql = mysql + " , " + Conversion.Val(txtDisplayLabel[conDlblLeaveBalanceDay].Text).ToString();
				mysql = mysql + " , " + ((SystemProcedure2.IsItEmpty(Conversion.Val(txtDisplayLabel[conDlblLeaveAmount].Text))) ? 0 : Conversion.Val(txtDisplayLabel[conDlblLeaveAmount].Text)).ToString();
				mysql = mysql + " , " + cmbCommon[0].GetItemData(cmbCommon[0].ListIndex).ToString();
				mysql = mysql + " , " + Conversion.Val(txtDisplayLabel[conDlblLeaveSalary].Text).ToString();
				mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLeaveFrom].DisplayText) + "'";
				mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLeaveTo].DisplayText) + "'";
				mysql = mysql + " ) ";

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));
			}
			else
			{
				mysql = " select time_stamp from pay_leave_adjustment where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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

				//    mySql = " select adjust_paid_leave_days from pay_leave_adjustment "
				//    mySql = mySql & " where entry_id = " & mSearchValue
				//    mReturnValue = GetMasterCode(mySql)

				mysql = " update pay_leave_adjustment set ";
				mysql = mysql + " emp_cd =" + mEmpCode.ToString();
				mysql = mysql + " , dept_cd =" + mDeptCode.ToString();
				mysql = mysql + " , desg_cd =" + mDesgCode.ToString();
				mysql = mysql + " , leave_cd =" + mLeaveCode.ToString();
				mysql = mysql + " , voucher_no =" + txtCommonTextBox[conTxtVoucherNo].Text;
				mysql = mysql + " , voucher_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtVoucheDate].DisplayText) + "'";
				mysql = mysql + " , reference_no ='" + txtCommonTextBox[conTXTReferenceNo].Text + "'";
				mysql = mysql + " , basic_salary =" + StringsHelper.Format(txtDisplayLabel[conDlblBasicSalary].Text, "##########0.000");
				mysql = mysql + " , total_salary =" + StringsHelper.Format(txtDisplayLabel[conDlblTotalSalary].Text, "##########0.000");
				mysql = mysql + " , Paid_Leave_Days =" + ((txtDisplayLabel[conDlblPaidDays].Text.Trim() != "") ? StringsHelper.Format(txtDisplayLabel[conDlblPaidDays].Text, "##########0.000") : "0");
				mysql = mysql + " , Adjust_Paid_Leave_Days =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtAdjustDays].Value);
				mysql = mysql + " , unpaid_Leave_Days =" + ((txtDisplayLabel[conDlblUnpaidDays].Text.Trim() != "") ? StringsHelper.Format(txtDisplayLabel[conDlblUnpaidDays].Text, "##########0.000") : "0");
				mysql = mysql + " , adjust_unpaid_Leave_Days =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtAdjustUnpaidDays].Value);
				mysql = mysql + " , comments ='" + txtCommonTextBox[conTxtComments].Text + "'";
				mysql = mysql + " , leave_balance =" + Conversion.Val(txtDisplayLabel[conDlblLeaveBalanceDay].Text).ToString();
				mysql = mysql + " , leave_amount =" + Conversion.Val(txtDisplayLabel[conDlblLeaveAmount].Text).ToString();
				mysql = mysql + " , trans_type =" + cmbCommon[0].GetItemData(cmbCommon[0].ListIndex).ToString();
				mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
				mysql = mysql + " , leave_salary =" + Conversion.Val(txtDisplayLabel[conDlblLeaveSalary].Text).ToString();
				mysql = mysql + " , Leave_From = '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLeaveFrom].DisplayText) + "'";
				mysql = mysql + " , Leave_To = '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLeaveTo].DisplayText) + "'";
				mysql = mysql + " where entry_id=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				//    mySql = " update pay_employee_leave_details "
				//    mySql = mySql & " set "
				//    mySql = mySql & " paid_leave_taken_days = (paid_leave_taken_days + " & Str(txtCommonNumber(conNTxtAdjustDays).Value) & ") - " & mReturnValue
				//    mySql = mySql & " where emp_cd =" & mEmpCode
				//    mySql = mySql & " and leave_cd =" & mLeaveCode
				//    gConn.Execute mySql

			}

			mysql = " delete from Pay_Leave_Encash_Employee_Contract_Details where Adjustment_Entry_Id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mysql;
			TempCommand_3.ExecuteNonQuery();
			int cnt = 0;
			int tempForEndVar = frmLeaveAmount.aVoucherDetails.GetLength(0) - 2;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mysql = mysql + "insert into pay_leave_employee_contract_details(Leave_Entry_Id,emp_Contract_Entry_Id,Leave_Days_Taken,leave_Days_Amount)";
				mysql = mysql + " values(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mysql = mysql + " , " + Convert.ToString(frmLeaveAmount.aVoucherDetails.GetValue(cnt, 0)); //For Entry ID
				mysql = mysql + " ," + Convert.ToString(frmLeaveAmount.aVoucherDetails.GetValue(cnt, 5)); //For Leave Days Taken
				mysql = mysql + " ," + Convert.ToString(frmLeaveAmount.aVoucherDetails.GetValue(cnt, 6)); //For Leave Days Amount
				mysql = mysql + ")";
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();
			}


			if (pApprove)
			{
				SystemHRProcedure.PayPostToHR("Pay_leave_adjustment", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
				SystemHRProcedure.PayApprove("Pay_leave_adjustment", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
				Leave_Adjustment_Post_Effect(SearchValue);
			}


			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			result = true;
			FirstFocusObject.Focus();
			return result;


			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
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

			string mysql = " delete from pay_leave_adjustment  where entry_id=" + Conversion.Str(mSearchValue);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();


			return true;

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

			//On Error GoTo eFoundError

			string mysql = " select pla.* ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "isnull(l_first_name,'') + ' ' + isnull(l_second_name,'') + ' ' + isnull(l_third_name,'') + ' ' + isnull(l_fourth_name,'')" : "isnull(a_first_name,'') + ' ' + isnull(a_second_name,'') + ' ' + isnull(a_third_name,'') + ' ' + isnull(a_fourth_name,'')") + " as emp_name ";
			mysql = mysql + " , emp_no ,weekend , weekend_day1_id, weekend_day2_id ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name") + " as dept_name ";
			mysql = mysql + " , dept_no ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name") + " as desg_name ";
			mysql = mysql + " , desg_no ";
			mysql = mysql + " , pemp.basic_salary, pemp.total_salary ";
			mysql = mysql + " , leave_no ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_leave_name" : "a_leave_name") + " as leave_name ";
			mysql = mysql + " , pemp.emp_type_id ";
			mysql = mysql + " from pay_leave_adjustment pla ";
			mysql = mysql + " inner join pay_employee pemp on pla.emp_cd = pemp.emp_cd ";
			mysql = mysql + " inner join pay_leave pleave on pla.leave_cd = pleave.leave_cd ";
			mysql = mysql + " inner join pay_department pdept on  pemp.dept_cd = pdept.dept_cd ";
			mysql = mysql + " inner join pay_designation pdesg on  pemp.desg_cd = pdesg.desg_cd  ";
			mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);


			DataSet localRec = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			localRec.Tables.Clear();
			adap.Fill(localRec);
			if (localRec.Tables[0].Rows.Count != 0)
			{
				//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(SearchValue);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mTimeStamp = Convert.ToString(localRec.Tables[0].Rows[0]["time_stamp"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtVoucherNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["voucher_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDate[conDTxtVoucheDate].Value = localRec.Tables[0].Rows[0]["voucher_date"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDate[conDTxtLeaveFrom].Value = localRec.Tables[0].Rows[0]["Leave_From"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDate[conDTxtLeaveTo].Value = localRec.Tables[0].Rows[0]["Leave_To"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTXTReferenceNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["reference_no"]) + "";

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtEmpCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["emp_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblEmpName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["emp_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDeptCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["dept_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDeptName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["dept_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDesgCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["desg_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDesgName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["desg_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblBasicSalary].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["basic_salary"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblTotalSalary].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["total_salary"], "###,###,##0.000");

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtLeaveCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["leave_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLeaveName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["leave_name"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblPaidDays].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["paid_leave_days"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtAdjustDays].Value = localRec.Tables[0].Rows[0]["adjust_paid_leave_days"];

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblUnpaidDays].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["unpaid_leave_days"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtAdjustUnpaidDays].Value = localRec.Tables[0].Rows[0]["adjust_unpaid_leave_days"];

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLeaveBalanceDay].Text = Convert.ToString(localRec.Tables[0].Rows[0]["leave_balance"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLeaveAmount].Text = Convert.ToString(localRec.Tables[0].Rows[0]["leave_amount"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemCombo.SearchCombo(cmbCommon[0], Convert.ToInt32(localRec.Tables[0].Rows[0]["Trans_Type"]));

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtComments].Text = Convert.ToString(localRec.Tables[0].Rows[0]["comments"]) + "";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLeaveSalary].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["leave_salary"], "########0.000");

				//Change the form mode to edit
				txtCommonTextBox[conTxtEmpCode].Enabled = false;
				txtCommonTextBox[conTxtLeaveCode].Enabled = false;
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mEmployeeTypeCd = Convert.ToInt32(localRec.Tables[0].Rows[0]["emp_type_id"]);
				//Set the form caption and Get the Voucher Status
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, frmPayLeaveAdjustment.DefInstance, Convert.ToInt32(localRec.Tables[0].Rows[0]["status"]), CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Leave Adjustment" : "Leave Adjustment");
			}
			CmbCommon_Click(cmbCommon[0], null);
			localRec = null;

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}


		public void PrintReport()
		{
			int mEntryId = 0;

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
			}
			else
			{
				return;
			}
			SystemReports.GetCrystalReport(110121235, 2, "9603", Conversion.Str(mEntryId), false);
		}


		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7090000, "920"));
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

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 3);
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				goto mend;
			}

			//Check validation during update and add of records
			if (!Information.IsNumeric(txtCommonTextBox[conTxtVoucherNo].Text))
			{
				MessageBox.Show("Enter the Loan No.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtVoucherNo].Focus();
				goto mend;
			}

			if (!Information.IsDate(txtCommonDate[conDTxtVoucheDate].DisplayText))
			{
				MessageBox.Show("Enter valid date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonDate[conDTxtVoucheDate].Focus();
				goto mend;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Employee Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtEmpCode].Focus();
				goto mend;
			}

			if (mTransType == 150)
			{
				if (Conversion.Val(Math.Abs(Double.Parse(txtDisplayLabel[conDlblLeaveAmount].Text)).ToString()) <= 0)
				{
					MessageBox.Show("Leave Amount can't be zero !", "Leave Encashment", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonNumber[conNTxtAdjustDays].Focus();
					goto mend;
				}
			}
			//' Commented by: Burhan Ghee Wala
			//' Date: 27-Nov-2007
			//' Desc: Adjust Paid Days can be zero valued

			//If IsItEmpty(txtCommonNumber(conNTxtAdjustDays).Value, NumberType) Then
			//    MsgBox "Adjust days cannot be zero", vbInformation, "Required"
			//    txtCommonNumber(conNTxtAdjustDays).SetFocus
			//    GoTo mend
			//End If

			//' End Comment

			//'  Date 02-Jan-2012 For Chacked Effective Date Should be current Month
			if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtVoucheDate].Value) < DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()) || ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtVoucheDate].Value) > DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()))
			{
				MessageBox.Show("Leave Adjustment cannot be backdated or for next period!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonDate[conDTxtVoucheDate].Focus();
			}
			else
			{


				return true;
			}
			mend:
			return false;

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmPayLeaveAdjustment.DefInstance = null;
				frmLeaveAmount = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void GetNextNumber()
		{
			txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_leave_adjustment", "voucher_no");
			FirstFocusObject.Focus();
		}

		private void txtCommonDate_Change(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonDate, Sender);
			try
			{
				string mysql = "";
				object mTempValue = null;

				if (Index == conDTxtLeaveFrom)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtLeaveCode].Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_leave_name" : "a_leave_name");
						mysql = mysql + " , leave_no, paid_leave_taken_days, unpaid_leave_taken_days, pemp.emp_cd, pleave.leave_cd ";
						mysql = mysql + " from pay_employee_leave_details peld ";
						mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = peld.emp_cd ";
						mysql = mysql + " inner join pay_leave pleave on peld.leave_cd = pleave.leave_cd ";
						mysql = mysql + " where ";
						mysql = mysql + " emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
						mysql = mysql + " and leave_no = " + txtCommonTextBox[conTxtLeaveCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtCommonTextBox[Index].Text = "";
							txtDisplayLabel[conDlblLeaveName].Text = "";
							txtDisplayLabel[conDlblPaidDays].Text = "";
							txtDisplayLabel[conDlblUnpaidDays].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblLeaveName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
							txtDisplayLabel[conDlblPaidDays].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(2)), "###,###,##0.000");
							txtDisplayLabel[conDlblUnpaidDays].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(3)), "###,###,##0.000");
							txtDisplayLabel[conDlblLeaveBalanceDay].Text = StringsHelper.Format(SystemHRProcedure.Leave_Balance_Days(ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(4)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(5)), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFrom].Value)), "###,###,##0.000");
						}
					}
					else
					{
						txtDisplayLabel[conDlblLeaveName].Text = "";
						txtDisplayLabel[conDlblPaidDays].Text = "";
						txtDisplayLabel[conDlblUnpaidDays].Text = "";
					}
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void txtCommonNumber_Change(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonNumber, Sender);
			string mysql = "";
			object mReturnValue = null;
			int mEmpCode = 0;
			int mLeaveCode = 0;

			if (Index == conNTxtAdjustDays)
			{
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (txtDisplayLabel[conDlblPaidDays].Text.Trim() != "" && !Convert.IsDBNull(txtCommonNumber[conNTxtAdjustDays].Value))
				{
					txtDisplayLabel[conDlblTotalDays].Text = StringsHelper.Format(Double.Parse(StringsHelper.Format(txtDisplayLabel[conDlblPaidDays].Text, "############0.000")) - ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtAdjustDays].Value), "########0.000");
				}
				else
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(txtCommonNumber[conNTxtAdjustDays].Value))
					{
						//UPGRADE_WARNING: (1068) txtCommonNumber().Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDisplayLabel[conDlblTotalDays].Text = ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtAdjustDays].Value);
					}
					else
					{
						txtDisplayLabel[conDlblTotalDays].Text = "0.000";
					}
				}

				if (mTransType == 150 && Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtAdjustDays].Value)) != 0)
				{
					//      If mEmployeeTypeCd = 148 Then
					//        txtDisplayLabel(conDlblLeaveAmount).Text = "0.000"
					//      Else
					mEmpCode = SystemHRProcedure.GetEmpCd(txtCommonTextBox[conTxtEmpCode].Text);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLeaveCode = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select leave_cd from pay_leave where leave_no=" + txtCommonTextBox[conTxtLeaveCode].Text));
					mysql = " select dbo.payLeaveAmount(" + mEmpCode.ToString() + "," + mLeaveCode.ToString() + "," + Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtAdjustDays].Value)).ToString() + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtVoucheDate].DisplayText) + "')";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						txtDisplayLabel[conDlblLeaveAmount].Text = StringsHelper.Format(Math.Abs(ReflectionHelper.GetPrimitiveValue<double>(mReturnValue)), "########0.000");
					}
					else
					{
						txtDisplayLabel[conDlblLeaveAmount].Text = "0.000";
					}
					//      End If
				}
				else
				{
					txtDisplayLabel[conDlblLeaveAmount].Text = "0.000";
				}
			}
			else if (Index == conNTxtAdjustUnpaidDays)
			{ 
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (txtDisplayLabel[conDlblUnpaidDays].Text.Trim() != "" && !Convert.IsDBNull(txtCommonNumber[conNTxtAdjustUnpaidDays].Value))
				{
					txtDisplayLabel[conDlblTotalUnpaidDays].Text = StringsHelper.Format(Double.Parse(StringsHelper.Format(txtDisplayLabel[conDlblUnpaidDays].Text, "############0.000")) - ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtAdjustUnpaidDays].Value), "########0.000");
				}
				else
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(txtCommonNumber[conNTxtAdjustUnpaidDays].Value))
					{
						//UPGRADE_WARNING: (1068) txtCommonNumber().Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDisplayLabel[conDlblTotalUnpaidDays].Text = ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtAdjustUnpaidDays].Value);
					}
					else
					{
						txtDisplayLabel[conDlblTotalUnpaidDays].Text = "0.000";
					}
				}
			}
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			if (Index == conTxtVoucherNo)
			{
				GetNextNumber();
			}
			else
			{
				FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
			}
		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			try
			{
				object mTempValue = null;
				int mEmpCd = 0;
				string mysql = "";
				int cnt = 0;

				if (Index == conTxtEmpCode)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name" : "a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name");
						mysql = mysql + " , dept_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
						mysql = mysql + " , desg_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
						mysql = mysql + " , emp_cd";
						mysql = mysql + " , pemp.basic_salary, pemp.total_salary,emp_type_id  ";
						mysql = mysql + " , " + SystemHRProcedure.GetEmpAnnualLeaveSalary(txtCommonTextBox[conTxtEmpCode].Text).ToString() + " as Leave_sal";
						mysql = mysql + " from pay_employee pemp , pay_department pdept, pay_designation pdesg ";
						mysql = mysql + " where ";
						mysql = mysql + " pemp.dept_cd = pdept.dept_cd and pemp.desg_cd = pdesg.desg_cd ";
						mysql = mysql + " and pemp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
						//''Only Active Employee
						mysql = mysql + " and pemp.status_cd = 1 ";

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtCommonTextBox[Index].Text = "";
							txtDisplayLabel[conDlblEmpName].Text = "";
							txtDisplayLabel[conDlblDeptCode].Text = "";
							txtDisplayLabel[conDlblDeptName].Text = "";
							txtDisplayLabel[conDlblDesgCode].Text = "";
							txtDisplayLabel[conDlblDesgName].Text = "";
							txtDisplayLabel[conDlblBasicSalary].Text = "";
							txtDisplayLabel[conDlblTotalSalary].Text = "";
							txtDisplayLabel[conDlblLeaveSalary].Text = "";
							mEmployeeTypeCd = 0;
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDeptCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDesgCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));
							txtDisplayLabel[conDlblBasicSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(6)), "###,###,##0.000");
							txtDisplayLabel[conDlblTotalSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(7)), "###,###,##0.000");
							mEmployeeTypeCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(8));
							txtDisplayLabel[conDlblLeaveSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(9)), "########0.000");
							CmbCommon_Click(cmbCommon[0], null);
						}
					}
					else
					{
						txtDisplayLabel[conDlblEmpName].Text = "";
						txtDisplayLabel[conDlblDeptCode].Text = "";
						txtDisplayLabel[conDlblDeptName].Text = "";
						txtDisplayLabel[conDlblDesgCode].Text = "";
						txtDisplayLabel[conDlblDesgName].Text = "";
						txtDisplayLabel[conDlblBasicSalary].Text = "";
						txtDisplayLabel[conDlblTotalSalary].Text = "";
						mEmployeeTypeCd = 0;
					}
				}
				else if (Index == conTxtLeaveCode)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtLeaveCode].Text, SystemVariables.DataType.NumberType))
					{

						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_leave_name" : "a_leave_name");
						mysql = mysql + " , leave_no, paid_leave_taken_days, unpaid_leave_taken_days, pemp.emp_cd, pleave.leave_cd ";
						mysql = mysql + " from pay_employee_leave_details peld ";
						mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = peld.emp_cd ";
						mysql = mysql + " inner join pay_leave pleave on peld.leave_cd = pleave.leave_cd ";
						mysql = mysql + " where ";
						mysql = mysql + " emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
						mysql = mysql + " and leave_no = " + txtCommonTextBox[conTxtLeaveCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtCommonTextBox[Index].Text = "";
							txtDisplayLabel[conDlblLeaveName].Text = "";
							txtDisplayLabel[conDlblPaidDays].Text = "";
							txtDisplayLabel[conDlblUnpaidDays].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblLeaveName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
							txtDisplayLabel[conDlblPaidDays].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(2)), "###,###,##0.000");
							txtDisplayLabel[conDlblUnpaidDays].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(3)), "###,###,##0.000");
							txtDisplayLabel[conDlblLeaveBalanceDay].Text = StringsHelper.Format(SystemHRProcedure.Leave_Balance_Days(ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(4)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(5)), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtVoucheDate].Value)), "###,###,##0.000");
						}
					}
					else
					{
						txtDisplayLabel[conDlblLeaveName].Text = "";
						txtDisplayLabel[conDlblPaidDays].Text = "";
						txtDisplayLabel[conDlblUnpaidDays].Text = "";
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
					txtCommonTextBox[Index].Focus();
				}
				else
				{
					//
				}
			}

		}


		public void FindRoutine(string pObjectName)
		{
			string mysql = "";
			object mTempSearchValue = null;

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));


			if (mObjectName == "txtCommonTextBox")
			{
				txtCommonTextBox[mIndex].Text = "";
				switch(mIndex)
				{
					case conTxtEmpCode : 
						mysql = " pay_emp.status_cd = 1 "; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", mysql)); 
						break;
					case conTxtLeaveCode : 
						if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
						{
							mysql = " pay_emp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
							//''Only Active Employee
							mysql = mysql + " and pay_emp.status_cd = 1 ";
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7070000, "876", mysql));
						}
						else
						{
							MessageBox.Show("Select an Employee ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtCommonTextBox[conTxtEmpCode].Focus();
						} 
						break;
					default:
						return;
				}
			}

			//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue) && !Object.Equals(mTempSearchValue, null))
			{
				if (mObjectName == "txtCommonTextBox")
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[mIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
				}
			}
		}

		public bool UnPost()
		{
			bool result = false;


			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				MessageBox.Show("You are currently in AddMode!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			if (mOldVoucherStatus == SystemVariables.VoucherStatus.stActive)
			{
				MessageBox.Show("Voucher is not posted!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			string mysql = "select is_pay_closed from pay_leave_adjustment where entry_id =" + ReflectionHelper.GetPrimitiveValue<int>(mSearchValue).ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
			{
				MessageBox.Show("Can not Unpost, Payroll month is closed!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			DialogResult ans = MessageBox.Show("Do you want to Unpost the Record ?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

			string myString = "";
			if (ans == System.Windows.Forms.DialogResult.Yes)
			{
				SystemVariables.gConn.BeginTransaction();

				myString = "update pay_leave_adjustment ";
				myString = myString + " set posted_HR = 0 ";
				myString = myString + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = myString;
				TempCommand.ExecuteNonQuery();

				myString = "update pay_leave_adjustment ";
				myString = myString + " set status = 1 ";
				myString = myString + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = myString;
				TempCommand_2.ExecuteNonQuery();
				Leave_Adjustment_UnPost_Effect(SearchValue);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				AddRecord();
			}
			else if (ans == System.Windows.Forms.DialogResult.No)
			{ 
				AddRecord();
				result = false;
			}
			else if (ans == System.Windows.Forms.DialogResult.Cancel)
			{ 
				result = false;
			}
			return result;
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

			//If mOldVoucherStatus = stActive Then
			//    frmTemp.VisiblePostTransactionToICS = False
			//    frmTemp.VisiblePostToGL = False
			//    frmTemp.EnableApprove = True
			//End If

			frmTemp.ShowDialog();

			//if the user clicks on OK button in the frmPost form
			//If frmTemp.mLastButtonClicked = 1 And frmTemp.mApprove = True Then
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

							SystemHRProcedure.PayPostToHR("pay_leave_adjustment", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
							SystemHRProcedure.PayApprove("pay_leave_adjustment", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));

							Leave_Adjustment_Post_Effect(SearchValue);

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


		private void Leave_Adjustment_Post_Effect(object pSearchValue)
		{

			string mysql = " select adjust_paid_leave_days,emp_cd, leave_cd from pay_leave_adjustment ";
			mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			mysql = " update pay_employee_leave_details ";
			mysql = mysql + " set ";
			mysql = mysql + " paid_leave_taken_days = paid_leave_taken_days - " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
			mysql = mysql + " where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
			mysql = mysql + " and leave_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();
		}

		private void Leave_Adjustment_UnPost_Effect(object pSearchValue)
		{

			string mysql = " select adjust_paid_leave_days,emp_cd, leave_cd from pay_leave_adjustment ";
			mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			mysql = " update pay_employee_leave_details ";
			mysql = mysql + " set ";
			mysql = mysql + " paid_leave_taken_days = paid_leave_taken_days + " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
			mysql = mysql + " where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
			mysql = mysql + " and leave_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();
		}
	}
}