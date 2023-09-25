
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayBudgetRevised
		: System.Windows.Forms.Form
	{

		public frmPayBudgetRevised()
{
InitializeComponent();
} 
 public  void frmPayBudgetRevised_old()
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


		private void frmPayBudgetRevised_Activated(System.Object eventSender, System.EventArgs eventArgs)
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



		// For Addition HCDetails Column Constraint
		private const int conAHDLineNo = 0;
		private const int conAHDPeriod = 1;
		private const int conAHDBudgetHC = 2;
		private const int conAHDBudgetSal = 3;
		private const int conAHDTotalSal = 4;
		private const int conAHDAnly1 = 5;
		private const int conAHDAnly2 = 6;
		private const int conAHDAnly3 = 7;
		private const int conAHDAnly4 = 8;
		private const int conAHDAnly5 = 9;
		private const int conAHDHeadcountLineNo = 10;
		private const int conLineNo = 11;

		private const int conAHDMaxColumns = 12;

		private int mThisFormID = 0;
		private string mSearchValue = "";
		private clsToolbar oThisFormToolBar = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;


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


		private void cmdGetRecords_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				int mDeptCd = 0;
				int mBudgetCd = 0;
				int mHCCategoryCd = 0;
				string mysql = "";
				int mCnt = 0;
				int mAddHC = 0;
				int mAddPay = 0;
				int mBudgetCategoryLineNo = 0;
				object mReturnValue = null;
				SqlDataReader rsAddPay = null;

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
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("Select Budget_Cd,Freezed from Pay_Budget where Budget_No = " + txtBudgetCode.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mBudgetCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
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

				if (!SystemProcedure2.IsItEmpty(txtHCCategoryNo.Text, SystemVariables.DataType.NumberType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("Select Head_Count_Category_Cd from Pay_Head_Count_Category where Head_Count_Category_No = " + txtHCCategoryNo.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mHCCategoryCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Please enter correct HeadCount category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
				else
				{
					MessageBox.Show("Please enter HeadCount category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				mysql = " select pbc.Line_No ";
				mysql = mysql + " From Pay_Budget_Category pbc";
				mysql = mysql + " where pbc.Budget_Cd = " + mBudgetCd.ToString() + " and pbc.head_count_category_cd = " + mHCCategoryCd.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mysql = " select pbc.Head_Count_Category_Cd , pbd.Budget_Period  ,  pbd.Budget_Head_Count  , pbd.Budgeted_Salary , (pbd.Budget_Head_Count  * pbd.Budgeted_Salary) as TotalAmt";
					mysql = mysql + " ,phc.analysis1_cd, phc.analysis2_cd, phc.analysis3_cd, phc.analysis4_cd, phc.analysis5_cd, phc.Total_Budget_Salary , pbd.Line_no";
					mysql = mysql + " from Pay_Budget_Details pbd";
					mysql = mysql + " inner join Pay_Budget_Category pbc on pbc.Line_No = pbd.Budget_Category_Line_No";
					mysql = mysql + " inner join Pay_head_count phc on phc.Budget_Details_Line_No = pbd.line_no";
					mysql = mysql + " where pbc.Head_Count_Category_Cd =  " + mHCCategoryCd.ToString() + " and pbc.Budget_Cd  = " + mBudgetCd.ToString();
					SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
					rsAddPay = sqlCommand.ExecuteReader();
					rsAddPay.Read();
					mCnt = 0;
					do 
					{
						DefineVoucherArray(mCnt, aAddHeadCount, conAHDMaxColumns, false);
						aAddHeadCount.SetValue((Convert.ToDouble(rsAddPay["Total_Budget_Salary"]) > 0) ? 1 : -1, mCnt, conAHDBudgetHC);
						aAddHeadCount.SetValue(rsAddPay["Budgeted_Salary"], mCnt, conAHDBudgetSal);
						aAddHeadCount.SetValue(rsAddPay["Head_Count_Category_Cd"], mCnt, conAHDHeadcountLineNo);
						aAddHeadCount.SetValue(rsAddPay["Budget_Period"], mCnt, conAHDPeriod);
						aAddHeadCount.SetValue(rsAddPay["TotalAmt"], mCnt, conAHDTotalSal);
						aAddHeadCount.SetValue(rsAddPay["analysis1_cd"], mCnt, conAHDAnly1);
						aAddHeadCount.SetValue(rsAddPay["analysis2_cd"], mCnt, conAHDAnly2);
						aAddHeadCount.SetValue(rsAddPay["analysis3_cd"], mCnt, conAHDAnly3);
						aAddHeadCount.SetValue(rsAddPay["analysis4_cd"], mCnt, conAHDAnly4);
						aAddHeadCount.SetValue(rsAddPay["analysis5_cd"], mCnt, conAHDAnly5);
						aAddHeadCount.SetValue(rsAddPay["Line_No"], mCnt, conLineNo);
						mAddHC = Convert.ToInt32(mAddHC + Convert.ToDouble(rsAddPay["Budget_Head_Count"]));
						mAddPay = Convert.ToInt32(mAddPay + Convert.ToDouble(rsAddPay["Budgeted_Salary"]));
						mCnt++;
					}
					while(rsAddPay.Read());
				}

				AssignGridLineNumbers(aAddHeadCount);

				grdAddHeadcountDetails.Rebind(true);
				grdAddHeadcountDetails.Refresh();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
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

				//''Asssign Additional Headcount Detail Grid
				SystemGrid.DefineSystemVoucherGrid(grdAddHeadcountDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "LN", 400, false, "&HBBC8CA", ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "Period", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "Budget HC", 1300, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "Budget Salary", 1300, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "Total Salary", 1300, false, "&HBBC8CA", ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "Account", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "Div", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "Dept", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "EmployeeNo", 1300, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "AnP", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "HS Headcount No", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAddHeadcountDetails, "BugetDetLineNo", 100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				DefineVoucherArray(-1, aAddHeadCount, conAHDMaxColumns, false);
				AssignGridLineNumbers(aAddHeadCount);

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdAddHeadcountDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdAddHeadcountDetails.setArray(aAddHeadCount);
				grdAddHeadcountDetails.Rebind(true);

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
			try
			{
				SystemProcedure2.ClearTextBox(this);

				DefineVoucherArray(-1, aAddHeadCount, conAHDMaxColumns, true);

				grdAddHeadcountDetails.Columns[conAHDBudgetSal].FooterText = "";
				grdAddHeadcountDetails.Columns[conAHDBudgetHC].FooterText = "";
				grdAddHeadcountDetails.Columns[conAHDTotalSal].FooterText = "";

				grdAddHeadcountDetails.Rebind(true);
				grdAddHeadcountDetails.Refresh();

				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
				mSearchValue = ""; //Change the msearchvalue to blank
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}

		}

		public bool saveRecord()
		{
			bool result = false;
			object mReturnValue = null;
			string mysql = "";
			int cnt = 0;
			int mDeptCd = 0;
			int mBudgetCd = 0;
			int mBudgetLineNo = 0;
			int mCategoryCd = 0;

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
						mBudgetCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
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

				if (!SystemProcedure2.IsItEmpty(txtHCCategoryNo.Text, SystemVariables.DataType.NumberType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("Select Head_Count_Category_Cd from Pay_Head_Count_Category where Head_Count_Category_No = " + txtHCCategoryNo.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mCategoryCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Please enter correct HeadCount category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return result;
					}
				}
				else
				{
					MessageBox.Show("Please enter HeadCount category!!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return result;
				}

				SystemVariables.gConn.BeginTransaction();
				grdAddHeadcountDetails.UpdateData();

				mysql = "select line_no from pay_budget_Category where budget_cd = " + mBudgetCd.ToString() + " and Head_Count_Category_Cd = " + mCategoryCd.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					//' Insert Head Count Category Details
					mysql = "insert into Pay_Budget_Category(Budget_Cd , Head_Count_Category_Cd  , Opening_Head_Count , Emp_Head_Count_Salary";
					mysql = mysql + " ,Opening_Replacement_Head_Count,Emp_Replacement_Salary,Additional_Head_Count,Emp_Additional_Salary,User_Cd) ";
					mysql = mysql + "values ( " + mBudgetCd.ToString();
					mysql = mysql + " ," + mCategoryCd.ToString();
					mysql = mysql + " , 0";
					mysql = mysql + " , 0";
					mysql = mysql + " , 0";
					mysql = mysql + " , 0";
					mysql = mysql + " , 0";
					mysql = mysql + " , 0";
					mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));

					//' Insert into Payroll Budgeted Headcount Details
					int tempForEndVar = aAddHeadCount.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						mysql = " insert into Pay_Budget_Details(Budget_Category_Line_No, Budget_Period, Budget_Head_Count, Revised_Head_Count , Budgeted_Salary ,User_Cd)";
						mysql = mysql + " values (" + ReflectionHelper.GetPrimitiveValue<int>(mReturnValue).ToString();
						mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDPeriod)) + "'";
						mysql = mysql + " , 0";
						mysql = mysql + " ," + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDBudgetHC));
						mysql = mysql + " ," + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDBudgetSal));
						mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
						mysql = mysql + " )";
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();

						mBudgetLineNo = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));

						mysql = " insert into pay_head_count (head_count_no,head_count_category_cd,emp_cd,is_budgeted";
						mysql = mysql + " ,budget_details_line_no,head_count_status,user_cd,user_date_time , Total_Budget_Salary";
						mysql = mysql + " ,analysis1_cd, analysis2_cd, analysis3_cd, analysis4_cd, analysis5_cd)";
						mysql = mysql + " values(" + SystemProcedure2.GetNewNumber("Pay_Head_count", "Head_count_No");
						mysql = mysql + " ," + mCategoryCd.ToString();
						mysql = mysql + " ,NULL , 1 , " + mBudgetLineNo.ToString() + " , 1";
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
						SqlCommand TempCommand_3 = null;
						TempCommand_3 = SystemVariables.gConn.CreateCommand();
						TempCommand_3.CommandText = mysql;
						TempCommand_3.ExecuteNonQuery();
					}
				}
				else
				{
					//' Insert into Payroll Budgeted Headcount Details
					int tempForEndVar2 = aAddHeadCount.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar2; cnt++)
					{
						if (SystemProcedure2.IsItEmpty(aAddHeadCount.GetValue(cnt, conAHDHeadcountLineNo), SystemVariables.DataType.StringType))
						{
							mysql = " insert into Pay_Budget_Details(Budget_Category_Line_No, Budget_Period, Budget_Head_Count,Revised_Head_Count , Budgeted_Salary ,User_Cd)";
							mysql = mysql + " values (" + ReflectionHelper.GetPrimitiveValue<int>(mReturnValue).ToString();
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDPeriod)) + "'";
							mysql = mysql + " , 0 ";
							mysql = mysql + " ," + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDBudgetHC));
							mysql = mysql + " ," + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDBudgetSal));
							mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
							mysql = mysql + " )";
							SqlCommand TempCommand_4 = null;
							TempCommand_4 = SystemVariables.gConn.CreateCommand();
							TempCommand_4.CommandText = mysql;
							TempCommand_4.ExecuteNonQuery();

							mBudgetLineNo = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));

							mysql = " insert into pay_head_count (head_count_no,head_count_category_cd,emp_cd,is_budgeted";
							mysql = mysql + " ,budget_details_line_no,head_count_status,user_cd,user_date_time , Total_Budget_Salary";
							mysql = mysql + " ,analysis1_cd, analysis2_cd, analysis3_cd, analysis4_cd, analysis5_cd)";
							mysql = mysql + " values(" + SystemProcedure2.GetNewNumber("Pay_Head_count", "Head_count_No");
							mysql = mysql + " ," + mCategoryCd.ToString();
							mysql = mysql + " ,NULL , 1 , " + mBudgetLineNo.ToString() + " , 1";
							mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
							mysql = mysql + " ,'" + DateTime.Today.ToString("dd-MMM-yyyy") + "'";
							if (Convert.ToDouble(aAddHeadCount.GetValue(cnt, conAHDBudgetHC)) > 0)
							{
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								mysql = mysql + " , " + ((Convert.IsDBNull(aAddHeadCount.GetValue(cnt, conAHDBudgetSal))) ? "0" : Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDBudgetSal)));
							}
							else
							{
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								mysql = mysql + " , " + (((Convert.IsDBNull(aAddHeadCount.GetValue(cnt, conAHDBudgetSal))) ? 0 : Convert.ToDouble(aAddHeadCount.GetValue(cnt, conAHDBudgetSal))) * -1).ToString();
							}
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDAnly1)) + "'";
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDAnly2)) + "'";
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDAnly3)) + "'";
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDAnly4)) + "'";
							mysql = mysql + " ,'" + Convert.ToString(aAddHeadCount.GetValue(cnt, conAHDAnly5)) + "'";
							mysql = mysql + " )";
							SqlCommand TempCommand_5 = null;
							TempCommand_5 = SystemVariables.gConn.CreateCommand();
							TempCommand_5.CommandText = mysql;
							TempCommand_5.ExecuteNonQuery();
						}
						else
						{
							if (!SystemProcedure2.IsItEmpty(aAddHeadCount.GetValue(cnt, conLineNo), SystemVariables.DataType.NumberType) && Convert.ToDouble(aAddHeadCount.GetValue(cnt, conAHDBudgetHC)) == 0)
							{
								mysql = "delete from pay_head_count";
								mysql = mysql + " where budget_details_line_no = " + Convert.ToInt32(aAddHeadCount.GetValue(cnt, conLineNo)).ToString();
								SqlCommand TempCommand_6 = null;
								TempCommand_6 = SystemVariables.gConn.CreateCommand();
								TempCommand_6.CommandText = mysql;
								TempCommand_6.ExecuteNonQuery();

								mysql = " update Pay_Budget_Details";
								mysql = mysql + " set  Revised_Head_Count = -1 ";
								mysql = mysql + " where Budget_Category_Line_No = " + Convert.ToString(aAddHeadCount.GetValue(cnt, conLineNo));
								SqlCommand TempCommand_7 = null;
								TempCommand_7 = SystemVariables.gConn.CreateCommand();
								TempCommand_7.CommandText = mysql;
								TempCommand_7.ExecuteNonQuery();
							}
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
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aAddHeadCount.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aAddHeadCount.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdAddHeadcountDetails.Bookmark), 1);
				AssignGridLineNumbers(aAddHeadCount);
				grdAddHeadcountDetails.Rebind(true);
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdAddHeadcountDetails" && grdAddHeadcountDetails.Enabled)
			{
				grdAddHeadcountDetails.Focus();
			}

			if (aAddHeadCount.GetLength(0) > 0)
			{
				if (SystemProcedure2.IsItEmpty(aAddHeadCount.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdAddHeadcountDetails.Bookmark), conLineNo), SystemVariables.DataType.NumberType))
				{
					grdAddHeadcountDetails.Delete();
					AssignGridLineNumbers(aAddHeadCount);
					grdAddHeadcountDetails.Rebind(true);
				}
				else
				{
					MessageBox.Show("Budgeted Item cannot delete make headcount zero!", "Budget Revised", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
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
			else if (pObjectName == "txtHCCategoryNo")
			{ 
				txtHCCategoryNo.Text = "";
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220622, "2755"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtHCCategoryNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtHCCategoryNo_Leave(txtHCCategoryNo, new EventArgs());
				}
			}
			else
			{

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

		private void txtHCCategoryNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtHCCategoryNo");
		}

		private void txtHCCategoryNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtHCCategoryNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Head_Count_Category_Name" : "A_Head_Count_Category_Name");
					mysql = mysql + " from Pay_Head_Count_Category where Head_Count_Category_No=" + txtHCCategoryNo.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtHCCategoryName.Text = "";
						//txtParentDeptNo.SetFocus
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtHCCategoryName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtHCCategoryName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}
	}
}