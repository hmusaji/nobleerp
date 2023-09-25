
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSALInstallmentReceipt
		: System.Windows.Forms.Form
	{

		public frmSALInstallmentReceipt()
{
InitializeComponent();
} 
 public  void frmSALInstallmentReceipt_old()
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


		private void frmSALInstallmentReceipt_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		const int mDateColumn = 1;
		//Const mMachineNoColumn As Integer = 2
		const int mLdgrCodeColumn = 2;
		const int mLdgrNameColumn = 3;
		const int mIntallmentNoColumn = 4;
		const int mAmountColumn = 5;
		const int mPrintedColumn = 6;
		const int mContractLNColumn = 7;
		const int mRemarkColumn = 8;
		const int mMaxArrayCols = 8;

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
			int cnt = 0;
			int mFromLineNo = 0;
			int mToLineNo = 0;
			//Dim mPrintLabelResult As Integer

			try
			{

				grdVoucherDetails.UpdateData();

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = "delete SAL_Temp_Receipt";
				TempCommand.ExecuteNonQuery();

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(aVoucherDetails.GetValue(cnt, mPrintedColumn))) == TriState.True)
					{
						mysql = new StringBuilder("INSERT INTO SAL_Temp_Receipt( Installment_Date, IntallmentNo, ldgr_no, L_Ldgr_Name, A_Ldgr_Name, Amount, Remarks, User_cd ) ");
						mysql.Append(" values( ");
						//mysql = mysql & IIf(aVoucherDetails(cnt, mMachineNoColumn) = "", "Null", "'" & aVoucherDetails(cnt, mMachineNoColumn) & "'") & ","
						mysql.Append("'" + StringsHelper.Format(aVoucherDetails.GetValue(cnt, mDateColumn), SystemVariables.gSystemDateFormat) + "',");
						mysql.Append(((Convert.ToString(aVoucherDetails.GetValue(cnt, mIntallmentNoColumn)) == "") ? "Null" : Convert.ToString(aVoucherDetails.GetValue(cnt, mIntallmentNoColumn))) + ",");
						mysql.Append(((Convert.ToString(aVoucherDetails.GetValue(cnt, mLdgrCodeColumn)) == "") ? "Null" : "'" + Convert.ToString(aVoucherDetails.GetValue(cnt, mLdgrCodeColumn)) + "'") + ",");
						mysql.Append(((Convert.ToString(aVoucherDetails.GetValue(cnt, mLdgrNameColumn)) == "") ? "Null" : "'" + Convert.ToString(aVoucherDetails.GetValue(cnt, mLdgrNameColumn)) + "'") + ",");
						mysql.Append(((Convert.ToString(aVoucherDetails.GetValue(cnt, mLdgrNameColumn)) == "") ? "Null" : "'" + Convert.ToString(aVoucherDetails.GetValue(cnt, mLdgrNameColumn)) + "'") + ",");
						mysql.Append("" + Convert.ToString(aVoucherDetails.GetValue(cnt, mAmountColumn)) + ",");
						mysql.Append("N'" + Convert.ToString(aVoucherDetails.GetValue(cnt, mRemarkColumn)) + "',");
						mysql.Append(Conversion.Str(SystemVariables.gLoggedInUserCode) + ")");

						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql.ToString();
						TempCommand_2.ExecuteNonQuery();

						//''''*********************Get the New line no during add mode ***************
						if (cnt == 0)
						{
							mFromLineNo = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
						}
						mToLineNo = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
						//''''*************************************************************************

						if (Convert.ToString(aVoucherDetails.GetValue(cnt, mContractLNColumn)) != "")
						{
							mysql = new StringBuilder("update SAL_Sales_Contract_Details");
							mysql.Append(" set Is_Printed = 1 where Line_No = " + Convert.ToString(aVoucherDetails.GetValue(cnt, mContractLNColumn)));
							SqlCommand TempCommand_3 = null;
							TempCommand_3 = SystemVariables.gConn.CreateCommand();
							TempCommand_3.CommandText = mysql.ToString();
							TempCommand_3.ExecuteNonQuery();
						}
					}

				}

				SystemReports.GetCrystalReport(100060163, 2, "10859,10860", mFromLineNo.ToString() + "," + mToLineNo.ToString());

				//MsgBox " Barcode Printing Completed", vbInformation
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				if (aVoucherDetails.GetLength(0) > 0)
				{
					MessageBox.Show(" Error Occured for Line No." + Convert.ToString(aVoucherDetails.GetValue(cnt, mLineNoColumn)), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				return;
			}
		}


		public void CloseForm()
		{
			this.Close();
		}

		private void cmdGenerate_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, 0, true);
				grdVoucherDetails.Rebind(true);
				GetRecord();
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
			}

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
			txtFromDate.Value = SystemVariables.gCurrentDate;
			txtToDate.Value = SystemVariables.gCurrentDate;

			mFirstGridFocus = true;

			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, (0xE7E2DC).ToString(), (0xE7E2DC).ToString());
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Date", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "txtTempDate");
			//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Machine No", 1500, True)
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Code", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, true, false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Name", 3000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "Total", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Intallment", 1000, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, true, false, 12, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Print", 500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Contract LN", 100, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1000, true);

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			withVar = grdVoucherDetails.Splits[0].DisplayColumns[mPrintedColumn];
			withVar.DataColumn.ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
			withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
			withVar.Visible = true;

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

		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}

			if ((C1Tab1.Width * 15 - (this.Width * 15 - 400)) > 0)
			{
				C1Tab1.Width = this.Width - 27;

				if ((C1Tab1.Width * 15 - 250) > 0)
				{
					grdVoucherDetails.Width = C1Tab1.Width - 17;
				}
			}

			if ((C1Tab1.Height * 15 - (this.Height * 15 - 2600)) > 0)
			{
				C1Tab1.Height = this.Height - 173;

				if ((C1Tab1.Height * 15 - 500) > 0)
				{
					grdVoucherDetails.Height = C1Tab1.Height - 33;
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

				DefineMasterRecordset();
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
			int cnt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(StringsHelper.Format(aVoucherDetails.GetValue(cnt, mAmountColumn), "###,###,###,###.000"), cnt, mAmountColumn);

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(aVoucherDetails.GetValue(cnt, mPrintedColumn))) == TriState.True)
				{
					mTotalAmount += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, mAmountColumn)));
				}
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

		public void GetRecord()
		{

			string mysql = "";

			SqlDataReader rsLocalRec = null;



			int cnt = 0;

			try
			{

				//Change the form mode to edit
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;

				mysql = " select scd.Line_No, l.Country, sc.Contract_No, scd.Installment_No, scd.Installment_Date,  scd.Amount, scd.Remarks, l.ldgr_no, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l.l_ldgr_name" : "l.a_ldgr_name") + " as ledger_name ";
				mysql = mysql + " from SAL_Sales_Contract sc inner join GL_Ledger l on l.Ldgr_Cd = sc.Ldgr_Cd ";
				mysql = mysql + " inner join SAL_Sales_Contract_Details scd on sc.Entry_Id = scd.Entry_Id";
				mysql = mysql + " where scd.is_paid = 0 "; //scd.Is_Printed = 0 and
				mysql = mysql + " and (Installment_Date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtFromDate.Value) + "'";
				mysql = mysql + " and Installment_Date <= '" + ReflectionHelper.GetPrimitiveValue<string>(txtToDate.Value) + "') order by scd.Installment_Date, l.ldgr_no ";

				if (txtCustomerCode.Text != "")
				{
					mysql = mysql + " and l.ldgr_no = '" + txtCustomerCode.Text + "'";
				}

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand.ExecuteReader();
				cnt = 0;

				SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, true);


				if (rsLocalRec.Read())
				{

					do 
					{
						SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, cnt, false);

						aVoucherDetails.SetValue(Conversion.Str(cnt + 1).Trim(), cnt, mLineNoColumn);
						aVoucherDetails.SetValue(rsLocalRec["Line_No"], cnt, mContractLNColumn);
						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["Installment_Date"]) + "", cnt, mDateColumn);
						aVoucherDetails.SetValue(rsLocalRec["ldgr_no"], cnt, mLdgrCodeColumn);
						aVoucherDetails.SetValue(rsLocalRec["ledger_name"], cnt, mLdgrNameColumn);
						//aVoucherDetails(cnt, mMachineNoColumn) = .Fields("Country").Value
						aVoucherDetails.SetValue(rsLocalRec["Installment_No"], cnt, mIntallmentNoColumn);
						aVoucherDetails.SetValue(StringsHelper.Format(rsLocalRec["Amount"], "###,###,###,###.000"), cnt, mAmountColumn);
						aVoucherDetails.SetValue(TriState.True, cnt, mPrintedColumn);
						aVoucherDetails.SetValue(rsLocalRec["Remarks"], cnt, mRemarkColumn);
						cnt++;
					}
					while(rsLocalRec.Read());

				}


				CalculateTotals();
				grdVoucherDetails.Rebind(true);

				rsLocalRec.Close();
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{
			if (MsgId == 1)
			{
				grdVoucherDetails.Col = mLdgrCodeColumn;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsLedgerCodeList);
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
				txtCustomerName.Text = "";
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdVoucherDetails.Col)
			{
				case mLdgrCodeColumn : case mLdgrNameColumn : 

					 
					if (grdVoucherDetails.Col == mLdgrCodeColumn)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("ldgr_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsLedgerCodeList.setSort("ldgr_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("ldgr_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsLedgerCodeList.setSort("ldgr_name");
					} 
					 
					int tempForEndVar = cmbMastersList.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersList.Splits[0].DisplayColumns[cnt];
						if (cnt < 2)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == mLdgrCodeColumn) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[mLdgrCodeColumn].Width;
							}
							else
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == mLdgrCodeColumn) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[mLdgrNameColumn].Width;
							}
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							withVar.Visible = true;
							cmbMastersList.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					cmbMastersList.Width += 17; 
					cmbMastersList.Height = 167; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			switch(grdVoucherDetails.Col)
			{
				case mLdgrCodeColumn : 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					if (grdVoucherDetails.Splits[0].DisplayColumns[mLdgrNameColumn].Visible && grdVoucherDetails.Splits[0].DisplayColumns[mLdgrNameColumn].AllowFocus)
					{
						grdVoucherDetails.Col = mLdgrNameColumn;
					}
					else
					{
					} 
					 
					break;
				case mLdgrNameColumn : 
					break;
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			try
			{
				if (grdVoucherDetails.Col == mLdgrCodeColumn || grdVoucherDetails.Col == mLdgrNameColumn)
				{
					if (grdVoucherDetails.Col == mLdgrCodeColumn)
					{
						grdVoucherDetails.Columns[mLdgrNameColumn].Value = cmbMastersList.Columns[1].Value;
					}
					else
					{
						grdVoucherDetails.Columns[mLdgrCodeColumn].Value = cmbMastersList.Columns[0].Value;
					}
					grdVoucherDetails.Columns[mPrintedColumn].Value = TriState.True;
				}
			}
			catch
			{
			}

		}

		private void DefineMasterRecordset()
		{
			string mysql = "";
			if (mFirstGridFocus)
			{
				mysql = "select ldgr_no, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l.l_ldgr_name as ldgr_name" : "l.a_ldgr_name as ldgr_name");
				mysql = mysql + " , ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "gl_accnt_group.l_group_name as group_name" : "gl_accnt_group.a_group_name as group_name");
				mysql = mysql + " , current_bal, gl_currency.symbol, gl_currency.curr_cd, l.type_cd, l.ldgr_cd ";
				mysql = mysql + " , cc.cost_no, l.type_cd as type_cd ";
				mysql = mysql + " , l.default_dr_cr_type ";
				mysql = mysql + " from gl_ledger l inner join gl_accnt_group on l.group_cd = gl_accnt_group.group_cd ";
				mysql = mysql + " inner join gl_currency on l.curr_cd = gl_currency.curr_cd ";
				mysql = mysql + " left outer join gl_cost_centers cc on l.default_cost_cd = cc.cost_cd ";

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
				{
					mysql = mysql + " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
				}
				//-----------------------------------------------------------------------------------------------------------

				mysql = mysql + " where l.discontinued = 0 ";

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
				{
					mysql = mysql + " and gls.Group_Cd = " + SystemVariables.gLoggedInUserGroupCode.ToString() + " and gls.Show = 1";
				}
				//-----------------------------------------------------------------------------------------------------------

				mysql = mysql + " order by 1 ";

				rsLedgerCodeList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLedgerCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLedgerCodeList.Tables.Clear();
				adap.Fill(rsLedgerCodeList);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsLedgerCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLedgerCodeList.Requery(-1);
			}

		}
	}
}