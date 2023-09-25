
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers;



namespace Xtreme
{
	internal partial class frmGLChartOfAccount
		: System.Windows.Forms.Form
	{

		public frmGLChartOfAccount()
{
InitializeComponent();
} 
 public  void frmGLChartOfAccount_old()
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
			this.fg.setScrollTips(false);
		}


		private void frmGLChartOfAccount_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private int mThisFormID = 0;
		private object mSearchValue = null;
		private bool mIsFormOpen = false;
		private string mTimeStamp = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0; //Enum for checking the current form mode
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
		 //This class checks for the rights given to the user
		private clsToolbar oThisFormToolBar = null;
		public Control FirstFocusObject = null;

		private const int conParentGroupCd1 = 0;
		private const int conParentGroupCd2 = 1;
		private const int conParentGroupCd3 = 2;
		private const int conParentGroupCd4 = 3;
		private const int conParentGroupCd5 = 4;
		private const int conParentGroupCd6 = 5;
		private const int conParentGroupCd7 = 6;
		private const int conAccountCd = 7;
		private const int conParentAccountCd = 8;
		private const int conAccountNature = 9;
		private const int conAccountLevel = 10;
		private const int conAccountNo = 11;
		private const int conAccountName = 12;
		private const int conTypeCd = 13;

		private const bool mDraggingAllowed = true;
		private const int mMaxCols = 14;

		// to handle node dragging
		private const int DRAGTOL = 200; // mouse movement before dragging starts
		[Serializable]
		private struct DRAGINFO
		{
			public bool bDragging; // currently dragging
			public bool bCheckDrag; // currently checking mouse to start dragging
			public int lSrc; // row being dragged
			public int xDown; // mouse down position
			public int yDown; // mouse down position
		}
		private DRAGINFO mFGDragInfo = new DRAGINFO();

		private const int mnuInsertAccountGroup = 0;
		private const int mnuInsertLedgerMaster = 1;
		private const int mnuSeperator1 = 2;
		private const int mnuEdit = 3;
		private const int mnuCancel = 4;

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis#2041
		//[DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int LockWindowUpdate(int hWnd);

		private bool m_booKeyCtrl = false;
		private bool m_booKeyShift = false;
		private bool m_booProcessSelected = false;


		public bool IsFormOpen
		{
			get
			{
				return mIsFormOpen;
			}
			set
			{
				mIsFormOpen = value;
			}
		}



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



		public object SearchValue
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





		private void fg_KeyUp(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{

				m_booKeyCtrl = false;
				m_booKeyShift = false;
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
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

					if (KeyCode == 13)
					{ //If enter key pressed send a tab key
						SendKeys.Send("{TAB}");
						return;
					}

					if (KeyCode == 116)
					{ //F5
						FillGrid(Convert.ToInt32(Conversion.Val(Convert.ToString(fg[fg.Row, conAccountCd]))), Convert.ToString(fg[fg.Row, conAccountNature]));
					}

					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
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

		public void CloseForm()
		{
			this.Close();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			//Me.Height = 7830
			this.Top = 0;
			this.Left = 0;

			this.IsFormOpen = true;

			//**--format & define the new toolbar
			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			oThisFormToolBar.ShowNewButton = false;
			oThisFormToolBar.ShowSaveButton = false;
			oThisFormToolBar.ShowDeleteButton = false;
			oThisFormToolBar.ShowPrintButton = true;
			oThisFormToolBar.ShowFindButton = true;
			oThisFormToolBar.ShowHelpButton = true;
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.DisableHelpButton = true;
			oThisFormToolBar.ShowCollapseAllButton = true;
			oThisFormToolBar.ShowExpandAllButton = true;
			this.WindowState = FormWindowState.Maximized;

			fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			fg.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
			fg.AutoSearchDelay = 5;
			fg.Styles.EmptyArea.BackColor = fg.BackColor;
			fg.AllowEditing = false;
			fg.Styles.Normal.Trimming = StringTrimming.EllipsisPath;
			fg.ExtendLastCol = true;
			fg.Cols.Fixed = 0;
			fg.Styles.Normal.Border.Color = Color.FromArgb(0, 0, 0);
			fg.Styles.Fixed.Border.Color = Color.FromArgb(0, 0, 0);
			fg.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
			fg.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			fg.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic)
			{
				fg.RightToLeft = RightToLeft.Yes;
			}
			fg.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf;
			fg.setRedraw(UpgradeHelpers.VSFlexGridExtensions.RedrawSettings.flexRDBuffered); // << new setting
			fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy;
			fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid property fg.ScrollTrack was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			fg.setScrollTrack(true);
			fg.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = fg.BackColor;

			fg.Cols.Count = mMaxCols;
			fg.Cols[conParentGroupCd1].Visible = false;
			fg.Cols[conParentGroupCd2].Visible = false;
			fg.Cols[conParentGroupCd3].Visible = false;
			fg.Cols[conParentGroupCd4].Visible = false;
			fg.Cols[conParentGroupCd5].Visible = false;
			fg.Cols[conParentGroupCd6].Visible = false;
			fg.Cols[conParentGroupCd7].Visible = false;
			fg.Cols[conAccountCd].Visible = false;
			fg.Cols[conParentAccountCd].Visible = false;

			fg.Cols[conAccountNature].Visible = false;
			fg.Cols[conAccountLevel].Visible = false;
			fg.Cols[conTypeCd].Visible = false;

			fg.Cols[conAccountNo].WidthDisplay = 200;

			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				fg.Cols[conAccountNo].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter;
			}
			else
			{
				fg.Cols[conAccountNo].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter;
			}

			fg.Cols[conAccountName].WidthDisplay = 200;

			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				fg.Cols[conAccountName].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter;
			}
			else
			{
				fg.Cols[conAccountName].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter;
			}

			//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid property fg.FontSize was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			fg.setFontSize(10);

			fg.Tree.Column = conAccountNo;

			fg.Rows[0].HeightDisplay = 23;
			fg.setCellFontBold(true, 0, conAccountNo, 0, conAccountName);

			fg[0, conAccountNo] = "Account No.";
			fg[0, conAccountName] = "Account Name";


			FillGrid();

		}

		public void FillGrid(int pBookmark = 0, string pNature = "L")
		{

			int mLevel = 0;
			int mRow = 0;

			clsHourGlass myHourGlass = new clsHourGlass();

			string mysql = " SELECT   ";
			mysql = mysql + " ag.reporting_sequence_id_1 ";
			mysql = mysql + " , ag.reporting_sequence_id_2 ";
			mysql = mysql + " , ag.reporting_sequence_id_3 ";
			mysql = mysql + " , ag.reporting_sequence_id_4 ";
			mysql = mysql + " , ag.reporting_sequence_id_5 ";
			mysql = mysql + " , ag.reporting_sequence_id_6 ";
			mysql = mysql + " , ag.reporting_sequence_id_7 ";
			mysql = mysql + " , ag.group_cd as account_cd ";
			mysql = mysql + " , ag.m_group_cd as parent_account_cd ";
			mysql = mysql + " , 'G' as accnt_nature ";
			mysql = mysql + " , ag.group_level as group_level ";
			mysql = mysql + " , ag.group_no as account_no ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , ag.l_group_name ";
			}
			else
			{
				mysql = mysql + " , ag.a_group_name ";
			}
			mysql = mysql + "  AS account_name, ag_type_cd as type_cd ";
			mysql = mysql + " from gl_accnt_group ag ";
			mysql = mysql + " Union All ";
			mysql = mysql + " SELECT   ";
			mysql = mysql + " ag.reporting_sequence_id_1 ";
			mysql = mysql + " , ag.reporting_sequence_id_2 ";
			mysql = mysql + " , ag.reporting_sequence_id_3 ";
			mysql = mysql + " , ag.reporting_sequence_id_4 ";
			mysql = mysql + " , ag.reporting_sequence_id_5 ";
			mysql = mysql + " , ag.reporting_sequence_id_6 ";
			mysql = mysql + " , ag.reporting_sequence_id_7 ";
			mysql = mysql + " , l.ldgr_cd as account_cd ";
			mysql = mysql + " , l.group_cd as parent_account_cd ";
			mysql = mysql + " , 'L' as accnt_nature ";
			mysql = mysql + " , (ag.group_level + 1) as group_level ";
			mysql = mysql + " , l.ldgr_no as account_no ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , l.l_ldgr_name ";
			}
			else
			{
				mysql = mysql + " , l.a_ldgr_name ";
			}
			mysql = mysql + "  AS account_name, type_cd as type_cd ";
			mysql = mysql + " from gl_accnt_group ag ";
			mysql = mysql + " inner join gl_ledger l on ag.group_cd = l.group_cd ";
			mysql = mysql + " order by ag.reporting_sequence_id_1 , ag.reporting_sequence_id_2 ";
			mysql = mysql + " , ag.reporting_sequence_id_3 , ag.reporting_sequence_id_4 ";
			mysql = mysql + " , ag.reporting_sequence_id_5 , ag.reporting_sequence_id_6 ";
			mysql = mysql + " , ag.reporting_sequence_id_7 , account_no ";

			DataSet rsTempRec = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsTempRec.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsTempRec.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsTempRec.Tables.Clear();
			adap.Fill(rsTempRec);

			fg.Rows.Count = 1;

			mRow = 1;
			foreach (DataRow iteration_row in rsTempRec.Tables[0].Rows)
			{

				//        .AddItem rsTempRec("parent_group_cd_1") & vbTab & rsTempRec("parent_group_cd_2") & vbTab _
				//'                & rsTempRec("parent_group_cd_3") & vbTab & rsTempRec("parent_group_cd_4") & vbTab _
				//'                & rsTempRec("parent_group_cd_5") & vbTab & rsTempRec("parent_group_cd_6") & vbTab _
				//'                & rsTempRec("parent_group_cd_7") & vbTab & rsTempRec("account_cd") & vbTab _
				//'                & rsTempRec("parent_account_cd") & vbTab _
				//'                & rsTempRec("accnt_nature") & vbTab & rsTempRec("group_level") & vbTab _
				//'                & rsTempRec("account_no") & vbTab & rsTempRec("l_account_name")

				fg.AddItem(Convert.ToString(iteration_row["reporting_sequence_id_1"]) + "\t" + Convert.ToString(iteration_row["reporting_sequence_id_2"]) + "\t" + Convert.ToString(iteration_row["reporting_sequence_id_3"]) + "\t" + Convert.ToString(iteration_row["reporting_sequence_id_4"]) + "\t" + Convert.ToString(iteration_row["reporting_sequence_id_5"]) + "\t" + Convert.ToString(iteration_row["reporting_sequence_id_6"]) + "\t" + Convert.ToString(iteration_row["reporting_sequence_id_7"]) + "\t" + Convert.ToString(iteration_row["account_cd"]) + "\t" + Convert.ToString(iteration_row["parent_account_cd"]) + "\t" + Convert.ToString(iteration_row["accnt_nature"]) + "\t" + Convert.ToString(iteration_row["group_level"]) + "\t" + Convert.ToString(iteration_row["account_no"]) + "\t" + Convert.ToString(iteration_row["account_name"]) + "\t" + Convert.ToString(iteration_row["type_cd"]));


				//UPGRADE_WARNING: (1068) fg.Cell() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mLevel = ReflectionHelper.GetPrimitiveValue<int>(fg.getCellValue(mRow, conAccountLevel));
				fg.Rows[mRow].Node.Level = fg.getCellValue(mRow, conAccountLevel);
				fg.Rows[mRow].IsNode = true;

				if (Convert.ToString(iteration_row["accnt_nature"]) == "G")
				{
					fg.setCellPicture(imgFolder.Image, mRow, conAccountNo);
					fg.setCellBackColor(Color.Silver, mRow, 0, mRow, fg.Cols.Count - 1);
				}
				else
				{
					fg.setCellPicture(ImgOpenFolder.Image, mRow, conAccountNo);
					fg.setCellBackColor(Color.White, mRow);
				}

				fg.Rows[mRow].HeightDisplay = 20;
				mRow++;

			}

			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				fg.setCellPictureAlignment(C1.Win.C1FlexGrid.ImageAlignEnum.LeftCenter, 0, conAccountNo, fg.Rows.Count - 1, conAccountNo);
			}
			else
			{
				fg.setCellPictureAlignment(C1.Win.C1FlexGrid.ImageAlignEnum.RightCenter, 0, conAccountNo, fg.Rows.Count - 1, conAccountNo);
				//UPGRADE_ISSUE: (2064) VSFlex8L.CellPropertySettings property CellPropertySettings.flexcpFontName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid property fg.Cell was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				fg.Cell[UpgradeStubs.VSFlex8L_CellPropertySettings.getflexcpFontName(), 0, conAccountName, fg.Rows.Count - 1, conAccountName] = SystemConstants.gArabicFontName;
				fg.setCellFontSize(10, 0, conAccountName, fg.Rows.Count - 1, conAccountName);
			}

			rsTempRec = null;

			if (pBookmark > 0)
			{
				SetDefaultRowInGrid(pBookmark.ToString(), 1, pNature, 7);
			}

		}


		private void fg_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//UPGRADE_ISSUE: (2068) VSFlex8L.VSFlexNode object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
				UpgradeStubs.VSFlex8L_VSFlexNode mCurrentNode = null;


				if (Shift == 1)
				{
					m_booKeyShift = true;
				}
				if (Shift == 2)
				{
					m_booKeyCtrl = true;
				}

				// use keypboard to expand/collapse nodes and to cancel dragging
				if (KeyCode == ((int) Keys.Left) || KeyCode == ((int) Keys.Right))
				{

					// do we have a node with children?
					//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid method fg.GetNode was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2068) VSFlex8L.IVSFlexNode object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
					//UPGRADE_ISSUE: (2068) VSFlex8L.VSFlexNode object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
					mCurrentNode = (UpgradeStubs.VSFlex8L_VSFlexNode) fg.GetNode(null);

					if (mCurrentNode == null)
					{
						return;
					}

					//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mCurrentNode.Children was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					if (mCurrentNode.getChildren() == 0)
					{
						return;
					}

					// we do, so expand or collapse it
					//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mCurrentNode.Expanded was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					mCurrentNode.setExpanded(KeyCode == ((int) Keys.Right));
					KeyCode = 0;

					// cancel dragging
				}
				else if (KeyCode == ((int) Keys.Escape))
				{ 
					if (mFGDragInfo.bDragging)
					{
						mFGDragInfo.bDragging = false;
						fg.Cursor = Cursors.Default;
						//UPGRADE_ISSUE: (2064) VSFlex8L.CellPropertySettings property CellPropertySettings.flexcpCustomFormat was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid property fg.Cell was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						fg.Cell[UpgradeStubs.VSFlex8L_CellPropertySettings.getflexcpCustomFormat(), mFGDragInfo.lSrc, 0, null, null] = false;
						KeyCode = 0;
					}
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void fg_MouseDown(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float x = eventArgs.X * 15;
			float y = eventArgs.Y * 15;

			// left button, no shift: start tracking mouse to drag
			if ((Button == 1) && (Shift == 0))
			{
				if ((mDraggingAllowed) && (!mFGDragInfo.bDragging))
				{

					// save current row and mouse position
					mFGDragInfo.lSrc = fg.Row;
					mFGDragInfo.xDown = Convert.ToInt32(x);
					mFGDragInfo.yDown = Convert.ToInt32(y);

					// start checking
					mFGDragInfo.bCheckDrag = true;
				}
			}
		}

		//UPGRADE_ISSUE: (2068) VSFlex8L.VSFlexNode object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
		private bool NoDropHere(UpgradeStubs.VSFlex8L_VSFlexNode pSourceNode = null, UpgradeStubs.VSFlex8L_VSFlexNode pTargetNode = null)
		{
			bool result = false;
			if (fg.MouseRow < fg.Rows.Fixed || fg.MouseCol < fg.Cols.Fixed || Convert.ToString(fg[fg.Row, conAccountNature]) == "L")
			{

				result = true;
			}

			//UPGRADE_ISSUE: (2068) Nothing object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
			if (!(pSourceNode is UpgradeStubs.Nothing) && !(pTargetNode is UpgradeStubs.Nothing))
			{
				//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property pTargetNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property pSourceNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (String.CompareOrdinal(Convert.ToString(fg[pSourceNode.getRow(), conAccountLevel]), Convert.ToString(fg[pTargetNode.getRow(), conAccountLevel])) < 0)
				{
					//''
					result = true;
				}
				else if (Conversion.Val(Convert.ToString(fg[pSourceNode.getRow(), conParentAccountCd])) == Conversion.Val(Convert.ToString(fg[pTargetNode.getRow(), conAccountCd])))
				{ 
					//'parent is same as before
					result = true;
				}
				else if (Conversion.Val(Convert.ToString(fg[pSourceNode.getRow(), conAccountCd])) == Conversion.Val(Convert.ToString(fg[pTargetNode.getRow(), conAccountCd])))
				{ 
					//''same account code
					result = true;
				}
			}
			return result;
		}

		private void fg_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float x = eventArgs.X * 15;
			float y = eventArgs.Y * 15;
			//UPGRADE_ISSUE: (2068) VSFlex8L.VSFlexNode object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
			UpgradeStubs.VSFlex8L_VSFlexNode mSourceNode = null;
			//UPGRADE_ISSUE: (2068) VSFlex8L.VSFlexNode object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
			UpgradeStubs.VSFlex8L_VSFlexNode mTargetNode = null;
			VSPrinter8Lib.MousePointerSettings mp = VSPrinter8Lib.MousePointerSettings.mpDefault;

			// if checking and the user moved past our tolerance, start dragging
			if (mFGDragInfo.bCheckDrag && Button == 1)
			{
				if (Math.Abs(x - mFGDragInfo.xDown) + Math.Abs(y - mFGDragInfo.yDown) > DRAGTOL)
				{

					// update flags
					mFGDragInfo.bDragging = true;
					mFGDragInfo.bCheckDrag = false;

					// set cursor and highlight node
					//UPGRADE_WARNING: (2065) VSFlex8L.MousePointerSettings property MousePointerSettings.flexPointerMove has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
					fg.Cursor = Windows.Cursors.Default;
					fg.setCellBackColor(Color.Yellow, mFGDragInfo.lSrc, 0);
				}
			}

			// check whether we can drop here
			if (mFGDragInfo.bDragging)
			{
				mp = VSPrinter8Lib.MousePointerSettings.mpHandDrag;

				//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid method fg.GetNode was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2068) VSFlex8L.IVSFlexNode object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
				//UPGRADE_ISSUE: (2068) VSFlex8L.VSFlexNode object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
				mSourceNode = (UpgradeStubs.VSFlex8L_VSFlexNode) fg.GetNode(mFGDragInfo.lSrc);
				//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid method fg.GetNode was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2068) VSFlex8L.IVSFlexNode object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
				//UPGRADE_ISSUE: (2068) VSFlex8L.VSFlexNode object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
				mTargetNode = (UpgradeStubs.VSFlex8L_VSFlexNode) fg.GetNode(null);

				if (NoDropHere(mSourceNode, mTargetNode))
				{
					mp = VSPrinter8Lib.MousePointerSettings.mpNoDrop;
				}

				if (mp != fg.Cursor)
				{
					//UPGRADE_WARNING: (6021) Casting 'VSPrinter8Lib.MousePointerSettings' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					fg.Cursor = (Cursor) mp;
				}
			}

		}

		private void fg_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float x = eventArgs.X * 15;
			float y = eventArgs.Y * 15;
			//UPGRADE_ISSUE: (2068) VSFlex8L.VSFlexNode object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
			UpgradeStubs.VSFlex8L_VSFlexNode mSourceNode = null;
			//UPGRADE_ISSUE: (2068) VSFlex8L.VSFlexNode object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
			UpgradeStubs.VSFlex8L_VSFlexNode mTargetNode = null;
			string mysql = "";

			int mRowFocus = 0;
			string mSearchValue = "";


			if (Button == 2 && fg.Row > 0)
			{
				fg.Row = fg.MouseRow;
				Ctx_~virtual_@ControlArray_Item.Show(this, (int) (x / 15), (int) (y / 15));
			}

			// if we were dragging, then do it
			if (mFGDragInfo.bDragging)
			{
				// stop dragging
				//UPGRADE_ISSUE: (2064) VSFlex8L.CellPropertySettings property CellPropertySettings.flexcpCustomFormat was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid property fg.Cell was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				fg.Cell[UpgradeStubs.VSFlex8L_CellPropertySettings.getflexcpCustomFormat(), mFGDragInfo.lSrc, 0, null, null] = false;
				mFGDragInfo.bDragging = false;
				fg.Cursor = Cursors.Default;


				// move node into new parent node
				//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid method fg.GetNode was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2068) VSFlex8L.IVSFlexNode object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
				//UPGRADE_ISSUE: (2068) VSFlex8L.VSFlexNode object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
				mSourceNode = (UpgradeStubs.VSFlex8L_VSFlexNode) fg.GetNode(mFGDragInfo.lSrc);
				//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid method fg.GetNode was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2068) VSFlex8L.IVSFlexNode object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
				//UPGRADE_ISSUE: (2068) VSFlex8L.VSFlexNode object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
				mTargetNode = (UpgradeStubs.VSFlex8L_VSFlexNode) fg.GetNode(null);

				// test whether the drop is allowed
				if (NoDropHere(mSourceNode, mTargetNode))
				{
					return;
				}

				//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode method mSourceNode.Move was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				mSourceNode.Move_Renamed(VSFlex8L.NodeMoveSettings.flexNMChildOf, mTargetNode);
				//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode method mSourceNode.Select was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				mSourceNode.Select_Renamed();

				//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mSourceNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (Convert.ToString(fg[mSourceNode.getRow(), conAccountNature]) == "G")
				{
					//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mTargetNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mSourceNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					if (Conversion.Val(Convert.ToString(fg[mSourceNode.getRow(), conParentAccountCd])) != Conversion.Val(Convert.ToString(fg[mTargetNode.getRow(), conAccountCd])))
					{

						SystemVariables.gConn.BeginTransaction();

						mysql = " update gl_accnt_group ";
						//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mTargetNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						mysql = mysql + " set m_group_cd =" + Convert.ToString(fg[mTargetNode.getRow(), conAccountCd]);
						//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mSourceNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						mysql = mysql + " where group_cd =" + Convert.ToString(fg[mSourceNode.getRow(), conAccountCd]);
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql;
						TempCommand.ExecuteNonQuery();

						//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mSourceNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						mSearchValue = Convert.ToString(fg[mSourceNode.getRow(), conAccountNo]);

						//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mSourceNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						mysql = "execute glUpdateGroupReportingSequence " + Convert.ToString(fg[mSourceNode.getRow(), conAccountCd]) + ", 0";
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();

						//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mSourceNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						mysql = "execute glUpdateChildGroupReportingSequence " + Convert.ToString(fg[mSourceNode.getRow(), conAccountCd]);
						//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mSourceNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select group_level from gl_accnt_group where group_cd = " + Convert.ToString(fg[mSourceNode.getRow(), conAccountCd])));
						SqlCommand TempCommand_3 = null;
						TempCommand_3 = SystemVariables.gConn.CreateCommand();
						TempCommand_3.CommandText = mysql;
						TempCommand_3.ExecuteNonQuery();

						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.CommitTrans();

						FillGrid();
						SetDefaultRowInGrid(mSearchValue, 1, "G", conAccountNo);
					}
				}
				else if (Convert.ToString(fg[mSourceNode.getRow(), conAccountNature]) == "L")
				{ 
					//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mTargetNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mSourceNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					if (Conversion.Val(Convert.ToString(fg[mSourceNode.getRow(), conParentAccountCd])) != Conversion.Val(Convert.ToString(fg[mTargetNode.getRow(), conAccountCd])))
					{
						SystemVariables.gConn.BeginTransaction();

						mysql = " update gl_ledger ";
						//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mTargetNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						mysql = mysql + " set group_cd =" + Convert.ToString(fg[mTargetNode.getRow(), conAccountCd]);
						//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mSourceNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						mysql = mysql + " where ldgr_cd =" + Convert.ToString(fg[mSourceNode.getRow(), conAccountCd]);
						SqlCommand TempCommand_4 = null;
						TempCommand_4 = SystemVariables.gConn.CreateCommand();
						TempCommand_4.CommandText = mysql;
						TempCommand_4.ExecuteNonQuery();

						//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mSourceNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						mSearchValue = Convert.ToString(fg[mSourceNode.getRow(), conAccountNo]);

						//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexNode property mSourceNode.Row was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						mysql = "execute glUpdateLedgerReportingSequence " + Convert.ToString(fg[mSourceNode.getRow(), conAccountCd]) + ", 0";
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();

						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.CommitTrans();

						FillGrid();
						SetDefaultRowInGrid(mSearchValue, 1, "L", conAccountNo);
					}
				}
			}

		}

		public void findRecord()
		{
			string mNature = "";
			string mAccountNo = "";

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000115));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//mSearchValue = mTempSearchValue(0)
				//Call GetRecord(mSearchValue)
				mNature = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0)).Substring(0, Math.Min(1, ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0)).Length));
				mAccountNo = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0)).Substring(Math.Max(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0)).Length - (Strings.Len(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0))) - 2), 0));
				SetDefaultRowInGrid(mAccountNo, 1, mNature, conAccountNo);
			}

		}

		public void ZRoutine()
		{
			int i = 0;
			int tempForEndVar = fg.Rows.Count - 1;
			for (i = fg.Row; i <= tempForEndVar; i++)
			{
				if (fg.Rows[i].IsNode)
				{
					fg.Rows[i - 1].Node.Collapsed = false;
				}
			}
		}

		public void JRoutine()
		{
			int i = 0;
			int tempForEndVar = fg.Rows.Count - 1;
			for (i = fg.Row; i <= tempForEndVar; i++)
			{
				if (fg.Rows[i].IsNode)
				{
					fg.Rows[i - 1].Node.Collapsed = true;
				}
			}
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			frmGLChartOfAccount.DefInstance = null;
			this.IsFormOpen = false;
		}



		public void mnuChartOfAccount1_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.mnuChartOfAccount1, eventSender);
			object mReturnValue = null;
			string mSQL = "";
			Form oFormName = null;
			int mFormId = 0;

			int mAccountCd = 0;
			string mAccntNature = "";

			switch(Index)
			{
				case mnuInsertAccountGroup : 
					 
					oFormName = frmGLAccountGroups.CreateInstance(); 
					mFormId = 420000; 
					ReflectionHelper.Invoke(ReflectionHelper.GetMember(oFormName, "UserAccess"), "CheckAccess", new object[]{mFormId, SystemVariables.SystemObjectTypes.objForm}); 
					 
					if (!ReflectionHelper.GetMember<bool>(ReflectionHelper.GetMember(oFormName, "UserAccess"), "DeniedAccess"))
					{
						//--else skip the form caption setting part
						if (!((mFormId >= 331000 && mFormId <= 336000) || (mFormId >= 341000 && mFormId <= 347000)))
						{
							oFormName.Text = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_form_name" : "a_form_name") + " from SM_FORM where form_id = " + mFormId.ToString()));
						}
						ReflectionHelper.LetMember(oFormName, "ThisFormId", mFormId);
						if (ReflectionHelper.GetPrimitiveValue<string>(fg.getCellText(fg.Row, conAccountNature)) == "G")
						{
							//UPGRADE_WARNING: (1068) fg.Cell() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(fg.getCellText(fg.Row, conAccountNo));
							//UPGRADE_WARNING: (1068) fg.Cell() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							ReflectionHelper.LetMember(ReflectionHelper.GetMember(oFormName, "txtTypeCode"), "Text", ReflectionHelper.GetPrimitiveValue(fg.getCellText(fg.Row, conTypeCd)));
							ReflectionHelper.Invoke(oFormName, "txtTypeCode_LostFocus", new object[]{});
						}
						else if (ReflectionHelper.GetPrimitiveValue<string>(fg.getCellText(fg.Row, conAccountNature)) == "L")
						{ 
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select group_no from gl_accnt_group where group_cd = " + ((ReflectionHelper.GetPrimitiveValue<string>(fg.getCellText(fg.Row, conParentAccountCd)) == "") ? "0" : ReflectionHelper.GetPrimitiveValue<string>(fg.getCellText(fg.Row, conParentAccountCd)))));
						}
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						ReflectionHelper.LetMember(ReflectionHelper.GetMember(oFormName, "txtParentGroupNo"), "Text", (Convert.IsDBNull(mReturnValue)) ? ((object) "") : mReturnValue);
						ReflectionHelper.Invoke(oFormName, "txtParentGroupNo_LostFocus", new object[]{});
						ReflectionHelper.LetMember(ReflectionHelper.GetMember(oFormName, "txtParentGroupNo"), "Enabled", false);
						ReflectionHelper.LetMember(ReflectionHelper.GetMember(oFormName, "cmdCommon", new object[]{0}), "Value", true);
						ReflectionHelper.LetMember(oFormName, "IsCalledFromCOA", true);
						oFormName.Show();
						//UPGRADE_WARNING: (2065) Form method oFormName.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
						oFormName.BringToFront();
					} 
					break;
				case mnuInsertLedgerMaster : 
					 
					oFormName = frmGLLedger.CreateInstance(); 
					mFormId = 420000; 
					ReflectionHelper.Invoke(ReflectionHelper.GetMember(oFormName, "UserAccess"), "CheckAccess", new object[]{mFormId, SystemVariables.SystemObjectTypes.objForm}); 
					 
					if (!ReflectionHelper.GetMember<bool>(ReflectionHelper.GetMember(oFormName, "UserAccess"), "DeniedAccess"))
					{
						//--else skip the form caption setting part
						if (!((mFormId >= 331000 && mFormId <= 336000) || (mFormId >= 341000 && mFormId <= 347000)))
						{
							oFormName.Text = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_form_name" : "a_form_name") + " from SM_FORM where form_id = " + mFormId.ToString()));
						}
						ReflectionHelper.LetMember(oFormName, "ThisFormId", mFormId);
						if (ReflectionHelper.GetPrimitiveValue<string>(fg.getCellText(fg.Row, conAccountNature)) == "G")
						{
							//UPGRADE_WARNING: (1068) fg.Cell() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(fg.getCellText(fg.Row, conAccountNo));
						}
						else
						{
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select group_no from gl_accnt_group where group_cd = " + ((ReflectionHelper.GetPrimitiveValue<string>(fg.getCellText(fg.Row, conParentAccountCd)) == "") ? "0" : ReflectionHelper.GetPrimitiveValue<string>(fg.getCellText(fg.Row, conParentAccountCd)))));
						}
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							ReflectionHelper.LetMember(ReflectionHelper.GetMember(oFormName, "txtCommon", new object[]{3}), "Text", ReflectionHelper.GetPrimitiveValue(mReturnValue));
							//UPGRADE_WARNING: (1068) fg.Cell() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							ReflectionHelper.LetMember(ReflectionHelper.GetMember(oFormName, "txtCommon", new object[]{23}), "Text", ReflectionHelper.GetPrimitiveValue(fg.getCellText(fg.Row, conTypeCd)));
							ReflectionHelper.Invoke(oFormName, "txtCommon_LostFocus", new object[]{23});
							ReflectionHelper.Invoke(oFormName, "txtCommon_LostFocus", new object[]{3});
							ReflectionHelper.LetMember(ReflectionHelper.GetMember(oFormName, "cmdCommon", new object[]{0}), "Value", true);
							ReflectionHelper.LetMember(ReflectionHelper.GetMember(oFormName, "txtCommon", new object[]{3}), "Enabled", false);
						}
						ReflectionHelper.LetMember(oFormName, "mIsCalledFromCOA", true);
						oFormName.Show();
						//UPGRADE_WARNING: (2065) Form method oFormName.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
						oFormName.BringToFront();
					} 
					break;
				case mnuEdit : 
					 
					mAccountCd = Convert.ToInt32(Conversion.Val(Convert.ToString(fg[fg.Row, conAccountCd]))); 
					mAccntNature = Convert.ToString(fg[fg.Row, conAccountNature]); 
					 
					if (mAccntNature == "G" && mAccountCd > 0)
					{
						oFormName = frmGLAccountGroups.CreateInstance();
						ReflectionHelper.LetMember(oFormName, "mIsCalledFromCOA", true);
						mFormId = 420000;
					}
					else if (mAccntNature == "L" && mAccountCd > 0)
					{ 
						oFormName = frmGLLedger.CreateInstance();
						//oFormName.mIsCalledFromCOA = True
						mFormId = 410000;
					} 
					 
					if (mFormId > 0)
					{

						ReflectionHelper.Invoke(ReflectionHelper.GetMember(oFormName, "UserAccess"), "CheckAccess", new object[]{mFormId, SystemVariables.SystemObjectTypes.objForm});

						if (!ReflectionHelper.GetMember<bool>(ReflectionHelper.GetMember(oFormName, "UserAccess"), "DeniedAccess"))
						{
							//--else skip the form caption setting part
							if (!((mFormId >= 331000 && mFormId <= 336000) || (mFormId >= 341000 && mFormId <= 347000)))
							{
								oFormName.Text = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_form_name" : "a_form_name") + " from SM_FORM where form_id = " + mFormId.ToString()));
							}

							ReflectionHelper.LetMember(oFormName, "ThisFormId", mFormId);
							ReflectionHelper.LetMember(oFormName, "SearchValue", mAccountCd);
							ReflectionHelper.Invoke(oFormName, "GetRecord", new object[]{mAccountCd});
							//oFormName.mParentFormCall = True
							//Set oFormName.mParentForm = Me
							oFormName.Show();
							//UPGRADE_WARNING: (2065) Form method oFormName.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
							oFormName.BringToFront();
						}

					} 
					break;
			}
		}

		public void SetDefaultRowInGrid(string pSearchValue, int pRow, string pNature, int pCol = conAccountNo, bool pFullMatch = true)
		{
			int mRowFocus = 0;

			int mStartRow = pRow;


			while(true)
			{
				mRowFocus = fg.FindRow(pSearchValue, mStartRow, pCol, 0, pFullMatch, false);
				if (mRowFocus > 0)
				{
					if (Convert.ToString(fg[mRowFocus, conAccountNature]) == pNature)
					{
						goto RowFound;
					}
					else
					{
						mStartRow = mRowFocus + 1;
					}
				}
				else
				{
					return;
				}
			};

			RowFound:
			fg.Row = mRowFocus;
			fg.ShowCell(mRowFocus, pCol);
			return;


			return;

			//    mRowFocus = .FindRow(pSearchValue, pRow, pCol, , pFullMatch)
			//    If mRowFocus > 0 Then
			//        If pNature <> "" Then
			//            If .TextMatrix(mRowFocus, conAccountNature) = pNature Then
			//                .Row = mRowFocus
			//                .ShowCell mRowFocus, pCol
			//            Else
			//                mRowFocus = .FindRow(pSearchValue, mRowFocus, pCol, , pFullMatch)
			//                If mRowFocus > 0 Then
			//                    .Row = mRowFocus
			//                    .ShowCell mRowFocus, pCol
			//                End If
			//            End If
			//        End If
			//    End If

		}

		public void PrintReport()
		{ //Print routine
			StringBuilder filter = new StringBuilder();

			int j = 0;

			int lngColSave = 0;
			int lngRowSave = 0;
			int lngRow = 0;
			m_booProcessSelected = true;
			InnovaUpdSupport.PInvoke.SafeNative.user32.LockWindowUpdate(fg.Handle.ToInt32());
			lngColSave = fg.Col;
			lngRowSave = fg.Row;
			int tempForEndVar = fg.Rows.Count - 1;
			for (lngRow = fg.Rows.Fixed; lngRow <= tempForEndVar; lngRow++)
			{
				fg.Row = lngRow;
				if (fg.getCellBackColor() == fg.Styles.Highlight.BackColor)
				{

					if (j > 0)
					{
						filter.Append(",");
					}
					filter.Append(Convert.ToString(fg[fg.Row, conAccountCd]));

					j++;
				}
			}
			fg.Col = lngColSave;
			fg.Row = lngRowSave;
			InnovaUpdSupport.PInvoke.SafeNative.user32.LockWindowUpdate(0);
			m_booProcessSelected = false;

			if (filter.ToString() == "")
			{
				SystemReports.GetSystemReport(41001000, 1);
			}
			else
			{
				SystemReports.GetSystemReport(41001000, 1, "", "", "", "", " l.ldgr_cd in (" + filter.ToString() + ")");
			}
		}

		bool booBusy_fg_RowColChange = false;
		private void fg_RowColChange(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				if (Convert.ToString(fg[fg.Row, fg.Col]) == "")
				{
					return;
				}

				int intThisCol = 0;
				int intThisRow = 0;
				if (m_booKeyShift || m_booProcessSelected || booBusy_fg_RowColChange)
				{
					return;
				}
				booBusy_fg_RowColChange = true;

				intThisCol = fg.Col;
				intThisRow = fg.Row;

				InnovaUpdSupport.PInvoke.SafeNative.user32.LockWindowUpdate(fg.Handle.ToInt32());

				if (m_booKeyCtrl)
				{
					fg.Col = 1;
					fg.Row = intThisRow;
					fg.ColSel = fg.Cols.Count - 1;
					fg.RowSel = intThisRow;
					if (fg.getCellBackColor() == fg.Styles.Highlight.BackColor)
					{
						fg.setCellBackColor(fg.BackColor);
						fg.setCellForeColor(fg.ForeColor);
					}
					else
					{
						fg.setCellBackColor(fg.Styles.Highlight.BackColor);
						fg.setCellForeColor(fg.Styles.Highlight.ForeColor);
					}
				}
				else
				{
					fg.Col = 1;
					fg.Row = 1;
					fg.ColSel = fg.Cols.Count - 1;
					fg.RowSel = fg.Rows.Count - 1;
					//UPGRADE_ISSUE: (2064) VSFlex8L.FillStyleSettings property FillStyleSettings.flexFillRepeat was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid property fg.FillStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					fg.setFillStyle(UpgradeStubs.VSFlex8L_FillStyleSettings.getflexFillRepeat());
					fg.setCellBackColor(fg.BackColor);
					fg.setCellForeColor(fg.ForeColor);
					fg.Col = 1;
					fg.Row = intThisRow;
					fg.ColSel = fg.Cols.Count - 1;
					fg.RowSel = intThisRow;
					fg.setCellBackColor(fg.Styles.Highlight.BackColor);
					fg.setCellForeColor(fg.Styles.Highlight.ForeColor);
				}

				fg.Col = intThisCol;
				fg.Row = intThisRow;

				InnovaUpdSupport.PInvoke.SafeNative.user32.LockWindowUpdate(0);
				booBusy_fg_RowColChange = false;
			}
			catch
			{
			}


		}

		private void fg_SelChange(Object eventSender, EventArgs eventArgs)
		{
			int intThisCol = 0;
			int intThisRow = 0;
			int intNextCol = 0;
			int intNextRow = 0;

			if (!m_booKeyShift)
			{
				return;
			}

			intThisCol = fg.Col;
			intThisRow = fg.Row;

			intNextCol = fg.ColSel;
			intNextRow = fg.RowSel;

			InnovaUpdSupport.PInvoke.SafeNative.user32.LockWindowUpdate(fg.Handle.ToInt32());

			// Clear Screen
			fg.Col = 1;
			fg.Row = 1;
			fg.ColSel = fg.Cols.Count - 1;
			fg.RowSel = fg.Rows.Count - 1;
			//UPGRADE_ISSUE: (2064) VSFlex8L.FillStyleSettings property FillStyleSettings.flexFillRepeat was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid property fg.FillStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			fg.setFillStyle(UpgradeStubs.VSFlex8L_FillStyleSettings.getflexFillRepeat());
			fg.setCellBackColor(fg.BackColor);
			fg.setCellForeColor(fg.ForeColor);

			// Update Multiline
			fg.Col = 1;
			fg.Row = intThisRow;
			fg.ColSel = fg.Cols.Count - 1;
			fg.RowSel = intNextRow;
			//UPGRADE_ISSUE: (2064) VSFlex8L.FillStyleSettings property FillStyleSettings.flexFillRepeat was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) VSFlex8L.VSFlexGrid property fg.FillStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			fg.setFillStyle(UpgradeStubs.VSFlex8L_FillStyleSettings.getflexFillRepeat());
			fg.setCellBackColor(fg.Styles.Highlight.BackColor);
			fg.setCellForeColor(fg.Styles.Highlight.ForeColor);

			InnovaUpdSupport.PInvoke.SafeNative.user32.LockWindowUpdate(0);



			fg.Col = intNextCol;
			fg.Row = intNextRow;

		}
	}
}