
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmICSBid
		: System.Windows.Forms.Form
	{

		private int mThisFormID = 0; //Assign the Formid for Each Form
		private object mSearchValue = null; //Variable for storing the searchvalue from the Find window
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0; //Enum for checking the current form mode
		
		public frmICSBid()
{
InitializeComponent();
} 
 public  void frmICSBid_old()
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
				FirstFocusObject = txtBidNo;
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

					//**--make the form visible before all the control gets loaded
					//**--(this way system pretends to be faster in loading forms)
					this.Show();
					Application.DoEvents();
					//**-------------------------------------------------------------------------------------------

					//Call ShowHideMasterDetails
					GetNextNumber();
					SystemProcedure.SetLabelCaption(this);
					txtValidityDate.Value = SystemVariables.gCurrentDate;
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

				if (this.ActiveControl.Name == txtCurrencyCode.Name)
				{
					if (KeyCode == ((int) Keys.F2))
					{
						txtCurrencyCode_DropButtonClick(txtCurrencyCode, null);
					}
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
				frmICSBid.DefInstance = null;
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

			ClearControls();

			GetNextNumber();

			FirstFocusObject.Focus();
			return;


			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		private void ClearControls()
		{
			txtCurrencyCode.Text = "";
			txtCurrencyName.Text = "";
			txtBidAmount.Value = 0;
			txtValidityDate.Value = SystemVariables.gCurrentDate;
			chkBankGuarantee.CheckState = CheckState.Unchecked;
			chkCertifiedCheque.CheckState = CheckState.Unchecked;
			txtBGCCNo.Text = "";
			txtIssueDate.Text = "";
			txtBankInitials.Text = "";
		}

		public bool saveRecord()
		{
			bool result = false;
			string mysql = "";
			object mReturnValue = null;
			clsHourGlass myHourGlass = null;
			int mCurrCD = 0;
			try
			{
				mCurrCD = 0;
				myHourGlass = new clsHourGlass();
				if (txtCurrencyCode.Text != "")
				{
					mysql = " select curr_cd from gl_currency where curr_no = '" + txtCurrencyCode.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCurrCD = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Invalid Currency!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						txtCurrencyCode.Focus();
						return false;
					}
				}

				SystemVariables.gConn.BeginTransaction();
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " select bid_no from ics_bid where bid_no='" + txtBidNo.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Duplicate Bid Number", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtBidNo.Focus();
						return false;
					}

					mysql = "insert into ics_bid (bid_no,bank_guarantee,";
					mysql = mysql + "certified_cheque, validity_date, bid_amount, bg_cc_no, curr_cd, bank_initials, issue_date, user_cd)";
					mysql = mysql + " values(";

					mysql = mysql + "'" + txtBidNo.Text + "'";
					mysql = mysql + "," + ((int) chkBankGuarantee.CheckState).ToString();
					mysql = mysql + "," + ((int) chkCertifiedCheque.CheckState).ToString();
					mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtValidityDate.Value) + "'";
					mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(txtBidAmount.Value); // Str(Format(Val(txtBidAmount.Text), "###############0.000"))
					mysql = mysql + "," + txtBGCCNo.Text;
					mysql = mysql + "," + ((mCurrCD == 0) ? " NULL " : mCurrCD.ToString());
					mysql = mysql + ",'" + txtBankInitials.Text + "'";
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mysql = mysql + "," + ((Convert.IsDBNull(txtIssueDate.Value)) ? " Null " : "'" + ReflectionHelper.GetPrimitiveValue<string>(txtIssueDate.Value) + "'");
					mysql = mysql + "," + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));
				}
				else
				{
					mysql = "update ics_bid";
					mysql = mysql + " set bid_no ='" + txtBidNo.Text + "'";
					mysql = mysql + " bank_guarantee =" + ((int) chkBankGuarantee.CheckState).ToString();
					mysql = mysql + ", certified_cheque =" + ((int) chkCertifiedCheque.CheckState).ToString();

					mysql = mysql + ", validity_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtValidityDate.Value) + "'";
					mysql = mysql + ", bid_amount = " + ReflectionHelper.GetPrimitiveValue<string>(txtBidAmount.Value); // Str(Format(Val(txtBidAmount.Text), "###############0.000"))
					mysql = mysql + ", bg_cc_no = " + txtBGCCNo.Text;
					mysql = mysql + ", curr_cd = " + ((mCurrCD == 0) ? " NULL " : mCurrCD.ToString());
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mysql = mysql + ", issue_date = " + ((Convert.IsDBNull(txtIssueDate.Value)) ? " NULL " : "'" + ReflectionHelper.GetPrimitiveValue<string>(txtIssueDate.Value) + "'");
					mysql = mysql + ", bank_initials = '" + txtBankInitials.Text + "'";
					mysql = mysql + ", user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where entry_id='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";

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

			//mySql = " select * from ics_bid where entry_=" & mSearchValue & "'"
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
				string mysql = "delete from ics_bid where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show("Bid Entry cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}


				//    ''''Donot allow to delete or modify the record if the information exists in the offline_transaction_details
				//    If AllowItemChange("ics_bid", mSearchValue) = False Then
				//        gConn.RollbackTrans
				//        MsgBox msg29, vbInformation
				//        deleteRecord = False
				//        Exit Function
				//    End If

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				//End If

				return true;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
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
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		public void GetRecord(object pSearchValue)
		{
			SqlDataReader rsLocalRec = null;
			object mReturnValue = null;
			string mysql = "";

			try
			{

				if (SystemProcedure2.IsItEmpty(pSearchValue, SystemVariables.DataType.StringType))
				{
					return;
				}

				//Change the form mode to edit

				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				mysql = " select * from ics_bid";
				mysql = mysql + " where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand.ExecuteReader();
				if (rsLocalRec.Read())
				{
					txtBidNo.Text = Convert.ToString(rsLocalRec["bid_no"]);
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkBankGuarantee.CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Bank_Guarantee"])) ? 1 : 0);
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkCertifiedCheque.CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Certified_Cheque"])) ? 1 : 0);
					txtValidityDate.Value = rsLocalRec["Validity_date"];
					txtBidAmount.Value = rsLocalRec["Bid_Amount"];
					txtBGCCNo.Text = Convert.ToString(rsLocalRec["bg_cc_no"]);
					txtBankInitials.Text = Convert.ToString(rsLocalRec["bank_initials"]) + "";
					if (!Convert.IsDBNull(rsLocalRec["issue_date"]))
					{
						txtIssueDate.Value = rsLocalRec["issue_date"];
					}
					else
					{
						txtIssueDate.Text = "";
					}
					mTimeStamp = Convert.ToString(rsLocalRec["time_stamp"]);
					if (!Convert.IsDBNull(rsLocalRec["curr_cd"]))
					{
						mysql = "select curr_no, " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? " a_curr_name " : " l_curr_name ");
						mysql = mysql + " from gl_currency where curr_cd = " + Convert.ToString(rsLocalRec["curr_cd"]);
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCurrencyCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCurrencyName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						}
					}
				}
				else
				{
					MessageBox.Show("No records found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				rsLocalRec.Close();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
		}

		public void findRecord()
		{ //Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9018115));
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

		private void txtBidNo_DropButtonClick(Object Sender, EventArgs e)
		{
			GetNextNumber();
		}

		private void GetNextNumber()
		{
			//Get the maximum + 1 bid code
			txtBidNo.Text = SystemProcedure2.GetNewNumber("ics_bid", "bid_no");
		}

		public bool CheckDataValidity()
		{
			bool result = false;
			DataSet rsMasterInfo = null;
			string mCheckTimeStamp = "";
			string mysql = "";

			//check validation during update and add of records
			if (SystemProcedure2.IsItEmpty(txtBidNo.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Bid code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstFocusObject.Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtBGCCNo.Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter BG/CC No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtBGCCNo.Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtValidityDate.Value, SystemVariables.DataType.DateType))
			{
				MessageBox.Show("Enter Validity date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtValidityDate.Focus();
				return false;
			}

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				//--check the timestamp value
				mysql = "select time_stamp ";
				mysql = mysql + " from ics_bid where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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

				rsMasterInfo = null;
			}

			return true;
		}

		private void txtCurrencyCode_DropButtonClick(Object Sender, EventArgs e)
		{
			string mSQL = "";
			txtCurrencyCode.Text = "";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1003000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				mSQL = " select curr_no, " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_curr_name " : " a_curr_name ");
				mSQL = mSQL + " from gl_currency where curr_cd = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCurrencyCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCurrencyName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
			}

		}

		private void txtCurrencyCode_KeyDown(Object Sender, System.Windows.Forms.TextBox.KeyDownEventArgs e)
		{
			Keys KeyCode = (Keys) e.KeyCode;
			int Shift = e.Shift;
			if (KeyCode == Keys.F2)
			{
				txtCurrencyCode_DropButtonClick(txtCurrencyCode, null);
			}
		}

		private void txtCurrencyCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			object mReturnValue = null;
			string mSQL = "";
			if (txtCurrencyCode.Text != "")
			{
				mSQL = " select curr_no, " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_curr_name " : " a_curr_name ");
				mSQL = mSQL + " from gl_currency where curr_no = '" + txtCurrencyCode.Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCurrencyCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCurrencyName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				}
				else
				{
					txtCurrencyCode.Text = "";
					txtCurrencyName.Text = "";
					MessageBox.Show("Invalid Currency!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtCurrencyCode.Focus();
					return;
				}
			}

		}
		public void PrintReport()
		{
			SystemReports.GetSystemReport(52020018, 1);
		}
	}
}