
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmARAPTransactionMatching
		: System.Windows.Forms.Form
	{

		private DataSet recHeader = null;
		private DataSet recDetail = null;
		private DataSet recCloneDetail = null;

		private clsAccessAllowed _UserAccess = null;
		public frmARAPTransactionMatching()
{
InitializeComponent();
} 
 public  void frmARAPTransactionMatching_old()
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

		private int mThisFormID = 0;
		private double mHeaderLineNo = 0;
		private double mDetailLineNo = 0;
		private string mHeaderTypeSelected = "";

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


		const string mDrCaption = "Dr";
		const string mCrCaption = "Cr";

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
			//
			//If comHeaderType.Text = mDrCaption Then
			//    Call GetLedgerDetail(txtLdgrNo.Text, 1, mDrCaption)
			//Else
			//    Call GetLedgerDetail(txtLdgrNo.Text, 1, mCrCaption)
			//End If
		}

		public void CloseForm()
		{
			if (grdVoucherDetails[1].EditActive)
			{
				grdVoucherDetails[1].UpdateData();
			}
			this.Close();

		}

		private void cmdFind_OKClick(Object Sender, EventArgs e)
		{
			object mTempValue = null;
			if (!SystemProcedure2.IsItEmpty(txtLdgrNo.Text, SystemVariables.DataType.StringType))
			{
				if (comHeaderType.Text == mDrCaption)
				{
					mHeaderTypeSelected = mDrCaption;
					GetLedgerDetail(txtLdgrNo.Text, 1, mDrCaption);
				}
				else
				{
					mHeaderTypeSelected = mCrCaption;
					GetLedgerDetail(txtLdgrNo.Text, 1, mCrCaption);
				}
				CalculateTotals(0, 0);
			}
			else
			{
				MessageBox.Show(" Please select a Ledger.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtLdgrNo.Focus();
			}
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

				if (this.ActiveControl.Name.ToLower() == ("grdVoucherDetails").ToLower())
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

			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this);
			oThisFormToolBar.ShowMoveRecordNextButton = true;
			oThisFormToolBar.ShowMoveRecordPreviousButton = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.ShowExitButton = true;
			this.WindowState = FormWindowState.Maximized;

			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails[0], false, false, false, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow, 2.4f, 1.4f, (0xE7E2DC).ToString(), (0xE7E2DC).ToString());
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Line_No", 400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false, false, false, false, false, 100, "line_no");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Type", 460, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "l_short_name");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Voucher No.", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "voucher_no");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Reference No.", 1400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "Reference_no", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Voucher Date", 1050, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true, 100, "voucher_date");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Due Date", 1050, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true, 100, "Due_date");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Voucher Amount", 950, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true, 100, "fc_amount");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Amount Due", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Amount Cleared", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true, 100, "fc_paid_amt");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Amount Cleared", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Balance", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true, 100, "FC_due_amt");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Time_stamp", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[0], "Remarks", 4000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "Remarks");

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
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails[1], false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2.4f, 1.4f, (0xE7E2DC).ToString(), (0xE7E2DC).ToString());
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Line_No", 400, true, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false, false, false, false, false, 100, "Line_no");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Type", 460, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "L_Short_Name");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Voucher No.", 1000, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "voucher_no");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Reference No.", 1400, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "Reference_No", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Voucher Date", 1050, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true, 100, "voucher_date");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Due Date", 1050, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true, 100, "due_date");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Voucher Amount", 950, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true, 100, "fc_amount");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Amount Due", 1000, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true, 100, "amt_due");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Amount Cleared", 1000, true, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false, false, false, false, true, 100, "amt_cleared");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Amount Cleared", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Balance", 1000, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true, 100, "FC_Due_Amt");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Time_stamp", 100, true, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false, false, false, false, false, 100, "time_stamp");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails[1], "Remarks", 4000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "Remarks");
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


			comHeaderType.AddItem("Dr");
			comHeaderType.AddItem("Cr");
			comHeaderType.ListIndex = 0;
		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			grdVoucherDetails[0].Width = this.Width - 20;
			grdVoucherDetails[1].Width = this.Width - 20;
			//UPGRADE_ISSUE: (2064) Line property Line1.X2 was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			Line1.setX2(this.Width * 15);
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

			Application.DoEvents();
			CalculateTotals(0, 0);
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
				string mysql = "";
				int mSourceLineNo = 0;
				string mAgainstLineNo = "";

				try
				{

					if (ColIndex == mUBClearedAmountColumn && Index == 1 && ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails[1].Columns[mUBClearedAmountColumn].Value) != "")
					{
						mGridClearedAmount = Conversion.Val(StringsHelper.Format(grdVoucherDetails[1].Columns[mUBClearedAmountColumn].Value, "############.000"));
						if (ReflectionHelper.GetPrimitiveValue<double>(OldValue) != mGridClearedAmount)
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mTotalAmount = Convert.ToDouble(recDetail.Tables[0].Rows[0]["amt_due"]);

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
							mAdjustedAmount = mGridClearedAmount - Convert.ToDouble(recDetail.Tables[0].Rows[0]["amt_cleared"]);
							if (mAdjustedAmount > Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails[0].Columns[mBalanceAmountColumn].Value)))
							{
								MessageBox.Show("Cleared amount cannot be greater than voucher Balance", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								grdVoucherDetails[1].Focus();
								Cancel = -1;
								return;
							}

							//''''''''''''Start Checking the TimeStamp'''''''''''''''''''''

							//Check for Header timestamp
							mysql = " select time_stamp from gl_accnt_trans_details where ";
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mysql = mysql + " line_no=" + Conversion.Str(recHeader.Tables[0].Rows[0]["line_no"]);

							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
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
							mysql = " select time_stamp from gl_accnt_trans_details where ";
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mysql = mysql + " line_no=" + Conversion.Str(recDetail.Tables[0].Rows[0]["line_no"]);

							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
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

							if (mHeaderTypeSelected == mDrCaption)
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mSourceLineNo = Convert.ToInt32(recHeader.Tables[0].Rows[0]["line_no"]);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mAgainstLineNo = Convert.ToString(recDetail.Tables[0].Rows[0]["line_no"]);
							}
							else
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mSourceLineNo = Convert.ToInt32(recDetail.Tables[0].Rows[0]["line_no"]);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mAgainstLineNo = Convert.ToString(recHeader.Tables[0].Rows[0]["line_no"]);
							}

							if (mGridClearedAmount == 0)
							{
								mysql = " delete gl_invoice_Tracking where";
								mysql = mysql + " source_line_no=" + Conversion.Str(mSourceLineNo);
								mysql = mysql + " and against_line_no=" + Conversion.Str(mAgainstLineNo);
							}
							else
							{
								mysql = "select adjusted_amt from gl_invoice_Tracking where";
								mysql = mysql + " source_line_no=" + Conversion.Str(mSourceLineNo);
								mysql = mysql + " and against_line_no=" + Conversion.Str(mAgainstLineNo);

								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (!Convert.IsDBNull(mReturnValue))
								{
									mysql = " UPDATE gl_Invoice_Tracking SET ";
									mysql = mysql + " Adjusted_Amt = Adjusted_Amt + " + mAdjustedAmount.ToString();
									mysql = mysql + " where Source_Line_No =" + Conversion.Str(mSourceLineNo);
									mysql = mysql + " and Against_Line_No =" + Conversion.Str(mAgainstLineNo);
								}
								else
								{
									mysql = "INSERT INTO gl_Invoice_Tracking (Source_Line_No, ";
									mysql = mysql + " Against_Line_No, Adjusted_Amt, User_Cd) VALUES( ";
									mysql = mysql + Conversion.Str(mSourceLineNo) + ",";
									mysql = mysql + Conversion.Str(mAgainstLineNo) + ",";
									mysql = mysql + Conversion.Str(mAdjustedAmount) + ",";
									mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";
								}
							}
							SystemVariables.gConn.BeginTransaction();
							SqlCommand TempCommand = null;
							TempCommand = SystemVariables.gConn.CreateCommand();
							TempCommand.CommandText = mysql;
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
				//    grdVoucherDetails(1).SetFocus
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

				if (comHeaderType.Text == mDrCaption)
				{
					GetLedgerDetail(txtLdgrNo.Text, 2, mDrCaption);
				}
				else
				{
					GetLedgerDetail(txtLdgrNo.Text, 2, mCrCaption);
				}

				CalculateTotals(0, 0);
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
				Value = recCloneDetail.Tables[0].Rows[0]["amt_cleared"];
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
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name, default_dr_cr_type " : "a_ldgr_name, default_dr_cr_type ") + " from gl_ledger where ldgr_no='" + txtLdgrNo.Text + "'" + " and type_cd=" + SystemGLConstants.gGLCustomerVendorTypeCode.ToString()));
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
						if (ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1)) == "D")
						{
							comHeaderType.ListIndex = 0;
						}
						else
						{
							comHeaderType.ListIndex = 1;
						}
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
			string mysql = "";
			try
			{

				mysql = "select ATD.Line_No ";
				mysql = mysql + ", AVT.L_Short_Name ";
				mysql = mysql + ", AT.voucher_No ";
				mysql = mysql + ", ATD.Reference_No ";
				mysql = mysql + ", AT.Voucher_Date ";
				mysql = mysql + ", ATD.Due_Date ";
				//mySql = mySql & ", ATD.FC_Voucher_Amt "
				mysql = mysql + ", abs(ATD.FC_amount) as fc_amount ";
				mysql = mysql + ", ATD.FC_Paid_Amt ";
				mysql = mysql + ", ATD.FC_due_amt ";
				mysql = mysql + ", ATD.Time_Stamp ";
				mysql = mysql + ", ATD.comments remarks ";
				mysql = mysql + " FROM  gl_accnt_trans_Details ATD ";
				mysql = mysql + " INNER JOIN gl_accnt_trans AT ON ATD.Entry_Id = AT.Entry_Id";
				mysql = mysql + " INNER JOIN gl_accnt_voucher_types AVT ON AT.Voucher_Type = AVT.Voucher_Type";
				mysql = mysql + " where ATD.Dr_Cr_Type='" + pDrCrType + "'";
				mysql = mysql + " and ATD.ldgr_cd=" + pLdgrCd.ToString();
				if (chkShowAll.CheckState == CheckState.Unchecked)
				{
					//mySql = mySql & " and ATD.fc_paid_amt <> ATD.fc_voucher_amt "
					mysql = mysql + " and ATD.fc_paid_amt <> abs(ATD.fc_amount) ";
				}
				mysql = mysql + " order by Voucher_Date";

				//UPGRADE_ISSUE: (2064) ADODB.Recordset property recHeader.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (recHeader.getState() == ConnectionState.Open)
				{
				}

				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
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
			if (chkShowAll.CheckState == CheckState.Unchecked)
			{
				mysql = mysql + " and (abs(atd.fc_amount) <> ATD.fc_paid_amt) ";
			}
			mysql = mysql + " order by voucher_date ";

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

			grdVoucherDetails[1].SetDataBinding(recDetail, "Table", grdVoucherDetails[1].Columns.Count > 0);
			foreach (C1.Win.C1TrueDBGrid.C1DisplayColumn col in grdVoucherDetails[1].Splits[0].DisplayColumns)
			{
				col.Visible = true;
			}
			grdVoucherDetails[1].Refresh();

		}

		private void GetLedgerDetail(string pLdgrNo, int pHeaderOrDetail, string pHeaderType)
		{
			object mReturnValue = null;
			string mHeaderType = "";
			string mDetailType = "";

			if (!SystemProcedure2.IsItEmpty(txtLdgrNo.Text, SystemVariables.DataType.StringType))
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

			//If Left(mReturnValue, 4) = Left(gGLCustomerVendorTypeCode, 4) Then
			//    mHeaderType = "C"
			//    mDetailType = "D"
			//ElseIf Left(mReturnValue, 4) = Left(gGLCustomerVendorTypeCode, 4) Then
			//    mHeaderType = "D"
			//    mDetailType = "C"
			//Else
			//    Exit Sub
			//End If


			//If mReturnValue(2) = "C" Then
			//    mHeaderType = "D"
			//    mDetailType = "C"
			//Else
			//    mHeaderType = "C"
			//    mDetailType = "D"
			//End If

			if (pHeaderType == mDrCaption)
			{
				mHeaderType = "D";
				mDetailType = "C";
			}
			else
			{
				mHeaderType = "C";
				mDetailType = "D";
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


		private void CalculateTotals(int mRowNumber, int mColNumber)
		{



			DataSet rsTempRec = null;

			double mHeaderVoucherAmt = 0;
			double mHeaderVoucherAmtCleared = 0;
			double mHeaderBalanceAmt = 0;

			double mDetailVoucherAmt = 0;
			double mDetailVoucherAmtCleared = 0;
			double mDetailVoucherAmtDue = 0;
			double mDetailBalanceAmt = 0;

			if (recHeader.Tables[0].Rows.Count > 0)
			{
				rsTempRec = new DataSet();
				//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method recHeader.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempRec = recHeader.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempRec.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempRec.MoveFirst();
				foreach (DataRow iteration_row in rsTempRec.Tables[0].Rows)
				{
					mHeaderVoucherAmt += Convert.ToDouble(iteration_row["fc_amount"]);
					mHeaderVoucherAmtCleared += Convert.ToDouble(iteration_row["fc_paid_amt"]);
					mHeaderBalanceAmt += Convert.ToDouble(iteration_row["fc_due_amt"]);
				}
				rsTempRec = null;
			}

			if (recDetail.Tables[0].Rows.Count > 0)
			{
				rsTempRec = new DataSet();
				//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method recDetail.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempRec = recDetail.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempRec.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempRec.MoveFirst();
				foreach (DataRow iteration_row_2 in rsTempRec.Tables[0].Rows)
				{
					mDetailVoucherAmt += Convert.ToDouble(iteration_row_2["fc_amount"]);
					mDetailVoucherAmtCleared += Convert.ToDouble(iteration_row_2["amt_cleared"]);
					mDetailVoucherAmtDue += Convert.ToDouble(iteration_row_2["amt_due"]);
					mDetailBalanceAmt += Convert.ToDouble(iteration_row_2["fc_due_amt"]);
				}
				rsTempRec = null;
			}

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''
			//'''''Header Grid ''''''''''''''''
			if (mHeaderVoucherAmt != 0)
			{
				grdVoucherDetails[0].Columns[mVoucherAmountColumn].FooterText = StringsHelper.Format(mHeaderVoucherAmt, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails[0].Columns[mVoucherAmountColumn].FooterText = "";
			}

			if (mHeaderVoucherAmtCleared != 0)
			{
				grdVoucherDetails[0].Columns[mClearedAmountColumn].FooterText = StringsHelper.Format(mHeaderVoucherAmtCleared, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails[0].Columns[mClearedAmountColumn].FooterText = "";
			}

			if (mHeaderBalanceAmt != 0)
			{
				grdVoucherDetails[0].Columns[mBalanceAmountColumn].FooterText = StringsHelper.Format(mHeaderBalanceAmt, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails[0].Columns[mBalanceAmountColumn].FooterText = "";
			}
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''
			//'''''Details Grid ''''''''''''''''
			if (mDetailVoucherAmt != 0)
			{
				grdVoucherDetails[1].Columns[mVoucherAmountColumn].FooterText = StringsHelper.Format(mDetailVoucherAmt, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails[1].Columns[mVoucherAmountColumn].FooterText = "";
			}

			if (mDetailVoucherAmtCleared != 0)
			{
				grdVoucherDetails[1].Columns[mUBClearedAmountColumn].FooterText = StringsHelper.Format(mDetailVoucherAmtCleared, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails[1].Columns[mUBClearedAmountColumn].FooterText = "";
			}

			if (mDetailVoucherAmtDue != 0)
			{
				grdVoucherDetails[1].Columns[mDueAmountColumn].FooterText = StringsHelper.Format(mDetailVoucherAmtDue, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails[1].Columns[mDueAmountColumn].FooterText = "";
			}

			if (mDetailBalanceAmt != 0)
			{
				grdVoucherDetails[1].Columns[mBalanceAmountColumn].FooterText = StringsHelper.Format(mDetailBalanceAmt, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails[1].Columns[mBalanceAmountColumn].FooterText = "";
			}
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''

		}

		public void MRoutine()
		{

			if (SystemProcedure2.IsItEmpty(txtLdgrNo.Text, SystemVariables.DataType.StringType))
			{
				return;
			}

			string mysql = " select top 1 max(ldgr_no) from GL_Ledger ";
			mysql = mysql + " where ldgr_no < '" + txtLdgrNo.Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtLdgrNo.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				txtLdgrNo_Leave(txtLdgrNo, new EventArgs());
				cmdFind_OKClick(cmdFind, null);
			}
		}

		public void ORoutine()
		{


			if (SystemProcedure2.IsItEmpty(txtLdgrNo.Text, SystemVariables.DataType.StringType))
			{
				return;
			}

			string mysql = " select top 1 min(ldgr_no) from GL_Ledger ";
			mysql = mysql + " where ldgr_no > '" + txtLdgrNo.Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtLdgrNo.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				txtLdgrNo_Leave(txtLdgrNo, new EventArgs());
				cmdFind_OKClick(cmdFind, null);
			}

		}
	}
}