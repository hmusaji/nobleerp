
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmREMaintenance
		: System.Windows.Forms.Form
	{

		public frmREMaintenance()
{
InitializeComponent();
} 
 public  void frmREMaintenance_old()
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


		private void frmREMaintenance_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		public Control FirstFocusObject = null;

		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;

		private bool mFirstGridFocus = false;
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


		private const int gccLineNoColumn = 0;
		private const int gccFromDate = 1;
		private const int gccToDate = 2;
		private const int gccAmount = 3;
		private const int gccRemarks = 4;

		private const int conTxtVoucherNo = 0;
		private const int conTxtMaintenanceNo = 1;
		private const int conTxtPropertyNo = 2;
		private const int conTXTUnitNo = 3;
		private const int conTxtComments = 4;
		private const int conTXTRefNo = 5;


		private const int conTxtNReceiptAmount = 1;

		private const int conTxtDReceiptDate = 0;
		private const int conTxtDStartingDate = 1;
		private const int conTxtDEndingDate = 2;

		private const int conDlblMaintenanceName = 0;
		private const int conDlblPropertyName = 1;

		private const int mMaxArray = 5;


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


		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, gccLineNoColumn);
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			System.DateTime mCurrentMonthDate = DateTime.FromOADate(0);
			System.DateTime mNextMonth = DateTime.FromOADate(0);

			try
			{

				FirstFocusObject = txtCommonTextBox[conTxtVoucherNo];
				mFirstGridFocus = true;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
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
				oThisFormToolBar.ShowDeleteLineButton = true;
				//.ShowPostButton = True
				//.ShowHelpButton = True
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);

				Application.DoEvents();
				this.Show();


				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2.3f, 1.4f, "&HB4D9F8", "&HB4D9F8");

				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "From Date", 1150, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "To Date", 1150, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, " T o t a l ");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);

				aVoucherDetails.RedimXArray(new int[]{0, mMaxArray}, new int[]{0, 0});
				aVoucherDetails.SetValue(1, 0, 0);


				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Enabled = true;

				//mCurrentMonthDate =
				mCurrentMonthDate = SystemProcedure2.GetNextMonth(ReflectionHelper.GetPrimitiveValue<System.DateTime>(SystemREProcedure.GetRELastMonthEndDate()));
				//DateAdd("m", 1, mCurrentMonthDate)

				if (mCurrentMonthDate.Month == DateTime.Today.Month)
				{
					txtVoucherDate.Value = DateTime.Today;
				}
				else
				{
					txtVoucherDate.Value = mCurrentMonthDate;
				}
				txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("re_maintenance", "voucher_no", 2);
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
				if (KeyCode == 13 && this.ActiveControl.Name != "grdVoucherDetails")
				{
					SendKeys.Send("{TAB}");
					return;
				}

				if (this.ActiveControl.Name.ToLower() == ("grdVoucherDetails").ToLower())
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

					//    If Shift = 0 Then
					//        If grdVoucherDetails.Col = gccReceivedAmt Or grdVoucherDetails.Col = gccChargedAmt Or grdVoucherDetails.Col = gccDiscountAmt Or grdVoucherDetails.Col = gccDueAmt Then
					//            If (KeyCode = 8) Or (KeyCode = 46) Or (KeyCode = 27) Then
					//                '
					//            ElseIf (KeyCode >= 48 And KeyCode <= 57) Or (KeyCode >= 96 And KeyCode <= 105) Or (KeyCode = 190) Or (KeyCode = 110) Then
					//                '
					//            Else
					//                KeyCode = 0
					//            End If
					//        End If
					//    End If
				}


				if (this.ActiveControl.Name != "txtCommonTextBox")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommonTextBox#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void IRoutine()
		{
			//If grdVoucherDetails.Enabled = True Then
			//    If ActiveControl.Name <> "grdVoucherDetails" Then
			//        grdVoucherDetails.SetFocus
			//    End If
			//'    If Not IsNull(grdVoucherDetails.Bookmark) Then
			//'        aContractDetails.InsertRows (grdVoucherDetails.Bookmark)
			//'        Call AssignGridLineNumbers
			//'        grdVoucherDetails.ReBind
			//'        grdVoucherDetails.SetFocus
			//'        grdVoucherDetails.Refresh
			//'    End If
			//    txtNCommon(conTxtNReceiptAmount).Value = SumReceiptAmount()
			//End If
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
			}

			CalculateTotals();
			grdVoucherDetails.Refresh();

		}


		private double CalculateTotals()
		{
			int cnt = 0;

			decimal mTotalChargeAmt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mTotalChargeAmt += ((decimal) Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, gccAmount))));
			}

			grdVoucherDetails.Columns[gccAmount].FooterText = StringsHelper.Format(Math.Round((double) mTotalChargeAmt, 2), "###,###,###,##0.000");
			txtAmount.Value = Math.Round((double) Double.Parse(StringsHelper.Format(mTotalChargeAmt, "###,###,###,##0.000")), 2);
			return Math.Round((double) Double.Parse(StringsHelper.Format(mTotalChargeAmt, "###,###,###,##0.000")), 2);
		}

		public bool saveRecord(bool pPostGl = false)
		{
			bool result = false;
			object mReturnValue = null;
			int cnt = 0;
			int mEntryID = 0;
			int mMaintenanceCd = 0;
			int mPropertyCd = 0;
			int mUnitCd = 0;
			System.DateTime mGenerateDate = DateTime.FromOADate(0);
			System.DateTime mLastMonthEndDate = DateTime.FromOADate(0);
			System.DateTime mTempDate = DateTime.FromOADate(0);
			System.DateTime mCurrentMonthLastDate = DateTime.FromOADate(0);
			string mySQL = "";

			try
			{
				//grdVoucherDetails.Update

				//mPostToGLOnTransactionPosting = GetSystemPreferenceSetting("post_to_gl_on_transaction_posting")

				//finding Maintenance Code
				mySQL = " select Maintenance_Cd from re_maintenance_type ";
				mySQL = mySQL + " where Maintenance_No ='" + txtCommonTextBox[conTxtMaintenanceNo].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Maintenance Code ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonTextBox[conTxtMaintenanceNo].Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mMaintenanceCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				//finding Property Code
				mySQL = " select Property_Cd from RE_Property ";
				mySQL = mySQL + " where Property_No ='" + txtCommonTextBox[conTxtPropertyNo].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Property Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonTextBox[conTxtPropertyNo].Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mPropertyCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				//finding Unit Code
				if (txtCommonTextBox[conTXTUnitNo].Text != "")
				{
					mySQL = " select unit_cd from RE_Property_Item_Unit_Details ";
					mySQL = mySQL + " where Unit_No ='" + txtCommonTextBox[conTXTUnitNo].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Unit Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommonTextBox[conTXTUnitNo].Focus();
						return result;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mUnitCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}

				if (CalculateTotals() != ReflectionHelper.GetPrimitiveValue<double>(txtAmount.Value))
				{
					return false;
				}

				if (!CheckDataValidity())
				{
					return false;
				}



				SystemVariables.gConn.BeginTransaction();

				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{

					mySQL = " insert into RE_Maintenance ";
					mySQL = mySQL + " (Voucher_No,Voucher_Date,Ref_No,Maintenance_Cd ";
					mySQL = mySQL + " , Property_Cd,Unit_Cd, Starting_Date, Ending_Date, Amount";
					mySQL = mySQL + " , comments, User_Cd) ";
					mySQL = mySQL + " values( ";
					mySQL = mySQL + " '" + txtCommonTextBox[conTxtVoucherNo].Text + "'";
					mySQL = mySQL + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText) + "'";
					mySQL = mySQL + " ,'" + txtCommonTextBox[conTXTRefNo].Text + "'";
					mySQL = mySQL + " ," + mMaintenanceCd.ToString();
					mySQL = mySQL + " ," + mPropertyCd.ToString();
					mySQL = mySQL + " ," + ((mUnitCd == 0) ? "null" : mUnitCd.ToString());
					mySQL = mySQL + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDate.DisplayText) + "'";
					mySQL = mySQL + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtEndDate.DisplayText) + "'";
					mySQL = mySQL + " ," + ReflectionHelper.GetPrimitiveValue<string>(txtAmount.Value);
					mySQL = mySQL + " ,N'" + txtCommonTextBox[conTxtComments].Text + "'";
					mySQL = mySQL + " ," + SystemVariables.gLoggedInUserCode.ToString();
					mySQL = mySQL + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mySQL;
					TempCommand.ExecuteNonQuery();

					mySQL = "select scope_identity()";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryID = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mySQL));

				}
				else if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{ 

					//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryID = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);

					mySQL = " update RE_Maintenance ";
					mySQL = mySQL + " set voucher_no = '" + txtCommonTextBox[conTxtVoucherNo].Text + "'";
					mySQL = mySQL + " , voucher_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText) + "'";
					mySQL = mySQL + " , ref_no = '" + txtCommonTextBox[conTXTRefNo].Text + "'";
					mySQL = mySQL + " , maintenance_cd = " + mMaintenanceCd.ToString();
					mySQL = mySQL + " , property_cd = " + mPropertyCd.ToString();
					mySQL = mySQL + " , unit_cd = " + ((mUnitCd == 0) ? "null" : mUnitCd.ToString());
					mySQL = mySQL + " , starting_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDate.DisplayText) + "'";
					mySQL = mySQL + " , ending_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtEndDate.DisplayText) + "'";
					mySQL = mySQL + " , amount = " + ReflectionHelper.GetPrimitiveValue<string>(txtAmount.Value);
					mySQL = mySQL + " , comments = N'" + txtCommonTextBox[conTxtComments].Text + "'";
					mySQL = mySQL + " where Entry_Id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mySQL;
					TempCommand_2.ExecuteNonQuery();

					mySQL = " delete from re_maintenance_details where entry_id =" + mEntryID.ToString();
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mySQL;
					TempCommand_3.ExecuteNonQuery();
				}

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					mySQL = " insert into RE_Maintenance_Details  ";
					mySQL = mySQL + " (Entry_id, from_date, to_date, amount, remarks) ";
					mySQL = mySQL + " values( ";
					mySQL = mySQL + mEntryID.ToString();
					mySQL = mySQL + " , '" + Convert.ToString(aVoucherDetails.GetValue(cnt, 1)) + "'";
					mySQL = mySQL + " , '" + Convert.ToString(aVoucherDetails.GetValue(cnt, 2)) + "'";
					mySQL = mySQL + " , " + Convert.ToString(aVoucherDetails.GetValue(cnt, 3));
					mySQL = mySQL + " , N'" + Convert.ToString(aVoucherDetails.GetValue(cnt, 4)) + "'";
					mySQL = mySQL + " )";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mySQL;
					TempCommand_4.ExecuteNonQuery();
				}


				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				return true;
			}
			catch (System.Exception excep)
			{


				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}
			return result;
		}

		public void AddRecord()
		{

			//Add a record
			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearNumberBox(this);
			SystemProcedure2.ClearDateBox(this);
			//dateCommon (conTxtDStartingDate)
			//dateCommon(conTxtDEndingDate).Value = ""

			//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			aVoucherDetails.Clear();
			aVoucherDetails.RedimXArray(new int[]{0, mMaxArray}, new int[]{0, 0});
			aVoucherDetails.SetValue(1, 0, 0);

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Enabled = true;
			txtAmount.Value = 0;

			//''''*************************************************************************
			//Set the form caption
			//Call SetFormCaption(mOldVoucherStatus, Me, stActive, CurrentFormMode, IIf(gPreferedLanguage = Arabic, "Receipt Transaction", "Receipt Transaction"))
			//''''*************************************************************************

			txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("re_maintenance", "voucher_no", 2);

			System.DateTime mCurrentMonthDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(SystemREProcedure.GetRELastMonthEndDate());
			mCurrentMonthDate = mCurrentMonthDate.AddMonths(1);

			if (mCurrentMonthDate.Month == DateTime.Today.Month)
			{
				txtVoucherDate.Value = DateTime.Today;
			}
			else
			{
				txtVoucherDate.Value = mCurrentMonthDate;
			}



			FirstFocusObject.Focus();

			return;


			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool deleteRecord()
		{
			bool result = false;

			if (MessageBox.Show("Are you sure you want to delete this record ?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
			{
				return false;
			}

			SystemVariables.gConn.BeginTransaction();

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mySQL = "delete from re_maintenance_details where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mySQL;
				TempCommand.ExecuteNonQuery();

				mySQL = "delete from re_maintenance where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mySQL;
				TempCommand_2.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Item cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();


				return true;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					result = false;
				}
				else
				{
					result = false;
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}
		//
		//Public Sub UpdateGridDetails(SearchValue)
		//Dim cnt As Integer
		//Dim mySql As String
		//Dim rsLocal As ADODB.Recordset
		//
		//cnt = 0
		//
		//mySql = " select dt.*, (cd.Receipt_Amount + cd.discount_amount) as Paid_Amount "
		//mySql = mySql & " from re_receipt mt "
		//mySql = mySql & " inner join re_receipt_details dt on mt.Entry_Id = dt.Entry_Id "
		//mySql = mySql & " inner join re_charge_details cd on dt.charge_cd = cd.charge_cd "
		//mySql = mySql & " where mt.Entry_Id = " & SearchValue
		//
		//Set rsLocal = New ADODB.Recordset
		//
		//With rsLocal
		//    .Open mySql, gConn, adOpenForwardOnly, adLockReadOnly
		//
		//    Do While Not .EOF
		//
		//        aVoucherDetails.ReDim 0, cnt, 0, mMaxArray
		//
		//        If .Fields("Is_Advance").Value = True Then
		//            aVoucherDetails(cnt, gccStatus) = "Advance"
		//        Else
		//            aVoucherDetails(cnt, gccStatus) = "Due"
		//        End If
		//
		//        aVoucherDetails(cnt, gccFromDate) = Format(.Fields("From_Date").Value, gSystemDateFormat)
		//        aVoucherDetails(cnt, gccToDate) = Format(.Fields("To_Date").Value, gSystemDateFormat)
		//        aVoucherDetails(cnt, gccChargedAmt) = .Fields("Charge_Amount").Value
		//        aVoucherDetails(cnt, gccPaidAmount) = .Fields("Paid_Amount").Value - .Fields("Receipt_Amount").Value - .Fields("discount_amount").Value
		//        aVoucherDetails(cnt, gccReceivedAmt) = .Fields("Receipt_Amount").Value
		//        aVoucherDetails(cnt, gccDiscountAmt) = .Fields("Discount_Amount").Value
		//        aVoucherDetails(cnt, gccDueAmt) = Val(aVoucherDetails(cnt, gccChargedAmt)) - Val(aVoucherDetails(cnt, gccPaidAmount)) - Val(aVoucherDetails(cnt, gccReceivedAmt)) - Val(aVoucherDetails(cnt, gccDiscountAmt))
		//        aVoucherDetails(cnt, gccRemarks) = .Fields("Comments").Value
		//
		//        cnt = cnt + 1
		//
		//        Call AssignGridLineNumbers
		//
		//        rsLocal.MoveNext
		//    Loop
		//End With
		//
		//grdVoucherDetails.Array = aVoucherDetails
		//grdVoucherDetails.ReBind
		//grdVoucherDetails.Refresh
		//
		//End Sub

		public void GetRecord(object SearchValue)
		{
			string mySQL = "";
			SqlDataReader localRec = null;
			SqlDataReader rsTempRec = null;

			try
			{

				mySQL = "select rm.entry_id, rm.voucher_no, rm.voucher_date, rm.ref_no, rm.starting_date, rm.ending_date, rm.amount, rm.comments ";
				mySQL = mySQL + ", rmt.maintenance_no, rmt.l_maintenance_name, rmt.a_maintenance_name ";
				mySQL = mySQL + " ,rp.property_no, rp.l_property_name, rp.a_property_name, rpiud.unit_no ";
				mySQL = mySQL + "from re_maintenance rm ";
				mySQL = mySQL + "left outer join re_maintenance_type rmt on rm.maintenance_cd = rmt.maintenance_cd ";
				mySQL = mySQL + "left outer join re_property rp on rm.property_cd = rp.property_cd ";
				mySQL = mySQL + "left outer join RE_Property_Item_Unit_Details rpiud on rm.unit_cd = rpiud.unit_cd ";
				mySQL = mySQL + " where rm.Entry_Id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mySQL, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				int mRow = 0;
				if (localRec.Read())
				{
					mSearchValue = localRec["Entry_Id"];

					txtCommonTextBox[conTxtVoucherNo].Text = Convert.ToString(localRec["Voucher_No"]);
					txtVoucherDate.Value = localRec["Voucher_Date"];
					txtCommonTextBox[conTXTRefNo].Text = Convert.ToString(localRec["Ref_No"]);
					txtStartDate.Value = localRec["Starting_Date"];
					txtEndDate.Value = localRec["Ending_Date"];
					txtAmount.Value = localRec["amount"];
					txtCommonTextBox[conTxtComments].Text = Convert.ToString(localRec["comments"]);
					txtCommonTextBox[conTxtMaintenanceNo].Text = Convert.ToString(localRec["maintenance_no"]);
					txtCommonTextBox[conTxtPropertyNo].Text = Convert.ToString(localRec["property_no"]);
					txtCommonTextBox[conTXTUnitNo].Text = (Convert.IsDBNull(localRec["unit_no"])) ? "" : Convert.ToString(localRec["unit_no"]);

					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						txtCommonDisplay[conDlblMaintenanceName].Text = Convert.ToString(localRec["l_maintenance_name"]);
						txtCommonDisplay[conDlblPropertyName].Text = Convert.ToString(localRec["l_property_name"]);
					}
					else
					{
						txtCommonDisplay[conDlblMaintenanceName].Text = Convert.ToString(localRec["l_maintenance_name"]);
						txtCommonDisplay[conDlblPropertyName].Text = Convert.ToString(localRec["l_property_name"]);
					}


					//'''''''''''''''''''''''''''''''''
					mRow = 0;
					//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					aVoucherDetails.Clear();
					mySQL = "select * from re_maintenance_details where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand sqlCommand_2 = new SqlCommand(mySQL, SystemVariables.gConn);
					rsTempRec = sqlCommand_2.ExecuteReader();
					rsTempRec.Read();
					do 
					{
						aVoucherDetails.RedimXArray(new int[]{mRow, mMaxArray}, new int[]{0, 0});
						aVoucherDetails.SetValue(mRow + 1, mRow, gccLineNoColumn);
						aVoucherDetails.SetValue(rsTempRec["from_date"], mRow, gccFromDate);
						aVoucherDetails.SetValue(rsTempRec["to_date"], mRow, gccToDate);
						aVoucherDetails.SetValue(rsTempRec["remarks"], mRow, gccRemarks);
						aVoucherDetails.SetValue(rsTempRec["amount"], mRow, gccAmount);
						CalculateTotals();
						mRow++;
					}
					while(rsTempRec.Read());

					grdVoucherDetails.Rebind(true);



					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;

					//Set the form caption and Get the Voucher Status
					//        Call SetFormCaption(mOldVoucherStatus, Me, .Fields("status"), CurrentFormMode, IIf(gPreferedLanguage = Arabic, "Receipt Transaction", "Receipt Transaction"))
				}

				Application.DoEvents();

				CalculateTotals();

				localRec.Close();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9018100));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool CheckDataValidity()
		{
			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 3);
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
			}
			else
			{


				if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtPropertyNo].Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Select Valid Property Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txtCommonTextBox[conTxtPropertyNo].Focus();
				}
				else
				{

					if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtMaintenanceNo].Text, SystemVariables.DataType.StringType))
					{
						MessageBox.Show("Select Valid Maintenance Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						txtCommonTextBox[conTxtMaintenanceNo].Focus();
					}
					else
					{


						if (!Information.IsDate(txtStartDate.Text))
						{
							MessageBox.Show("You have to enter the Start Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							txtStartDate.Focus();
						}
						else
						{

							if (!Information.IsDate(txtEndDate.Text))
							{
								MessageBox.Show("You have to enter the Start Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								txtEndDate.Focus();
							}
							else
							{


								if (ReflectionHelper.GetPrimitiveValue<double>(txtAmount.Value) <= 0)
								{
									MessageBox.Show("Please enter the Amount", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
									txtAmount.Focus();
								}
								else
								{

									//Call CalculateTotals



									return true;

								}
							}
						}
					}
				}
			}

			return false;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

			UserAccess = null;
			oThisFormToolBar = null;
			frmREMaintenance.DefInstance = null;
		}

		public void FindRoutine(string pObjectName)
		{

			object mTempSearchValue = null;
			//Dim mContract_Cd_Value As Long
			string mySQL = "";

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mObjectIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

			if (mObjectName == "txtCommonTextBox")
			{
				txtCommonTextBox[mObjectIndex].Text = "";
				switch(mObjectIndex)
				{
					case conTxtMaintenanceNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9006000, "1345")); 
						break;
					case conTxtPropertyNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9001000, "1323")); 
						break;
					case conTXTUnitNo : 
						if (txtCommonTextBox[conTxtPropertyNo].Text != "")
						{
							mySQL = " rep.property_no ='" + txtCommonTextBox[conTxtPropertyNo].Text + "' ";
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9017000, "1411", mySQL));
						}
						else
						{
							return;
						} 
						break;
					default:
						return;
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[mObjectIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtCommonTextBox_Leave(txtCommonTextBox[mObjectIndex], new EventArgs());
				}
			}
		}


		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			grdVoucherDetails.UpdateData();


			CalculateTotals();
			grdVoucherDetails.Refresh();

		}

		private void grdVoucherDetails_BeforeColUpdate(object eventSender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			object OldValue = eventArgs.OldValue;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			//CalculateTotals
			eventArgs.Cancel = Cancel != 0;
		}

		private void txtAmount_Leave(Object eventSender, EventArgs eventArgs)
		{
			LoadGridVoucher();
		}

		public bool LoadGridVoucher()
		{
			System.DateTime mNextDate = DateTime.FromOADate(0);
			double mAmountPerDay = 0;
			int mNumberOfdays = 0;

			if (!Information.IsDate(txtStartDate.Value) || !Information.IsDate(txtEndDate.Value))
			{
				MessageBox.Show("Invalid Start Date or End Date input !", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtStartDate.Focus();
				return false;
			}
			//UPGRADE_WARNING: (1068) txtStartDate.Value of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			System.DateTime mDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtStartDate.Value);
			//UPGRADE_WARNING: (1068) txtStartDate.Value of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			System.DateTime mStartDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtStartDate.Value);
			//UPGRADE_WARNING: (1068) txtEndDate.Value of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			System.DateTime mEndDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtEndDate.Value);
			if (ReflectionHelper.IsGreaterThan(txtStartDate.Value, txtEndDate.Value))
			{
				MessageBox.Show("Start Date should be greater than End Date ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtStartDate.Focus();
				return false;
			}
			else
			{
				mNumberOfdays = ((int) DateAndTime.DateDiff("d", ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtStartDate.Value), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtEndDate.Value), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) + 1;
			}

			if (ReflectionHelper.GetPrimitiveValue<double>(txtAmount.Value) <= 0)
			{
				MessageBox.Show("Invalid Amount input ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtAmount.Focus();
				return false;
			}
			else
			{
				mAmountPerDay = ReflectionHelper.GetPrimitiveValue<double>(txtAmount.Value) / ((double) mNumberOfdays);
			}

			int mRow = 0;
			//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			aVoucherDetails.Clear();

			while(!(mDate > mEndDate))
			{
				aVoucherDetails.RedimXArray(new int[]{mRow, mMaxArray}, new int[]{0, 0});
				if (DateAndTime.Day(mDate) == 1)
				{
					mNextDate = mDate.AddMonths(1).AddDays(-1);
				}
				else
				{
					mNextDate = DateTime.Parse(SystemProcedure.GetMonthDays(mDate).ToString() + "-" + mDate.Month.ToString() + "-" + mDate.Year.ToString());
				}
				if (mNextDate >= mEndDate)
				{
					mNextDate = mEndDate;
				}
				aVoucherDetails.SetValue(mRow + 1, mRow, gccLineNoColumn);
				aVoucherDetails.SetValue(mDate, mRow, gccFromDate);
				aVoucherDetails.SetValue(mNextDate, mRow, gccToDate);
				mNumberOfdays = ((int) DateAndTime.DateDiff("d", mDate, mNextDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) + 1;
				aVoucherDetails.SetValue(StringsHelper.Format(mNumberOfdays * mAmountPerDay, "####.000"), mRow, gccAmount);
				mDate = mNextDate.AddDays(1);
				CalculateTotals();
				mRow++;
			};

			grdVoucherDetails.Rebind(true);
			return true;

		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			DataSet rsTempRec = null;
			object mTempValue = null;
			string mySQL = "";
			int mLinkedTextBoxIndex = 0;

			try
			{
				switch(Index)
				{
					case conTxtMaintenanceNo : 
						mySQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_maintenance_name " : " a_maintenance_name "); 
						mySQL = mySQL + " from re_maintenance_type rmt where maintenance_no ='" + txtCommonTextBox[Index].Text + "'"; 
						mLinkedTextBoxIndex = conDlblMaintenanceName; 
						break;
					case conTxtPropertyNo : 
						mySQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_property_name " : " a_property_name "); 
						mySQL = mySQL + " from re_property where property_no ='" + txtCommonTextBox[Index].Text + "'"; 
						mLinkedTextBoxIndex = conDlblPropertyName; 
						//Call GetContractItems 
						//Exit Sub 
						break;
					default:
						return;
				}

				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[Index].Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtCommonDisplay[mLinkedTextBoxIndex].Text = "";
						txtCommonTextBox[Index].Tag = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//        If Index = conTXTContractNo Then
						//            txtCommonDisplay(conDlblTenantNo).Text = mTempValue(0)
						//            txtCommonDisplay(conDlblTenantName).Text = IIf(gPreferedLanguage = English, mTempValue(1), mTempValue(2))
						//
						//            txtCommonDisplay(conDlblContractAmt).Text = Format(mTempValue(3), "###,###,###,##0.000")
						//
						//            txtCommonDisplay(conDlblPayMethodNo).Text = mTempValue(4)
						//            txtCommonDisplay(conDlblPayMethodName).Text = IIf(gPreferedLanguage = English, mTempValue(5), mTempValue(6))
						//
						//            txtCommonDisplay(conDlblContractUnitNo).Text = mTempValue(7)
						//            dateCommon(conTxtDStartingDate).Value = mTempValue(8)
						//            dateCommon(conTxtDEndingDate).Value = mTempValue(9)
						//            txtCommonDisplay(conDlblStatusNo).Text = mTempValue(10)
						//            txtCommonDisplay(conDlblStatusName).Text = IIf(gPreferedLanguage = English, mTempValue(11), mTempValue(12))
						//
						//            Set rsTempRec = New ADODB.Recordset
						//            mySql = " select piud.unit_no "
						//            mySql = mySql & " from re_property_item_unit_details piud "
						//            mySql = mySql & " inner join re_contract_details cd on piud.unit_cd = cd.unit_cd "
						//            mySql = mySql & " where cd.contract_cd = " & mTempValue(13)
						//            rsTempRec.Open mySql, gConn, adOpenStatic, adLockReadOnly
						//
						//            txtCommonDisplay(conDlblContractUnitNo).Text = rsTempRec.GetString(adClipString, , , ",", "")
						//            rsTempRec.Close
						//            Set rsTempRec = Nothing
						//
						//            txtCommonTextBox(Index).Enabled = False
						//        Else
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonDisplay[mLinkedTextBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);

						//        End If

					}
				}
				else
				{
					txtCommonDisplay[mLinkedTextBoxIndex].Text = "";
					txtCommonTextBox[Index].Tag = "";
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
						txtCommonTextBox[Index].Focus();
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


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, object Value, object Bookmark)
		{
			//On Error Resume Next
			//
			//Select Case ColIndex
			//    Case gccChargedAmt, gccDiscountAmt, gccDueAmt, gccPaidAmount, gccReceivedAmt
			//        If Val(Value) <> 0 Then
			//            Value = Format(Val(Value), "###,###,###,###,##0.000")
			//        Else
			//            Value = ""
			//        End If
			//End Select
		}


		public bool Post()
		{
			bool result = false;
			DialogResult ans = (DialogResult) 0;
			System.DateTime mLastMonthEndDate = DateTime.FromOADate(0);
			bool mPostToGLOnTransactionPosting = false;

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
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mPostToGLOnTransactionPosting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("post_to_gl_on_transaction_posting"));


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
							//'''''''''''''''''''''''''''
							mLastMonthEndDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(SystemREProcedure.GetRELastMonthEndDate());

							if (SystemREProcedure.PostREReceiptsStatus(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue)))
							{
								//**--check if the transaction should be posted to gl after approval
								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_re_gl_link")) && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("post_to_gl_on_transaction_posting"))) == TriState.True)
								{
									if (!SystemREProcedure.PostREReceiptsToGL(mLastMonthEndDate, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue)))
									{
										//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
										SystemVariables.gConn.RollbackTrans();
										goto mDestroy;
									}

									if (!SystemREProcedure.PostREAdvanceReceiptsToGL(mLastMonthEndDate, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), false))
									{
										//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
										SystemVariables.gConn.RollbackTrans();
										goto mDestroy;
									}
								}
							}
							else
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								goto mDestroy;
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

		public void PrintReport(int pEntryId = 0)
		{
			int mEntryID = 0;
			frmSysReportPrint ofrmSysReportPrint = frmSysReportPrint.CreateInstance();

			try
			{

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryID = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
				}
				else
				{
					if (!SystemProcedure2.IsItEmpty(pEntryId))
					{
						mEntryID = pEntryId;
					}
					else
					{
						return;
					}
				}

				//\crystal_files\RASHID_RENT

				SystemReports.GetCrystalReport(100070000, 2, "5457", Conversion.Str(mEntryID), false);
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			if (Index == conTxtVoucherNo)
			{
				txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("re_maintenance", "voucher_no", 2);
			}
			else
			{
				FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
			}
		}
	}
}