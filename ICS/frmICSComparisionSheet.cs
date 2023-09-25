
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmICSComparisionSheet
		: System.Windows.Forms.Form
	{

		public frmICSComparisionSheet()
{
InitializeComponent();
} 
 public  void frmICSComparisionSheet_old()
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


		private void frmICSComparisionSheet_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		int mThisFormID = 0;
		object mSearchValue = null;
		string mTimeStamp = "";

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
		private XArrayHelper aComparisionDetails = null;

		//Private mParentVoucherTimeStamp As String
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;
		private Syncfusion.WinForms.Input.SfDateTimeEdit FirstFocusObject = null;

		private DataSet rsInvntTransList = null;
		private DataSet rsICSVoucherTypesList = null;

		private const int mMaxComparisionArray = 16;

		//define the expenses grid col no.
		private const int cLN = 0;
		private const int cCostVoucherType = 1;
		private const int cCostVoucherNo = 2;
		private const int cCostVoucherAmt = 3;
		private const int cCostVoucherEntryId = 4;
		private const int cCostRemarks1 = 5;
		private const int cCostExp1 = 6;
		private const int cCostRemarks2 = 7;
		private const int cCostExp2 = 8;
		private const int cRevenueVoucherType = 9;
		private const int cRevenueVoucherNo = 10;
		private const int cRevenueVoucherAmt = 11;
		private const int cRevenueVoucherEntryId = 12;
		private const int cRevenueRemarks1 = 13;
		private const int cRevenueExp1 = 14;
		private const int cRevenueRemarks2 = 15;
		private const int cRevenueExp2 = 16;


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


		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//If LCase(Me.ActiveControl.Name) = LCase("grdVoucherDetails") Then
				//    If KeyCode = 13 Or KeyCode = 115 Then
				//        Exit Sub
				//    ElseIf KeyCode = 222 Then ''for "'"
				//        KeyCode = 0
				//        Exit Sub
				//    End If
				//    If Shift = 0 Then
				if (grdComparisionDetails.Col == cCostVoucherAmt || grdComparisionDetails.Col == cCostExp1 || grdComparisionDetails.Col == cCostExp2 || grdComparisionDetails.Col == cRevenueVoucherAmt || grdComparisionDetails.Col == cRevenueExp1 || grdComparisionDetails.Col == cRevenueExp2)
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
				//    End If
				//End If

				//on keydown navigate the form by using enter key
				if (KeyCode == 13)
				{ //if enter key pressed send a tab key
					SendKeys.Send("{tab}");
					return;
				}

				if (this.ActiveControl.Name != "txtCommonTextBox")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommonTextBox#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
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
			DataSet rsTempRec = null;
			string mysql = "";

			try
			{

				this.Top = 0;
				this.Left = 0;


				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				//.ShowInsertLineButton = True
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				//With txtTempDate
				SystemGrid.DefineSystemVoucherGrid(grdComparisionDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2.2f, 1.4f, "&HDCE2DC", "&HDCE2DC");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "Voucher Type", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMasterList");
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "Voucher No.", 1250, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, " Total  ", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMasterList");
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "Voucher Amt.", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "Voucher Entry Id", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "Remarks 1", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 100);
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "Expenses1 Amt.", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "Remarks 2", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 100);
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "Expenses2 Amt.", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "Voucher Type", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMasterList");
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "Voucher No.", 1250, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMasterList");
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "Voucher Amt.", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "Voucher Entry Id", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "Remarks 1", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 100);
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "Expenses1 Amt.", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "Remarks 2", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 100);
				SystemGrid.DefineSystemVoucherGridColumn(grdComparisionDetails, "Expenses2 Amt.", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, true, false, true);


				SystemGrid.DefineSystemGridCombo(cmbMasterList);
				cmbMasterList.Width = 267;
				cmbMasterList.Height = 133;

				//setting voucher details grid properties
				aComparisionDetails = new XArrayHelper();
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aComparisionDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aComparisionDetails.Clear();
				aComparisionDetails.RedimXArray(new int[]{0, mMaxComparisionArray}, new int[]{0, 0});
				aComparisionDetails.SetValue(1, 0, 0);
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdComparisionDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdComparisionDetails.setArray(aComparisionDetails);


				rsInvntTransList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsInvntTransList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsInvntTransList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());

				CalculateTotals(0, 0);
				grdComparisionDetails.Rebind(true);

				txtVoucherDate.Value = DateTime.Today;
				FirstFocusObject = txtVoucherDate;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}

		}


		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;

				aComparisionDetails = null;
				//Set rsDrList = Nothing
				rsInvntTransList = null;
				rsICSVoucherTypesList = null;

				oThisFormToolBar = null;
				frmICSComparisionSheet.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}


		//Private Sub grdVoucherDetails_AfterColUpdate(ByVal ColIndex As Integer)
		//grdVoucherDetails.Update
		//
		//Dim mCurrentRow As Integer
		//mCurrentRow = grdVoucherDetails.Row
		//Select Case ColIndex
		//    Case grdComparisionDetails
		//        Call CalculateTotals1(CInt(mCurrentRow), ColIndex)
		//End Select
		//End Sub

		//Private Sub txtCommonTextBox_LostFocus(Index As Integer)
		//Dim mysql As String
		//Dim mTempReturnValue As Variant
		//Dim mSetValueIndex As Integer
		//
		//If gSkipTextBoxLostFocus = True Then
		//    Exit Sub
		//End If
		//
		//On Error GoTo eFoundError
		//
		//Select Case Index
		//    Case tcImportLocationCode
		//        mysql = "select " & IIf(gPreferedLanguage = English, "l_locat_name", "a_locat_name")
		//        mysql = mysql & ",'' from SM_Location where locat_no = " & txtCommonTextBox(Index).Text
		//
		//        mSetValueIndex = tcImportLocationCode
		//    Case tcImportVoucherType
		//'            mSetValueIndex = -1
		//    Case tcImportVoucherNo
		//        mysql = " select voucher_no from ICS_Transaction mt "
		//        mysql = mysql & " inner join SM_Location on mt.locat_cd = SM_Location.locat_cd "
		//        mysql = mysql & " where mt.voucher_type=" & txtCommonTextBox(tcImportVoucherType).Text
		//        mysql = mysql & " and mt.expenses_amt = 0 "
		//        mysql = mysql & " and mt.status = 2 "
		//        mysql = mysql & " and mt.posted_gl = 0 "
		//        mysql = mysql & " and mt.posted_gl_expense = 0 "
		//        mysql = mysql & " and mt.voucher_no = " & txtCommonTextBox(tcImportVoucherNo).Text
		//        mysql = mysql & " and SM_Location.locat_no = " & txtCommonTextBox(tcImportLocationCode).Text
		//
		//        mSetValueIndex = -2
		//    Case Else
		//        mSetValueIndex = 0
		//End Select
		//
		//If mSetValueIndex > 0 Then
		//    If Not IsItEmpty(txtCommonTextBox(Index).Text, StringType) Then
		//        mTempReturnValue = GetMasterCode(mysql)
		//        If IsNull(mTempReturnValue) Then
		//            If Index = tcImportLocationCode Then
		//                txtCommonTextBox(tcImportVoucherNo).Text = ""
		//                txtCommonTextBox(tcImportVoucherNo).Enabled = False
		//            Else
		//                '.txtDisplayLabel(mSetValueIndex).Text = ""
		//            End If
		//
		//            Err.Raise -9990002
		//        Else
		//            If Index = tcImportLocationCode Then
		//                If CurrentFormMode = frmAddMode Then
		//                    txtCommonTextBox(tcImportVoucherNo).Enabled = True
		//                    'If Me.ActiveControl.Name = "txtVoucherDate" Then
		//                        'txtCommonTextBox(tcImportVoucherNo).SetFocus
		//                    'End If
		//                End If
		//            Else
		//                '.txtDisplayLabel(mSetValueIndex).Text = mTempReturnValue(0)
		//            End If
		//        End If
		//    Else
		//        '.txtDisplayLabel(mSetValueIndex).Text = ""
		//        If Index = tcImportLocationCode Then
		//            txtCommonTextBox(tcImportVoucherNo).Enabled = False
		//        End If
		//    End If
		//ElseIf mSetValueIndex = -1 Then
		//    '''Nothing
		//ElseIf mSetValueIndex = -2 Then
		//    If Not IsItEmpty(txtCommonTextBox(Index).Text, NumberType) Then
		//        mTempReturnValue = GetMasterCode(mysql)
		//        If Not IsNull(mTempReturnValue) Then
		//            If GetLinkedVoucherDetails() = False Then
		//                Err.Raise -9990002
		//            Else
		//                txtCommonTextBox(tcImportLocationCode).Enabled = False
		//                txtCommonTextBox(tcImportVoucherNo).Enabled = False
		//                'Call TextBoxLostFocus(pForm, tcLedgerCode, pclsICSTransaction)
		//            End If
		//        Else
		//            Err.Raise -9990002
		//        End If
		//    End If
		//End If
		//
		//
		//Exit Sub
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
		//    'if the code is not found
		//    If txtCommonTextBox(Index).Enabled = True Then
		//       txtCommonTextBox(Index).SetFocus
		//    End If
		//Else
		//    '
		//End If
		//
		//End Sub

		//Private Sub txtCommonTextBox_DropButtonClick(Index As Integer)
		//Call FindRoutine("txtCommonTextBox#" + Trim(Index))
		//End Sub

		public void GetRecord(object pSearchValue)
		{


			if (SystemProcedure2.IsItEmpty(pSearchValue, SystemVariables.DataType.NumberType))
			{
				return;
			}

			string mysql = " select * ";
			mysql = mysql + " from ics_margin_sheet ";
			mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

			SqlDataReader rsLocalRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			if (rsLocalRec.Read())
			{
				CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				SearchValue = rsLocalRec["entry_id"];
				mTimeStamp = SystemProcedure2.tsFormat(Convert.ToString(rsLocalRec["time_stamp"]));

				//Set the form caption and Get the Voucher Status
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, Convert.ToInt32(rsLocalRec["status"]), CurrentFormMode, "ICS Comparision Sheet", "");
				//''''*************************************************************************

				txtTransactionNo.Text = Convert.ToString(rsLocalRec["trans_no"]);
				txtVoucherDate.Value = rsLocalRec["trans_date"];
				txtComments.Text = Convert.ToString(rsLocalRec["comments"]) + "";

				GetComparisionDetails(Convert.ToInt32(rsLocalRec["entry_id"]));
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		private void grdVoucherDetails_FormatText(int ColIndex, ref string Value, object Bookmark)
		{
			//--handle Null value error ---> when there is no ICS_Item in the
			//--system & the drop-down ICS_Item list combo is click
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				switch(ColIndex)
				{
					case cCostVoucherAmt : case cCostExp1 : case cCostExp2 : case cRevenueVoucherAmt : case cRevenueExp1 : case cRevenueExp2 : 
						if (Conversion.Val(Value) != 0)
						{
							Value = StringsHelper.Format(Conversion.Val(Value), "###,###,###,###,##0.000");
						}
						else
						{
							Value = "";
						} 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void CalculateTotals(int mRowNumber, int mColNumber)
		{
			int Cnt = 0;

			decimal mCostAmt = 0;
			decimal mCostExp1 = 0;
			decimal mCostExp2 = 0;
			decimal mRevenueAmt = 0;
			decimal mRevenueExp1 = 0;
			decimal mRevenueExp2 = 0;
			//grdComparisionDetails.Update
			int tempForEndVar = aComparisionDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				if (SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cCostVoucherAmt), SystemVariables.DataType.NumberType))
				{
					aComparisionDetails.SetValue("", Cnt, cCostVoucherAmt);
				}
				mCostAmt += ((decimal) Conversion.Val(StringsHelper.Format(aComparisionDetails.GetValue(Cnt, cCostVoucherAmt), "###############.######")));

				if (SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cCostExp1), SystemVariables.DataType.NumberType))
				{
					aComparisionDetails.SetValue("", Cnt, cCostExp1);
				}
				mCostExp1 += ((decimal) Conversion.Val(StringsHelper.Format(aComparisionDetails.GetValue(Cnt, cCostExp1), "###############.######")));

				if (SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cCostExp2), SystemVariables.DataType.NumberType))
				{
					aComparisionDetails.SetValue("", Cnt, cCostExp2);
				}
				mCostExp2 += ((decimal) Conversion.Val(StringsHelper.Format(aComparisionDetails.GetValue(Cnt, cCostExp2), "###############.######")));

				if (SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cRevenueVoucherAmt), SystemVariables.DataType.NumberType))
				{
					aComparisionDetails.SetValue("", Cnt, cRevenueVoucherAmt);
				}
				mRevenueAmt += ((decimal) Conversion.Val(StringsHelper.Format(aComparisionDetails.GetValue(Cnt, cRevenueVoucherAmt), "###############.######")));

				if (SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cRevenueExp1), SystemVariables.DataType.NumberType))
				{
					aComparisionDetails.SetValue("", Cnt, cRevenueExp1);
				}
				mRevenueExp1 += ((decimal) Conversion.Val(StringsHelper.Format(aComparisionDetails.GetValue(Cnt, cRevenueExp1), "###############.######")));

				if (SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cRevenueExp2), SystemVariables.DataType.NumberType))
				{
					aComparisionDetails.SetValue("", Cnt, cRevenueExp2);
				}
				mRevenueExp2 += ((decimal) Conversion.Val(StringsHelper.Format(aComparisionDetails.GetValue(Cnt, cRevenueExp2), "###############.######")));

			}

			if (!SystemProcedure2.IsItEmpty(mCostAmt, SystemVariables.DataType.NumberType))
			{
				grdComparisionDetails.Columns[cCostVoucherAmt].FooterText = StringsHelper.Format(mCostAmt, "###,###,###.000");
			}
			else
			{
				grdComparisionDetails.Columns[cCostVoucherAmt].FooterText = "";
			}

			if (!SystemProcedure2.IsItEmpty(mCostExp1, SystemVariables.DataType.NumberType))
			{
				grdComparisionDetails.Columns[cCostExp1].FooterText = StringsHelper.Format(mCostExp1, "###,###,###.000");
			}
			else
			{
				grdComparisionDetails.Columns[cCostExp1].FooterText = "";
			}

			if (!SystemProcedure2.IsItEmpty(mCostExp2, SystemVariables.DataType.NumberType))
			{
				grdComparisionDetails.Columns[cCostExp2].FooterText = StringsHelper.Format(mCostExp2, "###,###,###.000");
			}
			else
			{
				grdComparisionDetails.Columns[cCostExp2].FooterText = "";
			}


			if (!SystemProcedure2.IsItEmpty(mRevenueAmt, SystemVariables.DataType.NumberType))
			{
				grdComparisionDetails.Columns[cRevenueVoucherAmt].FooterText = StringsHelper.Format(mRevenueAmt, "###,###,###.000");
			}
			else
			{
				grdComparisionDetails.Columns[cRevenueVoucherAmt].FooterText = "";
			}

			if (!SystemProcedure2.IsItEmpty(mRevenueExp1, SystemVariables.DataType.NumberType))
			{
				grdComparisionDetails.Columns[cRevenueExp1].FooterText = StringsHelper.Format(mRevenueExp1, "###,###,###.000");
			}
			else
			{
				grdComparisionDetails.Columns[cRevenueExp1].FooterText = "";
			}

			if (!SystemProcedure2.IsItEmpty(mRevenueExp2, SystemVariables.DataType.NumberType))
			{
				grdComparisionDetails.Columns[cRevenueExp2].FooterText = StringsHelper.Format(mRevenueExp2, "###,###,###.000");
			}
			else
			{
				grdComparisionDetails.Columns[cRevenueExp2].FooterText = "";
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMasterList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMasterList_DataSourceChanged()
		{
			int Cnt = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_3 = null;
			switch(grdComparisionDetails.Col)
			{
				case cCostVoucherNo : case cRevenueVoucherNo : 
					 
					//If grdComparisionDetails.Col = cCostVoucherNo Then 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMasterList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMasterList.setListField("voucher_no"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsInvntTransList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsInvntTransList.setSort("voucher_no"); 
					//End If 
					 
					cmbMasterList.Width = 0; 
					int tempForEndVar = cmbMasterList.Columns.Count - 1; 
					for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMasterList.Splits[0].DisplayColumns[Cnt];
						if (Cnt < 4)
						{
							if (Cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder(0); //IIf(grdComparisionDetails.Col = cCostVoucherNo, 0, 1)
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdComparisionDetails.Splits[0].DisplayColumns[cCostVoucherNo].Width;
							}
							else if (Cnt == 1)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdComparisionDetails.Splits[0].DisplayColumns[cCostVoucherNo].Width;
							}
							else if (Cnt == 2)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdComparisionDetails.Splits[0].DisplayColumns[cCostVoucherNo].Width;
							}
							else if (Cnt == 3)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdComparisionDetails.Splits[0].DisplayColumns[cCostVoucherAmt].Width;
							}
							withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							withVar.Visible = true;
							cmbMasterList.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					cmbMasterList.Width += 17; 
					cmbMasterList.Height = 167; 
					 
					break;
				case cCostVoucherType : case cRevenueVoucherType : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMasterList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMasterList.setListField("voucher_type"); 
					 
					cmbMasterList.Width = 0; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar_2 = cmbMasterList.Splits[0].DisplayColumns[0]; 
					withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar_2.Width = grdComparisionDetails.Splits[0].DisplayColumns[cCostVoucherType].Width; 
					cmbMasterList.Width += withVar_2.Width / 15; 
					 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar_3 = cmbMasterList.Splits[0].DisplayColumns[1]; 
					withVar_3.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar_3.Width = grdComparisionDetails.Splits[0].DisplayColumns[cCostVoucherType].Width + 100; 
					cmbMasterList.Width = cmbMasterList.Width + withVar_3.Width / 15 + 7; 
					 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMasterList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMasterList_RowChange()
		{
			int mReturnValue = 0;

			if (grdComparisionDetails.Col == cCostVoucherNo)
			{
				grdComparisionDetails.Columns[cCostVoucherAmt].Value = cmbMasterList.Columns[3].Value;
				grdComparisionDetails.Columns[cCostVoucherEntryId].Value = cmbMasterList.Columns[5].Value;
			}
			else if (grdComparisionDetails.Col == cRevenueVoucherNo)
			{ 
				grdComparisionDetails.Columns[cRevenueVoucherAmt].Value = cmbMasterList.Columns[3].Value;
				grdComparisionDetails.Columns[cRevenueVoucherEntryId].Value = cmbMasterList.Columns[5].Value;
			}

		}

		private void grdComparisionDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			grdComparisionDetails.UpdateData();
			CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdComparisionDetails.Bookmark), ColIndex);
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdComparisionDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdComparisionDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == cCostVoucherAmt || ColIndex == cCostExp1 || ColIndex == cCostExp2 || ColIndex == cRevenueVoucherAmt || ColIndex == cRevenueExp1 || ColIndex == cRevenueExp2)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###,###,###.000");
				}
				else
				{
					Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "0.000");
				}
			}

		}

		private void grdComparisionDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			//Check for tag value of the column and fill the listbox accordingly
			if (SystemProcedure2.IsItEmpty(Convert.ToString(grdComparisionDetails.Tag), SystemVariables.DataType.StringType))
			{
				grdComparisionDetails.Tag = "1";

				SetList();
				cmbMasterList_RowChange(cmbMasterList, new EventArgs());
			}

			grdComparisionDetails.Col = 1;
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdComparisionDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdComparisionDetails_OnAddNew()
		{
			grdComparisionDetails.Columns[cLN].Text = (grdComparisionDetails.RowCount + 1).ToString();

		}

		private int CheckCurrency(int pDrCr, object pLdgrNo, int pRowNo = -1)
		{
			//'0=Not found
			//'1=Base currency
			//'2=Foreign Currency
			//
			//Dim rsCloneRecordset As adodb.Recordset
			//Dim mysql As String
			//Dim mReturnValue As Variant
			//
			//If IsItEmpty(pLdgrNo, StringType) Then
			//    CheckCurrency = 0
			//    Exit Function
			//End If
			//
			//If pRowNo = -1 Then
			//
			//'    If pDrCr = 1 Then
			//'        Set rsCloneRecordset = rsDrList.Clone
			//'    Else
			//        Set rsCloneRecordset = rsInvntTransList.Clone
			//'    End If
			//
			//    With rsCloneRecordset
			//        .MoveFirst
			//        .Find "ldgr_no='" & Trim(pLdgrNo) & "'"
			//        If Not .EOF Or .BOF Then
			//            If .Fields("curr_cd").Value = gDefaultCurrencyCd Then
			//                CheckCurrency = 1
			//            Else
			//                CheckCurrency = 2
			//            End If
			//        Else
			//            CheckCurrency = 0
			//        End If
			//    End With
			//Else
			//    mysql = "select curr_cd from gl_ledger "
			//    mysql = mysql & " where ldgr_no='" & pLdgrNo & "'"
			//
			//'    If Trim(aComparisionDetails(pRowNo, cTransactionType)) = "Cash" Then
			//''        mySql = mySql & " and (ldgr_type='B-CH' "
			//''        mySql = mySql & " or ldgr_type='B-BA')"
			//'        mySql = mySql & " and ( gl_ledger.type_cd =" & gGLCashTypeCode
			//'        mySql = mySql & " or gl_ledger.type_cd =" & gGLBankTypeCode & ")"
			//'    Else
			//        mysql = mysql & " and gl_ledger.type_cd <> " & gGLCashTypeCode
			//        mysql = mysql & " and gl_ledger.type_cd <> " & gGLBankTypeCode
			//        'mySql = mySql & " and ldgr_type <> 'F-BO' "
			//'    End If
			//
			//    mReturnValue = GetMasterCode(mysql)
			//    If Not IsNull(mReturnValue) Then
			//        If mReturnValue = gDefaultCurrencyCd Then
			//            CheckCurrency = 1
			//        Else
			//            CheckCurrency = 2
			//        End If
			//    Else
			//        CheckCurrency = 0
			//    End If
			//End If
			return 0;
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdComparisionDetails")
			{
				grdComparisionDetails.Focus();
			}

			if (aComparisionDetails.GetLength(0) > 0)
			{
				grdComparisionDetails.Delete();
				AssignGridLineNumbers();
				grdComparisionDetails.Rebind(true);
				grdComparisionDetails.Focus();
				CalculateTotals(0, 1);
				grdComparisionDetails.Refresh();
			}
		}

		private void grdComparisionDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			string mFilterCondition = "";
			//
			//If grdComparisionDetails.Col = cCostVoucherType Then
			//    Call SetList
			//End If

			switch(grdComparisionDetails.Col)
			{
				case cCostVoucherType : case cRevenueVoucherType : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMasterList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMasterList.setDataSource((msdatasrc.DataSource) rsICSVoucherTypesList); 
					break;
				case cCostVoucherNo : case cRevenueVoucherNo : 
					 
					if (grdComparisionDetails.Col == cCostVoucherNo)
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdComparisionDetails.Columns[cCostVoucherType].Value) != "")
						{
							//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							rsInvntTransList.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
							mFilterCondition = " voucher_type = " + ReflectionHelper.GetPrimitiveValue<string>(grdComparisionDetails.Columns[cCostVoucherType].Value).Trim();
							rsInvntTransList.Tables[0].DefaultView.RowFilter = mFilterCondition;
						}
						else
						{
							rsInvntTransList.Tables[0].DefaultView.RowFilter = " voucher_type = 0";
						}
					} 
					 
					if (grdComparisionDetails.Col == cRevenueVoucherNo)
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdComparisionDetails.Columns[cRevenueVoucherType].Value) != "")
						{

							//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							rsInvntTransList.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
							mFilterCondition = " voucher_type = " + ReflectionHelper.GetPrimitiveValue<string>(grdComparisionDetails.Columns[cRevenueVoucherType].Value).Trim();
							rsInvntTransList.Tables[0].DefaultView.RowFilter = mFilterCondition;
						}
						else
						{
							rsInvntTransList.Tables[0].DefaultView.RowFilter = " voucher_type = 0";
						}
					} 
					 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMasterList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMasterList.setDataSource((msdatasrc.DataSource) rsInvntTransList); 
					break;
			}

		}

		private void SetList()
		{


			string mysql = "select ivt.voucher_type , ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "ivt.L_voucher_name," : "ivt.A_voucher_name,");
			mysql = mysql + " ivt.voucher_type from ICS_Transaction_Types ivt ";
			mysql = mysql + " where ivt.show=1 ";
			mysql = mysql + " order by 1 ";

			rsICSVoucherTypesList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsICSVoucherTypesList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsICSVoucherTypesList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsICSVoucherTypesList.Tables.Clear();
			adap.Fill(rsICSVoucherTypesList);

			mysql = " select mt.voucher_no, l.locat_no, mt.voucher_date, mt.net_amt_lc, mt.voucher_type, mt.entry_id ";
			mysql = mysql + " from ICS_Transaction mt ";
			mysql = mysql + " inner join SM_Location l on mt.locat_cd = l.locat_cd ";
			//mySql = mySql & " order by 1 "

			rsInvntTransList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsInvntTransList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsInvntTransList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsInvntTransList.Tables.Clear();
			adap_2.Fill(rsInvntTransList);

		}

		public bool CheckDataValidity()
		{
			int Cnt = 0;

			grdComparisionDetails.UpdateData();

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 2);
				if (FirstFocusObject.Enabled)
				{
					FirstFocusObject.Focus();
				}
				goto mend;
			}

			if (SystemProcedure2.IsItEmpty(txtVoucherDate.Value, SystemVariables.DataType.DateType))
			{
				MessageBox.Show("Enter voucher date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (txtVoucherDate.Enabled)
				{
					txtVoucherDate.Focus();
				}
			}

			int tempForEndVar = aComparisionDetails.GetUpperBound(0);
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				//
				//    If IsItEmpty(aComparisionDetails(cnt, cCostVoucherType), NumberType) Then
				//        MsgBox "Invalid Cost Voucher Type", vbInformation
				//        grdComparisionDetails.Col = cCostVoucherType
				//        GoTo mGridFocus
				//    End If
				//
				//
				//    If IsItEmpty(aComparisionDetails(cnt, cCostVoucherNo), NumberType) Then
				//        MsgBox "Invalid Cost Voucher No.", vbInformation
				//        grdComparisionDetails.Col = cCostVoucherNo
				//        GoTo mGridFocus
				//    End If

				if (!SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cCostVoucherType), SystemVariables.DataType.NumberType) || !SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cCostVoucherNo), SystemVariables.DataType.NumberType))
				{
					if (SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cCostVoucherEntryId), SystemVariables.DataType.NumberType))
					{
						MessageBox.Show("Invalid Cost Voucher No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdComparisionDetails.Bookmark = Cnt;
						grdComparisionDetails.Col = cCostVoucherNo;
						goto mGridFocus;
					}
				}

				//    If IsItEmpty(aComparisionDetails(cnt, cRevenueVoucherType), NumberType) Then
				//        MsgBox "Invalid Revenue Voucher Type", vbInformation
				//        grdComparisionDetails.Col = cRevenueVoucherType
				//        GoTo mGridFocus
				//    End If
				//
				//    If IsItEmpty(aComparisionDetails(cnt, cRevenueVoucherNo), NumberType) Then
				//        MsgBox "Invalid Revenue Voucher No.", vbInformation
				//        grdComparisionDetails.Col = cRevenueVoucherNo
				//        GoTo mGridFocus
				//    End If

				if (!SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cRevenueVoucherType), SystemVariables.DataType.NumberType) || !SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cRevenueVoucherNo), SystemVariables.DataType.NumberType))
				{
					if (SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cRevenueVoucherEntryId), SystemVariables.DataType.NumberType))
					{
						MessageBox.Show("Invalid Revenue Voucher No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdComparisionDetails.Bookmark = Cnt;
						grdComparisionDetails.Col = cRevenueVoucherNo;
						goto mGridFocus;
					}
				}
			}



			return true;

			mGridFocus:
			grdComparisionDetails.Bookmark = Cnt;
			grdComparisionDetails.Focus();
			grdComparisionDetails.Rebind(true);
			goto mend;
			return false;

			mend:
			return false;
		}


		public bool saveRecord(bool pApprove = false)
		{
			bool result = false;
			string mysql = "";
			int mNewEntryID = 0;
			object mReturnValue = null;

			clsHourGlass myHourGlass = new clsHourGlass();


			//On Error GoTo eFoundError


			SystemVariables.gConn.BeginTransaction();

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{

				//''''****************************************************************************
				//I '''''''''''''N'''''''''''''S'''''''''''''E'''''''''''''R'''''''''''T
				//''''****************************************************************************

				txtTransactionNo.Text = SystemProcedure2.GetNewNumber("ics_margin_sheet", "trans_no");


				//''''***************Insert into the master table*****************************
				mNewEntryID = InsertMasterRecord(Convert.ToInt32(Double.Parse(txtTransactionNo.Text)));
				//''''************************************************************************

				//''''***************Insert into the details table*****************************
				InsertDetailRecord(mNewEntryID);
				//''''************************************************************************
			}
			else
			{


				//''''****************************************************************************
				//U '''''''''''''P'''''''''''''D'''''''''''''A'''''''''''''T'''''''''''E
				//''''****************************************************************************

				//''''*********************Make the mNewEntryID = Searchvalue so that the same
				//'''Variable can be user for both add and edit mode
				//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mNewEntryID = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
				//''''*************************************************************************


				//''''*********************Check the Master table TimeStamp *******************
				mysql = " select time_stamp from ics_margin_sheet ";
				mysql = mysql + " where entry_id=" + Conversion.Str(mNewEntryID);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//if the time stamp does not match the previous one then rollback
				if (SystemProcedure2.tsFormat(ReflectionHelper.GetPrimitiveValue<string>(mReturnValue)) != mTimeStamp)
				{
					MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					goto StationRollBackTrans;
				}
				//''''*************************************************************************

				//''''************************update the sales table****************************
				UpdateMasterRecord(mNewEntryID);
				//''''*************************************************************************

				mysql = " delete from ics_margin_sheet_details ";
				mysql = mysql + " where entry_id=" + Conversion.Str(mNewEntryID);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//''''***************Insert into the details table*****************************
				if (!InsertDetailRecord(mNewEntryID))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}
				//''''************************************************************************

			}


			//''''*************************************************************************
			//Approve (Change the status to 2)
			if (pApprove)
			{
				SystemICSProcedure.ApproveTransaction("ics_margin_sheet", mNewEntryID);
				//Call PostParentExpenses
			}
			//''''*************************************************************************

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();



			//''''*************************************************************************
			//Display a messbox if the auto generate voucher no is true and it is in addmode
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				mysql = SystemConstants.msg20 + txtTransactionNo.Text;
				MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}


			return true;


			//''''*************************************************************************

			//This code is executed when there is error before begin trans
			return false;
			//''''*************************************************************************


			//''''*************************************************************************
			StationRollBackTrans:
			//This code is executed when there is error after begin trans
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			return result;
			//''''*************************************************************************


			//''''*************************************************************************
			//All other Errors.

			int mReturnErrorType = 0;

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_table_Name"]), "GetRecord", SystemConstants.msg10);
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			if (mReturnErrorType == 1)
			{
				return false;
			}
			else if (mReturnErrorType == 2)
			{ 
				AddRecord();
				return false;
			}
			else if (mReturnErrorType == 3)
			{ 
				AddRecord();
				return false;
			}
			else
			{
				return false;
			}
		}

		private int InsertMasterRecord(int pTransactionNo)
		{

			string mysql = " insert into ics_margin_sheet ";
			mysql = mysql + " ( trans_no, trans_date, comments, status, user_cd ) ";
			mysql = mysql + " values(";
			mysql = mysql + " " + pTransactionNo.ToString();
			mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
			mysql = mysql + " ,N'" + txtComments.Text + "'";
			mysql = mysql + " ,1 ";
			mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
			mysql = mysql + " )";

			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			return ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));

		}

		private object UpdateMasterRecord(int pEntryId)
		{

			string mysql = " update ics_margin_sheet ";
			mysql = mysql + " set ";
			mysql = mysql + " trans_no =" + txtTransactionNo.Text;
			mysql = mysql + " , trans_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
			mysql = mysql + " , comments =N'" + txtComments.Text + "'";
			mysql = mysql + " , user_cd =" + SystemVariables.gLoggedInUserCode.ToString();
			mysql = mysql + " where entry_id =" + pEntryId.ToString();

			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();


			return null;
		}


		private bool InsertDetailRecord(int pEntryId)
		{
			string mysql = "";
			int Cnt = 0;
			object mReturnValue = null;
			int mCostEntryId = 0;
			int mRevenueEntryId = 0;

			int tempForEndVar = aComparisionDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{

				//'''****************************Get the Cost Voucher Entry Id***********************
				//''''****************************************************************************
				if (!SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cCostVoucherType), SystemVariables.DataType.NumberType) && !SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cCostVoucherNo), SystemVariables.DataType.NumberType))
				{
					mysql = " select entry_id from ICS_Transaction mt ";
					mysql = mysql + " where entry_id = " + Convert.ToString(aComparisionDetails.GetValue(Cnt, cCostVoucherEntryId));
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Enter valid Cost Voucher Typoe ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdComparisionDetails.Bookmark = Cnt;
						grdComparisionDetails.Focus();
						return false;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCostEntryId = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				else
				{
					mCostEntryId = 0;
				}

				//'''****************************Get the Revenue Voucher Entry Id***********************
				//''''****************************************************************************
				if (!SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cRevenueVoucherType), SystemVariables.DataType.NumberType) && !SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cRevenueVoucherNo), SystemVariables.DataType.NumberType))
				{
					mysql = " select mt.entry_id from ICS_Transaction mt ";
					mysql = mysql + " where mt.entry_id = " + Convert.ToString(aComparisionDetails.GetValue(Cnt, cRevenueVoucherEntryId));
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Enter valid Revenue Voucher Typoe ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdComparisionDetails.Bookmark = Cnt;
						grdComparisionDetails.Focus();
						return false;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mRevenueEntryId = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				else
				{
					mRevenueEntryId = 0;
				}

				mysql = " insert into ics_margin_sheet_details";
				mysql = mysql + " (entry_id, compare_1_entry_id, compare_1_expenses_1_amt, compare_1_expenses_1_remarks ";
				mysql = mysql + " , compare_1_expenses_2_amt, compare_1_expenses_2_remarks";
				mysql = mysql + " , compare_2_entry_id, compare_2_expenses_1_amt, compare_2_expenses_1_remarks";
				mysql = mysql + " , compare_2_expenses_2_amt, compare_2_expenses_2_remarks ";
				mysql = mysql + " ) ";
				mysql = mysql + " values( ";
				mysql = mysql + pEntryId.ToString();
				if (mCostEntryId != 0)
				{
					mysql = mysql + " , " + mCostEntryId.ToString();
				}
				else
				{
					mysql = mysql + " , null ";
				}

				if (!SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cCostExp1), SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " , " + Convert.ToString(aComparisionDetails.GetValue(Cnt, cCostExp1));
				}
				else
				{
					mysql = mysql + " , 0 ";
				}
				mysql = mysql + " , '" + Convert.ToString(aComparisionDetails.GetValue(Cnt, cCostRemarks1)) + "'";

				if (!SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cCostExp2), SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " , " + Convert.ToString(aComparisionDetails.GetValue(Cnt, cCostExp2));
				}
				else
				{
					mysql = mysql + " , 0 ";
				}
				mysql = mysql + " , '" + Convert.ToString(aComparisionDetails.GetValue(Cnt, cCostRemarks2)) + "'";

				if (mRevenueEntryId != 0)
				{
					mysql = mysql + " , " + mRevenueEntryId.ToString();
				}
				else
				{
					mysql = mysql + " , null ";
				}

				if (!SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cRevenueExp1), SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " , " + Convert.ToString(aComparisionDetails.GetValue(Cnt, cRevenueExp1));
				}
				else
				{
					mysql = mysql + " , 0 ";
				}
				mysql = mysql + " , '" + Convert.ToString(aComparisionDetails.GetValue(Cnt, cRevenueRemarks1)) + "'";

				if (!SystemProcedure2.IsItEmpty(aComparisionDetails.GetValue(Cnt, cRevenueExp2), SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " , " + Convert.ToString(aComparisionDetails.GetValue(Cnt, cRevenueExp2));
				}
				else
				{
					mysql = mysql + " , 0 ";
				}
				mysql = mysql + " , '" + Convert.ToString(aComparisionDetails.GetValue(Cnt, cRevenueRemarks2)) + "'";

				mysql = mysql + " ) ";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
			}

			//''''****************************************************************************
			return true;

		}

		public void AddRecord()
		{
			try
			{

				int Cnt = 0;

				//''''*************************************************************************
				//Set the form caption
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, "Comparision Sheet", "");
				//''''*************************************************************************


				//''''*************************************************************************
				//'''Grid settings
				int tempForEndVar = grdComparisionDetails.Columns.Count - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					grdComparisionDetails.Columns[Cnt].FooterText = "";
				}


				SystemGrid.DefineVoucherArray(aComparisionDetails, mMaxComparisionArray, -1, true);

				grdComparisionDetails.Rebind(true);

				SystemProcedure2.ClearTextBox(this);
				//Call ClearNumberBox(Me)

				SearchValue = ""; //Change the msearchvalue to blank
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive; //set new voucher status to active by default


				if (FirstFocusObject.Enabled)
				{
					FirstFocusObject.Focus();
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]), "AddRecord");
			}


		}

		public void findRecord()
		{

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2008000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				Application.DoEvents();
				GetRecord(mSearchValue);
			}
		}

		private void AssignGridLineNumbers()
		{
			//''''*************************************************************************
			//'''Assign the Grid Line No
			//''''*************************************************************************

			int Cnt = 0;
			int tempForEndVar = aComparisionDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				aComparisionDetails.SetValue(Cnt + 1, Cnt, cLN);
			}
		}

		private void GetComparisionDetails(int pEntryId)
		{
			SqlDataReader localRec = null;
			int Cnt = 0;

			//If IsItEmpty(grdComparisionDetails.Tag, StringType) Then
			//    Call grdComparisionDetails_GotFocus
			//End If

			string mysql = " select  mtc.voucher_type cost_voucher_type, mtc.voucher_no cost_voucher_no, mtc.net_amt_lc cost_voucher_amt ";
			mysql = mysql + " , mtc.entry_id cost_entry_id ";
			mysql = mysql + " , mtr.voucher_type as revenue_voucher_type, mtr.voucher_no as revenue_voucher_no, mtr.net_amt_lc as revenue_voucher_amt ";
			mysql = mysql + " , mtr.entry_id revenue_entry_id ";
			mysql = mysql + " , imsd.compare_1_expenses_1_remarks cost_remarks_1 , imsd.compare_1_expenses_1_amt cost_exp_amt_1";
			mysql = mysql + " , imsd.compare_1_expenses_2_remarks cost_remarks_2, imsd.compare_1_expenses_2_amt as cost_exp_amt_2 ";
			mysql = mysql + " , imsd.compare_2_expenses_1_remarks revenue_remarks_1, imsd.compare_2_expenses_1_amt revenue_exp_amt_1 ";
			mysql = mysql + " , imsd.compare_2_expenses_2_remarks revenue_remarks_2, imsd.compare_2_expenses_2_amt revenue_exp_amt_2";
			mysql = mysql + " from ics_margin_sheet_details imsd ";
			mysql = mysql + " left outer join ICS_Transaction mtc on imsd.compare_1_entry_id = mtc.entry_id ";
			mysql = mysql + " left outer join ICS_Transaction mtr on imsd.compare_2_entry_id = mtr.entry_id ";
			mysql = mysql + " where imsd.entry_id=" + Conversion.Str(pEntryId);
			mysql = mysql + " order by imsd.line_no ";

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand.ExecuteReader();
			localRec.Read();

			do 
			{
				aComparisionDetails.RedimXArray(new int[]{Cnt, mMaxComparisionArray}, new int[]{0, 0});

				aComparisionDetails.SetValue(Cnt + 1, Cnt, cLN);

				if (!Convert.IsDBNull(localRec["cost_voucher_type"]))
				{
					aComparisionDetails.SetValue(localRec["cost_voucher_type"], Cnt, cCostVoucherType);
				}
				else
				{
					aComparisionDetails.SetValue("", Cnt, cCostVoucherType);
				}

				if (!Convert.IsDBNull(localRec["cost_voucher_no"]))
				{
					aComparisionDetails.SetValue(localRec["cost_voucher_no"], Cnt, cCostVoucherNo);
				}
				else
				{
					aComparisionDetails.SetValue("", Cnt, cCostVoucherNo);
				}

				aComparisionDetails.SetValue(localRec["cost_voucher_amt"], Cnt, cCostVoucherAmt);

				if (!Convert.IsDBNull(localRec["cost_entry_id"]))
				{
					aComparisionDetails.SetValue(localRec["cost_entry_id"], Cnt, cCostVoucherEntryId);
				}
				else
				{
					aComparisionDetails.SetValue("", Cnt, cCostVoucherEntryId);
				}

				aComparisionDetails.SetValue(localRec["cost_remarks_1"], Cnt, cCostRemarks1);
				aComparisionDetails.SetValue(localRec["cost_exp_amt_1"], Cnt, cCostExp1);
				aComparisionDetails.SetValue(localRec["cost_remarks_2"], Cnt, cCostRemarks2);
				aComparisionDetails.SetValue(localRec["cost_exp_amt_2"], Cnt, cCostExp2);

				if (!Convert.IsDBNull(localRec["revenue_voucher_type"]))
				{
					aComparisionDetails.SetValue(localRec["revenue_voucher_type"], Cnt, cRevenueVoucherType);
				}
				else
				{
					aComparisionDetails.SetValue("", Cnt, cRevenueVoucherType);
				}

				if (!Convert.IsDBNull(localRec["revenue_voucher_no"]))
				{
					aComparisionDetails.SetValue(localRec["revenue_voucher_no"], Cnt, cRevenueVoucherNo);
				}
				else
				{
					aComparisionDetails.SetValue("", Cnt, cRevenueVoucherNo);
				}

				aComparisionDetails.SetValue(localRec["revenue_voucher_amt"], Cnt, cRevenueVoucherAmt);

				if (!Convert.IsDBNull(localRec["revenue_entry_id"]))
				{
					aComparisionDetails.SetValue(localRec["revenue_entry_id"], Cnt, cRevenueVoucherEntryId);
				}
				else
				{
					aComparisionDetails.SetValue("", Cnt, cRevenueVoucherEntryId);
				}

				aComparisionDetails.SetValue(localRec["revenue_remarks_1"], Cnt, cRevenueRemarks1);
				aComparisionDetails.SetValue(localRec["revenue_exp_amt_1"], Cnt, cRevenueExp1);
				aComparisionDetails.SetValue(localRec["revenue_remarks_2"], Cnt, cRevenueRemarks2);
				aComparisionDetails.SetValue(localRec["revenue_exp_amt_2"], Cnt, cRevenueExp2);

				Cnt++;
			}
			while(localRec.Read());
			localRec.Close();

			grdComparisionDetails.Rebind(true);

			CalculateTotals(0, 0);
		}

		public bool deleteRecord()
		{
			//Delete the Record

			bool result = false;
			string mysql = "";

			try
			{

				if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
				{
					SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 1);
					result = false;
					if (FirstFocusObject.Enabled)
					{
						FirstFocusObject.Focus();
					}
					return result;
				}


				SystemVariables.gConn.BeginTransaction();
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{

					//''''*************************************************************************

					mysql = " delete from ics_margin_sheet_item_details ";
					mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mysql = " delete from ics_margin_sheet ";
					mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();


				}
				//''''*************************************************************************

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();

					int mReturnErrorType = 0;
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, "", "Deleterecord", SystemConstants.msg10);
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
			}
			return result;
		}

		public bool Post()
		{
			bool result = false;
			DialogResult ans = (DialogResult) 0;
			frmSysOnlinePosting frmTemp = frmSysOnlinePosting.CreateInstance();

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 2);
				result = false;
				if (FirstFocusObject.Enabled)
				{
					FirstFocusObject.Focus();
				}
				return result;
			}


			frmTemp.ShowDialog();

			//if the user clicks on OK button in the frmPost form
			if (frmTemp.mApprove)
			{

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
						SystemVariables.gConn.BeginTransaction();

						SystemICSProcedure.ApproveTransaction("ics_margin_sheet", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));

						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.CommitTrans();
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

		public void PrintReport()
		{
			int mEntryId = 0;

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
			}
			else
			{
				return;
			}
			SystemReports.GetCrystalReport(100060225, 2, "7477", Conversion.Str(mEntryId), false);
		}
	}
}