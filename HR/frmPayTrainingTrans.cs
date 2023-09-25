
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayTrainingTrans
		: System.Windows.Forms.Form
	{

		private clsAccessAllowed _UserAccess = null;
		public frmPayTrainingTrans()
{
InitializeComponent();
} 
 public  void frmPayTrainingTrans_old()
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

		public Control FirstFocusObject = null;

		private int mThisFormID = 0; //Assign the Formid for Each Form
		private clsToolbar oThisFormToolBar = null;
		private string mTimeStamp = "";
		private bool mFirstGridFocus = false;
		private DataSet _rsBillingCodeList = null;
		private DataSet rsBillingCodeList
		{
			get
			{
				if (_rsBillingCodeList is null)
				{
					_rsBillingCodeList = new DataSet();
				}
				return _rsBillingCodeList;
			}
			set
			{
				_rsBillingCodeList = value;
			}
		}

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
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private int mLastCol = 0;
		private int mLastRow = 0;
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;

		private const int grdLineNoColumn = 0;
		private const int grdEmployeeCodeColumn = 1;
		private const int grdEmployeeNameColumn = 2;
		//Private Const grdBillingTypeColumn  As Integer = 3
		//Private Const grdCurrentAmtColumn  As Integer = 4
		//Private Const grdIncrementAmtColumn As Integer = 5
		//Private Const grdTotalAmtColumn As Integer = 6
		//Private Const grdIncludeInLeave As Integer = 7
		//Private Const grdIncludeInIndemnity As Integer = 8
		//Private Const grdRemarksColumn As Integer = 9

		private const int conTxtTransactionNo = 0;
		private const int conTxtTrainingCode = 1;
		private const int conTXTVenue = 4;
		private const int conTXTDurationHrs = 5;
		private const int conTXTDurationMins = 6;
		private const int conTXTNoOfTrainers = 7;
		private const int conTXTTrainerName = 3;
		private const int conTxtComments = 2;
		private const int conCmbTrainingType = 0;
		private const int conDateTxtFromDate = 2;
		private const int conDateTXTToDate = 3;

		private const int conDlblTrainerName = 0;

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



		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					FirstFocusObject.Focus();
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				FirstFocusObject = txtCommonTextBox[conTxtTransactionNo];
				//picFormToolbar.Visible = False
				grdVoucherDetails.Visible = false;

				this.Top = 0;
				this.Left = 0;


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

				SystemProcedure.SetLabelCaption(this);


				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //setting form mode to add initially
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
				mFirstGridFocus = true;

				object[] mObjectId = new object[1];
				mObjectId[conCmbTrainingType] = 1024;
				SystemCombo.FillComboWithSystemObjects(cmbTrainingType, mObjectId);
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder);
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Employee Code", 1400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Employee Name", 2700, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing Type", 1000, False, gDisableColumnBackColor, &HB4261B, , True, "T o t a l")
				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Current Amt.", 900, False, gDisableColumnBackColor, &H295C36, dbgRight, True, , dbgRight, , , , , , , , , , True)
				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Increment Amt.", 1000, True, , &H1818B4, dbgRight, True, , dbgRight, , , , , , , , , , True)
				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Total Amt.", 900, False, gDisableColumnBackColor, &H295C36, dbgRight, True, , dbgRight, , , , , , , , , , True)
				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Include In Leave", 800, , , , dbgCenter, False, , , , , , , , , , True)
				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Include In Indemnity", 800, , , , dbgCenter, False, , , , , , , , , , True)
				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1100, True, , , , False, , , , , , , , , , , True, , 50)

				//setting voucher details grid properties
				DefineVoucherArray(0, true);
				AssignGridLineNumbers();

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				//-- end of voucher grid property setting

				txtCommonTextBox[conTxtTransactionNo].Text = SystemProcedure2.GetNewNumber("pay_training_trans", "transaction_no");

				txtCommonDate[conDateTxtFromDate].Value = DateTime.Today;
				txtCommonDate[conDateTXTToDate].Value = DateTime.Today;
				grdVoucherDetails.Visible = true;
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
				//Refresh the product recordset when F5 is pressed
				if (Shift == 0 && KeyCode == 116 && !mFirstGridFocus)
				{
					DefineMasterRecordset();
				}

				//if the user presses any control key in the voucher grid object
				//On Keydown navigate the form by using enter key
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

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				aVoucherDetails = null;
				rsBillingCodeList = null;
				UserAccess = null;
				oThisFormToolBar = null;
				frmPayTrainingTrans.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			if (grdVoucherDetails.Col == grdEmployeeCodeColumn || grdVoucherDetails.Col == grdEmployeeNameColumn)
			{
				if (grdVoucherDetails.Col == grdEmployeeCodeColumn)
				{
					grdVoucherDetails.Columns[grdEmployeeNameColumn].Value = cmbMastersList.Columns[1].Value;
				}
				else
				{
					grdVoucherDetails.Columns[grdEmployeeCodeColumn].Value = cmbMastersList.Columns[0].Value;
				}
				grdVoucherDetails.Refresh();
			}
		}


		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			//If ColIndex = grdIncrementAmtColumn Then
			//    grdVoucherDetails.Update
			//    Call CalculateTotals(CInt(grdVoucherDetails.Bookmark), ColIndex)
			//    grdVoucherDetails.Refresh
			//End If
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, object Value, object Bookmark)
		{
			//If ColIndex = grdCurrentAmtColumn Or ColIndex = grdIncrementAmtColumn Or ColIndex = grdTotalAmtColumn Then
			//    If Not IsNull(Value) Then
			//        If Val(Value) <> 0 Then
			//            Value = Format(Value, "###,###,###,###,###.000")
			//        Else
			//            Value = ""
			//        End If
			//    End If
			//End If
		}

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
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
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.PostMsg(1);
			}
		}



		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, grdLineNoColumn);
			}
		}

		private void DefineVoucherArray(int pMaximumRows, bool pClearArray = false)
		{
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
			}
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, 9}, new int[]{0, 0});
		}

		public bool saveRecord(bool pApprove = false)
		{
			bool result = false;
			object mEmployeeCode = null;
			int mTrainingCode = 0;

			int cnt = 0;

			//On Error GoTo eFoundError

			string mysql = "select training_cd";
			mysql = mysql + " from pay_training where ";
			mysql = mysql + " training_no = '" + txtCommonTextBox[conTxtTrainingCode].Text + "'";

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				MessageBox.Show("Invalid Training Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = false;
				txtCommonTextBox[conTxtTrainingCode].Focus();
				return result;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTrainingCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}

			SystemVariables.gConn.BeginTransaction();
			string mCheckTimeStamp = "";
			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				mysql = " insert into pay_training_trans ";
				mysql = mysql + " (transaction_no, training_cd, from_date, to_date, venue, no_of_trainers, duration_hrs, duration_mins";
				mysql = mysql + " , training_type_id, trainer_name, total_cost , comments, user_cd)";
				mysql = mysql + " values ( ";
				mysql = mysql + txtCommonTextBox[conTxtTransactionNo].Text;
				mysql = mysql + " , " + mTrainingCode.ToString();
				mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDateTxtFromDate].DisplayText) + "'";
				mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDateTXTToDate].DisplayText) + "'";
				mysql = mysql + " , N'" + txtCommonTextBox[conTXTVenue].Text + "'";
				mysql = mysql + " , " + txtCommonTextBox[conTXTNoOfTrainers].Text;
				mysql = mysql + " , " + txtDurationHRS.Text;
				mysql = mysql + " , " + txtDurationMins.Text;
				mysql = mysql + " , " + cmbTrainingType[conCmbTrainingType].GetItemData(cmbTrainingType[conCmbTrainingType].ListIndex).ToString();
				mysql = mysql + " , N'" + txtCommonTextBox[conTXTTrainerName].Text + "'";
				mysql = mysql + " , " + txtcost.Text;
				mysql = mysql + " , N'" + txtCommonTextBox[conTxtComments].Text + "'";
				mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
				mysql = mysql + " ) ";

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();


				mysql = " select scope_identity() ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(mReturnValue);
				}
				else
				{
					MessageBox.Show("Error : Can not proceed with save!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}
			}
			else
			{
				mysql = " select time_stamp from pay_training_trans where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
				else
				{
					MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					result = false;
					FirstFocusObject.Focus();
					return result;
				}

				if (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp))
				{
					MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					result = false;
					FirstFocusObject.Focus();
					return result;
				}

				mysql = " update pay_training_trans set ";
				mysql = mysql + " transaction_no ='" + txtCommonTextBox[conTxtTransactionNo].Text + "'";
				mysql = mysql + " , training_cd =" + mTrainingCode.ToString();
				mysql = mysql + " , from_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDateTxtFromDate].DisplayText) + "'";
				mysql = mysql + " , to_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDateTXTToDate].DisplayText) + "'";
				mysql = mysql + " , venue = N'" + txtCommonTextBox[conTXTVenue].Text + "'";
				mysql = mysql + " , no_of_trainers =" + txtCommonTextBox[conTXTNoOfTrainers].Text;
				mysql = mysql + " , duration_hrs =" + txtDurationHRS.Text;
				mysql = mysql + " , duration_mins =" + txtDurationMins.Text;
				mysql = mysql + " , training_type_id =" + cmbTrainingType[conCmbTrainingType].GetItemData(cmbTrainingType[conCmbTrainingType].ListIndex).ToString();
				mysql = mysql + " , trainer_name = N'" + txtCommonTextBox[conTXTTrainerName].Text + "'";
				mysql = mysql + " , total_cost = " + txtcost.Text;
				mysql = mysql + " , comments = N'" + txtCommonTextBox[conTxtComments].Text + "'";
				mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
				mysql = mysql + " where entry_id=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();
			}

			//''Delete from pay_salary_variation
			mysql = " delete from pay_training_details ";
			mysql = mysql + " where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mysql;
			TempCommand_3.ExecuteNonQuery();

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mysql = " select emp_cd from pay_employee where emp_no='" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdEmployeeCodeColumn)) + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show("Invalid Employee Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					grdVoucherDetails.Col = grdEmployeeCodeColumn;
					grdVoucherDetails.Bookmark = cnt;
					grdVoucherDetails.Focus();
					return false;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEmployeeCode = ReflectionHelper.GetPrimitiveValue(mReturnValue);
				}

				//   If aVoucherDetails(cnt, grdIncludeInLeave) = vbFalse Or aVoucherDetails(cnt, grdIncludeInLeave) = "" Then
				//       mIncludeInLeave = 0
				//   Else
				//       mIncludeInLeave = 1
				//   End If

				//   If aVoucherDetails(cnt, grdIncludeInIndemnity) = vbFalse Or aVoucherDetails(cnt, grdIncludeInIndemnity) = "" Then
				//       mIncludeInIndemnity = 0
				//   Else
				//       mIncludeInIndemnity = 1
				//   End If

				mysql = " insert into pay_training_details";
				mysql = mysql + " (entry_id, emp_cd)";
				mysql = mysql + " values ( ";
				mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mysql = mysql + " ," + ReflectionHelper.GetPrimitiveValue<string>(mEmployeeCode);
				mysql = mysql + ")";

				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();
			}



			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			result = true;
			FirstFocusObject.Focus();
			return result;


			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			return result;
		}

		public bool CheckDataValidity()
		{
			int cnt = 0;
			int cnt1 = 0;
			string mEmployeeCode = "";



			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtTransactionNo].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter the Voucher No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto mend;
			}

			if (!Information.IsDate(txtCommonDate[conDateTxtFromDate].Value))
			{
				MessageBox.Show("Enter From Date!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto mend;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtTrainingCode].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter the Training Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto mend;
			}

			//*-- update all the current voucher grid information in grid's internal buffer
			grdVoucherDetails.UpdateData();

			if (aVoucherDetails.GetLength(0) <= 0)
			{
				MessageBox.Show("No Employee Selected", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				grdVoucherDetails.Col = grdEmployeeCodeColumn;
				grdVoucherDetails.Focus();
				goto mend;
			}


			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdEmployeeCodeColumn), SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Invalid Employee Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					grdVoucherDetails.Col = grdEmployeeCodeColumn;
					grdVoucherDetails.Bookmark = cnt;
					grdVoucherDetails.Focus();
					goto mend;
				}

			}

			int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar2; cnt++)
			{
				mEmployeeCode = Convert.ToString(aVoucherDetails.GetValue(cnt, grdEmployeeCodeColumn));
				int tempForEndVar3 = aVoucherDetails.GetLength(0) - 1;
				for (cnt1 = cnt + 1; cnt1 <= tempForEndVar3; cnt1++)
				{
					if (mEmployeeCode == Convert.ToString(aVoucherDetails.GetValue(cnt1, grdEmployeeCodeColumn)))
					{
						MessageBox.Show("Duplicate Emolyee Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						grdVoucherDetails.Col = grdEmployeeCodeColumn;
						grdVoucherDetails.Bookmark = cnt1;
						grdVoucherDetails.Focus();
						goto mend;
					}
				}
			}




			return true;
			mend:
			return false;
		}

		public void AddRecord()
		{
			int cnt = 0;

			try
			{

				int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					grdVoucherDetails.Columns[cnt].FooterText = "";
				}

				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode

				//''''*************************************************************************
				//Set the form caption
				//Call SetFormCaption(mOldVoucherStatus, Me, stActive, CurrentFormMode, IIf(gPreferedLanguage = Arabic, "Salary Variation", "Salary Variation"))
				//''''*************************************************************************

				SystemProcedure2.ClearTextBox(this);
				SystemProcedure2.ClearDateBox(this);
				SystemProcedure2.ClearNumberBox(this);
				DefineVoucherArray(0, true);
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);

				txtCommonTextBox[conTxtTransactionNo].Text = SystemProcedure2.GetNewNumber("pay_training_trans", "transaction_no");
				mSearchValue = ""; //Change the msearchvalue to blank
				mFirstGridFocus = true;
				FirstFocusObject.Focus();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}


		}


		public void GetRecord(object pSearchValue)
		{
			//On Error GoTo eFoundError
			object mTempValue = null;
			int cnt = 0;


			string mysql = " select * from pay_training_trans where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

			DataSet localRec = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			localRec.Tables.Clear();
			adap.Fill(localRec);
			if (localRec.Tables[0].Rows.Count != 0)
			{
				//UPGRADE_WARNING: (1068) pSearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(pSearchValue);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mTimeStamp = Convert.ToString(localRec.Tables[0].Rows[0]["time_stamp"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtTransactionNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["transaction_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDate[conDateTxtFromDate].Value = localRec.Tables[0].Rows[0]["from_date"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDate[conDateTXTToDate].Value = localRec.Tables[0].Rows[0]["to_date"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTXTVenue].Text = Convert.ToString(localRec.Tables[0].Rows[0]["venue"]) + "";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTXTNoOfTrainers].Text = Convert.ToString(localRec.Tables[0].Rows[0]["no_of_trainers"]) + "";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDurationHRS.Value = StringsHelper.Format(localRec.Tables[0].Rows[0]["duration_hrs"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDurationMins.Value = StringsHelper.Format(localRec.Tables[0].Rows[0]["duration_mins"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemCombo.SearchCombo(cmbTrainingType[conCmbTrainingType], Convert.ToInt32(localRec.Tables[0].Rows[0]["training_type_id"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTXTTrainerName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["trainer_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtComments].Text = Convert.ToString(localRec.Tables[0].Rows[0]["comments"]) + "";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtcost.Value = StringsHelper.Format(localRec.Tables[0].Rows[0]["total_cost"], "###,###,##0.000");

				mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "isnull(l_training_name,'')" : "isnull(a_training_name,'')");
				mysql = mysql + " ,training_no from pay_training ";
				mysql = mysql + " where ";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " training_cd = " + Convert.ToString(localRec.Tables[0].Rows[0]["training_cd"]);

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonTextBox[conTxtTrainingCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblTrainerName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));

				//Change the form mode to edit
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;

				//Set the form caption and Get the Voucher Status
				//Call SetFormCaption(mOldVoucherStatus, frmPaySalaryVariation, .Fields("status"), CurrentFormMode, IIf(gPreferedLanguage = Arabic, "Salary Variation ", "Salary Variation "))

			}

			DefineVoucherArray(0, true);
			mysql = " select pemp.emp_no ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , pemp.l_full_name as full_name ";
			}
			else
			{
				mysql = mysql + " , pemp.a_full_name as full_name";
			}
			mysql = mysql + " from pay_training_details ptd ";
			mysql = mysql + " left outer join pay_employee pemp on ptd.emp_cd = pemp.emp_cd ";
			mysql = mysql + " where ptd.entry_id = " + Conversion.Str(pSearchValue);

			SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
			localRec.Tables.Clear();
			adap_2.Fill(localRec);
			if (localRec.Tables[0].Rows.Count != 0)
			{
				foreach (DataRow iteration_row in localRec.Tables[0].Rows)
				{
					DefineVoucherArray(cnt, false);
					aVoucherDetails.SetValue(Conversion.Str(cnt + 1).Trim(), cnt, grdLineNoColumn);
					aVoucherDetails.SetValue(iteration_row["emp_no"], cnt, grdEmployeeCodeColumn);
					aVoucherDetails.SetValue(iteration_row["full_name"], cnt, grdEmployeeNameColumn);
					cnt++;
				}
			}

			AssignGridLineNumbers();
			grdVoucherDetails.Rebind(true);
			//Call CalculateTotals(0, 0)

			FirstFocusObject.Focus();
			if (mFirstGridFocus)
			{
				grdVoucherDetails_GotFocus(grdVoucherDetails, new EventArgs());
			}
			Application.DoEvents();

			return;


			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void PrintReport()
		{
			int mEntryId = 0;

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
			}
			else
			{
				return;
			}
			SystemReports.GetCrystalReport(110013095, 2, "8147", Conversion.Str(mEntryId), false);
		}


		public void CloseForm()
		{
			this.Close();
		}

		private void grdVoucherDetails_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			//Dim Col As Integer
			//
			//Col = grdVoucherDetails.Col
			//
			//If (Col = grdIncludeInLeave Or Col = grdIncludeInIndemnity) Then
			//    If Trim(grdVoucherDetails.Columns(Col).Value) = "" Then
			//        grdVoucherDetails.Columns(Col).Value = 0
			//    End If
			//    If KeyAscii = 32 Then
			//        KeyAscii = 0
			//        grdVoucherDetails.Columns(Col).Value = Not grdVoucherDetails.Columns(Col).Value
			//        grdVoucherDetails.Update
			//        grdVoucherDetails.Refresh
			//    Else
			//        KeyAscii = 0
			//    End If
			//End If
			if (KeyAscii == 0)
			{
				eventArgs.Handled = true;
			}
			eventArgs.KeyChar = Convert.ToChar(KeyAscii);
		}



		public void IRoutine()
		{
			int mCurrentLineNo = 0;

			if (ActiveControl.Name != "grdVoucherDetails")
			{
				grdVoucherDetails.Focus();
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdVoucherDetails.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdVoucherDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[grdLineNoColumn].Value);
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), 1);
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
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
				// Call CalculateTotals(0, 0)
				grdVoucherDetails.Rebind(true);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdVoucherDetails.Col)
			{
				case grdEmployeeCodeColumn : case grdEmployeeNameColumn : 
					if (grdVoucherDetails.Col == grdEmployeeCodeColumn)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("emp_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("emp_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("full_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("full_name");
					} 
					 
					int tempForEndVar = cmbMastersList.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersList.Splits[0].DisplayColumns[cnt];
						if (cnt < 3)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == grdEmployeeCodeColumn) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdEmployeeCodeColumn].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == grdEmployeeCodeColumn) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdEmployeeNameColumn].Width;
							}
							else if (cnt == 2)
							{ 
								//.Width = grdVoucherDetails.Columns(grdBillingTypeColumn).Width
							}
							withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
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
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			switch(grdVoucherDetails.Col)
			{
				case grdEmployeeCodeColumn : 
					grdVoucherDetails.Col = grdEmployeeNameColumn; 
					break;
			}
		}



		private void DefineMasterRecordset()
		{
			string mysql = "";

			if (mFirstGridFocus)
			{
				mysql = " select emp_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_full_name as full_name" : "a_full_name as full_name");
				mysql = mysql + " from pay_employee ";
				mysql = mysql + " where status_cd not in (3,4)";
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

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7062000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			grdVoucherDetails.Columns[grdLineNoColumn].Text = (grdVoucherDetails.RowCount + 1).ToString();
			//grdVoucherDetails.Columns(grdCurrentAmtColumn).Text = 0
			//grdVoucherDetails.Columns(grdIncrementAmtColumn).Text = 0

			//''''This cause the focus to be lost from billing code for the first time when a new row is added
			//grdVoucherDetails.Update

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{
			if (MsgId == 1)
			{
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList);
			}
		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdVoucherDetails.Col > 0 && LastCol > 0 && !mFirstGridFocus)
			{
				switch(grdVoucherDetails.Col)
				{
					case grdEmployeeCodeColumn : case grdEmployeeNameColumn : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList); 
						break;
				}
			}
		}

		private void grdVoucherDetails_BeforeColEdit(object eventSender, C1.Win.C1TrueDBGrid.BeforeColEditEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int KeyAscii = (int) eventArgs.KeyChar;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			//If (ColIndex = grdIncludeInLeave Or ColIndex = grdIncludeInIndemnity) Then
			//    If aVoucherDetails(grdVoucherDetails.Bookmark, ColIndex) = "" Then
			//        aVoucherDetails(grdVoucherDetails.Bookmark, ColIndex) = 0
			//    End If
			//    If KeyAscii = 0 Or KeyAscii = 13 Or KeyAscii = 32 Then
			//        aVoucherDetails(grdVoucherDetails.Bookmark, ColIndex) = Not aVoucherDetails(grdVoucherDetails.Bookmark, ColIndex)
			//        grdVoucherDetails.Update
			//        grdVoucherDetails.Refresh
			//    End If
			//    Cancel = True
			//End If
			eventArgs.Cancel = Cancel != 0;
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			//If Col = grdIncludeInLeave Or Col = grdIncludeInIndemnity Then
			//    If aVoucherDetails(Val(Bookmark), Col) = vbTrue Then
			//        Set CellStyle.ForegroundPicture = frmSysMain.imlSystemIcons.ListImages.Item("imgChecked2").Picture
			//        CellStyle.ForegroundPicturePosition = dbgFPPictureOnly
			//    Else   'If aVoucherDetails(Val(Bookmark), Col) = vbFalse Then
			//        Set CellStyle.ForegroundPicture = frmSysMain.imlSystemIcons.ListImages.Item("imgUnchecked").Picture
			//        CellStyle.ForegroundPicturePosition = dbgFPPictureOnly
			//    End If
			//End If
		}

		private void grdVoucherDetails_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (grdVoucherDetails.PointAt(X, Y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
			{
				mLastCol = grdVoucherDetails.Col;
				mLastRow = grdVoucherDetails.Row;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.PostMsg(2);
			}
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			if (Index == conTxtTransactionNo)
			{
				GetNextNumber();
			}
			else
			{
				FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
			}
		}

		private void GetNextNumber()
		{
			txtCommonTextBox[conTxtTransactionNo].Text = SystemProcedure2.GetNewNumber("Pay_training_trans", "transaction_no");
			FirstFocusObject.Focus();
		}

		public void FindRoutine(string pObjectName)
		{
			//Dim mySql As String
			object mTempSearchValue = null;

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

			switch(mIndex)
			{
				case conTxtTrainingCode : 
					txtCommonTextBox[conTxtTrainingCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7003500, "1881")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtTrainingCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				default:
					return;
			}
		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (Index == conTxtTrainingCode)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtTrainingCode].Text, SystemVariables.DataType.StringType))
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_training_name" : "a_training_name");
						mysql = mysql + " , training_no ";
						mysql = mysql + " from pay_training pt ";
						mysql = mysql + " where ";
						mysql = mysql + " pt.training_no ='" + txtCommonTextBox[conTxtTrainingCode].Text + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtCommonTextBox[conTxtTrainingCode].Text = "";
							txtDisplayLabel[conDlblTrainerName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonTextBox[conTxtTrainingCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblTrainerName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
						}
					}
					else
					{
						txtCommonTextBox[conTxtTrainingCode].Text = "";
						txtDisplayLabel[conDlblTrainerName].Text = "";
					}

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
					txtCommonTextBox[Index].Focus();
				}
				else
				{
					//
				}
			}

		}

		//Private Sub AssignCheckBoxValueInGrid()
		//'aVoucherDetails(0, grdLineNoColumn) = 1
		//aVoucherDetails(0, grdIncludeInLeave) = 0
		//aVoucherDetails(0, grdIncludeInIndemnity) = 0
		//End Sub

		public bool deleteRecord()
		{
			bool result = false;

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 1);
				result = false;
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				return result;
			}

			SystemVariables.gConn.BeginTransaction();

			string mysql = "delete from pay_training_details where entry_id=" + Conversion.Str(mSearchValue);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = "delete from pay_training_trans where entry_id=" + Conversion.Str(mSearchValue);
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();


			return true;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			if (mReturnErrorType == 1)
			{
				return false;
			}
			else if (mReturnErrorType == 2)
			{ 
				AddRecord();
				return false;
			}
			else
			{
				return false;
			}
		}


		public bool Post()
		{
			bool result = false;
			DialogResult ans = (DialogResult) 0;
			string mysql = "";
			object mReturnValue = null;

			frmSysOnlinePosting frmTemp = frmSysOnlinePosting.CreateInstance();

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 2);
				result = false;
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				return result;
			}


			frmTemp.ShowDialog();

			//if the user clicks on OK button in the frmPost form
			//If frmTemp.mLastButtonClicked = 1 And frmTemp.mApprove = True Then
			if (frmTemp.mApprove)
			{

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					//Display this message if status is active, which will require to save the record first
					ans = MessageBox.Show(SystemConstants.msg19 + "\r" + "\r" + SystemConstants.msg7, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				}
				else
				{
					//Display this message if status is not active, which will not require to save the record first
					ans = MessageBox.Show("                         Do you want to Post the Record ?                          " + "\r" + "\r" + "\r" + " NOTE :            Yes : To post after saving. " + "\r" + "                         No : To post without saving " + "\r" + "                         Cancel : To exit without posting ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
				}

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						goto mend;
					}
				}
				else
				{
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						goto mend;
					}
					else if (ans == System.Windows.Forms.DialogResult.No)
					{ 
						if (frmTemp.mApprove)
						{
							SystemVariables.gConn.BeginTransaction();
							SystemHRProcedure.PayPostToHR("Pay_Salary_Variation", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
							SystemHRProcedure.PayApprove("Pay_Salary_Variation", ReflectionHelper.GetPrimitiveValue<int>(SearchValue), "Pay_Salary_Variation_details");

							mysql = " select emp_no from pay_employee pemp ";
							mysql = mysql + " inner join pay_salary_variation psv on pemp.emp_cd = psv.emp_cd ";
							mysql = mysql + " where psv.entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								ReGenerateEmployeePayroll(ReflectionHelper.GetPrimitiveValue<string>(mReturnValue));
							}
							else
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								return false;
							}

							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.CommitTrans();
						}
					}

					result = true;
					goto mDestroy;
				}
			}

			goto mDestroy;

			mend:
			//This goto will only come if the voucherstatus is still active
			if (CheckDataValidity())
			{
				if (saveRecord(frmTemp.mApprove))
				{
					result = true;
					goto mDestroy;
				}
			}
			result = false;

			mDestroy:
			frmTemp.Close();
			return result;
		}


		private void ReGenerateEmployeePayroll(string pEmpNo)
		{
			string mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();

			SystemHRProcedure.ClearPayroll(mGenerateDate, pEmpNo, pEmpNo);
			SystemHRProcedure.GeneratePayrollEntry(mGenerateDate, pEmpNo, pEmpNo);
			SystemHRProcedure.GenerateLeaveEntry(mGenerateDate, pEmpNo, pEmpNo);
			SystemHRProcedure.GenerateLoanEntry(mGenerateDate, pEmpNo, pEmpNo);

		}
	}
}