
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSysDayLock
		: System.Windows.Forms.Form
	{

		public frmSysDayLock()
{
InitializeComponent();
} 
 public  void frmSysDayLock_old()
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


		private void frmSysDayLock_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private int mThisFormID = 0;
		private object mSearchValue = null;

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

		private clsToolbar oThisFormToolBar = null;

		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		public Control FirstFocusObject = null;
		private XArrayHelper _aDateDetail = null;
		private XArrayHelper aDateDetail
		{
			get
			{
				if (_aDateDetail is null)
				{
					_aDateDetail = new XArrayHelper();
				}
				return _aDateDetail;
			}
			set
			{
				_aDateDetail = value;
			}
		}


		private const int mMaxArrayCols = 2;

		private const int gccLineNoColumn = 0;
		private const int gccDateCodeColumn = 1;
		private const int gccLockColumn = 2;

		private int mLastCol = 0;
		private int mLastRow = 0;

		int mSManCd = 0;
		private string mTimeStamp = "";


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



		private void cmdSelect_Click(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			int cnt = 0;
			DataSet rsLocalRec = null;

			try
			{

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(txtFromDate.Value) && !Convert.IsDBNull(txtToDate.Value))
				{

					mysql = "select Sys_Date, locked";
					mysql = mysql + " from SM_period ";
					mysql = mysql + " where sys_date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtFromDate.Value) + "'";
					mysql = mysql + " and sys_date <= '" + ReflectionHelper.GetPrimitiveValue<string>(txtToDate.Value) + "'";

					rsLocalRec = new DataSet();
					//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLocalRec.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsLocalRec.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
					SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsLocalRec.Tables.Clear();
					adap.Fill(rsLocalRec);
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLocalRec.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsLocalRec.setActiveConnection(null);
					SystemGrid.DefineVoucherArray(aDateDetail, mMaxArrayCols, -1, true);
					cnt = 0;
					foreach (DataRow iteration_row in rsLocalRec.Tables[0].Rows)
					{

						SystemGrid.DefineVoucherArray(aDateDetail, mMaxArrayCols, cnt, false);

						aDateDetail.SetValue(cnt + 1, cnt, gccLineNoColumn);
						aDateDetail.SetValue(iteration_row["sys_date"], cnt, gccDateCodeColumn);
						aDateDetail.SetValue(iteration_row["locked"], cnt, gccLockColumn);

						cnt++;
					}
					rsLocalRec = null;
					grdDays.Rebind(true);
					grdDays.Refresh();

				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				txtFromDate.Value = DateTime.Parse("01-" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(DateTime.Today.Month) + "-" + Conversion.Str(DateTime.Today.Year));
				txtToDate.Value = DateTime.Today;

				FirstFocusObject = txtFromDate;

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;

				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.ShowCheckAllButton = true;
				oThisFormToolBar.ShowUncheckAllButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;
				SystemProcedure.SetLabelCaption(this);
				string mFixedAreaBackColor = (0xEAEAEA).ToString();

				//**--define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdDays, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");

				//**--define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdDays, "LN", 800, false, mFixedAreaBackColor);
				SystemGrid.DefineSystemVoucherGridColumn(grdDays, "Date", 3500, false, mFixedAreaBackColor);
				SystemGrid.DefineSystemVoucherGridColumn(grdDays, "Lock", 300, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);

				//''''*************************************************************************
				aDateDetail = new XArrayHelper();
				SystemGrid.DefineVoucherArray(aDateDetail, mMaxArrayCols, -1, false);

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdDays.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdDays.setArray(aDateDetail);
				grdDays.Rebind(true);
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}

		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdDays.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdDays_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			XArrayHelper aCurrentArray = null;

			if (Col == gccLockColumn)
			{
				aCurrentArray = aDateDetail;

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

		private void grdDays_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				int Col = grdDays.Col;
				if (Col == gccLockColumn)
				{
					if (KeyAscii == 32)
					{
						KeyAscii = 0;
						grdDays.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdDays.Columns[Col].Value);
						grdDays.UpdateData();
						grdDays.Refresh();
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

		private void grdDays_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float x = eventArgs.X * 15;
			float y = eventArgs.Y * 15;
			if (grdDays.PointAt(x, y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
			{
				mLastCol = grdDays.Col;
				mLastRow = grdDays.Row;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdDays.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdDays.PostMsg(1);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdDays.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdDays_PostEvent(int MsgId)
		{

			if (mLastCol == grdDays.Col && mLastRow == grdDays.Row)
			{
				return;
			}

			int Col = grdDays.Col;
			if (Col == gccLockColumn)
			{
				grdDays.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdDays.Columns[Col].Value);
				grdDays.UpdateData();
				grdDays.Refresh();
			}
		}

		public bool saveRecord()
		{
			bool result = false;
			StringBuilder mysql = new StringBuilder();
			try
			{
				SystemVariables.gConn.BeginTransaction();

				int cnt = 0;
				if (aDateDetail.GetLength(0) > 0)
				{
					int tempForEndVar = aDateDetail.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{


						mysql = new StringBuilder("update SM_period set locked = " + ((!Convert.ToBoolean(aDateDetail.GetValue(cnt, gccLockColumn))) ? 0 : 1).ToString());
						mysql.Append(" where sys_date = '" + Convert.ToString(aDateDetail.GetValue(cnt, gccDateCodeColumn)) + "'");
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql.ToString();
						TempCommand.ExecuteNonQuery();

					}
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				aDateDetail = null;

				aDateDetail = new XArrayHelper();
				SystemGrid.DefineVoucherArray(aDateDetail, mMaxArrayCols, -1, false);

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdDays.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdDays.setArray(aDateDetail);
				grdDays.Rebind(true);
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}

			return result;
		}

		public void CloseForm()
		{
			this.Close();
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void KRoutine()
		{
			int cnt = 0;


			while(cnt < aDateDetail.GetLength(0))
			{
				aDateDetail.SetValue(-1, cnt, gccLockColumn);
				cnt++;
			};
			grdDays.Rebind(true);
			grdDays.Refresh();
		}
		public void URoutine()
		{
			int cnt = 0;


			while(cnt < aDateDetail.GetLength(0))
			{
				aDateDetail.SetValue(0, cnt, gccLockColumn);
				cnt++;
			};
			grdDays.Rebind(true);
			grdDays.Refresh();
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}