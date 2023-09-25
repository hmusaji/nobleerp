
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayGeneratePayroll
		: System.Windows.Forms.Form
	{

		private clsAccessAllowed _UserAccess = null;
		public frmPayGeneratePayroll()
{
InitializeComponent();
} 
 public  void frmPayGeneratePayroll_old()
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

		private int mFormCallType = 0;
		private int mThisFormID = 0; //Assign the Formid for Each Form
		private bool mFirstGridFocus = false;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		private DataSet rsEmpGenerated = null;

		private const int conTxtFromEmpCode = 0;
		private const int conTxtToEmpCode = 1;

		private const int conDlblFromEmpCode = 0;
		private const int conDlblToEmpCode = 1;

		private SystemICSConstants.ShowOptions mPostOptionType = (SystemICSConstants.ShowOptions) 0;

		private const int mNormalHeight = 2700;
		private const int mAdvancedHeight = 4400;

		private const string mAdvancedCaption = "&Advance Mode >>";
		private const string mNormalCaption = "<< &Normal Mode";

		private int mEmpCdFrom = 0; //For Time and Attendance
		private int mEmpCdTo = 0; //For Time and Attendance


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


		public int FormCallType
		{
			set
			{
				mFormCallType = value;
			}
		}


		private void chkGenerateAll_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			if (chkGenerateAll.CheckState == CheckState.Checked)
			{
				txtCommonTextBox[conTxtFromEmpCode].Text = "";
				txtCommonTextBox[conTxtToEmpCode].Text = "";

				txtCommonTextBox[conTxtFromEmpCode].Enabled = false;
				txtCommonTextBox[conTxtToEmpCode].Enabled = false;

				mEmpCdFrom = 0;
				mEmpCdTo = 0;
			}
			else
			{
				txtCommonTextBox[conTxtFromEmpCode].Enabled = true;
				txtCommonTextBox[conTxtToEmpCode].Enabled = true;
				if (txtCommonTextBox[conTxtFromEmpCode].Text != "")
				{
					mEmpCdFrom = SystemHRProcedure.GetEmpCd(txtCommonTextBox[conTxtFromEmpCode].Text);
				}
				if (txtCommonTextBox[conTxtToEmpCode].Text != "")
				{
					mEmpCdTo = SystemHRProcedure.GetEmpCd(txtCommonTextBox[conTxtToEmpCode].Text);
				}
			}
		}

		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			string mGenerateDate = "";
			int mTotalEmpGenerated = 0;
			string mysql = "";
			object mReturnValue = null;
			object mPhoneDeductionCode = null;

			try
			{

				mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();
				if (mGenerateDate == "")
				{
					return;
				}

				if (mFormCallType == 1)
				{
					//'Set the recordset for total no. of employees
					rsEmpGenerated = new DataSet();
					//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
					//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsEmpGenerated.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					UpgradeStubs.ADODB_Fields15.Append("Emp_Cd", DbType.Decimal, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
					//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
					//UPGRADE_ISSUE: (2070) Constant adOpenUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsEmpGenerated.Open was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsEmpGenerated.Open(null, null, UpgradeStubs.ADODB_CursorTypeEnum.getadOpenUnspecified(), UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified(), -1);

					SystemVariables.gConn.BeginTransaction();
					if (chkClearPayroll.CheckState == CheckState.Checked)
					{
						SystemHRProcedure.ClearPayroll(mGenerateDate, txtCommonTextBox[conTxtFromEmpCode].Text, txtCommonTextBox[conTxtToEmpCode].Text);
					}
					SystemHRProcedure.GeneratePayrollEntry(mGenerateDate, txtCommonTextBox[conTxtFromEmpCode].Text, txtCommonTextBox[conTxtToEmpCode].Text, rsEmpGenerated);
					SystemHRProcedure.GenerateLeaveEntry(mGenerateDate, txtCommonTextBox[conTxtFromEmpCode].Text, txtCommonTextBox[conTxtToEmpCode].Text, rsEmpGenerated);
					SystemHRProcedure.GenerateLoanEntry(mGenerateDate, txtCommonTextBox[conTxtFromEmpCode].Text, txtCommonTextBox[conTxtToEmpCode].Text, rsEmpGenerated);

					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();

					if (rsEmpGenerated.Tables[0].Rows.Count != 0)
					{
						mTotalEmpGenerated = rsEmpGenerated.Tables[0].Rows.Count;
					}
					else
					{
						mTotalEmpGenerated = 0;
					}
					if (rsEmpGenerated.Tables[0].Rows.Count > 0)
					{
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsEmpGenerated.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsEmpGenerated.MoveFirst();
						foreach (DataRow iteration_row in rsEmpGenerated.Tables[0].Rows)
						{
							txtGeneratedEmployee.Text = txtGeneratedEmployee.Text + GetEmpNo(Convert.ToInt32(iteration_row["emp_cd"])) + Environment.NewLine;
						}
					}
					MessageBox.Show(mTotalEmpGenerated.ToString() + " Employees Generated, successfully! ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//Unload Me
					//''''''''''''''''''''''''''''''''''
				}
				else if (mFormCallType == 2)
				{ 
					if (mEmpCdFrom > 0 && mEmpCdTo == 0)
					{
						MessageBox.Show("Please Enter both from and to Employee No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					else if (mEmpCdFrom == 0 && mEmpCdTo > 0)
					{ 
						MessageBox.Show("Please Enter both from and to Employee No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					SystemVariables.gConn.BeginTransaction();

					//''check msgbox , by hakim on 18-jul-2010
					if (!SystemHRProcedure.ClearTimeAttendanceCurrentMonthTransaction(mEmpCdFrom, mEmpCdTo))
					{
						MessageBox.Show("Error : Time & Attendance could not be generated!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return;
					}
					if (!SystemHRProcedure.GenerateTimeAttendanceMonthlyTransaction(mEmpCdFrom, mEmpCdTo))
					{
						MessageBox.Show("Error : Time & Attendance could not be generated!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return;
					}
					if (!SystemHRProcedure.UpdateVacationInTimeAttendance(mEmpCdFrom, mEmpCdTo))
					{
						MessageBox.Show("Error : Time & Attendance could not be generated!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return;
					}
					if (!SystemHRProcedure.UpdateTimeAttendanceDayOff(mEmpCdFrom, mEmpCdTo))
					{
						MessageBox.Show("Error : Time & Attandance could not be generated!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return;
					}
					if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("Import_TimeAttendance_Format")) == 4)
					{
						SystemHRProcedure.UpdateAttendanceFromProjectTable(mEmpCdFrom, mEmpCdTo);
					}
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();
					MessageBox.Show("Time & Attandance generated successfully!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();

					this.Close();
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}

		}

		private void cmdPostMode_OKClick(Object Sender, EventArgs e)
		{
			if (mPostOptionType == SystemICSConstants.ShowOptions.optNormalMode)
			{
				mPostOptionType = SystemICSConstants.ShowOptions.optAdvancedMode;
			}
			else
			{
				mPostOptionType = SystemICSConstants.ShowOptions.optNormalMode;
			}
			ShowHideAdvancedOptions(mPostOptionType);
		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					FirstFocusObject.Focus();
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				SystemProcedure.SetLabelCaption(this);

				FirstFocusObject = txtCommonTextBox[conTxtFromEmpCode];

				this.Top = 0;
				this.Left = 0;
				ShowHideAdvancedOptions(SystemICSConstants.ShowOptions.optNormalMode);
				txtGeneratedEmployee.Text = "";
				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //setting form mode to add initially
				chkClearPayroll.Visible = mFormCallType == 1;
				this.WindowState = FormWindowState.Maximized;
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

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				frmPayGeneratePayroll.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCommonTextBox_Change(Object Sender, EventArgs e)
		{
			chkGenerateAll_CheckStateChanged(chkGenerateAll, new EventArgs());
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
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
				case conTxtFromEmpCode : 
					txtCommonTextBox[conTxtFromEmpCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtFromEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtToEmpCode : 
					txtCommonTextBox[conTxtToEmpCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtToEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				default:
					return;
			}
		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			try
			{
				object mTempValue = null;
				string mysql = "";

				if (Index == conTxtFromEmpCode)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtFromEmpCode].Text, SystemVariables.DataType.StringType))
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name" : "a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name");
						mysql = mysql + " from pay_employee pemp ";
						mysql = mysql + " where ";
						mysql = mysql + " pemp.emp_no ='" + txtCommonTextBox[conTxtFromEmpCode].Text + "'";

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblFromEmpCode].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblFromEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
						}
					}
					else
					{
						txtDisplayLabel[conDlblFromEmpCode].Text = "";
					}
				}
				else if (Index == conTxtToEmpCode)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtToEmpCode].Text, SystemVariables.DataType.StringType))
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name" : "a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name");
						mysql = mysql + " from pay_employee pemp ";
						mysql = mysql + " where ";
						mysql = mysql + " pemp.emp_no ='" + txtCommonTextBox[conTxtToEmpCode].Text + "'";

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblToEmpCode].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblToEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
						}
					}
					else
					{
						txtDisplayLabel[conDlblToEmpCode].Text = "";
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

		public void CloseForm()
		{
			this.Close();
		}


		private void TotalEmployeesGenerated(int pEmpCd, DataSet pEmpRec)
		{

			if (pEmpRec.Tables[0].Rows.Count == 0)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method pEmpRec.AddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				pEmpRec.AddNew("emp_cd", pEmpCd);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method pEmpRec.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				pEmpRec.MoveFirst();
				pEmpRec.Find(" emp_cd = " + pEmpCd.ToString());
				if (pEmpRec.Tables[0].Rows.Count == 0)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method pEmpRec.AddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					pEmpRec.AddNew("emp_cd", pEmpCd);
				}
			}

		}


		// added   For Get Employee code
		private string GetEmpNo(int pEmpCd)
		{
			string mSQL = " select emp_No";
			mSQL = mSQL + " from pay_employee";
			mSQL = mSQL + " where emp_cd= '" + pEmpCd.ToString() + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				return ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
			}
			else
			{
				return "0";
			}
		}

		private void ShowHideAdvancedOptions(SystemICSConstants.ShowOptions ChangeToMode)
		{
			bool mShowSetting = false;

			if (ChangeToMode == SystemICSConstants.ShowOptions.optAdvancedMode)
			{
				mShowSetting = true;
				cmdPostMode.OkCaption = mNormalCaption;
				//Me.Height = mAdvancedHeight
				//fraOptions.Enabled = True
			}
			else
			{
				mShowSetting = false;
				cmdPostMode.OkCaption = mAdvancedCaption;
				this.Height = mNormalHeight / 15;
				//fraOptions.Enabled = False
			}
			mPostOptionType = ChangeToMode;
		}
	}
}