
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayLeaveResume
		: System.Windows.Forms.Form
	{

		public frmPayLeaveResume()
{
InitializeComponent();
} 
 public  void frmPayLeaveResume_old()
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


		private void frmPayLeaveResume_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private bool mCheck = false;

		private const int conTxtVoucherNo = 0;
		private const int conTxtEmpCode = 1;
		private const int conTXTReferenceNo = 2;
		private const int conTxtLeaveCode = 3;
		private const int conTxtComments = 4;

		private const int conDlblDeptCode = 0;
		private const int conDlblDeptName = 1;
		private const int conDlblDesgCode = 2;
		private const int conDlblDesgName = 3;
		private const int conDlblBasicSalary = 4;
		private const int conDlblEmpName = 5;
		private const int conDlblLeaveName = 6;
		private const int conDlblLeaveBalanceDays = 7;
		private const int conDlblVoucheDate = 8;
		private const int conDlblTotalSalary = 9;
		private const int conDlblLeaveFromDate = 10;
		private const int conDlblLeaveToDate = 11;
		private const int conDlblStatus = 12;

		private const int conDTxtResumeDate = 0;
		private const int conDTxtActualResumeDate = 1;

		private const int conNTxtLeaveDays = 0;
		private const int conNTxtActualLeaveDays = 1;
		private const int conNTxtPaidDays = 2;
		private const int conNTxtUnPaidDays = 3;
		private const int conNTxtPaidHours = 4;

		private clsToolbar oThisFormToolBar = null;
		private string mTimeStamp = "";
		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;
		private bool mIncludeInDefaultLeave = false;
		private double mLeaveSalary = 0;
		private double mLeaveAmountPerDay = 0;

		private const int contabResume = 0;
		private const int contabApproval = 1;
		int mTemplateEntID = 0;


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


		private void cmdSubmmitApproval_Click(Object eventSender, EventArgs eventArgs)
		{
			DialogResult ans = (DialogResult) 0;
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				ans = MessageBox.Show("Do you want to save this record!!!", "Save", MessageBoxButtons.YesNo);
				if (ans == System.Windows.Forms.DialogResult.Yes)
				{
					if (saveRecord())
					{
						SystemHRProcedure.ApprovalSubmmit(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 2, mTemplateEntID, "Resumtion Transaction For Emp No :" + txtCommonTextBox[conTxtEmpCode].Text);
						AddRecord();
						MessageBox.Show("Approval Submitted Successfully::", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			else
			{
				if (SystemHRProcedure.CheckApprovalIsSubmmited(2, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue)))
				{
					if (saveRecord())
					{
						SystemHRProcedure.ApprovalSubmmit(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 2, mTemplateEntID, "Resumtion Transaction For Emp No :" + txtCommonTextBox[conTxtEmpCode].Text);
						AddRecord();
						MessageBox.Show("Approval Submitted Successfully::", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else
				{
					MessageBox.Show("Already Submitted for this record:", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			FirstFocusObject = txtCommonDate[conDTxtActualResumeDate];

			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
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
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowUnpostButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;


				//'Assign the Image for the toolbar
				//'Imagelist are kept on the main form and refered by their key
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(1))
				//'Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//'Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture
				//Set btnFormToolBar(7).Picture = frmSysMain.imlSystemIcons.ListImages("imgPostingTransactions").Picture

				SystemProcedure.SetLabelCaption(this);
				this.tabResume.CurrTab = Convert.ToInt16(contabResume);
				this.tabResume.set_TabVisible(Convert.ToInt16(contabApproval), SystemHRProcedure.IsApprovalEnabled(2));

				txtCommonDate[conDTxtResumeDate].Text = "";
				txtCommonDate[conDTxtActualResumeDate].Text = "";
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
				if (this.ActiveControl.Name == "txtCommonTextBox")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommonTextBox#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void AddRecord()
		{
			//Add a record
			//mCheck = False
			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearNumberBox(this);
			txtCommonDate[conDTxtResumeDate].Enabled = false;
			txtCommonDate[conDTxtActualResumeDate].Enabled = false;
			//txtCommonTextBox(conTxtComments).Enabled = False
			txtAdjustPaidDays.Value = 0;
			txtAdjustUnpaidDays.Value = 0;
			txtEncashmentDays.Value = 0;
			txtGrantDays.Value = 0;
			txtDisplayVariationDays.Text = "0";
			mIncludeInDefaultLeave = false;
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			//FirstFocusObject.SetFocus
			this.tabResume.CurrTab = Convert.ToInt16(contabResume);
			//mCheck = True
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord(bool pApprove = false)
		{
			bool result = false;
			object mReturnValue = null;
			string mysql = "";
			double mTotalAdjustDays = 0;

			try
			{


				if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Select a transaction !", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//FirstFocusObject.SetFocus
					return false;
				}

				mTotalAdjustDays = Math.Abs(ReflectionHelper.GetPrimitiveValue<double>(txtAdjustPaidDays.Value)) + Math.Abs(ReflectionHelper.GetPrimitiveValue<double>(txtAdjustUnpaidDays.Value)) + Math.Abs(ReflectionHelper.GetPrimitiveValue<double>(txtEncashmentDays.Value)) + Math.Abs(ReflectionHelper.GetPrimitiveValue<double>(txtGrantDays.Value));
				if (Math.Abs(Double.Parse(txtDisplayVariationDays.Text)) != mTotalAdjustDays)
				{
					MessageBox.Show("Please Adjust variation Days!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				mysql = " select pemp.status_cd from pay_leave_transaction plt inner join pay_employee pemp on pemp.emp_cd = plt.emp_cd where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == SystemHRProcedure.gStatusTerminated)
					{
						MessageBox.Show("Severance for this employee already made!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return result;
					}
				}
				else
				{
					MessageBox.Show("this record is not find!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return result;
				}

				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				mysql = " select time_stamp, resume_processed_status from pay_leave_transaction where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				}
				else
				{
					MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					result = false;
					FirstFocusObject.Focus();
					return result;
				}

				if (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp))
				{
					MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					result = false;
					FirstFocusObject.Focus();
					return result;
				}

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1))) == TriState.True)
				{
					MessageBox.Show("Resume Transaction already processed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}

				mysql = " update  pay_leave_transaction set ";
				mysql = mysql + " expected_resume_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtResumeDate].DisplayText) + "'";
				mysql = mysql + " , actual_resume_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtActualResumeDate].DisplayText) + "'";
				//added by burhan. Date: 12-jun-2008
				mysql = mysql + " , adjust_paid_days = " + StringsHelper.Format(txtAdjustPaidDays.Text, "####0.000");
				mysql = mysql + " , adjust_unpaid_days = " + StringsHelper.Format(txtAdjustUnpaidDays.Text, "####0.000");
				mysql = mysql + " , leave_bal_on_resume = " + StringsHelper.Format(txtLeaveBalOnResume.Text, "####0.000");
				mysql = mysql + " , adjusted_salary = " + StringsHelper.Format(txtSalaryAdjusted.Text, "####0.000");
				//end
				mysql = mysql + " , comments =N'" + txtCommonTextBox[conTxtComments].Text + "'";
				mysql = mysql + " , Leave_Encashment_Days = " + StringsHelper.Format(txtEncashmentDays.Text, "####0.000");
				mysql = mysql + " , Grant_Days = " + StringsHelper.Format(txtGrantDays.Text, "####0.000");
				mysql = mysql + " , Resume_Variation_Days = " + Conversion.Val(txtDisplayVariationDays.Text).ToString();
				mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
				mysql = mysql + " where entry_id=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//    mysql = " update pay_employee "
				//    mysql = mysql & " set status_cd = 1 "
				//    mysql = mysql & " from pay_employee pemp"
				//    mysql = mysql & " inner join pay_leave_transaction plt on pemp.emp_cd = plt.emp_cd "
				//    mysql = mysql & " where entry_id = " & Str(mSearchValue)
				//    gConn.Execute mysql
				//End If

				if (pApprove)
				{
					if (!SystemHRProcedure.GetTransactionApprovalStage(2, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 2))
					{
						MessageBox.Show("You Cannot Post this record!!!", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return result;
					}
					Employee_Resume_Post_Effect("Pay_leave_transaction", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
				}


				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
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
				result = false;
			}
			return result;
		}

		public object deleteRecord()
		{

			return null;
		}

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			//On Error GoTo eFoundError

			string mysql = " select plt.* ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "isnull(l_first_name,'') + ' ' + isnull(l_second_name,'') + ' ' + isnull(l_third_name,'') + ' ' + isnull(l_fourth_name,'')" : "isnull(a_first_name,'') + ' ' + isnull(a_second_name,'') + ' ' + isnull(a_third_name,'') + ' ' + isnull(a_fourth_name,'')") + " as emp_name ";
			mysql = mysql + " , dept_no ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name") + " as dept_name ";
			mysql = mysql + " , desg_no ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name") + " as desg_name ";
			mysql = mysql + " , emp_no ";
			mysql = mysql + " , pemp.basic_salary, pemp.total_salary ";
			mysql = mysql + " , leave_no ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_leave_name" : "a_leave_name") + " as leave_name ";
			mysql = mysql + " , pleave.include_weekend ";
			mysql = mysql + " , sat.trans_no, sat.l_approval_name , pemp.date_of_joining";
			mysql = mysql + " from pay_leave_transaction plt ";
			mysql = mysql + " inner join pay_employee pemp on plt.emp_cd = pemp.emp_cd ";
			mysql = mysql + " inner join pay_leave pleave on plt.leave_cd = pleave.leave_cd ";
			mysql = mysql + " inner join pay_department pdept on  pemp.dept_cd = pdept.dept_cd ";
			mysql = mysql + " inner join pay_designation pdesg on  pemp.desg_cd = pdesg.desg_cd  ";
			mysql = mysql + " left outer join sys_approval_template sat on plt.template_entry_id = sat.entry_id";
			mysql = mysql + " where plt.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

			DataSet localRec = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			localRec.Tables.Clear();
			adap.Fill(localRec);
			if (localRec.Tables[0].Rows.Count != 0)
			{
				//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(SearchValue);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mTimeStamp = Convert.ToString(localRec.Tables[0].Rows[0]["time_stamp"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mIncludeInDefaultLeave = Convert.ToBoolean(localRec.Tables[0].Rows[0]["include_weekend"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtVoucherNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["voucher_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblVoucheDate].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTXTReferenceNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["reference_no"]) + "";

				// Commented by Burhanuddin Ghee Wala
				// Date 06-Jun-2007, problem was tht if employee was on leave status was showing "Resumed" only
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToDouble(localRec.Tables[0].Rows[0]["resume_processed_status"]) == 1)
				{
					txtDisplayLabel[conDlblStatus].Text = "On Leave";
				}
				else
				{
					txtDisplayLabel[conDlblStatus].Text = "Resumed";
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(localRec.Tables[0].Rows[0]["resume_processed_status"])) == TriState.True)
				{
					txtCommonDate[conDTxtResumeDate].Enabled = false;
					txtCommonDate[conDTxtActualResumeDate].Enabled = false;
					//txtCommonTextBox(conTxtComments).Enabled = False
				}
				else
				{
					txtCommonDate[conDTxtResumeDate].Enabled = false;
					txtCommonDate[conDTxtActualResumeDate].Enabled = true;
					//txtCommonTextBox(conTxtComments).Enabled = True
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtEmpCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["emp_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblEmpName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["emp_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDeptCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["dept_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDeptName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["dept_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDesgCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["desg_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDesgName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["desg_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblBasicSalary].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["basic_salary"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblTotalSalary].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["total_salary"], "###,###,##0.000");

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtLeaveCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["leave_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLeaveName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["leave_name"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLeaveFromDate].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["leave_start_date"], SystemVariables.gSystemDateFormat);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLeaveToDate].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["leave_end_date"], SystemVariables.gSystemDateFormat);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtLeaveDays].Value = localRec.Tables[0].Rows[0]["leave_days"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLeaveBalanceDays].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["leave_balance_days"], "###,###,##0.000");

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtActualLeaveDays].Value = localRec.Tables[0].Rows[0]["actual_leave_days"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtPaidDays].Value = localRec.Tables[0].Rows[0]["paid_days"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtUnPaidDays].Value = localRec.Tables[0].Rows[0]["unpaid_days"];
				//added by burhan. Date: 12-Jun-2008
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtPaidHours].Value = localRec.Tables[0].Rows[0]["paid_hours"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtAdjustPaidDays.Value = localRec.Tables[0].Rows[0]["adjust_paid_days"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtAdjustUnpaidDays.Value = localRec.Tables[0].Rows[0]["adjust_unpaid_days"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtSalaryAdjusted.Value = localRec.Tables[0].Rows[0]["adjusted_salary"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtEncashmentDays.Value = localRec.Tables[0].Rows[0]["Leave_Encashment_Days"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtGrantDays.Value = localRec.Tables[0].Rows[0]["Grant_Days"];
				//end
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mLeaveSalary = Convert.ToDouble(localRec.Tables[0].Rows[0]["Leave_Salary"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!SystemProcedure2.IsItEmpty(localRec.Tables[0].Rows[0]["Paid_Days"], SystemVariables.DataType.NumberType) && !SystemProcedure2.IsItEmpty(localRec.Tables[0].Rows[0]["Leave_Salary_Amount"], SystemVariables.DataType.NumberType))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mLeaveAmountPerDay = Convert.ToDouble(localRec.Tables[0].Rows[0]["Leave_Salary_Amount"]) / ((double) Convert.ToDouble(localRec.Tables[0].Rows[0]["Paid_Days"]));
				}
				else
				{
					mLeaveAmountPerDay = 0;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtComments].Text = Convert.ToString(localRec.Tables[0].Rows[0]["comments"]) + "";

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (localRec.Tables[0].Rows[0].IsNull("expected_resume_date"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDate[conDTxtResumeDate].Value = Convert.ToDouble(localRec.Tables[0].Rows[0]["leave_end_date"]) + 1;
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDate[conDTxtResumeDate].Value = localRec.Tables[0].Rows[0]["expected_resume_date"];
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (localRec.Tables[0].Rows[0].IsNull("actual_resume_date"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDate[conDTxtActualResumeDate].Value = Convert.ToDouble(localRec.Tables[0].Rows[0]["leave_end_date"]) + 1;
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDate[conDTxtActualResumeDate].Value = localRec.Tables[0].Rows[0]["actual_resume_date"];
				}
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtJoiningDate.Value = localRec.Tables[0].Rows[0]["date_of_joining"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mTemplateEntID = (localRec.Tables[0].Rows[0].IsNull("Template_Entry_id")) ? 0 : Convert.ToInt32(localRec.Tables[0].Rows[0]["Template_Entry_id"]);
				//Assign Approval Template
				if (mTemplateEntID == 0)
				{
					txtApprovalTemplate.Text = "";
					txtDlblAppTemplateName.Text = "";
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtApprovalTemplate.Text = Convert.ToString(localRec.Tables[0].Rows[0]["trans_no"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtDlblAppTemplateName.Text = Convert.ToString(localRec.Tables[0].Rows[0]["l_approval_name"]);
				}
				//End
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayVariationDays.Text = Convert.ToString(localRec.Tables[0].Rows[0]["Resume_Variation_Days"]);

				//Change the form mode to edit
				//mCurrentFormMode = frmEditMode

				//Set the form caption and Get the Voucher Status
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, frmPayLeaveResume.DefInstance, Convert.ToInt32(localRec.Tables[0].Rows[0]["resume_processed_status"]), CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Employee Resume" : "Employee Resume");

			}
			localRec = null;

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}


		public void PrintReport()
		{

			//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
			SystemReports.GetCrystalReport(110121230, 2, "9417", Conversion.Str(mEntryId), false);
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7015000, "", " status = 2 and Not (pemp.status_cd in (3,4) and plt.Resume_Processed_Status = 1)"));
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

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				if (!SystemHRProcedure.GetTransactionApprovalStage(2, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 1))
				{
					MessageBox.Show("Cannot edit this record!!!", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
					goto mend;
				}
			}


			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 3);
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
			}
			else
			{


				if (!Information.IsDate(txtCommonDate[conDTxtResumeDate].DisplayText))
				{
					MessageBox.Show("Enter valid date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonDate[conDTxtResumeDate].Focus();
				}
				else
				{

					if (!Information.IsDate(txtCommonDate[conDTxtActualResumeDate].DisplayText))
					{
						MessageBox.Show("Enter valid date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommonDate[conDTxtActualResumeDate].Focus();
					}
					else
					{

						if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtActualResumeDate].DisplayText) < DateTime.Parse(SystemHRProcedure.GetPayrollSalaryDate()))
						{
							MessageBox.Show("Resumption date cannot be of previous month!!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtCommonDate[conDTxtActualResumeDate].Focus();
						}
						else
						{


							if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtResumeDate].Value) < DateTime.Parse(txtDisplayLabel[conDlblLeaveFromDate].Text))
							{
								MessageBox.Show(" Resume date cannot be less than leave start date!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
								txtCommonDate[conDTxtResumeDate].Focus();
							}
							else
							{

								return true;

							}
						}
					}
				}
			}
			mend:
			return false;
		}


		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmPayLeaveResume.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
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
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				return result;
			}

			//If mOldVoucherStatus = stActive Then
			//    frmTemp.VisiblePostTransactionToICS = False
			//    frmTemp.VisiblePostToGL = False
			//    frmTemp.EnableApprove = True
			//End If
			//'''  to resume all Leave
			//''' As On Date 01-jul-2009
			if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtActualResumeDate].Value) < DateTime.Parse(SystemHRProcedure.GetPayrollSalaryDate()))
			{
				MessageBox.Show("Back dated transaction cannot be posted!", "Post", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtActualResumeDate].Value) > DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()))
			{
				MessageBox.Show("Future resumption will be post in next month.", "Post", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			//''' End


			frmTemp.ShowDialog();

			//if the user clicks on OK button in the frmPost form
			//If frmTemp.mLastButtonClicked = 1 And frmTemp.mApprove = True Then
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
							Employee_Resume_Post_Effect("Pay_leave_transaction", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
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

		private void Employee_Resume_Post_Effect(string pMasterTableName, int pEntryId)
		{

			string mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();
			int mLastMonthEarningDays = 0;


			//''modified by hakim on 24-may-2009
			//mySQL = " select Weekend_Day1_Id,Weekend_Day2_Id from pay_employee where emp_cd = (select emp_cd from pay_leave_transaction where entry_id = " & pEntryId & ")"
			//mReturnValue = GetMasterCode(mySQL)
			string mysql = " select pemp.Weekend_Day1_Id, pemp.Weekend_Day2_Id, plt.is_pay_closed ";
			mysql = mysql + " from pay_employee pemp ";
			mysql = mysql + " inner join pay_leave_transaction plt on pemp.emp_cd = plt.emp_cd";
			mysql = mysql + " where plt.entry_id =" + pEntryId.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));


			if (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(2)) && DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()) > ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtActualResumeDate].Value) && ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtActualResumeDate].Value) >= DateTime.Parse(SystemHRProcedure.GetPayrollSalaryDate()))
			{
				mLastMonthEarningDays = Convert.ToInt32(SystemHRProcedure.CalculateDays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtActualResumeDate].Value), DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddDays(-1), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1))));
			}
			else
			{
				mLastMonthEarningDays = 0;
			}


			mysql = "update " + pMasterTableName;
			mysql = mysql + " set resume_processed_status = 2 ";
			mysql = mysql + ", resumed_payroll_date ='" + mGenerateDate + "'";
			mysql = mysql + ", last_month_earning_days = " + mLastMonthEarningDays.ToString();
			mysql = mysql + " where entry_id =" + Conversion.Str(pEntryId);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			//'' Date:02-Jan-2012
			//''For Updating process Date in Leave Transaction
			mysql = " update pay_leave_transaction ";
			mysql = mysql + " set  resumed_payroll_date = '" + StringsHelper.Format(SystemHRProcedure.GetPayrollGenerateDate(), SystemVariables.gSystemDateFormat) + "'";
			if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtActualResumeDate].Value) < DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()))
			{
				mysql = mysql + ", Resume_ProcessDate = '" + StringsHelper.Format(SystemHRProcedure.GetPayrollGenerateStartDate(), SystemVariables.gSystemDateFormat) + "'";
			}
			else if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtActualResumeDate].Value) > DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()))
			{ 
				mysql = mysql + ", Resume_ProcessDate = '" + StringsHelper.Format(SystemHRProcedure.GetPayrollGenerateDate(), SystemVariables.gSystemDateFormat) + "'";
			}
			else
			{
				mysql = mysql + ", Resume_ProcessDate = '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtActualResumeDate].Value) + "'";
			}
			mysql = mysql + " where entry_id =" + Conversion.Str(pEntryId);
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();


			mysql = " update pay_employee ";
			mysql = mysql + " set status_cd = 1 ";

			//'''''
			//'''modified on 18-sep-2006
			//'''this was done because payroll will be generated for both paynow and paywithpayroll
			//'''in case of paynow a deduction entry has to be done in order to make the payroll zero for an employee.
			//mySql = mySql & " , last_salary_date = case when leave_amount_payment_type_id= " & gPayNow
			//mySql = mySql & " then plt.expected_resume_date - 1 "
			//mySql = mySql & " else pemp.last_salary_date "
			//mySql = mySql & " end "
			mysql = mysql + " from pay_employee pemp ";
			mysql = mysql + " inner join pay_leave_transaction plt on pemp.emp_cd = plt.emp_cd ";
			mysql = mysql + " where entry_id = " + Conversion.Str(pEntryId);
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mysql;
			TempCommand_3.ExecuteNonQuery();

			mysql = "select leave_amount_payment_type_id from pay_leave_transaction where entry_id =" + Conversion.Str(pEntryId);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == 53)
			{
				mysql = " update pay_employee ";
				mysql = mysql + " set ";
				mysql = mysql + " last_salary_date= '" + (DateTimeHelper.ToString(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtActualResumeDate].DisplayText).AddDays(-1))) + "'";
				mysql = mysql + " from pay_employee pemp ";
				mysql = mysql + " where pemp.emp_no='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();
			}

			SystemHRProcedure.enumTAFields mFieldId = (SystemHRProcedure.enumTAFields) 0;

			mysql = " select pemp.emp_no,pemp.emp_cd, l.leave_type_cd, plvt.auto_resume ";
			mysql = mysql + " from pay_leave_transaction plt";
			mysql = mysql + " inner join pay_leave l on l.leave_cd = plt.leave_cd ";
			mysql = mysql + " inner join pay_leave_type plvt on plvt.type_cd = l.leave_type_cd";
			mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = plt.emp_cd ";
			mysql = mysql + " where plt.entry_id = " + Conversion.Str(pEntryId);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();
			//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			string mEmpNo = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
			//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
			if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2)) == 11)
			{
				mFieldId = SystemHRProcedure.enumTAFields.eTASickHours;
				//ElseIf mReturnValue(2) = 7 Then
				//    mFieldId = eTAAbsentHours
			}
			else
			{
				mFieldId = SystemHRProcedure.enumTAFields.eTAVacationHours;
			}

			UpdateTimeAttendance(mEmpCd, txtDisplayLabel[11].Text, ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtActualResumeDate].DisplayText), mFieldId, ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(3)));
			SystemHRProcedure.ClearPayroll(mGenerateDate, mEmpNo, mEmpNo);
			SystemHRProcedure.GeneratePayrollEntry(mGenerateDate, mEmpNo, mEmpNo);
			SystemHRProcedure.GenerateLeaveEntry(mGenerateDate, mEmpNo, mEmpNo);
			SystemHRProcedure.GenerateLoanEntry(mGenerateDate, mEmpNo, mEmpNo);
			//Call AlarmStatusUpdate(2, CLng(mSearchValue), 1)
		}

		public bool UnPost()
		{

			bool result = false;
			string mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();
			if (txtDisplayLabel[conDlblLeaveFromDate].Text == "")
			{
				MessageBox.Show("Please select a valid record!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			string mDtFrom = txtDisplayLabel[conDlblLeaveFromDate].Text;

			//mysql = "select is_pay_closed from pay_leave_transaction where entry_id =" & CLng(mSearchValue)
			//mReturnValue = GetMasterCode(mysql)
			//
			//If mReturnValue = True Then
			//    MsgBox "Can not Unpost, Payroll month is closed!!", vbInformation
			//    UnPost = False
			//    Exit Function
			//End If
			//


			string mysql = "select resume_processed_status, Resume_ProcessDate   from pay_leave_transaction where entry_id=" + ReflectionHelper.GetPrimitiveValue<int>(mSearchValue).ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0)) == 1)
			{
				MessageBox.Show("Cannot Unpost resume. Voucher is Active.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue).GetValue(1)) < DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()))
			{
				MessageBox.Show("Cannot Unpost last month resume.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}


			mysql = "select count(*) from pay_leave_transaction plt  ";
			mysql = mysql + " inner join pay_employee pemp on plt.emp_cd = pemp.emp_cd ";
			mysql = mysql + " where pemp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "' and leave_start_date > '" + mDtFrom + "'";

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) > 0)
			{
				MessageBox.Show("Can not Unpost, Transaction(s) after date " + mDtFrom + " already exits!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return false;
			}

			DialogResult ans = MessageBox.Show("Are you sure you want to Unpost the voucher ?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
			if (ans == System.Windows.Forms.DialogResult.Yes)
			{
				SystemVariables.gConn.BeginTransaction();
				Employee_Resume_Unpost_Effect("pay_leave_transaction", ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				//Call AlarmStatusUpdate(2, CLng(mSearchValue), 0)
				AddRecord();
				result = true;
			}
			else if (ans == System.Windows.Forms.DialogResult.No)
			{ 
				AddRecord();
			}
			else if (ans == System.Windows.Forms.DialogResult.Cancel)
			{ 
				result = false;
			}

			return result;
		}


		private void Employee_Resume_Unpost_Effect(string pMasterTableName, int pEntryId)
		{


			string mysql = "update " + pMasterTableName;
			mysql = mysql + " set resume_processed_status = 1 ";
			mysql = mysql + ", last_month_earning_days = 0";
			mysql = mysql + " where entry_id =" + Conversion.Str(pEntryId);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = " update pay_employee ";
			mysql = mysql + " set status_cd = " + SystemHRProcedure.gStatusOnLeave.ToString();


			//'''''
			//'''modified on 18-sep-2006
			//'''this was done because payroll will be generated for both paynow and paywithpayroll
			//'''in case of paynow a deduction entry has to be done in order to make the payroll zero for an employee.
			//mySql = mySql & " , last_salary_date = case when leave_amount_payment_type_id= " & gPayNow
			//mySql = mySql & " then plt.expected_resume_date - 1 "
			//mySql = mySql & " else pemp.last_salary_date "
			//mySql = mySql & " end "
			mysql = mysql + " from pay_employee pemp ";
			mysql = mysql + " inner join pay_leave_transaction plt on pemp.emp_cd = plt.emp_cd ";
			mysql = mysql + " where entry_id = " + Conversion.Str(pEntryId);
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

			SystemHRProcedure.enumTAFields mFieldId = (SystemHRProcedure.enumTAFields) 0;

			mysql = " select pemp.emp_no,pemp.emp_cd, l.leave_type_cd, plvt.auto_resume  ";
			mysql = mysql + " from pay_leave_transaction plt";
			mysql = mysql + " inner join pay_leave l on l.leave_cd = plt.leave_cd ";
			mysql = mysql + " inner join pay_leave_type plvt on plvt.type_cd = l.leave_type_cd ";
			mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = plt.emp_cd ";
			mysql = mysql + " where plt.entry_id = " + Conversion.Str(pEntryId);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			string mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();
			//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			string mEmpNo = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
			//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));

			if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2)) == 11)
			{
				mFieldId = SystemHRProcedure.enumTAFields.eTASickHours;
				//ElseIf mReturnValue(2) = 7 Then
				//    mFieldId = eTAAbsentHours
			}
			else
			{
				mFieldId = SystemHRProcedure.enumTAFields.eTAVacationHours;
			}


			UpdateTimeAttendanceOnUnpost(mEmpCd, txtDisplayLabel[11].Text, txtDisplayLabel[10].Text, mFieldId, ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(3)));
			SystemHRProcedure.ClearPayroll(mGenerateDate, mEmpNo, mEmpNo);
			SystemHRProcedure.GeneratePayrollEntry(mGenerateDate, mEmpNo, mEmpNo);
			SystemHRProcedure.GenerateLeaveEntry(mGenerateDate, mEmpNo, mEmpNo);
			SystemHRProcedure.GenerateLoanEntry(mGenerateDate, mEmpNo, mEmpNo);

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_approvals")))
			{
				mysql = " update pay_leave_transaction ";
				mysql = mysql + " set Approval_Stage_Resume = 0";
				mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();
			}
		}

		// for post resume in time attendance
		private bool UpdateTimeAttendance(int pEmpCd, string pLeaveEndDate, string pActualResumedDate, SystemHRProcedure.enumTAFields pFieldType, bool pAutoResume)
		{
			int mEntryId = 0;
			string mysql = "";
			object mReturnValue = null;

			string mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();

			if (!pAutoResume)
			{
				mysql = "select is_pay_closed, Rate_Calc_Method_Id from pay_leave_transaction where entry_id =" + ReflectionHelper.GetPrimitiveValue<int>(mSearchValue).ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Generate_AttHrs_For_DailyWage")) && ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1)) == 130)
				{
					return false;
				}

				if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0)) == 0)
				{
					SystemHRProcedure.UpdateDeductionHoursForResume(pEmpCd, pLeaveEndDate, pActualResumedDate, pFieldType, pAutoResume);
				}

				if (DateTime.Parse(mGenerateDate) >= DateTime.Parse(pActualResumedDate))
				{
					if (DateTime.Parse(pActualResumedDate) >= DateTime.Parse(SystemHRProcedure.GetPayrollSalaryDate()))
					{
						mEntryId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						SystemHRProcedure.UpdateAttendanceFieldsHours(pActualResumedDate, mGenerateDate, mEntryId, SystemHRProcedure.GetEmpPerDayHours(pEmpCd));
						mEntryId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAReserveHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						SystemHRProcedure.UpdateAttendanceFieldsHours(pActualResumedDate, mGenerateDate, mEntryId, 0);
						switch(pFieldType)
						{
							case SystemHRProcedure.enumTAFields.eTAVacationHours : 
								mEntryId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAVacationHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month); 
								break;
							case SystemHRProcedure.enumTAFields.eTAAbsentHours : 
								mEntryId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAAbsentHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month); 
								break;
							case SystemHRProcedure.enumTAFields.eTASickHours : 
								mEntryId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTASickHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month); 
								break;
						}

						if (DateTime.Parse(pLeaveEndDate) < DateTime.Parse(pActualResumedDate))
						{
							SystemHRProcedure.UpdateAttendanceFieldsHours(pLeaveEndDate, DateTimeHelper.ToString(DateTime.Parse(pActualResumedDate).AddDays(-1)), mEntryId, SystemHRProcedure.GetEmpPerDayHours(pEmpCd));
							mEntryId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAReserveHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
							SystemHRProcedure.UpdateAttendanceFieldsHours(pLeaveEndDate, pActualResumedDate, mEntryId, 0);
						}
						else
						{
							SystemHRProcedure.UpdateAttendanceFieldsHours(pActualResumedDate, pLeaveEndDate, mEntryId, 0);
						}

					}
				}
			}
			SystemHRProcedure.UpdateDailyWagesEmployeeEarnInTA(pEmpCd, pEmpCd);
			return false;
		}

		// for Unpost resume in time attendance
		private bool UpdateTimeAttendanceOnUnpost(int pEmpCd, string pToDate, string pFromDate, SystemHRProcedure.enumTAFields pFieldType, bool pAutoResume)
		{
			int mEntryId = 0;
			int mWorkHrsEntId = 0;
			int mReserveEntId = 0;

			string mPerDayHrs = SystemHRProcedure.GetEmpPerDayHours(pEmpCd).ToString();
			string mStartDate = SystemHRProcedure.GetPayrollGenerateStartDate();
			string mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();

			//To Update Deuction Hours in TNA only if cut off is enabled
			string mysql = "select is_pay_closed, Rate_Calc_Method_Id  from pay_leave_transaction where entry_id =" + ReflectionHelper.GetPrimitiveValue<int>(mSearchValue).ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Generate_AttHrs_For_DailyWage")) && ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1)) == 130)
			{
				return false;
			}

			if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0)) == 0)
			{
				SystemHRProcedure.UpdateDeductionHoursForLeave(pEmpCd, pFromDate, pToDate, Double.Parse(mPerDayHrs), pFieldType, pAutoResume);
			}

			switch(pFieldType)
			{
				case SystemHRProcedure.enumTAFields.eTAVacationHours : 
					if (DateTime.Parse(mGenerateDate) >= DateTime.Parse(pFromDate))
					{
						//If Leave date is coming in this month then update work hours from start date to payroll generate date
						mWorkHrsEntId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						mEntryId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAVacationHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						SystemHRProcedure.PostLeaveInTimeAttendance(mWorkHrsEntId, mEntryId, Double.Parse(mPerDayHrs), pToDate, pFromDate);
					} 
					break;
				case SystemHRProcedure.enumTAFields.eTASickHours : 
					if (DateTime.Parse(mGenerateDate) >= DateTime.Parse(pFromDate))
					{
						//If Leave date is coming in this month then update work hours from start date to payroll generate date
						mWorkHrsEntId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						mEntryId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTASickHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						SystemHRProcedure.PostLeaveInTimeAttendance(mWorkHrsEntId, mEntryId, Double.Parse(mPerDayHrs), pToDate, pFromDate);
					} 
					break;
				case SystemHRProcedure.enumTAFields.eTAAbsentHours : 
					if (DateTime.Parse(mGenerateDate) >= DateTime.Parse(pFromDate))
					{
						//If Leave date is coming in this month then update work hours from start date to payroll generate date
						mWorkHrsEntId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						mEntryId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAAbsentHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						SystemHRProcedure.PostLeaveInTimeAttendance(mWorkHrsEntId, mEntryId, Double.Parse(mPerDayHrs), pToDate, pFromDate);
					} 
					break;
			}
			//' Updated reserve hrs if auto resumed is false
			if (!pAutoResume)
			{
				mReserveEntId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAReserveHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
				mWorkHrsEntId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
				SystemHRProcedure.PostReserveHrsInTimeAttendance(mReserveEntId, mWorkHrsEntId, pToDate, Double.Parse(mPerDayHrs));
			}
			//' End
			SystemHRProcedure.UpdateDailyWagesEmployeeEarnInTA(pEmpCd, pEmpCd);
			return false;
		}

		private void txtAdjustPaidDays_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Conversion.Val(txtDisplayVariationDays.Text) < 0)
			{
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				txtEncashmentDays.Value = (Convert.ToDouble(ReflectionHelper.GetPrimitiveValue<double>(txtAdjustPaidDays.Value) + ReflectionHelper.GetPrimitiveValue<double>(txtAdjustUnpaidDays.Value))) - Conversion.Val(txtDisplayVariationDays.Text);
				txtGrantDays.Value = 0;
			}
			else
			{
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				txtAdjustUnpaidDays.Value = (Conversion.Val(txtDisplayVariationDays.Text) - (Convert.ToDouble(ReflectionHelper.GetPrimitiveValue<double>(txtAdjustPaidDays.Value) + ReflectionHelper.GetPrimitiveValue<double>(txtGrantDays.Value))));
				//txtGrantDays.Value = 0
				txtEncashmentDays.Value = 0;
			}
			LeaveAmount();
		}

		private void txtAdjustUnpaidDays_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Conversion.Val(txtDisplayVariationDays.Text) < 0)
			{
				if (Math.Abs(Conversion.Val(txtDisplayVariationDays.Text)) != Math.Abs(ReflectionHelper.GetPrimitiveValue<double>(txtAdjustUnpaidDays.Value)))
				{
					txtAdjustPaidDays.Value = (Math.Abs(Conversion.Val(txtDisplayVariationDays.Text)) - (Math.Abs(ReflectionHelper.GetPrimitiveValue<double>(txtAdjustUnpaidDays.Value)) + ReflectionHelper.GetPrimitiveValue<double>(txtEncashmentDays.Value))) * -1;
					txtGrantDays.Value = 0;
				}
				else
				{
					txtAdjustPaidDays.Value = 0;
					txtEncashmentDays.Value = 0;
					txtGrantDays.Value = 0;
				}
			}
			else
			{
				txtAdjustPaidDays.Value = 0;
				txtEncashmentDays.Value = 0;
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				txtGrantDays.Value = (Conversion.Val(txtDisplayVariationDays.Text) - (Convert.ToDouble(ReflectionHelper.GetPrimitiveValue<double>(txtAdjustPaidDays.Value) + ReflectionHelper.GetPrimitiveValue<double>(txtAdjustUnpaidDays.Value))));
			}
			LeaveAmount();
		}

		//added by burhan. Date:12-Jun-2008
		private void txtCommonDate_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonDate, eventSender);
			string mSQL = "";
			object mReturnValue = null;
			double mDifference = 0;

			if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
			{
				return;
			}
			txtDisplayVariationDays.Text = "0";
			txtAdjustPaidDays.Value = 0;
			txtAdjustUnpaidDays.Value = 0;
			txtLeaveBalOnResume.Text = "";
			txtEncashmentDays.Value = 0;
			txtGrantDays.Value = 0;
			txtSalaryAdjusted.Text = "0.000";
			if (Index == conDTxtActualResumeDate)
			{
				mSQL = " select Weekend_Day1_Id,Weekend_Day2_Id from pay_employee where emp_cd = (select emp_cd from pay_leave_transaction where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ")";
				if (mIncludeInDefaultLeave)
				{ //Checking Include Weekend or not
					mDifference = ReflectionHelper.GetPrimitiveValue<double>(txtCommonDate[conDTxtActualResumeDate].Value) - ReflectionHelper.GetPrimitiveValue<double>(txtCommonDate[conDTxtResumeDate].Value);
				}
				else
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					if (ReflectionHelper.IsLessThan(txtCommonDate[conDTxtActualResumeDate].Value, txtCommonDate[conDTxtResumeDate].Value))
					{
						mDifference = (SystemHRProcedure.CalculateDays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtActualResumeDate].Value), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtResumeDate].Value), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1))) - 1) * -1;
					}
					else
					{
						mDifference = SystemHRProcedure.CalculateDays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtResumeDate].Value), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtActualResumeDate].Value), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1))) - 1;
					}
				}
				if (mDifference != 0)
				{
					txtDisplayVariationDays.Text = mDifference.ToString();
					if (ReflectionHelper.IsGreaterThan(txtCommonDate[conDTxtActualResumeDate].Value, txtCommonDate[conDTxtResumeDate].Value))
					{ // if an employee resumes late
						if (!SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
						{
							mSQL = " select emp_cd, leave_cd from pay_leave_transaction where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								txtLeaveBalOnResume.Value = SystemHRProcedure.Leave_Balance_Days(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)), DateTime.Parse(txtCommonDate[conNTxtActualLeaveDays].Text).AddDays(1));
							}
						}
						txtAdjustUnpaidDays.Value = mDifference; //By Default all late days goes to unpaydays
					}
					else
					{
						if (Conversion.Val(txtCommonNumber[conNTxtUnPaidDays].Text) > 0)
						{
							if (Conversion.Val(txtCommonNumber[conNTxtUnPaidDays].Text) > Math.Abs(mDifference))
							{
								txtAdjustUnpaidDays.Value = mDifference;
								txtAdjustPaidDays.Value = 0;
								txtSalaryAdjusted.Value = 0;
							}
							else
							{
								txtAdjustUnpaidDays.Value = Conversion.Val(txtCommonNumber[conNTxtUnPaidDays].Text) * -1;
								txtAdjustPaidDays.Value = (Math.Abs(mDifference) - Conversion.Val(txtCommonNumber[conNTxtUnPaidDays].Text)) * -1;
								LeaveAmount();
							}
						}
					}
					//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
					txtEncashmentDays.Value = (Convert.ToDouble(ReflectionHelper.GetPrimitiveValue<double>(txtAdjustPaidDays.Value) + ReflectionHelper.GetPrimitiveValue<double>(txtAdjustUnpaidDays.Value))) - Conversion.Val(txtDisplayVariationDays.Text);
				}
			}
		}

		private void LeaveAmount()
		{
			int mEmpCode = 0;
			int mLeaveCode = 0;
			object mReturnValue = null;
			string mysql = "";

			if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
			{
				return;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Employee Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else
			{
				mysql = " select emp_cd from pay_employee where emp_no='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Employee Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonTextBox[conTxtEmpCode].Focus();
					return;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEmpCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtLeaveCode].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Leave Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtLeaveCode].Focus();
				return;
			}
			else
			{
				mysql = " select leave_cd from pay_leave where leave_no='" + txtCommonTextBox[conTxtLeaveCode].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Leave Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLeaveCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
			}

			if (Information.IsDate(txtDisplayLabel[conDlblLeaveFromDate].Text))
			{
				if (ReflectionHelper.GetPrimitiveValue<double>(txtAdjustPaidDays.Value) > 0)
				{
					mysql = " select dbo.payLeaveAmount(" + mEmpCode.ToString() + "," + mLeaveCode.ToString() + "," + ReflectionHelper.GetPrimitiveValue<string>(txtAdjustPaidDays.Value) + ",'" + txtDisplayLabel[conDlblLeaveFromDate].Text + "')";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtSalaryAdjusted.Value = ReflectionHelper.GetPrimitiveValue(mReturnValue);
					}
					else
					{
						txtSalaryAdjusted.Value = 0;
					}
				}
				else if (ReflectionHelper.GetPrimitiveValue<double>(txtAdjustPaidDays.Value) < 0)
				{ 
					txtSalaryAdjusted.Value = mLeaveAmountPerDay * ReflectionHelper.GetPrimitiveValue<double>(txtAdjustPaidDays.Value);
				}
				else
				{
					txtSalaryAdjusted.Value = 0;
				}
			}
			else
			{
				txtSalaryAdjusted.Value = 0;
			}

		}

		private void txtEncashmentDays_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Conversion.Val(txtDisplayVariationDays.Text) < 0)
			{
				txtAdjustPaidDays.Value = (Math.Abs(Conversion.Val(txtDisplayVariationDays.Text)) - (ReflectionHelper.GetPrimitiveValue<double>(txtEncashmentDays.Value) + Math.Abs(ReflectionHelper.GetPrimitiveValue<double>(txtAdjustUnpaidDays.Value)))) * -1;
				txtGrantDays.Value = 0;
			}
			else
			{
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				txtAdjustUnpaidDays.Value = (Conversion.Val(txtDisplayVariationDays.Text) - (Convert.ToDouble(ReflectionHelper.GetPrimitiveValue<double>(txtAdjustPaidDays.Value) + ReflectionHelper.GetPrimitiveValue<double>(txtGrantDays.Value))));
				txtEncashmentDays.Value = 0;
			}
			LeaveAmount();
		}

		private void txtGrantDays_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Conversion.Val(txtDisplayVariationDays.Text) > 0)
			{
				txtAdjustUnpaidDays.Value = (Conversion.Val(txtDisplayVariationDays.Text) - ReflectionHelper.GetPrimitiveValue<double>(txtGrantDays.Value));
				txtAdjustPaidDays.Value = 0;
				txtEncashmentDays.Value = 0;
			}
			else
			{
				txtCommonDate_Leave(txtCommonDate[conDTxtActualResumeDate], new EventArgs());
			}
			LeaveAmount();
		}
	}
}