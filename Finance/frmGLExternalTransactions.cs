
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmGLExternalTransactions
		: System.Windows.Forms.Form
	{


		
		public frmGLExternalTransactions()
{
InitializeComponent();
} 
 public  void frmGLExternalTransactions_old()
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


		private clsToolbar oThisFormToolBar = null;

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


		private const int cGLineNoColumn = 0;
		private const int cGExternalVoucherTypeColumn = 1;
		private const int cGVoucherTypeColumn = 2;
		private const int cGVoucherNoColumn = 3;
		private const int cGVoucherDateColumn = 4;
		private const int cGReferenceNoColumn = 5;
		private const int cGLdgrCodeColumn = 6;
		private const int cGCurrCdColumn = 7;
		private const int cGExchangeRateColumn = 8;
		private const int cGIsDebitColumn = 9;
		private const int cGFCAmountColumn = 10;
		private const int cGCostCenterCdColumn = 11;
		private const int cGCommentsColumn = 12;
		private const int cGInternalLineNoColumn = 13;
		private const int cGDueDateColumn = 14;
		private const int cGUploadedColumn = 15;
		private const int cGSessionUploadedNoColumn = 16;
		private const int cGSessionUploadedDateColumn = 17;
		private const int cGConvert = 18;

		private const int mMaxArrayCol = 18;
		private bool mFirstGridFocus = false;
		private int mLastCol = 0;
		private int mLastRow = 0;


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

		private void cmdShow_Click(Object eventSender, EventArgs eventArgs)
		{
			StringBuilder mysql = new StringBuilder();
			string mysqltemp = "";
			int cnt = 0;

			int mVoucherType = 0;
			int mVoucherNo = 0;
			System.DateTime mVoucherDate = DateTime.FromOADate(0);
			string mReferenceNo = "";
			double mTotalAmount = 0;

			SqlDataReader rsUnique = null;

			try
			{

				mysqltemp = "select distinct voucher_type,voucher_date,voucher_no,reference_no";
				mysqltemp = mysqltemp + " from GL_External_Accnt_Trans_Details";
				mysqltemp = mysqltemp + " where voucher_date <='" + ReflectionHelper.GetPrimitiveValue<string>(txtTransDate.Value) + "'";
				mysqltemp = mysqltemp + " and Uploaded = 0";

				SqlCommand sqlCommand = new SqlCommand(mysqltemp, SystemVariables.gConn);
				rsUnique = sqlCommand.ExecuteReader();
				rsUnique.Read();

				DataSet rsTempRec = null;
				do 
				{
					mVoucherType = Convert.ToInt32(rsUnique[0]);
					mVoucherDate = Convert.ToDateTime(rsUnique[1]);
					mVoucherNo = Convert.ToInt32(rsUnique[2]);
					mReferenceNo = Convert.ToString(rsUnique[3]);
					mTotalAmount = CalculateAmount(mVoucherType, mVoucherDate, mVoucherNo, mReferenceNo);

					mysql = new StringBuilder(" select External_Voucher_Type, Voucher_Type, Voucher_No,Voucher_Date ");
					mysql.Append(" , Reference_No, Ldgr_Cd, Curr_Cd, Exchange_Rate,Comments ");
					mysql.Append(" , Is_Debit, FC_Amount, Cost_Cd, Line_No, Due_Date");
					mysql.Append(" , Uploaded, Uploaded_Session_No, Uploaded_Session_Date");
					mysql.Append(" from GL_External_Accnt_Trans_Details");
					mysql.Append(" where Voucher_Type=" + mVoucherType.ToString());
					mysql.Append(" and Voucher_Date = '" + DateTimeHelper.ToString(mVoucherDate) + "'");
					mysql.Append(" and Voucher_No=" + mVoucherNo.ToString());
					mysql.Append(" and Reference_No='" + mReferenceNo + "'");
					mysql.Append(" and Uploaded = 0");
					mysql.Append(" order by 4");


					rsTempRec = new DataSet();
					SqlDataAdapter adap_2 = new SqlDataAdapter(mysql.ToString(), SystemVariables.gConn);
					rsTempRec.Tables.Clear();
					adap_2.Fill(rsTempRec);
					DefineVoucherArray(-1, true);

					if (rsTempRec.Tables[0].Rows.Count != 0)
					{

						DefineVoucherArray(cnt, false);

						//       Get the details information into the grid
						aVoucherDetails.SetValue(cnt, cnt, cGLineNoColumn);
						aVoucherDetails.SetValue(rsTempRec.Tables[0].Rows[0]["External_Voucher_Type"], cnt, cGExternalVoucherTypeColumn);
						aVoucherDetails.SetValue(rsTempRec.Tables[0].Rows[0]["voucher_type"], cnt, cGVoucherTypeColumn);
						aVoucherDetails.SetValue(rsTempRec.Tables[0].Rows[0]["voucher_no"], cnt, cGVoucherNoColumn);
						aVoucherDetails.SetValue(StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["Voucher_Date"], SystemVariables.gSystemDateFormat), cnt, cGVoucherDateColumn);
						aVoucherDetails.SetValue(rsTempRec.Tables[0].Rows[0]["Reference_No"], cnt, cGReferenceNoColumn);
						aVoucherDetails.SetValue(rsTempRec.Tables[0].Rows[0]["Ldgr_Cd"], cnt, cGLdgrCodeColumn);

						aVoucherDetails.SetValue(rsTempRec.Tables[0].Rows[0]["Curr_Cd"], cnt, cGCurrCdColumn);
						aVoucherDetails.SetValue(StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["Exchange_Rate"], "##0.000"), cnt, cGExchangeRateColumn);
						aVoucherDetails.SetValue((Convert.ToBoolean(rsTempRec.Tables[0].Rows[0]["Is_Debit"])) ? 1 : 0, cnt, cGIsDebitColumn);
						aVoucherDetails.SetValue(mTotalAmount, cnt, cGFCAmountColumn);
						aVoucherDetails.SetValue(rsTempRec.Tables[0].Rows[0]["Cost_Cd"], cnt, cGCostCenterCdColumn);

						aVoucherDetails.SetValue(rsTempRec.Tables[0].Rows[0]["Comments"], cnt, cGCommentsColumn);
						aVoucherDetails.SetValue(rsTempRec.Tables[0].Rows[0]["line_no"], cnt, cGInternalLineNoColumn);
						aVoucherDetails.SetValue(StringsHelper.Format(rsTempRec.Tables[0].Rows[0]["Due_Date"], SystemVariables.gSystemDateFormat), cnt, cGDueDateColumn);
						aVoucherDetails.SetValue(rsTempRec.Tables[0].Rows[0]["Uploaded"], cnt, cGUploadedColumn);
						aVoucherDetails.SetValue(rsTempRec.Tables[0].Rows[0]["Uploaded_Session_No"], cnt, cGSessionUploadedNoColumn);
						aVoucherDetails.SetValue(rsTempRec.Tables[0].Rows[0]["Uploaded_Session_Date"], cnt, cGSessionUploadedDateColumn);

						aVoucherDetails.SetValue(0, cnt, cGConvert);

						cnt++;

					}

					rsTempRec = null;
				}
				while(rsUnique.Read());
				rsUnique.Close();

				grdTransDetails.Rebind(true);
				grdTransDetails.Refresh();


				if (cnt > 0)
				{
					grdTransDetails.Focus();
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private double CalculateAmount(int pVoucherType, System.DateTime pVoucherDate, int pVoucherNo, string pReferenceNo, int pIsDebit = 1)
		{
			//''''*************************************************************************
			//'''Calculate the Total FC_Amount.
			//''''*************************************************************************

			double result = 0;
			string mysql = "";

			if (pIsDebit == 1)
			{
				mysql = "select isnull(sum(fc_amount),0) from GL_External_Accnt_Trans_Details";
				mysql = mysql + " where Voucher_Type=" + pVoucherType.ToString();
				mysql = mysql + " and Voucher_date='" + DateTimeHelper.ToString(pVoucherDate) + "'";
				mysql = mysql + " and voucher_no=" + pVoucherNo.ToString();
				mysql = mysql + " and reference_no='" + pReferenceNo + "'";
				mysql = mysql + " and is_debit=1";
				mysql = mysql + " and Uploaded =0";
			}
			else
			{
				mysql = "select isnull(sum(fc_amount),0) from GL_External_Accnt_Trans_Details";
				mysql = mysql + " where Voucher_Type=" + pVoucherType.ToString();
				mysql = mysql + " and Voucher_date='" + DateTimeHelper.ToString(pVoucherDate) + "'";
				mysql = mysql + " and voucher_no=" + pVoucherNo.ToString();
				mysql = mysql + " and reference_no='" + pReferenceNo + "'";
				mysql = mysql + " and is_debit=0";
				mysql = mysql + " and Uploaded =0";
			}
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			SqlDataAdapter TempAdapter = null;
			TempAdapter = new SqlDataAdapter();
			TempAdapter.SelectCommand = TempCommand;
			DataSet TempDataset = null;
			TempDataset = new DataSet();
			TempAdapter.Fill(TempDataset);
			DataSet rsTotalAmount = TempDataset;
			if (rsTotalAmount.Tables[0].Rows.Count != 0)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				result = Conversion.Val(Convert.ToString(rsTotalAmount.Tables[0].Rows[0][0]));
			}

			return result;
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
				//
				//If Me.ActiveControl.Name = "grdTransDetails" Or Me.ActiveControl.Name = "txtTempDate" Then
				//    If KeyCode = 13 Or KeyCode = 115 Then
				//        Exit Sub
				//    ElseIf KeyCode = 222 Then ''for "'"
				//        KeyCode = 0
				//        Exit Sub
				//    End If
				//    If Shift = 0 Then
				//        If grdTransDetails.Col = cGLedgerCode Then
				//            If GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no") = vbFalse Then
				//                If (KeyCode = 8) Or (KeyCode = 46) Or (KeyCode = 27) Then
				//                    '
				//                ElseIf (KeyCode >= 48 And KeyCode <= 57) Or (KeyCode >= 96 And KeyCode <= 105) Or (KeyCode = 190) Or (KeyCode = 110) Then
				//                    '
				//                Else
				//                    KeyCode = 0
				//                End If
				//            End If
				//        End If
				//    End If
				//End If

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
			//**--set the grid format
			this.Top = 0;
			this.Left = 0;


			//**--format & define the new toolbar
			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			//    .ShowPrintButton = True
			//    .ShowPostButton = True
			oThisFormToolBar.ShowSaveButton = true;
			oThisFormToolBar.ShowHelpButton = true;
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.DisableHelpButton = true;
			oThisFormToolBar.ShowCheckAllButton = true;
			oThisFormToolBar.ShowUncheckAllButton = true;
			this.WindowState = FormWindowState.Maximized;


			//mGridFontName = "Arial Narrow"
			string mGridFontName = "";
			int mGridFontSize = 8;

			//**--define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdTransDetails, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.4f, 1.4f, "&HB4D9F8", "&HB4D9F8", 280, 6);
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Line No", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "External Voucher Type", 1800, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", mGridFontName, false, "", mGridFontSize);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Voucher Type", 1250, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", mGridFontName, false, "", mGridFontSize);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Voucher No.", 1250, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", mGridFontName, false, "", mGridFontSize);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Voucher Date", 1250, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true, 100, "", mGridFontName, false, "", mGridFontSize);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Reference No.", 1250, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", mGridFontName, false, "", mGridFontSize);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Ledger Code", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Curr. No.", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Exchange Rate", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Is Debit", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Amount", 1250, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true, 100, "", mGridFontName, false, "", mGridFontSize);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Cost Center", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Comments", 1300, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", mGridFontName, false, "", mGridFontSize);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Internal Line No", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Due Date", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Uploaded", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Uploaded Session No.", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Uploded Session Date", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdTransDetails, "Convert", 500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, false, false, 100, "", mGridFontName, false, "", mGridFontSize);

			grdTransDetails.HoldFields();
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdTransDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdTransDetails.setArray(aVoucherDetails);


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
				frmGLExternalTransactions.DefInstance = null;
				oThisFormToolBar = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdTransDetails_BeforeColEdit(object eventSender, C1.Win.C1TrueDBGrid.BeforeColEditEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int KeyAscii = (int) eventArgs.KeyChar;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				if (ColIndex == cGConvert && Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdTransDetails.Bookmark), ColIndex)) != "")
				{
					if (KeyAscii == 0 || KeyAscii == 13 || KeyAscii == 32)
					{
						aVoucherDetails.SetValue(~Convert.ToInt32(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdTransDetails.Bookmark), ColIndex)), ReflectionHelper.GetPrimitiveValue<int>(grdTransDetails.Bookmark), ColIndex);
						grdTransDetails.UpdateData();
						grdTransDetails.Refresh();
					}
					Cancel = -1;
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdTransDetails.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdTransDetails_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			if (Col == cGConvert)
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


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdTransDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdTransDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == cGFCAmountColumn)
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

		private void grdTransDetails_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				int Col = grdTransDetails.Col;

				if (Col == cGConvert && ReflectionHelper.GetPrimitiveValue<string>(grdTransDetails.Columns[Col].Value).Trim() != "")
				{
					if (KeyAscii == 32)
					{
						KeyAscii = 0;
						grdTransDetails.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdTransDetails.Columns[Col].Value);
						grdTransDetails.UpdateData();
						grdTransDetails.Refresh();
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

		private void grdTransDetails_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float x = eventArgs.X * 15;
			float y = eventArgs.Y * 15;
			if (grdTransDetails.PointAt(x, y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
			{
				mLastCol = grdTransDetails.Col;
				mLastRow = grdTransDetails.Row;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdTransDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdTransDetails.PostMsg(2);
			}
		}

		private void DefineVoucherArray(int pMaximumRows, bool pClearArray = false)
		{
			//'''*************************************************************************
			//''Define the Vouchyer array size
			//'''*************************************************************************
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
			}
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, mMaxArrayCol}, new int[]{0, 0});

		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool saveRecord()
		{
			string mysql = "";
			object mReturnValue = null;

			int cnt = 0;
			bool mConvert = false;
			int mEntryId = 0;
			int mSessionNo = 0;

			int mDrLineNo = 0;
			int mCrLineNo = 0;
			string mDrCrType = "";
			int mLineNo = 0;
			decimal mFCAmount = 0;

			grdTransDetails.UpdateData();

			SystemVariables.gConn.BeginTransaction();
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			DataSet rsTempRec = null;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				mConvert = ((TriState) Convert.ToInt32(aVoucherDetails.GetValue(cnt, cGConvert))) == TriState.True;

				if (mConvert)
				{
					//Check for Duplicate Entry
					mysql = " select entry_id from gl_accnt_trans";
					mysql = mysql + " where voucher_type=" + Convert.ToString(aVoucherDetails.GetValue(cnt, cGVoucherTypeColumn));
					mysql = mysql + " and voucher_no=" + Convert.ToString(aVoucherDetails.GetValue(cnt, cGVoucherNoColumn));
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Duplicate Entry found!! Records cannot be saved", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}

					mysql = " insert into gl_accnt_trans (voucher_type, voucher_date, voucher_no ";
					mysql = mysql + " , reference_no, User_Cd )";
					mysql = mysql + " values ( ";
					mysql = mysql + Convert.ToString(aVoucherDetails.GetValue(cnt, cGVoucherTypeColumn)) + ", ";
					mysql = mysql + "'" + Convert.ToString(aVoucherDetails.GetValue(cnt, cGVoucherDateColumn)) + "',";
					mysql = mysql + Convert.ToString(aVoucherDetails.GetValue(cnt, cGVoucherNoColumn)) + ",";
					mysql = mysql + "'" + Convert.ToString(aVoucherDetails.GetValue(cnt, cGReferenceNoColumn)) + "'";
					mysql = mysql + " ," + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";
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
					rsTempRec = TempDataset_2;
					if (rsTempRec.Tables[0].Rows.Count != 0)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mEntryId = Convert.ToInt32(rsTempRec.Tables[0].Rows[0][0]);
					}
					else
					{
						MessageBox.Show("Error : Can not proceed with save!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}
					rsTempRec = null;

					rsTempRec = new DataSet();
					mysql = " select voucher_date, curr_cd, exchange_rate, comments, ldgr_cd, is_debit, fc_amount, cost_cd ";
					mysql = mysql + " from gl_external_accnt_trans_details ";
					mysql = mysql + " where voucher_type =" + Convert.ToString(aVoucherDetails.GetValue(cnt, cGVoucherTypeColumn));
					mysql = mysql + " and voucher_no =" + Convert.ToString(aVoucherDetails.GetValue(cnt, cGVoucherNoColumn));
					mysql = mysql + " and voucher_date ='" + Convert.ToString(aVoucherDetails.GetValue(cnt, cGVoucherDateColumn)) + "'";
					mysql = mysql + " and reference_no ='" + Convert.ToString(aVoucherDetails.GetValue(cnt, cGReferenceNoColumn)) + "'";

					SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsTempRec.Tables.Clear();
					adap.Fill(rsTempRec);
					foreach (DataRow iteration_row in rsTempRec.Tables[0].Rows)
					{
						if (Convert.ToBoolean(iteration_row["is_debit"]))
						{
							mDrLineNo++;
							mLineNo = mDrLineNo;
							mDrCrType = "D";
							mFCAmount = Convert.ToDecimal(iteration_row["fc_amount"]);
						}
						else
						{
							mCrLineNo++;
							mLineNo = mCrLineNo;
							mDrCrType = "C";
							mFCAmount = ((decimal) (Convert.ToDouble(iteration_row["fc_amount"]) * -1));
						}

						SystemFAProcedure.FAInsertGLDetailsEntry(mEntryId, Convert.ToString(iteration_row["ldgr_cd"]), Convert.ToString(iteration_row["cost_cd"]), Convert.ToDouble(iteration_row["exchange_rate"]), mFCAmount, (decimal) Math.Round((double) (Convert.ToDouble(iteration_row["exchange_rate"]) * ((double) mFCAmount)), 3), mDrCrType, Convert.ToString(iteration_row["voucher_date"]), mLineNo, 2, Convert.ToString(iteration_row["comments"]));

					}


					mSessionNo = Convert.ToInt32(Double.Parse(SystemProcedure2.GetNewNumber("GL_External_Accnt_Trans_Details", "Uploaded_Session_No")));
					mysql = "Update GL_External_Accnt_Trans_Details set Uploaded=1, Uploaded_Session_No=";
					mysql = mysql + mSessionNo.ToString() + ", Uploaded_Session_Date= getdate()";
					mysql = mysql + ", Uploaded_Entry_Id='" + mEntryId.ToString() + "'";
					mysql = mysql + " where Voucher_Type=" + Convert.ToString(aVoucherDetails.GetValue(cnt, cGVoucherTypeColumn));
					mysql = mysql + " and Voucher_No=" + Convert.ToString(aVoucherDetails.GetValue(cnt, cGVoucherNoColumn));
					mysql = mysql + " and Voucher_Date='" + Convert.ToString(aVoucherDetails.GetValue(cnt, cGVoucherDateColumn)) + "'";
					mysql = mysql + " and reference_no='" + Convert.ToString(aVoucherDetails.GetValue(cnt, cGReferenceNoColumn)) + "'";
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();
				}
			}


			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

			txtTransDate.Focus();
			return true;
		}


		public bool CheckDataValidity()
		{
			//Check validation during update and add of records

			bool result = false;
			if (!Information.IsDate(txtTransDate.Value))
			{
				MessageBox.Show("Enter valid date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtTransDate.Focus();
				return false;
			}

			//Check if Sum of Debit and Credit amounts are Matching

			double mTotalDebitAmount = 0;
			double mTotalCreditAmount = 0;
			int cnt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mTotalDebitAmount = Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, cGFCAmountColumn)));
				mTotalCreditAmount = CalculateAmount(Convert.ToInt32(aVoucherDetails.GetValue(cnt, cGVoucherTypeColumn)), Convert.ToDateTime(aVoucherDetails.GetValue(cnt, cGVoucherDateColumn)), Convert.ToInt32(aVoucherDetails.GetValue(cnt, cGVoucherNoColumn)), Convert.ToString(aVoucherDetails.GetValue(cnt, cGReferenceNoColumn)), 0);
			}

			if (mTotalDebitAmount != mTotalCreditAmount)
			{
				MessageBox.Show("Amount balances does not tally", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = false;
				grdTransDetails.Focus();
				return result;
			}

			return true;
		}


		public void AddRecord()
		{
			try
			{

				int cnt = 0;

				//'''*************************************************************************
				//''Grid settings
				int tempForEndVar = grdTransDetails.Columns.Count - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					grdTransDetails.Columns[cnt].FooterText = "";
				}
				DefineVoucherArray(-1, true);
				grdTransDetails.Rebind(true);

				SystemProcedure2.ClearTextBox(this);
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]), "AddRecord");
			}

		}

		//Private Sub grdTransDetails_RowColChange(LastRow As Variant, ByVal LastCol As Integer)
		//If grdTransDetails.Col > 0 And mFirstGridFocus = False Then
		//    '**--set the footer text to the transaction details comment
		//    '**--modified by: Moiz Hakimi
		//    '**--modified on: 10-jun-2005
		//    If Not IsNull(grdTransDetails.Bookmark) Then
		//        If Not IsNull(aVoucherDetails(grdTransDetails.Bookmark, gccAccntTransDetailsComments)) Then
		//            grdTransDetails.Columns(gccLedgerName).FooterText = aVoucherDetails(grdTransDetails.Bookmark, gccAccntTransDetailsComments)
		//        Else
		//            grdTransDetails.Columns(gccLedgerName).FooterText = ""
		//        End If
		//    End If
		//    '**--------------------------------------------------
		//End If
		//
		//End Sub

		public void LRoutine()
		{
			int cnt = 0;


			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(TriState.True, cnt, cGConvert);
			}
			grdTransDetails.Rebind(true);
		}

		public void URoutine()
		{
			int cnt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(TriState.False, cnt, cGConvert);
			}
			grdTransDetails.Rebind(true);
		}
	}
}