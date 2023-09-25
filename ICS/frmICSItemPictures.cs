
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmICSItemPictures
		: System.Windows.Forms.Form
	{

		public frmICSItemPictures()
{
InitializeComponent();
} 
 public  void frmICSItemPictures_old()
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


		private void frmICSItemPictures_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private DataSet _rsCommon = null;
		private DataSet rsCommon
		{
			get
			{
				if (_rsCommon is null)
				{
					_rsCommon = new DataSet();
				}
				return _rsCommon;
			}
			set
			{
				_rsCommon = value;
			}
		}

		private DataSet mobjRecordSet = null;
		private C1.Win.C1TrueDBGrid.C1DisplayColumn Col = null;
		private C1.Win.C1TrueDBGrid.C1DataColumnCollection cols = null;
		private int mThisFormID = 0;
		private string mItemNo = "";

		private const int conPartNo = 0;
		private const int conProductName = 1;
		private const int ConPicture = 2;


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


		public string ItemNo
		{
			set
			{
				mItemNo = value;

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property grdVoucherDetails.Columns.FilterText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.Splits[0].DisplayColumns[conPartNo].setFilterText(mItemNo);
				Application.DoEvents();
				grdVoucherDetails_FilterChange(grdVoucherDetails, new EventArgs());
			}
		}


		private void btnFormToolBar_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.btnFormToolBar, eventSender);
			SystemForms.ToolBarButtonClick(frmICSItemPictures.DefInstance, Convert.ToString(btnFormToolBar[Index].Tag));
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			//To Display the HourGlass
			clsHourGlass clsHour = new clsHourGlass();

			this.Top = 0;
			this.Left = 0;

			SystemProcedure2.DrawToolbar(this, picFormToolbar, btnFormToolBar[0]);
			btnFormToolBar[0].Picture = frmSysMain.DefInstance.imlMainToolBar.Images["imgDrillDown"];
			btnFormToolBar[1].Picture = frmSysMain.DefInstance.imlMainToolBar.Images["imgExit"];

			string mysql = " select part_no ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ",l_prod_name" : ",a_prod_name");
			mysql = mysql + ", picture from ICS_Item order by 1";

			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCommon.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsCommon.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsCommon.Tables.Clear();
			adap.Fill(rsCommon);
			grdVoucherDetails.SetDataBinding(rsCommon, "Table", grdVoucherDetails.Columns.Count > 0);
			foreach (C1.Win.C1TrueDBGrid.C1DisplayColumn col2 in grdVoucherDetails.Splits[0].DisplayColumns)
			{
				col2.Visible = true;
			}

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_3 = null;
			C1.Win.C1TrueDBGrid.Style withVar_4 = null;
			C1.Win.C1TrueDBGrid.Style withVar_5 = null;
			C1.Win.C1TrueDBGrid.Style withVar_6 = null;
			C1.Win.C1TrueDBGrid.Style withVar_7 = null;
			C1.Win.C1TrueDBGrid.Style withVar_8 = null;
			C1.Win.C1TrueDBGrid.Style withVar_9 = null;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			withVar = grdVoucherDetails.Splits[0].DisplayColumns[conPartNo];
			withVar.AllowSizing = false;
			withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
			withVar.ButtonHeader = true;
			withVar.DataColumn.Caption = "Part No";
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.DividerColor was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar.setDividerColor(frmSysMain.DefInstance.mnuSystemMenu.GetSpecialColor(XtremeCommandBars.XTPColorManagerColor.XPCOLOR_SEPARATOR));
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.DividerStyleConstants property DividerStyleConstants.dbgCustomColor was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar.ColumnDivider.Style = UpgradeStubs.C1_Win_C1TrueDBGrid_LineStyleEnum.getdbgCustomColor();
			withVar.Width = 87;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			withVar_2 = grdVoucherDetails.Splits[0].DisplayColumns[conProductName];
			withVar_2.AllowSizing = false;
			withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
			withVar_2.ButtonHeader = true;
			withVar_2.DataColumn.Caption = "Product Name";
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_2.DividerColor was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar_2.setDividerColor(frmSysMain.DefInstance.mnuSystemMenu.GetSpecialColor(XtremeCommandBars.XTPColorManagerColor.XPCOLOR_SEPARATOR));
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.DividerStyleConstants property DividerStyleConstants.dbgCustomColor was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar_2.ColumnDivider.Style = UpgradeStubs.C1_Win_C1TrueDBGrid_LineStyleEnum.getdbgCustomColor();
			withVar_2.Width = 187;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			withVar_3 = grdVoucherDetails.Splits[0].DisplayColumns[ConPicture];
			withVar_3.AllowSizing = false;
			withVar_3.Visible = false;
			grdVoucherDetails.HoldFields();

			grdVoucherDetails.AllowAddNew = false;
			grdVoucherDetails.AllowUpdate = false;
			grdVoucherDetails.AllowDelete = false;
			grdVoucherDetails.AllowArrows = true;
			grdVoucherDetails.AllowColMove = false;
			grdVoucherDetails.AllowColSelect = false;
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.AllowRowSelect was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setAllowRowSelect(false);
			grdVoucherDetails.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None;
			grdVoucherDetails.AlternatingRows = true;
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.AnchorRightColumn was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setAnchorRightColumn(true);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.AnimateWindowConstants property AnimateWindowConstants.dbgNoAnimate was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.AnimateWindow was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setAnimateWindow(UpgradeStubs.TrueOleDBGrid80_AnimateWindowConstants.getdbgNoAnimate());
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.AppearanceConstants property AppearanceConstants.dbgXPTheme was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.BorderStyle = UpgradeStubs.System_Windows_Forms_BorderStyle.getdbgXPTheme();
			grdVoucherDetails.BackColor = Color.White;
			grdVoucherDetails.BorderStyle = BorderStyle.FixedSingle;
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.ColumnFooters was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setColumnFooters(false);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.ColumnHeaders was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setColumnHeaders(true);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.MoveDirectionConstants property MoveDirectionConstants.dbgMoveDown was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.DirectionAfterEnter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setDirectionAfterEnter(UpgradeStubs.TrueOleDBGrid80_MoveDirectionConstants.getdbgMoveDown());
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.MoveDirectionConstants property MoveDirectionConstants.dbgMoveDown was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.DirectionAfterTab was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setDirectionAfterTab(UpgradeStubs.TrueOleDBGrid80_MoveDirectionConstants.getdbgMoveDown());
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.EmptyRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setEmptyRows(true);
			grdVoucherDetails.Enabled = true;
			withVar_4 = grdVoucherDetails.EvenRowStyle;
			withVar_4.BackColor = Color.White;
			withVar_4.ForeColor = Color.Black;
			grdVoucherDetails.ExtendRightColumn = true;
			grdVoucherDetails.FetchRowStyles = true;
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.FilterBar was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setFilterBar(true);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.FilterBarStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar_5 = grdVoucherDetails.getFilterBarStyle();
			withVar_5.BackColor = frmSysMain.DefInstance.mnuSystemMenu.GetSpecialColor(XtremeCommandBars.XTPColorManagerColor.XPCOLOR_HIGHLIGHT);
			withVar_5.ForeColor = frmSysMain.DefInstance.mnuSystemMenu.GetSpecialColor(XtremeCommandBars.XTPColorManagerColor.XPCOLOR_HIGHLIGHT_TEXT);
			grdVoucherDetails.Style.ForeColor = Color.Black;
			int headline = 2;
			if (headline == 0)
			{
				grdVoucherDetails.ColumnHeaders = false;
			}
			else
			{
				grdVoucherDetails.ColumnHeaders = true;
				foreach (C1.Win.C1TrueDBGrid.Split currentSplit in grdVoucherDetails.Splits)
				{
					currentSplit.ColumnCaptionHeight = headline * 17;
				}
			}
			grdVoucherDetails.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
			withVar_6 = grdVoucherDetails.HeadingStyle;
			withVar_6.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
			withVar_7 = grdVoucherDetails.HighLightRowStyle;
			withVar_7.BackColor = frmSysMain.DefInstance.mnuSystemMenu.GetSpecialColor(XtremeCommandBars.XTPColorManagerColor.XPCOLOR_HIGHLIGHT);
			withVar_7.ForeColor = frmSysMain.DefInstance.mnuSystemMenu.GetSpecialColor(XtremeCommandBars.XTPColorManagerColor.XPCOLOR_HIGHLIGHT_TEXT);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.FilterBarStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar_8 = grdVoucherDetails.getFilterBarStyle();
			withVar_8.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
			withVar_8.BackColor = Color.FromArgb(202, 221, 183);
			withVar_8.ForeColor = Color.Black;
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.MultipleLinesConstants property MultipleLinesConstants.dbgDisabled was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.MultipleLines was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setMultipleLines(UpgradeStubs.TrueOleDBGrid80_MultipleLinesConstants.getdbgDisabled());
			grdVoucherDetails.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None;
			withVar_9 = grdVoucherDetails.OddRowStyle;
			withVar_9.BackColor = Color.FromArgb(235, 235, 235);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.PartialRightColumn was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setPartialRightColumn(true);
			grdVoucherDetails.RecordSelectors = false;
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.DividerStyleConstants property DividerStyleConstants.dbgCustomColor was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.RowDivider.Style = UpgradeStubs.C1_Win_C1TrueDBGrid_LineStyleEnum.getdbgCustomColor();
			grdVoucherDetails.RowDivider.Color = frmSysMain.DefInstance.mnuSystemMenu.GetSpecialColor(XtremeCommandBars.XTPColorManagerColor.XPCOLOR_SEPARATOR);
			grdVoucherDetails.RowHeight = 17;
			grdVoucherDetails.Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center;
			grdVoucherDetails.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ControlNavigation;
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.ScrollTrack was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setScrollTrack(true);
			grdVoucherDetails.Tag = "1"; //Initialize Tag which will hold the one-based column index value

			//SetMarqueeColor grdVoucherDetails, frmSysMain.mnuSystemMenu.GetSpecialColor(XPCOLOR_HIGHLIGHT), frmSysMain.mnuSystemMenu.GetSpecialColor(XPCOLOR_HIGHLIGHT)
			SendKeys.Send("{UP}");
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				rsCommon = null;
				Col = null;
				cols = null;
				UserAccess = null;
				frmICSItemPictures.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FilterChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FilterChange()
		{
			//Gets called when an action is performed on the filter bar
			try
			{

				cols = grdVoucherDetails.Columns;
				int Cnt = 0;
				Cnt = grdVoucherDetails.Col;

				rsCommon.Tables[0].DefaultView.RowFilter = getFilter();
				grdVoucherDetails.Col = Cnt;
				grdVoucherDetails.EditActive = true;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Source + ":" + Environment.NewLine + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				cmdClearFilter_Click();
			}

		}

		private string getFilter()
		{

			string tmp = "";
			int n = 0;
			int i = 0;

			foreach (C1.Win.C1TrueDBGrid.C1DisplayColumn ColIterator in cols)
			{
				Col = ColIterator;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property Col.FilterText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (Col.getFilterText().Trim() != "")
				{
					n++;
					if (n > 1)
					{
						tmp = tmp + " AND ";
					}
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsCommon.Fields.Type was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					if (rsCommon.Tables[0].Rows[0][i].getType() == DbType.Decimal || rsCommon.Tables[0].Rows[0][i].getType() == DbType.Currency || rsCommon.Tables[0].Rows[0][i].getType() == DbType.Decimal || rsCommon.Tables[0].Rows[0][i].getType() == DbType.Double || rsCommon.Tables[0].Rows[0][i].getType() == DbType.Int32 || rsCommon.Tables[0].Rows[0][i].getType() == DbType.Decimal || rsCommon.Tables[0].Rows[0][i].getType() == DbType.Int16 || rsCommon.Tables[0].Rows[0][i].getType() == DbType.SByte)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property Col.FilterText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						tmp = tmp + "[" + Col.DataColumn.DataField + "] >=" + Col.getFilterText();
					}
					else if (rsCommon.Tables[0].Rows[0][i].getType() == DbType.DateTime || rsCommon.Tables[0].Rows[0][i].getType() == DbType.DateTime)
					{ 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property Col.FilterText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						if (Information.IsDate(Col.getFilterText()) && Strings.Len(Col.getFilterText()) > 8)
						{
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property Col.FilterText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							tmp = tmp + "[" + Col.DataColumn.DataField + "] >='" + Col.getFilterText() + "'";
						}
						else
						{
							if (n > 1)
							{
								n--;
								tmp = tmp.Substring(0, Math.Min(Strings.Len(tmp) - 4, tmp.Length)); //Remove "and"
							}
						}
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property Col.FilterText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						tmp = tmp + "[" + Col.DataColumn.DataField + "] LIKE '" + Col.getFilterText() + "*'";
					}
				}
				i++;
				//frmICSItemPictures.Col
				Col = default(C1.Win.C1TrueDBGrid.C1DisplayColumn);
			}
			return tmp;
		}

		private void cmdClearFilter_Click()
		{
			//Clears filter from grid
			foreach (C1.Win.C1TrueDBGrid.C1DisplayColumn ColIterator in grdVoucherDetails.Columns)
			{
				Col = ColIterator;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property Col.FilterText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				Col.setFilterText("");
				//frmICSItemPictures.Col
				Col = default(C1.Win.C1TrueDBGrid.C1DisplayColumn);
			}

			//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsCommon.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
			grdVoucherDetails.Focus();
		}

		private void grdVoucherDetails_HeadClick(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int iLastSortColIndex = 0; //the zero-based index of the last sorted column
			string sSQL = ""; //query string

			// Save the index of the last sort column and remove the picture
			if (StringsHelper.ToDoubleSafe(Convert.ToString(grdVoucherDetails.Tag)) != 0)
			{
				iLastSortColIndex = Convert.ToInt32(Math.Abs(Convert.ToInt32(Double.Parse(Convert.ToString(grdVoucherDetails.Tag)))) - 1);
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[iLastSortColIndex].HeadingStyle.ForegroundImage = null;
			}

			// Update the Tag property so it describes how to do the sort
			if ((iLastSortColIndex) != (ColIndex))
			{
				grdVoucherDetails.Tag = (ColIndex + 1).ToString(); // Store the one-based number of the column to be sorted
			}
			else
			{
				grdVoucherDetails.Tag = (-1 * Convert.ToInt32(Double.Parse(Convert.ToString(grdVoucherDetails.Tag)))).ToString(); // Change the sort order if same column is re-sorted
			}

			bool bSortAscending = (Convert.ToInt32(Double.Parse(Convert.ToString(grdVoucherDetails.Tag))) > 0); //sort order T/F=ASC/DESC

			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCommon.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsCommon.setSort("[" + grdVoucherDetails.Columns[ColIndex].DataField + "]" + ((bSortAscending) ? " ASC" : " DESC"));

			// Display the appropriate bitmap in the column header
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			C1.Win.C1TrueDBGrid.C1DisplayColumn c = grdVoucherDetails.Splits[0].DisplayColumns[ColIndex]; //object variable for
			C1.Win.C1TrueDBGrid.Style withVar = null;
			withVar = c.HeadingStyle;
			withVar.ForegroundImage = (bSortAscending) ? frmSysMain.DefInstance.imlSystemIcons.Images["imgSortup"] : frmSysMain.DefInstance.imlSystemIcons.Images["imgSortdown"];
			withVar.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.Far;
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.StyleDisp property withVar.TransparentForegroundPicture was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar.setTransparentForegroundPicture(true);
		}

		private void grdVoucherDetails_KeyUp(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				object mReturnValue = null;
				int i = 0;
				if (KeyCode == ((int) Keys.F2))
				{
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001000, "28"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						return;
					}
					int tempForEndVar = grdVoucherDetails.RowCount - 1;
					for (i = 0; i <= tempForEndVar; i++)
					{
						if (grdVoucherDetails.Columns[0].CellText(i + 1).Trim() == ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1)))
						{
							grdVoucherDetails.Bookmark = i + 1;
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.FilterActive was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							grdVoucherDetails.setFilterActive(false);
							break;
						}
					}
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			//If grdVoucherDetails.FilterActive = True Then
			//    grdVoucherDetails.HighlightRowStyle.BackColor = RGB(255, 255, 255)
			//Else
			//    grdVoucherDetails.HighlightRowStyle.BackColor = &HE3D9DD
			//End If

			try
			{
				ImgItem.Image = null;
				if (grdVoucherDetails.Columns[ConPicture].Text != "")
				{
					ImgItem.Image = Image.FromFile(SystemVariables.gProductPicturesPath + grdVoucherDetails.Columns[ConPicture].Text);
				}
				//LoadPicture("c:\windows\Rhododendron.bmp")
			}
			catch
			{

				ImgItem.Image = null;
			}
		}

		private void ImgItem_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			string mPicturePath = "";
			if (!SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[ConPicture].Text, SystemVariables.DataType.StringType))
			{
				mPicturePath = SystemVariables.gProductPicturesPath + grdVoucherDetails.Columns[ConPicture].Text;
				//Shell "d:\windows\System32\mspaint.exe " & mPicturePath, vbMaximizedFocus
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		public void QRoutine()
		{
			if (!SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[conPartNo].Text, SystemVariables.DataType.StringType))
			{
				repItemQuery.DefInstance.Show();
				//UPGRADE_WARNING: (2065) Form method repItemQuery.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
				repItemQuery.DefInstance.BringToFront();
				repItemQuery.DefInstance.txtPartNo.Text = grdVoucherDetails.Columns[conPartNo].Text;
				repItemQuery.DefInstance.GetProductInfo(grdVoucherDetails.Columns[conPartNo].Text);
			}
		}
	}
}