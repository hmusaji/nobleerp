
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmICSAutoAdjustPhysicalStock
		: System.Windows.Forms.Form
	{

		public frmICSAutoAdjustPhysicalStock()
{
InitializeComponent();
} 
 public  void frmICSAutoAdjustPhysicalStock_old()
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


		private void frmICSAutoAdjustPhysicalStock_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//Assign the Formid for Each Form
		int mThisFormID = 0;
		//Variable for storing the searchvalue from the Find window
		object mSearchValue = null;
		//This class checks for the rights given to the user
		
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

		//Enum for checking the current form mode
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		public Control FirstFocusObject = null;
		private string mTimeStamp = "";

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


		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			//On Error GoTo eFoundError
			object mReturnValue = null;
			int mShortageVoucherNo = 0;
			int mExcessVoucherNo = 0;
			int mUnitEntryId = 0;
			int mNewEntryID = 0;
			int mTempValue = 0;
			string mErrorMsg = "";

			int cnt = 0;
			string mNegativePartNo = "";
			bool mProcess = false;

			string mPartNo = "";
			int mStockAvailable = 0;
			object mTempReturnValue = null;

			int mBatchCode = 0;
			int mLocatCode = 0;


			clsHourGlass myHourGlass = new clsHourGlass();

			txtFromVoucherNo_Leave(txtFromVoucherNo, new EventArgs());
			txtToVoucherNo_Leave(txtToVoucherNo, new EventArgs());

			if (SystemProcedure2.IsItEmpty(txtTransactionDate.Value, SystemVariables.DataType.DateType))
			{
				MessageBox.Show("Invalid Transaction Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtTransactionDate.Focus();
				return;
			}
			if (SystemProcedure2.IsItEmpty(txtFromDate.Value, SystemVariables.DataType.DateType))
			{
				MessageBox.Show("Invalid Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtFromDate.Focus();
				return;
			}

			if (SystemProcedure2.IsItEmpty(txtToDate.Value, SystemVariables.DataType.DateType))
			{
				MessageBox.Show("Invalid Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtToDate.Focus();
				return;
			}

			if (!SystemProcedure2.ValidDateRange(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtTransactionDate.Value)))
			{
				MessageBox.Show("Invalid Date Range, Check the current financial year", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtTransactionDate.Focus();
				return;
			}

			if (!SystemProcedure2.IsItEmpty(txtBatchCode.Text, SystemVariables.DataType.NumberType))
			{
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select batch_cd from ics_trans_batch where batch_no=" + txtBatchCode.Text));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					txtBatchName.Text = "";
					throw new System.Exception("-9990002");
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mBatchCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
			}
			else
			{
				txtBatchName.Text = "";
				throw new System.Exception("-9990002");
			}


			if (!SystemProcedure2.IsItEmpty(txtLocationCode.Text, SystemVariables.DataType.NumberType))
			{
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select locat_cd from SM_Location where locat_no=" + txtLocationCode.Text));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					txtLocationName.Text = "";
					throw new System.Exception("-9990002");
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLocatCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
			}
			else
			{
				txtLocationName.Text = "";
				throw new System.Exception("-9990002");
			}

			SystemVariables.gConn.BeginTransaction();


			//Shortage Stock query
			//The physical count should not be processes and it should be posted

			//mySql = " select ifs.freeze_date, ifs.freeze_no"
			//mySql = mySql & " , ICS_Item.prod_cd, ICS_Item.base_unit_cd "
			//mySql = mySql & " , " & IIf(gPreferedLanguage = English, "ICS_Item.l_prod_name", "ICS_Item.a_prod_name") & " as prod_name "
			//mySql = mySql & " , (isnull( sum(ps.base_qty),0) - ifsd.freezed_base_qty) as qty_variance "
			//mySql = mySql & " ,  ifs.entry_id, ICS_Item.item_type_cd "
			//mySql = mySql & " from ics_freeze_stock ifs "
			//mySql = mySql & " inner join ics_freeze_stock_details ifsd on ifs.entry_id = ifsd.entry_id "
			//mySql = mySql & " inner join SM_Location on ifs.locat_cd = SM_Location.locat_cd "
			//mySql = mySql & " inner join ics_trans_batch itb on ifs.batch_cd = itb.batch_cd "
			//mySql = mySql & " inner join ICS_Item on ifsd.prod_cd = ICS_Item.prod_cd "
			//mySql = mySql & " inner join ICS_Item_category pcat on ICS_Item.cat_cd = pcat.cat_cd "
			//mySql = mySql & " inner join ICS_Item_group pgroup on ICS_Item.group_cd = pgroup.group_cd "
			//mySql = mySql & " inner join ICS_Item_Types it on ICS_Item.item_type_cd = it.item_type_cd "
			//mySql = mySql & " left outer join "
			//mySql = mySql & " (select dt.prod_cd, dt.base_qty "
			//mySql = mySql & " from ICS_Transaction_Details dt "
			//mySql = mySql & " inner join ICS_Transaction mt  on mt.entry_id = dt.entry_id "
			//mySql = mySql & " inner join ICS_Item_Types it on dt.item_type_cd = it.item_type_cd "
			//mySql = mySql & " where mt.locat_cd = " & Str(mLocatCode)
			//mySql = mySql & " and mt.batch_cd = " & Str(mBatchCode)
			//mySql = mySql & " and mt.voucher_type = " & Str(icsPhysicalCountVoucher)
			//mySql = mySql & " and (mt.voucher_date >= '" & txtFromDate.Value & "'"
			//mySql = mySql & "   and mt.voucher_date <= '" & txtToDate.Value & "') "
			//mySql = mySql & " and (mt.voucher_no >= " & txtFromVoucherNo.Text
			//mySql = mySql & " and mt.voucher_no <= " & txtToVoucherNo.Text & " ) "
			//mySql = mySql & " and mt.processed = 0 "
			//mySql = mySql & " and it.affect_stock = 1 "
			//mySql = mySql & " and mt.status = 2 "
			//mySql = mySql & " ) as ps on ps.prod_cd = ifsd.prod_cd "
			//mySql = mySql & " where SM_Location.locat_cd = " & Str(mLocatCode)
			//mySql = mySql & " and itb.batch_cd = " & Str(mBatchCode)
			//mySql = mySql & " and it.affect_stock = 1 "
			//mySql = mySql & " and ifs.status = 2 "
			//mySql = mySql & " group by  ICS_Item.prod_cd, ICS_Item.base_unit_cd "
			//mySql = mySql & " , ICS_Item.l_prod_name , ICS_Item.a_prod_name, ifs.entry_id "
			//mySql = mySql & " , ifs.freeze_date, ifs.freeze_no, ifsd.freezed_base_qty, ICS_Item.item_type_cd "
			//mySql = mySql & " having (isnull( sum(ps.base_qty),0) - ifsd.freezed_base_qty) < 0"

			string mysql = " select p.l_prod_name as prod_name ";
			mysql = mysql + " , (isnull(sum(m.physical_qty),0) - isnull(sum(m.freezed_base_qty),0)) as qty_variance ";
			mysql = mysql + " , p.prod_cd, p.base_unit_cd, p.item_type_cd ";
			mysql = mysql + " from ( ";
			mysql = mysql + " select ifsd.prod_cd, ifsd.freezed_base_qty, 0 as physical_qty ";
			mysql = mysql + " from ics_freeze_stock ifs ";
			mysql = mysql + " inner join ics_freeze_stock_details ifsd on ifs.entry_id = ifsd.entry_id ";
			mysql = mysql + " where ifs.locat_cd = " + Conversion.Str(mLocatCode);
			mysql = mysql + " and ifs.batch_cd = " + Conversion.Str(mBatchCode);
			if (chkIncludeProcessed.CheckState == CheckState.Unchecked)
			{
				mysql = mysql + " and ifs.processed = 0 ";
			}
			mysql = mysql + " and ifs.status = 2 ";
			mysql = mysql + " Union all ";
			mysql = mysql + " select dt.prod_cd, 0 as freezed_base_qty, dt.base_qty as physical_qty ";
			mysql = mysql + " from ICS_Transaction_Details dt ";
			mysql = mysql + " inner join ICS_Transaction mt  on mt.entry_id = dt.entry_id ";
			mysql = mysql + " where mt.locat_cd = " + mLocatCode.ToString();
			mysql = mysql + " and mt.batch_cd = " + mBatchCode.ToString();
			mysql = mysql + " and mt.voucher_type = " + Conversion.Str(SystemICSConstants.icsPhysicalCountVoucher);
			mysql = mysql + " and (mt.voucher_date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtFromDate.Value) + "'";
			mysql = mysql + " and mt.voucher_date <= '" + ReflectionHelper.GetPrimitiveValue<string>(txtToDate.Value) + "') ";
			mysql = mysql + " and (mt.voucher_no >= " + txtFromVoucherNo.Text;
			mysql = mysql + " and mt.voucher_no <= " + txtToVoucherNo.Text + " ) ";
			if (chkIncludeProcessed.CheckState == CheckState.Unchecked)
			{
				mysql = mysql + " and mt.processed = 0 ";
			}
			mysql = mysql + " and mt.status = 2 ";
			mysql = mysql + " ) as m ";
			mysql = mysql + " inner join ICS_Item p on m.prod_cd = p.prod_cd ";
			mysql = mysql + " inner join ICS_Item_Types it on p.item_type_cd = it.item_type_cd ";
			mysql = mysql + " Where it.affect_stock = 1 ";
			mysql = mysql + " group by p.l_prod_name, p.prod_cd , p.base_unit_cd, p.item_type_cd";
			mysql = mysql + " having ((IsNull(Sum(m.physical_qty), 0) - IsNull(Sum(m.freezed_base_qty), 0))) < 0 ";

			SqlDataReader rsLocalRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			bool rsLocalRecDidRead = rsLocalRec.Read();
			if (rsLocalRecDidRead)
			{
				mProcess = true;

				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsVoucherTypes.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsVoucherTypes.MoveFirst();
				SystemVariables.rsVoucherTypes.Find("voucher_type=" + SystemICSConstants.icsShortagesInStockVoucher.ToString());

				mShortageVoucherNo = Convert.ToInt32(Double.Parse(SystemICSProcedure.GetICSVoucherNo(Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Generate_voucher_no_method"]), ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), SystemICSConstants.icsShortagesInStockVoucher.ToString())));

				mysql = "  insert into ICS_Transaction ( voucher_type, voucher_date, voucher_no,  ";
				mysql = mysql + " comments, locat_cd, user_cd, due_date";
				mysql = mysql + " , on_hand_stock_affected ";
				mysql = mysql + " , posted_invnt , posted_gl ) values ";
				mysql = mysql + " (" + SystemICSConstants.icsShortagesInStockVoucher.ToString(); //Voucher Type
				mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtTransactionDate.Value) + "'"; //Date
				mysql = mysql + " ," + Conversion.Str(mShortageVoucherNo); //Voucher no
				mysql = mysql + " ,'Auto Adjustment of Stock'"; //Comments
				mysql = mysql + " ," + mLocatCode.ToString(); //Location Code
				mysql = mysql + " ," + Conversion.Str(SystemVariables.gLoggedInUserCode); //User Code
				mysql = mysql + " , cast('" + ReflectionHelper.GetPrimitiveValue<string>(txtTransactionDate.Value) + "' as smalldatetime)";
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["affect_on_hand_stock"]))
				{
					mysql = mysql + " , 1";
				}
				else
				{
					mysql = mysql + " , 0";
				}
				mysql = mysql + " ,0,0";
				mysql = mysql + ")";

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mNewEntryID = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));

				do 
				{
					//Insert in details table for shortages.
					mysql = " select unit_entry_id from ICS_Item_Unit_Details ";
					mysql = mysql + " where prod_cd=" + Conversion.Str(rsLocalRec["prod_cd"]);
					mysql = mysql + " and alt_unit_cd =" + Conversion.Str(rsLocalRec["base_unit_cd"]);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mUnitEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));

					mysql = "insert into ICS_Transaction_Details ( entry_id, ";
					mysql = mysql + " prod_cd, prod_name, unit_entry_id ";
					mysql = mysql + " , reference_no, qty, base_qty ";
					mysql = mysql + " , fc_rate, fc_prod_dis, fc_amount ";
					mysql = mysql + " , status, less_locat_cd ,item_type_cd ) ";
					mysql = mysql + " values (";
					mysql = mysql + Conversion.Str(mNewEntryID); //Entry Id
					mysql = mysql + " ," + Conversion.Str(rsLocalRec["prod_cd"]); //Product Code
					mysql = mysql + " ,'" + Convert.ToString(rsLocalRec["prod_name"]) + "'"; //Prod Name
					mysql = mysql + " ," + Conversion.Str(mUnitEntryId); //Unit Entry Id
					mysql = mysql + " ,'Auto Generated'"; //Comments
					mysql = mysql + " ," + Conversion.Str(Math.Abs(Convert.ToDouble(rsLocalRec["qty_variance"]))); //Qty
					mysql = mysql + " ," + Conversion.Str(Math.Abs(Convert.ToDouble(rsLocalRec["qty_variance"]))); //Base Qty
					mysql = mysql + " , 0 , 0, 0 "; //Rate, discount, fc_amt
					mysql = mysql + " ,1"; //Status
					mysql = mysql + " ," + mLocatCode.ToString(); //Locat code
					mysql = mysql + " ," + Convert.ToString(rsLocalRec["item_type_cd"]); //item type cd
					mysql = mysql + " )";

					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

				}
				while(rsLocalRec.Read());


				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["auto_post_ics"]))
				{
					SystemICSProcedure.PostTransactionToIcs(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_Name"]), mNewEntryID);
				}

				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["auto_post_gl_party"]))
				{
					SystemICSProcedure.PostTransactionToGLParty("ICS_Transaction", mNewEntryID);
				}


				//'''*************************************************************************
				//Check for negative stock
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("negative_stock_check")) && Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["check_negative_stock"]))
				{
					mNegativePartNo = SystemICSProcedure.NegativeStockCheck(mNewEntryID, "less_locat_cd", ref mErrorMsg);
					if (mNegativePartNo != "")
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show(mErrorMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
			}


			//'Excess Stock query

			//mySql = " select ifs.freeze_date, ifs.freeze_no"
			//mySql = mySql & " , ICS_Item.prod_cd, ICS_Item.base_unit_cd "
			//mySql = mySql & " , " & IIf(gPreferedLanguage = English, "ICS_Item.l_prod_name", "ICS_Item.a_prod_name") & " as prod_name "
			//mySql = mySql & " , (isnull( sum(ps.base_qty),0) - ifsd.freezed_base_qty) as qty_variance "
			//mySql = mySql & " ,  ifs.entry_id, ICS_Item.item_type_cd "
			//mySql = mySql & " from ics_freeze_stock ifs "
			//mySql = mySql & " inner join ics_freeze_stock_details ifsd on ifs.entry_id = ifsd.entry_id "
			//mySql = mySql & " inner join SM_Location on ifs.locat_cd = SM_Location.locat_cd "
			//mySql = mySql & " inner join ics_trans_batch itb on ifs.batch_cd = itb.batch_cd "
			//mySql = mySql & " inner join ICS_Item on ifsd.prod_cd = ICS_Item.prod_cd "
			//mySql = mySql & " inner join ICS_Item_category pcat on ICS_Item.cat_cd = pcat.cat_cd "
			//mySql = mySql & " inner join ICS_Item_group pgroup on ICS_Item.group_cd = pgroup.group_cd "
			//mySql = mySql & " inner join ICS_Item_Types it on ICS_Item.item_type_cd = it.item_type_cd "
			//mySql = mySql & " left outer join "
			//mySql = mySql & " (select dt.prod_cd, dt.base_qty "
			//mySql = mySql & " from ICS_Transaction_Details dt "
			//mySql = mySql & " inner join ICS_Transaction mt  on mt.entry_id = dt.entry_id "
			//mySql = mySql & " inner join ICS_Item_Types it on dt.item_type_cd = it.item_type_cd "
			//mySql = mySql & " where mt.locat_cd = " & Str(mLocatCode)
			//mySql = mySql & " and mt.batch_cd = " & Str(mBatchCode)
			//mySql = mySql & " and mt.voucher_type = " & Str(icsPhysicalCountVoucher)
			//mySql = mySql & " and (mt.voucher_date >= '" & txtFromDate.Value & "'"
			//mySql = mySql & "   and mt.voucher_date <= '" & txtToDate.Value & "') "
			//mySql = mySql & " and (mt.voucher_no >= " & txtFromVoucherNo.Text
			//mySql = mySql & " and mt.voucher_no <= " & txtToVoucherNo.Text & " ) "
			//mySql = mySql & " and mt.processed = 0 "
			//mySql = mySql & " and it.affect_stock = 1 "
			//mySql = mySql & " and mt.status = 2 "
			//mySql = mySql & " ) as ps on ps.prod_cd = ifsd.prod_cd "
			//mySql = mySql & " where SM_Location.locat_cd = " & Str(mLocatCode)
			//mySql = mySql & " and itb.batch_cd = " & Str(mBatchCode)
			//mySql = mySql & " and it.affect_stock = 1 "
			//mySql = mySql & " and ifs.status = 2 "
			//mySql = mySql & " group by  ICS_Item.prod_cd, ICS_Item.base_unit_cd "
			//mySql = mySql & " , ICS_Item.l_prod_name , ICS_Item.a_prod_name, ifs.entry_id "
			//mySql = mySql & " , ifs.freeze_date, ifs.freeze_no, ifsd.freezed_base_qty, ICS_Item.item_type_cd "
			//mySql = mySql & " having (isnull( sum(ps.base_qty),0) - ifsd.freezed_base_qty) > 0"

			mysql = " select p.l_prod_name as prod_name ";
			mysql = mysql + " , (isnull(sum(m.physical_qty),0) - isnull(sum(m.freezed_base_qty),0)) as qty_variance ";
			mysql = mysql + " , p.prod_cd, p.base_unit_cd, p.item_type_cd ";
			mysql = mysql + " from ( ";
			mysql = mysql + " select ifsd.prod_cd, ifsd.freezed_base_qty, 0 as physical_qty ";
			mysql = mysql + " from ics_freeze_stock ifs ";
			mysql = mysql + " inner join ics_freeze_stock_details ifsd on ifs.entry_id = ifsd.entry_id ";
			mysql = mysql + " where ifs.locat_cd = " + Conversion.Str(mLocatCode);
			mysql = mysql + " and ifs.batch_cd = " + Conversion.Str(mBatchCode);
			if (chkIncludeProcessed.CheckState == CheckState.Unchecked)
			{
				mysql = mysql + " and ifs.processed = 0 ";
			}
			mysql = mysql + " and ifs.status = 2 ";
			mysql = mysql + " Union all ";
			mysql = mysql + " select dt.prod_cd, 0 as freezed_base_qty, dt.base_qty as physical_qty ";
			mysql = mysql + " from ICS_Transaction_Details dt ";
			mysql = mysql + " inner join ICS_Transaction mt  on mt.entry_id = dt.entry_id ";
			mysql = mysql + " where mt.locat_cd = " + mLocatCode.ToString();
			mysql = mysql + " and mt.batch_cd = " + mBatchCode.ToString();
			mysql = mysql + " and mt.voucher_type = " + Conversion.Str(SystemICSConstants.icsPhysicalCountVoucher);
			mysql = mysql + " and (mt.voucher_date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtFromDate.Value) + "'";
			mysql = mysql + " and mt.voucher_date <= '" + ReflectionHelper.GetPrimitiveValue<string>(txtToDate.Value) + "') ";
			mysql = mysql + " and (mt.voucher_no >= " + txtFromVoucherNo.Text;
			mysql = mysql + " and mt.voucher_no <= " + txtToVoucherNo.Text + " ) ";
			if (chkIncludeProcessed.CheckState == CheckState.Unchecked)
			{
				mysql = mysql + " and mt.processed = 0 ";
			}
			mysql = mysql + " and mt.status = 2 ";
			mysql = mysql + " ) as m ";
			mysql = mysql + " inner join ICS_Item p on m.prod_cd = p.prod_cd ";
			mysql = mysql + " inner join ICS_Item_Types it on p.item_type_cd = it.item_type_cd ";
			mysql = mysql + " Where it.affect_stock = 1 ";
			mysql = mysql + " group by p.l_prod_name, p.prod_cd , p.base_unit_cd, p.item_type_cd";
			mysql = mysql + " having ((IsNull(Sum(m.physical_qty), 0) - IsNull(Sum(m.freezed_base_qty), 0))) > 0 ";

			SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand_2.ExecuteReader();
			bool rsLocalRecDidRead2 = rsLocalRec.Read();
			if (rsLocalRecDidRead)
			{
				mProcess = true;

				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsVoucherTypes.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsVoucherTypes.MoveFirst();
				SystemVariables.rsVoucherTypes.Find("voucher_type=" + SystemICSConstants.icsExcessInStockVoucher.ToString());

				mExcessVoucherNo = Convert.ToInt32(Double.Parse(SystemICSProcedure.GetICSVoucherNo(Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Generate_voucher_no_method"]), mLocatCode, SystemICSConstants.icsExcessInStockVoucher.ToString())));

				mysql = "  insert into ICS_Transaction ( voucher_type, voucher_date, voucher_no,  ";
				mysql = mysql + " comments, locat_cd, user_cd, due_date ";
				mysql = mysql + " , on_hand_stock_affected ";
				mysql = mysql + " ,posted_invnt , posted_gl ) values ";
				mysql = mysql + " ( " + SystemICSConstants.icsExcessInStockVoucher.ToString(); //Voucher Type
				mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtTransactionDate.Value) + "'"; //Date
				mysql = mysql + " ," + Conversion.Str(mExcessVoucherNo); //Voucher no
				mysql = mysql + " ,'Auto Adjustment of Stock'"; //Comments
				mysql = mysql + " ," + mLocatCode.ToString(); //Location Code
				mysql = mysql + " ," + Conversion.Str(SystemVariables.gLoggedInUserCode); //User Code
				mysql = mysql + " , cast('" + ReflectionHelper.GetPrimitiveValue<string>(txtTransactionDate.Value) + "' as smalldatetime)";
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["affect_on_hand_stock"]))
				{
					mysql = mysql + " , 1";
				}
				else
				{
					mysql = mysql + " , 0";
				}
				mysql = mysql + " ,0,0 ";
				mysql = mysql + ")";

				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mNewEntryID = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));

				do 
				{
					mysql = " select unit_entry_id from ICS_Item_Unit_Details ";
					mysql = mysql + " where prod_cd=" + Conversion.Str(rsLocalRec["prod_cd"]);
					mysql = mysql + " and alt_unit_cd =" + Conversion.Str(rsLocalRec["base_unit_cd"]);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mUnitEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));

					mysql = "insert into ICS_Transaction_Details ( entry_id, ";
					mysql = mysql + " prod_cd, prod_name, unit_entry_id ";
					mysql = mysql + " , reference_no, qty, base_qty ";
					mysql = mysql + " , fc_rate, fc_prod_dis, fc_amount ";
					mysql = mysql + " , status  , add_locat_cd ,item_type_cd ) ";
					mysql = mysql + " values (  ";
					mysql = mysql + Conversion.Str(mNewEntryID); //Entry Id
					mysql = mysql + " ," + Conversion.Str(rsLocalRec["prod_cd"]); //Product Code
					mysql = mysql + " ,'" + Convert.ToString(rsLocalRec["prod_name"]) + "'"; //Prod Name
					mysql = mysql + " ," + Conversion.Str(mUnitEntryId); //Unit entry Id
					mysql = mysql + " ,'Auto Generated'"; //Comments
					mysql = mysql + " ," + Conversion.Str(Math.Abs(Convert.ToDouble(rsLocalRec["qty_variance"]))); //Qty
					mysql = mysql + " ," + Conversion.Str(Math.Abs(Convert.ToDouble(rsLocalRec["qty_variance"]))); //Base Qty
					mysql = mysql + " , 0 , 0, 0 "; //Rate, discount, fc_amt
					mysql = mysql + " ,1"; //Status
					mysql = mysql + " ," + mLocatCode.ToString(); //Locat code
					mysql = mysql + " ," + Convert.ToString(rsLocalRec["item_type_cd"]); //Item type cd
					mysql = mysql + " )";

					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();
				}
				while(rsLocalRec.Read());
			}

			if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["auto_post_ics"]))
			{
				SystemICSProcedure.PostTransactionToIcs(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_Name"]), mNewEntryID);
			}

			if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["auto_post_gl_party"]))
			{
				SystemICSProcedure.PostTransactionToGLParty("ICS_Transaction", mNewEntryID);
			}

			if (mProcess)
			{
				mysql = " update ICS_Transaction ";
				mysql = mysql + " set processed = 1 where ";
				mysql = mysql + " locat_cd = " + mLocatCode.ToString();
				mysql = mysql + " and batch_cd = " + mBatchCode.ToString();
				mysql = mysql + " and voucher_no>= " + txtFromVoucherNo.Text;
				mysql = mysql + " and voucher_no<= " + txtToVoucherNo.Text;
				mysql = mysql + " and voucher_date >='" + ReflectionHelper.GetPrimitiveValue<string>(txtFromDate.Value) + "'";
				mysql = mysql + " and voucher_date <='" + ReflectionHelper.GetPrimitiveValue<string>(txtToDate.Value) + "'";
				mysql = mysql + " and processed = 0 ";
				SqlCommand TempCommand_5 = null;
				TempCommand_5 = SystemVariables.gConn.CreateCommand();
				TempCommand_5.CommandText = mysql;
				TempCommand_5.ExecuteNonQuery();

				mysql = " update ics_freeze_stock ";
				mysql = mysql + " set processed = 1 where ";
				mysql = mysql + " locat_cd = " + mLocatCode.ToString();
				mysql = mysql + " and batch_cd = " + mBatchCode.ToString();
				//    mysql = mysql & " and voucher_no>= " & txtFromVoucherNo.Text
				//    mysql = mysql & " and voucher_no<= " & txtToVoucherNo.Text
				//    mysql = mysql & " and voucher_date >='" & txtFromDate.Value & "'"
				//    mysql = mysql & " and voucher_date <='" & txtToDate.Value & "'"
				mysql = mysql + " and processed = 0 ";
				SqlCommand TempCommand_6 = null;
				TempCommand_6 = SystemVariables.gConn.CreateCommand();
				TempCommand_6.CommandText = mysql;
				TempCommand_6.ExecuteNonQuery();

			}

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

			if (mShortageVoucherNo > 0)
			{
				mysql = " Auto Generated Shortage Voucher No is :- " + Conversion.Str(mShortageVoucherNo);
			}
			else
			{
				mysql = "";
			}
			if (mExcessVoucherNo > 0)
			{
				mysql = mysql + "\r" + " Auto Generated Excess Voucher No is :- " + Conversion.Str(mExcessVoucherNo);
			}
			if (mShortageVoucherNo <= 0 && mExcessVoucherNo <= 0)
			{
				mysql = " No Records found";
			}
			MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.Close();
			return;


			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "CmdOK", SystemConstants.msg10);
			if (mReturnErrorType == 4)
			{
				txtLocationCode.Focus();
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			this.WindowState = FormWindowState.Maximized;

			txtFromDate.Value = DateTime.Today;
			txtToDate.Value = DateTime.Today;
			txtTransactionDate.Value = DateTime.Today;

			SystemProcedure.SetLabelCaption(this);
			clsFlip oFlipThisForm = null;
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
			{
				oFlipThisForm = new clsFlip();

				oFlipThisForm.SwapMe(this);
			}

			chkIncludeProcessed.CheckState = CheckState.Unchecked;
			chkIncludeProcessed.Visible = SystemVariables.gLoggedInUserCode == SystemConstants.gDefaultAdminUserCode;


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



		private void txtBatchCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine(this.ActiveControl.Name);
		}

		private void txtBatchCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;

				if (!SystemProcedure2.IsItEmpty(txtBatchCode.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_batch_name" : "a_batch_name") + "  from ics_trans_batch where batch_no = " + txtBatchCode.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtBatchName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtBatchName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtBatchName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					txtBatchCode.Focus();
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
				case "txtBatchCode" : 
					txtBatchCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001010, "1437")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtBatchCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtBatchCode_Leave(txtBatchCode, new EventArgs());
					} 
					break;
				default:
					return;
			}

		}

		private void txtFromVoucherNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			txtFromVoucherNo.Text = StringsHelper.Format(Conversion.Val(txtFromVoucherNo.Text), "000000000000");
		}

		private void txtToVoucherNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (SystemProcedure2.IsItEmpty(Conversion.Val(txtToVoucherNo.Text), SystemVariables.DataType.NumberType))
			{
				txtToVoucherNo.Text = StringsHelper.Format(Conversion.Val(txtToVoucherNo.Text), "999999999999");
			}
			else
			{
				txtToVoucherNo.Text = StringsHelper.Format(Conversion.Val(txtToVoucherNo.Text), "000000000000");
			}
		}

		public void CloseForm()
		{
			cmdOKCancel_CancelClick(cmdOKCancel, null);
		}
	}
}