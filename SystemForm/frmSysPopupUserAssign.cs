
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSysPopupUserAssign
		: System.Windows.Forms.Form
	{

		public frmSysPopupUserAssign()
{
InitializeComponent();
} 
 public  void frmSysPopupUserAssign_old()
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


		private void frmSysPopupUserAssign_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		public Control FirstFocusObject = null;

		private int mThisFormID = 0; //Assign the Formid for Each Form
		private string mTimeStamp = "";
		private clsToolbar oThisFormToolBar = null;
		private bool mFirstGridFocus = false;
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

		private string mSearchValue = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private const int conMaxColumns = 4;

		private const int mConUserId = 1;
		private const int mConName = 2;
		private const int mConAssign = 3;
		private const int mConUserCd = 4;

		//The property below are used for storing the Search value returned by the Find window
		public string SearchValue
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

				FirstFocusObject = txtPopupTypeCd;

				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = false;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = false;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = false;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowInsertLineButton = false;
				oThisFormToolBar.ShowDeleteLineButton = false;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = false;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.9f, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "User ID", 2500, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 50);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "User Name", 2500, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 50);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Assign", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, true, false, 50);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "UserCD", 2500, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false, false, false, true, false, 50);

				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Enabled = false;
				//txtPopupTypeCd.SetFocus
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}
		}

		private void txtPopupTypeCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtPopupTypeCd");
		}


		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			if (pObjectName == "txtPopupTypeCd")
			{
				txtPopupTypeCd.Text = "";
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000132));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtPopupTypeCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0));
					txtPopupTypeCd_Leave(txtPopupTypeCd, new EventArgs());
				}
				else
				{
					txtPopupTypeCd.Focus();
				}
			}

		}


		private void txtPopupTypeCd_Leave(Object eventSender, EventArgs eventArgs)
		{

			if (SystemProcedure2.IsItEmpty(txtPopupTypeCd.Text))
			{
				return;
			}

			string mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_description" : "a_description");
			mysql = mysql + " from SM_Popup_Type ";
			mysql = mysql + " where popup_type_cd=" + txtPopupTypeCd.Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtPopupTypeCdName.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				FillGrid();
			}
			else
			{
				txtPopupTypeCd.Text = "";
				txtPopupTypeCdName.Text = "";
			}

		}

		private void FillGrid()
		{

			string mysql = "select user_cd, [user_id],[User_name], 1 as assign";
			mysql = mysql + " from SM_USERS ";
			mysql = mysql + " where user_cd in (select user_cd from SM_Popup_User_Details where popup_type_cd =" + txtPopupTypeCd.Text + ")";
			mysql = mysql + " union ";
			mysql = mysql + " select user_cd,[user_id],[User_name],0 as assign";
			mysql = mysql + " from SM_USERS  ";
			mysql = mysql + " where user_cd not in (select user_cd from SM_Popup_User_Details where popup_type_cd =" + txtPopupTypeCd.Text + ")";

			int mRowCnt = 0;
			DataSet rs = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rs.Tables.Clear();
			adap.Fill(rs);
			aVoucherDetails.RedimXArray(new int[]{rs.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
			foreach (DataRow iteration_row in rs.Tables[0].Rows)
			{
				aVoucherDetails.SetValue(iteration_row["user_id"], mRowCnt, mConUserId);
				aVoucherDetails.SetValue(iteration_row["User_name"], mRowCnt, mConName);
				aVoucherDetails.SetValue(iteration_row["assign"], mRowCnt, mConAssign);
				aVoucherDetails.SetValue(iteration_row["user_cd"], mRowCnt, mConUserCd);
				mRowCnt++;
			}
			AssignGridLineNumbers();
			grdVoucherDetails.Refresh();
			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Enabled = true;
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

		public void CloseForm()
		{
			this.Close();
		}

		public bool saveRecord()
		{
			bool result = false;
			try
			{
				StringBuilder mysql = new StringBuilder();
				int cnt = 0;

				SystemVariables.gConn.BeginTransaction();

				mysql = new StringBuilder(" delete from SM_Popup_User_Details");
				mysql.Append(" where popup_type_cd =" + txtPopupTypeCd.Text);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql.ToString();
				TempCommand.ExecuteNonQuery();

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					if (Convert.ToDouble(aVoucherDetails.GetValue(cnt, mConAssign)) == 1)
					{
						mysql = new StringBuilder(" insert into SM_Popup_User_Details(user_cd,popup_type_cd)");
						mysql.Append(" values(" + Convert.ToString(aVoucherDetails.GetValue(cnt, mConUserCd)) + "," + txtPopupTypeCd.Text + ")");
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql.ToString();
						TempCommand_2.ExecuteNonQuery();
					}
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
			}
			return result;
		}

		public void AddRecord()
		{
			try
			{

				SystemProcedure2.ClearTextBox(this);
				DefineVoucherArray(-1, true);
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
				mSearchValue = ""; //Change the msearchvalue to blank
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}
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
				if (Convert.ToDouble(aVoucherDetails.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), mConAssign)) == 1)
				{
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgChecked2"];
					CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
				}
				else if (Convert.ToDouble(aVoucherDetails.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), mConAssign)) == 0)
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
					if (mCol == mConAssign)
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

				if (Col == mConAssign)
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
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}