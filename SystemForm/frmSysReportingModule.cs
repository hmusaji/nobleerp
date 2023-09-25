
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSysReportingModule
		: System.Windows.Forms.Form
	{

		public frmSysReportingModule()
{
InitializeComponent();
} 
 public  void frmSysReportingModule_old()
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


		private void frmSysReportingModule_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private clsToolbar oThisFormToolBar = null;
		private DataSet _rsReport = null;
		DataSet rsReport
		{
			get
			{
				if (_rsReport is null)
				{
					_rsReport = new DataSet();
				}
				return _rsReport;
			}
			set
			{
				_rsReport = value;
			}
		}

		private DataSet _rsReportParameter = null;
		DataSet rsReportParameter
		{
			get
			{
				if (_rsReportParameter is null)
				{
					_rsReportParameter = new DataSet();
				}
				return _rsReportParameter;
			}
			set
			{
				_rsReportParameter = value;
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

		private int mFindID = 0;
		private string mFindReturnColumnNo = "";
		private string mFindLableColumnNo = "";
		private string mFindWhereClause = "";
		private string mFindSecurityLedgerClause = "";
		private string mParameterType = "";

		private int mLocationFindID = 0;
		private string mLocationParameterType = "";
		private string mLocationFindReturnColumnNo = "";
		private string mLocationFindLableColumnNo = "";

		private string mVariablesSetSQL = "";
		private string mReportTitleFilter = "";

		private object mMasterDetails = null;
		private object mLocationDetails = null;

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


		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
					//ElseIf KeyCode = 27 Then
					//    Call cmdClose_Click
					//    Exit Sub
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			oThisFormToolBar = new clsToolbar();
			//tabMaster.top = ((frmSysMain.oSystemInformation.WorkAreaHeight - (frmSysMain.Height - frmSysMain.ScaleHeight) - Me.Height) / 2)
			//tabMaster.left = ((frmSysMain.oSystemInformation.WorkAreaWidth - (frmSysMain.Width - frmSysMain.ScaleWidth) - Me.Width) / 2)
			CreateGroupList();

			oThisFormToolBar.AttachObject(this); //, tcbSystemForm
			oThisFormToolBar.ShowNewButton = true;
			oThisFormToolBar.DisableNewButton = true;
			oThisFormToolBar.ShowSaveButton = true;
			oThisFormToolBar.DisableSaveButton = true;
			oThisFormToolBar.ShowPrintButton = true;
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.DisableHelpButton = true;
			this.WindowState = FormWindowState.Maximized;
			//**--check whether to allow column customization
			//.DisableColumnsButton = mEnableColumnCustomize

			//----------Advance Report Parameter---------
			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
			{
				lblAdvanceCostCode.Visible = true;
				txtAdvanceCostCode.Visible = true;
				txtDCostCenterName.Visible = true;
			}
			else
			{
				lblAdvanceCostCode.Visible = false;
				txtAdvanceCostCode.Visible = false;
				txtDCostCenterName.Visible = false;
			}


			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("project_costing")))
			{
				lblProjectCode.Visible = true;
				txtProjectCode.Visible = true;
				txtDProjectName.Visible = true;
			}
			else
			{
				lblProjectCode.Visible = false;
				txtProjectCode.Visible = false;
				txtDProjectName.Visible = false;
			}


			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_1")))
			{
				lblAnalysisCode1.Visible = true;
				txtAnalysisCode1.Visible = true;
				txtDAnalysisName1.Visible = true;
			}
			else
			{
				lblAnalysisCode1.Visible = false;
				txtAnalysisCode1.Visible = false;
				txtDAnalysisName1.Visible = false;
			}


			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_2")))
			{
				lblAnalysisCode2.Visible = true;
				txtAnalysisCode2.Visible = true;
				txtDAnalysisName2.Visible = true;
			}
			else
			{
				lblAnalysisCode2.Visible = false;
				txtAnalysisCode2.Visible = false;
				txtDAnalysisName2.Visible = false;
			}


			rptLevelSlider.Value = SystemVariables.gDefaultFinalReportLevel - 1;

			SystemProcedure.SetLabelCaption(this);
			lstGroup_ItemClick(lstGroup.FocusedItem);
		}


		public void CreateGroupList()
		{
			SqlDataReader rs = null;
			ListViewItem li = null;
			string mysql = "select distinct " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "rg.L_Group_Name" : "rg.a_Group_Name") + " as Group_Name";
			mysql = mysql + " , rg.group_id From SM_MODULES Mod ";
			mysql = mysql + " inner join sm_report_groups rg on mod.module_id = rg.module_id";
			mysql = mysql + " Where rg.show = 1 and mod.show = 1";
			mysql = mysql + " and group_id in (select distinct r.Group_Id ";
			mysql = mysql + " from SM_REPORTS r  inner join SM_MODULES sm  on r.module_id = sm.module_id ";
			mysql = mysql + " inner join SM_USER_GROUP_RIGHTS sugr on r.report_id = sugr.report_id ";
			mysql = mysql + " inner join SM_USERS su on su.group_cd = sugr.group_cd ";
			mysql = mysql + " inner join SM_Preferences sf on r.feature_id = sf.preference_id";
			mysql = mysql + " where su.user_cd =  1 and sm.show = 1  and sugr.right_level <> 0";
			mysql = mysql + " and r.show = 1  and sf.preference_value = '1'  and  Is_Form_Report = 0)";

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rs = sqlCommand.ExecuteReader();
			rs.Read();
			int i = 1;

			do 
			{
				//UPGRADE_ISSUE: (1046) MSComCtlLib.ListItems.Add Parameter 'SmallIcon' is not supported, and was removed. More Information: https://docs.mobilize.net/vbuc/ewis#1046
				li = lstGroup.Items.Insert(i - 1, Convert.ToString(rs["Group_name"]), "");
				i++;
			}
			while(rs.Read());

			rs.Close();
		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			tabMaster.Width = ((this.Width * 15 <= 200) ? 200 : this.Width * 15 - 200) / 15;
			tabMaster.Height = ((this.Height * 15 <= 500) ? 500 : this.Height * 15 - 500) / 15;

			lstGroup.Height = this.Height - 67;
			lstReport.Height = this.Height - 67;

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("switch_layout_in_arabic")))
			{
				SystemProcedure.SwitchLayout(this);
			}

		}

		private void lstGroup_ItemClick(ListViewItem Item)
		{
			ListViewItem li = null;

			HideControl();

			this.Text = "Reporting Module - " + lstGroup.FocusedItem.Text;
			string mysql = "select distinct " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "r.L_Report_Name" : "r.A_Report_Name") + " as Report_Name";
			mysql = mysql + " , r.Report_id, report_style_mode ";
			mysql = mysql + " from SM_REPORTS r ";
			mysql = mysql + " inner join SM_MODULES sm  on r.module_id = sm.module_id ";
			mysql = mysql + " inner join SM_USER_GROUP_RIGHTS sugr on r.report_id = sugr.report_id ";
			mysql = mysql + " inner join SM_USERS su on su.group_cd = sugr.group_cd ";
			mysql = mysql + " inner join SM_Preferences sf on r.feature_id = sf.preference_id";
			mysql = mysql + " where su.user_cd = " + Conversion.Str(SystemVariables.gLoggedInUserCode);
			mysql = mysql + " and sm.show = 1 ";
			mysql = mysql + " and sugr.right_level <> 0 ";
			mysql = mysql + " and r.show = 1 ";
			mysql = mysql + " and sf.preference_value = '1' ";
			mysql = mysql + " and  Is_Form_Report = 0 and r.Group_id=" + ReflectionHelper.GetPrimitiveValue<string>(Item.ImageKey);


			rsReport = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsReport.Tables.Clear();
			adap.Fill(rsReport);
			lstReport.Items.Clear();
			int i = 1;

			foreach (DataRow iteration_row in rsReport.Tables[0].Rows)
			{
				//UPGRADE_ISSUE: (1046) MSComCtlLib.ListItems.Add Parameter 'SmallIcon' is not supported, and was removed. More Information: https://docs.mobilize.net/vbuc/ewis#1046
				li = lstReport.Items.Insert(i - 1, Convert.ToString(iteration_row["Report_Name"]), "");
				i++;
			}

			//rs.Close

			lstReport.Columns[0].Text = lstGroup.FocusedItem.Text;
			//UPGRADE_ISSUE: (2064) MSComctlLib.IColumnHeader property lstReport.ColumnHeaders.Icon was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			lstReport.Columns[0].setIcon(Item.ImageKey);
			if (rsReport.Tables[0].Rows.Count > 0)
			{
				lstReport_ItemClick(lstReport.FocusedItem);
			}
		}

		//Private Sub lstReport_Click()
		//rsReport.MoveFirst
		//rsReport.Move lstReport.SelectedItem.Index - 1
		//'Call GetSystemReport(rsReport.Fields("Report_id").Value, 1, , CStr(mFromDate), CStr(mToDate))
		//ShowParameter (rsReport.Fields("Report_id").Value)
		//End Sub
		//Private Sub lstReport_ItemCheck(ByVal Item As MSComctlLib.ListItem)
		//Call GetSystemReport(51001050, 2, , CStr(mFromDate), CStr(mToDate))
		//End Sub

		private void ShowParameter(int mReportId)
		{
			string mControlName = "";

			if (mReportId == 42004000 || mReportId == 42006500 || mReportId == 44001001 || mReportId == 44002001 || mReportId == 44003001 || mReportId == 44002000 || mReportId == 44002002)
			{
				fraOptions.Top = 159;
				fraOptions.Visible = true;
				fraCostCenter.Top = 139;
				fraCostCenter.Visible = true;


				switch(mReportId)
				{
					case 42004000 : case 42006500 :  //Group Summary 
						txtGroupPrefix.Text = "["; 
						txtGroupSuffix.Text = "]"; 
						break;
					case 44001001 : case 44002001 : case 44003001 :  //trial balance report (normal), 'trading and profit & loss a/c report (normal) 
						//balance sheet report (normal) 
						txtGroupPrefix.Text = "["; 
						txtGroupSuffix.Text = "]"; 
						txtTabSpaceInTree.Value = 10; 
						break;
					case 44002002 : 
						fraOptions.Visible = false; 
						 
						break;
				}
			}
			else
			{
				fraOptions.Visible = false;
				fraCostCenter.Visible = false;
			}

			string mysql = "select parameter_name, Parameter_Type, control_name, find_id, find_return_column,";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "control_caption" : "A_control_caption") + " as control_caption";
			mysql = mysql + ", " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Lable_Find_column" : "A_Lable_Find_column");
			mysql = mysql + " as Lable_Find_column, Report_Filter_Id, default_value, comments, OPTIONAL from sm_report_parameter";
			mysql = mysql + " where show = 1 and report_id = " + mReportId.ToString();
			rsReportParameter = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsReportParameter.Tables.Clear();
			adap.Fill(rsReportParameter);
			HideControl();

			DataSet withVar = null;
			foreach (DataRow iteration_row in rsReportParameter.Tables[0].Rows)
			{

				withVar = rsReportParameter;
				mControlName = Convert.ToString(withVar.Tables[0].Rows[0]["control_name"]);

				switch(mControlName)
				{
					case "txtFromDate" : 
						fraDateRange.Visible = true; 
						txtFromDate.Visible = true; 
						lblFromDate.Visible = true; 
						 
						lblFromDate.Caption = Convert.ToString(withVar.Tables[0].Rows[0]["control_caption"]); 
						 
						if (SystemVariables.gRestrictBackDatedReport)
						{
							//UPGRADE_WARNING: (1068) GetDefaultValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtFromDate.Value = ReflectionHelper.GetPrimitiveValue(GetDefaultValue("CurrentDate"));
							//UPGRADE_WARNING: (1068) GetDefaultValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtFromDate.MinDate = ReflectionHelper.GetPrimitiveValue(GetDefaultValue("CurrentDate"));
						}
						else if (!withVar.Tables[0].Rows[0].IsNull("Default_Value"))
						{ 
							//UPGRADE_WARNING: (1068) GetDefaultValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtFromDate.Value = ReflectionHelper.GetPrimitiveValue(GetDefaultValue(Convert.ToString(withVar.Tables[0].Rows[0]["Default_Value"])));
						} 
						 
						break;
					case "txtToDate" : 
						fraDateRange.Visible = true; 
						txtToDate.Visible = true; 
						lblToDate.Visible = true; 
						lblToDate.Caption = Convert.ToString(withVar.Tables[0].Rows[0]["control_caption"]); 
						 
						if (SystemVariables.gRestrictBackDatedReport)
						{
							//UPGRADE_WARNING: (1068) GetDefaultValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtToDate.Value = ReflectionHelper.GetPrimitiveValue(GetDefaultValue("CurrentDate"));
							//UPGRADE_WARNING: (1068) GetDefaultValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtToDate.MinDate = ReflectionHelper.GetPrimitiveValue(GetDefaultValue("CurrentDate"));

						}
						else if (!withVar.Tables[0].Rows[0].IsNull("Default_Value"))
						{ 
							//UPGRADE_WARNING: (1068) GetDefaultValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtToDate.Value = ReflectionHelper.GetPrimitiveValue(GetDefaultValue(Convert.ToString(withVar.Tables[0].Rows[0]["Default_Value"])));
						} 
						 
						break;
					case "txtFromVoucherNo" : 
						fraVoucherRange.Visible = true; 
						lblFromVoucherNo.Visible = true; 
						txtFromVoucherNo.Visible = true; 
						lblFromVoucherNo.Caption = Convert.ToString(withVar.Tables[0].Rows[0]["control_caption"]); 
						 
						txtFromVoucherNo.IsRequired = ((withVar.Tables[0].Rows[0].IsNull("OPTIONAL")) ? 1 : ~Convert.ToInt32(withVar.Tables[0].Rows[0]["OPTIONAL"])) != 0; 
						 
						if (!withVar.Tables[0].Rows[0].IsNull("Default_Value"))
						{
							//UPGRADE_WARNING: (1068) GetDefaultValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtFromVoucherNo.Text = ReflectionHelper.GetPrimitiveValue<string>(GetDefaultValue(Convert.ToString(withVar.Tables[0].Rows[0]["Default_Value"])));
						} 
						 
						break;
					case "txtToVoucherNo" : 
						fraVoucherRange.Visible = true; 
						lblToVoucherNo.Visible = true; 
						txtToVoucherNo.Visible = true; 
						lblToVoucherNo.Caption = Convert.ToString(withVar.Tables[0].Rows[0]["control_caption"]); 
						txtToVoucherNo.IsRequired = ((withVar.Tables[0].Rows[0].IsNull("OPTIONAL")) ? 1 : ~Convert.ToInt32(withVar.Tables[0].Rows[0]["OPTIONAL"])) != 0; 
						 
						if (!withVar.Tables[0].Rows[0].IsNull("Default_Value"))
						{
							//UPGRADE_WARNING: (1068) GetDefaultValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtToVoucherNo.Text = ReflectionHelper.GetPrimitiveValue<string>(GetDefaultValue(Convert.ToString(withVar.Tables[0].Rows[0]["Default_Value"])));
						} 
						 
						break;
					case "txtMasterCode" : 
						mFindID = Convert.ToInt32(withVar.Tables[0].Rows[0]["find_id"]); 
						mFindReturnColumnNo = Convert.ToString(withVar.Tables[0].Rows[0]["find_return_column"]); 
						mFindLableColumnNo = Convert.ToString(withVar.Tables[0].Rows[0]["Lable_Find_column"]); 
						mParameterType = Convert.ToString(withVar.Tables[0].Rows[0]["Parameter_Type"]); 
						lblMasterCode.Visible = true; 
						txtMasterCode.Visible = true; 
						lblMasterCode.Caption = Convert.ToString(withVar.Tables[0].Rows[0]["control_caption"]); 
						txtMasterName.Visible = true; 
						txtMasterCode.IsRequired = ((withVar.Tables[0].Rows[0].IsNull("OPTIONAL")) ? 1 : ~Convert.ToInt32(withVar.Tables[0].Rows[0]["OPTIONAL"])) != 0; 
						 
						if (!withVar.Tables[0].Rows[0].IsNull("Default_Value"))
						{
							//UPGRADE_WARNING: (1068) GetDefaultValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtMasterCode.Text = ReflectionHelper.GetPrimitiveValue<string>(GetDefaultValue(Convert.ToString(withVar.Tables[0].Rows[0]["Default_Value"])));
						} 
						break;
					case "txtLocationCode" : 
						mLocationFindID = Convert.ToInt32(withVar.Tables[0].Rows[0]["find_id"]); 
						mLocationFindReturnColumnNo = Convert.ToString(withVar.Tables[0].Rows[0]["find_return_column"]); 
						mLocationFindLableColumnNo = Convert.ToString(withVar.Tables[0].Rows[0]["Lable_Find_column"]); 
						mLocationParameterType = Convert.ToString(withVar.Tables[0].Rows[0]["Parameter_Type"]); 
						lblLocationCode.Visible = true; 
						txtLocationCode.Visible = true; 
						lblLocationCode.Caption = Convert.ToString(withVar.Tables[0].Rows[0]["control_caption"]); 
						txtLocationName.Visible = true; 
						txtLocationCode.IsRequired = ((withVar.Tables[0].Rows[0].IsNull("OPTIONAL")) ? 1 : ~Convert.ToInt32(withVar.Tables[0].Rows[0]["OPTIONAL"])) != 0; 
						 
						if (!withVar.Tables[0].Rows[0].IsNull("Default_Value"))
						{
							//UPGRADE_WARNING: (1068) GetDefaultValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtLocationCode.Text = ReflectionHelper.GetPrimitiveValue<string>(GetDefaultValue(Convert.ToString(withVar.Tables[0].Rows[0]["Default_Value"])));
						} 
						 
						break;
					case "cmbReportFilter" : 
						lblReportFilter.Visible = true; 
						cmbReportFilter.Visible = true; 
						lblReportFilter.Caption = Convert.ToString(withVar.Tables[0].Rows[0]["control_caption"]); 
						FillReportParameter(cmbReportFilter, Convert.ToString(withVar.Tables[0].Rows[0]["Report_Filter_Id"])); 
						SystemCombo.SearchCombo(cmbReportFilter, Convert.ToInt32(withVar.Tables[0].Rows[0]["Default_Value"])); 
						break;
				}


			}

		}


		private void HideControl()
		{
			lblMasterCode.Visible = false;
			txtMasterCode.Visible = false;
			txtMasterCode.Text = "";
			txtMasterName.Visible = false;
			txtMasterName.Text = "";

			lblLocationCode.Visible = false;
			txtLocationCode.Visible = false;
			txtLocationCode.Text = "";
			txtLocationName.Visible = false;
			txtLocationName.Text = "";

			lblCostCenterCode.Visible = false;
			txtCostCenterCode.Visible = false;
			txtCostCenterCode.Text = "";

			fraDateRange.Visible = false;
			lblFromDate.Visible = false;
			lblToDate.Visible = false;
			txtFromDate.Visible = false;
			txtToDate.Visible = false;

			fraVoucherRange.Visible = false;
			txtFromVoucherNo.Visible = false;
			txtFromVoucherNo.Text = "";

			txtToVoucherNo.Visible = false;
			txtToVoucherNo.Text = "";
			lblFromVoucherNo.Visible = false;
			lblToVoucherNo.Visible = false;

			lblReportFilter.Visible = false;
			cmbReportFilter.Visible = false;
		}


		private void FindRoutine(string pObjectName)
		{
			string mLocationFindWhereClause = "";
			object mTempSearchValue = null;


			switch(pObjectName)
			{
				case "txtMasterCode" : 
					txtMasterCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(mFindID, mFindReturnColumnNo, mFindWhereClause, true, false, "", true, true, false, mFindSecurityLedgerClause)); 
					 
					break;
				case "txtLocationCode" : 
					txtLocationCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(mLocationFindID, mLocationFindReturnColumnNo, mLocationFindWhereClause, true, false, "", true, true, false, mFindSecurityLedgerClause)); 
					 
					break;
				case "txtCostCenterCode" : 
					txtCostCenterCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000110, "882", "", true, false, "", true, true)); 
					 
					break;
				case "txtAdvanceCostCode" : 
					txtAdvanceCostCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000110, "882", "", true, false, "", true, true)); 
					 
					break;
				case "txtProjectCode" : 
					txtProjectCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000130, "985", "", true, false, "", true, true)); 
					 
					break;
				case "txtAnalysisCode1" : 
					txtAnalysisCode1.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1008000, "1622", "anly_head_no = 1", true, false, "", true, true)); 
					 
					break;
				case "txtAnalysisCode2" : 
					txtAnalysisCode2.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1008000, "1622", "anly_head_no = 2", true, false, "", true, true)); 
					 
					break;
				default:
					return;
			}


			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{


				switch(pObjectName)
				{
					case "txtMasterCode" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtMasterCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(2)); 
						//mMasterDetails = mTempSearchValue 
						txtMasterCode_Leave(txtMasterCode, new EventArgs()); 
						 
						break;
					case "txtLocationCode" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtLocationCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(2)); 
						//mLocationDetails = mTempSearchValue 
						txtLocationCode_Leave(txtLocationCode, new EventArgs()); 
						 
						break;
					case "txtCostCenterCode" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtCostCenterCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)); 
						//Call txtCostCenterCode_LostFocus 
						 
						break;
					case "txtAdvanceCostCode" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtAdvanceCostCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)); 
						 
						break;
					case "txtProjectCode" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtProjectCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(2)); 
						//Call txtProjectCode_LostFocus 
						 
						break;
					case "txtAnalysisCode1" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtAnalysisCode1.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(2)); 
						//Call txtAnalysisCode1_LostFocus 
						 
						break;
					case "txtAnalysisCode2" : 
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						txtAnalysisCode2.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(2)); 
						//Call txtAnalysisCode2_LostFocus 
						break;
				}

			}

		}


		private void lstReport_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsReport.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsReport.MoveFirst();
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsReport.Move was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsReport.Move_Renamed(lstReport.FocusedItem.Index + 1 - 1, null);
			//Call GetSystemReport(rsReport.Fields("Report_id").Value, 1, , CStr(mFromDate), CStr(mToDate))
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			PreviewReport(Convert.ToInt32(rsReport.Tables[0].Rows[0]["Report_id"]));
		}


		private void lstReport_ItemClick(ListViewItem Item)
		{
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsReport.AbsolutePosition was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			if (((int) rsReport.getAbsolutePosition()) != lstReport.FocusedItem.Index + 1)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsReport.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsReport.MoveFirst();
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsReport.Move was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsReport.Move_Renamed(lstReport.FocusedItem.Index + 1 - 1, null);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				ShowParameter(Convert.ToInt32(rsReport.Tables[0].Rows[0]["Report_id"]));
			}
		}

		private void lstReport_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				if (KeyAscii == 13)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsReport.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsReport.MoveFirst();
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsReport.Move was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsReport.Move_Renamed(lstReport.FocusedItem.Index + 1 - 1, null);
					//Call GetSystemReport(rsReport.Fields("Report_id").Value, 1, , CStr(mFromDate), CStr(mToDate))
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					PreviewReport(Convert.ToInt32(rsReport.Tables[0].Rows[0]["Report_id"]));
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



		private void txtAdvanceCostCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine(this.ActiveControl.Name);
		}

		private void txtAdvanceCostCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;
			try
			{

				if (!SystemProcedure2.IsItEmpty(txtAdvanceCostCode.Text, SystemVariables.DataType.NumberType))
				{
					mysql = " select ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cost_name" : "a_cost_name");
					mysql = mysql + " from gl_cost_centers ";
					mysql = mysql + " where cost_no=" + txtAdvanceCostCode.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						txtDCostCenterName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDCostCenterName.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}

				}
				else
				{
					txtDCostCenterName.Text = "";
				}
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mMasterDetails = DBNull.Value;

				if (mReturnErrorType == 4)
				{
					txtAdvanceCostCode.Focus();
				}
			}

		}

		private void txtLocationCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine(this.ActiveControl.Name);
		}

		private void txtMasterCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine(this.ActiveControl.Name);
		}


		public void PrintReport()
		{
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsReport.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsReport.MoveFirst();
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsReport.Move was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsReport.Move_Renamed(lstReport.FocusedItem.Index + 1 - 1, null);
			//Call GetSystemReport(rsReport.Fields("Report_id").Value, 1, , CStr(mFromDate), CStr(mToDate))
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			PreviewReport(Convert.ToInt32(rsReport.Tables[0].Rows[0]["Report_id"]));
		}


		private void PreviewReport(int mReportId)
		{
			string mControlName = "";
			string mTempFromDate = "";
			string mTempToDate = "";

			string mParameterValueList = "";
			string mParameterNameList = "";
			string mParameterTypeList = "";
			int i = 0;
			DataSet withVar = null;
			DataSet withVar_2 = null;
			if (ValidateData())
			{


				if (txtFromDate.Visible)
				{
					//UPGRADE_WARNING: (1068) txtFromDate.Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempFromDate = ReflectionHelper.GetPrimitiveValue<string>(txtFromDate.Value);
				}
				else
				{
					mTempFromDate = SystemVariables.gCurrentPeriodStarts;
				}

				if (txtToDate.Visible)
				{
					//UPGRADE_WARNING: (1068) txtToDate.Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempToDate = ReflectionHelper.GetPrimitiveValue<string>(txtToDate.Value);
				}
				else
				{
					mTempToDate = SystemVariables.gCurrentPeriodEnds;
				}

				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("maintain_date_and_time_in_transactions")))
				{
					mTempFromDate = StringsHelper.Format(mTempFromDate, SystemVariables.gSystemDateFormat);
					mTempToDate = StringsHelper.Format(mTempToDate, SystemVariables.gSystemDateFormat); //txtToDate.Value

				}
				else
				{
					mTempFromDate = StringsHelper.Format(mTempFromDate, SystemVariables.gSystemDateFormat) + " 00:00:00 ";
					mTempToDate = StringsHelper.Format(mTempToDate, SystemVariables.gSystemDateFormat) + " 23:59:29 ";

				}

				mVariablesSetSQL = "";
				mReportTitleFilter = "";

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToDouble(rsReport.Tables[0].Rows[0]["report_style_mode"]) == 11)
				{

					if (rsReportParameter.Tables[0].Rows.Count == 0)
					{
						//
					}
					else
					{
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsReportParameter.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsReportParameter.MoveFirst();
						i = 1;

						foreach (DataRow iteration_row in rsReportParameter.Tables[0].Rows)
						{

							withVar = rsReportParameter;
							mControlName = Convert.ToString(withVar.Tables[0].Rows[0]["control_name"]);

							mParameterNameList = mParameterNameList + Convert.ToString(withVar.Tables[0].Rows[0]["Parameter_Name"]);
							mParameterTypeList = mParameterTypeList + Convert.ToString(withVar.Tables[0].Rows[0]["Parameter_Type"]);


							switch(mControlName)
							{
								case "txtMasterCode" : 
									mParameterValueList = mParameterValueList + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(0)).Trim(); 
									break;
								case "txtLocationCode" : 
									mParameterValueList = mParameterValueList + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(0)).Trim(); 
									break;
								case "txtFromDate" : 
									mParameterValueList = mParameterValueList + "'" + mTempFromDate + "'"; 
									break;
								case "txtToDate" : 
									mParameterValueList = mParameterValueList + "'" + mTempToDate + "'"; 
									break;
								case "txtFromVoucherNo" : 
									if (Convert.ToString(withVar.Tables[0].Rows[0]["Parameter_Type"]) == "C")
									{
										mParameterValueList = mParameterValueList + "'" + txtFromVoucherNo.Text + "'";
									}
									else
									{
										mParameterValueList = mParameterValueList + txtFromVoucherNo.Text;
									} 
									 
									break;
								case "txtToVoucherNo" : 
									if (Convert.ToString(withVar.Tables[0].Rows[0]["Parameter_Type"]) == "C")
									{
										mParameterValueList = mParameterValueList + "'" + txtToVoucherNo.Text + "'";
									}
									else
									{
										mParameterValueList = mParameterValueList + txtToVoucherNo.Text;
									} 
									break;
								case "cmbReportFilter" : 
									mParameterValueList = mParameterValueList + cmbReportFilter.GetItemData(cmbReportFilter.ListIndex).ToString(); 
									break;
							}
							if (i < rsReportParameter.Tables[0].Rows.Count)
							{
								mParameterNameList = mParameterNameList + ",";
								mParameterTypeList = mParameterTypeList + ",";
								mParameterValueList = mParameterValueList + ",";
							}
							i++;
						}
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						SystemReports.OpenCrystalReport(Convert.ToInt32(rsReport.Tables[0].Rows[0]["Report_id"]), mParameterNameList, mParameterTypeList, mParameterValueList);
					}
				}
				else
				{

					if (rsReportParameter.Tables[0].Rows.Count == 0)
					{
						//
					}
					else
					{
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsReportParameter.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsReportParameter.MoveFirst();

						foreach (DataRow iteration_row_2 in rsReportParameter.Tables[0].Rows)
						{

							withVar_2 = rsReportParameter;
							mControlName = Convert.ToString(withVar_2.Tables[0].Rows[0]["control_name"]);


							switch(mControlName)
							{
								case "txtMasterCode" : 
									if (!SystemProcedure2.IsItEmpty(txtMasterCode.Text, SystemVariables.DataType.StringType))
									{
										mVariablesSetSQL = mVariablesSetSQL + " set " + Convert.ToString(withVar_2.Tables[0].Rows[0]["Parameter_Name"]) + "=" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mMasterDetails).GetValue(0)).Trim();
										mReportTitleFilter = mReportTitleFilter + Convert.ToString(withVar_2.Tables[0].Rows[0]["Control_Caption"]) + " : " + txtMasterCode.Text + " - " + txtMasterName.Text + new String(' ', 10); //& "Location Code : " & Str(txtLocationCode.Text) & Space(110) & "From Voucher No : " & txtFromVoucherNo.Text & Space(10) & "To Voucher No : " & Str(txtToVoucherNo.Text)
									} 
									break;
								case "txtLocationCode" : 
									if (!SystemProcedure2.IsItEmpty(txtLocationCode.Text, SystemVariables.DataType.StringType))
									{
										mVariablesSetSQL = mVariablesSetSQL + " set " + Convert.ToString(withVar_2.Tables[0].Rows[0]["Parameter_Name"]) + "=" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(0)).Trim();
										mReportTitleFilter = mReportTitleFilter + Convert.ToString(withVar_2.Tables[0].Rows[0]["Control_Caption"]) + " : " + txtLocationCode.Text + " - " + txtLocationName.Text;
									} 
									break;
								case "txtFromDate" : 
									mVariablesSetSQL = mVariablesSetSQL + " set " + Convert.ToString(withVar_2.Tables[0].Rows[0]["Parameter_Name"]) + "= '" + mTempFromDate + "'"; 
									 
									break;
								case "txtToDate" : 
									mVariablesSetSQL = mVariablesSetSQL + " set " + Convert.ToString(withVar_2.Tables[0].Rows[0]["Parameter_Name"]) + "= '" + mTempToDate + "'"; 
									break;
								case "txtFromVoucherNo" : 
									if (!SystemProcedure2.IsItEmpty(txtFromVoucherNo.Text, SystemVariables.DataType.StringType))
									{
										if (Convert.ToString(withVar_2.Tables[0].Rows[0]["Parameter_Type"]) == "C")
										{
											mVariablesSetSQL = mVariablesSetSQL + " set " + Convert.ToString(withVar_2.Tables[0].Rows[0]["Parameter_Name"]) + "= '" + txtFromVoucherNo.Text + "'";
										}
										else
										{
											mVariablesSetSQL = mVariablesSetSQL + " set " + Convert.ToString(withVar_2.Tables[0].Rows[0]["Parameter_Name"]) + "= " + txtFromVoucherNo.Text;
										}

										mReportTitleFilter = mReportTitleFilter + Convert.ToString(withVar_2.Tables[0].Rows[0]["Control_Caption"]) + " : " + txtFromVoucherNo.Text + new String(' ', 10);
									} 
									break;
								case "txtToVoucherNo" : 
									if (!SystemProcedure2.IsItEmpty(txtToVoucherNo.Text, SystemVariables.DataType.StringType))
									{
										if (Convert.ToString(withVar_2.Tables[0].Rows[0]["Parameter_Type"]) == "C")
										{
											mVariablesSetSQL = mVariablesSetSQL + " set " + Convert.ToString(withVar_2.Tables[0].Rows[0]["Parameter_Name"]) + "= '" + txtToVoucherNo.Text + "'";
										}
										else
										{
											mVariablesSetSQL = mVariablesSetSQL + " set " + Convert.ToString(withVar_2.Tables[0].Rows[0]["Parameter_Name"]) + "= " + txtToVoucherNo.Text;
										}

										mReportTitleFilter = mReportTitleFilter + Convert.ToString(withVar_2.Tables[0].Rows[0]["Control_Caption"]) + " : " + txtToVoucherNo.Text + new String(' ', 10);
									} 
									break;
								case "cmbReportFilter" : 
									mVariablesSetSQL = mVariablesSetSQL + " set " + Convert.ToString(withVar_2.Tables[0].Rows[0]["Parameter_Name"]) + "= " + cmbReportFilter.GetItemData(cmbReportFilter.ListIndex).ToString(); 
									mReportTitleFilter = mReportTitleFilter + Convert.ToString(withVar_2.Tables[0].Rows[0]["Control_Caption"]) + " : " + cmbReportFilter.Text + new String(' ', 10); 
									 
									break;
							}


						}

					}

					if (fraOptions.Visible)
					{
						switch(mReportId)
						{
							case 42004000 : case 44001001 : case 44002001 : case 44003001 : 
								//**-------30-jan-2014 
								mVariablesSetSQL = mVariablesSetSQL + " set @ReportLevel = " + rptLevelSlider.Value.ToString(); 
								 
								if (!SystemProcedure2.IsItEmpty(txtAdvanceCostCode.Text, SystemVariables.DataType.NumberType))
								{
									mVariablesSetSQL = mVariablesSetSQL + " set @CostCenterCode = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select cost_cd from gl_cost_centers where cost_no = " + txtAdvanceCostCode.Text));
								}
								else
								{
									mVariablesSetSQL = mVariablesSetSQL + " set @CostCenterCode = null";
								} 

								 
								if (!SystemProcedure2.IsItEmpty(txtProjectCode.Text, SystemVariables.DataType.StringType))
								{
									mVariablesSetSQL = mVariablesSetSQL + " set @ProjectCode = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select project_cd from PROJ_Projects where project_no = '" + txtProjectCode.Text + "'"));
								}
								else
								{
									mVariablesSetSQL = mVariablesSetSQL + " set @ProjectCode = null";
								} 

								 
								if (!SystemProcedure2.IsItEmpty(txtAnalysisCode1.Text, SystemVariables.DataType.StringType))
								{
									mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode1 ='" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select anly_code from gl_analysis where anly_head_no = 1 and anly_code = '" + txtAnalysisCode1.Text.Trim() + "'")) + "'";
								}
								else
								{
									mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode1 = null";
								} 

								 
								if (!SystemProcedure2.IsItEmpty(txtAnalysisCode2.Text, SystemVariables.DataType.StringType))
								{
									mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode2 ='" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select anly_code from gl_analysis where anly_head_no = 2 and anly_code = '" + txtAnalysisCode2.Text.Trim() + "'")) + "'";
								}
								else
								{
									mVariablesSetSQL = mVariablesSetSQL + " set @AnalysisCode2 = null";
								} 
								 
								//            mVariablesSetSQL = mVariablesSetSQL + " set @ShowCYOpeningBalance = " & IIf(chkShowCYOpeningBalance.Value = vbUnchecked, "0", "1") 
								//            mVariablesSetSQL = mVariablesSetSQL + " set @ShowCYCurrentBalance = " & IIf(chkShowCYCurrentBalance.Value = vbUnchecked, "0", "1") 
								//            mVariablesSetSQL = mVariablesSetSQL + " set @ShowCYProfitAndLoss = " & IIf(chkShowCYProfitAndLoss.Value = vbUnchecked, "0", "1") 
								//            mVariablesSetSQL = mVariablesSetSQL + " set @ShowLYOpeningBalance = " & IIf(chkShowLYOpeningBalance.Value = vbUnchecked, "0", "1") 
								//            mVariablesSetSQL = mVariablesSetSQL + " set @ShowLYCurrentBalance = " & IIf(chkShowCYCurrentBalance.Value = vbUnchecked, "0", "1") 
								//            mVariablesSetSQL = mVariablesSetSQL + " set @ShowLYProfitAndLoss = " & IIf(chkShowLYProfitAndLoss.Value = vbUnchecked, "0", "1") 
								//            mVariablesSetSQL = mVariablesSetSQL + " set @ShowLedgerWithZeroBalance = " & IIf(chkShowLedgerWithZeroBalance.Value = vbUnchecked, "0", "1") 
								mVariablesSetSQL = mVariablesSetSQL + " set @GroupPrefix = '" + txtGroupPrefix.Text.Trim() + "'"; 
								mVariablesSetSQL = mVariablesSetSQL + " set @GroupSuffix = '" + txtGroupSuffix.Text.Trim() + "'"; 
								mVariablesSetSQL = mVariablesSetSQL + " set @TabSpaceInTree = " + Conversion.Str(txtTabSpaceInTree.Value); 
								mVariablesSetSQL = mVariablesSetSQL + " set @ShowLedgerWithZeroBalance = " + ((chkShowLedgerWithZeroBalance.CheckState == CheckState.Unchecked) ? "0" : "1"); 
								//**-------------------------------------------------------------------------------- 

								 
								break;
						}
					}

					if (!fraOptions.Visible && fraCostCenter.Visible)
					{
						switch(mReportId)
						{
							case 44002002 : 
								if (!SystemProcedure2.IsItEmpty(txtAdvanceCostCode.Text, SystemVariables.DataType.NumberType))
								{
									mVariablesSetSQL = mVariablesSetSQL + " set @CostCenterCode = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select cost_cd from gl_cost_centers where cost_no = " + txtAdvanceCostCode.Text));
								}
								else
								{
									mVariablesSetSQL = mVariablesSetSQL + " set @CostCenterCode = null";
								} 
								break;
						}
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemReports.GetSystemReport(Convert.ToInt32(rsReport.Tables[0].Rows[0]["Report_id"]), 2, mVariablesSetSQL, mTempFromDate, mTempToDate, mReportTitleFilter);
				}
			}
			else
			{
				return;
			}

		}

		private object GetDefaultValue(string mDefault)
		{


			switch(mDefault)
			{
				case "FirstOfMonth" : 
					return DateTime.Parse("01-" + DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Today.Month).Trim() + "-" + Conversion.Str(DateTime.Today.Year)); 

				case "LastOfMonth" : 
					return DateTime.Parse("01-" + DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Today.Month).Trim() + "-" + Conversion.Str(DateTime.Today.Year)).AddMonths(1).AddDays(-1); 

				case "FirstOfYear" : 
					return DateTime.Parse("01-" + DateTimeFormatInfo.CurrentInfo.GetMonthName(1).Trim() + "-" + Conversion.Str(DateTime.Today.Year)); 

				case "LastOfYear" : 
					return DateTime.Parse("31-" + DateTimeFormatInfo.CurrentInfo.GetMonthName(12).Trim() + "-" + Conversion.Str(DateTime.Today.Year)); 

				case "CurrentDate" : 
					return DateTime.Today; 

				default:
					return mDefault;
			}

		}


		private bool ValidateData()
		{
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (txtMasterCode.Visible && txtMasterCode.Text == "" && txtMasterCode.IsRequired)
			{
				txtMasterCode.Focus();
				return false;
			}
			else if (txtLocationCode.Visible && txtLocationCode.Text == "" && txtMasterCode.IsRequired)
			{ 
				txtLocationCode.Focus();
				return false;
			}
			else if (txtFromDate.Visible && Convert.IsDBNull(txtFromDate.Value))
			{ 
				txtFromDate.Focus();
				return false;
			}
			else if (txtToDate.Visible && Convert.IsDBNull(txtToDate.Value))
			{ 
				txtToDate.Focus();
				return false;
			}
			else if (txtFromVoucherNo.Visible && txtFromVoucherNo.Text == "" && txtMasterCode.IsRequired)
			{ 
				txtFromVoucherNo.Focus();
				return false;
			}
			else if (txtToVoucherNo.Visible && txtToVoucherNo.Text == "" && txtMasterCode.IsRequired)
			{ 
				txtToVoucherNo.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private void txtMasterCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempSearchValue = null;
				if (txtMasterCode.Text != "")
				{
					//UPGRADE_WARNING: (1068) GetFindValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(GetFindValue(mFindID, mFindReturnColumnNo, mFindReturnColumnNo, txtMasterCode.Text, mParameterType));
					//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
					if (!Object.Equals(mTempSearchValue, null))
					{
						//UPGRADE_WARNING: (1068) GetFindValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtMasterName.Text = ReflectionHelper.GetPrimitiveValue<string>(GetFindValue(mFindID, mFindLableColumnNo, mFindReturnColumnNo, txtMasterCode.Text, mParameterType));
						//UPGRADE_WARNING: (1068) mTempSearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mMasterDetails = ReflectionHelper.GetPrimitiveValue(mTempSearchValue);
					}
					else
					{
						txtMasterCode.Text = "";
						txtMasterName.Text = "";
						throw new System.Exception("-9990002");
						throw new Exception();
					}
				}
				else
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mMasterDetails = DBNull.Value;
				}
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				txtMasterCode.Focus();
			}
		}

		private void txtLocationCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempSearchValue = null;
				if (txtLocationCode.Text != "")
				{
					//UPGRADE_WARNING: (1068) GetFindValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(GetFindValue(mLocationFindID, mLocationFindReturnColumnNo, mLocationFindReturnColumnNo, txtLocationCode.Text, mLocationParameterType));
					//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
					if (!Object.Equals(mTempSearchValue, null))
					{
						//UPGRADE_WARNING: (1068) GetFindValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLocationName.Text = ReflectionHelper.GetPrimitiveValue<string>(GetFindValue(mLocationFindID, mLocationFindLableColumnNo, mLocationFindReturnColumnNo, txtLocationCode.Text, mLocationParameterType));
						//UPGRADE_WARNING: (1068) mTempSearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLocationDetails = ReflectionHelper.GetPrimitiveValue(mTempSearchValue);
					}
					else
					{
						txtLocationCode.Text = "";
						txtLocationName.Text = "";
						throw new System.Exception("-9990002");
						throw new Exception();
					}
				}
				else
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mLocationDetails = DBNull.Value;
				}
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				txtLocationCode.Focus();
			}
		}

		public object GetFindValue(int mFindID, string mColumnID, string mFindWhereColumn, string mWhereValue, string mType)
		{
			object result = null;
			string mSQL = "";
			object mTempWhereColumn = null;
			string[] mTempColumnList = null;

			object mTempColumn = null;
			int Cnt = 0;

			StringBuilder mTempColumnName = new StringBuilder();
			if (mColumnID != "")
			{
				mTempColumnList = mColumnID.Split(',');
				for (Cnt = 0; Cnt <= mTempColumnList.GetUpperBound(0); Cnt++)
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempColumn = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Table_Id, Field_Id from SM_FIND_DETAILS where Column_Id = " + mTempColumnList[Cnt]));

					if (mTempColumnName.ToString() != "")
					{
						mTempColumnName.Append(", ");
					}
					mTempColumnName.Append(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempColumn).GetValue(0)) + "." + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempColumn).GetValue(1)));
				}
			}

			if (mFindWhereColumn != "")
			{
				mTempColumnList = mFindWhereColumn.Split(',');
				int tempForEndVar = mTempColumnList.GetUpperBound(0);
				for (Cnt = 1; Cnt <= tempForEndVar; Cnt++)
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempWhereColumn = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Table_Id, Field_Id from SM_FIND_DETAILS where Column_Id = " + mTempColumnList[Cnt]));
				}
			}

			//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempWhereColumn) && !Object.Equals(mTempWhereColumn, null))
			{
				mTempWhereColumn = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempWhereColumn).GetValue(0)) + "." + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempWhereColumn).GetValue(1));
			}

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			string mTempFromClause = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select from_clause from sm_find where find_id = " + mFindID.ToString()));
			//mTempColumnName = GetMasterCode("select Table_Id, Field_Id from SM_FIND_DETAILS where Column_Id = " & mColumnID)

			//If Not IsNull(mTempColumnName) Then
			//    mTempColumnName = mTempColumnName(0) & "." & mTempColumnName(1)
			//End If

			if (mType == "C")
			{
				mSQL = "select " + mTempColumnName.ToString() + " from " + mTempFromClause + " where " + ReflectionHelper.GetPrimitiveValue<string>(mTempWhereColumn) + " = '" + mWhereValue + "'";
			}
			else
			{
				mSQL = "select " + mTempColumnName.ToString() + " from " + mTempFromClause + " where " + ReflectionHelper.GetPrimitiveValue<string>(mTempWhereColumn) + " = " + mWhereValue;
			}

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempReturnValue))
			{
				result = mTempReturnValue;
			}
			return result;
		}

		public void CloseForm()
		{
			this.Close();
		}

		private void FillReportParameter(Control mComboBox, string mReportFilters)
		{


			DataSet rsReportFilters = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsReportFilters.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsReportFilters.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());

			string mysql = "select L_Filter_Name, Filter_Value from SM_REPORT_FILTERS where filter_type_id in (" + mReportFilters + ")";

			//    With rsReportFilters
			//        .MoveFirst
			//        Do While Not .EOF
			SystemCombo.FillComboWithItemData(mComboBox, mysql);

			//.MoveNext
			//        Loop
			//    End With
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}