
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmFADepreciation
		: System.Windows.Forms.Form
	{

		public frmFADepreciation()
{
InitializeComponent();
} 
 public  void frmFADepreciation_old()
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


		private void frmFADepreciation_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
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

		public Control FirstFocusObject = null;
		private string mTimeStamp = "";
		public object mSearchValue = null;

		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;
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

			try
			{

				this.Top = 0;
				this.Left = 0;
				FirstFocusObject = txtDeprDate;

				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;


				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;


				SystemProcedure.SetLabelCaption(this);
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

		public bool saveRecord(bool pPostGl = false)
		{
			bool result = false;
			object mReturnValue = null;
			string mysql = "";
			SqlDataReader rsTempRec = null;
			decimal mDeprAmt = 0;
			int mLinkedEntryId = 0;
			int mDeprNo = 0;
			int mEntryId = 0;

			//On Error GoTo eFoundError

			SystemVariables.gConn.BeginTransaction();

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{

				mysql = " select voucher_date from fa_depr ";
				mysql = mysql + " where voucher_date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtDeprDate.Value) + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show(" Depreciation Date should be greater than last depreciation date : " + StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(mReturnValue), SystemVariables.gSystemDateFormat), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (ControlHelper.GetEnabled(FirstFocusObject))
					{
						FirstFocusObject.Focus();
					}
					goto mError;
				}


				mDeprNo = Convert.ToInt32(Double.Parse(SystemProcedure2.GetNewNumber("fa_depr", "voucher_no")));

				mysql = " insert into fa_depr ";
				mysql = mysql + " ( voucher_no, voucher_date, comments, user_cd )";
				mysql = mysql + " values (";
				mysql = mysql + Conversion.Str(mDeprNo);
				mysql = mysql + ", '" + ReflectionHelper.GetPrimitiveValue<string>(txtDeprDate.Value) + "'";
				mysql = mysql + ", N'" + txtComments.Text + "'";
				mysql = mysql + " ," + Conversion.Str(SystemVariables.gLoggedInUserCode);
				mysql = mysql + " ) ";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mysql = " select scope_identity() ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));

				mysql = " select * from fa_items ";
				mysql = mysql + " where status = 2 ";
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
				{
					mysql = mysql + " and posted_gl = 1 ";
				}
				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsTempRec = sqlCommand.ExecuteReader();

				if (rsTempRec.Read())
				{
					mLinkedEntryId = SystemFAProcedure.FAInsertDeprTransHeader(ReflectionHelper.GetPrimitiveValue<string>(txtDeprDate.Value), SystemFAProcedure.gFADepreciationVoucherType, true, mEntryId);
				}

				do 
				{
					//        If .Fields("asset_no") = "1002" Then
					//            Stop
					//        End If

					mDeprAmt = SystemFAProcedure.GetDeprAmount(Convert.ToInt32(rsTempRec["asset_cd"]), Convert.ToInt32(rsTempRec["depr_method_cd"]), Convert.ToDecimal(rsTempRec["depr_percent"]), Convert.ToDecimal(rsTempRec["asset_value"]), Convert.ToDecimal(rsTempRec["book_value"]), Convert.ToDateTime(rsTempRec["last_depr_date"]), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDeprDate.Value));

					mDeprAmt = (decimal) Math.Round((double) mDeprAmt, 3);
					if (mDeprAmt > 0)
					{
						SystemFAProcedure.FAInsertDeprTransDetails(mLinkedEntryId, Convert.ToInt32(rsTempRec["asset_cd"]), StringsHelper.Format(rsTempRec["last_depr_date"], SystemVariables.gSystemDateFormat), Convert.ToDecimal(rsTempRec["last_depr_amt"]), Convert.ToDecimal(rsTempRec["accumulated_depr_amt"]), Convert.ToInt32(rsTempRec["depr_method_cd"]), Convert.ToDecimal(rsTempRec["depr_percent"]), ReflectionHelper.GetPrimitiveValue<string>(txtDeprDate.Value), mDeprAmt);

						//''update the item master table
						mysql = " update fa_items ";
						mysql = mysql + " set ";
						mysql = mysql + " last_depr_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtDeprDate.Value) + "'";
						mysql = mysql + " , last_depr_amt =" + Conversion.Str(mDeprAmt);
						mysql = mysql + " , accumulated_depr_amt = accumulated_depr_amt + " + Conversion.Str(mDeprAmt);
						mysql = mysql + " where asset_cd = " + Convert.ToString(rsTempRec["asset_cd"]);
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();
					}

				}
				while(rsTempRec.Read());
			}
			else
			{
				//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);

				mysql = " update fa_depr ";
				mysql = mysql + " set ";
				mysql = mysql + " comments = N'" + txtComments.Text + "'";
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();
			}

			if (pPostGl)
			{
				PostStatus(ReflectionHelper.GetPrimitiveValue<int>(SearchValue));

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
				{
					if (!PostDepreciation(SystemFAProcedure.gFADepreciationVoucherType, mEntryId))
					{
						goto mError;
					}
				}
			}

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			result = true;
			if (ControlHelper.GetEnabled(FirstFocusObject))
			{
				FirstFocusObject.Focus();
			}
			return result;

			mError:
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			return false;



			int mReturnErrorType = 0;
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			return false;

		}

		public void PrintReport()
		{

		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool CheckDataValidity()
		{

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				if (mOldVoucherStatus == SystemVariables.VoucherStatus.stPosted)
				{ //if voucher is in posted mode
					MessageBox.Show("Voucher already posted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (mOldVoucherStatus == SystemVariables.VoucherStatus.stVoid)
				{  //if voucher is in deleted mode
					MessageBox.Show("Voucher already Void!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{

				if (!Information.IsDate(txtDeprDate.Value))
				{
					MessageBox.Show("Enter Valid Date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					FirstFocusObject.Focus();
				}
				else
				{

					if (!SystemProcedure2.ValidDateRange(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDeprDate.Value)))
					{
						MessageBox.Show("Invalid Date Range, Check the current financial year", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						FirstFocusObject.Focus();
					}
					else
					{

						if (txtComments.Text == "")
						{
							MessageBox.Show("Comments Required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtComments.Focus();
						}
						else
						{

							return true;

						}
					}
				}
			}

			return false;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmFADepreciation.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(8006000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void GetRecord(object SearchValue)
		{

			//On Error GoTo eFoundError

			string mysql = " select entry_id, voucher_no, voucher_date, comments, status ,time_stamp ";
			mysql = mysql + " from fa_depr ";
			mysql = mysql + " where entry_id = " + Conversion.Str(SearchValue);

			SqlDataReader localRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand.ExecuteReader();
			if (localRec.Read())
			{
				mSearchValue = localRec["entry_id"];
				mTimeStamp = Convert.ToString(localRec["time_stamp"]);

				//Set the form caption and Get the Voucher Status
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, frmFADepreciation.DefInstance, Convert.ToInt32(localRec["status"]), CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Depreciation " : "Depreciation ");

				txtDepreciationNo.Text = Convert.ToString(localRec["voucher_no"]);
				txtDeprDate.Value = localRec["voucher_date"];

				txtDeprDate.Enabled = false;

				if (mOldVoucherStatus == SystemVariables.VoucherStatus.stPosted)
				{
					//**--commented by : Moiz Hakimi
					//**--comment date : 15-nov-2005
					//**--Moiz Hakimipls check this line
					//btnFormToolBar(10).Enabled = True
				}
				else
				{
					//**--commented by : Moiz Hakimi
					//**--comment date : 15-nov-2005
					//**--Moiz Hakimipls check this line
					//btnFormToolBar(10).Enabled = False
				}

				txtComments.Text = Convert.ToString(localRec["comments"]) + "";


				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			}
			localRec.Close();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);

			mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
			txtDeprDate.Enabled = true;


			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			mSearchValue = "";

			if (ControlHelper.GetEnabled(FirstFocusObject))
			{
				FirstFocusObject.Focus();
			}

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool deleteRecord()
		{

			bool result = false;
			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 1);
				result = false;
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				return result;
			}

			SystemVariables.gConn.BeginTransaction();

			string mysql = " select entry_id from fa_depr ";
			mysql = mysql + " where entry_id > " + Conversion.Str(mSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				MessageBox.Show("Depreciation cannot be deleted, there are other depreciation done after this one", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{

				//''update the item master table to previous status
				mysql = " update fa_items ";
				mysql = mysql + " set ";
				mysql = mysql + " last_depr_date = dt.Last_Depr_Date ";
				mysql = mysql + " , last_depr_amt = dt.Last_Depr_amt ";
				mysql = mysql + " , accumulated_depr_amt = accumulated_depr_amt - dt.Depr_Amt ";
				mysql = mysql + " from fa_trans mt ";
				mysql = mysql + " inner join fa_trans_details dt on mt.entry_id = dt.entry_id ";
				mysql = mysql + " inner join fa_items fa on dt.asset_cd = fa.asset_cd ";
				mysql = mysql + " where mt.parent_entry_id = " + Conversion.Str(mSearchValue);
				mysql = mysql + " and mt.voucher_type =" + SystemFAProcedure.gFADepreciationVoucherType.ToString();
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();


				mysql = " delete from fa_trans_details ";
				mysql = mysql + " from fa_trans_details dt ";
				mysql = mysql + " inner join fa_trans mt on dt.entry_id = mt.entry_id ";
				mysql = mysql + " where mt.parent_entry_id = " + Conversion.Str(mSearchValue);
				mysql = mysql + " and mt.voucher_type =" + SystemFAProcedure.gFADepreciationVoucherType.ToString();
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				mysql = " delete from fa_trans ";
				mysql = mysql + " where parent_entry_id = " + Conversion.Str(mSearchValue);
				mysql = mysql + " and voucher_type =" + SystemFAProcedure.gFADepreciationVoucherType.ToString();
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();


				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					mysql = "delete from fa_depr where entry_id=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (Information.Err().Number != 0)
					{
						MessageBox.Show("Depreciation cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{

						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.CommitTrans();

						return true;

					}
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			return false;


			int mReturnErrorType = 0;
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
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

		private bool PostDepreciation(int pVoucherType, int pDeprEntryId)
		{
			int mVoucherNo = 0;
			int mDefaultGlVoucherType = 0;
			int mAccntTransEntryId = 0;
			object[, ] mArr = new object[6, 3];

			string mysql = " select dt.asset_cd, dt.Depr_Amt, mt.voucher_date ";
			mysql = mysql + " from fa_trans mt ";
			mysql = mysql + " inner join fa_trans_details dt ";
			mysql = mysql + " on mt.entry_id = dt.entry_id ";
			mysql = mysql + " where mt.parent_entry_id = " + pDeprEntryId.ToString();
			mysql = mysql + " and mt.voucher_type = " + pVoucherType.ToString();
			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();

			if (rsTempRec.Read())
			{
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mDefaultGlVoucherType = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("fa_default_gl_voucher_type"));

				mysql = " voucher_type = " + Conversion.Str(mDefaultGlVoucherType);
				mVoucherNo = Convert.ToInt32(Double.Parse(SystemProcedure2.GetNewNumber("gl_accnt_trans", "voucher_no", 0, mysql, " tablock(xlock) ")));

				mAccntTransEntryId = SystemFAProcedure.FAInsertGLHeaderEntry(mDefaultGlVoucherType, ReflectionHelper.GetPrimitiveValue<string>(txtDeprDate.Value), mVoucherNo, "", txtComments.Text, 2, SystemVariables.gLoggedInUserCode);
			}

			do 
			{
				if (SystemFAProcedure.GetFAGLLinks(mArr, Convert.ToInt32(rsTempRec["asset_cd"])))
				{
					//'''GL entry to generated as follows
					//'''     Asset Depreciation Account      Dr
					//'''         To Asset accumulated Depreciation a/c

					if (!SystemProcedure2.ValidDateRange(Convert.ToDateTime(rsTempRec["voucher_date"])))
					{

						MessageBox.Show(" Depreciation date should be in the financial year", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
					else
					{
						SystemFAProcedure.FAInsertGLDetailsEntry(mAccntTransEntryId, ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFADeprAccntCd, 0]), ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFADeprAccntCd, 1]), 1, Convert.ToDecimal(rsTempRec["Depr_Amt"]), (decimal) (1 * Convert.ToDouble(rsTempRec["Depr_Amt"])), "D", StringsHelper.Format(rsTempRec["voucher_date"], SystemVariables.gSystemDateFormat), 1, 1);

						SystemFAProcedure.FAInsertGLDetailsEntry(mAccntTransEntryId, ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFAAccumDeprAccntCd, 0]), ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFAAccumDeprAccntCd, 1]), 1, (decimal) (Convert.ToDouble(rsTempRec["Depr_Amt"]) * -1), (decimal) (1 * (Convert.ToDouble(rsTempRec["Depr_Amt"]) * -1)), "C", StringsHelper.Format(rsTempRec["voucher_date"], SystemVariables.gSystemDateFormat), 1, 1);
					}
				}
				else
				{
					//''error
					goto mError;
				}

			}
			while(rsTempRec.Read());

			mysql = " update fa_depr ";
			mysql = mysql + " set ";
			mysql = mysql + " posted_gl = 1 ";

			if (mAccntTransEntryId > 0)
			{
				mysql = mysql + " , gl_generated_voucher_type = " + Conversion.Str(mDefaultGlVoucherType);
				mysql = mysql + " , gl_generated_entry_id = " + Conversion.Str(mAccntTransEntryId);
			}
			mysql = mysql + " where entry_id = " + pDeprEntryId.ToString();
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			return true;

			mError:
			return false;

		}

		public bool Post()
		{
			bool result = false;
			DialogResult ans = (DialogResult) 0;
			frmSysOnlinePosting frmTemp = frmSysOnlinePosting.CreateInstance();

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 2);
				result = false;
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				return result;
			}


			frmTemp.ShowDialog();

			if (frmTemp.mApprove)
			{

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					ans = MessageBox.Show(SystemConstants.msg19 + "\r" + "\r" + SystemConstants.msg7, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				}
				else
				{
					ans = MessageBox.Show("                         Do you want to Post the Record ?                          " + "\r" + "\r" + "\r" + " NOTE :            Yes : To post after saving. " + "\r" + "                         No : To post without saving " + "\r" + "                         Cancel : To exit without posting ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
				}

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						goto mend;
					}
				}
				else
				{
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						goto mend;
					}
					else if (ans == System.Windows.Forms.DialogResult.No)
					{ 
						if (frmTemp.mApprove)
						{
							SystemVariables.gConn.BeginTransaction();

							PostStatus(ReflectionHelper.GetPrimitiveValue<int>(SearchValue));

							if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
							{
								if (!PostDepreciation(SystemFAProcedure.gFADepreciationVoucherType, ReflectionHelper.GetPrimitiveValue<int>(SearchValue)))
								{
									//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
									SystemVariables.gConn.RollbackTrans();
									result = false;
									goto mDestroy;
								}
							}
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.CommitTrans();
						}
					}

					result = true;
					goto mDestroy;
				}
			}

			goto mDestroy;

			mend:
			//This goto will only come if the voucherstatus is still active
			if (CheckDataValidity())
			{
				if (saveRecord(frmTemp.mApprove))
				{
					result = true;
					goto mDestroy;
				}
			}
			result = false;

			mDestroy:
			frmTemp.Close();
			return result;
		}

		public void GRoutine()
		{

			//''Check the GL module is enabled
			string mysql = " select show from SM_MODULES ";
			mysql = mysql + " where module_id = 2";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue) && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
			{
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					mysql = " select gl_generated_voucher_type, gl_generated_entry_id from fa_depr ";
					mysql = mysql + " where entry_id =" + Conversion.Str(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(0)))
						{
							if (SystemForms.GetSystemForm(310000, 2, ((Array) mReturnValue).GetValue(1), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0))))
							{
								//user has got access to the form
								//DoReportDrillDown = True
							}
							else
							{
								//access on the form is denied
								MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								//DoReportDrillDown = False
								//oReportGrid.SetFocus
							}
						}
						else
						{
							MessageBox.Show("No voucher Generated! ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
				}
			}
		}

		private void PostStatus(int pDeprEntryId)
		{

			string mysql = " update fa_depr ";
			mysql = mysql + " set ";
			mysql = mysql + " status = 2 ";
			mysql = mysql + " where entry_id = " + pDeprEntryId.ToString();
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

		}
	}
}