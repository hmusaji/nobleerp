
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayHoliday
		: System.Windows.Forms.Form
	{

		public frmPayHoliday()
{
InitializeComponent();
} 
 public  void frmPayHoliday_old()
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


		private void frmPayHoliday_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private const int conMaxColumns = 1;
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
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		private const int mConDateFrom = 0; //Textbox index no
		private const int mConDateTo = 1; //Textbox index no
		private const int mconLineNo = 0; //grid Column No
		private const int mCondate = 1; //grid Column No


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



		private void cmdGenerate_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				string mysql = "";
				object mReturnValue = null;
				int mCnt = 0;
				string mDatefrom = "";

				if (DateTime.Parse(txtCommonDate[mConDateFrom].Text) < DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()))
				{
					MessageBox.Show("You can not enter record for previous month", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				if (DateTime.Parse(txtCommonDate[mConDateFrom].Text) > DateTime.Parse(txtCommonDate[mConDateTo].Text))
				{
					MessageBox.Show("From date should be less than To date.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				int tempForEndVar = grdHolidayDetails.Columns.Count - 1;
				for (mCnt = 0; mCnt <= tempForEndVar; mCnt++)
				{
					grdHolidayDetails.Columns[mCnt].FooterText = "";
				}

				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
				DefineVoucherArray(-1, true);
				AssignGridLineNumbers();

				//Insert date in grid if it is not existing
				mCnt = 0;
				//UPGRADE_WARNING: (1068) txtCommonDate().DisplayText of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mDatefrom = ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[mConDateFrom].DisplayText);
				while (DateTime.Parse(mDatefrom) <= ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[mConDateTo].DisplayText))
				{
					aVoucherDetails.RedimXArray(new int[]{mCnt, conMaxColumns}, new int[]{0, 0});
					aVoucherDetails.SetValue(mDatefrom, mCnt, mCondate);
					mDatefrom = DateTimeHelper.ToString(DateTime.Parse(mDatefrom).AddDays(1));
					mCnt++;
				}

				AssignGridLineNumbers();
				grdHolidayDetails.Rebind(true);
				grdHolidayDetails.Refresh();
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
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
				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = false;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);
				//assign a next code
				txtHolidayNo.Text = SystemProcedure2.GetNewNumber("pay_holiday", "holiday_no");
				FirstFocusObject = txtHolidayNo;

				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_Calendar")))
				{
					txtCalendarCd.Visible = false;
					txtDlblCalendarName.Visible = false;
					lblCalendar.Visible = false;
					txtCalendarCd.Text = "1";
				}



				SystemGrid.DefineSystemVoucherGrid(grdHolidayDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");

				SystemGrid.DefineSystemVoucherGridColumn(grdHolidayDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdHolidayDetails, "Holiday Date", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "txtHolidayDate");

				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdHolidayDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdHolidayDetails.setArray(aVoucherDetails);
				grdHolidayDetails.Rebind(true);
				//txtCommonDate(mConDateFrom).Value = Date
				//txtCommonDate(mConDateTo).Value = Date
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
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

		private void GetRecord(object pSearchValue)
		{
			int mCnt = 0;

			// Get Master Holiday
			string mysql = "select holiday_no, l_holiday_name, a_holiday_name , pc.calendar_cd , pc.l_calendar_name";
			mysql = mysql + " from pay_holiday ph";
			mysql = mysql + " left outer join pay_calendar pc on ph.calendar_cd = pc.calendar_cd";
			mysql = mysql + " where holiday_cd=" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtHolidayNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtLHolidayName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtAHolidayName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCalendarCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDlblCalendarName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(4));
			}
			else
			{
				return;
			}
			// Get Details Holiday
			DataSet rsLocal = new DataSet();
			mysql = "select holiday_date";
			mysql = mysql + " from pay_holiday_details";
			mysql = mysql + " where holiday_cd=" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsLocal.Tables.Clear();
			adap.Fill(rsLocal);
			aVoucherDetails.RedimXArray(new int[]{rsLocal.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
			mCnt = 0;
			foreach (DataRow iteration_row in rsLocal.Tables[0].Rows)
			{
				aVoucherDetails.SetValue(iteration_row["holiday_date"], mCnt, mCondate);
				mCnt++;
			}

			AssignGridLineNumbers();
			grdHolidayDetails.Rebind(true);
			grdHolidayDetails.Refresh();
			CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
		}

		public void findRecord()
		{
			System.DateTime mGenerateDate = DateTime.FromOADate(0);

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7063000));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}

		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtCalendarCd" : 
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
					break;
				default:
					return;
			}

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

				int tempForEndVar = grdHolidayDetails.Columns.Count - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					grdHolidayDetails.Columns[cnt].FooterText = "";
				}

				SystemProcedure2.ClearTextBox(this);
				DefineVoucherArray(-1, true);
				AssignGridLineNumbers();
				txtHolidayNo.Text = SystemProcedure2.GetNewNumber("pay_holiday", "holiday_no");

				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_Calendar")))
				{
					txtCalendarCd.Visible = false;
					txtDlblCalendarName.Visible = false;
					lblCalendar.Visible = false;
					txtCalendarCd.Text = "1";
				}

				grdHolidayDetails.Rebind(true);
				mSearchValue = ""; //Change the msearchvalue to blank
				FirstFocusObject.Focus();
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}

		}

		public bool saveRecord()
		{
			bool result = false;
			string mysql = "";
			object mReturnValue = null;
			int mCnt = 0;
			try
			{

				SystemVariables.gConn.BeginTransaction();
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into pay_holiday(holiday_no, l_holiday_name , a_holiday_name ";
					mysql = mysql + ", user_cd , calendar_cd )";
					mysql = mysql + " values('" + txtHolidayNo.Text + "'";
					mysql = mysql + ",'" + txtLHolidayName.Text + "'";
					mysql = mysql + ",N'" + txtAHolidayName.Text + "'";
					mysql = mysql + "," + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + "," + txtCalendarCd.Text;
					mysql = mysql + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mysql = " select scope_identity()";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mSearchValue = ReflectionHelper.GetPrimitiveValue(mReturnValue);
					}
					else
					{
						result = false;
						mSearchValue = "";
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return result;
					}
				}
				else
				{
					mysql = " update pay_holiday";
					mysql = mysql + " set holiday_no='" + txtHolidayNo.Text + "'";
					mysql = mysql + " , l_holiday_name='" + txtLHolidayName.Text + "'";
					mysql = mysql + " , a_holiday_name=N'" + txtAHolidayName.Text + "'";
					mysql = mysql + " , modified_by_user_cd=" + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " , modified_date_time='" + DateTime.Now.ToString("dd/MMM/yyyy") + "'";
					mysql = mysql + " , calendar_cd =" + txtCalendarCd.Text;
					mysql = mysql + " where holiday_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}

				mysql = "delete from pay_holiday_details ";
				mysql = mysql + " where holiday_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (mCnt = 0; mCnt <= tempForEndVar; mCnt++)
				{
					mysql = " insert into pay_holiday_details(holiday_cd, holiday_date)";
					mysql = mysql + " values ( " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					mysql = mysql + ",'" + Convert.ToDateTime(aVoucherDetails.GetValue(mCnt, mCondate)).ToString("dd/MMM/yyyy") + "')";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();
				}
				if (!SystemHRProcedure.UpdatePublicHolidayInTimeAttendance())
				{
					//gConn.RollbackTrans
					throw new Exception();
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
			}
			return result;
		}

		public bool CheckDataValidity()
		{
			//Check validation during update and add of records
			if (SystemProcedure2.IsItEmpty(txtHolidayNo.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Holiday Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstFocusObject.Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtLHolidayName.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Holiday Name !!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtLHolidayName.Focus();
				return false;
			}
			return true;
		}

		public bool deleteRecord()
		{

			bool result = false;
			string mysql = " select protected from pay_holiday where holiday_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
				{
					MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				//If an error occurs, trap the error and dispaly a valid message
				SystemVariables.gConn.BeginTransaction();

				mysql = "delete from pay_holiday_details where holiday_cd=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mysql = " delete from pay_holiday where holiday_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Holiday cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
			}

			return result;
		}
		public void IRoutine()
		{
			int mCurrentLineNo = 0;

			if (ActiveControl.Name != "grdHolidayDetails" && grdHolidayDetails.Enabled)
			{
				grdHolidayDetails.Focus();
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdHolidayDetails.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdHolidayDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdHolidayDetails.Columns[mconLineNo].Value);
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdHolidayDetails.Bookmark), 1);
				AssignGridLineNumbers();
				grdHolidayDetails.Rebind(true);
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdHolidayDetails" && grdHolidayDetails.Enabled)
			{
				grdHolidayDetails.Focus();
			}

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdHolidayDetails.Delete();
				AssignGridLineNumbers();
				grdHolidayDetails.Rebind(true);
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
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}