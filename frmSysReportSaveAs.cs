
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSysReportSaveAs
		: System.Windows.Forms.Form
	{

		public frmSysReportSaveAs()
{
InitializeComponent();
} 
 public  void frmSysReportSaveAs_old()
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


		private void frmSysReportSaveAs_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private clsReportDefinition oReportDefinitionClass = null;
		private DataSet oMasterRecordset = null;
		private DataSet oDetailsRecordset = null;

		private bool mFormIsInitialized = false;

		public void AttachObjects(clsReportDefinition pReportClass, DataSet pMasterRecordset, DataSet pDetailsRecordset)
		{
			oReportDefinitionClass = pReportClass;
			oMasterRecordset = pMasterRecordset;
			oDetailsRecordset = pDetailsRecordset;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			mFormIsInitialized = true;
		}

		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			object mWhereClause = null;

			try
			{

				DialogResult ans = (DialogResult) 0;
				StringBuilder mysql = new StringBuilder();
				string mNewWhereClause = "";
				int newReportId = 0;
				string mHavingClause = "";

				ans = MessageBox.Show("Are you sure you want to save the" + new String(' ', 8) + "\r" + "current report?", "System Reports", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				int n = 0;
				int i = 0;
				if (ans == System.Windows.Forms.DialogResult.Yes)
				{
					SystemVariables.gConn.BeginTransaction();
					//gConn.CursorLocation = adUseClient

					newReportId = Convert.ToInt32(Double.Parse(SystemProcedure2.GetNewNumber("SM_Reports", "Report_Id", 4, "Group_Id = 13")));

					if (newReportId == 1)
					{
						newReportId = 13000001;
					}

					//UPGRADE_ISSUE: (2064) ADODB.Recordset method oDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oDetailsRecordset.MoveFirst();
					n = 1;
					foreach (DataRow iteration_row in oDetailsRecordset.Tables[0].Rows)
					{

						if (!SystemProcedure2.IsItEmpty(iteration_row["filter_condition"], SystemVariables.DataType.StringType))
						{
							if (!SystemProcedure2.IsItEmpty(mHavingClause, SystemVariables.DataType.StringType))
							{
								mHavingClause = mHavingClause + " " + Strings.Chr((int) Keys.Return).ToString() + "and " + Convert.ToString(iteration_row["filter_condition"]);
							}
							else
							{
								mHavingClause = Convert.ToString(iteration_row["filter_condition"]);
							}
						}
						n++;
					}


					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (!oMasterRecordset.Tables[0].Rows[0].IsNull("Where_Clause"))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mNewWhereClause = Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["Where_Clause"]);
					}

					if (!SystemProcedure2.IsItEmpty(mHavingClause, SystemVariables.DataType.StringType))
					{
						if (!SystemProcedure2.IsItEmpty(mWhereClause, SystemVariables.DataType.StringType))
						{
							mNewWhereClause = mNewWhereClause + " and " + mHavingClause;
						}
						else
						{
							mNewWhereClause = mHavingClause;
						}
					}

					mysql = new StringBuilder(" INSERT INTO SM_REPORTS (Report_Id,Module_Id,Feature_Id,Group_Id,Child_Report_Id,Child_Report_Id2,Child_Form_Id,Enable_Grouping");
					mysql.Append(",L_Report_Name,A_Report_Name,From_Clause,Where_Clause,Order_By_Clause,Variables_Declaration_SQL,Use_Where_Clause,Use_Distinct_Records");
					mysql.Append(",L_Report_Title1,A_Report_Title1,L_Report_Title2,A_Report_Title2,Show_Company_Name,Show_Addr1,Show_Addr2,Show_Report_Name,Show_Title1");
					mysql.Append(",Show_Title2,Show_Title_Filter_Condition,Show_Filter_Condition,Show_Drill_Down_Report,Show_Date_Range,Show_Filter_Tab,Show_Columns_Tab");
					mysql.Append(",Show_Fonts_Tab,Company_Font_Name,Address_Font_Name,Report_Name_Font_Name,Title1_Font_Name,Title2_Font_Name,Title_Filter_Font_Name");
					mysql.Append(",Date_Range_Font_Name,Details_Filter_Font_Name,Column_Header_Font_Name,Column_Details_Font_Name,Report_Totals_Font_Name,Page_Footer_Font_Name");
					mysql.Append(",Company_Font_Size,Address_Font_Size,Report_Name_Font_Size,Title1_Font_Size,Title2_Font_Size,Title_Filter_Font_Size,Date_Range_Font_Size");
					mysql.Append(",Details_Filter_Font_Size,Column_Header_Font_Size,Column_Details_Font_Size,Report_Totals_Font_Size,Page_Footer_Font_Size,Company_Font_Bold");
					mysql.Append(",Address_Font_Bold,Report_Name_Font_Bold,Title1_Font_Bold,Title2_Font_Bold,Title_Filter_Font_Bold,Date_Range_Font_Bold,Details_Filter_Font_Bold");
					mysql.Append(",Column_Header_Font_Bold,Column_Details_Font_Bold,Report_Totals_Font_Bold,Page_Footer_Font_Bold,Company_Font_Italic,Address_Font_Italic");
					mysql.Append(",Report_Name_Font_Italic,Title1_Font_Italic,Title2_Font_Italic,Title_Filter_Font_Italic,Date_Range_Font_Italic,Details_Filter_Font_Italic");
					mysql.Append(",Column_Header_Font_Italic,Column_Details_Font_Italic,Report_Totals_Font_Italic,Page_Footer_Font_Italic,Company_Font_Color,Address_Font_Color");
					mysql.Append(",Report_Name_Font_Color,Title1_Font_Color,Title2_Font_Color,Title_Filter_Font_Color,Date_Range_Font_Color,Details_Filter_Font_Color,Column_Header_Font_Color");
					mysql.Append(",Column_Details_Font_Color,Report_Totals_Font_Color,Page_Footer_Font_Color,Company_Font_Alignment,Address_Font_Alignment,Report_Name_Font_Alignment");
					mysql.Append(",Title1_Font_Alignment,Title2_Font_Alignment,Title_Filter_Font_Alignment,Date_Range_Font_Alignment,Details_Filter_Font_Alignment");
					mysql.Append(",Show_Report_Options_First,Allow_Design_Mode,Allow_Preview_Mode,First_Report_Mode,Repeat_Report_Header,Repeat_Page_Header,Monthly_Report");
					mysql.Append(",Auto_Size_Columns,Allow_Column_Groupings,Report_Style_Mode,Normal_Outline_Style_Type,Preview_Outline_Style_Type,Default_Report_Export_Type");
					mysql.Append(",Default_Report_Export_File_Name,Enable_Debit_Credit_Balancing,Outline_Parent_Colors,Outline_Child_Color,Show_Balance_At_End,Use_Multiple_Child_Reports");
					mysql.Append(",Expect_Language_Prefered,Show_Page_No_On_Print,Show_Current_Date_On_Print,Show_Current_Time_On_Print,Show_Record_Count_On_Print");
					mysql.Append(",Show_Report_Id_On_Print,Repeat_Report_Header_On_Each_Page,Comments,Show,Protected,User_Cd,User_Date_Time,External_Report_File_Name");
					mysql.Append(",A_External_Report_File_Name,Show_As_On_Date_Only,Sub_Report_Names,Print_Immediately_After_Display,Enable_Report_Options");
					mysql.Append(",Print_Without_Preview,datasource_initilization_script,datasource_cleanup_script,show_report_in_alternate_row_colors,report_from_date_caption");
					mysql.Append(",report_to_date_caption,From_Date_Parameter,To_Date_Parameter,Show_double_column_header,Show_double_report_header,Show_Verticle_Grid_Line");
					mysql.Append(",Show_Horizontal_Grid_Line,PaperSize,PrintDevice,Orientation,MarginTop,MarginBottom,MarginLeft,MarginRight,Cross_Tab,Is_Form_Report,show_report_footer");
					mysql.Append(",Footer_Text) ");
					mysql.Append(" select " + newReportId.ToString() + ", Module_Id,Feature_Id,13,Child_Report_Id,Child_Report_Id2,Child_Form_Id,Enable_Grouping");
					mysql.Append(",'" + txtEngName.Text + "',N'" + txtArabicName.Text + "',From_Clause,'" + mNewWhereClause + "',Order_By_Clause,Variables_Declaration_SQL,Use_Where_Clause,Use_Distinct_Records");
					mysql.Append(",L_Report_Title1,A_Report_Title1,L_Report_Title2,A_Report_Title2,Show_Company_Name,Show_Addr1,Show_Addr2,Show_Report_Name,Show_Title1");
					mysql.Append(",Show_Title2,Show_Title_Filter_Condition,Show_Filter_Condition,Show_Drill_Down_Report,Show_Date_Range,Show_Filter_Tab,Show_Columns_Tab");
					mysql.Append(",Show_Fonts_Tab,Company_Font_Name,Address_Font_Name,Report_Name_Font_Name,Title1_Font_Name,Title2_Font_Name,Title_Filter_Font_Name");
					mysql.Append(",Date_Range_Font_Name,Details_Filter_Font_Name,Column_Header_Font_Name,Column_Details_Font_Name,Report_Totals_Font_Name,Page_Footer_Font_Name");
					mysql.Append(",Company_Font_Size,Address_Font_Size,Report_Name_Font_Size,Title1_Font_Size,Title2_Font_Size,Title_Filter_Font_Size,Date_Range_Font_Size");
					mysql.Append(",Details_Filter_Font_Size,Column_Header_Font_Size,Column_Details_Font_Size,Report_Totals_Font_Size,Page_Footer_Font_Size,Company_Font_Bold");
					mysql.Append(",Address_Font_Bold,Report_Name_Font_Bold,Title1_Font_Bold,Title2_Font_Bold,Title_Filter_Font_Bold,Date_Range_Font_Bold,Details_Filter_Font_Bold");
					mysql.Append(",Column_Header_Font_Bold,Column_Details_Font_Bold,Report_Totals_Font_Bold,Page_Footer_Font_Bold,Company_Font_Italic,Address_Font_Italic");
					mysql.Append(",Report_Name_Font_Italic,Title1_Font_Italic,Title2_Font_Italic,Title_Filter_Font_Italic,Date_Range_Font_Italic,Details_Filter_Font_Italic");
					mysql.Append(",Column_Header_Font_Italic,Column_Details_Font_Italic,Report_Totals_Font_Italic,Page_Footer_Font_Italic,Company_Font_Color,Address_Font_Color");
					mysql.Append(",Report_Name_Font_Color,Title1_Font_Color,Title2_Font_Color,Title_Filter_Font_Color,Date_Range_Font_Color,Details_Filter_Font_Color,Column_Header_Font_Color");
					mysql.Append(",Column_Details_Font_Color,Report_Totals_Font_Color,Page_Footer_Font_Color,Company_Font_Alignment,Address_Font_Alignment,Report_Name_Font_Alignment");
					mysql.Append(",Title1_Font_Alignment,Title2_Font_Alignment,Title_Filter_Font_Alignment,Date_Range_Font_Alignment,Details_Filter_Font_Alignment");
					mysql.Append(",Show_Report_Options_First,Allow_Design_Mode,Allow_Preview_Mode,First_Report_Mode,Repeat_Report_Header,Repeat_Page_Header,Monthly_Report");
					mysql.Append(",Auto_Size_Columns,Allow_Column_Groupings,Report_Style_Mode,Normal_Outline_Style_Type,Preview_Outline_Style_Type,Default_Report_Export_Type");
					mysql.Append(",Default_Report_Export_File_Name,Enable_Debit_Credit_Balancing,Outline_Parent_Colors,Outline_Child_Color,Show_Balance_At_End,Use_Multiple_Child_Reports");
					mysql.Append(",Expect_Language_Prefered,Show_Page_No_On_Print,Show_Current_Date_On_Print,Show_Current_Time_On_Print,Show_Record_Count_On_Print");
					mysql.Append(",Show_Report_Id_On_Print,Repeat_Report_Header_On_Each_Page,Comments,Show,Protected,User_Cd,User_Date_Time,External_Report_File_Name");
					mysql.Append(",A_External_Report_File_Name,Show_As_On_Date_Only,Sub_Report_Names,Print_Immediately_After_Display,Enable_Report_Options");
					mysql.Append(",Print_Without_Preview,datasource_initilization_script,datasource_cleanup_script,show_report_in_alternate_row_colors,report_from_date_caption");
					mysql.Append(",report_to_date_caption,From_Date_Parameter,To_Date_Parameter,Show_double_column_header,Show_double_report_header,Show_Verticle_Grid_Line");
					mysql.Append(",Show_Horizontal_Grid_Line,PaperSize,PrintDevice,Orientation,MarginTop,MarginBottom,MarginLeft,MarginRight,Cross_Tab,Is_Form_Report,show_report_footer,Footer_Text");
					mysql.Append(" From SM_REPORTS");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql.Append(" where report_id = " + Conversion.Str(oMasterRecordset.Tables[0].Rows[0]["report_id"]));
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql.ToString();
					TempCommand.ExecuteNonQuery();

					mysql = new StringBuilder(" INSERT INTO SM_REPORT_PARAMETER (Report_Id,Feature_Id,Parameter_Name,Control_Name,Control_Caption,Find_Id,Find_Return_Column");
					mysql.Append(" ,L_Lable_Find_column,A_Lable_Find_column,Default_Value,Comments,Show,Protected,User_Date_Time,Parameter_Type,A_Control_Caption,Report_Filter_Id)");
					mysql.Append(" select " + newReportId.ToString() + ",Feature_Id,Parameter_Name,Control_Name,Control_Caption,Find_Id,Find_Return_Column");
					mysql.Append(" ,L_Lable_Find_column,A_Lable_Find_column,Default_Value,Comments,Show,Protected,User_Date_Time,Parameter_Type,A_Control_Caption,Report_Filter_Id ");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql.Append(" from SM_REPORT_PARAMETER where report_id = " + Conversion.Str(oMasterRecordset.Tables[0].Rows[0]["report_id"]));
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql.ToString();
					TempCommand_2.ExecuteNonQuery();

					mysql = new StringBuilder(" insert into sm_user_group_rights (report_id , right_level)");
					mysql.Append(" select " + newReportId.ToString() + " , Right_Level  from sm_user_group_rights ");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql.Append(" where report_id = " + Conversion.Str(oMasterRecordset.Tables[0].Rows[0]["report_id"]));
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql.ToString();
					TempCommand_3.ExecuteNonQuery();


					//UPGRADE_ISSUE: (2064) ADODB.Recordset method oDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oDetailsRecordset.MoveFirst();
					i = 1;
					foreach (DataRow iteration_row_2 in oDetailsRecordset.Tables[0].Rows)
					{

						mysql = new StringBuilder(" INSERT INTO SM_REPORT_FIELDS (Column_Id,Report_Id,Feature_Id,Column_No,Table_Id,Field_Id,Group_By_Field_Id,Linked_Parameter_Type");
						mysql.Append(" ,Linked_Parameter_Name,L_Field_Caption,A_Field_Caption,Field_Type,Field_Language,L_Field_Alignment,A_Field_Alignment,Show_Title,Show_Detail");
						mysql.Append(" ,Enable_Sorting,Enable_Group_Total,Enable_Grand_Total,Enable_Grand_Total_On_Top_Group,Get_Caption_SQL,Filter_Condition,Default_Width,Apply_Format");
						mysql.Append(" ,Round_No_Of_Digits,Format_Text_Type,Entry_Id_Column,Voucher_Type_Column,Month_Id_Column,Show_In_Column_Selection,Allow_Wrap_Text,Apply_Special_Format");
						mysql.Append(" ,Show_In_Bold,Show_In_Italic,Column_Back_Color,Column_Fore_Color,Column_Font_Name,Column_Font_Size,Column_Type,Formula_Columns_Definition");
						mysql.Append(" ,Formula_Columns_Calculation,Grouped_Column,Grouped_Caption,Insert_Line_Before_Total,Insert_Line_After_Total,Is_Item_Type_Column");
						mysql.Append(" ,Is_Item_Level_Column,Is_Outline_Column,Is_Parent_Cd_Column,Is_Child_Cd_Column,Is_Debit_Type_Column,Is_Credit_Type_Column,Enable_Filter");
						mysql.Append(" ,Filter_List_Types,List_SQL_Type,Standard_Filter_List_Type_Id,Custom_L_List_Field_SQL,Custom_A_List_Field_SQL,Builtin_From_List_Types");
						mysql.Append(" ,Builtin_To_List_Types,Is_Ldgr_No_Column,Is_Part_No_Column,Is_Row_Type_Column,Is_Group_Level_Column,Comments,Show,Protected,User_Date_Time");
						mysql.Append(" ,Default_From_Value,Default_To_Value,Linked_Parameter_Name2,Default_From_Value_When_Null,Default_To_Value_When_Null");
						mysql.Append(" ,Use_Unicode_Filter_Prefix,Report_Options_Find_Id,Report_Options_Find_Return_Column_Id,Cross_Tab_Type,Cross_Tab_Total_Type");
						mysql.Append(" ,Default_Filter_List_Types)");
						mysql.Append("  select " + newReportId.ToString() + i.ToString() + ", " + newReportId.ToString() + ",Feature_Id,Column_No,Table_Id,Field_Id,Group_By_Field_Id,Linked_Parameter_Type");
						mysql.Append(" ,Linked_Parameter_Name,L_Field_Caption,A_Field_Caption,Field_Type,Field_Language,L_Field_Alignment,A_Field_Alignment,Show_Title,Show_Detail");
						mysql.Append(" ,Enable_Sorting,Enable_Group_Total,Enable_Grand_Total,Enable_Grand_Total_On_Top_Group,Get_Caption_SQL, Filter_Condition,Default_Width,Apply_Format");
						mysql.Append(" ,Round_No_Of_Digits,Format_Text_Type,Entry_Id_Column,Voucher_Type_Column,Month_Id_Column,Show_In_Column_Selection,Allow_Wrap_Text,Apply_Special_Format");
						mysql.Append(" ,Show_In_Bold,Show_In_Italic,Column_Back_Color,Column_Fore_Color,Column_Font_Name,Column_Font_Size,Column_Type,Formula_Columns_Definition");
						mysql.Append(" ,Formula_Columns_Calculation,Grouped_Column,Grouped_Caption,Insert_Line_Before_Total,Insert_Line_After_Total,Is_Item_Type_Column");
						mysql.Append(" ,Is_Item_Level_Column,Is_Outline_Column,Is_Parent_Cd_Column,Is_Child_Cd_Column,Is_Debit_Type_Column,Is_Credit_Type_Column,Enable_Filter");
						mysql.Append(" ,Filter_List_Types,List_SQL_Type,Standard_Filter_List_Type_Id,Custom_L_List_Field_SQL,Custom_A_List_Field_SQL,Builtin_From_List_Types");
						mysql.Append(" ,Builtin_To_List_Types,Is_Ldgr_No_Column,Is_Part_No_Column,Is_Row_Type_Column,Is_Group_Level_Column,Comments,Show,Protected,User_Date_Time");
						mysql.Append(" ,Default_From_Value,Default_To_Value,Linked_Parameter_Name2,Default_From_Value_When_Null,Default_To_Value_When_Null");
						mysql.Append(" ,Use_Unicode_Filter_Prefix,Report_Options_Find_Id,Report_Options_Find_Return_Column_Id,Cross_Tab_Type,Cross_Tab_Total_Type");
						mysql.Append(" ,Default_Filter_List_Types from SM_REPORT_FIELDS ");
						mysql.Append(" where column_id = " + Conversion.Str(iteration_row_2["column_id"]));
						SqlCommand TempCommand_4 = null;
						TempCommand_4 = SystemVariables.gConn.CreateCommand();
						TempCommand_4.CommandText = mysql.ToString();
						TempCommand_4.ExecuteNonQuery();

						mysql = new StringBuilder(" insert into sm_user_group_rights (Report_Column_Id , right_level)");
						mysql.Append(" select " + newReportId.ToString() + i.ToString() + " , Right_Level  from sm_user_group_rights ");
						mysql.Append(" where Report_Column_Id = " + Conversion.Str(iteration_row_2["column_id"]));
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql.ToString();
						TempCommand_5.ExecuteNonQuery();
						i++;
					}
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();

				}

				this.Close();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 27)
				{
					this.Close();
				}

				if (KeyCode == 13)
				{ //if enter key pressed send a tab key
					SendKeys.Send("{tab}");
					return;
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
				frmSysSystemLabels.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}
	}
}