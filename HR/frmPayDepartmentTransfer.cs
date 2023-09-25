
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayDepartmentTransfer
		: System.Windows.Forms.Form
	{

		
		public frmPayDepartmentTransfer()
{
InitializeComponent();
} 
 public  void frmPayDepartmentTransfer_old()
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

		private const int conTxtVoucherNo = 0;
		private const int conTxtEmpCode = 1;
		private const int conTxtReferenceNo = 2;
		private const int conTxtNewDeptCode = 3;
		private const int conTxtNewDesgCode = 4;
		private const int conTxtComments = 5;

		private const int conDlblDeptCode = 0;
		private const int conDlblDeptName = 1;
		private const int conDlblNewDeptName = 2;
		private const int conDlblDesgCode = 3;
		private const int conDlblDesgName = 4;
		private const int conDlblNewDesgName = 5;
		private const int conDlblBasicSalary = 6;
		private const int conDlblEmpName = 7;


		private string mTimeStamp = "";
		private int mThisFormID = 0;
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


		private void btnFormToolBar_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.btnFormToolBar, eventSender);
			SystemForms.ToolBarButtonClick(this, Convert.ToString(btnFormToolBar[Index].Tag));
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			object frmMain = null;

			FirstFocusObject = txtCommonTextBox[conTxtVoucherNo];

			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;

				//Assign the Image for the toolbar
				//Imagelist are kept on the main form and refered by their key
				SystemProcedure2.DrawToolbar(this, picFormToolbar, btnFormToolBar[0]);
				btnFormToolBar[0].Picture = ReflectionHelper.GetMember<Image>(ReflectionHelper.Invoke(ReflectionHelper.GetMember(frmMain, "imlMainToolBar"), "ListImages", new object[]{"imgNew"}), "Picture");
				btnFormToolBar[1].Picture = ReflectionHelper.GetMember<Image>(ReflectionHelper.Invoke(ReflectionHelper.GetMember(frmMain, "imlMainToolBar"), "ListImages", new object[]{"imgSave"}), "Picture");
				btnFormToolBar[2].Picture = ReflectionHelper.GetMember<Image>(ReflectionHelper.Invoke(ReflectionHelper.GetMember(frmMain, "imlMainToolBar"), "ListImages", new object[]{"imgDelete"}), "Picture");
				btnFormToolBar[3].Picture = ReflectionHelper.GetMember<Image>(ReflectionHelper.Invoke(ReflectionHelper.GetMember(frmMain, "imlMainToolBar"), "ListImages", new object[]{"imgPrint"}), "Picture");
				btnFormToolBar[4].Picture = ReflectionHelper.GetMember<Image>(ReflectionHelper.Invoke(ReflectionHelper.GetMember(frmMain, "imlMainToolBar"), "ListImages", new object[]{"imgFind"}), "Picture");
				btnFormToolBar[5].Picture = ReflectionHelper.GetMember<Image>(ReflectionHelper.Invoke(ReflectionHelper.GetMember(frmMain, "imlMainToolBar"), "ListImages", new object[]{"imgHelp"}), "Picture");
				btnFormToolBar[6].Picture = ReflectionHelper.GetMember<Image>(ReflectionHelper.Invoke(ReflectionHelper.GetMember(frmMain, "imlMainToolBar"), "ListImages", new object[]{"imgExit"}), "Picture");

				//assign a next code
				txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("Pay_Department_Transfer", "voucher_no");

				txtVoucherDate.Value = DateTime.Today;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}



		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				object frmMain = null;
				ReflectionHelper.LetMember(frmMain, "Caption", SystemConstants.gAppName + " - " + this.Text);
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
			object txtStartDeductionDate = null;
			//Add a record
			SystemProcedure2.ClearTextBox(this);
			txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("Pay_Department_Transfer", "voucher_no");

			txtVoucherDate.Value = DateTime.Today;
			ReflectionHelper.LetMember(txtStartDeductionDate, "Value", DateTime.Today);


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
			string gUserCd = "";
			object txtLoanAmount = null;
			object txtLoanInstallmentAmount = null;
			object txtStartDeductionDate = null;
			object mReturnValue = null;
			int mEmpCode = 0;
			int mDeptCode = 0;
			int mNewDeptCode = 0;
			int mDesgCode = 0;
			int mNewDesgCode = 0;

			//Save a record
			//During save check for the mode
			//If in addmode then insert a record
			//else update the record in the recordset

			string mysql = "";
			try
			{

				mysql = "select pemp.emp_cd , pemp.dept_cd, pemp.desg_cd ";
				mysql = mysql + " from pay_employee pemp , pay_department pdept, pay_designation pdesg ";
				mysql = mysql + " where ";
				mysql = mysql + " pemp.dept_cd = pdept.dept_cd and pemp.desg_cd = pdesg.desg_cd ";
				mysql = mysql + " and pemp.emp_no = " + txtCommonTextBox[conTxtEmpCode].Text;

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Employee Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtCommonTextBox[conTxtEmpCode].Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEmpCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDeptCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDesgCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2));
				}

				//Get the New Dept Code
				mysql = "select dept_cd from pay_department ";
				mysql = mysql + " where ";
				mysql = mysql + " dept_no = " + txtCommonTextBox[conTxtNewDeptCode].Text;

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Department Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtCommonTextBox[conTxtNewDeptCode].Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mNewDeptCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				//Get the New Desg Code
				mysql = "select desg_cd from pay_designation ";
				mysql = mysql + " where ";
				mysql = mysql + " desg_no = " + txtCommonTextBox[conTxtNewDesgCode].Text;

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Designation Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtCommonTextBox[conTxtNewDesgCode].Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mNewDesgCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}




				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into pay_department_transfer ";
					mysql = mysql + " (emp_cd, current_dept_cd, current_desg_cd, new_dept_cd, new_desg_cd";
					mysql = mysql + " , voucher_no, voucher_date, reference_no, current_basic_salary";
					mysql = mysql + " , new_basic_salary, comments, user_cd) ";
					mysql = mysql + " values ( ";
					mysql = mysql + mEmpCode.ToString();
					mysql = mysql + " , " + mDeptCode.ToString();
					mysql = mysql + " , " + mDesgCode.ToString();
					mysql = mysql + " , " + mNewDeptCode.ToString();
					mysql = mysql + " , " + mNewDesgCode.ToString();
					mysql = mysql + " , " + txtCommonTextBox[conTxtVoucherNo].Text;
					mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText) + "'";
					mysql = mysql + " , '" + txtCommonTextBox[conTxtReferenceNo].Text + "'";
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblBasicSalary].Text, "###########.000");
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtNewBasicSalary.Value);
					mysql = mysql + " , '" + txtCommonTextBox[conTxtComments].Text + "'";
					mysql = mysql + " , " + gUserCd;
					mysql = mysql + " ) ";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					mysql = " select time_stamp from Pay_Department_Transfer where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollbackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						FirstFocusObject.Focus();
						return result;
					}

					if (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp))
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollbackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						FirstFocusObject.Focus();
						return result;
					}

					mysql = " update Pay_Department_Transfer set ";
					mysql = mysql + " emp_cd =" + mEmpCode.ToString();
					mysql = mysql + " , dept_cd =" + mDeptCode.ToString();
					mysql = mysql + " , desg_cd =" + mDesgCode.ToString();
					mysql = mysql + " , voucher_no =" + txtCommonTextBox[conTxtVoucherNo].Text;
					mysql = mysql + " , voucher_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText) + "'";
					mysql = mysql + " , reference_no ='" + txtCommonTextBox[conTxtReferenceNo].Text + "'";
					mysql = mysql + " , basic_salary =" + txtDisplayLabel[conDlblBasicSalary].Text;
					mysql = mysql + " , loan_amount =" + ReflectionHelper.GetMember<string>(txtLoanAmount, "Value");
					mysql = mysql + " , loan_installment_amount =" + ReflectionHelper.GetMember<string>(txtLoanInstallmentAmount, "Value");
					mysql = mysql + " , start_deduction_date ='" + ReflectionHelper.GetMember<string>(txtStartDeductionDate, "DisplayText") + "'";
					mysql = mysql + " , comments ='" + txtCommonTextBox[conTxtComments].Text + "'";
					mysql = mysql + " , user_cd =" + Conversion.Str(gUserCd);
					mysql = mysql + " where entry_id=" + Conversion.Str(mSearchValue);
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
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollbackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}
			return result;
		}

		public bool deleteRecord()
		{

			//If an error occurs, trap the error and dispaly a valid message
			SystemVariables.gConn.BeginTransaction();
			string mysql = "delete from Pay_Department_Transfer  where entry_id=" + Conversion.Str(mSearchValue);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

			return true;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			if (mReturnErrorType == 1)
			{
				return false;
			}
			else if (mReturnErrorType == 2)
			{ 
				AddRecord();
				return false;
			}
			else
			{
				return false;
			}
		}

		public void GetRecord(object SearchValue)
		{
			int conDlblLastCashPaymentDate = 0;
			int conDlblLastDeductionDate = 0;
			int conDlblTotalBalance = 0;
			int conDlblTotalCashPaid = 0;
			int conDlblTotalSalaryDeduction = 0;
			object mTempValue = null;
			object txtLoanAmount = null;
			object txtLoanInstallmentAmount = null;
			object txtStartDeductionDate = null;
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			//On Error GoTo eFoundError

			string mysql = " select * from Pay_Department_Transfer where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

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
				txtCommonTextBox[conTxtVoucherNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["voucher_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtVoucherDate.Value = localRec.Tables[0].Rows[0]["voucher_date"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtReferenceNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["reference_no"]) + "";

				mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "isnull(l_first_name,'') + ' ' + isnull(l_second_name,'') + ' ' + isnull(l_third_name,'') + ' ' + isnull(l_fourth_name,'')" : "isnull(a_first_name,'') + ' ' + isnull(a_second_name,'') + ' ' + isnull(a_third_name,'') + ' ' + isnull(a_fourth_name,'')");
				mysql = mysql + " , dept_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
				mysql = mysql + " , desg_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
				mysql = mysql + " , emp_no ";
				mysql = mysql + " , pemp.basic_salary ";
				mysql = mysql + " from pay_employee pemp , pay_department pdept, pay_designation pdesg ";
				mysql = mysql + " where ";
				mysql = mysql + " pemp.dept_cd = pdept.dept_cd and pemp.desg_cd = pdesg.desg_cd ";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " and pemp.emp_cd = " + Convert.ToString(localRec.Tables[0].Rows[0]["emp_cd"]);

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonTextBox[conTxtEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(5));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDeptCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDesgCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));
				txtDisplayLabel[conDlblBasicSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(6)), "###,###,##0.000");

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				ReflectionHelper.LetMember(txtLoanAmount, "Value", localRec.Tables[0].Rows[0]["loan_amount"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				ReflectionHelper.LetMember(txtStartDeductionDate, "Value", localRec.Tables[0].Rows[0]["start_deduction_date"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				ReflectionHelper.LetMember(txtLoanInstallmentAmount, "Value", localRec.Tables[0].Rows[0]["loan_installment_amount"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtComments].Text = Convert.ToString(localRec.Tables[0].Rows[0]["comments"]) + "";

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblTotalCashPaid].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["total_cash_paid"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblTotalSalaryDeduction].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["total_salary_deduction"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblTotalBalance].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["total_balance"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				System.DateTime TempDate = DateTime.FromOADate(0);
				txtDisplayLabel[conDlblLastCashPaymentDate].Text = (DateTime.TryParse(Convert.ToString(localRec.Tables[0].Rows[0]["last_cash_payment_date"]) + "", out TempDate)) ? TempDate.ToString("dd-MMM-yyyy") : Convert.ToString(localRec.Tables[0].Rows[0]["last_cash_payment_date"]) + "";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				System.DateTime TempDate2 = DateTime.FromOADate(0);
				txtDisplayLabel[conDlblLastDeductionDate].Text = (DateTime.TryParse(Convert.ToString(localRec.Tables[0].Rows[0]["last_deduction_date"]) + "", out TempDate2)) ? TempDate2.ToString("dd-MMM-yyyy") : Convert.ToString(localRec.Tables[0].Rows[0]["last_deduction_date"]) + "";

				//Change the form mode to edit
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			}
			localRec = null;

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void PrintReport()
		{

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7020000));
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
			if (!Information.IsNumeric(txtCommonTextBox[conTxtVoucherNo].Text))
			{
				MessageBox.Show("Enter the Loan No.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtVoucherNo].Focus();
				return false;
			}

			if (!Information.IsDate(txtVoucherDate.DisplayText))
			{
				MessageBox.Show("Enter valid date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtVoucherDate.Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Employee Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtEmpCode].Focus();
				return false;
			}

			if (!Information.IsNumeric(txtCommonTextBox[conTxtNewDeptCode].Text))
			{
				MessageBox.Show("Enter the Department No.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtNewDeptCode].Focus();
				return false;
			}

			if (!Information.IsNumeric(txtCommonTextBox[conTxtNewDesgCode].Text))
			{
				MessageBox.Show("Enter the Designation No.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtNewDesgCode].Focus();
				return false;
			}

			if (!Information.IsNumeric(txtNewBasicSalary.Value))
			{
				MessageBox.Show("Enter New Basic Salary ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtNewBasicSalary.Focus();
				return false;
			}

			return true;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			UserAccess = null;
			frmPayDepartmentTransfer.DefInstance = null;
		}

		public void GetNextNumber()
		{
			txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("Pay_Department_Transfer", "voucher_no");
			FirstFocusObject.Focus();
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			GetNextNumber();
		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (Index == conTxtEmpCode)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "isnull(l_first_name,'') + ' ' + isnull(l_second_name,'') + ' ' + isnull(l_third_name,'') + ' ' + isnull(l_fourth_name,'')" : "isnull(a_first_name,'') + ' ' + isnull(a_second_name,'') + ' ' + isnull(a_third_name,'') + ' ' + isnull(a_fourth_name,'')");
						mysql = mysql + " , dept_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
						mysql = mysql + " , desg_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
						mysql = mysql + " , emp_cd ";
						mysql = mysql + " , pemp.basic_salary ";
						mysql = mysql + " from pay_employee pemp , pay_department pdept, pay_designation pdesg ";
						mysql = mysql + " where ";
						mysql = mysql + " pemp.dept_cd = pdept.dept_cd and pemp.desg_cd = pdesg.desg_cd ";
						mysql = mysql + " and pemp.emp_no = " + txtCommonTextBox[conTxtEmpCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblEmpName].Text = "";
							txtDisplayLabel[conDlblDeptCode].Text = "";
							txtDisplayLabel[conDlblDeptName].Text = "";
							txtDisplayLabel[conDlblDesgCode].Text = "";
							txtDisplayLabel[conDlblDesgName].Text = "";
							txtDisplayLabel[conDlblBasicSalary].Text = "";

							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDeptCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDesgCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));
							txtDisplayLabel[conDlblBasicSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(6)), "###,###,##0.000");
						}
					}
					else
					{
						txtDisplayLabel[conDlblEmpName].Text = "";
						txtDisplayLabel[conDlblDeptCode].Text = "";
						txtDisplayLabel[conDlblDeptName].Text = "";
						txtDisplayLabel[conDlblDesgCode].Text = "";
						txtDisplayLabel[conDlblDesgName].Text = "";
						txtDisplayLabel[conDlblBasicSalary].Text = "";
					}
				}
				else if (Index == conTxtNewDeptCode)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtNewDeptCode].Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select dept_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
						mysql = mysql + " from pay_department pdept ";
						mysql = mysql + " where ";
						mysql = mysql + " pdept.dept_no = " + txtCommonTextBox[conTxtNewDeptCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblNewDeptName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblNewDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						}
					}
					else
					{
						txtDisplayLabel[conDlblNewDeptName].Text = "";
					}
				}
				else if (Index == conTxtNewDesgCode)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtNewDesgCode].Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select desg_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
						mysql = mysql + " from pay_designation ";
						mysql = mysql + " where ";
						mysql = mysql + " desg_no = " + txtCommonTextBox[conTxtNewDesgCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblNewDesgName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblNewDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						}
					}
					else
					{
						txtDisplayLabel[conDlblNewDesgName].Text = "";
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
					txtCommonTextBox[Index].Focus();
				}
				else
				{
					//
				}
			}

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
					case conTxtNewDeptCode : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7001000, "727")); 
						break;
					case conTxtNewDesgCode : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7002000, "734")); 
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
					txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
				}
			}
		}
	}
}