
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayHeadCountCategory
		: System.Windows.Forms.Form
	{

		public frmPayHeadCountCategory()
{
InitializeComponent();
} 
 public  void frmPayHeadCountCategory_old()
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


		private void frmPayHeadCountCategory_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

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
			FirstFocusObject = txtCategoryCode;

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

				//assign a next code
				txtCategoryCode.Text = SystemProcedure2.GetNewNumber("Pay_Head_Count_Category", "Head_Count_Category_No");
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
			txtCategoryCode.Text = SystemProcedure2.GetNewNumber("Pay_Head_Count_Category", "Head_Count_Category_No");
			txtStartDate.Value = "01-Jan-2011";
			txtEndDate.Value = "31-Dec-2011";

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
			int mDeptCd = 0;
			int mDesgCd = 0;
			try
			{

				if (!SystemProcedure2.IsItEmpty(txtDeptCode.Text, SystemVariables.DataType.NumberType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("Select dept_cd from pay_department where dept_no = " + txtDeptCode.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mDeptCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Please enter correct department category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}
				else
				{
					MessageBox.Show("Please enter department category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				if (!SystemProcedure2.IsItEmpty(txtDesgCode.Text, SystemVariables.DataType.NumberType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("Select desg_cd from pay_designation where desg_no = " + txtDesgCode.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mDesgCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Please enter correct Designation category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}
				else
				{
					MessageBox.Show("Please enter designation category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				SystemVariables.gConn.BeginTransaction();
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into Pay_Head_Count_Category(User_Cd , Head_Count_Category_No, L_Head_Count_Category_Name";
					mysql = mysql + " , A_Head_Count_Category_Name ,Dept_Cd, Discontinue ";
					mysql = mysql + " , Effective_Start_Date ,Effective_End_Date , desg_cd)";
					mysql = mysql + " VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + ",'" + txtCategoryCode.Text + "'";
					mysql = mysql + ",'" + txtLCategoryName.Text + "'";
					mysql = mysql + ",N'" + txtACategoryName.Text + "'";
					mysql = mysql + "," + mDeptCd.ToString();
					mysql = mysql + "," + ((int) chkDiscontinue.CheckState).ToString();
					mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDate.Value) + "'";
					mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtEndDate.Value) + "'";
					mysql = mysql + "," + mDesgCd.ToString();
					mysql = mysql + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

				}
				else
				{
					mysql = "update Pay_Head_Count_Category  ";
					mysql = mysql + " set Head_Count_Category_No ='" + txtCategoryCode.Text + "'";
					mysql = mysql + " , L_Head_Count_Category_Name ='" + txtLCategoryName.Text + "'";
					mysql = mysql + " , A_Head_Count_Category_Name =N'" + txtACategoryName.Text + "'";
					mysql = mysql + " , Dept_Cd = " + mDeptCd.ToString();
					mysql = mysql + " , Discontinue = " + ((int) chkDiscontinue.CheckState).ToString();
					mysql = mysql + " , Effective_Start_Date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDate.Value) + "'";
					mysql = mysql + " , Effective_End_Date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtEndDate.Value) + "'";
					mysql = mysql + " , Modified_By_User_Cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " , Modified_By_Date_Time='" + DateTime.Today.ToString("dd-MMM-yyyy") + "'";
					mysql = mysql + " , Desg_Cd = " + mDesgCd.ToString();
					mysql = mysql + " where Head_Count_Category_Cd=" + Conversion.Str(mSearchValue);
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
				string mysql = "delete from Pay_Head_Count_Category where Head_Count_Category_Cd=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Head Count Category cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

				mysql = " select phcc.*, pd.dept_no , pd.l_dept_name , pds.desg_no , pds.l_desg_name from Pay_Head_Count_Category phcc ";
				mysql = mysql + " inner join pay_department pd on pd.dept_cd = phcc.dept_cd ";
				mysql = mysql + " inner join pay_designation pds on pds.desg_cd = phcc.desg_cd ";
				mysql = mysql + " where Head_Count_Category_Cd= " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{
					mSearchValue = localRec["Head_Count_Category_Cd"];
					txtCategoryCode.Text = Convert.ToString(localRec["Head_Count_Category_No"]);
					txtLCategoryName.Text = Convert.ToString(localRec["L_Head_Count_Category_Name"]);
					txtACategoryName.Text = Convert.ToString(localRec["A_Head_Count_Category_Name"]) + "";
					txtDeptCode.Text = Convert.ToString(localRec["dept_no"]);
					txtDDeptName.Text = Convert.ToString(localRec["l_dept_name"]);
					txtDesgCode.Text = Convert.ToString(localRec["Desg_no"]);
					txtDlblDesgName.Text = Convert.ToString(localRec["l_desg_name"]);
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkDiscontinue.CheckState = (CheckState) ((Convert.ToBoolean(localRec["Discontinue"])) ? 1 : 0);
					txtStartDate.Value = localRec["Effective_Start_Date"];
					txtEndDate.Value = localRec["Effective_End_Date"];
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
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220622));
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
			if (SystemProcedure2.IsItEmpty(txtCategoryCode.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Category Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
				case "txtDeptCode" : 
					txtDeptCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7001000, "727,728,729")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDeptCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtDDeptName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						txtDeptCode_Leave(txtDeptCode, new EventArgs());
					} 
					break;
				case "txtDesgCode" : 
					txtDesgCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7002000, "734")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDesgCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtDesgCode_Leave(txtDesgCode, new EventArgs());
					} 
					break;
				default:
					return;
			}

		}

		private void txtDeptCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtDeptCode");
		}

		private void txtDeptCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtDeptCode.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_Dept_name" : "a_Dept_name");
					mysql = mysql + " from pay_Department where Dept_no=" + txtDeptCode.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDDeptName.Text = "";
						//txtParentDeptNo.SetFocus
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDDeptName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtDDeptName.Text = "";
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
					txtDeptCode.Focus();
				}
				else
				{
					//
				}
			}
		}


		private void txtDesgCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtDesgCode");
		}

		private void txtDesgCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtDesgCode.Text, SystemVariables.DataType.NumberType) || txtDesgCode.Text == "0")
				{
					mysql = "select desg_no ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
					mysql = mysql + " , desg_cd ";
					mysql = mysql + " from pay_designation ";
					mysql = mysql + " where ";
					mysql = mysql + " desg_no = " + txtDesgCode.Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDlblDesgName.Text = "";
						txtDesgCode.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDlblDesgName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					}
				}
				else
				{
					txtDlblDesgName.Text = "";
					txtDesgCode.Text = "";
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
					txtDeptCode.Focus();
				}
				else
				{
					//
				}
			}

		}
	}
}