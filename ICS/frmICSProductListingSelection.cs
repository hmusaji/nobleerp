
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers;



namespace Xtreme
{
	internal partial class frmICSProductListingSelection
		: System.Windows.Forms.Form
	{

		public frmICSProductListingSelection()
{
InitializeComponent();
} 
 public  void frmICSProductListingSelection_old()
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
			this.oReportGrid.setScrollTips(false);
		}


		private void frmICSProductListingSelection_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private const int conPartNo = 0;
		private const int conProdName = 1;
		private const int conShow = 2;
		private const int conProdCd = 3;

		private const int mFixedHeaderBackColor = 0xAECCC2;
		private const int mFixedGridBackColor = 0xDBEAE3;
		private const int mFilterBackColor = 0xEDFBFE;
		static readonly private Color mResultGridHighlightColor = Color.FromArgb(249, 192, 176);

		private clsToolbar oThisFormToolBar = null;
		int mSearchValue = 0;


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


		//Private Sub btnFormToolBar_Click(Index As Integer)
		//    Call ToolBarButtonClick(Me, btnFormToolBar(Index).Tag)
		//End Sub

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 32)
				{
					KeyCode = 0;
					oReportGrid[oReportGrid.Row, conShow] = (~Convert.ToInt32(Double.Parse(Convert.ToString(oReportGrid[oReportGrid.Row, conShow])))).ToString();
				}

				if (KeyCode == ((int) Keys.F2))
				{
					findRecord();
					return;
				}

				if (KeyCode == 13 && ActiveControl.Name == "txtPrice")
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}
				else if (KeyCode == 13)
				{ 
					SendKeys.Send("40");
					return;
				}
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{


			this.Top = 0;
			this.Left = 0;

			//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(3))
			//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
			//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
			//Set btnFormToolBar(6).Picture = frmSysMain.imlSystemIcons.ListImages("imgSelectAll2").Picture
			//Set btnFormToolBar(7).Picture = frmSysMain.imlSystemIcons.ListImages("imgSelectNone2").Picture
			//Set btnFormToolBar(8).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture


			//**--format & define the new toolbar
			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			oThisFormToolBar.ShowPrintButton = true;
			oThisFormToolBar.ShowFindButton = true;
			//.ShowHelpButton = True
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.ShowCheckAllButton = true;
			oThisFormToolBar.ShowUncheckAllButton = true;

			this.WindowState = FormWindowState.Maximized;


			SqlDataReader rsTempRec = null;

			string mysql = " select part_no ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , l_prod_name ";
			}
			else
			{
				mysql = mysql + " , a_prod_name ";
			}
			mysql = mysql + " , 0 ";
			mysql = mysql + " , prod_cd ";
			mysql = mysql + " from ICS_Item ";
			mysql = mysql + " where discontinued = 0 ";
			mysql = mysql + " order by part_no ";

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();

			if (rsTempRec.Read())
			{
				FormatSelectionGrid();
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property oReportGrid.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oReportGrid.setDataSource((msdatasrc.DataSource) rsTempRec);
				oReportGrid.Cols.Fixed = 2;


				oReportGrid.Cols[conPartNo].WidthDisplay = 133;
				oReportGrid[0, conPartNo] = "Part No ";

				oReportGrid.Cols[conProdName].WidthDisplay = 327;
				oReportGrid[0, conProdName] = "Product Name ";

				oReportGrid.Cols[conShow].WidthDisplay = 20;
				oReportGrid[0, conShow] = "Show";
				oReportGrid.Cols[conShow].DataType = typeof(Boolean);

				oReportGrid.Cols[conProdCd].WidthDisplay = 0;
				oReportGrid.Cols[conProdCd].Visible = false;
				oReportGrid[0, conProdCd] = "Prod_Cd";

				oReportGrid.setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter, 0, 0, 0, 3);
				oReportGrid.setCellFontBold(true, 0, 0, 0, 3);
				oReportGrid.setCellBackColor(ColorTranslator.FromOle(mFixedHeaderBackColor), 0, 0, 0, 3);

				oReportGrid.Row = 1;
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			UserAccess = null;
			frmICSProductListingSelection.DefInstance = null;
		}

		public void KRoutine()
		{
			int Cnt = 0;

			int tempForEndVar = oReportGrid.Rows.Count - 1;
			for (Cnt = 1; Cnt <= tempForEndVar; Cnt++)
			{
				oReportGrid[Cnt, conShow] = "-1";
			}

		}

		public void URoutine()
		{
			int Cnt = 0;

			int tempForEndVar = oReportGrid.Rows.Count - 1;
			for (Cnt = 1; Cnt <= tempForEndVar; Cnt++)
			{
				oReportGrid[Cnt, conShow] = "0";
			}

		}

		public void PrintReport(int pEntryId = 0)
		{
			StringBuilder mysql = new StringBuilder();
			int Cnt = 0;

			//If IsEmpty(txtPrice.Text) Or txtPrice.Text = "" Then
			//    MsgBox "Please select Price", vbInformation
			//    txtPrice.SetFocus
			//    Exit Sub
			//End If
			string mParameter = " ICS_Item. prod_cd in ( 0 ";

			int tempForEndVar = oReportGrid.Rows.Count - 1;
			for (Cnt = 1; Cnt <= tempForEndVar; Cnt++)
			{
				if (StringsHelper.ToDoubleSafe(Convert.ToString(oReportGrid[Cnt, conShow])) == -1)
				{
					mysql.Append(" ," + Convert.ToString(oReportGrid[Cnt, conProdCd]));
				}
			}

			mParameter = mParameter + mysql.ToString() + " ) ";
			if (txtPrice.Text != "")
			{
				mParameter = mParameter + " and price_list_cd = ";
				mParameter = mParameter + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select Price_List_cd from ICS_Price_List where Price_List_No=" + txtPrice.Text));
			}


			SystemReports.GetSystemReport(51001010, 1, "", "", "", "", mParameter);
		}


		private void FormatSelectionGrid()
		{
			oReportGrid.Rows.Count = 1;
			oReportGrid.Cols.Count = 0;
			oReportGrid.Clear(C1.Win.C1FlexGrid.ClearFlags.All, oReportGrid.GetCellRange(oReportGrid.BottomRow, oReportGrid.LeftCol, oReportGrid.TopRow, oReportGrid.RightCol));
			//**------------------------
			oReportGrid.Styles.Highlight.BackColor = mResultGridHighlightColor;
			oReportGrid.Styles.Highlight.ForeColor = Color.Black;
			//**------------------------
			oReportGrid.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
			oReportGrid.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			oReportGrid.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			oReportGrid.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
			oReportGrid.AutoResize = false;
			oReportGrid.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
			oReportGrid.AutoSearchDelay = 5;
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property oReportGrid.AutoSizeMouse was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			oReportGrid.setAutoSizeMouse(true);
			oReportGrid.BackColor = Color.FromArgb(255, 255, 255);
			oReportGrid.Styles.Alternate.BackColor = Color.FromArgb(244, 245, 241); //mFilterBackColor
			oReportGrid.Styles.EmptyArea.BackColor = Color.FromArgb(255, 255, 255);
			oReportGrid.Styles.Fixed.BackColor = Color.FromArgb(235, 235, 235);
			oReportGrid.Styles.Frozen.BackColor = Color.FromArgb(255, 255, 255);
			oReportGrid.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			oReportGrid.AllowEditing = true;
			oReportGrid.ExtendLastCol = true;
			oReportGrid.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
			oReportGrid.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			//UPGRADE_ISSUE: (2064) VSFlex8L.FillStyleSettings property FillStyleSettings.flexFillSingle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property oReportGrid.FillStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			oReportGrid.setFillStyle(UpgradeStubs.VSFlex8L_FillStyleSettings.getflexFillSingle());
			oReportGrid.Cols.Fixed = 0;
			oReportGrid.Rows.Fixed = 1;
			oReportGrid.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
			oReportGrid.ForeColor = Color.FromArgb(0, 0, 0);
			oReportGrid.Styles.Fixed.ForeColor = Color.FromArgb(0, 0, 0);
			oReportGrid.Styles.Frozen.ForeColor = Color.FromArgb(0, 0, 0);
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property oReportGrid.FontSize was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			oReportGrid.setFontSize(8);
			oReportGrid.Styles.Normal.Border.Color = Color.FromArgb(0, 0, 0);
			oReportGrid.Styles.Fixed.Border.Color = Color.FromArgb(0, 0, 0);
			oReportGrid.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			oReportGrid.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			oReportGrid.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			oReportGrid.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			oReportGrid.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
			//.Height = Me.ScaleHeight - picFormToolbar.Height
			oReportGrid.Left = 0;
			oReportGrid.Rows.MinSize = 17;
			oReportGrid.ScrollBars = ScrollBars.Both;
			oReportGrid.setScrollTips(false);
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property oReportGrid.ScrollTrack was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			oReportGrid.setScrollTrack(true);
			oReportGrid.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
			oReportGrid.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = Color.FromArgb(0, 0, 0);
			oReportGrid.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			oReportGrid.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			oReportGrid.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			//.Top = picFormToolbar.Top + picFormToolbar.Height
			//.Width = Me.ScaleWidth
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property oReportGrid.FontName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oReportGrid.setFontName("Arial");
				oReportGrid.RightToLeft = RightToLeft.No;
			}
			else
			{
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property oReportGrid.FontName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				oReportGrid.setFontName(SystemConstants.gArabicFontName);
				oReportGrid.RightToLeft = RightToLeft.Yes;
			}
			oReportGrid.Rows[0].HeightDisplay = 24;
		}

		public void findRecord()
		{

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempSearchValue).GetValue(0));
				Application.DoEvents();
				FindProduct(mSearchValue);
			}
		}

		private void FindProduct(int pProdCd)
		{
			int Cnt = 0;

			oReportGrid.Focus();
			int tempForEndVar = oReportGrid.Rows.Count - 1;
			for (Cnt = 1; Cnt <= tempForEndVar; Cnt++)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(oReportGrid.getCellText(Cnt, conProdCd))) == pProdCd)
				{
					oReportGrid.Row = Cnt;
					oReportGrid.Col = conShow;
					oReportGrid.Tree.Show(2);
					oReportGrid.ShowCell(Cnt, conPartNo);
					oReportGrid.setCellText(((int) TriState.True).ToString(), Cnt, conShow);
					return;
				}
			}

		}

		private void txtPrice_DropButtonClick(Object Sender, EventArgs e)
		{
			txtPrice.Text = "";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2009010, "2570,2571,2572"));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtPrice.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				txtPriceName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
				txtPrice_Leave(txtPrice, new EventArgs());
			}
		}

		private void txtPrice_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int Cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtPrice.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "Price_List_L_Name" : "Price_List_A_Name");
					mysql = mysql + " from ICS_Price_List where Price_List_No=" + txtPrice.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtPriceName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtPriceName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtPriceName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
			}
		}
	}
}