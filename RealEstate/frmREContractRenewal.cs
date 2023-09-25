
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers;



namespace Xtreme
{
	internal partial class frmREContractRenewal
		: System.Windows.Forms.Form
	{

		public frmREContractRenewal()
{
InitializeComponent();
} 
 public  void frmREContractRenewal_old()
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
			this._grdCommon_0.setScrollTips(false);
			this._grdCommon_1.setScrollTips(false);
		}


		private void frmREContractRenewal_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		public Control FirstFocusObject = null;
		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private bool mContractLoaded = false;
		private XArrayHelper aContractTimeStamps = null;

		private const int conContractMaster = 0;
		private const int conContractDetails = 1;

		private const int conContractNoColumn = 0;
		private const int conTenantNoColumn = 1;
		private const int conTenantNameColumn = 2;
		private const int conPropertyNameColumn = 3;
		private const int conStartingDateColumn = 4;
		private const int conEndingDateColumn = 5;
		private const int conReferenceNoColumn = 6;
		private const int conRenewColumn = 7;

		private const int conItemNoColumn = 0;
		private const int conItemNameColumn = 1;
		private const int conUnitNoColumn = 2;
		private const int conUnitAmountColumn = 3;
		private const int conRemarksColumn = 4;

		private const int clContractDetailsInfo = 0;
		private const int clContractMasterInfo = 1;

		private const int mFixedHeaderBackColor = 0xB7A088;
		private const int mResultGridHighlightColor = 0xB0C0F9;


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


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				this.Top = 0;
				this.Left = 0;
				mContractLoaded = false;
				FirstFocusObject = grdCommon[conContractMaster];
				aContractTimeStamps = new XArrayHelper();

				FormatContractGrids();
				GetExpiredContracts();
				mContractLoaded = true;

				SystemProcedure.SetLabelCaption(this);
				this.WindowState = FormWindowState.Maximized;

				Application.DoEvents();
				if (grdCommon[conContractMaster].Rows.Count > 1)
				{
					grdCommon[conContractMaster].Select(1, conRenewColumn, 1, conRenewColumn);
				}
				else
				{
					GetExpiredContractDetails(0);
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//**--to display the HourGlass
				clsHourGlass clsHour = new clsHourGlass();

				if (KeyCode == ((int) Keys.Return))
				{
					SendKeys.Send("{TAB}");
					return;
				}
				else if (KeyCode == ((int) Keys.F5))
				{ 
					mContractLoaded = false;
					GetExpiredContracts();
					mContractLoaded = true;
					if (grdCommon[conContractMaster].Rows.Count > 1)
					{
						grdCommon[conContractMaster].Select(1, conRenewColumn, 1, conRenewColumn);
						grdCommon[conContractMaster].Focus();
					}
					else
					{
						GetExpiredContractDetails(0);
					}
					return;
				}

				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
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

				UserAccess = null;
				frmREContractRenewal.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool CheckDataValidity()
		{
			bool result = false;
			//**--to display the HourGlass
			clsHourGlass clsHour = new clsHourGlass();

			return result;
		}

		public bool saveRecord()
		{
			return false;


			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			return false;
		}

		private void FormatContractGrids()
		{
			int cnt = 0;
			//**--to display the HourGlass
			clsHourGlass clsHour = new clsHourGlass();

			for (cnt = 0; cnt <= 1; cnt++)
			{
				grdCommon[cnt].Rows.Count = 1;
				grdCommon[cnt].Cols.Count = 0;
				grdCommon[cnt].Clear(C1.Win.C1FlexGrid.ClearFlags.All, grdCommon[cnt].GetCellRange(grdCommon[cnt].BottomRow, grdCommon[cnt].LeftCol, grdCommon[cnt].TopRow, grdCommon[cnt].RightCol));
				//**------------------------
				grdCommon[cnt].Styles.Highlight.BackColor = ColorTranslator.FromOle(mResultGridHighlightColor);
				grdCommon[cnt].Styles.Highlight.ForeColor = Color.Black;
				//**------------------------
				grdCommon[cnt].SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
				grdCommon[cnt].AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
				grdCommon[cnt].AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
				grdCommon[cnt].BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
				grdCommon[cnt].AutoResize = true;
				grdCommon[cnt].AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
				grdCommon[cnt].AutoSearchDelay = 5;
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdCommon.AutoSizeMouse was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdCommon[cnt].setAutoSizeMouse(true);
				grdCommon[cnt].BackColor = Color.White;
				grdCommon[cnt].Styles.Alternate.BackColor = Color.White;
				grdCommon[cnt].Styles.EmptyArea.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(SystemConstants.gDisableColumnBackColor)));
				grdCommon[cnt].Styles.Fixed.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(SystemConstants.gDisableColumnBackColor)));
				grdCommon[cnt].Styles.Frozen.BackColor = Color.White;
				grdCommon[cnt].BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
				grdCommon[cnt].AllowEditing = cnt == conContractMaster;
				grdCommon[cnt].ExtendLastCol = true;
				grdCommon[cnt].ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
				grdCommon[cnt].AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
				grdCommon[cnt].AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
				//UPGRADE_ISSUE: (2064) VSFlex8L.FillStyleSettings property FillStyleSettings.flexFillSingle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdCommon.FillStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdCommon[cnt].setFillStyle(UpgradeStubs.VSFlex8L_FillStyleSettings.getflexFillSingle());
				grdCommon[cnt].Rows.Fixed = 1;
				grdCommon[cnt].FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
				grdCommon[cnt].ForeColor = Color.FromArgb(0, 0, 0);
				grdCommon[cnt].Styles.Fixed.ForeColor = Color.FromArgb(0, 0, 0);
				grdCommon[cnt].Styles.Frozen.ForeColor = Color.FromArgb(0, 0, 0);
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdCommon.FontSize was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdCommon[cnt].setFontSize(8);
				grdCommon[cnt].Styles.Normal.Border.Color = Color.FromArgb(0, 0, 0);
				grdCommon[cnt].Styles.Fixed.Border.Color = Color.FromArgb(0, 0, 0);
				grdCommon[cnt].Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
				grdCommon[cnt].Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
				grdCommon[cnt].Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
				grdCommon[cnt].Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
				grdCommon[cnt].HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
				grdCommon[cnt].Rows.MinSize = 19;
				grdCommon[cnt].ScrollBars = ScrollBars.Both;
				grdCommon[cnt].setScrollTips(false);
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdCommon.ScrollTrack was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdCommon[cnt].setScrollTrack(true);
				grdCommon[cnt].SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
				grdCommon[cnt].Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = Color.FromArgb(0, 0, 0);
				grdCommon[cnt].KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
				grdCommon[cnt].Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
				grdCommon[cnt].Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdCommon.FontName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdCommon[cnt].setFontName("Arial");
					grdCommon[cnt].RightToLeft = RightToLeft.No;
				}
				else
				{
					//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdCommon.FontName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdCommon[cnt].setFontName(SystemConstants.gArabicFontName);
					grdCommon[cnt].RightToLeft = RightToLeft.Yes;
				}
				grdCommon[cnt].Rows[0].HeightDisplay = 22;
			}
		}

		private void GetExpiredContracts()
		{
			DataSet rsTempRec = null;
			string mySQL = "";
			//**--to display the HourGlass
			clsHourGlass clsHour = new clsHourGlass();

			try
			{

				mySQL = "select c.contract_no [Contract No], t.tenant_no [Tenant Code]";
				mySQL = mySQL + ", " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "t.l_tenant_name" : "t.a_tenant_name");
				mySQL = mySQL + " as [Tenant Name] ";
				mySQL = mySQL + ", " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "p.l_property_name" : "p.a_property_name");
				mySQL = mySQL + " as [Property Name] ";
				mySQL = mySQL + ", c.starting_date [Starting Date], c.ending_date [Ending Date] ";
				mySQL = mySQL + ", c.reference_no [Reference No], cast(0 as bit) [Renew], c.time_stamp ";
				mySQL = mySQL + " from re_contract c ";
				mySQL = mySQL + " inner join re_tenant t on c.tenant_cd = t.tenant_cd ";
				mySQL = mySQL + " inner join re_payment_method pm ";
				mySQL = mySQL + " on c.payment_method_cd = pm.payment_method_cd ";
				mySQL = mySQL + " inner join re_contract_status cs ";
				mySQL = mySQL + " on c.contract_status_cd = cs.contract_status_cd ";
				mySQL = mySQL + " inner join re_property p on c.property_cd = p.property_cd ";
				mySQL = mySQL + " where c.status = 2 "; //**--posted contracts only
				mySQL = mySQL + " and c.contract_status_cd = 1 "; //**--active contracts only
				mySQL = mySQL + " and c.ending_date <= '" + StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(SystemREProcedure.GetRELastMonthEndDate()), SystemVariables.gSystemDateFormat) + "'";

				rsTempRec = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsTempRec.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempRec.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mySQL, SystemVariables.gConn);
				rsTempRec.Tables.Clear();
				adap.Fill(rsTempRec);

				aContractTimeStamps.RedimXArray(new int[]{-1, -1}, new int[]{-1, -1});
				if (rsTempRec.Tables[0].Rows.Count > 0)
				{
					//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aContractTimeStamps.LoadRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					aContractTimeStamps.LoadRows((object[, ]) rsTempRec.GetRows(-1, null, "time_stamp"), true);
				}
				lblCommon[clContractMasterInfo].Caption = Convert.ToString(lblCommon[clContractMasterInfo].Tag) + " (Total " + rsTempRec.Tables[0].Rows.Count.ToString().Trim() + " Items)";

				grdCommon[conContractMaster].Rows.Count = 1;
				grdCommon[conContractMaster].Cols.Count = 0;
				grdCommon[conContractMaster].Clear(C1.Win.C1FlexGrid.ClearFlags.All, grdCommon[conContractMaster].GetCellRange(grdCommon[conContractMaster].BottomRow, grdCommon[conContractMaster].LeftCol, grdCommon[conContractMaster].TopRow, grdCommon[conContractMaster].RightCol));
				//UPGRADE_ISSUE: (2064) VSFlex8L.DataModeSettings property DataModeSettings.flexDMFree was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdCommon.DataMode was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdCommon[conContractMaster].setDataMode(UpgradeStubs.VSFlex8L_DataModeSettings.getflexDMFree());
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdCommon[conContractMaster].setDataSource(null);
				Application.DoEvents();
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdCommon[conContractMaster].setDataSource((msdatasrc.DataSource) rsTempRec);
				grdCommon[conContractMaster].Cols.Fixed = 7;

				grdCommon[conContractMaster].Cols[conContractNoColumn].WidthDisplay = 67;
				grdCommon[conContractMaster].setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter, 0, conContractNoColumn, grdCommon[conContractMaster].Rows.Count - 1, conContractNoColumn);

				grdCommon[conContractMaster].Cols[conTenantNoColumn].WidthDisplay = 67;
				grdCommon[conContractMaster].setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter, 0, conTenantNoColumn, grdCommon[conContractMaster].Rows.Count - 1, conTenantNoColumn);

				grdCommon[conContractMaster].Cols[conTenantNameColumn].WidthDisplay = 133;
				grdCommon[conContractMaster].setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter, 0, conTenantNameColumn, grdCommon[conContractMaster].Rows.Count - 1, conTenantNameColumn);

				grdCommon[conContractMaster].Cols[conPropertyNameColumn].WidthDisplay = 107;
				grdCommon[conContractMaster].setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter, 0, conPropertyNameColumn, grdCommon[conContractMaster].Rows.Count - 1, conPropertyNameColumn);

				grdCommon[conContractMaster].Cols[conStartingDateColumn].WidthDisplay = 73;
				grdCommon[conContractMaster].setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter, 0, conStartingDateColumn, grdCommon[conContractMaster].Rows.Count - 1, conStartingDateColumn);

				grdCommon[conContractMaster].Cols[conEndingDateColumn].WidthDisplay = 73;
				grdCommon[conContractMaster].setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter, 0, conEndingDateColumn, grdCommon[conContractMaster].Rows.Count - 1, conEndingDateColumn);

				grdCommon[conContractMaster].Cols[conReferenceNoColumn].WidthDisplay = 73;
				grdCommon[conContractMaster].setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter, 0, conReferenceNoColumn, grdCommon[conContractMaster].Rows.Count - 1, conReferenceNoColumn);

				grdCommon[conContractMaster].Cols[conRenewColumn].WidthDisplay = 67;
				grdCommon[conContractMaster].setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter, 0, conRenewColumn, grdCommon[conContractMaster].Rows.Count - 1, conRenewColumn);

				grdCommon[conContractMaster].setCellBackColor(ColorTranslator.FromOle(mFixedHeaderBackColor), 0, 0, 0, grdCommon[conContractMaster].Cols.Count - 1);
				rsTempRec = null;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}
		}

		private void GetExpiredContractDetails(int pContractNo)
		{
			DataSet rsTempRec = null;
			string mySQL = "";
			//**--to display the HourGlass
			clsHourGlass clsHour = new clsHourGlass();

			try
			{

				mySQL = " select pi.item_no [Item Code]";
				mySQL = mySQL + ", " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pi.l_item_name" : "pi.a_item_name");
				mySQL = mySQL + " as [Item Name] ";
				mySQL = mySQL + ", piud.unit_no [Unit Code], cd.amount [Unit Amount]";
				mySQL = mySQL + ", cd.remarks [Comments] ";
				mySQL = mySQL + " from  re_contract_details cd ";
				mySQL = mySQL + " inner join re_contract c on cd.contract_cd = c.contract_cd";
				mySQL = mySQL + " inner join re_property_item_unit_details piud";
				mySQL = mySQL + " on cd.unit_cd = piud.unit_cd";
				mySQL = mySQL + " inner join re_property_items pi on piud.item_cd = pi.item_cd";
				if (mContractLoaded)
				{
					mySQL = mySQL + " where c.contract_no = " + pContractNo.ToString();
				}
				else
				{
					mySQL = mySQL + " where c.contract_no = 0";
				}

				rsTempRec = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsTempRec.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempRec.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mySQL, SystemVariables.gConn);
				rsTempRec.Tables.Clear();
				adap.Fill(rsTempRec);

				lblCommon[clContractDetailsInfo].Caption = Convert.ToString(lblCommon[clContractDetailsInfo].Tag) + " (Total " + rsTempRec.Tables[0].Rows.Count.ToString().Trim() + " Items)";

				grdCommon[conContractDetails].Rows.Count = 1;
				grdCommon[conContractDetails].Cols.Count = 0;
				grdCommon[conContractDetails].Clear(C1.Win.C1FlexGrid.ClearFlags.All, grdCommon[conContractDetails].GetCellRange(grdCommon[conContractDetails].BottomRow, grdCommon[conContractDetails].LeftCol, grdCommon[conContractDetails].TopRow, grdCommon[conContractDetails].RightCol));
				//UPGRADE_ISSUE: (2064) VSFlex8L.DataModeSettings property DataModeSettings.flexDMFree was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdCommon.DataMode was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdCommon[conContractDetails].setDataMode(UpgradeStubs.VSFlex8L_DataModeSettings.getflexDMFree());
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdCommon[conContractDetails].setDataSource(null);
				Application.DoEvents();
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdCommon[conContractDetails].setDataSource((msdatasrc.DataSource) rsTempRec);
				grdCommon[conContractDetails].Cols.Fixed = grdCommon[conContractDetails].Cols.Count;

				grdCommon[conContractDetails].Cols[conItemNoColumn].WidthDisplay = 67;
				grdCommon[conContractDetails].setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter, 0, conItemNoColumn, grdCommon[conContractDetails].Rows.Count - 1, conItemNoColumn);

				grdCommon[conContractDetails].Cols[conItemNameColumn].WidthDisplay = 147;
				grdCommon[conContractDetails].setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter, 0, conItemNameColumn, grdCommon[conContractDetails].Rows.Count - 1, conItemNameColumn);

				grdCommon[conContractDetails].Cols[conUnitNoColumn].WidthDisplay = 107;
				grdCommon[conContractDetails].setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter, 0, conUnitNoColumn, grdCommon[conContractDetails].Rows.Count - 1, conUnitNoColumn);

				grdCommon[conContractDetails].Cols[conUnitAmountColumn].WidthDisplay = 107;
				grdCommon[conContractDetails].setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.RightCenter, 0, conUnitAmountColumn, grdCommon[conContractDetails].Rows.Count - 1, conUnitAmountColumn);
				grdCommon[conContractDetails].Cols[conUnitAmountColumn].Format = "###,###,##0.000";

				grdCommon[conContractDetails].Cols[conRemarksColumn].WidthDisplay = 107;
				grdCommon[conContractDetails].setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter, 0, conRemarksColumn, grdCommon[conContractDetails].Rows.Count - 1, conRemarksColumn);

				grdCommon[conContractDetails].setCellBackColor(ColorTranslator.FromOle(mFixedHeaderBackColor), 0, 0, 0, grdCommon[conContractDetails].Cols.Count - 1);
				rsTempRec = null;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}
		}

		private void grdCommon_RowColChange(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.grdCommon, eventSender);
			if (mContractLoaded)
			{
				if (Index == conContractMaster)
				{
					GetExpiredContractDetails(Convert.ToInt32(Double.Parse(Convert.ToString(grdCommon[conContractMaster][Convert.ToInt32(Conversion.Val(grdCommon[conContractMaster].Row.ToString())), conContractNoColumn]))));
				}
			}
		}

		private void cmdOkCancel_CancelClick(Object Sender, EventArgs e)
		{
			CloseForm();
		}

		private void cmdOkCancel_OKClick(Object Sender, EventArgs e)
		{
			DataSet rsCheckTimeStamp = null;
			string mCheckTimeStamp = "";
			int cnt = 0;
			string mTimeStamp = "";
			int mRenewContractCode = 0;
			object mTempValue = null;
			int mTotalRenewedContracts = 0;
			bool mPostToGLOnTransactionPosting = false;

			//**--to display the HourGlass
			clsHourGlass clsHour = new clsHourGlass();

			try
			{

				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mPostToGLOnTransactionPosting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("post_to_gl_on_transaction_posting"));

				if (grdCommon[conContractMaster].Rows.Count <= 1)
				{
					return;
				}

				SystemVariables.gConn.BeginTransaction();
				mTotalRenewedContracts = 0;
				int tempForEndVar = grdCommon[conContractMaster].Rows.Count - 1;
				for (cnt = 1; cnt <= tempForEndVar; cnt++)
				{
					if (Convert.ToString(grdCommon[conContractMaster][cnt, conRenewColumn]) == ((int) TriState.True).ToString())
					{
						mTimeStamp = Convert.ToString(aContractTimeStamps.GetValue(cnt - 1, 0));
						//**-- check whether the row is in the same status when it was retreived
						//**-- from the table for updation
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = "select time_stamp from re_contract where contract_no = " + Convert.ToString(grdCommon[conContractMaster][Convert.ToInt32(Conversion.Val(cnt.ToString())), conContractNoColumn]);
						SqlDataAdapter TempAdapter = null;
						TempAdapter = new SqlDataAdapter();
						TempAdapter.SelectCommand = TempCommand;
						DataSet TempDataset = null;
						TempDataset = new DataSet();
						TempAdapter.Fill(TempDataset);
						rsCheckTimeStamp = TempDataset;
						if (rsCheckTimeStamp.Tables[0].Rows.Count != 0)
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mCheckTimeStamp = Convert.ToString(rsCheckTimeStamp.Tables[0].Rows[0][0]);
						}
						if ((rsCheckTimeStamp.Tables[0].Rows.Count == 0) || (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp)))
						{
							rsCheckTimeStamp = null;
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							FirstFocusObject.Focus();
							return;
						}
						rsCheckTimeStamp = null;
						//**-------------------------------------------------------------------------------
						//UPGRADE_WARNING: (1068) GetRELastMonthEndDate() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemREProcedure.GetRELastMonthEndDate());
						if (SystemProcedure2.IsItEmpty(mTempValue, SystemVariables.DataType.DateType))
						{
							MessageBox.Show("Error: No Month End Generate History Found. Contact Your Systems Administrator", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							throw new Exception();
						}

						mRenewContractCode = Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select contract_cd from re_contract where contract_no = " + Convert.ToString(grdCommon[conContractMaster][Convert.ToInt32(Conversion.Val(cnt.ToString())), conContractNoColumn])))));
						if (SystemREProcedure.RenewContract(mRenewContractCode, ReflectionHelper.GetPrimitiveValue<System.DateTime>(mTempValue)))
						{
							mTotalRenewedContracts++;

							//**--check if the transaction should be posted to gl after approval
							if (mPostToGLOnTransactionPosting)
							{
								if (!SystemREProcedure.PostREChargesToGL(ReflectionHelper.GetPrimitiveValue<System.DateTime>(mTempValue), mRenewContractCode, 1))
								{
									throw new Exception();
								}
							}
						}
						else
						{
							throw new Exception();
						}
					}
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				MessageBox.Show("Total " + Conversion.Str(mTotalRenewedContracts).Trim() + " contract(s) renewed successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (!SystemVariables.gXtremeAdminLoggedIn)
				{
					CloseForm();
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				FirstFocusObject.Focus();
			}
		}

		private void cmdSelectContract_OKClick(Object Sender, EventArgs e)
		{
			int cnt = 0;
			//**--to display the HourGlass
			clsHourGlass clsHour = new clsHourGlass();

			if (grdCommon[conContractMaster].Rows.Count > 1)
			{
				grdCommon[conContractMaster].setRedraw(UpgradeHelpers.VSFlexGridExtensions.RedrawSettings.flexRDNone);
				int tempForEndVar = grdCommon[conContractMaster].Rows.Count - 1;
				for (cnt = grdCommon[conContractMaster].Rows.Fixed; cnt <= tempForEndVar; cnt++)
				{
					grdCommon[conContractMaster][cnt, conRenewColumn] = ((int) TriState.True).ToString();
				}
				grdCommon[conContractMaster].setRedraw(UpgradeHelpers.VSFlexGridExtensions.RedrawSettings.flexRDDirect);
				grdCommon[conContractMaster].Select(1, conRenewColumn, 1, conRenewColumn);
				grdCommon[conContractMaster].Focus();
			}
		}

		private void cmdSelectContract_CancelClick(Object Sender, EventArgs e)
		{
			int cnt = 0;
			//**--to display the HourGlass
			clsHourGlass clsHour = new clsHourGlass();

			if (grdCommon[conContractMaster].Rows.Count > 1)
			{
				grdCommon[conContractMaster].setRedraw(UpgradeHelpers.VSFlexGridExtensions.RedrawSettings.flexRDNone);
				int tempForEndVar = grdCommon[conContractMaster].Rows.Count - 1;
				for (cnt = grdCommon[conContractMaster].Rows.Fixed; cnt <= tempForEndVar; cnt++)
				{
					grdCommon[conContractMaster][cnt, conRenewColumn] = ((int) TriState.False).ToString();
				}
				grdCommon[conContractMaster].setRedraw(UpgradeHelpers.VSFlexGridExtensions.RedrawSettings.flexRDDirect);
				grdCommon[conContractMaster].Select(1, conRenewColumn, 1, conRenewColumn);
				grdCommon[conContractMaster].Focus();
			}
		}
	}
}