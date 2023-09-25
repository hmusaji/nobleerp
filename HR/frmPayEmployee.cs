
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayEmployee
		: System.Windows.Forms.Form
	{

		public frmPayEmployee()
{
InitializeComponent();
} 
 public  void frmPayEmployee_old()
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
			
		}


		private void frmPayEmployee_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		public Control FirstFocusObject = null;

		private const int conTabPersonnelBasic = 0;
		private const int conTabPersonnelJobDetails = 1;
		private const int conTabPersonnelDetailed = 2;
		private const int conTabPersonnelOthers = 3;
		private const int conTabPersonnelOthersDetails = 4;

		private const int conCmbTitle = 0;
		private const int conCmbSex = 1;
		private const int conCmbMaritalStatus = 2;
		private const int conCmbEmpType = 3;

		private const int conCmdPayroll = 0;
		private const int conCmdLeave = 1;
		private const int conCmdIndemnity = 2;
		private const int conCmdFixedSalary = 3;


		private const int conTxtEmpCode = 0;
		private const int conTxtLFirstName = 1;
		private const int conTxtLSecondName = 2;
		private const int conTxtLThirdName = 3;
		private const int conTxtLFourthName = 4;
		private const int conTxtAFirstName = 5;
		private const int conTxtASecondName = 6;
		private const int conTxtAThirdName = 7;
		private const int conTxtAFourthName = 8;
		private const int conTxtDeptCode = 9;
		private const int conTxtManagerCode = 10;
		private const int conTxtDesignationCode = 11;
		private const int conTxtGradeCode = 12;
		private const int conTxtNatCode = 13;
		private const int conTxtPassportNo = 14;
		private const int conTxtReligionCode = 15;
		private const int conTxtArea = 16;
		private const int conTxtBlock = 17;
		private const int conTxtStreet = 18;
		private const int conTxtLane = 19;
		private const int conTxtTypeofBldg = 20;
		private const int conTxtBldgNo = 21;
		private const int conTxtQasima = 22;
		private const int conTxtFloor = 23;
		private const int conTxtFlatNo = 24;
		private const int conTxtEntrance = 25;
		private const int conTxtPOBox = 26;
		private const int conTxtZipCode = 27;
		private const int conTxtTelephoneNo1 = 28;
		private const int conTxtMobileno = 29;
		private const int conTxtPagerNo = 30;
		private const int conTxtEmailAddress = 31;
		private const int conTxtAddress1 = 32;
		private const int conTxtAddress2 = 33;
		private const int conTxtAddress3 = 34;
		private const int conTxtTelephoneNo2 = 35;
		private const int conTxtComments = 36;
		private const int conTxtFax = 37;
		private const int conTxtCivilId = 38;
		private const int conTxtCompanyCode = 39;
		private const int conTxtLFatherName = 40;
		private const int conTxtAFatherName = 41;
		private const int conTxtLMotherName = 42;
		private const int conTxtAMotherName = 43;
		private const int conTxtPlaceOfBirth = 44;
		private const int conTxtQualificationCode = 45;
		private const int conTxtBloodGroup = 46;
		private const int conTxtNoOfWives = 47;
		private const int conTxtNoOfChildren = 48;
		private const int conTxtWorkPermitNo = 49;
		private const int conTxtVisaNo = 50;
		private const int conTxtVisaType = 51;
		private const int conTxtSponsorCode = 52;
		private const int conTxtComments1 = 53;
		private const int conTxtComments2 = 54;
		private const int conTxtComments3 = 55;
		private const int conTxtProbationDays = 56;
		private const int conTxtAddress4 = 57;
		private const int conTxtAFifthName = 58;
		private const int conTxtLFifthName = 59;
		private const int conTxtQualfDesc = 60;
		private const int conTxtProfessionalDesc = 61;
		private const int conTxtReliventExp = 62;
		private const int conTxtIrreliventExp = 63;
		private const int conTxtYearOfPassing = 64;
		private const int conTxtTicketType = 73;
		private const int conTxtTicketDestination = 71;
		private const int conTxtAnalysis1 = 65;
		private const int conTxtAnalysis2 = 66;
		private const int conTxtAnalysis3 = 67;
		private const int conTxtAnalysis4 = 68;
		private const int conTxtAnalysis5 = 69;
		private const int conTxtLocation = 70;
		private const int conTxtBudgetHeadCount = 72;

		private const int conDlblStatus = 0;
		private const int conDlblDeptName = 1;
		private const int conDlblManagerName = 2;
		private const int conDlblDesgName = 3;
		private const int conDlblGradeName = 4;
		private const int conDlblAge = 5;
		private const int conDlblCompName = 6;
		//Private Const conDlblWorkingPeriod As Integer = 6
		private const int conDlblNatName = 7;
		private const int conDlblReligionName = 8;
		private const int conDlblQualificationName = 15;
		private const int conDlblSponsorName = 10;
		private const int conDlblVisaTypeName = 9;
		private const int conDlblTicketTypeName = 11;
		private const int conDlblTicketDestinationName = 12;
		private const int conDlblTicketBalance = 13;
		private const int conDlblLocation = 17;
		private const int conDlblHeadCount = 18;

		private clsToolbar oThisFormToolBar = null;
		private string mTimeStamp = "";
		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		private int mNoOfEmployeeNo = 0;
		private string mDateOFJoinGlobal = "";
		private int mRecordNavigateSearchValue = 0;

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



		private void cmbCommon_Change(Object Sender, EventArgs e)
		{
			//''This code was not working for IMCO , so it has been moved to click event by hakim on 18-may-2009

			//Dim mEmpTypeId As Long
			//mEmpTypeId = cmbCommon(conCmbEmpType).ItemData(cmbCommon(conCmbEmpType).ListIndex)
			//If Index = conCmbEmpType Then
			//    If mEmpTypeId = 148 Then
			//        txtContractStratDate.Enabled = True
			//        txtContractEndDate.Enabled = True
			//        txtContractPeriod.Enabled = True
			//    Else
			//        txtContractStratDate.Enabled = False
			//        txtContractEndDate.Enabled = False
			//        txtContractPeriod.Enabled = False
			//    End If
			//End If
		}

		private void cmbCommon_Click(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.cmbCommon, Sender);
			int mEmpTypeId = 0;
			if (cmbCommon[conCmbEmpType].ListIndex >= 0)
			{
				mEmpTypeId = cmbCommon[conCmbEmpType].GetItemData(cmbCommon[conCmbEmpType].ListIndex);
			}

			if (Index == conCmbEmpType)
			{
				if (mEmpTypeId == 148)
				{
					txtContractStratDate.Enabled = true;
					txtContractEndDate.Enabled = true;
					txtContractPeriod.Enabled = true;
				}
				else
				{
					txtContractStratDate.Enabled = false;
					txtContractEndDate.Enabled = false;
					txtContractPeriod.Enabled = false;
				}
			}
		}

		private void showEmpDetails(int pIndex, int pForm)
		{
			DialogResult mAnswer = (DialogResult) 0;
			object mReturnValue = null;
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				mAnswer = MessageBox.Show("Do you want to save this record?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
				if (mAnswer == System.Windows.Forms.DialogResult.Yes)
				{
					if (!CheckDataValidity())
					{
						return;
					}
					if (!saveRecord())
					{
						return;
					}
				}
				else if (mAnswer == System.Windows.Forms.DialogResult.No)
				{ 
					AddRecord();
				}
				else
				{
					return;
				}
				CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			}
			if (pIndex == 0 || pIndex == 2)
			{
				SystemForms.GetSystemForm(pForm, 2, mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select time_stamp from pay_employee where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue)));
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
			}
			else
			{
				SystemForms.GetSystemForm(pForm, 2, mSearchValue);
			}
		}

		private void cmdPullGradeSetting_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{

				DialogResult mAnswer = (DialogResult) 0;
				object mReturnValue = null;
				string mysql = "";
				SqlDataReader rsTemp = null;
				int mGradeCd = 0;


				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mAnswer = MessageBox.Show("Do you want to save this record?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
					if (mAnswer == System.Windows.Forms.DialogResult.Yes)
					{
						if (!CheckDataValidity())
						{
							return;
						}
						if (!saveRecord())
						{
							return;
						}
					}
					else if (mAnswer == System.Windows.Forms.DialogResult.No)
					{ 
						AddRecord();
					}
					else
					{
						return;
					}
					CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				}

				mysql = " select last_salary_date from pay_employee ";
				mysql = mysql + " where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Employee Payroll Generated For One Month, Cannot pull from grade, Please create salary variation.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mGradeCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select grade_cd from pay_grade where grade_no =" + txtCommonTextBox[conTxtGradeCode].Text));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mGradeCd))
				{
					return;
				}

				SystemVariables.gConn.BeginTransaction();
				//************Import Fixed Earning and Deduction ***************************
				mysql = "select pgbd.* from pay_grade pg";
				mysql = mysql + " inner join pay_grade_billing_details pgbd on pgbd.grade_cd = pg.grade_cd";
				mysql = mysql + " where pg.grade_no=" + txtCommonTextBox[conTxtGradeCode].Text;
				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsTemp = sqlCommand.ExecuteReader();
				bool rsTempDidRead = rsTemp.Read();
				if (rsTempDidRead)
				{
					mysql = " delete from pay_employee_billing_details";
					mysql = mysql + " where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
					mysql = " insert into pay_employee_billing_details(emp_cd,bill_cd,billing_mode,amount, comments ,include_in_indemnity,user_cd)";
					mysql = mysql + " select " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + " ,bill_cd,billing_mode,amount,comments,include_in_indemnity, " + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " from pay_grade_billing_details";
					mysql = mysql + " where grade_cd =" + mGradeCd.ToString();
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}
				rsTemp.Close();

				//*************************End********************************************
				//************Import Leave Setting ***************************
				mysql = "select pgld.* from pay_grade pg";
				mysql = mysql + " inner join pay_grade_leave_details pgld on pgld.grade_cd = pg.grade_cd";
				mysql = mysql + " where pg.grade_no=" + txtCommonTextBox[conTxtGradeCode].Text;
				SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
				rsTemp = sqlCommand_2.ExecuteReader();
				bool rsTempDidRead2 = rsTemp.Read();
				if (rsTempDidRead)
				{
					mysql = " delete from pay_employee_leave_details";
					mysql = mysql + " where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();
					mysql = " insert into pay_employee_leave_details(emp_cd,leave_cd,leave_switch_over_period,leave_days_before_sop,leave_days_after_sop";
					mysql = mysql + " ,working_days_per_month_before_sop,working_days_per_month_after_sop";
					mysql = mysql + " ,deduct_paid_days,deduct_unpaid_days,comments,user_cd)";
					mysql = mysql + " select " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ", leave_cd,leave_switch_over_period,leave_days_before_sop,leave_days_after_sop";
					mysql = mysql + " ,working_days_per_month_before_sop,working_days_per_month_after_sop,deduct_paid_days";
					mysql = mysql + " ,deduct_unpaid_days,comments," + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " from pay_grade_leave_details";
					mysql = mysql + " where grade_cd = " + mGradeCd.ToString();
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();
				}
				rsTemp.Close();
				//*************************End********************************************
				//************Import Indemnity Setting ***************************
				mysql = "select pgid.* from pay_grade pg";
				mysql = mysql + " inner join pay_grade_indemnity_details pgid on pgid.grade_cd = pg.grade_cd";
				mysql = mysql + " where pg.grade_no=" + txtCommonTextBox[conTxtGradeCode].Text;
				SqlCommand sqlCommand_3 = new SqlCommand(mysql, SystemVariables.gConn);
				rsTemp = sqlCommand_3.ExecuteReader();
				bool rsTempDidRead3 = rsTemp.Read();
				if (rsTempDidRead)
				{
					mysql = " update pay_employee set ";
					mysql = mysql + " indemnity_switch_over_period =" + Convert.ToString(rsTemp["indemnity_switch_over_period"]);
					mysql = mysql + " , indemnity_days_before_sop =" + Convert.ToString(rsTemp["indemnity_days_before_sop"]);
					mysql = mysql + " , indemnity_days_after_sop =" + Convert.ToString(rsTemp["indemnity_days_after_sop"]);
					mysql = mysql + " , indemnity_working_days_per_month_before_sop =" + Convert.ToString(rsTemp["indemnity_working_days_per_month_before_sop"]);
					mysql = mysql + " , indemnity_working_days_per_month_after_sop =" + Convert.ToString(rsTemp["indemnity_working_days_per_month_after_sop"]);
					mysql = mysql + " , indemnity_deduct_paid_days =" + ((Convert.ToBoolean(rsTemp["indemnity_deduct_paid_days"])) ? 1 : 0).ToString();
					mysql = mysql + " , indemnity_deduct_unpaid_days =" + ((Convert.ToBoolean(rsTemp["indemnity_deduct_unpaid_days"])) ? 1 : 0).ToString();
					mysql = mysql + " , user_cd=" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_5 = null;
					TempCommand_5 = SystemVariables.gConn.CreateCommand();
					TempCommand_5.CommandText = mysql;
					TempCommand_5.ExecuteNonQuery();
				}
				rsTemp.Close();
				//*************************End********************************************
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, "Grade Setting Pull Days", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
			}
		}

		//Private Sub btnFormToolBar_Click(Index As Integer)
		//Call ToolBarButtonClick(Me, btnFormToolBar(Index).Tag)
		//End Sub

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			int Cnt = 0;

			FirstFocusObject = txtCommonTextBox[conTxtEmpCode];
			//On Error GoTo eFoundError

			this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			this.Top = 0;
			this.Left = 0;

			//**--format & define the new toolbar
			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			oThisFormToolBar.ShowNewButton = true;
			oThisFormToolBar.ShowSaveButton = true;
			oThisFormToolBar.ShowDeleteButton = true;
			oThisFormToolBar.BeginDeleteButtonWithGroup = true;

			oThisFormToolBar.ShowPrintButton = false;
			oThisFormToolBar.ShowFindButton = true;
			oThisFormToolBar.ShowEmployeeButton = true;
			oThisFormToolBar.BeginEmployeeButtonWithGroup = true;

			oThisFormToolBar.ShowHelpButton = true;
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.DisableHelpButton = true;

			oThisFormToolBar.ShowMoveRecordNextButton = true;
			oThisFormToolBar.ShowMoveRecordPreviousButton = true;

			oThisFormToolBar.ShowEmpPayrollButton = true;
			oThisFormToolBar.ShowEmpLeaveButton = true;
			oThisFormToolBar.ShowEmpIndemnityButton = true;
			oThisFormToolBar.ShowEmpFixedSalaryButton = true;
			oThisFormToolBar.ShowEmpDocumentButton = true;

			this.WindowState = FormWindowState.Maximized;
			//
			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_ticket")))
			{
				tabEmployee.Item(3).Visible = true;
			}
			else
			{
				this.tabEmployee.Item(3).Visible = false;
			}

			this.tabEmployee.Item(4).Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("HR_Budget"));


			//'Assign the Image for the toolbar
			//'Imagelist are kept on the main form and refered by their key
			//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
			//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
			//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
			//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
			//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
			//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
			//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
			//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture

			SystemProcedure.SetLabelCaption(this);


			//Set btnFormToolBar(7).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
			//Set btnFormToolBar(8).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture

			//**--make the form visible before all the control gets loaded
			//**--(this way system pretends to be faster in loading forms)
			this.Show();
			Application.DoEvents();
			//**-------------------------------------------------------------------------------------------

			//assign a next code
			txtCommonTextBox[conTxtEmpCode].Text = SystemProcedure2.GetNewNumber("pay_employee", "emp_no");
			tabEmployee.SelectedItem = conTabPersonnelBasic;
			txtJoiningDate.Value = DateTime.Today;
			txtBirthDate.Value = "01-jan-1900";
			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			txtCommonTextBox[conTxtProbationDays].Text = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("probation_period"));
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			//Fill the combo
			object[] mObjectId = new object[4];
			mObjectId[conCmbTitle] = 1001;
			mObjectId[conCmbSex] = 1002;
			mObjectId[conCmbMaritalStatus] = 1003;
			mObjectId[conCmbEmpType] = 1004;

			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mNoOfEmployeeNo = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Employee_No_Digit"));

			int mLen = 0;
			if (mNoOfEmployeeNo > 0)
			{
				mLen = Strings.Len(txtCommonTextBox[conTxtEmpCode].Text);
				while (mLen < mNoOfEmployeeNo)
				{
					txtCommonTextBox[conTxtEmpCode].Text = "0" + txtCommonTextBox[conTxtEmpCode].Text;
					mLen++;
				}
			}

			SystemCombo.FillComboWithSystemObjects(cmbCommon, mObjectId);

			//''modified by hakim on 20-may-2009
			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("use_cutoff")))
			{
				//If gLoggedInUserID = "Admin" Then
				txtDeductionHrs.Visible = true;
				lblDeductionHrs.Visible = true;
				if (SystemVariables.gLoggedInUserID == "Admin")
				{
					txtDeductionHrs.Enabled = true;
					txtDeductionHrs.BackColor = Color.White;
				}
			}
			txtContractStratDate.Text = "";
			txtContractEndDate.Text = "";
			//With cmbCommon(conCmbPayrollEmp)
			//    .AddItem "Yes"
			//    .ItemData(.NewIndex) = 1
			//    .AddItem "No"
			//    .ItemData(.NewIndex) = 0
			//    .ListIndex = 0
			//End With
			//
			//With cmbCommon(conCmbOverTime)
			//    .AddItem "Yes"
			//    .ItemData(.NewIndex) = 1
			//    .AddItem "No"
			//    .ItemData(.NewIndex) = 0
			//    .ListIndex = 0
			//End With
			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			//''''Added by yusuf as on 15-aug-2009 for grade setting
			txtDSeveranceDate.Text = "";
			cmdPullGradeSetting.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_Grade_Setting"));
			if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
			{
				txtDefaultProject.Visible = false;
				txtDlblDefaultProject.Visible = false;
				lblDefaultProject.Visible = false;
			}
			//''''End
			//UPGRADE_ISSUE: (2070) Constant vbCustom was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			imgPicture.Cursor = UpgradeStubs.System_Windows_Forms_Cursor.getvbCustom();
			imgPicture.Cursor = new Cursor((new Bitmap(frmSysIconsForm.DefInstance.imlSystemIcons.Images["imgHand"])).GetHicon());
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "Form Load");
			this.Close();
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//On Keydown navigate the form by using enter key
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					if (this.ActiveControl.Name == "txtCommonTextBox")
					{
						if (ControlArrayHelper.GetControlIndex(this.ActiveControl) == conTxtTelephoneNo2)
						{
							tabEmployee.SelectedItem = conTabPersonnelOthers;
						}
						else if (ControlArrayHelper.GetControlIndex(this.ActiveControl) == conTxtComments3)
						{ 
							txtCommonTextBox[conTxtEmpCode].Focus();
						}
						else if (ControlArrayHelper.GetControlIndex(this.ActiveControl) == conTxtComments)
						{ 
							tabEmployee.SelectedItem = conTabPersonnelDetailed;
						}
						else if (ControlArrayHelper.GetControlIndex(this.ActiveControl) == conTxtAFourthName)
						{ 
							tabEmployee.SelectedItem = conTabPersonnelBasic;
						}
					}
					SendKeys.Send("{TAB}");
					return;
				}


				//''(Alt + -> ) or ( Alt + <- )
				if (Shift == 4 && (KeyCode == 37 || KeyCode == 39))
				{
					if (!UserAccess.AllowUserDisplay)
					{
						MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					RecordNavidate(KeyCode, mRecordNavigateSearchValue);
					KeyCode = 0;
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

		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);
			txtCommonTextBox[conTxtEmpCode].Text = SystemProcedure2.GetNewNumber("pay_Employee", "emp_no");

			int mLen = 0;
			if (mNoOfEmployeeNo > 0)
			{
				mLen = Strings.Len(txtCommonTextBox[conTxtEmpCode].Text);
				while (mLen < mNoOfEmployeeNo)
				{
					txtCommonTextBox[conTxtEmpCode].Text = "0" + txtCommonTextBox[conTxtEmpCode].Text;
					mLen++;
				}
			}
			txtDSeveranceDate.Text = "";
			imgPicture.Tag = "";
			imgPicture.Image = Image.FromFile("");
			tabEmployee.SelectedItem = conTabPersonnelBasic;
			txtJoiningDate.Value = DateTime.Today;
			txtTicketAccrualStartDate.Value = DateTime.Today;
			txtContractStratDate.Text = "";
			txtContractEndDate.Text = "";
			txtContractStratDate.Enabled = false;
			txtContractEndDate.Enabled = false;
			txtContractPeriod.Enabled = false;
			txtCommonTextBox[conTxtGradeCode].Enabled = true;
			//chkHoldSalary.Value = 0
			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			txtCommonTextBox[conTxtProbationDays].Text = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("probation_period"));
			txtCommonTextBox[conTxtBudgetHeadCount].Enabled = true;
			chkAllowTicket.CheckState = CheckState.Unchecked;
			txtContractPeriod.Value = 0;
			txtNoticePeriod.Value = 0;
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			FirstFocusObject.Focus();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord()
		{
			bool result = false;
			object mHeadCountReturnValue = null;
			object mReturnValue = null;
			int mManagerCode = 0;
			int mDeptCode = 0;
			int mDesgCode = 0;
			int mGradeCode = 0;
			int mNatCode = 0;
			int mHeadContCd = 0;
			int mReligionCode = 0;
			int mQalfnCode = 0;
			int mCompCode = 0;
			int mSponsorCode = 0;
			int mVisaCode = 0;
			int mDefaultProjectCd = 0;
			string mysql = "";
			int mCnt = 0;
			int mTicketType = 0;
			int mTicketDestination = 0;
			int mLocationCd = 0;

			//Save a record
			//During save check for the mode
			//If in addmode then insert a record
			//else update the record in the recordset

			try
			{

				DataSet rsTemp = new DataSet();

				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_Change_Employee_No")) && mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					mysql = "select emp_no from pay_employee where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					if (ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) != txtCommonTextBox[conTxtEmpCode].Text)
					{
						MessageBox.Show("Employee No cann't be changed!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}

				//'Dept Query
				mysql = "select dept_cd from pay_department ";
				mysql = mysql + " where dept_no = " + txtCommonTextBox[conTxtDeptCode].Text;
				//'Desg Query
				mysql = mysql + " ;select desg_cd from pay_designation ";
				mysql = mysql + " where desg_no = " + txtCommonTextBox[conTxtDesignationCode].Text;
				//'Grade query
				mysql = mysql + " ;select grade_cd from pay_grade ";
				mysql = mysql + " where grade_no = " + txtCommonTextBox[conTxtGradeCode].Text;
				//'Nationality query
				mysql = mysql + " ;select nat_cd from pay_nationality ";
				mysql = mysql + " where nat_no = " + txtCommonTextBox[conTxtNatCode].Text;
				//'Company query
				mysql = mysql + " ;select comp_cd from pay_company ";
				mysql = mysql + " where comp_no = " + txtCommonTextBox[conTxtCompanyCode].Text;

				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsTemp.Tables.Clear();
				adap.Fill(rsTemp);
				mCnt = 1;
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsTemp.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064

				while(rsTemp.getState() != ConnectionState.Closed)
				{
					if (mCnt == 1)
					{
						if (rsTemp.Tables[0].Rows.Count == 0)
						{
							MessageBox.Show("Invalid Department Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							tabEmployee.SelectedItem = conTabPersonnelBasic;
							txtCommonTextBox[conTxtDeptCode].Focus();
							goto errorexit;
						}
						else
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mDeptCode = Convert.ToInt32(rsTemp.Tables[0].Rows[0][0]);
						}
					}
					else if (mCnt == 2)
					{ 
						if (rsTemp.Tables[0].Rows.Count == 0)
						{
							MessageBox.Show("Invalid Designation Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							tabEmployee.SelectedItem = conTabPersonnelBasic;
							txtCommonTextBox[conTxtDesignationCode].Focus();
							goto errorexit;
						}
						else
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mDesgCode = Convert.ToInt32(rsTemp.Tables[0].Rows[0][0]);
						}
					}
					else if (mCnt == 3)
					{ 
						if (rsTemp.Tables[0].Rows.Count == 0)
						{
							MessageBox.Show("Invalid Grade Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							tabEmployee.SelectedItem = conTabPersonnelBasic;
							txtCommonTextBox[conTxtGradeCode].Focus();
							goto errorexit;
						}
						else
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mGradeCode = Convert.ToInt32(rsTemp.Tables[0].Rows[0][0]);
						}
					}
					else if (mCnt == 4)
					{ 
						if (rsTemp.Tables[0].Rows.Count == 0)
						{
							MessageBox.Show("Invalid Nationality Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							tabEmployee.SelectedItem = conTabPersonnelBasic;
							txtCommonTextBox[conTxtNatCode].Focus();
							goto errorexit;
						}
						else
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mNatCode = Convert.ToInt32(rsTemp.Tables[0].Rows[0][0]);
						}
					}
					else if (mCnt == 5)
					{ 
						if (rsTemp.Tables[0].Rows.Count == 0)
						{
							MessageBox.Show("Invalid Company Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							tabEmployee.SelectedItem = conTabPersonnelBasic;
							txtCommonTextBox[conTxtCompanyCode].Focus();
							goto errorexit;
						}
						else
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mCompCode = Convert.ToInt32(rsTemp.Tables[0].Rows[0][0]);
						}
					}

					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTemp.NextRecordset was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsTemp = rsTemp.NextRecordset(null);
					mCnt++;
				};
				rsTemp = null;

				//'Added By Yusuf Date:30-Oct-2008
				if (chkAllowTicket.CheckState == CheckState.Checked)
				{
					//'Ticket Type
					mysql = "select entry_id from pay_ticket_type ";
					mysql = mysql + " where entry_id = " + txtCommonTextBox[conTxtTicketType].Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Ticket Type", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabEmployee.SelectedItem = conTabPersonnelOthersDetails;
						txtCommonTextBox[conTxtTicketType].Focus();
						goto errorexit;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTicketType = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}

					//'Ticket Destination
					mysql = "select entry_id from pay_ticket_destination ";
					mysql = mysql + " where entry_id =" + txtCommonTextBox[conTxtTicketDestination].Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Ticket Destination", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabEmployee.SelectedItem = conTabPersonnelOthersDetails;
						txtCommonTextBox[conTxtTicketDestination].Focus();
						goto errorexit;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTicketDestination = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				//'End

				//'Manager query
				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtManagerCode].Text, SystemVariables.DataType.StringType))
				{
					mysql = "select emp_cd from pay_employee ";
					mysql = mysql + " where emp_no ='" + txtCommonTextBox[conTxtManagerCode].Text + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Employee Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabEmployee.SelectedItem = conTabPersonnelBasic;
						txtCommonTextBox[conTxtManagerCode].Focus();
						goto errorexit;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mManagerCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}

				//' Default Project Code
				if (!SystemProcedure2.IsItEmpty(txtDefaultProject.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select project_cd from gl_projects ";
					mysql = mysql + " where project_no ='" + txtDefaultProject.Text + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Project Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabEmployee.SelectedItem = conTabPersonnelOthers;
						txtDefaultProject.Focus();
						goto errorexit;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mDefaultProjectCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				else
				{
					mDefaultProjectCd = 0;
				}

				//' Location Code
				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtLocation].Text, SystemVariables.DataType.StringType))
				{
					mysql = "select location_cd from pay_emp_location ";
					mysql = mysql + " where location_no ='" + txtCommonTextBox[conTxtLocation].Text + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Location Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabEmployee.SelectedItem = conTabPersonnelBasic;
						txtCommonTextBox[conTxtLocation].Focus();
						goto errorexit;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLocationCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				else
				{
					mLocationCd = 0;
				}

				//'Religion query
				if (Information.IsNumeric(txtCommonTextBox[conTxtReligionCode].Text))
				{
					mysql = "select religion_cd from pay_religion ";
					mysql = mysql + " where religion_no = " + txtCommonTextBox[conTxtReligionCode].Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Religion Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabEmployee.SelectedItem = conTabPersonnelBasic;
						txtCommonTextBox[conTxtReligionCode].Focus();
						goto errorexit;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReligionCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}

				// Added By Burhan Fri, 8-June-07
				//'Sponsor Query
				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtSponsorCode].Text, SystemVariables.DataType.StringType))
				{
					mysql = "select Sponsor_cd from pay_Sponsor ";
					mysql = mysql + " where sponsor_no = " + txtCommonTextBox[conTxtSponsorCode].Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Sponsor Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabEmployee.SelectedItem = conTabPersonnelOthers;
						txtCommonTextBox[conTxtSponsorCode].Focus();
						goto errorexit;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mSponsorCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}

				//'Visa Type Query
				if (Information.IsNumeric(txtCommonTextBox[conTxtVisaType].Text))
				{
					mysql = "select Visa_Type_cd from Pay_Visa_type ";
					mysql = mysql + " where L_Visa_Type_no = " + txtCommonTextBox[conTxtVisaType].Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Visa Type Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabEmployee.SelectedItem = conTabPersonnelOthers;
						txtCommonTextBox[conTxtVisaType].Focus();
						goto errorexit;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mVisaCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}


				//'Qualification query
				if (Information.IsNumeric(txtCommonTextBox[conTxtQualificationCode].Text))
				{
					mysql = "select qalfn_cd from pay_qualification ";
					mysql = mysql + " where qalfn_no = " + txtCommonTextBox[conTxtQualificationCode].Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Qualification Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabEmployee.SelectedItem = conTabPersonnelOthers;
						txtCommonTextBox[conTxtReligionCode].Focus();
						goto errorexit;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mQalfnCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}

				//'Budgeted Head Count
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("HR_Budget")))
				{
					if (Information.IsNumeric(txtCommonTextBox[conTxtBudgetHeadCount].Text))
					{
						mysql = "select head_count_cd from pay_head_count ";
						mysql = mysql + " where head_count_no = " + txtCommonTextBox[conTxtBudgetHeadCount].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue))
						{
							MessageBox.Show("Invalid Headcount Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							goto errorexit;
						}
						else
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mHeadContCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
						}
					}
					else
					{
						MessageBox.Show("Please Update Budget Head count!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}
				else
				{
					mHeadContCd = 0;
				}

				SystemVariables.gConn.BeginTransaction();
				object[, ] mSystemPreference = null;
				int mEmpCd = 0;
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{

					//''''''''''Get system preference default value "
					mSystemPreference = new object[17, 2];

					mSystemPreference[0, 0] = "Days_Per_Month";
					mSystemPreference[1, 0] = "Hours_Per_Day";
					mSystemPreference[2, 0] = "WeekEnd";
					mSystemPreference[3, 0] = "WeekEnd_Day1";
					mSystemPreference[4, 0] = "WeekEnd_Day2";
					mSystemPreference[5, 0] = "NormalOT";
					mSystemPreference[6, 0] = "FridayOT";
					mSystemPreference[7, 0] = "HolidayOT";

					mSystemPreference[8, 0] = "Indemnity_Switch_Over_Period";
					mSystemPreference[9, 0] = "Indemnity_Days_Before_SOP";
					mSystemPreference[10, 0] = "Indemnity_Days_After_SOP";
					mSystemPreference[11, 0] = "WD_Per_Month_Before_SOP";
					mSystemPreference[12, 0] = "WD_Per_Month_After_SOP";
					mSystemPreference[13, 0] = "Deduct_Paid_Days";
					mSystemPreference[14, 0] = "Deduct_Unpaid_Days";
					mSystemPreference[15, 0] = "Rate_Calc_Method";
					mSystemPreference[16, 0] = "Overtime_Working_Days";

					GetSystemPreferenceValue(mSystemPreference);
					//''''''''''''''''''''''''''''''''''''''''''''''''''''
					mysql = " insert into pay_employee (dept_cd, sponsor_cd, visa_type,  desg_cd, grade_cd, nat_cd, comp_cd ";
					mysql = mysql + " , manager_cd, qalfn_cd, religion_cd, emp_no ";
					mysql = mysql + " , l_first_name, l_second_name, l_third_name, l_fourth_name , l_fifth_name";
					mysql = mysql + " , a_first_name, a_second_name, a_third_name, a_fourth_name , a_fifth_name";
					mysql = mysql + " , date_of_birth, l_father_name, a_father_name";
					mysql = mysql + " , l_mother_name, a_mother_name, place_of_birth, sex_id, title_id ";
					mysql = mysql + " , date_of_joining";
					mysql = mysql + " , blood_group, marital_status_id, no_of_wives, no_of_child";
					mysql = mysql + " , block, street, lane, type_of_building, building_no, qasima";
					mysql = mysql + " , floor, flat_no, po_box, zip_cd, phone, fax, email, pager, mobile";
					mysql = mysql + " , permanent_addr_1, permanent_addr_2, permanent_addr_3, permanent_addr_4";
					mysql = mysql + " , permanent_phone, emp_type_id ";
					mysql = mysql + " , civil_id, passport_no, work_permit_no ";
					mysql = mysql + " , visa_no ";
					mysql = mysql + " , days_per_month, hours_per_day, weekend, weekend_day1_id";
					mysql = mysql + " , weekend_day2_id, normal_ot, friday_ot, holiday_ot ";
					mysql = mysql + " , indemnity_switch_over_period , indemnity_days_before_sop";
					mysql = mysql + " , indemnity_days_after_sop ";
					mysql = mysql + " , indemnity_working_days_per_month_before_sop ";
					mysql = mysql + " , indemnity_working_days_per_month_after_sop";
					mysql = mysql + " , indemnity_deduct_paid_days ";
					mysql = mysql + " , indemnity_deduct_unpaid_days ";
					mysql = mysql + " , rate_calc_method_id ";
					mysql = mysql + " , Overtime_Working_Days";

					mysql = mysql + " , opening_indemnity_as_on ";

					mysql = mysql + " , comments, emp_Picture_Path, area, probation_end_date, entrance, comment1, comment2, comment3, probation_days, user_cd";
					mysql = mysql + " , ticket,ticket_type,ticket_destination,ticket_start_date,contract_start_date";
					mysql = mysql + " , contract_end_date,contract_period,deduction_hrs,default_project";
					mysql = mysql + " , notice_period , login_id ,payment_type_id ,is_payroll_emp";
					mysql = mysql + " , qualf_description,professional_qualf,year_of_Graduation,Relevant_experience,Irrelevant_experience";
					mysql = mysql + " , Analysis1,Analysis2,Analysis3,Analysis4,Analysis5,location_cd , Head_Count_cd";
					mysql = mysql + " )";
					mysql = mysql + " values (";
					mysql = mysql + mDeptCode.ToString();
					mysql = mysql + " , " + ((mSponsorCode == 0) ? "NULL" : mSponsorCode.ToString());
					mysql = mysql + " , " + ((mVisaCode == 0) ? "NULL" : mVisaCode.ToString());
					mysql = mysql + " , " + mDesgCode.ToString();
					mysql = mysql + " , " + mGradeCode.ToString();
					mysql = mysql + " , " + mNatCode.ToString();
					mysql = mysql + " , " + mCompCode.ToString();
					if (mManagerCode == 0)
					{
						mysql = mysql + " , NULL ";
					}
					else
					{
						mysql = mysql + " , " + mManagerCode.ToString();
					}
					if (mQalfnCode == 0)
					{
						mysql = mysql + " , NULL ";
					}
					else
					{
						mysql = mysql + " , " + mQalfnCode.ToString();
					}
					if (mReligionCode == 0)
					{
						mysql = mysql + " , NULL ";
					}
					else
					{
						mysql = mysql + " , " + mReligionCode.ToString();
					}
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtEmpCode].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtLFirstName].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtLSecondName].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtLThirdName].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtLFourthName].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtLFifthName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAFirstName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtASecondName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAThirdName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAFourthName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAFifthName].Text + "'";

					if (!Information.IsDate(txtBirthDate.DisplayText))
					{
						mysql = mysql + " , NULL ";
					}
					else
					{
						mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtBirthDate.DisplayText) + "'";
					}

					mysql = mysql + " ,'" + txtCommonTextBox[conTxtLFatherName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAFatherName].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtLMotherName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAMotherName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtPlaceOfBirth].Text + "'";
					mysql = mysql + " , " + cmbCommon[conCmbSex].GetItemData(cmbCommon[conCmbSex].ListIndex).ToString();
					mysql = mysql + " , " + cmbCommon[conCmbTitle].GetItemData(cmbCommon[conCmbTitle].ListIndex).ToString();

					mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtJoiningDate.DisplayText) + "'"; //Joining Date
					//mysql = mysql & " ,'" & txtJoiningDate.DisplayText & "'"        'Last salary Date.

					mysql = mysql + " ,'" + txtCommonTextBox[conTxtBloodGroup].Text + "'";
					mysql = mysql + " , " + cmbCommon[conCmbMaritalStatus].GetItemData(cmbCommon[conCmbMaritalStatus].ListIndex).ToString();

					if (Information.IsNumeric(txtCommonTextBox[conTxtNoOfWives].Text))
					{
						mysql = mysql + " ," + txtCommonTextBox[conTxtNoOfWives].Text;
					}
					else
					{
						mysql = mysql + " ,NULL ";
					}

					if (Information.IsNumeric(txtCommonTextBox[conTxtNoOfChildren].Text))
					{
						mysql = mysql + " ," + txtCommonTextBox[conTxtNoOfChildren].Text;
					}
					else
					{
						mysql = mysql + " ,NULL ";
					}

					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtBlock].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtStreet].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtLane].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtTypeofBldg].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtBldgNo].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtQasima].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtFloor].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtFlatNo].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtPOBox].Text + "'";

					if (Information.IsNumeric(txtCommonTextBox[conTxtZipCode].Text))
					{
						mysql = mysql + " ," + txtCommonTextBox[conTxtZipCode].Text;
					}
					else
					{
						mysql = mysql + " ,NULL ";
					}

					mysql = mysql + " ,'" + txtCommonTextBox[conTxtTelephoneNo1].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtFax].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtEmailAddress].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtPagerNo].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtMobileno].Text + "'";

					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAddress1].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAddress2].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAddress3].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAddress4].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtTelephoneNo2].Text + "'";

					mysql = mysql + " , " + cmbCommon[conCmbEmpType].GetItemData(cmbCommon[conCmbEmpType].ListIndex).ToString();
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtCivilId].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtPassportNo].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtWorkPermitNo].Text + "'";
					//mySql = mySql & " ,N'" & txtCommonTextBox(conTxtVisaType).Text & "'"
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtVisaNo].Text + "'";

					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[0, 1]); //Days_Per_Month
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[1, 1]); //Hours_Per_Day
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[2, 1]); //WeekEnd
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[3, 1]); //WeekEnd_Day1
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[4, 1]); //WeekEnd_Day2
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[5, 1]); //NormalOT
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[6, 1]); //FridayOT
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[7, 1]); //HolidayOT

					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[8, 1]); //Indemnity_Switch_Over_Period
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[9, 1]); //Indemnity_Days_Before_SOP
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[10, 1]); //Indemnity_Days_After_SOP
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[11, 1]); //WD_Per_Month_Before_SOP
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[12, 1]); //WD_Per_Month_After_SOP
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[13, 1]); //Deduct_Paid_Days
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[14, 1]); //Deduct_Unpaid_Days
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[15, 1]); //Rate_Calc_Method
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(mSystemPreference[16, 1]); //Overtime_Working_Days

					mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtJoiningDate.DisplayText) + "'"; //Opening Indemnity As On


					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtComments].Text + "'";
					mysql = mysql + " ,'" + Convert.ToString(imgPicture.Tag) + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtArea].Text + "'";
					if (Information.IsDate(txtProbationEndDate.DisplayText))
					{
						mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtProbationEndDate.DisplayText) + "'";
					}
					else
					{
						mysql = mysql + " , NULL";
					}
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtEntrance].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtComments1].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtComments2].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtComments3].Text + "'";
					mysql = mysql + " , " + Conversion.Val(txtCommonTextBox[conTxtProbationDays].Text).ToString();
					mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " , " + ((int) chkAllowTicket.CheckState).ToString();
					if (Information.IsNumeric(txtCommonTextBox[conTxtTicketType].Text))
					{
						mysql = mysql + " , " + mTicketType.ToString();
					}
					else
					{
						mysql = mysql + " , Null";
					}
					if (Information.IsNumeric(txtCommonTextBox[conTxtTicketDestination].Text))
					{
						mysql = mysql + " , " + mTicketDestination.ToString();
					}
					else
					{
						mysql = mysql + " , Null";
					}
					if (chkAllowTicket.CheckState != CheckState.Unchecked)
					{
						mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtTicketAccrualStartDate.Value) + "'";
					}
					else
					{
						mysql = mysql + " , Null";
					}
					if (Information.IsDate(txtContractStratDate.Value))
					{
						mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtContractStratDate.Value) + "'";
					}
					else
					{
						mysql = mysql + " ,Null";
					}
					if (Information.IsDate(txtContractEndDate.Value))
					{
						mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtContractEndDate.Value) + "'";
					}
					else
					{
						mysql = mysql + " ,Null";
					}
					mysql = mysql + " ," + ReflectionHelper.GetPrimitiveValue<string>(txtContractPeriod.Value);
					mysql = mysql + " ," + Convert.ToInt32(Double.Parse(txtDeductionHrs.Text)).ToString();

					if (mDefaultProjectCd == 0)
					{
						mysql = mysql + " ,null";
					}
					else
					{
						mysql = mysql + " ," + mDefaultProjectCd.ToString();
					}

					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtNoticePeriod.Value);

					if (!SystemProcedure2.IsItEmpty(txtLoginID.Text, SystemVariables.DataType.StringType))
					{
						mysql = mysql + " ," + txtLoginID.Text + "'";
					}
					else
					{
						mysql = mysql + " ,NULL ";
					}
					mysql = mysql + " , 26 , 1";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtQualfDesc].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtProfessionalDesc].Text + "'";
					mysql = mysql + " , " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtYearOfPassing].Text, SystemVariables.DataType.NumberType)) ? "NULL" : txtCommonTextBox[conTxtYearOfPassing].Text);
					mysql = mysql + " , " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtReliventExp].Text, SystemVariables.DataType.NumberType)) ? "NULL" : txtCommonTextBox[conTxtReliventExp].Text);
					mysql = mysql + " , " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtIrreliventExp].Text, SystemVariables.DataType.NumberType)) ? "NULL" : txtCommonTextBox[conTxtIrreliventExp].Text);
					mysql = mysql + " , " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtAnalysis1].Text, SystemVariables.DataType.StringType)) ? "NULL" : "'" + txtCommonTextBox[conTxtAnalysis1].Text + "'");
					mysql = mysql + " , " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtAnalysis2].Text, SystemVariables.DataType.StringType)) ? "NULL" : "'" + txtCommonTextBox[conTxtAnalysis2].Text + "'");
					mysql = mysql + " , " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtAnalysis3].Text, SystemVariables.DataType.StringType)) ? "NULL" : "'" + txtCommonTextBox[conTxtAnalysis3].Text + "'");
					mysql = mysql + " , " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtAnalysis4].Text, SystemVariables.DataType.StringType)) ? "NULL" : "'" + txtCommonTextBox[conTxtAnalysis4].Text + "'");
					mysql = mysql + " , " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtAnalysis5].Text, SystemVariables.DataType.StringType)) ? "NULL" : "'" + txtCommonTextBox[conTxtAnalysis5].Text + "'");
					mysql = mysql + " , " + ((mLocationCd == 0) ? "Null" : mLocationCd.ToString());
					mysql = mysql + " , " + ((mHeadContCd == 0) ? "Null" : mHeadContCd.ToString());
					mysql = mysql + " ) ";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();


					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					//''''Insert the main billings in the details table when the employee is created

					//added by burhan for buttons to call different forms
					mSearchValue = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
					//end
					//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);

					rsTemp = new DataSet();
					mysql = " select bill_cd, is_basic_pay, linked_leave_cd ";
					mysql = mysql + " from pay_billing_type ";
					mysql = mysql + " where include_in_default_billing_types = 1 ";

					SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsTemp.Tables.Clear();
					adap_2.Fill(rsTemp);
					foreach (DataRow iteration_row in rsTemp.Tables[0].Rows)
					{
						mysql = " INSERT INTO Pay_Employee_Billing_Details(user_cd, emp_cd, bill_cd ";
						mysql = mysql + " , include_in_leave ";
						mysql = mysql + " , include_in_indemnity ";
						mysql = mysql + " , billing_mode)";
						mysql = mysql + " VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode);
						mysql = mysql + " , " + mEmpCd.ToString(); //Emp Code
						mysql = mysql + "," + Convert.ToString(iteration_row["bill_cd"]); //Bill Code
						if (Convert.ToBoolean(iteration_row["is_basic_pay"]))
						{
							//''Basic Salary
							mysql = mysql + ",1,1";
							mysql = mysql + ",'F'";
						}
						else
						{
							//''Others
							mysql = mysql + ", 0 , 0 ";
							mysql = mysql + ",'F'";
						}
						mysql = mysql + ")";
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();

						//            If Not IsNull(.Fields("linked_leave_cd")) Then
						//                mySql = " insert into pay_employee_leave_details"
						//                mySql = mySql & " (emp_cd, leave_cd, leave_switch_over_period, leave_days_before_sop "
						//                mySql = mySql & " , leave_days_after_sop, working_days_per_month_before_sop"
						//                mySql = mySql & " , working_days_per_month_after_sop, deduct_paid_days"
						//                mySql = mySql & " , deduct_unpaid_days, Opening_Paid_Leave_Balance_Date, user_cd) "
						//                mySql = mySql & " select "
						//                mySql = mySql & mEmpCd
						//                mySql = mySql & " , leave_cd "          'Leave Code
						//                mySql = mySql & " , leave_switch_over_period, leave_days_before_sop"
						//                mySql = mySql & " , leave_days_after_sop, working_days_per_month_before_sop "
						//                mySql = mySql & " , working_days_per_month_after_sop, deduct_paid_days"
						//                mySql = mySql & " , deduct_unpaid_days"
						//                mySql = mySql & " ,'" & txtJoiningDate.DisplayText & "'"        'Joining Date
						//                mySql = mySql & " , " & Str(gLoggedInUserCode)
						//                mySql = mySql & " from pay_leave "
						//                mySql = mySql & " where leave_cd = " & .Fields("linked_leave_cd")
						//
						//                gConn.Execute mySql
						//            End If

					}
					//added by burhan
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("SELECT time_stamp from pay_employee where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue)));
					//end


					mysql = " insert into pay_employee_leave_details";
					mysql = mysql + " (emp_cd, leave_cd, leave_switch_over_period, leave_days_before_sop ";
					mysql = mysql + " , leave_days_after_sop, working_days_per_month_before_sop";
					mysql = mysql + " , working_days_per_month_after_sop, deduct_paid_days";
					mysql = mysql + " , deduct_unpaid_days, Opening_Paid_Leave_Balance_Date, user_cd) ";
					mysql = mysql + " select ";
					mysql = mysql + mEmpCd.ToString();
					mysql = mysql + " , leave_cd "; //Leave Code
					mysql = mysql + " , leave_switch_over_period, leave_days_before_sop";
					mysql = mysql + " , leave_days_after_sop, working_days_per_month_before_sop ";
					mysql = mysql + " , working_days_per_month_after_sop, deduct_paid_days";
					mysql = mysql + " , deduct_unpaid_days";
					mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtJoiningDate.DisplayText) + "'"; //Joining Date
					mysql = mysql + " , " + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " from pay_leave ";
					mysql = mysql + " where include_in_default_leave_types = 1";

					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					//Added By Yusuf As on 11-06-2008
					//Desc: For Generate Time and Attendance Entry
					//For Generate Time Attendance Entry For That Employee
					if (!SystemHRProcedure.GenerateTimeAttendanceMonthlyTransaction(mEmpCd, mEmpCd))
					{
						MessageBox.Show("Time And Attendance Record Not Generated!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					if (!SystemHRProcedure.UpdateTimeAttendanceDayOff(mEmpCd, mEmpCd))
					{
						MessageBox.Show("Time And Attendance Record Not Generated!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					// Added By Yusuf On 28-Jan-2012 For Budget Update
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("HR_Budget")))
					{

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mHeadCountReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Emp_cd,Head_Count_Category_Cd from pay_head_count where head_count_no = " + txtCommonTextBox[conTxtBudgetHeadCount].Text));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(((Array) mHeadCountReturnValue).GetValue(0)))
						{
							mysql = "INSERT INTO Pay_Head_Count";
							mysql = mysql + " (Head_Count_Category_Cd,Head_Count_No,Emp_Cd,Is_Budgeted";
							mysql = mysql + " ,Budget_Details_Line_No,Head_Count_Status,Comments,User_Cd,analysis3_cd,analysis1_cd";
							mysql = mysql + " ,analysis2_cd,analysis4_cd,analysis5_cd,Total_Budget_Salary)";
							mysql = mysql + " Values( " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mHeadCountReturnValue).GetValue(1));
							mysql = mysql + " , " + SystemProcedure2.GetNewNumber("Pay_Head_Count", "Head_Count_No");
							mysql = mysql + " , NULL , 0 , NULL , 2 , '' ," + SystemVariables.gLoggedInUserCode.ToString();
							mysql = mysql + " , '' , ''";
							mysql = mysql + " , '','' ";
							mysql = mysql + " , '' , 0 ";
							mysql = mysql + " ) ";
							SqlCommand TempCommand_4 = null;
							TempCommand_4 = SystemVariables.gConn.CreateCommand();
							TempCommand_4.CommandText = mysql;
							TempCommand_4.ExecuteNonQuery();

							mysql = "update pay_head_count";
							mysql = mysql + " set Head_count_status = 4 ";
							mysql = mysql + " where head_count_no = " + txtCommonTextBox[conTxtBudgetHeadCount].Text;
							SqlCommand TempCommand_5 = null;
							TempCommand_5 = SystemVariables.gConn.CreateCommand();
							TempCommand_5.CommandText = mysql;
							TempCommand_5.ExecuteNonQuery();
						}
						else
						{
							mysql = "update pay_head_count";
							mysql = mysql + " set Head_count_status = 2 ";
							mysql = mysql + " , Emp_cd = " + ReflectionHelper.GetPrimitiveValue<int>(mSearchValue).ToString();
							mysql = mysql + " , Is_Budgeted = 0 ";
							mysql = mysql + "  ,analysis1_cd = ''";
							mysql = mysql + "  ,analysis2_cd = ''";
							mysql = mysql + "  ,analysis3_cd = ''";
							mysql = mysql + "  ,analysis4_cd = ''";
							mysql = mysql + "  ,analysis5_cd = ''";
							mysql = mysql + " where head_count_no = " + txtCommonTextBox[conTxtBudgetHeadCount].Text;
							SqlCommand TempCommand_6 = null;
							TempCommand_6 = SystemVariables.gConn.CreateCommand();
							TempCommand_6.CommandText = mysql;
							TempCommand_6.ExecuteNonQuery();
						}
					}
					//    mWorkHoursEntryId = GetTAEntryID(mEmpCd, WorkHours, Year(CDate(GetPayrollGenerateDate)), Month((CDate(GetPayrollGenerateDate))))
					//    Call UpdateAttendanceFieldsHours(GetPayrollGenerateStartDate, txtJoiningDate.DisplayText, mWorkHoursEntryId, 0, True)
					//''End
				}
				else
				{
					mysql = " select time_stamp from pay_employee where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}
					else
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						FirstFocusObject.Focus();
						return result;
					}

					if (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp))
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						FirstFocusObject.Focus();
						return result;
					}

					mysql = " update pay_employee set ";
					mysql = mysql + " dept_cd =" + mDeptCode.ToString();
					mysql = mysql + ", visa_Type = " + ((mVisaCode == 0) ? "NULL" : mVisaCode.ToString());
					mysql = mysql + ", Sponsor_cd =" + ((mSponsorCode == 0) ? "NULL" : mSponsorCode.ToString());
					mysql = mysql + " , desg_cd =" + mDesgCode.ToString();
					mysql = mysql + " , grade_cd =" + mGradeCode.ToString();
					mysql = mysql + " , nat_cd =" + mNatCode.ToString();
					mysql = mysql + " , comp_cd =" + mCompCode.ToString();
					if (mManagerCode == 0)
					{
						mysql = mysql + " , manager_cd = NULL ";
					}
					else
					{
						mysql = mysql + " , manager_cd =" + mManagerCode.ToString();
					}

					if (mQalfnCode == 0)
					{
						mysql = mysql + " , qalfn_cd = NULL ";
					}
					else
					{
						mysql = mysql + " , qalfn_cd =" + mQalfnCode.ToString();
					}

					if (mReligionCode == 0)
					{
						mysql = mysql + " , religion_cd = NULL ";
					}
					else
					{
						mysql = mysql + " , religion_cd =" + mReligionCode.ToString();
					}

					mysql = mysql + " , emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
					mysql = mysql + " , l_first_name ='" + txtCommonTextBox[conTxtLFirstName].Text + "'";
					mysql = mysql + " , l_second_name ='" + txtCommonTextBox[conTxtLSecondName].Text + "'";
					mysql = mysql + " , l_third_name ='" + txtCommonTextBox[conTxtLThirdName].Text + "'";
					mysql = mysql + " , l_fourth_name ='" + txtCommonTextBox[conTxtLFourthName].Text + "'";
					mysql = mysql + " , l_fifth_name ='" + txtCommonTextBox[conTxtLFifthName].Text + "'";
					mysql = mysql + " , a_first_name =N'" + txtCommonTextBox[conTxtAFirstName].Text + "'";
					mysql = mysql + " , a_second_name =N'" + txtCommonTextBox[conTxtASecondName].Text + "'";
					mysql = mysql + " , a_third_name =N'" + txtCommonTextBox[conTxtAThirdName].Text + "'";
					mysql = mysql + " , a_fourth_name =N'" + txtCommonTextBox[conTxtAFourthName].Text + "'";
					mysql = mysql + " , a_fifth_name =N'" + txtCommonTextBox[conTxtAFifthName].Text + "'";

					mysql = mysql + " , emp_picture_path = '" + Convert.ToString(imgPicture.Tag) + "'";
					if (!Information.IsDate(txtBirthDate.DisplayText))
					{
						mysql = mysql + " , date_of_birth = NULL ";
					}
					else
					{
						mysql = mysql + " , date_of_birth ='" + ReflectionHelper.GetPrimitiveValue<string>(txtBirthDate.DisplayText) + "'";
					}

					if (!Information.IsDate(txtJoiningDate.DisplayText))
					{
						mysql = mysql + " , date_of_joining = NULL ";
					}
					else
					{
						mysql = mysql + " , date_of_joining ='" + ReflectionHelper.GetPrimitiveValue<string>(txtJoiningDate.DisplayText) + "'";
					}

					if (!Information.IsDate(txtProbationEndDate.DisplayText))
					{
						mysql = mysql + " , probation_end_date = NULL ";
					}
					else
					{
						mysql = mysql + " , probation_end_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtProbationEndDate.DisplayText) + "'";
					}

					mysql = mysql + " , l_father_name ='" + txtCommonTextBox[conTxtLFatherName].Text + "'";
					mysql = mysql + " , a_father_name = N'" + txtCommonTextBox[conTxtAFatherName].Text + "'";
					mysql = mysql + " , l_mother_name ='" + txtCommonTextBox[conTxtLMotherName].Text + "'";
					mysql = mysql + " , a_mother_name = N'" + txtCommonTextBox[conTxtAMotherName].Text + "'";
					mysql = mysql + " , place_of_birth = N'" + txtCommonTextBox[conTxtPlaceOfBirth].Text + "'";
					mysql = mysql + " , blood_group ='" + txtCommonTextBox[conTxtBloodGroup].Text + "'";

					mysql = mysql + " , sex_id=" + cmbCommon[conCmbSex].GetItemData(cmbCommon[conCmbSex].ListIndex).ToString();
					mysql = mysql + " , title_id =" + cmbCommon[conCmbTitle].GetItemData(cmbCommon[conCmbTitle].ListIndex).ToString();
					mysql = mysql + " , marital_status_id=" + cmbCommon[conCmbMaritalStatus].GetItemData(cmbCommon[conCmbMaritalStatus].ListIndex).ToString();
					mysql = mysql + " , emp_type_id=" + cmbCommon[conCmbEmpType].GetItemData(cmbCommon[conCmbEmpType].ListIndex).ToString();

					if (Information.IsNumeric(txtCommonTextBox[conTxtNoOfWives].Text))
					{
						mysql = mysql + " , no_of_wives = " + txtCommonTextBox[conTxtNoOfWives].Text;
					}
					else
					{
						mysql = mysql + " , no_of_wives = NULL ";
					}

					if (Information.IsNumeric(txtCommonTextBox[conTxtNoOfChildren].Text))
					{
						mysql = mysql + " , no_of_child = " + txtCommonTextBox[conTxtNoOfChildren].Text;
					}
					else
					{
						mysql = mysql + " , no_of_child = NULL ";
					}

					if (Information.IsNumeric(txtCommonTextBox[conTxtZipCode].Text))
					{
						mysql = mysql + " , zip_cd = " + txtCommonTextBox[conTxtZipCode].Text;
					}
					else
					{
						mysql = mysql + " , zip_cd = NULL ";
					}
					mysql = mysql + " , area= N'" + txtCommonTextBox[conTxtArea].Text + "'";
					mysql = mysql + " , block = N'" + txtCommonTextBox[conTxtBlock].Text + "'";
					mysql = mysql + " , street = N'" + txtCommonTextBox[conTxtStreet].Text + "'";
					mysql = mysql + " , lane = N'" + txtCommonTextBox[conTxtLane].Text + "'";
					mysql = mysql + " , type_of_building = N'" + txtCommonTextBox[conTxtTypeofBldg].Text + "'";
					mysql = mysql + " , building_no = N'" + txtCommonTextBox[conTxtBldgNo].Text + "'";
					mysql = mysql + " , qasima = N'" + txtCommonTextBox[conTxtQasima].Text + "'";
					mysql = mysql + " , floor = N'" + txtCommonTextBox[conTxtFloor].Text + "'";
					mysql = mysql + " , flat_no = N'" + txtCommonTextBox[conTxtFlatNo].Text + "'";
					mysql = mysql + " , po_box = N'" + txtCommonTextBox[conTxtPOBox].Text + "'";
					mysql = mysql + " , comments = N'" + txtCommonTextBox[conTxtComments].Text + "'";

					mysql = mysql + " , phone = '" + txtCommonTextBox[conTxtTelephoneNo1].Text + "'";
					mysql = mysql + " , fax = '" + txtCommonTextBox[conTxtFax].Text + "'";
					mysql = mysql + " , email = '" + txtCommonTextBox[conTxtEmailAddress].Text + "'";
					mysql = mysql + " , mobile = '" + txtCommonTextBox[conTxtMobileno].Text + "'";
					mysql = mysql + " , permanent_addr_1 = N'" + txtCommonTextBox[conTxtAddress1].Text + "'";
					mysql = mysql + " , permanent_addr_2 = N'" + txtCommonTextBox[conTxtAddress2].Text + "'";
					mysql = mysql + " , permanent_addr_3 = N'" + txtCommonTextBox[conTxtAddress3].Text + "'";
					mysql = mysql + " , permanent_addr_4 = N'" + txtCommonTextBox[conTxtAddress4].Text + "'";
					mysql = mysql + " , permanent_phone = N'" + txtCommonTextBox[conTxtTelephoneNo2].Text + "'";
					mysql = mysql + " , civil_id = '" + txtCommonTextBox[conTxtCivilId].Text + "'";
					mysql = mysql + " , passport_no = '" + txtCommonTextBox[conTxtPassportNo].Text + "'";
					mysql = mysql + " , work_permit_no = '" + txtCommonTextBox[conTxtWorkPermitNo].Text + "'";
					//mySql = mySql & " , visa_type = N'" & txtCommonTextBox(conTxtVisaType).Text & "'"
					mysql = mysql + " , visa_no = N'" + txtCommonTextBox[conTxtVisaNo].Text + "'";
					mysql = mysql + " , pager = N'" + txtCommonTextBox[conTxtPagerNo].Text + "'";
					mysql = mysql + " , entrance = N'" + txtCommonTextBox[conTxtEntrance].Text + "'";
					mysql = mysql + " , comment1 = N'" + txtCommonTextBox[conTxtComments1].Text + "'";
					mysql = mysql + " , comment2 = N'" + txtCommonTextBox[conTxtComments2].Text + "'";
					mysql = mysql + " , comment3 = N'" + txtCommonTextBox[conTxtComments3].Text + "'";
					//added by burhan
					mysql = mysql + " , probation_days =" + Conversion.Val(txtCommonTextBox[conTxtProbationDays].Text).ToString();
					//end
					//'Added By yusuf Date:30-Oct-2008
					mysql = mysql + " , ticket =" + ((int) chkAllowTicket.CheckState).ToString();
					if (Information.IsNumeric(txtCommonTextBox[conTxtTicketType].Text))
					{
						mysql = mysql + " , ticket_type =" + mTicketType.ToString();
					}
					else
					{
						mysql = mysql + " , ticket_type = Null";
					}
					if (Information.IsNumeric(txtCommonTextBox[conTxtTicketDestination].Text))
					{
						mysql = mysql + " , ticket_destination=" + mTicketDestination.ToString();
					}
					else
					{
						mysql = mysql + " , ticket_destination = Null";
					}
					if (chkAllowTicket.CheckState != CheckState.Unchecked)
					{
						mysql = mysql + " , ticket_start_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtTicketAccrualStartDate.Value) + "'";
					}
					else
					{
						mysql = mysql + " , ticket_start_date = Null";
					}
					if (Information.IsDate(txtContractStratDate.Value))
					{
						mysql = mysql + " , contract_start_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtContractStratDate.Value) + "'";
					}
					else
					{
						mysql = mysql + " , contract_start_date = Null";
					}
					if (Information.IsDate(txtContractEndDate.Value))
					{
						mysql = mysql + " , contract_end_date = ' " + ReflectionHelper.GetPrimitiveValue<string>(txtContractEndDate.Value) + "'";
					}
					else
					{
						mysql = mysql + " , contract_end_date = Null";
					}
					mysql = mysql + " , contract_period = " + ReflectionHelper.GetPrimitiveValue<string>(txtContractPeriod.Value);
					//'End
					mysql = mysql + " , deduction_hrs = " + txtDeductionHrs.Text;
					if (mDefaultProjectCd == 0)
					{
						mysql = mysql + " , Default_Project = null ";
					}
					else
					{
						mysql = mysql + " , Default_Project = " + mDefaultProjectCd.ToString();
					}
					if (!SystemProcedure2.IsItEmpty(txtLoginID.Text, SystemVariables.DataType.StringType))
					{
						mysql = mysql + " , login_id = '" + txtLoginID.Text + "'";
					}
					else
					{
						mysql = mysql + " , login_id = NULL ";
					}
					mysql = mysql + " , notice_period =" + ReflectionHelper.GetPrimitiveValue<string>(txtNoticePeriod.Value);
					mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " , qualf_description = N'" + txtCommonTextBox[conTxtQualfDesc].Text + "'";
					mysql = mysql + " , professional_qualf = N'" + txtCommonTextBox[conTxtProfessionalDesc].Text + "'";
					mysql = mysql + " , year_of_Graduation = " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtYearOfPassing].Text, SystemVariables.DataType.NumberType)) ? "NULL" : txtCommonTextBox[conTxtYearOfPassing].Text);
					mysql = mysql + " , Relevant_experience = " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtReliventExp].Text, SystemVariables.DataType.NumberType)) ? "NULL" : txtCommonTextBox[conTxtReliventExp].Text);
					mysql = mysql + " , Irrelevant_experience = " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtIrreliventExp].Text, SystemVariables.DataType.NumberType)) ? "NULL" : txtCommonTextBox[conTxtIrreliventExp].Text);
					mysql = mysql + " , Analysis1 = " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtAnalysis1].Text, SystemVariables.DataType.StringType)) ? "NULL" : "'" + txtCommonTextBox[conTxtAnalysis1].Text + "'");
					mysql = mysql + " , Analysis2 = " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtAnalysis2].Text, SystemVariables.DataType.StringType)) ? "NULL" : "'" + txtCommonTextBox[conTxtAnalysis2].Text + "'");
					mysql = mysql + " , Analysis3 = " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtAnalysis3].Text, SystemVariables.DataType.StringType)) ? "NULL" : "'" + txtCommonTextBox[conTxtAnalysis3].Text + "'");
					mysql = mysql + " , Analysis4 = " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtAnalysis4].Text, SystemVariables.DataType.StringType)) ? "NULL" : "'" + txtCommonTextBox[conTxtAnalysis4].Text + "'");
					mysql = mysql + " , Analysis5 = " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtAnalysis5].Text, SystemVariables.DataType.StringType)) ? "NULL" : "'" + txtCommonTextBox[conTxtAnalysis5].Text + "'");
					mysql = mysql + " , location_cd = " + ((mLocationCd == 0) ? "Null" : mLocationCd.ToString());
					// mySql = mySql & " , hold_salary = " & chkHoldSalary.Value
					mysql = mysql + " , user_date_time = '" + DateTimeHelper.ToString(DateTime.Today) + "'";
					mysql = mysql + " where emp_cd = " + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_7 = null;
					TempCommand_7 = SystemVariables.gConn.CreateCommand();
					TempCommand_7.CommandText = mysql;
					TempCommand_7.ExecuteNonQuery();

					mysql = "update pp";
					mysql = mysql + " set pp.sponsor_cd = pemp.sponsor_cd ";
					mysql = mysql + " ,pp.project_cd = pemp.default_project ";
					mysql = mysql + " ,pp.dept_cd = pemp.dept_cd ";
					mysql = mysql + " ,pp.desg_cd = pemp.desg_cd ";
					mysql = mysql + " from pay_employee pemp ";
					mysql = mysql + " inner join pay_payroll pp on pp.emp_cd = pemp.emp_cd ";
					mysql = mysql + " where pp.pay_date = '" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
					SqlCommand TempCommand_8 = null;
					TempCommand_8 = SystemVariables.gConn.CreateCommand();
					TempCommand_8.CommandText = mysql;
					TempCommand_8.ExecuteNonQuery();
					mysql = "update pp";
					mysql = mysql + " set pp.dept_cd = pemp.dept_cd";
					mysql = mysql + " , pp.desg_cd = pemp.desg_cd";
					mysql = mysql + " from pay_employee pemp ";
					mysql = mysql + " inner join pay_payroll_master pp on pp.emp_cd = pemp.emp_cd ";
					mysql = mysql + " where pp.pay_date = '" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
					SqlCommand TempCommand_9 = null;
					TempCommand_9 = SystemVariables.gConn.CreateCommand();
					TempCommand_9.CommandText = mysql;
					TempCommand_9.ExecuteNonQuery();
				}

				//'Added By Yusuf For Alarm As On 05-Oct-2008
				int mProbDays = 0;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(txtProbationEndDate.Value))
				{
					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mProbDays = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Probation_period_days"));
					SystemProcedure.InsertAlarmDetails(7, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), txtCommonTextBox[conTxtComments].Text, DateTimeHelper.ToString(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtProbationEndDate.Value).AddDays(-mProbDays)));
				}
				//'End
				UpdateGLSegment();
				CheckDateOfJoining(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtJoiningDate.Value));
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				FirstFocusObject.Focus();
				return result;

				errorexit:
				return false;
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}
			return result;
		}

		public bool deleteRecord()
		{

			//'If an error occurs, trap the error and dispaly a valid message
			//gConn.BeginTrans
			//mysql = "delete from pay_employee  where emp_cd=" & Str(mSearchValue)
			//gConn.Execute mysql
			//
			//gConn.CommitTrans
			//deleteRecord = True

			//Check employee payroll generated for one month.
			bool result = false;
			string mysql = " select last_salary_date from pay_employee ";
			mysql = mysql + " where emp_cd = " + Conversion.Str(mSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				if (Information.IsDate(ReflectionHelper.GetPrimitiveValue<System.DateTime>(mReturnValue)))
				{
					MessageBox.Show("Employee last month payroll is genereated you cann't delete this record!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return result;
				}
			}
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemVariables.gConn.BeginTransaction();

				mysql = " delete from pay_ta_trans_detail";
				mysql = mysql + " from pay_ta_trans_detail pttd";
				mysql = mysql + " inner join pay_ta_trans ptt on ptt.entry_id = pttd.entry_id";
				mysql = mysql + " where ptt.emp_cd = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mysql = " delete from pay_ta_trans";
				mysql = mysql + " where emp_cd = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				mysql = " delete from pay_payroll_master";
				mysql = mysql + " where emp_cd = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				mysql = " delete from pay_payroll";
				mysql = mysql + " where emp_cd = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();

				mysql = " delete from Pay_Document_Transaction";
				mysql = mysql + " where emp_cd = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_5 = null;
				TempCommand_5 = SystemVariables.gConn.CreateCommand();
				TempCommand_5.CommandText = mysql;
				TempCommand_5.ExecuteNonQuery();

				mysql = " delete from pay_document_detail";
				mysql = mysql + " where emp_cd = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_6 = null;
				TempCommand_6 = SystemVariables.gConn.CreateCommand();
				TempCommand_6.CommandText = mysql;
				TempCommand_6.ExecuteNonQuery();

				mysql = " delete from pay_employee_billing_details";
				mysql = mysql + " where emp_cd = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_7 = null;
				TempCommand_7 = SystemVariables.gConn.CreateCommand();
				TempCommand_7.CommandText = mysql;
				TempCommand_7.ExecuteNonQuery();

				mysql = "delete from pay_employee_leave_details";
				mysql = mysql + " where emp_cd = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_8 = null;
				TempCommand_8 = SystemVariables.gConn.CreateCommand();
				TempCommand_8.CommandText = mysql;
				TempCommand_8.ExecuteNonQuery();

				mysql = " delete from Pay_Employee_GL_Details";
				mysql = mysql + " where emp_cd = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_9 = null;
				TempCommand_9 = SystemVariables.gConn.CreateCommand();
				TempCommand_9.CommandText = mysql;
				TempCommand_9.ExecuteNonQuery();

				mysql = " delete from pay_employee";
				mysql = mysql + " where emp_cd = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_10 = null;
				TempCommand_10 = SystemVariables.gConn.CreateCommand();
				TempCommand_10.CommandText = mysql;
				TempCommand_10.ExecuteNonQuery();


				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Employee cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				return true;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					AddRecord();
					result = false;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			//On Error GoTo eFoundError
			object mReturnValue = null;

			string mysql = " select * from pay_employee where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

			SqlDataReader localRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand.ExecuteReader();
			if (localRec.Read())
			{
				//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(SearchValue);
				mTimeStamp = Convert.ToString(localRec["time_stamp"]);
				mRecordNavigateSearchValue = Convert.ToInt32(localRec["emp_cd"]);

				mysql = " select pay_dept.dept_no , pay_dept.l_dept_name, pay_dept.a_dept_name";
				mysql = mysql + " , pay_desg.desg_no, pay_desg.l_desg_name , pay_desg.a_desg_name ";
				mysql = mysql + " , pay_grade.grade_no , pay_grade.l_grade_name ";
				mysql = mysql + " , pay_grade.a_grade_name , pay_nat.nat_no , pay_nat.l_nat_name ";
				mysql = mysql + " , pay_nat.a_nat_name, pay_qalfn.qalfn_no ";
				mysql = mysql + " , pay_qalfn.l_qalfn_name , pay_qalfn.a_qalfn_name ";
				mysql = mysql + " , pay_religion.religion_no , pay_religion.l_religion_name ";
				mysql = mysql + " , pay_religion.a_religion_name , pay_manager.emp_no ";


				mysql = mysql + " , pay_manager.l_first_name + ' ' + pay_manager.l_second_name + ' ' + pay_manager.l_third_name + ' ' + pay_manager.l_fourth_name ";
				mysql = mysql + " , pay_manager.a_first_name + ' ' + pay_manager.a_second_name + ' ' + pay_manager.a_third_name + ' ' + pay_manager.a_fourth_name ";
				mysql = mysql + " , emp_status.l_status_name , emp_status.a_status_name ";
				mysql = mysql + " , pay_comp.comp_no , pay_comp.l_comp_name , pay_comp.a_comp_name, pay_Sponsor.Sponsor_No ";

				mysql = mysql + " , pay_Sponsor.l_first_name + ' ' + pay_Sponsor.l_second_name + ' ' + pay_Sponsor.l_third_name + ' ' + pay_Sponsor.l_fourth_name ";
				mysql = mysql + " , pay_Sponsor.a_first_name + ' ' + pay_Sponsor.a_second_name + ' ' + pay_Sponsor.a_third_name + ' ' + pay_Sponsor.a_fourth_name ";

				mysql = mysql + " , pay_VisaT.L_Visa_Type_no , pay_VisaT.l_Visa_Type_name ,  pay_VisaT.A_Visa_Type_name ";
				mysql = mysql + " , gp.project_no , gp.l_project_name, gp.a_project_name";
				mysql = mysql + " , pel.location_no , pel.l_location , pel.a_LOCATION";
				mysql = mysql + " , phc.head_count_no";

				mysql = mysql + " from pay_employee pay_emp ";
				mysql = mysql + " inner join pay_department pay_dept on pay_emp.dept_cd = pay_dept.dept_cd ";
				mysql = mysql + " inner join pay_designation pay_desg on pay_emp.desg_cd = pay_desg.desg_cd ";
				mysql = mysql + " left join pay_grade on pay_emp.grade_cd = pay_grade.grade_cd";
				mysql = mysql + " left join pay_nationality pay_nat on pay_emp.nat_cd = pay_nat.nat_cd ";
				mysql = mysql + " left join pay_company pay_comp on pay_emp.comp_cd = pay_comp.comp_cd ";
				mysql = mysql + " left join pay_employee_status emp_status on pay_emp.status_cd = emp_status.status_cd ";
				mysql = mysql + " left outer join pay_employee pay_manager on pay_emp.manager_cd = pay_manager.emp_cd ";
				mysql = mysql + " left outer join pay_religion on pay_emp.religion_cd = pay_religion.religion_cd ";
				mysql = mysql + " left outer join pay_qualification pay_qalfn on pay_emp.qalfn_cd = pay_qalfn.qalfn_cd";
				mysql = mysql + " left outer join pay_Visa_Type pay_VisaT on pay_emp.Visa_Type = pay_VisaT.Visa_Type_Cd";
				mysql = mysql + " left outer join pay_Sponsor  on pay_emp.Sponsor_Cd = pay_Sponsor.Sponsor_Cd";
				mysql = mysql + " left outer join gl_projects gp on pay_emp.default_project = gp.project_cd ";
				mysql = mysql + " left outer join pay_emp_location pel on pel.location_cd = pay_emp.location_cd";
				mysql = mysql + " left outer join pay_head_count phc on phc.head_count_cd = pay_emp.head_count_cd";
				mysql = mysql + " where pay_emp.emp_cd= " + Convert.ToString(localRec["emp_cd"]);

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//''Department
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[conTxtDeptCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					txtDisplayLabel[conDlblDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(1) : ((Array) mReturnValue).GetValue(2));

					//''Designation
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[conTxtDesignationCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3));
					txtDisplayLabel[conDlblDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(4) : ((Array) mReturnValue).GetValue(5));

					//''Grade
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[conTxtGradeCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(6));
					txtDisplayLabel[conDlblGradeName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(7) : ((Array) mReturnValue).GetValue(8));

					//''Nationality
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[conTxtNatCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(9));
					txtDisplayLabel[conDlblNatName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(10) : ((Array) mReturnValue).GetValue(11));

					//''Qualification
					txtCommonTextBox[conTxtQualificationCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(12)) + "";
					txtDisplayLabel[conDlblQualificationName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(13) : ((Array) mReturnValue).GetValue(14)) + "";

					//''Religion
					txtCommonTextBox[conTxtReligionCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(15)) + "";
					txtDisplayLabel[conDlblReligionName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(16) : ((Array) mReturnValue).GetValue(17)) + "";

					//''Manager
					txtCommonTextBox[conTxtManagerCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(18)) + "";
					txtDisplayLabel[conDlblManagerName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(19) : ((Array) mReturnValue).GetValue(20)) + "";

					//''Status
					txtDisplayLabel[conDlblStatus].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(21) : ((Array) mReturnValue).GetValue(22)) + "";

					//''Company
					txtCommonTextBox[conTxtCompanyCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(23)) + "";
					txtDisplayLabel[conDlblCompName].Text = (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(24)) + "" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(25)) + "";

					//New fields added by Burhan on Fri, 08-June-2007
					//'Sponsor
					txtCommonTextBox[conTxtSponsorCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(26)) + "";
					txtDisplayLabel[conDlblSponsorName].Text = (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(27)) + "" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(28)) + "";
					//' Visa Type
					txtCommonTextBox[conTxtVisaType].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(29)) + "";
					txtDisplayLabel[conDlblVisaTypeName].Text = (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(30)) + "" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(31)) + "";

					//''Added By yusuf For Default Project
					txtDefaultProject.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(32)) + "";
					txtDlblDefaultProject.Text = (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(33)) + "" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(34)) + "";
					//'End

					//''Added By yusuf For Location
					txtCommonTextBox[conTxtLocation].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(35)) + "";
					txtDisplayLabel[conDlblLocation].Text = (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(36)) + "" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(37)) + "";
					//'End

					//''Added By yusuf For Location
					txtCommonTextBox[conTxtBudgetHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(38)) + "";
					txtDisplayLabel[conDlblHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(38)) + "";
					//'End
				}
				if (Convert.IsDBNull(localRec["termination_Date"]))
				{
					txtDSeveranceDate.Text = "";
				}
				else
				{
					txtDSeveranceDate.Value = localRec["termination_Date"];
				}
				txtCommonTextBox[conTxtArea].Text = Convert.ToString(localRec["Area"]) + "";
				txtCommonTextBox[conTxtEmpCode].Text = Convert.ToString(localRec["emp_no"]);
				txtCommonTextBox[conTxtLFirstName].Text = Convert.ToString(localRec["l_first_name"]);
				txtCommonTextBox[conTxtLSecondName].Text = Convert.ToString(localRec["l_second_name"]) + "";
				txtCommonTextBox[conTxtLThirdName].Text = Convert.ToString(localRec["l_third_name"]) + "";
				txtCommonTextBox[conTxtLFourthName].Text = Convert.ToString(localRec["l_fourth_name"]) + "";
				txtCommonTextBox[conTxtLFifthName].Text = Convert.ToString(localRec["l_fifth_name"]) + "";
				txtCommonTextBox[conTxtAFirstName].Text = Convert.ToString(localRec["a_first_name"]) + "";
				txtCommonTextBox[conTxtASecondName].Text = Convert.ToString(localRec["a_second_name"]) + "";
				txtCommonTextBox[conTxtAThirdName].Text = Convert.ToString(localRec["a_third_name"]) + "";
				txtCommonTextBox[conTxtAFourthName].Text = Convert.ToString(localRec["a_fourth_name"]) + "";
				txtCommonTextBox[conTxtAFifthName].Text = Convert.ToString(localRec["a_fifth_name"]) + "";
				//'' Added By Burhan Ghee Date: 25-Aug-2007
				txtCommonTextBox[conTxtComments1].Text = Convert.ToString(localRec["comment1"]) + "";
				txtCommonTextBox[conTxtComments2].Text = Convert.ToString(localRec["comment2"]) + "";
				txtCommonTextBox[conTxtComments3].Text = Convert.ToString(localRec["comment3"]) + "";
				//''End Add

				//'' Added By Burhan Ghee Date: 30-Jul-2007
				txtCommonTextBox[conTxtVisaNo].Text = Convert.ToString(localRec["visa_no"]) + "";
				txtCommonTextBox[conTxtEntrance].Text = Convert.ToString(localRec["entrance"]) + "";

				//''added By yusuf as on 17-mar-2010
				txtLoginID.Text = Convert.ToString(localRec["Login_Id"]) + "";

				//added by burhan
				txtCommonTextBox[conTxtProbationDays].Text = Convert.ToString(localRec["probation_days"]);
				//end
				//Added  by Burhan Ghee, Date: 11-Jun-2007
				//Set Employee Picture
				SetPicture((Convert.IsDBNull(localRec["Emp_Picture_Path"])) ? "" : Convert.ToString(localRec["Emp_Picture_Path"]));


				//''Added by Burhan Ghee, Date : 22-Jul-2007
				if (!Convert.IsDBNull(localRec["probation_end_date"]))
				{
					txtProbationEndDate.Value = localRec["probation_end_date"];
				}
				else
				{
					txtProbationEndDate.Text = "";
				}
				//''End

				//''Added by Yusuf Date: 30-Oct-2008
				if (Convert.ToBoolean(localRec["Ticket"]))
				{
					chkAllowTicket.CheckState = CheckState.Checked;
					txtCommonTextBox[conTxtTicketType].Text = Convert.ToString(localRec["ticket_type"]);
					txtCommonTextBox_Leave(txtCommonTextBox[conTxtTicketType], new EventArgs());
					txtCommonTextBox[conTxtTicketDestination].Text = Convert.ToString(localRec["ticket_destination"]);
					txtCommonTextBox_Leave(txtCommonTextBox[conTxtTicketDestination], new EventArgs());
					txtTicketAccrualStartDate.Value = localRec["ticket_start_date"];
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select  dbo.payTicketBalance(" + Convert.ToString(localRec["emp_cd"]) + ",'" + DateTime.Today.ToString("dd/MMMM/yyyy") + "',1)"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					txtDisplayLabel[conDlblTicketBalance].Text = (Convert.IsDBNull(mReturnValue)) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
				else
				{
					chkAllowTicket.CheckState = CheckState.Unchecked;
					txtCommonTextBox[conTxtTicketType].Text = "";
					txtDisplayLabel[conDlblTicketTypeName].Text = "";
					txtCommonTextBox[conTxtTicketDestination].Text = "";
					txtDisplayLabel[conDlblTicketDestinationName].Text = "";
					txtDisplayLabel[conDlblTicketBalance].Text = "";
				}
				//''End
				if (!Convert.IsDBNull(localRec["date_of_birth"]))
				{
					txtBirthDate.Value = localRec["date_of_birth"];
					txtDisplayLabel[conDlblAge].Text = (DateTime.Today.Year - ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtBirthDate.DisplayText).Year).ToString();
				}
				else
				{
					txtBirthDate.Text = "";
					txtDisplayLabel[conDlblAge].Text = "";
				}

				if (!Convert.IsDBNull(localRec["date_of_joining"]))
				{
					txtJoiningDate.Value = localRec["date_of_joining"];
				}
				else
				{
					txtJoiningDate.Text = "";
				}
				if (!Convert.IsDBNull(localRec["contract_start_date"]))
				{
					txtContractStratDate.Value = localRec["contract_start_date"];
				}
				else
				{
					txtContractStratDate.Text = "";
				}
				if (!Convert.IsDBNull(localRec["contract_end_date"]))
				{
					txtContractEndDate.Value = localRec["contract_end_date"];
				}
				else
				{
					txtContractEndDate.Text = "";
				}
				txtContractPeriod.Value = (Convert.IsDBNull(localRec["contract_period"])) ? ((object) 0) : localRec["contract_period"];
				txtCommonTextBox[conTxtLFatherName].Text = Convert.ToString(localRec["l_father_name"]) + "";
				txtCommonTextBox[conTxtAFatherName].Text = Convert.ToString(localRec["a_father_name"]) + "";
				txtCommonTextBox[conTxtLMotherName].Text = Convert.ToString(localRec["l_mother_name"]) + "";
				txtCommonTextBox[conTxtAMotherName].Text = Convert.ToString(localRec["a_mother_name"]) + "";
				txtCommonTextBox[conTxtPlaceOfBirth].Text = Convert.ToString(localRec["place_of_birth"]) + "";
				txtCommonTextBox[conTxtBloodGroup].Text = Convert.ToString(localRec["blood_group"]) + "";

				if (!Convert.IsDBNull(localRec["no_of_wives"]))
				{
					txtCommonTextBox[conTxtNoOfWives].Text = Convert.ToString(localRec["no_of_wives"]);
				}
				else
				{
					txtCommonTextBox[conTxtNoOfWives].Text = "";
				}

				if (!Convert.IsDBNull(localRec["no_of_child"]))
				{
					txtCommonTextBox[conTxtNoOfChildren].Text = Convert.ToString(localRec["no_of_child"]);
				}
				else
				{
					txtCommonTextBox[conTxtNoOfChildren].Text = "";
				}

				if (!Convert.IsDBNull(localRec["zip_cd"]))
				{
					txtCommonTextBox[conTxtZipCode].Text = Convert.ToString(localRec["zip_cd"]);
				}
				else
				{
					txtCommonTextBox[conTxtZipCode].Text = "";
				}

				SystemCombo.SearchCombo(cmbCommon[conCmbSex], Convert.ToInt32(localRec["sex_id"]));
				SystemCombo.SearchCombo(cmbCommon[conCmbMaritalStatus], Convert.ToInt32(localRec["marital_status_id"]));
				SystemCombo.SearchCombo(cmbCommon[conCmbEmpType], Convert.ToInt32(localRec["emp_type_id"]));
				SystemCombo.SearchCombo(cmbCommon[conCmbTitle], (Convert.IsDBNull(localRec["title_id"])) ? 0 : Convert.ToInt32(localRec["title_id"]));

				txtCommonTextBox[conTxtBlock].Text = Convert.ToString(localRec["block"]) + "";
				txtCommonTextBox[conTxtStreet].Text = Convert.ToString(localRec["street"]) + "";
				txtCommonTextBox[conTxtLane].Text = Convert.ToString(localRec["lane"]) + "";
				txtCommonTextBox[conTxtTypeofBldg].Text = Convert.ToString(localRec["type_of_building"]) + "";
				txtCommonTextBox[conTxtBldgNo].Text = Convert.ToString(localRec["building_no"]) + "";
				txtCommonTextBox[conTxtQasima].Text = Convert.ToString(localRec["qasima"]) + "";
				txtCommonTextBox[conTxtFloor].Text = Convert.ToString(localRec["floor"]) + "";
				txtCommonTextBox[conTxtFlatNo].Text = Convert.ToString(localRec["flat_no"]) + "";
				txtCommonTextBox[conTxtPOBox].Text = Convert.ToString(localRec["po_box"]) + "";
				txtCommonTextBox[conTxtTelephoneNo1].Text = Convert.ToString(localRec["phone"]) + "";
				txtCommonTextBox[conTxtFax].Text = Convert.ToString(localRec["fax"]) + "";
				txtCommonTextBox[conTxtEmailAddress].Text = Convert.ToString(localRec["email"]) + "";
				txtCommonTextBox[conTxtPagerNo].Text = Convert.ToString(localRec["pager"]) + "";
				txtCommonTextBox[conTxtMobileno].Text = Convert.ToString(localRec["mobile"]) + "";
				txtCommonTextBox[conTxtAddress1].Text = Convert.ToString(localRec["permanent_addr_1"]) + "";
				txtCommonTextBox[conTxtAddress2].Text = Convert.ToString(localRec["permanent_addr_2"]) + "";
				txtCommonTextBox[conTxtAddress3].Text = Convert.ToString(localRec["permanent_addr_3"]) + "";
				txtCommonTextBox[conTxtAddress4].Text = Convert.ToString(localRec["permanent_addr_4"]) + "";
				txtCommonTextBox[conTxtTelephoneNo2].Text = Convert.ToString(localRec["permanent_phone"]) + "";
				txtCommonTextBox[conTxtComments].Text = Convert.ToString(localRec["Comments"]) + "";

				txtCommonTextBox[conTxtCivilId].Text = Convert.ToString(localRec["civil_id"]) + "";
				txtCommonTextBox[conTxtPassportNo].Text = Convert.ToString(localRec["passport_no"]) + "";
				txtCommonTextBox[conTxtWorkPermitNo].Text = Convert.ToString(localRec["work_permit_no"]) + "";
				txtCommonTextBox[conTxtQualfDesc].Text = Convert.ToString(localRec["qualf_description"]) + "";
				txtCommonTextBox[conTxtProfessionalDesc].Text = Convert.ToString(localRec["professional_qualf"]) + "";
				txtCommonTextBox[conTxtYearOfPassing].Text = (Convert.IsDBNull(localRec["year_of_Graduation"])) ? "0" : txtCommonTextBox[conTxtYearOfPassing].Text;
				txtCommonTextBox[conTxtReliventExp].Text = (Convert.IsDBNull(localRec["Relevant_experience"])) ? "0" : txtCommonTextBox[conTxtReliventExp].Text;
				txtCommonTextBox[conTxtIrreliventExp].Text = (Convert.IsDBNull(localRec["Irrelevant_experience"])) ? "0" : txtCommonTextBox[conTxtIrreliventExp].Text;
				txtCommonTextBox[conTxtAnalysis1].Text = Convert.ToString(localRec["Analysis1"]) + "";
				txtCommonTextBox[conTxtAnalysis2].Text = Convert.ToString(localRec["Analysis2"]) + "";
				txtCommonTextBox[conTxtAnalysis3].Text = Convert.ToString(localRec["Analysis3"]) + "";
				txtCommonTextBox[conTxtAnalysis4].Text = Convert.ToString(localRec["Analysis4"]) + "";
				txtCommonTextBox[conTxtAnalysis5].Text = Convert.ToString(localRec["Analysis5"]) + "";
				//''Added By Yusuf For Display Deduction Hours
				txtDeductionHrs.Value = localRec["deduction_hrs"];
				txtNoticePeriod.Value = localRec["Notice_Period"];
				// chkHoldSalary.Value = IIf(.Fields("hold_salary").Value, 1, 0)
				//''End
				//Change the form mode to edit
				txtCommonTextBox[conTxtGradeCode].Enabled = Convert.IsDBNull(localRec["Last_Salary_Date"]);

				if (Convert.ToDouble(localRec["Emp_type_id"]) == 148)
				{
					txtContractStratDate.Enabled = true;
					txtContractEndDate.Enabled = true;
					txtContractPeriod.Enabled = true;
				}
				mDateOFJoinGlobal = Convert.ToString(localRec["date_of_joining"]);
				txtCommonTextBox[conTxtBudgetHeadCount].Enabled = false;
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			}
			localRec.Close();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		private void UpdateGLSegment()
		{

		}

		public void PrintReport()
		{

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool CheckDataValidity()
		{
			//Check validation during update and add of records
			string mysql = "";
			object mReturnValue = null;

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Employee Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtEmpCode].Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtLFirstName].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Employee Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtLFirstName].Focus();
				return false;
			}

			if (!Information.IsNumeric(txtCommonTextBox[conTxtDeptCode].Text))
			{
				MessageBox.Show("Enter the Department Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabEmployee.SelectedItem = conTabPersonnelBasic;
				txtCommonTextBox[conTxtDeptCode].Focus();
				return false;
			}

			if (!Information.IsNumeric(txtCommonTextBox[conTxtDesignationCode].Text))
			{
				MessageBox.Show("Enter the Designation Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabEmployee.SelectedItem = conTabPersonnelBasic;
				txtCommonTextBox[conTxtDeptCode].Focus();
				return false;
			}

			if (!Information.IsNumeric(txtCommonTextBox[conTxtCompanyCode].Text))
			{
				MessageBox.Show("Enter the Company Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabEmployee.SelectedItem = conTabPersonnelBasic;
				txtCommonTextBox[conTxtCompanyCode].Focus();
				return false;
			}

			if (!Information.IsNumeric(txtCommonTextBox[conTxtGradeCode].Text))
			{
				MessageBox.Show("Enter the Grade Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabEmployee.SelectedItem = conTabPersonnelBasic;
				txtCommonTextBox[conTxtGradeCode].Focus();
				return false;
			}

			if (!Information.IsDate(txtJoiningDate.Value))
			{
				MessageBox.Show("Enter the Joining Date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabEmployee.SelectedItem = conTabPersonnelBasic;
				txtJoiningDate.Focus();
				return false;
			}
			else
			{
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					mysql = " select date_of_joining,last_salary_date from pay_employee where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue).GetValue(0)) != ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtJoiningDate.Value))
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(1)))
							{
								MessageBox.Show("Joining date cannot be changed", "Enployee Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
								tabEmployee.SelectedItem = conTabPersonnelBasic;
								txtJoiningDate.Focus();
								return false;
							}
						}
					}
				}
			}

			if (!Information.IsNumeric(txtCommonTextBox[conTxtNatCode].Text))
			{
				MessageBox.Show("Enter the Nationality Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabEmployee.SelectedItem = conTabPersonnelBasic;
				txtCommonTextBox[conTxtNatCode].Focus();
				return false;
			}

			if (chkAllowTicket.CheckState == CheckState.Checked)
			{
				if (!Information.IsNumeric(txtCommonTextBox[conTxtTicketType].Text) || !Information.IsNumeric(txtCommonTextBox[conTxtTicketDestination].Text) || ReflectionHelper.IsLessThan(txtTicketAccrualStartDate.Value, txtJoiningDate.Value))
				{
					MessageBox.Show("Information missing for Air Ticket, Please enter all related details.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					tabEmployee.SelectedItem = conTabPersonnelOthersDetails;
					txtCommonTextBox[conTxtTicketType].Focus();
					return false;
				}
			}

			if (cmbCommon[conCmbEmpType].GetItemData(cmbCommon[conCmbEmpType].ListIndex) == 148)
			{
				if (!Information.IsDate(txtContractStratDate.Value))
				{
					MessageBox.Show("Enter the Contract Date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					tabEmployee.SelectedItem = conTabPersonnelBasic;
					txtContractStratDate.Focus();
					return false;
				}
			}
			return true;
		}

		private bool CheckDateOfJoining(System.DateTime pDateOfJoin)
		{
			bool result = false;
			try
			{
				string mysql = "";
				object mReturnValue = null;
				string mGenerateDate = "";
				string mEmpNo = "";
				if (!SystemProcedure2.IsItEmpty(mDateOFJoinGlobal))
				{
					if (DateTime.Parse(mDateOFJoinGlobal) != ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtJoiningDate.Value))
					{
						if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
						{
							if (pDateOfJoin > DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()))
							{
								MessageBox.Show("Payroll and Time &  Attendance will be clear for this month!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								SystemHRProcedure.ClearTimeAttendanceCurrentMonthTransaction(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));
								SystemHRProcedure.ClearPayroll(mGenerateDate, mEmpNo, mEmpNo);
							}
							else
							{
								MessageBox.Show("Payroll and Time & Attendance will be regenerated for this month!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								SystemHRProcedure.ClearTimeAttendanceCurrentMonthTransaction(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
								SystemHRProcedure.GenerateTimeAttendanceMonthlyTransaction(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
								SystemHRProcedure.UpdateVacationInTimeAttendance(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
								SystemHRProcedure.UpdateTimeAttendanceDayOff(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), ReflectionHelper.GetPrimitiveValue<int>(SearchValue));

								SystemHRProcedure.ClearPayroll(mGenerateDate, mEmpNo, mEmpNo);
								SystemHRProcedure.GeneratePayrollEntry(mGenerateDate, mEmpNo, mEmpNo);
								SystemHRProcedure.GenerateLeaveEntry(mGenerateDate, mEmpNo, mEmpNo);
								SystemHRProcedure.GenerateLoanEntry(mGenerateDate, mEmpNo, mEmpNo);
							}
						}
					}
				}
				return true;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
			}
			return result;
		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			if (this.Width * 15 > 220)
			{
				tabEmployee.Width = this.Width - 15;
			}

			if (this.Height * 15 > 3500)
			{
				tabEmployee.Height = this.Height - 233;
			}
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmPayEmployee.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void GetNextNumber()
		{
			txtCommonTextBox[conTxtEmpCode].Text = SystemProcedure2.GetNewNumber("pay_employee", "emp_no", 2);
			int mLen = 0;
			if (mNoOfEmployeeNo > 0)
			{
				mLen = Strings.Len(txtCommonTextBox[conTxtEmpCode].Text);
				while (mLen < mNoOfEmployeeNo)
				{
					txtCommonTextBox[conTxtEmpCode].Text = "0" + txtCommonTextBox[conTxtEmpCode].Text;
					mLen++;
				}
			}
			FirstFocusObject.Focus();
		}

		private void imgPicture_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			try
			{

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.InitDir was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				CommonDialog1Open.InitialDirectory = GetPhotoPath();
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				CommonDialog1Open.Filter = "BMP - JPG (*.bmp,*.jpg)|*.bmp; *.jpg";

				// Set the default files type to Word Documents
				//CommonDialog1.FilterIndex = 1


				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				CommonDialog1Open.FileName = "";
				CommonDialog1Open.ShowDialog();
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (CommonDialog1Open.FileName == "")
				{
					return;
				}
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileTitle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_WARNING: (2074) CommonDialog property CommonDialog1.FileTitle was upgraded to CommonDialog1.FileName which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
				SetPicture(Path.GetFileName(CommonDialog1Open.FileName));
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private string GetPhotoPath()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			string result = "";
			try
			{


				string TmpEmpPicture = new string(' ', 255);

				TmpEmpPicture = new string(' ', 255);
				string tempRefParam = "DatabaseInformation";
				string tempRefParam2 = "c:\\pictures\\";
				string tempRefParam3 = SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + "App.Config";
				InnovaUpdSupport.PInvoke.SafeNative.kernel32.GetPrivateProfileString(ref tempRefParam, "EmpPicturesPath", ref tempRefParam2, ref TmpEmpPicture, 255, ref tempRefParam3);
				result = TmpEmpPicture.Trim().Substring(0, Math.Min(Strings.Len(TmpEmpPicture.Trim()) - 1, TmpEmpPicture.Trim().Length));
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

			return result;
		}
		private object SetPicture(string Filename)
		{
			try
			{
				imgPicture.Tag = Filename;
				imgPicture.Image = Image.FromFile(GetPhotoPath() + Filename);
			}
			catch
			{
				imgPicture.Tag = "";
				imgPicture.Image = Image.FromFile("");

				//MsgBox "Invalid file selection !!", vbInformation
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis#1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return null;
		}

		private void imgPicture_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float x = eventArgs.X * 15;
			float y = eventArgs.Y * 15;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (ToolTipMain.GetToolTip(imgPicture) != "Double Click to Select Picture," + " Current Filename: " + GetPhotoPath() + Convert.ToString(imgPicture.Tag))
				{
					ToolTipMain.SetToolTip(imgPicture, "Double Click to Select Picture," + " Current Filename: " + GetPhotoPath() + Convert.ToString(imgPicture.Tag));
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}





		private void txtBirthDate_Change(Object Sender, EventArgs e)
		{
			if (Information.IsDate(txtBirthDate.DisplayText))
			{
				txtDisplayLabel[conDlblAge].Text = (DateTime.Today.Year - ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtBirthDate.DisplayText).Year).ToString();
			}
			else
			{
				txtDisplayLabel[conDlblAge].Text = "";
			}
		}

		private void txtCommonTextBox_Change(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			string mSQL = "";
			object mReturnValue = null;

			if (Index == conTxtProbationDays)
			{
				if (Information.IsDate(txtJoiningDate.Value))
				{
					txtProbationEndDate.Value = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtJoiningDate.Value).AddDays(Conversion.Val(txtCommonTextBox[conTxtProbationDays].Text));
				}
				//'''ElseIf Index = conTxtEmpCode Then
				//'''   If mCurrentFormMode = frmAddMode And Not IsItEmpty(txtCommonTextBox(conTxtEmpCode).Text, StringType) Then
				//'''      mSQL = " select emp_cd from pay_employee where emp_no = '" & txtCommonTextBox(conTxtEmpCode).Text & "'"
				//'''      mReturnValue = GetMasterCode(mSQL)
				//'''      If Not IsNull(mReturnValue) Then
				//'''         Call GetRecord(mReturnValue)
				//'''      End If
				//'''   End If
			}
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			if (Index == conTxtEmpCode)
			{
				GetNextNumber();
			}
			else
			{
				FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
			}
		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			try
			{
				object mTempValue = null;
				string mysql = "";
				int Cnt = 0;

				if (Index == conTxtCivilId && !SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtCivilId].Text, SystemVariables.DataType.StringType))
				{
					mysql = " select emp_no from pay_employee where civil_id = '" + txtCommonTextBox[conTxtCivilId].Text + "'";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempValue))
					{
						MessageBox.Show("Employee is Exists!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				if (Index == conTxtVisaType)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtVisaType].Text, SystemVariables.DataType.NumberType) || txtCommonTextBox[conTxtVisaType].Text == "0")
					{
						mysql = "select Visa_Type_cd ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Visa_Type_Name" : "A_Visa_Type_Name");
						mysql = mysql + " from pay_visa_Type ";
						mysql = mysql + " where ";
						mysql = mysql + " L_Visa_Type_no = " + txtCommonTextBox[conTxtVisaType].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblVisaTypeName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblVisaTypeName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						}
					}
					else
					{
						txtDisplayLabel[conDlblVisaTypeName].Text = "";
					}
				}


				if (Index == conTxtSponsorCode)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtSponsorCode].Text, SystemVariables.DataType.NumberType) || txtCommonTextBox[conTxtSponsorCode].Text == "0")
					{
						mysql = "select Sponsor_cd ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_First_name + ' ' +  L_Second_Name + ' ' + L_Third_Name + ' ' + L_Fourth_Name " : "A_First_name + ' ' +  A_Second_Name + ' ' + A_Third_Name + ' ' + A_Fourth_Name");
						mysql = mysql + " from pay_sponsor ";
						mysql = mysql + " where ";
						mysql = mysql + " sponsor_no = " + txtCommonTextBox[conTxtSponsorCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblSponsorName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblSponsorName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						}
					}
					else
					{
						txtDisplayLabel[conDlblSponsorName].Text = "";
					}
				}

				if (Index == conTxtDeptCode)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtDeptCode].Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select dept_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
						mysql = mysql + " from pay_department ";
						mysql = mysql + " where ";
						mysql = mysql + " dept_no = " + txtCommonTextBox[conTxtDeptCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblDeptName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						}
					}
					else
					{
						txtDisplayLabel[conDlblDeptName].Text = "";
					}
				}
				else if (Index == conTxtManagerCode)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtManagerCode].Text, SystemVariables.DataType.StringType))
					{
						mysql = "select emp_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name" : "a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name");
						mysql = mysql + " from pay_employee ";
						mysql = mysql + " where ";
						mysql = mysql + " emp_no ='" + txtCommonTextBox[conTxtManagerCode].Text + "'";

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblManagerName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblManagerName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						}
					}
					else
					{
						txtDisplayLabel[conDlblManagerName].Text = "";
					}
				}
				else if (Index == conTxtDesignationCode)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtDesignationCode].Text, SystemVariables.DataType.NumberType) || txtCommonTextBox[conTxtDesignationCode].Text == "0")
					{
						mysql = "select desg_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
						mysql = mysql + " , desg_cd ";
						mysql = mysql + " from pay_designation ";
						mysql = mysql + " where ";
						mysql = mysql + " desg_no = " + txtCommonTextBox[conTxtDesignationCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblDesgName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
							if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("HR_Budget")))
							{
								if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtDeptCode].Text, SystemVariables.DataType.NumberType))
								{
									mysql = " select Top 1 Head_Count_No from Pay_head_count phc";
									mysql = mysql + " inner join Pay_Head_Count_Category phcc on phc.head_count_category_cd = phcc.head_count_category_cd ";
									mysql = mysql + " inner join pay_department pd on pd.dept_cd = phcc.dept_cd ";
									mysql = mysql + " where pd.dept_no = " + txtCommonTextBox[conTxtDeptCode].Text;
									mysql = mysql + " and phcc.desg_cd = " + ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(2)).ToString();
									mysql = mysql + " and phc.Head_Count_Status in (1,3)";
									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
									if (!Convert.IsDBNull(mTempValue))
									{
										//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
										txtCommonTextBox[conTxtBudgetHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
										txtCommonTextBox_Leave(txtCommonTextBox[conTxtBudgetHeadCount], new EventArgs());
									}
									else
									{
										txtCommonTextBox[conTxtBudgetHeadCount].Text = "";
										txtDisplayLabel[conDlblHeadCount].Text = "";
									}
								}
							}
						}
					}
					else
					{
						txtDisplayLabel[conDlblDesgName].Text = "";
					}
				}
				else if (Index == conTxtCompanyCode)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtCompanyCode].Text, SystemVariables.DataType.NumberType) || txtCommonTextBox[conTxtCompanyCode].Text == "0")
					{
						mysql = "select comp_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_comp_name" : "a_comp_name");
						mysql = mysql + " from pay_company ";
						mysql = mysql + " where ";
						mysql = mysql + " comp_no = " + txtCommonTextBox[conTxtCompanyCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblCompName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblCompName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						}
					}
					else
					{
						txtDisplayLabel[conDlblCompName].Text = "";
					}
				}
				else if (Index == conTxtGradeCode)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtGradeCode].Text, SystemVariables.DataType.NumberType) || txtCommonTextBox[conTxtGradeCode].Text == "0")
					{
						mysql = "select grade_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_grade_name" : "a_grade_name");
						mysql = mysql + " from pay_grade ";
						mysql = mysql + " where ";
						mysql = mysql + " grade_no = " + txtCommonTextBox[conTxtGradeCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblGradeName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblGradeName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						}
					}
					else
					{
						txtDisplayLabel[conDlblGradeName].Text = "";
					}
				}
				else if (Index == conTxtBudgetHeadCount)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtBudgetHeadCount].Text, SystemVariables.DataType.NumberType))
					{
						if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtDeptCode].Text, SystemVariables.DataType.NumberType) && !SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtDesignationCode].Text, SystemVariables.DataType.NumberType))
						{
							mysql = "select head_count_no ";
							mysql = mysql + " from pay_head_count phc";
							mysql = mysql + " inner join pay_head_count_category phcc on phcc.head_count_category_cd = phc.head_count_category_cd";
							mysql = mysql + " inner join pay_department pd on pd.dept_cd = phcc.dept_cd";
							mysql = mysql + " inner join pay_designation pds on pds.desg_cd = phcc.desg_cd";
							mysql = mysql + " where ";
							mysql = mysql + " head_count_no = " + txtCommonTextBox[conTxtBudgetHeadCount].Text;
							mysql = mysql + " and phc.head_count_status in (1,3) and pd.dept_no = " + txtCommonTextBox[conTxtDeptCode].Text;
							mysql = mysql + " and pds.desg_no = " + txtCommonTextBox[conTxtDesignationCode].Text;
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mTempValue))
							{
								txtDisplayLabel[conDlblHeadCount].Text = "";
								throw new System.Exception("-9990002");
							}
							else
							{
								//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDisplayLabel[conDlblHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
							}
						}
						else
						{
							txtCommonTextBox[conTxtBudgetHeadCount].Text = "";
							txtDisplayLabel[conDlblHeadCount].Text = "";
						}
					}
					else
					{
						txtDisplayLabel[conDlblHeadCount].Text = "";
					}
				}
				else if (Index == conTxtNatCode)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtNatCode].Text, SystemVariables.DataType.NumberType) || txtCommonTextBox[conTxtNatCode].Text == "0")
					{
						mysql = "select nat_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_nat_name" : "a_nat_name");
						mysql = mysql + " from pay_nationality ";
						mysql = mysql + " where ";
						mysql = mysql + " nat_no = " + txtCommonTextBox[conTxtNatCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblNatName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblNatName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						}
					}
					else
					{
						txtDisplayLabel[conDlblNatName].Text = "";
					}
				}
				else if (Index == conTxtReligionCode)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtReligionCode].Text, SystemVariables.DataType.NumberType) || txtCommonTextBox[conTxtReligionCode].Text == "0")
					{
						mysql = "select religion_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_religion_name" : "a_religion_name");
						mysql = mysql + " from pay_religion ";
						mysql = mysql + " where ";
						mysql = mysql + " religion_no = " + txtCommonTextBox[conTxtReligionCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblReligionName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblReligionName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						}
					}
					else
					{
						txtDisplayLabel[conDlblReligionName].Text = "";
					}
				}
				else if (Index == conTxtQualificationCode)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtQualificationCode].Text, SystemVariables.DataType.NumberType) || txtCommonTextBox[conTxtQualificationCode].Text == "0")
					{
						mysql = "select qalfn_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_qalfn_name" : "a_qalfn_name");
						mysql = mysql + " from pay_qualification ";
						mysql = mysql + " where ";
						mysql = mysql + " qalfn_no = " + txtCommonTextBox[conTxtQualificationCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblQualificationName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblQualificationName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						}
					}
					else
					{
						txtDisplayLabel[conDlblQualificationName].Text = "";
					}
				}
				else if (Index == conTxtTicketType)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtTicketType].Text, SystemVariables.DataType.NumberType) || txtCommonTextBox[conTxtTicketType].Text == "0")
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ticket_type" : "a_ticket_type");
						mysql = mysql + " from pay_ticket_type ";
						mysql = mysql + " where ";
						mysql = mysql + " entry_id = " + txtCommonTextBox[conTxtTicketType].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblTicketTypeName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblTicketTypeName].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
						}
					}
					else
					{
						txtDisplayLabel[conDlblTicketTypeName].Text = "";
					}
				}
				else if (Index == conTxtTicketDestination)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtTicketDestination].Text, SystemVariables.DataType.NumberType) || txtCommonTextBox[conTxtTicketDestination].Text == "0")
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ticket_destination" : "a_ticket_destination");
						mysql = mysql + " from pay_ticket_destination ";
						mysql = mysql + " where ";
						mysql = mysql + " entry_id = " + txtCommonTextBox[conTxtTicketDestination].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblTicketDestinationName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblTicketDestinationName].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
						}
					}
					else
					{
						txtDisplayLabel[conDlblTicketDestinationName].Text = "";
					}
				}
				else if (Index == conTxtLocation)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtLocation].Text, SystemVariables.DataType.StringType) || txtCommonTextBox[conTxtLocation].Text == "0")
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_Location" : "a_Location");
						mysql = mysql + " from Pay_Emp_Location ";
						mysql = mysql + " where ";
						mysql = mysql + " Location_no = '" + txtCommonTextBox[conTxtLocation].Text + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblLocation].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblLocation].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
						}
					}
					else
					{
						txtDisplayLabel[conDlblLocation].Text = "";
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
					txtCommonTextBox[Index].Focus();
				}
				else
				{
					//
				}
			}
		}

		public void FindRoutine(string pObjectName)
		{
			//Dim mySql As String
			object mTempSearchValue = null;
			string mysql = "";
			int mDeptCd = 0;
			int mDesgCd = 0;

			if (pObjectName == "txtDefaultProject")
			{
				txtDefaultProject.Text = "";
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000130, "985"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDefaultProject.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtDefaultProject_Leave(txtDefaultProject, new EventArgs());
				}
			}

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));


			switch(mIndex)
			{
				case conTxtVisaType : 
					txtCommonTextBox[conTxtVisaType].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7210000, "1841")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtVisaType].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					 
					break;
				case conTxtSponsorCode : 
					txtCommonTextBox[conTxtSponsorCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7200000, "1837")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtSponsorCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 

					 
					break;
				case conTxtDeptCode : 
					txtCommonTextBox[conTxtDeptCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7001000, "727")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtDeptCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtManagerCode : 
					txtCommonTextBox[conTxtManagerCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtManagerCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtDesignationCode : 
					txtCommonTextBox[conTxtDesignationCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7002000, "734")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtDesignationCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtCompanyCode : 
					txtCommonTextBox[conTxtCompanyCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7001100, "1769")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtCompanyCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtGradeCode : 
					txtCommonTextBox[conTxtGradeCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7007000, "771")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtGradeCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtNatCode : 
					txtCommonTextBox[conTxtNatCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7004000, "743")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtNatCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtReligionCode : 
					txtCommonTextBox[conTxtReligionCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7003000, "739")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtReligionCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtQualificationCode : 
					txtCommonTextBox[conTxtQualificationCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7009000, "780")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtQualificationCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtTicketType : 
					txtCommonTextBox[conTxtTicketType].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220330)); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtTicketType].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtTicketDestination : 
					txtCommonTextBox[conTxtTicketDestination].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220340)); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtTicketDestination].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtBudgetHeadCount : 
					txtCommonTextBox[conTxtBudgetHeadCount].Text = ""; 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtDeptCode].Text, SystemVariables.DataType.NumberType) && !SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtDesignationCode].Text, SystemVariables.DataType.NumberType))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mDeptCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select dept_cd from pay_department where dept_no = " + txtCommonTextBox[conTxtDeptCode].Text));
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mDesgCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select desg_cd from pay_designation where desg_no = " + txtCommonTextBox[conTxtDesignationCode].Text));
						mysql = "phc.head_count_status in (1,3) and phcc.dept_cd = " + mDeptCd.ToString() + " and phcc.desg_cd = " + mDesgCd.ToString();

						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220623, "2768", mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonTextBox[conTxtBudgetHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
							txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
						}
					}
					else
					{
						MessageBox.Show("Please select department and designation!", "Budget Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					} 
					break;
				case conTxtLocation : 
					txtCommonTextBox[conTxtLocation].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220610, "2738")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtLocation].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				default:
					return;
			}

		}


		public object GetSystemPreferenceValue(object[, ] pValue)
		{
			int Cnt = 0;

			string mysql = " select * from SM_Preferences ";
			DataSet rsTempRec = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsTempRec.Tables.Clear();
			adap.Fill(rsTempRec);

			int tempForEndVar = pValue.GetUpperBound(0);
			for (Cnt = pValue.GetLowerBound(0); Cnt <= tempForEndVar; Cnt++)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempRec.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempRec.MoveFirst();
				rsTempRec.Find("preference_name='" + ReflectionHelper.GetPrimitiveValue<string>(pValue[Cnt, 1]) + "'");
				if (rsTempRec.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					pValue[Cnt, 2] = rsTempRec.Tables[0].Rows[0]["preference_value"];
				}
			}
			return null;
		}


		private void RecordNavidate(int pKeyCode, int pEmpCd)
		{

			string mysql = " select top 1 emp_cd from pay_employee ";
			mysql = mysql + " where 1=1 ";
			if (pEmpCd > 0 && pKeyCode == 37)
			{
				mysql = mysql + " and emp_cd < " + pEmpCd.ToString();
			}
			else if (pEmpCd > 0 && pKeyCode == 39)
			{ 
				mysql = mysql + " and emp_cd > " + pEmpCd.ToString();
			}

			if (pKeyCode == 37)
			{
				mysql = mysql + " order by emp_cd desc ";
			}
			else if (pKeyCode == 39)
			{ 
				mysql = mysql + " order by emp_cd asc ";
			}

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				GetRecord(mReturnValue);
			}

		}

		public void ORoutine()
		{

			if (!UserAccess.AllowUserDisplay)
			{
				MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			RecordNavidate(39, mRecordNavigateSearchValue);

		}

		public void MRoutine()
		{

			if (!UserAccess.AllowUserDisplay)
			{
				MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			RecordNavidate(37, mRecordNavigateSearchValue);
		}

		private void txtContractPeriod_Change(Object Sender, EventArgs e)
		{
			if (Information.IsDate(txtContractStratDate.Value))
			{
				txtContractEndDate.Value = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtContractStratDate.Value).AddYears(ReflectionHelper.GetPrimitiveValue<int>(txtContractPeriod.Value)).AddDays(-1);
			}
		}

		private void txtDefaultProject_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtDefaultProject");
		}

		private void txtDefaultProject_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";

				if (!SystemProcedure2.IsItEmpty(txtDefaultProject.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select project_no ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_project_name" : "a_project_name");
					mysql = mysql + " from gl_projects ";
					mysql = mysql + " where ";
					mysql = mysql + " project_no = '" + txtDefaultProject.Text + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDlblDefaultProject.Text = "";
						throw new Exception();
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDlblDefaultProject.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					}
				}
				else
				{
					txtDlblDefaultProject.Text = "";
				}
			}
			catch
			{
				MessageBox.Show("Invalid Project No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void txtJoiningDate_Change(Object Sender, EventArgs e)
		{
			if (Information.IsDate(txtJoiningDate.Value) && Information.IsNumeric(txtCommonTextBox[conTxtProbationDays].Text))
			{
				txtProbationEndDate.Value = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtJoiningDate.Value).AddDays(Conversion.Val(txtCommonTextBox[conTxtProbationDays].Text));
			}
		}

		public void ShowEmployeePayroll()
		{
			showEmpDetails(0, 701600);
		}

		public void ShowEmployeeLeave()
		{
			showEmpDetails(1, 701700);
		}
		public void ShowEmployeeIndemnity()
		{
			showEmpDetails(2, 702300);
		}
		public void ShowEmployeeFixedSalary()
		{
			showEmpDetails(3, 701300);
		}
		public void ShowEmployeeDocument()
		{
			showEmpDetails(4, 704400);
		}
	}
}