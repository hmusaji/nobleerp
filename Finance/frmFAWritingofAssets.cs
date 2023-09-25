
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmFAWritingofAssets
		: System.Windows.Forms.Form
	{

		public frmFAWritingofAssets()
{
InitializeComponent();
} 
 public  void frmFAWritingofAssets_old()
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


		private void frmFAWritingofAssets_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		private string mTimeStamp = "";

		private int mThisFormID = 0;
		private object mSearchValue = null;
		private clsToolbar oThisFormToolBar = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;

		private const int conDlblAssetName = 0;
		private const int conDlblPurchaseDate = 1;
		private const int conDlblLastDeprDate = 2;
		private const int conDlblLastAdjustmentDate = 3;
		private const int conDlblLastWriteOffDate = 4;
		private const int conDlblInvoiceAmt = 5;
		private const int conDlblAccumDeprAmt = 6;
		private const int conDlblLastAdjustmentAmt = 7;
		private const int conDlblLastWriteoffAmt = 8;
		private const int conDlblBookValue = 9;
		private const int conDlblLedgerName = 10;
		private const int conDlblCurrentAssetValue = 11;

		private const int conTxtAssetCd = 0;
		private const int conTxtLdgrNo = 1;
		private const int conTxtComments = 2;
		private const int conTxtTransactionNo = 3;

		private const int conNumWoffQty = 0;
		private const int conNumWoffAmt = 1;
		private const int conNumWoffDeprAmt = 2;
		private const int conNumSellingAmt = 3;
		private const int conNumDeprAmt = 4;
		private const int conNumActualWoffAmt = 5;
		private const int conNumExchangeRate = 6;

		private string cLastDeprDate = "";
		private int cWoffQty = 0;
		int cRemainingQty = 0;



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
			FirstFocusObject = txtCommon[conTxtAssetCd];

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
				//
				//
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture
				//Set btnFormToolBar(9).Picture = frmSysMain.imlSystemIcons.ListImages("imgPostingTransactions").Picture
				//Set btnFormToolBar(10).Picture = frmSysMain.imlMainToolBar.ListImages("imgReplacementProduct").Picture
				//
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
				//On Keydown navigate the form by using enter key
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
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
			SystemProcedure2.ClearNumberBox(this);

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Writeoff Asset" : "Writeoff Asset");
			mSearchValue = "";

			EnableDisableControl(true);

			if (ControlHelper.GetEnabled(FirstFocusObject))
			{
				FirstFocusObject.Focus();
			}

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord(bool pPostGl = false)
		{
			bool result = false;
			object mReturnValue = null;
			int mAssetCd = 0;
			int mTransNo = 0;
			string mLdgrCd = "";
			int mCurrCD = 0;
			int mEntryId = 0;


			//On Error GoTo eFoundError

			string mysql = " select * from fa_items ";
			mysql = mysql + " where asset_no='" + txtCommon[conTxtAssetCd].Text + "'";

			DataSet rsTempRec = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsTempRec.Tables.Clear();
			adap.Fill(rsTempRec);
			if (rsTempRec.Tables[0].Rows.Count != 0)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mAssetCd = Convert.ToInt32(rsTempRec.Tables[0].Rows[0]["asset_cd"]);
			}
			else
			{
				MessageBox.Show("Invalid Asset Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto mError;
			}

			mysql = " select ldgr_cd, curr_cd from gl_ledger ";
			mysql = mysql + " where ldgr_no='" + txtCommon[conTxtLdgrNo].Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mLdgrCd = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrCD = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
			}
			else
			{
				MessageBox.Show("Invalid Ledger Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto mError;
			}


			SystemVariables.gConn.BeginTransaction();
			string mCheckTimeStamp = "";
			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{

				mysql = " select max(voucher_date) from fa_depr ";
				mysql = mysql + " where voucher_date > '" + ReflectionHelper.GetPrimitiveValue<string>(txtWriteoffDate.Value) + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show(" Writeoff Date should be greater than last depreciation date : " + StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(mReturnValue), SystemVariables.gSystemDateFormat), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (ControlHelper.GetEnabled(FirstFocusObject))
					{
						FirstFocusObject.Focus();
					}
					goto mError;
				}

				mTransNo = Convert.ToInt32(Double.Parse(SystemProcedure2.GetNewNumber("fa_writeoff", "transaction_No")));

				//        If Not IsNull(.Fields("writeoff_date")) Then
				//            If .Fields("writeoff_date") <= txtWriteoffDate.Value Then
				//                gConn.RollbackTrans
				//                MsgBox " Writeoff date should be greater than last writeoff date", vbInformation
				//                If txtWriteoffDate.Enabled = True Then
				//                    txtWriteoffDate.SetFocus
				//                End If
				//                GoTo mError
				//            End If
				//        End If

				mysql = " insert into fa_writeoff ";
				mysql = mysql + " (transaction_no, asset_cd, locat_cd, qty, voucher_amt_lc, depr_method_cd ";
				mysql = mysql + " , depr_percent, last_depr_date, last_depr_amt, accumulated_depr_amt, last_adjustment_date ";
				mysql = mysql + " , adjusted_value, last_writeoff_date, last_writeoff_qty, last_writeoff_value ";
				mysql = mysql + " , writeoff_date, writeoff_qty, writeoff_amt, depr_amt, writeoff_depr_amt ";
				mysql = mysql + " , actual_writeoff_amt, ledger_accnt_cd ";
				mysql = mysql + " , curr_cd, selling_amt_fc, exchange_rate, comments ";
				mysql = mysql + " , user_cd) ";
				mysql = mysql + " values ( ";
				mysql = mysql + Conversion.Str(mTransNo);
				mysql = mysql + ", " + mAssetCd.ToString();
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + ", " + Convert.ToString(rsTempRec.Tables[0].Rows[0]["locat_cd"]);
				mysql = mysql + ", " + cWoffQty.ToString();
				mysql = mysql + ", " + StringsHelper.Format(txtCommonDisplay[conDlblInvoiceAmt].Text, "############0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + ", " + Convert.ToString(rsTempRec.Tables[0].Rows[0]["depr_method_cd"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + ", " + Convert.ToString(rsTempRec.Tables[0].Rows[0]["depr_percent"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + ", '" + StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["last_depr_date"], SystemVariables.gSystemDateFormat) + "'";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + ", " + Convert.ToString(rsTempRec.Tables[0].Rows[0]["last_depr_amt"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + ", " + Convert.ToString(rsTempRec.Tables[0].Rows[0]["accumulated_depr_amt"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!rsTempRec.Tables[0].Rows[0].IsNull("last_adjustment_date"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + ", '" + StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["last_adjustment_date"], SystemVariables.gSystemDateFormat) + "'";
				}
				else
				{
					mysql = mysql + ", NULL ";
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + ", " + Convert.ToString(rsTempRec.Tables[0].Rows[0]["adjusted_value"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (rsTempRec.Tables[0].Rows[0].IsNull("writeoff_date"))
				{
					mysql = mysql + ", NULL ";
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + ", '" + StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["writeoff_date"], SystemVariables.gSystemDateFormat) + "'";
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + ", " + Convert.ToString(rsTempRec.Tables[0].Rows[0]["writeoff_qty"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + ", " + Convert.ToString(rsTempRec.Tables[0].Rows[0]["writeoff_value"]);
				mysql = mysql + ", '" + ReflectionHelper.GetPrimitiveValue<string>(txtWriteoffDate.Value) + "'";
				mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumWoffQty].Value);
				mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumWoffAmt].Value);
				mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumDeprAmt].Value);
				mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumWoffDeprAmt].Value);
				mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumActualWoffAmt].Value);
				mysql = mysql + ", '" + mLdgrCd + "'";
				mysql = mysql + ", " + mCurrCD.ToString();
				mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumSellingAmt].Value);
				mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumExchangeRate].Value);
				mysql = mysql + ", N'" + txtCommon[conTxtComments].Text + "'";
				mysql = mysql + ", " + SystemVariables.gLoggedInUserCode.ToString();
				mysql = mysql + " ) ";

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));

			}
			else
			{
				//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);

				mysql = " select time_stamp from fa_writeoff where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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
					if (ControlHelper.GetEnabled(FirstFocusObject))
					{
						FirstFocusObject.Focus();
					}
					return result;
				}

				mysql = " update fa_writeoff set ";
				mysql = mysql + " writeoff_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtWriteoffDate.Value) + "'";
				mysql = mysql + " , writeoff_qty =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumWoffQty].Value);
				mysql = mysql + " , writeoff_amt =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumWoffAmt].Value);
				mysql = mysql + " , depr_amt =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumDeprAmt].Value);
				mysql = mysql + " , writeoff_depr_amt =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumWoffDeprAmt].Value);
				mysql = mysql + " , actual_writeoff_amt =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumActualWoffAmt].Value);
				mysql = mysql + " , ledger_accnt_cd ='" + mLdgrCd + "'";
				mysql = mysql + " , curr_cd =" + mCurrCD.ToString();
				mysql = mysql + " , selling_amt_fc =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumSellingAmt].Value);
				mysql = mysql + " , exchange_rate =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNumExchangeRate].Value);
				mysql = mysql + " , comments = N'" + txtCommon[conTxtComments].Text + "'";
				mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
				mysql = mysql + " where entry_id =" + mEntryId.ToString();

				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();
			}


			if (pPostGl)
			{
				if (!PostWriteoff(mEntryId))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					goto mError;
				}
			}

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();


			return true;
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
				string mysql = "delete from fa_writeoff where entry_id=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Asset Writeoff cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

			//On Error GoTo eFoundError

			string mysql = " select faWoff.*, fa.asset_no, fa.l_asset_name, fa.a_asset_name ";
			mysql = mysql + " , gl_ledger.ldgr_no, gl_ledger.l_ldgr_name, gl_ledger.a_ldgr_name ";
			mysql = mysql + " from fa_writeoff faWoff ";
			mysql = mysql + " inner join fa_items fa on fawoff.asset_cd = fa.asset_cd ";
			mysql = mysql + " inner join gl_ledger on fawoff.ledger_accnt_cd = gl_ledger.ldgr_cd ";
			mysql = mysql + " where faWoff.entry_id= " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

			DataSet localRec = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			localRec.Tables.Clear();
			adap.Fill(localRec);
			if (localRec.Tables[0].Rows.Count != 0)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mSearchValue = localRec.Tables[0].Rows[0]["entry_id"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mTimeStamp = Convert.ToString(localRec.Tables[0].Rows[0]["time_stamp"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conTxtTransactionNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["transaction_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conTxtAssetCd].Text = Convert.ToString(localRec.Tables[0].Rows[0]["asset_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conTxtLdgrNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["ldgr_no"]);

				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblLedgerName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["l_ldgr_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblAssetName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["l_asset_name"]);
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblLedgerName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["a_ldgr_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblAssetName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["a_asset_name"]);
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				cWoffQty = Convert.ToInt32(localRec.Tables[0].Rows[0]["qty"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDisplay[conDlblInvoiceAmt].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["voucher_amt_lc"], "###,###,###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtWriteoffDate.Value = localRec.Tables[0].Rows[0]["writeoff_date"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				cLastDeprDate = Convert.ToString(localRec.Tables[0].Rows[0]["last_depr_date"]); //''Last Depr. Date

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNumWoffQty].Value = localRec.Tables[0].Rows[0]["writeoff_qty"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNumWoffAmt].Value = localRec.Tables[0].Rows[0]["writeoff_amt"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNumDeprAmt].Value = localRec.Tables[0].Rows[0]["depr_amt"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNumWoffDeprAmt].Value = localRec.Tables[0].Rows[0]["writeoff_depr_amt"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNumActualWoffAmt].Value = localRec.Tables[0].Rows[0]["actual_writeoff_amt"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNumSellingAmt].Value = localRec.Tables[0].Rows[0]["selling_amt_fc"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNumExchangeRate].Value = localRec.Tables[0].Rows[0]["exchange_rate"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conTxtComments].Text = Convert.ToString(localRec.Tables[0].Rows[0]["comments"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDisplay[conDlblLastDeprDate].Text = Convert.ToString(localRec.Tables[0].Rows[0]["last_depr_date"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDisplay[conDlblAccumDeprAmt].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["accumulated_depr_amt"], "###,###,###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!localRec.Tables[0].Rows[0].IsNull("last_writeoff_date"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblLastWriteOffDate].Text = Convert.ToString(localRec.Tables[0].Rows[0]["last_writeoff_date"]);
				}
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDisplay[conDlblLastWriteoffAmt].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["last_writeoff_value"], "###,###,###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDisplay[conDlblBookValue].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["book_value"], "###,###,###,###,##0.000");

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!localRec.Tables[0].Rows[0].IsNull("last_adjustment_date"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblLastAdjustmentDate].Text = Convert.ToString(localRec.Tables[0].Rows[0]["last_adjustment_date"]);
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDisplay[conDlblLastAdjustmentAmt].Text = Convert.ToString(localRec.Tables[0].Rows[0]["adjusted_value"]);

				EnableDisableControl(false);


				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, Convert.ToInt32(localRec.Tables[0].Rows[0]["status"]), CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Writeoff Asset" : "Writeoff Asset");

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
			localRec = null;

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void PrintReport()
		{

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(8007000));
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
			}
			else
			{

				if (SystemProcedure2.IsItEmpty(txtCommon[conTxtAssetCd].Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Asset Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (txtCommon[conTxtAssetCd].Enabled)
					{
						txtCommon[conTxtAssetCd].Focus();
					}
				}
				else
				{

					if (!Information.IsDate(txtWriteoffDate.Value))
					{
						MessageBox.Show("Enter Writeoff Date ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						if (txtWriteoffDate.Enabled)
						{
							txtWriteoffDate.Focus();
						}
					}
					else
					{

						if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtWriteoffDate.Value) < DateTime.Parse(cLastDeprDate))
						{
							MessageBox.Show("Writeoff date should be greater than last depreciation date : " + StringsHelper.Format(cLastDeprDate, SystemVariables.gSystemDateFormat), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							if (txtWriteoffDate.Enabled)
							{
								txtWriteoffDate.Focus();
							}
						}
						else
						{

							if (SystemProcedure2.IsItEmpty(txtCommonNumber[conNumWoffAmt].Value, SystemVariables.DataType.NumberType))
							{
								MessageBox.Show("Actual Writeoff Amount should be greater than Zero", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
								if (txtCommonNumber[conNumActualWoffAmt].Enabled)
								{
									txtCommonNumber[conNumActualWoffAmt].Focus();
								}
							}
							else
							{

								//If IsItEmpty(txtCommonNumber(conNumWoffQty).Value, NumberType) Then
								//    MsgBox "Writeoff Quantity should be greater than Zero", vbInformation, "Required"
								//    If txtCommonNumber(conNumWoffQty).Enabled = True Then
								//        txtCommonNumber(conNumWoffQty).SetFocus
								//    End If
								//    GoTo mError
								//End If

								if (ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNumActualWoffAmt].Value) > Conversion.Val(StringsHelper.Format(txtCommonDisplay[conDlblBookValue].Text, "###############0.000")))
								{
									MessageBox.Show("Actual writeoff amount cannot be greater than bookvalue ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
									if (txtCommonNumber[conNumWoffAmt].Enabled)
									{
										txtCommonNumber[conNumWoffAmt].Focus();
									}
								}
								else
								{

									if (SystemProcedure2.IsItEmpty(txtCommon[conTxtLdgrNo].Text, SystemVariables.DataType.StringType))
									{
										MessageBox.Show("Enter Account Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
										if (txtCommon[conTxtLdgrNo].Enabled)
										{
											txtCommon[conTxtLdgrNo].Focus();
										}
									}
									else
									{


										return true;

									}
								}
							}
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
				frmFAWritingofAssets.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
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
					case conTxtLdgrNo : 
						mFilterCondition = " ( type_cd = " + SystemGLConstants.gGLCustomerVendorTypeCode.ToString().Substring(0, Math.Min(4, SystemGLConstants.gGLCustomerVendorTypeCode.ToString().Length)) + ")"; 
						//mFilterCondition = mFilterCondition & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" & ")" 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFilterCondition)); 
						break;
					case conTxtAssetCd : 
						mFilterCondition = " status = 2 "; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(8004000, "1137", mFilterCondition)); 
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
					case conTxtLdgrNo : 
						mysql = "select l_ldgr_name, a_ldgr_name, ldgr_cd, curr_cd from gl_ledger where show = 1 and ldgr_no='" + txtCommon[Index].Text + "'"; 
						mysql = mysql + " and ( type_cd = " + SystemGLConstants.gGLCustomerVendorTypeCode.ToString() + ")"; 
						//mySql = mySql & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" & ")" 
						 
						mLinkedTextBoxIndex = conDlblLedgerName; 
						break;
					case conTxtAssetCd : 
						mysql = "select l_asset_name, a_asset_name , asset_cd  "; 
						mysql = mysql + " , voucher_date , asset_value, last_depr_date, accumulated_depr_amt "; 
						mysql = mysql + " , last_adjustment_date , adjusted_value "; 
						mysql = mysql + " , writeoff_date, writeoff_value , book_value "; 
						mysql = mysql + " , qty, writeoff_qty "; 
						mysql = mysql + " from fa_items where asset_no='" + txtCommon[Index].Text + "'"; 
						mysql = mysql + " and status = 2 "; 
						mLinkedTextBoxIndex = conDlblAssetName; 
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
						//txtCommon(Index).Tag = ""

						cLastDeprDate = "";
						cWoffQty = 0;

						throw new System.Exception("-9990002");
					}
					else
					{
						txtCommonDisplay[mLinkedTextBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1));
						//txtCommon(Index).Tag = mTempValue(2)

						if (Index == conTxtLdgrNo)
						{
							if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(3)) == SystemGLConstants.gDefaultCurrencyCd)
							{
								txtCommonNumber[conNumExchangeRate].Value = 1;
								txtCommonNumber[conNumExchangeRate].Enabled = false;
							}
							else
							{
								txtCommonNumber[conNumExchangeRate].Value = 1;
								txtCommonNumber[conNumExchangeRate].Enabled = true;
							}
						}

						if (Index == conTxtAssetCd && CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
						{
							txtCommonDisplay[conDlblPurchaseDate].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(3)), SystemVariables.gSystemDateFormat);
							txtCommonDisplay[conDlblInvoiceAmt].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(4)), "###,###,###,###,##0.000");
							txtCommonDisplay[conDlblLastDeprDate].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(5)), SystemVariables.gSystemDateFormat);
							txtCommonDisplay[conDlblAccumDeprAmt].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(6)), "###,###,###,###,##0.000");
							txtCommonDisplay[conDlblLastAdjustmentDate].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(7)), SystemVariables.gSystemDateFormat);
							txtCommonDisplay[conDlblLastAdjustmentAmt].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(8)), "###,###,###,###,##0.000");
							txtCommonDisplay[conDlblLastWriteOffDate].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(9)), SystemVariables.gSystemDateFormat);
							txtCommonDisplay[conDlblLastWriteoffAmt].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(10)), "###,###,###,###,##0.000");
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							cWoffQty = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(12)); //''Purchase qty
							txtCommonDisplay[conDlblBookValue].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(11)), "###,###,###,###,##0.000");

							//'''Currentassetvalue = originalassetvalue - writeoff - adjustment
							txtCommonDisplay[conDlblCurrentAssetValue].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(4)) - ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(10)) - ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(8)), "###,###,###,###,##0.000");

							txtWriteoffDate.Value = ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mTempValue).GetValue(5)); //''Last Depr. Date
							cLastDeprDate = DateTimeHelper.ToString(ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mTempValue).GetValue(5))); //''Last Depr. Date

							//''Qty = purchase Qty - previous writeoff Qty
							cRemainingQty = Convert.ToInt32(ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(12)) - ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(13)));
							txtCommonNumber[conNumWoffQty].Value = 0;


							EnableDisableControl(false);

							CalculateWriteoff();

							txtWriteoffDate.Focus();
						}
					}
				}
				else
				{
					txtCommonDisplay[mLinkedTextBoxIndex].Text = "";
					//txtCommon(Index).Tag = ""
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

		private void txtCommonNumber_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (!((System.Windows.Forms.TextBox) eventSender).CausesValidation)
			{
				txtCommonNumber_Validated(eventSender, eventArgs);
			}
		}

		private void txtCommonNumber_Validated(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonNumber, eventSender);
			decimal mAssetValue = 0;

			if (Index == conNumWoffQty)
			{
				CalculateWriteoff();
			}
			else if (Index == conNumWoffAmt)
			{ 
				mAssetValue = (decimal) Conversion.Val(StringsHelper.Format(txtCommonNumber[conNumWoffAmt].Text, "###############0.000"));

				CalculateActualWriteoff(mAssetValue, 2);
			}

		}


		private void txtCommonNumber_Validating(Object eventSender, CancelEventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonNumber, eventSender);
			bool Cancel = eventArgs.Cancel;
			try
			{
				decimal mActualWoffAmt = 0;

				if (Index == conNumDeprAmt || Index == conNumWoffDeprAmt)
				{
					//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
					mActualWoffAmt = ((decimal) (ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNumWoffAmt].Value) - (Convert.ToDouble(ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNumDeprAmt].Value) + ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNumWoffDeprAmt].Value)))));
					if (mActualWoffAmt > ((decimal) Conversion.Val(StringsHelper.Format(txtCommonDisplay[conDlblBookValue].Text, "##############0.000"))))
					{
						MessageBox.Show("Actual Writeoff amount cannot be greater than Book value!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommonNumber[Index].Focus();
						Cancel = true;
					}
					else if (mActualWoffAmt < 0)
					{ 
						MessageBox.Show("Actual Writeoff amount cannot be negative!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommonNumber[Index].Focus();
						Cancel = true;
					}
					else
					{
						txtCommonNumber[conNumActualWoffAmt].Value = mActualWoffAmt;
					}
				}

				if (Index == conNumWoffQty)
				{
					if (ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[Index].Value) > Conversion.Val(cRemainingQty.ToString()))
					{
						MessageBox.Show("Writeoff Qty cannot be greater than Qty Remaining ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommonNumber[Index].Focus();
						Cancel = true;
					}
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel;
			}

		}

		private void txtWriteoffDate_Validating(Object eventSender, CancelEventArgs eventArgs)
		{
			bool Cancel = eventArgs.Cancel;
			try
			{
				if (!txtWriteoffDate.ValueIsNull && Information.IsDate(cLastDeprDate))
				{
					if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtWriteoffDate.Value) < DateTime.Parse(cLastDeprDate))
					{
						MessageBox.Show("Writeoff date should be greater than last depreciation date : " + StringsHelper.Format(cLastDeprDate, SystemVariables.gSystemDateFormat), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtWriteoffDate.Focus();
						Cancel = true;
					}
					else
					{
						CalculateWriteoff();
					}
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel;
			}
		}

		private void EnableDisableControl(bool pEnabled)
		{
			txtCommon[conTxtAssetCd].Enabled = pEnabled;
			txtWriteoffDate.Enabled = !pEnabled;
			txtCommonNumber[conNumWoffQty].Enabled = !pEnabled;
			txtCommonNumber[conNumWoffAmt].Enabled = !pEnabled;
			//txtCommonNumber(conNumDeprAmt).Enabled = Not pEnabled
			//txtCommonNumber(conNumWoffDeprAmt).Enabled = Not pEnabled
		}

		private void CalculateActualWriteoff(decimal pAssetValue, int pCalcType = 1)
		{
			decimal mCurrentAssetValue = 0;

			string mysql = "";

			decimal mBookValue = (decimal) Conversion.Val(StringsHelper.Format(txtCommonDisplay[conDlblBookValue].Text, "###############0.000"));
			decimal mAccumlatedDeprAmt = (decimal) Conversion.Val(StringsHelper.Format(txtCommonDisplay[conDlblAccumDeprAmt].Text, "###############0.000"));
			int mPurchaseQty = Convert.ToInt32(Conversion.Val(cWoffQty.ToString()) - Conversion.Val(cRemainingQty.ToString()));
			//UPGRADE_WARNING: (1068) txtCommonNumber().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mWriteoffQty = ReflectionHelper.GetPrimitiveValue<int>(txtCommonNumber[conNumWoffQty].Value);

			if (mWriteoffQty == 0)
			{
				mWriteoffQty = 1;
			}

			if (mPurchaseQty == 0)
			{
				mPurchaseQty = 1;
			}

			if (pCalcType == 1)
			{
				//If mPurchaseQty > 0 Then
				txtCommonNumber[conNumWoffAmt].Value = (((double) pAssetValue) / ((double) mPurchaseQty)) * mWriteoffQty;
				txtCommonNumber[conNumDeprAmt].Value = (((double) mAccumlatedDeprAmt) / ((double) mPurchaseQty)) * mWriteoffQty;
				//Else
				//    txtCommonNumber(conNumWoffAmt).Value = (pAssetValue)
				//    txtCommonNumber(conNumDeprAmt).Value = (mAccumlatedDeprAmt)
				//End If
			}
			else
			{
				mCurrentAssetValue = (decimal) Conversion.Val(StringsHelper.Format(txtCommonDisplay[conDlblCurrentAssetValue].Text, "###############0.000"));

				//If mCurrentAssetValue > 0 And mPurchaseQty > 0 Then
				if (mCurrentAssetValue > 0)
				{
					txtCommonNumber[conNumDeprAmt].Value = ((((double) (mAccumlatedDeprAmt * pAssetValue)) / ((double) mCurrentAssetValue)) / ((double) mPurchaseQty)) * mWriteoffQty;
				}
				else
				{
					txtCommonNumber[conNumDeprAmt].Value = 0;
				}
			}

			txtCommonNumber[conNumWoffDeprAmt].Value = 0;

			SqlDataReader rsTempRec = null;
			mysql = " select asset_cd, depr_method_cd, depr_percent from fa_items ";
			mysql = mysql + " where asset_no ='" + txtCommon[conTxtAssetCd].Text + "'";
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			bool rsTempRecDidRead = rsTempRec.Read();
			if (rsTempRecDidRead && Information.IsDate(txtWriteoffDate.Value))
			{
				txtCommonNumber[conNumWoffDeprAmt].Value = SystemFAProcedure.GetDeprAmount(Convert.ToInt32(rsTempRec["asset_cd"]), Convert.ToInt32(rsTempRec["depr_method_cd"]), Convert.ToDecimal(rsTempRec["depr_percent"]), pAssetValue, mBookValue, DateTime.Parse(txtCommonDisplay[conDlblLastDeprDate].Text), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtWriteoffDate.Value));
			}
			rsTempRec.Close();
			txtCommonNumber_Validating(txtCommonNumber[conNumDeprAmt], new CancelEventArgs(false));

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

							if (!PostWriteoff(ReflectionHelper.GetPrimitiveValue<int>(SearchValue)))
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

		private bool PostWriteoff(int pEntryId)
		{
			object[, ] mArr = new object[6, 3];
			object mDefaultGlVoucherType = null;
			int mVoucherNo = 0;
			int mVoucherEntryId = 0;
			int mTransEntryID = 0;
			decimal mDrTotal = 0;
			decimal mCrTotal = 0;
			decimal mBalance = 0;
			decimal mLineAmt = 0;
			int mDrLineNo = 0;
			int mCrLineNo = 0;


			//''''GL entry to generated as follows
			//Depr. A/C                              (Woff Depr. amt) Dr
			//Asset Accumulated Depreciation Account (Depr. Amt)      Dr
			//Customer A/C                                            Dr
			//        To Asset Accumulated Depreciation Account (Woff Depr. Amt)
			//        To Asset WriteOff A/C  (this account will be debited or creditd as per balance)
			//        To Asset Debit a/c     (Actual Woff Amt.) (Asset purchase price -  asset accumulated depr - asset write off amt)
			//        To Asset Sales a/c

			//''''''''''''''''''''''''''''''''''''''''''''''''
			//'A breif explanation of above entry
			//'When a sales of a fixed asset is done , a normal sales entry is passed
			//'Customer a/c      Dr
			//'          To Asset Sales a/c
			//'
			//'The depreciation accrued from the last date of depreciation upto the writeoff date
			//'Depr. A/C                              (Woff Depr. amt) Dr
			//'        To Asset Accumulated Depreciation Account (Woff Depr. Amt)
			//'
			//'All the depreciation accumulated for this asset upto the last date of depreciation
			//'plus (+) The depreciation accrued from the last date of depreciation upto the writeoff date
			//'Asset Accumulated Depreciation Account (Depr. Amt)      Dr
			//'        To Asset Debit a/c             (Actual Woff Amt.) (Asset purchase price -  asset accumulated depr - asset write off amt)
			//'
			//'The difference between the debit and credit entries is passed to this a/c
			//'        To Asset WriteOff A/C  (this account will be debited or creditd as per balance)
			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''

			string mysql = " select fa.qty faqty, fa.writeoff_qty fawriteoffqty, faw.* from fa_writeoff faw ";
			mysql = mysql + " inner join fa_items fa on faw.asset_cd = fa.asset_cd ";
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

					//''if the purchase date is within the financial year
					//''then only generate the GL entry.
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (!SystemProcedure2.ValidDateRange(Convert.ToDateTime(rsTempRec.Tables[0].Rows[0]["writeoff_date"])))
					{
						MessageBox.Show(" Writeoff date should be in the financial year", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mDefaultGlVoucherType = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetSystemPreferenceSetting("fa_default_gl_voucher_type"));

						mysql = " voucher_type = " + Conversion.Str(mDefaultGlVoucherType);
						mVoucherNo = Convert.ToInt32(Double.Parse(SystemProcedure2.GetNewNumber("gl_accnt_trans", "voucher_no", 0, mysql, " tablock(xlock) ")));

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mVoucherEntryId = SystemFAProcedure.FAInsertGLHeaderEntry(ReflectionHelper.GetPrimitiveValue<int>(mDefaultGlVoucherType), StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["writeoff_date"], SystemVariables.gSystemDateFormat), mVoucherNo, Convert.ToString(rsTempRec.Tables[0].Rows[0]["transaction_no"]), Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsTempRec.Tables[0].Rows[0]["comments"] : rsTempRec.Tables[0].Rows[0]["comments"]), 2, SystemVariables.gLoggedInUserCode);


						mDrLineNo = 1;
						mCrLineNo = 1;

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["writeoff_depr_amt"]) > 0)
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mLineAmt = Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["writeoff_depr_amt"]);
							//''''Depr. A/C                              (Woff Depr. amt) Dr
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFADeprAccntCd, 0]), (SystemProcedure2.IsItEmpty(mArr[SystemFAProcedure.gFADeprAccntCd, 1], SystemVariables.DataType.NumberType)) ? "NULL" : ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFADeprAccntCd, 1]), 1, mLineAmt, 1 * mLineAmt, "D", StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["writeoff_date"], SystemVariables.gSystemDateFormat), mDrLineNo, 1);

							mDrLineNo++;
							mDrTotal += mLineAmt;
						}
						else
						{
							mLineAmt = 0;
						}


						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["depr_amt"]) > 0)
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mLineAmt = Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["depr_amt"]);
							//'''''Asset Accumulated Depreciation Account (Depr. Amt)      Dr
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFAAccumDeprAccntCd, 0]), (SystemProcedure2.IsItEmpty(mArr[SystemFAProcedure.gFAAccumDeprAccntCd, 1], SystemVariables.DataType.NumberType)) ? "NULL" : ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFAAccumDeprAccntCd, 1]), 1, mLineAmt, 1 * mLineAmt, "D", StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["writeoff_date"], SystemVariables.gSystemDateFormat), mDrLineNo, 1);

							mDrLineNo++;
							mDrTotal += mLineAmt;
						}
						else
						{
							mLineAmt = 0;
						}


						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["selling_amt_lc"]) > 0)
						{
							//''''''''Supplier A/C                                            Dr
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mLineAmt = Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["selling_amt_lc"]);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, Convert.ToString(rsTempRec.Tables[0].Rows[0]["ledger_accnt_cd"]), "99999", Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["exchange_rate"]), mLineAmt, (decimal) (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["exchange_rate"]) * ((double) mLineAmt)), "D", StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["writeoff_date"], SystemVariables.gSystemDateFormat), mDrLineNo, 1);

							mDrLineNo++;
							mDrTotal += mLineAmt;
						}
						else
						{
							mLineAmt = 0;
						}


						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						mBalance = (decimal) (((double) mDrTotal) - (Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["writeoff_depr_amt"]) + Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["actual_writeoff_amt"])) + Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["selling_amt_lc"]))));
						if (mBalance > 0)
						{
							//''''''''''        To Asset WriteOff A/C  Cr
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFAWriteoffAccntCd, 0]), (SystemProcedure2.IsItEmpty(mArr[SystemFAProcedure.gFAWriteoffAccntCd, 1], SystemVariables.DataType.NumberType)) ? "NULL" : ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFAWriteoffAccntCd, 1]), 1, mBalance * -1, mBalance * -1, "C", StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["writeoff_date"], SystemVariables.gSystemDateFormat), mCrLineNo, 1);

							mCrLineNo++;
						}
						else if (mBalance < 0)
						{ 
							//'''''''''        Asset WriteOff A/C Dr
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFAWriteoffAccntCd, 0]), (SystemProcedure2.IsItEmpty(mArr[SystemFAProcedure.gFAWriteoffAccntCd, 1], SystemVariables.DataType.NumberType)) ? "NULL" : ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFAWriteoffAccntCd, 1]), 1, (decimal) Math.Abs((double) mBalance), (decimal) Math.Abs((double) mBalance), "D", StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["writeoff_date"], SystemVariables.gSystemDateFormat), mDrLineNo, 1);
							mDrLineNo++;
						}

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["writeoff_depr_amt"]) > 0)
						{
							//'''''        To Asset Accumulated Depreciation Account (Woff Depr. Amt)
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mLineAmt = Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["writeoff_depr_amt"]);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFAAccumDeprAccntCd, 0]), (SystemProcedure2.IsItEmpty(mArr[SystemFAProcedure.gFAAccumDeprAccntCd, 1], SystemVariables.DataType.NumberType)) ? "NULL" : ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFAAccumDeprAccntCd, 1]), 1, mLineAmt * -1, 1 * (mLineAmt * -1), "C", StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["writeoff_date"], SystemVariables.gSystemDateFormat), mCrLineNo, 1);

							mCrLineNo++;
							mCrTotal += mLineAmt;
						}
						else
						{
							mLineAmt = 0;
						}


						//'''''''''        To Asset Debit a/c (Actual Woff Amt.)
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mLineAmt = Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["actual_writeoff_amt"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFADebitAccntCd, 0]), (SystemProcedure2.IsItEmpty(mArr[SystemFAProcedure.gFADebitAccntCd, 1], SystemVariables.DataType.NumberType)) ? "NULL" : ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFADebitAccntCd, 1]), 1, mLineAmt * -1, 1 * (mLineAmt * -1), "C", StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["writeoff_date"], SystemVariables.gSystemDateFormat), mCrLineNo, 1);

						mCrLineNo++;
						mCrTotal += mLineAmt;


						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["selling_amt_lc"]) > 0)
						{
							//''''''''   To Asset Sales
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mLineAmt = Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["selling_amt_lc"]);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFASalesAccntCd, 0]), (SystemProcedure2.IsItEmpty(mArr[SystemFAProcedure.gFASalesAccntCd, 1], SystemVariables.DataType.NumberType)) ? "NULL" : ReflectionHelper.GetPrimitiveValue<string>(mArr[SystemFAProcedure.gFASalesAccntCd, 1]), Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["exchange_rate"]), mLineAmt * -1, (decimal) (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["exchange_rate"]) * ((double) (mLineAmt * -1))), "C", StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["writeoff_date"], SystemVariables.gSystemDateFormat), mCrLineNo, 1);

							mCrLineNo++;
							mCrTotal += mLineAmt;
						}
						else
						{
							mLineAmt = 0;
						}
					}
				}
				else
				{
					return false;
				}
			}

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mTransEntryID = SystemFAProcedure.FAInsertDeprTransHeader(StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["writeoff_date"], SystemVariables.gSystemDateFormat), SystemFAProcedure.gFAWriteoffVoucherType, true, pEntryId);

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			SystemFAProcedure.FAInsertDeprTransDetails(mTransEntryID, Convert.ToInt32(rsTempRec.Tables[0].Rows[0]["asset_cd"]), StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["last_depr_date"], SystemVariables.gSystemDateFormat), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["last_depr_amt"]), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["accumulated_depr_amt"]), Convert.ToInt32(rsTempRec.Tables[0].Rows[0]["depr_method_cd"]), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["depr_percent"]), StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["writeoff_date"], SystemVariables.gSystemDateFormat), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["writeoff_amt"]));

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			if (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["depr_amt"]) > 0)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemFAProcedure.FAInsertDeprTransDetails(mTransEntryID, Convert.ToInt32(rsTempRec.Tables[0].Rows[0]["asset_cd"]), StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["last_depr_date"], SystemVariables.gSystemDateFormat), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["last_depr_amt"]), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["accumulated_depr_amt"]), Convert.ToInt32(rsTempRec.Tables[0].Rows[0]["depr_method_cd"]), Convert.ToDecimal(rsTempRec.Tables[0].Rows[0]["depr_percent"]), StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["writeoff_date"], SystemVariables.gSystemDateFormat), (decimal) (Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["depr_amt"]) * -1));
			}

			mysql = " update fa_items set ";
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " accumulated_depr_amt = accumulated_depr_amt - " + Conversion.Str(rsTempRec.Tables[0].Rows[0]["depr_amt"]);
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " , writeoff_date ='" + StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["writeoff_date"], SystemVariables.gSystemDateFormat) + "'";

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			if (((Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["faqty"]) - Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["fawriteoffqty"])) - Convert.ToDouble(rsTempRec.Tables[0].Rows[0]["writeoff_qty"])) < 1)
			{
				mysql = mysql + " , writeoff_qty = 1 ";
			}
			else
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " , writeoff_qty = writeoff_qty + " + Convert.ToString(rsTempRec.Tables[0].Rows[0]["writeoff_qty"]);
			}
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " , writeoff_value = writeoff_value + " + Conversion.Str(rsTempRec.Tables[0].Rows[0]["writeoff_amt"]);
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " where asset_cd =" + Convert.ToString(rsTempRec.Tables[0].Rows[0]["asset_cd"]);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = " update fa_writeoff ";
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
					mysql = " select gl_generated_voucher_type, gl_generated_entry_id from fa_writeoff ";
					mysql = mysql + " where entry_id =" + Conversion.Str(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
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
				}
			}
		}


		private void CalculateWriteoff()
		{

			decimal mCurrentAssetValue = (decimal) Conversion.Val(StringsHelper.Format(txtCommonDisplay[conDlblCurrentAssetValue].Text, "###############0.000"));

			CalculateActualWriteoff(mCurrentAssetValue);

		}
	}
}