
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers;



namespace Xtreme
{
	internal partial class frmSysLdgrGroupAuthority
		: System.Windows.Forms.Form
	{

		public frmSysLdgrGroupAuthority()
{
InitializeComponent();
} 
 public  void frmSysLdgrGroupAuthority_old()
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
			this.grdUserGroups.setScrollTips(false);
		}


		private void frmSysLdgrGroupAuthority_Activated(System.Object eventSender, System.EventArgs eventArgs)
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


		private int mThisFormID = 0;
		private int mSearchValue = 0;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private bool mFirstGridFocus = false;

		private const int mldgr_name = 0;
		private const int mldgr_cd = 1;
		private const int mldgr_no = 2;
		private const int mLevel = 3;
		private const int mParentGroup = 4;
		private const int mSeq1 = 5;
		private const int mSeq2 = 6;
		private const int mSeq3 = 7;
		private const int mSeq4 = 8;
		private const int mSeq5 = 9;
		private const int mSeq6 = 10;
		private const int mSeq7 = 11;
		private const int mSeq8 = 12;
		private const int mAuthority = 13;
		private const int mAuthoritySetting = 14;

		private XArrayHelper aSettingsAuthority = null;

		private Control FirstFocusObject = null;
		private clsToolbar oThisFormToolBar = null;


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
		}


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			C1.Win.C1TrueDBGrid.C1DisplayColumn colVoucherDetails = null;

			try
			{

				//'setting form mode to add initially
				this.Top = 0;
				this.Left = 0;

				FirstFocusObject = txtGroupCode;
				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = false;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;

				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				grdUserGroups.Cols.Count = 0;

				clsFlip oFlipThisForm = null;
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
				{
					oFlipThisForm = new clsFlip();

					oFlipThisForm.SwapMe(this);
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}

		}

		private void txtGroupCode_DropButtonClick(Object Sender, EventArgs e)
		{
			SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtGroupCode");
		}


		public void FindRoutine(string pObjectName)
		{
			string mysql = "";
			int mGroupCd = 0;
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtGroupCode" : 
					txtGroupCode.Text = ""; 
					 
					//mySql = " usg.show=1 and protected = 0 " 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000020, "711", mysql)); 
					 
					break;
				default:
					 
					return;
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				if (pObjectName == "txtGroupCode")
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mGroupCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempSearchValue).GetValue(0));

					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtGroupCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtGroupCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(2));
					}

					//Call txtGroupCode_LostFocus
					//tabUserGroups.CurrTab = mGrdForms
				}
			}
		}

		private void txtGroupCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			object mTempValue = null;

			try
			{

				if (!SystemProcedure2.IsItEmpty(txtGroupCode.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name, group_cd" : "a_group_name, group_cd") + " from SM_USER_GROUPS where group_cd=" + txtGroupCode.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						lblGroupName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						lblGroupName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
						FillGrid(Convert.ToInt32(Double.Parse(txtGroupCode.Text)));
					}
				}
				else
				{
					lblGroupName.Text = "";
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
					//if the code is not found
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
					try
					{
						txtGroupCode.Focus();
					}
					catch (Exception exc)
					{
						NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
					}
				}
				else
				{
					//
				}
			}
		}


		private void FillGrid(int pGroupCd)
		{

			DataSet rsTempRec = new DataSet();
			int i = 0;

			clsHourGlass myHourGlass = new clsHourGlass();

			string mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name" : "a_group_name") + " as Name1, group_cd, group_no, 1 as level, m_group_cd ";
			mysql = mysql + " , Reporting_Sequence_ID_1 ,Reporting_Sequence_ID_2 ,Reporting_Sequence_ID_3 ,Reporting_Sequence_ID_4 ";
			mysql = mysql + " ,Reporting_Sequence_ID_5 ,Reporting_Sequence_ID_6 ,Reporting_Sequence_ID_7, 0 as reporting_sequence_id, 0 as Authority ";
			mysql = mysql + " from gl_accnt_group ";
			mysql = mysql + " union all ";
			mysql = mysql + " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name") + " as Name1, l.Ldgr_Cd, l.ldgr_no, 0 as level, l.group_cd";
			mysql = mysql + " ,Reporting_Sequence_ID_1 ,Reporting_Sequence_ID_2 ,Reporting_Sequence_ID_3 ";
			mysql = mysql + " ,Reporting_Sequence_ID_4 ,Reporting_Sequence_ID_5 ,Reporting_Sequence_ID_6 ,Reporting_Sequence_ID_7, l.reporting_sequence_id";
			mysql = mysql + " , CASE WHEN gls.Ldgr_Cd IS NULL THEN 0 ELSE 1 END AS Authority ";
			mysql = mysql + " from gl_ledger l ";
			mysql = mysql + " INNER JOIN GL_Accnt_Group AS gag on l.group_cd = gag.group_cd";
			mysql = mysql + " LEFT OUTER JOIN ";
			mysql = mysql + " (select Ldgr_Cd from GL_Ledger_Security where Group_Cd = " + pGroupCd.ToString() + ") as gls ";
			mysql = mysql + " ON l.Ldgr_Cd = gls.Ldgr_Cd ";
			mysql = mysql + " order by Reporting_Sequence_ID_1 ,Reporting_Sequence_ID_2 ,Reporting_Sequence_ID_3 ";
			mysql = mysql + " ,Reporting_Sequence_ID_4 ,Reporting_Sequence_ID_5 ,Reporting_Sequence_ID_6 ,Reporting_Sequence_ID_7, l.reporting_sequence_id";


			DataSet tempRec = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property tempRec.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			tempRec.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			tempRec.Tables.Clear();
			adap.Fill(tempRec); //, adOpenForwardOnly, adLockOptimistic


			int mtLevel = 0;
			grdUserGroups.Rows.Count = 1;
			grdUserGroups.Cols.Count = 0;
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdUserGroups.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdUserGroups.setDataSource((msdatasrc.DataSource) tempRec);

			grdUserGroups.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.Complete;
			grdUserGroups.Tree.Show(1);

			grdUserGroups.Cols[mldgr_cd].Visible = false;
			grdUserGroups.Cols[mldgr_no].Visible = false;
			grdUserGroups.Cols[mLevel].Visible = false;
			grdUserGroups.Cols[mParentGroup].Visible = false;
			grdUserGroups.Cols[mSeq1].Visible = false;
			grdUserGroups.Cols[mSeq2].Visible = false;
			grdUserGroups.Cols[mSeq3].Visible = false;
			grdUserGroups.Cols[mSeq4].Visible = false;
			grdUserGroups.Cols[mSeq5].Visible = false;
			grdUserGroups.Cols[mSeq6].Visible = false;
			grdUserGroups.Cols[mSeq7].Visible = false;
			grdUserGroups.Cols[mSeq8].Visible = false;
			grdUserGroups.Cols[mAuthority].Visible = false;
			grdUserGroups.Cols.Count = 15;
			grdUserGroups.AllowEditing = true;

			grdUserGroups.Cols[mldgr_name].WidthDisplay = 500;
			grdUserGroups[0, mldgr_name] = "L e d g e r";
			grdUserGroups[0, mAuthoritySetting] = "Authority";

			grdUserGroups.Styles.Normal.Border.Color = Color.FromArgb(0, 0, 0);
			grdUserGroups.Styles.Fixed.Border.Color = Color.FromArgb(0, 0, 0);
			grdUserGroups.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			grdUserGroups.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;

			int tempForEndVar = grdUserGroups.Rows.Count - 1;
			for (i = 1; i <= tempForEndVar; i++)
			{
				//        If grdUserGroups.TextMatrix(i, mLevel) = "1" Then
				//            .Cell(flexcpChecked, i, mAuthoritySetting) = CheckAuthority(i, mAuthoritySetting)
				//       Else
				grdUserGroups.setCellChecked((int) ((ReflectionHelper.GetPrimitiveValue<double>(grdUserGroups.getCellText(i, mAuthority)) == 1) ? C1.Win.C1FlexGrid.CheckEnum.TSChecked : C1.Win.C1FlexGrid.CheckEnum.TSUnchecked), i, mAuthoritySetting);
				//       End If
			}

			int tempForEndVar2 = grdUserGroups.Rows.Count - 1;
			for (i = 0; i <= tempForEndVar2; i++)
			{
				//UPGRADE_WARNING: (1068) grdUserGroups.Cell() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mtLevel = ReflectionHelper.GetPrimitiveValue<int>(grdUserGroups.getCellValue(i, mLevel));
				if (mtLevel != 0)
				{
					grdUserGroups.Rows[i].IsNode = true;
				}
				grdUserGroups.Rows[i].Node.Level = grdUserGroups.getCellValue(i, mParentGroup);
			}

			int tempForEndVar3 = grdUserGroups.Rows.Count - 1;
			for (i = 1; i <= tempForEndVar3; i++)
			{
				if (i == grdUserGroups.Rows.Count - 1)
				{
					grdUserGroups.Rows[i].IsNode = false;
				}
				else if (Convert.ToString(grdUserGroups[i, mldgr_cd]) != Convert.ToString(grdUserGroups[i + 1, mParentGroup]) && StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[i, mLevel])) != 1)
				{ 
					grdUserGroups.Rows[i].IsNode = false;
				}

				if (grdUserGroups.Rows[i].IsNode)
				{
					grdUserGroups.Rows[i - 1].Node.Collapsed = true;
				}
			}

		}

		public C1.Win.C1FlexGrid.CheckEnum CheckAuthority(int Row, int Col)
		{
			C1.Win.C1FlexGrid.CheckEnum result = C1.Win.C1FlexGrid.CheckEnum.None;
			int i = 0;

			result = C1.Win.C1FlexGrid.CheckEnum.TSUnchecked;

			int tempForEndVar = grdUserGroups.Rows.Count - 1;
			for (i = 1; i <= tempForEndVar; i++)
			{
				if (Convert.ToString(grdUserGroups[i, mParentGroup]) == Convert.ToString(grdUserGroups[Row, mldgr_cd]))
				{

					if (Convert.ToString(grdUserGroups[i, mLevel]) == "1")
					{
						GenerateAuthority(i, Col);
					}

				}
				else
				{
					if (ReflectionHelper.GetPrimitiveValue<double>(grdUserGroups.getCellText(i, mAuthority)) == 1)
					{
						result = C1.Win.C1FlexGrid.CheckEnum.TSChecked;
					}
				}
			}
			return result;
		}

		private void grdUserGroups_BeforeEdit(Object eventSender, C1.Win.C1FlexGrid.RowColEventArgs eventArgs)
		{
			int Row = eventArgs.Row;
			int Col = eventArgs.Col;
			bool Cancel = eventArgs.Cancel;
			try
			{

				if (Col == mAuthoritySetting)
				{
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((C1.Win.C1FlexGrid.CheckEnum) ReflectionHelper.GetPrimitiveValue<int>(grdUserGroups.getCellChecked(Row, mAuthoritySetting))) == C1.Win.C1FlexGrid.CheckEnum.TSChecked)
					{
						grdUserGroups.setCellChecked((int) C1.Win.C1FlexGrid.CheckEnum.TSChecked, Row, mAuthoritySetting);

					}
					else
					{
						grdUserGroups.setCellChecked((int) C1.Win.C1FlexGrid.CheckEnum.TSUnchecked, Row, mAuthoritySetting);

					}
					GenerateAuthority(Row, Col);

				}
			}
			finally
			{
				eventArgs.Cancel = Cancel;
			}
		}

		public object GenerateAuthority(int Row, int Col)
		{
			int i = 0;

			if (Convert.ToString(grdUserGroups[Row, mLevel]) == "1")
			{
				int tempForEndVar = grdUserGroups.Rows.Count - 1;
				for (i = 1; i <= tempForEndVar; i++)
				{
					if (Convert.ToString(grdUserGroups[i, mParentGroup]) == Convert.ToString(grdUserGroups[Row, mldgr_cd]))
					{

						grdUserGroups.setCellChecked(ReflectionHelper.GetPrimitiveValue<int>(grdUserGroups.getCellChecked(Row, mAuthoritySetting)), i, mAuthoritySetting);
						if (Convert.ToString(grdUserGroups[i, mLevel]) == "1")
						{
							GenerateAuthority(i, Col);
						}
					}
				}
			}
			return null;
		}
		public bool saveRecord()
		{
			bool result = false;
			StringBuilder mysql = new StringBuilder();
			int i = 0;
			try
			{

				if (txtGroupCode.Text != "")
				{

					SystemVariables.gConn.BeginTransaction();

					mysql = new StringBuilder(" DELETE FROM GL_Ledger_Security WHERE (Group_Cd=" + txtGroupCode.Text + ")");
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql.ToString();
					TempCommand.ExecuteNonQuery();

					int tempForEndVar = grdUserGroups.Rows.Count - 1;
					for (i = 1; i <= tempForEndVar; i++)
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((C1.Win.C1FlexGrid.CheckEnum) ReflectionHelper.GetPrimitiveValue<int>(grdUserGroups.getCellChecked(i, mAuthoritySetting))) == C1.Win.C1FlexGrid.CheckEnum.TSChecked && StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[i, mLevel])) == 0)
						{
							mysql = new StringBuilder("INSERT INTO GL_Ledger_Security ( ");
							mysql.Append(" Ldgr_cd, ");

							mysql.Append(" Group_cd, User_cd) VALUES(");
							mysql.Append(Conversion.Str(Convert.ToString(grdUserGroups[i, mldgr_cd])) + ",");
							mysql.Append(txtGroupCode.Text + ", " + SystemVariables.gLoggedInUserCode.ToString() + ")");
							SqlCommand TempCommand_2 = null;
							TempCommand_2 = SystemVariables.gConn.CreateCommand();
							TempCommand_2.CommandText = mysql.ToString();
							TempCommand_2.ExecuteNonQuery();
						}
					}

					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();
					MessageBox.Show("Records Save Successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
			}
			return result;
		}


		private bool FindLedgerCode(int pldgr_cd)
		{
			int cnt = 0;
			int tempForEndVar = grdUserGroups.Rows.Count - 1;
			for (cnt = 1; cnt <= tempForEndVar; cnt++)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdUserGroups.getCellText(cnt, mldgr_no))) == pldgr_cd)
				{
					grdUserGroups.Row = cnt;
					grdUserGroups.Col = mldgr_name;
					grdUserGroups.Tree.Show(2);
					grdUserGroups.ShowCell(cnt, mldgr_name);
					return true;
				}
			}
			return false;
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
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000115));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						if (!FindLedgerCode(Convert.ToInt32(Double.Parse(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)).Substring(Math.Max(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)).Length - (Strings.Len(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0))) - 2), 0))))))
						{
							MessageBox.Show(" Could not locate the specific Ledger!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}
					return;
				}
				if (this.ActiveControl.Name != "txtGroupCode")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
				else
				{
					//Call SystemFormKeyDown(Me, KeyCode, Shift, "txtGroupCode#" + Trim(Me.ActiveControl.Index))
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void grdUserGroups_KeyPressEdit(Object eventSender, C1.Win.C1FlexGrid.KeyPressEditEventArgs eventArgs)
		{
			int Row = eventArgs.Row;
			int Col = eventArgs.Col;
			int KeyAscii = eventArgs.KeyChar;
			if (Col == mldgr_name)
			{
				KeyAscii = 0;
			}
		}

		private void grdUserGroups_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				object mReturnValue = null;

				if (KeyAscii == ((int) Keys.F2))
				{
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000115));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						if (!FindLedgerCode(Convert.ToInt32(Double.Parse(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)).Substring(Math.Max(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)).Length - (Strings.Len(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0))) - 2), 0))))))
						{
							MessageBox.Show(" Could not locate the specific Ledger!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					return;
				}
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}
		public void AddRecord()
		{
			//Add a record

			txtGroupCode.Text = "";
			grdUserGroups.Cols.Count = 0;
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public void CloseForm()
		{
			this.Close();
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}