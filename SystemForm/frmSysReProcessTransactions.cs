
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSysReProcessTransactions
		: System.Windows.Forms.Form
	{

		public frmSysReProcessTransactions()
{
InitializeComponent();
} 
 public  void frmSysReProcessTransactions_old()
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
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			
		}


		private void frmSysReProcessTransactions_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private clsToolbar oThisFormToolBar = null;
		private object mSearchValue = null;
		private int mThisFormID = 0;
		private string mICSVoucherCriteria = "";

		private const int conOptUnpostVoucher = 0;
		private const int conOptRepostVoucher = 1;


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


		//Private Sub btnFormToolBar_Click(Index As Integer)
		//Call ToolBarButtonClick(Me, btnFormToolBar(Index).Tag)
		//End Sub
		//
		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{

			if (!optReprocessType[conOptUnpostVoucher].Checked)
			{
				if (RepostVouchers())
				{
					this.Close();
				}
			}
			else
			{
				if (SystemProcedure2.IsItEmpty(Convert.ToString(DlblVoucherType.Tag), SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Invalid Transaction, Select a Transaction ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				if (UnPostVouchers(Convert.ToInt32(Double.Parse(Convert.ToString(DlblVoucherType.Tag)))))
				{
					this.Close();
				}
			}

		}

		private bool UnPostVouchers(int pEntryId)
		{

			bool result = false;
			string mysql = "";
			object mReturnValue = null;
			int mSequenceID = 0;
			DialogResult ans = (DialogResult) 0;

			SqlDataReader rsLocalRec = null;
			clsHourGlass myHourGlass = null;

			try
			{


				mysql = " select top 1 dt.gl_post_sequence_counter ";
				mysql = mysql + "  from  ICS_Transaction mt ";
				mysql = mysql + "  inner join ICS_Transaction_Details dt on mt.entry_id = dt.entry_id ";
				mysql = mysql + "  inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";
				mysql = mysql + "  inner join SM_Location loc on mt.locat_cd = loc.locat_cd ";
				mysql = mysql + " where mt.entry_id =" + Conversion.Str(pEntryId);
				mysql = mysql + " and " + mICSVoucherCriteria;

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSequenceID = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					MessageBox.Show(" Invalid Record, select a proper voucher ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return result;
				}


				//mReturnValue = GetMasterCode("select entry_id from Backup_ICS_Transaction where is_reposted = 0")
				//If Not IsNull(mReturnValue) Then
				//    MsgBox "Unposted transactions are already exists! " & Chr(13) & _
				//'    "Please Repost it first.", vbCritical
				//    Exit Function
				//End If

				//'''Warning Message
				ans = MessageBox.Show("Are you sure, you want to unpost the vouchers?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (ans == System.Windows.Forms.DialogResult.No)
				{
					return result;
				}

				//'''Begin Transaction
				myHourGlass = new clsHourGlass();
				SystemVariables.gConn.BeginTransaction();


				//*************************************************************************
				//'''Create a backup of Gl_post_sequence_counter column from the invnt_tran table.
				mysql = " select id from sysobjects ";
				mysql = mysql + " where name = 'ICS_Transaction_Backup_Sequence' ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mysql = " select line_no from ICS_Transaction_Backup_Sequence ";
					mysql = mysql + " where is_reposted = 0 ";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mysql = " Continuing the Process will delete the previous backup sequence. " + "\r";
						mysql = mysql + " Are you sure, you want to continue? ";
						ans = MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
						if (ans == System.Windows.Forms.DialogResult.Yes)
						{
							mysql = "update ICS_Transaction_Backup_Sequence set is_reposted = 0 where is_reposted = 1";
							SqlCommand TempCommand = null;
							TempCommand = SystemVariables.gConn.CreateCommand();
							TempCommand.CommandText = mysql;
							TempCommand.ExecuteNonQuery();

							mysql = "update ICS_Transaction_Backup set is_reposted = 0 where is_reposted = 1";
							SqlCommand TempCommand_2 = null;
							TempCommand_2 = SystemVariables.gConn.CreateCommand();
							TempCommand_2.CommandText = mysql;
							TempCommand_2.ExecuteNonQuery();
						}
						else
						{
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							return result;
						}
					}

					//mySql = " drop table ICS_Transaction_Backup_Sequence "
					//gConn.Execute mySql
				}

				mysql = "Insert into ICS_Transaction_Backup (Generation_Date, is_reposted, User_Cd)";
				mysql = mysql + " values ('" + DateTimeHelper.ToString(DateTime.Now) + "',  0, " + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();
				//*************************************************************************
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select entry_id from ICS_Transaction_Backup where is_reposted = 0"));

				mysql = " insert into ICS_Transaction_Backup_Sequence (";
				mysql = mysql + " entry_id, link_line_no, link_entry_id, gl_post_sequence_counter, is_reposted)";
				mysql = mysql + " select " + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + ", dt.line_no, dt.entry_id, dt.gl_post_sequence_counter, 0 as is_reposted ";
				mysql = mysql + " from ICS_Transaction mt ";
				mysql = mysql + " inner join ICS_Transaction_Details dt on mt.entry_id = dt.entry_id ";
				mysql = mysql + " where dt.gl_post_sequence_counter >=" + Conversion.Str(mSequenceID);
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();
				//*************************************************************************

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mysql = " select distinct mt.entry_id , mt.voucher_type ";
					mysql = mysql + " , ivt.dented_stock_generated_linked_voucher_type + '' as dented_stock_generated_linked_voucher_type ";
					mysql = mysql + " , ivt.parent_type ";
					mysql = mysql + " from ICS_Transaction mt ";
					mysql = mysql + " inner join ICS_Transaction_Details dt on mt.entry_id = dt.entry_id ";
					mysql = mysql + " inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";
					mysql = mysql + " Where dt.gl_post_sequence_counter >=" + Conversion.Str(mSequenceID);
					mysql = mysql + " and " + mICSVoucherCriteria;

					SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
					rsLocalRec = sqlCommand.ExecuteReader();
					if (rsLocalRec.Read())
					{

						DisableICSTrigger();

						do 
						{
							DeleteGLRecords(Convert.ToInt32(rsLocalRec["entry_id"]), Convert.ToInt32(rsLocalRec["voucher_type"]), Convert.ToInt32(rsLocalRec["parent_type"]));

							UnPostICSVoucher(Convert.ToInt32(rsLocalRec["entry_id"]), Convert.ToString(rsLocalRec["dented_stock_generated_linked_voucher_type"]) + "", Convert.ToInt32(rsLocalRec["parent_type"]));

						}
						while(rsLocalRec.Read());

						UpdateProductCost(mSequenceID);
						UpdateProductCurrQty(mSequenceID);
						UnPostAssemblyTransInformation();
						EnableICSTrigger();

					}
					rsLocalRec.Close();
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				MessageBox.Show(" Unposting done successfully.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);


				return true;
			}
			catch (System.Exception excep)
			{
				mysql = excep.Message;
				result = false;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();

				//''Enable the trigger on any error
				EnableICSTrigger();

				MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return result;
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
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			//Imagelist are kept on the main form and refered by their key
			//**--format & define the new toolbar
			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			oThisFormToolBar.ShowFindButton = true;
			oThisFormToolBar.ShowHelpButton = true;

			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.DisableHelpButton = true;

			this.WindowState = FormWindowState.Maximized;

			mICSVoucherCriteria = " ivt.affect_gls = 1 ";
			mICSVoucherCriteria = mICSVoucherCriteria + " and mt.posted_gl = 1 ";
			mICSVoucherCriteria = mICSVoucherCriteria + " and mt.voucher_date >='" + SystemVariables.gCurrentPeriodStarts + "'";
			//mICSVoucherCriteria = mICSVoucherCriteria & " order by gl_post_sequence_counter "

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				UserAccess = null;
				frmSysReProcessTransactions.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void findRecord()
		{

			if (optReprocessType[conOptUnpostVoucher].Checked)
			{
			}
			else
			{
				return;
			}

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2007000, "", mICSVoucherCriteria));
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

			object mReturnValue = null;
			string mysql = "";

			try
			{


				if (SystemProcedure2.IsItEmpty(pSearchValue, SystemVariables.DataType.NumberType))
				{
					return;
				}

				mysql = " select ivt.voucher_type ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "ivt.l_voucher_name" : "ivt.a_voucher_name");
				mysql = mysql + " , loc.locat_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "loc.l_locat_name" : "loc.a_locat_name");
				mysql = mysql + " , mt.voucher_no ";
				mysql = mysql + "  from  ICS_Transaction mt ";
				mysql = mysql + "  inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";
				mysql = mysql + "  inner join SM_Location loc on mt.locat_cd = loc.locat_cd ";
				mysql = mysql + " where mt.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					DlblVoucherType.Tag = ReflectionHelper.GetPrimitiveValue<string>(pSearchValue); //''EntryId
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					DlblVoucherType.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					DlblVoucherName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					DlblLocationCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					DlblLocationName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					DlblVoucherNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(4));
				}
				else
				{
					DlblVoucherType.Tag = ""; //''EntryId
					DlblVoucherType.Text = "";
					DlblVoucherName.Text = "";
					DlblLocationCode.Text = "";
					DlblLocationName.Text = "";
					DlblVoucherNo.Text = "";
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}


		}

		public void CloseForm()
		{
			this.Close();
		}

		private void DeleteGLRecords(int pEntryId, int pVoucherType, int pParentVoucherType)
		{
			string mysql = "";

			if (pParentVoucherType == 201 || pParentVoucherType == 202)
			{
				//''if its sales or sales return type then do not delete the party and sales entry and gl adjusment link
				//''only delete the cost of sales entry.

				mysql = " delete from gl_accnt_trans_details ";
				mysql = mysql + " from gl_accnt_trans_details dt ";
				mysql = mysql + " inner join gl_accnt_trans mt on dt.entry_id = mt.entry_id ";
				mysql = mysql + " where mt.linked = 1 and linked_type_flag not in (1,2) ";
				mysql = mysql + " and mt.linked_entry_id = " + pEntryId.ToString();
				mysql = mysql + " and mt.linked_type = " + pVoucherType.ToString();
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mysql = " delete from gl_accnt_trans ";
				mysql = mysql + " where linked = 1 and linked_type_flag not in (1,2) ";
				mysql = mysql + " and linked_entry_id = " + pEntryId.ToString();
				mysql = mysql + " and linked_type = " + pVoucherType.ToString();
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

			}
			else
			{
				mysql = " delete from gl_invoice_tracking ";
				mysql = mysql + " from gl_invoice_tracking git ";
				mysql = mysql + " inner join gl_accnt_trans_details dt on git.source_line_no = dt.line_no ";
				mysql = mysql + " inner join gl_accnt_trans mt on mt.entry_id = dt.entry_id ";
				mysql = mysql + " Where mt.linked = 1 ";
				mysql = mysql + " and mt.linked_entry_id = " + pEntryId.ToString();
				mysql = mysql + " and mt.linked_type = " + pVoucherType.ToString();
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				mysql = " delete from gl_invoice_tracking ";
				mysql = mysql + " from gl_invoice_tracking git ";
				mysql = mysql + " inner join gl_accnt_trans_details dt on git.against_line_no = dt.line_no ";
				mysql = mysql + " inner join gl_accnt_trans mt on mt.entry_id = dt.entry_id ";
				mysql = mysql + " where mt.linked = 1 ";
				mysql = mysql + " and mt.linked_entry_id = " + pEntryId.ToString();
				mysql = mysql + " and mt.linked_type = " + pVoucherType.ToString();
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();

				mysql = " delete from gl_accnt_trans_details ";
				mysql = mysql + " from gl_accnt_trans_details dt ";
				mysql = mysql + " inner join gl_accnt_trans mt on dt.entry_id = mt.entry_id ";
				mysql = mysql + " where mt.linked = 1 ";
				mysql = mysql + " and mt.linked_entry_id = " + pEntryId.ToString();
				mysql = mysql + " and mt.linked_type = " + pVoucherType.ToString();
				SqlCommand TempCommand_5 = null;
				TempCommand_5 = SystemVariables.gConn.CreateCommand();
				TempCommand_5.CommandText = mysql;
				TempCommand_5.ExecuteNonQuery();

				mysql = " delete from gl_accnt_trans ";
				mysql = mysql + " where linked = 1 ";
				mysql = mysql + " and linked_entry_id = " + pEntryId.ToString();
				mysql = mysql + " and linked_type = " + pVoucherType.ToString();
				SqlCommand TempCommand_6 = null;
				TempCommand_6 = SystemVariables.gConn.CreateCommand();
				TempCommand_6.CommandText = mysql;
				TempCommand_6.ExecuteNonQuery();

			}

		}

		private void UnPostICSVoucher(int pEntryId, string pDentedStockLinkedVoucherType, int pParentVoucherType)
		{

			string mysql = " update ICS_Transaction ";
			mysql = mysql + " set posted_gl = 0  ";
			mysql = mysql + " where entry_id = " + pEntryId.ToString();
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = " update ICS_Transaction ";
			mysql = mysql + " set posted_gl_inventory = 0  ";
			mysql = mysql + " where entry_id = " + pEntryId.ToString();
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

			mysql = " update ICS_Transaction ";
			mysql = mysql + " set posted_gl_expense = 0  ";
			mysql = mysql + " where entry_id = " + pEntryId.ToString();
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mysql;
			TempCommand_3.ExecuteNonQuery();

			if (pParentVoucherType != 201 && pParentVoucherType != 202)
			{
				mysql = " update ICS_Transaction ";
				mysql = mysql + " set posted_gl_party = 0  ";
				mysql = mysql + " where entry_id = " + pEntryId.ToString();
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();
			}



			//''do not post the vouchers generated by group items
			mysql = " select entry_id from ICS_Transaction_Assembly ";
			mysql = mysql + " where component_trans_entry_id =" + pEntryId.ToString();
			mysql = mysql + " or assembly_trans_entry_id =" + pEntryId.ToString();
			//mySql = mySql & " and trans_type = 5 "      '''linked group
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				mysql = " update ICS_Transaction ";
				mysql = mysql + " set status = 1 ";
				mysql = mysql + " where entry_id = " + pEntryId.ToString();
				SqlCommand TempCommand_5 = null;
				TempCommand_5 = SystemVariables.gConn.CreateCommand();
				TempCommand_5.CommandText = mysql;
				TempCommand_5.ExecuteNonQuery();
			}
			else
			{
				//Stop
			}


			//''unpost the ics_voucher_expenses
			//''In this case both the purchase/receipt and expense voucher are active
			//''Case I : parent voucher is changed.
			//''expenses allocated remains the same in the ICS_Transaction_Details. When the parent voucher
			//''is posted the expenses voucher also gets posted along with it.
			//''Case II : expense voucher is modified.
			//''expenses will be reallocated in the parent table. When the expenses voucher is posted
			//''the parent voucher is also posted along with it.

			mysql = " update ics_landed_cost ";
			mysql = mysql + " set status = 1 ";
			mysql = mysql + " where linked_entry_id =" + pEntryId.ToString();
			SqlCommand TempCommand_6 = null;
			TempCommand_6 = SystemVariables.gConn.CreateCommand();
			TempCommand_6.CommandText = mysql;
			TempCommand_6.ExecuteNonQuery();


			//''the dented voucher generated is not linked to parent voucher
			//''on posting of parent voucher a dented voucher is created, which is still active.
			//''dented voucher should be taken care manually while unposting.
			//If Not IsItEmpty(pDentedStockLinkedVoucherType, NumberType) Then
			//    DeleteDentedVoucher (pEntryId)
			//End If

		}

		private void UpdateProductCost(int pGLPostSequenceCounter)
		{

			string mysql = " update ICS_Item ";
			mysql = mysql + " set cost =";
			mysql = mysql + " (isnull(( select top 1 item_cost from ICS_Transaction_Details ";
			mysql = mysql + " where gl_post_sequence_counter < " + pGLPostSequenceCounter.ToString();
			mysql = mysql + " and prod_cd = ICS_Item.prod_cd ";
			mysql = mysql + " order by gl_post_sequence_counter desc ),0))";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = " Update ICS_Transaction_Details ";
			mysql = mysql + " set item_cost = 0 ";
			mysql = mysql + " where gl_post_sequence_counter >= " + pGLPostSequenceCounter.ToString();
			mysql = mysql + " and item_type_cd in (1,3) ";
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

			mysql = " Update ICS_Transaction_Details ";
			mysql = mysql + " set ";
			mysql = mysql + " gl_post_sequence_counter = 0 ";
			mysql = mysql + " where gl_post_sequence_counter >= " + pGLPostSequenceCounter.ToString();
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mysql;
			TempCommand_3.ExecuteNonQuery();


		}


		private void UpdateProductCurrQty(int pGLPostSequenceCounter)
		{

			string mysql = " update ICS_Item ";
			mysql = mysql + " set current_qty =";
			mysql = mysql + " (isnull(( ";
			mysql = mysql + " select sum(case when dt.add_locat_cd is not null then dt.base_qty ";
			mysql = mysql + " else (dt.base_qty * -1) end) ";
			mysql = mysql + " from ICS_Transaction_Details dt ";
			mysql = mysql + " inner join ICS_Transaction mt on dt.entry_id = mt.entry_id ";
			mysql = mysql + " inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";
			mysql = mysql + " inner join ICS_Item p on dt.prod_cd = p.prod_cd ";
			mysql = mysql + " inner join ICS_Item_Types it on p.item_type_cd = it.item_type_cd ";
			mysql = mysql + " where ";
			mysql = mysql + " dt.prod_cd = ICS_Item.prod_Cd ";
			mysql = mysql + " and ivt.affect_on_hand_stock = 1 ";
			mysql = mysql + " and mt.posted_gl = 1 ";
			mysql = mysql + " and dt.gl_post_sequence_counter <" + pGLPostSequenceCounter.ToString();
			mysql = mysql + " and ivt.locat_to_locat = 0 ";
			mysql = mysql + " and it.item_type_cd in (1, 3) ";
			mysql = mysql + " ),0)) ";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

		}

		private void DisableICSTrigger()
		{

			string mysql = " alter table ICS_Transaction disable trigger trg_update_ICS_Transaction_gl_expense_posting ";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = " alter table ICS_Transaction disable trigger trg_update_ICS_Transaction_gl_inventory_posting ";
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

			mysql = " alter table ICS_Transaction disable trigger trg_update_ICS_Transaction_gl_posting ";
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mysql;
			TempCommand_3.ExecuteNonQuery();

		}


		private void EnableICSTrigger()
		{

			string mysql = " alter table ICS_Transaction enable trigger trg_update_ICS_Transaction_gl_expense_posting ";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = " alter table ICS_Transaction enable trigger trg_update_ICS_Transaction_gl_inventory_posting ";
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

			mysql = " alter table ICS_Transaction enable trigger trg_update_ICS_Transaction_gl_posting ";
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mysql;
			TempCommand_3.ExecuteNonQuery();

		}


		private bool RepostVouchers()
		{

			bool result = false;
			DataSet rsLocalRec = null;
			DialogResult ans = (DialogResult) 0;
			clsHourGlass myHourGlass = null;

			string mysql = "";
			//Dim mVoucherType As Integer
			object mReturnValue = null;
			int mEntryId = 0;
			int mRecordsPostToGL = 0;
			int mAutoGeneratedLinkedVoucherEntryId = 0;


			try
			{

				ans = MessageBox.Show(SystemConstants.msg7, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (ans == System.Windows.Forms.DialogResult.No)
				{
					return result;
				}

				myHourGlass = new clsHourGlass();

				//mEntryID = GetMasterCode("select entry_id from ICS_Transaction_Backupwhere is_reposted = 0 ")
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select top 1 entry_id from ICS_Transaction_Backup where is_reposted = 0 order by entry_id desc "));

				mysql = " select rs.link_entry_id ";
				mysql = mysql + " , ivt.voucher_type , ivt.dented_stock_generated_linked_voucher_type ";
				mysql = mysql + " , ivt.show_dented_stock_in_details , ivt.Auto_Post_Stock_Generated_Linked_Voucher_Type ";
				mysql = mysql + " from ( ";
				mysql = mysql + " select link_entry_id, min(gl_post_sequence_counter) as x_gl_post_sequence_counter ";
				mysql = mysql + " from ICS_Transaction_Backup_Sequence ";
				mysql = mysql + " where is_reposted = 0 ";
				mysql = mysql + " and entry_id =" + Conversion.Str(mEntryId);
				mysql = mysql + " group by link_entry_id ";
				mysql = mysql + " ) as rs ";
				mysql = mysql + " inner join ICS_Transaction mt on rs.link_entry_id = mt.entry_id ";
				mysql = mysql + " inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";
				mysql = mysql + " order by x_gl_post_sequence_counter asc  ";

				SystemVariables.gConn.BeginTransaction();

				rsLocalRec = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLocalRec.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLocalRec.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLocalRec.Tables.Clear();
				adap.Fill(rsLocalRec);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLocalRec.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLocalRec.setActiveConnection(null);


				foreach (DataRow iteration_row in rsLocalRec.Tables[0].Rows)
				{

					//''''*************************************************************************
					//''''Post the auto generated linked voucher eg. Delivery note autogenerated
					//''''from sales invoice
					mysql = " select entry_id from ICS_Transaction ";
					mysql = mysql + " where linked_to_entry_id = " + Convert.ToString(iteration_row["link_entry_id"]);
					mysql = mysql + " and status = 4 ";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mAutoGeneratedLinkedVoucherEntryId = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						mAutoGeneratedLinkedVoucherEntryId = 0;
					}
					//''''*************************************************************************


					SystemICSProcedure.ApproveTransaction("ICS_Transaction", Convert.ToInt32(iteration_row["link_entry_id"]));
					//**--approve parent transaction status if current
					//**--transaction is linked
					SystemICSProcedure.ApproveParentTransaction("ICS_Transaction", Convert.ToInt32(iteration_row["link_entry_id"]));

					//**--post serialized ICS_Items
					if (!SystemICSProcedure.PostSerialItems(Convert.ToInt32(iteration_row["voucher_type"]), Convert.ToInt32(iteration_row["link_entry_id"])))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show("Serialized items posting failed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						return result;
					}

					if (!rsLocalRec.Tables[0].Rows[0].IsNull("dented_stock_generated_linked_voucher_type"))
					{
						SystemICSProcedure.GenerateDentedItemVoucher(Convert.ToInt32(iteration_row["link_entry_id"]), Convert.ToInt32(iteration_row["dented_stock_generated_linked_voucher_type"]), Convert.ToBoolean(iteration_row["show_dented_stock_in_details"]), Convert.ToBoolean(iteration_row["Auto_Post_Stock_Generated_Linked_Voucher_Type"]), false);
					}


					//mRecordsPostToICS = mRecordsPostToICS + 1
					SystemICSProcedure.PostTransactionToIcs("ICS_Transaction", Convert.ToInt32(iteration_row["link_entry_id"]));

					if (mAutoGeneratedLinkedVoucherEntryId > 0)
					{
						SystemICSProcedure.PostTransactionToIcs("ICS_Transaction", mAutoGeneratedLinkedVoucherEntryId);
					}

					//mRecordsPostToGLParty = mRecordsPostToGLParty + 1
					SystemICSProcedure.PostTransactionToGLParty("ICS_Transaction", Convert.ToInt32(iteration_row["link_entry_id"]));

					if (mAutoGeneratedLinkedVoucherEntryId > 0)
					{
						SystemICSProcedure.PostTransactionToGLParty("ICS_Transaction", mAutoGeneratedLinkedVoucherEntryId);
					}

					//mRecordsPostToGLExpense = mRecordsPostToGLExpense + 1
					SystemICSProcedure.PostTransactionToGLExpenses("ICS_Transaction", Convert.ToInt32(iteration_row["link_entry_id"]), false);

					if (mAutoGeneratedLinkedVoucherEntryId > 0)
					{
						SystemICSProcedure.PostTransactionToGLExpenses("ICS_Transaction", mAutoGeneratedLinkedVoucherEntryId);
					}

					//mRecordsPostToGLInventory = mRecordsPostToGLInventory + 1
					SystemICSProcedure.PostTransactionToGLInventory("ICS_Transaction", Convert.ToInt32(iteration_row["link_entry_id"]), false);

					if (mAutoGeneratedLinkedVoucherEntryId > 0)
					{
						SystemICSProcedure.PostTransactionToGLInventory("ICS_Transaction", mAutoGeneratedLinkedVoucherEntryId, false);
					}


					SystemICSProcedure.PostTransactionToGL("ICS_Transaction", Convert.ToInt32(iteration_row["link_entry_id"]), false);

					if (mAutoGeneratedLinkedVoucherEntryId > 0)
					{
						SystemICSProcedure.PostTransactionToGL("ICS_Transaction", mAutoGeneratedLinkedVoucherEntryId, false);
					}

					//**--post the linked assembly group vouchers
					SystemICSProcedure.PostLinkedAssemblyGroupProduct(Convert.ToInt32(iteration_row["voucher_type"]), Convert.ToInt32(iteration_row["link_entry_id"]));


					//**--post the linked assembly group vouchers
					mysql = " update ICS_Transaction_Backup_Sequence ";
					mysql = mysql + " set is_reposted = 1 ";
					mysql = mysql + " where link_entry_id =" + Convert.ToString(iteration_row["link_entry_id"]);
					mysql = mysql + " and entry_id =" + mEntryId.ToString();
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mRecordsPostToGL++;


				}

				mysql = " update ICS_Transaction_Backup";
				mysql = mysql + " set is_reposted = 1 ";
				mysql = mysql + " where entry_id =" + mEntryId.ToString();
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				mysql = "Total Posted records : " + Conversion.Str(mRecordsPostToGL);

				MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				rsLocalRec = null;

				return true;
			}
			catch (System.Exception excep)
			{
				mysql = excep.Message;
				result = false;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show("Error : Unable to post transactions " + "\r" + mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			return result;
		}

		private bool isInitializingComponent;
		private void optReprocessType_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.optReprocessType, eventSender);
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				bool mVisible = false;

				mVisible = Index == conOptUnpostVoucher;

				lblVoucherType.Visible = mVisible;
				lblLocatCode.Visible = mVisible;
				lblVoucherNo.Visible = mVisible;
				DlblVoucherType.Visible = mVisible;
				DlblLocationCode.Visible = mVisible;
				DlblVoucherNo.Visible = mVisible;
				DlblVoucherName.Visible = mVisible;
				DlblLocationName.Visible = mVisible;

				Shape2.Visible = mVisible;

			}
		}

		//Private Sub DeleteDentedVoucher(ByVal pEntryId As Long)
		//Dim mySql As String
		//Dim mReturnValue As Variant
		//
		//mySql = " select entry_id from ICS_Transaction "
		//mySql = mySql & " where linked_to_entry_id =" & pEntryId
		//mReturnValue = GetMasterCode(mySql)
		//If Not IsNull(mReturnValue) Then
		//    Call UnPostICSVoucher(CLng(mReturnValue), "")
		//
		//    mySql = " update ICS_Transaction "
		//    mySql = mySql & " set posted_invnt = 0 "
		//    mySql = mySql & " where entry_id =" & mReturnValue
		//    gConn.Execute mySql
		//
		//    mySql = " delete from ICS_Transaction_Details "
		//    mySql = mySql & " where entry_id=" & mReturnValue
		//    gConn.Execute mySql
		//
		//    mySql = " delete from ICS_Transaction "
		//    mySql = mySql & " where entry_id=" & mReturnValue
		//    gConn.Execute mySql
		//End If
		//End Sub

		private void UnPostAssemblyTransInformation()
		{
			//''this procedure will unpost the build and unbuild assembly trans information transactions
			//''it will only be unposted if both assembly and component transactions are active.

			string mysql = " Update ICS_Transaction_Assembly ";
			mysql = mysql + " Set Status = 1 ";
			mysql = mysql + " from ICS_Transaction_Assembly ati";
			mysql = mysql + " inner join ICS_Transaction mt1 on ati.assembly_trans_entry_id = mt1.entry_id";
			mysql = mysql + " inner join ICS_Transaction mt2 on ati.component_trans_entry_id = mt2.entry_id";
			mysql = mysql + " where mt1.posted_gl = 0 And mt2.posted_gl = 0";
			mysql = mysql + " and ati.status <> 1";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

		}
	}
}