
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class repItemQuery
		: System.Windows.Forms.Form
	{

		int mThisFormID = 0;
		int mEntry_id = 0;
		int mPurchaseEntry_id = 0;
		int mtotalLocation = 0;

		private XArrayHelper _aLocationDetails = null;
		public repItemQuery()
{
InitializeComponent();
} 
 public  void repItemQuery_old()
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


		XArrayHelper aLocationDetails
		{
			get
			{
				if (_aLocationDetails is null)
				{
					_aLocationDetails = new XArrayHelper();
				}
				return _aLocationDetails;
			}
			set
			{
				_aLocationDetails = value;
			}
		}


		private clsToolbar oThisFormToolBar = null;
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


		private const int mTotalGridColumns = 14;

		private const int mLocationNoColumns = 0;
		private const int mLocationNameColumns = 1;
		private const int mBinLocationColumns = 2;
		private const int mStockInHandColumns = 3;
		private const int mStockAllocatedColumns = 4;
		private const int mStockAvailableColumns = 5;
		private const int mStockInTransitColumns = 6;
		private const int mStockOnOrderOfSalesColumns = 7;
		private const int mStockReservedColumns = 8;
		private const int mStockReturnInTransitColumns = 9;
		private const int mStockBookedColumns = 10;
		private const int mStockMTDUsageColumns = 11;
		private const int mStockYTDUsageColumns = 12;
		private const int mStockPhysicalLocationColumns = 13;
		private const int mLocationCodeColumn = 14;

		private const int conlblCostPrice = 1;
		private const int conlblClosingBal = 3;
		private const int conlblOpeningBal = 24;
		private const int conlblClosingValue = 9;
		private const int conlblOpeningValue = 23;
		private const int conlblPurchaseRate = 26;

		private const int mProductName = 1;
		private const int mProductCost = 2;
		private const int mProductCategory = 3;
		private const int mCostingMethod = 4;
		private const int mProductGroup = 5;
		private const int mOpeningBal = 6;
		private const int mOpeningVal = 7;
		private const int mClosingBal = 8;
		private const int mClosingVal = 9;
		private const int mProductType = 10;
		private const int mSupplierPartNo = 11;
		private const int mProductDescription = 12;
		private const int mTotalPurchaseQty = 13;
		private const int mTotalPurchaseRate = 14;
		private const int mTotalPurchaseDiscountAmount = 15;
		private const int mTotalPurchaseAmount = 16;
		private const int mTotalMonthlyPurchaseAmount = 17;
		private const int mTotalYearlyPurchaseAmount = 18;
		private const int mTotalSalesQty = 19;
		private const int mTotalSalesRate = 20;
		private const int mTotalSalesDiscountAmount = 21;
		private const int mTotalSalesAmount = 22;
		private const int mTotalMonthlySalesAmount = 23;
		private const int mTotalYearlySalesAmount = 24;
		private const int mSalesRate1 = 25;
		private const int mPurchaseRate = 26;
		private const int mSalesRate2 = 28;

		private clsPictureDisplay clsItemDisplay = null;
		private XtremeChartControl.ChartSeries Series = null;
		private XtremeChartControl.ChartSeries Series1 = null;
		private XtremeChartControl.ChartSeries Series2 = null;
		private XtremeChartControl.ChartSeries Series3 = null;


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


		private void ChartControl_MouseDownEvent(Object eventSender, AxXtremeChartControl._DChartControlEvents_MouseDownEvent eventArgs)
		{
			XtremeChartControl.ChartElement Element = null;
			XtremeChartControl.ChartSeriesPoint Point = null;
			if (eventArgs.button == 1)
			{
				Element = ChartControl.HitTest(eventArgs.x, eventArgs.y);

				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					Point = (XtremeChartControl.ChartSeriesPoint) Element;

					if (Point != null)
					{
						DoChartDrillDown(Convert.ToInt32(Double.Parse(Point.LegendText)));
						this.Cursor = CursorHelper.CursorDefault;
					}
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
		}

		private void ChartControl_MouseMoveEvent(Object eventSender, AxXtremeChartControl._DChartControlEvents_MouseMoveEvent eventArgs)
		{
			XtremeChartControl.ChartElement Element = ChartControl.HitTest(eventArgs.x, eventArgs.y);

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				XtremeChartControl.ChartSeriesPoint Point = (XtremeChartControl.ChartSeriesPoint) Element;

				if (Point != null)
				{
					//UPGRADE_ISSUE: (2070) Constant vbCustom was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
					this.Cursor = UpgradeStubs.System_Windows_Forms_Cursor.getvbCustom();
					this.Cursor = new Cursor((new Bitmap(frmSysIconsForm.DefInstance.imlSystemIcons.Images["imgHand"])).GetHicon());
				}
				else
				{
					this.Cursor = CursorHelper.CursorDefault;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void cmdProductPicture_Click()
		{
			string mPicturePath = "";
			if (txtPartNo.Text == "")
			{
				return;
			}
			string mSQL = " select picture from ICS_Item where part_no = '" + txtPartNo.Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mPicturePath = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				clsItemDisplay = new clsPictureDisplay();
				clsItemDisplay.PictureName = mPicturePath;
				clsItemDisplay.Show();
			}

		}

		//Private Sub btnFormToolBar_Click(Index As Integer)
		//'If Index = 0 Then
		//'
		//'Call DoReportDrillDown(Val(grdLocationDetails.Bookmark))
		//'Else
		//'Call ToolBarButtonClick(repItemQuery, btnFormToolBar(Index).Tag)
		//'End If
		//
		//Call ToolBarButtonClick(repItemQuery, btnFormToolBar(Index).Tag)
		//End Sub

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				SystemMenu.SetMeCurrentInWindowList(Conversion.Str(this.Handle.ToInt32()));
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			//Set FirstFocusObject = txtPartNo
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdLocationDetails, false, false, false, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow, 1.47f, 1, "&HE7E2DC", "&HE7E2DC");
			//--**modify additional properties

			C1.Win.C1TrueDBGrid.Style withVar = null;
			withVar = grdLocationDetails.HighLightRowStyle;
			withVar.BackColor = Color.FromArgb(184, 190, 214); //&H72DAA6
			withVar.ForeColor = Color.Black;
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.StyleDisp property withVar.BorderSize was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar.setBorderSize(1);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.StyleDisp property withVar.BorderType was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar.setBorderType(15);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.StyleDisp property withVar.BorderColor was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar.setBorderColor(Color.FromArgb(22, 37, 82));


			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdLocationDetails, "Code", 1400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLocationDetails, "Location Name", 3000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLocationDetails, "Bin Location", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLocationDetails, "Stock in Hand", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Stock_In_Hand_In_PQ")), false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLocationDetails, "Stock Allocated", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Stock_Allocated_In_PQ")), false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLocationDetails, "Stock Available", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Stock_Available_In_PQ")), false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLocationDetails, "Stock In Transit", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Stock_In_Transit_In_PQ")), false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLocationDetails, "Stock On Order", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_On_Order_Stock_In_PQ")), false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLocationDetails, "Stock Reserved", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Reserved_Stock_In_PQ")));
			SystemGrid.DefineSystemVoucherGridColumn(grdLocationDetails, "Stock Return In Transit", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Stock_Return_In_Transit_In_PQ")), false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLocationDetails, "Stock Booked", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Advanced_Booked_Stock_In_PQ")), false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLocationDetails, "Monthly Usage", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_MTD_Usage_In_PQ")), false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLocationDetails, "Yearly Usage", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_YTD_Usage_In_PQ")), false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdLocationDetails, "physical location", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Physical_Location_In_PQ")), false, false, false, false, 100, "", "", false, "", 0, true);

			this.Top = 0;
			this.Left = 0;

			//**--format & define the new toolbar
			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			oThisFormToolBar.ShowDrillDownButton = true;
			//.ShowProductPictureButton = True
			oThisFormToolBar.ShowMoveRecordPreviousButton = true;
			oThisFormToolBar.ShowMoveRecordNextButton = true;
			oThisFormToolBar.ShowHelpButton = true;
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.ShowFindButton = true;
			oThisFormToolBar.BeginProductPictureButtonWithGroup = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.DisableHelpButton = true;

			this.WindowState = FormWindowState.Maximized;


			//'Assign the Image for the toolbar
			//'Imagelist are kept on the main form and refered by their key
			//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
			//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgDrillDown").Picture
			//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
			//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
			//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgMovePrevious").Picture
			//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgMoveNext").Picture
			//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture

			txtLastCommanLabel[1].Cursor = new Cursor((new Bitmap(frmSysIconsForm.DefInstance.imlSystemIcons.Images["imgHand"])).GetHicon());
			txtLastCommanLabel[4].Cursor = new Cursor((new Bitmap(frmSysIconsForm.DefInstance.imlSystemIcons.Images["imgHand"])).GetHicon());
			txtLastCommanLabel[2].Cursor = new Cursor((new Bitmap(frmSysIconsForm.DefInstance.imlSystemIcons.Images["imgHand"])).GetHicon());
			txtLastCommanLabel[5].Cursor = new Cursor((new Bitmap(frmSysIconsForm.DefInstance.imlSystemIcons.Images["imgHand"])).GetHicon());
			txtLastCommanLabel[3].Cursor = new Cursor((new Bitmap(frmSysIconsForm.DefInstance.imlSystemIcons.Images["imgHand"])).GetHicon());
			txtLastCommanLabel[6].Cursor = new Cursor((new Bitmap(frmSysIconsForm.DefInstance.imlSystemIcons.Images["imgHand"])).GetHicon());

			SystemProcedure.SetLabelCaption(this);
			clsFlip oFlipThisForm = null;
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
			{
				oFlipThisForm = new clsFlip();

				oFlipThisForm.SwapMe(this);
			}

			lblCommon[conlblCostPrice].Visible = SystemVariables.gEnableUserLevelCostDetails;
			txtCommanTextbox[mProductCost].Visible = SystemVariables.gEnableUserLevelCostDetails;

			lblCommon[conlblOpeningBal].Visible = SystemVariables.gEnableUserLevelCostDetails;
			txtCommanTextbox[mOpeningBal].Visible = SystemVariables.gEnableUserLevelCostDetails;
			lblCommon[conlblClosingBal].Visible = SystemVariables.gEnableUserLevelCostDetails;
			txtCommanTextbox[mClosingBal].Visible = SystemVariables.gEnableUserLevelCostDetails;

			lblCommon[conlblOpeningValue].Visible = SystemVariables.gEnableUserLevelCostDetails;
			txtCommanTextbox[mOpeningVal].Visible = SystemVariables.gEnableUserLevelCostDetails;
			lblCommon[conlblClosingValue].Visible = SystemVariables.gEnableUserLevelCostDetails;
			txtCommanTextbox[mClosingVal].Visible = SystemVariables.gEnableUserLevelCostDetails;

			lblCommon[conlblPurchaseRate].Visible = SystemVariables.gEnableUserLevelCostDetails;
			txtCommanTextbox[mPurchaseRate].Visible = SystemVariables.gEnableUserLevelCostDetails;

			ChartControl.Content.BackgroundColor = Convert.ToUInt32(0xE7E2DC);
			ChartControl.Content.Border.Visible = false;

			ChartControl.Content.Series.DeleteAll();
			ChartControl.Content.Titles.DeleteAll();
			//ChartControl.Content.Titles.Add "Stock In Hand"
			ChartControl.Content.Legend.Visible = true;
			ChartControl.Content.Legend.HorizontalAlignment = XtremeChartControl.ChartLegendAlignment.xtpChartLegendFarOutside;

			Series = ChartControl.Content.Series.Add("Stock In Hand");
			Series1 = ChartControl.Content.Series.Add("Stock Allocated");
			Series2 = ChartControl.Content.Series.Add("Stock Available");
			Series3 = ChartControl.Content.Series.Add("Stock In Transit");

			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			Series.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Stock_In_Hand_In_PQ"));
			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			Series1.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Stock_Allocated_In_PQ"));
			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			Series2.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Stock_Available_In_PQ"));
			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			Series3.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Stock_In_Transit_In_PQ"));

			ChartControl.Content.Series[3].Style = (XtremeChartControl.ChartSeriesStyle) new XtremeChartControl.ChartBarSeriesStyle(); //ChartBarSeriesStyle
			ChartControl.Content.Series[2].Style = (XtremeChartControl.ChartSeriesStyle) new XtremeChartControl.ChartBarSeriesStyle();
			ChartControl.Content.Series[1].Style = (XtremeChartControl.ChartSeriesStyle) new XtremeChartControl.ChartBarSeriesStyle();
			ChartControl.Content.Series[0].Style = (XtremeChartControl.ChartSeriesStyle) new XtremeChartControl.ChartBarSeriesStyle();

			ChartControl.Content.Appearance.SetPalette("Office");

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("product_picture")))
			{
				fraProductInformation.Visible = true;
				imgPicture.Cursor = new Cursor((new Bitmap(frmSysIconsForm.DefInstance.imlSystemIcons.Images["imgHand"])).GetHicon());
			}
			else
			{
				fraProductInformation.Visible = false;
			}

		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				string mysql = "";
				object mReturnValue = null;

				if (Shift == 2 && (KeyCode == 67 || KeyCode == 86 || KeyCode == 88))
				{
					return;
				}

				//If KeyCode = 13 Then
				//    Exit Sub
				//ElseIf KeyCode = 115 Then                         'F2 key
				//    Call FindRoutine
				//   '(Me.ActiveControl.Name)
				//ElseIf KeyCode = vbKeyEscape Then
				//    Unload Me
				//    Exit Sub
				//End If

				//If KeyCode = 13 Then    'If enter key pressed send a tab key
				//    SendKeys "{TAB}"
				//    Exit Sub
				//End If


				//If F11 pressed show ICS_Item assembly details
				if (Shift == 0 && KeyCode == 122)
				{
					if (!SystemProcedure2.IsItEmpty(txtPartNo.Text, SystemVariables.DataType.StringType))
					{
						mysql = " select item_type_cd from ICS_Item ";
						mysql = mysql + " where part_no='" + txtPartNo.Text + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == SystemICSConstants.ptAssemblyBuildTypeID)
							{
								ShowProductAssemblyDetails(txtPartNo.Text);
							}
						}
					}
				}


				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift); //, Me.ActiveControl.Name)
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

				aLocationDetails = null;
				UserAccess = null;
				repItemQuery.DefInstance = null;
				oThisFormToolBar = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void grdLocationDetails_Click(Object eventSender, EventArgs eventArgs)
		{
			//If IsItEmpty(txtPartNo.Text, StringType) Then
			//     MsgBox "Error:Part No not Found"
			//     txtPartNo.SetFocus
			//End If
			//
			//If Not IsItEmpty(txtPartNo.Text, StringType) Then
			//    Call GetProductInfo(txtPartNo.Text)
			//End If
		}

		private void grdLocationDetails_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdLocationDetails.Bookmark))
			{
				DoReportDrillDown(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdLocationDetails.Bookmark))));
			}
		}

		private void grdLocationDetails_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				try
				{
					switch(KeyCode)
					{
						case 13 : case 32 : 
							DoReportDrillDown(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdLocationDetails.Bookmark)))); 
							break;
						case 27 : 
							CloseForm(); 
							break;
					}

					return;
				}
				catch (System.Exception excep)
				{
					MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void tlbFormToolBar_ButtonClick(ToolStripItem Button)
		{
			SystemForms.ToolBarButtonClick(this, Button.Name);
		}


		private void imgPicture_Click(Object eventSender, EventArgs eventArgs)
		{

			if (ToolTipMain.GetToolTip(imgPicture) != "")
			{
				//UPGRADE_ISSUE: (2068) Nothing object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
				if (clsItemDisplay is UpgradeStubs.Nothing)
				{
					clsItemDisplay = new clsPictureDisplay();
				}
				clsItemDisplay.PictureName = ToolTipMain.GetToolTip(imgPicture);

				clsItemDisplay.Show();
			}
		}

		private void txtLastCommanLabel_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtLastCommanLabel, eventSender);
			int vouhcer_type = 0;
			switch(Index)
			{
				case 1 : case 2 : case 3 : 
					if (mPurchaseEntry_id != 0)
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						vouhcer_type = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select voucher_type from ICS_Transaction where entry_id = " + mPurchaseEntry_id.ToString()));
						if (SystemForms.GetSystemForm(331000, 2, mPurchaseEntry_id, vouhcer_type))
						{
						}
						else
						{
							MessageBox.Show("Error:", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
					} 
					break;
				case 4 : case 5 : case 6 : 
					if (mEntry_id != 0)
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						vouhcer_type = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select voucher_type from ICS_Transaction where entry_id = " + mEntry_id.ToString()));
						if (SystemForms.GetSystemForm(341000, 2, mEntry_id, vouhcer_type))
						{
							//MsgBox "X"
						}
						else
						{
							MessageBox.Show("Error:", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
					} 
					break;
			}
		}

		private void txtPartNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine();
		}

		private void txtPartNo_KeyDown(Object Sender, System.Windows.Forms.TextBox.KeyDownEventArgs e)
		{
			Keys KeyCode = (Keys) e.KeyCode;
			int Shift = e.Shift;
			object mReturnValue = null;

			if (KeyCode == Keys.Return)
			{
				if (!SystemProcedure2.IsItEmpty(txtPartNo.Text, SystemVariables.DataType.StringType))
				{
					GetProductInfo(txtPartNo.Text);
				}
			}

			//If KeyCode = vbKeyF12 Then
			//    cmdProductPicture.Value = True
			//End If

			string mysql = "";
			if (KeyCode == Keys.F9)
			{
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("replacement_product")))
				{
					if (!SystemProcedure2.IsItEmpty(txtPartNo.Text, SystemVariables.DataType.StringType))
					{

						mysql = " select prod_cd from ICS_Item where part_no='" + txtPartNo.Text + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							frmICSReplacementProduct.DefInstance.GetRecord(mReturnValue);
							frmICSReplacementProduct.DefInstance.Show();
							//UPGRADE_WARNING: (2065) Form method frmICSReplacementProduct.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
							frmICSReplacementProduct.DefInstance.BringToFront();
						}
					}
				}
			}
		}

		public void FindRoutine()
		{


			txtPartNo.Text = "";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001000, "27,28,29,30"));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtPartNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(2));
				txtCommanTextbox[1].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(3) : ((Array) mTempSearchValue).GetValue(4));
				GetProductInfo(txtPartNo.Text);
				//Call txtPartNo_LostFocus
			}

		}

		public void CloseForm()
		{
			this.Close();
		}

		private void DoReportDrillDown(int pCurrentRow)
		{

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mProductCode = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select prod_cd from ICS_Item where part_no = '" + txtPartNo.Text + "'"));

			string mParameterString = " set @ProductCode = " + Conversion.Str(mProductCode);
			mParameterString = mParameterString + " set @LocationCode = " + Conversion.Str(aLocationDetails.GetValue(pCurrentRow, mLocationCodeColumn));
			mParameterString = mParameterString + " set @FromDate = '" + SystemVariables.gCurrentPeriodStarts + "'";
			mParameterString = mParameterString + " set @ToDate = '" + SystemVariables.gNextPeriodEnds + "'";

			string mTitleFilterString = "Product Code : " + txtPartNo.Text + new String(' ', 10);
			mTitleFilterString = mTitleFilterString + "Product Name : " + txtCommanTextbox[1].Text + "\r";
			mTitleFilterString = mTitleFilterString + "Location Code : " + Convert.ToString(aLocationDetails.GetValue(pCurrentRow, mLocationNoColumns)) + new String(' ', 10);
			mTitleFilterString = mTitleFilterString + "Location Code : " + Convert.ToString(aLocationDetails.GetValue(pCurrentRow, mLocationNameColumns));

			SystemReports.GetSystemReport(52001000, 2, mParameterString, SystemVariables.gCurrentPeriodStarts, SystemVariables.gCurrentPeriodEnds, mTitleFilterString);
		}

		private void DoChartDrillDown(int pLocCode)
		{
			int mProductCode = 0;
			string mParameterString = "";
			string mTitleFilterString = "";

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select locat_no, l_locat_name from SM_location where locat_cd =" + pLocCode.ToString()));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mProductCode = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select prod_cd from ICS_Item where part_no = '" + txtPartNo.Text + "'"));

				mParameterString = " set @ProductCode = " + Conversion.Str(mProductCode);
				mParameterString = mParameterString + " set @LocationCode = " + Conversion.Str(pLocCode);
				mParameterString = mParameterString + " set @FromDate = '" + SystemVariables.gCurrentPeriodStarts + "'";
				mParameterString = mParameterString + " set @ToDate = '" + SystemVariables.gNextPeriodEnds + "'";

				mTitleFilterString = "Product Code : " + txtPartNo.Text + new String(' ', 10);
				mTitleFilterString = mTitleFilterString + "Product Name : " + txtCommanTextbox[1].Text + "\r";
				mTitleFilterString = mTitleFilterString + "Location Code : " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0)) + new String(' ', 10);
				mTitleFilterString = mTitleFilterString + "Location Code : " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));

				SystemReports.GetSystemReport(52001000, 2, mParameterString, SystemVariables.gCurrentPeriodStarts, SystemVariables.gCurrentPeriodEnds, mTitleFilterString);
			}
		}
		public void IRoutine()
		{
			if (Strings.Len(SystemVariables.gProductPicturesPath) > 0)
			{
				frmICSItemPictures.DefInstance.Show();
				//UPGRADE_WARNING: (2065) Form method frmICSItemPictures.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
				frmICSItemPictures.DefInstance.BringToFront();
				frmICSItemPictures.DefInstance.ItemNo = txtPartNo.Text;
			}
		}

		public void GetProductInfo(string pPartNo)
		{
			DataSet rsProductInfo = new DataSet();
			string mysql = "";
			object mProductCode = null;

			try
			{
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mProductCode = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select prod_cd from ICS_Item where part_no = '" + txtPartNo.Text + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mProductCode))
				{
					throw new System.Exception("-9990002");
					txtPartNo.Focus();
					return;
				}

				//retriving ICS_Item information
				mysql = "select ICS_Item.part_no, ICS_Item.prod_desc ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " ,ICS_Item.l_prod_name as prod_name" : " ,ICS_Item.a_prod_name as prod_name");
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " ,ICS_Item_Group.l_group_name as group_name " : " ,ICS_Item_Group.a_group_name as group_name ");
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " ,ICS_Item_Category.l_cat_name as cat_name " : " ,ICS_Item_Category.a_cat_name as cat_name ");
				mysql = mysql + ", ICS_Item.cost, ICS_Item.stock_in_hand, ICS_Item.costing_method , ";
				mysql = mysql + " ICS_Item.Discontinued , ICS_Item.Supplier_Part_No,  ICS_Item.Item_Type_Cd ";
				mysql = mysql + " , ICS_Item.sales_rate, ICS_Item.purchase_rate ";
				mysql = mysql + " , ICS_Item.picture,  ICS_Item.Sale_Rate1 ";
				//'added by Moiz Hakimi ghee
				//'date:27-jan-2008
				mysql = mysql + " , ICS_Item.bin_location, " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " ICS_Unit.l_unit_name " : " ICS_Unit.l_unit_name ") + " as unit_name ";
				//end
				mysql = mysql + " from ICS_Item inner join ICS_Item_group on ICS_Item.group_cd = ICS_Item_group.group_cd ";
				mysql = mysql + " inner join ICS_Item_category on ICS_Item.cat_cd = ICS_Item_category.cat_cd ";
				//'added by Moiz Hakimi
				//'Date: 27-Jan-2008
				mysql = mysql + " inner join ICS_Unit on ICS_Item.base_unit_cd = ICS_Unit.unit_cd ";
				//End
				mysql = mysql + " where ICS_Item.prod_cd = " + Conversion.Str(mProductCode);

				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsProductInfo.Tables.Clear();
				adap.Fill(rsProductInfo);
				if (rsProductInfo.Tables[0].Rows.Count != 0)
				{
					//'added by Moiz Hakimi ghee
					//' date:27-jan-2008
					//txtCommanTextbox(0).Text = IIf(IsNull(rsProductInfo("bin_location")), "", rsProductInfo("bin_location"))
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					txtCommanTextbox[27].Text = (Convert.IsDBNull(rsProductInfo.Tables[0].Rows[0]["unit_name"])) ? "" : Convert.ToString(rsProductInfo.Tables[0].Rows[0]["unit_name"]);
					//'end
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[1].Text = Convert.ToString(rsProductInfo.Tables[0].Rows[0]["prod_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[4].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["stock_in_hand"], "###,###,##0.000");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[2].Text = Convert.ToString(rsProductInfo.Tables[0].Rows[0]["cost"]); //Format(rsProductInfo.Fields("cost"), "###,###,##0.000")

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[3].Text = Convert.ToString(rsProductInfo.Tables[0].Rows[0]["cat_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[12].Text = Convert.ToString(rsProductInfo.Tables[0].Rows[0]["prod_desc"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtDescription.Text = Convert.ToString(rsProductInfo.Tables[0].Rows[0]["prod_desc"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[5].Text = Convert.ToString(rsProductInfo.Tables[0].Rows[0]["group_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[mSalesRate1].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["sales_rate"], "#,###,##0.000");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[mSalesRate2].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["Sale_Rate1"], "#,###,##0.000");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[mPurchaseRate].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["purchase_rate"], "#,###,##0.000");

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToDouble(rsProductInfo.Tables[0].Rows[0]["Discontinued"]) == 1)
					{
						chkDiscontinue.CheckState = CheckState.Checked;
					}
					else
					{
						chkDiscontinue.CheckState = CheckState.Unchecked;
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToDouble(rsProductInfo.Tables[0].Rows[0]["Item_Type_Cd"]) == 1)
					{
						txtCommanTextbox[10].Text = "Inventory";
					}
					else if (Convert.ToDouble(rsProductInfo.Tables[0].Rows[0]["Item_Type_Cd"]) == 2)
					{ 
						txtCommanTextbox[10].Text = "Service";
					}
					else if (Convert.ToDouble(rsProductInfo.Tables[0].Rows[0]["Item_Type_Cd"]) == 3)
					{ 
						txtCommanTextbox[10].Text = "Assets";
					}
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[11].Text = Convert.ToString(rsProductInfo.Tables[0].Rows[0]["Supplier_Part_No"]) + "";

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToDouble(rsProductInfo.Tables[0].Rows[0]["costing_method"]) == 1)
					{
						txtCommanTextbox[4].Text = "Average Costing";
					}
					else
					{
						txtCommanTextbox[4].Text = "Standard Costing";
					}
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[8].Text = Convert.ToString(rsProductInfo.Tables[0].Rows[0]["stock_in_hand"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[9].Text = StringsHelper.Format(Convert.ToDouble(rsProductInfo.Tables[0].Rows[0]["stock_in_hand"]) * Convert.ToDouble(rsProductInfo.Tables[0].Rows[0]["cost"]), "###,###,##0.000");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkDiscontinue.CheckState = (CheckState) ((!Convert.ToBoolean(rsProductInfo.Tables[0].Rows[0]["discontinued"])) ? 0 : 1);

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("product_picture")))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						ShowPicture(Convert.ToString(rsProductInfo.Tables[0].Rows[0]["picture"]) + "");
					}
				}


				//Set rsProductInfo = Nothing


				//retriving Total Opening Stock , Total Opening Stock value information
				mysql = "select sum(base_qty)as TotalOpeningStock, sum(lc_amount) as TotalOpeningValue from ICS_Transaction_Details ";
				mysql = mysql + " itd inner join ICS_Transaction mt on itd.entry_id = mt.entry_id ";
				mysql = mysql + " inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";
				mysql = mysql + " Where ivt.affect_opening_value = 1 ";
				mysql = mysql + " and itd.prod_cd =" + Conversion.Str(mProductCode);

				SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsProductInfo.Tables.Clear();
				adap_2.Fill(rsProductInfo);
				if (rsProductInfo.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[6].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["TotalOpeningStock"], "###,###,##0.00");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[7].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["TotalOpeningValue"], "###,###,##0.000");
				}
				else
				{
					txtCommanTextbox[6].Text = "";
					txtCommanTextbox[7].Text = "";
				}
				//Set rsProductInfo = Nothing


				//'retriving ICS_Item last purchase information
				//mySql = "select top 1 mt.Entry_ID , mt.voucher_date "
				//mySql = mySql + IIf(gPreferedLanguage = English, " ,ledger.l_ldgr_name as ldgr_name", " , ledger.a_ldgr_name as ldgr_name")
				//mySql = mySql & " , dt.base_qty as qty, ICS_Unit.symbol, "
				//mySql = mySql & " dt.lc_rate as rate,  dt.lc_amount, dt.prod_exp_amt as expenses "
				//mySql = mySql & " from ICS_Transaction_Details dt inner join ICS_Transaction mt  on dt.entry_id = mt.entry_id  "
				//mySql = mySql & " inner join gl_ledger ledger on mt.ldgr_cd = ledger.ldgr_cd "
				//mySql = mySql & " inner join ICS_Item on dt.prod_cd = ICS_Item.prod_cd  "
				//mySql = mySql & " inner join ICS_Unit on ICS_Unit.unit_cd = ICS_Item.base_unit_cd "
				//mySql = mySql & " where mt.voucher_type=101 and dt.prod_cd = " & Str(mProductCode)
				//mySql = mySql & " order by 1 desc "

				//retriving ICS_Item last purchase information
				mysql = "select top 1 mt.Entry_ID , mt.voucher_date";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " ,ledger.l_ldgr_name as ldgr_name" : " , ledger.a_ldgr_name as ldgr_name");
				mysql = mysql + " , dt.qty as qty, ICS_Unit.symbol, ";
				mysql = mysql + " dt.lc_rate as rate,  dt.lc_amount, dt.prod_exp_amt as expenses ";
				mysql = mysql + " from ICS_Transaction_Details dt ";
				mysql = mysql + " inner join ICS_Transaction mt  on dt.entry_id = mt.entry_id  ";
				mysql = mysql + " inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";
				mysql = mysql + " inner join gl_ledger ledger on mt.ldgr_cd = ledger.ldgr_cd ";
				mysql = mysql + " inner join ICS_Item on dt.prod_cd = ICS_Item.prod_cd  ";
				mysql = mysql + " inner join ICS_Item_Unit_Details aud on dt.unit_entry_id = aud.unit_entry_id ";
				mysql = mysql + " inner join ICS_Unit on ICS_Unit.unit_cd = aud.alt_unit_cd ";
				mysql = mysql + " where ivt.parent_type=103 and dt.prod_cd = " + Conversion.Str(mProductCode);
				//''modified by Moiz Hakimion 28-feb-2007
				mysql = mysql + " order by 2 desc,1 desc ";
				//mysql = mysql & " order by 1 desc "

				SqlDataAdapter adap_3 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsProductInfo.Tables.Clear();
				adap_3.Fill(rsProductInfo);

				double mPurchaseExpRate = 0;
				if (rsProductInfo.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtLastCommanLabel[1].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat);
					if (SystemVariables.gEnableUserLevelCostDetails)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtLastCommanLabel[2].Text = Convert.ToString(rsProductInfo.Tables[0].Rows[0]["ldgr_name"]);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToDouble(rsProductInfo.Tables[0].Rows[0]["expenses"]) > 0 && Convert.ToDouble(rsProductInfo.Tables[0].Rows[0]["qty"]) > 0)
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
							mPurchaseExpRate = (Convert.ToDouble(Convert.ToDouble(rsProductInfo.Tables[0].Rows[0]["lc_amount"]) + Convert.ToDouble(rsProductInfo.Tables[0].Rows[0]["expenses"]))) / ((double) Convert.ToDouble(rsProductInfo.Tables[0].Rows[0]["qty"]));
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							txtLastCommanLabel[3].Text = Conversion.Str(rsProductInfo.Tables[0].Rows[0]["qty"]).Trim() + "  " + Convert.ToString(rsProductInfo.Tables[0].Rows[0]["symbol"]).Trim() + " @ " + Conversion.Str(rsProductInfo.Tables[0].Rows[0]["rate"]).Trim() + " / " + Convert.ToString(rsProductInfo.Tables[0].Rows[0]["symbol"]).Trim() + " (@ " + StringsHelper.Format(mPurchaseExpRate, "###,###,###.###") + " / " + Convert.ToString(rsProductInfo.Tables[0].Rows[0]["symbol"]).Trim() + " with Expenses)";
						}
						else
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							txtLastCommanLabel[3].Text = Conversion.Str(rsProductInfo.Tables[0].Rows[0]["qty"]).Trim() + "  " + Convert.ToString(rsProductInfo.Tables[0].Rows[0]["symbol"]).Trim() + " @ " + Conversion.Str(rsProductInfo.Tables[0].Rows[0]["rate"]).Trim(); // & " / " & Trim(.Fields("symbol"))
						}
					}
					else
					{
						txtLastCommanLabel[3].Text = "";
						txtLastCommanLabel[2].Text = "";
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mPurchaseEntry_id = Convert.ToInt32(rsProductInfo.Tables[0].Rows[0]["Entry_ID"]);
				}
				else
				{
					txtLastCommanLabel[1].Text = "";
					txtLastCommanLabel[2].Text = "";
					txtLastCommanLabel[3].Text = "";
				}
				//Set rsProductInfo = Nothing

				//'retriving ICS_Item last sales information
				//mySql = "select top 1 mt.Entry_ID, mt.voucher_date "
				//mySql = mySql + IIf(gPreferedLanguage = English, " ,ledger.l_ldgr_name as ldgr_name", " , ledger.a_ldgr_name as ldgr_name")
				//mySql = mySql & ", dt.base_qty as qty, ICS_Unit.symbol ,  dt.lc_rate as rate  "
				//mySql = mySql & " from ICS_Transaction_Details dt inner join ICS_Transaction mt on dt.entry_id = mt.entry_id "
				//mySql = mySql & " inner join gl_ledger ledger on mt.ldgr_cd = ledger.ldgr_cd "
				//mySql = mySql & " inner join ICS_Item on dt.prod_cd = ICS_Item.prod_cd "
				//mySql = mySql & " inner join ICS_Unit on ICS_Unit.unit_cd = ICS_Item.base_unit_cd "
				//mySql = mySql & " where mt.voucher_type=201 and dt.prod_cd = " & Str(mProductCode)
				//mySql = mySql & " order by 1 desc "

				//retriving ICS_Item last sales information
				mysql = "select top 1 mt.Entry_ID, mt.voucher_date ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " ,ledger.l_ldgr_name as ldgr_name" : " , ledger.a_ldgr_name as ldgr_name");
				mysql = mysql + ", dt.qty as qty, ICS_Unit.symbol ,  dt.lc_rate as rate  ";
				mysql = mysql + " from ICS_Transaction_Details dt ";
				mysql = mysql + " inner join ICS_Transaction mt on dt.entry_id = mt.entry_id ";
				mysql = mysql + " inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";
				mysql = mysql + " inner join gl_ledger ledger on mt.ldgr_cd = ledger.ldgr_cd ";
				mysql = mysql + " inner join ICS_Item on dt.prod_cd = ICS_Item.prod_cd ";
				mysql = mysql + " inner join ICS_Item_Unit_Details aud on dt.unit_entry_id = aud.unit_entry_id ";
				mysql = mysql + " inner join ICS_Unit on ICS_Unit.unit_cd = aud.alt_unit_cd ";
				mysql = mysql + " where ivt.parent_type=201 and dt.prod_cd = " + Conversion.Str(mProductCode);
				mysql = mysql + " and ivt.document_type in (1,2) ";
				//''modified by Moiz Hakimion 28-feb-2007
				mysql = mysql + " order by 2 desc, 1 desc ";
				//mysql = mysql & " order by 1 desc "

				SqlDataAdapter adap_4 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsProductInfo.Tables.Clear();
				adap_4.Fill(rsProductInfo);

				if (rsProductInfo.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtLastCommanLabel[4].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["voucher_date"], SystemVariables.gSystemDateFormat);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtLastCommanLabel[5].Text = Convert.ToString(rsProductInfo.Tables[0].Rows[0]["ldgr_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtLastCommanLabel[6].Text = Conversion.Str(rsProductInfo.Tables[0].Rows[0]["qty"]).Trim() + "  " + Convert.ToString(rsProductInfo.Tables[0].Rows[0]["symbol"]).Trim() + " @ " + Conversion.Str(rsProductInfo.Tables[0].Rows[0]["rate"]).Trim(); //& " / " & Trim(rsProductInfo.Fields("symbol"))
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mEntry_id = Convert.ToInt32(rsProductInfo.Tables[0].Rows[0]["Entry_ID"]);
				}
				else
				{
					txtLastCommanLabel[4].Text = "";
					txtLastCommanLabel[5].Text = "";
					txtLastCommanLabel[6].Text = "";
				}

				//retriving Total Purchase , Cost, discount, amount, information
				mysql = "SELECT ICS_Item.prod_cd , sum(dt.Base_Qty) As TotalQuantity , ";
				mysql = mysql + " (sum(dt.LC_Amount) /sum(dt.Base_Qty)) as TotalLcPurchaseRate , ";
				mysql = mysql + "sum(dt.LC_Prod_Dis) as TotalDiscount , sum(dt.LC_Amount)  as TotalAmount ";
				mysql = mysql + "From ICS_Transaction_Details dt ";
				mysql = mysql + "inner join ICS_Transaction mt on dt.entry_id = mt.entry_id ";
				mysql = mysql + " inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";
				mysql = mysql + "INNER JOIN ICS_Item ON dt.Prod_Cd = ICS_Item.Prod_Cd ";
				mysql = mysql + "Where ivt.parent_type=103 and ICS_Item.prod_cd = " + Conversion.Str(mProductCode);
				mysql = mysql + " GROUP BY ICS_Item.prod_cd";

				SqlDataAdapter adap_5 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsProductInfo.Tables.Clear();
				adap_5.Fill(rsProductInfo);
				if (rsProductInfo.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[13].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["TotalQuantity"], "###,###,##0.00");
					if (SystemVariables.gEnableUserLevelCostDetails)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommanTextbox[14].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["TotalLcPurchaseRate"], "###,###,##0.000");
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommanTextbox[15].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["TotalDiscount"], "###,###,##0.000");
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommanTextbox[16].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["TotalAmount"], "###,###,##0.000");
					}
					else
					{
						txtCommanTextbox[14].Text = "";
						txtCommanTextbox[15].Text = "";
						txtCommanTextbox[16].Text = "";
					}
				}
				else
				{
					txtCommanTextbox[13].Text = "";
					txtCommanTextbox[14].Text = "";
					txtCommanTextbox[15].Text = "";
					txtCommanTextbox[16].Text = "";
				}
				//Set rsProductInfo = Nothing

				//retriving Total sales , Cost, discount, amount, information
				mysql = "select ICS_Item.prod_cd , sum(dt.base_qty) as totalquantity ,";
				mysql = mysql + " case when sum(dt.base_qty)=0 then 0 else ";
				mysql = mysql + " (sum(dt.lc_amount) / sum(dt.base_qty)) end as totallcsalesrate ,";
				mysql = mysql + " sum(dt.lc_prod_dis) as totaldiscount , ";
				mysql = mysql + " sum(dt.lc_amount)  as totalamount ";
				mysql = mysql + " From ICS_Transaction_Details dt ";
				mysql = mysql + " inner join ICS_Transaction mt on dt.entry_id = mt.entry_id ";
				mysql = mysql + " inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";
				mysql = mysql + " INNER JOIN ICS_Item ON dt.Prod_Cd = ICS_Item.Prod_Cd ";
				mysql = mysql + " Where ivt.parent_type=201 ";
				mysql = mysql + " and ivt.document_type in (1,2) ";
				mysql = mysql + " and ICS_Item.prod_cd = " + Conversion.Str(mProductCode);
				mysql = mysql + " GROUP BY ICS_Item.prod_cd";

				SqlDataAdapter adap_6 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsProductInfo.Tables.Clear();
				adap_6.Fill(rsProductInfo);
				if (rsProductInfo.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[19].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["TotalQuantity"], "###,###,##0.00");
					if (SystemVariables.gEnableUserLevelCostDetails)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommanTextbox[20].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["TotalLcSalesRate"], "###,###,##0.000");
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommanTextbox[21].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["TotalDiscount"], "###,###,##0.000");
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommanTextbox[22].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["TotalAmount"], "###,###,##0.000");
					}
					else
					{
						txtCommanTextbox[20].Text = "";
						txtCommanTextbox[21].Text = "";
						txtCommanTextbox[22].Text = "";
					}
				}
				else
				{
					txtCommanTextbox[19].Text = "";
					txtCommanTextbox[20].Text = "";
					txtCommanTextbox[21].Text = "";
					txtCommanTextbox[22].Text = "";
				}
				//Set rsProductInfo = Nothing

				//---------------
				//retriving Total Purchase Return Quantity
				mysql = "select sum(dt.base_qty) as totalquantity ";
				mysql = mysql + " From ICS_Transaction_Details dt ";
				mysql = mysql + "inner join ICS_Transaction mt on dt.entry_id = mt.entry_id ";
				mysql = mysql + " inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";
				mysql = mysql + "INNER JOIN ICS_Item ON dt.Prod_Cd = ICS_Item.Prod_Cd ";
				mysql = mysql + "Where ivt.parent_type=102 and ICS_Item.prod_cd = " + Conversion.Str(mProductCode);
				mysql = mysql + " GROUP BY ICS_Item.prod_cd ";

				SqlDataAdapter adap_7 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsProductInfo.Tables.Clear();
				adap_7.Fill(rsProductInfo);
				if (rsProductInfo.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[17].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["TotalQuantity"], "###,###,##0.00");
					txtCommanTextbox[18].Text = StringsHelper.Format(Conversion.Val(txtCommanTextbox[13].Text) - Conversion.Val(txtCommanTextbox[17].Text), "###,###,##0.00");
				}
				else
				{
					txtCommanTextbox[17].Text = "";
					txtCommanTextbox[18].Text = StringsHelper.Format(Conversion.Val(txtCommanTextbox[13].Text), "###,###,##0.00");
				}
				//Set rsProductInfo = Nothing

				//retriving Total Sales Return Quantity
				mysql = "select sum(dt.base_qty) as totalquantity ";
				mysql = mysql + " From ICS_Transaction_Details dt ";
				mysql = mysql + "inner join ICS_Transaction mt on dt.entry_id = mt.entry_id ";
				mysql = mysql + " inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";
				mysql = mysql + "INNER JOIN ICS_Item ON dt.Prod_Cd = ICS_Item.Prod_Cd ";
				mysql = mysql + "Where ivt.parent_type=202 and ICS_Item.prod_cd = " + Conversion.Str(mProductCode);
				mysql = mysql + " GROUP BY ICS_Item.prod_cd";

				SqlDataAdapter adap_8 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsProductInfo.Tables.Clear();
				adap_8.Fill(rsProductInfo);
				if (rsProductInfo.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommanTextbox[23].Text = StringsHelper.Format(rsProductInfo.Tables[0].Rows[0]["TotalQuantity"], "###,###,##0.00");
					txtCommanTextbox[24].Text = StringsHelper.Format(Conversion.Val(txtCommanTextbox[19].Text) - Conversion.Val(txtCommanTextbox[23].Text), "###,###,##0.00");
				}
				else
				{
					txtCommanTextbox[23].Text = "";
					txtCommanTextbox[24].Text = StringsHelper.Format(Conversion.Val(txtCommanTextbox[19].Text), "###,###,##0.00");
				}
				//Set rsProductInfo = Nothing


				//Location Value in Grid
				mysql = "select round((pld.Stock_In_Hand / iu.Base_Qty), 2) as Stock_In_Hand, round((pld.Stock_Allocated / iu.Base_Qty), 2) as Stock_Allocated, ";
				mysql = mysql + " round((pld.Stock_Available / iu.Base_Qty), 2) as Stock_Available , round((pld.Stock_In_Transit / iu.Base_Qty),2) as Stock_In_Transit, ";
				mysql = mysql + " round((pld.Stock_On_Order_of_sales / iu.Base_Qty), 2) as Stock_On_Order_of_sales , ";
				mysql = mysql + " pld.Bin_Location, round((pld.Stock_Reserved / iu.Base_Qty),2) as Stock_Reserved, ";
				mysql = mysql + " round((pld.Stock_Return_In_Transit / iu.Base_Qty), 2) as Stock_Return_In_Transit , ";
				mysql = mysql + " round((pld.Stock_Booked / iu.Base_Qty), 2) as Stock_Booked, ";
				mysql = mysql + " pld.MTD_Usage, pld.YTD_Usage ,pld.physical_location ,";
				mysql = mysql + " SM_Location.locat_no,  SM_Location.locat_cd, ";
				mysql = mysql + "  u.symbol ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " ,u.symbol" : " , u.A_symbol") + " as symbol";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " ,SM_Location.l_locat_name as locat_name" : " , SM_Location.a_locat_name as locat_name");
				mysql = mysql + " from ICS_Item_location_details pld inner join SM_Location on ";
				mysql = mysql + " pld.locat_cd = SM_Location.locat_cd ";
				mysql = mysql + " inner join ICS_Item i on pld.prod_cd = i.prod_cd";
				mysql = mysql + " inner join ICS_Item_Unit_Details iu on  i.report_unit_cd = iu.Alt_Unit_Cd and i.prod_cd = iu.prod_cd ";
				mysql = mysql + " inner join ICS_Unit u on  i.report_unit_cd = u.unit_cd ";
				mysql = mysql + " where pld.prod_cd = " + Conversion.Str(mProductCode);

				ChartControl.Content.Series[0].Points.DeleteAll();
				ChartControl.Content.Series[1].Points.DeleteAll();
				ChartControl.Content.Series[2].Points.DeleteAll();
				ChartControl.Content.Series[3].Points.DeleteAll();

				int Cnt = 0;
				XtremeChartControl.ChartSeriesPoint pPoint = null;
				SqlDataAdapter adap_9 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsProductInfo.Tables.Clear();
				adap_9.Fill(rsProductInfo);
				if (rsProductInfo.Tables[0].Rows.Count != 0)
				{
					Cnt = 0;
					foreach (DataRow iteration_row in rsProductInfo.Tables[0].Rows)
					{
						aLocationDetails.RedimXArray(new int[]{Cnt, mTotalGridColumns}, new int[]{0, 0});
						aLocationDetails.SetValue(iteration_row["locat_no"], Cnt, mLocationNoColumns);
						aLocationDetails.SetValue(iteration_row["locat_name"], Cnt, mLocationNameColumns);
						aLocationDetails.SetValue(iteration_row["Bin_Location"], Cnt, mBinLocationColumns);
						aLocationDetails.SetValue(iteration_row["stock_in_hand"], Cnt, mStockInHandColumns);
						aLocationDetails.SetValue(iteration_row["stock_allocated"], Cnt, mStockAllocatedColumns);
						aLocationDetails.SetValue(iteration_row["stock_available"], Cnt, mStockAvailableColumns);
						aLocationDetails.SetValue(iteration_row["Stock_In_Transit"], Cnt, mStockInTransitColumns);
						aLocationDetails.SetValue(iteration_row["Stock_On_Order_of_sales"], Cnt, mStockOnOrderOfSalesColumns);
						aLocationDetails.SetValue(iteration_row["Stock_Reserved"], Cnt, mStockReservedColumns);
						aLocationDetails.SetValue(iteration_row["Stock_Return_In_Transit"], Cnt, mStockReturnInTransitColumns);
						aLocationDetails.SetValue(iteration_row["Stock_Booked"], Cnt, mStockBookedColumns);
						aLocationDetails.SetValue(iteration_row["MTD_Usage"], Cnt, mStockMTDUsageColumns);
						aLocationDetails.SetValue(iteration_row["YTD_Usage"], Cnt, mStockYTDUsageColumns);
						aLocationDetails.SetValue(iteration_row["physical_location"], Cnt, mStockPhysicalLocationColumns);
						aLocationDetails.SetValue(iteration_row["locat_cd"], Cnt, mLocationCodeColumn);


						pPoint = Series.Points.Add(iteration_row["locat_name"], iteration_row["stock_in_hand"]);
						pPoint.LegendText = Convert.ToString(iteration_row["locat_cd"]);
						pPoint.LabelText = Convert.ToString(iteration_row["Symbol"]) + " " + Convert.ToString(iteration_row["stock_in_hand"]);

						pPoint = Series1.Points.Add(iteration_row["locat_name"], iteration_row["stock_allocated"]);
						pPoint.LegendText = Convert.ToString(iteration_row["locat_cd"]);
						pPoint.LabelText = Convert.ToString(iteration_row["Symbol"]) + " " + Convert.ToString(iteration_row["stock_allocated"]);

						pPoint = Series2.Points.Add(iteration_row["locat_name"], iteration_row["stock_available"]);
						pPoint.LegendText = Convert.ToString(iteration_row["locat_cd"]);
						pPoint.LabelText = Convert.ToString(iteration_row["Symbol"]) + " " + Convert.ToString(iteration_row["stock_available"]);

						pPoint = Series3.Points.Add(iteration_row["locat_name"], iteration_row["Stock_In_Transit"]);
						pPoint.LegendText = Convert.ToString(iteration_row["locat_cd"]);
						pPoint.LabelText = Convert.ToString(iteration_row["Symbol"]) + " " + Convert.ToString(iteration_row["Stock_In_Transit"]);

						Cnt++;
					}
				}
				else
				{
					//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aLocationDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					aLocationDetails.Clear();
				}
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdLocationDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdLocationDetails.setArray(aLocationDetails);
				grdLocationDetails.Rebind(true);
				mtotalLocation = Cnt;




				//grdLocationDetails.SetFocus
				rsProductInfo = null;

				CalculateTotals();
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
			}
		}

		public void CreateBubblePoint(XtremeChartControl.ChartSeriesPointCollection pPointCollection, string lpszLegendText, int nYear, int nValue, double dWidth)
		{
			XtremeChartControl.ChartSeriesPoint pPoint = pPointCollection.Add2(nYear, nValue, dWidth);
			pPoint.LegendText = lpszLegendText;
		}

		public void RRoutine()
		{
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdLocationDetails.Bookmark))
			{
				DoReportDrillDown(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdLocationDetails.Bookmark))));
			}
		}


		private void CalculateTotals()
		{
			//Private Sub CalculateTotals(ByVal mRowNumber As Long, ByVal mColNumber As Long)


			int Cnt = 0;
			double mTotStockInHandColumns = 0;
			double mTotStockAllocatedColumns = 0;
			double mTotStockAvailableColumns = 0;
			double mTotStockInTransitColumns = 0;
			double mTotStockOnOrderColumns = 0;
			double mTotStockReservedColumns = 0;
			double mTotStockReturnInTransitColumns = 0;
			double mTotStockBookedColumns = 0;

			int tempForEndVar = mtotalLocation - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				mTotStockInHandColumns += Convert.ToDouble(aLocationDetails.GetValue(Cnt, 3));
				mTotStockAllocatedColumns += Convert.ToDouble(aLocationDetails.GetValue(Cnt, 4));
				mTotStockAvailableColumns += Convert.ToDouble(aLocationDetails.GetValue(Cnt, 5));
				mTotStockInTransitColumns += Convert.ToDouble(aLocationDetails.GetValue(Cnt, 6));
				mTotStockOnOrderColumns += Convert.ToDouble(aLocationDetails.GetValue(Cnt, 7));
				mTotStockReservedColumns += Convert.ToDouble(aLocationDetails.GetValue(Cnt, 8));
				mTotStockReturnInTransitColumns += Convert.ToDouble(aLocationDetails.GetValue(Cnt, 9));
				mTotStockBookedColumns += Convert.ToDouble(aLocationDetails.GetValue(Cnt, 10));

			}

			grdLocationDetails.Columns[3].FooterText = StringsHelper.Format(mTotStockInHandColumns, "##,##,##0.0");
			grdLocationDetails.Columns[4].FooterText = StringsHelper.Format(mTotStockAllocatedColumns, "##,##,##0.0");
			grdLocationDetails.Columns[5].FooterText = StringsHelper.Format(mTotStockAvailableColumns, "##,##,##0.0");
			grdLocationDetails.Columns[6].FooterText = StringsHelper.Format(mTotStockInTransitColumns, "##,##,##0.0");
			grdLocationDetails.Columns[7].FooterText = StringsHelper.Format(mTotStockOnOrderColumns, "##,##,##0.0");
			grdLocationDetails.Columns[8].FooterText = StringsHelper.Format(mTotStockReservedColumns, "##,##,##0.0");
			grdLocationDetails.Columns[9].FooterText = StringsHelper.Format(mTotStockReturnInTransitColumns, "##,##,##0.0");
			grdLocationDetails.Columns[10].FooterText = StringsHelper.Format(mTotStockBookedColumns, "##,##,##0.0");



		}

		public void ORoutine()
		{


			if (SystemProcedure2.IsItEmpty(txtPartNo.Text, SystemVariables.DataType.StringType))
			{
				return;
			}

			string mysql = " select top 1 min(part_no) from ICS_Item ";
			mysql = mysql + " where part_no > '" + txtPartNo.Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtPartNo.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				GetProductInfo(txtPartNo.Text);
			}

		}

		public void MRoutine()
		{

			if (SystemProcedure2.IsItEmpty(txtPartNo.Text, SystemVariables.DataType.StringType))
			{
				return;
			}

			string mysql = " select top 1 max(part_no) from ICS_Item ";
			mysql = mysql + " where part_no < '" + txtPartNo.Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtPartNo.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				GetProductInfo(txtPartNo.Text);
			}
		}

		private void ShowPicture(string pPictureName)
		{

			if (pPictureName != "")
			{
				imgPicture.Image = Image.FromFile(SystemVariables.gProductPicturesPath + pPictureName);
				ToolTipMain.SetToolTip(imgPicture, pPictureName);
			}
			else
			{
				imgPicture.Image = null;
				ToolTipMain.SetToolTip(imgPicture, "");
			}
			//If TypeName(clsItemDisplay) = "Nothing" Then
			//    Set clsItemDisplay = New clsPictureDisplay
			//End If
			//clsItemDisplay.PictureName = pPictureName
			//clsItemDisplay.Show
		}


		private void ShowProductAssemblyDetails(string pPartNo)
		{
			Form oFormName = null;

			string mysql = " select top 1 ati.entry_id ";
			mysql = mysql + " from ICS_Transaction_Details dt ";
			mysql = mysql + " inner join ICS_Transaction mt on mt.entry_id =dt.entry_id ";
			mysql = mysql + " inner join ICS_Item prod on dt.prod_cd = prod.prod_cd ";
			mysql = mysql + " inner join SM_Location locat on mt.locat_cd = locat.locat_cd ";
			mysql = mysql + " inner join ICS_Transaction_Assembly ati on mt.entry_id = ati.assembly_trans_entry_id ";
			mysql = mysql + " where trans_type = 1 ";
			mysql = mysql + " and prod.part_no ='" + pPartNo + "'";
			mysql = mysql + " order by ati.entry_id desc ";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				oFormName = frmICSBuildStock.CreateInstance();
				ReflectionHelper.LetMember(oFormName, "ThisVoucherType", SystemICSConstants.icsBuildAssemblyProduct);
				ReflectionHelper.LetMember(oFormName, "ThisFormId", 577000);
				ReflectionHelper.Invoke(ReflectionHelper.GetMember(oFormName, "UserAccess"), "CheckAccess", new object[]{577000, SystemVariables.SystemObjectTypes.objForm});
				//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//VB.Global.Load(oFormName);
				ReflectionHelper.Invoke(oFormName, "GetRecord", new object[]{mReturnValue});
				oFormName.Show();

				//UPGRADE_NOTE: (1029) Object oFormName may not be destroyed until it is garbage collected. More Information: https://docs.mobilize.net/vbuc/ewis#1029
				oFormName = null;
			}

		}


		public void findRecord()
		{
			FindRoutine();
		}
	}
}