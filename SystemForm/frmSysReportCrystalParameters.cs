
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSysReportCrystalParameters
		: System.Windows.Forms.Form
	{

		public frmSysReportCrystalParameters()
{
InitializeComponent();
} 
 public  void frmSysReportCrystalParameters_old()
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


		private void frmSysReportCrystalParameters_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private frmSysCRYSTALDesign oParentForm = null;
		private DataSet oMasterRecordset = null;
		private DataSet oDetailsRecordset = null;
		private DataSet[] rsComboLists = null;
		private DataSet rsFilterTypeList = null;
		private XArrayHelper aFilterRange = null;

		private bool mReportFilterTabClicked = false;
		private bool mReportAdvancedTabClicked = false;

		private int mShowOptionsTab = 0;
		private bool mFormIsInitialized = false;
		private Keys mLastButtonClicked = (Keys) 0;

		private const int tcReportFromDate = 0;
		private const int tcReportToDate = 1;

		private const int lcDateRange = 0;
		private const int lcFromDate = 1;
		private const int lcToDate = 2;
		private const int lcTabInfo = 3;

		private const int tpFilterRange = 0;
		private const int tpAdvancedOptions = 1;
		private const int mButtonOk = 0;
		private const int mButtonCancel = 1;
		private const int mButtonHelp = 2;

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

		private const int mEmptyString = 0;
		private const int mFixedAreaBackColor = 0xC4D5EC;

		public void AttachObjects(frmSysCRYSTALDesign pParentForm, DataSet pMasterRecordset, DataSet pDetailsRecordset)
		{
			oParentForm = pParentForm;
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


		public int LastButtonClicked
		{
			get
			{
				return (int) mLastButtonClicked;
			}
		}




		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				this.Text = "Report Parameters  [" + Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["l_report_name"]).Trim() + "]";
			}
			else
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				this.Text = "Report Parameters  [" + Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["a_report_name"]).Trim() + "]";
			}

			SystemGrid.DefineSystemVoucherGrid(grdReportOptions, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.6f, 1.4f, "&HC4D5EC", "&HB69D8D", 280);
			SystemGrid.DefineSystemGridCombo(cmbSearchList);

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			if (((TriState) Convert.ToInt32(oMasterRecordset.Tables[0].Rows[0]["show_date_range"])) == TriState.True)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDateRange[tcReportFromDate].Value = Convert.ToDateTime(oMasterRecordset.Tables[0].Rows[0]["report_from_date"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(oMasterRecordset.Tables[0].Rows[0]["report_from_date_caption"]))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					lblCommon[lcFromDate].Caption = Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["report_from_date_caption"]);
				}
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDateRange[tcReportToDate].Value = Convert.ToDateTime(oMasterRecordset.Tables[0].Rows[0]["report_to_date"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(oMasterRecordset.Tables[0].Rows[0]["report_to_date_caption"]))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					lblCommon[lcToDate].Caption = Convert.ToString(oMasterRecordset.Tables[0].Rows[0]["report_to_date_caption"]);
				}
			}

			tabReportOptions.CurrTab = (short) mShowOptionsTab;
			DoFormatTabs(tpFilterRange);
			mFormIsInitialized = true;
			Application.DoEvents();
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			try
			{

				frmSysReportCrystalParameters.DefInstance = null;
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
					btnReportOptions_ClickEvent(btnReportOptions[mButtonCancel], new EventArgs());
				}



				object mTempSearchValue = null;
				int mCurrentBookmark = 0;
				int mCurrentCol = 0;
				int mCurrentRow = 0;

				if (KeyCode == 115 && this.ActiveControl.Name.ToLower() == ("grdReportOptions").ToLower() && tabReportOptions.CurrTab == tpFilterRange && aFilterRange.GetLength(0) > 0 && (grdReportOptions.Col == mFilterFromColumn || grdReportOptions.Col == mFilterToColumn))
				{

					if (SystemProcedure2.IsItEmpty(grdReportOptions.Bookmark, SystemVariables.DataType.NumberType))
					{
						mCurrentBookmark = 0;
					}
					else
					{
						mCurrentBookmark = Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportOptions.Bookmark)));
					}
					mCurrentCol = grdReportOptions.Col;
					mCurrentRow = grdReportOptions.Row;

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

							grdReportOptions.UpdateData();
							grdReportOptions.Rebind(true);
							grdReportOptions.Refresh();
							grdReportOptions.Bookmark = mCurrentBookmark;
							grdReportOptions.Col = mCurrentCol;
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

		private void grdReportOptions_BeforeRowColChange(object eventSender, C1.Win.C1TrueDBGrid.CancelEventArgs eventArgs)
		{
			bool Cancel = eventArgs.Cancel;
			if (tabReportOptions.CurrTab == tpFilterRange)
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mFilterFromColumn].AllowFocus = true;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mFilterToColumn].AllowFocus = true;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbSearchList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbSearchList_DataSourceChanged()
		{
			int cnt = 0;
			int mComboWidth = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			if (tabReportOptions.CurrTab == tpFilterRange)
			{
				if ((grdReportOptions.Col == mFilterFieldTypeColumn) || (Conversion.Val(Convert.ToString(aFilterRange.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdReportOptions.Bookmark), mFilterListSQLType))) == 2))
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
					cmbSearchList.Width = (mComboWidth + 500) / 15;
				}
				else
				{
					int tempForEndVar2 = cmbSearchList.Columns.Count - 1;
					for (cnt = 0; cnt <= tempForEndVar2; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_2 = cmbSearchList.Splits[0].DisplayColumns[cnt];
						withVar_2.AllowSizing = false;
						withVar_2.Style.HorizontalAlignment = (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? C1.Win.C1TrueDBGrid.AlignHorzEnum.Near : C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
						if (cnt == 0)
						{
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							withVar_2.Width = grdReportOptions.Splits[0].DisplayColumns[grdReportOptions.Col].Width;
						}
						else
						{
							withVar_2.Width = 67;
						}
						mComboWidth += withVar_2.Width;
					}
					cmbSearchList.Width = (mComboWidth + 1500) / 15;
				}
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

			bool mTempValue = false;
			DataSet rsTempClone = null;
			if (tabReportOptions.CurrTab == tpFilterRange && aFilterRange.GetLength(0) > 0)
			{
				mCurrentRow = Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportOptions.Bookmark)));
				mTempFilterString = new StringBuilder("");

				if ((Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(LastRow)) != mCurrentRow) || (LastCol != grdReportOptions.Col))
				{
					//**--check whether column is allowed for editing
					if (grdReportOptions.Col == mFilterFromColumn || grdReportOptions.Col == mFilterToColumn)
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
							rsTempClone.Find("L_Filter_Name = '" + Convert.ToString(aFilterRange.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportOptions.Bookmark))), mFilterFieldTypeColumn)).Trim() + "'");
						}
						else
						{
							rsTempClone.Find("A_Filter_Name = '" + Convert.ToString(aFilterRange.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportOptions.Bookmark))), mFilterFieldTypeColumn)).Trim() + "'");
						}

						if (rsTempClone.Tables[0].Rows.Count != 0)
						{
							if (grdReportOptions.Col == mFilterFromColumn)
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mTempValue = Convert.ToBoolean(rsTempClone.Tables[0].Rows[0]["Allow_Value_In_From"]);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								grdReportOptions.Splits[0].DisplayColumns[mFilterFromColumn].AllowFocus = mTempValue;
							}
							else
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mTempValue = Convert.ToBoolean(rsTempClone.Tables[0].Rows[0]["Allow_Value_In_To"]);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								grdReportOptions.Splits[0].DisplayColumns[mFilterToColumn].AllowFocus = mTempValue;
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

					switch(grdReportOptions.Col)
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
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbSearchList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbSearchList.setDataSource((msdatasrc.DataSource) rsFilterTypeList); 
							break;
						case mFilterFromColumn : 
							switch(Convert.ToInt32(Conversion.Val(Convert.ToString(aFilterRange.GetValue(mCurrentRow, mFilterListSQLType)))))
							{
								case 0 : case 1 : 
									grdReportOptions.Columns[grdReportOptions.Col].DropDown = cmbSearchList; 
									//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbSearchList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
									cmbSearchList.setDataSource((msdatasrc.DataSource) aFilterRange.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportOptions.Bookmark))), mFilterFromListValues)); 
									break;
								case 2 : 
									grdReportOptions.Columns[grdReportOptions.Col].DropDown = cmbSearchList; 
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
									//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbSearchList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
									cmbSearchList.setDataSource((msdatasrc.DataSource) rsFilterTypeList); 
									break;
								case 3 : 
									grdReportOptions.Columns[grdReportOptions.Col].DropDown = null; 
									break;
							} 
							grdReportOptions.EditActive = true; 
							break;
						case mFilterToColumn : 
							switch(Convert.ToInt32(Conversion.Val(Convert.ToString(aFilterRange.GetValue(mCurrentRow, mFilterListSQLType)))))
							{
								case 0 : case 1 : 
									grdReportOptions.Columns[grdReportOptions.Col].DropDown = cmbSearchList; 
									//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbSearchList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
									cmbSearchList.setDataSource((msdatasrc.DataSource) aFilterRange.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportOptions.Bookmark))), mFilterFromListValues)); 
									break;
								case 2 : 
									grdReportOptions.Columns[grdReportOptions.Col].DropDown = cmbSearchList; 
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
									//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbSearchList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
									cmbSearchList.setDataSource((msdatasrc.DataSource) rsFilterTypeList); 
									break;
								case 3 : 
									grdReportOptions.Columns[grdReportOptions.Col].DropDown = null; 
									break;
							} 
							grdReportOptions.EditActive = true; 
							break;
					}
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdReportOptions.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdReportOptions_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			bool mTempValue = false;
			DataSet rsTempClone = null;
			if (tabReportOptions.CurrTab == tpFilterRange)
			{
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
							CellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(SystemConstants.gDisableColumnBackColor)));
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
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbSearchList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbSearchList_DropDownClose()
		{
			if (tabReportOptions.CurrTab == tpFilterRange)
			{
				grdReportOptions.UpdateData();
				grdReportOptions.RefreshRow(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdReportOptions.Bookmark)));
				grdReportOptions_RowColChange(grdReportOptions, new C1.Win.C1TrueDBGrid.RowColChangeEventArgs());
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbSearchList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbSearchList_RowChange()
		{
			if (tabReportOptions.CurrTab == tpFilterRange)
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mFilterFromColumn].AllowFocus = true;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdReportOptions.Splits[0].DisplayColumns[mFilterToColumn].AllowFocus = true;
			}
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
				if (rsTempClone.Tables[0].Rows.Count == 0)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempClone.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsTempClone.MoveFirst();
					rsTempClone.Find("L_Filter_Name = '" + pFilterTypeValue.Trim() + "'");
				}
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

		private bool SetReportFilters()
		{
			bool result = false;
			DataSet rsTempClone = null;
			int mColumnID = 0;
			string mColumnParameterName = "";
			string mColumnParameterName2 = "";
			int cnt = 0;
			bool mProtectedColumn = false;
			clsHourGlass myHourGlass = null;

			try
			{

				myHourGlass = new clsHourGlass();
				//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsFilterTypeList.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempClone = rsFilterTypeList.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempClone.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();

				if (txtDateRange[tcReportFromDate].Visible)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oMasterRecordset.Tables[0].Rows[0]["report_from_date"].setValue(ReflectionHelper.GetPrimitiveValue(txtDateRange[tcReportFromDate].Value));
					oParentForm.crrPrimaryReport.ParameterFields.GetItemByName("@FromDate", Type.Missing).ClearCurrentValueAndRange();
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					oParentForm.crrPrimaryReport.ParameterFields.GetItemByName("@FromDate", Type.Missing).AddCurrentValue(Convert.ToDateTime(oMasterRecordset.Tables[0].Rows[0]["report_from_date"]));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(oMasterRecordset.Tables[0].Rows[0]["show_as_on_date_only"])) == TriState.False)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property oMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						oMasterRecordset.Tables[0].Rows[0]["report_to_date"].setValue(ReflectionHelper.GetPrimitiveValue(txtDateRange[tcReportToDate].Value));
						oParentForm.crrPrimaryReport.ParameterFields.GetItemByName("@ToDate", Type.Missing).ClearCurrentValueAndRange();
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						oParentForm.crrPrimaryReport.ParameterFields.GetItemByName("@ToDate", Type.Missing).AddCurrentValue(Convert.ToDateTime(oMasterRecordset.Tables[0].Rows[0]["report_to_date"]));
					}
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method oMasterRecordset.Update was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					oMasterRecordset.Update_Renamed(null, null);
				}

				//**--setting all other parameters
				//**--Get values from filter grid
				int tempForEndVar = aFilterRange.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					//**--get the column id value
					mColumnID = Convert.ToInt32(aFilterRange.GetValue(cnt, mFilterColumnID));
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempClone.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsTempClone.MoveFirst();
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						rsTempClone.Find("L_Filter_Name = '" + Convert.ToString(aFilterRange.GetValue(cnt, mFilterFieldTypeColumn)).Trim() + "'");
					}
					else
					{
						rsTempClone.Find("A_Filter_Name = '" + Convert.ToString(aFilterRange.GetValue(cnt, mFilterFieldTypeColumn)).Trim() + "'");
					}
					if (rsTempClone.Tables[0].Rows.Count != 0)
					{
						mColumnParameterName = ReflectionHelper.GetPrimitiveValue<string>(SystemReports.GetColumnInformation("column_id = " + Conversion.Str(mColumnID), "linked_parameter_name", oDetailsRecordset)) + "";
						mColumnParameterName2 = ReflectionHelper.GetPrimitiveValue<string>(SystemReports.GetColumnInformation("column_id = " + Conversion.Str(mColumnID), "linked_parameter_name2", oDetailsRecordset)) + "";
						//UPGRADE_WARNING: (1068) GetColumnInformation() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mProtectedColumn = ReflectionHelper.GetPrimitiveValue<bool>(SystemReports.GetColumnInformation("column_id = " + Conversion.Str(mColumnID), "protected", oDetailsRecordset));

						//**--clearing from columns initial value
						if (mColumnParameterName != "")
						{
							oParentForm.crrPrimaryReport.ParameterFields.GetItemByName(mColumnParameterName, Type.Missing).ClearCurrentValueAndRange();
						}
						else
						{
							//**--assuming from column is a must passed parameter
							MessageBox.Show("Error: No parameter associated", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							throw new Exception();
						}
						//**--clearing to columns initial value
						if (mColumnParameterName2 != "")
						{
							oParentForm.crrPrimaryReport.ParameterFields.GetItemByName(mColumnParameterName2, Type.Missing).ClearCurrentValueAndRange();
						}

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(rsTempClone.Tables[0].Rows[0]["allow_value_in_from"])) == TriState.True)
						{
							//**--check whether the column is a protected one, if so
							//**--then do not allow empty parameter values
							if (mProtectedColumn && SystemProcedure2.IsItEmpty(aFilterRange.GetValue(cnt, mFilterFromColumn), SystemVariables.DataType.StringType))
							{
								MessageBox.Show("Parameter value required for column: " + ReflectionHelper.GetPrimitiveValue<string>(SystemReports.GetColumnInformation("column_id = " + Conversion.Str(mColumnID), (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_field_caption" : "a_field_caption", oDetailsRecordset)), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								grdReportOptions.Focus();
								throw new Exception();
							}
							if (Conversion.Val(Convert.ToString(aFilterRange.GetValue(cnt, mFilterListSQLType))) == 2)
							{
								if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
								{
									//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
									oParentForm.SetColumnFilterValue(mColumnID, mColumnParameterName, GetInterpretedValue(Convert.ToString(aFilterRange.GetValue(cnt, mFilterFromColumn))), true, Convert.ToBoolean(rsTempClone.Tables[0].Rows[0]["filter_already_quoted"]), true, Convert.ToString(aFilterRange.GetValue(cnt, mFilterFromColumn)));
								}
								else
								{
									//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
									oParentForm.SetColumnFilterValue(mColumnID, mColumnParameterName, GetInterpretedValue(Convert.ToString(aFilterRange.GetValue(cnt, mFilterFromColumn))), true, Convert.ToBoolean(rsTempClone.Tables[0].Rows[0]["filter_already_quoted"]), true, Convert.ToString(aFilterRange.GetValue(cnt, mFilterFromColumn)));
								}
							}
							else
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								oParentForm.SetColumnFilterValue(mColumnID, mColumnParameterName, aFilterRange.GetValue(cnt, mFilterFromColumn), true, Convert.ToBoolean(rsTempClone.Tables[0].Rows[0]["filter_already_quoted"]));
							}
						}
						else
						{
							oParentForm.SetColumnFilterValue(mColumnID, mColumnParameterName, "", true, true);
						}

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(rsTempClone.Tables[0].Rows[0]["allow_value_in_to"])) == TriState.True)
						{
							//**--check whether the column is a protected one, if so
							//**--then do not allow empty parameter values
							if (mProtectedColumn && SystemProcedure2.IsItEmpty(aFilterRange.GetValue(cnt, mFilterToColumn), SystemVariables.DataType.StringType))
							{
								MessageBox.Show("Parameter value required for column: " + ReflectionHelper.GetPrimitiveValue<string>(SystemReports.GetColumnInformation("column_id = " + Conversion.Str(mColumnID), (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_field_caption" : "a_field_caption", oDetailsRecordset)), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								grdReportOptions.Focus();
								throw new Exception();
							}
							if (Conversion.Val(Convert.ToString(aFilterRange.GetValue(cnt, mFilterListSQLType))) == 2)
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								oParentForm.SetColumnFilterValue(mColumnID, mColumnParameterName2, GetInterpretedValue(Convert.ToString(aFilterRange.GetValue(cnt, mFilterToColumn))), false, Convert.ToBoolean(rsTempClone.Tables[0].Rows[0]["filter_already_quoted"]), true, Convert.ToString(aFilterRange.GetValue(cnt, mFilterToColumn)));
							}
							else
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								oParentForm.SetColumnFilterValue(mColumnID, mColumnParameterName2, aFilterRange.GetValue(cnt, mFilterToColumn), false, Convert.ToBoolean(rsTempClone.Tables[0].Rows[0]["filter_already_quoted"]));
							}
						}
						else
						{
							oParentForm.SetColumnFilterValue(mColumnID, mColumnParameterName2, "", false, true);
						}
					}
					else
					{
						MessageBox.Show("Error: No such filter type found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						throw new Exception();
					}
				}

				//**--set parameter values for column not being shown in the list
				DataSet rsTempClone2 = null;

				//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method oParentForm.rsDetailsRecordset.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempClone2 = oParentForm.rsDetailsRecordset.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
				if (aFilterRange.GetLength(0) > 0)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempClone2.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsTempClone2.MoveFirst();
					foreach (DataRow iteration_row in rsTempClone2.Tables[0].Rows)
					{
						if (Convert.ToDouble(iteration_row["show"]) == 0)
						{
							oParentForm.crrPrimaryReport.ParameterFields.GetItemByName(Convert.ToString(iteration_row["linked_parameter_name"]), Type.Missing).ClearCurrentValueAndRange();
							if (Conversion.Val(Convert.ToString(iteration_row["list_sql_type"])) == 2)
							{
								oParentForm.SetColumnFilterValue(Convert.ToInt32(Conversion.Val(Convert.ToString(iteration_row["column_id"]))), Convert.ToString(iteration_row["linked_parameter_name"]), GetInterpretedValue(Convert.ToString(iteration_row["default_from_value"])), true, true, true, Convert.ToString(iteration_row["default_from_value"]));
							}
							else
							{
								oParentForm.SetColumnFilterValue(Convert.ToInt32(Conversion.Val(Convert.ToString(iteration_row["column_id"]))), Convert.ToString(iteration_row["linked_parameter_name"]), iteration_row["default_from_value"], true, true, false);
							}
						}

					}
				}
				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempClone2.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();

				result = true;
				rsTempClone = null;
			}
			catch (System.Exception excep)
			{

				result = false;
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return result;
		}

		private void cmdOKCancel_CancelClick()
		{
			Environment.Exit(0);
		}

		private void btnReportOptions_AccessKeyPress(Object eventSender, AxSmartNetButtonProject.__SmartNetButton_AccessKeyPressEvent eventArgs)
		{
			int Index = Array.IndexOf(this.btnReportOptions, eventSender);
			btnReportOptions_ClickEvent(btnReportOptions[Index], new EventArgs());
		}

		private void btnReportOptions_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.btnReportOptions, eventSender);
			int mCurrentRow = 0;
			object aTempValue = null;
			int ColCnt = 0;

			clsHourGlass myHourGlass = new clsHourGlass();
			grdReportOptions.UpdateData();
			switch(Index)
			{
				case mButtonOk : 
					//**--if filter tab was activated ever, set report filters 
					if (mReportFilterTabClicked)
					{
						oParentForm.SetReportData();
						if (!SetReportFilters())
						{
							return;
						}
					} 
					this.Hide(); 
					return;
				case mButtonCancel : 
					mLastButtonClicked = Keys.Cancel; 
					this.Hide(); 
					return;
				case mButtonHelp : 
					break;
			}
			grdReportOptions.Refresh();
			grdReportOptions.Focus();
		}

		private void DoFormatTabs(int pTabIndex)
		{
			string[] mTempFilterTypes = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn colReportOptions = null;
			int mTotalRequiredColumns = 0;
			int TempCnt = 0;
			int RecordsetCnt = 0;

			//**--disable object repainting
			InnovaUpdSupport.PInvoke.SafeNative.user32.SendMessageLong(grdReportOptions.Handle.ToInt32(), SystemAPI.WM_SETREDRAW, 0, 0);

			//**--create no. of report option columns
			switch(pTabIndex)
			{
				case tpFilterRange : 
					mTotalRequiredColumns = 3; 
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
				colReportOptions.AutoComplete = true;
				colReportOptions.ColumnDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single;
				colReportOptions.Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center;
				colReportOptions.Visible = true;
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					colReportOptions.Style.Font = colReportOptions.Style.Font.Change(name:SystemConstants.gArabicFontName1); //"Arial"
				}
				else
				{
					colReportOptions.Style.Font = colReportOptions.Style.Font.Change(name:SystemConstants.gArabicFontName1); //   gArabicFontName
				}
			}

			//**--hide all uncommon controls first
			fraDateRange.Visible = false;
			lblCommon[lcDateRange].Visible = false;
			lblCommon[lcFromDate].Visible = false;
			lblCommon[lcToDate].Visible = false;
			txtDateRange[tcReportFromDate].Visible = false;
			txtDateRange[tcReportToDate].Visible = false;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_3 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_4 = null;
			if (tabReportOptions.CurrTab == tpFilterRange)
			{
				grdReportOptions.Left = 8;
				grdReportOptions.Width = 460;
				grdReportOptions.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor;
				lblCommon[lcTabInfo].Left = 10;
				lblCommon[lcTabInfo].Caption = "Filter Range:";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(oMasterRecordset.Tables[0].Rows[0]["show_date_range"])) == TriState.True)
				{
					lblCommon[lcDateRange].Visible = true;
					lblCommon[lcFromDate].Visible = true;
					txtDateRange[tcReportFromDate].Visible = true;
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(oMasterRecordset.Tables[0].Rows[0]["show_as_on_date_only"])) == TriState.True)
					{
						lblCommon[lcToDate].Visible = false;
						txtDateRange[tcReportToDate].Visible = false;
					}
					else
					{
						lblCommon[lcToDate].Visible = true;
						txtDateRange[tcReportToDate].Visible = true;
					}
					fraDateRange.Visible = true;

					lblCommon[lcTabInfo].Top = 87;
					grdReportOptions.Top = 110;
					grdReportOptions.Height = 176;
				}
				else
				{
					lblCommon[lcTabInfo].Top = 17;
					grdReportOptions.Top = 40;
					grdReportOptions.Height = 233;
				}

				//**--format grid columns and its properties
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar = grdReportOptions.Splits[0].DisplayColumns[mFilterFieldNameColumn];
				withVar.AllowFocus = false;
				withVar.DataColumn.Caption = "Filter Column";
				withVar.Width = 140;
				withVar.Style.BackColor = ColorTranslator.FromOle(mFixedAreaBackColor);
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					withVar.Style.Font = withVar.Style.Font.Change(name:"Arial Narrow");
				}
				else
				{
					withVar.Style.Font = withVar.Style.Font.Change(name:"Arabic Transparent", size:10);
				}

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_2 = grdReportOptions.Splits[0].DisplayColumns[mFilterFieldTypeColumn];
				withVar_2.AllowFocus = true;
				withVar_2.AutoDropDown = true;
				withVar_2.DataColumn.Caption = "Type";
				withVar_2.DataColumn.DropDown = cmbSearchList;
				withVar_2.DropDownList = true;
				withVar_2.Width = 93;

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_3 = grdReportOptions.Splits[0].DisplayColumns[mFilterFromColumn];
				withVar_3.AllowFocus = true;
				withVar_3.AutoDropDown = true;
				withVar_3.DataColumn.Caption = "From";
				withVar_3.FetchStyle = TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone;
				withVar_3.Width = 113;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar_4 = grdReportOptions.Splits[0].DisplayColumns[mFilterToColumn];
				withVar_4.AllowFocus = true;
				withVar_4.AutoDropDown = true;
				withVar_4.DataColumn.Caption = "To";
				withVar_4.FetchStyle = TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone;
				withVar_4.Width = 67;

				if (!mReportFilterTabClicked)
				{

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
					if (oDetailsRecordset.Tables[0].Rows.Count > 0)
					{
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property oDetailsRecordset.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						oDetailsRecordset.setSort("column_no asc");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method oDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						oDetailsRecordset.MoveFirst();
						TempCnt = 0;
						RecordsetCnt = 0;

						foreach (DataRow iteration_row in oDetailsRecordset.Tables[0].Rows)
						{
							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
							if (((TriState) Convert.ToInt32(iteration_row["enable_filter"])) == TriState.True && ((TriState) Convert.ToInt32(iteration_row["show"])) == TriState.True)
							{
								aFilterRange.RedimXArray(new int[]{TempCnt, 10}, new int[]{0, 0});


								//'''get the find Id
								aFilterRange.SetValue(iteration_row["Report_Options_Find_Id"], TempCnt, mFilterFindId);
								aFilterRange.SetValue(iteration_row["Report_Options_Find_Return_Column_Id"], TempCnt, mFilterFindReturnColumnId);
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
								mTempFilterTypes = Convert.ToString(iteration_row["filter_list_types"]).Split(',');

								rsFilterTypeList.Tables[0].DefaultView.RowFilter = "filter_type_id = " + mTempFilterTypes[0];
								if (rsFilterTypeList.Tables[0].Rows.Count != 0)
								{
									aFilterRange.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsFilterTypeList.Tables[0].Rows[0]["l_filter_name"] : rsFilterTypeList.Tables[0].Rows[0]["a_filter_name"], TempCnt, mFilterFieldTypeColumn);
								}
								else
								{
									aFilterRange.SetValue("", TempCnt, mFilterFieldTypeColumn);
								}
								if (Conversion.Val(Convert.ToString(iteration_row["list_sql_type"])) != 2)
								{
									aFilterRange.SetValue(Convert.ToString(iteration_row["default_from_value"]) + "", TempCnt, mFilterFromColumn);
									aFilterRange.SetValue(Convert.ToString(iteration_row["default_to_value"]) + "", TempCnt, mFilterToColumn);
								}
								else
								{
									aFilterRange.SetValue(Convert.ToString(iteration_row["default_from_value"]) + "", TempCnt, mFilterFromColumn);
									aFilterRange.SetValue(Convert.ToString(iteration_row["default_to_value"]) + "", TempCnt, mFilterToColumn);
								}

								aFilterRange.SetValue(iteration_row["column_id"], TempCnt, mFilterColumnID);
								aFilterRange.SetValue(iteration_row["filter_list_types"], TempCnt, mFilterTypeValues);
								aFilterRange.SetValue(iteration_row["list_sql_type"], TempCnt, mFilterListSQLType);
								switch(Convert.ToInt32(Conversion.Val(Convert.ToString(iteration_row["list_sql_type"]))))
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
								TempCnt++;
							}
						}
					}
					mReportFilterTabClicked = true;
				}
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdReportOptions.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdReportOptions.setArray(aFilterRange);
				grdReportOptions.Rebind(true);
			}
			InnovaUpdSupport.PInvoke.SafeNative.user32.SendMessageLong(grdReportOptions.Handle.ToInt32(), SystemAPI.WM_SETREDRAW, -1, 0);
			grdReportOptions.Bookmark = 0;
			grdReportOptions.Refresh();
			fraReportOptions.Refresh();

			if (mFormIsInitialized)
			{
				grdReportOptions.Focus();
			}
		}
	}
}