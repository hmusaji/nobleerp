
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers;




namespace Xtreme
{
	internal partial class frmSysFindDesign
		: System.Windows.Forms.Form
	{


		private int mFindID = 0;
		private string mReturnColumnIDList = "";
		private string mCustomWhereClause = "";
		private bool mUseDefaultWhereClause = false;
		private bool mApplySpecialFormating = false;
		private string mCustomFromClause = "";
		private bool mEnableColumnCustomize = false;
		private object mReturnColumnValues = null;
		private DataSet rsReportData = null;
		private DataSet rsMasterRecordset = null;
		private DataSet rsDetailsRecordset = null;
		private bool mReportSettingsChanged = false;
		private bool mReportIsFormated = false;
		private bool mStructureIsCreated = false;
		private bool mUseColumnScroll = false;
		private bool mResizeInProgress = false;
		private bool mShowAllRecords = false;
		private string mAdditionalFromClause = "";
		private bool mUseDefaultColorScheme = false;
		private string mFindDataSourceSelectSQL = "";
		private string mFindDataSourceWhereSQL = "";
		private string mFindDataSourceGroupBySQL = "";
		private string mFindDataSourceOrderBySQL = "";

		private clsToolbar oThisFormToolBar = null;
		//--whether to allow or disallow user to add / open find master
		public bool mRestrictAccessToMasterFromFind = false;

		private const int mButtonSeek = 0;
		private const int mButtonNew = 1;
		private const int mButtonOpen = 2;
		private const int mButtonCustomize = 3;
		private const int mButtonCancel = 4;
		private const int mButtonHelp = 5;
		private const int mButtonSave = 6;

		private const int cbSubstringSearch = 0;
		private const int cbShowAllRecords = 1;

		private Color mFixedHeaderBackColor = System.Drawing.Color.Black;
		private Color mFixedGridBackColor = System.Drawing.Color.Black;
		private int mFilterBackColor = 0;
		private int mResultGridHighlightColor = 0;

		private int mResultGridHeight = 0;
		private const int mCriteriaGridHeight = 300;

		private const int mFixedRow = 0;
		private const string mColumnPrefix = "Column";

		public XtremeCommandBars.StatusBar UCStatusBar = null;
		public frmSysFindDesign()
{
InitializeComponent();
} 
 public  void frmSysFindDesign_old()
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
			
			InitExtendedProperties();
		}
		void InitExtendedProperties()
		{
			this.grdRecordsCriteria.setScrollTips(false);
			this.grdFindResult.setScrollTips(false);
		}



		public void SetFindParameters(int pFindID, string pReturnColumnIDList, string pCustomWhereClause, bool pUseDefaultWhereClause, bool pApplySpecialFormating, string pCustomFromClause, bool pEnableColumnCustomize, bool pRestrictAccessToMasterFromFind, bool pShowAllRecords, string pAdditionalFromClause)
		{
			mFindID = pFindID;
			mReturnColumnIDList = pReturnColumnIDList;
			mCustomWhereClause = pCustomWhereClause;
			mUseDefaultWhereClause = pUseDefaultWhereClause;
			mApplySpecialFormating = pApplySpecialFormating;
			mCustomFromClause = pCustomFromClause;
			mEnableColumnCustomize = pEnableColumnCustomize;
			mRestrictAccessToMasterFromFind = pRestrictAccessToMasterFromFind;
			mShowAllRecords = pShowAllRecords;
			mAdditionalFromClause = pAdditionalFromClause;
		}

		public object GetColumnReturnValues
		{
			get
			{
				return mReturnColumnValues;
			}
		}




		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//Call FormatFormAppearence
				FormatResultGrid();
				FormatCriteriaGrid();
				oThisFormToolBar = new clsToolbar();

				oThisFormToolBar.AttachObject(this, tcbSystemForm);

				oThisFormToolBar.ShowSelectButton = true;
				oThisFormToolBar.ShowColumnsButton = true;
				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				// To disable save option for non-administative user
				if (SystemVariables.gLoggedInUserCode != SystemConstants.gDefaultAdminUserCode)
				{
					oThisFormToolBar.DisableSaveButton = true;
				}

				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;
				oThisFormToolBar.DefineToolBar();

				//**--check whether to allow column customization
				oThisFormToolBar.DisableColumnsButton = mEnableColumnCustomize;

				CreateStatusBar();
				//btnReportOptions(mButtonCustomize).Enabled = mEnableColumnCustomize

				//'With lblFindResult
				//'    .left = grdFindResult.left + 80
				//'    .top = 700
				//'End With
				lblRecordsCriteria.Left = grdRecordsCriteria.Left + 5;
				lblRecordsCriteria.Top = grdRecordsCriteria.Top - 19;
				lblTips1.Top = grdFindResult.Top - 20;
				lblTips1.Left = grdFindResult.Left + 307;

				chkCommonSettings[cbShowAllRecords].Top = grdRecordsCriteria.Top - 17;
				chkCommonSettings[cbShowAllRecords].Left = lblRecordsCriteria.Left + 300;
				chkCommonSettings[cbSubstringSearch].Top = grdRecordsCriteria.Top - 17;
				chkCommonSettings[cbSubstringSearch].Left = lblRecordsCriteria.Left + 443;

				//txtCriteriaBox.BackColor = mFilterBackColor

				rsReportData = new DataSet();
				rsMasterRecordset = new DataSet();
				rsDetailsRecordset = new DataSet();

				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsMasterRecordset.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsMasterRecordset.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsDetailsRecordset.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsDetailsRecordset.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsReportData.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsReportData.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsReportData.Properties was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Properties property rsReportData.Properties.Item was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Property property rsReportData.Properties.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsReportData.getProperties().Item("Initial Fetch Size").setValue(15);

				mReportSettingsChanged = true;
				GetReportData();

				//**--check if the sub string search should be enabled by default
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["sub_string_search_by_default"])) == TriState.True)
				{
					chkCommonSettings[cbSubstringSearch].CheckState = CheckState.Checked;
				}
				//**------------------------------------------------------------------------

				chkCommonSettings[cbShowAllRecords].CheckState = (mShowAllRecords) ? CheckState.Checked : CheckState.Unchecked;
				if (mShowAllRecords)
				{
					chkCommonSettings[cbShowAllRecords].Visible = false;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				this.Text = Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsMasterRecordset.Tables[0].Rows[0]["l_find_name"] : rsMasterRecordset.Tables[0].Rows[0]["a_find_name"]);

				Control ObjCaption = null;
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic)
				{
					//UPGRADE_WARNING: (2065) Form property frmSysFindDesign.Controls has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
					foreach (Control ObjCaptionIterator in ContainerHelper.Controls(this))
					{
						ObjCaption = ObjCaptionIterator;
						if (ObjCaption.Name == "btnReportOptions")
						{
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsSystemLables.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.rsSystemLables.MoveFirst();
							SystemVariables.rsSystemLables.Find("english_name = '" + StringsHelper.Replace(ObjCaption.Text, "&", "", 1, -1, CompareMethod.Binary) + "'");
							if (SystemVariables.rsSystemLables.Tables[0].Rows.Count != 0)
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								ObjCaption.Text = Convert.ToString(SystemVariables.rsSystemLables.Tables[0].Rows[0]["arabic_name"]);
							}
						}
						ObjCaption = default(Control);
					}
				}
				//**--check whether new / open record shuld be allowed from the search
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				oThisFormToolBar.DisableNewButton = !(((TriState) Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["allow_new"])) == TriState.True && !mRestrictAccessToMasterFromFind);
				//    If rsMasterRecordset("allow_open").Value = vbTrue And mRestrictAccessToMasterFromFind = False Then
				//        btnReportOptions(mButtonOpen).Enabled = True
				//    Else
				//        btnReportOptions(mButtonOpen).Enabled = False
				//    End If
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}


		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					if (!mReportSettingsChanged)
					{
						//**--set the current focus to the first row & first column of the criteria section
						if (grdRecordsCriteria.Rows.Count > grdRecordsCriteria.Rows.Fixed && grdRecordsCriteria.Cols.Count > 0)
						{
							grdRecordsCriteria.Row = 0;
							grdRecordsCriteria.Col = 0;
							grdRecordsCriteria.Focus();
						}
					}
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					if (KeyCode == ((int) Keys.Escape))
					{
						btnReportOptions_Click(btnReportOptions[mButtonCancel], new EventArgs());
					}
					else if (KeyCode == ((int) Keys.Tab))
					{ 
						if (this.ActiveControl.Name == "txtCriteriaBox")
						{
							txtCriteriaBox_KeyDown(txtCriteriaBox, new KeyEventArgs((Keys) (((int) Keys.Tab) + 0 * 65536)));
						}
					}
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				fraOuterShadow.Width = this.Width - 17;
				grdFindResult.Width = fraOuterShadow.Width - 7;
				grdRecordsCriteria.Width = fraOuterShadow.Width - 7;

				fraOuterShadow.Height = this.Height - 89;
				mResultGridHeight = fraOuterShadow.Height * 15 - 905;
				grdFindResult.Height = mResultGridHeight / 15;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				InteractionHelper.SaveSettingRegistryKey("Innova", "Settings", "FindWindowWidth", (this.Width * 15).ToString());
				InteractionHelper.SaveSettingRegistryKey("Innova", "Settings", "FindWindowHeight", (this.Height * 15).ToString());

				rsReportData = null;
				rsMasterRecordset = null;
				rsDetailsRecordset = null;
				frmSysFindDesign.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void chkCommonSettings_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chkCommonSettings, eventSender);
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (mReportIsFormated)
				{
					if (Index == cbSubstringSearch)
					{
						txtCriteriaBox_TextChanged(txtCriteriaBox, new EventArgs());
					}
					else if (Index == cbShowAllRecords)
					{ 
						if (chkCommonSettings[Index].CheckState == CheckState.Checked)
						{
							chkCommonSettings[Index].Enabled = false;
							mShowAllRecords = true;
							GetReportData();
						}
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void GetReportData(string pReportSourceSQL = "")
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsReportData.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (rsReportData.getState() == ConnectionState.Open)
				{
				}

				if (!mStructureIsCreated)
				{
					GetReportStructure();
					mStructureIsCreated = true;
				}

				GetReportDataSource(pReportSourceSQL);
				grdFindResult.Rows.Count = grdFindResult.Rows.Fixed;
				grdFindResult.Cols.Count = 0;
				grdFindResult.Clear(C1.Win.C1FlexGrid.ClearFlags.All, grdFindResult.GetCellRange(grdFindResult.BottomRow, grdFindResult.LeftCol, grdFindResult.TopRow, grdFindResult.RightCol));
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdFindResult.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdFindResult.setDataSource(null);
				Application.DoEvents();
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdFindResult.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdFindResult.setDataSource((msdatasrc.DataSource) rsReportData);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void GetReportStructure()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				//** open the master record definition
				string mysql = " select * from SM_FIND where find_id = " + Conversion.Str(mFindID);
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsMasterRecordset.Tables.Clear();
				adap.Fill(rsMasterRecordset);

				//'** open the find details record definition
				mysql = " select * from SM_FIND_DETAILS where find_id = " + Conversion.Str(mFindID);
				mysql = mysql + " and ((show = 1 or protected = 1) ";
				mysql = mysql + " and (lower(field_language) = lower('U') or ";
				mysql = mysql + " lower(field_language) = lower('" + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "E" : "A") + "'))) ";

				SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsDetailsRecordset.Tables.Clear();
				adap_2.Fill(rsDetailsRecordset);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsDetailsRecordset.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsDetailsRecordset.setActiveConnection(null);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!mShowAllRecords && Convert.ToBoolean(rsMasterRecordset.Tables[0].Rows[0]["Show_All_Records"]))
				{
					mShowAllRecords = true;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void GetReportDataSource(string pReportSourceSQL = "")
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				StringBuilder mColumnsClause = new StringBuilder();
				string mWhereClause = "";
				StringBuilder mGroupByClause = new StringBuilder();
				string mOrderByClause = "";
				string mysql = "";
				string[] mFromClauseTables = null;
				int mCountTables = 0;
				string mFormatedFromClause = "";

				if (pReportSourceSQL == "")
				{
					//**--setting find where clause
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mWhereClause = Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["where_clause"]) + "";
					if (mWhereClause.Trim() != "" && mUseDefaultWhereClause)
					{
						if (mCustomWhereClause != "")
						{
							mWhereClause = mWhereClause + " and " + mCustomWhereClause;
						}
					}
					else
					{
						mWhereClause = mCustomWhereClause;
					}
					//**--------------------------------------------------------------------------------
					mColumnsClause = new StringBuilder("");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mOrderByClause = Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["order_by_clause"]) + "";
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsDetailsRecordset.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.setSort("show_detail desc, column_no asc");
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.MoveFirst();
					foreach (DataRow iteration_row in rsDetailsRecordset.Tables[0].Rows)
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(iteration_row["protected"])) == TriState.True || ((TriState) Convert.ToInt32(iteration_row["show_detail"])) == TriState.True)
						{
							//make report column clause
							if (mColumnsClause.ToString() != "")
							{
								mColumnsClause.Append(", ");
							}
							if (SystemProcedure2.IsItEmpty(iteration_row["table_id"], SystemVariables.DataType.StringType))
							{
								if (SystemVariables.gApplicationInitialized)
								{
									//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
									if ((((TriState) Convert.ToInt32(iteration_row["is_ldgr_no_column"])) == TriState.True && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no"))) == TriState.False) || (((TriState) Convert.ToInt32(iteration_row["is_part_no_column"])) == TriState.True && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_part_no"))) == TriState.False))
									{
										mColumnsClause.Append("cast(" + Convert.ToString(iteration_row["field_id"]).Trim() + " as bigint)" + "");
									}
									else
									{
										mColumnsClause.Append(Convert.ToString(iteration_row["field_id"]).Trim());
									}
								}
								else
								{
									mColumnsClause.Append(Convert.ToString(iteration_row["field_id"]).Trim());
								}
							}
							else
							{
								if (SystemVariables.gApplicationInitialized)
								{
									//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
									if ((((TriState) Convert.ToInt32(iteration_row["is_ldgr_no_column"])) == TriState.True && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no"))) == TriState.False) || (((TriState) Convert.ToInt32(iteration_row["is_part_no_column"])) == TriState.True && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_part_no"))) == TriState.False))
									{
										mColumnsClause.Append("cast(" + Convert.ToString(iteration_row["table_id"]).Trim() + "." + Convert.ToString(iteration_row["field_id"]).Trim() + " as bigint)" + "");
									}
									else
									{
										mColumnsClause.Append(Convert.ToString(iteration_row["table_id"]).Trim() + "." + Convert.ToString(iteration_row["field_id"]).Trim());
									}
								}
								else
								{
									mColumnsClause.Append(Convert.ToString(iteration_row["table_id"]).Trim() + "." + Convert.ToString(iteration_row["field_id"]).Trim());
								}
							}
							mColumnsClause.Append(" as " + mColumnPrefix + Conversion.Str(iteration_row["column_id"]).Trim());
							//**------------------------------------------------------------------------------------------------
							//make report where clause
							if (!SystemProcedure2.IsItEmpty(iteration_row["filter_condition"], SystemVariables.DataType.StringType))
							{
								if (!SystemProcedure2.IsItEmpty(mWhereClause, SystemVariables.DataType.StringType))
								{
									mWhereClause = mWhereClause + " and " + Convert.ToString(iteration_row["filter_condition"]);
								}
								else
								{
									mWhereClause = Convert.ToString(iteration_row["filter_condition"]);
								}
							}
							//**------------------------------------------------------------------------------------------------
							//make report group by clause
							if (!SystemProcedure2.IsItEmpty(iteration_row["group_by_field_id"], SystemVariables.DataType.StringType))
							{
								if (mGroupByClause.ToString() != "")
								{
									mGroupByClause.Append(", ");
								}
								mGroupByClause.Append(Convert.ToString(iteration_row["group_by_field_id"]).Trim());
							}
							//**------------------------------------------------------------------------------------------------
						}
					}

					if (mColumnsClause.ToString() != "")
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["use_distinct_records"])) == TriState.True)
						{
							mFindDataSourceSelectSQL = "select distinct " + mColumnsClause.ToString();
						}
						else
						{
							mFindDataSourceSelectSQL = "select " + mColumnsClause.ToString();
						}
						//**--building custom from clause
						mFindDataSourceSelectSQL = mFindDataSourceSelectSQL + " from ";
						if (mCustomFromClause == "")
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mFindDataSourceSelectSQL = mFindDataSourceSelectSQL + Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["from_clause"]);
						}
						else
						{
							mFromClauseTables = mCustomFromClause.Split(',');
							int tempForEndVar = mFromClauseTables.GetUpperBound(0);
							for (mCountTables = 0; mCountTables <= tempForEndVar; mCountTables++)
							{
								//rsMasterRecordset("from_clause").Value
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mFormatedFromClause = StringsHelper.Replace(Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["from_clause"]), "@" + Conversion.Str(mCountTables).Trim(), mFromClauseTables[mCountTables], 1, -1, CompareMethod.Binary);
							}
							mFindDataSourceSelectSQL = mFindDataSourceSelectSQL + mFormatedFromClause;
						}

						//'' This code for ledger security ------ Moiz Hakimi----27-Oct-2008-----------------------------------------
						//If mAdditionalFromClause <> "" And GetSystemPreferenceSetting("enable_Security_on_Ledger") = True Then
						mFindDataSourceSelectSQL = mFindDataSourceSelectSQL + " " + mAdditionalFromClause;
						//End If
						//-----------------------------------------------------------------------------------------------------------

						mysql = mFindDataSourceSelectSQL;

						if (mWhereClause.Trim() != "")
						{
							mFindDataSourceWhereSQL = " where " + mWhereClause;
							mysql = mysql + mFindDataSourceWhereSQL;
							if (!ShowAllRecords())
							{
								mysql = mysql + " and 1 = 2 ";
							}
						}
						else
						{
							if (!ShowAllRecords())
							{
								mysql = mysql + " where 1 = 2 ";
							}
							mFindDataSourceWhereSQL = "";
						}

						//'' This code to filter ledger code for security ------ Moiz Hakimi----27-Oct-2008--------------------------
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsSystemPreferences.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						if (SystemVariables.rsSystemPreferences.getState() == ConnectionState.Open)
						{
							if (mAdditionalFromClause != "" && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
							{
								mysql = mysql + " and gls.Group_Cd = " + SystemVariables.gLoggedInUserGroupCode.ToString() + " and gls.Show = 1";
							}
						}
						//-----------------------------------------------------------------------------------------------------------

						if (mGroupByClause.ToString() != "")
						{
							mFindDataSourceGroupBySQL = " group by " + mGroupByClause.ToString();
							mysql = mysql + mFindDataSourceGroupBySQL;
						}

						if (mOrderByClause != "")
						{
							mFindDataSourceOrderBySQL = " order by " + mOrderByClause;
							mysql = mysql + mFindDataSourceOrderBySQL;
						}
						else
						{
							mFindDataSourceOrderBySQL = " order by 1 ";
							mysql = mysql + mFindDataSourceOrderBySQL;
						}

						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsReportData.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						if (rsReportData.getState() == ConnectionState.Open)
						{
						}
						SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
						rsReportData.Tables.Clear();
						adap.Fill(rsReportData);
					}
				}
				else
				{
					SqlDataAdapter adap_2 = new SqlDataAdapter(pReportSourceSQL, SystemVariables.gConn);
					rsReportData.Tables.Clear();
					adap_2.Fill(rsReportData);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void FormatResultGrid()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int mSystemFindWindowWidthSize = 0;

				this.Width = Convert.ToInt32(Double.Parse(InteractionHelper.GetSettingRegistryKey("Innova", "Settings", "FindWindowWidth", "8820"))) / 15;
				this.Height = Convert.ToInt32(Double.Parse(InteractionHelper.GetSettingRegistryKey("Innova", "Settings", "FindWindowHeight", "6090"))) / 15;

				fraOuterShadow.Width = this.Width - 17;

				//If rsSystemPreferences.State = adStateOpen Then
				//    If GetSystemPreferenceSetting("system_find_window_width_size") <> 0 Then
				//        fraOuterShadow.Width = GetSystemPreferenceSetting("system_find_window_width_size")
				//        Me.Width = fraOuterShadow.Width + 250
				//    End If
				//End If

				grdFindResult.Rows.Count = 1;
				grdFindResult.Cols.Count = 0;
				grdFindResult.Clear(C1.Win.C1FlexGrid.ClearFlags.All, grdFindResult.GetCellRange(grdFindResult.BottomRow, grdFindResult.LeftCol, grdFindResult.TopRow, grdFindResult.RightCol));
				//**------------------------
				//.BackColorSel = mResultGridHighlightColor
				grdFindResult.Styles.Highlight.ForeColor = Color.Black;
				//**------------------------
				grdFindResult.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
				grdFindResult.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
				grdFindResult.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
				//UPGRADE_ISSUE: (2064) VSFlex8L.AppearanceSettings property AppearanceSettings.flexXPThemes was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdFindResult.BorderStyle = UpgradeStubs.C1_Win_C1FlexGrid_Util_BaseControls_BorderStyleEnum.getflexXPThemes();
				grdFindResult.AutoResize = false;
				grdFindResult.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
				grdFindResult.AutoSearchDelay = 5;
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdFindResult.AutoSizeMouse was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdFindResult.setAutoSizeMouse(true);
				grdFindResult.BackColor = Color.FromArgb(255, 255, 255);
				grdFindResult.Styles.Alternate.BackColor = Color.FromArgb(244, 245, 241); //mFilterBackColor

				//.BackColorBkg = mFixedGridBackColor
				grdFindResult.Styles.Fixed.BackColor = Color.FromArgb(220, 226, 231);
				//.BackColorFrozen = RGB(255, 255, 255)
				grdFindResult.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
				grdFindResult.AllowEditing = false;
				grdFindResult.ExtendLastCol = true;
				grdFindResult.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
				grdFindResult.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
				//UPGRADE_ISSUE: (2064) VSFlex8L.FillStyleSettings property FillStyleSettings.flexFillSingle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdFindResult.FillStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdFindResult.setFillStyle(UpgradeStubs.VSFlex8L_FillStyleSettings.getflexFillSingle());
				grdFindResult.Cols.Fixed = 0;
				grdFindResult.Rows.Fixed = 1;
				grdFindResult.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
				//.ForeColor = RGB(0, 0, 0)
				//.ForeColorFixed = RGB(0, 0, 0)
				//.ForeColorFrozen = RGB(0, 0, 0)

				//''modified by Moiz Hakimi28-dec-2006
				//''increase the font size when arabic
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic)
				{
					//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdFindResult.FontSize was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdFindResult.setFontSize(12);
				}
				else
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsSystemPreferences.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					if (SystemVariables.rsSystemPreferences.getState() == ConnectionState.Open)
					{
						//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdFindResult.FontSize was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						grdFindResult.setFontSize(ReflectionHelper.GetPrimitiveValue<float>(SystemProcedure2.GetSystemPreferenceSetting("system_find_window_font_size")));
					}
				}

				grdFindResult.Styles.Normal.Border.Color = Color.FromArgb(0, 0, 0);
				grdFindResult.Styles.Fixed.Border.Color = Color.FromArgb(0, 0, 0);
				grdFindResult.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
				grdFindResult.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
				grdFindResult.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
				grdFindResult.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
				grdFindResult.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
				grdFindResult.Height = mResultGridHeight / 15;
				grdFindResult.Left = fraOuterShadow.Left + 1;
				grdFindResult.Rows.MinSize = 17;
				grdFindResult.ScrollBars = ScrollBars.Both;
				grdFindResult.setScrollTips(false);
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdFindResult.ScrollTrack was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdFindResult.setScrollTrack(true);
				grdFindResult.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
				grdFindResult.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = Color.FromArgb(0, 0, 0);
				grdFindResult.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
				grdFindResult.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
				grdFindResult.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
				grdFindResult.Top = (fraOuterShadow.Top + fraOuterShadow.Height) - mResultGridHeight / 15;
				grdFindResult.Width = fraOuterShadow.Width - 1;
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdFindResult.FontName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdFindResult.setFontName(SystemConstants.gEnglishFontName);
					grdFindResult.RightToLeft = RightToLeft.No;
				}
				else
				{
					//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdFindResult.FontName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdFindResult.setFontName(SystemConstants.gArabicFontName);
					grdFindResult.RightToLeft = RightToLeft.Yes;
				}
				grdFindResult.Rows[0].HeightDisplay = 20;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void FormatCriteriaGrid()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				grdRecordsCriteria.setRedraw(UpgradeHelpers.VSFlexGridExtensions.RedrawSettings.flexRDNone);
				grdRecordsCriteria.Rows.Count = 1;
				grdRecordsCriteria.Cols.Count = 0;
				grdRecordsCriteria.Clear(C1.Win.C1FlexGrid.ClearFlags.All, grdRecordsCriteria.GetCellRange(grdRecordsCriteria.BottomRow, grdRecordsCriteria.LeftCol, grdRecordsCriteria.TopRow, grdRecordsCriteria.RightCol));
				//**-------------------------------------------------------------------------------
				grdRecordsCriteria.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
				grdRecordsCriteria.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
				grdRecordsCriteria.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
				grdRecordsCriteria.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
				//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid property grdRecordsCriteria.AutoSizeMouse was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdRecordsCriteria.setAutoSizeMouse(true);
				grdRecordsCriteria.AutoResize = false;
				grdRecordsCriteria.BackColor = Color.FromArgb(255, 255, 255);
				grdRecordsCriteria.Styles.Alternate.BackColor = Color.FromArgb(255, 255, 255);
				grdRecordsCriteria.Styles.EmptyArea.BackColor = mFixedGridBackColor;
				grdRecordsCriteria.Styles.Fixed.BackColor = mFixedHeaderBackColor;
				grdRecordsCriteria.Styles.Frozen.BackColor = Color.FromArgb(255, 255, 255);
				grdRecordsCriteria.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
				grdRecordsCriteria.AllowEditing = false;
				grdRecordsCriteria.ExtendLastCol = true;
				//UPGRADE_ISSUE: (2064) VSFlex8L.FillStyleSettings property FillStyleSettings.flexFillSingle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid property grdRecordsCriteria.FillStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdRecordsCriteria.setFillStyle(UpgradeStubs.VSFlex8L_FillStyleSettings.getflexFillSingle());
				grdRecordsCriteria.Cols.Fixed = 0;
				grdRecordsCriteria.Rows.Fixed = 0;
				grdRecordsCriteria.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
				grdRecordsCriteria.ForeColor = Color.FromArgb(0, 0, 0);
				grdRecordsCriteria.Styles.Fixed.ForeColor = Color.FromArgb(0, 0, 0);
				grdRecordsCriteria.Styles.Frozen.ForeColor = Color.FromArgb(0, 0, 0);
				//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid property grdRecordsCriteria.FontName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdRecordsCriteria.setFontName("Arial");
				//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid property grdRecordsCriteria.FontSize was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdRecordsCriteria.setFontSize(8);
				grdRecordsCriteria.Styles.Normal.Border.Color = Color.FromArgb(0, 0, 0);
				grdRecordsCriteria.Styles.Fixed.Border.Color = Color.FromArgb(0, 0, 0);
				grdRecordsCriteria.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
				grdRecordsCriteria.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
				grdRecordsCriteria.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
				grdRecordsCriteria.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
				grdRecordsCriteria.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
				grdRecordsCriteria.Height = mCriteriaGridHeight / 15;
				grdRecordsCriteria.Left = grdFindResult.Left;
				grdRecordsCriteria.Rows.MinSize = mCriteriaGridHeight / 15;
				grdRecordsCriteria.ScrollBars = ScrollBars.None;
				grdRecordsCriteria.setScrollTips(false);
				//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid property grdRecordsCriteria.ScrollTrack was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdRecordsCriteria.setScrollTrack(false);
				grdRecordsCriteria.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = Color.FromArgb(0, 0, 0);
				grdRecordsCriteria.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
				grdRecordsCriteria.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
				grdRecordsCriteria.Top = (grdFindResult.Top - mCriteriaGridHeight / 15);
				grdRecordsCriteria.Width = fraOuterShadow.Width - 1;
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					grdRecordsCriteria.RightToLeft = RightToLeft.No;
				}
				else
				{
					grdRecordsCriteria.RightToLeft = RightToLeft.Yes;
				}
				grdRecordsCriteria.setRedraw(UpgradeHelpers.VSFlexGridExtensions.RedrawSettings.flexRDDirect);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void DoFormatReportData()
		{
			int Cnt = 0;
			int mReportFixedRows = 0;
			int CriteriaColNo = 0;

			try
			{

				mReportFixedRows = grdFindResult.Rows.Fixed;
				//'**--set row identifier from recordsets bookmark
				grdFindResult.Cols.Count++;
				grdFindResult.Cols[grdFindResult.Cols.Count - 1].Move(0);
				grdFindResult.Cols[0].Visible = false;
				grdFindResult.Cols.Fixed = 1;
				int tempForEndVar = rsReportData.Tables[0].Rows.Count - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					grdFindResult[Cnt + mReportFixedRows, 0] = (Cnt + 1).ToString();
				}
				grdFindResult.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear);

				if (mReportSettingsChanged)
				{
					if (mReportIsFormated)
					{
						mReportIsFormated = false;
					}
					grdRecordsCriteria.Rows.Count = 1;
					grdRecordsCriteria.Cols.Count = 0;
					grdRecordsCriteria.Clear(C1.Win.C1FlexGrid.ClearFlags.All, grdRecordsCriteria.GetCellRange(grdRecordsCriteria.BottomRow, grdRecordsCriteria.LeftCol, grdRecordsCriteria.TopRow, grdRecordsCriteria.RightCol));
				}

				//**--define report columns
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsDetailsRecordset.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsDetailsRecordset.setSort("show_detail desc, column_no asc");
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsDetailsRecordset.MoveFirst();
				Cnt = grdFindResult.Cols.Fixed;
				foreach (DataRow iteration_row in rsDetailsRecordset.Tables[0].Rows)
				{
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(iteration_row["protected"])) == TriState.True || ((TriState) Convert.ToInt32(iteration_row["show_detail"])) == TriState.True)
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(iteration_row["show_detail"])) == TriState.True)
						{
							//**--set column header properties
							grdFindResult[mFixedRow, Cnt] = Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? iteration_row["l_field_caption"] : iteration_row["a_field_caption"]) + "";
							//**-----------------------------------------------------------------------------------------
							//**--set column level properties
							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
							if (((TriState) Convert.ToInt32(iteration_row["apply_format"])) == TriState.True)
							{
								grdFindResult.Cols[Cnt].UserData = Conversion.Str(iteration_row["format_text_type"]).Trim() + Conversion.Str(iteration_row["column_id"]).Trim();
							}
							else
							{
								grdFindResult.Cols[Cnt].UserData = "0" + Conversion.Str(iteration_row["column_id"]).Trim();
							}
							grdFindResult.Cols[Cnt].Visible = true;
							if (mReportSettingsChanged)
							{
								grdFindResult.Cols[Cnt].WidthDisplay = Convert.ToInt32(iteration_row["default_width"]) / 15;
							}
							else
							{
								CriteriaColNo = GetParallelColumnNo(grdFindResult, grdRecordsCriteria, Cnt, 2, 1);
								grdFindResult.Cols[Cnt].WidthDisplay = grdRecordsCriteria.Cols[CriteriaColNo].WidthDisplay;
							}

							//
							//                    If gPreferedLanguage = English Then
							//                        .Cell(flexcpFontName, mFixedRow, cnt, mFixedRow, .cols - 1) = rsDetailsRecordset.Fields("column_font_name").Value
							//                        .Cell(flexcpFontSize, mFixedRow, cnt, mFixedRow, .cols - 1) = 20
							//                    Else
							//                        .Cell(flexcpFontName, mFixedRow, 0, mFixedRow, .cols - 1) = gArabicFontName
							//                    End If

							string switchVar = Convert.ToString(iteration_row["field_alignment"]).ToLower();
							if (switchVar == ("L").ToLower())
							{
								grdFindResult.Cols[Cnt].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter;
							}
							else if (switchVar == ("R").ToLower())
							{ 
								grdFindResult.Cols[Cnt].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter;
							}
							else if (switchVar == ("C").ToLower())
							{ 
								grdFindResult.Cols[Cnt].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
							}
							//**-----------------------------------------------------------------------------------------
							//**--set columns data types
							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
							if (((TriState) Convert.ToInt32(iteration_row["is_ldgr_no_column"])) == TriState.True && SystemVariables.gApplicationInitialized)
							{
								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no"))) == TriState.True)
								{
									grdFindResult.Cols[Cnt].DataType = typeof(string);
								}
								else
								{
									grdFindResult.Cols[Cnt].DataType = typeof(Double);
								}
							}
							else if (((TriState) Convert.ToInt32(iteration_row["is_part_no_column"])) == TriState.True && SystemVariables.gApplicationInitialized)
							{ 
								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_part_no"))) == TriState.True)
								{
									grdFindResult.Cols[Cnt].DataType = typeof(string);
								}
								else
								{
									grdFindResult.Cols[Cnt].DataType = typeof(Double);
								}
							}
							else
							{
								string switchVar_2 = Convert.ToString(iteration_row["field_type"]).ToUpper();
								if (switchVar_2 == ("C").ToUpper())
								{
									grdFindResult.Cols[Cnt].DataType = typeof(string);
								}
								else if (switchVar_2 == ("N").ToUpper())
								{ 
									grdFindResult.Cols[Cnt].DataType = typeof(Double);
								}
								else if (switchVar_2 == ("D").ToUpper())
								{ 
									grdFindResult.Cols[Cnt].DataType = typeof(DateTime);
								}
								else if (switchVar_2 == ("L").ToUpper())
								{ 
									//.ColDataType(cnt) = flexDTBoolean
									MessageBox.Show("Error : Logical datatype not supported", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									Environment.Exit(0);
								}
							}
							//**-----------------------------------------------------------------------------------------
							//**--set special formating style for the column
							if (grdFindResult.Rows.Count > 1)
							{
								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								if (((TriState) Convert.ToInt32(iteration_row["apply_special_format"])) == TriState.True && mApplySpecialFormating)
								{
									//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
									if (((TriState) Convert.ToInt32(iteration_row["show_in_bold"])) == TriState.True)
									{
										grdFindResult.setCellFontBold(TriState.True != TriState.False, grdFindResult.Rows.Fixed, Cnt, grdFindResult.Rows.Count - 1, Cnt);
									}
									//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
									if (((TriState) Convert.ToInt32(iteration_row["show_in_italic"])) == TriState.True)
									{
										grdFindResult.setCellFontItalic(TriState.True != TriState.False, grdFindResult.Rows.Fixed, Cnt, grdFindResult.Rows.Count - 1, Cnt);
									}
									//**--save the column back color setting in the first 'cell data' of the column
									grdFindResult.SetUserData(mFixedRow, Cnt, iteration_row["column_back_color"]);
									grdFindResult.setCellBackColor(ColorTranslator.FromOle(Convert.ToInt32(iteration_row["column_back_color"])), grdFindResult.Rows.Fixed, Cnt, grdFindResult.Rows.Count - 1, Cnt);
									grdFindResult.setCellForeColor(ColorTranslator.FromOle(Convert.ToInt32(iteration_row["column_fore_color"])), grdFindResult.Rows.Fixed, Cnt, grdFindResult.Rows.Count - 1, Cnt);
								}
								else
								{
									grdFindResult.SetUserData(mFixedRow, Cnt, ColorTranslator.ToOle(Color.White));
								}
								//**--apply column font settings
								//UPGRADE_ISSUE: (2064) VSFlex8.CellPropertySettings property CellPropertySettings.flexcpFontName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdFindResult.Cell was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								grdFindResult.Cell[UpgradeStubs.VSFlex8_CellPropertySettings.getflexcpFontName(), grdFindResult.Rows.Fixed, Cnt, grdFindResult.Rows.Count - 1, Cnt] = iteration_row["column_font_name"];
								//.Cell(flexcpFontSize, .FixedRows, cnt, .Rows - 1, cnt) = rsDetailsRecordset("column_font_size").Value
							}
							if (mReportSettingsChanged)
							{
								//**--add a column in filter criteria if the column is to be displayed
								//**--and set its properties
								grdRecordsCriteria.Cols.Count++;

								grdRecordsCriteria.Cols[grdRecordsCriteria.Cols.Count - 1].WidthDisplay = Convert.ToInt32(iteration_row["default_width"]) / 15;
								grdRecordsCriteria.Cols[grdRecordsCriteria.Cols.Count - 1].UserData = Conversion.Str(iteration_row["column_id"]).Trim();

								string switchVar_3 = Convert.ToString(iteration_row["field_alignment"]).ToLower();
								if (switchVar_3 == ("L").ToLower())
								{
									grdRecordsCriteria.Cols[grdRecordsCriteria.Cols.Count - 1].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter;
								}
								else if (switchVar_3 == ("R").ToLower())
								{ 
									grdRecordsCriteria.Cols[grdRecordsCriteria.Cols.Count - 1].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter;
								}
								else if (switchVar_3 == ("C").ToLower())
								{ 
									grdRecordsCriteria.Cols[grdRecordsCriteria.Cols.Count - 1].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
								}
								//**--set columns data types
								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								if (((TriState) Convert.ToInt32(iteration_row["is_ldgr_no_column"])) == TriState.True && SystemVariables.gApplicationInitialized)
								{
									//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
									if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no"))) == TriState.True)
									{
										grdRecordsCriteria.Cols[grdRecordsCriteria.Cols.Count - 1].DataType = typeof(string);
									}
									else
									{
										grdRecordsCriteria.Cols[grdRecordsCriteria.Cols.Count - 1].DataType = typeof(Double);
									}
								}
								else if (((TriState) Convert.ToInt32(iteration_row["is_part_no_column"])) == TriState.True && SystemVariables.gApplicationInitialized)
								{ 
									//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
									if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_part_no"))) == TriState.True)
									{
										grdRecordsCriteria.Cols[grdRecordsCriteria.Cols.Count - 1].DataType = typeof(string);
									}
									else
									{
										grdRecordsCriteria.Cols[grdRecordsCriteria.Cols.Count - 1].DataType = typeof(Double);
									}
								}
								else
								{
									string switchVar_4 = Convert.ToString(iteration_row["field_type"]).ToUpper();
									if (switchVar_4 == ("C").ToUpper())
									{
										grdRecordsCriteria.Cols[grdRecordsCriteria.Cols.Count - 1].DataType = typeof(string);
									}
									else if (switchVar_4 == ("N").ToUpper())
									{ 
										grdRecordsCriteria.Cols[grdRecordsCriteria.Cols.Count - 1].DataType = typeof(Double);
									}
									else if (switchVar_4 == ("D").ToUpper())
									{ 
										grdRecordsCriteria.Cols[grdRecordsCriteria.Cols.Count - 1].DataType = typeof(DateTime);
									}
									else if (switchVar_4 == ("L").ToUpper())
									{ 
										//.ColDataType(cnt) = flexDTBoolean
										MessageBox.Show("Error : Logical datatype not supported", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
										Environment.Exit(0);
									}
								}
								//**-----------------------------------------------------------------------------------------
								//**-----------------------------------------------------------------------
							}
						}
						else
						{
							grdFindResult.Cols[Cnt].UserData = "0" + Conversion.Str(iteration_row["column_id"]).Trim();
							grdFindResult.Cols[Cnt].Visible = false;
						}
						Cnt++;
					}
				}
				//**-----------------------------------------------------------------------------------------
				//**--check if columns autosizing is enabled
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["Auto_Size_Columns"])) == TriState.True)
				{
					//**--autosize column headers
					grdFindResult.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
					grdFindResult.AutoSizeCols(0, grdFindResult.Cols.Count - 1, Convert.ToInt32(7));
				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		//UPGRADE_WARNING: (2050) VSFlex8.VSFlexGrid Event grdFindResult.AfterDataRefresh was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdFindResult_AfterDataRefresh()
		{
			try
			{

				//**--show the total result counts (or filtered records)
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsDetailsRecordset.MoveFirst();
				rsDetailsRecordset.Tables[0].DefaultView.RowFilter = "show_detail = 1";
				if (rsDetailsRecordset.Tables[0].Rows.Count == 0)
				{
					txtCriteriaBox.Visible = false;
					grdFindResult.Visible = false;
					//lblFindResult.Caption = " 0" & lblFindResult.Tag
					UCStatusBar.FindPane(1).Text = " 0" + Convert.ToString(lblFindResult.Tag);
				}
				else
				{
					txtCriteriaBox.Visible = true;
					grdFindResult.Visible = true;
					//lblFindResult.Caption = Trim(Str(grdFindResult.Rows - 1)) & lblFindResult.Tag
					UCStatusBar.FindPane(1).Text = Conversion.Str(grdFindResult.Rows.Count - 1).Trim() + Convert.ToString(lblFindResult.Tag);
				}
				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsDetailsRecordset.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsDetailsRecordset.MoveFirst();

				DoFormatReportData();
				if (mReportSettingsChanged)
				{
					mReportSettingsChanged = false;
				}

				mUseColumnScroll = false;
				grdFindResult_AfterScroll(grdFindResult, new C1.Win.C1FlexGrid.RangeEventArgs(grdFindResult.GetCellRange(0, 0), grdFindResult.GetCellRange(1, 1)));

				if (grdRecordsCriteria.Cols.Count > 0 && grdRecordsCriteria.Col == -1)
				{
					grdRecordsCriteria.Col = 0;
				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void grdFindResult_AfterResizeColumn(Object eventSender, C1.Win.C1FlexGrid.RowColEventArgs eventArgs)
		{
			int Row = eventArgs.Row;
			int Col = eventArgs.Col;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				int Cnt = GetParallelColumnNo(grdFindResult, grdRecordsCriteria, Col, 2, 1);
				grdRecordsCriteria.Cols[Cnt].WidthDisplay = grdFindResult.Cols[Col].WidthDisplay;

				mReportIsFormated = false;
				mUseColumnScroll = false;
				SetCurrentFilterSelection(false, true);
				grdFindResult_AfterScroll(grdFindResult, new C1.Win.C1FlexGrid.RangeEventArgs(grdFindResult.GetCellRange(0, 0), grdFindResult.GetCellRange(1, 1)));
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdFindResult_BeforeResizeColumn(Object eventSender, C1.Win.C1FlexGrid.RowColEventArgs eventArgs)
		{
			int Row = eventArgs.Row;
			int Col = eventArgs.Col;
			bool Cancel = eventArgs.Cancel;
			try
			{
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					mResizeInProgress = true;
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel;
			}
		}

		private void grdFindResult_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!mResizeInProgress)
				{
					btnReportOptions_Click(btnReportOptions[mButtonSeek], new EventArgs());
				}
				mResizeInProgress = false;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdFindResult_AfterSort(Object eventSender, C1.Win.C1FlexGrid.SortColEventArgs eventArgs)
		{
			int Col = eventArgs.Col;
			int Order = (int) eventArgs.Order;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				mUseColumnScroll = false;
				grdFindResult_AfterScroll(grdFindResult, new C1.Win.C1FlexGrid.RangeEventArgs(grdFindResult.GetCellRange(0, 0), grdFindResult.GetCellRange(1, 1)));
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdFindResult_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					if (KeyCode == ((int) Keys.Return) || KeyCode == ((int) Keys.Space))
					{
						btnReportOptions_Click(btnReportOptions[mButtonSeek], new EventArgs());
					}
					else if (KeyCode == ((int) Keys.Up))
					{ 
						if (grdFindResult.Row == grdFindResult.Rows.Fixed)
						{
							grdRecordsCriteria.Focus();
						}
					}
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private int GetParallelColumnNo(C1.Win.C1FlexGrid.C1FlexGrid CurrentGrid, C1.Win.C1FlexGrid.C1FlexGrid CompareToGrid, int CurrentGridCol, int G1Start = 1, int G2Start = 1)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			int result = 0;
			try
			{
				int Cnt = 0;

				//**--unhandled error
				//**--handle here when visible cols = 0
				int tempForEndVar = CompareToGrid.Cols.Count - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(CurrentGrid.Cols[CurrentGridCol].UserData).Substring(G1Start - 1) == ReflectionHelper.GetPrimitiveValue<string>(CompareToGrid.Cols[Cnt].UserData).Substring(G2Start - 1))
					{
						result = Cnt;
						break;
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		private void SetCurrentFilterSelection(bool SetBackColor = true, bool SetColumnWidth = true)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int CurrentResultCol = 0;
				int Cnt = 0;

				//**--check if results are formated
				//**--if not, then format it or else skip the process
				if (!mReportIsFormated)
				{
					mReportIsFormated = true;
				}
				else
				{
					return;
				}

				//If SetBackColor = True Then
				//    CurrentResultCol = GetParallelColumnNo(grdRecordsCriteria, grdFindResult, grdRecordsCriteria.Col, 1, 2)
				//    With grdFindResult
				//        If .Rows > .FixedRows Then
				//            For cnt = 0 To .cols - 1
				//                .Cell(flexcpBackColor, .FixedRows, cnt, .Rows - 1, cnt) = .Cell(flexcpData, mFixedRow, cnt)
				//            Next
				//            .Cell(flexcpBackColor, .FixedRows, CurrentResultCol, .Rows - 1, CurrentResultCol) = mFilterBackColor
				//        End If
				//    End With
				//End If

				if (SetColumnWidth)
				{
					txtCriteriaBox.Left = grdRecordsCriteria.Left + grdRecordsCriteria.GetCellRect(grdRecordsCriteria.Row, grdRecordsCriteria.Col, true).Left / 15 + 1;
					txtCriteriaBox.Top = grdRecordsCriteria.Top + grdRecordsCriteria.GetCellRect(grdRecordsCriteria.Row, grdRecordsCriteria.Col, true).Top / 15 + 1;
					txtCriteriaBox.Height = (grdRecordsCriteria.GetCellRect(grdRecordsCriteria.Row, grdRecordsCriteria.Col, true).Height - 30) / 15;
					txtCriteriaBox.Width = (grdRecordsCriteria.GetCellRect(grdRecordsCriteria.Row, grdRecordsCriteria.Col, true).Width - 10) / 15;
					if (!txtCriteriaBox.Visible)
					{
						txtCriteriaBox.Visible = true;
					}
					txtCriteriaBox.Focus();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCriteriaBox_TextChanged(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (Convert.ToString(txtCriteriaBox.Tag) == "")
				{
					if (ShowAllRecords())
					{
						FilterResultData(grdRecordsCriteria.Col);
						SetCurrentColumnSettings(grdRecordsCriteria);
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCriteriaBox_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{

					if (KeyCode == ((int) Keys.Return))
					{
						if (ShowAllRecords())
						{
							if (Shift == 1)
							{ //if shift key is pressed
								if (grdRecordsCriteria.Col > 0)
								{
									grdRecordsCriteria.Col--;
								}
								else
								{
									grdRecordsCriteria.Col = grdRecordsCriteria.Cols.Count - 1;
								}
							}
							else
							{
								btnReportOptions_Click(btnReportOptions[mButtonSeek], new EventArgs());
							}
						}
						else
						{
							FilterResultData2(grdRecordsCriteria.Col);
							mReportSettingsChanged = true;
							//Call DoFormatReportData
							//Call SetCurrentColumnSettings(grdRecordsCriteria)

						}
					}
					else if (KeyCode == ((int) Keys.Down))
					{ 
						//If (grdFindResult.Row < grdFindResult.FixedRows) And (grdFindResult.Rows > grdFindResult.FixedRows) Then
						if (grdFindResult.Rows.Count > grdFindResult.Rows.Fixed)
						{
							grdFindResult.Row = grdFindResult.Rows.Fixed;
							grdFindResult.ShowCell(grdFindResult.Rows.Fixed, grdFindResult.Col);
							grdFindResult.Focus();
						}
					}
					else if (KeyCode == ((int) Keys.Back) || KeyCode == ((int) Keys.Left) || KeyCode == ((int) Keys.PageUp))
					{ 
						//**--if creteria box is empty is Ctrl key is pressed
						if (txtCriteriaBox.Text == "" || Shift == 2 || txtCriteriaBox.SelectionStart == 0)
						{
							if (grdRecordsCriteria.Col > 0)
							{
								grdRecordsCriteria.Col--;
							}
						}
					}
					else if (KeyCode == ((int) Keys.Right) || KeyCode == ((int) Keys.PageDown) || KeyCode == ((int) Keys.Tab))
					{ 
						//**--if creteria box is empty is Ctrl key is pressed
						if (txtCriteriaBox.Text == "" || Shift == 2 || txtCriteriaBox.SelectionStart == Strings.Len(txtCriteriaBox.Text))
						{
							if (grdRecordsCriteria.Col < grdRecordsCriteria.Cols.Count - 1)
							{
								grdRecordsCriteria.Col++;
							}
							else
							{
								grdRecordsCriteria.Col = 0;
							}
						}
					}
					else if (KeyCode == ((int) Keys.End))
					{ 
						grdRecordsCriteria.Col = grdRecordsCriteria.Cols.Count - 1;
					}
					else if (KeyCode == ((int) Keys.Home))
					{ 
						grdRecordsCriteria.Col = 0;
					}
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void GetFindOptions()
		{
			try
			{

				//show query & options form
				frmSysFindOptions oFindOptionsForm = null;

				mReportSettingsChanged = true;
				oFindOptionsForm = frmSysFindOptions.CreateInstance();
				oFindOptionsForm.AttachObjects(this, rsMasterRecordset, rsDetailsRecordset);
				oFindOptionsForm.ShowOptionsTab = 0;
				//UPGRADE_WARNING: (7009) Multiple invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions More Information: https://docs.mobilize.net/vbuc/ewis#7009
				oFindOptionsForm.ShowDialog();
				oFindOptionsForm.Close();
				oFindOptionsForm = null;

				mReportSettingsChanged = false;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void SeekRecord(int CurrentRow)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string[] mTempColumnList = null;
				int mEntryColumnID = 0;
				int Cnt = 0;
				int ColCnt = 0;

				if (CurrentRow > 0)
				{
					//**--first set the entry id column value
					//**--(on index '0')
					//UPGRADE_WARNING: (1068) GetColumnInformation() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryColumnID = ReflectionHelper.GetPrimitiveValue<int>(SystemReports.GetColumnInformation("entry_id_column=1", "column_id", rsDetailsRecordset));
					int tempForEndVar = grdFindResult.Cols.Count - 1;
					for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
					{
						if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdFindResult.Cols[Cnt].UserData).Substring(1)) == mEntryColumnID)
						{
							mReturnColumnValues = Convert.ToString(grdFindResult[CurrentRow, Cnt]);
							break;
						}
					}
					//**--use split function to create the variable as an array
					mReturnColumnValues = ReflectionHelper.GetPrimitiveValue<string>(mReturnColumnValues).Split(new string[]{""}, StringSplitOptions.None);
					//**--------------------------------------------------------------------------------------------
					//**--retrieve other column values, if requested in the
					//**--parameter column list
					if (mReturnColumnIDList != "")
					{
						mTempColumnList = mReturnColumnIDList.Split(',');
						for (Cnt = 0; Cnt <= mTempColumnList.GetUpperBound(0); Cnt++)
						{
							mReturnColumnValues = ArraysHelper.RedimPreserve(mReturnColumnValues, new int[]{((Array) mReturnColumnValues).GetUpperBound(0) + 2});

							int tempForEndVar2 = grdFindResult.Cols.Count - 1;
							for (ColCnt = 0; ColCnt <= tempForEndVar2; ColCnt++)
							{
								if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdFindResult.Cols[ColCnt].UserData).Substring(1)) == Conversion.Val(mTempColumnList[Cnt]))
								{
									((Array) mReturnColumnValues).SetValue(Convert.ToString(grdFindResult[CurrentRow, ColCnt]), ((Array) mReturnColumnValues).GetUpperBound(0));
									break;
								}
							}
						}
					}
				}
				else
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mReturnColumnValues = DBNull.Value;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdRecordsCriteria_BeforeRowColChange(Object eventSender, C1.Win.C1FlexGrid.RangeEventArgs eventArgs)
		{
			int OldRow = eventArgs.OldRange.r1;
			int OldCol = eventArgs.OldRange.c1;
			int NewRow = eventArgs.NewRange.r1;
			int NewCol = eventArgs.NewRange.c1;
			bool Cancel = eventArgs.Cancel;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (mReportIsFormated)
				{
					grdRecordsCriteria[OldRow, OldCol] = txtCriteriaBox.Text + "";
					txtCriteriaBox.Tag = "False";
					txtCriteriaBox.Text = Convert.ToString(grdRecordsCriteria[NewRow, NewCol]);
					if (grdRecordsCriteria.Cols[NewCol].TextAlign == C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
					{
						txtCriteriaBox.TextAlign = HorizontalAlignment.Left;
					}
					else if (grdRecordsCriteria.Cols[NewCol].TextAlign == C1.Win.C1FlexGrid.TextAlignEnum.RightCenter)
					{ 
						txtCriteriaBox.TextAlign = HorizontalAlignment.Right;
					}
					else
					{
						txtCriteriaBox.TextAlign = HorizontalAlignment.Center;
					}
					txtCriteriaBox.Tag = "";
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdRecordsCriteria_AfterResizeColumn(Object eventSender, C1.Win.C1FlexGrid.RowColEventArgs eventArgs)
		{
			int Row = eventArgs.Row;
			int Col = eventArgs.Col;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				int Cnt = GetParallelColumnNo(grdRecordsCriteria, grdFindResult, Col, 1, 2);
				grdFindResult.Cols[Cnt].WidthDisplay = grdRecordsCriteria.Cols[Col].WidthDisplay;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdRecordsCriteria_Enter(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SetCurrentFilterSelection();
				//If txtCriteriaBox.Visible = False Then
				//    txtCriteriaBox.Visible = True
				//End If

				if (txtCriteriaBox.Visible)
				{
					txtCriteriaBox.Focus();
				}

				//Call grdRecordsCriteria_AfterRowColChange(0, 0, 0, 0)
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdFindResult_AfterScroll(Object eventSender, C1.Win.C1FlexGrid.RangeEventArgs eventArgs)
		{
			int OldTopRow = eventArgs.OldRange.r1;
			int OldLeftCol = eventArgs.OldRange.c1;
			int NewTopRow = eventArgs.NewRange.r1;
			int NewLeftCol = eventArgs.NewRange.c1;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				int Cnt = 0;
				int RowCnt = 0;
				int ColCnt = 0;
				object mFormatedValue = null;

				//**--apply column formats
				//**--on verticel scroll
				if (OldTopRow != NewTopRow)
				{
					int tempForEndVar = grdFindResult.Rows.Count - 1;
					for (RowCnt = grdFindResult.TopRow; RowCnt <= tempForEndVar; RowCnt++)
					{
						if (grdFindResult.Rows[RowCnt].IsVisible)
						{
							if (ReflectionHelper.GetPrimitiveValue<string>(grdFindResult.Rows[RowCnt].UserData) != "1")
							{
								grdFindResult.Rows[RowCnt].UserData = "1";

								int tempForEndVar2 = grdFindResult.Cols.Count - 1;
								for (ColCnt = grdFindResult.Cols.Fixed; ColCnt <= tempForEndVar2; ColCnt++)
								{
									if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdFindResult.Cols[ColCnt].UserData).Substring(0, Math.Min(1, ReflectionHelper.GetPrimitiveValue<string>(grdFindResult.Cols[ColCnt].UserData).Length))) != 0)
									{
										//UPGRADE_WARNING: (1068) GetFormatedValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
										mFormatedValue = ReflectionHelper.GetPrimitiveValue(SystemReports.GetFormatedValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdFindResult.Cols[ColCnt].UserData).Substring(0, Math.Min(1, ReflectionHelper.GetPrimitiveValue<string>(grdFindResult.Cols[ColCnt].UserData).Length)))), (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdFindResult.Cols[ColCnt].UserData).Substring(0, Math.Min(1, ReflectionHelper.GetPrimitiveValue<string>(grdFindResult.Cols[ColCnt].UserData).Length))) == 5) ? grdFindResult.getCellText(RowCnt, ColCnt) : grdFindResult.getCellValue(RowCnt, ColCnt)));
										grdFindResult.setCellText(ReflectionHelper.GetPrimitiveValue<string>(mFormatedValue), RowCnt, ColCnt);
									}
								}
							}
						}
						else
						{
							goto eEndFormatLoop;
						}
					}
				}
				eEndFormatLoop:

				//**--on horizontal scroll
				if (OldLeftCol != NewLeftCol && mUseColumnScroll)
				{
					SetCurrentColumnSettings(grdFindResult, NewLeftCol, OldLeftCol);
				}
				else
				{
					mUseColumnScroll = true;
				}

				return;


				MessageBox.Show(Information.Err().Description, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdRecordsCriteria_AfterScroll(Object eventSender, C1.Win.C1FlexGrid.RangeEventArgs eventArgs)
		{
			int OldTopRow = eventArgs.OldRange.r1;
			int OldLeftCol = eventArgs.OldRange.c1;
			int NewTopRow = eventArgs.NewRange.r1;
			int NewLeftCol = eventArgs.NewRange.c1;
			try
			{
				SetCurrentColumnSettings(grdRecordsCriteria, NewLeftCol);
			}
			catch
			{
			}
		}

		private void grdRecordsCriteria_RowColChange(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (mReportIsFormated)
				{
					SetCurrentColumnSettings(grdRecordsCriteria);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		bool mSettingInProgress_SetCurrentColumnSettings = false;
		private void SetCurrentColumnSettings(C1.Win.C1FlexGrid.C1FlexGrid CurrentObject, int NewCol = -1, int OldCol = -1)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;
				int mNewCurrentColumn = 0;

				if (!mSettingInProgress_SetCurrentColumnSettings)
				{
					grdRecordsCriteria.setRedraw(UpgradeHelpers.VSFlexGridExtensions.RedrawSettings.flexRDNone);
					grdFindResult.setRedraw(UpgradeHelpers.VSFlexGridExtensions.RedrawSettings.flexRDNone);

					mSettingInProgress_SetCurrentColumnSettings = true;
					if (CurrentObject.Name == "grdRecordsCriteria")
					{
						mNewCurrentColumn = (NewCol == -1) ? grdRecordsCriteria.Col : NewCol;
						//**--if the column is not in the current view make it visible
						//**--by setting it as the left most column
						if (!grdRecordsCriteria.Cols[mNewCurrentColumn].IsVisible)
						{
							grdRecordsCriteria.LeftCol = mNewCurrentColumn;

							//**--after setting the left column for the criteria grid
							//**--set the left most column of the result grid as well
							Cnt = GetParallelColumnNo(grdRecordsCriteria, grdFindResult, mNewCurrentColumn, 1, 2);
							grdFindResult.LeftCol = Cnt;
							//**------------------------------------------------------------------------------------
						}
						else
						{
							Cnt = GetParallelColumnNo(grdRecordsCriteria, grdFindResult, mNewCurrentColumn, 1, 2);
							grdFindResult.Col = Cnt;
							if (mNewCurrentColumn > 0)
							{
								//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid property grdRecordsCriteria.ClientWidth was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								if (grdRecordsCriteria.getClientWidth() < grdRecordsCriteria.GetCellRect(grdRecordsCriteria.Row, grdRecordsCriteria.Col, true).Left + grdRecordsCriteria.GetCellRect(grdRecordsCriteria.Row, grdRecordsCriteria.Col, true).Width)
								{
									grdRecordsCriteria.LeftCol = mNewCurrentColumn;
									grdFindResult.LeftCol = Cnt;
								}
								else
								{
									if (grdRecordsCriteria.GetCellRect(grdRecordsCriteria.Row, grdRecordsCriteria.Col, true).Left != grdFindResult.GetCellRect(grdFindResult.Row, grdFindResult.Col, true).Left)
									{
										grdFindResult.LeftCol = Cnt;
									}
								}
							}
						}
						//**----------------------------------------------------------------------------------------
						mReportIsFormated = false;
						SetCurrentFilterSelection();
					}
					else if (CurrentObject.Name == "grdFindResult")
					{ 
						mNewCurrentColumn = Math.Min(OldCol, NewCol);
						Cnt = GetParallelColumnNo(grdFindResult, grdRecordsCriteria, NewCol, 2, 1);
						if (!grdFindResult.Cols[mNewCurrentColumn].IsVisible)
						{
							grdRecordsCriteria.LeftCol = Cnt;
							if (!grdRecordsCriteria.Cols[grdRecordsCriteria.Col].IsVisible)
							{
								txtCriteriaBox.Visible = false;
							}
							else
							{
								mReportIsFormated = false;
								SetCurrentFilterSelection();
							}
						}
						else
						{
							grdRecordsCriteria.LeftCol = Cnt;
							if (grdRecordsCriteria.Cols[grdRecordsCriteria.Col].IsVisible)
							{
								txtCriteriaBox.Visible = true;
								mReportIsFormated = false;
								SetCurrentFilterSelection();
							}
						}
					}
					mSettingInProgress_SetCurrentColumnSettings = false;

					//UPGRADE_WARNING: (6021) Casting 'bool' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					grdRecordsCriteria.setRedraw((UpgradeHelpers.VSFlexGridExtensions.RedrawSettings) (-1));
					//UPGRADE_WARNING: (6021) Casting 'bool' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					grdFindResult.setRedraw((UpgradeHelpers.VSFlexGridExtensions.RedrawSettings) (-1));
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//Private Sub txtCriteriaBox_GotFocus()
		//With txtCriteriaBox
		//    Select Case grdRecordsCriteria.ColAlignment(grdRecordsCriteria.Col)
		//        Case flexAlignLeftCenter
		//            .Alignment = vbLeftJustify
		//        Case flexAlignRightCenter
		//            .Alignment = vbRightJustify
		//        Case flexAlignCenterCenter
		//            .Alignment = vbCenter
		//    End Select
		//End With
		//End Sub

		//Private Sub grdRecordsCriteria_AfterRowColChange(ByVal OldRow As Long, ByVal OldCol As Long, ByVal NewRow As Long, ByVal NewCol As Long)
		//'grdFindResult.ColDataType(NewCol) = flexDTBoolean
		//If grdFindResult.ColDataType(NewCol) = flexDTString Then
		//    chkCommonSettings.Enabled = True
		//Else
		//    chkCommonSettings.Enabled = False
		//End If
		//End Sub

		private bool ShowAllRecords()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			bool result = false;
			try
			{
				result = mShowAllRecords || ((int) chkCommonSettings[cbShowAllRecords].CheckState) == ((int) TriState.True);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		private void FilterResultData(int pCurrentEditColumn)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				string mFilterText = "";
				string mColumnName = "";
				string mFilterCriteriaType = "";
				int Cnt = 0;

				StringBuilder mFilterCondition = new StringBuilder();
				int position = 0;
				string[] output = null;
				string newFilter = "";
				int p = 0;
				int tempForEndVar = grdRecordsCriteria.Cols.Count - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					if (Cnt == pCurrentEditColumn)
					{
						mFilterText = txtCriteriaBox.Text;
					}
					else
					{
						mFilterText = Convert.ToString(grdRecordsCriteria[0, Cnt]);
					}



					if (mFilterText != "")
					{
						mFilterText = StringsHelper.Replace(mFilterText, "*", "%", 1, -1, CompareMethod.Binary);
						mColumnName = mColumnPrefix + ReflectionHelper.GetPrimitiveValue<string>(grdRecordsCriteria.Cols[Cnt].UserData).Trim();

						Type switchVar = grdRecordsCriteria.Cols[Cnt].DataType;
						if (switchVar == typeof(string))
						{
							position = (mFilterText.IndexOf('%') + 1);

							if (position > 0)
							{
								output = mFilterText.Split('%');

								foreach (string output_item in output)
								{
									if (output_item != "")
									{
										if (mFilterCondition.ToString() == "")
										{
											mFilterCondition.Append(mColumnName + " like '%" + output_item + "%'");
										}
										else
										{
											mFilterCondition.Append(" and " + mColumnName + " like '%" + output_item + "%'");
										}
									}
								}
							}
							else
							{
								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Default_In_Line_Search_in_Find"))) == TriState.True)
								{
									mFilterText = "%" + mFilterText;
								}

								if (mFilterText.StartsWith("*"))
								{ //chkCommonSettings(cbSubstringSearch).Value = vbFalse Then
									mFilterCriteriaType = " like '%";
									mFilterText = mFilterText.Substring(Math.Max(mFilterText.Length - (Strings.Len(mFilterText) - 1), 0));
								}
								else
								{
									mFilterCriteriaType = " like '";
								}
								if (mFilterText != "")
								{
									if (mFilterCondition.ToString() == "")
									{
										mFilterCondition = new StringBuilder(mColumnName + mFilterCriteriaType + mFilterText + "%'");
									}
									else
									{
										mFilterCondition.Append(" and " + mColumnName + mFilterCriteriaType + mFilterText + "%'");
									}
								}
							}
						}
						else if (switchVar == typeof(Double))
						{ 
							if (Conversion.Val(mFilterText) != 0)
							{
								if (mFilterCondition.ToString() == "")
								{
									mFilterCondition = new StringBuilder(mColumnName + " >= " + Conversion.Val(mFilterText).ToString());
								}
								else
								{
									mFilterCondition.Append(" and " + mColumnName + " >= " + mFilterText);
								}
							}
						}
						else if (switchVar == typeof(DateTime))
						{ 
							if (Information.IsDate(mFilterText))
							{
								if (mFilterCondition.ToString() == "")
								{
									mFilterCondition = new StringBuilder(mColumnName + " >= '" + StringsHelper.Format(Convert.ToDateTime(mFilterText), SystemVariables.gSystemDateFormat) + "'");
								}
								else
								{
									mFilterCondition.Append(" and " + mColumnName + " >= '" + StringsHelper.Format(Convert.ToDateTime(mFilterText), SystemVariables.gSystemDateFormat) + "'");
								}
							}
						}
						else if (switchVar == typeof(Boolean))
						{ 
						}
					}
				}


				rsReportData.Tables[0].DefaultView.RowFilter = mFilterCondition.ToString();




				grdFindResult.Cols.Fixed = 0;
				grdFindResult.Clear(C1.Win.C1FlexGrid.ClearFlags.UserData, grdFindResult.GetCellRange(grdFindResult.BottomRow, grdFindResult.LeftCol, grdFindResult.TopRow, grdFindResult.RightCol));
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid method grdFindResult.DataRefresh was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdFindResult.DataRefresh();
				mReportIsFormated = false;
				SetCurrentFilterSelection(true, false);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void FilterResultData2(int pCurrentEditColumn)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				string mFilterText = "";
				string mColumnName = "";
				string mFilterCriteriaType = "";
				int Cnt = 0;
				string mysql = "";

				StringBuilder mFilterCondition = new StringBuilder();
				int tempForEndVar = grdRecordsCriteria.Cols.Count - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					if (Cnt == pCurrentEditColumn)
					{
						mFilterText = txtCriteriaBox.Text;
					}
					else
					{
						mFilterText = Convert.ToString(grdRecordsCriteria[0, Cnt]);
					}
					if (mFilterText != "")
					{
						mColumnName = mColumnPrefix + ReflectionHelper.GetPrimitiveValue<string>(grdRecordsCriteria.Cols[Cnt].UserData).Trim();
						Type switchVar = grdRecordsCriteria.Cols[Cnt].DataType;
						if (switchVar == typeof(string))
						{
							if (mFilterText.StartsWith("*"))
							{ //chkCommonSettings(cbSubstringSearch).Value = vbFalse Then
								mFilterCriteriaType = " like '%";
								mFilterText = mFilterText.Substring(Math.Max(mFilterText.Length - (Strings.Len(mFilterText) - 1), 0));
							}
							else
							{
								mFilterCriteriaType = " like '";
							}

							if (mFilterText != "")
							{
								if (mFilterCondition.ToString() == "")
								{
									mFilterCondition = new StringBuilder(mColumnName + mFilterCriteriaType + mFilterText + "%'");
								}
								else
								{
									mFilterCondition.Append(" and " + mColumnName + mFilterCriteriaType + mFilterText + "%'");
								}
							}
						}
						else if (switchVar == typeof(Double))
						{ 
							if (Conversion.Val(mFilterText) != 0)
							{
								if (mFilterCondition.ToString() == "")
								{
									mFilterCondition = new StringBuilder(mColumnName + " >= " + Conversion.Val(mFilterText).ToString());
								}
								else
								{
									mFilterCondition.Append(" and " + mColumnName + " >= " + mFilterText);
								}
							}
						}
						else if (switchVar == typeof(DateTime))
						{ 
							if (Information.IsDate(mFilterText))
							{
								if (mFilterCondition.ToString() == "")
								{
									mFilterCondition = new StringBuilder(mColumnName + " >= '" + StringsHelper.Format(Convert.ToDateTime(mFilterText), SystemVariables.gSystemDateFormat) + "'");
								}
								else
								{
									mFilterCondition.Append(" and " + mColumnName + " >= '" + StringsHelper.Format(Convert.ToDateTime(mFilterText), SystemVariables.gSystemDateFormat) + "'");
								}
							}
						}
						else if (switchVar == typeof(Boolean))
						{ 
						}
					}
					//DoEvents
				}

				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsReportData.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (rsReportData.getState() == ConnectionState.Open)
				{
				}

				mysql = "select * from (";
				mysql = mysql + mFindDataSourceSelectSQL + mFindDataSourceWhereSQL;
				mysql = mysql + mFindDataSourceGroupBySQL;
				mysql = mysql + ") as rs";
				//**--order by clause can not be included, needs to work on it
				//mysql = mysql & mFindDataSourceOrderBySQL
				//**-----------------------------------------------------------------
				if (mFilterCondition.ToString() != "")
				{
					mysql = mysql + " where " + mFilterCondition.ToString();
				}
				mysql = mysql + " order by 1";

				GetReportData(mysql);
				//    .Open mysql, gConn, adOpenForwardOnly, adLockReadOnly
				//
				//With grdFindResult
				//    .FixedCols = 0
				//    .Clear 0, 3
				//    .DataRefresh
				//End With
				mReportIsFormated = false;
				SetCurrentFilterSelection(true, false);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void btnReportOptions_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.btnReportOptions, eventSender);
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				object mRecordEntryIDValue = null;

				switch(Index)
				{
					case mButtonSeek : 
						if (grdFindResult.Rows.Count > grdFindResult.Rows.Fixed && grdFindResult.Row == 0)
						{
							grdFindResult.Row = grdFindResult.Rows.Fixed;
						} 
						SeekRecord(grdFindResult.Row); 
						this.Hide(); 
						break;
					case mButtonNew : 
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
						if (!SystemProcedure2.IsItEmpty(rsMasterRecordset.Tables[0].Rows[0]["linked_form_id"], SystemVariables.DataType.NumberType))
						{
							this.Hide();
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemForms.GetSystemForm(Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["linked_form_id"]), 1);
						}
						else
						{
							MessageBox.Show("Associated form not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							grdRecordsCriteria.Focus();
						} 
						break;
					case mButtonOpen : 
						if (grdFindResult.Rows.Count > grdFindResult.Rows.Fixed && grdFindResult.Row == 0)
						{
							grdFindResult.Row = grdFindResult.Rows.Fixed;
						} 
						SeekRecord(grdFindResult.Row); 
						//UPGRADE_WARNING: (1068) mReturnColumnValues() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mRecordEntryIDValue = ReflectionHelper.GetPrimitiveValue(((Array) mReturnColumnValues).GetValue(0)); 
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
						mReturnColumnValues = DBNull.Value; 
						if (!SystemProcedure2.IsItEmpty(mRecordEntryIDValue, SystemVariables.DataType.StringType))
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							if (!SystemProcedure2.IsItEmpty(rsMasterRecordset.Tables[0].Rows[0]["linked_form_id"], SystemVariables.DataType.NumberType))
							{
								this.Hide();
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								SystemForms.GetSystemForm(Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["linked_form_id"]), 2, mRecordEntryIDValue);
							}
							else
							{
								MessageBox.Show("Associated form not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								grdRecordsCriteria.Focus();
							}
						}
						else
						{
							MessageBox.Show("No records selected", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							grdRecordsCriteria.Focus();
						} 
						 
						break;
					case mButtonCustomize : 
						GetFindOptions(); 
						grdRecordsCriteria.Focus(); 
						break;
					case mButtonSave : 
						SaveReportDefinition(); 
						grdRecordsCriteria.Focus(); 
						break;
					case mButtonCancel : 
						SeekRecord(-1); 
						this.Hide(); 
						break;
					case mButtonHelp : 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void btnReportOptions_AccessKeyPress(int Index, int KeyAscii)
		{
			try
			{
				btnReportOptions_Click(btnReportOptions[Index], new EventArgs());
			}
			catch
			{
			}
		}

		private void FormatFormAppearence()
		{
			//Dim btnObjects As Control

			//mnuColors.ActiveMenuBar.Visible = False

			//Me.BackColor = mnuColors.GetSpecialColor(XPCOLOR_3DSHADOW)
			//fraOuterShadow.BackColor = mnuColors.GetSpecialColor(XPCOLOR_3DFACE)
			//lblFindResult.BackColor = mnuColors.GetSpecialColor(XPCOLOR_3DFACE)
			//lblRecordsCriteria.BackColor = mnuColors.GetSpecialColor(XPCOLOR_3DFACE)
			//lblTips1.BackColor = mnuColors.GetSpecialColor(XPCOLOR_3DFACE)
			//chkCommonSettings(cbSubstringSearch).BackColor = mnuColors.GetSpecialColor(XPCOLOR_3DFACE)
			//chkCommonSettings(cbShowAllRecords).BackColor = mnuColors.GetSpecialColor(XPCOLOR_3DFACE)

			//mFixedHeaderBackColor = mnuColors.GetSpecialColor(XPCOLOR_MENUBAR_EXPANDED)
			//mFixedGridBackColor = vbWhite
			//mFilterBackColor = mnuColors.GetSpecialColor(XPCOLOR_HIGHLIGHT)
			//mResultGridHighlightColor = mnuColors.GetSpecialColor(XPCOLOR_HIGHLIGHT)

			//For Each btnObjects In Me.Controls
			//    If btnObjects.Name = "btnReportOptions" Then
			//        btnObjects.BackColor = mnuColors.GetSpecialColor(XPCOLOR_3DFACE)
			//        btnObjects.CaptionBackColor = mnuColors.GetSpecialColor(XPCOLOR_3DFACE)
			//        btnObjects.BackColorPop = mnuColors.GetSpecialColor(XPCOLOR_HIGHLIGHT)
			//        btnObjects.BackColorPush = mnuColors.GetSpecialColor(XPCOLOR_HIGHLIGHT_PUSHED)
			//        btnObjects.EdgeColor = mnuColors.GetSpecialColor(XPCOLOR_HIGHLIGHT_BORDER)
			//    End If
			//Next
		}

		private void SaveReportDefinition()
		{ //report save routine
			try
			{

				DialogResult ans = (DialogResult) 0;
				StringBuilder mysql = new StringBuilder();

				ans = MessageBox.Show("Are you sure you want to save the" + new String(' ', 8) + "\r" + "current find settings?", "System Reports", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (ans == System.Windows.Forms.DialogResult.Yes)
				{
					SystemVariables.gConn.BeginTransaction();


					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.MoveFirst();
					foreach (DataRow iteration_row in rsDetailsRecordset.Tables[0].Rows)
					{
						if (iteration_row["find_id"] == rsMasterRecordset.Tables[0].Rows[0]["find_id"])
						{


							mysql = new StringBuilder(" update SM_FIND_DETAILS ");
							mysql.Append(" set column_no =" + Conversion.Str(iteration_row["column_no"]));
							mysql.Append(" , l_field_caption ='" + Convert.ToString(iteration_row["l_field_caption"]).Trim() + "'");
							mysql.Append(" , a_field_caption =N'" + Convert.ToString(iteration_row["a_field_caption"]).Trim() + "'");
							mysql.Append(" , show_detail =" + ((Convert.ToBoolean(iteration_row["show_detail"])) ? 1 : 0).ToString());
							mysql.Append(" , field_alignment = '" + Convert.ToString(iteration_row["field_alignment"]) + "'");
							mysql.Append(" , default_width = " + Conversion.Str(iteration_row["default_width"]));
							//mySql = mySql & " , show_in_italic = " & IIf(.Fields("show_in_italic").Value = True, 1, 0)
							//mySql = mySql & " , show_in_bold = " & IIf(.Fields("show_in_bold").Value = True, 1, 0)
							mysql.Append(" where column_id = " + Conversion.Str(iteration_row["column_id"]));
							SqlCommand TempCommand = null;
							TempCommand = SystemVariables.gConn.CreateCommand();
							TempCommand.CommandText = mysql.ToString();
							TempCommand.ExecuteNonQuery();


						}
					}
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void txtCriteriaBox_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					if (Strings.Chr(KeyAscii).ToString() == "'")
					{
						KeyAscii = 0;
					}
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
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
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!SystemProcedure2.IsItEmpty(rsMasterRecordset.Tables[0].Rows[0]["linked_form_id"], SystemVariables.DataType.NumberType))
				{
					this.Hide();
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemForms.GetSystemForm(Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["linked_form_id"]), 1);
				}
				else
				{
					MessageBox.Show("Associated form not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					grdRecordsCriteria.Focus();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void saveRecord()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SaveReportDefinition();
				grdRecordsCriteria.Focus();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void SelectRecord()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (grdFindResult.Rows.Count > grdFindResult.Rows.Fixed && grdFindResult.Row == 0)
				{
					grdFindResult.Row = grdFindResult.Rows.Fixed;
				}
				SeekRecord(grdFindResult.Row);
				this.Hide();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void Options()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				GetFindOptions();
				grdRecordsCriteria.Focus();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void CloseForm()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SeekRecord(-1);
				this.Hide();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void CreateStatusBar()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				UCStatusBar = (XtremeCommandBars.StatusBar) tcbSystemForm.StatusBar;
				UCStatusBar.Visible = true;


				XtremeCommandBars.StatusBarPane Pane = UCStatusBar.AddPane(1);
				Pane.Text = "Total Records:";
				Pane.Caption = "No. of records";
				Pane.Button = true;
				Pane.Value = "";
				Pane.SetPadding(8, 0, 8, 0);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}
	}
}