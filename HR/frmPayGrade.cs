
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayGrade
		: System.Windows.Forms.Form
	{

		public frmPayGrade()
{
InitializeComponent();
} 
 public  void frmPayGrade_old()
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


		private void frmPayGrade_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		public Control FirstFocusObject = null;
		private string mTimeStamp = "";

		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private int mCurrentGrid = 0; //0 for salary grid and 1 for leave grid

		private const int conTabFixedEarning = 0;
		private const int conTabLeaveDetails = 1;
		private const int conTabIndemnityDetails = 2;

		//************For Fixed Earning ****************
		private XArrayHelper _aVoucherDetailsFS = null;
		private XArrayHelper aVoucherDetailsFS
		{
			get
			{
				if (_aVoucherDetailsFS is null)
				{
					_aVoucherDetailsFS = new XArrayHelper();
				}
				return _aVoucherDetailsFS;
			}
			set
			{
				_aVoucherDetailsFS = value;
			}
		}

		private int mLastCol = 0;
		private int mLastRow = 0;
		private bool mFirstGridFocusFS = false;
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


		private const int grdLineNoColumn = 0;
		private const int grdBillingCodeColumn = 1;
		private const int grdBillingNameColumn = 2;
		private const int grdBillingTypeColumn = 3;
		private const int grdCurrentAmtColumn = 4;
		private const int grdIncludeInIndemnity = 5;
		private const int grdRemarksColumn = 6;
		private const int FSMaxColumn = 6;
		//**************END*******************************
		//**************Leave setting *****************************
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

		private DataSet rsLeaveCodeList = null;

		private const int conTxtNWDPerMonthBeforeSOP = 4;
		private const int conTxtNWDPerMonthAfterSOP = 5;
		private const int conTxtSwitchOverPeriod = 7;
		private const int conTxtNLeaveDaysBeforeSOP = 6;
		private const int conTxtNLeaveDaysAfterSOP = 7;

		private const int grdLeaveCodeColumn = 1;
		private const int grdLeaveNameColumn = 2;
		private const int grdWDPerMonthBeforeSOPColumn = 3;
		private const int grdWDPerMonthAfterSOPColumn = 4;
		private const int grdSwitchOverPeriod = 5;
		private const int grdLeaveDaysBeforeSOP = 6;
		private const int grdLeaveDaysAfterSOP = 7;
		private const int grdDeductPaidDays = 8;
		private const int grdDeductUnPaidDays = 9;
		private const int LeaveMaxColumn = 9;

		private const int conCmbDeductPaidDaysLD = 2;
		private const int conCmbDeductUnPaidDaysLD = 3;
		//**************END******************************************
		//**************For Indmnity setting**************************
		private const int conTxtIndemnitySwitchOverPeriodIND = 0;

		private const int conTxtNIndemnityDaysBeforeSOPIND = 0;
		private const int conTxtNWDPerMonthBeforeSOPIND = 1;
		private const int conTxtNIndemnityDaysAfterSOPIND = 2;
		private const int conTxtNWDPerMonthAfterSOPIND = 3;

		private const int conCmbDeductPaidDays = 0;
		private const int conCmbDeductUnPaidDays = 1;
		//*************************END*******************************


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


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			FirstFocusObject = txtGradeNo;

			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;
				//**************************Leave Details *************************
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.65f, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Leave Code", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Leave Name", 4000, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "WDPerMonthBeforeSOPColumn", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "WDPerMonthAfterSOPColumn", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "SwitchOverPeriod", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LeaveDaysBeforeSOP", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LeaveDaysAfterSOP", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "DeductPaidDays", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "DeductUnPaidDays", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				DefineVoucherArray(-1, LeaveMaxColumn, aVoucherDetails, false);
				AssignGridLineNumbers(aVoucherDetails);

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				//*************************END*******************************

				//*******************Fixed Earning ********************************
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetailsFS, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.9f, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetailsFS, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetailsFS, "Billing No.", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersListFS");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetailsFS, "Billing Name", 2700, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, true, true, "cmbMastersListFS");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetailsFS, "Billing Type", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetailsFS, "Current Amt.", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetailsFS, "Include In Indemnity", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetailsFS, "Remarks", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 50);

				DefineVoucherArray(-1, FSMaxColumn, aVoucherDetailsFS, false);
				AssignGridLineNumbers(aVoucherDetailsFS);

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetailsFS.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetailsFS.setArray(aVoucherDetailsFS);
				grdVoucherDetailsFS.Rebind(true);
				//********************END**********************************

				//*********Indemnity Setting **************************
				object[] mObjectId = new object[4];
				mObjectId[conCmbDeductPaidDays] = 1009;
				mObjectId[conCmbDeductUnPaidDays] = 1009;
				mObjectId[conCmbDeductPaidDaysLD] = 1009;
				mObjectId[conCmbDeductUnPaidDaysLD] = 1009;

				SystemCombo.FillComboWithSystemObjects(CmbCommon, mObjectId);
				//*************************END**************************
				tabEmployee.CurrTab = Convert.ToInt16(conTabFixedEarning);
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_Grade_Setting")))
				{
					this.Height = 571;
				}
				else
				{
					this.Height = 267;
				}
				SystemProcedure.SetLabelCaption(this);
				//assign a next code
				txtGradeNo.Text = SystemProcedure2.GetNewNumber("Pay_Grade", "Grade_No");
				mFirstGridFocusFS = true;
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
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
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
			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearNumberBox(this);
			txtGradeNo.Text = SystemProcedure2.GetNewNumber("Pay_Grade", "Grade_No");
			//txtParentgradeNo.Enabled = True

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			FirstFocusObject.Focus();

			int tempForEndVar = grdVoucherDetailsFS.Columns.Count - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				grdVoucherDetailsFS.Columns[cnt].FooterText = "";
			}

			DefineVoucherArray(-1, FSMaxColumn, aVoucherDetailsFS, true);
			AssignGridLineNumbers(aVoucherDetailsFS);
			grdVoucherDetailsFS.Rebind(true);

			DefineVoucherArray(-1, LeaveMaxColumn, aVoucherDetails, true);
			AssignGridLineNumbers(aVoucherDetails);
			grdVoucherDetails.Rebind(true);

			tabEmployee.CurrTab = Convert.ToInt16(conTabFixedEarning);

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord()
		{
			bool result = false;
			object mReturnValue = null;
			int cnt = 0;
			int mBillingCode = 0;
			int mLeaveCode = 0;
			int mIncludeInIndemnity = 0;
			int mJobTypeCd = 0;

			//Dim mParentgradeCode As Integer
			//Save a record
			//During save check for the mode
			//If in addmode then insert a record
			//else update the record in the recordset

			string mysql = "";
			try
			{

				grdVoucherDetails.UpdateData();
				grdVoucherDetailsFS.UpdateData();

				if (SystemProcedure2.IsItEmpty(txtJobTypeNo.Text, SystemVariables.DataType.StringType))
				{
					mysql = " select jobtype_cd from pay_job_type where jobtype_no = '" + txtJobTypeNo.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mJobTypeCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						mJobTypeCd = 0;
					}
				}
				else
				{
					mJobTypeCd = 0;
				}

				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " INSERT INTO Pay_Grade(user_cd, Grade_No, l_grade_name, a_grade_name, comments, jobtype_cd , Min_Salary , Mid_Salary , Max_Salary)";
					mysql = mysql + " VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
					mysql = mysql + txtGradeNo.Text + ",";
					mysql = mysql + "'" + txtLGradeName.Text + "',";
					mysql = mysql + "N'" + txtAGradeName.Text + "',";
					mysql = mysql + "N'" + txtComment.Text + "'";
					mysql = mysql + ", " + ((mJobTypeCd == 0) ? "Null" : mJobTypeCd.ToString());
					mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtNMin.Value);
					mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtNMid.Value);
					mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtNMax.Value);
					mysql = mysql + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));
				}
				else
				{
					mysql = " select time_stamp,protected from Pay_Grade where grade_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
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
					if (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(1)))
					{
						MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}
					mysql = "UPDATE Pay_Grade SET ";
					mysql = mysql + " Grade_No =" + txtGradeNo.Text + ",";
					mysql = mysql + " L_grade_Name ='" + txtLGradeName.Text + "',";
					mysql = mysql + " A_grade_Name =N'" + txtAGradeName.Text + "',";
					mysql = mysql + " Comments =N'" + txtComment.Text + "'";
					mysql = mysql + ", jobtype_cd =  " + ((mJobTypeCd == 0) ? "Null" : mJobTypeCd.ToString());
					mysql = mysql + ", Min_Salary = " + ReflectionHelper.GetPrimitiveValue<string>(txtNMin.Value);
					mysql = mysql + ", Mid_Salary = " + ReflectionHelper.GetPrimitiveValue<string>(txtNMid.Value);
					mysql = mysql + ", Max_Salary = " + ReflectionHelper.GetPrimitiveValue<string>(txtNMax.Value);
					mysql = mysql + ", User_Cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where grade_cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}

				//***************************SAVE FIXED EARNING SETTING **********************************
				mysql = " delete from Pay_Grade_Billing_Details";
				mysql = mysql + " where grade_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();
				if (aVoucherDetailsFS.GetLength(0) > 0)
				{
					int tempForEndVar = aVoucherDetailsFS.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(aVoucherDetailsFS.GetValue(cnt, grdBillingCodeColumn)))
						{
							mysql = " select bill_cd from pay_billing_type where bill_no=" + Convert.ToString(aVoucherDetailsFS.GetValue(cnt, grdBillingCodeColumn));
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mReturnValue))
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								MessageBox.Show("Invalid Billing Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
								grdVoucherDetailsFS.Col = grdBillingCodeColumn;
								grdVoucherDetailsFS.Bookmark = cnt;
								grdVoucherDetailsFS.Focus();
								return false;
							}
							else
							{
								//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mBillingCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								if (((TriState) Convert.ToInt32(aVoucherDetailsFS.GetValue(cnt, grdIncludeInIndemnity))) == TriState.True)
								{
									mIncludeInIndemnity = 1;
								}
								else
								{
									mIncludeInIndemnity = 0;
								}
								mysql = " insert into Pay_Grade_Billing_Details ";
								mysql = mysql + " (grade_cd, bill_cd, amount ";
								mysql = mysql + " , include_in_indemnity, comments ";
								mysql = mysql + " , user_cd) ";
								mysql = mysql + " values(";
								mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
								mysql = mysql + " ," + mBillingCode.ToString();
								mysql = mysql + " ," + Convert.ToString(aVoucherDetailsFS.GetValue(cnt, grdCurrentAmtColumn));
								mysql = mysql + " ," + mIncludeInIndemnity.ToString();
								mysql = mysql + " ,N'" + Convert.ToString(aVoucherDetailsFS.GetValue(cnt, grdRemarksColumn)) + "'";
								mysql = mysql + " ," + Conversion.Str(SystemVariables.gLoggedInUserCode);
								mysql = mysql + ")";
								SqlCommand TempCommand_4 = null;
								TempCommand_4 = SystemVariables.gConn.CreateCommand();
								TempCommand_4.CommandText = mysql;
								TempCommand_4.ExecuteNonQuery();
							}
						}
					}
				}
				//**************************************END*********************************************
				//***************************SAVE LEAVE SETTING **********************************
				mysql = " delete from Pay_Grade_Leave_Details";
				mysql = mysql + " where grade_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_5 = null;
				TempCommand_5 = SystemVariables.gConn.CreateCommand();
				TempCommand_5.CommandText = mysql;
				TempCommand_5.ExecuteNonQuery();

				if (aVoucherDetails.GetLength(0) != 0)
				{
					UpdateGrid(grdVoucherDetails.Bookmark);
				}

				if (aVoucherDetails.GetLength(0) > 0)
				{
					int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar2; cnt++)
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(aVoucherDetails.GetValue(cnt, grdLeaveCodeColumn)))
						{
							mysql = " select leave_cd from pay_leave where leave_no=" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdLeaveCodeColumn));
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mReturnValue))
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								MessageBox.Show("Invalid Leave Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
								grdVoucherDetails.Col = grdLeaveCodeColumn;
								grdVoucherDetails.Bookmark = cnt;
								grdVoucherDetails.Focus();
								return false;
							}
							else
							{
								//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mLeaveCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
							}

							mysql = " insert into pay_grade_leave_details";
							mysql = mysql + " (grade_cd, leave_cd, leave_switch_over_period, leave_days_before_sop ";
							mysql = mysql + " , leave_days_after_sop, working_days_per_month_before_sop";
							mysql = mysql + " , working_days_per_month_after_sop, deduct_paid_days";
							mysql = mysql + " , deduct_unpaid_days";
							mysql = mysql + " , user_cd)";
							mysql = mysql + " values (";
							mysql = mysql + " " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
							mysql = mysql + " ," + mLeaveCode.ToString();
							mysql = mysql + " ," + ((Convert.ToString(aVoucherDetails.GetValue(cnt, grdSwitchOverPeriod)) == "") ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdSwitchOverPeriod))); // txtCommon(conTxtSwitchOverPeriod).Text
							mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdLeaveDaysBeforeSOP));
							mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdLeaveDaysAfterSOP));
							mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdWDPerMonthBeforeSOPColumn));
							mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdWDPerMonthAfterSOPColumn));
							mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdDeductPaidDays));
							mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdDeductUnPaidDays));
							mysql = mysql + " ," + Conversion.Str(SystemVariables.gLoggedInUserCode);
							mysql = mysql + " ) ";
							SqlCommand TempCommand_6 = null;
							TempCommand_6 = SystemVariables.gConn.CreateCommand();
							TempCommand_6.CommandText = mysql;
							TempCommand_6.ExecuteNonQuery();
						}
					}
				}

				//**************************************END*********************************************
				//***************************SAVE INDEMNITY SETTING **********************************
				mysql = " delete from Pay_Grade_Indemnity_Details";
				mysql = mysql + " where grade_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_7 = null;
				TempCommand_7 = SystemVariables.gConn.CreateCommand();
				TempCommand_7.CommandText = mysql;
				TempCommand_7.ExecuteNonQuery();

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(txtCommon[conTxtIndemnitySwitchOverPeriodIND].Text) && txtCommon[conTxtIndemnitySwitchOverPeriodIND].Text != "")
				{
					mysql = "insert into pay_grade_indemnity_details";
					mysql = mysql + " ( grade_cd,indemnity_switch_over_period,indemnity_days_before_sop,indemnity_days_after_sop,indemnity_working_days_per_month_before_sop";
					mysql = mysql + " ,indemnity_working_days_per_month_after_sop,indemnity_deduct_paid_days,indemnity_deduct_unpaid_days";
					mysql = mysql + " ,user_cd)";
					mysql = mysql + " values(";
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					mysql = mysql + " , " + txtCommon[conTxtIndemnitySwitchOverPeriodIND].Text;
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conTxtNIndemnityDaysBeforeSOPIND].Value);
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conTxtNIndemnityDaysAfterSOPIND].Value);
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conTxtNWDPerMonthBeforeSOPIND].Value);
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conTxtNWDPerMonthAfterSOPIND].Value);
					mysql = mysql + " , " + CmbCommon[conCmbDeductPaidDays].GetItemData(CmbCommon[conCmbDeductPaidDays].ListIndex).ToString();
					mysql = mysql + " , " + CmbCommon[conCmbDeductUnPaidDays].GetItemData(CmbCommon[conCmbDeductUnPaidDays].ListIndex).ToString();
					mysql = mysql + " ," + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " ) ";
					SqlCommand TempCommand_8 = null;
					TempCommand_8 = SystemVariables.gConn.CreateCommand();
					TempCommand_8.CommandText = mysql;
					TempCommand_8.ExecuteNonQuery();
				}
				//**************************************END*********************************************

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
			string mysql = " select protected from Pay_Grade where grade_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
				{
					MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				//If an error occurs, trap the error and dispaly a valid message
				SystemVariables.gConn.BeginTransaction();

				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					mysql = "delete from Pay_Grade where grade_cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (Information.Err().Number != 0)
					{
						MessageBox.Show("Product grade cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}

					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();
					result = true;
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}

			return result;

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
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			try
			{
				int cnt = 0;
				string mysql = "";
				object mReturnValue = null;
				SqlDataReader localRec = null;
				SqlDataReader rsFS = null;
				SqlDataReader rsLeave = null;
				SqlDataReader rsInd = null;

				mysql = " select * from Pay_Grade where grade_cd= " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{
					mSearchValue = localRec["grade_cd"];
					mTimeStamp = Convert.ToString(localRec["time_stamp"]);
					txtGradeNo.Text = Convert.ToString(localRec["Grade_No"]);
					txtLGradeName.Text = Convert.ToString(localRec["l_grade_Name"]);
					txtAGradeName.Text = Convert.ToString(localRec["a_grade_Name"]) + "";
					txtComment.Text = Convert.ToString(localRec["Comments"]) + "";
					txtNMin.Value = localRec["Min_Salary"];
					txtNMid.Value = localRec["Mid_Salary"];
					txtNMax.Value = localRec["Max_Salary"];
					if (!Convert.IsDBNull(localRec["jobtype_cd"]))
					{
						mysql = "select jobtype_no , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_Job_Description" : "a_Job_Description");
						mysql = mysql + " from pay_job_type";
						mysql = mysql + " where jobtype_no ='" + Convert.ToString(localRec["jobtype_cd"]) + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtJobTypeNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtJobTypeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						}
						else
						{
							txtJobTypeNo.Text = "";
							txtJobTypeName.Text = "";
						}
					}
					//Change the form mode to edit
					//***************************Fixed Salary***************************
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
					mysql = mysql + " , pgbd.* ";
					mysql = mysql + " from pay_grade_billing_details pgbd ";
					mysql = mysql + " inner join pay_billing_type pbt on pgbd.bill_cd = pbt.bill_cd ";
					mysql = mysql + " where pgbd.grade_cd = " + Conversion.Str(mSearchValue);
					mysql = mysql + " and pbt.show = 1 and pbt.linked_leave_cd is null ";
					SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
					rsFS = sqlCommand_2.ExecuteReader();
					cnt = 0;
					if (rsFS.Read())
					{
						do 
						{
							DefineVoucherArray(cnt, FSMaxColumn, aVoucherDetailsFS, false);
							aVoucherDetailsFS.SetValue(Conversion.Str(cnt + 1).Trim(), cnt, grdLineNoColumn);
							aVoucherDetailsFS.SetValue(rsFS["bill_no"], cnt, grdBillingCodeColumn);
							aVoucherDetailsFS.SetValue(rsFS["bill_name"], cnt, grdBillingNameColumn);
							aVoucherDetailsFS.SetValue(rsFS["bill_type"], cnt, grdBillingTypeColumn);
							aVoucherDetailsFS.SetValue(rsFS["amount"], cnt, grdCurrentAmtColumn);
							aVoucherDetailsFS.SetValue(rsFS["include_in_indemnity"], cnt, grdIncludeInIndemnity);
							aVoucherDetailsFS.SetValue(Convert.ToString(rsFS["comments"]) + "", cnt, grdRemarksColumn);
							cnt++;
						}
						while(rsFS.Read());
					}
					AssignGridLineNumbers(aVoucherDetailsFS);
					grdVoucherDetailsFS.Rebind(true);
					grdVoucherDetailsFS.Refresh();
					rsFS.Close();
					//***************************END************************************
					//***************************Leave Setting***************************
					mysql = " select pl.leave_no ,Leave_Type_Cd ";
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						mysql = mysql + " , pl.l_leave_name as leave_name ";
					}
					else
					{
						mysql = mysql + " , pl.a_leave_name as leave_name";
					}
					mysql = mysql + " , pgld.* ";
					mysql = mysql + " from pay_grade_leave_details pgld ";
					mysql = mysql + " inner join pay_leave pl on pgld.leave_cd = pl.leave_cd ";
					mysql = mysql + " where pgld.grade_cd = " + Conversion.Str(mSearchValue);
					SqlCommand sqlCommand_3 = new SqlCommand(mysql, SystemVariables.gConn);
					rsLeave = sqlCommand_3.ExecuteReader();
					cnt = 0;
					if (rsLeave.Read())
					{
						do 
						{
							DefineVoucherArray(cnt, LeaveMaxColumn, aVoucherDetails, false);
							aVoucherDetails.SetValue(Conversion.Str(cnt + 1).Trim(), cnt, grdLineNoColumn);
							aVoucherDetails.SetValue(rsLeave["leave_no"], cnt, grdLeaveCodeColumn);
							aVoucherDetails.SetValue(rsLeave["leave_name"], cnt, grdLeaveNameColumn);
							aVoucherDetails.SetValue(rsLeave["working_days_per_month_before_sop"], cnt, grdWDPerMonthBeforeSOPColumn);
							aVoucherDetails.SetValue(rsLeave["working_days_per_month_after_sop"], cnt, grdWDPerMonthAfterSOPColumn);
							aVoucherDetails.SetValue(rsLeave["leave_switch_over_period"], cnt, grdSwitchOverPeriod);
							aVoucherDetails.SetValue(rsLeave["leave_days_before_sop"], cnt, grdLeaveDaysBeforeSOP);
							aVoucherDetails.SetValue(rsLeave["leave_days_after_sop"], cnt, grdLeaveDaysAfterSOP);
							aVoucherDetails.SetValue((Convert.ToBoolean(rsLeave["deduct_paid_days"])) ? 1 : 0, cnt, grdDeductPaidDays);
							aVoucherDetails.SetValue((Convert.ToBoolean(rsLeave["deduct_unpaid_days"])) ? 1 : 0, cnt, grdDeductUnPaidDays);
							cnt++;
						}
						while(rsLeave.Read());
					}
					AssignGridLineNumbers(aVoucherDetails);
					grdVoucherDetails.Rebind(true);
					grdVoucherDetails.Refresh();
					rsLeave.Close();
					//***************************END************************************
					//***************************Indemnity Setting***************************
					mysql = " select * from pay_grade_indemnity_details";
					mysql = mysql + " where grade_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand sqlCommand_4 = new SqlCommand(mysql, SystemVariables.gConn);
					rsInd = sqlCommand_4.ExecuteReader();

					if (rsInd.Read())
					{
						txtCommon[conTxtIndemnitySwitchOverPeriodIND].Text = Convert.ToString(rsInd["indemnity_switch_over_period"]);
						txtCommonNumber[conTxtNIndemnityDaysBeforeSOPIND].Value = rsInd["indemnity_days_before_sop"];
						txtCommonNumber[conTxtNIndemnityDaysAfterSOPIND].Value = rsInd["indemnity_days_after_sop"];
						txtCommonNumber[conTxtNWDPerMonthBeforeSOPIND].Value = rsInd["indemnity_working_days_per_month_before_sop"];
						txtCommonNumber[conTxtNWDPerMonthAfterSOPIND].Value = rsInd["indemnity_working_days_per_month_after_sop"];
						SystemCombo.SearchCombo(CmbCommon[conCmbDeductPaidDays], (Convert.ToBoolean(rsInd["indemnity_deduct_paid_days"])) ? 1 : 0);
						SystemCombo.SearchCombo(CmbCommon[conCmbDeductUnPaidDays], (Convert.ToBoolean(rsInd["indemnity_deduct_unpaid_days"])) ? 1 : 0);
					}
					rsInd.Close();
					//***************************END************************************
					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				}
				localRec.Close();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}

		}

		public void PrintReport()
		{

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7007000));
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
			//Check validation during update and add of records
			if (!Information.IsNumeric(txtGradeNo.Text))
			{
				MessageBox.Show("Enter grade Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstFocusObject.Focus();
				return false;
			}

			return true;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmPayGrade.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			//Dim mLastRow As Long

			if (grdVoucherDetails.Col > 0 && LastCol > 0 && !mFirstGridFocus)
			{
				switch(grdVoucherDetails.Col)
				{
					case grdLeaveCodeColumn : case grdLeaveNameColumn : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsLeaveCodeList); 
						break;
				}
			}


			if (grdVoucherDetails.AddNewMode == C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent)
			{
				grdVoucherDetails.Columns[grdLineNoColumn].Text = (grdVoucherDetails.RowCount + 1).ToString();
				grdVoucherDetails.UpdateData();
			}

			//Debug.Print LastRow & "ok"
			if (Information.IsNumeric(LastRow))
			{
				UpdateGrid(LastRow);
			}
			Application.DoEvents();

			if (Information.IsNumeric(grdVoucherDetails.Bookmark))
			{
				UpdateTextBox(grdVoucherDetails.Bookmark);
			}

			if (grdVoucherDetails.AddNewMode == C1.Win.C1TrueDBGrid.AddNewModeEnum.NoAddNew)
			{
				//    If grdVoucherDetails.Row <> LastRow And LastRow <> "" Then
				//        UpdateGrid LastRow
				//        UpdateTextBox grdVoucherDetails.Bookmark
				//    End If

			}
			else if (grdVoucherDetails.AddNewMode == C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent)
			{ 

			}
			else
			{

			}
		}

		private void txtGradeNo_DropButtonClick(Object Sender, EventArgs e)
		{
			//Get the maximum + 1 product_category code
			GetNextNumber();
		}

		public void FindRoutine(string pObjectName)
		{
			//Dim mTempSearchValue As Variant
			//
			//Select Case pObjectName
			//    Case "txtParentgradeNo"
			//        txtParentgradeNo.Text = ""
			//        mTempSearchValue = FindItem(7001000, "727,728,729", mysql)
			//        If Not IsNull(mTempSearchValue) Then
			//            txtParentgradeNo.Text = mTempSearchValue(1)
			//            txtParentgradeName.Text = IIf(gPreferedLanguage = english, mTempSearchValue(2), mTempSearchValue(3))
			//            Call txtParentgradeNo_LostFocus
			//        End If
			//    Case Else
			//        Exit Sub
			//End Select

		}

		public void GetNextNumber()
		{
			txtGradeNo.Text = SystemProcedure2.GetNewNumber("Pay_Grade", "Grade_No");
			FirstFocusObject.Focus();
		}



		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersListFS.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersListFS_RowChange()
		{
			if (grdVoucherDetailsFS.Col == grdBillingCodeColumn || grdVoucherDetailsFS.Col == grdBillingNameColumn)
			{
				if (grdVoucherDetailsFS.Col == grdBillingCodeColumn)
				{
					grdVoucherDetailsFS.Columns[grdBillingNameColumn].Value = cmbMastersListFS.Columns[1].Value;
					grdVoucherDetailsFS.Columns[grdBillingTypeColumn].Value = cmbMastersListFS.Columns[2].Value;
				}
				else
				{
					grdVoucherDetailsFS.Columns[grdBillingCodeColumn].Value = cmbMastersListFS.Columns[0].Value;
					grdVoucherDetailsFS.Columns[grdBillingTypeColumn].Value = cmbMastersListFS.Columns[2].Value;
				}
			}
		}

		private void grdVoucherDetailsFS_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			if (ColIndex == grdCurrentAmtColumn)
			{
				grdVoucherDetailsFS.UpdateData();
				CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetailsFS.Bookmark), ColIndex);
				grdVoucherDetailsFS.Refresh();
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetailsFS.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetailsFS_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == grdCurrentAmtColumn)
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

		private void grdVoucherDetailsFS_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			mCurrentGrid = 0;
			if (mFirstGridFocusFS)
			{
				if (Convert.ToString(cmbMastersListFS.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersListFS);
					cmbMastersListFS.Tag = "OK";
				}

				DefineMasterRecordsetFS();
				mFirstGridFocusFS = false;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetailsFS.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetailsFS.PostMsg(1);
			}
		}


		private void CalculateTotals(int mRowNumber, int mColNumber)
		{
			int cnt = 0;

			double mTotalCurrentAmount = 0;

			int tempForEndVar = aVoucherDetailsFS.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (Convert.ToString(aVoucherDetailsFS.GetValue(cnt, grdBillingTypeColumn)) == "Earnings")
				{
					mTotalCurrentAmount += Conversion.Val(Convert.ToString(aVoucherDetailsFS.GetValue(cnt, grdCurrentAmtColumn)));
				}
				else
				{
					mTotalCurrentAmount -= Conversion.Val(Convert.ToString(aVoucherDetailsFS.GetValue(cnt, grdCurrentAmtColumn)));
				}


			}

			if (mTotalCurrentAmount != 0)
			{
				grdVoucherDetailsFS.Columns[grdCurrentAmtColumn].FooterText = StringsHelper.Format(mTotalCurrentAmount, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetailsFS.Columns[grdCurrentAmtColumn].FooterText = "";
			}
		}

		private void AssignGridLineNumbers(XArrayHelper pVoucherArray)
		{
			int cnt = 0;
			int tempForEndVar = pVoucherArray.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				pVoucherArray.SetValue(cnt + 1, cnt, grdLineNoColumn);
			}
		}

		private void DefineVoucherArray(int pMaximumRows, int pMaxColumn, XArrayHelper pVoucherArray, bool pClearArray = false)
		{
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method pVoucherArray.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				pVoucherArray.Clear();
			}
			pVoucherArray.RedimXArray(new int[]{pMaximumRows, pMaxColumn}, new int[]{0, 0});
		}

		private void grdVoucherDetailsFS_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				int Col = grdVoucherDetailsFS.Col;

				if (Col == grdIncludeInIndemnity)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetailsFS.Columns[Col].Value).Trim() == "")
					{
						grdVoucherDetailsFS.Columns[Col].Value = 0;
					}
					if (KeyAscii == 32)
					{
						KeyAscii = 0;
						grdVoucherDetailsFS.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetailsFS.Columns[Col].Value);
						grdVoucherDetailsFS.UpdateData();
						grdVoucherDetailsFS.Refresh();
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetailsFS.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetailsFS_PostEvent(int MsgId)
		{
			int Col = 0;
			if (MsgId == 2)
			{
				if (mLastCol == grdVoucherDetailsFS.Col && mLastRow == grdVoucherDetailsFS.Row)
				{
					return;
				}
				Col = grdVoucherDetailsFS.Col;
				if (Col == grdIncludeInIndemnity)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetailsFS.Columns[Col].Value) != "")
					{
						grdVoucherDetailsFS.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetailsFS.Columns[Col].Value);
						grdVoucherDetailsFS.UpdateData();
						grdVoucherDetailsFS.Refresh();
					}
				}
			}

			if (MsgId == 1)
			{
				grdVoucherDetailsFS.Col = grdBillingCodeColumn;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersListFS.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersListFS.setDataSource((msdatasrc.DataSource) rsBillingCodeList);
			}
		}

		public void IRoutine()
		{
			int mCurrentLineNo = 0;
			if (mCurrentGrid == 0)
			{
				if (ActiveControl.Name != "grdVoucherDetailsFS")
				{
					grdVoucherDetailsFS.Focus();
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(grdVoucherDetailsFS.Bookmark))
				{
					//UPGRADE_WARNING: (1068) grdVoucherDetailsFS.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetailsFS.Columns[grdLineNoColumn].Value);
					//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetailsFS.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					aVoucherDetailsFS.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetailsFS.Bookmark), 1);
					AssignGridLineNumbers(aVoucherDetailsFS);
					grdVoucherDetailsFS.Rebind(true);
				}
			}
			else if (mCurrentGrid == 1)
			{ 
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
					AssignGridLineNumbers(aVoucherDetails);
					grdVoucherDetails.Rebind(true);
				}
			}
		}

		public void LRoutine()
		{
			if (mCurrentGrid == 0)
			{
				if (ActiveControl.Name != "grdVoucherDetailsFS")
				{
					grdVoucherDetailsFS.Focus();
				}

				if (aVoucherDetailsFS.GetLength(0) > 0)
				{
					grdVoucherDetailsFS.Delete();
					AssignGridLineNumbers(aVoucherDetailsFS);
					CalculateTotals(0, 1);
					grdVoucherDetailsFS.Rebind(true);
				}
			}
			else if (mCurrentGrid == 1)
			{ 
				if (ActiveControl.Name != "grdVoucherDetails")
				{
					grdVoucherDetails.Focus();
				}

				if (aVoucherDetails.GetLength(0) > 0)
				{
					grdVoucherDetails.Delete();
					AssignGridLineNumbers(aVoucherDetails);
					grdVoucherDetails.Rebind(true);
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersListFS.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersListFS_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersListFS.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdVoucherDetailsFS.Col)
			{
				case grdBillingCodeColumn : case grdBillingNameColumn : 
					if (grdVoucherDetailsFS.Col == grdBillingCodeColumn)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersListFS.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersListFS.setListField("bill_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("bill_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersListFS.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersListFS.setListField("bill_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("bill_name");
					} 
					 
					int tempForEndVar = cmbMastersListFS.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersListFS.Splits[0].DisplayColumns[cnt];
						if (cnt < 3)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetailsFS.Col == grdBillingCodeColumn) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetailsFS.Splits[0].DisplayColumns[grdBillingCodeColumn].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetailsFS.Col == grdBillingCodeColumn) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetailsFS.Splits[0].DisplayColumns[grdBillingNameColumn].Width;
							}
							else if (cnt == 2)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetailsFS.Splits[0].DisplayColumns[grdBillingTypeColumn].Width;
							}
							withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							withVar.Visible = true;
							cmbMastersListFS.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					cmbMastersListFS.Width += 17; 
					cmbMastersListFS.Height = 167; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersListFS.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersListFS_DropDownClose()
		{
			switch(grdVoucherDetailsFS.Col)
			{
				case grdBillingCodeColumn : 
					grdVoucherDetailsFS.Col = grdBillingNameColumn; 
					break;
			}
		}

		private void DefineMasterRecordsetFS()
		{
			string mysql = "";

			if (mFirstGridFocusFS)
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
				mysql = mysql + " from pay_billing_type pbt ";
				mysql = mysql + " where pbt.show = 1 and pbt.linked_leave_cd is null ";
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetailsFS.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetailsFS_OnAddNew()
		{
			grdVoucherDetailsFS.Columns[grdLineNoColumn].Text = (grdVoucherDetailsFS.RowCount + 1).ToString();
			grdVoucherDetailsFS.Columns[grdCurrentAmtColumn].Text = "0";
		}

		private void grdVoucherDetailsFS_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdVoucherDetailsFS.Col > 0 && LastCol > 0 && !mFirstGridFocusFS)
			{
				switch(grdVoucherDetailsFS.Col)
				{
					case grdBillingCodeColumn : case grdBillingNameColumn : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersListFS.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersListFS.setDataSource((msdatasrc.DataSource) rsBillingCodeList); 
						break;
				}
			}
		}

		private void grdVoucherDetailsFS_BeforeColEdit(object eventSender, C1.Win.C1TrueDBGrid.BeforeColEditEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int KeyAscii = (int) eventArgs.KeyChar;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if ((ColIndex == grdIncludeInIndemnity) && !Convert.IsDBNull(grdVoucherDetailsFS.Bookmark))
				{
					if (Convert.ToString(aVoucherDetailsFS.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetailsFS.Bookmark), ColIndex)) == "")
					{
						aVoucherDetailsFS.SetValue(0, ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetailsFS.Bookmark), ColIndex);
					}
					if (KeyAscii == 0 || KeyAscii == 13 || KeyAscii == 32)
					{
						aVoucherDetailsFS.SetValue(~Convert.ToInt32(aVoucherDetailsFS.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetailsFS.Bookmark), ColIndex)), ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetailsFS.Bookmark), ColIndex);
						grdVoucherDetailsFS.UpdateData();
						grdVoucherDetailsFS.Refresh();
					}
					Cancel = -1;
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetailsFS.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetailsFS_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			if (Col == grdIncludeInIndemnity)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(aVoucherDetailsFS.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), Col))) == TriState.True)
				{
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgChecked2"];
					CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
				}
				else if (((TriState) Convert.ToInt32(aVoucherDetailsFS.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), Col))) == TriState.False)
				{ 
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgUnchecked"];
					CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
				}
			}
		}

		private void grdVoucherDetailsFS_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (grdVoucherDetailsFS.PointAt(X, Y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
			{
				mLastCol = grdVoucherDetailsFS.Col;
				mLastRow = grdVoucherDetailsFS.Row;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetailsFS.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetailsFS.PostMsg(2);
			}
		}

		//**************************************Leave Coding****************
		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdVoucherDetails.Col)
			{
				case grdLeaveCodeColumn : case grdLeaveNameColumn : 
					if (grdVoucherDetails.Col == grdLeaveCodeColumn)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("leave_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLeaveCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsLeaveCodeList.setSort("leave_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("leave_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLeaveCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsLeaveCodeList.setSort("leave_name");
					} 
					 
					int tempForEndVar = cmbMastersList.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersList.Splits[0].DisplayColumns[cnt];
						if (cnt < 2)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == grdLeaveCodeColumn) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdLeaveCodeColumn].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == grdLeaveCodeColumn) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdLeaveNameColumn].Width;
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
					cmbMastersList.Width = cmbMastersList.Width; 
					cmbMastersList.Height = 167; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			switch(grdVoucherDetails.Col)
			{
				case grdLeaveCodeColumn : 
					grdVoucherDetails.Col = grdLeaveNameColumn; 
					break;
			}
		}
		private void DefineMasterRecordset()
		{
			string mysql = "";

			if (mFirstGridFocus)
			{
				mysql = " select leave_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_leave_name as leave_name" : "a_leave_name as leave_name");
				mysql = mysql + " , is_fixed_leave ";
				//    mysql = mysql & " , leave_days_after_sop, working_days_per_month_before_sop"
				//    mysql = mysql & " , working_days_per_month_after_sop , deduct_paid_days"
				//    mysql = mysql & " , deduct_unpaid_days "
				mysql = mysql + " from pay_leave ";
				mysql = mysql + " order by 1 ";

				rsLeaveCodeList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLeaveCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLeaveCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLeaveCodeList.Tables.Clear();
				adap.Fill(rsLeaveCodeList);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsLeaveCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLeaveCodeList.Requery(-1);
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			object mReturnValue = null;
			if (grdVoucherDetails.Col == grdLeaveCodeColumn || grdVoucherDetails.Col == grdLeaveNameColumn)
			{
				if (grdVoucherDetails.Col == grdLeaveCodeColumn)
				{
					grdVoucherDetails.Columns[grdLeaveNameColumn].Value = cmbMastersList.Columns[1].Value;
				}
				else
				{
					grdVoucherDetails.Columns[grdLeaveCodeColumn].Value = cmbMastersList.Columns[0].Value;
				}
			}

			string mysql = "";
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdVoucherDetails.Bookmark))
			{
				if (!SystemProcedure2.IsItEmpty(cmbMastersList.Columns[0].Value, SystemVariables.DataType.NumberType))
				{
					//If aVoucherDetails(grdVoucherDetails.Bookmark, grdDefaultValuesDisplayedColumn) <> "Y" Then
					mysql = " select is_fixed_leave, leave_switch_over_period, leave_days_before_sop ";
					mysql = mysql + " , leave_days_after_sop, working_days_per_month_before_sop ";
					mysql = mysql + " , working_days_per_month_after_sop , deduct_paid_days ";
					mysql = mysql + " , deduct_unpaid_days ";
					mysql = mysql + " from pay_leave ";
					mysql = mysql + " where leave_no=" + ReflectionHelper.GetPrimitiveValue<string>(cmbMastersList.Columns[0].Value);

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommon[conTxtSwitchOverPeriod].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonNumber[conTxtNLeaveDaysBeforeSOP].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(2));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonNumber[conTxtNLeaveDaysAfterSOP].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(3));
						SystemCombo.SearchCombo(CmbCommon[conCmbDeductPaidDays], (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(6))) ? 1 : 0);
						SystemCombo.SearchCombo(CmbCommon[conCmbDeductUnPaidDays], (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(7))) ? 1 : 0);

						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonNumber[conTxtNWDPerMonthBeforeSOP].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(4));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonNumber[conTxtNWDPerMonthAfterSOP].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(5));
					}
				}
			}

		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			//If ColIndex = grdLeaveCodeColumn Or ColIndex = grdLeaveNameColumn Then
			//    grdVoucherDetails.Update
			//    Call CalculateTotals(CInt(grdVoucherDetails.Bookmark), ColIndex)
			//    grdVoucherDetails.Refresh
			//End If
		}

		private void grdVoxucherDetails_FormatText(int ColIndex, object Value, object Bookmark)
		{
			//If ColIndex = grdPaidLeaveTakenDaysColumn Or ColIndex = grdTotalPaidLeaveBalanceDaysColumn Then
			//    If Val(Value) <> 0 Then
			//        Value = Format(Value, "###,###,###,###,###.000")
			//    Else
			//        Value = ""
			//    End If
			//End If
		}

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			mCurrentGrid = 1;
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{
			int Col = 0;

			if (MsgId == 1)
			{
				grdVoucherDetails.Col = grdLeaveCodeColumn;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsLeaveCodeList);
			}
		}

		private void UpdateTextBox(object pBookmark)
		{
			txtCommon[conTxtSwitchOverPeriod].Text = Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdSwitchOverPeriod));
			txtCommonNumber[conTxtNLeaveDaysBeforeSOP].Value = aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdLeaveDaysBeforeSOP);
			txtCommonNumber[conTxtNLeaveDaysAfterSOP].Value = aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdLeaveDaysAfterSOP);

			txtCommonNumber[conTxtNWDPerMonthBeforeSOP].Value = aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdWDPerMonthBeforeSOPColumn);
			txtCommonNumber[conTxtNWDPerMonthAfterSOP].Value = aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdWDPerMonthAfterSOPColumn);

			//txtCommonNumber(conTxtNMaximumLeave).Value = aVoucherDetails(pBookmark, grdMaximumLeaveDays)

			//txtCommonNumber(conTxtNOpeningPaidLeaveBalanceDays).Value = aVoucherDetails(pBookmark, grdOpeningPaidLeaveBalDaysColumn)
			//If IsDate(aVoucherDetails(pBookmark, grdOpeningPaidLeaveBalDateColumn)) Then
			//    txtOpeningBalanceAsOn.Value = aVoucherDetails(pBookmark, grdOpeningPaidLeaveBalDateColumn)
			//Else
			//    txtOpeningBalanceAsOn.Text = ""
			//End If
			//txtCommonNumber(conTxtNOpeningPaidLeaveTakenDays).Value = aVoucherDetails(pBookmark, grdOpeningPaidLeaveTakenDaysColumn)

			//txtDisplayLabel(conDlblPaidLeaveTakenDays).Text = Format(aVoucherDetails(pBookmark, grdPaidLeaveTakenDaysColumn), "###,###,##0.000")
			//txtDisplayLabel(conDlblTotalPaidLeaveTakenDays).Text = Format(aVoucherDetails(pBookmark, grdOpeningPaidLeaveTakenDaysColumn) + aVoucherDetails(pBookmark, grdPaidLeaveTakenDaysColumn), "###,###,##0.000")


			//txtCommonNumber(conTxtNOpeningUnpaidLeaveTakenDays).Value = aVoucherDetails(pBookmark, grdOpeningUnPaidLeaveTakenDaysColumn)
			//txtDisplayLabel(conDlblUnPaidLeaveTakenDays).Text = Format(aVoucherDetails(pBookmark, grdUnPaidLeaveTakenDaysColumn), "###,###,##0.000")
			//txtDisplayLabel(conDlblTotalUnPaidLeaveTakenDays).Text = Format(aVoucherDetails(pBookmark, grdOpeningUnPaidLeaveTakenDaysColumn) + aVoucherDetails(pBookmark, grdUnPaidLeaveTakenDaysColumn), "###,###,##0.000")

			SystemCombo.SearchCombo(CmbCommon[conCmbDeductPaidDaysLD], Convert.ToInt32(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdDeductPaidDays)));
			SystemCombo.SearchCombo(CmbCommon[conCmbDeductUnPaidDaysLD], Convert.ToInt32(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdDeductUnPaidDays)));

			//txtDisplayLabel(conDlblLeaveBalanceAsOf).Text = aVoucherDetails(pBookmark, grdLeaveBalanceAsOf)
			//txtDisplayLabel(conDlblLeaveBalance).Text = aVoucherDetails(pBookmark, grdLeaveBalanceDays)

			//''''Get the Leave balance days as on today
			//Dim mysql As String
			//Dim mReturnValue As Variant
			//Dim mLeaveCode As Integer
			//
			//If Not IsItEmpty(aVoucherDetails(pBookmark, grdLeaveCodeColumn), NumberType) And Not IsItEmpty(mSearchValue, NumberType) Then
			//    mysql = " select leave_cd from pay_leave where leave_no=" & aVoucherDetails(pBookmark, grdLeaveCodeColumn)
			//    mReturnValue = GetMasterCode(mysql)
			//    If IsNull(mReturnValue) Then
			//        Exit Sub
			//    Else
			//        mLeaveCode = mReturnValue
			//    End If
			//
			//    mReturnValue = Leave_Balance_Days(CLng(mSearchValue), mLeaveCode, Date)
			//    lblCommon(conLblLeaveBalanceAsOf).Caption = "Leave Balance As Of " & Format(Date, gSystemDateFormat)
			//    txtDisplayLabel(conDlblLeaveBalanceAsOf).Text = Format(mReturnValue, "###,###,##0.000")
			//Else
			//    txtDisplayLabel(conDlblLeaveBalanceAsOf).Text = ""
			//    lblCommon(conLblLeaveBalanceAsOf).Caption = ""
			//End If

		}


		private void UpdateGrid(object pRow)
		{
			aVoucherDetails.SetValue(txtCommon[conTxtSwitchOverPeriod].Text, ReflectionHelper.GetPrimitiveValue<int>(pRow), grdSwitchOverPeriod);
			aVoucherDetails.SetValue(txtCommonNumber[conTxtNWDPerMonthBeforeSOP].Value, ReflectionHelper.GetPrimitiveValue<int>(pRow), grdWDPerMonthBeforeSOPColumn);
			aVoucherDetails.SetValue(txtCommonNumber[conTxtNWDPerMonthAfterSOP].Value, ReflectionHelper.GetPrimitiveValue<int>(pRow), grdWDPerMonthAfterSOPColumn);
			//aVoucherDetails(pRow, grdOpeningPaidLeaveBalDaysColumn) = txtCommonNumber(conTxtNOpeningPaidLeaveBalanceDays).Value
			//aVoucherDetails(pRow, grdOpeningPaidLeaveBalDateColumn) = txtOpeningBalanceAsOn.DisplayText
			//aVoucherDetails(pRow, grdOpeningPaidLeaveTakenDaysColumn) = txtCommonNumber(conTxtNOpeningPaidLeaveTakenDays).Value
			//aVoucherDetails(pRow, grdOpeningUnPaidLeaveTakenDaysColumn) = txtCommonNumber(conTxtNOpeningUnpaidLeaveTakenDays).Value

			aVoucherDetails.SetValue(txtCommonNumber[conTxtNLeaveDaysBeforeSOP].Value, ReflectionHelper.GetPrimitiveValue<int>(pRow), grdLeaveDaysBeforeSOP);
			aVoucherDetails.SetValue(txtCommonNumber[conTxtNLeaveDaysAfterSOP].Value, ReflectionHelper.GetPrimitiveValue<int>(pRow), grdLeaveDaysAfterSOP);
			//aVoucherDetails(pRow, grdMaximumLeaveDays) = txtCommonNumber(conTxtNMaximumLeave).Value

			aVoucherDetails.SetValue(CmbCommon[conCmbDeductPaidDays].GetItemData(CmbCommon[conCmbDeductPaidDays].ListIndex), ReflectionHelper.GetPrimitiveValue<int>(pRow), grdDeductPaidDays);
			aVoucherDetails.SetValue(CmbCommon[conCmbDeductUnPaidDays].GetItemData(CmbCommon[conCmbDeductUnPaidDays].ListIndex), ReflectionHelper.GetPrimitiveValue<int>(pRow), grdDeductUnPaidDays);
			//aVoucherDetails(pRow, grdLeaveBalanceAsOf) = txtDisplayLabel(conDlblLeaveBalanceAsOf).Text

		}

		private void txtJobTypeNo_DropButtonClick(Object Sender, EventArgs e)
		{
			txtJobTypeName.Text = "";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220600, "2734"));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtJobTypeNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				txtJobTypeNo_Leave(txtJobTypeNo, new EventArgs());
			}
		}

		private void txtJobTypeNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				string mysql = "";
				object mTempValue = null;
				if (!SystemProcedure2.IsItEmpty(txtJobTypeNo.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_Job_Description" : "a_Job_Description");
					mysql = mysql + " from pay_job_type";
					mysql = mysql + " where jobtype_no ='" + txtJobTypeNo.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtJobTypeName.Text = "";
						txtJobTypeNo.Text = "";
						MessageBox.Show("Job Type is not Exist", "Daily Payroll", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtJobTypeName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtJobTypeName.Text = "";
					txtJobTypeNo.Text = "";
					return;
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}
	}
}