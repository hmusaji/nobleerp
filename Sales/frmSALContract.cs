
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSALContract
		: System.Windows.Forms.Form
	{

		public frmSALContract()
{
InitializeComponent();
} 
 public  void frmSALContract_old()
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
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			
		}


		private void frmSALContract_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private const int mLineNoColumn = 0;
		private const int mDateColumn = 1;
		private const int mAmountColumn = 2;
		private const int mPrintedColumn = 3;
		private const int mPaidColumn = 4;
		private const int mPaidDateColumn = 5;
		private const int mRemarkColumn = 6;
		private const int mMaxArrayCols = 6;

		private DataSet recDetail = null;
		private DataSet recCloneDetail = null;
		private XArrayHelper _aVoucherDetails = null;
		private XArrayHelper aVoucherDetails
		{
			get
			{
				if (_aVoucherDetails is null)
				{
					_aVoucherDetails = new XArrayHelper();
				}
				return _aVoucherDetails;
			}
			set
			{
				_aVoucherDetails = value;
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


		public void PrintReport()
		{
			int mEntryId = 0;

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
			}
			else
			{
				return;
			}
			SystemReports.GetCrystalReport(100060162, 2, "10857", Conversion.Str(mEntryId), false);
		}

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
				int cnt = 0;
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

				if (ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) == "")
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

				//    If txtContractNo.Text = "" Then
				//        MsgBox "Please enter Contract No.", vbInformation
				//        txtContractNo.SetFocus
				//        Exit Function
				//    Else
				//            If mCurrentFormMode = frmAddMode Then
				//                mSQL = " select * from SAL_Sales_Contract where Contract_No = '" & txtContractNo.Text & "'"
				//                mReturnValue = GetMasterCode(mSQL)
				//                If Not IsNull(mReturnValue) Then
				//                    If MsgBox("Contract No. already exists." & Chr(13) & "(Yes) To generate an automated Contract No." & Chr(13) & "(No) To enter manually.", vbInformation + vbYesNo) = vbYes Then
				//                        txtContractNo.Text = GetNewNumber("SAL_Sales_Contract", "Contract_No")
				//                    Else
				//                        txtContractNo.SetFocus
				//                        Exit Function
				//                    End If
				//                End If
				//            End If
				//    End If

				if (ReflectionHelper.GetPrimitiveValue<string>(txtInstallmentStartDate.Value) == "")
				{
					MessageBox.Show("Please enter Installment Start Date.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtInstallmentStartDate.Focus();
					return result;
				}

				SystemVariables.gConn.BeginTransaction();
				grdVoucherDetails.UpdateData();
				string mCheckTimeStamp = "";

				mysql = " select time_stamp from SAL_Sales_Contract where Entry_Id = '" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";
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
					mysql = " insert into SAL_Sales_Contract ( Voucher_No, Ldgr_Cd, Contract_Date ";
					mysql = mysql + " , Amount, Discount, Down_Payment, Remaining_Amount, Installments, Installment_Start_Date, Remarks, user_cd )";
					mysql = mysql + " values ( ";
					mysql = mysql + "'" + Conversion.Str(txtVoucherNo.Text).Trim() + "',";
					mysql = mysql + mCustomerLdgrCd.ToString() + ",";
					mysql = mysql + "'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "',";
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(txtAmount.Value) + "," + ReflectionHelper.GetPrimitiveValue<string>(txtDiscount.Value) + "," + ReflectionHelper.GetPrimitiveValue<string>(txtDownPayment.Value) + ",";
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(txtRemainingAmount.Value) + "," + ReflectionHelper.GetPrimitiveValue<string>(txtInstallments.Value) + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtInstallmentStartDate.Value) + "',";
					mysql = mysql + "N'" + txtComment.Text + "', " + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";

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

					mysql = " update SAL_Sales_Contract ";
					mysql = mysql + " set Ldgr_Cd = " + mCustomerLdgrCd.ToString() + "";
					mysql = mysql + " , Contract_Date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
					mysql = mysql + " , Amount = " + ReflectionHelper.GetPrimitiveValue<string>(txtAmount.Value);
					mysql = mysql + " , Discount = " + ReflectionHelper.GetPrimitiveValue<string>(txtDiscount.Value);
					mysql = mysql + " , Down_Payment = " + ReflectionHelper.GetPrimitiveValue<string>(txtDownPayment.Value);
					mysql = mysql + " , Remaining_Amount = " + ReflectionHelper.GetPrimitiveValue<string>(txtRemainingAmount.Value);
					mysql = mysql + " , Installments = " + ReflectionHelper.GetPrimitiveValue<string>(txtInstallments.Value);
					mysql = mysql + " , Installment_Start_Date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtInstallmentStartDate.Value) + "'";
					mysql = mysql + " , Remarks = N'" + txtComment.Text + "'";
					mysql = mysql + " where entry_id = " + Conversion.Str(mSearchValue);

					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();
				}

				mysql = "delete SAL_Sales_Contract_Details ";
				mysql = mysql + " where Entry_Id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					mysql = "INSERT INTO SAL_Sales_Contract_Details(Entry_Id, Installment_No, Installment_Date, Paid_Date, Amount, Is_Printed, Is_Paid, Remarks, User_cd ) ";
					mysql = mysql + " VALUES(";
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ",";
					mysql = mysql + Convert.ToString(aVoucherDetails.GetValue(cnt, mLineNoColumn)) + ",";
					mysql = mysql + "'" + StringsHelper.Format(aVoucherDetails.GetValue(cnt, mDateColumn), SystemVariables.gSystemDateFormat) + "',";
					mysql = mysql + "" + ((Convert.ToString(aVoucherDetails.GetValue(cnt, mPaidDateColumn)) == "") ? "Null" : "'" + StringsHelper.Format(aVoucherDetails.GetValue(cnt, mPaidDateColumn), SystemVariables.gSystemDateFormat) + "'") + ",";
					mysql = mysql + "" + Convert.ToString(aVoucherDetails.GetValue(cnt, mAmountColumn)) + ",";
					mysql = mysql + "" + ((Convert.ToBoolean(aVoucherDetails.GetValue(cnt, mPrintedColumn))) ? "1" : "0") + ",";
					mysql = mysql + "" + ((Convert.ToBoolean(aVoucherDetails.GetValue(cnt, mPaidColumn))) ? "1" : "0") + ",";
					mysql = mysql + "N'" + Convert.ToString(aVoucherDetails.GetValue(cnt, mRemarkColumn)) + "',";
					mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";

					SqlCommand TempCommand_5 = null;
					TempCommand_5 = SystemVariables.gConn.CreateCommand();
					TempCommand_5.CommandText = mysql;
					TempCommand_5.ExecuteNonQuery();
				}

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
			SystemProcedure2.ClearNumberBox(this);
			this.txtVoucherNo.Text = SystemProcedure2.GetNewNumber("SAL_Sales_Contract", "Voucher_No");

			this.txtVoucherDate.Value = SystemVariables.gCurrentDate;
			this.txtInstallmentStartDate.Value = SystemVariables.gCurrentDate;

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank


			//''''*************************************************************************
			//'''Grid settings
			grdVoucherDetails.Columns[mAmountColumn].FooterText = "";

			SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, true);
			AssignGridLineNumbers();
			grdVoucherDetails.Rebind(true);
			//''''*************************************************************************

			txtVoucherDate.Text = "";
			txtInstallmentStartDate.Text = "";
			ShowHideFields();
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "mAssign_value");
		}

		public void CloseForm()
		{
			this.Close();
		}

		private void cmdGenerate_Click(Object eventSender, EventArgs eventArgs)
		{

			int installments = 0;
			double installmentAmount = 0;

			if (ReflectionHelper.GetPrimitiveValue<string>(txtInstallmentStartDate.Value) == "" || (ReflectionHelper.GetPrimitiveValue<double>(txtInstallments.Value) == 0 && ReflectionHelper.GetPrimitiveValue<double>(txtInstallmentAmount.Value) == 0))
			{

				return;

			}

			System.DateTime InstallmentStartDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtInstallmentStartDate.Value);

			int i = 0;
			if (ReflectionHelper.GetPrimitiveValue<double>(txtInstallments.Value) != 0)
			{
				installments = Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtInstallments.Value)));
				installmentAmount = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtRemainingAmount.Value)) / Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtInstallments.Value));
				txtInstallmentAmount.Value = installmentAmount;

			}
			else if (ReflectionHelper.GetPrimitiveValue<double>(txtInstallmentAmount.Value) != 0)
			{ 
				i = Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtRemainingAmount.Value)) / Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtInstallmentAmount.Value)));
				installments = i;
				installmentAmount = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtInstallmentAmount.Value));
				txtInstallments.Text = installments.ToString();
			}

			int cnt = 0;
			//    For Cnt = 1 To aVoucherDetails.Count(1) - 1
			//        grdVoucherDetails.Delete
			//        Call AssignGridLineNumbers
			//        grdVoucherDetails.ReBind
			//    Next
			SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, 0, true);
			grdVoucherDetails.Rebind(true);

			int tempForEndVar = installments - 1;
			for (cnt = 1; cnt <= tempForEndVar; cnt++)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), 1);
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
			}


			int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar2; cnt++)
			{
				aVoucherDetails.SetValue(InstallmentStartDate.AddMonths(cnt), cnt, mDateColumn);
				aVoucherDetails.SetValue(StringsHelper.Format(installmentAmount, "#########.000"), cnt, mAmountColumn);
			}

			CalculateTotals();
			grdVoucherDetails.Refresh();
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
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
					return;
				}
				catch
				{
				}
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
				if (KeyAscii == 13)
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

			string mSQL = "";

			object mReturnValue = null;

			this.Top = 0;
			this.Left = 0;

			//**--format & define the new toolbar]]]][87777765
			oThisFormToolBar = new clsToolbar();

			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			oThisFormToolBar.ShowNewButton = true;
			oThisFormToolBar.ShowSaveButton = true;
			oThisFormToolBar.ShowPrintButton = true;
			oThisFormToolBar.BeginFindButtonWithGroup = true;
			oThisFormToolBar.ShowFindButton = true;
			oThisFormToolBar.ShowMoveRecordPreviousButton = true;
			oThisFormToolBar.ShowMoveRecordNextButton = true;
			oThisFormToolBar.ShowDeleteButton = true;
			oThisFormToolBar.BeginDeleteButtonWithGroup = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.ShowDeleteLineButton = true;
			oThisFormToolBar.ShowInsertLineButton = true;
			oThisFormToolBar.BeginInsertLineButtonWithGroup = true;

			this.WindowState = FormWindowState.Maximized;

			this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //setting form mode to add initially
			txtVoucherDate.Value = SystemVariables.gCurrentDate;
			txtInstallmentStartDate.Value = SystemVariables.gCurrentDate;


			FirstFocusObject = txtCustomerCode;
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, (0xE7E2DC).ToString(), (0xE7E2DC).ToString());
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Date", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "Total", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "txtTempDate");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, true, false, 12, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Printed", 600, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Paid", 600, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Paid Date", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "txtTempDate");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1000, true);

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			withVar = grdVoucherDetails.Splits[0].DisplayColumns[mPrintedColumn];
			withVar.DataColumn.ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
			withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
			withVar.Visible = true;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			withVar_2 = grdVoucherDetails.Splits[0].DisplayColumns[mPaidColumn];
			withVar_2.DataColumn.ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
			withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
			withVar_2.Visible = true;

			aVoucherDetails = new XArrayHelper();
			SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, false);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);
			grdVoucherDetails.Rebind(true);

			txtTempDate.AlignHorizontal = TDBDate6.dbiAlignHConst.dbiAlignHLeft;
			txtTempDate.AlignVertical = TDBDate6.dbiAlignVConst.dbiAlignVCenter;
			txtTempDate.Appearance = TDBDate6.dbiAppearanceConst.dbiFlat;
			txtTempDate.BorderStyle = TDBDate6.dbiBorderStyleConst.dbiNoBorder;
			txtTempDate.CenturyMode = TDBDate6.dbiCenturyModeConst.dbiCurrentCentury;
			txtTempDate.Calendar.SelectStyle = TDBDate6.dbiCalndrSelStyleConst.dbiCalSelStyleFlatBtn;
			txtTempDate.Calendar.WeekTitles = "F,S,S,M,T,W,T";
			txtTempDate.CenturyMode = TDBDate6.dbiCenturyModeConst.dbiSystemCentury;
			txtTempDate.DisplayFormat = SystemVariables.gSystemDateFormat;
			txtTempDate.DropDown.Visible = TDBDate6.dbiVisibleConst.dbiShowOnFocus;
			txtTempDate.Format = SystemVariables.gSystemDateFormat;

			txtVoucherDate.Text = "";
			txtInstallmentStartDate.Text = "";

			GetNextNumber();
			ShowHideFields();
		}

		private void GetNextNumber()
		{
			//Get the maximum + 1 accnt_group code
			txtVoucherNo.Text = SystemProcedure2.GetNewNumber("SAL_Sales_Contract", "Voucher_No");
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				mRecordNavigateSearchValue = 0;

				recDetail = null;
				recCloneDetail = null;
				aVoucherDetails = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			grdVoucherDetails.UpdateData();

			CalculateTotals();
			grdVoucherDetails.Refresh();
			grdVoucherDetails.Refresh();
		}

		private void txtAmount_Leave(Object eventSender, EventArgs eventArgs)
		{
			CalculateAmount();
		}

		private void CalculateTotals()
		{
			double mTotalAmount = 0;
			int cnt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(StringsHelper.Format(aVoucherDetails.GetValue(cnt, mAmountColumn), "###,###,###,###.000"), cnt, mAmountColumn);
				mTotalAmount += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, mAmountColumn)));
			}

			if (mTotalAmount != 0)
			{
				if (mTotalAmount != Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtRemainingAmount.Value)))
				{
					aVoucherDetails.SetValue(StringsHelper.Format(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(aVoucherDetails.GetLength(0) - 1, mAmountColumn))) + Conversion.Val((Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtRemainingAmount.Value)) - mTotalAmount).ToString()), "#########.000"), aVoucherDetails.GetLength(0) - 1, mAmountColumn);
					mTotalAmount = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtRemainingAmount.Value));
				}
				grdVoucherDetails.Columns[mAmountColumn].FooterText = StringsHelper.Format(mTotalAmount, "###,###,###,###.000");
			}
			else
			{
				grdVoucherDetails.Columns[mAmountColumn].FooterText = "";
			}
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
			string mSQL = " select ldgr_cd, l_ldgr_Name, current_bal from gl_ledger where ldgr_no ='" + txtCustomerCode.Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				MessageBox.Show("Invalid Customer Code selected.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtCustomerCode.Focus();
				txtCustomerName.Text = "";

				return;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCustomerName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));

			}
		}

		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, mLineNoColumn);
			}
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			grdVoucherDetails.Columns[0].Text = (grdVoucherDetails.RowCount + 1).ToString();
		}

		private void txtDiscount_Leave(Object eventSender, EventArgs eventArgs)
		{
			CalculateAmount();
		}


		private void CalculateAmount()
		{
			txtNetAmount.Value = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtAmount.Value)) - Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtDiscount.Value));
			txtRemainingAmount.Value = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtNetAmount.Value)) - Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtDownPayment.Value));
		}

		private void txtDownPayment_Leave(Object eventSender, EventArgs eventArgs)
		{
			CalculateAmount();
		}


		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2009030));
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
			string mysql = "";
			SqlDataReader rsLocalRec = null;
			int cnt = 0;

			try
			{

				if (SystemProcedure2.IsItEmpty(SearchValue, SystemVariables.DataType.StringType))
				{
					return;
				}

				//Change the form mode to edit
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;

				mysql = " select sc.*, l.ldgr_no, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l.l_ldgr_name" : "l.a_ldgr_name") + " as ledger_name ";
				mysql = mysql + " from SAL_Sales_Contract sc inner join GL_Ledger l on l.Ldgr_Cd = sc.Ldgr_Cd ";
				mysql = mysql + " where sc.entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand.ExecuteReader();
				bool rsLocalRecDidRead = rsLocalRec.Read();
				cnt = 0;

				if (rsLocalRecDidRead)
				{
					//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mRecordNavigateSearchValue = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);

					mTimeStamp = Convert.ToString(rsLocalRec["time_stamp"]);
					txtCustomerCode.Text = Convert.ToString(rsLocalRec["ldgr_no"]);
					txtCustomerName.Text = Convert.ToString(rsLocalRec["ledger_name"]);
					txtVoucherDate.Value = Convert.ToString(rsLocalRec["Contract_Date"]) + "";
					txtVoucherNo.Text = Convert.ToString(rsLocalRec["Voucher_No"]);
					//txtContractNo.Text = .Fields("Contract_No")
					txtAmount.Value = rsLocalRec["Amount"];
					txtDiscount.Value = rsLocalRec["Discount"];
					txtNetAmount.Value = rsLocalRec["Net_Amount"];
					txtDownPayment.Value = rsLocalRec["Down_Payment"];
					txtRemainingAmount.Value = rsLocalRec["Remaining_Amount"];
					txtInstallments.Value = rsLocalRec["Installments"];
					txtInstallmentStartDate.Value = Convert.ToString(rsLocalRec["Installment_Start_Date"]) + "";
					txtComment.Text = Convert.ToString(rsLocalRec["Remarks"]);
					//**----------------------------------------------------------------------------------------------------
				}
				else
				{
					MessageBox.Show("No records found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				rsLocalRec.Close();

				SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, true);

				mysql = " select * from SAL_Sales_Contract_Details where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand_2.ExecuteReader();
				bool rsLocalRecDidRead2 = rsLocalRec.Read();
				if (rsLocalRecDidRead)
				{
					do 
					{
						SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, cnt, false);

						aVoucherDetails.SetValue(cnt + 1, cnt, mLineNoColumn);
						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["Installment_Date"]) + "", cnt, mDateColumn);
						aVoucherDetails.SetValue(rsLocalRec["Amount"], cnt, mAmountColumn);
						aVoucherDetails.SetValue(rsLocalRec["Is_Printed"], cnt, mPrintedColumn);
						aVoucherDetails.SetValue(rsLocalRec["Is_Paid"], cnt, mPaidColumn);
						aVoucherDetails.SetValue(rsLocalRec["Remarks"], cnt, mRemarkColumn);
						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["Paid_Date"]) + "", cnt, mPaidDateColumn);
						cnt++;
					}
					while(rsLocalRec.Read());
				}
				CalculateTotals();
				grdVoucherDetails.Refresh();
				grdVoucherDetails.Rebind(true);

				rsLocalRec.Close();

				CalculateTotals();
				ShowHideFields();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
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

			string mysql = " select top 1 Entry_Id from SAL_Sales_Contract ";
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

		public void ShowHideFields()
		{

			try
			{

				string mSQL = "";

				object mReturnValue = null;

				if (ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) != "")
				{
					mSQL = "select top 1 Line_No from SAL_Sales_Contract_Details where (Is_Paid = 1 or Is_Printed = 1) and  Entry_Id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						txtCustomerCode.Enabled = false;
						txtVoucherDate.Enabled = false;
						txtContractNo.Enabled = false;
						txtAmount.Enabled = false;
						txtDiscount.Enabled = false;
						txtDownPayment.Enabled = false;
						txtDownPayment.Enabled = false;
						txtInstallmentStartDate.Enabled = false;
						txtInstallments.Enabled = false;
						cmdGenerate.Enabled = false;

					}
					else
					{
						txtCustomerCode.Enabled = true;
						txtVoucherDate.Enabled = true;
						txtContractNo.Enabled = true;
						txtAmount.Enabled = true;
						txtDiscount.Enabled = true;
						txtDownPayment.Enabled = true;
						txtDownPayment.Enabled = true;
						txtInstallmentStartDate.Enabled = true;
						txtInstallments.Enabled = true;
						cmdGenerate.Enabled = true;
					}
				}
				else
				{
					txtCustomerCode.Enabled = true;
					txtVoucherDate.Enabled = true;
					txtContractNo.Enabled = true;
					txtAmount.Enabled = true;
					txtDiscount.Enabled = true;
					txtDownPayment.Enabled = true;
					txtDownPayment.Enabled = true;
					txtInstallmentStartDate.Enabled = true;
					txtInstallments.Enabled = true;
					cmdGenerate.Enabled = true;
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			//If ColIndex = mDebitAmountColumn Or ColIndex = mCreditAmountColumn Or ColIndex = mFCAmountColumn Or ColIndex = mLCAmountColumn Then
			if (ColIndex == mAmountColumn)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###,###,##0.000");
				}
				else
				{
					Value = "";
				}
			}
		}
		public void IRoutine()
		{
			if (ActiveControl.Name != "grdVoucherDetails")
			{
				grdVoucherDetails.Focus();
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdVoucherDetails.Bookmark))
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), 1);
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Focus();
				grdVoucherDetails.Refresh();
				txtInstallments.Value = ReflectionHelper.GetPrimitiveValue<double>(txtInstallments.Value) + 1;
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdVoucherDetails")
			{
				grdVoucherDetails.Focus();
			}

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdVoucherDetails.Delete();
				AssignGridLineNumbers();
				CalculateTotals();
				grdVoucherDetails.Rebind(true);
				txtInstallments.Value = ReflectionHelper.GetPrimitiveValue<double>(txtInstallments.Value) - 1;
			}
		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			int newLargeChange = 0;

			if (Frame2.Height * 15 > this.ClientRectangle.Height * 15)
			{
				HScroll1.Visible = true;
				HScroll1.SetBounds(this.ClientRectangle.Width - 17, 0, 17, this.ClientRectangle.Height);
				HScroll1.Minimum = 0;
				HScroll1.Maximum = (Frame2.Height * 15 - this.ClientRectangle.Height * 15 + HScroll1.LargeChange - 1);
				HScroll1.SmallChange = Convert.ToInt32((HScroll1.Maximum - HScroll1.LargeChange + 1) / 100d);
				newLargeChange = Convert.ToInt32((HScroll1.Maximum - HScroll1.LargeChange + 1) / 10d);
				HScroll1.Maximum = HScroll1.Maximum + newLargeChange - HScroll1.LargeChange;
				HScroll1.LargeChange = newLargeChange;
			}
			else
			{
				HScroll1.Visible = false;
			}

		}

		private void HScroll1_ValueChanged(Object eventSender, EventArgs eventArgs)
		{

			Frame2.Top = Convert.ToInt32(-HScroll1.Value) / 15;
			Application.DoEvents(); // this is not strictly necessary, but smooths the scolling some

		}

		public void FindRoutine(string pObjectName)
		{

			object mReturnValue = null;

			string mFindWhereClause = "";


			switch(pObjectName)
			{
				case "txtCustomerCode" : 
					txtCustomerCode.Text = ""; 
					mFindWhereClause = " l.type_cd =" + SystemGLConstants.gGLCustomerVendorTypeCode.ToString(); 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFindWhereClause)); 
					 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCustomerCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						txtCustomerCode_Leave(txtCustomerCode, new EventArgs());
					} 
					 
					return; 

			}

		}

		public bool deleteRecord()
		{
			string mysql = "";
			object mReturnValue = null;
			//Delete the Record
			try
			{

				mysql = "select top 1 Line_No from SAL_Sales_Contract_Details where (Is_Paid = 1 or Is_Printed = 1) and  Entry_Id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Installments are already printed/paid. Cannot delete transaction", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
				SystemVariables.gConn.BeginTransaction();

				mysql = "delete from SAL_Sales_Contract_Details ";
				mysql = mysql + " where entry_id = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mysql = " delete from SAL_Sales_Contract ";
				mysql = mysql + " where entry_id = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();


				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();


				return true;
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Delete Record", SystemConstants.msg10);

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
			return false;
		}
	}
}