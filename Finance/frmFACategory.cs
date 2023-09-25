
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmFACategory
		: System.Windows.Forms.Form
	{

		public frmFACategory()
{
InitializeComponent();
} 
 public  void frmFACategory_old()
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


		private void frmFACategory_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private string mTimeStamp = "";

		private XArrayHelper _aLedger = null;
		private XArrayHelper aLedger
		{
			get
			{
				if (_aLedger is null)
				{
					_aLedger = new XArrayHelper();
				}
				return _aLedger;
			}
			set
			{
				_aLedger = value;
			}
		}

		private DataSet rsLedgerList = null;
		private DataSet rsCostList = null;

		private const int grdAccountType = 0;
		private const int grdLedgerCode = 1;
		private const int grdLedgerName = 2;
		//Private Const grdApplyCostCenter As Integer = 3
		private const int grdCCNo = 3;
		private const int grdCCName = 4;
		private const int grdGroupCodeFilterOnLedger = 5;

		private const int mMaxArrayCols = 5;
		private const int mMaxArrayRows = 5;

		private const int conTabBasicDetails = 0;
		private const int conTabGLLinks = 1;

		bool mCategoryDefaultSet = false;



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
			FirstFocusObject = txtCatNo;

			try
			{

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

				SystemProcedure.SetLabelCaption(this);
				//assign a next code
				txtCatNo.Text = SystemProcedure2.GetNewNumber("fa_category", "cat_no");
				//
				//Call SetLabelCaption(Me)
				//If gPreferedLanguage = Arabic And GetSystemPreferenceSetting("flip_controls_in_arabic") = vbTrue Then
				//    Dim oFlipThisForm As New clsFlip
				//
				//    oFlipThisForm.SwapMe Me
				//End If
				//

				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, "&H98AFDA", "&H98AFDA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "GL Account Type", 2200, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Code", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Name", 2700, false, SystemConstants.gDisableColumnBackColor);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Apply cost center", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Code", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), (0x913DA3).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon", false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Name", 1800, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "GroupCodeFilterList", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);


				//Setting for the standard Listbox used on the grid
				SystemGrid.DefineSystemGridCombo(cmbCommon);
				cmbCommon.Height = 100;
				cmbCommon.Width = 280;

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
				{
					ResetGridArray();
					GenerateRecordSet();
					GetAccountInfo(0);
				}
				else
				{
					tabMaster.set_TabVisible(Convert.ToInt16(conTabGLLinks), false);
				}
				tabMaster.CurrTab = Convert.ToInt16(conTabBasicDetails);
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
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void AddRecord()
		{
			//Add a record

			SystemProcedure2.ClearTextBox(this);
			txtCatNo.Text = SystemProcedure2.GetNewNumber("fa_category", "cat_no");
			txtParentCatNo.Enabled = true;

			ResetGridArray();

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			mSearchValue = "";

			tabMaster.CurrTab = Convert.ToInt16(conTabBasicDetails);
			if (ControlHelper.GetEnabled(FirstFocusObject))
			{
				FirstFocusObject.Focus();
			}

			mCategoryDefaultSet = false;

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord()
		{
			bool result = false;
			string mParentCatCode = "";
			object mReturnValue = null;
			string mysql = "";
			int mEntryId = 0;

			try
			{

				if (txtParentCatNo.Enabled)
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select cat_cd from fa_category where cat_no=" + txtParentCatNo.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Fixed Asset Category", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						txtParentCatNo.Focus();
						return result;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mParentCatCode = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}
				}

				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " INSERT INTO fa_category(user_cd, m_cat_cd, cat_no, l_cat_name, a_cat_name ";
					mysql = mysql + " , remarks)";
					mysql = mysql + " VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
					mysql = mysql + "'" + mParentCatCode + "',";
					mysql = mysql + txtCatNo.Text + ",";
					mysql = mysql + "'" + txtLCatName.Text + "',";
					mysql = mysql + "N'" + txtACatName.Text + "',";
					mysql = mysql + "'" + txtComment.Text + "')";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mysql = " select scope_identity() ";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));
				}
				else
				{
					//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);

					mysql = " select time_stamp,protected from fa_category where cat_cd =" + mEntryId.ToString();
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
						tabMaster.CurrTab = Convert.ToInt16(conTabBasicDetails);
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
						tabMaster.CurrTab = Convert.ToInt16(conTabBasicDetails);
						if (ControlHelper.GetEnabled(FirstFocusObject))
						{
							FirstFocusObject.Focus();
						}
						return result;
					}

					mysql = " UPDATE fa_category SET ";
					if (txtParentCatNo.Enabled)
					{
						mysql = mysql + " M_cat_Cd =" + Conversion.Str(mParentCatCode) + ",";
					}
					mysql = mysql + " cat_No =" + txtCatNo.Text + ",";
					mysql = mysql + " L_cat_Name ='" + txtLCatName.Text + "',";
					mysql = mysql + " A_cat_Name =N'" + txtACatName.Text + "',";
					mysql = mysql + " remarks =N'" + txtComment.Text + "',";
					mysql = mysql + " user_cd=" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where cat_cd=" + Conversion.Str(mEntryId);

					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
				{
					if (!SaveGLLinks(mEntryId))
					{
						tabMaster.CurrTab = Convert.ToInt16(conTabGLLinks);
						grdVoucherDetails.Focus();
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						goto mError;
					}
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;

				tabMaster.CurrTab = Convert.ToInt16(conTabBasicDetails);
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}

				return result;

				mError:
				return false;
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

		public bool deleteRecord()
		{

			bool result = false;
			string mysql = " select protected from fa_category where cat_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
				{
					MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				//If an error occurs, trap the error and dispaly a valid message
				SystemVariables.gConn.BeginTransaction();

				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					mysql = "delete from fa_category where cat_cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (Information.Err().Number != 0)
					{
						MessageBox.Show("Fixed Assets Category cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}

					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();
					result = true;
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}

			return result;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			if (mReturnErrorType == 1)
			{
				return false;
			}
			else if (mReturnErrorType == 2)
			{ 
				AddRecord();
				return false;
			}
			else
			{
				return false;
			}
		}

		public void GetRecord(object SearchValue)
		{
			object mReturnValue = null;
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting
			SqlDataReader localRec = null;

			string mysql = " select * from fa_category where cat_cd =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand.ExecuteReader();
			if (localRec.Read())
			{
				mSearchValue = localRec["cat_cd"];
				mTimeStamp = Convert.ToString(localRec["time_stamp"]);
				txtCatNo.Text = Convert.ToString(localRec["cat_no"]);
				txtLCatName.Text = Convert.ToString(localRec["l_cat_Name"]);
				txtACatName.Text = Convert.ToString(localRec["a_cat_Name"]) + "";
				if (Convert.ToDouble(localRec["m_cat_cd"]) == 0)
				{
					txtParentCatNo.Enabled = false;
				}
				else
				{
					txtParentCatNo.Enabled = true;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cat_name,cat_no" : " a_cat_name, cat_no") + " from fa_category where cat_cd=" + Convert.ToString(localRec["m_cat_cd"])));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtParentCatNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtParentCatName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				}
				txtComment.Text = Convert.ToString(localRec["remarks"]) + "";


				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_fixed_asset_gl_link")))
				{
					GetAccountInfo(ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
				}
				mCategoryDefaultSet = true;
			}
			localRec.Close();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void PrintReport()
		{
			SystemReports.GetSystemReport(51001030, 1);

		}

		public void findRecord()
		{

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(8003000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		public void cmdGetNextNumber_Click()
		{
			txtCatNo.Text = SystemProcedure2.GetNewNumber("fa_category", "cat_no");
			FirstFocusObject.Focus();
		}

		public bool CheckDataValidity()
		{
			if (!Information.IsNumeric(txtCatNo.Text))
			{
				MessageBox.Show("Enter Category Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = Convert.ToInt16(conTabBasicDetails);
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				return false;
			}

			if (txtParentCatNo.Enabled)
			{
				if (!Information.IsNumeric(txtParentCatNo.Text))
				{
					MessageBox.Show("Enter Parent Category Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					tabMaster.CurrTab = Convert.ToInt16(conTabBasicDetails);
					if (txtParentCatNo.Enabled)
					{
						txtParentCatNo.Focus();
					}
					return false;
				}
			}

			return true;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				aLedger = null;
				rsLedgerList = null;
				rsCostList = null;
				UserAccess = null;

				oThisFormToolBar = null;
				frmFACategory.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCatNo_DropButtonClick(Object Sender, EventArgs e)
		{
			GetNextNumber();
		}

		private void txtParentCatNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtParentCatNo");
		}

		public void txtParentCatNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int Cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtParentCatNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cat_name" : "a_cat_name");
					mysql = mysql + " , cat_cd ";
					mysql = mysql + " from fa_category where cat_no=" + txtParentCatNo.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtParentCatName.Text = "";
						//txtParentCostNo.SetFocus
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtParentCatName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));

						if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode && !mCategoryDefaultSet)
						{
							GetAccountInfo(ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(1)));
							mCategoryDefaultSet = true;
						}
					}
				}
				else
				{
					txtParentCatName.Text = "";
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
					//    txtParentCostNo.SetFocus
				}
				else
				{
					//
				}
			}
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtParentCatNo" : 
					 
					txtParentCatNo.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(8003000, "1124,1125,1126")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtParentCatNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtACatName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						txtParentCatNo_Leave(txtParentCatNo, new EventArgs());
					} 
					break;
				default:
					return;
			}
		}

		public void GetNextNumber()
		{
			txtCatNo.Text = SystemProcedure2.GetNewNumber("fa_category", "cat_no");
			FirstFocusObject.Focus();
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbCommon.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbCommon_DataSourceChanged()
		{
			int Cnt = 0;
			cmbCommon.Width = 0;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			switch(grdVoucherDetails.Col)
			{
				case grdLedgerCode : 
					int tempForEndVar = cmbCommon.Columns.Count - 1; 
					for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbCommon.Splits[0].DisplayColumns[Cnt];
						if (Cnt < 2)
						{
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							switch(Cnt)
							{
								case 0 : 
									//.Order = IIf(grdVoucherDetails.Col = grdLedgerCode, 0, 1) 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdLedgerCode].Width; 
									withVar.Visible = true; 
									break;
								case 1 : 
									//.Order = IIf(grdVoucherDetails.Col = grdLedgerCode, 0, 1) 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdLedgerName].Width; 
									withVar.Visible = true; 
									break;
							}

							cmbCommon.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					cmbCommon.Width += 17; 
					cmbCommon.Height = 167; 
					break;
				case grdCCNo : 
					int tempForEndVar2 = cmbCommon.Columns.Count - 1; 
					for (Cnt = 0; Cnt <= tempForEndVar2; Cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_2 = cmbCommon.Splits[0].DisplayColumns[Cnt];
						if (Cnt < 2)
						{
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							withVar_2.Visible = true;
							if (Cnt == 0)
							{
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.DisplayColumns[Cnt].Width = grdVoucherDetails.Splits[0].DisplayColumns[grdCCNo].Width;
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.Width += grdVoucherDetails.Splits[0].DisplayColumns[grdCCNo].Width;
							}
							else if (Cnt == 1)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.DisplayColumns[Cnt].Width = grdVoucherDetails.Splits[0].DisplayColumns[grdCCName].Width;
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.Width += grdVoucherDetails.Splits[0].DisplayColumns[grdCCName].Width;
							}
						}
						else
						{
							withVar_2.Visible = false;
						}
						withVar_2.AllowSizing = false;
					} 
					cmbCommon.Width += 17; 
					cmbCommon.Height = 100; 
					break;
				default:
					cmbCommon.Width = 0; 
					break;
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbCommon.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbCommon_DropDownClose()
		{
			if (tabMaster.CurrTab == 1)
			{
				grdVoucherDetails.UpdateData();
				grdVoucherDetails.RefreshRow(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Bookmark)));
				grdVoucherDetails_RowColChange(grdVoucherDetails, new C1.Win.C1TrueDBGrid.RowColChangeEventArgs());

				if (grdVoucherDetails.Col == grdLedgerCode)
				{
					grdVoucherDetails.Col = grdCCNo;
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbCommon.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbCommon_RowChange()
		{
			if (grdVoucherDetails.Col == grdLedgerCode)
			{
				grdVoucherDetails.Columns[grdLedgerName].Value = cmbCommon.Columns[1].Value;
				//grdVoucherDetails.Columns(grdApplyCostCenter).Value = cmbCommon.Columns(2).Value
			}
			else if (grdVoucherDetails.Col == grdCCNo)
			{ 
				grdVoucherDetails.Columns[grdCCName].Value = cmbCommon.Columns[1].Value;
			}
		}

		private bool SaveGLLinks(int pAssetCd)
		{
			bool result = false;
			string mysql = "";
			string mGroupFilterClause = "";
			//On Error GoTo eFoundError

			int Cnt = 0;

			object mTempValue = null;
			object[, ] mLedger = new object[mMaxArrayRows + 1, 2];
			grdVoucherDetails.UpdateData();
			for (Cnt = 0; Cnt <= mMaxArrayRows; Cnt++)
			{
				if (SystemProcedure2.IsItEmpty(aLedger.GetValue(Cnt, grdLedgerCode), SystemVariables.DataType.StringType))
				{
					mLedger[Cnt, 0] = "NULL";
					mLedger[Cnt, 1] = "NULL";
				}
				else
				{
					mGroupFilterClause = FilterGroupCodeOnLedgerSql(Convert.ToString(aLedger.GetValue(Cnt, grdGroupCodeFilterOnLedger)), true);
					mysql = "select ldgr_cd from gl_ledger ";
					mysql = mysql + " where ldgr_no='" + Convert.ToString(aLedger.GetValue(Cnt, grdLedgerCode)) + "'";
					mysql = mysql + " and ( " + mGroupFilterClause + ")";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						goto eFoundError1;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLedger[Cnt, 0] = ReflectionHelper.GetPrimitiveValue(mTempValue);
						mLedger[Cnt, 1] = "NULL";
					}
				}
			}


			mysql = " update fa_category set ";
			if (ReflectionHelper.GetPrimitiveValue<string>(mLedger[0, 0]) == "NULL")
			{
				mysql = mysql + " debit_accnt_cd =NULL ,";
			}
			else
			{
				mysql = mysql + " debit_accnt_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[0, 0]) + ",";
			}

			if (ReflectionHelper.GetPrimitiveValue<string>(mLedger[1, 0]) == "NULL")
			{
				mysql = mysql + " accum_depr_accnt_Cd = NULL , ";
			}
			else
			{
				mysql = mysql + " accum_depr_accnt_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[1, 0]) + ",";
			}

			if (ReflectionHelper.GetPrimitiveValue<string>(mLedger[2, 0]) == "NULL")
			{
				mysql = mysql + " depr_accnt_cd = NULL ,";
			}
			else
			{
				mysql = mysql + " depr_accnt_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[2, 0]) + ",";
			}

			if (ReflectionHelper.GetPrimitiveValue<string>(mLedger[3, 0]) == "NULL")
			{
				mysql = mysql + " adjustment_accnt_Cd = NULL ,";
			}
			else
			{
				mysql = mysql + " adjustment_accnt_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[3, 0]) + ",";
			}

			if (ReflectionHelper.GetPrimitiveValue<string>(mLedger[4, 0]) == "NULL")
			{
				mysql = mysql + " writeoff_accnt_Cd = NULL ,";
			}
			else
			{
				mysql = mysql + " writeoff_accnt_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[4, 0]) + ",";
			}

			if (ReflectionHelper.GetPrimitiveValue<string>(mLedger[5, 0]) == "NULL")
			{
				mysql = mysql + " sales_accnt_Cd = NULL ";
			}
			else
			{
				mysql = mysql + " sales_accnt_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[5, 0]) + "";
			}

			mysql = mysql + " where cat_cd =" + Conversion.Str(pAssetCd);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();


			return true;

			eFoundError1:
			MessageBox.Show("Invalid Ledger Account", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			tabMaster.CurrTab = Convert.ToInt16(conTabGLLinks);
			grdVoucherDetails.Col = grdLedgerCode;
			grdVoucherDetails.Bookmark = Cnt;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				grdVoucherDetails.Focus();
				return false;


				MessageBox.Show("Invalid Cost Center ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = Convert.ToInt16(conTabGLLinks);
				grdVoucherDetails.Bookmark = Cnt;
				grdVoucherDetails.Col = grdCCNo;
				grdVoucherDetails.Focus();
				return false;



				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "savegllinks", SystemConstants.msg10);
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
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			//If Col = grdCCNo Then
			//    If aLedger(Bookmark, grdApplyCostCenter) = True Then
			//        CellStyle.BackColor = grdVoucherDetails.Columns(grdCCNo).BackColor
			//        CellStyle.ForeColor = grdVoucherDetails.Columns(grdCCNo).ForeColor
			//        grdVoucherDetails.Columns(grdCCNo).AllowFocus = True
			//    Else
			//        CellStyle.BackColor = gDisableColumnBackColor
			//        CellStyle.ForeColor = gDisableColumnBackColor
			//        grdVoucherDetails.Columns(grdCCNo).AllowFocus = False
			//    End If
			//End If
		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			string mFilterClause = "";
			if (grdVoucherDetails.Col > 0)
			{ //And mFirstGridFocus = True Then
				switch(grdVoucherDetails.Col)
				{
					case grdLedgerCode : 
						//''''Change the filter on the listbox 
						 
						mFilterClause = FilterGroupCodeOnLedgerSql(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdGroupCodeFilterOnLedger].Value)); 
						//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						rsLedgerList.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone(); 
						rsLedgerList.Tables[0].DefaultView.RowFilter = mFilterClause; 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbCommon.setDataSource((msdatasrc.DataSource) rsLedgerList); 
						break;
					case grdCCNo : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbCommon.setDataSource((msdatasrc.DataSource) rsCostList); 
						break;
				}
			}
			//
			//If grdVoucherDetails.Row <> LastRow Then
			//    If grdVoucherDetails.AddNewMode = dbgNoAddNew Then
			//        If Val(grdVoucherDetails.Columns(grdApplyCostCenter).Value) = True Then
			//            grdVoucherDetails.Columns(grdCCNo).AllowFocus = True
			//        Else
			//            grdVoucherDetails.Columns(grdCCNo).AllowFocus = False
			//        End If
			//    ElseIf grdVoucherDetails.AddNewMode = dbgAddNewCurrent Then
			//    Else                    'if grdVoucherDetails.AddNewMode = dbgAddNewPending
			//        If Val(grdVoucherDetails.Columns(grdApplyCostCenter).Value) = True Then
			//            grdVoucherDetails.Columns(grdCCNo).AllowFocus = True
			//        Else
			//            grdVoucherDetails.Columns(grdCCNo).AllowFocus = False
			//        End If
			//    End If
			//Else
			//    If aLedger.Count(1) > 0 And IsNull(LastRow) = True Then
			//        If Val(grdVoucherDetails.Columns(grdApplyCostCenter).Value) = True Then
			//            grdVoucherDetails.Columns(grdCCNo).AllowFocus = True
			//        Else
			//            grdVoucherDetails.Columns(grdCCNo).AllowFocus = False
			//        End If
			//    End If
			//End If
		}

		private void GenerateRecordSet()
		{

			string mysql = "select ldgr_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name as ldgr_name" : "a_ldgr_name as ldgr_name");
			mysql = mysql + " , type_cd from gl_ledger order by 1";
			rsLedgerList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsLedgerList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsLedgerList.Tables.Clear();
			adap.Fill(rsLedgerList);

			mysql = "select cost_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cost_name as cost_name" : "a_cost_name as cost_name");
			mysql = mysql + " from gl_cost_centers order by 1";
			rsCostList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCostList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsCostList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsCostList.Tables.Clear();
			adap_2.Fill(rsCostList);
		}

		private string FilterGroupCodeOnLedgerSql(string pGroupCodeList, bool pUseLeftClause = false)
		{
			int Cnt = 0;
			StringBuilder mFilterClause = new StringBuilder();

			string[] mGroupCodeFilterList = pGroupCodeList.Split(',');

			int tempForEndVar = mGroupCodeFilterList.GetUpperBound(0);
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				if (Cnt > 0)
				{
					mFilterClause.Append(" or ");
				}
				//If pUseLeftClause = True Then
				//    mFilterClause = mFilterClause & " left(group_cd,4) = '" & Trim(mGroupCodeFilterList(cnt)) & "'"
				//Else
				mFilterClause.Append(" type_cd =" + mGroupCodeFilterList[Cnt].Trim());
				//End If
			}

			return mFilterClause.ToString();
		}

		private void GetAccountInfo(int pCatCd)
		{

			ResetGridArray();

			string mysql = " select ";
			mysql = mysql + " Ledger_1.Ldgr_No AS Expr1";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_1.L_Ldgr_Name " : "Ledger_1.a_ldgr_Name") + " AS Expr2 ";
			//mySql = mySql & " , Ledger_1.apply_cost_center AS inventory_apply_cost "

			mysql = mysql + " , Ledger_2.Ldgr_No AS Expr3 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_2.L_Ldgr_Name " : "Ledger_2.a_ldgr_Name") + " AS Expr4 ";
			//mySql = mySql & " , Ledger_2.apply_cost_center AS adjustment_apply_cost "

			mysql = mysql + " , Ledger_3.Ldgr_No AS Expr5";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_3.L_Ldgr_Name " : "Ledger_3.a_ldgr_Name") + " AS Expr6 ";
			//mySql = mySql & " , Ledger_3.apply_cost_center AS cost_of_sale_apply_cost "

			mysql = mysql + " , Ledger_4.Ldgr_No AS Expr7";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_4.L_Ldgr_Name " : "Ledger_4.a_ldgr_Name") + " AS Expr8 ";
			//mySql = mySql & " , Ledger_4.apply_cost_center AS pdis_apply_cost "

			mysql = mysql + " , Ledger_5.Ldgr_No AS Expr9 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_5.L_Ldgr_Name " : "Ledger_5.a_ldgr_Name") + " AS Expr10 ";
			//mySql = mySql & " , Ledger_5.apply_cost_center AS cash_sale_apply_cost "

			mysql = mysql + " , Ledger_6.Ldgr_No AS Expr11";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_6.L_Ldgr_Name " : "Ledger_6.a_ldgr_Name") + " AS Expr12 ";
			//mySql = mySql & " , Ledger_6.apply_cost_center AS credit_sale_apply_cost "

			mysql = mysql + " , cc_1.cost_No AS Expr31 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_1.L_cost_Name " : "cc_1.a_cost_Name") + " AS Expr32 ";
			mysql = mysql + " , cc_2.cost_No AS Expr33 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_2.L_cost_Name " : "cc_2.a_cost_Name") + " AS Expr34 ";
			mysql = mysql + " , cc_3.cost_No AS Expr35 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_3.L_cost_Name " : "cc_3.a_cost_Name") + " AS Expr36 ";
			mysql = mysql + " , cc_4.cost_No AS Expr37 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_4.L_cost_Name " : "cc_4.a_cost_Name") + " AS Expr38 ";
			mysql = mysql + " , cc_5.cost_No AS Expr39 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_5.L_cost_Name " : "cc_5.a_cost_Name") + " AS Expr40 ";
			mysql = mysql + " , cc_6.cost_No AS Expr41 ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_6.L_cost_Name " : "cc_6.a_cost_Name") + " AS Expr42 ";

			mysql = mysql + " FROM fa_category fa ";
			mysql = mysql + " left JOIN gl_ledger Ledger_1 ON fa.debit_accnt_cd = Ledger_1.Ldgr_Cd";
			mysql = mysql + " left JOIN gl_ledger ledger_2 ON fa.accum_depr_accnt_Cd = ledger_2.Ldgr_Cd";
			mysql = mysql + " left JOIN gl_ledger ledger_3 ON fa.depr_accnt_Cd = ledger_3.Ldgr_Cd";
			mysql = mysql + " left JOIN gl_ledger ledger_4 ON fa.adjustment_accnt_cd = ledger_4.Ldgr_Cd";
			mysql = mysql + " left JOIN gl_ledger ledger_5 ON fa.writeoff_accnt_Cd = ledger_5.Ldgr_Cd";
			mysql = mysql + " left JOIN gl_ledger ledger_6 ON fa.sales_accnt_Cd = ledger_6.Ldgr_Cd";

			mysql = mysql + " left JOIN gl_cost_centers cc_1 ON fa.debit_cc_cd = cc_1.cost_Cd ";
			mysql = mysql + " left JOIN gl_cost_centers cc_2 ON fa.accum_depr_cc_Cd = cc_2.cost_Cd ";
			mysql = mysql + " left JOIN gl_cost_centers cc_3 ON fa.depr_cc_Cd = cc_3.cost_Cd ";
			mysql = mysql + " left JOIN gl_cost_centers cc_4 ON fa.adjustment_cc_cd = cc_4.cost_Cd";
			mysql = mysql + " left JOIN gl_cost_centers cc_5 ON fa.writeoff_cc_Cd = cc_5.cost_Cd";
			mysql = mysql + " left JOIN gl_cost_centers cc_6 ON fa.sales_cc_Cd = cc_6.cost_Cd ";

			if (pCatCd > 0)
			{
				mysql = mysql + " where fa.cat_cd =" + Conversion.Str(pCatCd);
			}
			else
			{
				mysql = mysql + " where fa.cat_cd = 1 ";
			}

			DataSet tempRec = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			tempRec.Tables.Clear();
			adap.Fill(tempRec);
			if (tempRec.Tables[0].Rows.Count != 0)
			{
				//''Inventory Cost
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr1"], 0, grdLedgerCode);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr2"], 0, grdLedgerName);
				//aLedger(0, grdApplyCostCenter) = .Fields("inventory_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr31"], 0, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr32"], 0, grdCCName);


				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr3"], 1, grdLedgerCode);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr4"], 1, grdLedgerName);
				//aLedger(1, grdApplyCostCenter) = .Fields("adjustment_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr33"], 1, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr34"], 1, grdCCName);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr5"], 2, grdLedgerCode);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr6"], 2, grdLedgerName);
				//aLedger(2, grdApplyCostCenter) = .Fields("cost_of_sale_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr35"], 2, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr36"], 2, grdCCName);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr7"], 3, grdLedgerCode);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr8"], 3, grdLedgerName);
				//aLedger(3, grdApplyCostCenter) = .Fields("pdis_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr37"], 3, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr38"], 3, grdCCName);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr9"], 4, grdLedgerCode);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr10"], 4, grdLedgerName);
				//aLedger(4, grdApplyCostCenter) = .Fields("cash_sale_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr39"], 4, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr40"], 4, grdCCName);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr11"], 5, grdLedgerCode);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr12"], 5, grdLedgerName);
				//aLedger(5, grdApplyCostCenter) = .Fields("credit_sale_apply_cost").Value
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr41"], 5, grdCCNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr42"], 5, grdCCName);

				grdVoucherDetails.Rebind(true);
			}
			tempRec = null;

			grdVoucherDetails.Col = 1;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			//grdVoucherDetails.SetFocus

		}

		private void ResetGridArray()
		{
			//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aLedger.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			aLedger.Clear();
			aLedger.RedimXArray(new int[]{mMaxArrayRows, mMaxArrayCols}, new int[]{0, 0});
			aLedger.SetValue("Debit Account", 0, grdAccountType);
			aLedger.SetValue(SystemProcedure2.GetSystemPreferenceSetting("fa_debit_filter_string"), 0, grdGroupCodeFilterOnLedger);

			aLedger.SetValue("Accumulated Depreciation A/c", 1, grdAccountType);
			aLedger.SetValue(SystemProcedure2.GetSystemPreferenceSetting("fa_accum_depr_filter_string"), 1, grdGroupCodeFilterOnLedger);

			aLedger.SetValue("Depreciation A/c", 2, grdAccountType);
			aLedger.SetValue(SystemProcedure2.GetSystemPreferenceSetting("fa_depr_filter_string"), 2, grdGroupCodeFilterOnLedger);

			aLedger.SetValue("Adjustment A/c", 3, grdAccountType);
			aLedger.SetValue(SystemProcedure2.GetSystemPreferenceSetting("fa_adjustment_filter_string"), 3, grdGroupCodeFilterOnLedger);

			aLedger.SetValue("WriteOff A/c", 4, grdAccountType);
			aLedger.SetValue(SystemProcedure2.GetSystemPreferenceSetting("fa_writeoff_filter_string"), 4, grdGroupCodeFilterOnLedger);

			aLedger.SetValue("Sales Account A/c", 5, grdAccountType);
			aLedger.SetValue(SystemProcedure2.GetSystemPreferenceSetting("fa_sales_filter_string"), 5, grdGroupCodeFilterOnLedger);

			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aLedger);
			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Refresh();
		}
	}
}