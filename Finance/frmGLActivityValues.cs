
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmGLActivityValues
		: System.Windows.Forms.Form
	{

		public frmGLActivityValues()
{
InitializeComponent();
} 
 public  void frmGLActivityValues_old()
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


		private void frmGLActivityValues_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private bool mFirstGridFocus = false;
		private int mThisFormID = 0;
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

		private object mSearchValue = null;
		private string mTimeStamp = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private clsToolbar oThisFormToolBar = null;

		private const int mLineNoColumn = 0;
		private const int mActivityValueCodeColumn = 1;
		private const int mActivityValueNameEnglishColumn = 2;
		private const int mActivityValueNameArabicColumn = 3;
		private const int mActivityValueShortNameEnglishColumn = 4;
		private const int mActivityValueShortNameArabicColumn = 5;
		private const int mActivityValueFreezeColumn = 6;

		private const int conTxtActivityCode = 0;
		private const int conTxtActivityNameEnglish = 1;
		private const int conTxtActivityNameArabic = 2;

		private const int mMaxArrayCols = 6;


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


		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			//tabMaster.Width = Me.Width - 400
			//tabFGeneral.Width = tabMaster.Width
			//grdVoucherDetails.Width = tabFGeneral.Width

			//tabMaster.Height = Me.Height - 3000
			//tabFGeneral.Height = tabMaster.Height
			//grdVoucherDetails.Height = tabFGeneral.Height
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				//Set rsProductList = Nothing
				oThisFormToolBar = null;
				UserAccess = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public bool CheckDataValidity()
		{
			bool result = false;
			int cnt = 0;
			//Check validation during update and add of records

			if (SystemProcedure2.IsItEmpty(txtCommon[conTxtActivityCode].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Part Number", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//FirstFocusObject.SetFocus
				result = false;
				txtCommon[conTxtActivityCode].Focus();
				return result;
			}

			grdVoucherDetails.UpdateData();

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, mActivityValueCodeColumn), SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Activity Value Code ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}

			int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar2; cnt++)
			{
				if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, mActivityValueNameEnglishColumn), SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Activity Value Name ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}
			return true;
		}



		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			//Dim MasterProductCode As Variant
			//
			//MasterProductCode = GetMasterCode("select Prod_Cd from ICS_Item where Part_no='" & txtCommon(conTxtActivityCode).Text & "'")
			//
			//If Not IsNull(MasterProductCode) Then
			//grdVoucherDetails.Enabled = True
			//'If mFirstGridFocus = True And Not IsNull(MasterProductCode) Then
			//    Dim mySql As String
			//
			//    mFirstGridFocus = False
			//    'setting up the ICS_Item list combobox properties
			//
			//    mySql = "select  symbol , "
			//    mySql = mySql + IIf(gPreferedLanguage = English, "L_Unit_Name [Unit Name]", "A_Unit_Name [Unit Name]")
			//    mySql = mySql & " from ICS_Item "
			//    mySql = mySql & " INNER JOIN   ICS_Item_Unit_Details ON ICS_Item.Prod_Cd = ICS_Item_Unit_Details.Prod_Cd  "
			//    mySql = mySql & " INNER JOIN   ICS_Unit ON ICS_Item_Unit_Details.Alt_Unit_Cd = ICS_Unit.Unit_Cd  "
			//    mySql = mySql & " where ICS_Item.prod_cd = " & MasterProductCode
			//
			//    Set rsProductList = New ADODB.Recordset
			//    rsProductList.CursorLocation = adUseClient
			//    rsProductList.Open mySql, gConn, adOpenStatic, adLockReadOnly
			//
			//
			//Else
			//    grdVoucherDetails.Enabled = False
			//    'rsProductList.Requery
			//End If

			grdVoucherDetails.Col = 1;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			FirstFocusObject = txtCommon[conTxtActivityCode];

			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, "&H98AA88");

			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Value Code", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Value Name (English)", 3500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Value Name (Arabic)", 3500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Short Name (English)", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Short Name (Arabic)", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);

			C1.Win.C1TrueDBGrid.C1DisplayColumn colVoucherDetails = null;

			this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			this.Top = 0;
			this.Left = 0;

			mFirstGridFocus = true;
			//setting voucher details grid properties
			aVoucherDetails.RedimXArray(new int[]{0, mMaxArrayCols}, new int[]{0, 0});
			aVoucherDetails.SetValue(1, 0, 0);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);
			grdVoucherDetails.Rebind(true);

			//**--format & define the new toolbar
			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			oThisFormToolBar.ShowNewButton = true;
			oThisFormToolBar.ShowSaveButton = true;
			oThisFormToolBar.BeginDeleteButtonWithGroup = true;
			oThisFormToolBar.ShowDeleteButton = true;
			//.ShowPrintButton = True
			oThisFormToolBar.ShowFindButton = true;
			oThisFormToolBar.ShowHelpButton = true;
			oThisFormToolBar.BeginInsertLineButtonWithGroup = true;
			oThisFormToolBar.ShowInsertLineButton = true;
			oThisFormToolBar.ShowDeleteLineButton = true;
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.DisableHelpButton = true;

			this.WindowState = FormWindowState.Maximized;

		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//if the user presses any control key in the voucher grid object
				if (this.ActiveControl.Name == "grdVoucherDetails")
				{
					switch(KeyCode)
					{
						case 13 : case 113 : 
							return;
					}
					if (Shift == 0)
					{
						if (grdVoucherDetails.Col == 4 || grdVoucherDetails.Col == 5 || grdVoucherDetails.Col == 6 || grdVoucherDetails.Col == 7)
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
					else if (Shift == 2)
					{ 
						switch(KeyCode)
						{
							case 68 :  //Ctrl+D to delete grid current row 
								//                aVoucherDetails.DeleteRows (grdVoucherDetails.row) 
								//                grdVoucherDetails.Refresh 
								break;
							case 73 :  //Ctrl+I to insert a row from grid's current row 
								//aVoucherDetails.InsertRows 
								break;
						}
					}
				}
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			grdVoucherDetails.Columns[0].Text = (grdVoucherDetails.RowCount + 1).ToString();
		}

		public void CloseForm()
		{
			aVoucherDetails = null;
			this.Close();
		}

		public void IRoutine()
		{
			if (ActiveControl.Name != "grdVoucherDetails")
			{
				grdVoucherDetails.Focus();
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdVoucherDetails.Bookmark))
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), 1);
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Focus();
				grdVoucherDetails.Refresh();
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdVoucherDetails")
			{
				grdVoucherDetails.Focus();
			}

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdVoucherDetails.Delete();
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
			}
		}

		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, mLineNoColumn);
			}
		}

		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			//mOldVoucherStatus = stActive        'set new voucher status to active by default
			//txtStatus.Caption = CheckVoucherStatus(mOldVoucherStatus)
			//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			aVoucherDetails.Clear();
			aVoucherDetails.RedimXArray(new int[]{0, 9}, new int[]{0, 0});
			aVoucherDetails.SetValue(1, 0, 0);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);

			grdVoucherDetails.Rebind(true);
			txtCommon[conTxtActivityCode].Focus();
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}


		public void findRecord()
		{

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000135));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				grdVoucherDetails.Enabled = true;
				GetRecord(mSearchValue);
			}

		}
		public bool saveRecord()
		{
			bool result = false;
			object mReturnValue = null;
			int mActivityTypeCode = 0;
			int cnt = 0;

			string mysql = "";
			try
			{


				//''''''''''''''''''''''''''''''''''''''''''''
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Activity_Type_Cd from PROJ_Project_Activity_Types where Activity_Type_No='" + txtActivityType.Text + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Activity Type", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtActivityType.Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mActivityTypeCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " INSERT INTO PROJ_Activities(User_Cd , Activity_Type_Cd, Acty_No, L_Acty_Name, A_Acty_Name, ";
					mysql = mysql + " Freeze , User_Date_Time ";
					mysql = mysql + " )";
					mysql = mysql + " VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
					mysql = mysql + mActivityTypeCode.ToString() + ",";
					mysql = mysql + "'" + txtCommon[conTxtActivityCode].Text + "',";
					mysql = mysql + "'" + txtCommon[conTxtActivityNameEnglish].Text + "',";
					mysql = mysql + "N'" + txtCommon[conTxtActivityNameArabic].Text + "',";
					mysql = mysql + "" + ((((int) chkFreeze.CheckState) == ((int) TriState.True)) ? 1 : 0).ToString() + ",";
					mysql = mysql + "'" + DateTimeHelper.ToString(DateTime.Now) + "'";
					mysql = mysql + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mSearchValue = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));

				}
				else
				{
					mysql = " select time_stamp, Freeze from PROJ_Activities where Acty_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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
					if (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(1)))
					{
						MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}
					mysql = "UPDATE PROJ_Activities SET ";
					mysql = mysql + " Activity_Type_Cd = " + mActivityTypeCode.ToString() + ",";
					mysql = mysql + " Acty_No = '" + txtCommon[conTxtActivityCode].Text + "',";
					mysql = mysql + " L_Acty_Name ='" + txtCommon[conTxtActivityNameEnglish].Text + "',";
					mysql = mysql + " A_Acty_Name =N'" + txtCommon[conTxtActivityNameArabic].Text + "',";
					mysql = mysql + " Freeze =" + ((((int) chkFreeze.CheckState) == ((int) TriState.True)) ? 1 : 0).ToString() + ",";
					mysql = mysql + " User_Cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
					mysql = mysql + " User_Date_Time ='" + DateTimeHelper.ToString(DateTime.Now) + "'";
					mysql = mysql + " where Acty_Cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}

				//-----------------Delete Activity Tasks-----------------------
				this.grdVoucherDetails.UpdateData();

				mysql = "delete PROJ_Activity_Tasks ";
				mysql = mysql + " where ";
				mysql = mysql + " Acty_Cd = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				//-----------------Insert Activity Tasks-----------------------
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(aVoucherDetails.GetValue(cnt, mActivityValueCodeColumn)) || Convert.ToString(aVoucherDetails.GetValue(cnt, mActivityValueNameEnglishColumn)) == "")
					{
						MessageBox.Show("Invalid Activity Task", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						grdVoucherDetails.Col = mActivityValueCodeColumn;
						throw new Exception();
					}
					else
					{
						mysql = " INSERT INTO PROJ_Activity_Tasks(User_Cd, Acty_Cd, Acty_Task_No, L_Acty_Task_Name, A_Acty_Task_Name, ";
						mysql = mysql + " L_Acty_Task_Short_Name, A_Acty_Task_Short_Name, Freeze , User_Date_Time ";
						mysql = mysql + " )";
						mysql = mysql + " VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
						mysql = mysql + Conversion.Str(mSearchValue) + ", ";
						mysql = mysql + "'" + Convert.ToString(aVoucherDetails.GetValue(cnt, mActivityValueCodeColumn)) + "',";
						mysql = mysql + "'" + Convert.ToString(aVoucherDetails.GetValue(cnt, mActivityValueNameEnglishColumn)) + "',";
						mysql = mysql + "N'" + Convert.ToString(aVoucherDetails.GetValue(cnt, mActivityValueNameArabicColumn)) + "',";
						mysql = mysql + "'" + Convert.ToString(aVoucherDetails.GetValue(cnt, mActivityValueShortNameEnglishColumn)) + "',";
						mysql = mysql + "N'" + Convert.ToString(aVoucherDetails.GetValue(cnt, mActivityValueShortNameArabicColumn)) + "',";
						mysql = mysql + "0, ";
						//mysql = mysql & "" & aVoucherDetails(cnt, mActivityValueFreezeColumn) & ","
						mysql = mysql + "'" + DateTimeHelper.ToString(DateTime.Now) + "'";
						mysql = mysql + ")";
						SqlCommand TempCommand_4 = null;
						TempCommand_4 = SystemVariables.gConn.CreateCommand();
						TempCommand_4.CommandText = mysql;
						TempCommand_4.ExecuteNonQuery();
					}
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


		public void GetRecord(object pSearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting
			SqlDataReader rsLocalRec = null;
			object mReturnValue = null;
			string mysql = "";

			try
			{

				CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
				if (Object.Equals(pSearchValue, null) || Convert.IsDBNull(pSearchValue))
				{
					return;
				}

				mysql = "select * ";
				mysql = mysql + " from PROJ_Activities ";
				mysql = mysql + " where Acty_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand.ExecuteReader();
				bool rsLocalRecDidRead = rsLocalRec.Read();
				if (rsLocalRecDidRead)
				{
					mSearchValue = rsLocalRec["Acty_Cd"];
					mTimeStamp = Convert.ToString(rsLocalRec["time_stamp"]);
					txtCommon[conTxtActivityCode].Text = Convert.ToString(rsLocalRec["Acty_No"]);
					txtCommon[conTxtActivityNameEnglish].Text = Convert.ToString(rsLocalRec["L_Acty_Name"]);
					txtCommon[conTxtActivityNameArabic].Text = Convert.ToString(rsLocalRec["A_Acty_Name"]);

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Activity_Type_Cd, L_Type_Name" : "Activity_Type_Cd, A_Type_Name") + " from PROJ_Project_Activity_Types where Activity_Type_Cd = " + Convert.ToString(rsLocalRec["Activity_Type_Cd"])));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtActivityType.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtActivityTypeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));

				}
				rsLocalRec.Close();

				mysql = "select * ";
				mysql = mysql + " from PROJ_Activity_Tasks ";
				mysql = mysql + " where Acty_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);


				SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand_2.ExecuteReader();
				bool rsLocalRecDidRead2 = rsLocalRec.Read();

				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
				aVoucherDetails.RedimXArray(new int[]{0, mMaxArrayCols}, new int[]{0, 0});

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[1].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[2].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
				int cnt = 0;
				if (rsLocalRecDidRead)
				{
					do 
					{

						aVoucherDetails.RedimXArray(new int[]{cnt, mMaxArrayCols}, new int[]{0, 0});

						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["Acty_Task_No"]).Trim(), cnt, mActivityValueCodeColumn);
						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["L_Acty_Task_Name"]).Trim(), cnt, mActivityValueNameEnglishColumn); //     IIf(gPreferedLanguage = english, Trim(.Fields("l_prod_name")), Trim(.Fields("a_prod_name")))
						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["A_Acty_Task_Name"]).Trim(), cnt, mActivityValueNameArabicColumn);
						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["L_Acty_Task_Short_Name"]).Trim(), cnt, mActivityValueShortNameEnglishColumn);
						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["A_Acty_Task_Short_Name"]).Trim(), cnt, mActivityValueShortNameArabicColumn);
						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["Freeze"]).Trim(), cnt, mActivityValueFreezeColumn);
						cnt++;
					}
					while(rsLocalRec.Read());
				}
				rsLocalRec.Close();

				AssignGridLineNumbers();

				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Refresh();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
		}

		public bool deleteRecord()
		{
			bool result = false;
			string mysql = "";

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mSearchValue))
			{
				return result;
			}

			SystemVariables.gConn.BeginTransaction();
			try
			{

				mysql = "delete from PROJ_Activity_Tasks where Acty_Cd =" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mysql = "delete from PROJ_Activities where Acty_Cd =" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				return true;
			}
			catch (System.Exception excep)
			{
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
			return result;
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtActivityType" : 
					txtActivityType.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000134, "2652,2653,2654")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtActivityType.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtActivityTypeName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						txtActivityType_Leave(txtActivityType, new EventArgs());
					} 
					break;
			}
			//mTempSearchValue = FindItem(1000135)
			//If Not IsNull(mTempSearchValue) Then
			//    mSearchValue = mTempSearchValue(0)
			//    Call GetRecord(mSearchValue)
			//End If

		}


		private void txtActivityType_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtActivityType");
		}

		private void txtActivityType_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtActivityType.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Type_Name" : "A_Type_Name");
					mysql = mysql + " from PROJ_Project_Activity_Types where Activity_Type_No =" + txtActivityType.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtActivityTypeName.Text = "";
						//txtParentCostNo.SetFocus
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtActivityTypeName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtActivityTypeName.Text = "";
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
					//    txtParentCostNo.SetFocus
				}
				else
				{
					//
				}
			}
		}
	}
}