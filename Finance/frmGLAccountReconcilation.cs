
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmGLAccountReconcilation
		: System.Windows.Forms.Form
	{


		
		public frmGLAccountReconcilation()
{
InitializeComponent();
} 
 public  void frmGLAccountReconcilation_old()
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

		private int mLastCol = 0;
		private int mLastRow = 0;
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

		private Control FirstFocusObject = null;
		private int mThisFormID = 0;

		const int mLineNoColumn = 0;
		const int mTimeStamp = 1;
		const int mVoucherDateColumn = 2;
		const int mVoucherNo = 3;
		const int mVoucherTypeColumn = 4;
		const int mLdgrNo = 5;
		const int mParticulars = 6;
		const int mDrAmountColumn = 7;
		const int mCrAmountColumn = 8;
		const int mReconciledColumn = 9;
		const int mRemarksColumn = 10;

		const int mMaxColumn = 10;

		const int conDebitUnReconcileAmt = 1;
		const int conDebitReconcileAmt = 2;
		const int conDebitTotalAmt = 3;

		const int conCreditUnReconcileAmt = 4;
		const int conCreditReconcileAmt = 5;
		const int conCreditTotalAmt = 6;

		const int conUnReconcileBalanceAmt = 7;
		const int conReconcileBalanceAmt = 8;
		const int conReconcileBalance = 9;

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


		private void cmdClose_Click()
		{

			this.Close();
		}

		private void chkShowReconciled_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			//If chkShowReconciled.Value = 1 Then
			GetVoucherDetail();
			//End If
		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				SystemMenu.SetMeCurrentInWindowList(Conversion.Str(this.Handle.ToInt32()));
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
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			//Set the Grid Format

			this.Top = 0;
			this.Left = 0;
			FirstFocusObject = txtVoucherDate;

			//**--format & define the new toolbar
			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			oThisFormToolBar.ShowSaveButton = true;
			oThisFormToolBar.ShowPrintButton = true;
			oThisFormToolBar.ShowCheckAllButton = true;
			oThisFormToolBar.ShowUncheckAllButton = true;
			oThisFormToolBar.ShowHelpButton = true;
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.DisableHelpButton = true;

			this.WindowState = FormWindowState.Maximized;


			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.4f, 1.4f, "&HB9E6E2", "&HB9E6E2");
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Line_No", 400, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Time_stamp", 100, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Voucher Date", 1150, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Voucher No.", 1000, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Type", 460, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger No.", 950, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Particulars", 3250, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Debit Amount", 1250, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Credit Amount", 1250, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Reconciled", 900, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 900, false, SystemConstants.gDisableColumnBackColor);

			grdVoucherDetails.HoldFields();
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);
			txtVoucherDate.Value = DateTime.Today;

			SystemProcedure.SetLabelCaption(this);
			clsFlip oFlipThisForm = null;
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
			{
				oFlipThisForm = new clsFlip();

				oFlipThisForm.SwapMe(this);
			}

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				frmGLAccountReconcilation.DefInstance = null;
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

			if (ColIndex == mDrAmountColumn || ColIndex == mCrAmountColumn)
			{
				CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);
				grdVoucherDetails.Refresh();
			}

		}

		private void grdVoucherDetails_BeforeColEdit(object eventSender, C1.Win.C1TrueDBGrid.BeforeColEditEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int KeyAscii = (int) eventArgs.KeyChar;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				if (ColIndex == mReconciledColumn && Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex)) != "")
				{
					if (KeyAscii == 0 || KeyAscii == 13 || KeyAscii == 32)
					{
						aVoucherDetails.SetValue(~Convert.ToInt32(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex)), ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);
						grdVoucherDetails.UpdateData();
						grdVoucherDetails.Refresh();
						CalculateReconcileBalance();
					}
					Cancel = -1;
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		private void grdVoucherDetails_BeforeColUpdate(object eventSender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			object OldValue = eventArgs.OldValue;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				if (!Information.IsDate(txtVoucherDate.Value))
				{
					MessageBox.Show("Enter Valid Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtVoucherDate.Focus();
					return;
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			if (Col == mReconciledColumn)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(aVoucherDetails.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), Col))) == TriState.True)
				{
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgChecked2"];
					CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
				}
				else if (((TriState) Convert.ToInt32(aVoucherDetails.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), Col))) == TriState.False)
				{ 
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgUnchecked"];
					CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == mDrAmountColumn || ColIndex == mCrAmountColumn)
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

			if (ColIndex == mVoucherDateColumn)
			{
				Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), SystemVariables.gSystemDateFormat);
			}
		}

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			grdVoucherDetails.Col = mReconciledColumn;
		}

		private void grdVoucherDetails_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				int Col = grdVoucherDetails.Col;

				if (Col == mReconciledColumn && ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[Col].Value).Trim() != "")
				{
					if (KeyAscii == 32)
					{
						KeyAscii = 0;
						grdVoucherDetails.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[Col].Value);
						grdVoucherDetails.UpdateData();
						grdVoucherDetails.Refresh();
						CalculateReconcileBalance();
					}
					else
					{
						KeyAscii = 0;
					}
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

		private void grdVoucherDetails_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float x = eventArgs.X * 15;
			float y = eventArgs.Y * 15;
			if (grdVoucherDetails.PointAt(x, y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
			{
				mLastCol = grdVoucherDetails.Col;
				mLastRow = grdVoucherDetails.Row;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.PostMsg(1);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{

			if (mLastCol == grdVoucherDetails.Col && mLastRow == grdVoucherDetails.Row)
			{
				return;
			}

			int Col = grdVoucherDetails.Col;
			if (Col == mReconciledColumn)
			{
				grdVoucherDetails.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[Col].Value);
				grdVoucherDetails.UpdateData();
				grdVoucherDetails.Refresh();
				CalculateReconcileBalance();
			}

		}

		private void txtLdgrNo_DropButtonClick(Object Sender, EventArgs e)
		{
			SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtLdgrNo");
		}

		private void txtLdgrNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			object mTempValue = null;
			string mysql = "";

			try
			{

				if (!SystemProcedure2.IsItEmpty(txtLdgrNo.Text, SystemVariables.DataType.StringType))
				{
					mysql = " select ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name");
					mysql = mysql + " , ldgr_cd from gl_ledger where ldgr_no='" + txtLdgrNo.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtLdgrName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLdgrName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
						GetVoucherDetail();
					}
				}
				else
				{
					txtLdgrName.Text = "";
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
						txtLdgrNo.Focus();
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

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtLdgrNo" : 
					txtLdgrNo.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLdgrNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtLdgrNo_Leave(txtLdgrNo, new EventArgs());
					} 
					break;
				default:
					return;
			}

		}


		private void GetVoucherDetail()
		{

			if (SystemProcedure2.IsItEmpty(txtLdgrNo.Text, SystemVariables.DataType.StringType))
			{
				return;
			}

			string mysql = " select ldgr_cd, current_reconciled_date, current_reconciled_bal from gl_ledger where ldgr_no='" + txtLdgrNo.Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				return;
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(1)))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtVoucherDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(2)))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtStatementEndingBalance.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(2));
			}

			mysql = " select atd.line_no, atd.time_stamp, avt.l_short_name, avt.a_short_name ";
			mysql = mysql + " , mt.voucher_date, mt.voucher_no, mt.reference_no ";
			mysql = mysql + " , gl_ledger.ldgr_no, gl_ledger.l_ldgr_name , gl_ledger.a_ldgr_name ";
			mysql = mysql + " , case when atd.lc_amount >= 0 then atd.lc_amount else 0 end as lc_dr_amt ";
			mysql = mysql + " , case when atd.lc_amount < 0 then abs(atd.lc_amount) else 0 end as lc_cr_amt ";
			mysql = mysql + " , atd.reconciled ";
			mysql = mysql + " , atd2.comments ";
			mysql = mysql + " from gl_accnt_trans_details atd ";
			mysql = mysql + " inner join gl_accnt_trans  mt on atd.entry_id = mt.entry_id ";
			mysql = mysql + " inner join gl_accnt_voucher_types  avt on mt.voucher_type = avt.voucher_type";
			mysql = mysql + " cross join gl_accnt_trans_details atd2 ";
			mysql = mysql + " inner join gl_ledger on atd2.ldgr_cd = gl_ledger.ldgr_cd";
			mysql = mysql + " where atd.ldgr_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
			mysql = mysql + " and mt.status <> 3 ";


			if (chkShowReconciled.CheckState == CheckState.Unchecked)
			{
				mysql = mysql + " and atd.reconciled =0 ";
			}

			mysql = mysql + " and atd2.dr_cr_line_no = 1 ";
			mysql = mysql + " and atd2.entry_id = mt.entry_id ";
			mysql = mysql + " and atd2.dr_cr_type <> atd.dr_cr_type";
			mysql = mysql + " order by 5 ";

			int Cnt = 0;
			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			DefineVoucherArray(-1, true);

			do 
			{
				DefineVoucherArray(Cnt, false);

				//Get the details information into the grid
				aVoucherDetails.SetValue(rsTempRec["line_no"], Cnt, mLineNoColumn);
				aVoucherDetails.SetValue(rsTempRec["time_stamp"], Cnt, mTimeStamp);
				aVoucherDetails.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsTempRec["l_short_name"] : rsTempRec["a_short_name"], Cnt, mVoucherTypeColumn);
				aVoucherDetails.SetValue(rsTempRec["voucher_date"], Cnt, mVoucherDateColumn);
				aVoucherDetails.SetValue(rsTempRec["voucher_no"], Cnt, mVoucherNo);
				aVoucherDetails.SetValue(rsTempRec["ldgr_no"], Cnt, mLdgrNo);
				aVoucherDetails.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsTempRec["l_ldgr_name"] : rsTempRec["a_ldgr_name"], Cnt, mParticulars);
				aVoucherDetails.SetValue(rsTempRec["lc_dr_amt"], Cnt, mDrAmountColumn);
				aVoucherDetails.SetValue(rsTempRec["lc_cr_amt"], Cnt, mCrAmountColumn);
				aVoucherDetails.SetValue(rsTempRec["reconciled"], Cnt, mReconciledColumn);
				aVoucherDetails.SetValue(rsTempRec["comments"], Cnt, mRemarksColumn);

				Cnt++;
			}
			while(rsTempRec.Read());

			grdVoucherDetails.Rebind(true);
			CalculateTotals(0, 0);
			CalculateReconcileBalance();

		}

		private void DefineVoucherArray(int pMaximumRows, bool pClearArray = false)
		{
			//''''*************************************************************************
			//'''Define the Vouchyer array size
			//''''*************************************************************************
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
			}
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, mMaxColumn}, new int[]{0, 0});

		}

		private void CalculateTotals(int mRowNumber, int mColNumber)
		{
			//''''*************************************************************************
			//'''Calculate the figures of following columns.
			//'''Quantity, Rate , Discount and amount.
			//''''*************************************************************************
			int Cnt = 0;

			double mTotalDrAmt = 0;
			double mTotalCrAmt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				mTotalDrAmt += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mDrAmountColumn)));
				mTotalCrAmt += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mCrAmountColumn)));
			}

			if (mTotalDrAmt != 0)
			{
				grdVoucherDetails.Columns[mDrAmountColumn].FooterText = StringsHelper.Format(mTotalDrAmt, "###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails.Columns[mDrAmountColumn].FooterText = "";
			}


			if (mTotalCrAmt != 0)
			{
				grdVoucherDetails.Columns[mCrAmountColumn].FooterText = StringsHelper.Format(mTotalCrAmt, "###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails.Columns[mCrAmountColumn].FooterText = "";
			}

		}

		private void CalculateReconcileBalance()
		{
			int Cnt = 0;
			double mDebitUnReconcileAmt = 0;
			double mCreditUnReconcileAmt = 0;
			double mDebitReconcileAmt = 0;
			double mCreditReconcileAmt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(aVoucherDetails.GetValue(Cnt, mReconciledColumn))) == TriState.True)
				{
					mDebitReconcileAmt += Conversion.Val(StringsHelper.Format(aVoucherDetails.GetValue(Cnt, mDrAmountColumn), "#################.###"));
					mCreditReconcileAmt += Conversion.Val(StringsHelper.Format(aVoucherDetails.GetValue(Cnt, mCrAmountColumn), "#################.###"));
				}
				else
				{
					mDebitUnReconcileAmt += Conversion.Val(StringsHelper.Format(aVoucherDetails.GetValue(Cnt, mDrAmountColumn), "#################.###"));
					mCreditUnReconcileAmt += Conversion.Val(StringsHelper.Format(aVoucherDetails.GetValue(Cnt, mCrAmountColumn), "#################.###"));
				}
			}

			dcReconcile[conDebitUnReconcileAmt].Text = StringsHelper.Format(mDebitUnReconcileAmt, "###,###,###,##0.000");
			dcReconcile[conDebitReconcileAmt].Text = StringsHelper.Format(mDebitReconcileAmt, "###,###,###,##0.000");
			dcReconcile[conDebitTotalAmt].Text = StringsHelper.Format(mDebitReconcileAmt + mDebitUnReconcileAmt, "###,###,###,##0.000");

			dcReconcile[conCreditUnReconcileAmt].Text = StringsHelper.Format(mCreditUnReconcileAmt, "###,###,###,##0.000");
			dcReconcile[conCreditReconcileAmt].Text = StringsHelper.Format(mCreditReconcileAmt, "###,###,###,##0.000");
			dcReconcile[conCreditTotalAmt].Text = StringsHelper.Format(mCreditReconcileAmt + mCreditUnReconcileAmt, "###,###,###,##0.000");

			dcReconcile[conUnReconcileBalanceAmt].Text = StringsHelper.Format(mDebitUnReconcileAmt - mCreditUnReconcileAmt, "###,###,###,##0.000");
			dcReconcile[conReconcileBalanceAmt].Text = StringsHelper.Format(mDebitReconcileAmt - mCreditReconcileAmt, "###,###,###,##0.000");
			dcReconcile[conReconcileBalance].Text = StringsHelper.Format((mDebitReconcileAmt + mDebitUnReconcileAmt) - (mCreditReconcileAmt + mCreditUnReconcileAmt), "###,###,###,##0.000");

			txtUnreconciledCreditAmount.Value = Conversion.Val(StringsHelper.Format(dcReconcile[conCreditUnReconcileAmt].Text, "############.###"));
			txtUnreconciledDebitAmount.Value = Conversion.Val(StringsHelper.Format(dcReconcile[conDebitUnReconcileAmt].Text, "############.###"));
			txtGLSystemBalance.Value = Conversion.Val(StringsHelper.Format(dcReconcile[conReconcileBalance].Text, "############.###"));
			txtAccountReconcilationDiff.Value = ReflectionHelper.GetPrimitiveValue<double>(txtStatementEndingBalance.Value) - ReflectionHelper.GetPrimitiveValue<double>(txtUnreconciledCreditAmount.Value) + ReflectionHelper.GetPrimitiveValue<double>(txtUnreconciledDebitAmount.Value) - ReflectionHelper.GetPrimitiveValue<double>(txtGLSystemBalance.Value);

		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool saveRecord()
		{

			bool result = false;
			string mysql = " select ldgr_cd from gl_ledger where ldgr_no='" + txtLdgrNo.Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mLdgrCd = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mLdgrCd))
			{
				MessageBox.Show("Invalid Ledger Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = true;
				txtLdgrNo.Focus();
				return result;
			}


			int Cnt = 0;
			int mReconciled = 0;
			int mLineNo = 0;


			SystemVariables.gConn.BeginTransaction();
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(aVoucherDetails.GetValue(Cnt, mReconciledColumn))) == TriState.True)
				{
					mReconciled = 1;
				}
				else
				{
					mReconciled = 0;
				}
				mLineNo = Convert.ToInt32(aVoucherDetails.GetValue(Cnt, mLineNoColumn));

				mysql = " update gl_accnt_trans_details ";
				mysql = mysql + " set reconciled = " + Conversion.Str(mReconciled);
				mysql = mysql + " , reconciled_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
				mysql = mysql + " where line_no = " + Conversion.Str(mLineNo);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
			}

			mysql = " update gl_ledger ";
			mysql = mysql + " set reconciled =1";
			mysql = mysql + " , last_reconciled_bal = current_reconciled_bal ";
			mysql = mysql + " , last_reconciled_date = current_reconciled_date ";
			mysql = mysql + " , current_reconciled_bal =" + ReflectionHelper.GetPrimitiveValue<string>(txtStatementEndingBalance.Value);
			mysql = mysql + " , current_reconciled_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
			mysql = mysql + " where ldgr_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mLdgrCd);

			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

			txtLdgrNo.Focus();
			return true;
		}


		public bool CheckDataValidity()
		{
			//Check validation during update and add of records

			if (!Information.IsDate(txtVoucherDate.Value))
			{
				MessageBox.Show("Enter Valid date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtVoucherDate.Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtLdgrNo.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Ledger Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtLdgrNo.Focus();
				return false;
			}

			return true;
		}


		public void AddRecord()
		{
			try
			{

				int Cnt = 0;

				//''''*************************************************************************
				//'''Grid settings
				int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					grdVoucherDetails.Columns[Cnt].FooterText = "";
				}
				DefineVoucherArray(-1, true);
				grdVoucherDetails.Rebind(true);

				SystemProcedure2.ClearTextBox(this);
				txtStatementEndingBalance.Value = 0;
				txtUnreconciledCreditAmount.Value = 0;
				txtUnreconciledDebitAmount.Value = 0;
				txtGLSystemBalance.Value = 0;
				txtAccountReconcilationDiff.Value = 0;
				txtVoucherDate.Value = DateTime.Today;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]), "AddRecord");
			}

		}

		public void LRoutine()
		{
			int Cnt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				aVoucherDetails.SetValue(TriState.True, Cnt, mReconciledColumn);
			}
			grdVoucherDetails.Rebind(true);
			CalculateTotals(0, 0);
			CalculateReconcileBalance();
		}

		public void URoutine()
		{
			int Cnt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				aVoucherDetails.SetValue(TriState.False, Cnt, mReconciledColumn);
			}
			grdVoucherDetails.Rebind(true);
			CalculateTotals(0, 0);
			CalculateReconcileBalance();
		}

		private void txtStatementEndingBalance_Change(Object Sender, EventArgs e)
		{
			CalculateReconcileBalance();
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
				grdVoucherDetails.Width = this.Width - 27;
			}
			catch
			{
			}
		}
	}
}