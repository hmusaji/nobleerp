
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmSysReportFind
		: System.Windows.Forms.Form
	{

		public frmSysReportFind()
{
InitializeComponent();
} 
 public  void frmSysReportFind_old()
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


		private void frmSysReportFind_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private clsReportDefinition oReportDefinitionClass = null;
		private DataSet oDetailsRecordset = null;
		private C1.Win.C1FlexGrid.C1FlexGrid oReportGrid = null;
		private XArrayHelper aReportStandardFind = null;

		private const int tpStandardFilter = 0;
		private const int tpAdvancedFilter = 1;
		private const int mColumnSelect = 0;
		private const int mColumnCaption = 1;
		//Private Const mColumnComments As Integer = 2
		private const int mColumnID = 2;
		private const int mFixedRow = 1;
		private int mLastCol = 0;
		private int mLastRow = 0;

		//Private Const mButtonFindNext As Integer = 0
		//Private Const mButtonCancel As Integer = 1
		//Private Const mButtonHelp As Integer = 2
		//Private Const mButtonSelect As Integer = 3
		//Private Const mButtonUnselect As Integer = 4
		//Private Const mButtonSelectAll As Integer = 5
		//Private Const mButtonSelectNone As Integer = 6
		private const int lcTabInfo = 1;
		private bool mReportStandardFindTabClicked = false;
		private bool mReportAdvancedFindTabClicked = false;
		private const string mFixedHeaderBackColor = "16758639";
		private const string mFixedColumnBackColor = "&HE2F4E1";

		private clsToolbar oThisFormToolBar = null;

		public void AttachObjects(clsReportDefinition pReportClass, DataSet pDetailsRecordset, C1.Win.C1FlexGrid.C1FlexGrid pReportGrid)
		{
			oReportDefinitionClass = pReportClass;
			oDetailsRecordset = pDetailsRecordset;
			oReportGrid = pReportGrid;
		}

		public void SearchWindowSettings(string pSeachText, bool pMatchExact, bool pMatchCase)
		{
			txtSearchString.Text = pSeachText;
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			chkMatchExact.CheckState = (CheckState) ((pMatchExact) ? 1 : 0);
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			chkMatchCase.CheckState = (CheckState) ((pMatchCase) ? 1 : 0);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			oThisFormToolBar = new clsToolbar();

			Control ObjCaption = null;
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic)
			{
				//UPGRADE_WARNING: (2065) Form property frmSysReportFind.Controls has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
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

			oThisFormToolBar.ShowFindButton = true;
			oThisFormToolBar.BeginCheckAllButtonWithGroup = true;
			oThisFormToolBar.ShowUncheckAllButton = true;
			oThisFormToolBar.ShowCheckAllButton = true;
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.DisableHelpButton = true;
			oThisFormToolBar.DefineToolBar();


			//define the report find grid
			SystemGrid.DefineSystemVoucherGrid(grdReportFind, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.6f, 1.4f, mFixedHeaderBackColor, "&HB69D8D", 280);
			//tabReportOptions.CurrTab = tpStandardFilter
			DefineSearchGrid();

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				oReportDefinitionClass = null;
				oReportGrid = null;
				aReportStandardFind = null;
				frmSysReportFind.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//**--Return or Enter key
				if (KeyCode == ((int) Keys.Return) && this.ActiveControl.Name != "grdReportFind" && this.ActiveControl.Name != "txtSearchString")
				{
					SendKeys.Send("{TAB}");
					return;
				}
				else if (KeyCode == 27)
				{ 
					CloseForm();
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		//Private Sub tabReportOptions_Click()
		//Dim colReportOptions  As TrueOleDBGrid80.Column
		//Dim mTotalRequiredColumns As Integer
		//Dim TempCnt As Integer
		//Dim TempCnt2 As Integer
		//
		//'**--disable object repainting
		//SendMessageLong grdReportFind.hWnd, WM_SETREDRAW, False, &O0
		//
		//'**--create no. of report option columns
		//Select Case tabReportOptions.CurrTab
		//    Case tpStandardFilter
		//        mTotalRequiredColumns = 1
		//    Case tpAdvancedFilter
		//        mTotalRequiredColumns = 0
		//End Select
		//
		//grdReportFind.Columns.Clear
		//DoEvents
		//
		//'**--setting column's common properties
		//With grdReportFind
		//    For TempCnt = 0 To mTotalRequiredColumns
		//        Set colReportOptions = .Columns.Add(TempCnt)
		//        With colReportOptions
		//            .AllowSizing = False
		//            .DividerStyle = dbgBlackLine
		//            .Style.VerticalAlignment = dbgVertCenter
		//            .Visible = True
		//        End With
		//    Next
		//End With
		//
		//'btnReportOptions(mButtonSelectAll).Visible = False
		//'btnReportOptions(mButtonSelectNone).Visible = False
		//'btnReportOptions(mButtonSelect).Visible = False
		//'btnReportOptions(mButtonUnselect).Visible = False
		//'cntButtons(1).Visible = False
		//
		//If tabReportOptions.CurrTab = tpStandardFilter Then
		//'    btnReportOptions(mButtonSelectAll).Visible = True
		//'    btnReportOptions(mButtonSelectNone).Visible = True
		//'    btnReportOptions(mButtonSelect).Visible = True
		//'    btnReportOptions(mButtonUnselect).Visible = True
		//'    cntButtons(1).Visible = True
		//
		//    With lblCommon(lcTabInfo)
		//        .Caption = "Search in Columns :"
		//        .left = 150
		//        .top = 1320
		//    End With
		//
		//    With grdReportFind
		//        .left = 120
		//        .Height = 2080
		//        .top = 1570
		//        .Width = 6800
		//        .MarqueeStyle = dbgSolidCellBorder
		//
		//        '**--format grid columns and its properties
		//        With .Columns(mColumnSelect)
		//            .Alignment = dbgCenter
		//            .AllowFocus = True
		//            .Caption = "Include"
		//            .FetchStyle = dbgFetchCellStyleColumn
		//            .Width = 700
		//        End With
		//
		//        With .Columns(mColumnCaption)
		//            .AllowFocus = False
		//            .BackColor = mFixedColumnBackColor
		//            .Caption = "Column Name"
		//            .Width = 2700
		//        End With
		//
		//'        With .Columns(mColumnComments)
		//'            .AllowFocus = False
		//'            .BackColor = mFixedColumnBackColor
		//'            .Caption = "Remarks"
		//'            .Width = 2000
		//'        End With
		//    End With
		//
		//    If mReportStandardFindTabClicked = False Then
		//'        Set btnReportOptions(mButtonSelectAll).Picture = frmSysMain.imlSystemIcons.ListImages.Item("imgSelectAll2").Picture
		//'        Set btnReportOptions(mButtonSelectNone).Picture = frmSysMain.imlSystemIcons.ListImages.Item("imgSelectNone2").Picture
		//'        Set btnReportOptions(mButtonSelect).Picture = frmSysMain.imlSystemIcons.ListImages.Item("imgMoveUp").Picture
		//'        Set btnReportOptions(mButtonUnselect).Picture = frmSysMain.imlSystemIcons.ListImages.Item("imgMoveDown").Picture
		//'
		//        Set aReportStandardFind = New XArrayDB
		//        TempCnt2 = 0
		//        With oReportGrid
		//            For TempCnt = .FixedCols To .cols - 1
		//                If .ColHidden(TempCnt) = False Then
		//                    aReportStandardFind.ReDim 0, TempCnt2, 0, 2
		//
		//                    aReportStandardFind(TempCnt2, mColumnSelect) = GetColumnInformation("column_id = " & Mid(.ColData(TempCnt), 2), "include_in_search", oDetailsRecordset)
		//                    aReportStandardFind(TempCnt2, mColumnCaption) = .TextMatrix(mFixedRow, TempCnt)
		//                    'aReportStandardFind(TempCnt2, mColumnComments) = GetColumnInformation("column_id = " & Mid(.ColData(TempCnt), 2), "comments", oDetailsRecordset)
		//                    aReportStandardFind(TempCnt2, mColumnID) = Mid(.ColData(TempCnt), 2)
		//                    TempCnt2 = TempCnt2 + 1
		//                End If
		//            Next
		//        End With
		//        mReportStandardFindTabClicked = True
		//    End If
		//    grdReportFind.Array = aReportStandardFind
		//    grdReportFind.ReBind
		//Else
		//'do advance search
		//End If
		//SendMessageLong grdReportFind.hWnd, WM_SETREDRAW, True, &O0
		//grdReportFind.Bookmark = 0
		//grdReportFind.Refresh
		//fraReportOptions.Refresh
		//
		//On Error Resume Next
		//grdReportFind.SetFocus
		//End Sub

		private void grdReportFind_BeforeColEdit(object eventSender, C1.Win.C1TrueDBGrid.BeforeColEditEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int KeyAscii = (int) eventArgs.KeyChar;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{

				if (ColIndex == mColumnSelect)
				{
					if (KeyAscii == 0 || KeyAscii == 13 || KeyAscii == 32)
					{
						aReportStandardFind.SetValue(~Convert.ToInt32(aReportStandardFind.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdReportFind.Bookmark), ColIndex)), ReflectionHelper.GetPrimitiveValue<int>(grdReportFind.Bookmark), ColIndex);
						grdReportFind.UpdateData();
						grdReportFind.Refresh();
					}
					Cancel = -1;
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdReportFind.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdReportFind_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			if (Col == mColumnSelect)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(aReportStandardFind.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), Col))) == TriState.True)
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

		private void grdReportFind_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float x = eventArgs.X * 15;
			float y = eventArgs.Y * 15;
			if (grdReportFind.PointAt(x, y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
			{
				mLastCol = grdReportFind.Col;
				mLastRow = grdReportFind.Row;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdReportFind.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdReportFind.PostMsg(1);
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdReportFind.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdReportFind_PostEvent(int MsgId)
		{

			if (mLastCol == grdReportFind.Col && mLastRow == grdReportFind.Row)
			{
				return;
			}

			int Col = grdReportFind.Col;
			if (Col == mColumnSelect)
			{
				grdReportFind.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdReportFind.Columns[Col].Value);
				grdReportFind.UpdateData();
				grdReportFind.Refresh();
			}

		}

		private void grdReportFind_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				int Col = grdReportFind.Col;

				if (Col == mColumnSelect)
				{
					if (KeyAscii == 32)
					{
						KeyAscii = 0;
						grdReportFind.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdReportFind.Columns[Col].Value);
						grdReportFind.UpdateData();
						grdReportFind.Refresh();
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

		private void txtSearchString_KeyDown(Object Sender, System.Windows.Forms.TextBox.KeyDownEventArgs e)
		{
			Keys KeyCode = (Keys) e.KeyCode;
			int Shift = e.Shift;
			if (KeyCode == Keys.Return)
			{
				findRecord();
			}
		}

		public void findRecord()
		{
			UpdateReportSearchSettings();
			if (!oReportDefinitionClass.SeekReportRow())
			{
				MessageBox.Show("No Match Found", "Find Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				this.Hide();
			}
			return;
		}
		public void KRoutine()
		{
			DoColumnSelect(2);
			grdReportFind.Refresh();
			grdReportFind.Focus();
		}
		public void URoutine()
		{
			DoColumnSelect(3);
			grdReportFind.Refresh();
			grdReportFind.Focus();
		}
		public void CloseForm()
		{
			this.Hide();
		}
		//Private Sub btnReportOptions_Click(Index As Integer)
		//Dim mCurrentRow As Long
		//Dim aTempValue As Variant
		//Dim ColCnt As Long
		//
		//Select Case Index
		//    Case mButtonSelect
		//        Call DoColumnSelect(0, Val(grdReportFind.Bookmark))
		//    Case mButtonUnselect
		//        Call DoColumnSelect(1, Val(grdReportFind.Bookmark))
		//    Case mButtonSelectAll
		//        Call DoColumnSelect(2)
		//    Case mButtonSelectNone
		//        Call DoColumnSelect(3)
		//    Case mButtonCancel
		//        Me.Hide
		//        Exit Sub
		//    Case mButtonHelp
		//    Case mButtonFindNext
		//        Call UpdateReportSearchSettings
		//        If oReportDefinitionClass.SeekReportRow() = False Then
		//            MsgBox "No Match Found", vbInformation, "Find Record"
		//        Else
		//            Me.Hide
		//        End If
		//        Exit Sub
		//End Select
		//grdReportFind.Refresh
		//grdReportFind.SetFocus
		//End Sub

		private void DoColumnSelect(int pSelectOptions = 0, int pCurrentRow = 0)
		{
			int RowCnt = 0;

			if (pSelectOptions == 0)
			{
				aReportStandardFind.SetValue(TriState.True, pCurrentRow, mColumnSelect);
			}
			else if (pSelectOptions == 1)
			{ 
				aReportStandardFind.SetValue(TriState.False, pCurrentRow, mColumnSelect);
			}
			else
			{
				int tempForEndVar = aReportStandardFind.GetLength(0) - 1;
				for (RowCnt = 0; RowCnt <= tempForEndVar; RowCnt++)
				{
					if (pSelectOptions == 2)
					{ //if show all button is pressed
						aReportStandardFind.SetValue(TriState.True, RowCnt, mColumnSelect);
					}
					else
					{
						//if show none button is pressed
						aReportStandardFind.SetValue(TriState.False, RowCnt, mColumnSelect);
					}
				}
			}
		}

		private void UpdateReportSearchSettings()
		{
			int ColCnt = 0;

			int RowCnt = 0;
			int tempForEndVar = oReportGrid.Cols.Count - 1;
			for (ColCnt = oReportGrid.Cols.Fixed; ColCnt <= tempForEndVar; ColCnt++)
			{
				if (oReportGrid.Cols[ColCnt].Visible)
				{
					oReportDefinitionClass.SetColumnInformation("column_id = " + ReflectionHelper.GetPrimitiveValue<string>(oReportGrid.Cols[ColCnt].UserData).Substring(1), "include_in_search", Convert.ToString(aReportStandardFind.GetValue(RowCnt, mColumnSelect)), "alias_id = " + oReportDefinitionClass.GetReportInformation("alias_id"));
					RowCnt++;
				}
			}
			oReportDefinitionClass.SetReportSearchSetting(txtSearchString.Text, chkMatchExact.CheckState != CheckState.Unchecked, chkMatchCase.CheckState != CheckState.Unchecked, optSearchFromPosition[0].Checked);
		}

		private void DefineSearchGrid()
		{
			C1.Win.C1TrueDBGrid.C1DisplayColumn colReportOptions = null;
			int TempCnt = 0;
			int TempCnt2 = 0;

			//**--disable object repainting
			InnovaUpdSupport.PInvoke.SafeNative.user32.SendMessageLong(grdReportFind.Handle.ToInt32(), SystemAPI.WM_SETREDRAW, 0, 0);

			int mTotalRequiredColumns = 1;

			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Columns method grdReportFind.Columns.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdReportFind.Columns.Clear();
			Application.DoEvents();

			//**--setting column's common properties
			int tempForEndVar = mTotalRequiredColumns;
			for (TempCnt = 0; TempCnt <= tempForEndVar; TempCnt++)
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				C1.Win.C1TrueDBGrid.C1DataColumn tempColumn = new C1.Win.C1TrueDBGrid.C1DataColumn();
				grdReportFind.Columns.Insert(TempCnt, tempColumn);
				colReportOptions = grdReportFind.Splits[0].DisplayColumns[tempColumn];
				colReportOptions.AllowSizing = false;
				colReportOptions.ColumnDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single;
				colReportOptions.Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center;
				colReportOptions.Visible = true;
			}

			//    With lblCommon(lcTabInfo)
			//        .Caption = "Search in Columns :"
			//
			//    End With

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			grdReportFind.Left = 8;
			grdReportFind.Height = 139;
			//.top = 2250
			grdReportFind.Width = 320;
			grdReportFind.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder;

			//**--format grid columns and its properties
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			withVar = grdReportFind.Splits[0].DisplayColumns[mColumnSelect];
			withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
			withVar.AllowFocus = true;
			withVar.DataColumn.Caption = "Include";
			withVar.FetchStyle = TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleColumn != TrueOleDBGrid80.FetchCellStyleConstants.dbgFetchCellStyleNone;
			withVar.Width = 47;

			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			withVar_2 = grdReportFind.Splits[0].DisplayColumns[mColumnCaption];
			withVar_2.AllowFocus = false;
			withVar_2.Style.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(mFixedColumnBackColor)));
			withVar_2.DataColumn.Caption = "Column Name";
			withVar_2.Width = 180;

			//        With .Columns(mColumnComments)
			//            .AllowFocus = False
			//            .BackColor = mFixedColumnBackColor
			//            .Caption = "Remarks"
			//            .Width = 2000
			//        End With

			if (!mReportStandardFindTabClicked)
			{
				//        Set btnReportOptions(mButtonSelectAll).Picture = frmSysMain.imlSystemIcons.ListImages.Item("imgSelectAll2").Picture
				//        Set btnReportOptions(mButtonSelectNone).Picture = frmSysMain.imlSystemIcons.ListImages.Item("imgSelectNone2").Picture
				//        Set btnReportOptions(mButtonSelect).Picture = frmSysMain.imlSystemIcons.ListImages.Item("imgMoveUp").Picture
				//        Set btnReportOptions(mButtonUnselect).Picture = frmSysMain.imlSystemIcons.ListImages.Item("imgMoveDown").Picture
				//
				aReportStandardFind = new XArrayHelper();
				TempCnt2 = 0;
				if (oReportGrid != null)
				{
					int tempForEndVar2 = oReportGrid.Cols.Count - 1;
					for (TempCnt = oReportGrid.Cols.Fixed; TempCnt <= tempForEndVar2; TempCnt++)
					{
						if (oReportGrid.Cols[TempCnt].Visible)
						{
							aReportStandardFind.RedimXArray(new int[]{TempCnt2, 2}, new int[]{0, 0});

							aReportStandardFind.SetValue(SystemReports.GetColumnInformation("column_id = " + ReflectionHelper.GetPrimitiveValue<string>(oReportGrid.Cols[TempCnt].UserData).Substring(1), "include_in_search", oDetailsRecordset), TempCnt2, mColumnSelect);
							aReportStandardFind.SetValue(Convert.ToString(oReportGrid[mFixedRow, TempCnt]), TempCnt2, mColumnCaption);
							//aReportStandardFind(TempCnt2, mColumnComments) = GetColumnInformation("column_id = " & Mid(.ColData(TempCnt), 2), "comments", oDetailsRecordset)
							aReportStandardFind.SetValue(ReflectionHelper.GetPrimitiveValue<string>(oReportGrid.Cols[TempCnt].UserData).Substring(1), TempCnt2, mColumnID);
							TempCnt2++;
						}
					}
				}
				mReportStandardFindTabClicked = true;
			}
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdReportFind.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdReportFind.setArray(aReportStandardFind);
			grdReportFind.Rebind(true);

			InnovaUpdSupport.PInvoke.SafeNative.user32.SendMessageLong(grdReportFind.Handle.ToInt32(), SystemAPI.WM_SETREDRAW, -1, 0);
			grdReportFind.Bookmark = 0;
			grdReportFind.Refresh();

			try
			{
				grdReportFind.Focus();
			}
			catch
			{
			}
		}
	}
}