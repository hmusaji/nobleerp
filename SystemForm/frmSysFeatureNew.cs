
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers;




namespace Xtreme
{
	internal partial class frmSysFeatureNew
		: System.Windows.Forms.Form
	{


		
		public frmSysFeatureNew()
{
InitializeComponent();
} 
 public  void frmSysFeatureNew_old()
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
			this.grdFeature.setScrollTips(false);
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
		private object mSearchValue = null;
		private string mTimeStamp = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0; //Enum for checking the current form mode

		private bool mFormIsInitialized = false;
		private bool mAttemptToSetFocus = false;

		//'grid columns constants
		private const int colModuleName = 1;
		private const int colFeatureId = 2;
		private const int colFeatureName = 3;
		private const int colFeatureEnabled = 4;

		private const int clCompanyIDIndex = 0;
		private const int clCompanyNameIndex = 1;

		private const int ccDefaultLanguageIndex = 0;


		static readonly private Color mFixedAreaBackColor = Color.FromArgb(217, 221, 213); //&HC9D3CE
		private const int mMaxArrayCols = 5;

		DataSet rsSystemFeatures = null;


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

				FirstFocusObject = grdFeature;
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
				oThisFormToolBar.ShowFindButton = false;
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

				if (KeyCode == ((int) Keys.F2))
				{
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(55));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						if (!FindFeatureId(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0))))
						{
							MessageBox.Show(" Could not locate the specific Preference!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}
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

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmSysFeatureNew.DefInstance = null;
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
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				Application.DoEvents();
				GetRecord(mSearchValue);
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

		public void GetRecord(object pSearchValue)
		{
			DataSet rs = new DataSet();
			string mysql = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "smod.l_group_name " : "smod.a_group_name");
			mysql = mysql + " [Module Name], feature_id  " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ", sf.l_feature_Name " : ", sf.a_feature_Name ");
			mysql = mysql + " [Feature Name], enabled as [Enabled]";
			mysql = mysql + " from SM_PARAMETER sf ";
			mysql = mysql + " inner join SM_MODULES smod on smod.module_id = sf.module_id";
			mysql = mysql + " Where smod.show = 1 ";
			if (!SystemVariables.gXtremeAdminLoggedIn)
			{
				mysql = mysql + " and is_admin_type =0 ";
			}
			mysql = mysql + " order by smod.module_id ";

			grdFeature.Clear();
			grdFeature.Refresh();
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
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdFeature.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdFeature.setDataSource(null);
			grdFeature.Cols.Fixed = 1;
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdFeature.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdFeature.setDataSource((msdatasrc.DataSource) rs);
			grdFeature.Cols.Fixed = 0;
			grdFeature.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 1);
			grdFeature.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.Complete;
			grdFeature.Tree.Show(1);
			grdFeature.Cols[colFeatureId].Visible = false;
			grdFeature.Cols.Count = 5;
			grdFeature.BackColor = mFixedAreaBackColor;
			grdFeature.Cols[0].WidthDisplay = 16;
			grdFeature.Cols[colModuleName].WidthDisplay = 200;
			grdFeature.Cols[colFeatureName].WidthDisplay = 433;

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
				int tempForEndVar = grdFeature.Rows.Count - 1;
				for (cnt = 1; cnt <= tempForEndVar; cnt++)
				{
					if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
					{
						mysql = new StringBuilder("");
						mysql.Append(" update SM_PARAMETER ");
						if (ReflectionHelper.GetPrimitiveValue<double>(grdFeature.getCellChecked(cnt, colFeatureEnabled)) == 1)
						{
							mysql.Append(" set enabled = 1");
						}
						else
						{
							mysql.Append(" set enabled = 0");
						}
						mysql.Append(" where feature_id = " + Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdFeature.getCellText(cnt, colFeatureId))).ToString());
						//mysql = mysql & " and protected = 0 "
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql.ToString();
						TempCommand.ExecuteNonQuery();
					}
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;

				rsSystemFeatures = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsSystemFeatures.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsSystemFeatures.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter("select feature_name, enabled from SM_PARAMETER", SystemVariables.gConn);
				rsSystemFeatures.Tables.Clear();
				adap.Fill(rsSystemFeatures);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsSystemFeatures.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsSystemFeatures.setActiveConnection(null);

				frmSysMain.DefInstance.SetCurrentLanguage(SystemVariables.gPreferedLanguage);
				MessageBox.Show("System Features have been updated. Restart system for the new settings to take effect", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

		public void JRoutine()
		{
			grdFeature.Tree.Show(1);
		}

		public void ZRoutine()
		{
			grdFeature.Tree.Show(2);
		}

		private bool FindFeatureId(int pFeatureId)
		{
			int cnt = 0;
			int tempForEndVar = grdFeature.Rows.Count - 1;
			for (cnt = 1; cnt <= tempForEndVar; cnt++)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdFeature.getCellText(cnt, colFeatureId))) == pFeatureId)
				{
					grdFeature.Row = cnt;
					grdFeature.Col = colFeatureName;
					grdFeature.Tree.Show(2);
					grdFeature.ShowCell(cnt, colFeatureName);
					return true;
				}
			}
			return false;
		}

		private void grdFeature_StartEdit(Object eventSender, C1.Win.C1FlexGrid.RowColEventArgs eventArgs)
		{
			int Row = eventArgs.Row;
			int Col = eventArgs.Col;
			bool Cancel = eventArgs.Cancel;
			try
			{
				if (Col == colFeatureName || Col == colModuleName)
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