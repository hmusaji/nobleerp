
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmGLSalesman
		: System.Windows.Forms.Form
	{

		public frmGLSalesman()
{
InitializeComponent();
} 
 public  void frmGLSalesman_old()
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


		private void frmGLSalesman_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//Assign the Formid for Each Form
		int mThisFormID = 0;
		object mSearchValue = null;

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

		private clsToolbar oThisFormToolBar = null;

		//Enum for checking the current form mode
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private DataSet _localRec = null;
		DataSet localRec
		{
			get
			{
				if (_localRec is null)
				{
					_localRec = new DataSet();
				}
				return _localRec;
			}
			set
			{
				_localRec = value;
			}
		}

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
			//Assingn the Picture to the Graphic button
			//On Error Resume Next
			//cmdGetNextNumber.Picture = LoadPicture(AppPath(App.Path) & "Image\" & picNextNo)

			try
			{

				FirstFocusObject = txtSmanNo;
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

				txtSmanNo.Text = SystemProcedure2.GetNewNumber("SM_SALESMAN", "sman_no");

				SystemProcedure.SetLabelCaption(this);
				clsFlip oFlipThisForm = null;
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
				{
					oFlipThisForm = new clsFlip();

					oFlipThisForm.SwapMe(this);
				}
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
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift);
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
			txtSmanNo.Text = SystemProcedure2.GetNewNumber("sm_salesman", "sman_no");

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			FirstFocusObject.Focus();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "mAssign_value");
		}

		public bool saveRecord()
		{
			//Save a record
			//During save check for the mode
			//If in addmode then insert a record
			//else update the record in the recordset

			bool result = false;
			string mysql = "";
			object mTempReturn = null;

			try
			{

				mysql = "select locat_cd from SM_Location where locat_no = " + ((txtLocatCode.Text == "") ? "Null" : txtLocatCode.Text);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempReturn = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				DataSet withVar = null;
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " INSERT INTO SM_SALESMAN(User_Cd, Sman_No, L_Sman_Name, A_Sman_Name, Addr_1, Addr_2, Phone, Fax, Mobile, Civil_Id, Pf_No, Email, Comm_Percent,Comments, Default_locat_cd)";
					mysql = mysql + " VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
					mysql = mysql + txtSmanNo.Text + ",";
					mysql = mysql + "'" + txtLSmanName.Text + "',";
					mysql = mysql + "'" + txtASmanName.Text + "',";
					mysql = mysql + "'" + txtAdd1.Text + "',";
					mysql = mysql + "'" + txtAdd2.Text + "',";
					mysql = mysql + "'" + txtPhone.Text + "',";
					mysql = mysql + "'" + txtFax.Text + "',";
					mysql = mysql + "'" + txtMobile.Text + "',";
					mysql = mysql + "'" + txtCivilId.Text + "',";
					mysql = mysql + "'" + txtPfNo.Text + "',";
					mysql = mysql + "'" + txtEmail.Text + "',";
					mysql = mysql + Conversion.Str(txtCommPercent.Value) + "0,";
					mysql = mysql + "'" + txtComment.Text + "',";
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mysql = mysql + ((System.DBNull.Value.Equals(mTempReturn)) ? "Null" : ReflectionHelper.GetPrimitiveValue<string>(mTempReturn)) + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					withVar = localRec;
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["sman_no"].setValue(txtSmanNo.Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["l_sman_Name"].setValue(txtLSmanName.Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["a_sman_Name"].setValue(txtASmanName.Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["addr_1"].setValue(txtAdd1.Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["addr_2"].setValue(txtAdd2.Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["phone"].setValue(txtPhone.Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["fax"].setValue(txtFax.Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["mobile"].setValue(txtMobile.Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["civil_id"].setValue(txtCivilId.Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["pf_no"].setValue(txtPfNo.Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["email"].setValue(txtEmail.Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["comm_percent"].setValue(ReflectionHelper.GetPrimitiveValue(txtCommPercent.Value));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["comments"].setValue(txtComment.Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Default_locat_cd"].setValue((System.DBNull.Value.Equals(mTempReturn)) ? ((object) "Null") : mTempReturn);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["User_cd"].setValue(SystemVariables.gLoggedInUserCode);
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method withVar.Update was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Update_Renamed(null, null);
				}
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
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select sman_cd from SM_Salesman where sman_no=" + txtSmanNo.Text));
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

		public bool deleteRecord()
		{
			//Delete the Record
			bool result = false;
			try
			{
				string mysql = "";
				object mReturnValue = null;

				SystemVariables.gConn.BeginTransaction();

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToDouble(localRec.Tables[0].Rows[0]["protected"]) == 0)
				{
					//UPGRADE_ISSUE: (2070) Constant adAffectCurrent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method localRec.Delete was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					localRec.Delete(UpgradeStubs.ADODB_AffectEnum.getadAffectCurrent());
					result = true;
				}
				else
				{
					MessageBox.Show(SystemConstants.msg12, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					result = false;
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return result;
				}

				//'''Donot allow to delete or modify the record if the information exists in the ST_OFFLINE_DETAILS
				mysql = " select comp_id from ST_OFFLINE_DETAILS ";
				mysql = mysql + " where table_name = 'SM_SALESMAN' ";
				mysql = mysql + " and (upload_entry_id ='" + Conversion.Str(mSearchValue).Trim() + "'";
				mysql = mysql + " or download_generated_entry_id ='" + Conversion.Str(mSearchValue).Trim() + "')";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show(SystemConstants.msg29, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select sman_cd from SM_Salesman where sman_no=" + txtSmanNo.Text));
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

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			string mysql = "";

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				localRec = null;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
				if (Object.Equals(mSearchValue, null) || Convert.IsDBNull(mSearchValue) || ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) == "")
				{
					return;
				}

				try
				{

					mysql = " select SM_Salesman.*, sm_location.locat_no from SM_Salesman left outer join sm_location on SM_Salesman.Default_locat_cd = sm_location.locat_cd where sman_cd ='" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue) + "'";

					//mysql = " select * from SM_Salesman where sman_cd=" & mSearchValue
					SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
					localRec.Tables.Clear();
					adap.Fill(localRec);
					DataSet withVar = null;
					withVar = localRec;
					if (withVar.Tables[0].Rows.Count != 0)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtSmanNo.Text = Convert.ToString(withVar.Tables[0].Rows[0]["sman_no"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtLSmanName.Text = Convert.ToString(withVar.Tables[0].Rows[0]["l_sman_Name"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtASmanName.Text = Convert.ToString(withVar.Tables[0].Rows[0]["a_sman_Name"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtAdd1.Text = Convert.ToString(withVar.Tables[0].Rows[0]["addr_1"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtAdd2.Text = Convert.ToString(withVar.Tables[0].Rows[0]["addr_2"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtPhone.Text = Convert.ToString(withVar.Tables[0].Rows[0]["phone"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFax.Text = Convert.ToString(withVar.Tables[0].Rows[0]["fax"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtMobile.Text = Convert.ToString(withVar.Tables[0].Rows[0]["mobile"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCivilId.Text = Convert.ToString(withVar.Tables[0].Rows[0]["civil_id"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtPfNo.Text = Convert.ToString(withVar.Tables[0].Rows[0]["pf_no"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtEmail.Text = Convert.ToString(withVar.Tables[0].Rows[0]["Email"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommPercent.Value = (withVar.Tables[0].Rows[0].IsNull("comm_percent")) ? ((object) "") : withVar.Tables[0].Rows[0]["comm_percent"];
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtComment.Text = Convert.ToString(withVar.Tables[0].Rows[0]["Comments"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtLocatCode.Text = Convert.ToString(withVar.Tables[0].Rows[0]["locat_no"]) + "";
						txtLocatCode_Leave(txtLocatCode, new EventArgs());

						//Change the form mode to edit
						mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
					}
					return;
				}
				catch (System.Exception excep)
				{

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void PrintReport()
		{
			SystemReports.GetSystemReport(54007030, 1);

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
			//MyReportForm.oReportProperties.ReportID = 1
			//MyReportForm.oReportProperties.CallerReportID(0, 3, rsMasterReportInformation, rsDetailReportInformation) = 10
			//MyReportForm.oReportProperties.SaveReportInformation MyReportForm.oReportProperties.ReportID, rsMasterReportInformation, rsDetailReportInformation
			//MyReportForm.Show

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1004000));
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
			if (!Information.IsNumeric(txtSmanNo.Text))
			{
				MessageBox.Show("Enter the Saleman Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
				localRec = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtLocatCode_DropButtonClick(Object Sender, EventArgs e)
		{
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2004000, "82"));
			//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			txtLocatCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
		}

		private void txtLocatCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mTempReturn = null;

			if (txtLocatCode.Text != "")
			{
				mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name");
				mysql = mysql + ",'' from SM_Location where locat_no = " + txtLocatCode.Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempReturn = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1068) mTempReturn() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLocatCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempReturn).GetValue(0));
			}
		}

		private void txtSmanNo_DropButtonClick(Object Sender, EventArgs e)
		{
			GetNextNumber();
		}

		public void GetNextNumber()
		{
			//Get the maximum + 1 salesman code
			txtSmanNo.Text = SystemProcedure2.GetNewNumber("SM_salesman", "sman_no");
			FirstFocusObject.Focus();
		}
	}
}