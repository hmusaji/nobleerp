
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayProjectAttandance
		: System.Windows.Forms.Form
	{

		public frmPayProjectAttandance()
{
InitializeComponent();
} 
 public  void frmPayProjectAttandance_old()
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


		private void frmPayProjectAttandance_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private clsToolbar oThisFormToolBar = null;
		int mThisFormID = 0;
		bool mFirstGridFocus = false;
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
		public bool mProjectFirstGridFocus = false;
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

		private DataSet _rsBillingCodeList1 = null;
		private DataSet rsBillingCodeList1
		{
			get
			{
				if (_rsBillingCodeList1 is null)
				{
					_rsBillingCodeList1 = new DataSet();
				}
				return _rsBillingCodeList1;
			}
			set
			{
				_rsBillingCodeList1 = value;
			}
		}


		private const int grdLineNoColumn = 0;
		private const int grdEmpCodeColumn = 1;
		private const int grdEmpNameColumn = 2;
		private const int grdWorkingHrs = 3;
		private const int grdWHProject = 4;
		private const int grdDayoff = 5;
		private const int grdNOT = 6;
		private const int grdNOTProject = 7;
		private const int grdFOT = 8;
		private const int grdFOTProject = 9;
		private const int grdHOT = 10;
		private const int grdHOTProject = 11;
		private const int grdOTAMTYN = 12;
		private const int grdOTAMT = 13;
		private const int grdOTAMTProject = 14;
		private const int grdLineNo = 15;
		private const int grdHoursPerDay = 16;
		private const int grdEmpStatus = 17;
		private const int grdAllowOT = 18;
		private const int grdIsPosted = 19;
		private const int conMaxColumns = 20;

		private const int conCmbEmpType = 0;


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


		private void cmbCommon_Leave(Object eventSender, EventArgs eventArgs)
		{
			mFirstGridFocus = true;
			mProjectFirstGridFocus = true;
		}

		private void cmdGetRecord_Click(Object eventSender, EventArgs eventArgs)
		{
			string mSQL = "";
			int mProjectcd = 0;
			int i = 0;
			int mPosition = 0;
			string mProjectStr = "";


			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mDays = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("No_Of_Days_For_Project_Attendance"));
			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mBeforeDays = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Project_Attendance_Entry_Before_No_Of_Days"));

			int mEmpType = cmbCommon[conCmbEmpType].GetItemData(cmbCommon[conCmbEmpType].ListIndex);
			object mTempValue = SystemHRProcedure.ProjectString();

			if (SystemProcedure2.IsItEmpty(mTempValue, SystemVariables.DataType.StringType))
			{
				mProjectcd = GetProjectCd(txtProjectNo.Text);
			}
			else
			{
				mProjectcd = GetProjectCd(txtProjectNo.Text, ReflectionHelper.GetPrimitiveValue<string>(mTempValue));
			}

			if (mDays > 0)
			{
				if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDAttandanceDate.Value) < DateTime.Today.AddDays(mDays * -1) || ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDAttandanceDate.Value) > DateTime.Today.AddDays(mBeforeDays))
				{
					MessageBox.Show("You cannot enter attrendance for this day. Please contact your administrator.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				else
				{
					txtDAttandanceDate.Enabled = false;
					cmbCommon[conCmbEmpType].Enabled = false;
					txtProjectNo.Enabled = false;
				}
			}
			else
			{
				txtDAttandanceDate.Enabled = false;
				cmbCommon[conCmbEmpType].Enabled = false;
				txtProjectNo.Enabled = false;
			}

			if (mProjectcd == 0)
			{
				MessageBox.Show("Please Check Project No !!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			FillGridData(ReflectionHelper.GetPrimitiveValue<string>(txtDAttandanceDate.Value), mProjectcd, mEmpType);
			if (mFirstGridFocus)
			{
				grdProjectAttendance_GotFocus(grdProjectAttendance, new EventArgs());
			}
			if (mProjectFirstGridFocus)
			{
				grdProjectAttendance_GotFocus(grdProjectAttendance, new EventArgs());
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
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}
				if (KeyCode == ((int) Keys.F2))
				{
					if (Support.GetActiveControl().Name == grdProjectAttendance.Name)
					{
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831"));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							if (!FindEmployeeCode(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1))))
							{
								MessageBox.Show(" Could not locate the specific Employee Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}
						}
						return;
					}
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
				bool mEnableDayoff = false;

				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_Project_Attendance_DeleteLine")))
				{
					oThisFormToolBar.ShowDeleteLineButton = true;
				}
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;
				oThisFormToolBar.ShowCheckAllButton = true;
				oThisFormToolBar.ShowUncheckAllButton = true;

				this.WindowState = FormWindowState.Maximized;
				//Set FirstFocusObject = grdVoucherDetails
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEnableDayoff = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_DayOff_Project_Attendance"));

				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdProjectAttendance, false, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "Emp No", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "Emp Name", 2700, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "Woking Hrs", 900, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "Project", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMastersList1");
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "Day Off", 600, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, mEnableDayoff, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "NOT", 900, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true, 100, "", "", false, "", 0, false, 1110);
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "NOTProject", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMastersList1");
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "FOT", 900, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true, 100, "", "", false, "", 0, false, 1114);
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "FOTProject", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMastersList1");
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "HOT", 900, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true, 100, "", "", false, "", 0, false, 1119);
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "HOTProject", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMastersList1");
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "OT Amt", 600, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "OT AMT", 900, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "AMTProject", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMastersList1");
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "LineNo", 100, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "HoursPerDay", 100, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "EmpStatus", 100, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "AllowOT", 100, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdProjectAttendance, "IsPosted", 100, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				mFirstGridFocus = true;
				mProjectFirstGridFocus = true;
				//Fill the combo
				object[] mObjectId = new object[1];
				mObjectId[0] = 1013;

				SystemCombo.FillComboWithSystemObjects(cmbCommon, mObjectId);

				SystemProcedure.SetLabelCaption(this);

				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdProjectAttendance.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdProjectAttendance.setArray(aVoucherDetails);
				grdProjectAttendance.Rebind(true);
				txtDAttandanceDate.Value = DateTime.Today;
				//''If gLoggedInUserCode = 1 Then
				//''  txtDAttandanceDate.Enabled = True
				//''Else
				//''  txtDAttandanceDate.Enabled = False
				//''End If
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
				aVoucherDetails.SetValue(cnt + 1, cnt, grdLineNoColumn);
			}
		}

		private object FillGridData(string pDate, int pProjectCd, int pEmpType)
		{
			try
			{
				StringBuilder mysql = new StringBuilder();
				int mProjectcd = 0;
				int mEmployeeType = 0;
				SqlDataReader rs = null;
				int mCntRow = 0;


				mysql = new StringBuilder(" select pptd.line_no , pptd.emp_cd  , pemp.emp_no , pemp.l_full_name , whrs , gpwh.project_no as whproject_no ,[not]");
				mysql.Append(" , gpnot.project_no as notproject_no,FOT ,gpfot.project_no as FOTProject_no , HOT ,gphot.project_no as HOTProject_no");
				mysql.Append(" , pemp.general_OT_amt as GOT , gpgot.project_no as GOTProject_no, pemp.hours_per_day , pptd.general_OT_amt ");
				mysql.Append(" , pptd.Is_Posted , pptd.Deduction_Hrs , pemp.allow_overtime , pptd.Is_Dayoff");
				mysql.Append(" from pay_project_ta_details pptd");
				mysql.Append(" inner join pay_employee pemp on pemp.emp_cd = pptd.emp_cd");
				mysql.Append(" left outer join gl_projects gpwh on gpwh.project_cd = pptd.whproject_cd");
				mysql.Append(" left outer join gl_projects gpnot on gpnot.project_cd = pptd.notproject_cd");
				mysql.Append(" left outer join gl_projects gpfot on gpfot.project_cd = pptd.FOTProject_Cd");
				mysql.Append(" left outer join gl_projects gphot on gphot.project_cd = pptd.HOTProject_Cd");
				mysql.Append(" left outer join gl_projects gpgot on gpgot.project_cd = pptd.GOTProject_Cd");
				mysql.Append(" Where pemp.default_project = " + pProjectCd.ToString());
				mysql.Append(" and pemp.rate_calc_method_id = " + pEmpType.ToString());
				mysql.Append(" and pptd.pay_date = '" + pDate + "'");
				mysql.Append(" and (pemp.Termination_date is null or pemp.Termination_date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtDAttandanceDate.Value) + "')");
				mysql.Append(" order by pemp.emp_no");
				mCntRow = 0;
				SqlCommand sqlCommand = new SqlCommand(mysql.ToString(), SystemVariables.gConn);
				rs = sqlCommand.ExecuteReader();
				rs.Read();
				do 
				{
					if (!SystemHRProcedure.IsEmployeeOnLeave(Convert.ToInt32(rs["emp_cd"]), pDate, 1))
					{
						aVoucherDetails.RedimXArray(new int[]{aVoucherDetails.GetLength(0), conMaxColumns}, new int[]{0, 0});
						aVoucherDetails.SetValue(rs["emp_no"], mCntRow, grdEmpCodeColumn);
						aVoucherDetails.SetValue(rs["l_full_name"], mCntRow, grdEmpNameColumn);
						aVoucherDetails.SetValue(rs["whrs"], mCntRow, grdWorkingHrs);
						aVoucherDetails.SetValue(rs["whproject_no"], mCntRow, grdWHProject);
						aVoucherDetails.SetValue(rs["Is_Dayoff"], mCntRow, grdDayoff);
						aVoucherDetails.SetValue(rs["NOT"], mCntRow, grdNOT);
						aVoucherDetails.SetValue(Convert.ToString(rs["NOTproject_no"]) + "", mCntRow, grdNOTProject);
						aVoucherDetails.SetValue(rs["FOT"], mCntRow, grdFOT);
						aVoucherDetails.SetValue(Convert.ToString(rs["FOTproject_no"]) + "", mCntRow, grdFOTProject);
						aVoucherDetails.SetValue(rs["HOT"], mCntRow, grdHOT);
						aVoucherDetails.SetValue(Convert.ToString(rs["HOTproject_no"]) + "", mCntRow, grdHOTProject);
						aVoucherDetails.SetValue(rs["GOT"], mCntRow, grdOTAMT);
						aVoucherDetails.SetValue(rs["general_OT_amt"], mCntRow, grdOTAMTYN);
						aVoucherDetails.SetValue(Convert.ToString(rs["GOTproject_no"]) + "", mCntRow, grdOTAMTProject);
						aVoucherDetails.SetValue(rs["line_no"], mCntRow, grdLineNo);
						aVoucherDetails.SetValue(rs["hours_per_day"], mCntRow, grdHoursPerDay);
						aVoucherDetails.SetValue((Convert.ToDouble(rs["Deduction_Hrs"]) > 0) ? 2 : 1, mCntRow, grdEmpStatus);
						aVoucherDetails.SetValue((Convert.ToBoolean(rs["allow_overtime"])) ? 1 : 0, mCntRow, grdAllowOT);
						aVoucherDetails.SetValue((Convert.ToBoolean(rs["Is_Posted"])) ? 1 : 0, mCntRow, grdIsPosted);
						mCntRow++;
					}
					else
					{
						mysql = new StringBuilder("delete from pay_project_ta_details ");
						mysql.Append(" where line_no = " + Convert.ToString(rs["line_no"]));
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql.ToString();
						TempCommand.ExecuteNonQuery();
					}
				}
				while(rs.Read());
				rs.Close();

				//Set rs = Nothing
				mysql = new StringBuilder(" select emp_cd , emp_no , l_full_name, hours_per_day , status_cd");
				mysql.Append(" ,Hours_per_day as WH ,'" + txtProjectNo.Text + "' as WHP,0 as [NOT],'" + txtProjectNo.Text + "' as NOTP,0 as FOT,'" + txtProjectNo.Text + "' as FOTP,0 as HOT");
				mysql.Append(" , '" + txtProjectNo.Text + "' as HOTP, General_OT_Amt as GOT ,'" + txtProjectNo.Text + "' as GOTP, allow_overtime");
				mysql.Append(" From pay_employee");
				mysql.Append(" where emp_cd not in ( select emp_cd from pay_project_ta_details where Pay_date ='" + pDate + "')");
				mysql.Append(" and rate_calc_method_id = " + pEmpType.ToString());
				mysql.Append(" and default_project = " + pProjectCd.ToString());
				//mySQL = mySQL & " and status_cd not in (" & gStatusOnHold & "," & gStatusTerminated & ")"
				mysql.Append(" and (Termination_date is null or Termination_date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtDAttandanceDate.Value) + "')");
				mysql.Append(" and Date_Of_Joining <= '" + ReflectionHelper.GetPrimitiveValue<string>(txtDAttandanceDate.Value) + "'");
				mysql.Append(" order by emp_no");

				SqlCommand sqlCommand_2 = new SqlCommand(mysql.ToString(), SystemVariables.gConn);
				rs = sqlCommand_2.ExecuteReader();
				bool rsDidRead2 = rs.Read();
				do 
				{
					if (!SystemHRProcedure.IsEmployeeOnLeave(Convert.ToInt32(rs["emp_cd"]), pDate, Convert.ToInt32(rs["Status_cd"])))
					{
						aVoucherDetails.RedimXArray(new int[]{aVoucherDetails.GetLength(0), conMaxColumns}, new int[]{0, 0});
						aVoucherDetails.SetValue(rs["emp_no"], mCntRow, grdEmpCodeColumn);
						aVoucherDetails.SetValue(rs["l_full_name"], mCntRow, grdEmpNameColumn);
						aVoucherDetails.SetValue(rs["wh"], mCntRow, grdWorkingHrs);
						aVoucherDetails.SetValue(rs["WHP"], mCntRow, grdWHProject);
						aVoucherDetails.SetValue(0, mCntRow, grdDayoff);
						aVoucherDetails.SetValue(rs["NOT"], mCntRow, grdNOT);
						aVoucherDetails.SetValue(rs["NOTP"], mCntRow, grdNOTProject);
						aVoucherDetails.SetValue(rs["FOT"], mCntRow, grdFOT);
						aVoucherDetails.SetValue(rs["FOTP"], mCntRow, grdFOTProject);
						aVoucherDetails.SetValue(rs["HOT"], mCntRow, grdHOT);
						aVoucherDetails.SetValue(rs["HOTP"], mCntRow, grdHOTProject);
						aVoucherDetails.SetValue(rs["GOT"], mCntRow, grdOTAMT);
						aVoucherDetails.SetValue(0, mCntRow, grdOTAMTYN);
						aVoucherDetails.SetValue(rs["GOTP"], mCntRow, grdOTAMTProject);
						aVoucherDetails.SetValue(0, mCntRow, grdLineNo);
						aVoucherDetails.SetValue(rs["hours_per_day"], mCntRow, grdHoursPerDay);
						aVoucherDetails.SetValue(rs["Status_cd"], mCntRow, grdEmpStatus);
						aVoucherDetails.SetValue((Convert.ToBoolean(rs["allow_overtime"])) ? 1 : 0, mCntRow, grdAllowOT);
						aVoucherDetails.SetValue(0, mCntRow, grdIsPosted);
						mCntRow++;
					}
				}
				while(rs.Read());
				rs.Close();
				CalculateTotal();
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdProjectAttendance.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdProjectAttendance.setArray(aVoucherDetails);
				grdProjectAttendance.Rebind(true);
				grdProjectAttendance.Refresh();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			return null;
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

				int tempForEndVar = grdProjectAttendance.Columns.Count - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					grdProjectAttendance.Columns[cnt].FooterText = "";
				}

				txtDAttandanceDate.Enabled = true;
				cmbCommon[conCmbEmpType].Enabled = true;
				txtProjectNo.Enabled = true;

				SystemProcedure2.ClearTextBox(this);
				DefineVoucherArray(-1, true);
				AssignGridLineNumbers();
				grdProjectAttendance.Rebind(true);
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}
		}

		private void CalculateTotal()
		{
			int mColCnt = 0;
			int mRowCnt = 0;
			double mTotal = 0;
			int tempForEndVar = grdProjectAttendance.Columns.Count - 1;
			for (mColCnt = 0; mColCnt <= tempForEndVar; mColCnt++)
			{
				mTotal = 0;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property grdProjectAttendance.Columns.Item.ColIndex was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (grdProjectAttendance.Splits[0].DisplayColumns[mColCnt].getColIndex() == grdWorkingHrs || grdProjectAttendance.Splits[0].DisplayColumns[mColCnt].getColIndex() == grdNOT || grdProjectAttendance.Splits[0].DisplayColumns[mColCnt].getColIndex() == grdFOT || grdProjectAttendance.Splits[0].DisplayColumns[mColCnt].getColIndex() == grdHOT || grdProjectAttendance.Splits[0].DisplayColumns[mColCnt].getColIndex() == grdOTAMT)
				{
					int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
					for (mRowCnt = 0; mRowCnt <= tempForEndVar2; mRowCnt++)
					{
						mTotal += ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mRowCnt, mColCnt), SystemVariables.DataType.NumberType)) ? 0 : Convert.ToDouble(aVoucherDetails.GetValue(mRowCnt, mColCnt)));
					}
					grdProjectAttendance.Columns[mColCnt].FooterText = mTotal.ToString();
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdProjectAttendance.Splits[0].DisplayColumns[mColCnt].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdProjectAttendance.Splits[0].DisplayColumns[mColCnt].FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
				}
			}
		}

		public bool saveRecord(bool pApprove = false)
		{
			bool result = false;
			StringBuilder mysql = new StringBuilder();
			int mProjectcd = 0;

			grdProjectAttendance.UpdateData();
			int mCnt = 0;
			string mString = "";
			SystemVariables.gConn.BeginTransaction();

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (mCnt = 0; mCnt <= tempForEndVar; mCnt++)
			{
				if (!SystemHRProcedure.IsEmployeeOnLeave(SystemHRProcedure.GetEmpCd(Convert.ToString(aVoucherDetails.GetValue(mCnt, grdEmpCodeColumn))), ReflectionHelper.GetPrimitiveValue<string>(txtDAttandanceDate.DisplayText), 1))
				{
					if (Convert.ToDouble(aVoucherDetails.GetValue(mCnt, grdLineNo)) == 0)
					{
						mysql = new StringBuilder(" insert into pay_project_ta_details");
						mysql.Append(" (emp_cd,pay_date,whrs,whproject_cd,[not],notproject_cd,fot,fotproject_cd,hot,hotproject_cd,got,gotproject_cd");
						mysql.Append(" ,created_user_cd,created_user_datetime,");
						mysql.Append(" General_OT_Amt, deduction_hrs,is_dayoff)");
						mysql.Append(" Values( " + SystemHRProcedure.GetEmpCd(Convert.ToString(aVoucherDetails.GetValue(mCnt, grdEmpCodeColumn))).ToString());
						mysql.Append(" , ' " + ReflectionHelper.GetPrimitiveValue<string>(txtDAttandanceDate.Value) + "'");
						mysql.Append(" , " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCnt, grdWorkingHrs), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(mCnt, grdWorkingHrs))));
						mProjectcd = GetProjectCd(Convert.ToString(aVoucherDetails.GetValue(mCnt, grdWHProject)));
						if (mProjectcd != 0)
						{
							mysql.Append(" , " + mProjectcd.ToString());
						}
						else
						{
							MessageBox.Show("Check project code for working hours in line no : " + (mCnt + 1).ToString(), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							return result;
						}
						mysql.Append(" , " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCnt, grdNOT), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(mCnt, grdNOT))));
						mProjectcd = GetProjectCd(Convert.ToString(aVoucherDetails.GetValue(mCnt, grdNOTProject)));
						if (mProjectcd != 0)
						{
							mysql.Append(" , " + mProjectcd.ToString());
						}
						else
						{
							mysql.Append(" , NULL");
						}
						mysql.Append(" , " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCnt, grdFOT), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(mCnt, grdFOT))));
						mProjectcd = GetProjectCd(Convert.ToString(aVoucherDetails.GetValue(mCnt, grdFOTProject)));
						if (mProjectcd != 0)
						{
							mysql.Append(" , " + mProjectcd.ToString());
						}
						else
						{
							mysql.Append(" , NULL");
						}
						mysql.Append(" , " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCnt, grdHOT), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(mCnt, grdHOT))));
						mProjectcd = GetProjectCd(Convert.ToString(aVoucherDetails.GetValue(mCnt, grdHOTProject)));
						if (mProjectcd != 0)
						{
							mysql.Append(" , " + mProjectcd.ToString());
						}
						else
						{
							mysql.Append(" , NULL");
						}
						mysql.Append(" , " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCnt, grdOTAMT), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(mCnt, grdOTAMT))));
						mProjectcd = GetProjectCd(Convert.ToString(aVoucherDetails.GetValue(mCnt, grdOTAMTProject)));
						if (mProjectcd != 0)
						{
							mysql.Append(" , " + mProjectcd.ToString());
						}
						else
						{
							mysql.Append(" , NULL");
						}
						mysql.Append("," + SystemVariables.gLoggedInUserCode.ToString());
						mysql.Append(",'" + DateTime.Today.ToString("dd-MMM-yyyy") + "'");
						mysql.Append("," + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCnt, grdOTAMTYN), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(mCnt, grdOTAMTYN))));
						if (Convert.ToDouble(aVoucherDetails.GetValue(mCnt, grdEmpStatus)) == SystemHRProcedure.gStatusOnLeave)
						{
							mysql.Append(" , " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCnt, grdWorkingHrs), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(mCnt, grdWorkingHrs))));
						}
						else
						{
							mysql.Append(" , 0");
						}
						mysql.Append("," + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCnt, grdDayoff), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(mCnt, grdDayoff))));
						mysql.Append(")");
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql.ToString();
						TempCommand.ExecuteNonQuery();
					}
					else if (Convert.ToDouble(aVoucherDetails.GetValue(mCnt, grdIsPosted)) == 0)
					{ 

						mysql = new StringBuilder(" update pay_project_ta_details ");
						mysql.Append(" set emp_cd = " + SystemHRProcedure.GetEmpCd(Convert.ToString(aVoucherDetails.GetValue(mCnt, grdEmpCodeColumn))).ToString());
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mysql.Append(" ,whrs = " + ((Convert.IsDBNull(aVoucherDetails.GetValue(mCnt, grdWorkingHrs))) ? "0" : Convert.ToString(aVoucherDetails.GetValue(mCnt, grdWorkingHrs))));
						mProjectcd = GetProjectCd(Convert.ToString(aVoucherDetails.GetValue(mCnt, grdWHProject)));
						if (mProjectcd != 0)
						{
							mysql.Append(" , whproject_cd = " + mProjectcd.ToString());
						}
						else
						{
							MessageBox.Show("Check project code for working hours in line no : " + (mCnt + 1).ToString(), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							return result;
						}
						mysql.Append(" ,Is_DayOff = " + ((!Convert.ToBoolean(aVoucherDetails.GetValue(mCnt, grdDayoff))) ? 0 : 1).ToString()); //Dayoff
						mysql.Append(" ,[not] = " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCnt, grdNOT), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(mCnt, grdNOT))));
						mProjectcd = GetProjectCd(Convert.ToString(aVoucherDetails.GetValue(mCnt, grdNOTProject)));
						if (mProjectcd != 0)
						{
							mysql.Append(" , notproject_cd = " + mProjectcd.ToString());
						}
						else
						{
							mysql.Append(" , notproject_cd = NULL");
						}
						mysql.Append(" , fot = " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCnt, grdFOT), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(mCnt, grdFOT))));
						mProjectcd = GetProjectCd(Convert.ToString(aVoucherDetails.GetValue(mCnt, grdFOTProject)));
						if (mProjectcd != 0)
						{
							mysql.Append(" , fotproject_cd = " + mProjectcd.ToString());
						}
						else
						{
							mysql.Append(" , fotproject_cd = NULL");
						}
						mysql.Append(" , hot = " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCnt, grdHOT), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(mCnt, grdHOT))));
						mProjectcd = GetProjectCd(Convert.ToString(aVoucherDetails.GetValue(mCnt, grdHOTProject)));
						if (mProjectcd != 0)
						{
							mysql.Append(" , hotproject_cd = " + mProjectcd.ToString());
						}
						else
						{
							mysql.Append(" ,  hotproject_cd = NULL");
						}
						mysql.Append(" , got = " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCnt, grdOTAMT), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(mCnt, grdOTAMT))));
						mProjectcd = GetProjectCd(Convert.ToString(aVoucherDetails.GetValue(mCnt, grdOTAMTProject)));
						if (mProjectcd != 0)
						{
							mysql.Append(" , gotproject_cd = " + mProjectcd.ToString());
						}
						else
						{
							mysql.Append(" , gotproject_cd = NULL");
						}
						mysql.Append(",Updated_User_cd = " + SystemVariables.gLoggedInUserCode.ToString());
						mysql.Append(", Updated_User_Datetime ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "'");
						mysql.Append(", General_OT_Amt = " + ((!Convert.ToBoolean(aVoucherDetails.GetValue(mCnt, grdOTAMTYN))) ? 0 : 1).ToString());
						if (Convert.ToDouble(aVoucherDetails.GetValue(mCnt, grdEmpStatus)) == SystemHRProcedure.gStatusOnLeave)
						{
							mysql.Append(" , Deduction_Hrs = " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCnt, grdWorkingHrs), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(mCnt, grdWorkingHrs))));
						}
						else
						{
							mysql.Append(" , Deduction_Hrs = 0");
						}
						mysql.Append(" where line_no = " + Convert.ToString(aVoucherDetails.GetValue(mCnt, grdLineNo)));
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql.ToString();
						TempCommand_2.ExecuteNonQuery();
					}
					else
					{
						mString = mString + Convert.ToString(aVoucherDetails.GetValue(mCnt, grdEmpCodeColumn)) + " , "; // & " Record for Employee No "  & " For this date is already imported in payroll!"
					}
				}
			}
			if (Strings.Len(mString) > 0)
			{
				MessageBox.Show(" Record for Employee No " + mString + " For this date is already imported in payroll!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			return true;

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			MessageBox.Show(Information.Err().Number.ToString() + Information.Err().Description, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			return result;
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdProjectAttendance.Col)
			{
				case grdEmpCodeColumn : case grdEmpNameColumn : 
					if (grdProjectAttendance.Col == grdEmpCodeColumn)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("emp_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("emp_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("name");
					} 
					 
					int tempForEndVar = cmbMastersList.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersList.Splits[0].DisplayColumns[cnt];
						if (cnt < 4)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdProjectAttendance.Col == grdEmpCodeColumn) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdProjectAttendance.Splits[0].DisplayColumns[grdEmpCodeColumn].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdProjectAttendance.Col == grdEmpCodeColumn) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdProjectAttendance.Splits[0].DisplayColumns[grdEmpNameColumn].Width;
							}
							withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							withVar.Visible = true;
							cmbMastersList.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					cmbMastersList.Width += 17; 
					cmbMastersList.Height = 167; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			switch(grdProjectAttendance.Col)
			{
				case grdEmpCodeColumn : case grdEmpNameColumn : 
					if (grdProjectAttendance.Col == grdEmpCodeColumn)
					{
						grdProjectAttendance.Col = grdEmpNameColumn;
					}
					else
					{
						grdProjectAttendance.Col = grdEmpCodeColumn;
					} 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			try
			{
				if (grdProjectAttendance.Col == grdEmpCodeColumn)
				{
					grdProjectAttendance.Columns[grdEmpNameColumn].Value = cmbMastersList.Columns[1].Value;
				}
				else if (grdProjectAttendance.Col == grdEmpNameColumn)
				{ 
					grdProjectAttendance.Columns[grdEmpCodeColumn].Value = cmbMastersList.Columns[0].Value;
				}
				grdProjectAttendance.Columns[grdWHProject].Value = txtProjectNo.Text;
				grdProjectAttendance.Columns[grdHoursPerDay].Value = cmbMastersList.Columns[2].Value;
				grdProjectAttendance.Columns[grdAllowOT].Value = cmbMastersList.Columns[3].Value;
				grdProjectAttendance.Columns[grdWorkingHrs].Value = 0;
				grdProjectAttendance.Columns[grdNOT].Value = 0;
				grdProjectAttendance.Columns[grdNOTProject].Value = txtProjectNo.Text;
				grdProjectAttendance.Columns[grdFOT].Value = 0;
				grdProjectAttendance.Columns[grdFOTProject].Value = txtProjectNo.Text;
				grdProjectAttendance.Columns[grdHOT].Value = 0;
				grdProjectAttendance.Columns[grdHOTProject].Value = txtProjectNo.Text;
				grdProjectAttendance.Columns[grdOTAMT].Value = 0;
				grdProjectAttendance.Columns[grdOTAMTProject].Value = txtProjectNo.Text;
			}
			catch
			{
				if (SystemProcedure2.IsItEmpty(txtProjectNo.Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Please select a Project then click on Get Attendance!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Please click on Get Attendance!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void DefineMasterRecordset()
		{
			string mysql = "";
			int mProject = 0;

			if (SystemProcedure2.IsItEmpty(txtProjectNo.Text, SystemVariables.DataType.StringType) || SystemProcedure2.IsItEmpty(txtDAttandanceDate.Value, SystemVariables.DataType.DateType))
			{
				return;
			}

			if (mFirstGridFocus)
			{
				mProject = GetProjectCd(txtProjectNo.Text);

				mysql = " select emp_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_full_name as name" : "a_full_name as name");
				mysql = mysql + " , hours_per_day , Allow_overtime";
				mysql = mysql + " from pay_employee ";
				mysql = mysql + " where  rate_calc_method_id = " + cmbCommon[conCmbEmpType].GetItemData(cmbCommon[conCmbEmpType].ListIndex).ToString();
				mysql = mysql + " and default_Project = " + mProject.ToString();
				mysql = mysql + " and emp_cd = dbo.EmployeeStatusAsOnDate( emp_cd , '" + ReflectionHelper.GetPrimitiveValue<string>(txtDAttandanceDate.DisplayText) + "')";
				mysql = mysql + " order by 1 ";


				rsBillingCodeList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsBillingCodeList.Tables.Clear();
				adap.Fill(rsBillingCodeList);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsBillingCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList.Requery(-1);
			}
		}

		private void grdProjectAttendance_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			try
			{
				grdProjectAttendance.UpdateData();
				CalculateTotal();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}


		private void grdProjectAttendance_BeforeColUpdate(object eventSender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			object OldValue = eventArgs.OldValue;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				try
				{
					double mWH = 0;
					int cnt = 0;
					int mRow = 0;

					//UPGRADE_WARNING: (1068) grdProjectAttendance.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mRow = ReflectionHelper.GetPrimitiveValue<int>(grdProjectAttendance.Bookmark);
					if (ColIndex == grdFOT || ColIndex == grdNOT || ColIndex == grdHOT)
					{
						if (ReflectionHelper.GetPrimitiveValue<double>(grdProjectAttendance.Columns[grdAllowOT].Value) == 0)
						{
							Cancel = 1;
							MessageBox.Show("This Employee overtime is not enable.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
					}

					if (ColIndex == grdFOT)
					{
						if (StringsHelper.ToDoubleSafe(grdProjectAttendance.Columns[grdFOT].Text) > 16)
						{
							Cancel = 1;
							MessageBox.Show("Overtime hours cannot be more then 16 hours in a day.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							grdProjectAttendance.Columns[grdNOT].Text = "0";
							grdProjectAttendance.Columns[grdHOT].Text = "0";
						}
					}

					if (ColIndex == grdNOT)
					{
						if (StringsHelper.ToDoubleSafe(grdProjectAttendance.Columns[grdNOT].Text) > 16)
						{
							Cancel = 1;
							MessageBox.Show("Overtime hours cannot be more then 16 hours in a day.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else if (StringsHelper.ToDoubleSafe(grdProjectAttendance.Columns[grdDayoff].Text) != 0)
						{ 
							Cancel = 1;
							MessageBox.Show("Day off is tick for this day.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							grdProjectAttendance.Columns[grdFOT].Text = "0";
							grdProjectAttendance.Columns[grdHOT].Text = "0";
						}
					}

					if (ColIndex == grdHOT)
					{
						if (StringsHelper.ToDoubleSafe(grdProjectAttendance.Columns[grdHOT].Text) > 24)
						{
							Cancel = 1;
							MessageBox.Show("Overtime hours cannot be more then 24 hours in a day.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							grdProjectAttendance.Columns[grdFOT].Text = "0";
							grdProjectAttendance.Columns[grdNOT].Text = "0";
						}
					}


					if (ColIndex == grdWorkingHrs && ReflectionHelper.GetPrimitiveValue<double>(grdProjectAttendance.Columns[grdHoursPerDay].Value) > 0)
					{
						mWH = 0;
						int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
						for (cnt = 0; cnt <= tempForEndVar; cnt++)
						{
							if (aVoucherDetails.GetValue(cnt, grdEmpCodeColumn) == grdProjectAttendance.Columns[grdEmpCodeColumn].Value)
							{
								if (cnt == mRow)
								{
									mWH += ReflectionHelper.GetPrimitiveValue<double>(grdProjectAttendance.Columns[grdWorkingHrs].Value);
								}
								else
								{
									mWH += Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdWorkingHrs));
								}
							}
						}
						if (mWH > Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdProjectAttendance.Columns[grdHoursPerDay].Value)))
						{
							MessageBox.Show("Working hrs cannot be more then Per day hours!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							Cancel = -1;
							return;
						}
					}
					return;
				}
				catch (System.Exception excep)
				{
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdProjectAttendance.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdProjectAttendance_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			try
			{
				int grdRow = 0;
				//UPGRADE_WARNING: (1068) grdProjectAttendance.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				grdRow = ReflectionHelper.GetPrimitiveValue<int>(grdProjectAttendance.Bookmark);
				if (Col == grdOTAMTYN || Col == grdDayoff)
				{
					if (Convert.ToDouble(aVoucherDetails.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), Col)) != 0)
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
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void grdProjectAttendance_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			if (mFirstGridFocus)
			{
				if (Convert.ToString(cmbMastersList.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList);
					cmbMastersList.Tag = "OK";
				}

				DefineMasterRecordset();
				mFirstGridFocus = false;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdProjectAttendance.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdProjectAttendance.PostMsg(1);
			}
			if (mProjectFirstGridFocus)
			{
				if (Convert.ToString(cmbMastersList1.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList);
					cmbMastersList1.Tag = "OK";
				}

				DefineMasterRecordsetProject();
				mProjectFirstGridFocus = false;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdProjectAttendance.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdProjectAttendance.PostMsg(2);
			}
		}

		private void grdProjectAttendance_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				try
				{
					int mRow = 0;
					int mCol = 0;
					mRow = grdProjectAttendance.Row;
					mCol = grdProjectAttendance.Col;
					if (grdProjectAttendance.Col == grdOTAMTYN || grdProjectAttendance.Col == grdDayoff)
					{
						if (KeyAscii == 32)
						{
							KeyAscii = 0;
							grdProjectAttendance_Post(grdProjectAttendance, new AxTrueOleDBGrid80.TrueDBGridEvents_PostEventEvent(3));
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

		private void grdProjectAttendance_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (grdProjectAttendance.PointAt(X, Y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
			{
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdProjectAttendance.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdProjectAttendance.PostMsg(3);
			}
		}

		private void grdProjectAttendance_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdProjectAttendance.Col > 0 && LastCol > 0 && !mFirstGridFocus)
			{
				switch(grdProjectAttendance.Col)
				{
					case grdEmpCodeColumn : case grdEmpNameColumn : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList); 
						break;
				}
			}
			if (grdProjectAttendance.Col > 0 && LastCol > 0 && !mProjectFirstGridFocus)
			{
				switch(grdProjectAttendance.Col)
				{
					case grdWHProject : case grdNOTProject : case grdFOTProject : case grdHOTProject : case grdOTAMTProject : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList1.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList1.setDataSource((msdatasrc.DataSource) rsBillingCodeList1); 
						break;
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdProjectAttendance.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdProjectAttendance_PostEvent(int MsgId)
		{
			int Col = 0;
			try
			{
				Col = grdProjectAttendance.Col;

				if (MsgId == 1)
				{
					grdProjectAttendance.Col = grdEmpCodeColumn;
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList);
				}
				if (MsgId == 2)
				{
					grdProjectAttendance.Col = grdEmpCodeColumn;
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList1);
				}
				if (MsgId == 3)
				{
					if (grdProjectAttendance.Col == grdOTAMTYN || grdProjectAttendance.Col == grdDayoff)
					{
						if (ReflectionHelper.GetPrimitiveValue<double>(grdProjectAttendance.Columns[Col].Value) == 0)
						{
							grdProjectAttendance.Columns[Col].Value = 1;
						}
						else
						{
							grdProjectAttendance.Columns[Col].Value = 0;
						}
						grdProjectAttendance.UpdateData();
						grdProjectAttendance.Refresh();
					}
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(excep.Message + " " + Information.Err().Number.ToString(), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		public void IRoutine()
		{
			int mCurrentLineNo = 0;

			if (ActiveControl.Name != "grdProjectAttendance" && grdProjectAttendance.Enabled)
			{
				grdProjectAttendance.Focus();
			}
			if (SystemVariables.gLoggedInUserCode == 1)
			{
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(grdProjectAttendance.Bookmark))
				{
					//UPGRADE_WARNING: (1068) grdProjectAttendance.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdProjectAttendance.Columns[grdLineNoColumn].Value);
					//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdProjectAttendance.Bookmark), 1);
					AssignGridLineNumbers();
					grdProjectAttendance.Rebind(true);
				}
			}
			else
			{
				MessageBox.Show("Line cannot be insert please contact your administrator.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		}

		public void LRoutine()
		{
			string mysql = "";

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_Project_Attendance_DeleteLine")))
			{
				if (ActiveControl.Name != "grdProjectAttendance" && grdProjectAttendance.Enabled)
				{
					grdProjectAttendance.Focus();
				}

				if (SystemVariables.gLoggedInUserCode == 1)
				{
					if (aVoucherDetails.GetLength(0) > 0)
					{
						if (Convert.ToInt32(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdProjectAttendance.Bookmark), grdLineNo)) != 0)
						{
							mysql = " Delete from pay_project_ta_details";
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							mysql = mysql + " where line_no = " + ReflectionHelper.GetPrimitiveValue<string>(grdProjectAttendance.Splits[0].DisplayColumns[grdLineNo].DataColumn.Value);
							SqlCommand TempCommand = null;
							TempCommand = SystemVariables.gConn.CreateCommand();
							TempCommand.CommandText = mysql;
							TempCommand.ExecuteNonQuery();
						}

						grdProjectAttendance.Delete();
						AssignGridLineNumbers();
						grdProjectAttendance.Rebind(true);
					}
				}
				else
				{
					MessageBox.Show("Line cannot be deleted please contact your administrator.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}


		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;
			string ProjectStr = "";
			string mysql = "";

			if (pObjectName == "txtProjectNo")
			{
				txtProjectNo.Text = "";
				ProjectStr = SystemHRProcedure.ProjectString();
				if (SystemProcedure2.IsItEmpty(ProjectStr, SystemVariables.DataType.StringType))
				{
					mysql = "pr1.show = 1";
				}
				else
				{
					mysql = "pr1.project_no in (  " + ProjectStr + " ) and pr1.show = 1";
				}
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000130, "985", mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtProjectNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtProjectNo_Leave(txtProjectNo, new EventArgs());
				}
			}

		}

		private void txtProjectNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtProjectNo");
		}

		private void txtProjectNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				string mCustomeSQL = "";

				if (!SystemProcedure2.IsItEmpty(txtProjectNo.Text, SystemVariables.DataType.StringType))
				{
					mTempValue = SystemHRProcedure.ProjectString();
					if (SystemProcedure2.IsItEmpty(mTempValue, SystemVariables.DataType.StringType))
					{
						mCustomeSQL = "";
					}
					else
					{
						mCustomeSQL = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
					mysql = "select project_no ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_project_name" : "a_project_name");
					mysql = mysql + " from gl_projects ";
					mysql = mysql + " where ";
					mysql = mysql + " project_no = '" + txtProjectNo.Text + "'";
					if (!SystemProcedure2.IsItEmpty(mCustomeSQL, SystemVariables.DataType.StringType))
					{
						mysql = mysql + " and project_no in (" + mCustomeSQL + ")";
					}

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDlBlProjectName.Text = "";
						throw new Exception();
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDlBlProjectName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					}
				}
				else
				{
					txtDlBlProjectName.Text = "";
				}
			}
			catch
			{
				MessageBox.Show("Invalid Project No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList1.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList1_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList1.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_3 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_4 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_5 = null;
			switch(grdProjectAttendance.Col)
			{
				case grdWHProject : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList1.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList1.setListField("project_no"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList1.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsBillingCodeList1.setSort("project_no"); 
					int tempForEndVar = cmbMastersList1.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersList1.Splits[0].DisplayColumns[cnt];
						if (cnt < 3)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdProjectAttendance.Col == grdWHProject) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdProjectAttendance.Splits[0].DisplayColumns[grdWHProject].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdProjectAttendance.Splits[0].DisplayColumns[grdNOT].Width;
							}
							withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							withVar.Visible = true;
							cmbMastersList1.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					cmbMastersList1.Width += 17; 
					cmbMastersList1.Height = 167; 
					break;
				case grdNOTProject : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList1.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList1.setListField("project_no"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList1.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsBillingCodeList1.setSort("project_no"); 
					int tempForEndVar2 = cmbMastersList1.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar2; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_2 = cmbMastersList1.Splits[0].DisplayColumns[cnt];
						if (cnt < 3)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_2.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar_2.setOrder((grdProjectAttendance.Col == grdNOTProject) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar_2.Width = grdProjectAttendance.Splits[0].DisplayColumns[grdNOTProject].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar_2.Width = grdProjectAttendance.Splits[0].DisplayColumns[grdHOT].Width;
							}
							withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							withVar_2.Visible = true;
							cmbMastersList1.Width += withVar_2.Width / 15;
						}
						else
						{
							withVar_2.Visible = false;
						}
						withVar_2.AllowSizing = false;
					} 
					cmbMastersList1.Width += 17; 
					cmbMastersList1.Height = 167; 
					break;
				case grdFOTProject : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList1.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList1.setListField("project_no"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList1.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsBillingCodeList1.setSort("project_no"); 
					int tempForEndVar3 = cmbMastersList1.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar3; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_3 = cmbMastersList1.Splits[0].DisplayColumns[cnt];
						if (cnt < 3)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_3.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar_3.setOrder((grdProjectAttendance.Col == grdFOTProject) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar_3.Width = grdProjectAttendance.Splits[0].DisplayColumns[grdFOTProject].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar_3.Width = grdProjectAttendance.Splits[0].DisplayColumns[grdHOT].Width;
							}
							withVar_3.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							withVar_3.Visible = true;
							cmbMastersList1.Width += withVar_3.Width / 15;
						}
						else
						{
							withVar_3.Visible = false;
						}
						withVar_3.AllowSizing = false;
					} 
					cmbMastersList1.Width += 17; 
					cmbMastersList1.Height = 167; 
					break;
				case grdHOTProject : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList1.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList1.setListField("project_no"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList1.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsBillingCodeList1.setSort("project_no"); 
					int tempForEndVar4 = cmbMastersList1.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar4; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_4 = cmbMastersList1.Splits[0].DisplayColumns[cnt];
						if (cnt < 3)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_4.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar_4.setOrder((grdProjectAttendance.Col == grdHOTProject) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar_4.Width = grdProjectAttendance.Splits[0].DisplayColumns[grdHOTProject].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar_4.Width = grdProjectAttendance.Splits[0].DisplayColumns[grdOTAMT].Width;
							}
							withVar_4.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							withVar_4.Visible = true;
							cmbMastersList1.Width += withVar_4.Width / 15;
						}
						else
						{
							withVar_4.Visible = false;
						}
						withVar_4.AllowSizing = false;
					} 
					cmbMastersList1.Width += 17; 
					cmbMastersList1.Height = 167; 
					break;
				case grdOTAMTProject : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList1.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList1.setListField("project_no"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList1.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsBillingCodeList1.setSort("project_no"); 
					int tempForEndVar5 = cmbMastersList1.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar5; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_5 = cmbMastersList1.Splits[0].DisplayColumns[cnt];
						if (cnt < 3)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_5.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar_5.setOrder((grdProjectAttendance.Col == grdOTAMTProject) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar_5.Width = grdProjectAttendance.Splits[0].DisplayColumns[grdOTAMTProject].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar_5.Width = grdProjectAttendance.Splits[0].DisplayColumns[grdOTAMTProject].Width;
							}
							withVar_5.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							withVar_5.Visible = true;
							cmbMastersList1.Width += withVar_5.Width / 15;
						}
						else
						{
							withVar_5.Visible = false;
						}
						withVar_5.AllowSizing = false;
					} 
					cmbMastersList1.Width += 17; 
					cmbMastersList1.Height = 167; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList1.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList1_DropDownClose()
		{
			switch(grdProjectAttendance.Col)
			{
				case grdWHProject : 
					grdProjectAttendance.Col = grdNOT; 
					break;
				case grdNOTProject : 
					grdProjectAttendance.Col = grdFOT; 
					break;
				case grdFOTProject : 
					grdProjectAttendance.Col = grdHOT; 
					break;
				case grdHOTProject : 
					grdProjectAttendance.Col = grdOTAMT; 
					break;
				case grdOTAMTProject : 
					grdProjectAttendance.Col = grdOTAMTProject; 
					break;
			}
		}

		private void DefineMasterRecordsetProject()
		{
			string mysql = "";

			if (mProjectFirstGridFocus)
			{
				mysql = " select project_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_project_name as project_Name" : "a_project_name as project_Name");
				mysql = mysql + " from gl_projects";
				mysql = mysql + " order by 1 ";

				rsBillingCodeList1 = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList1.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList1.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsBillingCodeList1.Tables.Clear();
				adap.Fill(rsBillingCodeList1);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsBillingCodeList1.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList1.Requery(-1);
			}
		}

		private int GetProjectCd(string pProjectNo, string pCustomSQL = "")
		{
			string mSQL = "";
			object mReturnValue = null;
			if (!SystemProcedure2.IsItEmpty(pProjectNo, SystemVariables.DataType.StringType))
			{
				mSQL = "select project_cd from gl_projects where project_no ='" + pProjectNo + "'";
				if (!SystemProcedure2.IsItEmpty(pCustomSQL, SystemVariables.DataType.StringType))
				{
					mSQL = mSQL + " and project_no in (" + pCustomSQL + ")";
				}
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					return 0;
				}
				else
				{
					return ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
			}
			else
			{
				return 0;
			}
		}

		private bool FindEmployeeCode(string pEmp_no)
		{
			int mCnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (mCnt = 0; mCnt <= tempForEndVar; mCnt++)
			{
				if (Convert.ToString(aVoucherDetails.GetValue(mCnt, grdEmpCodeColumn)) == pEmp_no)
				{
					grdProjectAttendance.Bookmark = mCnt;
					grdProjectAttendance.Col = grdWorkingHrs;
					return true;
				}
			}
			return false;
		}

		public void KRoutine()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(TriState.True, cnt, grdOTAMTYN);
			}
			grdProjectAttendance.Rebind(true);
		}

		public void URoutine()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(TriState.False, cnt, grdOTAMTYN);
			}
			grdProjectAttendance.Rebind(true);
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}