
using System;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayCorrectionUtility
		: System.Windows.Forms.Form
	{

		public frmPayCorrectionUtility()
{
InitializeComponent();
} 
 public  void frmPayCorrectionUtility_old()
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


		private void frmPayCorrectionUtility_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		private clsToolbar oThisFormToolBar = null;
		private object mSearchValue = null;

		private const int conTabEmployee = 0;
		private const int conTabLeave = 1;
		private const int conTabLeaveResumtion = 2;
		private string mExpectedResumeDate = "";
		private int mEntryId = 0;



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



		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				object mReturnValue = null;
				if (KeyCode == 13)
				{
					if (this.ActiveControl.Name != "txtComments")
					{
						SendKeys.Send("{TAB}");
						return;
					}
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

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{
				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = false;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = false;
				oThisFormToolBar.ShowHelpButton = false;
				oThisFormToolBar.ShowInsertLineButton = false;
				oThisFormToolBar.ShowDeleteLineButton = false;
				oThisFormToolBar.ShowMoveRecordNextButton = false;
				oThisFormToolBar.ShowMoveRecordPreviousButton = false;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = false;

				this.WindowState = FormWindowState.Maximized;
				//Me.tabCorrectionUtility.CurrTab = conTabEmployee
				optoption_CheckedChanged(optoption[0], new EventArgs());
				SystemProcedure.SetLabelCaption(this);
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}

		}

		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearNumberBox(this);

			this.tabCorrectionUtility.CurrTab = Convert.ToInt16(conTabEmployee);

		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;
			string mysql = "";

			if (SystemProcedure2.IsItEmpty(pObjectName, SystemVariables.DataType.StringType))
			{
				return;
			}
			switch(pObjectName)
			{
				case "txtEmployeeNo" : 
					txtEmployeeNo.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtEmployeeNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtEmployeeNo_Leave(txtEmployeeNo, new EventArgs());
					} 
					break;
				case "txtLeaveTransNo" : 
					txtLeaveTransNo.Text = ""; 
					mysql = " pemp.emp_no = '" + txtEmployeeNo.Text + "' and plt.status = 1"; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7080000, "888", mysql)); 
					 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLeaveTransNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtLeaveTransNo_Leave(txtLeaveTransNo, new EventArgs());
					} 
					break;
				case "txtResumtionTransNo" : 
					txtResumtionTransNo.Text = ""; 
					mysql = " pemp.emp_no = '" + txtEmployeeNo.Text + "' and resume_processed_status = 1"; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7080000, "888", mysql)); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtResumtionTransNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtResumtionTransNo_Leave(txtResumtionTransNo, new EventArgs());
					} 
					break;
				default:
					break;
			}
		}

		private bool isInitializingComponent;
		private void optoption_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.optoption, eventSender);
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				this.tabCorrectionUtility.CurrTab = (short) Index;
				if (optoption[0].Checked)
				{
					this.tabCorrectionUtility.set_TabEnabled(Convert.ToInt16(conTabEmployee), true);
					this.tabCorrectionUtility.set_TabEnabled(Convert.ToInt16(conTabLeave), false);
					this.tabCorrectionUtility.set_TabEnabled(Convert.ToInt16(conTabLeaveResumtion), false);
				}
				if (optoption[1].Checked)
				{
					this.tabCorrectionUtility.set_TabEnabled(Convert.ToInt16(conTabEmployee), false);
					this.tabCorrectionUtility.set_TabEnabled(Convert.ToInt16(conTabLeave), true);
					this.tabCorrectionUtility.set_TabEnabled(Convert.ToInt16(conTabLeaveResumtion), false);
				}
				if (optoption[2].Checked)
				{
					this.tabCorrectionUtility.set_TabEnabled(Convert.ToInt16(conTabEmployee), false);
					this.tabCorrectionUtility.set_TabEnabled(Convert.ToInt16(conTabLeave), false);
					this.tabCorrectionUtility.set_TabEnabled(Convert.ToInt16(conTabLeaveResumtion), true);
				}
			}
		}

		private void txtActualResumeDate_Change(Object Sender, EventArgs e)
		{
			if (SystemProcedure2.IsItEmpty(mExpectedResumeDate))
			{
				return;
			}
			txtDisplayVariationDays.Text = (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtActualResumeDate.DisplayText).ToOADate() - DateTime.Parse(mExpectedResumeDate).ToOADate()).ToString();
		}

		private void txtEmployeeNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtEmployeeNo");
		}

		private void txtEmployeeNo_Leave(Object eventSender, EventArgs eventArgs)
		{

			if (SystemProcedure2.IsItEmpty(txtEmployeeNo.Text, SystemVariables.DataType.StringType))
			{
				return;
			}
			string mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_full_name" : " a_full_name") + " as name";
			mysql = mysql + " , date_of_joining, deduction_hrs, emp_cd";
			mysql = mysql + " from pay_employee where emp_no = '" + txtEmployeeNo.Text + "'";

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[1].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDeductionHrs.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(2));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtJoiningDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(3));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(3));
			}
			else
			{
				txtDisplayLabel[1].Text = "";
				txtEmployeeNo.Text = "";
				txtDeductionHrs.Value = 0;
				//txtJoiningDate.DisplayText = ""
				mSearchValue = 0;
				mEntryId = 0;
				txtEmployeeNo.Focus();
			}
		}


		private void txtLeaveTransNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtLeaveTransNo");
		}

		private void txtLeaveTransNo_Leave(Object eventSender, EventArgs eventArgs)
		{

			if (SystemProcedure2.IsItEmpty(txtLeaveTransNo.Text, SystemVariables.DataType.StringType))
			{
				return;
			}

			string mysql = "select entry_id";
			mysql = mysql + " from pay_leave_transaction ";
			mysql = mysql + " where voucher_no = " + txtLeaveTransNo.Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}
			else
			{
				mEntryId = 0;
			}
		}

		private void txtResumtionTransNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtResumtionTransNo");
		}

		public bool saveRecord()
		{
			bool result = false;
			object mReturnValue = null;
			string mysql = "";
			bool mDateChange = false;
			int mSelectedopt = 0;
			try
			{

				mDateChange = false;
				SystemVariables.gConn.BeginTransaction();

				if (optoption[0].Checked)
				{
					mysql = " select date_of_joining from pay_employee where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(mReturnValue) != ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtJoiningDate.Value))
					{
						mDateChange = true;
					}
					mysql = "update pay_employee";
					mysql = mysql + " set deduction_hrs = " + ReflectionHelper.GetPrimitiveValue<string>(txtDeductionHrs.Value);
					mysql = mysql + " , date_of_joining = '" + ReflectionHelper.GetPrimitiveValue<string>(txtJoiningDate.DisplayText) + "'";
					mysql = mysql + " where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					ReGeneratePayroll();
					//Clear Accrual all
					if (mDateChange)
					{
						ClearLastMonthAccrual(ReflectionHelper.GetPrimitiveValue<string>(txtJoiningDate.DisplayText), true);
					}
					mSelectedopt = 0;
				}
				else if (optoption[1].Checked)
				{ 
					mysql = "update pay_leave_transaction";
					mysql = mysql + " set status = 2";
					mysql = mysql + " , is_pay_closed = 1";
					mysql = mysql + " , processDate = '" + DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).ToString("dd-MMM-yyyy") + "'";
					mysql = mysql + " , payroll_date = '" + DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).ToString("dd-MMM-yyyy") + "'";
					mysql = mysql + " where voucher_no = " + txtLeaveTransNo.Text;
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

					mysql = " update pay_employee";
					mysql = mysql + " set status_cd = 2";
					mysql = mysql + " where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					//mReturnValue = GetMasterCode("select leave_start_date from pay_leave_transaction where voucher_no = " & txtLeaveTransNo.Text)
					//To Re Generate Time & Attandance and Payroll For Current Month
					ReGenerateTA();
					ReGeneratePayroll();
					//Call ClearLastMonthAccrual(CStr(mReturnValue))
					mSelectedopt = 1;
				}
				else if (optoption[2].Checked)
				{ 
					//mLastMonthEarning =
					mysql = "update pay_leave_transaction";
					mysql = mysql + " set Resume_Processed_Status = 2";
					mysql = mysql + " , Actual_Resume_Date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtActualResumeDate.DisplayText) + "'";
					mysql = mysql + " , Resume_ProcessDate = '" + DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).ToString("dd-MMM-yyyy") + "'";
					mysql = mysql + " , Resumed_Payroll_Date = '" + DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).ToString("dd-MMM-yyyy") + "'";
					mysql = mysql + " , Adjust_Paid_Days = " + ReflectionHelper.GetPrimitiveValue<string>(txtAdjustPaidDays.Value);
					mysql = mysql + " , Adjust_UnPaid_Days = " + ReflectionHelper.GetPrimitiveValue<string>(txtAdjustUnpaidDays.Value);
					mysql = mysql + " , Leave_Encashment_Days = " + ReflectionHelper.GetPrimitiveValue<string>(txtEncashmentDays.Value);
					mysql = mysql + " , Grant_Days = " + ReflectionHelper.GetPrimitiveValue<string>(txtGrantDays.Value);
					mysql = mysql + " where voucher_no = " + txtResumtionTransNo.Text;
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();

					mysql = " update pay_employee";
					mysql = mysql + " set status_cd = 1";
					mysql = mysql + " where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_5 = null;
					TempCommand_5 = SystemVariables.gConn.CreateCommand();
					TempCommand_5.CommandText = mysql;
					TempCommand_5.ExecuteNonQuery();


					//To Re Generate Time & Attandance and Payroll For Current Month
					ReGenerateTA();
					ReGeneratePayroll();
					//Call ClearLastMonthAccrual(txtActualResumeDate.DisplayText)
					mSelectedopt = 2;
				}
				//Insert into log
				mysql = "insert into pay_correction_utility";
				mysql = mysql + " (  entry_id,trans_type,emp_cd,deduction_hrs,date_of_joining,actual_resume_date";
				mysql = mysql + "   ,adjusted_paid_days,adjusted_unpaid_days,encashment_days,grant_days,user_cd";
				mysql = mysql + " ) values ";
				mysql = mysql + "(  " + mEntryId.ToString();
				mysql = mysql + " , " + mSelectedopt.ToString();
				mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtDeductionHrs.Value);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(txtJoiningDate.DisplayText))
				{
					mysql = mysql + " , NULL";
				}
				else
				{
					mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtJoiningDate.DisplayText) + "'";
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(txtActualResumeDate.DisplayText))
				{
					mysql = mysql + " , NULL";
				}
				else
				{
					mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtActualResumeDate.DisplayText) + "'";
				}
				mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtAdjustPaidDays.Value);
				mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtAdjustUnpaidDays.Value);
				mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtEncashmentDays.Value);
				mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtGrantDays.Value);
				mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
				mysql = mysql + " ) ";
				SqlCommand TempCommand_6 = null;
				TempCommand_6 = SystemVariables.gConn.CreateCommand();
				TempCommand_6.CommandText = mysql;
				TempCommand_6.ExecuteNonQuery();

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				return true;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
				MessageBox.Show(excep.Message, "Update System Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			return result;
		}

		public bool CheckDataValidity()
		{
			object mReturnValue = null;
			string mysql = "";

			if (optoption[1].Checked)
			{
				mysql = "select entry_id from pay_leave_transaction where voucher_no = " + txtLeaveTransNo.Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid leave transaction no.!!!", "Leave Post", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtLeaveTransNo.Focus();
					return false;
				}
			}
			else if (optoption[2].Checked)
			{ 
				mysql = "select entry_id from pay_leave_transaction where voucher_no = " + txtResumtionTransNo.Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid leave resumption transaction no.!!!", "Leave Post", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtResumtionTransNo.Focus();
					return false;
				}
			}

			return true;

		}

		public object ReGenerateTA()
		{
			try
			{

				//''msgbox comments to be check ...by hakim jamali 18-jul-2010
				if (!SystemHRProcedure.ClearTimeAttendanceCurrentMonthTransaction(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), ReflectionHelper.GetPrimitiveValue<int>(SearchValue)))
				{
					MessageBox.Show("Time & Attendance is not generated, Please try again!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return null;
				}

				if (!SystemHRProcedure.GenerateTimeAttendanceMonthlyTransaction(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), ReflectionHelper.GetPrimitiveValue<int>(SearchValue)))
				{
					MessageBox.Show("Time & Attendance is not generated, Please try again!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return null;
				}

				if (!SystemHRProcedure.UpdateVacationInTimeAttendance(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), ReflectionHelper.GetPrimitiveValue<int>(SearchValue)))
				{
					MessageBox.Show("Time & Attendance is not generated, Please try again!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return null;
				}

				if (!SystemHRProcedure.UpdateTimeAttendanceDayOff(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), ReflectionHelper.GetPrimitiveValue<int>(SearchValue)))
				{
					MessageBox.Show("Time & Attendance is not generated, Please try again!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return null;
				}

				//MsgBox "Time & Attendance Generated Successfully !", vbInformation
			}
			catch
			{
				MessageBox.Show("Transaction Not Posted", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return null;
		}

		private object ReGeneratePayroll()
		{

			//Clear Payroll
			//For Generate Payroll Entry Based On New Time and Attendance
			SystemHRProcedure.ClearPayroll(SystemHRProcedure.GetPayrollGenerateDate(), txtEmployeeNo.Text, txtEmployeeNo.Text);
			SystemHRProcedure.GeneratePayrollEntry(SystemHRProcedure.GetPayrollGenerateDate(), txtEmployeeNo.Text, txtEmployeeNo.Text);
			SystemHRProcedure.GenerateLeaveEntry(SystemHRProcedure.GetPayrollGenerateDate(), txtEmployeeNo.Text, txtEmployeeNo.Text);
			SystemHRProcedure.GenerateLoanEntry(SystemHRProcedure.GetPayrollGenerateDate(), txtEmployeeNo.Text, txtEmployeeNo.Text);

			return null;
		}

		private object ClearLastMonthAccrual(string pDate, bool pClearAll = false)
		{

			System.DateTime mMonthDate = DateAndTime.DateSerial(DateTime.Parse(pDate).Year, DateTime.Parse(pDate).Month, 1);
			mMonthDate = mMonthDate.AddDays(-1);
			int mYear = mMonthDate.Year;
			int mMonth = mMonthDate.Month;

			string mysql = " delete from pay_leave_accrual_summary";
			mysql = mysql + " from pay_leave_accrual_summary plas";
			mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = plas.plas_emp_cd";
			mysql = mysql + " where pemp.emp_no = '" + txtEmployeeNo.Text + "'";
			if (!pClearAll)
			{
				mysql = mysql + " and plas.plas_year >= " + mYear.ToString();
				mysql = mysql + " and plas.plas_month > " + mMonth.ToString();
			}
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = " delete from pay_indemnity_accrual_summary";
			mysql = mysql + " from pay_indemnity_accrual_summary pias";
			mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = pias.pias_emp_cd";
			mysql = mysql + " where pemp.emp_no = '" + txtEmployeeNo.Text + "'";
			if (!pClearAll)
			{
				mysql = mysql + " and pias.pias_year >= " + mYear.ToString();
				mysql = mysql + " and pias.pias_month > " + mMonth.ToString();
			}
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

			return null;
		}

		private void txtResumtionTransNo_Leave(Object eventSender, EventArgs eventArgs)
		{

			if (SystemProcedure2.IsItEmpty(txtResumtionTransNo.Text, SystemVariables.DataType.StringType))
			{
				return;
			}

			string mysql = "select actual_resume_date,adjust_paid_days,adjust_unpaid_days";
			mysql = mysql + " ,leave_encashment_days,grant_days,entry_id";
			mysql = mysql + " from pay_leave_transaction ";
			mysql = mysql + " where voucher_no = " + txtResumtionTransNo.Text;

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtActualResumeDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtAdjustPaidDays.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtAdjustUnpaidDays.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(2));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtEncashmentDays.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(3));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtGrantDays.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(4));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mExpectedResumeDate = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(5));
			}
			else
			{
				txtActualResumeDate.DisplayText = "";
				txtAdjustPaidDays.Value = 0;
				txtAdjustUnpaidDays.Value = 0;
				txtEncashmentDays.Value = 0;
				txtGrantDays.Value = 0;
				mEntryId = 0;
			}
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}