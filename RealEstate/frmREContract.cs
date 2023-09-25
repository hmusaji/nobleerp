
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmREContract
		: System.Windows.Forms.Form
	{

		
		public frmREContract()
{
InitializeComponent();
} 
 public  void frmREContract_old()
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

		private clsToolbar oThisFormToolBar = null;
		public Control FirstFocusObject = null;
		private int mThisFormID = 0;
		private string mTimeStamp = "";
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;
		private System.DateTime mLastPeriodEnds = DateTime.FromOADate(0);

		private DataSet rsItemList = null;
		private DataSet rsUnitList = null;

		private bool mFirstGridFocus = false;
		private XArrayHelper _aContractDetails = null;
		private XArrayHelper aContractDetails
		{
			get
			{
				if (_aContractDetails is null)
				{
					_aContractDetails = new XArrayHelper();
				}
				return _aContractDetails;
			}
			set
			{
				_aContractDetails = value;
			}
		}


		private const int conLineNoColumn = 0;
		private const int conItemNoColumn = 1;
		private const int conItemNameColumn = 2;
		private const int conUnitNoColumn = 3;
		private const int conUnitAmountColumn = 4;
		private const int conItemCodeColumn = 5;
		private const int conUnitCodeColumn = 6;
		private const int conRemarksColumn = 7;

		private const int mMaxArray = 7;

		private const int conLBLStatusNo = 3;
		private const int conLBLSecurityDepositAmount = 11;

		private const int conTXTContractNo = 0;
		private const int conTXTTenantNo = 1;
		private const int conTXTStatusNo = 2;
		private const int conTXTPaymentMethodNo = 3;
		private const int conTxtPropertyNo = 5;

		private const int conTXTReferenceNo = 4;
		private const int conTXTOtherAmount = 5;
		private const int conTXTTotalAmount = 6;
		private const int conTXTContractAmount = 0;
		private const int conTXTStartingDate = 0;
		private const int conTXTEndingDate = 1;
		private const int conTXTSignedDate = 2;
		private const int conTXTTenantName = 0;
		private const int conTXTStatusName = 1;
		private const int conTXTPaymentMethodName = 2;
		private const int conTXTPropertyName = 3;
		private const int conTXTOpeningBalance = 0;
		private const int conTXTSecurityDepositAmount = 1;


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


		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{

					SystemProcedure2.CheckPostedStatus(1, "GLStatus", mOldVoucherStatus != SystemVariables.VoucherStatus.stActive, CurrentFormMode, 3);
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
		}

		//UPGRADE_WARNING: (2065) Form event Form.Deactivate has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
		private void Form_Deactivate(Object eventSender, EventArgs eventArgs)
		{
			SystemProcedure2.CheckPostedStatus(0, "GLStatus");
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			C1.Win.C1TrueDBGrid.C1DisplayColumn colContractDetails = null;

			try
			{

				FirstFocusObject = txtCommon[conTXTTenantNo];
				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
				this.Top = 0;
				this.Left = 0;
				mFirstGridFocus = true;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowPostButton = true;
				//.ShowPostAllButton = True
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginInsertLineButtonWithGroup = true;
				oThisFormToolBar.BeginPostButtonWithGroup = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;


				SystemGrid.DefineSystemVoucherGrid(grdContractDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, "&HABCED3", "&HABCED3");
				//**--define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdContractDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdContractDetails, "Item Code", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon", true);
				SystemGrid.DefineSystemVoucherGridColumn(grdContractDetails, "Item Name", 2500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "Total Contract Amount", C1.Win.C1TrueDBGrid.AlignHorzEnum.Center);
				SystemGrid.DefineSystemVoucherGridColumn(grdContractDetails, "Unit Code", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon", true);
				SystemGrid.DefineSystemVoucherGridColumn(grdContractDetails, "Unit Amount", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdContractDetails, "Item Code", 500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdContractDetails, "Unit Code", 500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdContractDetails, "Remarks");

				//**--setting up default values
				ShowHideMasterDetails();

				SystemProcedure.SetLabelCaption(this);

				//**--make the form visible before all the control gets loaded
				//**--(this way system pretends to be faster in loading forms)
				this.Show();
				Application.DoEvents();

				//**--set the last closed month
				//UPGRADE_WARNING: (1068) GetRELastMonthEndDate() of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mLastPeriodEnds = ReflectionHelper.GetPrimitiveValue<System.DateTime>(SystemREProcedure.GetRELastMonthEndDate());

				//**--setting voucher details grid properties
				rsItemList = new DataSet();
				rsUnitList = new DataSet();

				aContractDetails.RedimXArray(new int[]{0, mMaxArray}, new int[]{0, 0});
				aContractDetails.SetValue(1, 0, conLineNoColumn);
				SystemGrid.DefineSystemGridCombo(cmbCommon);
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdContractDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdContractDetails.setArray(aContractDetails);
				cmbCommon.Height = 120;
				grdContractDetails.Rebind(true);
				//**--end of voucher grid property setting

				Application.DoEvents();
				CalculateContractAmount();
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
				{
					SendKeys.Send("{TAB}");
					return;
				}
				else if (KeyCode == 116)
				{ 
					RefreshFormObjects();
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

		private void DefineMasterRecordset()
		{

			string mySQL = "select item_no, ";
			mySQL = mySQL + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_item_name" : "a_item_name") + " as item_name ";
			mySQL = mySQL + ", item_cd from re_property_items ";
			mySQL = mySQL + " where show = 1 ";

			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsItemList.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			if (rsItemList.getState() == ConnectionState.Open)
			{
			}
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsItemList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsItemList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mySQL, SystemVariables.gConn);
			rsItemList.Tables.Clear();
			adap.Fill(rsItemList);

			mySQL = "select unit_no, ";
			mySQL = mySQL + " iud.unit_amt, iud.unit_cd, iud.item_cd ,";
			mySQL = mySQL + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "p.l_property_name" : "p.a_property_name") + " as property_name";
			mySQL = mySQL + " , iud.property_cd ";
			mySQL = mySQL + " from re_property_item_unit_details iud ";
			mySQL = mySQL + " inner join re_property p on iud.property_cd = p.property_cd ";
			mySQL = mySQL + " inner join re_property_status ps on iud.property_status_cd = ps.property_status_cd ";
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				mySQL = mySQL + " where (ps.is_available = 1 ";
				mySQL = mySQL + " or iud.contract_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ")";
			}
			else
			{
				mySQL = mySQL + " where ps.is_available = 1 ";
			}

			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsUnitList.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			if (rsUnitList.getState() == ConnectionState.Open)
			{
			}
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsUnitList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsUnitList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap_2 = new SqlDataAdapter(mySQL, SystemVariables.gConn);
			rsUnitList.Tables.Clear();
			adap_2.Fill(rsUnitList);
		}

		private void grdContractDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			if (ColIndex == conUnitAmountColumn || ColIndex == conUnitNoColumn)
			{
				CalculateContractAmount();
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdContractDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdContractDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				if (ColIndex == conUnitAmountColumn)
				{
					Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,##0.000");
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdContractDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			if (mFirstGridFocus)
			{
				DefineMasterRecordset();
				mFirstGridFocus = false;

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdContractDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdContractDetails.PostMsg(1);
			}
			else
			{
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdContractDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdContractDetails_OnAddNew()
		{
			grdContractDetails.Columns[conLineNoColumn].Text = (grdContractDetails.RowCount + 1).ToString();
		}

		public bool saveRecord()
		{
			bool result = false;
			string mySQL = "";
			int cnt = 0;
			int mGeneratedEntryID = 0;
			object mTempValue = null;
			bool mChangeItemUnitStatus = false;

			try
			{

				//**--update grid array with current grid values
				grdContractDetails.UpdateData();

				SystemVariables.gConn.BeginTransaction();
				//**--inserting details in contract master table
				DataSet rsCheckTimeStamp = null;
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					txtCommon[conTXTContractNo].Text = SystemProcedure2.GetNewNumber("re_contract", "contract_no", 4);

					mySQL = " insert into re_contract ";
					mySQL = mySQL + " (contract_no, property_cd, tenant_cd, contract_status_cd, payment_method_cd";
					mySQL = mySQL + ", starting_date, ending_date, signed_date, contract_amt, opening_balance";
					mySQL = mySQL + ", reference_no, comments, user_cd, security_deposit_amt) ";
					mySQL = mySQL + " values( ";
					mySQL = mySQL + txtCommon[conTXTContractNo].Text;
					mySQL = mySQL + ", " + Convert.ToString(txtCommon[conTxtPropertyNo].Tag);
					mySQL = mySQL + ", " + Convert.ToString(txtCommon[conTXTTenantNo].Tag);
					//**--insert the default status code to 1 = active
					mySQL = mySQL + ", 1";
					mySQL = mySQL + ", " + Convert.ToString(txtCommon[conTXTPaymentMethodNo].Tag);
					mySQL = mySQL + ", '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conTXTStartingDate].DisplayText) + "'";
					mySQL = mySQL + ", '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conTXTEndingDate].DisplayText) + "'";
					mySQL = mySQL + ", '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conTXTSignedDate].DisplayText) + "'";
					mySQL = mySQL + ", " + StringsHelper.Format(grdContractDetails.Columns[conUnitAmountColumn].FooterText, "###############.####");
					mySQL = mySQL + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conTXTOpeningBalance].Value);
					mySQL = mySQL + ", N'" + txtCommon[conTXTReferenceNo].Text + "'";
					mySQL = mySQL + ", N'" + txtRemarks.Text + "'";
					mySQL = mySQL + ", " + SystemVariables.gLoggedInUserCode.ToString();
					mySQL = mySQL + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conTXTSecurityDepositAmount].Value);
					mySQL = mySQL + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mySQL;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mGeneratedEntryID = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
				}
				else if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{ 
					//*--updating main transaction table
					//*-- check whether the row is in the same status when it was retreived from the table for updation

					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = "select time_stamp from re_contract where contract_cd = " + Conversion.Str(mSearchValue);
					SqlDataAdapter TempAdapter_2 = null;
					TempAdapter_2 = new SqlDataAdapter();
					TempAdapter_2.SelectCommand = TempCommand_2;
					DataSet TempDataset_2 = null;
					TempDataset_2 = new DataSet();
					TempAdapter_2.Fill(TempDataset_2);
					rsCheckTimeStamp = TempDataset_2;
					if (rsCheckTimeStamp.Tables[0].Rows.Count != 0)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mCheckTimeStamp = Convert.ToString(rsCheckTimeStamp.Tables[0].Rows[0][0]);
					}
					if ((rsCheckTimeStamp.Tables[0].Rows.Count == 0) || (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp)))
					{
						rsCheckTimeStamp = null;
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						FirstFocusObject.Focus();
						return result;
					}
					rsCheckTimeStamp = null;
					//**-------------------------------------------------------------------------------

					mySQL = "update re_contract ";
					mySQL = mySQL + " set property_cd = " + Convert.ToString(txtCommon[conTxtPropertyNo].Tag);
					mySQL = mySQL + " , tenant_cd = " + Convert.ToString(txtCommon[conTXTTenantNo].Tag);
					mySQL = mySQL + " , payment_method_cd = " + Convert.ToString(txtCommon[conTXTPaymentMethodNo].Tag);
					mySQL = mySQL + " , starting_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conTXTStartingDate].DisplayText) + "'";
					mySQL = mySQL + " , ending_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conTXTEndingDate].DisplayText) + "'";
					mySQL = mySQL + " , signed_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conTXTSignedDate].DisplayText) + "'";
					mySQL = mySQL + " , contract_amt = " + StringsHelper.Format(grdContractDetails.Columns[conUnitAmountColumn].FooterText, "###############.####");
					mySQL = mySQL + " , opening_balance = " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conTXTOpeningBalance].Value);
					mySQL = mySQL + " , reference_no = N'" + txtCommon[conTXTReferenceNo].Text + "'";
					mySQL = mySQL + " , comments = N'" + txtRemarks.Text + "'";
					mySQL = mySQL + " , security_deposit_amt = " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conTXTSecurityDepositAmount].Value);
					mySQL = mySQL + " where contract_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mySQL;
					TempCommand_3.ExecuteNonQuery();

					//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mGeneratedEntryID = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);
				}
				//**-------------------------------------------------------------------------------------------

				//**--inserting details in contract details table
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					mySQL = "delete from re_contract_details ";
					mySQL = mySQL + " where contract_cd = " + mGeneratedEntryID.ToString();
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mySQL;
					TempCommand_4.ExecuteNonQuery();

					if (!SystemREProcedure.ReleaseContractItemUnits(mGeneratedEntryID))
					{
						throw new Exception();
					}
				}

				//**--check whether to change item unit
				//**--availability status or not
				mySQL = "select count(*) ";
				mySQL = mySQL + " from re_contract";
				mySQL = mySQL + " where contract_cd = " + Conversion.Str(mGeneratedEntryID);
				mySQL = mySQL + " and starting_date <= '" + StringsHelper.Format(SystemProcedure2.GetNextMonth(mLastPeriodEnds), SystemVariables.gSystemDateFormat) + "'";
				mySQL = mySQL + " and ending_date > '" + StringsHelper.Format(mLastPeriodEnds, SystemVariables.gSystemDateFormat) + "'";
				mChangeItemUnitStatus = ((ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode(mySQL)) == 0) ? TriState.False : TriState.True) != TriState.False;

				int tempForEndVar = aContractDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					//**--check if the contract ending date is greater then last closed month
					//**--then check for current item unit availability and update its availability
					if (mChangeItemUnitStatus)
					{
						mySQL = "select count(*) from re_property_item_unit_details iud ";
						mySQL = mySQL + " inner join re_property_status ps ";
						mySQL = mySQL + " on iud.property_status_cd = ps.property_status_cd ";
						mySQL = mySQL + " where unit_cd = " + Convert.ToString(aContractDetails.GetValue(cnt, conUnitCodeColumn));
						mySQL = mySQL + " and is_available = 1 ";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
						if (ReflectionHelper.GetPrimitiveValue<double>(mTempValue) == 0)
						{
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							MessageBox.Show("Error: Item Unit Unavailable", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return false;
						}

						mySQL = " update re_property_item_unit_details ";
						mySQL = mySQL + " set property_status_cd = 2 ";
						mySQL = mySQL + ", contract_cd = " + mGeneratedEntryID.ToString();
						mySQL = mySQL + " where unit_cd = " + Convert.ToString(aContractDetails.GetValue(cnt, conUnitCodeColumn));
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mySQL;
						TempCommand_5.ExecuteNonQuery();
					}

					mySQL = "insert into re_contract_details ";
					mySQL = mySQL + " (contract_cd, item_cd, unit_cd, amount, remarks) ";
					mySQL = mySQL + " values (";
					mySQL = mySQL + mGeneratedEntryID.ToString();
					mySQL = mySQL + "," + Convert.ToString(aContractDetails.GetValue(cnt, conItemCodeColumn));
					mySQL = mySQL + "," + Convert.ToString(aContractDetails.GetValue(cnt, conUnitCodeColumn));
					mySQL = mySQL + "," + Convert.ToString(aContractDetails.GetValue(cnt, conUnitAmountColumn));
					mySQL = mySQL + ", N'" + Convert.ToString(aContractDetails.GetValue(cnt, conRemarksColumn)) + "'";
					mySQL = mySQL + ")";
					SqlCommand TempCommand_6 = null;
					TempCommand_6 = SystemVariables.gConn.CreateCommand();
					TempCommand_6.CommandText = mySQL;
					TempCommand_6.ExecuteNonQuery();
				}
				//**-------------------------------------------------------------------------------------------
				//**--check if all the items in the contract belongs to the same property or not
				mySQL = " select count(*) from ";
				mySQL = mySQL + "(select distinct piud.property_cd ";
				mySQL = mySQL + " from re_contract_details cd ";
				mySQL = mySQL + " inner join re_property_item_unit_details piud ";
				mySQL = mySQL + " on piud.item_cd = cd.item_cd and piud.unit_cd = cd.unit_cd ";
				mySQL = mySQL + " where cd.contract_cd = " + Conversion.Str(mGeneratedEntryID);
				mySQL = mySQL + ") as rs ";
				if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode(mySQL)) > 1)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show("Error: All Contract Item Units shall belong to one Property only", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					grdContractDetails.Focus();
					return false;
				}
				//**-------------------------------------------------------------------------------------------
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					MessageBox.Show("Contract has been saved with no : " + txtCommon[conTXTContractNo].Text, "Press Enter To Continue...", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (System.Exception excep)
			{


				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				result = false;
			}
			return result;
		}

		public void AddRecord()
		{
			//**--add a record
			try
			{

				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mFirstGridFocus = true;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
				SystemProcedure2.ClearTextBox(this);
				SystemProcedure2.ClearNumberBox(this);

				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aContractDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aContractDetails.Clear();
				aContractDetails.RedimXArray(new int[]{0, mMaxArray}, new int[]{0, 0});
				aContractDetails.SetValue(1, 0, conLineNoColumn);
				grdContractDetails.Rebind(true);

				RefreshFormObjects();
				ShowHideMasterDetails();
				SystemProcedure2.CheckPostedStatus(1, "GLStatus", mOldVoucherStatus != SystemVariables.VoucherStatus.stActive, CurrentFormMode, 3);
				FirstFocusObject.Focus();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}
		}

		public bool deleteRecord()
		{
			bool result = false;
			string mySQL = "";

			try
			{

				if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
				{
					MessageBox.Show("Error: Contract already posted. Can not delete / modify the posted transaction!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					FirstFocusObject.Focus();
					return false;
				}

				SystemVariables.gConn.BeginTransaction();
				mySQL = "delete from re_contract_details ";
				mySQL = mySQL + " from re_contract_details cd ";
				mySQL = mySQL + " inner join re_contract c on c.contract_cd = cd.contract_cd ";
				mySQL = mySQL + " where cd.contract_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mySQL = mySQL + " and c.status = 1 ";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mySQL;
				TempCommand.ExecuteNonQuery();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					throw new Exception();
				}

				if (!SystemREProcedure.ReleaseContractItemUnits(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(mSearchValue)))))
				{
					throw new Exception();
				}

				mySQL = "delete from re_contract ";
				mySQL = mySQL + " where contract_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mySQL = mySQL + " and status = 1 ";
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mySQL;
				TempCommand_2.ExecuteNonQuery();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					throw new Exception();
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				return true;
			}
			catch
			{

				MessageBox.Show("Contract cannot be deleted!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}
			return result;
		}

		public void GetRecord(object pSearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting
			string mySQL = "";
			SqlDataReader rsLocalRec = null;

			try
			{

				if (SystemProcedure2.IsItEmpty(pSearchValue, SystemVariables.DataType.StringType))
				{
					return;
				}
				//**--change the form mode to edit
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				mFirstGridFocus = true;
				ShowHideMasterDetails();

				mySQL = "select c.contract_no, c.time_stamp ";
				mySQL = mySQL + ", t.tenant_cd, t.tenant_no, t.l_tenant_name, t.a_tenant_name ";
				mySQL = mySQL + ", cs.contract_status_cd, cs.status_no, cs.l_status_name, cs.a_status_name";
				mySQL = mySQL + ", p.property_cd, p.property_no, p.l_property_name, p.a_property_name ";
				mySQL = mySQL + ", pm.payment_method_cd, pm.payment_method_no, pm.l_payment_method_name ";
				mySQL = mySQL + ", pm.a_payment_method_name, c.status ";
				mySQL = mySQL + ", c.starting_date, c.ending_date, c.signed_date";
				mySQL = mySQL + ", c.contract_amt, c.other_amt, c.total_amt, c.opening_balance ";
				mySQL = mySQL + ", c.comments, c.reference_no, c.security_deposit_amt";

				mySQL = mySQL + " from re_contract c ";
				mySQL = mySQL + " inner join re_tenant t on c.tenant_cd = t.tenant_cd";
				mySQL = mySQL + " inner join re_contract_status cs on c.contract_status_cd = cs.contract_status_cd";
				mySQL = mySQL + " inner join re_payment_method pm on c.payment_method_cd = pm.payment_method_cd";
				mySQL = mySQL + " inner join re_property p on c.property_cd = p.property_cd";
				mySQL = mySQL + " where contract_cd = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

				SqlCommand sqlCommand = new SqlCommand(mySQL, SystemVariables.gConn);
				rsLocalRec = sqlCommand.ExecuteReader();
				if (rsLocalRec.Read())
				{
					mTimeStamp = Convert.ToString(rsLocalRec["time_stamp"]);
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mOldVoucherStatus = (SystemVariables.VoucherStatus) Convert.ToInt32(rsLocalRec["status"]);
					txtCommon[conTXTContractNo].Text = Convert.ToString(rsLocalRec["contract_no"]);
					txtCommon[conTXTTenantNo].Text = Convert.ToString(rsLocalRec["tenant_no"]);
					txtCommon[conTXTTenantNo].Tag = Convert.ToString(rsLocalRec["tenant_cd"]);
					txtCommon[conTXTStatusNo].Text = Convert.ToString(rsLocalRec["status_no"]);
					txtCommon[conTXTPaymentMethodNo].Text = Convert.ToString(rsLocalRec["payment_method_no"]);
					txtCommon[conTXTPaymentMethodNo].Tag = Convert.ToString(rsLocalRec["payment_method_cd"]);
					txtCommon[conTxtPropertyNo].Text = Convert.ToString(rsLocalRec["property_no"]);
					txtCommon[conTxtPropertyNo].Tag = Convert.ToString(rsLocalRec["property_cd"]);
					txtCommon[conTXTReferenceNo].Text = Convert.ToString(rsLocalRec["reference_no"]) + "";
					txtCommonDate[conTXTStartingDate].Value = rsLocalRec["starting_date"];
					txtCommonDate[conTXTEndingDate].Value = rsLocalRec["ending_date"];
					txtCommonDate[conTXTSignedDate].Value = rsLocalRec["signed_date"];
					txtCommonNumber[conTXTOpeningBalance].Value = rsLocalRec["opening_balance"];
					txtRemarks.Text = Convert.ToString(rsLocalRec["comments"]) + "";
					txtCommonNumber[conTXTSecurityDepositAmount].Value = rsLocalRec["security_deposit_amt"];
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						txtCommonDisplay[conTXTTenantName].Text = Convert.ToString(rsLocalRec["l_tenant_name"]) + "";
						txtCommonDisplay[conTXTStatusName].Text = Convert.ToString(rsLocalRec["l_status_name"]) + "";
						txtCommonDisplay[conTXTPaymentMethodName].Text = Convert.ToString(rsLocalRec["l_payment_method_name"]) + "";
						txtCommonDisplay[conTXTPropertyName].Text = Convert.ToString(rsLocalRec["l_property_name"]) + "";
					}
					else
					{
						txtCommonDisplay[conTXTTenantName].Text = Convert.ToString(rsLocalRec["a_tenant_name"]) + "";
						txtCommonDisplay[conTXTStatusName].Text = Convert.ToString(rsLocalRec["a_status_name"]) + "";
						txtCommonDisplay[conTXTPaymentMethodName].Text = Convert.ToString(rsLocalRec["a_payment_method_name"]) + "";
						txtCommonDisplay[conTXTPropertyName].Text = Convert.ToString(rsLocalRec["a_property_name"]) + "";
					}

					SystemProcedure2.CheckPostedStatus(1, "GLStatus", mOldVoucherStatus != SystemVariables.VoucherStatus.stActive, CurrentFormMode, 3);
				}
				rsLocalRec.Close();

				InsertContractDetails(pSearchValue);
				CalculateContractAmount();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9015000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				Application.DoEvents();
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
			int cnt = 0;
			string mySQL = "";
			object mReturnValue = null;

			try
			{

				txtCommon_Leave(txtCommon[conTXTTenantNo], new EventArgs());
				txtCommon_Leave(txtCommon[conTXTPaymentMethodNo], new EventArgs());
				txtCommon_Leave(txtCommon[conTxtPropertyNo], new EventArgs());
				CalculateContractAmount();

				if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
				{
					MessageBox.Show("Error: Contract already posted. Can not modify the posted transaction!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					FirstFocusObject.Focus();
					return false;
				}

				if (SystemProcedure2.IsItEmpty(txtCommon[conTXTTenantNo].Text, SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Enter Tenant Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommon[conTXTTenantNo].Focus();
					return false;
				}

				if (SystemProcedure2.IsItEmpty(txtCommon[conTXTPaymentMethodNo].Text, SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Enter Payment Method Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommon[conTXTPaymentMethodNo].Focus();
					return false;
				}

				if (SystemProcedure2.IsItEmpty(txtCommon[conTxtPropertyNo].Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Property Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommon[conTxtPropertyNo].Focus();
					return false;
				}

				if (SystemProcedure2.IsItEmpty(txtCommonDate[conTXTStartingDate].Text, SystemVariables.DataType.DateType))
				{
					MessageBox.Show("Enter Starting Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonDate[conTXTStartingDate].Focus();
					return false;
				}
				if (SystemProcedure2.IsItEmpty(txtCommonDate[conTXTEndingDate].Text, SystemVariables.DataType.DateType))
				{
					MessageBox.Show("Enter Ending Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonDate[conTXTEndingDate].Focus();
					return false;
				}
				if (SystemProcedure2.IsItEmpty(txtCommonDate[conTXTSignedDate].Text, SystemVariables.DataType.DateType))
				{
					MessageBox.Show("Enter Signed Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonDate[conTXTSignedDate].Focus();
					return false;
				}

				//**--check if contract starting date is less the ending date
				if (!(DateTime.Parse(txtCommonDate[conTXTEndingDate].Text) >= DateTime.Parse(txtCommonDate[conTXTStartingDate].Text)))
				{
					MessageBox.Show("Error: Invalid Date Range. Contract Ending Date can not be less then Contract Starting Date!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtCommonDate[conTXTStartingDate].Focus();
					return false;
				}


				//''commented by hakim on 19-feb-2005
				//'**--check if contract starting date is less then or equal to current period
				//If Not (CDate(txtCommonDate(conTXTStartingDate).Text) <= mLastPeriodEnds) Then
				//    MsgBox "Error: Invalid Date Range. Contract Date can not exceed current period date!", vbCritical
				//    txtCommonDate(conTXTStartingDate).SetFocus
				//    CheckDataValidity = False
				//    Exit Function
				//End If


				//**--check the contract details entries
				if (aContractDetails.GetLength(0) == 0)
				{
					MessageBox.Show("Error: Enter Contract Details", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					grdContractDetails.Focus();
					return false;
				}

				int tempForEndVar = aContractDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					if (!SystemProcedure2.IsItEmpty(aContractDetails.GetValue(cnt, conItemNoColumn), SystemVariables.DataType.NumberType))
					{
						mySQL = " select item_cd ";
						mySQL = mySQL + " from re_property_items ";
						mySQL = mySQL + " where item_no = " + Convert.ToString(aContractDetails.GetValue(cnt, conItemNoColumn));
						mySQL = mySQL + " and show = 1 ";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue))
						{
							MessageBox.Show("Error: Invalid Item Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							grdContractDetails.Row = cnt;
							grdContractDetails.Focus();
							return false;
						}
						else
						{
							aContractDetails.SetValue(mReturnValue, cnt, conItemCodeColumn);
						}
					}
					else
					{
						MessageBox.Show("Error: Enter Item Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdContractDetails.Row = cnt;
						grdContractDetails.Focus();
						return false;
					}

					if (!SystemProcedure2.IsItEmpty(aContractDetails.GetValue(cnt, conUnitNoColumn), SystemVariables.DataType.StringType))
					{
						mySQL = " select unit_cd ";
						mySQL = mySQL + " from re_property_item_unit_details ";
						mySQL = mySQL + " where unit_no = '" + Convert.ToString(aContractDetails.GetValue(cnt, conUnitNoColumn)).Trim() + "'";
						mySQL = mySQL + " and item_cd = " + Convert.ToString(aContractDetails.GetValue(cnt, conItemCodeColumn)).Trim();
						mySQL = mySQL + " and property_cd = " + Convert.ToString(txtCommon[conTxtPropertyNo].Tag).Trim();

						//        If mCurrentFormMode = frmAddMode Then
						//            mySql = mySql & " and property_status_cd = 1 "
						//        Else
						//            mySql = mySql & " and contract_cd = " & mSearchValue
						//        End If
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue))
						{
							MessageBox.Show("Error: Invalid Item Unit Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							grdContractDetails.Row = cnt;
							grdContractDetails.Focus();
							return false;
						}
						else
						{
							aContractDetails.SetValue(mReturnValue, cnt, conUnitCodeColumn);
						}
					}
					else
					{
						MessageBox.Show("Error: Enter Item Unit Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdContractDetails.Row = cnt;
						grdContractDetails.Focus();
						return false;
					}

					if (SystemProcedure2.IsItEmpty(aContractDetails.GetValue(cnt, conUnitAmountColumn), SystemVariables.DataType.NumberType))
					{
						MessageBox.Show("Error: Enter Unit Amount", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdContractDetails.Row = cnt;
						grdContractDetails.Focus();
						return false;
					}
				}
				return true;
			}
			catch
			{

				result = false;
			}
			return result;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				SystemProcedure2.CheckPostedStatus(0, "GLStatus");

				rsItemList = null;
				rsUnitList = null;
				aContractDetails = null;
				UserAccess = null;
				oThisFormToolBar = null;
				frmREContract.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

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
					case conTXTTenantNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9010000, "1365")); 
						break;
					case conTXTStatusNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9013000, "1383")); 
						break;
					case conTXTPaymentMethodNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9014000, "1387")); 
						break;
					case conTxtPropertyNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9001000, "1323")); 
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

		private void grdContractDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			grdContractDetails.UpdateData();
			//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsUnitList.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();

			switch(grdContractDetails.Col)
			{
				case conItemNoColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbCommon.setDataSource((msdatasrc.DataSource) rsItemList); 
					break;
				case conUnitNoColumn : 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(grdContractDetails.Bookmark))
					{
						if (!SystemProcedure2.IsItEmpty(aContractDetails.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdContractDetails.Bookmark))), conItemCodeColumn), SystemVariables.DataType.StringType))
						{
							if (SystemProcedure2.IsItEmpty(Convert.ToString(txtCommon[conTxtPropertyNo].Tag), SystemVariables.DataType.NumberType))
							{
								rsUnitList.Tables[0].DefaultView.RowFilter = " property_cd = 0 and item_cd = " + Convert.ToString(aContractDetails.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdContractDetails.Bookmark))), conItemCodeColumn));
							}
							else
							{
								rsUnitList.Tables[0].DefaultView.RowFilter = " property_cd = " + Convert.ToString(txtCommon[conTxtPropertyNo].Tag) + " and item_cd = " + Convert.ToString(aContractDetails.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdContractDetails.Bookmark))), conItemCodeColumn));
							}
						}
					} 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbCommon.setDataSource((msdatasrc.DataSource) rsUnitList); 
					break;
				default:
					return;
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
				switch(Index)
				{
					case conTXTTenantNo : 
						mySQL = "select l_tenant_name, a_tenant_name, tenant_cd from re_tenant where tenant_no = " + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conTXTTenantName; 
						break;
					case conTXTStatusNo : 
						mySQL = "select l_status_name, a_status_name, contract_status_cd from re_contract_status where status_no = " + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conTXTStatusName; 
						break;
					case conTXTPaymentMethodNo : 
						mySQL = "select l_payment_method_name, a_payment_method_name, payment_method_cd from re_payment_method where payment_method_no = " + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conTXTPaymentMethodName; 
						break;
					case conTxtPropertyNo : 
						mySQL = "select l_property_name, a_property_name, property_cd from re_property where property_no ='" + txtCommon[Index].Text + "'"; 
						mLinkedTextBoxIndex = conTXTPropertyName; 
						break;
					default:
						return;
				}

				if (!SystemProcedure2.IsItEmpty(txtCommon[Index].Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtCommonDisplay[mLinkedTextBoxIndex].Text = "";
						txtCommon[Index].Tag = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						txtCommonDisplay[mLinkedTextBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1));
						txtCommon[Index].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
					}
				}
				else
				{
					txtCommonDisplay[mLinkedTextBoxIndex].Text = "";
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdContractDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdContractDetails_PostEvent(int MsgId)
		{
			int Col = 0;

			if (MsgId == 1)
			{
				grdContractDetails.Col = conItemNoColumn;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbCommon.setDataSource((msdatasrc.DataSource) rsItemList);
			}
			else if (MsgId == 1001)
			{ 
				grdContractDetails.UpdateData();
			}
		}

		private void txtCommon_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);
			FindRoutine("txtCommon#" + Index.ToString().Trim());
		}

		private void AssignGridLineNumbers()
		{
			int cnt = 0;

			int tempForEndVar = aContractDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aContractDetails.SetValue(cnt + 1, cnt, conLineNoColumn);
			}
		}

		private void CalculateContractAmount()
		{
			int cnt = 0;

			grdContractDetails.UpdateData();
			double mContractAmount = 0;
			int tempForEndVar = aContractDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mContractAmount += Conversion.Val(Convert.ToString(aContractDetails.GetValue(cnt, conUnitAmountColumn)));
			}
			grdContractDetails.Columns[conUnitAmountColumn].FooterText = StringsHelper.Format(mContractAmount, "###,###,###,##0.000");
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbCommon.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbCommon_DataSourceChanged()
		{
			int cnt = 0;

			cmbCommon.Width = 0;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			switch(grdContractDetails.Col)
			{
				case conItemNoColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbCommon.setListField("item_no"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsItemList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsItemList.setSort("item_no"); 
					int tempForEndVar = cmbCommon.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbCommon.Splits[0].DisplayColumns[cnt];
						if (cnt < 2)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdContractDetails.Col == conItemNoColumn) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdContractDetails.Splits[0].DisplayColumns[conItemNoColumn].Width;
							}
							else
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdContractDetails.Col == conItemNoColumn) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdContractDetails.Splits[0].DisplayColumns[conItemNameColumn].Width;
							}

							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							withVar.Visible = true;
							cmbCommon.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					break;
				case conUnitNoColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbCommon.setListField("unit_no"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsUnitList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsUnitList.setSort("unit_no"); 
					int tempForEndVar2 = cmbCommon.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar2; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_2 = cmbCommon.Splits[0].DisplayColumns[cnt];
						if (cnt < 2 || cnt == 4)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_2.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar_2.setOrder((grdContractDetails.Col == conUnitNoColumn) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar_2.Width = grdContractDetails.Splits[0].DisplayColumns[conUnitNoColumn].Width;
							}
							else
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_2.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar_2.setOrder((grdContractDetails.Col == conUnitNoColumn) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar_2.Width = grdContractDetails.Splits[0].DisplayColumns[conUnitAmountColumn].Width + 40;
							}

							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							withVar_2.Visible = true;
							cmbCommon.Width += withVar_2.Width / 15;
						}
						else
						{
							withVar_2.Visible = false;
						}
						withVar_2.AllowSizing = false;
					} 
					 
					cmbCommon.Width += 17; 
					cmbCommon.Height = 167; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbCommon.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbCommon_DropDownClose()
		{
			grdContractDetails.UpdateData();
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbCommon.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbCommon_RowChange()
		{
			if (grdContractDetails.Col == conItemNoColumn)
			{
				grdContractDetails.Columns[conItemNameColumn].Value = cmbCommon.Columns[1].Value;
				grdContractDetails.Columns[conItemCodeColumn].Value = cmbCommon.Columns[2].Value;
				grdContractDetails.Columns[conUnitNoColumn].Value = "";
				grdContractDetails.Columns[conUnitAmountColumn].Value = "";
			}
			else if (grdContractDetails.Col == conUnitNoColumn)
			{ 
				grdContractDetails.Columns[conUnitAmountColumn].Value = cmbCommon.Columns[1].Value;
				grdContractDetails.Columns[conUnitCodeColumn].Value = cmbCommon.Columns[2].Value;
			}
		}

		private void ShowHideMasterDetails()
		{
			bool ShowStatusSetting = false;

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				//**--setup default display dates
				txtCommonDate[conTXTStartingDate].Value = DateTime.Today;
				txtCommonDate[conTXTEndingDate].Value = DateTime.Today.AddYears(1).AddDays(-1);
				txtCommonDate[conTXTSignedDate].Value = DateTime.Today;

				//**--hide status in add mode
				ShowStatusSetting = false;
			}
			else
			{
				//**--show status in edit mode
				ShowStatusSetting = true;
			}
			lblCommon[conLBLStatusNo].Visible = ShowStatusSetting;
			txtCommon[conTXTStatusNo].Visible = ShowStatusSetting;
			txtCommonDisplay[conTXTStatusName].Visible = ShowStatusSetting;

			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			ShowStatusSetting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_security_deposit_amount_on_contract"));
			lblCommon[conLBLSecurityDepositAmount].Visible = ShowStatusSetting;
			txtCommonNumber[conTXTSecurityDepositAmount].Visible = ShowStatusSetting;
		}

		private void RefreshFormObjects()
		{
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsItemList.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			if (rsItemList.getState() == ConnectionState.Open)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsItemList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsItemList.Requery(-1);
			}
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsUnitList.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			if (rsUnitList.getState() == ConnectionState.Open)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsUnitList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsUnitList.Requery(-1);
			}
		}

		public void IRoutine()
		{
			if (grdContractDetails.Enabled)
			{
				if (ActiveControl.Name != "grdContractDetails")
				{
					grdContractDetails.Focus();
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(grdContractDetails.Bookmark))
				{
					//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aContractDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					aContractDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdContractDetails.Bookmark), 1);
					AssignGridLineNumbers();
					grdContractDetails.Rebind(true);
					grdContractDetails.Focus();
					grdContractDetails.Refresh();
				}
			}
			CalculateContractAmount();
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdContractDetails")
			{
				grdContractDetails.Focus();
			}

			if (aContractDetails.GetLength(0) > 0)
			{
				grdContractDetails.Delete();
				AssignGridLineNumbers();
				// grdContractDetails.ReBind
			}
			CalculateContractAmount();
		}

		private void InsertContractDetails(object SearchValue)
		{
			System.DateTime mFirstDate = DateTime.FromOADate(0);


			aContractDetails.RedimXArray(new int[]{0, mMaxArray}, new int[]{0, 0});
			int cnt = 0;

			string mySQL = "select item_no,";
			mySQL = mySQL + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_item_name" : "a_item_name") + " as item_name ";
			mySQL = mySQL + ", unit_no, cd.amount, cd.item_cd, cd.unit_cd, cd.remarks ";
			mySQL = mySQL + " from re_contract_details cd ";
			mySQL = mySQL + " inner join re_property_items pi on cd.item_cd = pi.item_cd ";
			mySQL = mySQL + " inner join re_property_item_unit_details iud on cd.unit_cd = iud.unit_cd ";
			mySQL = mySQL + " where cd.contract_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

			SqlDataReader rsLocalRec = null;
			SqlCommand sqlCommand = new SqlCommand(mySQL, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			rsLocalRec.Read();
			do 
			{
				aContractDetails.RedimXArray(new int[]{cnt, mMaxArray}, new int[]{0, 0});
				aContractDetails.SetValue(rsLocalRec["item_no"], cnt, conItemNoColumn);
				aContractDetails.SetValue(Convert.ToString(rsLocalRec["item_name"]) + "", cnt, conItemNameColumn);
				aContractDetails.SetValue(rsLocalRec["unit_no"], cnt, conUnitNoColumn);
				aContractDetails.SetValue(rsLocalRec["amount"], cnt, conUnitAmountColumn);
				aContractDetails.SetValue(rsLocalRec["item_cd"], cnt, conItemCodeColumn);
				aContractDetails.SetValue(rsLocalRec["unit_cd"], cnt, conUnitCodeColumn);
				aContractDetails.SetValue(Convert.ToString(rsLocalRec["remarks"]) + "", cnt, conRemarksColumn);
				cnt++;

			}
			while(rsLocalRec.Read());
			AssignGridLineNumbers();

			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdContractDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdContractDetails.setArray(aContractDetails);
			grdContractDetails.Rebind(true);
			grdContractDetails.Refresh();
		}

		public bool Post()
		{
			bool result = false;
			object mTempValue = null;

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				if (mOldVoucherStatus == SystemVariables.VoucherStatus.stActive)
				{
					if (MessageBox.Show("Are you sure you want to post this contract?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
					{
						//UPGRADE_WARNING: (1068) GetRELastMonthEndDate() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemREProcedure.GetRELastMonthEndDate());
						if (SystemProcedure2.IsItEmpty(mTempValue, SystemVariables.DataType.DateType))
						{
							MessageBox.Show("Error: No Month End Generate History Found. Contact Your Systems Administrator", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							return result;
						}

						SystemVariables.gConn.BeginTransaction();
						if (SystemREProcedure.PostREContractsStatus(ReflectionHelper.GetPrimitiveValue<System.DateTime>(mTempValue), ReflectionHelper.GetPrimitiveValue<int>(mSearchValue)))
						{
							//                '**--check if the transaction should be posted to gl after approval
							//                If GetSystemPreferenceSetting("post_to_gl_on_transaction_posting") = vbTrue Then
							//                    If PostREChargesToGL(CDate(mTempValue), CLng(mSearchValue), 1) = False Then
							//                        GoTo eFoundError
							//                    End If
							//                End If

							MessageBox.Show("Contract Successfully Posted", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							AddRecord();
						}
						else
						{
							goto eFoundError;
						}
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.CommitTrans();
					}
					else
					{
						return result;
					}
				}
				else
				{
					MessageBox.Show("Contract Already Posted", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					return result;
				}
			}
			return true;

			eFoundError:
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			MessageBox.Show("Error: Contract Posting Failed!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}


		public void PrintReport(int pEntryId = 0)
		{
			int mEntryID = 0;
			frmSysReportPrint ofrmSysReportPrint = frmSysReportPrint.CreateInstance();

			try
			{

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryID = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
				}
				else
				{
					if (!SystemProcedure2.IsItEmpty(pEntryId))
					{
						mEntryID = pEntryId;
					}
					else
					{
						return;
					}
				}

				//\crystal_files\RASHID_RENT
				clsNumToCharArabic ANumToChar = new clsNumToCharArabic();
				//Call GetCrystalReport(100070010, 2, 8463, Str(mEntryID), False)
				SystemReports.GetCrystalReport(100070010, 2, "8463, 8526", Conversion.Str(mEntryID) + ", " + ANumToChar.NumToCharArabic(Double.Parse(grdContractDetails.Columns[4].FooterText)), false);
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}


		//Public Function PostAll() As Boolean
		//Dim mTempValue As Variant
		//Dim rsTempRec As ADODB.Recordset
		//Dim cnt As Long
		//Dim mySql As String
		//Dim mPostToGLOnTransactionPosting As Boolean
		//
		//'**--to display the HourGlass
		//Dim clsHour As clsHourGlass
		//Set clsHour = New clsHourGlass
		//
		//PostAll = False
		//mPostToGLOnTransactionPosting = GetSystemPreferenceSetting("post_to_gl_on_transaction_posting")
		//
		//If MsgBox("Are you sure you want to post all active contracts?", vbQuestion + vbYesNo) = vbYes Then
		//    mTempValue = GetRELastMonthEndDate()
		//    If IsItEmpty(mTempValue, DateType) Then
		//        MsgBox "Error: No Month End Generate History Found. Contact Your Systems Administrator", vbCritical
		//        Exit Function
		//    End If
		//
		//    Set rsTempRec = New ADODB.Recordset
		//    cnt = 0
		//    mySql = "select contract_cd from re_contract "
		//    mySql = mySql & " where status = 1"
		//    With rsTempRec
		//        .CursorLocation = adUseClient
		//        .Open mySql, gConn, adOpenForwardOnly, adLockReadOnly
		//        gConn.BeginTrans
		//        Do While Not .EOF
		//            If PostREContractsStatus(CDate(mTempValue), .Fields("contract_cd").Value) = False Then
		//                GoTo eFoundError
		//            Else
		//                '**--check if the transaction should be posted to gl after approval
		//                If mPostToGLOnTransactionPosting = True Then
		//                    If PostREChargesToGL(CDate(mTempValue), .Fields("contract_cd").Value, 1) = False Then
		//                        GoTo eFoundError
		//                    End If
		//                End If
		//            End If
		//            cnt = cnt + 1
		//
		//            .MoveNext
		//        Loop
		//        gConn.CommitTrans
		//        MsgBox "Total " & Trim(cnt) & " Contracts Posted Successfully", vbInformation
		//    End With
		//Else
		//    Exit Function
		//End If
		//PostAll = True
		//Exit Function
		//
		//eFoundError:
		//gConn.RollbackTrans
		//MsgBox "Error: Contract Posting Failed!", vbCritical
		//PostAll = False
		//End Function
	}
}