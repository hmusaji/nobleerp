
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSysAlarmPopup
		: System.Windows.Forms.Form
	{

		public frmSysAlarmPopup()
{
InitializeComponent();
} 
 public  void frmSysAlarmPopup_old()
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


		private void frmSysAlarmPopup_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private XArrayHelper _aVoucherDetails = null;
		private XArrayHelper aVoucherDetails
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

		private clsToolbar oThisFormToolBar = null;
		private const int conMaxColumns = 8;
		int mThisFormID = 0;
		private int mFormCallType = 0;
		private int mSearchValue = 0;
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

		public Control FirstFocusObject = null;

		private const int mConTransNo = 1;
		private const int mConEmpNo = 2;
		private const int mConEmpName = 3;
		private const int mConAlarmDate = 4;
		private const int mConRemarks = 5;
		private const int mConFormId = 7;
		private const int mConEntryId = 8;
		private const int mConDismiss = 6;


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



		public int FormCallType
		{
			get
			{
				return mFormCallType;
			}
			set
			{
				mFormCallType = value;
			}
		}


		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 13)
				{
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

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{
				int i = 0;
				int mSday = 0;
				int mCol = 0;
				string mStr = "";
				DataSet rsLocalRec = null;
				string mySql = "";
				object mReturnValue = null;
				System.DateTime mGenerateDate = DateTime.FromOADate(0);
				System.DateTime mStartDate = DateTime.FromOADate(0);

				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				FirstFocusObject = grdVoucherDetails;

				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.4f, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Transaction No", 1000, false, SystemConstants.gDisableColumnBackColor);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Code", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Name", 3000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Alarm Date", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Dismiss", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, true, false, 50);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "FormID", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "EntryID", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				//To Get days in which order they wants to display
				mGenerateDate = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate());
				mStartDate = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate());


				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mGenerateDate))
				{
					DefineVoucherArray(-1, true);
				}
				else
				{
					MessageBox.Show("Please Insert Cut off value....", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}

				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);

				grdVoucherDetails.Visible = true;
				grdVoucherDetails.Enabled = true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void DefineVoucherArray(int pMaximumRows, bool pClearArray = false)
		{
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
			}
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, conMaxColumns}, new int[]{0, 0});
		}


		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, SystemICSConstants.grdLineNoColumn);
			}
		}

		public object GetRecord(int pSearchValue)
		{

			mSearchValue = pSearchValue;

			string mySql = "select spd.Popup_date, spd.description ,spt.formid, spd.entry_id";
			switch(pSearchValue)
			{
				case 1 : case 2 : 
					mySql = mySql + " ,plt.voucher_no,pemp.emp_no,pemp.l_full_name, spd.posted"; 
					mySql = mySql + " from SM_Popup_Details spd"; 
					mySql = mySql + " inner join SM_Popup_Type spt on spd.popup_type_cd = spt.popup_type_cd"; 
					mySql = mySql + " inner join pay_leave_transaction plt on plt.entry_id = spd.entry_id"; 
					mySql = mySql + " inner join pay_employee pemp on pemp.emp_cd = plt.emp_cd"; 
					mySql = mySql + " where spd.popup_type_cd =" + pSearchValue.ToString() + " and spd.posted = 0"; 
					this.Text = "Reminder For Leave\\Resume"; 
					break;
				case 3 : 
					mySql = mySql + " ,pdd.document_no,pdm.l_document_name, pemp.l_full_name , spd.posted"; 
					mySql = mySql + " from SM_Popup_Details spd"; 
					mySql = mySql + " inner join SM_Popup_Type spt on spd.popup_type_cd = spt.popup_type_cd"; 
					mySql = mySql + " inner join pay_document_detail pdd on pdd.entry_id = spd.entry_id"; 
					mySql = mySql + " inner join pay_document_master pdm on pdm.document_cd = pdd.document_cd"; 
					mySql = mySql + " inner join pay_employee pemp on pemp.emp_cd = pdd.emp_cd"; 
					mySql = mySql + " where spd.popup_type_cd =" + pSearchValue.ToString() + " and spd.posted = 0"; 
					this.Text = "Reminder For Document Details"; 
					break;
				case 4 : 
					mySql = mySql + " ,pv.vehicle_no,pemp.emp_no,pemp.l_full_name, spd.posted"; 
					mySql = mySql + " from SM_Popup_Details spd"; 
					mySql = mySql + " inner join SM_Popup_Type spt on spd.popup_type_cd = spt.popup_type_cd"; 
					mySql = mySql + " inner join pay_vehicle pv on pv.vehicle_cd = spd.entry_id"; 
					mySql = mySql + " inner join pay_employee pemp on pemp.emp_cd = pv.emp_cd"; 
					mySql = mySql + " where spd.popup_type_cd =" + pSearchValue.ToString() + " and spd.posted = 0"; 
					this.Text = "Reminder For Vehicle"; 
					break;
				case 5 : 
					mySql = mySql + " ,pehd.entry_id,pemp.emp_no,pemp.l_full_name, spd.posted"; 
					mySql = mySql + " from SM_Popup_Details spd"; 
					mySql = mySql + " inner join SM_Popup_Type spt on spd.popup_type_cd = spt.popup_type_cd"; 
					mySql = mySql + " inner join pay_employee_hold_details pehd on pehd.entry_id = spd.entry_id"; 
					mySql = mySql + " inner join pay_employee pemp on pemp.emp_cd = pehd.emp_cd"; 
					mySql = mySql + " where spd.popup_type_cd =" + pSearchValue.ToString() + " and spd.posted = 0"; 
					this.Text = "Reminder For Hold Employee"; 
					break;
				case 6 : 
					mySql = mySql + " ,pdt.document_no,pemp.emp_no,pemp.l_full_name, spd.posted"; 
					mySql = mySql + " from SM_Popup_Details spd"; 
					mySql = mySql + " inner join SM_Popup_Type spt on spd.popup_type_cd = spt.popup_type_cd"; 
					mySql = mySql + " inner join pay_document_transaction pdt on pdt.entry_id = spd.entry_id"; 
					mySql = mySql + " inner join pay_employee pemp on pemp.emp_cd = pdt.emp_cd"; 
					mySql = mySql + " where spd.popup_type_cd =" + pSearchValue.ToString() + " and spd.posted = 0"; 
					this.Text = "Reminder For Document Transaction"; 
					break;
				case 7 : 
					mySql = mySql + " ,pemp.emp_cd,pemp.emp_no,pemp.l_full_name, spd.posted"; 
					mySql = mySql + " from SM_Popup_Details spd"; 
					mySql = mySql + " inner join SM_Popup_Type spt on spd.popup_type_cd = spt.popup_type_cd"; 
					mySql = mySql + " inner join pay_employee pemp on pemp.emp_cd = spd.entry_id"; 
					mySql = mySql + " where spd.popup_type_cd =" + pSearchValue.ToString() + " and spd.posted = 0"; 
					this.Text = "Reminder For Probation End Transaction"; 
					break;
			}
			mySql = mySql + " and spd.Popup_date <='" + DateTime.Today.ToString("dd/MMM/yyyy") + "'";
			mySql = mySql + " order by 6";
			int mCntRow = 0;
			if (pSearchValue == 3)
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[2].DataColumn.Caption = "Doc Name";
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[3].DataColumn.Caption = "Employee Name";
			}
			DataSet rs = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mySql, SystemVariables.gConn);
			rs.Tables.Clear();
			adap.Fill(rs);
			aVoucherDetails.RedimXArray(new int[]{rs.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
			foreach (DataRow iteration_row in rs.Tables[0].Rows)
			{
				aVoucherDetails.SetValue(iteration_row[4], mCntRow, mConTransNo);
				aVoucherDetails.SetValue(iteration_row[5], mCntRow, mConEmpNo);
				aVoucherDetails.SetValue(iteration_row[6], mCntRow, mConEmpName);
				aVoucherDetails.SetValue(iteration_row[0], mCntRow, mConAlarmDate);
				aVoucherDetails.SetValue(iteration_row[1], mCntRow, mConRemarks);
				aVoucherDetails.SetValue(iteration_row[2], mCntRow, mConFormId);
				aVoucherDetails.SetValue(iteration_row[3], mCntRow, mConEntryId);
				aVoucherDetails.SetValue(iteration_row[7], mCntRow, mConDismiss);
				mCntRow++;
			}
			AssignGridLineNumbers();
			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Refresh();
			FirstFocusObject.Focus();
			return null;
		}


		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			StringBuilder mySql = new StringBuilder();
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (Convert.ToBoolean(aVoucherDetails.GetValue(cnt, mConDismiss)))
				{
					mySql = new StringBuilder(" update SM_Popup_Details");
					mySql.Append(" set posted = 1");
					mySql.Append(" where popup_type_cd =" + mSearchValue.ToString());
					mySql.Append(" and entry_id = " + Convert.ToString(aVoucherDetails.GetValue(cnt, mConEntryId)));
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mySql.ToString();
					TempCommand.ExecuteNonQuery();
				}
			}
		}

		private void grdVoucherDetails_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_WARNING: (1068) grdVoucherDetails.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mRow = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark);
			int mFormId = Convert.ToInt32(aVoucherDetails.GetValue(mRow, mConFormId));
			object mSearch = aVoucherDetails.GetValue(mRow, mConEntryId);
			SystemForms.GetSystemForm(mFormId, 2, mSearch);
		}

		public void CloseForm()
		{
			this.Close();
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			int grdRow = 0;

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdVoucherDetails.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdVoucherDetails.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				grdRow = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark);
				if (Convert.ToBoolean(aVoucherDetails.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), mConDismiss)))
				{
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgChecked2"];
					CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
				}
				else if (!Convert.ToBoolean(aVoucherDetails.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), mConDismiss)))
				{ 
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgUnchecked"];
					CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
				}
			}
		}

		private void grdVoucherDetails_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				try
				{
					int mRow = 0;
					int mCol = 0;
					mRow = grdVoucherDetails.Row;
					mCol = grdVoucherDetails.Col;
					if (mCol == mConDismiss)
					{
						if (KeyAscii == 32)
						{
							KeyAscii = 0;
							grdVoucherDetails_Post(grdVoucherDetails, new AxTrueOleDBGrid80.TrueDBGridEvents_PostEventEvent(1));
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
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					return;
				}
				catch
				{
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

		private void grdVoucherDetails_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float x = eventArgs.X * 15;
			float y = eventArgs.Y * 15;
			if (grdVoucherDetails.PointAt(x, y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
			{
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.PostMsg(1);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{
			int Col = 0;
			try
			{
				Col = grdVoucherDetails.Col;

				if (Col == mConDismiss)
				{
					if (ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Columns[Col].Value) == 0)
					{
						grdVoucherDetails.Columns[Col].Value = 1;
					}
					else
					{
						grdVoucherDetails.Columns[Col].Value = 0;
					}
					grdVoucherDetails.UpdateData();
					grdVoucherDetails.Refresh();
				}
			}
			catch
			{
			}
		}
	}
}