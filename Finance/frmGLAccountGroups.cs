
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmGLAccountGroups
		: System.Windows.Forms.Form
	{

		private int mThisFormID = 0; //Assign the Formid for Each Form
		private object mSearchValue = null; //Variable for storing the searchvalue from the Find window
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0; //Enum for checking the current form mode
		
		public frmGLAccountGroups()
{
InitializeComponent();
} 
 public  void frmGLAccountGroups_old()
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
		 //This class checks for the rights given to the user
		public Control FirstFocusObject = null;

		private clsToolbar oThisFormToolBar = null;
		private string mTimeStamp = "";
		//Private mOldParentGroupCode As String
		private string mNewParentGroupCode = "";

		public Form mParentForm = null;
		public bool mParentFormCall = false;

		//define form level constants
		private const int mIndexGroupChildDetails = 0;
		private const int mParentGroupNameIndex = 6;
		private const int mTotalNoOfChildLedgerIndex = 7;
		private const int mTotalNoOfChildGroupIndex = 8;
		private const string mBracketOpener = " (";
		private const string mBracketCloser = ") ";
		private const string mTotalNoOfChildGroupText = " Sub Groups (Under This Group) ";
		private const string mTotalNoOfChildLedgerText = " Ledger Accounts (Under This Group) ";

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


		private void cmdCommon_Click(Object eventSender, EventArgs eventArgs)
		{
			if (!SystemProcedure2.IsItEmpty(txtParentGroupNo.Text, SystemVariables.DataType.StringType))
			{
				txtGroupNo.Text = GetNewGroupNo(txtParentGroupNo.Text);
			}
		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				SystemMenu.SetMeCurrentInWindowList(Conversion.Str(this.Handle.ToInt32()));
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				FirstFocusObject = txtGroupNo;
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
					//.DisableHelpButton = True

					this.WindowState = FormWindowState.Maximized;


					//**--make the form visible before all the control gets loaded
					//**--(this way system pretends to be faster in loading forms)
					this.Show();
					Application.DoEvents();
					//**-------------------------------------------------------------------------------------------

					ShowHideMasterDetails();
					GetNextNumber();
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

				if (Shift == 2 && (KeyCode == 67 || KeyCode == 86 || KeyCode == 88))
				{
					return;
				}

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

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));


				UserAccess = null;
				oThisFormToolBar = null;
				frmGLAccountGroups.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void AddRecord()
		{ //Add a record
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank

			SystemProcedure2.ClearTextBox(this);
			GetNextNumber();
			ShowHideMasterDetails();

			FirstFocusObject.Focus();
			return;


			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord()
		{
			bool result = false;
			string mysql = "";
			clsHourGlass myHourGlass = null;
			object mProtectedRecord = null;
			object mReturnValue = null;
			int mParentReportGroup = 0;
			int mChildReportGroup = 0;

			try
			{

				myHourGlass = new clsHourGlass();

				SystemVariables.gConn.BeginTransaction();
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{

					mysql = "insert into gl_accnt_group(m_group_cd, group_no, ";
					mysql = mysql + " l_group_name, a_group_name, comments, ag_type_cd, user_cd)";
					mysql = mysql + " values(";

					if (mNewParentGroupCode == "")
					{
						mysql = mysql + " NULL ,";
					}
					else
					{
						mysql = mysql + mNewParentGroupCode + ",";
					}

					mysql = mysql + "'" + txtGroupNo.Text + "',";
					mysql = mysql + "'" + txtLGroupName.Text + "',";
					mysql = mysql + "N'" + txtAGroupName.Text + "',";
					mysql = mysql + "N'" + txtComment.Text + "',";
					mysql = mysql + Conversion.Str(txtTypeCode.Text) + " ,";
					mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));
				}
				else
				{

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mProtectedRecord = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select protected from gl_accnt_group where group_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue)));
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(mProtectedRecord)) == TriState.True)
					{
						mysql = "update gl_accnt_group";
						mysql = mysql + " set group_no = " + txtGroupNo.Text + ",";
						mysql = mysql + " l_group_name ='" + txtLGroupName.Text + "',";
						mysql = mysql + " a_group_name = N'" + txtAGroupName.Text + "',";
						mysql = mysql + " comments = N'" + txtComment.Text + "',";
						mysql = mysql + " ag_type_cd =" + txtTypeCode.Text;
						mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
						mysql = mysql + " where group_cd='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";
					}
					else
					{
						mysql = "update gl_accnt_group";
						mysql = mysql + " set ";

						if (mNewParentGroupCode == "")
						{
							mysql = mysql + " m_group_cd = NULL ,";
						}
						else
						{
							mysql = mysql + " m_group_cd =" + mNewParentGroupCode + ",";
						}

						mysql = mysql + " group_no = " + txtGroupNo.Text + ",";
						mysql = mysql + " l_group_name ='" + txtLGroupName.Text + "',";
						mysql = mysql + " a_group_name = N'" + txtAGroupName.Text + "',";
						mysql = mysql + " comments = N'" + txtComment.Text + "',";
						mysql = mysql + " ag_type_cd =" + txtTypeCode.Text;
						mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
						mysql = mysql + " where group_cd='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";
					}

					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

				}

				//If mParentFormCall = True Then
				//    If mParentForm.IsFormOpen = True Then
				//        Call mParentForm.FillGrid
				//    End If
				//End If

				if (!SystemProcedure2.IsItEmpty(mNewParentGroupCode, SystemVariables.DataType.NumberType))
				{
					mysql = " select report_group from gl_accnt_types gat ";
					mysql = mysql + " inner join gl_accnt_group gag on gat.type_cd = gag.ag_type_cd ";
					mysql = mysql + " where gag.group_cd = " + mNewParentGroupCode;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mParentReportGroup = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}

					mysql = " select report_group from gl_accnt_types gat ";
					mysql = mysql + " where type_cd= " + txtTypeCode.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mChildReportGroup = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}

					if (mParentReportGroup != mChildReportGroup)
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show(" Account Type of Parent and Child does not match, Record cannot be saved. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtTypeCode.Focus();
						return false;
					}
				}

				mysql = "execute glUpdateGroupReportingSequence " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ", 0";
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				mysql = "execute glUpdateChildGroupReportingSequence " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select group_level from gl_accnt_group where group_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue)));
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();


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
				if (mReturnErrorType == 1)
				{
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					result = false;
				}
				else if (mReturnErrorType == 3)
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

		public bool deleteRecord()
		{ //Delete the Record

			bool result = false;
			string mysql = " select protected from gl_accnt_group where group_cd='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";
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
					mysql = "delete from gl_accnt_group where group_cd='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (Information.Err().Number != 0)
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show("Group cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}


					//'''Donot allow to delete or modify the record if the information exists in the offline_transaction_details
					if (!SystemProcedure2.AllowItemChange("gl_accnt_group", mSearchValue))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show(SystemConstants.msg29, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
				return false;
			}
			else if (mReturnErrorType == 2)
			{ 
				return false;
			}
			else if (mReturnErrorType == 3)
			{ 
				return false;
			}
			else
			{
				return false;
			}
		}

		public void GetRecord(object pSearchValue)
		{
			DataSet rsLocalRec = null;
			string mysql = "";

			try
			{

				if (SystemProcedure2.IsItEmpty(pSearchValue, SystemVariables.DataType.StringType))
				{
					return;
				}

				//Change the form mode to edit
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;

				mysql = " select ag.*, pg.group_no as parent_no, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pg.l_group_name" : "pg.a_group_name") + " as parent_group, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "tg.l_group_name" : "tg.a_group_name") + " as top_parent_group ";
				mysql = mysql + " ," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "act.l_type_name" : "act.a_type_name") + " as type_name ";
				mysql = mysql + " from gl_accnt_group ag ";
				mysql = mysql + " left join gl_accnt_group pg on ag.m_group_cd = pg.group_cd ";
				mysql = mysql + " left outer join gl_accnt_group tg on pg.m_group_cd = tg.group_cd ";
				mysql = mysql + " left outer join gl_accnt_types act on ag.ag_type_cd = act.type_cd ";
				mysql = mysql + " where ag.group_cd =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

				rsLocalRec = new DataSet();
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLocalRec.Tables.Clear();
				adap.Fill(rsLocalRec);
				if (rsLocalRec.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtGroupNo.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["group_no"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtLGroupName.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["l_Group_Name"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtAGroupName.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["a_Group_Name"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtParentGroupNo.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["parent_no"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtParentGroupName.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["parent_group"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtComment.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["Comments"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mTimeStamp = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["time_stamp"]);

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtTypeCode.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["ag_type_cd"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtDTypeName.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["type_name"]) + "";

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (!SystemProcedure2.IsItEmpty(rsLocalRec.Tables[0].Rows[0]["top_parent_group"], SystemVariables.DataType.StringType))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						lblCommon[mParentGroupNameIndex].Caption = mBracketOpener + Convert.ToString(rsLocalRec.Tables[0].Rows[0]["top_parent_group"]) + mBracketCloser;
					}
					else
					{
						lblCommon[mParentGroupNameIndex].Caption = "";
					}
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtGroupNo.Tag = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["m_group_cd"]) + "";
					lblCommon[mTotalNoOfChildLedgerIndex].Caption = " Total " + Conversion.Str(SystemProcedure2.GetMasterCode("select count(*) from gl_ledger where group_cd = '" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue) + "'")) + mTotalNoOfChildLedgerText;
					lblCommon[mTotalNoOfChildGroupIndex].Caption = " Total " + Conversion.Str(SystemProcedure2.GetMasterCode("select count(*) from gl_accnt_group where m_group_cd = '" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue) + "'")) + mTotalNoOfChildGroupText;

					ShowHideMasterDetails();
				}
				else
				{
					MessageBox.Show("No records found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				rsLocalRec = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
		}

		public void PrintReport()
		{
			//Print routine
			SystemReports.GetSystemReport(41001030, 1);
		}

		public void findRecord()
		{ //Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1002000));
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

		private void txtGroupNo_DropButtonClick(Object Sender, EventArgs e)
		{
			GetNextNumber();
		}

		private void txtParentGroupNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtParentGroupNo");
		}

		public void txtParentGroupNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			object mTempValue = null;
			string mysql = "";

			try
			{

				if (!SystemProcedure2.IsItEmpty(txtParentGroupNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = " select pg.l_group_name, pg.a_group_name, pg.group_cd, pg.show,  ";
					mysql = mysql + " tg.l_group_name, tg.a_group_name,  pg.AG_Type_cd, at.L_Type_Name, at.A_Type_Name";
					mysql = mysql + " from gl_accnt_group pg INNER JOIN  GL_Accnt_Types at ON pg.AG_Type_Cd = at.Type_Cd";
					mysql = mysql + " left outer join gl_accnt_group tg on pg.m_group_cd = tg.group_cd ";
					mysql = mysql + " where pg.show = 1 and pg.group_no = '" + txtParentGroupNo.Text + "'";
					//mysql = mysql & " and tg.show = 1 "
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtParentGroupName.Text = "";
						txtParentGroupNo.Tag = "";
						throw new System.Exception("-9990002");
						txtParentGroupNo.Focus();
					}
					else
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(3))) == TriState.False)
						{
							txtParentGroupName.Text = "";
							txtParentGroupNo.Tag = "";
							throw new System.Exception("-9990002");
							txtParentGroupNo.Focus();
						}
						else
						{
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtParentGroupName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
								lblCommon[mParentGroupNameIndex].Caption = mBracketOpener + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4)) + mBracketCloser;
							}
							else
							{
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtParentGroupName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
								lblCommon[mParentGroupNameIndex].Caption = mBracketOpener + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(5)) + mBracketCloser;
							}
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtTypeCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(6));
							txtTypeCode_Leave(txtTypeCode, new EventArgs());
							txtParentGroupNo.Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
						}
					}
				}
				else
				{
					txtParentGroupName.Text = "";
					txtParentGroupNo.Tag = "";
				}
				ShowHideMasterDetails();
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
					//txtParentGroupNo.SetFocus
				}
				else
				{
					//
				}
			}
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;
			string mSQL = "";

			switch(pObjectName)
			{
				case "txtParentGroupNo" : 
					txtParentGroupNo.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1002000, "15")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtParentGroupNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtParentGroupNo_Leave(txtParentGroupNo, new EventArgs());
					} 
					break;
				case "txtTypeCode" : 
					txtTypeCode.Text = ""; 
					mSQL = " type_cd in (1,2)         "; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1007000, "1606", mSQL)); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtTypeCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtTypeCode_Leave(txtTypeCode, new EventArgs());
					} 
					break;
				default:
					return;
			}
			ShowHideMasterDetails();
		}

		private void GetNextNumber()
		{
			//Get the maximum + 1 accnt_group code
			txtGroupNo.Text = SystemProcedure2.GetNewNumber("gl_accnt_group", "group_no");
		}

		private void ShowHideMasterDetails()
		{
			bool ShowSetting = false;

			//--setting - 1
			ShowSetting = CurrentFormMode != SystemVariables.SystemFormModes.frmAddMode;
			Frame1.Visible = ShowSetting;

			//--setting - 2
			lblCommon[mParentGroupNameIndex].Visible = !SystemProcedure2.IsItEmpty(txtParentGroupNo.Text, SystemVariables.DataType.NumberType);


			//**--in case the record is protected by the system
			//**--do not allow the parent to be changed
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				ShowSetting = ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select protected from gl_accnt_group where group_cd = '" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'"))) != TriState.True;
			}
			else
			{
				ShowSetting = true;
			}
			txtParentGroupNo.Enabled = ShowSetting;
		}

		public bool CheckDataValidity()
		{
			bool result = false;
			DataSet rsMasterInfo = null;
			string mCheckTimeStamp = "";
			string mysql = "";

			txtParentGroupNo_Leave(txtParentGroupNo, new EventArgs());

			mNewParentGroupCode = Convert.ToString(txtParentGroupNo.Tag);

			//check validation during update and add of records
			if (SystemProcedure2.IsItEmpty(txtGroupNo.Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter group code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstFocusObject.Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtTypeCode.Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Type Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtTypeCode.Focus();
				return false;
			}

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				//--check the timestamp value
				mysql = "select time_stamp, m_group_cd ";
				mysql = mysql + " from gl_accnt_group where group_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				SqlDataAdapter TempAdapter = null;
				TempAdapter = new SqlDataAdapter();
				TempAdapter.SelectCommand = TempCommand;
				DataSet TempDataset = null;
				TempDataset = new DataSet();
				TempAdapter.Fill(TempDataset);
				rsMasterInfo = TempDataset;
				//mOldParentGroupCode = rsMasterInfo("m_group_cd")
				if (rsMasterInfo.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mCheckTimeStamp = Convert.ToString(rsMasterInfo.Tables[0].Rows[0]["time_stamp"]);
				}
				if ((rsMasterInfo.Tables[0].Rows.Count == 0) || (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp)))
				{
					MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					FirstFocusObject.Focus();
					return result;
				}

				//    '--check if there is any record exists for the given master
				//    If mOldParentGroupCode <> mNewParentGroupCode Then
				//        If Val(GetMasterCode("select count(*) from gl_ledger where group_cd =" & mSearchValue)) > 0 Then
				//            '--do not allow update
				//            MsgBox "Error : Can not change Parent Group. Child Ledger Account Exists!", vbInformation
				//            CheckDataValidity = False
				//            FirstFocusObject.SetFocus
				//            Exit Function
				//        ElseIf Val(GetMasterCode("select count(*) from gl_accnt_group where m_group_cd =" & mSearchValue)) > 0 Then
				//            '--do not allow update
				//            MsgBox "Error : Can not change Parent Group. Child Group Exists!", vbInformation
				//            CheckDataValidity = False
				//            FirstFocusObject.SetFocus
				//            Exit Function
				//        End If
				//    End If

				rsMasterInfo = null;
			}

			return true;
		}

		private string GetNewGroupNo(string pGroupNo)
		{
			string result = "";
			int mGroupCd = 0;

			string mysql = " select group_cd from gl_accnt_group ";
			mysql = mysql + " where group_no='" + pGroupNo + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mGroupCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				mysql = " select max(cast(gag.group_no as bigint))  ";
				mysql = mysql + " from gl_accnt_group gag ";
				mysql = mysql + " where gag.m_group_cd = " + mGroupCd.ToString();

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					result = pGroupNo + "1";
				}
				else
				{
					result = (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(mReturnValue)) + 1).ToString();
				}
			}
			return result;
		}

		private void txtTypeCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtTypeCode");
		}

		private void txtTypeCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			object mTempValue = null;
			string mysql = "";

			try
			{

				if (!SystemProcedure2.IsItEmpty(txtTypeCode.Text, SystemVariables.DataType.NumberType))
				{
					mysql = " select l_type_name, a_type_name, type_cd, show from gl_accnt_types where show = 1 and type_cd in (1,2) and type_cd =" + txtTypeCode.Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtTypeCode.Text = "";
						txtDTypeName.Text = "";
						txtTypeCode.Tag = "";
						throw new System.Exception("-9990002");
						txtTypeCode.Focus();
					}
					else
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(3))) == TriState.False)
						{
							txtTypeCode.Text = "";
							txtDTypeName.Text = "";
							txtTypeCode.Tag = "";
							throw new System.Exception("-9990002");
							txtTypeCode.Focus();
						}
						else
						{
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDTypeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
							}
							else
							{
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDTypeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
							}
							txtTypeCode.Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
						}
					}
				}
				else
				{
					txtDTypeName.Text = "";
					txtTypeCode.Tag = "";
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
			}

		}
		public void helpProc()
		{
			//Print routine
			modHelp.ShowHelp(1);
		}
	}
}