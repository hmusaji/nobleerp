
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers;



namespace Xtreme
{
	internal partial class frmSysUserGroups
		: System.Windows.Forms.Form
	{

		public frmSysUserGroups()
{
InitializeComponent();
} 
 public  void frmSysUserGroups_old()
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
			this._grdUserGroups_0.setScrollTips(false);
			this._grdUserGroups_1.setScrollTips(false);
			this._grdUserGroups_2.setScrollTips(false);
			this._grdUserGroups_3.setScrollTips(false);
			this._grdUserGroups_4.setScrollTips(false);
		}


		private void frmSysUserGroups_Activated(System.Object eventSender, System.EventArgs eventArgs)
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


		private int mThisFormID = 0;
		private int mSearchValue = 0;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private bool mFirstGridFocus = false;

		private const int mGrdForms = 0;
		private const int mGrdReports = 1;
		private const int mGrdMenus = 2;
		private const int mGrdVouchers = 3;
		private const int mGrdCompany = 4;

		private const int mOutLineLevel = 0;
		private const int mType = 1;
		private const int mRightID = 2;
		private const int mModuleId = 3;
		private const int mFormId = 4;
		private const int mColId = 5;
		private const int mDesc = 6;
		private const int mRightLevel = 7;


		private const string mFormsComboString = "#0;No Access|#1;Display|#4;Create|#5;Display + Create|#9;Display + Update|#3;Display + Print|#7;Display + Print + Create|#13;Display + Create + Update|#15;Display + Print + Create + Update";
		private const string mReportsComboString = "#0;No Access|#1;Display|#3;Display + Print|#9;Display + Update|#11;Display + Print + Update";
		private const string mMenusComboString = "#0;No Access|#1;Display";
		private const string mVouchersComboString = "#0;No Access|#1;Display|#4;Create|#5;Display + Create|#9;Display + Update|#3;Display + Print|#7;Display + Print + Create|#13;Display + Create + Update|#15;Display + Print + Create + Update";
		private const string mCompanyComboString = "#0;No Access|#15;Full Access";

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


		//Private Sub btnFormToolBar_Click(Index As Integer)
		//Call ToolBarButtonClick(Me, btnFormToolBar(Index).Tag)
		//End Sub

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			C1.Win.C1TrueDBGrid.C1DisplayColumn colVoucherDetails = null;
			bool mReturnValue = false;
			string mysql = "";

			try
			{

				//'setting form mode to add initially
				this.Top = 0;
				this.Left = 0;

				FirstFocusObject = txtGroupName;
				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;

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

				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("multiple_company"));

				if (mReturnValue)
				{
					tabUserGroups.set_TabEnabled(Convert.ToInt16(mGrdCompany), mReturnValue);
				}
				else
				{
					tabUserGroups.set_TabEnabled(Convert.ToInt16(mGrdCompany), false);
				}

				if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select count(*) from SM_MODULES where module_id in(2,5,6,7) and show = 1", true)) > 0)
				{
					tabUserGroups.set_TabVisible(Convert.ToInt16(mGrdVouchers), true);
				}
				else
				{
					tabUserGroups.set_TabVisible(Convert.ToInt16(mGrdVouchers), false);
				}
				int i = 0;
				for (i = mGrdForms; i <= mGrdCompany; i++)
				{
					grdUserGroups[i].SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
					grdUserGroups[i].Styles.EmptyArea.BackColor = Color.FromArgb(248, 245, 231);
					grdUserGroups[i].BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
					grdUserGroups[i].setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter, 0, 0, 0, grdUserGroups[i].Cols.Count - 1);
					grdUserGroups[i].setCellBackColor(Color.FromArgb(123, 136, 119), 0, 0, 0, grdUserGroups[i].Cols.Count - 1);
					grdUserGroups[i].setCellForeColor(Color.White, 0, 0, 0, grdUserGroups[i].Cols.Count - 1);
					grdUserGroups[i].Cols.Count = 2;
					grdUserGroups[i].Cols[0].WidthDisplay = 247;
					grdUserGroups[i].AllowEditing = true;
					grdUserGroups[i].ExtendLastCol = true;
					grdUserGroups[i].Cols.Fixed = 0;
					grdUserGroups[i].FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
					grdUserGroups[i].Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
					grdUserGroups[i].Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
					grdUserGroups[i].AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
					grdUserGroups[i].Tree.Style = VSFlex7.OutlineBarSettings.flexOutlineBarSymbolsLeaf;
					grdUserGroups[i].Rows[0].HeightDisplay = 22;
					grdUserGroups[i].Rows.Count = 1;
					//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdUserGroups.Item.FontSize was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdUserGroups[i].setFontSize(10);
					grdUserGroups[i][0, 0] = "M o d u l e";
					grdUserGroups[i][0, 1] = "R i g h t s";
					//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdUserGroups.Item.ScrollTrack was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdUserGroups[i].setScrollTrack(true);
				}


				SystemProcedure.SetLabelCaption(this);
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

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				frmSysUserGroups.DefInstance = null;
				UserAccess = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdUserGroups_AfterEdit(Object eventSender, C1.Win.C1FlexGrid.RowColEventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.grdUserGroups, eventSender);
			int Row = eventArgs.Row;
			int Col = eventArgs.Col;
			DialogResult ans = (DialogResult) 0;
			int mValue = 0;
			int mOutLine = 0;
			int mRow = 0;
			if (Col == mRightLevel && grdUserGroups[Index].Rows[Row].IsNode)
			{

				mValue = Convert.ToInt32(Double.Parse(Convert.ToString(grdUserGroups[Index][Row, Col])));
				mOutLine = Convert.ToInt32(Double.Parse(Convert.ToString(grdUserGroups[Index][Row, mOutLineLevel])));

				ans = MessageBox.Show("Changing the Subgroup will assign the same rights to all the children", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (ans == System.Windows.Forms.DialogResult.No)
				{
					return;
				}

				int tempForEndVar = grdUserGroups[Index].Rows.Count - 1;
				for (mRow = Row + 1; mRow <= tempForEndVar; mRow++)
				{
					if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[Index][mRow, mOutLineLevel])) != mOutLine)
					{
						if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[Index][mRow, mFormId])) != 100000)
						{
							grdUserGroups[Index][mRow, Col] = mValue.ToString();
						}
					}
					else
					{
						break;
					}
				}
			}
		}

		private void grdUserGroups_BeforeEdit(Object eventSender, C1.Win.C1FlexGrid.RowColEventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.grdUserGroups, eventSender);
			int Row = eventArgs.Row;
			int Col = eventArgs.Col;
			bool Cancel = eventArgs.Cancel;
			try
			{
				if (Index == mGrdMenus)
				{
					if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[Index][Row, mFormId])) == 100000)
					{
						Cancel = true;
					}
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel;
			}
		}

		private void grdUserGroups_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.grdUserGroups, eventSender);
			int r = 0;
			r = grdUserGroups[Index].Row;
			if (r > 0)
			{
				grdUserGroups[Index].Rows[r - 1].Node.Collapsed = !grdUserGroups[Index].Rows[r - 1].IsCollapsed;
			}
		}

		private void grdUserGroups_StartEdit(Object eventSender, C1.Win.C1FlexGrid.RowColEventArgs eventArgs)
		{
			int Row = eventArgs.Row;
			int Col = eventArgs.Col;
			bool Cancel = eventArgs.Cancel;
			try
			{
				if (Col == mDesc)
				{
					Cancel = true;
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel;
			}
		}

		private void txtBasicGroupName_DropButtonClick(Object Sender, EventArgs e)
		{
			SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtBasicGroupName");
		}

		public void FindRoutine(string pObjectName)
		{
			string mysql = "";
			int mGroupCd = 0;
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtBasicGroupName" : 
					txtBasicGroupName.Text = ""; 
					 
					//mySql = " usg.show=1 and protected = 0 " 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000020, "708,709", mysql)); 
					break;
				default:
					return;
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				if (pObjectName == "txtBasicGroupName")
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mGroupCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempSearchValue).GetValue(0));

					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtBasicGroupName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtBasicGroupName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(2));
					}

					FillGrid(mGrdForms, mGroupCd);
					FillGrid(mGrdReports, mGroupCd);
					FillGrid(mGrdMenus, mGroupCd);
					FillGrid(mGrdVouchers, mGroupCd);
					FillGrid(mGrdCompany, mGroupCd);
					tabUserGroups.CurrTab = Convert.ToInt16(mGrdForms);
				}
			}
		}

		public bool saveRecord()
		{

			bool result = false;
			int mNewEntryID = 0;
			object mReturnValue = null;
			//
			//'Save a record
			//'During save check for the mode
			//'If in addmode then insert a record
			//'else update the record in the recordset
			//
			//On Error GoTo eFoundError

			clsHourGlass myHourGlass = new clsHourGlass();

			SystemVariables.gConn.BeginTransaction();

			string mysql = " select group_cd from SM_USER_GROUPS where ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name='" : "a_group_name='") + txtGroupName.Text + "'";

			int cnt = 0;
			int i = 0;

			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Duplicate Group Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					txtGroupName.Focus();
					return false;
				}
				mysql = " INSERT INTO SM_USER_GROUPS (L_Group_Name, A_Group_Name, Admin, show, Protected)";
				mysql = mysql + " VALUES ('" + txtGroupName.Text + "','', 0, 1, 0)";

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
				mNewEntryID = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));

				for (cnt = mGrdForms; cnt <= mGrdCompany; cnt++)
				{
					int tempForEndVar2 = grdUserGroups[cnt].Rows.Count - 1;
					for (i = 1; i <= tempForEndVar2; i++)
					{
						if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[cnt][i, mType])) > 0)
						{
							mysql = "INSERT INTO SM_USER_GROUP_RIGHTS (Group_Cd, ";
							switch(cnt)
							{
								case mGrdForms : 
									mysql = mysql + " Form_Id, "; 
									break;
								case mGrdReports : 
									if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[cnt][i, mType])) == 2)
									{
										mysql = mysql + " Report_Id, ";
									}
									else if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[cnt][i, mType])) == 4)
									{ 
										mysql = mysql + " Report_Column_Id, ";
									} 
									break;
								case mGrdMenus : 
									mysql = mysql + " Menu_Id, "; 
									break;
								case mGrdVouchers : 
									if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[cnt][i, mType])) == 5)
									{
										mysql = mysql + " accnt_voucher_type, ";
									}
									else if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[cnt][i, mType])) == 6)
									{ 
										mysql = mysql + " Invnt_Voucher_Type, ";
									} 
									break;
								case mGrdCompany : 
									mysql = mysql + " comp_Id, locat_cd , "; 
									break;
							}
							mysql = mysql + " Right_Level) VALUES(";
							mysql = mysql + Conversion.Str(mNewEntryID) + ","; //Group_cd
							if (cnt == mGrdReports)
							{
								if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[cnt][i, mType])) == 2)
								{
									mysql = mysql + Conversion.Str(Convert.ToString(grdUserGroups[cnt][i, mFormId])) + ","; //Object ID(forms,menu,report)
								}
								else if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[cnt][i, mType])) == 4)
								{ 
									mysql = mysql + Conversion.Str(Convert.ToString(grdUserGroups[cnt][i, mColId])) + ",";
								}
							}
							else if (cnt == mGrdCompany)
							{ 
								mysql = mysql + Conversion.Str(Convert.ToString(grdUserGroups[cnt][i, mModuleId])) + ",";
								mysql = mysql + Conversion.Str(Convert.ToString(grdUserGroups[cnt][i, mFormId])) + ",";
							}
							else
							{
								mysql = mysql + Conversion.Str(Convert.ToString(grdUserGroups[cnt][i, mFormId])) + ",";
							}
							mysql = mysql + Convert.ToString(grdUserGroups[cnt][i, mRightLevel]) + ")"; //Right level
							SqlCommand TempCommand_2 = null;
							TempCommand_2 = SystemVariables.gConn.CreateCommand();
							TempCommand_2.CommandText = mysql;
							TempCommand_2.ExecuteNonQuery();
						}
					}
				}

				//Temporary provision for entering record for the field comp_id
				//mysql = " insert into SM_USER_GROUP_RIGHTS (group_cd, comp_id,right_level ) "
				//mysql = mysql & " select " & Str(mNewEntryID) & ", comp_id , 1 from SM_COMPANY "
				//gConn.Execute mysql

			}
			else
			{
				mysql = mysql + " and group_cd<>" + Conversion.Str(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Duplicate Group Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					txtGroupName.Focus();
					return false;
				}
				//changed by Moiz Hakimi
				mysql = " update SM_USER_GROUPS set L_Group_Name = '" + txtGroupName.Text + "'";
				mysql = mysql + " where group_cd = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();
				//Get the Group_cd for inserting a new record
				//    mySql = " select group_cd from SM_USER_GROUPS where "
				//    mySql = mySql & IIf(gPreferedLanguage = English, "l_group_name='", "a_group_name='") & txtGroupName.Text & "'"
				//mReturnValue = GetMasterCode(mySql)
				mReturnValue = mSearchValue;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Group ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					txtGroupName.Focus();
					return false;
				}

				for (cnt = mGrdForms; cnt <= mGrdCompany; cnt++)
				{
					int tempForEndVar4 = grdUserGroups[cnt].Rows.Count - 1;
					for (i = 1; i <= tempForEndVar4; i++)
					{
						if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[cnt][i, mRightID])) > 0)
						{
							mysql = "Update SM_USER_GROUP_RIGHTS set ";
							mysql = mysql + " right_level=" + Convert.ToString(grdUserGroups[cnt][i, mRightLevel]);
							mysql = mysql + " where right_id =" + Convert.ToString(grdUserGroups[cnt][i, mRightID]);
							SqlCommand TempCommand_4 = null;
							TempCommand_4 = SystemVariables.gConn.CreateCommand();
							TempCommand_4.CommandText = mysql;
							TempCommand_4.ExecuteNonQuery();
						}
						else if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[cnt][i, mType])) > 0)
						{ 
							mysql = "INSERT INTO SM_USER_GROUP_RIGHTS (Group_Cd,";
							switch(cnt)
							{
								case mGrdForms : 
									mysql = mysql + " Form_Id, "; 
									break;
								case mGrdReports : 
									if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[cnt][i, mType])) == 2)
									{
										mysql = mysql + " Report_Id, ";
									}
									else if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[cnt][i, mType])) == 4)
									{ 
										mysql = mysql + " Report_Column_Id, ";
									} 
									break;
								case mGrdMenus : 
									mysql = mysql + " Menu_Id, "; 
									break;
								case mGrdVouchers : 
									if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[cnt][i, mType])) == 5)
									{
										mysql = mysql + " Accnt_Voucher_Type, ";
									}
									else if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[cnt][i, mType])) == 6)
									{ 
										mysql = mysql + " Invnt_Voucher_Type, ";
									} 
									break;
								case mGrdCompany : 
									mysql = mysql + " comp_Id, locat_cd ,"; 
									break;
							}
							mysql = mysql + " Right_Level) VALUES(";
							mysql = mysql + Conversion.Str(mReturnValue) + ","; //Group_cd
							if (cnt == mGrdReports)
							{
								if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[cnt][i, mType])) == 2)
								{
									mysql = mysql + Convert.ToString(grdUserGroups[cnt][i, mFormId]) + ","; //Object ID(forms,menu,report)
								}
								else if (StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[cnt][i, mType])) == 4)
								{ 
									mysql = mysql + Convert.ToString(grdUserGroups[cnt][i, mColId]) + ",";
								}
							}
							else if (cnt == mGrdCompany)
							{ 
								mysql = mysql + Conversion.Str(Convert.ToString(grdUserGroups[cnt][i, mModuleId])) + ",";
								mysql = mysql + Conversion.Str(Convert.ToString(grdUserGroups[cnt][i, mFormId])) + ",";
							}
							else
							{
								mysql = mysql + Convert.ToString(grdUserGroups[cnt][i, mFormId]) + ",";
							}
							mysql = mysql + Convert.ToString(grdUserGroups[cnt][i, mRightLevel]) + ")"; //Right level
							SqlCommand TempCommand_5 = null;
							TempCommand_5 = SystemVariables.gConn.CreateCommand();
							TempCommand_5.CommandText = mysql;
							TempCommand_5.ExecuteNonQuery();
						}
					}
				}
			}
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

			result = true;
			FirstFocusObject.Focus();
			return result;



			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			if (mReturnErrorType == 1)
			{
				return false;
				//ElseIf mReturnErrorType = 2 Then
				//    Call AddRecord
				//    saveRecord = False
				//ElseIf mReturnErrorType = 3 Then
				//    Call AddRecord
				//    saveRecord = False
			}
			else
			{
				return false;
			}
		}

		public bool CheckDataValidity()
		{
			//Check the voucher status. if its not in active mode do not allow any updates
			//Check the voucher status. if its not in active mode do not allow any updates

			if (SystemProcedure2.IsItEmpty(txtGroupName.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter the Group Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtGroupName.Focus();
				return false;
			}

			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				if (SystemProcedure2.IsItEmpty(txtBasicGroupName.Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter the Basic Group Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtBasicGroupName.Focus();
					return false;
				}
			}

			return true;
		}

		public void AddRecord()
		{
			//Add a record

			txtGroupName.Text = "";
			lblBasicGroupName.Visible = true;

			txtBasicGroupName.Visible = true;
			txtBasicGroupName.Text = "";

			grdUserGroups[mGrdForms].Rows.Count = 1;
			grdUserGroups[mGrdReports].Rows.Count = 1;
			grdUserGroups[mGrdMenus].Rows.Count = 1;
			grdUserGroups[mGrdVouchers].Rows.Count = 1;
			tabUserGroups.CurrTab = Convert.ToInt16(mGrdForms);

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = 0; //Change the msearchvalue to blank
			FirstFocusObject.Focus();
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public void GetRecord(object pSearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting
			string mysql = "";
			object mReturnValue = null;
			try
			{

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
				if (Object.Equals(pSearchValue, null) || Convert.IsDBNull(pSearchValue))
				{
					return;
				}

				mysql = " select ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name" : "a_group_name");
				mysql = mysql + " from SM_USER_GROUPS where group_cd=" + Conversion.Str(pSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtGroupName.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				//UPGRADE_WARNING: (1068) pSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue<int>(pSearchValue);

				FillGrid(mGrdForms, mSearchValue);
				FillGrid(mGrdReports, mSearchValue);
				FillGrid(mGrdMenus, mSearchValue);
				FillGrid(mGrdVouchers, mSearchValue);
				FillGrid(mGrdCompany, mSearchValue);

				tabUserGroups.CurrTab = Convert.ToInt16(mGrdForms);

				lblBasicGroupName.Visible = false;
				txtBasicGroupName.Visible = false;

				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
		}

		public void printRecord()
		{
			//Print routine

		}

		public void findRecord()
		{

			string mysql = " usg.show=1 and protected = 0 ";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000020, "", mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}

		}

		public void CloseForm()
		{
			this.Close();
		}

		private void FillGrid(int pGrid, int pGroupCd)
		{

			string mysql = "";
			StringBuilder mTempSql = new StringBuilder();
			object mReturnValue = null;
			SqlDataReader rsTempRec = null;
			int i = 0;

			clsHourGlass myHourGlass = new clsHourGlass();

			switch(pGrid)
			{
				case mGrdForms :  //System Form 
					mysql = "Select 1 as outlineLevel, 0 as type,  0 as rightId , Module_Id as moduleId , "; 
					mysql = mysql + " 0 as Id, 0 as col_id , "; 
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name" : "a_group_name") + " as Name1,"; 
					mysql = mysql + " 0 as rightLevel From SM_MODULES Where Show = 1"; 
					mysql = mysql + " Union"; 
					mysql = mysql + " Select 0 as outlineLevel, 1 as type, "; 
					mysql = mysql + " isnull(sugr.right_id,0) as rightId , sm.Module_Id as moduleId,"; 
					mysql = mysql + " sf.Form_Id AS Id, 0 as col_id , "; 
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "sf.L_Form_Name" : "sf.a_Form_Name") + " as name1,"; 
					mysql = mysql + " case when isnull(sugr.Right_Level, 0) not in (0,1,4,5,9,3,7,13,15) then 15 else isnull(sugr.Right_Level, 0) end  As rightLevel"; 
					mysql = mysql + " From SM_FORM  sf"; 
					mysql = mysql + " INNER JOIN SM_MODULES sm  ON sf.Module_Id = sm.Module_Id"; 
					mysql = mysql + " INNER JOIN SM_Preferences sfeatures ON sf.feature_Id = sfeatures.preference_Id "; 
					mysql = mysql + " LEFT OUTER JOIN "; 
					mysql = mysql + " (select * from SM_USER_GROUP_RIGHTS where group_cd=" + Conversion.Str(pGroupCd) + ") sugr"; 
					mysql = mysql + " ON sugr.Form_Id = sf.Form_Id"; 
					mysql = mysql + " Where sf.Show = 1 and sm.show = 1"; 
					mysql = mysql + " and sfeatures.preference_value = '1' "; 
					mysql = mysql + " order by 4,5"; 
					break;
				case mGrdReports :  //System Report 
					mysql = " select 1 as outlinelevel, 0 as type, 0 as rightid , "; 
					mysql = mysql + " module_id as moduleid , 0 as id, 0 as col_id,"; 
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name" : "a_group_name ") + " as name1,"; 
					mysql = mysql + " 0 as rightlevel from SM_MODULES"; 
					mysql = mysql + " Where Show = 1"; 
					mysql = mysql + " Union"; 
					mysql = mysql + " select 2 as outlinelevel, 2 as type, isnull(sugr.right_id,0) as rightid ,"; 
					mysql = mysql + " sm.module_id as moduleid,  sr.report_id as id, 0 as col_id,"; 
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "sr.l_report_name" : "sr.a_report_name") + " as name1,"; 
					mysql = mysql + " case when isnull(sugr.right_level, 0) not in (0,1,3,9,11) then 11 else isnull(sugr.right_level, 0) end as rightlevel"; 
					mysql = mysql + " from SM_REPORTS  sr"; 
					mysql = mysql + " inner join SM_MODULES sm  on sr.module_id = sm.module_id"; 
					mysql = mysql + " inner join SM_Preferences sfeatures  on sr.feature_id = sfeatures.preference_id"; 
					mysql = mysql + " left outer join  (select * from SM_USER_GROUP_RIGHTS "; 
					mysql = mysql + " where group_cd= " + Conversion.Str(pGroupCd) + ") sugr"; 
					mysql = mysql + " on sugr.report_id = sr.report_id "; 
					mysql = mysql + " where sr.show = 1 "; 
					mysql = mysql + " and sfeatures.preference_value = '1' "; 
					mysql = mysql + " and sm.show=1"; 
					mysql = mysql + " Union"; 
					mysql = mysql + " select 0 as outlinelevel, 4 as type,  "; 
					mysql = mysql + " isnull(sugr.right_id,0) as rightid , sm.module_id as moduleid,  "; 
					mysql = mysql + " sr.report_id as id, srd.column_id as col_id, "; 
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "srd.l_field_caption" : "srd.a_field_caption") + " as name1,"; 
					mysql = mysql + " case when isnull(sugr.right_level, 0) not in (0,1,3,9,11) then 11 else isnull(sugr.right_level, 0) end as rightlevel"; 
					mysql = mysql + " from SM_REPORT_FIELDS  srd "; 
					mysql = mysql + " inner join SM_REPORTS sr  on srd.report_id = sr.report_id"; 
					mysql = mysql + " inner join SM_MODULES sm  on sr.module_id = sm.module_id"; 
					mysql = mysql + " inner join SM_Preferences sfeatures  on sr.feature_id = sfeatures.preference_id "; 
					mysql = mysql + " left outer join  "; 
					mysql = mysql + " (select * from SM_USER_GROUP_RIGHTS where group_cd=" + Conversion.Str(pGroupCd) + ") sugr"; 
					mysql = mysql + " on sugr.report_column_id = srd.column_id"; 
					mysql = mysql + " where sr.show = 1 and sm.show = 1 and srd.show = 1"; 
					mysql = mysql + " and sfeatures.preference_value = '1' "; 
					mysql = mysql + " and sm.show=1"; 
					//'''If bilingual feature is enabled then show both english and arabic 
					//''' else show only english 
					if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("is_bilingual")))
					{
						mysql = mysql + " and (srd.field_language='U' or srd.field_language='E')";
					} 
					 
					mysql = mysql + " order by 4,5,6"; 
					break;
				case mGrdMenus :  //System Menu 
					mysql = "Select 1 as outlineLevel, 0 as type, 0 as rightId , Module_Id as moduleId , "; 
					mysql = mysql + " 0 as Id, 0 as col_id , "; 
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Group_Name " : "a_Group_Name ") + " as name1,"; 
					mysql = mysql + " 0 as rightLevel From SM_MODULES Where Show = 1"; 
					mysql = mysql + " Union "; 
					mysql = mysql + " Select menu_level + 2 as outlineLevel, 3 as type, "; 
					mysql = mysql + " isnull(sugr.right_id,0) as rightId , sm.Module_Id as moduleId, "; 
					mysql = mysql + " smenu.menu_Id AS Id, 0 as col_id , "; 
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "replace(ltrim(rtrim(smenu.L_Menu_Name)),'&','')" : "replace(ltrim(rtrim(smenu.a_Menu_Name)),'&','')") + " as name1,"; 
					mysql = mysql + " case when isnull(sugr.right_level, 0) not in (0,1) then 1 else isnull(sugr.right_level, 0) end as rightlevel"; 
					mysql = mysql + " From SM_MENU  smenu"; 
					mysql = mysql + " INNER JOIN SM_MODULES sm  ON smenu.Module_Id = sm.Module_Id"; 
					mysql = mysql + " inner join SM_Preferences sfeatures  on smenu.feature_id = sfeatures.preference_id "; 
					mysql = mysql + " LEFT OUTER JOIN "; 
					mysql = mysql + " (select * from SM_USER_GROUP_RIGHTS where group_cd=" + Conversion.Str(pGroupCd) + ") sugr"; 
					mysql = mysql + " ON sugr.menu_Id = smenu.menu_Id "; 
					mysql = mysql + " Where smenu.Show = 1  and smenu.app_menu = 0 and sm.show = 1 "; 
					mysql = mysql + " and sfeatures.preference_value = '1' "; 
					mysql = mysql + " and smenu.l_menu_name<>'-' "; 
					mysql = mysql + " order by 4,5"; 
					break;
				case mGrdVouchers :  //Accounts Voucher 
					mysql = "Select 1 as outlineLevel, 0 as type,  0 as rightId , 1 as moduleId , "; 
					mysql = mysql + " 0 as Id, 0 as col_id, 'Accounts Voucher' AS Name1 , 0 as rightLevel"; 
					mysql = mysql + " From gl_accnt_voucher_types Where Show = 1"; 
					mysql = mysql + " Union"; 
					mysql = mysql + " Select 0 as outlineLevel, 5 as type, "; 
					mysql = mysql + " isnull(sugr.right_id,0) as rightId , 1 as moduleId, "; 
					mysql = mysql + " avt.voucher_type AS Id, 0 as col_id , "; 
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "avt.L_voucher_Name" : "avt.a_voucher_Name") + " as name1,"; 
					mysql = mysql + " case when isnull(sugr.right_level, 0) not in (0,1,4,5,7,9,3,13,15) then 15 else isnull(sugr.right_level, 0) end as rightlevel"; 
					mysql = mysql + " From gl_accnt_voucher_types  avt"; 
					mysql = mysql + " inner join SM_Preferences sfeatures  on avt.feature_id = sfeatures.preference_id "; 
					mysql = mysql + " left OUTER JOIN "; 
					mysql = mysql + " (select * from SM_USER_GROUP_RIGHTS where group_cd=" + Conversion.Str(pGroupCd) + ") sugr"; 
					mysql = mysql + " ON sugr.accnt_voucher_type = avt.voucher_type "; 
					mysql = mysql + " Where avt.Show = 1 "; 
					mysql = mysql + " and sfeatures.preference_value = '1' "; 
					mysql = mysql + " Union"; 
					mysql = mysql + " Select 1 as outlineLevel, 0 as type, 0 as rightId ,2 as moduleId , "; 
					mysql = mysql + " 0 as Id, 0 as col_id, 'Inventory Voucher' AS Name1 , "; 
					mysql = mysql + " 0 as rightLevel From ICS_Transaction_Types "; 
					mysql = mysql + " Where Show = 1"; 
					mysql = mysql + " Union"; 
					mysql = mysql + " Select 0 as outlineLevel, 6 as type, "; 
					mysql = mysql + " isnull(sugr.right_id,0) as rightId , 2 as moduleId, "; 
					mysql = mysql + " ivt.voucher_type AS Id, 0 as col_id , "; 
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "ivt.L_voucher_Name " : "ivt.a_voucher_Name ") + " as name1,"; 
					mysql = mysql + " case when isnull(sugr.right_level, 0) not in (0,1,4,5,7,9,3,13,15) then 15 else isnull(sugr.right_level, 0) end as rightlevel"; 
					mysql = mysql + " From ICS_Transaction_Types  ivt "; 
					mysql = mysql + " inner join SM_Preferences sfeatures  on ivt.feature_id = sfeatures.preference_id "; 
					mysql = mysql + " left OUTER JOIN "; 
					mysql = mysql + " (select * from SM_USER_GROUP_RIGHTS where group_cd=" + Conversion.Str(pGroupCd) + ") sugr"; 
					mysql = mysql + " ON sugr.invnt_voucher_type = ivt.voucher_type "; 
					mysql = mysql + " Where ivt.Show = 1"; 
					mysql = mysql + " and sfeatures.preference_value = '1' "; 
					mysql = mysql + " order by 4,5"; 
					break;
				case mGrdCompany : 
					mysql = " Select 1 as outlineLevel, 0 as type,  0 as rightId , comp_Id as moduleId "; 
					mysql = mysql + " ,  0 as Id, 0 as col_id "; 
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_comp_name" : "a_comp_name") + " as name1 "; 
					mysql = mysql + " , 0 as rightLevel "; 
					mysql = mysql + " From SM_COMPANY "; 
					mysql = mysql + " Where Show = 1 "; 
					mysql = mysql + " Union "; 
					 
					SqlCommand sqlCommand = new SqlCommand(" select comp_id, db_alias from SM_COMPANY where show = 1", SystemVariables.gConn); 
					rsTempRec = sqlCommand.ExecuteReader(); 
					rsTempRec.Read(); 
					do 
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select name from master..sysdatabases where name='" + Convert.ToString(rsTempRec["db_alias"]) + "'"));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							if (mTempSql.ToString() != "")
							{
								mTempSql.Append(" union ");
							}

							mTempSql.Append(" Select 0 as outlineLevel, 1 as type ");
							mTempSql.Append(" ,  isnull(sugr.right_id,0) as rightId ");
							mTempSql.Append(" , " + Convert.ToString(rsTempRec["comp_id"]) + " as module_id ");
							mTempSql.Append(" , locat.locat_cd as Id, 0 as col_id ");
							mTempSql.Append(" , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "locat.l_locat_Name" : "locat.a_locat_Name") + " as name1 ");
							mTempSql.Append(" , case when isnull(sugr.Right_Level, 0) not in (0,15) then 15 else isnull(sugr.Right_Level, 0) end  As rightLevel ");
							mTempSql.Append(" from SM_Location locat ");
							mTempSql.Append(" LEFT OUTER JOIN  (select * from SM_USER_GROUP_RIGHTS where group_cd=" + Conversion.Str(pGroupCd) + ") sugr ");
							mTempSql.Append(" ON sugr.locat_cd = locat.locat_cd ");
							mTempSql.Append(" and sugr.comp_id = " + Convert.ToString(rsTempRec["comp_id"]));
							mTempSql.Append(" Where locat.Show = 1 ");
						}

					}
					while(rsTempRec.Read()); 
					mysql = mysql + " " + mTempSql.ToString(); 
					mysql = mysql + " order by 4,5"; 
					rsTempRec.Close(); 
					break;
			}

			DataSet tempRec = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property tempRec.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			tempRec.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
			tempRec.Tables.Clear();
			adap_2.Fill(tempRec);

			int mLevel = 0;
			grdUserGroups[pGrid].Rows.Count = 1;
			grdUserGroups[pGrid].Cols.Count = 0;
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdUserGroups.Item.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdUserGroups[pGrid].setDataSource((msdatasrc.DataSource) tempRec);
			grdUserGroups[pGrid].Tree.Column = mDesc;
			grdUserGroups[pGrid].setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter, 0, mDesc, 0, mRightLevel);
			grdUserGroups[pGrid].setCellBackColor(Color.FromArgb(123, 136, 119), 0, mDesc, 0, mRightLevel);
			grdUserGroups[pGrid].setCellForeColor(Color.White, 0, mDesc, 0, mRightLevel);

			grdUserGroups[pGrid].Cols[mOutLineLevel].Visible = false;
			grdUserGroups[pGrid].Cols[mType].Visible = false;
			grdUserGroups[pGrid].Cols[mRightID].Visible = false;
			grdUserGroups[pGrid].Cols[mModuleId].Visible = false;
			grdUserGroups[pGrid].Cols[mFormId].Visible = false;
			grdUserGroups[pGrid].Cols[mColId].Visible = false;
			grdUserGroups[pGrid].Cols[mDesc].WidthDisplay = 247;
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdUserGroups.Item.FontSize was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdUserGroups[pGrid].setFontSize(10);
			grdUserGroups[pGrid][0, mDesc] = "M o d u l e";
			grdUserGroups[pGrid][0, mRightLevel] = "R i g h t s";

			grdUserGroups[pGrid].Styles.Normal.Border.Color = Color.FromArgb(0, 0, 0);
			grdUserGroups[pGrid].Styles.Fixed.Border.Color = Color.FromArgb(0, 0, 0);
			grdUserGroups[pGrid].Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			grdUserGroups[pGrid].Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;

			int tempForEndVar = grdUserGroups[pGrid].Rows.Count - 1;
			for (i = 0; i <= tempForEndVar; i++)
			{
				//UPGRADE_WARNING: (1068) grdUserGroups.Item().Cell() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mLevel = ReflectionHelper.GetPrimitiveValue<int>(grdUserGroups[pGrid].getCellValue(i, 0));
				if (mLevel != 0)
				{
					grdUserGroups[pGrid].Rows[i].IsNode = true;
					if (mLevel == 1)
					{
						//.Cell(flexcpBackColor, i, mDesc, i, mRightLevel) = &HBCD5B7   '&H149431  '"&HEFB1E8"
						//ElseIf mLevel = 2 Then
						//    .Cell(flexcpBackColor, i, mDesc, i, mRightLevel) = &H149431 '"&HEFB1E8"
						//ElseIf mLevel = 3 Then
						//    .Cell(flexcpBackColor, i, mDesc, i, mRightLevel) = &HEFB1E8
					}
				}
				grdUserGroups[pGrid].Rows[i].Node.Level = grdUserGroups[pGrid].getCellValue(i, 0);
			}

			int tempForEndVar2 = grdUserGroups[pGrid].Rows.Count - 1;
			for (i = 1; i <= tempForEndVar2; i++)
			{
				if (i == grdUserGroups[pGrid].Rows.Count - 1)
				{
					grdUserGroups[pGrid].Rows[i].IsNode = false;
				}
				else if (Convert.ToString(grdUserGroups[pGrid][i, mOutLineLevel]) == Convert.ToString(grdUserGroups[pGrid][i + 1, mOutLineLevel]) && StringsHelper.ToDoubleSafe(Convert.ToString(grdUserGroups[pGrid][i, mType])) != 0)
				{ 
					grdUserGroups[pGrid].Rows[i].IsNode = false;
				}

				if (grdUserGroups[pGrid].Rows[i].IsNode)
				{
					grdUserGroups[pGrid].Rows[i - 1].Node.Collapsed = true;
				}
			}


			switch(pGrid)
			{
				case mGrdForms : 
					grdUserGroups[pGrid].Cols[mRightLevel].ComboList = mFormsComboString; 
					break;
				case mGrdReports : 
					grdUserGroups[pGrid].Cols[mRightLevel].ComboList = mReportsComboString; 
					break;
				case mGrdMenus : 
					grdUserGroups[pGrid].Cols[mRightLevel].ComboList = mMenusComboString; 
					break;
				case mGrdVouchers : 
					grdUserGroups[pGrid].Cols[mRightLevel].ComboList = mVouchersComboString; 
					break;
				case mGrdCompany : 
					grdUserGroups[pGrid].Cols[mRightLevel].ComboList = mCompanyComboString; 
					break;
			}

		}

		public bool deleteRecord()
		{
			//Delete the Record
			bool result = false;
			try
			{
				object mReturnValue = null;
				string mysql = "";

				clsHourGlass myHourGlass = null;
				myHourGlass = new clsHourGlass();

				mysql = " SELECT User_Cd From SM_USERS where Group_Cd = " + mSearchValue.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					SystemVariables.gConn.BeginTransaction();
					mysql = "delete SM_USER_GROUP_RIGHTS where group_cd=" + mSearchValue.ToString();
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
					mysql = "delete SM_USER_GROUPS where group_cd=" + mSearchValue.ToString();
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();
					AddRecord();
				}
				else
				{
					MessageBox.Show("Group has been assigned to users, Record cannot be deleted", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
				}
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "deleteRecord", SystemConstants.msg10);
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

		public void XRoutine()
		{
			int i = 0;
			int mActivateGrid = tabUserGroups.CurrTab;
			int tempForEndVar = grdUserGroups[mActivateGrid].Rows.Count - 1;
			for (i = 1; i <= tempForEndVar; i++)
			{
				if (grdUserGroups[mActivateGrid].Rows[i].IsNode)
				{
					grdUserGroups[mActivateGrid].Rows[i - 1].Node.Collapsed = false;
				}
			}
		}

		public void ORoutine()
		{
			int i = 0;
			int mActivateGrid = tabUserGroups.CurrTab;
			int tempForEndVar = grdUserGroups[mActivateGrid].Rows.Count - 1;
			for (i = 1; i <= tempForEndVar; i++)
			{
				if (grdUserGroups[mActivateGrid].Rows[i].IsNode)
				{
					grdUserGroups[mActivateGrid].Rows[i - 1].Node.Collapsed = true;
				}
			}
		}
	}
}