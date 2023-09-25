
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmSysModules
		: System.Windows.Forms.Form
	{


		
		public frmSysModules()
{
InitializeComponent();
} 
 public  void frmSysModules_old()
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
		public Control FirstFocusObject = null;

		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0; //Enum for checking the current form mode

		private bool mFormIsInitialized = false;
		private bool mAttemptToSetFocus = false;

		private int mLastCol = 0;
		private int mLastRow = 0;

		private const int mMaxArrayCols = 5;

		private const int gccSettingColumn = 0;
		private const int gccExternalSettingNameColumn = 1;
		private const int gccRemarksColumn = 2;
		private const int gccProtectedColumn = 3;
		private const int gccInternalSettingNameColumn = 4;
		private const int gccTimeStampColumn = 5;

		private XArrayHelper aSettingsGlobal = null;

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


		//These property set the Form mode to add mode or edit mode

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
			try
			{

				FirstFocusObject = grdCommon;
				this.CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
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
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				//'assign the Image for the toolbar
				//'imagelist are kept on the main form and refered by their key
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture

				SystemProcedure.SetLabelCaption(this);

				//**--make the form visible before all the control gets loaded
				//**--(this way system pretends to be faster in loading forms)
				this.Show();
				Application.DoEvents();
				//**-------------------------------------------------------------------------------------------

				ShowModulesSettings();
				mFormIsInitialized = true;
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
				//On Keydown navigate the form by using enter key
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}

				if (this.ActiveControl.Name != "txtCommon")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommon#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}
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
				oThisFormToolBar = null;
				frmSysModules.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdCommon_BeforeColEdit(object eventSender, C1.Win.C1TrueDBGrid.BeforeColEditEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int KeyAscii = (int) eventArgs.KeyChar;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				XArrayHelper aCurrentArray = null;

				if (ColIndex == gccSettingColumn)
				{
					if (KeyAscii == 0 || KeyAscii == 13 || KeyAscii == 32)
					{
						aCurrentArray = aSettingsGlobal;

						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(grdCommon.Columns[gccProtectedColumn].Value)) == TriState.False)
						{
							grdCommon.Columns[ColIndex].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdCommon.Columns[ColIndex].Value);
						}
						grdCommon.UpdateData();
						grdCommon.Refresh();
					}
					Cancel = -1;
				}
				aCurrentArray = null;
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdCommon.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdCommon_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			XArrayHelper aCurrentArray = null;

			if (Col == gccSettingColumn)
			{
				aCurrentArray = aSettingsGlobal;

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(aCurrentArray.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), gccProtectedColumn))) == TriState.True)
				{
					CellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(SystemConstants.gDisableColumnBackColor)));
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(aCurrentArray.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), Col))) == TriState.True)
					{
						CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgCheckedDisabled"];
					}
					else
					{
						CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgUncheckedDisabled"];
					}
				}
				else
				{
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(aCurrentArray.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), Col))) == TriState.True)
					{
						CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgChecked2"];
					}
					else
					{
						CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgUnchecked"];
					}
				}
				CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
			}
			aCurrentArray = null;
		}

		private void grdCommon_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				int Col = grdCommon.Col;
				if (Col == gccSettingColumn)
				{
					if (KeyAscii == 32)
					{
						KeyAscii = 0;
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(grdCommon.Columns[gccProtectedColumn].Value)) == TriState.False)
						{
							grdCommon.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdCommon.Columns[Col].Value);
						}
						grdCommon.UpdateData();
						grdCommon.Refresh();
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

		private void grdCommon_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float x = eventArgs.X * 15;
			float y = eventArgs.Y * 15;
			if (grdCommon.PointAt(x, y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
			{
				mLastCol = grdCommon.Col;
				mLastRow = grdCommon.Row;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdCommon.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdCommon.PostMsg(1);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdcommon.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdcommon_PostEvent(int MsgId)
		{

			if (mLastCol == grdCommon.Col && mLastRow == grdCommon.Row)
			{
				return;
			}

			int Col = grdCommon.Col;
			if (Col == gccSettingColumn)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(grdCommon.Columns[gccProtectedColumn].Value)) == TriState.False)
				{
					grdCommon.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdCommon.Columns[Col].Value);
				}
				grdCommon.UpdateData();
				grdCommon.Refresh();
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool CheckDataValidity()
		{
			grdCommon.UpdateData();
			//**--------------------------------------------------------------------------------------------------------------
			return true;


			return false;
		}

		public bool saveRecord()
		{
			bool result = false;
			StringBuilder mysql = new StringBuilder();
			StringBuilder mysql2 = new StringBuilder();
			clsHourGlass myHourGlass = null;
			int Cnt2 = 0;
			XArrayHelper aCurrentArray = null;
			bool mShowErrorMessage = false;
			string mCheckTimeStamp = "";
			DataSet rsMasterInfo = null;

			try
			{

				myHourGlass = new clsHourGlass();
				mShowErrorMessage = true;

				SystemVariables.gConn.BeginTransaction();
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					mysql = new StringBuilder("");
					aCurrentArray = aSettingsGlobal;

					//UPGRADE_ISSUE: (2068) Nothing object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
					if (!(aCurrentArray is UpgradeStubs.Nothing))
					{
						int tempForEndVar = aCurrentArray.GetUpperBound(0);
						for (Cnt2 = 0; Cnt2 <= tempForEndVar; Cnt2++)
						{
							//**--check the timestamp value
							mysql2 = new StringBuilder("select time_stamp from SM_MODULES ");
							mysql2.Append(" where module_id = " + Convert.ToString(aCurrentArray.GetValue(Cnt2, gccInternalSettingNameColumn)).Trim());

							SqlCommand TempCommand = null;
							TempCommand = SystemVariables.gConn.CreateCommand();
							TempCommand.CommandText = mysql2.ToString();
							SqlDataAdapter TempAdapter = null;
							TempAdapter = new SqlDataAdapter();
							TempAdapter.SelectCommand = TempCommand;
							DataSet TempDataset = null;
							TempDataset = new DataSet();
							TempAdapter.Fill(TempDataset);
							rsMasterInfo = TempDataset;
							if (rsMasterInfo.Tables[0].Rows.Count != 0)
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mCheckTimeStamp = Convert.ToString(rsMasterInfo.Tables[0].Rows[0]["time_stamp"]);
							}
							else
							{
								mCheckTimeStamp = "";
							}
							if ((rsMasterInfo.Tables[0].Rows.Count == 0) || (SystemProcedure2.tsFormat(Convert.ToString(aCurrentArray.GetValue(Cnt2, gccTimeStampColumn))) != SystemProcedure2.tsFormat(mCheckTimeStamp)))
							{
								MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								FirstFocusObject.Focus();
								rsMasterInfo = null;
								throw new Exception();
							}
							//**---------------------------------------------------------------------

							//**--else if the timestamp is ok then proceed with the update
							mysql.Append(" update SM_MODULES ");
							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
							mysql.Append(" set show = " + ((((TriState) Convert.ToInt32(aCurrentArray.GetValue(Cnt2, gccSettingColumn))) == TriState.False) ? "0" : "1"));
							mysql.Append(" where module_id = " + Convert.ToString(aCurrentArray.GetValue(Cnt2, gccInternalSettingNameColumn)).Trim());
							mysql.Append(" and protected = 0 ");
							//**---------------------------------------------------------------------
						}
					}
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql.ToString();
					TempCommand_2.ExecuteNonQuery();
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;

				MessageBox.Show("System modules have been updated. Restart system for the new settings to take effect", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				//FirstFocusObject.SetFocus
				CloseForm();
			}
			catch (System.Exception excep)
			{


				int mReturnErrorType = 0;

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
				if (mShowErrorMessage)
				{
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				}
			}
			return result;
		}

		private void InitializeSettings()
		{
			string mFixedAreaBackColor = (0xEAEAEA).ToString();

			SystemGrid.DefineSystemVoucherGrid(grdCommon, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 1.6f, 1.4f, SystemConstants.gDisableColumnBackColor, "&HB69D8D", 280);

			SystemGrid.DefineSystemVoucherGridColumn(grdCommon, "Enabled", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdCommon, "Module Name", 3500, false, mFixedAreaBackColor);
			SystemGrid.DefineSystemVoucherGridColumn(grdCommon, "Remarks", 1000, false, mFixedAreaBackColor);
			SystemGrid.DefineSystemVoucherGridColumn(grdCommon, "", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", true);
		}

		private void DoFrameFormat()
		{
			grdCommon.Left = 4;
			grdCommon.Top = 14;
			grdCommon.Width = this.ClientRectangle.Width - 13;
			grdCommon.Height = 376;
		}

		private void ShowModulesSettings()
		{
			DataSet rsLocalRec = null;

			try
			{

				if (!mFormIsInitialized)
				{
					InitializeSettings();
					DoFrameFormat();

					rsLocalRec = new DataSet();
					aSettingsGlobal = new XArrayHelper();

					//**--fill the preference grid with boolean_type options
					GetPreferencesInArray(rsLocalRec, aSettingsGlobal);

				}
				mAttemptToSetFocus = true;

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdCommon.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdCommon.setArray(aSettingsGlobal);
				grdCommon.Rebind(true);

				if (mAttemptToSetFocus)
				{
					grdCommon.Focus();
				}

				rsLocalRec = null;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				FirstFocusObject.Focus();
			}
		}

		private void GetPreferencesInArray(DataSet pRecordset, XArrayHelper pCurrentArray)
		{
			int cnt = 0;
			bool mIncludeInGrid = false;

			string mysql = "select ot.* ";
			mysql = mysql + " from SM_MODULES ot ";
			mysql = mysql + " order by module_id ";

			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property pRecordset.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			pRecordset.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			pRecordset.Tables.Clear();
			adap.Fill(pRecordset);
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property pRecordset.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			pRecordset.setActiveConnection(null);

			SystemGrid.DefineVoucherArray(pCurrentArray, mMaxArrayCols, -1, true);
			cnt = 0;
			foreach (DataRow iteration_row in pRecordset.Tables[0].Rows)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				mIncludeInGrid = !(((TriState) Convert.ToInt32(iteration_row["is_admin_type"])) == TriState.True && !SystemVariables.gXtremeAdminLoggedIn);

				if (mIncludeInGrid)
				{
					SystemGrid.DefineVoucherArray(pCurrentArray, mMaxArrayCols, cnt, false);

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					pCurrentArray.SetValue((((TriState) Convert.ToInt32(iteration_row["show"])) == TriState.False) ? TriState.False : TriState.True, cnt, gccSettingColumn);
					pCurrentArray.SetValue(StringsHelper.Replace(Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? iteration_row["l_group_name"] : iteration_row["a_group_name"]) + "", "&", "", 1, -1, CompareMethod.Binary), cnt, gccExternalSettingNameColumn);
					pCurrentArray.SetValue(Convert.ToString(iteration_row["comments"]) + "", cnt, gccRemarksColumn);
					pCurrentArray.SetValue(iteration_row["protected"], cnt, gccProtectedColumn);
					pCurrentArray.SetValue(iteration_row["module_id"], cnt, gccInternalSettingNameColumn);
					pCurrentArray.SetValue(iteration_row["time_stamp"], cnt, gccTimeStampColumn);

					cnt++;
				}
			}
		}
	}
}