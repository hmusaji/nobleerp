
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmICSAdjustStock
		: System.Windows.Forms.Form
	{

		public frmICSAdjustStock()
{
InitializeComponent();
} 
 public  void frmICSAdjustStock_old()
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


		private void frmICSAdjustStock_Activated(System.Object eventSender, System.EventArgs eventArgs)
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


		private void chkIncludeAllLocations_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			if (chkIncludeAllLocations.CheckState == CheckState.Checked)
			{
				txtLocationCode.Text = "";
				txtLocationName.Text = "";
				txtLocationCode.Enabled = false;
			}
			else
			{
				txtLocationCode.Text = "";
				txtLocationName.Text = "";
				txtLocationCode.Enabled = true;
			}

		}

		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			//On Error GoTo eFoundError

			SqlDataReader rsTempRec = null;
			string mysql = "";

			int mEntryId = 0;
			int mVoucherType = 0;
			string mVoucherName = "";
			string mVoucherAddOrLess = "";
			StringBuilder mVoucherNoGeneratedString = new StringBuilder();

			int mLocatCd = 0;
			int mVoucherNo = 0;
			object mReturnValue = null;


			if (SystemProcedure2.IsItEmpty(txtTransactionDate.Value, SystemVariables.DataType.DateType))
			{
				MessageBox.Show("Invalid Transaction Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtTransactionDate.Focus();
				return;
			}

			if (SystemProcedure2.IsItEmpty(txtAsOnDate.Value, SystemVariables.DataType.DateType))
			{
				MessageBox.Show("Invalid Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtAsOnDate.Focus();
				return;
			}

			//If IsItEmpty(txtToDate.Value, DateType) Then
			//    MsgBox "Invalid Date", vbInformation
			//    txtToDate.SetFocus
			//    Exit Sub
			//End If

			if (!SystemProcedure2.ValidDateRange(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtTransactionDate.Value)))
			{
				MessageBox.Show("Invalid Date Range, Check the current financial year", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtTransactionDate.Focus();
				return;
			}

			if (!SystemProcedure2.IsItEmpty(txtVoucherType.Text, SystemVariables.DataType.NumberType))
			{
				mysql = " select voucher_type, l_voucher_name, a_voucher_name ";
				mysql = mysql + " , add_or_less from ICS_Transaction_Types ";
				mysql = mysql + " Where voucher_type = " + txtVoucherType.Text;

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					txtVoucherName.Text = "";
					MessageBox.Show("Invalid Voucher Type ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtVoucherType.Focus();
					return;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mVoucherType = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mVoucherName = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mVoucherName = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
					}
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mVoucherAddOrLess = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3));
				}
			}
			else
			{
				txtVoucherName.Text = "";
				MessageBox.Show("Invalid Voucher Type ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtVoucherType.Focus();
				return;
			}

			if (chkIncludeAllLocations.CheckState == CheckState.Unchecked)
			{
				if (!SystemProcedure2.IsItEmpty(txtLocationCode.Text, SystemVariables.DataType.NumberType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select locat_cd from SM_Location where locat_no=" + txtLocationCode.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						txtLocationName.Text = "";
						MessageBox.Show("Invalid Location ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtLocationCode.Focus();
						return;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLocatCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				else
				{
					txtLocationName.Text = "";
					MessageBox.Show("Invalid Location ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtLocationCode.Enabled = true;
					txtLocationCode.Focus();
					return;
				}
			}



			mysql = " select locat_cd, locat_no, l_locat_name ";
			mysql = mysql + " from SM_Location ";
			if (chkIncludeAllLocations.CheckState == CheckState.Unchecked)
			{
				mysql = mysql + " where locat_cd =" + mLocatCd.ToString();
			}

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{

				SystemVariables.gConn.BeginTransaction();

				//'''Get new voucher No.
				mysql = " select isnull(max(voucher_no),0) + 1 from ICS_Transaction ";
				mysql = mysql + " where voucher_type = " + mVoucherType.ToString();
				mysql = mysql + " and locat_cd = " + Convert.ToString(rsTempRec["locat_cd"]);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mVoucherNo = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					mVoucherNo = 0;
				}

				//''Insert into ICS_Transaction master table
				mysql = " insert into ICS_Transaction ( voucher_type, voucher_date, voucher_no";
				mysql = mysql + " , Comments , locat_cd, user_cd, due_date , on_hand_stock_affected ";
				mysql = mysql + " , posted_invnt , posted_gl ) ";
				mysql = mysql + " select ";
				mysql = mysql + mVoucherType.ToString();
				mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtTransactionDate.Value) + "'";
				mysql = mysql + " , " + mVoucherNo.ToString();
				mysql = mysql + " , 'Auto Adjustment of Stock done by Admin' ";
				mysql = mysql + " , " + Convert.ToString(rsTempRec["locat_cd"]);
				mysql = mysql + " , 1 ";
				mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtTransactionDate.Value) + "'";
				mysql = mysql + " , 1 ";
				mysql = mysql + " , 0,0 ";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();


				//'''Get identity value
				mysql = " select scope_identity()";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}


				//''''Insert into ICS_Transaction_Details details table
				mysql = " insert into ICS_Transaction_Details ( entry_id, prod_cd , prod_name, unit_entry_id ";
				mysql = mysql + " , reference_no, qty, base_qty , fc_rate, fc_prod_dis, fc_amount ";
				mysql = mysql + " , status ";
				if (mVoucherAddOrLess == "A")
				{
					mysql = mysql + " , add_locat_cd ";
				}
				else
				{
					mysql = mysql + " , less_locat_cd ";
				}
				mysql = mysql + " ,item_type_cd ";
				mysql = mysql + " ) ";

				mysql = mysql + " select ";
				mysql = mysql + mEntryId.ToString();
				mysql = mysql + " , f.prod_cd, p.l_prod_name ";
				mysql = mysql + " , ( select unit_entry_id from ICS_Item_Unit_Details aud ";
				mysql = mysql + " Where aud.prod_cd = f.prod_cd ";
				mysql = mysql + " and aud.alt_unit_cd = p.base_unit_cd) ";
				mysql = mysql + " , '' ";
				mysql = mysql + " , abs(sum(f.qty_in) - sum(f.qty_out)) ";
				mysql = mysql + " , abs(sum(f.qty_in) - sum(f.qty_out)) ";
				mysql = mysql + " , 0,0,0 ";
				mysql = mysql + " , 1 ";
				mysql = mysql + " , " + Convert.ToString(rsTempRec["locat_cd"]);
				mysql = mysql + " , p.item_type_cd ";
				mysql = mysql + " From";
				mysql = mysql + " (";
				mysql = mysql + " select ICS_Item.prod_cd";
				mysql = mysql + " , sum(itd.base_qty) as qty_in";
				mysql = mysql + " , 0 as qty_out";
				mysql = mysql + " from ICS_Transaction_Details itd";
				mysql = mysql + " inner join ICS_Transaction it on itd.entry_id = it.entry_id";
				mysql = mysql + " inner join ICS_Transaction_Types ivt on it.voucher_type = ivt.voucher_type";
				mysql = mysql + " inner join ICS_Item on itd.prod_cd = ICS_Item.prod_cd";
				mysql = mysql + " Where ivt.affect_on_hand_stock = 1";
				mysql = mysql + " and it.voucher_date <=  '" + ReflectionHelper.GetPrimitiveValue<string>(txtAsOnDate.Value) + "'";
				mysql = mysql + " and itd.item_type_cd in (1,3) and itd.add_locat_cd = " + Convert.ToString(rsTempRec["locat_cd"]);
				mysql = mysql + " group by ICS_Item.prod_cd";
				mysql = mysql + " union all ";
				mysql = mysql + " select ICS_Item.prod_cd";
				mysql = mysql + " , 0 as qty_in";
				mysql = mysql + " , sum(itd.base_qty) as qty_out";
				mysql = mysql + " from ICS_Transaction_Details itd";
				mysql = mysql + " inner join ICS_Transaction it on itd.entry_id = it.entry_id";
				mysql = mysql + " inner join ICS_Transaction_Types ivt on it.voucher_type = ivt.voucher_type";
				mysql = mysql + " inner join ICS_Item on itd.prod_cd = ICS_Item.prod_cd";
				mysql = mysql + " Where ivt.affect_on_hand_stock = 1";
				mysql = mysql + " and it.voucher_date <=  '" + ReflectionHelper.GetPrimitiveValue<string>(txtAsOnDate.Value) + "'";
				mysql = mysql + " and itd.item_type_cd in (1,3) and itd.less_locat_cd = " + Convert.ToString(rsTempRec["locat_cd"]);
				mysql = mysql + " group by itd.less_locat_cd, ICS_Item.prod_cd";
				mysql = mysql + " ) as f";
				mysql = mysql + " inner join ICS_Item p on f.prod_cd = p.prod_cd";
				mysql = mysql + " group by f.prod_cd, p.l_prod_name, p.item_type_cd, p.base_unit_cd ";
				mysql = mysql + " having (Sum(f.qty_in) - Sum(f.qty_out)) < 0";

				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				mysql = " select @@rowcount ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(mReturnValue)) == 0)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
				}
				else
				{
					mysql = " update ICS_Transaction ";
					mysql = mysql + " set posted_invnt = 1 ";
					mysql = mysql + " where entry_id = " + mEntryId.ToString();
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();

					mVoucherNoGeneratedString.Append(" Locat No:" + Convert.ToString(rsTempRec["locat_no"]) + ", Location Name:" + Convert.ToString(rsTempRec["l_locat_name"]) + ", Voucher No:" + mVoucherNo.ToString() + "\r");
				}

			}
			while(rsTempRec.Read());


			if (mVoucherNoGeneratedString.ToString() == "")
			{
				MessageBox.Show(" No Records Found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show(mVoucherName + " Generated Succesfully " + "\r" + mVoucherNoGeneratedString.ToString(), "Xtreme", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}


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
			this.Top = 67;
			this.Left = 33;

			txtAsOnDate.Value = DateTime.Today;
			//txtToDate.Value = Date
			txtTransactionDate.Value = DateTime.Today;

			//Call SetLabelCaption(Me)
			//If gPreferedLanguage = Arabic And GetSystemPreferenceSetting("flip_controls_in_arabic") = vbTrue Then
			//    Dim oFlipThisForm As New clsFlip
			//
			//    oFlipThisForm.SwapMe Me
			//End If

			cntMainParameter.Redraw = true;
			this.WindowState = FormWindowState.Maximized;
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

		private void txtVoucherType_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine(this.ActiveControl.Name);
		}

		private void txtVoucherType_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;

				if (!SystemProcedure2.IsItEmpty(txtVoucherType.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name" : "a_voucher_name") + "  from ICS_Transaction_Types where voucher_type = " + txtVoucherType.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtVoucherName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtVoucherName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtVoucherName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					txtVoucherType.Focus();
				}
			}
		}

		private void txtLocationCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine(this.ActiveControl.Name);
		}

		private void txtLocationCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;

				if (!SystemProcedure2.IsItEmpty(txtLocationCode.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name") + "  from SM_Location where locat_no = " + txtLocationCode.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtLocationName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLocationName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtLocationName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					txtLocationCode.Focus();
				}
			}
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtLocationCode" : 
					txtLocationCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2004000, "82,83,84,85,86")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLocationCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtLocationName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						txtLocationCode_Leave(txtLocationCode, new EventArgs());
					} 
					break;
				case "txtVoucherType" : 
					txtVoucherType.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(200, "694,696")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtVoucherType.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0));
						txtVoucherName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(1) : ((Array) mTempSearchValue).GetValue(1));
						txtVoucherType_Leave(txtVoucherType, new EventArgs());
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