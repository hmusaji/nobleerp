
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmGLAccntTransDetailRemarks
		: System.Windows.Forms.Form
	{

		public frmGLAccntTransDetailRemarks()
{
InitializeComponent();
} 
 public  void frmGLAccntTransDetailRemarks_old()
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


		private void frmGLAccntTransDetailRemarks_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		//this recordset is used during updating and deleting the record
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
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);
				clsFlip oFlipThisForm = null;
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
				{
					oFlipThisForm = new clsFlip();

					oFlipThisForm.SwapMe(this);
				}

				txtRemarkNo.Text = SystemProcedure2.GetNewNumber("GL_Accnt_Trans_Details_Remarks_Master", "remarks_no");
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
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			txtlRemarkName.Focus();
			txtRemarkNo.Text = SystemProcedure2.GetNewNumber("GL_Accnt_Trans_Details_Remarks_Master", "remarks_no");
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

				SystemVariables.gConn.BeginTransaction();

				DataSet withVar = null;
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = "insert into GL_Accnt_Trans_Details_Remarks_Master (user_cd, remarks_no, l_remarks, a_remarks)  ";
					mysql = mysql + " values (" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
					mysql = mysql + "'" + txtRemarkNo.Text + "',";
					mysql = mysql + "'" + txtlRemarkName.Text + "',";
					mysql = mysql + "N'" + txtARemarkName.Text + "'";
					mysql = mysql + ")";
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
					withVar.Tables[0].Rows[0]["remarks_no"].setValue(txtRemarkNo.Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["l_remarks"].setValue(txtlRemarkName.Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["a_remarks"].setValue(txtARemarkName.Text);
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method withVar.Update was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Update_Renamed(null, null);
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				return true;
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				SystemVariables.gConn.BeginTransaction();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
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

				try
				{

					//On Error Resume Next
					//localRec.Close
					//Set localRec = Nothing

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
					if (Object.Equals(mSearchValue, null) || Convert.IsDBNull(mSearchValue) || ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) == "")
					{
						return;
					}


					mysql = " select * from GL_Accnt_Trans_Details_Remarks_Master where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
					localRec.Tables.Clear();
					adap.Fill(localRec);
					DataSet withVar = null;
					withVar = localRec;
					if (withVar.Tables[0].Rows.Count != 0)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtRemarkNo.Text = Convert.ToString(withVar.Tables[0].Rows[0]["remarks_no"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtlRemarkName.Text = Convert.ToString(withVar.Tables[0].Rows[0]["l_remarks"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtARemarkName.Text = Convert.ToString(withVar.Tables[0].Rows[0]["a_remarks"]) + "";

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
			//Print routine
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9018120));
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
			if (txtRemarkNo.Text == "")
			{
				MessageBox.Show("Enter Remark No", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtRemarkNo.Focus();
				return false;
			}

			if (txtlRemarkName.Text == "")
			{
				MessageBox.Show("Enter Remark Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtlRemarkName.Focus();
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
				localRec = null;
				oThisFormToolBar = null;
				frmGLAccntTransDetailRemarks.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtRemarkNo_DropButtonClick(Object Sender, EventArgs e)
		{
			txtRemarkNo.Text = SystemProcedure2.GetNewNumber("GL_Accnt_Trans_Details_Remarks_Master", "remarks_no");
		}
	}
}