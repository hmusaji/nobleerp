
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmGLAccrualBreakup
		: System.Windows.Forms.Form
	{

		public frmGLAccrualBreakup()
{
InitializeComponent();
} 
 public  void frmGLAccrualBreakup_old()
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


		private void frmGLAccrualBreakup_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private DataSet rsLedgerCodeList = null;
		private bool mFirstGridFocus = false;

		private XArrayHelper aBreakupVoucherDetails = null;
		private XArrayHelper aNewAdjustmentDetails = null;

		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;
		private System.Windows.Forms.TextBox FirstFocusObject = null;

		private const string mDisableColumnBackColor = "&HD5D5D5";

		private const int cGABDSno = 0;
		private const int cGABDProdCode = 1;
		private const int cGABDProdName = 2;
		private const int cGABDAmount = 3;
		private const int cGABDFromDate = 4;
		private const int cGABDToDate = 5;
		private const int cGABDLdgrCode = 6;
		private const int cGABDLdgrName = 7;
		private const int cGABDRemarks = 8;
		private const int cGABDInvntLineNo = 9;

		//define the new Adjustment Details col no.
		private const int cGAdjDSno = 0;
		private const int cGAdjDFromDate = 1;
		private const int cGAdjDToDate = 2;
		private const int cGAdjDAmt = 3;
		private const int cGAdjProdCode = 4;
		private const int cGAdjProdName = 5;
		private const int cGAdjLdgrCode = 6;
		private const int cGAdjLdgrName = 7;
		private const int cGAdjInvntLineNo = 8;


		private const int mMaxColBreakupVoucherDetails = 9;
		private const int mMaxColNewAdjustmentDetails = 8;

		private const int cTcNewVoucherType = 1;
		private const int cTcDebitAccountCode = 2;
		private const int cTcBreakupVoucherNo = 3;
		private const int cTcCreditAccountCode = 4;
		private const int cTcTransactionNo = 5;

		private const int cDLblCreditLdgrName = 1;
		private const int cDLblDebitLdgrName = 2;
		private const int cDLblBreakupVoucherType = 3;
		private const int cDLblNewVoucherTypeName = 4;
		private const int cDLblBreakupVoucherDate = 5;
		private const int cDLblBreakupInvNo = 6;


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


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{

			if (grdBreakupVoucherDetails.Col == cGABDLdgrCode)
			{
				grdBreakupVoucherDetails.Columns[cGABDLdgrName].Value = cmbMastersList.Columns[1].Value;
			}
			else if (grdBreakupVoucherDetails.Col == cGABDLdgrName)
			{ 
				grdBreakupVoucherDetails.Columns[cGABDLdgrCode].Value = cmbMastersList.Columns[0].Value;
			}

		}

		private void cmdAllocate_Click(Object eventSender, EventArgs eventArgs)
		{
			AutoAllocateDetails();
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (this.ActiveControl.Name.ToLower() == ("txtTempDate").ToLower() || this.ActiveControl.Name.ToLower() == ("grdRateAdjustment").ToLower() || this.ActiveControl.Name.ToLower() == ("grdNewAllocationDetails").ToLower())
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
						if (grdNewAllocationDetails.Col == cGAdjDAmt)
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
			string mysql = "";

			try
			{

				this.Top = 0;
				this.Left = 0;

				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
				FirstFocusObject = txtCommonTextBox[cTcBreakupVoucherNo];
				mFirstGridFocus = true;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				oThisFormToolBar.ShowUnpostButton = true;
				this.WindowState = FormWindowState.Maximized;


				//''define Account select
				//Call DefineSystemVoucherGrid(grdBreakupVoucherDetails, False, False, False, , , , False, , , , "&HB5BDB3", "&HB5BDB3")
				//
				//Call DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "LN", 400, False, gDisableColumnBackColor, , , False)
				//Call DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "Ledger Code", 1300, False, gDisableColumnBackColor, , , False)
				//Call DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "Ledger Name", 3200, False, gDisableColumnBackColor, , , False)
				//Call DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "Debit Amt.", 1400, False, gDisableColumnBackColor, , dbgRight, True, , , , , , , , , , , , True)
				//Call DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "Credit Amt.", 1600, False, gDisableColumnBackColor, , dbgRight, True, , , , , , , , , , , , True)
				//Call DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "Remarks", 450, False, gDisableColumnBackColor, , , False)

				//''define ICS_Item details
				SystemGrid.DefineSystemVoucherGrid(grdBreakupVoucherDetails, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, "&HB5BDB3", "&HB5BDB3");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Line_No_In_Details"]));
				SystemGrid.DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "Product Code", 1200, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "Product Name", 2700, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				//Call DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "Qty", 900, False, , , dbgRight)
				//Call DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "Rate", 1000, False, , , dbgRight, False, , dbgRight)
				SystemGrid.DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "Amount", 900, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "From Date", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "txtTempDate");
				SystemGrid.DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "To Date", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "txtTempDate");
				SystemGrid.DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "Ledger Code", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "Ledger Name", 3200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "Remarks", 2000, false, SystemConstants.gDisableColumnBackColor);
				SystemGrid.DefineSystemVoucherGridColumn(grdBreakupVoucherDetails, "Invnt Line No", 2000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				//define the Adjustment Details
				SystemGrid.DefineSystemVoucherGrid(grdNewAllocationDetails, false, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2.2f, 1.4f, "&HB5BDB3", "&HB5BDB3");

				SystemGrid.DefineSystemVoucherGridColumn(grdNewAllocationDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdNewAllocationDetails, "From Date", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdNewAllocationDetails, "To Date", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdNewAllocationDetails, "Amount", 900, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdNewAllocationDetails, "Product Code", 1200, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdNewAllocationDetails, "Product Name", 2500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdNewAllocationDetails, "Credit Ledger Code", 1100, true, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdNewAllocationDetails, "Credit Ledger Name", 2500, true, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdNewAllocationDetails, "Invnt Line No", 3000, true, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);


				aBreakupVoucherDetails = new XArrayHelper();
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aBreakupVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aBreakupVoucherDetails.Clear();
				aBreakupVoucherDetails.RedimXArray(new int[]{-1, mMaxColBreakupVoucherDetails}, new int[]{0, 0});
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdBreakupVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdBreakupVoucherDetails.setArray(aBreakupVoucherDetails);

				aNewAdjustmentDetails = new XArrayHelper();
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aNewAdjustmentDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aNewAdjustmentDetails.Clear();
				aNewAdjustmentDetails.RedimXArray(new int[]{-1, mMaxColNewAdjustmentDetails}, new int[]{0, 0});
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdNewAllocationDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdNewAllocationDetails.setArray(aNewAdjustmentDetails);

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

				txtCommonTextBox[cTcNewVoucherType].Text = "103";
				txtCommonTextBox_Leave(txtCommonTextBox[cTcNewVoucherType], new EventArgs());
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

				aBreakupVoucherDetails = null;
				aNewAdjustmentDetails = null;

				frmGLAccrualBreakup.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdBreakupVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdBreakupVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{

			if (ColIndex == cGABDAmount)
			{ // Or ColIndex = cGABDDebitAmt Then
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,###,###.000");
				}
				else
				{
					Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "0.000");
				}
			}

		}

		private void grdBreakupVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			if (mFirstGridFocus)
			{
				if (Convert.ToString(cmbMastersList.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList);
				}

				DefineMasterRecordset();
				mFirstGridFocus = false;
			}
			else
			{

			}
		}

		private void grdBreakupVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdBreakupVoucherDetails.Col > 0 && LastCol > 0 && !mFirstGridFocus)
			{
				switch(grdBreakupVoucherDetails.Col)
				{
					case cGABDLdgrCode : case cGABDLdgrName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsLedgerCodeList); 
						break;
				}
			}

		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			string mysql = "";
			object mTempReturnValue = null;
			int mSetValueIndex = 0;

			if (SystemVariables.gSkipTextBoxLostFocus)
			{
				return;
			}

			try
			{

				switch(Index)
				{
					case cTcNewVoucherType : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name" : "a_voucher_name"); 
						mysql = mysql + ",'' from gl_accnt_voucher_types where voucher_type = " + txtCommonTextBox[Index].Text; 
						 
						mSetValueIndex = cDLblNewVoucherTypeName; 
						break;
					case cTcCreditAccountCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l.l_ldgr_name" : "l.a_ldgr_name"); 
						mysql = mysql + ",'' from gl_ledger l where l.ldgr_no ='" + txtCommonTextBox[Index].Text + "'"; 
						 
						mSetValueIndex = cDLblCreditLdgrName; 
						break;
					case cTcBreakupVoucherNo : 
						//'''always select the breakup voucher no from find window. 
						//'''this is because we are not asking for voucher type. 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "gavt.l_voucher_name" : "gavt.a_voucher_name"); 
						mysql = mysql + " , ( select isnull(sum(lc_amount),0)"; 
						mysql = mysql + " from gl_accnt_trans_details "; 
						mysql = mysql + " where entry_id = mt.entry_id and lc_amount > 0 ) "; 
						mysql = mysql + " , mt.voucher_date gl_breakup_voucher_date "; 
						mysql = mysql + " , it.voucher_no inv_no "; 
						mysql = mysql + " from gl_accnt_trans mt "; 
						mysql = mysql + " inner join ICS_Transaction it on mt.linked_entry_id = it.entry_id "; 
						mysql = mysql + " inner join ICS_Transaction_Types ivt on it.voucher_type = ivt.voucher_type "; 
						mysql = mysql + " inner join gl_ledger l on it.ldgr_cd = l.ldgr_cd "; 
						mysql = mysql + " inner join gl_accnt_voucher_types gavt on mt.voucher_type = gavt.voucher_type "; 
						mysql = mysql + " where ivt.parent_type = 201 "; 
						mysql = mysql + " and it.status = 2 "; 
						mysql = mysql + " and mt.linked_type_flag = 1 "; 
						mysql = mysql + " and not exists( select entry_id from gl_accrual_breakup_master gabm "; 
						mysql = mysql + " where gabm.linked_entry_id = mt.entry_id) "; 
						mysql = mysql + " and mt.entry_id='" + Conversion.Val(Convert.ToString(txtCommonTextBox[Index].Tag)).ToString() + "'"; 
						 
						mSetValueIndex = cDLblBreakupVoucherType; 
						break;
					default:
						mSetValueIndex = 0; 
						break;
				}

				if (mSetValueIndex > 0)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[Index].Text, SystemVariables.DataType.StringType))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempReturnValue))
						{
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[mSetValueIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempReturnValue).GetValue(0));

							if (Index == cTcBreakupVoucherNo)
							{
								//UPGRADE_WARNING: (1068) mTempReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDebitAmount.Value = ReflectionHelper.GetPrimitiveValue(((Array) mTempReturnValue).GetValue(1));
								txtDisplayLabel[cDLblBreakupVoucherDate].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempReturnValue).GetValue(2)), SystemVariables.gSystemDateFormat);
								//UPGRADE_WARNING: (1068) mTempReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDisplayLabel[cDLblBreakupInvNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempReturnValue).GetValue(3));

								//                txtDFromDate.Value = Format(mTempReturnValue(2), gSystemDateFormat)
								//                txtDToDate.Value = Format(mTempReturnValue(2), gSystemDateFormat)
								GetBreakupVoucherDetails(Convert.ToInt32(Double.Parse(Convert.ToString(txtCommonTextBox[Index].Tag))));
							}
						}
					}
					else
					{
						txtDisplayLabel[mSetValueIndex].Text = "";
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
					if (txtCommonTextBox[Index].Enabled)
					{
						txtCommonTextBox[Index].Focus();
					}
				}
				else
				{
					//
				}
			}


		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
		}

		public void GetRecord(object pSearchValue)
		{
			int cnt = 0;
			SqlDataReader rsLocalRec1 = null;



			if (SystemProcedure2.IsItEmpty(pSearchValue, SystemVariables.DataType.NumberType))
			{
				return;
			}

			string mysql = " select gabm.voucher_no, gabm.entry_id ";
			mysql = mysql + " , mt.voucher_no as breakup_voucher_no "; //, mt.entry_id as gl_entry_id "
			mysql = mysql + " , mt.entry_id gl_entry_id ";
			mysql = mysql + " , mt.voucher_date gl_breakup_voucher_date ";
			mysql = mysql + " , gabm.status, gabm.posted_gl ";
			mysql = mysql + " , gabm.lc_amount , gabm.Comments, gabm.time_stamp ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " gavt.l_voucher_name " : " gavt.a_voucher_name ") + " as breakup_voucher_name ";
			mysql = mysql + " , gavt1.voucher_type new_gl_voucher_type ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " gavt1.l_voucher_name " : " gavt1.a_voucher_name ") + " as new_gl_voucher_name ";
			mysql = mysql + " , it.voucher_no inv_no ";
			mysql = mysql + " from gl_accrual_breakup_master gabm ";
			mysql = mysql + " inner join gl_accnt_trans mt on gabm.linked_entry_id = mt.entry_id ";
			mysql = mysql + " inner join gl_accnt_voucher_types gavt on mt.voucher_type = gavt.voucher_type ";
			mysql = mysql + " inner join gl_accnt_voucher_types gavt1 on gabm.gl_voucher_type = gavt1.voucher_type ";
			mysql = mysql + " inner join ICS_Transaction it on mt.linked_entry_id = it.entry_id ";
			mysql = mysql + " where gabm.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

			DataSet rsLocalRec = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsLocalRec.Tables.Clear();
			adap.Fill(rsLocalRec);
			if (rsLocalRec.Tables[0].Rows.Count != 0)
			{
				CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				SearchValue = rsLocalRec.Tables[0].Rows[0]["entry_id"];
				mTimeStamp = SystemProcedure2.tsFormat(Convert.ToString(rsLocalRec.Tables[0].Rows[0]["time_stamp"]));

				txtCommonTextBox[cTcBreakupVoucherNo].Enabled = false;
				//''this doevents helps in evecuting the lost event of above control instead of it getting
				//''executed after getrecord event.
				Application.DoEvents();

				//Set the form caption and Get the Voucher Status
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, Convert.ToInt32(rsLocalRec.Tables[0].Rows[0]["status"]), CurrentFormMode, "GL Accrual Breakup ", "Transaction");
				//''''*************************************************************************

				txtCommonTextBox[cTcTransactionNo].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["voucher_no"]);
				txtCommonTextBox[cTcBreakupVoucherNo].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["breakup_voucher_no"]);
				txtCommonTextBox[cTcBreakupVoucherNo].Tag = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["gl_entry_id"]);

				txtDisplayLabel[cDLblBreakupVoucherType].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["breakup_voucher_name"]);
				txtDisplayLabel[cDLblBreakupVoucherDate].Text = StringsHelper.Format(rsLocalRec.Tables[0].Rows[0]["gl_breakup_voucher_date"], SystemVariables.gSystemDateFormat);
				txtDisplayLabel[cDLblBreakupInvNo].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["inv_no"]);

				txtDebitAmount.Value = rsLocalRec.Tables[0].Rows[0]["lc_amount"];

				txtCommonTextBox[cTcNewVoucherType].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["new_gl_voucher_type"]);
				txtDisplayLabel[cDLblNewVoucherTypeName].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["new_gl_voucher_name"]);

				GetBreakupVoucherDetails(Convert.ToInt32(rsLocalRec.Tables[0].Rows[0]["gl_entry_id"]));


				txtComments.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["comments"]) + "";

				//        mySql = " select min(from_date), max(to_date) "
				//        mySql = mySql & " from gl_accrual_breakup_details "
				//        mySql = mySql & " where entry_id=" & SearchValue
				//        mReturnValues = GetMasterCode(mySql)
				//        If Not IsNull(mReturnValues) Then
				//            txtDFromDate.Value = mReturnValues(0)
				//            txtDToDate.Value = mReturnValues(1)
				//        End If

				SystemGrid.DefineVoucherArray(aNewAdjustmentDetails, mMaxColNewAdjustmentDetails, -1, true);

				mysql = " select gabd.from_date, gabd.to_date";
				mysql = mysql + " , l.ldgr_no as debit_ldgr_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l.l_ldgr_name " : " l.a_ldgr_name ") + " as debit_ldgr_name ";
				mysql = mysql + " , l1.ldgr_no as credit_ldgr_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l1.l_ldgr_name " : " l1.a_ldgr_name ") + " as credit_ldgr_name ";
				mysql = mysql + " , gabd.lc_amount ";
				mysql = mysql + " , gabd.linked_invnt_line_no ";
				mysql = mysql + " , p.part_no as part_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " p.l_prod_name " : " p.a_prod_name ") + " as prod_name ";
				mysql = mysql + " from gl_accrual_breakup_details gabd ";
				mysql = mysql + " inner join gl_ledger l on gabd.debit_ldgr_cd = l.ldgr_cd ";
				mysql = mysql + " inner join gl_ledger l1 on gabd.credit_ldgr_cd = l1.ldgr_cd ";
				mysql = mysql + " inner join ICS_Transaction_Details idt on idt.line_no = gabd.linked_invnt_line_no ";
				mysql = mysql + " inner join ICS_Item p on p.prod_cd = idt.prod_cd ";
				mysql = mysql + " where gabd.entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec1 = sqlCommand_2.ExecuteReader();
				if (rsLocalRec1.Read())
				{
					txtCommonTextBox[cTcDebitAccountCode].Text = Convert.ToString(rsLocalRec1["debit_ldgr_no"]);
					txtDisplayLabel[cDLblDebitLdgrName].Text = Convert.ToString(rsLocalRec1["debit_ldgr_name"]);


					do 
					{
						SystemGrid.DefineVoucherArray(aNewAdjustmentDetails, mMaxColNewAdjustmentDetails, cnt, false);

						aNewAdjustmentDetails.SetValue(cnt + 1, cnt, cGAdjDSno);
						aNewAdjustmentDetails.SetValue(rsLocalRec1["from_date"], cnt, cGAdjDFromDate);
						aNewAdjustmentDetails.SetValue(rsLocalRec1["to_date"], cnt, cGAdjDToDate);
						aNewAdjustmentDetails.SetValue(rsLocalRec1["lc_amount"], cnt, cGAdjDAmt);

						aNewAdjustmentDetails.SetValue(rsLocalRec1["credit_ldgr_no"], cnt, cGAdjLdgrCode);
						aNewAdjustmentDetails.SetValue(rsLocalRec1["credit_ldgr_name"], cnt, cGAdjLdgrName);

						aNewAdjustmentDetails.SetValue(rsLocalRec1["part_no"], cnt, cGAdjProdCode);
						aNewAdjustmentDetails.SetValue(rsLocalRec1["prod_name"], cnt, cGAdjProdName);

						aNewAdjustmentDetails.SetValue(rsLocalRec1["linked_invnt_line_no"], cnt, cGAdjInvntLineNo);

						cnt++;
					}
					while(rsLocalRec1.Read());
				}
				rsLocalRec1.Close();

				//        grdBreakupVoucherDetails.ReBind
				//        grdBreakupVoucherDetails.Refresh

				grdNewAllocationDetails.Rebind(true);
				grdNewAllocationDetails.Refresh();

				mysql = " select min(gabd.from_date) from_date, max(gabd.to_date) to_date ";
				mysql = mysql + " , gabd.linked_invnt_line_no  line_no , l1.ldgr_no as ldgr_no  ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l1.l_ldgr_name " : " l1.a_ldgr_name ") + " as credit_ldgr_name ";
				mysql = mysql + " from gl_accrual_breakup_details gabd ";
				mysql = mysql + " inner join gl_ledger l1 on gabd.credit_ldgr_cd = l1.ldgr_cd ";
				mysql = mysql + " Where gabd.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				mysql = mysql + " group by  gabd.linked_invnt_line_no  , l1.ldgr_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l1.l_ldgr_name " : " l1.a_ldgr_name ");
				SqlCommand sqlCommand_3 = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec1 = sqlCommand_3.ExecuteReader();
				bool rsLocalRec1DidRead2 = rsLocalRec1.Read();
				do 
				{
					int tempForEndVar = aBreakupVoucherDetails.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						if (Conversion.Val(Convert.ToString(aBreakupVoucherDetails.GetValue(cnt, cGABDInvntLineNo))) == Convert.ToDouble(rsLocalRec1["line_no"]))
						{
							aBreakupVoucherDetails.SetValue(rsLocalRec1["from_date"], cnt, cGABDFromDate);
							aBreakupVoucherDetails.SetValue(rsLocalRec1["to_date"], cnt, cGABDToDate);
							aBreakupVoucherDetails.SetValue(rsLocalRec1["ldgr_no"], cnt, cGABDLdgrCode);
							aBreakupVoucherDetails.SetValue(rsLocalRec1["credit_ldgr_name"], cnt, cGABDLdgrName);
						}
					}
				}
				while(rsLocalRec1.Read());
				rsLocalRec1.Close();

				grdBreakupVoucherDetails.Rebind(true);
				grdBreakupVoucherDetails.Refresh();
			}

		}

		public void CloseForm()
		{
			this.Close();
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

			if (mObjectName == "txtCommonTextBox")
			{
				txtCommonTextBox[mIndex].Text = "";
				switch(mIndex)
				{
					case cTcNewVoucherType : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(100, "712")); 
						break;
					case cTcCreditAccountCode : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2")); 
						break;
					case cTcBreakupVoucherNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000114, "1773")); 
						break;
					default:
						return;
				}
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				if (mObjectName == "txtCommonTextBox")
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[mIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));

					if (mIndex == cTcBreakupVoucherNo)
					{
						txtCommonTextBox[mIndex].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0));
					}

					txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdNewAllocationDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdNewAllocationDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{

			if (ColIndex == cGAdjDAmt)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,###,###.000");
				}
				else
				{
					Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "0.000");
				}
			}

		}

		public bool CheckDataValidity()
		{

			int cnt = 0;

			grdBreakupVoucherDetails.UpdateData();
			grdNewAllocationDetails.UpdateData();

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 2);
				goto mend;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[cTcBreakupVoucherNo].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Breakup Voucher No.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);

				if (txtCommonTextBox[cTcBreakupVoucherNo].Enabled)
				{
					txtCommonTextBox[cTcBreakupVoucherNo].Focus();
				}
				goto mend;
			}

			if (SystemProcedure2.IsItEmpty(txtDebitAmount.Value, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter value for Debit Amount.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);

				if (txtDebitAmount.Enabled)
				{
					txtDebitAmount.Focus();
				}
				goto mend;
			}
			//
			//If IsItEmpty(txtCommonTextBox(cTcCreditAccountCode).Text, NumberType) Then
			//    MsgBox "Enter Credit Account Code.", vbInformation, "Required"
			//
			//    If txtCommonTextBox(cTcCreditAccountCode).Enabled = True Then
			//         txtCommonTextBox(cTcCreditAccountCode).SetFocus
			//    End If
			//    GoTo mend
			//End If

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[cTcNewVoucherType].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Voucher Type.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);

				if (txtCommonTextBox[cTcNewVoucherType].Enabled)
				{
					txtCommonTextBox[cTcNewVoucherType].Focus();
				}
				goto mend;
			}

			//If IsItEmpty(txtBreakupPeriod.Value, NumberType) Then
			//    MsgBox "Enter value for Breakup Period", vbInformation, "Required"
			//
			//    If txtBreakupPeriod.Enabled = True Then
			//         txtBreakupPeriod.SetFocus
			//    End If
			//    GoTo mend
			//End If

			if (aNewAdjustmentDetails.GetUpperBound(0) < 0)
			{
				MessageBox.Show("No Break up details to save.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);

				//    If txtBreakupPeriod.Enabled = True Then
				//         txtBreakupPeriod.SetFocus
				//    End If
				goto mend;
			}

			int tempForEndVar = aNewAdjustmentDetails.GetUpperBound(0);
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (SystemProcedure2.IsItEmpty(aNewAdjustmentDetails.GetValue(cnt, cGAdjDFromDate), SystemVariables.DataType.DateType))
				{
					MessageBox.Show("Enter Valid From date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					grdNewAllocationDetails.Bookmark = cnt;
					grdNewAllocationDetails.Col = cGAdjDFromDate;
					grdNewAllocationDetails.Refresh();
					grdNewAllocationDetails.Focus();
					goto mend;
				}
				else
				{
					if (!SystemProcedure2.ValidDateRange(Convert.ToDateTime(aNewAdjustmentDetails.GetValue(cnt, cGAdjDFromDate))))
					{
						MessageBox.Show("Invalid Date Range, Check the current financial year", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdNewAllocationDetails.Bookmark = cnt;
						grdNewAllocationDetails.Col = cGAdjDFromDate;
						grdNewAllocationDetails.Refresh();
						grdNewAllocationDetails.Focus();
						goto mend;
					}
				}

				if (SystemProcedure2.IsItEmpty(aNewAdjustmentDetails.GetValue(cnt, cGAdjDToDate), SystemVariables.DataType.DateType))
				{
					MessageBox.Show("Enter Valid To date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					grdNewAllocationDetails.Bookmark = cnt;
					grdNewAllocationDetails.Col = cGAdjDToDate;
					grdNewAllocationDetails.Refresh();
					grdNewAllocationDetails.Focus();
					goto mend;
				}
				else
				{
					if (!SystemProcedure2.ValidDateRange(Convert.ToDateTime(aNewAdjustmentDetails.GetValue(cnt, cGAdjDToDate))))
					{
						MessageBox.Show("Invalid Date Range, Check the current financial year", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdNewAllocationDetails.Bookmark = cnt;
						grdNewAllocationDetails.Col = cGAdjDToDate;
						grdNewAllocationDetails.Refresh();
						grdNewAllocationDetails.Focus();
						goto mend;
					}
				}

				if (SystemProcedure2.IsItEmpty(aNewAdjustmentDetails.GetValue(cnt, cGAdjDAmt), SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Enter Valid Amount", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					grdNewAllocationDetails.Bookmark = cnt;
					grdNewAllocationDetails.Col = cGAdjDAmt;
					grdNewAllocationDetails.Refresh();
					grdNewAllocationDetails.Focus();
					goto mend;
				}
			}


			return true;

			goto mend;
			return false;

			mend:
			return false;
		}


		public bool saveRecord(bool pApprove = false)
		{

			bool result = false;
			object mTempValue = null;
			string mysql = "";
			int mBreakupEntryId = 0;

			int mNewEntryID = 0;
			//Dim mGLCreditAccountCd As Long
			int mGLDebitAccountCd = 0;
			int mGLVoucherType = 0;

			clsHourGlass myHourGlass = new clsHourGlass();


			try
			{


				//'''****************************Get the GL Voucher type****************************
				//''''****************************************************************************
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select voucher_type from gl_accnt_voucher_types where voucher_type=" + txtCommonTextBox[cTcNewVoucherType].Text));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempValue))
				{
					MessageBox.Show("Enter valid Voucher Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (txtCommonTextBox[cTcNewVoucherType].Enabled)
					{
						txtCommonTextBox[cTcNewVoucherType].Focus();
					}
					goto StationExitFunction;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mGLVoucherType = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
				}
				//''''****************************************************************************

				//''''****************************Get the GL Credit Account Code ******************
				//'''''****************************************************************************
				//mTempValue = GetMasterCode("select ldgr_cd from gl_ledger where ldgr_no='" & txtCommonTextBox(cTcCreditAccountCode).Text & "'")
				//If IsNull(mTempValue) Then
				//    MsgBox "Enter valid Credit Account Code.", vbInformation, "Error"
				//    If txtCommonTextBox(cTcCreditAccountCode).Enabled = True Then
				//        txtCommonTextBox(cTcCreditAccountCode).SetFocus
				//    End If
				//    GoTo StationExitFunction
				//Else
				//    mGLCreditAccountCd = mTempValue
				//End If
				//'''''****************************************************************************

				//'''****************************Get the GL Debit Account Code ******************
				//''''****************************************************************************
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select ldgr_cd from gl_ledger where ldgr_no='" + txtCommonTextBox[cTcDebitAccountCode].Text + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempValue))
				{
					MessageBox.Show("Enter valid Debit Account Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (txtCommonTextBox[cTcBreakupVoucherNo].Enabled)
					{
						txtCommonTextBox[cTcBreakupVoucherNo].Focus();
					}
					goto StationExitFunction;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mGLDebitAccountCd = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
				}
				//''''****************************************************************************


				//'''****************************Get the Breakup Voucher EntryId *****************
				//''''****************************************************************************
				if (SystemProcedure2.IsItEmpty(Convert.ToString(txtCommonTextBox[cTcBreakupVoucherNo].Tag), SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Select a valid Breakup Voucher ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonTextBox[cTcBreakupVoucherNo].Text = "";
					if (txtCommonTextBox[cTcBreakupVoucherNo].Enabled)
					{
						txtCommonTextBox[cTcBreakupVoucherNo].Focus();
					}
					goto StationExitFunction;
				}

				mysql = " select mt.entry_id from gl_accnt_trans mt ";
				mysql = mysql + " inner join ICS_Transaction it on mt.linked_entry_id = it.entry_id ";
				mysql = mysql + " inner join ICS_Transaction_Types ivt on it.voucher_type = ivt.voucher_type ";
				mysql = mysql + " inner join gl_ledger l on it.ldgr_cd = l.ldgr_cd ";
				mysql = mysql + " inner join gl_accnt_voucher_types gavt on mt.voucher_type = gavt.voucher_type ";
				mysql = mysql + " where ivt.parent_type = 201 ";
				mysql = mysql + " and it.status = 2 ";
				mysql = mysql + " and mt.linked_type_flag = 1 ";
				mysql = mysql + " and not exists( select gabm.entry_id from gl_accrual_breakup_master gabm ";
				mysql = mysql + " where gabm.linked_entry_id = mt.entry_id ";
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					mysql = mysql + " and gabm.entry_id <> " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				}
				mysql = mysql + " ) ";
				mysql = mysql + " and mt.entry_id =" + Convert.ToString(txtCommonTextBox[cTcBreakupVoucherNo].Tag);

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempValue))
				{
					MessageBox.Show("Select a valid Breakup Voucher ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (txtCommonTextBox[cTcBreakupVoucherNo].Enabled)
					{
						txtCommonTextBox[cTcBreakupVoucherNo].Focus();
					}
					goto StationExitFunction;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mBreakupEntryId = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
				}
				//''''****************************************************************************


				SystemVariables.gConn.BeginTransaction();

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{

					//''''****************************************************************************
					//I '''''''''''''N'''''''''''''S'''''''''''''E'''''''''''''R'''''''''''T
					//''''****************************************************************************

					txtCommonTextBox[cTcTransactionNo].Text = SystemProcedure2.GetNewNumber("gl_accrual_breakup_master", "voucher_no");


					//''''***************Insert into the master table*****************************
					mNewEntryID = InsertMasterRecord(Convert.ToInt32(Double.Parse(txtCommonTextBox[cTcTransactionNo].Text)), mBreakupEntryId, ReflectionHelper.GetPrimitiveValue<decimal>(txtDebitAmount.Value), mGLVoucherType, txtComments.Text);
					//''''************************************************************************

					//''''***************Insert Details ********************************
					if (!InsertDetailsRecord(mNewEntryID, mGLDebitAccountCd))
					{
						goto StationRollBackTrans;
					}
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
					mysql = " select time_stamp from gl_accrual_breakup_master ";
					mysql = mysql + " where entry_id=" + Conversion.Str(mNewEntryID);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//if the time stamp does not match the previous one then rollback
					if (SystemProcedure2.tsFormat(ReflectionHelper.GetPrimitiveValue<string>(mTempValue)) != mTimeStamp)
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						goto StationRollBackTrans;
					}
					//''''*************************************************************************

					UpdateMasterRecord(mNewEntryID, mBreakupEntryId, ReflectionHelper.GetPrimitiveValue<decimal>(txtDebitAmount.Value), mGLVoucherType, txtComments.Text);

					mysql = " delete from gl_accrual_breakup_details ";
					mysql = mysql + " where entry_id =" + mNewEntryID.ToString();
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();


					//''''***************Expenses and Charges Details ********************************
					if (!InsertDetailsRecord(mNewEntryID, mGLDebitAccountCd))
					{
						goto StationRollBackTrans;
					}
					//''''************************************************************************
				}


				//''''*************************************************************************
				//Approve (Change the status to 2)
				if (pApprove)
				{
					SystemICSProcedure.ApproveTransaction("gl_accrual_breakup_master", mNewEntryID);


					if (!PostGLAccrualBreakup(mNewEntryID))
					{
						goto StationRollBackTrans;
					}
				}

				//''''*************************************************************************

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();



				//''''*************************************************************************
				//Display a messbox if the auto generate voucher no is true and it is in addmode
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = SystemConstants.msg20 + txtCommonTextBox[cTcTransactionNo].Text;
					MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}


				return true;


				//''''*************************************************************************
				StationExitFunction:
				//This code is executed when there is error before begin trans
				return false;
				//''''*************************************************************************


				//''''*************************************************************************
				StationRollBackTrans:
				//This code is executed when there is error after begin trans
				result = false;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
			}
			catch (System.Exception excep)
			{
				//''''*************************************************************************


				//''''*************************************************************************
				//All other Errors.
				int mReturnErrorType = 0;

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_table_Name"]), "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				if (mReturnErrorType == 1)
				{
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					AddRecord();
					result = false;
				}
				else if (mReturnErrorType == 3)
				{ 
					AddRecord();
					result = false;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		private int InsertMasterRecord(int pVoucherNo, int pLinkedEntryId, decimal pLCAmount, int pGLVoucherType, string pComments)
		{

			string mysql = " insert into gl_accrual_breakup_master ";
			mysql = mysql + " (voucher_no, linked_entry_id, lc_amount, gl_voucher_type, comments, user_cd) ";
			mysql = mysql + " values ( ";
			mysql = mysql + pVoucherNo.ToString();
			mysql = mysql + " , " + pLinkedEntryId.ToString();
			mysql = mysql + " , " + pLCAmount.ToString();
			mysql = mysql + " , " + pGLVoucherType.ToString();
			mysql = mysql + " , N'" + pComments + "'";
			mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
			mysql = mysql + " )";

			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			return ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));

		}

		private int UpdateMasterRecord(int pEntryId, int pLinkedEntryId, decimal pLCAmount, int pGLVoucherType, string pComments)
		{

			string mysql = " update gl_accrual_breakup_master ";
			mysql = mysql + " set ";
			mysql = mysql + " gl_voucher_type =" + pGLVoucherType.ToString();
			mysql = mysql + " , linked_entry_id =" + pLinkedEntryId.ToString();
			mysql = mysql + " , lc_amount =" + pLCAmount.ToString();
			mysql = mysql + " , user_cd =" + SystemVariables.gLoggedInUserCode.ToString();
			mysql = mysql + " , comments =N'" + pComments + "'";
			mysql = mysql + " where entry_id=" + pEntryId.ToString();
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			return 0;
		}

		public void AddRecord()
		{
			try
			{


				//''''*************************************************************************
				//Set the form caption
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, "GL Accrual Breakup", "Transaction");
				//''''*************************************************************************


				SystemGrid.DefineVoucherArray(aBreakupVoucherDetails, mMaxColBreakupVoucherDetails, -1, true);
				SystemGrid.DefineVoucherArray(aNewAdjustmentDetails, mMaxColNewAdjustmentDetails, -1, true);

				grdBreakupVoucherDetails.Rebind(true);
				grdNewAllocationDetails.Rebind(true);

				SystemProcedure2.ClearTextBox(this);
				txtDebitAmount.Value = 0;

				SearchValue = ""; //Change the msearchvalue to blank
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive; //set new voucher status to active by default
				mFirstGridFocus = true;

				txtCommonTextBox[cTcBreakupVoucherNo].Enabled = true;


				txtCommonTextBox[cTcNewVoucherType].Text = "103";
				txtCommonTextBox_Leave(txtCommonTextBox[cTcNewVoucherType], new EventArgs());

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
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000116));
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

			int cnt = 0;
			int tempForEndVar = aNewAdjustmentDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aNewAdjustmentDetails.SetValue(cnt + 1, cnt, cGAdjDSno);
			}
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
					mysql = " delete from gl_accrual_breakup_details  ";
					mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mysql = " delete from gl_accrual_breakup_master ";
					mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
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
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_table_Name"]), "Deleterecord", SystemConstants.msg10);
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

						SystemICSProcedure.ApproveTransaction("gl_accrual_breakup_master", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));

						if (!PostGLAccrualBreakup(ReflectionHelper.GetPrimitiveValue<int>(SearchValue)))
						{
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							result = false;
							goto mDestroy;
						}


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


		private bool InsertDetailsRecord(int pEntryId, int pDebitLdgrCd)
		{

			StringBuilder mysql = new StringBuilder();
			int mGLCreditAccountCd = 0;
			object mTempValue = null;
			int cnt = 0;
			//Dim mGABDLineNo As Long

			int tempForEndVar = aNewAdjustmentDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{

				//'''****************************Get the GL Credit Account Code ******************
				//''''****************************************************************************
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select ldgr_cd from gl_ledger where ldgr_no='" + Convert.ToString(aNewAdjustmentDetails.GetValue(cnt, cGAdjLdgrCode)) + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempValue))
				{
					MessageBox.Show("Enter valid Credit Account Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mGLCreditAccountCd = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
				}
				//''''****************************************************************************

				mysql = new StringBuilder(" insert into gl_accrual_breakup_details ");
				mysql.Append(" (entry_id, from_date, to_date,debit_ldgr_cd, credit_ldgr_cd, lc_amount, linked_invnt_line_no) ");
				mysql.Append(" values( ");
				mysql.Append(Conversion.Str(pEntryId));
				mysql.Append(",'" + StringsHelper.Format(aNewAdjustmentDetails.GetValue(cnt, cGAdjDFromDate), SystemVariables.gSystemDateFormat) + "'");
				mysql.Append(",'" + StringsHelper.Format(aNewAdjustmentDetails.GetValue(cnt, cGAdjDToDate), SystemVariables.gSystemDateFormat) + "'");
				mysql.Append("," + pDebitLdgrCd.ToString());
				mysql.Append("," + mGLCreditAccountCd.ToString());
				mysql.Append("," + Convert.ToString(aNewAdjustmentDetails.GetValue(cnt, cGAdjDAmt)));
				mysql.Append("," + Convert.ToString(aNewAdjustmentDetails.GetValue(cnt, cGAdjInvntLineNo)));
				mysql.Append(" ) ");

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql.ToString();
				TempCommand.ExecuteNonQuery();


				//    mGABDLineNo = GetMasterCode("select scope_identity()")
				//    cnt1 = 0
				//    For cnt1 = 0 To aNewAdjustmentDetails.Count(1) - 1
				//        If aNewAdjustmentDetails(cnt, cGAdjInvntLineNo) = aBreakupVoucherDetails(cnt, cGABDInvntLineNo) Then
				//            mySql = " insert into gl_accrual_breakup_allocation_details "
				//            mySql = mySql & " (gabd_line_no, from_date, to_date, lc_amount) "
				//            mySql = mySql & " values ( "
				//            mySql = mySql & Str(mGABDLineNo)
				//            mySql = mySql & ",'" & Format(aNewAdjustmentDetails(cnt1, cGAdjDFromDate), gSystemDateFormat) & "'"
				//            mySql = mySql & ",'" & Format(aNewAdjustmentDetails(cnt1, cGAdjDToDate), gSystemDateFormat) & "'"
				//            mySql = mySql & "," & aNewAdjustmentDetails(cnt, cGAdjDAmt)
				//            mySql = mySql & " ) "
				//            gConn.Execute mySql
				//        End If
				//    Next cnt1
			}


			return true;

			MessageBox.Show(Information.Err().Description, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			return false;
		}


		private void GetBreakupVoucherDetails(int pEntryId)
		{

			int cnt = 0;
			int mLinkedEntryId = 0;

			SqlDataReader rsTempRec = null;

			string mysql = " select top 1 l.ldgr_no ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l.l_ldgr_name" : "l.a_ldgr_name") + " as ldgr_name ";
			mysql = mysql + " , case when dt.lc_amount > 0 then dt.lc_amount else 0 end as debit_amt ";
			mysql = mysql + " , case when dt.lc_amount < 0 then (dt.lc_amount * -1) else 0 end as credit_amt ";
			mysql = mysql + " , dt.comments, dt.dr_cr_type , mt.linked_entry_id ";
			mysql = mysql + " from gl_accnt_trans_details dt ";
			mysql = mysql + " inner join gl_accnt_trans mt on mt.entry_id = dt.entry_id ";
			mysql = mysql + " inner join gl_ledger l on dt.ldgr_cd = l.ldgr_cd ";
			mysql = mysql + " where dt.entry_id =" + Conversion.Str(pEntryId);
			mysql = mysql + " and dt.dr_cr_type = 'C' ";
			mysql = mysql + " order by dt.dr_cr_type desc ";

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();

			//   Do While Not .EOF
			//        Call DefineVoucherArray(aBreakupVoucherDetails, mMaxColBreakupVoucherDetails, cnt, False)
			//
			//        'Get the details information into the grid
			//        aBreakupVoucherDetails(cnt, cGABDSno) = cnt + 1
			//        aBreakupVoucherDetails(cnt, cGABDLdgrNo) = Trim(.Fields("ldgr_no").Value)
			//        aBreakupVoucherDetails(cnt, cGABDLdgrName) = Trim(.Fields("ldgr_name").Value)
			//        aBreakupVoucherDetails(cnt, cGABDDebitAmt) = Trim(.Fields("debit_amt").Value)
			//        aBreakupVoucherDetails(cnt, cGABDCreditAmt) = Trim(.Fields("credit_amt").Value)
			//        aBreakupVoucherDetails(cnt, cGABDRemarks) = Trim(.Fields("comments").Value)

			mLinkedEntryId = Convert.ToInt32(rsTempRec["linked_entry_id"]);

			txtCommonTextBox[cTcDebitAccountCode].Text = Convert.ToString(rsTempRec["ldgr_no"]).Trim();
			txtDisplayLabel[cDLblDebitLdgrName].Text = Convert.ToString(rsTempRec["ldgr_name"]).Trim();

			//        cnt = cnt + 1
			//        .MoveNext
			//    Loop



			mysql = " select p.part_no ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "p.l_prod_name" : "p.a_prod_name") + " as prod_name ";
			mysql = mysql + " , dt.lc_amount , dt.reference_no ";
			mysql = mysql + " , dt.line_no ";
			mysql = mysql + " from ICS_Transaction mt ";
			mysql = mysql + " inner join ICS_Transaction_Details dt on mt.entry_id = dt.entry_id ";
			mysql = mysql + " inner join ICS_Item p on dt.prod_cd = p.prod_cd ";
			mysql = mysql + " where dt.entry_id =" + Conversion.Str(mLinkedEntryId);
			mysql = mysql + " and dt.item_type_cd = " + SystemICSConstants.ptServiceTypeID.ToString();

			SystemGrid.DefineVoucherArray(aBreakupVoucherDetails, mMaxColBreakupVoucherDetails, -1, true);

			SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand_2.ExecuteReader();
			bool rsTempRecDidRead2 = rsTempRec.Read();

			do 
			{
				SystemGrid.DefineVoucherArray(aBreakupVoucherDetails, mMaxColBreakupVoucherDetails, cnt, false);

				//Get the details information into the grid
				aBreakupVoucherDetails.SetValue(cnt + 1, cnt, cGABDSno);
				aBreakupVoucherDetails.SetValue(Convert.ToString(rsTempRec["part_no"]).Trim(), cnt, cGABDProdCode);
				aBreakupVoucherDetails.SetValue(Convert.ToString(rsTempRec["prod_name"]).Trim(), cnt, cGABDProdName);
				aBreakupVoucherDetails.SetValue(Convert.ToString(rsTempRec["lc_amount"]).Trim(), cnt, cGABDAmount);
				aBreakupVoucherDetails.SetValue(Convert.ToString(rsTempRec["reference_no"]).Trim(), cnt, cGABDRemarks);
				aBreakupVoucherDetails.SetValue(Convert.ToString(rsTempRec["line_no"]).Trim(), cnt, cGABDInvntLineNo);

				cnt++;
			}
			while(rsTempRec.Read());

			grdBreakupVoucherDetails.Rebind(true);
			grdBreakupVoucherDetails.Refresh();
			rsTempRec.Close();

		}

		private bool PostGLAccrualBreakup(int pEntryId)
		{

			object mDefaultGlVoucherType = null;
			int mCreditLdgrCd = 0;
			int mDebitLdgrCd = 0;
			string mVoucherDate = "";
			decimal mDrCrAmt = 0;
			int mVoucherNo = 0;
			string mHeaderRemarks = "";
			string mDetailRemarks = "";
			int mVoucherEntryId = 0;



			//''''GL entry to generated as follows
			//        Sales A/c         Dr
			//            To Sales Accrual a/c
			//'''''''''''''''''''''''''''''''''''''''''
			//'''''Note:'''''''''''''''''''''''''''''''

			string mysql = " select gabm.gl_voucher_type, gabd.entry_id, gabd.from_date, gabd.to_date, gabd.debit_ldgr_cd, gabd.credit_ldgr_cd  ";
			mysql = mysql + " , gabd.lc_amount, gabd.line_no , it.voucher_no ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_ldgr_name " : "a_ldgr_name ") + " as ldgr_name ";
			mysql = mysql + " from gl_accrual_breakup_master gabm ";
			mysql = mysql + " inner join gl_accrual_breakup_details gabd on gabm.entry_id = gabd.entry_id ";
			mysql = mysql + " inner join gl_accnt_trans mt on gabm.linked_entry_id = mt.entry_id ";
			mysql = mysql + " inner join ICS_Transaction it on mt.linked_entry_id = it.entry_id ";
			mysql = mysql + " inner join gl_ledger l on it.ldgr_cd = l.ldgr_cd ";
			mysql = mysql + " where gabm.entry_id =" + pEntryId.ToString();

			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{

				mDefaultGlVoucherType = rsTempRec["gl_voucher_type"];
				mVoucherDate = Convert.ToString(rsTempRec["from_date"]);
				mDebitLdgrCd = Convert.ToInt32(rsTempRec["debit_ldgr_cd"]);
				mCreditLdgrCd = Convert.ToInt32(rsTempRec["credit_ldgr_cd"]);
				mDetailRemarks = StringsHelper.Format(rsTempRec["from_date"], SystemVariables.gSystemDateFormat) + " To " + StringsHelper.Format(rsTempRec["to_date"], SystemVariables.gSystemDateFormat);
				mHeaderRemarks = ("Inv. No.: " + Convert.ToString(rsTempRec["voucher_no"]) + ", Client: " + Convert.ToString(rsTempRec["ldgr_name"])).Substring(0, Math.Min(200, ("Inv. No.: " + Convert.ToString(rsTempRec["voucher_no"]) + ", Client: " + Convert.ToString(rsTempRec["ldgr_name"])).Length));
				if (!SystemProcedure2.ValidDateRange(DateTime.Parse(mVoucherDate)))
				{
					MessageBox.Show("Invalid Date, Not in the accounting period defined", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				mysql = " voucher_type =" + ReflectionHelper.GetPrimitiveValue<string>(mDefaultGlVoucherType);
				mVoucherNo = Convert.ToInt32(Double.Parse(SystemProcedure2.GetNewNumber("gl_accnt_trans", "voucher_no", 2, mysql, " tablock(xlock) ")));

				mVoucherEntryId = SystemFAProcedure.FAInsertGLHeaderEntry(ReflectionHelper.GetPrimitiveValue<int>(mDefaultGlVoucherType), StringsHelper.Format(mVoucherDate, SystemVariables.gSystemDateFormat), mVoucherNo, "", mHeaderRemarks, 2, SystemVariables.gLoggedInUserCode);

				mDrCrAmt = Convert.ToDecimal(rsTempRec["lc_amount"]);

				if (mDrCrAmt > 0)
				{
					//'''''''Debit A/C Dr.
					SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, mDebitLdgrCd.ToString(), "1", 1, mDrCrAmt, 1 * mDrCrAmt, "D", StringsHelper.Format(mVoucherDate, SystemVariables.gSystemDateFormat), 1, 1, mDetailRemarks);

					//'''''''Credit A/C Dr.
					SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, mCreditLdgrCd.ToString(), "1", 1, mDrCrAmt * -1, (1 * mDrCrAmt) * -1, "C", StringsHelper.Format(mVoucherDate, SystemVariables.gSystemDateFormat), 1, 1, mDetailRemarks);
				}
				else
				{
					return false;
				}

				mysql = " update gl_accrual_breakup_details ";
				mysql = mysql + " set gl_generated_entry_id =" + mVoucherEntryId.ToString();
				mysql = mysql + " where line_no =" + Convert.ToString(rsTempRec["line_no"]);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

			}
			while(rsTempRec.Read());
			rsTempRec.Close();

			mysql = " update gl_accrual_breakup_master ";
			mysql = mysql + " set posted_gl = 1";
			mysql = mysql + " where entry_id =" + pEntryId.ToString();
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();


			return true;
		}

		private void AutoAllocateDetails()
		{

			string mysql = "";
			object mReturnValue = null;
			int cnt = 0;
			decimal mAmount = 0;
			decimal mBalanceAmt = 0;
			decimal mAdjustmentAmt = 0;

			System.DateTime mLastDate = DateTime.FromOADate(0);
			System.DateTime mFromDate = DateTime.FromOADate(0);
			//Dim mToDate As Date
			int mTotalDays = 0;


			if (aBreakupVoucherDetails.GetLength(0) < 0)
			{
				MessageBox.Show(" Select voucher breakup details", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}


			SystemGrid.DefineVoucherArray(aNewAdjustmentDetails, mMaxColNewAdjustmentDetails, -1, true);
			int cnt1 = 0;
			grdBreakupVoucherDetails.UpdateData();

			int tempForEndVar = aBreakupVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{

				if (!(Information.IsDate(aBreakupVoucherDetails.GetValue(cnt, cGABDFromDate))))
				{
					MessageBox.Show("Invalid From Date ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					grdBreakupVoucherDetails.Bookmark = cnt;
					grdBreakupVoucherDetails.Focus();
					return;
				}

				if (!(Information.IsDate(aBreakupVoucherDetails.GetValue(cnt, cGABDToDate))))
				{
					MessageBox.Show("Invalid To Date ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					grdBreakupVoucherDetails.Bookmark = cnt;
					grdBreakupVoucherDetails.Focus();
					return;
				}

				if (Convert.ToDateTime(aBreakupVoucherDetails.GetValue(cnt, cGABDFromDate)) > Convert.ToDateTime(aBreakupVoucherDetails.GetValue(cnt, cGABDToDate)))
				{
					MessageBox.Show("From Date cannot be greater than To Date ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					grdBreakupVoucherDetails.Bookmark = cnt;
					grdBreakupVoucherDetails.Focus();
					return;
				}

				if (SystemProcedure2.IsItEmpty(aBreakupVoucherDetails.GetValue(cnt, cGABDLdgrCode), SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Invalid Credit Ledger Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					grdBreakupVoucherDetails.Bookmark = cnt;
					grdBreakupVoucherDetails.Focus();
					return;
				}

				mysql = " select ldgr_cd from gl_ledger ";
				mysql = mysql + " where ldgr_no ='" + Convert.ToString(aBreakupVoucherDetails.GetValue(cnt, cGABDLdgrCode)) + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Credit ledger code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					grdBreakupVoucherDetails.Bookmark = cnt;
					grdBreakupVoucherDetails.Focus();
					return;
				}

				if (Conversion.Val(Convert.ToString(aBreakupVoucherDetails.GetValue(cnt, cGABDAmount))) > 0)
				{

					//Call DefineVoucherArray(aNewAdjustmentDetails, mMaxColNewAdjustmentDetails, -1, True)
					mFromDate = Convert.ToDateTime(aBreakupVoucherDetails.GetValue(cnt, cGABDFromDate));
					mLastDate = Convert.ToDateTime(aBreakupVoucherDetails.GetValue(cnt, cGABDToDate));

					mTotalDays = ((int) DateAndTime.DateDiff("d", mFromDate, mLastDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) + 1;
					mAmount = (decimal) Conversion.Val(Convert.ToString(aBreakupVoucherDetails.GetValue(cnt, cGABDAmount)));
					mBalanceAmt = mAmount;


					while(mFromDate <= mLastDate)
					{

						SystemGrid.DefineVoucherArray(aNewAdjustmentDetails, mMaxColNewAdjustmentDetails, cnt1, false);


						//Get the details information into the grid

						aNewAdjustmentDetails.SetValue(cnt1 + 1, cnt1, cGAdjDSno);
						aNewAdjustmentDetails.SetValue(StringsHelper.Format(mFromDate, SystemVariables.gSystemDateFormat), cnt1, cGAdjDFromDate);
						aNewAdjustmentDetails.SetValue(GetMonthEndDate(mFromDate, mLastDate), cnt1, cGAdjDToDate);

						aNewAdjustmentDetails.SetValue(aBreakupVoucherDetails.GetValue(cnt, cGABDProdCode), cnt1, cGAdjProdCode);
						aNewAdjustmentDetails.SetValue(aBreakupVoucherDetails.GetValue(cnt, cGABDProdName), cnt1, cGAdjProdName);
						aNewAdjustmentDetails.SetValue(aBreakupVoucherDetails.GetValue(cnt, cGABDLdgrCode), cnt1, cGAdjLdgrCode);
						aNewAdjustmentDetails.SetValue(aBreakupVoucherDetails.GetValue(cnt, cGABDLdgrName), cnt1, cGAdjLdgrName);

						aNewAdjustmentDetails.SetValue(aBreakupVoucherDetails.GetValue(cnt, cGABDInvntLineNo), cnt1, cGAdjInvntLineNo);

						mFromDate = Convert.ToDateTime(aNewAdjustmentDetails.GetValue(cnt1, cGAdjDToDate)).AddDays(1);


						if (mFromDate < mLastDate)
						{
							mAdjustmentAmt = Decimal.Parse(StringsHelper.Format((((double) mAmount) / ((double) mTotalDays)) * (((int) DateAndTime.DateDiff("d", Convert.ToDateTime(aNewAdjustmentDetails.GetValue(cnt1, cGAdjDFromDate)), Convert.ToDateTime(aNewAdjustmentDetails.GetValue(cnt1, cGAdjDToDate)), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) + 1), "############0.000"), NumberStyles.Currency | NumberStyles.AllowExponent);
							aNewAdjustmentDetails.SetValue(mAdjustmentAmt, cnt1, cGAdjDAmt);
							mBalanceAmt -= mAdjustmentAmt;
						}
						else
						{
							aNewAdjustmentDetails.SetValue(mBalanceAmt, cnt1, cGAdjDAmt);
						}

						cnt1++;
					};
				}
			}

			grdNewAllocationDetails.UpdateData();
			grdNewAllocationDetails.Rebind(true);

		}

		private string GetMonthEndDate(System.DateTime pFromDate, System.DateTime pLastDate)
		{


			System.DateTime mNextMonth = pFromDate.AddMonths(1);

			System.DateTime mMonthEndDate = DateTime.Parse("01-" + mNextMonth.Month.ToString() + "-" + mNextMonth.Year.ToString()).AddDays(-1);
			if (mMonthEndDate < pLastDate)
			{
				return StringsHelper.Format(mMonthEndDate, SystemVariables.gSystemDateFormat);
			}
			else
			{
				return StringsHelper.Format(pLastDate, SystemVariables.gSystemDateFormat);
			}

		}

		private void DefineMasterRecordset()
		{
			string mysql = "";

			if (mFirstGridFocus)
			{
				mysql = "select ldgr_no, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name as ldgr_name" : "a_ldgr_name as ldgr_name");
				mysql = mysql + " , ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "gl_accnt_group.l_group_name as group_name" : "gl_accnt_group.a_group_name as group_name");
				mysql = mysql + " , current_bal, gl_currency.symbol, gl_currency.curr_cd, l.type_cd, l.ldgr_cd ";
				mysql = mysql + " , cc.cost_no, l.type_cd as type_cd ";
				mysql = mysql + " , l.default_dr_cr_type ";
				mysql = mysql + " from gl_ledger l inner join gl_accnt_group on l.group_cd = gl_accnt_group.group_cd ";
				mysql = mysql + " inner join gl_currency on l.curr_cd = gl_currency.curr_cd ";
				mysql = mysql + " left outer join gl_cost_centers cc on l.default_cost_cd = cc.cost_cd ";
				mysql = mysql + " where l.discontinued = 0 ";
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdBreakupVoucherDetails.Col)
			{
				case cGABDLdgrCode : case cGABDLdgrName : 
					if (grdBreakupVoucherDetails.Col == cGABDLdgrCode)
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
								withVar.setOrder((grdBreakupVoucherDetails.Col == cGABDLdgrCode) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdBreakupVoucherDetails.Splits[0].DisplayColumns[cGABDLdgrCode].Width;
							}
							else
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdBreakupVoucherDetails.Col == cGABDLdgrCode) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdBreakupVoucherDetails.Splits[0].DisplayColumns[cGABDLdgrName].Width;
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

		public bool UnPost()
		{

			DialogResult ans = MessageBox.Show("Do you really want to unpost?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if (ans == System.Windows.Forms.DialogResult.No)
			{
				return false;
			}

			SystemVariables.gConn.BeginTransaction();
			SqlDataReader rsTempRec = null;
			StringBuilder mysql = new StringBuilder();
			mysql.Append(" select line_no, from_date, gl_generated_entry_id , entry_id ");
			mysql.Append(" from gl_accrual_breakup_details ");
			mysql.Append(" where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue));
			mysql.Append(" and gl_generated_entry_id is not null ");
			SqlCommand sqlCommand = new SqlCommand(mysql.ToString(), SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{
				if (!SystemProcedure2.ValidDateRange(Convert.ToDateTime(rsTempRec["from_Date"])))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show("Invalid Date Range, Check the current financial year", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				mysql = new StringBuilder(" delete from gl_invoice_tracking ");
				mysql.Append(" from gl_invoice_tracking IT ");
				mysql.Append(" inner join gl_accnt_trans_details ATD on IT.source_line_no = ATD.line_no ");
				mysql.Append(" inner join gl_accnt_trans AT on ATD.entry_id = AT.entry_id");
				mysql.Append(" where AT.entry_id = " + Conversion.Str(rsTempRec["gl_generated_entry_id"]));
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql.ToString();
				TempCommand.ExecuteNonQuery();

				mysql = new StringBuilder(" delete from gl_invoice_tracking ");
				mysql.Append(" from gl_invoice_tracking IT ");
				mysql.Append(" inner join gl_accnt_trans_details ATD on IT.against_line_no = ATD.line_no ");
				mysql.Append(" inner join gl_accnt_trans AT on ATD.entry_id = AT.entry_id");
				mysql.Append(" where AT.entry_id = " + Conversion.Str(rsTempRec["gl_generated_entry_id"]));
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql.ToString();
				TempCommand_2.ExecuteNonQuery();

				mysql = new StringBuilder("delete from gl_accnt_trans_details ");
				mysql.Append(" where entry_id = " + Conversion.Str(rsTempRec["gl_generated_entry_id"]));
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql.ToString();
				TempCommand_3.ExecuteNonQuery();

				mysql = new StringBuilder("delete from gl_accnt_trans ");
				mysql.Append(" where entry_id = " + Conversion.Str(rsTempRec["gl_generated_entry_id"]));
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql.ToString();
				TempCommand_4.ExecuteNonQuery();


				mysql = new StringBuilder(" update gl_accrual_breakup_details ");
				mysql.Append(" set gl_generated_entry_id = null ");
				mysql.Append(" where line_no =" + Convert.ToString(rsTempRec["line_no"]));
				SqlCommand TempCommand_5 = null;
				TempCommand_5 = SystemVariables.gConn.CreateCommand();
				TempCommand_5.CommandText = mysql.ToString();
				TempCommand_5.ExecuteNonQuery();

				mysql = new StringBuilder(" update gl_accrual_breakup_master ");
				mysql.Append(" set posted_gl = 0 ");
				mysql.Append(" , status = 1 ");
				mysql.Append(" where entry_id =" + Convert.ToString(rsTempRec["entry_id"]));
				SqlCommand TempCommand_6 = null;
				TempCommand_6 = SystemVariables.gConn.CreateCommand();
				TempCommand_6.CommandText = mysql.ToString();
				TempCommand_6.ExecuteNonQuery();

			}
			while(rsTempRec.Read());
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

			return true;
		}

		public void PrintReport(int pEntryId = 0)
		{

			int mEntryId = 0;
			string mysql = "";
			int mReportId = 0;
			object mCrystalReportEntryIDColumnID = null;

			try
			{

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
				}
				else
				{
					if (!SystemProcedure2.IsItEmpty(pEntryId))
					{
						mEntryId = pEntryId;
					}
					else
					{
						return;
					}
				}

				mReportId = 44004040;

				mysql = "select column_id from SM_REPORT_FIELDS ";
				mysql = mysql + " where report_id = " + mReportId.ToString();
				mysql = mysql + " and entry_id_column = 1 ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCrystalReportEntryIDColumnID = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql, true));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mCrystalReportEntryIDColumnID))
				{
					MessageBox.Show("Error: Incomplete Report Information!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				SystemReports.GetCrystalReport(mReportId, 2, Conversion.Str(mCrystalReportEntryIDColumnID), Conversion.Str(mEntryId));
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}
	}
}