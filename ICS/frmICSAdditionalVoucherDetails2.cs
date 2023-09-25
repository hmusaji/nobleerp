
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmICSAdditionalVoucherDetails2
		: System.Windows.Forms.Form
	{

		//''Notes: 08-mar-2006
		//''This form will only be called during inventory transaction when
		//''preference final_payment screen is enabled on company and voucher level
		//''The inventory transaction should be cash.
		//''The cash_cd and credit_card_cd are saved in icsadditionalvouchedetails table
		//''the cash_cd on icsadditionalvouchedetails will be taken from its parent voucher eg. sales
		//''

		private SystemICSConstants.ShowOptions mPostOptionType = (SystemICSConstants.ShowOptions) 0;

		private const int mNormalHeight = 3735;
		private const int mAdvancedHeight = 4695;

		private const string mAdvancedCaption = "&Advanced Mode >>";
		private const string mNormalCaption = "<< &Normal Mode";

		private const int lcCashAmt = 7;
		private const int lcCreditCardAmt = 9;
		private const int lcTotalAmt = 3;

		private const int conTxtCashGLAC = 2;
		private const int conTxtCreditCardGLAC = 3;
		private const int conTxtCreditVoucherAC = 1;
		private const int conTxtCreditVoucherNo = 0;

		private const int conNTxtChangeAmt = 0;
		private const int conNTxtCashAmt = 1;
		private const int conNTxtCreditCardAmt = 2;
		private const int conNTxtVoucherAmt = 3;
		private const int conNTxtTotalAmt = 4;
		private const int conNTxtAmtReceived = 5;
		private const int conNTxtCreditVoucherAmt = 6;

		private const int conOptCredit = 0;
		private const int conOptCash = 1;

		private decimal mNetVoucherAmt = 0;
		private int mEntryId = 0;
		private int mButtonPressed = 0;
		private const int ctlAdvancedModeDetailsIndex = 6;
		public frmICSAdditionalVoucherDetails2()
{
InitializeComponent();
} 
 public  void frmICSAdditionalVoucherDetails2_old()
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



		public int CreditVoucherAmtIndex
		{
			get
			{
				return conNTxtCreditVoucherAmt;
			}
		}


		public int CreditCardAmtIndex
		{
			get
			{
				return conNTxtCreditCardAmt;
			}
		}


		public int CashAmtIndex
		{
			get
			{
				return conNTxtCashAmt;
			}
		}


		public int ChangeAmtIndex
		{
			get
			{
				return conNTxtChangeAmt;
			}
		}


		public int CreditCardGLAcIndex
		{
			get
			{
				return conTxtCreditCardGLAC;
			}
		}


		public int CreditVoucherAcIndex
		{
			get
			{
				return conTxtCreditVoucherAC;
			}
		}


		public int CreditVoucherNoIndex
		{
			get
			{
				return conTxtCreditVoucherNo;
			}
		}


		public int CashGLAcIndex
		{
			get
			{
				return conTxtCashGLAC;
			}
		}


		public int CashOptIndex
		{
			get
			{
				return conOptCash;
			}
		}


		public int CreditOptIndex
		{
			get
			{
				return conOptCredit;
			}
		}



		public void SetSetValues(int pEntryId, decimal value)
		{

			mEntryId = pEntryId;
			mNetVoucherAmt = value;

			txtNCommon[conNTxtTotalAmt].Value = value;
			txtNCommon[conNTxtVoucherAmt].Value = value;

		}


		public int ButtonPressed
		{
			get
			{
				//''1 = OK .. 2= Cancel

				return mButtonPressed;
			}
			set
			{
				//''1 = OK .. 2= Cancel

				mButtonPressed = value;
			}
		}


		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//Me.Left = (frmSysMain.Width - Me.Width) / 2
					//Me.Top = (frmSysMain.Height - Me.Height) / 2
					txtNCommon[conNTxtAmtReceived].Focus();
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 13 && this.ActiveControl.Name != "UCOkCancel1")
				{ //if enter key pressed send a tab key
					SendKeys.Send("{tab}");
					return;
				}

				if (this.ActiveControl.Name != "txtCommon")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift);
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

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			string mySql = "";
			object mReturnValue = null;

			SystemProcedure.SetLabelCaption(this);


			clsFlip oFlipThisForm = null;
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
			{
				oFlipThisForm = new clsFlip();

				oFlipThisForm.SwapMe(this);
			}

			mPostOptionType = SystemICSConstants.ShowOptions.optNormalMode;

			if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_ics_voucher_multiple_payment_mode")))
			{
				fraCashInfo.Visible = false;
				picPostMode.Visible = false;
			}
			else
			{
				fraCashInfo.Visible = true;
				picPostMode.Visible = true;
			}

			if (mEntryId > 0)
			{
				//    mySql = " select l1.ldgr_no , l1.ldgr_cd , l2.ldgr_no, l2.ldgr_cd, mt.is_cash "
				//    mySql = mySql & " , iavd.cash_amt, iavd.credit_card_amt "
				//    mySql = mySql & " from ICS_Transaction mt "
				//    mySql = mySql & " inner join ics_additional_voucher_details iavd on mt.entry_id = iavd.entry_id "
				//    mySql = mySql & " left join gl_ledger l1 on iavd.cash_ldgr_cd = l1.ldgr_cd "
				//    mySql = mySql & " left join gl_ledger l2 on iavd.credit_card_ldgr_cd = l2.ldgr_cd "
				//    mySql = mySql & " where mt.entry_id =" & mEntryID

				mySql = " select l1.ldgr_no , l1.ldgr_cd , l2.ldgr_no, l2.ldgr_cd, mt.is_cash ";
				mySql = mySql + " , mt.cash_amt_fc, mt.credit_card_amt_fc, mt.change_Amt_FC, mt.Amount_Received ";
				mySql = mySql + " , mt.Credit_voucher_no, mt.Credit_voucher_Amt_FC, l3.ldgr_no, l3.ldgr_cd ";
				mySql = mySql + " from ICS_Transaction mt ";
				mySql = mySql + " left join gl_ledger l1 on mt.cash_cd = l1.ldgr_cd ";
				mySql = mySql + " left join gl_ledger l2 on mt.credit_card_ldgr_cd = l2.ldgr_cd ";
				mySql = mySql + " left join gl_ledger l3 on mt.Credit_Voucher_Ldgr_Cd = l3.ldgr_cd ";
				mySql = mySql + " where mt.entry_id =" + mEntryId.ToString();

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					txtCommon[conTxtCashGLAC].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)) + "";
					txtCommon[conTxtCashGLAC].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1)) + "";
					txtCommon[conTxtCreditCardGLAC].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2)) + "";
					txtCommon[conTxtCreditCardGLAC].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3)) + "";
					txtCommon[conTxtCreditVoucherNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(9)) + "";
					txtCommon[conTxtCreditVoucherAC].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(11)) + "";
					txtCommon[conTxtCreditVoucherAC].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(12)) + "";

					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNCommon[conNTxtChangeAmt].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(7));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNCommon[conNTxtAmtReceived].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(8));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNCommon[conNTxtCashAmt].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(5));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNCommon[conNTxtCreditCardAmt].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(6));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNCommon[conNTxtCreditVoucherAmt].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(10));
				}
			}
			else
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!SystemVariables.rsVoucherTypes.Tables[0].Rows[0].IsNull("Default_credit_card_cd"))
				{
					mySql = " select ldgr_no from gl_ledger ";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mySql = mySql + " where ldgr_cd = " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Default_credit_card_cd"]);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommon[conTxtCreditCardGLAC].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommon[conTxtCreditCardGLAC].Tag = Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Default_credit_card_cd"]);
					}
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!SystemVariables.rsVoucherTypes.Tables[0].Rows[0].IsNull("default_credit_voucher_cd"))
				{
					mySql = " select ldgr_no from gl_ledger ";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mySql = mySql + " where ldgr_cd = " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["default_credit_voucher_cd"]);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommon[conTxtCreditVoucherAC].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommon[conTxtCreditVoucherAC].Tag = Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["default_credit_voucher_cd"]);
					}
				}
			}


		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			try
			{

				//Call RemoveMeFromWindowList(Str(Me.hWnd))
				frmICSAdditionalVoucherDetails2.DefInstance = null;
			}
			catch
			{
			}
		}

		private void cmdPostMode_AccessKeyPress(Object eventSender, AxSmartNetButtonProject.__SmartNetButton_AccessKeyPressEvent eventArgs)
		{
			cmdPostMode_ClickEvent(cmdPostMode, new EventArgs());
		}

		private void cmdPostMode_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			if (mPostOptionType == SystemICSConstants.ShowOptions.optNormalMode)
			{
				mPostOptionType = SystemICSConstants.ShowOptions.optAdvancedMode;
			}
			else
			{
				mPostOptionType = SystemICSConstants.ShowOptions.optNormalMode;
			}
			ShowHideAdvancedOptions(mPostOptionType);

		}

		private void ShowHideAdvancedOptions(SystemICSConstants.ShowOptions ChangeToMode)
		{
			bool mShowSetting = false;

			if (ChangeToMode == SystemICSConstants.ShowOptions.optAdvancedMode)
			{
				mShowSetting = true;
				cmdPostMode.Caption = mNormalCaption;
				this.Height = mAdvancedHeight / 15;
			}
			else
			{
				mShowSetting = false;
				cmdPostMode.Caption = mAdvancedCaption;
				this.Height = mNormalHeight / 15;
			}
			fraOptions.Visible = mShowSetting;
			Line1.Visible = mShowSetting;
			lblCommonLabel[ctlAdvancedModeDetailsIndex].Visible = mShowSetting;
			mPostOptionType = ChangeToMode;

		}

		//Private Sub optTransType_Click(Index As Integer)
		//
		//If Index = conOptCash Then
		//    picPostMode.Visible = True
		//
		//    fraCashInfo.Visible = True
		//ElseIf Index = conOptCredit Then
		//    picPostMode.Visible = False
		//
		//    txtNCommon(conNTxtCreditCardAmt).Value = 0
		//    txtNCommon(conNTxtCashAmt).Value = 0
		//
		//    With Me
		//        .txtCommon(.CashGLAcIndex).Text = ""
		//        .txtCommon(.CashGLAcIndex).Tag = ""
		//
		//        .txtCommon(.CreditCardGLAcIndex).Text = ""
		//        .txtCommon(.CreditCardGLAcIndex).Tag = ""
		//    End With
		//
		//    If mPostOptionType = optAdvancedMode Then
		//        cmdPostMode_Click
		//    End If
		//
		//    fraCashInfo.Visible = False
		//End If
		//
		//End Sub

		private void txtCommon_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);
			FindRoutine("txtCommon#" + Index.ToString().Trim());
		}

		private void txtNCommon_Change(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtNCommon, Sender);

			//'''enabled by Moiz Hakimion 04-may-2009
			//If rsVoucherTypes("enable_partial_receipt") = vbFalse Then
			//    If (Index = conNTxtCashAmt Or Index = conNTxtCreditCardAmt) Then
			//        If Index = conNTxtCashAmt Then
			//            txtNCommon(conNTxtCreditCardAmt).Value = mNetVoucherAmt - txtNCommon(conNTxtCashAmt).Value
			//        End If
			//
			//        If Index = conNTxtCreditCardAmt Then
			//            txtNCommon(conNTxtCashAmt).Value = mNetVoucherAmt - txtNCommon(conNTxtCreditCardAmt).Value
			//        End If
			//
			//        txtNCommon(conNTxtTotalAmt).Value = txtNCommon(conNTxtCashAmt).Value + txtNCommon(conNTxtCreditCardAmt).Value
			//    End If
			//End If

			if (ReflectionHelper.IsLessThanOrEqual(txtNCommon[conNTxtAmtReceived].Value, txtNCommon[conNTxtVoucherAmt].Value))
			{
				//UPGRADE_WARNING: (1068) txtNCommon().Value of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtNCommon[conNTxtTotalAmt].Value = ReflectionHelper.GetPrimitiveValue(txtNCommon[conNTxtAmtReceived].Value); //+ txtNCommon(conNTxtCreditCardAmt).Value
			}
			else
			{
				//UPGRADE_WARNING: (1068) txtNCommon().Value of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtNCommon[conNTxtTotalAmt].Value = ReflectionHelper.GetPrimitiveValue(txtNCommon[conNTxtVoucherAmt].Value);
			}

			//UPGRADE_WARNING: (1068) txtNCommon().Value of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			txtNCommon[conNTxtCreditCardAmt].MaxValue = ReflectionHelper.GetPrimitiveValue(txtNCommon[conNTxtAmtReceived].Value);
			//UPGRADE_WARNING: (1068) txtNCommon().Value of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			txtNCommon[conNTxtCreditVoucherAmt].MaxValue = ReflectionHelper.GetPrimitiveValue(txtNCommon[conNTxtAmtReceived].Value);
			//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
			txtNCommon[conNTxtCashAmt].Value = ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[conNTxtTotalAmt].Value) - (Convert.ToDouble(ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[conNTxtCreditCardAmt].Value) + ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[conNTxtCreditVoucherAmt].Value)));
			//txtNCommon(conNTxtCreditCardAmt).Value = txtNCommon(conNTxtTotalAmt).Value - txtNCommon(conNTxtCashAmt).Value


			if (Index == conNTxtAmtReceived)
			{
				if (ReflectionHelper.GetPrimitiveValue<decimal>(txtNCommon[conNTxtAmtReceived].Value) >= mNetVoucherAmt)
				{
					txtNCommon[conNTxtChangeAmt].Value = (ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[conNTxtAmtReceived].Value) - ((double) mNetVoucherAmt));
					txtNCommon[conNTxtChangeAmt].ForeColor = Color.Blue;

					lblChange.Text = "Change";
					lblChange.ForeColor = Color.Blue;


					txtNCommon[conNTxtCashAmt].Value = mNetVoucherAmt;
				}
				else
				{
					txtNCommon[conNTxtChangeAmt].Value = (((double) mNetVoucherAmt) - ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[conNTxtAmtReceived].Value));
					txtNCommon[conNTxtChangeAmt].ForeColor = Color.Red;

					lblChange.Text = "Balance";
					lblChange.ForeColor = Color.Red;

					//txtNCommon(conNTxtCashAmt).Value = txtNCommon(conNTxtChangeAmt).Value
					//UPGRADE_WARNING: (1068) txtNCommon().Value of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNCommon[conNTxtCashAmt].Value = ReflectionHelper.GetPrimitiveValue(txtNCommon[conNTxtAmtReceived].Value);
				}
			}
		}

		private void txtNCommon_Validating(Object eventSender, CancelEventArgs eventArgs)
		{

			//If (Index = conNTxtCashAmt Or Index = conNTxtCreditCardAmt) Then
			//    If Index = conNTxtCashAmt Then
			//        txtNCommon(conNTxtCreditCardAmt).Value = mNetVoucherAmt - txtNCommon(conNTxtCashAmt).Value
			//    End If
			//
			//    If Index = conNTxtCreditCardAmt Then
			//        txtNCommon(conNTxtCashAmt).Value = mNetVoucherAmt - txtNCommon(conNTxtCreditCardAmt).Value
			//    End If
			//
			//    txtNCommon(conNTxtTotalAmt).Value = txtNCommon(conNTxtCashAmt).Value + txtNCommon(conNTxtCreditCardAmt).Value
			//End If

		}

		private void UCOkCancel1_CancelClick(Object Sender, EventArgs e)
		{

			txtCommon[conTxtCashGLAC].Tag = "";
			txtCommon[conTxtCreditCardGLAC].Tag = "";

			mButtonPressed = 2;
			CloseForm();
		}

		//Private Sub chkCommonPost_Click(Index As Integer)
		//Static mLoopStatus As Boolean
		//Dim mEnableSetting As Boolean
		//Dim mCheckedSetting As CheckBoxConstants
		//
		//If mLoopStatus = False Then
		//    mLoopStatus = True
		//    If Index = ccPostToGLSIndex Then
		//        mCheckedSetting = chkCommonPost(Index).Value
		//
		//        chkCommonPost(ccPostGLPartyIndex).Value = mCheckedSetting
		//        chkCommonPost(ccPostGLExpenseIndex).Value = mCheckedSetting
		//        chkCommonPost(ccPostGLInventoryIndex).Value = mCheckedSetting
		//    End If
		//
		//    If chkCommonPost(ccPostGLInventoryIndex).Value = vbChecked Then
		//        mEnableSetting = False
		//        mCheckedSetting = vbChecked
		//
		//        chkCommonPost(ccPostStatusIndex).Enabled = mEnableSetting
		//        chkCommonPost(ccPostToICSIndex).Enabled = mEnableSetting
		//        chkCommonPost(ccPostToGLSIndex).Enabled = mEnableSetting
		//        chkCommonPost(ccPostGLPartyIndex).Enabled = mEnableSetting
		//        chkCommonPost(ccPostGLExpenseIndex).Enabled = mEnableSetting
		//
		//        chkCommonPost(ccPostStatusIndex).Value = mCheckedSetting
		//        chkCommonPost(ccPostToICSIndex).Value = mCheckedSetting
		//        chkCommonPost(ccPostToGLSIndex).Value = mCheckedSetting
		//        chkCommonPost(ccPostGLPartyIndex).Value = mCheckedSetting
		//        chkCommonPost(ccPostGLExpenseIndex).Value = mCheckedSetting
		//    Else
		//        mEnableSetting = True
		//
		//        chkCommonPost(ccPostStatusIndex).Enabled = mEnableSetting
		//        chkCommonPost(ccPostToICSIndex).Enabled = mEnableSetting
		//        chkCommonPost(ccPostToGLSIndex).Enabled = mEnableSetting
		//        chkCommonPost(ccPostGLPartyIndex).Enabled = mEnableSetting
		//        chkCommonPost(ccPostGLExpenseIndex).Enabled = mEnableSetting
		//    End If
		//
		//    If chkCommonPost(ccPostGLExpenseIndex).Value = vbChecked Then
		//        mEnableSetting = False
		//        mCheckedSetting = vbChecked
		//
		//        chkCommonPost(ccPostStatusIndex).Enabled = mEnableSetting
		//        chkCommonPost(ccPostToICSIndex).Enabled = mEnableSetting
		//        chkCommonPost(ccPostToGLSIndex).Enabled = mEnableSetting
		//        chkCommonPost(ccPostGLPartyIndex).Enabled = mEnableSetting
		//
		//        chkCommonPost(ccPostStatusIndex).Value = mCheckedSetting
		//        chkCommonPost(ccPostToICSIndex).Value = mCheckedSetting
		//        chkCommonPost(ccPostToGLSIndex).Value = mCheckedSetting
		//        chkCommonPost(ccPostGLPartyIndex).Value = mCheckedSetting
		//    Else
		//        mEnableSetting = True
		//
		//        chkCommonPost(ccPostStatusIndex).Enabled = mEnableSetting
		//        chkCommonPost(ccPostToICSIndex).Enabled = mEnableSetting
		//        chkCommonPost(ccPostToGLSIndex).Enabled = mEnableSetting
		//        chkCommonPost(ccPostGLPartyIndex).Enabled = mEnableSetting
		//    End If
		//
		//    If chkCommonPost(ccPostGLPartyIndex).Value = vbChecked Then
		//        mEnableSetting = False
		//        mCheckedSetting = vbChecked
		//
		//        chkCommonPost(ccPostToGLSIndex).Enabled = mEnableSetting
		//
		//        chkCommonPost(ccPostToGLSIndex).Value = mCheckedSetting
		//    Else
		//        mEnableSetting = True
		//        mCheckedSetting = vbUnchecked
		//
		//        chkCommonPost(ccPostToGLSIndex).Enabled = mEnableSetting
		//        chkCommonPost(ccPostToGLSIndex).Value = mCheckedSetting
		//    End If
		//
		//    mLoopStatus = False
		//End If
		//End Sub
		//
		private void UCOkCancel1_OKClick(Object Sender, EventArgs e)
		{
			string mySql = "";
			object mReturnValue = null;


			//''comented by Moiz Hakimion 08-sep-2007
			//''partial amount can be received against the invoice amount
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["enable_partial_receipt"])) == TriState.True)
			{
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				if (mNetVoucherAmt < (Convert.ToDecimal(Convert.ToDouble(ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[conNTxtCashAmt].Value) + ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[conNTxtCreditCardAmt].Value)) + ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[conNTxtCreditVoucherAmt].Value))))
				{
					MessageBox.Show(" Total amount cannot be greated than voucher Amount , Cannot Proceed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
			else
			{
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				if (mNetVoucherAmt != (Convert.ToDecimal(Convert.ToDouble(ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[conNTxtCashAmt].Value) + ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[conNTxtCreditCardAmt].Value)) + ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[conNTxtCreditVoucherAmt].Value))))
				{
					MessageBox.Show(" Total amount should be equal to voucher Amount , Cannot Proceed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_ics_voucher_multiple_payment_mode")))
			{
				if (!SystemProcedure2.IsItEmpty(txtCommon[conTxtCashGLAC].Text, SystemVariables.DataType.StringType))
				{
					mySql = " select ldgr_cd from gl_ledger ";
					mySql = mySql + " where ldgr_no ='" + txtCommon[conTxtCashGLAC].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						txtCommon[conTxtCashGLAC].Tag = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Invalid Cash A/c code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommon[conTxtCashGLAC].Tag = "";

						if (mPostOptionType == SystemICSConstants.ShowOptions.optNormalMode)
						{
							mPostOptionType = SystemICSConstants.ShowOptions.optAdvancedMode;
							ShowHideAdvancedOptions(mPostOptionType);
						}


						//txtCommon(conTxtCashGLAC).SetFocus

						return;
					}
				}
				else
				{
					txtCommon[conTxtCashGLAC].Tag = "";
				}

				if (!SystemProcedure2.IsItEmpty(txtCommon[conTxtCreditCardGLAC].Text, SystemVariables.DataType.StringType))
				{
					mySql = " select ldgr_cd from gl_ledger ";
					mySql = mySql + " where ldgr_no ='" + txtCommon[conTxtCreditCardGLAC].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						txtCommon[conTxtCreditCardGLAC].Tag = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Invalid Credit Card A/c code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommon[conTxtCreditCardGLAC].Tag = "";

						if (mPostOptionType == SystemICSConstants.ShowOptions.optNormalMode)
						{
							mPostOptionType = SystemICSConstants.ShowOptions.optAdvancedMode;
							ShowHideAdvancedOptions(mPostOptionType);
						}

						txtCommon[conTxtCreditCardGLAC].Focus();
						return;
					}
				}
				else
				{
					txtCommon[conTxtCreditCardGLAC].Tag = "";
				}

				if (!SystemProcedure2.IsItEmpty(txtCommon[conTxtCreditVoucherAC].Text, SystemVariables.DataType.StringType))
				{
					mySql = " select ldgr_cd from gl_ledger ";
					mySql = mySql + " where ldgr_no ='" + txtCommon[conTxtCreditVoucherAC].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						txtCommon[conTxtCreditVoucherAC].Tag = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Invalid Credit Voucher A/c code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommon[conTxtCreditVoucherAC].Tag = "";

						if (mPostOptionType == SystemICSConstants.ShowOptions.optNormalMode)
						{
							mPostOptionType = SystemICSConstants.ShowOptions.optAdvancedMode;
							ShowHideAdvancedOptions(mPostOptionType);
						}

						txtCommon[conTxtCreditVoucherAC].Focus();
						return;
					}
				}
				else
				{
					txtCommon[conTxtCreditVoucherAC].Tag = "";
				}
			}

			ButtonPressed = 1;

			CloseForm();

		}

		public void FindRoutine(string pObjectName)
		{
			string mySql = "";
			object mTempSearchValue = null;

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

			switch(mIndex)
			{
				case conTxtCashGLAC : 
					txtCommon[conTxtCashGLAC].Text = ""; 
					 
					//mysql = " ( ldgr_type = 'B-CH' or ldgr_type = 'B-BA' or ldgr_type = 'F-BO') and gl_ledger.discontinued = 0 " 
					mySql = " ( l.type_cd = " + SystemGLConstants.gGLBankTypeCode.ToString() + " or l.type_cd=" + SystemGLConstants.gGLCashTypeCode.ToString() + ") and l.discontinued = 0 "; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mySql)); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommon[conTxtCashGLAC].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						//Call txtCommon_LostFocus(mIndex)
					} 
					break;
				case conTxtCreditCardGLAC : 
					txtCommon[conTxtCreditCardGLAC].Text = ""; 
					//mysql = " ( ldgr_type = 'B-CH' or ldgr_type = 'B-BA' or ldgr_type = 'F-BO') and gl_ledger.discontinued = 0 " 
					mySql = " ( l.type_cd = " + SystemGLConstants.gGLBankTypeCode.ToString() + " or l.type_cd=" + SystemGLConstants.gGLCashTypeCode.ToString() + ") and l.discontinued = 0 "; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mySql)); 
					 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommon[conTxtCreditCardGLAC].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						//Call txtCommon_LostFocus(mIndex)
					} 
					break;
				case conTxtCreditVoucherAC : 
					txtCommon[conTxtCreditVoucherAC].Text = ""; 
					//mysql = " ( l.type_cd = " & gGLBankTypeCode & " or l.type_cd=" & gGLCashTypeCode & ") and gl_ledger.discontinued = 0 " 
					mySql = " l.discontinued = 0 "; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mySql)); 
					 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommon[conTxtCreditVoucherAC].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						//Call txtCommon_LostFocus(mIndex)
					} 
					break;
				default:
					return;
			}
		}

		private void txtCommon_Leave(Object eventSender, EventArgs eventArgs)
		{
			//On Error GoTo eFoundError
			//Dim mTempValue As Variant
			//Dim mySql As String
			//Dim cnt As Integer
			//Dim mSetValueIndex As Integer
			//
			//If gSkipTextBoxLostFocus = True Then
			//    Exit Sub
			//End If
			//
			//With Me
			//    Select Case Index
			//        Case conTxtCashGLAC
			//            mySql = "select " & IIf(gPreferedLanguage = English, "l_locat_name", "a_locat_name")
			//            mySql = mySql & ",'' from SM_Location where locat_no = " & .txtCommon(Index).Text
			//
			//            mSetValueIndex = conDlblLocationName
			//        Case conTxtCashGLAC
			//            mySql = "select " & IIf(gPreferedLanguage = English, "l_batch_name", "a_batch_name")
			//            mySql = mySql & ",'' from ics_trans_batch where batch_no = " & .txtCommon(Index).Text
			//
			//            mSetValueIndex = conDlblBatchName
			//      Case Else
			//            mSetValueIndex = 0
			//    End Select
			//
			//
			//    If mSetValueIndex > 0 Then
			//        If Not IsItEmpty(.txtCommon(Index).Text, StringType) Then
			//            mTempValue = GetMasterCode(mySql)
			//            If IsNull(mTempValue) Then
			//                .txtDisplayLabel(mSetValueIndex).Text = ""
			//
			//                Err.Raise -9990002
			//            Else
			//                .txtDisplayLabel(mSetValueIndex).Text = mTempValue(0)
			//
			//                If mSetValueIndex = conTxtCashGLAC Then
			//                    'txtCommon(conTxtCashGLAC).Enabled = False
			//                End If
			//            End If
			//        Else
			//            .txtDisplayLabel(mSetValueIndex).Text = ""
			//        End If
			//    End If
			//End With
			//
			//
			//Exit Sub
			//
			//eFoundError:
			//Dim mReturnErrorType As Integer
			//mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord", msg10)
			//If mReturnErrorType = 1 Then
			//'
			//ElseIf mReturnErrorType = 2 Then
			//'
			//ElseIf mReturnErrorType = 3 Then
			//'
			//ElseIf mReturnErrorType = 4 Then
			//    txtCommon(Index).SetFocus
			//Else
			//    '
			//End If
		}

		public void CloseForm()
		{
			this.Hide();
		}
	}
}