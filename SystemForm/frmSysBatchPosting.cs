
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSysBatchPosting
		: System.Windows.Forms.Form
	{

		public frmSysBatchPosting()
{
InitializeComponent();
} 
 public  void frmSysBatchPosting_old()
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


		private void frmSysBatchPosting_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		//This class checks for the rights given to the user
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

		const int NUM_STEPS = 4;

		const int RES_ERROR_MSG = 30000;

		//BASE VALUE FOR HELP FILE FOR THIS WIZARD:
		const int HELP_BASE = 1000;
		const string HELP_FILE = "MYWIZARD.HLP";

		const int BTN_HELP = 0;
		const int BTN_CANCEL = 1;
		const int BTN_BACK = 2;
		const int BTN_NEXT = 3;
		const int BTN_FINISH = 4;

		const int STEP_INTRO = 0;
		const int STEP_1 = 1;
		const int STEP_2 = 2;
		const int STEP_FINISH = 3;

		const int DIR_NONE = 0;
		const int DIR_BACK = 1;
		const int DIR_NEXT = 2;

		const string FRM_TITLE = "Blank Wizard";
		const string INTRO_KEY = "IntroductionScreen";
		const string SHOW_INTRO = "ShowIntro";
		const string TOPIC_TEXT = "<TOPIC_TEXT>";

		//module level vars
		int mnCurStep = 0;
		bool mbHelpStarted = false;

		bool mbFinishOK = false;
		private int ThisModuleID = 0;

		const int mGlVoucher = 2;
		const int mPurchaseVoucher = 5;
		const int mSalesVoucher = 6;
		const int mInventoryVoucher = 7;

		private SystemICSConstants.ShowOptions mPostOptionType = (SystemICSConstants.ShowOptions) 0;

		private const int ccIncludeAllVoucherTypesIndex = 0;
		private const int ccIncludeAllLocationsIndex = 1;

		private const int ccPostStatusIndex = 0;
		private const int ccPostToICSIndex = 1;
		private const int ccPostToGLSIndex = 2;
		private const int ccPostGLPartyIndex = 3;
		private const int ccPostGLExpenseIndex = 4;
		private const int ccPostGLInventoryIndex = 5;

		bool mPostingActive = false;

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


		private void cmbModule_Click(Object Sender, EventArgs e)
		{
			ThisModuleID = cmbModule.GetItemData(cmbModule.ListIndex);
			if (ThisModuleID == mGlVoucher)
			{
				SetGLVoucherType();
			}
			else
			{
				SetInvntVoucherType();
			}
		}

		private void SetInvntVoucherType()
		{
			string mysql = "";
			try
			{

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("multiple_location")))
				{
					cmbLocation.Enabled = true;
					chkCommonInclude[1].Enabled = true;
				}
				else
				{
					cmbLocation.Enabled = false;
					chkCommonInclude[1].Enabled = false;
				}

				//**-------------------------------------------------------------------------------------------

				//**--fill voucher types
				mysql = mysql + " select distinct " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name as voucher_name," : "a_voucher_name as voucher_name, ");
				mysql = mysql + " voucher_type  ";
				mysql = mysql + " from ICS_Transaction_Types ot ";
				mysql = mysql + " inner join SM_USER_GROUP_RIGHTS sugr ";
				mysql = mysql + " on ot.voucher_type = sugr.invnt_voucher_type ";
				mysql = mysql + " inner join SM_USER_GROUPS sug ";
				mysql = mysql + " on sugr.group_cd = sug.group_cd ";
				mysql = mysql + " inner join SM_USERS su ";
				mysql = mysql + " on sug.group_cd = su.group_cd ";
				mysql = mysql + " inner join SM_Preferences sf ";
				mysql = mysql + " on ot.feature_id = sf.preference_id ";
				mysql = mysql + " where su.user_cd = " + Conversion.Str(SystemVariables.gLoggedInUserCode);
				mysql = mysql + " and sugr.right_level <> 0 ";
				mysql = mysql + " and ot.show = 1 ";
				mysql = mysql + " and ot.Show_In_Periodical_Batch_Post = 1 ";
				mysql = mysql + " and sf.preference_value = '1' ";
				//'commented by Moiz Hakimion 24-dec-2006
				if (ThisModuleID != SystemConstants.gModuleICSID)
				{
					mysql = mysql + " and ot.module_id = " + Conversion.Str(ThisModuleID);
				}
				mysql = mysql + " order by 2 ";

				SystemCombo.FillComboWithItemData(cmbVoucherTypes, mysql);
				if (cmbVoucherTypes.ListCount > 0)
				{
					cmbVoucherTypes.ListIndex = 0;
				}

				//**--fill locations
				if (cmbLocation.Visible)
				{
					mysql = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name");
					mysql = mysql + " , locat_cd from SM_Location ";
					SystemCombo.FillComboWithItemData(cmbLocation, mysql);
					if (cmbLocation.ListCount > 0)
					{
						cmbLocation.ListIndex = 0;
					}
				}
				//**-------------------------------------------------------------------------------------------

				VoucherFrame.Enabled = true;
			}
			catch (System.Exception excep)
			{

				mysql = excep.Message;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();

					MessageBox.Show("Error : Unable to post transactions " + "\r" + mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
		}

		private void SetGLVoucherType()
		{
			string mysql = "";
			try
			{

				cmbLocation.Enabled = false;
				chkCommonInclude[1].Enabled = false;


				//**-------------------------------------------------------------------------------------------

				//**--fill voucher types
				mysql = "select distinct " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name as voucher_name," : "a_voucher_name as voucher_name, ");
				mysql = mysql + " voucher_type  from gl_accnt_voucher_types ot ";
				mysql = mysql + " inner join SM_USER_GROUP_RIGHTS sugr ";
				mysql = mysql + " on ot.voucher_type = sugr.accnt_voucher_type ";
				mysql = mysql + " inner join SM_USER_GROUPS sug ";
				mysql = mysql + " on sugr.group_cd = sug.group_cd ";
				mysql = mysql + " inner join SM_USERS su ";
				mysql = mysql + " on sug.group_cd = su.group_cd ";
				mysql = mysql + " where su.user_cd =   " + Conversion.Str(SystemVariables.gLoggedInUserCode);
				mysql = mysql + " and sugr.right_level <> 0 and ot.show = 1 ";

				if (ThisModuleID != SystemConstants.gModuleGLID)
				{
					mysql = mysql + " and ot.module_id = " + Conversion.Str(ThisModuleID);
				}
				mysql = mysql + " order by 2 ";

				SystemCombo.FillComboWithItemData(cmbVoucherTypes, mysql);
				if (cmbVoucherTypes.ListCount > 0)
				{
					cmbVoucherTypes.ListIndex = 0;
				}
				//**-------------------------------------------------------------------------------------------

				VoucherFrame.Enabled = true;
			}
			catch (System.Exception excep)
			{

				mysql = excep.Message;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();

					MessageBox.Show("Error : Unable to post transactions " + "\r" + mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
		}

		private void cmdDefaultSetting_Click(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			int cnt = 0;

			DialogResult ans = MessageBox.Show("Changing default post options will change the way voucher are posted to the system by default. This might lead you to unexpected results. Consult with your system manual / systems administrator for more details. Do you still want to continue with changes?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if (ans == System.Windows.Forms.DialogResult.Yes)
			{
				SystemVariables.gConn.BeginTransaction();
				mysql = " update ICS_Transaction_Types set ";
				mysql = mysql + " batch_post_status = " + ((chkCommonPost[ccPostStatusIndex].CheckState == CheckState.Checked) ? "1" : "0");
				mysql = mysql + " , batch_post_ics = " + ((chkCommonPost[ccPostToICSIndex].CheckState == CheckState.Checked) ? "1" : "0");
				mysql = mysql + " , batch_post_gl_party = " + ((chkCommonPost[ccPostGLPartyIndex].CheckState == CheckState.Checked) ? "1" : "0");
				mysql = mysql + " , batch_post_gl_expense = " + ((chkCommonPost[ccPostGLExpenseIndex].CheckState == CheckState.Checked) ? "1" : "0");
				mysql = mysql + " , batch_post_gl_inventory = " + ((chkCommonPost[ccPostGLInventoryIndex].CheckState == CheckState.Checked) ? "1" : "0");
				mysql = mysql + " , batch_post_gl = " + ((chkCommonPost[ccPostGLInventoryIndex].CheckState == CheckState.Checked) ? "1" : "0");
				mysql = mysql + " where voucher_type = ";

				if (chkCommonInclude[ccIncludeAllVoucherTypesIndex].CheckState == CheckState.Unchecked)
				{
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql + cmbVoucherTypes.GetItemData(cmbVoucherTypes.ListIndex).ToString();
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					int tempForEndVar = cmbVoucherTypes.ListCount - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql + cmbVoucherTypes.GetItemData(cnt).ToString();
						TempCommand_2.ExecuteNonQuery();
					}
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

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
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void cmdNav_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmdNav, eventSender);
			int nAltStep = 0;
			int lHelpTopic = 0;
			int rc = 0;

			switch(Index)
			{
				case BTN_HELP : 
					mbHelpStarted = true; 
					lHelpTopic = HELP_BASE + 10 * (1 + mnCurStep); 
					//rc = WinHelp(Me.hWnd, HELP_FILE, HELP_CONTEXT, lHelpTopic) 
					 
					break;
				case BTN_CANCEL : 
					this.Close(); 
					 
					break;
				case BTN_BACK : 
					//place special cases here to jump 
					//to alternate steps 
					nAltStep = mnCurStep - 1; 
					SetStep(nAltStep, DIR_BACK); 
					 
					break;
				case BTN_NEXT : 
					//place special cases here to jump 
					//to alternate steps 
					if (ValidateData(mnCurStep))
					{
						nAltStep = mnCurStep + 1;
						SetStep(nAltStep, DIR_NEXT);
					} 
					break;
				case BTN_FINISH : 
					//wizard creation code goes here 
					if (STEP_FINISH == mnCurStep)
					{
						this.Close();
					}
					else if (ValidateData(mnCurStep))
					{ 
						nAltStep = STEP_FINISH;
						SetStep(nAltStep, DIR_NEXT);
					} 
					 
					//If GetSetting(APP_CATEGORY, WIZARD_NAME, CONFIRM_KEY, vbNullString) = vbNullString Then 
					//frmConfirm.Show vbModal 
					//End If 
					 
					break;
			}
		}

		private bool ValidateData(int mnCurStep)
		{

			switch(mnCurStep)
			{
				case STEP_INTRO : 
					if (cmbModule.Text == "")
					{
						MessageBox.Show("Select Module First.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						goto Err;
					}
					else if (cmbVoucherTypes.Text == "")
					{ 
						MessageBox.Show("Select Transaction Type", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						goto Err;
					}
					else if (cmbLocation.Enabled)
					{ 
						if (ThisModuleID == mGlVoucher)
						{

						}
						else
						{
							if (cmbLocation.Text == "")
							{
								MessageBox.Show("Select Location", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								goto Err;
							}
						}
					} 
					break;
				case STEP_1 : 
					if (txtFromVoucherNo.Text == "")
					{
						txtFromVoucherNo.Text = "0";
					} 
					if (txtToVoucherNo.Text == "")
					{
						txtToVoucherNo.Text = "999999";
					} 
					break;
				case STEP_2 : 
					break;
			}

			return true;

			Err:
			return false;
		}
		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			int i = 0;
			string mysql = "";
			object mReturnValue = null;
			try
			{

				this.Top = (Convert.ToInt32((frmSysMain.DefInstance.oSystemInformation.WorkAreaHeight / 15 - (frmSysMain.DefInstance.Height - frmSysMain.DefInstance.ClientRectangle.Height) - this.Height) / 2f));
				this.Left = (Convert.ToInt32((frmSysMain.DefInstance.oSystemInformation.WorkAreaWidth / 15 - (frmSysMain.DefInstance.Width - frmSysMain.DefInstance.ClientRectangle.Width) - this.Width) / 2f));
				//init all vars
				mbFinishOK = false;

				for (i = 0; i <= NUM_STEPS - 1; i++)
				{
					fraStep[i].Left = -667;
				}
				SetStep(0, DIR_NONE);

				//**--make the form visible before all the control gets loaded
				//**--(this way system pretends to be faster in loading forms)
				this.Show();
				Application.DoEvents();

				mysql = mysql + " select distinct " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Group_Name as module_name," : "A_Group_Name as module_name, ");
				mysql = mysql + " Module_Id  ";
				mysql = mysql + " from SM_MODULES ";
				mysql = mysql + " where Module_Id in (2,5,6,7)";

				SystemCombo.FillComboWithItemData(cmbModule, mysql);

				txtFromDate.Value = DateTime.Parse("01-" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(DateTime.Today.Month) + "-" + Conversion.Str(DateTime.Today.Year));
				txtToDate.Value = DateTime.Today;
			}
			catch (System.Exception excep)
			{

				mysql = excep.Message;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();

					MessageBox.Show("Error : Unable to post transactions " + "\r" + mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}

		}

		private void SetStep(int nStep, int nDirection)
		{

			switch(nStep)
			{
				case STEP_INTRO : 
					mbFinishOK = false; 
					break;
				case STEP_1 : case STEP_2 : 
					mbFinishOK = true; 
					break;
				case STEP_FINISH : 
					mbFinishOK = false; 
					 
					break;
			}

			//move to new step
			fraStep[mnCurStep].Enabled = false;
			fraStep[nStep].Left = 0;
			if (nStep != mnCurStep)
			{
				fraStep[mnCurStep].Left = -667;
			}
			fraStep[nStep].Enabled = true;

			MoveStep(nStep);
			SetCaption(nStep);
			SetNavBtns(nStep);

		}

		private void SetNavBtns(int nStep)
		{
			string mysql = "";
			object mReturnValue = null;

			mnCurStep = nStep;

			if (mnCurStep == STEP_INTRO)
			{
				cmdNav[BTN_BACK].Enabled = false;
				cmdNav[BTN_NEXT].Enabled = true;

			}
			else if (mnCurStep == STEP_1)
			{ 
				if (ThisModuleID == SystemConstants.gModuleGLID)
				{
					cmdNav[BTN_NEXT].Enabled = false;
				}
				else
				{
					mysql = " select Enable_Advance_Mode_In_ICS_Batch_Post from SM_USERS where user_cd = " + SystemVariables.gLoggedInUserCode.ToString();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql, true));
					if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue) || SystemVariables.gMISuperUser)
					{
						mPostOptionType = SystemICSConstants.ShowOptions.optAdvancedMode;
						cmdNav[BTN_NEXT].Enabled = true;
					}
					else
					{
						mPostOptionType = SystemICSConstants.ShowOptions.optNormalMode;
						cmdNav[BTN_NEXT].Enabled = false;
					}
					cmdNav[BTN_BACK].Enabled = true;
				}
			}
			else if (mnCurStep == NUM_STEPS - 1)
			{ 
				cmdNav[BTN_NEXT].Enabled = false;
				cmdNav[BTN_BACK].Enabled = false;

			}
			else if (mnCurStep == STEP_2)
			{ 
				cmdNav[BTN_NEXT].Enabled = false;
				cmdNav[BTN_BACK].Enabled = true;

			}
			else
			{
				cmdNav[BTN_BACK].Enabled = true;
				cmdNav[BTN_NEXT].Enabled = true;
			}

			cmdNav[BTN_FINISH].Enabled = mbFinishOK;
		}

		private void SetCaption(int nStep)
		{
			try
			{

				this.Text = FRM_TITLE + " - " + App.Resources.Resources_Xtreme.ResourceManager.GetString("str" + Convert.ToString(fraStep[nStep].Tag));
			}
			catch
			{
			}

		}


		private void Load_Step_Intro()
		{
			//'Commented

		}

		private void Load_Step1()
		{
			//'Commented
		}
		private void Load_step2()
		{
			SelectDefaultPostOptions(cmbVoucherTypes.GetItemData(cmbVoucherTypes.ListIndex));
		}

		private void Load_step_Finish()
		{
			if (ThisModuleID == mGlVoucher)
			{
				PostGLVoucher();
			}
			else
			{
				PostInventoryVoucher();
			}
			mbFinishOK = true;
		}

		private void MoveStep(int mStep)
		{
			switch(mStep)
			{
				case STEP_INTRO : 
					Load_Step_Intro(); 
					break;
				case STEP_1 : 
					Load_Step1(); 
					break;
				case STEP_2 : 
					Load_step2(); 
					break;
				case STEP_FINISH : 
					Load_step_Finish(); 
					break;
			}
		}
		bool mLoopStatus_chkCommonPost_CheckStateChanged = false;
		private void chkCommonPost_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chkCommonPost, eventSender);
			bool mEnableSetting = false;
			CheckState mCheckedSetting = CheckState.Unchecked;

			if (!mLoopStatus_chkCommonPost_CheckStateChanged)
			{
				mLoopStatus_chkCommonPost_CheckStateChanged = true;
				if (Index == ccPostToGLSIndex)
				{
					mCheckedSetting = chkCommonPost[Index].CheckState;

					chkCommonPost[ccPostGLPartyIndex].CheckState = mCheckedSetting;
					chkCommonPost[ccPostGLExpenseIndex].CheckState = mCheckedSetting;
					chkCommonPost[ccPostGLInventoryIndex].CheckState = mCheckedSetting;
				}

				if (chkCommonPost[ccPostGLInventoryIndex].CheckState == CheckState.Checked)
				{
					mEnableSetting = false;
					mCheckedSetting = CheckState.Checked;

					chkCommonPost[ccPostStatusIndex].Enabled = mEnableSetting;
					chkCommonPost[ccPostToICSIndex].Enabled = mEnableSetting;
					chkCommonPost[ccPostToGLSIndex].Enabled = mEnableSetting;
					chkCommonPost[ccPostGLPartyIndex].Enabled = mEnableSetting;
					chkCommonPost[ccPostGLExpenseIndex].Enabled = mEnableSetting;

					chkCommonPost[ccPostStatusIndex].CheckState = mCheckedSetting;
					chkCommonPost[ccPostToICSIndex].CheckState = mCheckedSetting;
					chkCommonPost[ccPostToGLSIndex].CheckState = mCheckedSetting;
					chkCommonPost[ccPostGLPartyIndex].CheckState = mCheckedSetting;
					chkCommonPost[ccPostGLExpenseIndex].CheckState = mCheckedSetting;
				}
				else
				{
					mEnableSetting = true;

					chkCommonPost[ccPostStatusIndex].Enabled = mEnableSetting;
					chkCommonPost[ccPostToICSIndex].Enabled = mEnableSetting;
					chkCommonPost[ccPostToGLSIndex].Enabled = mEnableSetting;
					chkCommonPost[ccPostGLPartyIndex].Enabled = mEnableSetting;
					chkCommonPost[ccPostGLExpenseIndex].Enabled = mEnableSetting;
				}

				if (chkCommonPost[ccPostGLExpenseIndex].CheckState == CheckState.Checked)
				{
					mEnableSetting = false;
					mCheckedSetting = CheckState.Checked;

					chkCommonPost[ccPostStatusIndex].Enabled = mEnableSetting;
					chkCommonPost[ccPostToICSIndex].Enabled = mEnableSetting;
					chkCommonPost[ccPostToGLSIndex].Enabled = mEnableSetting;
					chkCommonPost[ccPostGLPartyIndex].Enabled = mEnableSetting;

					chkCommonPost[ccPostStatusIndex].CheckState = mCheckedSetting;
					chkCommonPost[ccPostToICSIndex].CheckState = mCheckedSetting;
					chkCommonPost[ccPostToGLSIndex].CheckState = mCheckedSetting;
					chkCommonPost[ccPostGLPartyIndex].CheckState = mCheckedSetting;
				}
				else
				{
					mEnableSetting = true;

					chkCommonPost[ccPostStatusIndex].Enabled = mEnableSetting;
					chkCommonPost[ccPostToICSIndex].Enabled = mEnableSetting;
					chkCommonPost[ccPostToGLSIndex].Enabled = mEnableSetting;
					chkCommonPost[ccPostGLPartyIndex].Enabled = mEnableSetting;
				}

				if (chkCommonPost[ccPostGLPartyIndex].CheckState == CheckState.Checked)
				{
					mEnableSetting = false;
					mCheckedSetting = CheckState.Checked;

					chkCommonPost[ccPostToGLSIndex].Enabled = mEnableSetting;

					chkCommonPost[ccPostToGLSIndex].CheckState = mCheckedSetting;
				}
				else
				{
					mEnableSetting = true;
					mCheckedSetting = CheckState.Unchecked;

					chkCommonPost[ccPostToGLSIndex].Enabled = mEnableSetting;
					chkCommonPost[ccPostToGLSIndex].CheckState = mCheckedSetting;
				}

				mLoopStatus_chkCommonPost_CheckStateChanged = false;
			}
		}
		private void SelectDefaultPostOptions(int pVoucherType)
		{
			DataSet rsTempRec = null;
			string mysql = "";
			CheckState mCheckStatus = CheckState.Unchecked;

			chkCommonPost[ccPostStatusIndex].CheckState = CheckState.Unchecked;
			chkCommonPost[ccPostToICSIndex].CheckState = CheckState.Unchecked;
			chkCommonPost[ccPostGLPartyIndex].CheckState = CheckState.Unchecked;
			chkCommonPost[ccPostGLExpenseIndex].CheckState = CheckState.Unchecked;
			chkCommonPost[ccPostGLInventoryIndex].CheckState = CheckState.Unchecked;

			if (chkCommonInclude[ccIncludeAllVoucherTypesIndex].CheckState == CheckState.Checked)
			{
				mCheckStatus = CheckState.Checked;
				//    chkCommonPost(ccPostGLInventoryIndex).Value = mCheckStatus
			}
			else
			{
				mysql = "select voucher_type, batch_post_ics, batch_post_gl_party, batch_post_status ";
				mysql = mysql + " , batch_post_gl_expense, batch_post_gl_inventory, batch_post_gl ";
				mysql = mysql + " from ICS_Transaction_Types ";

				rsTempRec = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsTempRec.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempRec.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsTempRec.Tables.Clear();
				adap.Fill(rsTempRec);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsTempRec.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempRec.setActiveConnection(null);
				if (rsTempRec.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempRec.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsTempRec.MoveFirst();
					rsTempRec.Find("voucher_type = " + Conversion.Str(pVoucherType));
					if (rsTempRec.Tables[0].Rows.Count != 0)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkCommonPost[ccPostStatusIndex].CheckState = (((TriState) Convert.ToInt32(rsTempRec.Tables[0].Rows[0]["batch_post_status"])) == TriState.True) ? CheckState.Checked : CheckState.Unchecked;
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkCommonPost[ccPostToICSIndex].CheckState = (((TriState) Convert.ToInt32(rsTempRec.Tables[0].Rows[0]["batch_post_ics"])) == TriState.True) ? CheckState.Checked : CheckState.Unchecked;
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkCommonPost[ccPostGLPartyIndex].CheckState = (((TriState) Convert.ToInt32(rsTempRec.Tables[0].Rows[0]["batch_post_gl_party"])) == TriState.True) ? CheckState.Checked : CheckState.Unchecked;
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkCommonPost[ccPostGLExpenseIndex].CheckState = (((TriState) Convert.ToInt32(rsTempRec.Tables[0].Rows[0]["batch_post_gl_expense"])) == TriState.True) ? CheckState.Checked : CheckState.Unchecked;
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkCommonPost[ccPostGLInventoryIndex].CheckState = (((TriState) Convert.ToInt32(rsTempRec.Tables[0].Rows[0]["batch_post_gl_inventory"])) == TriState.True) ? CheckState.Checked : CheckState.Unchecked;
					}
				}
				else
				{
					MessageBox.Show("Error: No voucher type records found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				rsTempRec = null;
			}
		}
		private void PostInventoryVoucher()
		{
			DataSet rsLocalRec = null;
			DialogResult ans = (DialogResult) 0;
			StringBuilder mListOfVoucherTypes = new StringBuilder();
			StringBuilder mListOfLocation = new StringBuilder();
			int cnt = 0;
			string mysql = "";
			int mRecordsStatusApproved = 0;
			int mRecordsPostToICS = 0;
			int mRecordsPostToGLParty = 0;
			int mRecordsPostToGLExpense = 0;
			int mRecordsPostToGLInventory = 0;
			int mRecordsPostToGL = 0;
			int mMaximumPostedRecords = 0;
			int mAutoGeneratedLinkedVoucherEntryId = 0;
			object mReturnValue = null;

			clsHourGlass myHourGlass = new clsHourGlass();

			try
			{

				//ans = MsgBox(msg7, vbYesNo + vbInformation)
				//If ans = vbNo Then
				//    Exit Sub
				//End If

				//Set myHourGlass = New clsHourGlass
				mPostingActive = true;

				if (chkCommonInclude[ccIncludeAllVoucherTypesIndex].CheckState == CheckState.Checked)
				{
					mListOfVoucherTypes = new StringBuilder("");
					int tempForEndVar = cmbVoucherTypes.ListCount - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						if (mListOfVoucherTypes.ToString() != "")
						{
							mListOfVoucherTypes.Append(", ");
						}
						mListOfVoucherTypes.Append(cmbVoucherTypes.GetItemData(cnt).ToString());
					}
				}
				else
				{
					mListOfVoucherTypes = new StringBuilder(cmbVoucherTypes.GetItemData(cmbVoucherTypes.ListIndex).ToString());
				}

				if (chkCommonInclude[ccIncludeAllLocationsIndex].CheckState == CheckState.Checked)
				{
					mListOfLocation = new StringBuilder("");
					int tempForEndVar2 = cmbLocation.ListCount - 1;
					for (cnt = 0; cnt <= tempForEndVar2; cnt++)
					{
						if (mListOfLocation.ToString() != "")
						{
							mListOfLocation.Append(", ");
						}
						mListOfLocation.Append(cmbLocation.GetItemData(cnt).ToString());
					}
				}
				else
				{
					mListOfLocation = new StringBuilder(cmbLocation.GetItemData(cmbLocation.ListIndex).ToString());
				}


				mysql = " select entry_id, status, posted_invnt, posted_gl_party ";
				mysql = mysql + " , posted_gl_expense , posted_gl_inventory, posted_gl ";
				mysql = mysql + " , mt.voucher_type, ivt.dented_stock_generated_linked_voucher_type ";
				mysql = mysql + " , show_dented_stock_in_details, Auto_Post_Stock_Generated_Linked_Voucher_Type ";
				mysql = mysql + " from ICS_Transaction mt ";
				mysql = mysql + " inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";
				mysql = mysql + " where (posted_gl = 0 and status <> 3) ";
				mysql = mysql + " and mt.voucher_type in (" + mListOfVoucherTypes.ToString() + ")";
				mysql = mysql + " and mt.locat_cd in (" + mListOfLocation.ToString() + ")";
				mysql = mysql + " and mt.voucher_date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtFromDate.Value) + "'";
				mysql = mysql + " and mt.voucher_date <= '" + ReflectionHelper.GetPrimitiveValue<string>(txtToDate.Value) + "'";
				mysql = mysql + " and mt.voucher_no >= " + txtFromVoucherNo.Text;
				mysql = mysql + " and mt.voucher_no <= " + txtToVoucherNo.Text;
				mysql = mysql + " and mt.voucher_date >= '" + SystemVariables.gCurrentPeriodStarts + "'";
				mysql = mysql + " and mt.voucher_date <= '" + SystemVariables.gNextPeriodEnds + "'";
				mysql = mysql + " order by affect_cost desc, affect_opening_value desc ";
				mysql = mysql + " , affect_on_hand_stock desc, add_or_less asc, module_id asc";


				rsLocalRec = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLocalRec.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLocalRec.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLocalRec.Tables.Clear();
				adap.Fill(rsLocalRec);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLocalRec.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLocalRec.setActiveConnection(null);

				foreach (DataRow iteration_row in rsLocalRec.Tables[0].Rows)
				{
					//'''*************************************************************************
					//------------Check if posting cancle by user---------------------------------
					if (!mPostingActive)
					{
						ans = MessageBox.Show("Do you want to commit here?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);

						if (ans == System.Windows.Forms.DialogResult.Yes)
						{
							goto CommitTrans;
						}
						else if (ans == System.Windows.Forms.DialogResult.No)
						{ 
							mPostingActive = true;
						}
					}
					//------------------------------------------------------------------------------
					//''-----------------------Moved by Moiz Hakimi------19-May-2010----------------
					//------------------------------------------------------------------------------
					SystemVariables.gConn.BeginTransaction();
					//''''*************************************************************************
					//''''Post the auto generated linked voucher eg. Delivery note autogenerated
					//''''from sales invoice
					mysql = " select entry_id from ICS_Transaction ";
					mysql = mysql + " where linked_to_entry_id = " + Convert.ToString(iteration_row["entry_id"]);
					mysql = mysql + " and status = 4 ";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mAutoGeneratedLinkedVoucherEntryId = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						mAutoGeneratedLinkedVoucherEntryId = 0;
					}
					//''''*************************************************************************

					if (chkCommonPost[ccPostStatusIndex].CheckState == CheckState.Checked)
					{
						if (Convert.ToDouble(iteration_row["status"]) == 1)
						{
							mRecordsStatusApproved++;
							SystemICSProcedure.ApproveTransaction("ICS_Transaction", Convert.ToInt32(iteration_row["entry_id"]));
							//**--approve parent transaction status if current
							//**--transaction is linked
							SystemICSProcedure.ApproveParentTransaction("ICS_Transaction", Convert.ToInt32(iteration_row["entry_id"]));

							//**--No Special posting require for serialized items
							//                If PostSerialItems(.Fields("voucher_type").Value, .Fields("entry_id").Value) = False Then
							//                    gConn.RollBackTrans
							//                    MsgBox "Serialized items posting failed", vbCritical
							//                    Exit Sub
							//                End If

							if (!rsLocalRec.Tables[0].Rows[0].IsNull("dented_stock_generated_linked_voucher_type"))
							{
								//Call GenerateDentedItemVoucher(.Fields("entry_id").Value, .Fields("dented_stock_generated_linked_voucher_type"))
								SystemICSProcedure.GenerateDentedItemVoucher(Convert.ToInt32(iteration_row["entry_id"]), Convert.ToInt32(iteration_row["dented_stock_generated_linked_voucher_type"]), Convert.ToBoolean(iteration_row["show_dented_stock_in_details"]), Convert.ToBoolean(iteration_row["Auto_Post_Stock_Generated_Linked_Voucher_Type"]), false);
							}
						}
					}

					if (chkCommonPost[ccPostToICSIndex].CheckState == CheckState.Checked)
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(iteration_row["posted_invnt"])) == TriState.False)
						{
							mRecordsPostToICS++;
							SystemICSProcedure.PostTransactionToIcs("ICS_Transaction", Convert.ToInt32(iteration_row["entry_id"]));

							if (mAutoGeneratedLinkedVoucherEntryId > 0)
							{
								SystemICSProcedure.PostTransactionToIcs("ICS_Transaction", mAutoGeneratedLinkedVoucherEntryId);
							}
						}
					}

					if (chkCommonPost[ccPostGLPartyIndex].CheckState == CheckState.Checked)
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(iteration_row["posted_gl_party"])) == TriState.False)
						{
							mRecordsPostToGLParty++;
							SystemICSProcedure.PostTransactionToGLParty("ICS_Transaction", Convert.ToInt32(iteration_row["entry_id"]));

							if (mAutoGeneratedLinkedVoucherEntryId > 0)
							{
								SystemICSProcedure.PostTransactionToGLParty("ICS_Transaction", mAutoGeneratedLinkedVoucherEntryId);
							}
						}
					}

					if (chkCommonPost[ccPostGLExpenseIndex].CheckState == CheckState.Checked)
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(iteration_row["posted_gl_expense"])) == TriState.False)
						{
							mRecordsPostToGLExpense++;
							SystemICSProcedure.PostTransactionToGLExpenses("ICS_Transaction", Convert.ToInt32(iteration_row["entry_id"]), false);

							if (mAutoGeneratedLinkedVoucherEntryId > 0)
							{
								SystemICSProcedure.PostTransactionToGLExpenses("ICS_Transaction", mAutoGeneratedLinkedVoucherEntryId);
							}
						}
					}

					if (chkCommonPost[ccPostGLInventoryIndex].CheckState == CheckState.Checked)
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(iteration_row["posted_gl_inventory"])) == TriState.False)
						{
							mRecordsPostToGLInventory++;
							SystemICSProcedure.PostTransactionToGLInventory("ICS_Transaction", Convert.ToInt32(iteration_row["entry_id"]), false);

							if (mAutoGeneratedLinkedVoucherEntryId > 0)
							{
								SystemICSProcedure.PostTransactionToGLInventory("ICS_Transaction", mAutoGeneratedLinkedVoucherEntryId, false);
							}

						}
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(iteration_row["posted_gl"])) == TriState.False)
						{
							mRecordsPostToGL++;
							SystemICSProcedure.PostTransactionToGL("ICS_Transaction", Convert.ToInt32(iteration_row["entry_id"]), false);

							if (mAutoGeneratedLinkedVoucherEntryId > 0)
							{
								SystemICSProcedure.PostTransactionToGL("ICS_Transaction", mAutoGeneratedLinkedVoucherEntryId, false);
							}
						}
					}

					//**--post the linked assembly group vouchers
					SystemICSProcedure.PostLinkedAssemblyGroupProduct(Convert.ToInt32(iteration_row["voucher_type"]), Convert.ToInt32(iteration_row["entry_id"]), chkCommonPost[ccPostStatusIndex].CheckState == CheckState.Checked, chkCommonPost[ccPostToICSIndex].CheckState == CheckState.Checked, chkCommonPost[ccPostGLPartyIndex].CheckState == CheckState.Checked, chkCommonPost[ccPostGLExpenseIndex].CheckState == CheckState.Checked, chkCommonPost[ccPostGLInventoryIndex].CheckState == CheckState.Checked);

					Application.DoEvents();
					ProgressBar1.Value = Convert.ToInt32((mRecordsPostToGLInventory / ((double) rsLocalRec.Tables[0].Rows.Count)) * 100);
					//Me.Caption = mRecordsPostToGLInventory & "/" & rsLocalRec.RecordCount

					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();
				}
				CommitTrans:
				mPostingActive = false;
				cmdNav[BTN_FINISH].Enabled = true;




				if (mPostOptionType == SystemICSConstants.ShowOptions.optAdvancedMode)
				{
					mysql = "Total approved records : " + Conversion.Str(mRecordsStatusApproved);
					mysql = mysql + "\r" + "Total posted records to inventory control system : " + Conversion.Str(mRecordsPostToICS);
					mysql = mysql + "\r" + "Total posted records to general ledger party / cash / bank accounts : " + Conversion.Str(mRecordsPostToGLParty);
					mysql = mysql + "\r" + "Total posted records to general ledger expenses : " + Conversion.Str(mRecordsPostToGLExpense);
					mysql = mysql + "\r" + "Total posted records to general ledger inventory accounts : " + Conversion.Str(mRecordsPostToGLInventory);
				}
				else
				{
					mMaximumPostedRecords = Math.Max(mRecordsStatusApproved, mRecordsPostToICS);
					mMaximumPostedRecords = Math.Max(mMaximumPostedRecords, mRecordsPostToGLParty);
					mMaximumPostedRecords = Math.Max(mMaximumPostedRecords, mRecordsPostToGLExpense);
					mMaximumPostedRecords = Math.Max(mMaximumPostedRecords, mRecordsPostToGLInventory);
					mysql = "Total posted records : " + Conversion.Str(mMaximumPostedRecords);
				}

				MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

				rsLocalRec = null;
				//Set myHourGlass = Nothing

				//FirstFocusObject.SetFocus
				return;


				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
			}
			catch (System.Exception excep)
			{

				mysql = excep.Message;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					myHourGlass = null;
					MessageBox.Show("Error : Unable to post transactions " + "\r" + mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}

		}

		private void PostGLVoucher()
		{
			int mVoucherType = 0;
			string mysql = "";
			DataSet rsTempRec = null;
			int cnt = 0;

			try
			{

				mVoucherType = cmbVoucherTypes.GetItemData(cmbVoucherTypes.ListIndex);
				cnt = 0;

				mysql = " select at.entry_id, pdc_generated_linked_gl_voucher_type ";
				mysql = mysql + " from gl_accnt_trans at ";
				mysql = mysql + " inner join gl_accnt_voucher_types avt ";
				mysql = mysql + " on at.voucher_type = avt.voucher_type ";
				mysql = mysql + " where at.voucher_date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtFromDate.Value) + "'";
				mysql = mysql + " and at.voucher_date <= '" + ReflectionHelper.GetPrimitiveValue<string>(txtToDate.Value) + "'";
				mysql = mysql + " and at.voucher_no >='" + txtFromVoucherNo.Text + "'";
				mysql = mysql + " and at.voucher_no <='" + txtToVoucherNo.Text + "'";
				mysql = mysql + " and at.voucher_date >= '" + SystemVariables.gCurrentPeriodStarts + "'";
				mysql = mysql + " and at.voucher_date <= '" + SystemVariables.gNextPeriodEnds + "'";
				mysql = mysql + " and at.status = 1 ";
				if (chkCommonInclude[ccIncludeAllVoucherTypesIndex].CheckState == CheckState.Unchecked)
				{
					mysql = mysql + " and at.voucher_type = " + Conversion.Str(mVoucherType);
				}

				rsTempRec = new DataSet();
				SystemVariables.gConn.BeginTransaction();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsTempRec.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTempRec.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsTempRec.Tables.Clear();
				adap.Fill(rsTempRec);
				foreach (DataRow iteration_row in rsTempRec.Tables[0].Rows)
				{
					if (!rsTempRec.Tables[0].Rows[0].IsNull("pdc_generated_linked_gl_voucher_type"))
					{
						if (!SystemGLProcedure.GenerateLinkedVoucherForPDC(Convert.ToInt32(iteration_row["pdc_generated_linked_gl_voucher_type"]), Convert.ToInt32(iteration_row["entry_id"])))
						{
							throw new Exception();
						}
					}

					mysql = "update gl_accnt_trans ";
					mysql = mysql + " set status = 2 ";
					mysql = mysql + " where entry_id = " + Conversion.Str(iteration_row["entry_id"]);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					cnt++;
					ProgressBar1.Value = Convert.ToInt32((cnt / ((double) rsTempRec.Tables[0].Rows.Count)) * 100);
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				mysql = Conversion.Str(cnt).Trim() + " Transaction(s) successfully posted.";

				MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (System.Exception excep)
			{


				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				mysql = excep.Message;
				MessageBox.Show("Error : Unable to post transactions " + "\r" + mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}


		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}