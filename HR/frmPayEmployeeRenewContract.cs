
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayEmployeeRenewContract
		: System.Windows.Forms.Form
	{

		public frmPayEmployeeRenewContract()
{
InitializeComponent();
} 
 public  void frmPayEmployeeRenewContract_old()
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


		private void frmPayEmployeeRenewContract_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		private clsToolbar oThisFormToolBar = null;
		private int mThisFormID = 0;
		private string mSearchValue = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private string mTimeStamp = "";

		private const int conDlblDeptCode = 0;
		private const int conDlblDeptName = 1;
		private const int conDlblDesgCode = 2;
		private const int conDlblDesgName = 3;
		private const int conDlblEmpName = 4;
		private const int conTxtEmpCode = 1;
		private int mPosted = 0;

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
		public string SearchValue
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




		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}
				if (this.ActiveControl.Name != "txtCommonTextBox")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommonTextBox#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
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
			FirstFocusObject = txtCommonTextBox[conTxtEmpCode];

			try
			{

				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;
				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm
				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowExitButton = true;
				this.WindowState = FormWindowState.Maximized;
				SystemProcedure.SetLabelCaption(this);
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
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
						mysql = " pay_emp.status_cd IN (1) and pay_emp.emp_type_id = 148"; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", mysql)); 
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

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			try
			{
				object mTempValue = null;
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
						mysql = mysql + " , pemp.rate_calc_method_id, weekend, weekend_day1_id , weekend_day2_id  ";
						mysql = mysql + " , pemp.total_salary, pemp.contract_start_date,pemp.contract_end_date,pemp.contract_period ";
						mysql = mysql + " from pay_employee pemp , pay_department pdept, pay_designation pdesg ";
						mysql = mysql + " where ";
						mysql = mysql + " pemp.dept_cd = pdept.dept_cd and pemp.desg_cd = pdesg.desg_cd ";
						mysql = mysql + " and pemp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
						mysql = mysql + " and pemp.emp_type_id = 148";

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
							txtContractStartDate.Value = DateTime.Today;
							txtContractEndDate.Value = DateTime.Today;
							txtNewContractPeriod.Value = 0;
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
							if (Information.IsDate(((Array) mTempValue).GetValue(11)))
							{
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtContractStartDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(11));
							}
							else
							{
								txtContractStartDate.Text = "";
							}
							if (Information.IsDate(((Array) mTempValue).GetValue(12)))
							{
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtContractEndDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(12));
							}
							else
							{
								txtContractEndDate.Text = "";
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(((Array) mTempValue).GetValue(13)))
							{
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtNewContractPeriod.Value = ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(13));
							}
							else
							{
								txtNewContractPeriod.Value = 0;
							}
						}
					}
					else
					{
						txtDisplayLabel[conDlblEmpName].Text = "";
						txtDisplayLabel[conDlblDeptCode].Text = "";
						txtDisplayLabel[conDlblDeptName].Text = "";
						txtDisplayLabel[conDlblDesgCode].Text = "";
						txtDisplayLabel[conDlblDesgName].Text = "";
						txtContractStartDate.Value = DateTime.Today;
						txtContractEndDate.Value = DateTime.Today;
						txtNewContractPeriod.Value = 0;
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
					if (txtCommonTextBox[Index].Enabled)
					{
						txtCommonTextBox[Index].Focus();
					}
				}
				else
				{
					//
				}
			}
		}

		//Public Sub findRecord()
		//Dim mReturnValue As Variant
		//mReturnValue = FindItem(7220310)
		//If Not IsNull(mReturnValue) Then
		//    mSearchValue = mReturnValue(0)
		//    Call GetRecord(mSearchValue)
		//End If
		//End Sub

		//Public Sub GetRecord(pEntryId As Variant)
		//Dim mysql As String
		//Dim mReturnValue As Variant
		//Dim rs As ADODB.Recordset
		//
		//mysql = " select pehd.time_stamp, pehd.startdate, pehd.Posted, pehd.resumedate, pemp.emp_no, pemp.l_full_Name "
		//mysql = mysql & " ,dept.dept_no, dept.l_dept_name, desg.desg_no, desg.l_desg_name"
		//mysql = mysql & " from pay_employee_hold_details pehd"
		//mysql = mysql & " inner join pay_employee pemp on pemp.emp_cd = pehd.emp_cd"
		//mysql = mysql & " inner join pay_department dept on dept.dept_cd  = pehd.dept_cd"
		//mysql = mysql & " inner join pay_designation desg on desg.desg_cd = pehd.desg_cd"
		//mysql = mysql & " where entry_id=" & pEntryId
		//
		//Set rs = New ADODB.Recordset
		//rs.Open mysql, gConn, adOpenForwardOnly, adLockReadOnly
		//With rs
		//    If Not .EOF Then
		//        mTimeStamp = .Fields("time_stamp")
		//        txtCommonTextBox(conTxtEmpCode).Text = .Fields("emp_no")
		//        txtContractStartDate.Value = .Fields("startdate")
		//        txtContractEndDate.Value = .Fields("resumedate")
		//        txtDisplayLabel(conDlblEmpName).Text = .Fields("l_full_name")
		//        txtDisplayLabel(conDlblDeptCode).Text = .Fields("dept_no")
		//        txtDisplayLabel(conDlblDeptName).Text = .Fields("l_dept_name")
		//        txtDisplayLabel(conDlblDesgCode).Text = .Fields("desg_no")
		//        txtDisplayLabel(conDlblDesgName).Text = .Fields("l_desg_name")
		//        If .Fields("posted") = True Then
		//            txtContractStartDate.Enabled = False
		//            txtCommonTextBox(conTxtEmpCode).Enabled = False
		//            mPosted = 1
		//        Else
		//            txtContractStartDate.Enabled = True
		//            txtCommonTextBox(conTxtEmpCode).Enabled = True
		//            mPosted = 0
		//        End If
		//    End If
		//End With
		//  mCurrentFormMode = frmEditMode
		//End Sub

		//Public Function saveRecord() As Boolean
		//On Error GoTo ErrHandler
		//Dim mReturnValue As Variant
		//Dim mysql As String
		//Dim mEmpCd As Long, mDeptCd As Long, mDesgCd As Long
		//
		//mysql = " select emp_cd from pay_employee where emp_no=" & txtCommonTextBox(conTxtEmpCode).Text
		//mReturnValue = GetMasterCode(mysql)
		//If Not IsNull(mReturnValue) Then
		//    mEmpCd = mReturnValue
		//Else
		//    MsgBox "Employee No is not available try again!!"
		//    Exit Function
		//End If
		//mysql = " select dept_cd from pay_department where dept_no=" & txtDisplayLabel(conDlblDeptCode).Text
		//mReturnValue = GetMasterCode(mysql)
		//If Not IsNull(mReturnValue) Then
		//    mDeptCd = mReturnValue
		//Else
		//    MsgBox "Employee No is not available try again!!"
		//    Exit Function
		//End If
		//mysql = " select desg_cd from pay_designation where desg_no=" & txtDisplayLabel(conDlblDesgCode).Text
		//mReturnValue = GetMasterCode(mysql)
		//If Not IsNull(mReturnValue) Then
		//    mDesgCd = mReturnValue
		//Else
		//    MsgBox "Employee No is not available try again!!"
		//    Exit Function
		//End If
		//
		//If mCurrentFormMode = frmAddMode Then
		//    mysql = " select emp_cd from pay_employee_hold_details where emp_cd=" & mEmpCd & " and resumed_processed=0"
		//    mReturnValue = GetMasterCode(mysql)
		//    If IsNull(mReturnValue) Then
		//        mysql = " insert into pay_employee_hold_details"
		//        mysql = mysql & "(emp_cd,dept_cd,desg_cd,startdate,resumedate,user_cd)"
		//        mysql = mysql & "values(" & mEmpCd & "," & mDeptCd & "," & mDesgCd
		//        mysql = mysql & " ,'" & txtContractStartDate.Value & "'"
		//        mysql = mysql & " ,'" & txtContractEndDate.Value & "'"
		//        mysql = mysql & "," & Str(gLoggedInUserCode) & ")"
		//        gConn.Execute (mysql)
		//        mysql = " select SCOPE_IDENTITY() "
		//        mSearchValue = GetMasterCode(mysql)
		//    Else
		//        MsgBox "Record All ready Exist!!", vbInformation
		//        Exit Function
		//    End If
		//Else
		//
		//    mysql = "select posted from pay_employee_hold_details where entry_id=" & mSearchValue
		//    mReturnValue = GetMasterCode(mysql)
		//    If mReturnValue = True Then
		//        MsgBox "Record Posted Cannot Editable!!", vbInformation
		//        saveRecord = False
		//        Exit Function
		//    End If
		//    mysql = "update pay_employee_hold_details"
		//    mysql = mysql & " set emp_cd = " & mEmpCd
		//    mysql = mysql & " ,dept_cd =" & mDeptCd
		//    mysql = mysql & " ,desg_cd =" & mDesgCd
		//    mysql = mysql & " ,startdate='" & txtContractStartDate.Value & "'"
		//    mysql = mysql & " ,resumedate='" & txtContractEndDate.Value & "'"
		//    mysql = mysql & " ,user_cd =" & Str(gLoggedInUserCode)
		//    mysql = mysql & " where entry_id=" & mSearchValue
		//    gConn.Execute (mysql)
		//End If
		//saveRecord = True
		//Exit Function
		//ErrHandler:
		//    MsgBox "Record Not Saved Check Again!!", vbInformation
		//    saveRecord = False
		//End Function

		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);

			//mCurrentFormMode = frmAddMode                           'Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			txtContractStartDate.Enabled = true;
			txtCommonTextBox[conTxtEmpCode].Enabled = true;
			mPosted = 0;
		}

		public bool Post()
		{
			bool result = false;
			try
			{
				string mysql = "";
				DialogResult ans = (DialogResult) 0;
				int mEmpCd = 0;
				object mReturnValue = null;
				string mContractEndDate = "";

				SystemVariables.gConn.BeginTransaction();
				ans = MessageBox.Show("Do you want renew the employee contract?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo);
				if (ans == System.Windows.Forms.DialogResult.Yes)
				{
					mEmpCd = SystemHRProcedure.GetEmpCd(txtCommonTextBox[conTxtEmpCode].Text);
					if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtContractStartDate.Value) < DateTime.Parse(SystemHRProcedure.GetMonthEndDate()))
					{
						//UPGRADE_WARNING: (1068) txtContractEndDate.Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mContractEndDate = ReflectionHelper.GetPrimitiveValue<string>(txtContractEndDate.Value);
						//Insert previous contract Details
						mysql = "insert into pay_employee_contract_accrual_details(emp_cd,leave_cd,leave_balance_days";
						mysql = mysql + " ,leave_salary,leave_days_per_month,indemnity_balance_days,indemnity_salary,indemnity_days_per_month";
						mysql = mysql + " ,contract_start_date,contract_end_date,calculate_on_calendar_days)";
						mysql = mysql + " select pemp.emp_cd, peld.leave_cd, dbo.payLeaveBalanceDays(pemp.emp_cd,peld.leave_cd,'" + mContractEndDate + "',1)";
						mysql = mysql + " ,dbo.PayGetLeaveSalary(pemp.emp_cd,peld.leave_cd)";
						mysql = mysql + " ,peld.working_days_per_month_after_sop";
						mysql = mysql + " ,dbo.payIndemnityBalanceDays(pemp.emp_cd,'" + mContractEndDate + "',1)";
						mysql = mysql + " ,pemp.indemnity_salary, pemp.indemnity_working_days_per_month_after_sop";
						mysql = mysql + " ,pemp.contract_start_date,'" + mContractEndDate + "'";
						mysql = mysql + " ,pl.calculate_on_calendar_days";
						mysql = mysql + " from pay_employee pemp";
						mysql = mysql + " inner join pay_employee_leave_details peld on peld.emp_cd = pemp.emp_cd";
						mysql = mysql + " inner join pay_leave pl on pl.leave_cd =peld.leave_cd";
						mysql = mysql + " where pemp.emp_cd = " + mEmpCd.ToString() + " and pl.leave_type_cd = 6";
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql;
						TempCommand.ExecuteNonQuery();

						//Update Employee contract date in master
						mysql = " update pay_employee ";
						mysql = mysql + " set contract_start_date = '" + DateTimeHelper.ToString(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtContractEndDate.Value).AddDays(1)) + "'";
						mysql = mysql + " , contract_end_date ='" + DateTimeHelper.ToString(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtContractEndDate.Value).AddYears(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtNewContractPeriod.Value))))) + "'";
						mysql = mysql + " , contract_period =" + Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtNewContractPeriod.Value)).ToString();
						mysql = mysql + " where emp_cd=" + mEmpCd.ToString();
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();

					}
					else
					{
						MessageBox.Show("Accrual date must be greater than Start date and less than Resume date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();
					return true;
				}
				else
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
			}
			return result;
		}



		public bool CheckDataValidity()
		{
			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Invalid Employee Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			if (SystemProcedure2.IsItEmpty(txtContractStartDate.Value, SystemVariables.DataType.DateType))
			{
				MessageBox.Show("Invalid start date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			return true;
		}
		public void CloseForm()
		{
			this.Close();
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}