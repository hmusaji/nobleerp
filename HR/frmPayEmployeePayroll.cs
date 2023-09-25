
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayEmployeePayroll
		: System.Windows.Forms.Form
	{

		private clsAccessAllowed _UserAccess = null;
		public frmPayEmployeePayroll()
{
InitializeComponent();
} 
 public  void frmPayEmployeePayroll_old()
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

		private const int conTabPersonnelBasic = 0;
		private const int conTabPersonnelDetailed = 1;
		private const int conTabPersonnelPayroll = 2;
		private const int conTabPersonnelLeave = 3;
		private const int conTabPersonnelOthers = 4;

		private const int conCmbWeekEndDay1 = 0;
		private const int conCmbWeekEndDay2 = 1;
		private const int conCmbOverTimeCalcMethod = 2;
		private const int conCmbPaymentType = 3;
		private const int conCmbAccountType = 4;
		private const int conCmbPayrollEmp = 5;
		private const int conCmbOverTime = 6;
		private const int conCmbRateCalcMethod = 7;

		private const int conTxtWeekEnd = 0;
		private const int conTxtBankCode = 1;
		private const int conTxtBankBranchCode = 2;
		private const int conTxtAccountNo = 3;
		private const int conTxtTransferToBank = 4;

		private const int conDlblEmpCode = 0;
		private const int conDlblEmpName = 1;
		private const int conDlblBasicSalary = 2;
		private const int conDlblTotalSalary = 3;
		private const int conDlblStatus = 5;
		private const int conDlblBankName = 6;
		private const int conDlblBankBranchName = 7;
		private const int conDlblTransferToBank = 8;

		private const int conLblWeekendDay2 = 5;
		private const int conLblWeekendDay1 = 6;

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


		private void chkMobileAllowance_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			//If chkMobileAllowance.Value = 1 Then
			//    txtMobileAllowance.Enabled = True
			//    txtMobileAllowance.BackColor = vbWhite
			//Else
			//    txtMobileAllowance.Enabled = False
			//    txtMobileAllowance.BackColor = gDisableColumnBackColor
			//    txtMobileAllowance.Value = 0
			//End If
		}


		private void cmbCommon_Click(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.cmbCommon, Sender);
			if (Index == conCmbRateCalcMethod)
			{
				if (cmbCommon[conCmbRateCalcMethod].GetItemData(cmbCommon[conCmbRateCalcMethod].ListIndex) == 60)
				{
					txtDaysPerMonth.Enabled = true;
					txtHoursPerDay.Enabled = true;
					txtRatePerHours.Enabled = false;
				}
				else if (cmbCommon[conCmbRateCalcMethod].GetItemData(cmbCommon[conCmbRateCalcMethod].ListIndex) == 61)
				{ 
					txtDaysPerMonth.Value = 0;
					txtDaysPerMonth.Enabled = false;
					txtHoursPerDay.Enabled = true;
					txtRatePerHours.Enabled = false;
				}
				else if (cmbCommon[conCmbRateCalcMethod].GetItemData(cmbCommon[conCmbRateCalcMethod].ListIndex) == 130)
				{ 
					txtDaysPerMonth.Value = 0;
					//txtHoursPerDay.Value = 0
					txtDaysPerMonth.Enabled = false;
					//txtHoursPerDay.Enabled = False
					txtRatePerHours.Enabled = true;
				}
			}
			else if (Index == conCmbOverTime)
			{ 
				if (cmbCommon[conCmbOverTime].GetItemData(cmbCommon[conCmbOverTime].ListIndex) == 1)
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					txtNormalOT.Value = (Convert.IsDBNull(SystemProcedure2.GetSystemPreferenceSetting("normalot"))) ? ((object) 0) : SystemProcedure2.GetSystemPreferenceSetting("normalot");
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					txtFridayOT.Value = (Convert.IsDBNull(SystemProcedure2.GetSystemPreferenceSetting("fridayot"))) ? ((object) 0) : SystemProcedure2.GetSystemPreferenceSetting("fridayot");
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					txtHolidayOT.Value = (Convert.IsDBNull(SystemProcedure2.GetSystemPreferenceSetting("holidayot"))) ? ((object) 0) : SystemProcedure2.GetSystemPreferenceSetting("holidayot");
				}
				else
				{
					txtNormalOT.Value = 0;
					txtFridayOT.Value = 0;
					txtHolidayOT.Value = 0;
				}
			}
		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				chkMobileAllowance.CheckState = CheckState.Unchecked;
				chkMobileAllowance_CheckStateChanged(chkMobileAllowance, new EventArgs());
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			int cnt = 0;

			clsHourGlass myHourGlass = new clsHourGlass();

			FirstFocusObject = cmbCommon[conCmbPayrollEmp];
			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;


				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = false;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = false;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;
				//
				//
				//'Assign the Image for the toolbar
				//'Imagelist are kept on the main form and refered by their key
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(1))
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture

				SystemProcedure.SetLabelCaption(this);


				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				//Fill the combo
				object[] mObjectId = new object[8];
				mObjectId[conCmbWeekEndDay1] = 1005;
				mObjectId[conCmbWeekEndDay2] = 1005;
				mObjectId[conCmbOverTimeCalcMethod] = 1006;
				mObjectId[conCmbPaymentType] = 1007;
				mObjectId[conCmbAccountType] = 1008;
				mObjectId[conCmbPayrollEmp] = 1009;
				mObjectId[conCmbOverTime] = 1009;
				mObjectId[conCmbRateCalcMethod] = 1013;

				SystemCombo.FillComboWithSystemObjects(cmbCommon, mObjectId);

				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_Calendar")))
				{
					txtCalendarCd.Visible = false;
					txtDlblCalendarName.Visible = false;
					lblCalendar.Visible = false;
					txtCalendarCd.Text = "1";
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
			txtNOTWorkingHrs.Value = 0;
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			FirstFocusObject.Focus();
			txtCommonTextBox[conTxtBankCode].Enabled = true;
			cmbCommon[conCmbPaymentType].Enabled = true;
			txtCommonTextBox[conTxtAccountNo].Enabled = true;
			txtCommonTextBox[conTxtTransferToBank].Enabled = true;
			txtAccountNo.Enabled = true;
			chkMobileAllowance.CheckState = CheckState.Unchecked;
			chkIncludeInPayslipPrinting.CheckState = CheckState.Unchecked;
			txtMobileAllowance.Value = 0;
			chkHoldSalary.CheckState = CheckState.Unchecked;
			//chkManualWeekend.Value = False
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord()
		{
			bool result = false;
			object mReturnValue = null;
			int mBankCode = 0;
			int mBranchCode = 0;
			object mTransferBankNo = null;
			string mysql = "";
			string mCheckTimeStamp = "";
			bool mGenerateTA = false;
			bool mGeneratePR = false;
			string mAttendanceStartDate = "";

			try
			{

				if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Select an Employee!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					FirstFocusObject.Focus();
					return result;
				}

				if (SystemProcedure2.IsItEmpty(txtHoursPerDay.Value, SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Hours per day cann't be zero!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtHoursPerDay.Focus();
					return result;
				}

				if (Information.IsNumeric(txtCommonTextBox[conTxtBankCode].Text))
				{
					mysql = "select bank_cd from SM_bank ";
					mysql = mysql + " where bank_no = " + txtCommonTextBox[conTxtBankCode].Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Bank Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						txtCommonTextBox[conTxtBankCode].Focus();
						return result;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mBankCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}


				//Added by burhan date 21-June-2007
				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtTransferToBank].Text, SystemVariables.DataType.StringType))
				{
					mysql = "select pbd.entry_id from pay_bank_details pbd ";
					mysql = mysql + " inner join SM_bank on pbd.bank_cd = SM_bank.bank_cd";
					mysql = mysql + " where sm_bank.bank_no = " + txtCommonTextBox[conTxtTransferToBank].Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Bank Account No for Salary Transfer.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						txtCommonTextBox[conTxtTransferToBank].Focus();
						return result;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTransferBankNo = ReflectionHelper.GetPrimitiveValue(mReturnValue);
					}

				}
				else
				{
					mTransferBankNo = "NULL";
				}


				//End Add


				if (Information.IsNumeric(txtCommonTextBox[conTxtBankBranchCode].Text))
				{
					mysql = "select branch_cd from sm_bank_branch ";
					mysql = mysql + " where branch_no = " + txtCommonTextBox[conTxtBankBranchCode].Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Branch Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						txtCommonTextBox[conTxtBankBranchCode].Focus();
						return result;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mBranchCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				//' on 03-July-2008
				//'Desc: For Daily Wages
				if (cmbCommon[conCmbRateCalcMethod].GetItemData(cmbCommon[conCmbRateCalcMethod].ListIndex) == 130)
				{
					txtDaysPerMonth.Value = 0;
					//txtHoursPerDay.Value = 0
				}
				//'End

				//'' as on 12-June-2008
				//''Desc: For Check if User Change Some Field related to Time  & Attendsnce Then ask him to generated Time&Attendance
				mGenerateTA = false;
				mGeneratePR = false;
				mysql = "select  rate_calc_method_id, payment_type_id, weekend_day1_id, weekend_day2_id, days_per_month, hours_per_day,Date_Of_joining,bank_cd,is_payroll_emp";
				mysql = mysql + " from pay_employee";
				mysql = mysql + " where  emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				if (cmbCommon[conCmbRateCalcMethod].GetItemData(cmbCommon[conCmbRateCalcMethod].ListIndex) != ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0)))
				{
					mGenerateTA = true;
					mGeneratePR = true;
				}
				if (cmbCommon[conCmbPaymentType].GetItemData(cmbCommon[conCmbPaymentType].ListIndex) != ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1)))
				{
					mGenerateTA = true;
					mGeneratePR = true;
				}
				if (cmbCommon[conCmbWeekEndDay1].GetItemData(cmbCommon[conCmbWeekEndDay1].ListIndex) != ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2)))
				{
					mGenerateTA = true;
					mGeneratePR = true;
				}
				if (cmbCommon[conCmbWeekEndDay2].GetItemData(cmbCommon[conCmbWeekEndDay2].ListIndex) != ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3)))
				{
					mGenerateTA = true;
					mGeneratePR = true;
				}
				if (Double.Parse(txtDaysPerMonth.Text) != ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(4)))
				{
					mGenerateTA = true;
					mGeneratePR = true;
				}
				if (Double.Parse(txtHoursPerDay.Text) != ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)))
				{
					mGenerateTA = true;
					mGeneratePR = true;
				}
				if (mBankCode != ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(7)))
				{
					mGeneratePR = true;
				}
				if (cmbCommon[conCmbPayrollEmp].GetItemData(cmbCommon[conCmbPayrollEmp].ListIndex) != ((ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(8))) ? 1 : 0))
				{
					mGeneratePR = true;
				}
				if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue).GetValue(6)) > DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAttendanceStartDate = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(6));
				}
				else
				{
					mAttendanceStartDate = SystemHRProcedure.GetPayrollGenerateStartDate();
				}

				//'' Remaining Part of Generate Time Attendance after save
				//''End
				SystemVariables.gConn.BeginTransaction();


				mysql = " select time_stamp from pay_employee where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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

				mysql = " update pay_employee set ";
				mysql = mysql + " is_payroll_emp=" + cmbCommon[conCmbPayrollEmp].GetItemData(cmbCommon[conCmbPayrollEmp].ListIndex).ToString();
				if (Conversion.Val(txtCommonTextBox[conTxtWeekEnd].Text) == 0)
				{
					mysql = mysql + ", weekend_day1_id= 59 ";
					mysql = mysql + ", weekend_day2_id= 59 ";
				}
				else if (Conversion.Val(txtCommonTextBox[conTxtWeekEnd].Text) == 1)
				{ 
					mysql = mysql + ", weekend_day1_id=" + cmbCommon[conCmbWeekEndDay1].GetItemData(cmbCommon[conCmbWeekEndDay1].ListIndex).ToString();
					mysql = mysql + ", weekend_day2_id= 59 ";
				}
				else if (Conversion.Val(txtCommonTextBox[conTxtWeekEnd].Text) == 2)
				{ 
					mysql = mysql + ", weekend_day1_id=" + cmbCommon[conCmbWeekEndDay1].GetItemData(cmbCommon[conCmbWeekEndDay1].ListIndex).ToString();
					mysql = mysql + ", weekend_day2_id=" + cmbCommon[conCmbWeekEndDay2].GetItemData(cmbCommon[conCmbWeekEndDay2].ListIndex).ToString();
				}

				//added by burhan. Date: 12-07-2008
				mysql = mysql + ", Mobile_Allowance_Entitled =" + ((int) chkMobileAllowance.CheckState).ToString();
				mysql = mysql + ", include_in_payslip_printing =" + ((int) chkIncludeInPayslipPrinting.CheckState).ToString();
				mysql = mysql + ", Mobile_Allowance_Amount =" + ReflectionHelper.GetPrimitiveValue<string>(txtMobileAllowance.Value);
				//end
				mysql = mysql + ", allow_overtime=" + cmbCommon[conCmbOverTime].GetItemData(cmbCommon[conCmbOverTime].ListIndex).ToString();
				mysql = mysql + ", payment_type_id=" + cmbCommon[conCmbPaymentType].GetItemData(cmbCommon[conCmbPaymentType].ListIndex).ToString();
				mysql = mysql + ", rate_per_day =" + ReflectionHelper.GetPrimitiveValue<string>(txtRatePerDay.Value);

				//Update OT Working Days
				mysql = mysql + ", Overtime_Working_Days=" + ReflectionHelper.GetPrimitiveValue<string>(txtNOTWorkingHrs.Value);

				if (Information.IsDate(txtLastSalaryDate.Value))
				{
					mysql = mysql + ", last_salary_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtLastSalaryDate.DisplayText) + "'";
				}
				else
				{
					mysql = mysql + ", last_salary_date = NULL ";
				}

				mysql = mysql + ", Bank_Account_Type_Id=" + cmbCommon[conCmbAccountType].GetItemData(cmbCommon[conCmbAccountType].ListIndex).ToString();

				mysql = mysql + ", rate_calc_method_id =" + cmbCommon[conCmbRateCalcMethod].GetItemData(cmbCommon[conCmbRateCalcMethod].ListIndex).ToString();

				if (Information.IsNumeric(txtDaysPerMonth.Value))
				{
					mysql = mysql + ", days_per_month=" + ReflectionHelper.GetPrimitiveValue<string>(txtDaysPerMonth.Value);
				}
				else
				{
					mysql = mysql + ", days_per_month=NULL";
				}

				if (Information.IsNumeric(txtHoursPerDay.Value))
				{
					mysql = mysql + ", hours_per_day=" + ReflectionHelper.GetPrimitiveValue<string>(txtHoursPerDay.Value);
				}
				else
				{
					mysql = mysql + ", hours_per_day=NULL";
				}

				if (Information.IsNumeric(txtRatePerHours.Value))
				{
					mysql = mysql + ", Rate_Per_Hour=" + ReflectionHelper.GetPrimitiveValue<string>(txtRatePerHours.Value);
				}
				else
				{
					mysql = mysql + ", Rate_Per_Hour=NULL";
				}

				if (Information.IsNumeric(txtCommonTextBox[conTxtWeekEnd].Text))
				{
					mysql = mysql + ", weekend=" + txtCommonTextBox[conTxtWeekEnd].Text;
				}
				else
				{
					mysql = mysql + ", weekend=0";
				}

				if (Information.IsNumeric(txtNormalOT.Value))
				{
					mysql = mysql + ", Normal_OT=" + ReflectionHelper.GetPrimitiveValue<string>(txtNormalOT.Value);
				}
				else
				{
					mysql = mysql + ", Normal_OT=NULL";
				}

				if (Information.IsNumeric(txtFridayOT.Value))
				{
					mysql = mysql + ", friday_OT=" + ReflectionHelper.GetPrimitiveValue<string>(txtFridayOT.Value);
				}
				else
				{
					mysql = mysql + ", friday_OT=NULL";
				}

				if (Information.IsNumeric(txtHolidayOT.Value))
				{
					mysql = mysql + ", holiday_OT=" + ReflectionHelper.GetPrimitiveValue<string>(txtHolidayOT.Value);
				}
				else
				{
					mysql = mysql + ", holiday_OT=NULL";
				}

				if (Information.IsNumeric(txtNGeneralOTAmt.Value))
				{
					mysql = mysql + ", General_OT_Amt=" + ReflectionHelper.GetPrimitiveValue<string>(txtNGeneralOTAmt.Value);
				}
				else
				{
					mysql = mysql + ", General_OT_Amt=0";
				}

				mysql = mysql + ", Bank_Account_No='" + txtCommonTextBox[conTxtAccountNo].Text + "'";
				mysql = mysql + " , Account_No = '" + txtAccountNo.Text + "'";
				if (mBankCode == 0)
				{
					mysql = mysql + ", bank_cd =NULL ";
				}
				else
				{
					mysql = mysql + ", bank_cd = " + mBankCode.ToString();
				}

				if (mBranchCode == 0)
				{
					mysql = mysql + ", bank_branch_cd =NULL ";
				}
				else
				{
					mysql = mysql + ", bank_branch_cd = " + mBranchCode.ToString();
				}
				//mySql = mySql & " , manual_weekend =" & chkManualWeekend.Value
				mysql = mysql + " , calendar_cd =" + txtCalendarCd.Text;
				mysql = mysql + " , transfer_bank_entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mTransferBankNo);
				mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
				mysql = mysql + " where emp_cd=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mysql = " update pay_employee";
				mysql = mysql + " set hold_salary = " + ((int) chkHoldSalary.CheckState).ToString();
				mysql = mysql + " where emp_cd=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				mysql = " update ppm";
				mysql = mysql + " set ppm.is_payroll_emp = pemp.is_payroll_emp";
				mysql = mysql + " , ppm.bank_cd = pemp.bank_cd";
				mysql = mysql + " , ppm.bank_account_no = pemp.bank_account_no";
				mysql = mysql + " , ppm.payment_type_id = pemp.payment_type_id ";
				mysql = mysql + " , ppm.transfer_bank_entry_id = pemp.transfer_bank_entry_id";
				mysql = mysql + " from pay_payroll_master ppm";
				mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = ppm.emp_cd";
				mysql = mysql + " where ppm.pay_date ='" + SystemHRProcedure.GetPayrollGenerateDate() + "' and ppm.emp_cd = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				mysql = " update pp";
				mysql = mysql + " set pp.bank_cd = pemp.bank_cd";
				mysql = mysql + " , pp.bank_account_no = pemp.bank_account_no";
				mysql = mysql + " , pp.payment_type_id = pemp.payment_type_id ";
				mysql = mysql + " from pay_payroll pp";
				mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = pp.emp_cd";
				mysql = mysql + " where pp.pay_date ='" + SystemHRProcedure.GetPayrollGenerateDate() + "' and pp.emp_cd = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();

				//' Added By Burhan Ghee Wala
				//' Date: 28-Nov-2007
				//' Desc: In Leave Transaction, Employee Severance Transaction, Employee Promotion Transaction
				//' contains bank_account_no and payment_type_id which gets stored when transaction gets saved.
				//' If meanwhile we update either bank_account_no or payment_type_id from the master table tht is pay_employee
				//' the change should be reflected in the corresponding tables.

				string mPayrollDate = "";
				mPayrollDate = SystemHRProcedure.GetPayrollGenerateDate();
				mysql = " update pay_leave_transaction set ";
				mysql = mysql + " bank_account_no ='" + txtCommonTextBox[conTxtAccountNo].Text + "'";
				mysql = mysql + " ,payment_type_id = " + cmbCommon[conCmbPaymentType].GetItemData(cmbCommon[conCmbPaymentType].ListIndex).ToString();
				mysql = mysql + " from pay_leave_transaction where ";
				mysql = mysql + " payroll_date <='" + mPayrollDate + "'";
				mysql = mysql + " and status = 1 and emp_cd =" + Conversion.Str(mSearchValue);
				mysql = mysql + " or payroll_date ='" + mPayrollDate + "'";
				mysql = mysql + " and status = 2 and emp_cd =" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_5 = null;
				TempCommand_5 = SystemVariables.gConn.CreateCommand();
				TempCommand_5.CommandText = mysql;
				TempCommand_5.ExecuteNonQuery();

				mysql = " update pay_employee_termination set ";
				mysql = mysql + " bank_account_no ='" + txtCommonTextBox[conTxtAccountNo].Text + "'";
				mysql = mysql + " ,payment_type_id = " + cmbCommon[conCmbPaymentType].GetItemData(cmbCommon[conCmbPaymentType].ListIndex).ToString();
				mysql = mysql + " from pay_employee_termination where ";
				mysql = mysql + " payroll_date <='" + mPayrollDate + "'";
				mysql = mysql + " and status = 1 and emp_cd =" + Conversion.Str(mSearchValue);
				mysql = mysql + " or payroll_date ='" + mPayrollDate + "'";
				mysql = mysql + " and status = 2 and emp_cd =" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_6 = null;
				TempCommand_6 = SystemVariables.gConn.CreateCommand();
				TempCommand_6.CommandText = mysql;
				TempCommand_6.ExecuteNonQuery();

				//' End Add
				//' For Time Attendace 12-June-2008
				//'For Time & Attendance New Entry Generated
				//'And GeneratePayroll
				if (mGenerateTA)
				{
					//''Update payroll master payment type id
					mysql = " update pay_payroll_master";
					mysql = mysql + " set payment_type_id =" + cmbCommon[conCmbPaymentType].GetItemData(cmbCommon[conCmbPaymentType].ListIndex).ToString();
					mysql = mysql + " where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + " and pay_date ='" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
					SqlCommand TempCommand_7 = null;
					TempCommand_7 = SystemVariables.gConn.CreateCommand();
					TempCommand_7.CommandText = mysql;
					TempCommand_7.ExecuteNonQuery();
					//'''check msg below ..by hakim on 18-jul-2010
					if (MessageBox.Show("Do you want to Generate Time & Attendance Again !", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						if (!SystemHRProcedure.ClearTimeAttendanceCurrentMonthTransaction(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), ReflectionHelper.GetPrimitiveValue<int>(SearchValue)))
						{
							MessageBox.Show("Time Attendance Not Generate Please Try again!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return result;
						}
						if (!SystemHRProcedure.GenerateTimeAttendanceMonthlyTransaction(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), ReflectionHelper.GetPrimitiveValue<int>(SearchValue)))
						{
							MessageBox.Show("Time Attendance Not Generate Please Try again!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return result;
						}
						if (!SystemHRProcedure.UpdateVacationInTimeAttendance(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), ReflectionHelper.GetPrimitiveValue<int>(SearchValue)))
						{
							MessageBox.Show("Time Attendance Not Generate Please Try again!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return result;
						}
						if (!SystemHRProcedure.UpdateTimeAttendanceDayOff(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), ReflectionHelper.GetPrimitiveValue<int>(SearchValue)))
						{
							MessageBox.Show("Time Attendance Not Generate Please Try again!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return result;
						}

						//            If CDate(mAttendanceStartDate) <> CDate(GetPayrollGenerateStartDate) Then
						//                mWorkHrsEntryId = GetTAEntryID(mSearchValue, WorkHours, Year(CDate(GetPayrollGenerateDate)), Month(CDate(GetPayrollGenerateDate)))
						//                Call UpdateAttendanceFieldsHours(GetPayrollGenerateStartDate, mAttendanceStartDate, CLng(mWorkHrsEntryId), 0, True)
						//            End If
						MessageBox.Show("Time & Attendance Generated Successfully !", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

					}
				}
				if (mGeneratePR)
				{
					//For Generate Payroll Entry Based On New Time and Attendance
					//Clear Payroll
					SystemHRProcedure.ClearPayroll(SystemHRProcedure.GetPayrollGenerateDate(), txtDisplayLabel[conDlblEmpCode].Text, txtDisplayLabel[conDlblEmpCode].Text);
					SystemHRProcedure.GeneratePayrollEntry(SystemHRProcedure.GetPayrollGenerateDate(), txtDisplayLabel[conDlblEmpCode].Text, txtDisplayLabel[conDlblEmpCode].Text);
					SystemHRProcedure.GenerateLeaveEntry(SystemHRProcedure.GetPayrollGenerateDate(), txtDisplayLabel[conDlblEmpCode].Text, txtDisplayLabel[conDlblEmpCode].Text);
					SystemHRProcedure.GenerateLoanEntry(SystemHRProcedure.GetPayrollGenerateDate(), txtDisplayLabel[conDlblEmpCode].Text, txtDisplayLabel[conDlblEmpCode].Text);
					//End
				}
				//''End

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

		public object deleteRecord()
		{

			return null;
		}

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			//On Error GoTo eFoundError
			object mReturnValue = null;

			string mysql = " select * from pay_employee where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

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

				mysql = " select bank.bank_no , bank.l_bank_name , bank.a_bank_name ";
				mysql = mysql + " , bank_branch.branch_no , bank_branch.l_branch_name";
				mysql = mysql + " , bank_branch.a_branch_name ";
				mysql = mysql + " , emp_status.l_status_name, emp_status.a_status_name ";
				mysql = mysql + " , pay_emp.rate_calc_method_id ";
				//new line
				mysql = mysql + " , pbd.account_no, bank1.l_bank_name, bank1.a_bank_name,bank1.bank_no ";
				//end line
				mysql = mysql + " ,l_calendar_name , a_calendar_name";
				mysql = mysql + " from  pay_employee pay_emp ";
				mysql = mysql + " left outer join SM_bank_branch bank_branch on pay_emp.bank_branch_cd = bank_branch.branch_cd ";
				mysql = mysql + " left outer join SM_bank bank on pay_emp.bank_cd = bank.bank_cd ";
				//'' Added New
				mysql = mysql + " left outer join pay_bank_details pbd on pay_emp.transfer_bank_entry_id = pbd.entry_id ";
				mysql = mysql + " left outer join SM_bank bank1 on pbd.bank_cd = bank1.bank_cd";
				mysql = mysql + " left outer join pay_calendar pc on pc.calendar_cd = pay_emp.calendar_cd";
				//''' Fin
				mysql = mysql + " inner join pay_employee_status emp_status on pay_emp.status_cd = emp_status.status_cd ";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " where pay_emp.emp_cd= " + Convert.ToString(localRec.Tables[0].Rows[0]["emp_cd"]);


				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//''Bank
					txtCommonTextBox[conTxtBankCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)) + "";
					txtDisplayLabel[conDlblBankName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(1) : ((Array) mReturnValue).GetValue(2)) + "";

					//''Branch
					txtCommonTextBox[conTxtBankBranchCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3)) + "";
					txtDisplayLabel[conDlblBankBranchName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(4) : ((Array) mReturnValue).GetValue(5)) + "";

					//''Status
					txtDisplayLabel[conDlblStatus].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(6) : ((Array) mReturnValue).GetValue(7)) + "";

					//'Transfer to Bank
					txtCommonTextBox[conTxtTransferToBank].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(12)) + "";
					txtDisplayLabel[conDlblTransferToBank].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(10) : ((Array) mReturnValue).GetValue(11)) + "";

					//'Calendar Code
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCalendarCd.Text = Convert.ToString(localRec.Tables[0].Rows[0]["Calendar_cd"]);
					txtDlblCalendarName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(13) : ((Array) mReturnValue).GetValue(14)) + "";
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblEmpCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["emp_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblEmpName].Text = Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? localRec.Tables[0].Rows[0]["l_full_name"] : localRec.Tables[0].Rows[0]["a_full_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblBasicSalary].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["basic_salary"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblTotalSalary].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["total_salary"], "###,###,##0.000");

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!localRec.Tables[0].Rows[0].IsNull("last_salary_date"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtLastSalaryDate.Value = localRec.Tables[0].Rows[0]["last_salary_date"];
					txtRatePerDay.Enabled = false;
					txtRatePerHours.Enabled = false;
					txtCommonTextBox[conTxtBankCode].Enabled = false;
					cmbCommon[conCmbPaymentType].Enabled = false;
					txtCommonTextBox[conTxtAccountNo].Locked = true;
					txtCommonTextBox[conTxtTransferToBank].Enabled = false;
					txtAccountNo.Enabled = false;
				}
				else
				{
					txtLastSalaryDate.Text = "";
					txtRatePerDay.Enabled = true;
					txtRatePerHours.Enabled = true;
					txtCommonTextBox[conTxtBankCode].Enabled = true;
					cmbCommon[conCmbPaymentType].Enabled = true;
					txtCommonTextBox[conTxtAccountNo].Locked = false;
					txtCommonTextBox[conTxtTransferToBank].Enabled = true;
					txtAccountNo.Enabled = true;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtWeekEnd].Text = Convert.ToString(localRec.Tables[0].Rows[0]["weekend"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemCombo.SearchCombo(cmbCommon[conCmbPayrollEmp], (Convert.ToBoolean(localRec.Tables[0].Rows[0]["is_payroll_emp"])) ? 1 : 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemCombo.SearchCombo(cmbCommon[conCmbWeekEndDay1], Convert.ToInt32(localRec.Tables[0].Rows[0]["weekend_day1_id"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemCombo.SearchCombo(cmbCommon[conCmbWeekEndDay2], Convert.ToInt32(localRec.Tables[0].Rows[0]["weekend_day2_id"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemCombo.SearchCombo(cmbCommon[conCmbOverTime], (Convert.ToBoolean(localRec.Tables[0].Rows[0]["allow_overtime"])) ? 1 : 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemCombo.SearchCombo(cmbCommon[conCmbPaymentType], Convert.ToInt32(localRec.Tables[0].Rows[0]["payment_type_id"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemCombo.SearchCombo(cmbCommon[conCmbAccountType], Convert.ToInt32(localRec.Tables[0].Rows[0]["Bank_Account_Type_Id"]));

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemCombo.SearchCombo(cmbCommon[conCmbRateCalcMethod], Convert.ToInt32(localRec.Tables[0].Rows[0]["rate_calc_method_id"]));

				//added by burhan. Date:12-07-2008
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtMobileAllowance.Value = localRec.Tables[0].Rows[0]["mobile_allowance_amount"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkMobileAllowance.CheckState = (CheckState) ((Convert.ToBoolean(localRec.Tables[0].Rows[0]["mobile_allowance_entitled"])) ? 1 : 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkIncludeInPayslipPrinting.CheckState = (CheckState) ((Convert.ToBoolean(localRec.Tables[0].Rows[0]["include_in_payslip_printing"])) ? 1 : 0);
				//end
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkHoldSalary.CheckState = (CheckState) ((Convert.ToBoolean(localRec.Tables[0].Rows[0]["Hold_Salary"])) ? 1 : 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtNOTWorkingHrs.Value = localRec.Tables[0].Rows[0]["Overtime_Working_Days"];

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!localRec.Tables[0].Rows[0].IsNull("days_per_month"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtDaysPerMonth.Value = localRec.Tables[0].Rows[0]["days_per_month"];
				}
				else
				{
					txtDaysPerMonth.Value = 0;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!localRec.Tables[0].Rows[0].IsNull("hours_per_day"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtHoursPerDay.Value = localRec.Tables[0].Rows[0]["hours_per_day"];
				}
				else
				{
					txtHoursPerDay.Value = 0;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!localRec.Tables[0].Rows[0].IsNull("rate_per_hour"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtRatePerHours.Value = localRec.Tables[0].Rows[0]["rate_per_hour"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtRatePerDay.Value = localRec.Tables[0].Rows[0]["rate_per_day"];
				}
				else
				{
					txtRatePerHours.Value = 0;
					txtRatePerDay.Value = 0;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!localRec.Tables[0].Rows[0].IsNull("Normal_OT"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtNormalOT.Value = localRec.Tables[0].Rows[0]["Normal_OT"];
				}
				else
				{
					txtNormalOT.Value = 0;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!localRec.Tables[0].Rows[0].IsNull("friday_OT"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtFridayOT.Value = localRec.Tables[0].Rows[0]["friday_OT"];
				}
				else
				{
					txtFridayOT.Value = 0;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!localRec.Tables[0].Rows[0].IsNull("holiday_OT"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtHolidayOT.Value = localRec.Tables[0].Rows[0]["holiday_OT"];
				}
				else
				{
					txtHolidayOT.Value = 0;
				}
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtNGeneralOTAmt.Value = localRec.Tables[0].Rows[0]["General_OT_Amt"];
				//chkManualWeekend.Value = IIf(.Fields("manual_weekend") <> 0, 1, 0)
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtAccountNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Bank_Account_No"]) + "";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtAccountNo.Text = Convert.ToString(localRec.Tables[0].Rows[0]["Account_No"]) + "";
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
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000));
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

			bool result = false;
			if (txtCommonTextBox[conTxtWeekEnd].Text == "1")
			{
				if (cmbCommon[conCmbWeekEndDay1].Text == "")
				{
					MessageBox.Show("Enter a valid weekend day. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					cmbCommon[conCmbWeekEndDay1].Focus();
					return result;
				}
			}
			else if (txtCommonTextBox[conTxtWeekEnd].Text == "2")
			{ 
				if (cmbCommon[conCmbWeekEndDay1].Text == "")
				{
					MessageBox.Show("Enter a valid weekend day. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					cmbCommon[conCmbWeekEndDay1].Focus();
					return result;
				}

				if (cmbCommon[conCmbWeekEndDay2].Text == "")
				{
					MessageBox.Show("Enter a valid weekend day. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					cmbCommon[conCmbWeekEndDay2].Focus();
					return result;
				}
			}
			else
			{

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
				frmPayEmployeePayroll.DefInstance = null;
				oThisFormToolBar = null;
				//rsSystemObjects.Close
				//Set rsSystemObjects = Nothing
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}


		private void txtCalendarCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtCalendarCd");
		}

		private void txtCalendarCd_Leave(Object eventSender, EventArgs eventArgs)
		{

			if (SystemProcedure2.IsItEmpty(txtCalendarCd.Text, SystemVariables.DataType.NumberType))
			{
				return;
			}

			string mysql = "Select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_calendar_name" : "a_calendar_name") + " as calendarName";
			mysql = mysql + " from pay_Calendar";
			mysql = mysql + " where calendar_cd = " + txtCalendarCd.Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDlblCalendarName.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
			}
			else
			{
				txtCalendarCd.Text = "";
				txtDlblCalendarName.Text = "";
			}

		}

		private void txtCommonTextBox_Change(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			if (Index == conTxtWeekEnd)
			{
				if (txtCommonTextBox[Index].Text == "1")
				{
					cmbCommon[conCmbWeekEndDay1].Enabled = true;
					cmbCommon[conCmbWeekEndDay1].Visible = true;
					lblCommonLabel[conLblWeekendDay1].Visible = true;
					SystemCombo.SearchCombo(cmbCommon[conCmbWeekEndDay1], 17); //Friday

					cmbCommon[conCmbWeekEndDay2].Enabled = false; //None
					cmbCommon[conCmbWeekEndDay2].Visible = false;
					lblCommonLabel[conLblWeekendDay2].Visible = false;
					SystemCombo.SearchCombo(cmbCommon[conCmbWeekEndDay2], 59);
				}
				else if (txtCommonTextBox[Index].Text == "2")
				{ 
					cmbCommon[conCmbWeekEndDay1].Enabled = true;
					cmbCommon[conCmbWeekEndDay1].Visible = true;
					lblCommonLabel[conLblWeekendDay1].Visible = true;
					SystemCombo.SearchCombo(cmbCommon[conCmbWeekEndDay1], 23); //Thursday

					cmbCommon[conCmbWeekEndDay2].Enabled = true;
					cmbCommon[conCmbWeekEndDay2].Visible = true;
					lblCommonLabel[conLblWeekendDay2].Visible = true;
					SystemCombo.SearchCombo(cmbCommon[conCmbWeekEndDay2], 17); //Friday
				}
				else
				{
					cmbCommon[conCmbWeekEndDay1].Enabled = false;
					cmbCommon[conCmbWeekEndDay1].Visible = false;
					lblCommonLabel[conLblWeekendDay1].Visible = false;
					SystemCombo.SearchCombo(cmbCommon[conCmbWeekEndDay1], 59); //None

					cmbCommon[conCmbWeekEndDay2].Enabled = false;
					cmbCommon[conCmbWeekEndDay2].Visible = false;
					lblCommonLabel[conLblWeekendDay2].Visible = false;
					SystemCombo.SearchCombo(cmbCommon[conCmbWeekEndDay2], 59); //None
				}
			}
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
		}

		private void txtCommonTextBox_KeyPress(Object Sender, System.Windows.Forms.TextBox.KeyPressEventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			int KeyAscii = e.KeyAscii;
			try
			{
				if (Index == conTxtWeekEnd)
				{
					//Allow only 1 and 2 key
					if (KeyAscii == 48 || KeyAscii == 49 || KeyAscii == 50 || KeyAscii == 8)
					{
					}
					else
					{
						KeyAscii = 0;
					}
				}
			}
			finally
			{
				e.KeyAscii = KeyAscii;
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

				if (Index == conTxtBankCode)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtBankCode].Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select bank_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_bank_name" : "a_bank_name");
						mysql = mysql + " from SM_bank ";
						mysql = mysql + " where ";
						mysql = mysql + " bank_no = " + txtCommonTextBox[conTxtBankCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblBankName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblBankName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						}
					}
					else
					{
						txtDisplayLabel[conDlblBankName].Text = "";
					}
				}
				else if (Index == conTxtBankBranchCode)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtBankBranchCode].Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select branch_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_branch_name" : "a_branch_name");
						mysql = mysql + " from SM_bank_branch ";
						mysql = mysql + " where ";
						mysql = mysql + " branch_no = " + txtCommonTextBox[conTxtBankBranchCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblBankBranchName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblBankBranchName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						}
					}
					else
					{
						txtDisplayLabel[conDlblBankBranchName].Text = "";
					}
					//'' Added By Burhan
					// Date : 21-Jun-2007
					//Desc: Added new find window for "Transfer To Bank"

				}
				else if (Index == conTxtTransferToBank)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtTransferToBank].Text, SystemVariables.DataType.StringType))
					{
						mysql = " select pbd.account_no ";
						mysql = mysql + "," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_bank_name" : "a_bank_name");
						mysql = mysql + " from pay_bank_details pbd ";
						mysql = mysql + " inner join SM_bank bank on pbd.bank_cd = bank.bank_cd ";
						mysql = mysql + " where bank.bank_no =" + txtCommonTextBox[conTxtTransferToBank].Text;
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblTransferToBank].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblTransferToBank].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						}
					}
					else
					{
						txtDisplayLabel[conDlblTransferToBank].Text = "";
					}

					/////end Alter
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

			if (pObjectName == "txtCalendarCd")
			{
				txtCalendarCd.Text = "";
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220590, "2726"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCalendarCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtCalendarCd_Leave(txtCalendarCd, new EventArgs());
				}
				return;
			}

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

			switch(mIndex)
			{
				case conTxtBankCode : 
					txtCommonTextBox[conTxtBankCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7030000, "820")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtBankCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtBankBranchCode : 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtBankCode].Text, SystemVariables.DataType.StringType))
					{
						mysql = " bank.bank_no=" + txtCommonTextBox[conTxtBankCode].Text;
					}
					else
					{
						mysql = "";
					} 
					txtCommonTextBox[conTxtBankBranchCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7040000, "825", mysql)); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtBankBranchCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					 
					break;
				case conTxtTransferToBank : 
					txtCommonTextBox[conTxtTransferToBank].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7031000, "1586")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtTransferToBank].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				default:
					return;
			}

		}

		private void txtRatePerDay_Change(Object Sender, EventArgs e)
		{
			double mRatePerHour = 0;
			if (cmbCommon[conCmbRateCalcMethod].GetItemData(cmbCommon[conCmbRateCalcMethod].ListIndex) != 130)
			{
				if (!SystemProcedure2.IsItEmpty(txtHoursPerDay.Value, SystemVariables.DataType.NumberType))
				{
					mRatePerHour = ReflectionHelper.GetPrimitiveValue<double>(txtRatePerDay.Value) / ((double) ReflectionHelper.GetPrimitiveValue<double>(txtHoursPerDay.Value));
					txtRatePerHours.Value = mRatePerHour;
				}
				else
				{
					MessageBox.Show("Please update Days per Hours!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{
				mRatePerHour = ReflectionHelper.GetPrimitiveValue<double>(txtRatePerDay.Value) / ((double) ((ReflectionHelper.GetPrimitiveValue<double>(txtHoursPerDay.Value) == 0) ? 8 : ReflectionHelper.GetPrimitiveValue<double>(txtHoursPerDay.Value)));
				txtRatePerHours.Value = mRatePerHour;
			}
		}
	}
}