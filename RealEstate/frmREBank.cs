
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmREBank
		: System.Windows.Forms.Form
	{

		public frmREBank()
{
InitializeComponent();
} 
 public  void frmREBank_old()
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


		private void frmREBank_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private clsToolbar oThisFormToolBar = null;
		public Control FirstFocusObject = null;

		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;


		private const int conTxtBankNo = 0;
		private const int conTxtLBankName = 1;
		private const int conTxtABankName = 2;
		private const int conTxtLShortBankName = 3;
		private const int conTxtAShortBankName = 4;
		private const int conTxtRemarks = 5;

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


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{
				FirstFocusObject = txtCommon[conTxtBankNo];
				txtCommon[conTxtBankNo].Text = SystemProcedure2.GetNewNumber("re_Bank", "Bank_no", 2);
				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);
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
				if (KeyCode == 13)
				{
					SendKeys.Send("{TAB}");
					return;
				}

				if (this.ActiveControl.Name != "txtCommon")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommon#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void AddRecord()
		{

			SystemProcedure2.ClearTextBox(this);

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			mSearchValue = "";
			FirstFocusObject.Focus();
			txtCommon[conTxtBankNo].Text = SystemProcedure2.GetNewNumber("re_Bank", "Bank_no", 2);
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord(bool pPostGl = false)
		{
			bool result = false;
			string mySQL = "";
			string myErrMsg = "";
			try
			{
				SystemVariables.gConn.BeginTransaction();
				myErrMsg = new String(' ', 24) + "Error";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mySQL = " insert into RE_Bank ";
					mySQL = mySQL + " (Bank_No, L_Bank_Name,A_Bank_name,L_Short_Name,A_Short_Name,comments,User_Cd) ";
					mySQL = mySQL + " values( ";
					mySQL = mySQL + txtCommon[conTxtBankNo].Text;
					mySQL = mySQL + ",'" + txtCommon[conTxtLBankName].Text + "'";
					mySQL = mySQL + ",N'" + txtCommon[conTxtABankName].Text + "'";
					mySQL = mySQL + ",'" + txtCommon[conTxtLShortBankName].Text + "'";
					mySQL = mySQL + ",N'" + txtCommon[conTxtAShortBankName].Text + "'";
					mySQL = mySQL + ",'" + txtCommon[conTxtRemarks].Text + "'";
					mySQL = mySQL + "," + SystemVariables.gLoggedInUserCode.ToString();
					mySQL = mySQL + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mySQL;
					TempCommand.ExecuteNonQuery();
				}
				else if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{ 
					mySQL = "update RE_Bank ";
					mySQL = mySQL + " set Bank_no = " + txtCommon[conTxtBankNo].Text;
					mySQL = mySQL + " , L_Bank_Name = " + "'" + txtCommon[conTxtLBankName].Text + "'";
					mySQL = mySQL + " , A_Bank_Name = " + "N'" + txtCommon[conTxtABankName].Text + "'";
					mySQL = mySQL + " , L_Short_Name = " + "'" + txtCommon[conTxtLShortBankName].Text + "'";
					mySQL = mySQL + " , A_Short_Name = " + "N'" + txtCommon[conTxtAShortBankName].Text + "'";
					mySQL = mySQL + " , comments = " + "'" + txtCommon[conTxtRemarks].Text + "'";
					mySQL = mySQL + " where Bank_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mySQL;
					TempCommand_2.ExecuteNonQuery();
				}
				result = true;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				return result;

				return false;
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}
			return result;
		}






		public bool deleteRecord()
		{
			bool result = false;

			SystemVariables.gConn.BeginTransaction();
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mySQL = "delete from re_Bank where Bank_Cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mySQL;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Bank can't be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			try
			{
				string mySQL = "";
				object mReturnValue = null;
				SqlDataReader localRec = null;
				mySQL = " select * ";
				mySQL = mySQL + " from re_Bank ";
				mySQL = mySQL + " where Bank_cd = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mySQL, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{

					mSearchValue = localRec["Bank_Cd"];

					txtCommon[conTxtBankNo].Text = Convert.ToString(localRec["Bank_No"]);
					txtCommon[conTxtLBankName].Text = Convert.ToString(localRec["l_Bank_name"]);
					txtCommon[conTxtABankName].Text = Convert.ToString(localRec["A_Bank_name"]) + "";

					txtCommon[conTxtRemarks].Text = Convert.ToString(localRec["comments"]) + "";

					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						txtCommon[conTxtLShortBankName].Text = Convert.ToString(localRec["l_Short_name"]);
					}
					else
					{
						txtCommon[conTxtAShortBankName].Text = Convert.ToString(localRec["A_Short_name"]);
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

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9007000));
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
			if (txtCommon[conTxtBankNo].Text.Trim() == "")
			{
				MessageBox.Show("You have to enter the Bank No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txtCommon[conTxtBankNo].Focus();
			}
			else
			{

				if (txtCommon[conTxtLBankName].Text.Trim() == "")
				{
					MessageBox.Show("You have to enter the Bank Name", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txtCommon[conTxtLBankName].Focus();
				}
				else
				{
					return true;

				}
			}

			return false;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

			UserAccess = null;
			oThisFormToolBar = null;
			frmREBank.DefInstance = null;
		}

		private void txtCommon_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);
			if (Index == conTxtBankNo)
			{
				txtCommon[conTxtBankNo].Text = SystemProcedure2.GetNewNumber("re_Bank", "Bank_No", 2);
			}
			else
			{
				//Call FindRoutine("txtCommon#" & Trim(Index))
			}
		}
	}
}