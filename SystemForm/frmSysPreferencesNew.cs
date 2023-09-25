
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers;




namespace Xtreme
{
	internal partial class frmSysPreferencesNew
		: System.Windows.Forms.Form
	{


		
		public frmSysPreferencesNew()
{
InitializeComponent();
} 
 public  void frmSysPreferencesNew_old()
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
			
			InitExtendedProperties();
		}
		void InitExtendedProperties()
		{
			this.grdPreference.setScrollTips(false);
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
		 //This class checks for the rights given to the user
		public Control FirstFocusObject = null;

		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private int mSearchValue = 0;
		private string mTimeStamp = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0; //Enum for checking the current form mode

		private bool mFormIsInitialized = false;
		private bool mAttemptToSetFocus = false;

		//'grid columns constants
		private const int colModuleName = 1;
		private const int colPreferenceName = 2;
		private const int colPreferenceId = 3;
		private const int colPreferenceDataType = 4;
		private const int colPreferenceDataValue = 5;
		private const int colPreferenceRemarks = 6;
		private const int colPreferenceDataList = 7;
		private const int colPreferenceSetting = 8;


		private const int clCompanyIDIndex = 0;
		private const int clCompanyNameIndex = 1;

		private const int ccDefaultLanguageIndex = 0;


		static readonly private Color mFixedAreaBackColor = Color.FromArgb(220, 226, 231); //&HC9D3CE
		private const int mMaxArrayCols = 5;

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
		public int SearchValue
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


		private void cmbPreferenceDataList_Leave(Object eventSender, EventArgs eventArgs)
		{
			cmbPreferenceDataList.Visible = false;
			grdPreference.setCellText(cmbPreferenceDataList.Text, Convert.ToInt32(Double.Parse(Conversion.Str(Convert.ToString(cmbPreferenceDataList.Tag)))), colPreferenceSetting);
		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				SystemMenu.SetMeCurrentInWindowList(Conversion.Str(this.Handle.ToInt32()));
				//xfd'
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				FirstFocusObject = grdPreference;
				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = false;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = false;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.ShowCollapseAllButton = true;
				oThisFormToolBar.ShowExpandAllButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);

				//**--make the form visible before all the control gets loaded
				//**--(this way system pretends to be faster in loading forms)
				this.Show();
				Application.DoEvents();
				//**-------------------------------------------------------------------------------------------

				//**--by default get the current company preferences
				mSearchValue = SystemVariables.gCompanyID;
				GetRecord(mSearchValue);
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
				object mReturnValue = null;
				//On Keydown navigate the form by using enter key
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}

				//If KeyCode = vbKeyF2 Then
				//    mReturnValue = FindItem(1000131) ', , " comp_id = " & gCompanyID
				//    If Not IsNull(mReturnValue) Then
				//        If FindPreferenceId(CInt(mReturnValue(0))) = False Then
				//            MsgBox " Could not locate the specific Preference!", vbExclamation
				//        End If
				//    End If
				//    Exit Sub
				//End If
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

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmSysPreferencesNew.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCommon_DropButtonClick(int Index)
		{
			FindRoutine("txtCommon#" + Index.ToString().Trim());
		}
		//
		//Private Sub txtCommon_LostFocus(Index As Integer)
		//Dim mTempValue As Variant
		//Dim mySql As String
		//Dim mLinkedTextBoxIndex As Integer
		//
		//On Error GoTo eFoundError
		//
		//Select Case Index
		//    Case ctOpeningBalAccountIndex
		//        mySql = "select l_ldgr_name, a_ldgr_name, ldgr_cd from gl_ledger where ldgr_type = 'I-SA' and ldgr_no='" & Trim(txtCommon(Index).Text) & "'"
		//        mLinkedTextBoxIndex = -1
		//    Case Else
		//        Exit Sub
		//End Select
		//
		//If Not IsItEmpty(txtCommon(Index).Text, StringType) Then
		//    mTempValue = GetMasterCode(mySql)
		//    If IsNull(mTempValue) Then
		//        If mLinkedTextBoxIndex >= 0 Then
		//            txtCommonDisplay(mLinkedTextBoxIndex).Text = ""
		//        End If
		//        txtCommon(Index).Tag = ""
		//        Err.Raise -9990002
		//    Else
		//        If mLinkedTextBoxIndex >= 0 Then
		//            txtCommonDisplay(mLinkedTextBoxIndex).Text = IIf(gPreferedLanguage = English, mTempValue(0), mTempValue(1))
		//        End If
		//        txtCommon(Index).Tag = mTempValue(2)
		//    End If
		//Else
		//    If mLinkedTextBoxIndex >= 0 Then
		//        txtCommonDisplay(mLinkedTextBoxIndex).Text = ""
		//    End If
		//    txtCommon(Index).Tag = ""
		//End If
		//Exit Sub
		//
		//
		//eFoundError:
		//Dim mReturnErrorType As Integer
		//mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord", msg10)
		//If mReturnErrorType = 1 Then
		//'
		//ElseIf mReturnErrorType = 2 Then
		//'
		//ElseIf mReturnErrorType = 3 Then
		//'
		//ElseIf mReturnErrorType = 4 Then
		//    'if the code is not found
		//    On Error Resume Next
		//    txtCommon(Index).SetFocus
		//Else
		//    '
		//End If
		//End Sub

		public void findRecord()
		{

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000131));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				if (!FindPreferenceId(ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempSearchValue).GetValue(0))))
				{
					MessageBox.Show(" Could not locate the specific Preference!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		public void FindRoutine(string pObjectName)
		{

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			//mObjectName = Left(pObjectName, InStr(1, pObjectName, "#", vbTextCompare) - 1)
			//mObjectIndex = CInt(Mid(pObjectName, InStr(1, pObjectName, "#", vbTextCompare) + 1))
			//If mObjectName = "txtCommon" Then
			//'    txtCommon(mObjectIndex).Text = ""
			//    Select Case mObjectIndex
			//        Case ctOpeningBalAccountIndex
			//            mTempSearchValue = FindItem(1001000, "2", "ldgr_type = 'I-SA'")
			//        Case Else
			//            Exit Sub
			//    End Select
			//    If Not IsNull(mTempSearchValue) Then
			//        txtCommon(mObjectIndex).Text = mTempSearchValue(1)
			//        Call txtCommon_LostFocus(mObjectIndex)
			//    End If
			//    'Call ShowHideMasterDetails
			//End If
		}

		public void GetRecord(int pSearchValue)
		{
			//Dim mTempValue As Variant
			DataSet rs = new DataSet();
			int i = 0;
			string mysql = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "smod.l_group_name " : "smod.a_group_name");
			mysql = mysql + " [Module Name] " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ", spref.l_preference_Name " : ", spref.a_preference_Name ");
			mysql = mysql + " [Preference Name], preference_id, preference_data_type, preference_value, spref.comments,spref.preference_data_list ";
			mysql = mysql + " from SM_Preferences spref ";
			mysql = mysql + " inner join SM_MODULES smod on spref.module_id = smod.module_id";
			mysql = mysql + " Where smod.show = 1 ";
			if (!SystemVariables.gXtremeAdminLoggedIn)
			{
				mysql = mysql + " and is_admin_type =0 ";
			}
			mysql = mysql + " order by smod.module_id ";

			grdPreference.Clear();
			grdPreference.Refresh();
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			SqlDataAdapter TempAdapter = null;
			TempAdapter = new SqlDataAdapter();
			TempAdapter.SelectCommand = TempCommand;
			DataSet TempDataset = null;
			TempDataset = new DataSet();
			TempAdapter.Fill(TempDataset);
			rs = TempDataset;
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdPreference.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdPreference.setDataSource(null);
			grdPreference.Cols.Fixed = 1;
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdPreference.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdPreference.setDataSource((msdatasrc.DataSource) rs);
			grdPreference.Cols.Fixed = 0;
			grdPreference.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 1);
			grdPreference.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.Complete;
			grdPreference.Tree.Show(1);
			grdPreference.Cols[colPreferenceId].Visible = false;
			grdPreference.Cols[colPreferenceDataType].Visible = false;
			grdPreference.Cols[colPreferenceDataValue].Visible = false;
			grdPreference.Cols[colPreferenceRemarks].Visible = false;
			grdPreference.Cols[colPreferenceDataList].Visible = false;
			grdPreference.Cols.Count = 9;
			grdPreference.setCellText("Setting", 0, colPreferenceSetting);
			grdPreference.BackColor = mFixedAreaBackColor;
			int tempForEndVar = grdPreference.Rows.Count - 1;
			for (i = 1; i <= tempForEndVar; i++)
			{
				if (ReflectionHelper.GetPrimitiveValue<string>(grdPreference.getCellText(i, colPreferenceDataType)) == "3")
				{
					grdPreference.setCellChecked((int) ((ReflectionHelper.GetPrimitiveValue<double>(grdPreference.getCellText(i, colPreferenceDataValue)) == 0) ? C1.Win.C1FlexGrid.CheckEnum.TSUnchecked : C1.Win.C1FlexGrid.CheckEnum.TSChecked), i, colPreferenceSetting);
					grdPreference.setCellBackColor(Color.White, i, colPreferenceSetting);
				}
				else if (ReflectionHelper.GetPrimitiveValue<string>(grdPreference.getCellText(i, colPreferenceDataType)) == "")
				{ 
					grdPreference.setCellBackColor(mFixedAreaBackColor, i, colPreferenceSetting);
				}
				else
				{
					grdPreference.setCellText(ReflectionHelper.GetPrimitiveValue<string>(grdPreference.getCellText(i, colPreferenceDataValue)), i, colPreferenceSetting);
					grdPreference.setCellBackColor(Color.White, i, colPreferenceSetting);
				}
			}
			grdPreference.Cols[0].WidthDisplay = 16;
			grdPreference.Cols[colModuleName].WidthDisplay = 200;
			grdPreference.Cols[colPreferenceName].WidthDisplay = 433;
			//mySql = " select " & IIf(gPreferedLanguage = English, "l_comp_name", "a_comp_name")
			//mySql = mySql & " , sp.time_stamp "
			//mySql = mySql & " from sm_company "
			//mySql = mySql & " inner join system_preferences sp on sp.comp_id = company.comp_id "
			//mySql = mySql & " where sp.comp_id = " & mSearchValue
			//
			//
			//
			//mTempValue = GetMasterCode(mySql, True)

			//**--change the form mode to edit
			mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool CheckDataValidity()
		{

			return true;

		}

		public bool saveRecord()
		{
			bool result = false;
			StringBuilder mysql = new StringBuilder();
			clsHourGlass myHourGlass = null;
			int cnt = 0;
			bool mShowErrorMessage = false;

			try
			{

				myHourGlass = new clsHourGlass();
				mShowErrorMessage = true;

				SystemVariables.gConn.BeginTransaction();
				int tempForEndVar = grdPreference.Rows.Count - 1;
				for (cnt = 1; cnt <= tempForEndVar; cnt++)
				{
					if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
					{
						mysql = new StringBuilder("");
						mysql.Append(" update SM_Preferences ");
						if (ReflectionHelper.GetPrimitiveValue<string>(grdPreference.getCellText(cnt, colPreferenceDataType)) == "3")
						{
							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
							if (((C1.Win.C1FlexGrid.CheckEnum) ReflectionHelper.GetPrimitiveValue<int>(grdPreference.getCellChecked(cnt, colPreferenceSetting))) == C1.Win.C1FlexGrid.CheckEnum.TSChecked)
							{
								mysql.Append(" set preference_value = '1'");
							}
							else
							{
								mysql.Append(" set preference_value = '0'");
							}
						}
						else
						{
							mysql.Append(" set preference_value = '" + StringsHelper.Replace(ReflectionHelper.GetPrimitiveValue<string>(grdPreference.getCellText(cnt, colPreferenceSetting)).Trim(), "'", "''", 1, -1, CompareMethod.Binary) + "'");
						}
						mysql.Append(" where preference_id = " + Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdPreference.getCellText(cnt, colPreferenceId))).ToString());
						//mySql = mySql & " and comp_id = " & Str(mSearchValue)
						mysql.Append(" and protected = 0 ");
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql.ToString();
						TempCommand.ExecuteNonQuery();
					}
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;

				SystemVariables.rsSystemPreferences = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsSystemPreferences.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsSystemPreferences.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter("select preference_name, preference_data_type, preference_value from SM_Preferences ", SystemVariables.gConn);
				SystemVariables.rsSystemPreferences.Tables.Clear();
				adap.Fill(SystemVariables.rsSystemPreferences);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsSystemPreferences.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsSystemPreferences.setActiveConnection(null);

				MessageBox.Show("System preferences have been updated. Restart system for the new settings to take effect", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				//FirstFocusObject.SetFocus
				CloseForm();
			}
			catch (System.Exception excep)
			{


				int mReturnErrorType = 0;

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
				if (mShowErrorMessage)
				{
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				}
			}
			return result;
		}


		private void grdPreference_AfterRowColChange(Object eventSender, C1.Win.C1FlexGrid.RangeEventArgs eventArgs)
		{
			int OldRow = eventArgs.OldRange.r1;
			int OldCol = eventArgs.OldRange.c1;
			int NewRow = eventArgs.NewRange.r1;
			int NewCol = eventArgs.NewRange.c1;
			string[] mReturnValue = null;
			int i = 0;

			txtRemarks.Text = ReflectionHelper.GetPrimitiveValue<string>(grdPreference.getCellText(NewRow, colPreferenceRemarks));
			if (NewCol == colPreferenceSetting)
			{
				if (ReflectionHelper.GetPrimitiveValue<string>(grdPreference.getCellText(NewRow, colPreferenceDataList)) != "")
				{
					cmbPreferenceDataList.Visible = true;
					cmbPreferenceDataList.Items.Clear();
					mReturnValue = Strings.Split(ReflectionHelper.GetPrimitiveValue<string>(grdPreference.getCellText(NewRow, colPreferenceDataList)), ",", -1, CompareMethod.Binary);
					foreach (string mReturnValue_item in mReturnValue)
					{
						cmbPreferenceDataList.AddItem(mReturnValue_item);
					}
					cmbPreferenceDataList.Left = grdPreference.Cols[colPreferenceSetting].Left + grdPreference.ScrollPosition.X + grdPreference.Left;
					cmbPreferenceDataList.Width = grdPreference.GetCellRect(grdPreference.Row, grdPreference.Col, true).Width / 15; //.ColWidth(colPreferenceSetting)
					cmbPreferenceDataList.Top = grdPreference.Rows[NewRow].Top + grdPreference.ScrollPosition.Y + grdPreference.Top;
					cmbPreferenceDataList.Tag = grdPreference.Row.ToString();
					cmbPreferenceDataList.Text = ReflectionHelper.GetPrimitiveValue<string>(grdPreference.getCellText(NewRow, NewCol));
					cmbPreferenceDataList.Focus();
					//cmbPreferenceDataList.Height = .RowHeight(NewRow)
					return;
				}
			}
			cmbPreferenceDataList.Visible = false;
		}

		private void grdPreference_AfterScroll(Object eventSender, C1.Win.C1FlexGrid.RangeEventArgs eventArgs)
		{
			int OldTopRow = eventArgs.OldRange.r1;
			int OldLeftCol = eventArgs.OldRange.c1;
			int NewTopRow = eventArgs.NewRange.r1;
			int NewLeftCol = eventArgs.NewRange.c1;

			if (cmbPreferenceDataList.Visible)
			{
				if ((grdPreference.Rows[Convert.ToInt32(Double.Parse(Conversion.Str(Convert.ToString(cmbPreferenceDataList.Tag))))].Top + grdPreference.ScrollPosition.Y) * 15 < 100 || (grdPreference.Rows[Convert.ToInt32(Double.Parse(Conversion.Str(Convert.ToString(cmbPreferenceDataList.Tag))))].Top + grdPreference.ScrollPosition.Y) * 15 > grdPreference.Height * 15 - 100)
				{
					cmbPreferenceDataList.Visible = false;
				}
				cmbPreferenceDataList.Top = grdPreference.Rows[Convert.ToInt32(Double.Parse(Conversion.Str(Convert.ToString(cmbPreferenceDataList.Tag))))].Top + grdPreference.ScrollPosition.Y + grdPreference.Top;
			}
		}

		private void grdPreference_BeforeEdit(Object eventSender, C1.Win.C1FlexGrid.RowColEventArgs eventArgs)
		{
			int Row = eventArgs.Row;
			int Col = eventArgs.Col;
			bool Cancel = eventArgs.Cancel;
			try
			{
				if (ReflectionHelper.GetPrimitiveValue<string>(grdPreference.getCellText(Row, colPreferenceDataType)) == "3")
				{
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((C1.Win.C1FlexGrid.CheckEnum) ReflectionHelper.GetPrimitiveValue<int>(grdPreference.getCellChecked(Row, colPreferenceSetting))) == C1.Win.C1FlexGrid.CheckEnum.TSChecked)
					{
						grdPreference.setCellChecked((int) C1.Win.C1FlexGrid.CheckEnum.TSChecked, Row, colPreferenceSetting);
					}
					else
					{
						grdPreference.setCellChecked((int) C1.Win.C1FlexGrid.CheckEnum.TSUnchecked, Row, colPreferenceSetting);
					}
					//If grdPreference.Cell(flexcpChecked, Row, Col) = flexTSGrayed Then
					//    grdPreference.Cell(flexcpChecked, Row, Col) = flexTSChecked
					//End If
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel;
			}
		}

		private void grdPreference_BeforeResizeColumn(Object eventSender, C1.Win.C1FlexGrid.RowColEventArgs eventArgs)
		{
			int Row = eventArgs.Row;
			int Col = eventArgs.Col;
			bool Cancel = eventArgs.Cancel;
			//cmbPreferenceDataList.Width = grdPreference.ColWidth(colPreferenceSetting)
			//cmbPreferenceDataList.Left = grdPreference.ColPos(colPreferenceSetting)
			eventArgs.Cancel = Cancel;
		}

		private void grdPreference_KeyPressEdit(Object eventSender, C1.Win.C1FlexGrid.KeyPressEditEventArgs eventArgs)
		{
			int Row = eventArgs.Row;
			int Col = eventArgs.Col;
			int KeyAscii = eventArgs.KeyChar;
			if (ReflectionHelper.GetPrimitiveValue<string>(grdPreference.getCellText(Row, colPreferenceDataType)) != "" && Col == colPreferenceSetting)
			{
				return;
			}
			KeyAscii = 0;
		}

		public void JRoutine()
		{
			grdPreference.Tree.Show(1);
		}

		public void ZRoutine()
		{
			grdPreference.Tree.Show(2);
		}

		private bool FindPreferenceId(int pPreferenceId)
		{
			int cnt = 0;
			int tempForEndVar = grdPreference.Rows.Count - 1;
			for (cnt = 1; cnt <= tempForEndVar; cnt++)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdPreference.getCellText(cnt, colPreferenceId))) == pPreferenceId)
				{
					grdPreference.Row = cnt;
					grdPreference.Col = colPreferenceName;
					grdPreference.Tree.Show(2);
					grdPreference.ShowCell(cnt, colPreferenceName);
					return true;
				}
			}
			return false;
		}

		private void grdPreference_StartEdit(Object eventSender, C1.Win.C1FlexGrid.RowColEventArgs eventArgs)
		{
			int Row = eventArgs.Row;
			int Col = eventArgs.Col;
			bool Cancel = eventArgs.Cancel;
			try
			{
				if (Col == colPreferenceName || Col == colModuleName)
				{
					Cancel = true;
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel;
			}
		}
	}
}