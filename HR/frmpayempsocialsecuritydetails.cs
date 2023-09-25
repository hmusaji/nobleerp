
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayEmpSocialSecurityDetails
		: System.Windows.Forms.Form
	{

		public frmPayEmpSocialSecurityDetails()
{
InitializeComponent();
} 
 public  void frmPayEmpSocialSecurityDetails_old()
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


		private void frmPayEmpSocialSecurityDetails_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
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

		private const int conSRNo = 0;
		private const int conEmpNo = 1;
		private const int conEmpName = 2;
		private const int conHireDate = 3;
		private const int conEmpSal = 4;
		private const int conAdditionalSal = 5;
		private const int conTotalSal = 6;
		private const int conSSBasicSal = 7;
		private const int conSSAdditionalSal = 8;
		private const int conSSTotalSalary = 9;
		private const int conSSOnBasic = 10;
		private const int conSSOnAddition = 11;
		private const int conSSOnTotal = 12;
		private const int conSSNet = 13;
		private const int conSSCompanyShare = 14;
		private const int conEmployeeShare = 15;
		private const int conEntryId = 16;
		private const int conLineNo = 17;

		private const int conMaxColumns = 18;

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
		}


		public SystemVariables.SystemFormModes CurrentFormModde
		{
			set
			{
				mCurrentFormMode = value;
			}
		}


		private void cmdGenerate_Click(Object eventSender, EventArgs eventArgs)
		{
			if (SystemHRProcedure.GeneratePayrollSocialSecurity("", ""))
			{
				MessageBox.Show("Payroll Entry has generated!", "Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Generated error!", "Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void cmdRefresh_Click(Object eventSender, EventArgs eventArgs)
		{
			SystemHRProcedure.GenerateSocialSecurity();
			FillGridData();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				this.Top = 0;
				this.Left = 0;

				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = false;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = false;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = false;
				oThisFormToolBar.ShowHelpButton = false;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = false;
				oThisFormToolBar.DisableHelpButton = false;

				this.WindowState = FormWindowState.Maximized;

				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdSocialSecurityDet, false, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.4f, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "Emp No", 700, false, SystemConstants.gDisableColumnBackColor);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "EmpName", 2500, false, SystemConstants.gDisableColumnBackColor);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "HireDare", 1000, false, SystemConstants.gDisableColumnBackColor);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "Emp Sys Salary", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "Additional Salary", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "Total Salay", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "SS Basic", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "SS Additional", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "SS Total", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "SS On Basic", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "SS On Additional", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "SS On Total", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "SS Total", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "Company Share", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "Emp Share", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "Entry Id", 10, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdSocialSecurityDet, "Line No", 10, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				//Call GenerateSocialSecurity("", "")


				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdSocialSecurityDet.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdSocialSecurityDet.setArray(aVoucherDetails);
				grdSocialSecurityDet.Rebind(true);

				FillGridData();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
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


		private void AssignGridLineNumbers()
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

		private void FillGridData()
		{
			try
			{
				System.DateTime mGenerateDate = DateTime.FromOADate(0);
				System.DateTime mStartDate = DateTime.FromOADate(0);
				string mSQL = "";
				DataSet rsLocal = null;
				int cnt = 0;
				object mReturnValue = null;

				mGenerateDate = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate());
				mStartDate = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate());

				mSQL = " select pessd.line_no,pessd.entry_id,pessd.emp_cd,pessd.pay_date,pessd.emp_salary";
				mSQL = mSQL + ",pessd.additional_allowance,pessd.ss_basic_salary,pessd.ss_additional_salary,pessd.ss_total_salary";
				mSQL = mSQL + " ,pessd.ss_on_basic,pessd.ss_on_additional,pessd.ss_on_total,pessd.ss_company_share";
				mSQL = mSQL + " ,pessd.ss_employee_share,pemp.emp_no , pemp.l_full_name , pemp.date_of_joining";
				mSQL = mSQL + " from pay_employee_social_security_details pessd";
				mSQL = mSQL + " inner join pay_employee pemp on pemp.emp_cd = pessd.emp_cd";
				mSQL = mSQL + " where pessd.pay_date = '" + SystemHRProcedure.GetPayrollGenerateDate() + "'";

				rsLocal = new DataSet();
				SqlDataAdapter adap = new SqlDataAdapter(mSQL, SystemVariables.gConn);
				rsLocal.Tables.Clear();
				adap.Fill(rsLocal);
				cnt = 0;
				aVoucherDetails.RedimXArray(new int[]{rsLocal.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
				foreach (DataRow iteration_row in rsLocal.Tables[0].Rows)
				{
					aVoucherDetails.SetValue(iteration_row["line_no"], cnt, conLineNo);
					aVoucherDetails.SetValue(iteration_row["Entry_id"], cnt, conEntryId);
					aVoucherDetails.SetValue(iteration_row["emp_no"], cnt, conEmpNo);
					aVoucherDetails.SetValue(iteration_row["l_full_name"], cnt, conEmpName);
					aVoucherDetails.SetValue(iteration_row["date_of_joining"], cnt, conHireDate);
					aVoucherDetails.SetValue(iteration_row["emp_salary"], cnt, conEmpSal);
					aVoucherDetails.SetValue(iteration_row["additional_allowance"], cnt, conAdditionalSal);
					//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
					aVoucherDetails.SetValue(Convert.ToDouble(iteration_row["emp_salary"]) + Convert.ToDouble(iteration_row["additional_allowance"]), cnt, conTotalSal);
					aVoucherDetails.SetValue(iteration_row["ss_basic_salary"], cnt, conSSBasicSal);
					aVoucherDetails.SetValue(iteration_row["ss_additional_salary"], cnt, conSSAdditionalSal);
					aVoucherDetails.SetValue(iteration_row["ss_total_salary"], cnt, conSSTotalSalary);
					aVoucherDetails.SetValue(iteration_row["ss_on_basic"], cnt, conSSOnBasic);
					aVoucherDetails.SetValue(iteration_row["ss_on_additional"], cnt, conSSOnAddition);
					aVoucherDetails.SetValue(iteration_row["ss_on_total"], cnt, conSSOnTotal);
					//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
					//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
					aVoucherDetails.SetValue(Convert.ToDouble(Convert.ToDouble(iteration_row["ss_on_basic"]) + Convert.ToDouble(iteration_row["ss_on_additional"])) + Convert.ToDouble(iteration_row["ss_on_total"]), cnt, conSSNet);
					aVoucherDetails.SetValue(iteration_row["ss_company_share"], cnt, conSSCompanyShare);
					aVoucherDetails.SetValue(iteration_row["ss_employee_share"], cnt, conEmployeeShare);
					cnt++;
				}

				AssignGridLineNumbers();
				grdSocialSecurityDet.Rebind(true);
				grdSocialSecurityDet.Refresh();
				Application.DoEvents();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(excep.Message + " " + Information.Err().Number.ToString(), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

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
				frmPayDesignation.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}


		public bool saveRecord()
		{
			bool result = false;
			StringBuilder mysql = new StringBuilder();
			int mEmpCd = 0;
			int cnt = 0;
			try
			{
				grdSocialSecurityDet.UpdateData();
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					mEmpCd = SystemHRProcedure.GetEmpCd(Convert.ToString(aVoucherDetails.GetValue(cnt, conEmpNo)));
					mysql = new StringBuilder(" Update pay_employee_social_security_details SET ");
					mysql.Append(" Entry_Id = " + Convert.ToString(aVoucherDetails.GetValue(cnt, conEntryId)));
					mysql.Append(" , Emp_cd =" + mEmpCd.ToString());
					mysql.Append(" , Emp_Salary =" + Convert.ToString(aVoucherDetails.GetValue(cnt, conEmpSal)));
					mysql.Append(" , Additional_Allowance =" + Convert.ToString(aVoucherDetails.GetValue(cnt, conAdditionalSal)));
					mysql.Append(" , SS_Basic_Salary =" + Convert.ToString(aVoucherDetails.GetValue(cnt, conSSBasicSal)));
					mysql.Append(" , SS_Additional_Salary =" + Convert.ToString(aVoucherDetails.GetValue(cnt, conSSAdditionalSal)));
					mysql.Append(" , SS_Total_Salary =" + Convert.ToString(aVoucherDetails.GetValue(cnt, conSSTotalSalary)));
					mysql.Append(" , SS_On_Basic =" + Convert.ToString(aVoucherDetails.GetValue(cnt, conSSOnBasic)));
					mysql.Append(" , SS_On_Additional=" + Convert.ToString(aVoucherDetails.GetValue(cnt, conSSOnAddition)));
					mysql.Append(" , SS_On_Total=" + Convert.ToString(aVoucherDetails.GetValue(cnt, conSSOnTotal)));
					mysql.Append(" , SS_Company_Share=" + Convert.ToString(aVoucherDetails.GetValue(cnt, conSSCompanyShare)));
					mysql.Append(" , SS_Employee_Share=" + Convert.ToString(aVoucherDetails.GetValue(cnt, conEmployeeShare)));
					mysql.Append(" , User_Cd =" + SystemVariables.gLoggedInUserCode.ToString());
					mysql.Append(" , Modified_Date_Time = '" + DateTime.Today.ToString("dd-MMM-yyyy") + "'");
					mysql.Append(" where pay_date ='" + SystemHRProcedure.GetPayrollGenerateDate() + "' and emp_cd = " + mEmpCd.ToString());
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql.ToString();
					TempCommand.ExecuteNonQuery();
				}
				MessageBox.Show("Data Updated Successfully!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				CloseForm();
				return true;
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				result = false;
			}
			return result;
		}


		private void UpdateGridData(int pCurrRow)
		{

			int cnt = pCurrRow;

			aVoucherDetails.SetValue(Convert.ToInt32(aVoucherDetails.GetValue(cnt, conEmpSal)) + Convert.ToInt32(aVoucherDetails.GetValue(cnt, conAdditionalSal)), cnt, conTotalSal);
			aVoucherDetails.SetValue((Convert.ToDouble(aVoucherDetails.GetValue(cnt, conTotalSal)) > 1500) ? ((object) 1500) : aVoucherDetails.GetValue(cnt, conTotalSal), cnt, conSSBasicSal);
			aVoucherDetails.SetValue(((Convert.ToDouble(aVoucherDetails.GetValue(cnt, conTotalSal)) - 1500) > 1250) ? 1250 : Math.Max(Convert.ToDouble(aVoucherDetails.GetValue(cnt, conTotalSal)) - 1500, 0), cnt, conSSAdditionalSal);
			//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
			aVoucherDetails.SetValue(Convert.ToDouble(aVoucherDetails.GetValue(cnt, conSSBasicSal)) + Convert.ToDouble(aVoucherDetails.GetValue(cnt, conSSAdditionalSal)), cnt, conSSTotalSalary);
			aVoucherDetails.SetValue(Convert.ToDouble(aVoucherDetails.GetValue(cnt, conSSBasicSal)) * 0.15d, cnt, conSSOnBasic);
			aVoucherDetails.SetValue(Convert.ToDouble(aVoucherDetails.GetValue(cnt, conSSAdditionalSal)) * 0.15d, cnt, conSSOnAddition);
			aVoucherDetails.SetValue(Convert.ToDouble(aVoucherDetails.GetValue(cnt, conSSTotalSalary)) * 0.035d, cnt, conSSOnTotal);
			//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
			//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
			aVoucherDetails.SetValue(Convert.ToDouble(Convert.ToDouble(aVoucherDetails.GetValue(cnt, conSSOnTotal)) + Convert.ToDouble(aVoucherDetails.GetValue(cnt, conSSOnAddition))) + Convert.ToDouble(aVoucherDetails.GetValue(cnt, conSSOnBasic)), cnt, conSSNet);

			if (Convert.ToDouble(aVoucherDetails.GetValue(cnt, conSSCompanyShare)) > 0)
			{
				aVoucherDetails.SetValue(Convert.ToDouble(aVoucherDetails.GetValue(cnt, conSSTotalSalary)) * 0.11d, cnt, conSSCompanyShare);
			}
			else
			{
				aVoucherDetails.SetValue(0, cnt, conSSCompanyShare);
			}
			aVoucherDetails.SetValue(Convert.ToDouble(aVoucherDetails.GetValue(cnt, conSSNet)) - Convert.ToDouble(aVoucherDetails.GetValue(cnt, conSSCompanyShare)), cnt, conEmployeeShare);

			grdSocialSecurityDet.Rebind(true);
			grdSocialSecurityDet.Refresh();
		}

		private void grdSocialSecurityDet_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;

			//UPGRADE_WARNING: (1068) grdSocialSecurityDet.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mCurrRow = ReflectionHelper.GetPrimitiveValue<int>(grdSocialSecurityDet.Bookmark);
			grdSocialSecurityDet.UpdateData();
			UpdateGridData(mCurrRow);

		}
	}
}