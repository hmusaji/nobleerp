
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmREReceiptTransaction
		: System.Windows.Forms.Form
	{

		public frmREReceiptTransaction()
{
InitializeComponent();
} 
 public  void frmREReceiptTransaction_old()
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


		private void frmREReceiptTransaction_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private clsToolbar oThisFormToolBar = null;
		public Control FirstFocusObject = null;

		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;

		private bool mFirstGridFocus = false;
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


		private const int gccLineNoColumn = 0;
		private const int gccStatus = 1;
		private const int gccFromDate = 2;
		private const int gccToDate = 3;
		private const int gccChargedAmt = 4;
		private const int gccPaidAmount = 5;
		private const int gccReceivedAmt = 6;
		private const int gccDiscountAmt = 7;
		private const int gccDueAmt = 8;
		private const int gccRemarks = 9;

		private const int conTxtReceiptNo = 0;
		private const int conTXTContractNo = 1;
		private const int conTxtPaidBy = 2;
		private const int conTXTReferenceNo = 3;

		private const int conTxtNReceiptAmount = 1;

		private const int conTxtDReceiptDate = 0;
		private const int conTxtDStartingDate = 1;
		private const int conTxtDEndingDate = 2;

		private const int conDlblTenantNo = 0;
		private const int conDlblTenantName = 1;
		private const int conDlblPayMethodNo = 2;
		private const int conDlblPayMethodName = 3;
		private const int conDlblContractAmt = 4;
		private const int conDlblStatusName = 5;
		private const int conDlblStatusNo = 6;
		private const int conDlblContractUnitNo = 7;


		private const int mMaxArray = 10;


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


		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, gccLineNoColumn);
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			System.DateTime mCurrentMonthDate = DateTime.FromOADate(0);
			System.DateTime mNextMonth = DateTime.FromOADate(0);

			try
			{

				FirstFocusObject = dateCommon[conTxtDReceiptDate];
				mFirstGridFocus = true;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
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
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);

				Application.DoEvents();
				this.Show();


				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2.3f, 1.4f, "&HB4D9F8", "&HB4D9F8");

				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Type", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "From Date", 1150, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "To Date", 1150, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, " T o t a l ");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Charged Amt.", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Paid Amt.", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Received Amt.", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Discount Amt.", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Due Amt.", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);

				aVoucherDetails.RedimXArray(new int[]{0, mMaxArray}, new int[]{0, 0});
				aVoucherDetails.SetValue(1, 0, 0);


				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Enabled = true;

				//mCurrentMonthDate =
				mCurrentMonthDate = SystemProcedure2.GetNextMonth(ReflectionHelper.GetPrimitiveValue<System.DateTime>(SystemREProcedure.GetRELastMonthEndDate()));
				//DateAdd("m", 1, mCurrentMonthDate)

				if (mCurrentMonthDate.Month == DateTime.Today.Month)
				{
					dateCommon[conTxtDReceiptDate].Value = DateTime.Today;
				}
				else
				{
					dateCommon[conTxtDReceiptDate].Value = mCurrentMonthDate;
				}
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
				if (KeyCode == 13 && this.ActiveControl.Name != "grdVoucherDetails")
				{
					SendKeys.Send("{TAB}");
					return;
				}

				if (this.ActiveControl.Name.ToLower() == ("grdVoucherDetails").ToLower())
				{
					if (KeyCode == 13 || KeyCode == 113)
					{
						return;
					}
					else if (KeyCode == 222)
					{  //'for "'"
						KeyCode = 0;
						return;
					}

					if (Shift == 0)
					{
						if (grdVoucherDetails.Col == gccReceivedAmt || grdVoucherDetails.Col == gccChargedAmt || grdVoucherDetails.Col == gccDiscountAmt || grdVoucherDetails.Col == gccDueAmt)
						{
							if ((KeyCode == 8) || (KeyCode == 46) || (KeyCode == 27))
							{
								//
							}
							else if ((KeyCode >= 48 && KeyCode <= 57) || (KeyCode >= 96 && KeyCode <= 105) || (KeyCode == 190) || (KeyCode == 110))
							{ 
								//
							}
							else
							{
								KeyCode = 0;
							}
						}
					}
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

		public void IRoutine()
		{
			//If grdVoucherDetails.Enabled = True Then
			//    If ActiveControl.Name <> "grdVoucherDetails" Then
			//        grdVoucherDetails.SetFocus
			//    End If
			//'    If Not IsNull(grdVoucherDetails.Bookmark) Then
			//'        aContractDetails.InsertRows (grdVoucherDetails.Bookmark)
			//'        Call AssignGridLineNumbers
			//'        grdVoucherDetails.ReBind
			//'        grdVoucherDetails.SetFocus
			//'        grdVoucherDetails.Refresh
			//'    End If
			//    txtNCommon(conTxtNReceiptAmount).Value = SumReceiptAmount()
			//End If
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
			}

			CalculateTotals(0, 0);
			grdVoucherDetails.Refresh();

		}

		private void GetContractItems()
		{


			int mRow = 0;
			int mTotalRec = 0;
			int mContractCd = 0;

			System.DateTime mStartingDate = DateTime.FromOADate(0);
			System.DateTime mEndingDate = DateTime.FromOADate(0);
			System.DateTime mFirstDate = DateTime.FromOADate(0);
			System.DateTime mToDate = DateTime.FromOADate(0);


			double mAmount = 0;
			double mReceiptAmt = 0;

			DataSet rsLocal = new DataSet();

			//mCurrentMonthEndDate = DateAdd("m", 1, CDate(GetRELastMonthEndDate))
			System.DateTime mCurrentMonthEndDate = SystemProcedure2.GetNextMonth(ReflectionHelper.GetPrimitiveValue<System.DateTime>(SystemREProcedure.GetRELastMonthEndDate()));

			int mNextMonth = mCurrentMonthEndDate.Month;
			int mNextYear = mCurrentMonthEndDate.Year;

			string mySQL = " select contract_cd, starting_date ";
			mySQL = mySQL + " , ending_date , contract_amt ";
			mySQL = mySQL + " from re_contract ";
			mySQL = mySQL + " where contract_no = " + Conversion.Val(txtCommon[conTXTContractNo].Text).ToString();
			mySQL = mySQL + " and status = 2 ";

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mContractCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mStartingDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue).GetValue(1));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEndingDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue).GetValue(2));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mAmount = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3));
				mReceiptAmt = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtNCommon[conTxtNReceiptAmount].Value));

				//''''get the contract end or termination date
				mySQL = " select ccsh.change_status_date from re_contract c ";
				mySQL = mySQL + " inner join re_contract_status cs on c.contract_status_cd = cs.contract_status_cd ";
				mySQL = mySQL + " inner join re_contract_change_status_history ccsh on c.contract_cd = ccsh.contract_cd ";
				mySQL = mySQL + " Where cs.is_active = 0 ";
				mySQL = mySQL + " and ccsh.new_contract_status_cd = c.contract_status_cd ";
				mySQL = mySQL + " and c.contract_cd =" + mContractCd.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mEndingDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(mReturnValue);
				}
				else
				{
					//''the ending date would be the contract date set above
				}
				//'''''''''''''''''''''''''

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("allow_receipt_beyond_contract_expiry_date")))
				{
					//'''make the ending date any future period
					mEndingDate = DateTime.Parse("31-dec-2077");
				}

				mySQL = " select * from re_charge_details ";
				mySQL = mySQL + " where contract_cd = " + mContractCd.ToString();
				mySQL = mySQL + " and due_amount > 0 ";
				mySQL = mySQL + " order by from_date ";
				SqlDataAdapter adap = new SqlDataAdapter(mySQL, SystemVariables.gConn);
				rsLocal.Tables.Clear();
				adap.Fill(rsLocal);
				if (rsLocal.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsLocal.MoveLast was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					mTotalRec = rsLocal.Tables[0].Rows.Count;

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mFirstDate = Convert.ToDateTime(rsLocal.Tables[0].Rows[0]["From_Date"]);
				}
				else
				{

					mySQL = " select max(from_date) as MaxFromDate from re_charge_details ";
					mySQL = mySQL + " where contract_cd = " + mContractCd.ToString();

					SqlDataAdapter adap_2 = new SqlDataAdapter(mySQL, SystemVariables.gConn);
					rsLocal.Tables.Clear();
					adap_2.Fill(rsLocal);

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(rsLocal.Tables[0].Rows[0]["MaxFromDate"]))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mFirstDate = Convert.ToDateTime(rsLocal.Tables[0].Rows[0]["MaxFromDate"]).AddMonths(1);
					}
					else
					{
						//''the firstdate would be the contract date
						mFirstDate = mStartingDate;
					}

					mTotalRec = 0;
				}

				mRow = 0;

				while ((mReceiptAmt) > 0 && ((mFirstDate < mEndingDate) || (mRow < mTotalRec)))
				{
					aVoucherDetails.RedimXArray(new int[]{mRow, mMaxArray}, new int[]{0, 0});

					if (mRow < mTotalRec)
					{

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mReceiptAmt -= Convert.ToDouble(rsLocal.Tables[0].Rows[0]["Due_Amount"]);
						aVoucherDetails.SetValue(0, mRow, gccDiscountAmt);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aVoucherDetails.SetValue(rsLocal.Tables[0].Rows[0]["charge_Amount"], mRow, gccChargedAmt);

						if (mReceiptAmt >= 0)
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
							aVoucherDetails.SetValue(Convert.ToDouble(rsLocal.Tables[0].Rows[0]["Receipt_Amount"]) + Convert.ToDouble(rsLocal.Tables[0].Rows[0]["Discount_Amount"]), mRow, gccPaidAmount);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aVoucherDetails.SetValue(rsLocal.Tables[0].Rows[0]["Due_Amount"], mRow, gccReceivedAmt);
							aVoucherDetails.SetValue(0, mRow, gccDueAmt);
						}
						else
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
							aVoucherDetails.SetValue(Convert.ToDouble(rsLocal.Tables[0].Rows[0]["Receipt_Amount"]) + Convert.ToDouble(rsLocal.Tables[0].Rows[0]["Discount_Amount"]), mRow, gccPaidAmount);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aVoucherDetails.SetValue(Convert.ToDouble(rsLocal.Tables[0].Rows[0]["Due_Amount"]) + mReceiptAmt, mRow, gccReceivedAmt);
							aVoucherDetails.SetValue(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRow, gccChargedAmt))) - (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRow, gccPaidAmount))) + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRow, gccDiscountAmt)))) - Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRow, gccReceivedAmt))), mRow, gccDueAmt);
							mReceiptAmt = 0;
						}

						//''all the default existing charges are considered as Due
						aVoucherDetails.SetValue("Due", mRow, gccStatus);
					}
					else
					{
						mReceiptAmt -= mAmount;

						aVoucherDetails.SetValue(0, mRow, gccPaidAmount);
						if (mReceiptAmt >= 0)
						{
							aVoucherDetails.SetValue(mAmount, mRow, gccChargedAmt);
							aVoucherDetails.SetValue(mAmount, mRow, gccReceivedAmt);
							aVoucherDetails.SetValue(0, mRow, gccDueAmt);
							aVoucherDetails.SetValue(0, mRow, gccDiscountAmt);
						}
						else
						{
							aVoucherDetails.SetValue(mAmount, mRow, gccChargedAmt);
							aVoucherDetails.SetValue(mAmount + mReceiptAmt, mRow, gccReceivedAmt);
							//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
							aVoucherDetails.SetValue(Convert.ToDouble(aVoucherDetails.GetValue(mRow, gccChargedAmt)) - (Convert.ToDouble(Convert.ToDouble(aVoucherDetails.GetValue(mRow, gccPaidAmount)) + Convert.ToDouble(aVoucherDetails.GetValue(mRow, gccReceivedAmt)))), mRow, gccDueAmt);
							aVoucherDetails.SetValue(0, mRow, gccDiscountAmt);
							mReceiptAmt = 0;
						}

						//''any charges added from receipt are considered as advance
						aVoucherDetails.SetValue("Advance", mRow, gccStatus);
					}

					mToDate = mFirstDate.AddMonths(1).AddDays(-1);
					aVoucherDetails.SetValue(StringsHelper.Format(mFirstDate, SystemVariables.gSystemDateFormat), mRow, gccFromDate);
					aVoucherDetails.SetValue(StringsHelper.Format(mToDate, SystemVariables.gSystemDateFormat), mRow, gccToDate);

					//        If CDate(mFirstDate) > CDate(mCurrentMonthEndDate) Then
					//            aVoucherDetails(mRow, gccStatus) = "Advance"
					//        Else
					//            aVoucherDetails(mRow, gccStatus) = "Due"
					//        End If

					mRow++;
					if (mRow < (mTotalRec))
					{
						if (rsLocal.Tables[0].Rows.Count != 0)
						{
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsLocal.MoveNext was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							rsLocal.MoveNext();
						}

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mFirstDate = Convert.ToDateTime(rsLocal.Tables[0].Rows[0]["From_Date"]);
					}
					else
					{
						mFirstDate = mFirstDate.AddMonths(1);
						if (rsLocal.Tables[0].Rows.Count != 0)
						{
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsLocal.MoveNext was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							rsLocal.MoveNext();
						}
					}

					AssignGridLineNumbers();
				}
			}
			else
			{
				MessageBox.Show("Invalid Contract No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtNCommon[conTxtNReceiptAmount].Value = 0;
				txtCommon[conTXTContractNo].Focus();
				return;
			}

			CalculateTotals(0, 0);

			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Refresh();
		}

		//Private Function SumReceiptAmount() As Double
		//Dim mRow As Long
		//Dim sum As Double
		//For mRow = 0 To aVoucherDetails.Count(1) - 1
		//    sum = sum + aVoucherDetails(mRow, gccReceivedAmt)
		//Next mRow
		//SumReceiptAmount = sum
		//End Function

		private void CalculateTotals(int pRowNumber, int pColNumber)
		{
			int cnt = 0;
			decimal mTotalDiscountAmt = 0;
			decimal mTotalPaidAmt = 0;
			decimal mTotalChargeAmt = 0;
			decimal mTotalDueAmt = 0;

			switch(pColNumber)
			{
				case gccReceivedAmt : case gccDiscountAmt : 
					aVoucherDetails.SetValue((Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(pRowNumber, gccChargedAmt))) - Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(pRowNumber, gccPaidAmount))) - Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(pRowNumber, gccReceivedAmt)))) - Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(pRowNumber, gccDiscountAmt))), pRowNumber, gccDueAmt); 
					break;
			}


			decimal mTotalReceivedAmt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mTotalChargeAmt += ((decimal) Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, gccChargedAmt))));
				mTotalPaidAmt += ((decimal) Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, gccPaidAmount))));
				mTotalReceivedAmt += ((decimal) Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, gccReceivedAmt))));
				mTotalDiscountAmt += ((decimal) Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, gccDiscountAmt))));
				mTotalDueAmt += ((decimal) Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, gccDueAmt))));
			}

			//If mTotalReceivedAmt <> 0 Then
			grdVoucherDetails.Columns[gccChargedAmt].FooterText = StringsHelper.Format(mTotalChargeAmt, "###,###,###,##0.000");
			grdVoucherDetails.Columns[gccPaidAmount].FooterText = StringsHelper.Format(mTotalPaidAmt, "###,###,###,##0.000");
			grdVoucherDetails.Columns[gccReceivedAmt].FooterText = StringsHelper.Format(mTotalReceivedAmt, "###,###,###,##0.000");
			grdVoucherDetails.Columns[gccDiscountAmt].FooterText = StringsHelper.Format(mTotalDiscountAmt, "###,###,###,##0.000");
			grdVoucherDetails.Columns[gccDueAmt].FooterText = StringsHelper.Format(mTotalDueAmt, "###,###,###,##0.000");
			//Else
			//    grdVoucherDetails.Columns(gccReceivedAmt).FooterText = ""
			//End If

			txtNCommon[conTxtNReceiptAmount].Value = mTotalReceivedAmt;
		}

		private void UpdateReceiptChargeInformation(int pReceiptCd, double pContractCd, int pRow, System.DateTime pCurrentMonthLastDate)
		{

			object mChargeCd = null;
			int mIsAdvance = 0;

			SqlDataReader rsLocal = null;


			//If CDate(aVoucherDetails(pRow, gccFromDate)) > pCurrentMonthLastDate Then
			//    mIsAdvance = 1
			//Else
			//    mIsAdvance = 0
			//End If

			string mySQL = " select contract_no from re_contract ";
			mySQL = mySQL + " where contract_cd = " + pContractCd.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mContractNo = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mySQL));

			mySQL = " select rcd.charge_cd from re_charge_details rcd ";
			mySQL = mySQL + " where rcd.contract_cd = " + pContractCd.ToString();
			mySQL = mySQL + " and rcd.due_amount > 0 ";
			mySQL = mySQL + " and rcd.from_date = '" + Convert.ToString(aVoucherDetails.GetValue(pRow, gccFromDate)) + "'";

			SqlCommand sqlCommand = new SqlCommand(mySQL, SystemVariables.gConn);
			rsLocal = sqlCommand.ExecuteReader();
			if (rsLocal.Read())
			{
				mySQL = "update re_charge_details ";
				mySQL = mySQL + " set Receipt_Amount = Receipt_Amount + " + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(pRow, gccReceivedAmt))).ToString();
				mySQL = mySQL + " , discount_amount = discount_amount + " + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(pRow, gccDiscountAmt))).ToString();
				mySQL = mySQL + " where charge_cd = " + Convert.ToString(rsLocal["Charge_Cd"]);
				mySQL = mySQL + " and from_date = '" + Convert.ToString(aVoucherDetails.GetValue(pRow, gccFromDate)) + "'";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mySQL;
				TempCommand.ExecuteNonQuery();

				mChargeCd = rsLocal["charge_cd"];
			}
			else
			{
				mySQL = "insert into  re_charge_details ";
				mySQL = mySQL + " (Contract_Cd ,Generate_Type_cd ,Charge_Amount ,Receipt_Amount ";
				mySQL = mySQL + " , discount_amount ";
				mySQL = mySQL + " , from_Date , to_date, reference_no , user_cd ) ";
				mySQL = mySQL + " values ( ";
				mySQL = mySQL + pContractCd.ToString();
				mySQL = mySQL + " , 3 ";
				mySQL = mySQL + " ," + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(pRow, gccChargedAmt))).ToString();
				mySQL = mySQL + " ," + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(pRow, gccReceivedAmt))).ToString();
				mySQL = mySQL + " ," + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(pRow, gccDiscountAmt))).ToString();
				mySQL = mySQL + " ,'" + Convert.ToString(aVoucherDetails.GetValue(pRow, gccFromDate)) + "'";
				mySQL = mySQL + " ,'" + Convert.ToString(aVoucherDetails.GetValue(pRow, gccToDate)) + "'";
				mySQL = mySQL + " ,'" + Conversion.Str(mContractNo) + "'";
				mySQL = mySQL + " ," + SystemVariables.gLoggedInUserCode.ToString();
				mySQL = mySQL + " ) ";
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mySQL;
				TempCommand_2.ExecuteNonQuery();

				mySQL = "select scope_identity()";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mChargeCd = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
			}

			if (Convert.ToString(aVoucherDetails.GetValue(pRow, gccStatus)) == "Advance")
			{
				mIsAdvance = 1;
			}
			else
			{
				mIsAdvance = 0;
			}

			mySQL = "insert into  re_receipt_details ";
			mySQL = mySQL + " (Entry_Id, Charge_Cd, Charge_Amount, Receipt_Amount ";
			mySQL = mySQL + " ,Discount_Amount, From_Date, To_Date, Is_Advance, Comments) ";
			mySQL = mySQL + " values ( ";
			mySQL = mySQL + pReceiptCd.ToString();
			mySQL = mySQL + " ," + ReflectionHelper.GetPrimitiveValue<string>(mChargeCd);
			mySQL = mySQL + " ," + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(pRow, gccChargedAmt))).ToString();
			mySQL = mySQL + " ," + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(pRow, gccReceivedAmt))).ToString();
			mySQL = mySQL + " ," + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(pRow, gccDiscountAmt))).ToString();
			mySQL = mySQL + " ,'" + Convert.ToString(aVoucherDetails.GetValue(pRow, gccFromDate)) + "'";
			mySQL = mySQL + " ,'" + Convert.ToString(aVoucherDetails.GetValue(pRow, gccToDate)) + "'";
			mySQL = mySQL + " , " + Conversion.Str(mIsAdvance);
			mySQL = mySQL + " , '" + Convert.ToString(aVoucherDetails.GetValue(pRow, gccRemarks)) + "'";
			mySQL = mySQL + " )";
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mySQL;
			TempCommand_3.ExecuteNonQuery();

			rsLocal.Close();

		}

		public bool saveRecord(bool pPostGl = false)
		{
			bool result = false;
			object mReturnValue = null;
			int cnt = 0;
			int mEntryID = 0;
			int mContractCd = 0;
			System.DateTime mGenerateDate = DateTime.FromOADate(0);
			System.DateTime mLastMonthEndDate = DateTime.FromOADate(0);
			System.DateTime mTempDate = DateTime.FromOADate(0);
			System.DateTime mCurrentMonthLastDate = DateTime.FromOADate(0);
			bool mPostToGLOnTransactionPosting = false;
			string mySQL = "";


			try
			{
				grdVoucherDetails.UpdateData();

				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mPostToGLOnTransactionPosting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("post_to_gl_on_transaction_posting"));

				mySQL = " select Contract_Cd from re_contract ";
				mySQL = mySQL + " where contract_No = " + txtCommon[conTXTContractNo].Text;
				mySQL = mySQL + " and status = 2 ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Contract No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommon[conTXTContractNo].Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mContractCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}


				SystemVariables.gConn.BeginTransaction();

				mySQL = " select generate_date from re_generate_history ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mGenerateDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(mReturnValue);
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLastMonthEndDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(mReturnValue);
					mTempDate = mGenerateDate.AddMonths(1);

					mGenerateDate = mGenerateDate.AddMonths(2);
					mCurrentMonthLastDate = DateTime.Parse("01-" + mGenerateDate.Month.ToString() + "-" + mGenerateDate.Year.ToString()).AddDays(-1);

					if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(dateCommon[conTxtDReceiptDate].DisplayText).Month != mTempDate.Month)
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show("Receipt date should be in the current month !", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}
				else
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show("Define Generate Date, contact system administrator!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					dateCommon[conTxtDReceiptDate].Focus();
					return result;
				}


				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					txtCommon[conTxtReceiptNo].Text = SystemProcedure2.GetNewNumber("re_receipt", "receipt_No", 2);

					mySQL = " insert into RE_Receipt ";
					mySQL = mySQL + " (Receipt_No,Reference_No,Contract_Cd,Receipt_Date ";
					mySQL = mySQL + " , Paid_By_Person,Receipt_Amount ";
					mySQL = mySQL + " , comments,User_Cd) ";
					mySQL = mySQL + " values( ";
					mySQL = mySQL + " '" + txtCommon[conTxtReceiptNo].Text + "'";
					mySQL = mySQL + " ,'" + txtCommon[conTXTReferenceNo].Text + "'";
					mySQL = mySQL + " ," + mContractCd.ToString();
					mySQL = mySQL + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(dateCommon[conTxtDReceiptDate].DisplayText) + "'";
					mySQL = mySQL + " ,N'" + txtCommon[conTxtPaidBy].Text + "'";
					mySQL = mySQL + " ," + ReflectionHelper.GetPrimitiveValue<string>(txtNCommon[conTxtNReceiptAmount].Value);
					mySQL = mySQL + " ,N'" + txtRemarks.Text + "'";
					mySQL = mySQL + " ," + SystemVariables.gLoggedInUserCode.ToString();
					mySQL = mySQL + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mySQL;
					TempCommand.ExecuteNonQuery();

					mySQL = "select scope_identity()";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryID = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mySQL));

				}
				else if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{ 
					CalculateTotals(0, 0);

					//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryID = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);

					mySQL = " update re_receipt ";
					mySQL = mySQL + " set receipt_no = " + txtCommon[conTxtReceiptNo].Text;
					mySQL = mySQL + " , reference_no = '" + txtCommon[conTXTReferenceNo].Text + "'";
					mySQL = mySQL + " , contract_cd = " + mContractCd.ToString();
					mySQL = mySQL + " , receipt_date = '" + ReflectionHelper.GetPrimitiveValue<string>(dateCommon[conTxtDReceiptDate].DisplayText) + "'";
					mySQL = mySQL + " , paid_by_person = N'" + txtCommon[conTxtPaidBy].Text + "'";
					mySQL = mySQL + " , receipt_amount = " + ReflectionHelper.GetPrimitiveValue<string>(txtNCommon[conTxtNReceiptAmount].Value);
					mySQL = mySQL + " , comments = N'" + txtRemarks.Text + "'";
					mySQL = mySQL + " where Entry_Id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mySQL;
					TempCommand_2.ExecuteNonQuery();

					DeleteReceiptDetails(mEntryID);
				}

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					//If Not IsItEmpty(aVoucherDetails(Cnt, gccReceivedAmt), NumberType) Then
					UpdateReceiptChargeInformation(mEntryID, mContractCd, cnt, mCurrentMonthLastDate);
					//End If
				}

				if (pPostGl)
				{
					if (SystemREProcedure.PostREReceiptsStatus(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue)))
					{

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_re_gl_link")) && mPostToGLOnTransactionPosting)
						{
							if (!SystemREProcedure.PostREReceiptsToGL(mLastMonthEndDate, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue)))
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								return false;
							}

							if (!SystemREProcedure.PostREAdvanceReceiptsToGL(mLastMonthEndDate, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), false))
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								return false;
							}
						}
					}
					else
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					MessageBox.Show("Receipt has been saved with no : " + txtCommon[conTxtReceiptNo].Text, "Press Enter To Continue", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				return true;
			}
			catch (System.Exception excep)
			{


				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
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
			SystemProcedure2.ClearDateBox(this);
			//dateCommon (conTxtDStartingDate)
			//dateCommon(conTxtDEndingDate).Value = ""

			//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			aVoucherDetails.Clear();
			aVoucherDetails.RedimXArray(new int[]{0, mMaxArray}, new int[]{0, 0});
			aVoucherDetails.SetValue(1, 0, 0);

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Enabled = true;


			//''''*************************************************************************
			//Set the form caption
			SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Receipt Transaction" : "Receipt Transaction");
			//''''*************************************************************************

			txtCommon[conTxtReceiptNo].Text = SystemProcedure2.GetNewNumber("re_receipt", "receipt_No", 2);

			txtCommon[conTXTContractNo].Enabled = true;
			txtNCommon[conTxtNReceiptAmount].Enabled = true;
			txtNCommon[conTxtNReceiptAmount].BackColor = Color.White;


			System.DateTime mCurrentMonthDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(SystemREProcedure.GetRELastMonthEndDate());
			mCurrentMonthDate = mCurrentMonthDate.AddMonths(1);

			if (mCurrentMonthDate.Month == DateTime.Today.Month)
			{
				dateCommon[conTxtDReceiptDate].Value = DateTime.Today;
			}
			else
			{
				dateCommon[conTxtDReceiptDate].Value = mCurrentMonthDate;
			}



			FirstFocusObject.Focus();

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

			DeleteReceiptDetails(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mySQL = "delete from re_receipt_details where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mySQL;
				TempCommand.ExecuteNonQuery();

				mySQL = "delete from re_receipt where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mySQL;
				TempCommand_2.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Item cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

		public void UpdateGridDetails(object SearchValue)
		{

			int cnt = 0;

			string mySQL = " select dt.*, (cd.Receipt_Amount + cd.discount_amount) as Paid_Amount ";
			mySQL = mySQL + " from re_receipt mt ";
			mySQL = mySQL + " inner join re_receipt_details dt on mt.Entry_Id = dt.Entry_Id ";
			mySQL = mySQL + " inner join re_charge_details cd on dt.charge_cd = cd.charge_cd ";
			mySQL = mySQL + " where mt.Entry_Id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

			SqlDataReader rsLocal = null;

			SqlCommand sqlCommand = new SqlCommand(mySQL, SystemVariables.gConn);
			rsLocal = sqlCommand.ExecuteReader();
			rsLocal.Read();

			do 
			{

				aVoucherDetails.RedimXArray(new int[]{cnt, mMaxArray}, new int[]{0, 0});

				if (Convert.ToBoolean(rsLocal["Is_Advance"]))
				{
					aVoucherDetails.SetValue("Advance", cnt, gccStatus);
				}
				else
				{
					aVoucherDetails.SetValue("Due", cnt, gccStatus);
				}

				aVoucherDetails.SetValue(StringsHelper.Format(rsLocal["From_Date"], SystemVariables.gSystemDateFormat), cnt, gccFromDate);
				aVoucherDetails.SetValue(StringsHelper.Format(rsLocal["To_Date"], SystemVariables.gSystemDateFormat), cnt, gccToDate);
				aVoucherDetails.SetValue(rsLocal["Charge_Amount"], cnt, gccChargedAmt);
				aVoucherDetails.SetValue(Convert.ToDouble(rsLocal["Paid_Amount"]) - Convert.ToDouble(rsLocal["Receipt_Amount"]) - Convert.ToDouble(rsLocal["discount_amount"]), cnt, gccPaidAmount);
				aVoucherDetails.SetValue(rsLocal["Receipt_Amount"], cnt, gccReceivedAmt);
				aVoucherDetails.SetValue(rsLocal["discount_amount"], cnt, gccDiscountAmt);
				aVoucherDetails.SetValue(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, gccChargedAmt))) - Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, gccPaidAmount))) - Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, gccReceivedAmt))) - Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, gccDiscountAmt))), cnt, gccDueAmt);
				aVoucherDetails.SetValue(rsLocal["Comments"], cnt, gccRemarks);

				cnt++;

				AssignGridLineNumbers();

			}
			while(rsLocal.Read());

			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);
			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Refresh();

		}

		public void GetRecord(object SearchValue)
		{
			string mySQL = "";
			DataSet localRec = null;
			DataSet rsTempRec = null;

			try
			{

				mySQL = "select r.Entry_Id,r.receipt_date, r.receipt_no, receipt_amount ";
				mySQL = mySQL + " , r.Paid_by_Person, r.contract_cd, r.status ";
				mySQL = mySQL + " , c.contract_no, c.contract_amt ";
				mySQL = mySQL + " , Tenant_No , L_tenant_name,A_tenant_name ";
				mySQL = mySQL + " , r.Reference_No , r.comments ";
				mySQL = mySQL + " , pm.payment_method_no, pm.l_payment_method_name, pm.a_payment_method_name ";
				mySQL = mySQL + " , c.reference_no contract_reference_no , c.starting_date, c.ending_date ";
				mySQL = mySQL + " , cs.status_no, cs.l_status_name, cs.a_status_name ";
				mySQL = mySQL + " , c.contract_cd ";
				mySQL = mySQL + " from re_receipt r ";
				mySQL = mySQL + " inner join re_contract c  on r.contract_cd = c.contract_cd ";
				mySQL = mySQL + " inner join re_tenant t on c.tenant_cd = t.tenant_cd ";
				mySQL = mySQL + " inner join re_payment_method pm on c.payment_method_cd = pm.payment_method_cd ";
				mySQL = mySQL + " inner join re_contract_status cs on c.contract_status_cd = cs.contract_status_cd ";
				mySQL = mySQL + " where Entry_Id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				localRec = new DataSet();
				SqlDataAdapter adap = new SqlDataAdapter(mySQL, SystemVariables.gConn);
				localRec.Tables.Clear();
				adap.Fill(localRec);
				if (localRec.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mSearchValue = localRec.Tables[0].Rows[0]["Entry_Id"];

					txtCommon[conTXTContractNo].Enabled = false;
					txtNCommon[conTxtNReceiptAmount].Enabled = false;
					txtNCommon[conTxtNReceiptAmount].BackColor = Color.FromArgb(239, 239, 239); //gDisableColumnBackColor

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTxtReceiptNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Receipt_No"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTXTReferenceNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Reference_No"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTXTContractNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Contract_No"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					dateCommon[conTxtDReceiptDate].Value = localRec.Tables[0].Rows[0]["Receipt_Date"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtNCommon[conTxtNReceiptAmount].Value = localRec.Tables[0].Rows[0]["Receipt_Amount"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblContractAmt].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["Contract_Amt"], "###,###,###,##0.000");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTxtPaidBy].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Paid_By_Person"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtRemarks.Text = Convert.ToString(localRec.Tables[0].Rows[0]["comments"]);

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblTenantNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["tenant_no"]);

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblPayMethodNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["payment_method_no"]);

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblContractUnitNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["contract_reference_no"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					dateCommon[conTxtDStartingDate].Value = localRec.Tables[0].Rows[0]["starting_date"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					dateCommon[conTxtDEndingDate].Value = localRec.Tables[0].Rows[0]["ending_date"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblStatusNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["status_no"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblStatusName].Text = Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? localRec.Tables[0].Rows[0]["l_status_name"] : localRec.Tables[0].Rows[0]["a_status_name"]);

					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conDlblTenantName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["L_Tenant_Name"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conDlblPayMethodName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["L_payment_method_Name"]);
					}
					else
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conDlblTenantName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["A_Tenant_Name"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conDlblPayMethodName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["a_payment_method_Name"]);
					}

					//''''''''get the unit no.
					rsTempRec = new DataSet();
					mySQL = " select piud.unit_no ";
					mySQL = mySQL + " from re_property_item_unit_details piud ";
					mySQL = mySQL + " inner join re_contract_details cd on piud.unit_cd = cd.unit_cd ";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mySQL = mySQL + " where cd.contract_cd = " + Convert.ToString(localRec.Tables[0].Rows[0]["contract_cd"]);
					SqlDataAdapter adap_2 = new SqlDataAdapter(mySQL, SystemVariables.gConn);
					rsTempRec.Tables.Clear();
					adap_2.Fill(rsTempRec);

					//UPGRADE_ISSUE: (2064) ADODB.StringFormatEnum property StringFormatEnum.adClipString was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempRec.GetString was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					txtCommonDisplay[conDlblContractUnitNo].Text = rsTempRec.GetString(UpgradeStubs.ADODB_StringFormatEnum.getadClipString(), -1, "", ",", "");
					rsTempRec = null;
					//'''''''''''''''''''''''''''


					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;

					//Set the form caption and Get the Voucher Status
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, Convert.ToInt32(localRec.Tables[0].Rows[0]["status"]), CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Receipt Transaction" : "Receipt Transaction");
				}

				Application.DoEvents();

				UpdateGridDetails(SearchValue);

				CalculateTotals(0, 0);

				localRec = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9018000));
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
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 3);
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
			}
			else
			{


				if (SystemProcedure2.IsItEmpty(txtCommon[conTXTContractNo].Text, SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("You have to enter the contract No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txtCommon[conTXTContractNo].Focus();
				}
				else
				{

					if (!Information.IsDate(dateCommon[conTxtDReceiptDate].Text))
					{
						MessageBox.Show("You have to enter the receipt date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						dateCommon[conTxtDReceiptDate].Focus();
					}
					else
					{

						if (ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[conTxtNReceiptAmount].Value) == 0 && aVoucherDetails.GetLength(0) == 0)
						{
							MessageBox.Show("Please enter the receipt Amount", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							if (txtNCommon[conTxtNReceiptAmount].Enabled)
							{
								txtNCommon[conTxtNReceiptAmount].Focus();
							}

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
			SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

			UserAccess = null;
			oThisFormToolBar = null;
			frmREReceiptTransaction.DefInstance = null;
		}

		public void FindRoutine(string pObjectName)
		{

			object mTempSearchValue = null;
			//Dim mContract_Cd_Value As Long
			string mySQL = "";

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
					case conTXTContractNo : 
						mySQL = " status = 2 "; 
						if (chkContractCriteria.CheckState == CheckState.Unchecked)
						{
							mySQL = mySQL + " and cs.is_active = 1 ";
						} 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9015000, "1392", mySQL)); 
						//            If Not IsNull(mTempSearchValue) Then 
						//                mContract_Cd_Value = mTempSearchValue(0) 
						//            End If 
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


		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			grdVoucherDetails.UpdateData();


			CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);
			grdVoucherDetails.Refresh();

		}

		private void grdVoucherDetails_BeforeColUpdate(object eventSender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			object OldValue = eventArgs.OldValue;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), gccChargedAmt))) - Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[gccPaidAmount].Value)) - Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[gccReceivedAmt].Value)) - Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[gccDiscountAmt].Value)) < 0)
				{
					MessageBox.Show("Please Enter a Valid Amount ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					Cancel = 1;
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		private void txtCommon_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);
			if (Index == conTxtReceiptNo)
			{
				txtCommon[conTxtReceiptNo].Text = SystemProcedure2.GetNewNumber("re_receipt", "receipt_No", 2);
			}
			else
			{
				FindRoutine("txtCommon#" + Index.ToString().Trim());
			}
		}


		private void txtCommon_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommon, eventSender);
			DataSet rsTempRec = null;
			object mTempValue = null;
			string mySQL = "";
			int mLinkedTextBoxIndex = 0;

			try
			{
				switch(Index)
				{
					case conTXTContractNo : 
						mySQL = " select tenant_no , L_Tenant_Name, A_Tenant_Name, Contract_Amt "; 
						mySQL = mySQL + " , pm.payment_method_no, pm.l_payment_method_name, pm.a_payment_method_name "; 
						mySQL = mySQL + " , c.reference_no , c.starting_date, c.ending_date "; 
						mySQL = mySQL + " , cs.status_no, cs.l_status_name, cs.a_status_name "; 
						mySQL = mySQL + " , c.contract_cd "; 
						mySQL = mySQL + " from re_contract c "; 
						mySQL = mySQL + " inner join re_tenant t on c.tenant_cd = t.tenant_cd "; 
						mySQL = mySQL + " inner join re_payment_method pm on c.payment_method_cd = pm.payment_method_cd "; 
						mySQL = mySQL + " inner join re_contract_status cs on c.contract_status_cd = cs.contract_status_cd "; 
						mySQL = mySQL + " where contract_no = " + txtCommon[Index].Text; 
						mySQL = mySQL + " and status = 2 "; 
						mLinkedTextBoxIndex = conDlblTenantName; 
						break;
					case conTxtNReceiptAmount : 
						GetContractItems(); 
						return;
					default:
						return;
				}

				if (!SystemProcedure2.IsItEmpty(txtCommon[Index].Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtCommonDisplay[mLinkedTextBoxIndex].Text = "";
						txtCommon[Index].Tag = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						if (Index == conTXTContractNo)
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonDisplay[conDlblTenantNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
							txtCommonDisplay[conDlblTenantName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(1) : ((Array) mTempValue).GetValue(2));

							txtCommonDisplay[conDlblContractAmt].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(3)), "###,###,###,##0.000");

							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonDisplay[conDlblPayMethodNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));
							txtCommonDisplay[conDlblPayMethodName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(5) : ((Array) mTempValue).GetValue(6));

							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonDisplay[conDlblContractUnitNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(7));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							dateCommon[conTxtDStartingDate].Value = ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(8));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							dateCommon[conTxtDEndingDate].Value = ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(9));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonDisplay[conDlblStatusNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(10));
							txtCommonDisplay[conDlblStatusName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(11) : ((Array) mTempValue).GetValue(12));

							rsTempRec = new DataSet();
							mySQL = " select piud.unit_no ";
							mySQL = mySQL + " from re_property_item_unit_details piud ";
							mySQL = mySQL + " inner join re_contract_details cd on piud.unit_cd = cd.unit_cd ";
							mySQL = mySQL + " where cd.contract_cd = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(13));
							SqlDataAdapter adap = new SqlDataAdapter(mySQL, SystemVariables.gConn);
							rsTempRec.Tables.Clear();
							adap.Fill(rsTempRec);

							//UPGRADE_ISSUE: (2064) ADODB.StringFormatEnum property StringFormatEnum.adClipString was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempRec.GetString was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							txtCommonDisplay[conDlblContractUnitNo].Text = rsTempRec.GetString(UpgradeStubs.ADODB_StringFormatEnum.getadClipString(), -1, "", ",", "");
							rsTempRec = null;

							txtCommon[Index].Enabled = false;
						}
						else
						{
							txtCommonDisplay[mLinkedTextBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1));

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

		private void txtNCommon_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtNCommon, eventSender);
			if (Index == conTxtNReceiptAmount)
			{
				if (ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[Index].Value) != 0)
				{
					GetContractItems();
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			//On Error Resume Next

			switch(ColIndex)
			{
				case gccChargedAmt : case gccDiscountAmt : case gccDueAmt : case gccPaidAmount : case gccReceivedAmt : 
					if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
					{
						Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,###,##0.000");
					}
					else
					{
						Value = "";
					} 
					break;
			}
		}

		private void DeleteReceiptDetails(int pEntryId)
		{

			StringBuilder mySQL = new StringBuilder();
			mySQL.Append(" select charge_cd, receipt_amount, from_date , discount_amount from re_receipt_details ");
			mySQL.Append(" where entry_id = " + pEntryId.ToString());

			SqlDataReader rsLocal = null;

			SqlCommand sqlCommand = new SqlCommand(mySQL.ToString(), SystemVariables.gConn);
			rsLocal = sqlCommand.ExecuteReader();
			rsLocal.Read();

			mySQL = new StringBuilder(" delete from re_receipt_details ");
			mySQL.Append(" where entry_id=" + pEntryId.ToString());
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mySQL.ToString();
			TempCommand.ExecuteNonQuery();

			do 
			{
				mySQL = new StringBuilder(" update re_charge_details ");
				mySQL.Append(" set receipt_amount = receipt_amount - " + Convert.ToString(rsLocal["receipt_amount"]));
				mySQL.Append(" , discount_amount = discount_amount - " + Convert.ToString(rsLocal["discount_amount"]));
				mySQL.Append(" where charge_cd = " + Convert.ToString(rsLocal["charge_cd"]));
				mySQL.Append(" and from_date ='" + Convert.ToString(rsLocal["from_date"]) + "'");
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mySQL.ToString();
				TempCommand_2.ExecuteNonQuery();

				mySQL = new StringBuilder(" delete re_charge_details ");
				mySQL.Append(" where charge_cd =" + Convert.ToString(rsLocal["charge_cd"]));
				mySQL.Append(" and generate_type_cd in ( 3, 5) ");
				mySQL.Append(" and status = 1 ");
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mySQL.ToString();
				TempCommand_3.ExecuteNonQuery();

			}
			while(rsLocal.Read());
			rsLocal.Close();

		}

		public bool Post()
		{
			bool result = false;
			DialogResult ans = (DialogResult) 0;
			System.DateTime mLastMonthEndDate = DateTime.FromOADate(0);
			bool mPostToGLOnTransactionPosting = false;

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

			//if the user clicks on OK button in the frmPost form
			//If frmTemp.mLastButtonClicked = 1 And frmTemp.mApprove = True Then
			if (frmTemp.mApprove)
			{
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mPostToGLOnTransactionPosting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("post_to_gl_on_transaction_posting"));


				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					//Display this message if status is active, which will require to save the record first
					ans = MessageBox.Show(SystemConstants.msg19 + "\r" + "\r" + SystemConstants.msg7, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				}
				else
				{
					//Display this message if status is not active, which will not require to save the record first
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
							//'''''''''''''''''''''''''''
							mLastMonthEndDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(SystemREProcedure.GetRELastMonthEndDate());

							if (SystemREProcedure.PostREReceiptsStatus(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue)))
							{
								//**--check if the transaction should be posted to gl after approval
								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_re_gl_link")) && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("post_to_gl_on_transaction_posting"))) == TriState.True)
								{
									if (!SystemREProcedure.PostREReceiptsToGL(mLastMonthEndDate, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue)))
									{
										//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
										SystemVariables.gConn.RollbackTrans();
										goto mDestroy;
									}

									if (!SystemREProcedure.PostREAdvanceReceiptsToGL(mLastMonthEndDate, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), false))
									{
										//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
										SystemVariables.gConn.RollbackTrans();
										goto mDestroy;
									}
								}
							}
							else
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								goto mDestroy;
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

		public void PrintReport(int pEntryId = 0)
		{
			int mEntryID = 0;
			frmSysReportPrint ofrmSysReportPrint = frmSysReportPrint.CreateInstance();

			try
			{

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryID = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
				}
				else
				{
					if (!SystemProcedure2.IsItEmpty(pEntryId))
					{
						mEntryID = pEntryId;
					}
					else
					{
						return;
					}
				}

				//\crystal_files\RASHID_RENT

				SystemReports.GetCrystalReport(100070000, 2, "5457", Conversion.Str(mEntryID), false);
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}
	}
}