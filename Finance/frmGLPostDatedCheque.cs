
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmGLPostDatedCheque
		: System.Windows.Forms.Form
	{


		
		public frmGLPostDatedCheque()
{
InitializeComponent();
} 
 public  void frmGLPostDatedCheque_old()
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

		private const int gccLineNoColumn = 0;
		private const int gccEntryId = 1;
		private const int gccPDCGeneratedLinkedVoucherTypeColumn = 2;
		private const int gccVoucherTypeColumn = 3;
		private const int gccVoucherNo = 4;
		private const int gccChequeNo = 5;
		private const int gccMaturityDate = 6;
		private const int gccLedgerCode = 7;
		private const int gccLedgerName = 8;
		private const int gccCostCode = 9;
		private const int gccDrCrType = 10;
		private const int gccAmount = 11;
		private const int gccComments = 12;
		private const int gccConvertDate = 13;
		private const int gccConvert = 14;
		private const int gccTimeStamp = 15;
		private const int gccATDLineNo = 16;
		private const int gccLedgerRemarks = 17;
		private const int gccAccntTransDetailsComments = 18;

		private const int mMaxArrayCol = 18;

		private int mLastCol = 0;
		private int mLastRow = 0;
		private bool mFirstGridFocus = false;
		private DataSet rsLedgerCodeList = null;
		private DataSet rsCostCodeList = null;

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


		//Private Sub btnFormToolBar_Click(Index As Integer)
		//Call ToolBarButtonClick(Me, btnFormToolBar(Index).Tag)
		//End Sub

		private void cmdClose_Click()
		{
			this.Close();
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			switch(grdVoucherDetails.Col)
			{
				case gccLedgerCode : case gccLedgerName : 
					if (grdVoucherDetails.Col == gccLedgerCode)
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
								withVar.setOrder((grdVoucherDetails.Col == gccLedgerCode) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccLedgerCode].Width;
							}
							else
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == gccLedgerCode) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccLedgerName].Width;
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
					break;
				case gccCostCode : 
					int tempForEndVar2 = cmbMastersList.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar2; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_2 = cmbMastersList.Splits[0].DisplayColumns[cnt];
						if (cnt < 2)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_2.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar_2.setOrder((grdVoucherDetails.Col == gccCostCode) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar_2.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccCostCode].Width;
							}
							else
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_2.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar_2.setOrder((grdVoucherDetails.Col == gccCostCode) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar_2.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccLedgerName].Width;
							}

							withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;

							withVar_2.Visible = true;
							cmbMastersList.Width += withVar_2.Width / 15;
						}
						else
						{
							withVar_2.Visible = false;
						}
						withVar_2.AllowSizing = false;
					} 

					 
					cmbMastersList.Width += 17; 
					cmbMastersList.Height = 167; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			if (grdVoucherDetails.Col == gccLedgerCode || grdVoucherDetails.Col == gccLedgerName)
			{
				if (grdVoucherDetails.Col == gccLedgerCode)
				{
					grdVoucherDetails.Columns[gccLedgerName].Value = cmbMastersList.Columns[1].Value;
				}
				else
				{
					grdVoucherDetails.Columns[gccLedgerCode].Value = cmbMastersList.Columns[0].Value;
				}
			}
		}

		private void cmdShow_Click(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;
			bool mPDCR = false;
			bool mPDCP = false;

			//On Error GoTo mend
			if (!SystemProcedure2.IsItEmpty(txtVoucherType.Text, SystemVariables.DataType.NumberType))
			{
				mysql = " select case when is_pdc_receipt_type = 1 then 'PDCR' else 'PDCP' end from gl_accnt_voucher_types";
				mysql = mysql + " where voucher_type =" + txtVoucherType.Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) == "PDCR")
					{
						mPDCR = true;
						mPDCP = false;
					}
					else
					{
						mPDCR = false;
						mPDCP = true;
					}
				}
				else
				{
					mPDCR = true;
					mPDCP = true;
				}
			}
			else
			{
				mPDCR = true;
				mPDCP = true;
			}

			mysql = "";

			if (mPDCR)
			{
				mysql = " select avt.voucher_type, at.voucher_no, at.pdc_due_date, gl_ledger.ldgr_no ";
				mysql = mysql + " , gl_ledger.l_ldgr_name , gl_ledger.a_ldgr_name , abs(atd.lc_amount) as lc_amount ";
				mysql = mysql + " , avt.l_short_name , avt.a_short_name ";
				mysql = mysql + " , at.entry_id , avt.pdc_generated_linked_gl_voucher_type ";
				mysql = mysql + " , at.time_stamp ";
				mysql = mysql + " , at.cheque_no ";
				mysql = mysql + " , atd.line_no ";
				mysql = mysql + " , at.comments ";
				mysql = mysql + " , case when atd.dr_cr_type = 'D' then 'Dr' else 'Cr' end  as dr_cr ";
				mysql = mysql + " , (select dt2.comments from gl_accnt_trans_details dt2";
				mysql = mysql + " where dt2.entry_id = at.entry_id and dt2.dr_cr_line_no = 1 ";
				mysql = mysql + " and dt2.dr_cr_type <> atd.dr_cr_type) as details_comment ";
				mysql = mysql + " , gcc.cost_no ";
				mysql = mysql + " from gl_accnt_trans at ";
				mysql = mysql + " inner join gl_accnt_trans_details atd on at.entry_id = atd.entry_id ";
				mysql = mysql + " inner join gl_accnt_voucher_types avt on at.voucher_type = avt.voucher_type ";
				mysql = mysql + " inner join gl_ledger on atd.ldgr_cd = gl_ledger.ldgr_cd ";
				mysql = mysql + " inner join gl_cost_centers gcc on atd.cost_cd = gcc.cost_cd ";
				mysql = mysql + " where avt.is_pdc_receipt_type = 1 ";
				mysql = mysql + " and atd.dr_cr_type = 'D' ";
				mysql = mysql + " and atd.dr_cr_line_no = 1 ";
				mysql = mysql + " and at.pdc_due_date <='" + ReflectionHelper.GetPrimitiveValue<string>(txtMaturityDate.Value) + "'";
				mysql = mysql + " and (at.pdc_due_date >='" + SystemVariables.gCurrentPeriodStarts + "'";
				mysql = mysql + " and at.pdc_due_date <='" + SystemVariables.gNextPeriodEnds + "')";
				//'added by Moiz Hakimion 11-feb-2008. This will help in having same voucher for rcpt/payment and PDC
				mysql = mysql + " and (at.voucher_date <> at.pdc_due_date) ";
				if (!SystemProcedure2.IsItEmpty(txtChequeNo.Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " and at.cheque_no = '" + txtChequeNo.Text + "'";
				}
				mysql = mysql + " and at.status = 1 ";
			}

			if (mPDCR && mPDCP)
			{
				mysql = mysql + " union all ";
			}

			if (!mPDCR)
			{
				mysql = "";
			}

			if (mPDCP)
			{
				mysql = mysql + " select avt.voucher_type, at.voucher_no, at.pdc_due_date, gl_ledger.ldgr_no ";
				mysql = mysql + " , gl_ledger.l_ldgr_name , gl_ledger.a_ldgr_name , abs(atd.lc_amount) as lc_amount ";
				mysql = mysql + " , avt.l_short_name , avt.a_short_name ";
				mysql = mysql + " , at.entry_id , avt.pdc_generated_linked_gl_voucher_type ";
				mysql = mysql + " , at.time_stamp ";
				mysql = mysql + " , at.cheque_no ";
				mysql = mysql + " , atd.line_no ";
				mysql = mysql + " , at.comments ";
				mysql = mysql + " , case when atd.dr_cr_type = 'D' then 'Dr' else 'Cr' end  as dr_cr ";
				mysql = mysql + " , (select dt2.comments from gl_accnt_trans_details dt2";
				mysql = mysql + " where dt2.entry_id = at.entry_id and dt2.dr_cr_line_no = 1 ";
				mysql = mysql + " and dt2.dr_cr_type <> atd.dr_cr_type) as details_comment ";
				mysql = mysql + " , gcc.cost_no ";
				mysql = mysql + " from gl_accnt_trans at ";
				mysql = mysql + " inner join gl_accnt_trans_details atd on at.entry_id = atd.entry_id ";
				mysql = mysql + " inner join gl_accnt_voucher_types avt on at.voucher_type = avt.voucher_type ";
				mysql = mysql + " inner join gl_ledger on atd.ldgr_cd = gl_ledger.ldgr_cd ";
				mysql = mysql + " inner join gl_cost_centers gcc on atd.cost_cd = gcc.cost_cd ";
				mysql = mysql + " Where avt.is_pdc_payment_type = 1 ";
				mysql = mysql + " and atd.dr_cr_type = 'C' ";
				mysql = mysql + " and atd.dr_cr_line_no = 1 ";
				mysql = mysql + " and at.pdc_due_date <='" + ReflectionHelper.GetPrimitiveValue<string>(txtMaturityDate.Value) + "'";
				mysql = mysql + " and (at.pdc_due_date >='" + SystemVariables.gCurrentPeriodStarts + "'";
				mysql = mysql + " and at.pdc_due_date <='" + SystemVariables.gNextPeriodEnds + "')";
				mysql = mysql + " and (at.voucher_date <> at.pdc_due_date) ";
				if (!SystemProcedure2.IsItEmpty(txtChequeNo.Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " and at.cheque_no = '" + txtChequeNo.Text + "'";
				}
				mysql = mysql + " and at.status = 1 ";
				mysql = mysql + " order by 3 ";
			}


			int cnt = 0;

			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			DefineVoucherArray(-1, true);

			do 
			{
				DefineVoucherArray(cnt, false);

				//Get the details information into the grid
				aVoucherDetails.SetValue(cnt, cnt, gccLineNoColumn);
				aVoucherDetails.SetValue(rsTempRec["entry_id"], cnt, gccEntryId);
				aVoucherDetails.SetValue(rsTempRec["pdc_generated_linked_gl_voucher_type"], cnt, gccPDCGeneratedLinkedVoucherTypeColumn);
				aVoucherDetails.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsTempRec["l_short_name"] : rsTempRec["a_short_name"], cnt, gccVoucherTypeColumn);
				aVoucherDetails.SetValue(rsTempRec["voucher_no"], cnt, gccVoucherNo);
				aVoucherDetails.SetValue(StringsHelper.Format(rsTempRec["pdc_due_date"], SystemVariables.gSystemDateFormat), cnt, gccMaturityDate);
				aVoucherDetails.SetValue(rsTempRec["ldgr_no"], cnt, gccLedgerCode);
				aVoucherDetails.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsTempRec["l_ldgr_name"] : rsTempRec["a_ldgr_name"], cnt, gccLedgerName);
				aVoucherDetails.SetValue(rsTempRec["cost_no"], cnt, gccCostCode);
				aVoucherDetails.SetValue(rsTempRec["lc_amount"], cnt, gccAmount);
				aVoucherDetails.SetValue(rsTempRec["comments"], cnt, gccComments);
				aVoucherDetails.SetValue(0, cnt, gccConvert);
				aVoucherDetails.SetValue(rsTempRec["time_stamp"], cnt, gccTimeStamp);
				aVoucherDetails.SetValue(rsTempRec["line_no"], cnt, gccATDLineNo);

				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["cheque_no"]) + "", cnt, gccChequeNo);
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["dr_cr"]) + "", cnt, gccDrCrType);
				aVoucherDetails.SetValue(StringsHelper.Format(rsTempRec["pdc_due_date"], SystemVariables.gSystemDateFormat), cnt, gccConvertDate);
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["comments"]) + "", cnt, gccLedgerRemarks);
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["details_comment"]) + "", cnt, gccAccntTransDetailsComments);

				cnt++;
			}
			while(rsTempRec.Read());

			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Refresh();

			CalculateTotals(0, 0);

			if (cnt > 0)
			{
				grdVoucherDetails.Focus();
			}
			return;

			MessageBox.Show(Information.Err().Description, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

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

				if (this.ActiveControl.Name == "grdVoucherDetails" || this.ActiveControl.Name == "txtTempDate")
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
						if (grdVoucherDetails.Col == gccLedgerCode)
						{
							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
							if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no"))) == TriState.False)
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
				}

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
			mFirstGridFocus = true;

			//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(1))
			//Set btnFormToolBar(1).Picture = frmSysMain.imlSystemIcons.ListImages("imgPostingTransactions").Picture
			//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
			//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
			//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgInsertLine").Picture
			//Set btnFormToolBar(7).Picture = frmSysMain.imlMainToolBar.ListImages("imgDeleteLine").Picture
			//Set btnFormToolBar(8).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture

			//**--format & define the new toolbar
			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			//.ShowPrintButton = True
			//.ShowPostButton = True
			oThisFormToolBar.ShowSaveButton = true;
			oThisFormToolBar.ShowHelpButton = true;
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.DisableHelpButton = true;
			oThisFormToolBar.ShowCheckAllButton = true;
			oThisFormToolBar.ShowUncheckAllButton = true;
			this.WindowState = FormWindowState.Maximized;


			txtTempDate.AlignHorizontal = TDBDate6.dbiAlignHConst.dbiAlignHLeft;
			txtTempDate.AlignVertical = TDBDate6.dbiAlignVConst.dbiAlignVCenter;
			txtTempDate.Appearance = TDBDate6.dbiAppearanceConst.dbiFlat;
			txtTempDate.BorderStyle = TDBDate6.dbiBorderStyleConst.dbiNoBorder;
			txtTempDate.CenturyMode = TDBDate6.dbiCenturyModeConst.dbiCurrentCentury;
			txtTempDate.Calendar.SelectStyle = TDBDate6.dbiCalndrSelStyleConst.dbiCalSelStyleFlatBtn;
			txtTempDate.Calendar.WeekTitles = "S,M,T,W,T,F,S";
			txtTempDate.CenturyMode = TDBDate6.dbiCenturyModeConst.dbiSystemCentury;
			txtTempDate.DisplayFormat = SystemVariables.gSystemDateFormat;
			txtTempDate.DropDown.Visible = TDBDate6.dbiVisibleConst.dbiShowOnFocus;
			txtTempDate.Format = SystemVariables.gSystemDateFormat;


			//mGridFontName = "Arial Narrow"
			string mGridFontName = "";
			int mGridFontSize = 8;

			//**--define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.4f, 1.4f, "&HB4D9F8", "&HB4D9F8", 280, 6);
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Line No", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Entry Id", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "PDCGeneratedLinkedVoucherType", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false, false, false, false, false, 100, "", mGridFontName, false, "", mGridFontSize);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Type", 500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", mGridFontName, false, "", mGridFontSize);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Transaction No.", 1050, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", mGridFontName, false, "", mGridFontSize);

			//**--pls add this column : cheque number
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cheque No.", 1050, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", mGridFontName, false, "", mGridFontSize);
			//**----------------------
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Maturity Date", 1050, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true, 100, "", mGridFontName, false, "", mGridFontSize);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Code", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, true, false, false, false, false, 100, "", mGridFontName, false, "", mGridFontSize);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Name", 2400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, true, false, false, false, false, 100, "", mGridFontName, false, "", mGridFontSize, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Code", 900, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, true, false, false, false, false, 100, "", mGridFontName, false, "", mGridFontSize);
			//**--pls add this column : amount type...Dr / Cr
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Dr / Cr", 350, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", mGridFontName, false, "", mGridFontSize);
			//**----------------------
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true, 100, "", mGridFontName, false, "", mGridFontSize);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remark", 2400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", mGridFontName, false, "", mGridFontSize, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Convert Date", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", mGridFontName, false, "txtTempDate", mGridFontSize);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Convert", 500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, false, false, 100, "", mGridFontName, false, "", mGridFontSize);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Time Stamp", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "ATD Line", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Remarks", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

			grdVoucherDetails.HoldFields();
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);
			//.CellTips = dbgFloating
			//.CellTipsDelay = 0



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
				frmGLPostDatedCheque.DefInstance = null;
				oThisFormToolBar = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdVoucherDetails_BeforeColEdit(object eventSender, C1.Win.C1TrueDBGrid.BeforeColEditEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int KeyAscii = (int) eventArgs.KeyChar;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				if (ColIndex == gccConvert && Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex)) != "")
				{
					if (KeyAscii == 0 || KeyAscii == 13 || KeyAscii == 32)
					{
						aVoucherDetails.SetValue(~Convert.ToInt32(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex)), ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);
						grdVoucherDetails.UpdateData();
						grdVoucherDetails.Refresh();
						//Call CalculateReconcileBalance
					}
					Cancel = -1;
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
			if (Col == gccConvert)
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FetchCellTips was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FetchCellTips(int SplitIndex, int ColIndex, int RowIndex, string CellTip, bool FullyDisplayed, C1.Win.C1TrueDBGrid.Style TipStyle)
		{
			//If (ColIndex = gccLedgerCode Or ColIndex = gccLedgerName) Then
			//
			//    grdVoucherDetails.ToolTipText = "hkaaa"
			//Else
			//    CellTip = ""
			//End If
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == gccAmount)
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

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";

			if (mFirstGridFocus)
			{
				//If cmbMastersList.Tag = "" Then
				SystemGrid.DefineSystemGridCombo(cmbMastersList);
				//End If

				DefineMasterRecordset();
				mFirstGridFocus = false;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.PostMsg(1);
			}
			else
			{
			}

		}

		private void grdVoucherDetails_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				int Col = grdVoucherDetails.Col;

				if (Col == gccConvert && ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[Col].Value).Trim() != "")
				{
					if (KeyAscii == 32)
					{
						KeyAscii = 0;
						grdVoucherDetails.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[Col].Value);
						grdVoucherDetails.UpdateData();
						grdVoucherDetails.Refresh();
						//Call CalculateReconcileBalance
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
				grdVoucherDetails.PostMsg(2);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{

			if (MsgId == 1)
			{
				grdVoucherDetails.Col = gccLedgerCode;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsLedgerCodeList);
			}

			if (mLastCol == grdVoucherDetails.Col && mLastRow == grdVoucherDetails.Row)
			{
				return;
			}

			int Col = grdVoucherDetails.Col;
			if (Col == gccConvert)
			{
				grdVoucherDetails.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[Col].Value);
				grdVoucherDetails.UpdateData();
				grdVoucherDetails.Refresh();
				//Call CalculateReconcileBalance
			}

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
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, mMaxArrayCol}, new int[]{0, 0});

		}


		private void CalculateTotals(int mRowNumber, int mColNumber)
		{
			//''''*************************************************************************
			//'''Calculate the figures of following columns.
			//'''Quantity, Rate , Discount and amount.
			//''''*************************************************************************
			int cnt = 0;

			double mTotalAmt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mTotalAmt += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, gccAmount)));
			}

			if (mTotalAmt != 0)
			{
				grdVoucherDetails.Columns[gccAmount].FooterText = StringsHelper.Format(mTotalAmt, "###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails.Columns[gccAmount].FooterText = "";
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool saveRecord()
		{
			bool result = false;
			string mysql = "";
			object mReturnValue = null;

			int cnt = 0;
			bool mConvert = false;
			int mPDCGenerateLinkedVoucherType = 0;
			int mEntryId = 0;
			string mOldTimeStamp = "";
			string mNewTimeStamp = "";
			int mLdgrCd = 0;
			int mCostCd = 0;
			string mDrCrType = "";

			string mConvertDate = "";

			grdVoucherDetails.UpdateData();

			SystemVariables.gConn.BeginTransaction();
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				mConvert = ((TriState) Convert.ToInt32(aVoucherDetails.GetValue(cnt, gccConvert))) == TriState.True;

				if (mConvert)
				{
					mOldTimeStamp = Convert.ToString(aVoucherDetails.GetValue(cnt, gccTimeStamp));
					mPDCGenerateLinkedVoucherType = Convert.ToInt32(aVoucherDetails.GetValue(cnt, gccPDCGeneratedLinkedVoucherTypeColumn));
					mEntryId = Convert.ToInt32(aVoucherDetails.GetValue(cnt, gccEntryId));


					//'''''''''Check the voucher time stamp
					mysql = " select time_stamp from gl_accnt_trans where entry_id = " + Conversion.Str(mEntryId);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mNewTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}

					if (SystemProcedure2.tsFormat(mOldTimeStamp) != SystemProcedure2.tsFormat(mNewTimeStamp))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//FirstFocusObject.SetFocus
						return false;
					}


					mysql = "select ldgr_cd ";
					mysql = mysql + " from gl_ledger ";
					//mysql = mysql & " where (gl_ledger.ldgr_type = 'B-CH' or gl_ledger.ldgr_type = 'B-BA') "
					mysql = mysql + " where ( gl_ledger.type_cd = " + SystemGLConstants.gGLBankTypeCode.ToString();
					mysql = mysql + " or gl_ledger.type_cd =" + SystemGLConstants.gGLCashTypeCode.ToString() + ")";
					mysql = mysql + " and ldgr_no='" + Convert.ToString(aVoucherDetails.GetValue(cnt, gccLedgerCode)) + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLdgrCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);

						if (!Information.IsDate(aVoucherDetails.GetValue(cnt, gccConvertDate)))
						{
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							MessageBox.Show("Invalid Convert Date !", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							result = false;
							grdVoucherDetails.Focus();
							return result;
						}
						else
						{
							mConvertDate = StringsHelper.Format(aVoucherDetails.GetValue(cnt, gccConvertDate), SystemVariables.gSystemDateFormat);
						}

					}
					else
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show("Invalid Ledger !", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						grdVoucherDetails.Focus();
						return result;
					}


					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdVoucherDetails.Splits[0].DisplayColumns[gccCostCode].Visible)
					{
						if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, gccCostCode), SystemVariables.DataType.NumberType))
						{
							mysql = "select cost_cd ";
							mysql = mysql + " from gl_cost_centers ";
							mysql = mysql + " where ";
							mysql = mysql + " cost_no=" + Convert.ToString(aVoucherDetails.GetValue(cnt, gccCostCode));
							mysql = mysql + " and show =1 ";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mCostCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
							}
							else
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								MessageBox.Show("Invalid Cost Center!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								result = false;
								grdVoucherDetails.Focus();
								return result;
							}
						}
						else
						{
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							MessageBox.Show("Invalid Cost Center!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							result = false;
							grdVoucherDetails.Focus();
							return result;
						}
					}
					else
					{
						mCostCd = 0;
					}

					if (Convert.ToString(aVoucherDetails.GetValue(cnt, gccDrCrType)) == "Dr")
					{
						mDrCrType = "D";
					}
					else
					{
						mDrCrType = "C";
					}

					SystemGLProcedure.GenerateLinkedVoucherForPDC(mPDCGenerateLinkedVoucherType, mEntryId, mLdgrCd, mDrCrType, mConvertDate, mCostCd);
				}
			}


			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

			txtMaturityDate.Focus();
			return true;
		}


		public bool CheckDataValidity()
		{
			//Check validation during update and add of records

			if (!Information.IsDate(txtMaturityDate.Value))
			{
				MessageBox.Show("Enter valid date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtMaturityDate.Focus();
				return false;
			}

			return true;
		}


		public void AddRecord()
		{
			try
			{

				int cnt = 0;

				//''''*************************************************************************
				//'''Grid settings
				int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					grdVoucherDetails.Columns[cnt].FooterText = "";
				}
				DefineVoucherArray(-1, true);
				grdVoucherDetails.Rebind(true);

				SystemProcedure2.ClearTextBox(this);
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
			int cnt = 0;


			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(TriState.True, cnt, gccConvert);
			}
			grdVoucherDetails.Rebind(true);
		}

		public void URoutine()
		{
			int cnt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(TriState.False, cnt, gccConvert);
			}
			grdVoucherDetails.Rebind(true);
		}

		private void DefineMasterRecordset()
		{

			string mysql = "select ldgr_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name as ldgr_name" : "a_ldgr_name as ldgr_name");
			mysql = mysql + " from gl_ledger ";
			mysql = mysql + " where ( gl_ledger.type_cd = " + SystemGLConstants.gGLBankTypeCode.ToString();
			mysql = mysql + " or gl_ledger.type_cd =" + SystemGLConstants.gGLCashTypeCode.ToString() + ")";
			mysql = mysql + " order by 1 ";

			rsLedgerCodeList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsLedgerCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsLedgerCodeList.Tables.Clear();
			adap.Fill(rsLedgerCodeList);

			mysql = "select gcc.cost_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "gcc.l_cost_name as cost_name" : "gcc.a_cost_name as cost_name");
			mysql = mysql + " from gl_cost_centers gcc ";
			mysql = mysql + " where gcc.show = 1 ";
			mysql = mysql + " order by 1 ";

			rsCostCodeList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCostCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsCostCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsCostCodeList.Tables.Clear();
			adap_2.Fill(rsCostCodeList);

		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			//If grdVoucherDetails.Col > 0 And LastCol > 0 And mFirstGridFocus = False Then
			if (grdVoucherDetails.Col > 0 && !mFirstGridFocus)
			{
				switch(grdVoucherDetails.Col)
				{
					case gccLedgerCode : case gccLedgerName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsLedgerCodeList); 
						break;
					case gccCostCode : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsCostCodeList); 
						break;
				}

				//**--set the footer text to the transaction details comment
				//**--modified by: Moiz Hakimi
				//**--modified on: 10-jun-2005
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(grdVoucherDetails.Bookmark))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), gccAccntTransDetailsComments)))
					{
						grdVoucherDetails.Columns[gccLedgerName].FooterText = Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), gccAccntTransDetailsComments));
					}
					else
					{
						grdVoucherDetails.Columns[gccLedgerName].FooterText = "";
					}
				}
				//**--------------------------------------------------
			}

			if (grdVoucherDetails.Col == gccLedgerName || grdVoucherDetails.Col == gccLedgerCode)
			{
				if (ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Bookmark) >= 0)
				{
					//Debug.Print grdVoucherDetails.Bookmark
					if (Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), gccLedgerRemarks)) != "")
					{
						ToolTipMain.SetToolTip(grdVoucherDetails, Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), gccLedgerRemarks)));
					}
					else
					{
						ToolTipMain.SetToolTip(grdVoucherDetails, "");
					}
				}
			}
		}



		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;
			string mFilterCondition = "";

			switch(pObjectName)
			{
				case "txtVoucherType" : 
					txtVoucherType.Text = ""; 
					 
					mFilterCondition = " gl.show = 1 and (gl.is_pdc_receipt_type = 1 or gl.is_pdc_payment_type = 1)"; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(205, "2044", mFilterCondition)); 
					 
					break;
				default:
					return;
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				switch(pObjectName)
				{
					case "txtVoucherType" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtVoucherType.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)); 
						txtVoucherType_Leave(txtVoucherType, new EventArgs()); 
						break;
				}
			}
		}


		private void txtVoucherType_DropButtonClick(Object Sender, EventArgs e)
		{

			SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtVoucherType");

		}

		private void txtVoucherType_Leave(Object eventSender, EventArgs eventArgs)
		{

			try
			{
				object mTempValue = null;
				string mysql = "";

				if (!SystemProcedure2.IsItEmpty(txtVoucherType.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name, voucher_type" : "a_voucher_name, voucher_type");
					mysql = mysql + " from gl_accnt_voucher_types  ";
					mysql = mysql + " where voucher_type=" + txtVoucherType.Text;
					mysql = mysql + " and show = 1 ";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempValue))
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtVoucherName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
					}
					else
					{
						txtVoucherName.Text = "";
						throw new System.Exception("-9990002");
					}
				}
				else
				{
					txtVoucherName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					//if the code is not found
					txtVoucherType.Focus();
				}
				else
				{
					//
				}
			}
		}
	}
}