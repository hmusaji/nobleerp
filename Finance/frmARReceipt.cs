
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmARReceipt
		: System.Windows.Forms.Form
	{

		public frmARReceipt()
{
InitializeComponent();
} 
 public  void frmARReceipt_old()
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


		private void frmARReceipt_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private int mThisFormID = 0;
		private object mSearchValue = null;
		int mEntryId = 0;

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

		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		public Control FirstFocusObject = null;

		private int mICSVocuherType = 0;
		private int mCrystalID = 0;
		private bool mUseNumToChar = false;
		int mSourceLineEntryId = 0;
		int mInvoiceEntryId = 0;
		int mSManCd = 0;
		private string mTimeStamp = "";

		const int mLineNoColumn = 0;
		const int mVoucherTypeColumn = 1;
		const int mVoucherNo = 2;
		const int mReferenceNoColumn = 3;
		const int mVoucherDateColumn = 4;
		const int mVoucherDueDateColumn = 5;
		const int mVoucherAmountColumn = 6;
		const int mDueAmountColumn = 7;
		const int mClearedAmountColumn = 8;
		const int mUBClearedAmountColumn = 9;
		const int mBalanceAmountColumn = 10;
		const int mTimeStampColumn = 11;
		const int mDetailsRemarksColumn = 12;
		const int mDetailsEntryIdColumn = 13;
		int mFindId = 0;

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
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "";
				int mReportId = 0;
				decimal mVoucherAmount = 0;

				if (mEntryId != 0)
				{
					mysql = " select top 1 Report_Id from gl_print_task_detail ";
					mysql = mysql + "where (voucher_type = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select voucher_type from GL_Accnt_Trans where entry_id = " + mEntryId.ToString())) + ")";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReportId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReportId))
					{
						mysql = " select sum(lc_amount) from gl_accnt_trans_details ";
						mysql = mysql + " where lc_amount> 0 ";
						mysql = mysql + " and entry_id = " + Conversion.Str(mEntryId);
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mVoucherAmount = ReflectionHelper.GetPrimitiveValue<decimal>(SystemProcedure2.GetMasterCode(mysql));

						frmGLTransaction.DefInstance.PrintGLCrystalReport(mEntryId, mReportId, mVoucherAmount);
					}
				}
				else
				{
					MessageBox.Show("Please save transaction before print", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void saveRecord()
		{
			try
			{
				string mSQL = "";
				object mReturnValue = null;
				int mCashLdgrCd = 0;
				int mCustomerLdgrCd = 0;
				int mDiscountLdgrCd = 0;
				string mReceiptNo = "";


				int Cnt = 0;

				//    If MsgBox("Do you want to save?", vbInformation + vbYesNo) = vbNo Then
				//        txtSalesInvoiceNo.SetFocus
				//        Exit Sub
				//    End If

				if (txtCashBankCD.Text == "")
				{
					MessageBox.Show("Please enter Cash/Bank Code.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCashBankCD.Focus();
					return;
				}

				if (txtVoucherDate.Text == "")
				{
					MessageBox.Show("Please enter Voucher Date.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtVoucherDate.Focus();
					return;
				}

				if (Conversion.Val(txtReceiptAmt.Text) == 0)
				{
					MessageBox.Show("Please enter Receipt Amount.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtReceiptAmt.Focus();
					return;
				}

				if (Conversion.Val(txtDiscountAmt.Text) != 0 && txtDiscountCD.Text == "")
				{
					MessageBox.Show("Please enter Discount Account.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtDiscountCD.Focus();
					return;
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
					return;
				}

				if (txtVoucherNo.Text == "")
				{
					MessageBox.Show("Please enter Voucher No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtVoucherNo.Focus();
					return;
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

				mSQL = " select ldgr_cd from gl_ledger where ldgr_no ='" + txtCashBankCD.Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCashLdgrCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					MessageBox.Show("Invalid Cash/Bank No. selected.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCashBankCD.Focus();
					return;
				}

				mSQL = " select ldgr_cd from gl_ledger where ldgr_no ='" + txtDiscountCD.Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDiscountLdgrCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				SystemVariables.gConn.BeginTransaction();

				//Passing GL Entry
				mEntryId = SystemFAProcedure.FAInsertGLHeaderEntry(ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Quick_receipt_GL_Transaction")), ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value), Convert.ToInt32(Double.Parse(txtVoucherNo.Text)), "", txtComments.Text, 1, SystemVariables.gLoggedInUserCode);

				SystemFAProcedure.FAInsertGLDetailsEntry(mEntryId, mCashLdgrCd.ToString(), "1", 1, (decimal) Conversion.Val(txtReceiptAmt.Text), (decimal) Conversion.Val(txtReceiptAmt.Text), "D", ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value), 1, 2, "", mSManCd);

				if (mDiscountLdgrCd != 0 && Conversion.Val(txtDiscountAmt.Text) != 0)
				{
					SystemFAProcedure.FAInsertGLDetailsEntry(mEntryId, mDiscountLdgrCd.ToString(), "1", 1, (decimal) Conversion.Val(txtDiscountAmt.Text), (decimal) Conversion.Val(txtDiscountAmt.Text), "D", ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value), 2, 2, "", mSManCd);
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				SystemFAProcedure.FAInsertGLDetailsEntry(mEntryId, mCustomerLdgrCd.ToString(), "1", 1, (decimal) ((Conversion.Val(txtReceiptAmt.Text) + ((Convert.IsDBNull(Conversion.Val(txtDiscountAmt.Text))) ? 0 : Conversion.Val(txtDiscountAmt.Text))) * -1), (decimal) ((Conversion.Val(txtReceiptAmt.Text) + ((Convert.IsDBNull(Conversion.Val(txtDiscountAmt.Text))) ? 0 : Conversion.Val(txtDiscountAmt.Text))) * -1), "C", ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value), 1, 2, "", mSManCd);

				//End Passing GL Entry

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select scope_identity()"));



				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					if (Convert.ToDouble(aVoucherDetails.GetValue(Cnt, mUBClearedAmountColumn)) > 0)
					{

						mSQL = " insert into gl_invoice_tracking (against_line_no, source_line_no, adjusted_amt,user_cd) ";
						mSQL = mSQL + " values (";
						mSQL = mSQL + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
						mSQL = mSQL + ", " + Convert.ToString(aVoucherDetails.GetValue(Cnt, mLineNoColumn)); // source line no
						mSQL = mSQL + " ," + Convert.ToString(aVoucherDetails.GetValue(Cnt, mUBClearedAmountColumn));
						mSQL = mSQL + ", " + SystemVariables.gLoggedInUserCode.ToString() + ")";
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mSQL;
						TempCommand.ExecuteNonQuery();


					}
				}

				//        mSQL = " insert into gl_invoice_tracking (against_line_no, source_line_no, adjusted_amt,user_cd) "
				//        mSQL = mSQL & " values ("
				//        mSQL = mSQL & mReturnValue    ' against_line_no
				//        mSQL = mSQL & ", " & mSourceLineEntryId  ' source line no
				//        mSQL = mSQL & " ," & Val(txtReceiptAmt.Text) + IIf(IsNull(Val(txtDiscountAmt.Text)), 0, Val(txtDiscountAmt.Text))
				//        mSQL = mSQL & ", " & gLoggedInUserCode & ")"
				//        gConn.Execute mSQL
				//
				//        '''Update amount_received column, this is only for mithaq optics
				//        mSQL = " update ICS_Transaction set amount_received = amount_received + " & txtReceiptAmt.Value & " where entry_id = " & mInvoiceEntryId
				//        gConn.Execute mSQL
				//
				//        If Val(txtReceiptAmt.Text) = Val(txtInvoiceBal.Text) Then
				//            mSQL = " update ICS_Additional_Voucher_Details set trans_type = 1, credit_card_date = '" & Format(Date, gSystemDateFormat) & "' where entry_id = " & mInvoiceEntryId
				//            gConn.Execute mSQL
				//            mSQL = " update ICS_Transaction set status = 2 where entry_id = " & mInvoiceEntryId
				//            gConn.Execute mSQL
				//        End If
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				if (MessageBox.Show("Saved Successfully." + "\r" + "Do you want to print this Sales Invoice ?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
				{
					PrintReport();
				}

				AddRecord();
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
			}



		}


		public void CloseForm()
		{
			try
			{
				this.Close();
			}
			catch
			{
			}
		}

		private void cmdAutoAdjust_Click(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;
				double mAdjustmentAmount = Double.Parse(txtReceiptAmt.Text);
				mAdjustmentAmount += Double.Parse(txtDiscountAmt.Text);

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					if (Convert.ToDouble(aVoucherDetails.GetValue(Cnt, mDueAmountColumn)) >= mAdjustmentAmount)
					{
						aVoucherDetails.SetValue(mAdjustmentAmount, Cnt, mUBClearedAmountColumn);
						aVoucherDetails.SetValue(Convert.ToDouble(aVoucherDetails.GetValue(Cnt, mDueAmountColumn)) - mAdjustmentAmount, Cnt, mBalanceAmountColumn);
						mAdjustmentAmount = 0;
						//Exit For
					}
					else
					{
						aVoucherDetails.SetValue(aVoucherDetails.GetValue(Cnt, mDueAmountColumn), Cnt, mUBClearedAmountColumn);
						aVoucherDetails.SetValue(0, Cnt, mBalanceAmountColumn);
						mAdjustmentAmount -= Convert.ToDouble(aVoucherDetails.GetValue(Cnt, mDueAmountColumn));
					}

				}
				grdVoucherDetails.Refresh();
				CalculateTotals(0, 0);
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
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
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
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
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
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
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
		public void findRecord()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = " mt.voucher_type = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("Quick_receipt_GL_Transaction"));

				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(mFindId, "", mysql, true, true));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
					GetRecord(mSearchValue);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}
		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mSQL = "";
				object mReturnValue = null;

				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar]]]][87777765
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowExitButton = true;
				this.WindowState = FormWindowState.Maximized;


				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2.4f, 1.4f, (0xE7E2DC).ToString(), (0xE7E2DC).ToString());
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Line_No", 400, true, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Type", 460, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Voucher No.", 1000, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Reference No.", 1400, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Voucher Date", 1050, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Due Date", 1050, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Voucher Amount", 950, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount Due", 1000, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount Cleared", 1000, true, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount Cleared", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Balance", 1000, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Time_stamp", 100, true, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 4000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near);

				//    With grdVoucherDetails
				//        '.HoldFields
				//        With .HighlightRowStyle
				//            .BackColor = &HE7E2DC
				//            .BorderSize = 1
				//            .BorderType = 15
				//            .BorderColor = &H800000
				//            .ForeColor = vbBlack
				//        End With
				//    End With



				AddRecord();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}
		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			try
			{
				grdVoucherDetails.Width = this.Width - 20;
			}
			catch
			{
			}
		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				grdVoucherDetails.UpdateData();
				CalculateTotals(0, 0);
				grdVoucherDetails.Refresh();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdVoucherDetails_BeforeColUpdate(object eventSender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			object OldValue = eventArgs.OldValue;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					grdVoucherDetails.UpdateData();
					CalculateTotals(0, 0);
					grdVoucherDetails.Refresh();
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		private void grdVoucherDetails_Leave(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				grdVoucherDetails.UpdateData();
				CalculateTotals(0, 0);
				grdVoucherDetails.Refresh();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCashBankCD_DropButtonClick(Object Sender, EventArgs e)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", " type_cd = 4 or type_cd = 5 "));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCashBankCD.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					txtCashBankCD_Leave(txtCashBankCD, new EventArgs());
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCashBankCD_KeyDown(Object Sender, System.Windows.Forms.TextBox.KeyDownEventArgs e)
		{
			Keys KeyCode = (Keys) e.KeyCode;
			int Shift = e.Shift;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (KeyCode == Keys.F4)
				{
					txtCashBankCD_DropButtonClick(txtCashBankCD, null);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void txtCashBankCD_Leave(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (txtCashBankCD.Text == "")
				{
					return;
				}
				string mSQL = " select ldgr_cd, l_ldgr_Name from gl_ledger where ldgr_no ='" + txtCashBankCD.Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Cash/Bank Code selected.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtCashBankCD.Focus();
					txtCashBankLedName.Text = "";
					return;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCashBankLedName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}


		private void txtCustomerCode_DropButtonClick(Object Sender, EventArgs e)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
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
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCustomerCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
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
					txtBalAmt.Text = "";
					return;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCustomerName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));

					if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2)) > 0)
					{
						txtBalAmt.Text = "Dr.       " + StringsHelper.Format(Math.Abs(ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2))), "##,###,###.000");
					}
					else if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2)) == 0)
					{ 
						txtBalAmt.Text = "0.000";
					}
					else
					{
						txtBalAmt.Text = "Cr." + StringsHelper.Format(Math.Abs(ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2))), "##,###,###.000");
					}
				}

				GetLedgerDetail(txtCustomerCode.Text, 1, "Dr");
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtDiscountCD_DropButtonClick(Object Sender, EventArgs e)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", " type_cd = 2 "));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDiscountCD.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					txtDiscountCD_Leave(txtDiscountCD, new EventArgs());
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtDiscountCD_KeyDown(Object Sender, System.Windows.Forms.TextBox.KeyDownEventArgs e)
		{
			Keys KeyCode = (Keys) e.KeyCode;
			int Shift = e.Shift;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (KeyCode == Keys.F4)
				{
					txtDiscountCD_DropButtonClick(txtDiscountCD, null);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtDiscountCD_Leave(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (txtDiscountCD.Text == "")
				{
					return;
				}
				string mSQL = " select ldgr_cd, l_ldgr_Name from gl_ledger where ldgr_no ='" + txtDiscountCD.Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Discount Code selected.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtDiscountCD.Focus();
					txtDiscountLedName.Text = "";
					return;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDiscountLedName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//Private Sub txtPercentDiscount_Change()
		//    txtDiscountAmt.Text = (txtPercentDiscount.Text / txtInvoiceBal.Text) * 100
		//End Sub

		//
		//Private Sub txtSalesInvoiceNo_DropButtonClick()
		//    Dim mTempValue As Variant
		//    Dim mSQL As String
		//    txtSalesInvoiceNo.Text = ""
		//    mTempValue = FindItem(3000201, "10,13", " voucher_type = " & mICSVocuherType & " and locat_no = '" & txtLocationCd.Text & "'")
		//    If Not IsNull(mTempValue) Then
		//        txtSalesInvoiceNo.Text = mTempValue(1)
		//        Call txtSalesInvoiceNo_LostFocus
		//    End If
		//End Sub
		//
		//Private Sub txtSalesInvoiceNo_LostFocus()
		//    Dim mSQL As String
		//    Dim mTempValue As Variant
		//    Dim mLdgrCd As Long
		//    If txtSalesInvoiceNo.Text <> "" Then
		//        mSQL = " select it.ldgr_cd, it.voucher_type,  it.locat_cd, it.entry_id, it.voucher_date, sman_cd from ICS_Transaction it "
		//        mSQL = mSQL & " inner join SM_Location l on l.locat_cd = it.locat_cd "
		//        mSQL = mSQL & " where it.voucher_no = '" & txtSalesInvoiceNo.Text & "' and it.voucher_type = " & mICSVocuherType
		//        mSQL = mSQL & " and l.locat_no = '" & txtLocationCd.Text & "'"
		//
		//        mTempValue = GetMasterCode(mSQL)
		//
		//        If Not IsNull(mTempValue) Then
		//            mLdgrCd = mTempValue(0)
		//            mInvoiceEntryId = mTempValue(3)
		//            mSManCd = mTempValue(5)
		//            txtInvoiceDate.Text = Format(Conversion.CVDate(mTempValue(4)), gSystemDateFormat)
		//            mSQL = " select gdt.fc_due_amt as bal, gdt.line_no from gl_accnt_trans gmt "
		//            mSQL = mSQL & " inner join gl_accnt_trans_details gdt on gmt.entry_id = gdt.entry_id "
		//            mSQL = mSQL & " inner join ICS_Transaction mt on gmt.linked_entry_id = mt.entry_id "
		//            mSQL = mSQL & "  Where gmt.linked_type_flag = 1 "
		//            mSQL = mSQL & "  and gdt.dr_cr_type = 'D' "
		//            mSQL = mSQL & " and mt.voucher_type = " & mTempValue(1)
		//            mSQL = mSQL & " and mt.voucher_no = " & txtSalesInvoiceNo.Text
		//            mSQL = mSQL & " and mt.locat_cd =" & mTempValue(2)
		//            mTempValue = GetMasterCode(mSQL)
		//            If Not IsNull(mTempValue) Then
		//                txtInvoiceBal.Text = Format(mTempValue(0), "##,##,####.000")
		//                mSourceLineEntryId = mTempValue(1)
		//            End If
		//
		//
		//
		//
		//            'Call CleanAllTextBox
		//
		//            mSQL = "select ldgr_no, l_ldgr_name, ldgr_cd from gl_ledger where ldgr_cd =" & mLdgrCd
		//            mTempValue = GetMasterCode(mSQL)
		//            If Not IsNull(mTempValue) Then
		//                txtCustomerCode.Text = mTempValue(0)
		//                txtCustomerName.Text = mTempValue(1)
		//                mSQL = "select sum(lc_amount) as balance "
		//                mSQL = mSQL & " from gl_accnt_trans glt"
		//                mSQL = mSQL & " inner join gl_accnt_trans_details gltd on glt.entry_id = gltd.entry_id "
		//                mSQL = mSQL & " where gltd.ldgr_cd =" & mTempValue(2)
		//                mTempValue = GetMasterCode(mSQL)
		//                If mTempValue > 0 Then
		//                    txtBalAmt.Text = "Dr.       " & Format(Abs(mTempValue), "##,###,###.000")
		//                ElseIf mTempValue = 0 Then
		//                    txtBalAmt.Text = "0.000"
		//                Else
		//                    txtBalAmt.Text = "Cr." & Format(Abs(mTempValue), "##,###,###.000")
		//                End If
		//            Else
		//                MsgBox "Invalid selection", vbExclamation
		//                txtSalesInvoiceNo.SetFocus
		//                Exit Sub
		//            End If
		//        Else
		//            MsgBox "Invalid Sales Invoice No.", vbExclamation
		//            txtSalesInvoiceNo.SetFocus
		//            Exit Sub
		//        End If
		//    End If
		//End Sub

		private object GetNewGLVoucherNo(object pVoucherType)
		{
			try
			{
				txtVoucherNo.Text = SystemProcedure2.GetNewNumber("gl_accnt_trans", " voucher_no ", 2, " voucher_type = " + ReflectionHelper.GetPrimitiveValue<string>(pVoucherType));
			}
			catch
			{
			}
			return null;
		}

		private void GetLedgerDetail(string pLdgrNo, int pHeaderOrDetail, string pHeaderType)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				object mReturnValue = null;
				string mHeaderType = "";
				string mDetailType = "";

				if (!SystemProcedure2.IsItEmpty(txtCustomerCode.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select ldgr_cd, '' from gl_ledger where ldgr_no='" + pLdgrNo + "'" + " and type_cd=" + SystemGLConstants.gGLCustomerVendorTypeCode.ToString()));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						return;
					}
				}
				else
				{
					return;
				}

				GetVoucherDetail("D", Convert.ToInt32(Double.Parse(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)))), 0);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void GetVoucherDetail(string pDrCrType, int pLdgrCode, int pSourceLineNo)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				string mysql = " SELECT ATD.Line_No , AVT.L_Short_Name ";
				mysql = mysql + ", AT.voucher_No ";
				mysql = mysql + ", ATD.Reference_No ";
				mysql = mysql + ", AT.Voucher_Date , ATD.Due_Date ";
				mysql = mysql + ", abs(ATD.FC_amount) as fc_amount ";
				mysql = mysql + ", ATD.FC_Due_Amt + isnull(InvTracking.Adjusted_Amt,0) AS [amt_due] ";
				mysql = mysql + ", isnull(InvTracking.Adjusted_Amt,0) AS [amt_cleared] ";
				mysql = mysql + ", ATD.FC_Due_Amt , InvTracking.comments as [Comments] ";
				mysql = mysql + ", ATD.Time_Stamp ";
				mysql = mysql + ", ATD.comments remarks ";
				mysql = mysql + " FROM gl_accnt_trans  as AT";
				mysql = mysql + " INNER JOIN gl_accnt_voucher_types as AVT ON AT.Voucher_Type = AVT.Voucher_Type";
				mysql = mysql + " right outer join gl_accnt_trans_Details as ATD ON AT.Entry_Id = ATD.Entry_Id";
				mysql = mysql + " left outer JOIN";
				mysql = mysql + " (select Adjusted_Amt, against_line_no, source_Line_No,comments from  gl_invoice_Tracking";
				if (pDrCrType == "D")
				{
					mysql = mysql + " where against_Line_No=" + Conversion.Str(pSourceLineNo) + ")";
				}
				else
				{
					mysql = mysql + " where source_Line_No=" + Conversion.Str(pSourceLineNo) + ")";
				}
				mysql = mysql + " as InvTracking";

				if (pDrCrType == "D")
				{
					mysql = mysql + " ON ATD.Line_No = InvTracking.source_Line_No";
				}
				else
				{
					mysql = mysql + " ON ATD.Line_No = InvTracking.Against_Line_No";
				}
				mysql = mysql + " where ATD.Dr_Cr_Type='" + pDrCrType + "'";
				mysql = mysql + " and ATD.ldgr_cd=" + pLdgrCode.ToString();
				//If chkShowAll.Value = 0 Then
				mysql = mysql + " and (abs(atd.fc_amount) <> ATD.fc_paid_amt) ";
				//End If
				mysql = mysql + " order by voucher_date ";

				recDetail = new DataSet();
				recCloneDetail = new DataSet();

				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property recDetail.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				recDetail.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());

				//UPGRADE_ISSUE: (2064) ADODB.Recordset property recDetail.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (recDetail.getState() == ConnectionState.Open)
				{
				}
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property recCloneDetail.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (recCloneDetail.getState() == ConnectionState.Open)
				{
				}

				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				recDetail.Tables.Clear();
				adap.Fill(recDetail);
				//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method recDetail.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				recCloneDetail = recDetail.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());

				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
				aVoucherDetails.RedimXArray(new int[]{0, 13}, new int[]{0, 0});

				int Cnt = 0;
				SystemGrid.DefineVoucherArray(aVoucherDetails, 13, recDetail.Tables[0].Rows.Count - 1, true);
				if (recDetail.Tables[0].Rows.Count != 0)
				{
					foreach (DataRow iteration_row in recDetail.Tables[0].Rows)
					{


						aVoucherDetails.SetValue(Convert.ToString(iteration_row["Line_No"]).Trim(), Cnt, mLineNoColumn);
						aVoucherDetails.SetValue(Convert.ToString(iteration_row["L_Short_Name"]).Trim(), Cnt, mVoucherTypeColumn);
						aVoucherDetails.SetValue(Convert.ToString(iteration_row["voucher_No"]).Trim(), Cnt, mVoucherNo);
						aVoucherDetails.SetValue(Convert.ToString(iteration_row["Reference_No"]).Trim(), Cnt, mReferenceNoColumn);
						aVoucherDetails.SetValue(Convert.ToString(iteration_row["Voucher_Date"]).Trim(), Cnt, mVoucherDateColumn);
						aVoucherDetails.SetValue(Convert.ToString(iteration_row["Due_Date"]).Trim(), Cnt, mVoucherDueDateColumn);
						aVoucherDetails.SetValue(Convert.ToString(iteration_row["fc_amount"]).Trim(), Cnt, mVoucherAmountColumn);
						aVoucherDetails.SetValue(Convert.ToString(iteration_row["FC_Due_Amt"]).Trim(), Cnt, mDueAmountColumn);
						aVoucherDetails.SetValue(Convert.ToString(iteration_row["amt_cleared"]).Trim(), Cnt, mClearedAmountColumn);
						aVoucherDetails.SetValue(Convert.ToString(iteration_row["amt_due"]).Trim(), Cnt, mBalanceAmountColumn);
						aVoucherDetails.SetValue(Convert.ToString(iteration_row["Time_Stamp"]).Trim(), Cnt, mTimeStampColumn);
						aVoucherDetails.SetValue(Convert.ToString(iteration_row["remarks"]).Trim(), Cnt, mDetailsRemarksColumn);
						aVoucherDetails.SetValue(Convert.ToString(iteration_row["remarks"]).Trim(), Cnt, mDetailsEntryIdColumn);
						Cnt++;
					}
				}
				recDetail = null;

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Refresh();

				CalculateTotals(0, 0);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}


		private void CalculateTotals(int mRowNumber, int mColNumber)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;



				DataSet rsTempRec = null;

				double mHeaderVoucherAmt = 0;
				double mHeaderVoucherAmtCleared = 0;
				double mHeaderBalanceAmt = 0;

				double mDetailVoucherAmt = 0;
				double mDetailVoucherAmtCleared = 0;
				double mDetailVoucherAmtDue = 0;
				double mDetailBalanceAmt = 0;

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					mDetailVoucherAmt += Convert.ToDouble(aVoucherDetails.GetValue(Cnt, mVoucherAmountColumn));
					mDetailVoucherAmtCleared += Convert.ToDouble(aVoucherDetails.GetValue(Cnt, mUBClearedAmountColumn));
					mDetailVoucherAmtDue += Convert.ToDouble(aVoucherDetails.GetValue(Cnt, mDueAmountColumn));
					mDetailBalanceAmt += Convert.ToDouble(aVoucherDetails.GetValue(Cnt, mBalanceAmountColumn));

				}

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''
				//'''''Details Grid ''''''''''''''''
				if (mDetailVoucherAmt != 0)
				{
					grdVoucherDetails.Columns[mVoucherAmountColumn].FooterText = StringsHelper.Format(mDetailVoucherAmt, "###,###,###,###,##0.000");
				}
				else
				{
					grdVoucherDetails.Columns[mVoucherAmountColumn].FooterText = "";
				}

				if (mDetailVoucherAmtCleared != 0)
				{
					grdVoucherDetails.Columns[mUBClearedAmountColumn].FooterText = StringsHelper.Format(mDetailVoucherAmtCleared, "###,###,###,###,##0.000");
				}
				else
				{
					grdVoucherDetails.Columns[mUBClearedAmountColumn].FooterText = "";
				}

				if (mDetailVoucherAmtDue != 0)
				{
					grdVoucherDetails.Columns[mDueAmountColumn].FooterText = StringsHelper.Format(mDetailVoucherAmtDue, "###,###,###,###,##0.000");
				}
				else
				{
					grdVoucherDetails.Columns[mDueAmountColumn].FooterText = "";
				}

				if (mDetailBalanceAmt != 0)
				{
					grdVoucherDetails.Columns[mBalanceAmountColumn].FooterText = StringsHelper.Format(mDetailBalanceAmt, "###,###,###,###,##0.000");
				}
				else
				{
					grdVoucherDetails.Columns[mBalanceAmountColumn].FooterText = "";
				}
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		public void AddRecord()
		{
			object mOppositeLedgerDetails = null;
			try
			{
				string mSQL = "";
				object mReturnValue = null;
				//Add a record
				SystemProcedure2.ClearTextBox(this);
				SystemProcedure2.ClearNumberBox(this);
				SystemProcedure2.ClearCheckBox(this);

				//Gl Voucher type
				mSQL = " select voucher_type, l_voucher_name, Opposite_Ldgr_Cd, Default_Discount_Ldgr_Cd, Find_Id from gl_accnt_voucher_types where voucher_type = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("Quick_receipt_GL_Transaction"));
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));

				GetNewGLVoucherNo(((Array) mReturnValue).GetValue(0));

				string mysql2 = "";
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(2)))
				{

					mysql2 = "select ldgr_no, ";
					mysql2 = mysql2 + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name");
					mysql2 = mysql2 + " from gl_ledger l ";
					mysql2 = mysql2 + " where ldgr_cd = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mOppositeLedgerDetails = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql2));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mOppositeLedgerDetails))
					{
						txtCashBankCD.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mOppositeLedgerDetails).GetValue(0)) + "";
						txtCashBankLedName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mOppositeLedgerDetails).GetValue(1)) + "";
					}
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(3)))
				{

					mysql2 = "select ldgr_no, ";
					mysql2 = mysql2 + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name");
					mysql2 = mysql2 + " from gl_ledger l ";
					mysql2 = mysql2 + " where ldgr_cd = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3));

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mOppositeLedgerDetails = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql2));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mOppositeLedgerDetails))
					{
						txtDiscountCD.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mOppositeLedgerDetails).GetValue(0)) + "";
						txtDiscountLedName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mOppositeLedgerDetails).GetValue(1)) + "";
					}
				}

				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mFindId = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(4));

				//ICS Voucher Type & Crystal Report Id
				mSQL = " select voucher_type, crystal_report_id, use_num_to_char_function from ICS_Transaction_Types where voucher_type = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("Quick_receipt_ICS_Transaction"));
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCrystalID = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mICSVocuherType = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mUseNumToChar = ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(2));
				}
				else
				{
					MessageBox.Show("Incorrect ICS Transaction Type defined in preferences.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				aVoucherDetails = null;

				aVoucherDetails.RedimXArray(new int[]{0, 13}, new int[]{0, 0});
				aVoucherDetails.SetValue(1, 0, 0);
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);

				CalculateTotals(0, 0);
				//Cash & Bank Code
				//mSQL = " select ldgr_no, l_ldgr_name from gl_ledger where ldgr_cd = '" & GetSystemPreferenceSetting("cash_bank_cd_in_delivery") & "'"
				//mReturnValue = GetMasterCode(mSQL)
				//If Not IsNull(mReturnValue) Then
				//    txtCashBankCD.Text = mReturnValue(0)
				//    txtCashBankLedName.Text = mReturnValue(1)
				//End If

				//txtParentNatNo.Enabled = True

				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
				mSearchValue = ""; //Change the msearchvalue to blank
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}

		}

		public void GetRecord(object pSearchValue)
		{
			//''''*************************************************************************
			//This routine is called after getting the value from Find window or
			//''''*************************************************************************
			string mysql = "";
			SqlDataReader rsLocalRec = null;


			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (SystemProcedure2.IsItEmpty(pSearchValue, SystemVariables.DataType.NumberType) || Convert.IsDBNull(pSearchValue))
				{
					return;
				}
				try
				{

					//If GetSystemPreferenceSetting("voucher_adjustment") = True Then
					//    Call InsertAdjustedVouchersInArray(Val(mSearchValue))
					//End If

					mysql = " select mt.* ";
					mysql = mysql + " , glb.branch_cd";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_branch_name" : "a_branch_name") + " as branch_name ";
					mysql = mysql + " from gl_accnt_trans mt ";
					mysql = mysql + " left outer join gl_branch glb on mt.branch_cd = glb.branch_cd ";
					mysql = mysql + " where mt.entry_id = " + Conversion.Str(pSearchValue);

					SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
					rsLocalRec = sqlCommand.ExecuteReader();

					if (rsLocalRec.Read())
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(rsLocalRec["show"])) == TriState.True)
						{
							txtVoucherNo.Text = Convert.ToString(rsLocalRec["voucher_no"]);
							txtVoucherDate.Value = rsLocalRec["voucher_date"];
							txtComments.Text = Convert.ToString(rsLocalRec["comments"]) + "";


						}
					}
					rsLocalRec.Close();

					mysql = " select atd.*, l.ldgr_no, atd.curr_cd, ";
					mysql = mysql + " l.l_ldgr_name, l.a_ldgr_name, l.current_bal, ";
					mysql = mysql + " gl_accnt_group.l_group_name, gl_accnt_group.a_group_name, projects.project_no ";
					mysql = mysql + " , anly1.anly_code as anly_code_1 ";
					mysql = mysql + " , anly2.anly_code as anly_code_2 ";
					mysql = mysql + " , gl_currency.symbol as curr_symbol, gcc.cost_no, SM_Salesman.sman_no ";
					mysql = mysql + " , gcc.l_cost_name, gcc.a_cost_name, cons.consignment_no ";

					mysql = mysql + " from gl_accnt_trans_details atd ";
					mysql = mysql + " inner join gl_ledger l on atd.ldgr_cd = l.ldgr_cd ";
					mysql = mysql + " inner join gl_accnt_group on l.group_cd = gl_accnt_group.group_cd ";
					mysql = mysql + " inner join gl_currency on atd.curr_cd = gl_currency.curr_cd ";
					mysql = mysql + " left outer join gl_cost_centers gcc on atd.cost_cd = gcc.cost_cd ";
					mysql = mysql + " left outer join SM_Salesman on atd.sman_cd = SM_Salesman.sman_cd ";
					mysql = mysql + " left outer join gl_consignment cons on atd.consignment_cd = cons.consignment_cd ";
					mysql = mysql + " left outer join gl_analysis anly1 on atd.anly_code_1 = anly1.anly_code ";
					mysql = mysql + " and atd.anly_head_no_1 = anly1.anly_head_no ";
					mysql = mysql + " left outer join gl_analysis anly2 on atd.anly_code_2 = anly2.anly_code ";
					mysql = mysql + " and atd.anly_head_no_2 = anly2.anly_head_no ";
					mysql = mysql + " left outer join PROJ_Projects projects on atd.project_cd = projects.project_cd ";
					mysql = mysql + " where atd.entry_id = " + Conversion.Str(pSearchValue);
					mysql = mysql + " order by atd.line_no ";
					SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
					rsLocalRec = sqlCommand_2.ExecuteReader();
					bool rsLocalRecDidRead2 = rsLocalRec.Read();

					int Cnt = 0;
					Cnt = 0;

					do 
					{
						if (Convert.ToString(rsLocalRec["dr_cr_type"]) == "D" && Convert.ToDouble(rsLocalRec["Dr_Cr_Line_No"]) == 1)
						{

							txtCashBankCD.Text = Convert.ToString(rsLocalRec["ldgr_no"]).Trim();
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								txtCashBankLedName.Text = Convert.ToString(rsLocalRec["l_ldgr_name"]).Trim();
							}
							else
							{
								txtCashBankLedName.Text = Convert.ToString(rsLocalRec["a_ldgr_name"]).Trim();
							}

							txtReceiptAmt.Value = rsLocalRec["lc_amount"];

						}
						else if (Convert.ToString(rsLocalRec["dr_cr_type"]) == "D" && Convert.ToDouble(rsLocalRec["Dr_Cr_Line_No"]) == 2)
						{ 

							txtDiscountCD.Text = Convert.ToString(rsLocalRec["ldgr_no"]).Trim();
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								txtDiscountLedName.Text = Convert.ToString(rsLocalRec["l_ldgr_name"]).Trim();
							}
							else
							{
								txtDiscountLedName.Text = Convert.ToString(rsLocalRec["a_ldgr_name"]).Trim();
							}

							txtDiscountAmt.Value = rsLocalRec["lc_amount"];

						}
						else if (Convert.ToString(rsLocalRec["dr_cr_type"]) == "C")
						{ 
							txtCustomerCode.Text = Convert.ToString(rsLocalRec["ldgr_no"]).Trim();
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								txtCustomerName.Text = Convert.ToString(rsLocalRec["l_ldgr_name"]).Trim();
							}
							else
							{
								txtCustomerName.Text = Convert.ToString(rsLocalRec["a_ldgr_name"]).Trim();
							}
						}

					}
					while(rsLocalRec.Read());
					rsLocalRec.Close();
					return;
				}
				catch (System.Exception excep)
				{
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]), "GetRecord");
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}