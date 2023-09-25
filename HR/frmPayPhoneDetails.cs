
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayPhoneDetails
		: System.Windows.Forms.Form
	{

		public frmPayPhoneDetails()
{
InitializeComponent();
} 
 public  void frmPayPhoneDetails_old()
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


		private void frmPayPhoneDetails_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private string mTimeStamp = "";
		private clsToolbar oThisFormToolBar = null;
		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

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

		private const int mConEmpCode = 1;
		private const int mConName = 2;
		private const int mConMobileNo = 3;
		private const int mConMobileAllowance = 5;
		private const int mCondate = 4;
		private const int mConInvoiceTotal = 6;
		private const int mConLocalCalls = 7;
		private const int mConMobile = 8;
		private const int mConMessage = 9;
		private const int mConRank = 10;
		private const int mConDeduction = 11;
		private const int mConRemarks = 12;
		private const int conMaxColumns = 12;

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


		private void cmdClear_Click(Object eventSender, EventArgs eventArgs)
		{

			string mysql = "update pay_phone_details";
			mysql = mysql + " set invoice_total = 0, Deducted_Value =0";
			mysql = mysql + " where pay_date = '" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();
			GetRecord();

		}

		private void cmdFilterByDept_Click(Object eventSender, EventArgs eventArgs)
		{
			GetRecord();
		}

		private void cmdImportPhoneDeduction_Click(Object eventSender, EventArgs eventArgs)
		{
			clsHourGlass mHourGlass = null;
			DataSet rsPhone = null;
			try
			{
				mHourGlass = null;
				rsPhone = null;
				int cnt = 0;
				string mFileName = "";

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				CommonDialog1Open.FileName = "";
				//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property CommonDialog1.Flags was upgraded to CommonDialog1Open.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
				//UPGRADE_WARNING: (2074) FileOpenConstants STRING RESOURCE ["IDS-CONSTANT"] NOT FOUND FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
				CommonDialog1Open.ShowReadOnly = false;
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				CommonDialog1Open.Filter = "Text (*.txt)|*.txt|Excel (*.xls)|*.xls";
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FilterIndex was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				CommonDialog1Open.FilterIndex = 2;
				CommonDialog1Open.ShowDialog();

				mHourGlass = new clsHourGlass();
				rsPhone = new DataSet();

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (CommonDialog1Open.FileName != "")
				{
					//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsPhone.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsPhone.setDataSource(Read_Excel(CommonDialog1Open.FileName));
				}
				else
				{
					mHourGlass = null;
					return;
				}
				mFileName = "C:\\PhoneDedError_" + DateAndTime.Day(DateTime.Today).ToString() + "_" + DateTime.Today.Year.ToString() + ".txt";
				//'Importing Phone Deduction in Phone Deduction Table.....
				FileSystem.FileClose(1);
				FileSystem.FileOpen(1, mFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);

				foreach (DataRow iteration_row in rsPhone.Tables[0].Rows)
				{
					int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						if (Convert.ToInt32(aVoucherDetails.GetValue(cnt, mConMobileNo)) == Convert.ToDouble(iteration_row["MobileNo"]))
						{
							if (ReflectionHelper.IsLessThan(aVoucherDetails.GetValue(cnt, mConMobileAllowance), iteration_row["Amount"]))
							{
								aVoucherDetails.SetValue(iteration_row["Amount"], cnt, mConInvoiceTotal);
								aVoucherDetails.SetValue(Math.Abs(Convert.ToDouble(aVoucherDetails.GetValue(cnt, mConMobileAllowance)) - Convert.ToDouble(aVoucherDetails.GetValue(cnt, mConInvoiceTotal))), cnt, mConDeduction);
								goto NEXTPHONE;
							}
							else
							{
								aVoucherDetails.SetValue(iteration_row["Amount"], cnt, mConInvoiceTotal);
								goto NEXTPHONE;
							}
						}
					}
					FileSystem.PrintLine(1, "Mobile no does not exists : " + Convert.ToString(iteration_row["MobileNo"]));
					NEXTPHONE:;
				}
				//''End
				FileSystem.FileClose(1);

				CalculateTotals();
				grdPhoneDetails.Rebind(true);
				grdPhoneDetails.Refresh();

				mHourGlass = null;
				rsPhone = null;
			}
			catch (System.Exception excep)
			{
				mHourGlass = null;
				rsPhone = null;
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = false;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = false;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = false;
				oThisFormToolBar.ShowHelpButton = false;
				oThisFormToolBar.ShowInsertLineButton = false;
				oThisFormToolBar.ShowDeleteLineButton = false;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = false;

				this.WindowState = FormWindowState.Maximized;
				FirstFocusObject = txtDeductionCode;

				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdPhoneDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdPhoneDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdPhoneDetails, "Employee Code", 800, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdPhoneDetails, "Name", 2500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Center);
				SystemGrid.DefineSystemVoucherGridColumn(grdPhoneDetails, "Mobile No", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdPhoneDetails, "Date", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdPhoneDetails, "Mobile Allowance", 850, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdPhoneDetails, "Invoice Total", 850, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdPhoneDetails, "Local Calls", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdPhoneDetails, "Mobile Calls", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdPhoneDetails, "Messages", 850, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdPhoneDetails, "Rank", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdPhoneDetails, "Deduction Amount", 850, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Red).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdPhoneDetails, "Remarks", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);



				SystemProcedure.SetLabelCaption(this);

				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdPhoneDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdPhoneDetails.setArray(aVoucherDetails);
				grdPhoneDetails.Rebind(true);
				GetRecord();
				grdPhoneDetails.Visible = true;
				grdPhoneDetails.Enabled = true;
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
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


		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, SystemICSConstants.grdLineNoColumn);
			}
		}

		private void GetRecord()
		{
			int mCntRow = 0;

			string mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();
			string mysql = "select bill_no from pay_billing_type";
			mysql = mysql + " where bill_cd=" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("phone_deduction_bill_cd"));
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDeductionCode.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				txtDeductionCode_Leave(txtDeductionCode, new EventArgs());
			}

			mysql = "select ppd.* , pemp.emp_no";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " , pemp.l_full_name " : " , pemp.a_full_name ") + " as name";
			mysql = mysql + " from pay_phone_details ppd";
			mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = ppd.emp_cd";
			mysql = mysql + " inner join pay_department pdept on pemp.dept_cd = pdept.dept_cd";
			mysql = mysql + " where ppd.pay_date='" + mGenerateDate + "'";
			if (!SystemProcedure2.IsItEmpty(txtDepartmentCode.Text, SystemVariables.DataType.StringType))
			{
				mysql = mysql + " and pdept.dept_no=" + txtDepartmentCode.Text;
			}

			DataSet rsLocalRecCol = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsLocalRecCol.Tables.Clear();
			adap.Fill(rsLocalRecCol);
			aVoucherDetails.RedimXArray(new int[]{rsLocalRecCol.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
			mCntRow = 0;
			foreach (DataRow iteration_row in rsLocalRecCol.Tables[0].Rows)
			{
				aVoucherDetails.SetValue(iteration_row["emp_no"], mCntRow, mConEmpCode);
				aVoucherDetails.SetValue(iteration_row["name"], mCntRow, mConName);
				aVoucherDetails.SetValue(iteration_row["Mobile"], mCntRow, mConMobileNo);
				aVoucherDetails.SetValue(iteration_row["pay_date"], mCntRow, mCondate);
				aVoucherDetails.SetValue(iteration_row["invoice_total"], mCntRow, mConInvoiceTotal);
				aVoucherDetails.SetValue(iteration_row["Local_Calls"], mCntRow, mConLocalCalls);
				aVoucherDetails.SetValue(iteration_row["Mobiles"], mCntRow, mConMobile);
				aVoucherDetails.SetValue(iteration_row["Messages"], mCntRow, mConMessage);
				aVoucherDetails.SetValue(iteration_row["Rank"], mCntRow, mConRank);
				aVoucherDetails.SetValue(iteration_row["Deducted_Value"], mCntRow, mConDeduction);
				aVoucherDetails.SetValue(iteration_row["Remarks"], mCntRow, mConRemarks);
				aVoucherDetails.SetValue(iteration_row["mobile_allowance_amount"], mCntRow, mConMobileAllowance);
				mCntRow++;
			}

			AssignGridLineNumbers();
			CalculateTotals();
			grdPhoneDetails.Rebind(true);
			grdPhoneDetails.Refresh();
			//FirstFocusObject.SetFocus

		}

		private void grdPhoneDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			double mDeductionAmt = 0;
			//UPGRADE_WARNING: (1068) grdPhoneDetails.Bookmark of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int grdRow = ReflectionHelper.GetPrimitiveValue<int>(grdPhoneDetails.Bookmark);
			if (ColIndex == mConInvoiceTotal)
			{
				mDeductionAmt = ReflectionHelper.GetPrimitiveValue<double>(grdPhoneDetails.Columns[ColIndex].Value) - Convert.ToDouble(aVoucherDetails.GetValue(grdRow, mConMobileAllowance));
				aVoucherDetails.SetValue(Math.Max(mDeductionAmt, 0), grdRow, mConDeduction);
			}
			CalculateTotals();
			grdPhoneDetails.Refresh();
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdPhoneDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdPhoneDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == mConMobileAllowance || ColIndex == mConDeduction || ColIndex == mConInvoiceTotal)
			{
				Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###,###,##0.000");
			}
		}



		private void txtDeductionCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtDeductionCode");
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;
			string mysql = "";

			if (pObjectName == "txtDeductionCode")
			{
				txtDeductionCode.Text = "";
				mysql = " pbt.show =  1 and pbt.bill_type_id= 52";
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7008000, "775", mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDeductionCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtDeductionCode_Leave(txtDeductionCode, new EventArgs());
				}
				else
				{
					MessageBox.Show("Invalid Deduction code.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtDeductionCode.Focus();
				}
			}
			else if (pObjectName == "txtDepartmentCode")
			{ 
				txtDepartmentCode.Text = "";
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7001000, "727"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDepartmentCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtDepartmentCode_Leave(txtDepartmentCode, new EventArgs());
				}
			}

		}

		private void txtDeductionCode_Leave(Object eventSender, EventArgs eventArgs)
		{

			string mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pbt.l_bill_name" : "pbt.a_bill_name");
			mysql = mysql + " from pay_billing_type pbt ";
			mysql = mysql + " where bill_no ='" + txtDeductionCode.Text + "'";
			mysql = mysql + " and bill_type_id = 52 ";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDeductionCodeName.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
			}
			else
			{
				txtDeductionCode.Text = "";
				txtDeductionCodeName.Text = "";
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				object mReturnValue = null;
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}
				if (KeyCode == ((int) Keys.F2))
				{
					if (Support.GetActiveControl().Name == grdPhoneDetails.Name)
					{
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831"));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							if (!FindEmployeeCode(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1))))
							{
								MessageBox.Show(" Could not locate the specific Employee Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}
						}
						return;
					}
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

		private bool FindEmployeeCode(string pEmp_no)
		{
			int mCnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (mCnt = 0; mCnt <= tempForEndVar; mCnt++)
			{
				if (Convert.ToString(aVoucherDetails.GetValue(mCnt, mConEmpCode)) == pEmp_no)
				{
					grdPhoneDetails.Bookmark = mCnt;
					grdPhoneDetails.Col = mConInvoiceTotal;
					return true;
				}
			}
			return false;
		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool saveRecord()
		{
			bool result = false;
			string mysql = "";
			int mCntRow = 0;
			int mDeductionCode = 0;
			object mReturnValue = null;
			string mGenerateDate = "";
			try
			{

				mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();
				mysql = " select bill_cd from pay_billing_type";
				mysql = mysql + " where bill_no=" + txtDeductionCode.Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDeductionCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					MessageBox.Show("Invalid Deduction Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtDeductionCode.Focus();
				}
				grdPhoneDetails.UpdateData();
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (mCntRow = 0; mCntRow <= tempForEndVar; mCntRow++)
				{
					mysql = " update pay_phone_details";
					mysql = mysql + " set Invoice_Total =" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, mConInvoiceTotal));
					mysql = mysql + " , Local_Calls =" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, mConLocalCalls));
					mysql = mysql + " , Mobiles =" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, mConMobile));
					mysql = mysql + " , Messages =" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, mConMessage));
					mysql = mysql + " , Rank =" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, mConRank));
					mysql = mysql + " , Deducted_Value=" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, mConDeduction));
					mysql = mysql + " , Remarks='" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, mConRemarks)) + "'";
					mysql = mysql + " , deduction_bill_cd=" + mDeductionCode.ToString();
					mysql = mysql + " from pay_phone_details ";
					mysql = mysql + " inner join  pay_employee pemp on pemp.emp_cd = pay_phone_details.emp_cd";
					mysql = mysql + " where pemp.emp_no = '" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, mConEmpCode)) + "'";
					mysql = mysql + " and pay_phone_details.mobile ='" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, mConMobileNo)) + "'";
					mysql = mysql + " and pay_phone_details.pay_date='" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, mCondate)) + "'";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				//Call ClearPayroll(mGenerateDate)
				SystemHRProcedure.GeneratePayrollEntry(mGenerateDate, "", "");
				//Call GenerateLeaveEntry(mGenerateDate, "", "")
				//Call GenerateLoanEntry(mGenerateDate, "", "")

				result = true;
				MessageBox.Show("Record has been saved successfully!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
			}
			return result;
		}

		public bool CheckDataValidity()
		{
			//Check validation during update and add of records
			if (SystemProcedure2.IsItEmpty(txtDeductionCode.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Invalid Deduction Code.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtDeductionCode.Focus();
				return false;
			}

			return true;
		}

		public bool deleteRecord()
		{
			//Dim mysql As String
			//Dim mReturnValue  As Variant
			//
			//gConn.BeginTrans
			//On Error Resume Next
			//
			//mysql = " delete from pay_payroll "
			//mysql = mysql & " where pay_date = '" & Format(GetPayrollGenerateDate, gSystemDateFormat) & "' and trans_type ='EmpPhoneTrn'"
			//gConn.Execute mysql 'first delete all the generated information
			//
			//mysql = "delete from pay_phone_details where pay_date='" & Format(GetPayrollGenerateDate, gSystemDateFormat) & "'"
			//gConn.Execute mysql
			//
			//If Err.Number <> 0 Then
			//    MsgBox "Phone Details cannot be deleted, transaction already occurs", vbInformation
			//    gConn.RollBackTrans
			//    deleteRecord = False
			//    Exit Function
			//End If
			//
			//gConn.CommitTrans
			//deleteRecord = True
			//Call ClearGrid
			return false;
		}



		public void ClearGrid()
		{
			int cnt = 0;
			try
			{
				int tempForEndVar = grdPhoneDetails.Columns.Count - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					grdPhoneDetails.Columns[cnt].FooterText = "";
					if (cnt > 4)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdPhoneDetails.Splits[0].DisplayColumns[cnt].Style.BackColor = Color.White;
					}
				}
				DefineVoucherArray(-1, true);
				AssignGridLineNumbers();
				grdPhoneDetails.Rebind(true);
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}
		}


		private void CalculateTotals()
		{
			int cnt = 0;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				double mTotalMobileAllowance = 0;
				double mTotalInvDetails = 0;
				double mTotalDection = 0;

				grdPhoneDetails.UpdateData();
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					mTotalMobileAllowance += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, mConMobileAllowance)));
					mTotalInvDetails += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, mConInvoiceTotal)));
					mTotalDection += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, mConDeduction)));
				}

				if (mTotalMobileAllowance != 0)
				{
					grdPhoneDetails.Columns[mConMobileAllowance].FooterText = StringsHelper.Format(mTotalMobileAllowance, "###,###,###,###,##0.000");
				}
				else
				{
					grdPhoneDetails.Columns[mConMobileAllowance].FooterText = "";
				}

				if (mTotalInvDetails != 0)
				{
					grdPhoneDetails.Columns[mConInvoiceTotal].FooterText = StringsHelper.Format(mTotalInvDetails, "###,###,###,###,##0.000");
				}
				else
				{
					grdPhoneDetails.Columns[mConInvoiceTotal].FooterText = "";
				}

				if (mTotalDection != 0)
				{
					grdPhoneDetails.Columns[mConDeduction].FooterText = StringsHelper.Format(mTotalDection, "###,###,###,###,##0.000");
				}
				else
				{
					grdPhoneDetails.Columns[mConDeduction].FooterText = "";
				}
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdPhoneDetails.Splits[0].DisplayColumns[mConDeduction].FooterStyle.ForeColor = Color.Red;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtDepartmentCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtDepartmentCode");
		}

		private void txtDepartmentCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mTempValue = null;

			if (!SystemProcedure2.IsItEmpty(txtDepartmentCode.Text, SystemVariables.DataType.NumberType))
			{
				mysql = "select dept_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
				mysql = mysql + " from pay_department ";
				mysql = mysql + " where ";
				mysql = mysql + " dept_no = " + txtDepartmentCode.Text;

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempValue))
				{
					txtDepartmentName.Text = "";
					throw new System.Exception("-9990002");
				}
				else
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDepartmentName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
				}
			}
			else
			{
				txtDepartmentName.Text = "";
			}
		}

		public DataSet Read_Excel(string sFile)
		{
			DataSet result = null;
			try
			{
				DataSet rs = null;
				string sconn = "";
				rs = new DataSet();

				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rs.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rs.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				//UPGRADE_ISSUE: (2064) ADODB.CursorTypeEnum property CursorTypeEnum.adOpenKeyset was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rs.CursorType was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rs.setCursorType(UpgradeStubs.ADODB_CursorTypeEnum.getadOpenKeyset());
				//UPGRADE_ISSUE: (2064) ADODB.LockTypeEnum property LockTypeEnum.adLockBatchOptimistic was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rs.LockType was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rs.setLockType(UpgradeStubs.ADODB_LockTypeEnum.getadLockBatchOptimistic());

				sconn = "DRIVER=Microsoft Excel Driver (*.xls);" + "DBQ=" + sFile;
				SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM [sheet1$]", sconn);
				rs.Tables.Clear();
				adap.Fill(rs);

				result = rs;
				rs = null;
			}
			catch (System.Exception excep)
			{

				Debug.WriteLine(Support.TabLayout(excep.Message + " " + excep.Source, ((int) MsgBoxStyle.Critical).ToString(), "Import"));
			}
			return result;
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}