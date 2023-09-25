
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmICSProductCategory
		: System.Windows.Forms.Form
	{

		public frmICSProductCategory()
{
InitializeComponent();
} 
 public  void frmICSProductCategory_old()
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


		private void frmICSProductCategory_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		//Enum for checking the current form mode
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private clsToolbar oThisFormToolBar = null;
		Control FirstFocusObject = null;
		string mTimeStamp = "";

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
			FirstFocusObject = txtCatNo;

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

				//
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
				//
				//assign a next code
				txtCatNo.Text = SystemProcedure2.GetNewNumber("ICS_Item_Category", "cat_no");

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
				if (Shift == 2 && (KeyCode == 67 || KeyCode == 86 || KeyCode == 88))
				{
					return;
				}

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
			txtCatNo.Text = SystemProcedure2.GetNewNumber("ICS_Item_Category", "cat_no");
			txtParentCatNo.Enabled = true;

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
			string mParentCatCode = "";
			object mReturnValue = null;
			string mysql = "";
			//Save a record
			//During save check for the mode
			//If in addmode then insert a record
			//else update the record in the recordset

			try
			{

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select cat_cd from ICS_Item_category where cat_no=" + txtParentCatNo.Text));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("invalid Product Category", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtParentCatNo.Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mParentCatCode = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}

				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " INSERT INTO ICS_Item_category(user_cd, m_cat_cd, cat_no, l_cat_name, a_cat_name, Short_Code, comments)";
					mysql = mysql + " VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
					mysql = mysql + "'" + mParentCatCode + "',";
					mysql = mysql + txtCatNo.Text + ",";
					mysql = mysql + "'" + txtLCatName.Text + "',";
					mysql = mysql + "N'" + txtACatName.Text + "',";
					mysql = mysql + "'" + txtShortName.Text + "',";
					mysql = mysql + "'" + txtComment.Text + "')";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					mysql = " select time_stamp,protected from ICS_Item_category where cat_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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
					mysql = " UPDATE ICS_Item_category SET ";
					mysql = mysql + " M_cat_Cd =" + Conversion.Str(mParentCatCode) + ",";
					mysql = mysql + " cat_No =" + txtCatNo.Text + ",";
					mysql = mysql + " L_cat_Name ='" + txtLCatName.Text + "',";
					mysql = mysql + " A_cat_Name =N'" + txtACatName.Text + "',";
					mysql = mysql + " Short_Code ='" + txtShortName.Text + "',";
					mysql = mysql + " Comments ='" + txtComment.Text + "',";
					mysql = mysql + " user_cd=" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where cat_cd=" + Conversion.Str(mSearchValue);

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
			string mysql = " select protected from ICS_Item_category where cat_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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
					mysql = "delete from ICS_Item_category where cat_cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (Information.Err().Number != 0)
					{
						MessageBox.Show("Product Category cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}


					//'''Donot allow to delete or modify the record if the information exists in the offline_transaction_details
					mysql = " select comp_id from offline_transaction_details ";
					mysql = mysql + " where table_name = 'ICS_Item_Category' ";
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
			object mReturnValue = null;
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting
			SqlDataReader localRec = null;

			string mysql = " select * from ICS_Item_category where cat_cd =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand.ExecuteReader();
			if (localRec.Read())
			{
				mSearchValue = localRec["cat_cd"];
				mTimeStamp = Convert.ToString(localRec["time_stamp"]);
				txtCatNo.Text = Convert.ToString(localRec["cat_no"]);
				txtLCatName.Text = Convert.ToString(localRec["l_cat_Name"]);
				txtLCatName.Text = Convert.ToString(localRec["l_cat_Name"]);
				txtShortName.Text = Convert.ToString(localRec["Short_Code"]) + "";

				if (Convert.ToDouble(localRec["m_cat_cd"]) == 0)
				{
					txtParentCatNo.Enabled = false;
				}
				else
				{
					txtParentCatNo.Enabled = true;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cat_name,cat_no" : " a_cat_name, cat_no") + " from ICS_Item_category where cat_cd=" + Convert.ToString(localRec["m_cat_cd"])));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtParentCatNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtParentCatName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				}
				txtComment.Text = Convert.ToString(localRec["Comments"]) + "";
				//Change the form mode to edit
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			}
			localRec.Close();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void PrintReport()
		{
			SystemReports.GetSystemReport(51001030, 1);
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

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2003000));
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
			//Get the maximum + 1 ICS_Item_category code
			txtCatNo.Text = SystemProcedure2.GetNewNumber("ICS_Item_Category", "cat_no");
			FirstFocusObject.Focus();
		}

		public bool CheckDataValidity()
		{
			//Check validation during update and add of records
			if (!Information.IsNumeric(txtCatNo.Text))
			{
				MessageBox.Show("Enter Category Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstFocusObject.Focus();
				return false;
			}
			if (!Information.IsNumeric(txtParentCatNo.Text))
			{
				MessageBox.Show("Enter Parent Category Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (txtParentCatNo.Enabled)
				{
					FirstFocusObject.Focus();
				}
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
				frmICSProductCategory.DefInstance = null;
				oThisFormToolBar = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCatNo_DropButtonClick(Object Sender, EventArgs e)
		{
			//Get the maximum + 1 ICS_Item_category code
			GetNextNumber();
		}

		private void txtParentCatNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtParentCatNo");
		}

		public void txtParentCatNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int Cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtParentCatNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cat_name" : "a_cat_name");
					mysql = mysql + " from ICS_Item_category where cat_no=" + txtParentCatNo.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtParentCatName.Text = "";
						//txtParentCostNo.SetFocus
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtParentCatName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtParentCatName.Text = "";
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
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtParentCatNo" : 
					 
					txtParentCatNo.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2003000, "47,48,49")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtParentCatNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtACatName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						txtParentCatNo_Leave(txtParentCatNo, new EventArgs());
					} 
					break;
				default:
					return;
			}
		}

		public void GetNextNumber()
		{
			txtCatNo.Text = SystemProcedure2.GetNewNumber("ICS_Item_Category", "cat_no");
			FirstFocusObject.Focus();
		}
	}
}