
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayOvertimeEntry
		: System.Windows.Forms.Form
	{

		private XArrayHelper _aVoucherDetails = null;
		public frmPayOvertimeEntry()
{
InitializeComponent();
} 
 public  void frmPayOvertimeEntry_old()
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
		private string mSearchValue = "";
		
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
		private const int conDate = 1;
		private const int conNOT = 2;
		private const int conNAmt = 3;
		private const int conNEntID = 4;
		private const int conFOT = 5;
		private const int conFAmt = 6;
		private const int conFEntId = 7;
		private const int conHOT = 8;
		private const int conHAmt = 9;
		private const int conHEntId = 10;


		private const int conMaxColumns = 11;

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
		private bool mIsGridChanged = false;


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

				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.4f, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Date", 2500, false, SystemConstants.gDisableColumnBackColor);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Normal OT", 750, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount", 750, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "NLN", 750, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Friday OT", 750, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount", 750, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "FLN", 750, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Holiday OT", 750, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount", 750, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "HLN", 750, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

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
					MessageBox.Show("Please Insert Cut off value....", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}

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
		public void PrintReport()
		{

		}

		public void CloseForm()
		{
			this.Close();
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
					grdVoucherDetails.Columns[cnt].Text = "";
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

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			grdVoucherDetails.UpdateData();
			CalculateTotal();
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
					int mCurrentCellHrs = 0;

					mCol = grdVoucherDetails.Col;
					//UPGRADE_WARNING: (1068) grdVoucherDetails.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mRow = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark);

					mysql = "select pbt.bill_no from pay_ta_field ptf";
					mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = ptf.bill_cd";
					mysql = mysql + " where ta_field_id=" + ((mCol == 2) ? 5 : ((mCol == 5) ? 6 : 7)).ToString();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					if (ColIndex == conNOT)
					{
						// Normal OT
						grdVoucherDetails.Columns[conNAmt].Value = SystemHRProcedure.Rounding(((mBasicSalary) / (mDaysPerMonth * mHoursPerDay) * ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conNOT].Value)) * mNormalOTRate, ReflectionHelper.GetPrimitiveValue<int>(mReturnValue));
					}
					else if (ColIndex == conFOT)
					{ 
						// Friday OT
						grdVoucherDetails.Columns[conFAmt].Value = SystemHRProcedure.Rounding(((mBasicSalary) / (mDaysPerMonth * mHoursPerDay) * ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conFOT].Value)) * mFridayOTRate, ReflectionHelper.GetPrimitiveValue<int>(mReturnValue));
					}
					else if (ColIndex == conHOT)
					{ 
						// Holiday OT
						grdVoucherDetails.Columns[conHAmt].Value = SystemHRProcedure.Rounding(((mBasicSalary) / (mDaysPerMonth * mHoursPerDay) * ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[conHOT].Value)) * mHolidayOTRate, ReflectionHelper.GetPrimitiveValue<int>(mReturnValue));
					}

					grdVoucherDetails.Refresh();
					return;
				}
				catch
				{
					MessageBox.Show("Please Define Billing Code.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		private void CalculateTotal()
		{
			try
			{
				int mColCnt = 0;
				int mRowCnt = 0;
				double mTotal = 0;
				int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
				for (mColCnt = 0; mColCnt <= tempForEndVar; mColCnt++)
				{
					mTotal = 0;
					if (mColCnt != 0 && mColCnt != 1 && mColCnt != 4 && mColCnt != 7 && mColCnt != 10)
					{
						int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
						for (mRowCnt = 0; mRowCnt <= tempForEndVar2; mRowCnt++)
						{
							mTotal += Convert.ToDouble(aVoucherDetails.GetValue(mRowCnt, mColCnt));
						}
						grdVoucherDetails.Columns[mColCnt].FooterText = mTotal.ToString();
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdVoucherDetails.Splits[0].DisplayColumns[mColCnt].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdVoucherDetails.Splits[0].DisplayColumns[mColCnt].FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
					}
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == conNAmt || ColIndex == conFAmt || ColIndex == conHAmt)
			{
				Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###,###,##0.000");
			}
		}

		public void FindRoutine(string pObjectName)
		{
			if (pObjectName == "txtEmployeeCode")
			{
				txtEmployeeCode_DropButtonClick(txtEmployeeCode, null);
			}
		}

		private void txtEmployeeCode_DropButtonClick(Object Sender, EventArgs e)
		{
			txtEmployeeCode.Text = "";
			string mSQL = " pay_emp.status_cd Not IN (3,4) and pay_emp.allow_overtime = 1 ";
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
			string mysql = "";
			object mTempValue = null;
			if (!SystemProcedure2.IsItEmpty(txtEmployeeCode.Text, SystemVariables.DataType.StringType))
			{
				mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name" : "a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name");
				mysql = mysql + " , emp_cd ";
				mysql = mysql + " , pemp.basic_salary, pemp.total_salary, pemp.normal_ot, pemp.friday_ot, pemp.holiday_ot, pemp.allow_overtime, pemp.hours_per_day ";
				mysql = mysql + " , pemp.rate_calc_method_id, pemp.days_per_month, pemp.weekend_day1_id, pemp.weekend_day2_id, pemp.rate_per_hour ";
				mysql = mysql + " from pay_employee pemp , pay_department pdept, pay_designation pdesg ";
				mysql = mysql + " where ";
				mysql = mysql + " pemp.dept_cd = pdept.dept_cd and pemp.desg_cd = pdesg.desg_cd ";
				mysql = mysql + " and pemp.emp_no ='" + txtEmployeeCode.Text + "'";

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
					txtEmployeeCode.Text = "";
					txtEmployeeCode.Focus();
					return;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDisplayLabel[ConDlblEmployeeName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
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

			FillGridData();
			grdVoucherDetails.Focus();
		}

		private void FillGridData()
		{
			if (txtEmployeeCode.Text == "")
			{
				return;
			}

			GetSQL(5);
			GetSQL(6);
			GetSQL(7);

			AssignGridLineNumbers();
			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Refresh();
			Application.DoEvents();
			mIsGridChanged = false;
		}

		public object GetSQL(int mTafieldid)
		{

			string mSQL = " select line_no,";
			mSQL = mSQL + "  hrs, amount, pttd.pay_date";
			mSQL = mSQL + " from pay_ta_trans ptt ";
			mSQL = mSQL + " inner join pay_employee pemp on pemp.emp_cd = ptt.emp_cd ";
			mSQL = mSQL + " inner join pay_ta_field ptf on ptt.tafield_id = ptf.ta_field_id ";
			mSQL = mSQL + " inner join pay_ta_trans_detail pttd on pttd.entry_id = ptt.entry_id";
			mSQL = mSQL + " where ptt.is_pay_closed = 0 ";
			mSQL = mSQL + " and pemp.emp_no  = '" + txtEmployeeCode.Text + "'";
			mSQL = mSQL + " and ptf.ta_field_id =" + mTafieldid.ToString() + " order by pttd.pay_date";

			DataSet rsLocal = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mSQL, SystemVariables.gConn);
			rsLocal.Tables.Clear();
			adap.Fill(rsLocal);
			int cnt = 0;
			aVoucherDetails.RedimXArray(new int[]{rsLocal.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
			foreach (DataRow iteration_row in rsLocal.Tables[0].Rows)
			{
				aVoucherDetails.SetValue(iteration_row["pay_date"], cnt, conDate);
				if (mTafieldid == 5)
				{
					aVoucherDetails.SetValue(iteration_row["line_no"], cnt, conNEntID);
					aVoucherDetails.SetValue(iteration_row["amount"], cnt, conNAmt);
					aVoucherDetails.SetValue(iteration_row["hrs"], cnt, conNOT);
				}
				else if (mTafieldid == 6)
				{ 
					aVoucherDetails.SetValue(iteration_row["line_no"], cnt, conFEntId);
					aVoucherDetails.SetValue(iteration_row["amount"], cnt, conFAmt);
					aVoucherDetails.SetValue(iteration_row["hrs"], cnt, conFOT);
				}
				else if (mTafieldid == 7)
				{ 
					aVoucherDetails.SetValue(iteration_row["line_no"], cnt, conHEntId);
					aVoucherDetails.SetValue(iteration_row["amount"], cnt, conHAmt);
					aVoucherDetails.SetValue(iteration_row["hrs"], cnt, conHOT);
				}
				cnt++;
			}
			return null;
		}

		public bool saveRecord(bool pApprove = false)
		{
			bool result = false;
			StringBuilder mysql = new StringBuilder();
			int cnt = 0;
			try
			{

				SystemVariables.gConn.BeginTransaction();

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					mysql = new StringBuilder(" update pay_ta_trans_detail set hrs = " + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, conNOT))).ToString());
					mysql.Append(", amount = " + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, conNAmt))).ToString());
					mysql.Append(", affect_payroll = 1");
					mysql.Append(" where line_no = " + Convert.ToString(aVoucherDetails.GetValue(cnt, conNEntID)));
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql.ToString();
					TempCommand.ExecuteNonQuery();

					mysql = new StringBuilder(" update pay_ta_trans_detail set hrs = " + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, conFOT))).ToString());
					mysql.Append(", amount = " + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, conFAmt))).ToString());
					mysql.Append(", affect_payroll = 1");
					mysql.Append(" where line_no = " + Convert.ToString(aVoucherDetails.GetValue(cnt, conFEntId)));
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql.ToString();
					TempCommand_2.ExecuteNonQuery();

					mysql = new StringBuilder(" update pay_ta_trans_detail set hrs = " + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, conHOT))).ToString());
					mysql.Append(", amount = " + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, conHAmt))).ToString());
					mysql.Append(", affect_payroll = 1");
					mysql.Append(" where line_no = " + Convert.ToString(aVoucherDetails.GetValue(cnt, conHEntId)));
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql.ToString();
					TempCommand_3.ExecuteNonQuery();

				}

				SystemHRProcedure.ClearPayroll(SystemHRProcedure.GetPayrollGenerateDate(), txtEmployeeCode.Text, txtEmployeeCode.Text);
				SystemHRProcedure.GeneratePayrollEntry(SystemHRProcedure.GetPayrollGenerateDate(), txtEmployeeCode.Text, txtEmployeeCode.Text);
				SystemHRProcedure.GenerateLeaveEntry(SystemHRProcedure.GetPayrollGenerateDate(), txtEmployeeCode.Text, txtEmployeeCode.Text);
				SystemHRProcedure.GenerateLoanEntry(SystemHRProcedure.GetPayrollGenerateDate(), txtEmployeeCode.Text, txtEmployeeCode.Text);

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				//saveRecord = True
				mIsGridChanged = false;
				return true;
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
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}