
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmICSPrintReportFormat
		: System.Windows.Forms.Form
	{

		public frmICSPrintReportFormat()
{
InitializeComponent();
} 
 public  void frmICSPrintReportFormat_old()
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


		private void frmICSPrintReportFormat_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		public int mEntryId = 0;
		public string mFormId = "";
		public int mVoucherType = 0;

		private XArrayHelper _aVoucherDetails = null;
		public XArrayHelper aVoucherDetails
		{
			get
			{
				if (_aVoucherDetails is null)
				{
					_aVoucherDetails = new XArrayHelper();
				}
				return _aVoucherDetails;
			}
			set
			{
				_aVoucherDetails = value;
			}
		}


		private const int mMaxArrayCols = 4;

		private const int gccReportIDColumn = 0;
		private const int gccReportNameColumn = 1;
		private const int gccSelectColumn = 2;
		private const int gccPrinterColumn = 3;


		private void cmdCancle_Click(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			aVoucherDetails.Clear();
			this.Close();
		}

		private void cmdOk_Click(Object eventSender, EventArgs eventArgs)
		{
			this.Hide();
		}

		//Public Sub SetPrintFormat(pFormID As String, pVoucherType As Long)
		//    mFormId = pFormID
		//    mVoucherType = pVoucherType
		//End Sub

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			string mFixedAreaBackColor = (0xEAEAEA).ToString();

			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(rptGrid, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HE7E2DC", "&HE7E2DC");
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(rptGrid, "ReportID", 0, false, mFixedAreaBackColor);
			SystemGrid.DefineSystemVoucherGridColumn(rptGrid, "Format", 3300, false, (0xE7E2DC).ToString());
			SystemGrid.DefineSystemVoucherGridColumn(rptGrid, "Select", 300, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);

			SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, true);

			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property rptGrid.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rptGrid.setArray(aVoucherDetails);

			ShowPrintSettings();
			rptGrid.Rebind(true);
			rptGrid.Refresh();

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			frmICSPrintReportFormat.DefInstance = null;
		}


		private void ShowPrintSettings()
		{
			bool mAttemptToSetFocus = false;
			bool mFormIsInitialized = false;
			DataSet rsLocalRec = null;

			try
			{

				if (!mFormIsInitialized)
				{
					rsLocalRec = new DataSet();

					//**--fill the preference grid with boolean_type options
					GetPreferencesInArray(rsLocalRec);

				}
				mAttemptToSetFocus = true;

				rsLocalRec = null;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void InitializeSettings()
		{

		}


		private void GetPreferencesInArray(DataSet pRecordset)
		{
			string mysql = "";
			int Cnt = 0;

			if (mFormId == "frmICSTransactionMaster")
			{
				mysql = "select IPTD.Report_ID, SR.L_Report_Name, IPTD.default_Select, IPTD.printer_path ";
				mysql = mysql + " from ICS_Print_Task_Detail IPTD inner join ";
				mysql = mysql + " SM_REPORTS SR on IPTD.Report_ID = SR.Report_Id ";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " where Voucher_Type = " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Voucher_Type"]);
			}
			else
			{
				mysql = "select gptd.Report_ID, SR.L_Report_Name, gptd.default_Select, gptd.printer_path ";
				mysql = mysql + " from GL_Print_Task_Detail gptd inner join ";
				mysql = mysql + " SM_REPORTS SR on gptd.Report_ID = SR.Report_Id ";
				mysql = mysql + " where Voucher_Type = " + mVoucherType.ToString();
			}

			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property pRecordset.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			pRecordset.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			pRecordset.Tables.Clear();
			adap.Fill(pRecordset);
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property pRecordset.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			pRecordset.setActiveConnection(null);

			SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, true);
			Cnt = 0;
			foreach (DataRow iteration_row in pRecordset.Tables[0].Rows)
			{

				SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, Cnt, false);

				//pCurrentArray(cnt, gccSettingColumn) = IIf(.Fields("show").Value = vbFalse, vbFalse, vbTrue)
				aVoucherDetails.SetValue(iteration_row["Report_ID"], Cnt, gccReportIDColumn);
				aVoucherDetails.SetValue(iteration_row["L_Report_Name"], Cnt, gccReportNameColumn);
				aVoucherDetails.SetValue(iteration_row["default_Select"], Cnt, gccSelectColumn);
				aVoucherDetails.SetValue(iteration_row["printer_path"], Cnt, gccPrinterColumn);

				Cnt++;
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event rptGrid.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void rptGrid_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			XArrayHelper aCurrentArray = null;

			if (Col == gccSelectColumn)
			{
				aCurrentArray = aVoucherDetails;

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(aCurrentArray.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), Col))) == TriState.True)
				{
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgChecked2"];
				}
				else
				{
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgUnchecked"];
				}

				CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
			}
			aCurrentArray = null;
		}

		private void rptGrid_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				int Col = rptGrid.Col;
				if (Col == gccSelectColumn)
				{
					if (KeyAscii == 32)
					{
						KeyAscii = 0;
						rptGrid.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(rptGrid.Columns[Col].Value);
						rptGrid.UpdateData();
						rptGrid.Refresh();
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

		private void rptGrid_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float x = eventArgs.X * 15;
			float y = eventArgs.Y * 15;
			int mLastCol = 0;
			int mLastRow = 0;
			if (rptGrid.PointAt(x, y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
			{
				mLastCol = rptGrid.Col;
				mLastRow = rptGrid.Row;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method rptGrid.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rptGrid.PostMsg(1);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event rptGrid.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void rptGrid_PostEvent(int MsgId)
		{
			int mLastCol = 0;
			int mLastRow = 0;

			if (mLastCol == rptGrid.Col && mLastRow == rptGrid.Row)
			{
				return;
			}

			int Col = rptGrid.Col;
			if (Col == gccSelectColumn)
			{
				rptGrid.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(rptGrid.Columns[Col].Value);
				rptGrid.UpdateData();
				rptGrid.Refresh();
			}
		}
	}
}