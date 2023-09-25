
using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class repParametersWindow
		: System.Windows.Forms.Form
	{

		public repParametersWindow()
{
InitializeComponent();
} 
 public  void repParametersWindow_old()
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


		private void repParametersWindow_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private int mReportId = 0;
		private int mLastButtonClicked = 0;
		private string mLostFocusSQL = "";
		private string mFindRoutineSQL = "";
		private int mFindID = 0;
		private string mFindReturnColumnNo = "";
		private string mFindWhereClause = "";
		private string mFindSecurityLedgerClause = "";

		private bool mCodeIsString = false;
		private string mVariablesSetSQL = "";
		private string mReportFromDate = "";
		private string mReportToDate = "";
		private string mReportTitleFilter = "";
		private string mParameterWindowCaption = "";
		private string mDefaultMasterValue = "";

		//Private Const mLocationFindID As Long = 2004000
		private int mLocationFindID = 0;
		private string mLocationFindReturnColumnNo = "";
		private string mLocationFindWhereClause = "";
		private string mLocationLostFocusSQL = "";
		private bool mLocationCodeIsString = false;
		private bool mLocationCodeIsMust = false;
		private bool mLocationFindIsChanged = false;
		private bool mMasterCodeIsMust = false;

		private object mMasterDetails = null;
		private object mLocationDetails = null;

		private SystemICSConstants.ShowOptions mPostOptionType = (SystemICSConstants.ShowOptions) 0;

		private const int mNormalHeight = 3900;
		private const int mAdvancedHeight = 7665;

		private const string mAdvancedCaption = "&Advance Mode >>";
		private const string mNormalCaption = "<< &Normal Mode";

		public int ReportID
		{
			set
			{
				mReportId = value;
			}
		}



		public string ParameterWindowCaption
		{
			set
			{
				mParameterWindowCaption = value;
			}
		}



		public string VariablesSetSQL
		{
			get
			{
				return mVariablesSetSQL;
			}
		}





		public string ReportFromDate
		{
			get
			{
				return mReportFromDate;
			}
			set
			{
				mReportFromDate = value;
				txtFromDate.Value = mReportFromDate;
			}
		}





		public string ReportToDate
		{
			get
			{
				return mReportToDate;
			}
			set
			{
				mReportToDate = value;
				txtToDate.Value = mReportToDate;
			}
		}



		public string ReportTitleFilter
		{
			get
			{
				return mReportTitleFilter;
			}
		}



		public int LastButtonClicked
		{
			get
			{
				return mLastButtonClicked;
			}
		}





		public string DefaultMasterValue
		{
			get
			{
				return mDefaultMasterValue;
			}
			set
			{
				mDefaultMasterValue = value;
				txtMasterCode.Text = mDefaultMasterValue;
			}
		}



		private void cmdPostMode_OKClick(Object Sender, EventArgs e)
		{

			if (mPostOptionType == SystemICSConstants.ShowOptions.optNormalMode)
			{
				mPostOptionType = SystemICSConstants.ShowOptions.optAdvancedMode;
			}
			else
			{
				mPostOptionType = SystemICSConstants.ShowOptions.optNormalMode;
			}

			Application.DoEvents();
			ShowHideAdvancedOptions(mPostOptionType);
		}


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			string mysql = "";
			object mReturnValue = null;
			int cnt = 0;
			this.Top = 67;
			this.Left = 33;
			//cntMainParameter.Redraw = False
			bool mPromptForLocationMasterOnly = false;
			lblMasterCode.Visible = true;
			txtMasterCode.Visible = true;
			txtMasterName.Visible = true;
			fraVoucherRange.Visible = false;
			lblVoucherRange.Visible = false;
			mLocationFindID = 2004000;
			mLocationFindReturnColumnNo = "82";
			mLocationFindWhereClause = "";
			mLocationLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name") + "  , locat_cd from SM_Location where locat_no = ";
			mLocationCodeIsString = false;
			mLocationCodeIsMust = true;
			mMasterCodeIsMust = true;
			mLocationFindIsChanged = false;
			txtFromDate.Value = DateTime.Parse("01-" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(DateTime.Today.Month) + "-" + Conversion.Str(DateTime.Today.Year));
			txtToDate.Value = DateTime.Today;
			//**--hide the advanced parameter options by default
			cmdPostMode.Visible = false;

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
			{
				lblCostCenterCode.Visible = true;
				txtCostCenterCode.Visible = true;
				txtDCostCenterName.Visible = true;
			}
			else
			{
				lblCostCenterCode.Visible = false;
				txtCostCenterCode.Visible = false;
				txtDCostCenterName.Visible = false;
			}


			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("project_costing")))
			{
				lblProjectCode.Visible = true;
				txtProjectCode.Visible = true;
				txtDProjectName.Visible = true;
			}
			else
			{
				lblProjectCode.Visible = false;
				txtProjectCode.Visible = false;
				txtDProjectName.Visible = false;
			}


			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_1")))
			{
				lblAnalysisCode1.Visible = true;
				txtAnalysisCode1.Visible = true;
				txtDAnalysisName1.Visible = true;
			}
			else
			{
				lblAnalysisCode1.Visible = false;
				txtAnalysisCode1.Visible = false;
				txtDAnalysisName1.Visible = false;
			}


			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_2")))
			{
				lblAnalysisCode2.Visible = true;
				txtAnalysisCode2.Visible = true;
				txtDAnalysisName2.Visible = true;
			}
			else
			{
				lblAnalysisCode2.Visible = false;
				txtAnalysisCode2.Visible = false;
				txtDAnalysisName2.Visible = false;
			}

			lblReportLevel.Visible = true;
			cmbReportLevel.Visible = true;
			lblGroupPrefix.Visible = true;
			txtGroupPrefix.Visible = true;
			lblGroupSuffix.Visible = true;
			txtGroupSuffix.Visible = true;
			lblTabSpaceInTree.Visible = true;
			txtTabSpaceInTree.Visible = true;
			chkShowCYCurrentBalance.Visible = false;
			chkShowCYOpeningBalance.Visible = false;
			chkShowCYProfitAndLoss.Visible = false;
			chkShowLedgerWithZeroBalance.Visible = false;
			chkShowLYCurrentBalance.Visible = false;
			chkShowLYOpeningBalance.Visible = false;
			chkShowLYProfitAndLoss.Visible = false;
			//**-----------------------------------------------------------
			ShowHideAdvancedOptions(SystemICSConstants.ShowOptions.optNormalMode);


			for (cnt = 1; cnt <= 7; cnt++)
			{
				cmbReportLevel.AddItem(cnt.ToString());
				cmbReportLevel.SetItemData(cmbReportLevel.NewIndex, cnt);
			}

			cmbReportLevel.ListIndex = SystemVariables.gDefaultFinalReportLevel - 1;



			switch(mReportId)
			{
				case 31001000 :  //**--Upload Data History 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 31002000 :  //**--Download Data History 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					//    Case 41001005                    '**-- Chart Of Accounts (New Format of Accounts) 
					//        lblMasterCode.Visible = False 
					//        txtMasterCode.Visible = False 
					//        txtMasterName.Visible = False 
					//        fraDateRange.Top = lblMasterCode.Top 
					//        lblDateRange.Top = lblMasterCode.Top - 110 
					 
					break;
				case 41001020 :  //**--Chart of Accounts (Date Wise) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 41001040 : case 41001041 : case 42005000 :  //Account Register 
					mFindID = 100; 
					mFindReturnColumnNo = "712"; 
					lblMasterCode.Caption = "Voucher Type"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Voucher_Name, Voucher_Type" : "A_Voucher_Name, Voucher_Type") + " from GL_Accnt_Voucher_Types where show =1 and Voucher_Type = "; 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					 
					break;
				case 41002000 : case 41002030 : case 54008007 :  //**--Statement of Accounts , Daily Summary 
					mFindID = 1001000; 
					mFindReturnColumnNo = "2"; 
					//'' --------------This code for ledger security ------ Moiz Hakimi----28-Oct-2008--------------------------- 
					 
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
					{
						mFindSecurityLedgerClause = " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
					} 
					 
					//''--------------------------------------------------------------------------------------------------------- 
					lblMasterCode.Caption = "Ledger Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name, ldgr_cd" : "a_ldgr_name, ldgr_cd") + " from gl_ledger where ldgr_no = "; 
					mCodeIsString = true; 
					 
					break;
				case 41002500 :  //**--Ledger Wise Analysis Summary 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					//''''''''''''' Comment by Moiz Hakimi--- 04-Feb-2010--------New Group By Structure has been created--------- 
					//        mFindID = 1001000 
					//        mFindReturnColumnNo = "2" 
					// 
					//        ''' --------------This code for ledger security ------ Moiz Hakimi----28-Oct-2008--------------------------- 
					//            If GetSystemPreferenceSetting("enable_Security_on_Ledger") = True Then 
					//            mFindSecurityLedgerClause = " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd " 
					//        End If 
					//        '''--------------------------------------------------------------------------------------------------------- 
					// 
					//        lblMasterCode.Caption = "Ledger Code" 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_ldgr_name, ldgr_cd", "a_ldgr_name, ldgr_cd") & " from gl_ledger where ldgr_no = " 
					//        mCodeIsString = True 
					 
					break;
				case 41002010 : 
					mFindID = 1001000; 
					mFindReturnColumnNo = "2"; 
					txtFromDate.Value = DateTime.Parse("01-" + DateTimeFormatInfo.CurrentInfo.GetMonthName(1).Trim() + "-" + Conversion.Str(DateTime.Today.Year)); 
					txtToDate.Value = DateTime.Parse("31-" + DateTimeFormatInfo.CurrentInfo.GetMonthName(12).Trim() + "-" + Conversion.Str(DateTime.Today.Year)); 
					//'' --------------This code for ledger security ------ Moiz Hakimi----28-Oct-2008--------------------------- 
					 
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
					{
						mFindSecurityLedgerClause = " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
					} 
					 
					//''--------------------------------------------------------------------------------------------------------- 
					lblMasterCode.Caption = "Ledger Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name, ldgr_cd" : "a_ldgr_name, ldgr_cd") + " from gl_ledger where ldgr_no = "; 
					mCodeIsString = true; 
					 
					break;
				case 41003000 : case 41002015 : case 110013000 : case 110013010 : case 43009070 : case 53006310 : case 53006320 : case 54006150 : case 1000001 : case 42009300 :  //**--Day Book , Statement of Account(Summary) , Realstate Advance Rent Report , Over due Report , list of outstanding Bills , Salesman Collection Report, Item Evalution By Supplier , sales report (Sales / SRtrn ) Without Location 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 42001000 :  //Cash Book 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 42001100 :  //Cost Center Wise Group Wise Report 
					txtMasterCode.NumericOnly = true; 
					mFindID = 1000110; 
					mFindReturnColumnNo = "882"; 
					lblMasterCode.Caption = "Cost Center "; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Cost_Name, cost_cd" : "a_Cost_Name, cost_cd") + " from gl_cost_centers where cost_no = "; 
					mCodeIsString = true; 
					 
					break;
				case 42001200 :  //Cost Center Statement Report 
					txtMasterCode.NumericOnly = true; 
					mFindID = 1000110; 
					mFindReturnColumnNo = "882"; 
					lblMasterCode.Caption = "Cost Center "; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Cost_Name, cost_cd" : "a_Cost_Name, cost_cd") + " from gl_cost_centers where cost_no = "; 
					mCodeIsString = true; 
					 
					break;
				case 42001201 :  //Cost Center Statement Report (Ledger Wise) 
					txtMasterCode.NumericOnly = true; 
					mFindID = 1000110; 
					mFindReturnColumnNo = "882"; 
					lblMasterCode.Caption = "Cost Center"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Cost_Name, cost_cd" : "a_Cost_Name, cost_cd") + " from gl_cost_centers where cost_no = "; 
					mCodeIsString = true; 
					txtLocationCode.Visible = true; 
					lblLocationCode.Visible = true; 
					txtLocationName.Visible = true; 
					lblLocationCode.Caption = "Ledger Code"; 
					mLocationFindID = 1001000; 
					mLocationFindReturnColumnNo = "2"; 
					//'' --------------This code for ledger security ------ Moiz Hakimi----28-Oct-2008--------------------------- 
					 
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
					{
						mFindSecurityLedgerClause = " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
					} 
					 
					//''--------------------------------------------------------------------------------------------------------- 
					mLocationLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name") + " , ldgr_cd from gl_ledger where ldgr_no = "; 
					mLocationCodeIsString = true; 
					mLocationFindIsChanged = true; 
					 
					break;
				case 42001300 :  //Cost Center Group Wise 
					txtMasterCode.NumericOnly = true; 
					mFindID = 1000110; 
					mFindReturnColumnNo = "882"; 
					lblMasterCode.Caption = "Cost Center "; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Cost_Name, cost_cd" : "a_Cost_Name, cost_cd") + " from gl_cost_centers where cost_no = "; 
					mCodeIsString = true; 
					 
					break;
				case 42001900 :  //Cost Center Profit and loss 
					txtMasterCode.NumericOnly = true; 
					mFindID = 1000110; 
					mFindReturnColumnNo = "882"; 
					lblMasterCode.Caption = "Cost Center "; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Cost_Name, cost_cd" : "a_Cost_Name, cost_cd") + " from gl_cost_centers where cost_no = "; 
					mCodeIsString = true; 
					 
					break;
				case 42002000 :  //Bank Book 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 42008000 :  //Cost Centre Catgory Report 
					mFindID = 1005000; 
					mFindReturnColumnNo = "959"; 
					lblMasterCode.Caption = "Category Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Cat_Name, Cat_Cd" : "A_Cat_Name, Cat_Cd") + " from gl_Cost_Category where Cat_No = "; 
					 
					break;
				case 42009600 :  //Project Wise Statement Report 
					txtMasterCode.NumericOnly = true; 
					mFindID = 1000130; 
					mFindReturnColumnNo = "985"; 
					lblMasterCode.Caption = "Project Wise"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Project_Name, project_cd" : "a_Project_Name, project_cd") + " from PROJ_Projects where project_no = "; 
					mCodeIsString = true; 
					 
					break;
				case 43002000 :  //Aged Receivable by Due Date 
					lblFromDate.Caption = "As on Date"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 42001400 :  //List of cost center 
					txtMasterCode.NumericOnly = true; 
					mFindID = 1000110; 
					mFindReturnColumnNo = "882"; 
					lblMasterCode.Caption = "Cost Center "; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Cost_Name, cost_cd" : "a_Cost_Name, cost_cd") + " from gl_cost_centers where cost_no = "; 
					mCodeIsString = true; 
					 
					break;
				case 43003000 :  //Aged Receivable by Voucher Date 
					lblFromDate.Caption = "As on Date"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 43004000 : case 43001000 : case 52020050 : case 43004100 : case 43004200 : case 43004300 :  //Over Due Summary  (Receivable) 
					lblFromDate.Caption = "As on Date"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 43005000 :  //Outstanding Receiable by Customer 
					mFindID = 1001000; 
					mFindReturnColumnNo = "2"; 
					mFindWhereClause = " type_cd = " + SystemGLConstants.gGLCustomerVendorTypeCode.ToString(); 
					//mFindWhereClause = mFindWhereClause & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" 
					lblToDate.Caption = "As on Date"; 
					lblFromDate.Visible = false; 
					txtFromDate.Visible = false; 
					//'' --------------This code for ledger security ------ Moiz Hakimi----28-Oct-2008--------------------------- 
					 
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
					{
						mFindSecurityLedgerClause = " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
					} 
					 
					//''--------------------------------------------------------------------------------------------------------- 
					lblMasterCode.Caption = "Ledger Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name, ldgr_cd" : "a_ldgr_name, ldgr_cd"); 
					mLostFocusSQL = mLostFocusSQL + " from gl_ledger where type_cd = " + SystemGLConstants.gGLCustomerVendorTypeCode.ToString(); 
					//mLostFocusSQL = mLostFocusSQL & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "')" 
					mLostFocusSQL = mLostFocusSQL + " and ldgr_no = "; 
					mCodeIsString = true; 
					 
					break;
				case 43009000 :  //Account Voucher Linking 
					mFindID = 1001000; 
					mFindReturnColumnNo = "2"; 
					//'' --------------This code for ledger security ------ Moiz Hakimi----28-Oct-2008--------------------------- 
					 
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
					{
						mFindSecurityLedgerClause = " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
					} 
					 
					//''--------------------------------------------------------------------------------------------------------- 
					lblMasterCode.Caption = "Ledger Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name, ldgr_cd" : "a_ldgr_name, ldgr_cd") + " from gl_ledger where ldgr_no = "; 
					mCodeIsString = true; 
					 
					break;
				case 43009050 :  //Salesman Wise Collection (Default) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 43009060 :  //Salesman Wise Collection (Actual) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 43009100 :  //Post Dated Cheque Receipt 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					fraVoucherRange.Visible = true; 
					//lblVoucherRange.Visible = True 
					fraVoucherRange.Top = lblMasterCode.Top; 
					//lblVoucherRange.Top = lblMasterCode 
					 
					break;
				case 43009200 :  //Post Dated Cheque 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					fraVoucherRange.Visible = true; 
					//lblVoucherRange.Visible = True 
					fraVoucherRange.Top = lblMasterCode.Top; 
					 
					break;
				case 43009300 : case 43009400 :  //Post Dated Cheque (Receipt Summary) , Post Dated Cheque (Payment Summary) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					fraVoucherRange.Visible = true; 
					//lblVoucherRange.Visible = True 
					fraVoucherRange.Top = lblMasterCode.Top; 
					 
					break;
				case 44001000 :  //trial balance report (hierarchical) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 44002000 :  //trading and profit & loss a/c report (hierarchical) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 44003000 :  //balance sheet report  (hierarchical) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 44003005 :  //balance sheet report (P normal) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 44004000 : case 44004010 :  //cash flow report 
					 
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
					{
						txtMasterCode.NumericOnly = true;
						mFindID = 1000110;
						mFindReturnColumnNo = "882";
						lblMasterCode.Caption = "Cost Center ";
						mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Cost_Name, cost_cd" : "a_Cost_Name, cost_cd") + " from gl_cost_centers where cost_no = ";
						mCodeIsString = false;
						mMasterCodeIsMust = false;
					}
					else
					{
						lblMasterCode.Visible = false;
						txtMasterCode.Visible = false;
						txtMasterName.Visible = false;
						fraDateRange.Top = lblMasterCode.Top;
						lblDateRange.Top = lblMasterCode.Top - 7;
					} 

					 
					break;
				case 45002000 :  //Aged Payable  by Due Date 
					lblFromDate.Caption = "As on Date"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 45003000 :  //Aged Payable by Voucher Date 
					lblFromDate.Caption = "As on Date"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 45004000 :  //Over Due Summary  (Payable) 
					lblFromDate.Caption = "As on Date"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 45005000 :  //Outstanding Payable by Supplier 
					mFindID = 1001000; 
					mFindReturnColumnNo = "2"; 
					mFindWhereClause = " type_cd = " + SystemGLConstants.gGLCustomerVendorTypeCode.ToString(); 
					//mFindWhereClause = mFindWhereClause & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" 
					lblFromDate.Caption = "As on Date"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					//'' --------------This code for ledger security ------ Moiz Hakimi----28-Oct-2008--------------------------- 
					 
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
					{
						mFindSecurityLedgerClause = " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
					} 
					 
					//''--------------------------------------------------------------------------------------------------------- 
					lblMasterCode.Caption = "Ledger Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name, ldgr_cd" : "a_ldgr_name, ldgr_cd"); 
					mLostFocusSQL = mLostFocusSQL + " from gl_ledger where type_cd = " + SystemGLConstants.gGLCustomerVendorTypeCode.ToString(); 
					//mLostFocusSQL = mLostFocusSQL & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "')" 
					mLostFocusSQL = mLostFocusSQL + " and ldgr_no = "; 
					mCodeIsString = true; 
					 
					break;
				case 51001025 :  //List of ICS_Item Group 
					lblDateRange.Visible = false; 
					fraDateRange.Visible = false; 
					lblLocationCode.Visible = false; 
					txtLocationCode.Visible = false; 
					txtLocationName.Visible = false; 
					lblMasterCode.Caption = "Group Code"; 
					mFindID = 2002000; 
					mFindReturnColumnNo = "40"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name, group_cd" : "l_group_name, group_cd") + " from ICS_Item_group where group_no = "; 
					 
					break;
				case 51001040 :  //List of ICS_Item  Category 
					lblDateRange.Visible = false; 
					fraDateRange.Visible = false; 
					lblLocationCode.Visible = false; 
					txtLocationCode.Visible = false; 
					txtLocationName.Visible = false; 
					lblMasterCode.Caption = "Category Code"; 
					mFindID = 2003000; 
					mFindReturnColumnNo = "47"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_Cat_name, cat_cd" : "l_Cat_name, Cat_cd") + " from ICS_Item_Category where Cat_no = "; 
					 
					break;
				case 51003000 : case 52020030 : case 52004200 : case 52006000 :  //Stock Ledger  Stock Ledger (Al Aqsa) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 51004000 : case 51004010 :  //Missing Voucher , Missing Voucher (Cash / Credit) 
					lblMasterCode.Caption = "Voucher Type"; 
					mFindID = 200; 
					mFindReturnColumnNo = "693"; 
					mFindWhereClause = " ivt.show =1"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Voucher_Name, Voucher_Type" : "A_Voucher_Name, Voucher_Type") + " from ICS_Transaction_Types where show =1 and Voucher_Type = "; 
					lblLocationCode.Visible = true; 
					txtLocationCode.Visible = true; 
					txtLocationName.Visible = true; 
					mCodeIsString = true; 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					 
					break;
				case 52001000 :  //Stock Report (Product Wise) 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					lblLocationCode.Visible = true; 
					txtLocationCode.Visible = true; 
					txtLocationName.Visible = true; 
					mCodeIsString = true; 
					mLocationCodeIsMust = false; 
					 
					break;
				case 52010070 : case 52005030 : case 52005040 :  //Expiry report 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 52002000 : case 54004025 :  //Stock Report (Group Wise) , Sales report (Group & Location Wise) 
					lblMasterCode.Caption = "Group Code"; 
					mFindID = 2002000; 
					mFindReturnColumnNo = "40"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name, group_cd" : "l_group_name, group_cd") + " from ICS_Item_group where group_no = "; 
					lblLocationCode.Visible = true; 
					txtLocationCode.Visible = true; 
					txtLocationName.Visible = true; 
					// . Date: 16/10/2007 Reason: To add report for inventory group wise summary 
					// ----------------------------------------------------------------------------------------- 
					 
					break;
				case 52002050 :  // Inventory Group Wise Summary 
					mPromptForLocationMasterOnly = true; 
					lblMasterCode.Caption = "Group Code"; 
					lblLocationCode.Visible = true; 
					txtLocationCode.Visible = true; 
					txtLocationName.Visible = true; 
					// ----------------------------------------------------------------------------------------- 
					 
					break;
				case 52003000 : case 54004030 : case 54004032 :  //Stock Report (Category Wise) , Sales report Category & Location Wise , Sale / SRtn report Cateroy & Location Wise 
					lblMasterCode.Caption = "Category Code"; 
					mFindID = 2003000; 
					mFindReturnColumnNo = "47"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cat_name, cat_cd" : "a_cat_name, cat_cd") + " from ICS_Item_Category where cat_no = "; 
					lblLocationCode.Visible = true; 
					txtLocationCode.Visible = true; 
					txtLocationName.Visible = true; 
					 
					break;
				//UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis#7001
				//case 54008007 : 
					//break;
				//UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis#7001
				//case 52004200 : 
					//break;
				//UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis#7001
				//case 52006000 : 
					//break;
				case 52004000 : case 52004100 : case 52020040 :  //Stock Report (Location Wise) , stock Ledger )Location Wise 
					mPromptForLocationMasterOnly = true; 
					//        lblMasterCode.Caption = "Location Code" 
					// 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					 
					break;
				case 52004005 : case 52020060 :  //Product Evaluation (Product Wise) 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mCodeIsString = true; 
					 
					break;
				case 52005010 :  //Linked Transaction Analysis 
					lblMasterCode.Caption = "Voucher Type"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Voucher_Name, Voucher_Type" : "A_Voucher_Name, Voucher_Type") + " from ICS_Transaction_Types where Voucher_Type = "; 
					mFindID = 200; 
					mFindReturnColumnNo = "693"; 
					lblLocationCode.Visible = true; 
					txtLocationCode.Visible = true; 
					txtLocationName.Visible = true; 
					fraDateRange.Visible = false; 
					lblDateRange.Visible = false; 
					lblVoucherRange.Left = lblDateRange.Left; 
					lblVoucherRange.Visible = true; 
					lblToVoucherNo.Visible = false; 
					txtToVoucherNo.Visible = false; 
					mCodeIsString = true; 
					lblFromVoucherNo.Caption = "Voucher No:"; 
					lblFromVoucherNo.Left = lblDateRange.Left; 
					fraVoucherRange.Left = fraDateRange.Left; 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					 
					break;
				case 52005020 :  //Item Ageing Report Analysis Report 
					lblFromDate.Caption = "As on Date"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 52005025 :  //Stock Ageing Report Analysis Report 
					lblFromDate.Caption = "As on Date"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 52008010 :  //Item Below Minimum Level Report 
					lblDateRange.Visible = false; 
					fraDateRange.Visible = false; 
					mPromptForLocationMasterOnly = true; 
					//        lblMasterCode.Caption = "Location Code" 
					// 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					// 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					 
					break;
				case 52008020 :  //Item Below Re-order Level Report 
					lblDateRange.Visible = false; 
					fraDateRange.Visible = false; 
					mPromptForLocationMasterOnly = true; 
					//        lblMasterCode.Caption = "Location Code" 
					// 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					// 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					 
					break;
				case 52008030 :  //Item Above Maximum Level Report 
					lblDateRange.Visible = false; 
					fraDateRange.Visible = false; 
					mPromptForLocationMasterOnly = true; 
					//        lblMasterCode.Caption = "Location Code" 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					// 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					 
					break;
				case 52010010 : case 52005050 : case 52005060 :  //Inventory Transaction (Voucher Type) 
					lblMasterCode.Caption = "Voucher Type"; 
					mFindID = 200; 
					mFindReturnColumnNo = "693"; 
					mFindWhereClause = " ivt.show =1"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Voucher_Name, Voucher_Type" : "A_Voucher_Name, Voucher_Type") + " from ICS_Transaction_Types where show =1 and Voucher_Type = "; 
					lblLocationCode.Visible = true; 
					txtLocationCode.Visible = true; 
					txtLocationName.Visible = true; 
					mCodeIsString = true; 
					fraVoucherRange.Visible = false; 
					lblVoucherRange.Visible = false; 
					 
					break;
				case 52010015 : case 52010012 :  //Inventory Transaction (Details Free Goods,Damage,Excess------etc), Inventory Transaction (Invoice Free Goods,Damage,Excess------etc) , item summary by party 
					lblMasterCode.Caption = "From Voucher Type"; 
					lblLocationCode.Caption = "To Voucher Type"; 
					mFindID = 200; 
					mFindReturnColumnNo = "693"; 
					mFindWhereClause = " ivt.show =1"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Voucher_Name, Voucher_Type" : "A_Voucher_Name, Voucher_Type") + " from ICS_Transaction_Types where show =1 and Voucher_Type = "; 
					lblLocationCode.Visible = true; 
					txtLocationCode.Visible = true; 
					txtLocationName.Visible = true; 
					mLocationFindID = 200; 
					mLocationFindReturnColumnNo = "693"; 
					mLocationFindWhereClause = "ivt.show =1"; 
					mCodeIsString = true; 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					mLocationLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Voucher_Name, Voucher_Type" : "A_Voucher_Name, Voucher_Type") + " from ICS_Transaction_Types where show =1 and Voucher_Type = "; 
					 
					break;
				case 52004008 : case 52010045 : case 52010060 : case 52010050 :  //Inventory Transaction (Details Free Goods,Damage,Excess------etc), Inventory Transaction (Invoice Free Goods,Damage,Excess------etc) , item summary by party 
					lblMasterCode.Caption = "Voucher Type"; 
					mFindID = 200; 
					mFindReturnColumnNo = "693"; 
					mFindWhereClause = " ivt.show =1"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Voucher_Name, Voucher_Type" : "A_Voucher_Name, Voucher_Type") + " from ICS_Transaction_Types where show =1 and Voucher_Type = "; 
					lblLocationCode.Visible = false; 
					txtLocationCode.Visible = false; 
					txtLocationName.Visible = false; 
					mCodeIsString = true; 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					 
					break;
				//UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis#7001
				//case 52010050 :  //Transaction Proces Details 
					//lblMasterCode.Caption = "Voucher Type"; 
					//mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Voucher_Name, Voucher_Type" : "A_Voucher_Name, Voucher_Type") + " from ICS_Transaction_Types where Voucher_Type = "; 
					//mFindID = 200; 
					//mFindReturnColumnNo = "693"; 
					//lblLocationCode.Visible = true; 
					//txtLocationCode.Visible = true; 
					//txtLocationName.Visible = true; 
					////fraDateRange.Visible = True 
					////lblDateRange.Visible = True 
					////lblVoucherRange.Left = lblDateRange.Left 
					////lblVoucherRange.Visible = True 
					////lblToVoucherNo.Visible = False 
					////txtToVoucherNo.Visible = False 
					////mCodeIsString = True 
					////lblFromVoucherNo.Caption = "Voucher No:" 
					////lblFromVoucherNo.Left = lblDateRange.Left 
					////fraVoucherRange.Left = fraDateRange.Left 
					////fraVoucherRange.Visible = True 
					////lblVoucherRange.Visible = True 
					// 
					//break;
				case 52010020 :  //Inventory Transaction (Location Wise) 
					mPromptForLocationMasterOnly = true; 
					// 
					//        lblMasterCode.Caption = "Location Code" 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					 
					break;
				case 52010030 :  //Inventory Transaction (Product Wise) 
					lblMasterCode.Caption = "Product Code"; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					lblLocationCode.Visible = true; 
					txtLocationCode.Visible = true; 
					txtLocationName.Visible = true; 
					mCodeIsString = true; 
					fraVoucherRange.Visible = false; 
					lblVoucherRange.Visible = false; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					 
					break;
				case 52010040 :  //Assembly Transaction Details 
					lblMasterCode.Caption = "Voucher Type"; 
					mFindID = 200; 
					mFindReturnColumnNo = "693"; 
					mFindWhereClause = " ivt.show =1 "; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Voucher_Name, Voucher_Type" : "A_Voucher_Name, Voucher_Type") + " from ICS_Transaction_Types where show =1 and Voucher_Type = "; 
					lblLocationCode.Visible = false; 
					txtLocationCode.Visible = false; 
					txtLocationName.Visible = false; 
					mCodeIsString = true; 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					 
					break;
				case 52020010 :  //Stock Variation Report 
					lblMasterCode.Caption = "Batch Code"; 
					mFindID = 2001010; 
					mFindReturnColumnNo = "1437"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_batch_Name, batch_cd" : "a_batch_Name, batch_cd") + " from ics_trans_batch where batch_no = "; 
					lblDateRange.Caption = " Physical Count Date "; 
					lblFromDate.Caption = "From Date"; 
					lblToDate.Caption = "To Date"; 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					lblVoucherRange.Caption = " Physical Count "; 
					lblFromVoucherNo.Caption = "From Tran. #"; 
					lblToVoucherNo.Caption = "To Tran. #"; 
					txtLocationCode.Visible = true; 
					lblLocationCode.Visible = true; 
					txtLocationName.Visible = true; 
					 
					break;
				case 52020011 :  //Stock Variation ICS_Item Wise 
					lblMasterCode.Caption = "Product Code"; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					lblLocationCode.Visible = true; 
					txtLocationCode.Visible = true; 
					txtLocationName.Visible = true; 
					//        lblLocationCode.Caption = "Location Code" 
					lblDateRange.Caption = " Date Information "; 
					lblVoucherRange.Caption = " Physical Count "; 
					lblFromDate.Caption = "Freeze Date"; 
					lblFromVoucherNo.Caption = "From Tran. #"; 
					lblToVoucherNo.Caption = "To Tran. #"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					mCodeIsString = true; 
					 
					break;
				case 52020013 :  //Freeze Stock List 
					mPromptForLocationMasterOnly = true; 
					lblDateRange.Caption = " Date Information "; 
					lblVoucherRange.Caption = " Physical Count "; 
					lblFromDate.Caption = "Freeze Date"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					fraVoucherRange.Visible = false; 
					lblVoucherRange.Visible = false; 
					//        lblMasterCode.Caption = "Location Code" 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					// 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					 
					break;
				case 52020015 :  //Serial Report ICS_Item Wise 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mFindWhereClause = " Serialized = 1 "; 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where serialized = 1 and part_no = "; 
					lblVoucherRange.Visible = true; 
					lblVoucherRange.Caption = " Serial No "; 
					lblFromVoucherNo.Caption = "From No. #"; 
					lblToVoucherNo.Caption = "To No. #"; 
					fraVoucherRange.Visible = true; 
					mCodeIsString = true; 
					lblDateRange.Visible = false; 
					fraDateRange.Visible = false; 
					 
					break;
				case 52020020 :  //Serial No. History (Product Wise) 
					txtFromVoucherNo.NumericOnly = true; 
					txtToVoucherNo.NumericOnly = true; 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where serialized = 1 and part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mFindWhereClause = " Serialized = 1 "; 
					lblVoucherRange.Visible = true; 
					lblVoucherRange.Caption = " ICS_Item Serial No."; 
					fraVoucherRange.Visible = true; 
					lblFromVoucherNo.Caption = "From Serial No. #"; 
					lblToVoucherNo.Caption = "To Serial No. #"; 
					mCodeIsString = true; 
					 
					break;
				case 52020025 :  //Warranty Period (Product Wise) 
					lblFromDate.Caption = "As on Date"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					txtFromVoucherNo.NumericOnly = true; 
					txtToVoucherNo.NumericOnly = true; 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where serialized = 1 and part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mFindWhereClause = " Serialized = 1 "; 
					lblVoucherRange.Visible = true; 
					lblVoucherRange.Caption = " ICS_Item Serial No."; 
					fraVoucherRange.Visible = true; 
					lblFromVoucherNo.Caption = "From Serial No. #"; 
					lblToVoucherNo.Caption = "To Serial No. #"; 
					mCodeIsString = true; 
					 
					break;
				case 52004010 : case 52020045 :  //List of ICS_Item (Location Wise) , list of ICS_Item (Location wise Barida) 
					lblDateRange.Visible = false; 
					fraDateRange.Visible = false; 
					mPromptForLocationMasterOnly = true; 
					//        lblMasterCode.Caption = "Location Code" 
					// 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					// 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					 
					break;
				case 52006010 :  //Assembly Transaction Details 
					lblMasterCode.Caption = "Parent Voucher"; 
					mFindID = 215; 
					mFindReturnColumnNo = "1803"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Voucher_Name, Voucher_Type" : "A_Voucher_Name, Voucher_Type") + " from ICS_Transaction_Types where show =1 and Voucher_Type = "; 
					lblLocationCode.Visible = false; 
					txtLocationCode.Visible = false; 
					txtLocationName.Visible = false; 
					mCodeIsString = true; 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					 
					break;
				case 53001001 :  //Purchase Report (Product Wise - Monthly) 
					lblDateRange.Visible = false; 
					fraDateRange.Visible = false; 
					lblMasterCode.Caption = "Product Code"; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					mCodeIsString = true; 
					 
					break;
				case 53002000 :  //Purchase Report (Groupt Wise) 
					lblDateRange.Visible = false; 
					fraDateRange.Visible = false; 
					lblMasterCode.Caption = "Group Code"; 
					mFindID = 2002000; 
					mFindReturnColumnNo = "40"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name, group_cd" : "a_group_name, group_cd") + " from ICS_Item_group where group_no = "; 
					 
					break;
				case 53003000 :  //Purchase Report (Catagory Wise) 
					lblDateRange.Visible = false; 
					fraDateRange.Visible = false; 
					lblMasterCode.Caption = "Category Code"; 
					mFindID = 2003000; 
					mFindReturnColumnNo = "47"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cat_name, cat_cd" : "a_cat_name, cat_cd") + " from ICS_Item_category where cat_no = "; 
					 
					break;
				case 53004010 :  //Purchase Report (Location -> ICS_Item Wise) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					//        mPromptForLocationMasterOnly = True 
					//        lblMasterCode.Caption = "Location Code" 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					// 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					 
					break;
				case 53004020 :  //Purchase Report (Location -> Supplier Wise) 
					mPromptForLocationMasterOnly = true; 
					// 
					//        lblMasterCode.Caption = "Location Code" 
					// 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					// 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					 
					break;
				case 53005010 :  //Monthly Purchase Report (Supplier Wise) 
					lblMasterCode.Caption = "Ledger Code"; 
					//'' --------------This code for ledger security ------ Moiz Hakimi----28-Oct-2008--------------------------- 
					 
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
					{
						mFindSecurityLedgerClause = " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
					} 
					 
					//''--------------------------------------------------------------------------------------------------------- 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name, ldgr_cd" : "a_ldgr_name, ldgr_cd"); 
					mLostFocusSQL = mLostFocusSQL + " from gl_ledger where type_cd = " + SystemGLConstants.gGLCustomerVendorTypeCode.ToString(); 
					//mLostFocusSQL = mLostFocusSQL & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "')" 
					mLostFocusSQL = mLostFocusSQL + " and ldgr_no = "; 
					mFindID = 1001000; 
					mFindReturnColumnNo = "2"; 
					mFindWhereClause = "type_cd = " + SystemGLConstants.gGLCustomerVendorTypeCode.ToString(); 
					//mFindWhereClause = mFindWhereClause & "or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" 
					fraDateRange.Visible = false; 
					lblDateRange.Visible = false; 
					fraVoucherRange.Visible = false; 
					lblVoucherRange.Visible = false; 
					mCodeIsString = true; 
					 
					break;
				case 53006000 : case 53006500 :  //Purchase Report(Date / Invoice Wise ) 
					mPromptForLocationMasterOnly = true; 
					// 
					//        lblMasterCode.Caption = "Location Code" 
					// 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					// 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					 
					break;
				case 53006100 :  //Comparative Purchase  Analysis 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 53006200 :  //Monthly Purchase Report 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 53006300 : case 51001150 : case 51001200 :  //Analysis by Supplier 
					lblDateRange.Visible = true; 
					fraDateRange.Visible = true; 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mCodeIsString = true; 
					 
					break;
				case 53006600 :  //**--Expenses & Charges Report 
					mFindID = 1001000; 
					mFindReturnColumnNo = "2"; 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					//'' --------------This code for ledger security ------ Moiz Hakimi----28-Oct-2008--------------------------- 
					 
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
					{
						mFindSecurityLedgerClause = " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
					} 
					 
					//''--------------------------------------------------------------------------------------------------------- 
					lblMasterCode.Caption = "Ledger Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name, ldgr_cd" : "a_ldgr_name, ldgr_cd") + " from gl_ledger where ldgr_no = "; 
					mCodeIsString = true; 
					 
					break;
				case 53007010 :  //Purchase Quotation (Product Wise) 
					lblDateRange.Visible = true; 
					fraDateRange.Visible = true; 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mCodeIsString = true; 
					 
					break;
				case 53007020 :  //Purchase Quotation(Date / Invoice Wise ) 
					mPromptForLocationMasterOnly = true; 
					//        lblMasterCode.Caption = "Location Code" 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					 
					break;
				case 53008010 :  //Purchase Order (Product Wise) 
					lblDateRange.Visible = true; 
					fraDateRange.Visible = true; 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mCodeIsString = true; 
					 
					break;
				case 53008020 :  //Purchase Order(Date / Invoice Wise ) 
					mPromptForLocationMasterOnly = true; 
					//        lblMasterCode.Caption = "Location Code" 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					// 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					 
					break;
				case 53009010 :  //Received of Goods (Product Wise) 
					lblDateRange.Visible = true; 
					fraDateRange.Visible = true; 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mCodeIsString = true; 
					 
					break;
				case 53009020 :  //Received of Goods(Date / Invoice Wise ) 
					mPromptForLocationMasterOnly = true; 
					//        lblMasterCode.Caption = "Location Code" 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					// 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					 
					break;
				case 53001010 :  //Purchase Return (Product Wise) 
					lblDateRange.Visible = true; 
					fraDateRange.Visible = true; 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mCodeIsString = true; 
					 
					break;
				case 53001020 :  //Purchase Return(Date / Invoice Wise ) 
					mPromptForLocationMasterOnly = true; 
					//        lblMasterCode.Caption = "Location Code" 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					// 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					 
					break;
				case 54000100 :  //Sales Price List (Customer Wise) 
					lblMasterCode.Caption = "Ledger Code"; 
					//'' --------------This code for ledger security ------ Moiz Hakimi----28-Oct-2008--------------------------- 
					 
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
					{
						mFindSecurityLedgerClause = " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
					} 
					 
					//''--------------------------------------------------------------------------------------------------------- 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name, ldgr_cd" : "a_ldgr_name, ldgr_cd"); 
					mLostFocusSQL = mLostFocusSQL + " from gl_ledger where (type_cd = " + SystemGLConstants.gGLCustomerVendorTypeCode.ToString() + ")"; 
					mLostFocusSQL = mLostFocusSQL + " and ldgr_no = "; 
					mFindID = 1001000; 
					mFindReturnColumnNo = "2"; 
					mFindWhereClause = " type_cd = " + SystemGLConstants.gGLCustomerVendorTypeCode.ToString(); 
					fraDateRange.Visible = false; 
					lblDateRange.Visible = false; 
					fraVoucherRange.Visible = false; 
					lblVoucherRange.Visible = false; 
					mCodeIsString = true; 
					 
					break;
				case 54001001 : case 54000010 :  //Sales Report (Product Wise - Monthly) 
					lblDateRange.Visible = false; 
					fraDateRange.Visible = false; 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mCodeIsString = true; 
					 
					break;
				case 54002100 : case 54001100 : case 54103000 : case 53009030 : case 54103100 : case 53002100 :  //Sales Report (Group Wise) , Sales Return , Receipt Report Group Wise , Sales Return  group wise , Purchase Return (Group Wise) 
					lblDateRange.Visible = true; 
					fraDateRange.Visible = true; 
					lblMasterCode.Caption = "Group Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name, group_cd" : "a_group_name, group_cd") + " from ICS_Item_group where group_no = "; 
					mFindID = 2002000; 
					mFindReturnColumnNo = "40"; 
					 
					break;
				case 54003000 :  //Sales Report (Category Wise) 
					lblDateRange.Visible = false; 
					fraDateRange.Visible = false; 
					lblMasterCode.Caption = "Category Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cat_name, cat_cd" : "a_cat_name, cat_cd") + " from ICS_Item_category where cat_no = "; 
					mFindID = 2003000; 
					mFindReturnColumnNo = "47"; 
					 
					break;
				case 54003100 : case 54104000 : case 53009040 : case 53003100 :  //Sales Report (Category Wise), Sales Return Report (Category Wise), Receipt of Goods (Category Wise) , Purchase Report (Category Wise) 
					lblDateRange.Visible = true; 
					fraDateRange.Visible = true; 
					lblMasterCode.Caption = "Category Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cat_name, cat_cd" : "a_cat_name, cat_cd") + " from ICS_Item_category where cat_no = "; 
					mFindID = 2003000; 
					mFindReturnColumnNo = "47"; 
					 
					break;
				case 54004010 :  //Sales Report (Location -> ICS_Item Wise) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					//        mPromptForLocationMasterOnly = True 
					//        lblMasterCode.Caption = "Location Code" 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					// 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					 
					break;
				case 54004020 :  //Sales Report (Location -> Customer Wise) 
					mPromptForLocationMasterOnly = true; 
					//        lblMasterCode.Caption = "Location Code" 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					// 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					 
					break;
				case 54005010 : case 54000020 :  //Monthly Sales Report (Customer Wise)  , Monthly Sales / Sales Return Report (Customer Wise) 
					lblMasterCode.Caption = "Ledger Code"; 
					//'' --------------This code for ledger security ------ Moiz Hakimi----28-Oct-2008--------------------------- 
					 
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
					{
						mFindSecurityLedgerClause = " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
					} 
					 
					//''--------------------------------------------------------------------------------------------------------- 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name, ldgr_cd" : "a_ldgr_name, ldgr_cd"); 
					mLostFocusSQL = mLostFocusSQL + " from gl_ledger where type_cd = " + SystemGLConstants.gGLCustomerVendorTypeCode.ToString(); 
					//mLostFocusSQL = mLostFocusSQL & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "')" 
					mLostFocusSQL = mLostFocusSQL + " and ldgr_no = "; 
					mFindID = 1001000; 
					mFindReturnColumnNo = "2"; 
					mFindWhereClause = " type_cd = " + SystemGLConstants.gGLCustomerVendorTypeCode.ToString(); 
					//mFindWhereClause = mFindWhereClause & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" 
					fraDateRange.Visible = false; 
					lblDateRange.Visible = false; 
					fraVoucherRange.Visible = false; 
					lblVoucherRange.Visible = false; 
					mCodeIsString = true; 
					 
					break;
				case 54006000 : case 54102000 : case 54202000 : case 54302000 : case 54402000 : case 54502000 : case 54602000 : case 54006100 : case 54006200 : case 54006160 : case 54006010 : case 54004028 :  //Sales Report (Date / Invoice Wise ) - , Day Summary 
					mPromptForLocationMasterOnly = true; 
					//        lblMasterCode.Caption = "Location Code" 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					// 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					 
					break;
				case 54006190 : case 54006220 : 
					lblDateRange.Visible = true; 
					fraDateRange.Visible = true; 
					lblMasterCode.Caption = "Salesman Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_sman_name, sman_cd" : "a_sman_name, sman_cd") + " from SM_Salesman where sman_no = "; 
					mFindID = 1004000; 
					mFindReturnColumnNo = "88"; 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					//Added by Moiz Hakimi. Date: 27/7/2009 Reason: To add report for ICS_Item salesman 
					//------------------------------------------------------------- 
					 
					break;
				case 54008008 : case 52004150 : 
					lblDateRange.Visible = true; 
					fraDateRange.Visible = true; 
					lblMasterCode.Caption = "Salesman Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_sman_name, sman_cd" : "a_sman_name, sman_cd") + " from SM_Salesman where sman_no = "; 
					mFindID = 1004000; 
					mFindReturnColumnNo = "88"; 
					//Added by Rizwan. Date: 6/9/2007 & 10/9/2007 Reason: To add two reports for ICS_Item Supplier, Group Wise Summary and Customer Wise Sales Summary 
					//------------------------------------------------------------- 
					 
					break;
				case 54006207 : case 54006210 : case 54006230 : case 52010055 :  //Product Supplier Wise Summary, Group Wise Summary and Customer Wise Sales Summary 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					//------------------------------------------------------------ 
					 
					break;
				case 54007011 : case 54006600 :  //Sales Report (Salesman Wise - Monthly) 
					lblDateRange.Visible = false; 
					fraDateRange.Visible = false; 
					lblMasterCode.Caption = "Salesman Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_sman_name, sman_cd" : "a_sman_name, sman_cd") + " from SM_Salesman where sman_no = "; 
					mFindID = 1004000; 
					mFindReturnColumnNo = "88"; 
					 
					break;
				case 54007020 : case 54006170 : case 54006180 : case 54007025 : case 54008009 :  //Sales Report (Salesman Summary) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 54007040 :  //Sales Report (Customer Wise Summary) 
					lblDateRange.Visible = false; 
					fraDateRange.Visible = false; 
					lblMasterCode.Caption = "Salesman Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_sman_name, sman_cd" : "a_sman_name, sman_cd") + " from SM_Salesman where sman_no = "; 
					mFindID = 1004000; 
					mFindReturnColumnNo = "88"; 
					 
					break;
				case 54008005 : case 54105000 : case 54008001 :  //Monthly Sales Report , Monthly Sales Return Report , Monthly Net Sales Report 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					//Added by Rizwan. Date: 7/9/2007 Reason: To add report for Most Common Returns 
					//------------------------------------------------------------- 
					 
					break;
				case 54105005 :  //Most Common Returns Report 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					//------------------------------------------------------------ 
					 
					break;
				case 54008010 :  //Comparative Sales  Analysis 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 54008020 :  //Inventory Profitability Report 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 54008030 :  //Fast Moving Item 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 54008040 :  //Slow Moving Item 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 54009010 :  //Assembly Transaction Details 
					lblDateRange.Visible = true; 
					fraDateRange.Visible = true; 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mCodeIsString = true; 
					 
					break;
				case 54009020 : 
					mPromptForLocationMasterOnly = true; 
					//        lblMasterCode.Caption = "Location Code" 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_locat_name, locat_cd", "a_locat_name, locat_cd") & " from SM_Location where locat_no = " 
					// 
					//        mFindID = 2004000 
					//        mFindReturnColumnNo = "82" 
					fraVoucherRange.Visible = true; 
					lblVoucherRange.Visible = true; 
					 
					break;
				case 54101000 :  // sales return (product wise) 
					lblDateRange.Visible = true; 
					fraDateRange.Visible = true; 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mCodeIsString = true; 
					 
					break;
				case 54201000 :  // delivery notes (product wise) 
					lblDateRange.Visible = true; 
					fraDateRange.Visible = true; 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mCodeIsString = true; 
					 
					break;
				case 54301000 :  // stock return (product wise) 
					lblDateRange.Visible = true; 
					fraDateRange.Visible = true; 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mCodeIsString = true; 
					 
					break;
				case 54401000 :  // sales order (product wise) 
					lblDateRange.Visible = true; 
					fraDateRange.Visible = true; 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mCodeIsString = true; 
					 
					break;
				case 54501000 :  // sales quotation (product wise) 
					lblDateRange.Visible = true; 
					fraDateRange.Visible = true; 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mCodeIsString = true; 
					 
					break;
				case 54601000 :  // advanced sales booking (product wise) 
					lblDateRange.Visible = true; 
					fraDateRange.Visible = true; 
					lblMasterCode.Caption = "Product Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name, prod_cd" : "a_prod_name, prod_cd") + " from ICS_Item where part_no = "; 
					mFindID = 2001000; 
					mFindReturnColumnNo = "28"; 
					mCodeIsString = true; 
					 
					break;
				case 64001000 : case 64001100 :  //Monthly Payroll Report 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 64001500 : case 64001600 : case 64001650 : case 65009200 : case 65009250 : case 65092420 :  //Payroll sheet , Employee Payroll Sheet, Payroll Report, Penalty Report 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					mysql = " select generate_date "; 
					mysql = mysql + " from pay_payroll_generate_history "; 
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql)); 
					 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mReturnValue))
					{
						txtFromDate.Value = ReflectionHelper.GetPrimitiveValue<System.DateTime>(mReturnValue);
						txtToDate.Value = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate());
					} 

					 
					break;
				case 64001700 : case 110120000 : case 65092300 : case 110113583 : case 110112110 :  // Expire Document Details , Check Project Allocation ,Project Rate, Project Group 
					lblFromDate.Caption = "As on Date"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				//UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis#7001
				//case 65092300 :  //Indeminity 
					//lblFromDate.Caption = "For the month :"; 
					//lblToDate.Visible = false; 
					//txtToDate.Visible = false; 
					//lblMasterCode.Visible = false; 
					//txtMasterCode.Visible = false; 
					//txtMasterName.Visible = false; 
					//fraDateRange.Top = lblMasterCode.Top; 
					//lblDateRange.Top = lblMasterCode.Top - 7; 
					// 
					//break;
				case 54602010 :  //**--Allocated stock (Product Wise) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 110121250 : 
					lblFromDate.Caption = "From Date"; 
					lblToDate.Caption = "To Date"; 
					lblToDate.Visible = true; 
					txtToDate.Visible = true; 
					lblMasterCode.Visible = true; 
					lblMasterCode.Caption = "Attendance Type"; 
					txtMasterCode.Visible = true; 
					txtMasterName.Visible = true; 
					lblLocationCode.Visible = true; 
					lblLocationCode.Caption = "Employee Code"; 
					txtLocationCode.Visible = true; 
					txtLocationName.Visible = true; 
					mFindID = 7220565; 
					mFindReturnColumnNo = "2599"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_field_name,ta_field_id" : "a_field_name,ta_field_id") + " from pay_ta_field where ta_field_id = "; 
					mCodeIsString = true; 
					mMasterCodeIsMust = false; 
					mLocationFindID = 7050000; 
					mLocationFindReturnColumnNo = "831"; 
					mLocationLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_full_name,emp_no" : "a_full_name,emp_no") + " from pay_employee where emp_no ="; 
					mLocationCodeIsString = true; 
					mLocationCodeIsMust = false; 
					 
					break;
				case 65003000 : case 110013220 :  //Leave Balance Report 
					lblFromDate.Caption = "As on Date"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					lblMasterCode.Visible = true; 
					lblMasterCode.Caption = "Leave Type"; 
					txtMasterCode.Visible = true; 
					txtMasterName.Visible = true; 
					lblLocationCode.Visible = true; 
					lblLocationCode.Caption = "Employee Code"; 
					txtLocationCode.Visible = true; 
					txtLocationName.Visible = true; 
					mFindID = 7220000; 
					mFindReturnColumnNo = "1918"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_type_name,type_cd" : "a_type_name,type_cd") + " from pay_leave_type where show =1 and type_cd = "; 
					mCodeIsString = true; 
					mMasterCodeIsMust = false; 
					mLocationFindID = 7050000; 
					mLocationFindReturnColumnNo = "831"; 
					mLocationLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_full_name,emp_no" : "a_full_name,emp_no") + " from pay_employee where emp_no ="; 
					mLocationCodeIsString = true; 
					mLocationCodeIsMust = false; 
					 
					break;
				case 64001640 : 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					txtFromDate.Value = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()); 
					txtToDate.Value = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()); 
					 
					break;
				case 65003050 :  //Training Report 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					txtFromDate.Value = DateAndTime.DateSerial(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Year, 1, 1); 
					txtToDate.Value = DateTime.Today; 
					 
					break;
				case 65002000 :  //Salary Variation Report 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					txtFromDate.Value = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()); 
					txtToDate.Value = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()); 
					 
					break;
				case 65003060 :  //Training Monthly Report 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					//    Case 65004000          ' Fixed allowance & Deduction Report 
					//        fraDateRange.Visible = False 
					//        lblDateRange.Visible = False 
					// 
					//        lblMasterCode.Caption = "Employee Code" 
					//        mLostFocusSQL = " select " & IIf(gPreferedLanguage = English, "l_first_name, emp_cd", "a_first_name, emp_cd") & " from pay_employee where emp_no = " 
					// 
					//        mFindID = 7050000 
					//        mFindReturnColumnNo = "831" 
					// 
					//        mCodeIsString = True 
					 
					break;
				case 65005000 :  //Leave Balance Report 
					mFindID = 7220000; 
					mFindReturnColumnNo = "1918"; 
					lblFromDate.Caption = "As on Date"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					//        lblMasterCode.Visible = False 
					//        txtMasterCode.Visible = False 
					//        txtMasterName.Visible = False 
					//fraDateRange.Top = lblMasterCode.Top 
					//lblDateRange.Top = lblMasterCode.Top - 110 
					lblMasterCode.Caption = "Leave Type"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_type_name, type_cd" : "a_type_name, type_cd"); 
					mLostFocusSQL = mLostFocusSQL + " from pay_leave_type where "; 
					mLostFocusSQL = mLostFocusSQL + " type_cd = "; 
					mCodeIsString = false; 
					 
					break;
				case 120000001 : 
					//lblFromDate.Caption = "As on Date" 
					mFindID = 1000020; 
					mFindReturnColumnNo = "711"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					lblFromDate.Visible = false; 
					txtFromDate.Visible = false; 
					fraDateRange.Visible = false; 
					lblDateRange.Visible = false; 
					lblMasterCode.Caption = "Group Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Group_Name, Group_Cd" : "a_Group_Name, Group_Cd"); 
					mLostFocusSQL = mLostFocusSQL + " from SM_USER_GROUPS where "; 
					mLostFocusSQL = mLostFocusSQL + " Group_Cd = "; 
					mCodeIsString = false; 
					 
					break;
				case 65092360 :  //Attendance Sheet 
					mFindID = 7050000; 
					mFindReturnColumnNo = "831"; 
					lblFromDate.Caption = "For The Month"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					//        lblMasterCode.Visible = False 
					//        txtMasterCode.Visible = False 
					//        txtMasterName.Visible = False 
					//fraDateRange.Top = lblMasterCode.Top 
					//lblDateRange.Top = lblMasterCode.Top - 110 
					lblMasterCode.Caption = "Employee No"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_full_name, emp_no" : "a_full_name, emp_no"); 
					mLostFocusSQL = mLostFocusSQL + " from pay_employee where "; 
					mLostFocusSQL = mLostFocusSQL + " emp_no = "; 
					mCodeIsString = false; 
					 
					break;
				case 65005500 : case 110013620 : case 110121290 :  //Indemnity  Report and leve transaction report 
					lblFromDate.Caption = "As on Date"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 91001000 :  //Fixed Asset Register 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					//fraVoucherRange.Visible = True 
					//lblVoucherRange.Visible = True 
					//fraVoucherRange.Top = lblMasterCode.Top 
					 
					break;
				case 91002000 :  //Assets History 
					txtMasterCode.NumericOnly = true; 
					lblDateRange.Visible = false; 
					fraDateRange.Visible = false; 
					mFindID = 8004000; 
					mFindReturnColumnNo = "1137"; 
					lblMasterCode.Caption = "Asset No"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_asset_name, Asset_Cd" : "a_asset_name, Asset_Cd") + " from fa_items where asset_no = "; 
					mCodeIsString = true; 
					 
					break;
				case 91005000 :  //Category Wise Depreciation Details 
					lblFromDate.Caption = "As on Date"; 
					lblToDate.Visible = false; 
					txtToDate.Visible = false; 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 110013560 :  //Transfer n Promotion Report 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 110012000 : case 110013060 :  //**--List of Contracts 
					lblFromDate.Caption = "Starting Date"; 
					lblToDate.Caption = "Ending Date"; 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					txtFromDate.Value = DateTime.Parse("01-" + DateTimeFormatInfo.CurrentInfo.GetMonthName(1).Trim() + "-" + Conversion.Str(DateTime.Today.Year)); 
					txtToDate.Value = DateTime.Parse("31-" + DateTimeFormatInfo.CurrentInfo.GetMonthName(12).Trim() + "-" + Conversion.Str(DateTime.Today.Year)); 
					 
					break;
				case 110013020 :  //**--Tenant Statement of Account 
					mFindID = 9010000; 
					mFindReturnColumnNo = "1365"; 
					lblMasterCode.Caption = "Tenant Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_tenant_name, tenant_Cd" : "a_tenant_name, tenant_Cd") + " from RE_Tenant where Tenant_No = "; 
					mCodeIsString = true; 
					 
					break;
				case 110013030 :  //**--Property Statement of Account 
					mFindID = 9001000; 
					mFindReturnColumnNo = "1323"; 
					lblMasterCode.Caption = "Property Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Property_Name, Property_Cd" : "a_Property_Name, Property_Cd") + " from RE_Property where Property_No = "; 
					mCodeIsString = true; 
					 
					break;
				case 110013040 :  //**--Collection Report (Date Wise) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					 
					break;
				case 42004000 : case 42006500 :  //Group Summary 
					mFindID = 1002000; 
					mFindReturnColumnNo = "15"; 
					lblMasterCode.Caption = "Group Code"; 
					mLostFocusSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name, group_cd" : "a_group_name, group_cd") + " from gl_accnt_group where group_level <> 0 and group_no = "; 
					mCodeIsString = true; 
					//**--newly added parameters 
					//**--modified by: Moiz Hakimi 
					//**--modified on: 23-dec-2005 
					cmdPostMode.Visible = true; 
					chkShowCYCurrentBalance.Visible = true; 
					chkShowCYOpeningBalance.Visible = true; 
					chkShowLedgerWithZeroBalance.Visible = true; 
					txtGroupPrefix.Text = "["; 
					txtGroupSuffix.Text = "]"; 
					txtTabSpaceInTree.Value = 10; 
					chkShowCYOpeningBalance.CheckState = CheckState.Checked; 
					chkShowCYCurrentBalance.CheckState = CheckState.Checked; 
					chkShowLedgerWithZeroBalance.CheckState = CheckState.Unchecked; 
					//**------------------------------------------------------------------------ 
					 
					break;
				case 44001001 :  //trial balance report (normal) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					//**--newly added parameters 
					//**--modified by: Moiz Hakimi 
					//**--modified on: 23-dec-2005 
					cmdPostMode.Visible = true; 
					chkShowCYCurrentBalance.Visible = true; 
					chkShowCYOpeningBalance.Visible = true; 
					chkShowLedgerWithZeroBalance.Visible = true; 
					txtGroupPrefix.Text = "["; 
					txtGroupSuffix.Text = "]"; 
					txtTabSpaceInTree.Value = 10; 
					chkShowCYOpeningBalance.CheckState = CheckState.Checked; 
					chkShowCYCurrentBalance.CheckState = CheckState.Checked; 
					chkShowLedgerWithZeroBalance.CheckState = CheckState.Unchecked; 
					//**------------------------------------------------------------------------ 
					 
					break;
				case 44002001 :  //trading and profit & loss a/c report (normal) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					//**--newly added parameters 
					//**--modified by: Moiz Hakimi 
					//**--modified on: 23-dec-2005 
					cmdPostMode.Visible = true; 
					chkShowCYCurrentBalance.Visible = true; 
					chkShowCYOpeningBalance.Visible = true; 
					chkShowLedgerWithZeroBalance.Visible = true; 
					chkShowCYProfitAndLoss.Visible = true; 
					txtGroupPrefix.Text = "["; 
					txtGroupSuffix.Text = "]"; 
					txtTabSpaceInTree.Value = 10; 
					chkShowCYOpeningBalance.CheckState = CheckState.Checked; 
					chkShowCYCurrentBalance.CheckState = CheckState.Checked; 
					chkShowLedgerWithZeroBalance.CheckState = CheckState.Unchecked; 
					chkShowCYProfitAndLoss.CheckState = CheckState.Checked; 
					//**------------------------------------------------------------------------ 
					 
					break;
				case 44003001 :  //balance sheet report (normal) 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					//**--newly added parameters 
					//**--modified by: Moiz Hakimi 
					//**--modified on: 23-dec-2005 
					cmdPostMode.Visible = true; 
					chkShowCYCurrentBalance.Visible = true; 
					chkShowCYOpeningBalance.Visible = true; 
					chkShowLedgerWithZeroBalance.Visible = true; 
					chkShowCYProfitAndLoss.Visible = true; 
					txtGroupPrefix.Text = "["; 
					txtGroupSuffix.Text = "]"; 
					txtTabSpaceInTree.Value = 10; 
					chkShowCYOpeningBalance.CheckState = CheckState.Checked; 
					chkShowCYCurrentBalance.CheckState = CheckState.Checked; 
					chkShowLedgerWithZeroBalance.CheckState = CheckState.Unchecked; 
					chkShowCYProfitAndLoss.CheckState = CheckState.Checked; 
					//**------------------------------------------------------------------------ 
					 
					break;
				case 100090260 :  //RE Maintenance Report 
					lblMasterCode.Visible = false; 
					txtMasterCode.Visible = false; 
					txtMasterName.Visible = false; 
					fraDateRange.Top = lblMasterCode.Top; 
					lblDateRange.Top = lblMasterCode.Top - 7; 
					break;
			}


			if (mPromptForLocationMasterOnly)
			{
				lblMasterCode.Visible = false;
				txtMasterCode.Visible = false;
				txtMasterName.Visible = false;
				lblLocationCode.Top = lblMasterCode.Top;
				txtLocationCode.Top = txtMasterCode.Top;
				txtLocationName.Top = txtMasterName.Top;
				lblLocationCode.Visible = true;
				txtLocationCode.Visible = true;
				txtLocationName.Visible = true;
			}

			this.Text = mParameterWindowCaption;
			GetParameterRecordset();
			//cntMainParameter.Redraw = True
		}


		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{


				if (KeyCode == ((int) Keys.Return))
				{ //Return or Enter key
					SendKeys.Send("{TAB}");
					return;

				}
				else if (KeyCode == ((int) Keys.Escape))
				{  //Escape key
					cmdOKCancel_CancelClick(cmdOKCancel, null);
					KeyCode = 0;

				}
				else if (KeyCode == 113)
				{  //F2 key
					FindRoutine(this.ActiveControl.Name);
					KeyCode = 0;
				}
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
				SaveParameterRecordset();
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				repParametersWindow.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}


		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			mLastButtonClicked = 0;
			this.Hide();
		}


		private void txtCostCenterCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine(this.ActiveControl.Name);
		}


		private void txtCostCenterCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;
			try
			{

				if (!SystemProcedure2.IsItEmpty(txtCostCenterCode.Text, SystemVariables.DataType.NumberType))
				{
					mysql = " select ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cost_name" : "a_cost_name");
					mysql = mysql + " from gl_cost_centers ";
					mysql = mysql + " where cost_no=" + txtCostCenterCode.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						txtDCostCenterName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDCostCenterName.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}

				}
				else
				{
					txtDCostCenterName.Text = "";
				}
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mMasterDetails = DBNull.Value;

				if (mReturnErrorType == 4)
				{
					txtCostCenterCode.Focus();
				}
			}

		}


		private void txtLocationCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine(this.ActiveControl.Name);
		}


		private void txtLocationCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			try
			{

				if (!SystemProcedure2.IsItEmpty(txtLocationCode.Text, SystemVariables.DataType.StringType))
				{

					if (mLocationCodeIsString)
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLocationDetails = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mLocationLostFocusSQL + "'" + txtLocationCode.Text + "'"));
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLocationDetails = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mLocationLostFocusSQL + txtLocationCode.Text));
					}

					//mLocationDetails = GetMasterCode("select " & IIf(gPreferedLanguage = english, "l_locat_name", "a_locat_name") & "  from SM_Location where locat_no = " & txtLocationCode.Text)

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mLocationDetails))
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mLocationDetails = DBNull.Value;
						txtLocationName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{

						if (mLocationFindID == 2004000)
						{
							//UPGRADE_WARNING: (1068) mLocationDetails() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtLocationName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(0));
						}
						else
						{
							//UPGRADE_WARNING: (1068) mLocationDetails() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtLocationName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(0));
						}

					}

				}
				else
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mLocationDetails = DBNull.Value;
					txtLocationName.Text = "";
				}

				//**--check location level user security

				if (SystemVariables.gLoggedInUserCode != SystemConstants.gDefaultAdminUserCode && SystemVariables.gLoggedInSingleLocation && txtLocationCode.Visible && !mLocationFindIsChanged && !SystemProcedure2.IsItEmpty(txtLocationCode.Text, SystemVariables.DataType.NumberType))
				{

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_location_level_security_in_reports")))
					{
						mysql = " select count(*)";
						mysql = mysql + " from SM_users su";
						mysql = mysql + " where user_cd = " + SystemVariables.gLoggedInUserCode.ToString();
						mysql = mysql + " and exists (select * from SM_USER_GROUP_RIGHTS sugr";
						mysql = mysql + " inner join SM_Location l on l.locat_cd = sugr.locat_cd ";
						mysql = mysql + " where sugr.group_cd = su.group_cd";
						mysql = mysql + " and sugr.right_level <> 0";
						mysql = mysql + " and l.locat_no = " + txtLocationCode.Text.Trim();
						mysql = mysql + " and comp_id = " + SystemVariables.gCompanyID.ToString() + ")";

						if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode(mysql)) == 0)
						{
							MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							txtLocationCode.Focus();
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							mLocationDetails = DBNull.Value;
							return;
						}

					}

				}
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mLocationDetails = DBNull.Value;

				if (mReturnErrorType == 4)
				{
					txtLocationCode.Focus();
				}
			}

		}


		private void txtMasterCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine(this.ActiveControl.Name);
		}


		private void txtMasterCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{

				if (!SystemProcedure2.IsItEmpty(txtMasterCode.Text, SystemVariables.DataType.StringType))
				{

					if (mCodeIsString)
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mMasterDetails = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mLostFocusSQL + "'" + txtMasterCode.Text + "'"));
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mMasterDetails = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mLostFocusSQL + txtMasterCode.Text));
					}


					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mMasterDetails))
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mMasterDetails = DBNull.Value;
						txtMasterName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mMasterDetails() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtMasterName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(0));
					}

				}
				else
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mMasterDetails = DBNull.Value;
					txtMasterName.Text = "";
				}
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mMasterDetails = DBNull.Value;

				if (mReturnErrorType == 4)
				{
					txtMasterCode.Focus();
				}
			}

		}


		private void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;


			switch(pObjectName)
			{
				case "txtMasterCode" : 
					txtMasterCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(mFindID, mFindReturnColumnNo, mFindWhereClause, true, false, "", true, true, false, mFindSecurityLedgerClause)); 
					 
					break;
				case "txtLocationCode" : 
					txtLocationCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(mLocationFindID, mLocationFindReturnColumnNo, mLocationFindWhereClause, true, false, "", true, true, false, mFindSecurityLedgerClause)); 
					 
					break;
				case "txtCostCenterCode" : 
					txtCostCenterCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000110, "882", "", true, false, "", true, true)); 
					 
					break;
				case "txtProjectCode" : 
					txtProjectCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000130, "985", "", true, false, "", true, true)); 
					 
					break;
				case "txtAnalysisCode1" : 
					txtAnalysisCode1.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1008000, "1622", "anly_head_no = 1", true, false, "", true, true)); 
					 
					break;
				case "txtAnalysisCode2" : 
					txtAnalysisCode2.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1008000, "1622", "anly_head_no = 2", true, false, "", true, true)); 
					 
					break;
				default:
					return;
			}


			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{


				switch(pObjectName)
				{
					case "txtMasterCode" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtMasterCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)); 
						txtMasterCode_Leave(txtMasterCode, new EventArgs()); 
						 
						break;
					case "txtLocationCode" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtLocationCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)); 
						txtLocationCode_Leave(txtLocationCode, new EventArgs()); 
						 
						break;
					case "txtCostCenterCode" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtCostCenterCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)); 
						txtCostCenterCode_Leave(txtCostCenterCode, new EventArgs()); 
						 
						break;
					case "txtProjectCode" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtProjectCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)); 
						txtProjectCode_Leave(txtProjectCode, new EventArgs()); 
						 
						break;
					case "txtAnalysisCode1" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtAnalysisCode1.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)); 
						txtAnalysisCode1_Leave(txtAnalysisCode1, new EventArgs()); 
						 
						break;
					case "txtAnalysisCode2" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtAnalysisCode2.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)); 
						txtAnalysisCode2_Leave(txtAnalysisCode2, new EventArgs()); 
						break;
				}

			}

		}


		private void txtFromDate_Validating(Object eventSender, CancelEventArgs eventArgs)
		{
			//If IsDate(txtFromDate.Value) And IsDate(txtToDate.Value) Then
			//    If CDate(txtFromDate.Value) > CDate(txtToDate.Value) And txtToDate.Visible = True Then
			//        MsgBox "Enter valid date range", vbInformation
			//        Cancel = True
			//    End If
			//End If
		}


		private void txtProjectCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine(this.ActiveControl.Name);
		}


		private void txtAnalysisCode1_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine(this.ActiveControl.Name);
		}


		private void txtAnalysisCode2_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine(this.ActiveControl.Name);
		}


		private void txtProjectCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;
			try
			{

				if (!SystemProcedure2.IsItEmpty(txtProjectCode.Text, SystemVariables.DataType.StringType))
				{
					mysql = " select ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_project_name" : "a_project_name");
					mysql = mysql + " from PROJ_Projects ";
					mysql = mysql + " where project_no= '" + txtProjectCode.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						txtDProjectName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDProjectName.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}

				}
				else
				{
					txtDProjectName.Text = "";
				}
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mMasterDetails = DBNull.Value;

				if (mReturnErrorType == 4)
				{
					txtProjectCode.Focus();
				}
			}

		}


		private void txtAnalysisCode1_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;
			try
			{

				if (!SystemProcedure2.IsItEmpty(txtAnalysisCode1.Text, SystemVariables.DataType.StringType))
				{
					mysql = " select ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_anly_name" : "a_anly_name");
					mysql = mysql + " from gl_analysis ";
					mysql = mysql + " where anly_head_no = 1 and anly_code = '" + txtAnalysisCode1.Text.Trim() + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						txtDAnalysisName1.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDAnalysisName1.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}

				}
				else
				{
					txtDAnalysisName1.Text = "";
				}
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mMasterDetails = DBNull.Value;

				if (mReturnErrorType == 4)
				{
					txtAnalysisCode1.Focus();
				}
			}

		}


		private void txtAnalysisCode2_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;
			try
			{

				if (!SystemProcedure2.IsItEmpty(txtAnalysisCode2.Text, SystemVariables.DataType.StringType))
				{
					mysql = " select ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_anly_name" : "a_anly_name");
					mysql = mysql + " from gl_analysis ";
					mysql = mysql + " where anly_head_no = 2 and anly_code = '" + txtAnalysisCode2.Text.Trim() + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						txtDAnalysisName2.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDAnalysisName2.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}

				}
				else
				{
					txtDAnalysisName2.Text = "";
				}
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mMasterDetails = DBNull.Value;

				if (mReturnErrorType == 4)
				{
					txtAnalysisCode2.Focus();
				}
			}

		}


		private void txtToDate_Validating(Object eventSender, CancelEventArgs eventArgs)
		{
			//If IsDate(txtFromDate.Value) And IsDate(txtToDate.Value) Then
			//    If CDate(txtToDate.Value) < CDate(txtFromDate.Value) And txtFromDate.Visible = True Then
			//        MsgBox "Enter valid date range", vbInformation
			//        Cancel = True
			//    End If
			//End If
		}


		private void txtFromVoucherNo_Leave(Object eventSender, EventArgs eventArgs)
		{

			if (txtFromVoucherNo.NumericOnly)
			{
				txtFromVoucherNo.Text = StringsHelper.Format(Conversion.Val(txtFromVoucherNo.Text), "000000000000");
			}

		}


		private void txtToVoucherNo_Leave(Object eventSender, EventArgs eventArgs)
		{

			if (txtToVoucherNo.NumericOnly)
			{

				if (SystemProcedure2.IsItEmpty(Conversion.Val(txtToVoucherNo.Text), SystemVariables.DataType.NumberType))
				{
					txtToVoucherNo.Text = StringsHelper.Format(Conversion.Val(txtToVoucherNo.Text), "999999999999");
				}
				else
				{
					txtToVoucherNo.Text = StringsHelper.Format(Conversion.Val(txtToVoucherNo.Text), "000000000000");
				}

			}

		}


		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			string mTempFromDate = "";
			string mTempToDate = "";
			object mReturnValue = null;
			string mysql = "";
			txtFromVoucherNo_Leave(txtFromVoucherNo, new EventArgs());
			txtToVoucherNo_Leave(txtToVoucherNo, new EventArgs());

			if (txtFromDate.Visible)
			{

				if (!Information.IsDate(txtFromDate.Value))
				{
					MessageBox.Show("Error: Enter Valid Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtFromDate.Focus();
					return;
				}

			}


			if (txtToDate.Visible)
			{

				if (!Information.IsDate(txtToDate.Value))
				{
					MessageBox.Show("Error: Enter Valid Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtToDate.Focus();
					return;
				}

			}


			if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtFromDate.Value) > ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtToDate.Value) && txtToDate.Visible && txtFromDate.Visible)
			{
				MessageBox.Show("Enter valid date range", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtToDate.Focus();
				return;
			}

			try
			{
				mLastButtonClicked = 1;

				if (txtMasterCode.Visible)
				{
					txtMasterCode_Leave(txtMasterCode, new EventArgs());

					if (mMasterCodeIsMust)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mMasterDetails))
						{
							txtMasterCode.Focus();
							return;
						}

					}

				}


				if (txtLocationCode.Visible)
				{
					txtLocationCode_Leave(txtLocationCode, new EventArgs());

					if (mLocationCodeIsMust)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mLocationDetails))
						{
							txtLocationCode.Focus();
							return;
						}

					}

				}


				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("maintain_date_and_time_in_transactions")))
				{
					//UPGRADE_WARNING: (1068) txtFromDate.Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempFromDate = ReflectionHelper.GetPrimitiveValue<string>(txtFromDate.Value);
					//UPGRADE_WARNING: (1068) txtToDate.Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempToDate = ReflectionHelper.GetPrimitiveValue<string>(txtToDate.Value);
				}
				else
				{
					mTempFromDate = ReflectionHelper.GetPrimitiveValue<string>(txtFromDate.Value) + " 00:00:00 ";
					mTempToDate = ReflectionHelper.GetPrimitiveValue<string>(txtToDate.Value) + " 23:59:59 ";
				}

				//**-------------------------------------------------
				mReportFromDate = "";
				mReportToDate = "";


				switch(mReportId)
				{
					case 31001000 : case 41001020 : case 41003000 : case 41002015 : case 110013000 : case 110013010 : case 43009070 : case 53006310 : case 53006320 : case 54006150 : case 1000001 : case 42009300 : case 42001000 : case 42002000 : case 51003000 : case 52020030 : case 52004200 : case 52006000 : case 52010070 : case 52005030 : case 52005040 : case 53006200 : case 54602010 : case 64001000 : case 64001100 : case 64001640 : case 65003050 : case 65002000 : case 110013560 : case 110012000 : case 110013060 : case 110013040 : 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						 
						break;
					case 31002000 : 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						//    Case 41001005 
						//        mVariablesSetSQL = " set @FromDate = '" & mTempFromDate + "'" 
						//        mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" & mTempToDate + "' " 
						 
						break;
					case 41001040 : case 41001041 : case 42005000 : 
						mVariablesSetSQL = " set @VoucherType = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = " + txtFromVoucherNo.Text; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToVoucherNo = " + txtToVoucherNo.Text; 
						mReportTitleFilter = "Voucher Type : " + txtMasterCode.Text + "    Voucher Name :  " + txtMasterName.Text; 
						 
						break;
					case 41002000 : case 41002030 : case 54008007 : 
						mVariablesSetSQL = " set @LedgerCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						//If gPreferedLanguage = English Then 
						mReportTitleFilter = "Ledger Code : " + txtMasterCode.Text + "    Ledger Name : " + txtMasterName.Text; 
						//Else 
						//'    mReportTitleFilter = "„‰„‰‘” Ì„‰ „‘”‰ Ì" 
						 
						break;
					case 42006500 : 
						mVariablesSetSQL = " set @GroupCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						//If gPreferedLanguage = English Then 
						mReportTitleFilter = "Ledger Code : " + txtMasterCode.Text + "    Ledger Name : " + txtMasterName.Text; 
						 
						break;
					case 41002500 :  //Ledger Wise Analysis Summary 
						//mVariablesSetSQL = " set @LdgrCode = '" & Trim(mMasterDetails(1)) & "'" 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						//If gPreferedLanguage = English Then 
						//mReportTitleFilter = "Ledger Code : " & txtMasterCode.Text & "    Ledger Name : " & txtMasterName.Text 
						 
						break;
					case 41002010 : 
						mVariablesSetSQL = " set @LedgerCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Ledger Code : " + txtMasterCode.Text + "    Ledger Name : " + txtMasterName.Text; 
						 
						break;
					case 42001100 : 
						mVariablesSetSQL = " set @costcenter = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Cost Code : " + txtMasterCode.Text + "    Cost Center Name : " + txtMasterName.Text; 
						 
						break;
					case 42001200 : 
						mVariablesSetSQL = " set @costcenterCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Cost Center Code : " + txtMasterCode.Text + "    Cost Center Name : " + txtMasterName.Text; 
						 
						break;
					case 42001201 : 
						mVariablesSetSQL = " set @CostCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @LedgerCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Cost Center Code : " + txtMasterCode.Text + "    Cost Center Name : " + txtMasterName.Text; 
						mReportTitleFilter = mReportTitleFilter + "\r" + "Ledger Code : " + txtLocationCode.Text + new String(' ', 5) + "Ledger Name : " + txtLocationName.Text; 
						 
						break;
					case 42001300 : 
						mVariablesSetSQL = " set @CostCenterCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @LedgerCode = 'Z-PG-00000'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Cost Center Code : " + txtMasterCode.Text + "    Cost Center Name : " + txtMasterName.Text; 
						 
						break;
					case 42001900 : 
						mVariablesSetSQL = " set @CostCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Cost Center Code : " + txtMasterCode.Text + "    Cost Center Name : " + txtMasterName.Text; 
						 
						break;
					case 42008000 : 
						mVariablesSetSQL = " set @CatCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Category Code : " + txtMasterCode.Text + "    Category Name : " + txtMasterName.Text; 
						 
						break;
					case 42009600 : 
						mVariablesSetSQL = " set @ProjectCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Project Code : " + txtMasterCode.Text + "    Project Name : " + txtMasterName.Text; 
						 
						break;
					case 43002000 : case 45002000 : 
						mVariablesSetSQL = "set @DayRange1 = 30 set @DayRange2 = 60 set @DayRange3 = 90 set @DayRange4 = 120 set @DayRange5 = 150  set @VoucherDateType = 2 "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @AsOnDate = '" + mTempFromDate + "'"; 
						mReportTitleFilter = "As On Date : " + mTempFromDate; 
						 
						break;
					case 42001400 : 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @CostCenterCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mReportTitleFilter = "Cost Center Code : " + txtMasterCode.Text + "    Cost Center Name : " + txtMasterName.Text + " From Date : " + mTempFromDate + " To Date : " + mTempToDate; 
						 
						break;
					case 43003000 : 
						mVariablesSetSQL = "set @DayRange1 = 30 set @DayRange2 = 60 set @DayRange3 = 90 set @DayRange4 = 120 set @DayRange5 = 150  set @VoucherDateType = 1 "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @AsOnDate = '" + mTempFromDate + "'"; 
						mReportTitleFilter = "As On Date : " + mTempFromDate; 
						 
						break;
					case 43004000 : case 43001000 : case 52020050 : case 43004100 : case 43004300 : 
						mVariablesSetSQL = "set @DayRange1 = 30 set @DayRange2 = 60 set @DayRange3 = 90 set @DayRange4 = 120 set @DayRange5 = 150  "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @AsOnDate = '" + mTempFromDate + "'"; 
						mReportTitleFilter = "As On Date : " + mTempFromDate; 
						 
						break;
					case 43004200 : case 52005020 : case 52005025 : 
						mVariablesSetSQL = " set @AsOnDate = '" + mTempFromDate + "'"; 
						mReportTitleFilter = "As On Date : " + mTempFromDate; 
						 
						break;
					case 43005000 : 
						mVariablesSetSQL = "set @DayRange1 = 30 set @DayRange2 = 60 set @DayRange3 = 90 set @DayRange4 = 120 set @DayRange5 = 150  set @VoucherDateType = 1 "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @LedgerCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @AsOnDate = '" + mTempToDate + "'"; 
						mysql = " select phone , fax from gl_ledger "; 
						mysql = mysql + " where ldgr_no =" + txtMasterCode.Text; 
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql)); 
						 
						if (!SystemProcedure2.IsItEmpty(((Array) mReturnValue).GetValue(0), SystemVariables.DataType.StringType) || !SystemProcedure2.IsItEmpty(((Array) mReturnValue).GetValue(1), SystemVariables.DataType.StringType))
						{
							mReportTitleFilter = "As On Date : " + mTempToDate + "\r";
							mReportTitleFilter = mReportTitleFilter + " Ledger Code : " + txtMasterCode.Text + "    Ledger Name : " + txtMasterName.Text + "\r" + "   Tel No: " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)) + "    Fax No:" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						}
						else
						{
							mReportTitleFilter = "As On Date : " + mTempToDate + "\r";
							mReportTitleFilter = "As On Date : " + mTempToDate + "              Ledger Code : " + txtMasterCode.Text + "    Ledger Name : " + txtMasterName.Text;
						} 

						 
						break;
					case 43009000 :  // Account Voucher Tracking 
						mVariablesSetSQL = " set @LedgerCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Ledger Code : " + txtMasterCode.Text + "    Ledger Name : " + txtMasterName.Text; 
						 
						break;
					case 43009050 :  // Salesman Wise Collection (Default) 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						 
						break;
					case 43009060 :  // Salesman Wise Collection (Actual) 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						 
						break;
					case 43009100 : case 43009300 : 
						mVariablesSetSQL = " set @VoucherType = 110 "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = " + txtFromVoucherNo.Text; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToVoucherNo = " + txtToVoucherNo.Text; 
						 
						break;
					case 43009200 : 
						mVariablesSetSQL = " set @VoucherType = 111 "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = " + txtFromVoucherNo.Text; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToVoucherNo = " + txtToVoucherNo.Text; 
						mReportTitleFilter = "Voucher Type : " + txtMasterCode.Text + "    Voucher Name :  " + txtMasterName.Text; 
						 
						break;
					case 43009400 : 
						mVariablesSetSQL = " set @VoucherType = 111 "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = " + txtFromVoucherNo.Text; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToVoucherNo = " + txtToVoucherNo.Text; 
						 
						break;
					case 44001000 :  //trial balance report (hierarchical) 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						 
						break;
					case 44002000 :  //trading and profit & loss a/c report (hierarchical) 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						 
						break;
					case 44003000 :  //balance sheet report  (hierarchical) 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						 
						break;
					case 44003005 :  //balance sheet report (normal) 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						 
						break;
					case 44004000 : case 44004010 : 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						 
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
						if (!Convert.IsDBNull(mMasterDetails) && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
						{
							mReportTitleFilter = "Cost Center : " + txtMasterCode.Text + new String(' ', 5) + txtMasterName.Text;
							mVariablesSetSQL = mVariablesSetSQL + " set @CostCenterCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim();
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @CostCenterCode = null ";
						} 

						 
						break;
					case 45003000 : 
						mVariablesSetSQL = "set @DayRange1 = 30 set @DayRange2 = 60 set @DayRange3 = 90 set @DayRange4 = 120 set @DayRange5 = 150 set @VoucherDateType = 1 "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @AsOnDate = '" + mTempFromDate + "'"; 
						mReportTitleFilter = "As On Date : " + mTempFromDate; 
						 
						break;
					case 45004000 : 
						mVariablesSetSQL = "set @DayRange1 = 30 set @DayRange2 = 60 set @DayRange3 = 90 set @DayRange4 = 120 set @DayRange5 = 150 "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @AsOnDate = '" + mTempFromDate + "'"; 
						mReportTitleFilter = "As On Date : " + mTempFromDate; 
						 
						break;
					case 45005000 : 
						mVariablesSetSQL = "set @DayRange1 = 30 set @DayRange2 = 60 set @DayRange3 = 90 set @DayRange4 = 120 set @DayRange5 = 150  set @VoucherDateType = 1 "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @LedgerCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @AsOnDate = '" + mTempFromDate + "'"; 
						mReportTitleFilter = "As On Date : " + mTempFromDate; 
						mReportTitleFilter = "Ledger Code : " + txtMasterCode.Text + "    Ledger Name : " + txtMasterName.Text; 
						 
						break;
					//UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis#7001
					//case 54008007 : 
						//break;
					case 51001025 : 
						mVariablesSetSQL = " set @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						//mReportTitleFilter = "Group Code : " & txtMasterCode.Text & Space(10) 
						mReportTitleFilter = "Group Code : " + Conversion.Str(txtMasterCode.Text) + "    Group Name : " + txtMasterName.Text; 
						 
						break;
					case 51001040 : 
						mVariablesSetSQL = " set @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mReportTitleFilter = "Category Code : " + Conversion.Str(txtMasterCode.Text) + "    Category Name : " + txtMasterName.Text; 
						 
						break;
					//UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis#7001
					//case 51001040 : 
						//mVariablesSetSQL = " set @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						////mReportTitleFilter = "Group Code : " & txtMasterCode.Text & Space(10) 
						//mReportTitleFilter = "Category Code : " + Conversion.Str(txtMasterCode.Text) + "    Category Name : " + txtMasterName.Text; 
						// 
						//break;
					case 51004000 : case 51004010 : 
						mVariablesSetSQL = " set @VoucherType = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = " + txtFromVoucherNo.Text; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToVoucherNo = " + txtToVoucherNo.Text; 
						mReportTitleFilter = new String(' ', 100) + "Voucher Type : " + txtMasterCode.Text + new String(' ', 10) + "Location Code : " + Conversion.Str(txtLocationCode.Text) + new String(' ', 110) + "From Voucher No : " + txtFromVoucherNo.Text + new String(' ', 10) + "To Voucher No : " + Conversion.Str(txtToVoucherNo.Text); 
						 
						break;
					case 52001000 : 
						mVariablesSetSQL = " set @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Product Code : " + txtMasterCode.Text; 
						 
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
						if (!Convert.IsDBNull(mLocationDetails))
						{
							mReportTitleFilter = mReportTitleFilter + new String(' ', 10) + "Location Code : " + Conversion.Str(txtLocationCode.Text);
						} 

						 
						break;
					case 52002000 : case 54004025 : 
						mVariablesSetSQL = " set @GroupCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Group Code : " + txtMasterCode.Text + new String(' ', 10) + "Group Name : " + txtMasterName.Text + new String(' ', 10) + "Location Code : " + Conversion.Str(txtLocationCode.Text); 
						// . Date: 16/10/2007 Reason: To add report for inventory group wise summary 
						// ----------------------------------------------------------------------------------------- 
						 
						break;
					case 52002050 :  // Inventory Group Wise Summary 
						mVariablesSetSQL = mVariablesSetSQL + " set @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						// ----------------------------------------------------------------------------------------- 
						 
						break;
					case 52003000 : case 54004030 : case 54004032 : 
						mVariablesSetSQL = " set @CategoryCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Category Code : " + txtMasterCode.Text + new String(' ', 10) + "Category Name : " + txtMasterName.Text + new String(' ', 10) + "Location Code : " + Conversion.Str(txtLocationCode.Text); 
						 
						break;
					//UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis#7001
					//case 52004200 : 
						//break;
					case 52004000 : case 52004100 : case 52020040 : 
						mVariablesSetSQL = mVariablesSetSQL + " set @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Location Code : " + txtLocationCode.Text + new String(' ', 10) + "Location Name : " + txtLocationName.Text; 
						 
						break;
					case 52004005 : case 52020060 : case 53006300 : case 51001150 : case 51001200 : 
						mVariablesSetSQL = " set @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Product Code : " + txtMasterCode.Text + "    ICS_Item Name : " + txtMasterName.Text; 
						 
						break;
					case 52004010 : case 52020045 : case 52008010 : case 52008020 : case 52008030 : 
						mVariablesSetSQL = mVariablesSetSQL + " set @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						mReportTitleFilter = "Location Code : " + txtLocationCode.Text + new String(' ', 10) + "Location Name : " + txtLocationName.Text; 
						 
						break;
					case 52005010 : 
						mVariablesSetSQL = " set @VoucherType = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = " + Conversion.Str(txtFromVoucherNo.Text); 
						mReportTitleFilter = "Voucher Type : " + txtMasterCode.Text + new String(' ', 10) + "Location Code : " + Conversion.Str(txtLocationCode.Text); 
						 
						break;
					case 52006010 : case 52010040 : 
						mVariablesSetSQL = " set @VoucherType = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						//mVariablesSetSQL = mVariablesSetSQL + " set @LocationCode = " & Trim(mLocationDetails(1)) 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = " + txtFromVoucherNo.Text; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToVoucherNo = " + txtToVoucherNo.Text; 
						mReportTitleFilter = "Voucher Type : " + txtMasterCode.Text + new String(' ', 10) + "Voucher Name : " + txtMasterName.Text; 
						 
						break;
					case 52010010 : case 52005050 : case 52005060 : 
						mVariablesSetSQL = " set @VoucherType = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Voucher Type : " + txtMasterCode.Text + new String(' ', 10) + "Location Code : " + Conversion.Str(txtLocationCode.Text); 
						 
						break;
					case 52010015 : case 52010012 : 
						mVariablesSetSQL = " set @VoucherType = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = " + txtFromVoucherNo.Text; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToVoucherNo = " + txtToVoucherNo.Text; 
						mReportTitleFilter = "From Voucher Type : " + txtMasterCode.Text + new String(' ', 10) + " Voucher Name :  " + txtMasterName.Text + "To Voucher Type : " + txtLocationCode.Text + new String(' ', 10) + "  To Voucher Name :  " + txtLocationName.Text; 
						 
						break;
					case 52004008 : case 52010045 : case 52010060 : case 52010050 : 
						mVariablesSetSQL = " set @VoucherType = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						//mVariablesSetSQL = mVariablesSetSQL + " set @LocationCode = " & Trim(mLocationDetails(1)) 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = " + txtFromVoucherNo.Text; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToVoucherNo = " + txtToVoucherNo.Text; 
						mReportTitleFilter = "Voucher Type : " + txtMasterCode.Text + new String(' ', 10) + "    Voucher Name :  " + txtMasterName.Text; 
						 
						break;
					case 52010020 : case 53004020 : case 54004020 : 
						mVariablesSetSQL = " set  @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Location Code : " + Conversion.Str(txtLocationCode.Text) + "    Location Name : " + txtLocationName.Text; 
						 
						break;
					case 52010030 : 
						mVariablesSetSQL = " set @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Product Code : " + txtMasterCode.Text + new String(' ', 10) + "Product Name : " + txtMasterName.Text + new String(' ', 10) + "Location Code : " + Conversion.Str(txtLocationCode.Text); 
						 
						break;
					//UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis#7001
					//case 52010050 : 
						//mVariablesSetSQL = " set @VoucherType = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						//mVariablesSetSQL = mVariablesSetSQL + " set @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						//mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						//mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						////mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = " & Str(txtFromVoucherNo.Text) 
						//mReportTitleFilter = "Voucher Type : " + txtMasterCode.Text + new String(' ', 10) + "Location Code : " + Conversion.Str(txtLocationCode.Text); 
						// 
						//break;
					case 52020010 : 
						mVariablesSetSQL = " set @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @BatchCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = " + txtFromVoucherNo.Text; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToVoucherNo = " + txtToVoucherNo.Text; 
						mVariablesSetSQL = mVariablesSetSQL + " set @PhysicalCountVoucherType = " + SystemICSConstants.icsPhysicalCountVoucher.ToString(); 
						mReportTitleFilter = "Location Code : " + Conversion.Str(txtLocationCode.Text) + "    Location Name : " + txtLocationName.Text; 
						 
						break;
					case 52020011 : 
						mVariablesSetSQL = " set  @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						//mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" & mTempToDate + "' " 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = " + txtFromVoucherNo.Text; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToVoucherNo = " + txtToVoucherNo.Text; 
						mReportTitleFilter = "Product Code : " + Conversion.Str(txtMasterCode.Text) + "    Location Name : " + txtLocationCode.Text; 
						 
						break;
					case 52020013 : 
						mVariablesSetSQL = " set @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						//mVariablesSetSQL = mVariablesSetSQL + " set @PhysicalCountVoucherType = " & icsPhysicalCountVoucher 
						mReportTitleFilter = "Location Code : " + Conversion.Str(txtLocationCode.Text) + "    Location Name : " + txtLocationName.Text; 
						 
						break;
					case 52020015 : 
						mVariablesSetSQL = " set @ProductCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = '" + txtFromVoucherNo.Text + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToVoucherNo = '" + txtToVoucherNo.Text + "' "; 
						mReportTitleFilter = "Product Code : " + txtMasterCode.Text + "    ICS_Item Name : " + txtMasterName.Text; 
						 
						break;
					case 52020020 : 
						mVariablesSetSQL = " set @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						//mVariablesSetSQL = mVariablesSetSQL + " set @LocationCode = " & Trim(mLocationDetails(1)) 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromSerialNo = " + txtFromVoucherNo.Text + " "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToSerialNo = " + txtToVoucherNo.Text + " "; 
						mReportTitleFilter = "Product Code : " + txtMasterCode.Text + "  ICS_Item Name : " + txtMasterName.Text + new String(' ', 10) + "  From Serial No.: " + txtFromVoucherNo.Text + "  To Serial No.: " + txtToVoucherNo.Text; 
						 
						break;
					case 52020025 : 
						mVariablesSetSQL = " set @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						//        mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" & mTempToDate + "' " 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromSerialNo = " + txtFromVoucherNo.Text + " "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToSerialNo = " + txtToVoucherNo.Text + " "; 
						mReportTitleFilter = "Product Code : " + txtMasterCode.Text + "  ICS_Item Name : " + txtMasterName.Text + new String(' ', 10) + "  From Serial No.: " + txtFromVoucherNo.Text + "  To Serial No.: " + txtToVoucherNo.Text; 
						 
						break;
					case 53001001 : case 54001001 : case 54000010 : 
						mVariablesSetSQL = " set @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + SystemVariables.gCurrentPeriodStarts + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + SystemVariables.gCurrentPeriodEnds + "' "; 
						mReportFromDate = SystemVariables.gCurrentPeriodStarts; 
						mReportToDate = SystemVariables.gCurrentPeriodEnds; 
						mReportTitleFilter = "Product Code : " + txtMasterCode.Text + "    ICS_Item Name : " + txtMasterName.Text; 
						 
						break;
					case 53002000 : 
						mVariablesSetSQL = " set  @GroupCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + SystemVariables.gCurrentPeriodStarts + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + SystemVariables.gCurrentPeriodEnds + "' "; 
						mReportFromDate = SystemVariables.gCurrentPeriodStarts; 
						mReportToDate = SystemVariables.gCurrentPeriodEnds; 
						mReportTitleFilter = "Group Code : " + Conversion.Str(txtMasterCode.Text) + "    Group Name : " + txtMasterName.Text; 
						 
						break;
					case 53003000 : case 54003000 : 
						mVariablesSetSQL = " set  @CategoryCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + SystemVariables.gCurrentPeriodStarts + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + SystemVariables.gCurrentPeriodEnds + "' "; 
						mReportFromDate = SystemVariables.gCurrentPeriodStarts; 
						mReportToDate = SystemVariables.gCurrentPeriodEnds; 
						mReportTitleFilter = "Category Code : " + Conversion.Str(txtMasterCode.Text) + "    Category Name : " + txtMasterName.Text; 
						 
						break;
					case 53004010 : case 53006100 : case 54008010 : case 54008020 : case 54008030 : case 54008040 : 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						 
						break;
					case 53005010 : 
						mVariablesSetSQL = " set  @LedgerCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + SystemVariables.gCurrentPeriodStarts + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + SystemVariables.gCurrentPeriodEnds + "' "; 
						mReportFromDate = SystemVariables.gCurrentPeriodStarts; 
						mReportToDate = SystemVariables.gNextPeriodEnds; 
						mReportTitleFilter = "Supplier Code : " + txtMasterCode.Text + "    Supplier Name : " + txtMasterName.Text; 
						 
						break;
					case 53006000 : case 53006500 : case 53007020 : case 53008020 : case 53009020 : case 53001020 : case 54006000 : case 54102000 : case 54202000 : case 54302000 : case 54402000 : case 54502000 : case 54602000 : case 54006100 : case 54006200 : case 54006160 : case 54006010 : case 54004028 : case 54009020 : 
						mVariablesSetSQL = " set  @LocationCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = " + txtFromVoucherNo.Text; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToVoucherNo = " + txtToVoucherNo.Text; 
						mReportTitleFilter = "Location Code : " + Conversion.Str(txtLocationCode.Text) + "    Location Name : " + txtLocationName.Text; 
						 
						break;
					case 53006600 : 
						mVariablesSetSQL = " set @LedgerCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = " + txtFromVoucherNo.Text; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToVoucherNo = " + txtToVoucherNo.Text; 
						mReportTitleFilter = "Ledger Code : " + txtMasterCode.Text + "    Ledger Name : " + txtMasterName.Text; 
						 
						break;
					case 53007010 : case 53008010 : case 53009010 : case 53001010 : 
						mVariablesSetSQL = " set @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportFromDate = SystemVariables.gCurrentPeriodStarts; 
						mReportToDate = SystemVariables.gCurrentPeriodEnds; 
						mReportTitleFilter = "Product Code : " + txtMasterCode.Text + "    ICS_Item Name : " + txtMasterName.Text; 
						 
						break;
					case 54000100 : 
						mVariablesSetSQL = " set @LedgerCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mReportTitleFilter = "Ledger Code : " + txtMasterCode.Text + "    Ledger Name : " + txtMasterName.Text; 
						 
						break;
					case 54002100 : case 54001100 : case 54103000 : case 53009030 : case 54103100 : case 53002100 : 
						mVariablesSetSQL = " set @GroupCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportFromDate = mTempFromDate; 
						mReportToDate = mTempToDate; 
						mReportTitleFilter = "Group Code : " + Conversion.Str(txtMasterCode.Text) + "    Group Name : " + txtMasterName.Text; 
						 
						break;
					case 54003100 : case 54104000 : case 53009040 : case 53003100 : 
						mVariablesSetSQL = " set @CategoryCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Category Code : " + Conversion.Str(txtMasterCode.Text) + "    Category Name : " + txtMasterName.Text; 
						 
						break;
					case 54004010 : 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						//        mVariablesSetSQL = " set  @LocationCode = " & Trim(mLocationDetails(1)) 
						//        mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" & mTempFromDate + "'" 
						//        mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" & mTempToDate + "' " 
						//        mReportFromDate = mTempFromDate 
						//        mReportToDate = mTempToDate 
						//        mReportTitleFilter = "Location Code : " & Str(txtLocationCode.Text) & "    Location Name : " & txtLocationName.Text 
						 
						break;
					case 54005010 : case 54000020 : 
						mVariablesSetSQL = " set  @LedgerCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + SystemVariables.gCurrentPeriodStarts + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + SystemVariables.gCurrentPeriodEnds + "' "; 
						mReportFromDate = SystemVariables.gCurrentPeriodStarts; 
						mReportToDate = SystemVariables.gNextPeriodEnds; 
						mReportTitleFilter = "Customer Code : " + txtMasterCode.Text + "    Customer Name : " + txtMasterName.Text; 
						 
						break;
					case 54006190 : case 54006220 : 
						mVariablesSetSQL = " set @SmanCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + SystemVariables.gCurrentPeriodStarts + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + SystemVariables.gCurrentPeriodEnds + "' "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = " + txtFromVoucherNo.Text; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToVoucherNo = " + txtToVoucherNo.Text; 
						mReportTitleFilter = "Salesman Code : " + Conversion.Str(txtMasterCode.Text) + "    Salesman Name : " + txtMasterName.Text; 
						 
						break;
					case 54008008 : case 52004150 : 
						mVariablesSetSQL = " set @SmanCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + SystemVariables.gCurrentPeriodStarts + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + SystemVariables.gCurrentPeriodEnds + "' "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Salesman Code : " + Conversion.Str(txtMasterCode.Text) + "    Salesman Name : " + txtMasterName.Text; 
						 
						break;
					case 54007011 : case 54007040 : 
						mVariablesSetSQL = " set @SmanCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + SystemVariables.gCurrentPeriodStarts + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + SystemVariables.gCurrentPeriodEnds + "' "; 
						mReportFromDate = SystemVariables.gCurrentPeriodStarts; 
						mReportToDate = SystemVariables.gCurrentPeriodEnds; 
						mReportTitleFilter = "Salesman Code : " + Conversion.Str(txtMasterCode.Text) + "    Salesman Name : " + txtMasterName.Text; 
						 
						break;
					case 54007020 : case 54006170 : case 54006180 : case 54007025 : case 54008009 : 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						//Added by Rizwan. Date: 6/9/2007 & 10/9/2007 Reason: To add three reports for ICS_Item Supplier, Group Wise Summary and Customer Wise Sales Summary 
						//------------------------------------------------------------- 
						 
						break;
					case 54006207 : case 54006210 : case 54006230 : case 52010055 : case 54105005 : 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						//------------------------------------------------------------- 
						 
						break;
					case 54008005 : case 54105000 : case 54008001 : 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						//Added by Rizwan. Date: 7/9/2007 Reason: To add report for Most Common Returns 
						//------------------------------------------------------------- 
						 
						break;
					case 54009010 : 
						mVariablesSetSQL = " set @VoucherType = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportFromDate = SystemVariables.gCurrentPeriodStarts; 
						mReportToDate = SystemVariables.gCurrentPeriodEnds; 
						mReportTitleFilter = "Product Code : " + txtMasterCode.Text + "    ICS_Item Name : " + txtMasterName.Text; 
						 
						break;
					case 54101000 :  // sales return (product wise) 
						mVariablesSetSQL = " set @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportFromDate = SystemVariables.gCurrentPeriodStarts; 
						mReportToDate = SystemVariables.gCurrentPeriodEnds; 
						mReportTitleFilter = "Product Code : " + txtMasterCode.Text + "    ICS_Item Name : " + txtMasterName.Text; 
						 
						break;
					case 54201000 :  // delivery notes (product wise) 
						mVariablesSetSQL = " set @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportFromDate = SystemVariables.gCurrentPeriodStarts; 
						mReportToDate = SystemVariables.gCurrentPeriodEnds; 
						mReportTitleFilter = "Product Code : " + txtMasterCode.Text + "    ICS_Item Name : " + txtMasterName.Text; 
						 
						break;
					case 54301000 :  // stock return (product wise) 
						mVariablesSetSQL = " set @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportFromDate = SystemVariables.gCurrentPeriodStarts; 
						mReportToDate = SystemVariables.gCurrentPeriodEnds; 
						mReportTitleFilter = "Product Code : " + txtMasterCode.Text + "    ICS_Item Name : " + txtMasterName.Text; 
						 
						break;
					case 54401000 :  // sales order (product wise) 
						mVariablesSetSQL = " set @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportFromDate = SystemVariables.gCurrentPeriodStarts; 
						mReportToDate = SystemVariables.gCurrentPeriodEnds; 
						mReportTitleFilter = "Product Code : " + txtMasterCode.Text + "    ICS_Item Name : " + txtMasterName.Text; 
						 
						break;
					case 54501000 :  // sales quotation (product wise) 
						mVariablesSetSQL = " set @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportFromDate = SystemVariables.gCurrentPeriodStarts; 
						mReportToDate = SystemVariables.gCurrentPeriodEnds; 
						mReportTitleFilter = "Product Code : " + txtMasterCode.Text + "    ICS_Item Name : " + txtMasterName.Text; 
						 
						break;
					case 54601000 :  // advanced sales booking (product wise) 
						mVariablesSetSQL = " set @ProductCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportFromDate = SystemVariables.gCurrentPeriodStarts; 
						mReportToDate = SystemVariables.gCurrentPeriodEnds; 
						mReportTitleFilter = "Product Code : " + txtMasterCode.Text + "    ICS_Item Name : " + txtMasterName.Text; 
						 
						break;
					case 64001500 : case 64001600 : case 64001650 : case 65009200 : case 65009250 : case 65092420 :  // Payroll Sheet , Employee Payroll Sheet, Payroll Report , Penalty Report 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						 
						break;
					case 64001700 : case 110120000 : case 110113583 : case 110112110 : 
						mVariablesSetSQL = mVariablesSetSQL + " set @AsOnDate = '" + mTempFromDate + "'"; 
						mReportTitleFilter = "As On Date : " + mTempFromDate; 
						 
						if (mReportId == 110120000)
						{
							SystemHRProcedure.gProjectAllocationDate = mTempFromDate;
						}
						else
						{
							SystemHRProcedure.gProjectAllocationDate = "";
						} 

						 
						break;
					case 65092300 : 
						mVariablesSetSQL = mVariablesSetSQL + " set @AsOnDate = '" + mTempFromDate + "'"; 
						mReportTitleFilter = "For the month of : " + DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Parse(mTempFromDate).Month) + "," + DateTime.Parse(mTempFromDate).Year.ToString(); 
						 
						break;
					case 110121250 : 
						mVariablesSetSQL = mVariablesSetSQL + " set @Fromdate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "'"; 
						 
						if (!SystemProcedure2.IsItEmpty(txtMasterCode.Text, SystemVariables.DataType.StringType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @TAFieldId = " + txtMasterCode.Text;
							//        Else
							//          mVariablesSetSQL = mVariablesSetSQL + " set @TAFieldId = 0 "
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtLocationCode.Text, SystemVariables.DataType.StringType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @FromEmpNo = '" + txtLocationCode.Text + "'";
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @FromEmpNo = ''";
						} 
						 
						mReportTitleFilter = "From Date  : " + mTempFromDate + " To Date : " + mTempToDate; 
						 
						break;
					case 65003000 : case 110013220 : 
						mVariablesSetSQL = mVariablesSetSQL + " set @AsOnDate = '" + mTempFromDate + "'"; 
						 
						if (!SystemProcedure2.IsItEmpty(txtMasterCode.Text, SystemVariables.DataType.StringType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @TypeCd = " + txtMasterCode.Text;
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @TypeCd = 0 ";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtLocationCode.Text, SystemVariables.DataType.StringType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @FromEmpNo = '" + txtLocationCode.Text + "'";
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @FromEmpNo = ''";
						} 
						 
						mReportTitleFilter = "As On Date : " + mTempFromDate; 
						 
						break;
					case 65003060 : 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						//    Case 65004000 
						//        mVariablesSetSQL = mVariablesSetSQL + " set @EmployeeCode = " & Trim(mMasterDetails(1)) 
						//        mReportTitleFilter = "Employee Code : " & txtMasterCode.Text & Space(10) & "Employee Name : " & txtMasterName.Text 
						// 
						 
						break;
					case 65005000 : 
						mVariablesSetSQL = mVariablesSetSQL + " set @AsOnDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @LeaveCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mReportTitleFilter = "As On Date : " + mTempFromDate + "\r"; 
						mReportTitleFilter = mReportTitleFilter + "Leave Type Name : " + txtMasterName.Text; 
						 
						break;
					case 120000001 : 
						mVariablesSetSQL = mVariablesSetSQL + " set @GroupCode= " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mReportTitleFilter = mReportTitleFilter + " Group Code : " + txtMasterName.Text; 
						 
						break;
					case 65092360 : 
						mVariablesSetSQL = mVariablesSetSQL + " set @AsOnDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @EmpNo = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mReportTitleFilter = "As On Date : " + mTempFromDate + "\r"; 
						mReportTitleFilter = mReportTitleFilter + "Attendance For Employee: " + txtMasterName.Text; 
						 
						break;
					case 65005500 : case 110013620 : case 110121290 : 
						mVariablesSetSQL = mVariablesSetSQL + " set @AsOnDate = '" + mTempFromDate + "'"; 
						mReportTitleFilter = "As On Date : " + mTempFromDate; 
						 
						break;
					case 91001000 : 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromVoucherNo = " + txtFromVoucherNo.Text; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToVoucherNo = " + txtToVoucherNo.Text; 
						 
						break;
					case 91002000 : 
						mVariablesSetSQL = " set @AssetCd = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mReportTitleFilter = "Assets Code : " + txtMasterCode.Text + "    Assets Name : " + txtMasterName.Text; 
						//Case 91004000 
						//       mVariablesSetSQL = mVariablesSetSQL + " set @VoucherDate = '" & mTempFromDate & "'" 
						//      mReportTitleFilter = "As On Date : " & mTempFromDate 
						 
						break;
					case 91005000 : 
						mVariablesSetSQL = " set @VoucherDate = '" + mTempFromDate + "'"; 
						mReportTitleFilter = "As On Date : " + mTempFromDate; 
						 
						break;
					case 110013020 : 
						mVariablesSetSQL = " set @TenantCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Tenant Code : " + txtMasterCode.Text + "    Tenant Name : " + txtMasterName.Text; 
						 
						break;
					case 110013030 : 
						mVariablesSetSQL = " set @PropertyCode = '" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						mReportTitleFilter = "Property Code : " + txtMasterCode.Text + "    Property Name : " + txtMasterName.Text; 
						 
						break;
					case 42004000 : 
						mVariablesSetSQL = " set @LedgerCode = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(1)).Trim(); 
						mVariablesSetSQL = mVariablesSetSQL + " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						//**--newly added parameters 
						//**--modified by: Moiz Hakimi 
						//**--modified on: 23-dec-2005 
						mVariablesSetSQL = mVariablesSetSQL + " set @ReportLevel = " + cmbReportLevel.GetItemData(cmbReportLevel.ListIndex).ToString(); 
						 
						if (!SystemProcedure2.IsItEmpty(txtCostCenterCode.Text, SystemVariables.DataType.NumberType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @CostCenterCode = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select cost_cd from gl_cost_centers where cost_no = " + txtCostCenterCode.Text));
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @CostCenterCode = null";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtProjectCode.Text, SystemVariables.DataType.StringType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @ProjectCode = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select project_cd from PROJ_Projects where project_no = '" + txtProjectCode.Text + "'"));
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @ProjectCode = null";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtAnalysisCode1.Text, SystemVariables.DataType.StringType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode1 ='" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select anly_code from gl_analysis where anly_head_no = 1 and anly_code = '" + txtAnalysisCode1.Text.Trim() + "'")) + "'";
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode1 = null";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtAnalysisCode2.Text, SystemVariables.DataType.StringType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode2 ='" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select anly_code from gl_analysis where anly_head_no = 2 and anly_code = '" + txtAnalysisCode2.Text.Trim() + "'")) + "'";
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode2 = null";
						} 
						 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowCYOpeningBalance = " + ((chkShowCYOpeningBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowCYCurrentBalance = " + ((chkShowCYCurrentBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowCYProfitAndLoss = " + ((chkShowCYProfitAndLoss.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowLYOpeningBalance = " + ((chkShowLYOpeningBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowLYCurrentBalance = " + ((chkShowCYCurrentBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowLYProfitAndLoss = " + ((chkShowLYProfitAndLoss.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowLedgerWithZeroBalance = " + ((chkShowLedgerWithZeroBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @GroupPrefix = '" + txtGroupPrefix.Text.Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @GroupSuffix = '" + txtGroupSuffix.Text.Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @TabSpaceInTree = " + Conversion.Str(txtTabSpaceInTree.Value); 
						//**-------------------------------------------------------------------------------- 
						mReportTitleFilter = "Group Code : " + Conversion.Str(txtMasterCode.Text) + "    Group Name : " + txtMasterName.Text; 
						 
						if (!SystemProcedure2.IsItEmpty(txtCostCenterCode.Text, SystemVariables.DataType.StringType))
						{

							if (mReportTitleFilter != "")
							{
								mReportTitleFilter = mReportTitleFilter + Strings.Chr((int) Keys.Return).ToString();
							}

							mReportTitleFilter = mReportTitleFilter + "Cost Center : " + Conversion.Str(txtCostCenterCode.Text) + new String(' ', 5) + "Cost Center Name : " + txtDCostCenterName.Text;
							mVariablesSetSQL = mVariablesSetSQL + " set @CostNo = " + txtCostCenterCode.Text;
							mVariablesSetSQL = mVariablesSetSQL + " set @CostName = '" + txtDCostCenterName.Text + "'";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtProjectCode.Text, SystemVariables.DataType.StringType))
						{

							if (mReportTitleFilter != "")
							{
								mReportTitleFilter = mReportTitleFilter + Strings.Chr((int) Keys.Return).ToString();
							}

							mReportTitleFilter = mReportTitleFilter + "Project Code : " + txtProjectCode.Text + new String(' ', 5) + "Project Name : " + txtDProjectName.Text;
							mVariablesSetSQL = mVariablesSetSQL + " set @ProjectNo = '" + txtProjectCode.Text + "'";
							mVariablesSetSQL = mVariablesSetSQL + " set @ProjectName = '" + txtDProjectName.Text + "'";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtAnalysisCode1.Text, SystemVariables.DataType.StringType))
						{

							if (mReportTitleFilter != "")
							{
								mReportTitleFilter = mReportTitleFilter + Strings.Chr((int) Keys.Return).ToString();
							}

							mReportTitleFilter = mReportTitleFilter + "Analysis Code 1 : " + txtAnalysisCode1.Text + new String(' ', 5) + "Analysis Desc 1 : " + txtDAnalysisName1.Text;
							//mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode1 = " & txtAnalysisCode1.Text
							//mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisName1 = '" & txtDAnalysisName1.Text & "'"
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtAnalysisCode2.Text, SystemVariables.DataType.StringType))
						{

							if (mReportTitleFilter != "")
							{
								mReportTitleFilter = mReportTitleFilter + Strings.Chr((int) Keys.Return).ToString();
							}

							mReportTitleFilter = mReportTitleFilter + "Analysis Code 2 : " + txtAnalysisCode2.Text + new String(' ', 5) + "Analysis Desc 2 : " + txtDAnalysisName2.Text;
							//mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode2 = " & txtAnalysisCode2.Text
							//mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisName2 = '" & txtDAnalysisName2.Text & "'"
						} 

						 
						break;
					case 44001001 :  //trial balance report (normal) 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						//**--newly added parameters 
						//**--modified by: Moiz Hakimi 
						//**--modified on: 23-dec-2005 
						mVariablesSetSQL = mVariablesSetSQL + " set @ReportLevel = " + cmbReportLevel.GetItemData(cmbReportLevel.ListIndex).ToString(); 
						 
						if (!SystemProcedure2.IsItEmpty(txtCostCenterCode.Text, SystemVariables.DataType.NumberType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @CostCenterCode = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select cost_cd from gl_cost_centers where cost_no = " + txtCostCenterCode.Text));
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @CostCenterCode = null";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtProjectCode.Text, SystemVariables.DataType.StringType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @ProjectCode = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select project_cd from PROJ_Projects where project_no = '" + txtProjectCode.Text + "'"));
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @ProjectCode = null";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtAnalysisCode1.Text, SystemVariables.DataType.StringType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode1 ='" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select anly_code from gl_analysis where anly_head_no = 1 and anly_code = '" + txtAnalysisCode1.Text.Trim() + "'")) + "'";
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode1 = null";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtAnalysisCode2.Text, SystemVariables.DataType.StringType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode2 ='" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select anly_code from gl_analysis where anly_head_no = 2 and anly_code = '" + txtAnalysisCode2.Text.Trim() + "'")) + "'";
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode2 = null";
						} 
						 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowCYOpeningBalance = " + ((chkShowCYOpeningBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowCYCurrentBalance = " + ((chkShowCYCurrentBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowCYProfitAndLoss = " + ((chkShowCYProfitAndLoss.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowLYOpeningBalance = " + ((chkShowLYOpeningBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowLYCurrentBalance = " + ((chkShowCYCurrentBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowLYProfitAndLoss = " + ((chkShowLYProfitAndLoss.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowLedgerWithZeroBalance = " + ((chkShowLedgerWithZeroBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @GroupPrefix = '" + txtGroupPrefix.Text.Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @GroupSuffix = '" + txtGroupSuffix.Text.Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @TabSpaceInTree = " + Conversion.Str(txtTabSpaceInTree.Value); 
						//**-------------------------------------------------------------------------------- 
						 
						if (!SystemProcedure2.IsItEmpty(txtCostCenterCode.Text, SystemVariables.DataType.StringType))
						{

							if (mReportTitleFilter != "")
							{
								mReportTitleFilter = mReportTitleFilter + Strings.Chr((int) Keys.Return).ToString();
							}

							mReportTitleFilter = mReportTitleFilter + "Cost Center : " + Conversion.Str(txtCostCenterCode.Text) + new String(' ', 5) + "Cost Center Name : " + txtDCostCenterName.Text;
							mVariablesSetSQL = mVariablesSetSQL + " set @CostNo = " + txtCostCenterCode.Text;
							mVariablesSetSQL = mVariablesSetSQL + " set @CostName = '" + txtDCostCenterName.Text + "'";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtProjectCode.Text, SystemVariables.DataType.StringType))
						{

							if (mReportTitleFilter != "")
							{
								mReportTitleFilter = mReportTitleFilter + Strings.Chr((int) Keys.Return).ToString();
							}

							mReportTitleFilter = mReportTitleFilter + "Project Code : " + txtProjectCode.Text + new String(' ', 5) + "Project Name : " + txtDProjectName.Text;
							mVariablesSetSQL = mVariablesSetSQL + " set @ProjectNo = '" + txtProjectCode.Text + "'";
							mVariablesSetSQL = mVariablesSetSQL + " set @ProjectName = '" + txtDProjectName.Text + "'";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtAnalysisCode1.Text, SystemVariables.DataType.StringType))
						{

							if (mReportTitleFilter != "")
							{
								mReportTitleFilter = mReportTitleFilter + Strings.Chr((int) Keys.Return).ToString();
							}

							mReportTitleFilter = mReportTitleFilter + "Analysis Code 1 : " + txtAnalysisCode1.Text + new String(' ', 5) + "Analysis Desc 1 : " + txtDAnalysisName1.Text;
							//mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode1 = " & txtAnalysisCode1.Text
							//mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisName1 = '" & txtDAnalysisName1.Text & "'"
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtAnalysisCode2.Text, SystemVariables.DataType.StringType))
						{

							if (mReportTitleFilter != "")
							{
								mReportTitleFilter = mReportTitleFilter + Strings.Chr((int) Keys.Return).ToString();
							}

							mReportTitleFilter = mReportTitleFilter + "Analysis Code 2 : " + txtAnalysisCode2.Text + new String(' ', 5) + "Analysis Desc 2 : " + txtDAnalysisName2.Text;
							//mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode2 = " & txtAnalysisCode2.Text
							//mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisName2 = '" & txtDAnalysisName2.Text & "'"
						} 

						 
						break;
					case 44002001 :  //trading and profit & loss a/c report (normal) 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						//**--newly added parameters 
						//**--modified by: Moiz Hakimi 
						//**--modified on: 23-dec-2005 
						mVariablesSetSQL = mVariablesSetSQL + " set @ReportLevel = " + cmbReportLevel.GetItemData(cmbReportLevel.ListIndex).ToString(); 
						 
						if (!SystemProcedure2.IsItEmpty(txtCostCenterCode.Text, SystemVariables.DataType.NumberType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @CostCenterCode = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select cost_cd from gl_cost_centers where cost_no = " + txtCostCenterCode.Text));
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @CostCenterCode = null";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtProjectCode.Text, SystemVariables.DataType.StringType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @ProjectCode = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select project_cd from PROJ_Projects where project_no = '" + txtProjectCode.Text + "'"));
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @ProjectCode = null";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtAnalysisCode1.Text, SystemVariables.DataType.StringType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode1 = '" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select anly_code from gl_analysis where anly_head_no = 1 and anly_code = '" + txtAnalysisCode1.Text.Trim() + "'")) + "'";
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode1 = null";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtAnalysisCode2.Text, SystemVariables.DataType.StringType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode2 = '" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select anly_code from gl_analysis where anly_head_no = 2 and anly_code = '" + txtAnalysisCode2.Text.Trim() + "'")) + "'";
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode2 = null";
						} 
						 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowCYOpeningBalance = " + ((chkShowCYOpeningBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowCYCurrentBalance = " + ((chkShowCYCurrentBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowCYProfitAndLoss = " + ((chkShowCYProfitAndLoss.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowLYOpeningBalance = " + ((chkShowLYOpeningBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowLYCurrentBalance = " + ((chkShowCYCurrentBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowLYProfitAndLoss = " + ((chkShowLYProfitAndLoss.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowLedgerWithZeroBalance = " + ((chkShowLedgerWithZeroBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @GroupPrefix = '" + txtGroupPrefix.Text.Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @GroupSuffix = '" + txtGroupSuffix.Text.Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @TabSpaceInTree = " + Conversion.Str(txtTabSpaceInTree.Value); 
						//**-------------------------------------------------------------------------------- 
						 
						if (!SystemProcedure2.IsItEmpty(txtCostCenterCode.Text, SystemVariables.DataType.StringType))
						{

							if (mReportTitleFilter != "")
							{
								mReportTitleFilter = mReportTitleFilter + Strings.Chr((int) Keys.Return).ToString();
							}

							mReportTitleFilter = mReportTitleFilter + "Cost Center : " + Conversion.Str(txtCostCenterCode.Text) + new String(' ', 5) + "Cost Center Name : " + txtDCostCenterName.Text;
							mVariablesSetSQL = mVariablesSetSQL + " set @CostNo = " + txtCostCenterCode.Text;
							mVariablesSetSQL = mVariablesSetSQL + " set @CostName = '" + txtDCostCenterName.Text + "'";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtProjectCode.Text, SystemVariables.DataType.StringType))
						{

							if (mReportTitleFilter != "")
							{
								mReportTitleFilter = mReportTitleFilter + Strings.Chr((int) Keys.Return).ToString();
							}

							mReportTitleFilter = mReportTitleFilter + "Project Code : " + txtProjectCode.Text + new String(' ', 5) + "Project Name : " + txtDProjectName.Text;
							mVariablesSetSQL = mVariablesSetSQL + " set @ProjectNo = '" + txtProjectCode.Text + "'";
							mVariablesSetSQL = mVariablesSetSQL + " set @ProjectName = '" + txtDProjectName.Text + "'";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtAnalysisCode1.Text, SystemVariables.DataType.StringType))
						{

							if (mReportTitleFilter != "")
							{
								mReportTitleFilter = mReportTitleFilter + Strings.Chr((int) Keys.Return).ToString();
							}

							mReportTitleFilter = mReportTitleFilter + "Analysis Code 1 : " + txtAnalysisCode1.Text + new String(' ', 5) + "Analysis Desc 1 : " + txtDAnalysisName1.Text;
							//mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode1 = " & txtAnalysisCode1.Text
							//mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisName1 = '" & txtDAnalysisName1.Text & "'"
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtAnalysisCode2.Text, SystemVariables.DataType.StringType))
						{

							if (mReportTitleFilter != "")
							{
								mReportTitleFilter = mReportTitleFilter + Strings.Chr((int) Keys.Return).ToString();
							}

							mReportTitleFilter = mReportTitleFilter + "Analysis Code 2 : " + txtAnalysisCode2.Text + new String(' ', 5) + "Analysis Desc 2 : " + txtDAnalysisName2.Text;
							//mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode2 = " & txtAnalysisCode2.Text
							//mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisName2 = '" & txtDAnalysisName2.Text & "'"
						} 

						 
						break;
					case 44003001 :  //balance sheet report (normal) 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						//**--newly added parameters 
						//**--modified by: Moiz Hakimi 
						//**--modified on: 23-dec-2005 
						mVariablesSetSQL = mVariablesSetSQL + " set @ReportLevel = " + cmbReportLevel.GetItemData(cmbReportLevel.ListIndex).ToString(); 
						 
						if (!SystemProcedure2.IsItEmpty(txtCostCenterCode.Text, SystemVariables.DataType.NumberType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @CostCenterCode = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select cost_cd from gl_cost_centers where cost_no = " + txtCostCenterCode.Text));
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @CostCenterCode = null";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtProjectCode.Text, SystemVariables.DataType.StringType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @ProjectCode = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select project_cd from PROJ_Projects where project_no = '" + txtProjectCode.Text + "'"));
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @ProjectCode = null";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtAnalysisCode1.Text, SystemVariables.DataType.StringType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode1 ='" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select anly_code from gl_analysis where anly_head_no = 1 and anly_code = '" + txtAnalysisCode1.Text.Trim() + "'")) + "'";
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode1 = null";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtAnalysisCode2.Text, SystemVariables.DataType.StringType))
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode2 = '" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select anly_code from gl_analysis where anly_head_no = 2 and anly_code = '" + txtAnalysisCode2.Text.Trim() + "'")) + "'";
						}
						else
						{
							mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode2 = null";
						} 
						 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowCYOpeningBalance = " + ((chkShowCYOpeningBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowCYCurrentBalance = " + ((chkShowCYCurrentBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowCYProfitAndLoss = " + ((chkShowCYProfitAndLoss.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowLYOpeningBalance = " + ((chkShowLYOpeningBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowLYCurrentBalance = " + ((chkShowCYCurrentBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowLYProfitAndLoss = " + ((chkShowLYProfitAndLoss.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @ShowLedgerWithZeroBalance = " + ((chkShowLedgerWithZeroBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
						mVariablesSetSQL = mVariablesSetSQL + " set @GroupPrefix = '" + txtGroupPrefix.Text.Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @GroupSuffix = '" + txtGroupSuffix.Text.Trim() + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @TabSpaceInTree = " + Conversion.Str(txtTabSpaceInTree.Value); 
						//**-------------------------------------------------------------------------------- 
						 
						if (!SystemProcedure2.IsItEmpty(txtCostCenterCode.Text, SystemVariables.DataType.StringType))
						{

							if (mReportTitleFilter != "")
							{
								mReportTitleFilter = mReportTitleFilter + Strings.Chr((int) Keys.Return).ToString();
							}

							mReportTitleFilter = mReportTitleFilter + "Cost Center : " + Conversion.Str(txtCostCenterCode.Text) + new String(' ', 5) + "Cost Center Name : " + txtDCostCenterName.Text;
							mVariablesSetSQL = mVariablesSetSQL + " set @CostNo = " + txtCostCenterCode.Text;
							mVariablesSetSQL = mVariablesSetSQL + " set @CostName = '" + txtDCostCenterName.Text + "'";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtProjectCode.Text, SystemVariables.DataType.StringType))
						{

							if (mReportTitleFilter != "")
							{
								mReportTitleFilter = mReportTitleFilter + Strings.Chr((int) Keys.Return).ToString();
							}

							mReportTitleFilter = mReportTitleFilter + "Project Code : " + txtProjectCode.Text + new String(' ', 5) + "Project Name : " + txtDProjectName.Text;
							mVariablesSetSQL = mVariablesSetSQL + " set @ProjectNo = '" + txtProjectCode.Text + "'";
							mVariablesSetSQL = mVariablesSetSQL + " set @ProjectName = '" + txtDProjectName.Text + "'";
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtAnalysisCode1.Text, SystemVariables.DataType.StringType))
						{

							if (mReportTitleFilter != "")
							{
								mReportTitleFilter = mReportTitleFilter + Strings.Chr((int) Keys.Return).ToString();
							}

							mReportTitleFilter = mReportTitleFilter + "Analysis Code 1 : " + txtAnalysisCode1.Text + new String(' ', 5) + "Analysis Desc 1 : " + txtDAnalysisName1.Text;
							//mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode1 = " & txtAnalysisCode1.Text
							//mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisName1 = '" & txtDAnalysisName1.Text & "'"
						} 

						 
						if (!SystemProcedure2.IsItEmpty(txtAnalysisCode2.Text, SystemVariables.DataType.StringType))
						{

							if (mReportTitleFilter != "")
							{
								mReportTitleFilter = mReportTitleFilter + Strings.Chr((int) Keys.Return).ToString();
							}

							mReportTitleFilter = mReportTitleFilter + "Analysis Code 2 : " + txtAnalysisCode2.Text + new String(' ', 5) + "Analysis Desc 2 : " + txtDAnalysisName2.Text;
							//mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode2 = " & txtAnalysisCode2.Text
							//mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisName2 = '" & txtDAnalysisName2.Text & "'"
						} 

						 
						break;
					case 100090260 : 
						mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'"; 
						mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' "; 
						break;
				}


				if (mReportFromDate == "")
				{
					//UPGRADE_WARNING: (1068) txtFromDate.Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReportFromDate = ReflectionHelper.GetPrimitiveValue<string>(txtFromDate.Value);
				}


				if (mReportToDate == "")
				{
					//UPGRADE_WARNING: (1068) txtToDate.Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReportToDate = ReflectionHelper.GetPrimitiveValue<string>(txtToDate.Value);
				}

				this.Hide();
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);

				if (mReturnErrorType == 4)
				{
					txtMasterCode.Focus();
				}
			}
		}

		//Private Sub cmdPostMode_AccessKeyPress(KeyAscii As Integer)
		//Call cmdPostMode_Click
		//End Sub

		private void ShowHideAdvancedOptions(SystemICSConstants.ShowOptions ChangeToMode)
		{
			bool mShowSetting = false;

			if (ChangeToMode == SystemICSConstants.ShowOptions.optAdvancedMode)
			{
				mShowSetting = true;
				cmdPostMode.OkCaption = mNormalCaption;
				this.Height = mAdvancedHeight / 15;
				fraOptions.Enabled = true;
			}
			else
			{
				mShowSetting = false;
				cmdPostMode.OkCaption = mAdvancedCaption;
				this.Height = mNormalHeight / 15;
				fraOptions.Enabled = false;
			}

			//fraOptions.Visible = mShowSetting
			//Line1.Visible = mShowSetting
			//lblCommon(ctlAdvancedModeDetailsIndex).Visible = mShowSetting
			mPostOptionType = ChangeToMode;
		}


		private void GetParameterRecordset()
		{
			try
			{

				if (SystemVariables.rsReportParameter.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsReportParameter.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.rsReportParameter.MoveFirst();
					SystemVariables.rsReportParameter.Find("ReportId = " + Conversion.Str(mReportId));

					if (SystemVariables.rsReportParameter.Tables[0].Rows.Count != 0)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtMasterCode.Text = Convert.ToString(SystemVariables.rsReportParameter.Tables[0].Rows[0]["MasterCode"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtMasterName.Text = Convert.ToString(SystemVariables.rsReportParameter.Tables[0].Rows[0]["MasterName"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtLocationCode.Text = Convert.ToString(SystemVariables.rsReportParameter.Tables[0].Rows[0]["LocationCode"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtLocationName.Text = Convert.ToString(SystemVariables.rsReportParameter.Tables[0].Rows[0]["LocationName"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFromDate.Text = Convert.ToDateTime(SystemVariables.rsReportParameter.Tables[0].Rows[0]["FromDate"]).ToString("dd-MM-yyyy");
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtToDate.Text = Convert.ToDateTime(SystemVariables.rsReportParameter.Tables[0].Rows[0]["ToDate"]).ToString("dd-MM-yyyy");
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFromVoucherNo.Text = Convert.ToString(SystemVariables.rsReportParameter.Tables[0].Rows[0]["FromVoucherNo"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtToVoucherNo.Text = Convert.ToString(SystemVariables.rsReportParameter.Tables[0].Rows[0]["ToVoucherNo"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCostCenterCode.Text = Convert.ToString(SystemVariables.rsReportParameter.Tables[0].Rows[0]["CostCenterCode"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtProjectCode.Text = Convert.ToString(SystemVariables.rsReportParameter.Tables[0].Rows[0]["ProjectCode"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtAnalysisCode1.Text = Convert.ToString(SystemVariables.rsReportParameter.Tables[0].Rows[0]["AnalysisCode1"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtAnalysisCode2.Text = Convert.ToString(SystemVariables.rsReportParameter.Tables[0].Rows[0]["AnalysisCode2"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						cmbReportLevel.Text = Convert.ToString(SystemVariables.rsReportParameter.Tables[0].Rows[0]["ReportLevel"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtGroupPrefix.Text = Convert.ToString(SystemVariables.rsReportParameter.Tables[0].Rows[0]["GroupPrefix"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtGroupSuffix.Text = Convert.ToString(SystemVariables.rsReportParameter.Tables[0].Rows[0]["GroupSufix"]);
					}

				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}


		private void SaveParameterRecordset()
		{
			try
			{

				if (SystemVariables.rsReportParameter.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsReportParameter.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.rsReportParameter.MoveFirst();
					SystemVariables.rsReportParameter.Find("ReportId = " + Conversion.Str(mReportId));

					if (SystemVariables.rsReportParameter.Tables[0].Rows.Count != 0)
					{

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Tables[0].Rows[0]["reportId"].setValue(Conversion.Str(mReportId));
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Tables[0].Rows[0]["MasterCode"].setValue(txtMasterCode.Text);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Tables[0].Rows[0]["MasterName"].setValue(txtMasterName.Text);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Tables[0].Rows[0]["LocationCode"].setValue(txtLocationCode.Text);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Tables[0].Rows[0]["LocationName"].setValue(txtLocationName.Text);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Tables[0].Rows[0]["FromDate"].setValue(txtFromDate.Text);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Tables[0].Rows[0]["ToDate"].setValue(txtToDate.Text);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Tables[0].Rows[0]["FromVoucherNo"].setValue(txtFromVoucherNo.Text);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Tables[0].Rows[0]["ToVoucherNo"].setValue(txtToVoucherNo.Text);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Tables[0].Rows[0]["CostCenterCode"].setValue(txtCostCenterCode.Text);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Tables[0].Rows[0]["ProjectCode"].setValue(txtProjectCode.Text);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Tables[0].Rows[0]["AnalysisCode1"].setValue(txtAnalysisCode1.Text);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Tables[0].Rows[0]["AnalysisCode2"].setValue(txtAnalysisCode2.Text);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Tables[0].Rows[0]["ReportLevel"].setValue(cmbReportLevel.Text);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Tables[0].Rows[0]["GroupPrefix"].setValue(txtGroupPrefix.Text);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Tables[0].Rows[0]["GroupSufix"].setValue(txtGroupSuffix.Text);
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsReportParameter.Update was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.rsReportParameter.Update_Renamed(null, null);

						return;
					}
					else
					{
						goto AddRecord;
					}

				}

				AddRecord:

				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsReportParameter.AddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.AddNew(null, null);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Tables[0].Rows[0]["reportId"].setValue(Conversion.Str(mReportId));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Tables[0].Rows[0]["MasterCode"].setValue(txtMasterCode.Text);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Tables[0].Rows[0]["MasterName"].setValue(txtMasterName.Text);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Tables[0].Rows[0]["LocationCode"].setValue(txtLocationCode.Text);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Tables[0].Rows[0]["LocationName"].setValue(txtLocationName.Text);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Tables[0].Rows[0]["FromDate"].setValue(txtFromDate.Text);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Tables[0].Rows[0]["ToDate"].setValue(txtToDate.Text);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Tables[0].Rows[0]["FromVoucherNo"].setValue(txtFromVoucherNo.Text);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Tables[0].Rows[0]["ToVoucherNo"].setValue(txtToVoucherNo.Text);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Tables[0].Rows[0]["CostCenterCode"].setValue(txtCostCenterCode.Text);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Tables[0].Rows[0]["ProjectCode"].setValue(txtProjectCode.Text);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Tables[0].Rows[0]["AnalysisCode1"].setValue(txtAnalysisCode1.Text);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Tables[0].Rows[0]["AnalysisCode2"].setValue(txtAnalysisCode2.Text);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Tables[0].Rows[0]["ReportLevel"].setValue(cmbReportLevel.Text);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Tables[0].Rows[0]["GroupPrefix"].setValue(txtGroupPrefix.Text);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsReportParameter.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Tables[0].Rows[0]["GroupSufix"].setValue(txtGroupSuffix.Text);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsReportParameter.Update was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsReportParameter.Update_Renamed(null, null);
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}
	}
}