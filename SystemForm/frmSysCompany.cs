
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmSysCompany
		: System.Windows.Forms.Form
	{


		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private object mSearchValue = null;
		private string mTimeStamp = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		private const int ctCompanyCode = 0;
		private const int ctCompanyNameEnglish = 1;
		private const int ctCompanyNameArabic = 2;
		private const int ctDBFileName = 3;
		private const int ctAddress1 = 4;
		private const int ctAddress2 = 5;
		private const int ctDBBackEnd = 6;
		private const int ctProductKey = 7;

		private const int cdCurrentPeriodStartDate = 0;
		private const int cdCurrentPeriodEndDate = 1;
		private const int cdNextPeriodStartDate = 2;
		private const int cdNextPeriodEndDate = 3;
		private const int cdLastBackupDate = 4;

		private const int clSystemEdition = 0;
		private const int clSystemColorScheme = 1;
		private const int clCompany = 2;

		private const int coDefaultSetting = 0;
		private const int coExistingSetting = 1;

		private const int ccImportPreferenceAndSettings = 0;
		private const int ccImportGLVoucherSetting = 1;
		private const int ccImportICSVoucherSetting = 2;
		private const int ccImportGLMasterData = 3;
		private const int ccImportICSMasterData = 4;
		private const int ccImportExactReplica = 5;

		private const int clblDBBackEnd = 13;
		private const int clblProductKey = 14;
		private const int clblSystemEdition = 15;
		private const int clblSystemColorScheme = 16;

		
		public frmSysCompany()
{
InitializeComponent();
} 
 public  void frmSysCompany_old()
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

		public Control FirstFocusObject = null;

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


		private void chkCommon_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chkCommon, eventSender);
			int cnt = 0;
			if (Index == ccImportExactReplica)
			{
				if (chkCommon[ccImportExactReplica].CheckState == CheckState.Checked)
				{
					for (cnt = ccImportPreferenceAndSettings; cnt <= ccImportICSMasterData; cnt++)
					{
						chkCommon[cnt].CheckState = CheckState.Unchecked;
						chkCommon[cnt].Enabled = false;
					}
				}
				else
				{
					for (cnt = ccImportPreferenceAndSettings; cnt <= ccImportICSMasterData; cnt++)
					{
						chkCommon[cnt].CheckState = CheckState.Unchecked;
						chkCommon[cnt].Enabled = true;
					}
				}
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
			string mysql = "";

			try
			{

				FirstFocusObject = txtCommon[ctCompanyCode];
				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;
				//
				//'assign the Image for the toolbar
				//'imagelist are kept on the main form and refered by their key
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture

				SystemProcedure.SetLabelCaption(this);
				//If gPreferedLanguage = Arabic And rsCompanyProperties("flip_controls_in_arabic").Value = vbTrue Then
				//    Dim oFlipThisForm As New clsFlip
				//
				//    oFlipThisForm.SwapMe Me
				//End If

				cmbCommon[clSystemEdition].AddItem("Standard");
				cmbCommon[clSystemEdition].SetItemData(cmbCommon[clSystemEdition].NewIndex, 1);
				cmbCommon[clSystemEdition].AddItem("Professional");
				cmbCommon[clSystemEdition].SetItemData(cmbCommon[clSystemEdition].NewIndex, 2);
				cmbCommon[clSystemEdition].AddItem("Enterprise");
				cmbCommon[clSystemEdition].SetItemData(cmbCommon[clSystemEdition].NewIndex, 3);
				if (cmbCommon[clSystemEdition].ListCount > 0)
				{
					cmbCommon[clSystemEdition].ListIndex = 0;
				}


				mysql = " select ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_scheme_name " : " a_scheme_name ");
				mysql = mysql + " , scheme_id from SM_COLOR_SCHEMA ";
				SystemCombo.FillComboWithItemData(cmbCommon[clSystemColorScheme], mysql);
				if (cmbCommon[clSystemColorScheme].ListCount > 0)
				{
					cmbCommon[clSystemColorScheme].ListIndex = 0;
				}

				mysql = " select ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_comp_name " : " a_comp_name ");
				mysql = mysql + " , comp_id from SM_COMPANY ";
				SystemCombo.FillComboWithItemData(cmbCommon[clCompany], mysql);
				if (cmbCommon[clCompany].ListCount > 0)
				{
					cmbCommon[clCompany].ListIndex = 0;
				}

				lblCommon[clblSystemEdition].Visible = SystemVariables.gXtremeAdminLoggedIn;
				cmbCommon[clSystemEdition].Visible = SystemVariables.gXtremeAdminLoggedIn;
				lblCommon[clblSystemColorScheme].Visible = SystemVariables.gXtremeAdminLoggedIn;
				cmbCommon[clSystemColorScheme].Visible = SystemVariables.gXtremeAdminLoggedIn;

				lblCommon[clblDBBackEnd].Visible = SystemVariables.gXtremeAdminLoggedIn;
				txtCommon[ctDBBackEnd].Visible = SystemVariables.gXtremeAdminLoggedIn;
				lblCommon[clblProductKey].Visible = SystemVariables.gXtremeAdminLoggedIn;
				txtCommon[ctProductKey].Visible = SystemVariables.gXtremeAdminLoggedIn;

				tabMaster.CurrTab = 0;

				//**--make the form visible before all the control gets loaded
				//**--(this way system pretends to be faster in loading forms)
				this.Show();
				Application.DoEvents();
				//**-------------------------------------------------------------------------------------------

				GetNextNumber();
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
				frmSysCompany.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void GetNextNumber()
		{
			txtCommon[ctCompanyCode].Text = SystemProcedure2.GetNewNumber("SM_COMPANY", "comp_id");
			FirstFocusObject.Focus();
		}

		private bool isInitializingComponent;
		private void optPreferenceSettings_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.optPreferenceSettings, eventSender);
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				int cnt = 0;
				if (Index == coDefaultSetting)
				{
					cmbCommon[clCompany].Enabled = false;
					for (cnt = ccImportPreferenceAndSettings; cnt <= ccImportExactReplica; cnt++)
					{
						chkCommon[cnt].CheckState = CheckState.Unchecked;
						chkCommon[cnt].Enabled = false;
					}
				}
				else if (Index == coExistingSetting)
				{ 
					cmbCommon[clCompany].Enabled = true;
					for (cnt = ccImportPreferenceAndSettings; cnt <= ccImportExactReplica; cnt++)
					{
						chkCommon[cnt].CheckState = CheckState.Unchecked;
						chkCommon[cnt].Enabled = true;
					}
				}
			}
		}

		private void txtCommon_DropButtonClick(Object Sender, EventArgs e)
		{
			GetNextNumber();
		}

		public void CloseForm()
		{
			this.Close();
		}

		private void txtCommon_KeyPress(Object Sender, System.Windows.Forms.TextBox.KeyPressEventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);
			int KeyAscii = e.KeyAscii;
			try
			{
				if (Index == ctDBFileName)
				{
					if (KeyAscii == 32)
					{
						KeyAscii = 0;
					}
				}
			}
			finally
			{
				e.KeyAscii = KeyAscii;
			}
		}

		private void txtCommonDate_Change(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonDate, Sender);
			System.DateTime mdate = DateTime.FromOADate(0);
			if (Index == cdCurrentPeriodStartDate)
			{
				if (Information.IsDate(txtCommonDate[cdCurrentPeriodStartDate].Value))
				{
					txtCommonDate[cdCurrentPeriodEndDate].Value = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[cdCurrentPeriodStartDate].Value).AddYears(1).AddDays(-1);

					txtCommonDate[cdNextPeriodStartDate].Value = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[cdCurrentPeriodStartDate].Value).AddYears(1);
					txtCommonDate[cdNextPeriodEndDate].Value = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[cdCurrentPeriodStartDate].Value).AddYears(2).AddDays(-1);
				}
			}
		}

		public void findRecord()
		{
			//Call the find window
			string mysql = "";

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1, "", mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			try
			{
				string mysql = "";
				object mReturnValue = null;
				SqlDataReader localRec = null;


				mysql = " select * from SM_COMPANY where comp_id= " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{
					mSearchValue = localRec["comp_id"];
					mTimeStamp = Convert.ToString(localRec["time_stamp"]);
					txtCommon[ctCompanyCode].Text = Convert.ToString(localRec["comp_id"]);

					txtCommon[ctCompanyNameEnglish].Text = Convert.ToString(localRec["l_comp_name"]);
					txtCommon[ctCompanyNameArabic].Text = Convert.ToString(localRec["a_comp_name"]);
					txtCommon[ctDBFileName].Text = Convert.ToString(localRec["db_alias"]);

					txtCommon[ctAddress1].Text = Convert.ToString(localRec["addr_1"]) + "";
					txtCommon[ctAddress2].Text = Convert.ToString(localRec["addr_2"]) + "";
					txtCommon[ctDBBackEnd].Text = Convert.ToString(localRec["db_backend"]);
					txtCommon[ctProductKey].Text = Convert.ToString(localRec["product_key"]);

					txtCommonDate[cdCurrentPeriodStartDate].Value = localRec["current_period_start_date"];
					txtCommonDate[cdCurrentPeriodEndDate].Value = localRec["current_period_end_date"];
					txtCommonDate[cdNextPeriodStartDate].Value = localRec["next_period_start_date"];
					txtCommonDate[cdNextPeriodEndDate].Value = localRec["next_period_end_date"];
					if (!Convert.IsDBNull(localRec["last_backup_date"]))
					{
						txtCommonDate[cdLastBackupDate].Value = localRec["last_backup_date"];
					}
					else
					{
						txtCommonDate[cdLastBackupDate].Text = "";
					}

					SystemCombo.SearchCombo(cmbCommon[clSystemEdition], Convert.ToInt32(localRec["system_edition"]));
					SystemCombo.SearchCombo(cmbCommon[clSystemColorScheme], Convert.ToInt32(localRec["color_scheme_id"]));

					txtComment.Text = Convert.ToString(localRec["Comments"]) + "";

					fraInitialCompanyLevelPreferences.Enabled = false;
					txtCommon[ctCompanyCode].Enabled = false;
					txtCommon[ctDBFileName].Enabled = false;
					txtCommonDate[cdCurrentPeriodStartDate].Enabled = false;
					//txtCommonDate(cdCurrentPeriodStartDate).BackColor = &HD5D5D5

					//Change the form mode to edit
					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				}
				localRec.Close();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}

		}

		public void AddRecord()
		{
			SystemProcedure2.ClearTextBox(this);
			txtCommon[ctCompanyCode].Text = SystemProcedure2.GetNewNumber("SM_COMPANY", "comp_id");

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			mSearchValue = "";

			fraInitialCompanyLevelPreferences.Enabled = true;
			txtCommon[ctCompanyCode].Enabled = true;
			txtCommon[ctDBFileName].Enabled = true;
			txtCommonDate[cdCurrentPeriodStartDate].Enabled = true;
			//txtCommonDate(cdCurrentPeriodStartDate).BackColor = vbWhite

			FirstFocusObject.Focus();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool CheckDataValidity()
		{


			if (SystemProcedure2.IsItEmpty(txtCommon[ctCompanyCode].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Company Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (txtCommon[ctCompanyCode].Enabled)
				{
					txtCommon[ctCompanyCode].Focus();
				}
			}
			else
			{

				if (SystemProcedure2.IsItEmpty(txtCommon[ctCompanyNameEnglish].Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Company Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (txtCommon[ctCompanyNameEnglish].Enabled)
					{
						txtCommon[ctCompanyNameEnglish].Focus();
					}
				}
				else
				{

					if (SystemProcedure2.IsItEmpty(txtCommon[ctCompanyNameArabic].Text, SystemVariables.DataType.StringType))
					{
						MessageBox.Show("Enter Company Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						if (txtCommon[ctCompanyNameArabic].Enabled)
						{
							txtCommon[ctCompanyNameArabic].Focus();
						}
					}
					else
					{

						if (SystemProcedure2.IsItEmpty(txtCommon[ctDBFileName].Text, SystemVariables.DataType.StringType))
						{
							MessageBox.Show("Enter DB File Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
							if (txtCommon[ctDBFileName].Enabled)
							{
								txtCommon[ctDBFileName].Focus();
							}
						}
						else
						{

							if (!Information.IsDate(txtCommonDate[cdCurrentPeriodStartDate].Value))
							{
								MessageBox.Show("Enter valid date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
								if (txtCommonDate[cdCurrentPeriodStartDate].Enabled)
								{
									txtCommonDate[cdCurrentPeriodStartDate].Focus();
								}
							}
							else
							{

								return true;

							}
						}
					}
				}
			}

			return false;

		}

		public bool saveRecord()
		{
			bool result = false;
			object mReturnValue = null;
			string mysql = "";

			//On Error GoTo eFoundError

			SystemVariables.gConn.BeginTransaction();

			clsHourGlass myHourGlass = new clsHourGlass();

			string mCheckTimeStamp = "";
			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{

				mysql = " select comp_id from SM_COMPANY ";
				mysql = mysql + " where comp_id = " + txtCommon[ctCompanyCode].Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show(" Duplicate Company code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (txtCommon[ctCompanyCode].Enabled)
					{
						txtCommon[ctCompanyCode].Focus();
					}
					return false;
				}

				mysql = " select name from master..sysdatabases ";
				mysql = mysql + " where name ='" + txtCommon[ctDBFileName].Text.Trim() + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show(" Duplicate DB File name!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (txtCommon[ctDBFileName].Enabled)
					{
						txtCommon[ctDBFileName].Focus();
					}

					return false;
				}

				mysql = " insert into SM_COMPANY ";
				mysql = mysql + " (comp_id, l_comp_name, a_comp_name, db_alias ";
				mysql = mysql + " , current_period_start_date, current_period_end_date";
				mysql = mysql + " , next_period_start_date, next_period_end_date, addr_1, addr_2 ";
				if (SystemVariables.gXtremeAdminLoggedIn)
				{
					mysql = mysql + " , color_scheme_id, ICS_Item_key, system_edition";
				}
				mysql = mysql + " , comments, user_cd) ";
				mysql = mysql + " values(";
				mysql = mysql + txtCommon[ctCompanyCode].Text;
				mysql = mysql + ",'" + txtCommon[ctCompanyNameEnglish].Text + "'";
				mysql = mysql + ",N'" + txtCommon[ctCompanyNameArabic].Text + "'";
				mysql = mysql + ",'" + txtCommon[ctDBFileName].Text + "'";
				mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[cdCurrentPeriodStartDate].Value) + "'";
				mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[cdCurrentPeriodEndDate].Value) + "'";
				mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[cdNextPeriodStartDate].Value) + "'";
				mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[cdNextPeriodEndDate].Value) + "'";
				mysql = mysql + ",N'" + txtCommon[ctAddress1].Text + "'";
				mysql = mysql + ",N'" + txtCommon[ctAddress2].Text + "'";

				if (SystemVariables.gXtremeAdminLoggedIn)
				{
					mysql = mysql + "," + cmbCommon[clSystemColorScheme].GetItemData(cmbCommon[clSystemColorScheme].ListIndex).ToString();
					mysql = mysql + ",'" + txtCommon[ctProductKey].Text + "'";
					mysql = mysql + "," + cmbCommon[clSystemEdition].GetItemData(cmbCommon[clSystemEdition].ListIndex).ToString();
				}

				mysql = mysql + ",'" + txtComment.Text + "'";
				mysql = mysql + "," + Conversion.Str(SystemVariables.gLoggedInUserCode);
				mysql = mysql + ")";

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mysql = " update SM_COMPANY ";
				mysql = mysql + " set ";
				mysql = mysql + " ICS_Item_key= ";
				mysql = mysql + " ( select top 1 ICS_Item_key from SM_COMPANY ";
				mysql = mysql + " where protected = 1 ) ";
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();
			}
			else
			{
				mysql = " select time_stamp,protected from SM_COMPANY where comp_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				}
				else
				{
					MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					result = false;
					if (ControlHelper.GetEnabled(FirstFocusObject))
					{
						FirstFocusObject.Focus();
					}
					return result;
				}
				if (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp))
				{
					MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					result = false;
					if (ControlHelper.GetEnabled(FirstFocusObject))
					{
						FirstFocusObject.Focus();
					}
					return result;
				}


				mysql = " update SM_COMPANY set ";
				mysql = mysql + " l_comp_name ='" + txtCommon[ctCompanyNameEnglish].Text + "'";
				mysql = mysql + ", a_comp_name =N'" + txtCommon[ctCompanyNameArabic].Text + "'";
				mysql = mysql + ", addr_1 =N'" + txtCommon[ctAddress1].Text + "'";
				mysql = mysql + ", addr_2 =N'" + txtCommon[ctAddress2].Text + "'";
				mysql = mysql + ", comments =N'" + txtComment.Text + "'";
				if (SystemVariables.gXtremeAdminLoggedIn)
				{
					mysql = mysql + ", color_scheme_id= " + cmbCommon[clSystemColorScheme].GetItemData(cmbCommon[clSystemColorScheme].ListIndex).ToString();
					mysql = mysql + ", ICS_Item_key='" + txtCommon[ctProductKey].Text + "'";
					mysql = mysql + ", system_edition=" + cmbCommon[clSystemEdition].GetItemData(cmbCommon[clSystemEdition].ListIndex).ToString();
				}

				mysql = mysql + ", user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
				mysql = mysql + " where comp_id=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();



			}
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				RestoreDatabase(txtCommon[ctDBFileName].Text);
			}



			return true;


			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			return false;
		}


		private bool RestoreDatabase(string pRestoreDBName)
		{
			bool result = false;
			string mysql = "";
			string mDataLogicalName = "";
			string mLogLogicalName = "";

			string mSourceDBPath = "";
			string mSourceDBName = "";
			string mDataFilePath = "";
			string mBackupFileName = "";
			object mReturnValue = null;

			//On Error GoTo mend

			string mBackupPath = "c:\\";
			string mDefaultDBName = "Demo";

			if (optPreferenceSettings[coExistingSetting].Checked == (TriState.True != TriState.False))
			{
				mysql = " select db_alias from SM_COMPANY ";
				mysql = mysql + " where comp_id=" + cmbCommon[clCompany].GetItemData(cmbCommon[clCompany].ListIndex).ToString();

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSourceDBName = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
				else
				{
					MessageBox.Show("Invalid Database!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}

			if (chkCommon[ccImportExactReplica].CheckState == CheckState.Checked)
			{
				mBackupFileName = (mSourceDBName + "_backup_" + StringsHelper.Format(DateTime.Today, "dd_mmm_yyyy") + "_" + StringsHelper.Format(DateTimeHelper.Time, "hh_mm")).ToLower();

				mysql = "backup database " + mSourceDBName + " to disk='" + mBackupPath + mBackupFileName + "'";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mSourceDBPath = mBackupPath + mBackupFileName;
			}
			else
			{
				//mSourceDBName = mDefaultDBName
				mSourceDBPath = mBackupPath + mDefaultDBName;
			}

			mysql = " RESTORE FILELISTONLY   FROM DISK = '" + mSourceDBPath + "' ";
			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			bool rsTempRecDidRead = rsTempRec.Read();
			if (rsTempRecDidRead)
			{
				mDataLogicalName = Convert.ToString(rsTempRec[0]);
				rsTempRecDidRead = rsTempRec.Read();
				mLogLogicalName = Convert.ToString(rsTempRec[0]);
			}
			else
			{
				MessageBox.Show("Invalid file found!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			rsTempRec.Close();

			mysql = " select filename from sysfiles ";
			SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand_2.ExecuteReader();
			bool rsTempRecDidRead2 = rsTempRec.Read();
			if (rsTempRecDidRead)
			{
				mysql = Convert.ToString(rsTempRec[0]).Trim();
				mDataFilePath = mysql.Substring(0, Math.Min(GetLastSlashPosition(mysql), mysql.Length));
			}
			else
			{
				MessageBox.Show("Invalid output from sysfiles!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			rsTempRec.Close();


			mysql = " restore database " + pRestoreDBName;
			mysql = mysql + " from disk = '" + mSourceDBPath + "' ";
			mysql = mysql + " with move '" + mDataLogicalName + "' TO '" + mDataFilePath + pRestoreDBName + ".mdf' ";
			mysql = mysql + " , move '" + mLogLogicalName + "' TO '" + mDataFilePath + pRestoreDBName + ".ldf'";
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();


			SystemVariables.gConn.BeginTransaction();

			if (chkCommon[ccImportICSVoucherSetting].CheckState == CheckState.Checked)
			{
				ImportICSVoucherSetting(mSourceDBName, pRestoreDBName);
			}

			if (chkCommon[ccImportICSMasterData].CheckState == CheckState.Checked)
			{
				ImportICSMasterData(mSourceDBName, pRestoreDBName);
			}

			if (chkCommon[ccImportGLVoucherSetting].CheckState == CheckState.Checked)
			{
				ImportGLVoucherSetting(mSourceDBName, pRestoreDBName);
			}

			if (chkCommon[ccImportGLMasterData].CheckState == CheckState.Checked)
			{
				ImportGLMasterData(mSourceDBName, pRestoreDBName);
			}

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();



			return true;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		private int GetLastSlashPosition(string pString)
		{
			int cnt = 0;
			int cnt1 = 0;


			while(true)
			{
				cnt = Strings.InStr(cnt1 + 1, pString, "\\", CompareMethod.Binary);
				if (cnt != 0)
				{
					cnt1 = cnt;
				}
				else
				{
					return cnt1;
				}
			};
			return 0;
		}

		private string GetInsertSql(string pOrigDBName, string pDestDBName, string pTableName, string pWhereClause = "")
		{
			StringBuilder mInsertColumnName = new StringBuilder();
			StringBuilder mSelectColumnName = new StringBuilder();

			int mTableHasIdentity = 0;

			string mysql = " select sc.name ";
			mysql = mysql + " from " + pOrigDBName + "..syscolumns sc ";
			mysql = mysql + " inner join " + pOrigDBName + "..sysobjects so on sc.id = so.id ";
			mysql = mysql + " inner join " + pDestDBName + "..syscolumns sc2 on sc.name = sc2.name ";
			mysql = mysql + " inner join " + pDestDBName + "..sysobjects so2 on sc2.id = so2.id ";
			mysql = mysql + " where so.name ='" + pTableName + "'";
			mysql = mysql + " and so2.name ='" + pTableName + "'";
			mysql = mysql + " and so.xtype = 'u' ";
			mysql = mysql + " and sc.xtype not in (34, 36, 98, 189) ";
			mysql = mysql + " and sc.iscomputed = 0  ";
			mysql = mysql + " and sc.name = sc2.name ";
			SqlDataReader rsTableColumns = null;

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTableColumns = sqlCommand.ExecuteReader();
			rsTableColumns.Read();
			do 
			{
				if (mInsertColumnName.ToString() != "")
				{
					mInsertColumnName.Append(", " + Convert.ToString(rsTableColumns["name"]));
				}
				else
				{
					mInsertColumnName.Append(Convert.ToString(rsTableColumns["name"]));
				}

				if (mSelectColumnName.ToString() != "")
				{
					mSelectColumnName.Append(", " + Convert.ToString(rsTableColumns["name"]));
				}
				else
				{
					mSelectColumnName.Append(Convert.ToString(rsTableColumns["name"]));
				}

			}
			while(rsTableColumns.Read());
			rsTableColumns.Close();

			mysql = " select objectproperty ( object_id('" + pTableName + "'),'tablehasidentity') ";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mTableHasIdentity = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));
			if (mTableHasIdentity == 1)
			{
				mysql = " set identity_insert " + pDestDBName + ".." + pTableName + " on ";
			}
			else
			{
				mysql = "";
			}


			mysql = mysql + " insert into " + pDestDBName + ".." + pTableName;
			mysql = mysql + " (";
			mysql = mysql + mInsertColumnName.ToString();
			mysql = mysql + " )";
			mysql = mysql + " select ";
			mysql = mysql + mSelectColumnName.ToString();
			mysql = mysql + " from " + pOrigDBName + ".." + pTableName;

			mysql = mysql + " where 1=1 ";
			if (pWhereClause != "")
			{
				mysql = mysql + " and " + pWhereClause;
			}

			if (mTableHasIdentity == 1)
			{
				mysql = mysql + " set identity_insert " + pDestDBName + ".." + pTableName + " off ";
			}

			return mysql;


		}

		private void ImportICSVoucherSetting(string pOrigDBName, string pDestDBName)
		{

			string mysql = " delete from " + pDestDBName + ".." + "ICS_Transaction_Types";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = GetInsertSql(pOrigDBName, pDestDBName, "ICS_Transaction_Types");
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();
		}

		private void ImportGLVoucherSetting(string pOrigDBName, string pDestDBName)
		{

			string mString = " not exists( ";
			mString = mString + " select voucher_type from " + pDestDBName + "..accnt_voucher_types";
			mString = mString + " where voucher_type = " + pOrigDBName + "..accnt_voucher_types.voucher_type)";
			string mysql = GetInsertSql(pOrigDBName, pDestDBName, "accnt_voucher_types", mString);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = GetUpdateSql(pOrigDBName, pDestDBName, "accnt_voucher_types");
			mysql = mysql + " from " + pOrigDBName + "..accnt_voucher_types ot ";
			mysql = mysql + " inner join " + pDestDBName + "..accnt_voucher_types nt ";
			mysql = mysql + " on ot.voucher_type = nt.voucher_type ";
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

		}

		private void ImportGLMasterData(string pOrigDBName, string pDestDBName)
		{

			string mysql = " delete from " + pDestDBName + ".." + "location";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = " delete from " + pDestDBName + ".." + "accnt_voucher_types";
			mysql = mysql + " where protected = 0 ";
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

			mysql = " delete from " + pDestDBName + ".." + "gl_ledger";
			mysql = mysql + " where protected = 0 ";
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mysql;
			TempCommand_3.ExecuteNonQuery();

			mysql = " delete from " + pDestDBName + ".." + "gl_accnt_group";
			mysql = mysql + " where protected = 0 ";
			SqlCommand TempCommand_4 = null;
			TempCommand_4 = SystemVariables.gConn.CreateCommand();
			TempCommand_4.CommandText = mysql;
			TempCommand_4.ExecuteNonQuery();


			mysql = " alter table " + pDestDBName + "..gl_accnt_group ";
			mysql = mysql + " drop constraint CK_Accnt_Group_Type ";
			mysql = mysql + GetUpdateSql(pOrigDBName, pDestDBName, "gl_accnt_group");
			mysql = mysql + " from " + pOrigDBName + "..gl_accnt_group ot ";
			mysql = mysql + " inner join " + pDestDBName + "..gl_accnt_group nt ";
			mysql = mysql + " on ot.group_cd = nt.group_cd ";
			mysql = mysql + " alter table " + pDestDBName + "..gl_accnt_group ";
			mysql = mysql + " with nocheck add constraint CK_Accnt_Group_Type check ";
			mysql = mysql + " (([group_type] > 0 and [group_type] <= 4)) ";
			SqlCommand TempCommand_5 = null;
			TempCommand_5 = SystemVariables.gConn.CreateCommand();
			TempCommand_5.CommandText = mysql;
			TempCommand_5.ExecuteNonQuery();

			string mString = " not exists( ";
			mString = mString + " select group_cd from " + pDestDBName + "..gl_accnt_group ";
			mString = mString + " where group_cd = " + pOrigDBName + "..gl_accnt_group.group_cd)";
			mysql = GetInsertSql(pOrigDBName, pDestDBName, "gl_accnt_group", mString);
			SqlCommand TempCommand_6 = null;
			TempCommand_6 = SystemVariables.gConn.CreateCommand();
			TempCommand_6.CommandText = mysql;
			TempCommand_6.ExecuteNonQuery();


			mysql = GetUpdateSql(pOrigDBName, pDestDBName, "gl_ledger");
			mysql = mysql + " from " + pOrigDBName + "..gl_ledger ot ";
			mysql = mysql + " inner join " + pDestDBName + "..gl_ledger nt ";
			mysql = mysql + " on ot.ldgr_cd = nt.ldgr_cd ";
			SqlCommand TempCommand_7 = null;
			TempCommand_7 = SystemVariables.gConn.CreateCommand();
			TempCommand_7.CommandText = mysql;
			TempCommand_7.ExecuteNonQuery();

			mString = " not exists( ";
			mString = mString + " select ldgr_cd from " + pDestDBName + "..gl_ledger ";
			mString = mString + " where ldgr_cd = " + pOrigDBName + "..gl_ledger.ldgr_cd)";
			mysql = GetInsertSql(pOrigDBName, pDestDBName, "gl_ledger", mString);
			SqlCommand TempCommand_8 = null;
			TempCommand_8 = SystemVariables.gConn.CreateCommand();
			TempCommand_8.CommandText = mysql;
			TempCommand_8.ExecuteNonQuery();

			mysql = GetInsertSql(pOrigDBName, pDestDBName, "location");
			SqlCommand TempCommand_9 = null;
			TempCommand_9 = SystemVariables.gConn.CreateCommand();
			TempCommand_9.CommandText = mysql;
			TempCommand_9.ExecuteNonQuery();

			mysql = GetUpdateSql(pOrigDBName, pDestDBName, "accnt_voucher_types");
			mysql = mysql + " from " + pOrigDBName + "..accnt_voucher_types ot ";
			mysql = mysql + " inner join " + pDestDBName + "..accnt_voucher_types nt ";
			mysql = mysql + " on ot.voucher_type = nt.voucher_type ";
			SqlCommand TempCommand_10 = null;
			TempCommand_10 = SystemVariables.gConn.CreateCommand();
			TempCommand_10.CommandText = mysql;
			TempCommand_10.ExecuteNonQuery();

			mString = " not exists( ";
			mString = mString + " select voucher_type from " + pDestDBName + "..accnt_voucher_types";
			mString = mString + " where voucher_type = " + pOrigDBName + "..accnt_voucher_types.voucher_type)";
			mysql = GetInsertSql(pOrigDBName, pDestDBName, "accnt_voucher_types", mString);
			SqlCommand TempCommand_11 = null;
			TempCommand_11 = SystemVariables.gConn.CreateCommand();
			TempCommand_11.CommandText = mysql;
			TempCommand_11.ExecuteNonQuery();

		}

		private void ImportICSMasterData(string pOrigDBName, string pDestDBName)
		{

			string mysql = " delete from " + pDestDBName + ".." + "ICS_Item_Unit_Details";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = " delete from " + pDestDBName + ".." + "unit";
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

			mysql = " delete from " + pDestDBName + ".." + "ICS_Item";
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mysql;
			TempCommand_3.ExecuteNonQuery();

			mysql = " delete from " + pDestDBName + ".." + "ICS_Item_Group";
			SqlCommand TempCommand_4 = null;
			TempCommand_4 = SystemVariables.gConn.CreateCommand();
			TempCommand_4.CommandText = mysql;
			TempCommand_4.ExecuteNonQuery();

			//mySql = " delete from " & pDestDBName & ".." & "ICS_Item_Category"
			//gConn.Execute mySql

			mysql = GetInsertSql(pOrigDBName, pDestDBName, "unit");
			SqlCommand TempCommand_5 = null;
			TempCommand_5 = SystemVariables.gConn.CreateCommand();
			TempCommand_5.CommandText = mysql;
			TempCommand_5.ExecuteNonQuery();


			mysql = " alter table " + pDestDBName + "..ICS_Item_Group ";
			mysql = mysql + " drop constraint FK_Product_Group_Product_Group ";
			mysql = mysql + GetInsertSql(pOrigDBName, pDestDBName, "product_group");
			mysql = mysql + " alter table " + pDestDBName + "..ICS_Item_Group ";
			mysql = mysql + " add constraint FK_Product_Group_Product_Group ";
			mysql = mysql + " foreign key ( group_cd ) references dbo.ICS_Item_Group ( m_group_cd )";
			SqlCommand TempCommand_6 = null;
			TempCommand_6 = SystemVariables.gConn.CreateCommand();
			TempCommand_6.CommandText = mysql;
			TempCommand_6.ExecuteNonQuery();

			mysql = " alter table " + pDestDBName + "..ICS_Item_Category ";
			mysql = mysql + " drop constraint FK_Product_Category_Product_Category ";
			mysql = mysql + GetInsertSql(pOrigDBName, pDestDBName, "ICS_Item_Category");
			mysql = mysql + " alter table " + pDestDBName + "..ICS_Item_Category ";
			mysql = mysql + " add constraint FK_Product_Category_Product_Category ";
			mysql = mysql + " foreign key ( cat_cd ) references dbo.ICS_Item_Category ( m_cat_cd )";
			SqlCommand TempCommand_7 = null;
			TempCommand_7 = SystemVariables.gConn.CreateCommand();
			TempCommand_7.CommandText = mysql;
			TempCommand_7.ExecuteNonQuery();

			mysql = GetInsertSql(pOrigDBName, pDestDBName, "ICS_Item");
			SqlCommand TempCommand_8 = null;
			TempCommand_8 = SystemVariables.gConn.CreateCommand();
			TempCommand_8.CommandText = mysql;
			TempCommand_8.ExecuteNonQuery();

			mysql = GetInsertSql(pOrigDBName, pDestDBName, "ICS_Item_Unit_Details");
			SqlCommand TempCommand_9 = null;
			TempCommand_9 = SystemVariables.gConn.CreateCommand();
			TempCommand_9.CommandText = mysql;
			TempCommand_9.ExecuteNonQuery();

		}


		private string GetUpdateSql(string pOrigDBName, string pDestDBName, string pTableName)
		{
			StringBuilder mUpdateColumnName = new StringBuilder();

			string mysql = " select sc.name ";
			mysql = mysql + " from " + pOrigDBName + "..syscolumns sc ";
			mysql = mysql + " inner join " + pOrigDBName + "..sysobjects so on sc.id = so.id ";
			mysql = mysql + " inner join " + pDestDBName + "..syscolumns sc2 on sc.name = sc2.name ";
			mysql = mysql + " inner join " + pDestDBName + "..sysobjects so2 on sc2.id = so2.id ";
			mysql = mysql + " where so.name ='" + pTableName + "'";
			mysql = mysql + " and so2.name ='" + pTableName + "'";
			mysql = mysql + " and so.xtype = 'u' ";
			mysql = mysql + " and sc.xtype not in (34, 36, 98, 189, 127) ";
			mysql = mysql + " and sc.iscomputed = 0  ";
			mysql = mysql + " and sc.name = sc2.name ";
			SqlDataReader rsTableColumns = null;

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTableColumns = sqlCommand.ExecuteReader();
			rsTableColumns.Read();
			do 
			{
				if (mUpdateColumnName.ToString() != "")
				{
					mUpdateColumnName.Append(", " + Convert.ToString(rsTableColumns["name"]) + " = ot." + Convert.ToString(rsTableColumns["name"]));
				}
				else
				{
					mUpdateColumnName = new StringBuilder(Convert.ToString(rsTableColumns["name"]) + " = ot." + Convert.ToString(rsTableColumns["name"]));
				}

			}
			while(rsTableColumns.Read());
			rsTableColumns.Close();

			mysql = " update " + pDestDBName + ".." + pTableName;
			mysql = mysql + " set ";
			mysql = mysql + mUpdateColumnName.ToString();

			return mysql;

		}
	}
}