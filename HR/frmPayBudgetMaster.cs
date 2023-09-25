
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayBudgetMaster
		: System.Windows.Forms.Form
	{

		public frmPayBudgetMaster()
{
InitializeComponent();
} 
 public  void frmPayBudgetMaster_old()
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


		private void frmPayBudgetMaster_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

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


		private void cmdRefreshCategory_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				int mBudgetCd = 0;
				int mHCCategoryCd = 0;
				object mReturnValue = null;
				SqlDataReader rsLocal = null;
				string mysql = "";
				double mTotalYearSalary = 0;
				DialogResult ans = (DialogResult) 0;

				ans = MessageBox.Show("Do you want to refresh category details for current budget.", "Budget Update", MessageBoxButtons.YesNo);
				if (ans == System.Windows.Forms.DialogResult.Yes)
				{
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
								return;
							}
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

					SystemVariables.gConn.BeginTransaction();

					mysql = " select p.l_dept_name , p.Head_Count_Category_Cd,p.L_Head_Count_Category_Name , SUM(p.CHC) as CHC , SUM(p.CHCP) as CHCP , SUM(p.RHC) as RHC, SUM(p.RHCP) as RHCP";
					mysql = mysql + " From";
					mysql = mysql + " (";
					mysql = mysql + " select pd.l_dept_name, phcc.Head_Count_Category_Cd, phcc.L_Head_Count_Category_Name  , count(Distinct phc.Emp_Cd) as CHC , SUM(pebd.Amount) as CHCP , 0 as RHC , 0 RHCP";
					mysql = mysql + " from Pay_Head_Count phc ";
					mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
					mysql = mysql + " inner join Pay_Department pd on pd.Dept_Cd = phcc.Dept_Cd ";
					mysql = mysql + " inner join Pay_Employee_Billing_Details pebd on pebd.Emp_Cd = phc.Emp_Cd ";
					mysql = mysql + " where phc.Head_Count_Status = 2 ";
					mysql = mysql + " group by phcc.Head_Count_Category_Cd, phcc.L_Head_Count_Category_Name , phc.Head_Count_Status , pd.l_dept_name";
					mysql = mysql + " Union All";
					mysql = mysql + " select pd.l_dept_name, phcc.Head_Count_Category_Cd, phcc.L_Head_Count_Category_Name  , 0 as CHC , 0 as CHCP , count(Distinct phc.Emp_Cd) as RHC , SUM(pebd.Amount) RHCP";
					mysql = mysql + " from Pay_Head_Count phc";
					mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
					mysql = mysql + " inner join Pay_Department pd on pd.Dept_Cd = phcc.Dept_Cd";
					mysql = mysql + " inner join Pay_Employee_Billing_Details pebd on pebd.Emp_Cd = phc.Emp_Cd";
					mysql = mysql + " where phc.Head_Count_Status = 3 ";
					mysql = mysql + " group by phcc.Head_Count_Category_Cd, phcc.L_Head_Count_Category_Name , phc.Head_Count_Status , pd.l_dept_name";
					mysql = mysql + "  ) as p";
					mysql = mysql + " group by p.l_dept_name , p.Head_Count_Category_Cd ,p.L_Head_Count_Category_Name";
					mysql = mysql + " order by 1";

					SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
					rsLocal = sqlCommand.ExecuteReader();
					rsLocal.Read();
					do 
					{
						mysql = " select line_No from Pay_Budget_Category where Budget_Cd = " + mBudgetCd.ToString() + " and Head_Count_Category_Cd = " + Convert.ToString(rsLocal["Head_Count_Category_Cd"]);
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue))
						{
							mysql = "insert into Pay_Budget_Category(Budget_Cd , Head_Count_Category_Cd  , Opening_Head_Count , Emp_Head_Count_Salary";
							mysql = mysql + " ,Opening_Replacement_Head_Count,Emp_Replacement_Salary,Additional_Head_Count,Emp_Additional_Salary,User_Cd) ";
							mysql = mysql + "values ( " + mBudgetCd.ToString();
							mysql = mysql + " ," + Convert.ToString(rsLocal["Head_Count_Category_Cd"]);
							mysql = mysql + " ," + Convert.ToString(rsLocal["CHC"]);
							mysql = mysql + " ," + Convert.ToString(rsLocal["CHCP"]);
							mysql = mysql + " ," + Convert.ToString(rsLocal["RHC"]);
							mysql = mysql + " ," + Convert.ToString(rsLocal["RHCP"]);
							mysql = mysql + " , 0";
							mysql = mysql + " , 0";
							mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
							mysql = mysql + " )";
							SqlCommand TempCommand = null;
							TempCommand = SystemVariables.gConn.CreateCommand();
							TempCommand.CommandText = mysql;
							TempCommand.ExecuteNonQuery();


							mysql = "INSERT INTO Pay_Budget_Payroll_Details";
							mysql = mysql + " (Budget_Category_Line_No,Bill_cd,Amount,User_Cd,User_Date_Time,Emp_cd)";
							mysql = mysql + " select pbd.Line_No , pbt.Bill_Cd , pebd.Amount  , 1 ucode , GETDATE() as InsDate , phc.Emp_Cd";
							mysql = mysql + " from Pay_Head_Count phc";
							mysql = mysql + " inner join Pay_Budget_Category pbd on pbd.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
							mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
							mysql = mysql + " inner join Pay_Department pd on pd.Dept_Cd = phcc.Dept_Cd";
							mysql = mysql + " inner join Pay_Employee pemp on pemp.Emp_Cd = phc.Emp_Cd";
							mysql = mysql + " inner join Pay_Employee_Billing_Details pebd on pebd.Emp_Cd = phc.Emp_Cd";
							mysql = mysql + " inner join Pay_Billing_Type pbt on pbt.Bill_Cd = pebd.Bill_Cd";
							mysql = mysql + " where phc.Head_Count_Status in (2) and phc.Head_Count_Category_Cd = " + Convert.ToString(rsLocal["Head_Count_Category_Cd"]);
							SqlCommand TempCommand_2 = null;
							TempCommand_2 = SystemVariables.gConn.CreateCommand();
							TempCommand_2.CommandText = mysql;
							TempCommand_2.ExecuteNonQuery();

						}
					}
					while(rsLocal.Read());

					//Insert in current payroll details


					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();
					MessageBox.Show("Refresh Payroll done successfull!", "Budget", MessageBoxButtons.OK, MessageBoxIcon.Information);

				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void cmdRefreshPayroll_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				int mBudgetCd = 0;
				int mHCCategoryCd = 0;
				object mReturnValue = null;
				SqlDataReader rsLocal = null;
				string mysql = "";
				double mTotalYearSalary = 0;
				DialogResult ans = (DialogResult) 0;
				ans = MessageBox.Show("Do you want to refresh payroll details for current budget.", "Budget Update", MessageBoxButtons.YesNo);
				if (ans == System.Windows.Forms.DialogResult.Yes)
				{
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
								return;
							}
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

					SystemVariables.gConn.BeginTransaction();

					mysql = " update Pay_Budget_Category ";
					mysql = mysql + " Set Opening_Replacement_Head_Count = 0 ";
					mysql = mysql + " , Opening_Head_Count = 0 ";
					mysql = mysql + " , Emp_Replacement_Salary = 0 ";
					mysql = mysql + " , Emp_Head_Count_Salary = 0 ";
					mysql = mysql + " Where Budget_Cd = " + mBudgetCd.ToString();
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mysql = " select p.l_dept_name , p.Head_Count_Category_Cd,p.L_Head_Count_Category_Name , SUM(p.CHC) as CHC , SUM(p.CHCP) as CHCP , SUM(p.RHC) as RHC, SUM(p.RHCP) as RHCP";
					mysql = mysql + " From";
					mysql = mysql + " (";
					mysql = mysql + " select pd.l_dept_name, phcc.Head_Count_Category_Cd, phcc.L_Head_Count_Category_Name  , count(Distinct phc.Emp_Cd) as CHC , SUM(pebd.Amount) as CHCP , 0 as RHC , 0 RHCP";
					mysql = mysql + " from Pay_Head_Count phc ";
					mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
					mysql = mysql + " inner join Pay_Department pd on pd.Dept_Cd = phcc.Dept_Cd ";
					mysql = mysql + " inner join Pay_Employee_Billing_Details pebd on pebd.Emp_Cd = phc.Emp_Cd ";
					mysql = mysql + " where phc.Head_Count_Status = 2 ";
					mysql = mysql + " group by phcc.Head_Count_Category_Cd, phcc.L_Head_Count_Category_Name , phc.Head_Count_Status , pd.l_dept_name";
					mysql = mysql + " Having Count(phc.Emp_Cd) > 0";
					mysql = mysql + " Union All";
					mysql = mysql + " select pd.l_dept_name, phcc.Head_Count_Category_Cd, phcc.L_Head_Count_Category_Name  , 0 as CHC , 0 as CHCP , count(Distinct phc.Emp_Cd) as RHC , SUM(pebd.Amount) RHCP";
					mysql = mysql + " from Pay_Head_Count phc";
					mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
					mysql = mysql + " inner join Pay_Department pd on pd.Dept_Cd = phcc.Dept_Cd";
					mysql = mysql + " inner join Pay_Employee_Billing_Details pebd on pebd.Emp_Cd = phc.Emp_Cd";
					mysql = mysql + " where phc.Head_Count_Status = 3 ";
					mysql = mysql + " group by phcc.Head_Count_Category_Cd, phcc.L_Head_Count_Category_Name , phc.Head_Count_Status , pd.l_dept_name";
					mysql = mysql + " Having Count(phc.Emp_Cd) > 0";
					mysql = mysql + "  ) as p";
					mysql = mysql + " group by p.l_dept_name , p.Head_Count_Category_Cd ,p.L_Head_Count_Category_Name";
					mysql = mysql + " order by 1";

					SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
					rsLocal = sqlCommand.ExecuteReader();
					rsLocal.Read();
					do 
					{
						mysql = " select line_No from Pay_Budget_Category where Budget_Cd = " + mBudgetCd.ToString() + " and Head_Count_Category_Cd = " + Convert.ToString(rsLocal["Head_Count_Category_Cd"]);
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							mysql = "Update Pay_Budget_Category";
							mysql = mysql + " set Opening_Head_Count = " + Convert.ToString(rsLocal["CHC"]);
							mysql = mysql + " , Emp_Head_Count_Salary = " + Convert.ToString(rsLocal["CHCP"]);
							mysql = mysql + " , Opening_Replacement_Head_Count = " + Convert.ToString(rsLocal["RHC"]);
							mysql = mysql + " , Emp_Replacement_Salary = " + Convert.ToString(rsLocal["RHCP"]);
							mysql = mysql + " where Head_Count_Category_Cd = " + Convert.ToString(rsLocal["Head_Count_Category_Cd"]);
							mysql = mysql + " and Budget_Cd = " + mBudgetCd.ToString();

							//''Added by hakim on 08-dec-2012..it was missing.
							SqlCommand TempCommand_2 = null;
							TempCommand_2 = SystemVariables.gConn.CreateCommand();
							TempCommand_2.CommandText = mysql;
							TempCommand_2.ExecuteNonQuery();
						}
						else
						{
							mysql = "insert into Pay_Budget_Category(Budget_Cd , Head_Count_Category_Cd  , Opening_Head_Count , Emp_Head_Count_Salary";
							mysql = mysql + " ,Opening_Replacement_Head_Count,Emp_Replacement_Salary,Additional_Head_Count,Emp_Additional_Salary,User_Cd) ";
							mysql = mysql + "values ( " + mBudgetCd.ToString();
							mysql = mysql + " ," + Convert.ToString(rsLocal["Head_Count_Category_Cd"]);
							mysql = mysql + " ," + Convert.ToString(rsLocal["CHC"]);
							mysql = mysql + " ," + Convert.ToString(rsLocal["CHCP"]);
							mysql = mysql + " ," + Convert.ToString(rsLocal["RHC"]);
							mysql = mysql + " ," + Convert.ToString(rsLocal["RHCP"]);
							mysql = mysql + " , 0";
							mysql = mysql + " , 0";
							mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
							mysql = mysql + " )";
							SqlCommand TempCommand_3 = null;
							TempCommand_3 = SystemVariables.gConn.CreateCommand();
							TempCommand_3.CommandText = mysql;
							TempCommand_3.ExecuteNonQuery();
						}
					}
					while(rsLocal.Read());

					//Insert in current payroll details
					mysql = " delete from Pay_Budget_Payroll_Details ";
					mysql = mysql + " from Pay_Budget_Payroll_Details pbpd ";
					mysql = mysql + " inner join pay_budget_category pbc on pbc.Line_No = pbpd.Budget_Category_Line_No";
					mysql = mysql + " Where pbc.budget_cd = " + mBudgetCd.ToString();
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();

					mysql = "INSERT INTO Pay_Budget_Payroll_Details";
					mysql = mysql + " (Budget_Category_Line_No,Bill_cd,Amount,User_Cd,User_Date_Time,Emp_cd ";
					mysql = mysql + " , analysis1_cd , analysis2_cd , analysis3_cd , analysis4_cd ,analysis5_cd ,HeadCountStatus ) ";
					mysql = mysql + " select pbd.Line_No , pbt.Bill_Cd , pebd.Amount  , 1 ucode , GETDATE() as InsDate , phc.Emp_Cd";
					mysql = mysql + " , pemp.Analysis1 , pemp.Analysis2, pemp.Analysis3, pemp.Analysis4, pemp.Analysis5,  phc.Head_Count_Status ";
					mysql = mysql + " from Pay_Head_Count phc";
					mysql = mysql + " inner join Pay_Budget_Category pbd on pbd.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
					mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
					mysql = mysql + " inner join Pay_Department pd on pd.Dept_Cd = phcc.Dept_Cd";
					mysql = mysql + " inner join Pay_Employee pemp on pemp.Emp_Cd = phc.Emp_Cd";
					mysql = mysql + " inner join Pay_Employee_Billing_Details pebd on pebd.Emp_Cd = phc.Emp_Cd";
					mysql = mysql + " inner join Pay_Billing_Type pbt on pbt.Bill_Cd = pebd.Bill_Cd";
					mysql = mysql + " where phc.Head_Count_Status in (2) and pbt.Include_In_Budget = 1 ";
					mysql = mysql + " and pbd.budget_cd = " + mBudgetCd.ToString();
					SqlCommand TempCommand_5 = null;
					TempCommand_5 = SystemVariables.gConn.CreateCommand();
					TempCommand_5.CommandText = mysql;
					TempCommand_5.ExecuteNonQuery();

					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();
					MessageBox.Show("Refresh Payroll done successfull!", "Budget", MessageBoxButtons.OK, MessageBoxIcon.Information);

				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			FirstFocusObject = txtBudgetCode;

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
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = false;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);

				//assign a next code
				txtBudgetCode.Text = SystemProcedure2.GetNewNumber("Pay_Budget", "Budget_No");
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
			txtBudgetCode.Text = SystemProcedure2.GetNewNumber("Pay_Budget", "Budget_No");
			txtStartDate.Value = "01-Jan-2011";
			txtEndDate.Value = "31-Dec-2011";
			chkFreezed.CheckState = CheckState.Unchecked;
			cmdRefreshCategory.Enabled = false;
			cmdRefreshPayroll.Enabled = false;

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			FirstFocusObject.Focus();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord()
		{
			bool result = false;
			string mysql = "";
			try
			{

				SystemVariables.gConn.BeginTransaction();
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into Pay_Budget(User_Cd , Budget_No, L_Budget_Name";
					mysql = mysql + " , A_Budget_Name  ";
					mysql = mysql + " , Budget_Start_Date ,Budget_End_Date , Freezed)";
					mysql = mysql + " VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + ",'" + txtBudgetCode.Text + "'";
					mysql = mysql + ",'" + txtLBudgetName.Text + "'";
					mysql = mysql + ",N'" + txtABudgetName.Text + "'";
					mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDate.Value) + "'";
					mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtEndDate.Value) + "'";
					mysql = mysql + "," + ((int) chkFreezed.CheckState).ToString();
					mysql = mysql + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

				}
				else
				{
					mysql = "update Pay_Budget  ";
					mysql = mysql + " set Budget_No ='" + txtBudgetCode.Text + "'";
					mysql = mysql + " , L_Budget_Name ='" + txtLBudgetName.Text + "'";
					mysql = mysql + " , A_Budget_Name =N'" + txtABudgetName.Text + "'";
					mysql = mysql + " , Budget_Start_Date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDate.Value) + "'";
					mysql = mysql + " , Budget_End_Date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtEndDate.Value) + "'";
					mysql = mysql + " , Modified_By_User_Cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " , Modified_By_Date_Time='" + DateTime.Today.ToString("dd-MMM-yyyy") + "'";
					mysql = mysql + " , freezed = " + ((int) chkFreezed.CheckState).ToString();
					mysql = mysql + " where Budget_Cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				FirstFocusObject.Focus();
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

		public bool deleteRecord()
		{
			bool result = false;

			//If an error occurs, trap the error and dispaly a valid message
			SystemVariables.gConn.BeginTransaction();

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "delete from Pay_Budget where Budget_Cd=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Budget master cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				return true;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					AddRecord();
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
			return result;
		}

		public void GetRecord(object SearchValue)
		{
			try
			{
				string mysql = "";
				object mReturnValue = null;
				SqlDataReader localRec = null;

				mysql = " select * from Pay_Budget  where Budget_Cd= " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{
					mSearchValue = localRec["Budget_Cd"];
					txtBudgetCode.Text = Convert.ToString(localRec["Budget_No"]);
					txtLBudgetName.Text = Convert.ToString(localRec["L_Budget_Name"]);
					txtABudgetName.Text = Convert.ToString(localRec["A_Budget_Name"]) + "";
					txtStartDate.Value = localRec["Budget_Start_Date"];
					txtEndDate.Value = localRec["Budget_End_Date"];
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkFreezed.CheckState = (CheckState) ((Convert.ToBoolean(localRec["Freezed"])) ? 1 : 0);
					if (Convert.ToBoolean(localRec["freezed"]))
					{
						cmdRefreshCategory.Enabled = false;
						cmdRefreshPayroll.Enabled = false;
					}
					else
					{
						cmdRefreshCategory.Enabled = true;
						cmdRefreshPayroll.Enabled = true;
					}
					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				}
				localRec.Close();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}

		}

		public void PrintReport()
		{

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220624));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool CheckDataValidity()
		{
			//Check validation during update and add of records
			if (SystemProcedure2.IsItEmpty(txtBudgetCode.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Budget Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstFocusObject.Focus();
				return false;
			}
			return true;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				UserAccess = null;
				oThisFormToolBar = null;
				frmPayDesignation.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}
	}
}