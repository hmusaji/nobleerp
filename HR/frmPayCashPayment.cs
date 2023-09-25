
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayCashPayment
		: System.Windows.Forms.Form
	{

		public frmPayCashPayment()
{
InitializeComponent();
} 
 public  void frmPayCashPayment_old()
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


		private void frmPayCashPayment_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
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

		public Control FirstFocusObject = null;

		private const int conTxtVocherNo = 0;
		private const int conTxtLoanNo = 1;
		private const int conTXTReferenceNo = 2;
		private const int conTxtComments = 3;

		private const int conDlblLoanDate = 0;
		private const int conDlblEmpCode = 1;
		private const int conDlblEmpName = 2;
		private const int conDlblLoanAmount = 3;
		private const int conDlblLoanBalance = 4;

		private clsToolbar oThisFormToolBar = null;
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


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			FirstFocusObject = txtCommonTextBox[conTxtLoanNo];

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
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;
				//
				//
				//'Assign the Image for the toolbar
				//'Imagelist are kept on the main form and refered by their key
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture

				SystemProcedure.SetLabelCaption(this);

				//assign a next code
				txtCommonTextBox[conTxtVocherNo].Text = SystemProcedure2.GetNewNumber("Pay_Loan_Cash_Payment", "voucher_no");
				txtVoucherDate.Value = DateTime.Today;
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
			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearNumberBox(this);

			txtCommonTextBox[conTxtVocherNo].Text = SystemProcedure2.GetNewNumber("pay_loan_cash_payment", "voucher_no");

			txtVoucherDate.Value = DateTime.Today;

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
			object mReturnValue = null;
			int mLoanEntryId = 0;
			decimal mLoanBalance = 0;
			decimal mOldVoucherAmt = 0;
			int mOldLoanEntryId = 0;
			//Save a record
			//During save check for the mode
			//If in addmode then insert a record
			//else update the record in the recordset

			string mysql = "";
			try
			{

				if (ReflectionHelper.GetPrimitiveValue<double>(txtCashAmount.Value) <= 0)
				{
					MessageBox.Show("Amount should be greater than zero ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtCashAmount.Focus();
					return result;
				}

				SystemVariables.gConn.BeginTransaction();

				mysql = " select entry_id , total_balance from pay_loan ";
				mysql = mysql + " where voucher_no = " + txtCommonTextBox[conTxtLoanNo].Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Loan No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonTextBox[conTxtLoanNo].Focus();
					goto eExit;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLoanEntryId = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLoanBalance = ReflectionHelper.GetPrimitiveValue<decimal>(((Array) mReturnValue).GetValue(1));
				}

				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{

					if (ReflectionHelper.GetPrimitiveValue<decimal>(txtCashAmount.Value) > mLoanBalance)
					{
						MessageBox.Show("Cash amount cannot be greater than total balance", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCashAmount.Focus();
						goto eExit;
					}

					mysql = " insert into pay_loan_cash_payment ";
					mysql = mysql + " (loan_entry_id, voucher_no, voucher_date, voucher_amt";
					mysql = mysql + " , reference_no, comments, user_cd) ";
					mysql = mysql + " values(";
					mysql = mysql + mLoanEntryId.ToString();
					mysql = mysql + " , " + txtCommonTextBox[conTxtVocherNo].Text;
					mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText) + "'";
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCashAmount.Value);
					mysql = mysql + " , '" + txtCommonTextBox[conTXTReferenceNo].Text + "'";
					mysql = mysql + " , '" + txtCommonTextBox[conTxtComments].Text + "'";
					mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " ) ";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					mysql = " select time_stamp, voucher_amt , loan_entry_id from pay_loan_cash_payment where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mOldVoucherAmt = ReflectionHelper.GetPrimitiveValue<decimal>(((Array) mReturnValue).GetValue(1));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mOldLoanEntryId = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2));
					}
					else
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						FirstFocusObject.Focus();
						goto eExit;
					}

					if (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp))
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						FirstFocusObject.Focus();
						goto eExit;
					}

					//Check for the cash amount should be less than loan amount
					//During update check if the loan no is also changed.
					if (mLoanEntryId == mOldLoanEntryId)
					{
						if (ReflectionHelper.GetPrimitiveValue<decimal>(txtCashAmount.Value) > (mLoanBalance + mOldVoucherAmt))
						{
							MessageBox.Show("Cash amount cannot be greater than total balance", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtCashAmount.Focus();
							goto eExit;
						}
					}
					else
					{
						if (ReflectionHelper.GetPrimitiveValue<decimal>(txtCashAmount.Value) > mLoanBalance)
						{
							MessageBox.Show("Cash amount cannot be greater than total balance", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtCashAmount.Focus();
							goto eExit;
						}
					}

					mysql = " update pay_loan_cash_payment set ";
					mysql = mysql + " loan_entry_id =" + mLoanEntryId.ToString();
					mysql = mysql + " , voucher_no =" + txtCommonTextBox[conTxtVocherNo].Text;
					mysql = mysql + " , voucher_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText) + "'";
					mysql = mysql + " , voucher_amt =" + ReflectionHelper.GetPrimitiveValue<string>(txtCashAmount.Value);
					mysql = mysql + " , reference_no ='" + txtCommonTextBox[conTXTReferenceNo].Text + "'";
					mysql = mysql + " , comments ='" + txtCommonTextBox[conTxtComments].Text + "'";
					mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where entry_id=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}

				//update the pay_loan table
				mysql = " update pay_loan set ";
				mysql = mysql + " total_cash_paid = isnull((select sum(plcp.voucher_amt) ";
				mysql = mysql + " from pay_loan_cash_payment plcp where ";
				mysql = mysql + " plcp.loan_entry_id = pay_loan.entry_id),0) ";
				mysql = mysql + " , last_cash_payment_date = (select max(voucher_date) ";
				mysql = mysql + " from pay_loan_cash_payment plcp ";
				mysql = mysql + " where plcp.loan_entry_id = pay_loan.entry_id) ";
				mysql = mysql + " where entry_id = " + mLoanEntryId.ToString();
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				string mGenerateDate = "";
				mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();
				SystemHRProcedure.ClearPayroll(mGenerateDate, txtDisplayLabel[conDlblEmpCode].Text, txtDisplayLabel[conDlblEmpCode].Text);
				SystemHRProcedure.GeneratePayrollEntry(mGenerateDate, txtDisplayLabel[conDlblEmpCode].Text, txtDisplayLabel[conDlblEmpCode].Text);
				SystemHRProcedure.GenerateLeaveEntry(mGenerateDate, txtDisplayLabel[conDlblEmpCode].Text, txtDisplayLabel[conDlblEmpCode].Text);
				SystemHRProcedure.GenerateLoanEntry(mGenerateDate, txtDisplayLabel[conDlblEmpCode].Text, txtDisplayLabel[conDlblEmpCode].Text);

				result = true;
				FirstFocusObject.Focus();
				return result;

				eExit:
				result = false;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
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

			//If an error occurs, trap the error and dispaly a valid message
			SystemVariables.gConn.BeginTransaction();

			//'' Added By Burhan Ghee Wala
			//'' Date: 23-Jul-2007
			//'' Desc: when cash transaction deleted, Loan Master entry's cash_paid field should be updated

			string mysql = "select loan_entry_id, voucher_amt from pay_loan_cash_payment where entry_id =" + Conversion.Str(mSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mLoanEntryId = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(0));
			//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mCashPaid = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));

			mysql = "update pay_loan set total_cash_paid =total_cash_paid - " + ReflectionHelper.GetPrimitiveValue<string>(mCashPaid);
			mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mLoanEntryId);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();
			//End

			mysql = "delete from pay_loan_cash_payment where entry_id=" + Conversion.Str(mSearchValue);
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();
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
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			//On Error GoTo eFoundError
			object mReturnValue = null;

			string mysql = " select * from pay_loan_cash_payment where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

			SqlDataReader localRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand.ExecuteReader();
			if (localRec.Read())
			{
				//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(SearchValue);
				mTimeStamp = Convert.ToString(localRec["time_stamp"]);

				txtCommonTextBox[conTxtVocherNo].Text = Convert.ToString(localRec["voucher_no"]);
				txtVoucherDate.Value = localRec["voucher_date"];
				txtCashAmount.Value = localRec["voucher_amt"];
				txtCommonTextBox[conTXTReferenceNo].Text = Convert.ToString(localRec["reference_no"]) + "";
				txtCommonTextBox[conTxtComments].Text = Convert.ToString(localRec["comments"]) + "";

				mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name" : "a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name");
				mysql = mysql + " , emp_no ";
				mysql = mysql + " , voucher_date ";
				mysql = mysql + " , loan_amount ";
				mysql = mysql + " , total_balance ";
				mysql = mysql + " , ploan.voucher_no ";
				mysql = mysql + " from pay_employee pemp , pay_loan ploan ";
				mysql = mysql + " where ";
				mysql = mysql + " pemp.emp_cd = ploan.emp_cd ";
				mysql = mysql + " and ploan.entry_id = " + Convert.ToString(localRec["loan_entry_id"]);

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[conTxtLoanNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(5));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDisplayLabel[conDlblEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					txtDisplayLabel[conDlblLoanDate].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(2)), SystemVariables.gSystemDateFormat);
					txtDisplayLabel[conDlblLoanAmount].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(3)), "###,###,###.000");
					txtDisplayLabel[conDlblLoanBalance].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(4)), "###,###,###.000");
				}

				//Change the form mode to edit
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			}
			localRec.Close();

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
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7006000));
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

			if (!Information.IsNumeric(txtCommonTextBox[conTxtVocherNo].Text))
			{
				MessageBox.Show("Enter Cash No.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtVocherNo].Focus();
				return false;
			}

			if (!Information.IsDate(txtVoucherDate.Value))
			{
				MessageBox.Show("Enter Cash Payment Date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtVoucherDate.Focus();
				return false;
			}

			if (!Information.IsNumeric(txtCommonTextBox[conTxtLoanNo].Text))
			{
				MessageBox.Show("Enter Loan No.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtLoanNo].Focus();
				return false;
			}

			if (!Information.IsNumeric(txtCashAmount.Value))
			{
				MessageBox.Show("Enter Cash Amount", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCashAmount.Focus();
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
				frmPayCashPayment.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtParentDeptNo_DropButtonClick()
		{
			FindRoutine("txtParentDeptNo");
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

			switch(mIndex)
			{
				case conTxtLoanNo : 
					txtCommonTextBox[conTxtLoanNo].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7005000, "747")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtLoanNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				default:
					return;
			}

		}

		public void GetNextNumber()
		{
			txtCommonTextBox[conTxtVocherNo].Text = SystemProcedure2.GetNewNumber("Pay_Loan_Cash_Payment", "voucher_no");
			FirstFocusObject.Focus();
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			if (Index == conTxtVocherNo)
			{
				GetNextNumber();
			}
			else if (Index == conTxtLoanNo)
			{ 
				FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
			}

		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (Index == conTxtLoanNo)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtLoanNo].Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name" : "a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name");
						mysql = mysql + " , emp_no ";
						mysql = mysql + " , voucher_date ";
						mysql = mysql + " , loan_amount ";
						mysql = mysql + " , total_balance ";
						mysql = mysql + " from pay_employee pemp , pay_loan ploan ";
						mysql = mysql + " where ";
						mysql = mysql + " pemp.emp_cd = ploan.emp_cd ";
						mysql = mysql + " and voucher_no = " + txtCommonTextBox[conTxtLoanNo].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblEmpCode].Text = "";
							txtDisplayLabel[conDlblEmpName].Text = "";
							txtDisplayLabel[conDlblLoanDate].Text = "";
							txtDisplayLabel[conDlblLoanAmount].Text = "";
							txtDisplayLabel[conDlblLoanBalance].Text = "";

							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
							txtDisplayLabel[conDlblLoanDate].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(2)), SystemVariables.gSystemDateFormat);
							txtDisplayLabel[conDlblLoanAmount].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(3)), "###,###,###.000");
							txtDisplayLabel[conDlblLoanBalance].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(4)), "###,###,###.000");
						}
					}
					else
					{
						txtDisplayLabel[conDlblEmpCode].Text = "";
						txtDisplayLabel[conDlblEmpName].Text = "";
						txtDisplayLabel[conDlblLoanDate].Text = "";
						txtDisplayLabel[conDlblLoanAmount].Text = "";
						txtDisplayLabel[conDlblLoanBalance].Text = "";
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
					txtCommonTextBox[conTxtLoanNo].Focus();
				}
				else
				{
					//
				}
			}

		}
	}
}