
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayAssetsTrans
		: System.Windows.Forms.Form
	{

		public frmPayAssetsTrans()
{
InitializeComponent();
} 
 public  void frmPayAssetsTrans_old()
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


		private void frmPayAssetsTrans_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		private string mTimeStamp = "";

		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
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

		private bool mFirstGridFocus = false;
		private DataSet rsBillingCodeList = null;

		private const int mconTxtTransactionNo = 0;
		private const int mconTxtEmployeeCode = 2;
		private const int mconTxtComments = 3;

		private const int mcmbTransactionType = 0;

		private const int mDlblEmployeeName = 0;

		private const int conMaxColumns = 4;
		private const int grdAssetLineNo = 0;
		private const int grdAssetNo = 1;
		private const int grdAssetName = 2;
		private const int grdAssetQuantity = 3;
		private const int grdAssetID = 4;



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


		private void cmbCommon_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[mconTxtEmployeeCode].Text, SystemVariables.DataType.StringType))
			{
				mFirstGridFocus = true;
				DefineMasterRecordset();
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			FirstFocusObject = txtCommonTextBox[mconTxtTransactionNo];

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
				oThisFormToolBar.ShowDeleteButton = false;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;
				this.WindowState = FormWindowState.Maximized;

				SystemGrid.DefineSystemVoucherGrid(grdAssetTransDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");
				SystemGrid.DefineSystemVoucherGridColumn(grdAssetTransDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAssetTransDetails, "Asset No", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdAssetTransDetails, "Asset Name", 3500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, true, false, false, false, false, 100, "", "", false, "", 0, true);

				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Code", 1300, , , , , False, , , True, , , "cmbMastersList", , , , , , , , , , , , , True)
				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Name", 3500, , , , , False, , , True, True, False, "cmbMastersList", , , , , , , , , , , , , True)


				SystemGrid.DefineSystemVoucherGridColumn(grdAssetTransDetails, "Issued Quantity", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdAssetTransDetails, "Asset ID", 0, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdAssetTransDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdAssetTransDetails.setArray(aVoucherDetails);
				grdAssetTransDetails.Rebind(true);
				SystemProcedure.SetLabelCaption(this);
				txtTransDate.Value = DateTime.Today;
				//Fill the combo
				object[] mObjectId = new object[1];
				mObjectId[mcmbTransactionType] = 1031;

				SystemCombo.FillComboWithSystemObjects(cmbCommon, mObjectId);
				//assign a next code
				Application.DoEvents();
				txtCommonTextBox[mconTxtTransactionNo].Text = SystemProcedure2.GetNewNumber("Pay_Assets_Transaction", "Transaction_No", 2);
				mFirstGridFocus = true;
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
				if (this.ActiveControl.Name == "grdAssetTransDetails")
				{
					if (KeyCode == 13 || KeyCode == 113)
					{
						return;
					}
					else if (KeyCode == 222)
					{  //'for "'"
						KeyCode = 0;
						return;
					}
					if (Shift == 0)
					{
						if (grdAssetTransDetails.Col == grdAssetQuantity)
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

		public void AddRecord()
		{
			int cnt = 0;
			//Add a record

			int tempForEndVar = grdAssetTransDetails.Columns.Count - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				grdAssetTransDetails.Columns[cnt].FooterText = "";
			}

			SystemProcedure2.ClearTextBox(this);
			txtCommonTextBox[mconTxtTransactionNo].Text = SystemProcedure2.GetNewNumber("Pay_Assets_Transaction", "Transaction_No", 2);
			DefineVoucherArray(-1, true);
			AssignGridLineNumbers();
			grdAssetTransDetails.Rebind(true);
			mFirstGridFocus = true;
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			txtTransDate.Value = DateTime.Today;
			//FirstFocusObject.SetFocus
			txtCommonTextBox[mconTxtEmployeeCode].Enabled = true;
			cmbCommon[mcmbTransactionType].Enabled = true;
			txtTransDate.Enabled = true;
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord()
		{
			bool result = false;
			try
			{
				string mysql = "";
				object mReturnValue = null;
				int mEmpCd = 0;
				int mTransType = 0;

				mysql = "select emp_cd from pay_employee where emp_no ='" + txtCommonTextBox[mconTxtEmployeeCode].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					MessageBox.Show("Invaild Employee Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
				SystemVariables.gConn.BeginTransaction();
				mTransType = cmbCommon[mcmbTransactionType].GetItemData(cmbCommon[mcmbTransactionType].ListIndex);
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = "insert into pay_assets_transaction";
					mysql = mysql + "(transaction_no,transaction_date,transaction_type,emp_cd";
					mysql = mysql + " ,remarks,user_cd)";
					mysql = mysql + " values('" + txtCommonTextBox[mconTxtTransactionNo].Text + "'";
					mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtTransDate.Value) + "'";
					mysql = mysql + " , " + cmbCommon[mcmbTransactionType].GetItemData(cmbCommon[mcmbTransactionType].ListIndex).ToString();
					mysql = mysql + " , " + mEmpCd.ToString();
					mysql = mysql + " ,N'" + txtCommonTextBox[mconTxtComments].Text + "'";
					mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select scope_identity()"));
				}
				else
				{
					ReverseAffectedAssets();
					mysql = "update pay_assets_transaction";
					mysql = mysql + "set transaction_no = '" + txtCommonTextBox[mconTxtTransactionNo].Text + "'";
					mysql = mysql + ",transaction_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtTransDate.Value) + "'";
					mysql = mysql + ",transaction_type = " + cmbCommon[mcmbTransactionType].GetItemData(cmbCommon[mcmbTransactionType].ListIndex).ToString();
					mysql = mysql + ",emp_cd = " + mEmpCd.ToString();
					mysql = mysql + ",remarks = N'" + txtCommonTextBox[mconTxtComments].Text + "'";
					mysql = mysql + ",user_cd = " + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				}
				//Delete pay_assets_transaction_details
				mysql = "delete from pay_assets_transaction_details";
				mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();
				int mCnt = 0;
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (mCnt = 0; mCnt <= tempForEndVar; mCnt++)
				{
					mysql = " insert into pay_assets_transaction_details(entry_id,asset_entry_id,issue_qty)";
					mysql = mysql + " values(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(mCnt, grdAssetID));
					mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(mCnt, grdAssetQuantity));
					mysql = mysql + ")";
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();
					UpdateMasterAssets(mTransType, Convert.ToInt32(aVoucherDetails.GetValue(mCnt, grdAssetQuantity)), Convert.ToInt32(aVoucherDetails.GetValue(mCnt, grdAssetID)), mEmpCd);
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				return true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}
			return result;
		}


		public void PrintReport()
		{

		}


		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220550));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void GetRecord(object pSearchValue)
		{
			DataSet rsLocal = null;
			int mCntRow = 0;

			string mSQL = " select transaction_no,transaction_date,transaction_type,remarks,pemp.emp_no";
			mSQL = mSQL + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ",l_full_name " : ",a_full_name") + " as emp_name";
			mSQL = mSQL + " , pas.entry_id";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mSQL = mSQL + ", (select l_object_caption from SM_Objects sobj where sobj.Interpreted_Value = pas.Transaction_Type and sobj.Group_Id = 1031)";
			}
			else
			{
				mSQL = mSQL + ", (select l_object_caption from SM_Objects sobj where sobj.Interpreted_Value = pas.Transaction_Type and sobj.Group_Id = 1031)";
			}
			mSQL = mSQL + " from Pay_Assets_Transaction pas";
			mSQL = mSQL + " inner join pay_employee pemp on pemp.emp_cd = pas.emp_cd";
			mSQL = mSQL + " where pas.entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(6));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonTextBox[mconTxtTransactionNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtTransDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
				SystemCombo.SearchCombo(cmbCommon[mcmbTransactionType], ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2)));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonTextBox[mconTxtComments].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonTextBox[mconTxtEmployeeCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(4));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[mDlblEmployeeName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(5));

				mSQL = " select patd.entry_id, patd.Issue_Qty, pa.asset_no, pa.l_asset_name, patd.Asset_Entry_Id";
				mSQL = mSQL + " from pay_assets_transaction_details patd";
				mSQL = mSQL + " inner join Pay_Assets pa on pa.entry_id = patd.Asset_Entry_Id";
				mSQL = mSQL + " Where patd.entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				rsLocal = new DataSet();
				SqlDataAdapter adap = new SqlDataAdapter(mSQL, SystemVariables.gConn);
				rsLocal.Tables.Clear();
				adap.Fill(rsLocal);
				aVoucherDetails.RedimXArray(new int[]{rsLocal.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
				mCntRow = 0;
				foreach (DataRow iteration_row in rsLocal.Tables[0].Rows)
				{
					aVoucherDetails.SetValue(iteration_row["asset_no"], mCntRow, grdAssetNo);
					aVoucherDetails.SetValue(iteration_row["l_asset_name"], mCntRow, grdAssetName);
					aVoucherDetails.SetValue(iteration_row["Issue_Qty"], mCntRow, grdAssetQuantity);
					aVoucherDetails.SetValue(iteration_row["Asset_Entry_Id"], mCntRow, grdAssetID);
					mCntRow++;
				}
				AssignGridLineNumbers();
				grdAssetTransDetails.Rebind(true);
				grdAssetTransDetails.Refresh();
				rsLocal = null;
			}
			txtCommonTextBox[mconTxtEmployeeCode].Enabled = false;
			cmbCommon[mcmbTransactionType].Enabled = false;
			txtTransDate.Enabled = false;

			CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
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

				frmPayAssetsTrans.DefInstance = null;
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
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, conMaxColumns}, new int[]{0, 0});
		}

		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, SystemICSConstants.grdLineNoColumn);
			}
		}


		public bool CheckDataValidity()
		{
			//Check validation during update and add of records

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[mconTxtEmployeeCode].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Employee Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[mconTxtEmployeeCode].Focus();
				return false;
			}

			return true;
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			if (grdAssetTransDetails.Col == grdAssetNo)
			{
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setListField("asset_no");
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList.setSort("asset_no");
			}
			else
			{
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setListField("asset_name");
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList.setSort("asset_name");
			}

			int tempForEndVar = cmbMastersList.Columns.Count - 1;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar = cmbMastersList.Splits[0].DisplayColumns[cnt];
				if (cnt < 2)
				{
					if (cnt == 0)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						withVar.setOrder((grdAssetTransDetails.Col == grdAssetNo) ? 0 : 1);
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar.Width = grdAssetTransDetails.Splits[0].DisplayColumns[grdAssetNo].Width;
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						withVar.setOrder((grdAssetTransDetails.Col == grdAssetNo) ? 1 : 0);
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar.Width = grdAssetTransDetails.Splits[0].DisplayColumns[grdAssetName].Width;
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
					cmbMastersList.Width += withVar.Width / 15;
				}
				else
				{
					withVar.Visible = false;
				}
				withVar.AllowSizing = false;
			}
			cmbMastersList.Width += 17;
			cmbMastersList.Height = 167;

			//
			//Select Case grdAssetTransDetails.Col
			//    Case grdAssetNo
			//        cmbMastersList.ListField = "asset_no"
			//        rsBillingCodeList.Sort = "asset_no"
			//        For cnt = 0 To cmbMastersList.Columns.Count - 1
			//            With cmbMastersList.Columns(cnt)
			//                If cnt < 3 Then
			//                    If cnt = 0 Then
			//                        .Order = IIf(grdAssetTransDetails.Col = grdAssetNo, 0, 1)
			//                        .Width = grdAssetTransDetails.Columns(grdAssetNo).Width
			//                    End If
			//                    .Alignment = dbgLeft
			//                    .Visible = True
			//                    cmbMastersList.Width = cmbMastersList.Width + .Width
			//                Else
			//                    .Visible = False
			//                End If
			//                .AllowSizing = False
			//            End With
			//        Next
			//        cmbMastersList.Width = cmbMastersList.Width + 250
			//        cmbMastersList.Height = 2000
			//Case grdAssetName
			//        cmbMastersList.ListField = "asset_name"
			//        rsBillingCodeList.Sort = "asset_name"
			//        For cnt = 0 To cmbMastersList.Columns.Count - 1
			//            With cmbMastersList.Columns(cnt)
			//                If cnt < 3 Then
			//                    If cnt = 0 Then
			//                        .Order = IIf(grdAssetTransDetails.Col = grdAssetName, 0, 1)
			//                        .Width = grdAssetTransDetails.Columns(grdAssetName).Width
			//                    End If
			//                    .Alignment = dbgLeft
			//                    .Visible = True
			//                    cmbMastersList.Width = cmbMastersList.Width + .Width
			//                Else
			//                    .Visible = False
			//                End If
			//                .AllowSizing = False
			//            End With
			//        Next
			//        cmbMastersList.Width = cmbMastersList.Width + 250
			//        cmbMastersList.Height = 2000
			//End Select
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			switch(grdAssetTransDetails.Col)
			{
				case grdAssetNo : 
					grdAssetTransDetails.Col = grdAssetNo; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			if (grdAssetTransDetails.Col == grdAssetNo)
			{
				//grdAssetTransDetails.Columns(grdAssetNo).Value = cmbMastersList.Columns(0).Value
				grdAssetTransDetails.Columns[grdAssetName].Value = cmbMastersList.Columns[1].Value;
				grdAssetTransDetails.Columns[grdAssetID].Value = cmbMastersList.Columns[3].Value;
				grdAssetTransDetails.Columns[grdAssetQuantity].Value = 0;
				AssignGridLineNumbers();
			}
			else if (grdAssetTransDetails.Col == grdAssetName)
			{ 
				grdAssetTransDetails.Columns[grdAssetNo].Value = cmbMastersList.Columns[0].Value;
				//grdAssetTransDetails.Columns(grdAssetName).Value = cmbMastersList.Columns(0).Value
				grdAssetTransDetails.Columns[grdAssetID].Value = cmbMastersList.Columns[3].Value;
				grdAssetTransDetails.Columns[grdAssetQuantity].Value = 0;
				AssignGridLineNumbers();
			}

			//If grdVoucherDetails.Col = mLedgerCodeColumn Or grdVoucherDetails.Col = mLedgerNameColumn Then
			//    If grdVoucherDetails.Col = mLedgerCodeColumn Then
			//        grdVoucherDetails.Columns(mLedgerNameColumn).Value = cmbMastersList.Columns(1).Value
			//    Else
			//        grdVoucherDetails.Columns(mLedgerCodeColumn).Value = cmbMastersList.Columns(0).Value
			//    End If
			//End If

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdAssetTransDetails.AfterInsert was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdAssetTransDetails_AfterInsert()
		{
			AssignGridLineNumbers();
			grdAssetTransDetails.Refresh();
		}

		private void grdAssetTransDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			if (mFirstGridFocus)
			{
				if (Convert.ToString(cmbMastersList.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList);
					cmbMastersList.Tag = "OK";
				}

				DefineMasterRecordset();
				mFirstGridFocus = false;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdAssetTransDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdAssetTransDetails.PostMsg(1);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdAssetTransDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdAssetTransDetails_PostEvent(int MsgId)
		{
			int Col = 0;

			if (MsgId == 1)
			{
				grdAssetTransDetails.Col = grdAssetNo;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList);
			}
		}

		private void grdAssetTransDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdAssetTransDetails.Col > 0 && LastCol > 0 && !mFirstGridFocus)
			{
				switch(grdAssetTransDetails.Col)
				{
					case grdAssetNo : case grdAssetName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList); 
						break;
				}
			}
		}

		public void IRoutine()
		{
			int mCurrentLineNo = 0;

			if (ActiveControl.Name != "grdAssetTransDetails" && grdAssetTransDetails.Enabled)
			{
				grdAssetTransDetails.Focus();
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdAssetTransDetails.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdAssetTransDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdAssetTransDetails.Columns[grdAssetLineNo].Value);
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdAssetTransDetails.Bookmark), 1);
				AssignGridLineNumbers();
				grdAssetTransDetails.Rebind(true);
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdAssetTransDetails" && grdAssetTransDetails.Enabled)
			{
				grdAssetTransDetails.Focus();
			}

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdAssetTransDetails.Delete();
				AssignGridLineNumbers();
				grdAssetTransDetails.Rebind(true);
			}
		}

		private void DefineMasterRecordset()
		{
			string mysql = "";
			int mTransType = 0;
			if (mFirstGridFocus)
			{
				mTransType = cmbCommon[mcmbTransactionType].GetItemData(cmbCommon[mcmbTransactionType].ListIndex);
				if (mTransType == 1 || mTransType == 3)
				{
					mysql = " select asset_no ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_asset_name" : "a_asset_name") + " as asset_name";
					mysql = mysql + " ,  balance_qty, entry_id";
					mysql = mysql + " from pay_assets ";
					mysql = mysql + " where balance_qty > 0";
					mysql = mysql + " order by 1 ";
				}
				else
				{
					mysql = " select asset_no ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_asset_name" : "a_asset_name") + " as asset_name";
					mysql = mysql + " ,  paed.quantity , pa.entry_id";
					mysql = mysql + " from pay_assets pa";
					mysql = mysql + " inner join pay_assets_emp_details paed on paed.asset_entry_id =  pa.entry_id";
					mysql = mysql + " where paed.quantity > 0";
					mysql = mysql + " and paed.emp_cd=" + SystemHRProcedure.GetEmpCd(txtCommonTextBox[mconTxtEmployeeCode].Text).ToString();
					mysql = mysql + " order by 1 ";
				}
				rsBillingCodeList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsBillingCodeList.Tables.Clear();
				adap.Fill(rsBillingCodeList);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsBillingCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList.Requery(-1);
			}
		}

		public void FindRoutine(string pObjectName)
		{
			string mysql = "";
			object mTempSearchValue = null;

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

			switch(mIndex)
			{
				case mconTxtEmployeeCode : 
					txtCommonTextBox[mconTxtEmployeeCode].Text = ""; 
					mysql = " pay_emp.status_cd not in (3,4)"; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", mysql)); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[mconTxtEmployeeCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				default:
					break;
			}

		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			string mSQL = "";
			object mReturnValue = null;

			switch(Index)
			{
				case mconTxtEmployeeCode : 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(txtCommonTextBox[mconTxtEmployeeCode].Text) && txtCommonTextBox[mconTxtEmployeeCode].Text != "")
					{
						mSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_full_name" : " a_full_name");
						mSQL = mSQL + " from pay_employee";
						mSQL = mSQL + " where  emp_no ='" + txtCommonTextBox[mconTxtEmployeeCode].Text + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[mDlblEmployeeName].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
							mFirstGridFocus = true;
							DefineMasterRecordset();
						}
						else
						{
							txtDisplayLabel[mDlblEmployeeName].Text = "";
							txtCommonTextBox[mconTxtEmployeeCode].Text = "";
						}
					}
					else
					{
						txtDisplayLabel[mDlblEmployeeName].Text = "";
						txtCommonTextBox[mconTxtEmployeeCode].Text = "";

					} 
					break;
				default:
					return;
			}
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			if (Index == mconTxtTransactionNo)
			{
				txtCommonTextBox[mconTxtTransactionNo].Text = SystemProcedure2.GetNewNumber("Pay_Assets_Transaction", "Transaction_No", 2);
			}
			else
			{
				FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
			}
		}

		public bool UpdateMasterAssets(int pTransType, int pIssuedQTy, int pAssetID, int pEmpCd)
		{
			object mReturnValue = null;
			string mysql = "update pay_assets";
			if (pTransType == 1)
			{
				mysql = mysql + " set issued_qty = issued_qty + " + pIssuedQTy.ToString();
			}
			else if (pTransType == 2)
			{ 
				mysql = mysql + " set issued_qty = issued_qty - " + pIssuedQTy.ToString();
			}
			else
			{
				mysql = mysql + " set damage_qty = damage_qty + " + pIssuedQTy.ToString();
			}
			mysql = mysql + " where entry_id =" + pAssetID.ToString();
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();
			if (pTransType != 3)
			{
				mysql = " select entry_id";
				mysql = mysql + " from pay_assets_emp_details";
				mysql = mysql + " where emp_cd =" + pEmpCd.ToString();
				mysql = mysql + " and asset_entry_id =" + pAssetID.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mysql = "update pay_assets_emp_details";
					mysql = mysql + " set quantity = quantity + " + ((pTransType == 1) ? pIssuedQTy : (pIssuedQTy * -1)).ToString();
					mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}
				else
				{
					mysql = "insert into pay_assets_emp_details(emp_cd ,asset_entry_id, quantity)";
					mysql = mysql + " values(" + pEmpCd.ToString();
					mysql = mysql + "," + pAssetID.ToString();
					mysql = mysql + "," + pIssuedQTy.ToString();
					mysql = mysql + ")";
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();
				}
			}
			return false;
		}

		public object ReverseAffectedAssets()
		{

			string mSQL = "select pat.transaction_type,pa.balance_qty, patd.issue_qty ,patd.asset_entry_id ,pat.emp_cd";
			mSQL = mSQL + " from pay_assets_transaction pat";
			mSQL = mSQL + " inner join pay_assets_transaction_details patd on pat.entry_id = patd.entry_id";
			mSQL = mSQL + " inner join Pay_Assets pa on pa.entry_id = patd.Asset_Entry_Id";
			mSQL = mSQL + " Where pat.entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			SqlDataReader rsLocal = null;
			SqlCommand sqlCommand = new SqlCommand(mSQL, SystemVariables.gConn);
			rsLocal = sqlCommand.ExecuteReader();
			rsLocal.Read();
			do 
			{
				UpdateMasterAssets(Convert.ToInt32(rsLocal["transaction_type"]), Convert.ToInt32(rsLocal["issue_qty"]) * -1, Convert.ToInt32(rsLocal["asset_entry_id"]), Convert.ToInt32(rsLocal["emp_cd"]));
			}
			while(rsLocal.Read());
			return null;
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdAssetTransDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdAssetTransDetails_FormatText(int ColIndex, object Value, object Bookmark)
		{
			if (ColIndex == grdAssetQuantity)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					CalculateTotal();
				}
			}
		}

		private void CalculateTotal()
		{
			int mCnt = 0;
			double mTotal = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (mCnt = 0; mCnt <= tempForEndVar; mCnt++)
			{
				mTotal += Convert.ToDouble(aVoucherDetails.GetValue(mCnt, grdAssetQuantity));
			}

			if (mTotal != 0)
			{
				grdAssetTransDetails.Columns[grdAssetQuantity].FooterText = mTotal.ToString();
			}
			else
			{
				grdAssetTransDetails.Columns[grdAssetQuantity].FooterText = "";
			}
		}
	}
}