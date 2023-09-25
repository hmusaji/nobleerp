
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmICSTransBatch
		: System.Windows.Forms.Form
	{

		public frmICSTransBatch()
{
InitializeComponent();
} 
 public  void frmICSTransBatch_old()
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


		private void frmICSTransBatch_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private object mSearchValue = null;
		private string mTimeStamp = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;


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
				FirstFocusObject = txtBatchNo;

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

					//assign a next code
					txtBatchNo.Text = SystemProcedure2.GetNewNumber("ics_trans_batch", "batch_no", 2);


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
			txtBatchNo.Text = SystemProcedure2.GetNewNumber("ics_trans_batch", "batch_no", 2);

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

			//Save a record
			//During save check for the mode
			//If in addmode then insert a record
			//else update the record in the recordset

			string mysql = "";
			try
			{


				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					//Get the Parent Group Code
					mysql = " INSERT INTO ics_trans_batch(user_cd, batch_no ";
					mysql = mysql + " , l_batch_name, a_batch_name, comments) ";
					mysql = mysql + " VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
					mysql = mysql + txtBatchNo.Text + ",";
					mysql = mysql + "'" + txtLBatchName.Text + "',";
					mysql = mysql + "N'" + txtABatchName.Text + "',";
					mysql = mysql + "'" + txtComment.Text + "')";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					mysql = " select time_stamp from ics_trans_batch where batch_cd ='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";
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

					//    If mReturnValue(1) Then
					//        MsgBox msg12, vbInformation
					//        gConn.RollbackTrans
					//        saveRecord = False
					//        Exit Function
					//    End If

					mysql = " UPDATE ics_trans_batch SET ";
					mysql = mysql + " batch_No =" + txtBatchNo.Text + ",";
					mysql = mysql + " L_batch_Name ='" + txtLBatchName.Text + "',";
					mysql = mysql + " A_batch_Name =N'" + txtABatchName.Text + "',";
					mysql = mysql + " Comments ='" + txtComment.Text + "',";
					mysql = mysql + " user_cd=" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where batch_cd=" + Conversion.Str(mSearchValue);

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

			//mySql = " select protected from ics_trans_batch where batch_cd=" & mSearchValue
			//mReturnValue = GetMasterCode(mySql)
			//If Not IsNull(mReturnValue) Then
			//    If mReturnValue Then
			//        MsgBox msg12, vbInformation
			//        deleteRecord = False
			//        Exit Function
			//    End If

			//If an error occurs, trap the error and dispaly a valid message
			SystemVariables.gConn.BeginTransaction();

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "delete from ics_trans_batch where batch_cd=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Batch cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				//End If

				return true;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					//mSearchValue = GetMasterCode("select from gl_accnt_group", "group_no", txtGroupNo.Text, "group_cd")
					//Call GetRecord("gl_accnt_group", "group_cd", mSearchValue, StringType)
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
			string mysql = "";
			SqlDataReader localRec = null;

			try
			{

				mysql = " select * from ics_trans_batch where batch_cd =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{
					mSearchValue = localRec["batch_cd"];
					mTimeStamp = Convert.ToString(localRec["time_stamp"]);
					txtBatchNo.Text = Convert.ToString(localRec["batch_no"]);
					txtLBatchName.Text = Convert.ToString(localRec["l_batch_Name"]);
					txtABatchName.Text = Convert.ToString(localRec["a_batch_Name"]) + "";

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
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001010));
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
		//
		//Public Sub cmdGetNextNumber_Click()
		//'Get the maximum + 1 ics_trans_batch code
		//txtBatchNo.Text = GetNewNumber("ics_trans_batch", "batch_no", 2)
		//FirstFocusObject.SetFocus
		//End Sub

		public bool CheckDataValidity()
		{
			//Check validation during update and add of records
			if (SystemProcedure2.IsItEmpty(txtBatchNo.Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Batch Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstFocusObject.Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtLBatchName.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Batch Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtLBatchName.Focus();
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
				frmICSTransBatch.DefInstance = null;
				oThisFormToolBar = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtBatchNo_DropButtonClick(Object Sender, EventArgs e)
		{
			//Get the maximum + 1 ics_trans_batch code
			GetNextNumber();
		}

		public void GetNextNumber()
		{
			txtBatchNo.Text = SystemProcedure2.GetNewNumber("ics_trans_batch", "batch_no", 2);
			FirstFocusObject.Focus();
		}
	}
}