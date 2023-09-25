
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmICSFreezeStock
		: System.Windows.Forms.Form
	{

		private clsAccessAllowed _UserAccess = null;
		public frmICSFreezeStock()
{
InitializeComponent();
} 
 public  void frmICSFreezeStock_old()
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

		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;

		private const int gccLineNoColumn = 0;
		private const int gccPartNoColumn = 1;
		private const int gccProdNameColumn = 2;
		private const int gccFreezeQtyColumn = 3;

		private const int conTxtFreezeNo = 0;
		private const int conTxtLocationCode = 1;
		private const int conTxtComments = 2;
		private const int conTXTReferenceNo = 3;
		private const int conTxtBatchNo = 4;

		private const int conDlblBatchName = 1;
		private const int conDlblLocationName = 2;



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


		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					FirstFocusObject.Focus();
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				FirstFocusObject = txtFreezeDate;
				//picFormToolbar.Visible = False
				grdVoucherDetails.Visible = false;

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
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				//
				//'Assign the Image for the toolbar
				//'Imagelist are kept on the main form and refered by their key
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(8).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture
				//Set btnFormToolBar(9).Picture = frmSysMain.imlSystemIcons.ListImages("imgPostingTransactions").Picture
				//

				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(1))
				//picFormToolbar.Visible = True


				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
				mFirstGridFocus = true;


				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.9f);
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Part No.", 1500, false, SystemConstants.gDisableColumnBackColor);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Part Name", 4500, false, SystemConstants.gDisableColumnBackColor);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Freeze Qty.", 900, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far);


				DefineVoucherArray(0, true);

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				//-- end of voucher grid property setting

				txtCommonTextBox[conTxtFreezeNo].Text = SystemProcedure2.GetNewNumber("ics_freeze_stock", "freeze_no");

				txtFreezeDate.Value = DateTime.Today;
				grdVoucherDetails.Visible = true;
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

				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}

				if (this.ActiveControl.Name == "txtCommonTextBox")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommonTextBox#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
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

				aVoucherDetails = null;
				UserAccess = null;
				oThisFormToolBar = null;
				frmICSFreezeStock.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void DefineVoucherArray(int pMaximumRows, bool pClearArray = false)
		{
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
			}
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, 9}, new int[]{0, 0});
		}

		public bool saveRecord(bool pApprove = false)
		{

			bool result = false;
			int mLocatCd = 0;
			int mBatchCd = 0;
			int mEntryId = 0;



			//On Error GoTo eFoundError

			string mysql = "select locat_cd ";
			mysql = mysql + " from SM_Location where ";
			mysql = mysql + " locat_no = " + txtCommonTextBox[conTxtLocationCode].Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				MessageBox.Show("Invalid Location Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = false;
				txtCommonTextBox[conTxtLocationCode].Focus();
				return result;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mLocatCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}

			mysql = "select batch_cd ";
			mysql = mysql + " from ics_trans_batch where ";
			mysql = mysql + " batch_no = " + txtCommonTextBox[conTxtBatchNo].Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				MessageBox.Show("Invalid Batch No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = false;
				txtCommonTextBox[conTxtBatchNo].Focus();
				return result;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mBatchCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}

			SystemVariables.gConn.BeginTransaction();

			mysql = " select locat_cd from ics_freeze_stock ";
			mysql = mysql + " where batch_cd =" + mBatchCd.ToString();
			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				mysql = mysql + " and entry_id <> " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			}
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				result = false;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				MessageBox.Show(" Batch already assigned for a Freeze Transaction, Select another Batch Code, Transaction failed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtBatchNo].Focus();
				return result;
			}

			string mCheckTimeStamp = "";
			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				txtCommonTextBox[conTxtFreezeNo].Text = SystemProcedure2.GetNewNumber("ics_freeze_stock", "freeze_no");

				mysql = " insert into ics_freeze_stock ";
				mysql = mysql + " (locat_cd, batch_cd, freeze_date, freeze_no, reference_no ";
				mysql = mysql + " , comments, status, user_cd) ";
				mysql = mysql + " values ( ";
				mysql = mysql + mLocatCd.ToString();
				mysql = mysql + " , " + mBatchCd.ToString();
				mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtFreezeDate.Value) + "'";
				mysql = mysql + " , " + txtCommonTextBox[conTxtFreezeNo].Text;
				mysql = mysql + " , '" + txtCommonTextBox[conTXTReferenceNo].Text + "'";
				mysql = mysql + " , '" + txtCommonTextBox[conTxtComments].Text + "'";
				mysql = mysql + " , 1 ";
				mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
				mysql = mysql + " ) ";

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();


				mysql = " select scope_identity() ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					MessageBox.Show("Error : Can not proceed with save!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}
			}
			else
			{
				//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);

				mysql = " select time_stamp from ics_freeze_stock where entry_id =" + mEntryId.ToString();
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

				mysql = " update ics_freeze_stock ";
				mysql = mysql + " set ";
				mysql = mysql + "   locat_cd =" + mLocatCd.ToString();
				mysql = mysql + " , batch_cd =" + mBatchCd.ToString();
				mysql = mysql + " , freeze_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtFreezeDate.Value) + "'";
				mysql = mysql + " , reference_no ='" + txtCommonTextBox[conTXTReferenceNo].Text + "'";
				mysql = mysql + " , comments ='" + txtCommonTextBox[conTxtComments].Text + "'";
				mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
				mysql = mysql + " where entry_id=" + Conversion.Str(mEntryId);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();
			}

			//''Delete from ics_freeze_stock
			mysql = " delete from ics_freeze_stock_details ";
			mysql = mysql + " where entry_id=" + mEntryId.ToString();
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mysql;
			TempCommand_3.ExecuteNonQuery();


			mysql = " select  ";
			mysql = mysql + " pld.prod_cd ";
			mysql = mysql + " , isnull((select ";
			mysql = mysql + " (sum( case itd.add_locat_cd when " + mLocatCd.ToString() + " then itd.base_qty else 0 end ) - ";
			mysql = mysql + " sum( case itd.less_locat_cd when " + mLocatCd.ToString() + " then itd.base_qty else 0 end )) ";
			mysql = mysql + " from ICS_Transaction_Details itd ";
			mysql = mysql + " inner join ICS_Transaction it on itd.entry_id = it.entry_id";
			mysql = mysql + " inner join ICS_Transaction_Types ivt on it.voucher_type = ivt.voucher_type";
			mysql = mysql + " inner join ICS_Item p on itd.prod_cd = p.prod_cd ";
			mysql = mysql + " where ivt.affect_on_hand_stock = 1 ";
			mysql = mysql + " and it.voucher_date <='" + ReflectionHelper.GetPrimitiveValue<string>(txtFreezeDate.Value) + "'";
			mysql = mysql + " and itd.prod_cd = pld.prod_cd ";
			mysql = mysql + " and dbo.icsincludethislocation( pld.locat_cd , ";
			mysql = mysql + " ivt.generate_on_multiple_location, ivt.locat_to_locat, it.locat_cd, ";
			mysql = mysql + " itd.add_locat_cd, itd.less_locat_cd) = 1 ";
			mysql = mysql + " and p.item_type_cd in (1,3) ";
			mysql = mysql + " ),0) as freeze_qty ";
			mysql = mysql + " from ICS_Item_location_details pld ";
			mysql = mysql + " where pld.locat_cd = " + mLocatCd.ToString();

			SqlDataReader rsTempRec = null;

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{
				mysql = " insert into ics_freeze_stock_details ";
				mysql = mysql + " (entry_id, prod_cd, freezed_base_qty) ";
				mysql = mysql + " values(";
				mysql = mysql + Conversion.Str(mEntryId);
				mysql = mysql + " ," + Convert.ToString(rsTempRec["prod_cd"]);
				mysql = mysql + " ," + Convert.ToString(rsTempRec["freeze_qty"]);
				mysql = mysql + ")";

				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();

			}
			while(rsTempRec.Read());


			if (pApprove)
			{
				PostStatus(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));
			}

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				MessageBox.Show(" Stock freezed with Freeze No.:" + txtCommonTextBox[conTxtFreezeNo].Text, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

			//FirstFocusObject.SetFocus
			return true;


			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			return result;
		}

		public bool CheckDataValidity()
		{

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 3);
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
			}
			else
			{

				if (!Information.IsDate(txtFreezeDate.Value))
				{
					MessageBox.Show("Enter Valid Date!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{

					if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtLocationCode].Text, SystemVariables.DataType.NumberType))
					{
						MessageBox.Show("Enter the Location Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{

						if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtBatchNo].Text, SystemVariables.DataType.NumberType))
						{
							MessageBox.Show("Enter the Batch No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{




							return true;
						}
					}
				}
			}

			return false;
		}

		public void AddRecord()
		{

			try
			{

				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode

				//''''*************************************************************************
				//Set the form caption
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Freeze Stock" : "Freeze Stock");
				//''''*************************************************************************

				SystemProcedure2.ClearTextBox(this);
				DefineVoucherArray(0, true);
				grdVoucherDetails.Rebind(true);

				txtFreezeDate.Value = DateTime.Today;
				//txtCommonTextBox(conTxtLocationCode).Enabled = True

				mSearchValue = ""; //Change the msearchvalue to blank
				mFirstGridFocus = true;
				FirstFocusObject.Focus();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}


		}


		public void GetRecord(object pSearchValue)
		{
			//On Error GoTo eFoundError
			int cnt = 0;


			string mysql = " select ifs.freeze_date, ifs.freeze_no, ifs.reference_no, ifs.comments ";
			mysql = mysql + " , ifs.Status , ifs.time_stamp ";
			mysql = mysql + " , SM_Location.locat_no, SM_Location.l_locat_name, SM_Location.a_locat_name ";
			mysql = mysql + " , itb.batch_no, itb.l_batch_name, itb.a_batch_name ";
			mysql = mysql + " from ics_freeze_stock ifs ";
			mysql = mysql + " inner join SM_Location on ifs.locat_cd = SM_Location.locat_cd ";
			mysql = mysql + " inner join ics_trans_batch itb on ifs.batch_cd = itb.batch_cd ";
			mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

			SqlDataReader localRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand.ExecuteReader();
			bool localRecDidRead = localRec.Read();
			if (localRecDidRead)
			{
				//UPGRADE_WARNING: (1068) pSearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(pSearchValue);
				mTimeStamp = Convert.ToString(localRec["time_stamp"]);

				txtCommonTextBox[conTxtFreezeNo].Text = Convert.ToString(localRec["freeze_no"]);
				txtFreezeDate.Value = localRec["freeze_date"];
				txtCommonTextBox[conTXTReferenceNo].Text = Convert.ToString(localRec["reference_no"]) + "";
				txtCommonTextBox[conTxtComments].Text = Convert.ToString(localRec["comments"]) + "";


				txtCommonTextBox[conTxtLocationCode].Text = Convert.ToString(localRec["locat_no"]);
				txtCommonTextBox[conTxtBatchNo].Text = Convert.ToString(localRec["batch_no"]);

				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					txtDisplayLabel[conDlblLocationName].Text = Convert.ToString(localRec["l_locat_name"]);
					txtDisplayLabel[conDlblBatchName].Text = Convert.ToString(localRec["l_batch_name"]);
				}
				else
				{
					txtDisplayLabel[conDlblLocationName].Text = Convert.ToString(localRec["a_locat_name"]);
					txtDisplayLabel[conDlblBatchName].Text = Convert.ToString(localRec["a_batch_name"]);
				}

				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;

				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, frmICSFreezeStock.DefInstance, Convert.ToInt32(localRec["status"]), CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Freeze Stock" : "Freeze Stock");

			}
			localRec.Close();

			DefineVoucherArray(0, true);

			mysql = " select ICS_Item.part_no ";
			mysql = mysql + "," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " ICS_Item.l_prod_name " : "ICS_Item.a_prod_name ");
			mysql = mysql + " as prod_name , ifsd.freezed_base_qty ";
			mysql = mysql + " from ics_freeze_stock_details ifsd ";
			mysql = mysql + " inner join ICS_Item on ifsd.prod_cd = ICS_Item.prod_cd ";
			mysql = mysql + " where ifsd.entry_id = " + Conversion.Str(pSearchValue);

			SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand_2.ExecuteReader();
			bool localRecDidRead2 = localRec.Read();
			if (localRecDidRead)
			{
				do 
				{
					DefineVoucherArray(cnt, false);
					aVoucherDetails.SetValue(Conversion.Str(cnt + 1).Trim(), cnt, gccLineNoColumn);
					aVoucherDetails.SetValue(localRec["part_no"], cnt, gccPartNoColumn);
					aVoucherDetails.SetValue(localRec["prod_name"], cnt, gccProdNameColumn);
					aVoucherDetails.SetValue(localRec["freezed_base_qty"], cnt, gccFreezeQtyColumn);

					cnt++;
				}
				while(localRec.Read());
			}

			grdVoucherDetails.Rebind(true);

			FirstFocusObject.Focus();


			localRec.Close();
			return;


			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void PrintReport()
		{

		}

		public void CloseForm()
		{
			this.Close();
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001020));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			if (Index == conTxtFreezeNo)
			{
				GetNextNumber();
			}
			else
			{
				FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
			}
		}

		private void GetNextNumber()
		{
			txtCommonTextBox[conTxtFreezeNo].Text = SystemProcedure2.GetNewNumber("ics_freeze_stock", "freeze_no");
			FirstFocusObject.Focus();
		}

		public void FindRoutine(string pObjectName)
		{
			//Dim mySql As String
			object mTempSearchValue = null;

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

			switch(mIndex)
			{
				case conTxtLocationCode : 
					txtCommonTextBox[conTxtLocationCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2004000, "82")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtLocationCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtBatchNo : 
					txtCommonTextBox[conTxtBatchNo].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001010, "1437")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtBatchNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					 
					break;
				default:
					return;
			}
		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;
				int mSetValueIndex = 0;

				if (SystemVariables.gSkipTextBoxLostFocus)
				{
					return;
				}


				switch(Index)
				{
					case conTxtLocationCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name"); 
						mysql = mysql + ",'' from SM_Location where locat_no = " + this.txtCommonTextBox[Index].Text; 
						 
						mSetValueIndex = conDlblLocationName; 
						break;
					case conTxtBatchNo : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_batch_name" : "a_batch_name"); 
						mysql = mysql + ",'' from ics_trans_batch where batch_no = " + this.txtCommonTextBox[Index].Text; 
						 
						mSetValueIndex = conDlblBatchName; 
						break;
					default:
						mSetValueIndex = 0; 
						break;
				}


				if (mSetValueIndex > 0)
				{
					if (!SystemProcedure2.IsItEmpty(this.txtCommonTextBox[Index].Text, SystemVariables.DataType.StringType))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							this.txtDisplayLabel[mSetValueIndex].Text = "";

							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							this.txtDisplayLabel[mSetValueIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));

							if (mSetValueIndex == conTxtLocationCode)
							{
								//txtCommonTextBox(conTxtLocationCode).Enabled = False
							}
						}
					}
					else
					{
						this.txtDisplayLabel[mSetValueIndex].Text = "";
					}
				}


				//If Index = conTxtLocationCode Then
				//    If Not IsItEmpty(txtCommonTextBox(conTxtLocationCode).Text, NumberType) Then
				//        mysql = "select " & IIf(gPreferedLanguage = english, "l_locat_name", "a_locat_name")
				//        mysql = mysql & " from SM_Location "
				//        mysql = mysql & " where "
				//        mysql = mysql & " and locat_no = " & txtCommonTextBox(conTxtLocationCode).Text
				//    Else
				//        txtDisplayLabel(conDlblLocationName).Text = ""
				//    End If
				//End If
				//
				//mTempValue = GetMasterCode(mysql)
				//If IsNull(mTempValue) Then
				//    txtDisplayLabel(conDlblLocationName).Text = ""
				//
				//    Err.Raise -9990002
				//Else
				//    txtDisplayLabel(conDlblLocationName).Text = mTempValue(0)
				//    txtCommonTextBox(conTxtLocationCode).Enabled = False
				//End If
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
					txtCommonTextBox[Index].Focus();
				}
				else
				{
					//
				}
			}

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

			string mysql = "delete from ics_freeze_stock_details where entry_id=" + Conversion.Str(mSearchValue);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = "delete from ics_freeze_stock where entry_id=" + Conversion.Str(mSearchValue);
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();


			return true;

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

			//if the user clicks on OK button in the frmPost form
			//If frmTemp.mLastButtonClicked = 1 And frmTemp.mApprove = True Then
			if (frmTemp.mApprove)
			{

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					//Display this message if status is active, which will require to save the record first
					ans = MessageBox.Show(SystemConstants.msg19 + "\r" + "\r" + SystemConstants.msg7, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				}
				else
				{
					//Display this message if status is not active, which will not require to save the record first
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
							PostStatus(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));

							//                Call PayPostToHR("ics_freeze_stock", CLng(SearchValue))
							//                Call PayApprove("ics_freeze_stock", CLng(SearchValue), "ics_freeze_stock_details")
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
			//This goto will only come if the voucherstatus is still active
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

		private void PostStatus(int pEntryId)
		{

			string mysql = " update ics_freeze_stock ";
			mysql = mysql + " set  status = 2 ";
			mysql = mysql + " where entry_id =" + pEntryId.ToString();
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

		}
	}
}