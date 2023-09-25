
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayClearPayroll
		: System.Windows.Forms.Form
	{

		public frmPayClearPayroll()
{
InitializeComponent();
} 
 public  void frmPayClearPayroll_old()
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


		private void frmPayClearPayroll_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		int mThisFormID = 0;
		private int mFormCallType = 0;
		private XArrayHelper mArr = null;
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


		private const int gccAccountNo = 0;
		private const int gccAccountName = 1;
		private const int gccDebit = 2;
		private const int gccCredit = 3;
		private const int gccCCNo = 4;
		private const int gccCCName = 5;
		private const int gccComments = 6;
		private const int gccLdgrCd = 7;
		private const int gccCCCd = 8;

		private const int mMaxCols = 8;

		private const string conPayrollComments = "Payroll";
		private const string conLeaveProvisionComments = "Leave Provision";
		private const string conIndemnityProvisionComments = "Indemnity Provision";


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



		public int FormCallType
		{
			get
			{
				return mFormCallType;
			}
			set
			{
				mFormCallType = value;
			}
		}


		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			string mysql = "";
			int ans = 0;
			object mReturnValue = null;
			frmPayGLVoucherView mForm = null;
			System.DateTime mProjectRateDate = DateTime.FromOADate(0);
			SqlDataReader rsTempRecordset = null;

			SystemHRProcedure.gPayrollGenerateEndDate = "";
			string mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();
			string mMonthEndDate = SystemHRProcedure.GetMonthEndDate();
			string mStartDate = SystemHRProcedure.GetPayrollGenerateStartDate();

			if (mGenerateDate == "")
			{
				return;
			}

			//On Error GoTo eFoundError

			if (mFormCallType == 1)
			{
				ans = (int) MessageBox.Show("Are you sure you want to clear the payroll ? ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);

				if (ans == ((int) System.Windows.Forms.DialogResult.Yes))
				{
					SystemVariables.gConn.BeginTransaction();
					//        mySql = " delete from pay_payroll "
					//        mySql = mySql & " where pay_date='" & mGenerateDate & "'"
					//        mySql = mySql & " and trans_type is not null "
					//        gConn.Execute mySql

					//**--commented by : abbas
					//**--comment date : 15-nov-2005
					//**--hakim pls check this line
					SystemHRProcedure.ClearPayroll(mGenerateDate);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();

					MessageBox.Show("Payroll cleared , successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					this.Close();
				}
			}
			else if (mFormCallType == 2)
			{ 
				ans = (int) MessageBox.Show("Are you sure you want to close the payroll ? ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (ans == ((int) System.Windows.Forms.DialogResult.No))
				{
					return;
				}

				//''''''    If CDate(mMonthEndDate) < CDate(mStartDate) Then
				//''''''        MsgBox "Please close last month and then close payroll for this month!", vbInformation, "Closing"
				//''''''        Exit Sub
				//''''''    End If

				if (!ProceedWithUnPostedTransaction(mGenerateDate))
				{
					return;
				}

				if (UnGeneratedTransactionExists(mGenerateDate))
				{
					return;
				}

				SystemVariables.gConn.BeginTransaction();
				pbClosePayroll.Value = 0;
				pbClosePayroll.Visible = true;
				// temp
				//''''''Call GenerateAbsentHrsAdjustment
				GenearateAbsentHrsAdjustment(mGenerateDate);
				pbClosePayroll.Value += 5;
				PostPayrollTransaction();
				pbClosePayroll.Value += 5;
				UpdateLoanDetails(mGenerateDate);
				pbClosePayroll.Value += 5;

				UpdateEmployeeLastSalaryDate(mGenerateDate);
				pbClosePayroll.Value += 5;
				AppendTimeAttendanceHistory();
				pbClosePayroll.Value += 5;
				SystemHRProcedure.UpdateEmpDeductionhours();
				pbClosePayroll.Value += 5;

				//'' As On 19-April-2009
				//''Fro Project Allocation By Payroll Details
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
				{
					InsertProjectAllocationMaster();
					pbClosePayroll.Value += 5;
					if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("Import_TimeAttendance_Format")) != 4)
					{
						AllocateProject(mGenerateDate);
					}
					else
					{
						AllocateProjectOnProjectAttendance(mGenerateDate);
					}
					pbClosePayroll.Value += 5;
				}
				else
				{
					pbClosePayroll.Value += 10;
				}
				//'' End ''''''''''''''''''''''''''''''''''''


				// From Now always month end along with payroll for all
				// If GetSystemPreferenceSetting("close_month_along_with_payroll") = True Then
				ResetLeave(mGenerateDate);
				UpdatePayrollLeaveSummary(mGenerateDate);
				pbClosePayroll.Value += 10;
				UpdatePayrollIndemnitySummary(mGenerateDate);
				pbClosePayroll.Value += 10;
				//'''''' as On 1-11-2008
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_ticket")))
				{
					UpdatePayrollTicketSummary(mGenerateDate);
				}
				//''End

				//Check if any salary variation transaction posted that is effect in next month
				//For that first check Effect Date is enable or not
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("use_effective_date_for_salary_variation")))
				{
					mysql = "update psvd";
					mysql = mysql + " Set psvd.Status = 2";
					mysql = mysql + " from pay_salary_variation psv";
					mysql = mysql + " inner join pay_salary_variation_details psvd on psvd.entry_id = psv.entry_id";
					mysql = mysql + " Where psv.[Status] = 2 and psv.effective_date > '" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				pbClosePayroll.Value += 5;
				//End

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
				{
					//''' Bill_NO = 9 For Leave
					//''' Bill_NO = 11 For Indmnity
					//''' Bill_NO = 13 For Ticket
					//'''' For Indemnity
					mysql = " update ppp";
					mysql = mysql + " set ppp.rate = isnull(pias.pias_curr_accru_lc_amount,0) / ppp.pay_hours";
					mysql = mysql + " from pay_project_payroll ppp";
					mysql = mysql + " inner join pay_indemnity_accrual_summary pias on pias.pias_emp_cd = ppp.emp_cd";
					mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = ppp.bill_cd ";
					mysql = mysql + " where pias.pias_year =" + DateTime.Parse(mGenerateDate).Year.ToString() + " and pias.pias_month =" + DateTime.Parse(mGenerateDate).Month.ToString();
					mysql = mysql + " and ppp.pay_date ='" + mGenerateDate + "'";
					mysql = mysql + " and pias.pias_curr_accru_lc_amount > 0 ";
					mysql = mysql + " and pbt.bill_no = 11 ";
					mysql = mysql + " and ppp.pay_hours > 0 ";
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

					//'''For Leave
					mysql = " update ppp";
					mysql = mysql + " set ppp.rate = isnull(plas.plas_curr_accru_lc_amount,0) / ppp.pay_hours";
					mysql = mysql + " from pay_project_payroll ppp";
					mysql = mysql + " inner join pay_leave_accrual_summary plas on plas.plas_emp_cd = ppp.emp_cd";
					mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = ppp.bill_cd ";
					mysql = mysql + " where plas.plas_year =" + DateTime.Parse(mGenerateDate).Year.ToString() + " and plas.plas_month =" + DateTime.Parse(mGenerateDate).Month.ToString();
					mysql = mysql + " and ppp.pay_date ='" + mGenerateDate + "'";
					mysql = mysql + " and plas.plas_curr_accru_lc_amount > 0 ";
					mysql = mysql + " and pbt.bill_no = 9 ";
					mysql = mysql + " and ppp.pay_hours > 0 ";
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_ticket")))
					{
						//'''For Ticket
						mysql = " update ppp";
						mysql = mysql + " set ppp.rate = isnull(ptas.ptas_curr_accru_lc_amount,0) / ppp.pay_hours ";
						mysql = mysql + " from pay_project_payroll ppp";
						mysql = mysql + " inner join pay_ticket_accrual_summary ptas on ptas.ptas_emp_cd = ppp.emp_cd";
						mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = ppp.bill_cd ";
						mysql = mysql + " where ptas.ptas_year =" + DateTime.Parse(mGenerateDate).Year.ToString() + " and ptas.ptas_month =" + DateTime.Parse(mGenerateDate).Month.ToString();
						mysql = mysql + " and ppp.pay_date ='" + mGenerateDate + "'";
						mysql = mysql + " and ptas.ptas_curr_accru_lc_amount > 0 ";
						mysql = mysql + " and pbt.bill_no = 13 ";
						mysql = mysql + " and ppp.pay_hours > 0 ";
						SqlCommand TempCommand_4 = null;
						TempCommand_4 = SystemVariables.gConn.CreateCommand();
						TempCommand_4.CommandText = mysql;
						TempCommand_4.ExecuteNonQuery();
					}
				}
				//'''''''''''''''''''''''''END'''''''''''''''''''''''''''''''''''''''''''''''
				pbClosePayroll.Value += 5;
				//'''commented by hakim
				//'''the gl entry generate was moved to new form on 29-jun-2009
				//        If GetSystemPreferenceSetting("enable_payroll_gl_link") = True Then
				//            If GetPayrollEntryInfoIntoArray(mMonthEndDate) = True Then
				//            Call ClubVoucherEntry
				//                 Set mForm = New frmPayGLVoucherView
				//                mForm.AssignArray = mArr
				//                mForm.Show 1
				//                If mForm.mPostTransaction = False Then
				//                    Unload mForm
				//                    Set mForm = Nothing
				//                    gConn.RollBackTrans
				//                    gPayrollGenerateEndDate = ""
				//                    mGenerateDate = GetPayrollGenerateDate
				//                    Exit Sub
				//                Else
				//                    Unload mForm
				//                    Set mForm = Nothing
				//
				//                    Call GeneratePayrollGLEntry(Format(mGenerateDate, gSystemDateFormat), mArr)
				//
				//                End If
				//            Else
				//                gConn.RollBackTrans
				//                Exit Sub
				//            End If
				//        End If

				// End If

				UpdatePayrollGenerateHistory(DateTime.Parse(mGenerateDate));
				if (!SystemHRProcedure.GenerateTimeAttendanceEntry())
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return;
				}
				pbClosePayroll.Value += 10;

				SystemHRProcedure.GeneratePayrollEntry(SystemHRProcedure.gPayrollGenerateEndDate, "", "");
				pbClosePayroll.Value += 10;
				SystemHRProcedure.GenerateLeaveEntry(SystemHRProcedure.gPayrollGenerateEndDate, "", "");
				pbClosePayroll.Value += 5;
				SystemHRProcedure.GenerateLoanEntry(SystemHRProcedure.gPayrollGenerateEndDate, "", "");
				pbClosePayroll.Value += 5;


				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				MessageBox.Show("Payroll Closed, successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				this.Close();
			}
			else if (mFormCallType == 3)
			{ 
				ans = (int) MessageBox.Show("Are you sure you want to close the month ? ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				mStartDate = "01-" + DateTime.Parse(mMonthEndDate).Month.ToString() + "-" + DateTime.Parse(mMonthEndDate).Year.ToString();
				if (ans == ((int) System.Windows.Forms.DialogResult.No))
				{
					return;
				}
				if (DateTime.Parse(mMonthEndDate) > DateTime.Parse(mGenerateDate))
				{
					MessageBox.Show("Please close payroll before close month!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				//    gConn.BeginTrans
				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("close_month_along_with_payroll")))
				{
					//Check All Employee are Allocated or Not Modified on 25-Feb-2009
					//''moved from top by hakim on 24-may-2009
					SystemVariables.gConn.BeginTransaction();

					//        ''''commented by hakim on 26-may-2009
					//        ''''Important for  to check
					//       '''''Checked  this for checking all employee allocation is done or not.
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
					{
						mysql = "select emp_cd from pay_employee where status_cd not in(" + SystemHRProcedure.gStatusTerminated.ToString() + "," + SystemHRProcedure.gStatusOnHold.ToString() + ")";
						SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
						rsTempRecordset = sqlCommand.ExecuteReader();
						rsTempRecordset.Read();
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						do 
						{
							if (!SystemHRProcedure.CheckForProjectAllocatedHrs(Convert.ToInt32(rsTempRecordset["emp_cd"]), mMonthEndDate))
							{
								ans = (int) MessageBox.Show("Allocation is not complete for the current month. Do you want to continue... " + SystemHRProcedure.GetPayrollGenerateDate(), "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
								if (ans == ((int) MsgBoxStyle.YesNo))
								{
									//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
									SystemVariables.gConn.RollbackTrans();
									SystemReports.GetSystemReport(110120000, 2, "set @AsOnDate='" + mMonthEndDate + "'");
									this.Close();
									return;
								}
								else
								{
									goto NEXTSTEP;
								}
							}
						}
						while(rsTempRecordset.Read());
						//''' To Post this month Project Allocation Record
						//'''As On 25-Aug-2009
						mysql = "update pay_project_payroll";
						mysql = mysql + " set is_pay_closed = 1";
						mysql = mysql + " where pay_date = '" + mMonthEndDate + "'";
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();
						//'''END
						NEXTSTEP:;
					}
					//''End

					//Call ResetLeave(mGenerateDate)
					//Call UpdatePayrollLeaveSummary(mMonthEndDate)
					//Call UpdatePayrollIndemnitySummary(mMonthEndDate)
					//'''''' as On 1-11-2008
					//If GetSystemPreferenceSetting("enable_ticket") = True Then
					//    Call UpdatePayrollTicketSummary(mMonthEndDate)
					//End If
					//''' End
					//If GetSystemPreferenceSetting("enable_payroll_project") = True Then
					//            mProjectRateDate = CDate(GetMonthEndDate)
					//            mysql = "Update pay_payroll"
					//            mysql = mysql & " set yearly_monthly_rate = isnull(round(case (dbo.payGetProjectTotalSalary(pemp.emp_no,'" & Format(CStr(mProjectRateDate), "dd/MMM/yyyy") & "')) "
					//            mysql = mysql & " when 0 then 0"
					//            mysql = mysql & " else Case dbo.payGetEmployeeWorkingHours(pemp.emp_no,'" & mStartDate & "',1)"
					//            mysql = mysql & " when 0 then 0"
					//            mysql = mysql & " else (dbo.payGetProjectTotalSalary(pemp.emp_no,'" & Format(CStr(mProjectRateDate), "dd/MMM/yyyy") & "')/dbo.payGetEmployeeWorkingHours(pemp.emp_no,'" & mStartDate & "',1))"
					//            mysql = mysql & " End"
					//            mysql = mysql & " end,3),0)"
					//            mysql = mysql & " from pay_payroll pp"
					//            mysql = mysql & " inner join pay_employee pemp on pemp.emp_cd = pp.emp_cd"
					//            mysql = mysql & " where  year(pp.pay_date) = year('" & Format(CStr(mProjectRateDate), "dd/MMM/yyyy") & "') and month(pp.pay_date) = month('" & Format(CStr(mProjectRateDate), "dd/MMM/yyyy") & "')"
					//            gConn.Execute mysql
					//End If

					//'''  as on 25-Feb-2009 For Cutoff Deduction Hours Update in Master Employee
					//Call UpdateTotalDeductionhoursInMaster
					//''' END
					//''Update Rate For Project Allocation In Pay_Project_Payroll for indemnity, leave and ticket

					UpdateMonthEndDate(mMonthEndDate);

					//''commented by hakim on 29-jun-2009
					//''moved to new form
					//        If GetSystemPreferenceSetting("enable_payroll_gl_link") = True Then
					//            If GetPayrollEntryInfoIntoArray(mMonthEndDate) = True Then
					//            Call ClubVoucherEntry
					//                Set mForm = New frmPayGLVoucherView
					//                mForm.AssignArray = mArr
					//                mForm.Show 1
					//                If mForm.mPostTransaction = False Then
					//                    Unload mForm
					//                    Set mForm = Nothing
					//                    gConn.RollBackTrans
					//                    gPayrollGenerateEndDate = ""
					//                    mGenerateDate = GetPayrollGenerateDate
					//                    Exit Sub
					//                Else
					//                    Unload mForm
					//                    Set mForm = Nothing
					//
					//                    Call GeneratePayrollGLEntry(Format(mGenerateDate, gSystemDateFormat), mArr)
					//
					//                End If
					//            Else
					//                gConn.RollBackTrans
					//                Exit Sub
					//            End If
					//        End If
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();
					MessageBox.Show("Month End Closed Successfully!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
				else
				{
					MessageBox.Show("Close month along with payroll setting is true, Cannot close month ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
			}

			return;

			MessageBox.Show(Information.Err().Description, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
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

				if (KeyCode == 27)
				{ //If enter key pressed send a tab key
					this.Close();
					return;
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
			System.DateTime mPayrollDate = DateTime.FromOADate(0);

			this.Top = 0;
			this.Left = 0;

			SystemProcedure.SetLabelCaption(this);

			this.WindowState = FormWindowState.Maximized;

			string mysql = " select generate_date ";
			mysql = mysql + " from Pay_Payroll_Generate_History ";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				mReturnValue = InputBoxHelper.InputBox("Enter the Payroll Generate Date. (dd-mmm-yyyy)", "Enter the Date");
				if (!Information.IsDate(mReturnValue))
				{
					MessageBox.Show("Invalid Date.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					MessageBox.Show("Current payroll generate date is not defined ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mPayrollDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(mReturnValue);

					mysql = " insert into pay_payroll_generate_history ";
					mysql = mysql + " (generate_date, user_cd)";
					mysql = mysql + " values (";
					mysql = mysql + "'" + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + "'";
					mysql = mysql + "," + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " ) ";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
			}
			else
			{
				mPayrollDate = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate());
			}

			if (Information.IsDate(mReturnValue))
			{
				if (mFormCallType == 1)
				{
					lblMessage.Text = " Clear Payroll for " + mPayrollDate.ToString("MMM") + "-" + mPayrollDate.ToString("yyyy");
				}
				else if (mFormCallType == 2)
				{ 
					lblMessage.Text = " Close Payroll for " + mPayrollDate.ToString("MMM") + "-" + mPayrollDate.ToString("yyyy");
				}
				else if (mFormCallType == 3)
				{ 
					lblMessage.Text = " Close Month for " + DateTime.Parse(SystemHRProcedure.GetMonthEndDate()).ToString("MMM") + "-" + DateTime.Parse(SystemHRProcedure.GetMonthEndDate()).ToString("yyyy");
				}
			}

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));


				frmPayClearPayroll.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//Private Function GeneratePayrollGLEntry(ByVal pVoucherDate As String, ByVal pArr As XArrayDB)
		//Dim mysql As String
		//
		//Dim mLdgrCd As String
		//Dim mCostCd As String
		//Dim mLineAmt As Currency
		//
		//Dim mDrCr As String
		//Dim mDrLineNo As Integer
		//Dim mCrLineNo As Integer
		//Dim mComments As String
		//
		//Dim mDefaultGlVoucherType As Integer
		//Dim mVoucherNo As Long
		//Dim mAccntTransEntryId As Long
		//Dim cnt As Integer
		//
		//
		//mDefaultGlVoucherType = GetSystemPreferenceSetting("pay_default_gl_voucher_type")
		//
		//'If GetSystemPreferenceSetting("pay_gl_entry_method") = 1 Then
		//'    ''''Department Level entry
		//
		//    mDrLineNo = 1
		//    mCrLineNo = 1
		//
		//    mysql = " voucher_type = " & Str(mDefaultGlVoucherType)
		//    mVoucherNo = GetNewNumber("gl_accnt_trans", "voucher_no", , mysql, " tablock(xlock) ")
		//
		//    mAccntTransEntryId = FAInsertGLHeaderEntry(mDefaultGlVoucherType, pVoucherDate _
		//'        , mVoucherNo, "", "Auto Generated Payroll Entry for the month of " & Format(CDate(pVoucherDate), "MMM"), 4, gLoggedInUserCode)
		//
		//
		//    For cnt = 0 To pArr.Count(1) - 1
		//        mLdgrCd = pArr(cnt, gccLdgrCd)
		//        mCostCd = pArr(cnt, gccCCCd)
		//        mComments = pArr(cnt, gccComments)
		//
		//        If Val(Format(pArr(cnt, gccDebit), "#############0.000")) > 0 Then
		//            mDrCr = "D"
		//            mLineAmt = Val(Format(pArr(cnt, gccDebit), "#############0.000"))
		//        Else
		//            mDrCr = "C"
		//            mLineAmt = Val(Format(pArr(cnt, gccCredit), "#############0.000"))
		//        End If
		//
		//        If mDrCr = "D" Then
		//            Call FAInsertGLDetailsEntry(mAccntTransEntryId, mLdgrCd _
		//'            , mCostCd, 1, mLineAmt, (1 * mLineAmt), mDrCr, pVoucherDate _
		//'            , mDrLineNo, 1, mComments)
		//
		//            mDrLineNo = mDrLineNo + 1
		//        Else
		//            Call FAInsertGLDetailsEntry(mAccntTransEntryId, mLdgrCd _
		//'            , mCostCd, 1, (mLineAmt * -1), (1 * (mLineAmt * -1)), mDrCr, pVoucherDate _
		//'            , mCrLineNo, 1, mComments)
		//
		//            mCrLineNo = mCrLineNo + 1
		//        End If
		//    Next cnt
		//'End If
		//
		//Exit Function
		//
		//End Function

		//Private Function GetPayrollEntryInfoIntoArray(ByVal pVoucherDate As String) As Boolean
		//Dim mysql As String
		//Dim mReturnValue As Variant
		//Dim rsTempRec As ADODB.Recordset
		//Dim rsTempRec1 As ADODB.Recordset
		//Dim mPrevPayrollDate As String ' this variable is declared bcoz the month is closed and pay_payroll_generate_history has been updated for next month
		//Dim mSecondLastPayrollDate As String
		//Dim mLdgrCd As String
		//Dim mLdgrNo As String
		//Dim mLdgrName As String
		//Dim mApplyCostCenter As Boolean
		//
		//Dim mCostCd As String
		//Dim mCostNo As String
		//Dim mCostName As String
		//
		//Dim mBalanceAmt As Currency
		//Dim mDrCr As String
		//
		//Dim mLeaveProvisionDays  As Double
		//Dim mLeaveProvisionAmt As Currency
		//
		//Dim mLeaveBalanceDays As Double
		//Dim mPreviousLeaveBalanceDaysProvision As Double
		//
		//Dim mIndemnityBalanceDays As Double
		//Dim mPreviousIndemnityBalanceDaysProvision As Double
		//Dim mIndemnityProvisionDays As Double
		//Dim mIndemnityProvisionAmount As Currency
		//
		//Dim cnt As Integer
		//
		//Set mArr = New XArrayDB
		//
		//mPrevPayrollDate = DateAdd("m", -1, Format(GetPayrollGenerateDate, "mm-yyyy"))
		//mSecondLastPayrollDate = DateAdd("m", -1, Format(mPrevPayrollDate, "mm-yyyy"))
		//
		//If GetSystemPreferenceSetting("pay_gl_entry_method") = 1 Then
		//    ''''Department Level entry
		//
		//    '''Staff Salary a/c   dr
		//    '''     To Salary Control A/C
		//    mysql = " select pbt.bill_cd , pbt.bill_type_id "
		//    mysql = mysql & " , pdept.dept_cd as emp_dept_cd , gltab.ldgr_cd "
		//    mysql = mysql & " , gl_ledger.ldgr_no , cc.cost_no "
		//    If gPreferedLanguage = English Then
		//        mysql = mysql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//    Else
		//        mysql = mysql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//    End If
		//    mysql = mysql & " , gltab.cost_cd , round(sum(pp.lc_amount),3) lc_amount "
		//    mysql = mysql & " from pay_payroll pp "
		//    mysql = mysql & " inner join pay_billing_type pbt on pp.bill_cd = pbt.bill_cd "
		//    mysql = mysql & " inner join pay_department pdept on pp.dept_cd = pdept.dept_cd "
		//    mysql = mysql & " left join pay_department_gl_details gltab on pdept.dept_cd = gltab.dept_cd "
		//    mysql = mysql & " and pp.bill_cd = gltab.bill_cd "
		//    mysql = mysql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//    mysql = mysql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//    mysql = mysql & " where pp.pay_date ='" & pVoucherDate & "'"
		//    mysql = mysql & " and pp.lc_amount > 0 "
		//    mysql = mysql & " group by pbt.bill_cd , pbt.bill_type_id "
		//    mysql = mysql & " , pdept.dept_cd , gltab.ldgr_cd , gltab.cost_cd "
		//    mysql = mysql & " , gl_ledger.ldgr_no, gl_ledger.l_ldgr_name, gl_ledger.a_ldgr_name "
		//    mysql = mysql & " , cc.cost_no, cc.l_cost_name, cc.a_cost_name "
		//Else
		//    mysql = " select pbt.bill_cd , pbt.bill_type_id "
		//    mysql = mysql & " , pemp.emp_cd as emp_dept_cd "
		//    mysql = mysql & " , glinfo.ldgr_cd "
		//    mysql = mysql & " , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name ldgr_name "
		//    mysql = mysql & " , l_cost_name cost_name , glinfo.cost_cd "
		//    mysql = mysql & " , round(pp.lc_amount,3) lc_amount "
		//    mysql = mysql & " from pay_payroll pp "
		//    mysql = mysql & " inner join pay_billing_type pbt on pp.bill_cd = pbt.bill_cd "
		//    mysql = mysql & " inner join pay_employee pemp on pp.emp_cd = pemp.emp_cd "
		//    mysql = mysql & " left join pay_employee_gl_details glinfo "
		//    mysql = mysql & " on pemp.emp_cd = glinfo.emp_cd  and pp.bill_cd = glinfo.bill_cd "
		//    mysql = mysql & " left join gl_ledger on glinfo.ldgr_cd = gl_ledger.ldgr_cd "
		//    mysql = mysql & " left join gl_cost_centers cc on glinfo.cost_cd = cc.cost_cd "
		//    mysql = mysql & " where pp.pay_date ='" & pVoucherDate & "'"
		//    mysql = mysql & " and pp.lc_amount > 0 "
		//End If
		//
		//Set rsTempRec = New ADODB.Recordset
		//With rsTempRec
		//    .Open mysql, gConn, adOpenForwardOnly, adLockReadOnly
		//
		//    If Not .EOF Then
		//        Do While Not .EOF
		//            If IsNull(.Fields("ldgr_cd")) Then
		//                Call DisplayError(.Fields("emp_dept_cd"))
		//                GoTo mError
		//            Else
		//                mLdgrCd = .Fields("ldgr_cd")
		//                mLdgrNo = .Fields("ldgr_no")
		//                mLdgrName = .Fields("ldgr_name")
		//
		//                If GetSystemPreferenceSetting("cost_center") = True Then
		//                    If IsNull(.Fields("cost_cd")) Then
		//                        Call DisplayError(.Fields("emp_dept_cd"))
		//                        GoTo mError
		//                    Else
		//                        mCostCd = .Fields("cost_cd")
		//                        mCostNo = .Fields("cost_no")
		//                        mCostName = .Fields("cost_name")
		//                    End If
		//                Else
		//                    mCostCd = ""
		//                    mCostNo = ""
		//                    mCostName = ""
		//                End If
		//            End If
		//
		//            If .Fields("bill_type_id") = 51 Then
		//                mDrCr = "D"
		//            Else
		//                mDrCr = "C"
		//            End If
		//
		//            If mDrCr = "D" Then
		//                Call InsertIntoArray(cnt, mLdgrNo, mLdgrName, .Fields("lc_amount"), 0 _
		//'                    , mCostNo, mCostName, mLdgrCd, mCostCd, conPayrollComments)
		//
		//                mBalanceAmt = mBalanceAmt + .Fields("lc_amount")
		//            Else
		//                Call InsertIntoArray(cnt, mLdgrNo, mLdgrName, 0, .Fields("lc_amount") _
		//'                    , mCostNo, mCostName, mLdgrCd, mCostCd, conPayrollComments)
		//
		//                mBalanceAmt = mBalanceAmt - .Fields("lc_amount")
		//            End If
		//
		//            cnt = cnt + 1
		//
		//
		//            '''''Salary Control
		//            If GetSystemPreferenceSetting("pay_gl_entry_method") = 1 Then
		//                mysql = " select pbt.bill_cd , pbt.bill_type_id "
		//                mysql = mysql & " , pdept.dept_cd as emp_dept_cd , gltab.ldgr_cd "
		//                mysql = mysql & " , gltab.cost_cd "
		//                mysql = mysql & " , gl_ledger.ldgr_no , cc.cost_no "
		//
		//                If gPreferedLanguage = English Then
		//                    mysql = mysql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//                Else
		//                    mysql = mysql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//                End If
		//
		//                mysql = mysql & " from pay_billing_type pbt"
		//                mysql = mysql & " left join pay_department_gl_details gltab on pbt.bill_cd = gltab.bill_cd "
		//                mysql = mysql & " left join pay_department pdept on pdept.dept_cd = gltab.dept_cd "
		//                mysql = mysql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//                mysql = mysql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd   "
		//                mysql = mysql & " where pbt.bill_cd = 10 "
		//                mysql = mysql & " and pdept.dept_cd =" & rsTempRec.Fields("emp_dept_cd")
		//                mysql = mysql & " group by pbt.bill_cd , pbt.bill_type_id "
		//                mysql = mysql & " , pdept.dept_cd , gltab.ldgr_cd , gltab.cost_cd "
		//                mysql = mysql & " , gl_ledger.ldgr_no, gl_ledger.l_ldgr_name, gl_ledger.a_ldgr_name "
		//                mysql = mysql & " , cc.cost_no, cc.l_cost_name, cc.a_cost_name "
		//            Else
		//                mysql = " select pbt.bill_cd , pbt.bill_type_id "
		//                mysql = mysql & " , pemp.emp_cd as emp_dept_cd "
		//                mysql = mysql & " , gltab.ldgr_cd , gltab.cost_cd "
		//                mysql = mysql & " , gl_ledger.ldgr_no , cc.cost_no "
		//
		//                If gPreferedLanguage = English Then
		//                    mysql = mysql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//                Else
		//                    mysql = mysql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//                End If
		//
		//                mysql = mysql & " from pay_billing_type pbt"
		//                mysql = mysql & " left join pay_employee_gl_details gltab on pbt.bill_cd = gltab.bill_cd "
		//                mysql = mysql & " left join pay_employee pemp on pemp.emp_cd = gltab.emp_cd "
		//                mysql = mysql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//                mysql = mysql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd   "
		//                mysql = mysql & " where pbt.bill_cd = 10 "
		//                mysql = mysql & " and pemp.emp_cd =" & rsTempRec.Fields("emp_dept_cd")
		//            End If
		//
		//            Set rsTempRec1 = New ADODB.Recordset
		//            With rsTempRec1
		//                .Open mysql, gConn, adOpenForwardOnly, adLockReadOnly
		//
		//                If Not .EOF Then
		//                    If IsNull(.Fields("ldgr_cd")) Then
		//                        Call DisplayError(.Fields("emp_dept_cd"))
		//                        GoTo mError
		//                    Else
		//                        mLdgrCd = .Fields("ldgr_cd")
		//                        mLdgrNo = .Fields("ldgr_no")
		//                        mLdgrName = .Fields("ldgr_name")
		//
		//                        If GetSystemPreferenceSetting("cost_center") = True Then
		//                            If IsNull(.Fields("cost_cd")) Then
		//                                Call DisplayError(.Fields("emp_dept_cd"))
		//                            Else
		//                                mCostCd = .Fields("cost_cd")
		//                                mCostNo = .Fields("cost_no")
		//                                mCostName = .Fields("cost_name")
		//                            End If
		//                        Else
		//                            mCostCd = ""
		//                            mCostNo = ""
		//                            mCostName = ""
		//                        End If
		//                    End If
		//
		//                    If mBalanceAmt > 0 Then
		//                        mDrCr = "C"
		//                    Else
		//                        mDrCr = "D"
		//                    End If
		//
		//                    If mDrCr = "D" Then
		//                        Call InsertIntoArray(cnt, mLdgrNo, mLdgrName, Abs(mBalanceAmt), 0 _
		//'                            , mCostNo, mCostName, mLdgrCd, mCostCd, conPayrollComments)
		//                    Else
		//                        Call InsertIntoArray(cnt, mLdgrNo, mLdgrName, 0, Abs(mBalanceAmt) _
		//'                            , mCostNo, mCostName, mLdgrCd, mCostCd, conPayrollComments)
		//                    End If
		//
		//                    cnt = cnt + 1
		//                Else
		//                    Call DisplayError(rsTempRec.Fields("emp_dept_cd"))
		//                    GoTo mError
		//                End If
		//                .Close
		//            End With
		//
		//            mBalanceAmt = 0
		//            .MoveNext
		//        Loop
		//
		//        .Close
		//    End If
		//End With
		//
		//
		//
		//'''Staff Leave expenses a/c   dr
		//'''     To Leave provision  a/c
		//'mysql = " select pemp.emp_cd , pdept.dept_cd "
		//'mysql = mysql & " from pay_employee pemp "
		//'mysql = mysql & " inner join pay_department pdept on pemp.dept_cd = pdept.dept_cd "
		//'mysql = mysql & " where status_cd = 1 "
		//'
		//'Set rsTempRec = New ADODB.Recordset
		//'With rsTempRec
		//'    .Open mysql, gConn, adOpenForwardOnly, adLockReadOnly
		//'    Do While Not .EOF
		//'
		//'        mysql = " select  dbo.payLeaveBalanceDays( "
		//'        mysql = mysql & .Fields("emp_cd")
		//'        mysql = mysql & " , 1 "
		//'        mysql = mysql & " , '" & pVoucherDate & "'"
		//'        mysql = mysql & " , 0 ) "
		//'        mReturnValue = GetMasterCode(mysql)
		//'        If Not IsNull(mReturnValue) Then
		//'            mLeaveBalanceDays = mReturnValue
		//'        Else
		//'            mLeaveBalanceDays = 0
		//'        End If
		//'
		//'
		//'        ''''Get the previous leave provision days
		//'        mysql = " select isnull(sum(provision_days),0) "
		//'        mysql = mysql & " from pay_gl_provision "
		//'        mysql = mysql & " where generate_date <'" & pVoucherDate & "'"
		//'        mysql = mysql & " and emp_cd=" & .Fields("emp_cd")
		//'        mysql = mysql & " and provision_type = 2 "  '''leave
		//'        mReturnValue = GetMasterCode(mysql)
		//'        If Not IsNull(mReturnValue) Then
		//'            mPreviousLeaveBalanceDaysProvision = mReturnValue
		//'        Else
		//'            mPreviousLeaveBalanceDaysProvision = 0
		//'        End If
		//'
		//'        mLeaveProvisionDays = mLeaveBalanceDays - mPreviousLeaveBalanceDaysProvision
		//'
		//'
		//'        mysql = " select round( dbo.payLeaveAmount( "
		//'        mysql = mysql & .Fields("emp_cd")
		//'        mysql = mysql & " , 1 "
		//'        mysql = mysql & " , " & mLeaveProvisionDays
		//'        mysql = mysql & " , '" & pVoucherDate & "'), 3,1 )"
		//'        mReturnValue = GetMasterCode(mysql)
		//'        If Not IsNull(mReturnValue) Then
		//'            mLeaveProvisionAmt = mReturnValue
		//'        Else
		//'            mLeaveProvisionAmt = 0
		//'        End If
		//'
		//'        Call InsertIntoPayGLProvision(pVoucherDate, 2, 1, .Fields("emp_cd") _
		//''            , .Fields("dept_cd"), mLeaveProvisionDays, mLeaveProvisionAmt)
		//'
		//'    .MoveNext
		//'    Loop
		//'End With
		//
		//
		//If GetSystemPreferenceSetting("pay_gl_entry_method") = 1 Then
		//    'Commented by burhan. Date:22-may-2008
		//    'desc: to get cumulative balance of current month minus previous month
		//    'mysql = " select sum(plas_curr_accru_lc_amount) lc_amount "
		//    mysql = " select sum(case when plas.plas_year = " & Year(CDate(mPrevPayrollDate)) & " and plas.plas_month = " & Month(CDate(mPrevPayrollDate)) & " then plas_cumm_accrued_amt when plas.plas_year = " & Year(CDate(mSecondLastPayrollDate)) & " and plas.plas_month = " & Month(CDate(mSecondLastPayrollDate)) & "  then plas_cumm_accrued_amt *-1 end )  lc_amount "
		//    ''
		//    mysql = mysql & " , gltab.ldgr_cd, gltab.cost_cd, gltab.dept_cd as emp_dept_cd "
		//    mysql = mysql & " , gl_ledger.ldgr_no , cc.cost_no "
		//    If gPreferedLanguage = English Then
		//        mysql = mysql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//    Else
		//        mysql = mysql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//    End If
		//    mysql = mysql & ", 1 as sorder "
		//    'mysql = mysql & " from pay_gl_provision pprov " ' commented by burhan for testing
		//    mysql = mysql & " from PAY_LEAVE_ACCRUAL_SUMMARY plas " ' added by burhan for testing
		//
		//    mysql = mysql & " inner join pay_employee pemp on plas.plas_emp_cd = pemp.emp_cd " ' added for testing
		//
		//    mysql = mysql & " inner join pay_department_gl_details gltab on pemp.dept_cd = gltab.dept_cd"
		//    mysql = mysql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//    mysql = mysql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//    mysql = mysql & " Where "
		//    mysql = mysql & "  (gltab.bill_cd = 2) "         'Leave expenses biling cd
		//    mysql = mysql & " and ((plas.plas_year = " & Year(mPrevPayrollDate) ' added for testin
		//    mysql = mysql & " and plas.plas_month =  " & Month(mPrevPayrollDate) & ")"  ' added for testin
		//
		//    '''
		//    'Commented by burhan. Date:22-may-2008
		//    'desc: to get cumulative balance
		//    mysql = mysql & " or (plas.plas_year = " & Year(CDate(mSecondLastPayrollDate)) ' added for testin
		//    mysql = mysql & " and plas.plas_month =  " & Month(CDate(mSecondLastPayrollDate)) & "))"  ' added for testin
		//    '''
		//    mysql = mysql & " and plas.plas_curr_accru_lc_amount > 0 " ' added for testin
		//    'mysql = mysql & "  and pprov.provision_type = 2 "   ''Leave provision
		//    'mysql = mysql & "  and pprov.generate_date ='" & pVoucherDate & "'"
		//    'mysql = mysql & "  and pprov.provision_amount > 0 "
		//    mysql = mysql & "  group by gltab.ldgr_cd, gltab.cost_cd, gltab.dept_cd "
		//    mysql = mysql & " , gl_ledger.ldgr_no, gl_ledger.l_ldgr_name, gl_ledger.a_ldgr_name "
		//    mysql = mysql & " , cc.cost_no, cc.l_cost_name, cc.a_cost_name "
		//
		//    mysql = mysql & " union all "
		//
		//    'Commented by burhan. Date:22-may-2008
		//    'desc: to get cumulative balance
		//    'mysql = mysql & " select sum(plas_curr_accru_lc_amount) * -1 lc_amount "
		//    mysql = mysql & " select sum(case when plas.plas_year = " & Year(CDate(mPrevPayrollDate)) & " and plas.plas_month = " & Month(CDate(mPrevPayrollDate)) & " then plas_cumm_accrued_amt when plas.plas_year = " & Year(CDate(mSecondLastPayrollDate)) & " and plas.plas_month = " & Month(CDate(mSecondLastPayrollDate)) & "  then plas_cumm_accrued_amt *-1 end)  * -1 lc_amount "
		//
		//    mysql = mysql & " , gltab.ldgr_cd, gltab.cost_cd, gltab.dept_cd as emp_dept_cd "
		//    mysql = mysql & " , gl_ledger.ldgr_no , cc.cost_no "
		//    If gPreferedLanguage = English Then
		//        mysql = mysql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//    Else
		//        mysql = mysql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//    End If
		//    mysql = mysql & ", 2 as sorder "
		//    'mysql = mysql & " from pay_gl_provision pprov " commented for testing
		//
		//    mysql = mysql & " from PAY_LEAVE_ACCRUAL_SUMMARY plas " ' added by burhan for testing
		//    mysql = mysql & " inner join pay_employee pemp on plas.plas_emp_cd = pemp.emp_cd " 'added for testing
		//
		//    mysql = mysql & " inner join pay_department_gl_details gltab on pemp.dept_cd = gltab.dept_cd"
		//    mysql = mysql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//    mysql = mysql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//    mysql = mysql & " Where "
		//    mysql = mysql & "  (gltab.bill_cd = 7) "         'Leave provision biling cd
		//
		//    mysql = mysql & " and ((plas.plas_year = " & Year(mPrevPayrollDate) ' added for testin
		//    mysql = mysql & " and plas.plas_month =  " & Month(mPrevPayrollDate) & ") " ' added for testin
		//
		//    'Commented by burhan. Date:22-may-2008
		//    'desc: to get cumulative balance
		//    mysql = mysql & " or (plas.plas_year = " & Year(CDate(mSecondLastPayrollDate)) ' added for testin
		//    mysql = mysql & " and plas.plas_month =  " & Month(CDate(mSecondLastPayrollDate)) & "))"  ' added for testin
		//    '''
		//    mysql = mysql & " and plas.plas_curr_accru_lc_amount > 0 " ' added for testin
		//
		//'    mysql = mysql & "  and pprov.provision_type = 2 "   ''Leave provision
		//'    mysql = mysql & "  and pprov.generate_date ='" & pVoucherDate & "'"
		//'    mysql = mysql & "  and pprov.provision_amount > 0 "
		//    mysql = mysql & "  group by gltab.ldgr_cd, gltab.cost_cd, gltab.dept_cd "
		//    mysql = mysql & " , gl_ledger.ldgr_no, gl_ledger.l_ldgr_name, gl_ledger.a_ldgr_name "
		//    mysql = mysql & " , cc.cost_no, cc.l_cost_name, cc.a_cost_name "
		//    mysql = mysql & " order by gltab.dept_cd, sorder "
		//Else
		//    'Commented by burhan. Date:22-may-2008
		//    'desc: to get cumulative balance
		//    'mysql = " select sum(plas_curr_accru_lc_amount) lc_amount "
		//    mysql = " select sum(case when plas.plas_year = " & Year(CDate(mPrevPayrollDate)) & " and plas.plas_month = " & Month(CDate(mPrevPayrollDate)) & " then plas_cumm_accrued_amt when plas.plas_year = " & Year(CDate(mSecondLastPayrollDate)) & " and plas.plas_month = " & Month(CDate(mSecondLastPayrollDate)) & "  then plas_cumm_accrued_amt *-1 end)  lc_amount "
		//    ''
		//    mysql = mysql & " ,gltab.ldgr_cd, gltab.cost_cd"
		//    mysql = mysql & " , gltab.emp_cd as emp_dept_cd "
		//    mysql = mysql & " , gl_ledger.ldgr_no , cc.cost_no "
		//    If gPreferedLanguage = English Then
		//        mysql = mysql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//    Else
		//        mysql = mysql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//    End If
		//    mysql = mysql & ", 1 as sorder "
		//    'mySql = mySql & " from pay_gl_provision pprov "
		//    mysql = mysql & " from PAY_LEAVE_ACCRUAL_SUMMARY plas " 'added by burhan for testing
		//    mysql = mysql & " inner join pay_employee pemp on plas.plas_emp_cd = pemp.emp_cd " 'added for testing
		//
		//    mysql = mysql & " inner join pay_employee_gl_details gltab on pemp.emp_cd = gltab.emp_cd"
		//    mysql = mysql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//    mysql = mysql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//    mysql = mysql & " Where "
		//    mysql = mysql & "  (gltab.bill_cd = 2) "         'Leave expenses biling cd
		//
		//    'Commented by burhan. Date:22-may-2008
		//    'desc: to get cumulative balance
		//'    mysql = mysql & " and plas.plas_year = " & Year(mPrevPayrollDate) ' added for testin
		//'    mysql = mysql & " and plas.plas_month =  " & Month(mPrevPayrollDate) ' added for testin
		//    mysql = mysql & " and ((plas.plas_year = " & Year(mPrevPayrollDate) ' added for testin
		//    mysql = mysql & " and plas.plas_month =  " & Month(mPrevPayrollDate) & ") " ' added for testin
		//
		//    mysql = mysql & " or (plas.plas_year = " & Year(CDate(mSecondLastPayrollDate)) ' added for testin
		//    mysql = mysql & " and plas.plas_month =  " & Month(CDate(mSecondLastPayrollDate)) & "))"  ' added for testin
		//    '''
		//    mysql = mysql & " and plas.plas_curr_accru_lc_amount > 0 " ' added for testin
		//
		//'    mySql = mySql & "  and plas.provision_type = 2 "   ''Leave provision
		//'    mySql = mySql & "  and plas.generate_date ='" & pVoucherDate & "'"
		//'    mySql = mySql & "  and plas.provision_amount > 0 "
		//    mysql = mysql & " union all "
		//    mysql = mysql & " select sum(case when plas.plas_year = " & Year(CDate(mPrevPayrollDate)) & " and plas.plas_month = " & Month(CDate(mPrevPayrollDate)) & " then plas_cumm_accrued_amt when plas.plas_year = " & Year(CDate(mSecondLastPayrollDate)) & " and plas.plas_month = " & Month(CDate(mSecondLastPayrollDate)) & "  then plas_cumm_accrued_amt *-1 end)  * -1 lc_amount "
		//    mysql = mysql & " , gltab.ldgr_cd, gltab.cost_cd "
		//    mysql = mysql & " , gltab.emp_cd as emp_dept_cd "
		//    mysql = mysql & " , gl_ledger.ldgr_no , cc.cost_no "
		//    If gPreferedLanguage = English Then
		//        mysql = mysql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//    Else
		//        mysql = mysql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//    End If
		//    mysql = mysql & ", 2 as sorder "
		//
		//    'mySql = mySql & " from pay_gl_provision plas "
		//    mysql = mysql & " from PAY_LEAVE_ACCRUAL_SUMMARY plas " 'added by burhan for testing
		//    mysql = mysql & " inner join pay_employee pemp on plas.plas_emp_cd = pemp.emp_cd " 'added for testing
		//
		//    mysql = mysql & " inner join pay_employee_gl_details gltab on pemp.emp_cd = gltab.emp_cd"
		//    mysql = mysql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//    mysql = mysql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//    mysql = mysql & " Where "
		//    mysql = mysql & "  (gltab.bill_cd = 7) "         'Leave expenses biling cd
		//
		//    'Commented by burhan. Date:22-may-2008
		//    'desc: to get cumulative balance
		//'    mysql = mysql & " and plas.plas_year = " & Year(mPrevPayrollDate) ' added for testin
		//'    mysql = mysql & " and plas.plas_month =  " & Month(mPrevPayrollDate) ' added for testin
		//    mysql = mysql & " and ((plas.plas_year = " & Year(mPrevPayrollDate) ' added for testin
		//    mysql = mysql & " and plas.plas_month =  " & Month(mPrevPayrollDate) & ") " ' added for testin
		//
		//    mysql = mysql & " or (plas.plas_year = " & Year(mSecondLastPayrollDate) ' added for testin
		//    mysql = mysql & " and plas.plas_month =  " & Month(mSecondLastPayrollDate) & "))"  ' added for testin
		//    '''
		//
		//    mysql = mysql & " and plas.plas_curr_accru_lc_amount > 0 " ' added for testin
		//
		//
		//    'mySql = mySql & "  and plas.provision_type = 2 "   ''Leave provision
		//    'mySql = mySql & "  and plas.generate_date ='" & pVoucherDate & "'"
		//    'mySql = mySql & "  and plas.provision_amount > 0 "
		//    mysql = mysql & " order by gltab.emp_cd, sorder "
		//End If
		//
		//Set rsTempRec = New ADODB.Recordset
		//With rsTempRec
		//    .Open mysql, gConn, adOpenForwardOnly, adLockReadOnly
		//
		//    If Not .EOF Then
		//        Do While Not .EOF
		//            If IsNull(.Fields("ldgr_cd")) Then
		//                Call DisplayError(.Fields("emp_dept_cd"))
		//                GoTo mError
		//            Else
		//                mLdgrCd = .Fields("ldgr_cd")
		//                mLdgrNo = .Fields("ldgr_no")
		//                mLdgrName = .Fields("ldgr_name")
		//
		//                If GetSystemPreferenceSetting("cost_center") = True Then
		//                    If IsNull(.Fields("cost_cd")) Then
		//                        Call DisplayError(.Fields("emp_dept_cd"))
		//                        GoTo mError
		//                    Else
		//                        mCostCd = .Fields("cost_cd")
		//                        mCostNo = .Fields("cost_no")
		//                        mCostName = .Fields("cost_name")
		//                    End If
		//                Else
		//                    mCostCd = ""
		//                    mCostNo = ""
		//                    mCostName = ""
		//                End If
		//            End If
		//
		//            If .Fields("lc_amount") > 0 Then
		//                mDrCr = "D"
		//            Else
		//                mDrCr = "C"
		//            End If
		//
		//            If mDrCr = "D" Then
		//                Call InsertIntoArray(cnt, mLdgrNo, mLdgrName, .Fields("lc_amount"), 0 _
		//'                    , mCostNo, mCostName, mLdgrCd, mCostCd, conLeaveProvisionComments)
		//            Else
		//                Call InsertIntoArray(cnt, mLdgrNo, mLdgrName, 0, Abs(.Fields("lc_amount")) _
		//'                    , mCostNo, mCostName, mLdgrCd, mCostCd, conLeaveProvisionComments)
		//            End If
		//
		//            cnt = cnt + 1
		//            .MoveNext
		//        Loop
		//        rsTempRec.Close
		//    End If
		//End With
		//
		//
		//
		//
		//'''Staff Indemnity expenses a/c   dr
		//'''     To Indemnity provision  a/c
		//'mysql = " select pemp.emp_cd , pdept.dept_cd "
		//'mysql = mysql & " from pay_employee pemp "
		//'mysql = mysql & " inner join pay_department pdept on pemp.dept_cd = pdept.dept_cd "
		//'mysql = mysql & " inner join pay_nationality pnat on pemp.nat_cd = pnat.nat_cd "
		//'mysql = mysql & " where pemp.status_cd = 1 "
		//'mysql = mysql & " and pnat.allocate_provision = 1 "
		//'
		//'Set rsTempRec = New ADODB.Recordset
		//'With rsTempRec
		//'    .Open mysql, gConn, adOpenForwardOnly, adLockReadOnly
		//'    Do While Not .EOF
		//'
		//'        mysql = " select  dbo.payIndemnityBalanceDays( "
		//'        mysql = mysql & .Fields("emp_cd")
		//'        mysql = mysql & " , '" & pVoucherDate & "'"
		//'        mysql = mysql & " , 0 ) "
		//'        mReturnValue = GetMasterCode(mysql)
		//'        If Not IsNull(mReturnValue) Then
		//'            mIndemnityBalanceDays = mReturnValue
		//'        Else
		//'            mIndemnityBalanceDays = 0
		//'        End If
		//'
		//'
		//'        ''''Get the previous indemnity provision days
		//'        mysql = " select isnull(sum(provision_days),0) "
		//'        mysql = mysql & " from pay_gl_provision "
		//'        mysql = mysql & " where generate_date <'" & pVoucherDate & "'"
		//'        mysql = mysql & " and emp_cd=" & .Fields("emp_cd")
		//'        mysql = mysql & " and provision_type = 3 "  '''indemnity
		//'        mReturnValue = GetMasterCode(mysql)
		//'        If Not IsNull(mReturnValue) Then
		//'            mPreviousIndemnityBalanceDaysProvision = mReturnValue
		//'        Else
		//'            mPreviousIndemnityBalanceDaysProvision = 0
		//'        End If
		//'
		//'        mIndemnityProvisionDays = mIndemnityBalanceDays - mPreviousIndemnityBalanceDaysProvision
		//'
		//'
		//'        mysql = " select  round( dbo.payIndemnityAmount( "
		//'        mysql = mysql & .Fields("emp_cd")
		//'        mysql = mysql & " , " & mIndemnityProvisionDays
		//'        mysql = mysql & " , '" & pVoucherDate & "'), 3, 1 )"
		//'        mReturnValue = GetMasterCode(mysql)
		//'        If Not IsNull(mReturnValue) Then
		//'            mIndemnityProvisionAmount = mReturnValue
		//'        Else
		//'            mIndemnityProvisionAmount = 0
		//'        End If
		//'
		//'        Call InsertIntoPayGLProvision(pVoucherDate, 3, 1, .Fields("emp_cd") _
		//''            , .Fields("dept_cd"), mIndemnityProvisionDays, mIndemnityProvisionAmount)
		//'
		//'    .MoveNext
		//'    Loop
		//'End With
		//
		//
		//If GetSystemPreferenceSetting("pay_gl_entry_method") = 1 Then
		//    'Commented by Burhan. Date:24-May-2008
		//    'Desc:to get cumulative balance
		//    'mysql = " select sum(pias_curr_accru_lc_amount) lc_amount "
		//    mysql = " select sum(case when pias.pias_year = " & Year(CDate(mPrevPayrollDate)) & " and pias.pias_month = " & Month(CDate(mPrevPayrollDate)) & " then pias_cumm_accrued_amt when pias.pias_year = " & Year(CDate(mSecondLastPayrollDate)) & " and pias.pias_month = " & Month(CDate(mSecondLastPayrollDate)) & "  then pias_cumm_accrued_amt *-1 end )  lc_amount "
		//    mysql = mysql & " , gltab.ldgr_cd, gltab.cost_cd, gltab.dept_cd as emp_dept_cd "
		//    mysql = mysql & " , gl_ledger.ldgr_no , cc.cost_no "
		//    If gPreferedLanguage = English Then
		//        mysql = mysql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//    Else
		//        mysql = mysql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//    End If
		//    mysql = mysql & ", 1 as sorder "
		//    mysql = mysql & " from PAY_INDEMNITY_ACCRUAL_SUMMARY pias "
		//    mysql = mysql & " inner join pay_employee pemp on pias.pias_emp_cd = pemp.emp_cd " 'added for testing
		//
		//    mysql = mysql & " inner join pay_department_gl_details gltab on pemp.dept_cd = gltab.dept_cd"
		//    mysql = mysql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//    mysql = mysql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//    mysql = mysql & " Where "
		//    mysql = mysql & "  (gltab.bill_cd = 8) "         'Leave expenses biling cd
		//
		//
		//     'Commented by burhan. Date:22-may-2008
		//    'desc: to get cumulative balance
		//    'mysql = mysql & " and pias.pias_year = " & Year(mPrevPayrollDate) ' added for testin
		//    'mysql = mysql & " and pias.pias_month =  " & Month(mPrevPayrollDate) ' added for testin
		//
		//    mysql = mysql & " and ((pias.pias_year = " & Year(mPrevPayrollDate) ' added for testin
		//    mysql = mysql & " and pias.pias_month =  " & Month(mPrevPayrollDate) & ") " ' added for testin
		//
		//    mysql = mysql & " or (pias.pias_year = " & Year(mSecondLastPayrollDate) ' added for testin
		//    mysql = mysql & " and pias.pias_month =  " & Month(mSecondLastPayrollDate) & "))"  ' added for testin
		//    '''
		//
		//    mysql = mysql & " and pias.pias_cumm_accrued_amt> 0 " ' added for testin
		//
		//
		//'    mysql = mysql & "  and pprov.provision_type = 3 "   ''Indemnity provision
		//'    mysql = mysql & "  and pprov.generate_date ='" & pVoucherDate & "'"
		//'    mysql = mysql & "  and pprov.provision_amount > 0 "
		//    mysql = mysql & "  group by gltab.ldgr_cd, gltab.cost_cd, gltab.dept_cd "
		//    mysql = mysql & " , gl_ledger.ldgr_no, gl_ledger.l_ldgr_name, gl_ledger.a_ldgr_name "
		//    mysql = mysql & " , cc.cost_no, cc.l_cost_name, cc.a_cost_name "
		//    mysql = mysql & " union all "
		//
		//    'Commented by Burhan. Date:24-May-2008
		//    'Desc:to get cumulative balance
		//    'mysql = mysql & " select sum(pias_curr_accru_lc_amount) * -1 lc_amount "
		//    mysql = mysql & " select sum(case when pias.pias_year = " & Year(CDate(mPrevPayrollDate)) & " and pias.pias_month = " & Month(CDate(mPrevPayrollDate)) & " then pias_cumm_accrued_amt when pias.pias_year = " & Year(CDate(mSecondLastPayrollDate)) & " and pias.pias_month = " & Month(CDate(mSecondLastPayrollDate)) & "  then pias_cumm_accrued_amt *-1 end ) * -1  lc_amount "
		//
		//
		//    mysql = mysql & " , gltab.ldgr_cd, gltab.cost_cd, gltab.dept_cd as emp_dept_cd "
		//    mysql = mysql & " , gl_ledger.ldgr_no , cc.cost_no "
		//    If gPreferedLanguage = English Then
		//        mysql = mysql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//    Else
		//        mysql = mysql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//    End If
		//    mysql = mysql & ", 2 as sorder "
		//    mysql = mysql & " from PAY_INDEMNITY_ACCRUAL_SUMMARY pias "
		//    mysql = mysql & " inner join pay_employee pemp on pias.pias_emp_cd = pemp.emp_cd " 'added for testing
		//    mysql = mysql & " inner join pay_department_gl_details gltab on pemp.dept_cd = gltab.dept_cd"
		//
		//    mysql = mysql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//    mysql = mysql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//    mysql = mysql & " Where "
		//    mysql = mysql & "  (gltab.bill_cd = 9) "         'indemnity provision biling cd
		//
		//     'Commented by burhan. Date:22-may-2008
		//    'desc: to get cumulative balance
		//    'mysql = mysql & " and pias.pias_year = " & Year(mPrevPayrollDate) ' added for testin
		//    'mysql = mysql & " and pias.pias_month =  " & Month(mPrevPayrollDate) ' added for testin
		//
		//    mysql = mysql & " and ((pias.pias_year = " & Year(mPrevPayrollDate) ' added for testin
		//    mysql = mysql & " and pias.pias_month =  " & Month(mPrevPayrollDate) & ") " ' added for testin
		//
		//    mysql = mysql & " or (pias.pias_year = " & Year(mSecondLastPayrollDate) ' added for testin
		//    mysql = mysql & " and pias.pias_month =  " & Month(mSecondLastPayrollDate) & "))"  ' added for testin
		//    '''
		//
		//    mysql = mysql & " and pias.pias_cumm_accrued_amt> 0 " ' added for testin
		//
		//
		//
		//'    mysql = mysql & "  and pprov.provision_type = 3 "   ''indemnity provision
		//'    mysql = mysql & "  and pprov.generate_date ='" & pVoucherDate & "'"
		//'    mysql = mysql & "  and pprov.provision_amount > 0 "
		//    mysql = mysql & "  group by gltab.ldgr_cd, gltab.cost_cd, gltab.dept_cd "
		//    mysql = mysql & " , gl_ledger.ldgr_no, gl_ledger.l_ldgr_name, gl_ledger.a_ldgr_name "
		//    mysql = mysql & " , cc.cost_no, cc.l_cost_name, cc.a_cost_name "
		//    mysql = mysql & " order by gltab.dept_cd, sorder "
		//Else
		//    mysql = " select pias_curr_accru_lc_amount lc_amount "
		//    mysql = mysql & " ,gltab.ldgr_cd, gltab.cost_cd"
		//    mysql = mysql & " , gltab.emp_cd as emp_dept_cd "
		//    mysql = mysql & " , gl_ledger.ldgr_no , cc.cost_no "
		//    If gPreferedLanguage = English Then
		//        mysql = mysql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//    Else
		//        mysql = mysql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//    End If
		//    mysql = mysql & ", 1 as sorder "
		//    'mySql = mySql & " from pay_gl_provision pprov " '
		//    mysql = mysql & " from PAY_INDEMNITY_ACCRUAL_SUMMARY pias "
		//    mysql = mysql & " inner join pay_employee pemp on pias.pias_emp_cd = pemp.emp_cd " 'added for testing
		//
		//    mysql = mysql & " inner join pay_employee_gl_details gltab on pemp.emp_cd = gltab.emp_cd"
		//    mysql = mysql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//    mysql = mysql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//    mysql = mysql & " Where "
		//    mysql = mysql & "  (gltab.bill_cd = 8) "         'indemnity expenses biling cd
		//
		//    mysql = mysql & " and pias.pias_year = " & Year(mPrevPayrollDate) ' added for testin
		//    mysql = mysql & " and pias.pias_month =  " & Month(mPrevPayrollDate) ' added for testin
		//    mysql = mysql & " and pias.pias_curr_accru_lc_amount> 0 " ' added for testin
		//
		//
		//'    mySql = mySql & "  and pprov.provision_type = 3 "   ''indemnity provision
		//'    mySql = mySql & "  and pprov.generate_date ='" & pVoucherDate & "'"
		//'    mySql = mySql & "  and pprov.provision_amount > 0 "
		//    mysql = mysql & " union all "
		//    mysql = mysql & " select (pias_curr_accru_lc_amount * -1) lc_amount "
		//    mysql = mysql & " , gltab.ldgr_cd, gltab.cost_cd "
		//    mysql = mysql & " , gltab.emp_cd as emp_dept_cd "
		//    mysql = mysql & " , gl_ledger.ldgr_no , cc.cost_no "
		//    If gPreferedLanguage = English Then
		//        mysql = mysql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//    Else
		//        mysql = mysql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//    End If
		//    'mySql = mySql & ", gl_ledger.apply_cost_center "
		//    mysql = mysql & ", 2 as sorder "
		//    ' mySql = mySql & " from pay_gl_provision pprov "
		//    mysql = mysql & " from PAY_INDEMNITY_ACCRUAL_SUMMARY pias "
		//    mysql = mysql & " inner join pay_employee pemp on pias.pias_emp_cd = pemp.emp_cd " 'added for testing
		//
		//    mysql = mysql & " inner join pay_employee_gl_details gltab on pemp.emp_cd = gltab.emp_cd"
		//    mysql = mysql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//    mysql = mysql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//    mysql = mysql & " Where "
		//    mysql = mysql & "  (gltab.bill_cd = 9) "         'indemnity provision biling cd
		//
		//    mysql = mysql & " and pias.pias_year = " & Year(mPrevPayrollDate) ' added for testin
		//    mysql = mysql & " and pias.pias_month =  " & Month(mPrevPayrollDate) ' added for testin
		//    mysql = mysql & " and pias.pias_curr_accru_lc_amount> 0 " ' added for testin
		//
		//'    mySql = mySql & "  and pprov.provision_type = 3 "   ''indeminty provision
		//'    mySql = mySql & "  and pprov.generate_date ='" & pVoucherDate & "'"
		//'    mySql = mySql & "  and pprov.provision_amount > 0 "
		//    mysql = mysql & " order by gltab.emp_cd, sorder "
		//End If
		//
		//Set rsTempRec = New ADODB.Recordset
		//With rsTempRec
		//    .Open mysql, gConn, adOpenForwardOnly, adLockReadOnly
		//
		//    If Not .EOF Then
		//        Do While Not .EOF
		//            If IsNull(.Fields("ldgr_cd")) Then
		//                Call DisplayError(.Fields("emp_dept_cd"))
		//                GoTo mError
		//            Else
		//                mLdgrCd = .Fields("ldgr_cd")
		//                mLdgrNo = .Fields("ldgr_no")
		//                mLdgrName = .Fields("ldgr_name")
		//
		//                If GetSystemPreferenceSetting("cost_center") = True Then
		//                    If IsNull(.Fields("cost_cd")) Then
		//                        Call DisplayError(.Fields("emp_dept_cd"))
		//                        GoTo mError
		//                    Else
		//                        mCostCd = .Fields("cost_cd")
		//                        mCostNo = .Fields("cost_no")
		//                        mCostName = .Fields("cost_name")
		//                    End If
		//                Else
		//                    mCostCd = ""
		//                    mCostNo = ""
		//                    mCostName = ""
		//                End If
		//            End If
		//
		//            If .Fields("lc_amount") > 0 Then
		//                mDrCr = "D"
		//            Else
		//                mDrCr = "C"
		//            End If
		//
		//            If mDrCr = "D" Then
		//                Call InsertIntoArray(cnt, mLdgrNo, mLdgrName, .Fields("lc_amount"), 0 _
		//'                    , mCostNo, mCostName, mLdgrCd, mCostCd, conIndemnityProvisionComments)
		//            Else
		//                Call InsertIntoArray(cnt, mLdgrNo, mLdgrName, 0, Abs(.Fields("lc_amount")) _
		//'                    , mCostNo, mCostName, mLdgrCd, mCostCd, conIndemnityProvisionComments)
		//            End If
		//
		//            cnt = cnt + 1
		//            .MoveNext
		//        Loop
		//        rsTempRec.Close
		//    End If
		//End With
		//
		//Set rsTempRec = Nothing
		//Set rsTempRec1 = Nothing
		//
		//GetPayrollEntryInfoIntoArray = True
		//
		//Exit Function
		//
		//mError:
		//GetPayrollEntryInfoIntoArray = False
		//Exit Function
		//
		//End Function

		//Private Sub InsertIntoArray(ByVal pRow As Long, ByVal pAccountNo As String, ByVal pAccountName As String _
		//'        , ByVal pDrAmt As Currency, ByVal pCrAmt As Currency, ByVal pCCCode As String _
		//'        , ByVal pCCName As String, ByVal pLdgrCd As String, ByVal pCCCd As String _
		//'        , ByVal pComments As String)
		//
		//mArr.ReDim 0, pRow, 0, mMaxCols
		//
		//mArr(pRow, gccAccountNo) = pAccountNo
		//mArr(pRow, gccAccountName) = pAccountName
		//mArr(pRow, gccDebit) = Format(pDrAmt, "###,###,###,##0.000")
		//mArr(pRow, gccCredit) = Format(pCrAmt, "###,###,###,##0.000")
		//mArr(pRow, gccCCNo) = pCCCode
		//mArr(pRow, gccCCName) = pCCName
		//mArr(pRow, gccLdgrCd) = pLdgrCd
		//mArr(pRow, gccCCCd) = pCCCd
		//mArr(pRow, gccComments) = pComments
		//
		//End Sub

		private bool ProceedWithUnPostedTransaction(string pGenerateDate)
		{
			DialogResult ans = (DialogResult) 0;

			//''''Check for unposted leave transaction
			string mysql = " select status from pay_leave_transaction ";
			mysql = mysql + " where Status <> 2 ";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				ans = MessageBox.Show(" There are some unposted leave transaction, Do you want to proceed?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			}
			else
			{

				//''''Check for unposted leave adjustment
				mysql = " select status from pay_leave_adjustment ";
				mysql = mysql + " where Status <> 2 ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					ans = MessageBox.Show(" There are some unposted Leave Adjustment transaction, Do you want to proceed?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				}
				else
				{

					//''''Check for unposted salary variation
					mysql = " select status from pay_salary_variation ";
					mysql = mysql + " where Status <> 2 ";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						ans = MessageBox.Show(" There are some unposted Salary Variation transaction, Do you want to proceed?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
					}
					else
					{

						//''''Check for unposted promotion
						mysql = " select status from pay_promotion ";
						mysql = mysql + " where Status <> 2 ";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							ans = MessageBox.Show(" There are some unposted Transfer/Promotion transaction, Do you want to proceed?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
						}
						else
						{

							//''''Check for unposted Leave resume
							mysql = " select status from pay_leave_transaction ";
							mysql = mysql + " where resume_processed_Status <> 2 ";
							mysql = mysql + " and leave_end_date <'" + pGenerateDate + "'";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								ans = MessageBox.Show(" There are some unposted leave resume transaction, Do you want to proceed?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
							}
							else
							{

								//''''Check for Unposted Employee Termination
								mysql = " select status from pay_employee_termination ";
								mysql = mysql + " where Status <> 2 ";
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (!Convert.IsDBNull(mReturnValue))
								{
									ans = MessageBox.Show(" There are some unposted Employee Termination Transaction, Do you want to proceed?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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


			return ans == System.Windows.Forms.DialogResult.Yes;

		}

		private bool UnGeneratedTransactionExists(string pGenerateDate)
		{

			bool result = false;
			string mPayDate = SystemHRProcedure.GetPayrollGenerateDate();

			SqlDataReader rsLocalRec = null;
			//''''Check for ungenerated records from billing details
			string mysql = " select pbt.bill_cd, pebd.emp_cd,  linked_leave_cd";
			mysql = mysql + " , pemp.* ";
			mysql = mysql + " , pebd.bill_cd , pebd.amount ";
			mysql = mysql + " from pay_billing_type pbt ";
			mysql = mysql + " inner join pay_employee_billing_details pebd ";
			mysql = mysql + " on pbt.bill_cd = pebd.bill_cd ";
			mysql = mysql + " inner join pay_employee pemp ";
			mysql = mysql + " on pebd.emp_cd = pemp.emp_cd ";
			mysql = mysql + " Where Not Exists ";
			mysql = mysql + " (select bill_cd, emp_cd from pay_payroll pp ";
			mysql = mysql + " Where pp.bill_cd = pebd.bill_cd And pp.emp_cd = pebd.emp_cd ";
			mysql = mysql + " and pay_date ='" + pGenerateDate + "')";
			mysql = mysql + " and linked_leave_cd is null ";
			mysql = mysql + " and pebd.billing_mode = 'F' ";
			mysql = mysql + " and pemp.status_cd = 1 ";
			mysql = mysql + " and pemp.rate_calc_method_id<>" + SystemHRProcedure.gDailyWages.ToString();
			mysql = mysql + " and pemp.is_payroll_emp = 1";
			mysql = mysql + " and month(pemp.date_of_joining) <= " + DateTime.Parse(mPayDate).Month.ToString();
			mysql = mysql + " and year(pemp.date_of_joining) <= " + DateTime.Parse(mPayDate).Year.ToString();

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			bool rsLocalRecDidRead = rsLocalRec.Read();
			if (rsLocalRecDidRead)
			{
				MessageBox.Show(" Generate the payroll, before closing. Process cancelled! ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				rsLocalRec.Close();


				//''''''''Check for ungenerated leave transaction
				mysql = " select plt.*, pbt.bill_cd from pay_leave_transaction plt ";
				mysql = mysql + " inner join pay_employee pemp on plt.emp_cd = pemp.emp_cd ";
				mysql = mysql + " inner join pay_billing_type pbt on pbt.linked_leave_cd = plt.leave_cd ";
				mysql = mysql + " where plt.is_pay_closed = 0 ";
				mysql = mysql + " and plt.status = 2 ";
				mysql = mysql + " and pemp.is_payroll_emp = 1";
				//mySql = mySql & " and leave_amount_payment_type_id = " & gPayWithPayroll
				mysql = mysql + " and plt.leave_salary_amount > 0 ";
				mysql = mysql + " and plt.leave_amount_payment_type_id <> 50";
				mysql = mysql + " and entry_id not in ";
				mysql = mysql + " ( select trans_id from pay_payroll ";
				mysql = mysql + " where trans_type = 'LeaveTrn' )";
				mysql = mysql + " and pemp.status_cd <> 3";
				mysql = mysql + " and pemp.rate_calc_method_id<>" + SystemHRProcedure.gDailyWages.ToString();
				SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand_2.ExecuteReader();
				bool rsLocalRecDidRead2 = rsLocalRec.Read();
				if (rsLocalRecDidRead)
				{
					MessageBox.Show(" Generate the payroll, before closing. Process cancelled! ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					rsLocalRec.Close();


					//'''''''Check for ungenerated loan transaction
					mysql = " select pl.emp_cd, pl.dept_cd, pl.desg_cd ";
					mysql = mysql + " , entry_id, loan_installment_amount ";
					mysql = mysql + " , total_balance ";
					mysql = mysql + " from pay_loan pl ";
					mysql = mysql + " inner join pay_employee pemp ";
					mysql = mysql + " on pl.emp_cd = pemp.emp_cd ";
					mysql = mysql + " where total_balance > 0 ";
					mysql = mysql + " and pemp.is_payroll_emp = 1";
					mysql = mysql + " and pemp.rate_calc_method_id<>" + SystemHRProcedure.gDailyWages.ToString();
					//''
					//'' Date:07-Jul-2008 Desc:if a loan start date is in december and current month is oct so this loan entry can't generate in this month
					mysql = mysql + " and  pl.start_deduction_date<'" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
					//'' End
					mysql = mysql + " and entry_id not in ";
					mysql = mysql + " ( select trans_id from pay_payroll ";
					mysql = mysql + " where trans_type = 'LoanTrn' ";
					mysql = mysql + " and pay_date ='" + pGenerateDate + "'";
					//''--modified by hakim on 30-apr-2009
					//''it was modified because of the changes made that loan should not be calculated if an employee is on leave or terminated.
					//mysql = mysql & " ) and pemp.status_cd <> 3"
					mysql = mysql + " ) and pemp.status_cd = 1";

					SqlCommand sqlCommand_3 = new SqlCommand(mysql, SystemVariables.gConn);
					rsLocalRec = sqlCommand_3.ExecuteReader();
					bool rsLocalRecDidRead3 = rsLocalRec.Read();
					if (rsLocalRecDidRead)
					{
						MessageBox.Show(" Generate the payroll loan, before closing. Process cancelled! ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						rsLocalRec.Close();

						return false;

					}
				}
			}

			result = true;
			rsLocalRec.Close();
			return result;

		}


		private void PostPayrollTransaction()
		{

			//''''Close the penalty transaction
			string mysql = " update pay_penalty_details ";
			mysql = mysql + " set is_pay_closed = 1 ";
			mysql = mysql + " where (deduction_date >= '" + SystemHRProcedure.GetPayrollGenerateStartDate() + "' and deduction_date <= '" + SystemHRProcedure.GetPayrollGenerateDate() + "')";
			mysql = mysql + " and is_pay_closed = 0 ";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			//''''Close the leave transaction
			mysql = " update pay_leave_transaction ";
			mysql = mysql + " set is_pay_closed = 1 ";
			mysql = mysql + " where Status = 2 ";
			mysql = mysql + " and is_pay_closed = 0 ";
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();


			//''''Close the salary variation
			mysql = " update pay_salary_variation ";
			mysql = mysql + " set is_pay_closed = 1 ";
			mysql = mysql + " where Status = 2 ";
			mysql = mysql + " and is_pay_closed = 0 ";
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mysql;
			TempCommand_3.ExecuteNonQuery();


			//''''Reset Payslip Option In Master
			mysql = "update pay_employee";
			mysql = mysql + " set is_payslip_sent =0";
			SqlCommand TempCommand_4 = null;
			TempCommand_4 = SystemVariables.gConn.CreateCommand();
			TempCommand_4.CommandText = mysql;
			TempCommand_4.ExecuteNonQuery();

			//''''Close the employee termination
			mysql = " update pay_employee_termination ";
			mysql = mysql + " set is_pay_closed = 1 ";
			mysql = mysql + " where Status = 2 ";
			mysql = mysql + " and is_pay_closed = 0 ";
			SqlCommand TempCommand_5 = null;
			TempCommand_5 = SystemVariables.gConn.CreateCommand();
			TempCommand_5.CommandText = mysql;
			TempCommand_5.ExecuteNonQuery();


			//''''Close the employee leave adjustment
			mysql = " update pay_leave_adjustment ";
			mysql = mysql + " set is_pay_closed = 1 ";
			mysql = mysql + " where Status = 2 ";
			mysql = mysql + " and is_pay_closed = 0 ";
			SqlCommand TempCommand_6 = null;
			TempCommand_6 = SystemVariables.gConn.CreateCommand();
			TempCommand_6.CommandText = mysql;
			TempCommand_6.ExecuteNonQuery();

			//''''Close the employee time and attendance
			mysql = " update pay_ta_trans ";
			mysql = mysql + " set is_pay_closed = 1 ";
			mysql = mysql + " where is_pay_closed = 0 ";
			SqlCommand TempCommand_7 = null;
			TempCommand_7 = SystemVariables.gConn.CreateCommand();
			TempCommand_7.CommandText = mysql;
			TempCommand_7.ExecuteNonQuery();

			//'''Close Phone Deduction Entry
			mysql = " update ppd";
			mysql = mysql + " set ppd.is_pay_closed = 1";
			mysql = mysql + " from pay_phone_details ppd";
			mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = ppd.emp_cd";
			mysql = mysql + " where pemp.status_cd <> 2 and ppd.is_pay_closed = 0";
			SqlCommand TempCommand_8 = null;
			TempCommand_8 = SystemVariables.gConn.CreateCommand();
			TempCommand_8.CommandText = mysql;
			TempCommand_8.ExecuteNonQuery();

			//'''Close the payroll transaction
			mysql = " update pay_payroll ";
			mysql = mysql + " set is_pay_closed = 1 ";
			mysql = mysql + " where pay_date = '" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
			SqlCommand TempCommand_9 = null;
			TempCommand_9 = SystemVariables.gConn.CreateCommand();
			TempCommand_9.CommandText = mysql;
			TempCommand_9.ExecuteNonQuery();

			//'''Delete All Billings that End_Date is Finish
			mysql = " delete from pay_employee_billing_details";
			mysql = mysql + " where end_date <= '" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
			SqlCommand TempCommand_10 = null;
			TempCommand_10 = SystemVariables.gConn.CreateCommand();
			TempCommand_10.CommandText = mysql;
			TempCommand_10.ExecuteNonQuery();

		}

		private void UpdateLoanDetails(string pGenerateDate)
		{

			//'''''Update the loan information
			SqlDataReader rsTempRec = null;
			StringBuilder mysql = new StringBuilder();
			mysql.Append(" select lc_amount, trans_id from pay_payroll ");
			mysql.Append(" where pay_date='" + pGenerateDate + "'");
			mysql.Append(" and trans_type = 'LoanTrn'");
			SqlCommand sqlCommand = new SqlCommand(mysql.ToString(), SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{
				mysql = new StringBuilder(" update pay_loan");
				mysql.Append(" set total_salary_deduction = total_salary_deduction +" + Convert.ToString(rsTempRec["lc_amount"]));
				mysql.Append(" , last_deduction_date ='" + pGenerateDate + "'");
				mysql.Append(" where entry_id = " + Convert.ToString(rsTempRec["trans_id"]));
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql.ToString();
				TempCommand.ExecuteNonQuery();
			}
			while(rsTempRec.Read());
			rsTempRec.Close();


			//'' Added By Burhan Ghee Wala
			//'' Date: 22-Jul-2007
			//'' Desc: Check if Employee is terminated and make his loan total balance NIL if not NIL.

			mysql = new StringBuilder(" select pl.* from  pay_loan pl ");
			mysql.Append(" left join pay_employee pemp on pl.emp_cd = pemp.emp_cd ");
			mysql.Append(" Where status_cd = 3 And total_balance > 0");
			SqlCommand sqlCommand_2 = new SqlCommand(mysql.ToString(), SystemVariables.gConn);
			rsTempRec = sqlCommand_2.ExecuteReader();
			bool rsTempRecDidRead2 = rsTempRec.Read();
			do 
			{
				mysql = new StringBuilder(" update pay_loan");
				mysql.Append(" set total_salary_deduction = total_salary_deduction +" + Convert.ToString(rsTempRec["total_balance"]));
				mysql.Append(" , last_deduction_date ='" + pGenerateDate + "'");
				mysql.Append(" where entry_id = " + Convert.ToString(rsTempRec["entry_id"]));
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql.ToString();
				TempCommand_2.ExecuteNonQuery();
			}
			while(rsTempRec.Read());
			rsTempRec.Close();

			//End


		}

		private void UpdatePayrollGenerateHistory(System.DateTime pGenerateDate)
		{


			//commented by burhan. Date: 04-Jun-2008
			//Desc: In order to bring cutoff period
			//mTempDate = "01-" & Format(pGenerateDate, "mmm") & "-" & Format(pGenerateDate, "yyyy")
			//e.g if the current generate date is 24-June-2008 then the new payroll generate date will be 25-June-2008
			//now in database table generate_date field will be stored with the month's starting date instead of month's ending date


			System.DateTime mTempDate = DateTime.Parse(StringsHelper.Format(pGenerateDate.AddDays(1), SystemVariables.gSystemDateFormat));
			string mNewPayrollGenerateDate = StringsHelper.Format(mTempDate, SystemVariables.gSystemDateFormat);
			string mNextPayrollGenerateDate = DateTimeHelper.ToString(DateTime.Parse(StringsHelper.Format(mTempDate, SystemVariables.gSystemDateFormat)).AddMonths(1));
			string mPayrollSalaryDate = DateTimeHelper.ToString(DateTime.Parse(SystemHRProcedure.GetPayrollSalaryDate()).AddMonths(1));

			//''''Update the previous month generation date
			string mysql = " update pay_payroll_generate_history ";
			mysql = mysql + " set previous_generate_date = generate_date ";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			//''''Update the next month generation date
			mysql = " update pay_payroll_generate_history ";
			mysql = mysql + " set generate_date = '" + mNewPayrollGenerateDate + "'";
			mysql = mysql + " , next_generate_date = '" + mNextPayrollGenerateDate + "'";
			mysql = mysql + " , cut_off_date = '" + mPayrollSalaryDate + "'"; //'''Update the Payroll Salary Date date
			mysql = mysql + " , user_cd =" + SystemVariables.gLoggedInUserCode.ToString();
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();


			SystemHRProcedure.gPayrollGenerateEndDate = "";
			SystemHRProcedure.gPayrollGenerateStartDate = "";
			SystemHRProcedure.gPayrollSalaryDate = "";
		}

		private void UpdateMonthEndDate(string pMonthEndDate)
		{
			System.DateTime mTempDate = DateTime.FromOADate(0);
			System.DateTime mNextMonthGenerateDate = DateTime.Parse(SystemHRProcedure.GetMonthEndDate()).AddDays(1).AddMonths(1);
			string mNewMonthEndDate = DateTimeHelper.ToString(mNextMonthGenerateDate.AddDays(-1));
			//mNewMonthEndDate = Format(DateAdd("m", 1, mNewMonthEndDate) - 1, gSystemDateFormat)

			//''''Update the previous month generation date
			string mysql = " update pay_payroll_generate_history ";
			mysql = mysql + " set month_end_date = '" + mNewMonthEndDate + "'";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();


		}


		//Private Sub InsertIntoPayGLProvision(ByVal pVoucherDate As String, ByVal pProvisionType As Long, ByVal pLeaveCd As Long, ByVal pEmpCd As Long, ByVal pDeptCd As Long, ByVal pProvisionDays As Double, ByVal pProvisionAmt As Currency)
		//
		//Dim mysql As String
		//Dim mReturnValue As Variant
		//
		//mysql = " select entry_id "
		//mysql = mysql & " from pay_gl_provision  "
		//mysql = mysql & " where generate_date ='" & Format(pVoucherDate, gSystemDateFormat) & "'"
		//mysql = mysql & " and provision_type = " & pProvisionType
		//
		//If pLeaveCd <> 0 Then
		//    mysql = mysql & " and leave_cd = " & pLeaveCd
		//End If
		//mysql = mysql & " and emp_cd = " & pEmpCd
		//mReturnValue = GetMasterCode(mysql)
		//
		//''''if the record exists then update else insert
		//''''one way the record can exists is through salary increment
		//If Not IsNull(mReturnValue) Then
		//    mysql = mysql & " update pay_gl_provision  "
		//    mysql = mysql & " set "
		//    mysql = mysql & " provision_days = provision_days + " & pProvisionDays
		//    mysql = mysql & " , provision_amount = provision_amount + " & pProvisionAmt
		//    mysql = mysql & " where generate_date ='" & Format(pVoucherDate, gSystemDateFormat) & "'"
		//    mysql = mysql & " and provision_type = " & pProvisionType
		//
		//    If pLeaveCd <> 0 Then
		//        mysql = mysql & " and leave_cd = " & pLeaveCd
		//    End If
		//    mysql = mysql & " and emp_cd = " & pEmpCd
		//    gConn.Execute mysql
		//
		//Else
		//    mysql = " insert into pay_gl_provision "
		//    mysql = mysql & " (generate_date, emp_cd, leave_cd, dept_cd, provision_type "
		//    mysql = mysql & " , provision_days, provision_amount, user_cd) "
		//    mysql = mysql & " values( "
		//    mysql = mysql & "'" & Format(pVoucherDate, gSystemDateFormat) & "'"
		//    mysql = mysql & " , " & pEmpCd
		//
		//    If pLeaveCd <> 0 Then
		//        mysql = mysql & " , " & pLeaveCd
		//    End If
		//
		//    mysql = mysql & " , " & pDeptCd
		//    mysql = mysql & " , " & pProvisionType
		//    mysql = mysql & " , " & pProvisionDays
		//    mysql = mysql & " , " & pProvisionAmt
		//    mysql = mysql & " , " & gLoggedInUserCode
		//    mysql = mysql & " ) "
		//    gConn.Execute mysql
		//End If
		//
		//End Sub

		private void UpdateEmployeeLastSalaryDate(string pGenerateDate)
		{

			string mysql = " update pay_employee ";
			mysql = mysql + " set ";
			mysql = mysql + " last_salary_date='" + pGenerateDate + "'";
			mysql = mysql + " from pay_employee pemp ";
			mysql = mysql + " inner join pay_payroll pp on pemp.emp_cd = pp.emp_cd ";
			mysql = mysql + " where pp.pay_date='" + pGenerateDate + "'";
			mysql = mysql + " and pemp.status_cd =" + SystemHRProcedure.gStatusActive.ToString();
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();


			//''''this modification was done on 17th dec 2006
			//''if an employee goes on leave from 10-dec-2006 to 25-dec-2006'
			//''the payroll is closed before he arrives'
			//''if the resumtion is done in next payroll month ie. jan 2007
			//''then the employee should get 5 days of previous month and 26 days of current month.
			mysql = " update pay_employee ";
			mysql = mysql + " set ";
			mysql = mysql + " last_salary_date= (select max(leave_end_date) ";
			mysql = mysql + "       from pay_leave_transaction ";
			mysql = mysql + "       where emp_cd = pemp.emp_cd )";
			mysql = mysql + " from pay_employee pemp ";
			mysql = mysql + " where pemp.status_cd =" + SystemHRProcedure.gStatusOnLeave.ToString();
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

		}

		//Private Sub DisplayError(ByVal pCode As Long)
		//'''pType = 1 then Department level error
		//'''pType = 2 then Employee level error
		//
		//Dim mysql As String
		//Dim mErrorMessage As String
		//Dim mReturnValue As Variant
		//
		//
		//If GetSystemPreferenceSetting("pay_gl_entry_method") = 1 Then
		//    ''''Department Level entry
		//
		//    mysql = " select "
		//    If gPreferedLanguage = English Then
		//        mysql = mysql & " l_dept_name "
		//    Else
		//        mysql = mysql & " a_dept_name "
		//    End If
		//    mysql = mysql & " from pay_department "
		//    mysql = mysql & " where dept_cd =" & pCode
		//
		//    mErrorMessage = " GL links not defined for Department : "
		//Else
		//    mysql = " select "
		//    If gPreferedLanguage = English Then
		//        mysql = mysql & " l_first_name "
		//    Else
		//        mysql = mysql & " a_first_name "
		//    End If
		//    mysql = mysql & " from pay_employee "
		//    mysql = mysql & " where emp_cd =" & pCode
		//
		//    mErrorMessage = " GL links not defined for Employee : "
		//End If
		//
		//mReturnValue = GetMasterCode(mysql)
		//
		//MsgBox mErrorMessage & mReturnValue
		//End Sub


		private void ResetLeave(string pGenerateDate)
		{


			//'Added By Burhan Ghee
			//'Date: 21-10-2007"
			//'Desc: for leave initialization purpose
			StringBuilder mysql = new StringBuilder();
			mysql.Append(" select pemp.emp_cd, pld.leave_cd, pemp.termination_date, pemp.status_cd ");
			mysql.Append(" , pl.validity_period_type, pl.validity_period_month, month(pemp.date_of_joining) as month_of_joining ");
			mysql.Append(" from pay_employee pemp ");
			mysql.Append(" inner join pay_employee_leave_details pld on pemp.emp_cd = pld.emp_cd ");
			mysql.Append(" inner join pay_leave pl on pld.leave_cd = pl.leave_cd ");
			mysql.Append(" inner join pay_leave_type plt on pl.leave_type_cd = plt.type_cd ");
			mysql.Append(" where plt.type_cd <> 6  ");
			mysql.Append(" and pemp.status_cd <> " + SystemHRProcedure.gStatusTerminated.ToString());
			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql.ToString(), SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{
				if (Convert.ToDouble(rsTempRec["validity_period_type"]) == 0)
				{ //if Validity Type is per fiscal year
					if (DateTime.Parse(pGenerateDate).AddMonths(1).Month == Convert.ToDouble(rsTempRec["validity_period_month"]))
					{
						mysql = new StringBuilder(" update pay_employee_leave_details ");
						mysql.Append(" set ");
						mysql.Append("  paid_leave_taken_days = 0");
						mysql.Append(" where ");
						mysql.Append(" emp_cd =" + Convert.ToString(rsTempRec["emp_cd"]));
						mysql.Append(" and leave_cd =" + Convert.ToString(rsTempRec["leave_cd"]));
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql.ToString();
						TempCommand.ExecuteNonQuery();
					}
				}
				else if (Convert.ToDouble(rsTempRec["validity_period_type"]) == 1)
				{  //if Validity Type is on joining date
					if (DateTime.Parse(pGenerateDate).AddMonths(1).Month == Convert.ToDouble(rsTempRec["month_of_joining"]))
					{
						mysql = new StringBuilder(" update pay_employee_leave_details ");
						mysql.Append(" set ");
						mysql.Append("  paid_leave_taken_days = 0 ");
						mysql.Append(" where ");
						mysql.Append(" emp_cd =" + Convert.ToString(rsTempRec["emp_cd"]));
						mysql.Append(" and leave_cd =" + Convert.ToString(rsTempRec["leave_cd"]));
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql.ToString();
						TempCommand_2.ExecuteNonQuery();
					}
				}
			}
			while(rsTempRec.Read());
			//'End Add
		}


		private void UpdatePayrollLeaveSummary(string pGenerateDate)
		{

			object mReturnValue = null;
			double mPaidDays = 0;
			double mUnPaidDays = 0;
			double mAdjustedPaidDays = 0;
			double mAdjustedUnPaidDays = 0;
			double mCurrLeaveAccruedDays = 0;
			double mCummLeaveAccruedDays = 0;
			decimal mCurrLeaveAmt = 0;
			decimal mCummLeaveAmt = 0;
			decimal mLeaveAmtPaid = 0;
			double mAnnualLeaveDays = 0;
			string mLastAccrualDate = "";
			string mGenerateDate = "";

			SqlDataReader rsTempRec = null;
			string mysql = " select pemp.emp_cd, pld.leave_cd, pemp.termination_date, pemp.status_cd ";
			//'Added By Burhan Ghee
			//'Date: 21-10-2007"
			//'Desc: for leave initialization purpose
			mysql = mysql + " , pl.validity_period_type, pl.validity_period_month, month(pemp.date_of_joining) as month_of_joining ";
			//'End Add
			mysql = mysql + " , pl.deduct_paid_days ,pl.deduct_unpaid_days , pl.deduct_absent_days, pemp.hours_Per_day";
			mysql = mysql + " from pay_employee pemp ";
			mysql = mysql + " inner join pay_employee_leave_details pld on pemp.emp_cd = pld.emp_cd ";
			mysql = mysql + " inner join pay_leave pl on pld.leave_cd = pl.leave_cd ";
			mysql = mysql + " inner join pay_leave_type plt on pl.leave_type_cd = plt.type_cd ";
			mysql = mysql + " where plt.type_cd = 6 ";

			//''
			//'' For Hold Employee Leave summary will not generated
			mysql = mysql + " and pemp.status_cd <>" + SystemHRProcedure.gStatusOnHold.ToString();
			//mySql = mySql & " and pemp.status_cd <> " & gStatusTerminated
			mysql = mysql + " and pemp.date_of_joining <= '" + pGenerateDate + "'";

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{
				mGenerateDate = pGenerateDate;

				//'''do not generate terminated employees
				if (Convert.ToDouble(rsTempRec["status_cd"]) == SystemHRProcedure.gStatusTerminated)
				{
					if (!Convert.IsDBNull(rsTempRec["termination_date"]))
					{
						if (DateTime.Parse(mGenerateDate).Month == Convert.ToDateTime(rsTempRec["termination_date"]).Month && DateTime.Parse(mGenerateDate).Year == Convert.ToDateTime(rsTempRec["termination_date"]).Year)
						{
							mGenerateDate = StringsHelper.Format(rsTempRec["termination_date"], SystemVariables.gSystemDateFormat);
						}
						else
						{
							if (Convert.ToDateTime(rsTempRec["termination_date"]) < DateTime.Parse(mGenerateDate))
							{
								goto mExitSub;
							}
						}
					}
					else
					{
						goto mExitSub;
					}
				}

				mysql = " select dbo.payLeaveBalanceDays(" + Convert.ToString(rsTempRec["emp_cd"]) + " , " + Convert.ToString(rsTempRec["Leave_Cd"]) + " , '" + mGenerateDate + "', 3 ) ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCurrLeaveAccruedDays = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
				}

				mysql = " select  dbo.payLeaveAmount(" + Convert.ToString(rsTempRec["emp_cd"]) + " , " + Convert.ToString(rsTempRec["Leave_Cd"]) + " , " + mCurrLeaveAccruedDays.ToString() + " , '" + mGenerateDate + "' ) ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCurrLeaveAmt = ReflectionHelper.GetPrimitiveValue<decimal>(mReturnValue);
				}
				//
				//        If .Fields("emp_cd") = 49 Then
				//        Stop
				//        End If
				//'' As on 25-Mar-2010
				mysql = "SELECT  top 1 PLAS_CUMM_ACCRUED_DAYS , PLAS_YEAR , PLAS_MONTH ";
				mysql = mysql + " From PAY_LEAVE_ACCRUAL_SUMMARY";
				mysql = mysql + " Where PLAS_EMP_CD = " + Convert.ToString(rsTempRec["emp_cd"]);
				mysql = mysql + " ORDER BY PLAS_YEAR DESC, PLAS_MONTH DESC";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mCummLeaveAccruedDays = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0));
					mLastAccrualDate = DateAndTime.DateSerial(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2)), 1).ToString("dd-MMM-yyyy");
					mLastAccrualDate = DateTime.Parse(mLastAccrualDate).AddMonths(1).ToString("dd-MMM-yyyy");
				}
				else
				{
					mCummLeaveAccruedDays = 0;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select date_of_joining from pay_employee where emp_cd = " + Convert.ToString(rsTempRec["emp_cd"])));
					mLastAccrualDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(mReturnValue).ToString("dd-MMM-yyyy");
				}
				//''End

				mysql = " select plas_emp_cd from pay_leave_accrual_summary plas ";
				mysql = mysql + " where plas_emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
				mysql = mysql + " and plas_leave_cd = " + Convert.ToString(rsTempRec["Leave_Cd"]);
				mysql = mysql + " and plas_year = " + DateTime.Parse(mLastAccrualDate).Year.ToString();
				mysql = mysql + " and plas_month = " + DateTime.Parse(mLastAccrualDate).Month.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					mysql = " insert into pay_leave_accrual_summary ";
					mysql = mysql + " (plas_emp_cd, plas_leave_cd, plas_curr_cd, plas_year, plas_month ,plas_leave_accrual_date ,  plas_user_cd , PLAS_Leave_Salary) ";
					mysql = mysql + " values ( ";
					mysql = mysql + Convert.ToString(rsTempRec["emp_cd"]);
					mysql = mysql + " , " + Convert.ToString(rsTempRec["Leave_Cd"]);
					mysql = mysql + " , 1 ";
					mysql = mysql + " , " + DateTime.Parse(mGenerateDate).Year.ToString();
					mysql = mysql + " , " + DateTime.Parse(mGenerateDate).Month.ToString();
					//'' on 25-Dec-2011 For Accrual Generate Date
					mysql = mysql + " , '" + mGenerateDate + "'";
					mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " , isnull(dbo.PayGetLeaveSalary(" + Convert.ToString(rsTempRec["emp_cd"]) + " , " + Convert.ToString(rsTempRec["Leave_Cd"]) + "),0)";
					mysql = mysql + " ) ";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}

				mysql = " select isnull(sum(paid_days) ,0)  ";
				mysql = mysql + " , isnull(sum(leave_salary_amount)  ,0) ";
				mysql = mysql + " From pay_leave_transaction ";
				mysql = mysql + " where emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
				mysql = mysql + " and status = 2";
				mysql = mysql + " and leave_cd = " + Convert.ToString(rsTempRec["Leave_Cd"]);
				mysql = mysql + " and processdate >= '" + mLastAccrualDate + "'";
				mysql = mysql + " and processdate <= '" + pGenerateDate + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mPaidDays = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLeaveAmtPaid = ReflectionHelper.GetPrimitiveValue<decimal>(((Array) mReturnValue).GetValue(1));
				}
				//''''''  as on 03-aug-2009
				//'''''' For taking paid or paid days on resume
				mysql = " select  ";
				mysql = mysql + "  isnull(sum(adjust_paid_days) ,0)";
				mysql = mysql + " , isnull(sum(adjusted_salary)  ,0) ";
				mysql = mysql + " From pay_leave_transaction ";
				mysql = mysql + " where emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
				mysql = mysql + " and resume_processed_status = 2";
				mysql = mysql + " and leave_cd = " + Convert.ToString(rsTempRec["Leave_Cd"]);
				mysql = mysql + " and resume_processdate  >= '" + mLastAccrualDate + "'";
				mysql = mysql + " and resume_processdate <= '" + pGenerateDate + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mPaidDays += ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0));
					mLeaveAmtPaid = (decimal) (((double) mLeaveAmtPaid) + ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1)));
				}
				//'''''' End
				//'''''' For Unpaid Day at the time of taking leave
				mysql = " select isnull(sum(unpaid_days)  ,0)   ";
				mysql = mysql + " From pay_leave_transaction ";
				mysql = mysql + " where emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
				//mysql = mysql & " and leave_cd = " & .Fields("leave_cd")
				mysql = mysql + " and processdate  >=' " + mLastAccrualDate + "'";
				mysql = mysql + " and processdate <= '" + pGenerateDate + "'";
				mysql = mysql + " and status = 2";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mUnPaidDays = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
				}

				if (Convert.ToBoolean(rsTempRec["deduct_absent_days"]))
				{
					mysql = " select  isnull(sum(no_of_day/" + Convert.ToString(rsTempRec["Hours_Per_day"]) + "),0)";
					mysql = mysql + " From pay_employee_absentdays_details";
					mysql = mysql + " where (AbsentDate >= ' " + mLastAccrualDate + "' and AbsentDate <= '" + pGenerateDate + "')";
					mysql = mysql + " and emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mUnPaidDays += ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
					}
				}
				//''''' END
				//'''''' For Unpaid Day at the time resume duty
				mysql = " select ";
				mysql = mysql + "  isnull(sum(adjust_unpaid_days) ,0)  ";
				mysql = mysql + " From pay_leave_transaction ";
				mysql = mysql + " where emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
				mysql = mysql + " and resume_processdate  >= '" + mLastAccrualDate + "'";
				mysql = mysql + " and resume_processdate <= '" + pGenerateDate + "'";
				mysql = mysql + " and resume_processed_status = 2";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mUnPaidDays += ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
				}


				mysql = " select isnull(sum(adjust_paid_leave_days) ,0) ";
				mysql = mysql + " , isnull(sum(adjust_unpaid_leave_days)  ,0) ";
				mysql = mysql + " From pay_leave_adjustment ";
				mysql = mysql + " where emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
				mysql = mysql + " and leave_cd = " + Convert.ToString(rsTempRec["Leave_Cd"]);
				mysql = mysql + " and voucher_date >= '" + mLastAccrualDate + "'";
				mysql = mysql + " and voucher_date <= '" + pGenerateDate + "'";
				mysql = mysql + " and status = 2 ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAdjustedPaidDays = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAdjustedUnPaidDays = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1));
				}
				//mCummLeaveAccruedDays = (mCummLeaveAccruedDays + mCurrLeaveAccruedDays) - (mPaidDays) + (mAdjustedPaidDays)
				mysql = " select dbo.payLeaveBalanceDays(" + Convert.ToString(rsTempRec["emp_cd"]) + " , " + Convert.ToString(rsTempRec["Leave_Cd"]) + " , '" + mGenerateDate + "', 1 ) ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCummLeaveAccruedDays = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
				}
				else
				{
					mCummLeaveAccruedDays = 0;
				}

				mysql = " select  dbo.payLeaveAmount(" + Convert.ToString(rsTempRec["emp_cd"]) + " , " + Convert.ToString(rsTempRec["Leave_Cd"]) + " , " + mCummLeaveAccruedDays.ToString() + " , '" + mGenerateDate + "') ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCummLeaveAmt = ReflectionHelper.GetPrimitiveValue<decimal>(mReturnValue);
				}


				mysql = " select dateadd(year, peld.leave_switch_over_period, pemp.date_of_joining) ";
				mysql = mysql + " , peld.leave_days_before_sop, peld.leave_days_after_sop,  peld.leave_switch_over_period ";
				mysql = mysql + " from pay_employee_leave_details peld ";
				mysql = mysql + " inner join pay_employee pemp on peld.emp_cd = pemp.emp_cd ";
				mysql = mysql + " Where peld.emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
				mysql = mysql + " and peld.leave_cd =" + Convert.ToString(rsTempRec["Leave_Cd"]);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3)) == 0)
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mAnnualLeaveDays = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						if (DateTime.Parse(mGenerateDate) > ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue).GetValue(0)))
						{
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mAnnualLeaveDays = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2));
						}
						else
						{
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mAnnualLeaveDays = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1));
						}
					}
				}
				//'Added by Burhan Ghee Wala
				//'Date: 21-Oct-2007
				//'Desc: for leave initialization purpose
				if (Convert.ToDouble(rsTempRec["validity_period_type"]) == 0)
				{ //if Validity Type is per fiscal year
					if (DateTime.Parse(pGenerateDate).AddMonths(1).Month == Convert.ToDouble(rsTempRec["validity_period_month"]))
					{
						mAdjustedPaidDays -= mCummLeaveAccruedDays;
						mCummLeaveAccruedDays = 0;
						mCummLeaveAmt = 0;
					}
				}
				else if (Convert.ToDouble(rsTempRec["validity_period_type"]) == 1)
				{  //if Validity Type is on joining date
					if (DateTime.Parse(pGenerateDate).AddMonths(1).Month == Convert.ToDouble(rsTempRec["month_of_joining"]))
					{
						mAdjustedPaidDays -= mCummLeaveAccruedDays;
						mCummLeaveAccruedDays = 0;
						mCummLeaveAmt = 0;
					}
				}
				//' End Add
				mysql = " update pay_leave_accrual_summary ";
				mysql = mysql + " set ";
				mysql = mysql + " plas_accrued_days =" + mCurrLeaveAccruedDays.ToString();
				mysql = mysql + " , plas_availed_days =" + mPaidDays.ToString();
				mysql = mysql + " , plas_lwp_days =" + mUnPaidDays.ToString();
				mysql = mysql + " , plas_adjusted_paid_days =" + mAdjustedPaidDays.ToString();
				mysql = mysql + " , plas_adjusted_unpaid_days =" + mAdjustedUnPaidDays.ToString();
				mysql = mysql + " , plas_curr_accru_fc_amount =" + mCurrLeaveAmt.ToString();
				mysql = mysql + " , plas_curr_accru_lc_amount =" + mCurrLeaveAmt.ToString();
				mysql = mysql + " , plas_cumm_accrued_days =" + mCummLeaveAccruedDays.ToString();
				mysql = mysql + " , plas_cumm_accrued_amt =" + mCummLeaveAmt.ToString();
				mysql = mysql + " , plas_leave_fc_amount_paid =" + mLeaveAmtPaid.ToString();
				mysql = mysql + " , plas_leave_lc_amount_paid =" + mLeaveAmtPaid.ToString();
				mysql = mysql + " , plas_annual_leave_days =" + mAnnualLeaveDays.ToString();
				mysql = mysql + " where ";
				mysql = mysql + " plas_emp_cd =" + Convert.ToString(rsTempRec["emp_cd"]);
				mysql = mysql + " and plas_leave_cd =" + Convert.ToString(rsTempRec["Leave_Cd"]);
				mysql = mysql + " and plas_year =" + DateTime.Parse(mGenerateDate).Year.ToString();
				mysql = mysql + " and plas_month =" + DateTime.Parse(mGenerateDate).Month.ToString();
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				mExitSub:;
			}
			while(rsTempRec.Read());


		}

		//''''' END

		//'''        mysql = " select isnull(sum(paid_days) ,0)  "
		//'''        mysql = mysql & " , isnull(sum(unpaid_days)  ,0) "
		//'''        mysql = mysql & " , isnull(sum(leave_salary_amount)  ,0) "
		//'''        mysql = mysql & " From pay_leave_transaction "
		//'''        mysql = mysql & " where emp_cd = " & .Fields("emp_cd")
		//'''        mysql = mysql & " and leave_cd = " & .Fields("leave_cd")
		//'''        mysql = mysql & " and ( year(leave_start_date) = " & Year(mGenerateDate)
		//'''        mysql = mysql & " and month(leave_start_date) = " & Month(mGenerateDate)
		//'''        mysql = mysql & " ) "
		//'''        mReturnValue = GetMasterCode(mysql)
		//'''        If Not IsNull(mReturnValue) Then
		//'''            mPaidDays = mReturnValue(0)
		//'''            mUnPaidDays = mReturnValue(1)
		//'''            mLeaveAmtPaid = mReturnValue(2)
		//'''        End If
		//'''        'For employee resume
		//'''        mysql = " select  isnull(sum(adjust_paid_days) ,0)  "
		//'''        mysql = mysql & " , isnull(sum(adjust_unpaid_days) ,0)  "
		//'''        mysql = mysql & " , isnull(sum(adjusted_salary)  ,0) "
		//'''        mysql = mysql & " From pay_leave_transaction "
		//'''        mysql = mysql & " where emp_cd = " & .Fields("emp_cd")
		//'''        mysql = mysql & " and leave_cd = " & .Fields("leave_cd")
		//'''        mysql = mysql & " and ( year(actual_resume_date) = " & Year(mGenerateDate)
		//'''        mysql = mysql & " and month(actual_resume_date) = " & Month(mGenerateDate)
		//'''        mysql = mysql & " and resume_processed_status = 2"
		//'''        mysql = mysql & " ) "
		//'''        mReturnValue = GetMasterCode(mysql)
		//'''        If Not IsNull(mReturnValue) Then
		//'''            mPaidDays = mPaidDays + mReturnValue(0)
		//'''            mUnPaidDays = mUnPaidDays + mReturnValue(1)
		//'''            mLeaveAmtPaid = mLeaveAmtPaid + mReturnValue(2)
		//'''        End If

		//        mySql = " select (isnull(sum(plas_accrued_days),0) - isnull(sum(plas_availed_days ),0)) + isnull(sum(PLAS_ADJUSTED_PAID_DAYS ),0) "
		//        mySql = mySql & " from pay_leave_accrual_summary "
		//        mySql = mySql & " where "
		//        mySql = mySql & " plas_emp_cd =" & .Fields("emp_cd").Value
		//        mySql = mySql & " and plas_leave_cd =" & .Fields("leave_cd").Value
		//        mySql = mySql & " and ((plas_year < year('" & mGenerateDate & "')) or"
		//        mySql = mySql & " ((plas_year = year('" & mGenerateDate & "')) and (plas_month < month('" & mGenerateDate & "'))))"
		//        mReturnValue = GetMasterCode(mySql)
		//        If Not IsNull(mReturnValue) Then
		//            mCummLeaveAccruedDays = mReturnValue
		//        End If


		private void UpdatePayrollIndemnitySummary(string pGenerateDate)
		{
			object mReturnValue = null;

			double mCurrIndemnityAccruedDays = 0;
			double mCummIndemnityAccruedDays = 0;
			decimal mCurrIndemnityAmt = 0;
			decimal mCummIndemnityAmt = 0;
			double mAnnualIndemnityDays = 0;

			string mGenerateDate = "";

			string mysql = " select pemp.emp_cd, pemp.status_cd, pemp.termination_date ";
			mysql = mysql + " from pay_employee pemp ";
			mysql = mysql + " inner join pay_nationality pn on pemp.nat_cd = pn.nat_cd";
			//''
			//'' For Hold Employee Indemnity summary will not generated
			mysql = mysql + " where pemp.status_cd <>" + SystemHRProcedure.gStatusOnHold.ToString();
			mysql = mysql + " and pn.Allocate_Provision <> 1 ";
			//mySql = mySql & " where pemp.status_cd <> 3 "

			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{
				mGenerateDate = pGenerateDate;

				//'''do not generate terminated employees
				if (Convert.ToDouble(rsTempRec["status_cd"]) == SystemHRProcedure.gStatusTerminated)
				{
					if (!Convert.IsDBNull(rsTempRec["termination_date"]))
					{
						if (DateTime.Parse(mGenerateDate).Month == Convert.ToDateTime(rsTempRec["termination_date"]).Month && DateTime.Parse(mGenerateDate).Year == Convert.ToDateTime(rsTempRec["termination_date"]).Year)
						{
							mGenerateDate = StringsHelper.Format(rsTempRec["termination_date"], SystemVariables.gSystemDateFormat);
						}
						else
						{
							if (Convert.ToDateTime(rsTempRec["termination_date"]) < DateTime.Parse(mGenerateDate))
							{
								goto mExitSub;
							}
						}
					}
					else
					{
						goto mExitSub;
					}
				}

				mysql = " select dbo.payIndemnityBalanceDays(" + Convert.ToString(rsTempRec["emp_cd"]) + " , '" + mGenerateDate + "', 3 ) ";
				//MsgBox payIndemnityBalanceDays(.Fields("emp_cd"), mGenerateDate, 3)
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCurrIndemnityAccruedDays = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
				}

				mysql = " select  dbo.payIndemnityAmount(" + Convert.ToString(rsTempRec["emp_cd"]) + " , " + mCurrIndemnityAccruedDays.ToString() + " , '" + mGenerateDate + "' ) ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCurrIndemnityAmt = ReflectionHelper.GetPrimitiveValue<decimal>(mReturnValue);
				}

				//'' As on 25-Mar-2010
				mysql = "select  top 1 pias_cumm_accrued_days";
				mysql = mysql + " from pay_indemnity_accrual_summary";
				mysql = mysql + " Where pias_emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
				mysql = mysql + " order by pias_year desc, pias_month desc";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mCummIndemnityAccruedDays = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
				}
				else
				{
					mCummIndemnityAccruedDays = 0;
				}
				//''End

				mysql = " select pias_emp_cd from pay_indemnity_accrual_summary plas ";
				mysql = mysql + " where pias_emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
				mysql = mysql + " and pias_year = " + DateTime.Parse(mGenerateDate).Year.ToString();
				mysql = mysql + " and pias_month = " + DateTime.Parse(mGenerateDate).Month.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					mysql = " insert into pay_indemnity_accrual_summary ";
					mysql = mysql + " (pias_emp_cd, pias_curr_cd, pias_year, pias_month, pias_user_cd) ";
					mysql = mysql + " values ( ";
					mysql = mysql + Convert.ToString(rsTempRec["emp_cd"]);
					mysql = mysql + " , 1 ";
					mysql = mysql + " , " + DateTime.Parse(mGenerateDate).Year.ToString();
					mysql = mysql + " , " + DateTime.Parse(mGenerateDate).Month.ToString();
					mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " ) ";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}


				//        mySql = " select isnull(sum(pias_accrued_days),0)   "
				//        mySql = mySql & " from pay_indemnity_accrual_summary "
				//        mySql = mySql & " where "
				//        mySql = mySql & " pias_emp_cd =" & .Fields("emp_cd").Value
				//        mySql = mySql & " and ((pias_year < year('" & mGenerateDate & "')) or"
				//        mySql = mySql & " ((pias_year = year('" & mGenerateDate & "')) and (pias_month < month('" & mGenerateDate & "'))))"
				//        mReturnValue = GetMasterCode(mySql)
				//        If Not IsNull(mReturnValue) Then
				//            mCummIndemnityAccruedDays = mReturnValue
				//        End If
				mCummIndemnityAccruedDays = (mCummIndemnityAccruedDays + mCurrIndemnityAccruedDays);

				mysql = " select  dbo.payIndemnityAmount(" + Convert.ToString(rsTempRec["emp_cd"]) + " , " + mCummIndemnityAccruedDays.ToString() + " , '" + mGenerateDate + "' ) ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCummIndemnityAmt = ReflectionHelper.GetPrimitiveValue<decimal>(mReturnValue);
				}

				//''
				//'For indeminity day
				mysql = " select dateadd(year, pemp.Indemnity_Switch_Over_Period, pemp.date_of_joining) ";
				mysql = mysql + " , pemp.Indemnity_Days_Before_SOP, pemp.Indemnity_Days_After_SOP,  pemp.Indemnity_Switch_Over_Period ";
				mysql = mysql + " from pay_employee pemp ";
				mysql = mysql + " Where pemp.emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3)) == 0)
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mAnnualIndemnityDays = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						if (DateTime.Parse(mGenerateDate) > ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue).GetValue(0)))
						{
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mAnnualIndemnityDays = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2));
						}
						else
						{
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mAnnualIndemnityDays = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1));
						}
					}
				}
				//'END

				mysql = " update pay_indemnity_accrual_summary ";
				mysql = mysql + " set ";
				mysql = mysql + " pias_accrued_days =" + mCurrIndemnityAccruedDays.ToString();
				mysql = mysql + " , pias_month_days =" + DateAndTime.Day(DateTime.Parse(mGenerateDate)).ToString();
				mysql = mysql + " , pias_curr_accru_fc_amount =" + mCurrIndemnityAmt.ToString();
				mysql = mysql + " , pias_curr_accru_lc_amount =" + mCurrIndemnityAmt.ToString();
				mysql = mysql + " , pias_cumm_accrued_days =" + mCummIndemnityAccruedDays.ToString();
				mysql = mysql + " , pias_cumm_accrued_amt =" + mCummIndemnityAmt.ToString();
				mysql = mysql + " , pias_annual_indemnity_days=" + mAnnualIndemnityDays.ToString();
				mysql = mysql + " where ";
				mysql = mysql + " pias_emp_cd =" + Convert.ToString(rsTempRec["emp_cd"]);
				mysql = mysql + " and pias_year =" + DateTime.Parse(mGenerateDate).Year.ToString();
				mysql = mysql + " and pias_month =" + DateTime.Parse(mGenerateDate).Month.ToString();
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				mExitSub:;
			}
			while(rsTempRec.Read());

		}

		public void UpdatePayrollTicketSummary(string pGenerateDate)
		{

			object mReturnValue = null;

			double mCurrTicketAccrued = 0;
			double mCummTicketAccrued = 0;
			decimal mCurrTicketAmt = 0;
			decimal mCummTicketAmt = 0;
			double mTicketAdjustment = 0;
			double mAnnualTicket = 0;
			decimal mTicketAmount = 0;
			double mTicketTaken = 0;
			double mPaidDays = 0;
			double mUnPaidDays = 0;
			string mGenerateDate = "";

			string mysql = " select pemp.emp_cd, pemp.status_cd, pemp.termination_date ";
			mysql = mysql + " from pay_employee pemp ";
			mysql = mysql + " where pemp.status_cd <>" + SystemHRProcedure.gStatusOnHold.ToString();
			mysql = mysql + " and pemp.ticket = 1";


			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{
				mGenerateDate = pGenerateDate;

				//'''do not generate terminated employees
				if (Convert.ToDouble(rsTempRec["status_cd"]) == SystemHRProcedure.gStatusTerminated)
				{
					if (!Convert.IsDBNull(rsTempRec["termination_date"]))
					{
						if (DateTime.Parse(mGenerateDate).Month == Convert.ToDateTime(rsTempRec["termination_date"]).Month && DateTime.Parse(mGenerateDate).Year == Convert.ToDateTime(rsTempRec["termination_date"]).Year)
						{
							mGenerateDate = StringsHelper.Format(rsTempRec["termination_date"], SystemVariables.gSystemDateFormat);
						}
						else
						{
							if (Convert.ToDateTime(rsTempRec["termination_date"]) < DateTime.Parse(mGenerateDate))
							{
								goto mExitSub;
							}
						}
					}
					else
					{
						goto mExitSub;
					}
				}

				mysql = " select dbo.payTicketBalance(" + Convert.ToString(rsTempRec["emp_cd"]) + " , '" + mGenerateDate + "', 3 ) ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCurrTicketAccrued = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
				}

				mysql = " select return_ticket_amount ";
				mysql = mysql + " from pay_ticket_destination ptd";
				mysql = mysql + " inner join pay_employee pemp on pemp.ticket_destination = ptd.entry_id";
				mysql = mysql + " where emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTicketAmount = ReflectionHelper.GetPrimitiveValue<decimal>(mReturnValue);
				}
				else
				{
					mTicketAmount = 0;
				}

				mCurrTicketAmt = (decimal) (((double) mTicketAmount) * mCurrTicketAccrued);

				mysql = " select ptas_emp_cd from pay_ticket_accrual_summary ptas ";
				mysql = mysql + " where ptas_emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
				mysql = mysql + " and ptas_year = " + DateTime.Parse(mGenerateDate).Year.ToString();
				mysql = mysql + " and ptas_month = " + DateTime.Parse(mGenerateDate).Month.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					mysql = " insert into pay_ticket_accrual_summary ";
					mysql = mysql + " (ptas_emp_cd, ptas_curr_cd, ptas_year, ptas_month, ptas_user_cd) ";
					mysql = mysql + " values ( ";
					mysql = mysql + Convert.ToString(rsTempRec["emp_cd"]);
					mysql = mysql + " , 1 ";
					mysql = mysql + " , " + DateTime.Parse(mGenerateDate).Year.ToString();
					mysql = mysql + " , " + DateTime.Parse(mGenerateDate).Month.ToString();
					mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " ) ";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}

				mysql = " select isnull(sum(ticket_issued),0)";
				mysql = mysql + " From pay_leave_transaction";
				mysql = mysql + " where emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
				mysql = mysql + " and ( year(leave_start_date) = " + DateTime.Parse(mGenerateDate).Year.ToString();
				mysql = mysql + " and month(leave_start_date) = " + DateTime.Parse(mGenerateDate).Month.ToString();
				mysql = mysql + " and status = 2";
				mysql = mysql + " ) ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTicketTaken = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
				}

				mysql = " select isnull(sum(ticket_adjustment),0)";
				mysql = mysql + " from pay_ticket_adjustment_encashment ";
				mysql = mysql + " where emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
				mysql = mysql + " and ( year(voucher_date) = " + DateTime.Parse(mGenerateDate).Year.ToString();
				mysql = mysql + " and month(voucher_date) = " + DateTime.Parse(mGenerateDate).Month.ToString();
				mysql = mysql + " ) ";
				mysql = mysql + " and status = 2";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTicketAdjustment = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
				}
				mPaidDays = 0;
				mUnPaidDays = 0;
				if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("Deduct_paid_day_for_ticket")) == 1)
				{
					mysql = " select isnull(sum(plt.paid_days) ,0)  ";
					mysql = mysql + " From pay_leave_transaction plt";
					mysql = mysql + " inner join pay_leave pl on pl.leave_cd = plt.leave_cd";
					mysql = mysql + " where plt.emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
					mysql = mysql + " and plt.status = 2";
					mysql = mysql + " and pl.leave_type_cd = 6";
					mysql = mysql + " and ( year(plt.leave_start_date) = " + DateTime.Parse(mGenerateDate).Year.ToString();
					mysql = mysql + " and month(plt.leave_start_date) = " + DateTime.Parse(mGenerateDate).Month.ToString();
					mysql = mysql + " ) ";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mPaidDays = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
					}

					mysql = " select  ";
					mysql = mysql + "  isnull(sum(plt.adjust_paid_days) ,0)";
					mysql = mysql + " From pay_leave_transaction plt";
					mysql = mysql + " inner join pay_leave pl on pl.leave_cd = plt.leave_cd";
					mysql = mysql + " where plt.emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
					mysql = mysql + " and plt.resume_processed_status = 2";
					mysql = mysql + " and pl.leave_type_cd = 6";
					mysql = mysql + " and ( year(plt.actual_resume_date) = " + DateTime.Parse(mGenerateDate).Year.ToString();
					mysql = mysql + " and month(plt.actual_resume_date) = " + DateTime.Parse(mGenerateDate).Month.ToString();
					mysql = mysql + " ) ";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mPaidDays += ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
					}
				}

				if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("Deduct_unpaid_day_for_ticket")) == 1)
				{
					mysql = " select isnull(sum(unpaid_days)  ,0)   ";
					mysql = mysql + " From pay_leave_transaction ";
					mysql = mysql + " where emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
					mysql = mysql + " and ( year(leave_start_date) = " + DateTime.Parse(mGenerateDate).Year.ToString();
					mysql = mysql + " and month(leave_start_date) = " + DateTime.Parse(mGenerateDate).Month.ToString();
					mysql = mysql + " and status = 2";
					mysql = mysql + " ) ";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mUnPaidDays = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
					}
					//''''' END
					//'''''' For Unpaid Day at the time resume duty
					mysql = " select ";
					mysql = mysql + "  isnull(sum(adjust_unpaid_days) ,0)  ";
					mysql = mysql + " From pay_leave_transaction ";
					mysql = mysql + " where emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
					mysql = mysql + " and ( year(actual_resume_date) = " + DateTime.Parse(mGenerateDate).Year.ToString();
					mysql = mysql + " and month(actual_resume_date) = " + DateTime.Parse(mGenerateDate).Month.ToString();
					mysql = mysql + " and resume_processed_status = 2";
					mysql = mysql + " ) ";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mUnPaidDays += ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
					}
				}

				mysql = " select isnull(sum(ptas_accrued_ticket),0) - (isnull(sum(ptas_availed_ticket),0) + isnull(sum(ptas_adjusted_ticket),0) )";
				mysql = mysql + " from pay_ticket_accrual_summary ";
				mysql = mysql + " where ";
				mysql = mysql + " ptas_emp_cd =" + Convert.ToString(rsTempRec["emp_cd"]);
				mysql = mysql + " and ((ptas_year < year('" + mGenerateDate + "')) or";
				mysql = mysql + " ((ptas_year = year('" + mGenerateDate + "')) and (ptas_month < month('" + mGenerateDate + "'))))";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCummTicketAccrued = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
				}
				mCummTicketAccrued = (mCummTicketAccrued + mCurrTicketAccrued) + mTicketAdjustment - mTicketTaken;

				mCummTicketAmt = (decimal) (((double) mTicketAmount) * mCummTicketAccrued);

				mysql = " select ticket_per_year ";
				mysql = mysql + " from pay_ticket_type ptt";
				mysql = mysql + " inner join pay_employee pemp on pemp.ticket_type = ptt.entry_id";
				mysql = mysql + " where emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAnnualTicket = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
				}

				mysql = " update pay_ticket_accrual_summary ";
				mysql = mysql + " set ";
				mysql = mysql + " ptas_accrued_ticket =" + mCurrTicketAccrued.ToString();
				mysql = mysql + " , ptas_availed_ticket = " + mTicketTaken.ToString();
				mysql = mysql + " , ptas_adjusted_ticket = " + mTicketAdjustment.ToString();
				mysql = mysql + " , ptas_curr_accru_fc_amount =" + mCurrTicketAmt.ToString();
				mysql = mysql + " , ptas_curr_accru_lc_amount =" + mCurrTicketAmt.ToString();
				mysql = mysql + " , ptas_cumm_accrued_ticket =" + mCummTicketAccrued.ToString();
				mysql = mysql + " , ptas_cumm_accrued_amt =" + mCummTicketAmt.ToString();
				mysql = mysql + " , ptas_annual_ticket=" + mAnnualTicket.ToString();
				mysql = mysql + " , ptas_adjusted_paid_days =" + mPaidDays.ToString();
				mysql = mysql + " , ptas_adjusted_unpaid_days=" + mUnPaidDays.ToString();
				mysql = mysql + " where ";
				mysql = mysql + " ptas_emp_cd =" + Convert.ToString(rsTempRec["emp_cd"]);
				mysql = mysql + " and ptas_year =" + DateTime.Parse(mGenerateDate).Year.ToString();
				mysql = mysql + " and ptas_month =" + DateTime.Parse(mGenerateDate).Month.ToString();
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				mExitSub:;
			}
			while(rsTempRec.Read());

		}

		//Private Sub ClubVoucherEntry() ' added by burhanuddin ghee wala
		//Dim rsTmp As New Recordset
		//Dim i As Integer
		//Dim mysql As String
		//
		//'creatin a new temporary table
		//
		//mysql = "create table #TmpVoucher (account_no varchar(50), account_name varchar(50) "
		//mysql = mysql & ", dr_amount money, cr_amount money, cost_name varchar(50), cost_no int "
		//mysql = mysql & ", led_cd int, cost_cd int )"
		//gConn.Execute mysql
		//
		//For i = 0 To mArr.Count(1) - 1
		//    mysql = "insert into #Tmpvoucher values ('" & mArr(i, gccAccountNo) & "'"
		//    mysql = mysql & " ,'" & mArr(i, gccAccountName) & "'"
		//    mysql = mysql & " ," & CDbl(mArr(i, gccDebit))
		//    mysql = mysql & " ," & CDbl(mArr(i, gccCredit))
		//    mysql = mysql & " ,'" & mArr(i, gccCCName) & "'"
		//    mysql = mysql & " ,'" & mArr(i, gccCCNo) & "'"
		//    mysql = mysql & " ," & mArr(i, gccLdgrCd)
		//    mysql = mysql & " ," & IIf(mArr(i, gccCCCd) = "", 0, mArr(i, gccCCCd)) & ")"
		//    gConn.Execute mysql
		//Next
		//
		//mysql = " select account_no, account_name, cost_no, cost_name, sum(dr_amount) as dr_amount, sum(cr_amount) as cr_amount"
		//mysql = mysql & " ,led_cd, cost_cd from #TmpVoucher where dr_amount > 0 "
		//mysql = mysql & "  group by  account_no, account_name, cost_no, cost_name, led_cd, cost_cd "
		//mysql = mysql & " union "
		//mysql = mysql & " select account_no, account_name, cost_no, cost_name, sum(dr_amount) as dr_amount, sum(cr_amount) as cr_amount"
		//mysql = mysql & " ,led_cd, cost_cd from #TmpVoucher where cr_amount > 0 "
		//mysql = mysql & " group by  account_no, account_name, cost_no, cost_name, led_cd, cost_cd order by sum(cr_amount)"
		//
		//Set mArr = New XArrayDB
		//Set rsTmp = gConn.Execute(mysql)
		//i = 0
		//Do While Not rsTmp.EOF
		//    InsertIntoArray i, rsTmp("account_no"), rsTmp("account_name"), rsTmp("dr_amount"), rsTmp("cr_amount"), _
		//'                    rsTmp("cost_no"), rsTmp("cost_name"), rsTmp("led_cd"), rsTmp("cost_cd"), ""
		//    i = i + 1
		//    rsTmp.MoveNext
		//Loop
		//
		//gConn.Execute "drop table #TmpVoucher"
		//
		//
		//End Sub

		private bool AppendTimeAttendanceHistory()
		{

			// Append All Row of Pay_TA_Trans till Last Month
			string mSQL = " insert into pay_ta_trans_hist(entry_id, company_id, emp_cd, tafield_id, pay_year, pay_month, is_pay_closed, remarks)";
			mSQL = mSQL + " select ptt.Entry_Id, ptt.Company_Id, ptt.Emp_Cd, ptt.TAField_Id, ptt.Pay_Year, ptt.Pay_Month, ptt.Is_Pay_Closed, ptt.Remarks";
			mSQL = mSQL + " from pay_ta_trans ptt";
			mSQL = mSQL + " left outer join pay_ta_trans_hist ptth on ptt.entry_id = ptth.Entry_id";
			mSQL = mSQL + " Where ptt.is_pay_closed = 1 And ptth.entry_id Is Null";
			mSQL = mSQL + " and ptt.pay_month = " + DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddDays(-1).Month.ToString();
			mSQL = mSQL + " and ptt.pay_Year = " + DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddDays(-1).Year.ToString();
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mSQL;
			TempCommand.ExecuteNonQuery();

			// Append All Row of Pay_TA_Trans_Detail till Last Month
			mSQL = "insert into pay_ta_trans_detail_hist(line_no, entry_id, pay_date, pay_day, hrs, affect_payroll, amount, remarks)";
			mSQL = mSQL + " select pttd.line_no, pttd.entry_id, pttd.pay_date, pttd.pay_day, pttd.hrs, pttd.affect_payroll, pttd.amount, pttd.remarks";
			mSQL = mSQL + " from pay_ta_trans_detail pttd";
			mSQL = mSQL + " inner join pay_ta_trans ptt on pttd.entry_id = ptt.entry_id";
			mSQL = mSQL + " left outer join pay_ta_trans_detail_hist pttdh on pttd.line_no = pttdh.line_no";
			mSQL = mSQL + " Where ptt.is_pay_closed = 1 And pttdh.entry_id Is Null";
			mSQL = mSQL + " and ptt.pay_month = " + DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddDays(-1).Month.ToString();
			mSQL = mSQL + " and ptt.pay_Year = " + DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddDays(-1).Year.ToString();

			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mSQL;
			TempCommand_2.ExecuteNonQuery();

			// Delete All Existing row from Pay_ta_trans till Last Month
			mSQL = " delete pay_ta_trans_detail";
			mSQL = mSQL + " from pay_ta_trans_detail pttd";
			mSQL = mSQL + " inner join pay_ta_trans ptt on ptt.entry_id = pttd.entry_id";
			mSQL = mSQL + " where ptt.is_pay_closed = 1";
			mSQL = mSQL + " and ptt.pay_month = " + DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddDays(-1).Month.ToString();
			mSQL = mSQL + " and ptt.pay_Year = " + DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddDays(-1).Year.ToString();
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mSQL;
			TempCommand_3.ExecuteNonQuery();

			// Delete All Existing row from Pay_ta_trans till Last Month
			mSQL = " delete from pay_ta_trans ";
			mSQL = mSQL + " where is_pay_closed = 1";
			mSQL = mSQL + " and pay_month = " + DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddDays(-1).Month.ToString();
			mSQL = mSQL + " and pay_Year = " + DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddDays(-1).Year.ToString();
			SqlCommand TempCommand_4 = null;
			TempCommand_4 = SystemVariables.gConn.CreateCommand();
			TempCommand_4.CommandText = mSQL;
			TempCommand_4.ExecuteNonQuery();

			return false;
		}

		private bool InsertProjectAllocationMaster()
		{
			bool result = false;
			try
			{
				string mysql = "";
				string mPayrollGenDate = "";
				string mLastMonthGnerateDate = "";
				DataSet rs = null;
				string mStartDate = "";
				string mEndDate = "";

				mPayrollGenDate = SystemHRProcedure.GetPayrollGenerateDate();
				mLastMonthGnerateDate = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).AddMonths(-1).ToString("dd/MMM/yyyy");
				mStartDate = DateTimeHelper.ToString(DateTime.Parse(SystemHRProcedure.GetPayrollSalaryDate()));
				mEndDate = DateTime.Parse(SystemHRProcedure.GetPayrollSalaryDate()).AddMonths(1).AddDays(-1).ToString("dd/MMM/yyyy");

				//-----Insert All Billing to pay_project_payroll which in include fro project allocation
				mysql = "insert into pay_project_payroll";
				mysql = mysql + " (emp_cd,pay_date,bill_cd,show)";
				mysql = mysql + " select pemp.emp_cd,'" + mPayrollGenDate + "',pbt.bill_cd,pbt.show_in_project_allocation";
				mysql = mysql + " from pay_billing_type pbt";
				mysql = mysql + " cross join pay_employee pemp";
				mysql = mysql + " where pbt.include_in_project_allocation = 1 and pemp.status_cd not in(3,4)";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
				//-----Update Hours For All Billing
				//''''   '----Updating Fixed Salary Hours
				//''''   mysql = " update ppp"
				//''''   mysql = mysql & " set ppp.pay_hours = pp.pay_hours - plt.pay_now_hours "
				//''''   mysql = mysql & " from pay_project_payroll ppp"
				//''''   mysql = mysql & " inner join pay_payroll pp on pp.bill_cd = ppp.bill_cd and pp.emp_cd = ppp.emp_cd and ppp.pay_date = pp.pay_date"
				//''''   mysql = mysql & " inner join pay_leave_transaction plt on plt.emp_cd = ppp.emp_cd"
				//''''   mysql = mysql & " where pp.pay_date = '" & mPayrollGenDate & "' and  pp.billing_mode = 'F'"
				//''''   mysql = mysql & " and plt.is_pay_closed = 1 and plt.status = 2 and plt.leave_amount_payment_type_id = 53 and payroll_date='" & mPayrollGenDate & "'"
				//''''   gConn.Execute mysql
				//''''   '----Updating All Other Hours
				//''''   mysql = " update ppp"
				//''''   mysql = mysql & " set ppp.pay_hours = isnull(pp.pay_hours,0) "
				//''''   mysql = mysql & " from pay_project_payroll ppp"
				//''''   mysql = mysql & " inner join pay_payroll pp on pp.bill_cd = ppp.bill_cd and pp.emp_cd = ppp.emp_cd and ppp.pay_date = pp.pay_date"
				//''''   mysql = mysql & " where pp.pay_date = '" & mPayrollGenDate & "'"
				//''''   mysql = mysql & " and ppp.emp_cd not in ( select emp_cd from pay_leave_transaction where is_pay_closed = 1 and status = 2 and leave_amount_payment_type_id = 53 and payroll_date='" & mPayrollGenDate & "')"
				//''''
				if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("Import_TimeAttendance_Format")) == 4)
				{
					//------Updating Basic Salary Hours in Project Attendance Table
					mysql = "Update ppp";
					mysql = mysql + " set ppp.pay_hours = isnull((select sum(pttd.Hrs) from v_pay_ta_trans_details pttd inner join v_pay_ta_trans ptt on ptt.entry_id = pttd.entry_id";
					mysql = mysql + " where ptt.tafield_id = 1 and ptt.emp_cd = ppp.emp_cd ";
					if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("Import_TimeAttendance_Format")) != 4)
					{
						mysql = mysql + " and (pttd.pay_date >= '" + mLastMonthGnerateDate + "' and pttd.pay_date <= '" + mPayrollGenDate + "') ),0)";
					}
					else
					{
						mysql = mysql + " and (pttd.pay_date >= '" + mStartDate + "' and pttd.pay_date <= '" + mEndDate + "') ),0)";
					}
					mysql = mysql + " from pay_project_payroll ppp";
					mysql = mysql + " where ppp.pay_date = '" + mPayrollGenDate + "' and ppp.bill_cd = 1";
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
					//------Updating All Billing

					mysql = "Update ppp";
					mysql = mysql + " set ppp.pay_hours = isnull((select sum(pp.pay_hours) from vpay_payroll pp where pp.bill_cd = ppp.bill_cd and pp.pay_date = ppp.pay_date and pp.emp_cd = ppp.emp_cd),0)";
					mysql = mysql + " from pay_project_payroll ppp";
					mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = ppp.bill_cd";
					mysql = mysql + " where ppp.pay_date = '" + mPayrollGenDate + "'";
					mysql = mysql + " and pbt.group_no <> 1";
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					//---------Update Accrual Hrs
					mysql = " update ppp";
					mysql = mysql + " set ppp.pay_hours = (select ppp1.pay_hours from pay_project_payroll ppp1 where ppp1.pay_date = '" + mPayrollGenDate + "' and ppp1.bill_cd =1 and ppp1.emp_cd = ppp.emp_cd )";
					mysql = mysql + " from pay_project_payroll ppp";
					mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = ppp.bill_cd";
					mysql = mysql + " where ppp.pay_date = '" + mPayrollGenDate + "' and pbt.group_no = 1";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();
				}
				else
				{
					//------Updating All Billing
					mysql = "Update ppp";
					if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_Pay_Now_Allocation")))
					{ // Chage as on 11-Nov-2012 for BLK Paynow option
						mysql = mysql + " set ppp.pay_hours = isnull((select sum(pp.pay_hours) from vpay_payroll pp where pp.bill_cd = ppp.bill_cd and pp.pay_date = ppp.pay_date and pp.emp_cd = ppp.emp_cd),0)";
					}
					else
					{
						mysql = mysql + " set ppp.pay_hours = isnull((select sum(pp.pay_hours) from pay_payroll pp where pp.bill_cd = ppp.bill_cd and pp.pay_date = ppp.pay_date and pp.emp_cd = ppp.emp_cd),0)";
					}
					mysql = mysql + " from pay_project_payroll ppp";
					mysql = mysql + " where ppp.pay_date = '" + mPayrollGenDate + "'";
					SqlCommand TempCommand_5 = null;
					TempCommand_5 = SystemVariables.gConn.CreateCommand();
					TempCommand_5.CommandText = mysql;
					TempCommand_5.ExecuteNonQuery();
					//---------Update Accrual Hrs
					mysql = " update ppp";
					mysql = mysql + " set ppp.pay_hours = (select ppp1.pay_hours from pay_project_payroll ppp1 where ppp1.pay_date = '" + mPayrollGenDate + "' and ppp1.bill_cd =1 and ppp1.emp_cd = ppp.emp_cd )";
					mysql = mysql + " from pay_project_payroll ppp";
					mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = ppp.bill_cd";
					mysql = mysql + " where ppp.pay_date = '" + mPayrollGenDate + "' and pbt.bill_no in (9,11,13)";
					SqlCommand TempCommand_6 = null;
					TempCommand_6 = SystemVariables.gConn.CreateCommand();
					TempCommand_6.CommandText = mysql;
					TempCommand_6.ExecuteNonQuery();
				}
				//-----Update Rate For All Billing
				mysql = " update ppp ";
				mysql = mysql + " set ppp.rate = pp.lc_amount / case pp.pay_hours when 0 then 1 else pp.pay_hours end ";
				mysql = mysql + " from pay_project_payroll ppp ";
				mysql = mysql + " inner join pay_payroll pp on pp.bill_cd = ppp.bill_cd and pp.emp_cd = ppp.emp_cd and ppp.pay_date = pp.pay_date";
				mysql = mysql + " where pp.pay_date = '" + mPayrollGenDate + "'";
				SqlCommand TempCommand_7 = null;
				TempCommand_7 = SystemVariables.gConn.CreateCommand();
				TempCommand_7.CommandText = mysql;
				TempCommand_7.ExecuteNonQuery();
				//------Update Rate For Deduction Billing
				mysql = " update ppp ";
				mysql = mysql + " set ppp.rate = ppp.rate * -1 ";
				mysql = mysql + " from pay_project_payroll ppp ";
				mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = ppp.bill_cd ";
				mysql = mysql + " where ppp.pay_date = '" + mPayrollGenDate + "' and pbt.bill_type_id = 52 ";
				SqlCommand TempCommand_8 = null;
				TempCommand_8 = SystemVariables.gConn.CreateCommand();
				TempCommand_8.CommandText = mysql;
				TempCommand_8.ExecuteNonQuery();
				//-----------Update Yearly Fixed Earning and Deduction
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_Yearly_Fixed_Earning_Deduction")))
				{
					mysql = " update pay_project_payroll ";
					mysql = mysql + " set yearly_rate = (dbo.payGetEmpYearlySalary(emp_cd)/(12 * pay_hours)) ";
					mysql = mysql + " where pay_date = '" + mPayrollGenDate + "' and bill_cd = 1 ";
					SqlCommand TempCommand_9 = null;
					TempCommand_9 = SystemVariables.gConn.CreateCommand();
					TempCommand_9.CommandText = mysql;
					TempCommand_9.ExecuteNonQuery();
				}

				return true;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
			}
			return result;
		}


		public bool AllocateProject(string pMonthEndDate)
		{
			string mysql = "";
			string mBillCd = "";

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select bill_cd from pay_billing_type where bill_no = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("last_month_salary_deduction_bill_cd"))));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mBillCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
			}
			else
			{
				mBillCd = "0";
			}
			if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("last_month_earning_bill_cd")) != 0)
			{
				mBillCd = mBillCd + "," + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("last_month_earning_bill_cd"));
			}

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Allocate_All_Payroll_Transaction")))
			{
				mysql = " insert into pay_project_payroll_details(Entry_Id,Pay_Date,Project_Cd,Pay_Hours,Pay_Days)";
				mysql = mysql + " select ppp.Entry_id, ppp.pay_date ,pemp.Default_project,ppp.pay_hours , 0 as days";
				mysql = mysql + " from pay_employee pemp";
				mysql = mysql + " inner join pay_project_payroll ppp on ppp.emp_cd = pemp.emp_cd";
				mysql = mysql + " where  ppp.pay_hours > 0";
				mysql = mysql + " and ppp.pay_date ='" + pMonthEndDate + "'";
				mysql = mysql + " and pemp.default_project is not null";
			}
			else
			{
				mysql = " insert into pay_project_payroll_details(Entry_Id,Pay_Date,Project_Cd,Pay_Hours,Pay_Days)";
				mysql = mysql + " select ppp.Entry_id, ppp.pay_date ,pemp.default_project, ppp.pay_hours , 0 as days";
				mysql = mysql + " from pay_employee pemp";
				mysql = mysql + " inner join pay_project_payroll ppp on ppp.emp_cd = pemp.emp_cd";
				mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = ppp.bill_cd";
				mysql = mysql + " where  ppp.pay_hours > 0 and pbt.over_time = 0 "; // and pbt.bill_cd not in(" & mBillCd & ")"
				mysql = mysql + " and ppp.pay_date ='" + pMonthEndDate + "'";
				mysql = mysql + " and pemp.default_project is not null";
			}

			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();
			return false;
		}

		public bool AllocateProjectOnProjectAttendance(string pMonthEndDate)
		{
			try
			{
				string mysql = "";
				string mBillCd = "";
				object mReturnValue = null;
				string mStartDate = "";
				string mEndDate = "";
				double mCurrtMntTotalHrs = 0;
				double mCurrRemainingHrs = 0;
				int mNOTBillCd = 0;
				int mFOTBillCd = 0;
				int mHOTBillCd = 0;
				int mGotBillCd = 0;
				SqlDataReader rs = null;
				SqlDataReader rsAtten = null;

				mStartDate = SystemHRProcedure.GetPayrollSalaryDate();
				mEndDate = DateTimeHelper.ToString(DateTime.Parse(SystemHRProcedure.GetPayrollSalaryDate()).AddMonths(1).AddDays(-1));
				mysql = "select bill_cd from pay_ta_field where TA_Field_ID = " + ((int) SystemHRProcedure.enumTAFields.eTANormalOT).ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mNOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					mNOTBillCd = 0;
				}
				mysql = "select bill_cd from pay_ta_field where TA_Field_ID = " + ((int) SystemHRProcedure.enumTAFields.eTAFridayOT).ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mFOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					mFOTBillCd = 0;
				}
				mysql = "select bill_cd from pay_ta_field where TA_Field_ID = " + ((int) SystemHRProcedure.enumTAFields.eTAHolidayOT).ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mHOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					mHOTBillCd = 0;
				}
				mysql = "select bill_cd from pay_ta_field where TA_Field_ID = " + ((int) SystemHRProcedure.enumTAFields.eTAGeneralOT).ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mGotBillCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					mGotBillCd = 0;
				}
				mysql = "select emp_cd , emp_no , default_project from pay_employee where status_cd not in (3,4) and default_project is not null ";
				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rs = sqlCommand.ExecuteReader();
				rs.Read();
				do 
				{
					mysql = "select Pay_Hours from pay_project_payroll ";
					mysql = mysql + " where emp_Cd = " + Convert.ToString(rs["emp_cd"]) + " and Pay_Date = '" + pMonthEndDate + "' and bill_cd = 1 ";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						mCurrtMntTotalHrs = 0;
						mCurrRemainingHrs = 0;
					}
					else
					{
						mCurrtMntTotalHrs = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
						mCurrRemainingHrs = mCurrtMntTotalHrs;
					}


					mysql = "select Emp_cd,SUM(WHrs) as Hrs,WHProject_Cd from pay_project_ta_details pptd";
					mysql = mysql + " where pay_date >= '" + mStartDate + "' and pay_date <= '" + mEndDate + "'";
					mysql = mysql + " and WHProject_cd <> " + Convert.ToString(rs["default_project"]);
					mysql = mysql + " and emp_cd = " + Convert.ToString(rs["emp_cd"]);
					mysql = mysql + " and pptd.pay_date not in (select ptd.pay_date from pay_ta_trans pt";
					mysql = mysql + " inner join pay_ta_trans_detail ptd on ptd.entry_id = pt.entry_id";
					mysql = mysql + " where pt.tafield_id = " + ((int) SystemHRProcedure.enumTAFields.eTAWeekend).ToString() + " and ptd.hrs = 1  and pt.emp_cd = " + Convert.ToString(rs["emp_cd"]) + " and ptd.pay_date >= '" + mStartDate + "' and ptd.pay_date < '" + mEndDate + "')";
					mysql = mysql + " group by emp_cd , WHProject_cd";
					SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
					rsAtten = sqlCommand_2.ExecuteReader();
					rsAtten.Read();
					do 
					{
						mysql = " insert into pay_project_payroll_details(Entry_Id,Pay_Date,Project_Cd,Pay_Hours,Pay_Days)";
						mysql = mysql + " select Entry_id, pay_date ," + Convert.ToString(rsAtten["WHProject_cd"]) + "," + Convert.ToString(rsAtten["Hrs"]) + ", 0 as days";
						mysql = mysql + " from pay_project_payroll ppp";
						mysql = mysql + " inner join pay_billing_type pbt on ppp.bill_cd = pbt.bill_cd";
						mysql = mysql + " where  pay_hours > 0";
						mysql = mysql + " and emp_cd = " + Convert.ToString(rsAtten["emp_cd"]);
						mysql = mysql + " and pay_date ='" + pMonthEndDate + "'";
						mysql = mysql + " and pbt.group_no = 1";
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql;
						TempCommand.ExecuteNonQuery();
						mCurrRemainingHrs -= Convert.ToDouble(rsAtten["Hrs"]);
					}
					while(rsAtten.Read());
					rsAtten.Close();
					if (mCurrRemainingHrs > 0)
					{
						mysql = " insert into pay_project_payroll_details(Entry_Id,Pay_Date,Project_Cd,Pay_Hours,Pay_Days)";
						mysql = mysql + " select Entry_id, pay_date ," + Convert.ToString(rs["default_project"]) + "," + mCurrRemainingHrs.ToString() + ", 0 as days";
						mysql = mysql + " from pay_project_payroll ppp";
						mysql = mysql + " inner join pay_billing_type pbt on ppp.bill_cd = pbt.bill_cd";
						mysql = mysql + " where  pay_hours > 0";
						mysql = mysql + " and emp_cd = " + Convert.ToString(rs["emp_cd"]);
						mysql = mysql + " and pay_date ='" + pMonthEndDate + "'";
						mysql = mysql + " and pbt.group_no = 1";
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();
					}
					//-----****************NORMAL OVERTIME IMPORT ******************--------------
					if (mNOTBillCd != 0)
					{
						mysql = " select Emp_cd,SUM([NOT]) as Hrs,NOTProject_Cd from pay_project_ta_details";
						mysql = mysql + " where pay_date >= '" + mStartDate + "' and pay_date <= '" + mEndDate + "'";
						mysql = mysql + " and [NOT] > 0 ";
						mysql = mysql + " and emp_cd = " + Convert.ToString(rs["emp_cd"]);
						mysql = mysql + " group by emp_cd , NOTProject_Cd";
						SqlCommand sqlCommand_3 = new SqlCommand(mysql, SystemVariables.gConn);
						rsAtten = sqlCommand_3.ExecuteReader();
						bool rsAttenDidRead2 = rsAtten.Read();
						do 
						{
							if (!Convert.IsDBNull(rsAtten["NOTProject_Cd"]))
							{
								mysql = " insert into pay_project_payroll_details(Entry_Id,Pay_Date,Project_Cd,Pay_Hours,Pay_Days)";
								mysql = mysql + " select Entry_id, pay_date ," + Convert.ToString(rsAtten["NOTProject_Cd"]) + "," + Convert.ToString(rsAtten["Hrs"]) + ", 0 as days";
								mysql = mysql + " from pay_project_payroll ppp";
								mysql = mysql + " inner join pay_billing_type pbt on ppp.bill_cd = pbt.bill_cd";
								mysql = mysql + " where  pay_hours > 0 ";
								mysql = mysql + " and emp_cd = " + Convert.ToString(rsAtten["emp_cd"]);
								mysql = mysql + " and pay_date = '" + pMonthEndDate + "'";
								mysql = mysql + " and ppp.bill_cd = " + mNOTBillCd.ToString();
								SqlCommand TempCommand_3 = null;
								TempCommand_3 = SystemVariables.gConn.CreateCommand();
								TempCommand_3.CommandText = mysql;
								TempCommand_3.ExecuteNonQuery();
							}
						}
						while(rsAtten.Read());
						rsAtten.Close();
					}
					//-----************************* END ***************************--------------
					//-----****************FRIDAY OVERTIME IMPORT ******************--------------
					if (mFOTBillCd != 0)
					{
						mysql = "select Emp_cd,SUM(FOT) as Hrs,FOTProject_Cd from pay_project_ta_details";
						mysql = mysql + " where pay_date >= '" + mStartDate + "' and pay_date <= '" + mEndDate + "'";
						mysql = mysql + " and emp_cd = " + Convert.ToString(rs["emp_cd"]);
						mysql = mysql + " and [FOT] > 0 ";
						mysql = mysql + " group by emp_cd , FOTProject_Cd";
						SqlCommand sqlCommand_4 = new SqlCommand(mysql, SystemVariables.gConn);
						rsAtten = sqlCommand_4.ExecuteReader();
						bool rsAttenDidRead3 = rsAtten.Read();
						do 
						{
							if (!Convert.IsDBNull(rsAtten["FOTProject_Cd"]))
							{
								mysql = " insert into pay_project_payroll_details(Entry_Id,Pay_Date,Project_Cd,Pay_Hours,Pay_Days)";
								mysql = mysql + " select Entry_id, pay_date ," + Convert.ToString(rsAtten["FOTProject_Cd"]) + "," + Convert.ToString(rsAtten["Hrs"]) + ", 0 as days";
								mysql = mysql + " from pay_project_payroll ppp";
								mysql = mysql + " inner join pay_billing_type pbt on ppp.bill_cd = pbt.bill_cd";
								mysql = mysql + " where  pay_hours > 0";
								mysql = mysql + " and emp_cd = " + Convert.ToString(rsAtten["emp_cd"]);
								mysql = mysql + " and pay_date ='" + pMonthEndDate + "'";
								mysql = mysql + " and ppp.bill_cd = " + mFOTBillCd.ToString();
								SqlCommand TempCommand_4 = null;
								TempCommand_4 = SystemVariables.gConn.CreateCommand();
								TempCommand_4.CommandText = mysql;
								TempCommand_4.ExecuteNonQuery();
							}
						}
						while(rsAtten.Read());
						rsAtten.Close();
					}
					//-----************************* END ***************************--------------
					//-----****************HOLIDAY OVERTIME IMPORT ******************--------------
					if (mHOTBillCd != 0)
					{
						mysql = "select Emp_cd,SUM(HOT) as Hrs,HOTProject_Cd from pay_project_ta_details";
						mysql = mysql + " where pay_date >= '" + mStartDate + "' and pay_date <= '" + mEndDate + "'";
						mysql = mysql + " and emp_cd = " + Convert.ToString(rs["emp_cd"]);
						mysql = mysql + " and [HOT] > 0 ";
						mysql = mysql + " group by emp_cd , HOTProject_Cd";
						SqlCommand sqlCommand_5 = new SqlCommand(mysql, SystemVariables.gConn);
						rsAtten = sqlCommand_5.ExecuteReader();
						bool rsAttenDidRead4 = rsAtten.Read();
						do 
						{
							if (!Convert.IsDBNull(rsAtten["HOTProject_Cd"]))
							{
								mysql = " insert into pay_project_payroll_details(Entry_Id,Pay_Date,Project_Cd,Pay_Hours,Pay_Days)";
								mysql = mysql + " select Entry_id, pay_date ," + Convert.ToString(rsAtten["HOTProject_Cd"]) + "," + Convert.ToString(rsAtten["Hrs"]) + ", 0 as days";
								mysql = mysql + " from pay_project_payroll ppp";
								mysql = mysql + " inner join pay_billing_type pbt on ppp.bill_cd = pbt.bill_cd";
								mysql = mysql + " where  pay_hours > 0";
								mysql = mysql + " and emp_cd = " + Convert.ToString(rsAtten["emp_cd"]);
								mysql = mysql + " and pay_date ='" + pMonthEndDate + "'";
								mysql = mysql + " and ppp.bill_cd = " + mHOTBillCd.ToString();
								SqlCommand TempCommand_5 = null;
								TempCommand_5 = SystemVariables.gConn.CreateCommand();
								TempCommand_5.CommandText = mysql;
								TempCommand_5.ExecuteNonQuery();
							}
						}
						while(rsAtten.Read());
						rsAtten.Close();
					}
					//-----************************* END ***************************--------------
					//-----****************GENERAL OVERTIME IMPORT ******************--------------
					if (mGotBillCd != 0)
					{
						mysql = "select Emp_cd,SUM(GOT) as Hrs,GOTProject_Cd from pay_project_ta_details";
						mysql = mysql + " where pay_date >= '" + mStartDate + "' and pay_date <= '" + mEndDate + "'";
						mysql = mysql + " and emp_cd = " + Convert.ToString(rs["emp_cd"]);
						mysql = mysql + " and [GOT] > 0 and General_OT_Amt = 1";
						mysql = mysql + " group by emp_cd , GOTProject_Cd";
						SqlCommand sqlCommand_6 = new SqlCommand(mysql, SystemVariables.gConn);
						rsAtten = sqlCommand_6.ExecuteReader();
						bool rsAttenDidRead5 = rsAtten.Read();
						do 
						{
							if (!Convert.IsDBNull(rsAtten["GOTProject_Cd"]))
							{
								mysql = " insert into pay_project_payroll_details(Entry_Id,Pay_Date,Project_Cd,Pay_Hours,Pay_Days)";
								mysql = mysql + " select Entry_id, pay_date ," + Convert.ToString(rsAtten["GOTProject_Cd"]) + "," + Convert.ToString(rsAtten["Hrs"]) + ", 0 as days";
								mysql = mysql + " from pay_project_payroll ppp";
								mysql = mysql + " inner join pay_billing_type pbt on ppp.bill_cd = pbt.bill_cd";
								mysql = mysql + " where  pay_hours > 0";
								mysql = mysql + " and emp_cd = " + Convert.ToString(rsAtten["emp_cd"]);
								mysql = mysql + " and pay_date ='" + pMonthEndDate + "'";
								mysql = mysql + " and ppp.bill_cd = " + mGotBillCd.ToString();
								SqlCommand TempCommand_6 = null;
								TempCommand_6 = SystemVariables.gConn.CreateCommand();
								TempCommand_6.CommandText = mysql;
								TempCommand_6.ExecuteNonQuery();
							}
						}
						while(rsAtten.Read());
						rsAtten.Close();
					}
					//-----************************* END ***************************
				}
				while(rs.Read());
			}
			catch
			{

				MessageBox.Show("Project Attendance Import Error!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			return false;
		}

		public bool GenearateAbsentHrsAdjustment(string pGenerateDate, string pFromEmp = "", string pToEmp = "")
		{
			try
			{
				StringBuilder mysql = new StringBuilder();
				int mVoucherNo = 0;
				SqlDataReader rs = null;
				string mStartDate = "";
				string mEndDate = "";

				mStartDate = SystemHRProcedure.GetPayrollSalaryDate();
				mEndDate = DateTime.Parse(mStartDate).AddMonths(1).ToString("dd/MMM/yyyy");

				mysql = new StringBuilder(" select emp_cd,dept_cd,desg_cd,basic_salary,total_salary");
				mysql.Append("     ,isnull(dbo.PayGetAbsentDaysByPeriod( '" + mStartDate + "','" + mEndDate + "',emp_cd),0) as absent_days");
				mysql.Append(" From pay_employee");
				mysql.Append(" Where status_cd <> 3");
				mysql.Append("   and isnull(dbo.PayGetAbsentDaysByPeriod('" + mStartDate + "','" + mEndDate + "',emp_cd),0) >0");
				if (!SystemProcedure2.IsItEmpty(pFromEmp, SystemVariables.DataType.StringType))
				{
					mysql.Append("   and emp_no >= '" + pFromEmp + "'");
					mysql.Append("   and emp_no <= '" + pToEmp + "'");
				}

				SqlCommand sqlCommand = new SqlCommand(mysql.ToString(), SystemVariables.gConn);
				rs = sqlCommand.ExecuteReader();
				rs.Read();
				do 
				{
					mysql = new StringBuilder(" insert into pay_employee_absentdays_details(emp_cd,pay_date,absentDate,no_of_day,user_cd)");
					mysql.Append(" values(");
					mysql.Append(Convert.ToString(rs["emp_cd"]));
					mysql.Append(" ,'" + pGenerateDate + "'");
					mysql.Append(" ,'" + pGenerateDate + "'");
					mysql.Append(" ," + Convert.ToString(rs["absent_days"]));
					mysql.Append(" ," + SystemVariables.gLoggedInUserCode.ToString());
					mysql.Append(" )");
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql.ToString();
					TempCommand.ExecuteNonQuery();
				}
				while(rs.Read());
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

			return false;
		}
	}
}