
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayDailyPayrollEntry
		: System.Windows.Forms.Form
	{

		private XArrayHelper _aVoucherDetails = null;
		public frmPayDailyPayrollEntry()
{
InitializeComponent();
} 
 public  void frmPayDailyPayrollEntry_old()
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

		private clsToolbar oThisFormToolBar = null;
		int mThisFormID = 0;
		private int mFormCallType = 0;
		private object mSearchValue = null;
		
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

		// For Column Constraint
		private const int conLineNo = 0;
		private const int conFieldName = 1;
		private const int conDays = 2;
		private const int conHours = 3;
		private const int conAmount = 4;
		private const int conAffectPayroll = 5;
		private const int conRemarks = 6;
		private const int conTAFieldId = 7;
		private const int conEntryId = 8;

		private const int conMaxColumns = 9;

		private const int ConDlblEmployeeName = 1;
		private const int conDlblBasicSalary = 2;
		private const int conDlblTotalSalary = 3;

		private double mNormalOTRate = 0;
		private double mFridayOTRate = 0;
		private double mHolidayOTRate = 0;
		private double mBasicSalary = 0;
		private double mTotalSalary = 0;
		private bool mAllowOvertime = false;
		private double mHoursPerDay = 0;
		private double mDaysPerMonth = 0;
		private double mRatePerHour = 0;
		private int mRateCalcMethod = 0;
		private double mRatePerDay = 0;
		private bool mIsGridChanged = false;
		private double mOvertimeSalary = 0;
		private int mOvertimeFormat = 0;
		private bool mIsEntitleForOT = false;
		//Dim mOldSickDay As Double
		double mOldPaidDays = 0;
		double mOldUnPaidDays = 0;
		double mUnPaidDays = 0;
		double mPaidDays = 0;
		int mOvertimeWorkingDays = 0;



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


		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				txtEmployeeCode.Focus();
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
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void Form_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				DialogResult mAns = (DialogResult) 0;

				if (KeyAscii == 43 || KeyAscii == 45)
				{
					if (mIsGridChanged)
					{
						mAns = MessageBox.Show("Do you want to save record ?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
						if (mAns == System.Windows.Forms.DialogResult.Yes)
						{
							saveRecord();
							txtPayDate.Focus();
						}
						else if (mAns == System.Windows.Forms.DialogResult.Cancel)
						{ 
							KeyAscii = 0;
							grdVoucherDetails.Focus();
							if (KeyAscii == 0)
							{
								eventArgs.Handled = true;
							}
							return;
						}
					}
					txtPayDate.Value = (KeyAscii == 45) ? ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtPayDate.Value).AddDays(-1) : ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtPayDate.Value).AddDays(1);
					txtPayDate_Leave(txtPayDate, new EventArgs());
					KeyAscii = 0;
				}
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{
				int i = 0;
				int mSday = 0;
				int mCol = 0;
				string mStr = "";
				DataSet rsLocalRec = null;
				string mysql = "";
				object mReturnValue = null;
				System.DateTime mGenerateDate = DateTime.FromOADate(0);
				System.DateTime mStartDate = DateTime.FromOADate(0);

				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = false;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = false;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = false;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowInsertLineButton = false;
				oThisFormToolBar.ShowDeleteLineButton = false;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;
				FirstFocusObject = grdVoucherDetails;
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mOvertimeFormat = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Overtime_Format"));

				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.4f, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Field Name", 2500, false, SystemConstants.gDisableColumnBackColor);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Days", 650, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Hours", 650, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Affect Payroll", 600, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "FieldId", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				//To Get days in which order they wants to display
				mGenerateDate = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate());
				mStartDate = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate());


				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mGenerateDate))
				{
					DefineVoucherArray(-1, true);
				}
				else
				{
					MessageBox.Show("Cut off date not defined.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}

				//
				//For i = 1 To 31
				//    mStr = Day(mStartDate)
				//    If mStartDate <= mGenerateDate Then
				//        Call DefineSystemVoucherGridColumn(grdVoucherDetails, mStr, 500, True, , , , False, , , , , , , , True, , True)
				//    Else
				//        Call DefineSystemVoucherGridColumn(grdVoucherDetails, mStr, 500, True, , , , False, , , , , , , , False, , True)
				//    End If
				//     mStartDate = mStartDate + 1
				//Next
				// End Of Day Spacify


				SystemProcedure.SetLabelCaption(this);


				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);

				grdVoucherDetails.Visible = true;
				grdVoucherDetails.Enabled = true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
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



		public bool saveRecord(bool pApprove = false)
		{
			bool result = false;
			StringBuilder mysql = new StringBuilder();
			int mEmpCd = 0;
			int cnt = 0;

			try
			{

				if (!grdVoucherDetails.Enabled)
				{
					MessageBox.Show("Cannot save previous month's record.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				SystemVariables.gConn.BeginTransaction();

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					mysql = new StringBuilder(" update pay_ta_trans_detail set hrs = " + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, conHours))).ToString());
					mysql.Append(", amount = " + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, conAmount))).ToString());
					mysql.Append(", affect_payroll = " + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, conAffectPayroll))).ToString());
					mysql.Append(", remarks = N'" + Convert.ToString(aVoucherDetails.GetValue(cnt, conRemarks)) + "'");
					mysql.Append(" where line_no = " + Convert.ToString(aVoucherDetails.GetValue(cnt, conEntryId)));
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql.ToString();
					TempCommand.ExecuteNonQuery();
				}

				//''Update Sick Leave
				mEmpCd = SystemHRProcedure.GetEmpCd(txtEmployeeCode.Text);
				if (mOldPaidDays != 0 || mOldUnPaidDays != 0)
				{
					SystemHRProcedure.UpdateSickLeaveDays(mOldPaidDays * -1, mOldUnPaidDays * -1, mEmpCd);
				}
				if (mPaidDays != 0 || mUnPaidDays != 0)
				{
					SystemHRProcedure.UpdateSickLeaveDays(mPaidDays, mUnPaidDays, mEmpCd);
				}

				SystemHRProcedure.ClearPayroll(SystemHRProcedure.GetPayrollGenerateDate(), txtEmployeeCode.Text, txtEmployeeCode.Text);
				SystemHRProcedure.GeneratePayrollEntry(SystemHRProcedure.GetPayrollGenerateDate(), txtEmployeeCode.Text, txtEmployeeCode.Text);
				SystemHRProcedure.GenerateLeaveEntry(SystemHRProcedure.GetPayrollGenerateDate(), txtEmployeeCode.Text, txtEmployeeCode.Text);
				SystemHRProcedure.GenerateLoanEntry(SystemHRProcedure.GetPayrollGenerateDate(), txtEmployeeCode.Text, txtEmployeeCode.Text);

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				//'-05-Nov-2008
				result = true;
				if (FormCallType == 1)
				{
					mIsGridChanged = false;
					grdVoucherDetails.Enabled = false;
				}
				else
				{
					CloseForm();
				}
				//'End
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				result = false;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

			return result;
		}



		public bool CheckDataValidity()
		{
			string mSQL = " select count(*) from pay_employee where emp_no = '" + txtEmployeeCode.Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
			if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) <= 0)
			{
				MessageBox.Show("Invalid Employee Code entered!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			return true;
		}

		public void PrintReport()
		{

		}

		public void CloseForm()
		{
			this.Close();
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			Form oFormName = null;
			if (mIsGridChanged)
			{
				if (MessageBox.Show("Do you want to save record ?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					saveRecord();
					mIsGridChanged = false;
					if (mFormCallType == 2)
					{
						SystemForms.GetSystemForm(904100, 2, mSearchValue);
					}
				}
			}
		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			grdVoucherDetails.UpdateData();
			mIsGridChanged = true;
		}

		private void grdVoucherDetails_BeforeColUpdate(object eventSender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			object OldValue = eventArgs.OldValue;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				try
				{
					int mCol = 0;
					string mysql = "";
					object mReturnValue = null;
					int mRow = 0;
					int cnt = 0;
					double mLeaveBalance = 0;
					int mCurrentCellHrs = 0;

					mCol = grdVoucherDetails.Col;
					//UPGRADE_WARNING: (1068) grdVoucherDetails.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mRow = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark);
					//UPGRADE_WARNING: (1068) grdVoucherDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCurrentCellHrs = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[ColIndex].Value);

					if (mRateCalcMethod != SystemHRProcedure.gDailyWages)
					{
						if (mCol == conDays)
						{
							grdVoucherDetails.Columns[conHours].Value = ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conDays].Value) * mHoursPerDay;
						}
						else
						{
							grdVoucherDetails.Columns[conDays].Value = ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conHours].Value) / mHoursPerDay;
						}
					}
					else
					{
						if (mCol == conDays)
						{
							grdVoucherDetails.Columns[conHours].Value = ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conDays].Value) * 8;
						}
						else
						{
							grdVoucherDetails.Columns[conDays].Value = ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conHours].Value) / 8d;
						}
					}

					if (ColIndex == conHours || ColIndex == conDays)
					{
						if (Convert.ToDouble(aVoucherDetails.GetValue(mRow, conTAFieldId)) == 3)
						{ //Sick Leave Calculation
							mLeaveBalance = SystemHRProcedure.Leave_Balance_Days(Convert.ToInt32(ReflectionHelper.GetPrimitiveValue<double>(mSearchValue)), 3, ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtPayDate.Value), 4);
							if (ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conDays].Value) > mLeaveBalance)
							{
								mysql = " select dbo.payLeaveAmount(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ",3," + Conversion.Val(mLeaveBalance.ToString()).ToString() + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtPayDate.DisplayText) + "')";
								grdVoucherDetails.Columns[conRemarks].Value = mLeaveBalance.ToString() + " ;";
								mPaidDays = mLeaveBalance;
								mUnPaidDays = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[conDays].Value)) - mLeaveBalance;
							}
							else
							{
								mysql = " select dbo.payLeaveAmount(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ",3," + Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[conDays].Value)).ToString() + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtPayDate.DisplayText) + "')";
								grdVoucherDetails.Columns[conRemarks].Value = ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[conDays].Value) + " ; ";
								mPaidDays = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[conDays].Value));
								mUnPaidDays = 0;
							}
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								grdVoucherDetails.Columns[conAmount].Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(mReturnValue), "#####0.000");
							}
							if (ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conDays].Value) > mLeaveBalance)
							{
								mysql = " select dbo.payLeavedetails(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ",3," + Conversion.Val(mLeaveBalance.ToString()).ToString() + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtPayDate.DisplayText) + "')";
							}
							else
							{
								mysql = " select dbo.payLeavedetails(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ",3," + Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[conDays].Value)).ToString() + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtPayDate.DisplayText) + "')";
							}
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
								grdVoucherDetails.Columns[conRemarks].Value = ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conRemarks].Value) + Double.Parse(ReflectionHelper.GetPrimitiveValue<string>(mReturnValue));
							}
							if (ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conDays].Value) > 0)
							{
								grdVoucherDetails.Columns[conAffectPayroll].Value = 1;
							}
							else
							{
								grdVoucherDetails.Columns[conAffectPayroll].Value = 0;
							}
						}
						if (Convert.ToDouble(aVoucherDetails.GetValue(mRow, conTAFieldId)) == 1)
						{ // Working Hours
							if (mRateCalcMethod == SystemHRProcedure.gDailyWages)
							{
								grdVoucherDetails.Columns[conAmount].Value = ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conHours].Value) * mRatePerHour;
								if (ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conHours].Value) == 0)
								{
									grdVoucherDetails.Columns[conAffectPayroll].Value = 0;
								}
								else
								{
									grdVoucherDetails.Columns[conAffectPayroll].Value = 1;
								}
							}
							else
							{
								if (StringsHelper.ToDoubleSafe(grdVoucherDetails.Columns[conHours].Text) > mHoursPerDay)
								{
									MessageBox.Show("Employee Hours cannot exceed more than " + mHoursPerDay.ToString() + ".", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									Cancel = -1;
									return;
								}
								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								if (((SystemHRProcedure.enumTAFields) ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[conTAFieldId].Value)) == SystemHRProcedure.enumTAFields.eTAWorkHours)
								{
									int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
									for (cnt = 0; cnt <= tempForEndVar; cnt++)
									{
										//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
										if (((SystemHRProcedure.enumTAFields) Convert.ToInt32(aVoucherDetails.GetValue(cnt, conTAFieldId))) == SystemHRProcedure.enumTAFields.eTAAbsentHours)
										{
											aVoucherDetails.SetValue(mHoursPerDay - Double.Parse(grdVoucherDetails.Columns[conHours].Text), cnt, conHours);
											break;
										}
									}
								}
							}
						}
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((SystemHRProcedure.enumTAFields) ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[conTAFieldId].Value)) == SystemHRProcedure.enumTAFields.eTAAbsentHours)
						{
							int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
							for (cnt = 0; cnt <= tempForEndVar2; cnt++)
							{
								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								if (((SystemHRProcedure.enumTAFields) Convert.ToInt32(aVoucherDetails.GetValue(cnt, conTAFieldId))) == SystemHRProcedure.enumTAFields.eTAWorkHours)
								{
									aVoucherDetails.SetValue(mHoursPerDay - Double.Parse(grdVoucherDetails.Columns[conHours].Text), cnt, conHours);
									break;
								}
							}
						}
						if (mAllowOvertime)
						{
							mysql = "select pbt.bill_no,pbt.bill_cd from pay_ta_field ptf";
							mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = ptf.bill_cd";
							mysql = mysql + " where ta_field_id=" + Convert.ToString(aVoucherDetails.GetValue(mRow, conTAFieldId));
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							if (mRateCalcMethod != SystemHRProcedure.gDailyWages)
							{ // overtime is not applicable for daily wages employee
								if (Convert.ToDouble(aVoucherDetails.GetValue(mRow, conTAFieldId)) == 5)
								{ // Normal OT
									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select dbo.paygetovertimesalary(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "," + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1)) + ")"));
									//If GetSystemPreferenceSetting("Overtime_Working_Days") <> 0 Then
									if (mOvertimeWorkingDays != 0)
									{
										mDaysPerMonth = mOvertimeWorkingDays; //GetSystemPreferenceSetting("Overtime_Working_Days")
									}
									if (mOvertimeFormat == 1)
									{
										grdVoucherDetails.Columns[conAmount].Value = SystemHRProcedure.Rounding(((mOvertimeSalary) / (mDaysPerMonth * mHoursPerDay) * ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conHours].Value)) * mNormalOTRate, ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
									}
									else
									{
										grdVoucherDetails.Columns[conAmount].Value = SystemHRProcedure.Rounding(((mOvertimeSalary * 12) / (365 * mHoursPerDay) * ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conHours].Value)) * mNormalOTRate, ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
									}
									grdVoucherDetails.Columns[conAffectPayroll].Value = 1;
								}
								if (Convert.ToDouble(aVoucherDetails.GetValue(mRow, conTAFieldId)) == 6)
								{ // Friday OT
									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select dbo.paygetovertimesalary(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "," + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1)) + ")"));
									//If GetSystemPreferenceSetting("Overtime_Working_Days") <> 0 Then
									if (mOvertimeWorkingDays != 0)
									{
										mDaysPerMonth = mOvertimeWorkingDays; //GetSystemPreferenceSetting("Overtime_Working_Days")
									}
									if (mOvertimeFormat == 1)
									{
										grdVoucherDetails.Columns[conAmount].Value = SystemHRProcedure.Rounding(((mOvertimeSalary) / (mDaysPerMonth * mHoursPerDay) * ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conHours].Value)) * mFridayOTRate, ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
									}
									else
									{
										grdVoucherDetails.Columns[conAmount].Value = SystemHRProcedure.Rounding(((mOvertimeSalary * 12) / (365 * mHoursPerDay) * ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conHours].Value)) * mFridayOTRate, ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
									}
									grdVoucherDetails.Columns[conAffectPayroll].Value = 1;
								}
								if (Convert.ToDouble(aVoucherDetails.GetValue(mRow, conTAFieldId)) == 7)
								{ // Holiday OT
									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select dbo.paygetovertimesalary(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "," + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1)) + ")"));
									//If GetSystemPreferenceSetting("Overtime_Working_Days") <> 0 Then
									if (mOvertimeWorkingDays != 0)
									{
										mDaysPerMonth = mOvertimeWorkingDays; //GetSystemPreferenceSetting("Overtime_Working_Days")
									}
									if (mOvertimeFormat == 1)
									{
										grdVoucherDetails.Columns[conAmount].Value = SystemHRProcedure.Rounding(((mOvertimeSalary) / (mDaysPerMonth * mHoursPerDay) * ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conHours].Value)) * mHolidayOTRate, ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
									}
									else
									{
										grdVoucherDetails.Columns[conAmount].Value = SystemHRProcedure.Rounding(((mOvertimeSalary * 12) / (365 * mHoursPerDay) * ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conHours].Value)) * mHolidayOTRate, ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
									}
									grdVoucherDetails.Columns[conAffectPayroll].Value = 1;
								}
							}
							else
							{
								if (Convert.ToDouble(aVoucherDetails.GetValue(mRow, conTAFieldId)) == 5)
								{
									grdVoucherDetails.Columns[conAmount].Value = SystemHRProcedure.Rounding((mRatePerHour * ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conHours].Value)) * mNormalOTRate, ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
									grdVoucherDetails.Columns[conAffectPayroll].Value = 1;
								}
								else if (Convert.ToDouble(aVoucherDetails.GetValue(mRow, conTAFieldId)) == 6)
								{ 
									grdVoucherDetails.Columns[conAmount].Value = SystemHRProcedure.Rounding((mRatePerHour * ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conHours].Value)) * mFridayOTRate, ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
									grdVoucherDetails.Columns[conAffectPayroll].Value = 1;
								}
								else if (Convert.ToDouble(aVoucherDetails.GetValue(mRow, conTAFieldId)) == 7)
								{ 
									grdVoucherDetails.Columns[conAmount].Value = SystemHRProcedure.Rounding((mRatePerHour * ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conHours].Value)) * mHolidayOTRate, ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
									grdVoucherDetails.Columns[conAffectPayroll].Value = 1;
								}
								if (ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conHours].Value) == 0)
								{
									grdVoucherDetails.Columns[conAffectPayroll].Value = 0;
								}
								else
								{
									grdVoucherDetails.Columns[conAffectPayroll].Value = 1;
								}
							}
						}
					}

					CalculateTotal();

					grdVoucherDetails.Refresh();
					return;
				}
				catch (System.Exception excep)
				{
					int mReturnErrorType = 0;
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
					MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		//Private Sub GridColorChange()
		//Dim mColCnt As Integer
		//Dim mRowCnt As Integer
		//For mRowCnt = 0 To aVoucherDetails.Count(1) - 1
		//   If aVoucherDetails(mRowCnt, mConTAFieldID) = eTAWeekend Or aVoucherDetails(mRowCnt, mConTAFieldID) = eTAPublicHoliday Then
		//        For mColCnt = 2 To 32
		//            If aVoucherDetails(mRowCnt, mColCnt) > 0 Then
		//                 grdVoucherDetails.Columns.Item(mColCnt).BackColor = &H8080FF
		//            End If
		//        Next
		//    End If
		//Next
		//End Sub

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			//UPGRADE_WARNING: (1068) grdVoucherDetails.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int grdRow = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark);
			if (Col == conAffectPayroll)
			{
				if (Convert.ToDouble(aVoucherDetails.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), Col)) == 1)
				{
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgChecked2"];
					CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
				}
				else if (Convert.ToDouble(aVoucherDetails.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), Col)) == 0)
				{ 
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgUnchecked"];
					CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
				}
			}
		}

		private void CalculateTotal()
		{
			//Dim mColCnt As Integer
			//Dim mRowCnt As Integer
			//Dim mTotal As Double
			//For mColCnt = 0 To grdVoucherDetails.Columns.Count - 1
			//    mTotal = 0
			//    If grdVoucherDetails.Columns.Item(mColCnt).ColIndex >= 2 And grdVoucherDetails.Columns.Item(mColCnt).ColIndex <= 32 Then
			//        For mRowCnt = 0 To aVoucherDetails.Count(1) - 1
			//           If aVoucherDetails(mRowCnt, mConTAFieldType) <> "B" Then
			//                mTotal = mTotal + aVoucherDetails(mRowCnt, mColCnt)
			//           End If
			//        Next mRowCnt
			//        grdVoucherDetails.Columns(mColCnt).FooterText = mTotal
			//        grdVoucherDetails.Columns(mColCnt).Alignment = dbgCenter
			//        grdVoucherDetails.Columns(mColCnt).FooterAlignment = dbgCenter
			//    End If
			//Next
		}

		public void AddRecord()
		{
			int cnt = 0;
			try
			{

				int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					grdVoucherDetails.Columns[cnt].FooterText = "";
					if (cnt > 1)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdVoucherDetails.Splits[0].DisplayColumns[cnt].Style.BackColor = Color.White;
					}
				}
				SystemProcedure2.ClearTextBox(this);
				DefineVoucherArray(-1, true);
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
				mSearchValue = ""; //Change the msearchvalue to blank
				txtEmployeeCode.Focus();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == conAmount || ColIndex == conHours)
			{
				Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###,###,##0.000");
			}
		}

		private void grdVoucherDetails_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				try
				{
					int mRow = 0;
					int mCol = 0;
					mRow = grdVoucherDetails.Row;
					mCol = grdVoucherDetails.Col;
					if (grdVoucherDetails.Col == conAffectPayroll)
					{
						if (KeyAscii == 32)
						{
							KeyAscii = 0;
							grdVoucherDetails_Post(grdVoucherDetails, new AxTrueOleDBGrid80.TrueDBGridEvents_PostEventEvent(1));
						}
						else
						{
							KeyAscii = 0;
						}
						if (KeyAscii == 0)
						{
							eventArgs.Handled = true;
						}
						return;
					}
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					return;
				}
				catch
				{
				}
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}

		private void grdVoucherDetails_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (grdVoucherDetails.PointAt(X, Y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
			{
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.PostMsg(1);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{
			int Col = 0;
			try
			{
				Col = grdVoucherDetails.Col;

				if (grdVoucherDetails.Col == conAffectPayroll)
				{
					if (ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[Col].Value) == 0)
					{
						grdVoucherDetails.Columns[Col].Value = 1;
					}
					else
					{
						grdVoucherDetails.Columns[Col].Value = 0;
					}
					grdVoucherDetails.UpdateData();
					grdVoucherDetails.Refresh();
				}
			}
			catch
			{
			}
		}

		private void txtEmployeeCode_DropButtonClick(Object Sender, EventArgs e)
		{
			txtEmployeeCode.Text = "";
			string mSQL = " pay_emp.status_cd not in (3,4) ";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", mSQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtEmployeeCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				txtEmployeeCode_Leave(txtEmployeeCode, new EventArgs());
			}
		}

		private void txtEmployeeCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				string mysql = "";
				object mTempValue = null;
				if (!SystemProcedure2.IsItEmpty(txtEmployeeCode.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name" : "a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name");
					mysql = mysql + " , emp_cd ";
					mysql = mysql + " , pemp.basic_salary, pemp.total_salary, pemp.normal_ot, pemp.friday_ot, pemp.holiday_ot, pemp.allow_overtime, pemp.hours_per_day ";
					mysql = mysql + " , pemp.rate_calc_method_id, pemp.days_per_month, pemp.weekend_day1_id, pemp.weekend_day2_id, pemp.rate_per_hour, pemp.rate_per_day , pemp.Overtime_Working_Days";
					mysql = mysql + " from pay_employee pemp , pay_department pdept, pay_designation pdesg ";
					mysql = mysql + " where ";
					mysql = mysql + " pemp.dept_cd = pdept.dept_cd and pemp.desg_cd = pdesg.desg_cd ";
					mysql = mysql + " and pemp.emp_no ='" + txtEmployeeCode.Text + "'";
					mysql = mysql + " and pemp.status_cd not in (3,4)";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDisplayLabel[ConDlblEmployeeName].Text = "";
						txtDisplayLabel[conDlblBasicSalary].Text = "";
						mTotalSalary = 0;
						mNormalOTRate = 0;
						mFridayOTRate = 0;
						mHolidayOTRate = 0;
						mAllowOvertime = false;
						mHoursPerDay = 0;
						mDaysPerMonth = 0;
						mRatePerHour = 0;
						mRatePerDay = 0;
						mOvertimeWorkingDays = 0;
						//Err.Raise -9990002
						MessageBox.Show("Check Employee Code", "Daily Payroll", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDisplayLabel[ConDlblEmployeeName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(1));
						txtDisplayLabel[conDlblBasicSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(2)), "###,###,##0.000");
						txtDisplayLabel[conDlblTotalSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(3)), "###,###,##0.000");
						mBasicSalary = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2)));
						mTotalSalary = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3)));
						if (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mTempValue).GetValue(7)))
						{
							mNormalOTRate = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4)));
							mFridayOTRate = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(5))); //IIf(IsNull(Val(mTempValue(5))), 0, Val(mTempValue(5))) '
							mHolidayOTRate = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(6))); //IIf(IsNull(Val(mTempValue(6))), 0, Val(mTempValue(6))) '
						}
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mAllowOvertime = ReflectionHelper.GetPrimitiveValue<bool>(((Array) mTempValue).GetValue(7));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mHoursPerDay = ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(8));
						if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(9)) == SystemHRProcedure.gFixedDays)
						{ //if fixed days
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mDaysPerMonth = ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(10));
							mRatePerHour = 0;
							mRateCalcMethod = SystemHRProcedure.gFixedDays;
						}
						else if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(9)) == SystemHRProcedure.gActualDays)
						{ 
							mDaysPerMonth = SystemHRProcedure.CalculateDays(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()), DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()), ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(11)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(12)));
							mRatePerHour = 0;
							mRateCalcMethod = SystemHRProcedure.gActualDays;
						}
						else
						{
							// if daily wages
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mRatePerHour = ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(13));
							mRateCalcMethod = SystemHRProcedure.gDailyWages;
							mDaysPerMonth = 0;
						}
						mOvertimeWorkingDays = Convert.ToInt32(Math.Floor(ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(15))));
					}
				}
				else
				{
					txtDisplayLabel[ConDlblEmployeeName].Text = "";
					txtDisplayLabel[conDlblBasicSalary].Text = "";
					mBasicSalary = 0;
					mTotalSalary = 0;
					mNormalOTRate = 0;
					mFridayOTRate = 0;
					mHolidayOTRate = 0;
					mAllowOvertime = false;
					mHoursPerDay = 0;
					mDaysPerMonth = 0;
					mRatePerHour = 0;
					return;
				}
				txtPayDate.Value = SystemHRProcedure.GetPayrollGenerateStartDate();
				FillGridData();
			}
			catch
			{
			}

		}

		private void FillGridData()
		{
			try
			{
				System.DateTime mGenerateDate = DateTime.FromOADate(0);
				System.DateTime mStartDate = DateTime.FromOADate(0);
				string mSQL = "";
				DataSet rsLocal = null;
				int cnt = 0;
				object mReturnValue = null;

				mGenerateDate = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate());
				mStartDate = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate());

				if (txtEmployeeCode.Text == "" || SystemProcedure2.IsItEmpty(txtPayDate.DisplayText, SystemVariables.DataType.DateType))
				{
					return;
				}
				if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtPayDate.Value) < mStartDate)
				{
					grdVoucherDetails.Enabled = false;
					grdVoucherDetails.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(SystemConstants.gDisableColumnBackColor)));
				}
				else
				{
					grdVoucherDetails.Enabled = true;
					grdVoucherDetails.BackColor = Color.White;
				}
				mSQL = " select line_no," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_field_name " : " a_field_name");
				mSQL = mSQL + " as field_name, hrs, amount, affect_payroll, pttd.remarks, ptt.tafield_id";
				mSQL = mSQL + " from pay_ta_trans ptt ";
				mSQL = mSQL + " inner join pay_employee pemp on pemp.emp_cd = ptt.emp_cd ";
				mSQL = mSQL + " inner join pay_ta_field ptf on ptt.tafield_id = ptf.ta_field_id ";
				mSQL = mSQL + " inner join pay_ta_trans_detail pttd on pttd.entry_id = ptt.entry_id";
				mSQL = mSQL + " where pay_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtPayDate.DisplayText) + "'";
				mSQL = mSQL + " and pemp.emp_no  = '" + txtEmployeeCode.Text + "'";
				mSQL = mSQL + " and ptf.ta_field_id not in (10, 4, 15 ,16 ,14) order by ptf.ta_field_id";

				rsLocal = new DataSet();

				SqlDataAdapter adap = new SqlDataAdapter(mSQL, SystemVariables.gConn);
				rsLocal.Tables.Clear();
				adap.Fill(rsLocal);
				cnt = 0;
				aVoucherDetails.RedimXArray(new int[]{rsLocal.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
				foreach (DataRow iteration_row in rsLocal.Tables[0].Rows)
				{
					aVoucherDetails.SetValue(iteration_row["line_no"], cnt, conEntryId);
					aVoucherDetails.SetValue(iteration_row["field_name"], cnt, conFieldName);
					aVoucherDetails.SetValue(iteration_row["amount"], cnt, conAmount);
					if (mHoursPerDay == 0)
					{
						aVoucherDetails.SetValue(0, cnt, conDays);
					}
					else
					{
						aVoucherDetails.SetValue(Convert.ToDouble(iteration_row["hrs"]) / mHoursPerDay, cnt, conDays);
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((SystemHRProcedure.enumTAFields) Convert.ToInt32(iteration_row["tafield_id"])) == SystemHRProcedure.enumTAFields.eTASickHours)
						{
							if (Convert.ToDouble(iteration_row["hrs"]) > 0)
							{
								//                  mReturnValue = Val(Split(.Fields("remarks").Value, ";"))
								//                  If Not IsNull(mReturnValue) Then
								mOldPaidDays = Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, conDays)));
								mOldUnPaidDays = Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, conDays))) - mPaidDays;
								//                  Else
								//                     mOldPaidDays = 0
								//                     mOldUnPaidDays = 0
								//                  End If
							}
							else
							{
								mOldPaidDays = 0;
								mOldUnPaidDays = 0;
							}
						}
					}
					aVoucherDetails.SetValue(iteration_row["hrs"], cnt, conHours);
					aVoucherDetails.SetValue((Convert.ToBoolean(iteration_row["affect_payroll"])) ? 1 : 0, cnt, conAffectPayroll);
					aVoucherDetails.SetValue(iteration_row["remarks"], cnt, conRemarks);
					aVoucherDetails.SetValue(iteration_row["tafield_id"], cnt, conTAFieldId);
					cnt++;
				}
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Refresh();
				Application.DoEvents();
				mIsGridChanged = false;
			}
			catch
			{
			}

		}


		private void txtPayDate_Leave(Object eventSender, EventArgs eventArgs)
		{
			FillGridData();
		}

		public void FindRoutine(string pObjectName)
		{

			if (pObjectName == "txtEmployeeCode")
			{
				txtEmployeeCode_DropButtonClick(txtEmployeeCode, null);
			}

		}

		public void GetRecord(int pSearchValue)
		{
			int mCnt = 0;
			string mSQL = "select emp_no from pay_employee";
			mSQL = mSQL + " where emp_cd=" + pSearchValue.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));

			mSearchValue = pSearchValue;

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtEmployeeCode.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				txtEmployeeCode_Leave(txtEmployeeCode, new EventArgs());
			}

			txtPayDate.Value = SystemHRProcedure.GetPayrollGenerateDate();
			txtPayDate_Leave(txtPayDate, new EventArgs());

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (mCnt = 0; mCnt <= tempForEndVar; mCnt++)
			{
				if (Convert.ToDouble(aVoucherDetails.GetValue(mCnt, conTAFieldId)) == SystemHRProcedure.gCurrentTAFieldId)
				{
					grdVoucherDetails.Row = mCnt;
					grdVoucherDetails.Col = conTAFieldId;
				}
			}

		}
	}
}