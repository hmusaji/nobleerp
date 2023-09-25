
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayBudgetDetails
		: System.Windows.Forms.Form
	{

		public frmPayBudgetDetails()
{
InitializeComponent();
} 
 public  void frmPayBudgetDetails_old()
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


		private void frmPayBudgetDetails_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
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

		public Control FirstFocusObject = null;
		private string mTimeStamp = "";

		private bool mFirstGridFocus = false;
		private XArrayHelper _aHeadCountSummaries = null;
		private XArrayHelper aHeadCountSummaries
		{
			get
			{
				if (_aHeadCountSummaries is null)
				{
					_aHeadCountSummaries = new XArrayHelper();
				}
				return _aHeadCountSummaries;
			}
			set
			{
				_aHeadCountSummaries = value;
			}
		}

		private XArrayHelper _aAddHeadCount = null;
		private XArrayHelper aAddHeadCount
		{
			get
			{
				if (_aAddHeadCount is null)
				{
					_aAddHeadCount = new XArrayHelper();
				}
				return _aAddHeadCount;
			}
			set
			{
				_aAddHeadCount = value;
			}
		}

		private XArrayHelper _aAddHeadCountFilter = null;
		private XArrayHelper aAddHeadCountFilter
		{
			get
			{
				if (_aAddHeadCountFilter is null)
				{
					_aAddHeadCountFilter = new XArrayHelper();
				}
				return _aAddHeadCountFilter;
			}
			set
			{
				_aAddHeadCountFilter = value;
			}
		}

		private XArrayHelper _aPayrollDetails = null;
		private XArrayHelper aPayrollDetails
		{
			get
			{
				if (_aPayrollDetails is null)
				{
					_aPayrollDetails = new XArrayHelper();
				}
				return _aPayrollDetails;
			}
			set
			{
				_aPayrollDetails = value;
			}
		}

		private XArrayHelper _aPayrollDetFilter = null;
		private XArrayHelper aPayrollDetFilter
		{
			get
			{
				if (_aPayrollDetFilter is null)
				{
					_aPayrollDetFilter = new XArrayHelper();
				}
				return _aPayrollDetFilter;
			}
			set
			{
				_aPayrollDetFilter = value;
			}
		}


		// For Headcount Summary Column Constraint
		private const int conHSLineNo = 0;
		private const int conHSSection = 1;
		private const int conHSHeadcountSummary = 2;
		private const int conHSCurrentHC = 3;
		private const int conHSReplacement = 4;
		private const int conHSTotalAddHC = 5;
		private const int conHSTotalHC = 6;
		private const int conHSCurrPayrollSal = 7;
		private const int conHSReplacementCost = 8;
		private const int conHSAddPayrollCost = 9;
		private const int conHSAnnualCost = 10;
		private const int conHSCategoryCd = 11;
		private const int conHSLastYearRemainingHC = 12;

		private const int conHSMaxColumns = 13;

		// For Addition HCDetails Column Constraint
		private const int conAHDLineNo = 0;
		private const int conAHDPeriod = 1;
		private const int conAHDBudgetHC = 2;
		private const int conAHDAnly4 = 3;
		private const int conAHDBudgetSal = 4;
		private const int conAHDTotalSal = 5;
		private const int conAHDAnly1 = 6;
		private const int conAHDAnly2 = 7;
		private const int conAHDAnly3 = 8;
		private const int conAHDAnly5 = 9;
		private const int conAHDHeadcountLineNo = 10;

		private const int conAHDMaxColumns = 11;

		// For Payroll Details Column Constraint
		private const int conPDLineNo = 0;
		private const int conPDEmpNo = 1;
		private const int conPDEmpName = 2;
		private const int conPDBasic = 3;
		private const int conPDAllowance = 4;
		private const int conPDHSCategoryNo = 5;
		private const int conPDBillCd = 6;
		private const int conPDEmpCd = 7;
		private const int conPDAnly1 = 8;
		private const int conPDAnly2 = 9;
		private const int conPDAnly3 = 10;
		private const int conPDAnly4 = 11;
		private const int conPDAnly5 = 12;
		private const int conPDHeadCountStatus = 13;

		private const int conPDMaxColumns = 14;

		private System.DateTime mBudgetEndDate = DateTime.FromOADate(0);
		private int mThisFormID = 0;
		private string mSearchValue = "";
		private clsToolbar oThisFormToolBar = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private int mSectionCd = 0;
		private int mDesgCd = 0;



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


		public string SearchValue
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


		//These property set the Form mode to add mode or edit mode

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


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = false;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = false;
				oThisFormToolBar.ShowHelpButton = false;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;

				this.WindowState = FormWindowState.Maximized;

				mFirstGridFocus = true;

				//''Asssign HeadcountSummary Grid
				SystemGrid.DefineSystemVoucherGrid(grdHeadcountSummary, false, false, false, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");
				SystemGrid.DefineSystemVoucherGridColumn(grdHeadcountSummary, "LN", 400, false, "&HBBC8CA", ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdHeadcountSummary, "Section", 2100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdHeadcountSummary, "Headcount Category", 2500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdHeadcountSummary, "Current Payroll HC", 1400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdHeadcountSummary, "Available Replacements", 1400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdHeadcountSummary, "Total Additional HC", 1400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdHeadcountSummary, "Total Year End HC", 1400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdHeadcountSummary, "Current Payroll Total Salary", 1400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdHeadcountSummary, "Replacement Cost", 1400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdHeadcountSummary, "Additional Payroll Cost", 1400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdHeadcountSummary, "Annual Cost Year End", 1400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdHeadcountSummary, "CategoryCode", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdHeadcountSummary, "LastYearRemainingHC", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				//''Asssign Additional Headcount Detail Grid
				SystemGrid.DefineSystemVoucherGrid(grdAddHeadcountDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "LN", 400, false, "&HBBC8CA", ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "Period", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "Budget HC", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "EmployeeNo", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "Budget Salary", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "Total Salary", 1500, false, "&HBBC8CA", ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "Account", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "Div", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "Dept", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "AnP", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "HS Line No", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				//''Asssign Current Payroll Detail Grid
				SystemGrid.DefineSystemVoucherGrid(grdCurrentPayroll, false, false, false, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");
				SystemGrid.DefineSystemVoucherGridColumn(grdCurrentPayroll, "LN", 400, false, "&HBBC8CA", ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdCurrentPayroll, "EmpNo", 600, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdCurrentPayroll, "Name", 3000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdCurrentPayroll, "Amount", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdCurrentPayroll, "Allowance", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdCurrentPayroll, "HS Line No", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdCurrentPayroll, "Bill Cd", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdCurrentPayroll, "Emp Cd", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdCurrentPayroll, "Account", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdCurrentPayroll, "Div", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdCurrentPayroll, "Dept", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdCurrentPayroll, "Emp", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdCurrentPayroll, "AnP", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdCurrentPayroll, "HeadCountStatus", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				DefineVoucherArray(-1, aHeadCountSummaries, conHSMaxColumns, false);
				AssignGridLineNumbers(aHeadCountSummaries);

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdHeadcountSummary.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdHeadcountSummary.setArray(aHeadCountSummaries);
				grdHeadcountSummary.Rebind(true);

				DefineVoucherArray(-1, aAddHeadCount, conAHDMaxColumns, false);
				DefineVoucherArray(-1, aAddHeadCountFilter, conAHDMaxColumns, false);
				AssignGridLineNumbers(aAddHeadCountFilter);

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdAddHeadcountDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdAddHeadcountDetails.setArray(aAddHeadCountFilter);
				grdAddHeadcountDetails.Rebind(true);


				DefineVoucherArray(-1, aPayrollDetails, conPDMaxColumns, false);
				DefineVoucherArray(-1, aPayrollDetFilter, conPDMaxColumns, false);
				AssignGridLineNumbers(aPayrollDetFilter);

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdCurrentPayroll.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdCurrentPayroll.setArray(aPayrollDetFilter);
				grdCurrentPayroll.Rebind(true);


				SystemProcedure.SetLabelCaption(this);
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}


		}

		private void DefineVoucherArray(int pMaximumRows, XArrayHelper aVoucherDetails, int conMaxColumns, bool pClearArray = false)
		{
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
			}
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, conMaxColumns}, new int[]{0, 0});
		}

		private void AssignGridLineNumbers(XArrayHelper aVoucherDetails)
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, SystemICSConstants.grdLineNoColumn);
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//On Keydown navigate the form by using enter key
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
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

		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);

			txtBudgetCode.Enabled = true;
			txtDeptCode.Enabled = true;

			DefineVoucherArray(-1, aHeadCountSummaries, conHSMaxColumns, true);
			DefineVoucherArray(-1, aPayrollDetails, conPDMaxColumns, true);
			DefineVoucherArray(-1, aPayrollDetFilter, conPDMaxColumns, true);
			DefineVoucherArray(-1, aAddHeadCount, conAHDMaxColumns, true);
			DefineVoucherArray(-1, aAddHeadCountFilter, conAHDMaxColumns, true);

			grdCurrentPayroll.Columns[conPDBasic].FooterText = "";
			grdCurrentPayroll.Columns[conPDAllowance].FooterText = "";
			grdAddHeadcountDetails.Columns[conAHDBudgetSal].FooterText = "";
			grdAddHeadcountDetails.Columns[conAHDBudgetHC].FooterText = "";
			grdAddHeadcountDetails.Columns[conAHDTotalSal].FooterText = "";
			grdHeadcountSummary.Columns[conHSCurrentHC].FooterText = "";
			grdHeadcountSummary.Columns[conHSCurrPayrollSal].FooterText = "";
			grdHeadcountSummary.Columns[conHSReplacement].FooterText = "";
			grdHeadcountSummary.Columns[conHSReplacementCost].FooterText = "";
			grdHeadcountSummary.Columns[conHSTotalAddHC].FooterText = "";
			grdHeadcountSummary.Columns[conHSAddPayrollCost].FooterText = "";
			grdHeadcountSummary.Columns[conHSTotalHC].FooterText = "";
			grdHeadcountSummary.Columns[conHSAnnualCost].FooterText = "";

			grdHeadcountSummary.Rebind(true);
			grdHeadcountSummary.Refresh();
			grdAddHeadcountDetails.Rebind(true);
			grdAddHeadcountDetails.Refresh();
			grdCurrentPayroll.Rebind(true);
			grdCurrentPayroll.Refresh();

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord()
		{
			bool result = false;
			object mReturnValue = null;
			string mysql = "";
			int cnt = 0;
			int mDeptCd = 0;
			int mBudgetCd = 0;
			try
			{

				if (!SystemProcedure2.IsItEmpty(txtDeptCode.Text, SystemVariables.DataType.NumberType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("Select dept_cd from pay_department where dept_no = " + txtDeptCode.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mDeptCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Please enter correct department category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return result;
					}
				}
				else
				{
					MessageBox.Show("Please enter department category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return result;
				}

				if (!SystemProcedure2.IsItEmpty(txtBudgetCode.Text, SystemVariables.DataType.NumberType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("Select Budget_Cd,Freezed from Pay_Budget where Budget_No = " + txtBudgetCode.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						if (!ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(1)))
						{
							mBudgetCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
						}
						else
						{
							MessageBox.Show("This Budget is freezed!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return false;
						}
					}
					else
					{
						MessageBox.Show("Please enter correct BudgetCode category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return result;
					}
				}
				else
				{
					MessageBox.Show("Please enter BudgetCode category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return result;
				}

				SystemVariables.gConn.BeginTransaction();
				grdHeadcountSummary.UpdateData();
				grdAddHeadcountDetails.UpdateData();

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					//' Insert Head Count Category Details
					int tempForEndVar = aHeadCountSummaries.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						mysql = "insert into Pay_Budget_Category(Budget_Cd , Head_Count_Category_Cd  , Opening_Head_Count , Emp_Head_Count_Salary";
						mysql = mysql + " ,Opening_Replacement_Head_Count,Emp_Replacement_Salary,Additional_Head_Count,Emp_Additional_Salary,User_Cd,RemainingHC) ";
						mysql = mysql + "values ( " + mBudgetCd.ToString();
						mysql = mysql + " ," + Convert.ToString(aHeadCountSummaries.GetValue(cnt, conHSCategoryCd));
						mysql = mysql + " ," + Convert.ToString(aHeadCountSummaries.GetValue(cnt, conHSCurrentHC));
						mysql = mysql + " ," + Convert.ToString(aHeadCountSummaries.GetValue(cnt, conHSCurrPayrollSal));
						mysql = mysql + " ," + Convert.ToString(aHeadCountSummaries.GetValue(cnt, conHSReplacement));
						mysql = mysql + " ," + Convert.ToString(aHeadCountSummaries.GetValue(cnt, conHSReplacementCost));
						mysql = mysql + " ," + Convert.ToString(aHeadCountSummaries.GetValue(cnt, conHSTotalAddHC));
						mysql = mysql + " ," + Convert.ToString(aHeadCountSummaries.GetValue(cnt, conHSAddPayrollCost));
						mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
						mysql = mysql + " ," + Convert.ToString(aHeadCountSummaries.GetValue(cnt, conHSLastYearRemainingHC));
						mysql = mysql + " )";
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql;
						TempCommand.ExecuteNonQuery();
					}

					//' Insert into Payroll Budget Details
					int tempForEndVar2 = aPayrollDetails.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar2; cnt++)
					{
						mysql = " select line_No from Pay_Budget_Category where Budget_Cd = " + mBudgetCd.ToString() + " and Head_Count_Category_Cd = " + Convert.ToString(aPayrollDetails.GetValue(cnt, conPDHSCategoryNo));
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue))
						{
							throw new Exception();
						}
						mysql = "insert into Pay_Budget_Payroll_Details(Budget_Category_Line_No,Bill_cd,Amount,Allowance_Amount ,User_Cd,Emp_cd";
						mysql = mysql + " ,analysis1_cd ,analysis2_cd,analysis3_cd,analysis4_cd,analysis5_cd,HeadCountStatus)";
						mysql = mysql + " values (" + ReflectionHelper.GetPrimitiveValue<int>(mReturnValue).ToString();
						mysql = mysql + " ," + Convert.ToString(aPayrollDetails.GetValue(cnt, conPDBillCd));
						mysql = mysql + " ," + Convert.ToString(aPayrollDetails.GetValue(cnt, conPDBasic));
						mysql = mysql + " ," + Convert.ToString(aPayrollDetails.GetValue(cnt, conPDAllowance));
						mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
						mysql = mysql + " ," + Convert.ToString(aPayrollDetails.GetValue(cnt, conPDEmpCd));
						mysql = mysql + " ,'" + Convert.ToString(aPayrollDetails.GetValue(cnt, conPDAnly1)) + "'";
						mysql = mysql + " ,'" + Convert.ToString(aPayrollDetails.GetValue(cnt, conPDAnly2)) + "'";
						mysql = mysql + " ,'" + Convert.ToString(aPayrollDetails.GetValue(cnt, conPDAnly3)) + "'";
						mysql = mysql + " ,'" + Convert.ToString(aPayrollDetails.GetValue(cnt, conPDAnly4)) + "'";
						mysql = mysql + " ,'" + Convert.ToString(aPayrollDetails.GetValue(cnt, conPDAnly5)) + "'";
						mysql = mysql + " ," + Convert.ToString(aPayrollDetails.GetValue(cnt, conPDHeadCountStatus));
						mysql = mysql + " )";
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();
					}

					//' Insert into Payroll Budgeted Headcount Details
					int tempForEndVar3 = aAddHeadCount.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar3; cnt++)
					{
						if (!SystemProcedure2.IsItEmpty(aAddHeadCount.GetValue(cnt, conAHDHeadcountLineNo), SystemVariables.DataType.StringType))
						{
							mysql = " select line_No from Pay_Budget_Category where Budget_Cd = " + mBudgetCd.ToString() + " and Head_Count_Category_Cd = " + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDHeadcountLineNo));
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mReturnValue))
							{
								throw new Exception();
							}

							mysql = " insert into Pay_Budget_Details(Budget_Category_Line_No, Budget_Period, Budget_Head_Count , Budgeted_Salary ,User_Cd)";
							mysql = mysql + " values (" + ReflectionHelper.GetPrimitiveValue<int>(mReturnValue).ToString();
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDPeriod)) + "'";
							mysql = mysql + " ," + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDBudgetHC));
							mysql = mysql + " ," + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDBudgetSal));
							mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
							mysql = mysql + " )";
							SqlCommand TempCommand_3 = null;
							TempCommand_3 = SystemVariables.gConn.CreateCommand();
							TempCommand_3.CommandText = mysql;
							TempCommand_3.ExecuteNonQuery();

							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));

							mysql = " insert into pay_head_count (head_count_no,head_count_category_cd,emp_cd,is_budgeted";
							mysql = mysql + " ,budget_details_line_no,head_count_status,user_cd,user_date_time , Total_Budget_Salary";
							mysql = mysql + " ,analysis1_cd, analysis2_cd, analysis3_cd, analysis4_cd, analysis5_cd)";
							mysql = mysql + " values(" + SystemProcedure2.GetNewNumber("Pay_Head_count", "Head_count_No");
							mysql = mysql + " ," + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDHeadcountLineNo));
							mysql = mysql + " ,NULL , 1 , " + ReflectionHelper.GetPrimitiveValue<int>(mReturnValue).ToString() + " , 1";
							mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
							mysql = mysql + " ,'" + DateTime.Today.ToString("dd-MMM-yyyy") + "'";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							mysql = mysql + " ," + ((Convert.IsDBNull(aAddHeadCount.GetValue(cnt, conAHDBudgetSal))) ? "0" : Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDBudgetSal)));
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDAnly1)) + "'";
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDAnly2)) + "'";
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDAnly3)) + "'";
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDAnly4)) + "'";
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDAnly5)) + "'";
							mysql = mysql + " )";
							SqlCommand TempCommand_4 = null;
							TempCommand_4 = SystemVariables.gConn.CreateCommand();
							TempCommand_4.CommandText = mysql;
							TempCommand_4.ExecuteNonQuery();
						}
					}

				}
				else
				{
					//' Insert into Payroll Budgeted Headcount Details
					int tempForEndVar4 = aHeadCountSummaries.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar4; cnt++)
					{
						mysql = " select line_No from Pay_Budget_Category where Budget_Cd = " + mBudgetCd.ToString() + " and Head_Count_Category_Cd = " + Convert.ToString(aHeadCountSummaries.GetValue(cnt, conHSCategoryCd));
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue))
						{
							throw new Exception();
						}

						mysql = "delete from pay_head_count where head_count_category_cd = " + Convert.ToInt32(aHeadCountSummaries.GetValue(cnt, conHSCategoryCd)).ToString();
						mysql = mysql + " and Is_Budgeted = 1";
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();
						mysql = "delete from pay_budget_details where Budget_Category_Line_No = " + ReflectionHelper.GetPrimitiveValue<int>(mReturnValue).ToString();
						SqlCommand TempCommand_6 = null;
						TempCommand_6 = SystemVariables.gConn.CreateCommand();
						TempCommand_6.CommandText = mysql;
						TempCommand_6.ExecuteNonQuery();
					}

					int tempForEndVar5 = aAddHeadCount.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar5; cnt++)
					{
						if (!SystemProcedure2.IsItEmpty(aAddHeadCount.GetValue(cnt, conAHDHeadcountLineNo), SystemVariables.DataType.StringType))
						{
							mysql = " select line_No from Pay_Budget_Category where Budget_Cd = " + mBudgetCd.ToString() + " and Head_Count_Category_Cd = " + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDHeadcountLineNo));
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mReturnValue))
							{
								throw new Exception();
							}

							mysql = " insert into Pay_Budget_Details(Budget_Category_Line_No, Budget_Period, Budget_Head_Count , Budgeted_Salary ,User_Cd)";
							mysql = mysql + " values (" + ReflectionHelper.GetPrimitiveValue<int>(mReturnValue).ToString();
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDPeriod)) + "'";
							mysql = mysql + " ," + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDBudgetHC));
							mysql = mysql + " ," + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDBudgetSal));
							mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
							mysql = mysql + " )";
							SqlCommand TempCommand_7 = null;
							TempCommand_7 = SystemVariables.gConn.CreateCommand();
							TempCommand_7.CommandText = mysql;
							TempCommand_7.ExecuteNonQuery();

							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));

							//'''' Auto Generated Entry For Headcount
							mysql = " insert into pay_head_count (head_count_no,head_count_category_cd,emp_cd,is_budgeted";
							mysql = mysql + " ,budget_details_line_no,head_count_status,user_cd,user_date_time , Total_Budget_Salary";
							mysql = mysql + " ,analysis1_cd, analysis2_cd, analysis3_cd, analysis4_cd, analysis5_cd)";
							mysql = mysql + " values(" + SystemProcedure2.GetNewNumber("Pay_Head_count", "Head_count_No");
							mysql = mysql + " ," + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDHeadcountLineNo));
							mysql = mysql + " ,NULL , 1 , " + ReflectionHelper.GetPrimitiveValue<int>(mReturnValue).ToString() + " , 1";
							mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
							mysql = mysql + " ,'" + DateTime.Today.ToString("dd-MMM-yyyy") + "'";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							mysql = mysql + " ," + ((Convert.IsDBNull(aAddHeadCount.GetValue(cnt, conAHDBudgetSal))) ? "0" : Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDBudgetSal)));
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDAnly1)) + "'";
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDAnly2)) + "'";
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDAnly3)) + "'";
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDAnly4)) + "'";
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDAnly5)) + "'";
							mysql = mysql + " )";
							SqlCommand TempCommand_8 = null;
							TempCommand_8 = SystemVariables.gConn.CreateCommand();
							TempCommand_8.CommandText = mysql;
							TempCommand_8.ExecuteNonQuery();


						}
					}

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				return true;
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}
			return result;
		}



		public void CloseForm()
		{
			this.Close();
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmPayBudgetDetails.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}


		public void IRoutine()
		{
			int mCurrentLineNo = 0;

			if (ActiveControl.Name != "grdAddHeadcountDetails" && grdAddHeadcountDetails.Enabled)
			{
				grdAddHeadcountDetails.Focus();
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdAddHeadcountDetails.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdAddHeadcountDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdAddHeadcountDetails.Columns[conAHDLineNo].Value);
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aAddHeadCountFilter.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aAddHeadCountFilter.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdAddHeadcountDetails.Bookmark), 1);
				AssignGridLineNumbers(aAddHeadCountFilter);
				grdAddHeadcountDetails.Rebind(true);
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdAddHeadcountDetails" && grdAddHeadcountDetails.Enabled)
			{
				grdAddHeadcountDetails.Focus();
			}

			if (aAddHeadCountFilter.GetLength(0) > 0)
			{
				grdAddHeadcountDetails.Delete();
				AssignGridLineNumbers(aAddHeadCount);
				grdAddHeadcountDetails.Rebind(true);
			}
		}

		private void FillHeadcountSummary()
		{
			try
			{
				int mDeptCd = 0;
				int mBudgetCd = 0;
				int mHCCategoryCd = 0;
				object mReturnValue = null;
				DataSet rsLocal = null;
				SqlDataReader rsPayroll = null;
				SqlDataReader rsAddPay = null;
				int mCntRow = 0;
				int mCnt = 0;
				int mAcnt = 0;
				int mAddHC = 0;
				double mAddPay = 0;
				string mysql = "";
				double mTotalYearSalary = 0;
				int mLastYearHC = 0;

				if (!SystemProcedure2.IsItEmpty(txtDeptCode.Text, SystemVariables.DataType.NumberType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("Select dept_cd from pay_department where dept_no = " + txtDeptCode.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mDeptCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Please enter correct department category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
				else
				{
					MessageBox.Show("Please enter department category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				if (!SystemProcedure2.IsItEmpty(txtBudgetCode.Text, SystemVariables.DataType.NumberType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("Select Budget_Cd, Budget_End_Date from Pay_Budget where Budget_No = " + txtBudgetCode.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mBudgetCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
						mBudgetEndDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						MessageBox.Show("Please enter correct BudgetCode category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
				else
				{
					MessageBox.Show("Please enter BudgetCode category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}


				mysql = " select pbc.Line_No ";
				mysql = mysql + " From Pay_Budget_Category pbc";
				mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = pbc.Head_Count_Category_Cd";
				mysql = mysql + " inner join Pay_Department pd on pd.Dept_Cd = phcc.Dept_Cd";
				mysql = mysql + " where pbc.Budget_Cd = " + mBudgetCd.ToString() + " and pd.Dept_Cd = " + mDeptCd.ToString(); //pd.M_Dept_Cd in (select pd1.Dept_Cd from Pay_Department pd1 where pd1.M_Dept_Cd = " & mDeptCd & " and pd1.Dept_Level = 3)"
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
					txtBudgetCode.Enabled = false;
					txtDeptCode.Enabled = false;
				}

				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " select p.l_dept_name , p.Head_Count_Category_Cd,p.L_Head_Count_Category_Name , SUM(p.CHC) as CHC , SUM(p.CHCP) as CHCP , SUM(p.RHC) as RHC, SUM(p.RHCP) as RHCP";
					mysql = mysql + " From";
					mysql = mysql + " (";
					mysql = mysql + " select pd.l_dept_name, phcc.Head_Count_Category_Cd, phcc.L_Head_Count_Category_Name  , count(Distinct phc.Emp_Cd) as CHC , SUM(pebd.Amount) as CHCP , 0 as RHC , 0 RHCP";
					mysql = mysql + " from Pay_Head_Count phc ";
					mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
					mysql = mysql + " inner join Pay_Department pd on pd.Dept_Cd = phcc.Dept_Cd ";
					mysql = mysql + " inner join Pay_Employee_Billing_Details pebd on pebd.Emp_Cd = phc.Emp_Cd ";
					mysql = mysql + " where phc.Head_Count_Status = 2  and pd.Dept_Cd = " + mDeptCd.ToString();
					mysql = mysql + " group by phcc.Head_Count_Category_Cd, phcc.L_Head_Count_Category_Name , phc.Head_Count_Status , pd.l_dept_name";
					mysql = mysql + " Having Count(phc.Emp_Cd) > 0";
					mysql = mysql + " Union All";
					mysql = mysql + " select pd.l_dept_name, phcc.Head_Count_Category_Cd, phcc.L_Head_Count_Category_Name  , 0 as CHC , 0 as CHCP , count(Distinct phc.Emp_Cd) as RHC , SUM(pebd.Amount) RHCP";
					mysql = mysql + " from Pay_Head_Count phc";
					mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
					mysql = mysql + " inner join Pay_Department pd on pd.Dept_Cd = phcc.Dept_Cd";
					mysql = mysql + " inner join Pay_Employee_Billing_Details pebd on pebd.Emp_Cd = phc.Emp_Cd";
					mysql = mysql + " where phc.Head_Count_Status = 3 and pd.Dept_Cd = " + mDeptCd.ToString();
					mysql = mysql + " group by phcc.Head_Count_Category_Cd, phcc.L_Head_Count_Category_Name , phc.Head_Count_Status , pd.l_dept_name";
					mysql = mysql + " Having Count(phc.Emp_Cd) > 0";
					mysql = mysql + "  ) as p";
					mysql = mysql + " group by p.l_dept_name , p.Head_Count_Category_Cd ,p.L_Head_Count_Category_Name";
					mysql = mysql + " order by 1";

					rsLocal = new DataSet();
					SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsLocal.Tables.Clear();
					adap.Fill(rsLocal);
					aHeadCountSummaries.RedimXArray(new int[]{rsLocal.Tables[0].Rows.Count - 1, conHSMaxColumns}, new int[]{0, 0});
					mCntRow = 0;
					mCnt = 0;
					mAcnt = 0;
					foreach (DataRow iteration_row in rsLocal.Tables[0].Rows)
					{
						mysql = "select COUNT(phc.Head_Count_Cd) ";
						mysql = mysql + " from Pay_Head_Count phc where phc.Head_Count_Category_Cd = " + Convert.ToString(iteration_row["Head_Count_Category_Cd"]);
						mysql = mysql + " and Head_Count_Status = 1";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLastYearHC = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));

						aHeadCountSummaries.SetValue(iteration_row["l_dept_name"], mCntRow, conHSSection);
						aHeadCountSummaries.SetValue(iteration_row["L_Head_Count_Category_Name"], mCntRow, conHSHeadcountSummary);
						aHeadCountSummaries.SetValue(0, mCntRow, conHSAddPayrollCost);
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						aHeadCountSummaries.SetValue(Convert.ToDouble(iteration_row["CHCP"]) + Convert.ToDouble(iteration_row["RHCP"]), mCntRow, conHSAnnualCost);
						aHeadCountSummaries.SetValue(iteration_row["CHC"], mCntRow, conHSCurrentHC);
						aHeadCountSummaries.SetValue(iteration_row["CHCP"], mCntRow, conHSCurrPayrollSal);
						aHeadCountSummaries.SetValue(iteration_row["RHC"], mCntRow, conHSReplacement);
						aHeadCountSummaries.SetValue(iteration_row["RHCP"], mCntRow, conHSReplacementCost);
						aHeadCountSummaries.SetValue(0, mCntRow, conHSTotalAddHC);
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						aHeadCountSummaries.SetValue(Convert.ToDouble(iteration_row["CHC"]) + Convert.ToDouble(iteration_row["RHC"]), mCntRow, conHSTotalHC);
						aHeadCountSummaries.SetValue(iteration_row["Head_Count_Category_Cd"], mCntRow, conHSCategoryCd);
						aHeadCountSummaries.SetValue(mLastYearHC, mCntRow, conHSLastYearRemainingHC);
						//'Insert Payroll Details for Currently Working Employee
						mysql = "select pemp.emp_no , pemp.l_full_name , pemp.emp_cd , phcc.Head_Count_Category_Cd";
						mysql = mysql + " , pebd.bill_cd as Bill_Cd";
						mysql = mysql + " , SUM(pebd.Amount) as CHCP";
						mysql = mysql + " , 0 as CHCPA , pemp.Analysis1 , pemp.Analysis2, pemp.Analysis3, pemp.Analysis4, pemp.Analysis5,  phc.Head_Count_Status";
						mysql = mysql + " from Pay_Head_Count phc";
						mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
						mysql = mysql + " inner join Pay_Department pd on pd.Dept_Cd = phcc.Dept_Cd";
						mysql = mysql + " inner join Pay_Employee_Billing_Details pebd on pebd.Emp_Cd = phc.Emp_Cd";
						mysql = mysql + " inner join Pay_Employee pemp on pemp.emp_cd = phc.emp_cd";
						mysql = mysql + " inner join Pay_Billing_Type pbt on pbt.Bill_Cd = pebd.Bill_Cd";
						mysql = mysql + " where phc.Head_Count_Status in (2,3) "; //and pd.M_Dept_Cd in (select pd1.Dept_Cd from Pay_Department pd1 where pd1.M_Dept_Cd = " & mDeptCd & " and pd1.Dept_Level = 3)"
						mysql = mysql + " and phcc.Head_Count_Category_Cd =  " + Convert.ToString(iteration_row["Head_Count_Category_Cd"]) + " and pbt.Include_In_Budget = 1";
						mysql = mysql + " group by pemp.emp_no , pemp.l_full_name , pemp.emp_cd , phcc.Head_Count_Category_Cd , phc.Head_Count_Status";
						mysql = mysql + " , pemp.Analysis1 , pemp.Analysis2, pemp.Analysis3, pemp.Analysis4, pemp.Analysis5 , pebd.bill_cd";
						mysql = mysql + " Having Count(phc.Emp_Cd) > 0";

						SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
						rsPayroll = sqlCommand_2.ExecuteReader();
						if (rsPayroll.Read())
						{
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsPayroll.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						}
						do 
						{
							DefineVoucherArray(mCnt, aPayrollDetails, conPDMaxColumns, false);
							aPayrollDetails.SetValue(rsPayroll["Emp_No"], mCnt, conPDEmpNo);
							aPayrollDetails.SetValue(rsPayroll["l_Full_name"], mCnt, conPDEmpName);
							aPayrollDetails.SetValue(rsPayroll["CHCP"], mCnt, conPDBasic);
							aPayrollDetails.SetValue(rsPayroll["CHCPA"], mCnt, conPDAllowance);
							aPayrollDetails.SetValue(rsPayroll["Head_Count_Category_Cd"], mCnt, conPDHSCategoryNo);
							aPayrollDetails.SetValue(rsPayroll["Bill_Cd"], mCnt, conPDBillCd);
							aPayrollDetails.SetValue(rsPayroll["Emp_cd"], mCnt, conPDEmpCd);
							aPayrollDetails.SetValue(rsPayroll["Analysis1"], mCnt, conPDAnly1);
							aPayrollDetails.SetValue(rsPayroll["Analysis2"], mCnt, conPDAnly2);
							aPayrollDetails.SetValue(rsPayroll["Analysis3"], mCnt, conPDAnly3);
							aPayrollDetails.SetValue(rsPayroll["Analysis4"], mCnt, conPDAnly4);
							aPayrollDetails.SetValue(rsPayroll["Analysis5"], mCnt, conPDAnly5);
							aPayrollDetails.SetValue(rsPayroll["Head_Count_Status"], mCnt, conPDHeadCountStatus);
							mCnt++;
						}
						while(rsPayroll.Read());
						mCntRow++;
					}
					rsLocal = null;

				}
				else
				{
					// If Budget Head Count is saved
					mysql = " select pd.l_dept_name , phcc.Head_Count_Category_Cd , phcc.L_Head_Count_Category_Name , Opening_Head_Count  ,  Emp_Head_Count_Salary";
					mysql = mysql + " ,  Opening_Replacement_Head_Count , Emp_Replacement_Salary , Additional_Head_Count  , Emp_Additional_Salary , RemainingHC";
					mysql = mysql + " from Pay_Budget_Category pbc ";
					mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = pbc.Head_Count_Category_Cd ";
					mysql = mysql + " inner join Pay_Department pd on pd.dept_cd = phcc.dept_cd";
					mysql = mysql + " Where pbc.Budget_Cd = " + mBudgetCd.ToString() + " and pd.Dept_Cd = " + mDeptCd.ToString(); //pd.M_Dept_Cd in (select pd1.Dept_Cd from Pay_Department pd1 where pd1.M_Dept_Cd = " & mDeptCd & " and pd1.Dept_Level = 3)"
					mysql = mysql + " order by 1";

					DefineVoucherArray(-1, aHeadCountSummaries, conHSMaxColumns, true);
					DefineVoucherArray(-1, aAddHeadCount, conAHDMaxColumns, true);
					DefineVoucherArray(-1, aPayrollDetails, conPDMaxColumns, true);

					rsLocal = new DataSet();
					SqlDataAdapter adap_3 = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsLocal.Tables.Clear();
					adap_3.Fill(rsLocal);
					aHeadCountSummaries.RedimXArray(new int[]{rsLocal.Tables[0].Rows.Count - 1, conHSMaxColumns}, new int[]{0, 0});
					mCntRow = 0;
					mCnt = 0;
					mAcnt = 0;
					foreach (DataRow iteration_row_3 in rsLocal.Tables[0].Rows)
					{
						mAddHC = 0;
						mAddPay = 0;
						aHeadCountSummaries.SetValue(iteration_row_3["l_dept_name"], mCntRow, conHSSection);
						aHeadCountSummaries.SetValue(iteration_row_3["L_Head_Count_Category_Name"], mCntRow, conHSHeadcountSummary);
						aHeadCountSummaries.SetValue(iteration_row_3["Emp_Additional_Salary"], mCntRow, conHSAddPayrollCost);
						aHeadCountSummaries.SetValue(iteration_row_3["Opening_Head_Count"], mCntRow, conHSCurrentHC);
						aHeadCountSummaries.SetValue(iteration_row_3["Emp_Head_Count_Salary"], mCntRow, conHSCurrPayrollSal);
						aHeadCountSummaries.SetValue(iteration_row_3["Opening_Replacement_Head_Count"], mCntRow, conHSReplacement);
						aHeadCountSummaries.SetValue(iteration_row_3["Emp_Replacement_Salary"], mCntRow, conHSReplacementCost);
						aHeadCountSummaries.SetValue(iteration_row_3["Additional_Head_Count"], mCntRow, conHSTotalAddHC);
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						aHeadCountSummaries.SetValue(Convert.ToDouble(Convert.ToDouble(iteration_row_3["Opening_Head_Count"]) + Convert.ToDouble(iteration_row_3["Opening_Replacement_Head_Count"])) + Convert.ToDouble(iteration_row_3["Additional_Head_Count"]), mCntRow, conHSTotalHC);
						aHeadCountSummaries.SetValue(iteration_row_3["Head_Count_Category_Cd"], mCntRow, conHSCategoryCd);
						aHeadCountSummaries.SetValue(iteration_row_3["RemainingHC"], mCntRow, conHSLastYearRemainingHC);

						//'Insert Payroll Details for Currently Working Employee
						mysql = " select pemp.emp_cd , pemp.l_full_name , pemp.emp_no , pbpd.Bill_Cd , pbpd.Amount , pbpd.Allowance_amount , pbc.Head_Count_Category_Cd";
						mysql = mysql + "  , pbpd.analysis1_cd, pbpd.analysis2_cd, pbpd.analysis3_cd, pbpd.analysis4_cd, pbpd.analysis5_cd";
						mysql = mysql + "  from Pay_Budget_Payroll_Details pbpd";
						mysql = mysql + "  inner join Pay_Budget_Category pbc on pbc.Line_No = pbpd.Budget_Category_Line_No";
						mysql = mysql + "  inner join pay_employee pemp on pemp.emp_cd = pbpd.emp_cd";
						mysql = mysql + " where pbc.Head_Count_Category_Cd =  " + Convert.ToString(iteration_row_3["Head_Count_Category_Cd"]) + " and pbc.Budget_Cd  = " + mBudgetCd.ToString();

						SqlCommand sqlCommand_4 = new SqlCommand(mysql, SystemVariables.gConn);
						rsPayroll = sqlCommand_4.ExecuteReader();
						bool rsPayrollDidRead2 = rsPayroll.Read();
						do 
						{
							DefineVoucherArray(mCnt, aPayrollDetails, conPDMaxColumns, false);
							aPayrollDetails.SetValue(rsPayroll["Emp_No"], mCnt, conPDEmpNo);
							aPayrollDetails.SetValue(rsPayroll["l_Full_name"], mCnt, conPDEmpName);
							aPayrollDetails.SetValue(rsPayroll["Amount"], mCnt, conPDBasic);
							aPayrollDetails.SetValue(rsPayroll["Allowance_Amount"], mCnt, conPDAllowance);
							aPayrollDetails.SetValue(rsPayroll["Head_Count_Category_Cd"], mCnt, conPDHSCategoryNo);
							aPayrollDetails.SetValue(rsPayroll["Bill_Cd"], mCnt, conPDBillCd);
							aPayrollDetails.SetValue(rsPayroll["Emp_cd"], mCnt, conPDEmpCd);
							aPayrollDetails.SetValue(rsPayroll["analysis1_cd"], mCnt, conPDAnly1);
							aPayrollDetails.SetValue(rsPayroll["Analysis2_cd"], mCnt, conPDAnly2);
							aPayrollDetails.SetValue(rsPayroll["Analysis3_cd"], mCnt, conPDAnly3);
							aPayrollDetails.SetValue(rsPayroll["Analysis4_cd"], mCnt, conPDAnly4);
							aPayrollDetails.SetValue(rsPayroll["Analysis5_cd"], mCnt, conPDAnly5);
							mCnt++;
						}
						while(rsPayroll.Read());

						//'Inser Additional HeadCount Details For Edit
						mysql = " select pbc.Head_Count_Category_Cd , pbd.Budget_Period  ,  pbd.Budget_Head_Count  , pbd.Budgeted_Salary , (pbd.Budget_Head_Count  * pbd.Budgeted_Salary) as TotalAmt";
						mysql = mysql + " ,phc.analysis1_cd, phc.analysis2_cd, phc.analysis3_cd, phc.analysis4_cd, phc.analysis5_cd, phc.Total_Budget_Salary";
						mysql = mysql + " from Pay_Budget_Details pbd";
						mysql = mysql + " inner join Pay_Budget_Category pbc on pbc.Line_No = pbd.Budget_Category_Line_No";
						mysql = mysql + " left outer join Pay_head_count phc on pbd.line_no = phc.Budget_Details_Line_No ";
						mysql = mysql + " where pbc.Head_Count_Category_Cd =  " + Convert.ToString(iteration_row_3["Head_Count_Category_Cd"]) + " and pbc.Budget_Cd  = " + mBudgetCd.ToString();
						mTotalYearSalary = 0;
						SqlCommand sqlCommand_5 = new SqlCommand(mysql, SystemVariables.gConn);
						rsAddPay = sqlCommand_5.ExecuteReader();
						rsAddPay.Read();
						do 
						{
							DefineVoucherArray(mAcnt, aAddHeadCount, conAHDMaxColumns, false);
							aAddHeadCount.SetValue((Convert.ToDouble(rsAddPay["Total_Budget_Salary"]) > 0) ? 1 : -1, mAcnt, conAHDBudgetHC);
							aAddHeadCount.SetValue(rsAddPay["Budgeted_Salary"], mAcnt, conAHDBudgetSal);
							aAddHeadCount.SetValue(rsAddPay["Head_Count_Category_Cd"], mAcnt, conAHDHeadcountLineNo);
							aAddHeadCount.SetValue(rsAddPay["Budget_Period"], mAcnt, conAHDPeriod);
							aAddHeadCount.SetValue(rsAddPay["TotalAmt"], mAcnt, conAHDTotalSal);
							aAddHeadCount.SetValue(rsAddPay["analysis1_cd"], mAcnt, conAHDAnly1);
							aAddHeadCount.SetValue(rsAddPay["analysis2_cd"], mAcnt, conAHDAnly2);
							aAddHeadCount.SetValue(rsAddPay["analysis3_cd"], mAcnt, conAHDAnly3);
							aAddHeadCount.SetValue(rsAddPay["analysis4_cd"], mAcnt, conAHDAnly4);
							aAddHeadCount.SetValue(rsAddPay["analysis5_cd"], mAcnt, conAHDAnly5);
							mAddHC = Convert.ToInt32(mAddHC + Convert.ToDouble(rsAddPay["Budget_Head_Count"]));
							mAddPay += Convert.ToDouble(rsAddPay["Budgeted_Salary"]);
							mTotalYearSalary += ((Convert.ToDouble(rsAddPay["Budgeted_Salary"]) * Convert.ToDouble(rsAddPay["Budget_Head_Count"])) * (((int) DateAndTime.DateDiff("m", Convert.ToDateTime(rsAddPay["Budget_Period"]), mBudgetEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) + 1));
							mAcnt++;
						}
						while(rsAddPay.Read());
						aHeadCountSummaries.SetValue(mAddHC, mCntRow, conHSTotalAddHC);
						aHeadCountSummaries.SetValue(mAddPay, mCntRow, conHSAddPayrollCost);
						aHeadCountSummaries.SetValue((Convert.ToDouble(iteration_row_3["Emp_Head_Count_Salary"]) * 12) + (Convert.ToDouble(iteration_row_3["Emp_Replacement_Salary"]) * 12) + mTotalYearSalary, mCntRow, conHSAnnualCost);
						mCntRow++;
					}
				}
				AssignGridLineNumbers(aHeadCountSummaries);
				grdHeadcountSummary.Rebind(true);
				grdHeadcountSummary.Refresh();
				grdHeadcountSummary_RowColChange(grdHeadcountSummary, new C1.Win.C1TrueDBGrid.RowColChangeEventArgs());
				//Call CalculateTotal
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void CalculateTotal()
		{
			//Dim mTotalSal As Double
			int cnt = 0;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				double mBudgetSal = 0;
				int mHeadCount = 0;
				double mTotalSal = 0;
				double mTotalYearSalary = 0;
				//''Update Total For Additional Grid
				grdAddHeadcountDetails.UpdateData();
				int tempForEndVar = aAddHeadCountFilter.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					mBudgetSal += Convert.ToDouble(aAddHeadCountFilter.GetValue(cnt, conAHDBudgetSal));
					mHeadCount = Convert.ToInt32(mHeadCount + Convert.ToDouble(aAddHeadCountFilter.GetValue(cnt, conAHDBudgetHC)));
					mTotalSal += Convert.ToDouble(aAddHeadCountFilter.GetValue(cnt, conAHDTotalSal));
					mTotalYearSalary += ((mBudgetSal * mHeadCount) * (((int) DateAndTime.DateDiff("m", Convert.ToDateTime(aAddHeadCountFilter.GetValue(cnt, conAHDPeriod)), mBudgetEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) + 1));
					grdHeadcountSummary.Columns[conHSAddPayrollCost].Value = mTotalSal;
					grdHeadcountSummary.Columns[conHSTotalAddHC].Value = mHeadCount;
				}
				grdAddHeadcountDetails.Columns[conAHDBudgetSal].FooterText = mBudgetSal.ToString();
				grdAddHeadcountDetails.Columns[conAHDBudgetHC].FooterText = mHeadCount.ToString();
				grdAddHeadcountDetails.Columns[conAHDTotalSal].FooterText = mTotalSal.ToString();
				grdAddHeadcountDetails.Refresh();

				//''Update Headcount Summary Grid

				mTotalSal = 0;
				int mCurrPayHC = 0;
				double mCurrPaySal = 0;
				int mReplacHC = 0;
				double mReplacSal = 0;
				int mAddHC = 0;
				double mAddSal = 0;
				int mTotalHC = 0;
				grdHeadcountSummary.UpdateData();
				int tempForEndVar2 = aHeadCountSummaries.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar2; cnt++)
				{
					mCurrPayHC = Convert.ToInt32(mCurrPayHC + Convert.ToDouble(aHeadCountSummaries.GetValue(cnt, conHSCurrentHC)));
					mCurrPaySal += Convert.ToDouble(aHeadCountSummaries.GetValue(cnt, conHSCurrPayrollSal));
					mReplacHC = Convert.ToInt32(mReplacHC + Convert.ToDouble(aHeadCountSummaries.GetValue(cnt, conHSReplacement)));
					mReplacSal += Convert.ToDouble(aHeadCountSummaries.GetValue(cnt, conHSReplacementCost));
					mAddHC = Convert.ToInt32(mAddHC + Convert.ToDouble(aHeadCountSummaries.GetValue(cnt, conHSTotalAddHC)));
					mAddSal += Convert.ToDouble(aHeadCountSummaries.GetValue(cnt, conHSAddPayrollCost));
					mTotalHC = Convert.ToInt32(mTotalHC + Convert.ToDouble(aHeadCountSummaries.GetValue(cnt, conHSTotalHC)));
					mTotalSal += Convert.ToDouble(aHeadCountSummaries.GetValue(cnt, conHSAnnualCost));
				}

				grdHeadcountSummary.Columns[conHSCurrentHC].FooterText = mCurrPayHC.ToString();
				grdHeadcountSummary.Columns[conHSCurrPayrollSal].FooterText = mCurrPaySal.ToString();
				grdHeadcountSummary.Columns[conHSReplacement].FooterText = mReplacHC.ToString();
				grdHeadcountSummary.Columns[conHSReplacementCost].FooterText = mReplacSal.ToString();
				grdHeadcountSummary.Columns[conHSTotalAddHC].FooterText = mAddHC.ToString();
				grdHeadcountSummary.Columns[conHSAddPayrollCost].FooterText = mAddSal.ToString();
				grdHeadcountSummary.Columns[conHSTotalHC].FooterText = mTotalHC.ToString();
				grdHeadcountSummary.Columns[conHSAnnualCost].FooterText = mTotalSal.ToString();
				grdHeadcountSummary.Columns[conHSTotalHC].Text = (ReflectionHelper.GetPrimitiveValue<int>(grdHeadcountSummary.Columns[conHSCurrentHC].Value) + ReflectionHelper.GetPrimitiveValue<int>(grdHeadcountSummary.Columns[conHSReplacement].Value) + ReflectionHelper.GetPrimitiveValue<int>(grdHeadcountSummary.Columns[conHSTotalAddHC].Value)).ToString();
				grdHeadcountSummary.Columns[conHSAnnualCost].Text = ((ReflectionHelper.GetPrimitiveValue<double>(grdHeadcountSummary.Columns[conHSCurrPayrollSal].Value) * 12) + (ReflectionHelper.GetPrimitiveValue<double>(grdHeadcountSummary.Columns[conHSReplacementCost].Value) * 12) + mTotalYearSalary).ToString();
				grdHeadcountSummary.UpdateData();

				//''Update Total For Billing Amount Grid
				double mBillAmtTotal = 0;
				double mAllAmtTotal = 0;
				int tempForEndVar3 = aPayrollDetFilter.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar3; cnt++)
				{
					mBillAmtTotal += Convert.ToDouble(aPayrollDetFilter.GetValue(cnt, conPDBasic));
					mAllAmtTotal += Convert.ToDouble(aPayrollDetFilter.GetValue(cnt, conPDAllowance));
				}
				grdCurrentPayroll.Columns[conPDBasic].FooterText = mBillAmtTotal.ToString();
				grdCurrentPayroll.Columns[conPDAllowance].FooterText = mAllAmtTotal.ToString();
				grdCurrentPayroll.UpdateData();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void grdAddHeadcountDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			string mysql = "";
			string mHeadCount = "";
			string mBudgetSalary = "";

			if (ColIndex == conAHDBudgetSal || ColIndex == conAHDBudgetHC)
			{
				if (!SystemProcedure2.IsItEmpty(grdAddHeadcountDetails.Columns[conAHDBudgetHC].Value, SystemVariables.DataType.StringType) && !SystemProcedure2.IsItEmpty(grdAddHeadcountDetails.Columns[conAHDBudgetSal].Value, SystemVariables.DataType.StringType))
				{
					grdAddHeadcountDetails.Columns[conAHDTotalSal].Value = ReflectionHelper.GetPrimitiveValue<int>(grdAddHeadcountDetails.Columns[conAHDBudgetHC].Value) * ReflectionHelper.GetPrimitiveValue<double>(grdAddHeadcountDetails.Columns[conAHDBudgetSal].Value);
					grdAddHeadcountDetails.Columns[conAHDHeadcountLineNo].Value = grdHeadcountSummary.Columns[conHSCategoryCd].Value;
				}
				else
				{
					grdAddHeadcountDetails.Columns[conAHDTotalSal].Value = 0;
				}
				AssignGridLineNumbers(aAddHeadCountFilter);
				CalculateTotal();
			}
		}

		private void grdAddHeadcountDetails_BeforeColUpdate(object eventSender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			object OldValue = eventArgs.OldValue;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				int cnt = 0;

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (!SystemProcedure2.IsItEmpty(grdAddHeadcountDetails.Splits[0].DisplayColumns[conAHDBudgetHC], SystemVariables.DataType.StringType))
				{
					if (ColIndex == conAHDBudgetSal && StringsHelper.ToDoubleSafe(grdAddHeadcountDetails.Columns[conAHDBudgetHC].Text) < 0)
					{
						Cancel = -1;
						goto Start;
					}
					if (ColIndex == conAHDAnly4 && StringsHelper.ToDoubleSafe(grdAddHeadcountDetails.Columns[conAHDBudgetHC].Text) < 0)
					{
						Start:
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (!SystemProcedure2.IsItEmpty(grdAddHeadcountDetails.Splits[0].DisplayColumns[conAHDAnly4], SystemVariables.DataType.StringType))
						{
							int tempForEndVar = aPayrollDetFilter.GetLength(0) - 1;
							for (cnt = 0; cnt <= tempForEndVar; cnt++)
							{
								if (Convert.ToString(aPayrollDetFilter.GetValue(cnt, conPDEmpNo)) == grdAddHeadcountDetails.Columns[conAHDAnly4].Text)
								{
									//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
									grdAddHeadcountDetails.Columns[conAHDBudgetSal].Text = Convert.ToString(Convert.ToDouble(aPayrollDetFilter.GetValue(cnt, conPDBasic)) + Convert.ToDouble(aPayrollDetFilter.GetValue(cnt, conPDAllowance)));
									return;
								}
							}
							Cancel = -1;
							MessageBox.Show("Employee No doesn't exists!", "Employee Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
					}
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		private void grdHeadcountSummary_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			int mRow = 0;
			int cnt = 0;
			int mcntPay = 0;
			int mCnt = 0;
			int mCategoryCd = 0;
			XArrayHelper mTempAddHeadCount = new XArrayHelper();

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdHeadcountSummary.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdHeadcountSummary.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mRow = ReflectionHelper.GetPrimitiveValue<int>(grdHeadcountSummary.Bookmark);
				DefineVoucherArray(-1, aPayrollDetFilter, conPDMaxColumns, true);
				mcntPay = 0;
				int tempForEndVar = aPayrollDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					if (Convert.ToInt32(aPayrollDetails.GetValue(cnt, conPDHSCategoryNo)) == ReflectionHelper.GetPrimitiveValue<int>(grdHeadcountSummary.Columns[conHSCategoryCd].Value))
					{
						DefineVoucherArray(mcntPay, aPayrollDetFilter, conPDMaxColumns, false);
						aPayrollDetFilter.SetValue(aPayrollDetails.GetValue(cnt, conPDEmpNo), mcntPay, conPDEmpNo);
						aPayrollDetFilter.SetValue(aPayrollDetails.GetValue(cnt, conPDEmpName), mcntPay, conPDEmpName);
						aPayrollDetFilter.SetValue(aPayrollDetails.GetValue(cnt, conPDBasic), mcntPay, conPDBasic);
						aPayrollDetFilter.SetValue(aPayrollDetails.GetValue(cnt, conPDAllowance), mcntPay, conPDAllowance);
						aPayrollDetFilter.SetValue(aPayrollDetails.GetValue(cnt, conPDHSCategoryNo), mcntPay, conPDHSCategoryNo);
						aPayrollDetFilter.SetValue(aPayrollDetails.GetValue(cnt, conPDBillCd), mcntPay, conPDBillCd);
						aPayrollDetFilter.SetValue(aPayrollDetails.GetValue(cnt, conPDEmpCd), mcntPay, conPDEmpCd);
						mcntPay++;
					}
				}

				AssignGridLineNumbers(aPayrollDetFilter);
				grdCurrentPayroll.Rebind(true);
				grdCurrentPayroll.Refresh();
				//Call CalculateTotal

				DefineVoucherArray(-1, mTempAddHeadCount, conAHDMaxColumns, true);
				mCnt = 0;
				mCategoryCd = 0;
				mcntPay = 0;
				int tempForEndVar2 = aAddHeadCountFilter.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar2; cnt++)
				{
					DefineVoucherArray(mCnt, mTempAddHeadCount, conAHDMaxColumns, false);
					mTempAddHeadCount.SetValue(aAddHeadCountFilter.GetValue(cnt, conAHDBudgetHC), mCnt, conAHDBudgetHC);
					mTempAddHeadCount.SetValue(aAddHeadCountFilter.GetValue(cnt, conAHDBudgetSal), mCnt, conAHDBudgetSal);
					mTempAddHeadCount.SetValue(aAddHeadCountFilter.GetValue(cnt, conAHDHeadcountLineNo), mCnt, conAHDHeadcountLineNo);
					mTempAddHeadCount.SetValue(aAddHeadCountFilter.GetValue(cnt, conAHDPeriod), mCnt, conAHDPeriod);
					mTempAddHeadCount.SetValue(aAddHeadCountFilter.GetValue(cnt, conAHDTotalSal), mCnt, conAHDTotalSal);
					mTempAddHeadCount.SetValue(aAddHeadCountFilter.GetValue(cnt, conAHDAnly1), mCnt, conAHDAnly1);
					mTempAddHeadCount.SetValue(aAddHeadCountFilter.GetValue(cnt, conAHDAnly2), mCnt, conAHDAnly2);
					mTempAddHeadCount.SetValue(aAddHeadCountFilter.GetValue(cnt, conAHDAnly3), mCnt, conAHDAnly3);
					mTempAddHeadCount.SetValue(aAddHeadCountFilter.GetValue(cnt, conAHDAnly4), mCnt, conAHDAnly4);
					mTempAddHeadCount.SetValue(aAddHeadCountFilter.GetValue(cnt, conAHDAnly5), mCnt, conAHDAnly5);
					mCategoryCd = Convert.ToInt32(aAddHeadCountFilter.GetValue(cnt, conAHDHeadcountLineNo));
					mCnt++;
				}
				DefineVoucherArray(-1, aAddHeadCountFilter, conAHDMaxColumns, true);

				int tempForEndVar3 = aAddHeadCount.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar3; cnt++)
				{
					if (Convert.ToInt32(aAddHeadCount.GetValue(cnt, conAHDHeadcountLineNo)) != mCategoryCd && !SystemProcedure2.IsItEmpty(Convert.ToInt32(aAddHeadCount.GetValue(cnt, conAHDHeadcountLineNo)), SystemVariables.DataType.NumberType))
					{
						DefineVoucherArray(mCnt, mTempAddHeadCount, conAHDMaxColumns, false);
						mTempAddHeadCount.SetValue(aAddHeadCount.GetValue(cnt, conAHDBudgetHC), mCnt, conAHDBudgetHC);
						mTempAddHeadCount.SetValue(aAddHeadCount.GetValue(cnt, conAHDBudgetSal), mCnt, conAHDBudgetSal);
						mTempAddHeadCount.SetValue(aAddHeadCount.GetValue(cnt, conAHDHeadcountLineNo), mCnt, conAHDHeadcountLineNo);
						mTempAddHeadCount.SetValue(aAddHeadCount.GetValue(cnt, conAHDPeriod), mCnt, conAHDPeriod);
						mTempAddHeadCount.SetValue(aAddHeadCount.GetValue(cnt, conAHDTotalSal), mCnt, conAHDTotalSal);
						mTempAddHeadCount.SetValue(aAddHeadCount.GetValue(cnt, conAHDAnly1), mCnt, conAHDAnly1);
						mTempAddHeadCount.SetValue(aAddHeadCount.GetValue(cnt, conAHDAnly2), mCnt, conAHDAnly2);
						mTempAddHeadCount.SetValue(aAddHeadCount.GetValue(cnt, conAHDAnly3), mCnt, conAHDAnly3);
						mTempAddHeadCount.SetValue(aAddHeadCount.GetValue(cnt, conAHDAnly4), mCnt, conAHDAnly4);
						mTempAddHeadCount.SetValue(aAddHeadCount.GetValue(cnt, conAHDAnly5), mCnt, conAHDAnly5);
						mCnt++;
					}
					if (Convert.ToInt32(aAddHeadCount.GetValue(cnt, conAHDHeadcountLineNo)) == ReflectionHelper.GetPrimitiveValue<int>(grdHeadcountSummary.Columns[conHSCategoryCd].Value))
					{
						DefineVoucherArray(mcntPay, aAddHeadCountFilter, conAHDMaxColumns, false);
						aAddHeadCountFilter.SetValue(aAddHeadCount.GetValue(cnt, conAHDBudgetHC), mcntPay, conAHDBudgetHC);
						aAddHeadCountFilter.SetValue(aAddHeadCount.GetValue(cnt, conAHDBudgetSal), mcntPay, conAHDBudgetSal);
						aAddHeadCountFilter.SetValue(aAddHeadCount.GetValue(cnt, conAHDHeadcountLineNo), mcntPay, conAHDHeadcountLineNo);
						aAddHeadCountFilter.SetValue(aAddHeadCount.GetValue(cnt, conAHDPeriod), mcntPay, conAHDPeriod);
						aAddHeadCountFilter.SetValue(aAddHeadCount.GetValue(cnt, conAHDTotalSal), mcntPay, conAHDTotalSal);
						aAddHeadCountFilter.SetValue(aAddHeadCount.GetValue(cnt, conAHDAnly1), mcntPay, conAHDAnly1);
						aAddHeadCountFilter.SetValue(aAddHeadCount.GetValue(cnt, conAHDAnly2), mcntPay, conAHDAnly2);
						aAddHeadCountFilter.SetValue(aAddHeadCount.GetValue(cnt, conAHDAnly3), mcntPay, conAHDAnly3);
						aAddHeadCountFilter.SetValue(aAddHeadCount.GetValue(cnt, conAHDAnly4), mcntPay, conAHDAnly4);
						aAddHeadCountFilter.SetValue(aAddHeadCount.GetValue(cnt, conAHDAnly5), mcntPay, conAHDAnly5);
						mcntPay++;
					}
				}
				DefineVoucherArray(-1, aAddHeadCount, conAHDMaxColumns, true);
				int tempForEndVar4 = mTempAddHeadCount.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar4; cnt++)
				{
					DefineVoucherArray(cnt, aAddHeadCount, conAHDMaxColumns, false);
					aAddHeadCount.SetValue(mTempAddHeadCount.GetValue(cnt, conAHDBudgetHC), cnt, conAHDBudgetHC);
					aAddHeadCount.SetValue(mTempAddHeadCount.GetValue(cnt, conAHDBudgetSal), cnt, conAHDBudgetSal);
					aAddHeadCount.SetValue(mTempAddHeadCount.GetValue(cnt, conAHDHeadcountLineNo), cnt, conAHDHeadcountLineNo);
					aAddHeadCount.SetValue(mTempAddHeadCount.GetValue(cnt, conAHDPeriod), cnt, conAHDPeriod);
					aAddHeadCount.SetValue(mTempAddHeadCount.GetValue(cnt, conAHDTotalSal), cnt, conAHDTotalSal);
					aAddHeadCount.SetValue(mTempAddHeadCount.GetValue(cnt, conAHDAnly1), cnt, conAHDAnly1);
					aAddHeadCount.SetValue(mTempAddHeadCount.GetValue(cnt, conAHDAnly2), cnt, conAHDAnly2);
					aAddHeadCount.SetValue(mTempAddHeadCount.GetValue(cnt, conAHDAnly3), cnt, conAHDAnly3);
					aAddHeadCount.SetValue(mTempAddHeadCount.GetValue(cnt, conAHDAnly4), cnt, conAHDAnly4);
					aAddHeadCount.SetValue(mTempAddHeadCount.GetValue(cnt, conAHDAnly5), cnt, conAHDAnly5);
				}
				grdAddHeadcountDetails.Columns[conAHDBudgetSal].FooterText = "";
				grdAddHeadcountDetails.Columns[conAHDBudgetHC].FooterText = "";
				grdAddHeadcountDetails.Rebind(true);
				grdAddHeadcountDetails.Refresh();
				CalculateTotal();

			}

		}

		private void txtBudgetCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtBudgetCode");
		}

		private void txtBudgetCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtBudgetCode.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Budget_Name" : "A_Budget_Name");
					mysql = mysql + " , freezed ";
					mysql = mysql + " from Pay_Budget where Budget_No=" + txtBudgetCode.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtBudgetCode.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDBudgetName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
					}
				}
				else
				{
					txtDBudgetName.Text = "";
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void txtDeptCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtDeptCode");
		}

		private void txtDeptCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtDeptCode.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_Dept_name" : "a_Dept_name");
					mysql = mysql + " from pay_Department where Dept_no=" + txtDeptCode.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDCategoryName.Text = "";
						//txtParentDeptNo.SetFocus
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDCategoryName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
						FillHeadcountSummary();
					}
				}
				else
				{
					txtDCategoryName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			if (pObjectName == "txtBudgetCode")
			{
				txtBudgetCode.Text = "";
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220624, "2770"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtBudgetCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtBudgetCode_Leave(txtBudgetCode, new EventArgs());
				}
			}
			else if (pObjectName == "txtDeptCode")
			{ 
				txtDeptCode.Text = "";
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7001000, "727", " pd1.dept_level = 4"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDeptCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtDeptCode_Leave(txtDeptCode, new EventArgs());
				}
			}
			else
			{

			}
		}
	}
}