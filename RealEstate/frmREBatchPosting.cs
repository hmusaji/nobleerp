
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmREBatchPosting
		: System.Windows.Forms.Form
	{

		public frmREBatchPosting()
{
InitializeComponent();
} 
 public  void frmREBatchPosting_old()
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


		private void frmREBatchPosting_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		//This class checks for the rights given to the user
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

		private System.Windows.Forms.ComboBox FirstFocusObject = null;
		private int mThisFormID = 0;

		private const int conContract = 0;
		private const int conReceipt = 1;


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
			clsHourGlass clsHour = new clsHourGlass();

			FirstFocusObject = cmbTransactionType;
			this.Top = 0;
			this.Left = 0;

			SystemProcedure.SetLabelCaption(this);

			//UPGRADE_WARNING: (1068) GetRELastMonthEndDate() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempValue = ReflectionHelper.GetPrimitiveValue(SystemREProcedure.GetRELastMonthEndDate());
			if (SystemProcedure2.IsItEmpty(mTempValue, SystemVariables.DataType.DateType))
			{
				MessageBox.Show("Error: No Month End Generate History Found. Contact Your Systems Administrator", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}

			//txtFromDate.Value = CDate("01-" & MonthName(Month(mTempValue), True) & "-" & Str(Year(mTempValue)))
			txtFromDate.Value = ReflectionHelper.GetPrimitiveValue<System.DateTime>(mTempValue).AddDays(1);
			txtToDate.Value = SystemProcedure2.GetNextMonth(ReflectionHelper.GetPrimitiveValue<System.DateTime>(mTempValue));

			//**--make the form visible before all the control gets loaded
			//**--(this way system pretends to be faster in loading forms)
			this.Show();
			Application.DoEvents();
			//**-------------------------------------------------------------------------------------------

			string mySQL = "select 'Contract' as type_name , 0 as type_id ";
			mySQL = mySQL + " union ";
			mySQL = mySQL + " select 'Receipt' as type_name , 1 as type_id ";
			if (mySQL != "")
			{
				SystemCombo.FillComboWithItemData(cmbTransactionType, mySQL);
				if (cmbTransactionType.ListCount > 0)
				{
					cmbTransactionType.ListIndex = 0;
				}
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//On Keydown navigate the form by using enter key
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift);
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
				frmREBatchPosting.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void CloseForm()
		{
			this.Close();
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

		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			int mTransactionType = 0;
			string mySQL = "";
			DataSet tempRec = null;
			int mRecordPosted = 0;
			int mRecordApproved = 0;
			DialogResult ans = (DialogResult) 0;
			object mReturnValue = null;

			try
			{

				ans = MessageBox.Show(SystemConstants.msg7, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (ans == System.Windows.Forms.DialogResult.No)
				{
					return;
				}

				txtFromVoucherNo_Leave(txtFromVoucherNo, new EventArgs());
				txtToVoucherNo_Leave(txtToVoucherNo, new EventArgs());

				if (SystemProcedure2.IsItEmpty(txtFromDate.DisplayText, SystemVariables.DataType.DateType))
				{
					MessageBox.Show("Invalid From Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtFromDate.Focus();
					return;
				}

				if (SystemProcedure2.IsItEmpty(txtToDate.DisplayText, SystemVariables.DataType.DateType))
				{
					MessageBox.Show("Invalid To Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtToDate.Focus();
					return;
				}

				mTransactionType = cmbTransactionType.GetItemData(cmbTransactionType.ListIndex);

				if (cmbTransactionType.GetItemData(cmbTransactionType.ListIndex) == conContract)
				{
					PostContract();
				}
				else if (cmbTransactionType.GetItemData(cmbTransactionType.ListIndex) == conReceipt)
				{ 
					PostReceipt();
				}


				FirstFocusObject.Focus();
				//Call CloseForm
			}
			catch (System.Exception excep)
			{

				mySQL = excep.Message;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();

					MessageBox.Show("Error : Unable to post transactions " + "\r" + mySQL, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
		}

		private bool PostContract()
		{

			//**--to display the HourGlass
			bool result = false;
			clsHourGlass clsHour = new clsHourGlass();

			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			bool mPostToGLOnTransactionPosting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("post_to_gl_on_transaction_posting"));


			//UPGRADE_WARNING: (1068) GetRELastMonthEndDate() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempValue = ReflectionHelper.GetPrimitiveValue(SystemREProcedure.GetRELastMonthEndDate());
			if (SystemProcedure2.IsItEmpty(mTempValue, SystemVariables.DataType.DateType))
			{
				MessageBox.Show("Error: No Month End Generate History Found. Contact Your Systems Administrator", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return result;
			}

			DataSet rsTempRec = new DataSet();
			int cnt = 0;

			string mySQL = "select contract_cd from re_contract ";
			mySQL = mySQL + " where status = 1";
			mySQL = mySQL + " and ( starting_date >='" + ReflectionHelper.GetPrimitiveValue<string>(txtFromDate.DisplayText) + "'";
			mySQL = mySQL + " and starting_date <='" + ReflectionHelper.GetPrimitiveValue<string>(txtToDate.DisplayText) + "')";
			mySQL = mySQL + " and ( contract_no >=" + txtFromVoucherNo.Text;
			mySQL = mySQL + " and contract_no <=" + txtToVoucherNo.Text + ")";

			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsTempRec.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsTempRec.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mySQL, SystemVariables.gConn);
			rsTempRec.Tables.Clear();
			adap.Fill(rsTempRec);

			SystemVariables.gConn.BeginTransaction();
			foreach (DataRow iteration_row in rsTempRec.Tables[0].Rows)
			{
				if (!SystemREProcedure.PostREContractsStatus(ReflectionHelper.GetPrimitiveValue<System.DateTime>(mTempValue), Convert.ToInt32(iteration_row["contract_cd"])))
				{
					goto eFoundError;
				}
				else
				{
					//**--check if the transaction should be posted to gl after approval
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_re_gl_link")) && mPostToGLOnTransactionPosting)
					{
						if (!SystemREProcedure.PostREChargesToGL(ReflectionHelper.GetPrimitiveValue<System.DateTime>(mTempValue), Convert.ToInt32(iteration_row["contract_cd"]), 1))
						{
							goto eFoundError;
						}
					}
				}
				cnt++;

			}
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			MessageBox.Show("Total " + cnt.ToString().Trim() + " Contracts Posted Successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

			return true;

			eFoundError:
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			MessageBox.Show("Error: Contract Posting Failed!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}

		private bool PostReceipt()
		{
			System.DateTime mLastMonthEndDate = DateTime.FromOADate(0);

			//UPGRADE_WARNING: (1068) GetRELastMonthEndDate() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempValue = ReflectionHelper.GetPrimitiveValue(SystemREProcedure.GetRELastMonthEndDate());
			if (SystemProcedure2.IsItEmpty(mTempValue, SystemVariables.DataType.DateType))
			{
				MessageBox.Show("Error: No Month End Generate History Found. Contact Your Systems Administrator", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			else
			{
				mLastMonthEndDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(mTempValue);
			}


			SqlDataReader rsTempRec = null;
			int cnt = 0;

			string mySQL = "select entry_id from re_receipt ";
			mySQL = mySQL + " where status = 1 ";
			mySQL = mySQL + " and ( receipt_date >='" + ReflectionHelper.GetPrimitiveValue<string>(txtFromDate.DisplayText) + "'";
			mySQL = mySQL + " and receipt_date <='" + ReflectionHelper.GetPrimitiveValue<string>(txtToDate.DisplayText) + "')";
			mySQL = mySQL + " and ( receipt_no >=" + txtFromVoucherNo.Text;
			mySQL = mySQL + " and receipt_no <=" + txtToVoucherNo.Text + ")";

			SystemVariables.gConn.BeginTransaction();

			SqlCommand sqlCommand = new SqlCommand(mySQL, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_re_gl_link")))
				{
					//**--posting all the active receipts to gl
					if (!SystemREProcedure.PostREReceiptsToGL(mLastMonthEndDate, Convert.ToInt32(rsTempRec["entry_id"])))
					{
						goto eErrorFound;
					}

					if (!SystemREProcedure.PostREAdvanceReceiptsToGL(mLastMonthEndDate, Convert.ToInt32(rsTempRec["entry_id"]), false))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}
				}
				//**------------

				cnt++;

			}
			while(rsTempRec.Read());

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			MessageBox.Show("Total " + cnt.ToString().Trim() + " Receipt Posted Successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

			return true;

			eErrorFound:

			rsTempRec.Close();
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			return false;

		}
	}
}