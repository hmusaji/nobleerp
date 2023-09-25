
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayVehicle
		: System.Windows.Forms.Form
	{

		public frmPayVehicle()
{
InitializeComponent();
} 
 public  void frmPayVehicle_old()
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


		private void frmPayVehicle_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		int mThisFormID = 0;
		object mSearchValue = null;

		
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

		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private clsToolbar oThisFormToolBar = null;


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
			//Assingn the Picture to the Graphic button
			//On Error Resume Next
			//cmdGetNextNumber.Picture = frmSysMain.imlSystemIcons.ListImages.Item("imgNextCode").Picture

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
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

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
				//txtVehicleCode.Text = GetNewNumber("Pay_Vehicle", "Vehicle_No")
				//
				SystemProcedure.SetLabelCaption(this);
				//If gPreferedLanguage = Arabic And GetSystemPreferenceSetting("flip_controls_in_arabic") = vbTrue Then
				//    Dim oFlipThisForm As New clsFlip
				//
				//    oFlipThisForm.SwapMe Me
				//End If

				txtVehicleCode.Text = SystemProcedure2.GetNewNumber("Pay_Vehicle", "Vehicle_No", 2);
				txtInsIssueDate.Value = DateTime.Today;
				txtInsExpireDate.Value = DateTime.Today;
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
			txtVehicleCode.Text = SystemProcedure2.GetNewNumber("Pay_Vehicle", "Vehicle_No", 2);
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			txtInsIssueDate.Value = DateTime.Today;
			txtInsExpireDate.Value = DateTime.Today;
			txtVehicleCode.Focus();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "mAssign_value");
		}

		public bool saveRecord()
		{
			bool result = false;
			string mysql = "";
			try
			{
				//Save a record
				//During save check for the mode
				//If in addmode then insert a record
				//else update the record in the recordset

				//Get the Parent Group Code
				//mReturnValue = GetMasterCode("select Emp_Cd from Pay_Employee where Emp_No='" & txtEmpCode.Text & "'")
				//If IsNull(mReturnValue) Then
				//    MsgBox "Invalid Employee Code", vbInformation
				//    saveRecord = False
				//    txtEmpCode.SetFocus
				//    Exit Function
				//Else
				//    mEmpCode = mReturnValue
				//End If

				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = "INSERT INTO Pay_Vehicle (User_Cd, Vehicle_No, Chassis_No, Engine_No, ";
					mysql = mysql + " Model, Model_Desc, Make, Insurance_No ";
					mysql = mysql + " ,Insurance_Company ,Insurance_Issue_Date, Insurance_Expiry_Date, Colour, No_Of_Passengers, Comments";
					mysql = mysql + " ,a_description,plate_no,gatepass_no)";
					mysql = mysql + " values (" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
					//    mysql = mysql & mEmpCode & ","
					mysql = mysql + "'" + txtVehicleCode.Text + "',";
					mysql = mysql + "'" + txtChasisNo.Text + "',";
					mysql = mysql + "'" + txtEngineNo.Text + "',";
					mysql = mysql + "'" + txtModel.Text + "',";
					mysql = mysql + "'" + txtDesc.Text + "',";
					mysql = mysql + "'" + txtMake.Text + "',";
					mysql = mysql + "'" + txtInsuranceNumber.Text + "',";
					mysql = mysql + "'" + txtInsCompName.Text + "',";
					mysql = mysql + "'" + ReflectionHelper.GetPrimitiveValue<string>(txtInsIssueDate.DisplayText) + "',";
					mysql = mysql + "'" + ReflectionHelper.GetPrimitiveValue<string>(txtInsExpireDate.DisplayText) + "',";
					mysql = mysql + "'" + txtColour.Text + "',";
					mysql = mysql + "'" + txtNo_Of_Passengers.Text + "',";
					mysql = mysql + "'" + txtComments.Text + "',";
					mysql = mysql + "N'" + txtADesc.Text + "',";
					mysql = mysql + "'" + txtPlatNo.Text + "',";
					mysql = mysql + "'" + txtGatePassNo.Text + "'";
					mysql = mysql + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));
				}
				else
				{
					mysql = " update Pay_Vehicle ";
					mysql = mysql + " set  ";
					//    mysql = mysql & " emp_cd = " & mEmpCode
					mysql = mysql + " Vehicle_No ='" + txtVehicleCode.Text + "'";
					mysql = mysql + ", Chassis_No ='" + txtChasisNo.Text + "'";
					mysql = mysql + ", Engine_No ='" + txtEngineNo.Text + "'";
					mysql = mysql + ", Model ='" + txtModel.Text + "'";
					mysql = mysql + ", Model_Desc ='" + txtDesc.Text + "'";
					mysql = mysql + ", Colour ='" + txtColour.Text + "'";
					mysql = mysql + ", Make ='" + txtMake.Text + "'";
					mysql = mysql + ", No_Of_Passengers ='" + txtNo_Of_Passengers.Text + "'";
					mysql = mysql + ", Insurance_No ='" + txtInsuranceNumber.Text + "'";
					mysql = mysql + ", Insurance_Company ='" + txtInsCompName.Text + "'";
					mysql = mysql + ", Insurance_Issue_Date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtInsIssueDate.DisplayText) + "'";
					mysql = mysql + ", Insurance_Expiry_Date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtInsExpireDate.DisplayText) + "'";
					mysql = mysql + ", Comments ='" + txtComments.Text + "'";
					mysql = mysql + ", a_Description = N'" + txtADesc.Text + "'";
					mysql = mysql + ", plate_No = '" + txtPlatNo.Text + "'";
					mysql = mysql + ", GatePass_No = '" + txtGatePassNo.Text + "'";
					mysql = mysql + ", user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where Vehicle_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}
				SystemProcedure.InsertAlarmDetails(4, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), txtComments.Text, ReflectionHelper.GetPrimitiveValue<string>(txtInsExpireDate.Value));
				return true;
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Vehicle_Cd from Pay_Vehicle where Vehicle_No= " + txtVehicleCode.Text));
					GetRecord(mSearchValue);
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
			return result;
		}

		public object deleteRecord()
		{
			object result = null;
			string mysql = "";
			object mReturnValue = null;

			try
			{

				mysql = " select protected from Pay_Vehicle where Vehicle_Cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
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

					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
					try
					{
						mysql = "delete from Pay_Vehicle where Vehicle_Cd=" + Conversion.Str(mSearchValue);
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql;
						TempCommand.ExecuteNonQuery();

						//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (Information.Err().Number != 0)
						{
							MessageBox.Show("Document Place cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							return false;
						}

						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.CommitTrans();
						SystemProcedure.AlarmDelete(4, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));
						result = true;
					}
					catch (Exception exc)
					{
						NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
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
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					AddRecord();
					((Array) result).GetValue(0);
				}
				else
				{
					result = false;
				}
			}

			return result;
		}

		public void GetRecord(object SearchValue)
		{
			//SearchTable As String, SearchField As String,
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			string mysql = "";
			object mReturnValue = null;
			SqlDataReader rsLocalRec = null;


			try
			{

				if (SystemProcedure2.IsItEmpty(SearchValue, SystemVariables.DataType.NumberType))
				{
					return;
				}


				mysql = " select * from Pay_Vehicle where Vehicle_Cd = '" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue) + "'";


				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand.ExecuteReader();
				if (rsLocalRec.Read())
				{
					txtVehicleCode.Text = Convert.ToString(rsLocalRec["Vehicle_No"]);
					txtChasisNo.Text = Convert.ToString(rsLocalRec["Chassis_No"]) + "";
					txtEngineNo.Text = Convert.ToString(rsLocalRec["Engine_No"]) + "";
					txtModel.Text = (Convert.IsDBNull(rsLocalRec["Model"])) ? "0" : Convert.ToString(rsLocalRec["Model"]);
					txtDesc.Text = Convert.ToString(rsLocalRec["Model_Desc"]) + "";
					txtColour.Text = Convert.ToString(rsLocalRec["Colour"]) + "";
					txtMake.Text = Convert.ToString(rsLocalRec["Make"]) + "";
					txtNo_Of_Passengers.Text = (Convert.IsDBNull(rsLocalRec["No_Of_Passengers"])) ? "0" : Convert.ToString(rsLocalRec["No_Of_Passengers"]);
					txtInsuranceNumber.Text = Convert.ToString(rsLocalRec["Insurance_No"]) + "";
					txtInsCompName.Text = Convert.ToString(rsLocalRec["Insurance_Company"]) + "";
					txtInsIssueDate.Value = (Convert.IsDBNull(rsLocalRec["Insurance_Issue_Date"])) ? ((object) DateTime.Today) : rsLocalRec["Insurance_Issue_Date"];
					txtInsExpireDate.Value = (Convert.IsDBNull(rsLocalRec["Insurance_Expiry_Date"])) ? ((object) DateTime.Today) : rsLocalRec["Insurance_Expiry_Date"];
					txtComments.Text = Convert.ToString(rsLocalRec["Comments"]) + "";
					txtADesc.Text = Convert.ToString(rsLocalRec["A_Description"]) + "";
					txtGatePassNo.Text = Convert.ToString(rsLocalRec["GatePass_No"]) + "";
					txtPlatNo.Text = Convert.ToString(rsLocalRec["Plate_No"]) + "";
					if (!Convert.IsDBNull(rsLocalRec["Emp_Cd"]))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_First_Name,Emp_No" : " A_First_Name, Emp_No") + " from pay_employee where Emp_Cd=" + Convert.ToString(rsLocalRec["Emp_Cd"])));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtEmpCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtEmpName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						txtEmpCode_Leave(txtEmpCode, new EventArgs());
					}
					txtComments.Text = Convert.ToString(rsLocalRec["Comments"]) + "";
					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
					//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SearchValue);
				}
				rsLocalRec.Close();
				//txtEmpCode_LostFocus
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
		}

		public void PrintReport()
		{
			//Call GetSystemReport(52020016, 1)
			//Dim rsMasterReportInformation As New Recordset ' Recordset
			//Dim rsDetailReportInformation As New Recordset
			//Dim MyReportForm As New frmSysReportDesign
			//
			//MyReportForm.oReportProperties.CreateReportInformationTablesDefinition rsMasterReportInformation, rsDetailReportInformation
			//rsMasterReportInformation.Open
			//rsDetailReportInformation.Open
			//
			//Set MyReportForm.rsMasterRecordsetName = rsMasterReportInformation
			//Set MyReportForm.rsDetailsRecordsetName = rsDetailReportInformation
			//
			//MyReportForm.oReportProperties.ReportID = 7
			//MyReportForm.oReportProperties.CallerReportID(0, 3, rsMasterReportInformation, rsDetailReportInformation) = 10
			//MyReportForm.oReportProperties.SaveReportInformation MyReportForm.oReportProperties.ReportID, rsMasterReportInformation, rsDetailReportInformation
			//MyReportForm.Show
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7160000));
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

			if (SystemProcedure2.IsItEmpty(txtVehicleCode.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter the Vehicle Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtVehicleCode.Focus();
				return false;
			}
			//
			//If IsItEmpty(txtEmpCode.Text, StringType) Then
			//    MsgBox "Enter the Employee Code", vbInformation, "Required"
			//    txtEmpCode.SetFocus
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
				frmICSUnit.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtVehicleCode_DropButtonClick(Object Sender, EventArgs e)
		{
			GetNextNumber();
		}

		public void GetNextNumber()
		{
			//Get the maximum + 1 unit code
			txtVehicleCode.Text = SystemProcedure2.GetNewNumber("Pay_Vehicle", "Vehicle_No", 2);
			txtVehicleCode.Focus();
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtEmpCode" : 
					txtEmpCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831,832,833")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtEmpCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtEmpName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						txtEmpCode_Leave(txtEmpCode, new EventArgs());
					} 
					break;
				default:
					return;
			}
		}


		private void txtEmpCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtEmpCode");
		}

		public void txtEmpCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			//'' added by burhan ghee wala
			//'' Date: 17-Jul-2007

			try
			{
				object mTempValue = null;
				string mysql = "";
				int mLinkedTextBoxIndex = 0;

				mysql = " select pemp.l_first_name + ' ' + pemp.l_second_name + ' ' + pemp.l_third_name + ' ' + pemp.l_fourth_name as L_Full_Name ";
				mysql = mysql + " , pemp.a_first_name + ' ' + pemp.a_second_name + ' ' + pemp.a_third_name + ' ' + pemp.a_fourth_name ";
				mysql = mysql + " , pdept.dept_no , pdept.l_dept_name, pdept.a_dept_name ";
				mysql = mysql + " , pdesg.desg_no , pdesg.l_desg_name, pdesg.a_desg_name ";
				mysql = mysql + " from pay_employee pemp ";
				mysql = mysql + " inner join pay_department pdept on pemp.dept_cd = pdept.dept_cd ";
				mysql = mysql + " inner join pay_designation pdesg on pemp.desg_cd = pdesg.desg_cd ";
				mysql = mysql + " where emp_no ='" + txtEmpCode.Text + "'";


				if (!SystemProcedure2.IsItEmpty(txtEmpCode.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtEmpCode.Text = "";
						throw new System.Exception("-9990002");
						return;
					}

					txtEmpName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1));

					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDepCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDesCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(5));
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDepName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDesName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(6));
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDepName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDesName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(7));
					}
				}
				else
				{

					txtEmpName.Text = "";
					txtDepCode.Text = "";
					txtDepName.Text = "";
					txtDesName.Text = "";
					txtDesCode.Text = "";
				}



				//Commented by burhan ghee Dated: 17-Jul-2007
				//Dim mTempValue As Variant
				//Dim mySql As String
				//Dim cnt As Integer
				//
				//If Not IsItEmpty(txtEmpCode.Text, StringType) Then
				//    mySql = "select " & IIf(gPreferedLanguage = English, "l_first_name", "a_first_name")
				//    mySql = mySql & " from Pay_Employee where Emp_No='" & txtEmpCode.Text & "'"
				//    mTempValue = GetMasterCode(mySql)
				//    If IsNull(mTempValue) Then
				//        txtEmpName.Text = ""
				//        'txtParentCostNo.SetFocus
				//        Err.Raise -9990002
				//    Else
				//        txtEmpName.Text = mTempValue
				//    End If
				//Else
				//    txtEmpName.Text = ""
				//End If
				//Exit Sub
				//
				//eFoundError:
				//Dim mReturnErrorType As Integer
				//mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord", msg10)
				//If mReturnErrorType = 1 Then
				//'
				//ElseIf mReturnErrorType = 2 Then
				//'
				//ElseIf mReturnErrorType = 3 Then
				//'
				//ElseIf mReturnErrorType = 4 Then
				//'    txtParentCostNo.SetFocus
				//Else
				//    '
				//End If
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
					if (txtEmpCode.Enabled)
					{
						txtEmpCode.Focus();
					}
				}
				else
				{
					//
				}
			}

		}
	}
}