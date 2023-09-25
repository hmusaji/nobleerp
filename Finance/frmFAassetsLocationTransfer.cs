
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmFAassetsLocationTransfer
		: System.Windows.Forms.Form
	{

		public frmFAassetsLocationTransfer()
{
InitializeComponent();
} 
 public  void frmFAassetsLocationTransfer_old()
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


		private void frmFAassetsLocationTransfer_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
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
		private string mTimeStamp = "";
		private bool mFirstGridFocus = false;
		private clsToolbar oThisFormToolBar = null;

		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;


		private XArrayHelper _aAsset = null;
		private XArrayHelper aAsset
		{
			get
			{
				if (_aAsset is null)
				{
					_aAsset = new XArrayHelper();
				}
				return _aAsset;
			}
			set
			{
				_aAsset = value;
			}
		}

		private DataSet rsAssetList = null;
		private DataSet rsLocationList = null;

		private const int conGrdSno = 0;
		private const int conGrdAssetCd = 1;
		private const int conGrdAssetName = 2;
		private const int conGrdCurrLocatNo = 3;
		//Private Const conGrdCurrLocatName As Integer = 4
		private const int conGrdNewLocatNo = 4;
		//Private Const conGrdNewLocatName As Integer = 6

		private const int mMaxArrayCols = 4;


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
			FirstFocusObject = txtVoucherDate;

			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mFirstGridFocus = false;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
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
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;


				//
				//'Assign the Image for the toolbar
				//'Imagelist are kept on the main form and refered by their key
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture
				//Set btnFormToolBar(7).Picture = frmSysMain.imlMainToolBar.ListImages("imgInsertLine").Picture
				//Set btnFormToolBar(8).Picture = frmSysMain.imlMainToolBar.ListImages("imgDeleteLine").Picture
				//Set btnFormToolBar(9).Picture = frmSysMain.imlSystemIcons.ListImages("imgPostingTransactions").Picture

				SystemProcedure.SetLabelCaption(this);
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2, 1.4f, "&H98AFDA", "&H98AFDA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Asset Code", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Asset Name", 4000, false, SystemConstants.gDisableColumnBackColor);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Curr. Locat Code", 1000, false, SystemConstants.gDisableColumnBackColor, (0x913DA3).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Current Locat Name", 1200, False, gDisableColumnBackColor)
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "New Locat Code", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x913DA3).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon");
				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "New Locat Name", 1800, False, gDisableColumnBackColor)


				SystemGrid.DefineSystemGridCombo(cmbCommon);
				cmbCommon.Height = 100;
				cmbCommon.Width = 280;

				SystemGrid.DefineVoucherArray(aAsset, mMaxArrayCols, 0);
				aAsset.SetValue(1, 0, 0);

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aAsset);
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Refresh();
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

				if (this.ActiveControl.Name == "grdVoucherDetails")
				{
					if (KeyCode == 13 || KeyCode == 115)
					{
						return;
					}
					else if (KeyCode == 222)
					{ 
						KeyCode = 0;
						return;
					}

					if (Shift == 0)
					{
						if (grdVoucherDetails.Col == conGrdNewLocatNo || grdVoucherDetails.Col == conGrdAssetCd)
						{
							if ((KeyCode == 8) || (KeyCode == 46) || (KeyCode == 27))
							{
								//
							}
							else if ((KeyCode >= 48 && KeyCode <= 57) || (KeyCode >= 96 && KeyCode <= 105) || (KeyCode == 190) || (KeyCode == 110))
							{ 
								//
							}
							else
							{
								KeyCode = 0;
							}
						}
					}
				}


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

		public void AddRecord()
		{
			SystemProcedure2.ClearTextBox(this);

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			mSearchValue = "";
			FirstFocusObject.Focus();
			SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Asset Location Transfer" : "Asset Location Transfer");

			SystemGrid.DefineVoucherArray(aAsset, mMaxArrayCols, -1);
			//aAsset(0, 0) = 1
			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Refresh();


			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord(bool pPostGl = false)
		{
			bool result = false;
			object mReturnValue = null;
			string mysql = "";
			int mAssetCd = 0;
			int mNewLocatCd = 0;
			int mCurrLocatCd = 0;
			int mEntryId = 0;
			int Cnt = 0;

			try
			{

				SystemVariables.gConn.BeginTransaction();

				txtVoucherNo.Text = SystemProcedure2.GetNewNumber("FA_Location_Transfer", "voucher_no");

				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into fa_location_transfer ";
					mysql = mysql + " (voucher_no, voucher_date, remarks, user_cd) ";
					mysql = mysql + " values( ";
					mysql = mysql + txtVoucherNo.Text;
					mysql = mysql + ", '" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
					mysql = mysql + ", N'" + txtComments.Text + "'";
					mysql = mysql + ", " + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));

				}
				else
				{
					//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);

					mysql = " select time_stamp from fa_location_transfer ";
					mysql = mysql + " where entry_id =" + mEntryId.ToString();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}
					else
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						FirstFocusObject.Focus();
						return result;
					}

					if (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp))
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						FirstFocusObject.Focus();
						return result;
					}

					mysql = " update fa_location_transfer set ";
					mysql = mysql + " voucher_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
					mysql = mysql + " , remarks =N'" + txtComments.Text + "'";
					mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where entry_id =" + Conversion.Str(mEntryId);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

					mysql = " delete from fa_location_transfer_details where entry_id = " + Conversion.Str(mEntryId);
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

				}

				int tempForEndVar = aAsset.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					mysql = " select asset_cd from fa_items ";
					mysql = mysql + " where asset_no ='" + Convert.ToString(aAsset.GetValue(Cnt, conGrdAssetCd)) + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mAssetCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Invalid Asset Cd", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdVoucherDetails.Col = conGrdAssetCd;
						goto mError;
					}

					mysql = " select locat_cd from fa_location ";
					mysql = mysql + " where locat_no =" + Convert.ToString(aAsset.GetValue(Cnt, conGrdNewLocatNo));
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mNewLocatCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Invalid Location Cd", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdVoucherDetails.Col = conGrdNewLocatNo;
						goto mError;
					}

					mysql = " select locat_cd from fa_location ";
					mysql = mysql + " where locat_no =" + Convert.ToString(aAsset.GetValue(Cnt, conGrdCurrLocatNo));
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCurrLocatCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Invalid Location Cd", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdVoucherDetails.Col = conGrdNewLocatNo;
						goto mError;
					}


					mysql = " insert into fa_location_transfer_details ";
					mysql = mysql + " (entry_id, asset_cd, locat_cd, new_locat_cd) ";
					mysql = mysql + " values (";
					mysql = mysql + mEntryId.ToString();
					mysql = mysql + " , " + mAssetCd.ToString();
					mysql = mysql + " , " + mCurrLocatCd.ToString();
					mysql = mysql + " , " + mNewLocatCd.ToString();
					mysql = mysql + " ) ";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();

				}

				if (pPostGl)
				{
					if (!PostFALocationTransfer(mEntryId))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}
					else
					{
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsAssetList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsAssetList.Requery(-1);
					}
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();



				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					MessageBox.Show(" Transaction has been saved with No: " + txtVoucherNo.Text, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				result = true;
				FirstFocusObject.Focus();
				return result;

				mError:
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				grdVoucherDetails.Bookmark = Cnt;
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

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 1);
				result = false;
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				return result;
			}


			SystemVariables.gConn.BeginTransaction();

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "delete from fa_location_transfer_details where entry_id =" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mysql = "delete from fa_location_transfer where entry_id =" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Fixed Asset Location Transfer cannot be deleted., transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();


				return true;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					AddRecord();
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

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			try
			{
				string mysql = "";
				object mReturnValue = null;
				int Cnt = 0;
				SqlDataReader localRec = null;

				mysql = " select mt.voucher_no , mt.voucher_date , mt.remarks , mt.status , mt.entry_id ";
				mysql = mysql + " , mt.time_stamp ";
				mysql = mysql + " , lold.locat_no currlocatno, lnew.locat_no newlocatno ";
				mysql = mysql + " , fa_items.asset_no , fa_items.l_asset_name , fa_items.a_asset_name ";
				mysql = mysql + " from  fa_location_transfer mt ";
				mysql = mysql + " inner join fa_location_transfer_details dt on mt.entry_id = dt.entry_id ";
				mysql = mysql + " inner join fa_location lold on dt.locat_cd = lold.locat_cd ";
				mysql = mysql + " inner join fa_location lnew on dt.new_locat_cd = lnew.locat_cd ";
				mysql = mysql + " inner join fa_items on dt.asset_cd = fa_items.asset_cd ";
				mysql = mysql + " where mt.entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{
					mSearchValue = localRec["entry_id"];
					mTimeStamp = Convert.ToString(localRec["time_stamp"]);
					txtVoucherNo.Text = Convert.ToString(localRec["voucher_no"]);
					txtVoucherDate.Value = localRec["voucher_date"];
					txtComments.Text = Convert.ToString(localRec["remarks"]) + "";

					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
					SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, Convert.ToInt32(localRec["status"]), CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Asset Location Transafer" : "Asset Location Transafer");

					SystemGrid.DefineVoucherArray(aAsset, mMaxArrayCols, -1, true);
					do 
					{
						SystemGrid.DefineVoucherArray(aAsset, mMaxArrayCols, Cnt);

						aAsset.SetValue(localRec["asset_no"], Cnt, conGrdAssetCd);
						if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
						{
							aAsset.SetValue(localRec["l_asset_name"], Cnt, conGrdAssetName);
						}
						else
						{
							aAsset.SetValue(localRec["a_asset_name"], Cnt, conGrdAssetName);
						}
						aAsset.SetValue(localRec["currlocatno"], Cnt, conGrdCurrLocatNo);
						aAsset.SetValue(localRec["newlocatno"], Cnt, conGrdNewLocatNo);

						Cnt++;
					}
					while(localRec.Read());

					AssignGridLineNumbers();
					grdVoucherDetails.Rebind(true);
					grdVoucherDetails.Refresh();

				}
				localRec.Close();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}


		}

		public void PrintReport()
		{

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(8009000));
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

		public bool CheckDataValidity()
		{
			bool result = false;
			int Cnt = 0;

			grdVoucherDetails.UpdateData();

			int tempForEndVar = 0;
			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				if (mOldVoucherStatus == SystemVariables.VoucherStatus.stPosted)
				{ //if voucher is in posted mode
					MessageBox.Show("Voucher already posted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (mOldVoucherStatus == SystemVariables.VoucherStatus.stVoid)
				{  //if voucher is in deleted mode
					MessageBox.Show("Voucher already Void!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{


				if (!Information.IsDate(txtVoucherDate.Value))
				{
					MessageBox.Show("Enter Valid Date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					FirstFocusObject.Focus();
					return false;
				}

				if (aAsset.GetLength(0) > 0)
				{
				}
				else
				{
					MessageBox.Show("Enter Details information ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					FirstFocusObject.Focus();
					return false;
				}

				tempForEndVar = aAsset.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					if (SystemProcedure2.IsItEmpty(aAsset.GetValue(Cnt, conGrdAssetCd), SystemVariables.DataType.StringType))
					{
						MessageBox.Show("Invalid Asset Code ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						grdVoucherDetails.Col = conGrdAssetCd;
						grdVoucherDetails.Bookmark = Cnt;
						return result;
					}

					if (SystemProcedure2.IsItEmpty(aAsset.GetValue(Cnt, conGrdNewLocatNo), SystemVariables.DataType.NumberType))
					{
						MessageBox.Show("Invalid Location  Code ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						grdVoucherDetails.Col = conGrdNewLocatNo;
						grdVoucherDetails.Bookmark = Cnt;
						return result;
					}

					if (aAsset.GetValue(Cnt, conGrdCurrLocatNo) == aAsset.GetValue(Cnt, conGrdNewLocatNo))
					{
						MessageBox.Show("Current Location and New location cannot be same.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						grdVoucherDetails.Col = conGrdNewLocatNo;
						grdVoucherDetails.Bookmark = Cnt;
						return result;
					}

				}

				return true;

			}

			return false;

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				rsAssetList = null;
				rsLocationList = null;
				oThisFormToolBar = null;
				frmFAassetsLocationTransfer.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
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
				case conGrdAssetCd : 
					int tempForEndVar = cmbCommon.Columns.Count - 1; 
					for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbCommon.Splits[0].DisplayColumns[Cnt];
						if (Cnt < 3)
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
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[conGrdAssetCd].Width; 
									withVar.Visible = true; 
									break;
								case 1 : 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[conGrdAssetName].Width; 
									withVar.Visible = true; 
									break;
								case 2 : 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[conGrdCurrLocatNo].Width; 
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
				case conGrdNewLocatNo : 
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
								cmbCommon.DisplayColumns[Cnt].Width = grdVoucherDetails.Splits[0].DisplayColumns[conGrdNewLocatNo].Width;
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.Width += grdVoucherDetails.Splits[0].DisplayColumns[conGrdNewLocatNo].Width;
							}
							else if (Cnt == 1)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.DisplayColumns[Cnt].Width = grdVoucherDetails.Splits[0].DisplayColumns[conGrdAssetName].Width;
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.Width += grdVoucherDetails.Splits[0].DisplayColumns[conGrdAssetName].Width;
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
			grdVoucherDetails.UpdateData();
			grdVoucherDetails.RefreshRow(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Bookmark)));
			grdVoucherDetails_RowColChange(grdVoucherDetails, new C1.Win.C1TrueDBGrid.RowColChangeEventArgs());

			if (grdVoucherDetails.Col == conGrdAssetCd)
			{
				grdVoucherDetails.Col = conGrdNewLocatNo;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbCommon.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbCommon_RowChange()
		{
			if (grdVoucherDetails.Col == conGrdAssetCd)
			{
				grdVoucherDetails.Columns[conGrdAssetName].Value = cmbCommon.Columns[1].Value;
				grdVoucherDetails.Columns[conGrdCurrLocatNo].Value = cmbCommon.Columns[2].Value;
				//grdVoucherDetails.Columns(conGrdCurrLocatName).Value = cmbCommon.Columns(3).Value
			}
			else if (grdVoucherDetails.Col == conGrdNewLocatNo)
			{ 
				//grdVoucherDetails.Columns(conGrdNewLocatName).Value = cmbCommon.Columns(1).Value
			}
		}

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";


			if (SystemProcedure2.IsItEmpty(Convert.ToString(grdVoucherDetails.Tag), SystemVariables.DataType.StringType))
			{
				grdVoucherDetails.Tag = "1";

				GenerateRecordSet();
				//Call cmbCommon_RowChange
			}

			grdVoucherDetails.Col = conGrdAssetCd;
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			cmbCommon.setDataSource((msdatasrc.DataSource) rsAssetList);
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			grdVoucherDetails.Columns[conGrdSno].Text = (grdVoucherDetails.RowCount + 1).ToString();
		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdVoucherDetails.Col > 0 && mFirstGridFocus)
			{
				switch(grdVoucherDetails.Col)
				{
					case conGrdAssetCd : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbCommon.setDataSource((msdatasrc.DataSource) rsAssetList); 
						break;
					case conGrdNewLocatNo : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbCommon.setDataSource((msdatasrc.DataSource) rsLocationList); 
						break;
				}
			}

			mFirstGridFocus = true;

			//If grdVoucherDetails.Row <> LastRow Then
			//    If grdVoucherDetails.AddNewMode = dbgNoAddNew Then
			//    ElseIf grdVoucherDetails.AddNewMode = dbgAddNewCurrent Then
			//    Else
			//    End If
			//Else
			//'    If mFirstGridFocus = True And aAsset.Count(1) > 0 And IsNull(LastRow) = True Then
			//'    End If
			//End If

		}

		private void GenerateRecordSet()
		{

			string mysql = "select asset_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_asset_name as asset_name" : "a_asset_name as asset_name");
			mysql = mysql + " , locat_no ";
			mysql = mysql + "," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name as locat_name" : "a_locat_name as locat_name");
			mysql = mysql + " from fa_items fa ";
			mysql = mysql + " inner join fa_location fl on fa.locat_cd = fl.locat_cd ";
			mysql = mysql + " where fa.status = 2 ";
			mysql = mysql + " order by 1";

			rsAssetList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsAssetList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsAssetList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsAssetList.Tables.Clear();
			adap.Fill(rsAssetList);

			mysql = "select locat_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name as locat_name" : "a_locat_name as locat_name");
			mysql = mysql + " from fa_location order by 1";
			rsLocationList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLocationList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsLocationList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsLocationList.Tables.Clear();
			adap_2.Fill(rsLocationList);

		}

		public void IRoutine()
		{
			if (ActiveControl.Name != "grdVoucherDetails")
			{
				grdVoucherDetails.Focus();
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdVoucherDetails.Bookmark))
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aAsset.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aAsset.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), 1);
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Focus();
				grdVoucherDetails.Refresh();
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdVoucherDetails")
			{
				grdVoucherDetails.Focus();
			}

			if (aAsset.GetLength(0) > 0)
			{
				grdVoucherDetails.Delete();
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
			}
		}

		private void AssignGridLineNumbers()
		{
			int Cnt = 0;

			int tempForEndVar = aAsset.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				aAsset.SetValue(Cnt + 1, Cnt, conGrdSno);
			}
		}


		public bool Post()
		{
			bool result = false;
			DialogResult ans = (DialogResult) 0;
			frmSysOnlinePosting frmTemp = frmSysOnlinePosting.CreateInstance();

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 2);
				result = false;
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				return result;
			}


			frmTemp.ShowDialog();

			if (frmTemp.mApprove)
			{

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					ans = MessageBox.Show(SystemConstants.msg19 + "\r" + "\r" + SystemConstants.msg7, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				}
				else
				{
					ans = MessageBox.Show("                         Do you want to Post the Record ?                          " + "\r" + "\r" + "\r" + " NOTE :            Yes : To post after saving. " + "\r" + "                         No : To post without saving " + "\r" + "                         Cancel : To exit without posting ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
				}

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						goto mend;
					}
				}
				else
				{
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						goto mend;
					}
					else if (ans == System.Windows.Forms.DialogResult.No)
					{ 
						if (frmTemp.mApprove)
						{
							SystemVariables.gConn.BeginTransaction();

							if (!PostFALocationTransfer(ReflectionHelper.GetPrimitiveValue<int>(SearchValue)))
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								result = false;
								goto mDestroy;
							}
							else
							{
							}

							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.CommitTrans();
						}
					}

					result = true;
					goto mDestroy;
				}
			}

			goto mDestroy;

			mend:
			if (CheckDataValidity())
			{
				if (saveRecord(frmTemp.mApprove))
				{
					result = true;
					goto mDestroy;
				}
			}
			result = false;

			mDestroy:
			frmTemp.Close();
			return result;
		}

		private bool PostFALocationTransfer(int pEntryId)
		{


			StringBuilder mysql = new StringBuilder();
			mysql.Append(" select asset_cd , new_locat_cd from fa_location_transfer_details ");
			mysql.Append(" where entry_id =" + pEntryId.ToString());
			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql.ToString(), SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{
				mysql = new StringBuilder(" update fa_items set ");
				mysql.Append(" locat_cd =" + Convert.ToString(rsTempRec["new_locat_cd"]));
				mysql.Append(" where asset_cd =" + Convert.ToString(rsTempRec["asset_cd"]));
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql.ToString();
				TempCommand.ExecuteNonQuery();

				mysql = new StringBuilder(" update FA_Location_Transfer set ");
				mysql.Append(" status = 2 ");
				mysql.Append(" where entry_id=" + pEntryId.ToString());
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql.ToString();
				TempCommand_2.ExecuteNonQuery();

			}
			while(rsTempRec.Read());

			rsTempRec.Close();

			return true;
		}
	}
}