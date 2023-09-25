
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmGLCostCenters
		: System.Windows.Forms.Form
	{

		public frmGLCostCenters()
{
InitializeComponent();
} 
 public  void frmGLCostCenters_old()
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


		private void frmGLCostCenters_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//Assign the Formid for Each Form
		//Variable for storing the searchvalue from the Find window
		int mThisFormID = 0;

		object mSearchValue = null;
		//This class checks for the rights given to the user
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
		public Control FirstFocusObject = null;
		private string mTimeStamp = "";

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
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				FirstFocusObject = txtCostNo;

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

					//assign a next code
					txtCostNo.Text = SystemProcedure2.GetNewNumber("gl_cost_centers", "cost_no");



					lblCostCategory.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_category"));
					txtCostCategoryNo.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_category"));
					txtCostCategoryName.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_category"));

					SystemProcedure.SetLabelCaption(this);
					clsFlip oFlipThisForm = null;
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
					{
						oFlipThisForm = new clsFlip();

						oFlipThisForm.SwapMe(this);
					}


					return;
				}
				catch (System.Exception excep)
				{

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
					this.Close();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
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
			txtCostNo.Text = SystemProcedure2.GetNewNumber("gl_cost_centers", "cost_no");
			txtParentCostNo.Enabled = true;

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
			int mParentCostCode = 0;
			string mCostCatCode = "";
			//Save a record
			//During save check for the mode
			//If in addmode then insert a record
			//else update the record in the recordset

			string mysql = "";
			try
			{

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select cost_cd from gl_cost_centers where cost_no=" + txtParentCostNo.Text));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Cost Center", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtParentCostNo.Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mParentCostCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("cost_category"))) == TriState.True)
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select cat_cd from gl_cost_category where cat_no=" + txtCostCategoryNo.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Cost Category", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						txtCostCategoryNo.Focus();
						return result;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCostCatCode = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}
				}
				else
				{
					mCostCatCode = "default";
				}


				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					//Get the Parent Group Code
					mysql = " INSERT INTO gl_cost_centers(user_cd, m_cost_cd, cost_no ";
					mysql = mysql + " , l_cost_name, a_cost_name, cat_cd, comments) ";
					mysql = mysql + " VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
					mysql = mysql + Conversion.Str(mParentCostCode) + ",";
					mysql = mysql + txtCostNo.Text + ",";
					mysql = mysql + "'" + txtLCostName.Text + "',";
					mysql = mysql + "N'" + txtACostName.Text + "',";
					mysql = mysql + mCostCatCode + ",";
					mysql = mysql + "'" + txtComment.Text + "')";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					mysql = " select time_stamp,protected from gl_cost_centers where cost_cd ='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";
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
					if (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(1)))
					{
						MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}

					mysql = " UPDATE gl_cost_centers SET ";
					mysql = mysql + " M_Cost_Cd =" + Conversion.Str(mParentCostCode) + ",";
					mysql = mysql + " Cost_No =" + txtCostNo.Text + ",";
					mysql = mysql + " L_Cost_Name ='" + txtLCostName.Text + "',";
					mysql = mysql + " A_Cost_Name =N'" + txtACostName.Text + "',";
					mysql = mysql + " cat_cd =" + mCostCatCode + ",";
					mysql = mysql + " Comments ='" + txtComment.Text + "',";
					mysql = mysql + " user_cd=" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where cost_cd=" + Conversion.Str(mSearchValue);

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
			//Delete the Record

			bool result = false;
			string mysql = " select protected from gl_cost_centers where cost_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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

				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					mysql = "delete from gl_cost_centers where cost_cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (Information.Err().Number != 0)
					{
						MessageBox.Show("Cost center cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

			return result;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			if (mReturnErrorType == 1)
			{
				//mSearchValue = GetMasterCode("select from gl_accnt_group", "group_no", txtGroupNo.Text, "group_cd")
				//Call GetRecord("gl_accnt_group", "group_cd", mSearchValue, StringType)
				return false;
			}
			else if (mReturnErrorType == 2)
			{ 
				AddRecord();
				return false;
			}
			else
			{
				return false;
			}
		}

		public void GetRecord(object SearchValue)
		{
			string mysql = "";
			SqlDataReader localRec = null;
			object mReturnValue = null;

			try
			{

				mysql = " select * from gl_cost_centers where cost_cd =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{
					mSearchValue = localRec["cost_cd"];
					mTimeStamp = Convert.ToString(localRec["time_stamp"]);
					txtCostNo.Text = Convert.ToString(localRec["cost_no"]);
					txtLCostName.Text = Convert.ToString(localRec["l_cost_Name"]);
					txtACostName.Text = Convert.ToString(localRec["a_cost_Name"]) + "";
					if (Convert.ToDouble(localRec["m_cost_cd"]) == 0 || Convert.IsDBNull(localRec["m_cost_cd"]))
					{
						txtParentCostNo.Text = "";
						txtParentCostName.Text = "";
						txtParentCostNo.Enabled = false;
					}
					else
					{
						txtParentCostNo.Enabled = true;
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cost_name,cost_no" : " a_cost_name, cost_no") + " from gl_cost_centers where cost_cd=" + Convert.ToString(localRec["m_cost_cd"])));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtParentCostNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtParentCostName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("cost_category"))) == TriState.True)
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cat_name, cat_no" : " a_cat_name, cat_no") + " from gl_cost_category where cat_cd=" + Convert.ToString(localRec["cat_cd"])));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCostCategoryNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCostCategoryName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					}

					txtComment.Text = Convert.ToString(localRec["Comments"]) + "";

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
			//MyReportForm.oReportProperties.ReportID = 4
			//MyReportForm.oReportProperties.CallerReportID(0, 3, rsMasterReportInformation, rsDetailReportInformation) = 10
			//MyReportForm.oReportProperties.SaveReportInformation MyReportForm.oReportProperties.ReportID, rsMasterReportInformation, rsDetailReportInformation
			//MyReportForm.Show
		}

		public void findRecord()
		{
			//Call the find window


			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000110));
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

		public void cmdGetNextNumber_Click()
		{
			//Get the maximum + 1 gl_cost_centers code
			txtCostNo.Text = SystemProcedure2.GetNewNumber("gl_cost_centers", "cost_no");
			FirstFocusObject.Focus();
		}

		public bool CheckDataValidity()
		{
			//Check validation during update and add of records
			if (SystemProcedure2.IsItEmpty(txtCostNo.Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Cost Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstFocusObject.Focus();
				return false;
			}
			if (SystemProcedure2.IsItEmpty(txtLCostName.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Cost Center Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtLCostName.Focus();
				return false;
			}
			if (SystemProcedure2.IsItEmpty(txtParentCostNo.Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Parent Cost Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (txtParentCostNo.Enabled)
				{
					txtParentCostNo.Focus();
				}
				return false;
			}

			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("cost_category"))) == TriState.True)
			{
				if (SystemProcedure2.IsItEmpty(txtCostCategoryNo.Text, SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Enter Cost Category Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCostCategoryNo.Focus();
					return false;
				}
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
				frmGLCostCenters.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCostCategoryNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtCostCategoryNo");
		}

		private void txtCostCategoryNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtCostCategoryNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cat_name" : "a_cat_name");
					mysql = mysql + " from gl_cost_category where cat_no=" + txtCostCategoryNo.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtCostCategoryName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCostCategoryName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtCostCategoryName.Text = "";
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
					//    txtParentCostNo.SetFocus
				}
				else
				{
					//
				}
			}
		}

		private void txtCostNo_DropButtonClick(Object Sender, EventArgs e)
		{
			//Get the maximum + 1 gl_cost_centers code
			GetNextNumber();
		}

		private void txtParentCostNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtParentCostNo");
		}

		public void txtParentCostNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtParentCostNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cost_name" : "a_cost_name");
					mysql = mysql + " from gl_cost_centers where cost_no=" + txtParentCostNo.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtParentCostName.Text = "";
						//txtParentCostNo.SetFocus
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtParentCostName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtParentCostName.Text = "";
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
					//    txtParentCostNo.SetFocus
				}
				else
				{
					//
				}
			}
		}

		public void FindRoutine(string pObjectName)
		{
			//call the search window
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtParentCostNo" : 
					txtParentCostNo.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000110, "882,883,884")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtParentCostNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtParentCostName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						txtParentCostNo_Leave(txtParentCostNo, new EventArgs());
					} 
					return;
				case "txtCostCategoryNo" : 
					txtCostCategoryNo.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1005000, "959,960,961")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCostCategoryNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCostCategoryName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						txtCostCategoryNo_Leave(txtCostCategoryNo, new EventArgs());
					} 
					return;
			}
		}

		public void GetNextNumber()
		{
			txtCostNo.Text = SystemProcedure2.GetNewNumber("gl_cost_centers", "cost_no");
			FirstFocusObject.Focus();
		}
	}
}