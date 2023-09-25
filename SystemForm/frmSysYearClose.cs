
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmSysYearClose
		: System.Windows.Forms.Form
	{

		public frmSysYearClose()
{
InitializeComponent();
} 
 public  void frmSysYearClose_old()
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


		private void frmSysYearClose_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private int mThisFormID = 0;

		private const int conCompanyName = 0;
		private const int conCurrentFiscalYear = 1;
		private const int conNextFiscalYear = 2;
		private const int conNewCurrentFiscalYear = 3;
		private const int conNewNextFiscalYear = 4;
		private const int conVoucherType = 5;
		private const int conProfitLossAccountName = 6;
		private const int conCapitalAccountName = 7;

		private const string mProfitAndLossGroupCode = "H";

		
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


		private void btnReportOptions_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.btnReportOptions, eventSender);
			if (Index == 1)
			{
				CloseYear();
			}
			else if (Index == 2)
			{ 
				this.Close();
			}
		}

		private void cmdButton_AccessKeyPress(int Index, int KeyAscii)
		{
			cmdButton_Click(Index);
		}

		private void cmdButton_Click(int Index)
		{
			if (Index == 1)
			{
				CloseYear();
			}
			else if (Index == 2)
			{ 
				this.Close();
			}
		}

		private void btnReportOptions_KeyDownEvent(Object eventSender, AxSmartNetButtonProject.__SmartNetButton_KeyDownEvent eventArgs)
		{
			int Index = Array.IndexOf(this.btnReportOptions, eventSender);
			if (eventArgs.keyCode == ((int) Keys.Return) || eventArgs.keyCode == 32)
			{
				cmdButton_Click(Index);
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
				else if (KeyCode == 27)
				{ 
					this.Close();
					return;
				}

				if (this.ActiveControl.Name == "txtCommonSearch")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommonSearch#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			//Get the Company Information


			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conCompanyName].Text = Convert.ToString(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["l_comp_name"]);
			}
			else
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommon[conCompanyName].Text = Convert.ToString(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["a_comp_name"]);
			}

			this.Top = 0;
			this.Left = 0;

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			string myString = "From " + StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["current_period_start_date"], SystemVariables.gSystemDateFormat);
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			myString = myString + " To " + StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["current_period_end_date"], SystemVariables.gSystemDateFormat);
			txtCommon[conCurrentFiscalYear].Text = myString;

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			myString = "From " + StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["next_period_start_date"], SystemVariables.gSystemDateFormat);
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			myString = myString + " To " + StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["next_period_end_date"], SystemVariables.gSystemDateFormat);
			txtCommon[conNextFiscalYear].Text = myString;
			txtCommon[conNewCurrentFiscalYear].Text = myString;


			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			myString = "From " + StringsHelper.Format(Convert.ToDateTime(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["next_period_start_date"]).AddYears(1), SystemVariables.gSystemDateFormat);
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			myString = myString + " To " + StringsHelper.Format(Convert.ToDateTime(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["next_period_end_date"]).AddYears(1), SystemVariables.gSystemDateFormat);
			txtCommon[conNewNextFiscalYear].Text = myString;

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			txtVoucherDate.Value = StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["current_period_end_date"], SystemVariables.gSystemDateFormat);

			txtCommonSearch[conVoucherType].Text = "103";
			txtCommonSearch_Leave(txtCommonSearch[conVoucherType], new EventArgs());
			this.WindowState = FormWindowState.Maximized;

		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;
			string mysql = "";

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mObjectIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

			if (mObjectName == "txtCommonSearch")
			{
				txtCommonSearch[mObjectIndex].Text = "";
				switch(mObjectIndex)
				{
					case conCapitalAccountName : 
						//mysql = " left(ldgr_cd, 1) = 'A'" 
						mysql = " l.type_cd = " + SystemGLConstants.gGLAssetsLiabilitiesTypeCode.ToString(); 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mysql)); 
						//        Case conProfitLossAccountName 
						//            mysql = " left(ldgr_cd, 4) = 'H-PL'" 
						//            mTempSearchValue = FindItem(1001000, "2", mysql) 
						//        Case conVoucherType 
						//            'mTempSearchValue = FindItem(1000110, "882") 
						break;
					default:
						return;
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonSearch[mObjectIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtCommonSearch_Leave(txtCommonSearch[mObjectIndex], new EventArgs());
				}
			}
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				frmSysYearClose.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCommonSearch_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonSearch, Sender);
			//Call ToolBarButtonClick(Me, "FindRoutine", "txtLdgrNo")
			FindRoutine("txtCommonSearch#" + Index.ToString().Trim());
		}

		private void txtCommonSearch_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonSearch, eventSender);
			string mysql = "";
			object mTempReturnValue = null;
			int mSetValueIndex = 0;


			try
			{

				switch(Index)
				{
					case conCapitalAccountName : 
						mysql = "select ldgr_no as [Ledger Code], "; 
						mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name"); 
						mysql = mysql + " as [Ledger Name], ldgr_no  from gl_ledger "; 
						//mysql = mysql & " where left(ldgr_cd, 1) = 'A'" 
						mysql = mysql + " where type_cd =" + SystemGLConstants.gGLAssetsLiabilitiesTypeCode.ToString(); 
						mysql = mysql + " and ldgr_no='" + txtCommonSearch[conCapitalAccountName].Text + "'"; 
						mSetValueIndex = conCapitalAccountName; 
						//    Case conProfitLossAccountName 
						//        mysql = "select ldgr_no as [Ledger Code], " 
						//        mysql = mysql + IIf(gPreferedLanguage = english, "l_ldgr_name", "a_ldgr_name") 
						//        mysql = mysql & " as [Ledger Name], ldgr_no  from gl_ledger " 
						//        mysql = mysql & " where left(ldgr_cd, 4) = 'H-PL'" 
						//        mysql = mysql & " and ldgr_no='" & txtCommonSearch(conProfitLossAccountName).Text & "'" 
						//        mSetValueIndex = conProfitLossAccountName 
						break;
					case conVoucherType : 
						mysql = "select voucher_type as [Voucher Type], " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name" : "a_voucher_name"); 
						mysql = mysql + " as [Voucher Name], voucher_type "; 
						mysql = mysql + " from gl_accnt_voucher_types "; 
						mysql = mysql + " where voucher_type = " + txtCommonSearch[conVoucherType].Text; 
						mSetValueIndex = conVoucherType; 
						break;
					default:
						mSetValueIndex = 0; 
						break;
				}

				if (mSetValueIndex > 0)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonSearch[Index].Text, SystemVariables.DataType.StringType))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempReturnValue))
						{
							txtCommon[mSetValueIndex].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommon[mSetValueIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempReturnValue).GetValue(1));
						}
					}
					else
					{
						txtCommon[mSetValueIndex].Text = "";
					}
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
					//    If Me.txtCommonTextBox(Index).Enabled = True Then
					//       Me.txtCommonTextBox(Index).SetFocus
					//    End If
				}
				else
				{
					//
				}
			}


		}

		//
		//Private Sub CloseYear()
		//Dim mySql As String
		//Dim mCapitalAccountCode As String
		//Dim mProfitandLossAccountCode As String
		//Dim mLdgrCd As String
		//Dim mVoucherType As Long
		//Dim mVoucherNo As Long
		//Dim mNewEntryID As Long
		//Dim ans As Integer
		//
		//Dim mNetProfitAndLoss As Double
		//Dim mPeriodOpeningProfit As Double
		//Dim mCurrentYearTransferredProfit As Double
		//Dim mCurrentYearProfit As Double
		//Dim NetProfitAndLoss As Double
		//Dim mReturnValue As Variant
		//
		//
		//On Error GoTo eFoundError
		//
		//Dim myHourGlass As clsHourGlass
		//Set myHourGlass = New clsHourGlass
		//
		//'****'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//'Caution message box
		//ans = MsgBox("Are you sure, you want to close the year?", vbInformation + vbYesNo)
		//If ans = vbNo Then
		//    Exit Sub
		//End If
		//
		//'****'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//
		//
		//'****'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//'Get the Ledger Code for Capital Account , Profit And loss A.c, voucher Type
		//If Not IsItEmpty(txtCommonSearch(conCapitalAccountName).Text, StringType) Then
		//    mySql = " select ldgr_cd from gl_ledger where ldgr_no='" & txtCommonSearch(conCapitalAccountName).Text & "'"
		//    mReturnValue = GetMasterCode(mySql)
		//    If IsNull(mReturnValue) Then
		//        MsgBox "Invalid Ledger Code", vbInformation
		//        txtCommonSearch(conCapitalAccountName).SetFocus
		//        Exit Sub
		//    Else
		//        mCapitalAccountCode = mReturnValue
		//    End If
		//Else
		//    MsgBox "Invalid Ledger Code", vbInformation
		//    txtCommonSearch(conCapitalAccountName).SetFocus
		//    Exit Sub
		//End If
		//
		//If Not IsItEmpty(txtCommonSearch(conProfitLossAccountName).Text, StringType) Then
		//    mySql = " select ldgr_cd from gl_ledger where ldgr_no='" & txtCommonSearch(conProfitLossAccountName).Text & "'"
		//    mReturnValue = GetMasterCode(mySql)
		//    If IsNull(mReturnValue) Then
		//        MsgBox "Invalid Ledger Code", vbInformation
		//        txtCommonSearch(conProfitLossAccountName).SetFocus
		//        Exit Sub
		//    Else
		//        mProfitandLossAccountCode = mReturnValue
		//    End If
		//Else
		//    MsgBox "Invalid Ledger Code", vbInformation
		//    txtCommonSearch(conProfitLossAccountName).SetFocus
		//    Exit Sub
		//End If
		//
		//If Not IsItEmpty(txtCommonSearch(conVoucherType).Text, StringType) Then
		//    mySql = " select voucher_type from accnt_voucher_types where voucher_type=" & txtCommonSearch(conVoucherType).Text
		//    mReturnValue = GetMasterCode(mySql)
		//    If IsNull(mReturnValue) Then
		//        MsgBox "Invalid Voucher Type", vbInformation
		//        txtCommonSearch(conVoucherType).SetFocus
		//        Exit Sub
		//    Else
		//        mVoucherType = mReturnValue
		//    End If
		//Else
		//    MsgBox "Invalid Voucher Type", vbInformation
		//    txtCommonSearch(conVoucherType).SetFocus
		//    Exit Sub
		//End If
		//'****'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//
		//
		//gConn.BeginTrans
		//'**--year close for all the ics voucher type transactions
		//Call YearEndPostICSTransactions
		//'**--year close for all the gl voucher type transactions
		//Call YearEndPostGLTransactions
		//
		//
		//'**------------------------------------------------------------------------------------
		//'**--Generate the GL Entry
		//'**--Profit--P&L A.c Dr to Capital A.c
		//'**--Loss--Capital A.c to P&L A.c
		//mySql = " select (isnull(sum(lc_cr_amt), 0) - isnull(sum(lc_dr_amt), 0))"
		//mySql = mySql & " from gl_accnt_trans_details atd"
		//mySql = mySql & " inner join gl_accnt_trans mt on atd.entry_id = mt.entry_id"
		//mySql = mySql & " inner join accnt_voucher_types avt on avt.voucher_type = mt.voucher_type"
		//mySql = mySql & " where left(ldgr_cd, 1) = '" & mProfitAndLossGroupCode & "'"
		//mySql = mySql & " and avt.op_voucher_type = 1"
		//mySql = mySql & " and mt.voucher_date >= cast('" & Format(rsCompanyProperties("current_period_start_date").Value, gSystemDateFormat) & "' as smalldatetime)"
		//mySql = mySql & " and mt.voucher_date <= cast('" & Format(rsCompanyProperties("current_period_end_date").Value, gSystemDateFormat) & "' as smalldatetime)"
		//mySql = mySql & " and mt.status <> 3"
		//mPeriodOpeningProfit = GetMasterCode(mySql)
		//
		//
		//mySql = " select isnull(sum(lc_dr_amt), 0) - isnull(sum(lc_cr_amt), 0)"
		//mySql = mySql & " from gl_accnt_trans_details atd"
		//mySql = mySql & " inner join gl_accnt_trans mt on atd.entry_id = mt.entry_id"
		//mySql = mySql & " inner join accnt_voucher_types avt on avt.voucher_type = mt.voucher_type"
		//mySql = mySql & " where left(ldgr_cd, 1) = '" & mProfitAndLossGroupCode & "'"
		//mySql = mySql & " and mt.voucher_date >= cast('" & Format(rsCompanyProperties("current_period_start_date").Value, gSystemDateFormat) & "' as smalldatetime)"
		//mySql = mySql & " and mt.voucher_date <= cast('" & Format(rsCompanyProperties("current_period_end_date").Value, gSystemDateFormat) & "' as smalldatetime)"
		//mySql = mySql & " and mt.status <> 3"
		//mySql = mySql & " and avt.op_voucher_type = 0"
		//mCurrentYearTransferredProfit = GetMasterCode(mySql)
		//
		//
		//mySql = " select isnull(sum(lc_dr_amt), 0) - isnull(sum(lc_cr_amt), 0)"
		//mySql = mySql & " from gl_accnt_trans_details atd"
		//mySql = mySql & " inner join gl_accnt_trans mt on atd.entry_id = mt.entry_id"
		//mySql = mySql & " inner join gl_ledger on atd.ldgr_cd = gl_ledger.ldgr_cd"
		//mySql = mySql & " inner join gl_accnt_group ag on gl_ledger.group_cd = ag.group_cd"
		//mySql = mySql & " Where (ag.group_type = 1 Or ag.group_type = 2)"
		//mySql = mySql & " and ag.show = 1"
		//mySql = mySql & " and mt.voucher_date >= cast('" & Format(rsCompanyProperties("current_period_start_date").Value, gSystemDateFormat) & "' as smalldatetime)"
		//mySql = mySql & " and mt.voucher_date <= cast('" & Format(rsCompanyProperties("current_period_end_date").Value, gSystemDateFormat) & "' as smalldatetime)"
		//mySql = mySql & " and mt.status <> 3"
		//mySql = mySql & " and mt.entry_id not in"
		//mySql = mySql & " (select entry_id from gl_accnt_trans_details"
		//mySql = mySql & " where left(ldgr_cd, 1) = '" & mProfitAndLossGroupCode & "')"
		//
		//mCurrentYearProfit = GetMasterCode(mySql)
		//
		//mNetProfitAndLoss = (mPeriodOpeningProfit + mCurrentYearProfit) - (mCurrentYearTransferredProfit)
		//
		//If mNetProfitAndLoss <> 0 Then
		//    mySql = " voucher_type = " & txtCommonSearch(conVoucherType).Text
		//    mVoucherNo = GetNewNumber("gl_accnt_trans", "voucher_no", , mySql, " tablock(xlock) ")
		//
		//    mySql = " insert into gl_accnt_trans(voucher_type, voucher_date, voucher_no, "
		//    mySql = mySql & " status, comments, user_cd) "
		//    mySql = mySql & " values ("
		//    mySql = mySql & mVoucherType
		//    mySql = mySql & ",'" & txtVoucherDate.Value & "'"
		//    mySql = mySql & "," & mVoucherNo
		//    mySql = mySql & ",2"
		//    mySql = mySql & ",'Year Closing Auto Generated Profit and Loss entry'"
		//    mySql = mySql & "," & gLoggedInUserCode & ")"
		//    gConn.Execute mySql
		//
		//    mNewEntryID = CLng(GetMasterCode("select scope_identity()"))
		//
		//    'Debit Entry
		//    mySql = " insert into gl_accnt_trans_details (entry_id, ldgr_cd, exchange_rate, "
		//    mySql = mySql & " fc_dr_amt, fc_cr_amt, dr_cr_line_no, dr_cr_type, "
		//    mySql = mySql & " fc_voucher_amt, due_date)"
		//    mySql = mySql & " values ("
		//    mySql = mySql & Str(mNewEntryID)
		//    If mNetProfitAndLoss > 0 Then
		//        mySql = mySql & ",'" & mProfitandLossAccountCode & "'"
		//    Else
		//        mySql = mySql & ",'" & mCapitalAccountCode & "'"
		//    End If
		//    mySql = mySql & " ,1"
		//    mySql = mySql & " ," & Abs(mNetProfitAndLoss)
		//    mySql = mySql & " , 0, 1"
		//    mySql = mySql & " , 'D' "
		//    mySql = mySql & " ," & Abs(mNetProfitAndLoss)
		//    mySql = mySql & ",'" & Format(rsCompanyProperties("next_period_start_date").Value, gSystemDateFormat) & "')"
		//    gConn.Execute mySql
		//
		//    'Credit Entry
		//    mySql = " insert into gl_accnt_trans_details (entry_id, ldgr_cd, exchange_rate, "
		//    mySql = mySql & " fc_dr_amt, fc_cr_amt, dr_cr_line_no, dr_cr_type, "
		//    mySql = mySql & " fc_voucher_amt, due_date)"
		//    mySql = mySql & " values ("
		//    mySql = mySql & Str(mNewEntryID)
		//    If mNetProfitAndLoss > 0 Then
		//        mySql = mySql & ",'" & mCapitalAccountCode & "'"
		//    Else
		//        mySql = mySql & ",'" & mProfitandLossAccountCode & "'"
		//    End If
		//    mySql = mySql & " ,1"
		//    mySql = mySql & " ,0"
		//    mySql = mySql & " ," & Abs(mNetProfitAndLoss)
		//    mySql = mySql & " , 1 , 'C' "
		//    mySql = mySql & " ," & Abs(mNetProfitAndLoss)
		//    mySql = mySql & ",'" & Format(rsCompanyProperties("next_period_start_date").Value, gSystemDateFormat) & "')"
		//    gConn.Execute mySql
		//End If
		//'**------------------------------------------------------------------------------------
		//
		//
		//Call UpdateCompanySystemYear
		//
		//
		//gConn.CommitTrans
		//
		//MsgBox "Closing of the year has been done successfully, Restart the application to work in the new year", vbInformation
		//End
		//
		//
		//Exit Sub
		//eFoundError:
		//Dim mReturnErrorType As Integer
		//mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, "frmSysYearClose", "GetRecord", msg10)
		//If mReturnErrorType = 1 Then
		//'
		//ElseIf mReturnErrorType = 2 Then
		//'
		//ElseIf mReturnErrorType = 3 Then
		//'
		//ElseIf mReturnErrorType = 4 Then
		//    'if the code is not found
		//'    If pForm.txtCommonTextBox(Index).Enabled = True Then
		//'       pForm.txtCommonTextBox(Index).SetFocus
		//'    End If
		//Else
		//    '
		//End If
		//
		//On Error Resume Next
		//gConn.RollbackTrans
		//End Sub

		private void YearEndPostICSTransactions()
		{

			DataSet rsLocalRec = new DataSet();

			string mysql = " select entry_id, mt.voucher_type ";
			mysql = mysql + " from ICS_Transaction mt ";
			mysql = mysql + " inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";
			mysql = mysql + " where (posted_gl = 0 and status <> 3) ";
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " and voucher_date >= cast('" + StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["current_period_start_date"], SystemVariables.gSystemDateFormat) + "' as smalldatetime)";
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " and voucher_date <= cast('" + StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["current_period_end_date"], SystemVariables.gSystemDateFormat) + "' as smalldatetime)";
			mysql = mysql + " order by affect_cost desc, affect_opening_value desc ";
			mysql = mysql + " , affect_on_hand_stock desc, add_or_less asc, module_id asc";

			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLocalRec.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsLocalRec.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsLocalRec.Tables.Clear();
			adap.Fill(rsLocalRec);
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLocalRec.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsLocalRec.setActiveConnection(null);
			foreach (DataRow iteration_row in rsLocalRec.Tables[0].Rows)
			{
				SystemICSProcedure.PostTransactionToGL("ICS_Transaction", Convert.ToInt32(iteration_row["entry_id"]), true);

				if (!SystemICSProcedure.PostSerialItems(Convert.ToInt32(iteration_row["voucher_type"]), Convert.ToInt32(iteration_row["entry_id"])))
				{
					MessageBox.Show("Serialized items posting failed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return;
				}
				//**--post the linked assembly group vouchers
				SystemICSProcedure.PostLinkedAssemblyGroupProduct(Convert.ToInt32(iteration_row["voucher_type"]), Convert.ToInt32(iteration_row["entry_id"]), true, true, true, true, true);

				//        Call ProcessTransactionYearEnd("ICS_Transaction", .Fields("entry_id").Value)

			}

			//**--process transactions year end
			mysql = " update ICS_Transaction ";
			mysql = mysql + " set transaction_year_closed = 1 ";
			mysql = mysql + " where transaction_year_closed = 0 ";
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " and voucher_date >= cast('" + StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["current_period_start_date"], SystemVariables.gSystemDateFormat) + "' as smalldatetime)";
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " and voucher_date <= cast('" + StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["current_period_end_date"], SystemVariables.gSystemDateFormat) + "' as smalldatetime);";

			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();
			//**----------------------------------------------------------------------------

		}

		private void YearEndPostGLTransactions()
		{

			//**------------------------------------------------------------------------------------
			//**--change the status of accnt voucher to posted
			string mysql = " update gl_accnt_trans ";
			mysql = mysql + " set status = 2 ";
			mysql = mysql + " where status = 1 ";
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " and voucher_date >= cast('" + StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["current_period_start_date"], SystemVariables.gSystemDateFormat) + "' as smalldatetime)";
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " and voucher_date <= cast('" + StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["current_period_end_date"], SystemVariables.gSystemDateFormat) + "' as smalldatetime)";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();


			//**--close the year for the transactions
			mysql = " update gl_accnt_trans ";
			mysql = mysql + " set transaction_year_closed = 1 ";
			mysql = mysql + " where transaction_year_closed = 0 ";
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " and voucher_date >= cast('" + StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["current_period_start_date"], SystemVariables.gSystemDateFormat) + "' as smalldatetime)";
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " and voucher_date <= cast('" + StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["current_period_end_date"], SystemVariables.gSystemDateFormat) + "' as smalldatetime)";
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();
			//**------------------------------------------------------------------------------------
		}

		private void UpdateCompanySystemYear(int pCompID)
		{
			//'''update the current year and next year dates


			//**------------------------------------------------------------------------------------
			//**--update the Company table
			string mysql = " update SM_COMPANY ";
			mysql = mysql + " set current_period_start_date = next_period_start_date ";
			mysql = mysql + " , current_period_end_date = next_period_end_date ";
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " , next_period_start_date ='" + StringsHelper.Format(Convert.ToDateTime(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["next_period_start_date"]).AddYears(1), SystemVariables.gSystemDateFormat) + "'";
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mysql = mysql + " , next_period_end_date ='" + StringsHelper.Format(Convert.ToDateTime(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["next_period_end_date"]).AddYears(1), SystemVariables.gSystemDateFormat) + "'";
			mysql = mysql + " where comp_id = " + Conversion.Str(pCompID);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();
			//**------------------------------------------------------------------------------------

		}


		private void CloseYear()
		{
			string mysql = "";
			string mCapitalAccountCode = "";
			int mCapitalAccountCostCd = 0;
			int mVoucherType = 0;
			DialogResult ans = (DialogResult) 0;

			object mReturnValue = null;


			try
			{

				clsHourGlass myHourGlass = null;
				myHourGlass = new clsHourGlass();

				//****'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				//Caution message box
				ans = MessageBox.Show("Are you sure, you want to close the year?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (ans == System.Windows.Forms.DialogResult.No)
				{
					return;
				}

				//****'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


				//****'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				//Get the Ledger Code for Capital Account , Profit And loss A.c, voucher Type
				if (!SystemProcedure2.IsItEmpty(txtCommonSearch[conCapitalAccountName].Text, SystemVariables.DataType.StringType))
				{
					mysql = " select ldgr_cd, default_cost_cd from gl_ledger where ldgr_no='" + txtCommonSearch[conCapitalAccountName].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Ledger Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommonSearch[conCapitalAccountName].Focus();
						return;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCapitalAccountCode = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(1)))
							{
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mCapitalAccountCostCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
							}
							else
							{
								MessageBox.Show("Define Default cost code for capital account.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								return;
							}
						}
						else
						{
							mCapitalAccountCostCd = 1;
						}
					}
				}
				else
				{
					MessageBox.Show("Invalid Ledger Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonSearch[conCapitalAccountName].Focus();
					return;
				}

				//If Not IsItEmpty(txtCommonSearch(conProfitLossAccountName).Text, StringType) Then
				//    mysql = " select ldgr_cd from gl_ledger where ldgr_no='" & txtCommonSearch(conProfitLossAccountName).Text & "'"
				//    mReturnValue = GetMasterCode(mysql)
				//    If IsNull(mReturnValue) Then
				//        MsgBox "Invalid Ledger Code", vbInformation
				//        txtCommonSearch(conProfitLossAccountName).SetFocus
				//        Exit Sub
				//    Else
				//        mProfitandLossAccountCode = mReturnValue
				//    End If
				//Else
				//    MsgBox "Invalid Ledger Code", vbInformation
				//    txtCommonSearch(conProfitLossAccountName).SetFocus
				//    Exit Sub
				//End If

				if (!SystemProcedure2.IsItEmpty(txtCommonSearch[conVoucherType].Text, SystemVariables.DataType.StringType))
				{
					mysql = " select voucher_type from gl_accnt_voucher_types where voucher_type=" + txtCommonSearch[conVoucherType].Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Voucher Type", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommonSearch[conVoucherType].Focus();
						return;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mVoucherType = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				else
				{
					MessageBox.Show("Invalid Voucher Type", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonSearch[conVoucherType].Focus();
					return;
				}
				//****'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


				SystemVariables.gConn.BeginTransaction();
				//**--year close for all the ics voucher type transactions
				YearEndPostICSTransactions();
				//**--year close for all the gl voucher type transactions
				YearEndPostGLTransactions();

				//**--Generate the final year close entry
				GenerateGLVoucherEntry(mVoucherType, mCapitalAccountCode, mCapitalAccountCostCd);

				UpdateCompanySystemYear(SystemVariables.gCompanyID);


				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				MessageBox.Show("Closing of the year has been done successfully, Restart the application to work in the new year", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				Environment.Exit(0);
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, "frmSysYearClose", "GetRecord", SystemConstants.msg10);
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
					//    If pForm.txtCommonTextBox(Index).Enabled = True Then
					//       pForm.txtCommonTextBox(Index).SetFocus
					//    End If
				}
				else
				{
					//
				}

				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}


		}

		private void GenerateGLVoucherEntry(int pVoucherType, string pCapitalAccountCode, int pCapitalAccountCostCode)
		{

			double mNetProfitAndLoss = 0;

			int mCnt = 0;
			int mDebitLineNo = 0;
			int mCreditLineNo = 0;

			int mVoucherNo = 0;
			int mNewEntryID = 0;

			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			bool mCostCenterEnabled = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center"));

			string mysql = " select isnull(sum(lc_amount), 0) as VoucherAmt ";
			mysql = mysql + " , atd.ldgr_cd ";
			mysql = mysql + " , atd.cost_cd  ";
			mysql = mysql + " from gl_accnt_trans_details atd";
			mysql = mysql + " inner join gl_accnt_trans mt on atd.entry_id = mt.entry_id";
			mysql = mysql + " inner join gl_ledger l on atd.ldgr_cd = l.ldgr_cd";
			mysql = mysql + " inner join gl_accnt_types gat on l.type_cd = gat.type_cd ";
			mysql = mysql + " Where ";
			mysql = mysql + " gat.report_group = " + SystemGLConstants.gGLIncomeExpenseTypeCode.ToString();
			mysql = mysql + " and mt.voucher_date >= cast('" + StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["current_period_start_date"], SystemVariables.gSystemDateFormat) + "' as smalldatetime)";
			mysql = mysql + " and mt.voucher_date <= cast('" + StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["current_period_end_date"], SystemVariables.gSystemDateFormat) + "' as smalldatetime)";
			mysql = mysql + " and mt.status <> 3";
			mysql = mysql + " group by atd.ldgr_cd ";
			mysql = mysql + " , atd.cost_cd  ";


			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			if (rsTempRec.Read())
			{

				mysql = " voucher_type = " + pVoucherType.ToString();
				mVoucherNo = Convert.ToInt32(Double.Parse(SystemProcedure2.GetNewNumber("gl_accnt_trans", "voucher_no", 0, mysql, " tablock(xlock) ")));

				mysql = " insert into gl_accnt_trans(voucher_type, voucher_date, voucher_no, ";
				mysql = mysql + " status, comments, user_cd) ";
				mysql = mysql + " values (";
				mysql = mysql + pVoucherType.ToString();
				mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
				mysql = mysql + "," + mVoucherNo.ToString();
				mysql = mysql + ",2";
				mysql = mysql + ",'Year Closing Auto Generated Profit and Loss entry'";
				mysql = mysql + "," + SystemVariables.gLoggedInUserCode.ToString() + ")";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mNewEntryID = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
				mDebitLineNo = 0;
				mCreditLineNo = 0;

				do 
				{
					if (Convert.ToDouble(rsTempRec["voucheramt"]) != 0)
					{
						mNetProfitAndLoss += Convert.ToDouble(rsTempRec["voucheramt"]);
						mCnt++;

						//''entry for all the income and expenses account.
						//''if the voucheramt is dr then pass the entry in cr.
						mysql = " insert into gl_accnt_trans_details (entry_id, ldgr_cd ";
						mysql = mysql + " , cost_cd ";
						mysql = mysql + " , lc_amount, dr_cr_line_no, dr_cr_type ";
						mysql = mysql + " , fc_amount, due_date)";
						mysql = mysql + " values (";
						mysql = mysql + Conversion.Str(mNewEntryID);
						mysql = mysql + "," + Convert.ToString(rsTempRec["ldgr_cd"]);

						if (!Convert.IsDBNull(rsTempRec["cost_cd"]))
						{
							mysql = mysql + "," + Convert.ToString(rsTempRec["cost_cd"]);
						}
						else
						{
							mysql = mysql + ", 1 ";
						}

						mysql = mysql + "," + Conversion.Str(Convert.ToDouble(rsTempRec["voucheramt"]) * -1);

						//mysql = mysql & " ," & Str(mCnt)

						//''if greater than 0 than credit side
						if (Convert.ToDouble(rsTempRec["voucheramt"]) > 0)
						{
							mCreditLineNo++;
							mysql = mysql + " ," + Conversion.Str(mCreditLineNo);
							mysql = mysql + " , 'C' ";
						}
						else
						{
							mDebitLineNo++;
							mysql = mysql + " ," + Conversion.Str(mDebitLineNo);
							mysql = mysql + " , 'D' ";
						}

						mysql = mysql + "," + Conversion.Str(Convert.ToDouble(rsTempRec["voucheramt"]) * -1);
						mysql = mysql + ",'" + StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["next_period_start_date"], SystemVariables.gSystemDateFormat) + "')";
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();
					}

				}
				while(rsTempRec.Read());

				if (Math.Abs(mNetProfitAndLoss) > 0)
				{
					//'''Create and entry with the total balance
					//'''for retained earning account or capital account.
					mysql = " insert into gl_accnt_trans_details (entry_id, ldgr_cd, cost_cd ";
					mysql = mysql + " , lc_amount, dr_cr_line_no, dr_cr_type ";
					mysql = mysql + " , fc_amount, due_date)";
					mysql = mysql + " values (";
					mysql = mysql + Conversion.Str(mNewEntryID);
					mysql = mysql + "," + pCapitalAccountCode;
					mysql = mysql + "," + pCapitalAccountCostCode.ToString();
					mysql = mysql + "," + Conversion.Str(mNetProfitAndLoss);

					//mysql = mysql & " ," & (mCnt + 1)

					//''if greater than 0 than Debit side
					if (mNetProfitAndLoss > 0)
					{
						mDebitLineNo++;
						mysql = mysql + " ," + Conversion.Str(mDebitLineNo);
						mysql = mysql + " , 'D' ";
					}
					else
					{
						mCreditLineNo++;
						mysql = mysql + " ," + Conversion.Str(mCreditLineNo);
						mysql = mysql + " , 'C' ";
					}

					mysql = mysql + " ," + Conversion.Str(mNetProfitAndLoss);
					mysql = mysql + ",'" + StringsHelper.Format(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["next_period_start_date"], SystemVariables.gSystemDateFormat) + "')";
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();
				}
			}
		}
	}
}