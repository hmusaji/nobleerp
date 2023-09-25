
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmRentReceipt
		: System.Windows.Forms.Form
	{

		public frmRentReceipt()
{
InitializeComponent();
} 
 public  void frmRentReceipt_old()
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


		private void frmRentReceipt_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		const int mLineNoColumn = 0;
		const int mNameColumn = 1;
		const int mFloorNoColumn = 2;
		const int mRoomNoColumn = 3;
		//Const mDescriptionColumn As Integer = 4
		//Const mIntallmentNoColumn As Integer = 4
		const int mAmountColumn = 4;
		const int mCashCheckColumn = 5;
		const int mBankColumn = 6;
		//Const mRemarkColumn As Integer = 4
		const int mMaxArrayCols = 6;

		private bool mFirstGridFocus = false;
		private DataSet rsLedgerCodeList = null;
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

			StringBuilder mysql = new StringBuilder();
			int Cnt = 0;
			int mFromLineNo = 0;
			int mToLineNo = 0;
			//Dim mPrintLabelResult As Integer

			clsNumToCharArabic clsNumToCharArabic = new clsNumToCharArabic();
			try
			{

				grdVoucherDetails.UpdateData();

				//gConn.Execute ("delete SAL_Temp_Rent_Receipt")

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					//If aVoucherDetails(Cnt, mPrintedColumn) = vbTrue Then
					mysql = new StringBuilder("INSERT INTO SAL_Temp_Rent_Receipt( [Date],[CheckCash],[Bank],[BuildingNo],[FloorNo],[RoomNo],[L_Ldgr_Name],[A_Ldgr_Name],[Amount],");
					mysql.Append(" [AmountInWord] , [Description],[Remarks],[User_Cd] ) ");
					mysql.Append(" values( ");
					mysql.Append("'" + DateTime.Parse(txtDate.Text).ToString("MM-dd-yyyy") + "',");
					mysql.Append(((Convert.ToString(aVoucherDetails.GetValue(Cnt, mCashCheckColumn)) == "") ? "Null" : "N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, mCashCheckColumn)) + "'") + ",");
					mysql.Append(((Convert.ToString(aVoucherDetails.GetValue(Cnt, mBankColumn)) == "") ? "Null" : "N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, mBankColumn)) + "'") + ",");
					mysql.Append("N'" + txtBuildingNo.Text + "',");
					mysql.Append(((Convert.ToString(aVoucherDetails.GetValue(Cnt, mFloorNoColumn)) == "") ? "Null" : "N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, mFloorNoColumn)) + "'") + ",");
					mysql.Append(((Convert.ToString(aVoucherDetails.GetValue(Cnt, mRoomNoColumn)) == "") ? "Null" : "N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, mRoomNoColumn)) + "'") + ",");
					mysql.Append(((Convert.ToString(aVoucherDetails.GetValue(Cnt, mNameColumn)) == "") ? "Null" : "N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, mNameColumn)) + "'") + ", '',");
					mysql.Append("" + Convert.ToString(aVoucherDetails.GetValue(Cnt, mAmountColumn)) + ",");
					mysql.Append("N'" + clsNumToCharArabic.NumToCharArabic(Convert.ToDouble(aVoucherDetails.GetValue(Cnt, mAmountColumn))) + "',");
					mysql.Append("N'" + txtDescription.Text + "','',");
					//mysql = mysql & "N'" & aVoucherDetails(Cnt, mDescriptionColumn) & "',"
					mysql.Append(Conversion.Str(SystemVariables.gLoggedInUserCode) + ")");

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql.ToString();
					TempCommand.ExecuteNonQuery();

					//''''*********************Get the New line no during add mode ***************
					if (Cnt == 0)
					{
						mFromLineNo = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
					}
					mToLineNo = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
					//''''*************************************************************************


					//End If

				}

				SystemReports.GetCrystalReport(100060164, 2, "10872,10873", mFromLineNo.ToString() + "," + mToLineNo.ToString());

				//MsgBox " Barcode Printing Completed", vbInformation
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				if (aVoucherDetails.GetLength(0) > 0)
				{
					MessageBox.Show(" Error Occured for Line No." + Convert.ToString(aVoucherDetails.GetValue(Cnt, mLineNoColumn)), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				return;
			}
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

			oThisFormToolBar.ShowPrintButton = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.ShowDeleteLineButton = true;
			oThisFormToolBar.ShowInsertLineButton = true;
			oThisFormToolBar.BeginInsertLineButtonWithGroup = true;

			this.WindowState = FormWindowState.Maximized;


			this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //setting form mode to add initially

			mFirstGridFocus = true;

			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, (0xE7E2DC).ToString(), (0xE7E2DC).ToString());
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Name", 4000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "Total", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, false, 100, "", SystemConstants.gArabicFontName);
			//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Date", 1100, , , , dbgLeft, , , , , , , , , , , , , , , , , , "txtTempDate")
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Floor No", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", SystemConstants.gArabicFontName);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Room No", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", SystemConstants.gArabicFontName);

			//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Description", 3000, True, , , , , , , , , , , , , , , , , , , gArabicFontName)
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, true, false, 12, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cash/Check", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", SystemConstants.gArabicFontName);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Bank Name", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", SystemConstants.gArabicFontName);
			//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1000, True)


			aVoucherDetails = new XArrayHelper();
			SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, false);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);
			grdVoucherDetails.Rebind(true);

			//    With txtTempDate
			//        .AlignHorizontal = dbiAlignHLeft
			//        .AlignVertical = dbiAlignVCenter
			//        .Appearance = dbiFlat
			//        .BorderStyle = dbiNoBorder
			//        .CenturyMode = dbiCurrentCentury
			//        .Calendar.SelectStyle = dbiCalSelStyleFlatBtn
			//        .Calendar.WeekTitles = "F,S,S,M,T,W,T"
			//        .CenturyMode = dbiSystemCentury
			//        .DisplayFormat = gSystemDateFormat
			//        .DropDown = dbiShowOnFocus
			//        .Format = gSystemDateFormat
			//    End With

		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}

			if (this.Width * 15 > 600)
			{
				C1Tab1.Width = this.Width - 27;

				if ((C1Tab1.Width * 15 - 250) > 0)
				{
					grdVoucherDetails.Width = C1Tab1.Width - 17;
				}
			}

			if (this.Height * 15 > 2500)
			{
				C1Tab1.Height = this.Height - 153;

				if ((C1Tab1.Height * 15 - 500) > 0)
				{
					grdVoucherDetails.Height = C1Tab1.Height - 53;
				}
			}

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
			CalculateTotals();
		}

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";

			if (mFirstGridFocus)
			{
				if (Convert.ToString(cmbMastersList.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList, 260, 10);
				}

				mFirstGridFocus = false;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.PostMsg(1);
			}
			else
			{

			}

		}

		private void CalculateTotals()
		{
			double mTotalAmount = 0;
			int Cnt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				aVoucherDetails.SetValue(StringsHelper.Format(aVoucherDetails.GetValue(Cnt, mAmountColumn), "###,###,###,###.000"), Cnt, mAmountColumn);
			}

			if (mTotalAmount != 0)
			{
				grdVoucherDetails.Columns[mAmountColumn].FooterText = StringsHelper.Format(mTotalAmount, "###,###,###,###.000");
			}
			else
			{
				grdVoucherDetails.Columns[mAmountColumn].FooterText = "";
			}
		}

		private void AssignGridLineNumbers()
		{
			int Cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				aVoucherDetails.SetValue(Cnt + 1, Cnt, mLineNoColumn);
			}
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			grdVoucherDetails.Columns[0].Text = (grdVoucherDetails.RowCount + 1).ToString();
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
		//
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
			}
		}
	}
}