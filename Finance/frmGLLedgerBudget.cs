
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmGLLedgerBudget
		: System.Windows.Forms.Form
	{

		public frmGLLedgerBudget()
{
InitializeComponent();
} 
 public  void frmGLLedgerBudget_old()
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


		private void frmGLLedgerBudget_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//Variable for storing the searchvalue from the Find window
		object mSearchValue = null;
		int mThisFormID = 0;
		string mTimeStamp = "";
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

		//This class checks for the rights given to the user
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0; //Enum for checking the current form mode
		public Control FirstFocusObject = null;
		private XArrayHelper _aVoucherDetails = null;
		XArrayHelper aVoucherDetails
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


		private void cbFromMonth_Leave(Object eventSender, EventArgs eventArgs)
		{
			GenerateRecord();
		}

		private void cbFromYear_Leave(Object eventSender, EventArgs eventArgs)
		{
			GenerateRecord();
		}

		private void cbToMonth_Leave(Object eventSender, EventArgs eventArgs)
		{
			GenerateRecord();
		}

		private void cbToYear_Leave(Object eventSender, EventArgs eventArgs)
		{
			GenerateRecord();
		}

		private void cmdAllocate_Click(Object eventSender, EventArgs eventArgs)
		{
			int i = 0;
			double mAllocatedMonthValue = ReflectionHelper.GetPrimitiveValue<double>(txtAnnualBudget.Value) / ((double) DateAndTime.DateDiff("M", DateTime.Parse("01-" + cbFromMonth.Text + "-" + cbFromYear.Text), DateTime.Parse("01-" + cbToMonth.Text + "-" + cbToYear.Text), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
			AssignGridValues(mAllocatedMonthValue);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			C1.Win.C1TrueDBGrid.C1DisplayColumn colVoucherDetails = null;
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
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				FirstFocusObject = txtLdgrNo;

				cbFromYear.AddItem("2006");
				cbFromYear.AddItem("2007");
				cbFromYear.AddItem("2008");
				cbFromYear.AddItem("2009");
				cbFromYear.AddItem("2010");
				cbFromYear.AddItem("2011");
				cbFromYear.AddItem("2012");
				cbFromYear.AddItem("2013");
				cbFromYear.AddItem("2014");

				cbFromMonth.AddItem("January");
				cbFromMonth.AddItem("February");
				cbFromMonth.AddItem("March");
				cbFromMonth.AddItem("April");
				cbFromMonth.AddItem("May");
				cbFromMonth.AddItem("June");
				cbFromMonth.AddItem("July");
				cbFromMonth.AddItem("August");
				cbFromMonth.AddItem("September");
				cbFromMonth.AddItem("October");
				cbFromMonth.AddItem("November");
				cbFromMonth.AddItem("December");

				cbToYear.AddItem("2006");
				cbToYear.AddItem("2007");
				cbToYear.AddItem("2008");
				cbToYear.AddItem("2009");
				cbToYear.AddItem("2010");
				cbToYear.AddItem("2011");
				cbToYear.AddItem("2012");
				cbToYear.AddItem("2013");
				cbToYear.AddItem("2014");

				cbToMonth.AddItem("January");
				cbToMonth.AddItem("February");
				cbToMonth.AddItem("March");
				cbToMonth.AddItem("April");
				cbToMonth.AddItem("May");
				cbToMonth.AddItem("June");
				cbToMonth.AddItem("July");
				cbToMonth.AddItem("August");
				cbToMonth.AddItem("September");
				cbToMonth.AddItem("October");
				cbToMonth.AddItem("November");
				cbToMonth.AddItem("December");

				//Assign the Image for the toolbar
				//Imagelist are kept on the main form and refered by their key
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture

				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false);
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Year", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Month", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Period", 3500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount", 900, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);

				cbFromYear.Text = DateTime.Parse(SystemVariables.gCurrentPeriodStarts).Year.ToString();
				cbFromMonth.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Parse(SystemVariables.gCurrentPeriodStarts).Month);
				cbToYear.Text = DateTime.Parse(SystemVariables.gCurrentPeriodEnds).Year.ToString();
				cbToMonth.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Parse(SystemVariables.gCurrentPeriodEnds).Month);

				GenerateRecord();
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
				if (Shift == 0 && this.ActiveControl.Name == "grdVoucherDetails")
				{
					if (grdVoucherDetails.Col == 2)
					{
						if ((KeyCode == 8) || (KeyCode == 46) || (KeyCode == 27))
						{
							//
						}
						else if ((KeyCode >= 48 && KeyCode <= 57) || (KeyCode >= 96 && KeyCode <= 105) || (KeyCode == 190) || (KeyCode == 110))
						{ 
							//
						}
						else
						{
							KeyCode = 0;
						}
					}
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
			txtAnnualBudget.Value = 0;
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			AssignGridValues(0);
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
			int cnt = 0;
			System.DateTime mStartDate = DateTime.FromOADate(0);
			System.DateTime mEndDate = DateTime.FromOADate(0);

			try
			{

				//Get the Parent Group Code
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select ldgr_cd from gl_ledger where ldgr_no=" + txtLdgrNo.Text));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Enter valid ledger code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtLdgrNo.Focus();
					return false;
				}

				SystemVariables.gConn.BeginTransaction();
				grdVoucherDetails.UpdateData();
				string mCheckTimeStamp = "";

				mysql = " select time_stamp from gl_ledger_budget where ldgr_cd = '" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue) && (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp)))
				{
					MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					result = false;
					FirstFocusObject.Focus();
					return result;
				}
				mStartDate = DateTime.Parse("01-" + cbFromMonth.Text + "-" + cbFromYear.Text);
				mEndDate = DateTime.Parse("01-" + cbToMonth.Text + "-" + cbToYear.Text);

				mysql = "delete gl_ledger_Budget ";
				mysql = mysql + " where ldgr_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mysql = mysql + " and budget_Year > = " + mStartDate.Year.ToString() + " and budget_Year <= " + mEndDate.Year.ToString();
				mysql = mysql + " and budget_Month >= " + mStartDate.Month.ToString() + " and budget_Month <=" + mEndDate.Month.ToString();

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					mysql = "INSERT INTO gl_ledger_Budget(Ldgr_Cd, budget_Year, budget_Month, Amount, User_cd ) ";
					mysql = mysql + " VALUES(";
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ",";
					mysql = mysql + Convert.ToString(aVoucherDetails.GetValue(cnt, 0)) + ",";
					mysql = mysql + Convert.ToString(aVoucherDetails.GetValue(cnt, 1)) + ",";
					mysql = mysql + Convert.ToString(aVoucherDetails.GetValue(cnt, 3)) + ",";
					mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";

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
			bool result = false;
			string mysql = "";
			//Delete the Record
			try
			{

				mysql = "delete from gl_ledger_budget where ldgr_cd='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				return true;
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				FirstFocusObject.Focus();
				result = false;
			}
			return result;
		}

		public void printRecord()
		{
			//Print routine

		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool CheckDataValidity()
		{
			//Check validation during update and add of records
			if (SystemProcedure2.IsItEmpty(txtLdgrNo.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Ledger Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtLdgrNo.Focus();
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
				aVoucherDetails = null;
				oThisFormToolBar = null;
				frmGLLedgerBudget.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int i = 0;
			double mTotal = 0;
			grdVoucherDetails.UpdateData();
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (i = 0; i <= tempForEndVar; i++)
			{
				if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(i, 3), SystemVariables.DataType.NumberType))
				{
					mTotal += Convert.ToDouble(aVoucherDetails.GetValue(i, 3));
				}
			}
			txtAnnualBudget.Value = mTotal;
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == 3)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###,###,###.000");
				}
				else
				{
					Value = "";
				}
			}
		}


		private void txtLdgrNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{


				GenerateRecord();
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
					//if the code is not found
					//    txtLdgrNo.SetFocus
				}
				else
				{
					//
				}
			}

		}


		public void FindRoutine(string pObjectName)
		{
			//call the search window
			//Dim myString As String
			//Dim tempSearch  As New frmSearch
			//Dim mArr(1)
			//mArr(0) = 2500
			//mArr(1) = 3000
			//
			//Select Case pObjectName
			//    Case "txtLdgrNo"
			//        txtLdgrNo.Text = ""
			//        myString = "select ldgr_no as [Ledger Code], "
			//        myString = myString + IIf(gPreferedLanguage = English, "l_ldgr_name", "a_ldgr_name")
			//        myString = myString & " as [Ledger Name], ldgr_no  from Ledger "
			//        myString = myString & " order by 1 "
			//    Case Else
			//        Exit Sub
			//End Select
			//
			//tempSearch.gridSqlString = myString
			//tempSearch.gridColWidth = mArr
			//tempSearch.formName = Me
			//tempSearch.Show 1
			//
			//Select Case pObjectName
			//    Case "txtLdgrNo"
			//        txtLdgrNo.Text = tempSearch.getReturnValue
			//        Call txtLdgrNo_LostFocus
			//End Select
			//
			//Unload tempSearch
			//Set tempSearch = Nothing
		}

		private void txtLdgrNo_DropButtonClick(Object Sender, EventArgs e)
		{
			findRecord();
		}

		public void AssignGridValues(double mValue)
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(mValue, cnt, 3);
			}
			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Bookmark = 0;
		}

		public double GetGridValues(int mValue)
		{
			double result = 0;
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, 0))) == mValue)
				{
					result = Convert.ToDouble(aVoucherDetails.GetValue(cnt, 2));
					break;
				}
			}
			return result;
		}

		public void findRecord()
		{
			object mTempSearchValue = null;
			txtLdgrNo.Text = "";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2,3"));
			}
			else
			{
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2,4"));
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtLdgrNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtLdgrName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(2));
			}
			txtLdgrNo.Focus();
			txtAnnualBudget.Focus();
		}

		public object GenerateRecord()
		{
			try
			{

				int i = 0;
				System.DateTime mStartDate = DateTime.FromOADate(0);
				System.DateTime mEndDate = DateTime.FromOADate(0);
				int mMonthCount = 0;
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;
				DataSet rsBudget = null;

				if (cbFromMonth.Text != "" && cbFromYear.Text != "" && cbToMonth.Text != "" && cbToYear.Text != "")
				{
					mStartDate = DateTime.Parse("01-" + cbFromMonth.Text + "-" + cbFromYear.Text);
					mEndDate = DateTime.Parse("01-" + cbToMonth.Text + "-" + cbToYear.Text);

					lblFromToDate.Caption = " Budeget Allocated From: " + cbFromMonth.Text + "," + cbFromYear.Text + " To: " + cbToMonth.Text + "," + cbToYear.Text;

					mMonthCount = (int) DateAndTime.DateDiff("M", mStartDate, mEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
					//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					aVoucherDetails.Clear();
					aVoucherDetails.RedimXArray(new int[]{mMonthCount, 3}, new int[]{0, 0});


					while(mStartDate <= mEndDate)
					{
						aVoucherDetails.SetValue(mStartDate.Year, i, 0);
						aVoucherDetails.SetValue(mStartDate.Month, i, 1);
						aVoucherDetails.SetValue(DateTimeFormatInfo.CurrentInfo.GetMonthName(mStartDate.Month) + ", " + mStartDate.Year.ToString(), i, 2);
						mStartDate = mStartDate.AddMonths(1);
						i++;
					};

					mStartDate = DateTime.Parse("01-" + cbFromMonth.Text + "-" + cbFromYear.Text);
					mEndDate = DateTime.Parse("01-" + cbToMonth.Text + "-" + cbToYear.Text);

					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdVoucherDetails.setArray(aVoucherDetails);
					grdVoucherDetails.Rebind(true);

					if (!SystemProcedure2.IsItEmpty(txtLdgrNo.Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select ldgr_cd," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name");
						mysql = mysql + " from gl_ledger where ldgr_no=" + txtLdgrNo.Text;
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));


						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtLdgrName.Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtLdgrName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
							mysql = " select Ldgr_Cd, budget_Month, budget_Year, Amount, Time_Stamp";
							mysql = mysql + " from gl_ledger_budget ";
							mysql = mysql + " where ldgr_cd='" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0)) + "'";
							mysql = mysql + " and cast('01' + '-' + datename(mm, cast(cast(budget_Month as varchar(2)) + '-13' + '-2006' as smalldatetime)) + '-' + cast(budget_Year as varchar(4)) as smalldatetime)";
							mysql = mysql + " > = '" + DateTimeHelper.ToString(mStartDate) + "'";
							mysql = mysql + " and cast('01' + '-' + datename(mm, cast(cast(budget_Month as varchar(2)) + '-13' + '-2006' as smalldatetime)) + '-' + cast(budget_Year as varchar(4)) as smalldatetime)";
							mysql = mysql + " <= '" + DateTimeHelper.ToString(mEndDate) + "'";

							rsBudget = new DataSet();
							SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
							rsBudget.Tables.Clear();
							adap.Fill(rsBudget);
							txtAnnualBudget.Value = 0;

							if (rsBudget.Tables[0].Rows.Count == 0)
							{
								AssignGridValues(0);
								txtAnnualBudget.Focus();
								mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
								mSearchValue = "";
							}
							else
							{

								//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsBudget.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								rsBudget.MoveFirst();
								cnt = 0;
								mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mTimeStamp = Convert.ToString(rsBudget.Tables[0].Rows[0]["Time_Stamp"]);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mSearchValue = rsBudget.Tables[0].Rows[0]["Ldgr_Cd"];

								foreach (DataRow iteration_row in rsBudget.Tables[0].Rows)
								{
									int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
									for (cnt = 0; cnt <= tempForEndVar; cnt++)
									{
										if (aVoucherDetails.GetValue(cnt, 0) == iteration_row["budget_Year"] && aVoucherDetails.GetValue(cnt, 1) == iteration_row["budget_Month"])
										{
											aVoucherDetails.SetValue(iteration_row["Amount"], cnt, 3);
											//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
											txtAnnualBudget.Value = ReflectionHelper.GetPrimitiveValue<double>(txtAnnualBudget.Value) + Convert.ToDouble(iteration_row["Amount"]);
										}
									}

									//cnt = cnt + 1
								}

								grdVoucherDetails.Rebind(true);
								grdVoucherDetails.Bookmark = 0;
								txtAnnualBudget.Focus();

							}
						}
					}
					else
					{
						txtLdgrName.Text = "";
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
				}
			}
			return null;
		}
	}
}