
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayPenaltyTrans
		: System.Windows.Forms.Form
	{

		public frmPayPenaltyTrans()
{
InitializeComponent();
} 
 public  void frmPayPenaltyTrans_old()
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


		private void frmPayPenaltyTrans_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private const int conTxtTransactionNo = 0;
		private const int conTxtEmpCode = 1;
		private const int conTxtComments = 3;
		private const int conTxtPenaltyCode = 4;
		private const int conTxtPenaltyAction = 5;


		private const int conDlblDeptCode = 0;
		private const int conDlblDeptName = 1;
		private const int conDlblDesgCode = 2;
		private const int conDlblDesgName = 3;
		private const int conDlblBasicSalary = 4;
		private const int conDlblRepeatedNoOfTimes = 5;
		private const int conDlblEmpName = 13;
		private const int conDlblPenaltyName = 14;

		private double mTotalSalary = 0;
		private double mDailysalary = 0;
		private double mPenaltySalary = 0;
		private double mDaysPerMonth = 0;

		private string mTimeStamp = "";
		private clsToolbar oThisFormToolBar = null;
		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

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


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			FirstFocusObject = txtCommonTextBox[conTxtTransactionNo];

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
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);

				//assign a next code
				txtCommonTextBox[conTxtTransactionNo].Text = SystemProcedure2.GetNewNumber("Pay_Penalty_Details", "transaction_no");

				txtVoucherDate.Value = DateTime.Today;
				txtStartDeductionDate.Value = DateTime.Today;
				txtDeductionDate.Value = DateTime.Today;
				txtActualPenaltyDate.Value = DateTime.Today;
				txtActualPenaltyTo.Value = DateTime.Today;
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
			SystemProcedure2.ClearTextBox(this);
			txtCommonTextBox[conTxtTransactionNo].Text = SystemProcedure2.GetNewNumber("Pay_Penalty_Details", "transaction_no");

			txtVoucherDate.Value = DateTime.Today;
			txtStartDeductionDate.Value = DateTime.Today;
			txtPenaltyAmount.Value = 0;
			txtDeductionDate.Value = DateTime.Today;
			txtActualPenaltyDate.Value = DateTime.Today;
			txtActualPenaltyTo.Value = DateTime.Today;
			txtPenaltyDays.Value = 0;
			txtMonthPercent.Value = 0;
			txtPenaltyDeductionAmount.Value = 0;
			txtNRepeatDeductPer.Value = 0;

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			FirstFocusObject.Focus();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord()
		{
			bool result = false;
			object mReturnValue = null;
			int mEmpCode = 0;
			int mDeptCode = 0;
			int mDesgCode = 0;
			int mPenaltyCd = 0;
			//Save a record
			//During save check for the mode
			//If in addmode then insert a record
			//else update the record in the recordset

			string mysql = "";
			try
			{

				mysql = "select emp_cd , dept_cd, desg_cd ";
				mysql = mysql + " from pay_employee ";
				mysql = mysql + " where ";
				mysql = mysql + " emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
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
				}

				mysql = "select penalty_cd from pay_penalty ";
				mysql = mysql + " where penalty_no = " + txtCommonTextBox[conTxtPenaltyCode].Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Penalty Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtCommonTextBox[conTxtPenaltyCode].Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mPenaltyCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				CalculateTotalDeductionAmt();

				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into pay_penalty_details ";
					mysql = mysql + " (emp_cd, dept_cd, penalty_cd, transaction_no, transaction_date ";
					mysql = mysql + " , penalty_deduction_amount ";
					mysql = mysql + " , penalty_repeated, penalty_action, remarks";
					mysql = mysql + " , penalty_month_percent, penalty_amount, penalty_days";
					mysql = mysql + " , deduction_Date, penalty_Date,Penalty_Date_To ,Deduct_Percetage, user_cd)";
					mysql = mysql + " values ( ";
					mysql = mysql + mEmpCode.ToString();
					mysql = mysql + " , " + mDeptCode.ToString();
					mysql = mysql + " , " + mPenaltyCd.ToString();
					mysql = mysql + " , " + txtCommonTextBox[conTxtTransactionNo].Text;
					mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText) + "'";
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtPenaltyDeductionAmount.Value);
					mysql = mysql + " , " + Conversion.Val(txtDisplayLabel[conDlblRepeatedNoOfTimes].Text).ToString();
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtPenaltyAction].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtComments].Text + "'";
					mysql = mysql + " ," + ReflectionHelper.GetPrimitiveValue<string>(txtMonthPercent.Value);
					mysql = mysql + " ," + ReflectionHelper.GetPrimitiveValue<string>(txtPenaltyAmount.Value);
					mysql = mysql + " ," + ReflectionHelper.GetPrimitiveValue<string>(txtPenaltyDays.Value);
					mysql = mysql + " ,'" + DateTime.Parse(txtDeductionDate.Text).ToString("dd/MMM/yyyy") + "'";
					mysql = mysql + " ,'" + DateTime.Parse(txtActualPenaltyDate.Text).ToString("dd/MMM/yyyy") + "'";
					mysql = mysql + " ,'" + DateTime.Parse(txtActualPenaltyTo.Text).ToString("dd/MMM/yyyy") + "'";
					mysql = mysql + " ," + ReflectionHelper.GetPrimitiveValue<string>(txtNRepeatDeductPer.Value);
					mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " ) ";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					mysql = " select time_stamp , is_pay_closed  from pay_penalty_details where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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

					if (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(1)))
					{
						MessageBox.Show("Record cannot be saved as payroll for the date specified is closed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						FirstFocusObject.Focus();
						return result;
					}

					mysql = " select entry_id from Pay_Loan_Cash_Payment where loan_entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Cash transaction exists for this Loan, Update failed!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						FirstFocusObject.Focus();
						return result;
					}

					mysql = " update pay_penalty_details set ";
					mysql = mysql + " emp_cd =" + mEmpCode.ToString();
					mysql = mysql + " , dept_cd =" + mDeptCode.ToString();
					mysql = mysql + " , penalty_cd =" + mPenaltyCd.ToString();
					mysql = mysql + " , transaction_no =" + txtCommonTextBox[conTxtTransactionNo].Text;
					mysql = mysql + " , transaction_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText) + "'";
					mysql = mysql + " , penalty_deduction_amount =" + ReflectionHelper.GetPrimitiveValue<string>(txtPenaltyDeductionAmount.Value);
					mysql = mysql + " , penalty_action = N'" + txtCommonTextBox[conTxtComments].Text + "'";
					mysql = mysql + " , penalty_repeated =" + Conversion.Val(txtDisplayLabel[conDlblRepeatedNoOfTimes].Text).ToString();
					mysql = mysql + " , remarks = N'" + txtCommonTextBox[conTxtComments].Text + "'";
					mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " , Penalty_Month_Percent=" + ReflectionHelper.GetPrimitiveValue<string>(txtMonthPercent.Value);
					mysql = mysql + " , Penalty_Amount=" + ReflectionHelper.GetPrimitiveValue<string>(txtPenaltyAmount.Value);
					mysql = mysql + " , Penalty_Days=" + ReflectionHelper.GetPrimitiveValue<string>(txtPenaltyDays.Value);
					mysql = mysql + " , Deduction_Date= '" + DateTime.Parse(txtDeductionDate.Text).ToString("dd/MMM/yyyy") + "'";
					mysql = mysql + " , Penalty_Date= '" + DateTime.Parse(txtActualPenaltyDate.Text).ToString("dd/MMM/yyyy") + "'";
					mysql = mysql + " , Penalty_Date_To = '" + DateTime.Parse(txtActualPenaltyTo.Text).ToString("dd/MMM/yyyy") + "'";
					mysql = mysql + " , Deduct_Percetage = " + ReflectionHelper.GetPrimitiveValue<string>(txtNRepeatDeductPer.Value);
					mysql = mysql + " where entry_id=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}

				mysql = "select emp_no from pay_employee where emp_cd = " + mEmpCode.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					SystemHRProcedure.ClearPayroll(SystemHRProcedure.GetPayrollGenerateDate(), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue));
					SystemHRProcedure.GeneratePayrollEntry(SystemHRProcedure.GetPayrollGenerateDate(), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue));
					SystemHRProcedure.GenerateLeaveEntry(SystemHRProcedure.GetPayrollGenerateDate(), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue));
					SystemHRProcedure.GenerateLoanEntry(SystemHRProcedure.GetPayrollGenerateDate(), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue));
				}


				//'''End

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
		{
			bool result = false;
			string mysql = "";
			object mReturnValue = null;
			int mEmpCd = 0;
			try
			{

				SystemVariables.gConn.BeginTransaction();

				mysql = " select is_pay_closed, emp_cd ";
				mysql = mysql + " from pay_penalty_details ";
				mysql = mysql + " where entry_id=" + Conversion.Str(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					if (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(0)))
					{
						MessageBox.Show("Record cannot be deleted as payroll is closed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
				}

				mysql = "delete from pay_penalty_details  where entry_id=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//Generate Payroll
				mysql = "select emp_no from pay_employee where emp_cd = " + mEmpCd.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					SystemHRProcedure.ClearPayroll(SystemHRProcedure.GetPayrollGenerateDate(), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue));
					SystemHRProcedure.GeneratePayrollEntry(SystemHRProcedure.GetPayrollGenerateDate(), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue));
					SystemHRProcedure.GenerateLeaveEntry(SystemHRProcedure.GetPayrollGenerateDate(), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue));
					SystemHRProcedure.GenerateLoanEntry(SystemHRProcedure.GetPayrollGenerateDate(), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue));
				}
				//End

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				return true;
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
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
			return result;
		}

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			//On Error GoTo eFoundError
			object mReturnValue = null;

			string mysql = " select * from pay_penalty_details where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

			SqlDataReader localRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand.ExecuteReader();
			if (localRec.Read())
			{
				//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(SearchValue);
				mTimeStamp = Convert.ToString(localRec["time_stamp"]);

				txtCommonTextBox[conTxtTransactionNo].Text = Convert.ToString(localRec["transaction_no"]);
				txtVoucherDate.Value = localRec["transaction_date"];

				mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "isnull(l_first_name,'') + ' ' + isnull(l_second_name,'') + ' ' + isnull(l_third_name,'') + ' ' + isnull(l_fourth_name,'')" : "isnull(a_first_name,'') + ' ' + isnull(a_second_name,'') + ' ' + isnull(a_third_name,'') + ' ' + isnull(a_fourth_name,'')");
				mysql = mysql + " , dept_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
				mysql = mysql + " , desg_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
				mysql = mysql + " , emp_no ";
				mysql = mysql + " , pemp.basic_salary, pemp.Total_Salary, pemp.days_per_month ";
				mysql = mysql + " ,pemp.rate_calc_method_id,pemp.weekend_day1_id,pemp.weekend_day2_id";
				mysql = mysql + " from pay_employee pemp , pay_department pdept, pay_designation pdesg ";
				mysql = mysql + " where ";
				mysql = mysql + " pemp.dept_cd = pdept.dept_cd and pemp.desg_cd = pdesg.desg_cd ";
				mysql = mysql + " and pemp.emp_cd = " + Convert.ToString(localRec["emp_cd"]);

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonTextBox[conTxtEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(5));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDeptCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDesgCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(4));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTotalSalary = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(7));

				if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(9)) == SystemHRProcedure.gFixedDays)
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDaysPerMonth = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(8));
				}
				else if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(9)) == SystemHRProcedure.gActualDays)
				{ 
					mDaysPerMonth = SystemHRProcedure.CalculateDays(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()), DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(10)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(11)));
				}

				mysql = "select penalty_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_penalty_name" : "a_penalty_name");
				mysql = mysql + " , penalty_cd";
				mysql = mysql + " from pay_penalty where penalty_cd = " + Convert.ToString(localRec["penalty_cd"]);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[conTxtPenaltyCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDisplayLabel[conDlblPenaltyName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mPenaltySalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select dbo.paygetpenaltysalary(" + Convert.ToString(localRec["emp_cd"]) + "," + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2)) + ")"));
					mDailysalary = mPenaltySalary / mDaysPerMonth;
				}

				txtPenaltyAmount.Value = localRec["penalty_amount"];
				txtPenaltyDeductionAmount.Value = localRec["penalty_deduction_amount"];
				txtCommonTextBox[conTxtPenaltyAction].Text = Convert.ToString(localRec["penalty_action"]) + "";
				txtCommonTextBox[conTxtComments].Text = Convert.ToString(localRec["remarks"]) + "";
				txtMonthPercent.Value = localRec["Penalty_Month_Percent"];
				txtPenaltyAmount.Value = localRec["Penalty_Amount"];
				txtPenaltyDays.Value = localRec["Penalty_Days"];
				txtDeductionDate.Value = localRec["Deduction_Date"];
				txtActualPenaltyDate.Value = localRec["Penalty_Date"];
				txtActualPenaltyTo.Value = (Convert.IsDBNull(localRec["Penalty_Date_To"])) ? localRec["Penalty_Date"] : localRec["Penalty_Date_To"];
				txtNRepeatDeductPer.Value = localRec["Deduct_Percetage"];
				txtDisplayLabel[conDlblRepeatedNoOfTimes].Text = Convert.ToString(localRec["penalty_repeated"]);
				//Change the form mode to edit
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			}
			localRec.Close();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void PrintReport()
		{
			//Dim mEntryID As Long
			//
			//If CurrentFormMode = frmEditMode Then
			//    mEntryID = SearchValue
			//Else
			//    Exit Sub
			//End If
			//Call GetCrystalReport(110013082, 2, "7887", Str(mEntryID), False)

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7065000));
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
			if (!Information.IsNumeric(txtCommonTextBox[conTxtTransactionNo].Text))
			{
				MessageBox.Show("Enter the Penalty No.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtTransactionNo].Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Employee Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtEmpCode].Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtPenaltyCode].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Penalty Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtPenaltyCode].Focus();
				return false;
			}


			if (SystemProcedure2.IsItEmpty(txtPenaltyDeductionAmount.Value, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Penalty Amount cannot be zero", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtPenaltyAmount.Focus();
				return false;
			}

			if (!Information.IsDate(txtVoucherDate.DisplayText))
			{
				MessageBox.Show("Enter valid date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtVoucherDate.Focus();
				return false;
			}

			if (!Information.IsDate(txtDeductionDate.DisplayText))
			{
				MessageBox.Show("Enter valid date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtDeductionDate.Focus();
				return false;
			}
			if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDeductionDate.DisplayText) < DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()))
			{
				MessageBox.Show("Invalid date, should be in payroll period.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtDeductionDate.Focus();
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
				frmPayPenaltyTrans.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void GetNextNumber()
		{
			txtCommonTextBox[conTxtTransactionNo].Text = SystemProcedure2.GetNewNumber("pay_penalty_details", "entry_id");
			FirstFocusObject.Focus();
		}

		private void txtActualPenaltyDate_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;
				int mDaysInMonth = 0;
				object mReturnValue = null;
				int mRepeatNo = 0;
				double mPenaltyValue = 0;

				if (Information.IsDate(txtActualPenaltyDate.Value))
				{
					//'To Get Repeat Penalty No
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtPenaltyCode].Text, SystemVariables.DataType.NumberType) && !SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
					{
						RepeatePenaltyNo(txtCommonTextBox[conTxtEmpCode].Text, Convert.ToInt32(Double.Parse(txtCommonTextBox[conTxtPenaltyCode].Text)));
						mRepeatNo = Convert.ToInt32(Conversion.Val(txtDisplayLabel[conDlblRepeatedNoOfTimes].Text));
						mysql = "select Penalty_value,l_Penalty_Desc,a_Penalty_Desc";
						mysql = mysql + " from Pay_Penalty pp";
						mysql = mysql + " inner join Pay_Penalty_Setup pps on pp.Penalty_Cd = pps.Penalty_Cd";
						mysql = mysql + " where Repetition_No = " + mRepeatNo.ToString() + " and Penalty_No = " + txtCommonTextBox[conTxtPenaltyCode].Text;
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							txtCommonTextBox[conTxtPenaltyAction].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2)) + "";
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtNRepeatDeductPer.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(0));
							//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
							txtPenaltyDeductionAmount.Value = (Convert.ToDouble(ReflectionHelper.GetPrimitiveValue<double>(txtPenaltyDays.Value) + ReflectionHelper.GetPrimitiveValue<double>(txtNRepeatDeductPer.Value))) * mDailysalary; //txtPenaltyDays.Value * txtNRepeatDeductPer.Value * mDailysalary
						}
					}
					//'End
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(excep.Message + Information.Err().Number.ToString(), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			object mTempSearchValue = null;
			if (Index == conTxtTransactionNo)
			{
				GetNextNumber();
			}
			else if (Index == conTxtPenaltyCode)
			{ 
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7064000, "2397"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[conTxtPenaltyCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				}
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
				string mysql = "";
				int cnt = 0;
				int mDaysInMonth = 0;
				object mReturnValue = null;
				int mRepeatNo = 0;
				double mPenaltyValue = 0;

				if (Index == conTxtEmpCode)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name" : "a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name");
						mysql = mysql + " , dept_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
						mysql = mysql + " , desg_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
						mysql = mysql + " , emp_cd ";
						mysql = mysql + " , pemp.basic_salary , pemp.Total_Salary, pemp.days_per_month";
						mysql = mysql + " , pemp.rate_calc_method_id,pemp.weekend_day1_id,pemp.weekend_day2_id";
						mysql = mysql + " from pay_employee pemp , pay_department pdept, pay_designation pdesg ";
						mysql = mysql + " where ";
						mysql = mysql + " pemp.dept_cd = pdept.dept_cd and pemp.desg_cd = pdesg.desg_cd ";
						mysql = mysql + " and pemp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
						mysql = mysql + " and pemp.status_cd <> " + SystemHRProcedure.gStatusTerminated.ToString() + " and pemp.rate_calc_method_id <> " + SystemHRProcedure.gDailyWages.ToString();
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblEmpName].Text = "";
							txtDisplayLabel[conDlblDeptCode].Text = "";
							txtDisplayLabel[conDlblDeptName].Text = "";
							txtDisplayLabel[conDlblDesgCode].Text = "";
							txtDisplayLabel[conDlblDesgName].Text = "";
							MessageBox.Show("Invalid Employee code.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtCommonTextBox[conTxtEmpCode].Focus();
							return;
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
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTotalSalary = ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(7));
							if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(9)) == SystemHRProcedure.gFixedDays)
							{
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mDaysPerMonth = ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(8));
							}
							else if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(9)) == SystemHRProcedure.gActualDays)
							{ 
								mDaysPerMonth = SystemHRProcedure.CalculateDays(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()), DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()), ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(10)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(11)));
							}
						}
						//'To Get Repeat Penalty No
						if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtPenaltyCode].Text, SystemVariables.DataType.NumberType))
						{
							RepeatePenaltyNo(txtCommonTextBox[conTxtEmpCode].Text, Convert.ToInt32(Double.Parse(txtCommonTextBox[conTxtPenaltyCode].Text)));
						}
						//'End
					}
					else
					{
						txtDisplayLabel[conDlblEmpName].Text = "";
						txtDisplayLabel[conDlblDeptCode].Text = "";
						txtDisplayLabel[conDlblDeptName].Text = "";
						txtDisplayLabel[conDlblDesgCode].Text = "";
						txtDisplayLabel[conDlblDesgName].Text = "";
					}

				}
				else if (Index == conTxtPenaltyCode)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[Index].Text, SystemVariables.DataType.StringType))
					{
						mysql = "select pp.penalty_cd, " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pp.l_penalty_name" : "pp.a_penalty_name");
						mysql = mysql + " from pay_penalty pp where penalty_no ='" + txtCommonTextBox[conTxtPenaltyCode].Text + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue))
						{
							txtDisplayLabel[conDlblPenaltyName].Text = "";
							MessageBox.Show("Invalid Penalty Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtCommonTextBox[conTxtPenaltyCode].Focus();
							return;
						}
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDisplayLabel[conDlblPenaltyName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.NumberType))
						{

							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select dbo.paygetpenaltysalary(" + SystemHRProcedure.GetEmpCd(txtCommonTextBox[conTxtEmpCode].Text).ToString() + "," + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)) + ")"));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mReturnValue))
							{
								mPenaltySalary = 0;
								MessageBox.Show("Penalty salary details need to be defined", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							else
							{
								//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mPenaltySalary = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
							}
							mDailysalary = mPenaltySalary / mDaysPerMonth;
						}
					}
					else
					{
						txtDisplayLabel[conDlblPenaltyName].Text = "";
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
					txtCommonTextBox[conTxtEmpCode].Focus();
				}
				else
				{
					//
				}
			}
		}


		public void FindRoutine(string pObjectName)
		{
			//Dim mySql As String
			object mTempSearchValue = null;
			string mysql = "";

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

			switch(mIndex)
			{
				case conTxtEmpCode : 
					txtCommonTextBox[conTxtEmpCode].Text = ""; 
					mysql = "pay_emp.status_cd <>" + SystemHRProcedure.gStatusTerminated.ToString() + " and pay_emp.rate_calc_method_id <>" + SystemHRProcedure.gDailyWages.ToString(); 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", mysql)); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					 
					break;
				case conTxtPenaltyCode : 
					txtCommonTextBox[conTxtPenaltyCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7064000, "2397")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtPenaltyCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					 
					break;
				default:
					return;
			}
		}



		private void txtMonthPercent_Leave(Object eventSender, EventArgs eventArgs)
		{
			txtPenaltyDays.Value = ReflectionHelper.GetPrimitiveValue<double>(txtMonthPercent.Value) / 100d;
			CalculateTotalDeductionAmt();
		}

		private void CalculateTotalDeductionAmt()
		{
			if (ReflectionHelper.GetPrimitiveValue<double>(txtPenaltyDays.Value) == 0 && ReflectionHelper.GetPrimitiveValue<double>(txtPenaltyAmount.Value) == 0)
			{
				txtPenaltyAmount.Enabled = true;
				txtPenaltyDays.Enabled = true;
				txtMonthPercent.Enabled = true;
				txtPenaltyAmount.BackColor = SystemColors.Window;
				txtPenaltyDays.BackColor = SystemColors.Window;
				txtMonthPercent.BackColor = SystemColors.Window;
			}
			else if ((ReflectionHelper.GetPrimitiveValue<double>(txtPenaltyDays.Value) > 0))
			{ 
				txtPenaltyAmount.Enabled = false;
				txtPenaltyDays.Enabled = true;
				txtMonthPercent.Enabled = true;
				txtPenaltyAmount.BackColor = Color.FromArgb(239, 239, 239);
				txtPenaltyDays.BackColor = SystemColors.Window;
				txtMonthPercent.BackColor = SystemColors.Window;
			}
			else if ((ReflectionHelper.GetPrimitiveValue<double>(txtPenaltyAmount.Value) > 0))
			{ 
				txtPenaltyAmount.Enabled = true;
				txtPenaltyDays.Enabled = false;
				txtMonthPercent.Enabled = false;
				txtPenaltyAmount.BackColor = SystemColors.Window;
				txtPenaltyDays.BackColor = Color.FromArgb(239, 239, 239);
				txtMonthPercent.BackColor = Color.FromArgb(239, 239, 239);
			}

			if (ReflectionHelper.GetPrimitiveValue<double>(txtPenaltyDays.Value) > 0)
			{
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				txtPenaltyDeductionAmount.Value = (Convert.ToDouble(ReflectionHelper.GetPrimitiveValue<double>(txtPenaltyDays.Value) + ReflectionHelper.GetPrimitiveValue<double>(txtNRepeatDeductPer.Value))) * mDailysalary;
				//txtPenaltyDeductionAmount.Value = txtPenaltyDeductionAmount.Value + (txtPenaltyDeductionAmount.Value * txtNRepeatDeductPer.Value)
			}
			else
			{
				//UPGRADE_WARNING: (1068) txtPenaltyAmount.Value of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtPenaltyDeductionAmount.Value = ReflectionHelper.GetPrimitiveValue(txtPenaltyAmount.Value);
			}
		}

		private void txtPenaltyAmount_Leave(Object eventSender, EventArgs eventArgs)
		{
			CalculateTotalDeductionAmt();
		}

		private void txtPenaltyDays_Leave(Object eventSender, EventArgs eventArgs)
		{
			txtMonthPercent.Value = ReflectionHelper.GetPrimitiveValue<double>(txtPenaltyDays.Value) * 100;
			CalculateTotalDeductionAmt();
		}


		private void RepeatePenaltyNo(string pEmpNo, int pPenaltyNo)
		{
			int mEmpCd = 0;
			int mPenaltyCd = 0;

			string mysql = " select emp_cd from pay_employee where emp_no= '" + pEmpNo + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}
			else
			{
				return;
			}
			mysql = " select penalty_cd from pay_penalty where penalty_no=" + pPenaltyNo.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mPenaltyCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}
			else
			{
				return;
			}
			mysql = "select count(*) as No ";
			mysql = mysql + " from pay_penalty_details ";
			mysql = mysql + " where(emp_cd=" + mEmpCd.ToString() + ") and (penalty_cd=" + mPenaltyCd.ToString() + ")";
			mysql = mysql + " and Penalty_Date >= '" + ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtActualPenaltyDate.Value).AddMonths(-3).ToString("dd-MMM-yyyy") + "'";
			mysql = mysql + " and Penalty_Date < '" + ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtActualPenaltyDate.Value).ToString("dd-MMM-yyyy") + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				txtDisplayLabel[conDlblRepeatedNoOfTimes].Text = (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) + 1).ToString();
			}
		}
	}
}