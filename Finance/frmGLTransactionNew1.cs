using Excel = Microsoft.Office.Interop.Excel;

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmGLTransaction
		: System.Windows.Forms.Form
	{

		private int mThisFormID = 0; //Assign the Formid for Each Form
		private string mTimeStamp = "";
		private XArrayHelper _aVoucherDetails = null;
		public frmGLTransaction()
{
InitializeComponent();
} 
 public  void frmGLTransaction_old()
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


		public XArrayHelper aVoucherDetails
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

		private XArrayHelper aAdjustedVoucherDetails = null;
		private DataSet _rsGLVoucherTypes = null;
		private DataSet rsGLVoucherTypes
		{
			get
			{
				if (_rsGLVoucherTypes is null)
				{
					_rsGLVoucherTypes = new DataSet();
				}
				return _rsGLVoucherTypes;
			}
			set
			{
				_rsGLVoucherTypes = value;
			}
		}

		private DataSet rsLedgerCodeList = null;
		private DataSet rsDRCRType = null;
		private DataSet rsCostCenterList = null;
		private DataSet rsSalesmanList = null;
		private DataSet rsAnlyCode = null;
		private DataSet rsProjectList = null;
		private DataSet rsCurrencySymbols = null;
		private DataSet rsConsignmentsList = null;
		private DataSet rsRemarksList = null;
		private bool mFirstGridFocus = false;
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;
		//Private mOldFormHeight As Long
		//Private mOldFormWidth As Long
		private object mSearchValue = null; //Variable for storing the searchvalue from the Find window
		private int mRecordNavigateSearchValue = 0;
		private int mLastVoucherNo = 0;

		private frmICSPrintReportFormat frmRptFormat = null;

		private double mOppositeLedgerExchangeRate = 0;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0; //Enum for checking the current form mode
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
		 //This class checks for the rights given to the user
		private clsToolbar oThisFormToolBar = null;
		public int DefaultVoucherType = 0;
		public bool PreventVoucherTypeSelection = false;
		public Control FirstFocusObject = null;

		//**--define form level default contants
		private const int mLineNoColumn = 0;
		private const int mLedgerCodeColumn = 1;
		private const int mLedgerNameColumn = 2;
		private const int mCurrencySymbolColumn = 3;
		private const int mExchangeRateColumn = 4;
		private const int mDebitAmountColumn = 5;
		private const int mCreditAmountColumn = 6;
		private const int mFCAmountColumn = 7;
		private const int mLCAmountColumn = 8;
		private const int mDrCrTypeColumn = 9;
		private const int mConsignmentColumn = 10;
		private const int mVoucherAdjBtn = 11;
		private const int mCostCenterColumn = 12;
		private const int mSalesmanColumn = 13;
		private const int mFlex1Column = 14;
		private const int mProjectColumn = 15;
		private const int mAnlyCode1Column = 16;
		private const int mAnlyCode2Column = 17;
		private const int mChequeNoColumn = 18;
		private const int mRemarksColumn = 19;
		private const int mGroupNameColumn = 20;
		private const int mCurrencyCodeColumn = 21;
		private const int mLedgerBalanceColumn = 22;
		private const int mLineFCAmountColumn = 23;


		private const int conMaxGLTransCols = 24;

		//contants for voucher linking module
		private const int conVLLineNoColumn = 0;
		private const int conVLDrCrTypeColumn = 1;
		private const int conVLSourceLineNoColumn = 2;
		private const int conVLAgainstLineNoColumn = 3;
		private const int conVLAdjustedAmountColumn = 4;
		private const int conVLLinkedTimeStampColumn = 5;
		private const int conVLLinkedRemarksColumn = 6;

		private const int conMaxVoucherLinkingCols = 6;

		private const int mSourceTranButtonIndex = 10;
		//**----------------------------------------------------------------------
		private const string mDrTypeCaption = "D";
		private const string mCrTypeCaption = "C";

		private string mGridColumnBackColor = "";
		public XtremeCommandBars.StatusBar UCStatusBar = null;


		//The property below are used for storing the Search value returned by the Find window

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


		public int ExchangeRateColumn
		{
			get
			{
				return mExchangeRateColumn;
			}
		}


		public int LineFCAmountColumn
		{
			get
			{
				return mLineFCAmountColumn;
			}
		}


		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					FirstFocusObject.Focus();

					//'Added By: Moiz Hakimi
					//'Date: 26-Jan-2008
					//If GetSystemPreferenceSetting("enable_gl_voucher_type_combo") = vbTrue Then
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					cmbVoucherTypes.Enabled = Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Enable_Combo_List"]);

					SystemMenu.SetMeCurrentInWindowList(Conversion.Str(this.Handle.ToInt32()));
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			int mFormBackColor = 0;
			int mHeaderControlsBackColor = 0;

			try
			{

				CreateStatusBar();

				rsDRCRType = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsDRCRType.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsDRCRType.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsDRCRType.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsDRCRType.setActiveConnection(null);

				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDRCRType.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("drcr", DbType.String, 10, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2070) Constant adOpenUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDRCRType.Open was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsDRCRType.Open(null, null, UpgradeStubs.ADODB_CursorTypeEnum.getadOpenUnspecified(), UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified(), -1);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDRCRType.AddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsDRCRType.AddNew("drcr", "Dr");
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDRCRType.AddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsDRCRType.AddNew("drcr", "Cr");

				this.Top = 0;
				this.Left = 0;
				//**--check whether numeric gl_ledger codes are allowed
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				txtCashLedgerCode.NumericOnly = ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no"))) != TriState.True;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowVoidButton = true;
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginInsertLineButtonWithGroup = true;
				oThisFormToolBar.BeginPostButtonWithGroup = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.BeginDeleteButtonWithGroup = true;
				oThisFormToolBar.BeginSourceTranButtonWithGroup = true;
				oThisFormToolBar.ShowImportButton = true;

				oThisFormToolBar.DisableHelpButton = true;
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				oThisFormToolBar.ShowSourceTranButton = ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_source_transaction_from_gl"))) == TriState.True;

				if (SystemVariables.gLoggedInUserGroupCode == SystemConstants.gDefaultAdminGroupCode)
				{
					oThisFormToolBar.ShowUnpostButton = true;
				}

				oThisFormToolBar.ShowMoveRecordNextButton = true;
				oThisFormToolBar.ShowMoveRecordPreviousButton = true;

				this.WindowState = FormWindowState.Maximized;

				//**--format the form color
				//mFormBackColor = &HE7E2DC    'tcbSystemForm.GetSpecialColor(XPCOLOR_3DSHADOW)
				//mHeaderControlsBackColor = &HE7E2DC    'tcbSystemForm.GetSpecialColor(XPCOLOR_3DFACE)

				//Me.BackColor = mFormBackColor
				//lblComments.BackColor = mFormBackColor

				//fraTransactionHeader.BackColor = mHeaderControlsBackColor
				//fraTransactionHeader.BorderColor = &HE7E2DC    '15724527 tcbSystemForm.GetSpecialColor(XPCOLOR_HIGHLIGHT_BORDER)
				//fraCashLedgerDetails.BorderColor = mFormBackColor

				SystemProcedure.SetLabelCaption(this);
				clsFlip oFlipThisForm = null;
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
				{
					oFlipThisForm = new clsFlip();

					oFlipThisForm.SwapMe(this);
				}


				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("voucher_adjustment")))
				{
					aAdjustedVoucherDetails = new XArrayHelper();
					aAdjustedVoucherDetails.RedimXArray(new int[]{-1, conMaxVoucherLinkingCols}, new int[]{0, 0});
				}

				FirstFocusObject = txtVoucherDate;

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //setting form mode to add initially
				txtVoucherDate.Value = SystemVariables.gCurrentDate;
				mFirstGridFocus = true;

				mGridColumnBackColor = "15724527"; //tcbSystemForm.GetSpecialColor(XPCOLOR_MENUBAR_EXPANDED)

				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, mGridColumnBackColor, mGridColumnBackColor, 320, 10); //define voucher grid
				//**--define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, mGridColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Type", 450, , , , dbgCenter, False, , , True, , , "cmbMastersList", True)
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Code", 1300, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, true, false, false, false, false, 100, "", "", false, "", 0, true);

				//'commented by Moiz Hakimi
				//'desc : to remove footer
				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Name", 3200, , , , , False, "T o t a l", , True, , , "cmbMastersList")
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Name", 3500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, true, false, false, false, false, 100, "", "", false, "", 0, true);

				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Curr.", 600, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Exch. Rate", 1300, true, ColorTranslator.ToOle(Color.White).ToString(), (0x295C36).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, true, false, true);

				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Debit Amount", 1600, true, ColorTranslator.ToOle(Color.White).ToString(), (0x295C36).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Credit Amount", 1600, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false, false, false, false, true);
				//' added by Moiz Hakimi
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount (KWD)", 1600, true, ColorTranslator.ToOle(Color.White).ToString(), (0x295C36).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount (Foreign)", 1600, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Dr/Cr", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", true, true, false, true);

				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Branch", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "T.M.", 1300, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, true, true, -1);
				//'
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "CostCenter", 900, true, ColorTranslator.ToOle(Color.White).ToString(), (0x913DA3).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Salesman", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Receipt No.", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Project", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Anly 1", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Anly 2", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cheque No.", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 20);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "cmbMastersList", false, true, false, false, true, false, 500, "", SystemConstants.gArabicFontName, false, "", 0, true);

				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("advance_multiple_currency")))
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mCurrencySymbolColumn].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mCurrencySymbolColumn].Style.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(SystemConstants.gDisableColumnBackColor)));
				}

				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Ledger_branch")))
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mConsignmentColumn].Visible = false;
				}

				//add button for voucher details
				C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar = grdVoucherDetails.Splits[0].DisplayColumns[mVoucherAdjBtn];
				withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
				withVar.DataColumn.Caption = "T.M.";
				withVar.AllowFocus = true;
				withVar.ButtonAlways = true;
				withVar.ButtonText = true;
				withVar.Width = 33;
				withVar.Style.Font = withVar.Style.Font.Change(bold:true, size:11, name:"Verdana");
				withVar.Style.ForeColor = Color.FromArgb(21, 64, 77);
				withVar.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("voucher_adjustment"));
				//'

				//**--setting voucher details grid properties
				DefineVoucherArray(0, false);
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.ExtendRightColumn = true;
				//**-- end of voucher grid property setting

				FillVoucherTypes();
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
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
				object mTempSearchValue = null;
				double mBalanceAmt = 0;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{

					if (Shift == 2 && (KeyCode == 67 || KeyCode == 86 || KeyCode == 88))
					{
						return;
					}

					//'added by Moiz Hakimi. Date: 07-Apr-2008
					//desc: Shift + F12 to search ledger account in grid
					if (this.ActiveControl.Name.ToLower() == ("grdVoucherDetails").ToLower())
					{
						if (Shift == 1 && KeyCode == 123)
						{
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2"));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mTempSearchValue))
							{
								SearchLedgerNoInGrid(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)));
							}
						}
					}

					//Refresh the ICS_Item recordset when F5 is pressed
					if (Shift == 0 && KeyCode == 116 && !mFirstGridFocus)
					{
						DefineMasterRecordset();
					}

					//'Alt + V for cancelrecord
					if (Shift == 4 && KeyCode == 86)
					{
						CancelRecord();
					}


					//''(Alt + -> ) or ( Alt + <- )
					if (Shift == 4 && (KeyCode == 37 || KeyCode == 39))
					{
						//    If Not IsItEmpty(mSearchValue, NumberType) Then
						//        If CLng(mSearchValue) > 0 Then
						if (!UserAccess.AllowUserDisplay)
						{
							MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

						//Call RecordNavidate(KeyCode, mRecordNavigateSearchValue, rsGLVoucherTypes("voucher_type"))
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						RecordNavidate(KeyCode, Convert.ToInt32(Double.Parse(txtVoucherNo.Text)), Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["voucher_type"]));
						KeyCode = 0;
						//        End If
						//    End If
					}

					//'    ''added by Moiz Hakimi Date:10-May-2008
					//'    If Shift = 1 And KeyCode = vbKeyF3 Then
					//'        Dim mForm As New frmICSBarcodeDataCollection
					//'        mForm.CallerId = 2
					//'        mForm.Show 1
					//'        If mForm.mTabSelected = 2 Then
					//'            GetRecord mForm.GLVoucherID, True
					//'        ElseIf mForm.mTabSelected = 1 Then
					//'            ImportExternalDataFromExcel mForm.Filename
					//'        Else
					//'            Exit Sub
					//'        End If
					//'    End If


					//if the user presses any control key in the voucher grid object
					if (this.ActiveControl.Name == "grdVoucherDetails")
					{
						if (KeyCode == 13)
						{ //''Or KeyCode = 115 Then
							return;
						}

						if (Shift == 0)
						{
							if (grdVoucherDetails.Col == mFCAmountColumn || grdVoucherDetails.Col == mCostCenterColumn || grdVoucherDetails.Col == mSalesmanColumn || grdVoucherDetails.Col == mFlex1Column)
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
							//------------------------------------------------------------------
							if (grdVoucherDetails.Col == mLCAmountColumn && KeyCode == 113)
							{
								if (grdVoucherDetails.Columns[mLCAmountColumn].Text == "" && UCStatusBar.FindPane(SystemGLConstants.lcDiffrence2).Text != "")
								{ //txtBalance.Caption <> ""
									//mBalanceAmt = Replace(Left(txtBalance.Caption, Len(txtBalance.Caption) - 4), ",", "")
									grdVoucherDetails.Columns[mLCAmountColumn].Text = StringsHelper.Replace(UCStatusBar.FindPane(SystemGLConstants.lcDiffrence2).Text.Substring(0, Math.Min(Strings.Len(UCStatusBar.FindPane(SystemGLConstants.lcDiffrence2).Text) - 4, UCStatusBar.FindPane(SystemGLConstants.lcDiffrence2).Text.Length)), ",", "", 1, -1, CompareMethod.Binary);
									grdVoucherDetails.Columns[mDrCrTypeColumn].Text = StringsHelper.Replace(UCStatusBar.FindPane(SystemGLConstants.lcDiffrence2).Text.Substring(Math.Max(UCStatusBar.FindPane(SystemGLConstants.lcDiffrence2).Text.Length - 3, 0)), ")", "", 1, -1, CompareMethod.Binary);
									grdVoucherDetails_AfterColUpdate(grdVoucherDetails, new C1.Win.C1TrueDBGrid.ColEventArgs());
								}
							}
							//------------------------------------------------------------------
							//If F2 pressed search for ledger no in the grid
							if (KeyCode == 115 && (grdVoucherDetails.Col == mLedgerCodeColumn || grdVoucherDetails.Col == mLedgerNameColumn))
							{
								if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
								{
									//1001000, , "l.type_cd =" & gGLCustomerVendorTypeCode)
									//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2,3"));
								}
								else
								{
									//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2,4"));
								}

								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (!Convert.IsDBNull(mTempSearchValue))
								{
									FetchDetailsFromLdgrNoInGrid(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)), ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(2)));
								}
							}

							//If F2 pressed search for remarks in the grid
							if (KeyCode == 115 && grdVoucherDetails.Col == mRemarksColumn)
							{
								if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
								{
									//1001000, , "l.type_cd =" & gGLCustomerVendorTypeCode)
									//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9018120, "2390"));
								}
								else
								{
									//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9018120, "2391"));
								}

								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (!Convert.IsDBNull(mTempSearchValue))
								{
									grdVoucherDetails.Columns[mRemarksColumn].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
								}
							}

							if (KeyCode == 115 && (grdVoucherDetails.Col == mAnlyCode1Column))
							{
								if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
								{
									//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1008000, "1622", " anly.anly_head_no = 1 "));
								}
								else
								{
									//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1008000, "1622", " anly.anly_head_no = 1 "));
								}

								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (!Convert.IsDBNull(mTempSearchValue) && !Convert.IsDBNull(grdVoucherDetails.Bookmark))
								{
									aVoucherDetails.SetValue(((Array) mTempSearchValue).GetValue(0), ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), mAnlyCode1Column);
									grdVoucherDetails.Refresh();
								}
							}

							if (KeyCode == 115 && (grdVoucherDetails.Col == mAnlyCode2Column))
							{
								if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
								{
									//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1008000, "1622", " anly.anly_head_no = 2 "));
								}
								else
								{
									//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1008000, "1622", " anly.anly_head_no = 2 "));
								}

								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (!Convert.IsDBNull(mTempSearchValue) && !Convert.IsDBNull(grdVoucherDetails.Bookmark))
								{
									aVoucherDetails.SetValue(((Array) mTempSearchValue).GetValue(0), ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), mAnlyCode2Column);
									grdVoucherDetails.Refresh();
								}
							}

							if (KeyCode == 114)
							{
								grdVoucherDetails.EditActive = true;
							}

							if (grdVoucherDetails.Col == mLedgerCodeColumn)
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
							if (grdVoucherDetails.Col == mLCAmountColumn || grdVoucherDetails.Col == mFCAmountColumn)
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
					//On Keydown navigate the form by using enter key
					if (KeyCode == 13)
					{ //If enter key pressed send a tab key
						SendKeys.Send("{TAB}");
						return;
					}
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (this.Width * 15 > 170)
				{
					grdVoucherDetails.Width = this.Width - 11;
				}

				if (this.Height * 15 > 1900)
				{
					grdVoucherDetails.Height = this.Height - (grdVoucherDetails.Top + 127);
				}

				frmFooter.Top = grdVoucherDetails.Top + grdVoucherDetails.Height + 1;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				aVoucherDetails = null;
				aAdjustedVoucherDetails = null;
				//Set rsDrCrTypeList = Nothing
				rsGLVoucherTypes = null;
				rsLedgerCodeList = null;
				rsCostCenterList = null;
				rsSalesmanList = null;
				rsAnlyCode = null;
				rsProjectList = null;
				UserAccess = null;
				frmGLTransaction.DefInstance = null;
				rsDRCRType = null;
				rsCurrencySymbols = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			try
			{
				if (grdVoucherDetails.Col == mLedgerCodeColumn || grdVoucherDetails.Col == mLedgerNameColumn)
				{
					if (grdVoucherDetails.Col == mLedgerCodeColumn)
					{
						grdVoucherDetails.Columns[mLedgerNameColumn].Value = cmbMastersList.Columns[1].Value;
					}
					else
					{
						grdVoucherDetails.Columns[mLedgerCodeColumn].Value = cmbMastersList.Columns[0].Value;
					}
					grdVoucherDetails.Columns[mCurrencySymbolColumn].Value = cmbMastersList.Columns[4].Value;

					//If IsItEmpty(grdVoucherDetails.Columns(mCostCenterColumn).Value, NumberType) Then
					grdVoucherDetails.Columns[mCostCenterColumn].Value = ReflectionHelper.GetPrimitiveValue<string>(cmbMastersList.Columns[8].Value) + "";
					//End If

					//----------------------------------------------------------------------------------
					if (ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[mLCAmountColumn].Value) == "")
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[mDrCrTypeColumn].Visible)
						{
							if (ReflectionHelper.GetPrimitiveValue<string>(cmbMastersList.Columns[10].Value) == "D")
							{
								grdVoucherDetails.Columns[mDrCrTypeColumn].Text = "Dr";
							}
							else
							{
								grdVoucherDetails.Columns[mDrCrTypeColumn].Text = "Cr";
							}
						}
					}
					//------------------------------------------------------------------------------------
					//-----------------------------------------To Copy Comments in Next Line-------------------------------
					if (grdVoucherDetails.Row > 0 && ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[mRemarksColumn].Value) == "" && grdVoucherDetails.Columns[mLineNoColumn].Text != "")
					{
						grdVoucherDetails.Columns[mRemarksColumn].Value = aVoucherDetails.GetValue(Convert.ToInt32(Double.Parse(grdVoucherDetails.Columns[mLineNoColumn].Text) - 2), mRemarksColumn);
					}
					//--------------------------------------------------------------------------------------------------------------------
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(cmbMastersList.Columns[2].Value))
					{
						UCStatusBar.FindPane(SystemGLConstants.lcGroup2).Text = StringsHelper.Replace(ReflectionHelper.GetPrimitiveValue<string>(cmbMastersList.Columns[2].Value), "&", "&&", 1, -1, CompareMethod.Binary);
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Show_FC_Balance_In_Taskbar"]))
					{
						UCStatusBar.FindPane(SystemGLConstants.lcCurrBal2).Text = StringsHelper.Format(Math.Abs(ReflectionHelper.GetPrimitiveValue<double>(cmbMastersList.Columns[11].Value)), "###,###,###,###,##0.000") + ((ReflectionHelper.GetPrimitiveValue<double>(cmbMastersList.Columns[11].Value) != 0) ? ((ReflectionHelper.GetPrimitiveValue<double>(cmbMastersList.Columns[11].Value) > 0) ? "   Dr" : "   Cr") : "");
					}
					else
					{
						UCStatusBar.FindPane(SystemGLConstants.lcCurrBal2).Text = StringsHelper.Format(Math.Abs(ReflectionHelper.GetPrimitiveValue<double>(cmbMastersList.Columns[3].Value)), "###,###,###,###,##0.000") + ((ReflectionHelper.GetPrimitiveValue<double>(cmbMastersList.Columns[3].Value) != 0) ? ((ReflectionHelper.GetPrimitiveValue<double>(cmbMastersList.Columns[3].Value) > 0) ? "   Dr" : "   Cr") : "");
					}


					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(cmbMastersList.Columns[5].Value))
					{
						GetExchangeRate(ReflectionHelper.GetPrimitiveValue<int>(cmbMastersList.Columns[5].Value));
					}
					//'        If cmbMastersList.Columns(5).Value <> gDefaultCurrencyCd Then
					//'            Call ShowHideFCAmount(True)
					//'        Else
					//'            Call ShowHideFCAmount(True)
					//'        End If
				}
			}
			catch
			{
			}


		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//Dim rsCloneRecordset As ADODB.Recordset
				//Dim mDrCrType As String
				object mTempReturnValue = null;
				string mysql = "";

				grdVoucherDetails.UpdateData();

				//If GetSystemPreferenceSetting("voucher_adjustment") = True Then
				//    If (ColIndex = mDebitAmountColumn Or ColIndex = mCreditAmountColumn) And IsItEmpty(Val(grdVoucherDetails.Columns(mLedgerCodeColumn).Value), StringType) = False Then
				//        Set rsCloneRecordset = rsLedgerCodeList.Clone
				//        With rsCloneRecordset
				//            .MoveFirst
				//            .Find "ldgr_no ='" & grdVoucherDetails.Columns(mLedgerCodeColumn).Value & "'"
				//            If Not .EOF Or .BOF Then
				//                If .Fields("type_cd").Value = gGLCustomerVendorTypeCode Then
				//                'And ColIndex = mCreditAmountColumn) Or (.Fields("ldgr_type").Value = Left(gGLCustomerVendorTypeCode, 4) And ColIndex = mDebitAmountColumn) Then
				//                    If ColIndex = mDebitAmountColumn Then
				//                        mDrCrType = mDrTypeCaption
				//                    Else
				//                        mDrCrType = mCrTypeCaption
				//                    End If
				//
				//                    If .Fields("curr_cd").Value = gDefaultCurrencyCd Then
				//                        Call GetVoucherAdjustmentDetails(grdVoucherDetails.Columns(mLedgerCodeColumn).Value, Val(grdVoucherDetails.Columns(ColIndex)), mDrCrType)
				//                    Else
				//                        Call GetVoucherAdjustmentDetails(grdVoucherDetails.Columns(mLedgerCodeColumn).Value, Val(aVoucherDetails(grdVoucherDetails.Bookmark, mLineFCAmountColumn)), mDrCrType)
				//                    End If
				//                End If
				//            End If
				//        End With
				//    End If
				//End If
				if (ColIndex == mLedgerCodeColumn || ColIndex == mLedgerNameColumn)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Show_Salesman"]) && Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Show_Default_Salesman_In_Detail"]) && ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[mLedgerCodeColumn].Value) != "")
					{
						mysql = "select sman_no from gl_ledger";
						mysql = mysql + " inner join SM_Salesman on gl_ledger.default_sman_cd = SM_Salesman.sman_cd";
						mysql = mysql + " where (gl_ledger.Ldgr_No =" + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[mLedgerCodeColumn].Value) + " )";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempReturnValue))
						{
							grdVoucherDetails.Columns[mSalesmanColumn].Value = mTempReturnValue;
						}
						else
						{
							grdVoucherDetails.Columns[mSalesmanColumn].Value = "";
						}
					}
					//----------------------------------for Copy/Paste-----------
					if (ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[mLedgerNameColumn].Value) == "")
					{
						cmbMastersList_RowChange(cmbMastersList, new EventArgs());
					}
					//-----------------------------------------------------------------------------
				}
				else if (ColIndex == mFCAmountColumn || ColIndex == mLCAmountColumn || ColIndex == mExchangeRateColumn || ColIndex == mDrCrTypeColumn || ColIndex == mDebitAmountColumn || ColIndex == mCreditAmountColumn)
				{ 
					CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);
					grdVoucherDetails.Refresh();
				}

				//Set rsCloneRecordset = Nothing
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
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					string mDrCrType = "";

					//If ColIndex = mDebitAmountColumn Or ColIndex = mCreditAmountColumn Then
					//
					//'    If ColIndex = mDebitAmountColumn Then
					//'        If grdVoucherDetails.Columns(mDrCrTypeColumn).Value = mDrTypeCaption Then
					//'            Cancel = False
					//'        Else
					//'            Cancel = True
					//'        End If
					//'    Else
					//'        If grdVoucherDetails.Columns(mDrCrTypeColumn).Value = mCrTypeCaption Then
					//'            Cancel = False
					//'        Else
					//'            Cancel = True
					//'        End If
					//'    End If
					//
					//    If Cancel = False Then
					//        rsLedgerCodeList.MoveFirst
					//        rsLedgerCodeList.Find "ldgr_no='" & grdVoucherDetails.Columns(mLedgerCodeColumn).Value & "'"
					//        If Not rsLedgerCodeList.EOF Or rsLedgerCodeList.BOF Then
					//            If rsLedgerCodeList.Fields("curr_cd").Value <> gDefaultCurrencyCd Then
					//                Cancel = True
					//
					//                If ColIndex = mDebitAmountColumn Then
					//                    Call GetLedgerAmount(mDrTypeCaption)
					//                ElseIf ColIndex = mCreditAmountColumn Then
					//                    Call GetLedgerAmount(mCrTypeCaption)
					//                End If
					//
					//                Call grdVoucherDetails_AfterColUpdate(ColIndex)
					//            Else
					//                Cancel = False
					//            End If
					//        Else
					//            Cancel = False
					//        End If
					//    End If
					//End If
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
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
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					string mSQL = "";
					object mReturnValue = null;
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("voucher_adjustment")))
					{
						//If ColIndex = mDrCrTypeColumn Or ColIndex = mLedgerCodeColumn Or ColIndex = mLedgerNameColumn Or ColIndex = mDebitAmountColumn Or ColIndex = mCreditAmountColumn Then
						//If ColIndex = mLedgerCodeColumn Or ColIndex = mLedgerNameColumn Or ColIndex = mDebitAmountColumn Or ColIndex = mCreditAmountColumn Then
						if (ColIndex == mLedgerCodeColumn || ColIndex == mLedgerNameColumn || ColIndex == mFCAmountColumn || ColIndex == mLCAmountColumn || ColIndex == mDrCrTypeColumn || ColIndex == mCurrencySymbolColumn)
						{
							bool tempRefParam = true;
							Cancel = (!DeleteCurrentLineAdjustment(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[mLineNoColumn].Value))), ref tempRefParam)) ? -1 : 0;
						}
					}


					if (ColIndex == mLedgerCodeColumn || ColIndex == mLedgerNameColumn)
					{
						if (ColIndex == mLedgerCodeColumn)
						{
							if (!IsValidLdgrNo(grdVoucherDetails.Columns[mLedgerCodeColumn].Text, rsLedgerCodeList))
							{
								MessageBox.Show(" Invalid Ledger No. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								OldValue = "";
								Cancel = -1;
							}
						}

						if (ColIndex == mLedgerNameColumn)
						{
							if (!IsValidLedgerName(grdVoucherDetails.Columns[mLedgerNameColumn].Text, rsLedgerCodeList))
							{
								MessageBox.Show(" Invalid Ledger Name. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								OldValue = "";
								Cancel = -1;
							}
						}
					}
					//'commented by Moiz Hakimi
					//'check whether user has selected or entered right currency symbol
					if (ColIndex == mCurrencySymbolColumn)
					{
						if (grdVoucherDetails.Columns[mCurrencySymbolColumn].Text.Trim() != "")
						{
							mSQL = "select curr_cd, exchange_rate from gl_currency where symbol = '" + grdVoucherDetails.Columns[mCurrencySymbolColumn].Text + "'";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mReturnValue))
							{
								MessageBox.Show("Invalid Currency Symbol.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								OldValue = "";
								Cancel = -1;
							}
							else
							{
								GetExchangeRate(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
							}
						}
					}

					if (ColIndex == mDrCrTypeColumn)
					{
						grdVoucherDetails.Columns[mDrCrTypeColumn].Text = grdVoucherDetails.Columns[mDrCrTypeColumn].Text.Trim();
					}

					if (ColIndex == mConsignmentColumn)
					{
						if (grdVoucherDetails.Columns[mConsignmentColumn].Text.Trim() != "")
						{
							mSQL = " select consignment_cd from gl_consignment where consignment_no = '" + grdVoucherDetails.Columns[mConsignmentColumn].Text + "'";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mReturnValue))
							{
								MessageBox.Show("Invalid Consignment Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								OldValue = "";
								Cancel = -1;
							}
						}
					}
					if (Cancel == (0))
					{
						grdVoucherDetails.Focus();
					}
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		private void grdVoucherDetails_ButtonClick(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				DataSet rsCloneRecordset = null;
				string mDrCrType = "";
				string mSQL = "";
				object mReturnValue = null;
				bool mCancel = false;

				if (ColIndex == mVoucherAdjBtn)
				{
					grdVoucherDetails.UpdateData();
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("voucher_adjustment")))
					{

						bool tempRefParam = true;
						mCancel = !DeleteCurrentLineAdjustment(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[mLineNoColumn].Value))), ref tempRefParam);
						if (mCancel)
						{
							return;
						}

						if (!SystemProcedure2.IsItEmpty(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[mLedgerCodeColumn].Value)), SystemVariables.DataType.StringType))
						{
							//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsLedgerCodeList.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							rsCloneRecordset = rsLedgerCodeList.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsCloneRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							rsCloneRecordset.MoveFirst();
							rsCloneRecordset.Find("ldgr_no ='" + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[mLedgerCodeColumn].Value) + "'");
							//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCloneRecordset.BOF was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							if (rsCloneRecordset.Tables[0].Rows.Count != 0 || rsCloneRecordset.getBOF())
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								if (Convert.ToDouble(rsCloneRecordset.Tables[0].Rows[0]["type_cd"]) == SystemGLConstants.gGLCustomerVendorTypeCode)
								{
									//And ColIndex = mCreditAmountColumn) Or (.Fields("ldgr_type").Value = Left(gGLCustomerVendorTypeCode, 4) And ColIndex = mDebitAmountColumn) Then
									if (grdVoucherDetails.Columns[mDrCrTypeColumn].Text == "Dr")
									{
										mDrCrType = "D";
									}
									else if (grdVoucherDetails.Columns[mDrCrTypeColumn].Text == "Cr")
									{ 
										mDrCrType = "C";
									}
									else
									{
										return;
									}

									//check currency selected in grid
									mSQL = "select curr_cd, symbol from gl_currency where symbol = '" + grdVoucherDetails.Columns[mCurrencySymbolColumn].Text + "'";
									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
									if (!Convert.IsDBNull(mReturnValue))
									{
										if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0)) == SystemGLConstants.gDefaultCurrencyCd)
										{
											GetVoucherAdjustmentDetails(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[mLedgerCodeColumn].Value), Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[mLCAmountColumn].Text, "###############0.000")), mDrCrType, ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1)));
										}
										else
										{
											GetVoucherAdjustmentDetails(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[mLedgerCodeColumn].Value), Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[mFCAmountColumn].Text, "###############0.000")), mDrCrType, ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1)));
										}
									}
									else
									{
										return;
									}
								}
							}
						}
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mSQL = "";
				object mReturnValue = null;
				//If Col = mCostCenterColumn And grdVoucherDetails.Columns(mCostCenterColumn).Visible = True Then
				//    If ApplyCostCenterToLedger(Val(aVoucherDetails(Bookmark, mLedgerCodeColumn))) = True Then
				//        CellStyle.BackColor = grdVoucherDetails.Columns(mCostCenterColumn).BackColor
				//        CellStyle.ForeColor = grdVoucherDetails.Columns(mCostCenterColumn).ForeColor
				//        grdVoucherDetails.Columns(mCostCenterColumn).AllowFocus = True
				//    Else
				//        CellStyle.BackColor = gDisableColumnBackColor
				//        CellStyle.ForeColor = gDisableColumnBackColor
				//        grdVoucherDetails.Columns(mCostCenterColumn).AllowFocus = False
				//    End If
				//End If

				if (Col == mDrCrTypeColumn || Col == mLCAmountColumn || Col == mFCAmountColumn)
				{
					if (Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Bookmark), mDrCrTypeColumn)) == "Dr")
					{
						if (Col == mLCAmountColumn || Col == mFCAmountColumn)
						{
							CellStyle.ForeColor = Color.Green;
						}
					}
					else
					{
						if (Col == mLCAmountColumn)
						{
							CellStyle.ForeColor = Color.Red;
						}
					}
				}
				if (Col == mCurrencySymbolColumn || Col == mExchangeRateColumn || Col == mFCAmountColumn)
				{
					mSQL = " select curr_cd from gl_currency where symbol = '" + Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Bookmark), mCurrencySymbolColumn)) + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == SystemGLConstants.gDefaultCurrencyCd)
					{
						if (Col == mCurrencySymbolColumn || Col == mExchangeRateColumn || Col == mFCAmountColumn)
						{
							if (Col != mCurrencySymbolColumn)
							{
								CellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(SystemConstants.gDisableColumnBackColor)));
							}
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							grdVoucherDetails.Splits[0].DisplayColumns[mExchangeRateColumn].AllowFocus = false;
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							grdVoucherDetails.Splits[0].DisplayColumns[mFCAmountColumn].AllowFocus = false;

							if (Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Bookmark), mExchangeRateColumn)) == "")
							{
								aVoucherDetails.SetValue("", ReflectionHelper.GetPrimitiveValue<int>(Bookmark), mExchangeRateColumn);
								//grdVoucherDetails.Columns(mExchangeRateColumn) = ""
							}
							if (Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Bookmark), mFCAmountColumn)) == "")
							{
								//grdVoucherDetails.Columns(mFCAmountColumn) = ""
								aVoucherDetails.SetValue("", ReflectionHelper.GetPrimitiveValue<int>(Bookmark), mFCAmountColumn);
							}
						}
						else
						{
							CellStyle.BackColor = Color.White;
							//grdVoucherDetails.Columns(mExchangeRateColumn).AllowFocus = True
							//grdVoucherDetails.Columns(mFCDebitAmountColumn).AllowFocus = True
							//grdVoucherDetails.Columns(mFCCreditAmountColumn).AllowFocus = True
						}
					}
					else if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) > 1)
					{ 
						if (Col == mCurrencySymbolColumn || Col == mExchangeRateColumn || Col == mFCAmountColumn)
						{
							if (Col != mCurrencySymbolColumn)
							{
								CellStyle.BackColor = Color.White;
							}
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							grdVoucherDetails.Splits[0].DisplayColumns[mExchangeRateColumn].AllowFocus = true;
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							grdVoucherDetails.Splits[0].DisplayColumns[mFCAmountColumn].AllowFocus = true;
						}
						else
						{
							CellStyle.BackColor = Color.White;
						}
					}
					else
					{
						if (Col == mCurrencySymbolColumn || Col == mExchangeRateColumn || Col == mFCAmountColumn)
						{
							if (Col != mCurrencySymbolColumn)
							{
								CellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(SystemConstants.gDisableColumnBackColor)));
							}
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							grdVoucherDetails.Splits[0].DisplayColumns[mExchangeRateColumn].AllowFocus = false;
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							grdVoucherDetails.Splits[0].DisplayColumns[mFCAmountColumn].AllowFocus = false;
							if (grdVoucherDetails.Columns[mExchangeRateColumn].Text != "")
							{
								grdVoucherDetails.Columns[mExchangeRateColumn].Text = "";
							}
							if (grdVoucherDetails.Columns[mFCAmountColumn].Text != "")
							{
								grdVoucherDetails.Columns[mFCAmountColumn].Text = "";
							}
						}
						else
						{
							CellStyle.BackColor = Color.White;
						}
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//If ColIndex = mDebitAmountColumn Or ColIndex = mCreditAmountColumn Or ColIndex = mFCAmountColumn Or ColIndex = mLCAmountColumn Then
				if (ColIndex == mFCAmountColumn || ColIndex == mLCAmountColumn || ColIndex == mDebitAmountColumn || ColIndex == mCreditAmountColumn)
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

				if (ColIndex == mExchangeRateColumn)
				{
					if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
					{
						Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "##############0.000000000");
					}
					else
					{
						Value = "";
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "";

				if (mFirstGridFocus)
				{
					if (Convert.ToString(cmbMastersList.Tag) == "")
					{
						SystemGrid.DefineSystemGridCombo(cmbMastersList, 260, 10);
					}

					//    If grdVoucherDetails.Columns(mDrCrTypeColumn).Visible = True Then
					//        Set rsDrCrTypeList = New ADODB.Recordset
					//        rsDrCrTypeList.Fields.Append "dr_cr_type_name", adChar, 2
					//        rsDrCrTypeList.Open
					//        rsDrCrTypeList.AddNew "dr_cr_type_name", mDrTypeCaption
					//        rsDrCrTypeList.AddNew "dr_cr_type_name", mCrTypeCaption
					//        rsDrCrTypeList.Update
					//    End If

					DefineMasterRecordset();
					mFirstGridFocus = false;
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdVoucherDetails.PostMsg(1);
				}
				else
				{

				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		//Private Sub grdVoucherDetails_KeyDown(KeyCode As Integer, Shift As Integer)
		//If KeyCode = 40 Then
		//   grdVoucherDetails.Col = mLedgerCodeColumn
		//End If
		//End Sub

		private void grdVoucherDetails_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					if (KeyAscii == 39)
					{ //'handle singlequote
						KeyAscii = 0;
					}

					//commented by Moiz Hakimi
					//if user presses 'C' or 'D' button, Dr/Cr column should be automatically be texted 'Dr' or 'Cr'
					if (grdVoucherDetails.Col == mDrCrTypeColumn)
					{
						if (KeyAscii == 99 || KeyAscii == 196)
						{
							grdVoucherDetails.Columns[mDrCrTypeColumn].Text = "Cr";
							grdVoucherDetails.UpdateData();
							CalculateTotals(grdVoucherDetails.Row, grdVoucherDetails.Col);
						}
						else if (KeyAscii == 100 || KeyAscii == 237)
						{ 
							grdVoucherDetails.Columns[mDrCrTypeColumn].Text = "Dr";
							grdVoucherDetails.UpdateData();
							CalculateTotals(grdVoucherDetails.Row, grdVoucherDetails.Col);
						}
					}
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
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

		private void grdVoucherDetails_Leave(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				grdVoucherDetails.UpdateData();
				Application.DoEvents();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				grdVoucherDetails.Columns[mLineNoColumn].Text = (grdVoucherDetails.RowCount + 1).ToString();

				//-------------------------------------------------------------------------------
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Single_Entry_Type"]) == "D")
				{
					grdVoucherDetails.Columns[mDrCrTypeColumn].Text = "Dr";
				}
				else if (Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Single_Entry_Type"]) == "C")
				{ 
					grdVoucherDetails.Columns[mDrCrTypeColumn].Text = "Cr";
				}
				else
				{
					grdVoucherDetails.Columns[mDrCrTypeColumn].Text = "Dr";
				}
				//-------------------------------------------------------------------------------
				//If grdVoucherDetails.Col = mDebitAmountColumn Then
				//    grdVoucherDetails.Columns(mDrCrTypeColumn).Text = mDrTypeCaption
				//ElseIf grdVoucherDetails.Col = mCreditAmountColumn Then
				//    grdVoucherDetails.Columns(mDrCrTypeColumn).Text = mCrTypeCaption
				//Else
				//    If rsGLVoucherTypes.Fields("Allow_Single_Entry").Value = False And Val(Format(grdVoucherDetails.Columns(mDebitAmountColumn).FooterText, "###########0.000")) > Val(Format(grdVoucherDetails.Columns(mCreditAmountColumn).FooterText, "###########0.000")) Then
				//        grdVoucherDetails.Columns(mDrCrTypeColumn).Text = mCrTypeCaption
				//    ElseIf rsGLVoucherTypes.Fields("Allow_Single_Entry").Value = False And Val(Format(grdVoucherDetails.Columns(mCreditAmountColumn).FooterText, "###########0.000")) > Val(Format(grdVoucherDetails.Columns(mDebitAmountColumn).FooterText, "###########0.000")) Then
				//        grdVoucherDetails.Columns(mDrCrTypeColumn).Text = mDrTypeCaption
				//    Else
				//        If rsGLVoucherTypes.Fields("Default_Dr_Cr_Type") = "D" Then
				//            grdVoucherDetails.Columns(mDrCrTypeColumn).Text = mDrTypeCaption
				//        Else
				//            grdVoucherDetails.Columns(mDrCrTypeColumn).Text = mCrTypeCaption
				//        End If
				//    End If
				//End If
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void CalculateTotals(int mRowNumber, int mColNumber)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;
				double mAmount = 0;

				//If aVoucherDetails.Count(1) > 1 Then
				if (aVoucherDetails.GetLength(0) >= 1)
				{
					if (mColNumber == mExchangeRateColumn)
					{
						if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, mFCAmountColumn))) != 0)
						{
							aVoucherDetails.SetValue(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, mExchangeRateColumn))) * Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, mFCAmountColumn))), mRowNumber, mLCAmountColumn);
						}
					}
					else if (mColNumber == mFCAmountColumn)
					{ 
						if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, mExchangeRateColumn))) != 0)
						{
							aVoucherDetails.SetValue(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, mExchangeRateColumn))) * Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, mFCAmountColumn))), mRowNumber, mLCAmountColumn);
						}
					}
					else if (mColNumber == mLCAmountColumn)
					{ 
						if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, mFCAmountColumn))) != 0)
						{
							aVoucherDetails.SetValue(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, mLCAmountColumn))) / Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, mFCAmountColumn))), mRowNumber, mExchangeRateColumn);
						}
					}
				}

				double mTotalDebitAmount = 0;
				double mTotalCreditAmount = 0;
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					mAmount = Conversion.Val(StringsHelper.Replace(Convert.ToString(aVoucherDetails.GetValue(Cnt, mLCAmountColumn)), ",", "", 1, -1, CompareMethod.Binary));

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdVoucherDetails.Splits[0].DisplayColumns[mDebitAmountColumn].Visible && grdVoucherDetails.Splits[0].DisplayColumns[mCreditAmountColumn].Visible)
					{
						mTotalDebitAmount += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mDebitAmountColumn)));
						mTotalCreditAmount += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mCreditAmountColumn)));
					}
					else
					{
						if (Convert.ToString(aVoucherDetails.GetValue(Cnt, mDrCrTypeColumn)).Trim() == "Dr")
						{
							mTotalDebitAmount += Double.Parse(StringsHelper.Format(mAmount, "###############0.000"));
						}
						else if (Convert.ToString(aVoucherDetails.GetValue(Cnt, mDrCrTypeColumn)).Trim() == "Cr")
						{ 
							mTotalCreditAmount += Double.Parse(StringsHelper.Format(mAmount, "###############0.000"));
						}
					}
				}

				if (mTotalDebitAmount != 0)
				{
					//grdVoucherDetails.Columns(mDebitAmountColumn).FooterText = Format(mTotalDebitAmount, "###,###,###,###,##0.000")
					txtTotalDR.Text = StringsHelper.Format(mTotalDebitAmount, "###,###,###,###,##0.000");
				}
				else
				{
					//grdVoucherDetails.Columns(mDebitAmountColumn).FooterText = ""
					txtTotalDR.Text = "";
				}

				if (mTotalCreditAmount != 0)
				{
					//grdVoucherDetails.Columns(mCreditAmountColumn).FooterText = Format(mTotalCreditAmount, "###,###,###,###,##0.000")
					txtTotalCR.Text = StringsHelper.Format(mTotalCreditAmount, "###,###,###,###,##0.000");
				}
				else
				{
					//grdVoucherDetails.Columns(mCreditAmountColumn).FooterText = ""
					txtTotalCR.Text = "";
				}

				//'''Display the balance
				if (UCStatusBar.FindPane(SystemGLConstants.lcDiffrence1).Visible)
				{
					if (mTotalDebitAmount > mTotalCreditAmount)
					{
						UCStatusBar.FindPane(SystemGLConstants.lcDiffrence2).Text = StringsHelper.Format(mTotalDebitAmount - mTotalCreditAmount, "###,###,###,###,##0.000") + " (Cr)";
					}
					else if (mTotalDebitAmount < mTotalCreditAmount)
					{ 
						UCStatusBar.FindPane(SystemGLConstants.lcDiffrence2).Text = StringsHelper.Format(mTotalCreditAmount - mTotalDebitAmount, "###,###,###,###,##0.000") + " (Dr)";
					}
					else
					{
						UCStatusBar.FindPane(SystemGLConstants.lcDiffrence2).Text = "";
					}
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["allow_single_entry"]) && Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Single_Entry_Type"]) == "D")
				{
					txtTotalCR.Text = txtTotalDR.Text;
				}
				else if (Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["allow_single_entry"]) && Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Single_Entry_Type"]) == "C")
				{ 
					txtTotalDR.Text = txtTotalCR.Text;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void AssignGridLineNumbers()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					aVoucherDetails.SetValue(Cnt + 1, Cnt, mLineNoColumn);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void DefineVoucherArray(int pMaximumRows, bool pClearArray = false)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (pClearArray)
				{
					//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					aVoucherDetails.Clear();
				}
				aVoucherDetails.RedimXArray(new int[]{pMaximumRows, conMaxGLTransCols}, new int[]{0, 0});
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public bool saveRecord(bool pApprove = false)
		{
			bool result = false;
			object mTempItemInfo = null;
			int mLedgerCode = 0;
			int mCurrenyCode = 0;
			int mCostCenterCode = 0;
			object mConsignmentCode = null;
			object mSalesmanCode = null;
			object mProjectCode = null;
			string mAnlyCode1 = "";
			string mAnlyCode2 = "";

			string mChequeNo = "";
			bool mAutoGenerateVoucherNo = false;
			int mNewEntryID = 0;
			string mysql = "";
			int Cnt = 0;
			int mDebitLineNumber = 0;
			int mCreditLineNumber = 0;
			double mExchangeRate = 0;
			int mCreditDays = 0;
			decimal mFCAmount = 0;
			decimal mLCAmount = 0;
			string mFlex1 = "";

			string mDrCrType = "";

			try
			{
				SystemVariables.gConn.BeginTransaction();

				//Check the autogenerate voucher no method
				DataSet withVar = null;
				withVar = rsGLVoucherTypes;
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method withVar.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				withVar.MoveFirst();
				withVar.Find("voucher_type = " + Conversion.Str(cmbVoucherTypes.GetItemData(cmbVoucherTypes.ListIndex)));
				if (withVar.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mAutoGenerateVoucherNo = Convert.ToBoolean(withVar.Tables[0].Rows[0]["Auto_Generate_Voucher_No"]);
				}
				else
				{
					mAutoGenerateVoucherNo = true;
				}

				//Check if is empty
				if (!mAutoGenerateVoucherNo)
				{
					if (SystemProcedure2.IsItEmpty(txtVoucherNo.Text, SystemVariables.DataType.NumberType))
					{
						MessageBox.Show("Enter the voucher No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtVoucherNo.Focus();
						result = false;
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return result;
					}
				}

				//check for duplication after the transaction begins.
				if (!mAutoGenerateVoucherNo)
				{
					//    mySql = " select voucher_no from gl_accnt_trans"
					//    mySql = mySql & " where voucher_no = " & txtVoucherNo.Text
					//    mySql = mySql & " and voucher_type = " & Str(cmbVoucherTypes.ItemData(cmbVoucherTypes.ListIndex))
					//    If CurrentFormMode = frmEditMode Then
					//        mySql = mySql & " and entry_id <>" & Str(SearchValue)
					//    End If
					//    mTempItemInfo = GetMasterCode(mySql)
					//    If Not IsNull(mTempItemInfo) Then
					//        MsgBox "Duplicate Voucher No.", vbInformation, "Error"
					//        txtVoucherNo.SetFocus
					//        saveRecord = False
					//        gConn.RollbackTrans
					//        Exit Function
					//    End If
					if (IsDuplicateTransaction(Convert.ToInt32(Double.Parse(txtVoucherNo.Text)), Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(mSearchValue))), cmbVoucherTypes.GetItemData(cmbVoucherTypes.ListIndex), ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("gl_voucher_no_generate_method")), "", txtBranchCode.Text))
					{
						MessageBox.Show("Duplicate Voucher No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtVoucherNo.Focus();
						result = false;
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return result;
					}
				}

				//''Check if Date is greater than current date
				System.DateTime mdate = DateTime.FromOADate(0);
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_user_level_date_security")))
				{
					if (!SystemVariables.gAllowFuturedateTransaction)
					{
						mysql = " select convert(char(10),getdate(),103) as dt";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mdate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(SystemProcedure2.GetMasterCode(mysql));
						if (DateTime.Parse(txtVoucherDate.Text) > mdate)
						{
							MessageBox.Show("Invalid Date Range, Access denied for future date transaction", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtVoucherDate.Focus();
							result = false;
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							return result;
						}
					}
				}
				//----------------------------------------------------------------------

				DataSet rsGetEntryId = null;
				DataSet rsCheckTimeStamp = null;
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					if (mAutoGenerateVoucherNo)
					{
						mysql = " voucher_type = " + Conversion.Str(cmbVoucherTypes.GetItemData(cmbVoucherTypes.ListIndex));
						//txtVoucherNo.Text = GetNewNumber("gl_accnt_trans", "voucher_no", 2, mySql, " tablock(xlock) ")
						txtVoucherNo.Text = SystemGLProcedure.GLGetNewVoucherNo(cmbVoucherTypes.GetItemData(cmbVoucherTypes.ListIndex), StringsHelper.Format(txtVoucherDate.Value, SystemVariables.gSystemDateFormat), txtBranchCode.Text).ToString();
					}

					mysql = " insert into gl_accnt_trans ( voucher_type, voucher_date, voucher_no ";
					mysql = mysql + " , reference_no";
					mysql = mysql + " , pdc_due_date, cheque_no , linked_module_id ";
					mysql = mysql + " , comments, flex_01, branch_cd, user_cd ";
					mysql = mysql + ")";
					mysql = mysql + " values ( ";
					mysql = mysql + Conversion.Str(cmbVoucherTypes.GetItemData(cmbVoucherTypes.ListIndex)) + ",";
					mysql = mysql + "'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
					mysql = mysql + ",'" + Conversion.Str(txtVoucherNo.Text).Trim() + "',";
					mysql = mysql + "N'" + txtReferenceNo.Text + "'";

					if (txtMaturityDate.Visible == (TriState.True != TriState.False) && !SystemProcedure2.IsItEmpty(txtMaturityDate.Value, SystemVariables.DataType.DateType))
					{
						mysql = mysql + ", cast('" + ReflectionHelper.GetPrimitiveValue<string>(txtMaturityDate.Value) + "' as smalldatetime) ";
					}
					else
					{
						mysql = mysql + ", NULL ";
					}

					if (txtChequeNo.Visible && txtChequeNo.Text != "")
					{
						mysql = mysql + ", '" + txtChequeNo.Text + "'";
					}
					else
					{
						mysql = mysql + ", NULL ";
					}
					mysql = mysql + " , 2 ";
					mysql = mysql + ", N'" + txtComments.Text + "'";
					mysql = mysql + ", N'" + txtFlex01.Text + "'";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Show_Branch_Code_In_Header"]))
					{
						mysql = mysql + ", '" + txtBranchCode.Text + "'";
					}
					else
					{
						mysql = mysql + ", NULL ";
					}
					mysql = mysql + " , " + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " )";
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
					rsGetEntryId = TempDataset_2;
					if (rsGetEntryId.Tables[0].Rows.Count != 0)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mNewEntryID = Convert.ToInt32(rsGetEntryId.Tables[0].Rows[0][0]);
					}
					else
					{
						MessageBox.Show("Error : Can not proceed with save!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}
					rsGetEntryId = null;
				}
				else
				{
					//*--updating main transaction table
					//*-- check whether the row is in the same status when it was retreived from the table for updation
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = "select time_stamp from gl_accnt_trans where entry_id = " + Conversion.Str(mSearchValue);
					SqlDataAdapter TempAdapter_3 = null;
					TempAdapter_3 = new SqlDataAdapter();
					TempAdapter_3.SelectCommand = TempCommand_3;
					DataSet TempDataset_3 = null;
					TempDataset_3 = new DataSet();
					TempAdapter_3.Fill(TempDataset_3);
					rsCheckTimeStamp = TempDataset_3;
					if (rsCheckTimeStamp.Tables[0].Rows.Count != 0)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mCheckTimeStamp = Convert.ToString(rsCheckTimeStamp.Tables[0].Rows[0][0]);
					}
					if ((rsCheckTimeStamp.Tables[0].Rows.Count == 0) || (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp)))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						FirstFocusObject.Focus();
						return result;
					}

					//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mNewEntryID = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);
					if (mOldVoucherStatus == SystemVariables.VoucherStatus.stActive)
					{
						mysql = " update gl_accnt_trans ";
						mysql = mysql + " set voucher_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
						mysql = mysql + " , voucher_no ='" + Conversion.Str(txtVoucherNo.Text).Trim() + "'";
						mysql = mysql + " , reference_no = N'" + txtReferenceNo.Text + "'";

						if (txtMaturityDate.Visible == (TriState.True != TriState.False) && !SystemProcedure2.IsItEmpty(txtMaturityDate.Value, SystemVariables.DataType.DateType))
						{
							mysql = mysql + " , pdc_due_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtMaturityDate.Value) + "'";
						}
						else
						{
							mysql = mysql + " , pdc_due_date = NULL ";
						}

						if (txtChequeNo.Visible && txtChequeNo.Text != "")
						{
							mysql = mysql + " , cheque_no = '" + txtChequeNo.Text + "'";
						}
						else
						{
							mysql = mysql + " , cheque_no = NULL ";
						}

						mysql = mysql + " , comments = N'" + txtComments.Text + "'";
						mysql = mysql + " , flex_01 = N'" + txtFlex01.Text + "'";

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Show_Branch_Code_In_Header"]))
						{
							mysql = mysql + " , branch_cd = '" + txtBranchCode.Text + "'";
						}
						else
						{
							mysql = mysql + " , branch_cd = null ";
						}

						mysql = mysql + " , user_cd = " + Conversion.Str(SystemVariables.gLoggedInUserCode);
						mysql = mysql + " where entry_id = " + Conversion.Str(mSearchValue);
						SqlCommand TempCommand_4 = null;
						TempCommand_4 = SystemVariables.gConn.CreateCommand();
						TempCommand_4.CommandText = mysql;
						TempCommand_4.ExecuteNonQuery();

						//'this was done due to problem in honest.
						//        If GetSystemPreferenceSetting("voucher_adjustment") = True Then
						//            'Get the TimeStamp from gl_accnt_trans_details
						//            'And compare it with the initially saved time_stamp in the Local Array
						//            mySql = " select line_no, time_stamp "
						//            mySql = mySql & " from gl_accnt_trans_details atd "
						//            mySql = mySql & " where line_no in (select against_line_no from "
						//            mySql = mySql & " gl_invoice_tracking vt inner join gl_accnt_trans_details atd2 "
						//            mySql = mySql & " on vt.source_line_no = atd2.line_no "
						//            mySql = mySql & " where atd2.entry_id = " & Str(mSearchValue)
						//            mySql = mySql & " union "
						//            mySql = mySql & " select source_line_no from "
						//            mySql = mySql & " gl_invoice_tracking vt inner join gl_accnt_trans_details atd2 "
						//            mySql = mySql & " on vt.against_line_no = atd2.line_no "
						//            mySql = mySql & " where atd2.entry_id = " & Str(mSearchValue)
						//            mySql = mySql & " ) "
						//            Set rsLinkedTimeStamps = gConn.Execute(mySql)
						//            With rsLinkedTimeStamps
						//                Do While Not .EOF
						//                    Dim mFoundLineNo As Long
						//
						//                    ''''Handle the error if the array is empty.
						//                    If aAdjustedVoucherDetails.Count(1) > 0 Then
						//                        mFoundLineNo = aAdjustedVoucherDetails.Find(0, Val(conVLAgainstLineNoColumn), Val(.Fields("line_no").Value), XORDER_ASCEND, XCOMP_DEFAULT, XTYPE_LONG)
						//                    Else
						//                        mFoundLineNo = -1
						//                    End If
						//                    If mFoundLineNo >= 0 Then
						//                        If tsFormat(aAdjustedVoucherDetails(mFoundLineNo, conVLLinkedTimeStampColumn)) <> tsFormat(.Fields("time_stamp").Value) Then
						//                            gConn.RollbackTrans
						//                            MsgBox "Some of the Adjusted Vouchers has modified by another user!", vbInformation, "Error:"
						//                            saveRecord = False
						//                            FirstFocusObject.SetFocus
						//                            Exit Function
						//                        End If
						//                    End If
						//                    rsLinkedTimeStamps.MoveNext
						//                Loop
						//            End With
						//            Set rsLinkedTimeStamps = Nothing
						//        End If

						//**-------------------------------------------------------------------------------
						//**--deleting old linked transaction entries
						mysql = " delete from gl_invoice_tracking ";
						mysql = mysql + " from gl_invoice_tracking vt inner join gl_accnt_trans_details atd ";
						mysql = mysql + " on vt.source_line_no = atd.line_no ";
						mysql = mysql + " where atd.entry_id = " + Conversion.Str(mSearchValue);
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();

						mysql = " delete from gl_invoice_tracking ";
						mysql = mysql + " from gl_invoice_tracking vt inner join gl_accnt_trans_details atd ";
						mysql = mysql + " on vt.against_line_no = atd.line_no ";
						mysql = mysql + " where atd.entry_id = " + Conversion.Str(mSearchValue);
						SqlCommand TempCommand_6 = null;
						TempCommand_6 = SystemVariables.gConn.CreateCommand();
						TempCommand_6.CommandText = mysql;
						TempCommand_6.ExecuteNonQuery();
						//**------------------------------------------------------------------------------

						//**--deleting old transaction entries
						mysql = " delete from gl_accnt_trans_details where entry_id = " + Conversion.Str(mSearchValue);
						SqlCommand TempCommand_7 = null;
						TempCommand_7 = SystemVariables.gConn.CreateCommand();
						TempCommand_7.CommandText = mysql;
						TempCommand_7.ExecuteNonQuery();
						//**------------------------------------------------------------------------------
					}
					else
					{
						throw new System.Exception("1");
					}
				}

				//updating account details transaction table
				mDebitLineNumber = 0;
				mCreditLineNumber = 0;
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{

					//    If Val(aVoucherDetails(cnt, mDebitAmountColumn)) > 0 And Val(aVoucherDetails(cnt, mCreditAmountColumn)) > 0 Then
					//        '''This situation is rarely to occur but still a check is done while save.
					//        gConn.RollbackTrans
					//        MsgBox "Invalid Amount in Debit and Credit Column", vbInformation, "Error"
					//        grdVoucherDetails.Col = mLedgerCodeColumn
					//        grdVoucherDetails.Bookmark = cnt
					//        grdVoucherDetails.SetFocus
					//        saveRecord = False
					//        Exit Function
					//    End If

					//    '*-- check for valid ledger code
					//    mySql = "select ldgr_cd, curr_cd, credit_limit_days "
					//    mySql = mySql & " from gl_ledger l where ldgr_no ='" & aVoucherDetails(cnt, mLedgerCodeColumn) & "'"
					//    'mySql = mySql & IIf(aVoucherDetails(cnt, mDrCrTypeColumn) = mDrTypeCaption, IIf(IsNull(rsGLVoucherTypes.Fields("Debit_Filter_Condition").Value) = False, " and ( " & rsGLVoucherTypes.Fields("Debit_Filter_Condition").Value & " )", ""), IIf(IsNull(rsGLVoucherTypes.Fields("Credit_Filter_Condition").Value) = False, " and ( " & rsGLVoucherTypes.Fields("Credit_Filter_Condition").Value & " )", ""))
					//    If Val(aVoucherDetails(cnt, mDebitAmountColumn)) > 0 Then
					//        If Not IsNull(rsGLVoucherTypes.Fields("Debit_Filter_Condition").Value) Then
					//            mySql = mySql & " and " & rsGLVoucherTypes.Fields("Debit_Filter_Condition").Value
					//        End If
					//    End If
					//
					//    If Val(aVoucherDetails(cnt, mCreditAmountColumn)) > 0 Then
					//        If Not IsNull(rsGLVoucherTypes.Fields("credit_Filter_Condition").Value) Then
					//            mySql = mySql & " and " & rsGLVoucherTypes.Fields("credit_Filter_Condition").Value
					//        End If
					//    End If

					if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, mLedgerCodeColumn)) || Convert.ToString(aVoucherDetails.GetValue(Cnt, mLedgerCodeColumn)) != "")
					{
						//*-- check for valid ledger code
						mysql = "select ldgr_cd, curr_cd, credit_limit_days ";
						mysql = mysql + " from gl_ledger l where ldgr_no ='" + Convert.ToString(aVoucherDetails.GetValue(Cnt, mLedgerCodeColumn)) + "'";
						//mySql = mySql & IIf(aVoucherDetails(cnt, mDrCrTypeColumn) = mDrTypeCaption, IIf(IsNull(rsGLVoucherTypes.Fields("Debit_Filter_Condition").Value) = False, " and ( " & rsGLVoucherTypes.Fields("Debit_Filter_Condition").Value & " )", ""), IIf(IsNull(rsGLVoucherTypes.Fields("Credit_Filter_Condition").Value) = False, " and ( " & rsGLVoucherTypes.Fields("Credit_Filter_Condition").Value & " )", ""))

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["allow_single_entry"])) == TriState.True)
						{
							//If Val(aVoucherDetails(cnt, mDebitAmountColumn)) > 0 Then
							if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mLCAmountColumn))) > 0 && Convert.ToString(aVoucherDetails.GetValue(Cnt, mDrCrTypeColumn)) == "Dr")
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								if (!rsGLVoucherTypes.Tables[0].Rows[0].IsNull("Debit_Filter_Condition"))
								{
									//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
									mysql = mysql + " and ( " + Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Debit_Filter_Condition"]) + " ) ";
								}
							}

							//If Val(aVoucherDetails(cnt, mCreditAmountColumn)) > 0 Then
							if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mLCAmountColumn))) > 0 && Convert.ToString(aVoucherDetails.GetValue(Cnt, mDrCrTypeColumn)) == "Cr")
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								if (!rsGLVoucherTypes.Tables[0].Rows[0].IsNull("credit_Filter_Condition"))
								{
									//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
									mysql = mysql + " and ( " + Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["credit_Filter_Condition"]) + " ) ";
								}
							}
						}
						else
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							if (!rsGLVoucherTypes.Tables[0].Rows[0].IsNull("Debit_Filter_Condition"))
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mysql = mysql + " and ( " + Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Debit_Filter_Condition"]) + " ) ";
							}
						}

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempItemInfo = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempItemInfo))
						{
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							MessageBox.Show("Invalid Ledger Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
							grdVoucherDetails.Col = mLedgerCodeColumn;
							grdVoucherDetails.Bookmark = Cnt;
							grdVoucherDetails.Focus();
							return false;
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempItemInfo() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mLedgerCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempItemInfo).GetValue(0));
							//mCurrenyCode = mTempItemInfo(1)
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(((Array) mTempItemInfo).GetValue(2)))
							{
								//UPGRADE_WARNING: (1068) mTempItemInfo() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mCreditDays = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempItemInfo).GetValue(2));
							}
							else
							{
								mCreditDays = 0;
							}

							mysql = " select curr_cd from gl_currency where symbol = '" + Convert.ToString(aVoucherDetails.GetValue(Cnt, mCurrencySymbolColumn)) + "'";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempItemInfo = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mTempItemInfo))
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								MessageBox.Show("Invalid Currency Symbol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								if (grdVoucherDetails.Splits[0].DisplayColumns[mCurrencySymbolColumn].Visible)
								{
									grdVoucherDetails.Col = mCurrencySymbolColumn;
								}
								grdVoucherDetails.Bookmark = Cnt;
								grdVoucherDetails.Focus();
								return false;
							}
							else
							{
								//UPGRADE_WARNING: (1068) mTempItemInfo of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mCurrenyCode = ReflectionHelper.GetPrimitiveValue<int>(mTempItemInfo);
							}

							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
							if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("cost_center"))) == TriState.True)
							{
								//*--check for valid cost center code
								if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, mCostCenterColumn), SystemVariables.DataType.NumberType))
								{
									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mTempItemInfo = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select cost_cd from gl_cost_centers where cost_no =" + Conversion.Str(aVoucherDetails.GetValue(Cnt, mCostCenterColumn))));
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
									if (Convert.IsDBNull(mTempItemInfo))
									{
										//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
										SystemVariables.gConn.RollbackTrans();
										MessageBox.Show("Invalid Cost Center Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
										grdVoucherDetails.Col = mCostCenterColumn;
										grdVoucherDetails.Bookmark = Cnt;
										grdVoucherDetails.Focus();
										return false;
									}
									else
									{
										//UPGRADE_WARNING: (1068) mTempItemInfo of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
										mCostCenterCode = ReflectionHelper.GetPrimitiveValue<int>(mTempItemInfo);
									}
								}
								else
								{
									//**--cost center must be specified if the cost center is enabled on the ledger
									//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
									SystemVariables.gConn.RollbackTrans();
									MessageBox.Show("Invalid cost center code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
									grdVoucherDetails.Col = mCostCenterColumn;
									grdVoucherDetails.Bookmark = Cnt;
									grdVoucherDetails.Focus();
									return false;
								}
								//** -----------------------------------------------------------------------------------
							}
							else
							{
								mCostCenterCode = 1;
							}
						}
						//** -----------------------------------------------------------------------------------
						//*--check for valid consignment code
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, mConsignmentColumn), SystemVariables.DataType.StringType) && grdVoucherDetails.Splits[0].DisplayColumns[mConsignmentColumn].Visible)
						{
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempItemInfo = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select consignment_cd from gl_consignment where consignment_no = '" + Convert.ToString(aVoucherDetails.GetValue(Cnt, mConsignmentColumn)) + "'"));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mTempItemInfo))
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								MessageBox.Show("Invalid Consignment Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
								grdVoucherDetails.Col = mConsignmentColumn;
								grdVoucherDetails.Bookmark = Cnt;
								grdVoucherDetails.Focus();
								return false;
							}
							else
							{
								//UPGRADE_WARNING: (1068) mTempItemInfo of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mConsignmentCode = ReflectionHelper.GetPrimitiveValue(mTempItemInfo);
							}
						}
						else
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							mConsignmentCode = DBNull.Value;
						}
						//** -----------------------------------------------------------------------------------
						//*--check for valid salesman code
						if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, mSalesmanColumn), SystemVariables.DataType.NumberType))
						{
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempItemInfo = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select sman_cd from SM_Salesman where sman_no =" + Conversion.Str(aVoucherDetails.GetValue(Cnt, mSalesmanColumn))));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mTempItemInfo))
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								MessageBox.Show("Invalid Salemsan Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
								grdVoucherDetails.Col = mSalesmanColumn;
								grdVoucherDetails.Bookmark = Cnt;
								grdVoucherDetails.Focus();
								return false;
							}
							else
							{
								//UPGRADE_WARNING: (1068) mTempItemInfo of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mSalesmanCode = ReflectionHelper.GetPrimitiveValue(mTempItemInfo);
							}
						}
						else
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							mSalesmanCode = DBNull.Value;
						}

						//** -----------------------------------------------------------------------------------
						//*--check for valid Anlysis code
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, mAnlyCode1Column), SystemVariables.DataType.StringType) && grdVoucherDetails.Splits[0].DisplayColumns[mAnlyCode1Column].Visible)
						{
							mysql = " select anly_code from gl_analysis where anly_code ='" + Convert.ToString(aVoucherDetails.GetValue(Cnt, mAnlyCode1Column)) + "'";
							mysql = mysql + " and anly_head_no = 1 ";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempItemInfo = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mTempItemInfo))
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								MessageBox.Show("Invalid Anlysis Code 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
								grdVoucherDetails.Col = mAnlyCode1Column;
								grdVoucherDetails.Bookmark = Cnt;
								grdVoucherDetails.Focus();
								return false;
							}
							else
							{
								//UPGRADE_WARNING: (1068) mTempItemInfo of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mAnlyCode1 = ReflectionHelper.GetPrimitiveValue<string>(mTempItemInfo);
							}
						}
						else
						{
							mAnlyCode1 = "";
						}

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, mAnlyCode2Column), SystemVariables.DataType.StringType) && grdVoucherDetails.Splits[0].DisplayColumns[mAnlyCode2Column].Visible)
						{
							mysql = " select anly_code from gl_analysis where anly_code ='" + Convert.ToString(aVoucherDetails.GetValue(Cnt, mAnlyCode2Column)) + "'";
							mysql = mysql + " and anly_head_no = 2 ";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempItemInfo = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mTempItemInfo))
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								MessageBox.Show("Invalid Anlysis Code 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
								grdVoucherDetails.Col = mAnlyCode2Column;
								grdVoucherDetails.Bookmark = Cnt;
								grdVoucherDetails.Focus();
								return false;
							}
							else
							{
								//UPGRADE_WARNING: (1068) mTempItemInfo of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mAnlyCode2 = ReflectionHelper.GetPrimitiveValue<string>(mTempItemInfo);
							}
						}
						else
						{
							mAnlyCode2 = "";
						}
						//** -----------------------------------------------------------------------------------

						//** -----------------------------------------------------------------------------------
						//*--check for valid project code
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, mProjectColumn), SystemVariables.DataType.StringType) && grdVoucherDetails.Splits[0].DisplayColumns[mProjectColumn].Visible)
						{
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempItemInfo = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select project_cd from PROJ_Projects where project_no = '" + Convert.ToString(aVoucherDetails.GetValue(Cnt, mProjectColumn)) + "'"));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mTempItemInfo))
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								MessageBox.Show("Invalid project code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
								grdVoucherDetails.Col = mProjectColumn;
								grdVoucherDetails.Bookmark = Cnt;
								grdVoucherDetails.Focus();
								return false;
							}
							else
							{
								//UPGRADE_WARNING: (1068) mTempItemInfo of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mProjectCode = ReflectionHelper.GetPrimitiveValue(mTempItemInfo);
							}
						}
						else
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							mProjectCode = DBNull.Value;
						}

						//** -----------------------------------------------------------------------------------
						//*--cheque no.
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, mChequeNoColumn), SystemVariables.DataType.StringType) && grdVoucherDetails.Splits[0].DisplayColumns[mChequeNoColumn].Visible)
						{
							mChequeNo = Convert.ToString(aVoucherDetails.GetValue(Cnt, mChequeNoColumn));
						}
						else
						{
							if (txtChequeNo.Visible)
							{
								mChequeNo = txtChequeNo.Text;
							}
							else
							{
								mChequeNo = "";
							}
						}

						//** -----------------------------------------------------------------------------------
						//** -----------------------------------------------------------------------------------
						//*--cheque no.
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, mFlex1Column), SystemVariables.DataType.StringType) && grdVoucherDetails.Splits[0].DisplayColumns[mFlex1Column].Visible)
						{
							mFlex1 = Convert.ToString(aVoucherDetails.GetValue(Cnt, mFlex1Column));
						}
						else
						{
							mFlex1 = "";
						}

						//** -----------------------------------------------------------------------------------
						//*-- check for valid debit & credit amount column values

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[mDebitAmountColumn].Visible && grdVoucherDetails.Splits[0].DisplayColumns[mCreditAmountColumn].Visible)
						{
							if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mDebitAmountColumn))) == 0 && Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mCreditAmountColumn))) == 0)
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								MessageBox.Show("Invalid Ledger Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								if (grdVoucherDetails.Splits[0].DisplayColumns[mLCAmountColumn].Visible)
								{
									grdVoucherDetails.Col = mLCAmountColumn;
								}
								grdVoucherDetails.Bookmark = Cnt;
								grdVoucherDetails.Focus();
								return false;
							}
						}
						else if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mLCAmountColumn))) == 0)
						{ 
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							MessageBox.Show("Invalid Ledger Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							if (grdVoucherDetails.Splits[0].DisplayColumns[mLCAmountColumn].Visible)
							{
								grdVoucherDetails.Col = mLCAmountColumn;
							}
							grdVoucherDetails.Bookmark = Cnt;
							grdVoucherDetails.Focus();
							return false;
						}
						//** -----------------------------------------------------------------------------------



						if (mCurrenyCode != SystemGLConstants.gDefaultCurrencyCd)
						{
							if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mExchangeRateColumn))) != 0)
							{
								mExchangeRate = Convert.ToDouble(aVoucherDetails.GetValue(Cnt, mExchangeRateColumn));
								if (Convert.ToString(aVoucherDetails.GetValue(Cnt, mDrCrTypeColumn)) == "Dr")
								{
									mLCAmount = (decimal) Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mLCAmountColumn)));
								}
								else
								{
									mLCAmount = (decimal) (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mLCAmountColumn))) * -1);
								}
								if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mFCAmountColumn))) != 0)
								{
									if (Convert.ToString(aVoucherDetails.GetValue(Cnt, mDrCrTypeColumn)) == "Dr")
									{
										mFCAmount = (decimal) Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mFCAmountColumn)));
										mDebitLineNumber++;
									}
									else
									{
										mFCAmount = (decimal) (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mFCAmountColumn))) * -1);
										mCreditLineNumber++;
									}
								}

								//--------------------------------------------------------------------------------------------------------------
								//            Else
								//                MsgBox "Please enter FC Amount ", vbExclamation
								//                gConn.RollbackTrans
								//                MsgBox "Please enter Exchange Rate", vbExclamation
								//                saveRecord = False
								//                Exit Function
								//            End If
								//--------------------------------------------------------------------------------------------------------------
							}
							else
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								MessageBox.Show("Please enter Exchange Rate", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								return false;
							}
						}
						else
						{
							mExchangeRate = 1;
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							if (grdVoucherDetails.Splits[0].DisplayColumns[mDebitAmountColumn].Visible && grdVoucherDetails.Splits[0].DisplayColumns[mCreditAmountColumn].Visible)
							{
								if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mDebitAmountColumn))) > 0)
								{
									aVoucherDetails.SetValue("Dr", Cnt, mDrCrTypeColumn);
									mLCAmount = Convert.ToDecimal(aVoucherDetails.GetValue(Cnt, mDebitAmountColumn));
									mFCAmount = Convert.ToDecimal(aVoucherDetails.GetValue(Cnt, mDebitAmountColumn));
									mDebitLineNumber++;
								}
								else if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mCreditAmountColumn))) > 0)
								{ 
									aVoucherDetails.SetValue("Cr", Cnt, mDrCrTypeColumn);
									mLCAmount = (decimal) (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mCreditAmountColumn))) * -1);
									mFCAmount = (decimal) (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mCreditAmountColumn))) * -1);
									mCreditLineNumber++;
								}
							}
							else
							{

								if (Convert.ToString(aVoucherDetails.GetValue(Cnt, mDrCrTypeColumn)) == "Dr")
								{
									mLCAmount = Convert.ToDecimal(aVoucherDetails.GetValue(Cnt, mLCAmountColumn));
									mFCAmount = Convert.ToDecimal(aVoucherDetails.GetValue(Cnt, mLCAmountColumn));
									mDebitLineNumber++;
								}
								else
								{
									mLCAmount = (decimal) (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mLCAmountColumn))) * -1);
									mFCAmount = (decimal) (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mLCAmountColumn))) * -1);
									mCreditLineNumber++;
								}
							}
						}

						mysql = " insert into gl_accnt_trans_details ( entry_id, ldgr_cd, curr_cd, sman_cd, project_cd ";
						mysql = mysql + " , anly_code_1, anly_head_no_1 , anly_code_2, anly_head_no_2 ";
						mysql = mysql + " , cost_cd , exchange_rate, fc_amount, lc_amount, due_date, ";
						mysql = mysql + " dr_cr_type, dr_cr_line_no, status";
						mysql = mysql + " , pdc_due_date, cheque_no ";
						mysql = mysql + " , comments, consignment_cd, flex1 )";
						mysql = mysql + " values ( ";
						mysql = mysql + Conversion.Str(mNewEntryID) + ",";
						mysql = mysql + mLedgerCode.ToString() + ",";
						mysql = mysql + mCurrenyCode.ToString() + ",";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mysql = mysql + ((Convert.IsDBNull(mSalesmanCode)) ? "null" : Conversion.Str(mSalesmanCode));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mysql = mysql + "," + ((Convert.IsDBNull(mProjectCode)) ? "null" : Conversion.Str(mProjectCode));

						if (mAnlyCode1 == "")
						{
							mysql = mysql + " , NULL "; //anly_code_1
							mysql = mysql + " , NULL "; //anly_head_no_1
						}
						else
						{
							mysql = mysql + " , '" + mAnlyCode1 + "'"; //anly_code_1
							mysql = mysql + " , 1"; //anly_head_no_1
						}

						if (mAnlyCode2 == "")
						{
							mysql = mysql + " , NULL "; //anly_code_2
							mysql = mysql + " , NULL "; //anly_head_no_2
						}
						else
						{
							mysql = mysql + " , '" + mAnlyCode2 + "'"; //anly_code_2
							mysql = mysql + " , 2"; //anly_head_no_2
						}

						mysql = mysql + " , " + ((mCostCenterCode == 0) ? "null" : Conversion.Str(mCostCenterCode)) + ",";
						mysql = mysql + Conversion.Str(mExchangeRate) + ",";


						//    If mCurrenyCode <> gDefaultCurrencyCd Then
						//        If Val(aVoucherDetails(cnt, mDebitAmountColumn)) > 0 Then
						//            mFCLineAmt = Val(aVoucherDetails(cnt, mLineFCAmountColumn))
						//            mLineAmt = Val(aVoucherDetails(cnt, mDebitAmountColumn))
						//        Else
						//            mFCLineAmt = (Val(aVoucherDetails(cnt, mLineFCAmountColumn)) * -1)
						//            mLineAmt = (Val(aVoucherDetails(cnt, mCreditAmountColumn)) * -1)
						//        End If
						//    Else
						//        If Val(aVoucherDetails(cnt, mDebitAmountColumn)) > 0 Then
						//            mLineAmt = Val(aVoucherDetails(cnt, mDebitAmountColumn))
						//            mFCLineAmt = Format(Val(aVoucherDetails(cnt, mDebitAmountColumn)), "############0.000")
						//        Else
						//            mLineAmt = (Val(aVoucherDetails(cnt, mCreditAmountColumn)) * -1)
						//            mFCLineAmt = (Format(Val(aVoucherDetails(cnt, mCreditAmountColumn)), "############0.000") * -1)
						//        End If
						//    End If

						mysql = mysql + Conversion.Str(mFCAmount) + ",";
						//mySql = mySql & Str(mLineAmt * mExchangeRate) & ","
						mysql = mysql + Conversion.Str(StringsHelper.Format(mLCAmount, "############0.000")) + ",";

						mysql = mysql + " cast('" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "' as smalldatetime) ";
						mysql = mysql + " + " + Conversion.Str(mCreditDays);

						mysql = mysql + "," + ((Convert.ToString(aVoucherDetails.GetValue(Cnt, mDrCrTypeColumn)) == "Cr") ? "'C'" : "'D'") + ",";

						if (mDebitLineNumber == 0 && Convert.ToString(aVoucherDetails.GetValue(Cnt, mDrCrTypeColumn)) == "Dr")
						{
							mDebitLineNumber++;
						}

						if (mCreditLineNumber == 0 && Convert.ToString(aVoucherDetails.GetValue(Cnt, mDrCrTypeColumn)) == "Cr")
						{
							mCreditLineNumber++;
						}

						mysql = mysql + Conversion.Str((Convert.ToString(aVoucherDetails.GetValue(Cnt, mDrCrTypeColumn)) == "Cr") ? mCreditLineNumber : mDebitLineNumber) + ",";

						mysql = mysql + " 2 "; //Status

						if (txtMaturityDate.Visible == (TriState.True != TriState.False) && !SystemProcedure2.IsItEmpty(txtMaturityDate.Value, SystemVariables.DataType.DateType))
						{
							mysql = mysql + ", cast('" + ReflectionHelper.GetPrimitiveValue<string>(txtMaturityDate.Value) + "' as smalldatetime) ";
						}
						else
						{
							mysql = mysql + ", NULL ";
						}

						//    If txtChequeNo.Visible = True And txtChequeNo.Text <> "" Then
						//        mySql = mySql & ", '" & txtChequeNo.Text & "'"
						//    Else
						//        mySql = mySql & ", NULL "
						//    End If

						if (mChequeNo != "")
						{
							mysql = mysql + ", '" + mChequeNo + "'";
						}
						else
						{
							mysql = mysql + ", NULL ";
						}

						mysql = mysql + ", N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, mRemarksColumn)) + "', ";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mysql = mysql + ((Convert.IsDBNull(mConsignmentCode)) ? "null" : Conversion.Str(mConsignmentCode));
						if (mFlex1 != "")
						{
							mysql = mysql + ", '" + mFlex1 + "'";
						}
						else
						{
							mysql = mysql + ", NULL ";
						}
						mysql = mysql + " )";
						SqlCommand TempCommand_8 = null;
						TempCommand_8 = SystemVariables.gConn.CreateCommand();
						TempCommand_8.CommandText = mysql;
						TempCommand_8.ExecuteNonQuery();

						//if voucher linking is enabled insert all the adjusted records in
						//invoice_tracking table
						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("voucher_adjustment")))
						{
							InsertAdjustedVoucherDetails(Convert.ToInt32(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mLineNoColumn)))));
						}
					}
				}

				//if voucher type allowes SINGLE ENTRY then generate the opposite entry
				double mDebitColumnTotalAmount = 0;
				double mCreditColumnTotalAmount = 0;
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Allow_Single_Entry"]))
				{

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempItemInfo = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select ldgr_cd, curr_cd, credit_limit_days from gl_ledger l where ldgr_no ='" + txtCashLedgerCode.Text + "'"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempItemInfo))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show("Invalid Ledger Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdVoucherDetails.Col = mLedgerCodeColumn;
						grdVoucherDetails.Bookmark = Cnt;
						grdVoucherDetails.Focus();
						return false;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempItemInfo() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLedgerCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempItemInfo).GetValue(0));
						//UPGRADE_WARNING: (1068) mTempItemInfo() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCurrenyCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempItemInfo).GetValue(1));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(((Array) mTempItemInfo).GetValue(2)))
						{
							mCreditDays = 0;
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempItemInfo() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mCreditDays = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempItemInfo).GetValue(2));
						}

					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempItemInfo = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select cost_cd from gl_cost_centers gcc where gcc.cost_no =" + txtCostCenterCode.Text));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempItemInfo))
						{
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							MessageBox.Show("Invalid Cost Center Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
							grdVoucherDetails.Col = mCostCenterColumn;
							grdVoucherDetails.Bookmark = Cnt;
							grdVoucherDetails.Focus();
							return false;
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempItemInfo of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mCostCenterCode = ReflectionHelper.GetPrimitiveValue<int>(mTempItemInfo);
						}
					}
					else
					{
						mCostCenterCode = 1;
					}

					if (mCurrenyCode != SystemGLConstants.gDefaultCurrencyCd)
					{
						mExchangeRate = 1;
					}
					else
					{
						mExchangeRate = 1;
					}

					mysql = " insert into gl_accnt_trans_details ( entry_id, ldgr_cd, curr_cd, cost_cd, exchange_rate, ";
					mysql = mysql + " fc_amount, lc_amount, due_date, dr_cr_type, dr_cr_line_no, ";
					mysql = mysql + " cheque_no, comments, Show_In_Header )";
					mysql = mysql + " values ( ";
					mysql = mysql + Conversion.Str(mNewEntryID) + ",";
					mysql = mysql + mLedgerCode.ToString() + ",";
					mysql = mysql + mCurrenyCode.ToString() + ",";
					mysql = mysql + ((mCostCenterCode == 0) ? "null" : Conversion.Str(mCostCenterCode)) + ",";
					mysql = mysql + Conversion.Str(mExchangeRate) + ",";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Single_Entry_Type"]) == "D")
					{
						mCreditColumnTotalAmount = Conversion.Val(StringsHelper.Format(txtTotalDR.Text, "###############0.000"));
					}
					else
					{
						mDebitColumnTotalAmount = Conversion.Val(StringsHelper.Format(txtTotalCR.Text, "###############0.000"));
					}

					if (mDebitColumnTotalAmount > 0)
					{
						mysql = mysql + Conversion.Str(mDebitColumnTotalAmount) + ",";
					}
					else
					{
						mysql = mysql + Conversion.Str(mCreditColumnTotalAmount * -1) + ",";
					}

					if (mDebitColumnTotalAmount > 0)
					{
						mysql = mysql + Conversion.Str(mDebitColumnTotalAmount * mExchangeRate) + ",";
					}
					else
					{
						mysql = mysql + Conversion.Str((mCreditColumnTotalAmount * -1) * mExchangeRate) + ",";
					}

					mysql = mysql + " cast('" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "' as smalldatetime) ";
					mysql = mysql + " + " + Conversion.Str(mCreditDays) + ",";

					mysql = mysql + ((mDebitColumnTotalAmount != 0) ? "'D'" : "'C'") + ",";
					mysql = mysql + Conversion.Str(1) + ",";
					//    mySql = mySql + Str(mDebitColumnTotalAmount + mCreditColumnTotalAmount) & ","

					if (txtChequeNo.Visible)
					{
						mysql = mysql + "'" + txtChequeNo.Text + "'";
					}
					else
					{
						mysql = mysql + " NULL ";
					}

					mysql = mysql + ", '', 1";
					mysql = mysql + " )";
					SqlCommand TempCommand_9 = null;
					TempCommand_9 = SystemVariables.gConn.CreateCommand();
					TempCommand_9.CommandText = mysql;
					TempCommand_9.ExecuteNonQuery();
				}


				//Post of GL
				if (pApprove)
				{

					//'''on 20th feb 2004
					SystemICSProcedure.ApproveTransaction("gl_accnt_trans", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(rsGLVoucherTypes.Tables[0].Rows[0]["pdc_generated_linked_gl_voucher_type"]))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["single_entry_type"]) == "D")
						{
							mDrCrType = "C";
						}
						else
						{
							mDrCrType = "D";
						}

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (!SystemGLProcedure.GenerateLinkedVoucherForPDC(Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["pdc_generated_linked_gl_voucher_type"]), mNewEntryID, 0, mDrCrType))
						{
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							result = false;
							txtMaturityDate.Focus();
							return result;
						}
					}
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				mLastVoucherNo = Convert.ToInt32(Double.Parse(txtVoucherNo.Text));

				//Display a messbox if the auto generate voucher no is true and it is in addmode
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Display_Voucher_No_After_Save"]))
					{
						mysql = SystemConstants.msg20 + txtVoucherNo.Text;
						if (pApprove)
						{
							mysql = mysql + SystemConstants.msg22;
						}
						MessageBox.Show(mysql, "Press any key to continue...", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}


				//If rsGLVoucherTypes("print_after_save") = True Then
				//    Dim ans As Long
				//
				//    ans = MsgBox(msg25, vbInformation + vbYesNo, "Expert Printing")
				//    If ans = vbYes Then
				PrintReport(mNewEntryID);
				//        '''This doevent was placed because after adding a new voucher and
				//        '''print preview is closed, VB hangs.
				//        DoEvents
				//    End If
				//End If
				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Add_new_record_after_save")))
				{
					GetRecord(mNewEntryID);
				}

				//FirstFocusObject.SetFocus
				return true;
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				//Resume
				//If mReturnErrorType = 1 Then
				//    mSearchValue = GetMasterCode("vaccnt_group", "group_no", txtGroupNo.Text, "group_cd")
				//    Call GetRecord("vaccnt_group", "group_cd", mSearchValue, StringType)
				//    saveRecord = False
				//ElseIf mReturnErrorType = 2 Then
				//    Call AddRecord
				//    saveRecord = False
				//ElseIf mReturnErrorType = 3 Then
				//    Call AddRecord
				//    saveRecord = False
				//Else
				//    saveRecord = False
				//End If
			}
			return result;
		}

		public bool CheckDataValidity()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			bool result = false;
			try
			{
				int Cnt = 0;

				//*-- update all the current voucher grid information in grid's internal buffer
				grdVoucherDetails.UpdateData();
				//** -----------------------------------------------------------------------------------
				//*-- check the voucher status. if its not in active mode do not allow any updates
				if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
				{
					if (mOldVoucherStatus == SystemVariables.VoucherStatus.stPosted)
					{ //if voucher is in posted mode
						MessageBox.Show("Voucher already posted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else if (mOldVoucherStatus == SystemVariables.VoucherStatus.stVoid)
					{  //if voucher is in deleted mode
						MessageBox.Show("Voucher already Void!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					if (ControlHelper.GetEnabled(FirstFocusObject))
					{
						FirstFocusObject.Focus();
					}
					return false;
				}
				//** -----------------------------------------------------------------------------------
				//*-- check whether voucher type is selected or not
				if (SystemProcedure2.IsItEmpty(cmbVoucherTypes.Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Voucher Type", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (ControlHelper.GetEnabled(FirstFocusObject))
					{
						FirstFocusObject.Focus();
					}
					return false;
				}
				//** -----------------------------------------------------------------------------------
				//*-- check if voucher date is specified
				if (SystemProcedure2.IsItEmpty(txtVoucherDate.Value, SystemVariables.DataType.DateType))
				{
					MessageBox.Show("Enter voucher date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					FirstFocusObject.Focus();
					return false;
				}
				else
				{
					if (!SystemProcedure2.ValidDateRange(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value)))
					{
						MessageBox.Show("Invalid Date Range, Check the current financial year", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						if (txtVoucherDate.Enabled)
						{
							txtVoucherDate.Focus();
						}
						return false;
					}
				}
				//** -----------------------------------------------------------------------------------

				//** -----------------------------------------------------------------------------------
				//*-- check if branch code is entered
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["show_branch_code_in_header"]))
				{
					if (SystemProcedure2.IsItEmpty(txtBranchCode.Text, SystemVariables.DataType.StringType))
					{
						MessageBox.Show("Enter Branch Code ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						if (txtBranchCode.Enabled)
						{
							txtBranchCode.Focus();
						}
						return false;
					}
				}
				//** -----------------------------------------------------------------------------------

				//** -----------------------------------------------------------------------------------
				//*-- check if maturity date is specified
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("post_dated_cheque")) && txtMaturityDate.Visible)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["is_pdc_receipt_type"])) == TriState.True || ((TriState) Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["is_pdc_payment_type"])) == TriState.True)
					{
						if (SystemProcedure2.IsItEmpty(txtMaturityDate.Value, SystemVariables.DataType.DateType))
						{
							MessageBox.Show("Enter PDC Maturity date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtMaturityDate.Focus();
							return false;
						}

						if (ReflectionHelper.IsLessThan(txtMaturityDate.Value, txtVoucherDate.Value))
						{
							MessageBox.Show("PDC Maturity date cannot be less than voucher date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtMaturityDate.Focus();
							return false;
						}
					}
				}
				//** -----------------------------------------------------------------------------------


				//*-- check if opposite ledger details are specified (in case its visible)
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["allow_single_entry"])) == TriState.True && ((TriState) Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["show_opposite_ldgr_in_header"])) == TriState.True)
				{
					if (SystemProcedure2.IsItEmpty(txtCashLedgerCode.Text, SystemVariables.DataType.StringType))
					{
						MessageBox.Show("Enter " + lblCashLedgerDetails.Caption, "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						if (txtCashLedgerCode.Enabled)
						{
							txtCashLedgerCode.Focus();
						}
						return false;
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
					{
						if (SystemProcedure2.IsItEmpty(txtCostCenterCode.Text, SystemVariables.DataType.NumberType))
						{
							MessageBox.Show("Enter " + lblCostCenterCode.Caption, "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
							if (txtCostCenterCode.Enabled)
							{
								txtCostCenterCode.Focus();
							}
							return false;
						}
					}
				}
				//** -----------------------------------------------------------------------------------
				//*-- check for records existence
				if (Conversion.Val(StringsHelper.Format(txtTotalCR.Text, "###############0.000")) == 0 && Conversion.Val(StringsHelper.Format(txtTotalDR.Text, "###############0.000")) == 0)
				{
					MessageBox.Show("Enter voucher details / amount", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					grdVoucherDetails.Focus();
					return result;
				}
				//** -----------------------------------------------------------------------------------
				//*-- check whether debit and credit amount is equal
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["allow_single_entry"])) == TriState.False)
				{
					if (Conversion.Val(StringsHelper.Format(txtTotalCR.Text, "###############0.000")) != Conversion.Val(StringsHelper.Format(txtTotalDR.Text, "###############0.000")))
					{
						MessageBox.Show("Amount balances does not tally", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						grdVoucherDetails.Focus();
						grdVoucherDetails.Rebind(true);
						return result;
					}
				}
				//** -----------------------------------------------------------------------------------
				//*--
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					//check for ledger details (e.g. ledger code, debit amount or credit amount)
					//    If IsItEmpty(aVoucherDetails(cnt, mLedgerCodeColumn), StringType) Then
					//        MsgBox "Invalid Ledger Code"
					//        grdVoucherDetails.Col = mLedgerCodeColumn
					//        grdVoucherDetails.Bookmark = cnt
					//        grdVoucherDetails.SetFocus
					//        CheckDataValidity = False
					//        Exit Function
					//    End If

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdVoucherDetails.Splits[0].DisplayColumns[mDebitAmountColumn].Visible && grdVoucherDetails.Splits[0].DisplayColumns[mCreditAmountColumn].Visible)
					{
						if ((Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mDebitAmountColumn))) == 0 && Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mCreditAmountColumn))) == 0) && !SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, mLedgerCodeColumn), SystemVariables.DataType.StringType))
						{
							MessageBox.Show("Specify Ledger Amount", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mDebitAmountColumn))) == 0 && grdVoucherDetails.Splits[0].DisplayColumns[mDebitAmountColumn].Visible)
							{
								grdVoucherDetails.Col = mLCAmountColumn;
							}
							grdVoucherDetails.Bookmark = Cnt;
							grdVoucherDetails.Focus();
							return false;
						}
					}
					else
					{
						if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mLCAmountColumn))) == 0 && !SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, mLedgerCodeColumn), SystemVariables.DataType.StringType))
						{
							MessageBox.Show("Specify Ledger Amount", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, mLCAmountColumn))) == 0 && grdVoucherDetails.Splits[0].DisplayColumns[mLCAmountColumn].Visible)
							{
								grdVoucherDetails.Col = mLCAmountColumn;
							}
							grdVoucherDetails.Bookmark = Cnt;
							grdVoucherDetails.Focus();
							return false;
						}
					}
				}

				//--check whether a messege should appear if the cash balance goes negative
				//If rsCompanyProperties("enable_negative_cash_check").Value = vbTrue Then
				//
				//End If

				result = true;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		public void AddRecord()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;

				int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					grdVoucherDetails.Columns[Cnt].FooterText = "";
				}

				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
				oThisFormToolBar.ChangeEnabledSetting(SystemConstants.gToolButtonSourceTran, false);

				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
				//''''*************************************************************************
				//Set the form caption
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? rsGLVoucherTypes.Tables[0].Rows[0]["a_voucher_name"] : rsGLVoucherTypes.Tables[0].Rows[0]["l_voucher_name"]));
				//''''*************************************************************************

				//Call ClearTextBox(Me)
				//txtBranchName.Text = ""
				//txtBranchCode.Text = ""
				//txtFlex01.Text = ""
				txtComments.Text = "";
				//txtCostCenterName.Text = ""
				//txtCostCenterCode.Text = ""
				//txtCashLedgerName.Text = ""
				//txtCashLedgerCode.Text = ""
				txtReferenceNo.Text = "";
				txtVoucherNo.Text = "";
				txtChequeNo.Text = "";
				txtTotalDR.Text = "";
				txtTotalCR.Text = "";

				ClearStatusBar();
				cmbVoucherTypes_Click(cmbVoucherTypes, null);

				//txtVoucherDate.Value = gCurrentDate
				txtVoucherDate.Enabled = true;

				mSearchValue = ""; //Change the msearchvalue to blank
				mFirstGridFocus = true;

				//'Added By Moiz Hakimi Ghee
				//'Date: 26-Jan-2008
				//If GetSystemPreferenceSetting("enable_gl_voucher_type_combo") = True Then
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				cmbVoucherTypes.Enabled = Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Enable_Combo_List"]);
				//Else
				//cmbVoucherTypes.Enabled = False
				//End If
				FirstFocusObject = txtVoucherDate;
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}

				return;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public bool deleteRecord()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			bool result = false;
			try
			{
				string mysql = "";
				//Delete the Record
				try
				{


					if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
					{
						if (mOldVoucherStatus == SystemVariables.VoucherStatus.stPosted)
						{ //if voucher is in posted mode
							MessageBox.Show(SystemConstants.msg26 + SystemConstants.msg17, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
							result = false;
						}
						else if (mOldVoucherStatus == SystemVariables.VoucherStatus.stVoid)
						{  //if voucher is in deleted mode
							MessageBox.Show(SystemConstants.msg27 + SystemConstants.msg17, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
							result = false;
						}
						else if (mOldVoucherStatus == SystemVariables.VoucherStatus.stAutoGenerated)
						{  //if voucher is in deleted mode
							MessageBox.Show(SystemConstants.msg28 + SystemConstants.msg17, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
							result = false;
						}
						FirstFocusObject.Focus();
						return result;
					}


					SystemVariables.gConn.BeginTransaction();

					mysql = " delete from gl_invoice_tracking ";
					mysql = mysql + " from gl_invoice_tracking IT ";
					mysql = mysql + " inner join gl_accnt_trans_details ATD on IT.source_line_no = ATD.line_no ";
					mysql = mysql + " inner join gl_accnt_trans AT on ATD.entry_id = AT.entry_id";
					mysql = mysql + " where AT.entry_id = " + Conversion.Str(mSearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mysql = " delete from gl_invoice_tracking ";
					mysql = mysql + " from gl_invoice_tracking IT ";
					mysql = mysql + " inner join gl_accnt_trans_details ATD on IT.against_line_no = ATD.line_no ";
					mysql = mysql + " inner join gl_accnt_trans AT on ATD.entry_id = AT.entry_id";
					mysql = mysql + " where AT.entry_id = " + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

					mysql = "delete from gl_accnt_trans_details ";
					mysql = mysql + " where entry_id = " + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					mysql = "delete from gl_accnt_trans ";
					mysql = mysql + " where entry_id = " + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();


					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();


					return true;
				}
				catch (System.Exception excep)
				{
					int mReturnErrorType = 0;
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Delete Record", SystemConstants.msg10);

					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		public void GetRecord(object pSearchValue, bool pImport = false)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting
			string mysql = "";
			SqlDataReader rsLocalRec = null;
			object mImportedSearchValue = null;


			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (SystemProcedure2.IsItEmpty(pSearchValue, SystemVariables.DataType.NumberType) || Convert.IsDBNull(pSearchValue))
				{
					return;
				}
				try
				{

					//If GetSystemPreferenceSetting("voucher_adjustment") = True Then
					//    Call InsertAdjustedVouchersInArray(Val(mSearchValue))
					//End If

					mysql = " select mt.* ";
					mysql = mysql + " , glb.branch_cd";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_branch_name" : "a_branch_name") + " as branch_name ";
					mysql = mysql + " from gl_accnt_trans mt ";
					mysql = mysql + " left outer join gl_branch glb on mt.branch_cd = glb.branch_cd ";
					mysql = mysql + " where mt.entry_id = " + Conversion.Str(pSearchValue);

					SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
					rsLocalRec = sqlCommand.ExecuteReader();
					if (rsLocalRec.Read())
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(rsLocalRec["show"])) == TriState.True)
						{
							//added by Moiz Hakimi. Date: 10-may-2008
							if (!pImport)
							{

								mSearchValue = rsLocalRec["entry_id"];

								SystemCombo.SearchCombo(cmbVoucherTypes, Convert.ToInt32(rsLocalRec["voucher_type"]));


								//''while drill down from report if the user does not have access, error was not handled.
								if (cmbVoucherTypes.ListIndex == -1)
								{
									MessageBox.Show("Error: Access Denied!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}

								if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("voucher_adjustment")))
								{
									InsertAdjustedVouchersInArray(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(mSearchValue))));
								}

								mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;

								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								if (((TriState) Convert.ToInt32(rsLocalRec["linked"])) == TriState.True)
								{
									oThisFormToolBar.ChangeEnabledSetting(SystemConstants.gToolButtonSourceTran, true);
								}
								else
								{
									oThisFormToolBar.ChangeEnabledSetting(SystemConstants.gToolButtonSourceTran, false);
								}


								mImportedSearchValue = rsLocalRec["entry_id"];
								//mRecordNavigateSearchValue = .Fields("entry_id")
								mTimeStamp = Convert.ToString(rsLocalRec["time_stamp"]);
								txtVoucherNo.Text = Convert.ToString(rsLocalRec["voucher_no"]);
								txtVoucherDate.Value = rsLocalRec["voucher_date"];
								txtVoucherDate.Enabled = Convert.ToDateTime(rsLocalRec["voucher_date"]) >= DateTime.Parse(SystemVariables.gCurrentPeriodStarts) && Convert.ToDateTime(rsLocalRec["voucher_date"]) <= DateTime.Parse(SystemVariables.gNextPeriodEnds);
								txtReferenceNo.Text = Convert.ToString(rsLocalRec["reference_no"]) + "";
								txtComments.Text = Convert.ToString(rsLocalRec["comments"]) + "";
								txtFlex01.Text = Convert.ToString(rsLocalRec["flex_01"]) + "";

								if (txtMaturityDate.Visible && !Convert.IsDBNull(rsLocalRec["pdc_due_date"]))
								{
									txtMaturityDate.Value = rsLocalRec["pdc_due_date"];
								}
								else
								{
									txtMaturityDate.ClearControl();
								}

								if (txtChequeNo.Visible)
								{
									txtChequeNo.Text = Convert.ToString(rsLocalRec["cheque_no"]) + "";
								}

								if (Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["show_branch_code_in_header"]))
								{
									txtBranchCode.Text = Convert.ToString(rsLocalRec["branch_cd"]) + "";
									txtBranchName.Text = Convert.ToString(rsLocalRec["branch_name"]) + "";
								}
								else
								{
									txtBranchCode.Text = "";
									txtBranchName.Text = "";
								}
								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								mOldVoucherStatus = (SystemVariables.VoucherStatus) Convert.ToInt32(rsLocalRec["status"]);

								//**--set the form caption and get the voucher status
								SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, Convert.ToInt32(rsLocalRec["status"]), CurrentFormMode, Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? rsGLVoucherTypes.Tables[0].Rows[0]["a_voucher_name"] : rsGLVoucherTypes.Tables[0].Rows[0]["l_voucher_name"]));
							}
							else
							{
								mImportedSearchValue = rsLocalRec["entry_id"];

								//'''clear the voucher adjustment link during import
								if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("voucher_adjustment")))
								{
									//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aAdjustedVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
									aAdjustedVoucherDetails.Clear();
									aAdjustedVoucherDetails.RedimXArray(new int[]{-1, conMaxVoucherLinkingCols}, new int[]{0, 0});
								}

							}
						}
						else
						{
							MessageBox.Show("Unable to display the Record!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
					}
					rsLocalRec.Close();

					mysql = " select atd.*, l.ldgr_no, atd.curr_cd, ";
					mysql = mysql + " l.l_ldgr_name, l.a_ldgr_name, l.current_bal, ";
					mysql = mysql + " gl_accnt_group.l_group_name, gl_accnt_group.a_group_name, projects.project_no ";
					mysql = mysql + " , anly1.anly_code as anly_code_1 ";
					mysql = mysql + " , anly2.anly_code as anly_code_2 ";
					mysql = mysql + " , gl_currency.symbol as curr_symbol, gcc.cost_no, SM_Salesman.sman_no ";
					mysql = mysql + " , gcc.l_cost_name, gcc.a_cost_name, cons.consignment_no ";

					if (Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Show_FC_Balance_In_Taskbar"]))
					{
						mysql = mysql + " , (select sum(FC_Amount) from GL_Accnt_Trans_Details dt1 where dt1.ldgr_cd = l.ldgr_cd) as FC_Balance";
					}

					mysql = mysql + " from gl_accnt_trans_details atd ";
					mysql = mysql + " inner join gl_ledger l on atd.ldgr_cd = l.ldgr_cd ";
					mysql = mysql + " inner join gl_accnt_group on l.group_cd = gl_accnt_group.group_cd ";
					mysql = mysql + " inner join gl_currency on atd.curr_cd = gl_currency.curr_cd ";
					mysql = mysql + " left outer join gl_cost_centers gcc on atd.cost_cd = gcc.cost_cd ";
					mysql = mysql + " left outer join SM_Salesman on atd.sman_cd = SM_Salesman.sman_cd ";
					mysql = mysql + " left outer join gl_consignment cons on atd.consignment_cd = cons.consignment_cd ";
					mysql = mysql + " left outer join gl_analysis anly1 on atd.anly_code_1 = anly1.anly_code ";
					mysql = mysql + " and atd.anly_head_no_1 = anly1.anly_head_no ";
					mysql = mysql + " left outer join gl_analysis anly2 on atd.anly_code_2 = anly2.anly_code ";
					mysql = mysql + " and atd.anly_head_no_2 = anly2.anly_head_no ";
					mysql = mysql + " left outer join PROJ_Projects projects on atd.project_cd = projects.project_cd ";
					mysql = mysql + " where atd.entry_id = " + Conversion.Str(mImportedSearchValue);
					mysql = mysql + " order by atd.line_no ";
					SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
					rsLocalRec = sqlCommand_2.ExecuteReader();
					bool rsLocalRecDidRead2 = rsLocalRec.Read();

					DefineVoucherArray(0, true);

					int Cnt = 0;
					Cnt = 0;
					txtCashLedgerCode.Text = "";
					do 
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["allow_single_entry"])) == TriState.True && rsGLVoucherTypes.Tables[0].Rows[0]["single_entry_type"] != rsLocalRec["dr_cr_type"])
						{
							if (txtCashLedgerCode.Text == "")
							{
								txtCashLedgerCode.Text = Convert.ToString(rsLocalRec["ldgr_no"]).Trim();
								if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
								{
									txtCashLedgerName.Text = Convert.ToString(rsLocalRec["l_ldgr_name"]).Trim();
								}
								else
								{
									txtCashLedgerName.Text = Convert.ToString(rsLocalRec["a_ldgr_name"]).Trim();
								}

								if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
								{
									txtCostCenterCode.Text = Convert.ToString(rsLocalRec["cost_no"]).Trim() + "";
									if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
									{
										txtCostCenterName.Text = Convert.ToString(rsLocalRec["l_cost_name"]).Trim() + "";
									}
									else
									{
										txtCostCenterName.Text = Convert.ToString(rsLocalRec["a_cost_name"]).Trim() + "";
									}
								}
							}
							else
							{
								MessageBox.Show("More then one account is " + ((Convert.ToString(rsLocalRec["dr_cr_type"]) == "D") ? "Debited" : "Credited") + ". Invalid Entry!" + "\r" + "Contact System Administrator", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								return;
							}
						}
						else
						{
							DefineVoucherArray(Cnt, false);

							if (!pImport)
							{
								if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("voucher_adjustment")))
								{
									AssignVoucherAdjustmentLineNumbers(Convert.ToString(rsLocalRec["dr_cr_type"]), Convert.ToInt32(Conversion.Val(Convert.ToString(rsLocalRec["line_no"]))), Cnt + 1);
								}
							}

							aVoucherDetails.SetValue(Conversion.Str(Cnt + 1).Trim(), Cnt, mLineNoColumn);
							//aVoucherDetails(cnt, mDrCrTypeColumn) = IIf(.Fields("dr_cr_type") = "D", mDrTypeCaption, mCrTypeCaption)

							aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["ldgr_no"]).Trim(), Cnt, mLedgerCodeColumn);
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["l_ldgr_name"]).Trim(), Cnt, mLedgerNameColumn);
								aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["l_group_name"]).Trim(), Cnt, mGroupNameColumn);
							}
							else
							{
								aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["a_ldgr_name"]).Trim(), Cnt, mLedgerNameColumn);
								aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["a_group_name"]).Trim(), Cnt, mGroupNameColumn);
							}
							aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["curr_symbol"]).Trim(), Cnt, mCurrencySymbolColumn);
							//aVoucherDetails(cnt, mDebitAmountColumn) = .Fields("fc_dr_amt").Value * .Fields("exchange_rate").Value
							//aVoucherDetails(cnt, mCreditAmountColumn) = .Fields("fc_cr_amt").Value * .Fields("exchange_rate").Value

							//            If .Fields("fc_amount").Value > 0 Then
							//                aVoucherDetails(Cnt, mDebitAmountColumn) = .Fields("fc_amount").Value * .Fields("exchange_rate").Value
							//            Else
							//                aVoucherDetails(Cnt, mCreditAmountColumn) = Abs(.Fields("fc_amount").Value) * .Fields("exchange_rate").Value
							//            End If

							if (Convert.ToDouble(rsLocalRec["lc_amount"]) > 0)
							{
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								if (grdVoucherDetails.Splits[0].DisplayColumns[mDebitAmountColumn].Visible)
								{
									aVoucherDetails.SetValue(rsLocalRec["lc_amount"], Cnt, mDebitAmountColumn);
								}
								else
								{
									aVoucherDetails.SetValue(rsLocalRec["lc_amount"], Cnt, mLCAmountColumn);
									aVoucherDetails.SetValue("Dr", Cnt, mDrCrTypeColumn);
								}
							}
							else
							{
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								if (grdVoucherDetails.Splits[0].DisplayColumns[mCreditAmountColumn].Visible)
								{
									aVoucherDetails.SetValue(Math.Abs(Convert.ToDouble(rsLocalRec["lc_amount"])), Cnt, mCreditAmountColumn);
								}
								else
								{
									aVoucherDetails.SetValue(Math.Abs(Convert.ToDouble(rsLocalRec["lc_amount"])), Cnt, mLCAmountColumn);
									aVoucherDetails.SetValue("Cr", Cnt, mDrCrTypeColumn);
								}
							}

							aVoucherDetails.SetValue(rsLocalRec["cost_no"], Cnt, mCostCenterColumn);
							aVoucherDetails.SetValue(rsLocalRec["sman_no"], Cnt, mSalesmanColumn);
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							if (grdVoucherDetails.Splits[0].DisplayColumns[mFlex1Column].Visible)
							{
								aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["flex1"]).Trim() + "", Cnt, mFlex1Column);
							}
							aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["consignment_no"]) + "", Cnt, mConsignmentColumn);

							aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["anly_code_1"]) + "", Cnt, mAnlyCode1Column);
							aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["anly_code_2"]) + "", Cnt, mAnlyCode2Column);

							aVoucherDetails.SetValue(rsLocalRec["project_no"], Cnt, mProjectColumn);
							aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["comments"]).Trim() + "", Cnt, mRemarksColumn);

							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							if (grdVoucherDetails.Splits[0].DisplayColumns[mChequeNoColumn].Visible)
							{
								aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["cheque_no"]).Trim() + "", Cnt, mChequeNoColumn);
							}

							aVoucherDetails.SetValue(rsLocalRec["curr_cd"], Cnt, mCurrencyCodeColumn);
							aVoucherDetails.SetValue(rsLocalRec["current_bal"], Cnt, mLedgerBalanceColumn);
							//aVoucherDetails(Cnt, mLedgerBalanceColumn) = .Fields("FC_Balance").Value
							if (Convert.ToDouble(rsLocalRec["curr_cd"]) != SystemGLConstants.gDefaultCurrencyCd)
							{
								aVoucherDetails.SetValue(rsLocalRec["exchange_rate"], Cnt, mExchangeRateColumn);
							}
							else
							{
								aVoucherDetails.SetValue("", Cnt, mExchangeRateColumn);
							}

							//            If .Fields("dr_cr_type").Value = "D" Then
							//                aVoucherDetails(cnt, mLineFCAmountColumn) = .Fields("fc_dr_amt").Value
							//            Else
							//                aVoucherDetails(cnt, mLineFCAmountColumn) = .Fields("fc_cr_amt").Value
							//            End If

							if (Convert.ToDouble(rsLocalRec["curr_cd"]) != SystemGLConstants.gDefaultCurrencyCd)
							{
								if (Convert.ToDouble(rsLocalRec["fc_amount"]) > 0)
								{
									aVoucherDetails.SetValue(rsLocalRec["fc_amount"], Cnt, mFCAmountColumn);
								}
								else
								{
									aVoucherDetails.SetValue(Math.Abs(Convert.ToDouble(rsLocalRec["fc_amount"])), Cnt, mFCAmountColumn);
								}
							}
							else
							{
								aVoucherDetails.SetValue("", Cnt, mFCAmountColumn);
							}

							Cnt++;
						}
					}
					while(rsLocalRec.Read());
					rsLocalRec.Close();

					if (Cnt > 0)
					{
						CalculateTotals(1, 1);
					}
					else
					{
						CalculateTotals(0, 0);
					}

					grdVoucherDetails.Rebind(true);
					FirstFocusObject = txtVoucherDate;

					//'it is must as addrecord steps are not handled in cmbVoucherTypes click event
					cmbVoucherTypes.Enabled = false;

					if (mFirstGridFocus)
					{
						grdVoucherDetails_GotFocus(grdVoucherDetails, new EventArgs());
					}
					Application.DoEvents();

					//''this was added because during modification when the focus is on ledger code
					//''the filter was done on ledger name.
					cmbMastersList_DataSourceChanged(cmbMastersList, new EventArgs());
					return;
				}
				catch (System.Exception excep)
				{

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void PrintReport(int pEntryId = 0)
		{
			DialogResult ans = (DialogResult) 0;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int mEntryId = 0;
				frmSysReportPrint frmSysReportPrint = frmSysReportPrint.CreateInstance();
				int mCrystalReportNumToCharColumnID = 0;
				object mReturnValue = null;
				int mCountReport = 0;
				SqlDataReader rsTempRec = null;
				XArrayHelper aReports = new XArrayHelper();
				int i = 0;


				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
				}
				else
				{
					mEntryId = pEntryId;
				}

				if (mEntryId == 0)
				{
					return;
				}

				string mysql = " select sum(lc_amount) from gl_accnt_trans_details ";
				mysql = mysql + " where lc_amount> 0 ";
				mysql = mysql + " and entry_id = " + Conversion.Str(mEntryId);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				decimal mVoucherAmount = ReflectionHelper.GetPrimitiveValue<decimal>(SystemProcedure2.GetMasterCode(mysql));


				string mDefaultPrint = "";
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["use_crystal_reports_for_print"])) == TriState.True)
				{
					//---------------------------------------------------------------------------------------------------------
					//---------------------For Multiple crystal report print-----------------------------------------------
					//---------------------------------------------------------------------------------------------------------

					mysql = " select count(Report_Id) as pAutoPrint from gl_print_task_detail where (voucher_type = " + Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Voucher_Type"]) + ")";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCountReport = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));
					if (mCountReport > 0)
					{
						if (pEntryId != 0)
						{

							//Dim wshObj As New WshNetwork

							mysql = " select Prompt_For_Print_After_Save, report_id, Printer_Path, Auto_Print_After_Save, Show_Preview, Show_Printer ";
							mysql = mysql + " from  GL_Print_Task_Detail ";
							mysql = mysql + " WHERE (Voucher_Type = " + Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Voucher_Type"]);
							if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
							{
								mysql = mysql + " and enable_print_on_edit = 1)";
							}
							else
							{
								mysql = mysql + " and Auto_Print_After_Save = 1)";
							}


							SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
							rsTempRec = sqlCommand.ExecuteReader();
							rsTempRec.Read();

							if (rsTempRec.HasRows)
							{
								mysql = " select  count(Show_Option) as CountReport ";
								mysql = mysql + " from  GL_Print_Task_Detail ";
								mysql = mysql + " WHERE Voucher_Type = " + Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Voucher_Type"]);
								mysql = mysql + " and Show_Option = 1";

								if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
								{
									mysql = mysql + " and enable_print_on_edit = 1";
								}
								else
								{
									mysql = mysql + " and Auto_Print_After_Save = 1";
								}

								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
								//-------------------------------------------Check show option is false -----------------------------------
								//---------------------------------------------------------------------------------------------------------
								if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == 0)
								{

									do 
									{
										if (Convert.ToBoolean(rsTempRec["Prompt_For_Print_After_Save"]))
										{
											ans = MessageBox.Show(SystemConstants.msg25, "Xtreme Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
										}
										else
										{
											ans = System.Windows.Forms.DialogResult.Yes;
										}

										if (ans == System.Windows.Forms.DialogResult.Yes)
										{
											if (Convert.ToBoolean(rsTempRec["Show_Preview"]))
											{
												PrintGLCrystalReport(mEntryId, Convert.ToInt32(rsTempRec["Report_Id"]), mVoucherAmount, false, "", Convert.ToBoolean(rsTempRec["Show_Printer"]));
											}
											else
											{
												if (!Convert.IsDBNull(rsTempRec["Printer_Path"]))
												{
													PrintGLCrystalReport(mEntryId, Convert.ToInt32(rsTempRec["Report_Id"]), mVoucherAmount, true, Convert.ToString(rsTempRec["Printer_Path"]), Convert.ToBoolean(rsTempRec["Show_Printer"]));
												}
												else
												{
													PrintGLCrystalReport(mEntryId, Convert.ToInt32(rsTempRec["Report_Id"]), mVoucherAmount, true, "", Convert.ToBoolean(rsTempRec["Show_Printer"]));
												}
											}
										}
									}
									while(rsTempRec.Read());
								}
								else
								{
									mysql = " select  count(report_id) as CountReport ";
									mysql = mysql + " from  GL_Print_Task_Detail ";
									mysql = mysql + " WHERE Voucher_Type = " + Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Voucher_Type"]);

									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
									if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) > 1)
									{

										frmRptFormat = frmICSPrintReportFormat.DefInstance;
										frmRptFormat.mFormId = this.Name;
										frmRptFormat.mVoucherType = Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["Voucher_Type"]);
										frmRptFormat.mEntryId = mEntryId;
										frmRptFormat.ShowDialog();
										aReports = frmRptFormat.aVoucherDetails;
										frmRptFormat.Close();

										i = 0;
										int tempForEndVar = aReports.GetLength(0) - 1;
										for (i = 0; i <= tempForEndVar; i++)
										{

											//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
											if (((TriState) Convert.ToInt32(aReports.GetValue(i, 2))) == TriState.True)
											{
												if (Convert.ToBoolean(aReports.GetValue(i, 4)))
												{
													PrintGLCrystalReport(mEntryId, Convert.ToInt32(aReports.GetValue(i, 0)), mVoucherAmount, false, "", Convert.ToBoolean(aReports.GetValue(i, 5)));
												}
												else
												{
													//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
													if (!Convert.IsDBNull(aReports.GetValue(i, 3)) || Convert.ToString(aReports.GetValue(i, 3)) != "")
													{
														PrintGLCrystalReport(mEntryId, Convert.ToInt32(aReports.GetValue(i, 0)), mVoucherAmount, true, Convert.ToString(aReports.GetValue(i, 3)));
													}
													else
													{
														PrintGLCrystalReport(mEntryId, Convert.ToInt32(aReports.GetValue(i, 0)), mVoucherAmount, true);
													}
												}
											}
										}
									}
									else
									{
										do 
										{
											if (Convert.ToBoolean(rsTempRec["Auto_Print_After_Save"]))
											{
												if (Convert.ToBoolean(rsTempRec["Prompt_For_Print_After_Save"]))
												{
													ans = MessageBox.Show(SystemConstants.msg25, "Xtreme Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
												}
												else
												{
													ans = System.Windows.Forms.DialogResult.Yes;
												}

												if (ans == System.Windows.Forms.DialogResult.Yes)
												{

													if (Convert.ToBoolean(rsTempRec["Show_Preview"]))
													{
														PrintGLCrystalReport(mEntryId, Convert.ToInt32(rsTempRec["Report_Id"]), mVoucherAmount, false, "", Convert.ToBoolean(rsTempRec["Show_Printer"]));
													}
													else
													{
														if (!Convert.IsDBNull(rsTempRec["Printer_Path"]))
														{
															PrintGLCrystalReport(mEntryId, Convert.ToInt32(rsTempRec["Report_Id"]), mVoucherAmount, true, Convert.ToString(rsTempRec["Printer_Path"]), Convert.ToBoolean(rsTempRec["Show_Printer"]));
														}
														else
														{
															PrintGLCrystalReport(mEntryId, Convert.ToInt32(rsTempRec["Report_Id"]), mVoucherAmount, true, "", Convert.ToBoolean(rsTempRec["Show_Printer"]));
														}
													}
												}
											}
										}
										while(rsTempRec.Read());
									}
								}
							}
						}
						else
						{
							if (mCountReport > 1)
							{
								frmRptFormat = frmICSPrintReportFormat.DefInstance;
								frmRptFormat.mFormId = this.Name;
								frmRptFormat.mVoucherType = Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["Voucher_Type"]);
								frmRptFormat.mEntryId = mEntryId;
								frmRptFormat.ShowDialog();
								aReports = frmRptFormat.aVoucherDetails;
								frmRptFormat.Close();

								i = 0;
								int tempForEndVar2 = aReports.GetLength(0) - 1;
								for (i = 0; i <= tempForEndVar2; i++)
								{

									//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
									if (((TriState) Convert.ToInt32(aReports.GetValue(i, 2))) == TriState.True)
									{
										PrintGLCrystalReport(mEntryId, Convert.ToInt32(aReports.GetValue(i, 0)), mVoucherAmount);
									}
								}

							}
							else
							{
								mysql = "SELECT Report_Id From GL_Print_Task_Detail WHERE (Voucher_Type = " + Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Voucher_Type"]) + ")";
								PrintGLCrystalReport(mEntryId, ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql)), mVoucherAmount);
							}
						}

					}
				}
				else
				{
					mysql = " declare @NumToChar as varchar(1000) ";
					mysql = mysql + " set @NumToChar='" + SystemProcedure2.num_to_char(Conversion.Str(mVoucherAmount)) + "' ";
					mysql = mysql + " SELECT  mt.entry_id, mt.Voucher_Type, mt.Voucher_Date ";
					mysql = mysql + " , mt.Voucher_No ";
					mysql = mysql + " , mt.Reference_No, avt.L_Voucher_Name  ";
					mysql = mysql + " , l.Ldgr_No , l.L_Ldgr_Name, dt.Line_No ";
					//mySql = mySql & " , dt.LC_Dr_Amt, dt.LC_Cr_Amt "
					mysql = mysql + " , case when dt.lc_amount > 0 then dt.lc_amount else 0 end as lc_dr_amt ";
					mysql = mysql + " , case when dt.lc_amount < 0 then dt.lc_amount else 0 end as lc_cr_amt ";
					mysql = mysql + " , (case when  dt.Dr_Cr_Type='D' THEN 'Dr' else 'Cr' end) as cr_dr_type ";
					mysql = mysql + " , cc.cost_no, cc.l_cost_name, cc.a_cost_name ";
					mysql = mysql + " , @numtochar as numtochar ";
					mysql = mysql + " , dt.comments dtComments ";
					mysql = mysql + " , mt.comments mtComments ";
					mysql = mysql + " , abs(dt.lc_amount) ";
					mysql = mysql + " From gl_accnt_trans mt ";
					mysql = mysql + " INNER JOIN  gl_accnt_trans_Details dt ON mt.Entry_Id = dt.Entry_Id ";
					mysql = mysql + " INNER JOIN  gl_ledger l ON dt.Ldgr_Cd = l.Ldgr_Cd ";
					mysql = mysql + " INNER JOIN  gl_accnt_voucher_types avt ON mt.Voucher_Type = avt.Voucher_Type ";
					mysql = mysql + " left outer join gl_cost_centers cc on dt.cost_cd = cc.cost_cd ";
					mysql = mysql + " where mt.entry_id =  " + Conversion.Str(mEntryId);

					frmSysReportPrint.ReportModuleType = 1; // gl module type
					frmSysReportPrint.ReportType = Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Voucher_type"]);
					frmSysReportPrint.RecordSource = mysql;
					//frmSysReportPrint.Show 1

					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//VB.Global.Load(frmSysReportPrint);
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["show_print_preview_first"])) == TriState.True)
					{
						//UPGRADE_WARNING: (7009) Multiple invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions More Information: https://docs.mobilize.net/vbuc/ewis#7009
						frmSysReportPrint.ShowDialog();
					}
					else
					{
						frmSysReportPrint.vsrReportPreviewer.PrintDoc(true, null, null);
					}

					frmSysReportPrint.Close();
					frmSysReportPrint = null;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		public void CloseForm()
		{
			try
			{
				this.Close();
			}
			catch
			{
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (MsgId == 1)
				{
					grdVoucherDetails.Col = mLedgerCodeColumn;
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					cmbMastersList.setDataSource((msdatasrc.DataSource) rsLedgerCodeList);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;
				object mCurrentbal = null;
				string mSQL = "";
				object mReturnValue = null;

				if (aVoucherDetails.GetLength(0) > 0)
				{
					mSQL = " select curr_cd from gl_currency where symbol = '" + grdVoucherDetails.Columns[mCurrencySymbolColumn].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == SystemGLConstants.gDefaultCurrencyCd)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[mExchangeRateColumn].Visible)
						{
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							grdVoucherDetails.Splits[0].DisplayColumns[mExchangeRateColumn].AllowFocus = false;
						}
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[mFCAmountColumn].Visible)
						{
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							grdVoucherDetails.Splits[0].DisplayColumns[mFCAmountColumn].AllowFocus = false;
						}
					}
					else
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[mExchangeRateColumn].Visible)
						{
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							grdVoucherDetails.Splits[0].DisplayColumns[mExchangeRateColumn].AllowFocus = true;
						}
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[mFCAmountColumn].Visible)
						{
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							grdVoucherDetails.Splits[0].DisplayColumns[mFCAmountColumn].AllowFocus = true;
						}
					}

				}
				if (grdVoucherDetails.Row != ReflectionHelper.GetPrimitiveValue<double>(LastRow))
				{
					if (grdVoucherDetails.AddNewMode == C1.Win.C1TrueDBGrid.AddNewModeEnum.NoAddNew)
					{
						ShowLedgerDetails(false);
						//        If ApplyCostCenterToLedger(Val(grdVoucherDetails.Columns(mLedgerCodeColumn).Value)) = True Then
						//            grdVoucherDetails.Columns(mCostCenterColumn).AllowFocus = True
						//        Else
						//            grdVoucherDetails.Columns(mCostCenterColumn).AllowFocus = False
						//        End If
					}
					else if (grdVoucherDetails.AddNewMode == C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent)
					{ 
						ShowLedgerDetails(true);
						//        grdVoucherDetails.Columns(mCostCenterColumn).AllowFocus = False
					}
					else
					{
						//if grdVoucherDetails.AddNewMode = dbgAddNewPending
						ShowLedgerDetails(false);
						//        If ApplyCostCenterToLedger(Val(grdVoucherDetails.Columns(mLedgerCodeColumn).Value)) = True Then
						//            grdVoucherDetails.Columns(mCostCenterColumn).AllowFocus = True
						//        Else
						//            grdVoucherDetails.Columns(mCostCenterColumn).AllowFocus = False
						//        End If
					}
				}
				else
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!mFirstGridFocus && aVoucherDetails.GetLength(0) > 0 && Convert.IsDBNull(LastRow))
					{
						ShowLedgerDetails(false);
						//        If ApplyCostCenterToLedger(Val(grdVoucherDetails.Columns(mLedgerCodeColumn).Value)) = True Then
						//            grdVoucherDetails.Columns(mCostCenterColumn).AllowFocus = True
						//        Else
						//            grdVoucherDetails.Columns(mCostCenterColumn).AllowFocus = False
						//        End If
					}
				}

				if (grdVoucherDetails.Col > 0 && LastCol > 0 && !mFirstGridFocus)
				{
					switch(grdVoucherDetails.Col)
					{
						case mCurrencySymbolColumn : 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersList.setDataSource((msdatasrc.DataSource) rsCurrencySymbols); 
							break;
						case mLedgerCodeColumn : case mLedgerNameColumn : 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersList.setDataSource((msdatasrc.DataSource) rsLedgerCodeList); 
							break;
						case mCostCenterColumn : 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersList.setDataSource((msdatasrc.DataSource) rsCostCenterList); 
							break;
						case mSalesmanColumn : 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersList.setDataSource((msdatasrc.DataSource) rsSalesmanList); 
							break;
						case mAnlyCode1Column : case mAnlyCode2Column : 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersList.setDataSource((msdatasrc.DataSource) rsAnlyCode); 
							break;
						case mProjectColumn : 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersList.setDataSource((msdatasrc.DataSource) rsProjectList); 
							break;
						case mDrCrTypeColumn : 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersList.setDataSource((msdatasrc.DataSource) rsDRCRType); 
							break;
						case mConsignmentColumn : 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersList.setDataSource((msdatasrc.DataSource) rsConsignmentsList); 
							break;
						case mRemarksColumn : 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersList.setDataSource((msdatasrc.DataSource) rsRemarksList); 
							break;
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void IRoutine()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int mCurrentLineNo = 0;

				if (ActiveControl.Name != "grdVoucherDetails")
				{
					grdVoucherDetails.Focus();
				}
				int Cnt = 0;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(grdVoucherDetails.Bookmark))
				{
					//UPGRADE_WARNING: (1068) grdVoucherDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[mLineNoColumn].Value);
					//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), 1);
					AssignGridLineNumbers();
					grdVoucherDetails.Rebind(true);
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("voucher_adjustment")))
					{

						int tempForEndVar = aAdjustedVoucherDetails.GetLength(0) - 1;
						for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
						{
							if (Conversion.Val(Convert.ToString(aAdjustedVoucherDetails.GetValue(Cnt, conVLLineNoColumn))) >= mCurrentLineNo)
							{
								aAdjustedVoucherDetails.SetValue(Convert.ToDouble(aAdjustedVoucherDetails.GetValue(Cnt, conVLLineNoColumn)) + 1, Cnt, conVLLineNoColumn);
							}
						}
					}
					//-------------------------------------------------------------------------------
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Single_Entry_Type"]) == "D")
					{
						grdVoucherDetails.Columns[mDrCrTypeColumn].Text = "Dr";
					}
					else if (Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Single_Entry_Type"]) == "C")
					{ 
						grdVoucherDetails.Columns[mDrCrTypeColumn].Text = "Cr";
					}
					else
					{
						grdVoucherDetails.Columns[mDrCrTypeColumn].Text = "Dr";
					}
					//-------------------------------------------------------------------------------
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void LRoutine()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (ActiveControl.Name != "grdVoucherDetails")
				{
					grdVoucherDetails.Focus();
				}

				int Cnt = 0;
				if (aVoucherDetails.GetLength(0) > 0)
				{
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("voucher_adjustment")))
					{
						bool tempRefParam = true;
						if (!DeleteCurrentLineAdjustment(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[mLineNoColumn].Value))), ref tempRefParam))
						{
							return;
						}

						int tempForEndVar = aAdjustedVoucherDetails.GetLength(0) - 1;
						for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
						{
							if (Conversion.Val(Convert.ToString(aAdjustedVoucherDetails.GetValue(Cnt, conVLLineNoColumn))) > Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[mLineNoColumn].Value)))
							{
								aAdjustedVoucherDetails.SetValue(Convert.ToDouble(aAdjustedVoucherDetails.GetValue(Cnt, conVLLineNoColumn)) - 1, Cnt, conVLLineNoColumn);
							}
						}

					}
					grdVoucherDetails.Delete();
					AssignGridLineNumbers();
					CalculateTotals(0, 1);
					grdVoucherDetails.Rebind(true);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void FillVoucherTypes()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "";

				if (SystemVariables.gLoggedInUserCode == SystemConstants.gDefaultAdminUserCode)
				{
					mysql = "select * from gl_accnt_voucher_types ";
					mysql = mysql + " where show = 1 ";
					mysql = mysql + " order by voucher_type ";
				}
				else
				{
					mysql = "select avt.* from gl_accnt_voucher_types avt ";
					mysql = mysql + " inner join SM_USER_GROUP_RIGHTS sugr ";
					mysql = mysql + " on avt.voucher_type = sugr.accnt_voucher_type ";
					mysql = mysql + " inner join SM_USER_GROUPS sug ";
					mysql = mysql + " on sugr.group_cd = sug.group_cd ";
					mysql = mysql + " inner join SM_USERS su ";
					mysql = mysql + " on sug.group_cd = su.group_cd ";
					mysql = mysql + " where su.user_cd = " + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " and sugr.right_level <> 0 and avt.show = 1 ";
					mysql = mysql + " order by voucher_type ";
				}

				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsGLVoucherTypes.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsGLVoucherTypes.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsGLVoucherTypes.Tables.Clear();
				adap.Fill(rsGLVoucherTypes);
				cmbVoucherTypes.Clear();
				DataSet withVar = null;
				withVar = rsGLVoucherTypes;
				foreach (DataRow iteration_row in rsGLVoucherTypes.Tables[0].Rows)
				{
					cmbVoucherTypes.AddItem(Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? withVar.Tables[0].Rows[0]["l_voucher_name"] : withVar.Tables[0].Rows[0]["a_voucher_name"]));
					cmbVoucherTypes.SetItemData(cmbVoucherTypes.NewIndex, Convert.ToInt32(withVar.Tables[0].Rows[0]["voucher_type"]));
				}

				if (!PreventVoucherTypeSelection)
				{
					if (cmbVoucherTypes.ListCount > 0)
					{
						if (DefaultVoucherType != 0)
						{
							SystemCombo.SearchCombo(cmbVoucherTypes, Convert.ToInt32(Double.Parse(Conversion.Str(DefaultVoucherType))));
						}
						else
						{
							cmbVoucherTypes.ListIndex = 0;
						}
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}


		}

		private void cmbVoucherTypes_Click(Object Sender, EventArgs e)
		{
			object mOppositeLedgerDetails = null;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;
				object ans = null;
				string mysql = "";

				//'this was done because of misbehave of listbox after adding a transaction.
				//Call DefineVoucherArray(0, True)
				DefineVoucherArray(-1, true);

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("voucher_adjustment")))
				{
					//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aAdjustedVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					aAdjustedVoucherDetails.Clear();
					aAdjustedVoucherDetails.RedimXArray(new int[]{-1, conMaxVoucherLinkingCols}, new int[]{0, 0});
				}
				AssignGridLineNumbers();
				mFirstGridFocus = true;


				int mCurrentVoucherType = cmbVoucherTypes.GetItemData(cmbVoucherTypes.ListIndex);
				UserAccess.CheckAccess(mCurrentVoucherType, SystemVariables.SystemObjectTypes.objAccntVoucherType); //check for the user accesses for the selected voucher type
				if (UserAccess.DeniedAccess)
				{
					MessageBox.Show("Error: Access Denied!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				if (rsGLVoucherTypes.Tables[0].Rows.Count == 0)
				{
					mLastVoucherNo = 0;
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToDouble(rsGLVoucherTypes.Tables[0].Rows[0]["voucher_type"]) != mCurrentVoucherType)
					{
						mLastVoucherNo = 0;
					}
				}

				DataSet withVar = null;
				string mysql2 = "";
				withVar = rsGLVoucherTypes;
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsGLVoucherTypes.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsGLVoucherTypes.MoveFirst();
				rsGLVoucherTypes.Find("voucher_type = " + Conversion.Str(mCurrentVoucherType));
				if (withVar.Tables[0].Rows.Count == 0)
				{
					MessageBox.Show("error:", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}
				//''''*************************************************************************
				//**--Set the form caption
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? rsGLVoucherTypes.Tables[0].Rows[0]["a_voucher_name"] : rsGLVoucherTypes.Tables[0].Rows[0]["l_voucher_name"]));
				//''''*************************************************************************

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(withVar.Tables[0].Rows[0]["show_remarks_in_header"])) == TriState.True)
				{
					lblReference.Visible = true;
					txtReferenceNo.Visible = true;
				}
				else
				{
					lblReference.Visible = false;
					txtReferenceNo.Visible = false;
				}


				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(withVar.Tables[0].Rows[0]["show_flex_01_in_header"])) == TriState.True)
				{
					lblFlex01.Visible = true;
					txtFlex01.Visible = true;
				}
				else
				{
					lblFlex01.Visible = false;
					txtFlex01.Visible = false;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(withVar.Tables[0].Rows[0]["Show_Branch_Code_In_Header"])) == TriState.True)
				{
					lblBranchCode.Visible = true;
					txtBranchCode.Visible = true;
					txtBranchName.Visible = true;
				}
				else
				{
					lblBranchCode.Visible = false;
					txtBranchCode.Visible = false;
					txtBranchName.Visible = false;
				}

				//**--Posted Cheque Setting
				//''''*************************************************************************
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(withVar.Tables[0].Rows[0]["show_maturity_date"])) == TriState.True)
				{
					lblMaturityDate.Visible = true;
					txtMaturityDate.Visible = true;
					txtMaturityDate.Value = SystemVariables.gCurrentDate;
				}
				else
				{
					lblMaturityDate.Visible = false;
					txtMaturityDate.Visible = false;
				}


				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(withVar.Tables[0].Rows[0]["show_cheque_no"])) == TriState.True)
				{
					lblChequeNo.Visible = true;
					txtChequeNo.Visible = true;
				}
				else
				{
					lblChequeNo.Visible = false;
					txtChequeNo.Visible = false;
				}
				//''''*************************************************************************


				//**--Check for voucher no. generation method
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["auto_generate_voucher_no"]))
				{
					txtVoucherNo.Enabled = true;
					if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Get_Max_New_Voucher_No"]))
						{
							mLastVoucherNo = 0;
						}

						if (mLastVoucherNo == 0)
						{
							txtVoucherNo.Text = SystemGLProcedure.GLGetNewVoucherNo(cmbVoucherTypes.GetItemData(cmbVoucherTypes.ListIndex), StringsHelper.Format(txtVoucherDate.Value, SystemVariables.gSystemDateFormat), txtBranchCode.Text).ToString();
						}
						else
						{
							txtVoucherNo.Text = (mLastVoucherNo + 1).ToString();
						}
						txtReferenceNo.Text = txtVoucherNo.Text;
					}
				}
				else
				{
					if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
					{
						txtVoucherNo.Text = "";
						txtVoucherNo.Enabled = false;
					}
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[mLineNoColumn].Visible = Convert.ToBoolean(withVar.Tables[0].Rows[0]["show_line_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[mLedgerCodeColumn].Visible = Convert.ToBoolean(withVar.Tables[0].Rows[0]["show_ldgr_cd"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[mLedgerNameColumn].Visible = Convert.ToBoolean(withVar.Tables[0].Rows[0]["show_ldgr_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[mChequeNoColumn].Visible = Convert.ToBoolean(withVar.Tables[0].Rows[0]["show_cheque_no_in_details"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[mRemarksColumn].Visible = Convert.ToBoolean(withVar.Tables[0].Rows[0]["show_remarks_in_details"]);

				// For consignment number in detail--------------------------------
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Ledger_branch")))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mConsignmentColumn].Visible = Convert.ToBoolean(withVar.Tables[0].Rows[0]["Show_Consignment_In_Details"]);
				}
				//---------------------------------------------------------------------------------------------

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("multiple_currency")))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mCurrencySymbolColumn].Visible = Convert.ToBoolean(withVar.Tables[0].Rows[0]["show_currency"]);
				}
				else
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mCurrencySymbolColumn].Visible = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mExchangeRateColumn].Visible = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mFCAmountColumn].Visible = false;
				}

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mCostCenterColumn].Visible = Convert.ToBoolean(withVar.Tables[0].Rows[0]["show_cost_center"]);
				}
				else
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mCostCenterColumn].Visible = false;
				}

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("salesman")))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mSalesmanColumn].Visible = Convert.ToBoolean(withVar.Tables[0].Rows[0]["show_salesman"]);
				}
				else
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mSalesmanColumn].Visible = false;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[mFlex1Column].Visible = Convert.ToBoolean(withVar.Tables[0].Rows[0]["Show_Flex1_In_Details"]);

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[mAnlyCode1Column].Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_1"));
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[mAnlyCode2Column].Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_2"));

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("project_costing")))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mProjectColumn].Visible = Convert.ToBoolean(withVar.Tables[0].Rows[0]["show_project"]);
				}
				else
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mProjectColumn].Visible = false;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[mLedgerCodeColumn].AllowFocus = Convert.ToBoolean(withVar.Tables[0].Rows[0]["Allow_Listing_Of_Ldgr_Cd"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[mLedgerNameColumn].AllowFocus = Convert.ToBoolean(withVar.Tables[0].Rows[0]["Allow_Listing_Of_Ldgr_Name"]);

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (grdVoucherDetails.Splits[0].DisplayColumns[mCurrencySymbolColumn].Visible)
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mCurrencySymbolColumn].FooterDivider = true;
				}
				else if (grdVoucherDetails.Splits[0].DisplayColumns[mLedgerNameColumn].Visible)
				{ 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mLedgerNameColumn].FooterDivider = true;
				}
				else if (grdVoucherDetails.Splits[0].DisplayColumns[mLedgerCodeColumn].Visible)
				{ 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[mLedgerCodeColumn].FooterDivider = true;
				}
				//----------------------------------------------------------------------
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(withVar.Tables[0].Rows[0]["Show_Reference_No"])) == TriState.True)
				{
					lblReference.Visible = true;
					txtReferenceNo.Visible = true;
				}
				else
				{
					lblReference.Visible = false;
					txtReferenceNo.Visible = false;
				}
				//----------------------------------------------------------------------
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(withVar.Tables[0].Rows[0]["allow_single_entry"])) == TriState.True && ((TriState) Convert.ToInt32(withVar.Tables[0].Rows[0]["show_opposite_ldgr_in_header"])) == TriState.True)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode && !withVar.Tables[0].Rows[0].IsNull("Opposite_Ldgr_Cd"))
					{

						mysql2 = "select ldgr_no, ";
						mysql2 = mysql2 + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name");
						mysql2 = mysql2 + ", gcc.cost_no, ";
						mysql2 = mysql2 + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "gcc.l_cost_name" : "gcc.a_cost_name");
						mysql2 = mysql2 + " from gl_ledger l ";
						mysql2 = mysql2 + " left outer join gl_cost_centers gcc on l.default_cost_cd = gcc.cost_cd ";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mysql2 = mysql2 + " where ldgr_cd = " + Convert.ToString(withVar.Tables[0].Rows[0]["Opposite_Ldgr_Cd"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToString(withVar.Tables[0].Rows[0]["Single_Entry_Type"]) == "D")
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							if (!SystemProcedure2.IsItEmpty(rsGLVoucherTypes.Tables[0].Rows[0]["credit_filter_condition"], SystemVariables.DataType.StringType))
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mysql2 = mysql2 + " and (" + Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["credit_filter_condition"]) + ")";
							}
						}
						else
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							if (!SystemProcedure2.IsItEmpty(rsGLVoucherTypes.Tables[0].Rows[0]["debit_filter_condition"], SystemVariables.DataType.StringType))
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mysql2 = mysql2 + " and (" + Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["debit_filter_condition"]) + ")";
							}
						}
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mOppositeLedgerDetails = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql2));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mOppositeLedgerDetails))
						{
							//UPGRADE_WARNING: (1068) mOppositeLedgerDetails() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCashLedgerCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mOppositeLedgerDetails).GetValue(0));
							//UPGRADE_WARNING: (1068) mOppositeLedgerDetails() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCashLedgerName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mOppositeLedgerDetails).GetValue(1));

							if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
							{
								txtCostCenterCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mOppositeLedgerDetails).GetValue(2)) + "";
								txtCostCenterName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mOppositeLedgerDetails).GetValue(3)) + "";
							}
						}
						else
						{
							txtCashLedgerCode.Text = "";
							txtCashLedgerName.Text = "";
							txtCostCenterCode.Text = "";
							txtCostCenterName.Text = "";
						}
						//        Else
						//            txtCashLedgerCode.Text = ""
						//            txtCashLedgerName.Text = ""
						//            txtCostCenterCode.Text = ""
						//            txtCostCenterName.Text = ""
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (!withVar.Tables[0].Rows[0].IsNull("opposite_ldgr_header_caption"))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						lblCashLedgerDetails.Caption = Convert.ToString(withVar.Tables[0].Rows[0]["opposite_ldgr_header_caption"]);
					}
					else
					{
						lblCashLedgerDetails.Caption = " Cash / Bank Details ";
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (!withVar.Tables[0].Rows[0].IsNull("opposite_ldgr_cd_caption"))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						lblCashLedgerCode.Caption = Convert.ToString(withVar.Tables[0].Rows[0]["opposite_ldgr_cd_caption"]);
					}
					else
					{
						lblCashLedgerCode.Caption = "Cash / Bank Code";
					}

					//grdVoucherDetails.Columns(mDrCrTypeColumn).Visible = False

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToString(withVar.Tables[0].Rows[0]["Single_Entry_Type"]) == "D")
					{
						grdVoucherDetails.Columns[mLCAmountColumn].Caption = (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("multiple_currency"))) ? "Debit (KD)" : "Debit Amount";
						grdVoucherDetails.Columns[mFCAmountColumn].Caption = "Debit (Foreign)";
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdVoucherDetails.Splits[0].DisplayColumns[mDrCrTypeColumn].Visible = false;
						//grdVoucherDetails.Columns(mDebitAmountColumn).Visible = True
						//grdVoucherDetails.Columns(mCreditAmountColumn).Visible = False
					}
					else if (Convert.ToString(withVar.Tables[0].Rows[0]["Single_Entry_Type"]) == "C")
					{ 
						grdVoucherDetails.Columns[mLCAmountColumn].Caption = (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("multiple_currency"))) ? "Credit (KD)" : "Credit Amount";
						grdVoucherDetails.Columns[mFCAmountColumn].Caption = "Credit (Foreign)";
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdVoucherDetails.Splits[0].DisplayColumns[mDrCrTypeColumn].Visible = false;
						//grdVoucherDetails.Columns(mDebitAmountColumn).Visible = False
						//grdVoucherDetails.Columns(mCreditAmountColumn).Visible = True
					}

					fraCashLedgerDetails.Visible = true;
					lblCashLedgerCode.Visible = true;
					lblCashLedgerDetails.Visible = true;
					txtCashLedgerCode.Visible = true;
					txtCashLedgerName.Visible = true;

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
					{
						lblCostCenterCode.Visible = true;
						txtCostCenterCode.Visible = true;
						txtCostCenterName.Visible = true;
					}
					else
					{
						lblCostCenterCode.Visible = false;
						txtCostCenterCode.Visible = false;
						txtCostCenterName.Visible = false;
					}

					UCStatusBar.FindPane(SystemGLConstants.lcDiffrence1).Visible = false;
					UCStatusBar.FindPane(SystemGLConstants.lcDiffrence2).Visible = false;

					//'            lblBalance.Visible = False
					//'            txtBalance.Visible = False
				}
				else
				{

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (!Convert.ToBoolean(withVar.Tables[0].Rows[0]["show_dr_cr_type"]) && !ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("multiple_currency")))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdVoucherDetails.Splits[0].DisplayColumns[mDrCrTypeColumn].Visible = Convert.ToBoolean(withVar.Tables[0].Rows[0]["show_dr_cr_type"]);
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdVoucherDetails.Splits[0].DisplayColumns[mFCAmountColumn].Visible = false;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdVoucherDetails.Splits[0].DisplayColumns[mLCAmountColumn].Visible = false;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdVoucherDetails.Splits[0].DisplayColumns[mDebitAmountColumn].Visible = true;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdVoucherDetails.Splits[0].DisplayColumns[mCreditAmountColumn].Visible = true;
					}
					else
					{
						grdVoucherDetails.Columns[mLCAmountColumn].Caption = (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("multiple_currency"))) ? "Amount (KD)" : "Amount";
						grdVoucherDetails.Columns[mFCAmountColumn].Caption = "Amount (Foreign)";
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdVoucherDetails.Splits[0].DisplayColumns[mDrCrTypeColumn].Visible = true;
					}



					fraCashLedgerDetails.Visible = false;
					lblCashLedgerCode.Visible = false;
					lblCashLedgerDetails.Visible = false;

					txtCashLedgerCode.Visible = false;
					txtCashLedgerName.Visible = false;

					lblCostCenterCode.Visible = false;
					txtCostCenterCode.Visible = false;
					txtCostCenterName.Visible = false;

					UCStatusBar.FindPane(SystemGLConstants.lcDiffrence1).Visible = true;
					UCStatusBar.FindPane(SystemGLConstants.lcDiffrence2).Visible = true;

				}
				grdVoucherDetails.Rebind(true);
				//'Added By Moiz Hakimi
				//'Date: 26-Jan-2008
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				cmbVoucherTypes.Enabled = Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["enable_combo_list"]);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}




		private void txtBranchCode_DropButtonClick(Object Sender, EventArgs e)
		{
			try
			{
				SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtBranchCode");
			}
			catch
			{
			}
		}

		private void txtBranchCode_Leave(Object eventSender, EventArgs eventArgs)
		{

			try
			{
				object mTempValue = null;
				string mysql = "";

				if (!SystemProcedure2.IsItEmpty(txtBranchCode.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_branch_name, branch_cd" : "a_branch_name, branch_cd");
					mysql = mysql + " from gl_branch  ";
					mysql = mysql + " where branch_cd='" + txtBranchCode.Text + "'";
					mysql = mysql + " and show = 1 ";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempValue))
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtBranchName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
					}
					else
					{
						txtBranchName.Text = "";
						throw new System.Exception("-9990002");
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (!Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["auto_generate_voucher_no"]))
					{
						if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
						{
							txtVoucherNo.Text = SystemGLProcedure.GLGetNewVoucherNo(cmbVoucherTypes.GetItemData(cmbVoucherTypes.ListIndex), ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value), txtBranchCode.Text).ToString();
							txtReferenceNo.Text = txtVoucherNo.Text;
						}
					}
				}
				else
				{
					txtBranchName.Text = "";
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
					txtBranchCode.Focus();
				}
				else
				{
					//
				}
			}
		}

		private void txtCashLedgerCode_DropButtonClick(Object Sender, EventArgs e)
		{
			try
			{
				SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtCashLedgerCode");
			}
			catch
			{
			}
		}

		private void txtCashLedgerCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";

				DataSet withVar = null;
				if (!SystemProcedure2.IsItEmpty(txtCashLedgerCode.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l.l_ldgr_name, l.ldgr_cd" : "l.a_ldgr_name, l.ldgr_cd");
					mysql = mysql + ", gcc.cost_no, ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "gcc.l_cost_name" : "gcc.a_cost_name");
					mysql = mysql + " from gl_ledger l ";
					mysql = mysql + " left outer join gl_cost_centers gcc on l.default_cost_cd = gcc.cost_cd ";

					//'' --------------This code for ledger security ------ ---------------------------------------------
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
					{
						mysql = mysql + " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
					}
					//-----------------------------------------------------------------------------------------------------------

					mysql = mysql + " where l.ldgr_no='" + txtCashLedgerCode.Text + "'";
					mysql = mysql + " and l.discontinued = 0 ";

					//''----------- This code to filter ledger code for security -------------------------------------
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
					{
						mysql = mysql + " and gls.Group_Cd = " + SystemVariables.gLoggedInUserGroupCode.ToString() + " and gls.Show = 1";
					}
					//-----------------------------------------------------------------------------------------------------------

					withVar = rsGLVoucherTypes;
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToString(withVar.Tables[0].Rows[0]["Single_Entry_Type"]) == "D")
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (!SystemProcedure2.IsItEmpty(rsGLVoucherTypes.Tables[0].Rows[0]["credit_filter_condition"], SystemVariables.DataType.StringType))
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mysql = mysql + " and (" + Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["credit_filter_condition"]) + ")";
						}
					}
					else
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (!SystemProcedure2.IsItEmpty(rsGLVoucherTypes.Tables[0].Rows[0]["debit_filter_condition"], SystemVariables.DataType.StringType))
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mysql = mysql + " and (" + Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["debit_filter_condition"]) + ")";
						}
					}

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempValue))
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCashLedgerName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
						{
							if (SystemProcedure2.IsItEmpty(txtCostCenterCode.Text, SystemVariables.DataType.NumberType) || CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
							{
								txtCostCenterCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2)) + "";
								txtCostCenterName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3)) + "";
							}
						}

						//        If Left(mTempValue(1), 4) = Left(gGLCashTypeCode, 4) Or Left(mTempValue(1), 4) = Left(gGLBankTypeCode, 4) Or Left(mTempValue(1), 4) = Left(gGLBankTypeCode, 4) Then
						//            txtCashLedgerName.Text = mTempValue(0)
						//        Else
						//            txtCashLedgerName.Text = ""
						//            Err.Raise -9990002
						//        End If
					}
					else
					{
						txtCashLedgerName.Text = "";
						throw new System.Exception("-9990002");
					}
				}
				else
				{
					txtCashLedgerName.Text = "";
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
					txtCashLedgerCode.Focus();
				}
				else
				{
					//
				}
			}
		}

		private void lblExchangeRate_Click()
		{
			try
			{
				GetLedgerAmount1();
			}
			catch
			{
			}

		}


		private void txtCostCenterCode_DropButtonClick(Object Sender, EventArgs e)
		{
			try
			{
				SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtCostCenterCode");
			}
			catch
			{
			}
		}

		private void txtCostCenterCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";

				if (!SystemProcedure2.IsItEmpty(txtCostCenterCode.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cost_name, cost_cd" : "a_cost_name, cost_cd");
					mysql = mysql + " from gl_cost_centers gcc where cost_no=" + txtCostCenterCode.Text;
					mysql = mysql + " and gcc.show = 1 ";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempValue))
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCostCenterName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
					}
					else
					{
						txtCostCenterName.Text = "";
						throw new System.Exception("-9990002");
					}
				}
				else
				{
					txtCostCenterName.Text = "";
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
					txtCostCenterCode.Focus();
				}
				else
				{
					//
				}
			}

		}

		private void txtExchangeRate_Click()
		{
			GetLedgerAmount1();
		}

		private void lblTransactionAmount_Click()
		{
			GetLedgerAmount1();
		}

		private void txtFlex01_DropButtonClick(Object Sender, EventArgs e)
		{
			SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtFlex01");
		}

		private void txtTransactionAmount_Click()
		{
			GetLedgerAmount1();
		}

		private void DefineDebitCondition(DataSet rsTempRecords)
		{
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			if (!SystemProcedure2.IsItEmpty(rsGLVoucherTypes.Tables[0].Rows[0]["debit_filter_condition"], SystemVariables.DataType.StringType))
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				rsTempRecords.Tables[0].DefaultView.RowFilter = rsGLVoucherTypes.Tables[0].Rows[0]["debit_filter_condition"];
			}
			else
			{
				rsTempRecords.Tables[0].DefaultView.RowFilter = "";
			}
		}

		private void DefineCreditCondition(DataSet rsTempRecords)
		{
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			if (!SystemProcedure2.IsItEmpty(rsGLVoucherTypes.Tables[0].Rows[0]["credit_filter_condition"], SystemVariables.DataType.StringType))
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				rsTempRecords.Tables[0].DefaultView.RowFilter = rsGLVoucherTypes.Tables[0].Rows[0]["credit_filter_condition"];
			}
			else
			{
				rsTempRecords.Tables[0].DefaultView.RowFilter = "";
			}
		}

		private void DefineAnlysisFilter(DataSet rsTempRecords, int pAnalysisHeadNo)
		{

			rsTempRecords.Tables[0].DefaultView.RowFilter = " anly_head_no = " + pAnalysisHeadNo.ToString();

		}


		private void GetLedgerAmount(string pDrCrType)
		{
			//'This procedure prompts for the Exchange rate window
			//'In case of Foreign Currency
			//
			//Dim oChildLedgerAmountForm As New frmGLLedgerFCAmount
			//Dim mReturnValue As Variant
			//Dim mySql As String
			//
			//oChildLedgerAmountForm.Left = 90
			//oChildLedgerAmountForm.Top = 60 + (Me.Top + grdVoucherDetails.Top + grdVoucherDetails.Height) - oChildLedgerAmountForm.Height / 2
			//oChildLedgerAmountForm.ParentForm = Me
			//
			//
			//If Val(aVoucherDetails(grdVoucherDetails.Bookmark, mExchangeRateColumn)) = 0 Then
			//    mySql = " select exchange_rate from gl_currency "
			//    mySql = mySql & " where symbol ='" & aVoucherDetails(grdVoucherDetails.Bookmark, mCurrencySymbolColumn) & "'"
			//    mReturnValue = GetMasterCode(mySql)
			//    If Not IsNull(mReturnValue) Then
			//        If mReturnValue > 0 Then
			//            oChildLedgerAmountForm.txtExchangeRate.Value = mReturnValue
			//        End If
			//    End If
			//Else
			//    oChildLedgerAmountForm.txtExchangeRate.Value = Val(aVoucherDetails(grdVoucherDetails.Bookmark, mExchangeRateColumn))
			//End If
			//
			//oChildLedgerAmountForm.txtFCAmount.Value = Val(aVoucherDetails(grdVoucherDetails.Bookmark, mLineFCAmountColumn))
			//
			//'If grdVoucherDetails.Columns(mDrCrTypeColumn).Value = mDrTypeCaption Then
			//'    oChildLedgerAmountForm.optAmountType(0).Value = True
			//'Else
			//'    oChildLedgerAmountForm.optAmountType(1).Value = True
			//'End If
			//
			//'If grdVoucherDetails.Columns(mDrCrTypeColumn).Visible = False Then
			//'    oChildLedgerAmountForm.optAmountType(0).Enabled = False
			//'    oChildLedgerAmountForm.optAmountType(1).Enabled = False
			//'Else
			//'    oChildLedgerAmountForm.optAmountType(0).Enabled = True
			//'    oChildLedgerAmountForm.optAmountType(1).Enabled = True
			//'End If
			//
			//
			//oChildLedgerAmountForm.Show 1
			//
			//'If grdVoucherDetails.Columns(mDrCrTypeColumn).Value = mDrTypeCaption Then
			//'    grdVoucherDetails.Columns(mDebitAmountColumn).Value = Val(aVoucherDetails(grdVoucherDetails.Bookmark, mLineFCAmountColumn)) * Val(aVoucherDetails(grdVoucherDetails.Bookmark, mExchangeRateColumn))
			//'Else
			//'    grdVoucherDetails.Columns(mCreditAmountColumn).Value = Val(aVoucherDetails(grdVoucherDetails.Bookmark, mLineFCAmountColumn)) * Val(aVoucherDetails(grdVoucherDetails.Bookmark, mExchangeRateColumn))
			//'End If
			//
			//If oChildLedgerAmountForm.IsOkClicked = True Then
			//    If pDrCrType = mDrTypeCaption Then         ''Debit
			//        'grdVoucherDetails.Columns(mDebitAmountColumn).Value = Format(Val(aVoucherDetails(grdVoucherDetails.Bookmark, mLineFCAmountColumn)) * Val(aVoucherDetails(grdVoucherDetails.Bookmark, mExchangeRateColumn)), "##############0.000")      ' "###,###,###,###,##0.000")
			//        'grdVoucherDetails.Columns(mCreditAmountColumn).Value = 0
			//    Else
			//        grdVoucherDetails.Columns(mCreditAmountColumn).Value = Format(Val(aVoucherDetails(grdVoucherDetails.Bookmark, mLineFCAmountColumn)) * Val(aVoucherDetails(grdVoucherDetails.Bookmark, mExchangeRateColumn)), "##############0.000")
			//        grdVoucherDetails.Columns(mDebitAmountColumn).Value = 0
			//    End If
			//End If
			//
			//Unload oChildLedgerAmountForm
			//Set oChildLedgerAmountForm = Nothing
			//
			//txtExchangeRate.Caption = aVoucherDetails(grdVoucherDetails.Bookmark, mExchangeRateColumn)
			//txtTransactionAmount.Caption = aVoucherDetails(grdVoucherDetails.Bookmark, mLineFCAmountColumn)
			//
		}

		public void ShowLedgerDetails(bool pShowRecordEmpty)
		{
			if (!pShowRecordEmpty)
			{
				rsLedgerCodeList.Tables[0].DefaultView.RowFilter = "";
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsLedgerCodeList.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLedgerCodeList.MoveFirst();
				rsLedgerCodeList.Find("ldgr_no='" + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[mLedgerCodeColumn].Value) + "'");
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerCodeList.BOF was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (rsLedgerCodeList.Tables[0].Rows.Count != 0 || rsLedgerCodeList.getBOF())
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					UCStatusBar.FindPane(SystemGLConstants.lcGroup2).Text = Convert.ToString(rsLedgerCodeList.Tables[0].Rows[0]["group_name"]);

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Show_FC_Balance_In_Taskbar"]))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						UCStatusBar.FindPane(SystemGLConstants.lcCurrBal2).Text = StringsHelper.Format(Math.Abs(Convert.ToDouble(rsLedgerCodeList.Tables[0].Rows[0]["FC_Balance"])), "###,###,###,###,##0.000") + ((Convert.ToDouble(rsLedgerCodeList.Tables[0].Rows[0]["FC_Balance"]) != 0) ? ((Convert.ToDouble(rsLedgerCodeList.Tables[0].Rows[0]["FC_Balance"]) > 0) ? "   Dr" : "   Cr") : "");
					}
					else
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						UCStatusBar.FindPane(SystemGLConstants.lcCurrBal2).Text = StringsHelper.Format(Math.Abs(Convert.ToDouble(rsLedgerCodeList.Tables[0].Rows[0]["current_bal"])), "###,###,###,###,##0.000") + ((Convert.ToDouble(rsLedgerCodeList.Tables[0].Rows[0]["current_bal"]) != 0) ? ((Convert.ToDouble(rsLedgerCodeList.Tables[0].Rows[0]["current_bal"]) > 0) ? "   Dr" : "   Cr") : "");
					}
				}
				else
				{
					UCStatusBar.FindPane(SystemGLConstants.lcGroup2).Text = "";
					UCStatusBar.FindPane(SystemGLConstants.lcCurrBal2).Text = "";

				}
			}
			else
			{
				UCStatusBar.FindPane(SystemGLConstants.lcGroup2).Text = "";
				UCStatusBar.FindPane(SystemGLConstants.lcCurrBal2).Text = "";

			}
		}



		private void GetVoucherAdjustmentDetails(string pLedgerCode, double mLedgerAmount, string pDrCrType, string pCurrSymbol)
		{
			DataSet rsCloneRecordset = null;

			frmARAPVoucherLinking oVoucherAmountAdjustment = null;
			if (!SystemProcedure2.IsItEmpty(pLedgerCode, SystemVariables.DataType.StringType) && mLedgerAmount != 0)
			{
				//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsLedgerCodeList.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsCloneRecordset = rsLedgerCodeList.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsCloneRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsCloneRecordset.MoveFirst();
				rsCloneRecordset.Find("ldgr_no='" + pLedgerCode + "'");
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCloneRecordset.BOF was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (rsCloneRecordset.Tables[0].Rows.Count != 0 || rsCloneRecordset.getBOF())
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToDouble(rsCloneRecordset.Tables[0].Rows[0]["type_cd"]) == SystemGLConstants.gGLCustomerVendorTypeCode)
					{
						oVoucherAmountAdjustment = frmARAPVoucherLinking.CreateInstance();

						oVoucherAmountAdjustment.SetVoucherSourceArray = aAdjustedVoucherDetails;
						oVoucherAmountAdjustment.FormMode = this.CurrentFormMode;
						//UPGRADE_WARNING: (1068) grdVoucherDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						oVoucherAmountAdjustment.LineNo = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[mLineNoColumn].Value);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						oVoucherAmountAdjustment.LedgerCode = Convert.ToInt32(rsCloneRecordset.Tables[0].Rows[0]["ldgr_cd"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						oVoucherAmountAdjustment.LedgerNo = Convert.ToString(rsCloneRecordset.Tables[0].Rows[0]["ldgr_no"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						oVoucherAmountAdjustment.LedgerName = Convert.ToString(rsCloneRecordset.Tables[0].Rows[0]["ldgr_name"]);
						oVoucherAmountAdjustment.CurrencySymbol = pCurrSymbol; // .Fields("symbol").Value
						oVoucherAmountAdjustment.LedgerAmount = mLedgerAmount;
						oVoucherAmountAdjustment.DrCrType = pDrCrType;

						oVoucherAmountAdjustment.Left = 6;
						oVoucherAmountAdjustment.Top = 70 + (this.Top + grdVoucherDetails.Top + grdVoucherDetails.Height) - oVoucherAmountAdjustment.Height;
						//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						//VB.Global.Load(oVoucherAmountAdjustment);
						//UPGRADE_WARNING: (7009) Multiple invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions More Information: https://docs.mobilize.net/vbuc/ewis#7009
						oVoucherAmountAdjustment.ShowDialog();
					}
				}
			}

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				rsCloneRecordset = null;
				oVoucherAmountAdjustment.Close();
				oVoucherAmountAdjustment = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int Cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_3 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_4 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_5 = null;
			switch(grdVoucherDetails.Col)
			{
				case mRemarksColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList.setListField("remark_name"); 
					cmbMastersList.DisplayColumns[0].Visible = true; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbMastersList.Width = grdVoucherDetails.Splits[0].DisplayColumns[mLineNoColumn].Width + 167; 
					cmbMastersList.Height = 167; 
					break;
				case mConsignmentColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList.setListField("consignment_no"); 
					cmbMastersList.DisplayColumns[0].Visible = true; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbMastersList.Width = grdVoucherDetails.Splits[0].DisplayColumns[mLineNoColumn].Width + 167; 
					cmbMastersList.Height = 167; 
					break;
				case mDrCrTypeColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList.setListField("type"); 
					cmbMastersList.DisplayColumns[0].Visible = true; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbMastersList.Width = grdVoucherDetails.Splits[0].DisplayColumns[mLineNoColumn].Width + 17; 
					cmbMastersList.Height = 47; 
					//    Case mDrCrTypeColumn 
					//        cmbMastersList.Columns(0).Visible = True 
					//        cmbMastersList.Width = grdVoucherDetails.Columns(mLineNoColumn).Width + 1000 
					//        cmbMastersList.Height = 1200 
					break;
				case mCurrencySymbolColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList.setListField("Symbol"); 
					cmbMastersList.DisplayColumns[0].Visible = true; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbMastersList.Width = grdVoucherDetails.Splits[0].DisplayColumns[mLineNoColumn].Width + 233; 
					cmbMastersList.Height = 167; 
					break;
				case mLedgerCodeColumn : case mLedgerNameColumn : 
					//        If (grdVoucherDetails.Columns(mDrCrTypeColumn).Value = mDrTypeCaption) Then 
					//            Call DefineDebitCondition(rsLedgerCodeList) 
					//        ElseIf (grdVoucherDetails.Columns(mDrCrTypeColumn).Value = mCrTypeCaption) Then 
					//            Call DefineCreditCondition(rsLedgerCodeList) 
					//        ElseIf (rsGLVoucherTypes.Fields("Allow_Single_Entry").Value = False) And (Val(Format(grdVoucherDetails.Columns(mCreditAmountColumn).FooterText, "###########0.000")) > Val(Format(grdVoucherDetails.Columns(mDebitAmountColumn).FooterText, "###########0.000"))) Then 
					//            Call DefineDebitCondition(rsLedgerCodeList) 
					//        ElseIf (rsGLVoucherTypes.Fields("Allow_Single_Entry").Value = False) And (Val(Format(grdVoucherDetails.Columns(mDebitAmountColumn).FooterText, "###########0.000")) > Val(Format(grdVoucherDetails.Columns(mCreditAmountColumn).FooterText, "###########0.000"))) Then 
					//            Call DefineCreditCondition(rsLedgerCodeList) 
					//        ElseIf rsGLVoucherTypes.Fields("Default_Dr_Cr_Type") = "D" Then 
					//            Call DefineDebitCondition(rsLedgerCodeList) 
					//        ElseIf rsGLVoucherTypes.Fields("Default_Dr_Cr_Type") = "C" Then 
					//            Call DefineCreditCondition(rsLedgerCodeList) 
					//        Else 
					//            MsgBox "Error:" 
					//        End If 
					 
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
					if ((Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Allow_Single_Entry"])) && Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Default_Dr_Cr_Type"]) == mDrTypeCaption)
					{
						DefineDebitCondition(rsLedgerCodeList);
					}
					else if ((Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Allow_Single_Entry"])) && Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["Default_Dr_Cr_Type"]) == mCrTypeCaption)
					{ 
						DefineCreditCondition(rsLedgerCodeList);
					}
					else if ((!Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Allow_Single_Entry"])))
					{ 
						//'In case of double line entry the filteration will be applied
						//'from debit_filter_condition to both the debit and credit ledger list.
						DefineDebitCondition(rsLedgerCodeList);
					}
					else
					{
						MessageBox.Show("Error:", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					} 
					 
					if (grdVoucherDetails.Col == mLedgerCodeColumn)
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
					for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersList.Splits[0].DisplayColumns[Cnt];
						if (Cnt < 2)
						{
							if (Cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == mLedgerCodeColumn) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[mLedgerCodeColumn].Width;
							}
							else
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == mLedgerCodeColumn) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[mLedgerNameColumn].Width;
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
				case mCostCenterColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList.setListField("cost_no"); 
					int tempForEndVar2 = cmbMastersList.Columns.Count - 1; 
					for (Cnt = 0; Cnt <= tempForEndVar2; Cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_2 = cmbMastersList.Splits[0].DisplayColumns[Cnt];
						if (Cnt < 2)
						{
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							withVar_2.Visible = true;
							if (Cnt == 0)
							{
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbMastersList.DisplayColumns[Cnt].Width = grdVoucherDetails.Splits[0].DisplayColumns[mCostCenterColumn].Width;
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbMastersList.Width += grdVoucherDetails.Splits[0].DisplayColumns[mCostCenterColumn].Width;
							}
							else if (Cnt == 1)
							{ 
								cmbMastersList.DisplayColumns[Cnt].Width = 133;
								cmbMastersList.Width += 200;
							}
						}
						else
						{
							withVar_2.Visible = false;
						}
						withVar_2.AllowSizing = false;
					} 
					cmbMastersList.Width += 17; 
					cmbMastersList.Height = 100; 
					break;
				case mSalesmanColumn : 
					int tempForEndVar3 = cmbMastersList.Columns.Count - 1; 
					for (Cnt = 0; Cnt <= tempForEndVar3; Cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_3 = cmbMastersList.Splits[0].DisplayColumns[Cnt];
						if (Cnt < 2)
						{
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar_3.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar_3.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							withVar_3.Visible = true;
							if (Cnt == 0)
							{
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbMastersList.DisplayColumns[Cnt].Width = grdVoucherDetails.Splits[0].DisplayColumns[mSalesmanColumn].Width;
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbMastersList.Width += grdVoucherDetails.Splits[0].DisplayColumns[mSalesmanColumn].Width;
							}
							else if (Cnt == 1)
							{ 
								cmbMastersList.DisplayColumns[Cnt].Width = 67;
								cmbMastersList.Width += 67;
							}
						}
						else
						{
							withVar_3.Visible = false;
						}
						withVar_3.AllowSizing = false;
					} 
					cmbMastersList.Width += 17; 
					cmbMastersList.Height = 100; 
					break;
				case mAnlyCode1Column : case mAnlyCode2Column : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList.setListField("anly_code"); 
					 
					if (grdVoucherDetails.Col == mAnlyCode1Column)
					{
						DefineAnlysisFilter(rsAnlyCode, 1);
					}
					else if (grdVoucherDetails.Col == mAnlyCode2Column)
					{ 
						DefineAnlysisFilter(rsAnlyCode, 2);
					} 
					 
					int tempForEndVar4 = cmbMastersList.Columns.Count - 1; 
					for (Cnt = 0; Cnt <= tempForEndVar4; Cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_4 = cmbMastersList.Splits[0].DisplayColumns[Cnt];
						if (Cnt < 2)
						{
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar_4.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar_4.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							withVar_4.Visible = true;
							if (Cnt == 0)
							{
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbMastersList.DisplayColumns[Cnt].Width = grdVoucherDetails.Splits[0].DisplayColumns[grdVoucherDetails.Col].Width;
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbMastersList.Width += grdVoucherDetails.Splits[0].DisplayColumns[grdVoucherDetails.Col].Width;
							}
							else if (Cnt == 1)
							{ 
								cmbMastersList.DisplayColumns[Cnt].Width = 153;
								cmbMastersList.Width += 153;
							}
						}
						else
						{
							withVar_4.Visible = false;
						}
						withVar_4.AllowSizing = false;
					} 
					cmbMastersList.Width += 17; 
					cmbMastersList.Height = 100; 
					break;
				case mProjectColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList.setListField("project_no"); 
					int tempForEndVar5 = cmbMastersList.Columns.Count - 1; 
					for (Cnt = 0; Cnt <= tempForEndVar5; Cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_5 = cmbMastersList.Splits[0].DisplayColumns[Cnt];
						if (Cnt < 2)
						{
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar_5.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar_5.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							withVar_5.Visible = true;
							if (Cnt == 0)
							{
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbMastersList.DisplayColumns[Cnt].Width = grdVoucherDetails.Splits[0].DisplayColumns[grdVoucherDetails.Col].Width;
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbMastersList.Width += grdVoucherDetails.Splits[0].DisplayColumns[grdVoucherDetails.Col].Width;
							}
							else if (Cnt == 1)
							{ 
								cmbMastersList.DisplayColumns[Cnt].Width = 180;
								cmbMastersList.Width += 180;
							}
						}
						else
						{
							withVar_5.Visible = false;
						}
						withVar_5.AllowSizing = false;
					} 
					cmbMastersList.Width += 17; 
					cmbMastersList.Height = 100; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			//If grdVoucherDetails.Col = mLedgerCodeColumn Or grdVoucherDetails.Col = mLedgerNameColumn Then
			//    On Error Resume Next
			//    If cmbMastersList.Columns(5).Value <> gDefaultCurrencyCd Then
			//        grdVoucherDetails.Columns(mDebitAmountColumn).Value = 0
			//        grdVoucherDetails.Columns(mCreditAmountColumn).Value = 0
			//    End If
			//    On Error GoTo 0
			//End If

			switch(grdVoucherDetails.Col)
			{
				//    Case mDrCrTypeColumn
				//        If grdVoucherDetails.Columns(mLedgerCodeColumn).Visible = True And grdVoucherDetails.Columns(mLedgerCodeColumn).AllowFocus = True Then
				//            grdVoucherDetails.Col = mLedgerCodeColumn
				//        Else
				//            grdVoucherDetails.Col = mLedgerNameColumn
				//        End If
				case mLedgerCodeColumn : 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					if (grdVoucherDetails.Splits[0].DisplayColumns[mLedgerNameColumn].Visible && grdVoucherDetails.Splits[0].DisplayColumns[mLedgerNameColumn].AllowFocus)
					{
						grdVoucherDetails.Col = mLedgerNameColumn;
					}
					else
					{
					} 
					 
					break;
				case mLedgerNameColumn : case mCostCenterColumn : case mSalesmanColumn : 
					break;
			}

		}

		//Private Function ApplyCostCenterToLedger(pLedgerCode As String) As Boolean
		//Dim rsCloneRecordset As ADODB.Recordset
		//
		//If pLedgerCode <> 0 Then
		//    Set rsCloneRecordset = rsLedgerCodeList.Clone
		//    With rsCloneRecordset
		//        .MoveFirst
		//        .Find "ldgr_no='" & pLedgerCode & "'"
		//        If Not .EOF Or .BOF Then
		//            ApplyCostCenterToLedger = .Fields("Apply_Cost_Center").Value
		//        Else
		//            ApplyCostCenterToLedger = False
		//        End If
		//    End With
		//Else
		//    ApplyCostCenterToLedger = False
		//End If
		//
		//If TypeName(rsCloneRecordset) <> "Nothing" Then
		//    If rsCloneRecordset.State = adStateOpen Then
		//        rsCloneRecordset.Close
		//    End If
		//End If
		//Set rsCloneRecordset = Nothing
		//End Function

		private bool InsertAdjustedVoucherDetails(int pCurrentLineNo)
		{
			int Cnt = 0;
			//Dim rsGetLineNo As ADODB.Recordset
			int mNewLineNo = 0;
			object mReturnValue = null;
			string mysql = "";

			int mDrSourceLineNo = 0;
			int mCrAgainstLineNo = 0;

			bool mGetSourceLineNo = true;

			int tempForEndVar = aAdjustedVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				if (Convert.ToDouble(aAdjustedVoucherDetails.GetValue(Cnt, conVLLineNoColumn)) == pCurrentLineNo)
				{
					if (mGetSourceLineNo)
					{
						mGetSourceLineNo = false;

						//Set rsGetLineNo = gConn.Execute("select scope_identity()")
						mysql = "select scope_identity()";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mNewLineNo = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
						}
						else
						{
							MessageBox.Show("Error : Can not proceed with save!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							return false;
						}
					}

					if (Convert.ToString(aAdjustedVoucherDetails.GetValue(Cnt, conVLDrCrTypeColumn)) == mDrTypeCaption)
					{
						mDrSourceLineNo = mNewLineNo;
						mCrAgainstLineNo = Convert.ToInt32(Conversion.Val(Convert.ToString(aAdjustedVoucherDetails.GetValue(Cnt, conVLAgainstLineNoColumn))));
					}
					else
					{
						mDrSourceLineNo = Convert.ToInt32(Conversion.Val(Convert.ToString(aAdjustedVoucherDetails.GetValue(Cnt, conVLSourceLineNoColumn))));
						mCrAgainstLineNo = mNewLineNo;
					}

					//''this check is to double check the database if the condition is true
					//''if this error does not occur for any user then it should be removed in future.
					//''it was created to confirm the logic is right.
					mysql = " select count(*) from ";
					mysql = mysql + " (select line_no from gl_accnt_trans_details ";
					mysql = mysql + " where line_no = " + mDrSourceLineNo.ToString() + " and dr_cr_type = '" + mDrTypeCaption + "' ";
					mysql = mysql + " Union All ";
					mysql = mysql + " select line_no from gl_accnt_trans_details ";
					mysql = mysql + " where line_no = " + mCrAgainstLineNo.ToString() + " and dr_cr_type = '" + mCrTypeCaption + "') temptable ";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) != 2)
					{
						MessageBox.Show("Error in Invoice Tracking Adjustment, Contact System Administrator ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}

					//*--updating main transaction table
					//*-- check whether the row is in the same status when it was retreived from the table for updation
					//make it If CurrentFormMode = frmEditMode Then
					//        mAgainstLineNo = Val(aAdjustedVoucherDetails(cnt, conVLAgainstLineNoColumn))

					//        mySql = "select time_stamp, dr_cr_type from gl_accnt_trans_details where line_no = " & mAgainstLineNo
					//        mReturnValue = GetMasterCode(mySql)
					//        If Not IsNull(mReturnValue) Then
					//            mCheckTimeStamp = mReturnValue(0)
					//            If mReturnValue(1) = "D" Then
					//                mDrSourceLineNo = mAgainstLineNo
					//            Else
					//                mDrSourceLineNo = mNewLineNo
					//            End If
					//        End If
					//        If IsNull(mReturnValue) Or (tsFormat(aAdjustedVoucherDetails(cnt, conVLLinkedTimeStampColumn)) <> tsFormat(mCheckTimeStamp)) Then
					//            InsertAdjustedVoucherDetails = False
					//            Exit Function
					//        End If
					//
					//        mySql = " select dr_cr_type from gl_accnt_trans_details where line_no = " & mNewLineNo
					//        mReturnValue = GetMasterCode(mySql)
					//        If Not IsNull(mReturnValue) Then
					//            If mReturnValue = "C" Then
					//                mCrAgainstLineNo = mNewLineNo
					//            Else
					//                mCrAgainstLineNo = mAgainstLineNo
					//            End If
					//        End If

					mysql = "insert into gl_invoice_tracking ";
					mysql = mysql + " (source_line_no, against_line_no, adjusted_amt, comments, user_cd) ";
					mysql = mysql + " values( ";
					mysql = mysql + Conversion.Str(mDrSourceLineNo) + ",";
					mysql = mysql + Conversion.Str(mCrAgainstLineNo) + ",";
					mysql = mysql + Conversion.Str(aAdjustedVoucherDetails.GetValue(Cnt, conVLAdjustedAmountColumn)) + ",";
					mysql = mysql + "N'" + Convert.ToString(aAdjustedVoucherDetails.GetValue(Cnt, conVLLinkedRemarksColumn)) + "',";
					mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
			}
			return true;
		}

		private void InsertAdjustedVouchersInArray(int pVoucherEntryId)
		{
			DataSet rsAdjustedVouchers = new DataSet();

			//mysql = " select vt.source_line_no, vt.against_line_no, vt.adjusted_amt, "
			//mysql = mysql & " (select atd2.time_stamp from gl_accnt_trans_details atd2 "
			//mysql = mysql & " where line_no = vt.against_line_no ), "
			//mysql = mysql & " vt.comments from gl_invoice_tracking vt "
			//mysql = mysql & " inner join gl_accnt_trans_details atd on vt.source_line_no = atd.line_no "
			//mysql = mysql & " where atd.entry_id = " & Str(pVoucherEntryId)
			//mysql = mysql & " order by vt.source_line_no "

			string mysql = " select 0 as line_no , atd.dr_cr_type";
			mysql = mysql + " , vt.source_line_no, vt.against_line_no, vt.adjusted_amt, ";
			//''get the opposite line no..incase of dr get against and cr get sourcelineno
			mysql = mysql + " case when atd.dr_cr_type = 'D' then ";
			mysql = mysql + " (select atd2.time_stamp from gl_accnt_trans_details atd2 ";
			mysql = mysql + " where line_no = vt.against_line_no ) ";
			mysql = mysql + " Else ";
			mysql = mysql + " (select atd2.time_stamp from gl_accnt_trans_details atd2 ";
			mysql = mysql + " where line_no = vt.source_line_no ) end ";
			mysql = mysql + " , vt.comments from gl_invoice_tracking vt ";
			mysql = mysql + " inner join gl_accnt_trans_details atd ";
			mysql = mysql + " on (vt.source_line_no = atd.line_no  or vt.against_line_no = atd.line_no  ) ";
			mysql = mysql + " where atd.entry_id = " + Conversion.Str(pVoucherEntryId);
			mysql = mysql + " order by vt.source_line_no ";

			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsAdjustedVouchers.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsAdjustedVouchers.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsAdjustedVouchers.Tables.Clear();
			adap.Fill(rsAdjustedVouchers);
			if (rsAdjustedVouchers.Tables[0].Rows.Count != 0)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aAdjustedVoucherDetails.LoadRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aAdjustedVoucherDetails.LoadRows((object[, ]) rsAdjustedVouchers.GetRows(-1, null, null), true);
			}
		}

		private bool DeleteCurrentLineAdjustment(int pCurrentLineNo, ref bool pConfirmDelete)
		{
			int Cnt = 0;
			DialogResult ans = (DialogResult) 0;

			int tempForEndVar = aAdjustedVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				if (Cnt >= aAdjustedVoucherDetails.GetLength(0))
				{
					break;
				}
				if (Conversion.Val(Convert.ToString(aAdjustedVoucherDetails.GetValue(Cnt, conVLLineNoColumn))) == pCurrentLineNo)
				{
					if (pConfirmDelete)
					{
						pConfirmDelete = false;
						ans = MessageBox.Show("Modifying / Deleting current line will delete all the " + "\r" + "linked adjusted vouchers... proceed with changes?", "Error:", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
						if (ans == System.Windows.Forms.DialogResult.No)
						{
							return false;
						}
					}
					//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aAdjustedVoucherDetails.DeleteRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					aAdjustedVoucherDetails.DeleteRows(Cnt, 1);
					Cnt--;
				}
			}
			return true;
		}

		public bool Post()
		{
			bool result = false;
			DialogResult ans = (DialogResult) 0;
			string mDrCrType = "";
			frmSysOnlinePosting frmTemp = frmSysOnlinePosting.CreateInstance();

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				if (mOldVoucherStatus == SystemVariables.VoucherStatus.stPosted)
				{ //if voucher is in posted mode
					MessageBox.Show(SystemConstants.msg26 + SystemConstants.msg23, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
				}
				else if (mOldVoucherStatus == SystemVariables.VoucherStatus.stVoid)
				{  //if voucher is in deleted mode
					MessageBox.Show(SystemConstants.msg27 + SystemConstants.msg23, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
				}
				else if (mOldVoucherStatus == SystemVariables.VoucherStatus.stAutoGenerated)
				{  //if voucher is in deleted mode
					MessageBox.Show(SystemConstants.msg28 + SystemConstants.msg23, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
				}
				//    If FirstFocusObject.Enabled = True Then
				//        FirstFocusObject.SetFocus
				//    End If
				return result;
			}

			frmTemp.ShowDialog();

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
						if (frmTemp.mApprove)
						{
							SystemVariables.gConn.BeginTransaction();

							SystemICSProcedure.ApproveTransaction("gl_accnt_trans", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(rsGLVoucherTypes.Tables[0].Rows[0]["pdc_generated_linked_gl_voucher_type"]))
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								if (Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["single_entry_type"]) == "D")
								{
									mDrCrType = "C";
								}
								else
								{
									mDrCrType = "D";
								}

								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								if (!SystemGLProcedure.GenerateLinkedVoucherForPDC(Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["pdc_generated_linked_gl_voucher_type"]), ReflectionHelper.GetPrimitiveValue<int>(SearchValue), Convert.ToInt32(Double.Parse("")), mDrCrType))
								{
									result = false;
									//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
									SystemVariables.gConn.RollbackTrans();
									txtMaturityDate.Focus();
									goto mDestroy;
								}
							}

							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.CommitTrans();

						}
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

		private void PostToGL(int pEntryId)
		{
			string myString = "update gl_accnt_trans ";
			myString = myString + " set status = 2 ";
			myString = myString + " where status = 1 ";
			myString = myString + " and entry_id =" + Conversion.Str(pEntryId);

			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = myString;
			TempCommand.ExecuteNonQuery();
		}

		private void DefineMasterRecordset()
		{
			string mysql = "";
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			if (grdVoucherDetails.Splits[0].DisplayColumns[mCurrencySymbolColumn].Visible && grdVoucherDetails.Splits[0].DisplayColumns[mCurrencySymbolColumn].AllowFocus)
			{
				if (mFirstGridFocus)
				{
					mysql = "select symbol, " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_curr_name " : "a_curr_name ");
					mysql = mysql + " ,curr_no, exchange_rate from gl_currency order by 1";

					rsCurrencySymbols = new DataSet();
					//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCurrencySymbols.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsCurrencySymbols.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
					SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsCurrencySymbols.Tables.Clear();
					adap.Fill(rsCurrencySymbols);
				}
				else
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsCurrencySymbols.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsCurrencySymbols.Requery(-1);
				}
			}

			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			if (grdVoucherDetails.Splits[0].DisplayColumns[mRemarksColumn].Visible)
			{
				if (mFirstGridFocus)
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_remarks " : "a_remarks ");
					mysql = mysql + " as remarks_name from GL_Accnt_Trans_Details_Remarks_Master order by 1";

					rsRemarksList = new DataSet();
					//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsRemarksList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsRemarksList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
					SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsRemarksList.Tables.Clear();
					adap_2.Fill(rsRemarksList);
				}
				else
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsRemarksList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsRemarksList.Requery(-1);
				}
			}

			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			if (grdVoucherDetails.Splits[0].DisplayColumns[mConsignmentColumn].Visible)
			{
				if (mFirstGridFocus)
				{
					mysql = "select consignment_no, " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_consignment_name " : "a_consignment_name ");
					mysql = mysql + " from gl_consignment order by 1";

					rsConsignmentsList = new DataSet();
					//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsConsignmentsList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsConsignmentsList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
					SqlDataAdapter adap_3 = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsConsignmentsList.Tables.Clear();
					adap_3.Fill(rsConsignmentsList);
				}
				else
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsConsignmentsList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsConsignmentsList.Requery(-1);
				}
			}


			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			if ((grdVoucherDetails.Splits[0].DisplayColumns[mLedgerCodeColumn].Visible && grdVoucherDetails.Splits[0].DisplayColumns[mLedgerCodeColumn].AllowFocus) || (grdVoucherDetails.Splits[0].DisplayColumns[mLedgerNameColumn].Visible && grdVoucherDetails.Splits[0].DisplayColumns[mLedgerNameColumn].AllowFocus))
			{
				if (mFirstGridFocus)
				{
					mysql = "select ldgr_no, ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l.l_ldgr_name as ldgr_name" : "l.a_ldgr_name as ldgr_name");
					mysql = mysql + " , ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "gl_accnt_group.l_group_name as group_name" : "gl_accnt_group.a_group_name as group_name");
					mysql = mysql + " , current_bal, gl_currency.symbol, gl_currency.curr_cd, l.type_cd, l.ldgr_cd ";
					mysql = mysql + " , cc.cost_no, l.type_cd as type_cd ";
					mysql = mysql + " , l.default_dr_cr_type ";

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Show_FC_Balance_In_Taskbar"]))
					{
						mysql = mysql + " , (select sum(FC_Amount) from GL_Accnt_Trans_Details dt1 where dt1.ldgr_cd = l.ldgr_cd) as FC_Balance";
					}

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
					SqlDataAdapter adap_4 = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsLedgerCodeList.Tables.Clear();
					adap_4.Fill(rsLedgerCodeList);
				}
				else
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsLedgerCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsLedgerCodeList.Requery(-1);
				}
			}

			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			if (grdVoucherDetails.Splits[0].DisplayColumns[mSalesmanColumn].Visible)
			{
				if (mFirstGridFocus)
				{
					mysql = "select sman_no, ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_sman_name as sman_name" : "a_sman_name as sman_name");
					mysql = mysql + " from SM_salesman";
					mysql = mysql + " order by 1 ";

					rsSalesmanList = new DataSet();
					//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsSalesmanList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsSalesmanList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
					SqlDataAdapter adap_5 = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsSalesmanList.Tables.Clear();
					adap_5.Fill(rsSalesmanList);
				}
				else
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsSalesmanList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsSalesmanList.Requery(-1);
				}
			}

			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			if (grdVoucherDetails.Splits[0].DisplayColumns[mAnlyCode1Column].Visible || grdVoucherDetails.Splits[0].DisplayColumns[mAnlyCode2Column].Visible)
			{
				if (mFirstGridFocus)
				{
					mysql = "select anly_code , ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_anly_name as anly_name" : "a_anly_name as anly_name");
					mysql = mysql + " , anly_head_no ";
					mysql = mysql + " from gl_analysis ";
					mysql = mysql + " order by 1 ";

					rsAnlyCode = new DataSet();
					//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsAnlyCode.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsAnlyCode.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
					SqlDataAdapter adap_6 = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsAnlyCode.Tables.Clear();
					adap_6.Fill(rsAnlyCode);
				}
				else
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsAnlyCode.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsAnlyCode.Requery(-1);
				}
			}

			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			if (grdVoucherDetails.Splits[0].DisplayColumns[mProjectColumn].Visible)
			{
				if (mFirstGridFocus)
				{
					mysql = "select project_no, ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_project_name as project_name" : "a_project_name as project_name");
					mysql = mysql + " from PROJ_Projects ";
					mysql = mysql + " order by 1 ";

					rsProjectList = new DataSet();
					//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProjectList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsProjectList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
					SqlDataAdapter adap_7 = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsProjectList.Tables.Clear();
					adap_7.Fill(rsProjectList);
				}
				else
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsProjectList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsProjectList.Requery(-1);
				}
			}

			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			if (grdVoucherDetails.Splits[0].DisplayColumns[mCostCenterColumn].Visible)
			{
				if (mFirstGridFocus)
				{
					mysql = "select cost_no, ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cost_name as cost_name" : "a_cost_name as cost_name");
					mysql = mysql + " from gl_cost_centers ";
					mysql = mysql + " order by 1 ";

					rsCostCenterList = new DataSet();
					//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCostCenterList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsCostCenterList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
					SqlDataAdapter adap_8 = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsCostCenterList.Tables.Clear();
					adap_8.Fill(rsCostCenterList);
				}
				else
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsCostCenterList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsCostCenterList.Requery(-1);
				}
			}
		}

		private void txtVoucherDate_Change(Object Sender, EventArgs e)
		{
			if (!Information.IsDate(txtVoucherDate.Value))
			{
				return;
			}
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("On Error Goto Label (0)");
			if (this.Visible)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(rsGLVoucherTypes.Tables[0].Rows[0]["Show_Maturity_Date"]))
				{
					//UPGRADE_WARNING: (1068) txtVoucherDate.Value of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtMaturityDate.Value = ReflectionHelper.GetPrimitiveValue(txtVoucherDate.Value);
				}
			}
		}

		private void txtVoucherDate_Validating(Object eventSender, CancelEventArgs eventArgs)
		{
			bool Cancel = eventArgs.Cancel;
			try
			{
				if (Information.IsDate(txtVoucherDate.Value))
				{
					Cancel = !SystemProcedure2.ValidDateRange(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value));
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel;
			}
		}

		public void findRecord()
		{
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			string mysql = " mt.voucher_type = " + Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["voucher_type"]);

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["find_id"]), "", mysql, true, true));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;
			string mFilterCondition = "";
			string mAdditionalFromClause = "";

			DataSet withVar = null;
			switch(pObjectName)
			{
				case "txtCashLedgerCode" : 
					txtCashLedgerCode.Text = ""; 
					 
					withVar = rsGLVoucherTypes; 
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
					if (Convert.ToString(withVar.Tables[0].Rows[0]["Single_Entry_Type"]) == "D")
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (!SystemProcedure2.IsItEmpty(rsGLVoucherTypes.Tables[0].Rows[0]["credit_filter_condition"], SystemVariables.DataType.StringType))
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mFilterCondition = " (" + Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["credit_filter_condition"]) + ")";
						}
					}
					else
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (!SystemProcedure2.IsItEmpty(rsGLVoucherTypes.Tables[0].Rows[0]["debit_filter_condition"], SystemVariables.DataType.StringType))
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mFilterCondition = " (" + Convert.ToString(rsGLVoucherTypes.Tables[0].Rows[0]["debit_filter_condition"]) + ")";
						}
					} 
					 
					if (mFilterCondition == "")
					{
						mFilterCondition = " l.discontinued = 0 ";
					}
					else
					{
						mFilterCondition = mFilterCondition + " and l.discontinued = 0 ";
					} 
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
					{
						mAdditionalFromClause = " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
					}
					else
					{
						mAdditionalFromClause = "";
					} 
					//'' --------------------------------------------------------------------------------------------------------- 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFilterCondition, true, false, "", true, false, false, mAdditionalFromClause)); 
					 
					break;
				case "txtCostCenterCode" : 
					txtCostCenterCode.Text = ""; 
					 
					mFilterCondition = " show = 1 "; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000110, "882", mFilterCondition)); 
					break;
				case "txtBranchCode" : 
					txtBranchCode.Text = ""; 
					 
					mFilterCondition = " show = 1 "; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000117, "1806", mFilterCondition)); 
					break;
				case "txtFlex01" : 
					txtCostCenterCode.Text = ""; 
					 
					mFilterCondition = " l.show = 1 "; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "3,4", mFilterCondition)); 
					 
					break;
				default:
					return;
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				switch(pObjectName)
				{
					case "txtCashLedgerCode" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtCashLedgerCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)); 
						txtCashLedgerCode_Leave(txtCashLedgerCode, new EventArgs()); 
						break;
					case "txtCostCenterCode" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtCostCenterCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)); 
						txtCostCenterCode_Leave(txtCostCenterCode, new EventArgs()); 
						break;
					case "txtFlex01" : 
						if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
						{
							//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtFlex01.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtFlex01.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(2));
						} 
						break;
					case "txtBranchCode" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtBranchCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)); 
						txtBranchCode_Leave(txtBranchCode, new EventArgs()); 
						break;
				}
			}
		}

		private void AssignVoucherAdjustmentLineNumbers(string pDrCrType, int pOriginalLineNo, int pGridLineNo)
		{
			int Cnt = 0;

			int tempForEndVar = aAdjustedVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				if (pDrCrType == mDrTypeCaption)
				{
					if (Convert.ToDouble(aAdjustedVoucherDetails.GetValue(Cnt, conVLSourceLineNoColumn)) == pOriginalLineNo)
					{
						aAdjustedVoucherDetails.SetValue(pGridLineNo, Cnt, conVLLineNoColumn);
					}
				}
				else
				{
					if (Convert.ToDouble(aAdjustedVoucherDetails.GetValue(Cnt, conVLAgainstLineNoColumn)) == pOriginalLineNo)
					{
						aAdjustedVoucherDetails.SetValue(pGridLineNo, Cnt, conVLLineNoColumn);
					}
				}
			}
		}

		public void GetSourceTran()
		{
			string mysql = "";
			int mLinkedChildFormID = 0;

			SqlDataReader rsTempRec = null;

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				mysql = "select linked, linked_type, linked_entry_id, linked_module_id ";
				mysql = mysql + " from gl_accnt_trans ";
				mysql = mysql + " where entry_id = " + Conversion.Str(mSearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsTempRec = sqlCommand.ExecuteReader();
				if (rsTempRec.Read())
				{
					if (!Convert.IsDBNull(rsTempRec["linked_type"]))
					{
						SystemProcedure2.GetLinkedChildFormID(Convert.ToInt32(rsTempRec["linked_module_id"]), Convert.ToInt32(rsTempRec["linked_type"]), ref mLinkedChildFormID);
						if (mLinkedChildFormID == 0)
						{
							MessageBox.Show("Error: No information provided for the linked module!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							if (SystemForms.GetSystemForm(mLinkedChildFormID, 2, rsTempRec["linked_entry_id"], Convert.ToInt32(rsTempRec["linked_type"])))
							{
								//user has got access to the form
								//DoReportDrillDown = True
							}
							else
							{
								//access on the form is denied
								MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								//DoReportDrillDown = False
								//oReportGrid.SetFocus
							}
						}
					}
				}
				rsTempRec.Close();
			}

		}

		private void GetLedgerAmount1()
		{
			string mDrCrType = "";

			if (Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[mDebitAmountColumn].Value, "##############0.000")) > 0)
			{
				mDrCrType = mDrTypeCaption;
			}
			else
			{
				mDrCrType = mCrTypeCaption;
			}

			GetLedgerAmount(mDrCrType);

			grdVoucherDetails.UpdateData();
			CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), grdVoucherDetails.Col);

		}
		public bool VoidRecord()
		{
			CancelRecord();
			return false;
		}
		public bool CancelRecord()
		{
			bool result = false;
			string mysql = "";
			DialogResult ans = (DialogResult) 0;
			//Cancel the voucher
			try
			{


				if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
				{
					if (mOldVoucherStatus == SystemVariables.VoucherStatus.stPosted)
					{ //if voucher is in posted mode
						MessageBox.Show(SystemConstants.msg26 + SystemConstants.msg17, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
					}
					else if (mOldVoucherStatus == SystemVariables.VoucherStatus.stVoid)
					{  //if voucher is in deleted mode
						MessageBox.Show(SystemConstants.msg27 + SystemConstants.msg17, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
					}
					else if (mOldVoucherStatus == SystemVariables.VoucherStatus.stAutoGenerated)
					{  //if voucher is in deleted mode
						MessageBox.Show(SystemConstants.msg28 + SystemConstants.msg17, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
					}
					FirstFocusObject.Focus();
					return result;
				}

				ans = MessageBox.Show("Do you want to change the transaction status to void ?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (ans == System.Windows.Forms.DialogResult.No)
				{
					return false;
				}

				SystemVariables.gConn.BeginTransaction();

				mysql = " delete from gl_invoice_tracking ";
				mysql = mysql + " from gl_invoice_tracking IT ";
				mysql = mysql + " inner join gl_accnt_trans_details ATD on IT.source_line_no = ATD.line_no ";
				mysql = mysql + " inner join gl_accnt_trans AT on ATD.entry_id = AT.entry_id";
				mysql = mysql + " where AT.entry_id = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mysql = " delete from gl_invoice_tracking ";
				mysql = mysql + " from gl_invoice_tracking IT ";
				mysql = mysql + " inner join gl_accnt_trans_details ATD on IT.against_line_no = ATD.line_no ";
				mysql = mysql + " inner join gl_accnt_trans AT on ATD.entry_id = AT.entry_id";
				mysql = mysql + " where AT.entry_id = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				mysql = "delete from gl_accnt_trans_details ";
				mysql = mysql + " where entry_id = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				mysql = " update gl_accnt_trans ";
				mysql = mysql + " set status = 3 ";
				mysql = mysql + " where entry_id = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();


				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				AddRecord();
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Delete Record", SystemConstants.msg10);

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


			return result;
		}

		private void RecordNavidate(int pKeyCode, int pVoucherNo, int pVoucherType)
		{
			string mysql = "";

			if (pVoucherNo == 0 && pKeyCode == 37)
			{
				mysql = " select max(entry_id) from gl_accnt_trans ";
			}
			else if (pVoucherNo == 0 && pKeyCode == 39)
			{ 
				mysql = " select min(entry_id) from gl_accnt_trans ";
			}
			else
			{
				mysql = " select top 1 entry_id from gl_accnt_trans ";
			}
			mysql = mysql + " where 1=1 ";
			if (pVoucherNo > 0 && pKeyCode == 37)
			{
				mysql = mysql + " and voucher_no < " + pVoucherNo.ToString();
			}
			else if (pVoucherNo > 0 && pKeyCode == 39)
			{ 
				mysql = mysql + " and voucher_no > " + pVoucherNo.ToString();
			}

			if (txtBranchCode.Text != "")
			{
				mysql = mysql + " and Branch_cd = '" + txtBranchCode.Text + "'";
			}
			mysql = mysql + " and voucher_type =" + pVoucherType.ToString();

			if (pVoucherNo != 0)
			{
				if (pKeyCode == 37)
				{
					mysql = mysql + " order by cast(voucher_no as bigint) desc ";
				}
				else if (pKeyCode == 39)
				{ 
					mysql = mysql + " order by cast(voucher_no as bigint) asc ";
				}
			}

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				GetRecord(mReturnValue);
			}

		}

		private void FetchDetailsFromLdgrNoInGrid(string pLdgrNo, string pLdgrName)
		{

			grdVoucherDetails.Columns[mLedgerCodeColumn].Value = pLdgrNo;
			grdVoucherDetails.Columns[mLedgerNameColumn].Value = pLdgrName;

			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsLedgerCodeList.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsLedgerCodeList.MoveFirst();
			rsLedgerCodeList.Find(" ldgr_no='" + pLdgrNo + "'");
			if (rsLedgerCodeList.Tables[0].Rows.Count != 0)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerCodeList.Bookmark was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.Bookmark = rsLedgerCodeList.getBookmark();

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("voucher_adjustment")))
				{
					bool tempRefParam = false;
					DeleteCurrentLineAdjustment(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[mLineNoColumn].Value))), ref tempRefParam);
				}
				//-------------------------------------------------------------------
				cmbMastersList_RowChange(cmbMastersList, new EventArgs());
				grdVoucherDetails_AfterColUpdate(grdVoucherDetails, new C1.Win.C1TrueDBGrid.ColEventArgs());
			}
			else
			{
				grdVoucherDetails.Columns[mLedgerCodeColumn].Value = "";
				grdVoucherDetails.Columns[mLedgerNameColumn].Value = "";
			}

		}

		private bool IsDuplicateTransaction(int pVoucherNo, int pEntryId, int pVoucherType, int pFormatType, string pVoucherDate = "", string pBranchCode = "")
		{
			string mysql = "";

			if (pFormatType == 0)
			{
				mysql = " select voucher_no ";
				mysql = mysql + " from gl_accnt_trans with (tablockx) ";
				mysql = mysql + " where voucher_type = " + pVoucherType.ToString();
				mysql = mysql + " and voucher_no =" + pVoucherNo.ToString();
			}
			else if (pFormatType == 4)
			{ 
				mysql = " select voucher_no ";
				mysql = mysql + " from gl_accnt_trans with (tablockx) ";
				mysql = mysql + " where voucher_type = " + pVoucherType.ToString();
				mysql = mysql + " and branch_cd = '" + pBranchCode + "'";
				mysql = mysql + " and voucher_no =" + pVoucherNo.ToString();
			}

			if (pEntryId != 0)
			{
				mysql = mysql + " and entry_id <> " + pEntryId.ToString();
			}

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			return !Convert.IsDBNull(mReturnValue);
		}


		public bool UnPost()
		{
			bool result = false;
			string mysql = "";
			DialogResult ans = (DialogResult) 0;
			object mReturnValue = null;

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				ans = MessageBox.Show("Do you really want to unpost?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (ans == System.Windows.Forms.DialogResult.No)
				{
					return false;
				}


				mysql = " select status, linked, voucher_date ";
				mysql = mysql + " from gl_accnt_trans ";
				mysql = mysql + " where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//mysql = mysql & " and linked = 0 and status <> 4 "
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					if (!SystemProcedure2.ValidDateRange(ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue).GetValue(2))))
					{
						MessageBox.Show("Record cannot be unpost, the transaction does not belong to current financial year.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						goto mExit;
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((SystemVariables.VoucherStatus) ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0))) == SystemVariables.VoucherStatus.stAutoGenerated || ((TriState) ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1))) == TriState.True)
					{
						MessageBox.Show("Auto generated voucher cannot be unpost.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						goto mExit;
					}

					SystemVariables.gConn.BeginTransaction();

					mysql = " update gl_accnt_trans ";
					mysql = mysql + " set status = 1 ";
					mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();

					result = true;

				}
				else
				{
					result = false;
				}
			}
			else
			{
				goto mExit;
			}

			return true;

			mExit:
			return false;
		}

		public void ORoutine()
		{

			if (!UserAccess.AllowUserDisplay)
			{
				MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			mRecordNavigateSearchValue = Convert.ToInt32((txtVoucherNo.Text == "") ? ((object) 0) : ((object) txtVoucherNo.Text));
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			RecordNavidate(39, mRecordNavigateSearchValue, Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["voucher_type"]));
		}

		public void MRoutine()
		{

			if (!UserAccess.AllowUserDisplay)
			{
				MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			mRecordNavigateSearchValue = Convert.ToInt32((txtVoucherNo.Text == "") ? ((object) 0) : ((object) txtVoucherNo.Text));
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			RecordNavidate(37, mRecordNavigateSearchValue, Convert.ToInt32(rsGLVoucherTypes.Tables[0].Rows[0]["voucher_type"]));

		}

		private bool IsValidLdgrNo(string pLdgrNo, DataSet pRsLdgrRec)
		{
			bool result = false;
			if (SystemProcedure2.IsItEmpty(pLdgrNo, SystemVariables.DataType.StringType))
			{
				return true;
			}

			//UPGRADE_ISSUE: (2064) ADODB.Recordset method pRsLdgrRec.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			pRsLdgrRec.MoveFirst();
			pRsLdgrRec.Find("ldgr_no='" + pLdgrNo + "'");

			if (pRsLdgrRec.Tables[0].Rows.Count == 0)
			{
				result = false;
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method pRsLdgrRec.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				pRsLdgrRec.MoveFirst();
			}
			else
			{
				result = true;
			}
			return result;
		}

		private bool IsValidLedgerName(string pLdgrName, DataSet pRsLdgrRec)
		{

			bool result = false;
			if (SystemProcedure2.IsItEmpty(pLdgrName, SystemVariables.DataType.StringType))
			{
				return true;
			}

			//UPGRADE_ISSUE: (2064) ADODB.Recordset method pRsLdgrRec.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			pRsLdgrRec.MoveFirst();
			pRsLdgrRec.Find("ldgr_name='" + pLdgrName + "'");

			if (pRsLdgrRec.Tables[0].Rows.Count == 0)
			{
				result = false;
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method pRsLdgrRec.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				pRsLdgrRec.MoveFirst();
			}
			else
			{
				result = true;
			}
			return result;
		}

		private void GetExchangeRate(int pCurrencyCd)
		{

			string mSQL = "select curr_cd, exchange_rate from gl_currency where curr_cd = " + pCurrencyCd.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0)) != SystemGLConstants.gDefaultCurrencyCd)
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					grdVoucherDetails.Columns[mExchangeRateColumn].Text = (Convert.IsDBNull(((Array) mReturnValue).GetValue(1))) ? "" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				}
				else
				{
					grdVoucherDetails.Columns[mExchangeRateColumn].Text = "";
				}
			}

		}


		private void SearchLedgerNoInGrid(string pLedgerNo)
		{
			int Cnt = 0;
			int mStartFrom = 0;
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(grdVoucherDetails.Bookmark))
			{
				return;
			}
			else
			{
				mStartFrom = 0; //grdVoucherDetails.Bookmark
			}

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = mStartFrom + 1; Cnt <= tempForEndVar; Cnt++)
			{
				if (Convert.ToString(aVoucherDetails.GetValue(Cnt, mLedgerCodeColumn)) == pLedgerNo)
				{
					grdVoucherDetails.Bookmark = Cnt;
					break;
				}
			}

		}

		//added by Moiz Hakimi. Date: 14-jul-2008
		private void ImportExternalDataFromExcel(string pFileName)
		{
			try
			{

				clsImportExcelData clsImportExcel = null;
				int Cnt = 0;
				int mExcelRow = 0;
				string mysql = "";
				object mReturnValue = null;
				Excel.Workbook mBook = null;
				object mRng = null;

				int mColLedgerCode = 0;
				int mColLedgerName = 0;
				int mColSymbol = 0;
				int mColExchangeRate = 0;
				int mColFCAmount = 0;
				int mColLCAmount = 0;
				int mColDRCR = 0;
				int mColRemarks = 0;

				mColLedgerCode = 1;
				mColLedgerName = 2;
				mColSymbol = 3;
				mColExchangeRate = 4;
				mColFCAmount = 5;
				mColLCAmount = 6;
				mColDRCR = 7;
				mColRemarks = 8;
				clsImportExcel = new clsImportExcelData();
				clsImportExcel.GetDataFromFile(pFileName);

				mBook = clsImportExcel.ExcelWorkBookObject;
				mRng = ReflectionHelper.GetMember(ReflectionHelper.GetMember(mBook.ActiveSheet, "UsedRange"), "Rows");


				aVoucherDetails = new XArrayHelper();
				DefineVoucherArray(0, true);
				object tempForEndVar = ReflectionHelper.GetMember<object>(ReflectionHelper.GetMember(mRng, "Rows"), "Count");
				for (mExcelRow = 2; mExcelRow <= Convert.ToDouble(tempForEndVar); mExcelRow++)
				{
					if (!SystemProcedure2.IsItEmpty(ReflectionHelper.GetMember(ReflectionHelper.Invoke(mRng, "Cells", new object[]{mExcelRow, mColLedgerCode}), "Value"), SystemVariables.DataType.StringType))
					{
						mysql = " select ldgr_no ";
						if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
						{
							mysql = mysql + " , l_ldgr_name ";
						}
						else
						{
							mysql = mysql + " , a_ldgr_name ";
						}
						mysql = mysql + " from gl_ledger where ldgr_no ='" + ReflectionHelper.GetMember<string>(ReflectionHelper.Invoke(mRng, "Cells", new object[]{mExcelRow, mColLedgerCode}), "Value") + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						//    If IsNull(mReturnValue) Then
						//        GoTo mNext
						//    End If
						DefineVoucherArray(Cnt, false);
						aVoucherDetails.SetValue(Cnt + 1, Cnt, mLineNoColumn);

						//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue) && !Object.Equals(mReturnValue, null))
						{
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							if (grdVoucherDetails.Splits[0].DisplayColumns[mLedgerCodeColumn].Visible)
							{
								aVoucherDetails.SetValue(((Array) mReturnValue).GetValue(0), Cnt, mLedgerCodeColumn);
							}

							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							if (grdVoucherDetails.Splits[0].DisplayColumns[mLedgerNameColumn].Visible)
							{
								if (!SystemProcedure2.IsItEmpty(ReflectionHelper.GetMember(ReflectionHelper.Invoke(mRng, "Cells", new object[]{mExcelRow, mColLedgerName}), "Value"), SystemVariables.DataType.StringType))
								{
									aVoucherDetails.SetValue(ReflectionHelper.GetMember(ReflectionHelper.Invoke(mRng, "Cells", new object[]{mExcelRow, mColLedgerName}), "Value"), Cnt, mLedgerNameColumn);
								}
								else
								{
									aVoucherDetails.SetValue(((Array) mReturnValue).GetValue(1), Cnt, mLedgerNameColumn);
								}
							}
						}

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[mCurrencySymbolColumn].Visible)
						{
							aVoucherDetails.SetValue(ReflectionHelper.GetMember(ReflectionHelper.Invoke(mRng, "Cells", new object[]{mExcelRow, mColSymbol}), "Value"), Cnt, mCurrencySymbolColumn);
						}

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[mExchangeRateColumn].Visible)
						{
							aVoucherDetails.SetValue(ReflectionHelper.GetMember(ReflectionHelper.Invoke(mRng, "Cells", new object[]{mExcelRow, mColExchangeRate}), "Value"), Cnt, mExchangeRateColumn);
						}

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[mFCAmountColumn].Visible)
						{
							aVoucherDetails.SetValue(ReflectionHelper.GetMember(ReflectionHelper.Invoke(mRng, "Cells", new object[]{mExcelRow, mColFCAmount}), "Value"), Cnt, mFCAmountColumn);
						}

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[mLCAmountColumn].Visible)
						{
							aVoucherDetails.SetValue(ReflectionHelper.GetMember(ReflectionHelper.Invoke(mRng, "Cells", new object[]{mExcelRow, mColLCAmount}), "Value"), Cnt, mLCAmountColumn);
						}

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[mDrCrTypeColumn].Visible)
						{
							aVoucherDetails.SetValue(ReflectionHelper.GetMember(ReflectionHelper.Invoke(mRng, "Cells", new object[]{mExcelRow, mColDRCR}), "Value"), Cnt, mDrCrTypeColumn);
						}

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[mRemarksColumn].Visible)
						{
							aVoucherDetails.SetValue(ReflectionHelper.GetMember(ReflectionHelper.Invoke(mRng, "Cells", new object[]{mExcelRow, mColRemarks}), "Value"), Cnt, mRemarksColumn);
						}

						Cnt++;
					}

				}

				mBook.Close(false, Type.Missing, Type.Missing);
				mBook = null;
				mRng = null;
				clsImportExcel = null;

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Refresh();

				if (mFirstGridFocus)
				{
					grdVoucherDetails_GotFocus(grdVoucherDetails, new EventArgs());
				}
				CalculateTotals(0, 0);
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return;
			}
		}
		//---------------------------------------------------------------------------------------------------------
		//---------------------For Multiple crystal report print-----------------------------------------------
		//---------------------------------------------------------------------------------------------------------
		public object PrintGLCrystalReport(int pEntryId = 0, int pReportID = 0, decimal pVoucherAmount = 0, bool pPrintDirectly = false, string pPrinter = "", bool pShowPrinter = false)
		{
			string mysql = "";
			string mCurrSymbol = "";
			object mCrystalReportEntryIDColumnID = null;
			int mCrystalReportNumToCharColumnID = 0;
			object mReturnValue = null;

			int mEntryId = pEntryId;

			clsNumToCharArabic clsNumToCharArabic = null;
			if (pReportID != 0)
			{
				mysql = "select column_id from SM_REPORT_FIELDS ";
				mysql = mysql + " where report_id = " + pReportID.ToString();
				mysql = mysql + " and entry_id_column = 1 ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCrystalReportEntryIDColumnID = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql, true));

				mysql = "select column_id from SM_REPORT_FIELDS ";
				mysql = mysql + " where report_id = " + pReportID.ToString();
				mysql = mysql + " and linked_parameter_name = '@NumToChar'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql, true));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					mCrystalReportNumToCharColumnID = 0;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCrystalReportNumToCharColumnID = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				//'----------------------------------------------For Num To Char----------------
				mysql = " select gc.symbol ";
				mysql = mysql + " from gl_currency gc";
				mysql = mysql + " where gc.curr_cd = 1";

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCurrSymbol = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
				//'--------------------------------------------------------------------------------------
				if (mCrystalReportNumToCharColumnID == 0)
				{
					SystemReports.GetCrystalReport(pReportID, 2, Conversion.Str(mCrystalReportEntryIDColumnID), Conversion.Str(mEntryId), true, pPrintDirectly, pPrinter, pShowPrinter);
				}
				else
				{
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						SystemReports.GetCrystalReport(pReportID, 2, Conversion.Str(mCrystalReportEntryIDColumnID) + "," + mCrystalReportNumToCharColumnID.ToString().Trim(), mEntryId.ToString().Trim() + "," + SystemProcedure2.num_to_char(Conversion.Str(pVoucherAmount), mCurrSymbol), true, pPrintDirectly, pPrinter, pShowPrinter);
					}
					else
					{

						clsNumToCharArabic = new clsNumToCharArabic();
						SystemReports.GetCrystalReport(pReportID, 2, Conversion.Str(mCrystalReportEntryIDColumnID) + "," + mCrystalReportNumToCharColumnID.ToString().Trim(), mEntryId.ToString().Trim() + "," + clsNumToCharArabic.NumToCharArabic((double) pVoucherAmount), true, pPrintDirectly, pPrinter, pShowPrinter);
					}
				}
			}
			return null;
		}

		public void CreateStatusBar()
		{

			CommandBars.ActiveMenuBar.Visible = false;
			UCStatusBar = (XtremeCommandBars.StatusBar) CommandBars.StatusBar;

			UCStatusBar.Visible = true;


			XtremeCommandBars.StatusBarPane Pane = UCStatusBar.AddPane(SystemGLConstants.lcGroup1);
			Pane.Visible = true;
			Pane.Text = "Group :";
			Pane.SetPadding(8, 0, 8, 0);

			Pane = UCStatusBar.AddPane(SystemGLConstants.lcGroup2);
			Pane.Visible = true;
			Pane.Text = "";
			Pane.Width = 180;
			Pane.SetPadding(8, 0, 8, 0);

			Pane = UCStatusBar.AddPane(SystemGLConstants.lcCurrBal1);
			Pane.Visible = true;
			Pane.Text = "Current Balance :";
			Pane.SetPadding(8, 0, 8, 0);

			Pane = UCStatusBar.AddPane(SystemGLConstants.lcCurrBal2);
			Pane.Visible = true;
			Pane.Text = "";
			Pane.Width = 100;
			Pane.SetPadding(8, 0, 8, 0);

			Pane = UCStatusBar.AddPane(SystemGLConstants.lcDiffrence1);
			Pane.Visible = true;
			Pane.Text = "Difference :";
			Pane.TextColor = Convert.ToUInt32(ColorTranslator.ToOle(Color.Red));
			Pane.SetPadding(8, 0, 8, 0);

			Pane = UCStatusBar.AddPane(SystemGLConstants.lcDiffrence2);
			Pane.Visible = true;
			Pane.Text = "";
			Pane.Width = 120;
			Pane.TextColor = Convert.ToUInt32(ColorTranslator.ToOle(Color.Red));
			Pane.SetPadding(8, 0, 8, 0);

		}

		private void ClearStatusBar()
		{
			UCStatusBar.FindPane(SystemGLConstants.lcGroup2).Text = "";
			UCStatusBar.FindPane(SystemGLConstants.lcCurrBal2).Text = "";
			UCStatusBar.FindPane(SystemGLConstants.lcDiffrence2).Text = "";
		}

		public void ImportData()
		{

			frmICSBarcodeDataCollection mForm = frmICSBarcodeDataCollection.CreateInstance();

			mForm.CallerId = 2;
			//UPGRADE_WARNING: (7009) Multiple invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions More Information: https://docs.mobilize.net/vbuc/ewis#7009
			mForm.ShowDialog();

			if (mForm.mTabSelected == 2)
			{
				GetRecord(mForm.GLVoucherID, true);
			}
			else if (mForm.mTabSelected == 1)
			{ 
				ImportExternalDataFromExcel(mForm.Filename);
			}
			else
			{

				return;

			}

		}
	}
}