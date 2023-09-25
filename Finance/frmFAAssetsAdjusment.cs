
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmFAAssetsAdjusment
		: System.Windows.Forms.Form
	{

		public frmFAAssetsAdjusment()
{
InitializeComponent();
} 
 public  void frmFAAssetsAdjusment_old()
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


		private void frmFAAssetsAdjusment_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;
		private clsToolbar oThisFormToolBar = null;

		private const int conTxtVoucherNo = 0;
		private const int conTxtAssetCd = 1;
		private const int conTxtAdjustLdgrNo = 2;
		private const int conTxtAdjustCCNo = 3;

		private const int conDlblAssetName = 0;
		private const int conDlblAdjustAccountName = 1;
		private const int conDlblAdjustCCName = 2;


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
			FirstFocusObject = txtCommon[conTxtVoucherNo];

			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
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
				oThisFormToolBar.ShowGLTranButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
				{
					lblAssetsAdjustmentAccount.Visible = true;
					txtCommon[conTxtAdjustLdgrNo].Visible = true;
					txtCommonDisplay[conDlblAdjustAccountName].Visible = true;

					lblAssetsAdjustmentCostCenter.Visible = true;
					txtCommon[conTxtAdjustCCNo].Visible = true;
					txtCommonDisplay[conDlblAdjustCCName].Visible = true;
				}
				else
				{
					lblAssetsAdjustmentAccount.Visible = false;
					txtCommon[conTxtAdjustLdgrNo].Visible = false;
					txtCommonDisplay[conDlblAdjustAccountName].Visible = false;

					lblAssetsAdjustmentCostCenter.Visible = false;
					txtCommon[conTxtAdjustCCNo].Visible = false;
					txtCommonDisplay[conDlblAdjustCCName].Visible = false;
				}

				//assign a next code
				SystemProcedure.SetLabelCaption(this);
				txtCommon[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("fa_adjustment", "voucher_no");
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
				{
					SendKeys.Send("{TAB}");
					return;
				}

				if (this.ActiveControl.Name != "txtCommon")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommon#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void AddRecord()
		{

			SystemProcedure2.ClearTextBox(this);
			txtCommon[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("fa_adjustment", "voucher_no");
			txtAdjustmentAmount.Value = 0;

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
			mSearchValue = "";
			FirstFocusObject.Focus();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord(bool pPostGl = false)
		{
			bool result = false;
			int mAssetCd = 0;
			string mLdgrCd = "";
			string mCCCd = "";
			int mEntryId = 0;

			//On Error GoTo eFoundError


			string mysql = " select asset_cd from fa_items ";
			mysql = mysql + " where asset_no='" + txtCommon[conTxtAssetCd].Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mAssetCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}
			else
			{
				MessageBox.Show("Invalid Asset Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommon[conTxtAssetCd].Focus();
				goto mError;
			}

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
			{
				mysql = " select ldgr_cd from gl_ledger ";
				mysql = mysql + " where ldgr_no='" + txtCommon[conTxtAdjustLdgrNo].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLdgrCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
					{
						mysql = " select cost_cd from gl_cost_centers ";
						mysql = mysql + " where cost_no=" + txtCommon[conTxtAdjustCCNo].Text;
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mCCCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
						}
						else
						{
							MessageBox.Show("Invalid Cost Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							if (txtCommon[conTxtAdjustCCNo].Enabled)
							{
								txtCommon[conTxtAdjustCCNo].Focus();
							}
							goto mError;
						}
					}
					else
					{
						mCCCd = "NULL";
					}
				}
				else
				{
					MessageBox.Show("Invalid Account Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommon[conTxtAdjustLdgrNo].Focus();
					goto mError;
				}
			}

			SystemVariables.gConn.BeginTransaction();

			mysql = " select voucher_date from fa_depr ";
			mysql = mysql + " where voucher_date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtAdjustmentDate.Value) + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				MessageBox.Show(" Adjustment Date should be greater than last depreciation date : " + StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(mReturnValue), SystemVariables.gSystemDateFormat), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (txtAdjustmentDate.Enabled)
				{
					txtAdjustmentDate.Focus();
				}
				return false;
			}

			string mCheckTimeStamp = "";
			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				mysql = " insert into fa_adjustment ";
				mysql = mysql + " (voucher_no, voucher_date, asset_cd, adjustment_accnt_cd, adjustment_cc_cd ";
				mysql = mysql + " , voucher_amt, remarks, user_cd) ";
				mysql = mysql + " values( ";
				mysql = mysql + txtCommon[conTxtVoucherNo].Text;
				mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtAdjustmentDate.Value) + "'";
				mysql = mysql + " , " + mAssetCd.ToString();
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
				{
					mysql = mysql + " , '" + mLdgrCd + "'";
					mysql = mysql + " , " + mCCCd;
				}
				else
				{
					mysql = mysql + " , NULL ";
					mysql = mysql + " , NULL ";
				}
				mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtAdjustmentAmount.Value);
				mysql = mysql + " , N'" + txtRemarks.Text + "'";
				mysql = mysql + " , " + Conversion.Str(SystemVariables.gLoggedInUserCode);
				mysql = mysql + " )";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mysql = "select scope_identity()";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));

			}
			else
			{
				//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);

				mysql = " select time_stamp from fa_adjustment where entry_id =" + mEntryId.ToString();
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

				mysql = " update fa_adjustment set ";
				mysql = mysql + " voucher_date= '" + ReflectionHelper.GetPrimitiveValue<string>(txtAdjustmentDate.Value) + "'";
				mysql = mysql + " , asset_cd =" + mAssetCd.ToString();
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
				{
					mysql = mysql + " , adjustment_accnt_cd ='" + mLdgrCd + "'";
					mysql = mysql + " , adjustment_cc_cd =" + mCCCd;
				}
				mysql = mysql + " , voucher_amt =" + ReflectionHelper.GetPrimitiveValue<string>(txtAdjustmentAmount.Value);
				mysql = mysql + " , remarks = N'" + txtRemarks.Text + "'";
				mysql = mysql + " , user_cd =" + SystemVariables.gLoggedInUserCode.ToString();
				mysql = mysql + " where entry_id =" + mEntryId.ToString();
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

			}

			if (pPostGl)
			{
				if (!PostAdjustment(mEntryId))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					goto mError;
				}
			}

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			result = true;
			FirstFocusObject.Focus();
			return result;

			mError:
			return false;


			int mReturnErrorType = 0;
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			return false;
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

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "delete from fa_adjustment where entry_id=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Asset Adjustment cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();


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
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			try
			{
				string mysql = "";
				object mReturnValue = null;
				SqlDataReader localRec = null;

				mysql = " select fadj.* ";
				mysql = mysql + " , fa.asset_no ";
				mysql = mysql + " , fa.l_asset_name , fa.a_asset_name ";
				mysql = mysql + " , gl_ledger.ldgr_no ";
				mysql = mysql + " , gl_ledger.l_ldgr_name , gl_ledger.a_ldgr_name ";
				mysql = mysql + " , cc.cost_no ";
				mysql = mysql + " , cc.l_cost_name , cc.a_cost_name ";
				mysql = mysql + " from fa_adjustment fadj ";
				mysql = mysql + " inner join fa_items fa on fadj.asset_cd = fa.asset_cd ";
				mysql = mysql + " left join gl_ledger on fadj.adjustment_accnt_cd = gl_ledger.ldgr_cd ";
				mysql = mysql + " left join gl_cost_centers cc on fadj.adjustment_cc_cd = cc.cost_cd ";
				mysql = mysql + " where entry_id= " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{

					mSearchValue = localRec["entry_id"];
					mTimeStamp = Convert.ToString(localRec["time_stamp"]);

					txtCommon[conTxtVoucherNo].Text = Convert.ToString(localRec["voucher_no"]);
					txtAdjustmentDate.Value = localRec["voucher_date"];

					txtCommon[conTxtAssetCd].Text = Convert.ToString(localRec["asset_no"]);
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						txtCommonDisplay[conDlblAssetName].Text = Convert.ToString(localRec["l_asset_name"]);
					}
					else
					{
						txtCommonDisplay[conDlblAssetName].Text = Convert.ToString(localRec["a_asset_name"]);
					}


					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
					{
						txtCommon[conTxtAdjustLdgrNo].Text = Convert.ToString(localRec["ldgr_no"]) + "";
						txtCommon[conTxtAdjustCCNo].Text = Convert.ToString(localRec["cost_no"]) + "";

						if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
						{
							txtCommonDisplay[conDlblAdjustAccountName].Text = Convert.ToString(localRec["l_ldgr_name"]) + "";
							txtCommonDisplay[conDlblAdjustCCName].Text = Convert.ToString(localRec["l_cost_name"]) + "";
						}
						else
						{
							txtCommonDisplay[conDlblAdjustAccountName].Text = Convert.ToString(localRec["a_ldgr_name"]);
							txtCommonDisplay[conDlblAdjustCCName].Text = Convert.ToString(localRec["a_cost_name"]) + "";
						}
					}

					txtAdjustmentAmount.Value = localRec["voucher_amt"];
					txtRemarks.Text = Convert.ToString(localRec["remarks"]) + "";

					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
					SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, frmFAAssetsAdjusment.DefInstance, Convert.ToInt32(localRec["status"]), CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Asset Adjustment" : "Asset Adjustment");

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

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(8008000));
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
				goto mError;
			}

			if (!Information.IsNumeric(txtCommon[conTxtVoucherNo].Text))
			{
				MessageBox.Show("Enter Adjustment Voucher No", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstFocusObject.Focus();
				goto mError;
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[conTxtAssetCd].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Asset Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommon[conTxtAssetCd].Focus();
				goto mError;
			}

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
			{
				if (SystemProcedure2.IsItEmpty(txtCommon[conTxtAdjustLdgrNo].Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Adjustment Account Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommon[conTxtAdjustLdgrNo].Focus();
					goto mError;
				}

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
				{
					if (SystemProcedure2.IsItEmpty(txtCommon[conTxtAdjustLdgrNo].Text, SystemVariables.DataType.StringType))
					{
						MessageBox.Show("Enter Adjustment Cost Center Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommon[conTxtAdjustLdgrNo].Focus();
						goto mError;
					}
				}
			}

			if (!Information.IsDate(txtAdjustmentDate.Value))
			{
				MessageBox.Show("Enter Adjustment Date ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtAdjustmentDate.Focus();
			}
			else
			{

				if (ReflectionHelper.GetPrimitiveValue<double>(txtAdjustmentAmount.Value) == 0)
				{
					MessageBox.Show("Enter Adjustment Amount", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtAdjustmentAmount.Focus();
				}
				else
				{



					return true;

				}
			}
			mError:
			return false;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				oThisFormToolBar = null;
				UserAccess = null;
				frmFAAssetsAdjusment.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtGradeNo_DropButtonClick()
		{
			//Get the maximum + 1 ICS_Item_category code
			GetNextNumber();
		}

		public void FindRoutine(string pObjectName)
		{

			object mTempSearchValue = null;
			string mFilterCondition = "";

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mObjectIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));
			if (mObjectName == "txtCommon")
			{
				txtCommon[mObjectIndex].Text = "";
				switch(mObjectIndex)
				{
					case conTxtAdjustLdgrNo : 
						mFilterCondition = " type_cd =" + SystemGLConstants.gGLCustomerVendorTypeCode.ToString(); 
						//mFilterCondition = mFilterCondition & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" & ")" 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFilterCondition)); 
						break;
					case conTxtAssetCd : 
						mFilterCondition = " status = 2 "; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(8004000, "1137", mFilterCondition)); 
						break;
					case conTxtAdjustCCNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000110, "882")); 
						break;
					default:
						return;
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommon[mObjectIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtCommon_Leave(txtCommon[mObjectIndex], new EventArgs());
				}
			}

		}

		public void GetNextNumber()
		{
			//txtGradeNo.Text = GetNewNumber("Pay_Grade", "Grade_No")
			//FirstFocusObject.SetFocus
		}

		private void txtCommon_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);
			FindRoutine("txtCommon#" + Index.ToString().Trim());
		}

		private void txtCommon_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommon, eventSender);

			object mTempValue = null;
			string mysql = "";
			int mLinkedTextBoxIndex = 0;

			try
			{
				switch(Index)
				{
					case conTxtAdjustLdgrNo : 
						mysql = "select l_ldgr_name, a_ldgr_name, ldgr_cd from gl_ledger where show = 1 and ldgr_no='" + txtCommon[Index].Text + "'"; 
						mysql = mysql + " and ( type_cd = " + SystemGLConstants.gGLCustomerVendorTypeCode.ToString() + ")"; 
						 
						mLinkedTextBoxIndex = conDlblAdjustAccountName; 
						break;
					case conTxtAssetCd : 
						mysql = "select fa.l_asset_name, fa.a_asset_name , fa.asset_cd  "; 
						mysql = mysql + " , gl_ledger.ldgr_no , gl_ledger.l_ldgr_name, gl_ledger.a_ldgr_name "; 
						mysql = mysql + " , cc.cost_no , cc.l_cost_name , cc.a_cost_name "; 
						mysql = mysql + " , fa.last_depr_date "; 
						mysql = mysql + " from fa_items fa "; 
						mysql = mysql + " left join gl_ledger on fa.adjustment_accnt_cd = gl_ledger.ldgr_cd"; 
						mysql = mysql + " left join gl_cost_centers cc on fa.adjustment_cc_cd = cc.cost_cd"; 
						mysql = mysql + " where fa.asset_no='" + txtCommon[Index].Text + "'"; 
						mysql = mysql + " and status = 2 "; 
						mLinkedTextBoxIndex = conDlblAssetName; 
						break;
					case conTxtAdjustCCNo : 
						mysql = "select l_cost_name, a_cost_name, cost_cd from gl_cost_centers where show = 1 and cost_no=" + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conDlblAdjustCCName; 
						break;
					default:
						return;
				}

				if (!SystemProcedure2.IsItEmpty(txtCommon[Index].Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtCommonDisplay[mLinkedTextBoxIndex].Text = "";
						txtCommon[Index].Tag = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						txtCommonDisplay[mLinkedTextBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1));
						txtCommon[Index].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));

						if (Index == conTxtAssetCd)
						{
							txtAdjustmentDate.Value = ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mTempValue).GetValue(9)).AddDays(1);


							txtCommon[conTxtAdjustLdgrNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3)) + "";
							txtCommon[conTxtAdjustCCNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(6)) + "";
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								txtCommonDisplay[conDlblAdjustAccountName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4)) + "";
								txtCommonDisplay[conDlblAdjustCCName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(7)) + "";
							}
							else
							{
								txtCommonDisplay[conDlblAdjustAccountName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(5)) + "";
								txtCommonDisplay[conDlblAdjustCCName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(8)) + "";
							}

							//If mTempValue(9) = True Then
							txtCommon[conTxtAdjustCCNo].Enabled = true;
							//Else
							//    txtCommon(conTxtAdjustCCNo).Enabled = False
							//    txtCommon(conTxtAdjustCCNo).Text = ""
							//    txtCommonDisplay(conDlblAdjustCCName).Text = ""
							//End If
						}

						if (Index == conTxtAdjustLdgrNo)
						{
							if (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mTempValue).GetValue(3)))
							{
								txtCommon[conTxtAdjustCCNo].Enabled = true;
							}
							else
							{
								txtCommon[conTxtAdjustCCNo].Enabled = false;
								txtCommon[conTxtAdjustCCNo].Text = "";
								txtCommonDisplay[conDlblAdjustCCName].Text = "";
							}
						}
					}
				}
				else
				{
					txtCommonDisplay[mLinkedTextBoxIndex].Text = "";
					txtCommon[Index].Tag = "";
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
					//if the code is not found
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
					try
					{
						txtCommon[Index].Focus();
					}
					catch (Exception exc)
					{
						NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
					}
				}
				else
				{
					//
				}
			}

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

							if (!PostAdjustment(ReflectionHelper.GetPrimitiveValue<int>(SearchValue)))
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								result = false;
								goto mDestroy;
							}
							else
							{
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

		private bool PostAdjustment(int pEntryId)
		{
			object[, ] mArr = new object[6, 3];
			object mDefaultGlVoucherType = null;
			int mVoucherNo = 0;
			int mVoucherEntryId = 0;
			int mTransEntryID = 0;


			//''''GL entry to generated as follows
			//    Asset Adjustment Account        Dr
			//           To Asset Debit a/c


			string mysql = " select fadj.* ";
			mysql = mysql + " , fa.last_depr_date , fa.last_depr_amt ";
			mysql = mysql + " , fa.accumulated_depr_amt , fa.depr_method_cd , fa.depr_percent ";
			mysql = mysql + " , fa.book_value ";
			mysql = mysql + " from fa_adjustment fadj ";
			mysql = mysql + " inner join fa_items fa on fadj.asset_cd = fa.asset_cd";
			mysql = mysql + " where entry_id =" + pEntryId.ToString();
			DataSet rsTempRec = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsTempRec.Tables.Clear();
			adap.Fill(rsTempRec);

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (SystemFAProcedure.GetFAGLLinks(mArr, Convert.ToInt32(rsTempRec.Tables[0].Rows[0]["asset_cd"])))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["book_value"]) - Math.Abs(Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["voucher_amt"])) <= 0)
					{
						MessageBox.Show("BookValue cannot be negative ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}

					//''if the purchase date is within the financial year
					//''then only generate the GL entry.
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (!SystemProcedure2.ValidDateRange(Convert.ToDateTime(rsTempRec.Tables[0].Rows[0]["voucher_date"])))
					{

						MessageBox.Show(" Adjustment date should be in the financial year", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mDefaultGlVoucherType = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetSystemPreferenceSetting("fa_default_gl_voucher_type"));

						mysql = " voucher_type = " + Conversion.Str(mDefaultGlVoucherType);
						mVoucherNo = Convert.ToInt32(Double.Parse(SystemProcedure2.GetNewNumber("gl_accnt_trans", "voucher_no", 0, mysql, " tablock(xlock) ")));

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mVoucherEntryId = SystemFAProcedure.FAInsertGLHeaderEntry(ReflectionHelper.GetPrimitiveValue<int>(mDefaultGlVoucherType), StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat), mVoucherNo, Convert.ToString(rsTempRec.Tables[0].Rows[0]["voucher_no"]), Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsTempRec.Tables[0].Rows[0]["remarks"] : rsTempRec.Tables[0].Rows[0]["remarks"]), 2, SystemVariables.gLoggedInUserCode);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["voucher_amt"]) > 0)
						{
							//'''Asset Debit a/c                 Dr
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFADebitAccntCd, 0]), (SystemProcedure2.IsItEmpty(mArr[SystemFAProcedure.gFADebitAccntCd, 1], SystemVariables.DataType.NumberType)) ? "NULL" : ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFADebitAccntCd, 1]), 1, (decimal) Math.Abs(Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["voucher_amt"])), (decimal) Math.Abs(Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["voucher_amt"])), "D", StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat), 1, 1);

							//''''Asset Adjustment Account        Cr
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, Convert.ToString(rsTempRec.Tables[0].Rows[0]["adjustment_accnt_cd"]), (rsTempRec.Tables[0].Rows[0].IsNull("adjustment_cc_cd")) ? "NULL" : Convert.ToString(rsTempRec.Tables[0].Rows[0]["adjustment_cc_cd"]), 1, (decimal) (Math.Abs(Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["voucher_amt"])) * -1), (decimal) (Math.Abs(Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["voucher_amt"])) * -1), "C", StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat), 1, 1);

						}
						else
						{
							//''''Asset Adjustment Account        Dr
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, Convert.ToString(rsTempRec.Tables[0].Rows[0]["adjustment_accnt_cd"]), (rsTempRec.Tables[0].Rows[0].IsNull("adjustment_cc_cd")) ? "NULL" : Convert.ToString(rsTempRec.Tables[0].Rows[0]["adjustment_cc_cd"]), 1, (decimal) Math.Abs(Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["voucher_amt"])), 0, "D", StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat), 1, 1);


							//           To Asset Debit a/c
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFADebitAccntCd, 0]), (SystemProcedure2.IsItEmpty(mArr[SystemFAProcedure.gFADebitAccntCd, 1], SystemVariables.DataType.NumberType)) ? "NULL" : ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFADebitAccntCd, 1]), 1, (decimal) (Math.Abs(Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["voucher_amt"])) * -1), (decimal) (Math.Abs(Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["voucher_amt"])) * -1), "C", StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat), 1, 1);
						}
					}
				}
				else
				{
					return false;
				}
			}

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mTransEntryID = SystemFAProcedure.FAInsertDeprTransHeader(StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat), SystemFAProcedure.gFAAdjustmentVoucherType, true, pEntryId);


			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			SystemFAProcedure.FAInsertDeprTransDetails(mTransEntryID, Convert.ToInt32(rsTempRec.Tables[0].Rows[0]["asset_cd"]), StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["last_depr_date"], SystemVariables.gSystemDateFormat), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["last_depr_amt"]), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["accumulated_depr_amt"]), Convert.ToInt32(rsTempRec.Tables[0].Rows[0]["depr_method_cd"]), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["depr_percent"]), StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["voucher_amt"]));


			mysql = " update fa_items set ";
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " adjusted_value = adjusted_value + " + Conversion.Str(Math.Abs(Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["voucher_amt"])));
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " , last_adjustment_date ='" + StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat) + "'";
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " where asset_cd =" + Convert.ToString(rsTempRec.Tables[0].Rows[0]["asset_cd"]);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = " update fa_adjustment ";
			mysql = mysql + " set ";
			mysql = mysql + "   status = 2 ";
			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
			{
				mysql = mysql + " , posted_gl = 1 ";
				mysql = mysql + " , gl_generated_voucher_type =" + ReflectionHelper.GetPrimitiveValue<string>(mDefaultGlVoucherType);
				mysql = mysql + " , gl_generated_entry_id =" + mVoucherEntryId.ToString();
			}
			mysql = mysql + " where entry_id =" + pEntryId.ToString();
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();


			rsTempRec = null;
			return true;
		}

		public void GRoutine()
		{

			//''Check the GL module is enabled
			string mysql = " select show from SM_MODULES ";
			mysql = mysql + " where module_id = 2";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
			{
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					mysql = " select gl_generated_voucher_type, gl_generated_entry_id from fa_adjustment ";
					mysql = mysql + " where entry_id =" + Conversion.Str(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						if (SystemForms.GetSystemForm(310000, 2, ((Array) mReturnValue).GetValue(1), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0))))
						{
						}
						else
						{
							MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						}

					}
				}
			}
		}
	}
}