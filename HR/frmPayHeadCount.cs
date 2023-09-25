
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayHeadCount
		: System.Windows.Forms.Form
	{

		public frmPayHeadCount()
{
InitializeComponent();
} 
 public  void frmPayHeadCount_old()
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


		private void frmPayHeadCount_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		private string mTimeStamp = "";

		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private const int mcmbStatus = 0;

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


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			FirstFocusObject = txtHeadcountCode;

			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
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
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);

				//Fill the combo
				object[] mObjectId = new object[1];
				mObjectId[mcmbStatus] = 1038;
				SystemCombo.FillComboWithSystemObjects(cmbCommon, mObjectId);

				//assign a next code
				txtHeadcountCode.Text = SystemProcedure2.GetNewNumber("Pay_Head_Count", "Head_Count_No");
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
				//On Keydown navigate the form by using enter key
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
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

		public void AddRecord()
		{
			//Add a record

			SystemProcedure2.ClearTextBox(this);
			txtHeadcountCode.Text = SystemProcedure2.GetNewNumber("Pay_Head_Count", "Head_Count_No");
			txtStartDate.Value = 0;
			txtNTotalSalary.Value = 0;

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
			object mReturnValue = null;
			string mysql = "";
			int mEmpCd = 0;
			int mHeadcountCategoryCd = 0;
			try
			{

				if ((((!SystemProcedure2.IsItEmpty(txtEmpCode.Text, SystemVariables.DataType.StringType)) ? -1 : 0) | ((int) chkBudgeted.CheckState)) != 0)
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("Select emp_cd from pay_employee where emp_no = '" + txtEmpCode.Text + "'"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						mEmpCd = 0;
					}
				}
				else
				{
					mEmpCd = 0;
				}

				if (!SystemProcedure2.IsItEmpty(txtHCCategoryNo.Text, SystemVariables.DataType.NumberType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("Select Head_Count_Category_Cd from Pay_Head_Count_Category where Head_Count_Category_No = " + txtHCCategoryNo.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mHeadcountCategoryCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Please enter correct Headcount category category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}
				else
				{
					MessageBox.Show("Please enter Headcount category category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				SystemVariables.gConn.BeginTransaction();
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into Pay_Head_Count(User_Cd , Head_Count_No, Head_Count_Category_Cd";
					mysql = mysql + " , Emp_Cd ,Head_Count_Status, Is_Budgeted ";
					mysql = mysql + " , Comments ,analysis1_cd,analysis2_cd,analysis3_cd,analysis4_cd,analysis5_cd)";
					mysql = mysql + " VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + ",'" + txtHeadcountCode.Text + "'";
					mysql = mysql + "," + mHeadcountCategoryCd.ToString();
					mysql = mysql + "," + ((mEmpCd == 0) ? "NULL" : mEmpCd.ToString());
					mysql = mysql + "," + cmbCommon[mcmbStatus].GetItemData(cmbCommon[mcmbStatus].ListIndex).ToString();
					mysql = mysql + "," + ((int) chkBudgeted.CheckState).ToString();
					mysql = mysql + ",N'" + txtComments.Text + "'";
					mysql = mysql + ",'" + txtAnly1.Text + "'";
					mysql = mysql + ",'" + txtAnly2.Text + "'";
					mysql = mysql + ",'" + txtAnly3.Text + "'";
					mysql = mysql + ",'" + txtAnly4.Text + "'";
					mysql = mysql + ",'" + txtAnly5.Text + "'";
					mysql = mysql + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

				}
				else
				{
					mysql = "update Pay_Head_Count  ";
					mysql = mysql + " set Head_Count_No ='" + txtHeadcountCode.Text + "'";
					mysql = mysql + " , Head_Count_Category_Cd =" + mHeadcountCategoryCd.ToString();
					mysql = mysql + " , Emp_Cd =" + ((mEmpCd == 0) ? "NULL" : mEmpCd.ToString());
					mysql = mysql + " , Head_Count_Status = " + cmbCommon[mcmbStatus].GetItemData(cmbCommon[mcmbStatus].ListIndex).ToString();
					mysql = mysql + " , Is_Budgeted = " + ((int) chkBudgeted.CheckState).ToString();
					mysql = mysql + " , Comments = N'" + txtComments.Text + "'";
					mysql = mysql + " , analysis1_cd = '" + txtAnly1.Text + "'";
					mysql = mysql + " , analysis2_cd = '" + txtAnly2.Text + "'";
					mysql = mysql + " , analysis3_cd = '" + txtAnly3.Text + "'";
					mysql = mysql + " , analysis4_cd = '" + txtAnly4.Text + "'";
					mysql = mysql + " , analysis5_cd = '" + txtAnly5.Text + "'";
					mysql = mysql + " , Modified_By_User_Cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " , Modified_By_Date_Time='" + DateTime.Today.ToString("dd-MMM-yyyy") + "'";
					mysql = mysql + " where Head_Count_Cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				FirstFocusObject.Focus();
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
			bool result = false;

			//If an error occurs, trap the error and dispaly a valid message
			SystemVariables.gConn.BeginTransaction();

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "delete from Pay_Head_Count where Head_Count_Cd=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Head Count cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			try
			{
				string mysql = "";
				object mReturnValue = null;
				SqlDataReader localRec = null;

				mysql = " select phc.*, phcc.Head_Count_Category_no , phcc.L_Head_Count_Category_Name ,pemp.emp_no , pemp.l_full_name";
				mysql = mysql + " , case when head_count_status = 2 then pemp.total_salary else case When head_count_status = 3 then phc.Total_budget_salary else pbd.Budgeted_Salary end end as salary  ";
				mysql = mysql + " , case when head_count_status = 1 then  pbd.Budget_Period else pemp.Date_Of_Joining end as StartDate  ";
				mysql = mysql + " from Pay_Head_Count phc";
				mysql = mysql + " left outer join pay_employee pemp on pemp.emp_cd = phc.emp_cd ";
				mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
				mysql = mysql + " left outer join pay_budget_details pbd on pbd.line_no = phc. Budget_Details_Line_No ";
				mysql = mysql + " where phc.Head_Count_Cd= " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{
					mSearchValue = localRec["Head_Count_Cd"];
					txtHeadcountCode.Text = Convert.ToString(localRec["Head_Count_No"]);
					txtHCCategoryNo.Text = Convert.ToString(localRec["Head_Count_Category_no"]);
					txtHCCategoryName.Text = Convert.ToString(localRec["L_Head_Count_Category_Name"]);
					txtEmpCode.Text = Convert.ToString(localRec["Emp_No"]) + "";
					txtEmpName.Text = Convert.ToString(localRec["l_full_name"]) + "";
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkBudgeted.CheckState = (CheckState) ((Convert.ToBoolean(localRec["Is_Budgeted"])) ? 1 : 0);
					SystemCombo.SearchCombo(cmbCommon[mcmbStatus], Convert.ToInt32(localRec["Head_Count_Status"]));
					txtComments.Text = Convert.ToString(localRec["Comments"]) + "";
					txtAnly1.Text = Convert.ToString(localRec["analysis1_cd"]) + "";
					txtAnly2.Text = Convert.ToString(localRec["analysis2_cd"]) + "";
					txtAnly3.Text = Convert.ToString(localRec["analysis3_cd"]) + "";
					txtAnly4.Text = Convert.ToString(localRec["analysis4_cd"]) + "";
					txtAnly5.Text = Convert.ToString(localRec["analysis5_cd"]) + "";
					txtStartDate.Value = (Convert.IsDBNull(localRec["StartDate"])) ? ((object) DateTime.Today) : localRec["StartDate"];
					txtNTotalSalary.Value = (Convert.IsDBNull(localRec["Salary"])) ? ((object) 0) : localRec["Salary"];
					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				}
				localRec.Close();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}

		}

		public void PrintReport()
		{

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220623));
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
			if (SystemProcedure2.IsItEmpty(txtHeadcountCode.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Headcount Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstFocusObject.Focus();
				return false;
			}
			return true;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				UserAccess = null;
				oThisFormToolBar = null;
				frmPayDesignation.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtHCCategoryNo" : 
					txtHCCategoryNo.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220622, "2755")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtHCCategoryNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtHCCategoryNo_Leave(txtHCCategoryNo, new EventArgs());
					} 
					break;
				default:
					return;
			}

		}

		private void txtHCCategoryNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtHCCategoryNo");
		}

		private void txtHCCategoryNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtHCCategoryNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Head_Count_Category_Name" : "A_Head_Count_Category_Name");
					mysql = mysql + " from Pay_Head_Count_Category where Head_Count_Category_No=" + txtHCCategoryNo.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtHCCategoryName.Text = "";
						//txtParentDeptNo.SetFocus
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtHCCategoryName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtHCCategoryName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		//Private Sub txtEmpCode_DropButtonClick()
		//Call FindRoutine("txtEmpCode")
		//End Sub
		//
		//Private Sub txtEmpCode_LostFocus()
		//On Error GoTo eFoundError
		//Dim mTempValue As Variant
		//Dim mySQL As String
		//Dim cnt As Integer
		//
		//If Not IsItEmpty(txtHCCategoryNo.Text, NumberType) Then
		//    mySQL = "select " & IIf(gPreferedLanguage = english, "l_Dept_name", "a_Dept_name")
		//    mySQL = mySQL + " from pay_Department where Dept_no=" & txtHCCategoryNo.Text
		//    mTempValue = GetMasterCode(mySQL)
		//    If IsNull(mTempValue) Then
		//        txtDDeptName.Text = ""
		//        'txtParentDeptNo.SetFocus
		//        Err.Raise -9990002
		//    Else
		//        txtDDeptName.Text = mTempValue
		//    End If
		//Else
		//    txtDDeptName.Text = ""
		//End If
		//Exit Sub
		//
		//eFoundError:
		//   MsgBox Err.Number & " " & Err.Description
		//End Sub
	}
}