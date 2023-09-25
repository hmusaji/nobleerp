
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers;



namespace Xtreme
{
	internal partial class frmPayImportAtten
		: System.Windows.Forms.Form
	{

		public frmPayImportAtten()
{
InitializeComponent();
} 
 public  void frmPayImportAtten_old()
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
			
			InitExtendedProperties();
		}
		void InitExtendedProperties()
		{
			this.grdMigrate2.setScrollTips(false);
		}


		private void frmPayImportAtten_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		 //This class checks for the rights given to the user
		private XArrayHelper _TableArray = null;
		private XArrayHelper TableArray
		{
			get
			{
				if (_TableArray is null)
				{
					_TableArray = new XArrayHelper();
				}
				return _TableArray;
			}
			set
			{
				_TableArray = value;
			}
		}

		private XArrayHelper _FieldArray = null;
		private XArrayHelper FieldArray
		{
			get
			{
				if (_FieldArray is null)
				{
					_FieldArray = new XArrayHelper();
				}
				return _FieldArray;
			}
			set
			{
				_FieldArray = value;
			}
		}


		//Constants for Sys_Migrate_Table
		private const int Table_Id = 0;
		private const int LTableName = 1;
		private const int ATableName = 2;
		private const int TableComments = 3;
		private const int TableName = 4;



		public int ThisFormId
		{
			get
			{
				object mThisFormID = null;
				return ReflectionHelper.GetPrimitiveValue<int>(mThisFormID);
			}
			set
			{
				int mThisFormID = value;
			}
		}


		private void btnLoadGrid_Click(Object eventSender, EventArgs eventArgs)
		{
			clsHourGlass mHourGlass = null;
			try
			{
				mHourGlass = null;
				int ImportType = 0;
				int i = 0;
				int j = 0;

				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				ImportType = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Import_TimeAttendance_Format"));

				grdMigrate2.Cols.Fixed = 1;
				grdMigrate2.Rows.Fixed = 1;
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				CommonDialog1Open.FileName = "";
				//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property CommonDialog1.Flags was upgraded to CommonDialog1Open.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
				//UPGRADE_WARNING: (2074) FileOpenConstants STRING RESOURCE ["IDS-CONSTANT"] NOT FOUND FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
				CommonDialog1Open.ShowReadOnly = false;
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				CommonDialog1Open.Filter = "Text (*.txt)|*.txt|Excel (*.xls)|*.xls";
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FilterIndex was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				CommonDialog1Open.FilterIndex = 2;
				CommonDialog1Open.ShowDialog();


				mHourGlass = new clsHourGlass();

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (CommonDialog1Open.FileName != "")
				{
					//UPGRADE_ISSUE: (2064) VSFlex8.SaveLoadSettings property SaveLoadSettings.flexFileExcel was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid method grdMigrate2.LoadGrid was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdMigrate2.LoadGrid(CommonDialog1Open.FileName, UpgradeStubs.VSFlex8_SaveLoadSettings.getflexFileExcel(), null);
				}
				else
				{
					return;
				}
				grdMigrate2.Rows.Fixed = 1;
				GenerateSRNO();
				grdMigrate2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;

				j = 3;
				while (Information.IsDate(StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(grdMigrate2.getCellText(1, j)), SystemVariables.gSystemDateFormat)) && grdMigrate2.Cols.Count - 1 > j)
				{
					grdMigrate2.setCellText(StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(grdMigrate2.getCellText(1, j)), SystemVariables.gSystemDateFormat), 1, j);
					j++;
				}
				if (optDownloadFormat[0].Checked)
				{
					if (ImportType == 2)
					{
						grdMigrate2.setCellText("EmpNo", 1, 1);
						grdMigrate2.setCellText("ProjectNo", 1, 2);
					}
					else if (ImportType == 3)
					{ 
						//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdMigrate2.FormatString was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						grdMigrate2.setFormatString("SerialNo|EmpNo|Name|Date");
						int tempForEndVar = grdMigrate2.Rows.Count - 1;
						for (i = 2; i <= tempForEndVar; i++)
						{
							grdMigrate2.setCellText(DateTimeHelper.ToString(ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, 3))), i, 3);
						}
					}
				}
				else if (optDownloadFormat[1].Checked || optDownloadFormat[2].Checked)
				{ 
					//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdMigrate2.FormatString was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdMigrate2.setFormatString("SerialNo|EmpNo|Name|NormalOT|FridayOT|HolidayOT|ProjectNo");
				}

				mHourGlass = null;
			}
			catch (System.Exception excep)
			{
				mHourGlass = null;
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void GenerateSRNO()
		{
			clsHourGlass mHourGlass = new clsHourGlass();
			int i = 0;
			grdMigrate2.Cols[0].WidthDisplay = 53;

			int tempForEndVar = grdMigrate2.Rows.Count - 1;
			for (i = 1; i <= tempForEndVar; i++)
			{
				grdMigrate2.setCellText(i.ToString(), i, 0);
			}
		}


		private void btnDeleteLine_Click(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int i = 0;
				int LastRow = grdMigrate2.RowSel;
				//grdMigrate2.RemoveItem (grdMigrate2.RowSel)
				int tempForEndVar = grdMigrate2.RowSel;
				for (i = grdMigrate2.Row; i <= tempForEndVar; i++)
				{
					grdMigrate2.RemoveItem(LastRow);
					LastRow--;
				}
				GenerateSRNO();
				//Call GridResize(, True)
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void cmdMigrate_Click(Object eventSender, EventArgs eventArgs)
		{
			int ImportType = 0;

			if (MessageBox.Show("You are going to Import Attendance!", "Importing...", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
			{
				if (!optDownloadFormat[0].Checked && !optDownloadFormat[1].Checked && !optDownloadFormat[2].Checked && !optDownloadFormat[3].Checked)
				{
					MessageBox.Show("Please select a imort format !", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				if (optDownloadFormat[0].Checked)
				{
					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					ImportType = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Import_TimeAttendance_Format"));
					if (ImportType == 1)
					{ //CeaserPac
						cmdVerify_Click(cmdVerify, new EventArgs());
						if (!UpdateAbsentHrs())
						{
							MessageBox.Show("Please Check Late Hours and try again!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
						if (!UpdateOvertime())
						{
							MessageBox.Show("Please Check OT Hours and try again!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
					}
					else if (ImportType == 2)
					{  //IMCO,UES
						//Call UpdateAbsentHrs_Method2
						if (SystemProcedure2.IsItEmpty(txtErrorFilePAth.Text, SystemVariables.DataType.StringType))
						{
							MessageBox.Show("Please Define Error File Path!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
						UpdateAbbreviationHrs_Method2();
					}
					else if (ImportType == 3)
					{  //AGT
						UpdateAbsentHrsMethod3();
					}
					else if (ImportType == 4)
					{  //GreenField , Hajary
						SystemHRProcedure.UpdateAttendanceFromProjectTable();
					}
					else if (ImportType == 5)
					{  //SHBC
						UpdateAbsentHrsMethod5();
					}
					else if (ImportType == 6)
					{  //ASMACS
						UpdateTAMethod6();
					}
				}
				else if (optDownloadFormat[1].Checked)
				{ 
					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					ImportType = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Import_Overtime_Payroll_Format"));
					if (ImportType == 1)
					{
						if (SystemProcedure2.IsItEmpty(txtErrorFilePAth.Text, SystemVariables.DataType.StringType))
						{
							MessageBox.Show("Please Define Error File Path!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
						UpdateOT_Method3();
					}
				}
				else if (optDownloadFormat[2].Checked)
				{ 
					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					ImportType = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Import_Overtime_Project_Format"));
					if (ImportType == 1)
					{
						if (SystemProcedure2.IsItEmpty(txtErrorFilePAth.Text, SystemVariables.DataType.StringType))
						{
							MessageBox.Show("Please Define Error File Path!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
						UpdateOT_Project_Details();
					}
				}
				else if (optDownloadFormat[3].Checked)
				{ 
					UpdateApprovedTA();
				}

				if (!optDownloadFormat[2].Checked)
				{
					SystemHRProcedure.ClearPayroll(SystemHRProcedure.GetPayrollGenerateDate(), "", "", false);
					SystemHRProcedure.GeneratePayrollEntry(SystemHRProcedure.GetPayrollGenerateDate(), "", "");
					SystemHRProcedure.GenerateLeaveEntry(SystemHRProcedure.GetPayrollGenerateDate(), "", "");
					SystemHRProcedure.GenerateLoanEntry(SystemHRProcedure.GetPayrollGenerateDate(), "", "");
				}

				MessageBox.Show("Attendance Import Successfully!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
		}

		private void cmdVerify_Click(Object eventSender, EventArgs eventArgs)
		{
			int i = 0;
			int tempForEndVar = grdMigrate2.Rows.Count - 1;
			for (i = 6; i <= tempForEndVar; i++)
			{
				if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 3)) == "")
				{
					MessageBox.Show("Employee Code cannot be blank in SRNO." + i.ToString() + "!", "Importing Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 4)) == "")
				{
					grdMigrate2.setCellText("0:00", i, 4);
				}
				if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 5)) == "")
				{
					grdMigrate2.setCellText("0:00", i, 5);
				}
				if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 6)) == "")
				{
					grdMigrate2.setCellText("0:00", i, 6);
				}
			}
		}

		public bool UpdateAbsentHrs()
		{
			bool result = false;
			try
			{
				int i = 0;
				string mdate = "";
				int mAbsEntID = 0;
				int mWrkEntID = 0;
				int mEmpCd = 0;
				double mEmpPerDayHrs = 0;
				StringBuilder mErrorIn = new StringBuilder();
				double mHours = 0;
				string mFileName = "";
				string mProjectNotExist = "";

				mErrorIn = new StringBuilder("");
				lblmsg.Text = "Updating Record No......";

				mFileName = txtErrorFilePAth.Text;
				FileSystem.FileClose(1);
				FileSystem.FileOpen(1, mFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);

				int tempForEndVar = grdMigrate2.Rows.Count - 1;
				for (i = 1; i <= tempForEndVar; i++)
				{
					mEmpCd = SystemHRProcedure.GetEmpCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 3)));
					if (mEmpCd > 0)
					{
						mEmpPerDayHrs = SystemHRProcedure.GetEmpPerDayHours(mEmpCd);
						mdate = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(grdMigrate2.getCellText(i, 2)), SystemVariables.gSystemDateFormat);
						if (DateAndTime.Hour(ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, 5))) > 0 || (ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, 5)).Minute / 60d) > 0)
						{
							mHours = DateAndTime.Hour(ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, 5))) + (ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, 5)).Minute / 60d);
							if (!GetEmpDayType(mEmpCd, mdate, SystemHRProcedure.enumTAFields.eTAWeekend))
							{
								if (!GetEmpDayType(mEmpCd, mdate, SystemHRProcedure.enumTAFields.eTAPublicHoliday))
								{
									mAbsEntID = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTAAbsentHours, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
									mWrkEntID = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
									if (mEmpPerDayHrs <= mHours)
									{
										SystemHRProcedure.UpdateAttendanceFieldsHours(mdate, mdate, mAbsEntID, mEmpPerDayHrs, false);
										SystemHRProcedure.UpdateAttendanceFieldsHours(mdate, mdate, mWrkEntID, 0, false);
									}
									else
									{
										SystemHRProcedure.UpdateAttendanceFieldsHours(mdate, mdate, mAbsEntID, mHours, false);
										SystemHRProcedure.UpdateAttendanceFieldsHours(mdate, mdate, mWrkEntID, mEmpPerDayHrs - mHours, false);
									}
								}
							}
						}
					}
					else
					{
						mErrorIn.Append(i.ToString() + ",");
						mProjectNotExist = "Employee No:" + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 3)) + " is Not Available.Line No.:-" + i.ToString();
						FileSystem.PrintLine(1, mProjectNotExist);
					}
					Application.DoEvents();
					lblmsg.Text = lblmsg.Text + ".";
					lblmsg.Text = "Updating Record No......" + i.ToString();
				}

				FileSystem.FileClose(1);
				lblmsg.Text = "";
				return true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
				lblmsg.Text = "";
			}
			return result;
		}

		public bool UpdateOvertime()
		{
			bool result = false;
			try
			{
				int i = 0;
				string mdate = "";
				int mFOTEntId = 0, mNOTEntId = 0, mHOTEntId = 0;
				int mEmpCd = 0;
				double mEmpPerDayHrs = 0;
				StringBuilder mErrorIn = new StringBuilder();
				double mHours = 0;
				string mSQL = "";
				int mDaysPerMonth = 0;
				double mOvertimeSalary = 0;
				object mReturnValue = null;
				int mOTBillCd = 0;
				double mAmt = 0;
				int mOvertimeFormat = 0;
				string mFileName = "";
				string mProjectNotExist = "";
				int mOvertimeWorkingDays = 0;

				mErrorIn = new StringBuilder("");
				lblmsg.Text = "Updating OT.";
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mOvertimeFormat = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Overtime_Format"));

				mFileName = txtErrorFilePAth.Text.Substring(0, Math.Min(Strings.Len(txtErrorFilePAth.Text) - 4, txtErrorFilePAth.Text.Length));
				mFileName = mFileName + "OT.txt";
				FileSystem.FileClose(1);
				FileSystem.FileOpen(1, mFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);

				int tempForEndVar = grdMigrate2.Rows.Count - 1;
				for (i = 1; i <= tempForEndVar; i++)
				{
					mEmpCd = SystemHRProcedure.GetEmpCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 3)));
					mSQL = " select basic_salary, normal_ot, friday_ot, holiday_ot,  allow_overtime, hours_per_day";
					mSQL = mSQL + " , rate_calc_method_id, days_per_month, weekend_day1_id, weekend_day2_id ,Overtime_Working_Days";
					mSQL = mSQL + " from pay_employee";
					if (mEmpCd > 0)
					{
						mdate = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(grdMigrate2.getCellText(i, 2)), SystemVariables.gSystemDateFormat);
						if (DateAndTime.Hour(ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, 6))) > 0 || ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, 6)).Minute > 0)
						{
							mSQL = mSQL + " where emp_cd=" + mEmpCd.ToString();
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
							mOvertimeWorkingDays = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(10));
							if (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(4)))
							{ //For Check this employee is entitle for overtime or not
								mHours = DateAndTime.Hour(ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, 6))) + (ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, 6)).Minute / 60d);
								if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(6)) == SystemHRProcedure.gFixedDays)
								{ //if fixed days
									//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mDaysPerMonth = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(7)); //Calculate Working Days in Month
								}
								else if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(6)) == SystemHRProcedure.gActualDays)
								{ 
									mDaysPerMonth = Convert.ToInt32(SystemHRProcedure.CalculateDays(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()), DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(8)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(9)))); //Calculate Working Days in Month
								}
								//If GetSystemPreferenceSetting("Overtime_Working_Days") <> 0 Then
								if (mOvertimeWorkingDays != 0)
								{
									mDaysPerMonth = Convert.ToInt32(mOvertimeWorkingDays * mEmpPerDayHrs);
								}
								mAmt = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0)) / (mDaysPerMonth * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(6)));
								if (!GetEmpDayType(mEmpCd, mdate, SystemHRProcedure.enumTAFields.eTAWeekend))
								{
									if (!GetEmpDayType(mEmpCd, mdate, SystemHRProcedure.enumTAFields.eTAPublicHoliday))
									{
										//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
										mOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_cd from pay_ta_field ptf inner join pay_billing_type pbt on pbt.bill_cd = ptf.bill_cd where ptf.ta_field_id=5"));
										mNOTEntId = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTANormalOT, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
										SystemHRProcedure.UpdateAttendanceFieldsHours(mdate, mdate, mNOTEntId, mHours, false);
										//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
										mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode(" select dbo.paygetovertimesalary(" + mEmpCd.ToString() + "," + mOTBillCd.ToString() + ")"));
										if (mOvertimeFormat == 1)
										{
											mAmt = mOvertimeSalary / (mDaysPerMonth * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)));
										}
										else
										{
											mAmt = (mOvertimeSalary * 12) / (365 * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)));
										}
										mAmt = SystemHRProcedure.Rounding(mAmt * mHours * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1)), ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_no from pay_billing_type pbt where pbt.bill_cd=" + mOTBillCd.ToString())));
										UpdateAttendanceOTAmt(mdate, mdate, mNOTEntId, mAmt);
									}
									else
									{
										//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
										mOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_cd from pay_ta_field ptf inner join pay_billing_type pbt on pbt.bill_cd = ptf.bill_cd where ptf.ta_field_id=7"));
										mHOTEntId = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTAHolidayOT, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
										SystemHRProcedure.UpdateAttendanceFieldsHours(mdate, mdate, mHOTEntId, mHours, false);
										//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
										mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode(" select dbo.paygetovertimesalary(" + mEmpCd.ToString() + "," + mOTBillCd.ToString() + ")"));
										if (mOvertimeFormat == 1)
										{
											mAmt = mOvertimeSalary / (mDaysPerMonth * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)));
										}
										else
										{
											mAmt = (mOvertimeSalary * 12) / (365 * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)));
										}
										mAmt = SystemHRProcedure.Rounding(mAmt * mHours * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3)), ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_no from pay_billing_type pbt where pbt.bill_cd=" + mOTBillCd.ToString())));
										UpdateAttendanceOTAmt(mdate, mdate, mHOTEntId, mAmt);
									}
								}
								else
								{
									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_cd from pay_ta_field ptf inner join pay_billing_type pbt on pbt.bill_cd = ptf.bill_cd where ptf.ta_field_id=6"));
									mFOTEntId = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTAFridayOT, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
									SystemHRProcedure.UpdateAttendanceFieldsHours(mdate, mdate, mFOTEntId, mHours, false);
									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode(" select dbo.paygetovertimesalary(" + mEmpCd.ToString() + "," + mOTBillCd.ToString() + ")"));
									if (mOvertimeFormat == 1)
									{
										mAmt = mOvertimeSalary / (mDaysPerMonth * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)));
									}
									else
									{
										mAmt = (mOvertimeSalary * 12) / (365 * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)));
									}
									mAmt = SystemHRProcedure.Rounding(mAmt * mHours * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2)), ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_no from pay_billing_type pbt where pbt.bill_cd=" + mOTBillCd.ToString())));
									UpdateAttendanceOTAmt(mdate, mdate, mFOTEntId, mAmt);
								}
							}
						}
					}
					else
					{
						mErrorIn.Append(i.ToString() + ",");
						mProjectNotExist = "Employee No:" + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 3)) + " is Not Available.Line No.:-" + i.ToString();
						FileSystem.PrintLine(1, mProjectNotExist);
					}
					Application.DoEvents();
					lblmsg.Text = "Updateing OT Record.........." + i.ToString();
				}
				lblmsg.Text = "";
				result = true;
				FileSystem.FileClose(1);
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
				lblmsg.Text = "";
			}
			return result;
		}


		public bool GetEmpDayType(int pEmpCd, string pDay, SystemHRProcedure.enumTAFields pTafield)
		{

			string mSQL = "select pttd.hrs";
			mSQL = mSQL + " from pay_ta_trans_detail pttd";
			mSQL = mSQL + " inner join pay_ta_trans ptt on ptt.entry_id = pttd.entry_id";
			mSQL = mSQL + " Where ptt.emp_cd =" + pEmpCd.ToString();
			mSQL = mSQL + " and pttd.pay_date ='" + pDay + "'";
			mSQL = mSQL + " and ptt.pay_year =" + DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year.ToString();
			//mSql = mSql & " "
			mSQL = mSQL + " and ptt.pay_month =" + DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month.ToString();
			mSQL = mSQL + " and ptt.tafield_id=" + ((int) pTafield).ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				return ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == 1;
			}
			else
			{
				return false;
			}
		}



		public bool UpdateAttendanceOTAmt(string pStartDate, string pEndDate, int pEntryId, double pAmt)
		{
			bool result = false;
			try
			{
				string mysql = "";
				object mReturnValue = null;

				mysql = " update pay_ta_trans_detail ";
				mysql = mysql + " set Amount= Amount + " + pAmt.ToString() + ", affect_payroll = 1 ";
				mysql = mysql + " where entry_id =" + pEntryId.ToString();
				mysql = mysql + " and pay_date >='" + StringsHelper.Format(pStartDate, SystemVariables.gSystemDateFormat) + "'";
				mysql = mysql + " and pay_date <='" + StringsHelper.Format(pEndDate, SystemVariables.gSystemDateFormat) + "'";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				return true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
			}
			return result;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("Import_TimeAttendance_Format")) == 4)
			{
				btnLoadGrid.Visible = false;
				lblerrorpath.Visible = false;
				txtErrorFilePAth.Visible = false;
				grdMigrate2.Enabled = false;
				optDownloadFormat[1].Visible = false;
				optDownloadFormat[2].Visible = false;
				chkIncludeLeaveEmployee.Visible = false;
			}
			if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("Import_TimeAttendance_Format")) == 6)
			{
				lblDate.Visible = true;
				txtDate.Visible = true;
				optDownloadFormat[1].Visible = false;
				optDownloadFormat[2].Visible = false;
				optDownloadFormat[3].Visible = true;
				chkIncludeLeaveEmployee.Visible = true;
				txtDate.Value = SystemHRProcedure.GetPayrollGenerateStartDate();
			}
			txtErrorFilePAth.Text = "C:\\ErrorFilePath_" + DateAndTime.Day(DateTime.Today).ToString() + "_" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(DateTime.Today.Month) + DateAndTime.Hour(DateTime.Now).ToString() + DateTime.Now.Minute.ToString() + ".txt";
			grdMigrate2.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			grdMigrate2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			grdMigrate2.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
		}

		public bool UpdateAbsentHrs_Method2()
		{
			bool result = false;
			try
			{
				int i = 0;
				int j = 0;
				string mdate = "";
				int mAbsEntID = 0;
				int mWrkEntID = 0;
				int mDeductionEntID = 0;
				int mEmpCd = 0;
				double mEmpPerDayHrs = 0;
				StringBuilder mErrorIn = new StringBuilder();
				double mHours = 0;
				string mGenerateDate = "";
				int mTotalDeductionHrs = 0;
				object mReturnValue = null;

				mErrorIn = new StringBuilder("");
				lblmsg.Text = "Updating.";
				mGenerateDate = StringsHelper.Format(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddDays(-1), SystemVariables.gSystemDateFormat);
				int tempForEndVar = grdMigrate2.Rows.Count - 1;
				for (i = 2; i <= tempForEndVar; i++)
				{
					mEmpCd = SystemHRProcedure.GetEmpCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)));
					if (mEmpCd > 0)
					{
						mEmpPerDayHrs = SystemHRProcedure.GetEmpPerDayHours(mEmpCd);
						j = 3;
						while (Information.IsDate(StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(grdMigrate2.getCellText(1, j)), SystemVariables.gSystemDateFormat)) && grdMigrate2.Cols.Count - 1 > j)
						{ //j = 2 To 16
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select weekend_day1_id,weekend_day2_id,hours_per_day,status_cd from pay_employee where emp_cd =" + mEmpCd.ToString()));
							mdate = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(grdMigrate2.getCellText(1, j)), SystemVariables.gSystemDateFormat);
							if (!(ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3)) == 3 || ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3)) == 4))
							{
								if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, j))) < mEmpPerDayHrs && Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, j))) > 0)
								{
									mHours = DateAndTime.Hour(ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, j))) + (ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, j)).Minute / 60d);
									//mAbsEntID = GetTAEntryID(mEmpCd, eTAAbsentHours, Year(CDate(mGenerateDate)), Month(CDate(mGenerateDate)))
									//mWrkEntID = GetTAEntryID(mEmpCd, eTAWorkHours, Year(CDate(mGenerateDate)), Month(CDate(mGenerateDate)))
									mDeductionEntID = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTADeductionHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
									mTotalDeductionHrs = Convert.ToInt32(SystemHRProcedure.CalculateDays(DateTime.Parse(mdate), DateTime.Parse(mdate), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1))) * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2)));
									if (mEmpPerDayHrs > mHours)
									{
										//Call UpdateAttendanceFieldsHours(mdate, mdate, mAbsEntID, (mEmpPerDayHrs - mHours), False)
										//Call UpdateAttendanceFieldsHours(mdate, mdate, mWrkEntID, (mEmpPerDayHrs - mHours), False)
										if (mTotalDeductionHrs > 0)
										{
											mTotalDeductionHrs = Convert.ToInt32(mEmpPerDayHrs - mHours);
										}
										else
										{
											mTotalDeductionHrs = 0;
										}
										SystemHRProcedure.UpdateAttendanceFieldsHours(mdate, mdate, mDeductionEntID, mEmpPerDayHrs - mHours, false);
										SystemHRProcedure.UpdateDeductionHrsMaster(mTotalDeductionHrs, mEmpCd);
									}
								}
							}

							j++;
						}
					}
					else
					{
						mErrorIn.Append(i.ToString() + ",");
					}
					lblmsg.Text = lblmsg.Text + ".";
					if (i % 50 == 0)
					{
						lblmsg.Text = "Updating.";
					}
				}
				lblmsg.Text = "";
				//If Len(mErrorIn) > 0 Then
				//    MsgBox "Not Updated Line " & mErrorIn, vbInformation
				//End If
				return true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
				lblmsg.Text = "";
			}
			return result;
		}

		public bool UpdateAbbreviationHrs_Method2()
		{
			bool result = false;
			string mProjectNotExist = "";
			try
			{
				int i = 0;
				int j = 0;
				string mdate = "";
				int mLeaveEntID = 0;
				int mSickLeavEntID = 0;
				int mWrkEntID = 0;
				int mAbsEntID = 0;
				int mWeekendEntID = 0;
				int mHolidayEntId = 0;
				int mEmpCd = 0;
				double mEmpPerDayHrs = 0;
				StringBuilder mErrorIn = new StringBuilder();
				double mHours = 0;
				string mValue = "";
				double mLeave = 0;
				double mSick = 0;
				double mAbsent = 0;
				double mDeductionHrs = 0;
				int mDeductionHrsEntID = 0;
				double mLastMnthEarnHrs = 0;
				int mLastMnthEarnEntID = 0;
				double mHoliday = 0;
				int mProjectcd = 0;
				string mGenerateDate = "";
				int mTotalDeductionHrs = 0;
				string mStartDate = "";
				object mReturnValue = null;
				string mFileName = "";

				mProjectNotExist = " ";
				mErrorIn = new StringBuilder("");
				lblmsg.Text = "Updating Record No...";
				mFileName = txtErrorFilePAth.Text;
				FileSystem.FileClose(1);
				FileSystem.FileOpen(1, mFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
				int tempForEndVar = grdMigrate2.Rows.Count - 1;
				for (i = 1; i <= tempForEndVar; i++)
				{
					mProjectcd = 0;
					mEmpCd = SystemHRProcedure.GetEmpCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)));
					mProjectcd = GetProjectCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 2)));

					mLeave = 0;
					mSick = 0;
					mAbsent = 0;
					mHoliday = 0;
					if (mEmpCd > 0)
					{
						mEmpPerDayHrs = SystemHRProcedure.GetEmpPerDayHours(mEmpCd);
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select weekend_day1_id,weekend_day2_id,hours_per_day,status_cd from pay_employee where emp_cd =" + mEmpCd.ToString()));
						if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3)) == 3 || ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3)) == 4)
						{
							goto NextRecord;
						}
						j = 3;
						while (Information.IsDate(StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(grdMigrate2.getCellText(1, j)), SystemVariables.gSystemDateFormat)) && grdMigrate2.Cols.Count - 1 > j)
						{
							mdate = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(grdMigrate2.getCellText(1, j)), SystemVariables.gSystemDateFormat);
							mStartDate = DateTimeHelper.ToString(DateAndTime.DateSerial(DateTime.Parse(mdate).Year, DateTime.Parse(mdate).Month, 1));
							mGenerateDate = StringsHelper.Format(DateTime.Parse(mStartDate).AddMonths(1).AddDays(-1), SystemVariables.gSystemDateFormat);
							//UPGRADE_WARNING: (1068) grdMigrate2.Cell() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mValue = ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, j));
							mWrkEntID = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
							switch(mValue)
							{
								case "L" : 
									//                    mLeaveEntID = GetTAEntryID(mEmpCd, eTAVacationHours, Year(CDate(mGenerateDate)), Month(CDate(mGenerateDate))) 
									//                    Call UpdateAttendanceFieldsHours(mdate, mdate, mLeaveEntID, mEmpPerDayHrs, False) 
									//                    Call UpdateAttendanceFieldsHours(mdate, mdate, mWrkEntID, 0, False) 
									//                    mLeave = mLeave + mEmpPerDayHrs 
									break;
								case "S" : 
									//                    mSickLeavEntID = GetTAEntryID(mEmpCd, eTASickHours, Year(CDate(mGenerateDate)), Month(CDate(mGenerateDate))) 
									//                    Call UpdateAttendanceFieldsHours(mdate, mdate, mSickLeavEntID, mEmpPerDayHrs, False) 
									//                    Call UpdateAttendanceFieldsHours(mdate, mdate, mWrkEntID, 0, False) 
									//                    mSick = mSick + mEmpPerDayHrs 
									break;
								case "A" : 
									mAbsEntID = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTAAbsentHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month); 
									SystemHRProcedure.UpdateAttendanceFieldsHours(mdate, mdate, mAbsEntID, mEmpPerDayHrs, false); 
									if (DateTime.Parse(mdate) < DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()))
									{
										mDeductionHrsEntID = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTADeductionHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
										SystemHRProcedure.UpdateAttendanceFieldsHours(mdate, mdate, mDeductionHrsEntID, mEmpPerDayHrs, false);
										mTotalDeductionHrs = Convert.ToInt32(SystemHRProcedure.CalculateDays(DateTime.Parse(mdate), DateTime.Parse(mdate), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1))) * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2)));
										SystemHRProcedure.UpdateDeductionHrsMaster(mTotalDeductionHrs, mEmpCd);
									} 
									SystemHRProcedure.UpdateAttendanceFieldsHours(mdate, mdate, mWrkEntID, 0, false); 
									//mAbsent = mAbsent + mEmpPerDayHrs 
									break;
								case "F" : 
									//                    mWeekendEntID = GetTAEntryID(mEmpCd, eTAWeekend, Year(CDate(mGenerateDate)), Month(CDate(mGenerateDate))) 
									//                    Call UpdateAttendanceFieldsHours(mdate, mdate, mWeekendEntID, 1, False) 
									//                    Call UpdateAttendanceFieldsHours(mdate, mdate, mWrkEntID, 0, False) 
									break;
								case "H" : 
									//                    mHolidayEntId = GetTAEntryID(mEmpCd, eTAPublicHoliday, Year(CDate(mGenerateDate)), Month(CDate(mGenerateDate))) 
									//                    Call UpdateAttendanceFieldsHours(mdate, mdate, mHolidayEntId, 1, False) 
									//                    Call UpdateAttendanceFieldsHours(mdate, mdate, mWrkEntID, 0, False) 
									//                    mHoliday = mHoliday + mEmpPerDayHrs 
									break;
							}
							j++;
						}
						if (!SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(i, 2), SystemVariables.DataType.StringType))
						{
							if (mProjectcd == 0)
							{
								mProjectNotExist = "Project No:" + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 2)) + " is Not Available.Line No.:-" + i.ToString();
								FileSystem.PrintLine(1, mProjectNotExist);
								goto NextRecord;
							}
						}

						if (mProjectcd > 0)
						{
							AllocationProject(mGenerateDate, mProjectcd, mEmpCd);
						}
					}
					else
					{
						mErrorIn.Append(i.ToString() + ",");
						mProjectNotExist = "Employee No:" + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)) + " is Not Available.Line No.:-" + i.ToString();
						FileSystem.PrintLine(1, mProjectNotExist);
					}
					Application.DoEvents();
					lblmsg.Text = "Updating Record No......" + i.ToString();
					//If i Mod 50 = 0 Then lblmsg.Caption = "Updating Record No..."
					NextRecord:;

				}
				lblmsg.Text = "Update Done......";
				result = true;


				FileSystem.FileClose(1);
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
				lblmsg.Text = "";
			}

			return result;
		}


		public bool UpdateOT_Method3()
		{
			bool result = false;
			string mProjectNotExist = "";
			try
			{
				int i = 0;
				string mdate = "";
				StringBuilder mErrorIn = new StringBuilder();
				string mysql = "";
				int mNOTEntId = 0;
				int mFOTEntId = 0;
				int mHOTEntId = 0;
				int mEmpCd = 0;
				int mOTBillCd = 0;
				int mHrsPerMnt = 0;
				double mOTSalary = 0;
				double mHours = 0;
				double mNOT = 0;
				double mFOT = 0;
				double mHOT = 0;
				double mOTTotalAmt = 0;
				double mEmpPerDayHrs = 0;
				int mProjectcd = 0;
				int mOvertimeFormat = 0;
				string mFileName = "";
				double mDaysPerMonth = 0;
				bool mDailywages = false;
				object mReturnValue = null;
				int mOvertimeWorkingDays = 0;

				mErrorIn = new StringBuilder("");
				lblmsg.Text = "Updating....";
				mysql = "select bill_cd from pay_ta_field where ta_field_id =";
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mOvertimeFormat = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Overtime_Format"));

				if (SystemProcedure2.IsItEmpty(txtErrorFilePAth.Text, SystemVariables.DataType.StringType))
				{
					mFileName = "C:\\Attendance_" + DateAndTime.Day(DateTime.Today).ToString() + ".txt";
				}
				else
				{
					mFileName = txtErrorFilePAth.Text;
				}

				FileSystem.FileClose(1);
				FileSystem.FileOpen(1, mFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
				int tempForEndVar = grdMigrate2.Rows.Count - 1;
				for (i = 1; i <= tempForEndVar; i++)
				{
					if (chkIncludeLeaveEmployee.CheckState != CheckState.Unchecked)
					{
						mEmpCd = SystemHRProcedure.GetEmpCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)), "status_cd not in (2,3,4)");
					}
					else
					{
						mEmpCd = SystemHRProcedure.GetEmpCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)), "status_cd not in (3,4)");
					}
					mProjectcd = GetProjectCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 6)));
					if (mEmpCd > 0)
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select rate_calc_method_id, rate_per_hour,Overtime_Working_Days from pay_employee where emp_cd =" + mEmpCd.ToString()));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0)) == 130)
							{
								mDailywages = true;
								mOTSalary = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1));
							}
							else
							{
								mDailywages = false;
							}
							mOvertimeWorkingDays = Convert.ToInt32(Math.Floor(ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2))));
						}
						mEmpPerDayHrs = SystemHRProcedure.GetEmpPerDayHours(mEmpCd);
						if (mOvertimeFormat == 1)
						{
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mHrsPerMnt = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select dbo.[payGetEmployeeWorkingHours]('" + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)) + "','" + SystemHRProcedure.GetPayrollGenerateStartDate() + "',1)"));
						}
						else
						{
							mHrsPerMnt = Convert.ToInt32(365 * mEmpPerDayHrs);
						}
						//If GetSystemPreferenceSetting("Overtime_Working_Days") <> 0 Then
						if (mOvertimeWorkingDays != 0)
						{
							mHrsPerMnt = Convert.ToInt32(mOvertimeWorkingDays * mEmpPerDayHrs); //GetSystemPreferenceSetting("Overtime_Working_Days") * mEmpPerDayHrs
						}
						mdate = DateTime.Parse(SystemHRProcedure.GetPayrollSalaryDate()).AddMonths(1).AddDays(-1).ToString("dd/MMM/yyyy");
						mNOT = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 3)));
						mFOT = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 4)));
						mHOT = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 5)));

						//        If Not IsItEmpty((grdMigrate2.Cell(flexcpText, i, 5)), NumberType) Then
						//          mHrsPerMnt = Val(grdMigrate2.Cell(flexcpText, i, 5)) * mEmpPerDayHrs
						//        End If

						if (mNOT > 0)
						{
							mNOTEntId = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTANormalOT, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
							UpdateOTAttendanceHours(mdate, mdate, mNOTEntId, mNOT, false, mProjectcd);
							if (!mDailywages)
							{
								mOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql + "5"));
								mOTSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select dbo.paygetovertimesalary(" + mEmpCd.ToString() + "," + mOTBillCd.ToString() + ")"));
								mOTSalary = ((mOvertimeFormat == 1) ? mOTSalary : (mOTSalary * 12)) / ((double) mHrsPerMnt);
							}
							mOTTotalAmt = SystemHRProcedure.Rounding(mOTSalary * mNOT * OTRate(1, mEmpCd), ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_no from pay_ta_field ptf inner join pay_billing_type pbt on pbt.bill_cd = ptf.bill_cd where ptf.ta_field_id=5")));
							UpdateAttendanceOTAmt(mdate, mdate, mNOTEntId, mOTTotalAmt);
						}
						if (mFOT > 0)
						{
							mFOTEntId = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTAFridayOT, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
							UpdateOTAttendanceHours(mdate, mdate, mFOTEntId, mFOT, false, mProjectcd);
							if (!mDailywages)
							{
								mOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql + "6"));
								mOTSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select dbo.paygetovertimesalary(" + mEmpCd.ToString() + "," + mOTBillCd.ToString() + ")"));
								mOTSalary = ((mOvertimeFormat == 1) ? mOTSalary : (mOTSalary * 12)) / ((double) mHrsPerMnt);
							}
							mOTTotalAmt = SystemHRProcedure.Rounding(mOTSalary * mFOT * OTRate(2, mEmpCd), ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_no from pay_ta_field ptf inner join pay_billing_type pbt on pbt.bill_cd = ptf.bill_cd where ptf.ta_field_id=6")));
							UpdateAttendanceOTAmt(mdate, mdate, mFOTEntId, mOTTotalAmt);
						}
						if (mHOT > 0)
						{
							mHOTEntId = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTAHolidayOT, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
							UpdateOTAttendanceHours(mdate, mdate, mHOTEntId, mHOT, false, mProjectcd);
							if (!mDailywages)
							{
								mOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql + "7"));
								mOTSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select dbo.paygetovertimesalary(" + mEmpCd.ToString() + "," + mOTBillCd.ToString() + ")"));
								mOTSalary = ((mOvertimeFormat == 1) ? mOTSalary : (mOTSalary * 12)) / ((double) mHrsPerMnt);
							}
							mOTTotalAmt = SystemHRProcedure.Rounding(mOTSalary * mHOT * OTRate(3, mEmpCd), ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_no from pay_ta_field ptf inner join pay_billing_type pbt on pbt.bill_cd = ptf.bill_cd where ptf.ta_field_id=7")));
							UpdateAttendanceOTAmt(mdate, mdate, mHOTEntId, mOTTotalAmt);
						}
					}
					else
					{
						mErrorIn.Append(i.ToString() + ",");
						mProjectNotExist = "Employee No:" + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)) + " is Not Available.Line No.:-" + i.ToString();
						FileSystem.PrintLine(1, mProjectNotExist);
					}
					Application.DoEvents();
					lblmsg.Text = "Updating Record No......" + i.ToString();
					//'''If i Mod 50 = 0 Then lblmsg.Caption = "Updating."

				}

				FileSystem.FileClose(1);

				lblmsg.Text = "Update Done.";
				//If Len(mErrorIn) > 0 Then
				//    MsgBox "Not Updated Line " & mErrorIn, vbInformation
				//End If
				return true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
				lblmsg.Text = "";
			}
			return result;
		}

		private bool UpdateOTAttendanceHours(string pStartDate, string pEndDate, int pEntryId, double pHours, bool pUpdateDayOff = true, int pProjectCd = 0)
		{
			bool result = false;
			try
			{
				string mysql = "";
				object mReturnValue = null;

				mysql = " update pay_ta_trans_detail ";
				mysql = mysql + " set hrs= hrs +" + pHours.ToString();
				mysql = mysql + " where entry_id =" + pEntryId.ToString();
				mysql = mysql + " and pay_date >='" + StringsHelper.Format(pStartDate, SystemVariables.gSystemDateFormat) + "'";
				mysql = mysql + " and pay_date <='" + StringsHelper.Format(pEndDate, SystemVariables.gSystemDateFormat) + "'";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				if (pProjectCd > 0)
				{
					//Call InsertProjectAllocation(pEntryId, GetPayrollGenerateDate, pProjectCd, pHours)
				}

				//Update Time Attendance DayOff
				mysql = " select emp_cd from pay_ta_trans";
				mysql = mysql + " where entry_id =" + pEntryId.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				if (pUpdateDayOff)
				{
					if (!SystemHRProcedure.UpdateTimeAttendanceDayOff(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), ReflectionHelper.GetPrimitiveValue<int>(mReturnValue)))
					{
						MessageBox.Show("Error updating Time & Attendance hours!!", "Updating Time & Attendance Hours", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}
				return true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				result = false;
			}
			return result;
		}

		private double OTRate(int OTType, int pEmpCd)
		{

			string mysql = "select " + ((OTType == 1) ? "Normal_OT" : ((OTType == 2) ? "Friday_OT" : "Holiday_OT"));
			mysql = mysql + " from pay_employee ";
			mysql = mysql + " where emp_cd = " + pEmpCd.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				return ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
			}
			else
			{
				return 0;
			}
		}

		private int GetProjectCd(string ProjectNO)
		{

			string mysql = "select Project_Cd from GL_Projects";
			mysql = mysql + " where Project_No ='" + ProjectNO + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				return ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}
			else
			{
				return 0;
			}
		}

		private bool InsertProjectAllocation(int pEntryId, string pDate, int pProjectCd, ref double pHours, int pDays)
		{
			bool InserProjectAllocation = false;
			try
			{
				string mysql = "";

				if (pHours == 0)
				{ //if phours not supplied then take this hours from ta
					pHours = GetHoursByEntryID(pEntryId);
				}
				if (pHours == 0)
				{ // if phours after checking in ta also zero then exit function
					return false;
				}

				mysql = "insert into pay_project_payroll_details";
				mysql = mysql + "(entry_id,pay_date,project_cd,pay_hours,pay_days)";
				mysql = mysql + " values( " + pEntryId.ToString();
				mysql = mysql + ",'" + pDate + "'";
				mysql = mysql + "," + pProjectCd.ToString();
				mysql = mysql + "," + pHours.ToString();
				mysql = mysql + "," + pDays.ToString();
				mysql = mysql + ")";

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
				InserProjectAllocation = true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				InserProjectAllocation = false;
			}
			return false;
		}

		private bool InsertProjectAllocation(int pEntryId, string pDate, int pProjectCd, ref double pHours)
		{
			return InsertProjectAllocation(pEntryId, pDate, pProjectCd, ref pHours, 0);
		}

		private bool InsertProjectAllocation(int pEntryId, string pDate, int pProjectCd)
		{
			double tempRefParam = 0;
			return InsertProjectAllocation(pEntryId, pDate, pProjectCd, ref tempRefParam, 0);
		}

		private double GetHoursByEntryID(int pEntryId)
		{
			bool InserProjectAllocation = false;
			try
			{
				string mysql = "";
				object mReturnValue = null;

				mysql = "select sum(hrs)";
				mysql = mysql + " from pay_ta_trans_detail";
				mysql = mysql + " where entry_id = " + pEntryId.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049

				if (Convert.IsDBNull(mReturnValue))
				{
					return 0;
				}
				else
				{
					return ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				InserProjectAllocation = false;
			}
			return 0;
		}

		private bool AllocationProject(string pGenerateDate, int pProjectCd, int pEmpCode)
		{
			bool result = false;
			try
			{
				string mSQL = "";
				double mHours = 0;
				SqlDataReader rs = null;
				object mReturnValue = null;

				mSQL = " select top 1 line_no from pay_project_payroll ppp";
				mSQL = mSQL + " inner join pay_project_payroll_details pppd on ppp.entry_id = pppd.entry_id where ppp.emp_cd = " + pEmpCode.ToString() + " and ppp.pay_date ='" + pGenerateDate + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					mSQL = "select bill_cd,group_no from pay_billing_type where group_no is not null and show_in_project_allocation = 1 and over_time = 0";
					SqlCommand sqlCommand = new SqlCommand(mSQL, SystemVariables.gConn);
					rs = sqlCommand.ExecuteReader();
					rs.Read();
					do 
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select pay_hours from pay_project_payroll where bill_cd =" + Convert.ToString(rs["bill_cd"]) + " and emp_cd =" + pEmpCode.ToString() + " and pay_date='" + pGenerateDate + "'"));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue))
						{
							mHours = 0;
						}
						else
						{
							mHours = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
						}
						mSQL = " insert into pay_project_payroll_details (entry_id, pay_date, project_cd, pay_hours, pay_days)";
						mSQL = mSQL + " select ppp.entry_id,ppp.pay_date," + pProjectCd.ToString() + "," + mHours.ToString() + " ,0";
						mSQL = mSQL + " from pay_billing_type pbt ";
						mSQL = mSQL + " inner join pay_project_payroll ppp on ppp.bill_cd = pbt.bill_cd";
						mSQL = mSQL + " where pbt.group_no =" + Convert.ToString(rs["group_no"]);
						mSQL = mSQL + " and ppp.emp_cd = " + pEmpCode.ToString();
						mSQL = mSQL + " and ppp.pay_date ='" + pGenerateDate + "'";
						mSQL = mSQL + " and ppp.bill_cd in (select bill_cd from pay_payroll pp where pp.emp_cd = ppp.emp_cd and pp.pay_date = ppp.pay_date)";
						mSQL = mSQL + " and pbt.bill_no not in (9,11,13) ";
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mSQL;
						TempCommand.ExecuteNonQuery();
					}
					while(rs.Read());
					//''Insert Indeminity,Ticket,Leave
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select pay_hours from pay_project_payroll where bill_cd = 1 and emp_cd =" + pEmpCode.ToString() + " and pay_date='" + pGenerateDate + "'"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mHours = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
						mSQL = " insert into pay_project_payroll_details (entry_id, pay_date, project_cd, pay_hours, pay_days) ";
						mSQL = mSQL + " select ppp.entry_id, ppp.pay_date";
						mSQL = mSQL + ", " + pProjectCd.ToString();
						mSQL = mSQL + ", " + mHours.ToString();
						mSQL = mSQL + ", 0"; // days
						mSQL = mSQL + " from pay_project_payroll ppp";
						mSQL = mSQL + " inner join pay_billing_type pbt on pbt.bill_cd = ppp.bill_cd";
						mSQL = mSQL + " where ppp.pay_date ='" + pGenerateDate + "' and pbt.bill_no in (9,11,13) and ppp.emp_cd =" + pEmpCode.ToString();
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mSQL;
						TempCommand_2.ExecuteNonQuery();
					}

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

		public bool UpdateOT_Project_Details()
		{
			bool result = false;
			try
			{
				int i = 0;
				string mdate = "";
				StringBuilder mErrorIn = new StringBuilder();
				string mysql = "";
				int mNOTBillCd = 0;
				int mFOTBillCd = 0;
				int mHOTBillCd = 0;
				int mEmpCd = 0;
				int mOTBillCd = 0;
				int mHrsPerMnt = 0;
				double mOTSalary = 0;
				double mHours = 0;
				double mNOT = 0;
				double mFOT = 0;
				double mHOT = 0;
				double mOTTotalAmt = 0;
				double mEmpPerDayHrs = 0;
				int mProjectcd = 0;
				object mReturnValue = null;
				object mReturnValue1 = null;
				int mCheckValue = 0;
				string mFileName = "";
				string mMonthEndDate = "";
				string mProjectNotExist = "";
				//Dim mFileName As String

				mErrorIn = new StringBuilder("");
				lblmsg.Text = "Updating.";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mNOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("SELECT Bill_Cd FROM Pay_Billing_Type WHERE (Over_Time = 1)"));
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mFOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("SELECT Bill_Cd FROM Pay_Billing_Type WHERE (Over_Time = 2)"));
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mHOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("SELECT Bill_Cd FROM Pay_Billing_Type WHERE (Over_Time = 3)"));
				mMonthEndDate = SystemHRProcedure.GetMonthEndDate();

				mFileName = "C:\\OTProjectErrorList.txt";
				FileSystem.FileClose(1);
				FileSystem.FileOpen(1, mFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
				int tempForEndVar = grdMigrate2.Rows.Count - 1;
				for (i = 1; i <= tempForEndVar; i++)
				{
					mEmpCd = SystemHRProcedure.GetEmpCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)));
					mProjectcd = GetProjectCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 6)));
					if (!SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(i, 2), SystemVariables.DataType.StringType) && mProjectcd == 0)
					{
						mProjectNotExist = "Project No: " + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 6)) + " is Not Available.Line No.:-" + i.ToString();
						FileSystem.PrintLine(1, mProjectNotExist);
						goto NextRec;
					}

					if (mEmpCd > 0)
					{
						//mEmpPerDayHrs = GetEmpPerDayHours(mEmpCd)
						//mHrsPerMnt = GetMasterCode("select dbo.[payGetEmployeeWorkingHours]('" & grdMigrate2.Cell(flexcpText, i, 2) & "','" & GetPayrollGenerateStartDate & "',1)")
						mdate = DateTime.Parse(SystemHRProcedure.GetPayrollSalaryDate()).AddMonths(1).AddDays(-1).ToString("dd/MMM/yyyy");
						mNOT = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 3)));
						mFOT = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 4)));
						mHOT = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 5)));
						if (mNOT > 0)
						{
							mCheckValue = 0;
							mysql = "select entry_id from pay_project_payroll where emp_cd = " + mEmpCd.ToString() + " and bill_cd =" + mNOTBillCd.ToString() + " and pay_date = '" + DateTimeHelper.ToString(DateTime.Parse(mMonthEndDate)) + "'";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							mysql = "select line_no from Pay_Project_Payroll_Details where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + " and project_cd = " + mProjectcd.ToString();
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue1 = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							mCheckValue = (Convert.IsDBNull(mReturnValue1)) ? 0 : ReflectionHelper.GetPrimitiveValue<int>(mReturnValue1);
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								if (mCheckValue == 0)
								{
									if (!UpdateProjectAllocation(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), mMonthEndDate, mProjectcd, mNOT, 0, 0, 1))
									{
										mErrorIn.Append(i.ToString() + ",");
										i++;
										goto NextRec;
									}
								}
								else
								{
									if (!UpdateProjectAllocation(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), mMonthEndDate, mProjectcd, mNOT, mCheckValue, 0, 2))
									{
										mErrorIn.Append(i.ToString() + ",");
										i++;
										goto NextRec;
									}
								}
							}
						}
						if (mFOT > 0)
						{
							mCheckValue = 0;
							mysql = "select entry_id from pay_project_payroll where emp_cd = " + mEmpCd.ToString() + " and bill_cd =" + mFOTBillCd.ToString() + " and pay_date = '" + DateTimeHelper.ToString(DateTime.Parse(mMonthEndDate)) + "'";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							mysql = "select line_no from Pay_Project_Payroll_Details where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + " and project_cd = " + mProjectcd.ToString();
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue1 = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							mCheckValue = (Convert.IsDBNull(mReturnValue1)) ? 0 : ReflectionHelper.GetPrimitiveValue<int>(mReturnValue1);
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								if (mCheckValue == 0)
								{
									if (!UpdateProjectAllocation(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), mMonthEndDate, mProjectcd, mFOT, 0, 0, 1))
									{
										mErrorIn.Append(i.ToString() + ",");
										i++;
										goto NextRec;
									}
								}
								else
								{
									if (!UpdateProjectAllocation(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), mMonthEndDate, mProjectcd, mFOT, mCheckValue, 0, 2))
									{
										mErrorIn.Append(i.ToString() + ",");
										i++;
										goto NextRec;
									}
								}
							}
						}
						if (mHOT > 0)
						{
							mCheckValue = 0;
							mysql = "select entry_id from pay_project_payroll where emp_cd = " + mEmpCd.ToString() + " and bill_cd =" + mHOTBillCd.ToString() + " and pay_date = '" + DateTimeHelper.ToString(DateTime.Parse(mMonthEndDate)) + "'";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							mysql = "select line_no from Pay_Project_Payroll_Details where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + " and project_cd = " + mProjectcd.ToString();
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue1 = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							mCheckValue = (Convert.IsDBNull(mReturnValue1)) ? 0 : ReflectionHelper.GetPrimitiveValue<int>(mReturnValue1);
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								if (mCheckValue == 0)
								{
									if (!UpdateProjectAllocation(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), mMonthEndDate, mProjectcd, mHOT, 0, 0, 1))
									{
										mErrorIn.Append(i.ToString() + ",");
										i++;
										goto NextRec;
									}
								}
								else
								{
									if (!UpdateProjectAllocation(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), mMonthEndDate, mProjectcd, mHOT, mCheckValue, 0, 2))
									{
										mErrorIn.Append(i.ToString() + ",");
										i++;
										goto NextRec;
									}
								}
							}
						}

					}
					else
					{
						mErrorIn.Append(i.ToString() + ",");
					}
					lblmsg.Text = lblmsg.Text + ".";
					if (i % 50 == 0)
					{
						lblmsg.Text = "Updating.";
					}
					NextRec:;
				}

				FileSystem.FileClose(1);

				lblmsg.Text = "";

				return true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
				lblmsg.Text = "";
			}
			return result;
		}


		public bool UpdateProjectAllocation(int pEntryId, string pDate, int pProjectCd, double pHours, object pline_no, int pDays, int pInsertType)
		{
			bool result = false;
			try
			{
				string mysql = "";

				if (pInsertType == 1)
				{
					mysql = "insert into pay_project_payroll_details";
					mysql = mysql + "(entry_id,pay_date,project_cd,pay_hours,pay_days)";
					mysql = mysql + " values( " + pEntryId.ToString();
					mysql = mysql + ",'" + pDate + "'";
					mysql = mysql + "," + pProjectCd.ToString();
					mysql = mysql + "," + pHours.ToString();
					mysql = mysql + "," + pDays.ToString();
					mysql = mysql + ")";
				}
				else if (pInsertType == 2 && ReflectionHelper.GetPrimitiveValue<double>(pline_no) > 0)
				{ 
					mysql = " update pay_project_payroll_details ";
					mysql = mysql + " set pay_hours = pay_hours + " + pHours.ToString();
					mysql = mysql + " where line_no = " + ReflectionHelper.GetPrimitiveValue<string>(pline_no);
				}

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				return true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
			}
			return result;
		}

		public bool UpdateProjectAllocation(int pEntryId, string pDate, int pProjectCd, double pHours, object pline_no, int pDays)
		{
			return UpdateProjectAllocation(pEntryId, pDate, pProjectCd, pHours, pline_no, pDays, 1);
		}

		public bool UpdateProjectAllocation(int pEntryId, string pDate, int pProjectCd, double pHours, object pline_no)
		{
			return UpdateProjectAllocation(pEntryId, pDate, pProjectCd, pHours, pline_no, 0, 1);
		}

		public bool UpdateProjectAllocation(int pEntryId, string pDate, int pProjectCd, double pHours)
		{
			return UpdateProjectAllocation(pEntryId, pDate, pProjectCd, pHours, 0, 0, 1);
		}

		public bool UpdateAbsentHrsMethod3()
		{
			bool result = false;
			try
			{
				int i = 0;
				string mdate = "";
				int mAbsEntID = 0;
				int mWrkEntID = 0;
				int mEmpCd = 0;
				double mEmpPerDayHrs = 0;
				string mErrorIn = "";
				double mHours = 0;

				mErrorIn = "";
				lblmsg.Text = "Updating Record No......";
				int tempForEndVar = grdMigrate2.Rows.Count - 1;
				for (i = 1; i <= tempForEndVar; i++)
				{
					mEmpCd = SystemHRProcedure.GetEmpCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)));
					if (mEmpCd > 0)
					{
						mEmpPerDayHrs = SystemHRProcedure.GetEmpPerDayHours(mEmpCd);
						mdate = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, 3)), SystemVariables.gSystemDateFormat);
						if (!GetEmpDayType(mEmpCd, mdate, SystemHRProcedure.enumTAFields.eTAWeekend))
						{ //''Check if it is a Weekend
							if (!GetEmpDayType(mEmpCd, mdate, SystemHRProcedure.enumTAFields.eTAPublicHoliday))
							{ //''Check if it is a Public Holiday
								if (!EmpOnLeave(mEmpCd, mdate))
								{ //''Check if it is a Leave For This Employee
									mAbsEntID = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTAAbsentHours, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
									mWrkEntID = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
									SystemHRProcedure.UpdateAttendanceFieldsHours(mdate, mdate, mAbsEntID, mEmpPerDayHrs, false);
									SystemHRProcedure.UpdateAttendanceFieldsHours(mdate, mdate, mWrkEntID, 0, false);
								}
							}
						}
					}
					else
					{
						mErrorIn = mErrorIn + i.ToString() + ",";
					}
					lblmsg.Text = lblmsg.Text + ".";
					lblmsg.Text = "Updating Record No......" + i.ToString();
					Application.DoEvents();
				}
				lblmsg.Text = "";
				result = true;
				if (Strings.Len(mErrorIn) > 0)
				{
					MessageBox.Show("Not Updated Line " + mErrorIn, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
				lblmsg.Text = "";
			}
			return result;
		}

		public bool EmpOnLeave(int pEmpCd, string pDay)
		{

			string mSQL = "select sum(pttd.hrs)";
			mSQL = mSQL + " from pay_ta_trans_detail pttd";
			mSQL = mSQL + " inner join pay_ta_trans ptt on ptt.entry_id = pttd.entry_id";
			mSQL = mSQL + " Where ptt.emp_cd =" + pEmpCd.ToString();
			mSQL = mSQL + " and pttd.pay_date ='" + pDay + "'";
			mSQL = mSQL + " and ptt.pay_year =" + DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year.ToString();
			mSQL = mSQL + " and ptt.pay_month =" + DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month.ToString();
			mSQL = mSQL + " and ptt.tafield_id in(" + ((int) SystemHRProcedure.enumTAFields.eTAReserveHours).ToString() + "," + ((int) SystemHRProcedure.enumTAFields.eTAVacationHours).ToString() + "," + ((int) SystemHRProcedure.enumTAFields.eTAAdvanceSalary).ToString() + ")";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				return ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) >= 8;
			}
			else
			{
				return false;
			}
		}


		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			grdMigrate2.Width = this.Width - 18;
			grdMigrate2.Height = this.Height - (grdMigrate2.Top + 40);

		}

		private void optDownloadFormat_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				if (optDownloadFormat[0].Checked)
				{
					if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("Import_TimeAttendance_Format")) != 6)
					{
						chkIncludeLeaveEmployee.Visible = false;
					}
				}
				else if (optDownloadFormat[1].Checked)
				{ 
					chkIncludeLeaveEmployee.Visible = true;
				}
				else if (optDownloadFormat[0].Checked)
				{ 
					chkIncludeLeaveEmployee.Visible = false;
				}
			}
		}

		private bool UpdateAbsentHrsMethod5()
		{
			bool result = false;
			int j = 0;
			object mFileName = null;
			string mGenerateDate = "";
			System.DateTime mStartDate = DateTime.FromOADate(0);
			object mValue = null;
			try
			{
				int i = 0;
				string mdate = "";
				int mHOTEntId = 0, mNOTEntId = 0, mAbsEntID = 0, mWrkEntID = 0, mFOTEntId = 0, mOTBillCd = 0;
				int mEmpCd = 0;
				double mEmpPerDayHrs = 0;
				string mErrorIn = "";
				int mProjectcd = 0;
				double mHours = 0;
				string mCurrentMonthCutOffDate = "";
				string mLastMonthCutoffDate = "";
				int mDaysPerMonth = 0;
				double mOvertimeSalary = 0;
				int mOvertimeFormat = 0;
				object mReturnValue = null;
				string mEmployeeNotExit = "";
				string mysql = "";
				double mAmt = 0;

				mLastMonthCutoffDate = SystemHRProcedure.GetPayrollSalaryDate();
				mCurrentMonthCutOffDate = DateTimeHelper.ToString(DateTime.Parse(mLastMonthCutoffDate).AddMonths(1).AddDays(-1));
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mOvertimeFormat = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Overtime_Format"));
				mErrorIn = "";
				lblmsg.Text = "Updating Record No......";

				if (SystemProcedure2.IsItEmpty(txtErrorFilePAth.Text, SystemVariables.DataType.StringType))
				{
					mFileName = "C:\\Attendance_" + DateAndTime.Day(DateTime.Today).ToString() + ".txt";
				}
				else
				{
					mFileName = txtErrorFilePAth.Text;
				}

				FileSystem.FileClose(1);
				FileSystem.FileOpen(1, ReflectionHelper.GetPrimitiveValue<string>(mFileName), OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);

				int tempForEndVar = grdMigrate2.Rows.Count - 1;
				for (i = 2; i <= tempForEndVar; i++)
				{
					mEmpCd = SystemHRProcedure.GetEmpCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)));
					if (mEmpCd > 0)
					{
						j = 5;
						while (SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(1, j), SystemVariables.DataType.StringType) && grdMigrate2.Cols.Count - 1 > j)
						{ //j = 2 To 16
							mProjectcd = GetProjectCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, j)));
							mStartDate = DateAndTime.DateSerial(DateTime.Parse(mdate).Year, DateTime.Parse(mdate).Month, 1);
							mGenerateDate = StringsHelper.Format(mStartDate.AddMonths(1).AddDays(-1), SystemVariables.gSystemDateFormat);
							//UPGRADE_WARNING: (1068) grdMigrate2.Cell() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mValue = ReflectionHelper.GetPrimitiveValue(grdMigrate2.getCellText(i, j));

							j++;
						}
					}

				}

				if (Strings.Len(mErrorIn) > 0)
				{
					MessageBox.Show("Not Updated Line " + mErrorIn, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				mysql = "Drop table #TmpAttendance";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				FileSystem.FileClose(1);
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
				lblmsg.Text = "";
			}

			return result;
		}


		private object UpdateAbsentHrsMethod51()
		{
			object mFileName = null;
			try
			{
				int i = 0;
				string mdate = "";
				int mHOTEntId = 0, mNOTEntId = 0, mAbsEntID = 0, mWrkEntID = 0, mFOTEntId = 0, mOTBillCd = 0;
				int mEmpCd = 0;
				double mEmpPerDayHrs = 0;
				string mErrorIn = "";
				int mProjectcd = 0;
				double mHours = 0;
				string mCurrentMonthCutOffDate = "";
				string mLastMonthCutoffDate = "";
				int mDaysPerMonth = 0;
				double mOvertimeSalary = 0;
				int mOvertimeFormat = 0;
				object mReturnValue = null;
				string mEmployeeNotExit = "";
				string mysql = "";
				double mAmt = 0;
				int mOvertimeWorkingDays = 0;

				mLastMonthCutoffDate = SystemHRProcedure.GetPayrollSalaryDate();
				mCurrentMonthCutOffDate = DateTimeHelper.ToString(DateTime.Parse(mLastMonthCutoffDate).AddMonths(1));
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mOvertimeFormat = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Overtime_Format"));
				mErrorIn = "";
				lblmsg.Text = "Updating Record No......";

				mysql = "create table #TmpAttendance ( emp_cd bigint, [pay_date] smallDatetime";
				mysql = mysql + ", WorkHours decimal(8,3) , OT decimal(8,3) , Project_cd bigint , weekend bit ,  publicholiday bit , emponleave bit)";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				if (SystemProcedure2.IsItEmpty(txtErrorFilePAth.Text, SystemVariables.DataType.StringType))
				{
					mFileName = "C:\\Attendance_" + DateAndTime.Day(DateTime.Today).ToString() + ".txt";
				}
				else
				{
					mFileName = txtErrorFilePAth.Text;
				}

				FileSystem.FileClose(1);
				FileSystem.FileOpen(1, ReflectionHelper.GetPrimitiveValue<string>(mFileName), OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);

				int tempForEndVar = grdMigrate2.Rows.Count - 1;
				for (i = 2; i <= tempForEndVar; i++)
				{
					mEmpCd = SystemHRProcedure.GetEmpCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)));
					mProjectcd = GetProjectCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 5)));
					mdate = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, 2)), SystemVariables.gSystemDateFormat);
					if (mEmpCd != 0)
					{
						mysql = " insert into #TmpAttendance(emp_cd , pay_date , WorkHours , OT , Project_cd , weekend , publicholiday , emponleave) ";
						mysql = mysql + " Select " + mEmpCd.ToString();
						mysql = mysql + ", '" + mdate + "'";
						mysql = mysql + ", " + Convert.ToDouble(DateAndTime.Hour(ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, 3)))).ToString();
						mysql = mysql + ", " + Convert.ToDouble(DateAndTime.Hour(ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, 4)))).ToString();
						mysql = mysql + ", " + mProjectcd.ToString();
						mysql = mysql + ", " + ((GetEmpDayType(mEmpCd, mdate, SystemHRProcedure.enumTAFields.eTAWeekend)) ? 1 : 0).ToString();
						mysql = mysql + ", " + ((GetEmpDayType(mEmpCd, mdate, SystemHRProcedure.enumTAFields.eTAPublicHoliday)) ? 1 : 0).ToString();
						mysql = mysql + ", " + ((EmpOnLeave(mEmpCd, mdate)) ? 1 : 0).ToString();
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();

						//******************************* Updating Overtime In Attendance **************************
						mysql = " select basic_salary, normal_ot, friday_ot, holiday_ot,  allow_overtime, hours_per_day";
						mysql = mysql + " , rate_calc_method_id, days_per_month, weekend_day1_id, weekend_day2_id ,Overtime_Working_Days";
						mysql = mysql + " from pay_employee";
						mysql = mysql + " where emp_cd = " + mEmpCd.ToString();
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						if (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(4)))
						{ //For Check this employee is entitle for overtime or not
							mOvertimeWorkingDays = Convert.ToInt32(Math.Floor(ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(10))));
							mHours = DateAndTime.Hour(ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, 4))) + (ReflectionHelper.GetPrimitiveValue<System.DateTime>(grdMigrate2.getCellText(i, 4)).Minute / 60d);
							if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(6)) == SystemHRProcedure.gFixedDays)
							{ //if fixed days
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mDaysPerMonth = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(7)); //Calculate Working Days in Month
							}
							else if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(6)) == SystemHRProcedure.gActualDays)
							{ 
								mDaysPerMonth = Convert.ToInt32(SystemHRProcedure.CalculateDays(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()), DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(8)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(9)))); //Calculate Working Days in Month
							}
							//If GetSystemPreferenceSetting("Overtime_Working_Days") <> 0 Then
							if (mOvertimeWorkingDays != 0)
							{
								mDaysPerMonth = mOvertimeWorkingDays; //GetSystemPreferenceSetting("Overtime_Working_Days")
							}
							mAmt = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0)) / (mDaysPerMonth * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(6)));
							if (!GetEmpDayType(mEmpCd, mdate, SystemHRProcedure.enumTAFields.eTAWeekend))
							{
								if (!GetEmpDayType(mEmpCd, mdate, SystemHRProcedure.enumTAFields.eTAPublicHoliday))
								{
									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_cd from pay_ta_field ptf inner join pay_billing_type pbt on pbt.bill_cd = ptf.bill_cd where ptf.ta_field_id=5"));
									mNOTEntId = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTANormalOT, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
									SystemHRProcedure.UpdateAttendanceFieldsHours(mdate, mdate, mNOTEntId, mHours, false);
									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode(" select dbo.paygetovertimesalary(" + mEmpCd.ToString() + "," + mOTBillCd.ToString() + ")"));
									if (mOvertimeFormat == 1)
									{
										mAmt = mOvertimeSalary / (mDaysPerMonth * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)));
									}
									else
									{
										mAmt = (mOvertimeSalary * 12) / (365 * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)));
									}
									mAmt = SystemHRProcedure.Rounding(mAmt * mHours * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1)), ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_no from pay_billing_type pbt where pbt.bill_cd=" + mOTBillCd.ToString())));
									UpdateAttendanceOTAmt(mdate, mdate, mNOTEntId, mAmt);
								}
								else
								{
									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_cd from pay_ta_field ptf inner join pay_billing_type pbt on pbt.bill_cd = ptf.bill_cd where ptf.ta_field_id=7"));
									mHOTEntId = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTAHolidayOT, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
									SystemHRProcedure.UpdateAttendanceFieldsHours(mdate, mdate, mHOTEntId, mHours, false);
									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode(" select dbo.paygetovertimesalary(" + mEmpCd.ToString() + "," + mOTBillCd.ToString() + ")"));
									if (mOvertimeFormat == 1)
									{
										mAmt = mOvertimeSalary / (mDaysPerMonth * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)));
									}
									else
									{
										mAmt = (mOvertimeSalary * 12) / (365 * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)));
									}
									mAmt = SystemHRProcedure.Rounding(mAmt * mHours * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3)), ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_no from pay_billing_type pbt where pbt.bill_cd=" + mOTBillCd.ToString())));
									UpdateAttendanceOTAmt(mdate, mdate, mHOTEntId, mAmt);
								}
							}
							else
							{
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_cd from pay_ta_field ptf inner join pay_billing_type pbt on pbt.bill_cd = ptf.bill_cd where ptf.ta_field_id=6"));
								mFOTEntId = SystemHRProcedure.GetTAEntryID(mEmpCd, SystemHRProcedure.enumTAFields.eTAFridayOT, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
								SystemHRProcedure.UpdateAttendanceFieldsHours(mdate, mdate, mFOTEntId, mHours, false);
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode(" select dbo.paygetovertimesalary(" + mEmpCd.ToString() + "," + mOTBillCd.ToString() + ")"));
								if (mOvertimeFormat == 1)
								{
									mAmt = mOvertimeSalary / (mDaysPerMonth * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)));
								}
								else
								{
									mAmt = (mOvertimeSalary * 12) / (365 * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)));
								}
								mAmt = SystemHRProcedure.Rounding(mAmt * mHours * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2)), ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_no from pay_billing_type pbt where pbt.bill_cd=" + mOTBillCd.ToString())));
								UpdateAttendanceOTAmt(mdate, mdate, mFOTEntId, mAmt);
							}
						}
						//******************END OF OvertimeImport **********************
					}
					else
					{
						mEmployeeNotExit = "Employee Not Exist : " + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)) + " in Line No : " + i.ToString();
						FileSystem.PrintLine(1, mEmployeeNotExit);
					}
					lblmsg.Text = "Updating Record No......" + i.ToString();
					Application.DoEvents();
				}

				//***************Update Absent in Time Attendance**********************************
				mysql = " update pttd";
				mysql = mysql + " set pttd.hrs =pemp.hours_per_day - ( select SUM(WorkHours) from #TmpAttendance pptd ";
				mysql = mysql + " where pptd.pay_date = pttd.pay_date and pptd.emp_cd = ptt.emp_cd and pptd.emponleave = 0)";
				mysql = mysql + " from pay_ta_trans_detail pttd";
				mysql = mysql + " inner join pay_ta_trans ptt on pttd.entry_id = ptt.entry_id";
				mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = ptt.emp_cd";
				mysql = mysql + " where pttd.pay_date >'" + mLastMonthCutoffDate + "' and pttd.pay_date <='" + mCurrentMonthCutOffDate + "'";
				mysql = mysql + " and ptt.tafield_id = 2 and pemp.hours_per_day > 0";
				mysql = mysql + " and ( select SUM(WorkHours) from #TmpAttendance pptd ";
				mysql = mysql + " where pptd.pay_date = pttd.pay_date and pptd.emp_cd = ptt.emp_cd and pptd.emponleave = 0) between 0 and (pemp.hours_per_day-1)";
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();
				//***************END Of Updating Absent in Time Attendance**********************************

				lblmsg.Text = "";
				UpdateAbsentHrsMethod5 = true;
				if (Strings.Len(mErrorIn) > 0)
				{
					MessageBox.Show("Not Updated Line " + mErrorIn, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				mysql = "Drop table #TmpAttendance";
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();

				FileSystem.FileClose(1);
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				UpdateAbsentHrsMethod5 = false;
				lblmsg.Text = "";
			}

			return null;
		}

		private bool UpdateApprovedTA()
		{
			bool result = false;
			try
			{
				int i = 0;
				string mdate = "";
				int mFOTEntId = 0, mSickEntID = 0, mAbsEntID = 0, mWrkEntID = 0, mNOTEntId = 0, mHOTEntId = 0;
				int mGOTEntId = 0, mOTBillCd = 0;
				int mEmpCd = 0;
				double mEmpPerDayHrs = 0;
				int mDaysPerMonth = 0;
				double mRatePerHours = 0;
				double mPaidDays = 0;
				double mUnPaidDays = 0;
				double mHours = 0;
				string mErrorIn = "";
				int mProjectcd = 0;
				double mOvertimeSalary = 0;
				int mOvertimeFormat = 0;
				object mReturnValue = null;
				string mEmployeeNotExit = "";
				string mysql = "";
				double mAmt = 0;
				double mDays = 0;
				SqlDataReader rsLocal = null;
				StringBuilder mComments = new StringBuilder();
				double mLeaveBalance = 0;
				int mOvertimeWorkingDays = 0;

				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mOvertimeFormat = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Overtime_Format"));
				i = 1;
				lblmsg.Text = "Updating Record No......";
				mysql = "select * from Pay_Attendance_Approval where Pay_Date = '" + SystemHRProcedure.GetPayrollGenerateDate() + "' and Approval_Stage = 2 and Is_Imported = 0";
				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocal = sqlCommand.ExecuteReader();
				rsLocal.Read();
				do 
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select weekend_day1_id,weekend_day2_id,hours_per_day,status_cd,Rate_Per_Hour,days_per_month,rate_calc_method_id,Normal_ot,friday_ot,holiday_ot,allow_overtime,Overtime_Working_Days,status_cd from pay_employee where emp_cd =" + Convert.ToString(rsLocal["Emp_cd"])));
					mOvertimeWorkingDays = Convert.ToInt32(Math.Floor(ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(11))));
					if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(6)) == SystemHRProcedure.gFixedDays)
					{ //if fixed days
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mDaysPerMonth = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(5)); //Calculate Working Days in Month
					}
					else if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(6)) == SystemHRProcedure.gActualDays)
					{ 
						mDaysPerMonth = Convert.ToInt32(SystemHRProcedure.CalculateDays(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()), DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(8)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(9)))); //Calculate Working Days in Month
					}
					//If GetSystemPreferenceSetting("Overtime_Working_Days") <> 0 Then
					if (mOvertimeWorkingDays != 0)
					{
						mDaysPerMonth = mOvertimeWorkingDays; //GetSystemPreferenceSetting("Overtime_Working_Days")
					}

					//*************Working Hours Import *******************
					if (Convert.ToDouble(rsLocal["WorkedHrs"]) > 0)
					{ //Working Hours Update
						mWrkEntID = SystemHRProcedure.GetTAEntryID(Convert.ToInt32(rsLocal["Emp_cd"]), SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
						if (mWrkEntID == 0)
						{
							goto NextRecord;
						}
						mHours = Convert.ToDouble(rsLocal["WorkedHrs"]);
						SystemHRProcedure.UpdateAttendanceFieldsHours(Convert.ToString(rsLocal["AttendanceDate"]), Convert.ToString(rsLocal["AttendanceDate"]), mWrkEntID, mHours);
						if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(6)) == SystemHRProcedure.gDailyWages)
						{
							mysql = "Update pttd";
							mysql = mysql + " set Amount = pttd.hrs * " + ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(4)).ToString();
							mysql = mysql + " ,Affect_Payroll = 1";
							mysql = mysql + " from pay_ta_trans ptt ";
							mysql = mysql + " inner join pay_ta_trans_detail pttd on ptt.entry_id = pttd.entry_id";
							mysql = mysql + " where pttd.pay_date = '" + Convert.ToString(rsLocal["AttendanceDate"]) + "' and ptt.entry_id = " + mWrkEntID.ToString() + " and ptt.tafield_id = " + ((int) SystemHRProcedure.enumTAFields.eTAWorkHours).ToString();
							SqlCommand TempCommand = null;
							TempCommand = SystemVariables.gConn.CreateCommand();
							TempCommand.CommandText = mysql;
							TempCommand.ExecuteNonQuery();
						}
					}
					//*************Absent Hours Import *******************
					if (Convert.ToDouble(rsLocal["NoPayDays"]) > 0)
					{ //Absent Hour Update
						mAbsEntID = SystemHRProcedure.GetTAEntryID(Convert.ToInt32(rsLocal["Emp_cd"]), SystemHRProcedure.enumTAFields.eTAAbsentHours, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
						mHours = Convert.ToDouble(rsLocal["NoPayDays"]);
						SystemHRProcedure.UpdateAttendanceFieldsHours(Convert.ToString(rsLocal["AttendanceDate"]), Convert.ToString(rsLocal["AttendanceDate"]), mAbsEntID, mHours);
					}
					if (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(10)))
					{ // Check Employee is eligible for OT or not.!!!!!
						//*************NOT Hours Import *******************
						if (Convert.ToDouble(rsLocal["NormalOT"]) > 0)
						{ //NOT Hours Update
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_cd from pay_ta_field ptf inner join pay_billing_type pbt on pbt.bill_cd = ptf.bill_cd where ptf.ta_field_id=" + ((int) SystemHRProcedure.enumTAFields.eTANormalOT).ToString()));
							mHours = Convert.ToDouble(rsLocal["NormalOT"]);
							mNOTEntId = SystemHRProcedure.GetTAEntryID(Convert.ToInt32(rsLocal["Emp_cd"]), SystemHRProcedure.enumTAFields.eTANormalOT, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
							SystemHRProcedure.UpdateAttendanceFieldsHours(Convert.ToString(rsLocal["AttendanceDate"]), Convert.ToString(rsLocal["AttendanceDate"]), mNOTEntId, mHours);
							if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(6)) != SystemHRProcedure.gDailyWages)
							{ //if Not Daily Wages Emp
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode(" select dbo.paygetovertimesalary(" + Convert.ToString(rsLocal["Emp_cd"]) + "," + mOTBillCd.ToString() + ")"));
								if (mOvertimeFormat == 1)
								{
									mAmt = mOvertimeSalary / (mDaysPerMonth * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2)));
								}
								else
								{
									mAmt = (mOvertimeSalary * 12) / (365 * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2)));
								}
							}
							else
							{
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mAmt = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(4));
							}
							mAmt = SystemHRProcedure.Rounding(mAmt * mHours * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(7)), ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_no from pay_billing_type pbt where pbt.bill_cd=" + mOTBillCd.ToString())));
							UpdateAttendanceOTAmt(Convert.ToString(rsLocal["AttendanceDate"]), Convert.ToString(rsLocal["AttendanceDate"]), mNOTEntId, mAmt);
						}
						//*************FOT Hours Import *******************
						if (Convert.ToDouble(rsLocal["FridayOT"]) > 0)
						{ //FOT Hours Update
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_cd from pay_ta_field ptf inner join pay_billing_type pbt on pbt.bill_cd = ptf.bill_cd where ptf.ta_field_id=" + ((int) SystemHRProcedure.enumTAFields.eTAFridayOT).ToString()));
							mHours = Convert.ToDouble(rsLocal["FridayOT"]);
							mFOTEntId = SystemHRProcedure.GetTAEntryID(Convert.ToInt32(rsLocal["Emp_cd"]), SystemHRProcedure.enumTAFields.eTAFridayOT, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
							SystemHRProcedure.UpdateAttendanceFieldsHours(Convert.ToString(rsLocal["AttendanceDate"]), Convert.ToString(rsLocal["AttendanceDate"]), mFOTEntId, mHours);
							if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(6)) != SystemHRProcedure.gDailyWages)
							{ //if Not Daily Wages Emp
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode(" select dbo.paygetovertimesalary(" + Convert.ToString(rsLocal["Emp_cd"]) + "," + mOTBillCd.ToString() + ")"));
								if (mOvertimeFormat == 1)
								{
									mAmt = mOvertimeSalary / (mDaysPerMonth * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)));
								}
								else
								{
									mAmt = (mOvertimeSalary * 12) / (365 * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)));
								}
							}
							else
							{
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mAmt = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(4));
							}
							mAmt = SystemHRProcedure.Rounding(mAmt * mHours * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(8)), ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_no from pay_billing_type pbt where pbt.bill_cd=" + mOTBillCd.ToString())));
							UpdateAttendanceOTAmt(Convert.ToString(rsLocal["AttendanceDate"]), Convert.ToString(rsLocal["AttendanceDate"]), mFOTEntId, mAmt);
						}
						//*************HOT Hours Import *******************
						if (Convert.ToDouble(rsLocal["HolidayOT"]) > 0)
						{ //HOT Hours Update
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mOTBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_cd from pay_ta_field ptf inner join pay_billing_type pbt on pbt.bill_cd = ptf.bill_cd where ptf.ta_field_id=" + ((int) SystemHRProcedure.enumTAFields.eTAHolidayOT).ToString()));
							mHours = Convert.ToDouble(rsLocal["HolidayOT"]);
							mHOTEntId = SystemHRProcedure.GetTAEntryID(Convert.ToInt32(rsLocal["Emp_cd"]), SystemHRProcedure.enumTAFields.eTAHolidayOT, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
							SystemHRProcedure.UpdateAttendanceFieldsHours(Convert.ToString(rsLocal["AttendanceDate"]), Convert.ToString(rsLocal["AttendanceDate"]), mHOTEntId, mHours);
							if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(6)) != SystemHRProcedure.gDailyWages)
							{ //if Not Daily Wages Emp
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode(" select dbo.paygetovertimesalary(" + Convert.ToString(rsLocal["Emp_cd"]) + "," + mOTBillCd.ToString() + ")"));
								if (mOvertimeFormat == 1)
								{
									mAmt = mOvertimeSalary / (mDaysPerMonth * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2)));
								}
								else
								{
									mAmt = (mOvertimeSalary * 12) / (365 * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2)));
								}
							}
							else
							{
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mAmt = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(4));
							}
							mAmt = SystemHRProcedure.Rounding(mAmt * mHours * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(9)), ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select pbt.bill_no from pay_billing_type pbt where pbt.bill_cd=" + mOTBillCd.ToString())));
							UpdateAttendanceOTAmt(Convert.ToString(rsLocal["AttendanceDate"]), Convert.ToString(rsLocal["AttendanceDate"]), mHOTEntId, mAmt);
						}
					}
					//*************Sick Hours Import *******************
					if (Convert.ToDouble(rsLocal["SickHrs"]) > 0)
					{ //Sick Leave Hours Update
						mSickEntID = SystemHRProcedure.GetTAEntryID(Convert.ToInt32(rsLocal["Emp_cd"]), SystemHRProcedure.enumTAFields.eTASickHours, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);
						mHours = Convert.ToDouble(rsLocal["SickHrs"]);
						SystemHRProcedure.UpdateAttendanceFieldsHours(Convert.ToString(rsLocal["AttendanceDate"]), Convert.ToString(rsLocal["AttendanceDate"]), mSickEntID, mHours);
						mDays = mHours / 8d; //CDbl(mReturnValue(2))
						mLeaveBalance = SystemHRProcedure.Leave_Balance_Days(Convert.ToInt32(rsLocal["Emp_cd"]), 3, Convert.ToDateTime(rsLocal["AttendanceDate"]), 4);
						if (mDays > mLeaveBalance)
						{
							mysql = " select dbo.payLeaveAmount(" + Convert.ToString(rsLocal["Emp_cd"]) + ",3," + Conversion.Val(mLeaveBalance.ToString()).ToString() + ",'" + Convert.ToString(rsLocal["AttendanceDate"]) + "')";
							mComments = new StringBuilder(mLeaveBalance.ToString() + " ;");
							mPaidDays = mLeaveBalance;
							mUnPaidDays = mHours - mLeaveBalance;
						}
						else
						{
							mysql = " select dbo.payLeaveAmount(" + Convert.ToString(rsLocal["Emp_cd"]) + ",3," + mDays.ToString() + ",'" + Convert.ToString(rsLocal["AttendanceDate"]) + "')";
							mComments = new StringBuilder(mDays.ToString() + " ; ");
							mPaidDays = mDays;
							mUnPaidDays = 0;
						}
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							mAmt = Double.Parse(StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(mReturnValue), "#####0.000"));
						}
						if (mDays > mLeaveBalance)
						{
							mysql = " select dbo.payLeavedetails(" + Convert.ToString(rsLocal["Emp_cd"]) + ",3," + Conversion.Val(mLeaveBalance.ToString()).ToString() + ",'" + Convert.ToString(rsLocal["AttendanceDate"]) + "')";
						}
						else
						{
							mysql = " select dbo.payLeavedetails(" + Convert.ToString(rsLocal["Emp_cd"]) + ",3," + mDays.ToString() + ",'" + Convert.ToString(rsLocal["AttendanceDate"]) + "')";
						}
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							mComments.Append(ReflectionHelper.GetPrimitiveValue<string>(mReturnValue));
						}
						mysql = "Update pttd";
						mysql = mysql + " set Amount =  " + mAmt.ToString();
						mysql = mysql + " ,Affect_Payroll = 1";
						mysql = mysql + " ,Remarks = '" + mComments.ToString() + "'";
						mysql = mysql + " from pay_ta_trans ptt ";
						mysql = mysql + " inner join pay_ta_trans_detail pttd on ptt.entry_id = pttd.entry_id";
						mysql = mysql + " where pttd.pay_date = '" + Convert.ToString(rsLocal["AttendanceDate"]) + "' and ptt.entry_id = " + mSickEntID.ToString() + " and ptt.tafield_id = " + ((int) SystemHRProcedure.enumTAFields.eTASickHours).ToString();
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();
						SystemHRProcedure.UpdateSickLeaveDays(mPaidDays, mUnPaidDays, Convert.ToInt32(rsLocal["Emp_cd"]));
					}
					// Update Field With Is_imported true
					mysql = "update Pay_Attendance_Approval set Is_Imported = 1 where Entry_id = " + Convert.ToString(rsLocal["Entry_id"]);
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					NextRecord:
					lblmsg.Text = "Updating Record No......" + i.ToString();
					Application.DoEvents();
					i++;
				}
				while(rsLocal.Read());



				return true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
				lblmsg.Text = "";
			}
			return result;
		}

		private object UpdateTAMethod6()
		{
			object mFileName = null;
			try
			{
				int i = 0;
				string mdate = "";
				int mEmpCd = 0;
				string mErrorIn = "";
				object mReturnValue = null;
				string mEmployeeNotExit = "";
				StringBuilder mysql = new StringBuilder();
				string mComments = "";

				if (SystemProcedure2.IsItEmpty(txtErrorFilePAth.Text, SystemVariables.DataType.StringType))
				{
					mFileName = "C:\\Attendance_" + DateAndTime.Day(DateTime.Today).ToString() + ".txt";
				}
				else
				{
					mFileName = txtErrorFilePAth.Text;
				}
				FileSystem.FileClose(1);
				FileSystem.FileOpen(1, ReflectionHelper.GetPrimitiveValue<string>(mFileName), OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);

				int tempForEndVar = grdMigrate2.Rows.Count - 1;
				for (i = 2; i <= tempForEndVar; i++)
				{
					if (chkIncludeLeaveEmployee.CheckState == CheckState.Unchecked)
					{
						mEmpCd = SystemHRProcedure.GetEmpCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)));
					}
					else
					{
						mEmpCd = SystemHRProcedure.GetEmpCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)), "status_cd = 1");
					}
					if (mEmpCd != 0)
					{
						mysql = new StringBuilder(" insert into pay_attendance_approval");
						mysql.Append(" (emp_cd,pay_date,workedhrs,sickhrs,nopaydays,normalot,fridayot,holidayot");
						mysql.Append(" ,attendancedate,user_cd,user_date_time)");
						mysql.Append(" Values(" + mEmpCd.ToString());
						mysql.Append(" , '" + SystemHRProcedure.GetPayrollGenerateDate() + "'");
						mysql.Append(" , " + ((SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(i, 2))) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 2)))); // Worked Hrs
						mysql.Append(" , " + ((SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(i, 3))) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 3)))); // Sick Hrs
						mysql.Append(" , " + ((SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(i, 4))) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 4)))); // NoPayDays
						mysql.Append(" , " + ((SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(i, 5))) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 5)))); // normalOT
						mysql.Append(" , " + ((SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(i, 6))) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 6)))); // FridayOT
						mysql.Append(" , " + ((SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(i, 7))) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 7)))); // HolidayOT
						mysql.Append(" , '" + ReflectionHelper.GetPrimitiveValue<string>(txtDate.Value) + "'"); // AttendanceDate
						mysql.Append(" , " + SystemVariables.gLoggedInUserCode.ToString());
						mysql.Append(" , '" + DateTime.Today.ToString("dd-MMM-yyyy") + "'");
						mysql.Append(" )");
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql.ToString();
						TempCommand.ExecuteNonQuery();
					}
					else
					{

						mEmployeeNotExit = "Employee No. " + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)) + " Not Exist in Line No. : " + i.ToString();
						FileSystem.PrintLine(1, mEmployeeNotExit);
					}
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				UpdateAbsentHrsMethod5 = false;
				lblmsg.Text = "";
			}

			return null;
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}