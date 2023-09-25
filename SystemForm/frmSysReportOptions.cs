
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmSysReportOptions
		: System.Windows.Forms.Form
	{

		public frmSysReportOptions()
{
InitializeComponent();
} 
 public  void frmSysReportOptions_old()
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


		private void frmSysReportOptions_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private Form oParentForm = null;
		private clsToolbar oThisFormToolBar = null;

		private clsReportDefinition oReportDefinitionClass = null;
		private DataSet oMasterRecordset = null;
		private DataSet oDetailsRecordset = null;
		private XArrayHelper aFilterRange = null;
		private XArrayHelper aReportColumns = null;
		private XArrayHelper aReportFonts = null;
		private XArrayHelper aAdvancedOptions = null;
		private DataSet[] rsComboLists = null;

		private DataSet rsFilterTypeList = null;
		private DataSet rsColumnTypeList = null;
		private DataSet rsFormatTypeList = null;

		private bool mReportFilterTabClicked = false;
		private bool mReportColumnTabClicked = false;
		private bool mReportFontTabClicked = false;
		private bool mReportAdvancedTabClicked = false;
		//Private mLastButtonClicked As Integer
		private int mShowOptionsTab = 0;
		private bool mFormIsInitialized = false;

		private const int tcReportFromDate = 0;
		private const int tcReportToDate = 1;

		private const int lcDateRange = 0;
		private const int lcFromDate = 1;
		private const int lcToDate = 2;
		private const int lcTabInfo = 3;

		private const int tpReportColumns = 0;
		private const int tpFilterRange = 1;
		private const int tpReportFonts = 2;
		private const int tpAdvancedOptions = 3;

		private const int mFilterFieldNameColumn = 0;
		private const int mFilterFieldTypeColumn = 1;
		private const int mFilterFromColumn = 2;
		private const int mFilterToColumn = 3;
		private const int mFilterColumnID = 4;
		private const int mFilterTypeValues = 5;
		private const int mFilterListSQLType = 6;
		private const int mFilterFromListValues = 7;
		private const int mFilterToListValues = 8;
		private const int mFilterFindId = 9;
		private const int mFilterFindReturnColumnId = 10;
		private const int mFilterFieldType = 11;

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

		private const int mReportBandCompanyName = 0;
		private const int mReportBandReportName = 1;
		private const int mReportBandColumnHeader = 2;
		private const int mReportBandColumnDetails = 3;
		private const int mReportBandTitleFilter = 4;
		private const int mReportBandDetailsFilter = 5;
		private const int mReportBandDateRange = 6;
		private const int mReportBandAddress = 7;
		private const int mReportBandTitle1 = 8;
		private const int mReportBandTitle2 = 9;

		private const int mFontReportBandShow = 0;
		private const int mFontReportBand = 1;
		private const int mFontDetails = 2;
		private const int mFontIcon = 3;
		private const int mFontReportBandAlignment = 4;
		private const int mFontName = 5;
		private const int mFontBold = 6;
		private const int mFontItalic = 7;
		private const int mFontSize = 8;
		private const int mFontColor = 9;

		private int mLastCol = 0;
		private int mLastRow = 0;

		private const int mEmptyString = 0;

		private const int mOrderAscending = 10001;
		private const int mOrderDescending = 10002;

		private const int mAlignLeft = 11001;
		private const int mAlignRight = 11002;
		private const int mAlignCenter = 11003;

		private int mFixedAreaBackColor = 0;
		private Color mDisableColumnBackColor = System.Drawing.Color.Black;

		public void AttachObjects(clsReportDefinition pReportClass, DataSet pMasterRecordset, DataSet pDetailsRecordset)
		{
			oReportDefinitionClass = pReportClass;
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


		private void chkShowAll_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chkShowAll.CheckState == CheckState.Checked)
			{
				CalculateColumnNumber(1);
			}
			else
			{
				CalculateColumnNumber(2);
			}

			grdReportFields.Refresh();
			grdReportFields.Focus();

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			oThisFormToolBar = new clsToolbar();

			mFixedAreaBackColor = 16574424;
			mDisableColumnBackColor = Color.FromArgb(216, 231, 252);

			oThisFormToolBar.AttachObject(this, tcbSystemForm);

			oThisFormToolBar.ShowSelectButton = true;
			oThisFormToolBar.ShowExitButton = true;

			oThisFormToolBar.DefineToolBar();

			DefineFieldTab();
			//Call DefineFontTab
			//Call DefineFilterTab

			//----------------------------------------------------------------------------------------------------
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtReportName.Text = Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["l_Report_Name"]);
			}
			else
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtReportName.Text = Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["A_Report_Name"]);
			}
			//-----------------------------------------------------------------------------------------------------

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			if (((TriState) Convert.ToInt32(oMasterRecordset.Tables[0].Rows[0]["show_date_range"])) == TriState.True)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!SystemProcedure2.IsItEmpty(oMasterRecordset.Tables[0].Rows[0]["report_from_date"], SystemVariables.DataType.DateType))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtDateRange[tcReportFromDate].Value = Convert.ToDateTime(oMasterRecordset.Tables[0].Rows[0]["report_from_date"]);
				}
				else
				{
					txtDateRange[tcReportFromDate].Value = DateTime.Today;
				}
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!SystemProcedure2.IsItEmpty(oMasterRecordset.Tables[0].Rows[0]["report_to_date"], SystemVariables.DataType.DateType))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtDateRange[tcReportToDate].Value = Convert.ToDateTime(oMasterRecordset.Tables[0].Rows[0]["report_to_date"]);
				}
				else
				{
					txtDateRange[tcReportToDate].Value = DateTime.Today;
				}
			}

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			chkRowsInAlternateColor.CheckState = (((TriState) Convert.ToInt32(oMasterRecordset.Tables[0].Rows[0]["show_report_in_alternate_row_colors"])) == TriState.False) ? CheckState.Unchecked : CheckState.Checked;
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			chkShowDoubleCoumnHeader.CheckState = (((TriState) Convert.ToInt32(oMasterRecordset.Tables[0].Rows[0]["Show_double_column_header"])) == TriState.False) ? CheckState.Unchecked : CheckState.Checked;
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			chkShowDoubleReportHeader.CheckState = (((TriState) Convert.ToInt32(oMasterRecordset.Tables[0].Rows[0]["Show_double_Report_header"])) == TriState.False) ? CheckState.Unchecked : CheckState.Checked;
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			chkShowVerticleLine.CheckState = (((TriState) Convert.ToInt32(oMasterRecordset.Tables[0].Rows[0]["Show_Verticle_Grid_Line"])) == TriState.False) ? CheckState.Unchecked : CheckState.Checked;
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			chkShowHorizontalLine.CheckState = (((TriState) Convert.ToInt32(oMasterRecordset.Tables[0].Rows[0]["Show_Horizontal_Grid_Line"])) == TriState.False) ? CheckState.Unchecked : CheckState.Checked;
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			chkShowFooter.CheckState = (((TriState) Convert.ToInt32(oMasterRecordset.Tables[0].Rows[0]["show_report_footer"])) == TriState.False) ? CheckState.Unchecked : CheckState.Checked;

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			rtbFooter.Rtf = (Convert.IsDBNull(oMasterRecordset.Tables[0].Rows[0]["Footer_Text"])) ? "" : Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["Footer_Text"]);

			tabReportOptions.SelectedItem = tpReportColumns;

			Control ObjCaption = null;
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic)
			{
				//UPGRADE_WARNING: (2065) Form property frmSysReportOptions.Controls has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
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
						//        ElseIf ObjCaption.Name = "tabReportOptions" Then
						//            With rsSystemLables
						//                .MoveFirst
						//                .Find "english_name = '" & Replace(ObjCaption.Caption, "&", "") & "'"
						//                If Not .EOF Then
						//                    ObjCaption.Caption = .Fields("arabic_name").Value
						//                End If
						//            End With
						//            tabReportOptions.TabCaption
					}
					ObjCaption = default(Control);
				}
			}
			mFormIsInitialized = true;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			try
			{

				frmSysReportOptions.DefInstance = null;
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
				if (KeyCode == ((int) Keys.Return) && this.ActiveControl.Name != "grdReportFilters")
				{
					SendKeys.Send("{TAB}");
					return;
				}
				else if (KeyCode == 27)
				{ 
					CloseForm();
				}

				object mTempSearchValue = null;
				int mCurrentBookmark = 0;
				int mCurrentCol = 0;
				int mCurrentRow = 0;

				if (KeyCode == 115 && this.ActiveControl.Name.ToLower() == ("grdReportFilters").ToLower() && tabReportOptions.SelectedItem == tpFilterRange && (grdReportFilters.Col == mFilterFromColumn || grdReportFilters.Col == mFilterToColumn))
				{

					if (SystemProcedure2.IsItEmpty(grdReportFilters.Bookmark, SystemVariables.DataType.NumberType))
					{
						mCurrentBookmark = 0;
					}
					else
					{
						mCurrentBookmark = Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportFilters.Bookmark)));
					}
					if (aFilterRange.GetLength(0) > 0)
					{
						mCurrentCol = grdReportFilters.Col;
						mCurrentRow = grdReportFilters.Row;

						if (!SystemProcedure2.IsItEmpty(aFilterRange.GetValue(mCurrentBookmark, mFilterFindId), SystemVariables.DataType.NumberType))
						{
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(Convert.ToInt32(aFilterRange.GetValue(mCurrentBookmark, mFilterFindId)), Convert.ToString(aFilterRange.GetValue(mCurrentBookmark, mFilterFindReturnColumnId))));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mTempSearchValue))
							{
								if (mCurrentCol == mFilterFromColumn)
								{
									aFilterRange.SetValue(((Array) mTempSearchValue).GetValue(1), mCurrentBookmark, mFilterFromColumn);
								}
								else
								{
									aFilterRange.SetValue(((Array) mTempSearchValue).GetValue(1), mCurrentBookmark, mFilterToColumn);
								}

								grdReportFilters.UpdateData();
								grdReportFilters.Rebind(true);
								grdReportFilters.Refresh();
								//grdReportFilters.Row = mCurrentRow
								grdReportFilters.Bookmark = mCurrentBookmark;
								grdReportFilters.Col = mCurrentCol;
							}
						}
					}

					KeyCode = 0;
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}
		private void grdReportFields_BeforeRowColChange(object eventSender, C1.Win.C1TrueDBGrid.CancelEventArgs eventArgs)
		{
			bool Cancel = eventArgs.Cancel;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdReportFields.Splits[0].DisplayColumns[mColumnOrder].AllowFocus = true;
		}

		private void grdReportFormats_BeforeRowColChange(object eventSender, C1.Win.C1TrueDBGrid.CancelEventArgs eventArgs)
		{
			bool Cancel = eventArgs.Cancel;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdReportFormats.Splits[0].DisplayColumns[mFontReportBandAlignment].AllowFocus = true;
		}

		private void grdReportFilters_BeforeRowColChange(object eventSender, C1.Win.C1TrueDBGrid.CancelEventArgs eventArgs)
		{
			bool Cancel = eventArgs.Cancel;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdReportFilters.Splits[0].DisplayColumns[mFilterFromColumn].AllowFocus = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdReportFilters.Splits[0].DisplayColumns[mFilterToColumn].AllowFocus = true;
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbFieldList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbFieldList_DataSourceChanged()
		{
			int Cnt = 0;
			int mComboWidth = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			if (grdReportFields.Col == mColumnAlignment || grdReportFields.Col == mColumnOrder)
			{
				int tempForEndVar = cmbFieldList.Columns.Count - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					withVar = cmbFieldList.Splits[0].DisplayColumns[Cnt];
					if (Cnt == 1 && SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						withVar.AllowSizing = false;
						withVar.Style.HorizontalAlignment = (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? C1.Win.C1TrueDBGrid.AlignHorzEnum.Near : C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
						withVar.Visible = true;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar.Width = grdReportFields.Splits[0].DisplayColumns[grdReportFields.Col].Width;
						mComboWidth = withVar.Width;
					}
					else if (Cnt == 2 && SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic)
					{ 
						withVar.AllowSizing = false;
						withVar.Style.HorizontalAlignment = (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? C1.Win.C1TrueDBGrid.AlignHorzEnum.Near : C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
						withVar.Visible = true;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar.Width = grdReportFields.Splits[0].DisplayColumns[grdReportFields.Col].Width;
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
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbFieldList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					cmbFieldList.setListField("l_filter_name");
				}
				else
				{
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbFieldList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					cmbFieldList.setListField("a_filter_name");
				}
				cmbFieldList.Height = 93;
				cmbFieldList.Width = (mComboWidth + 250) / 15;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbFormatList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbFormatList_DataSourceChanged()
		{
			int Cnt = 0;
			int mComboWidth = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			if (grdReportFormats.Col == mFontReportBandAlignment)
			{
				int tempForEndVar = cmbFormatList.Columns.Count - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					withVar = cmbFormatList.Splits[0].DisplayColumns[Cnt];
					if (Cnt == 1 && SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						withVar.AllowSizing = false;
						withVar.Style.HorizontalAlignment = (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? C1.Win.C1TrueDBGrid.AlignHorzEnum.Near : C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
						withVar.Visible = true;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar.Width = grdReportFormats.Splits[0].DisplayColumns[grdReportFormats.Col].Width;
						mComboWidth = withVar.Width;
					}
					else if (Cnt == 2 && SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic)
					{ 
						withVar.AllowSizing = false;
						withVar.Style.HorizontalAlignment = (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? C1.Win.C1TrueDBGrid.AlignHorzEnum.Near : C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
						withVar.Visible = true;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar.Width = grdReportFormats.Splits[0].DisplayColumns[grdReportFormats.Col].Width;
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
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbFormatList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					cmbFormatList.setListField("l_filter_name");
				}
				else
				{
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbFormatList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					cmbFormatList.setListField("a_filter_name");
				}
				cmbFormatList.Height = 93;
				cmbFormatList.Width = (mComboWidth + 250) / 15;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbFilterList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbFilterList_DataSourceChanged()
		{
			int Cnt = 0;
			int mComboWidth = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			if ((grdReportFilters.Col == mFilterFieldTypeColumn) || (Conversion.Val(Convert.ToString(aFilterRange.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdReportFilters.Bookmark), mFilterListSQLType))) == 2))
			{
				int tempForEndVar = cmbFilterList.Columns.Count - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					withVar = cmbFilterList.Splits[0].DisplayColumns[Cnt];
					if (Cnt == 1 && SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						withVar.AllowSizing = false;
						withVar.Style.HorizontalAlignment = (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? C1.Win.C1TrueDBGrid.AlignHorzEnum.Near : C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
						withVar.Visible = true;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar.Width = grdReportFilters.Splits[0].DisplayColumns[grdReportFilters.Col].Width;
						mComboWidth = withVar.Width;
					}
					else if (Cnt == 2 && SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic)
					{ 
						withVar.AllowSizing = false;
						withVar.Style.HorizontalAlignment = (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? C1.Win.C1TrueDBGrid.AlignHorzEnum.Near : C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
						withVar.Visible = true;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar.Width = grdReportFilters.Splits[0].DisplayColumns[grdReportFilters.Col].Width;
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
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbFilterList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					cmbFilterList.setListField("l_filter_name");
				}
				else
				{
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbFilterList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					cmbFilterList.setListField("a_filter_name");
				}
				cmbFilterList.Height = 93;
				cmbFilterList.Width = (mComboWidth + 500) / 15;
			}
			else
			{
				int tempForEndVar2 = cmbFilterList.Columns.Count - 1;
				for (Cnt = 0; Cnt <= tempForEndVar2; Cnt++)
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					withVar_2 = cmbFilterList.Splits[0].DisplayColumns[Cnt];
					withVar_2.AllowSizing = false;
					withVar_2.Style.HorizontalAlignment = (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? C1.Win.C1TrueDBGrid.AlignHorzEnum.Near : C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
					if (Cnt == 0)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_2.Width = grdReportFilters.Splits[0].DisplayColumns[grdReportFilters.Col].Width;
					}
					else
					{
						withVar_2.Width = 67;
					}
					mComboWidth += withVar_2.Width;
				}
				cmbFilterList.Width = (mComboWidth + 1500) / 15;
			}

		}

		private void chkAdvancedOptions_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((int) chkAdvancedOptions.CheckState) == ((int) CheckState.Unchecked))
			{
				txtReportName.Enabled = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnCaption].AllowFocus = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnCaption].Style.BackColor = ColorTranslator.FromOle(mFixedAreaBackColor);
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnShowTitle].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnWordWrap].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnEnableGrouping].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnApplySpecialFormat].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnShowBold].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnShowItalic].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnBackColor].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnForeColor].Visible = false;
			}
			else
			{
				txtReportName.Enabled = true;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnCaption].AllowFocus = true;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnCaption].Style.BackColor = Color.White;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnShowTitle].Visible = true;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnWordWrap].Visible = true;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnEnableGrouping].Visible = true;
				//        .Columns(mColumnApplySpecialFormat).Visible = True
				//        .Columns(mColumnShowBold).Visible = True
				//        .Columns(mColumnShowItalic).Visible = True
				//        .Columns(mColumnBackColor).Visible = True
				//        .Columns(mColumnForeColor).Visible = True
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnApplySpecialFormat].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnShowBold].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnShowItalic].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnBackColor].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnForeColor].Visible = false;




				//**--temporary disable these options
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnShowTitle].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnWordWrap].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnEnableGrouping].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnApplySpecialFormat].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnShowBold].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnShowItalic].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnBackColor].Visible = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportFields.Splits[0].DisplayColumns[mColumnForeColor].Visible = false;
				//**--------------------------------------------------------------------------
			}
		}
		private void grdReportFields_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			int mCurrentRow = 0;
			string[] mTempFilterTypes = null;
			StringBuilder mTempFilterString = new StringBuilder();
			int mTempCnt = 0;

			try
			{

				if (SystemProcedure2.IsItEmpty(grdReportFields.Bookmark, SystemVariables.DataType.NumberType))
				{
					mCurrentRow = 0;
				}
				else
				{
					mCurrentRow = Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportFields.Bookmark)));
				}

				mTempFilterString = new StringBuilder("");
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(LastRow))
				{
					LastRow = -1;
				}
				if ((Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(LastRow)) != mCurrentRow) || (LastCol != grdReportFields.Col))
				{
					switch(grdReportFields.Col)
					{
						case mColumnOrder : 
							//**--check whether sorting is allowed for the report column 
							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021 
							if (((TriState) Convert.ToInt32(aReportColumns.GetValue(mCurrentRow, mColumnEnableSorting))) == TriState.True)
							{
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								grdReportFields.Splits[0].DisplayColumns[mColumnOrder].AllowFocus = true;
							}
							else
							{
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								grdReportFields.Splits[0].DisplayColumns[mColumnOrder].AllowFocus = false;
								return;
							} 
							 
							//**--get the column sort order 
							mTempFilterTypes = (Conversion.Str(mEmptyString) + "," + Conversion.Str(mOrderAscending) + "," + Conversion.Str(mOrderDescending)).Split(','); 
							 
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
							rsColumnTypeList.Tables[0].DefaultView.RowFilter = mTempFilterString.ToString(); 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbFieldList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbFieldList.setDataSource((msdatasrc.DataSource) rsColumnTypeList); 
							break;
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
							rsColumnTypeList.Tables[0].DefaultView.RowFilter = mTempFilterString.ToString(); 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbFieldList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbFieldList.setDataSource((msdatasrc.DataSource) rsColumnTypeList); 
							break;
					}
				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void grdReportFilters_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			int mCurrentRow = 0;
			string[] mTempFilterTypes = null;
			StringBuilder mTempFilterString = new StringBuilder();
			int mTempCnt = 0;

			try
			{

				if (SystemProcedure2.IsItEmpty(grdReportFilters.Bookmark, SystemVariables.DataType.NumberType))
				{
					mCurrentRow = 0;
				}
				else
				{
					mCurrentRow = Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportFilters.Bookmark)));
				}

				bool mTempValue = false;
				DataSet rsTempClone = null;
				if (aFilterRange.GetLength(0) > 0)
				{
					mTempFilterString = new StringBuilder("");

					if ((Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(LastRow)) != mCurrentRow) || (LastCol != grdReportFilters.Col))
					{
						//**--check whether column is allowed for editing
						if (grdReportFilters.Col == mFilterFromColumn || grdReportFilters.Col == mFilterToColumn)
						{

							//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsFilterTypeList.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							rsTempClone = rsFilterTypeList.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempClone.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							rsTempClone.MoveFirst();
							//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							rsTempClone.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								rsTempClone.Find("L_Filter_Name = '" + Convert.ToString(aFilterRange.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportFilters.Bookmark))), mFilterFieldTypeColumn)).Trim() + "'");
							}
							else
							{
								rsTempClone.Find("A_Filter_Name = '" + Convert.ToString(aFilterRange.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportFilters.Bookmark))), mFilterFieldTypeColumn)).Trim() + "'");
							}

							if (rsTempClone.Tables[0].Rows.Count != 0)
							{
								if (grdReportFilters.Col == mFilterFromColumn)
								{
									//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
									mTempValue = Convert.ToBoolean(rsTempClone.Tables[0].Rows[0]["Allow_Value_In_From"]);
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
									grdReportFilters.Splits[0].DisplayColumns[mFilterFromColumn].AllowFocus = mTempValue;

									if (Convert.ToString(aFilterRange.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportFilters.Bookmark))), mFilterFieldType)).Trim() == "D")
									{
										grdReportFilters.Columns[mFilterFromColumn].Editor = txtTempDate;
									}
									else
									{
										grdReportFilters.Columns[mFilterFromColumn].Editor = SysInfoLib.;
									}
								}
								else
								{
									//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
									mTempValue = Convert.ToBoolean(rsTempClone.Tables[0].Rows[0]["Allow_Value_In_To"]);
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
									grdReportFilters.Splits[0].DisplayColumns[mFilterToColumn].AllowFocus = mTempValue;
									if (Convert.ToString(aFilterRange.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportFilters.Bookmark))), mFilterFieldType)).Trim() == "D")
									{
										grdReportFilters.Columns[mFilterToColumn].Editor = txtTempDate;
									}
									else
									{
										grdReportFilters.Columns[mFilterFromColumn].Editor = SysInfoLib.;
									}
								}
								if (mTempValue == (TriState.False != TriState.False))
								{
									rsTempClone = null;
									return;
								}
							}
							else
							{
								MessageBox.Show("Filter not found!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								rsTempClone = null;
								return;
							}
							rsTempClone = null;
						}
						//**-------------------------------------------------------------------------------------------

						switch(grdReportFilters.Col)
						{
							case mFilterFieldTypeColumn : 
								//**--get the filter type name 
								mTempFilterTypes = Convert.ToString(aFilterRange.GetValue(mCurrentRow, mFilterTypeValues)).Split(','); 
								 
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
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbFilterList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
								cmbFilterList.setDataSource((msdatasrc.DataSource) rsFilterTypeList); 
								break;
							case mFilterFromColumn : 
								switch(Convert.ToInt32(Conversion.Val(Convert.ToString(aFilterRange.GetValue(mCurrentRow, mFilterListSQLType)))))
								{
									case 0 : case 1 : 
										grdReportFilters.Columns[grdReportFilters.Col].DropDown = cmbFilterList; 
										//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbFilterList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
										cmbFilterList.setDataSource((msdatasrc.DataSource) aFilterRange.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportFilters.Bookmark))), mFilterFromListValues)); 
										break;
									case 2 : 
										grdReportFilters.Columns[grdReportFilters.Col].DropDown = cmbFilterList; 
										mTempFilterTypes = Convert.ToString(aFilterRange.GetValue(mCurrentRow, mFilterFromListValues)).Split(','); 
										 
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
										//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbFilterList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
										cmbFilterList.setDataSource((msdatasrc.DataSource) rsFilterTypeList); 
										break;
									case 3 : 
										grdReportFilters.Columns[grdReportFilters.Col].DropDown = null; 
										break;
								} 
								grdReportFilters.EditActive = true; 
								break;
							case mFilterToColumn : 
								switch(Convert.ToInt32(Conversion.Val(Convert.ToString(aFilterRange.GetValue(mCurrentRow, mFilterListSQLType)))))
								{
									case 0 : case 1 : 
										grdReportFilters.Columns[grdReportFilters.Col].DropDown = cmbFilterList; 
										//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbFilterList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
										cmbFilterList.setDataSource((msdatasrc.DataSource) aFilterRange.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportFilters.Bookmark))), mFilterFromListValues)); 
										break;
									case 2 : 
										grdReportFilters.Columns[grdReportFilters.Col].DropDown = cmbFilterList; 
										mTempFilterTypes = Convert.ToString(aFilterRange.GetValue(mCurrentRow, mFilterToListValues)).Split(','); 
										 
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
										//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbFilterList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
										cmbFilterList.setDataSource((msdatasrc.DataSource) rsFilterTypeList); 
										break;
									case 3 : 
										grdReportFilters.Columns[grdReportFilters.Col].DropDown = null; 
										break;
								} 
								grdReportFilters.EditActive = true; 
								break;
						}
					}
				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void grdReportFormats_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			int mCurrentRow = 0;
			string[] mTempFilterTypes = null;
			StringBuilder mTempFilterString = new StringBuilder();
			int mTempCnt = 0;

			try
			{

				if (SystemProcedure2.IsItEmpty(grdReportFormats.Bookmark, SystemVariables.DataType.NumberType))
				{
					mCurrentRow = 0;
				}
				else
				{
					mCurrentRow = Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportFormats.Bookmark)));
				}

				mTempFilterString = new StringBuilder("");
				if ((Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(LastRow)) != mCurrentRow) || (LastCol != grdReportFormats.Col))
				{
					if (grdReportFormats.Col == mFontReportBandAlignment)
					{
						//**--check whether alignment can be set for for the report band
						if (mCurrentRow == mReportBandColumnHeader || mCurrentRow == mReportBandColumnDetails)
						{
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							grdReportFormats.Splits[0].DisplayColumns[mFontReportBandAlignment].AllowFocus = false;
							return;
						}
						else
						{
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							grdReportFormats.Splits[0].DisplayColumns[mFontReportBandAlignment].AllowFocus = true;
						}

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
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = mTempFilterString.ToString();

						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbFormatList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbFormatList.setDataSource((msdatasrc.DataSource) rsFormatTypeList);
					}
				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void grdReportFields_BeforeColEdit(object eventSender, C1.Win.C1TrueDBGrid.BeforeColEditEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int KeyAscii = (int) eventArgs.KeyChar;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				if (ColIndex == mColumnShowDetails || ColIndex == mColumnShowTitle || ColIndex == mColumnWordWrap || ColIndex == mColumnEnableGrouping || ColIndex == mColumnApplySpecialFormat || ColIndex == mColumnShowBold || ColIndex == mColumnShowItalic)
				{

					if (KeyAscii == 0 || KeyAscii == 13 || KeyAscii == 32)
					{
						aReportColumns.SetValue(~Convert.ToInt32(aReportColumns.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdReportFields.Bookmark), ColIndex)), ReflectionHelper.GetPrimitiveValue<int>(grdReportFields.Bookmark), ColIndex);
						grdReportFields.UpdateData();
						CalculateColumnNumber();
						grdReportFields.Refresh();
					}
					Cancel = -1;
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		private void grdReportFormats_BeforeColEdit(object eventSender, C1.Win.C1TrueDBGrid.BeforeColEditEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int KeyAscii = (int) eventArgs.KeyChar;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				if (ColIndex == mFontReportBandShow)
				{
					if (KeyAscii == 0 || KeyAscii == 13 || KeyAscii == 32)
					{
						aReportFonts.SetValue(~Convert.ToInt32(aReportFonts.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdReportFormats.Bookmark), ColIndex)), ReflectionHelper.GetPrimitiveValue<int>(grdReportFormats.Bookmark), ColIndex);
						grdReportFormats.UpdateData();
						grdReportFormats.Refresh();
					}
					Cancel = -1;
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdReportFilters.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdReportFilters_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{

			bool mTempValue = false;
			DataSet rsTempClone = null;
			if (Col == mFilterFromColumn || Col == mFilterToColumn)
			{

				//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsFilterTypeList.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempClone = rsFilterTypeList.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempClone.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempClone.MoveFirst();
				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempClone.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					rsTempClone.Find("L_Filter_Name = '" + Convert.ToString(aFilterRange.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), mFilterFieldTypeColumn)).Trim() + "'");
				}
				else
				{
					rsTempClone.Find("A_Filter_Name = '" + Convert.ToString(aFilterRange.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), mFilterFieldTypeColumn)).Trim() + "'");
				}

				if (rsTempClone.Tables[0].Rows.Count != 0)
				{
					if (Col == mFilterFromColumn)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mTempValue = Convert.ToBoolean(rsTempClone.Tables[0].Rows[0]["Allow_Value_In_From"]);
					}
					else
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mTempValue = Convert.ToBoolean(rsTempClone.Tables[0].Rows[0]["Allow_Value_In_To"]);
					}
					if (mTempValue == (TriState.True != TriState.False))
					{
						CellStyle.BackColor = Color.White;
					}
					else
					{
						CellStyle.BackColor = mDisableColumnBackColor;
					}
				}
				else
				{
					//MsgBox "Filter not found!", vbCritical
					return;
				}
				rsTempClone = null;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdReportFields.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdReportFields_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			//And aReportColumns.UpperBound(1) > 0
			if (Col == mColumnShowDetails || Col == mColumnShowTitle || Col == mColumnWordWrap || Col == mColumnEnableGrouping || Col == mColumnApplySpecialFormat || Col == mColumnShowBold || Col == mColumnShowItalic)
			{
				//    If aReportColumns(Val(Bookmark), Col) = vbTrue Then
				//        Set CellStyle.ForegroundPicture = frmSysMain.imlSystemIcons.ListImages.Item("imgChecked2").Picture
				//        CellStyle.ForegroundPicturePosition = dbgFPPictureOnly
				//    Else
				//        Set CellStyle.ForegroundPicture = frmSysMain.imlSystemIcons.ListImages.Item("imgUnchecked").Picture
				//        CellStyle.ForegroundPicturePosition = dbgFPPictureOnly
				//    End If
			}
			else if (Col == mColumnOrder)
			{ 
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(aReportColumns.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), mColumnEnableSorting))) == TriState.True)
				{
					CellStyle.BackColor = Color.White;
				}
				else
				{
					CellStyle.BackColor = mDisableColumnBackColor;
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdReportFormats.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdReportFormats_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{

			if (Col == mFontReportBandShow)
			{
				//    If Val(Bookmark) = mReportBandReportName Or Val(Bookmark) = mReportBandColumnHeader Or Val(Bookmark) = mReportBandColumnDetails Then
				//        CellStyle.BackColor = gDisableColumnBackColor
				//        Set CellStyle.ForegroundPicture = frmSysMain.imlSystemIcons.ListImages.Item("imgCheckedDisabled").Picture
				//    Else
				//        CellStyle.BackColor = vbWhite
				//        If aReportFonts(Val(Bookmark), Col) = vbTrue Then
				//            Set CellStyle.ForegroundPicture = frmSysMain.imlSystemIcons.ListImages.Item("imgChecked2").Picture
				//        Else
				//            Set CellStyle.ForegroundPicture = frmSysMain.imlSystemIcons.ListImages.Item("imgUnchecked").Picture
				//        End If
				//    End If
				//    CellStyle.ForegroundPicturePosition = dbgFPPictureOnly
			}
			else if (Col == mFontDetails)
			{ 
				CellStyle.Font = CellStyle.Font.Change(bold:Convert.ToBoolean(aReportFonts.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), mFontBold)), italic:Convert.ToBoolean(aReportFonts.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), mFontItalic)));
				CellStyle.ForeColor = ColorTranslator.FromOle(Convert.ToInt32(aReportFonts.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), mFontColor)));
			}
			else if (Col == mFontReportBandAlignment)
			{ 
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark)) == mReportBandColumnHeader || Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark)) == mReportBandColumnDetails)
				{
					CellStyle.BackColor = mDisableColumnBackColor;
				}
				else
				{
					CellStyle.BackColor = Color.White;
				}
			}
		}

		private void grdReportFields_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (grdReportFields.PointAt(X, Y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
			{
				mLastCol = grdReportFilters.Col;
				mLastRow = grdReportFilters.Row;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdReportFilters.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdReportFilters.PostMsg(1);
			}
		}

		private void grdReportFormats_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (grdReportFormats.PointAt(X, Y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
			{
				mLastCol = grdReportFormats.Col;
				mLastRow = grdReportFormats.Row;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdReportFormats.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdReportFormats.PostMsg(1);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdReportFields.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdReportFields_PostEvent(int MsgId)
		{

			if (mLastCol == grdReportFields.Col && mLastRow == grdReportFields.Row)
			{
				return;
			}

			int Col = grdReportFields.Col;

			if (Col == mColumnShowDetails || Col == mColumnShowTitle || Col == mColumnWordWrap || Col == mColumnEnableGrouping || Col == mColumnApplySpecialFormat || Col == mColumnShowBold || Col == mColumnShowItalic)
			{
				grdReportFields.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdReportFields.Columns[Col].Value);
				grdReportFields.UpdateData();
				CalculateColumnNumber();
				grdReportFields.Refresh();
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdReportFormats.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdReportFormats_PostEvent(int MsgId)
		{

			if (mLastCol == grdReportFormats.Col && mLastRow == grdReportFormats.Row)
			{
				return;
			}

			int Col = grdReportFormats.Col;

			if (Col == mFontReportBandShow)
			{
				grdReportFormats.Columns[mFontReportBandShow].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdReportFormats.Columns[mFontReportBandShow].Value);
				grdReportFormats.UpdateData();
				grdReportFormats.Refresh();
			}
		}

		private void grdReportFields_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				int Col = grdReportFields.Col;

				if (Col == mColumnShowDetails || Col == mColumnShowTitle || Col == mColumnWordWrap || Col == mColumnEnableGrouping || Col == mColumnApplySpecialFormat || Col == mColumnShowBold || Col == mColumnShowItalic)
				{
					if (KeyAscii == 32)
					{
						KeyAscii = 0;
						grdReportFields.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdReportFields.Columns[Col].Value);
						grdReportFields.UpdateData();
						CalculateColumnNumber();
						grdReportFields.Refresh();
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
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}

		private void grdReportFormats_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				int Col = grdReportFormats.Col;

				if (Col == mFontReportBandShow)
				{
					if (KeyAscii == 32)
					{
						KeyAscii = 0;
						grdReportFormats.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdReportFormats.Columns[Col].Value);
						grdReportFormats.UpdateData();
						grdReportFormats.Refresh();
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


		//Private Sub btnReportOptions_Click(Index As Integer)
		//Dim mCurrentRow As Long
		//Dim aTempValue As Variant
		//Dim ColCnt As Long
		//
		//Select Case Index
		//    Case mButtonOk
		//        Call UpdateReportSettings
		//        Me.Hide
		//        oReportDefinitionClass.GetReportData
		//        Exit Sub
		//    Case mButtonCancel
		//        Me.Hide
		//        Exit Sub
		//'    Case mButtonApply
		//'        Call UpdateReportSettings
		//'        oReportDefinitionClass.GetReportData
		//    Case mButtonHelp
		//End Select
		//grdReportFields.Refresh
		//grdReportFields.SetFocus
		//End Sub
		public void SelectRecord()
		{
			UpdateReportSettings();
			this.Hide();
			oReportDefinitionClass.GetReportData();
			return;
			//grdReportFields.Refresh
			//grdReportFields.SetFocus
		}

		public void CloseForm()
		{
			this.Hide();
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbFilterList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbFilterList_DropDownClose()
		{
			grdReportFilters.UpdateData();
			grdReportFilters.RefreshRow(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportFilters.Bookmark)));
			grdReportFilters_RowColChange(grdReportFilters, new C1.Win.C1TrueDBGrid.RowColChangeEventArgs());
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbFilterList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbFilterList_RowChange()
		{
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdReportFilters.Splits[0].DisplayColumns[mFilterFromColumn].AllowFocus = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdReportFilters.Splits[0].DisplayColumns[mFilterToColumn].AllowFocus = true;
		}

		private void grdReportFormats_ButtonClick(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int mCurrentRow = 0;
			if (ColIndex == mFontIcon)
			{

				//UPGRADE_ISSUE: (6012) CommonDialog variable was not upgraded More Information: https://docs.mobilize.net/vbuc/ewis#6012
				if (ColIndex == mFontIcon)
				{
					//UPGRADE_WARNING: (1068) grdReportFormats.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCurrentRow = ReflectionHelper.GetPrimitiveValue<int>(grdReportFormats.Bookmark);
					//UPGRADE_ISSUE: (2064) MSComDlg.FontsConstants property FontsConstants.cdlCFBoth was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property cdgGetFontWindow.flags was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					cdgGetFontWindow.setFlags((int) UpgradeStubs.MSComDlg_FontsConstants.getcdlCFBoth());
					//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property cdgGetFontWindow.Flags was upgraded to cdgGetFontWindowFont.ShowEffects which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
					cdgGetFontWindowFont.ShowEffects = true;

					cdgGetFontWindowFont.Font = cdgGetFontWindowFont.Font.Change(name:Convert.ToString(aReportFonts.GetValue(mCurrentRow, mFontName)));
					cdgGetFontWindowFont.Font = cdgGetFontWindowFont.Font.Change(size:Convert.ToDecimal(aReportFonts.GetValue(mCurrentRow, mFontSize)));
					cdgGetFontWindowFont.Font = cdgGetFontWindowFont.Font.Change(bold:Convert.ToBoolean(aReportFonts.GetValue(mCurrentRow, mFontBold)));
					cdgGetFontWindowFont.Font = cdgGetFontWindowFont.Font.Change(italic:Convert.ToBoolean(aReportFonts.GetValue(mCurrentRow, mFontItalic)));
					cdgGetFontWindowColor.Color = ColorTranslator.FromOle(Convert.ToInt32(aReportFonts.GetValue(mCurrentRow, mFontColor)));

					cdgGetFontWindowFont.ShowDialog();
				}
				aReportFonts.SetValue(cdgGetFontWindowFont.Font.Name, mCurrentRow, mFontName);
				aReportFonts.SetValue(cdgGetFontWindowFont.Font.Size, mCurrentRow, mFontSize);
				aReportFonts.SetValue(cdgGetFontWindowFont.Font.Bold, mCurrentRow, mFontBold);
				aReportFonts.SetValue(cdgGetFontWindowFont.Font.Italic, mCurrentRow, mFontItalic);
				aReportFonts.SetValue(ColorTranslator.ToOle(cdgGetFontWindowColor.Color), mCurrentRow, mFontColor);

				GetFontStatus();
			}
		}

		private void GetFontStatus()
		{
			int RowCnt = 0;

			for (RowCnt = 0; RowCnt <= 9; RowCnt++)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				aReportFonts.SetValue(Convert.ToString(aReportFonts.GetValue(RowCnt, mFontName)).Trim() + ", " + Conversion.Str(aReportFonts.GetValue(RowCnt, mFontSize)) + ((((TriState) Convert.ToInt32(aReportFonts.GetValue(RowCnt, mFontBold))) == TriState.True) ? ", Bold" : "") + ((((TriState) Convert.ToInt32(aReportFonts.GetValue(RowCnt, mFontItalic))) == TriState.True) ? ", Italic" : ""), RowCnt, mFontDetails);
			}
			grdReportFilters.Refresh();
		}

		private int GetInterpretedValue(string pFilterTypeValue)
		{

			//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsFilterTypeList.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			int result = 0;
			DataSet rsTempClone = rsFilterTypeList.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());

			//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsTempClone.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempClone.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsTempClone.MoveFirst();
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				rsTempClone.Find("L_Filter_Name = '" + pFilterTypeValue.Trim() + "'");
			}
			else
			{
				rsTempClone.Find("A_Filter_Name = '" + pFilterTypeValue.Trim() + "'");
			}
			if (rsTempClone.Tables[0].Rows.Count != 0)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				result = Convert.ToInt32(rsTempClone.Tables[0].Rows[0]["Interpreted_Value"]);
			}
			else
			{
				MessageBox.Show("Error : Filter type not found ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			return result;
		}

		private void UpdateReportSettings()
		{
			//grdReportFilters.Update
			SetReportGeneralInfo();
			//**--if report columns tab was activated ever, set report columns properties
			if (mReportColumnTabClicked)
			{
				SetReportColumns();
			}
			//**--if filter tab was activated ever, set report filters
			if (mReportFilterTabClicked)
			{
				SetReportFilters();
			}

			//**--if report fonts tab was activated ever, set report fonts properties
			if (mReportFontTabClicked)
			{
				SetReportFonts();
			}
			//grdReportFilters.SetFocus
		}
		private void SetReportGeneralInfo()
		{
			try
			{

				//'--------------------This is for Report Name----------------------
				//----------------------------------------------------------------------------------------------------
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oMasterRecordset.Tables[0].Rows[0]["l_Report_Name"].setValue(txtReportName.Text);
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oMasterRecordset.Tables[0].Rows[0]["A_Report_Name"].setValue(txtReportName.Text);
				}
				//-----------------------------------------------------------------------------------------------------
				//**--alternate rows color setting
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["show_report_in_alternate_row_colors"].setValue((chkRowsInAlternateColor.CheckState == CheckState.Checked) ? 1 : 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Show_double_column_header"].setValue((chkShowDoubleCoumnHeader.CheckState == CheckState.Checked) ? 1 : 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Show_double_Report_header"].setValue((chkShowDoubleReportHeader.CheckState == CheckState.Checked) ? 1 : 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Show_Verticle_Grid_Line"].setValue((chkShowVerticleLine.CheckState == CheckState.Checked) ? 1 : 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Show_Horizontal_Grid_Line"].setValue((chkShowHorizontalLine.CheckState == CheckState.Checked) ? 1 : 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["show_report_footer"].setValue((chkShowFooter.CheckState == CheckState.Checked) ? 1 : 0);

				if (chkShowFooter.CheckState != CheckState.Unchecked)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oMasterRecordset.Tables[0].Rows[0]["Footer_Text"].setValue(rtbFooter.Rtf);
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oMasterRecordset.Tables[0].Rows[0]["Footer_Text"].setValue("");
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}


		}
		private void SetReportFilters()
		{
			int Cnt = 0;
			int mColumnID = 0;
			bool IsRangeType = false;

			//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsFilterTypeList.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			DataSet rsTempClone = rsFilterTypeList.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
			//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsTempClone.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();

			//UPGRADE_WARNING: (1068) txtDateRange().Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			string mTempFromDate = ReflectionHelper.GetPrimitiveValue<string>(txtDateRange[tcReportFromDate].Value);
			//UPGRADE_WARNING: (1068) txtDateRange().Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			string mTempToDate = ReflectionHelper.GetPrimitiveValue<string>(txtDateRange[tcReportToDate].Value);

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

			if (txtDateRange[tcReportFromDate].Visible)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["parameter_set_sql"].setValue(" set @FromDate = '" + mTempFromDate + "'" + " set @ToDate = '" + mTempToDate + "' ");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["report_from_date"].setValue(ReflectionHelper.GetPrimitiveValue(txtDateRange[tcReportFromDate].Value));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["report_to_date"].setValue(ReflectionHelper.GetPrimitiveValue(txtDateRange[tcReportToDate].Value));
			}

			string mFilterCondition = "";
			StringBuilder mDetailFilterText = new StringBuilder();
			string mStringCharacter = "";
			string mGroupByText = "";

			//**--Get values from filter grid
			int tempForEndVar = aFilterRange.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				//Get the column id value
				mColumnID = Convert.ToInt32(aFilterRange.GetValue(Cnt, mFilterColumnID));

				mFilterCondition = "";
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempClone.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempClone.MoveFirst();
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					rsTempClone.Find("L_Filter_Name = '" + Convert.ToString(aFilterRange.GetValue(Cnt, mFilterFieldTypeColumn)).Trim() + "'");
				}
				else
				{
					rsTempClone.Find("A_Filter_Name = '" + Convert.ToString(aFilterRange.GetValue(Cnt, mFilterFieldTypeColumn)).Trim() + "'");
				}
				if (rsTempClone.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (ReflectionHelper.GetPrimitiveValue<string>(SystemReports.GetColumnInformation("column_id = " + Conversion.Str(mColumnID), "Field_Type", oDetailsRecordset)) == "C" && ((TriState) Convert.ToInt32(rsTempClone.Tables[0].Rows[0]["filter_already_quoted"])) == TriState.False || ReflectionHelper.GetPrimitiveValue<string>(SystemReports.GetColumnInformation("column_id = " + Conversion.Str(mColumnID), "Field_Type", oDetailsRecordset)) == "D" && ((TriState) Convert.ToInt32(rsTempClone.Tables[0].Rows[0]["filter_already_quoted"])) == TriState.False)
					{
						mStringCharacter = "'";
					}
					else
					{
						mStringCharacter = "";
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					IsRangeType = (Convert.ToInt32(rsTempClone.Tables[0].Rows[0]["Allow_Value_In_From"]) & Convert.ToInt32(rsTempClone.Tables[0].Rows[0]["Allow_Value_In_to"])) != 0;
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(rsTempClone.Tables[0].Rows[0]["Allow_Value_In_From"])) == TriState.True && !SystemProcedure2.IsItEmpty(aFilterRange.GetValue(Cnt, mFilterFromColumn), SystemVariables.DataType.StringType))
					{
						if (mDetailFilterText.ToString() != "")
						{
							mDetailFilterText.Append(" and ");
						}
						mDetailFilterText.Append(Convert.ToString(aFilterRange.GetValue(Cnt, mFilterFieldNameColumn)).Trim());
						mDetailFilterText.Append(" " + Convert.ToString(aFilterRange.GetValue(Cnt, mFilterFieldTypeColumn)).Trim());
						if (IsRangeType)
						{
							mDetailFilterText.Append(" From ");
						}
						else
						{
							mDetailFilterText.Append(" ");
						}
						mDetailFilterText.Append(Convert.ToString(aFilterRange.GetValue(Cnt, mFilterFromColumn)));
						//**--set column filter text (from value)
						if (mFilterCondition != "")
						{
							mFilterCondition = mFilterCondition + " and ";
						}
						//**--or else take the value as it is
						//**--add field id with the table alias
						mFilterCondition = mFilterCondition + ReflectionHelper.GetPrimitiveValue<string>(SystemReports.GetColumnInformation("column_id = " + Conversion.Str(mColumnID), "Field_id", oDetailsRecordset, true));
						//**--add filter prefix & suffix operator
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mFilterCondition = mFilterCondition + " " + ((rsTempClone.Tables[0].Rows[0].IsNull("From_Prefix_Filter_String")) ? "" : Convert.ToString(rsTempClone.Tables[0].Rows[0]["From_Prefix_Filter_String"]));

						if (Conversion.Val(Convert.ToString(aFilterRange.GetValue(Cnt, mFilterListSQLType))) == 2)
						{
							//**--if the from value column contains built-in value
							//**--get the interpreted value of the current cell
							mFilterCondition = mFilterCondition + mStringCharacter + GetInterpretedValue(Convert.ToString(aFilterRange.GetValue(Cnt, mFilterFromColumn))).ToString() + mStringCharacter;
						}
						else
						{
							mFilterCondition = mFilterCondition + mStringCharacter + StringsHelper.Replace(Convert.ToString(aFilterRange.GetValue(Cnt, mFilterFromColumn)), ",", mStringCharacter + "," + mStringCharacter, 1, -1, CompareMethod.Binary) + mStringCharacter;
						}
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mFilterCondition = mFilterCondition + ((rsTempClone.Tables[0].Rows[0].IsNull("From_Suffix_Filter_String")) ? "" : Convert.ToString(rsTempClone.Tables[0].Rows[0]["From_Suffix_Filter_String"]));
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(rsTempClone.Tables[0].Rows[0]["Allow_Value_In_To"])) == TriState.True && !SystemProcedure2.IsItEmpty(aFilterRange.GetValue(Cnt, mFilterToColumn), SystemVariables.DataType.StringType))
					{
						//**--or else take the value as it is
						if (mDetailFilterText.ToString() != "")
						{
							mDetailFilterText.Append(" and ");
						}
						mDetailFilterText.Append(" To ");
						mDetailFilterText.Append(Convert.ToString(aFilterRange.GetValue(Cnt, mFilterToColumn)));
						//**--set column filter text (to value)
						if (mFilterCondition != "")
						{
							mFilterCondition = mFilterCondition + " and ";
						}
						//**--add field id with the table alias
						mFilterCondition = mFilterCondition + ReflectionHelper.GetPrimitiveValue<string>(SystemReports.GetColumnInformation("column_id = " + Conversion.Str(mColumnID), "Field_id", oDetailsRecordset, true));
						//**--add filter prefix & suffix operator
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mFilterCondition = mFilterCondition + " " + ((rsTempClone.Tables[0].Rows[0].IsNull("To_Prefix_Filter_String")) ? "" : Convert.ToString(rsTempClone.Tables[0].Rows[0]["To_Prefix_Filter_String"]));
						if (Conversion.Val(Convert.ToString(aFilterRange.GetValue(Cnt, mFilterListSQLType))) == 2)
						{
							//**--if the from value column contains built-in value
							//**--get the interpreted value of the current cell
							mFilterCondition = mFilterCondition + mStringCharacter + GetInterpretedValue(Convert.ToString(aFilterRange.GetValue(Cnt, mFilterToColumn))).ToString() + mStringCharacter;
						}
						else
						{
							mFilterCondition = mFilterCondition + mStringCharacter + Convert.ToString(aFilterRange.GetValue(Cnt, mFilterToColumn)) + mStringCharacter;
						}
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mFilterCondition = mFilterCondition + ((rsTempClone.Tables[0].Rows[0].IsNull("To_Suffix_Filter_String")) ? "" : Convert.ToString(rsTempClone.Tables[0].Rows[0]["To_Suffix_Filter_String"]));
					}
					//**--set column filter
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					oReportDefinitionClass.SetColumnInformation("column_id = " + Conversion.Str(mColumnID), "Filter_Condition", mFilterCondition, "alias_id = " + Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["alias_id"]));

				}
				else
				{
					//**--raise error here
				}
			}
			rsTempClone = null;
			//-------------------This is for Group By display on header--------Moiz Hakimi--------19-Mar-2009--------------
			//-------------------------------------------------------------------------------------------------------------
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method oDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			oDetailsRecordset.MoveFirst();
			foreach (DataRow iteration_row in oDetailsRecordset.Tables[0].Rows)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (!oDetailsRecordset.Tables[0].Rows[0].IsNull("Group_by_field_Id") && ((TriState) Convert.ToInt32(iteration_row["show_detail"])) == TriState.True)
				{
					if (mGroupByText != "")
					{
						mGroupByText = mGroupByText + ", ";
					}
					//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
					mGroupByText = Convert.ToString(Double.Parse(mGroupByText) + Convert.ToDouble(iteration_row["L_Field_Caption"]));
				}
			}

			if (mDetailFilterText.ToString() != "" && mGroupByText != "")
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["report_details_filter"].setValue(mDetailFilterText.ToString() + Environment.NewLine + "Group By " + mGroupByText);
			}
			else if (mDetailFilterText.ToString() == "" && mGroupByText != "")
			{ 
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["report_details_filter"].setValue("Group By " + mGroupByText);
			}
			else
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["report_details_filter"].setValue(mDetailFilterText.ToString());
			}
			//-------------------------------------------------------------------------------------------------------------

		}

		private void SetReportColumns()
		{
			try
			{

				int RowCnt = 0;
				DataSet rsTempClone = null;

				//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsColumnTypeList.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempClone = rsColumnTypeList.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempClone.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();


				//**-- filter the report column recordset to the current report
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				oDetailsRecordset.Tables[0].DefaultView.RowFilter = "alias_id = " + Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["alias_id"]);

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
					oDetailsRecordset.Tables[0].Rows[0]["Column_No"].setValue(RowCnt + 1); //aReportColumns(RowCnt, mColumnNo)
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oDetailsRecordset.Tables[0].Rows[0]["default_width"].setValue(aReportColumns.GetValue(RowCnt, mColumnWidth));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oDetailsRecordset.Tables[0].Rows[0]["show_title"].setValue(aReportColumns.GetValue(RowCnt, mColumnShowTitle));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oDetailsRecordset.Tables[0].Rows[0]["Allow_Wrap_Text"].setValue(aReportColumns.GetValue(RowCnt, mColumnWordWrap));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oDetailsRecordset.Tables[0].Rows[0]["Grouped_Column"].setValue(aReportColumns.GetValue(RowCnt, mColumnEnableGrouping));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oDetailsRecordset.Tables[0].Rows[0]["Apply_Special_Format"].setValue(aReportColumns.GetValue(RowCnt, mColumnApplySpecialFormat));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oDetailsRecordset.Tables[0].Rows[0]["Show_In_Bold"].setValue(aReportColumns.GetValue(RowCnt, mColumnShowBold));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oDetailsRecordset.Tables[0].Rows[0]["Show_In_Italic"].setValue(aReportColumns.GetValue(RowCnt, mColumnShowItalic));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oDetailsRecordset.Tables[0].Rows[0]["Column_Back_Color"].setValue(aReportColumns.GetValue(RowCnt, mColumnBackColor));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oDetailsRecordset.Tables[0].Rows[0]["Column_Fore_Color"].setValue(aReportColumns.GetValue(RowCnt, mColumnForeColor));

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
					//**--set column sort order & order type
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempClone.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsTempClone.MoveFirst();
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						rsTempClone.Find("L_Filter_Name = '" + Convert.ToString(aReportColumns.GetValue(RowCnt, mColumnOrder)).Trim() + "'");
					}
					else
					{
						rsTempClone.Find("a_Filter_Name = '" + Convert.ToString(aReportColumns.GetValue(RowCnt, mColumnOrder)).Trim() + "'");
					}
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToDouble(rsTempClone.Tables[0].Rows[0]["Filter_Type_Id"]) == mEmptyString)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						oDetailsRecordset.Tables[0].Rows[0]["include_in_order"].setValue((int) TriState.False);
					}
					else
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						oDetailsRecordset.Tables[0].Rows[0]["include_in_order"].setValue((int) TriState.True);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToDouble(rsTempClone.Tables[0].Rows[0]["Filter_Type_Id"]) == mOrderAscending)
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							oDetailsRecordset.Tables[0].Rows[0]["desc_order"].setValue((int) TriState.False);
						}
						else
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							oDetailsRecordset.Tables[0].Rows[0]["desc_order"].setValue((int) TriState.True);
						}
					}
					//**---------------------------------------------------------------------------
					//**--set column alignment
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempClone.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsTempClone.MoveFirst();
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						rsTempClone.Find("L_Filter_Name = '" + Convert.ToString(aReportColumns.GetValue(RowCnt, mColumnAlignment)).Trim() + "'");
					}
					else
					{
						rsTempClone.Find("a_Filter_Name = '" + Convert.ToString(aReportColumns.GetValue(RowCnt, mColumnAlignment)).Trim() + "'");
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					switch(Convert.ToInt32(Conversion.Val(Convert.ToString(rsTempClone.Tables[0].Rows[0]["filter_type_id"]))))
					{
						case mAlignLeft : 
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
							//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							oDetailsRecordset.Tables[0].Rows[0]["Field_Alignment"].setValue(("L").ToUpper()); 
							break;
						case mAlignRight : 
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
							//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							oDetailsRecordset.Tables[0].Rows[0]["Field_Alignment"].setValue(("R").ToUpper()); 
							break;
						default:
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
							//UPGRADE_ISSUE: (2064) ADODB.Field20 property oDetailsRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							oDetailsRecordset.Tables[0].Rows[0]["Field_Alignment"].setValue(("C").ToUpper()); 
							break;
					}
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method oDetailsRecordset.Update was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oDetailsRecordset.Update_Renamed(null, null);
				}
				//**-- remove the report column recordset filter
				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
				rsTempClone = null;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void SetReportFonts()
		{
			try
			{

				int RowCnt = 0;
				DataSet rsTempClone = null;

				//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsColumnTypeList.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempClone = rsColumnTypeList.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempClone.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Show_Company_Name"].setValue(aReportFonts.GetValue(mReportBandCompanyName, mFontReportBandShow));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Company_Font_Name"].setValue(aReportFonts.GetValue(mReportBandCompanyName, mFontName));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Company_Font_size"].setValue(aReportFonts.GetValue(mReportBandCompanyName, mFontSize));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Company_Font_bold"].setValue(aReportFonts.GetValue(mReportBandCompanyName, mFontBold));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Company_Font_italic"].setValue(aReportFonts.GetValue(mReportBandCompanyName, mFontItalic));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Company_Font_color"].setValue(aReportFonts.GetValue(mReportBandCompanyName, mFontColor));

				//.Fields("Show_Report_Name").Value = aReportFonts(mReportBandReportName, mFontReportBandShow)
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Report_Name_Font_Name"].setValue(aReportFonts.GetValue(mReportBandReportName, mFontName));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Report_Name_Font_size"].setValue(aReportFonts.GetValue(mReportBandReportName, mFontSize));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Report_Name_Font_bold"].setValue(aReportFonts.GetValue(mReportBandReportName, mFontBold));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Report_Name_Font_italic"].setValue(aReportFonts.GetValue(mReportBandReportName, mFontItalic));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Report_Name_Font_color"].setValue(aReportFonts.GetValue(mReportBandReportName, mFontColor));

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Column_Header_Font_Name"].setValue(aReportFonts.GetValue(mReportBandColumnHeader, mFontName));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Column_Header_Font_size"].setValue(aReportFonts.GetValue(mReportBandColumnHeader, mFontSize));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Column_Header_Font_bold"].setValue(aReportFonts.GetValue(mReportBandColumnHeader, mFontBold));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Column_Header_Font_italic"].setValue(aReportFonts.GetValue(mReportBandColumnHeader, mFontItalic));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Column_Header_Font_color"].setValue(aReportFonts.GetValue(mReportBandColumnHeader, mFontColor));

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Column_Details_Font_Name"].setValue(aReportFonts.GetValue(mReportBandColumnDetails, mFontName));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Column_Details_Font_size"].setValue(aReportFonts.GetValue(mReportBandColumnDetails, mFontSize));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Column_Details_Font_bold"].setValue(aReportFonts.GetValue(mReportBandColumnDetails, mFontBold));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Column_Details_Font_italic"].setValue(aReportFonts.GetValue(mReportBandColumnDetails, mFontItalic));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Column_Details_Font_color"].setValue(aReportFonts.GetValue(mReportBandColumnDetails, mFontColor));

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Show_Title_Filter_Condition"].setValue(aReportFonts.GetValue(mReportBandTitleFilter, mFontReportBandShow));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title_Filter_Font_Name"].setValue(aReportFonts.GetValue(mReportBandTitleFilter, mFontName));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title_Filter_Font_size"].setValue(aReportFonts.GetValue(mReportBandTitleFilter, mFontSize));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title_Filter_Font_bold"].setValue(aReportFonts.GetValue(mReportBandTitleFilter, mFontBold));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title_Filter_Font_italic"].setValue(aReportFonts.GetValue(mReportBandTitleFilter, mFontItalic));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title_Filter_Font_color"].setValue(aReportFonts.GetValue(mReportBandTitleFilter, mFontColor));

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Show_Filter_Condition"].setValue(aReportFonts.GetValue(mReportBandDetailsFilter, mFontReportBandShow));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Details_Filter_Font_Name"].setValue(aReportFonts.GetValue(mReportBandDetailsFilter, mFontName));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Details_Filter_Font_size"].setValue(aReportFonts.GetValue(mReportBandDetailsFilter, mFontSize));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Details_Filter_Font_bold"].setValue(aReportFonts.GetValue(mReportBandDetailsFilter, mFontBold));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Details_Filter_Font_italic"].setValue(aReportFonts.GetValue(mReportBandDetailsFilter, mFontItalic));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Details_Filter_Font_color"].setValue(aReportFonts.GetValue(mReportBandDetailsFilter, mFontColor));

				//    .Fields("Show_Date_Range").Value = aReportFonts(mReportBandDateRange, mFontReportBandShow)
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Date_Range_Font_Name"].setValue(aReportFonts.GetValue(mReportBandDateRange, mFontName));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Date_Range_Font_size"].setValue(aReportFonts.GetValue(mReportBandDateRange, mFontSize));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Date_Range_Font_bold"].setValue(aReportFonts.GetValue(mReportBandDateRange, mFontBold));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Date_Range_Font_italic"].setValue(aReportFonts.GetValue(mReportBandDateRange, mFontItalic));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Date_Range_Font_color"].setValue(aReportFonts.GetValue(mReportBandDateRange, mFontColor));

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Show_Addr1"].setValue(aReportFonts.GetValue(mReportBandAddress, mFontReportBandShow));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Show_Addr2"].setValue(aReportFonts.GetValue(mReportBandAddress, mFontReportBandShow));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Address_Font_Name"].setValue(aReportFonts.GetValue(mReportBandAddress, mFontName));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Address_Font_size"].setValue(aReportFonts.GetValue(mReportBandAddress, mFontSize));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Address_Font_bold"].setValue(aReportFonts.GetValue(mReportBandAddress, mFontBold));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Address_Font_italic"].setValue(aReportFonts.GetValue(mReportBandAddress, mFontItalic));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Address_Font_color"].setValue(aReportFonts.GetValue(mReportBandAddress, mFontColor));

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Show_Title1"].setValue(aReportFonts.GetValue(mReportBandTitle1, mFontReportBandShow));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title1_Font_Name"].setValue(aReportFonts.GetValue(mReportBandTitle1, mFontName));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title1_Font_size"].setValue(aReportFonts.GetValue(mReportBandTitle1, mFontSize));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title1_Font_bold"].setValue(aReportFonts.GetValue(mReportBandTitle1, mFontBold));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title1_Font_italic"].setValue(aReportFonts.GetValue(mReportBandTitle1, mFontItalic));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title1_Font_color"].setValue(aReportFonts.GetValue(mReportBandTitle1, mFontColor));

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Show_Title2"].setValue(aReportFonts.GetValue(mReportBandTitle2, mFontReportBandShow));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title2_Font_Name"].setValue(aReportFonts.GetValue(mReportBandTitle2, mFontName));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title2_Font_size"].setValue(aReportFonts.GetValue(mReportBandTitle2, mFontSize));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title2_Font_bold"].setValue(aReportFonts.GetValue(mReportBandTitle2, mFontBold));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title2_Font_italic"].setValue(aReportFonts.GetValue(mReportBandTitle2, mFontItalic));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title2_Font_color"].setValue(aReportFonts.GetValue(mReportBandTitle2, mFontColor));


				//--**setting report band alignments
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Company_Font_Alignment"].setValue(GetReportBandAlignmentCodeFromText(Convert.ToString(aReportFonts.GetValue(mReportBandCompanyName, mFontReportBandAlignment))));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Address_Font_Alignment"].setValue(GetReportBandAlignmentCodeFromText(Convert.ToString(aReportFonts.GetValue(mReportBandAddress, mFontReportBandAlignment))));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Report_Name_Font_Alignment"].setValue(GetReportBandAlignmentCodeFromText(Convert.ToString(aReportFonts.GetValue(mReportBandReportName, mFontReportBandAlignment))));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title1_Font_Alignment"].setValue(GetReportBandAlignmentCodeFromText(Convert.ToString(aReportFonts.GetValue(mReportBandTitle1, mFontReportBandAlignment))));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title2_Font_Alignment"].setValue(GetReportBandAlignmentCodeFromText(Convert.ToString(aReportFonts.GetValue(mReportBandTitle2, mFontReportBandAlignment))));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Title_Filter_Font_Alignment"].setValue(GetReportBandAlignmentCodeFromText(Convert.ToString(aReportFonts.GetValue(mReportBandTitleFilter, mFontReportBandAlignment))));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Date_Range_Font_Alignment"].setValue(GetReportBandAlignmentCodeFromText(Convert.ToString(aReportFonts.GetValue(mReportBandDateRange, mFontReportBandAlignment))));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Details_Filter_Font_Alignment"].setValue(GetReportBandAlignmentCodeFromText(Convert.ToString(aReportFonts.GetValue(mReportBandDetailsFilter, mFontReportBandAlignment))));


				//**--alternate rows color setting
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["show_report_in_alternate_row_colors"].setValue((chkRowsInAlternateColor.CheckState == CheckState.Checked) ? 1 : 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Show_double_column_header"].setValue((chkShowDoubleCoumnHeader.CheckState == CheckState.Checked) ? 1 : 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Show_double_Report_header"].setValue((chkShowDoubleReportHeader.CheckState == CheckState.Checked) ? 1 : 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Show_Verticle_Grid_Line"].setValue((chkShowVerticleLine.CheckState == CheckState.Checked) ? 1 : 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oMasterRecordset.Tables[0].Rows[0]["Show_Horizontal_Grid_Line"].setValue((chkShowHorizontalLine.CheckState == CheckState.Checked) ? 1 : 0);
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private string GetReportBandAlignmentCodeFromText(string pAlignmentText)
		{

			//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsFormatTypeList.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			DataSet rsTempClone = rsFormatTypeList.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
			//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsTempClone.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempClone.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsTempClone.MoveFirst();

			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				rsTempClone.Find("L_Filter_Name = '" + pAlignmentText + "'");
			}
			else
			{
				rsTempClone.Find("a_Filter_Name = '" + pAlignmentText + "'");
			}

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			switch(Convert.ToInt32(Conversion.Val(Convert.ToString(rsTempClone.Tables[0].Rows[0]["filter_type_id"]))))
			{
				case mAlignLeft : 
					return "0";
				case mAlignRight : 
					return "1";
				default:
					return "2";
			}
		}

		private void tabReportOptions_SelectedChanged(Object eventSender, AxXtremeSuiteControls._DTabControlEvents_SelectedChangedEvent eventArgs)
		{
			C1.Win.C1TrueDBGrid.C1DisplayColumn colReportOptions = null;
			int mTotalRequiredColumns = 0;
			int TempCnt = 0;
			int RecordsetCnt = 0;

			//**--disable object repainting
			//SendMessageLong grdReportFilters.hWnd, WM_SETREDRAW, False, &O0

			if (eventArgs.item.Index == tpFilterRange)
			{
				DefineFilterTab();

			}
			else if (eventArgs.item.Index == tpReportColumns)
			{ 
				DefineFieldTab();

			}
			else if (eventArgs.item.Index == tpReportFonts)
			{ 
				DefineFontTab();
			}

			Application.DoEvents();

			if (mFormIsInitialized)
			{
				//grdReportFilters.SetFocus
			}
		}

		private void UpDown_DownClick(Object eventSender, EventArgs eventArgs)
		{
			object aTempValue = null;
			int ColCnt = 0;

			grdReportFields.UpdateData();
			//UPGRADE_WARNING: (1068) grdReportFields.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mCurrentRow = ReflectionHelper.GetPrimitiveValue<int>(grdReportFields.Bookmark);
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
			grdReportFields.Bookmark = mCurrentRow + 1;
			CalculateColumnNumber();
			grdReportFields.Refresh();

		}

		//Private Sub grdReportFields_AfterColUpdate(ByVal ColIndex As Integer)
		//If ColIndex = mColumnWidth Then
		//    If Val(aReportColumns(Val(grdReportFilters.Bookmark), mColumnWidth)) >= 0 And Val(aReportColumns(Val(grdReportFilters.Bookmark), mColumnWidth)) <= 30000 Then
		//
		//End If
		//End Sub

		private void UpDown_UpClick(Object eventSender, EventArgs eventArgs)
		{
			object aTempValue = null;
			int ColCnt = 0;

			grdReportFields.UpdateData();
			//UPGRADE_WARNING: (1068) grdReportFields.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mCurrentRow = ReflectionHelper.GetPrimitiveValue<int>(grdReportFields.Bookmark);
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
			grdReportFields.Bookmark = mCurrentRow - 1;
			CalculateColumnNumber();
			grdReportFields.Refresh();

		}
		private void DefineFieldTab()
		{
			int mTotalRequiredColumns = 0;
			int TempCnt = 0;
			int RecordsetCnt = 0;

			//grdReportFields.Columns.Clear
			//DoEvents
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			if (!mReportColumnTabClicked)
			{
				mTotalRequiredColumns = 13;

				SystemGrid.DefineSystemVoucherGrid(grdReportFields, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.6f, 1.4f, Conversion.Str(mFixedAreaBackColor), "&HB69D8D", 280);
				SystemGrid.DefineSystemGridCombo(cmbFieldList);

				SystemGrid.DefineSystemVoucherGridColumn(grdReportFields, "Column Name", 2700, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFields, "Show", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFields, "Col #", 600, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFields, "Order", 950, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbFieldList", true, true, false, TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFields, "Alignment", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbFieldList", true, true, false, TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFields, "Width", 750, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFields, "Title", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFields, "Wrap", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFields, "Grouped", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFields, "ApplyFormat", 1000);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFields, "Bold", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFields, "Italic", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFields, "BackColor", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFields, "ForeColor", 1000, true);

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar = grdReportFields.Splits[0].DisplayColumns[mColumnShowDetails];
				withVar.DataColumn.ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
				chkAdvancedOptions_CheckStateChanged(chkAdvancedOptions, new EventArgs());


				//**--get the filter types list from database
				rsColumnTypeList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsColumnTypeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsColumnTypeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter("select * from SM_REPORT_FILTERS", SystemVariables.gConn);
				rsColumnTypeList.Tables.Clear();
				adap.Fill(rsColumnTypeList);

				aReportColumns = new XArrayHelper();
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property oDetailsRecordset.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.setSort("column_no asc, column_id asc");
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method oDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.MoveFirst();
				TempCnt = 0;
				RecordsetCnt = 0;

				foreach (DataRow iteration_row in oDetailsRecordset.Tables[0].Rows)
				{
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (iteration_row["alias_id"] == oMasterRecordset.Tables[0].Rows[0]["alias_id"] && ((TriState) Convert.ToInt32(iteration_row["show"])) == TriState.True)
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
						aReportColumns.SetValue("", TempCnt, mColumnOrder);
						aReportColumns.SetValue(iteration_row["default_width"], TempCnt, mColumnWidth);
						aReportColumns.SetValue(iteration_row["show_title"], TempCnt, mColumnShowTitle);
						aReportColumns.SetValue(iteration_row["Allow_Wrap_Text"], TempCnt, mColumnWordWrap);
						aReportColumns.SetValue(iteration_row["Grouped_Column"], TempCnt, mColumnEnableGrouping);
						aReportColumns.SetValue(iteration_row["Apply_Special_Format"], TempCnt, mColumnApplySpecialFormat);
						aReportColumns.SetValue(iteration_row["Show_In_Bold"], TempCnt, mColumnShowBold);
						aReportColumns.SetValue(iteration_row["Show_In_Italic"], TempCnt, mColumnShowItalic);
						aReportColumns.SetValue(iteration_row["Column_Back_Color"], TempCnt, mColumnBackColor);
						aReportColumns.SetValue(iteration_row["Column_Fore_Color"], TempCnt, mColumnForeColor);
						//**--get the column alignment
						string switchVar = Convert.ToString(iteration_row["field_alignment"]).ToUpper();
						if (switchVar == ("L").ToUpper())
						{
							rsColumnTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignLeft);
						}
						else if (switchVar == ("R").ToUpper())
						{ 
							rsColumnTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignRight);
						}
						else
						{
							rsColumnTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignCenter);
						}
						aReportColumns.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsColumnTypeList.Tables[0].Rows[0]["l_filter_name"] : rsColumnTypeList.Tables[0].Rows[0]["a_filter_name"], TempCnt, mColumnAlignment);
						aReportColumns.SetValue(iteration_row["enable_sorting"], TempCnt, mColumnEnableSorting);
						aReportColumns.SetValue(iteration_row["column_id"], TempCnt, mColumnFieldID);
						//**-------------------------------------------------------------------------------------------

						TempCnt++;
					}
				}
				mReportColumnTabClicked = true;

				CalculateColumnNumber();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdReportFields.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdReportFields.setArray(aReportColumns);
				grdReportFields.Rebind(true);
			}

		}

		private void DefineFilterTab()
		{
			string[] mTempFilterTypes = null;
			int mTotalRequiredColumns = 0;
			int TempCnt = 0;
			int RecordsetCnt = 0;

			if (!mReportFilterTabClicked)
			{
				SystemGrid.DefineSystemVoucherGrid(grdReportFilters, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.6f, 1.4f, Conversion.Str(mFixedAreaBackColor), "&HB69D8D", 280);
				SystemGrid.DefineSystemGridCombo(cmbFilterList);

				mTotalRequiredColumns = 3;
				//SendMessageLong grdReportFilters.hWnd, WM_SETREDRAW, False, &O0

				//grdReportFilters.Columns.Clear
				//DoEvents

				//**--setting column's common properties
				//With grdReportFilters
				//    For TempCnt = 0 To mTotalRequiredColumns
				//        Set colReportOptions = .Columns.Add(TempCnt)
				//        With colReportOptions
				//            .AllowSizing = False
				//            .DividerStyle = dbgBlackLine
				//            .Style.VerticalAlignment = dbgVertCenter
				//            .Visible = True
				//            If gPreferedLanguage = English Then
				//                '.Font.Name = "Arial"
				//            Else
				//                .Font.Name = gArabicFontName
				//            End If
				//        End With
				//    Next
				//End With

				SystemGrid.DefineSystemVoucherGridColumn(grdReportFilters, "Filter Column", 2000, false, Conversion.Str(mFixedAreaBackColor));
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFilters, "Type", 1400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbFilterList", true);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFilters, "From", 1700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFilters, "To", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "", false, true, false, TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone);

				//        .left = 120
				//        .Width = 6800
				//       .MarqueeStyle = dbgFloatingEditor
				//       lblCommon(lcTabInfo).left = 150
				//       lblCommon(lcTabInfo).Caption = "Filter Range:"

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(oMasterRecordset.Tables[0].Rows[0]["show_date_range"])) == TriState.True)
				{
					lblCommon[lcFromDate].Visible = true;
					lblCommon[lcToDate].Visible = true;
					txtDateRange[tcReportFromDate].Visible = true;
					txtDateRange[tcReportToDate].Visible = true;
					fraDateRange.Visible = true;

					//                lblCommon(lcTabInfo).top = 1300
					grdReportFilters.Top = 53;
					grdReportFilters.Height = 176;
				}
				else
				{
					//                lblCommon(lcTabInfo).top = 250
					grdReportFilters.Top = 10;
					grdReportFilters.Height = 220;
				}



				//**--get the filter types list from database
				rsFilterTypeList = new DataSet();
				aFilterRange = new XArrayHelper();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsFilterTypeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsFilterTypeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter("select * from SM_REPORT_FILTERS", SystemVariables.gConn);
				rsFilterTypeList.Tables.Clear();
				adap.Fill(rsFilterTypeList);
				//**-----------------------------------------------------------------------------------------------------

				//UPGRADE_ISSUE: (2064) ADODB.Recordset property oDetailsRecordset.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.setSort("column_no asc, column_id asc");
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method oDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oDetailsRecordset.MoveFirst();
				TempCnt = 0;
				RecordsetCnt = 0;

				foreach (DataRow iteration_row in oDetailsRecordset.Tables[0].Rows)
				{
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (iteration_row["alias_id"] == oMasterRecordset.Tables[0].Rows[0]["alias_id"] && ((TriState) Convert.ToInt32(iteration_row["show"])) == TriState.True && ((TriState) Convert.ToInt32(iteration_row["Enable_Filter"])) == TriState.True && Conversion.Val(Convert.ToString(iteration_row["Column_Type"])) == 1)
					{
						aFilterRange.RedimXArray(new int[]{TempCnt, 11}, new int[]{0, 0});


						//'''get the find Id
						aFilterRange.SetValue(iteration_row["Report_Options_Find_Id"], TempCnt, mFilterFindId);
						aFilterRange.SetValue(iteration_row["Report_Options_Find_Return_Column_Id"], TempCnt, mFilterFindReturnColumnId);
						aFilterRange.SetValue(iteration_row["Field_Type"], TempCnt, mFilterFieldType);
						//''''''''''''''

						//**--get the filter field caption
						if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
						{
							aFilterRange.SetValue(" " + Convert.ToString(iteration_row["l_field_caption"]), TempCnt, mFilterFieldNameColumn);
						}
						else
						{
							aFilterRange.SetValue(" " + Convert.ToString(iteration_row["a_field_caption"]), TempCnt, mFilterFieldNameColumn);
						}
						//**--get the filter type name
						mTempFilterTypes = Convert.ToString(iteration_row["Filter_List_Types"]).Split(',');

						rsFilterTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + mTempFilterTypes[0];
						if (rsFilterTypeList.Tables[0].Rows.Count != 0)
						{
							aFilterRange.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsFilterTypeList.Tables[0].Rows[0]["l_filter_name"] : rsFilterTypeList.Tables[0].Rows[0]["a_filter_name"], TempCnt, mFilterFieldTypeColumn);
						}
						else
						{
							aFilterRange.SetValue("", TempCnt, mFilterFieldTypeColumn);
						}
						aFilterRange.SetValue("", TempCnt, mFilterFromColumn);
						aFilterRange.SetValue("", TempCnt, mFilterToColumn);

						aFilterRange.SetValue(iteration_row["column_id"], TempCnt, mFilterColumnID);
						aFilterRange.SetValue(iteration_row["Filter_List_Types"], TempCnt, mFilterTypeValues);
						aFilterRange.SetValue(iteration_row["List_SQL_Type"], TempCnt, mFilterListSQLType);
						switch(Convert.ToInt32(Conversion.Val(Convert.ToString(iteration_row["List_SQL_Type"]))))
						{
							case 0 : 
								rsComboLists = ArraysHelper.RedimPreserve(rsComboLists, new int[]{RecordsetCnt + 1}); 
								rsComboLists[RecordsetCnt] = new DataSet(); 
								//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
								//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsComboLists.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
								rsComboLists[RecordsetCnt].setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient()); 
								 
								rsFilterTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Convert.ToString(iteration_row["Standard_Filter_List_Type_Id"]); 
								if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
								{
									SqlDataAdapter adap_2 = new SqlDataAdapter(Convert.ToString(rsFilterTypeList.Tables[0].Rows[0]["L_List_Field_SQL"]), SystemVariables.gConn);
									rsComboLists[RecordsetCnt].Tables.Clear();
									adap_2.Fill(rsComboLists[RecordsetCnt]);
								}
								else
								{
									SqlDataAdapter adap_3 = new SqlDataAdapter(Convert.ToString(rsFilterTypeList.Tables[0].Rows[0]["a_List_Field_SQL"]), SystemVariables.gConn);
									rsComboLists[RecordsetCnt].Tables.Clear();
									adap_3.Fill(rsComboLists[RecordsetCnt]);
								} 
								aFilterRange.SetValue(rsComboLists[RecordsetCnt].Tables[0].Rows[0], TempCnt, mFilterFromListValues); 
								 
								RecordsetCnt++; 
								break;
							case 1 : 
								rsComboLists = ArraysHelper.RedimPreserve(rsComboLists, new int[]{RecordsetCnt + 1}); 
								rsComboLists[RecordsetCnt] = new DataSet(); 
								//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
								//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsComboLists.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
								rsComboLists[RecordsetCnt].setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient()); 
								 
								if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
								{
									SqlDataAdapter adap_4 = new SqlDataAdapter(Convert.ToString(iteration_row["Custom_L_List_Field_SQL"]), SystemVariables.gConn);
									rsComboLists[RecordsetCnt].Tables.Clear();
									adap_4.Fill(rsComboLists[RecordsetCnt]);
								}
								else
								{
									SqlDataAdapter adap_5 = new SqlDataAdapter(Convert.ToString(iteration_row["Custom_A_List_Field_SQL"]), SystemVariables.gConn);
									rsComboLists[RecordsetCnt].Tables.Clear();
									adap_5.Fill(rsComboLists[RecordsetCnt]);
								} 
								aFilterRange.SetValue(rsComboLists[RecordsetCnt].Tables[0].Rows[0], TempCnt, mFilterFromListValues); 
								 
								RecordsetCnt++; 
								break;
							case 2 : 
								aFilterRange.SetValue(iteration_row["Builtin_From_List_Types"], TempCnt, mFilterFromListValues); 
								aFilterRange.SetValue(iteration_row["Builtin_To_List_Types"], TempCnt, mFilterToListValues); 
								break;
							case 3 : 
								aFilterRange.SetValue("", TempCnt, mFilterFromListValues); 
								aFilterRange.SetValue("", TempCnt, mFilterToListValues); 
								break;
						}

						//**-----------Default Value------------
						if (!oDetailsRecordset.Tables[0].Rows[0].IsNull("Default_Filter_List_Types"))
						{
							aFilterRange.SetValue(iteration_row["Default_From_Value"], TempCnt, mFilterFromColumn);
							aFilterRange.SetValue(iteration_row["Default_To_Value"], TempCnt, mFilterToColumn);
						}
						//-------------------------------------
						TempCnt++;
					}
				}
				mReportFilterTabClicked = true;

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdReportFilters.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdReportFilters.setArray(aFilterRange);
				grdReportFilters.Rebind(true);
			}
		}

		private void DefineFontTab()
		{





			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			if (!mReportFontTabClicked)
			{
				SystemGrid.DefineSystemVoucherGrid(grdReportFormats, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.6f, Single.Parse(Conversion.Str(mFixedAreaBackColor)), "&HB69D8D", "280");
				SystemGrid.DefineSystemGridCombo(cmbFormatList);

				SystemGrid.DefineSystemVoucherGridColumn(grdReportFormats, "Show", 600, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFormats, "Report Band", 1700, false, Conversion.Str(mFixedAreaBackColor), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFormats, "Font Details", 3200, false, Conversion.Str(mFixedAreaBackColor), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFormats, "", 400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone);
				SystemGrid.DefineSystemVoucherGridColumn(grdReportFormats, "Alignment", 500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbFormatList", true);


				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar = grdReportFormats.Splits[0].DisplayColumns[mFontReportBandShow];
				withVar.DataColumn.ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;

				//    With .Columns(mFontReportBand)
				//        .AllowFocus = False
				//        .BackColor = mFixedAreaBackColor
				//        .Caption = "Report Band"
				//        .Width = 1700
				//    End With
				//    With .Columns(mFontDetails)
				//        .AllowFocus = False
				//        .BackColor = gDisableColumnBackColor
				//        .Caption = "Font Details"
				//        .FetchStyle = dbgFetchCellStyleColumn
				//        .HeaderDivider = False
				//        .Width = 3500
				//    End With
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_2 = grdReportFormats.Splits[0].DisplayColumns[mFontIcon];
				withVar_2.ButtonAlways = true;
				withVar_2.ButtonText = true;
				withVar_2.Style.Font = withVar_2.Style.Font.Change(bold:true, size:11, name:"Verdana");
				withVar_2.Style.ForeColor = Color.FromArgb(21, 64, 77);

				//    With .Columns(mFontReportBandAlignment)
				//        .Alignment = dbgLeft
				//        .AutoDropDown = True
				//        .AutoCompletion = True
				//        .AllowFocus = True
				//        .Caption = "Alignment"
				//        .DropDown = "cmbFormatList"
				//        .DropDownList = True
				//        .FetchStyle = dbgFetchCellStyleColumn
				//        .Width = 800
				//    End With


				//**--get the filter types list from database
				rsFormatTypeList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsFormatTypeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsFormatTypeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter("select * from SM_REPORT_FILTERS", SystemVariables.gConn);
				rsFormatTypeList.Tables.Clear();
				adap.Fill(rsFormatTypeList);

				aReportFonts = new XArrayHelper();
				aReportFonts.RedimXArray(new int[]{9, 9}, new int[]{0, 0});


				//**--get the band alignment
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077

				switch(Convert.ToInt32(Conversion.Val(Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["Company_Font_Alignment"]))))
				{
					case 0 : 
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignLeft); 
						 
						break;
					case 1 : 
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignRight); 
						 
						break;
					default:
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignCenter); 
						break;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Show_Company_Name"], mReportBandCompanyName, mFontReportBandShow);
				aReportFonts.SetValue(" Company Name", mReportBandCompanyName, mFontReportBand);
				aReportFonts.SetValue("A", mReportBandCompanyName, mFontIcon);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsFormatTypeList.Tables[0].Rows[0]["l_filter_name"] : rsFormatTypeList.Tables[0].Rows[0]["a_filter_name"], mReportBandCompanyName, mFontReportBandAlignment);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Company_Font_Name"], mReportBandCompanyName, mFontName);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Company_Font_size"], mReportBandCompanyName, mFontSize);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Company_Font_bold"], mReportBandCompanyName, mFontBold);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Company_Font_italic"], mReportBandCompanyName, mFontItalic);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Company_Font_color"], mReportBandCompanyName, mFontColor);

				//**--get the band alignment
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077

				switch(Convert.ToInt32(Conversion.Val(Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["Report_Name_Font_Alignment"]))))
				{
					case 0 : 
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignLeft); 
						 
						break;
					case 1 : 
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignRight); 
						 
						break;
					default:
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignCenter); 
						break;
				}

				aReportFonts.SetValue(TriState.True, mReportBandReportName, mFontReportBandShow);
				aReportFonts.SetValue(" Report Name", mReportBandReportName, mFontReportBand);
				aReportFonts.SetValue("A", mReportBandReportName, mFontIcon);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsFormatTypeList.Tables[0].Rows[0]["l_filter_name"] : rsFormatTypeList.Tables[0].Rows[0]["a_filter_name"], mReportBandReportName, mFontReportBandAlignment);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Report_Name_Font_Name"], mReportBandReportName, mFontName);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Report_Name_Font_size"], mReportBandReportName, mFontSize);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Report_Name_Font_bold"], mReportBandReportName, mFontBold);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Report_Name_Font_italic"], mReportBandReportName, mFontItalic);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Report_Name_Font_color"], mReportBandReportName, mFontColor);

				aReportFonts.SetValue(TriState.True, mReportBandColumnHeader, mFontReportBandShow);
				aReportFonts.SetValue(" Column Header", mReportBandColumnHeader, mFontReportBand);
				aReportFonts.SetValue("A", mReportBandColumnHeader, mFontIcon);
				aReportFonts.SetValue("", mReportBandColumnHeader, mFontReportBandAlignment);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Column_Header_Font_Name"], mReportBandColumnHeader, mFontName);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Column_Header_Font_size"], mReportBandColumnHeader, mFontSize);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Column_Header_Font_bold"], mReportBandColumnHeader, mFontBold);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Column_Header_Font_italic"], mReportBandColumnHeader, mFontItalic);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Column_Header_Font_color"], mReportBandColumnHeader, mFontColor);

				aReportFonts.SetValue(TriState.True, mReportBandColumnDetails, mFontReportBandShow);
				aReportFonts.SetValue(" Column Details", mReportBandColumnDetails, mFontReportBand);
				aReportFonts.SetValue("A", mReportBandColumnDetails, mFontIcon);
				aReportFonts.SetValue("", mReportBandColumnDetails, mFontReportBandAlignment);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Column_Details_Font_Name"], mReportBandColumnDetails, mFontName);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Column_Details_Font_size"], mReportBandColumnDetails, mFontSize);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Column_Details_Font_bold"], mReportBandColumnDetails, mFontBold);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Column_Details_Font_italic"], mReportBandColumnDetails, mFontItalic);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Column_Details_Font_color"], mReportBandColumnDetails, mFontColor);

				//**--get the band alignment
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077

				switch(Convert.ToInt32(Conversion.Val(Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["title_filter_font_alignment"]))))
				{
					case 0 : 
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignLeft); 
						 
						break;
					case 1 : 
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignRight); 
						 
						break;
					default:
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignCenter); 
						break;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Show_Title_Filter_Condition"], mReportBandTitleFilter, mFontReportBandShow);
				aReportFonts.SetValue(" Title Filter", mReportBandTitleFilter, mFontReportBand);
				aReportFonts.SetValue("A", mReportBandTitleFilter, mFontIcon);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsFormatTypeList.Tables[0].Rows[0]["l_filter_name"] : rsFormatTypeList.Tables[0].Rows[0]["a_filter_name"], mReportBandTitleFilter, mFontReportBandAlignment);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Title_Filter_Font_Name"], mReportBandTitleFilter, mFontName);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Title_Filter_Font_size"], mReportBandTitleFilter, mFontSize);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Title_Filter_Font_bold"], mReportBandTitleFilter, mFontBold);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Title_Filter_Font_italic"], mReportBandTitleFilter, mFontItalic);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Title_Filter_Font_color"], mReportBandTitleFilter, mFontColor);

				//**--get the band alignment
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077

				switch(Convert.ToInt32(Conversion.Val(Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["Details_Filter_Font_Alignment"]))))
				{
					case 0 : 
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignLeft); 
						 
						break;
					case 1 : 
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignRight); 
						 
						break;
					default:
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignCenter); 
						break;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Show_Filter_Condition"], mReportBandDetailsFilter, mFontReportBandShow);
				aReportFonts.SetValue(" Details Filter", mReportBandDetailsFilter, mFontReportBand);
				aReportFonts.SetValue("A", mReportBandDetailsFilter, mFontIcon);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsFormatTypeList.Tables[0].Rows[0]["l_filter_name"] : rsFormatTypeList.Tables[0].Rows[0]["a_filter_name"], mReportBandDetailsFilter, mFontReportBandAlignment);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Details_Filter_Font_Name"], mReportBandDetailsFilter, mFontName);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Details_Filter_Font_size"], mReportBandDetailsFilter, mFontSize);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Details_Filter_Font_bold"], mReportBandDetailsFilter, mFontBold);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Details_Filter_Font_italic"], mReportBandDetailsFilter, mFontItalic);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Details_Filter_Font_color"], mReportBandDetailsFilter, mFontColor);

				//**--get the band alignment
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077

				switch(Convert.ToInt32(Conversion.Val(Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["Date_Range_Font_Alignment"]))))
				{
					case 0 : 
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignLeft); 
						 
						break;
					case 1 : 
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignRight); 
						 
						break;
					default:
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignCenter); 
						break;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Show_Date_Range"], mReportBandDateRange, mFontReportBandShow);
				aReportFonts.SetValue(" Date Range", mReportBandDateRange, mFontReportBand);
				aReportFonts.SetValue("A", mReportBandDateRange, mFontIcon);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsFormatTypeList.Tables[0].Rows[0]["l_filter_name"] : rsFormatTypeList.Tables[0].Rows[0]["a_filter_name"], mReportBandDateRange, mFontReportBandAlignment);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Date_Range_Font_Name"], mReportBandDateRange, mFontName);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Date_Range_Font_size"], mReportBandDateRange, mFontSize);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Date_Range_Font_bold"], mReportBandDateRange, mFontBold);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Date_Range_Font_italic"], mReportBandDateRange, mFontItalic);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Date_Range_Font_color"], mReportBandDateRange, mFontColor);

				//**--get the band alignment
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077

				switch(Convert.ToInt32(Conversion.Val(Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["Address_Font_Alignment"]))))
				{
					case 0 : 
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignLeft); 
						 
						break;
					case 1 : 
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignRight); 
						 
						break;
					default:
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignCenter); 
						break;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Show_Addr1"], mReportBandAddress, mFontReportBandShow);
				aReportFonts.SetValue(" Address", mReportBandAddress, mFontReportBand);
				aReportFonts.SetValue("A", mReportBandAddress, mFontIcon);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsFormatTypeList.Tables[0].Rows[0]["l_filter_name"] : rsFormatTypeList.Tables[0].Rows[0]["a_filter_name"], mReportBandAddress, mFontReportBandAlignment);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Address_Font_Name"], mReportBandAddress, mFontName);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Address_Font_size"], mReportBandAddress, mFontSize);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Address_Font_bold"], mReportBandAddress, mFontBold);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Address_Font_italic"], mReportBandAddress, mFontItalic);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Address_Font_color"], mReportBandAddress, mFontColor);

				//**--get the band alignment
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077

				switch(Convert.ToInt32(Conversion.Val(Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["Title1_Font_Alignment"]))))
				{
					case 0 : 
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignLeft); 
						 
						break;
					case 1 : 
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignRight); 
						 
						break;
					default:
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignCenter); 
						break;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Show_Title1"], mReportBandTitle1, mFontReportBandShow);
				aReportFonts.SetValue(" Title 1", mReportBandTitle1, mFontReportBand);
				aReportFonts.SetValue("A", mReportBandTitle1, mFontIcon);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsFormatTypeList.Tables[0].Rows[0]["l_filter_name"] : rsFormatTypeList.Tables[0].Rows[0]["a_filter_name"], mReportBandTitle1, mFontReportBandAlignment);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Title1_Font_Name"], mReportBandTitle1, mFontName);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Title1_Font_size"], mReportBandTitle1, mFontSize);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Title1_Font_bold"], mReportBandTitle1, mFontBold);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Title1_Font_italic"], mReportBandTitle1, mFontItalic);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Title1_Font_color"], mReportBandTitle1, mFontColor);

				//**--get the band alignment
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				switch(Convert.ToInt32(Conversion.Val(Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["Title2_Font_Alignment"]))))
				{
					case 0 : 
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignLeft); 
						 
						break;
					case 1 : 
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignRight); 
						 
						break;
					default:
						rsFormatTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + Conversion.Str(mAlignCenter); 
						break;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Show_Title2"], mReportBandTitle2, mFontReportBandShow);
				aReportFonts.SetValue(" Title 2", mReportBandTitle2, mFontReportBand);
				aReportFonts.SetValue("A", mReportBandTitle2, mFontIcon);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsFormatTypeList.Tables[0].Rows[0]["l_filter_name"] : rsFormatTypeList.Tables[0].Rows[0]["a_filter_name"], mReportBandTitle2, mFontReportBandAlignment);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Title2_Font_Name"], mReportBandTitle2, mFontName);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Title2_Font_size"], mReportBandTitle2, mFontSize);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Title2_Font_bold"], mReportBandTitle2, mFontBold);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Title2_Font_italic"], mReportBandTitle2, mFontItalic);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aReportFonts.SetValue(oMasterRecordset.Tables[0].Rows[0]["Title2_Font_color"], mReportBandTitle2, mFontColor);

				mReportFontTabClicked = true;
				GetFontStatus();

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdReportFormats.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdReportFormats.setArray(aReportFonts);
				grdReportFormats.Rebind(true);
			}

		}

		private void cmdColor_Click(Object eventSender, EventArgs eventArgs)
		{
			if (ReflectionHelper.GetValueForcedToCursor(ColorTranslator.ToOle(rtbFooter.SelectionColor)) == CursorHelper.CursorDefault)
			{
				rtbFooter.SelectionColor = Color.Blue;
			}
			else
			{
				rtbFooter.SelectionColor = ColorTranslator.FromOle(0);
			}
			rtbFooter.Refresh();
		}

		private void cmdBold_Click(Object eventSender, EventArgs eventArgs)
		{
			if (!ReflectionHelper.GetPrimitiveValue<bool>(rtbFooter.SelectionFont.Bold))
			{
				rtbFooter.SelectionFont = rtbFooter.SelectionFont.Change(bold:true);
			}
			else
			{
				rtbFooter.SelectionFont = rtbFooter.SelectionFont.Change(bold:false);
			}
		}

		private void cmdItalic_Click(Object eventSender, EventArgs eventArgs)
		{
			if (!ReflectionHelper.GetPrimitiveValue<bool>(rtbFooter.SelectionFont.Italic))
			{
				rtbFooter.SelectionFont = rtbFooter.SelectionFont.Change(italic:true);
			}
			else
			{
				rtbFooter.SelectionFont = rtbFooter.SelectionFont.Change(italic:false);
			}
		}

		private void cmdUnderline_Click(Object eventSender, EventArgs eventArgs)
		{
			if (!ReflectionHelper.GetPrimitiveValue<bool>(rtbFooter.SelectionFont.Underline))
			{
				rtbFooter.SelectionFont = rtbFooter.SelectionFont.Change(underline:true);
			}
			else
			{
				rtbFooter.SelectionFont = rtbFooter.SelectionFont.Change(underline:false);
			}
		}
	}
}