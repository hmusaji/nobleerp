
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmICSVoucherRateVariation
		: System.Windows.Forms.Form
	{

		public frmICSVoucherRateVariation()
{
InitializeComponent();
} 
 public  void frmICSVoucherRateVariation_old()
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


		private void frmICSVoucherRateVariation_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		int mThisFormID = 0;
		object mSearchValue = null;
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


		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			//On Error GoTo eFoundError

			SqlDataReader rsTempRecDetails = null;
			string mysql = "";

			int mEntryId = 0;
			int mLdgrCd = 0;
			int mProdCd = 0;
			decimal mNewRate = 0;
			decimal mNewFcAmount = 0;

			object mReturnValue = null;
			int mTotalInvoiceEffected = 0;


			int mVoucherType = SystemICSConstants.icsSalesVoucher;

			if (SystemProcedure2.IsItEmpty(txtFromDate.Value, SystemVariables.DataType.DateType))
			{
				MessageBox.Show("Invalid From Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtFromDate.Focus();
				return;
			}

			if (SystemProcedure2.IsItEmpty(txtToDate.Value, SystemVariables.DataType.DateType))
			{
				MessageBox.Show("Invalid Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtToDate.Focus();
				return;
			}

			if (ReflectionHelper.GetPrimitiveValue<double>(txtNewRate.Value) <= 0)
			{
				MessageBox.Show(" Current Price cannot be zero ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtNewRate.Focus();
				return;
			}

			if (!SystemProcedure2.IsItEmpty(txtLedgerCd.Text, SystemVariables.DataType.StringType))
			{
				mysql = " select ldgr_cd ";
				mysql = mysql + " from gl_ledger ";
				mysql = mysql + " Where ldgr_no='" + txtLedgerCd.Text + "'";

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					txtLedgerCd.Text = "";
					MessageBox.Show("Invalid Ledger ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtLedgerCd.Focus();
					return;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLdgrCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
			}
			else
			{
				txtLedgerCd.Text = "";
				MessageBox.Show("Invalid Ledger ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtLedgerCd.Focus();
				return;
			}


			if (!SystemProcedure2.IsItEmpty(txtProductCd.Text, SystemVariables.DataType.StringType))
			{
				mysql = " select prod_cd from ICS_Item ";
				mysql = mysql + " Where part_no ='" + txtProductCd.Text + "'";

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					txtProductCd.Text = "";
					MessageBox.Show("invalid Product ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtProductCd.Focus();
					return;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mProdCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
			}
			else
			{
				txtProductCd.Text = "";
				MessageBox.Show("invalid Product ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtProductCd.Focus();
				return;
			}


			SystemVariables.gConn.BeginTransaction();

			mysql = " select distinct mt.entry_id, mt.posted_gl_party, mt.posted_invnt, mt.exchange_rate ";
			mysql = mysql + " from ICS_Transaction mt ";
			mysql = mysql + " inner join ICS_Transaction_Details dt on mt.entry_id = dt.entry_id ";
			mysql = mysql + " where mt.status = 1 ";
			mysql = mysql + " and mt.voucher_type =" + mVoucherType.ToString();
			mysql = mysql + " and mt.ldgr_cd =" + mLdgrCd.ToString();
			mysql = mysql + " and dt.prod_cd =" + mProdCd.ToString();
			mysql = mysql + " and mt.voucher_date >='" + ReflectionHelper.GetPrimitiveValue<string>(txtFromDate.Value) + "'";
			mysql = mysql + " and mt.voucher_date <='" + ReflectionHelper.GetPrimitiveValue<string>(txtToDate.Value) + "'";

			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{

				mTotalInvoiceEffected++;

				if (Convert.ToBoolean(rsTempRec["posted_gl_party"]))
				{
					mysql = " update ICS_Transaction ";
					mysql = mysql + " set posted_gl_party = 0 ";
					mysql = mysql + " where entry_id=" + Convert.ToString(rsTempRec["entry_id"]);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}

				if (Convert.ToBoolean(rsTempRec["posted_invnt"]))
				{
					mysql = " update ICS_Transaction ";
					mysql = mysql + " set posted_invnt = 0 ";
					mysql = mysql + " where entry_id=" + Convert.ToString(rsTempRec["entry_id"]);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}

				mysql = " select dt.line_no, dt.qty, dt.fc_rate, dt.fc_prod_dis, dt.fc_amount ";
				mysql = mysql + " , dt.prod_cd , dt.entry_id ";
				mysql = mysql + " , aud.unit_entry_id, aud.base_qty, aud.alt_qty ";
				mysql = mysql + " from ICS_Transaction_Details dt ";
				mysql = mysql + " inner join ICS_Item_Unit_Details aud on dt.unit_entry_id = aud.unit_entry_id ";
				mysql = mysql + " where dt.entry_id = " + Convert.ToString(rsTempRec["entry_id"]);
				mysql = mysql + " and dt.prod_cd =" + mProdCd.ToString();

				SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
				rsTempRecDetails = sqlCommand_2.ExecuteReader();
				rsTempRecDetails.Read();

				do 
				{
					//'''Convert the ICS_Unit used
					mNewRate = (decimal) ((Convert.ToDouble(rsTempRecDetails["alt_qty"]) * ReflectionHelper.GetPrimitiveValue<double>(txtNewRate.Value)) / ((double) Convert.ToDouble(rsTempRecDetails["base_qty"])));

					if (Convert.ToDouble(rsTempRecDetails["fc_prod_dis"]) > 0)
					{
						if (((((double) mNewRate) * Convert.ToDouble(rsTempRecDetails["qty"])) - Convert.ToDouble(rsTempRecDetails["fc_prod_dis"])) < 0)
						{
							mNewFcAmount = Convert.ToDecimal(rsTempRecDetails["fc_prod_dis"]);
						}
						else
						{
							mNewFcAmount = (decimal) ((((double) mNewRate) * Convert.ToDouble(rsTempRecDetails["qty"])) - Convert.ToDouble(rsTempRecDetails["fc_prod_dis"]));
						}
					}
					else
					{
						mNewFcAmount = (decimal) ((((double) mNewRate) * Convert.ToDouble(rsTempRecDetails["qty"])) - Convert.ToDouble(rsTempRecDetails["fc_prod_dis"]));
					}


					mysql = "  update ICS_Transaction_Details ";
					mysql = mysql + " set ";
					mysql = mysql + " fc_rate = " + mNewRate.ToString();
					mysql = mysql + " , fc_amount =" + mNewFcAmount.ToString();
					mysql = mysql + " where line_no = " + Convert.ToString(rsTempRecDetails["line_no"]);
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();


					//'''Insert a record in history table
					mysql = " insert into ics_trans_rate_change_history ";
					mysql = mysql + " ( line_no, entry_id, prod_cd, unit_entry_id, exchange_rate ";
					mysql = mysql + " , qty , base_qty, old_fc_rate, old_fc_prod_dis, old_fc_amount ";
					mysql = mysql + " , new_fc_rate, new_fc_prod_dis , new_fc_amount, user_cd) ";
					mysql = mysql + " values (";
					mysql = mysql + Conversion.Str(rsTempRecDetails["line_no"]);
					mysql = mysql + " ," + Conversion.Str(rsTempRecDetails["entry_id"]);
					mysql = mysql + " ," + Convert.ToString(rsTempRecDetails["prod_cd"]);
					mysql = mysql + " ," + Convert.ToString(rsTempRecDetails["unit_entry_id"]);
					mysql = mysql + " ," + Convert.ToString(rsTempRec["exchange_rate"]);
					mysql = mysql + " ," + Convert.ToString(rsTempRecDetails["qty"]);
					mysql = mysql + " ," + Convert.ToString(rsTempRecDetails["base_qty"]);
					mysql = mysql + " ," + Convert.ToString(rsTempRecDetails["fc_rate"]);
					mysql = mysql + " ," + Convert.ToString(rsTempRecDetails["fc_prod_dis"]);
					mysql = mysql + " ," + Convert.ToString(rsTempRecDetails["fc_amount"]);
					mysql = mysql + " ," + mNewRate.ToString();
					mysql = mysql + " ," + Convert.ToString(rsTempRecDetails["fc_prod_dis"]);
					mysql = mysql + " ," + mNewFcAmount.ToString();
					mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " ) ";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();

				}
				while(rsTempRecDetails.Read());

				mysql = " update ICS_Transaction ";
				mysql = mysql + " set voucher_amt_fc = ";
				mysql = mysql + " ( select sum(fc_amount) from ICS_Transaction_Details ";
				mysql = mysql + "  where entry_id =" + Convert.ToString(rsTempRec["entry_id"]) + ")";
				mysql = mysql + " where entry_id =" + Convert.ToString(rsTempRec["entry_id"]);
				SqlCommand TempCommand_5 = null;
				TempCommand_5 = SystemVariables.gConn.CreateCommand();
				TempCommand_5.CommandText = mysql;
				TempCommand_5.ExecuteNonQuery();

				if (Convert.ToDouble(rsTempRec["posted_gl_party"]) == 1)
				{
					mysql = " update ICS_Transaction ";
					mysql = mysql + " set posted_gl_party = 1 ";
					mysql = mysql + " where entry_id =" + Convert.ToString(rsTempRec["entry_id"]);
					SqlCommand TempCommand_6 = null;
					TempCommand_6 = SystemVariables.gConn.CreateCommand();
					TempCommand_6.CommandText = mysql;
					TempCommand_6.ExecuteNonQuery();
				}

				if (Convert.ToDouble(rsTempRec["posted_invnt"]) == 1)
				{
					mysql = " update ICS_Transaction ";
					mysql = mysql + " set posted_invnt = 1 ";
					mysql = mysql + " where entry_id =" + Convert.ToString(rsTempRec["entry_id"]);
					SqlCommand TempCommand_7 = null;
					TempCommand_7 = SystemVariables.gConn.CreateCommand();
					TempCommand_7.CommandText = mysql;
					TempCommand_7.ExecuteNonQuery();
				}

			}
			while(rsTempRec.Read());


			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

			MessageBox.Show(" Price Changed Successfully, Total Invoices Effected : " + Conversion.Str(mTotalInvoiceEffected), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

			return;


			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			MessageBox.Show((Double.Parse(Information.Err().Description) + Information.Err().Number).ToString(), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

			try
			{
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
			}
			catch
			{
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			this.Top = 0;
			this.Left = 0;

			txtFromDate.Value = DateTime.Today;
			txtToDate.Value = DateTime.Today;

			//Call SetLabelCaption(Me)
			//If gPreferedLanguage = Arabic And GetSystemPreferenceSetting("flip_controls_in_arabic") = vbTrue Then
			//    Dim oFlipThisForm As New clsFlip
			//
			//    oFlipThisForm.SwapMe Me
			//End If

			cntMainParameter.Redraw = true;
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{

				if (KeyCode == ((int) Keys.Return))
				{ //Return or Enter key
					SendKeys.Send("{TAB}");
					return;
				}
				else if (KeyCode == ((int) Keys.Escape))
				{  //Escape key
					SystemForms.ToolBarButtonClick(this, "Exit");
					KeyCode = 0;
				}
				else if (KeyCode == 113)
				{  //F2 key
					FindRoutine(this.ActiveControl.Name);
					KeyCode = 0;
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
				frmICSAutoAdjustPhysicalStock.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtLedgerCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine(this.ActiveControl.Name);
		}

		private void txtLedgerCd_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;

				if (!SystemProcedure2.IsItEmpty(txtLedgerCd.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name") + "  from gl_ledger where ldgr_no='" + txtLedgerCd.Text + "'"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtLedgerName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLedgerName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtLedgerName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					txtLedgerCd.Focus();
				}
			}
		}

		private void txtProductCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine(this.ActiveControl.Name);
		}

		private void txtProductCd_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";

				if (!SystemProcedure2.IsItEmpty(txtProductCd.Text, SystemVariables.DataType.StringType))
				{
					mysql = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name" : "a_prod_name");
					mysql = mysql + " , prod_cd ";
					mysql = mysql + " from ICS_Item ";
					mysql = mysql + " where ICS_Item.part_no ='" + txtProductCd.Text + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

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

						mysql = " select ";
						mysql = mysql + " isnull(pti.last_sales_rate * (saud.alt_qty/saud.base_qty),0)  as sales_rate ";
						mysql = mysql + " from ICS_Item_trans_info pti  ";
						mysql = mysql + " left join gl_ledger on pti.ldgr_cd = gl_ledger.ldgr_cd ";
						mysql = mysql + " left join ICS_Item_Unit_Details saud on pti.last_sales_unit_entry_id = saud.unit_entry_id ";
						mysql = mysql + " where ldgr_no ='" + txtLedgerCd.Text + "'";
						mysql = mysql + " and pti.prod_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCurrentRate.Value = ReflectionHelper.GetPrimitiveValue(mTempValue);
					}
				}
				else
				{
					txtProductName.Text = "";
					txtCurrentRate.Value = 0;
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					txtProductCd.Focus();
				}
			}

		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;
			string mysql = "";

			switch(pObjectName)
			{
				case "txtProductCd" : 
					txtProductCd.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001000, "28")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtProductCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						//txtProductName.Text = IIf(gPreferedLanguage = English, mTempSearchValue(2), mTempSearchValue(3))
						txtProductCd_Leave(txtProductCd, new EventArgs());
					} 
					break;
				case "txtLedgerCd" : 
					txtLedgerCd.Text = ""; 
					 
					mysql = " l.type_cd =" + SystemGLConstants.gGLCustomerVendorTypeCode.ToString(); 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mysql)); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLedgerCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtLedgerCd_Leave(txtLedgerCd, new EventArgs());
					} 
					break;
				default:
					return;
			}

		}

		public void CloseForm()
		{
			cmdOKCancel_CancelClick(cmdOKCancel, null);
		}
	}
}