
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayTicketAccrualSummary
		: System.Windows.Forms.Form
	{

		public frmPayTicketAccrualSummary()
{
InitializeComponent();
} 
 public  void frmPayTicketAccrualSummary_old()
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


		private void frmPayTicketAccrualSummary_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		public Control FirstFocusObject = null;

		private clsToolbar oThisFormToolBar = null;
		private int mThisFormID = 0; //Assign the Formid for Each Form
		private string mTimeStamp = "";
		private bool mFirstGridFocus = false;
		private DataSet _rsLeaveCodeList = null;
		private DataSet rsLeaveCodeList
		{
			get
			{
				if (_rsLeaveCodeList is null)
				{
					_rsLeaveCodeList = new DataSet();
				}
				return _rsLeaveCodeList;
			}
			set
			{
				_rsLeaveCodeList = value;
			}
		}

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

		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		private double mLeaveSalary = 0;

		private const int grdLineNoColumn = 0;
		private const int grdTicketYearColumn = 1;
		private const int grdTicketMonthColumn = 2;
		//Private Const grdIndemnityMonthDaysColumn As Integer = 3
		private const int grdTicketAccruedColumn = 3;
		private const int grdTicketAvailedColumn = 4;
		private const int grdTicketAdjustmentColumn = 5;
		private const int grdCurrAccruAmtColumn = 6;
		private const int grdCummAccruedTicketColumn = 7;
		private const int grdCummAccruedAmtColumn = 8;
		private const int grdRemarksColumn = 9;


		private const int conDlblEmpCode = 0;
		private const int conDlblEmpName = 1;
		private const int conDlblTicketAmount = 5;

		private const int conMaxColumns = 9;


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


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				FirstFocusObject = grdVoucherDetails;
				grdVoucherDetails.Visible = false;

				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = false;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = false;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //setting form mode to add initially
				mFirstGridFocus = true;

				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Year", 500, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Month", 600, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Month Days", 700, True, , &H1818B4, dbgRight, True, , dbgRight, , , , , , , , , , True)
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Accrual Ticket", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Availed Ticket", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ticket Adjustment", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Curr. Accru. Amt.", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cumm Accru. Ticket", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cumm. Accru. Amt.", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 50);

				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);

				grdVoucherDetails.Visible = true;
				grdVoucherDetails.Enabled = false;
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
				if (Shift == 0 && KeyCode == 116 && !mFirstGridFocus)
				{
					//Call DefineMasterRecordset
				}

				if (this.ActiveControl.Name == "grdVoucherDetails")
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
						if (grdVoucherDetails.Col == grdCurrAccruAmtColumn || grdVoucherDetails.Col == grdCummAccruedAmtColumn || grdVoucherDetails.Col == grdTicketYearColumn || grdVoucherDetails.Col == grdTicketMonthColumn)
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


				if (KeyCode == 13)
				{
					SendKeys.Send("{TAB}");
					return;
				}
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				aVoucherDetails = null;
				rsLeaveCodeList = null;
				UserAccess = null;
				oThisFormToolBar = null;
				frmPayIndemnityAccrualSummary.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}
		//
		//Private Sub cmbMastersList_RowChange()
		//If grdVoucherDetails.Col = grdLeaveCodeColumn Or grdVoucherDetails.Col = grdLeaveNameColumn Then
		//    If grdVoucherDetails.Col = grdLeaveCodeColumn Then
		//        grdVoucherDetails.Columns(grdLeaveNameColumn).Value = cmbMastersList.Columns(1).Value
		//    Else
		//        grdVoucherDetails.Columns(grdLeaveCodeColumn).Value = cmbMastersList.Columns(0).Value
		//    End If
		//End If
		//End Sub

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			if (ColIndex == grdCurrAccruAmtColumn || ColIndex == grdCummAccruedTicketColumn || ColIndex == grdCummAccruedTicketColumn)
			{
				grdVoucherDetails.UpdateData();
				CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);
				grdVoucherDetails.Refresh();
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == grdCurrAccruAmtColumn || ColIndex == grdCummAccruedAmtColumn)
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

		private void CalculateTotals(int mRowNumber, int mColNumber)
		{
			int cnt = 0;

			decimal mTotalAccruDays = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mTotalAccruDays += ((decimal) Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketAccruedColumn))));
				// mTotalMonthDays = mTotalMonthDays + Val(aVoucherDetails(cnt, grdIndemnityMonthDaysColumn))
			}

			if (mTotalAccruDays != 0)
			{
				grdVoucherDetails.Columns[grdTicketAccruedColumn].FooterText = StringsHelper.Format(mTotalAccruDays, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails.Columns[grdTicketAccruedColumn].FooterText = "";
			}
		}

		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, grdLineNoColumn);
			}
		}

		private void DefineVoucherArray(int pMaximumRows, bool pClearArray = false)
		{
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
			}
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, conMaxColumns}, new int[]{0, 0});
		}

		public bool saveRecord(bool pApprove = false)
		{

			int mEmpCd = 0;
			object mReturnValue = null;
			string mysql = "";
			int cnt = 0;

			//On Error GoTo eFoundError

			grdVoucherDetails.UpdateData();

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);
			}
			else
			{
				return false;
			}

			SystemVariables.gConn.BeginTransaction();

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mysql = " select ptas_entry_id from pay_ticket_accrual_summary ";
				mysql = mysql + " where ptas_emp_cd=" + mEmpCd.ToString();
				mysql = mysql + " and ptas_year=" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketYearColumn));
				mysql = mysql + " and ptas_month=" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketMonthColumn));

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					mysql = " insert into pay_ticket_accrual_summary ";
					mysql = mysql + " ( ";
					mysql = mysql + " ptas_emp_cd, ptas_curr_cd, ptas_year, ptas_month ";
					mysql = mysql + " , ptas_accrued_ticket,ptas_availed_ticket,ptas_adjusted_ticket ";
					mysql = mysql + " , ptas_curr_accru_fc_amount, ptas_curr_accru_lc_amount, ptas_cumm_accrued_ticket, ptas_cumm_accrued_amt ";
					mysql = mysql + " , ptas_remarks, ptas_user_cd ";
					mysql = mysql + " ) ";
					mysql = mysql + " values ( ";
					mysql = mysql + mEmpCd.ToString();
					mysql = mysql + " ," + SystemGLConstants.gDefaultCurrencyCd.ToString();
					mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketYearColumn));
					mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketMonthColumn));

					if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketAccruedColumn))) > 0)
					{
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketAccruedColumn));
					}
					else
					{
						mysql = mysql + " , 0 ";
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(aVoucherDetails.GetValue(cnt, grdTicketAvailedColumn)) && Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketAvailedColumn))) > 0)
					{
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketAvailedColumn));
					}
					else
					{
						mysql = mysql + " , 0 ";
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(aVoucherDetails.GetValue(cnt, grdTicketAdjustmentColumn)) && Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketAdjustmentColumn))) > 0)
					{
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketAdjustmentColumn));
					}
					else
					{
						mysql = mysql + " , 0 ";
					}

					if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdCurrAccruAmtColumn))) > 0)
					{
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdCurrAccruAmtColumn));
					}
					else
					{
						mysql = mysql + " , 0 ";
					}

					if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdCurrAccruAmtColumn))) > 0)
					{
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdCurrAccruAmtColumn));
					}
					else
					{
						mysql = mysql + " , 0 ";
					}

					if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdCummAccruedTicketColumn))) > 0)
					{
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdCummAccruedTicketColumn));
					}
					else
					{
						mysql = mysql + " , 0 ";
					}

					if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdCummAccruedAmtColumn))) > 0)
					{
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdCummAccruedAmtColumn));
					}
					else
					{
						mysql = mysql + " , 0 ";
					}

					mysql = mysql + " ,N'" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdRemarksColumn)) + "'";
					mysql = mysql + " ," + Conversion.Str(SystemVariables.gLoggedInUserCode);

					mysql = mysql + " ) ";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					mysql = " update pay_ticket_accrual_summary set ";
					mysql = mysql + " ptas_year = " + Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketYearColumn));
					mysql = mysql + " , ptas_month = " + Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketMonthColumn));
					mysql = mysql + " , ptas_accrued_ticket = " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdTicketAccruedColumn), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketAccruedColumn)));
					//mysql = mysql & " , ptas_month_days = " & IIf(IsItEmpty(aVoucherDetails(cnt, grdIndemnityMonthDaysColumn), NumberType), 0, aVoucherDetails(cnt, grdIndemnityMonthDaysColumn))
					mysql = mysql + " , ptas_availed_ticket =" + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdTicketAvailedColumn), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketAvailedColumn)));
					mysql = mysql + " , ptas_adjusted_ticket =" + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdTicketAdjustmentColumn), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketAdjustmentColumn)));
					mysql = mysql + " , ptas_curr_accru_fc_amount = " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdCurrAccruAmtColumn), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdCurrAccruAmtColumn)));
					mysql = mysql + " , ptas_curr_accru_lc_amount = " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdCurrAccruAmtColumn), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdCurrAccruAmtColumn)));
					mysql = mysql + " , ptas_cumm_accrued_ticket = " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdCummAccruedTicketColumn), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdCummAccruedTicketColumn)));
					mysql = mysql + " , ptas_cumm_accrued_amt = " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdCummAccruedAmtColumn), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdCummAccruedAmtColumn)));
					mysql = mysql + " , ptas_remarks = N'" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdRemarksColumn)) + "'";
					mysql = mysql + " , ptas_user_cd = " + Conversion.Str(SystemVariables.gLoggedInUserCode);

					mysql = mysql + " where ptas_emp_cd=" + mEmpCd.ToString();
					mysql = mysql + " and ptas_year=" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketYearColumn));
					mysql = mysql + " and ptas_month=" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketMonthColumn));

					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}
			}

			cnt = 0;


			//''''delete from the database, the lines which are deleted from grid
			mysql = " select ptas.ptas_year, ptas.ptas_month ";
			mysql = mysql + " from pay_ticket_accrual_summary ptas ";
			mysql = mysql + " where ptas.ptas_emp_cd =" + mEmpCd.ToString();
			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{
				int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar2; cnt++)
				{
					if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketYearColumn))) == Convert.ToDouble(rsTempRec["ptas_year"]) && Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdTicketMonthColumn))) == Convert.ToDouble(rsTempRec["ptas_month"]))
					{

						goto jumpnext;
					}
				}

				mysql = " delete from pay_ticket_accrual_summary";
				mysql = mysql + " where ptas_emp_cd=" + mEmpCd.ToString();
				mysql = mysql + " and ptas_year=" + Convert.ToString(rsTempRec["ptas_year"]);
				mysql = mysql + " and ptas_month=" + Convert.ToString(rsTempRec["ptas_month"]);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();
				jumpnext:;
			}
			while(rsTempRec.Read());

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			grdVoucherDetails.Enabled = false;
			Application.DoEvents();
			return true;



			int mReturnErrorType = 0;
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			MessageBox.Show(Information.Err().Description, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

			return false;
		}

		public bool CheckDataValidity()
		{
			int cnt = 0;

			if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Select an employee!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}


			//*-- update all the current voucher grid information in grid's internal buffer
			grdVoucherDetails.UpdateData();

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{

				if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdTicketYearColumn), SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Invalid Year", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					grdVoucherDetails.Col = grdTicketYearColumn;
					grdVoucherDetails.Bookmark = cnt;
					grdVoucherDetails.Focus();
					return false;
				}

				if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdTicketMonthColumn), SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Invalid Month", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					grdVoucherDetails.Col = grdTicketMonthColumn;
					grdVoucherDetails.Bookmark = cnt;
					grdVoucherDetails.Focus();
					return false;
				}

			}

			return true;
		}

		public void AddRecord()
		{
			int cnt = 0;

			try
			{

				int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					grdVoucherDetails.Columns[cnt].FooterText = "";
				}

				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode

				SystemProcedure2.ClearTextBox(this);
				DefineVoucherArray(-1, true);
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Enabled = false;

				mSearchValue = ""; //Change the msearchvalue to blank

				mFirstGridFocus = true;
				//FirstFocusObject.SetFocus
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}


		}


		public void GetRecord(object pSearchValue, bool pSearchByEmpCd = false)
		{

			int cnt = 0;

			//On Error GoTo eFoundError
			//
			//'''''Get the values by entryId
			//'''''this is called from report drill down
			//'''''other wise normally by emp code
			//If pSearchByEmpCd = False Then
			//    mySql = " select emp_cd , pay_date "
			//    mySql = mySql & " from pay_payroll "
			//    mySql = mySql & " where entry_id =" & pSearchValue
			//    mReturnValue = GetMasterCode(mySql)
			//    If Not IsNull(mReturnValue) Then
			//        mEmpCd = mReturnValue(0)
			//        mPayrollDate = mReturnValue(1)
			//    End If
			//Else
			//    mEmpCd = pSearchValue
			//End If

			string mysql = " select pemp.emp_no as emp_no ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , pemp.l_first_name + ' ' + pemp.l_second_name + ' ' + pemp.l_third_name + ' ' + pemp.l_fourth_name as emp_name";
			}
			else
			{
				mysql = mysql + " , pemp.a_first_name + ' ' + pemp.a_second_name + ' ' + pemp.a_third_name + ' ' + pemp.a_fourth_name as emp_name";
			}
			mysql = mysql + " from pay_employee pemp ";
			mysql = mysql + " where pemp.emp_cd = " + Conversion.Str(pSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				DefineVoucherArray(-1, true);
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
			}
			else
			{
				DefineVoucherArray(-1, true);
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				return;
			}

			mysql = "select ptas.ptas_year ";
			mysql = mysql + " , ptas.ptas_month, ptas.ptas_accrued_ticket,ptas_availed_ticket,ptas_adjusted_ticket ";
			//mysql = mysql & " , ptas.ptas_month_days "
			mysql = mysql + " , ptas.ptas_curr_accru_lc_amount ";
			mysql = mysql + " , ptas.ptas_cumm_accrued_ticket, ptas.ptas_cumm_accrued_amt ";
			mysql = mysql + " , ptas.ptas_remarks ";
			mysql = mysql + " from pay_ticket_accrual_summary ptas ";
			mysql = mysql + " inner Join pay_employee pemp on ptas.ptas_emp_cd = pemp.emp_cd  ";
			mysql = mysql + " where pemp.emp_cd = " + Conversion.Str(pSearchValue);
			mysql = mysql + " order by ptas.ptas_year desc , ptas.ptas_month desc ";

			SqlDataReader rsLocalRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			if (rsLocalRec.Read())
			{
				do 
				{
					DefineVoucherArray(cnt, false);
					aVoucherDetails.SetValue(Conversion.Str(cnt + 1).Trim(), cnt, grdLineNoColumn);

					aVoucherDetails.SetValue(rsLocalRec["ptas_year"], cnt, grdTicketYearColumn);
					aVoucherDetails.SetValue(rsLocalRec["ptas_month"], cnt, grdTicketMonthColumn);
					// aVoucherDetails(cnt, grdIndemnityMonthDaysColumn) = .Fields("ptas_month_days").Value
					aVoucherDetails.SetValue(rsLocalRec["ptas_accrued_ticket"], cnt, grdTicketAccruedColumn);
					aVoucherDetails.SetValue((Convert.IsDBNull(rsLocalRec["ptas_availed_ticket"])) ? ((object) 0) : rsLocalRec["ptas_availed_ticket"], cnt, grdTicketAvailedColumn);
					aVoucherDetails.SetValue((Convert.IsDBNull(rsLocalRec["ptas_adjusted_ticket"])) ? ((object) 0) : rsLocalRec["ptas_adjusted_ticket"], cnt, grdTicketAdjustmentColumn);
					aVoucherDetails.SetValue(rsLocalRec["ptas_curr_accru_lc_amount"], cnt, grdCurrAccruAmtColumn);
					aVoucherDetails.SetValue(rsLocalRec["ptas_cumm_accrued_ticket"], cnt, grdCummAccruedTicketColumn);
					aVoucherDetails.SetValue(rsLocalRec["ptas_cumm_accrued_amt"], cnt, grdCummAccruedAmtColumn);
					aVoucherDetails.SetValue(rsLocalRec["ptas_remarks"], cnt, grdRemarksColumn);

					cnt++;
				}
				while(rsLocalRec.Read());
			}

			AssignGridLineNumbers();
			grdVoucherDetails.Rebind(true);
			CalculateTotals(0, 0);

			grdVoucherDetails.Enabled = true;
			FirstFocusObject.Focus();
			mFirstGridFocus = true;

			//If mFirstGridFocus = True Then
			//    Call grdVoucherDetails_GotFocus
			//End If
			//DoEvents

			rsLocalRec.Close();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void PrintReport()
		{

		}

		public void CloseForm()
		{
			this.Close();
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{
			//Dim Col As Integer
			//
			//If MsgId = 1 Then
			//    grdVoucherDetails.Col = grdLeaveCodeColumn
			//    Set cmbMastersList.DataSource = rsLeaveCodeList
			//End If
		}

		public void IRoutine()
		{
			int mCurrentLineNo = 0;

			if (ActiveControl.Name != "grdVoucherDetails" && grdVoucherDetails.Enabled)
			{
				grdVoucherDetails.Focus();
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdVoucherDetails.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdVoucherDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[grdLineNoColumn].Value);
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), 1);
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdVoucherDetails" && grdVoucherDetails.Enabled)
			{
				grdVoucherDetails.Focus();
			}

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdVoucherDetails.Delete();
				AssignGridLineNumbers();
				CalculateTotals(0, 1);
				grdVoucherDetails.Rebind(true);
			}
		}


		public void findRecord()
		{
			//Call the find window

			//mysql = " pay_emp.status_cd=1 "
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue, true);
			}
		}

		public void FindRoutine(string pObjectName)
		{
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			grdVoucherDetails.Columns[grdLineNoColumn].Text = (grdVoucherDetails.RowCount + 1).ToString();
			grdVoucherDetails.Columns[grdCurrAccruAmtColumn].Text = "0";

			//''''This cause the focus to be lost from billing code for the first time when a new row is added
			//grdVoucherDetails.Update
			//grdVoucherDetails.Refresh
		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			//If grdVoucherDetails.Col > 0 And LastCol > 0 And mFirstGridFocus = False Then
			//    Select Case grdVoucherDetails.Col
			//        Case grdLeaveCodeColumn, grdLeaveNameColumn
			//            Set cmbMastersList.DataSource = rsLeaveCodeList
			//    End Select
			//End If
		}
	}
}