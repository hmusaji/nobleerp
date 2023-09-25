
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayTermination
		: System.Windows.Forms.Form
	{

		public frmPayTermination()
{
InitializeComponent();
} 
 public  void frmPayTermination_old()
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


		private void frmPayTermination_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private bool mCheck = false;
		private clsToolbar oThisFormToolBar = null;

		private const int conTxtVoucherNo = 0;
		private const int conTxtEmpCode = 1;
		private const int conTXTReferenceNo = 2;
		private const int conTxtComments = 3;
		private const int conTxtEarningComments = 4;
		private const int conTxtDeductionComments = 5;
		private const int conTxtBudgetHeadCount = 72;

		private const int conTabTerminationDetails = 0;
		private const int conTabTerminationOthDetails = 1;

		private const int conDlblDeptCode = 0;
		private const int conDlblDeptName = 1;
		private const int conDlblDesgCode = 2;
		private const int conDlblDesgName = 3;
		private const int conDlblLeaveSalary = 4;
		private const int conDlblIndemnitySalary = 5;
		private const int conDlblEmpName = 6;
		private const int conDlblLeaveDays = 7;
		private const int conDlblIndemnityDays = 8;
		private const int conDlblLeaveAmtPerDay = 9;
		private const int conDlblIndemnityAmtPerDay = 10;
		private const int conDlblHeadCount = 26;

		private const int conDlblNetSalaryPerDay = 16;
		private const int conDlblNetSalaryDays = 17;

		private const int conDlblLeaveAmtDue = 11;
		private const int conDlblIndemnityAmtDue = 12;
		private const int conDlblNetSalaryDue = 13;
		private const int conDlblTotalAmt = 14;
		private const int conDlblTotalAmtPaid = 15;

		private const int conDlblEarningDue = 18;
		private const int conDlblDeductionDue = 19;
		private const int conDlblLoanDue = 20;
		private const int conDlblStatus = 21;

		//ST = Severance Type
		private const int conDlblSTLeaveAmtDue = 22;
		private const int conDlblSTIndemnityAmtDue = 23;
		private const int conDlblSTNetSalaryDue = 24;
		private const int conDlblSTTotalAmt = 25;

		private const int conNTxtLeaveAmountPaid = 0;
		private const int conNTxtIndemnityAmountPaid = 1;
		private const int conNTxtNetSalaryPaid = 2;
		private const int conNTxtEarningPaid = 3;
		private const int conNTxtDeductionRecovered = 4;
		private const int conNTxtLoanRecovered = 5;

		private const int conCmbTerminationType = 0;

		private string mTimeStamp = "";
		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;
		private int mSeverenceStatus = 0;
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

		bool mCmbClkEvntEnable = false;
		int mTemplateEntID = 0;
		int mEmpStatusCd = 0;
		string mExpectedResumeDate = "";
		int mEligibilityDays = 0;

		private const int grdLineNoColumn = 0;
		private const int grdBillingCodeColumn = 1;
		private const int grdBillingNameColumn = 2;
		private const int grdBillingTypeColumn = 3;
		private const int grdBillingModeTextColumn = 4;
		private const int grdBillingModeValueColumn = 5;
		private const int grdBillingLinkedLeaveColumn = 6;
		private const int grdBillingAmtColumn = 7;
		private const int grdBillingDays = 8;
		private const int grdBillingHours = 9;
		private const int grdAmtColumn = 10;
		private const int grdRemarksColumn = 11;
		private const int grdOverTime = 12;
		private const int grdEntryId = 13;
		private const int grdTransType = 14;
		private const int grdBillTypeID = 15;
		private const string conFixed = "F";
		private const string conTemporary = "T";

		private double mDaysPerMonth = 0;
		private double mHoursPerDay = 0;
		private double mBasicSalary = 0;
		private int mPaymentTypeId = 0;
		private double mOvertimeSalary = 0;

		private const int conMaxColumns = 15;

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



		private void CmbCommon_Click(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.CmbCommon, Sender);
			double tmpTotalIndmntAmt = 0;
			try
			{
				if (!mCmbClkEvntEnable)
				{
					return;
				}
				string mysql = "";
				SqlDataReader rsTmp = null;
				double mIndemnityPercent = 0;
				int mTotalWorkedDays = 0;
				int mRateCalMethod = 0;
				double mRatePerDay = 0;
				System.DateTime mDateOfJoining = DateTime.FromOADate(0);
				object mTempReturnValue = null;

				if (txtCommonTextBox[conTxtEmpCode].Text == "" || !Information.IsDate(txtVoucherDate.Value) || CmbCommon[conCmbTerminationType].Text == "")
				{
					return;
				}

				if (Index == conCmbTerminationType)
				{
					SqlCommand sqlCommand = new SqlCommand("select * from pay_employee where emp_no = '" + txtCommonTextBox[conTxtEmpCode].Text + "'", SystemVariables.gConn);
					rsTmp = sqlCommand.ExecuteReader();
					rsTmp.Read();
					if (rsTmp.HasRows)
					{
						mTotalWorkedDays = (int) DateAndTime.DateDiff("d", Convert.ToDateTime(rsTmp["date_of_joining"]), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
						mRateCalMethod = Convert.ToInt32(rsTmp["rate_calc_method_id"]);
						mRatePerDay = Convert.ToDouble(rsTmp["Rate_Per_Day"]);
					}
					else
					{
						rsTmp.Close();
						return;
					}
					//MsgBox mTotalWorkedDays
					rsTmp.Close();
					mIndemnityPercent = 0;
					mysql = " select * from pay_termination_type_details where type_cd = " + CmbCommon[conCmbTerminationType].GetItemData(CmbCommon[conCmbTerminationType].ListIndex).ToString();
					SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
					rsTmp = sqlCommand_2.ExecuteReader();
					bool rsTmpDidRead2 = rsTmp.Read();

					do 
					{
						if (Convert.ToDouble(rsTmp["start_period"]) >= mTotalWorkedDays || Convert.ToDouble(rsTmp["end_period"]) >= mTotalWorkedDays)
						{
							mIndemnityPercent = Convert.ToDouble(rsTmp["percent_amount"]);
							break;
						}
					}
					while(rsTmp.Read());
					if (mIndemnityPercent == 0)
					{
						txtDisplayLabel[conDlblSTIndemnityAmtDue].Text = "0.000";
					}
					else
					{
						tmpTotalIndmntAmt = Conversion.Val(txtDisplayLabel[conDlblIndemnityDays].Text) * Conversion.Val(txtDisplayLabel[conDlblIndemnityAmtPerDay].Text);
						if (mIndemnityPercent == 100)
						{
							txtDisplayLabel[conDlblSTIndemnityAmtDue].Text = StringsHelper.Format(txtDisplayLabel[conDlblIndemnityAmtDue].Text, "#####0.000");
						}
						else
						{
							txtDisplayLabel[conDlblSTIndemnityAmtDue].Text = StringsHelper.Format((tmpTotalIndmntAmt / 100d) * mIndemnityPercent, "#####0.000");
						}
					}
					mysql = " select Preference_Value from SM_Preferences where Preference_Name = 'probation_period'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					if (ReflectionHelper.GetPrimitiveValue<int>(mTempReturnValue) > 0)
					{
						if (ReflectionHelper.GetPrimitiveValue<int>(mTempReturnValue) > mTotalWorkedDays + 1)
						{
							txtDisplayLabel[conDlblSTLeaveAmtDue].Text = "0.000";
							txtDisplayLabel[conDlblSTIndemnityAmtDue].Text = "0.000";
						}
					}

					if (mEligibilityDays != 0)
					{
						if (mTotalWorkedDays < mEligibilityDays && CmbCommon[conCmbTerminationType].GetItemData(CmbCommon[conCmbTerminationType].ListIndex) != 55)
						{
							txtCommonNumber[conNTxtLeaveAmountPaid].Value = 0;
						}
						else
						{
							txtCommonNumber[conNTxtLeaveAmountPaid].Value = Conversion.Val(txtDisplayLabel[conDlblSTLeaveAmtDue].Text);
						}
					}

					txtCommonNumber[conNTxtIndemnityAmountPaid].Value = Conversion.Val(txtDisplayLabel[conDlblSTIndemnityAmtDue].Text);
					txtCommonNumber[conNTxtNetSalaryPaid].Value = Conversion.Val(txtDisplayLabel[conDlblSTNetSalaryDue].Text);
					//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
					//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
					txtDisplayLabel[conDlblSTTotalAmt].Text = StringsHelper.Format(Convert.ToDouble(ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtLeaveAmountPaid].Value) + ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtIndemnityAmountPaid].Value)) + ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtNetSalaryPaid].Value), "######0.000");

					rsTmp.Close();
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void cmbCommon_Leave(Object eventSender, EventArgs eventArgs)
		{
			CmbCommon_Click(CmbCommon[conCmbTerminationType], null);
		}

		private void cmbSeveranceStatus_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmbSeveranceStatus, eventSender);
			mSeverenceStatus = cmbSeveranceStatus[Index].GetItemData(cmbSeveranceStatus[Index].ListIndex);
		}

		private void cmdSubmmitApproval_Click(Object eventSender, EventArgs eventArgs)
		{
			DialogResult ans = (DialogResult) 0;
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				ans = MessageBox.Show("Do you want to save this record!!!", "Save", MessageBoxButtons.YesNo);
				if (ans == System.Windows.Forms.DialogResult.Yes)
				{
					if (saveRecord())
					{
						SystemHRProcedure.ApprovalSubmmit(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 9, mTemplateEntID, "Termination For Emp No :" + txtCommonTextBox[conTxtEmpCode].Text);
						AddRecord();
						MessageBox.Show("Approval Submitted Successfully::", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			else
			{
				if (SystemHRProcedure.CheckApprovalIsSubmmited(9, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue)))
				{
					if (saveRecord())
					{
						SystemHRProcedure.ApprovalSubmmit(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 9, mTemplateEntID, "Termination For Emp No :" + txtCommonTextBox[conTxtEmpCode].Text);
						AddRecord();
						MessageBox.Show("Approval Submitted Successfully::", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else
				{
					MessageBox.Show("Already Submitted for this record:", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			FirstFocusObject = txtCommonTextBox[conTxtVoucherNo];
			mCmbClkEvntEnable = true;
			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
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
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowUnpostButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;


				SystemProcedure.SetLabelCaption(this);

				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 1.47f, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing No.", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing Name", 2700, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing Type", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing Mode", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing Mode value", 0, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LinkedLeaveColumn", 0, false, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "BillingAmt", 0, false, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Days", 700, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Hours", 700, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 50);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "OverTime", 0, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Entry ID", 0, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Trans. Type", 0, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Bill Type ID", 0, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				//setting voucher details grid properties
				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);

				//assign a next code
				txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("Pay_Employee_Termination", "voucher_no");

				txtVoucherDate.Text = "";
				txtDSubmittedDate.Text = "";
				txtDisplayLabel[conDlblLeaveDays].Text = "0.000";
				txtDisplayLabel[conDlblLeaveAmtPerDay].Text = "0.000";
				txtDisplayLabel[conDlblLeaveAmtDue].Text = "0.000";
				txtDisplayLabel[conDlblSTLeaveAmtDue].Text = "0.000";

				txtDisplayLabel[conDlblIndemnityDays].Text = "0.000";
				txtDisplayLabel[conDlblIndemnityAmtPerDay].Text = "0.000";
				txtDisplayLabel[conDlblIndemnityAmtDue].Text = "0.000";
				txtDisplayLabel[conDlblSTIndemnityAmtDue].Text = "0.000";
				txtDisplayLabel[conDlblTotalAmt].Text = "0.000";

				txtDisplayLabel[conDlblNetSalaryDays].Text = "0.000";
				txtDisplayLabel[conDlblNetSalaryPerDay].Text = "0.000";
				txtDisplayLabel[conDlblNetSalaryDue].Text = "0.000";
				txtDisplayLabel[conDlblSTNetSalaryDue].Text = "0.000";
				txtDisplayLabel[conDlblTotalAmtPaid].Text = "0.000";
				txtDisplayLabel[conDlblEarningDue].Text = "0.000";

				txtDisplayLabel[conDlblDeductionDue].Text = "0.000";
				txtDisplayLabel[conDlblSTTotalAmt].Text = "0.000";
				//'Commented By Burhan Ghee Wala
				//'Date: 16-Oct-2007
				//'Desc: Termination Combo Box will fetch records from pay_termination_type table instead of sysdb
				//Dim mObjectId()
				//ReDim mObjectId(0)
				//mObjectId(conCmbTerminationType) = 1012
				//Call FillComboWithSystemObjects(CmbCommon, mObjectId)
				//'End Comment

				//'Added By Burhan ghee wala
				//'Date: 16-Oct-2007

				string mysql = "";
				mysql = " select ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_type_name" : " a_type_name");
				mysql = mysql + " ,Type_Cd from pay_termination_type ";
				SystemCombo.FillComboWithItemData(CmbCommon[conCmbTerminationType], mysql, true);

				object[] mObjectId = new object[1];
				mObjectId[0] = 1035;
				SystemCombo.FillComboWithSystemObjects(cmbSeveranceStatus, mObjectId);

				if (CmbCommon[conCmbTerminationType].ListCount > 0)
				{
					CmbCommon[conCmbTerminationType].ListIndex = 0;
				}
				this.frmApproval.Visible = SystemHRProcedure.IsApprovalEnabled(9);
				this.tabTermination.CurrTab = Convert.ToInt16(conTabTerminationDetails);
				//'End Add

				//'''Severence Status
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Use_Severence_Status")))
				{
					mSeverenceStatus = 1;
					cmbSeveranceStatus[0].Enabled = true;
				}
				else
				{
					mSeverenceStatus = 3;
					cmbSeveranceStatus[0].ListIndex = 2;
					cmbSeveranceStatus[0].Enabled = false;
				}
				//'''End

				//'''Budget Tab
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("HR_Budget")))
				{
					this.tabTermination.set_TabVisible(2, true);
				}
				else
				{
					this.tabTermination.set_TabVisible(2, false);
				}
				//''End

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
			//mCheck = False
			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearNumberBox(this);
			SystemProcedure2.ClearDateBox(this);

			txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("Pay_Employee_Termination", "voucher_no");

			txtCommonTextBox[conTxtEmpCode].Enabled = true;
			txtVoucherDate.Enabled = true;
			txtDSubmittedDate.Enabled = true;
			CmbCommon[conCmbTerminationType].Enabled = true;
			//txtVoucherDate.Value = Date

			txtDisplayLabel[conDlblLeaveDays].Text = "0.000";
			txtDisplayLabel[conDlblLeaveAmtPerDay].Text = "0.000";
			txtDisplayLabel[conDlblLeaveAmtDue].Text = "0.000";
			txtDisplayLabel[conDlblSTLeaveAmtDue].Text = "0.000";
			txtDlblAppTemplateName.Text = "";
			txtDisplayLabel[conDlblIndemnityDays].Text = "0.000";
			txtDisplayLabel[conDlblIndemnityAmtPerDay].Text = "0.000";
			txtDisplayLabel[conDlblIndemnityAmtDue].Text = "0.000";
			txtDisplayLabel[conDlblSTIndemnityAmtDue].Text = "0.000";
			txtDisplayLabel[conDlblTotalAmt].Text = "0.000";

			txtDisplayLabel[conDlblNetSalaryDays].Text = "0.000";
			txtDisplayLabel[conDlblNetSalaryPerDay].Text = "0.000";
			txtDisplayLabel[conDlblNetSalaryDue].Text = "0.000";
			txtDisplayLabel[conDlblTotalAmtPaid].Text = "0.000";
			txtDisplayLabel[conDlblSTNetSalaryDue].Text = "0.000";
			txtDisplayLabel[conDlblDeductionDue].Text = "0.000";
			txtDisplayLabel[conDlblEarningDue].Text = "0.000";
			txtDisplayLabel[conDlblSTTotalAmt].Text = "0.000";

			CmbCommon[conCmbTerminationType].ListIndex = -1;
			cmbSeveranceStatus[0].ListIndex = 0;
			mSeverenceStatus = 1;

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Use_Severence_Status")))
			{
				mSeverenceStatus = 1;
				cmbSeveranceStatus[0].Enabled = true;
			}
			else
			{
				mSeverenceStatus = 3;
				cmbSeveranceStatus[0].ListIndex = 2;
				cmbSeveranceStatus[0].Enabled = false;
			}

			int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				grdVoucherDetails.Columns[cnt].FooterText = "";
			}

			DefineVoucherArray(-1, true);
			AssignGridLineNumbers();
			grdVoucherDetails.Rebind(true);
			txtVoucherDate.Text = "";
			txtDSubmittedDate.Text = "";
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode

			mFirstGridFocus = true;
			mSearchValue = ""; //Change the msearchvalue to blank
			FirstFocusObject.Focus();
			mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
			this.tabTermination.CurrTab = Convert.ToInt16(conTabTerminationDetails);
			//mCheck = True
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		private void chkBudget_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			txtCommonTextBox[conTxtBudgetHeadCount].Enabled = chkBudget.CheckState == CheckState.Checked;
		}

		public bool saveRecord(bool pApprove = false)
		{
			bool result = false;
			object mReturnValue = null;
			int mEmpCode = 0;
			double mTotalBudSalary = 0;
			int mHCCd = 0;

			string mysql = "";

			try
			{

				mysql = "select emp_cd , total_salary from  pay_employee ";
				mysql = mysql + " where ";
				mysql = mysql + " emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Employee Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtCommonTextBox[conTxtEmpCode].Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEmpCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTotalBudSalary = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1));
				}

				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = "select entry_id from pay_employee_termination where emp_cd =" + mEmpCode.ToString() + " and status =  1 ";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
					}
					else
					{
						MessageBox.Show("Unposted transaction for this employee is exist.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("HR_Budget")) && chkBudget.CheckState == CheckState.Checked)
				{
					if (Information.IsNumeric(txtCommonTextBox[conTxtBudgetHeadCount].Text))
					{
						mysql = "select head_count_cd from pay_head_count ";
						mysql = mysql + " where head_count_no = " + txtCommonTextBox[conTxtBudgetHeadCount].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue))
						{
							MessageBox.Show("Invalid Headcount Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return false;
						}
						else
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mHCCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
						}
					}
					else
					{
						MessageBox.Show("Please Update Budget Head count!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}
				else
				{
					mHCCd = 0;
				}

				SystemVariables.gConn.BeginTransaction();

				string mCheckTimeStamp = "";
				int mOldSeverenceStatus = 0;
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into pay_employee_termination ";
					mysql = mysql + " (emp_cd, dept_cd, desg_cd, comp_cd, curr_cd, voucher_no ";
					mysql = mysql + " , voucher_date,Submitted_Date, reference_no, termination_type_id, leave_balance_days ";
					mysql = mysql + " , leave_amount_per_day, leave_amount_due, leave_amount_paid";
					mysql = mysql + " , indemnity_balance_days , indemnity_amount_per_day ";
					mysql = mysql + " , indemnity_amount_due , indemnity_amount_paid ";
					mysql = mysql + " , net_salary_balance_days , net_salary_amount_per_day ";
					mysql = mysql + " , net_salary_amount_due ";
					mysql = mysql + " , net_salary_amount_paid ";
					mysql = mysql + " , last_salary_date";
					mysql = mysql + " , basic_salary, total_salary, leave_salary ";
					mysql = mysql + " , indemnity_salary ";
					mysql = mysql + " , bank_cd, bank_branch_cd, bank_account_no, rate_calc_method_id";
					mysql = mysql + " , payment_type_id ";
					mysql = mysql + " , weekend, weekend_day1_id, weekend_day2_id ";
					mysql = mysql + " , days_per_month , hours_per_day ";
					mysql = mysql + " , leave_cd, leave_switch_over_period, leave_days_before_sop ";
					mysql = mysql + " , leave_days_after_sop , leave_working_days_per_month_before_sop";
					mysql = mysql + " , leave_working_days_per_month_after_sop, leave_deduct_paid_days ";
					mysql = mysql + " , leave_deduct_unpaid_days , paid_leave_taken_days ";
					mysql = mysql + " , indemnity_switch_over_period, indemnity_days_before_sop ";
					mysql = mysql + " , indemnity_days_after_sop ";
					mysql = mysql + " , indemnity_working_days_per_month_before_sop ";
					mysql = mysql + " , indemnity_working_days_per_month_after_sop ";
					mysql = mysql + " , indemnity_deduct_paid_days , indemnity_deduct_unpaid_days ,comments";
					mysql = mysql + " , user_cd ,template_entry_id, Severence_status,leave_st_amount_due,indemnity_st_amount_due,net_salary_st_amount_due";
					mysql = mysql + " , Is_Budgeted , Head_Count_cd";
					mysql = mysql + " , IsReplacement )";
					mysql = mysql + " select pemp.emp_cd, pemp.dept_cd, pemp.desg_cd, pemp.comp_cd";
					mysql = mysql + " , pemp.curr_cd";
					mysql = mysql + " , " + txtCommonTextBox[conTxtVoucherNo].Text;
					mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText) + "'";
					mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtDSubmittedDate.DisplayText) + "'";
					mysql = mysql + " , '" + txtCommonTextBox[conTXTReferenceNo].Text + "'";
					mysql = mysql + " , " + CmbCommon[conCmbTerminationType].GetItemData(CmbCommon[conCmbTerminationType].ListIndex).ToString();
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblLeaveDays].Text, "##########0.000");
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblLeaveAmtPerDay].Text, "##########0.000");
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblLeaveAmtDue].Text, "##########0.000");
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtLeaveAmountPaid].Value);
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblIndemnityDays].Text, "##########0.000");
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblIndemnityAmtPerDay].Text, "##########0.000");
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblIndemnityAmtDue].Text, "##########0.000");
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtIndemnityAmountPaid].Value);
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblNetSalaryDays].Text, "##########0.000");
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblNetSalaryPerDay].Text, "##########0.000");
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblNetSalaryDue].Text, "##########0.000");
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtNetSalaryPaid].Value);
					mysql = mysql + " , pemp.last_salary_date ";
					mysql = mysql + " , pemp.basic_salary , pemp.total_salary ";
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblLeaveSalary].Text, "##########0.000");
					mysql = mysql + " , pemp.indemnity_salary ";
					mysql = mysql + " , pemp.bank_cd , pemp.bank_branch_cd ";
					mysql = mysql + " , pemp.bank_account_no, pemp.rate_calc_method_id ";
					mysql = mysql + " , pemp.payment_type_id ";
					mysql = mysql + " , pemp.weekend, pemp.weekend_day1_id, pemp.weekend_day2_id ";
					mysql = mysql + " , pemp.days_per_month, pemp.hours_per_day ";
					//mySql = mySql & " , peld.opening_paid_leave_balance_date "
					//mySql = mySql & " , peld.opening_paid_leave_balance_days "
					mysql = mysql + " , peld.leave_cd , peld.leave_switch_over_period ";
					mysql = mysql + " , peld.leave_days_before_sop, peld.leave_days_after_sop ";
					mysql = mysql + " , peld.working_days_per_month_before_sop ";
					mysql = mysql + " , peld.working_days_per_month_after_sop ";
					mysql = mysql + " , peld.deduct_paid_days, peld.deduct_unpaid_days ";
					mysql = mysql + " , peld.paid_leave_taken_days ";
					//mySql = mySql & " , pemp.opening_indemnity_balance_days, pemp.opening_indemnity_as_on "
					mysql = mysql + " , pemp.indemnity_switch_over_period, pemp.indemnity_days_before_sop ";
					mysql = mysql + " , pemp.indemnity_days_after_sop ";
					mysql = mysql + " , pemp.indemnity_working_days_per_month_before_sop ";
					mysql = mysql + " , pemp.indemnity_working_days_per_month_after_sop ";
					mysql = mysql + " , pemp.indemnity_deduct_paid_days , pemp.indemnity_deduct_unpaid_days ";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtComments].Text + "'";
					//''added by burhan
					//''Date: 21-Jul-2007
					//    mySql = mySql & " , N'" & txtCommonTextBox(conTxtEarningComments).Text & "'"
					//    mySql = mySql & " , " & Format(txtDisplayLabel(conDlblEarningDue).Text, "##########0.000")
					//    mySql = mySql & " , " & txtCommonNumber(conNTxtEarningPaid).Value
					//    mySql = mySql & " , N'" & txtCommonTextBox(conTxtDeductionComments).Text & "'"
					//    mySql = mySql & " , " & Format(txtDisplayLabel(conDlblDeductionDue).Text, "##########0.000")
					//    mySql = mySql & " , " & txtCommonNumber(conNTxtDeductionRecovered).Value
					//    '''End
					//    mySql = mySql & " , " & Format(txtDisplayLabel(conDlblLoanDue).Text, "##########0.000")
					//    mySql = mySql & " , " & txtCommonNumber(conNTxtLoanRecovered).Value
					mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
					//'Added For Approval Entry ID  as on 06-dec-2009
					if (mTemplateEntID == 0)
					{
						mysql = mysql + ", NULL";
					}
					else
					{
						mysql = mysql + "," + mTemplateEntID.ToString();
					}
					//'END
					//'Added For Employee Notice Period as on 26-dec-2010
					mysql = mysql + "," + cmbSeveranceStatus[0].GetItemData(cmbSeveranceStatus[0].ListIndex).ToString();
					//''End

					mysql = mysql + "," + txtDisplayLabel[conDlblSTLeaveAmtDue].Text;
					mysql = mysql + "," + txtDisplayLabel[conDlblSTIndemnityAmtDue].Text;
					mysql = mysql + "," + txtDisplayLabel[conDlblSTNetSalaryDue].Text;
					mysql = mysql + "," + ((int) chkBudget.CheckState).ToString();
					mysql = mysql + "," + ((mHCCd == 0) ? "NULL" : mHCCd.ToString());
					mysql = mysql + "," + ((int) chkIsReplacement.CheckState).ToString();
					mysql = mysql + " from pay_employee pemp ";
					mysql = mysql + " left outer join ( select peld1.* from pay_employee_leave_details peld1  where peld1.leave_cd = " + SystemHRProcedure.gVacationLeave.ToString() + " ) peld ";
					mysql = mysql + " on pemp.emp_cd = peld.emp_cd ";
					mysql = mysql + " where pemp.emp_cd = " + mEmpCode.ToString();
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));

					if (mSeverenceStatus != 1)
					{
						mysql = " update pay_employee_termination ";
						mysql = mysql + " set payroll_date = '" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
						mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();
					}
				}
				else
				{
					mysql = " select time_stamp,Severence_status from Pay_Employee_Termination where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mOldSeverenceStatus = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
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

					if (mOldSeverenceStatus != mSeverenceStatus && mSeverenceStatus == 1)
					{
						mysql = " update pay_employee ";
						mysql = mysql + " set status_cd = " + SystemHRProcedure.gStatusActive.ToString();
						mysql = mysql + " where emp_cd =" + mEmpCode.ToString();
						SqlCommand TempCommand_3 = null;
						TempCommand_3 = SystemVariables.gConn.CreateCommand();
						TempCommand_3.CommandText = mysql;
						TempCommand_3.ExecuteNonQuery();
					}
					if (mOldSeverenceStatus == 1 && mSeverenceStatus != 1)
					{
						mysql = " update pay_employee_termination ";
						mysql = mysql + " set payroll_date = '" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
						mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						SqlCommand TempCommand_4 = null;
						TempCommand_4 = SystemVariables.gConn.CreateCommand();
						TempCommand_4.CommandText = mysql;
						TempCommand_4.ExecuteNonQuery();
					}
					else if (mOldSeverenceStatus != 1 && mSeverenceStatus == 1)
					{ 
						mysql = " update pay_employee_termination ";
						mysql = mysql + " set payroll_date = null ";
						mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();
					}

					mysql = " update pay_employee_termination set ";
					mysql = mysql + " voucher_no = " + txtCommonTextBox[conTxtVoucherNo].Text;
					mysql = mysql + " , voucher_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText) + "'";
					mysql = mysql + " , Submitted_Date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtDSubmittedDate.DisplayText) + "'";
					mysql = mysql + " , reference_no ='" + txtCommonTextBox[conTXTReferenceNo].Text + "'";
					mysql = mysql + " , termination_type_id = " + CmbCommon[conCmbTerminationType].GetItemData(CmbCommon[conCmbTerminationType].ListIndex).ToString();
					mysql = mysql + " , leave_amount_paid =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtLeaveAmountPaid].Value);
					mysql = mysql + " , indemnity_amount_paid =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtIndemnityAmountPaid].Value);
					mysql = mysql + " , net_salary_amount_paid =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtNetSalaryPaid].Value);
					mysql = mysql + " , net_salary_balance_days =" + Double.Parse(txtDisplayLabel[conDlblNetSalaryDays].Text).ToString();
					mysql = mysql + " , net_salary_amount_due = " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtNetSalaryPaid].Value);
					mysql = mysql + " , comments= N'" + txtCommonTextBox[conTxtComments].Text + "'";
					//'''    mySql = mySql & " , other_earning_remarks= N'" & txtCommonTextBox(conTxtEarningComments).Text & "'"
					//'''    mySql = mySql & " , other_deduction_remarks= N'" & txtCommonTextBox(conTxtDeductionComments).Text & "'"
					//'''    mySql = mySql & " , other_earning_amount_paid=" & txtCommonNumber(conNTxtEarningPaid).Value
					//'''    mySql = mySql & " , other_deduction_amount_recovered=" & txtCommonNumber(conNTxtDeductionRecovered).Value
					//'''    mySql = mySql & " , loan_amount_paid =" & txtCommonNumber(conNTxtLoanRecovered).Value
					//Modify_Date,Modify_User_cd
					mysql = mysql + " , Modify_User_cd =" + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " , Modify_Date = '" + DateTime.Today.ToString("dd-MMM-yyyy") + "'";
					//'Added For Approval Entry ID  as on 06-dec-2009
					if (mTemplateEntID == 0)
					{
						mysql = mysql + ",template_entry_id =  NULL";
					}
					else
					{
						mysql = mysql + ",template_entry_id = " + mTemplateEntID.ToString();
					}
					//'END
					mysql = mysql + " , IsReplacement = " + ((int) chkIsReplacement.CheckState).ToString();
					mysql = mysql + " , Severence_status =" + cmbSeveranceStatus[0].GetItemData(cmbSeveranceStatus[0].ListIndex).ToString();
					mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					mysql = mysql + "";
					SqlCommand TempCommand_6 = null;
					TempCommand_6 = SystemVariables.gConn.CreateCommand();
					TempCommand_6.CommandText = mysql;
					TempCommand_6.ExecuteNonQuery();


				}

				mysql = " delete from pay_employee_termination_payroll_details";
				mysql = mysql + " where termination_entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_7 = null;
				TempCommand_7 = SystemVariables.gConn.CreateCommand();
				TempCommand_7.CommandText = mysql;
				TempCommand_7.ExecuteNonQuery();

				int cnt = 0;

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					mysql = "insert into pay_employee_termination_payroll_details (termination_entry_id,pay_date,emp_cd";
					mysql = mysql + " , bill_cd,billing_mode,pay_hours,pay_days,fc_amount,comments,user_cd)";
					mysql = mysql + " values(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					mysql = mysql + " ,'" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
					mysql = mysql + " ," + mEmpCode.ToString();
					mysql = mysql + " ," + GetBillCd(Convert.ToInt32(aVoucherDetails.GetValue(cnt, grdBillingCodeColumn))).ToString();
					mysql = mysql + " ,'" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingModeValueColumn)) + "'";
					if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdBillingHours), SystemVariables.DataType.NumberType))
					{
						mysql = mysql + " , 0";
					}
					else
					{
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingHours));
					}
					if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdBillingDays), SystemVariables.DataType.NumberType))
					{
						mysql = mysql + " ,0";
					}
					else
					{
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingDays));
					}
					mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdAmtColumn));
					mysql = mysql + " ,'" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdRemarksColumn)) + "'";
					mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " )";
					SqlCommand TempCommand_8 = null;
					TempCommand_8 = SystemVariables.gConn.CreateCommand();
					TempCommand_8.CommandText = mysql;
					TempCommand_8.ExecuteNonQuery();
				}

				if (mSeverenceStatus != 1)
				{ //''If Severence status is on notice it will not make employee status terminated or it will not stop his payroll
					//''''Change the status of the employee to terminated
					mysql = " update pay_employee ";
					mysql = mysql + " set status_cd = " + SystemHRProcedure.gStatusTerminated.ToString();
					mysql = mysql + " where emp_cd =" + mEmpCode.ToString();
					SqlCommand TempCommand_9 = null;
					TempCommand_9 = SystemVariables.gConn.CreateCommand();
					TempCommand_9.CommandText = mysql;
					TempCommand_9.ExecuteNonQuery();

					//'' on 01-Feb-2012   For Budget
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("HR_Budget")))
					{
						mysql = " update pay_head_count ";
						if (chkIsReplacement.CheckState == CheckState.Checked)
						{
							mysql = mysql + " set Head_count_status = 3 ";
							mysql = mysql + " , Replacement_Status = 1 ";
							mysql = mysql + "  , Total_Budget_Salary = " + SystemHRProcedure.GetEmpBudgetSalary(txtCommonTextBox[conTxtEmpCode].Text).ToString();
						}
						else
						{
							mysql = mysql + " set Head_count_status = 4 ";
							mysql = mysql + " , Replacement_Status = NULL ";
							mysql = mysql + "  , Total_Budget_Salary = " + SystemHRProcedure.GetEmpBudgetSalary(txtCommonTextBox[conTxtEmpCode].Text).ToString();
						}
						mysql = mysql + "  , Is_Budgeted = 0 ";
						mysql = mysql + " where emp_cd = " + mEmpCode.ToString() + " and head_count_status = 2 ";
						SqlCommand TempCommand_10 = null;
						TempCommand_10 = SystemVariables.gConn.CreateCommand();
						TempCommand_10.CommandText = mysql;
						TempCommand_10.ExecuteNonQuery();

						if (chkBudget.CheckState == CheckState.Checked)
						{
							mysql = "update pay_head_count";
							mysql = mysql + " set  Head_count_status = 4 ";
							mysql = mysql + "  , Is_Budgeted = 0 ";
							mysql = mysql + " where head_count_no = " + txtCommonTextBox[conTxtBudgetHeadCount].Text;
							SqlCommand TempCommand_11 = null;
							TempCommand_11 = SystemVariables.gConn.CreateCommand();
							TempCommand_11.CommandText = mysql;
							TempCommand_11.ExecuteNonQuery();
						}
						//''           Dim mHeadCountReturnValue As Variant
						//''        mHeadCountReturnValue = GetMasterCode("select Emp_cd,Head_Count_Category_Cd from pay_head_count where head_count_no = " & txtCommonTextBox(conTxtBudgetHeadCount).Text)
						//''        If Not IsNull(mHeadCountReturnValue(0)) Then
						//''            mySQL = " update pay_head_count"
						//''            mySQL = mySQL & " set Head_count_status = " & IIf(chkIsReplacement.Value, 3, 4)
						//''            mySQL = mySQL & "  , Replacement_Status = " & IIf(chkIsReplacement.Value, 1, "NULL")
						//''            mySQL = mySQL & "  , Total_Budget_Salary = " & GetEmpBudgetSalary(txtCommonTextBox(conTxtEmpCode).Text)
						//''            mySQL = mySQL & "  , Is_Budgeted = 0 "
						//''            mySQL = mySQL & " where emp_cd = " & CLng(mReturnValue(0)) & " and head_count_status = 2 "
						//''            gConn.Execute mySQL
						//''
						//''            mySQL = "INSERT INTO Pay_Head_Count"
						//''            mySQL = mySQL & " (Head_Count_Category_Cd,Head_Count_No,Emp_Cd,Is_Budgeted"
						//''            mySQL = mySQL & " ,Budget_Details_Line_No,Head_Count_Status,Comments,User_Cd,analysis3_cd,analysis1_cd"
						//''            mySQL = mySQL & " ,analysis2_cd,analysis4_cd,analysis5_cd,Total_Budget_Salary)"
						//''            mySQL = mySQL & " Values( " & mHeadCountReturnValue(1)
						//''            mySQL = mySQL & " , " & GetNewNumber("Pay_Head_Count", "Head_Count_No")
						//''            mySQL = mySQL & " , NULL , 0 , NULL , 2 , '' " & gLoggedInUserCode
						//''            mySQL = mySQL & " , " & txtCommonTextBox(conTxtAnalysis1).Text & " , " & txtCommonTextBox(conTxtAnalysis2).Text
						//''            mySQL = mySQL & " , " & txtCommonTextBox(conTxtAnalysis3).Text & " , " & txtCommonTextBox(conTxtAnalysis4).Text
						//''            mySQL = mySQL & " , " & txtCommonTextBox(conTxtAnalysis5).Text & " , 0 "
						//''            mySQL = mySQL & " ) "
						//''            gConn.Execute mySQL
						//''        Else
						//''            mySQL = "update pay_head_count"
						//''            mySQL = mySQL & " set Head_count_status = 4 " 'Discontinued
						//''            mySQL = mySQL & "  , Is_Budgeted = 0 "
						//''            mySQL = mySQL & " where head_count_no = " & txtCommonTextBox(conTxtBudgetHeadCount).Text
						//''            gConn.Execute mySQL
						//''        End If

					}
					//''End


					//'''   mySQL = "update pay_payroll_master "
					//'''   mySQL = mySQL & " set status_cd = " & gStatusTerminated
					//'''   mySQL = mySQL & " where emp_cd =" & mEmpCode & " and pay_date ='" & GetPayrollGenerateDate & "'"
					//'''   gConn.Execute mySQL

					mysql = "delete from pay_payroll";
					mysql = mysql + " where emp_cd = " + mEmpCode.ToString();
					mysql = mysql + " and pay_date = '" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
					SqlCommand TempCommand_12 = null;
					TempCommand_12 = SystemVariables.gConn.CreateCommand();
					TempCommand_12.CommandText = mysql;
					TempCommand_12.ExecuteNonQuery();

					mysql = "delete from pay_payroll_master";
					mysql = mysql + " where emp_cd = " + mEmpCode.ToString();
					mysql = mysql + " and pay_date = '" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
					SqlCommand TempCommand_13 = null;
					TempCommand_13 = SystemVariables.gConn.CreateCommand();
					TempCommand_13.CommandText = mysql;
					TempCommand_13.ExecuteNonQuery();
					//'End
				}

				SystemProcedure.InsertAlarmDetails(9, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), txtCommonTextBox[conTxtComments].Text, ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value));

				if (pApprove)
				{
					if (!SystemHRProcedure.GetTransactionApprovalStage(9, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 2))
					{
						MessageBox.Show("Cannot Post this record!!!", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.CommitTrans();
						return result;
					}
					SystemHRProcedure.PayPostToHR("Pay_Employee_Termination", ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));
					SystemHRProcedure.PayApprove("Pay_Employee_Termination", ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));
					Termination_Post_Effect(mSearchValue);
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_gl_link")))
					{
						if (!PostGLTransaction())
						{
							result = false;
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							FirstFocusObject.Focus();
							return result;
						}
					}
				}


				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				FirstFocusObject.Focus();
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}
			return result;
		}

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

			if (!SystemHRProcedure.GetTransactionApprovalStage(9, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 1))
			{
				MessageBox.Show("Cannot delete this record!!!", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return result;
			}

			SystemVariables.gConn.BeginTransaction();

			//Employee Master Record Make It Active
			string mysql = " update pay_employee ";
			mysql = mysql + " set status_cd = 1 ";
			mysql = mysql + " from pay_employee pemp inner join Pay_Employee_Termination pet ";
			mysql = mysql + " on pemp.emp_cd = pet.emp_cd ";
			mysql = mysql + " where pet.entry_id=" + Conversion.Str(mSearchValue);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			//Employee Payroll Master Make It Active
			mysql = " update pay_payroll_master ";
			mysql = mysql + " set status_cd = 1 ";
			mysql = mysql + " from pay_payroll_master ppm inner join Pay_Employee_Termination pet  ";
			mysql = mysql + " on ppm.emp_cd = pet.emp_cd ";
			mysql = mysql + " where pet.entry_id=" + Conversion.Str(mSearchValue) + " and ppm.status_cd = 3";
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

			mysql = "delete from pay_employee_termination_payroll_details where termination_entry_id = " + Conversion.Str(mSearchValue);
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mysql;
			TempCommand_3.ExecuteNonQuery();

			mysql = "delete from Pay_Employee_Termination  where entry_id=" + Conversion.Str(mSearchValue);
			SqlCommand TempCommand_4 = null;
			TempCommand_4 = SystemVariables.gConn.CreateCommand();
			TempCommand_4.CommandText = mysql;
			TempCommand_4.ExecuteNonQuery();

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

		public void GetRecord(object SearchValue)
		{
			mCmbClkEvntEnable = false;
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			//On Error GoTo eFoundError
			DataSet rs = null;

			FirstFocusObject.Focus();

			string mysql = " select pet.* ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "isnull(l_first_name,'') + ' ' + isnull(l_second_name,'') + ' ' + isnull(l_third_name,'') + ' ' + isnull(l_fourth_name,'')" : "isnull(a_first_name,'') + ' ' + isnull(a_second_name,'') + ' ' + isnull(a_third_name,'') + ' ' + isnull(a_fourth_name,'')") + " as emp_name ";
			mysql = mysql + " , emp_no ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name") + " as dept_name ";
			mysql = mysql + " , dept_no ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name") + " as desg_name ";
			mysql = mysql + " , desg_no ";
			mysql = mysql + " , pemp.total_salary, dbo.paygetleavesalary(pemp.emp_cd, pleave.leave_cd) as leave_salary "; //, pemp.leave_salary
			mysql = mysql + " , leave_no ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_leave_name" : "a_leave_name") + " as leave_name ";
			mysql = mysql + " , sat.trans_no, sat.l_approval_name , pemp.date_of_joining , pemp.status_cd";
			mysql = mysql + " , phc.Head_count_no";
			mysql = mysql + " from Pay_Employee_Termination pet ";
			mysql = mysql + " inner join pay_employee pemp on pet.emp_cd = pemp.emp_cd ";
			mysql = mysql + " left outer join pay_leave pleave on pet.leave_cd = pleave.leave_cd ";
			mysql = mysql + " left outer join sys_approval_template sat on pet.template_entry_id = sat.entry_id";
			mysql = mysql + " inner join pay_department pdept on  pemp.dept_cd = pdept.dept_cd ";
			mysql = mysql + " inner join pay_designation pdesg on  pemp.desg_cd = pdesg.desg_cd  ";
			mysql = mysql + " left outer join Pay_Head_count phc on phc.head_count_cd = pet.head_count_cd";
			mysql = mysql + " where pet.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);


			DataSet localRec = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			localRec.Tables.Clear();
			adap.Fill(localRec);
			int mCntRow = 0;
			if (localRec.Tables[0].Rows.Count != 0)
			{
				//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(SearchValue);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mTimeStamp = Convert.ToString(localRec.Tables[0].Rows[0]["time_stamp"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mEmpStatusCd = Convert.ToInt32(localRec.Tables[0].Rows[0]["status_cd"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtVoucherNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["voucher_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtVoucherDate.Value = localRec.Tables[0].Rows[0]["voucher_date"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!SystemProcedure2.IsItEmpty(localRec.Tables[0].Rows[0]["Submitted_Date"], SystemVariables.DataType.DateType))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtDSubmittedDate.Value = localRec.Tables[0].Rows[0]["Submitted_Date"];
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtDSubmittedDate.Value = localRec.Tables[0].Rows[0]["voucher_date"];
				}
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTXTReferenceNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["reference_no"]) + "";

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtEmpCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["emp_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblEmpName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["emp_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDeptCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["dept_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDeptName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["dept_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDesgCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["desg_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDesgName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["desg_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLeaveSalary].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["leave_salary"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblIndemnitySalary].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["indemnity_salary"], "###,###,##0.000");

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLeaveDays].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["leave_balance_days"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLeaveAmtPerDay].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["leave_amount_per_day"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLeaveAmtDue].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["leave_amount_due"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblSTLeaveAmtDue].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["Leave_ST_Amount_Due"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtLeaveAmountPaid].Value = localRec.Tables[0].Rows[0]["leave_amount_paid"];

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblIndemnityDays].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["indemnity_balance_days"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblIndemnityAmtPerDay].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["indemnity_amount_per_day"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblIndemnityAmtDue].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["indemnity_amount_due"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblSTIndemnityAmtDue].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["Indemnity_ST_Amount_Due"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtIndemnityAmountPaid].Value = localRec.Tables[0].Rows[0]["indemnity_amount_paid"];

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblNetSalaryDays].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["net_salary_balance_days"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblNetSalaryPerDay].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["net_salary_amount_per_day"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblNetSalaryDue].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["net_salary_amount_due"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblSTNetSalaryDue].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["Net_Salary_ST_Amount_Due"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtNetSalaryPaid].Value = localRec.Tables[0].Rows[0]["net_salary_amount_paid"];

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLoanDue].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["Loan_Amount_Due"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtLoanRecovered].Value = localRec.Tables[0].Rows[0]["Loan_Amount_Paid"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				txtDisplayLabel[conDlblTotalAmt].Text = StringsHelper.Format(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(localRec.Tables[0].Rows[0]["leave_amount_due"]) + Convert.ToDouble(localRec.Tables[0].Rows[0]["indemnity_amount_due"])) + Convert.ToDouble(localRec.Tables[0].Rows[0]["net_salary_amount_due"])) + Convert.ToDouble(localRec.Tables[0].Rows[0]["other_earning_amount_due"])) - (Convert.ToDouble(Convert.ToDouble(localRec.Tables[0].Rows[0]["other_deduction_amount_due"]) + Convert.ToDouble(localRec.Tables[0].Rows[0]["Loan_Amount_Due"]))), "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				txtDisplayLabel[conDlblSTTotalAmt].Text = StringsHelper.Format(Convert.ToDouble(Convert.ToDouble(localRec.Tables[0].Rows[0]["Leave_ST_Amount_Due"]) + Convert.ToDouble(localRec.Tables[0].Rows[0]["Indemnity_ST_Amount_Due"])) + Convert.ToDouble(localRec.Tables[0].Rows[0]["Net_Salary_ST_Amount_Due"]), "###,###,##0.000");
				//'' Added By Burhan Ghee Wala
				//'' Date: 21-Jul-2007
				//''        txtCommonTextBox(conTxtEarningComments).Text = .Fields("other_earning_remarks") & ""
				//''        txtCommonTextBox(conTxtDeductionComments).Text = .Fields("other_deduction_remarks") & ""
				//''        txtCommonNumber(conNTxtEarningPaid).Value = .Fields("other_earning_amount_paid")
				//''        txtCommonNumber(conNTxtDeductionRecovered).Value = .Fields("other_deduction_amount_recovered")
				//''        txtDisplayLabel(conDlblEarningDue).Text = Format(.Fields("other_earning_amount_due"), "###,###,##0.000")
				//''        txtDisplayLabel(conDlblDeductionDue).Text = Format(.Fields("other_deduction_amount_due"), "###,###,##0.000")
				//''End
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemCombo.SearchCombo(CmbCommon[conCmbTerminationType], Convert.ToInt32(localRec.Tables[0].Rows[0]["Termination_Type_Id"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtComments].Text = Convert.ToString(localRec.Tables[0].Rows[0]["comments"]) + "";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mTemplateEntID = (localRec.Tables[0].Rows[0].IsNull("Template_Entry_id")) ? 0 : Convert.ToInt32(localRec.Tables[0].Rows[0]["Template_Entry_id"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemCombo.SearchCombo(cmbSeveranceStatus[0], Convert.ToInt32(localRec.Tables[0].Rows[0]["Severence_status"]));
				mSeverenceStatus = cmbSeveranceStatus[0].GetItemData(cmbSeveranceStatus[0].ListIndex);
				//Assign Approval Template
				if (mTemplateEntID == 0)
				{
					txtApprovalTemplate.Text = "";
					txtDlblAppTemplateName.Text = "";
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtApprovalTemplate.Text = Convert.ToString(localRec.Tables[0].Rows[0]["trans_no"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtDlblAppTemplateName.Text = Convert.ToString(localRec.Tables[0].Rows[0]["l_approval_name"]);
				}
				//End
				//Change the form mode to edit
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				txtCommonTextBox[conTxtEmpCode].Enabled = false;
				//cmbCommon(conCmbTerminationType).Enabled = False
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToDouble(localRec.Tables[0].Rows[0]["Severence_status"]) == 3)
				{
					txtDSubmittedDate.Enabled = false;
					txtVoucherDate.Enabled = false;
				}
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtJoiningDate.Value = localRec.Tables[0].Rows[0]["Date_Of_joining"];

				//'' on 29-Jan-2012 for Budget
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkBudget.CheckState = (CheckState) ((Convert.ToBoolean(localRec.Tables[0].Rows[0]["Is_Budgeted"])) ? 1 : 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkIsReplacement.CheckState = (CheckState) ((Convert.ToBoolean(localRec.Tables[0].Rows[0]["IsReplacement"])) ? 1 : 0);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!localRec.Tables[0].Rows[0].IsNull("Head_count_no"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonTextBox[conTxtBudgetHeadCount].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Head_count_no"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtDisplayLabel[conDlblHeadCount].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Head_count_no"]);
				}

				chkBudget.Enabled = false;
				txtCommonTextBox[conTxtBudgetHeadCount].Enabled = false;
				//'''END
				//'' As on 05-Apr-2010 For Termination Payroll Detail
				mysql = " select pbt.bill_no, pbt.l_bill_name ";
				mysql = mysql + " , (select l_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) as bill_type_id ";
				mysql = mysql + " , case when petpd.billing_mode = 'T' then 'Temporary' else 'Fixed' End as Mode ";
				mysql = mysql + " , petpd.billing_mode as mode_value, petpd.FC_Amount, pbt.bill_type_id, petpd.Pay_Hours, petpd.Pay_Days ";
				mysql = mysql + " from pay_billing_type pbt";
				mysql = mysql + " inner join pay_employee_termination_payroll_details petpd on petpd.bill_cd = pbt.bill_cd";
				mysql = mysql + " where petpd.termination_entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				rs = new DataSet();
				mCntRow = 0;
				SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rs.Tables.Clear();
				adap_2.Fill(rs);
				aVoucherDetails.RedimXArray(new int[]{rs.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
				foreach (DataRow iteration_row in rs.Tables[0].Rows)
				{
					aVoucherDetails.SetValue(mCntRow + 1, mCntRow, grdLineNoColumn);
					aVoucherDetails.SetValue(iteration_row["bill_no"], mCntRow, grdBillingCodeColumn);
					aVoucherDetails.SetValue(iteration_row["l_bill_name"], mCntRow, grdBillingNameColumn);
					aVoucherDetails.SetValue(iteration_row["bill_type_id"], mCntRow, grdBillingTypeColumn);
					aVoucherDetails.SetValue(iteration_row["Mode"], mCntRow, grdBillingModeTextColumn);
					aVoucherDetails.SetValue(iteration_row["mode_value"], mCntRow, grdBillingModeValueColumn);
					aVoucherDetails.SetValue(iteration_row["bill_type_id"], mCntRow, grdBillTypeID);
					aVoucherDetails.SetValue(iteration_row["fc_amount"], mCntRow, grdAmtColumn);
					aVoucherDetails.SetValue(iteration_row["pay_days"], mCntRow, grdBillingDays);
					aVoucherDetails.SetValue(iteration_row["pay_hours"], mCntRow, grdBillingHours);
					mCntRow++;
				}
				CalculateTotals(mCntRow, grdAmtColumn);
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Refresh();
				mFirstGridFocus = true;
				if (mFirstGridFocus)
				{
					grdVoucherDetails_GotFocus(grdVoucherDetails, new EventArgs());
				}
				//''END
				//Set the form caption and Get the Voucher Status
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, frmPayTermination.DefInstance, Convert.ToInt32(localRec.Tables[0].Rows[0]["status"]), CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Employee Severance Transaction" : "Employee Severance Transaction");
				CmbCommon[conCmbTerminationType].Enabled = false;
			}
			mCmbClkEvntEnable = true;
			localRec = null;

			return;

			mCmbClkEvntEnable = true;
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
			SystemReports.GetCrystalReport(110013090, 2, "6412", Conversion.Str(mEntryId), false);
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7110000));
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

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				if (!SystemHRProcedure.GetTransactionApprovalStage(9, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 1))
				{
					MessageBox.Show("Cannot edit this record!!!", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
					goto mend;
				}
			}

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

				if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Employee Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonTextBox[conTxtEmpCode].Focus();
				}
				else
				{

					if (SystemProcedure2.IsItEmpty(CmbCommon[conCmbTerminationType].Text, SystemVariables.DataType.StringType))
					{
						MessageBox.Show("Select valid Termination Type ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						CmbCommon[conCmbTerminationType].Focus();
					}
					else
					{

						if (!Information.IsDate(txtVoucherDate.DisplayText))
						{
							MessageBox.Show("Enter valid date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtVoucherDate.Focus();
						}
						else
						{



							return true;
						}
					}
				}
			}
			mend:
			return false;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmPayTermination.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void GetNextNumber()
		{
			txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("Pay_Employee_Termination", "voucher_no");
			FirstFocusObject.Focus();
		}



		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == grdAmtColumn || ColIndex == grdBillingDays || ColIndex == grdBillingHours)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###,###,##0.000");
				}
				else
				{
					Value = "";
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{
			int Col = 0;

			if (MsgId == 1)
			{
				grdVoucherDetails.Col = grdBillingCodeColumn;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList);
			}
		}



		private void txtApprovalTemplate_DropButtonClick(Object Sender, EventArgs e)
		{
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220586, "2618"));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				mTemplateEntID = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempSearchValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtApprovalTemplate.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				txtApprovalTemplate_Leave(txtApprovalTemplate, new EventArgs());
			}
		}

		private void txtApprovalTemplate_Leave(Object eventSender, EventArgs eventArgs)
		{

			string mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_Approval_Name" : "a_Approval_Name");
			mysql = mysql + " from sys_approval_template where entry_id = " + mTemplateEntID.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDlblAppTemplateName.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
			}
			else
			{
				txtDlblAppTemplateName.Text = "";
			}

		}

		private void txtCommonNumber_Change(Object Sender, EventArgs e)
		{
			//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
			//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
			//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
			//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
			txtDisplayLabel[conDlblTotalAmtPaid].Text = StringsHelper.Format(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtLeaveAmountPaid].Value) + ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtIndemnityAmountPaid].Value)) + ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtNetSalaryPaid].Value)) + ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtEarningPaid].Value)) - (Convert.ToDouble(ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtDeductionRecovered].Value) + ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtLoanRecovered].Value))), "###,###,##0.000");
			txtDisplayLabel[conDlblTotalAmt].Text = StringsHelper.Format(Conversion.Val(StringsHelper.Format(txtDisplayLabel[conDlblLeaveAmtDue].Text, "########0.000")) + Conversion.Val(StringsHelper.Format(txtDisplayLabel[conDlblIndemnityAmtDue].Text, "########0.000")) + Conversion.Val(StringsHelper.Format(txtDisplayLabel[conDlblNetSalaryDue].Text, "########0.000")) + Conversion.Val(StringsHelper.Format(txtDisplayLabel[conDlblEarningDue].Text, "########0.000")) - Conversion.Val(StringsHelper.Format(txtDisplayLabel[conDlblLoanDue].Text, "########0.000")), "########0.000");
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			if (Index == conTxtVoucherNo)
			{
				GetNextNumber();
			}
			else
			{
				FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
			}
		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			try
			{
				object mTempValue = null;
				object mApprovalTempValue = null;
				string mysql = "";
				int cnt = 0;
				object mReturnValue = null;

				if (Index == conTxtEmpCode)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name" : "a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name");
						mysql = mysql + " , dept_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
						mysql = mysql + " , desg_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
						mysql = mysql + " , emp_cd";
						mysql = mysql + " , pemp.rate_calc_method_id, weekend, weekend_day1_id , weekend_day2_id  ";
						mysql = mysql + " , pemp.total_salary, pes.l_status_name, pemp.status_cd, pemp.basic_salary, pemp.days_per_month, pemp.hours_per_day";
						mysql = mysql + " , pemp.notice_period, pemp.Date_of_joining , pemp.indemnity_salary ";
						mysql = mysql + " from pay_employee pemp , pay_department pdept, pay_designation pdesg , pay_employee_status pes";
						mysql = mysql + " where ";
						mysql = mysql + " pemp.dept_cd = pdept.dept_cd and pemp.desg_cd = pdesg.desg_cd ";
						mysql = mysql + " and pemp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
						//''Only Active Employee
						mysql = mysql + " and pemp.status_cd in (1,2) ";

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtCommonTextBox[Index].Text = "";
							txtDisplayLabel[conDlblEmpName].Text = "";
							txtDisplayLabel[conDlblDeptCode].Text = "";
							txtDisplayLabel[conDlblDeptName].Text = "";
							txtDisplayLabel[conDlblDesgCode].Text = "";
							txtDisplayLabel[conDlblDesgName].Text = "";
							txtDisplayLabel[conDlblLeaveSalary].Text = "";
							txtDisplayLabel[conDlblIndemnitySalary].Text = "";
							txtDisplayLabel[conDlblStatus].Text = "";
							txtNoticePeriod.Value = 0;
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDeptCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDesgCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblStatus].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(11));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mEmpStatusCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(12));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mBasicSalary = ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(13));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mDaysPerMonth = ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(14));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mHoursPerDay = ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(15));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							txtNoticePeriod.Value = Convert.ToInt32((Convert.IsDBNull(((Array) mTempValue).GetValue(16))) ? ((object) 0) : ((Array) mTempValue).GetValue(16));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtJoiningDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(17));
							txtDisplayLabel[conDlblLeaveSalary].Text = StringsHelper.Format(SystemHRProcedure.GetEmpAnnualLeaveSalary(txtCommonTextBox[conTxtEmpCode].Text), "###,###,##0.000");
							txtDisplayLabel[conDlblIndemnitySalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(18)), "###,###,##0.000");
							//Default Approval Aasign
							mTemplateEntID = SystemHRProcedure.GetDefaultTemplateEntryID(txtCommonTextBox[conTxtEmpCode].Text);
							if (mTemplateEntID == 0)
							{
								txtApprovalTemplate.Text = "";
								txtDlblAppTemplateName.Text = "";
							}
							else
							{
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mApprovalTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select trans_no,l_approval_name from sys_approval_template where entry_id =" + mTemplateEntID.ToString()));
								//UPGRADE_WARNING: (1068) mApprovalTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtApprovalTemplate.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mApprovalTempValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mApprovalTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDlblAppTemplateName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mApprovalTempValue).GetValue(1));
							}
							//if Employee is on leave then calculate its unpaid days
							if (mEmpStatusCd == 2)
							{
								mysql = " select plt.actual_resume_date";
								mysql = mysql + " from pay_leave_transaction plt ";
								mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = plt.emp_cd";
								mysql = mysql + " where pemp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
								mysql = mysql + " and plt.resume_processed_status = 1";

								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (!Convert.IsDBNull(mReturnValue))
								{
									//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mExpectedResumeDate = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
								}
							}
							//End
							if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("HR_Budget")))
							{
								mysql = " select Top 1 head_count_no from pay_head_count phc";
								mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = phc.emp_cd ";
								mysql = mysql + " inner join pay_head_count_category phcc on phcc.head_count_category_cd = phc.head_count_category_cd";
								mysql = mysql + " inner join pay_department pd on phcc.dept_cd  = pd.dept_cd ";
								mysql = mysql + " inner join pay_designation pds on phcc.desg_cd = pds.desg_cd ";
								mysql = mysql + " where pemp.emp_no = '" + txtCommonTextBox[conTxtEmpCode].Text + "'";
								mysql = mysql + " and phc.Total_Budget_Salary < 0 ";
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (Convert.IsDBNull(mReturnValue))
								{
									txtCommonTextBox[conTxtBudgetHeadCount].Text = "";
									txtDisplayLabel[conDlblHeadCount].Text = "";
								}
								else
								{
									//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									txtCommonTextBox[conTxtBudgetHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
									//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									txtDisplayLabel[conDlblHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
								}
							}
						}
					}
					else
					{
						txtDisplayLabel[conDlblEmpName].Text = "";
						txtDisplayLabel[conDlblDeptCode].Text = "";
						txtDisplayLabel[conDlblDeptName].Text = "";
						txtDisplayLabel[conDlblDesgCode].Text = "";
						txtDisplayLabel[conDlblDesgName].Text = "";
						txtDisplayLabel[conDlblLeaveSalary].Text = "";
						txtDisplayLabel[conDlblIndemnitySalary].Text = "";
						txtDisplayLabel[conDlblStatus].Text = "";
					}
				}

				if (Index == conTxtBudgetHeadCount)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtBudgetHeadCount].Text, SystemVariables.DataType.NumberType) && !SystemProcedure2.IsItEmpty(txtDisplayLabel[conDlblDeptCode].Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select head_count_no ";
						mysql = mysql + " from pay_head_count phc";
						mysql = mysql + " inner join pay_head_count_category phcc on phcc.head_count_category_cd = phc.head_count_category_cd";
						mysql = mysql + " inner join pay_department pd on pd.dept_cd = phcc.dept_cd";
						mysql = mysql + " where ";
						mysql = mysql + " head_count_no = " + txtCommonTextBox[conTxtBudgetHeadCount].Text;
						mysql = mysql + " and phc.head_count_status in (1,3) and pd.dept_no = " + txtDisplayLabel[conDlblDeptCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblHeadCount].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
						}
					}
					else
					{
						txtDisplayLabel[conDlblHeadCount].Text = "";
						txtCommonTextBox[conTxtBudgetHeadCount].Text = "";
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
					if (txtCommonTextBox[Index].Enabled)
					{
						txtCommonTextBox[Index].Focus();
					}
				}
				else
				{
					//
				}
			}

		}


		public void FindRoutine(string pObjectName)
		{
			string mysql = "";
			int mDeptCd = 0;
			int mDesgCd = 0;
			object mTempSearchValue = null;

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));


			if (mObjectName == "txtCommonTextBox")
			{
				txtCommonTextBox[mIndex].Text = "";
				switch(mIndex)
				{
					case conTxtEmpCode : 
						mysql = " pay_emp.status_cd in (1,2) "; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", mysql)); 
						break;
					case conTxtBudgetHeadCount : 
						txtCommonTextBox[conTxtBudgetHeadCount].Text = ""; 
						if (!SystemProcedure2.IsItEmpty(txtDisplayLabel[conDlblDeptCode].Text, SystemVariables.DataType.NumberType) && !SystemProcedure2.IsItEmpty(txtDisplayLabel[conDlblDesgCode].Text, SystemVariables.DataType.NumberType))
						{
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mDeptCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select dept_cd from pay_department where dept_no = " + txtDisplayLabel[conDlblDeptCode].Text));
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mDesgCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select desg_cd from pay_designation where desg_no = " + txtDisplayLabel[conDlblDesgCode].Text));
							mysql = "phc.head_count_status in (1,3) and phcc.dept_cd = " + mDeptCd.ToString() + " and phcc.desg_cd = " + mDesgCd.ToString();

							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220623, "2768", mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mTempSearchValue))
							{
								//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtCommonTextBox[conTxtBudgetHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
								txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
							}
						} 
						 
						break;
					default:
						return;
				}
			}

			//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue) && !Object.Equals(mTempSearchValue, null))
			{
				if (mObjectName == "txtCommonTextBox")
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[mIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
				}
			}
		}

		public bool Post()
		{
			bool result = false;
			DialogResult ans = (DialogResult) 0;
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

			if (mSeverenceStatus != 3)
			{
				MessageBox.Show("Cann't post record! Please change Severence status!!", "Severence Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return result;
			}
			//If mOldVoucherStatus = stActive Then
			//    frmTemp.VisiblePostTransactionToICS = False
			//    frmTemp.VisiblePostToGL = False
			//    frmTemp.EnableApprove = True
			//End If

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
						//            If frmTemp.mPostToInvnt = True Then
						//                '''
						//            End If
						//
						//            If frmTemp.mPostToGL = True Then
						//                'Call PostToGL(rsVoucherTypes("master_table_name"), CLng(SearchValue))
						//            End If

						if (frmTemp.mApprove)
						{
							SystemVariables.gConn.BeginTransaction();

							SystemHRProcedure.PayPostToHR("Pay_Employee_Termination", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
							SystemHRProcedure.PayApprove("Pay_Employee_Termination", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
							Termination_Post_Effect(SearchValue);

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
			SystemProcedure.AlarmStatusUpdate(9, ReflectionHelper.GetPrimitiveValue<int>(SearchValue), 1);
			result = false;

			mDestroy:
			frmTemp.Close();
			return result;
		}

		private void Termination_Post_Effect(object pSearchValue)
		{

			string mysql = " select leave_balance_days , emp_cd , leave_cd , total_Salary from Pay_Employee_Termination ";
			mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			int mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
			double mTotalBudSalary = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(2)))
			{
				mysql = " update pay_employee_leave_details ";
				mysql = mysql + " set ";
				mysql = mysql + " paid_leave_taken_days = paid_leave_taken_days + " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				mysql = mysql + " where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				mysql = mysql + " and leave_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
			}

			mysql = " update pay_employee ";
			mysql = mysql + " set ";
			mysql = mysql + " termination_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText) + "'";
			mysql = mysql + " where emp_cd =" + mEmpCd.ToString();
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();


			int mWorkHorsEntryId = SystemHRProcedure.GetTAEntryID(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)), SystemHRProcedure.enumTAFields.eTAWorkHours, ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.DisplayText).Year, ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.DisplayText).Month);
			if (!SystemHRProcedure.UpdateAttendanceFieldsHours(ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText), SystemHRProcedure.GetPayrollGenerateDate(), mWorkHorsEntryId, 0, false))
			{
				return;
			}
			//''Added By Burhan Ghee Wala
			//''Date: 09-Jul-2007

			mysql = "select emp_no from pay_employee where emp_cd = " + mEmpCd.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//    ClearPayroll GetPayrollGenerateDate, mReturnValue, mReturnValue
				//    GeneratePayrollEntry GetPayrollGenerateDate, mReturnValue, mReturnValue
				//    GenerateLeaveEntry GetPayrollGenerateDate, mReturnValue, mReturnValue
				//    GenerateLoanEntry GetPayrollGenerateDate, mReturnValue, mReturnValue
			}
			//'''End
		}

		private void txtDSubmittedDate_Enter(Object eventSender, EventArgs eventArgs)
		{
			if (!Information.IsDate(txtDSubmittedDate.DisplayText))
			{
				txtDSubmittedDate.Value = DateTime.Today;
			}
		}

		private void txtDSubmittedDate_Leave(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(txtDSubmittedDate.Value))
			{
				//'ccommented by hakim on 22-nov-2011
				//'If IsDate(CDate(txtDSubmittedDate.Value)) Then
				if (Information.IsDate(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDSubmittedDate.Value)) && !Information.IsDate(txtVoucherDate.Value))
				{
					txtVoucherDate.Value = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDSubmittedDate.Value).AddDays(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtNoticePeriod.Value))).ToString("dd-MMM-yyyy");
				}
			}
		}

		private void txtVoucherDate_Enter(Object eventSender, EventArgs eventArgs)
		{
			if (!Information.IsDate(txtVoucherDate.DisplayText))
			{
				txtVoucherDate.Value = DateTime.Today;
			}
		}

		private void txtVoucherDate_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				double mLeaveBalanceDays = 0;
				double mIndemnityBalanceDays = 0;
				decimal mLeaveSalary = 0;
				decimal mIndemnitySalary = 0;
				int mDaysPerMonth = 0;
				double mCurrentContLeaveBalance = 0;
				double mLeaveAmount = 0;
				double mCurrentContIndemnityBal = 0;
				double mIndemnityAmount = 0;
				string mysql = "";
				int mEmpCode = 0;
				int mLeaveCode = 0;
				object mReturnValue = null;
				object mTempReturnValue = null;
				string mDateOfJoining = "";
				bool mCalanderDays = false;
				//Dim mEntitleDays As Double

				if (mEmpStatusCd == SystemHRProcedure.gStatusTerminated)
				{
					return;
				}

				if (Information.IsDate(txtVoucherDate.Value) && txtCommonTextBox[conTxtEmpCode].Text != "")
				{
					mLeaveCode = 1;
					mysql = " select pl.leave_cd, pl.calculate_on_calendar_days, eligibility_days from pay_leave pl";
					mysql = mysql + " inner join pay_employee_leave_details peld on peld.leave_cd = pl.leave_cd";
					mysql = mysql + " where pl.leave_type_cd =  6 and peld.emp_cd =" + SystemHRProcedure.GetEmpCd(txtCommonTextBox[conTxtEmpCode].Text).ToString();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mLeaveCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
						mCalanderDays = ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(1));
						mEligibilityDays = Convert.ToInt32(ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2)));
					}
					mysql = " select pemp.emp_cd, dbo.paygetleavesalary(pemp.emp_cd," + mLeaveCode.ToString() + ") as leave_salary, pemp.indemnity_salary, pemp.days_per_month";
					mysql = mysql + " , pnat.allocate_provision, pemp.rate_calc_method_id, weekend_day1_id, weekend_day2_id";
					mysql = mysql + ", pemp.date_of_joining, peld.working_days_per_month_before_sop, pemp.emp_type_id , pemp.Rate_Per_Day";
					mysql = mysql + " from pay_employee pemp ";
					mysql = mysql + " inner join pay_nationality pnat on pemp.nat_cd = pnat.nat_cd ";
					mysql = mysql + " inner join pay_employee_leave_details peld on pemp.emp_cd = peld.emp_cd ";
					mysql = mysql + " where pemp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
					mysql = mysql + " and peld.leave_cd =" + mLeaveCode.ToString();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mEmpCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
						//mLeaveSalary = IIf(IsNull(mReturnValue(1)), mReturnValue(11), mReturnValue(1)) 'If Leave Salary is null then take rate_per_day
						//mIndemnitySalary = mReturnValue(2)
						if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)) == 60)
						{
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mDaysPerMonth = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(3));
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mLeaveSalary = ReflectionHelper.GetPrimitiveValue<decimal>(((Array) mReturnValue).GetValue(1));
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mIndemnitySalary = ReflectionHelper.GetPrimitiveValue<decimal>(((Array) mReturnValue).GetValue(2));
						}
						else if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)) == 61)
						{ 
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mDaysPerMonth = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(9)); //CalculateDays(GetPayrollGenerateStartDate, GetPayrollGenerateDate, CInt(mReturnValue(6)), CInt(mReturnValue(7)))
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mLeaveSalary = ReflectionHelper.GetPrimitiveValue<decimal>(((Array) mReturnValue).GetValue(1));
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mIndemnitySalary = ReflectionHelper.GetPrimitiveValue<decimal>(((Array) mReturnValue).GetValue(2));
						}
						else if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)) == 130)
						{ 
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mLeaveSalary = ReflectionHelper.GetPrimitiveValue<decimal>(((Array) mReturnValue).GetValue(11));
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mIndemnitySalary = ReflectionHelper.GetPrimitiveValue<decimal>(((Array) mReturnValue).GetValue(11));
						}
						if (mEmpStatusCd == 1)
						{
							mLeaveBalanceDays = SystemHRProcedure.Leave_Balance_Days(mEmpCode, mLeaveCode, ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.DisplayText));
						}
						else if (mEmpStatusCd == 2)
						{ 
							mLeaveBalanceDays = SystemHRProcedure.Leave_Balance_Days(mEmpCode, mLeaveCode, DateTime.Parse(mExpectedResumeDate));
						}
						//        If Val(mReturnValue(10)) = 148 Then
						//           mLeaveAmount = GetMasterCode("select dbo.payGetLeaveAmountForContract(" & mEmpCode & "," & mLeaveCode & "," & mLeaveBalanceDays & ",'" & txtVoucherDate.Value & "')")
						//        Else
						//''added by hakim on 24-may-2009
						if (mDaysPerMonth > 0)
						{
							if (!mCalanderDays)
							{
								mLeaveAmount = mLeaveBalanceDays * (((double) mLeaveSalary) / ((double) mDaysPerMonth));
							}
							else
							{
								mLeaveAmount = mLeaveBalanceDays * (((double) (mLeaveSalary * 12)) / 365d);
							}
						}
						else
						{
							mLeaveAmount = mLeaveBalanceDays * ((double) mLeaveSalary);
						}
						//        End If

						if (mLeaveBalanceDays > 0)
						{
							txtDisplayLabel[conDlblLeaveAmtPerDay].Text = StringsHelper.Format(mLeaveAmount / mLeaveBalanceDays, "###,###,##0.000");
						}
						else
						{
							txtDisplayLabel[conDlblLeaveAmtPerDay].Text = "0";
						}

						txtDisplayLabel[conDlblLeaveDays].Text = StringsHelper.Format(mLeaveBalanceDays, "###,###,##0.000");
						txtDisplayLabel[conDlblLeaveAmtDue].Text = StringsHelper.Format(Math.Round((double) mLeaveAmount, 2), "###,###,##0.000");
						txtDisplayLabel[conDlblSTLeaveAmtDue].Text = StringsHelper.Format(Math.Round((double) mLeaveAmount, 2), "########0.000");
						//txtCommonNumber(conNTxtLeaveAmountPaid).Value = Round(mLeaveAmount, 2)

						if (!ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(4)))
						{
							if (mEmpStatusCd == 1)
							{
								mIndemnityBalanceDays = SystemHRProcedure.IndemnityBalanceDays(mEmpCode, ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.DisplayText));
							}
							else if (mEmpStatusCd == 2)
							{ 
								mIndemnityBalanceDays = SystemHRProcedure.IndemnityBalanceDays(mEmpCode, DateTime.Parse(mExpectedResumeDate));
							}
						}
						else
						{
							mIndemnityBalanceDays = 0;
						}
						txtDisplayLabel[conDlblIndemnityDays].Text = StringsHelper.Format(mIndemnityBalanceDays, "###,###,##0.000");
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mDateOfJoining = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(8));

						//'' Changed By Burhan
						//'' Date: 09-Jul-2007
						//'' Desc: Get Indemnity Amount from SQL funtion PayIndemnityAmount

						//txtDisplayLabel(conDlblIndemnityAmtPerDay).Text = Format((mIndemnitySalary / mDaysPerMonth), "###,###,##0.000")
						//txtDisplayLabel(conDlblIndemnityAmtDue).Text = Format(mIndemnityBalanceDays * (mIndemnitySalary / mDaysPerMonth), "###,###,##0.000")
						//txtCommonNumber(conNTxtIndemnityAmountPaid).Value = mIndemnityBalanceDays * (mIndemnitySalary / mDaysPerMonth)
						mIndemnityAmount = 0;
						//        If Val(mReturnValue(10)) = 148 Then
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mIndemnityAmount = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select dbo.payGetIndmnityAmountForContract(" + mEmpCode.ToString() + "," + mIndemnityBalanceDays.ToString() + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "')"));
						//        End If

						//        mysql = " select  round( dbo.payIndemnityAmount( "
						//        mysql = mysql & mEmpCode
						//        mysql = mysql & " , " & mCurrentContIndemnityBal
						//        mysql = mysql & " , '" & txtVoucherDate.DisplayText & "'), 3, 1 )"
						//        mTempReturnValue = GetMasterCode(mysql)
						if (mIndemnityAmount != 0 && mIndemnityBalanceDays != 0)
						{
							//mIndemnityAmount = CDbl(mTempReturnValue) + mIndemnityAmount
							//txtDisplayLabel(conDlblIndemnityAmtPerDay).Text = Format(Round((mReturnValue / mIndemnityBalanceDays), 2), "###,###,##0.000")
							txtDisplayLabel[conDlblIndemnityAmtDue].Text = StringsHelper.Format(mIndemnityAmount, "###########0.000");
							//txtCommonNumber(conNTxtIndemnityAmountPaid).Value = Format(mIndemnityAmount, "###########0.000")
							txtDisplayLabel[conDlblSTIndemnityAmtDue].Text = StringsHelper.Format(mIndemnityAmount, "###########0.000");
							txtDisplayLabel[conDlblIndemnityAmtPerDay].Text = StringsHelper.Format(mIndemnityAmount / mIndemnityBalanceDays, "###,###,##0.000");
						}
						else
						{
							txtDisplayLabel[conDlblIndemnityAmtDue].Text = "0.000";
							txtCommonNumber[conNTxtIndemnityAmountPaid].Text = "0.000";
							txtDisplayLabel[conDlblIndemnityAmtPerDay].Text = "0.000";
							txtDisplayLabel[conDlblSTIndemnityAmtDue].Text = "0.000";
						}
						//End
						//'Add
						mysql = " select Preference_Value from SM_Preferences where Preference_Name = 'probation_period'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						if (ReflectionHelper.GetPrimitiveValue<int>(mTempReturnValue) > 0)
						{
							if (ReflectionHelper.GetPrimitiveValue<int>(mTempReturnValue) > ((int) DateAndTime.DateDiff("d", DateTime.Parse(mDateOfJoining), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.DisplayText), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) + 1)
							{
								txtCommonNumber[conNTxtLeaveAmountPaid].Value = 0;
								txtCommonNumber[conNTxtIndemnityAmountPaid].Value = 0;
							}
						}
						//'End
					}
					mFirstGridFocus = true;
					if (mFirstGridFocus)
					{
						grdVoucherDetails_GotFocus(grdVoucherDetails, new EventArgs());
					}
					if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.DisplayText) >= DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()))
					{
						GenerateFixedSalary();
						GenerateTempEarDed();
					}
					GetLoanBalance();

					txtDisplayLabel[conDlblTotalAmt].Text = StringsHelper.Format(Conversion.Val(StringsHelper.Format(txtDisplayLabel[conDlblLeaveAmtDue].Text, "########0.000")) + Conversion.Val(StringsHelper.Format(txtDisplayLabel[conDlblIndemnityAmtDue].Text, "########0.000")) + Conversion.Val(StringsHelper.Format(txtDisplayLabel[conDlblNetSalaryDue].Text, "########0.000")) + Conversion.Val(StringsHelper.Format(txtDisplayLabel[conDlblEarningDue].Text, "########0.000")) - Conversion.Val(StringsHelper.Format(txtDisplayLabel[conDlblLoanDue].Text, "########0.000")), "########0.000");

					CmbCommon_Click(CmbCommon[conCmbTerminationType], null);
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		public object GetLoanBalance()
		{

			string mysql = "";
			int mCntRow = 0;
			SqlDataReader rs = null;
			try
			{
				//'' Function Addded By Burhan Ghee Wala
				//'' Date: 21-Jul-2007
				//'' Desc: To calculate loan balance amount

				mysql = "select sum(total_balance) as amt,pbt.bill_no,pbt.l_bill_name ,pbt.bill_type_id ,'Temporary' as Mode ";
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					mysql = mysql + " , (select l_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) ";
				}
				else
				{
					mysql = mysql + " , (select a_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) ";
				}
				mysql = mysql + " as billmode , 'T' as mode_value";
				mysql = mysql + " from pay_loan ploan";
				mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = ploan.loan_cd";
				mysql = mysql + " left  join pay_employee pemp on ploan.emp_cd = pemp.emp_cd ";
				mysql = mysql + " where pemp.emp_no = '" + txtCommonTextBox[conTxtEmpCode].Text + "' and ploan.total_Balance > 0";
				mysql = mysql + " group by pbt.bill_no,pbt.l_bill_name,pbt.bill_type_id , pbt.bill_type_id";
				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rs = sqlCommand.ExecuteReader();
				rs.Read();
				//    mReturnValue = GetMasterCode(mySQL)
				do 
				{
					mCntRow = aVoucherDetails.GetLength(0);
					aVoucherDetails.RedimXArray(new int[]{aVoucherDetails.GetLength(0), conMaxColumns}, new int[]{0, 0});
					aVoucherDetails.SetValue(aVoucherDetails.GetLength(0), mCntRow, grdLineNoColumn);
					aVoucherDetails.SetValue(rs["bill_no"], mCntRow, grdBillingCodeColumn);
					aVoucherDetails.SetValue(rs["l_bill_name"], mCntRow, grdBillingNameColumn);
					aVoucherDetails.SetValue(rs["billmode"], mCntRow, grdBillingTypeColumn);
					aVoucherDetails.SetValue(rs["Mode"], mCntRow, grdBillingModeTextColumn);
					aVoucherDetails.SetValue(rs["mode_value"], mCntRow, grdBillingModeValueColumn);
					aVoucherDetails.SetValue(rs["bill_type_id"], mCntRow, grdBillTypeID);
					aVoucherDetails.SetValue(rs["amt"], mCntRow, grdAmtColumn);
					aVoucherDetails.SetValue(0, mCntRow, grdBillingDays);
					aVoucherDetails.SetValue(0, mCntRow, grdBillingHours);
					CalculateTotals(aVoucherDetails.GetLength(0), grdAmtColumn);
					mCntRow++;
				}
				while(rs.Read());
				rs.Close();
				CalculateTotals(mCntRow, grdAmtColumn);
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Refresh();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "");
			}

			return null;
		}


		public object GenerateFixedSalary()
		{

			string mysql = "";
			object mReturnValue = null;
			SqlDataReader rsTempRec = null;
			System.DateTime mWorkStartDate = DateTime.FromOADate(0);
			System.DateTime mWorkEndDate = DateTime.FromOADate(0);
			System.DateTime mGenerateDate = DateTime.FromOADate(0);
			double mActualWorkDays = 0;
			double mWorkedDays = 0;
			decimal mAmountPerDay = 0;
			double mLeaveTakenDays = 0;
			int mOfficialWDPerMonth = 0;
			int mTotalDaysInAMonth = 0;
			DataSet rs = null;

			try
			{

				if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType) && !Information.IsDate(txtVoucherDate.Value))
				{
					return null;
				}

				//''Back Dated termination entered then don't calculate salary for then
				if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value) < DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()))
				{
					return null;
				}

				mGenerateDate = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()); //mReturnValue
				//UPGRADE_WARNING: (1068) txtVoucherDate.Value of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mWorkEndDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value);

				mysql = " select pemp.emp_cd";
				mysql = mysql + " , pemp.dept_cd, pemp.desg_cd, pemp.last_salary_date, pemp.date_of_joining ";
				mysql = mysql + " , pemp.weekend, pemp.weekend_day1_id, pemp.weekend_day2_id ";
				mysql = mysql + " , pemp.days_per_month, pemp.rate_calc_method_id ";
				mysql = mysql + " , pemp.total_salary , pemp.hours_per_day , pemp.rate_per_day";
				mysql = mysql + " from pay_employee pemp ";
				mysql = mysql + " Where ";
				mysql = mysql + " pemp.status_cd = 1 ";
				mysql = mysql + " and (pemp.last_salary_date <'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText) + "'";
				mysql = mysql + " or pemp.last_salary_date is null ) ";
				mysql = mysql + " and pemp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsTempRec = sqlCommand.ExecuteReader();

				int mCntRow = 0;
				if (rsTempRec.Read())
				{
					if (Convert.ToDateTime(rsTempRec["date_of_joining"]) > DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()))
					{
						mWorkStartDate = Convert.ToDateTime(rsTempRec["date_of_joining"]); //CDate(GetPayrollGenerateStartDate)  '"01-" & Month(mGenerateDate) & "-" & Year(mGenerateDate))
					}
					else
					{
						if (Convert.IsDBNull(rsTempRec["last_salary_date"]))
						{
							mWorkStartDate = Convert.ToDateTime(rsTempRec["date_of_joining"]);
						}
						else
						{
							mWorkStartDate = DateTime.FromOADate(Convert.ToDouble(rsTempRec["last_salary_date"]) + 1); //CDate(GetPayrollGenerateStartDate) '
						}
					}

					mysql = "select * from v_pay_current_month_leave";
					mysql = mysql + " where emp_cd=" + Convert.ToString(rsTempRec["emp_cd"]);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						mLeaveTakenDays = 0;
					}
					else
					{
						if (Convert.ToDouble(rsTempRec["hours_per_day"]) > 0 && ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1)) > 0)
						{
							mLeaveTakenDays = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1)) / ((double) Convert.ToDouble(rsTempRec["hours_per_day"]));
						}
						else
						{
							mLeaveTakenDays = 0;
						}
					}
					//---End
					//''Modify  on 12-01-2012
					//''mWorkedDays = CalculateDays(mWorkStartDate, mWorkEndDate, .Fields("weekend_day1_id"), .Fields("weekend_day2_id"))
					if (mWorkStartDate <= ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value))
					{
						mWorkedDays = CalculateSalaryDays(mWorkStartDate);
					}
					else
					{
						mWorkedDays = 0;
					}
					mOfficialWDPerMonth = Convert.ToInt32(rsTempRec["days_per_month"]);
					mTotalDaysInAMonth = SystemHRProcedure.GetDaysInAMonth(mWorkEndDate, Convert.ToInt32(rsTempRec["weekend_day1_id"]), Convert.ToInt32(rsTempRec["weekend_day2_id"]));

					mysql = " select sum(case when pbt.bill_type_id = 51 then pp.lc_amount else pp.lc_amount * -1 end)";
					mysql = mysql + " from pay_payroll pp";
					mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = pp.bill_cd";
					mysql = mysql + " where pp.billing_mode = 'F' and pp.pay_date ='" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
					mysql = mysql + " and pp.emp_cd = " + SystemHRProcedure.GetEmpCd(txtCommonTextBox[conTxtEmpCode].Text).ToString();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					if (Convert.ToDouble(rsTempRec["rate_calc_method_id"]) == SystemHRProcedure.gFixedDays)
					{
						//''''''''''''Formula for calculating Actual work days in a month for Fixed Day
						//''''''''''''Weekend days are also considered
						//'ActualWorkDays = ((Worked Days + (Officail WD - Days In a month)) - Leave Taken Days)
						mAmountPerDay = (decimal) (Convert.ToDouble(rsTempRec["total_salary"]) / ((double) Convert.ToDouble(rsTempRec["days_per_month"])));
						if (mWorkEndDate >= mWorkStartDate)
						{
							mActualWorkDays = mWorkedDays; //((mWorkedDays + (mOfficialWDPerMonth - mTotalDaysInAMonth)) - mLeaveTakenDays)
						}
					}
					else if (Convert.ToDouble(rsTempRec["rate_calc_method_id"]) == SystemHRProcedure.gActualDays)
					{ 
						//''''''''''''Formula for calculating Actual work days in a month for Actual Day
						//''''''''''''Weekend days are also considered
						//'ActualWorkDays = Worked Day
						mActualWorkDays = mWorkedDays;
						mOfficialWDPerMonth = mTotalDaysInAMonth;
						mAmountPerDay = (decimal) (Convert.ToDouble(rsTempRec["Total_Salary"]) / ((double) mTotalDaysInAMonth));
					}
					else if (Convert.ToDouble(rsTempRec["rate_calc_method_id"]) == SystemHRProcedure.gDailyWages)
					{ 
						mActualWorkDays = mWorkedDays;
						mOfficialWDPerMonth = mTotalDaysInAMonth;
						mAmountPerDay = Convert.ToDecimal(rsTempRec["rate_per_day"]);
					}

					//        If Not IsNull(mReturnValue) Then
					//            mAmountPerDay = mReturnValue / mActualWorkDays
					//        Else
					//            mAmountPerDay = 0
					//        End If
					txtDisplayLabel[conDlblNetSalaryDays].Text = StringsHelper.Format(mActualWorkDays, "###,###,##0.000");
					//        txtDisplayLabel(conDlblNetSalaryPerDay).Text = Format(mAmountPerDay, "###,###,##0.000")
					//        txtDisplayLabel(conDlblNetSalaryDue).Text = Format(Round((mActualWorkDays * mAmountPerDay), 2), "###,###,##0.000")
					//        txtCommonNumber(conNTxtNetSalaryPaid).Value = Format(txtDisplayLabel(conDlblNetSalaryDue).Text, "###,###,##0.000")
					mCntRow = 0;
					rs = new DataSet();
					mysql = " select pbt.bill_no, pbt.l_bill_name ";
					mysql = mysql + " , (select l_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) as bill_type_id ";
					mysql = mysql + " , case when pebd.billing_mode = 'T' then 'Temporary' else 'Fixed' End as Mode ";
					mysql = mysql + " , pebd.billing_mode as mode_value, pebd.amount, pbt.bill_type_id ";
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						mysql = mysql + " , (select l_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) ";
					}
					else
					{
						mysql = mysql + " , (select a_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) ";
					}
					mysql = mysql + " as billmode";
					mysql = mysql + " from pay_billing_type pbt";
					mysql = mysql + " inner join pay_employee_billing_details pebd on pebd.bill_cd = pbt.bill_cd";
					mysql = mysql + " where pebd.emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
					SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rs.Tables.Clear();
					adap_2.Fill(rs);
					aVoucherDetails.RedimXArray(new int[]{rs.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
					foreach (DataRow iteration_row in rs.Tables[0].Rows)
					{
						aVoucherDetails.SetValue(mCntRow + 1, mCntRow, grdLineNoColumn);
						aVoucherDetails.SetValue(iteration_row["bill_no"], mCntRow, grdBillingCodeColumn);
						aVoucherDetails.SetValue(iteration_row["l_bill_name"], mCntRow, grdBillingNameColumn);
						aVoucherDetails.SetValue(iteration_row["billmode"], mCntRow, grdBillingTypeColumn);
						aVoucherDetails.SetValue(iteration_row["Mode"], mCntRow, grdBillingModeTextColumn);
						aVoucherDetails.SetValue(iteration_row["mode_value"], mCntRow, grdBillingModeValueColumn);
						aVoucherDetails.SetValue(iteration_row["bill_type_id"], mCntRow, grdBillTypeID);
						aVoucherDetails.SetValue(Math.Round((double) (mActualWorkDays * (Convert.ToDouble(iteration_row["Amount"]) / ((double) mOfficialWDPerMonth))), 2), mCntRow, grdAmtColumn);
						aVoucherDetails.SetValue(mActualWorkDays, mCntRow, grdBillingDays);
						aVoucherDetails.SetValue(mActualWorkDays * mHoursPerDay, mCntRow, grdBillingHours);
						mCntRow++;
					}
					CalculateTotals(mCntRow, grdAmtColumn);
					grdVoucherDetails.Rebind(true);
					grdVoucherDetails.Refresh();
				}
				else
				{
					txtDisplayLabel[conDlblNetSalaryDays].Text = "0.000";
					txtDisplayLabel[conDlblNetSalaryPerDay].Text = "0.000";
					txtDisplayLabel[conDlblNetSalaryDue].Text = "0.000";
					txtDisplayLabel[conDlblEarningDue].Text = "0.000";
					txtCommonNumber[conNTxtNetSalaryPaid].Value = 0;
					txtCommonNumber[conNTxtEarningPaid].Value = 0;
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "");
				this.Close();
			}
			return null;
		}

		private double CalculateSalaryDays(System.DateTime pStartDate)
		{
			object mReturnValue = null;
			string mGenerateDate = "";
			string mNextMonthStartDate = "";
			double mTotalDays = 0;
			double mActualDaysInMonth = 0;
			System.DateTime mdate = DateTime.FromOADate(0);

			try
			{

				mTotalDays = 0;
				//'modified by hakim on 08-dec-2011, problem occured with hydrotek, with null value in mreturnvalue
				//If Day(txtVoucherDate.Value) <> 1 Then

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select weekend_day1_id,weekend_day2_id,emp_cd,days_per_month,hours_per_day,rate_calc_method_id from pay_employee where emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'"));
				mTotalDays = 0;
				if (DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()) < pStartDate)
				{
					if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value) > DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()))
					{
						if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)) == SystemHRProcedure.gFixedDays)
						{
							mTotalDays += ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3));
						}
						else
						{
							mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();
							mActualDaysInMonth = SystemHRProcedure.CalculateDays(pStartDate, DateTime.Parse(mGenerateDate), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)));
							mTotalDays += mActualDaysInMonth;
						}
						mNextMonthStartDate = DateTimeHelper.ToString(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddMonths(1));
					}
					else
					{
						mGenerateDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("dd-MMM-yyyy");
						mActualDaysInMonth = SystemHRProcedure.CalculateDays(pStartDate, DateTime.Parse(mGenerateDate), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)));
						System.DateTime TempDate = DateTime.FromOADate(0);
						string tempRefParam = (DateTime.TryParse(DateTimeHelper.ToString(pStartDate), out TempDate)) ? TempDate.ToString("dd-MMM-yyyy") : DateTimeHelper.ToString(pStartDate);
						mTotalDays += SystemHRProcedure.GetAttendenceWorkedDays(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(3)), Convert.ToInt32(mActualDaysInMonth), ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(4)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(5)), false, 0, ref tempRefParam, ref mGenerateDate);
						//UPGRADE_WARNING: (1068) txtVoucherDate.Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mNextMonthStartDate = ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value);
					}
				}
				else if (DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()) == pStartDate)
				{ 
					if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value) > DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()))
					{
						if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)) == SystemHRProcedure.gFixedDays)
						{
							mTotalDays += ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3));
						}
						else
						{
							mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();
							mActualDaysInMonth = SystemHRProcedure.CalculateDays(pStartDate, DateTime.Parse(mGenerateDate), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)));
							mTotalDays += mActualDaysInMonth;
						}
						mNextMonthStartDate = DateTimeHelper.ToString(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddMonths(1));
					}
					else if (DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()) == ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value))
					{ 
						if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)) == SystemHRProcedure.gFixedDays)
						{
							mTotalDays += ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3));
						}
						else
						{
							mGenerateDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("dd-MMM-yyyy");
							mActualDaysInMonth = SystemHRProcedure.CalculateDays(pStartDate, DateTime.Parse(mGenerateDate), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)));
							mTotalDays += mActualDaysInMonth;
						}
						//UPGRADE_WARNING: (1068) txtVoucherDate.Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mNextMonthStartDate = ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value);
					}
					else
					{
						mGenerateDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("dd-MMM-yyyy");
						mActualDaysInMonth = SystemHRProcedure.CalculateDays(pStartDate, DateTime.Parse(mGenerateDate), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)));
						System.DateTime TempDate2 = DateTime.FromOADate(0);
						string tempRefParam2 = (DateTime.TryParse(DateTimeHelper.ToString(pStartDate), out TempDate2)) ? TempDate2.ToString("dd-MMM-yyyy") : DateTimeHelper.ToString(pStartDate);
						mTotalDays += SystemHRProcedure.GetAttendenceWorkedDays(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(3)), Convert.ToInt32(mActualDaysInMonth), ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(4)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(5)), false, 0, ref tempRefParam2, ref mGenerateDate);
						//UPGRADE_WARNING: (1068) txtVoucherDate.Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mNextMonthStartDate = ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value);
					}
				}


				//If Day(pStartDate) <> 1 Then
				//    mdate = DateSerial(Year(pStartDate), Month(pStartDate), 1)
				//    mdate = DateAdd("d", -1, DateAdd("m", 1, mdate))
				//    mTotalDays = CalculateDays(pStartDate, mdate, CInt(mReturnValue(0)), CInt(mReturnValue(1)))
				//    pStartDate = DateAdd("d", 1, mdate)
				//End If
				//If txtVoucherDate.Value > CDate(GetPayrollGenerateDate) Then
				//   If Day(txtVoucherDate.Value) <> 1 Then
				//      mNextMonthStartDate = Format(DateSerial(Year(txtVoucherDate.Value), Month(txtVoucherDate.Value), 1), "dd-MMM-yyyy")
				//      mTotalDays = mTotalDays + CalculateDays(CDate(mNextMonthStartDate), CDate(txtVoucherDate.Value), CInt(mReturnValue(0)), CInt(mReturnValue(1)))
				//      mNextMonthStartDate = Format(DateAdd("m", -1, CDate(mNextMonthStartDate)), "dd-MMM-yyyy")
				//   Else
				//      mNextMonthStartDate = Format(DateAdd("m", -1, CDate(txtVoucherDate.Value)), "dd-MMM-yyyy")
				//      mTotalDays = 1 ' Because severance Date is 01 of month
				//   End If
				//Else
				//   mNextMonthStartDate = GetPayrollGenerateStartDate
				//End If

				if (DateTime.Parse(mNextMonthStartDate) < ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value))
				{
					mdate = DateAndTime.DateSerial(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).Year, ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).Month, 1);
					while (DateTime.Parse(mNextMonthStartDate) != mdate)
					{
						if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)) == SystemHRProcedure.gFixedDays)
						{
							mTotalDays += ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3));
						}
						else
						{
							mGenerateDate = DateTime.Parse(mNextMonthStartDate).AddMonths(1).AddDays(-1).ToString("dd-MMM-yyyy");
							mActualDaysInMonth = SystemHRProcedure.CalculateDays(DateTime.Parse(mNextMonthStartDate), DateTime.Parse(mGenerateDate), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)));
							mTotalDays += mActualDaysInMonth;
						}
						mNextMonthStartDate = DateTime.Parse(mNextMonthStartDate).AddMonths(1).ToString("dd-MMM-yyyy");
					}
				}
				//''Calculation of current month
				if (DateTime.Parse(mNextMonthStartDate) != ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value))
				{
					if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value) > DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()))
					{
						mGenerateDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("dd-MMM-yyyy");
						mActualDaysInMonth = SystemHRProcedure.CalculateDays(DateTime.Parse(mNextMonthStartDate), DateTime.Parse(mGenerateDate), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)));
						mTotalDays += SystemHRProcedure.GetAttendenceWorkedDays(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(3)), Convert.ToInt32(mActualDaysInMonth), ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(4)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(5)), false, 0, ref mNextMonthStartDate, ref mGenerateDate);
					}
					else
					{
						mGenerateDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("dd-MMM-yyyy");
						mActualDaysInMonth = SystemHRProcedure.CalculateDays(DateTime.Parse(mNextMonthStartDate), DateTime.Parse(mGenerateDate), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)));
						mTotalDays += SystemHRProcedure.GetAttendenceWorkedDays(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(3)), Convert.ToInt32(mActualDaysInMonth), ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(4)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(5)), false, 0, ref mNextMonthStartDate, ref mGenerateDate);
					}
				}

				return mTotalDays;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			return 0;
		}

		public object GenerateTempEarDed()
		{
			try
			{
				string mysql = "";
				object mReturnValue = null;
				int mEmpCd = 0;
				SqlDataReader rs = null;
				string mEarString = "";
				string mDedString = "";
				int mCntRow = 0;
				int mTotalRow = 0;

				mEmpCd = SystemHRProcedure.GetEmpCd(txtCommonTextBox[conTxtEmpCode].Text);
				mCntRow = 0;
				mysql = " select pbt.bill_no, pbt.l_bill_name ";
				mysql = mysql + " , (select l_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) as bill_type_id ";
				mysql = mysql + " , case when pp.billing_mode = 'T' then 'Temporary' else 'Fixed' End as Mode ";
				mysql = mysql + " , pp.billing_mode as mode_value, pp.lc_amount, pbt.bill_type_id , pp.pay_hours, pp.pay_days";
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					mysql = mysql + " , (select l_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) ";
				}
				else
				{
					mysql = mysql + " , (select a_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) ";
				}
				mysql = mysql + " as billmode";
				mysql = mysql + " from pay_billing_type pbt";
				mysql = mysql + " inner join pay_payroll pp on pp.bill_cd = pbt.bill_cd";
				mysql = mysql + " where pp.emp_cd = " + mEmpCd.ToString() + " and pp.pay_date = ' " + SystemHRProcedure.GetPayrollGenerateDate() + "'";
				mysql = mysql + " and (pp.trans_type <> 'EmpBillTrn' or pp.trans_type is null)";
				mysql = mysql + " and ( pp.trans_id not in ( select pl.entry_id from pay_loan pl where pl.emp_cd =" + mEmpCd.ToString() + ")";
				mysql = mysql + " or pp.trans_id is null)";
				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rs = sqlCommand.ExecuteReader();
				rs.Read();

				do 
				{
					mCntRow = aVoucherDetails.GetLength(0);
					aVoucherDetails.RedimXArray(new int[]{aVoucherDetails.GetLength(0), conMaxColumns}, new int[]{0, 0});
					aVoucherDetails.SetValue(aVoucherDetails.GetLength(0), mCntRow, grdLineNoColumn);
					aVoucherDetails.SetValue(rs["bill_no"], mCntRow, grdBillingCodeColumn);
					aVoucherDetails.SetValue(rs["l_bill_name"], mCntRow, grdBillingNameColumn);
					aVoucherDetails.SetValue(rs["billmode"], mCntRow, grdBillingTypeColumn);
					aVoucherDetails.SetValue(rs["Mode"], mCntRow, grdBillingModeTextColumn);
					aVoucherDetails.SetValue(rs["mode_value"], mCntRow, grdBillingModeValueColumn);
					aVoucherDetails.SetValue(rs["bill_type_id"], mCntRow, grdBillTypeID);
					aVoucherDetails.SetValue(rs["lc_amount"], mCntRow, grdAmtColumn);
					aVoucherDetails.SetValue(rs["pay_days"], mCntRow, grdBillingDays);
					aVoucherDetails.SetValue(rs["pay_hours"], mCntRow, grdBillingHours);
					mCntRow++;
				}
				while(rs.Read());
				CalculateTotals(mCntRow, grdAmtColumn);
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Refresh();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "");
			}

			return null;
		}

		public bool UnPost()
		{

			bool result = false;
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				MessageBox.Show("Please select a valid posted voucher", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			if (mOldVoucherStatus == SystemVariables.VoucherStatus.stActive)
			{
				MessageBox.Show("Can not Unpost active vouchers!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = false;
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				return result;
			}

			string mysql = " select is_pay_closed from pay_employee_termination where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
			{
				MessageBox.Show("Can not unpost, Payroll month is closed!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			DialogResult ans = MessageBox.Show("Do you want to Unpost the Record ?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

			string myString = "";
			if (ans == System.Windows.Forms.DialogResult.Yes)
			{
				SystemVariables.gConn.BeginTransaction();

				//Call PayPostToHR("Pay_Employee_Termination", CLng(SearchValue))

				myString = "update Pay_Employee_Termination ";
				myString = myString + " set posted_HR = 0 ";
				myString = myString + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<int>(SearchValue).ToString();
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = myString;
				TempCommand.ExecuteNonQuery();

				//Call PayApprove("Pay_Employee_Termination", CLng(SearchValue))
				myString = "update Pay_Employee_Termination ";
				myString = myString + " set status = 1 ";
				myString = myString + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<int>(SearchValue).ToString();
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = myString;
				TempCommand_2.ExecuteNonQuery();


				Termination_Unpost_Effect(SearchValue);

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				SystemProcedure.AlarmStatusUpdate(9, ReflectionHelper.GetPrimitiveValue<int>(SearchValue), 0);
				return true;

			}
			else if (ans == System.Windows.Forms.DialogResult.No)
			{ 
				result = false;
				AddRecord();
				return result;
			}
			else if (ans == System.Windows.Forms.DialogResult.Cancel)
			{ 
				return false;
			}


			return result;
		}



		private void Termination_Unpost_Effect(object pSearchValue)
		{
			int mGLEntryID = 0;

			string mysql = " select leave_balance_days , emp_cd , leave_cd , gl_entry_id from Pay_Employee_Termination ";
			mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(3)))
			{
				mGLEntryID = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(3));
			}
			else
			{
				mGLEntryID = 0;
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(2)))
			{
				mysql = " update pay_employee_leave_details ";
				mysql = mysql + " set ";
				mysql = mysql + " paid_leave_taken_days = paid_leave_taken_days - " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				mysql = mysql + " where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				mysql = mysql + " and leave_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
			}

			mysql = " update pay_employee ";
			mysql = mysql + " set ";
			mysql = mysql + " termination_date = NULL ";
			mysql = mysql + " where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

			//mySQL = " update pay_employee "
			//mySQL = mySQL & " set status_cd = " & gStatusActive
			//mySQL = mySQL & " where emp_cd =" & mReturnValue(1)
			//gConn.Execute mySQL


			//''Added By Burhan Ghee Wala
			//''Date: 09-Jul-2007
			double mEmployeeWorkHrs = SystemHRProcedure.GetEmpPerDayHours(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)));
			int mWorkHorsEntryId = SystemHRProcedure.GetTAEntryID(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)), SystemHRProcedure.enumTAFields.eTAWorkHours, ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.DisplayText).Year, ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.DisplayText).Month);
			if (!SystemHRProcedure.UpdateAttendanceFieldsHours(ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText), SystemHRProcedure.GetPayrollGenerateDate(), mWorkHorsEntryId, mEmployeeWorkHrs, true))
			{
				return;
			}

			//' As on 08-Apr-2010 For GL Entry Delete
			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_gl_link")))
			{
				mysql = " delete from GL_Accnt_Trans_Details";
				mysql = mysql + " where entry_id = " + mGLEntryID.ToString();
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				mysql = " delete from GL_Accnt_Trans";
				mysql = mysql + " where entry_id = " + mGLEntryID.ToString();
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();
			}
			//'END

			mysql = "select emp_no from pay_employee where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				SystemHRProcedure.ClearPayroll(SystemHRProcedure.GetPayrollGenerateDate(), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue));
				SystemHRProcedure.GeneratePayrollEntry(SystemHRProcedure.GetPayrollGenerateDate(), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue));
				SystemHRProcedure.GenerateLeaveEntry(SystemHRProcedure.GetPayrollGenerateDate(), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue));
				SystemHRProcedure.GenerateLoanEntry(SystemHRProcedure.GetPayrollGenerateDate(), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mReturnValue));
			}
			//'''End

		}

		private bool PostGLTransaction()
		{
			try
			{
				string mSQL = "";
				object mReturnValue = null;
				int mEmpCd = 0;
				string mEmployeeName = "";
				object mDeptCd = null;
				object mLeaveExpCd = null;
				object mLeaveExpCostCd = null;
				object mLeaveProvisionCd = null;
				object mLeaveProvisionCostCd = null;
				object mIndemnityExpCd = null;
				object mIndemnityExpCostCd = null;
				object mIndemnityProvisionCd = null;
				object mIndemnityProvisionCostCd = null;
				object mSalaryExpCd = null;
				object mSalaryExpCostCd = null;
				object mSalaryControlCd = null;
				object mSalaryControlCostCd = null;
				int mGLVoucherType = 0;
				string mTerminationDate = "";
				string mVoucherNo = "";
				double mIndemnityAmt = 0;
				double mLeaveAmt = 0;
				double mIndemnityPaidAmt = 0;
				double mLeavePaidAmt = 0;
				double mDiffAmt = 0;
				object mPLLedgerCd = null;
				object mPILedgerCd = null;
				double mTotal = 0;
				string mAnalysisCd1 = "";
				string mAnalysisCd2 = "";
				string mAnalysisCd3 = "";
				string mAnalysisCd4 = "";
				string mAnalysisCd5 = "";
				//For Hajery Account Code
				string mSalaryControlAcc = "";
				string mLeaveExeAcc = "";
				string mLeaveProAcc = "";
				string mIndemExeAcc = "";
				string mIndemProAcc = "";
				//End
				int mGLEntryMethod = 0;

				//Dim mSalaryControlCd As Long
				//Dim mSalaryControlCostCd As Long
				double mTotalSalaryControlAmt = 0;
				SqlDataReader rs = null;
				string mFileName = "";
				string mMonthName = "";
				int pGLMethod = 0;
				string mEmpAnalysis1 = "";

				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				pGLMethod = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("pay_gl_entry_method"));
				mFileName = SystemVariables.gPayrollGLFilePath + SystemVariables.gDatabaseName + "_" + DateTimeFormatInfo.CurrentInfo.GetMonthName(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).Month) + "_" + ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).Year.ToString() + ".txt"; //Test.txt"

				if (pGLMethod == 4)
				{
					mMonthName = "Salary For the " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).Month) + " " + ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).Year.ToString();
					FileSystem.FileClose(1);
					FileSystem.FileOpen(1, mFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
				}

				mSQL = " select e.emp_cd, e.dept_cd, indemnity_amount_due, leave_amount_due, voucher_no, voucher_date, e.l_full_name ";
				mSQL = mSQL + " , indemnity_amount_paid, leave_amount_paid, analysis1 ";
				mSQL = mSQL + " from pay_employee_termination t inner join pay_employee e on e.emp_cd = t.emp_cd where t.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show(" Invalid Transaction!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDeptCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mIndemnityAmt = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLeaveAmt = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3));
					mVoucherNo = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(4));
					mTerminationDate = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(5)), SystemVariables.gSystemDateFormat);
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEmployeeName = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(6));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mIndemnityPaidAmt = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(7));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLeavePaidAmt = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(8));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mEmpAnalysis1 = (Convert.IsDBNull(((Array) mReturnValue).GetValue(9))) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(9));
				}

				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mGLVoucherType = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("pay_default_gl_voucher_type"));
				if (pGLMethod == 1)
				{ //If prefrence is set to department wise gl a/c
					//dept level salary legder and cost code
					mSQL = " select ldgr_cd, cost_cd from Pay_Department_GL_Details where dept_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mDeptCd) + " and bill_cd = 10";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mSalaryControlCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mSalaryControlCostCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}

					//dept leave exp legder and cost code
					mSQL = " select ldgr_cd, cost_cd from Pay_Department_GL_Details where dept_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mDeptCd) + " and bill_cd = 7";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLeaveExpCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLeaveExpCostCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}

					// dept leave Provision ledger code and cost center code
					mSQL = " select ldgr_cd, cost_cd from Pay_Department_GL_Details where dept_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mDeptCd) + " and bill_cd = 5";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLeaveProvisionCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLeaveProvisionCostCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}


					//Indemnity
					//old dept indemnity exp legder and cost code
					mSQL = " select ldgr_cd, cost_cd from Pay_Department_GL_Details where dept_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mDeptCd) + " and bill_cd = 9";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mIndemnityExpCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mIndemnityExpCostCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}
					//old dept indemnity Provision ledger code and cost center code
					mSQL = " select ldgr_cd, cost_cd from Pay_Department_GL_Details where dept_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mDeptCd) + " and bill_cd = 8";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mIndemnityProvisionCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mIndemnityProvisionCostCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}

				}
				else if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("pay_gl_entry_method")) == 2)
				{ 
					//dept level salary legder and cost code
					mSQL = " select ldgr_cd, cost_cd from Pay_Department_GL_Details where dept_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mDeptCd) + " and bill_cd = 10";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mSalaryControlCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mSalaryControlCostCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}

					//dept leave exp legder and cost code
					mSQL = " select ldgr_cd, cost_cd from Pay_Employee_GL_Details where emp_cd = " + mEmpCd.ToString() + " and bill_cd = 7";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLeaveExpCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLeaveExpCostCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}

					// dept leave Provision ledger code and cost center code
					mSQL = " select ldgr_cd, cost_cd from Pay_Employee_GL_Details where emp_cd = " + mEmpCd.ToString() + " and bill_cd = 5";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLeaveProvisionCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLeaveProvisionCostCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}


					//Indemnity
					//dept indemnity exp legder and cost code
					mSQL = " select ldgr_cd, cost_cd from Pay_Employee_GL_Details where emp_cd = " + mEmpCd.ToString() + " and bill_cd = 9";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mIndemnityExpCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mIndemnityExpCostCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}
					//dept indemnity Provision ledger code and cost center code
					mSQL = " select ldgr_cd, cost_cd from Pay_Employee_GL_Details where emp_cd = " + mEmpCd.ToString() + " and bill_cd = 8";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mIndemnityProvisionCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mIndemnityProvisionCostCd = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}
				}
				else if (pGLMethod == 4)
				{ 
					mSQL = " select Analysis2_Cd , Analysis3_Cd , Analysis1_Cd from Pay_Employee_GL_Details where emp_cd = " + mEmpCd.ToString() + " and bill_cd = 10";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mSalaryControlCd = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)) + "";
						mSalaryControlCostCd = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1)) + "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mSalaryControlAcc = (Convert.IsDBNull(((Array) mReturnValue).GetValue(2))) ? mEmpAnalysis1 : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
					}
					else
					{
						MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}

					//dept leave exp legder and cost code
					mSQL = " select Analysis2_Cd , Analysis3_Cd , Analysis1_Cd  from Pay_Employee_GL_Details where emp_cd = " + mEmpCd.ToString() + " and bill_cd = 7";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mLeaveExpCd = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)) + "";
						mLeaveExpCostCd = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1)) + "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mLeaveExeAcc = (Convert.IsDBNull(((Array) mReturnValue).GetValue(2))) ? mEmpAnalysis1 : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
					}
					else
					{
						MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}

					// dept leave Provision ledger code and cost center code
					mSQL = " select Analysis2_Cd , Analysis3_Cd , Analysis1_Cd  from Pay_Employee_GL_Details where emp_cd = " + mEmpCd.ToString() + " and bill_cd = 5";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mLeaveProvisionCd = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)) + "";
						mLeaveProvisionCostCd = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1)) + "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mLeaveProAcc = (Convert.IsDBNull(((Array) mReturnValue).GetValue(2))) ? mEmpAnalysis1 : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
					}
					else
					{
						MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}


					//Indemnity
					//dept indemnity exp legder and cost code
					mSQL = " select Analysis2_Cd , Analysis3_Cd , Analysis1_Cd from Pay_Employee_GL_Details where emp_cd = " + mEmpCd.ToString() + " and bill_cd = 9";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mIndemnityExpCd = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)) + "";
						mIndemnityExpCostCd = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1)) + "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mIndemExeAcc = (Convert.IsDBNull(((Array) mReturnValue).GetValue(2))) ? mEmpAnalysis1 : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
					}
					else
					{
						MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}

					//dept indemnity Provision ledger code and cost center code
					mSQL = " select Analysis2_Cd , Analysis3_Cd , Analysis1_Cd  from Pay_Employee_GL_Details where emp_cd = " + mEmpCd.ToString() + " and bill_cd = 8";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mIndemnityProvisionCd = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)) + "";
						mIndemnityProvisionCostCd = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1)) + "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mIndemProAcc = (Convert.IsDBNull(((Array) mReturnValue).GetValue(2))) ? mEmpAnalysis1 : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
					}
					else
					{
						MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}
				}

				//Passing GL Entry
				// Leave Accrual Entry, not yet started
				//desc: e.g if an employee terminates on 15-May-2008 then we have to accumulate his 15 day leave and indemnity accruals in GL
				//   1) Leave Expense A/c Dr
				//   2)    To Leave Prov A/c
				//   3) Indemnity Expense A/c Dr
				//   4)    TO Indemnity Prov A/c
				//after the accumulation entry, the indemnity and leave provision a/c will be nullified with the actual accruals as of termination date
				//by passing a reverse entry as below
				//   5) Leave Prov A/c Dr
				//   6)    To Leave Expense A/c
				//if leave balance is in minus then reverse entry will be passed.
				//   7) Indemnity Prov A/c Dr
				//   8)    To Indemnity Expense A/c

				string mGLVoucherNo = "";
				int mCnt = 0;
				if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("pay_gl_entry_method")) != 3)
				{
					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mPLLedgerCd = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetSystemPreferenceSetting("hr_payroll_pl_ledger_cd"));
					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mPILedgerCd = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetSystemPreferenceSetting("Payroll_GL_Indemnity_AC"));
					if (pGLMethod == 1 || pGLMethod == 2)
					{
						mGLVoucherNo = SystemProcedure2.GetNewNumber("gl_accnt_trans", " voucher_no ", 2, " voucher_type = " + mGLVoucherType.ToString());
						mReturnValue = SystemFAProcedure.FAInsertGLHeaderEntry(mGLVoucherType, mTerminationDate, Convert.ToInt32(Double.Parse(mGLVoucherNo)), mVoucherNo, "Being " + mEmployeeName + " terminated", 1, SystemVariables.gLoggedInUserCode);
					}
					if (mLeaveAmt > 0)
					{
						if (pGLMethod == 4)
						{
							if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
							{
								FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_1(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), 1, ReflectionHelper.GetPrimitiveValue<string>(mLeaveProvisionCd), ReflectionHelper.GetPrimitiveValue<string>(mLeaveProvisionCostCd), mEmpAnalysis1, txtCommonTextBox[conTxtEmpCode].Text, mMonthName, "JVGEN", mLeaveAmt));

								if (mLeavePaidAmt > 0)
								{
									FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_1(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), 1, ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCd), ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCostCd), mEmpAnalysis1, txtCommonTextBox[conTxtEmpCode].Text, mMonthName, "JVGEN", mLeavePaidAmt * -1));
								}
								if (mLeaveAmt != mLeavePaidAmt)
								{
									FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_1(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), 1, ReflectionHelper.GetPrimitiveValue<string>(mPLLedgerCd), "", mEmpAnalysis1, txtCommonTextBox[conTxtEmpCode].Text, mMonthName, "JVGEN", (mLeaveAmt - mLeavePaidAmt) * -1));
								}
							}
							else
							{
								FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_2(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), mLeaveProAcc, ReflectionHelper.GetPrimitiveValue<string>(mLeaveProvisionCd), ReflectionHelper.GetPrimitiveValue<string>(mLeaveProvisionCostCd), txtCommonTextBox[conTxtEmpCode].Text, "", mMonthName, "JV2500", mLeaveAmt));
								if (mLeavePaidAmt > 0)
								{
									FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_2(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), mSalaryControlAcc, ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCd), ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCostCd), txtCommonTextBox[conTxtEmpCode].Text, "", mMonthName, "JV2500", mLeavePaidAmt * -1));
								}
								if (mLeaveAmt != mLeavePaidAmt)
								{
									FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_2(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), ReflectionHelper.GetPrimitiveValue<string>(mPLLedgerCd), "", "", txtCommonTextBox[conTxtEmpCode].Text, "", mMonthName, "JV2500", (mLeaveAmt - mLeavePaidAmt) * -1));
								}
							}
						}
						else
						{
							SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mLeaveProvisionCd), ReflectionHelper.GetPrimitiveValue<string>(mLeaveProvisionCostCd), 1, (decimal) mLeaveAmt, (decimal) mLeaveAmt, "D", mTerminationDate, 1, 2, "");
							if (mLeavePaidAmt > 0)
							{
								SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCd), ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCostCd), 1, (decimal) (mLeavePaidAmt * -1), (decimal) (mLeavePaidAmt * -1), "C", mTerminationDate, 1, 2, "");
							}
							if (mLeaveAmt != mLeavePaidAmt)
							{
								SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mPLLedgerCd), "1", 1, (decimal) ((mLeaveAmt - mLeavePaidAmt) * -1), (decimal) ((mLeaveAmt - mLeavePaidAmt) * -1), "C", mTerminationDate, 1, 2, "");
							}
						}
					}
					else if (mLeaveAmt < 0)
					{  //if leave amount is in minus then a reverse entry will be generated
						SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mLeaveProvisionCd), ReflectionHelper.GetPrimitiveValue<string>(mLeaveProvisionCostCd), 1, (decimal) mLeaveAmt, (decimal) mLeaveAmt, "C", mTerminationDate, 1, 2, "");
						SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCd), ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCostCd), 1, (decimal) (mLeavePaidAmt * -1), (decimal) (mLeavePaidAmt * -1), "D", mTerminationDate, 1, 2, "");
						if (mLeaveAmt != mLeavePaidAmt)
						{
							SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mPLLedgerCd), "1", 1, (decimal) ((mLeaveAmt - mLeavePaidAmt) * 1), (decimal) ((mLeaveAmt - mLeavePaidAmt) * 1), "D", mTerminationDate, 1, 2, "");
						}
					}

					if (mIndemnityAmt > 0)
					{
						if (pGLMethod == 4)
						{
							if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
							{
								FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_1(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), 1, ReflectionHelper.GetPrimitiveValue<string>(mIndemnityProvisionCd), ReflectionHelper.GetPrimitiveValue<string>(mIndemnityProvisionCostCd), mEmpAnalysis1, txtCommonTextBox[conTxtEmpCode].Text, mMonthName, "JVGEN", mIndemnityAmt));
								if (mIndemnityPaidAmt > 0)
								{
									FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_1(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), 1, ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCd), ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCostCd), mEmpAnalysis1, txtCommonTextBox[conTxtEmpCode].Text, mMonthName, "JVGEN", mIndemnityPaidAmt * -1));
								}
								if (mIndemnityAmt != mIndemnityPaidAmt)
								{
									FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_1(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), 1, ReflectionHelper.GetPrimitiveValue<string>(mPILedgerCd), "", mEmpAnalysis1, txtCommonTextBox[conTxtEmpCode].Text, mMonthName, "JVGEN", (mIndemnityAmt - mIndemnityPaidAmt) * -1));
								}
							}
							else
							{
								FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_2(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), mIndemProAcc, ReflectionHelper.GetPrimitiveValue<string>(mIndemnityProvisionCd), ReflectionHelper.GetPrimitiveValue<string>(mIndemnityProvisionCostCd), txtCommonTextBox[conTxtEmpCode].Text, "", mMonthName, "JV2500", mIndemnityAmt));
								if (mIndemnityPaidAmt > 0)
								{
									FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_2(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), mSalaryControlAcc, ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCd), ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCostCd), txtCommonTextBox[conTxtEmpCode].Text, "", mMonthName, "JV2500", mIndemnityPaidAmt * -1));
								}
								if (mIndemnityAmt != mIndemnityPaidAmt)
								{
									FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_2(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), ReflectionHelper.GetPrimitiveValue<string>(mPILedgerCd), "", "", txtCommonTextBox[conTxtEmpCode].Text, "", mMonthName, "JV2500", (mIndemnityAmt - mIndemnityPaidAmt) * -1));
								}
							}
						}
						else
						{
							SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mIndemnityProvisionCd), ReflectionHelper.GetPrimitiveValue<string>(mIndemnityProvisionCostCd), 1, (decimal) mIndemnityAmt, (decimal) mIndemnityAmt, "D", mTerminationDate, 1, 2, "");
							if (mIndemnityPaidAmt > 0)
							{
								SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCd), ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCostCd), 1, (decimal) (mIndemnityPaidAmt * -1), (decimal) (mIndemnityPaidAmt * -1), "C", mTerminationDate, 1, 2, "");
							}
							if (mIndemnityAmt != mIndemnityPaidAmt)
							{
								SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mPILedgerCd), "1", 1, (decimal) ((mIndemnityAmt - mIndemnityPaidAmt) * -1), (decimal) ((mIndemnityAmt - mIndemnityPaidAmt) * -1), "C", mTerminationDate, 1, 2, "");
							}
						}
					}
					else if (mIndemnityAmt < 0)
					{  //if leave amount is in minus then a reverse entry will be generated
						SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mIndemnityProvisionCd), ReflectionHelper.GetPrimitiveValue<string>(mIndemnityProvisionCostCd), 1, (decimal) mIndemnityAmt, (decimal) mIndemnityAmt, "C", mTerminationDate, 1, 2, "");
						SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCd), ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCostCd), 1, (decimal) (mIndemnityAmt * -1), (decimal) (mIndemnityAmt * -1), "D", mTerminationDate, 1, 2, "");
						if (mIndemnityAmt != mIndemnityPaidAmt)
						{
							SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mPILedgerCd), "1", 1, (decimal) ((mIndemnityAmt - mIndemnityPaidAmt) * 1), (decimal) ((mIndemnityAmt - mIndemnityPaidAmt) * 1), "D", mTerminationDate, 1, 2, "");
						}
					}
					//End Passing GL Entry
					//''' As On 07-Apr-2010
					mSQL = " select  pegd.Ldgr_Cd, pegd.Cost_Cd, petpd.lc_amount,petpd.lc_amount,pbt.bill_type_id,pegd.analysis1_cd,pegd.analysis2_cd ";
					mSQL = mSQL + " ,pegd.analysis3_cd,pegd.analysis4_cd,pegd.analysis5_cd";
					mSQL = mSQL + " From pay_employee_termination_payroll_details petpd ";
					mSQL = mSQL + " inner join pay_employee_gl_details pegd on pegd.emp_cd = petpd.emp_cd and pegd.bill_cd = petpd.bill_Cd ";
					mSQL = mSQL + " inner join pay_billing_type pbt on pbt.bill_cd = pegd.bill_cd ";
					mSQL = mSQL + " where termination_entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

					mCnt = 0;

					SqlCommand sqlCommand = new SqlCommand(mSQL, SystemVariables.gConn);
					rs = sqlCommand.ExecuteReader();
					rs.Read();
					do 
					{
						if (Convert.IsDBNull(rs["analysis1_cd"]))
						{
							mAnalysisCd1 = "";
						}
						else
						{
							mAnalysisCd1 = Convert.ToString(rs["analysis1_cd"]);
						}
						if (Convert.IsDBNull(rs["analysis2_cd"]))
						{
							mAnalysisCd2 = "";
						}
						else
						{
							mAnalysisCd2 = Convert.ToString(rs["analysis2_cd"]);
						}
						if (Convert.IsDBNull(rs["analysis3_cd"]))
						{
							mAnalysisCd3 = "";
						}
						else
						{
							mAnalysisCd3 = Convert.ToString(rs["analysis3_cd"]);
						}
						if (Convert.IsDBNull(rs["analysis4_cd"]))
						{
							mAnalysisCd4 = "";
						}
						else
						{
							mAnalysisCd4 = Convert.ToString(rs["analysis4_cd"]);
						}
						if (Convert.IsDBNull(rs["analysis5_cd"]))
						{
							mAnalysisCd5 = "";
						}
						else
						{
							mAnalysisCd5 = Convert.ToString(rs["analysis5_cd"]);
						}
						mCnt++;

						if (Convert.ToDouble(rs["bill_type_id"]) == 51)
						{
							if (pGLMethod == 4)
							{
								if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
								{
									FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_1(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), 1, mAnalysisCd2, mAnalysisCd3, (mAnalysisCd1 == "") ? mEmpAnalysis1 : mAnalysisCd1, mAnalysisCd4, mMonthName, "JVGEN", Convert.ToDouble(rs["lc_amount"])));
								}
								else
								{
									FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_2(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), mAnalysisCd1, mAnalysisCd2, mAnalysisCd3, mAnalysisCd4, mAnalysisCd5, mMonthName, "JV2500", Convert.ToDouble(rs["lc_amount"])));
								}
							}
							else
							{
								SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), Convert.ToString(rs["Ldgr_Cd"]), Convert.ToString(rs["Cost_Cd"]), 1, Convert.ToDecimal(rs["lc_amount"]), Convert.ToDecimal(rs["lc_amount"]), "D", mTerminationDate, 1, 2, "", 0, mAnalysisCd1, mAnalysisCd2);
							}
							mTotal += Convert.ToDouble(rs["lc_amount"]);
						}
						else
						{
							if (pGLMethod == 4)
							{
								if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
								{
									FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_1(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), 1, mAnalysisCd2, mAnalysisCd3, (mAnalysisCd1 == "") ? mEmpAnalysis1 : mAnalysisCd1, mAnalysisCd4, mMonthName, "JVGEN", Convert.ToDouble(rs["lc_amount"]) * -1));
								}
								else
								{
									FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_2(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), mAnalysisCd1, mAnalysisCd2, mAnalysisCd3, mAnalysisCd4, mAnalysisCd5, mMonthName, "JV2500", Convert.ToDouble(rs["lc_amount"]) * -1));
								}
							}
							else
							{
								SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), Convert.ToString(rs["Ldgr_Cd"]), Convert.ToString(rs["Cost_Cd"]), 1, (decimal) (Convert.ToDouble(rs["lc_amount"]) * -1), (decimal) (Convert.ToDouble(rs["lc_amount"]) * -1), "C", mTerminationDate, 1, 2, "", 0, mAnalysisCd1, mAnalysisCd2);
							}
							mTotal += (Convert.ToDouble(rs["lc_amount"]) * -1);
						}
					}
					while(rs.Read());

					if (pGLMethod == 4)
					{
						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
						{
							FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_1(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), 1, ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCd), ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCostCd), "", txtCommonTextBox[conTxtEmpCode].Text, mMonthName, "JVGEN", mTotal * -1));
						}
						else
						{
							FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_2(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).ToString("yyyyMMdd"), mSalaryControlAcc, ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCd), ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCostCd), txtCommonTextBox[conTxtEmpCode].Text, "", mMonthName, "JV2500", mTotal * -1));
						}
					}
					else
					{
						SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCd), ReflectionHelper.GetPrimitiveValue<string>(mSalaryControlCostCd), 1, (decimal) (mTotal * -1), (decimal) (mTotal * -1), "C", mTerminationDate, 1, 2, "");
					}
					rs.Close();
					//'''End
					if (pGLMethod == 1 || pGLMethod == 2)
					{
						mSQL = " update gl_accnt_trans set linked = 1, linked_entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ", linked_module_id = 8, linked_type_flag = 12 where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mSQL;
						TempCommand.ExecuteNonQuery();

						mSQL = " update pay_employee_termination set gl_entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mSQL;
						TempCommand_2.ExecuteNonQuery();
					}
					else
					{
						FileSystem.FileClose(1);
					}
				}
				return true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public void IRoutine()
		{
			int mCurrentLineNo = 0;

			if (ActiveControl.Name != "grdVoucherDetails" && grdVoucherDetails.Enabled)
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
			if (ActiveControl.Name != "grdVoucherDetails" && grdVoucherDetails.Enabled)
			{
				grdVoucherDetails.Focus();
			}

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdVoucherDetails.Delete();
				AssignGridLineNumbers();
				CalculateTotals(0, 1);
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
				case grdBillingCodeColumn : case grdBillingNameColumn : 
					if (grdVoucherDetails.Col == grdBillingCodeColumn)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("bill_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("bill_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("bill_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("bill_name");
					} 
					 
					int tempForEndVar = cmbMastersList.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersList.Splits[0].DisplayColumns[cnt];
						if (cnt < 4)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == grdBillingCodeColumn) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdBillingCodeColumn].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == grdBillingCodeColumn) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdBillingNameColumn].Width;
							}
							else if (cnt == 2)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdBillingTypeColumn].Width;
							}
							else if (cnt == 3)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdBillingModeTextColumn].Width;
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			if (grdVoucherDetails.Col == grdBillingCodeColumn || grdVoucherDetails.Col == grdBillingNameColumn)
			{
				if (grdVoucherDetails.Col == grdBillingCodeColumn)
				{
					grdVoucherDetails.Columns[grdBillingNameColumn].Value = cmbMastersList.Columns[1].Value;
				}
				else
				{
					grdVoucherDetails.Columns[grdBillingCodeColumn].Value = cmbMastersList.Columns[0].Value;
				}
				grdVoucherDetails.Columns[grdBillingTypeColumn].Value = cmbMastersList.Columns[2].Value;
				grdVoucherDetails.Columns[grdBillingModeTextColumn].Value = cmbMastersList.Columns[3].Value;
				grdVoucherDetails.Columns[grdBillingModeValueColumn].Value = cmbMastersList.Columns[4].Value;
				grdVoucherDetails.Columns[grdBillingLinkedLeaveColumn].Value = cmbMastersList.Columns[5].Value;
				grdVoucherDetails.Columns[grdBillingAmtColumn].Value = cmbMastersList.Columns[6].Value;
				grdVoucherDetails.Columns[grdOverTime].Value = cmbMastersList.Columns[7].Value;
				grdVoucherDetails.Columns[grdBillTypeID].Value = cmbMastersList.Columns[8].Value;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			switch(grdVoucherDetails.Col)
			{
				case grdBillingCodeColumn : 
					grdVoucherDetails.Col = grdBillingNameColumn; 
					break;
			}
		}

		private void DefineMasterRecordset()
		{
			string mysql = "";

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				return;
			}

			if (mFirstGridFocus)
			{
				mysql = " select bill_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_bill_name as bill_name" : "a_bill_name as bill_name");
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					mysql = mysql + " , (select l_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) ";
				}
				else
				{
					mysql = mysql + " , (select a_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) ";
				}
				mysql = mysql + " , case when pebd.billing_mode = 'T' then 'Temporary' else 'Fixed' End as Mode ";
				mysql = mysql + " , pebd.billing_mode as mode_value ";
				mysql = mysql + " , case when pebd.billing_mode = 'T' then '1' else '0' End as LinkedLeave ";
				mysql = mysql + " , case when pebd.billing_mode = 'T' then " + mBasicSalary.ToString() + " else amount End as amount ";
				mysql = mysql + " , pbt.over_time as over_time ";
				mysql = mysql + " , pbt.bill_type_id as bill_type_id "; //''''''
				mysql = mysql + " from pay_billing_type pbt ";
				mysql = mysql + " inner join Pay_Employee_Billing_Details pebd on pbt.bill_cd = pebd.bill_cd ";
				mysql = mysql + " where pebd.emp_cd = " + SystemHRProcedure.GetEmpCd(txtCommonTextBox[conTxtEmpCode].Text).ToString();
				mysql = mysql + " and pbt.show = 1";
				mysql = mysql + " Union all ";
				mysql = mysql + " select bill_no  , l_bill_name as bill_name ";
				mysql = mysql + " , (select l_object_caption from SM_Objects sobj ";
				mysql = mysql + " where sobj.object_id = pbt.bill_type_id) ";
				mysql = mysql + " , 'Temporary' as Mode ";
				mysql = mysql + " , 'T' as mode_value ";
				mysql = mysql + " , 'B' as LinkedLeave ";
				mysql = mysql + " , case when pbt.over_time = 1 or pbt.over_time = 2 or pbt.over_time = 3 then " + mBasicSalary.ToString() + " else 0 end as amount ";
				mysql = mysql + " , pbt.over_time as over_time ";
				mysql = mysql + " , pbt.bill_type_id as bill_type_id "; //''''''
				mysql = mysql + " from pay_billing_type pbt ";
				//mySql = mySql & " left join Pay_Employee_Billing_Details pebd on pbt.bill_cd = pebd.bill_cd "
				mysql = mysql + " Where Not Exists ";
				mysql = mysql + " ( select bill_cd from Pay_Employee_Billing_Details pebd1 ";
				mysql = mysql + " Where pbt.bill_cd = pebd1.bill_cd ";
				mysql = mysql + " and pebd1.emp_cd = " + SystemHRProcedure.GetEmpCd(txtCommonTextBox[conTxtEmpCode].Text).ToString();
				mysql = mysql + " )";
				mysql = mysql + " and pbt.show = 1";
				mysql = mysql + " order by 1 ";

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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			grdVoucherDetails.Columns[grdLineNoColumn].Text = (grdVoucherDetails.RowCount + 1).ToString();
			grdVoucherDetails.Columns[grdAmtColumn].Text = "0";

			//''''This cause the focus to be lost from billing code for the first time when a new row is added
			//grdVoucherDetails.Update
			//grdVoucherDetails.Refresh
		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdVoucherDetails.Col > 0 && LastCol > 0 && !mFirstGridFocus)
			{
				switch(grdVoucherDetails.Col)
				{
					case grdBillingCodeColumn : case grdBillingNameColumn : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList); 
						break;
				}
			}
		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			if (ColIndex == grdAmtColumn || ColIndex == grdBillingDays || ColIndex == grdBillingHours)
			{
				grdVoucherDetails.UpdateData();
				CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);
				grdVoucherDetails.Refresh();
			}
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

		private void RefreshRecord()
		{
			int cnt = 0;
			int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				grdVoucherDetails.Columns[cnt].FooterText = "";
			}

			//mCurrentFormMode = frmAddMode                           'Change the form mode to addmode

			DefineVoucherArray(-1, true);
			AssignGridLineNumbers();
			grdVoucherDetails.Rebind(true);
			//grdVoucherDetails.Enabled = False

			mSearchValue = ""; //Change the msearchvalue to blank
			//mPayrollDate = ""
			mFirstGridFocus = true;

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
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, conMaxColumns}, new int[]{0, 0});
		}

		private void CalculateTotals(int mRowNumber, int mColNumber)
		{
			int cnt = 0;

			double mTotalAmount = 0;
			double mBasicSalaryDays = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdBillTypeID)) == 51)
				{
					mTotalAmount += Conversion.Val(Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdAmtColumn)).ToString());
				}
				else
				{
					mTotalAmount -= Conversion.Val(Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdAmtColumn)).ToString());
				}
				if (Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdBillingCodeColumn)) == 1)
				{
					mBasicSalaryDays = Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdBillingDays));
				}
			}
			//Assign Basic Salary Days
			txtDisplayLabel[conDlblNetSalaryDays].Text = mBasicSalaryDays.ToString();

			if (mTotalAmount != 0)
			{
				grdVoucherDetails.Columns[grdAmtColumn].FooterText = StringsHelper.Format(mTotalAmount, "###,###,###,###,##0.000");
				txtDisplayLabel[conDlblNetSalaryDue].Text = StringsHelper.Format(mTotalAmount, "###,###,###,###,##0.000");
				txtDisplayLabel[conDlblSTNetSalaryDue].Text = StringsHelper.Format(mTotalAmount, "############0.000");
				txtCommonNumber[conNTxtNetSalaryPaid].Value = StringsHelper.Format(mTotalAmount, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails.Columns[grdAmtColumn].FooterText = "";
				txtDisplayLabel[conDlblNetSalaryDue].Text = "0.000";
				txtDisplayLabel[conDlblSTNetSalaryDue].Text = "0.000";
				txtCommonNumber[conNTxtNetSalaryPaid].Value = 0;
			}
		}

		private int GetBillCd(int pBillNo)
		{

			string mysql = "select bill_cd from pay_billing_type where bill_no = " + pBillNo.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				return 0;
			}
			else
			{
				return ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}
		}
	}
}