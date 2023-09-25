
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayLeaveAmount
		: System.Windows.Forms.Form
	{

		public frmPayLeaveAmount()
{
InitializeComponent();
} 
 public  void frmPayLeaveAmount_old()
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


		private void frmPayLeaveAmount_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		private XArrayHelper _aVoucherDetails = null;
		public XArrayHelper aVoucherDetails
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

		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		public object mSearchValue = null;
		public string mFromDate = "";
		public int mLeaveCd = 0;
		public double mTotalLeaveAmount = 0;
		public double mPaidDays = 0;
		public int mCalltype = 0;
		public int mLeaveEntID = 0;

		private const int conMaxColumns = 6;
		private const int mContractEndDate = 1;
		private const int mLeaveBalDays = 2;
		private const int mLeaveTakenDays = 3;
		private const int mLeaveSalaryC = 4;
		private const int mLeaveDaysTake = 5;
		private const int mLeaveAmount = 6;

		public SystemVariables.SystemFormModes CurrentFormMode
		{
			set
			{
				mCurrentFormMode = value;
			}
		}


		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			this.Hide();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			int mCnt = 0;

			mTotalLeaveAmount = 0;
			double mTotalPaidDays = 0;
			grdLeaveAmountDetails.UpdateData();
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (mCnt = 0; mCnt <= tempForEndVar; mCnt++)
			{
				mTotalLeaveAmount += Convert.ToDouble(aVoucherDetails.GetValue(mCnt, mLeaveAmount));
				mTotalPaidDays += Convert.ToDouble(aVoucherDetails.GetValue(mCnt, mLeaveDaysTake));
			}
			if (Conversion.Val(mPaidDays.ToString()) != Conversion.Val(mTotalPaidDays.ToString()))
			{
				MessageBox.Show("Paid Days are not equal to total paid days.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			this.Hide();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			SystemProcedure.SetLabelCaption(this);

			//''Asssign Earnings Details Grid
			SystemGrid.DefineSystemVoucherGrid(grdLeaveAmountDetails, false, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 1.47f, 1.4f, "&HBBC8CA", "&HBBC8CA");

			SystemGrid.DefineSystemVoucherGridColumn(grdLeaveAmountDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdLeaveAmountDetails, "Contract_End_Date", 1475, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLeaveAmountDetails, "Leave_Balance", 1225, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLeaveAmountDetails, "Leave_Taken_Days", 1225, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLeaveAmountDetails, "Leave_Salary", 1225, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLeaveAmountDetails, "Leave_Days_Taken", 1225, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLeaveAmountDetails, "Leave_Amount", 1300, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);

			DefineVoucherArray(-1, false);
			AssignGridLineNumbers();
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdLeaveAmountDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdLeaveAmountDetails.setArray(aVoucherDetails);
			grdLeaveAmountDetails.Rebind(true);
			GetRecord(mSearchValue);

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

		private void GetRecord(object pSearchValue)
		{
			string mysql = "";
			int mCnt = 0;

			if (mLeaveCd == 0 && SystemProcedure2.IsItEmpty(mLeaveCd))
			{
				return;
			}
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			double mleaveDays = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode(" select dbo.payLeaveBalanceDays(" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue) + "," + mLeaveCd.ToString() + ",'" + mFromDate + "',3)"));
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			double mLeaveSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode(" select dbo.paygetLeavesalary(" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue) + "," + mLeaveCd.ToString() + ")"));

			if (mLeaveEntID > 0)
			{
				mysql = "select plecd.Leave_Days_Taken,plecd.Leave_Days_Amount,pecad.contract_end_date,pecad.leave_balance_days";
				mysql = mysql + " ,pecad.leave_taken_days,pecad.leave_salary ";
				if (mCalltype == 1)
				{ //For Leave
					mysql = mysql + " from Pay_Leave_Employee_Contract_Details plecd";
				}
				else if (mCalltype == 2)
				{  // Leave Adjustment
					mysql = mysql + " from Pay_Leave_Encash_Employee_Contract_Details plecd";
				}
				mysql = mysql + " left outer join  Pay_Employee_Contract_Accrual_Details pecad on plecd.Emp_Contract_Entry_Id = pecad.entry_id";
				mysql = mysql + " where " + ((mCalltype == 1) ? "plecd.leave_entry_id" : "plecd.adjustment_entry_id") + "=" + mLeaveEntID.ToString();
			}
			else
			{
				mysql = "select pecad.entry_id,pecad.contract_end_date,pecad.leave_balance_days,pecad.leave_taken_days,pecad.leave_salary";
				mysql = mysql + " ,isnull(plecd.Leave_Days_Taken,0) as Leave_Days_Taken ,isnull(plecd.Leave_Days_Amount,0) as Leave_Days_Amount";
				mysql = mysql + " from Pay_Employee_Contract_Accrual_Details pecad";
				if (mCalltype == 1)
				{ //For Leave
					mysql = mysql + " left outer join Pay_Leave_Employee_Contract_Details plecd on  pecad.entry_id = plecd.Emp_Contract_Entry_Id";
				}
				else if (mCalltype == 2)
				{  // Leave Adjustment
					mysql = mysql + " left outer join Pay_Leave_Encash_Employee_Contract_Details plecd on  pecad.entry_id = plecd.Emp_Contract_Entry_Id";
				}
				mysql = mysql + " where pecad.emp_cd = " + ReflectionHelper.GetPrimitiveValue<int>(pSearchValue).ToString();
				mysql = mysql + " union all";
				mysql = mysql + " select 0,'" + mFromDate + "'," + mleaveDays.ToString() + ",0," + mLeaveSalary.ToString() + ",0,0";
			}

			DataSet rs = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rs.Tables.Clear();
			adap.Fill(rs);
			aVoucherDetails.RedimXArray(new int[]{rs.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
			mCnt = 0;
			foreach (DataRow iteration_row in rs.Tables[0].Rows)
			{
				aVoucherDetails.SetValue((rs.Tables[0].Rows[0].IsNull("contract_end_date")) ? ((object) mFromDate) : iteration_row["contract_end_date"], mCnt, mContractEndDate);
				aVoucherDetails.SetValue((rs.Tables[0].Rows[0].IsNull("leave_balance_days")) ? ((object) mleaveDays) : iteration_row["leave_balance_days"], mCnt, mLeaveBalDays);
				aVoucherDetails.SetValue((rs.Tables[0].Rows[0].IsNull("leave_taken_days")) ? ((object) 0) : iteration_row["leave_taken_days"], mCnt, mLeaveTakenDays);
				aVoucherDetails.SetValue((rs.Tables[0].Rows[0].IsNull("leave_salary")) ? ((object) mLeaveSalary) : iteration_row["leave_salary"], mCnt, mLeaveSalaryC);
				aVoucherDetails.SetValue(iteration_row["Leave_Days_Taken"], mCnt, mLeaveDaysTake);
				aVoucherDetails.SetValue(iteration_row["Leave_Days_Amount"], mCnt, mLeaveAmount);
				mCnt++;
			}
			txtCommonNumber[2].Value = mPaidDays;
			AssignGridLineNumbers();
			grdLeaveAmountDetails.Rebind(true);
			grdLeaveAmountDetails.Refresh();
		}

		private void grdLeaveAmountDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			if (ColIndex == mLeaveDaysTake)
			{
				grdLeaveAmountDetails.UpdateData();
				CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdLeaveAmountDetails.Bookmark), ColIndex);
				grdLeaveAmountDetails.Refresh();
			}
		}

		private void CalculateTotals(int mRowNumber, int mColNumber)
		{
			int cnt = 0;

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			string mEmpNo = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select emp_no from pay_employee where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue)));
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			double mDaysInMonth = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select dbo.[payGetEmployeeWorkingHours](" + mEmpNo + ",'" + SystemHRProcedure.GetPayrollGenerateStartDate() + "',2)"));

			if (aVoucherDetails.GetLength(0) > 0)
			{
				if (mColNumber == mLeaveDaysTake)
				{
					grdLeaveAmountDetails.Columns[mLeaveAmount].Value = Math.Round((double) ((ReflectionHelper.GetPrimitiveValue<double>(grdLeaveAmountDetails.Columns[mLeaveSalaryC].Value) / mDaysInMonth) * ReflectionHelper.GetPrimitiveValue<double>(grdLeaveAmountDetails.Columns[mLeaveDaysTake].Value)), 3);
				}

			}
			grdLeaveAmountDetails.UpdateData();
			double mTotalAmount = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mTotalAmount += Conversion.Val(Convert.ToDouble(aVoucherDetails.GetValue(cnt, mLeaveAmount)).ToString());
			}


			if (mTotalAmount != 0)
			{
				grdLeaveAmountDetails.Columns[mLeaveAmount].FooterText = StringsHelper.Format(mTotalAmount, "###,###,###,###,##0.000");
			}
			else
			{
				grdLeaveAmountDetails.Columns[mLeaveAmount].FooterText = "";
			}
			grdLeaveAmountDetails.Refresh();
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}