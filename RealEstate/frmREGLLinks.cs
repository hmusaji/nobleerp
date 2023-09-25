
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmREGLLinks
		: System.Windows.Forms.Form
	{

		public frmREGLLinks()
{
InitializeComponent();
} 
 public  void frmREGLLinks_old()
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


		private void frmREGLLinks_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		int mThisFormID = 0;
		object mSearchValue = null;
		
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
		private bool mCurrentSearchOnInternalCodes = false;

		private string mAllowedRevenueCodes = "";
		private string mAllowedAccruedCodes = "";
		private string mAllowedCashCodes = "";
		private string mAllowedAdvanceCodes = "";
		private string mAllowedDiscountCodes = "";

		private const int conLBLRevenueCode = 0;
		private const int conLBLAccruedCode = 1;
		private const int conLBLCashCode = 2;
		private const int conLBLAdvanceCode = 3;
		private const int conLBLDiscountCode = 4;

		private const int conTXTRevenueCode = 0;
		private const int conTXTAccruedCode = 1;
		private const int conTXTCashCode = 2;
		private const int conTXTAdvanceCode = 3;
		private const int conTXTDiscountCode = 4;

		private const int conTXTRevenueName = 0;
		private const int conTXTAccruedName = 1;
		private const int conTXTCashName = 2;
		private const int conTXTAdvanceName = 3;
		private const int conTXTDiscountName = 4;

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


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				this.Top = 0;
				this.Left = 0;
				mCurrentSearchOnInternalCodes = false;

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
				SystemProcedure.SetLabelCaption(this);

				UCStatusBar.ChildSpacing = 100;
				UCStatusBar.EvenControlSpacing = 500;

				UCStatusBar.AddControl(1);
				UCStatusBar.SetStatusLabel(1, UCStatusBar.LabelProperty.stCaption, "Group Type :");
				UCStatusBar.SetStatusLabel(1, UCStatusBar.LabelProperty.stAutoSize, (true).ToString());

				UCStatusBar.AddControl(2);
				UCStatusBar.SetStatusLabel(2, UCStatusBar.LabelProperty.stForeColor, ColorTranslator.ToOle(Color.White).ToString());
				UCStatusBar.SetStatusLabel(2, UCStatusBar.LabelProperty.stWidth, "5000");
				UCStatusBar.ReAllignLabels();

				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_property_level_revenue_posting")))
				{
					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAllowedRevenueCodes = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_revenue_codes"));
					lblCommon[conLBLRevenueCode].Visible = true;
					txtCommon[conTXTRevenueCode].Visible = true;
					txtDisplayLabel[conTXTRevenueName].Visible = true;
				}
				else
				{
					mAllowedRevenueCodes = "";
					lblCommon[conLBLRevenueCode].Visible = false;
					txtCommon[conTXTRevenueCode].Visible = false;
					txtDisplayLabel[conTXTRevenueName].Visible = false;
				}

				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_property_level_accrued_charges_posting")))
				{
					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAllowedAccruedCodes = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_accrued_codes"));
					lblCommon[conLBLAccruedCode].Visible = true;
					txtCommon[conTXTAccruedCode].Visible = true;
					txtDisplayLabel[conTXTAccruedName].Visible = true;
				}
				else
				{
					mAllowedAccruedCodes = "";
					lblCommon[conLBLAccruedCode].Visible = false;
					txtCommon[conTXTAccruedCode].Visible = false;
					txtDisplayLabel[conTXTAccruedName].Visible = false;
				}

				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_property_level_cash_posting")))
				{
					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAllowedCashCodes = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_cash_codes"));
					lblCommon[conLBLCashCode].Visible = true;
					txtCommon[conTXTCashCode].Visible = true;
					txtDisplayLabel[conTXTCashName].Visible = true;
				}
				else
				{
					mAllowedCashCodes = "";
					lblCommon[conLBLCashCode].Visible = false;
					txtCommon[conTXTCashCode].Visible = false;
					txtDisplayLabel[conTXTCashName].Visible = false;
				}

				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_property_level_advanced_receipt_posting")))
				{
					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAllowedAdvanceCodes = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_advance_codes"));
					lblCommon[conLBLAdvanceCode].Visible = true;
					txtCommon[conTXTAdvanceCode].Visible = true;
					txtDisplayLabel[conTXTAdvanceName].Visible = true;
				}
				else
				{
					mAllowedAdvanceCodes = "";
					lblCommon[conLBLAdvanceCode].Visible = false;
					txtCommon[conTXTAdvanceCode].Visible = false;
					txtDisplayLabel[conTXTAdvanceName].Visible = false;
				}

				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_property_level_discount_posting")))
				{
					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAllowedDiscountCodes = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_discount_codes"));
					lblCommon[conLBLDiscountCode].Visible = true;
					txtCommon[conTXTDiscountCode].Visible = true;
					txtDisplayLabel[conTXTDiscountName].Visible = true;
				}
				else
				{
					mAllowedDiscountCodes = "";
					lblCommon[conLBLDiscountCode].Visible = false;
					txtCommon[conTXTDiscountCode].Visible = false;
					txtDisplayLabel[conTXTDiscountName].Visible = false;
				}

				this.Show();
				Application.DoEvents();

				GetRecord();
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

		public bool saveRecord()
		{
			bool result = false;
			string mySQL = "";
			DataSet rsTempRec = null;

			try
			{

				SystemVariables.gConn.BeginTransaction();

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = "select count(*) from re_gl_links";
				SqlDataAdapter TempAdapter = null;
				TempAdapter = new SqlDataAdapter();
				TempAdapter.SelectCommand = TempCommand;
				DataSet TempDataset = null;
				TempDataset = new DataSet();
				TempAdapter.Fill(TempDataset);
				rsTempRec = TempDataset;
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToDouble(rsTempRec.Tables[0].Rows[0][0]) > 0)
				{
					mySQL = "update re_gl_links set ";
					mySQL = mySQL + " revenue_cd = " + ((txtCommon[conTXTRevenueCode].Visible) ? Convert.ToString(txtCommon[conTXTRevenueCode].Tag) : "null");
					mySQL = mySQL + ", accrued_cd = " + ((txtCommon[conTXTAccruedCode].Visible) ? Convert.ToString(txtCommon[conTXTAccruedCode].Tag) : "null");
					mySQL = mySQL + ", cash_cd = " + ((txtCommon[conTXTCashCode].Visible) ? Convert.ToString(txtCommon[conTXTCashCode].Tag) : "null");
					mySQL = mySQL + ", advance_cd = " + ((txtCommon[conTXTAdvanceCode].Visible) ? Convert.ToString(txtCommon[conTXTAdvanceCode].Tag) : "null");
					mySQL = mySQL + ", discount_cd = " + ((txtCommon[conTXTDiscountCode].Visible) ? Convert.ToString(txtCommon[conTXTDiscountCode].Tag) : "null");
					mySQL = mySQL + ", user_cd = " + Conversion.Str(SystemVariables.gLoggedInUserCode);
				}
				else
				{
					mySQL = "insert into re_gl_links ";
					mySQL = mySQL + " (revenue_cd, accrued_cd, cash_cd, advance_cd, discount_cd, user_cd)";
					mySQL = mySQL + " values (";
					mySQL = mySQL + ((txtCommon[conTXTRevenueCode].Visible) ? Convert.ToString(txtCommon[conTXTRevenueCode].Tag) : "null");
					mySQL = mySQL + ", " + ((txtCommon[conTXTAccruedCode].Visible) ? Convert.ToString(txtCommon[conTXTAccruedCode].Tag) : "null");
					mySQL = mySQL + ", " + ((txtCommon[conTXTCashCode].Visible) ? Convert.ToString(txtCommon[conTXTCashCode].Tag) : "null");
					mySQL = mySQL + ", " + ((txtCommon[conTXTAdvanceCode].Visible) ? Convert.ToString(txtCommon[conTXTAdvanceCode].Tag) : "null");
					mySQL = mySQL + ", " + ((txtCommon[conTXTDiscountCode].Visible) ? Convert.ToString(txtCommon[conTXTDiscountCode].Tag) : "null");
					mySQL = mySQL + ", " + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";
				}
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mySQL;
				TempCommand_2.ExecuteNonQuery();
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				MessageBox.Show("Real Estate - GL settings have been updated. Restart system for the new settings to take effect.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = true;
				CloseForm();
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					result = false;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		public void CloseForm()
		{
			this.Close();
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmREGLLinks.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCommon_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);
			FindRoutine("txtCommon#" + Index.ToString().Trim());
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;
			string mFilterCondition = "";

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mObjectIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));
			if (mObjectName == "txtCommon")
			{
				txtCommon[mObjectIndex].Text = "";
				switch(mObjectIndex)
				{
					case conTXTRevenueCode : 
						//mFilterCondition = "left(ldgr_cd, 4) in (" + mAllowedRevenueCodes + ")" 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFilterCondition)); 
						break;
					case conTXTAccruedCode : 
						//mFilterCondition = "left(ldgr_cd, 4) in (" + mAllowedAccruedCodes + ")" 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFilterCondition)); 
						break;
					case conTXTCashCode : 
						//mFilterCondition = "left(ldgr_cd, 4) in (" + mAllowedCashCodes + ")" 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFilterCondition)); 
						break;
					case conTXTAdvanceCode : 
						//mFilterCondition = "left(ldgr_cd, 4) in (" + mAllowedAdvanceCodes + ")" 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFilterCondition)); 
						break;
					case conTXTDiscountCode : 
						//mFilterCondition = "left(ldgr_cd, 4) in (" + mAllowedDiscountCodes + ")" 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFilterCondition)); 
						break;
					default:
						return;
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommon[mObjectIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtCommon_Leave(txtCommon[mObjectIndex], new EventArgs());
				}
			}
		}

		private void txtCommon_Enter(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommon, eventSender);
			switch(Index)
			{
				case conTXTRevenueCode : 
					UCStatusBar.SetStatusLabel(2, UCStatusBar.LabelProperty.stCaption, "Income (Direct/Indirect)"); 
					break;
				case conTXTAccruedCode : 
					UCStatusBar.SetStatusLabel(2, UCStatusBar.LabelProperty.stCaption, "Current Assets"); 
					break;
				case conTXTCashCode : 
					UCStatusBar.SetStatusLabel(2, UCStatusBar.LabelProperty.stCaption, "Cash/Bank Account"); 
					break;
				case conTXTAdvanceCode : 
					UCStatusBar.SetStatusLabel(2, UCStatusBar.LabelProperty.stCaption, "Current Liabilities"); 
					break;
				case conTXTDiscountCode : 
					UCStatusBar.SetStatusLabel(2, UCStatusBar.LabelProperty.stCaption, "Expenses (Direct/Indirect)"); 
					break;
			}
		}

		private void txtCommon_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommon, eventSender);
			object mTempValue = null;
			string mySQL = "";
			int mLinkedTextBoxIndex = 0;

			try
			{

				mySQL = "select l_ldgr_name, a_ldgr_name, ldgr_cd, ldgr_no from gl_ledger where ";
				if (!mCurrentSearchOnInternalCodes)
				{
					mySQL = mySQL + " ldgr_no = '" + txtCommon[Index].Text.Trim() + "'";
				}
				else
				{
					mySQL = mySQL + " ldgr_cd =" + Convert.ToString(txtCommon[Index].Tag).Trim();
				}
				switch(Index)
				{
					case conTXTRevenueCode : 
						//mySql = mySql & " and left(ldgr_cd, 4) in (" + mAllowedRevenueCodes + ")" 
						mLinkedTextBoxIndex = conTXTRevenueName; 
						break;
					case conTXTAccruedCode : 
						//mySql = mySql & " and left(ldgr_cd, 4) in (" + mAllowedAccruedCodes + ")" 
						mLinkedTextBoxIndex = conTXTAccruedName; 
						break;
					case conTXTCashCode : 
						//mySql = mySql & " and left(ldgr_cd, 4) in (" + mAllowedCashCodes + ")" 
						mLinkedTextBoxIndex = conTXTCashName; 
						break;
					case conTXTAdvanceCode : 
						//mySql = mySql & " and left(ldgr_cd, 4) in (" + mAllowedAdvanceCodes + ")" 
						mLinkedTextBoxIndex = conTXTAdvanceName; 
						break;
					case conTXTDiscountCode : 
						//mySql = mySql & " and left(ldgr_cd, 4) in (" + mAllowedDiscountCodes + ")" 
						mLinkedTextBoxIndex = conTXTDiscountName; 
						break;
					default:
						return;
				}


				if (!SystemProcedure2.IsItEmpty((!mCurrentSearchOnInternalCodes) ? txtCommon[Index].Text : Convert.ToString(txtCommon[Index].Tag), SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDisplayLabel[mLinkedTextBoxIndex].Text = "";
						txtCommon[Index].Tag = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						txtDisplayLabel[mLinkedTextBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1));
						txtCommon[Index].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
						if (mCurrentSearchOnInternalCodes)
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommon[Index].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
						}
					}
				}
				else
				{
					txtDisplayLabel[mLinkedTextBoxIndex].Text = "";
					txtCommon[Index].Tag = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					//
				}
				else if (mReturnErrorType == 2)
				{ 
					//
				}
				else if (mReturnErrorType == 3)
				{ 
					//
				}
				else if (mReturnErrorType == 4)
				{ 
					//if the code is not found
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
					try
					{
						txtCommon[Index].Focus();
					}
					catch (Exception exc)
					{
						NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
					}
				}
				else
				{
					//
				}
			}
		}

		private void GetRecord()
		{
			object mTempValue = null;
			string mySQL = "";

			try
			{


				mySQL = "select top 1 revenue_cd, accrued_cd, cash_cd, advance_cd, discount_cd from re_gl_links";

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempValue))
				{
					throw new System.Exception("-9990002");
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				txtCommon[conTXTRevenueCode].Tag = (Convert.IsDBNull(((Array) mTempValue).GetValue(0))) ? "" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				txtCommon[conTXTAccruedCode].Tag = (Convert.IsDBNull(((Array) mTempValue).GetValue(1))) ? "" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				txtCommon[conTXTCashCode].Tag = (Convert.IsDBNull(((Array) mTempValue).GetValue(2))) ? "" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				txtCommon[conTXTAdvanceCode].Tag = (Convert.IsDBNull(((Array) mTempValue).GetValue(3))) ? "" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				txtCommon[conTXTDiscountCode].Tag = (Convert.IsDBNull(((Array) mTempValue).GetValue(4))) ? "" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));

				mCurrentSearchOnInternalCodes = true;

				if (txtCommon[conTXTRevenueCode].Visible)
				{
					txtCommon_Leave(txtCommon[conTXTRevenueCode], new EventArgs());
				}
				if (txtCommon[conTXTAccruedCode].Visible)
				{
					txtCommon_Leave(txtCommon[conTXTAccruedCode], new EventArgs());
				}
				if (txtCommon[conTXTCashCode].Visible)
				{
					txtCommon_Leave(txtCommon[conTXTCashCode], new EventArgs());
				}
				if (txtCommon[conTXTAdvanceCode].Visible)
				{
					txtCommon_Leave(txtCommon[conTXTAdvanceCode], new EventArgs());
				}
				if (txtCommon[conTXTDiscountCode].Visible)
				{
					txtCommon_Leave(txtCommon[conTXTDiscountCode], new EventArgs());
				}

				mCurrentSearchOnInternalCodes = false;
			}
			catch (Exception e)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number == -9990002)
				{
					mCurrentSearchOnInternalCodes = false;
					//MsgBox "GL link codes not defined!" + Chr(13) + "GL link must be defined to run month end process", vbInformation
				}
				else
				{
					MessageBox.Show(e.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
		}

		public bool CheckDataValidity()
		{
			if (txtCommon[conTXTRevenueCode].Visible)
			{
				txtCommon_Leave(txtCommon[conTXTRevenueCode], new EventArgs());
				if (SystemProcedure2.IsItEmpty(txtCommon[conTXTRevenueCode].Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Revenue Ledger Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommon[conTXTRevenueCode].Focus();
					return false;
				}
			}

			if (txtCommon[conTXTAccruedCode].Visible)
			{
				txtCommon_Leave(txtCommon[conTXTAccruedCode], new EventArgs());
				if (SystemProcedure2.IsItEmpty(txtCommon[conTXTAccruedCode].Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Accrued Ledger Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommon[conTXTAccruedCode].Focus();
					return false;
				}
			}

			if (txtCommon[conTXTCashCode].Visible)
			{
				txtCommon_Leave(txtCommon[conTXTCashCode], new EventArgs());
				if (SystemProcedure2.IsItEmpty(txtCommon[conTXTCashCode].Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Cash Ledger Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommon[conTXTCashCode].Focus();
					return false;
				}
			}

			if (txtCommon[conTXTAdvanceCode].Visible)
			{
				txtCommon_Leave(txtCommon[conTXTAdvanceCode], new EventArgs());
				if (SystemProcedure2.IsItEmpty(txtCommon[conTXTAdvanceCode].Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Advance Ledger Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommon[conTXTAdvanceCode].Focus();
					return false;
				}
			}

			if (txtCommon[conTXTDiscountCode].Visible)
			{
				txtCommon_Leave(txtCommon[conTXTDiscountCode], new EventArgs());
				if (SystemProcedure2.IsItEmpty(txtCommon[conTXTDiscountCode].Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Discount Ledger Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommon[conTXTDiscountCode].Focus();
					return false;
				}
			}

			return true;
		}
	}
}