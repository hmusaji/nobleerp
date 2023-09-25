
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPaySalaryVariation
		: System.Windows.Forms.Form
	{

		
		public frmPaySalaryVariation()
{
InitializeComponent();
} 
 public  void frmPaySalaryVariation_old()
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
		private const int grdBillingCodeColumn = 1;
		private const int grdBillingNameColumn = 2;
		private const int grdBillingTypeColumn = 3;
		private const int grdCurrentAmtColumn = 4;
		private const int grdIncrementAmtColumn = 5;
		private const int grdTotalAmtColumn = 6;
		private const int grdIncludeInLeave = 7;
		private const int grdIncludeInIndemnity = 8;
		private const int grdEndDate = 9;
		private const int grdIsPeriodic = 10;
		private const int grdRemarksColumn = 11;


		private const int conTxtVoucherNo = 0;
		private const int conTxtEmpCode = 1;
		private const int conTxtComments = 2;
		private const int conTXTReferenceNo = 3;
		private const int conTXTNewDesignationCd = 4;
		private const int conTXTNewDepartmentCd = 5;
		private const int conTxtBudgetHeadCount = 72;
		private const int conTxtOldBudgetHeadCount = 6;

		private const int conDlblEmpName = 0;
		private const int conDlblBasicSalary = 1;
		private const int conDlblDesgCode = 2;
		private const int conDlblDesgName = 3;
		private const int conDlblTotalSalary = 4;
		private const int conDlblDeptCode = 5;
		private const int conDlblDeptName = 6;
		private const int conDlblNewDesgName = 8;
		private const int conDlblNewDeptName = 10;
		private const int conDlblHeadCount = 18;
		private const int conDlblOldHeadCount = 7;

		private const int conCmbPaymentType = 1;
		private const int conCmbNewPaymentType = 0;

		private const int contabSalaryVAriation = 0;
		private const int contabEmployeeDetail = 1;
		private const int contabApproval = 2;
		int mTemplateEntID = 0;

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


		private void chkBudget_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			if (chkBudget.CheckState == CheckState.Checked)
			{
				txtCommonTextBox[conTxtOldBudgetHeadCount].Enabled = true;
				txtCommonTextBox[conTxtOldBudgetHeadCount].Locked = false;
			}
			else
			{
				txtCommonTextBox[conTxtOldBudgetHeadCount].Enabled = false;
				txtCommonTextBox[conTxtOldBudgetHeadCount].Locked = true;
			}
		}

		private void cmbType_Click(Object Sender, EventArgs e)
		{
			txtCommonTextBox[conTXTNewDepartmentCd].Enabled = false;
			txtCommonTextBox[conTXTNewDesignationCd].Enabled = false;
			grdVoucherDetails.Enabled = false;
			if (cmbType.GetItemData(cmbType.ListIndex) == 3)
			{ // If Transfer
				txtCommonTextBox[conTXTNewDepartmentCd].Enabled = true;
				txtCommonTextBox[conTXTNewDesignationCd].Enabled = true;
			}
			else if (cmbType.GetItemData(cmbType.ListIndex) == 4)
			{  // If Promotion
				txtCommonTextBox[conTXTNewDepartmentCd].Enabled = true;
				txtCommonTextBox[conTXTNewDesignationCd].Enabled = true;
				grdVoucherDetails.Enabled = true;
			}
			else if (cmbType.GetItemData(cmbType.ListIndex) == 5)
			{  // If Increment
				grdVoucherDetails.Enabled = true;
			}
			else
			{
				//other than above
				txtCommonTextBox[conTXTNewDepartmentCd].Enabled = true;
				txtCommonTextBox[conTXTNewDesignationCd].Enabled = true;
				grdVoucherDetails.Enabled = true;
			}

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
						SystemHRProcedure.ApprovalSubmmit(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 8, mTemplateEntID, "Salary Variation For Emp No :" + txtCommonTextBox[conTxtEmpCode].Text);
						AddRecord();
						MessageBox.Show("Approval Submitted Successfully::", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			else
			{
				if (SystemHRProcedure.CheckApprovalIsSubmmited(8, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue)))
				{
					if (saveRecord())
					{
						SystemHRProcedure.ApprovalSubmmit(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 8, mTemplateEntID, "Salary Variation For Emp No :" + txtCommonTextBox[conTxtEmpCode].Text);
						AddRecord();
						MessageBox.Show("Approval Submitted Successfully::", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else
				{
					MessageBox.Show("All ready Submitted for this record:", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
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


				FirstFocusObject = txtCommonTextBox[conTxtVoucherNo];
				//picFormToolbar.Visible = False
				grdVoucherDetails.Visible = false;

				this.Top = 0;
				this.Left = 0;


				//**format & define the new toolbar
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
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowUnpostButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);


				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //setting form mode to add initially
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
				mFirstGridFocus = true;


				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.9f);
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing No.", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing Name", 2700, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing Type", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "T o t a l");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Current Amt.", 900, false, SystemConstants.gDisableColumnBackColor, (0x295C36).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Increment Amt.", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Total Amt.", 900, false, SystemConstants.gDisableColumnBackColor, (0x295C36).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Include In Leave", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Include In Indemnity", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "End Date", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "txtTempDate");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Is Periodic", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 50);

				//setting voucher details grid properties
				DefineVoucherArray(0, true);
				AssignGridLineNumbers();

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				//-- end of voucher grid property setting

				txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_salary_variation", "voucher_no");

				txtVoucherDate.Value = DateTime.Today;
				txtEffectiveDate.Value = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate());
				grdVoucherDetails.Visible = true;
				string mysql = "";
				mysql = " select ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_type_name" : " a_type_name");
				mysql = mysql + " ,Promo_Type_Cd from pay_promotion_type ";
				SystemCombo.FillComboWithItemData(cmbType, mysql);
				if (cmbType.ListCount > 0)
				{
					cmbType.ListIndex = 0;
				}
				this.tabSalaryVariation.CurrTab = Convert.ToInt16(contabSalaryVAriation);
				this.tabSalaryVariation.set_TabVisible(Convert.ToInt16(contabApproval), SystemHRProcedure.IsApprovalEnabled(8));

				object[] mObjectId = new object[2];
				mObjectId[conCmbNewPaymentType] = 1007;
				mObjectId[conCmbPaymentType] = 1007;

				SystemCombo.FillComboWithSystemObjects(cmbCommon, mObjectId);

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("HR_Budget")))
				{
					this.tabSalaryVariation.set_TabVisible(3, true);
					txtCommonTextBox[conTxtBudgetHeadCount].Enabled = true;
					chkBudget.Enabled = true;
					chkBudget.CheckState = CheckState.Unchecked;
				}
				else
				{
					this.tabSalaryVariation.set_TabVisible(3, false);
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
				//Refresh the product recordset when F5 is pressed
				if (Shift == 0 && KeyCode == 116 && !mFirstGridFocus)
				{
					DefineMasterRecordset();
				}

				//if the user presses any control key in the voucher grid object
				if (this.ActiveControl.Name == "grdVoucherDetails")
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
					if (Shift == 0)
					{
						if (grdVoucherDetails.Col == grdIncrementAmtColumn)
						{
							if ((KeyCode == 8) || (KeyCode == 46) || (KeyCode == 27) || (KeyCode == 109))
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
				}
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
				frmPaySalaryVariation.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
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
				grdVoucherDetails.Columns[grdCurrentAmtColumn].Value = cmbMastersList.Columns[3].Value;
				grdVoucherDetails.Columns[grdIncludeInLeave].Value = cmbMastersList.Columns[4].Value;
				grdVoucherDetails.Columns[grdIncludeInIndemnity].Value = cmbMastersList.Columns[5].Value;
				grdVoucherDetails.Columns[grdIncrementAmtColumn].Value = 0;
				//grdVoucherDetails.ReBind
				grdVoucherDetails.Refresh();
			}
		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			if (ColIndex == grdIncrementAmtColumn)
			{
				grdVoucherDetails.UpdateData();
				CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);
				grdVoucherDetails.Refresh();
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == grdCurrentAmtColumn || ColIndex == grdIncrementAmtColumn || ColIndex == grdTotalAmtColumn)
			{
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(Value))
				{
					if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
					{
						Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###,###,###.000");
					}
					else
					{
						Value = "";
					}
				}
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


		private void CalculateTotals(int mRowNumber, int mColNumber)
		{
			int cnt = 0;

			double mTotalCurrentAmount = 0;
			double mTotalIncrementAmount = 0;


			aVoucherDetails.SetValue(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, grdCurrentAmtColumn))) + Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, grdIncrementAmtColumn))), mRowNumber, grdTotalAmtColumn);

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingTypeColumn)) == "Earnings")
				{
					mTotalIncrementAmount += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdIncrementAmtColumn)));
					mTotalCurrentAmount += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdCurrentAmtColumn)));
				}
				else
				{
					mTotalIncrementAmount -= Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdIncrementAmtColumn)));
					mTotalCurrentAmount -= Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdCurrentAmtColumn)));
				}
			}

			if (mTotalCurrentAmount != 0)
			{
				grdVoucherDetails.Columns[grdCurrentAmtColumn].FooterText = StringsHelper.Format(mTotalCurrentAmount, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails.Columns[grdCurrentAmtColumn].FooterText = "";
			}

			if (mTotalIncrementAmount != 0)
			{
				grdVoucherDetails.Columns[grdIncrementAmtColumn].FooterText = StringsHelper.Format(mTotalIncrementAmount, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails.Columns[grdIncrementAmtColumn].FooterText = "";
			}

			if ((mTotalCurrentAmount + mTotalIncrementAmount) > 0)
			{
				grdVoucherDetails.Columns[grdTotalAmtColumn].FooterText = StringsHelper.Format(mTotalCurrentAmount + mTotalIncrementAmount, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails.Columns[grdTotalAmtColumn].FooterText = "";
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
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, 11}, new int[]{0, 0});
		}

		public bool saveRecord(bool pApprove = false)
		{
			bool result = false;
			object mReturnValue = null;
			double mRetroactiveDays = 0;
			int mEmpCode = 0;
			int mDeptCode = 0;
			int mDesgCode = 0;
			int mBillingCode = 0;
			int mNewDeptCode = 0;
			int mNewDesgCode = 0;
			int mBillingType = 0;
			double mTempDays = 0;
			int mBank = 0;
			int mNewBank = 0;
			int mGrade = 0;
			int mNewGrade = 0;
			int mTransferBankId = 0;
			int mNewTransferBankId = 0;

			int mIncludeInIndemnity = 0;
			int mIncludeInLeave = 0;
			int mIsPeriodic = 0;
			int cnt = 0;
			string mysql = "";
			int mNewHCCd = 0;
			int mOldHCCd = 0;
			int mDefaultProjectCd = 0;
			int mDefaultProjectCdNew = 0;

			try
			{

				mysql = "select emp_cd , dept_cd, desg_cd, bank_cd , Grade_Cd , Transfer_Bank_Entry_Id ";
				mysql = mysql + " from pay_employee where ";
				mysql = mysql + " emp_no = '" + txtCommonTextBox[conTxtEmpCode].Text + "'";

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
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDeptCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDesgCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2));
					if (!SystemProcedure2.IsItEmpty(((Array) mReturnValue).GetValue(3), SystemVariables.DataType.NumberType))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mBank = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(3));
					}
					else
					{
						mBank = 0;
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(4)))
					{
						mGrade = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(4));
					}
					else
					{
						mGrade = 0;
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(5)))
					{
						mTransferBankId = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(5));
					}
					else
					{
						mTransferBankId = 0;
					}
				}


				mysql = "select desg_cd ";
				mysql = mysql + " from pay_designation where ";
				mysql = mysql + " desg_no = '" + txtCommonTextBox[conTXTNewDesignationCd].Text + "'";

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Designation Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtCommonTextBox[conTXTNewDesignationCd].Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mNewDesgCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				if (!SystemProcedure2.IsItEmpty(txtNewBankCd.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select bank_cd ";
					mysql = mysql + " from sm_bank where ";
					mysql = mysql + " bank_no = '" + txtNewBankCd.Text + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid New Bank Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						txtNewBankCd.Focus();
						return result;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mNewBank = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				else
				{
					mNewBank = 0;
				}

				if (!SystemProcedure2.IsItEmpty(txtNewCompBank.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select pbd.entry_id ";
					mysql = mysql + " from sm_bank b inner join pay_bank_details pbd on pbd.bank_cd = b.bank_cd where ";
					mysql = mysql + " b.bank_no = " + txtNewCompBank.Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid New Company Bank Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						txtNewCompBank.Focus();
						return result;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mNewTransferBankId = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				else
				{
					mNewTransferBankId = 0;
				}


				if (!SystemProcedure2.IsItEmpty(txtDefaultProjectNew.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select project_cd from PROJ_Projects ";
					mysql = mysql + " where project_no ='" + txtDefaultProjectNew.Text + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Project Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						throw new Exception();
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mDefaultProjectCdNew = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				else
				{
					mDefaultProjectCdNew = 0;
				}


				if (!SystemProcedure2.IsItEmpty(txtDefaultProjectDispl.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select project_cd from PROJ_Projects ";
					mysql = mysql + " where project_no ='" + txtDefaultProjectDispl.Text + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Project Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						throw new Exception();
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mDefaultProjectCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				else
				{
					mDefaultProjectCd = 0;
				}

				if (!SystemProcedure2.IsItEmpty(txtNewGrade.Text, SystemVariables.DataType.NumberType) || txtNewGrade.Text == "0")
				{
					mysql = "select grade_cd ";
					mysql = mysql + " from pay_grade where ";
					mysql = mysql + " grade_no = " + txtNewGrade.Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid New Grade Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						txtNewGrade.Focus();
						return result;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mNewGrade = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				else
				{
					mNewGrade = 0;
				}

				mysql = "select dept_cd ";
				mysql = mysql + " from pay_department where ";
				mysql = mysql + " dept_no = '" + txtCommonTextBox[conTXTNewDepartmentCd].Text + "'";

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Department Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtCommonTextBox[conTXTNewDepartmentCd].Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mNewDeptCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				//'Budgeted Head Count
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("HR_Budget")))
				{
					if (txtCommonTextBox[conTXTNewDesignationCd].Text != txtDisplayLabel[conDlblDesgCode].Text || txtCommonTextBox[conTXTNewDepartmentCd].Text != txtDisplayLabel[conDlblDeptCode].Text)
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
								mNewHCCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
							}
						}
						else
						{
							MessageBox.Show("Please Update Budget Head count!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return false;
						}

						if (Information.IsNumeric(txtCommonTextBox[conTxtOldBudgetHeadCount].Text))
						{
							mysql = "select head_count_cd from pay_head_count ";
							mysql = mysql + " where head_count_no = " + txtCommonTextBox[conTxtOldBudgetHeadCount].Text;

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
								mOldHCCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
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
						mNewHCCd = 0;
						mOldHCCd = 0;
					}
				}
				else
				{
					mNewHCCd = 0;
					mOldHCCd = 0;
				}

				SystemVariables.gConn.BeginTransaction();

				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_salary_variation", "voucher_no");
					mysql = " insert into pay_salary_variation ";
					mysql = mysql + " (emp_cd, dept_cd, desg_cd, voucher_no, voucher_date, reference_no";
					mysql = mysql + " , basic_salary, total_salary, comments, new_dept_cd, new_desg_cd";
					mysql = mysql + " , type_id, user_cd, effective_date,template_entry_id";
					mysql = mysql + " , new_bank_cd, new_transfer_bank_entry_id ,new_grade_cd , new_bank_account_no, new_rate_per_day, new_payment_type_id";
					mysql = mysql + " , bank_cd,transfer_bank_entry_id ,grade_cd ,bank_account_no,rate_per_day,payment_type_id, Account_no, New_Account_no";
					mysql = mysql + " , is_budgeted,new_head_count_cd,old_head_count_cd,IsReplacement,Default_Project,New_Default_Project)";
					mysql = mysql + " values ( ";
					mysql = mysql + mEmpCode.ToString();
					mysql = mysql + " , " + mDeptCode.ToString();
					mysql = mysql + " , " + mDesgCode.ToString();
					mysql = mysql + " , " + txtCommonTextBox[conTxtVoucherNo].Text;
					mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText) + "'";
					mysql = mysql + " , '" + txtCommonTextBox[conTXTReferenceNo].Text + "'";
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblBasicSalary].Text, "##########0.000");
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblTotalSalary].Text, "##########0.000");
					mysql = mysql + " , '" + txtCommonTextBox[conTxtComments].Text + "'";
					mysql = mysql + " , " + mNewDeptCode.ToString();
					mysql = mysql + " , " + mNewDesgCode.ToString();
					mysql = mysql + " , " + cmbType.GetItemData(cmbType.ListIndex).ToString();
					mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtEffectiveDate.Value) + "'";
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
					//' On 22-Sep-2011
					if (mNewBank == 0)
					{
						mysql = mysql + ", NULL";
					}
					else
					{
						mysql = mysql + "," + mNewBank.ToString();
					}

					if (mNewTransferBankId == 0)
					{
						mysql = mysql + ", NULL";
					}
					else
					{
						mysql = mysql + "," + mNewTransferBankId.ToString();
					}

					if (mNewGrade == 0)
					{
						mysql = mysql + ", NULL";
					}
					else
					{
						mysql = mysql + "," + mNewGrade.ToString();
					}

					mysql = mysql + ",'" + txtNewBankAccountNo.Text + "'";
					mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(txtNewRatePerDay.Value);
					mysql = mysql + "," + cmbCommon[conCmbNewPaymentType].GetItemData(cmbCommon[conCmbNewPaymentType].ListIndex).ToString();
					if (mBank == 0)
					{
						mysql = mysql + ", NULL";
					}
					else
					{
						mysql = mysql + "," + mBank.ToString();
					}

					if (mTransferBankId == 0)
					{
						mysql = mysql + ", NULL";
					}
					else
					{
						mysql = mysql + "," + mTransferBankId.ToString();
					}

					if (mGrade == 0)
					{
						mysql = mysql + ", NULL";
					}
					else
					{
						mysql = mysql + "," + mGrade.ToString();
					}

					mysql = mysql + ", '" + txtOldBankAccountNo.Text + "'";
					mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtOldRatePerDay.Value);
					mysql = mysql + ", " + cmbCommon[conCmbPaymentType].GetItemData(cmbCommon[conCmbPaymentType].ListIndex).ToString();
					mysql = mysql + ", '" + txtOldAccountNo.Text + "'";
					mysql = mysql + ", '" + txtNewAccountNo.Text + "'";
					mysql = mysql + ", " + ((int) chkBudget.CheckState).ToString();
					mysql = mysql + ", " + ((mNewHCCd == 0) ? "NULL" : mNewHCCd.ToString());
					mysql = mysql + ", " + ((mOldHCCd == 0) ? "NULL" : mOldHCCd.ToString());
					mysql = mysql + ", " + ((int) chkIsReplacement.CheckState).ToString();
					mysql = mysql + ", " + ((mDefaultProjectCd == 0) ? " NULL " : mDefaultProjectCd.ToString());
					mysql = mysql + ", " + ((mDefaultProjectCdNew == 0) ? " NULL " : mDefaultProjectCdNew.ToString());
					//'END
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
					mysql = " select time_stamp from pay_salary_variation where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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

					mysql = " update pay_salary_variation set ";
					mysql = mysql + " emp_cd =" + mEmpCode.ToString();
					mysql = mysql + " , dept_cd =" + mDeptCode.ToString();
					mysql = mysql + " , desg_cd =" + mDesgCode.ToString();
					mysql = mysql + " , new_dept_cd =" + mNewDeptCode.ToString();
					mysql = mysql + " , new_desg_cd =" + mNewDesgCode.ToString();
					mysql = mysql + " , voucher_no =" + txtCommonTextBox[conTxtVoucherNo].Text;
					mysql = mysql + " , voucher_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText) + "'";
					mysql = mysql + " , reference_no ='" + txtCommonTextBox[conTXTReferenceNo].Text + "'";
					mysql = mysql + " , basic_salary =" + StringsHelper.Format(txtDisplayLabel[conDlblBasicSalary].Text, "##########0.000");
					mysql = mysql + " , total_salary =" + StringsHelper.Format(txtDisplayLabel[conDlblTotalSalary].Text, "##########0.000");
					mysql = mysql + " , comments ='" + txtCommonTextBox[conTxtComments].Text + "'";
					mysql = mysql + " , type_id =" + cmbType.GetItemData(cmbType.ListIndex).ToString();
					mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " , user_date_time = '" + DateTimeHelper.ToString(DateTime.Today) + "'";
					mysql = mysql + " , effective_date='" + ReflectionHelper.GetPrimitiveValue<string>(txtEffectiveDate.Value) + "'";
					if (mNewBank == 0)
					{
						mysql = mysql + " , new_bank_cd = NULL";
					}
					else
					{
						mysql = mysql + " , new_bank_cd = " + mNewBank.ToString();
					}
					mysql = mysql + " , new_bank_account_no = '" + txtNewBankAccountNo.Text + "'";
					mysql = mysql + " , new_account_no = '" + txtNewAccountNo.Text + "'";
					mysql = mysql + " , new_rate_per_day = " + ReflectionHelper.GetPrimitiveValue<string>(txtNewRatePerDay.Value);
					mysql = mysql + " , new_payment_type_id = " + cmbCommon[conCmbNewPaymentType].GetItemData(cmbCommon[conCmbNewPaymentType].ListIndex).ToString();
					mysql = mysql + " , IsReplacement = " + ((int) chkIsReplacement.CheckState).ToString();
					if (mNewTransferBankId == 0)
					{
						mysql = mysql + " , new_transfer_bank_entry_id = NULL";
					}
					else
					{
						mysql = mysql + " , new_transfer_bank_entry_id = " + mNewTransferBankId.ToString();
					}

					if (mNewGrade == 0)
					{
						mysql = mysql + " , new_grade_cd = NULL ";
					}
					else
					{
						mysql = mysql + " , new_grade_cd = " + mNewGrade.ToString();
					}
					mysql = mysql + ", Default_Project = " + ((mDefaultProjectCd == 0) ? " NULL " : mDefaultProjectCd.ToString());
					mysql = mysql + ", New_Default_Project =  " + ((mDefaultProjectCdNew == 0) ? " NULL " : mDefaultProjectCdNew.ToString());
					//    If mBank = 0 Then
					//      mySQL = mySQL & " , bank_cd = NULL"
					//    Else
					//      mySQL = mySQL & " , bank_cd = " & mBank
					//    End If
					//    mySQL = mySQL & " , bank_account_no = '" & txtOldBankAccountNo.Text & "'"
					//    mySQL = mySQL & " , rate_per_day = " & txtOldRatePerDay.Value
					//    mySQL = mySQL & " , payment_type_id = " & cmbCommon(conCmbPaymentType).ItemData(cmbCommon(conCmbPaymentType).ListIndex)

					//'Added For Approval Entry ID  as on 03-dec-2009
					if (mTemplateEntID == 0)
					{
						mysql = mysql + ",template_entry_id =  NULL";
					}
					else
					{
						mysql = mysql + ",template_entry_id = " + mTemplateEntID.ToString();
					}
					//'END
					mysql = mysql + " where entry_id=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}

				//''Delete from pay_salary_variation
				mysql = " delete from pay_salary_variation_details ";
				mysql = mysql + " where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdBillingCodeColumn), SystemVariables.DataType.NumberType))
				{
					int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						mysql = " select bill_cd, bill_type_id from pay_billing_type ";
						mysql = mysql + " where bill_no=" + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdBillingCodeColumn), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingCodeColumn)));
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							MessageBox.Show("Invalid Billing Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
							grdVoucherDetails.Col = grdBillingCodeColumn;
							grdVoucherDetails.Bookmark = cnt;
							grdVoucherDetails.Focus();
							return false;
						}
						else
						{
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mBillingCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mBillingType = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
						}

						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(aVoucherDetails.GetValue(cnt, grdIncludeInLeave))) == TriState.False || Convert.ToString(aVoucherDetails.GetValue(cnt, grdIncludeInLeave)) == "")
						{
							mIncludeInLeave = 0;
						}
						else
						{
							mIncludeInLeave = 1;
						}

						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(aVoucherDetails.GetValue(cnt, grdIncludeInIndemnity))) == TriState.False || Convert.ToString(aVoucherDetails.GetValue(cnt, grdIncludeInIndemnity)) == "")
						{
							mIncludeInIndemnity = 0;
						}
						else
						{
							mIncludeInIndemnity = 1;
						}

						if (Information.IsDate(aVoucherDetails.GetValue(cnt, grdEndDate)) == (TriState.False != TriState.False) || Convert.ToString(aVoucherDetails.GetValue(cnt, grdEndDate)) == "")
						{
							mIsPeriodic = 0;
						}
						else
						{
							mIsPeriodic = 1;
						}

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("retroactive_salary")) && ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtEffectiveDate.Value) < DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()) && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("use_effective_date_for_salary_variation")))
						{
							mRetroactiveDays = CalculateRetroactiveDays();
						}
						else
						{
							mRetroactiveDays = 0;
						}
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select  days_per_month, hours_per_day, rate_calc_method_id , weekend_day1_id,weekend_day2_id from pay_employee where emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'"));

						mysql = " insert into pay_salary_variation_details";
						mysql = mysql + " (entry_id, bill_cd, variation_amount, last_amount ";
						mysql = mysql + " , include_in_leave ";
						mysql = mysql + " , include_in_indemnity, comments, is_periodic, end_date, retroactive_salary_days,retroactive_salary_amount) ";
						mysql = mysql + " values(";
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						mysql = mysql + " ," + mBillingCode.ToString();
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdIncrementAmtColumn));
						if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdCurrentAmtColumn), SystemVariables.DataType.NumberType))
						{
							mysql = mysql + " ,0";
						}
						else
						{
							mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdCurrentAmtColumn));
						}
						mysql = mysql + " ," + Conversion.Str(mIncludeInLeave);
						mysql = mysql + " ," + Conversion.Str(mIncludeInIndemnity);
						mysql = mysql + " ,N'" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdRemarksColumn)) + "'";
						if (Information.IsDate(aVoucherDetails.GetValue(cnt, grdEndDate)))
						{
							mysql = mysql + " , 1";
							mysql = mysql + " ,'" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdEndDate)) + "'";
						}
						else
						{
							mysql = mysql + " , 0";
							mysql = mysql + " , NULL";
						}
						mysql = mysql + " ," + mRetroactiveDays.ToString();
						if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2)) == SystemHRProcedure.gFixedDays)
						{
							mysql = mysql + " ," + Math.Round((double) (mRetroactiveDays * (Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdIncrementAmtColumn)) / ((double) ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0))))), 3).ToString();
						}
						else
						{
							mTempDays = SystemHRProcedure.CalculateDays(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()), DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(3)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(4)));
							mysql = mysql + " ," + Math.Round((double) (mRetroactiveDays * (Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdIncrementAmtColumn)) / mTempDays)), 3).ToString();
						}

						mysql = mysql + ")";

						SqlCommand TempCommand_4 = null;
						TempCommand_4 = SystemVariables.gConn.CreateCommand();
						TempCommand_4.CommandText = mysql;
						TempCommand_4.ExecuteNonQuery();
					}
				}

				int mOldDeptCd = 0;
				int mNewDeptCd = 0;
				int mEmpCd = 0;
				string mSQL = "";
				int mGLVoucherType = 0;
				string mAccrualDate = "";
				double mLastLeaveAccruedAmt = 0;
				double mLastIndemnityAccruedAmt = 0;
				string mReferenceNo = "";
				int mOldDeptGLLeaveExpLedgerCd = 0;
				int mOldDeptGLLeaveExpCostCd = 0;
				int mNewDeptGLLeaveExpLedgerCd = 0;
				int mNewDeptGLLeaveExpCostCd = 0;
				int mOldDeptGLLeaveProvLedgerCd = 0;
				int mOldDeptGLLeaveProvCostCd = 0;
				int mNewDeptGLLeaveProvLedgerCd = 0;
				int mNewDeptGLLeaveProvCostCd = 0;
				int mOldDeptGLIndemnityExpLedgerCd = 0;
				int mOldDeptGLIndemnityExpCostCd = 0;
				int mNewDeptGLIndemnityExpLedgerCd = 0;
				int mNewDeptGLIndemnityExpCostCd = 0;
				int mOldDeptGLIndemnityProvLedgerCd = 0;
				int mOldDeptGLIndemnityProvCostCd = 0;
				int mNewDeptGLIndemnityProvLedgerCd = 0;
				int mNewDeptGLIndemnityProvCostCd = 0;
				string mVoucherNo = "";
				string mVoucherDate = "";
				if (pApprove)
				{
					if (!SystemHRProcedure.GetTransactionApprovalStage(8, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 2))
					{
						MessageBox.Show("Record cannot be posted.", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.CommitTrans();
						return true;
					}
					//'Added by Burhan Ghee. Date:25-May-2008
					//'Desc: If employee's department is being changed then his leave and indemnity accruals should be transferred to new department
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select show from sm_modules where module_id = 8 ", true));

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_gl_link")) && ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue) && ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("pay_gl_entry_method")) == 1)
					{


						mAccrualDate = DateTimeHelper.ToString(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).AddMonths(-1));

						mSQL = " select dept_cd, new_dept_cd, emp_cd, voucher_no from pay_salary_variation where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue))
						{
							MessageBox.Show("Department Code cannot be null!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							result = false;
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							return result;
						}
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mOldDeptCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mNewDeptCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReferenceNo = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3));

						mSQL = " select sum(plas_cumm_accrued_amt) from pay_leave_accrual_summary where plas_emp_cd = " + mEmpCd.ToString() + " and plas_month = " + DateTime.Parse(mAccrualDate).Month.ToString() + " and plas_year = " + DateTime.Parse(mAccrualDate).Year.ToString();
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue) || ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == 0)
						{
							mLastLeaveAccruedAmt = 0;
						}
						else
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mLastLeaveAccruedAmt = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
						}

						mSQL = " select sum(pias_cumm_accrued_amt) from pay_indemnity_accrual_summary where pias_emp_cd = " + mEmpCd.ToString() + " and pias_month = " + DateTime.Parse(mAccrualDate).Month.ToString() + " and pias_year = " + DateTime.Parse(mAccrualDate).Year.ToString();
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue) || ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == 0)
						{
							mLastIndemnityAccruedAmt = 0;
						}
						else
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mLastIndemnityAccruedAmt = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue);
						}

						if (mLastIndemnityAccruedAmt == 0 && mLastLeaveAccruedAmt == 0)
						{
							goto mJump;
						}


						if (mOldDeptCd != mNewDeptCd)
						{ //if user has not changed the department then exit else execute below code
							//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mGLVoucherType = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("pay_default_gl_voucher_type"));
							//old dept leave exp legder and cost code
							mSQL = " select ldgr_cd, cost_cd from Pay_Department_GL_Details where dept_cd = " + mOldDeptCd.ToString() + " and bill_cd = 2";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mOldDeptGLLeaveExpLedgerCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mOldDeptGLLeaveExpCostCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
							}
							else
							{
								MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								result = false;
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								return result;
							}
							//old dept leave Provision ledger code and cost center code
							mSQL = " select ldgr_cd, cost_cd from Pay_Department_GL_Details where dept_cd = " + mOldDeptCd.ToString() + " and bill_cd = 7";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mOldDeptGLLeaveProvLedgerCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mOldDeptGLLeaveProvCostCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
							}
							else
							{
								MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								result = false;
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								return result;
							}

							//new dept leave expense ledger code and cost center code
							mSQL = " select ldgr_cd, cost_cd from Pay_Department_GL_Details where dept_cd = " + mNewDeptCd.ToString() + " and bill_cd = 2";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mNewDeptGLLeaveExpLedgerCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mNewDeptGLLeaveExpCostCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
							}
							else
							{
								MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								result = false;
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								return result;
							}
							//new dept leave Provision ledger code and cost center code
							mSQL = " select ldgr_cd, cost_cd from Pay_Department_GL_Details where dept_cd = " + mNewDeptCd.ToString() + " and bill_cd = 7";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mNewDeptGLLeaveProvLedgerCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mNewDeptGLLeaveProvCostCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
							}
							else
							{
								MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								result = false;
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								return result;
							}

							//Indemnity
							//old dept indemnity exp legder and cost code
							mSQL = " select ldgr_cd, cost_cd from Pay_Department_GL_Details where dept_cd = " + mOldDeptCd.ToString() + " and bill_cd = 8";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mOldDeptGLIndemnityExpLedgerCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mOldDeptGLIndemnityExpCostCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
							}
							else
							{
								MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								result = false;
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								return result;
							}
							//old dept indemnity Provision ledger code and cost center code
							mSQL = " select ldgr_cd, cost_cd from Pay_Department_GL_Details where dept_cd = " + mOldDeptCd.ToString() + " and bill_cd = 9";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mOldDeptGLIndemnityProvLedgerCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mOldDeptGLIndemnityProvCostCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
							}
							else
							{
								MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								result = false;
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								return result;
							}

							//new dept indemnity expense ledger code and cost center code
							mSQL = " select ldgr_cd, cost_cd from Pay_Department_GL_Details where dept_cd = " + mNewDeptCd.ToString() + " and bill_cd = 8";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mNewDeptGLIndemnityExpLedgerCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mNewDeptGLIndemnityExpCostCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
							}
							else
							{
								MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								result = false;
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								return result;
							}
							//new dept leave Provision ledger code and cost center code
							mSQL = " select ldgr_cd, cost_cd from Pay_Department_GL_Details where dept_cd = " + mNewDeptCd.ToString() + " and bill_cd = 9";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mNewDeptGLIndemnityProvLedgerCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mNewDeptGLIndemnityProvCostCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
							}
							else
							{
								MessageBox.Show("GL Links not defined!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								result = false;
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								return result;
							}


							//Passing GL Entry
							//Transefering Leave Balance
							//   1)New Dept Leave Expense A/c Dr
							//   2)    To Old Dept Leave Expense A/c
							//   3)Old Dept Leave Prov A/c Dr
							//   4)    To New Dept Leave Prov A/c
							//Transefering Indemnity Balance
							//   5)New Dept Indemnity Expense A/c Dr
							//   6)    To Old Dept Indemnity Expense A/c
							//   7)Old Dept Indemnity Prov A/c Dr
							//   8)    To New Dept Indemnity Prov A/c


							mVoucherDate = SystemHRProcedure.GetPayrollGenerateDate();
							mVoucherNo = SystemProcedure2.GetNewNumber("gl_accnt_trans", " voucher_no ", 2, " voucher_type = " + mGLVoucherType.ToString());

							mReturnValue = SystemFAProcedure.FAInsertGLHeaderEntry(mGLVoucherType, mVoucherDate, Convert.ToInt32(Double.Parse(mVoucherNo)), mReferenceNo, "Being department transferred", 4, SystemVariables.gLoggedInUserCode);
							if (mLastLeaveAccruedAmt > 0)
							{
								SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), mNewDeptGLLeaveExpLedgerCd.ToString(), mNewDeptGLLeaveExpCostCd.ToString(), 1, (decimal) mLastLeaveAccruedAmt, (decimal) mLastLeaveAccruedAmt, "D", mVoucherDate, 1, 2, "");
								SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), mOldDeptGLLeaveExpLedgerCd.ToString(), mOldDeptGLLeaveExpCostCd.ToString(), 1, (decimal) (mLastLeaveAccruedAmt * -1), (decimal) (mLastLeaveAccruedAmt * -1), "C", mVoucherDate, 1, 2, "");

								SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), mNewDeptGLLeaveProvLedgerCd.ToString(), mNewDeptGLLeaveProvCostCd.ToString(), 1, (decimal) (mLastLeaveAccruedAmt * -1), (decimal) (mLastLeaveAccruedAmt * -1), "C", mVoucherDate, 1, 2, "");
								SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), mOldDeptGLLeaveProvLedgerCd.ToString(), mOldDeptGLLeaveProvCostCd.ToString(), 1, (decimal) mLastLeaveAccruedAmt, (decimal) mLastLeaveAccruedAmt, "D", mVoucherDate, 1, 2, "");
							}
							if (mLastIndemnityAccruedAmt > 0)
							{
								SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), mNewDeptGLIndemnityExpLedgerCd.ToString(), mNewDeptGLLeaveExpCostCd.ToString(), 1, (decimal) mLastIndemnityAccruedAmt, (decimal) mLastIndemnityAccruedAmt, "D", mVoucherDate, 1, 2, "");
								SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), mOldDeptGLIndemnityExpLedgerCd.ToString(), mOldDeptGLLeaveExpCostCd.ToString(), 1, (decimal) (mLastIndemnityAccruedAmt * -1), (decimal) (mLastIndemnityAccruedAmt * -1), "C", mVoucherDate, 1, 2, "");

								SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), mNewDeptGLIndemnityProvLedgerCd.ToString(), mNewDeptGLIndemnityProvCostCd.ToString(), 1, (decimal) (mLastIndemnityAccruedAmt * -1), (decimal) (mLastIndemnityAccruedAmt * -1), "C", mVoucherDate, 1, 2, "");
								SystemFAProcedure.FAInsertGLDetailsEntry(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), mOldDeptGLIndemnityProvLedgerCd.ToString(), mOldDeptGLIndemnityProvCostCd.ToString(), 1, (decimal) mLastIndemnityAccruedAmt, (decimal) mLastIndemnityAccruedAmt, "D", mVoucherDate, 1, 2, "");
							}
							//End Passing GL Entry
							mSQL = " update gl_accnt_trans set linked = 1, linked_entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ", linked_module_id = 8, linked_type_flag = 12 where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
							SqlCommand TempCommand_5 = null;
							TempCommand_5 = SystemVariables.gConn.CreateCommand();
							TempCommand_5.CommandText = mSQL;
							TempCommand_5.ExecuteNonQuery();
						}
					}
					//End Department Update
					mJump:

					//''Commented by hakim and replaced by procedure.
					//    mySql = " update pay_employee "
					//    mySql = mySql & " set dept_cd = psv.new_dept_cd "
					//    mySql = mySql & " , desg_cd = psv.new_desg_cd "
					//    mySql = mySql & " , bank_cd = psv.new_bank_cd "
					//    mySql = mySql & " , bank_account_no = psv.new_bank_account_no"
					//    mySql = mySql & " , payment_type_id = psv.new_payment_type_id"
					//    mySql = mySql & " , rate_per_day = psv.new_rate_per_day"
					//    mySql = mySql & " , grade_cd = psv.new_grade_cd"
					//    mySql = mySql & " , Transfer_Bank_Entry_Id = psv.New_Transfer_Bank_Entry_Id"
					//    mySql = mySql & " , account_no = psv.new_account_no"
					//    mySql = mySql & " from pay_employee pemp "
					//    mySql = mySql & " inner join pay_salary_variation psv on pemp.emp_cd = psv.emp_cd "
					//    mySql = mySql & " where psv.entry_id = " & SearchValue
					//    gConn.Execute mySql
					//
					//    Call PayPostToHR("Pay_Salary_Variation", CLng(SearchValue))
					//     If IsDate(txtEffectiveDate.Value) Then
					//        If CDate(txtEffectiveDate.Value) <= CDate(GetPayrollGenerateDate) Then
					//            Call PayApprove("Pay_Salary_Variation", CLng(SearchValue), "Pay_Salary_Variation_Details")
					//        Else
					//            Call PayApprove("Pay_Salary_Variation", CLng(SearchValue))
					//        End If
					//     End If
					//
					//    Call ReGenerateEmployeePayroll(txtCommonTextBox(conTxtEmpCode).Text)

					SalaryVariationPostEffect(ReflectionHelper.GetPrimitiveValue<int>(SearchValue), txtCommonTextBox[conTxtEmpCode].Text);

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
			}
			return result;
		}

		public bool CheckDataValidity()
		{
			int cnt = 0;
			int cnt1 = 0;
			int mBillingCode = 0;

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				if (!SystemHRProcedure.GetTransactionApprovalStage(8, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 1))
				{
					MessageBox.Show("You Cannot edit this record!!!", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
				goto mend;
			}


			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtVoucherNo].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter the Voucher No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto mend;
			}

			if (!Information.IsDate(txtVoucherDate.Value))
			{
				MessageBox.Show("Enter Valid Date!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto mend;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter the Employee Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto mend;
			}

			//*-- update all the current voucher grid information in grid's internal buffer
			grdVoucherDetails.UpdateData();

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				//    If IsItEmpty(aVoucherDetails(cnt, grdBillingCodeColumn), NumberType) Then
				//        MsgBox "Invalid Billing Code"
				//        grdVoucherDetails.Col = grdBillingCodeColumn
				//        grdVoucherDetails.Bookmark = cnt
				//        grdVoucherDetails.SetFocus
				//        GoTo mend
				//    End If

				if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdTotalAmtColumn))) < 0)
				{
					MessageBox.Show("Total Amount cannot be less than zero.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					grdVoucherDetails.Col = grdIncrementAmtColumn;
					grdVoucherDetails.Bookmark = cnt;
					grdVoucherDetails.Focus();
					goto mend;
				}
			}

			int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar2; cnt++)
			{
				mBillingCode = Convert.ToInt32(aVoucherDetails.GetValue(cnt, grdBillingCodeColumn));
				int tempForEndVar3 = aVoucherDetails.GetLength(0) - 1;
				for (cnt1 = cnt + 1; cnt1 <= tempForEndVar3; cnt1++)
				{
					if (mBillingCode == Convert.ToDouble(aVoucherDetails.GetValue(cnt1, grdBillingCodeColumn)))
					{
						MessageBox.Show("Duplicate Billing Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						grdVoucherDetails.Col = grdBillingCodeColumn;
						grdVoucherDetails.Bookmark = cnt1;
						grdVoucherDetails.Focus();
						goto mend;
					}
				}
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("retroactive_salary")) && ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtEffectiveDate.Value) < DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()) && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("use_effective_date_for_salary_variation")))
				{
					if (Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdIncrementAmtColumn)) < 0)
					{
						MessageBox.Show("You can not reduce salary for last month!!!", "Salary Variation", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Salary Variation" : "Employee Promotion / Increment");
				//''''*************************************************************************

				SystemProcedure2.ClearTextBox(this);
				DefineVoucherArray(0, true);
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);

				txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_salary_variation", "voucher_no");
				txtVoucherDate.Value = DateTime.Today;
				txtEffectiveDate.Value = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate());
				txtCommonTextBox[conTxtEmpCode].Enabled = true;
				txtCommonTextBox[conTxtBudgetHeadCount].Enabled = true;
				//chkBudget.Enabled = True
				chkIsReplacement.CheckState = CheckState.Unchecked;
				chkBudget.CheckState = CheckState.Unchecked;
				txtCommonTextBox[conTxtOldBudgetHeadCount].Enabled = true;

				mSearchValue = ""; //Change the msearchvalue to blank
				mFirstGridFocus = true;
				FirstFocusObject.Focus();
				this.tabSalaryVariation.CurrTab = Convert.ToInt16(contabSalaryVAriation);
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


			string mysql = " select psv.* ";
			mysql = mysql + " , sat.trans_no, sat.l_approval_name";
			mysql = mysql + " from pay_salary_variation psv";
			mysql = mysql + " left outer join sys_approval_template sat on psv.template_entry_id = sat.entry_id";
			mysql = mysql + " where psv.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

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
				txtCommonTextBox[conTxtVoucherNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["voucher_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtVoucherDate.Value = localRec.Tables[0].Rows[0]["voucher_date"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTXTReferenceNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["reference_no"]) + "";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtComments].Text = Convert.ToString(localRec.Tables[0].Rows[0]["comments"]) + "";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblBasicSalary].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["basic_salary"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblTotalSalary].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["total_salary"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtEffectiveDate.Value = (localRec.Tables[0].Rows[0].IsNull("effective_date")) ? localRec.Tables[0].Rows[0]["voucher_date"] : localRec.Tables[0].Rows[0]["effective_date"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemCombo.SearchCombo(cmbType, (localRec.Tables[0].Rows[0].IsNull("type_id")) ? 0 : Convert.ToInt32(localRec.Tables[0].Rows[0]["type_id"]));
				//'Added on 24-Sep-2011
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemCombo.SearchCombo(cmbCommon[conCmbNewPaymentType], (localRec.Tables[0].Rows[0].IsNull("New_Payment_type_Id")) ? 25 : Convert.ToInt32(localRec.Tables[0].Rows[0]["New_Payment_type_Id"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemCombo.SearchCombo(cmbCommon[conCmbPaymentType], (localRec.Tables[0].Rows[0].IsNull("Payment_type_Id")) ? 25 : Convert.ToInt32(localRec.Tables[0].Rows[0]["Payment_type_Id"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtNewBankAccountNo.Text = Convert.ToString(localRec.Tables[0].Rows[0]["new_bank_account_no"]) + "";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtOldBankAccountNo.Text = Convert.ToString(localRec.Tables[0].Rows[0]["bank_account_no"]) + "";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtNewAccountNo.Text = Convert.ToString(localRec.Tables[0].Rows[0]["new_account_no"]) + "";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtOldAccountNo.Text = Convert.ToString(localRec.Tables[0].Rows[0]["account_no"]) + "";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtNewRatePerDay.Value = (localRec.Tables[0].Rows[0].IsNull("New_Rate_Per_Day")) ? ((object) 0) : localRec.Tables[0].Rows[0]["New_Rate_Per_Day"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtOldRatePerDay.Value = (localRec.Tables[0].Rows[0].IsNull("Rate_Per_Day")) ? ((object) 0) : localRec.Tables[0].Rows[0]["Rate_Per_Day"];

				//''Added On 10-Oct-2011
				mysql = " select pesv.emp_cd , b1.bank_no , b2.bank_no , b1.l_bank_name , b2.l_bank_name";
				mysql = mysql + " from pay_salary_variation pesv";
				mysql = mysql + " left outer join sm_bank b1 on b1.bank_cd = pesv.bank_cd";
				mysql = mysql + " left outer join sm_bank b2 on b2.bank_cd = pesv.new_bank_cd";
				mysql = mysql + " where pesv.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(((Array) mTempValue).GetValue(1)))
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtOldBankCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtoldBankName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(((Array) mTempValue).GetValue(2)))
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNewBankCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNewBankName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));
				}

				mysql = " select pesv.emp_cd , b1.bank_no , b2.bank_no , b1.l_bank_name , b2.l_bank_name";
				mysql = mysql + " from pay_salary_variation pesv";
				mysql = mysql + " left outer join Pay_Bank_Details bd1 on bd1.Entry_id = pesv.Transfer_Bank_Entry_Id";
				mysql = mysql + " left outer join Pay_Bank_Details bd2 on bd2.Entry_id = pesv.New_Transfer_Bank_Entry_Id";
				mysql = mysql + " left outer join sm_bank b1 on b1.bank_cd = bd1.bank_cd";
				mysql = mysql + " left outer join sm_bank b2 on b2.bank_cd = bd2.bank_cd";
				mysql = mysql + " where pesv.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(((Array) mTempValue).GetValue(1)))
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtoldCompBank.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtOldCompBankName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(((Array) mTempValue).GetValue(2)))
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNewCompBank.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNewCompBankName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));
				}

				mysql = " select pesv.emp_cd , pg1.grade_no , pg2.grade_no , pg1.l_grade_name , pg2.l_grade_name";
				mysql = mysql + " from pay_salary_variation pesv";
				mysql = mysql + " left outer join Pay_Grade pg1 on pg1.Grade_cd = pesv.Grade_cd";
				mysql = mysql + " left outer join Pay_Grade pg2 on pg2.Grade_cd = pesv.new_Grade_cd";
				mysql = mysql + " where pesv.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(((Array) mTempValue).GetValue(1)))
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtOldGrade.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDGradeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(((Array) mTempValue).GetValue(2)))
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNewGrade.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDNewGradeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));
				}
				//''END



				mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "isnull(l_first_name,'') + ' ' + isnull(l_second_name,'') + ' ' + isnull(l_third_name,'') + ' ' + isnull(l_fourth_name,'')" : "isnull(a_first_name,'') + ' ' + isnull(a_second_name,'') + ' ' + isnull(a_third_name,'') + ' ' + isnull(a_fourth_name,'')");
				mysql = mysql + " , pdept.dept_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pdept.l_dept_name" : "pdept.a_dept_name");
				mysql = mysql + " , pdesg.desg_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pdesg.l_desg_name" : "pdesg.a_desg_name");
				mysql = mysql + " , emp_no ";
				mysql = mysql + " , newpdept.dept_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "newpdept.l_dept_name" : "newpdept.a_dept_name");
				mysql = mysql + " , newpdesg.desg_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "newpdesg.l_desg_name" : "newpdesg.a_desg_name");
				mysql = mysql + " from pay_employee pemp , pay_department pdept, pay_designation pdesg ";
				mysql = mysql + " , pay_department newpdept, pay_designation newpdesg  where ";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " pdept.dept_cd = " + Convert.ToString(localRec.Tables[0].Rows[0]["dept_cd"]) + " and pdesg.desg_cd = " + Convert.ToString(localRec.Tables[0].Rows[0]["desg_cd"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " and newpdept.dept_cd = " + Convert.ToString(localRec.Tables[0].Rows[0]["new_dept_cd"]) + " and newpdesg.desg_cd = " + Convert.ToString(localRec.Tables[0].Rows[0]["new_desg_cd"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " and pemp.emp_cd = " + Convert.ToString(localRec.Tables[0].Rows[0]["emp_cd"]);

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonTextBox[conTxtEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(5));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDesgCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDeptCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonTextBox[conTXTNewDepartmentCd].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(6));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblNewDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(7));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonTextBox[conTXTNewDesignationCd].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(8));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblNewDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(9));

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mTemplateEntID = (localRec.Tables[0].Rows[0].IsNull("Template_Entry_id")) ? 0 : Convert.ToInt32(localRec.Tables[0].Rows[0]["Template_Entry_id"]);
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

				//'' on 29-Jan-2012 for Budget
				mysql = " select pesv.emp_cd  , phc1.head_count_no , phc2.head_count_no , pesv.Is_budgeted , pesv.IsReplacement";
				mysql = mysql + " from pay_salary_variation pesv";
				mysql = mysql + " left outer join Pay_Head_count phc1 on phc1.head_count_cd = pesv.new_head_count_cd";
				mysql = mysql + " left outer join Pay_head_count phc2 on phc2.head_count_cd = pesv.old_head_count_cd";
				mysql = mysql + " where pesv.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkBudget.CheckState = (CheckState) ((ReflectionHelper.GetPrimitiveValue<bool>(((Array) mTempValue).GetValue(3))) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkIsReplacement.CheckState = (CheckState) ((ReflectionHelper.GetPrimitiveValue<bool>(((Array) mTempValue).GetValue(4))) ? 1 : 0);

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(((Array) mTempValue).GetValue(1)))
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[conTxtBudgetHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDisplayLabel[conDlblHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(((Array) mTempValue).GetValue(2)))
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[conTxtOldBudgetHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDisplayLabel[conDlblOldHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
				}

				//Update  as on 21-Jun-2012
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!localRec.Tables[0].Rows[0].IsNull("Default_Project"))
				{
					mysql = "select project_no , l_project_name ";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " from PROJ_Projects where project_cd = " + Convert.ToString(localRec.Tables[0].Rows[0]["Default_Project"]);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempValue))
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDefaultProjectDispl.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDlblDefaultProject.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					}
					else
					{
						txtDefaultProjectDispl.Text = "";
						txtDlblDefaultProject.Text = "";
					}
				}
				else
				{
					txtDefaultProjectDispl.Text = "";
					txtDlblDefaultProject.Text = "";
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!localRec.Tables[0].Rows[0].IsNull("New_Default_Project"))
				{
					mysql = "select project_no , l_project_name ";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " from PROJ_Projects where project_cd = " + Convert.ToString(localRec.Tables[0].Rows[0]["New_Default_Project"]);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempValue))
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDefaultProjectNew.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDlblNewDefaultProject.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					}
					else
					{
						txtDefaultProjectNew.Text = "";
						txtDlblNewDefaultProject.Text = "";
					}
				}
				else
				{
					txtDefaultProjectNew.Text = "";
					txtDlblNewDefaultProject.Text = "";
				}

				chkBudget.Enabled = false;
				txtCommonTextBox[conTxtBudgetHeadCount].Enabled = false;
				txtCommonTextBox[conTxtOldBudgetHeadCount].Enabled = false;
				//''End

				//Change the form mode to edit
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				txtCommonTextBox[conTxtEmpCode].Enabled = false;

				//Set the form caption and Get the Voucher Status
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, frmPaySalaryVariation.DefInstance, Convert.ToInt32(localRec.Tables[0].Rows[0]["status"]), CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Salary Variation " : "Salary Variation ");

			}

			DefineVoucherArray(0, true);
			mysql = " select pbt.bill_no ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , pbt.l_bill_name as bill_name ";
				mysql = mysql + " , (select l_object_caption from SM_Objects where object_id=pbt.bill_type_id) as bill_type ";
			}
			else
			{
				mysql = mysql + " , pbt.a_bill_name as bill_name";
				mysql = mysql + " , (select a_object_caption from SM_Objects where object_id=pbt.bill_type_id) as bill_type ";
			}
			mysql = mysql + " , psvd.* ";
			mysql = mysql + " from pay_salary_variation_details psvd ";
			mysql = mysql + " inner join pay_billing_type pbt on psvd.bill_cd = pbt.bill_cd ";
			mysql = mysql + " where psvd.entry_id = " + Conversion.Str(pSearchValue);

			SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
			localRec.Tables.Clear();
			adap_2.Fill(localRec);
			if (localRec.Tables[0].Rows.Count != 0)
			{
				foreach (DataRow iteration_row in localRec.Tables[0].Rows)
				{
					DefineVoucherArray(cnt, false);
					aVoucherDetails.SetValue(Conversion.Str(cnt + 1).Trim(), cnt, grdLineNoColumn);
					aVoucherDetails.SetValue(iteration_row["bill_no"], cnt, grdBillingCodeColumn);
					aVoucherDetails.SetValue(iteration_row["bill_name"], cnt, grdBillingNameColumn);
					aVoucherDetails.SetValue(iteration_row["bill_type"], cnt, grdBillingTypeColumn);
					aVoucherDetails.SetValue(iteration_row["last_amount"], cnt, grdCurrentAmtColumn);
					aVoucherDetails.SetValue(iteration_row["variation_amount"], cnt, grdIncrementAmtColumn);
					//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
					aVoucherDetails.SetValue(Convert.ToDouble(iteration_row["last_amount"]) + Convert.ToDouble(iteration_row["variation_amount"]), cnt, grdTotalAmtColumn);
					aVoucherDetails.SetValue(iteration_row["include_in_leave"], cnt, grdIncludeInLeave);
					aVoucherDetails.SetValue(iteration_row["include_in_indemnity"], cnt, grdIncludeInIndemnity);
					aVoucherDetails.SetValue(iteration_row["is_periodic"], cnt, grdIsPeriodic);
					aVoucherDetails.SetValue(iteration_row["end_date"], cnt, grdEndDate);
					aVoucherDetails.SetValue(Convert.ToString(iteration_row["comments"]) + "", cnt, grdRemarksColumn);
					cnt++;
				}
			}

			AssignGridLineNumbers();
			grdVoucherDetails.Rebind(true);
			CalculateTotals(0, 0);

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
			SystemReports.GetCrystalReport(110013081, 2, "7886", Conversion.Str(mEntryId), false);
		}


		public void CloseForm()
		{
			this.Close();
		}

		private void grdVoucherDetails_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				int Col = grdVoucherDetails.Col;

				if (Col == grdIncludeInLeave || Col == grdIncludeInIndemnity)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[Col].Value).Trim() == "")
					{
						grdVoucherDetails.Columns[Col].Value = 0;
					}
					if (KeyAscii == 32)
					{
						KeyAscii = 0;
						grdVoucherDetails.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[Col].Value);
						grdVoucherDetails.UpdateData();
						grdVoucherDetails.Refresh();
					}
					else
					{
						KeyAscii = 0;
					}
				}
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{
			int Col = 0;

			if (MsgId == 2)
			{
				if (mLastCol == grdVoucherDetails.Col && mLastRow == grdVoucherDetails.Row)
				{
					return;
				}
				Col = grdVoucherDetails.Col;
				if (Col == grdIncludeInLeave || Col == grdIncludeInIndemnity)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[Col].Value) != "")
					{
						grdVoucherDetails.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[Col].Value);
					}
					else
					{
						grdVoucherDetails.Columns[Col].Value = 0;
					}
					grdVoucherDetails.UpdateData();
					grdVoucherDetails.Refresh();
				}
			}

			if (MsgId == 1)
			{
				grdVoucherDetails.Col = grdBillingCodeColumn;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList);
			}
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
				CalculateTotals(0, 0);
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
						if (cnt < 3)
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
				case grdBillingCodeColumn : 
					grdVoucherDetails.Col = grdBillingNameColumn; 
					break;
			}
		}



		private void DefineMasterRecordset()
		{
			string mysql = "";
			object mReturnValue = null;
			string mTempSql = "";

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

				//''This statement will get the current amount and include_in_leave
				//''from pay_employee_billing_details for the employee which is selected.
				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
				{
					mTempSql = " select emp_cd from pay_employee where emp_no='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mTempSql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mysql = mysql + " , ( select case when pbt.is_calculate = 0 then amount else percentage end from pay_employee_billing_details ";
						mysql = mysql + " where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
						mysql = mysql + " and bill_cd = pbt.bill_cd ) as Current_Amt ";

						mysql = mysql + " , ( select include_in_leave from pay_employee_billing_details ";
						mysql = mysql + " where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
						mysql = mysql + " and bill_cd = pbt.bill_cd ) as include_in_leave ";

						mysql = mysql + " , ( select include_in_indemnity from pay_employee_billing_details ";
						mysql = mysql + " where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
						mysql = mysql + " and bill_cd = pbt.bill_cd ) as include_in_indemnity ";

					}
					else
					{
						mysql = mysql + ", 0 as Current_Amt ";
						mysql = mysql + ", 0 as include_in_leave ";
						mysql = mysql + ", 0 as include_in_indemnity ";
					}
				}
				else
				{
					mysql = mysql + ", 0 as Current_Amt ";
					mysql = mysql + ", 0 as include_in_leave ";
					mysql = mysql + ", 0 as include_in_indemnity ";
				}

				mysql = mysql + " from pay_billing_type pbt ";
				mysql = mysql + " where pbt.show = 1";
				mysql = mysql + " and linked_leave_cd is null ";
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

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7060000));
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
			grdVoucherDetails.Columns[grdCurrentAmtColumn].Text = "0";
			grdVoucherDetails.Columns[grdIncrementAmtColumn].Text = "0";

			//''''This cause the focus to be lost from billing code for the first time when a new row is added
			//grdVoucherDetails.Update

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

		private void grdVoucherDetails_BeforeColEdit(object eventSender, C1.Win.C1TrueDBGrid.BeforeColEditEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int KeyAscii = (int) eventArgs.KeyChar;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				if (ColIndex == grdIncludeInLeave || ColIndex == grdIncludeInIndemnity)
				{
					if (Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex)) == "")
					{
						aVoucherDetails.SetValue(0, ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);
					}
					if (KeyAscii == 0 || KeyAscii == 13 || KeyAscii == 32)
					{
						aVoucherDetails.SetValue(~Convert.ToInt32(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex)), ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);
						grdVoucherDetails.UpdateData();
						grdVoucherDetails.Refresh();
					}
					Cancel = -1;
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			if (Col == grdIncludeInLeave || Col == grdIncludeInIndemnity)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(aVoucherDetails.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), Col))) == TriState.True)
				{
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgChecked2"];
					CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
				}
				else
				{
					//If aVoucherDetails(Val(Bookmark), Col) = vbFalse Then
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgUnchecked"];
					CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
				}
			}
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

		private void GetNextNumber()
		{
			txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_salary_variation", "voucher_no");
			FirstFocusObject.Focus();
		}

		public void FindRoutine(string pObjectName)
		{
			//Dim mySql As String
			string mysql = "";
			object mTempSearchValue = null;
			int mDeptCd = 0;
			int mDesgCd = 0;

			if (pObjectName == "OldBank")
			{
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7030000, "820"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtOldBankCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtOldBankCd_Leave(txtOldBankCd, new EventArgs());
				}
			}

			if (pObjectName == "txtDefaultProject")
			{
				txtDefaultProjectNew.Text = "";
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000130, "985"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDefaultProjectNew.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtDefaultProjectNew_Leave(txtDefaultProjectNew, new EventArgs());
				}
			}

			if (pObjectName == "NewBank")
			{
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7030000, "820"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNewBankCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtNewBankCd_Leave(txtNewBankCd, new EventArgs());
				}
			}

			if (pObjectName == "OldCompBank")
			{
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7031000, "1586"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtoldCompBank.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtoldCompBank_Leave(txtoldCompBank, new EventArgs());
				}
			}

			if (pObjectName == "NewCompBank")
			{
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7031000, "1586"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNewCompBank.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtNewCompBank_Leave(txtNewCompBank, new EventArgs());
				}
			}

			if (pObjectName == "OldGrade")
			{
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7007000, "771"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtOldGrade.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtOldGrade_Leave(txtOldGrade, new EventArgs());
				}
			}

			if (pObjectName == "NewGrade")
			{
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7007000, "771"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNewGrade.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtNewGrade_Leave(txtNewGrade, new EventArgs());
				}
			}

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

			switch(mIndex)
			{
				case conTxtEmpCode : 
					txtCommonTextBox[conTxtEmpCode].Text = ""; 
					mysql = " pay_emp.status_cd= " + SystemHRProcedure.gStatusActive.ToString(); 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", mysql)); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					 
					break;
				case conTXTNewDesignationCd : 
					txtCommonTextBox[conTXTNewDesignationCd].Text = ""; 
					 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7002000, "734")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTXTNewDesignationCd].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 

					 
					break;
				case conTXTNewDepartmentCd : 
					txtCommonTextBox[conTXTNewDepartmentCd].Text = ""; 
					 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7001000, "727")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTXTNewDepartmentCd].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					 
					break;
				case conTxtBudgetHeadCount : 
					txtCommonTextBox[conTxtBudgetHeadCount].Text = ""; 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTXTNewDepartmentCd].Text, SystemVariables.DataType.NumberType) && !SystemProcedure2.IsItEmpty(txtCommonTextBox[conTXTNewDesignationCd].Text, SystemVariables.DataType.NumberType))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mDeptCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select dept_cd from pay_department where dept_no = " + txtCommonTextBox[conTXTNewDepartmentCd].Text));
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mDesgCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select desg_cd from pay_designation where desg_no = " + txtCommonTextBox[conTXTNewDesignationCd].Text));
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
				case conTxtOldBudgetHeadCount : 
					txtCommonTextBox[conTxtOldBudgetHeadCount].Text = ""; 
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
							txtCommonTextBox[conTxtOldBudgetHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
							txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
						}
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
				object mReturnValue = null;
				object mApprovalTempValue = null;
				string mysql = "";
				int cnt = 0;
				int mDeptCd = 0;
				int mDesgCd = 0;

				if (Index == conTxtEmpCode)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name" : "a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name");
						mysql = mysql + " , desg_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
						mysql = mysql + " , dept_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
						mysql = mysql + " , basic_salary, total_salary ";
						mysql = mysql + " , pemp.basic_salary , payment_type_id , bank_account_no , rate_per_day , account_no , gp.project_no , gp.l_project_name";
						mysql = mysql + " from pay_employee pemp";
						mysql = mysql + " inner join pay_department pdept on pemp.dept_cd = pdept.dept_cd";
						mysql = mysql + " inner join  pay_designation pdesg on pemp.desg_cd = pdesg.desg_cd  ";
						mysql = mysql + " left outer join PROJ_Projects gp on pemp.default_project = gp.project_cd";
						mysql = mysql + " where ";
						mysql = mysql + " pemp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
						mysql = mysql + " and pemp.status_cd= " + SystemHRProcedure.gStatusActive.ToString();
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblEmpName].Text = "";
							txtDisplayLabel[conDlblDesgCode].Text = "";
							txtDisplayLabel[conDlblDesgName].Text = "";
							txtDisplayLabel[conDlblBasicSalary].Text = "";
							txtDisplayLabel[conDlblTotalSalary].Text = "";
							txtDisplayLabel[conDlblNewDeptName].Text = "";
							txtDisplayLabel[conDlblNewDesgName].Text = "";
							txtCommonTextBox[conTXTNewDepartmentCd].Text = "";
							txtCommonTextBox[conTXTNewDesignationCd].Text = "";
							txtoldBankName.Text = "";
							txtNewBankName.Text = "";
							txtOldBankCd.Text = "";
							txtNewBankCd.Text = "";
							NotUpgradedHelper.NotifyNotUpgradedElement("The following assignment/return was commented because it has incompatible types");
							//txtNewBankAccountNo = (System.Windows.Forms.TextBox) "";
							txtOldBankAccountNo.Text = "";
							txtOldAccountNo.Text = "";
							txtNewAccountNo.Text = "";
							txtNewRatePerDay.Value = 0;
							txtOldRatePerDay.Value = 0;
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDesgCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDeptCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));
							txtDisplayLabel[conDlblBasicSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(5)), "###,###,##0.000");
							txtDisplayLabel[conDlblTotalSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(6)), "###,###,##0.000");
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblNewDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblNewDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonTextBox[conTXTNewDepartmentCd].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonTextBox[conTXTNewDesignationCd].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
							//''  on 24-sep-2011
							txtNewBankAccountNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(9)) + "";
							txtOldBankAccountNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(9)) + "";
							txtNewAccountNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(11)) + "";
							txtOldAccountNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(11)) + "";
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtNewRatePerDay.Value = ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(10));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtOldRatePerDay.Value = ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(10));
							txtDefaultProjectDispl.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(12)) + "";
							txtDlblDefaultProject.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(13)) + "";
							txtDefaultProjectNew.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(12)) + "";
							txtDlblNewDefaultProject.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(13)) + "";

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							SystemCombo.SearchCombo(cmbCommon[conCmbNewPaymentType], (Convert.IsDBNull(((Array) mTempValue).GetValue(8))) ? 0 : ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(8)));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							SystemCombo.SearchCombo(cmbCommon[conCmbPaymentType], (Convert.IsDBNull(((Array) mTempValue).GetValue(8))) ? 0 : ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(8)));

							mysql = " select b.bank_no , b.l_bank_name";
							mysql = mysql + " from pay_employee pemp left outer join sm_bank b on b.bank_cd = pemp.bank_cd ";
							mysql = mysql + " where pemp.emp_no = '" + txtCommonTextBox[conTxtEmpCode].Text + "'";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(0)))
							{
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtOldBankCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtoldBankName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtNewBankCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtNewBankName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
							}
							else
							{
								txtNewBankCd.Text = "";
								txtNewBankName.Text = "";
								txtOldBankCd.Text = "";
								txtNewBankName.Text = "";
							}

							mysql = " select b.bank_no , b.l_bank_name";
							mysql = mysql + " from pay_employee pemp   ";
							mysql = mysql + " left outer join pay_bank_details pbd on pbd.Entry_id = pemp.Transfer_Bank_Entry_Id";
							mysql = mysql + " left outer join sm_bank b on b.bank_cd = pbd.bank_cd";
							mysql = mysql + " where pemp.emp_no = '" + txtCommonTextBox[conTxtEmpCode].Text + "'";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(0)))
							{
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtoldCompBank.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtOldCompBankName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtNewCompBank.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtNewCompBankName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
							}
							else
							{
								txtoldCompBank.Text = "";
								txtOldCompBankName.Text = "";
								txtNewCompBank.Text = "";
								txtNewCompBankName.Text = "";
							}

							mysql = " select g.Grade_No , g.l_Grade_Name ";
							mysql = mysql + " from pay_employee pemp ";
							mysql = mysql + " left outer join Pay_grade g on g.grade_cd = pemp.grade_cd ";
							mysql = mysql + " where pemp.emp_no = '" + txtCommonTextBox[conTxtEmpCode].Text + "'";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(0)))
							{
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtOldGrade.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDGradeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtNewGrade.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDNewGradeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
							}
							else
							{
								txtOldGrade.Text = "";
								txtDGradeName.Text = "";
								txtNewGrade.Text = "";
								txtDNewGradeName.Text = "";
							}
							//''End

							txtCommonTextBox[conTxtEmpCode].Enabled = false;
							//Default Approval Assign
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
						}
						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("HR_Budget")))
						{
							mysql = " select Top 1 head_count_no from pay_head_count phc";
							mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = phc.emp_cd ";
							mysql = mysql + " inner join pay_head_count_category phcc on phcc.head_count_category_cd = phc.head_count_category_cd";
							mysql = mysql + " inner join pay_department pd on phcc.dept_cd  = pd.dept_cd ";
							mysql = mysql + " inner join pay_designation pds on phcc.desg_cd = pds.desg_cd ";
							mysql = mysql + " where pemp.emp_no = '" + txtCommonTextBox[conTxtEmpCode].Text + "'";
							//mySql = mySql & " and phc.Total_Budget_Salary < 0 "
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mReturnValue))
							{
								txtCommonTextBox[conTxtOldBudgetHeadCount].Text = "";
								txtDisplayLabel[conDlblOldHeadCount].Text = "";
							}
							else
							{
								//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtCommonTextBox[conTxtOldBudgetHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
								//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDisplayLabel[conDlblOldHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
							}
						}
					}
					else
					{
						txtDisplayLabel[conDlblEmpName].Text = "";
						txtDisplayLabel[conDlblDesgCode].Text = "";
						txtDisplayLabel[conDlblDesgName].Text = "";
						txtDisplayLabel[conDlblBasicSalary].Text = "";
						txtDisplayLabel[conDlblTotalSalary].Text = "";
						txtDisplayLabel[conDlblNewDeptName].Text = "";
						txtDisplayLabel[conDlblNewDesgName].Text = "";
						txtCommonTextBox[conTXTNewDepartmentCd].Text = "";
						txtCommonTextBox[conTXTNewDesignationCd].Text = "";
					}

				}

				if (Index == conTXTNewDepartmentCd)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTXTNewDepartmentCd].Text, SystemVariables.DataType.StringType))
					{
						mysql = "select ";
						mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
						mysql = mysql + " from  pay_department pdept ";
						mysql = mysql + " where ";
						mysql = mysql + " pdept.dept_no ='" + txtCommonTextBox[conTXTNewDepartmentCd].Text + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblNewDeptName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblNewDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
						}
					}
					else
					{
						txtDisplayLabel[conDlblNewDeptName].Text = "";
					}

				}

				if (Index == conTxtBudgetHeadCount)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtBudgetHeadCount].Text, SystemVariables.DataType.NumberType))
					{
						if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTXTNewDepartmentCd].Text, SystemVariables.DataType.NumberType) && !SystemProcedure2.IsItEmpty(txtCommonTextBox[conTXTNewDepartmentCd].Text, SystemVariables.DataType.NumberType))
						{
							if (txtCommonTextBox[conTXTNewDesignationCd].Text != txtDisplayLabel[conDlblDesgCode].Text || txtCommonTextBox[conTXTNewDepartmentCd].Text != txtDisplayLabel[conDlblDeptCode].Text)
							{
								mysql = "select head_count_no ";
								mysql = mysql + " from pay_head_count phc";
								mysql = mysql + " inner join pay_head_count_category phcc on phcc.head_count_category_cd = phc.head_count_category_cd";
								mysql = mysql + " inner join pay_department pd on pd.dept_cd = phcc.dept_cd";
								mysql = mysql + " inner join pay_designation pds on pds.desg_cd = phcc.desg_cd";
								mysql = mysql + " where ";
								mysql = mysql + " head_count_no = " + txtCommonTextBox[conTxtBudgetHeadCount].Text;
								mysql = mysql + " and phc.head_count_status in (1,3) and pd.dept_no = " + txtCommonTextBox[conTXTNewDepartmentCd].Text;
								mysql = mysql + " and pds.desg_cd = " + txtCommonTextBox[conTXTNewDesignationCd].Text;

								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (Convert.IsDBNull(mTempValue))
								{
									txtDisplayLabel[conDlblHeadCount].Text = "";
								}
								else
								{
									//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									txtDisplayLabel[conDlblHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
								}
							}
							else
							{
								txtCommonTextBox[conTxtBudgetHeadCount].Text = "";
								txtDisplayLabel[conDlblHeadCount].Text = "";
							}
						}
						else
						{
							txtCommonTextBox[conTxtBudgetHeadCount].Text = "";
							txtDisplayLabel[conDlblHeadCount].Text = "";
						}
					}
					else
					{
						txtDisplayLabel[conDlblHeadCount].Text = "";
						txtCommonTextBox[conTxtBudgetHeadCount].Text = "";
					}
				}

				if (Index == conTxtOldBudgetHeadCount)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtOldBudgetHeadCount].Text, SystemVariables.DataType.NumberType))
					{
						if (!SystemProcedure2.IsItEmpty(txtDisplayLabel[conDlblDeptCode].Text, SystemVariables.DataType.NumberType) && !SystemProcedure2.IsItEmpty(txtDisplayLabel[conDlblDesgCode].Text, SystemVariables.DataType.NumberType))
						{
							if (txtCommonTextBox[conTXTNewDesignationCd].Text != txtDisplayLabel[conDlblDesgCode].Text || txtCommonTextBox[conTXTNewDepartmentCd].Text != txtDisplayLabel[conDlblDeptCode].Text)
							{
								mysql = "select head_count_no ";
								mysql = mysql + " from pay_head_count phc";
								mysql = mysql + " inner join pay_head_count_category phcc on phcc.head_count_category_cd = phc.head_count_category_cd";
								mysql = mysql + " inner join pay_department pd on pd.dept_cd = phcc.dept_cd";
								mysql = mysql + " inner join pay_designation pds on pds.desg_cd = phcc.desg_cd";
								mysql = mysql + " where ";
								mysql = mysql + " head_count_no = " + txtCommonTextBox[conTxtOldBudgetHeadCount].Text;
								mysql = mysql + " and phc.head_count_status in (1,3) and pd.dept_no = " + txtDisplayLabel[conDlblDeptCode].Text;
								mysql = mysql + " and pds.desg_cd = " + txtDisplayLabel[conDlblDesgCode].Text;

								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (Convert.IsDBNull(mTempValue))
								{
									txtDisplayLabel[conDlblOldHeadCount].Text = "";
								}
								else
								{
									//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									txtDisplayLabel[conDlblOldHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
								}
							}
							else
							{
								txtDisplayLabel[conDlblOldHeadCount].Text = "";
								txtCommonTextBox[conTxtOldBudgetHeadCount].Text = "";
							}
						}
						else
						{
							txtDisplayLabel[conDlblOldHeadCount].Text = "";
							txtCommonTextBox[conTxtOldBudgetHeadCount].Text = "";
						}
					}
					else
					{
						txtDisplayLabel[conDlblOldHeadCount].Text = "";
						txtCommonTextBox[conTxtOldBudgetHeadCount].Text = "";
					}
				}

				if (Index == conTXTNewDesignationCd)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTXTNewDesignationCd].Text, SystemVariables.DataType.StringType))
					{
						mysql = "select ";
						mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
						mysql = mysql + " ,desg_cd ";
						mysql = mysql + " from  pay_designation pdesg ";
						mysql = mysql + " where ";
						mysql = mysql + " pdesg.desg_no ='" + txtCommonTextBox[conTXTNewDesignationCd].Text + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblNewDesgName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblNewDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
							if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("HR_Budget")))
							{
								if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTXTNewDepartmentCd].Text, SystemVariables.DataType.NumberType))
								{
									if (txtCommonTextBox[conTXTNewDesignationCd].Text != txtDisplayLabel[conDlblDesgCode].Text || txtCommonTextBox[conTXTNewDepartmentCd].Text != txtDisplayLabel[conDlblDeptCode].Text)
									{
										mysql = " select Top 1 Head_Count_No from Pay_head_count phc";
										mysql = mysql + " inner join Pay_Head_Count_Category phcc on phc.head_count_category_cd = phcc.head_count_category_cd ";
										mysql = mysql + " inner join pay_department pd on pd.dept_cd = phcc.dept_cd ";
										mysql = mysql + " where pd.dept_no = " + txtCommonTextBox[conTXTNewDepartmentCd].Text;
										mysql = mysql + " and phcc.desg_cd = " + ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(1)).ToString();
										mysql = mysql + " and phc.Head_Count_Status in (1,3)";
										//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
										mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
										if (!Convert.IsDBNull(mTempValue))
										{
											//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
											txtCommonTextBox[conTxtBudgetHeadCount].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
											txtCommonTextBox_Leave(txtCommonTextBox[conTxtBudgetHeadCount], new EventArgs());
										}
										else
										{
											txtCommonTextBox[conTxtBudgetHeadCount].Text = "";
											txtDisplayLabel[conDlblHeadCount].Text = "";
										}
									}
									else
									{
										txtCommonTextBox[conTxtBudgetHeadCount].Text = "";
										txtDisplayLabel[conDlblHeadCount].Text = "";
									}
								}
							}
						}
					}
					else
					{
						txtDisplayLabel[conDlblNewDesgName].Text = "";
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

		private void AssignCheckBoxValueInGrid()
		{
			//aVoucherDetails(0, grdLineNoColumn) = 1
			aVoucherDetails.SetValue(0, 0, grdIncludeInLeave);
			aVoucherDetails.SetValue(0, 0, grdIncludeInIndemnity);
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

			if (!SystemHRProcedure.GetTransactionApprovalStage(8, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 1))
			{
				MessageBox.Show("Record cannot be deleted.", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return result;
			}

			SystemVariables.gConn.BeginTransaction();

			string mysql = "delete from pay_salary_variation_details where entry_id=" + Conversion.Str(mSearchValue);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = "delete from pay_salary_variation where entry_id=" + Conversion.Str(mSearchValue);
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

							//''Commented by hakim and replaced with a procedure
							//                Call PayPostToHR("Pay_Salary_Variation", CLng(SearchValue))
							//                If IsDate(txtEffectiveDate.Value) Then
							//                   If CDate(txtEffectiveDate.Value) <= CDate(GetPayrollGenerateDate) Then
							//                       Call PayApprove("Pay_Salary_Variation", CLng(SearchValue), "Pay_Salary_Variation_Details")
							//                   Else
							//                       Call PayApprove("Pay_Salary_Variation", CLng(SearchValue))
							//                   End If
							//                End If
							//
							//                mySql = " select  emp_no from pay_employee pemp "
							//                mySql = mySql & " inner join pay_salary_variation psv on pemp.emp_cd = psv.emp_cd "
							//                mySql = mySql & " where psv.entry_id =" & SearchValue
							//                mReturnValue = GetMasterCode(mySql)
							//
							//                If Not IsNull(mReturnValue) Then
							//                    Call ReGenerateEmployeePayroll(mReturnValue)
							//                Else
							//                    gConn.RollBackTrans
							//                    Post = False
							//                    Exit Function
							//                End If
							SalaryVariationPostEffect(ReflectionHelper.GetPrimitiveValue<int>(SearchValue), txtCommonTextBox[conTxtEmpCode].Text);

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

		public bool UnPost()
		{
			//Exit Function
			bool result = false;
			SqlDataReader localRec = null;
			//''



			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				MessageBox.Show("You are currently in AddMode!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			if (mOldVoucherStatus == SystemVariables.VoucherStatus.stActive)
			{
				MessageBox.Show("Voucher is not posted!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}


			string mysql = "select is_pay_closed from pay_salary_variation where entry_id =" + ReflectionHelper.GetPrimitiveValue<int>(mSearchValue).ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
			{
				MessageBox.Show("Can not Unpost, Payroll month is closed!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			mysql = " select voucher_date from pay_salary_variation where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			string mVoucherDate = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode(mysql));

			mysql = "select count(*) from pay_salary_variation psv  ";
			mysql = mysql + " inner join pay_employee pemp on psv.emp_cd = pemp.emp_cd ";
			mysql = mysql + " where pemp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "' and voucher_date > '" + mVoucherDate + "'";

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) > 0)
			{
				MessageBox.Show("Can not Unpost, Transaction(s) after date " + mVoucherDate + " already exits!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return false;
			}


			DialogResult ans = MessageBox.Show("Do you want to Unpost the Record ?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

			if (ans == System.Windows.Forms.DialogResult.Yes)
			{
				//''
				mysql = "select psv.emp_cd, psvd.*, pbt.is_calculate from pay_salary_variation psv ";
				mysql = mysql + " inner join pay_salary_variation_details psvd on psv.entry_id = psvd.entry_id";
				mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = psvd.bill_cd";
				mysql = mysql + " Where psv.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				localRec.Read();

				SystemVariables.gConn.BeginTransaction();
				do 
				{
					mysql = " Update pay_employee_billing_details ";
					if (!Convert.ToBoolean(localRec["is_calculate"]))
					{
						mysql = mysql + " set  amount = " + Convert.ToString(localRec["last_amount"]);
					}
					else
					{
						mysql = mysql + " set  percentage = " + Convert.ToString(localRec["last_amount"]);
					}
					mysql = mysql + ", last_amount = 0 ";
					mysql = mysql + ", user_cd = " + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " where emp_cd = " + Convert.ToString(localRec["emp_cd"]) + " and bill_cd = " + Convert.ToString(localRec["bill_cd"]);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				while(localRec.Read());

				mysql = "update pemp";
				mysql = mysql + " set pemp.dept_cd = psv.dept_cd ";
				mysql = mysql + " , pemp.desg_cd = psv.desg_cd";
				mysql = mysql + " , pemp.bank_Cd = psv.bank_cd";
				mysql = mysql + " , pemp.bank_account_no = psv.bank_account_no";
				mysql = mysql + " , pemp.payment_type_id = psv.payment_type_id ";
				mysql = mysql + " , grade_cd = psv.grade_cd";
				mysql = mysql + " , Transfer_Bank_Entry_Id = psv.Transfer_Bank_Entry_Id";
				mysql = mysql + " , account_no = psv.account_no";
				mysql = mysql + " , pemp.Default_project = psv.Default_Project";
				mysql = mysql + " from pay_salary_variation psv";
				mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = psv.emp_cd";
				mysql = mysql + " where psv.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				mysql = "update pay_salary_variation ";
				mysql = mysql + " set posted_HR = 0 ";
				mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				mysql = "update pay_salary_variation ";
				mysql = mysql + " set status = 1 ";
				mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();

				mysql = "update pay_salary_variation_details ";
				mysql = mysql + " set status = 1 ";
				mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand TempCommand_5 = null;
				TempCommand_5 = SystemVariables.gConn.CreateCommand();
				TempCommand_5.CommandText = mysql;
				TempCommand_5.ExecuteNonQuery();

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				SystemHRProcedure.ReGenerateEmployeePayroll(txtCommonTextBox[conTxtEmpCode].Text);
				result = true;
				AddRecord();
			}
			else if (ans == System.Windows.Forms.DialogResult.No)
			{ 

				AddRecord();
				result = false;
			}
			else if (ans == System.Windows.Forms.DialogResult.Cancel)
			{ 

				result = false;
			}
			return result;
		}

		private double CalculateRetroactiveDays()
		{
			object mReturnValue = null;
			string mLastMonthDate = "";
			string mLastMonthStartDate = "";
			double mTotalDays = 0;
			double mActualDaysInMonth = 0;
			try
			{

				mTotalDays = 0;
				//'modified by hakim on 08-dec-2011, problem occured with hydrotek, with null value in mreturnvalue
				//If Day(txtEffectiveDate.Value) <> 1 Then
				if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtEffectiveDate.Value) != DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()) && DateAndTime.Day(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtEffectiveDate.Value)) != 1)
				{
					mLastMonthStartDate = DateAndTime.DateSerial(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtEffectiveDate.Value).Year, ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtEffectiveDate.Value).Month, 1).AddMonths(1).ToString("dd-MMM-yyyy");
					mLastMonthDate = DateTimeHelper.ToString(DateTime.Parse(mLastMonthStartDate).AddDays(-1));
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select weekend_day1_id,weekend_day2_id,emp_cd,days_per_month,hours_per_day,rate_calc_method_id from pay_employee where emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'"));
					mTotalDays = SystemHRProcedure.CalculateDays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtEffectiveDate.Value), DateTime.Parse(mLastMonthDate), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)));
				}
				else
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select weekend_day1_id,weekend_day2_id,emp_cd,days_per_month,hours_per_day,rate_calc_method_id from pay_employee where emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'"));
					//UPGRADE_WARNING: (1068) txtEffectiveDate.Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLastMonthStartDate = ReflectionHelper.GetPrimitiveValue<string>(txtEffectiveDate.Value);
				}
				while (DateTime.Parse(mLastMonthStartDate) != DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()))
				{
					if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5)) == SystemHRProcedure.gFixedDays)
					{
						if (DateTime.Parse(mLastMonthStartDate).Month != ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtEffectiveDate.Value).Month || mLastMonthStartDate == ReflectionHelper.GetPrimitiveValue<string>(txtEffectiveDate.Value))
						{
							mTotalDays += ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3));
						}
						else
						{
							mLastMonthDate = DateTime.Parse(mLastMonthStartDate).AddMonths(1).AddDays(-1).ToString("dd-MMM-yyyy");
							mActualDaysInMonth = SystemHRProcedure.CalculateDays(DateTime.Parse(mLastMonthStartDate), DateTime.Parse(mLastMonthDate), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)));
							mTotalDays += SystemHRProcedure.GetAttendenceWorkedDays(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(3)), Convert.ToInt32(mActualDaysInMonth), ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(4)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(5)), false, 0, ref mLastMonthStartDate, ref mLastMonthDate);
						}
					}
					else
					{
						mLastMonthDate = DateTime.Parse(mLastMonthStartDate).AddMonths(1).AddDays(-1).ToString("dd-MMM-yyyy");
						mActualDaysInMonth = SystemHRProcedure.CalculateDays(DateTime.Parse(mLastMonthStartDate), DateTime.Parse(mLastMonthDate), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)));
						mTotalDays += SystemHRProcedure.GetAttendenceWorkedDays(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(3)), Convert.ToInt32(mActualDaysInMonth), ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(4)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(5)), false, 0, ref mLastMonthStartDate, ref mLastMonthDate);
					}
					mLastMonthStartDate = DateTime.Parse(mLastMonthStartDate).AddMonths(1).ToString("dd-MMM-yyyy");
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

		private void txtDefaultProjectNew_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtDefaultProject");
		}

		private void txtDefaultProjectNew_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";

				if (!SystemProcedure2.IsItEmpty(txtDefaultProjectNew.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select project_no ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_project_name" : "a_project_name");
					mysql = mysql + " from PROJ_Projects ";
					mysql = mysql + " where ";
					mysql = mysql + " project_no = '" + txtDefaultProjectNew.Text + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDlblNewDefaultProject.Text = "";
						throw new Exception();
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDlblNewDefaultProject.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					}
				}
				else
				{
					txtDlblNewDefaultProject.Text = "";
				}
			}
			catch
			{
				MessageBox.Show("Invalid Project No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void txtNewBankCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("NewBank");
		}

		private void txtNewBankCd_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;

			if (!SystemProcedure2.IsItEmpty(txtNewBankCd.Text, SystemVariables.DataType.NumberType))
			{
				mysql = " select bank_no , l_bank_name";
				mysql = mysql + " from sm_bank where bank_no = " + txtNewBankCd.Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNewBankName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				}
				else
				{
					txtNewBankCd.Text = "";
					txtNewBankName.Text = "";
				}
			}
			else
			{
				txtNewBankCd.Text = "";
				txtNewBankName.Text = "";
			}

		}

		private void txtNewCompBank_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("NewCompBank");
		}

		private void txtNewCompBank_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;

			if (!SystemProcedure2.IsItEmpty(txtNewCompBank.Text, SystemVariables.DataType.NumberType))
			{
				mysql = " select pbd.account_no ";
				mysql = mysql + "," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_bank_name" : "a_bank_name");
				mysql = mysql + " from pay_bank_details pbd ";
				mysql = mysql + " inner join sm_bank bank on pbd.bank_cd = bank.bank_cd ";
				mysql = mysql + " where bank.bank_no =" + txtNewCompBank.Text;

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNewCompBankName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				}
				else
				{
					txtNewCompBank.Text = "";
					txtNewCompBankName.Text = "";
				}
			}
			else
			{
				txtNewCompBank.Text = "";
				txtNewCompBankName.Text = "";
			}
		}

		private void txtNewGrade_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("NewGrade");
		}

		private void txtNewGrade_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;

			if (!SystemProcedure2.IsItEmpty(txtNewGrade.Text, SystemVariables.DataType.NumberType) || txtNewGrade.Text == "0")
			{
				mysql = "select grade_no";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_grade_name" : "a_grade_name");
				mysql = mysql + " from pay_grade ";
				mysql = mysql + " where ";
				mysql = mysql + " grade_no = " + txtNewGrade.Text;

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					txtDNewGradeName.Text = "";
					throw new System.Exception("-9990002");
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDNewGradeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				}
			}
			else
			{
				txtDNewGradeName.Text = "";
			}
		}

		private void txtOldBankCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("OldCompBank");
		}

		private void txtOldBankCd_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;

			if (!SystemProcedure2.IsItEmpty(txtOldBankCd.Text, SystemVariables.DataType.NumberType))
			{
				mysql = " select bank_no , l_bank_name";
				mysql = mysql + " from sm_bank where bank_no = " + txtOldBankCd.Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtoldBankName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				}
				else
				{
					txtOldBankCd.Text = "";
					txtoldBankName.Text = "";
				}
			}
			else
			{
				txtOldBankCd.Text = "";
				txtoldBankName.Text = "";
			}

		}


		private void txtoldCompBank_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("OldCompBank");
		}

		private void txtoldCompBank_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;

			if (!SystemProcedure2.IsItEmpty(txtoldCompBank.Text, SystemVariables.DataType.NumberType))
			{
				mysql = " select pbd.account_no ";
				mysql = mysql + "," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_bank_name" : "a_bank_name");
				mysql = mysql + " from pay_bank_details pbd ";
				mysql = mysql + " inner join sm_bank bank on pbd.bank_cd = bank.bank_cd ";
				mysql = mysql + " where bank.bank_no =" + txtoldCompBank.Text;

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtoldCompBank.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				}
				else
				{
					txtoldCompBank.Text = "";
					txtOldCompBankName.Text = "";
				}
			}
			else
			{
				txtoldCompBank.Text = "";
				txtOldCompBankName.Text = "";
			}

		}

		private void txtOldGrade_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("OldGrade");
		}

		private void txtOldGrade_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;

			if (!SystemProcedure2.IsItEmpty(txtOldGrade.Text, SystemVariables.DataType.NumberType) || txtOldGrade.Text == "0")
			{
				mysql = "select grade_no";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_grade_name" : "a_grade_name");
				mysql = mysql + " from pay_grade ";
				mysql = mysql + " where ";
				mysql = mysql + " grade_no = " + txtOldGrade.Text;

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					txtDGradeName.Text = "";
					throw new System.Exception("-9990002");
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDGradeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				}
			}
			else
			{
				txtDGradeName.Text = "";
			}

		}

		private void SalaryVariationPostEffect(int pEntryId, string pEmpNo)
		{
			object mHeadCountReturnValue = null;

			string mysql = " update pay_employee ";
			mysql = mysql + " set dept_cd = psv.new_dept_cd ";
			mysql = mysql + " , desg_cd = psv.new_desg_cd ";
			mysql = mysql + " , bank_cd = psv.new_bank_cd ";
			mysql = mysql + " , bank_account_no = psv.new_bank_account_no";
			mysql = mysql + " , payment_type_id = psv.new_payment_type_id";
			mysql = mysql + " , rate_per_day = psv.new_rate_per_day";
			mysql = mysql + " , grade_cd = psv.new_grade_cd";
			mysql = mysql + " , Transfer_Bank_Entry_Id = psv.New_Transfer_Bank_Entry_Id";
			mysql = mysql + " , account_no = psv.new_account_no";
			mysql = mysql + " , Default_Project = psv.New_Default_Project";
			mysql = mysql + " from pay_employee pemp ";
			mysql = mysql + " inner join pay_salary_variation psv on pemp.emp_cd = psv.emp_cd ";
			mysql = mysql + " where psv.entry_id = " + Conversion.Str(pEntryId);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = " select emp_cd , total_salary from pay_employee where emp_no = '" + txtCommonTextBox[conTxtEmpCode].Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//'' on 31-Jan-2012   For Budget
			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("HR_Budget")))
			{
				if (txtCommonTextBox[conTXTNewDesignationCd].Text != txtDisplayLabel[conDlblDesgCode].Text || txtCommonTextBox[conTXTNewDepartmentCd].Text != txtDisplayLabel[conDlblDeptCode].Text)
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mHeadCountReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Emp_cd,Head_Count_Category_Cd from pay_head_count where head_count_no = " + txtCommonTextBox[conTxtBudgetHeadCount].Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(((Array) mHeadCountReturnValue).GetValue(0)))
					{
						mysql = " update pay_head_count";
						mysql = mysql + " set Head_count_status = " + ((chkIsReplacement.CheckState != CheckState.Unchecked) ? 3 : 4).ToString();
						mysql = mysql + "  , Replacement_Status = " + ((chkIsReplacement.CheckState != CheckState.Unchecked) ? "1" : "NULL");
						mysql = mysql + "  , Total_Budget_Salary = " + SystemHRProcedure.GetEmpBudgetSalary(txtCommonTextBox[conTxtEmpCode].Text).ToString();
						mysql = mysql + "  , Is_Budgeted = 0 ";
						mysql = mysql + " where emp_cd = " + ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)).ToString() + " and head_count_status = 2 ";
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();

						mysql = "INSERT INTO Pay_Head_Count";
						mysql = mysql + " (Head_Count_Category_Cd,Head_Count_No,Emp_Cd,Is_Budgeted";
						mysql = mysql + " ,Budget_Details_Line_No,Head_Count_Status,Comments,User_Cd,analysis3_cd,analysis1_cd";
						mysql = mysql + " ,analysis2_cd,analysis4_cd,analysis5_cd,Total_Budget_Salary)";
						mysql = mysql + " Values( " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mHeadCountReturnValue).GetValue(1));
						mysql = mysql + " , " + SystemProcedure2.GetNewNumber("Pay_Head_Count", "Head_Count_No");
						mysql = mysql + " , NULL , 0 , NULL , 2 , '' " + SystemVariables.gLoggedInUserCode.ToString();
						mysql = mysql + " , '' , '' , '' , '' , '' , 0 ";
						mysql = mysql + " ) ";
						SqlCommand TempCommand_3 = null;
						TempCommand_3 = SystemVariables.gConn.CreateCommand();
						TempCommand_3.CommandText = mysql;
						TempCommand_3.ExecuteNonQuery();
					}
					else
					{
						mysql = " update pay_head_count";
						mysql = mysql + " set Head_count_status = " + ((chkIsReplacement.CheckState != CheckState.Unchecked) ? 3 : 4).ToString();
						mysql = mysql + "  , Replacement_Status = " + ((chkIsReplacement.CheckState != CheckState.Unchecked) ? "1" : "NULL");
						mysql = mysql + "  , Total_Budget_Salary = " + SystemHRProcedure.GetEmpBudgetSalary(txtCommonTextBox[conTxtEmpCode].Text).ToString();
						mysql = mysql + "  , Is_Budgeted = 0 ";
						mysql = mysql + " where emp_cd = " + ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)).ToString() + " and head_count_status = 2 ";
						SqlCommand TempCommand_4 = null;
						TempCommand_4 = SystemVariables.gConn.CreateCommand();
						TempCommand_4.CommandText = mysql;
						TempCommand_4.ExecuteNonQuery();

						mysql = "update pay_head_count";
						mysql = mysql + " set Head_count_status = 2 ";
						mysql = mysql + "  , Emp_cd = " + ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)).ToString();
						mysql = mysql + "  , Is_Budgeted = 0 ";
						mysql = mysql + "  ,analysis1_cd = ''";
						mysql = mysql + "  ,analysis2_cd = ''";
						mysql = mysql + "  ,analysis3_cd = ''";
						mysql = mysql + "  ,analysis4_cd = ''";
						mysql = mysql + "  ,analysis5_cd = ''";
						mysql = mysql + " where head_count_no = " + txtCommonTextBox[conTxtBudgetHeadCount].Text;
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();
					}
					//mySQL = "update pay_head_count "
					//mySQL = mySQL & " set  Head_count_status =  4"
					//mySQL = mySQL & "  , Is_Budgeted = 0 "
					//mySQL = mySQL & " where head_count_no = " & txtCommonTextBox(conTxtOldBudgetHeadCount).Text
					//gConn.Execute mySQL
				}
			}

			SystemHRProcedure.PayPostToHR("Pay_Salary_Variation", pEntryId);
			if (Information.IsDate(txtEffectiveDate.Value))
			{
				if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtEffectiveDate.Value) <= DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()))
				{
					SystemHRProcedure.PayApprove("Pay_Salary_Variation", pEntryId, "Pay_Salary_Variation_Details");
				}
				else
				{
					SystemHRProcedure.PayApprove("Pay_Salary_Variation", pEntryId);
				}
			}

			SystemHRProcedure.ReGenerateEmployeePayroll(pEmpNo);

		}
	}
}