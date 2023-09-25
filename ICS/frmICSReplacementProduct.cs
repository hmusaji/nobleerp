
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmICSReplacementProduct
		: System.Windows.Forms.Form
	{

		public frmICSReplacementProduct()
{
InitializeComponent();
} 
 public  void frmICSReplacementProduct_old()
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


		private void frmICSReplacementProduct_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private bool mFirstGridFocus = false;
		private object mSearchValue = null;
		private clsToolbar oThisFormToolBar = null;

		private int mThisFormID = 0;
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


		private const int conLineNoColumn = 0;
		private const int conPartNo = 1;
		private const int conProductNameColumn = 2;
		private const int conStockInHandQty = 3;
		private const int conSalesRate = 4;

		private const int mMaxArray = 4;

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
			C1.Win.C1TrueDBGrid.C1DisplayColumn colVoucherDetails = null;

			//**--define voucher grid columns
			SystemProcedure.SetLabelCaption(this);
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, "&HA3E0DA");

			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Product Code", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon", true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Product Name", 2500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Stock In Hand", 1300, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Sales Rate", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false);


			this.Top = 0;
			this.Left = 0;

			mFirstGridFocus = true;
			//setting voucher details grid properties
			aVoucherDetails.RedimXArray(new int[]{0, mMaxArray}, new int[]{0, 0});
			aVoucherDetails.SetValue(1, 0, 0);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);
			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Enabled = false;
			//-- end of voucher grid property setting
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			cmbCommon.Width = grdVoucherDetails.Splits[0].DisplayColumns[conPartNo].Width + grdVoucherDetails.Splits[0].DisplayColumns[conProductNameColumn].Width + 20;
			cmbCommon.Height = 113;

			//**--format & define the new toolbar
			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			oThisFormToolBar.ShowNewButton = false;
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

			//
			//'Imagelist are kept on the main form and refered by their key
			//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(1))
			//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
			//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
			//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
			//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
			//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
			//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgInsertLine").Picture
			//Set btnFormToolBar(7).Picture = frmSysMain.imlMainToolBar.ListImages("imgDeleteLine").Picture
			//Set btnFormToolBar(8).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture

			clsFlip oFlipThisForm = null;
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
			{
				oFlipThisForm = new clsFlip();
				oFlipThisForm.SwapMe(this);
			}


		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				oThisFormToolBar = null;
				UserAccess = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
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
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtProductName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
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
						txtProductCode.Focus();
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			grdVoucherDetails.Columns[0].Text = (grdVoucherDetails.RowCount + 1).ToString();
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbCommon.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbCommon_RowChange()
		{
			if (grdVoucherDetails.Col == 1)
			{
				grdVoucherDetails.Columns[conProductNameColumn].Value = cmbCommon.Columns[1].Value;
				grdVoucherDetails.Columns[conStockInHandQty].Value = cmbCommon.Columns[2].Value;
				grdVoucherDetails.Columns[conSalesRate].Value = StringsHelper.Format(cmbCommon.Columns[3].Value, "###,###,###,##0.000");
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
				if (grdVoucherDetails.Enabled)
				{
					grdVoucherDetails.Focus();
				}
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdVoucherDetails.Bookmark))
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), 1);
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);

				if (grdVoucherDetails.Enabled)
				{
					grdVoucherDetails.Focus();
				}
				grdVoucherDetails.Refresh();
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdVoucherDetails")
			{
				if (grdVoucherDetails.Enabled)
				{
					grdVoucherDetails.Focus();
				}
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
				aVoucherDetails.SetValue(cnt + 1, cnt, conLineNoColumn);
			}
		}

		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);

			//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			aVoucherDetails.Clear();
			aVoucherDetails.RedimXArray(new int[]{0, mMaxArray}, new int[]{0, 0});
			aVoucherDetails.SetValue(1, 0, 0);

			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Enabled = false;

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
				GetRecord(mSearchValue);
			}
		}

		public bool saveRecord()
		{
			bool result = false;
			string mysql = "";
			int mMasterProductCode = 0;
			int mReplacementProductCode = 0;
			object mReturnValue = null;
			int cnt = 0;
			try
			{

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Prod_Cd from ICS_Item where Part_no='" + txtProductCode.Text + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mMasterProductCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					MessageBox.Show("invalid Product", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				//Save a record
				//During save check for the mode
				//If in addmode then insert a record
				//else update the record in the recordset

				grdVoucherDetails.UpdateData();
				SystemVariables.gConn.BeginTransaction();

				mysql = " delete from Replacement_Products  ";
				mysql = mysql + " where prod_cd=" + mMasterProductCode.ToString() + " or ";
				mysql = mysql + " repl_prod_cd=" + mMasterProductCode.ToString();

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					if (Convert.ToString(aVoucherDetails.GetValue(cnt, conPartNo)) == txtProductCode.Text)
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show("Duplicate ICS_Item ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						grdVoucherDetails.Bookmark = cnt;
						grdVoucherDetails.Focus();
						return result;
					}

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Prod_Cd from ICS_Item where part_no='" + Convert.ToString(aVoucherDetails.GetValue(cnt, conPartNo)) + "'"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show("Error: Code not found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						return false;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReplacementProductCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}


					mysql = " select prod_cd from replacement_products ";
					mysql = mysql + " where ( prod_cd =" + mMasterProductCode.ToString();
					mysql = mysql + " and repl_prod_cd =" + mReplacementProductCode.ToString() + ")";
					mysql = mysql + " or ";
					mysql = mysql + " ( prod_cd =" + mReplacementProductCode.ToString();
					mysql = mysql + " and repl_prod_cd =" + mMasterProductCode.ToString() + ")";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show("Duplicate ICS_Item ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						grdVoucherDetails.Bookmark = cnt;
						grdVoucherDetails.Focus();
						return result;
					}

					mysql = " Insert into Replacement_Products (prod_cd, repl_prod_cd, user_cd) ";
					mysql = mysql + " Values ( ";
					mysql = mysql + Conversion.Str(mMasterProductCode);
					mysql = mysql + "," + Conversion.Str(mReplacementProductCode);
					mysql = mysql + "," + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + ")";
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

					mysql = " Insert into Replacement_Products (prod_cd, repl_prod_cd, user_cd) ";
					mysql = mysql + " Values ( ";
					mysql = mysql + Conversion.Str(mReplacementProductCode);
					mysql = mysql + "," + Conversion.Str(mMasterProductCode);
					mysql = mysql + "," + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + ")";
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				result = true;
				grdVoucherDetails.Enabled = false;
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
			int cnt = 0;
			string mysql = "";
			object mReturnValue = null;

			try
			{

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
				if (Object.Equals(pSearchValue, null) || Convert.IsDBNull(pSearchValue))
				{
					return;
				}

				mysql = " select part_no ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ", l_Prod_name" : ", a_Prod_name");
				mysql = mysql + " from ICS_Item where Prod_cd=" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtProductCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtProductName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));

				mysql = "SELECT p.Part_No, p.l_prod_name, p.a_prod_name ";
				mysql = mysql + " , rp.repl_prod_cd ";
				mysql = mysql + " , p.stock_in_hand , p.sales_rate ";
				mysql = mysql + " FROM Replacement_Products rp ";
				mysql = mysql + " INNER JOIN ICS_Item p ON rp.Repl_Prod_Cd = p.Prod_Cd ";
				mysql = mysql + " where rp.prod_cd =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				mysql = mysql + " order by p.Part_no";

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand.ExecuteReader();

				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
				aVoucherDetails.RedimXArray(new int[]{0, mMaxArray}, new int[]{0, 0});

				if (rsLocalRec.Read())
				{
					do 
					{
						aVoucherDetails.RedimXArray(new int[]{cnt, mMaxArray}, new int[]{0, 0});

						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["Part_no"]).Trim(), cnt, conPartNo);
						aVoucherDetails.SetValue(((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? Convert.ToString(rsLocalRec["l_prod_name"]).Trim() : Convert.ToString(rsLocalRec["a_prod_name"]).Trim()) + "", cnt, conProductNameColumn);
						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["stock_in_hand"]).Trim() + "", cnt, conStockInHandQty);
						aVoucherDetails.SetValue(StringsHelper.Format(rsLocalRec["sales_rate"], "###,###,##0.000"), cnt, conSalesRate);
						cnt++;
					}
					while(rsLocalRec.Read());
				}
				rsLocalRec.Close();

				AssignGridLineNumbers();

				grdVoucherDetails.Enabled = true;
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Refresh();
				grdVoucherDetails.Focus();
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

				mysql = " delete from Replacement_Products  ";
				mysql = mysql + " where prod_cd=" + ReflectionHelper.GetPrimitiveValue<string>(ReplacementProductCode) + " or ";
				mysql = mysql + " repl_prod_cd=" + ReflectionHelper.GetPrimitiveValue<string>(ReplacementProductCode);


				//If an error occurs, trap the error and dispaly a valid message
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
				return true;
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

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			DataSet rsProductList = null;
			string mysql = "";

			if (mFirstGridFocus)
			{
				mFirstGridFocus = false;
				//setting up the ICS_Item list combobox properties

				mysql = "select part_no [Product Code], ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name [Product Name]" : "a_prod_name [Product Name]");
				mysql = mysql + ", stock_in_hand, sales_rate from ICS_Item ";
				mysql = mysql + " inner join ICS_Unit on ICS_Item.base_unit_cd = ICS_Unit.unit_cd order by 1";

				rsProductList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProductList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsProductList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsProductList.Tables.Clear();
				adap.Fill(rsProductList);

				SystemGrid.DefineSystemGridCombo(cmbCommon);

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbCommon.setDataSource((msdatasrc.DataSource) rsProductList);
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				cmbCommon.DisplayColumns[0].Width = grdVoucherDetails.Splits[0].DisplayColumns[conPartNo].Width;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				cmbCommon.DisplayColumns[1].Width = grdVoucherDetails.Splits[0].DisplayColumns[conProductNameColumn].Width + 7;
				cmbCommon.DisplayColumns[2].Visible = false;
				cmbCommon.DisplayColumns[3].Visible = false;
			}
			grdVoucherDetails.Col = 1;
		}
	}
}