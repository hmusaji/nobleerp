
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSALCustomerCallLog
		: System.Windows.Forms.Form
	{

		public frmSALCustomerCallLog()
{
InitializeComponent();
} 
 public  void frmSALCustomerCallLog_old()
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


		private void frmSALCustomerCallLog_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private int mThisFormID = 0;
		private object mSearchValue = null;
		int mEntryId = 0;

		
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

		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		public Control FirstFocusObject = null;

		private int mICSVocuherType = 0;
		private int mCrystalID = 0;
		private bool mUseNumToChar = false;
		int mSourceLineEntryId = 0;
		int mInvoiceEntryId = 0;
		int mSManCd = 0;
		private string mTimeStamp = "";

		private DataSet recCloneDetail = null;
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

		private int mRecordNavigateSearchValue = 0;



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


		//Public Sub PrintReport()
		//Dim mysql As String
		//Dim mReportId As Long
		//Dim mVoucherAmount As Currency
		//
		//    If mEntryId <> 0 Then
		//        mysql = " select top 1 Report_Id from gl_print_task_detail "
		//        mysql = mysql & "where (voucher_type = " & GetMasterCode("select voucher_type from GL_Accnt_Trans where entry_id = " & mEntryId) & ")"
		//        mReportId = GetMasterCode(mysql)
		//
		//        If Not IsNull(mReportId) Then
		//            mysql = " select sum(lc_amount) from gl_accnt_trans_details "
		//            mysql = mysql & " where lc_amount> 0 "
		//            mysql = mysql & " and entry_id = " & Str(mEntryId)
		//            mVoucherAmount = GetMasterCode(mysql)
		//
		//            Call frmGLTransaction.PrintGLCrystalReport(mEntryId, mReportId, mVoucherAmount)
		//        End If
		//    Else
		//        MsgBox "Please save transaction before print", vbInformation
		//    End If
		//End Sub

		public bool saveRecord()
		{
			bool result = false;
			try
			{
				string mSQL = "";
				object mReturnValue = null;
				int mSManCd = 0;
				int mCustomerLdgrCd = 0;
				string mVoucherNo = "";
				System.DateTime mVoucherDate = DateTime.FromOADate(0);
				int mNewEntryID = 0;
				int Cnt = 0;
				string mysql = "";

				//    If MsgBox("Do you want to save?", vbInformation + vbYesNo) = vbNo Then
				//        txtSalesInvoiceNo.SetFocus
				//        Exit Sub
				//    End If

				if (txtCustomerCode.Text == "")
				{
					MessageBox.Show("Please enter Customer Code.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCustomerCode.Focus();
					return result;
				}

				if (txtVoucherDate.Text == "")
				{
					MessageBox.Show("Please enter Voucher Date.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtVoucherDate.Focus();
					return result;
				}

				mSQL = "select ldgr_cd from gl_ledger where ldgr_no ='" + txtCustomerCode.Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCustomerLdgrCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					MessageBox.Show("Invalid Customer selected.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCustomerCode.Focus();
					return result;
				}

				mSQL = "select sman_cd from SM_SALESMAN where Sman_No ='" + txtSalesmanCode.Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSManCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					//        MsgBox "Invalid Salesman selected.", vbInformation
					//        txtSalesmanCode.SetFocus
					//        Exit Function
				}

				if (txtVoucherNo.Text == "")
				{
					MessageBox.Show("Please enter Voucher No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtVoucherNo.Focus();
					return result;
				}
				else
				{
					//        mSQL = " select * from gl_accnt_trans where voucher_no = '" & txtVoucherNo.Text & "' and voucher_type  = " & txtVoucherCode.Text
					//        mReturnValue = GetMasterCode(mSQL)
					//        If Not IsNull(mReturnValue) Then
					//            If MsgBox("Voucher No. already exists." & Chr(13) & "(Yes) To generate an automated Voucher No." & Chr(13) & "(No) To enter manually.", vbInformation + vbYesNo) = vbYes Then
					//                Call GetNewGLVoucherNo(Val(txtVoucherCode.Text))
					//            Else
					//                txtVoucherNo.SetFocus
					//                Exit Sub
					//            End If
					//        End If
				}

				SystemVariables.gConn.BeginTransaction();
				//grdVoucherDetails.Update
				string mCheckTimeStamp = "";

				mysql = " select time_stamp from SAL_Customer_Call_Entry where Entry_Id = '" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue) && (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp)))
				{
					MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					result = false;
					FirstFocusObject.Focus();
					return result;
				}


				DataSet rsGetEntryId = null;
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into SAL_Customer_Call_Entry ( Voucher_No, Ldgr_Cd, Voucher_Date, Call_Date ";
					mysql = mysql + " , Sman_Cd, CallTime, CallRcvrTime, Remarks, Remarks2, user_cd )";
					mysql = mysql + " values ( ";
					mysql = mysql + "'" + Conversion.Str(txtVoucherNo.Text).Trim() + "',";
					mysql = mysql + mCustomerLdgrCd.ToString() + ",";
					mysql = mysql + "'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "',";
					mysql = mysql + "'" + ReflectionHelper.GetPrimitiveValue<string>(txtCallDate.Value) + "',";
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mysql = mysql + ((Convert.IsDBNull(mSManCd)) ? "Null" : mSManCd.ToString()) + ",'" + cmbCallTime.Text + "','" + Convert.ToString(txtCallRcvrTime.Value) + "',";
					mysql = mysql + "N'" + txtComment.Text + "', N'" + txtComment2.Text + "', " + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = "select scope_identity()";
					SqlDataAdapter TempAdapter_2 = null;
					TempAdapter_2 = new SqlDataAdapter();
					TempAdapter_2.SelectCommand = TempCommand_2;
					DataSet TempDataset_2 = null;
					TempDataset_2 = new DataSet();
					TempAdapter_2.Fill(TempDataset_2);
					rsGetEntryId = TempDataset_2;
					if (rsGetEntryId.Tables[0].Rows.Count != 0)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mNewEntryID = Convert.ToInt32(rsGetEntryId.Tables[0].Rows[0][0]);
						mSearchValue = mNewEntryID;
					}
					else
					{
						MessageBox.Show("Error : Can not proceed with save!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}
					rsGetEntryId = null;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mNewEntryID = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);

					mysql = " update SAL_Customer_Call_Entry ";
					mysql = mysql + " set Ldgr_Cd = " + mCustomerLdgrCd.ToString() + "";
					mysql = mysql + " , Voucher_Date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
					mysql = mysql + " , Call_Date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtCallDate.Value) + "'";
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mysql = mysql + " , Sman_Cd = " + ((Convert.IsDBNull(mSManCd)) ? "Null" : mSManCd.ToString());
					mysql = mysql + " , CallTime = '" + cmbCallTime.Text + "'";
					mysql = mysql + " , CallRcvrTime = '" + Convert.ToString(txtCallRcvrTime.Value) + "'";
					mysql = mysql + " , Remarks = N'" + txtComment.Text + "'";
					mysql = mysql + " , Remarks2 = N'" + txtComment2.Text + "'";
					mysql = mysql + " where entry_id = " + Conversion.Str(mSearchValue);

					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();
				}
				//
				//        mysql = "delete SAL_Customer_Call_Entry_Details "
				//        mysql = mysql + " where Entry_Id = " & mSearchValue
				//
				//        gConn.Execute (mysql)
				//
				//    For Cnt = 0 To aVoucherDetails.Count(1) - 1
				//        mysql = "INSERT INTO SAL_Customer_Call_Entry_Details(Entry_Id, Line_No, Remarks, User_cd ) "
				//        mysql = mysql & " VALUES("
				//        mysql = mysql & mSearchValue & ","
				//        mysql = mysql & aVoucherDetails(Cnt, 0) & ","
				//        mysql = mysql & "'" & aVoucherDetails(Cnt, 1) & "',"
				//        mysql = mysql & Str(gLoggedInUserCode) & ")"
				//
				//        gConn.Execute (mysql)
				//    Next

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				//FirstFocusObject.SetFocus
				return true;
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

		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);
			txtVoucherNo.Text = SystemProcedure2.GetNewNumber("SAL_Customer_Call_Entry", "Voucher_No");
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			txtCallRcvrTime.Value = "12:00:00 AM";
			cmbCallTime.Text = "AM";
			txtVoucherDate.Value = SystemVariables.gCurrentDate;
			txtCallDate.Value = SystemVariables.gCurrentDate;

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "mAssign_value");
		}

		public void CloseForm()
		{
			this.Close();
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//''(Alt + -> ) or ( Alt + <- )
				if (Shift == 4 && (KeyCode == 37 || KeyCode == 39))
				{
					if (!UserAccess.AllowUserDisplay)
					{
						MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					RecordNavidate(KeyCode, mRecordNavigateSearchValue);
					KeyCode = 0;
				}

				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void Form_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				if (KeyAscii == 13 && this.ActiveControl.Name != "txtComment" && this.ActiveControl.Name != "txtComment2")
				{
					SendKeys.Send("{Tab}");
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					return;
				}
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{



			this.Top = 0;
			this.Left = 0;

			//**--format & define the new toolbar]]]][87777765
			oThisFormToolBar = new clsToolbar();

			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			oThisFormToolBar.ShowNewButton = true;
			oThisFormToolBar.ShowSaveButton = true;
			//.ShowPrintButton = True
			oThisFormToolBar.BeginFindButtonWithGroup = true;
			oThisFormToolBar.ShowFindButton = true;
			oThisFormToolBar.ShowMoveRecordPreviousButton = true;
			oThisFormToolBar.ShowMoveRecordNextButton = true;
			oThisFormToolBar.ShowDeleteButton = true;
			oThisFormToolBar.BeginDeleteButtonWithGroup = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.ShowExitButton = true;

			this.WindowState = FormWindowState.Maximized;

			this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //setting form mode to add initially
			txtVoucherDate.Value = SystemVariables.gCurrentDate;
			txtCallDate.Value = SystemVariables.gCurrentDate;

			//Cash & Bank Code
			string mSQL = " select ldgr_no, l_ldgr_name from gl_ledger where ldgr_cd = '" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("cash_bank_cd_in_delivery")) + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{

			}

			FirstFocusObject = txtCustomerCode;

			cmbCallTime.AddItem("AM");
			cmbCallTime.AddItem("PM");
			cmbCallTime.AddItem("Any Time");

			cmbCallTime.Text = "AM";

			GetNextNumber();
		}

		private void GetNextNumber()
		{
			//Get the maximum + 1 accnt_group code
			txtVoucherNo.Text = SystemProcedure2.GetNewNumber("SAL_Customer_Call_Entry", "Voucher_No");
		}

		private void txtCustomerCode_DropButtonClick(Object Sender, EventArgs e)
		{
			string mFindWhereClause = " l.type_cd =" + SystemGLConstants.gGLCustomerVendorTypeCode.ToString();

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFindWhereClause));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCustomerCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				txtCustomerCode_Leave(txtCustomerCode, new EventArgs());
			}
		}

		private void txtCustomerCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (txtCustomerCode.Text == "")
			{
				return;
			}
			string mSQL = " select ldgr_cd," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Ldgr_Name" : "A_Ldgr_Name") + " as LedgerName from gl_ledger where ldgr_no ='" + txtCustomerCode.Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				//MsgBox "Invalid Customer Code selected.", vbExclamation
				//txtCustomerCode.SetFocus
				txtCustomerCode.Text = "";
				txtCustomerName.Text = "";

				return;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCustomerName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));

			}
		}

		private void txtSalesmanCode_DropButtonClick(Object Sender, EventArgs e)
		{
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1004000, "88"));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtSalesmanCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				txtSalesmanCode_Leave(txtSalesmanCode, new EventArgs());
			}
		}

		private void txtSalesmanCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (txtSalesmanCode.Text == "")
			{
				return;
			}
			string mSQL = " select Sman_Cd, " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Sman_Name" : "A_Sman_Name") + " as sman_name from SM_SALESMAN where Sman_No ='" + txtSalesmanCode.Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				//MsgBox "Invalid Salesman Code selected.", vbExclamation
				//txtSalesmanCode.SetFocus
				txtSalesmanCode.Text = "";
				txtSalesmanName.Text = "";

				return;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtSalesmanName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));

			}
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2009020));
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
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			string mysql = "";

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				localRec = null;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
				if (Object.Equals(mSearchValue, null) || Convert.IsDBNull(mSearchValue) || ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) == "")
				{
					return;
				}

				try
				{

					mysql = " select CCE.*, l.ldgr_no, s.sman_no, " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l.L_Ldgr_Name" : "l.A_Ldgr_Name") + " as LedgerName, ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "S.L_Sman_Name" : "S.A_Sman_Name") + " as SalesmanName";
					mysql = mysql + " from SAL_Customer_Call_Entry CCE left outer join GL_Ledger l on CCE.Ldgr_Cd = l.ldgr_cd";
					mysql = mysql + " left outer join SM_SALESMAN S on CCE.Sman_Cd = S.Sman_Cd where CCE.Entry_Id ='" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue) + "'";

					//mysql = " select * from SM_Salesman where sman_cd=" & mSearchValue
					SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
					localRec.Tables.Clear();
					adap.Fill(localRec);
					DataSet withVar = null;
					withVar = localRec;
					if (withVar.Tables[0].Rows.Count != 0)
					{
						//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mRecordNavigateSearchValue = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtVoucherDate.Value = withVar.Tables[0].Rows[0]["Voucher_Date"];
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtVoucherNo.Text = Convert.ToString(withVar.Tables[0].Rows[0]["Voucher_No"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCallDate.Value = Convert.ToString(withVar.Tables[0].Rows[0]["Call_Date"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCallRcvrTime.Value = Convert.ToString(withVar.Tables[0].Rows[0]["CallRcvrTime"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						cmbCallTime.Text = Convert.ToString(withVar.Tables[0].Rows[0]["CallTime"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtComment.Text = Convert.ToString(withVar.Tables[0].Rows[0]["Remarks"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtComment2.Text = Convert.ToString(withVar.Tables[0].Rows[0]["Remarks2"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCustomerCode.Text = Convert.ToString(withVar.Tables[0].Rows[0]["ldgr_no"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCustomerName.Text = Convert.ToString(withVar.Tables[0].Rows[0]["LedgerName"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtSalesmanCode.Text = Convert.ToString(withVar.Tables[0].Rows[0]["sman_no"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtSalesmanName.Text = Convert.ToString(withVar.Tables[0].Rows[0]["SalesmanName"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mTimeStamp = Convert.ToString(withVar.Tables[0].Rows[0]["Time_Stamp"]);
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

		public void ORoutine()
		{

			if (!UserAccess.AllowUserDisplay)
			{
				MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			RecordNavidate(39, mRecordNavigateSearchValue);

		}

		public void MRoutine()
		{

			if (!UserAccess.AllowUserDisplay)
			{
				MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			RecordNavidate(37, mRecordNavigateSearchValue);


		}

		private void RecordNavidate(int pKeyCode, int pEntryId)
		{

			string mysql = " select top 1 Entry_Id from SAL_Customer_Call_Entry ";
			mysql = mysql + " where 1=1 ";
			if (pEntryId > 0 && pKeyCode == 37)
			{
				mysql = mysql + " and Entry_Id < " + pEntryId.ToString();
			}
			else if (pEntryId > 0 && pKeyCode == 39)
			{ 
				mysql = mysql + " and Entry_Id > " + pEntryId.ToString();
			}

			if (pKeyCode == 37)
			{
				mysql = mysql + " order by Voucher_No desc ";
			}
			else if (pKeyCode == 39)
			{ 
				mysql = mysql + " order by Voucher_No asc ";
			}

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(mReturnValue);
				GetRecord(mReturnValue);
			}

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

				mysql = "delete from SAL_Customer_Call_Entry where Entry_Id =" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Entry cannot be deleted", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}

				//'''Donot allow to delete or modify the record if the information exists in the ST_OFFLINE_DETAILS
				mysql = " select comp_id from ST_OFFLINE_DETAILS ";
				mysql = mysql + " where table_name = 'SAL_Customer_Call_Entry' ";
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

				return true;
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Entry_Id from SAL_Customer_Call_Entry where Voucher_No=" + txtVoucherNo.Text));
					GetRecord(mSearchValue);
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


		public void FindRoutine(string pObjectName)
		{
			object mReturnValue = null;
			string mFindWhereClause = "";

			string mObjectName = pObjectName;
			//mIndex = CInt(Mid(pObjectName, InStr(1, pObjectName, "#", vbTextCompare) + 1))

			if (mObjectName == "txtCustomerCode")
			{
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFindWhereClause));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCustomerCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					txtCustomerCode_Leave(txtCustomerCode, new EventArgs());
				}
			}

			if (mObjectName == "txtSalesmanCode")
			{
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1004000, "88"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtSalesmanCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					txtSalesmanCode_Leave(txtSalesmanCode, new EventArgs());
				}
			}
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}