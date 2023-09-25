
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmGLExchangeRate
		: System.Windows.Forms.Form
	{

		public frmGLExchangeRate()
{
InitializeComponent();
} 
 public  void frmGLExchangeRate_old()
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


		private void frmGLExchangeRate_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//Assign the Formid for Each Form
		int mThisFormID = 0;
		//Variable for storing the searchvalue from the Find window
		object mSearchValue = null;
		//This class checks for the rights given to the user
		
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

		private clsToolbar oThisFormToolBar = null;
		//Enum for checking the current form mode
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private string mTimeStamp = "";
		public Control FirstFocusObject = null;

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
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				FirstFocusObject = txtdate;
				txtdate.Value = DateTime.Today;
				//Assign the Image for the toolbar
				//Imagelist are kept on the main form and refered by their key
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture
				//
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

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			FirstFocusObject.Focus();
			txtdate.Value = DateTime.Today;

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "mAssign_value");
		}

		public bool saveRecord()
		{
			bool result = false;
			string mysql = "";
			int mCurrencyCode = 0;
			object mReturnValue = null;

			try
			{
				//Save a record
				//During save check for the mode
				//If in addmode then insert a record
				//else update the record in the recordset

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrencyCode = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select curr_cd from gl_currency where curr_no=" + txtCurrNo.Text));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mCurrencyCode))
				{
					MessageBox.Show("Invalid Currency code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtCurrNo.Focus();
					return result;
				}

				mysql = " select er.curr_cd from exchange_rates ER ";
				mysql = mysql + " inner join gl_currency curr on er.curr_cd = curr.curr_cd";
				mysql = mysql + " Where curr.curr_no = " + txtCurrNo.Text + " and";
				mysql = mysql + " er.as_on_date='" + ReflectionHelper.GetPrimitiveValue<string>(txtdate.Value) + "'";
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					mysql = mysql + " and er.entry_id<>" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				}
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Record already exists for same date and same currency", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					FirstFocusObject.Focus();
					return result;
				}

				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = "insert into exchange_rates (user_cd, as_on_date, curr_cd, std_rate, buy_rate, sale_rate)  ";
					mysql = mysql + " values (" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
					mysql = mysql + "'" + ReflectionHelper.GetPrimitiveValue<string>(txtdate.Value) + "',";
					mysql = mysql + Conversion.Str(mCurrencyCode) + ",";
					mysql = mysql + ((!SystemProcedure2.IsItEmpty(txtStdRate.Text, SystemVariables.DataType.NumberType)) ? txtStdRate.Text : Conversion.Str(0)) + ",";
					mysql = mysql + ((!SystemProcedure2.IsItEmpty(txtBuyRate.Text, SystemVariables.DataType.NumberType)) ? txtBuyRate.Text : Conversion.Str(0)) + ",";
					mysql = mysql + ((!SystemProcedure2.IsItEmpty(txtSaleRate.Text, SystemVariables.DataType.NumberType)) ? txtSaleRate.Text : Conversion.Str(0)) + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					mysql = " select time_stamp from exchange_rates where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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

					mysql = "UPDATE Exchange_Rates SET ";
					mysql = mysql + " Curr_Cd =" + Conversion.Str(mCurrencyCode) + ", ";
					mysql = mysql + " As_On_Date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtdate.Value) + "', ";
					mysql = mysql + " Std_Rate =" + ReflectionHelper.GetPrimitiveValue<string>(txtStdRate.Value) + ", ";
					mysql = mysql + " Buy_Rate =" + ReflectionHelper.GetPrimitiveValue<string>(txtBuyRate.Value) + ", ";
					mysql = mysql + " Sale_Rate =" + ReflectionHelper.GetPrimitiveValue<string>(txtSaleRate.Value) + ", ";
					mysql = mysql + " User_Cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where Entry_Id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				return true;
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					result = false;
				}
				else
				{
					result = false;
				}
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			return result;
		}

		public bool deleteRecord()
		{
			//Delete the Record
			bool result = false;
			try
			{
				string mysql = "";
				mysql = "delete from exchange_rates where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				return true;
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					result = false;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		public void GetRecord(int SearchValue)
		{

			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting
			try
			{

				string mysql = "";
				SqlDataReader localRec = null;
				object mExchangeMasterValue = null;

				if (SystemProcedure2.IsItEmpty(SearchValue, SystemVariables.DataType.NumberType))
				{
					return;
				}

				mysql = " select * from exchange_rates where entry_id=" + SearchValue.ToString();


				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{
					mSearchValue = localRec["entry_id"];
					mTimeStamp = Convert.ToString(localRec["time_stamp"]);
					txtdate.Value = localRec["as_on_date"];
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mExchangeMasterValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select curr_no,symbol from gl_currency where curr_cd=" + Convert.ToString(localRec["curr_cd"])));
					//UPGRADE_WARNING: (1068) mExchangeMasterValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCurrNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mExchangeMasterValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mExchangeMasterValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCurrSymbol.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mExchangeMasterValue).GetValue(1));
					txtStdRate.Value = localRec["std_rate"];
					txtBuyRate.Value = localRec["buy_rate"];
					txtSaleRate.Value = localRec["sale_rate"];

					//Change the form mode to edit
					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
		}

		public void printRecord()
		{
			//Print routine
		}

		public void findRecord()
		{
			//'Call the find window
			//Dim tempSearch As New frmSearch
			//
			//Dim mArr(2)
			//mArr(0) = 1500
			//mArr(1) = 2000
			//mArr(2) = 1000
			//
			//tempSearch.gridSqlString = "select as_on_date as [Date], gl_currency.curr_no as [Currency Code], gl_currency.symbol as [Symbol], entry_id  from exchange_rates, currency where exchange_rates.curr_cd = gl_currency.curr_cd "
			//tempSearch.gridColWidth = mArr
			//tempSearch.formName = Me
			//tempSearch.Show 1
			//
			//If Not IsItEmpty(tempSearch.getReturnValue, NumberType) Then
			//    Call GetRecord(tempSearch.getReturnValue)
			//End If
			//
			//Unload tempSearch
			//Set tempSearch = Nothing
		}
		public void CloseForm()
		{
			this.Close();
		}

		public bool CheckDataValidity()
		{
			//Check validation during update and add of records
			//If Not IsNumeric(txtUnitNo.Text) Then
			//    MsgBox "Enter the ICS_Unit Code", vbInformation, "Required"
			//    txtUnitNo.SetFocus
			//    CheckDataValidity = False
			//    Exit Function
			//End If
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
				frmGLExchangeRate.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCurrNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtCurrNo");
		}

		private void txtCurrNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (txtCurrNo.Text != "" && (!Convert.IsDBNull(txtCurrNo.Text)) && (!String.IsNullOrEmpty(txtCurrNo.Text)))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select SYMBOL from gl_currency where curr_no=" + txtCurrNo.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtCurrSymbol.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCurrSymbol.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtCurrSymbol.Text = "";
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
					//if the code is not found
					txtCurrNo.Focus();
				}
				else if (mReturnErrorType == 5)
				{ 
					//
				}
				else
				{
					//
				}
			}
		}

		public void FindRoutine(string pObjectName)
		{
			//Dim myString As String
			//Dim tempSearch  As New frmSearch
			//Dim mArr(1)
			//mArr(0) = 2500
			//mArr(1) = 3000
			//Select Case pObjectName
			//    Case "txtCurrNo"
			//        txtCurrNo.Text = ""
			//        myString = "select curr_no as [Currency Code], "
			//        myString = myString + IIf(gPreferedLanguage = English, "l_curr_name", "a_curr_name")
			//        myString = myString & " as [Currency Name], curr_no  from gl_currency "
			//        myString = myString & " order by 1 "
			//    Case Else
			//        Exit Sub
			//End Select
			//
			//tempSearch.gridSqlString = myString
			//tempSearch.gridColWidth = mArr
			//tempSearch.formName = Me
			//tempSearch.Show 1
			//
			//If Not IsItEmpty(tempSearch.getReturnValue, NumberType) Then
			//    Select Case pObjectName
			//        Case "txtCurrNo"
			//            txtCurrNo.Text = tempSearch.getReturnValue
			//            Call txtCurrNo_LostFocus
			//    End Select
			//End If
			//
			//Unload tempSearch
			//Set tempSearch = Nothing
		}
	}
}