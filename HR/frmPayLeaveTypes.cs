
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayLeaveTypes
		: System.Windows.Forms.Form
	{

		
		public frmPayLeaveTypes()
{
InitializeComponent();
} 
 public  void frmPayLeaveTypes_old()
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

			FirstFocusObject = txtGradeNo;

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
				txtGradeNo.Text = SystemProcedure2.GetNewNumber("Pay_Grade", "Grade_No");
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
			txtGradeNo.Text = SystemProcedure2.GetNewNumber("Pay_Grade", "Grade_No");
			//txtParentgradeNo.Enabled = True

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
			double gUserCd = 0;
			object mReturnValue = null;
			//Dim mParentgradeCode As Integer
			//Save a record
			//During save check for the mode
			//If in addmode then insert a record
			//else update the record in the recordset

			string mysql = "";
			try
			{

				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " INSERT INTO Pay_Grade(user_cd, Grade_No, l_grade_name, a_grade_name, comments)";
					mysql = mysql + " VALUES(" + Conversion.Str(gUserCd) + ",";
					mysql = mysql + txtGradeNo.Text + ",";
					mysql = mysql + "'" + txtLGradeName.Text + "',";
					mysql = mysql + "N'" + txtAGradeName.Text + "',";
					mysql = mysql + "N'" + txtComment.Text + "')";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					mysql = " select time_stamp,protected from Pay_Grade where grade_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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
					if (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(1)))
					{
						MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollbackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}
					mysql = "UPDATE Pay_Grade SET ";
					mysql = mysql + " Grade_No =" + txtGradeNo.Text + ",";
					mysql = mysql + " L_grade_Name ='" + txtLGradeName.Text + "',";
					mysql = mysql + " A_grade_Name =N'" + txtAGradeName.Text + "',";
					mysql = mysql + " Comments =N'" + txtComment.Text + "',";
					mysql = mysql + " User_Cd =" + Conversion.Str(gUserCd);
					mysql = mysql + " where grade_cd=" + Conversion.Str(mSearchValue);
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

			bool result = false;
			string mysql = " select protected from Pay_Grade where grade_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
				{
					MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				//If an error occurs, trap the error and dispaly a valid message
				SystemVariables.gConn.BeginTransaction();

				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					mysql = "delete from Pay_Grade where grade_cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (Information.Err().Number != 0)
					{
						MessageBox.Show("Product grade cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollbackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}

					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();
					result = true;
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}

			return result;

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

			try
			{
				string mysql = "";
				object mReturnValue = null;
				SqlDataReader localRec = null;

				mysql = " select * from Pay_Grade where grade_cd= " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{
					mSearchValue = localRec["grade_cd"];
					mTimeStamp = Convert.ToString(localRec["time_stamp"]);
					txtGradeNo.Text = Convert.ToString(localRec["Grade_No"]);
					txtLGradeName.Text = Convert.ToString(localRec["l_grade_Name"]);
					txtAGradeName.Text = Convert.ToString(localRec["a_grade_Name"]) + "";
					//        If .Fields("m_grade_cd") = 0 Then
					//            txtParentgradeNo.Enabled = False
					//        Else
					//            txtParentgradeNo.Enabled = True
					//            mReturnValue = GetMasterCode("select " & IIf(gPreferedLanguage = english, " Grade_No,l_grade_name", "Grade_No,a_grade_name") & " from Pay_Grade where grade_cd=" & .Fields("m_grade_cd"))
					//            txtParentgradeNo.Text = mReturnValue(0)
					//            txtParentgradeName.Text = mReturnValue(1)
					//        End If
					txtComment.Text = Convert.ToString(localRec["Comments"]) + "";

					//Change the form mode to edit
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
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7007000));
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
			if (!Information.IsNumeric(txtGradeNo.Text))
			{
				MessageBox.Show("Enter grade Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstFocusObject.Focus();
				return false;
			}

			return true;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			object frmPaygradeionality = null;
			UserAccess = null;
			frmPaygradeionality = null;
		}

		private void txtGradeNo_DropButtonClick(Object Sender, EventArgs e)
		{
			//Get the maximum + 1 product_category code
			GetNextNumber();
		}

		public void FindRoutine(string pObjectName)
		{
			//Dim mTempSearchValue As Variant
			//
			//Select Case pObjectName
			//    Case "txtParentgradeNo"
			//        txtParentgradeNo.Text = ""
			//        mTempSearchValue = FindItem(7001000, "727,728,729", mysql)
			//        If Not IsNull(mTempSearchValue) Then
			//            txtParentgradeNo.Text = mTempSearchValue(1)
			//            txtParentgradeName.Text = IIf(gPreferedLanguage = english, mTempSearchValue(2), mTempSearchValue(3))
			//            Call txtParentgradeNo_LostFocus
			//        End If
			//    Case Else
			//        Exit Sub
			//End Select

		}

		public void GetNextNumber()
		{
			txtGradeNo.Text = SystemProcedure2.GetNewNumber("Pay_Grade", "Grade_No");
			FirstFocusObject.Focus();
		}
	}
}