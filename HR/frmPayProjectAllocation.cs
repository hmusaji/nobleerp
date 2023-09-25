
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayProjectAllocation
		: System.Windows.Forms.Form
	{

		public frmPayProjectAllocation()
{
InitializeComponent();
} 
 public  void frmPayProjectAllocation_old()
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


		private void frmPayProjectAllocation_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private int mFormCallType = 0;
		private clsToolbar oThisFormToolBar = null;
		private int mThisFormID = 0; //Assign the Formid for Each Form
		private string mTimeStamp = "";
		private bool mFirstGridFocus = false;
		private DataSet _rsProjectCodeList = null;
		private DataSet rsProjectCodeList
		{
			get
			{
				if (_rsProjectCodeList is null)
				{
					_rsProjectCodeList = new DataSet();
				}
				return _rsProjectCodeList;
			}
			set
			{
				_rsProjectCodeList = value;
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

		private XArrayHelper _aTADetails = null;
		private XArrayHelper aTADetails
		{
			get
			{
				if (_aTADetails is null)
				{
					_aTADetails = new XArrayHelper();
				}
				return _aTADetails;
			}
			set
			{
				_aTADetails = value;
			}
		}

		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		//Private mLastCol As Integer
		//Private mLastRow As Integer

		private double mDaysPerMonth = 0;
		private double mHoursPerDay = 0;
		private double mBasicSalary = 0;
		private double mNormalOT = 0;
		private double mFridayOT = 0;
		private double mHolidayOT = 0;
		private int mPaymentTypeId = 0;

		//Constants from Grid TADetails
		private const int grdLineNoColumn = 0;
		private const int grdTAEntryId = 1;
		private const int grdTAFieldName = 2;
		private const int grdTAHours = 3;
		private const int grdAllocatedHrs = 4;
		private const int grdGroupCode = 5;

		//Constants from Grid Project Allocation
		//Private Const grdLineNoColumn  As Integer = 0 ' already declared up
		private const int grdProjectLineNo = 1;
		private const int grdProjectCd = 2;
		private const int grdProjectNo = 3;
		private const int grdProjectName = 4;
		private const int grdHours = 5;
		private const int grdTimeStamp = 6;

		private const int conTAMaxColumns = 6;
		private const int conProjectMaxColumns = 7;

		private const int conDlblEmpCode = 0;
		private const int conDlblEmpName = 1;
		private const int conDlblMonth = 2;
		private const int conDlblYear = 3;
		private const int conDlblBasicSalary = 4;
		private const int conDlblLeaveSalary = 5;
		private const int conDlblDepartmentCd = 6;
		private const int conDlblDepartmentName = 7;

		private string mPayrollDate = "";
		private string mPayrollStartDate = "";

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



		private void cmdPayroll_Click(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mSearchValue))
			{
				mPayrollDate = SystemHRProcedure.GetPayrollGenerateDate();
				mysql = " select entry_id , pay_date ";
				mysql = mysql + " from pay_payroll ";
				mysql = mysql + " where emp_cd = " + Conversion.Str(mSearchValue);
				mysql = mysql + " and pay_date='" + mPayrollDate + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					SystemForms.GetSystemForm(702100, 2, ((Array) mReturnValue).GetValue(0)); //Call Payroll Entry Form
				}
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				FirstFocusObject = grdVoucherDetails;
				//picFormToolbar.Visible = False
				grdVoucherDetails.Visible = false;

				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = false;
				oThisFormToolBar.ShowSaveButton = false;
				oThisFormToolBar.ShowDeleteButton = false;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.ShowInsertLineButton = false;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);

				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(1))
				//picFormToolbar.Visible = True


				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //setting form mode to add initially
				mFirstGridFocus = true;


				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdTADetails, false, true, false, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow, 1.47f, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdTADetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdTADetails, "EntryId", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdTADetails, "Particulars.", 4000, true, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Center);
				SystemGrid.DefineSystemVoucherGridColumn(grdTADetails, "Hours", 1000);
				SystemGrid.DefineSystemVoucherGridColumn(grdTADetails, "Allocated Hours", 1000);
				SystemGrid.DefineSystemVoucherGridColumn(grdTADetails, "GroupCode", 400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 1.47f, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "ProjectLN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "ProjectCd.", 800, true, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Project Code", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Project Name", 6000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "No.Of Hours", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.General);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "TimeStamp", 0, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				//setting voucher details grid properties
				DefineVoucherArray(-1, aVoucherDetails, 0);
				DefineVoucherArray(-1, aTADetails, 0);
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdTADetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdTADetails.setArray(aTADetails);
				grdTADetails.Rebind(true);
				//-- end of voucher grid property setting

				grdVoucherDetails.Visible = true;
				grdVoucherDetails.Enabled = false;
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
				object mReturnValue = null;
				if (KeyCode == 13)
				{
					SendKeys.Send("{TAB}");
					return;
				}

				if (KeyCode == ((int) Keys.F2) && ActiveControl.Name == "grdVoucherDetails" && (grdVoucherDetails.Col == grdProjectNo || grdVoucherDetails.Col == grdProjectName) && (SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[grdProjectCd].Value) || SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[grdHours].Value)))
				{
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000130, "985, 986, 987"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						grdVoucherDetails.Columns[grdProjectCd].Value = ((Array) mReturnValue).GetValue(0);
						grdVoucherDetails.Columns[grdProjectNo].Value = ((Array) mReturnValue).GetValue(1);
						if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
						{
							grdVoucherDetails.Columns[grdProjectName].Value = ((Array) mReturnValue).GetValue(2);
						}
						else
						{
							grdVoucherDetails.Columns[grdProjectName].Value = ((Array) mReturnValue).GetValue(3);
						}
					}
					return;
				}

				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void Form_Closed(Object eventSender, CancelEventArgs eventArgs)
		{
			int Cancel = (eventArgs.Cancel) ? 1 : 0;
			try
			{
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					DialogResult ans = (DialogResult) 0;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(txtDisplayLabel[0].Text) && txtDisplayLabel[0].Text != "")
					{
						if (!SystemHRProcedure.CheckForProjectAllocatedHrs(GetEmpCode(txtDisplayLabel[0].Text), mPayrollDate))
						{
							ans = MessageBox.Show("Allocation is not completed.Do you want to exit?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel);
							if (ans != System.Windows.Forms.DialogResult.Yes)
							{
								Cancel = -1;
							}
						}
					}
					SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
					aVoucherDetails = null;
					aTADetails = null;
					rsProjectCodeList = null;
					UserAccess = null;
					oThisFormToolBar = null;
					frmPayProjectAllocation.DefInstance = null;
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		private void grdTADetails_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			//Dim mSql As String
			//Dim mReturnValue As Variant
			//Dim mReturnValue1 As Variant
			//
			//If Not IsNull(grdVoucherDetails.Bookmark) Then
			//    mSql = "select emp_cd from pay_employee"
			//    mSql = mSql & " where emp_no=" & txtDisplayLabel(0).Text
			//    mReturnValue = GetMasterCode(mSql)
			//
			//    If Not IsNull(mReturnValue) Then
			//        mSql = "select tafield_id"
			//        mSql = mSql & " from pay_ta_trans"
			//        mSql = mSql & " where entry_id =" & grdTADetails.Columns(grdTAEntryId).Value
			//        mReturnValue1 = GetMasterCode(mSql)
			//        gCurrentTAFieldId = mReturnValue1
			//        Call GetSystemForm(903500, 2, mReturnValue)
			//    Else
			//        Exit Sub
			//    End If
			//End If
		}

		private void grdTADetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdTADetails.Columns[grdTAEntryId].Value))
			{
				//UPGRADE_WARNING: (1068) grdTADetails.Columns().Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtAllocationFor.Text = ReflectionHelper.GetPrimitiveValue<string>(grdTADetails.Columns[grdTAFieldName].Value);
				FillProjectGrid(ReflectionHelper.GetPrimitiveValue<int>(grdTADetails.Columns[grdTAEntryId].Value));
			}
		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int mTABookmark = 0;
			int mVDBookmark = 0;
			grdVoucherDetails.UpdateData();
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (ColIndex == grdHours && !Convert.IsDBNull(grdVoucherDetails.Bookmark) && !Convert.IsDBNull(grdTADetails.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdTADetails.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTABookmark = ReflectionHelper.GetPrimitiveValue<int>(grdTADetails.Bookmark);
				mVDBookmark = Convert.ToInt32(ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Bookmark) + 1);
				CalculateTotals();
				grdVoucherDetails.Refresh();
				FillTAGrid(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), mPayrollStartDate, mPayrollDate);
				grdTADetails.Bookmark = mTABookmark;

				if ((mVDBookmark) >= aVoucherDetails.GetLength(0))
				{
					aVoucherDetails.AppendRows(1);
					grdVoucherDetails.Rebind(true);
					Application.DoEvents();
				}

				grdVoucherDetails.Bookmark = mVDBookmark;
			}
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
					string mSQL = "";
					object mReturnValue = null;
					object mTempValaue = null;
					SqlDataReader rs = null;
					int mPrevProjectCd = 0;

					if (ColIndex == grdHours)
					{
						if (SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[grdProjectCd].Value))
						{
							MessageBox.Show("Invalid Project selection!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							Cancel = -1;
							return;
						}
						if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdHours].Value)) > (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdTADetails.Columns[grdTAHours].Value)) - Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdTADetails.Columns[grdAllocatedHrs].Value))) + Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(OldValue)))
						{
							MessageBox.Show("Hours cannot exceed allocated hours!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							Cancel = -1;
							return;
						}
						else
						{
							SystemVariables.gConn.BeginTransaction();

							mSQL = " select ppp.bill_cd,ppp.entry_id ";
							mSQL = mSQL + " from pay_billing_type pbt ";
							mSQL = mSQL + " inner join pay_project_payroll ppp on ppp.bill_cd = pbt.bill_cd";
							mSQL = mSQL + " where pbt.group_no =" + ReflectionHelper.GetPrimitiveValue<string>(grdTADetails.Columns[grdGroupCode].Value);
							mSQL = mSQL + " and ppp.emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
							mSQL = mSQL + " and ppp.pay_date ='" + mPayrollDate + "'";
							mSQL = mSQL + " and ppp.bill_cd in (select bill_cd from pay_payroll pp where pp.emp_cd = ppp.emp_cd and pp.pay_date = ppp.pay_date)";
							SqlCommand sqlCommand = new SqlCommand(mSQL, SystemVariables.gConn);
							rs = sqlCommand.ExecuteReader();
							rs.Read();
							do 
							{
								if (SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[grdProjectLineNo].Value))
								{
									mSQL = " insert into pay_project_payroll_details (entry_id, pay_date, project_cd, pay_hours, pay_days) values (";
									mSQL = mSQL + Convert.ToString(rs["entry_id"]); //CStr(grdTADetails.Columns(grdTAEntryId).Value)
									mSQL = mSQL + ", '" + mPayrollDate + "'";
									mSQL = mSQL + ", " + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdProjectCd].Value);
									mSQL = mSQL + ", " + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdHours].Value);
									mSQL = mSQL + ", 0"; // days
									mSQL = mSQL + ")";
									SqlCommand TempCommand = null;
									TempCommand = SystemVariables.gConn.CreateCommand();
									TempCommand.CommandText = mSQL;
									TempCommand.ExecuteNonQuery();
								}
								else
								{
									mSQL = " select project_cd from pay_project_payroll_details where line_no =" + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdProjectLineNo].Value);
									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mPrevProjectCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mSQL));

									mSQL = " select time_stamp from pay_project_payroll_details where line_no = " + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdProjectLineNo].Value);
									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
									//if the time stamp does not match the previous one then rollback
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
									if (!Convert.IsDBNull(mPrevProjectCd))
									{
										mSQL = " update pay_project_payroll_details set ";
										mSQL = mSQL + " project_cd = " + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdProjectCd].Value);
										mSQL = mSQL + ", pay_hours = " + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdHours].Value);
										mSQL = mSQL + ", pay_days = 0";
										mSQL = mSQL + " where entry_id = " + Convert.ToString(rs["entry_id"]);
										mSQL = mSQL + " and project_cd = " + mPrevProjectCd.ToString();
										SqlCommand TempCommand_2 = null;
										TempCommand_2 = SystemVariables.gConn.CreateCommand();
										TempCommand_2.CommandText = mSQL;
										TempCommand_2.ExecuteNonQuery();
									}
								}
							}
							while(rs.Read());
							if (SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[grdProjectLineNo].Value) && ReflectionHelper.GetPrimitiveValue<double>(grdTADetails.Columns[grdGroupCode].Value) == 1)
							{
								mSQL = " insert into pay_project_payroll_details (entry_id, pay_date, project_cd, pay_hours, pay_days) ";
								mSQL = mSQL + " select ppp.entry_id, ppp.pay_date";
								mSQL = mSQL + ", " + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdProjectCd].Value);
								mSQL = mSQL + ", " + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdHours].Value);
								mSQL = mSQL + ", 0"; // days
								mSQL = mSQL + " from pay_project_payroll ppp";
								mSQL = mSQL + " inner join pay_billing_type pbt on pbt.bill_cd = ppp.bill_cd";
								mSQL = mSQL + " where ppp.pay_date ='" + mPayrollDate + "' and pbt.bill_no in (9,11,13) and ppp.emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
								SqlCommand TempCommand_3 = null;
								TempCommand_3 = SystemVariables.gConn.CreateCommand();
								TempCommand_3.CommandText = mSQL;
								TempCommand_3.ExecuteNonQuery();
							}
							else if (!SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[grdProjectLineNo].Value) && ReflectionHelper.GetPrimitiveValue<double>(grdTADetails.Columns[grdGroupCode].Value) == 1)
							{ 
								mSQL = " update pppd set ";
								mSQL = mSQL + " pppd.project_cd = " + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdProjectCd].Value);
								mSQL = mSQL + ", pppd.pay_hours = " + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdHours].Value);
								mSQL = mSQL + ", pppd.pay_days = 0";
								mSQL = mSQL + " from pay_project_payroll_details pppd";
								mSQL = mSQL + " inner join pay_project_payroll ppp on ppp.entry_id = pppd.entry_id";
								mSQL = mSQL + " inner join pay_billing_type pbt on pbt.bill_cd = ppp.bill_cd";
								mSQL = mSQL + " where ppp.pay_date ='" + mPayrollDate + "' and pbt.bill_no in (9,11,13) and ppp.emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
								mSQL = mSQL + " and pppd.project_cd = " + mPrevProjectCd.ToString();
								SqlCommand TempCommand_4 = null;
								TempCommand_4 = SystemVariables.gConn.CreateCommand();
								TempCommand_4.CommandText = mSQL;
								TempCommand_4.ExecuteNonQuery();
							}
							//''''Assign whatever group assign with this ggroup will be allocate*********
							//''''Add  As On 01-jul-2009
							if (SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[grdProjectLineNo].Value))
							{ //And grdTADetails.Columns(grdGroupCode).Value = 1 Then
								mSQL = " insert into pay_project_payroll_details (entry_id, pay_date, project_cd, pay_hours, pay_days) ";
								mSQL = mSQL + " select ppp.entry_id, ppp.pay_date";
								mSQL = mSQL + ", " + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdProjectCd].Value);
								mSQL = mSQL + ", ppp.pay_hours ";
								mSQL = mSQL + ", 0"; // days
								mSQL = mSQL + " from pay_project_payroll ppp";
								mSQL = mSQL + " inner join pay_billing_type pbt on pbt.bill_cd = ppp.bill_cd";
								mSQL = mSQL + " where ppp.pay_date ='" + mPayrollDate + "'";
								//mSQL = mSQL & " and pbt.group_no in (select group_no from pay_billing_type where group_assign_with_group = " & grdTADetails.Columns(grdGroupCode).Value & " and group_no <>" & grdTADetails.Columns(grdGroupCode).Value & ")"
								mSQL = mSQL + " and pbt.group_assign_with_group = " + ReflectionHelper.GetPrimitiveValue<string>(grdTADetails.Columns[grdGroupCode].Value) + " and pbt.group_no <>" + ReflectionHelper.GetPrimitiveValue<string>(grdTADetails.Columns[grdGroupCode].Value);
								mSQL = mSQL + " and ppp.emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
								mSQL = mSQL + " and ppp.pay_hours > 0";
								SqlCommand TempCommand_5 = null;
								TempCommand_5 = SystemVariables.gConn.CreateCommand();
								TempCommand_5.CommandText = mSQL;
								TempCommand_5.ExecuteNonQuery();
							}
							else if (!SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[grdProjectLineNo].Value))
							{  // And grdTADetails.Columns(grdGroupCode).Value = 1 Then
								mSQL = " update pppd set ";
								mSQL = mSQL + " pppd.project_cd = " + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdProjectCd].Value);
								mSQL = mSQL + ", pppd.pay_hours =  ppp.pay_hours ";
								mSQL = mSQL + ", pppd.pay_days = 0";
								mSQL = mSQL + " from pay_project_payroll_details pppd";
								mSQL = mSQL + " inner join pay_project_payroll ppp on ppp.entry_id = pppd.entry_id";
								mSQL = mSQL + " inner join pay_billing_type pbt on pbt.bill_cd = ppp.bill_cd";
								mSQL = mSQL + " where ppp.pay_date ='" + mPayrollDate + "'";
								mSQL = mSQL + " and pbt.group_no in (select group_no from pay_billing_type where group_assign_with_group = " + ReflectionHelper.GetPrimitiveValue<string>(grdTADetails.Columns[grdGroupCode].Value) + " and group_no <>" + ReflectionHelper.GetPrimitiveValue<string>(grdTADetails.Columns[grdGroupCode].Value) + ")";
								mSQL = mSQL + " and ppp.emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
								mSQL = mSQL + " and pppd.project_cd = " + mPrevProjectCd.ToString();
								SqlCommand TempCommand_6 = null;
								TempCommand_6 = SystemVariables.gConn.CreateCommand();
								TempCommand_6.CommandText = mSQL;
								TempCommand_6.ExecuteNonQuery();
							}
							//End If
						}
						//gConn.Execute mSql
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.CommitTrans();
						grdVoucherDetails.Refresh();
					}
					return;
				}
				catch (System.Exception excep)
				{
					Cancel = -1;
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}


		private void grdVoucherDetails_ButtonClick(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			if (SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[grdProjectCd].Value) || SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[grdHours].Value))
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[grdProjectName].Locked = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[grdProjectNo].Locked = false;
			}
			else
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[grdProjectName].Locked = true;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[grdProjectNo].Locked = true;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == grdHours)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###,###,##0.000");
				}
				else
				{
					Value = "";
				}
			}
		}

		private void CalculateTotals()
		{
			int cnt = 0;

			double mTotalAmount = 0;
			double mAllocationTotal = 0;
			int tempForEndVar = aTADetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mTotalAmount += Conversion.Val(Convert.ToString(aTADetails.GetValue(cnt, grdTAHours)));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mAllocationTotal += Conversion.Val((Convert.IsDBNull(aTADetails.GetValue(cnt, grdAllocatedHrs))) ? "0" : Convert.ToString(aTADetails.GetValue(cnt, grdAllocatedHrs)));
			}

			if (mTotalAmount != 0)
			{
				grdTADetails.Columns[grdTAHours].FooterText = StringsHelper.Format(mTotalAmount, "###,###,###,###,##0.000");
			}
			else
			{
				grdTADetails.Columns[grdTAHours].FooterText = "";
			}

			if (mAllocationTotal != 0)
			{
				grdTADetails.Columns[grdAllocatedHrs].FooterText = StringsHelper.Format(mAllocationTotal, "###,###,###,###,##0.000");
			}
			else
			{
				grdTADetails.Columns[grdAllocatedHrs].FooterText = "";
			}

			mTotalAmount = 0;
			int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar2; cnt++)
			{
				mTotalAmount += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdHours)));
			}

			if (mTotalAmount != 0)
			{
				grdVoucherDetails.Columns[grdHours].FooterText = StringsHelper.Format(mTotalAmount, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails.Columns[grdHours].FooterText = "";
			}



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

		private void DefineVoucherArray(int pMaximumRows, XArrayHelper pArray, int pMaxColumns, bool pClearArray = false)
		{
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method pArray.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				pArray.Clear();
			}
			pArray.RedimXArray(new int[]{pMaximumRows, pMaxColumns}, new int[]{0, 0});
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
				}

				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode

				SystemProcedure2.ClearTextBox(this);
				DefineVoucherArray(-1, aTADetails, conTAMaxColumns, true);
				DefineVoucherArray(-1, aVoucherDetails, conProjectMaxColumns, true);

				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Enabled = false;

				mSearchValue = ""; //Change the msearchvalue to blank
				mPayrollDate = "";
				mFirstGridFocus = true;
				//FirstFocusObject.SetFocus
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}


		}


		public void GetRecord(object pSearchValue, bool pSearchByEmpCd, ref string pGenerateDate)
		{

			string mysql = "";
			int mEmpCd = 0;
			object mReturnValue = null;
			DataSet rsLocalRec = new DataSet();
			int cnt = 0;

			//On Error GoTo eFoundError

			//mPayrollDate = GetPayrollGenerateDate
			//mPayrollStartDate = GetPayrollGenerateStartDate
			if (pSearchByEmpCd)
			{
				pGenerateDate = SystemHRProcedure.gProjectAllocationDate;
			}
			if (pGenerateDate == "")
			{
				mPayrollDate = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddDays(-1).ToString("dd/MMM/yyyy");
				mPayrollStartDate = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddMonths(-1).ToString("dd/MMM/yyyy");
			}
			else
			{
				System.DateTime TempDate = DateTime.FromOADate(0);
				mPayrollDate = (DateTime.TryParse(pGenerateDate, out TempDate)) ? TempDate.ToString("dd/MMM/yyyy") : pGenerateDate;
				mPayrollStartDate = DateTime.Parse(pGenerateDate).AddDays(1).AddMonths(-1).ToString("dd/MMM/yyyy");
			}
			if (mPayrollDate == "")
			{
				return;
			}

			//''''Get the values by entryId
			//''''this is called from report drill down
			//''''other wise normally by emp code
			if (!pSearchByEmpCd)
			{
				mysql = " select emp_cd , pay_date ";
				mysql = mysql + " from pay_payroll ";
				mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mPayrollDate = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				}
			}
			else
			{
				//UPGRADE_WARNING: (1068) pSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(pSearchValue);
			}

			mysql = " select pemp.emp_no, pemp.emp_cd ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name as emp_name";
			}
			else
			{
				mysql = mysql + " , a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name as emp_name ";
			}
			mysql = mysql + " , basic_salary ";
			mysql = mysql + " , weekend ";
			mysql = mysql + " , days_per_month ";
			mysql = mysql + " , hours_per_day ";
			mysql = mysql + " , isnull(normal_ot,0) ";
			mysql = mysql + " , payment_type_id ";
			mysql = mysql + " , isnull(friday_ot,0) ";
			mysql = mysql + " , isnull(holiday_ot,0) ";
			mysql = mysql + " , rate_calc_method_id ";
			mysql = mysql + " , weekend_day1_id ";
			mysql = mysql + " , weekend_day2_id ";
			mysql = mysql + " , pdept.dept_no ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , l_dept_name as dept_name";
			}
			else
			{
				mysql = mysql + " , a_dept_name as dept_name";
			}
			mysql = mysql + " from pay_employee pemp ";
			mysql = mysql + " inner join pay_department pdept on pemp.dept_cd = pdept.dept_Cd ";
			mysql = mysql + " where pemp.emp_cd = " + Conversion.Str(mEmpCd);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
				cnt = 0;
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
				txtDisplayLabel[conDlblBasicSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(3)), "###,###,##0.000");
				txtDisplayLabel[conDlblLeaveSalary].Text = StringsHelper.Format(SystemHRProcedure.GetEmpAnnualLeaveSalary(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0))), "###,###,##0.000");
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDepartmentName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(15));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDepartmentCd].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(14));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mBasicSalary = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mHoursPerDay = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(6));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mNormalOT = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(7));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mPaymentTypeId = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(8));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mFridayOT = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(9));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mHolidayOT = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(10));
				if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(11)) == SystemHRProcedure.gFixedDays)
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDaysPerMonth = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5));
				}
				else if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(11)) == SystemHRProcedure.gActualDays)
				{ 
					mDaysPerMonth = SystemHRProcedure.CalculateDays(DateTime.Parse(mPayrollStartDate), DateTime.Parse(mPayrollDate), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(12)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(13)));
				}
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			}
			else
			{
				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				return;
			}

			System.DateTime TempDate2 = DateTime.FromOADate(0);
			txtDisplayLabel[conDlblMonth].Text = (DateTime.TryParse(mPayrollDate, out TempDate2)) ? TempDate2.ToString("MMM") : mPayrollDate;
			System.DateTime TempDate3 = DateTime.FromOADate(0);
			txtDisplayLabel[conDlblYear].Text = (DateTime.TryParse(mPayrollDate, out TempDate3)) ? TempDate3.ToString("yyyy") : mPayrollDate;


			FillTAGrid(mEmpCd, mPayrollStartDate, mPayrollDate);

			AssignGridLineNumbers();
			grdVoucherDetails.Rebind(true);
			CalculateTotals();

			grdVoucherDetails.Enabled = true;
			FirstFocusObject.Focus();
			mFirstGridFocus = true;
			Application.DoEvents();

			rsLocalRec = null;

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void GetRecord(object pSearchValue, bool pSearchByEmpCd)
		{
			string tempRefParam = "";
			GetRecord(pSearchValue, pSearchByEmpCd, ref tempRefParam);
		}

		public void GetRecord(object pSearchValue)
		{
			string tempRefParam2 = "";
			GetRecord(pSearchValue, true, ref tempRefParam2);
		}

		public void PrintReport()
		{

		}

		public void CloseForm()
		{
			this.Close();
		}

		public void IRoutine()
		{
			int mCurrentLineNo = 0;

			if (ActiveControl.Name != "grdVoucherDetails" && grdVoucherDetails.Enabled)
			{
				grdVoucherDetails.Focus();
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdVoucherDetails.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdVoucherDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[grdLineNoColumn].Value);
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), 1);
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
			}
		}

		public void LRoutine()
		{
			try
			{
				string mSQL = "";
				if (this.ActiveControl.Name == "grdVoucherDetails" && grdVoucherDetails.Enabled)
				{
					grdVoucherDetails.Focus();
					if (!SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[grdProjectLineNo].Value))
					{
						mSQL = " delete from pay_project_payroll_details ";
						mSQL = mSQL + " where line_no = " + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdProjectLineNo].Value);
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mSQL;
						TempCommand.ExecuteNonQuery();

						mSQL = " delete from pay_project_payroll_details";
						mSQL = mSQL + " from pay_project_payroll_details pppd ";
						mSQL = mSQL + " inner join pay_project_payroll ppp on ppp.entry_id = pppd.entry_id";
						mSQL = mSQL + " inner join pay_billing_type pbt on pbt.bill_cd = ppp.bill_cd";
						mSQL = mSQL + " where pbt.bill_no in (9,11,13) and project_cd = " + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdProjectCd].Value);
						mSQL = mSQL + " and emp_cd = " + SystemHRProcedure.GetEmpCd(txtDisplayLabel[conDlblEmpCode].Text).ToString();
						mSQL = mSQL + " and pppd.pay_date = '" + mPayrollDate + "'";
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mSQL;
						TempCommand_2.ExecuteNonQuery();

						mSQL = " delete from pay_project_payroll_details";
						mSQL = mSQL + " from pay_project_payroll_details pppd ";
						mSQL = mSQL + " inner join pay_project_payroll ppp on ppp.entry_id = pppd.entry_id";
						mSQL = mSQL + " inner join pay_billing_type pbt on pbt.bill_cd = ppp.bill_cd";
						mSQL = mSQL + " where pbt.group_no = " + ReflectionHelper.GetPrimitiveValue<string>(grdTADetails.Columns[grdGroupCode].Value);
						mSQL = mSQL + " and project_cd = " + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdProjectCd].Value);
						mSQL = mSQL + " and emp_cd = " + SystemHRProcedure.GetEmpCd(txtDisplayLabel[conDlblEmpCode].Text).ToString();
						mSQL = mSQL + " and pppd.pay_date = '" + mPayrollDate + "'";
						SqlCommand TempCommand_3 = null;
						TempCommand_3 = SystemVariables.gConn.CreateCommand();
						TempCommand_3.CommandText = mSQL;
						TempCommand_3.ExecuteNonQuery();
					}
					grdVoucherDetails.Delete();
					grdVoucherDetails_AfterColUpdate(grdVoucherDetails, new C1.Win.C1TrueDBGrid.ColEventArgs());
					grdVoucherDetails.Rebind(true);
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		public void findRecord()
		{
			object mTempSearchValue = null;
			string mysql = "";
			DialogResult ans = (DialogResult) 0;
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(txtDisplayLabel[0].Text) && txtDisplayLabel[0].Text != "")
			{
				if (!SystemHRProcedure.CheckForProjectAllocatedHrs(GetEmpCode(txtDisplayLabel[0].Text), mPayrollDate))
				{
					ans = MessageBox.Show("Allocation is not completed. Do you want to change record?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel);
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						goto Find;
					}
					else
					{
						return;
					}
				}
			}
			Find:
			mysql = " pemp.status_cd <> 3 ";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220580, "2608", mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				string tempRefParam = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				GetRecord(mSearchValue, true, ref tempRefParam);
			}
		}

		public void FillTAGrid(int pEmpCd, string pPayrollStartDate, string pPayrollDate)
		{
			int cnt = 0;

			string mysql = "select ppp.entry_id";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + ", pbt.l_bill_name as bill_name";
			}
			else
			{
				mysql = mysql + ", pbt.a_bill_name as bill_name";
			}
			mysql = mysql + ",  ppp.pay_hours";
			mysql = mysql + ", (select isnull(sum(pay_hours),0) from pay_project_payroll_details where entry_id = ppp.entry_id) as allocated_hrs ";
			mysql = mysql + ", pbt.group_no ";
			mysql = mysql + " from pay_project_payroll ppp";
			mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = ppp.bill_cd";
			mysql = mysql + " where ppp.pay_date ='" + pPayrollDate + "' and ppp.show = 1";
			mysql = mysql + " and ppp.emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

			SqlDataReader rsLocalRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			if (rsLocalRec.Read())
			{
				do 
				{
					DefineVoucherArray(cnt, aTADetails, conTAMaxColumns, false);
					aTADetails.SetValue(Conversion.Str(cnt + 1).Trim(), cnt, grdLineNoColumn);
					aTADetails.SetValue(rsLocalRec["entry_id"], cnt, grdTAEntryId);
					aTADetails.SetValue(rsLocalRec["bill_name"], cnt, grdTAFieldName);
					aTADetails.SetValue(rsLocalRec["pay_hours"], cnt, grdTAHours);
					aTADetails.SetValue(rsLocalRec["allocated_hrs"], cnt, grdAllocatedHrs);
					aTADetails.SetValue(rsLocalRec["group_no"], cnt, grdGroupCode);
					cnt++;
				}
				while(rsLocalRec.Read());
			}
			grdTADetails.Rebind(true);

		}

		public void FillProjectGrid(int pEntryId)
		{
			int cnt = 0;

			string mysql = " select gp.project_cd, gp.project_no, pppd.line_no, gp.project_cd ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + ", l_project_name ";
			}
			else
			{
				mysql = mysql + ", a_project_name ";
			}
			mysql = mysql + " as project_name, pay_hours, pppd.time_stamp  ";
			mysql = mysql + "  from gl_projects gp ";
			mysql = mysql + " inner Join pay_project_payroll_details pppd on gp.project_Cd = pppd.project_cd";
			mysql = mysql + " Where pppd.entry_id =" + pEntryId.ToString();

			DefineVoucherArray(0, aVoucherDetails, conProjectMaxColumns, true);
			SqlDataReader rsLocalRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			if (rsLocalRec.Read())
			{
				do 
				{
					DefineVoucherArray(cnt, aVoucherDetails, conProjectMaxColumns, false);
					aVoucherDetails.SetValue(Conversion.Str(cnt + 1).Trim(), cnt, grdLineNoColumn);

					aVoucherDetails.SetValue(rsLocalRec["line_no"], cnt, grdProjectLineNo);
					aVoucherDetails.SetValue(rsLocalRec["project_cd"], cnt, grdProjectCd);
					aVoucherDetails.SetValue(rsLocalRec["project_no"], cnt, grdProjectNo);
					aVoucherDetails.SetValue(rsLocalRec["project_name"], cnt, grdProjectName);
					aVoucherDetails.SetValue(rsLocalRec["pay_hours"], cnt, grdHours);
					aVoucherDetails.SetValue(rsLocalRec["time_stamp"], cnt, grdTimeStamp);
					cnt++;
				}
				while(rsLocalRec.Read());
			}
			grdVoucherDetails.Rebind(true);

		}

		private void DefineMasterRecordset()
		{
			string mSQL = "";

			if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
			{
				return;
			}

			if (mFirstGridFocus)
			{
				mSQL = " select project_cd, project_no ";
				mSQL = mSQL + ", " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_project_name " : " a_project_name ") + " as project_name ";
				mSQL = mSQL + " from gl_projects ";
				rsProjectCodeList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProjectCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsProjectCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mSQL, SystemVariables.gConn);
				rsProjectCodeList.Tables.Clear();
				adap.Fill(rsProjectCodeList);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsProjectCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsProjectCodeList.Requery(-1);
			}

		}

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			if (mFirstGridFocus)
			{
				if (Convert.ToString(cmbMastersList.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList);
					cmbMastersList.Tag = "OK";
				}

				DefineMasterRecordset();
				mFirstGridFocus = false;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.PostMsg(1);
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{
			int Col = 0;

			if (MsgId == 1)
			{
				grdVoucherDetails.Col = grdProjectNo;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsProjectCodeList);
			}

		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			switch(grdVoucherDetails.Col)
			{
				case grdProjectNo : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList.setListField("project_no"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProjectCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsProjectCodeList.setSort("project_no"); 
					break;
				case grdProjectName : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList.setListField("project_name"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProjectCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsProjectCodeList.setSort("project_name"); 
					break;
			}
			int tempForEndVar = cmbMastersList.Columns.Count - 1;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar = cmbMastersList.Splits[0].DisplayColumns[cnt];
				if (cnt < 4)
				{
					if (cnt == 0)
					{
						withVar.Visible = false;
					}
					else if (cnt == 1)
					{ 
						//.Order = IIf(grdVoucherDetails.Col = grdProjectNo, 1, 0)
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdProjectNo].Width;
						withVar.Visible = true;
					}
					else if (cnt == 2)
					{ 
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdProjectName].Width;
						withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
						withVar.Visible = true;
						cmbMastersList.Width += withVar.Width / 15;
					}
				}
				else
				{
					withVar.Visible = false;
				}
				withVar.AllowSizing = false;
			}
			cmbMastersList.Width += 15;
			cmbMastersList.Height = 167;
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			switch(grdVoucherDetails.Col)
			{
				case grdProjectNo : 
					grdVoucherDetails.Col = grdProjectName; 
					break;
			}
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			if (grdVoucherDetails.Col == grdProjectNo || grdVoucherDetails.Col == grdProjectName)
			{
				if (grdVoucherDetails.Col == grdProjectNo)
				{
					grdVoucherDetails.Columns[grdProjectCd].Value = cmbMastersList.Columns[0].Value;
					grdVoucherDetails.Columns[grdProjectName].Value = cmbMastersList.Columns[2].Value;
				}
				else
				{
					grdVoucherDetails.Columns[grdProjectCd].Value = cmbMastersList.Columns[0].Value;
					grdVoucherDetails.Columns[grdProjectNo].Value = cmbMastersList.Columns[1].Value;
				}
			}
		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdVoucherDetails.Col > 0 && LastCol > 0 && !mFirstGridFocus)
			{
				switch(grdVoucherDetails.Col)
				{
					case grdProjectNo : case grdProjectName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsProjectCodeList); 
						break;
				}
			}

			//grdVoucherDetails_ButtonClick (grdVoucherDetails.Col)
			CalculateTotals();
		}

		public int GetEmpCode(string pEmpNo)
		{

			string mysql = " select emp_cd from pay_employee";
			mysql = mysql + " where emp_no ='" + pEmpNo + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
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
	}
}