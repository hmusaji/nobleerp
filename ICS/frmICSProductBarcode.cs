
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmICSProductBarcode
		: System.Windows.Forms.Form
	{

		public frmICSProductBarcode()
{
InitializeComponent();
} 
 public  void frmICSProductBarcode_old()
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


		private void frmICSProductBarcode_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private DataSet rsProductList = null;
		private bool mFirstGridFocus = false;

		
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
		//Dim mHeaderLineNo As Double
		//Dim mDetailLineNo As Double
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

		private clsToolbar oThisFormToolBar = null;

		private const int mLineNoColumn = 0;
		//Private Const mProductCodeColumn As Integer = 1
		//Private Const mProductNameColumn As Integer = 2
		//Private Const mTimeStampColumn As Integer = 10
		private const int mBarCodeColumn = 1;
		private const int mUnitCodeColumn = 2;

		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

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


		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				rsProductList = null;
				oThisFormToolBar = null;
				UserAccess = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public bool CheckDataValidity()
		{
			bool result = false;
			int cnt = 0;
			//Check validation during update and add of records

			if (SystemProcedure2.IsItEmpty(txtProductCode.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Part Number", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//FirstFocusObject.SetFocus
				result = false;
				txtProductCode.Focus();
				return result;
			}

			grdVoucherDetails.UpdateData();

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, mBarCodeColumn), SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Bar Code ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					//FirstFocusObject.SetFocus
					return false;
				}
			}

			int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar2; cnt++)
			{
				if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, mUnitCodeColumn), SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter ICS_Unit Symbol", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					//FirstFocusObject.SetFocus
					return false;
				}
			}
			return true;
		}

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object MasterProductCode = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Prod_Cd from ICS_Item where Part_no='" + txtProductCode.Text + "'"));

			string mysql = "";
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(MasterProductCode))
			{
				grdVoucherDetails.Enabled = true;

				mFirstGridFocus = false;
				//setting up the ICS_Item list combobox properties

				mysql = "select  symbol , ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Unit_Name [Unit Name]" : "A_Unit_Name [Unit Name]");
				mysql = mysql + " from ICS_Item ";
				mysql = mysql + " INNER JOIN   ICS_Item_Unit_Details ON ICS_Item.Prod_Cd = ICS_Item_Unit_Details.Prod_Cd  ";
				mysql = mysql + " INNER JOIN   ICS_Unit ON ICS_Item_Unit_Details.Alt_Unit_Cd = ICS_Unit.Unit_Cd  ";
				mysql = mysql + " where ICS_Item.prod_cd = " + ReflectionHelper.GetPrimitiveValue<string>(MasterProductCode);

				rsProductList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProductList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsProductList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsProductList.Tables.Clear();
				adap.Fill(rsProductList);

				SystemGrid.DefineSystemGridCombo(cmbCommon);
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property CmbCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbCommon.setDataSource((msdatasrc.DataSource) rsProductList);

			}
			else
			{
				grdVoucherDetails.Enabled = false;
			}
			grdVoucherDetails.Col = 1;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, "&H98AA88");
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Product Barcode", 3500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "", true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Units", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon", true);

			C1.Win.C1TrueDBGrid.C1DisplayColumn colVoucherDetails = null;

			this.Top = 0;
			this.Left = 0;

			mFirstGridFocus = true;
			//setting voucher details grid properties
			aVoucherDetails.RedimXArray(new int[]{0, 2}, new int[]{0, 0});
			aVoucherDetails.SetValue(1, 0, 0);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);
			grdVoucherDetails.Rebind(true);
			//-- end of voucher grid property setting
			cmbCommon.Width = 327;
			cmbCommon.Height = 100;

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
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.DisableHelpButton = true;

			this.WindowState = FormWindowState.Maximized;

		}

		private void txtProductCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			object mTempValue = null;

			try
			{

				if (!SystemProcedure2.IsItEmpty(txtProductCode.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_Prod_name, Prod_cd" : "a_Prod_name, Prod_cd") + " from ICS_Item where Part_no ='" + txtProductCode.Text + "'"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtProductName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						grdVoucherDetails.Enabled = true;
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtProductName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select prod_Cd from ICS_Item where Part_no ='" + txtProductCode.Text + "'"));
						GetRecord(mSearchValue);
					}
				}
				else
				{
					txtProductName.Text = "";
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
						txtProductCode.Text = "";
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

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//if the user presses any control key in the voucher grid object
				if (this.ActiveControl.Name == "grdVoucherDetails")
				{
					switch(KeyCode)
					{
						case 13 : case 113 : 
							return;
					}
					if (Shift == 0)
					{
						if (grdVoucherDetails.Col == 4 || grdVoucherDetails.Col == 5 || grdVoucherDetails.Col == 6 || grdVoucherDetails.Col == 7)
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
					else if (Shift == 2)
					{ 
						switch(KeyCode)
						{
							case 68 :  //Ctrl+D to delete grid current row 
								//                aVoucherDetails.DeleteRows (grdVoucherDetails.row) 
								//                grdVoucherDetails.Refresh 
								break;
							case 73 :  //Ctrl+I to insert a row from grid's current row 
								//aVoucherDetails.InsertRows 
								break;
						}
					}
				}

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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			grdVoucherDetails.Columns[0].Text = (grdVoucherDetails.RowCount + 1).ToString();
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbCommon.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbCommon_DropDownClose()
		{
			if (grdVoucherDetails.Col == 1)
			{
				grdVoucherDetails.Col++;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbCommon.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbCommon_RowChange()
		{
			if (grdVoucherDetails.Col == 2)
			{
				//Display the ICS_Unit Name from listbox into Grid
				//grdVoucherDetails.Columns(mBarCodeColumn).Value = cmbCommon.Columns(0).Value

				//grdVoucherDetails.Columns(2).Alignment = dbgLeft
				//grdVoucherDetails.Columns(2).Value = cmbCommon.Columns(1).Value
			}
		}

		public void CloseForm()
		{
			aVoucherDetails = null;
			this.Close();
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
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), 1);
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

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdVoucherDetails.Delete();
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
			}
		}

		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, mLineNoColumn);
			}
		}

		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);

			//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			aVoucherDetails.Clear();
			aVoucherDetails.RedimXArray(new int[]{0, 2}, new int[]{0, 0});
			aVoucherDetails.SetValue(1, 0, 0);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);

			grdVoucherDetails.Rebind(true);
			txtProductCode.Focus();
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}


		public void findRecord()
		{

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				grdVoucherDetails.Enabled = true;
				GetRecord(mSearchValue);
			}

		}

		public bool saveRecord()
		{
			bool result = false;
			StringBuilder mysql = new StringBuilder();
			object MasterProductCode = null;
			object DuplicateBarcode = null;
			object UnitCode = null;
			int cnt = 0;
			try
			{

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				MasterProductCode = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Prod_Cd from ICS_Item where Part_no='" + txtProductCode.Text + "'"));

				grdVoucherDetails.UpdateData();
				SystemVariables.gConn.BeginTransaction();

				mysql = new StringBuilder(" delete from ICS_Item_Barcode_Details  ");
				mysql.Append(" where prod_cd=" + ReflectionHelper.GetPrimitiveValue<string>(MasterProductCode));
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql.ToString();
				TempCommand.ExecuteNonQuery();

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					UnitCode = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("SELECT ICS_Item_Unit_Details.unit_entry_id FROM   ICS_Item INNER JOIN   ICS_Item_Unit_Details ON ICS_Item.Prod_Cd = ICS_Item_Unit_Details.Prod_Cd INNER JOIN   ICS_Unit ON ICS_Item_Unit_Details.Alt_Unit_Cd = ICS_Unit.Unit_Cd where ICS_Item.part_no='" + txtProductCode.Text + "' and ICS_Unit.symbol='" + Convert.ToString(aVoucherDetails.GetValue(cnt, 2)) + "'"));

					if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Allow_Duplicate_Barcode")))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						DuplicateBarcode = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Barcode from ICS_Item_Barcode_Details where Barcode='" + Convert.ToString(aVoucherDetails.GetValue(cnt, 1)) + "'"));
						if (aVoucherDetails.GetValue(cnt, 1) == DuplicateBarcode)
						{
							MessageBox.Show("Duplicate Barcode Number", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							grdVoucherDetails.Bookmark = cnt;

							grdVoucherDetails.Focus();
							return result;

						}



					}


					mysql = new StringBuilder(" Insert into ICS_Item_Barcode_Details (prod_cd, Barcode , Unit_Entry_Id) ");
					mysql.Append(" Values ( ");
					mysql.Append(Conversion.Str(MasterProductCode) + " , ");
					mysql.Append("'" + Convert.ToString(aVoucherDetails.GetValue(cnt, 1)) + "' , " + Conversion.Str(UnitCode) + ")");
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql.ToString();
					TempCommand_2.ExecuteNonQuery();

				}
				// end of updating transaction details table
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				txtProductCode.Focus();
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
			}

			return result;
		}


		public void GetRecord(object pSearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting
			SqlDataReader rsLocalRec = null;

			string mysql = "";

			try
			{

				CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
				if (Object.Equals(pSearchValue, null) || Convert.IsDBNull(pSearchValue))
				{
					return;
				}

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtProductCode.Text = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode(" select part_no from ICS_Item where Prod_cd='" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue) + "'"));
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtProductName.Text = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode(" select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_Prod_name" : "a_Prod_name") + " from ICS_Item where Prod_cd=" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue)));


				mysql = "select  pbd.Barcode , ICS_Unit.symbol   ";
				mysql = mysql + " from ICS_Item_barcode_details pbd inner join ICS_Item on pbd.prod_cd = ICS_Item.prod_cd";
				mysql = mysql + " inner join ICS_Item_Unit_Details aud on pbd.unit_entry_id = aud.unit_entry_id";
				mysql = mysql + " inner join ICS_Unit on aud.alt_unit_cd = ICS_Unit.unit_cd  ";
				mysql = mysql + " where pbd.prod_cd = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);


				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand.ExecuteReader();

				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
				aVoucherDetails.RedimXArray(new int[]{0, 5}, new int[]{0, 0});

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[1].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[2].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
				int cnt = 0;
				if (rsLocalRec.Read())
				{
					do 
					{

						aVoucherDetails.RedimXArray(new int[]{cnt, 5}, new int[]{0, 0});

						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["Barcode"]).Trim(), cnt, 1);
						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["symbol"]).Trim(), cnt, 2); //     IIf(gPreferedLanguage = english, Trim(.Fields("l_prod_name")), Trim(.Fields("a_prod_name")))
						cnt++;
					}
					while(rsLocalRec.Read());
				}
				rsLocalRec.Close();

				AssignGridLineNumbers();

				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Refresh();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
		}

		public bool deleteRecord()
		{
			bool result = false;
			string mysql = "";
			object ReplacementProductCode = null;

			try
			{

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				ReplacementProductCode = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Prod_Cd from ICS_Item where part_no='" + txtProductCode.Text + "'"));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049


				if (Convert.IsDBNull(ReplacementProductCode))
				{
					MessageBox.Show("Enter Part Number", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					//FirstFocusObject.SetFocus
					//CheckDataValidity = False
					txtProductCode.Focus();
					return result;
				}
				else
				{
					mysql = " delete from ICS_Item_Barcode_Details  ";
					mysql = mysql + " where prod_cd=" + ReflectionHelper.GetPrimitiveValue<string>(ReplacementProductCode);
					//If an error occurs, trap the error and dispaly a valid message
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
					return true;
				}
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
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
			return result;
		}

		public void FindRoutine(string pObjectName)
		{

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}

		}
	}
}