
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmARAPVoucherLinking
		: System.Windows.Forms.Form
	{

		public frmARAPVoucherLinking()
{
InitializeComponent();
} 
 public  void frmARAPVoucherLinking_old()
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


		private void frmARAPVoucherLinking_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private SystemVariables.SystemFormModes mFormMode = (SystemVariables.SystemFormModes) 0;
		private int mLedgerCode = 0;
		private string mLedgerNo = "";
		private string mLedgerName = "";
		private string mDrCrType = "";
		private string mCurrencySymbol = "";
		private int mLineNo = 0;
		private double mLedgerAmount = 0;

		private XArrayHelper aParentAdjustedVoucherDetails = null;
		private XArrayHelper _aCurrentAdjustedVoucherDetails = null;
		private XArrayHelper aCurrentAdjustedVoucherDetails
		{
			get
			{
				if (_aCurrentAdjustedVoucherDetails is null)
				{
					_aCurrentAdjustedVoucherDetails = new XArrayHelper();
				}
				return _aCurrentAdjustedVoucherDetails;
			}
			set
			{
				_aCurrentAdjustedVoucherDetails = value;
			}
		}


		private const int mLineNoColumn = 0;
		private const int mVoucherTypeColumn = 1;
		private const int mVoucherNoColumn = 2;
		private const int mReferenceNoColumn = 3;
		private const int mDetailsRemarksColumn = 4;
		private const int mVoucherDateColumn = 5;
		private const int mDueDateColumn = 6;
		private const int mVoucherAmountColumn = 7;
		private const int mDueAmountColumn = 8;
		private const int mClearedAmountColumn = 9;
		private const int mRemarksColumn = 10;
		private const int mTimeStampColumn = 11;

		//contants for voucher linking module
		private const int conVLLineNoColumn = 0;
		private const int conVLDrCrTypeColumn = 1;
		private const int conVLSourceLineNoColumn = 2;
		private const int conVLAgainstLineNoColumn = 3;
		private const int conVLAdjustedAmountColumn = 4;
		private const int conVLLinkedTimeStampColumn = 5;
		private const int conVLLinkedRemarksColumn = 6;

		public SystemVariables.SystemFormModes FormMode
		{
			set
			{
				mFormMode = value;
			}
		}


		public int LedgerCode
		{
			set
			{
				mLedgerCode = value;
			}
		}


		public string DrCrType
		{
			set
			{
				mDrCrType = value;
			}
		}


		public string LedgerNo
		{
			set
			{
				mLedgerNo = value;
			}
		}


		public string LedgerName
		{
			set
			{
				mLedgerName = value;
			}
		}


		public string CurrencySymbol
		{
			set
			{
				mCurrencySymbol = value;
			}
		}


		public int LineNo
		{
			set
			{
				mLineNo = value;
			}
		}


		public double LedgerAmount
		{
			set
			{
				mLedgerAmount = value;
			}
		}


		public XArrayHelper SetVoucherSourceArray
		{
			set
			{
				aParentAdjustedVoucherDetails = value;
			}
		}


		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			this.Hide();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			grdVoucherDetails.UpdateData();

			int cnt = 0;
			int tempForEndVar = aCurrentAdjustedVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (!SystemProcedure2.IsItEmpty(aCurrentAdjustedVoucherDetails.GetValue(cnt, mClearedAmountColumn), SystemVariables.DataType.NumberType))
				{
					aParentAdjustedVoucherDetails.RedimXArray(new int[]{aParentAdjustedVoucherDetails.GetLength(0), aParentAdjustedVoucherDetails.GetLength(1) - 1}, new int[]{0, 0});
					aParentAdjustedVoucherDetails.SetValue(mLineNo, aParentAdjustedVoucherDetails.GetLength(0) - 1, conVLLineNoColumn);
					aParentAdjustedVoucherDetails.SetValue(mDrCrType, aParentAdjustedVoucherDetails.GetLength(0) - 1, conVLDrCrTypeColumn);
					if (mDrCrType == "D")
					{
						aParentAdjustedVoucherDetails.SetValue(0, aParentAdjustedVoucherDetails.GetLength(0) - 1, conVLSourceLineNoColumn);
						aParentAdjustedVoucherDetails.SetValue(aCurrentAdjustedVoucherDetails.GetValue(cnt, mLineNoColumn), aParentAdjustedVoucherDetails.GetLength(0) - 1, conVLAgainstLineNoColumn);
					}
					else
					{
						aParentAdjustedVoucherDetails.SetValue(aCurrentAdjustedVoucherDetails.GetValue(cnt, mLineNoColumn), aParentAdjustedVoucherDetails.GetLength(0) - 1, conVLSourceLineNoColumn);
						aParentAdjustedVoucherDetails.SetValue(0, aParentAdjustedVoucherDetails.GetLength(0) - 1, conVLAgainstLineNoColumn);
					}
					aParentAdjustedVoucherDetails.SetValue(aCurrentAdjustedVoucherDetails.GetValue(cnt, mClearedAmountColumn), aParentAdjustedVoucherDetails.GetLength(0) - 1, conVLAdjustedAmountColumn);
					aParentAdjustedVoucherDetails.SetValue(aCurrentAdjustedVoucherDetails.GetValue(cnt, mTimeStampColumn), aParentAdjustedVoucherDetails.GetLength(0) - 1, conVLLinkedTimeStampColumn);
					aParentAdjustedVoucherDetails.SetValue(aCurrentAdjustedVoucherDetails.GetValue(cnt, mRemarksColumn), aParentAdjustedVoucherDetails.GetLength(0) - 1, conVLLinkedRemarksColumn);
				}
			}
			this.Hide();
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				object mOldValue = null;
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}
				else if (KeyCode == 27)
				{ 
					cmdOKCancel_CancelClick(cmdOKCancel, null);
					return;
				}
				decimal mAmountToBeAdjusted = 0;
				decimal mDueAmount = 0;
				decimal mClearAmount = 0;
				decimal mAdjustedAmount = 0;
				if (this.ActiveControl.Name == "grdVoucherDetails" && Shift == 0)
				{
					if (grdVoucherDetails.Col == mClearedAmountColumn)
					{
						if ((KeyCode == 8) || (KeyCode == 46) || (KeyCode == 27))
						{
							//
						}
						else if ((KeyCode >= 48 && KeyCode <= 57) || (KeyCode >= 96 && KeyCode <= 105) || (KeyCode == 190) || (KeyCode == 110))
						{ 
							//
						}
						else if (KeyCode == 32)
						{ 


							mAmountToBeAdjusted = Decimal.Parse(StringsHelper.Format(txtToBeAdjusted.Text, "##########0.000"), NumberStyles.Currency | NumberStyles.AllowExponent);
							mDueAmount = Decimal.Parse(StringsHelper.Format(aCurrentAdjustedVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), mDueAmountColumn), "##########0.000"), NumberStyles.Currency | NumberStyles.AllowExponent);

							if (mDueAmount <= mAmountToBeAdjusted)
							{
								mClearAmount = mDueAmount;
							}
							else
							{
								mClearAmount = mAmountToBeAdjusted;
							}

							mOldValue = aCurrentAdjustedVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), mClearedAmountColumn);
							if (!CheckAmountValidity(grdVoucherDetails.Col, mOldValue, mClearAmount.ToString(), ref mAdjustedAmount))
							{

							}
							else
							{
								aCurrentAdjustedVoucherDetails.SetValue(mClearAmount, ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), mClearedAmountColumn);
								grdVoucherDetails.Rebind(true);
								if (mAdjustedAmount > 0)
								{
									txtAmountAdjusted.Value = ReflectionHelper.GetPrimitiveValue<double>(txtAmountAdjusted.Value) + ((double) mAdjustedAmount);
								}
								else
								{
									txtAmountAdjusted.Value = ReflectionHelper.GetPrimitiveValue<double>(txtAmountAdjusted.Value) - Math.Abs((double) mAdjustedAmount);
								}
							}
						}
						else
						{
							KeyCode = 0;
						}
					}
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
			fraVoucherAdjustment.Left = 0;
			fraVoucherAdjustment.Top = 0;
			this.Width = fraVoucherAdjustment.Width;
			this.Height = fraVoucherAdjustment.Height;

			//Call DefineVoucherGrid


			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, false, true, ColorTranslator.ToOle(Color.FromArgb(255, 255, 255)).ToString(), ColorTranslator.ToOle(Color.FromArgb(0, 0, 0)).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2.4f, 1.4f, (0xC0C0C0).ToString());
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "", 400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Type", 500, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Voucher No.", 1050, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Reference No.", 1150, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1050, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Voucher Date", 1050, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Due Date", 1050, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Voucher Amount", 1000, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount Due", 1000, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount Cleared", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 50);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "", 400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

			GetVoucher();

			txtLdgrNo.Text = mLedgerNo;
			txtLdgrName.Text = mLedgerName;
			txtCurrencySymbol.Text = mCurrencySymbol;
			txtAmountToAdjust.Value = mLedgerAmount;
			txtAmountAdjusted.Value = 0;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				aParentAdjustedVoucherDetails = null;
				aCurrentAdjustedVoucherDetails = null;
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
				decimal mAdjustedAmount = 0;
				//Dim mGridClearedAmount As Double
				//Dim mysql As String
				try
				{

					if (!CheckAmountValidity(ColIndex, OldValue, ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[mClearedAmountColumn].Value), ref mAdjustedAmount))
					{
						Cancel = -1;
						return;
					}
					else
					{
						if (mAdjustedAmount > 0)
						{
							txtAmountAdjusted.Value = ReflectionHelper.GetPrimitiveValue<double>(txtAmountAdjusted.Value) + ((double) mAdjustedAmount);
						}
						else
						{
							txtAmountAdjusted.Value = ReflectionHelper.GetPrimitiveValue<double>(txtAmountAdjusted.Value) - Math.Abs((double) mAdjustedAmount);
						}
					}

					return;
				}
				catch (System.Exception excep)
				{
					MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					Cancel = -1;
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == mVoucherAmountColumn || ColIndex == mDueAmountColumn || ColIndex == mClearedAmountColumn)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###,###,##0.000");
				}
				else
				{
					Value = "0.000";
				}
			}
			else if (ColIndex == mVoucherDateColumn || ColIndex == mDueDateColumn)
			{ 
				Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), SystemVariables.gInputDateFormat);
			}
		}

		private void GetVoucher()
		{
			try
			{
				string mDetailType = "";
				DataSet recDetail = new DataSet();
				string mysql = "";

				//If Left(mLedgerCode, 4) = Left(gGLCustomerVendorTypeCode, 4) Then
				//    mDetailType = "D"
				//ElseIf Left(mLedgerCode, 4) = Left(gGLCustomerVendorTypeCode, 4) Then
				//    mDetailType = "C"
				//Else
				//    MsgBox "Error:"
				//    Exit Sub
				//End If

				//If mDrCrType = "Dr" Then
				//    mDetailType = "C"
				//Else
				//    mDetailType = "D"
				//End If

				if (mDrCrType == "D")
				{
					mDetailType = "C";
				}
				else
				{
					mDetailType = "D";
				}

				//mySql = " SELECT ATD.Line_No as [LN], AVT.L_Short_Name AS [Voucher Type]"
				//mySql = mySql & " , at.voucher_no as [Voucher No]"
				//mySql = mySql & " , at.reference_no as [Reference No]"
				//mySql = mySql & " , ATD.Reference_No AS [Remarks], "
				//mySql = mySql & " AT.Voucher_Date AS [Date], ATD.Due_Date AS [Due Date],"
				//mySql = mySql & " ATD.FC_Voucher_Amt AS [Amount],"
				//mySql = mySql & " ATD.FC_Due_Amt + isnull(InvTracking.Adjusted_Amt,0) AS [Amt. Due],"
				//mySql = mySql & " isnull(InvTracking.Adjusted_Amt,0) AS [Amt. Cleared],"
				//mySql = mySql & " InvTracking.comments as [Comments], "
				//mySql = mySql & " ATD.Time_Stamp as [Time_Stamp] "
				//mySql = mySql & " FROM gl_accnt_trans  as AT"
				//mySql = mySql & " INNER JOIN gl_accnt_voucher_types as AVT ON AT.Voucher_Type = AVT.Voucher_Type"
				//mySql = mySql & " right outer join gl_accnt_trans_Details as ATD ON AT.Entry_Id = ATD.Entry_Id"
				//mySql = mySql & " left outer JOIN"
				//mySql = mySql & " (select Adjusted_Amt,Against_Line_No,comments from  ICS_Transaction_Tracking"
				//mySql = mySql & " where "
				//mySql = mySql & " Source_Line_No= 0 )"
				//mySql = mySql & " as InvTracking"
				//mySql = mySql & " ON ATD.Line_No = InvTracking.Against_Line_No"
				//mySql = mySql & " where ATD.Dr_Cr_Type='" & mDetailType & "'"
				//mySql = mySql & " and ATD.ldgr_cd='" & mLedgerCode & "'"
				//mySql = mySql & " and (ATD.fc_voucher_amt <> ATD.fc_paid_amt )"
				//mySql = mySql & " order by AT.Voucher_Date "

				mysql = " SELECT ATD.Line_No as [LN], AVT.L_Short_Name AS [Voucher Type]";
				mysql = mysql + " , at.voucher_no as [Voucher No]";
				mysql = mysql + " , at.reference_no as [Reference No]";
				mysql = mysql + " , ATD.comments AS [Remarks], ";
				//mySql = mySql & " , ATD.Reference_No AS [Remarks], "
				mysql = mysql + " AT.Voucher_Date AS [Date], ATD.Due_Date AS [Due Date],";
				mysql = mysql + " abs(ATD.FC_amount) AS [Amount],";
				mysql = mysql + " ATD.FC_Due_Amt + isnull(InvTracking.Adjusted_Amt,0) AS [Amt. Due],";
				mysql = mysql + " isnull(InvTracking.Adjusted_Amt,0) AS [Amt. Cleared],";
				mysql = mysql + " InvTracking.comments as [Comments], ";
				mysql = mysql + " ATD.Time_Stamp as [Time_Stamp] ";
				mysql = mysql + " FROM gl_accnt_trans  as AT";
				mysql = mysql + " INNER JOIN gl_accnt_voucher_types as AVT ON AT.Voucher_Type = AVT.Voucher_Type";
				mysql = mysql + " right outer join gl_accnt_trans_Details as ATD ON AT.Entry_Id = ATD.Entry_Id";
				mysql = mysql + " left outer JOIN";
				mysql = mysql + " (select Adjusted_Amt,Against_Line_No,comments from  gl_invoice_tracking ";
				mysql = mysql + " where ";
				mysql = mysql + " Source_Line_No= 0 )";
				mysql = mysql + " as InvTracking";
				mysql = mysql + " ON ATD.Line_No = InvTracking.Against_Line_No";
				mysql = mysql + " where ATD.Dr_Cr_Type='" + mDetailType + "'";
				mysql = mysql + " and ATD.ldgr_cd=" + mLedgerCode.ToString();
				mysql = mysql + " and (abs(ATD.fc_amount) <> ATD.fc_paid_amt )";
				mysql = mysql + " order by AT.Voucher_Date ";

				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				recDetail.Tables.Clear();
				adap.Fill(recDetail);
				if (recDetail.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aCurrentAdjustedVoucherDetails.LoadRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					aCurrentAdjustedVoucherDetails.LoadRows((object[, ]) recDetail.GetRows(-1, null, null), true);
				}
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aCurrentAdjustedVoucherDetails);
				grdVoucherDetails.Rebind(true);
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			grdVoucherDetails.Col = mClearedAmountColumn;
		}

		private void grdVoucherDetails_Leave(Object eventSender, EventArgs eventArgs)
		{
			grdVoucherDetails.UpdateData();
		}

		private void txtAmountAdjusted_Change(Object Sender, EventArgs e)
		{
			txtToBeAdjusted.Value = ReflectionHelper.GetPrimitiveValue<double>(txtAmountToAdjust.Value) - ReflectionHelper.GetPrimitiveValue<double>(txtAmountAdjusted.Value);
		}

		private void txtAmountToAdjust_Change(Object Sender, EventArgs e)
		{
			txtToBeAdjusted.Value = ReflectionHelper.GetPrimitiveValue<double>(txtAmountToAdjust.Value) - ReflectionHelper.GetPrimitiveValue<double>(txtAmountAdjusted.Value);
		}


		private bool CheckAmountValidity(int pColIndex, object pOldValue, string pClearedAmount, ref decimal pAdjustedAmount)
		{
			bool result = false;
			decimal mGridClearedAmount = 0;
			decimal mOldValue = 0;

			try
			{

				mGridClearedAmount = (decimal) Conversion.Val(StringsHelper.Format(pClearedAmount, "###########0.000"));
				mOldValue = (decimal) Conversion.Val(StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(pOldValue), "###########0.000"));

				if (pColIndex == mClearedAmountColumn)
				{
					if (mOldValue != mGridClearedAmount)
					{
						if (mGridClearedAmount > Decimal.Parse(grdVoucherDetails.Columns[mDueAmountColumn].Text, NumberStyles.Currency | NumberStyles.AllowExponent))
						{
							MessageBox.Show("Cleared amount cannot be greater than Due amount", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							grdVoucherDetails.Focus();
							return false;
						}

						if (mOldValue > 0)
						{
							pAdjustedAmount = mGridClearedAmount - mOldValue;
						}
						else
						{
							pAdjustedAmount = mGridClearedAmount;
						}

						if (pAdjustedAmount > ReflectionHelper.GetPrimitiveValue<decimal>(txtToBeAdjusted.Value))
						{
							MessageBox.Show("Cleared amount cannot be greater than To Be Adjusted Amount", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							grdVoucherDetails.Focus();
							return false;
						}

					}
				}


				return true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
			}
			return result;
		}
	}
}