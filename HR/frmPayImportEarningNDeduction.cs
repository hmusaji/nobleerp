
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers;



namespace Xtreme
{
	internal partial class frmPayImportEarningNDeduction
		: System.Windows.Forms.Form
	{

		public frmPayImportEarningNDeduction()
{
InitializeComponent();
} 
 public  void frmPayImportEarningNDeduction_old()
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
			
			InitExtendedProperties();
		}
		void InitExtendedProperties()
		{
			this.grdMigrate2.setScrollTips(false);
		}


		private void frmPayImportEarningNDeduction_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		 //This class checks for the rights given to the user



		public int ThisFormId
		{
			get
			{
				object mThisFormID = null;
				return ReflectionHelper.GetPrimitiveValue<int>(mThisFormID);
			}
			set
			{
				int mThisFormID = value;
			}
		}


		private void btnLoadGrid_Click(Object eventSender, EventArgs eventArgs)
		{
			clsHourGlass mHourGlass = null;
			try
			{
				mHourGlass = null;
				int ImportType = 0;
				int i = 0;
				int j = 0;


				grdMigrate2.Cols.Fixed = 1;
				grdMigrate2.Rows.Fixed = 1;
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				CommonDialog1Open.FileName = "";
				//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property CommonDialog1.Flags was upgraded to CommonDialog1Open.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
				//UPGRADE_WARNING: (2074) FileOpenConstants STRING RESOURCE ["IDS-CONSTANT"] NOT FOUND FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
				CommonDialog1Open.ShowReadOnly = false;
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				CommonDialog1Open.Filter = "Text (*.txt)|*.txt|Excel (*.xls)|*.xls";
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FilterIndex was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				CommonDialog1Open.FilterIndex = 2;
				CommonDialog1Open.ShowDialog();


				mHourGlass = new clsHourGlass();

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (CommonDialog1Open.FileName != "")
				{
					//UPGRADE_ISSUE: (2064) VSFlex8.SaveLoadSettings property SaveLoadSettings.flexFileExcel was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid method grdMigrate2.LoadGrid was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdMigrate2.LoadGrid(CommonDialog1Open.FileName, UpgradeStubs.VSFlex8_SaveLoadSettings.getflexFileExcel(), null);
				}
				else
				{
					return;
				}
				grdMigrate2.Rows.Fixed = 1;
				GenerateSRNO();
				grdMigrate2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;

				grdMigrate2.setCellText("EmpNo", 0, 1);
				grdMigrate2.setCellText("Bill_No", 0, 2);
				grdMigrate2.setCellText("Days", 0, 3);
				grdMigrate2.setCellText("Hours", 0, 4);
				grdMigrate2.setCellText("Amount", 0, 5);

				btnDeleteLine_Click(btnDeleteLine, new EventArgs());

				mHourGlass = null;
			}
			catch (System.Exception excep)
			{
				mHourGlass = null;
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void GenerateSRNO()
		{
			clsHourGlass mHourGlass = new clsHourGlass();
			int i = 0;
			grdMigrate2.Cols[0].WidthDisplay = 53;

			int tempForEndVar = grdMigrate2.Rows.Count - 1;
			for (i = 1; i <= tempForEndVar; i++)
			{
				grdMigrate2.setCellText(i.ToString(), i, 0);
			}
		}

		private int GetBillCd(int pBillNo)
		{

			string mysql = "select bill_cd from pay_billing_type where bill_no = " + pBillNo.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				return ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}
			else
			{
				return 0;
			}

		}

		private void cmdMigrate_Click(Object eventSender, EventArgs eventArgs)
		{
			int i = 0;
			try
			{
				string mErrorIn = "";
				StringBuilder mysql = new StringBuilder();
				object mReturnValue = null;
				int mMasterEntId = 0;
				int mEmpCd = 0;
				int mBill_cd = 0;
				string mFileName = "";
				string mGenerateDate = "";

				mFileName = "C:\\ImportEarning-Deduction_" + DateAndTime.Day(DateTime.Today).ToString() + "_" + DateTime.Today.Year.ToString() + ".txt";
				FileSystem.FileClose(1);
				FileSystem.FileOpen(1, mFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);

				SystemVariables.gConn.BeginTransaction();

				if (MessageBox.Show("You are going to Import Earning & Deduction!", "Importing...", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
				{
					mErrorIn = "";
					mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();

					lblProgress.Text = "Updating Record No......";
					int tempForEndVar = grdMigrate2.Rows.Count - 1;
					for (i = 1; i <= tempForEndVar; i++)
					{
						if (chkExcludeLeaveEmployee.CheckState == CheckState.Checked)
						{
							mEmpCd = SystemHRProcedure.GetEmpCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)), " status_cd not in (2,3,4) and Is_Payroll_Emp = 1 ");
						}
						else
						{
							mEmpCd = SystemHRProcedure.GetEmpCd(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)), " status_cd not in (3,4) and Is_Payroll_Emp = 1 ");
						}

						if (mEmpCd != 0)
						{
							mBill_cd = GetBillCd(ReflectionHelper.GetPrimitiveValue<int>(grdMigrate2.getCellText(i, 2)));
							mMasterEntId = SystemHRProcedure.GetPayrollMasterEntryID(mGenerateDate, mEmpCd);
							if (mBill_cd != 0)
							{
								mysql = new StringBuilder("insert into Pay_Payroll([Pay_Date],[Emp_Cd],[Bill_Cd],[Curr_Cd],[Dept_Cd],[Desg_Cd],[Comp_Cd]");
								mysql.Append("    ,[Billing_Mode],[Pay_Hours],[Pay_Days],[Exchange_Rate],[FC_Amount]");
								mysql.Append("    ,[Trans_Type],[Trans_Id],[Rate_Calc_Method_Id],[Weekend],[Weekend_Day1_Id],[Weekend_Day2_Id]");
								mysql.Append("    ,[Days_Per_Month],[Total_Salary],[Hours_Per_Day],[Normal_OT],[Friday_OT],[Holiday_OT]");
								mysql.Append("    ,[Payment_Type_Id],[Bank_Cd],[Bank_Branch_Cd],[Bank_Account_No],[Is_Pay_Closed]");
								mysql.Append("    ,[User_Cd],[Sponsor_cd],[project_cd],Master_Entry_ID)");
								mysql.Append(" select '" + mGenerateDate + "' , [Emp_Cd], " + mBill_cd.ToString());
								mysql.Append("   ,[Curr_Cd],[Dept_Cd],[Desg_Cd],[Comp_Cd] ");
								mysql.Append("    ,'M'," + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 4)) + ", " + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 3)) + ",1," + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 5)));
								mysql.Append("    ,Null,Null,[Rate_Calc_Method_Id],[Weekend],[Weekend_Day1_Id],[Weekend_Day2_Id]");
								mysql.Append("    ,[Days_Per_Month],[Total_Salary],[Hours_Per_Day],[Normal_OT],[Friday_OT],[Holiday_OT]");
								mysql.Append("    ,[Payment_Type_Id],[Bank_Cd],[Bank_Branch_Cd],[Bank_Account_No],0");
								mysql.Append("    ,[User_Cd],[Sponsor_cd], Default_Project , " + mMasterEntId.ToString());
								mysql.Append(" from Pay_Employee ");
								mysql.Append(" Where emp_cd = " + mEmpCd.ToString());
								SqlCommand TempCommand = null;
								TempCommand = SystemVariables.gConn.CreateCommand();
								TempCommand.CommandText = mysql.ToString();
								TempCommand.ExecuteNonQuery();
							}
							else
							{
								FileSystem.PrintLine(1, "Bill No " + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 2)) + " does not Exists in line no : " + i.ToString());
							}
						}
						else
						{
							FileSystem.PrintLine(1, "Emp No " + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)) + " does not Exists in line no : " + i.ToString());
						}
						lblProgress.Text = "Updating Record No...... " + i.ToString();
					}
				}
				lblProgress.Text = i.ToString() + " Record Imported.";
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				FileSystem.FileClose(1);
				MessageBox.Show("Import Done Successfully!", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Form_Closed(this, new CancelEventArgs());
			}
			catch (System.Exception excep)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(excep.Message + " - " + Information.Err().Number.ToString(), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				FileSystem.FileClose(1);
			}
		}

		private void cmdVerify_Click()
		{
			int i = 0;
			int tempForEndVar = grdMigrate2.Rows.Count - 1;
			for (i = 2; i <= tempForEndVar; i++)
			{
				if (SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(i, 1), SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Employee Code cannot be blank in line no: " + i.ToString() + "!", "Importing Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				if (SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(i, 2), SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Bill no cannot be blank or zero in line no: " + i.ToString() + "!", "Importing Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(grdMigrate2.getCellText(i, 3)))
				{
					grdMigrate2.setCellText("0", i, 3);
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(grdMigrate2.getCellText(i, 4)))
				{
					grdMigrate2.setCellText("0", i, 4);
				}
				if (SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(i, 5), SystemVariables.DataType.NumberType))
				{
					grdMigrate2.setCellText("0", i, 5);
				}
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			txtDMonthDate.Value = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate());
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				UserAccess = null;
				frmPayImportEarningNDeduction.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void CloseForm()
		{
			Form_Closed(this, new CancelEventArgs());
		}

		private void btnDeleteLine_Click(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int i = 0;
				int LastRow = grdMigrate2.RowSel;
				//grdMigrate2.RemoveItem (grdMigrate2.RowSel)
				int tempForEndVar = grdMigrate2.RowSel;
				for (i = grdMigrate2.Row; i <= tempForEndVar; i++)
				{
					grdMigrate2.RemoveItem(LastRow);
					LastRow--;
				}
				GenerateSRNO();
				//Call GridResize(, True)
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			grdMigrate2.Width = this.Width - 18;
			grdMigrate2.Height = this.Height - (grdMigrate2.Top + 40);

		}
	}
}