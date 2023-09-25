
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmSysFindOptions
		: System.Windows.Forms.Form
	{

		public frmSysFindOptions()
{
InitializeComponent();
} 
 public  void frmSysFindOptions_old()
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


		private void frmSysFindOptions_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private Form oParentForm = null;
		private clsToolbar oThisFormToolBar = null;

		private DataSet oMasterRecordset = null;
		private DataSet oDetailsRecordset = null;
		private XArrayHelper aReportColumns = null;
		private XArrayHelper aAdvancedOptions = null;
		private DataSet rsFilterTypeList = null;

		private bool mReportColumnTabClicked = false;
		private bool mReportAdvancedTabClicked = false;
		private int mShowOptionsTab = 0;
		private int mLastCol = 0;
		private int mLastRow = 0;

		private const int tpReportColumns = 0;
		private const int tpAdvancedOptions = 1;
		private const int lcTabInfo = 3;

		private const int mColumnCaption = 0;
		private const int mColumnShowDetails = 1;
		private const int mColumnNo = 2;
		private const int mColumnOrder = 3;
		private const int mColumnAlignment = 4;
		private const int mColumnWidth = 5;
		private const int mColumnShowTitle = 6;
		private const int mColumnWordWrap = 7;
		private const int mColumnEnableGrouping = 8;
		private const int mColumnApplySpecialFormat = 9;
		private const int mColumnShowBold = 10;
		private const int mColumnShowItalic = 11;
		private const int mColumnBackColor = 12;
		private const int mColumnForeColor = 13;
		private const int mColumnEnableSorting = 14;
		private const int mColumnFieldID = 15;

		private const int mButtonOk = 0;
		private const int mButtonCancel = 1;
		private const int mButtonSave = 2;
		private const int mButtonHelp = 3;
		private const int mButtonShowAll = 4;
		private const int mButtonShowNone = 5;
		private const int mButtonMoveUp = 6;
		private const int mButtonMoveDown = 7;
		private const int mEmptyString = 0;

		private const int mOrderAscending = 10001;
		private const int mOrderDescending = 10002;

		private const int mAlignLeft = 11001;
		private const int mAlignRight = 11002;
		private const int mAlignCenter = 11003;

		private const int mFixedAreaBackColor = unchecked((int) 0x80000016); //&HC4D5EC

		public void AttachObjects(Form pReportForm, DataSet pMasterRecordset, DataSet pDetailsRecordset)
		{
			oParentForm = pReportForm;
			oMasterRecordset = pMasterRecordset;
			oDetailsRecordset = pDetailsRecordset;
		}

		public int ShowOptionsTab
		{
			set
			{
				mShowOptionsTab = value;
			}
		}


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			oThisFormToolBar = new clsToolbar();
			this.Top = 67;
			this.Left = 100;

			SystemGrid.DefineSystemVoucherGrid(grdReportOptions, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.6f, 1.4f, "9671571", "&HB69D8D", 280);
			SystemGrid.DefineSystemGridCombo(cmbSearchList);

			tabReportOptions.CurrTab = (short) mShowOptionsTab;

			Control ObjCaption = null;
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic)
			{
				//UPGRADE_WARNING: (2065) Form property frmSysFindOptions.Controls has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
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
			oThisFormToolBar.AttachObject(this, tcbSystemForm);

			oThisFormToolBar.ShowSelectButton = true;
			//.ShowSaveButton = True
			oThisFormToolBar.BeginCheckAllButtonWithGroup = true;
			oThisFormToolBar.ShowCheckAllButton = true;
			oThisFormToolBar.ShowUncheckAllButton = true;
			oThisFormToolBar.BeginDrillDownButtonWithGroup = true;
			oThisFormToolBar.ShowDrillDownButton = true;
			oThisFormToolBar.ShowDrillUpButton = true;
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.DisableHelpButton = true;
			oThisFormToolBar.DefineToolBar();
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			try
			{

				frmSysFindOptions.DefInstance = null;
			}
			catch
			{
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//**--Return or Enter key
				if (KeyCode == ((int) Keys.Return) && this.ActiveControl.Name != "grdReportOptions")
				{
					SendKeys.Send("{TAB}");
					return;
				}
				else if (KeyCode == 27)
				{ 
					btnReportOptions_Click(mButtonCancel);
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void tabReportOptions_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			object mTempFilterTypes = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn colReportOptions = null;
			int mTotalRequiredColumns = 0;
			int TempCnt = 0;
			int RecordsetCnt = 0;

			//**--disable object repainting
			InnovaUpdSupport.PInvoke.SafeNative.user32.SendMessageLong(grdReportOptions.Handle.ToInt32(), SystemAPI.WM_SETREDRAW, 0, 0);

			//**--create no. of report option columns
			switch(tabReportOptions.CurrTab)
			{
				case tpReportColumns : 
					mTotalRequiredColumns = 13; 
					break;
				case tpAdvancedOptions : 
					mTotalRequiredColumns = 0; 
					break;
			}

			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Columns method grdReportOptions.Columns.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdReportOptions.Columns.Clear();
			Application.DoEvents();

			//**--setting column's common properties
			int tempForEndVar = mTotalRequiredColumns;
			for (TempCnt = 0; TempCnt <= tempForEndVar; TempCnt++)
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				C1.Win.C1TrueDBGrid.C1DataColumn tempColumn = new C1.Win.C1TrueDBGrid.C1DataColumn();
				grdReportOptions.Columns.Insert(TempCnt, tempColumn);
				colReportOptions = grdReportOptions.Splits[0].DisplayColumns[tempColumn];
				colReportOptions.AllowSizing = false;
				colReportOptions.ColumnDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single;
				colReportOptions.Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center;
				colReportOptions.Visible = true;
			}

			//**--hide all uncommon controls first
			chkAdvancedOptions.Visible = false;
			//btnReportOptions(mButtonShowAll).Visible = False
			//btnReportOptions(mButtonShowNone).Visible = False
			//btnReportOptions(mButtonMoveUp).Visible = False
			//btnReportOptions(mButtonMoveDown).Visible = False
			//cntButtons(1).Visible = False

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_3 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_4 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_5 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_6 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_7 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_8 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_9 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_10 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_11 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_12 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_13 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_14 = null;
			if (tabReportOptions.CurrTab == tpReportColumns)
			{
				//btnReportOptions(mButtonShowAll).Visible = True
				//btnReportOptions(mButtonShowNone).Visible = True
				//btnReportOptions(mButtonMoveUp).Visible = True
				//btnReportOptions(mButtonMoveDown).Visible = True
				//cntButtons(1).Visible = True

				lblCommon[lcTabInfo].Caption = "Report Columns:";
				lblCommon[lcTabInfo].Left = 10;
				lblCommon[lcTabInfo].Top = 17;

				chkAdvancedOptions.Left = 1;
				chkAdvancedOptions.Top = 45;

				chkAdvancedOptions.Visible = true;

				grdReportOptions.Left = 1;
				grdReportOptions.Height = 195;
				grdReportOptions.Top = 60;
				grdReportOptions.Width = this.Width - 5;
				grdReportOptions.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder;

				//**--format grid columns and its properties
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar = grdReportOptions.Splits[0].DisplayColumns[mColumnCaption];
				withVar.DataColumn.Caption = "Column Name";
				withVar.Width = 180;

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_2 = grdReportOptions.Splits[0].DisplayColumns[mColumnShowDetails];
				withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
				withVar_2.AllowFocus = true;
				withVar_2.DataColumn.Caption = "Show";
				withVar_2.FetchStyle = TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone;
				withVar_2.Width = 47;

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_3 = grdReportOptions.Splits[0].DisplayColumns[mColumnNo];
				withVar_3.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
				withVar_3.AllowFocus = false;
				withVar_3.DataColumn.Caption = "Col #";
				withVar_3.Style.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(SystemConstants.gDisableColumnBackColor)));
				withVar_3.Width = 40;

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_4 = grdReportOptions.Splits[0].DisplayColumns[mColumnOrder];
				withVar_4.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
				withVar_4.AutoDropDown = true;
				withVar_4.AutoComplete = true;
				withVar_4.AllowFocus = false;
				withVar_4.Style.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(SystemConstants.gDisableColumnBackColor)));
				withVar_4.DataColumn.Caption = "Order";
				withVar_4.DataColumn.DropDown = cmbSearchList;
				withVar_4.DropDownList = true;
				withVar_4.FetchStyle = TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone;
				withVar_4.Width = 63;

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_5 = grdReportOptions.Splits[0].DisplayColumns[mColumnAlignment];
				withVar_5.AutoDropDown = true;
				withVar_5.AutoComplete = true;
				withVar_5.AllowFocus = true;
				withVar_5.DataColumn.Caption = "Alignment";
				withVar_5.DataColumn.DropDown = cmbSearchList;
				withVar_5.DropDownList = true;
				withVar_5.Width = 53;

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_6 = grdReportOptions.Splits[0].DisplayColumns[mColumnWidth];
				withVar_6.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
				withVar_6.AllowFocus = true;
				withVar_6.DataColumn.Caption = "Width";
				withVar_6.Width = 50;

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_7 = grdReportOptions.Splits[0].DisplayColumns[mColumnShowTitle];
				withVar_7.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
				withVar_7.AllowFocus = true;
				withVar_7.DataColumn.Caption = "Title";
				withVar_7.FetchStyle = TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone;
				withVar_7.Width = 47;

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_8 = grdReportOptions.Splits[0].DisplayColumns[mColumnWordWrap];
				withVar_8.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
				withVar_8.AllowFocus = true;
				withVar_8.DataColumn.Caption = "Wrap";
				withVar_8.FetchStyle = TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone;
				withVar_8.Width = 47;

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_9 = grdReportOptions.Splits[0].DisplayColumns[mColumnEnableGrouping];
				withVar_9.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
				withVar_9.AllowFocus = true;
				withVar_9.DataColumn.Caption = "Grouped";
				withVar_9.FetchStyle = TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone;
				withVar_9.Width = 47;

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_10 = grdReportOptions.Splits[0].DisplayColumns[mColumnApplySpecialFormat];
				withVar_10.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
				withVar_10.AllowFocus = true;
				withVar_10.DataColumn.Caption = "ApplyFormat";
				withVar_10.FetchStyle = TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone;
				withVar_10.Width = 67;

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_11 = grdReportOptions.Splits[0].DisplayColumns[mColumnShowBold];
				withVar_11.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
				withVar_11.AllowFocus = true;
				withVar_11.DataColumn.Caption = "Bold";
				withVar_11.FetchStyle = TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone;
				withVar_11.Width = 47;

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_12 = grdReportOptions.Splits[0].DisplayColumns[mColumnShowItalic];
				withVar_12.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
				withVar_12.AllowFocus = true;
				withVar_12.DataColumn.Caption = "Italic";
				withVar_12.FetchStyle = TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone;
				withVar_12.Width = 47;

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_13 = grdReportOptions.Splits[0].DisplayColumns[mColumnBackColor];
				withVar_13.AllowFocus = true;
				withVar_13.DataColumn.Caption = "BackColor";
				withVar_13.Width = 67;

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_14 = grdReportOptions.Splits[0].DisplayColumns[mColumnForeColor];
				withVar_14.AllowFocus = true;
				withVar_14.DataColumn.Caption = "ForeColor";
				withVar_14.Width = 67;
				chkAdvancedOptions_CheckStateChanged(chkAdvancedOptions, new EventArgs());

				if (!mReportColumnTabClicked)
				{

					//**--get the filter types list from database
					rsFilterTypeList = new DataSet();
					//Set aFilterRange = New XArrayDB
					//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsFilterTypeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsFilterTypeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
					SqlDataAdapter adap = new SqlDataAdapter("select * from SM_REPORT_FILTERS", SystemVariables.gConn);
					rsFilterTypeList.Tables.Clear();
					adap.Fill(rsFilterTypeList);
					//**-----------------------------------------------------------------------------------------------------

					//Set btnReportOptions(mButtonShowAll).Picture = frmSysMain.imlSystemIcons.ListImages.Item("imgSelectAll2").Picture
					//Set btnReportOptions(mButtonShowNone).Picture = frmSysMain.imlSystemIcons.ListImages.Item("imgSelectNone2").Picture
					//Set btnReportOptions(mButtonMoveUp).Picture = frmSysMain.imlSystemIcons.ListImages.Item("imgMoveUp").Picture
					//Set btnReportOptions(mButtonMoveDown).Picture = frmSysMain.imlSystemIcons.ListImages.Item("imgMoveDown").Picture


					aReportColumns = new XArrayHelper();
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property oDetailsRecordset.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oDetailsRecordset.setSort("column_no asc");
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method oDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oDetailsRecordset.MoveFirst();
					TempCnt = 0;
					RecordsetCnt = 0;

					foreach (DataRow iteration_row in oDetailsRecordset.Tables[0].Rows)
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (iteration_row["find_id"] == oMasterRecordset.Tables[0].Rows[0]["find_id"] && ((TriState) Convert.ToInt32(iteration_row["show"])) == TriState.True)
						{
							aReportColumns.RedimXArray(new int[]{TempCnt, 15}, new int[]{0, 0});

							//**--get the filter field caption
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								aReportColumns.SetValue(iteration_row["l_field_caption"], TempCnt, mColumnCaption);
							}
							else
							{
								aReportColumns.SetValue(iteration_row["a_field_caption"], TempCnt, mColumnCaption);
							}
							aReportColumns.SetValue(iteration_row["show_detail"], TempCnt, mColumnShowDetails);
							aReportColumns.SetValue(iteration_row["Column_No"], TempCnt, mColumnNo);
							aReportColumns.SetValue("Allow Sort", TempCnt, mColumnOrder);
							aReportColumns.SetValue(iteration_row["default_width"], TempCnt, mColumnWidth);
							//                    aReportColumns(TempCnt, mColumnShowTitle) = .Fields("show_title").Value
							aReportColumns.SetValue(iteration_row["Allow_Wrap_Text"], TempCnt, mColumnWordWrap);
							//                    aReportColumns(TempCnt, mColumnEnableGrouping) = .Fields("Grouped_Column").Value
							aReportColumns.SetValue(iteration_row["Apply_Special_Format"], TempCnt, mColumnApplySpecialFormat);
							aReportColumns.SetValue(iteration_row["Show_In_Bold"], TempCnt, mColumnShowBold);
							aReportColumns.SetValue(iteration_row["Show_In_Italic"], TempCnt, mColumnShowItalic);
							aReportColumns.SetValue(iteration_row["Column_Back_Color"], TempCnt, mColumnBackColor);
							aReportColumns.SetValue(iteration_row["Column_Fore_Color"], TempCnt, mColumnForeColor);
							//**--get the column alignment
							string switchVar = Convert.ToString(iteration_row["field_alignment"]).ToUpper();
							if (switchVar == ("L").ToUpper())
							{
								rsFilterTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignLeft);
							}
							else if (switchVar == ("R").ToUpper())
							{ 
								rsFilterTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignRight);
							}
							else
							{
								rsFilterTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignCenter);
							}
							aReportColumns.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsFilterTypeList.Tables[0].Rows[0]["l_filter_name"] : rsFilterTypeList.Tables[0].Rows[0]["a_filter_name"], TempCnt, mColumnAlignment);
							aReportColumns.SetValue(iteration_row["enable_sorting"], TempCnt, mColumnEnableSorting);
							aReportColumns.SetValue(iteration_row["column_id"], TempCnt, mColumnFieldID);
							//**-------------------------------------------------------------------------------------------

							TempCnt++;
						}
					}
					mReportColumnTabClicked = true;
				}
				CalculateColumnNumber();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdReportOptions.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdReportOptions.setArray(aReportColumns);
				grdReportOptions.Rebind(true);
			}
			InnovaUpdSupport.PInvoke.SafeNative.user32.SendMessageLong(grdReportOptions.Handle.ToInt32(), SystemAPI.WM_SETREDRAW, -1, 0);
			grdReportOptions.Bookmark = 0;
			grdReportOptions.Refresh();
			fraReportOptions.Refresh();

			try
			{
				grdReportOptions.Focus();
			}
			catch
			{
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbSearchList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbSearchList_DataSourceChanged()
		{
			int cnt = 0;
			int mComboWidth = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			if (tabReportOptions.CurrTab == tpReportColumns)
			{
				if (grdReportOptions.Col == mColumnAlignment || grdReportOptions.Col == mColumnOrder)
				{
					int tempForEndVar = cmbSearchList.Columns.Count - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbSearchList.Splits[0].DisplayColumns[cnt];
						if (cnt == 1 && SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
						{
							withVar.AllowSizing = false;
							withVar.Style.HorizontalAlignment = (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? C1.Win.C1TrueDBGrid.AlignHorzEnum.Near : C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							withVar.Visible = true;
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							withVar.Width = grdReportOptions.Splits[0].DisplayColumns[grdReportOptions.Col].Width;
							mComboWidth = withVar.Width;
						}
						else if (cnt == 2 && SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic)
						{ 
							withVar.AllowSizing = false;
							withVar.Style.HorizontalAlignment = (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? C1.Win.C1TrueDBGrid.AlignHorzEnum.Near : C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							withVar.Visible = true;
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							withVar.Width = grdReportOptions.Splits[0].DisplayColumns[grdReportOptions.Col].Width;
							mComboWidth = withVar.Width;
						}
						else
						{
							withVar.Visible = false;
							withVar.AllowSizing = false;
						}
					}
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbSearchList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbSearchList.setListField("l_filter_name");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbSearchList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbSearchList.setListField("a_filter_name");
					}
					cmbSearchList.Height = 93;
					cmbSearchList.Width = (mComboWidth + 250) / 15;
				}
			}
		}

		private void chkAdvancedOptions_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((int) chkAdvancedOptions.CheckState) == ((int) CheckState.Unchecked))
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnCaption].AllowFocus = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnCaption].Style.BackColor = ColorTranslator.FromOle(mFixedAreaBackColor);
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnShowTitle].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnWordWrap].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnEnableGrouping].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnApplySpecialFormat].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnShowBold].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnShowItalic].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnBackColor].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnForeColor].Visible = false;
			}
			else
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnCaption].AllowFocus = true;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnCaption].Style.BackColor = Color.White;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnShowTitle].Visible = true;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnWordWrap].Visible = true;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnEnableGrouping].Visible = true;
				//        .Columns(mColumnApplySpecialFormat).Visible = True
				//        .Columns(mColumnShowBold).Visible = True
				//        .Columns(mColumnShowItalic).Visible = True
				//        .Columns(mColumnBackColor).Visible = True
				//        .Columns(mColumnForeColor).Visible = True
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnApplySpecialFormat].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnShowBold].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnShowItalic].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnBackColor].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnForeColor].Visible = false;


				//**--temporary disable these options
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnShowTitle].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnWordWrap].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnEnableGrouping].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnApplySpecialFormat].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnShowBold].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnShowItalic].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnBackColor].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mColumnForeColor].Visible = false;
				//**--------------------------------------------------------------------------
			}
		}

		private void grdReportOptions_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			int mCurrentRow = 0;
			string[] mTempFilterTypes = null;
			StringBuilder mTempFilterString = new StringBuilder();
			int mTempCnt = 0;

			if (tabReportOptions.CurrTab == tpReportColumns)
			{
				mCurrentRow = Convert.ToInt32(Conversion.Val(grdReportOptions.Row.ToString()));
				mTempFilterString = new StringBuilder("");
				if ((Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(LastRow)) != mCurrentRow) || (LastCol != grdReportOptions.Col))
				{
					switch(grdReportOptions.Col)
					{
						case mColumnAlignment : 
							//**--get the column alignment 
							mTempFilterTypes = (Conversion.Str(mAlignLeft) + "," + Conversion.Str(mAlignRight) + "," + Conversion.Str(mAlignCenter)).Split(','); 
							 
							foreach (string mTempFilterTypes_item in mTempFilterTypes)
							{
								if (mTempFilterString.ToString() == "")
								{
									mTempFilterString.Append("filter_type_id = " + mTempFilterTypes_item);
								}
								else
								{
									mTempFilterString.Append(" or filter_type_id = " + mTempFilterTypes_item);
								}
							} 
							rsFilterTypeList.Tables[0].DefaultView.RowFilter = mTempFilterString.ToString(); 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbSearchList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbSearchList.setDataSource((msdatasrc.DataSource) rsFilterTypeList); 
							break;
					}
				}
			}
		}

		private void grdReportOptions_BeforeColEdit(object eventSender, C1.Win.C1TrueDBGrid.BeforeColEditEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int KeyAscii = (int) eventArgs.KeyChar;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				if (tabReportOptions.CurrTab == tpReportColumns)
				{
					if (ColIndex == mColumnShowDetails || ColIndex == mColumnShowTitle || ColIndex == mColumnWordWrap || ColIndex == mColumnEnableGrouping || ColIndex == mColumnApplySpecialFormat || ColIndex == mColumnShowBold || ColIndex == mColumnShowItalic)
					{
						if (KeyAscii == 0 || KeyAscii == 13 || KeyAscii == 32)
						{
							aReportColumns.SetValue(~Convert.ToInt32(aReportColumns.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdReportOptions.Bookmark), ColIndex)), ReflectionHelper.GetPrimitiveValue<int>(grdReportOptions.Bookmark), ColIndex);
							grdReportOptions.UpdateData();
							CalculateColumnNumber();
							grdReportOptions.Refresh();
						}
						Cancel = -1;
					}
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdReportOptions.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdReportOptions_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			if (tabReportOptions.CurrTab == tpReportColumns)
			{
				//And aReportColumns.UpperBound(1) > 0
				if (Col == mColumnShowDetails || Col == mColumnShowTitle || Col == mColumnWordWrap || Col == mColumnEnableGrouping || Col == mColumnApplySpecialFormat || Col == mColumnShowBold || Col == mColumnShowItalic)
				{
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(aReportColumns.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), Col))) == TriState.True)
					{
						CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgChecked2"];
						CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
					}
					else
					{
						CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgUnchecked"];
						CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
					}
				}
			}
		}

		private void grdReportOptions_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float x = eventArgs.X * 15;
			float y = eventArgs.Y * 15;
			if (tabReportOptions.CurrTab == tpReportColumns)
			{
				if (grdReportOptions.PointAt(x, y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
				{
					mLastCol = grdReportOptions.Col;
					mLastRow = grdReportOptions.Row;
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdReportOptions.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdReportOptions.PostMsg(1);
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdReportOptions.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdReportOptions_PostEvent(int MsgId)
		{

			if (mLastCol == grdReportOptions.Col && mLastRow == grdReportOptions.Row)
			{
				return;
			}

			int Col = grdReportOptions.Col;
			if (tabReportOptions.CurrTab == tpReportColumns)
			{
				if (Col == mColumnShowDetails || Col == mColumnShowTitle || Col == mColumnWordWrap || Col == mColumnEnableGrouping || Col == mColumnApplySpecialFormat || Col == mColumnShowBold || Col == mColumnShowItalic)
				{
					grdReportOptions.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdReportOptions.Columns[Col].Value);
					grdReportOptions.UpdateData();
					CalculateColumnNumber();
					grdReportOptions.Refresh();
				}
			}
		}

		private void grdReportOptions_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				int Col = grdReportOptions.Col;
				if (tabReportOptions.CurrTab == tpReportColumns)
				{
					if (Col == mColumnShowDetails || Col == mColumnShowTitle || Col == mColumnWordWrap || Col == mColumnEnableGrouping || Col == mColumnApplySpecialFormat || Col == mColumnShowBold || Col == mColumnShowItalic)
					{
						if (KeyAscii == 32)
						{
							KeyAscii = 0;
							grdReportOptions.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdReportOptions.Columns[Col].Value);
							grdReportOptions.UpdateData();
							CalculateColumnNumber();
							grdReportOptions.Refresh();
						}
						else
						{
							KeyAscii = 0;
						}
						if (KeyAscii == 0)
						{
							eventArgs.Handled = true;
						}
						return;
					}
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

		private void CalculateColumnNumber(int pDisplayOptions = 0)
		{
			int RowCnt = 0;

			int ColCnt = 1;
			int tempForEndVar = aReportColumns.GetLength(0) - 1;
			for (RowCnt = 0; RowCnt <= tempForEndVar; RowCnt++)
			{
				if (pDisplayOptions == 1)
				{ //if show all button is pressed
					aReportColumns.SetValue(TriState.True, RowCnt, mColumnShowDetails);
				}
				else if (pDisplayOptions == 2)
				{  //if show none button is pressed
					aReportColumns.SetValue(TriState.False, RowCnt, mColumnShowDetails);
				}

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(aReportColumns.GetValue(RowCnt, mColumnShowDetails))) == TriState.True)
				{
					aReportColumns.SetValue(ColCnt, RowCnt, mColumnNo);
					ColCnt++;
				}
				else
				{
					aReportColumns.SetValue("", RowCnt, mColumnNo);
				}
			}
		}

		private void btnReportOptions_AccessKeyPress(int Index, int KeyAscii)
		{
			btnReportOptions_Click(Index);
		}

		public void KRoutine()
		{
			CalculateColumnNumber(1);
			grdReportOptions.Refresh();
			grdReportOptions.Focus();
		}
		public void URoutine()
		{
			CalculateColumnNumber(2);
			grdReportOptions.Refresh();
			grdReportOptions.Focus();
		}
		public void RRoutine()
		{
			object aTempValue = null;
			int ColCnt = 0;

			grdReportOptions.UpdateData();
			//UPGRADE_WARNING: (1068) grdReportOptions.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mCurrentRow = ReflectionHelper.GetPrimitiveValue<int>(grdReportOptions.Bookmark);
			if (mCurrentRow == aReportColumns.GetLength(0) - 1)
			{
				return;
			}
			//**--swap current row values with the next row
			int tempForEndVar = aReportColumns.GetLength(1) - 1;
			for (ColCnt = 0; ColCnt <= tempForEndVar; ColCnt++)
			{
				aTempValue = aReportColumns.GetValue(mCurrentRow + 1, ColCnt);
				aReportColumns.SetValue(aReportColumns.GetValue(mCurrentRow, ColCnt), mCurrentRow + 1, ColCnt);
				aReportColumns.SetValue(aTempValue, mCurrentRow, ColCnt);
			}
			grdReportOptions.Bookmark = mCurrentRow + 1;
			CalculateColumnNumber();
			grdReportOptions.Refresh();
			grdReportOptions.Focus();
		}
		public void TRoutine()
		{
			object aTempValue = null;
			int ColCnt = 0;

			grdReportOptions.UpdateData();
			//UPGRADE_WARNING: (1068) grdReportOptions.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mCurrentRow = ReflectionHelper.GetPrimitiveValue<int>(grdReportOptions.Bookmark);
			if (mCurrentRow == 0)
			{
				return;
			}
			//**--swap current row values with the previous row
			int tempForEndVar = aReportColumns.GetLength(1) - 1;
			for (ColCnt = 0; ColCnt <= tempForEndVar; ColCnt++)
			{
				aTempValue = aReportColumns.GetValue(mCurrentRow - 1, ColCnt);
				aReportColumns.SetValue(aReportColumns.GetValue(mCurrentRow, ColCnt), mCurrentRow - 1, ColCnt);
				aReportColumns.SetValue(aTempValue, mCurrentRow, ColCnt);
			}
			grdReportOptions.Bookmark = mCurrentRow - 1;
			CalculateColumnNumber();

			grdReportOptions.Refresh();
			grdReportOptions.Focus();
		}
		public void SelectRecord()
		{
			UpdateReportSettings();
			this.Hide();
			ReflectionHelper.Invoke(oParentForm, "GetReportData", new object[]{});
			return;
		}
		public void saveRecord()
		{
			DialogResult ans = MessageBox.Show("Are you sure you want to save the" + new String(' ', 8) + "\r" + "current Find Record settings?", "System Reports", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if (ans == System.Windows.Forms.DialogResult.Yes)
			{
				//**--update report definition first in the disconnected (local)
				//**--recordset first
				UpdateReportSettings();
				//**--and use the UpdateBatch method to flash the data in the database
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property oDetailsRecordset.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.setActiveConnection(SystemVariables.gConn);

				//**--temporary commented
				//**--column no uniqueness is not handled
				//oDetailsRecordset.UpdateBatch
				//**--end of temporary comments

				//**--set the active connection to nothing to keep the recordset disconnected
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property oDetailsRecordset.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.setActiveConnection(null);
				this.Hide();
				ReflectionHelper.Invoke(oParentForm, "GetReportData", new object[]{});
				return;
			}
		}
		public void CloseForm()
		{
			this.Hide();
		}

		private void btnReportOptions_Click(int Index)
		{
			int mCurrentRow = 0;
			object aTempValue = null;
			int ColCnt = 0;
			DialogResult ans = (DialogResult) 0;

			switch(Index)
			{
				case mButtonShowAll : 
					CalculateColumnNumber(1); 
					break;
				case mButtonShowNone : 
					CalculateColumnNumber(2); 
					break;
				case mButtonMoveUp : 
					grdReportOptions.UpdateData(); 
					//UPGRADE_WARNING: (1068) grdReportOptions.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mCurrentRow = ReflectionHelper.GetPrimitiveValue<int>(grdReportOptions.Bookmark); 
					if (mCurrentRow == 0)
					{
						return;
					} 
					//**--swap current row values with the previous row 
					int tempForEndVar = aReportColumns.GetLength(1) - 1; 
					for (ColCnt = 0; ColCnt <= tempForEndVar; ColCnt++)
					{
						aTempValue = aReportColumns.GetValue(mCurrentRow - 1, ColCnt);
						aReportColumns.SetValue(aReportColumns.GetValue(mCurrentRow, ColCnt), mCurrentRow - 1, ColCnt);
						aReportColumns.SetValue(aTempValue, mCurrentRow, ColCnt);
					} 
					grdReportOptions.Bookmark = mCurrentRow - 1; 
					CalculateColumnNumber(); 
					break;
				case mButtonMoveDown : 
					grdReportOptions.UpdateData(); 
					//UPGRADE_WARNING: (1068) grdReportOptions.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mCurrentRow = ReflectionHelper.GetPrimitiveValue<int>(grdReportOptions.Bookmark); 
					if (mCurrentRow == aReportColumns.GetLength(0) - 1)
					{
						return;
					} 
					//**--swap current row values with the next row 
					int tempForEndVar2 = aReportColumns.GetLength(1) - 1; 
					for (ColCnt = 0; ColCnt <= tempForEndVar2; ColCnt++)
					{
						aTempValue = aReportColumns.GetValue(mCurrentRow + 1, ColCnt);
						aReportColumns.SetValue(aReportColumns.GetValue(mCurrentRow, ColCnt), mCurrentRow + 1, ColCnt);
						aReportColumns.SetValue(aTempValue, mCurrentRow, ColCnt);
					} 
					grdReportOptions.Bookmark = mCurrentRow + 1; 
					CalculateColumnNumber(); 
					break;
				case mButtonOk : 
					UpdateReportSettings(); 
					this.Hide(); 
					ReflectionHelper.Invoke(oParentForm, "GetReportData", new object[]{}); 
					return;
				case mButtonCancel : 
					this.Hide(); 
					return;
				case mButtonSave : 
					ans = MessageBox.Show("Are you sure you want to save the" + new String(' ', 8) + "\r" + "current Find Record settings?", "System Reports", MessageBoxButtons.YesNo, MessageBoxIcon.Information); 
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						//**--update report definition first in the disconnected (local)
						//**--recordset first
						UpdateReportSettings();
						//**--and use the UpdateBatch method to flash the data in the database
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property oDetailsRecordset.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						oDetailsRecordset.setActiveConnection(SystemVariables.gConn);

						//**--temporary commented
						//**--column no uniqueness is not handled
						//oDetailsRecordset.UpdateBatch
						//**--end of temporary comments

						//**--set the active connection to nothing to keep the recordset disconnected
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property oDetailsRecordset.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						oDetailsRecordset.setActiveConnection(null);
						this.Hide();
						ReflectionHelper.Invoke(oParentForm, "GetReportData", new object[]{});
						return;
					} 
					break;
				case mButtonHelp : 
					break;
			}
			grdReportOptions.Refresh();
			grdReportOptions.Focus();
		}

		private void UpdateReportSettings()
		{
			grdReportOptions.UpdateData();

			//**--if report columns tab was activated ever, set report columns properties
			if (mReportColumnTabClicked)
			{
				SetReportColumns();
			}

			grdReportOptions.Focus();
		}

		private void SetReportColumns()
		{
			int RowCnt = 0;

			//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsFilterTypeList.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			DataSet rsTempClone = rsFilterTypeList.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
			//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsTempClone.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();


			//**-- filter the report column recordset to the current report
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			oDetailsRecordset.Tables[0].DefaultView.RowFilter = "find_id = " + Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["find_id"]);

			int tempForEndVar = aReportColumns.GetLength(0) - 1;
			for (RowCnt = 0; RowCnt <= tempForEndVar; RowCnt++)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method oDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.MoveFirst();
				oDetailsRecordset.Find("column_id = " + Convert.ToString(aReportColumns.GetValue(RowCnt, mColumnFieldID)));
				if (oDetailsRecordset.Tables[0].Rows.Count == 0)
				{
					MessageBox.Show("Error : Column not found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					//**--show error messege and then exit from the procedure for the time being
					return;
				}
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.Tables[0].Rows[0]["show_detail"].setValue(aReportColumns.GetValue(RowCnt, mColumnShowDetails));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.Tables[0].Rows[0]["column_no"].setValue(RowCnt + 1); //areportcolumns(rowcnt, mcolumnno)
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.Tables[0].Rows[0]["default_width"].setValue(aReportColumns.GetValue(RowCnt, mColumnWidth));
				//        .fields("show_title").value = areportcolumns(rowcnt, mcolumnshowtitle)
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.Tables[0].Rows[0]["allow_wrap_text"].setValue(aReportColumns.GetValue(RowCnt, mColumnWordWrap));
				//        .fields("grouped_column").value = areportcolumns(rowcnt, mcolumnenablegrouping)
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.Tables[0].Rows[0]["apply_special_format"].setValue(aReportColumns.GetValue(RowCnt, mColumnApplySpecialFormat));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.Tables[0].Rows[0]["show_in_bold"].setValue(aReportColumns.GetValue(RowCnt, mColumnShowBold));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.Tables[0].Rows[0]["show_in_italic"].setValue(aReportColumns.GetValue(RowCnt, mColumnShowItalic));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.Tables[0].Rows[0]["column_back_color"].setValue(aReportColumns.GetValue(RowCnt, mColumnBackColor));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.Tables[0].Rows[0]["column_fore_color"].setValue(aReportColumns.GetValue(RowCnt, mColumnForeColor));

				//**--reset column caption
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oDetailsRecordset.Tables[0].Rows[0]["l_field_caption"].setValue(aReportColumns.GetValue(RowCnt, mColumnCaption));
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oDetailsRecordset.Tables[0].Rows[0]["a_field_caption"].setValue(aReportColumns.GetValue(RowCnt, mColumnCaption));
				}
				//**---------------------------------------------------------------------------
				//**--set column alignment
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempClone.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempClone.MoveFirst();
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					rsTempClone.Find("l_filter_name = '" + Convert.ToString(aReportColumns.GetValue(RowCnt, mColumnAlignment)).Trim() + "'");
				}
				else
				{
					rsTempClone.Find("a_filter_name = '" + Convert.ToString(aReportColumns.GetValue(RowCnt, mColumnAlignment)).Trim() + "'");
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				switch(Convert.ToInt32(Conversion.Val(Convert.ToString(rsTempClone.Tables[0].Rows[0]["filter_type_id"]))))
				{
					case mAlignLeft : 
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						oDetailsRecordset.Tables[0].Rows[0]["field_alignment"].setValue(("L").ToUpper()); 
						break;
					case mAlignRight : 
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						oDetailsRecordset.Tables[0].Rows[0]["field_alignment"].setValue(("R").ToUpper()); 
						break;
					default:
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						oDetailsRecordset.Tables[0].Rows[0]["field_alignment"].setValue(("C").ToUpper()); 
						break;
				}
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method oDetailsRecordset.Update was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.Update_Renamed(null, null);
			}
			//**--set column no for the show=0
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method oDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			oDetailsRecordset.MoveFirst();
			foreach (DataRow iteration_row in oDetailsRecordset.Tables[0].Rows)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(iteration_row["show"])) == TriState.False)
				{
					RowCnt++;
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					iteration_row["column_no"].setValue(RowCnt);
				}
			}
			//**---------------------------------------------------------------------------
			//**-- remove the report column recordset filter
			//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			oDetailsRecordset.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
		}
	}
}