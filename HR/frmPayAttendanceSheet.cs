
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayAttendanceSheet
		: System.Windows.Forms.Form
	{

		public frmPayAttendanceSheet()
{
InitializeComponent();
} 
 public  void frmPayAttendanceSheet_old()
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


		private void frmPayAttendanceSheet_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private XArrayHelper _aVoucherDetails = null;
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

		private const int conMaxColumns = 36;
		private clsToolbar oThisFormToolBar = null;
		int mThisFormID = 0;
		private int mFormCallType = 0;
		private object mSearchValue = null;
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

		// For Column Constraint
		private const int mConTAFieldName = 1;
		private const int mConRemarks = 33;
		private const int mConIncludeINCalculationHrs = 34;
		private const int mConTAFieldID = 35;
		private const int mConTAFieldType = 36;

		private const int mConTxtEmpNo = 1;
		private const int mConTxtEmpName = 2;
		private const int mConTxtDept = 3;
		private const int mDisplaylblDeptName = 4;
		private const int mDisplaylblYear = 5;
		private const int mDisplaylblMonth = 6;
		private double mHoursPerDay = 0; //It Will Change When We Call a employee from Find Window


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
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowInsertLineButton = false;
				oThisFormToolBar.ShowDeleteLineButton = false;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;
				FirstFocusObject = grdVoucherDetails;
				DefineGridColumns(SystemHRProcedure.GetPayrollGenerateStartDate(), SystemHRProcedure.GetPayrollGenerateDate());


				SystemProcedure.SetLabelCaption(this);
				grdVoucherDetails.Visible = true;
				grdVoucherDetails.Enabled = true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void DefineGridColumns(string pStartDate, string pEndDate)
		{
			int i = 0;
			string mStr = "";


			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Description", 2500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);


			for (i = 1; i <= 31; i++)
			{
				mStr = DateAndTime.Day(DateTime.Parse(pStartDate)).ToString();
				if (DateTime.Parse(pStartDate) <= DateTime.Parse(pEndDate))
				{
					SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, mStr, 500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
				}
				else
				{
					SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, mStr, 500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false, false, true);
				}
				pStartDate = DateTimeHelper.ToString(DateTime.Parse(pStartDate).AddDays(1));
			}
			// End Of Day Spacify

			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 2500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 50);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "IncludeINCalculationHrs", 2500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false, false, false, true, false, 50);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "TAFieldID", 2500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false, false, false, true, false, 50);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "TAFieldType", 2500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false, false, false, true, false, 50);

			DefineVoucherArray(-1, false);
			AssignGridLineNumbers();
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);
			grdVoucherDetails.Rebind(true);

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

		public void findRecord()
		{
			string mysql = " pemp.status_cd <> " + SystemHRProcedure.gStatusTerminated.ToString() + " and pemp.is_payroll_generated = 0 ";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220560, "2582,2583", mysql));
			System.DateTime mGenerateDate = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate());

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(((Array) mTempSearchValue).GetValue(0), ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempSearchValue).GetValue(2)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempSearchValue).GetValue(1)));
			}
		}
		public object GetRecord(object pSearchValue, int pay_year, int pay_month)
		{
			SqlDataReader rsLocalRecCol = null;
			int mCntCol = 0;
			int mCntRow = 0;
			int cnt = 0;

			//'''' Re Bind Attendance Grid for selected Month
			//mySQL = " select pay_date from pay_payroll "
			//mySQL = mySQL & " where year(pay_date) =" & pay_year
			//mySQL = mySQL & " and month(pay_date) =" & pay_month
			//mTempSearchValue1 = GetMasterCode(mySQL)
			//mStartdate = DateAdd("m", -1, CDate(mTempSearchValue1)) + 1
			//Call DefineGridColumns(mStartdate, CStr(mTempSearchValue1))
			//'''' End

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

			mHoursPerDay = SystemHRProcedure.GetEmpPerDayHours(ReflectionHelper.GetPrimitiveValue<int>(pSearchValue));
			string mysql = " select pemp.emp_no";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , pemp.l_full_name as empname ";
			}
			else
			{
				mysql = mysql + " , pemp.a_full_name as empname ";
			}
			mysql = mysql + " , pdesg.l_desg_name as designame, pdesg.desg_cd ";
			mysql = mysql + " from  pay_employee pemp ";
			mysql = mysql + " inner join pay_designation pdesg on pemp.desg_cd = pdesg.desg_cd ";
			mysql = mysql + " where pemp.emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);


			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue1 = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue1))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue1() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayEmp[mConTxtEmpNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue1).GetValue(0));
				//UPGRADE_WARNING: (1068) mTempSearchValue1() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayEmpName[mConTxtEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue1).GetValue(1));
				//UPGRADE_WARNING: (1068) mTempSearchValue1() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonTextBox[mConTxtDept].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue1).GetValue(3));
				//UPGRADE_WARNING: (1068) mTempSearchValue1() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[mDisplaylblDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue1).GetValue(2));
				txtDisplayLabel[mDisplaylblYear].Text = pay_year.ToString();
				txtDisplayLabel[mDisplaylblMonth].Tag = pay_month.ToString();
				txtDisplayLabel[mDisplaylblMonth].Text = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(pay_month);
			}

			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = " select ptf.l_field_name as field_name";
			}
			else
			{
				mysql = " select ptf.a_field_name as field_name ";
			}

			mysql = mysql + ",ptf.ta_field_id, ptf.include_in_total_hrs, ptt.remarks, ptt.entry_id, ptf.ta_field_type";
			mysql = mysql + " from pay_ta_trans ptt ";
			mysql = mysql + " inner join   pay_ta_field ptf on ptt.tafield_id = ptf.ta_field_id";
			mysql = mysql + " where (ptt.emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue) + ") ";
			mysql = mysql + " and (ptt.pay_year =" + pay_year.ToString() + " ) ";
			mysql = mysql + " and (ptt.pay_month=" + pay_month.ToString() + ")";
			mysql = mysql + " and ptf.show <> 0";
			mysql = mysql + " group by ptf.l_field_name, ptf.a_field_name";
			mysql = mysql + ",ptt.remarks, ptf.ta_field_id,ptf.include_in_total_hrs, ptt.entry_id,ptf.ta_field_type";
			mysql = mysql + " order by ptf.ta_field_id";

			DataSet rsLocalRecRow = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsLocalRecRow.Tables.Clear();
			adap.Fill(rsLocalRecRow);
			aVoucherDetails.RedimXArray(new int[]{rsLocalRecRow.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
			mCntRow = 0;
			foreach (DataRow iteration_row in rsLocalRecRow.Tables[0].Rows)
			{
				aVoucherDetails.SetValue(iteration_row["Field_name"], mCntRow, mConTAFieldName);
				aVoucherDetails.SetValue(iteration_row["Remarks"], mCntRow, mConRemarks);
				aVoucherDetails.SetValue(iteration_row["Include_In_Total_Hrs"], mCntRow, mConIncludeINCalculationHrs);
				aVoucherDetails.SetValue(iteration_row["ta_field_id"], mCntRow, mConTAFieldID);
				aVoucherDetails.SetValue(iteration_row["ta_field_type"], mCntRow, mConTAFieldType);
				//For Column Sql
				mysql = "select pttd.hrs, pttd.pay_day";
				mysql = mysql + " from  pay_ta_trans ptt";
				mysql = mysql + " inner join pay_ta_trans_detail pttd on ptt.entry_id = pttd.entry_id";
				mysql = mysql + " where (ptt.emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue) + ")";
				mysql = mysql + " and (ptt.TAField_Id =" + Convert.ToString(iteration_row["ta_field_id"]) + ")";
				mysql = mysql + " and ptt.pay_year=" + pay_year.ToString() + " and ptt.pay_month=" + pay_month.ToString();
				mysql = mysql + " order by ptt.entry_id, pttd.Pay_Date";

				SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRecCol = sqlCommand_2.ExecuteReader();
				rsLocalRecCol.Read();
				mCntCol = 2;
				do 
				{
					aVoucherDetails.SetValue(rsLocalRecCol["hrs"], mCntRow, mCntCol);
					mCntCol++;
				}
				while(rsLocalRecCol.Read());

				rsLocalRecCol.Close();
				mCntRow++;
			}

			AssignGridLineNumbers();
			CalculateTotal();
			grdVoucherDetails.Rebind(true);
			GridColorChange();
			grdVoucherDetails.Enabled = true;
			grdVoucherDetails.Refresh();
			FirstFocusObject.Focus();
			return null;
		}

		public bool saveRecord(bool pApprove = false)
		{
			object mReturnValue = null;
			string mysql = "";
			SqlDataReader rsTempRec = null;
			int mCntCol = 0;
			int mCntRow = 0;
			int mCol = 0;
			string mdate = "";
			string mGenerateDate = "";

			try
			{

				SystemVariables.gConn.BeginTransaction();

				mysql = "select   ptt.entry_id";
				mysql = mysql + " from pay_ta_trans ptt";
				mysql = mysql + " inner join pay_ta_field ptf on ptf.ta_field_id = ptt.tafield_id ";
				mysql = mysql + " inner join pay_employee pemp on ptt.emp_cd = pemp.emp_cd";
				mysql = mysql + " where (pemp.emp_no ='" + txtDisplayEmp[mConTxtEmpNo].Text + "') ";
				mysql = mysql + " and (ptt.pay_year =" + txtDisplayLabel[mDisplaylblYear].Text + ") ";
				mysql = mysql + " and (ptt.pay_month = " + Convert.ToString(txtDisplayLabel[mDisplaylblMonth].Tag) + ")";
				mysql = mysql + " and ptf.show = 1 ";
				mysql = mysql + " group by ptt.entry_id";

				mCntRow = 0;
				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsTempRec = sqlCommand.ExecuteReader();
				rsTempRec.Read();
				do 
				{
					// Get Max Column For apply Year and Month
					mysql = "select count(entry_id) as col";
					mysql = mysql + " from pay_ta_trans_detail";
					mysql = mysql + " where Entry_ID=" + Convert.ToString(rsTempRec["Entry_ID"]);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCol = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					//Delete old Record for this month
					mysql = "delete pay_ta_trans_detail";
					mysql = mysql + " where entry_id=" + Convert.ToString(rsTempRec["Entry_ID"]);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
					//generate New Entry on basis of grid rows and column
					mCntCol = 2;

					while(mCntCol <= mCol + 1)
					{
						mdate = DateTimeHelper.ToString(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddDays(mCntCol - 2));
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						SystemHRProcedure.InsertTADetails(Convert.ToInt32(rsTempRec["Entry_ID"]), Convert.ToInt32(aVoucherDetails.GetValue(mCntRow, mCntCol)), Convert.ToInt32(Double.Parse(grdVoucherDetails.Splits[0].DisplayColumns[mCntCol].DataColumn.Caption)), StringsHelper.Format(mdate, SystemVariables.gSystemDateFormat));
						mCntCol++;
					};
					mCntRow++;
				}
				while(rsTempRec.Read());
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempRec.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064

				mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();
				SystemHRProcedure.ClearPayroll(mGenerateDate, txtDisplayEmp[mConTxtEmpNo].Text, txtDisplayEmp[mConTxtEmpNo].Text);
				SystemHRProcedure.GeneratePayrollEntry(mGenerateDate, txtDisplayEmp[mConTxtEmpNo].Text, txtDisplayEmp[mConTxtEmpNo].Text);
				SystemHRProcedure.GenerateLeaveEntry(mGenerateDate, txtDisplayEmp[mConTxtEmpNo].Text, txtDisplayEmp[mConTxtEmpNo].Text);
				SystemHRProcedure.GenerateLoanEntry(mGenerateDate, txtDisplayEmp[mConTxtEmpNo].Text, txtDisplayEmp[mConTxtEmpNo].Text);

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				grdVoucherDetails.Enabled = false;
				return true;
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			return false;
		}

		public void PrintReport()
		{

		}

		public void CloseForm()
		{
			this.Close();
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
					int mgrdCol = 0;
					int mgrdRow = 0;
					int cnt = 0;
					int mCurrentCellHrs = 0;

					mgrdCol = grdVoucherDetails.Col;
					//UPGRADE_WARNING: (1068) grdVoucherDetails.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mgrdRow = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark);
					//UPGRADE_WARNING: (1068) grdVoucherDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCurrentCellHrs = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[ColIndex].Value);

					if (mCurrentCellHrs > mHoursPerDay && Convert.ToBoolean(aVoucherDetails.GetValue(mgrdRow, mConIncludeINCalculationHrs)))
					{
						Cancel = -1;
						return;
					}
					else
					{
						cnt = 0;
					}

					if (Convert.ToBoolean(aVoucherDetails.GetValue(mgrdRow, mConIncludeINCalculationHrs)))
					{
						int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
						for (cnt = 0; cnt <= tempForEndVar; cnt++)
						{
							if (ReflectionHelper.GetPrimitiveValue<int>(OldValue) >= mCurrentCellHrs)
							{
								if (Convert.ToBoolean(aVoucherDetails.GetValue(cnt, mConIncludeINCalculationHrs)) && cnt != mgrdRow)
								{
									aVoucherDetails.SetValue(Convert.ToInt32(aVoucherDetails.GetValue(cnt, mgrdCol)) + (ReflectionHelper.GetPrimitiveValue<int>(OldValue) - mCurrentCellHrs), cnt, mgrdCol);
									aVoucherDetails.SetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[ColIndex].Value), mgrdRow, mgrdCol);
									goto ExitHere;
								}
							}
							else
							{
								if (Convert.ToBoolean(aVoucherDetails.GetValue(cnt, mConIncludeINCalculationHrs)) && cnt != mgrdRow && Convert.ToDouble(aVoucherDetails.GetValue(cnt, mgrdCol)) >= (mCurrentCellHrs - ReflectionHelper.GetPrimitiveValue<int>(OldValue)))
								{
									aVoucherDetails.SetValue(Convert.ToInt32(aVoucherDetails.GetValue(cnt, mgrdCol)) - (mCurrentCellHrs - ReflectionHelper.GetPrimitiveValue<int>(OldValue)), cnt, mgrdCol);
									aVoucherDetails.SetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[ColIndex].Value), mgrdRow, mgrdCol);
									goto ExitHere;
								}
								else
								{
									if (Convert.ToDouble(aVoucherDetails.GetValue(cnt, mgrdCol)) > 0)
									{
										mCurrentCellHrs -= Convert.ToInt32(aVoucherDetails.GetValue(cnt, mgrdCol));
										aVoucherDetails.SetValue(0, cnt, mgrdCol);
									}
								}
							}
						}
					}
					else
					{
						aVoucherDetails.SetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[ColIndex].Value), mgrdRow, mgrdCol);
						//if DayOff Or Public holiday then make all working day zero
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((SystemHRProcedure.enumTAFields) Convert.ToInt32(aVoucherDetails.GetValue(mgrdRow, mConTAFieldID))) == SystemHRProcedure.enumTAFields.eTAPublicHoliday || ((SystemHRProcedure.enumTAFields) Convert.ToInt32(aVoucherDetails.GetValue(mgrdRow, mConTAFieldID))) == SystemHRProcedure.enumTAFields.eTAWeekend)
						{
							if (Convert.ToDouble(aVoucherDetails.GetValue(mgrdRow, mgrdCol)) > 0)
							{
								int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
								for (cnt = 0; cnt <= tempForEndVar2; cnt++)
								{
									if (Convert.ToBoolean(aVoucherDetails.GetValue(cnt, mConIncludeINCalculationHrs)))
									{
										aVoucherDetails.SetValue(0, cnt, mgrdCol);
										//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
										grdVoucherDetails.Splits[0].DisplayColumns[mgrdCol].Style.BackColor = Color.FromArgb(255, 128, 128);
									}
								}
							}
							else
							{
								aVoucherDetails.SetValue(mHoursPerDay, 0, mgrdCol);
								int tempForEndVar3 = aVoucherDetails.GetLength(0) - 1;
								for (cnt = 1; cnt <= tempForEndVar3; cnt++)
								{
									aVoucherDetails.SetValue(0, cnt, mgrdCol);
								}
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								grdVoucherDetails.Splits[0].DisplayColumns[mgrdCol].Style.BackColor = Color.White;
							}
						}
					}
					CalculateTotal();
					ExitHere:
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

		private void GridColorChange()
		{
			int mColCnt = 0;
			int mRowCnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (mRowCnt = 0; mRowCnt <= tempForEndVar; mRowCnt++)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((SystemHRProcedure.enumTAFields) Convert.ToInt32(aVoucherDetails.GetValue(mRowCnt, mConTAFieldID))) == SystemHRProcedure.enumTAFields.eTAWeekend || ((SystemHRProcedure.enumTAFields) Convert.ToInt32(aVoucherDetails.GetValue(mRowCnt, mConTAFieldID))) == SystemHRProcedure.enumTAFields.eTAPublicHoliday)
				{
					for (mColCnt = 2; mColCnt <= 32; mColCnt++)
					{
						if (Convert.ToDouble(aVoucherDetails.GetValue(mRowCnt, mColCnt)) > 0)
						{
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							grdVoucherDetails.Splits[0].DisplayColumns[mColCnt].Style.BackColor = Color.FromArgb(255, 128, 128);
						}
					}
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			//UPGRADE_WARNING: (1068) grdVoucherDetails.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int grdRow = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark);
			if (Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Bookmark), mConTAFieldType)).ToUpper() == "B")
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
			int mColCnt = 0;
			int mRowCnt = 0;
			double mTotal = 0;
			int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
			for (mColCnt = 0; mColCnt <= tempForEndVar; mColCnt++)
			{
				mTotal = 0;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property grdVoucherDetails.Columns.Item.ColIndex was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (grdVoucherDetails.Splits[0].DisplayColumns[mColCnt].getColIndex() >= 2 && grdVoucherDetails.Splits[0].DisplayColumns[mColCnt].getColIndex() <= 32)
				{
					int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
					for (mRowCnt = 0; mRowCnt <= tempForEndVar2; mRowCnt++)
					{
						if (Convert.ToString(aVoucherDetails.GetValue(mRowCnt, mConTAFieldType)) != "B")
						{
							mTotal += Convert.ToDouble(aVoucherDetails.GetValue(mRowCnt, mColCnt));
						}
					}
					grdVoucherDetails.Columns[mColCnt].FooterText = mTotal.ToString();
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mColCnt].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mColCnt].FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
				}
			}
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
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
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
					if (Convert.ToString(aVoucherDetails.GetValue(mRow, mConTAFieldType)).ToUpper() == "B")
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

				if (Convert.ToString(aVoucherDetails.GetValue(grdVoucherDetails.Row, mConTAFieldType)).ToUpper() == "B")
				{
					if (ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[Col].Value) == 0)
					{
						grdVoucherDetails.Columns[Col].Value = 1;
						int tempRefParam = 0;
						grdVoucherDetails_BeforeColUpdate(grdVoucherDetails, new C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs());
					}
					else
					{
						grdVoucherDetails.Columns[Col].Value = 0;
						int tempRefParam2 = 0;
						grdVoucherDetails_BeforeColUpdate(grdVoucherDetails, new C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs());
					}
					grdVoucherDetails.UpdateData();
					grdVoucherDetails.Refresh();
				}
			}
			catch
			{
			}
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}