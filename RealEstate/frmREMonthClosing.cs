
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmREMonthClosing
		: System.Windows.Forms.Form
	{

		public frmREMonthClosing()
{
InitializeComponent();
} 
 public  void frmREMonthClosing_old()
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


		private void frmREMonthClosing_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private int mThisFormID = 0;
		private System.DateTime mLastMonthEndDate = DateTime.FromOADate(0);


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
			string mySQL = "";
			object mTempValue = null;

			try
			{

				this.Top = 0;
				this.Left = 0;
				//**--make the form visible before all the control gets loaded
				//**--(this way system pretends to be faster in loading forms)
				this.Show();
				this.WindowState = FormWindowState.Maximized;
				Application.DoEvents();

				SystemProcedure.SetLabelCaption(this);


				//UPGRADE_WARNING: (1068) GetRELastMonthEndDate() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemREProcedure.GetRELastMonthEndDate());
				if (SystemProcedure2.IsItEmpty(mTempValue, SystemVariables.DataType.DateType))
				{
					MessageBox.Show("Error: No Month End Generate History Found. Contact Your Systems Administrator", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.Close();
				}
				else
				{
					mLastMonthEndDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(mTempValue);
					txtMonthEndDate.Value = SystemProcedure2.GetNextMonth(mLastMonthEndDate);
				}
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
				if (KeyCode == ((int) Keys.Escape))
				{
					CloseForm();
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
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
				frmREMonthClosing.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtOkCancel_OKClick(Object Sender, EventArgs e)
		{
			clsHourGlass clsHour = new clsHourGlass();

			DialogResult mAns = MessageBox.Show("Are you sure you want to run the month end process for this period?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (mAns == System.Windows.Forms.DialogResult.Yes)
			{
				DoMonthEndProcess();
			}
			else
			{
				return;
			}
		}

		private void txtOkCancel_CancelClick(Object Sender, EventArgs e)
		{
			this.Close();
		}

		private void DoMonthEndProcess()
		{
			string mySQL = "";
			System.DateTime mNewMonthStartDate = DateTime.FromOADate(0);
			System.DateTime mNewMonthEndDate = DateTime.FromOADate(0);
			bool mPostToGLOnTransactionPosting = false;
			DataSet rsLocalRec = null;
			try
			{

				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mPostToGLOnTransactionPosting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("post_to_gl_on_transaction_posting"));

				SystemVariables.gConn.BeginTransaction();

				//**--posting all the active contracts
				if (!SystemREProcedure.PostREContractsStatus(mLastMonthEndDate))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return;
				}
				//**-------------------------------------------------------------------

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_re_gl_link")))
				{
					//**--posting all the active charges
					if (!SystemREProcedure.PostREChargesToGL(mLastMonthEndDate))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return;
					}
				}
				//**-------------------------------------------------------------------

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_re_gl_link")))
				{
					//**--posting all the active receipts to gl
					if (!SystemREProcedure.PostREReceiptsToGL(mLastMonthEndDate))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return;
					}
					if (!SystemREProcedure.PostREAdvanceReceiptsToGL(mLastMonthEndDate, 0, false))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return;
					}
				}
				//**-------------------------------------------------------------------

				//**--release expired contract unit items
				mySQL = "select c.contract_cd";
				mySQL = mySQL + " from re_contract c ";
				mySQL = mySQL + " where c.status = 2 "; //**--posted contracts only
				mySQL = mySQL + " and c.contract_status_cd = 1 "; //**--active contracts only
				mySQL = mySQL + " and c.ending_date <= '" + StringsHelper.Format(txtMonthEndDate.Value, SystemVariables.gSystemDateFormat) + "'";
				rsLocalRec = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLocalRec.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLocalRec.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mySQL, SystemVariables.gConn);
				rsLocalRec.Tables.Clear();
				adap.Fill(rsLocalRec);
				foreach (DataRow iteration_row in rsLocalRec.Tables[0].Rows)
				{
					SystemREProcedure.ReleaseContractItemUnits(Convert.ToInt32(iteration_row["contract_cd"]));

				}
				rsLocalRec = null;
				//**-------------------------------------------------------------------

				//**--automatically renew all expired contracts
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("auto_renew_contracts_on_month_close")))
				{
					if (!SystemREProcedure.RenewContract(0, ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtMonthEndDate.Value)))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return;
					}
				}
				//**-------------------------------------------------------------------

				//**--generate charges entries for the next period
				if (!SystemREProcedure.GenerateNextPeriodRECharges(mLastMonthEndDate))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return;
				}
				//**-------------------------------------------------------------------


				//**--check if the transaction should be posted to gl after approval
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_re_gl_link")) && mPostToGLOnTransactionPosting)
				{
					if (!SystemREProcedure.PostREChargesToGL(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtMonthEndDate.Value)))
					{
						throw new Exception();
					}
				}
				//**---------------------------------------------------------------------


				//**--generate advance receipt gl effect for the next month
				//**--(please do not get confused why its being called twice;
				//**--first being called on top of this procedure to make sure
				//**--advance receipt gl effect is gone for the particular month
				//**--and second time being called to generate gl effect immediately after
				//**--next month charges generation
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_re_gl_link")) && mPostToGLOnTransactionPosting)
				{
					if (!SystemREProcedure.PostREAdvanceReceiptsToGL(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtMonthEndDate.Value), 0, false))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return;
					}
				}
				//**---------------------------------------------------------------------
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				mySQL = "Month End Process was successful for the period ending : ";
				mySQL = mySQL + StringsHelper.Format(SystemProcedure2.GetNextMonth(mLastMonthEndDate), SystemVariables.gSystemDateFormat);
				MessageBox.Show(mySQL, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

				//**--print monthly rent notice report
				//If GetSystemPreferenceSetting("print_monthly_charges_notice") = vbTrue Then
				//    If GetSystemPreferenceSetting("prompt_for_monthly_charges_print") = vbTrue Then
				//        If MsgBox("Do you want to print monthly charges Notice Slip?", vbQuestion + vbYesNo) <> vbYes Then
				//            GoTo FinishProcess
				//        End If
				//    End If
				//    '**--commenting it for the time being
				//    '**--there is some problem in caliing in the procedure here
				//    '**--currently call this report from menu option directly
				//    Call PrintMonthlyChargesSlips(mLastMonthEndDate)
				//End If
				//FinishProcess:

				this.Close();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void PrintMonthlyChargesSlips(System.DateTime pMonthEndDate)
		{
			string mySQL = "";
			object mTempValue = null;

			try
			{

				mySQL = "select isnull(min(charge_cd), 0), isnull(max(charge_cd), 0) ";
				mySQL = mySQL + " from re_charge_details ";
				mySQL = mySQL + " where to_date = '" + StringsHelper.Format(pMonthEndDate, SystemVariables.gSystemDateFormat) + "'";

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
				SystemReports.GetCrystalReport(100090100, 2, "@FromChargeCode,@ToChargeCode", ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0)).Trim() + "," + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1)).Trim(), false);
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		}
	}
}