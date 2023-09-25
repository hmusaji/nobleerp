
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayeEmployeeRehire
		: System.Windows.Forms.Form
	{

		public frmPayeEmployeeRehire()
{
InitializeComponent();
} 
 public  void frmPayeEmployeeRehire_old()
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


		private void frmPayeEmployeeRehire_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		private clsToolbar oThisFormToolBar = null;
		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private string mTimeStamp = "";

		private const int conDlblDeptCode = 0;
		private const int conDlblDeptName = 1;
		private const int conDlblDesgCode = 2;
		private const int conDlblDesgName = 3;
		private const int conDlblEmpName = 4;
		private const int conTxtEmpCode = 1;
		private int mReferenceNo = 0;
		private int mStatus = 0;
		private bool mIsPost = false;
		// mMethod Vaiable Description
		// 1 For Resume employee as New Employee; 2 For Resume employee as Old Employee With make all accrual balance zero
		// 3 For Resume employee as Old Employee and make hold period as Nopayday; 4 for Resume employee as old Employee and accrued all hold period as paid days
		private int mMethod = 0;
		//Set mMethod = 0
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


		private bool isInitializingComponent;
		private void ChkNewEmp_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				if (ChkNewEmp.Checked)
				{
					txtDateOfJoining.Enabled = true;
					txtNewEmpNo.Enabled = true;
					txtNewEmpNo.Text = txtCommonTextBox[conTxtEmpCode].Text;
					txtLastAccrualDate.Enabled = false;
					CHkOldWithNoPay.Checked = false;
					CHKOldWithPayDays.Checked = false;
					CHKOldWithZeroAccrual.Checked = false;
					mMethod = 1;
				}
				else
				{
					txtNewEmpNo.Text = "";
					mMethod = 0;
				}
			}
		}

		private void ResetControl()
		{
			txtDateOfJoining.Enabled = false;
			txtNewEmpNo.Enabled = false;
			txtLastAccrualDate.Enabled = false;
			txtnopaydays.Enabled = false;
		}

		private void CHkOldWithNoPay_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				ResetControl();
				if (CHkOldWithNoPay.Checked)
				{
					txtLastAccrualDate.Enabled = true;
					CHKOldWithPayDays.Checked = false;
					CHKOldWithZeroAccrual.Checked = false;
					ChkNewEmp.Checked = false;
					mMethod = 3;
				}
				else
				{
					mMethod = 0;
				}
			}
		}

		private void CHKOldWithPayDays_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				ResetControl();
				if (CHKOldWithPayDays.Checked)
				{
					txtLastAccrualDate.Enabled = true;
					CHkOldWithNoPay.Checked = false;
					CHKOldWithZeroAccrual.Checked = false;
					ChkNewEmp.Checked = false;
					mMethod = 4;
				}
				else
				{
					mMethod = 0;
				}
			}
		}

		private void CHKOldWithZeroAccrual_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				ResetControl();
				if (CHKOldWithZeroAccrual.Checked)
				{
					txtLastAccrualDate.Enabled = true;
					CHkOldWithNoPay.Checked = false;
					CHKOldWithPayDays.Checked = false;
					ChkNewEmp.Checked = false;
					mMethod = 2;
				}
				else
				{
					mMethod = 0;
				}
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

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			FirstFocusObject = txtCommonTextBox[conTxtEmpCode];

			try
			{

				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
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
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = false;
				oThisFormToolBar.ShowUnpostButton = false;
				oThisFormToolBar.DisableHelpButton = false;
				this.WindowState = FormWindowState.Maximized;
				mIsPost = false;
				SystemProcedure.SetLabelCaption(this);
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
		}

		public void FindRoutine(string pObjectName)
		{
			string mysql = "";
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
					case conTxtEmpCode : 
						mysql = " pay_emp.status_cd IN (3,4)"; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", mysql)); 
						break;
					default:
						return;
				}
			}

			//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue) && !Object.Equals(mTempSearchValue, null))
			{
				if (mObjectName == "txtCommonTextBox")
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[mIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
				}
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
				int mEmpCd = 0;

				if (Index == conTxtEmpCode && !mIsPost)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name" : "a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name");
						mysql = mysql + " , dept_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
						mysql = mysql + " , desg_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
						mysql = mysql + " , emp_cd";
						mysql = mysql + " , pemp.rate_calc_method_id, weekend, weekend_day1_id , weekend_day2_id  ";
						mysql = mysql + " , pemp.total_salary, pemp.status_cd, pemp.emp_cd ";
						mysql = mysql + " from pay_employee pemp , pay_department pdept, pay_designation pdesg ";
						mysql = mysql + " where ";
						mysql = mysql + " pemp.dept_cd = pdept.dept_cd and pemp.desg_cd = pdesg.desg_cd ";
						mysql = mysql + " and pemp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
						mysql = mysql + " and pemp.status_cd In(3,4)";

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtCommonTextBox[Index].Text = "";
							txtDisplayLabel[conDlblEmpName].Text = "";
							txtDisplayLabel[conDlblDeptCode].Text = "";
							txtDisplayLabel[conDlblDeptName].Text = "";
							txtDisplayLabel[conDlblDesgCode].Text = "";
							txtDisplayLabel[conDlblDesgName].Text = "";
							txtNewEmpNo.Text = "";
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
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mStatus = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(11));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(12));
							txtNewEmpNo.Text = txtCommonTextBox[conTxtEmpCode].Text;
							if (mStatus == SystemHRProcedure.gStatusOnHold)
							{
								mysql = " select entry_id,startdate,resumedate from pay_employee_hold_details";
								mysql = mysql + " where emp_cd=" + mEmpCd.ToString();
								mysql = mysql + " and resumed_processed = 0 ";
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mReferenceNo = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtStartDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(1));
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtResumeDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(2));
							}
							else
							{
								mysql = " select termination_date,emp_cd from pay_employee";
								mysql = mysql + " where emp_cd=" + mEmpCd.ToString();
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								txtStartDate.Value = (Convert.IsDBNull(((Array) mTempValue).GetValue(0))) ? ((object) DateTime.Today) : ((Array) mTempValue).GetValue(0);
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mReferenceNo = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(1));
							}
						}
					}
					else
					{
						txtDisplayLabel[conDlblEmpName].Text = "";
						txtDisplayLabel[conDlblDeptCode].Text = "";
						txtDisplayLabel[conDlblDeptName].Text = "";
						txtDisplayLabel[conDlblDesgCode].Text = "";
						txtDisplayLabel[conDlblDesgName].Text = "";
						txtNewEmpNo.Text = "";
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
					if (txtCommonTextBox[Index].Enabled)
					{
						txtCommonTextBox[Index].Focus();
					}
				}
				else
				{
					//
				}
			}
		}

		public void GetRecord(object pEntryId)
		{

			string mysql = " select perd.*, pemp.emp_no, pemp.l_full_name,pemp.status_cd ";
			mysql = mysql + " ,dept.dept_no, dept.l_dept_name";
			mysql = mysql + " ,desg.desg_no, desg.l_desg_name";
			mysql = mysql + " from pay_employee_rehire_details perd";
			mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = perd.emp_cd";
			mysql = mysql + " inner join pay_department dept on dept.dept_cd = perd.dept_cd";
			mysql = mysql + " inner join pay_designation desg on desg.desg_cd = perd.desg_cd ";
			mysql = mysql + " where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(pEntryId);

			DataSet rs = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rs.Tables.Clear();
			adap.Fill(rs);
			if (rs.Tables[0].Rows.Count != 0)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mTimeStamp = Convert.ToString(rs.Tables[0].Rows[0]["time_stamp"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mIsPost = Convert.ToBoolean(rs.Tables[0].Rows[0]["posted"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtEmpCode].Text = Convert.ToString(rs.Tables[0].Rows[0]["emp_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtStartDate.Value = rs.Tables[0].Rows[0]["startdate"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtResumeDate.Value = rs.Tables[0].Rows[0]["expected_resumedate"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!SystemProcedure2.IsItEmpty(rs.Tables[0].Rows[0]["new_date_of_joining"], SystemVariables.DataType.DateType))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtDateOfJoining.Value = rs.Tables[0].Rows[0]["new_date_of_joining"];
				}
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!SystemProcedure2.IsItEmpty(rs.Tables[0].Rows[0]["last_accrual_date"], SystemVariables.DataType.DateType))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtLastAccrualDate.Value = rs.Tables[0].Rows[0]["last_accrual_date"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtnopaydays.Text = Convert.ToString(rs.Tables[0].Rows[0]["total_unpaid_days"]);
				}
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!rs.Tables[0].Rows[0].IsNull("resumed_method"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					switch(Convert.ToInt32(rs.Tables[0].Rows[0]["resumed_method"]))
					{
						case 1 : 
							ChkNewEmp.Checked = true; 
							break;
						case 2 : 
							CHKOldWithZeroAccrual.Checked = true; 
							break;
						case 3 : 
							CHkOldWithNoPay.Checked = true; 
							break;
						case 4 : 
							CHKOldWithPayDays.Checked = true; 
							break;
					}
				}
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblEmpName].Text = Convert.ToString(rs.Tables[0].Rows[0]["l_full_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDeptCode].Text = Convert.ToString(rs.Tables[0].Rows[0]["dept_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDeptName].Text = Convert.ToString(rs.Tables[0].Rows[0]["l_dept_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDesgCode].Text = Convert.ToString(rs.Tables[0].Rows[0]["desg_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDesgName].Text = Convert.ToString(rs.Tables[0].Rows[0]["l_desg_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mStatus = Convert.ToInt32(rs.Tables[0].Rows[0]["status_Cd"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtNewEmpNo.Text = Convert.ToString(rs.Tables[0].Rows[0]["new_employee_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mReferenceNo = Convert.ToInt32(rs.Tables[0].Rows[0]["reference_no"]);
			}
			mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			frmDetail.Visible = true;
			txtCommonTextBox[conTxtEmpCode].Locked = true;
			txtStartDate.Enabled = false;
		}

		public void findRecord()
		{
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220300));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mMethod = 0;
			mStatus = 0;
			ChkNewEmp.Checked = false;
			CHkOldWithNoPay.Checked = false;
			CHKOldWithPayDays.Checked = false;
			CHKOldWithZeroAccrual.Checked = false;
			mIsPost = false;
			mSearchValue = ""; //Change the msearchvalue to blank
			txtCommonTextBox[conTxtEmpCode].Locked = false;
			txtStartDate.Enabled = true;
		}

		public bool deleteRecord()
		{
			bool result = false;
			string mysql = "";
			object mReturnValue = null;
			try
			{

				mysql = " select protected,posted from pay_employee_rehire_details where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0)) != 0 || ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1)) != 0)
					{
						MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}

					//If an error occurs, trap the error and dispaly a valid message
					SystemVariables.gConn.BeginTransaction();

					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
					try
					{
						mysql = "delete from pay_employee_rehire_details where entry_id=" + Conversion.Str(mSearchValue);
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql;
						TempCommand.ExecuteNonQuery();

						//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (Information.Err().Number != 0)
						{
							MessageBox.Show("Record cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							return false;
						}

						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.CommitTrans();
						result = true;
					}
					catch (Exception exc2)
					{
						NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
					}
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();

					int mReturnErrorType = 0;
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
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
			}

			return result;
		}


		public bool saveRecord()
		{
			bool result = false;
			object mReturnValue = null;
			string mysql = "";
			int mDeptCd = 0, mEmpCd = 0, mDesgCd = 0;
			string mOldDateOfJoining = "";
			try
			{

				mysql = " select emp_cd,date_of_joining from pay_employee where emp_no='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mOldDateOfJoining = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				}
				else
				{
					MessageBox.Show("Invalid Employee Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return result;
				}

				mysql = " select dept_cd from pay_department where dept_no=" + txtDisplayLabel[conDlblDeptCode].Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDeptCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					MessageBox.Show("Invalid Department Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return result;
				}

				mysql = " select desg_cd from pay_designation where desg_no=" + txtDisplayLabel[conDlblDesgCode].Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDesgCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					MessageBox.Show("Invalid Designation Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return result;
				}

				SystemVariables.gConn.BeginTransaction();

				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " select reference_no from pay_employee_rehire_details";
					mysql = mysql + " where reference_no=" + mReferenceNo.ToString();
					mysql = mysql + " and posted = 0";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						mysql = " INSERT INTO pay_employee_rehire_details";
						mysql = mysql + " (emp_cd,dept_cd,desg_cd,startdate,expected_resumedate,resumed_method";
						mysql = mysql + " ,new_employee_no,old_date_of_joining,new_date_of_joining,last_accrual_date";
						mysql = mysql + " ,total_unpaid_days,reference_no,user_cd)";
						mysql = mysql + " VALUES(" + mEmpCd.ToString() + "," + mDeptCd.ToString() + "," + mDesgCd.ToString();
						mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDate.Value) + "'";
						mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtResumeDate.Value) + "'";
						mysql = mysql + " ," + mMethod.ToString();
						mysql = mysql + " ,'" + txtNewEmpNo.Text + "'";
						if (mMethod == 1)
						{
							mysql = mysql + " ,'" + mOldDateOfJoining + "'";
							mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtDateOfJoining.Value) + "'";
							mysql = mysql + " ,Null,0";
						}
						else
						{
							mysql = mysql + " ,Null,Null";
							mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtLastAccrualDate.Value) + "'";
							mysql = mysql + " ," + txtnopaydays.Text;
						}
						mysql = mysql + "," + mReferenceNo.ToString();
						mysql = mysql + "," + Conversion.Str(SystemVariables.gLoggedInUserCode);
						mysql = mysql + ")";

						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql;
						TempCommand.ExecuteNonQuery();
						mysql = " SELECT SCOPE_IDENTITY()";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
					}
					else
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show("Record Already Exist.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}
				else
				{
					mysql = "select posted from pay_employee_rehire_details where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
					{
						MessageBox.Show("Record Posted, cannot be modified!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}

					mysql = "UPDATE pay_employee_rehire_details ";
					mysql = mysql + " set emp_cd=" + mEmpCd.ToString() + ", dept_cd =" + mDeptCd.ToString() + ", desg_cd=" + mDesgCd.ToString();
					mysql = mysql + " ,startdate='" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDate.Value) + "'";
					mysql = mysql + " ,expected_resumedate='" + ReflectionHelper.GetPrimitiveValue<string>(txtResumeDate.Value) + "'";
					mysql = mysql + " ,resumed_method=" + mMethod.ToString();
					if (mMethod == 1)
					{
						mysql = mysql + " ,old_date_of_joining ='" + StringsHelper.Format(mOldDateOfJoining, SystemVariables.gSystemDateFormat) + "'";
						mysql = mysql + " ,New_date_of_joining ='" + ReflectionHelper.GetPrimitiveValue<string>(txtDateOfJoining.Value) + "'";
					}
					else
					{
						mysql = mysql + " ,last_accrual_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtLastAccrualDate.Value) + "'";
					}
					mysql = mysql + " ,total_unpaid_days =" + txtnopaydays.Text;
					mysql = mysql + " ,reference_no=" + mReferenceNo.ToString();
					mysql = mysql + " ,User_Cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where entry_id =" + Conversion.Str(mSearchValue);
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

		private void txtLastAccrualDate_Change(Object Sender, EventArgs e)
		{
			if (((CHkOldWithNoPay.Checked) ? -1 : 0) == 1)
			{
				txtnopaydays.Text = (((int) DateAndTime.DateDiff("d", DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtLastAccrualDate.Text), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) + 1).ToString();
			}
			else
			{
				txtnopaydays.Text = "0";
			}
		}

		public bool Post()
		{
			bool result = false;
			try
			{
				string mysql = "";
				object mReturnValue = null;
				int mUnPaidDays = 0;
				string mLastMonthGenDate = "";
				string pAsOnDate = "";
				string mGenerateDate = "";
				int mEmpCd = 0;

				if (!CheckDataValidity())
				{
					return result;
				}

				if (!saveRecord())
				{
					return result;
				}


				//''need to check below logic with ...by hakim jamali 18-jul-2010
				mLastMonthGenDate = DateTimeHelper.ToString(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddDays(-1));
				if (DateTime.Parse(txtResumeDate.Text) > DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()))
				{ // And CDate(txtResumeDate.Text) < CDate(GetPayrollGenerateStartDate) Then
					MessageBox.Show("This Transaction will post in next month", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return result;
				}

				mEmpCd = SystemHRProcedure.GetEmpCd(txtCommonTextBox[conTxtEmpCode].Text);
				SystemVariables.gConn.BeginTransaction();
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					if (mMethod != 0)
					{

						switch(mMethod)
						{
							case 1 :  //As a new employee rehire 
								if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDateOfJoining.Value) >= ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtStartDate.Value))
								{ //And CDate(txtDateOfJoining.Value) <= CDate(txtResumeDate.Value) Then
									//UPGRADE_WARNING: (1068) txtDateOfJoining.Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									pAsOnDate = ReflectionHelper.GetPrimitiveValue<string>(txtDateOfJoining.Value);
									if (txtCommonTextBox[conTxtEmpCode].Text == txtNewEmpNo.Text)
									{
										if (!SystemHRProcedure.UpdateAccrualWithZero(ReflectionHelper.GetPrimitiveValue<string>(txtDateOfJoining.Value), mEmpCd))
										{
											result = false;
											//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
											SystemVariables.gConn.RollbackTrans();
											return result;
										}
										mysql = " update pay_employee ";
										mysql = mysql + " set date_of_joining = '" + ReflectionHelper.GetPrimitiveValue<string>(txtDateOfJoining.Value) + "'";
										mysql = mysql + " where emp_no='" + txtNewEmpNo.Text + "'";
										SqlCommand TempCommand = null;
										TempCommand = SystemVariables.gConn.CreateCommand();
										TempCommand.CommandText = mysql;
										TempCommand.ExecuteNonQuery();
									}
									else
									{
										if (!CreateNewEmployee(mEmpCd, txtNewEmpNo.Text))
										{
											//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
											SystemVariables.gConn.RollbackTrans();
											return result;
										}
									}
								}
								else
								{
									MessageBox.Show("Date of joining must be greater than start date. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									result = false;
									//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
									SystemVariables.gConn.RollbackTrans();
									return result;
								} 
								break;
							case 2 : 
								if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtLastAccrualDate.Value) > ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtStartDate.Value) && ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtLastAccrualDate.Value) <= ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtResumeDate.Value))
								{
									if (!SystemHRProcedure.UpdateAccrualWithZero(ReflectionHelper.GetPrimitiveValue<string>(txtLastAccrualDate.Value), mEmpCd))
									{
										result = false;
										//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
										SystemVariables.gConn.RollbackTrans();
										return result;
									}
									//UPGRADE_WARNING: (1068) txtLastAccrualDate.Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									pAsOnDate = ReflectionHelper.GetPrimitiveValue<string>(txtLastAccrualDate.Value);
								}
								else
								{
									MessageBox.Show("Accrual date must be greater than start date and less than resume date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								} 
								break;
							case 3 : 
								if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtLastAccrualDate.Value) > ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtStartDate.Value) && ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtLastAccrualDate.Value) <= ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtResumeDate.Value))
								{
									mUnPaidDays = Convert.ToInt32(Double.Parse(txtnopaydays.Text));
									if (!SystemHRProcedure.UpdateAdjustleavedays(mUnPaidDays, mEmpCd, ReflectionHelper.GetPrimitiveValue<string>(txtResumeDate.Value)))
									{
										result = false;
										//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
										SystemVariables.gConn.RollbackTrans();
										return result;
									}
								}
								else
								{
									MessageBox.Show("Accrual date must be greater than start date and less than resume date.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								} 
								break;
						}


						//''commented by hakim on 13-may-2009
						//        If CDate(pAsOnDate) > CDate(mLastMonthGenDate) + 1 Then
						//            mUnPaidDays = DateDiff("d", CDate(mLastMonthGenDate), CDate(pAsOnDate))
						//            If Not UpdateAdjustleavedays(mUnPaidDays, mEmpCd, txtResumeDate.Value) Then
						//                Post = False
						//                Exit Function
						//            End If
						//        End If
						mysql = " update pay_employee_rehire_details";
						mysql = mysql + " set posted = 1";
						mysql = mysql + " where entry_id= " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();

						mysql = " update pay_employee ";
						mysql = mysql + " set status_cd = " + SystemHRProcedure.gStatusActive.ToString();
						mysql = mysql + ", termination_date = null ";
						mysql = mysql + " where emp_no='" + txtNewEmpNo.Text + "'";
						SqlCommand TempCommand_3 = null;
						TempCommand_3 = SystemVariables.gConn.CreateCommand();
						TempCommand_3.CommandText = mysql;
						TempCommand_3.ExecuteNonQuery();

						mysql = " update pay_employee_hold_details";
						mysql = mysql + " set resumed_processed = 1";
						mysql = mysql + " where emp_cd=" + SystemHRProcedure.GetEmpCd(txtCommonTextBox[conTxtEmpCode].Text).ToString();
						mysql = mysql + " and resumed_processed = 0";
						SqlCommand TempCommand_4 = null;
						TempCommand_4 = SystemVariables.gConn.CreateCommand();
						TempCommand_4.CommandText = mysql;
						TempCommand_4.ExecuteNonQuery();
						mEmpCd = SystemHRProcedure.GetEmpCd(txtNewEmpNo.Text);
						//' Generate This Employee Attendance Agauin
						//mEmpCd = GetEmpCd(txtCommonTextBox(conTxtEmpCode).Text)
						//'''need to check below messages .. by hakim on 18-jul-2010
						if (!SystemHRProcedure.ClearTimeAttendanceCurrentMonthTransaction(mEmpCd, mEmpCd))
						{
							MessageBox.Show("Error : Time & Attendance could not be generated!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							return result;
						}
						if (!SystemHRProcedure.GenerateTimeAttendanceMonthlyTransaction(mEmpCd, mEmpCd))
						{
							MessageBox.Show("Error : Time & Attendance could not be generated!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							return result;
						}
						if (!SystemHRProcedure.UpdateVacationInTimeAttendance(mEmpCd, mEmpCd))
						{
							MessageBox.Show("Error : Time & Attendance could not be generated!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							return result;
						}
						if (!SystemHRProcedure.UpdateTimeAttendanceDayOff(mEmpCd, mEmpCd))
						{
							MessageBox.Show("Error : Time & Attendance could not be generated!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							return result;
						}
						//'' Generate That Employee Payroll Again
						mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();
						SystemHRProcedure.GeneratePayrollEntry(mGenerateDate, txtNewEmpNo.Text, txtNewEmpNo.Text);
						SystemHRProcedure.GenerateLeaveEntry(mGenerateDate, txtNewEmpNo.Text, txtNewEmpNo.Text);
						SystemHRProcedure.GenerateLoanEntry(mGenerateDate, txtNewEmpNo.Text, txtNewEmpNo.Text);

						MessageBox.Show("Record Posted!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show(" Please choose a method of resume/rehire !!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return result;
					}
				}
				else
				{
					MessageBox.Show("You cannot post record at this time!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return result;
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				return true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
			}
			return result;
		}

		public bool CheckDataValidity()
		{
			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Please select an employee!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			if (!Information.IsDate(txtResumeDate.Value))
			{
				MessageBox.Show("Please select resume date!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			if (mMethod == 0)
			{
				MessageBox.Show("Please choose a rehire method!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			return true;
		}

		public bool CreateNewEmployee(int pOldEmpCd, string pNewEmpNo)
		{
			bool result = false;
			string mysql = "";
			int mEmpCd = 0;
			try
			{

				//'' For Append Employee Master Record
				mysql = " insert into pay_employee";
				mysql = mysql + " (Curr_Cd, Dept_Cd, Desg_Cd, Grade_Cd, Nat_Cd, Status_Cd, Comp_Cd, Manager_Cd, Qalfn_Cd, Religion_Cd, Bank_Cd, Bank_Branch_Cd, Visa_Type, ";
				mysql = mysql + " Sponsor_Cd, Agent_Cd, Contract_Cd, Emp_No, L_First_Name, L_Second_Name, L_Third_Name, L_Fourth_Name, A_First_Name, A_Second_Name, A_Third_Name,";
				mysql = mysql + " A_Fourth_Name, Date_Of_Birth, Place_Of_Birth, L_Father_Name, A_Father_Name, L_Mother_Name, A_Mother_Name, Sex_Id, Emp_Type_Id, Date_Of_Joining,";
				mysql = mysql + " Date_Of_Entry, Blood_Group, Marital_Status_Id, No_Of_Wives, No_Of_Child, Block, Street, Lane, Type_Of_Building, Building_No, Qasima, Floor, Flat_No, PO_Box,";
				mysql = mysql + " Zip_Cd, Phone, Fax, Email, Pager, Mobile, Permanent_Addr_1, Permanent_Addr_2, Permanent_Addr_3, Permanent_Phone, Current_Contract_No,";
				mysql = mysql + " Current_Contract_Start_Date, Current_Contract_Indemnity_Start_Date, Current_Contract_End_Date, Allow_Overtime, Is_Payroll_Emp, Is_Payroll_Generated,";
				mysql = mysql + " Rate_Calc_Method_Id, Payment_Type_Id, Bank_Account_No, Bank_Account_Type_Id, Weekend, Weekend_Day1_Id, Weekend_Day2_Id, Basic_Salary, Total_Salary";
				mysql = mysql + " , Indemnity_Salary, Last_Salary_Date, Days_Per_Month, Hours_Per_Day, OT_Calc_Method_Id, Normal_OT, Friday_OT, Holiday_OT,";
				mysql = mysql + " Indemnity_Switch_Over_Period, Indemnity_Days_Before_SOP, Indemnity_Days_After_SOP, Indemnity_Working_Days_Per_Month_Before_SOP,";
				mysql = mysql + " Indemnity_Working_Days_Per_Month_After_SOP, Indemnity_Deduct_Paid_Days, Indemnity_Deduct_Unpaid_Days, Opening_Indemnity_Balance_Days,";
				mysql = mysql + " Opening_Indemnity_Balance_Amount, Opening_Indemnity_As_On, Opening_Indemnity_Days_Encashed, Indemnity_Days_Encashed, Emp_CV, Emp_Picture,";
				mysql = mysql + " Comments, Show, Protected, User_Cd, User_Date_Time,Civil_Id, Passport_No, Termination_Date,";
				mysql = mysql + " Work_Permit_No, Visa_No, area, Emp_Picture_Path, Transfer_Bank_Entry_Id, Probation_End_Date, entrance, Comment1, Comment2, Comment3, Title_Id,";
				mysql = mysql + " Notice_Period, Rate_Per_Hour, Mobile_Allowance_Entitled, Mobile_Allowance_Amount, Probation_days, Include_In_Payslip_Printing)";

				mysql = mysql + " select Curr_Cd, Dept_Cd, Desg_Cd, Grade_Cd, Nat_Cd, Status_Cd, Comp_Cd, Manager_Cd, Qalfn_Cd, Religion_Cd, Bank_Cd, Bank_Branch_Cd, Visa_Type, ";
				mysql = mysql + " Sponsor_Cd, Agent_Cd, Contract_Cd,'" + txtNewEmpNo.Text + "' , L_First_Name, L_Second_Name, L_Third_Name, L_Fourth_Name, A_First_Name, A_Second_Name, A_Third_Name,";
				mysql = mysql + " A_Fourth_Name, Date_Of_Birth, Place_Of_Birth, L_Father_Name, A_Father_Name, L_Mother_Name, A_Mother_Name, Sex_Id, Emp_Type_Id,'" + DateTime.Parse(txtDateOfJoining.Text).ToString("dd-MMM-yyyy") + "',";
				mysql = mysql + " Date_Of_Entry, Blood_Group, Marital_Status_Id, No_Of_Wives, No_Of_Child, Block, Street, Lane, Type_Of_Building, Building_No, Qasima, Floor, Flat_No, PO_Box,";
				mysql = mysql + " Zip_Cd, Phone, Fax, Email, Pager, Mobile, Permanent_Addr_1, Permanent_Addr_2, Permanent_Addr_3, Permanent_Phone, Current_Contract_No,";
				mysql = mysql + " Current_Contract_Start_Date, Current_Contract_Indemnity_Start_Date, Current_Contract_End_Date, Allow_Overtime, Is_Payroll_Emp, Is_Payroll_Generated,";
				mysql = mysql + " Rate_Calc_Method_Id, Payment_Type_Id, Bank_Account_No, Bank_Account_Type_Id, Weekend, Weekend_Day1_Id, Weekend_Day2_Id, Basic_Salary, Total_Salary";
				mysql = mysql + " , Indemnity_Salary, Last_Salary_Date, Days_Per_Month, Hours_Per_Day, OT_Calc_Method_Id, Normal_OT, Friday_OT, Holiday_OT,";
				mysql = mysql + " Indemnity_Switch_Over_Period, Indemnity_Days_Before_SOP, Indemnity_Days_After_SOP, Indemnity_Working_Days_Per_Month_Before_SOP,";
				mysql = mysql + " Indemnity_Working_Days_Per_Month_After_SOP, Indemnity_Deduct_Paid_Days, Indemnity_Deduct_Unpaid_Days, Opening_Indemnity_Balance_Days,";
				mysql = mysql + " Opening_Indemnity_Balance_Amount, Opening_Indemnity_As_On, Opening_Indemnity_Days_Encashed, Indemnity_Days_Encashed, Emp_CV, Emp_Picture,";
				mysql = mysql + " Comments, Show, Protected," + SystemVariables.gLoggedInUserCode.ToString() + ", User_Date_Time, Civil_Id, Passport_No, Termination_Date,";
				mysql = mysql + " Work_Permit_No, Visa_No, area, Emp_Picture_Path, Transfer_Bank_Entry_Id, Probation_End_Date, entrance, Comment1, Comment2, Comment3, Title_Id,";
				mysql = mysql + " Notice_Period, Rate_Per_Hour, Mobile_Allowance_Entitled, Mobile_Allowance_Amount, Probation_days, Include_In_Payslip_Printing";
				mysql = mysql + " from  pay_employee";
				mysql = mysql + " where emp_cd =" + pOldEmpCd.ToString();
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//'Get New Employee Code
				mEmpCd = SystemHRProcedure.GetEmpCd(pNewEmpNo);

				//' For Append Employeee Billing type
				mysql = "insert into pay_employee_billing_details(emp_cd, bill_cd, billing_mode, amount, last_change_date, last_amount, comments, include_in_leave, include_in_indemnity, user_cd)";
				mysql = mysql + " select " + mEmpCd.ToString() + ", bill_cd, billing_mode, amount, last_change_date, last_amount, comments, include_in_leave, include_in_indemnity";
				mysql = mysql + "," + SystemVariables.gLoggedInUserCode.ToString();
				mysql = mysql + " from pay_employee_billing_details";
				mysql = mysql + " where emp_cd =" + pOldEmpCd.ToString();
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				//' For Append Employee Leave Details
				mysql = "insert into pay_employee_leave_details(emp_cd, leave_cd, leave_switch_over_period, leave_days_before_sop, leave_days_after_sop, working_days_per_month_before_sop";
				mysql = mysql + " , working_days_per_month_after_sop, deduct_paid_days, deduct_unpaid_days, opening_paid_leave_balance_date, opening_paid_leave_balance_days";
				mysql = mysql + " , opening_paid_leave_taken_days, opening_unpaid_leave_taken_days, paid_leave_taken_days, unpaid_leave_taken_days, ytd_paid_leave_days";
				mysql = mysql + " , ytd_unpaid_leave_days, maximum_leave_days, leave_provision_amount, leave_provision_days, leave_provision_paid_days_taken";
				mysql = mysql + " , paid_leave_encashed_amount, opening_indemnity_days_encashed_amount, comments, last_resume_date, user_cd)";
				mysql = mysql + " select  " + mEmpCd.ToString() + ", leave_cd, leave_switch_over_period, leave_days_before_sop, leave_days_after_sop, working_days_per_month_before_sop";
				mysql = mysql + " , working_days_per_month_after_sop, deduct_paid_days, deduct_unpaid_days, opening_paid_leave_balance_date, opening_paid_leave_balance_days";
				mysql = mysql + " , opening_paid_leave_taken_days, opening_unpaid_leave_taken_days, paid_leave_taken_days, unpaid_leave_taken_days, ytd_paid_leave_days";
				mysql = mysql + " , ytd_unpaid_leave_days, maximum_leave_days, leave_provision_amount, leave_provision_days, leave_provision_paid_days_taken";
				mysql = mysql + " , paid_leave_encashed_amount, opening_indemnity_days_encashed_amount, comments, last_resume_date," + SystemVariables.gLoggedInUserCode.ToString();
				mysql = mysql + " from pay_employee_leave_details";
				mysql = mysql + " where emp_cd =" + pOldEmpCd.ToString();
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				//' For Terminate old employee
				mysql = "update pay_employee";
				mysql = mysql + " set status_cd =" + SystemHRProcedure.gStatusTerminated.ToString();
				mysql = mysql + " ,comments = 'Terminated Because of re-hiring as new employee no" + pNewEmpNo + "'";
				mysql = mysql + " where emp_cd=" + pOldEmpCd.ToString();
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();

				return true;
			}
			catch
			{
				result = false;
			}
			return result;
		}


		private void txtResumeDate_Change(Object Sender, EventArgs e)
		{
			//txtLastAccrualDate.Value = txtResumeDate.Value
		}
		public void CloseForm()
		{
			this.Close();
		}

		private void txtResumeDate_Validating(Object eventSender, CancelEventArgs eventArgs)
		{
			bool Cancel = eventArgs.Cancel;
			try
			{
				//UPGRADE_WARNING: (1068) txtResumeDate.Value of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtLastAccrualDate.Value = ReflectionHelper.GetPrimitiveValue(txtResumeDate.Value);
			}
			finally
			{
				eventArgs.Cancel = Cancel;
			}
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}