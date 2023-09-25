
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayVehicleTrans
		: System.Windows.Forms.Form
	{

		public frmPayVehicleTrans()
{
InitializeComponent();
} 
 public  void frmPayVehicleTrans_old()
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


		private void frmPayVehicleTrans_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		int mThisFormID = 0;
		object mSearchValue = null;
		object mTimeStamp = null;

		
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

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
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
			txtVehicleTransNo.Text = SystemProcedure2.GetNewNumber("Pay_Vehicle_Trans", "Trans_No", 2);
			txtVoucherDate.Value = DateTime.Today;
			//txtVehicleCode.SetFocus

		}

		private void txtEmpCodeNew_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtEmpCodeNew");
		}

		private void txtVehicleCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtVehicleCode");
		}

		private void txtVehicleCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			object mReturnValue = null;
			string mCheckTimeStamp = "";
			string mysql = "";
			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				if (txtVehicleCode.Text != "" && !SystemProcedure2.IsItEmpty(txtVehicleCode.Text, SystemVariables.DataType.StringType))
				{
					mysql = " select pemp.emp_no, pemp.l_full_name";
					mysql = mysql + " from pay_vehicle pv ";
					mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = pv.emp_cd";
					mysql = mysql + " where Vehicle_No='" + txtVehicleCode.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtEmpCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtEmpName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					}
				}
			}
		}

		private void txtVehicleTransNo_DropButtonClick(Object Sender, EventArgs e)
		{
			txtVehicleTransNo.Text = SystemProcedure2.GetNewNumber("Pay_Vehicle_Trans", "Trans_No", 2);
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
						txtEmpName.Text = GetEmployeeName(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)));
					} 
					break;
				case "txtEmpCodeNew" : 
					txtEmpCodeNew.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtEmpCodeNew.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtEmpNameNew.Text = GetEmployeeName(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)));
					} 
					break;
				case "txtVehicleCode" : 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7160000, "1487")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtVehicleCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtVehicleCode_Leave(txtVehicleCode, new EventArgs());
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

		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);
			txtVehicleTransNo.Text = SystemProcedure2.GetNewNumber("Pay_Vehicle_Trans", "Trans_No", 2);
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			txtVehicleCode.Focus();
			return;
		}

		public void CloseForm()
		{
			this.Close();
		}

		public object deleteRecord()
		{
			object result = null;
			string mysql = "";
			object mReturnValue = null;

			try
			{

				mysql = " select protected from Pay_Vehicle_Trans where Line_no=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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
						mysql = "delete from Pay_Vehicle_Trans where Line_no=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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


				mysql = " select pvt.*";
				mysql = mysql + " , pnew.emp_no as newemp," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pnew.l_Full_Name" : "pnew.A_full_Name") + " as pnewname";
				mysql = mysql + " ,pv.vehicle_no";
				mysql = mysql + " from Pay_Vehicle_Trans pvt";
				mysql = mysql + " inner join pay_employee pnew on pnew.emp_cd = pvt.New_emp_cd";
				mysql = mysql + " inner join pay_vehicle pv on pv.vehicle_cd = pvt.vehicle_cd";
				mysql = mysql + " where Line_no= " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);


				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand.ExecuteReader();
				if (rsLocalRec.Read())
				{
					mTimeStamp = rsLocalRec["time_stamp"];
					txtVehicleTransNo.Text = Convert.ToString(rsLocalRec["Trans_No"]);
					txtVehicleCode.Text = Convert.ToString(rsLocalRec["vehicle_no"]);
					txtVoucherDate.Value = rsLocalRec["Trans_date"];
					txtEmpCodeNew.Text = Convert.ToString(rsLocalRec["newemp"]);
					txtEmpNameNew.Text = Convert.ToString(rsLocalRec["pnewname"]);
					txtNKMPerMonth.Value = rsLocalRec["Per_Month_KM"];
					txtComments.Text = (Convert.IsDBNull(rsLocalRec["Remarks"])) ? "" : Convert.ToString(rsLocalRec["Remarks"]);
					if (!Convert.IsDBNull(rsLocalRec["Current_emp_cd"]))
					{
						mysql = " select emp_no," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_Full_Name" : "A_full_Name") + " as name";
						mysql = mysql + " from pay_employee where emp_cd=" + Convert.ToString(rsLocalRec["Current_emp_cd"]);
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtEmpCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtEmpName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						}
					}
				}
				rsLocalRec.Close();
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
		}
		public bool CheckDataValidity()
		{

			if (SystemProcedure2.IsItEmpty(txtVehicleCode.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter the Vehicle Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtVehicleCode.Focus();
				return false;
			}

			//If IsItEmpty(txtEmpCode.Text, StringType) Then
			//    MsgBox "Enter the Employee Code", vbInformation, "Required"
			//    txtEmpCode.SetFocus
			//    CheckDataValidity = False
			//    Exit Function
			//End If

			if (SystemProcedure2.IsItEmpty(txtEmpCodeNew.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter the Employee Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtEmpCode.Focus();
				return false;
			}

			return true;
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220200));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}

		}


		public bool saveRecord()
		{
			bool result = false;
			string mysql = "";
			object mReturnValue = null;
			int mEmpCode = 0;
			int mVehicleCode = 0;
			int mEmpCodeNew = 0;
			try
			{
				//Save a record
				//During save check for the mode
				//If in addmode then insert a record
				//else update the record in the recordset

				//Get the Parent Group Code
				Application.DoEvents();

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Emp_Cd from Pay_Employee where Emp_No='" + txtEmpCodeNew.Text + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid New Employee Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtEmpCode.Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEmpCodeNew = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select vehicle_cd,emp_cd from Pay_vehicle where vehicle_no='" + txtVehicleCode.Text + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(((Array) mReturnValue).GetValue(0)))
				{
					MessageBox.Show("Invalid vehicle Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtVehicleCode.Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mVehicleCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(((Array) mReturnValue).GetValue(1)))
				{
					mEmpCode = 0;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEmpCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
				}

				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = "INSERT INTO Pay_Vehicle_trans (User_Cd, Vehicle_Cd, Trans_No, Trans_date, Current_emp_cd, ";
					mysql = mysql + " New_emp_cd, Remarks, Per_Month_KM)";
					mysql = mysql + " values (" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
					mysql = mysql + mVehicleCode.ToString() + ",";
					mysql = mysql + "'" + txtVehicleTransNo.Text + "',";
					mysql = mysql + "'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "',";
					if (mEmpCode == 0)
					{
						mysql = mysql + " Null" + ",";
					}
					else
					{
						mysql = mysql + mEmpCode.ToString() + ",";
					}
					mysql = mysql + mEmpCodeNew.ToString() + ",";
					mysql = mysql + "'" + txtComments.Text + "'";
					mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(txtNKMPerMonth.Value);
					mysql = mysql + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					mysql = " select time_stamp from pay_vehicle_trans where line_no =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					}
					else
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						txtVehicleTransNo.Focus();
						return result;
					}

					mysql = " update Pay_Vehicle_trans ";
					mysql = mysql + " set  ";
					mysql = mysql + " Vehicle_Cd = " + mVehicleCode.ToString();
					mysql = mysql + " , Trans_No ='" + txtVehicleTransNo.Text + "'";
					mysql = mysql + ", Trans_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
					if (mEmpCode == 0)
					{
						mysql = mysql + ", Current_emp_cd = Null";
					}
					else
					{
						mysql = mysql + ", Current_emp_cd =" + mEmpCode.ToString();
					}
					mysql = mysql + ", New_emp_cd =" + mEmpCodeNew.ToString();
					mysql = mysql + ", Remarks ='" + txtComments.Text + "'";
					mysql = mysql + ", user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + ", Per_Month_KM = " + ReflectionHelper.GetPrimitiveValue<string>(txtNKMPerMonth.Value);
					mysql = mysql + " where line_no = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}

				mysql = " update pay_vehicle";
				mysql = mysql + " set ";
				mysql = mysql + " emp_cd=" + mEmpCodeNew.ToString();
				mysql = mysql + " where vehicle_cd=" + mVehicleCode.ToString();
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

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

		private string GetEmployeeName(string pEmpNo)
		{

			string mysql = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_full_name" : "a_full_name");
			mysql = mysql + " from pay_employee";
			mysql = mysql + " where emp_no = '" + pEmpNo + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				return ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
			}
			else
			{
				return "";
			}

		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}