
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayGenerateBankFile
		: System.Windows.Forms.Form
	{

		public frmPayGenerateBankFile()
{
InitializeComponent();
} 
 public  void frmPayGenerateBankFile_old()
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


		private void frmPayGenerateBankFile_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		int mThisFormID = 0;
		object mSearchValue = null;
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


		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		public Control FirstFocusObject = null;
		double HashTot = 0;


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


		private void chkSelectAll_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			if (chkSelectAll.CheckState == CheckState.Checked)
			{
				txtFromEmpNo.Text = "";
				txtFromEmpName.Text = "";
				txtFromEmpNo.Enabled = false;

				txtToEmpNo.Text = "";
				txtToEmpName.Text = "";
				txtToEmpNo.Enabled = false;
			}
			else
			{
				txtFromEmpNo.Enabled = true;
				txtToEmpNo.Enabled = true;
			}

		}

		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			//On Error GoTo eFoundError

			int i = 0;
			int mTotalRecords = 0;
			decimal mTotalSalary = 0;

			string mFileName = "";
			int mBankCd = 0;

			string mCompanyAccountNo = "";
			int mDownloadFormat = 0;
			string mCompanyFileInitial = "";
			string mCompanyName = "";
			string mStandardBankCd = "";
			string mDownloadPath = "";
			int mEntryId = 0;
			string mPSCode = "";
			string mHSBCNetID = "";
			string mHSBCCustID = ""; // Not in use
			string mHSBCBankCd = "";
			string mBankUniueCd = "";
			string mHSBCStandardBankCd = ""; // Hexagon ABC Customer ID
			int mBankDiskGenerate = 0;
			clsHourGlass myHourGlass = new clsHourGlass();

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_Leave_Bank_Disk")))
			{
				if (GenerateOption[0].Checked)
				{
					mBankDiskGenerate = 1; // Generate For Payroll
					mFileName = txtFilePath.Text;
				}
				else
				{
					mBankDiskGenerate = 2; // Generate For Leave
					mFileName = txtLeaveFilePath.Text;
				}
			}
			else
			{
				mBankDiskGenerate = 1; // Generate For Payroll
				mFileName = txtFilePath.Text;
			}

			string mysql = " select pbd.account_no, pbd.download_format, pbd.company_file_initial ";
			mysql = mysql + " , bank.standard_bank_cd, pbd.download_path, pbd.entry_id, company_name, pbd.hsbc_ps_code, pbd.hsbc_net_id, pbd.hsbc_cust_id";
			mysql = mysql + " , pbd.bank_cd ,bank.bank_no , pbd.Bank_Identity , pbd.bank_unique_id";
			mysql = mysql + " from pay_bank_details pbd ";
			mysql = mysql + " inner join SM_bank as bank on pbd.bank_cd = bank.bank_cd ";
			if (mBankDiskGenerate == 1)
			{
				mysql = mysql + " where pbd.entry_id='" + txtBankAccountNo.Text + "'";
			}
			else
			{
				mysql = mysql + " where pbd.entry_id='" + txtLeaveCompBankCd.Text + "'";
			}
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCompanyAccountNo = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mDownloadFormat = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCompanyFileInitial = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mStandardBankCd = (Convert.IsDBNull(((Array) mReturnValue).GetValue(3))) ? "0001" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mDownloadPath = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(4));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(5));
				mCompanyName = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(6)) + "";
				mPSCode = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(7)) + "";
				mHSBCNetID = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(8)) + "";
				mHSBCCustID = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(9)) + "";
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mBankCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(10));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mHSBCBankCd = (Convert.IsDBNull(((Array) mReturnValue).GetValue(12))) ? "" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(12));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mBankUniueCd = (Convert.IsDBNull(((Array) mReturnValue).GetValue(13))) ? "" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(13));
			}
			else
			{
				MessageBox.Show("Invalid Bank, Select a valid bank.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}




			if (mBankDiskGenerate == 1)
			{ //'For Payroll Bank File
				mysql = " select pemp.Emp_No as Emp_No ";
				mysql = mysql + " , pemp.l_first_name + ' ' + pemp.l_second_name  + ' ' +  pemp.l_third_name  + ' ' + pemp.l_fourth_name as emp_name ";
				//''modified by hakim on 8th dec 2011
				//mySQL = mySQL & " , isnull(pp.bank_account_no,0) as bank_account_no "
				mysql = mysql + " , isnull(ppm.bank_account_no,0) as bank_account_no ";
				mysql = mysql + " , sum( case when  pbt.bill_type_id = 51 then pp.lc_amount";
				mysql = mysql + " else (pp.lc_amount * -1) end) as amt ";
				mysql = mysql + " , isnull( b1.standard_bank_Cd,0) as standard_bank_cd";
				mysql = mysql + " , isnull(b1.hsbc_bank_cd, '') as hsbc_bank_cd ";
				mysql = mysql + " , isnull(pemp.Civil_Id,'') as Civil_Id ";
				mysql = mysql + " from pay_payroll pp ";
				mysql = mysql + " inner join pay_payroll_master ppm on ppm.entry_id = pp.master_entry_id";
				mysql = mysql + " inner join pay_billing_type pbt on pp.bill_cd = pbt.bill_cd ";
				mysql = mysql + " inner join pay_employee pemp on pp.emp_cd = pemp.emp_cd ";
				mysql = mysql + " left outer join pay_sponsor ps on ps.sponsor_cd = pp.sponsor_cd ";
				mysql = mysql + " left outer join gl_projects gp on gp.project_cd = pp.project_cd ";
				mysql = mysql + " left outer join pay_company pc on pc.comp_cd = pp.Comp_cd ";
				mysql = mysql + " inner join pay_department pd on pemp.dept_cd = pd.dept_cd ";
				//Added by Burhan Ghee Wala Date: 15-Oct-2007
				mysql = mysql + " left join sm_bank b1 on pemp.bank_cd = b1.bank_cd ";
				//End
				//Added By Burhan Ghee Wala Date: 25-Jul-2007
				mysql = mysql + " inner join pay_bank_details pbd on ppm.transfer_bank_entry_id = pbd.entry_id ";
				//End
				mysql = mysql + " left join sm_bank as bank on pbd.bank_cd = bank.bank_cd ";
				mysql = mysql + " Where Month(pp.pay_date) = " + cmbMonth.GetItemData(cmbMonth.ListIndex).ToString();
				mysql = mysql + " And Year(pp.pay_date) = " + cmbYear.GetItemData(cmbYear.ListIndex).ToString();
				mysql = mysql + " And ppm.transfer_bank_Entry_id = " + mEntryId.ToString();
				//mySql = mySql & " ) "
				//mySql = mySql & " and pp.payment_type_id = 25 "
				mysql = mysql + " and ppm.is_payroll_emp = 1 ";
				mysql = mysql + " and pbt.Include_In_Bank_Transfer = 1 ";
				//mySql = mySql & " And b1.bank_cd ='" & mBankCd & "'"

				if (!SystemProcedure2.IsItEmpty(txtDepartmentCode.Text, SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " And pd.dept_no >='" + txtDepartmentCode.Text + "'";
				}
				if (!SystemProcedure2.IsItEmpty(txtDepartmentCodeTo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " And pd.dept_no <='" + txtDepartmentCodeTo.Text + "'";
				}

				if (!SystemProcedure2.IsItEmpty(txtFromEmpNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " And pemp.emp_no >='" + txtFromEmpNo.Text + "'";
				}

				if (!SystemProcedure2.IsItEmpty(txtToEmpNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " And pemp.emp_no <='" + txtToEmpNo.Text + "'";
				}

				if (!SystemProcedure2.IsItEmpty(txtSponsorCd.Text, SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " And ps.sponsor_no ='" + txtSponsorCd.Text + "'";
				}

				if (!SystemProcedure2.IsItEmpty(txtCompanyCode.Text, SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " And pc.comp_no = " + txtCompanyCode.Text;
				}

				if (!SystemProcedure2.IsItEmpty(txtProjectCd.Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " And gp.project_no ='" + txtProjectCd.Text + "'";
				}

				if (!SystemProcedure2.IsItEmpty(txtEmpBankAccount.Text, SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " And b1.bank_no ='" + txtEmpBankAccount.Text + "'";
				}

				mysql = mysql + " group by pemp.Emp_No, pemp.l_first_name, pemp.l_second_name";
				mysql = mysql + " , pemp.l_third_name ";
				mysql = mysql + " , pemp.l_fourth_name, ppm.bank_account_no, b1.standard_bank_Cd, b1.hsbc_bank_cd , pemp.Civil_Id";

			}
			else
			{
				//'For Leave

				mysql = " select pemp.Emp_No as Emp_No ";
				mysql = mysql + " , pemp.l_first_name + ' ' + pemp.l_second_name  + ' ' +  pemp.l_third_name  + ' ' + pemp.l_fourth_name as emp_name ";
				mysql = mysql + " , isnull(pemp.bank_account_no,0) as bank_account_no ";
				mysql = mysql + " , sum( case when  pbt.bill_type_id = 51 then pltpd.lc_amount";
				mysql = mysql + " else (pltpd.lc_amount * -1) end) as amt ";
				mysql = mysql + " , isnull( b1.standard_bank_Cd,0) as standard_bank_cd";
				mysql = mysql + " , isnull(b1.hsbc_bank_cd, '') as hsbc_bank_cd ";
				mysql = mysql + " , isnull(pemp.Civil_Id,'') as Civil_Id ";
				mysql = mysql + " from Pay_Leave_Transaction plt ";
				mysql = mysql + " inner join PAY_LEAVE pl on pl.Leave_Cd = plt.Leave_Cd ";
				mysql = mysql + " inner join Pay_Leave_Transacrion_Payroll_Details pltpd on plt.entry_id = pltpd.Leave_Entry_Id  and pl.Deduction_Bill_Cd <> pltpd.Bill_Cd ";
				mysql = mysql + " inner join pay_billing_type pbt on pltpd.bill_cd = pbt.bill_cd ";
				mysql = mysql + " inner join pay_employee pemp on pltpd.emp_cd = pemp.emp_cd ";
				mysql = mysql + " left outer join pay_sponsor ps on ps.sponsor_cd = pemp.sponsor_cd ";
				mysql = mysql + " left outer join gl_projects gp on gp.project_cd = pemp.default_project ";
				mysql = mysql + " left outer join pay_company pc on pc.comp_cd = pemp.Comp_cd ";
				mysql = mysql + " inner join pay_department pd on pemp.dept_cd = pd.dept_cd ";
				//Added by Burhan Ghee Wala Date: 15-Oct-2007
				mysql = mysql + " left join sm_bank b1 on pemp.bank_cd = b1.bank_cd ";
				//End
				//Added By Burhan Ghee Wala Date: 25-Jul-2007
				mysql = mysql + " inner join pay_bank_details pbd on pemp.transfer_bank_entry_id = pbd.entry_id ";
				//End
				mysql = mysql + " left join sm_bank as bank on pbd.bank_cd = bank.bank_cd ";
				mysql = mysql + " Where pemp.transfer_bank_Entry_id = " + mEntryId.ToString();
				mysql = mysql + " and pemp.is_payroll_emp = 1 ";
				mysql = mysql + " and pbt.Include_In_Bank_Transfer = 1 ";
				mysql = mysql + " and plt.Voucher_Date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtDFromTransDate.Value) + "'";
				mysql = mysql + " and plt.Voucher_Date <= '" + ReflectionHelper.GetPrimitiveValue<string>(txtDToTransDate.Value) + "'";
				if (!SystemProcedure2.IsItEmpty(txtLeaveFromTransNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " And plt.Voucher_No >='" + txtLeaveFromTransNo.Text + "'";
				}
				if (!SystemProcedure2.IsItEmpty(txtLeaveToTransNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " And plt.Voucher_No <='" + txtLeaveToTransNo.Text + "'";
				}

				if (!SystemProcedure2.IsItEmpty(txtLeaveSponsorCd.Text, SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " And ps.sponsor_no ='" + txtLeaveSponsorCd.Text + "'";
				}

				if (!SystemProcedure2.IsItEmpty(txtLeaveProjectCd.Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " And gp.project_no ='" + txtLeaveProjectCd.Text + "'";
				}

				if (!SystemProcedure2.IsItEmpty(txtLeaveEmpBankCd.Text, SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " And b1.bank_no ='" + txtLeaveEmpBankCd.Text + "'";
				}

				mysql = mysql + " group by pemp.Emp_No, pemp.l_first_name, pemp.l_second_name";
				mysql = mysql + " , pemp.l_third_name ";
				mysql = mysql + " , pemp.l_fourth_name, pemp.bank_account_no, b1.standard_bank_Cd, b1.hsbc_bank_cd , pemp.Civil_Id";
			}

			SqlDataReader rsLocalRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			rsLocalRec.Read();
			if (!rsLocalRec.HasRows)
			{
				MessageBox.Show("No record found!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			//'' Added By Burhan Ghee Wala
			//'' Date: 24-Jul-2007
			if (mDownloadFormat == 5)
			{
				do 
				{

					if (Convert.ToDouble(rsLocalRec["amt"]) > 0)
					{ // if salary amount is greater than zero than only record should be added in file
						mTotalRecords++;
						mTotalSalary = (decimal) (((double) mTotalSalary) + Convert.ToDouble(rsLocalRec["amt"]));
					}


				}
				while(rsLocalRec.Read());
			}

			//''End

			FileSystem.FileClose(1);
			FileSystem.FileOpen(1, mFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
			if (mDownloadFormat != 9)
			{
				FileSystem.PrintLine(1, InsertHeader(mDownloadFormat, mCompanyFileInitial, mStandardBankCd, mCompanyAccountNo, mCompanyName, mTotalRecords, mHSBCCustID, mHSBCNetID, mPSCode, mTotalSalary, mHSBCBankCd, mBankUniueCd));
			}

			mTotalRecords = 0;
			mTotalSalary = 0;
			i = 1;
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsLocalRec.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			do 
			{

				if (Convert.ToDouble(rsLocalRec["amt"]) > 0)
				{ // if salary amount is greater than zero than only record should be added in file
					FileSystem.PrintLine(1, InsertDetail(mDownloadFormat, mCompanyFileInitial, Convert.ToString(rsLocalRec["standard_bank_cd"]), Convert.ToString(rsLocalRec["emp_no"]), Convert.ToString(rsLocalRec["bank_account_no"]).Trim(), Convert.ToDecimal(rsLocalRec["amt"]), Convert.ToString(rsLocalRec["emp_name"]).Trim(), Convert.ToString(rsLocalRec["hsbc_bank_cd"]).Trim(), i.ToString(), Convert.ToString(rsLocalRec["Civil_Id"])));

					mTotalRecords++;
					mTotalSalary = (decimal) (((double) mTotalSalary) + Convert.ToDouble(rsLocalRec["amt"]));
					i++;
				}

			}
			while(rsLocalRec.Read());
			if (mDownloadFormat != 5 && mDownloadFormat != 9)
			{ // if format type is for HSBC bank no footer is required. This step is neccesary bcoz it leave a blank line at the end of file.
				FileSystem.PrintLine(1, InsertFooter(mDownloadFormat, mCompanyFileInitial, mStandardBankCd, mTotalRecords, mTotalSalary, mCompanyAccountNo, mCompanyName));
			}

			FileSystem.FileClose(1);


			MessageBox.Show("File Generated Successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

			this.Close();
			return;


			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "CmdOK", SystemConstants.msg10);

		}

		private void cmdPrintReport_Click(Object eventSender, EventArgs eventArgs)
		{
			string mParameter = "";
			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_Leave_Bank_Disk")))
			{
				if (GenerateOption[0].Checked)
				{
					//        mParameter = txtBankAccountNo.Text & "," & IIf(IsItEmpty(txtDepartmentCode.Text, NumberType), "0", CStr(txtDepartmentCode.Text)) & "," & _
					//'                    IIf(IsItEmpty(txtDepartmentCodeTo.Text, NumberType), "0", CStr(txtDepartmentCodeTo.Text)) & "," & _
					//'                    IIf(IsItEmpty(txtEmpBankAccount.Text, NumberType), "0", CStr(txtEmpBankAccount.Text)) & "," & _
					//'                    IIf(IsItEmpty(txtSponsorCd.Text, NumberType), "0", CStr(txtSponsorCd.Text))
					//        Call GetCrystalReport(110013700, 2, "7971,8758,10351,10352", Str(mParameter), False)
				}
				else
				{
					//Call GetCrystalReport(110121230, 2, "9417", Str(mEntryId), False)
				}
			}
			else
			{
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			int mYear = 0;
			int cnt = 0;

			this.Top = 67;
			this.Left = 33;

			SystemProcedure.SetLabelCaption(this);
			clsFlip oFlipThisForm = null;
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
			{
				oFlipThisForm = new clsFlip();

				oFlipThisForm.SwapMe(this);
			}



			mYear = DateTime.Today.Year;
			int tempForEndVar = mYear + 1;
			for (cnt = 2000; cnt <= tempForEndVar; cnt++)
			{

				cmbYear.AddItem(cnt.ToString());
				cmbYear.SetItemData(cmbYear.NewIndex, cnt);
			}

			SystemCombo.SearchCombo(cmbYear, DateTime.Today.Year);

			cmbMonth.AddItem("Jan");
			cmbMonth.SetItemData(cmbMonth.NewIndex, 1);

			cmbMonth.AddItem("Feb");
			cmbMonth.SetItemData(cmbMonth.NewIndex, 2);

			cmbMonth.AddItem("Mar");
			cmbMonth.SetItemData(cmbMonth.NewIndex, 3);

			cmbMonth.AddItem("Apr");
			cmbMonth.SetItemData(cmbMonth.NewIndex, 4);

			cmbMonth.AddItem("May");
			cmbMonth.SetItemData(cmbMonth.NewIndex, 5);

			cmbMonth.AddItem("Jun");
			cmbMonth.SetItemData(cmbMonth.NewIndex, 6);

			cmbMonth.AddItem("Jul");
			cmbMonth.SetItemData(cmbMonth.NewIndex, 7);

			cmbMonth.AddItem("Aug");
			cmbMonth.SetItemData(cmbMonth.NewIndex, 8);

			cmbMonth.AddItem("Sep");
			cmbMonth.SetItemData(cmbMonth.NewIndex, 9);

			cmbMonth.AddItem("Oct");
			cmbMonth.SetItemData(cmbMonth.NewIndex, 10);

			cmbMonth.AddItem("Nov");
			cmbMonth.SetItemData(cmbMonth.NewIndex, 11);

			cmbMonth.AddItem("Dec");
			cmbMonth.SetItemData(cmbMonth.NewIndex, 12);

			SystemCombo.SearchCombo(cmbMonth, DateTime.Today.Month);

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_Leave_Bank_Disk")))
			{
				this.tabBankDisk.set_TabVisible(1, true);
				this.Frame1.Visible = true;
				this.GenerateOption[0].Checked = true;

			}
			else
			{
				this.tabBankDisk.set_TabVisible(1, false);
				this.Frame1.Visible = false;
			}

			chkSelectAll.CheckState = CheckState.Checked;
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
					SystemForms.ToolBarButtonClick(this, "Exit");
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

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				UserAccess = null;
				frmPayGenerateBankFile.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;
			string mysql = "";

			switch(pObjectName)
			{
				case "txtBankAccountNo" : 
					txtBankName.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7031000)); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtBankAccountNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0));
						txtBankAccountNo_Leave(txtBankAccountNo, new EventArgs());
					} 
					break;
				case "txtLeaveCompBankCd" : 
					lblLeaveCompBankName.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7031000)); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLeaveCompBankCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0));
						txtLeaveCompBankCd_Leave(txtLeaveCompBankCd, new EventArgs());
					} 
					break;
				case "txtFromEmpNo" : 
					txtFromEmpNo.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtFromEmpNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						TxtFromEmpno_Leave(txtFromEmpNo, new EventArgs());
					} 
					break;
				case "txtToEmpNo" : 
					txtToEmpNo.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtToEmpNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						TxtToEmpNo_Leave(txtToEmpNo, new EventArgs());
					} 
					break;
				case "txtEmpBankAccount" : 
					txtEmpBankAccount.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7030000, "820")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtEmpBankAccount.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtEmpBankAccount_Leave(txtEmpBankAccount, new EventArgs());
					} 
					break;
				case "txtLeaveEmpBankCd" : 
					txtLeaveEmpBankCd.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7030000, "820")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLeaveEmpBankCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtLeaveEmpBankCd_Leave(txtLeaveEmpBankCd, new EventArgs());
					} 
					break;
				case "txtDepartmentCode" : 
					txtDepartmentCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7001000, "727")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDepartmentCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtDepartmentCode_Leave(txtDepartmentCode, new EventArgs());
					} 
					break;
				case "txtDepartmentCodeTo" : 
					txtDepartmentCodeTo.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7001000, "727")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDepartmentCodeTo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtDepartmentCodeTo_Leave(txtDepartmentCodeTo, new EventArgs());
					} 
					break;
				case "txtSponsorCd" : 
					txtSponsorCd.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7200000, "1837")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtSponsorCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtSponsorCd_Leave(txtSponsorCd, new EventArgs());
					} 
					break;
				case "txtLeaveSponsorCd" : 
					txtLeaveSponsorCd.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7200000, "1837")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLeaveSponsorCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtLeaveSponsorCd_Leave(txtLeaveSponsorCd, new EventArgs());
					} 
					break;
				case "txtCompanyCode" : 
					txtCompanyCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7001100, "1769")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCompanyCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCompanyCode_Leave(txtCompanyCode, new EventArgs());
					} 
					break;
				case "txtProjectCd" : 
					txtProjectCd.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000130, "985")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtProjectCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtProjectCd_Leave(txtProjectCd, new EventArgs());
					} 
					break;
				case "txtLeaveProjectCd" : 
					txtLeaveProjectCd.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000130, "985")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLeaveProjectCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtLeaveProjectCd_Leave(txtLeaveProjectCd, new EventArgs());
					} 
					break;
				case "txtLeaveFromTransNo" : 
					txtLeaveFromTransNo.Text = ""; 
					mysql = " plt.status <> 1"; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7080000, "888", mysql)); 
					 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLeaveFromTransNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtLeaveFromTransNo_Leave(txtLeaveFromTransNo, new EventArgs());
					} 
					break;
				case "txtLeaveToTransNo" : 
					txtLeaveToTransNo.Text = ""; 
					mysql = " plt.status <> 1"; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7080000, "888", mysql)); 
					 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLeaveToTransNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtLeaveToTransNo_Leave(txtLeaveToTransNo, new EventArgs());
					} 
					break;
				default:
					return;
			}

		}




		private void txtLeaveFromTransNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtLeaveFromTransNo");
		}

		private void txtLeaveFromTransNo_Leave(Object eventSender, EventArgs eventArgs)
		{

			if (SystemProcedure2.IsItEmpty(txtLeaveFromTransNo.Text, SystemVariables.DataType.StringType))
			{
				return;
			}

			string mysql = "select entry_id";
			mysql = mysql + " from pay_leave_transaction ";
			mysql = mysql + " where voucher_no = " + txtLeaveFromTransNo.Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				MessageBox.Show("Leave Trans does no not exists.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void txtLeaveToTransNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtLeaveToTransNo");
		}

		private void txtLeaveToTransNo_Leave(Object eventSender, EventArgs eventArgs)
		{

			if (SystemProcedure2.IsItEmpty(txtLeaveToTransNo.Text, SystemVariables.DataType.StringType))
			{
				return;
			}

			string mysql = "select entry_id";
			mysql = mysql + " from pay_leave_transaction ";
			mysql = mysql + " where voucher_no = " + txtLeaveToTransNo.Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				MessageBox.Show("Leave Trans does no not exists.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}


		private bool isInitializingComponent;
		private void GenerateOption_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.GenerateOption, eventSender);
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				this.tabBankDisk.CurrTab = (short) Index;
			}
		}

		private void tabBankDisk_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			int i = 0;

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_Leave_Bank_Disk")))
			{
				i = this.tabBankDisk.CurrTab;
				GenerateOption[i].Checked = true;
			}

		}

		private void txtBankAccountNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtBankAccountNo");
		}

		private void txtLeaveCompBankCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtLeaveCompBankCd");
		}

		private void txtLeaveCompBankCd_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";

				if (!SystemProcedure2.IsItEmpty(txtLeaveCompBankCd.Text, SystemVariables.DataType.StringType))
				{
					mysql = " select pbd.account_no ";
					mysql = mysql + "," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_bank_name" : "a_bank_name");
					mysql = mysql + ", pbd.download_path , isnull(pbd.Company_File_Initial,'') , bank.bank_no";
					mysql = mysql + " from pay_bank_details pbd ";
					mysql = mysql + " inner join sm_bank bank on pbd.bank_cd = bank.bank_cd ";
					mysql = mysql + " where pbd.entry_id ='" + txtLeaveCompBankCd.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						lblLeaveCompBankName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						lblLeaveCompBankName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					}
					txtLeaveFilePath.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2)) + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3)) + "_" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4)) + "_" + DateAndTime.Day(DateTime.Today).ToString() + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(DateTime.Today.Month) + "_" + DateAndTime.Hour(DateTime.Now).ToString() + DateTime.Now.Minute.ToString() + ".txt";
				}
				else
				{
					lblLeaveCompBankName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					//txtBankAccountNo.SetFocus
				}
			}
		}

		private void txtBankAccountNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";

				if (!SystemProcedure2.IsItEmpty(txtBankAccountNo.Text, SystemVariables.DataType.StringType))
				{
					mysql = " select pbd.account_no ";
					mysql = mysql + "," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_bank_name" : "a_bank_name");
					mysql = mysql + ", pbd.download_path , isnull(pbd.Company_File_Initial,'') , bank.bank_no";
					mysql = mysql + " from pay_bank_details pbd ";
					mysql = mysql + " inner join SM_bank as bank on pbd.bank_cd = bank.bank_cd ";
					mysql = mysql + " where pbd.entry_id ='" + txtBankAccountNo.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtBankName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtBankName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					}
					txtFilePath.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2)) + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3)) + "_" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4)) + "_" + DateAndTime.Day(DateTime.Today).ToString() + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(DateTime.Today.Month) + "_" + DateAndTime.Hour(DateTime.Now).ToString() + DateTime.Now.Minute.ToString() + ".txt";
				}
				else
				{
					txtBankName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					//txtBankAccountNo.SetFocus
				}
			}
		}



		private void txtCompanyCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtCompanyCode");
		}

		private void txtCompanyCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtCompanyCode.Text, SystemVariables.DataType.NumberType) || txtCompanyCode.Text == "0")
				{
					mysql = "select comp_no ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_comp_name" : "a_comp_name");
					mysql = mysql + " from pay_company ";
					mysql = mysql + " where ";
					mysql = mysql + " comp_no = " + txtCompanyCode.Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDlblCompanyName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDlblCompanyName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					}
				}
				else
				{
					txtDlblCompanyName.Text = "";
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
					txtCompanyCode.Focus();
				}
				else
				{
					//
				}
			}

		}

		private void txtDepartmentCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtDepartmentCode");
		}

		private void txtDepartmentCodeTo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtDepartmentCodeTo");
		}

		private void txtDepartmentCodeTo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;

				if (!SystemProcedure2.IsItEmpty(txtDepartmentCodeTo.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name") + "  from pay_department where dept_no ='" + txtDepartmentCodeTo.Text + "'"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDepartmentCodeTo.Text = "";
						txtDepartmentNameTo.Text = "";
						MessageBox.Show("Invalid Department Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDepartmentNameTo.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtDepartmentNameTo.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					txtEmpBankAccount.Focus();
				}
			}
		}



		private void txtEmpBankAccount_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtEmpBankAccount");
		}

		private void txtLeaveEmpBankCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtLeaveEmpBankCd");
		}

		private void txtLeaveEmpBankCd_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;

				if (!SystemProcedure2.IsItEmpty(txtLeaveEmpBankCd.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_bank_name" : "a_bank_name") + "  from sm_bank where bank_no ='" + txtLeaveEmpBankCd.Text + "'"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtLeaveEmpBankCd.Text = "";
						lblLeaveEmpBankName.Text = "";
						MessageBox.Show("Invalid Bank Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						lblLeaveEmpBankName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					lblLeaveEmpBankName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					txtEmpBankAccount.Focus();
				}
			}
		}

		private void txtEmpBankAccount_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;

				if (!SystemProcedure2.IsItEmpty(txtEmpBankAccount.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_bank_name" : "a_bank_name") + "  from SM_bank where bank_no ='" + txtEmpBankAccount.Text + "'"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtEmpBankAccount.Text = "";
						txtEmpBankName.Text = "";
						MessageBox.Show("Invalid Bank Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtEmpBankName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtEmpBankName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					txtEmpBankAccount.Focus();
				}
			}
		}

		private void txtDepartmentCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;

				if (!SystemProcedure2.IsItEmpty(txtDepartmentCode.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name") + "  from pay_department where dept_no ='" + txtDepartmentCode.Text + "'"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDepartmentCode.Text = "";
						txtDepartmentName.Text = "";
						MessageBox.Show("Invalid Department Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDepartmentName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtDepartmentName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					txtEmpBankAccount.Focus();
				}
			}
		}
		private void txtFromEmpNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtFromEmpNo");

		}

		private void TxtFromEmpno_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				//
				//txtFromEmpNo.Text = Format(Val(txtFromEmpNo.Text), "000000000000")

				if (!SystemProcedure2.IsItEmpty(txtFromEmpNo.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_first_name" : "a_first_name") + "  from pay_employee where emp_no ='" + txtFromEmpNo.Text + "'"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtFromEmpName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtFromEmpName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtFromEmpName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					txtFromEmpNo.Focus();
				}
			}
		}



		private void txtLeaveProjectCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtLeaveProjectCd");
		}

		private void txtLeaveSponsorCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtLeaveSponsorCd");
		}

		private void txtProjectCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtProjectCd");
		}

		private void txtLeaveProjectCd_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";

				if (!SystemProcedure2.IsItEmpty(txtLeaveProjectCd.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select project_no ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_project_name" : "a_project_name");
					mysql = mysql + " from gl_projects ";
					mysql = mysql + " where ";
					mysql = mysql + " project_no = '" + txtLeaveProjectCd.Text + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						lblLeaveProjectName.Text = "";
						throw new Exception();
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						lblLeaveProjectName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					}
				}
				else
				{
					lblLeaveProjectName.Text = "";
				}
			}
			catch
			{
				MessageBox.Show("Invalid Project No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void txtProjectCd_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";

				if (!SystemProcedure2.IsItEmpty(txtProjectCd.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select project_no ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_project_name" : "a_project_name");
					mysql = mysql + " from gl_projects ";
					mysql = mysql + " where ";
					mysql = mysql + " project_no = '" + txtProjectCd.Text + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDProjectName.Text = "";
						throw new Exception();
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDProjectName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					}
				}
				else
				{
					txtDProjectName.Text = "";
				}
			}
			catch
			{
				MessageBox.Show("Invalid Project No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void txtSponsorCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtSponsorCd");
		}

		private void txtLeaveSponsorCd_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mTempValue = null;

			if (!SystemProcedure2.IsItEmpty(txtLeaveSponsorCd.Text, SystemVariables.DataType.NumberType))
			{
				mysql = "select Sponsor_cd ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_First_name + ' ' +  L_Second_Name + ' ' + L_Third_Name + ' ' + L_Fourth_Name " : "A_First_name + ' ' +  A_Second_Name + ' ' + A_Third_Name + ' ' + A_Fourth_Name");
				mysql = mysql + " from pay_sponsor ";
				mysql = mysql + " where ";
				mysql = mysql + " sponsor_no = " + txtLeaveSponsorCd.Text;

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempValue))
				{
					lblLeaveSponsorName.Text = "";
					throw new System.Exception("-9990002");
				}
				else
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					lblLeaveSponsorName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
				}
			}
			else
			{
				lblLeaveSponsorName.Text = "";
			}
		}

		private void txtSponsorCd_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mTempValue = null;

			if (!SystemProcedure2.IsItEmpty(txtSponsorCd.Text, SystemVariables.DataType.NumberType))
			{
				mysql = "select Sponsor_cd ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_First_name + ' ' +  L_Second_Name + ' ' + L_Third_Name + ' ' + L_Fourth_Name " : "A_First_name + ' ' +  A_Second_Name + ' ' + A_Third_Name + ' ' + A_Fourth_Name");
				mysql = mysql + " from pay_sponsor ";
				mysql = mysql + " where ";
				mysql = mysql + " sponsor_no = " + txtSponsorCd.Text;

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempValue))
				{
					txtDlblSponsorName.Text = "";
					throw new System.Exception("-9990002");
				}
				else
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDlblSponsorName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
				}
			}
			else
			{
				txtDlblSponsorName.Text = "";
			}
		}

		private void txtToEmpNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtToEmpNo");
		}

		private void TxtToEmpNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;

				//
				//If IsItEmpty(Val(txtToEmpNo.Text), NumberType) Then
				//    txtToEmpNo.Text = Format(Val(txtToEmpNo.Text), "999999999999")
				//Else
				//    txtToEmpNo.Text = Format(Val(txtToEmpNo.Text), "000000000000")
				//End If

				if (!SystemProcedure2.IsItEmpty(txtToEmpNo.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_first_name" : "a_first_name") + "  from pay_employee where emp_no ='" + txtToEmpNo.Text + "'"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtToEmpName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtToEmpName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtToEmpName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					txtToEmpNo.Focus();
				}
			}
		}

		public void CloseForm()
		{
			cmdOkCancel_CancelClick(cmdOKCancel, null);
		}


		private string InsertHeader(int pDownloadFormat, string pCompanyBankFileInitial, string pStandardBankCd, string pCompanyAccountNo, string pCompanyName, int pTotalRecords = 0, string pCompBankID = "", string pHSBCNetID = "", string pPSCode = "", decimal pTotalAmount = 0, string pHSBCBankCD = "", string pBankUniqueCd = "")
		{

			string mString = "";
			System.DateTime mHSBCDate = DateTime.FromOADate(0);
			string mStime = "";

			string mCreationDate = DateAndTime.Day(DateTime.Today).ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString();
			string mPaymentDate = DateAndTime.Day(DateTime.Today).ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString();
			//UPGRADE_WARNING: (2081) Len has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			string mDateMYD = ((Marshal.SizeOf(DateTime.Today.Month) == 1) ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString()) + DateTime.Today.Year.ToString() + "0" + ((Marshal.SizeOf(DateAndTime.Day(DateTime.Today)) == 1) ? "0" + DateAndTime.Day(DateTime.Today).ToString() : DateAndTime.Day(DateTime.Today).ToString());
			switch(pDownloadFormat)
			{
				case 1 : 
					//''''CBK 
					mString = "HDR" + pCompanyBankFileInitial + " " + StringsHelper.Format(pStandardBankCd, "000") + " " + 
					          mCreationDate + " " + mPaymentDate + " " + ResizeString(pCompanyAccountNo, 15) + new String(' ', 56); 
					break;
				case 2 : 
					//''''Others 
					mString = pCompanyName + mDateMYD; 
					break;
				case 4 : case 10 : 
					//''''Burgan Bank 
					mString = pCompanyBankFileInitial + pCompanyName + "                                  " + mDateMYD; 
					break;
				case 5 : 
					//' 24-jul-2008 
					mStime = Strings.FormatDateTime(DateTime.Parse("01:30:00 PM"), DateFormat.ShortTime); 
					if (String.CompareOrdinal(Strings.FormatDateTime(DateTimeHelper.Time, DateFormat.ShortTime), mStime) > 0)
					{
						mHSBCDate = DateTime.Today.AddDays(1);
					}
					else
					{
						mHSBCDate = DateTime.Today;
					} 
					//'End 
					//''''HSBC Bank Added by Burhan Ghee Date: 24-Jul-2007 
					mString = "IFH,IFILE,CSV," + pCompBankID + "," + pHSBCNetID + ",Sal" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(mHSBCDate.Month); 
					 
					//''modified by hakim on 12-jul-2010 
					mString = mString + mHSBCDate.Year.ToString() + pBankUniqueCd + "," + mHSBCDate.Year.ToString() + "/" + mHSBCDate.ToString("MM") + "/" + mHSBCDate.ToString("dd") + "," + DateTimeHelper.Time.ToString("HH:mm:SS"); 
					//'mString = mString & Year(mHSBCDate) & "," & Format(mHSBCDate, "yyyy-MM-dd") & "," & Format(Time, "HH:MM:SS") 
					 
					mString = mString + "," + pHSBCBankCD + ",1," + (pTotalRecords + 2).ToString() + Environment.NewLine; 
					mString = mString + "BATHDR,ACH-CR," + pTotalRecords.ToString() + ",Sal" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(mHSBCDate.Month) + mHSBCDate.Year.ToString() + ",,,,,,"; 
					mString = mString + "@1ST@," + mHSBCDate.ToString("yyyyMMdd") + "," + pCompanyAccountNo + ",KWD"; 
					mString = mString + "," + StringsHelper.Format(pTotalAmount, "#########.000") + ",,,KW,HBME,KWD,," + pCompanyName + ",Payroll -" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(mHSBCDate.Month) + "-" + mHSBCDate.Year.ToString(); 
					mString = mString + ",,,," + pPSCode + ",Payroll -" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(mHSBCDate.Month) + "-" + mHSBCDate.Year.ToString(); 
					break;
				case 6 : 
					//'' Gulf Bank 
					mString = "HDR" + " " + DateTime.Today.ToString("ddMMyy") + " " + pStandardBankCd; 
					break;
				case 7 : case 11 : 
					//''' Burgan Bank BDinar 
					mString = pCompanyBankFileInitial + pCompanyName + "                                  " + mDateMYD; 
					break;
				case 8 : 
					//'' NBK 
					mString = "HDR " + pCompanyAccountNo + DateTime.Now.ToString("MMyyyy") + pCompanyBankFileInitial; 
					break;
				case 9 : 
					//' ABK 
					break;
			}

			return mString;
		}

		private string InsertDetail(int pDownloadFormat, string pCompanyBankFileInitial, string pStandardBankCd, string pEmpPayrollNo, string pEmpBankAccoutNo, decimal pSalaryAmt, string pEmpName, string pHSBCBankCD, string pSRNO, string pCivilId)
		{

			//pStandardBankCd is not being used for HSBC
			//pHSBCBankCd is for Beneficiary Bank Number /ID, this to recognize which bank the salary has to be transfered

			string mString = "";
			string SecPartyRefrence = "";
			double RecTot = 0;
			System.DateTime n1 = DateTime.FromOADate(0); // for calculation and formating number

			switch(pDownloadFormat)
			{
				case 1 : 
					//'''CBK 
					if (!SystemProcedure2.IsItEmpty(pHSBCBankCD, SystemVariables.DataType.StringType))
					{
						pEmpPayrollNo = pHSBCBankCD;
					} 
					 
					mString = "DTL" + pCompanyBankFileInitial + " " + StringsHelper.Format(pStandardBankCd, "000") + " " + 
					          ResizeString(pEmpPayrollNo.Substring(0, Math.Min(5, pEmpPayrollNo.Length)), 5) + " " + ResizeString(StringsHelper.Format(pEmpBankAccoutNo.Substring(0, Math.Min(11, pEmpBankAccoutNo.Length)), "0000000000"), 10) + new String(' ', 5) + 
					          ResizeString(StringsHelper.Format(pSalaryAmt, "00000000.000"), 12) + " " + 
					          ResizeString(pEmpName, 40) + new String(' ', 15); 
					 
					break;
				case 2 : 
					//'''Others  Added dated 23-Jun-2015 
					n1 = DateTime.FromOADate(Convert.ToInt64(pSalaryAmt - ((decimal) Math.Floor((double) pSalaryAmt)))); 
					// function is used to remove decimal point from the number and join them like 000010.5 = 0000105 
					pSalaryAmt = Decimal.Parse(StringsHelper.Replace(Conversion.Str(Math.Floor((double) pSalaryAmt)) + StringsHelper.Replace(StringsHelper.Format(n1, "####.000"), ".", "", 1, -1, CompareMethod.Binary), " ", "", 1, -1, CompareMethod.Binary), NumberStyles.Currency | NumberStyles.AllowExponent); 
					 
					//MsgBox Format(n1, "####.000") 
					//pSalaryAmt = Replace(Str(Int(pSalaryAmt)) & Replace(Str((n1)), ".", ""), " ", "") 
					 
					mString = StringsHelper.Format(pEmpPayrollNo, "100000000000") + "" + 
					          ResizeString(pEmpName, 40) + ResizeString(StringsHelper.Format(pEmpBankAccoutNo.Substring(0, Math.Min(14, pEmpBankAccoutNo.Length)), "0000000000000"), 13) + 
					          ResizeString(StringsHelper.Format(pSalaryAmt, "0000000000000"), 13); 
					 
					break;
				case 4 : 
					//'''Burgan Bank Added dated 17-Jun-2015 
					n1 = DateTime.FromOADate(Convert.ToInt64(pSalaryAmt - ((decimal) Math.Floor((double) pSalaryAmt)))); 
					// function is used to remove decimal point from the number and join them like 000010.5 = 0000105 
					pSalaryAmt = Decimal.Parse(StringsHelper.Replace(Conversion.Str(Math.Floor((double) pSalaryAmt)) + StringsHelper.Replace(StringsHelper.Format(n1, "####.000"), ".", "", 1, -1, CompareMethod.Binary), " ", "", 1, -1, CompareMethod.Binary), NumberStyles.Currency | NumberStyles.AllowExponent); 
					 
					mString = StringsHelper.Format(pEmpPayrollNo, "100000000000") + "" + 
					          ResizeString(pEmpName, 40) + ResizeString(StringsHelper.Format(pEmpBankAccoutNo.Substring(0, Math.Min(10, pEmpBankAccoutNo.Length)), "0000000000"), 10) + 
					          ResizeString(StringsHelper.Format(pSalaryAmt, "0000000000000"), 13); 
					 
					//    Case 4 
					//        ''''Burgan Bank Added by burhanuddin ghee wala dated 17-Jun-2007 
					//        n1 = pSalaryAmt - Int(pSalaryAmt) 
					//        ' function is used to remove decimal point from the number and join them like 000010.5 = 0000105 
					//        pSalaryAmt = Replace(Str(Int(pSalaryAmt)) & Replace((Format(n1, "####.000")), ".", ""), " ", "") 
					// 
					//        mString = Format(pEmpPayrollNo, "100000000000") & "" & _
					//'        ResizeString(pEmpName, 40) & ResizeString(Format(Left(pEmpBankAccoutNo, 11), "0000000000"), 10) & _
					//'        ResizeString(Format(pSalaryAmt, "0000000000000"), 13) 
					// 
					break;
				case 5 : 
					SecPartyRefrence = "Salary " + cmbMonth.Text + cmbYear.Text.Substring(Math.Max(cmbYear.Text.Length - 2, 0)); 
					//'''HSBC Bank Added by burhanuddin ghee wala dated 24-Jul-2007 
					 
					mString = "SECPTY," + pEmpBankAccoutNo + "," + pEmpName.Substring(0, Math.Min(20, pEmpName.Length)) + "," + pEmpPayrollNo + 
					          "," + pHSBCBankCD + ",,," + StringsHelper.Format(pSalaryAmt, "#########.000") + ",," + SecPartyRefrence + 
					          ",,,,,N,N"; 
					break;
				case 6 : 
					//'' Gulf Bank 
					mString = "DTL" + ResizeString(pCivilId, 12) + "   " + ResizeString(pEmpName.Substring(0, Math.Min(39, pEmpName.Length)), 39) + " " + ResizeString(StringsHelper.Format(pEmpBankAccoutNo.Substring(0, Math.Min(30, pEmpBankAccoutNo.Length)), "000000000000000000000000000000"), 30) + ResizeString(StringsHelper.Format(pSalaryAmt, "00000000.000"), 12) + " 000000003"; 
					 
					break;
				case 7 : 
					//'' Burgan Bank BDinar 
					//'''Burgan Bank Added by burhanuddin ghee wala dated 17-Jun-2007 
					n1 = DateTime.FromOADate(Convert.ToInt64(pSalaryAmt - ((decimal) Math.Floor((double) pSalaryAmt)))); 
					// function is used to remove decimal point from the number and join them like 000010.5 = 0000105 
					pSalaryAmt = Decimal.Parse(StringsHelper.Replace(Conversion.Str(Math.Floor((double) pSalaryAmt)) + StringsHelper.Replace(StringsHelper.Format(n1, "####.000"), ".", "", 1, -1, CompareMethod.Binary), " ", "", 1, -1, CompareMethod.Binary), NumberStyles.Currency | NumberStyles.AllowExponent); 
					 
					mString = StringsHelper.Format(pEmpPayrollNo, "100000000000") + "" + 
					          ResizeString(pEmpName.Substring(0, Math.Min(40, pEmpName.Length)), 40) + ResizeString(StringsHelper.Format(pEmpBankAccoutNo.Substring(0, Math.Min(16, pEmpBankAccoutNo.Length)), "0000000000000000"), 16) + 
					          ResizeString(StringsHelper.Format(pSalaryAmt, "0000000000000"), 13); 
					break;
				case 8 : 
					//' NBK 
					mString = ResizeString(pEmpPayrollNo, 10) + "" + 
					          ResizeString(pEmpName, 45) + ResizeString(pEmpBankAccoutNo.Substring(0, Math.Min(18, pEmpBankAccoutNo.Length)), 18) + 
					          ResizeString(StringsHelper.Format(pSalaryAmt, "00000000.000"), 12) + ResizeString(StringsHelper.Format(pStandardBankCd, "00"), 2); 
					RecTot = Conversion.Val(pEmpBankAccoutNo) * ((double) pSalaryAmt); 
					HashTot += RecTot; 
					break;
				case 9 : 
					//' ABK 
					//'mString = ResizeString(Format(Left(pEmpBankAccoutNo, 13), "0000000000000"), 13) & " " & ResizeString(Left(pEmpName, 39), 39) & " " & _
					//       ''ResizeString(Format(pSalaryAmt, "00000.000"), 9) 
					mString = StringsHelper.Format(ResizeString(pCivilId, 12), "000000000000000") + ResizeString(pEmpName.Substring(0, Math.Min(40, pEmpName.Length)), 40) + 
					          ResizeString(StringsHelper.Format(pEmpBankAccoutNo.Substring(0, Math.Min(30, pEmpBankAccoutNo.Length)), "000000000000000000000000000000"), 30) + 
					          ResizeString(StringsHelper.Format(pSalaryAmt, "00000000.000"), 12) + "SAL" + pStandardBankCd; 
					break;
				case 10 :  //SRNO instant on EMPNOx 
					//'''Burgan Bank  dated 05-Jun-2011 
					n1 = DateTime.FromOADate(Convert.ToInt64(pSalaryAmt - ((decimal) Math.Floor((double) pSalaryAmt)))); 
					// function is used to remove decimal point from the number and join them like 000010.5 = 0000105 
					pSalaryAmt = Decimal.Parse(StringsHelper.Replace(Conversion.Str(Math.Floor((double) pSalaryAmt)) + StringsHelper.Replace(StringsHelper.Format(n1, "####.000"), ".", "", 1, -1, CompareMethod.Binary), " ", "", 1, -1, CompareMethod.Binary), NumberStyles.Currency | NumberStyles.AllowExponent); 
					 
					mString = StringsHelper.Format(pSRNO, "100000000000") + "" + 
					          ResizeString(pEmpName, 40) + ResizeString(StringsHelper.Format(pEmpBankAccoutNo.Substring(0, Math.Min(10, pEmpBankAccoutNo.Length)), "0000000000"), 10) + 
					          ResizeString(StringsHelper.Format(pSalaryAmt, "0000000000000"), 13); 
					break;
				case 11 :  //SRNO instant on EMPNO 
					//'''Burgan Bank BDinar  dated 05-Jun-2011 
					n1 = DateTime.FromOADate(Convert.ToInt64(pSalaryAmt - ((decimal) Math.Floor((double) pSalaryAmt)))); 
					//function is used to remove decimal point from the number and join them like 000010.5 = 0000105 
					pSalaryAmt = Decimal.Parse(StringsHelper.Replace(Conversion.Str(Math.Floor((double) pSalaryAmt)) + StringsHelper.Replace(StringsHelper.Format(n1, "####.000"), ".", "", 1, -1, CompareMethod.Binary), " ", "", 1, -1, CompareMethod.Binary), NumberStyles.Currency | NumberStyles.AllowExponent); 
					 
					mString = StringsHelper.Format(pSRNO, "100000000000") + "" + 
					          ResizeString(pEmpName.Substring(0, Math.Min(40, pEmpName.Length)), 40) + ResizeString(StringsHelper.Format(pEmpBankAccoutNo.Substring(0, Math.Min(16, pEmpBankAccoutNo.Length)), "0000000000000000"), 16) + 
					          ResizeString(StringsHelper.Format(pSalaryAmt, "0000000000000"), 13); 
					 
					break;
				case 12 :  // For BKME 
					mString = "\"" + pEmpBankAccoutNo + "\"" + "," + "\"" + ResizeString(pEmpName.Substring(0, Math.Min(40, pEmpName.Length)), 40) + "\"" + "," + "\"" + 
					          ResizeString(StringsHelper.Format(pSalaryAmt, "00000.000"), 9) + "\"" + "," + "\"" + "YES" + "\"" + "," + "\"" + StringsHelper.Format(pSRNO, "000000") + 
					          "\"" + "," + "\"" + "\""; 
					 
					break;
				case 13 :  // For KFH 
					mString = "" + pEmpPayrollNo + "," + pEmpName + "," + pEmpBankAccoutNo + "," + StringsHelper.Format(pSalaryAmt, "####.000") + "," + pCivilId + ",1"; 
					break;
			}

			return mString;

		}

		private string InsertFooter(int pDownloadFormat, string pCompanyBankFileInitial, string pStandardBankCd, int pTotalRecords, decimal pTotalAmt, string pCompanyAccountNo, string pCompanyName)
		{

			string mString = "";
			double n = 0; // For calculation and formating

			switch(pDownloadFormat)
			{
				case 1 : 
					//'''CBK 
					mString = "TRL" + pCompanyBankFileInitial + " " + StringsHelper.Format(pStandardBankCd, "000") + " " + 
					          ResizeString(pTotalRecords.ToString(), 5) + " " + 
					          ResizeString(StringsHelper.Format(pTotalAmt, "########.#00"), 12) + new String(' ', 70); 
					 
					break;
				case 2 : 
					//'''Others - Added by burhanuddin ghee wala dated 23-Jun-2007 
					n = (double) (pTotalAmt - ((decimal) Math.Floor((double) pTotalAmt))); 
					// function is used to remove decimal point from the number and join them like 000010.5 = 0000105 
					pTotalAmt = Decimal.Parse(StringsHelper.Replace(Conversion.Str(Math.Floor((double) pTotalAmt)) + StringsHelper.Replace(Conversion.Str(Math.Round((double) n, 3)), ".", "", 1, -1, CompareMethod.Binary), " ", "", 1, -1, CompareMethod.Binary), NumberStyles.Currency | NumberStyles.AllowExponent); 
					 
					mString = "2" + StringsHelper.Format(pTotalRecords, "00000") + 
					          ResizeString(StringsHelper.Format(pTotalAmt, "0000000000000"), 13) + new String(' ', 70); 
					 
					break;
				case 4 : 
					//'''Burgan Bank Added by burhanuddin ghee wala dated 17-Jun-2007 
					n = (double) (pTotalAmt - ((decimal) Math.Floor((double) pTotalAmt))); 
					// function is used to remove decimal point from the number and join them like 000010.5 = 0000105 
					pTotalAmt = Decimal.Parse(StringsHelper.Replace(Conversion.Str(Math.Floor((double) pTotalAmt)) + StringsHelper.Replace(StringsHelper.Format(n, "####.000"), ".", "", 1, -1, CompareMethod.Binary), " ", "", 1, -1, CompareMethod.Binary), NumberStyles.Currency | NumberStyles.AllowExponent); 
					 
					mString = "2" + StringsHelper.Format(pTotalRecords, "00000") + 
					          ResizeString(StringsHelper.Format(pTotalAmt, "0000000000000"), 13) + new String(' ', 70); 
					break;
				case 6 : 
					//'' GULF Bank 
					mString = "TRL" + " " + ResizeString(StringsHelper.Format(pTotalRecords, "00000000"), 8) + " " + ResizeString(StringsHelper.Format(pTotalAmt, "0000000000.000"), 14) + " " + pCompanyName; 
					break;
				case 7 : 
					//'' Burgan Bank BDinar 
					n = (double) (pTotalAmt - ((decimal) Math.Floor((double) pTotalAmt))); 
					// function is used to remove decimal point from the number and join them like 000010.5 = 0000105 
					pTotalAmt = Decimal.Parse(StringsHelper.Replace(Conversion.Str(Math.Floor((double) pTotalAmt)) + StringsHelper.Replace(StringsHelper.Format(n, "####.000"), ".", "", 1, -1, CompareMethod.Binary), " ", "", 1, -1, CompareMethod.Binary), NumberStyles.Currency | NumberStyles.AllowExponent); 
					mString = "2" + StringsHelper.Format(pTotalRecords, "00000") + 
					          ResizeString(StringsHelper.Format(pTotalAmt, "0000000000000"), 13) + new String(' ', 70); 
					break;
				case 8 : 
					//' NBK 
					mString = "TRL " + pCompanyAccountNo + " " + ResizeString(StringsHelper.Format(pTotalRecords, "0000"), 4) + " " + 
					          StringsHelper.Format(pTotalAmt, "00000000.000") + StringsHelper.Format(HashTot, new string('0', 52)); 
					break;
				case 9 : 
					//' ABK 
					//'mString = " " & ResizeString(Format(pTotalAmt, "000000000.000"), 13) & " " & Format(pTotalRecords, "00000") 
					break;
				case 10 : 
					//'''Burgan Bank  wala dated 17-Jun-2007 
					n = (double) (pTotalAmt - ((decimal) Math.Floor((double) pTotalAmt))); 
					// function is used to remove decimal point from the number and join them like 000010.5 = 0000105 
					pTotalAmt = Decimal.Parse(StringsHelper.Replace(Conversion.Str(Math.Floor((double) pTotalAmt)) + StringsHelper.Replace(StringsHelper.Format(n, "####.000"), ".", "", 1, -1, CompareMethod.Binary), " ", "", 1, -1, CompareMethod.Binary), NumberStyles.Currency | NumberStyles.AllowExponent); 
					 
					mString = "2" + StringsHelper.Format(pTotalRecords, "00000") + 
					          ResizeString(StringsHelper.Format(pTotalAmt, "0000000000000"), 13) + new String(' ', 70); 
					break;
				case 11 : 
					//'' Burgan Bank BDinar 
					n = (double) (pTotalAmt - ((decimal) Math.Floor((double) pTotalAmt))); 
					// function is used to remove decimal point from the number and join them like 000010.5 = 0000105 
					pTotalAmt = Decimal.Parse(StringsHelper.Replace(Conversion.Str(Math.Floor((double) pTotalAmt)) + StringsHelper.Replace(StringsHelper.Format(n, "####.000"), ".", "", 1, -1, CompareMethod.Binary), " ", "", 1, -1, CompareMethod.Binary), NumberStyles.Currency | NumberStyles.AllowExponent); 
					mString = "2" + StringsHelper.Format(pTotalRecords, "00000") + 
					          ResizeString(StringsHelper.Format(pTotalAmt, "0000000000000"), 13) + new String(' ', 70); 
					 
					break;
			}

			return mString;

		}


		private string ResizeString(string pString, int pSize)
		{
			int mSpace = 0;
			if (pSize > Strings.Len(pString))
			{
				mSpace = pSize - Strings.Len(pString);
			}
			else
			{
				mSpace = 0;
			}
			return pString + new String(' ', mSpace);

		}
	}
}