
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmGLAnalysisCode
		: System.Windows.Forms.Form
	{

		public frmGLAnalysisCode()
{
InitializeComponent();
} 
 public  void frmGLAnalysisCode_old()
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


		private void frmGLAnalysisCode_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private int mThisFormID = 0;
		private object mSearchValue = null;

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

		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		public Control FirstFocusObject = null;
		private string mTimeStamp = "";

		private const int conTxtAnalysisCode = 0;
		private const int conTxtAnalysisNameEnglish = 1;
		private const int conTxtAnalysisNameArabic = 2;
		private const int conTxtAnalysisShortNameEnglish = 3;
		private const int conTxtAnalysisShortNameArabic = 4;
		private const int conTxtAnalysisComments = 5;


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
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				FirstFocusObject = txtCommon[conTxtAnalysisCode];

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
					oThisFormToolBar.ShowPrintButton = true;
					oThisFormToolBar.ShowFindButton = true;
					oThisFormToolBar.ShowHelpButton = true;
					oThisFormToolBar.ShowExitButton = true;
					oThisFormToolBar.BeginExitButtonWithGroup = true;
					//.DisableHelpButton = True

					this.WindowState = FormWindowState.Maximized;

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_1")))
					{
						comAnalysisHeadNo.AddItem("1");
						comAnalysisHeadNo.SetItemData(comAnalysisHeadNo.NewIndex, 1);
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_2")))
					{
						comAnalysisHeadNo.AddItem("2");
						comAnalysisHeadNo.SetItemData(comAnalysisHeadNo.NewIndex, 2);
					}
					comAnalysisHeadNo.ListIndex = 0;

					if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_2")))
					{
						comAnalysisHeadNo.Visible = false;
						lblDisplayLabel[0].Visible = false;
					}

					//assign a next code
					txtCommon[conTxtAnalysisCode].Text = SystemProcedure2.GetNewNumber("gl_analysis", "anly_code");

					SystemProcedure.SetLabelCaption(this);
					clsFlip oFlipThisForm = null;
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
					{
						oFlipThisForm = new clsFlip();

						oFlipThisForm.SwapMe(this);
					}

					SetDefaultValue();
					return;
				}
				catch (System.Exception excep)
				{

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
					this.Close();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
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
			txtCommon[conTxtAnalysisCode].Text = SystemProcedure2.GetNewNumber("gl_analysis", "anly_code");
			SetDefaultValue();

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


			string mysql = "";
			try
			{


				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					//Get the Parent Group Code
					mysql = " insert into gl_analysis ";
					mysql = mysql + " (anly_head_no, anly_code, l_anly_name, a_anly_name ";
					mysql = mysql + " , l_anly_short_name, a_anly_short_name ";
					mysql = mysql + ", Start_Date, End_Date, Estimated_Expenses, Estimated_Income";
					mysql = mysql + " , freeze, user_cd) ";
					mysql = mysql + " VALUES(";
					mysql = mysql + comAnalysisHeadNo.GetItemData(comAnalysisHeadNo.ListIndex).ToString();
					mysql = mysql + ",'" + txtCommon[conTxtAnalysisCode].Text + "'";
					mysql = mysql + ",'" + txtCommon[conTxtAnalysisNameEnglish].Text + "'";
					mysql = mysql + ",N'" + txtCommon[conTxtAnalysisNameArabic].Text + "'";
					mysql = mysql + ",'" + txtCommon[conTxtAnalysisShortNameEnglish].Text + "'";
					mysql = mysql + ",N'" + txtCommon[conTxtAnalysisShortNameArabic].Text + "'";
					mysql = mysql + "," + ((ReflectionHelper.GetPrimitiveValue<string>(txtStartDate.Value) == "") ? " Null" : "'" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDate.Value) + "'");
					mysql = mysql + "," + ((ReflectionHelper.GetPrimitiveValue<string>(txtEndDate.Value) == "") ? " Null" : "'" + ReflectionHelper.GetPrimitiveValue<string>(txtEndDate.Value) + "'");
					mysql = mysql + "," + txtExtimatedExp.Text;
					mysql = mysql + "," + txtEstimatedIncome.Text;
					mysql = mysql + ",N'" + txtComment.Text + "'";
					mysql = mysql + "," + ((int) chkFreeze.CheckState).ToString();
					mysql = mysql + "," + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

				}
				else
				{
					mysql = " select time_stamp from gl_analysis where anly_code ='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
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

					mysql = " UPDATE gl_analysis SET ";
					mysql = mysql + " anly_head_no =" + Conversion.Str(comAnalysisHeadNo.GetItemData(comAnalysisHeadNo.ListIndex));
					mysql = mysql + " , anly_code ='" + txtCommon[conTxtAnalysisCode].Text + "'";
					mysql = mysql + " , l_anly_name ='" + txtCommon[conTxtAnalysisNameEnglish].Text + "'";
					mysql = mysql + " , a_anly_name =N'" + txtCommon[conTxtAnalysisNameArabic].Text + "'";
					mysql = mysql + " , l_anly_short_name ='" + txtCommon[conTxtAnalysisShortNameEnglish].Text + "'";
					mysql = mysql + " , a_anly_short_name =N'" + txtCommon[conTxtAnalysisShortNameArabic].Text + "'";
					mysql = mysql + " , l_anly_desc =N'" + txtComment.Text + "'";
					mysql = mysql + " , Start_Date = " + ((ReflectionHelper.GetPrimitiveValue<string>(txtStartDate.Value) == "") ? " Null" : "'" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDate.Value) + "'");
					mysql = mysql + " , End_Date = " + ((ReflectionHelper.GetPrimitiveValue<string>(txtEndDate.Value) == "") ? " Null" : "'" + ReflectionHelper.GetPrimitiveValue<string>(txtEndDate.Value) + "'");
					mysql = mysql + " , Estimated_Expenses = " + txtExtimatedExp.Text;
					mysql = mysql + " , Estimated_Income = " + txtEstimatedIncome.Text;
					mysql = mysql + " , Comments ='" + txtComment.Text + "'";
					mysql = mysql + " , user_cd=" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " , freeze=" + ((int) chkFreeze.CheckState).ToString();
					mysql = mysql + " where anly_code='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";

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
			//Delete the Record
			bool result = false;


			//If an error occurs, trap the error and dispaly a valid message
			SystemVariables.gConn.BeginTransaction();

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "delete from gl_analysis where anly_code=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Cost center cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			string mysql = "";
			SqlDataReader localRec = null;

			try
			{

				mysql = " select * from gl_analysis where anly_code ='" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue) + "'";
				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{
					mSearchValue = Convert.ToString(localRec["anly_code"]).Trim();
					mTimeStamp = Convert.ToString(localRec["time_stamp"]);

					SystemCombo.SearchCombo(comAnalysisHeadNo, Convert.ToInt32(localRec["anly_head_no"]));

					txtCommon[conTxtAnalysisCode].Text = Convert.ToString(localRec["anly_code"]);
					txtCommon[conTxtAnalysisNameEnglish].Text = Convert.ToString(localRec["l_anly_name"]);
					txtCommon[conTxtAnalysisNameArabic].Text = Convert.ToString(localRec["a_anly_name"]) + "";
					txtCommon[conTxtAnalysisShortNameEnglish].Text = Convert.ToString(localRec["l_anly_short_name"]);
					txtCommon[conTxtAnalysisShortNameArabic].Text = Convert.ToString(localRec["a_anly_short_name"]) + "";
					txtComment.Text = Convert.ToString(localRec["Comments"]) + "";
					if (!Convert.IsDBNull(localRec["Start_Date"]))
					{
						txtStartDate.Value = Convert.ToString(localRec["Start_Date"]) + "";
					}
					else
					{
						txtStartDate.Text = "";
					}

					if (!Convert.IsDBNull(localRec["End_Date"]))
					{
						txtEndDate.Value = Convert.ToString(localRec["End_Date"]) + "";
					}
					else
					{
						txtEndDate.Text = "";
					}

					txtExtimatedExp.Value = Convert.ToString(localRec["Estimated_Expenses"]) + "";
					txtEstimatedIncome.Value = Convert.ToString(localRec["Estimated_Income"]) + "";

					if (Convert.ToBoolean(localRec["freeze"]))
					{
						chkFreeze.CheckState = CheckState.Checked;
					}
					else
					{
						chkFreeze.CheckState = CheckState.Unchecked;
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
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1008000));
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

		public void cmdGetNextNumber_Click()
		{
			//Get the maximum + 1 gl_analysis code
			txtCommon[conTxtAnalysisCode].Text = SystemProcedure2.GetNewNumber("gl_analysis", "anly_code");
			FirstFocusObject.Focus();
		}

		public bool CheckDataValidity()
		{

			if (SystemProcedure2.IsItEmpty(txtCommon[conTxtAnalysisCode].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Analysis Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommon[conTxtAnalysisCode].Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[conTxtAnalysisNameEnglish].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Analysis Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommon[conTxtAnalysisNameEnglish].Focus();
				return false;
			}


			if (SystemProcedure2.IsItEmpty(txtCommon[conTxtAnalysisShortNameEnglish].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Analysis Short Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommon[conTxtAnalysisShortNameEnglish].Focus();
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
				frmGLAnalysisCode.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void GetNextNumber()
		{
			txtCommon[conTxtAnalysisCode].Text = SystemProcedure2.GetNewNumber("gl_analysis", "anly_code");
			FirstFocusObject.Focus();
		}

		private void txtCommon_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);
			if (Index == conTxtAnalysisCode)
			{
				GetNextNumber();
			}
		}

		private void SetDefaultValue()
		{
			txtStartDate.Value = SystemVariables.gCurrentDate;
			txtEndDate.Value = SystemVariables.gCurrentDate;
		}
	}
}