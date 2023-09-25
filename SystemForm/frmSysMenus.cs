
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmSysMenus
		: System.Windows.Forms.Form
	{


		
		public frmSysMenus()
{
InitializeComponent();
} 
 public  void frmSysMenus_old()
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
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			
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
		private int mSearchValue = 0;
		private string mTimeStamp = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0; //Enum for checking the current form mode

		private bool mFormIsInitialized = false;
		private bool mAttemptToSetFocus = false;

		private bool mGlobalSettingTabClicked = false;
		private bool mGLSettingTabClicked = false;
		private bool mICSSettingTabClicked = false;
		private bool mSalesSettingTabClicked = false;
		private bool mPurchaseSettingTabClicked = false;
		private bool mHRSettingTabClicked = false;
		private bool mPaySettingTabClicked = false;

		private int mLastCol = 0;
		private int mLastRow = 0;

		private const int cSettingsGlobalIndex = 0;
		private const int cSettingsGLIndex = 1;
		private const int cSettingsICSIndex = 2;
		private const int cSettingsSalesIndex = 3;
		private const int cSettingsPurchaseIndex = 4;
		private const int cSettingsHRIndex = 5;
		private const int cSettingsPayIndex = 6;

		private const int mFixedAreaBackColor = 0xD5DDD9; //&HC9D3CE
		private const int mMaxArrayCols = 10;

		private const int gccShowSettingColumn = 0;
		private const int gccEnabledSettingColumn = 1;
		private const int gccExternalSettingNameColumn = 2;
		private const int gccExternalSettingANameColumn = 3;
		private const int gccRemarksColumn = 4;
		private const int gccShowAsToolbarColumn = 5;
		private const int gccVoucherTypeColumn = 6;
		private const int gccIconIdColumn = 7;
		private const int gccProtectedColumn = 8;
		private const int gccInternalSettingNameColumn = 9;
		private const int gccTimeStampColumn = 10;

		private XArrayHelper aSettingsGlobal = null;
		private XArrayHelper aSettingsGL = null;
		private XArrayHelper aSettingsICS = null;
		private XArrayHelper aSettingsSales = null;
		private XArrayHelper aSettingsPurchase = null;
		private XArrayHelper aSettingsHR = null;
		private XArrayHelper aSettingsPay = null;

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


		//The property below are used for storing the Search value returned by the Find window
		public int SearchValue
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
				ShowHideTabs();

				//**--make the form visible before all the control gets loaded
				//**--(this way system pretends to be faster in loading forms)
				this.Show();
				Application.DoEvents();
				//**-------------------------------------------------------------------------------------------

				mGlobalSettingTabClicked = false;
				mGLSettingTabClicked = false;
				mICSSettingTabClicked = false;
				mSalesSettingTabClicked = false;
				mPurchaseSettingTabClicked = false;
				mHRSettingTabClicked = false;

				tabMaster.CurrTab = Convert.ToInt16(cSettingsGlobalIndex);
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

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			cntOuterFrame.Width = this.Width - 7;
			tabMaster.Width = this.Width - 7;

			cntOuterFrame.Height = this.Height - 27;
			tabMaster.Height = this.Height - 40;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmSysMenus.DefInstance = null;
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
				//Dim aCurrentArray As XArrayDB

				if (ColIndex == gccShowSettingColumn || ColIndex == gccEnabledSettingColumn || ColIndex == gccShowAsToolbarColumn)
				{
					if (KeyAscii == 0 || KeyAscii == 13 || KeyAscii == 32)
					{
						//        Select Case tabMaster.CurrTab
						//            Case cSettingsGlobalIndex
						//                Set aCurrentArray = aSettingsGlobal
						//            Case cSettingsGLIndex
						//                Set aCurrentArray = aSettingsGL
						//            Case cSettingsICSIndex
						//                Set aCurrentArray = aSettingsICS
						//            Case cSettingsSalesIndex
						//                Set aCurrentArray = aSettingsSales
						//            Case cSettingsPurchaseIndex
						//                Set aCurrentArray = aSettingsPurchase
						//            Case cSettingsHRIndex
						//                Set aCurrentArray = aSettingsHR
						//            Case cSettingsPayIndex
						//                Set aCurrentArray = aSettingsPay
						//        End Select

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

				//Set aCurrentArray = Nothing
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

			if (Col == gccShowSettingColumn || Col == gccEnabledSettingColumn || Col == gccShowAsToolbarColumn)
			{
				switch(tabMaster.CurrTab)
				{
					case cSettingsGlobalIndex : 
						aCurrentArray = aSettingsGlobal; 
						break;
					case cSettingsGLIndex : 
						aCurrentArray = aSettingsGL; 
						break;
					case cSettingsICSIndex : 
						aCurrentArray = aSettingsICS; 
						break;
					case cSettingsSalesIndex : 
						aCurrentArray = aSettingsSales; 
						break;
					case cSettingsPurchaseIndex : 
						aCurrentArray = aSettingsPurchase; 
						break;
					case cSettingsHRIndex : 
						aCurrentArray = aSettingsHR; 
						break;
					case cSettingsPayIndex : 
						aCurrentArray = aSettingsPay; 
						break;
				}

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
				if (Col == gccShowSettingColumn || Col == gccEnabledSettingColumn || Col == gccShowAsToolbarColumn)
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
			if (Col == gccShowSettingColumn || Col == gccEnabledSettingColumn || Col == gccShowAsToolbarColumn)
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

		private void ShowHideTabs()
		{
			int mCurrentTab = 0;

			DataSet rsSystemModules = new DataSet();

			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsSystemModules.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsSystemModules.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter("select module_id, show from SM_MODULES", SystemVariables.gConn);
			rsSystemModules.Tables.Clear();
			adap.Fill(rsSystemModules);
			foreach (DataRow iteration_row in rsSystemModules.Tables[0].Rows)
			{
				switch(Convert.ToInt32(Conversion.Val(Convert.ToString(iteration_row["module_id"]))))
				{
					case SystemConstants.gModuleGlobalID : 
						mCurrentTab = cSettingsGlobalIndex; 
						break;
					case SystemConstants.gModuleGLID : 
						mCurrentTab = cSettingsGLIndex; 
						break;
					case SystemConstants.gModuleICSID : 
						mCurrentTab = cSettingsICSIndex; 
						break;
					case SystemConstants.gModuleSalesID : 
						mCurrentTab = cSettingsSalesIndex; 
						break;
					case SystemConstants.gModulePurchaseID : 
						mCurrentTab = cSettingsPurchaseIndex; 
						break;
					case SystemConstants.gModuleHRID : 
						mCurrentTab = cSettingsHRIndex; 
						break;
					case SystemConstants.gModulePayID : 
						mCurrentTab = cSettingsPayIndex; 
						break;
					default:
						goto EndSettings; 
						break;
				}
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(iteration_row["show"])) == TriState.True)
				{
					tabMaster.set_TabVisible((short) mCurrentTab, true);
				}
				else
				{
					tabMaster.set_TabVisible((short) mCurrentTab, false);
					tabMaster.TabsPerPage = (short) (tabMaster.TabsPerPage - 1);
				}

				EndSettings:;
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
			//all ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord")
		}

		public bool saveRecord()
		{
			bool result = false;
			StringBuilder mysql = new StringBuilder();
			StringBuilder mysql2 = new StringBuilder();
			clsHourGlass myHourGlass = null;
			int cnt = 0;
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

					for (cnt = 0; cnt <= 6; cnt++)
					{
						switch(cnt)
						{
							case cSettingsGlobalIndex : 
								if (mGlobalSettingTabClicked)
								{
									aCurrentArray = aSettingsGlobal;
								}
								else
								{
									aCurrentArray = null;
								} 
								break;
							case cSettingsGLIndex : 
								if (mGLSettingTabClicked)
								{
									aCurrentArray = aSettingsGL;
								}
								else
								{
									aCurrentArray = null;
								} 
								break;
							case cSettingsICSIndex : 
								if (mICSSettingTabClicked)
								{
									aCurrentArray = aSettingsICS;
								}
								else
								{
									aCurrentArray = null;
								} 
								break;
							case cSettingsSalesIndex : 
								if (mSalesSettingTabClicked)
								{
									aCurrentArray = aSettingsSales;
								}
								else
								{
									aCurrentArray = null;
								} 
								break;
							case cSettingsPurchaseIndex : 
								if (mPurchaseSettingTabClicked)
								{
									aCurrentArray = aSettingsPurchase;
								}
								else
								{
									aCurrentArray = null;
								} 
								break;
							case cSettingsHRIndex : 
								if (mHRSettingTabClicked)
								{
									aCurrentArray = aSettingsHR;
								}
								else
								{
									aCurrentArray = null;
								} 
								break;
							case cSettingsPayIndex : 
								if (mPaySettingTabClicked)
								{
									aCurrentArray = aSettingsPay;
								}
								else
								{
									aCurrentArray = null;
								} 
								break;
						}

						//UPGRADE_ISSUE: (2068) Nothing object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
						if (!(aCurrentArray is UpgradeStubs.Nothing))
						{
							int tempForEndVar2 = aCurrentArray.GetUpperBound(0);
							for (Cnt2 = 0; Cnt2 <= tempForEndVar2; Cnt2++)
							{
								//**--check the timestamp value
								mysql2 = new StringBuilder("select time_stamp from SM_MENU ");
								mysql2.Append(" where menu_id = " + Convert.ToString(aCurrentArray.GetValue(Cnt2, gccInternalSettingNameColumn)).Trim());

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
								mysql.Append(" update SM_MENU ");
								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								mysql.Append(" set show = " + ((((TriState) Convert.ToInt32(aCurrentArray.GetValue(Cnt2, gccShowSettingColumn))) == TriState.False) ? "0" : "1"));
								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								mysql.Append("  , enabled = " + ((((TriState) Convert.ToInt32(aCurrentArray.GetValue(Cnt2, gccEnabledSettingColumn))) == TriState.False) ? "0" : "1"));
								mysql.Append("  , l_menu_name = '" + StringsHelper.Replace(Convert.ToString(aCurrentArray.GetValue(Cnt2, gccExternalSettingNameColumn)), "'", "''", 1, -1, CompareMethod.Binary) + "'");
								mysql.Append("  , a_menu_name = N'" + StringsHelper.Replace(Convert.ToString(aCurrentArray.GetValue(Cnt2, gccExternalSettingANameColumn)), "'", "''", 1, -1, CompareMethod.Binary) + "'");
								mysql.Append("  , comments = '" + StringsHelper.Replace(Convert.ToString(aCurrentArray.GetValue(Cnt2, gccRemarksColumn)), "'", "''", 1, -1, CompareMethod.Binary) + "'");
								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								mysql.Append("  , Show_In_Shortcut_Bar = " + ((((TriState) Convert.ToInt32(aCurrentArray.GetValue(Cnt2, gccShowAsToolbarColumn))) == TriState.False) ? "0" : "1"));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								mysql.Append("  , ics_voucher_type = " + ((Convert.IsDBNull(aCurrentArray.GetValue(Cnt2, gccVoucherTypeColumn))) ? "Null" : Convert.ToString(aCurrentArray.GetValue(Cnt2, gccVoucherTypeColumn))));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								mysql.Append("  , Ribbon_Icon_Id = " + ((Convert.IsDBNull(aCurrentArray.GetValue(Cnt2, gccIconIdColumn))) ? "0" : Convert.ToString(aCurrentArray.GetValue(Cnt2, gccIconIdColumn))));
								mysql.Append(" where menu_id = " + Convert.ToString(aCurrentArray.GetValue(Cnt2, gccInternalSettingNameColumn)).Trim());
								mysql.Append(" and protected = 0 ");
								//**---------------------------------------------------------------------
							}
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

				MessageBox.Show("System menus have been updated. Restart system for the new settings to take effect", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			SystemGrid.DefineSystemVoucherGrid(grdCommon, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 1.6f, 1.4f, mFixedAreaBackColor.ToString(), "&HB69D8D", 280);

			SystemGrid.DefineSystemVoucherGridColumn(grdCommon, "Show", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdCommon, "Enabled", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdCommon, "Menu Name", 4000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdCommon, "Menu Name Arabic", 4000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdCommon, "Remarks", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdCommon, "Shortcut Bar", 900, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdCommon, "Voucher Type", 1100);
			SystemGrid.DefineSystemVoucherGridColumn(grdCommon, "Icon", 1100);
			SystemGrid.DefineSystemVoucherGridColumn(grdCommon, "", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", true);
		}

		private void DoFrameFormat()
		{
			grdCommon.Left = -1;
			grdCommon.Top = 21;
			grdCommon.Width = tabMaster.Width - 1;
			grdCommon.Height = tabMaster.Height - (grdCommon.Top + 23);
		}

		private void tabMaster_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			try
			{

				if (!mFormIsInitialized)
				{
					InitializeSettings();
					DoFrameFormat();
				}
				mAttemptToSetFocus = true;
				switch(tabMaster.CurrTab)
				{
					case cSettingsGlobalIndex : 
						ShowGlobalSettingTab(); 
						mGlobalSettingTabClicked = true; 
						break;
					case cSettingsGLIndex : 
						ShowGLSettingTab(); 
						mGLSettingTabClicked = true; 
						break;
					case cSettingsICSIndex : 
						ShowICSSettingTab(); 
						mICSSettingTabClicked = true; 
						break;
					case cSettingsSalesIndex : 
						ShowSalesSettingTab(); 
						mSalesSettingTabClicked = true; 
						break;
					case cSettingsPurchaseIndex : 
						ShowPurchaseSettingTab(); 
						mPurchaseSettingTabClicked = true; 
						break;
					case cSettingsHRIndex : 
						ShowHRSettingTab(); 
						mHRSettingTabClicked = true; 
						break;
					case cSettingsPayIndex : 
						ShowPayrollSettingTab(); 
						mPaySettingTabClicked = true; 
						break;
				}
				grdCommon.Rebind(true);
				if (mAttemptToSetFocus)
				{
					grdCommon.Focus();
				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				FirstFocusObject.Focus();
			}
		}

		private void ShowGlobalSettingTab()
		{
			DataSet rsLocalRec = null;

			if (!mGlobalSettingTabClicked)
			{
				rsLocalRec = new DataSet();
				aSettingsGlobal = new XArrayHelper();

				//**--fill the preference grid with boolean_type options
				GetPreferencesInArray(rsLocalRec, aSettingsGlobal, mSearchValue, SystemConstants.gModuleGlobalID);

			}
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdCommon.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdCommon.setArray(aSettingsGlobal);
			grdCommon.Rebind(true);

			return;


			MessageBox.Show("Error : Invalid system preferences", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void ShowGLSettingTab()
		{
			DataSet rsLocalRec = null;

			if (!mGLSettingTabClicked)
			{
				rsLocalRec = new DataSet();
				aSettingsGL = new XArrayHelper();

				GetPreferencesInArray(rsLocalRec, aSettingsGL, mSearchValue, SystemConstants.gModuleGLID);

			}
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdCommon.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdCommon.setArray(aSettingsGL);
			grdCommon.Rebind(true);

		}

		private void ShowICSSettingTab()
		{
			DataSet rsLocalRec = null;

			if (!mICSSettingTabClicked)
			{
				rsLocalRec = new DataSet();
				aSettingsICS = new XArrayHelper();

				GetPreferencesInArray(rsLocalRec, aSettingsICS, mSearchValue, SystemConstants.gModuleICSID);

			}
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdCommon.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdCommon.setArray(aSettingsICS);
			grdCommon.Rebind(true);

		}

		private void ShowSalesSettingTab()
		{
			DataSet rsLocalRec = null;

			if (!mSalesSettingTabClicked)
			{
				rsLocalRec = new DataSet();
				aSettingsSales = new XArrayHelper();

				GetPreferencesInArray(rsLocalRec, aSettingsSales, mSearchValue, SystemConstants.gModuleSalesID);

			}
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdCommon.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdCommon.setArray(aSettingsSales);
			grdCommon.Rebind(true);

		}

		private void ShowPurchaseSettingTab()
		{
			DataSet rsLocalRec = null;

			if (!mPurchaseSettingTabClicked)
			{
				rsLocalRec = new DataSet();
				aSettingsPurchase = new XArrayHelper();

				GetPreferencesInArray(rsLocalRec, aSettingsPurchase, mSearchValue, SystemConstants.gModulePurchaseID);

			}
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdCommon.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdCommon.setArray(aSettingsPurchase);
			grdCommon.Rebind(true);

		}

		private void ShowHRSettingTab()
		{
			DataSet rsLocalRec = null;

			if (!mHRSettingTabClicked)
			{
				rsLocalRec = new DataSet();
				aSettingsHR = new XArrayHelper();

				GetPreferencesInArray(rsLocalRec, aSettingsHR, mSearchValue, SystemConstants.gModuleHRID);

			}
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdCommon.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdCommon.setArray(aSettingsHR);
			grdCommon.Rebind(true);

		}

		private void ShowPayrollSettingTab()
		{
			DataSet rsLocalRec = null;

			if (!mHRSettingTabClicked)
			{
				rsLocalRec = new DataSet();
				aSettingsPay = new XArrayHelper();

				GetPreferencesInArray(rsLocalRec, aSettingsPay, mSearchValue, SystemConstants.gModulePayID);

			}
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdCommon.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdCommon.setArray(aSettingsPay);
			grdCommon.Rebind(true);

		}

		private void GetPreferencesInArray(DataSet pRecordset, XArrayHelper pCurrentArray, int pCompanyID, int pModuleID)
		{
			string mysql = "";
			int cnt = 0;
			bool mIncludeInGrid = false;

			if (SystemVariables.gLoggedInUserGroupCode == SystemConstants.gDefaultAdminGroupCode)
			{
				mysql = "select ot.* ";
				mysql = mysql + " from SM_MENU ot ";
				mysql = mysql + " inner join SM_MODULES sm on ot.module_id = sm.module_id ";
				mysql = mysql + " inner join SM_Preferences sf on ot.feature_id = sf.preference_id ";
				mysql = mysql + " where ot.module_id = " + Conversion.Str(pModuleID);
				mysql = mysql + " and sf.preference_value = '1' ";
				mysql = mysql + " and sm.show = 1 ";
				//    mysql = mysql & " and ot.protected = 0 "
				mysql = mysql + " and ot.menu_item_type in (1, 2) and ot.Menu_Level <> 0";
				mysql = mysql + " order by menu_id ";
			}
			else
			{
				mysql = "select ot.* ";
				mysql = mysql + " from SM_MENU ot ";
				mysql = mysql + " inner join SM_MODULES sm on ot.module_id = sm.module_id ";
				mysql = mysql + " inner join SM_Preferences sf on ot.feature_id = sf.preference_id ";
				mysql = mysql + " where ot.module_id = " + Conversion.Str(pModuleID);
				mysql = mysql + " and sf.preference_value = '1' ";
				mysql = mysql + " and sm.show = 1 ";
				mysql = mysql + " and ot.protected = 0 ";
				mysql = mysql + " and ot.menu_item_type in (1, 2) ";
				mysql = mysql + " and ot.show = 1";
				mysql = mysql + " order by menu_id ";
			}

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
					pCurrentArray.SetValue((((TriState) Convert.ToInt32(iteration_row["show"])) == TriState.False) ? TriState.False : TriState.True, cnt, gccShowSettingColumn);
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					pCurrentArray.SetValue((((TriState) Convert.ToInt32(iteration_row["enabled"])) == TriState.False) ? TriState.False : TriState.True, cnt, gccEnabledSettingColumn);
					pCurrentArray.SetValue(Convert.ToString(iteration_row["l_menu_name"]) + "", cnt, gccExternalSettingNameColumn);
					pCurrentArray.SetValue(Convert.ToString(iteration_row["a_menu_name"]) + "", cnt, gccExternalSettingANameColumn);
					pCurrentArray.SetValue(Convert.ToString(iteration_row["comments"]) + "", cnt, gccRemarksColumn);
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					pCurrentArray.SetValue((((TriState) Convert.ToInt32(iteration_row["Show_In_Shortcut_Bar"])) == TriState.False) ? TriState.False : TriState.True, cnt, gccShowAsToolbarColumn);
					pCurrentArray.SetValue(iteration_row["ics_voucher_type"], cnt, gccVoucherTypeColumn);
					pCurrentArray.SetValue(iteration_row["Ribbon_Icon_Id"], cnt, gccIconIdColumn);
					pCurrentArray.SetValue(iteration_row["protected"], cnt, gccProtectedColumn);
					pCurrentArray.SetValue(iteration_row["menu_id"], cnt, gccInternalSettingNameColumn);
					pCurrentArray.SetValue(iteration_row["time_stamp"], cnt, gccTimeStampColumn);

					cnt++;
				}
			}
		}
	}
}