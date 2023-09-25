
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmARAPVoucherTracking
		: System.Windows.Forms.Form
	{

		private DataSet recHeader = null;
		private DataSet recDetail = null;
		private DataSet recCloneDetail = null;

		private clsAccessAllowed _UserAccess = null;
		public frmARAPVoucherTracking()
{
InitializeComponent();
} 
 public  void frmARAPVoucherTracking_old()
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

		int mThisFormID = 0;
		double mHeaderLineNo = 0;
		double mDetailLineNo = 0;

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


		private void chkShowAll_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			GetLedgerDetail(1);
		}

		private void cmdClose_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			int ans = 0;
			if (grdVoucherDetails[1].EditActive)
			{
				grdVoucherDetails[1].UpdateData();
			}
			this.Close();
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

				if (frmARAPVoucherTracking.DefInstance.ActiveControl.Name.ToLower() == ("grdVoucherDetails").ToLower())
				{
					if (KeyCode == 13 || KeyCode == 115)
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
						if (grdVoucherDetails[1].Col == mUBClearedAmountColumn)
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

			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails[0], false, false, false, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow, 2.4f, 1.4f, (0x80A4C4).ToString());
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Line_No", 400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false, false, false, false, false, 100, "line_no");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Type", 460, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "l_short_name");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Voucher No.", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "voucher_no");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Reference No.", 1400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "Reference_no");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Voucher Date", 1050, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true, 100, "voucher_date");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Due Date", 1050, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true, 100, "Due_date");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Voucher Amount", 950, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true, 100, "fc_amount");

			//This column is generated for keeping the same sequence of header and detail grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Amount Due", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Amount Cleared", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true, 100, "fc_paid_amt");
			//This column is generated for keeping the same sequence of header and detail grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Amount Cleared", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Balance", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true, 100, "FC_due_amt");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Time_stamp", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

			C1.Win.C1TrueDBGrid.Style withVar = null;
			grdVoucherDetails[0].HoldFields();
			withVar = grdVoucherDetails[0].HighLightRowStyle;
			withVar.BackColor = Color.FromArgb(126, 145, 188);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.StyleDisp property withVar.BorderSize was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar.setBorderSize(1);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.StyleDisp property withVar.BorderType was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar.setBorderType(15);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.StyleDisp property withVar.BorderColor was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar.setBorderColor(Color.Navy);
			withVar.ForeColor = Color.White;

			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails[1], false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2.4f, 1.4f, (0x80A4C4).ToString());
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Line_No", 400, true, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false, false, false, false, false, 100, "Line_no");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Type", 460, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "L_Short_Name");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Voucher No.", 1000, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "voucher_no");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Reference No.", 1400, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "Reference_No");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Voucher Date", 1050, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true, 100, "voucher_date");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Due Date", 1050, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true, 100, "due_date");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Voucher Amount", 950, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true, 100, "fc_amount");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Amount Due", 1000, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true, 100, "Amt. Due");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Amount Cleared", 1000, true, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false, false, false, false, true, 100, "Amt. Cleared");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Amount Cleared", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Balance", 100, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true, 100, "FC_Due_Amt");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Time_stamp", 100, true, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false, false, false, false, false, 100, "time_stamp");
			grdVoucherDetails[1].HoldFields();

			recDetail = new DataSet();
			recHeader = new DataSet();
			recCloneDetail = new DataSet();

			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property recDetail.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			recDetail.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property recHeader.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			recHeader.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());

			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			txtLdgrNo.NumericOnly = ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no"))) != TriState.True;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				recHeader = null;
				recDetail = null;
				UserAccess = null;
				frmARAPVoucherTracking.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails[0].PostMsg(1);

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mHeaderLineNo = Convert.ToDouble(recHeader.Tables[0].Rows[0]["line_no"]);
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			mDetailLineNo = Convert.ToDouble(recDetail.Tables[0].Rows[0]["line_no"]);

		}

		private void grdVoucherDetails_BeforeColUpdate(object eventSender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.grdVoucherDetails, eventSender);
			int ColIndex = eventArgs.ColIndex;
			object OldValue = eventArgs.OldValue;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{

				object mReturnValue = null;
				double mAdjustedAmount = 0;
				double mGridClearedAmount = 0;
				double mTotalAmount = 0;
				string mySql = "";
				try
				{

					if (ColIndex == mUBClearedAmountColumn && Index == 1 && ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails[1].Columns[mUBClearedAmountColumn].Value) != "")
					{
						mGridClearedAmount = Conversion.Val(StringsHelper.Format(grdVoucherDetails[1].Columns[mUBClearedAmountColumn].Value, "############.000"));
						if (ReflectionHelper.GetPrimitiveValue<double>(OldValue) != mGridClearedAmount)
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mTotalAmount = Convert.ToDouble(recDetail.Tables[0].Rows[0]["amt. due"]);

							if (mGridClearedAmount > mTotalAmount)
							{
								MessageBox.Show("Cleared amount cannot be greater than Due amount", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								grdVoucherDetails[1].Focus();
								Cancel = -1;
								return;
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (grdVoucherDetails[0].Row < 0 || Convert.IsDBNull(grdVoucherDetails[0].Columns[mBalanceAmountColumn].Value))
							{
								MessageBox.Show("No header voucher to link", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								grdVoucherDetails[1].Focus();
								Cancel = -1;
								return;
							}

							//Check the cleared amount with the source voucher
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mAdjustedAmount = mGridClearedAmount - Convert.ToDouble(recDetail.Tables[0].Rows[0]["amt. cleared"]);
							if (mAdjustedAmount > Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails[0].Columns[mBalanceAmountColumn].Value)))
							{
								MessageBox.Show("Cleared amount cannot be greater than voucher Balance", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								grdVoucherDetails[1].Focus();
								Cancel = -1;
								return;
							}

							//''''''''''''Start Checking the TimeStamp'''''''''''''''''''''

							//Check for Header timestamp
							mySql = " select time_stamp from gl_accnt_trans_details where ";
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mySql = mySql + " line_no=" + Conversion.Str(recHeader.Tables[0].Rows[0]["line_no"]);

							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySql));
							//if the time stamp does not match the previous one then rollback
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							if (SystemProcedure2.tsFormat(Convert.ToString(recHeader.Tables[0].Rows[0]["Time_Stamp"])) != SystemProcedure2.tsFormat(ReflectionHelper.GetPrimitiveValue<string>(mReturnValue)))
							{
								MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								Cancel = -1;
								grdVoucherDetails[0].Focus();
								return;
							}

							//Check for Detail timestamp
							mySql = " select time_stamp from gl_accnt_trans_details where ";
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mySql = mySql + " line_no=" + Conversion.Str(recDetail.Tables[0].Rows[0]["line_no"]);

							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySql));
							//if the time stamp does not match the previous one then rollback
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							if (SystemProcedure2.tsFormat(Convert.ToString(recDetail.Tables[0].Rows[0]["Time_Stamp"])) != SystemProcedure2.tsFormat(ReflectionHelper.GetPrimitiveValue<string>(mReturnValue)))
							{
								MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								Cancel = -1;
								grdVoucherDetails[1].Focus();
								return;
							}

							//''''''''''''End Checking the TimeStamp'''''''''''''''''''''

							if (mGridClearedAmount == 0)
							{
								mySql = " delete gl_invoice_Tracking where";
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mySql = mySql + " source_line_no=" + Conversion.Str(recHeader.Tables[0].Rows[0]["line_no"]);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mySql = mySql + " and against_line_no=" + Conversion.Str(recDetail.Tables[0].Rows[0]["line_no"]);
							}
							else
							{
								mySql = "select adjusted_amt from gl_invoice_Tracking where";
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mySql = mySql + " source_line_no=" + Conversion.Str(recHeader.Tables[0].Rows[0]["line_no"]);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mySql = mySql + " and against_line_no=" + Conversion.Str(recDetail.Tables[0].Rows[0]["line_no"]);

								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySql));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (!Convert.IsDBNull(mReturnValue))
								{
									mySql = " UPDATE gl_Invoice_Tracking SET ";
									mySql = mySql + " Adjusted_Amt = Adjusted_Amt + " + mAdjustedAmount.ToString();
									//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
									mySql = mySql + " where Source_Line_No =" + Conversion.Str(recHeader.Tables[0].Rows[0]["line_no"]);
									//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
									mySql = mySql + " and Against_Line_No =" + Conversion.Str(recDetail.Tables[0].Rows[0]["line_no"]);
								}
								else
								{
									mySql = "INSERT INTO gl_Invoice_Tracking (Source_Line_No, ";
									mySql = mySql + " Against_Line_No, Adjusted_Amt, User_Cd) VALUES( ";
									//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
									mySql = mySql + Conversion.Str(recHeader.Tables[0].Rows[0]["line_no"]) + ",";
									//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
									mySql = mySql + Conversion.Str(recDetail.Tables[0].Rows[0]["line_no"]) + ",";
									mySql = mySql + Conversion.Str(mAdjustedAmount) + ",";
									mySql = mySql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";
								}
							}
							SystemVariables.gConn.BeginTransaction();
							SqlCommand TempCommand = null;
							TempCommand = SystemVariables.gConn.CreateCommand();
							TempCommand.CommandText = mySql;
							TempCommand.ExecuteNonQuery();
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.CommitTrans();
						}
					}
					return;
				}
				catch (System.Exception excep)
				{
					MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					Cancel = -1;
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
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		//UPGRADE_WARNING: (2050) ControlArray Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int Index, int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == mVoucherAmountColumn || ColIndex == mClearedAmountColumn || ColIndex == mUBClearedAmountColumn || ColIndex == mBalanceAmountColumn)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###,###,##0.000");
				}
				else
				{
					Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "0.000");
				}
			}
			if (ColIndex == mVoucherDateColumn || ColIndex == mVoucherDueDateColumn)
			{
				Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), SystemVariables.gSystemDateFormat);
			}
			if (Index == 1 && ColIndex == mDueAmountColumn)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###,###,##0.000");
				}
				else
				{
					Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "0.000");
				}
			}
		}

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.grdVoucherDetails, eventSender);
			if (Index == 1)
			{
				grdVoucherDetails[1].Focus();
			}
		}

		//UPGRADE_WARNING: (2050) ControlArray Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int Index, int MsgId)
		{


			//UPGRADE_WARNING: (1068) grdVoucherDetails().FirstRow of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mDetailFirstRow = ReflectionHelper.GetPrimitiveValue(grdVoucherDetails[1].FirstRow);
			//UPGRADE_WARNING: (1068) grdVoucherDetails().Bookmark of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mDetailBookmark = ReflectionHelper.GetPrimitiveValue(grdVoucherDetails[1].Bookmark);
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method recDetail.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			recDetail.Requery(-1);
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property recCloneDetail.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			if (recCloneDetail.getState() == ConnectionState.Open)
			{
			}
			//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method recDetail.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			recCloneDetail = recDetail.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
			grdVoucherDetails[1].Rebind(true);

			//UPGRADE_WARNING: (1068) grdVoucherDetails().Bookmark of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mHeaderBookmark = ReflectionHelper.GetPrimitiveValue(grdVoucherDetails[0].Bookmark);
			//UPGRADE_WARNING: (1068) grdVoucherDetails().FirstRow of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mHeaderFirstRow = ReflectionHelper.GetPrimitiveValue(grdVoucherDetails[0].FirstRow);
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method recHeader.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			recHeader.Requery(-1);
			grdVoucherDetails[0].Rebind(true);

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				grdVoucherDetails[1].FirstRow = mDetailFirstRow;
				grdVoucherDetails[1].Bookmark = mDetailBookmark;

				grdVoucherDetails[0].FirstRow = mHeaderFirstRow;
				grdVoucherDetails[0].Bookmark = mHeaderBookmark;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.grdVoucherDetails, eventSender);
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (Index == 0)
			{
				//If LastRow = "" Or LastRow = grdVoucherDetails(0).Bookmark + 1 Or IsNull(LastRow) Then
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (ReflectionHelper.GetPrimitiveValue<string>(LastRow) == "" || Convert.IsDBNull(LastRow))
				{
					return;
				}
				GetLedgerDetail(2);
			}
		}

		private void grdVoucherDetails_UnboundColumnFetch(Object eventSender, C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.grdVoucherDetails, eventSender);
			int Col = eventArgs.Col;
			string Value = eventArgs.Value;
			if (Index == 1 && Col == mUBClearedAmountColumn)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property recCloneDetail.Bookmark was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				recCloneDetail.setBookmark(Bookmark);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				Value = recCloneDetail.Tables[0].Rows[0]["amt. cleared"];
			}
		}

		private void txtLdgrNo_DropButtonClick(Object Sender, EventArgs e)
		{
			SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtLdgrNo");
		}

		private void txtLdgrNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			object mTempValue = null;

			try
			{

				if (!SystemProcedure2.IsItEmpty(txtLdgrNo.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name, ldgr_cd" : "a_ldgr_name, ldgr_cd") + " from gl_ledger where ldgr_no='" + txtLdgrNo.Text + "'"));
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
						GetLedgerDetail(1);
					}
				}
				else
				{
					txtLdgrName.Text = "";
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property recHeader.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					if (recHeader.getState() == ConnectionState.Open)
					{
					}

					//UPGRADE_ISSUE: (2064) ADODB.Recordset property recDetail.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					if (recDetail.getState() == ConnectionState.Open)
					{
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
			string mFindWhereClause = "";


			switch(pObjectName)
			{
				case "txtLdgrNo" : 
					txtLdgrNo.Text = ""; 
					mFindWhereClause = " l.type_cd =" + SystemGLConstants.gGLCustomerVendorTypeCode.ToString(); 
					//        mFindWhereClause = mFindWhereClause & " or left(ldgr_cd, 4) = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFindWhereClause)); 
					 
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


		private void GetVoucherHeader(string pDrCrType, int pLdgrCd)
		{
			string mySql = "";
			try
			{

				mySql = "select ATD.Line_No ";
				mySql = mySql + ", AVT.L_Short_Name ";
				mySql = mySql + ", AT.voucher_No ";
				mySql = mySql + ", ATD.Reference_No ";
				mySql = mySql + ", AT.Voucher_Date ";
				mySql = mySql + ", ATD.Due_Date ";
				//mySql = mySql & ", ATD.FC_Voucher_Amt "
				mySql = mySql + ", abs(ATD.FC_amount) as fc_amount ";
				mySql = mySql + ", ATD.FC_Paid_Amt ";
				mySql = mySql + ", ATD.FC_due_amt ";
				mySql = mySql + ", ATD.Time_Stamp ";
				mySql = mySql + " FROM  gl_accnt_trans_Details ATD ";
				mySql = mySql + " INNER JOIN gl_accnt_trans AT ON ATD.Entry_Id = AT.Entry_Id";
				mySql = mySql + " INNER JOIN gl_accnt_voucher_types AVT ON AT.Voucher_Type = AVT.Voucher_Type";
				mySql = mySql + " where ATD.Dr_Cr_Type='" + pDrCrType + "'";
				mySql = mySql + " and ATD.ldgr_cd=" + pLdgrCd.ToString();
				if (chkShowAll.CheckState == CheckState.Unchecked)
				{
					//mySql = mySql & " and ATD.fc_paid_amt <> ATD.fc_voucher_amt "
					mySql = mySql + " and ATD.fc_paid_amt <> abs(ATD.fc_amount) ";
				}
				mySql = mySql + " order by Voucher_Date";

				//UPGRADE_ISSUE: (2064) ADODB.Recordset property recHeader.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (recHeader.getState() == ConnectionState.Open)
				{
				}

				SqlDataAdapter adap = new SqlDataAdapter(mySql, SystemVariables.gConn);
				recHeader.Tables.Clear();
				adap.Fill(recHeader);

				grdVoucherDetails[0].SetDataBinding(recHeader, "Table", grdVoucherDetails[0].Columns.Count > 0);
				foreach (C1.Win.C1TrueDBGrid.C1DisplayColumn col in grdVoucherDetails[0].Splits[0].DisplayColumns)
				{
					col.Visible = true;
				}
				grdVoucherDetails[0].Refresh();
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void GetVoucherDetail(string pDrCrType, int pLdgrCode, int pSourceLineNo)
		{

			string mySql = " SELECT ATD.Line_No , AVT.L_Short_Name ";
			mySql = mySql + ", AT.voucher_No ";
			mySql = mySql + ", ATD.Reference_No ";
			mySql = mySql + ", AT.Voucher_Date , ATD.Due_Date ";
			//mySql = mySql & ", ATD.FC_Voucher_Amt "
			mySql = mySql + ", abs(ATD.FC_amount) as fc_amount ";
			mySql = mySql + ", ATD.FC_Due_Amt + isnull(InvTracking.Adjusted_Amt,0) AS [Amt. Due] ";
			mySql = mySql + ", isnull(InvTracking.Adjusted_Amt,0) AS [Amt. Cleared] ";
			mySql = mySql + ", ATD.FC_Due_Amt , InvTracking.comments as [Comments] ";
			mySql = mySql + ", ATD.Time_Stamp ";
			mySql = mySql + " FROM gl_accnt_trans  as AT";
			mySql = mySql + " INNER JOIN gl_accnt_voucher_types as AVT ON AT.Voucher_Type = AVT.Voucher_Type";
			mySql = mySql + " right outer join gl_accnt_trans_Details as ATD ON AT.Entry_Id = ATD.Entry_Id";
			mySql = mySql + " left outer JOIN";
			mySql = mySql + " (select Adjusted_Amt, against_line_no, source_Line_No,comments from  gl_invoice_Tracking";
			mySql = mySql + " where source_Line_No=" + Conversion.Str(pSourceLineNo) + ")";
			mySql = mySql + " as InvTracking";
			mySql = mySql + " ON ATD.Line_No = InvTracking.Against_Line_No";
			//mySql = mySql & " ON ATD.Line_No = InvTracking.source_Line_No"
			mySql = mySql + " where ATD.Dr_Cr_Type='" + pDrCrType + "'";
			mySql = mySql + " and ATD.ldgr_cd=" + pLdgrCode.ToString();
			if (chkShowAll.CheckState == CheckState.Unchecked)
			{
				//mySql = mySql & " and (ATD.fc_voucher_amt <> ATD.fc_paid_amt) "
				mySql = mySql + " and (abs(atd.fc_amount) <> ATD.fc_paid_amt) ";
			}
			mySql = mySql + " order by voucher_date ";

			//UPGRADE_ISSUE: (2064) ADODB.Recordset property recDetail.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			if (recDetail.getState() == ConnectionState.Open)
			{
			}
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property recCloneDetail.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			if (recCloneDetail.getState() == ConnectionState.Open)
			{
			}

			SqlDataAdapter adap = new SqlDataAdapter(mySql, SystemVariables.gConn);
			recDetail.Tables.Clear();
			adap.Fill(recDetail);
			//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method recDetail.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			recCloneDetail = recDetail.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());

			grdVoucherDetails[1].SetDataBinding(recDetail, "Table", grdVoucherDetails[1].Columns.Count > 0);
			foreach (C1.Win.C1TrueDBGrid.C1DisplayColumn col in grdVoucherDetails[1].Splits[0].DisplayColumns)
			{
				col.Visible = true;
			}
			grdVoucherDetails[1].Refresh();

		}

		private void GetLedgerDetail(int pHeaderOrDetail)
		{
			object mReturnValue = null;
			string mHeaderType = "";
			string mDetailType = "";

			if (!SystemProcedure2.IsItEmpty(txtLdgrNo.Text, SystemVariables.DataType.StringType))
			{
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select ldgr_cd, type_cd from gl_ledger where ldgr_no='" + txtLdgrNo.Text + "'"));
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

			//If Left(mReturnValue, 4) = Left(gGLCustomerVendorTypeCode, 4) Then
			//    mHeaderType = "C"
			//    mDetailType = "D"
			//ElseIf Left(mReturnValue, 4) = Left(gGLCustomerVendorTypeCode, 4) Then
			//    mHeaderType = "D"
			//    mDetailType = "C"
			//Else
			//    Exit Sub
			//End If

			if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1)) == SystemGLConstants.gGLCustomerVendorTypeCode)
			{
				mHeaderType = "D";
				mDetailType = "C";
			}
			else
			{
				return;
			}

			if (pHeaderOrDetail == 1)
			{
				GetVoucherHeader(mHeaderType, Convert.ToInt32(Double.Parse(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)))));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				GetVoucherDetail(mDetailType, Convert.ToInt32(Double.Parse(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)))), (Convert.IsDBNull(grdVoucherDetails[0].Columns[0].Value)) ? 0 : ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails[0].Columns[0].Value));
			}
			else
			{
				GetVoucherDetail(mDetailType, Convert.ToInt32(Double.Parse(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)))), ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails[0].Columns[0].Value));
			}
		}
	}
}