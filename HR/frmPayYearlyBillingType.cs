
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayYearlyBillingDetails
		: System.Windows.Forms.Form
	{

		private clsAccessAllowed _UserAccess = null;
		public frmPayYearlyBillingDetails()
{
InitializeComponent();
} 
 public  void frmPayYearlyBillingDetails_old()
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
		private string mTimeStamp = "";
		private clsToolbar oThisFormToolBar = null;
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

		private const int grdLineNoColumn = 0;
		private const int grdBillingCodeColumn = 1;
		private const int grdBillingNameColumn = 2;
		private const int grdBillingTypeColumn = 3;
		//Private Const grdLastChangeDateColumn  As Integer = 4
		private const int grdLastAmtColumn = 4;
		private const int grdCurrentAmtColumn = 5;
		private const int grdRemarksColumn = 6;

		private const int conDlblEmpCode = 0;
		private const int conDlblEmpName = 1;


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
				//On Error Resume Next
				//FirstFocusObject.SetFocus
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				FirstFocusObject = grdVoucherDetails;

				//picFormToolbar.Visible = False
				grdVoucherDetails.Visible = false;

				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = false;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = false;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //setting form mode to add initially
				mFirstGridFocus = true;

				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.9f, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing No.", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing Name", 2700, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing Type", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "LastChange Date", 950, False, gDisableColumnBackColor, &H295C36, dbgRight, True, , dbgRight, , , , , , , , , , True)
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Last Amt.", 900, false, SystemConstants.gDisableColumnBackColor, (0x295C36).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Current Amt.", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 50);

				SystemProcedure.SetLabelCaption(this);

				clsFlip oFlipThisForm = null;
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
				{
					oFlipThisForm = new clsFlip();
					oFlipThisForm.SwapMe(this);
				}

				//setting voucher details grid properties
				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				//-- end of voucher grid property setting

				grdVoucherDetails.Visible = true;
				grdVoucherDetails.Enabled = false;
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
						if (grdVoucherDetails.Col == grdCurrentAmtColumn)
						{
							if ((KeyCode == 8) || (KeyCode == 46) || (KeyCode == 27))
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
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
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
				frmPayBillingDetails.DefInstance = null;
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
					grdVoucherDetails.Columns[grdBillingTypeColumn].Value = cmbMastersList.Columns[2].Value;
				}
				else
				{
					grdVoucherDetails.Columns[grdBillingCodeColumn].Value = cmbMastersList.Columns[0].Value;
					grdVoucherDetails.Columns[grdBillingTypeColumn].Value = cmbMastersList.Columns[2].Value;
				}
			}
		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			if (ColIndex == grdCurrentAmtColumn)
			{
				grdVoucherDetails.UpdateData();
				CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);
				grdVoucherDetails.Refresh();
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == grdLastAmtColumn || ColIndex == grdCurrentAmtColumn)
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

			double mTotalLastAmount = 0;
			double mTotalCurrentAmount = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingTypeColumn)) == "Earnings")
				{
					mTotalLastAmount += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdLastAmtColumn)));
					mTotalCurrentAmount += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdCurrentAmtColumn)));
				}
				else
				{
					mTotalLastAmount -= Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdLastAmtColumn)));
					mTotalCurrentAmount -= Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdCurrentAmtColumn)));
				}
			}

			if (mTotalLastAmount != 0)
			{
				grdVoucherDetails.Columns[grdLastAmtColumn].FooterText = StringsHelper.Format(mTotalLastAmount, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails.Columns[grdLastAmtColumn].FooterText = "";
			}
			if (mTotalCurrentAmount != 0)
			{
				grdVoucherDetails.Columns[grdCurrentAmtColumn].FooterText = StringsHelper.Format(mTotalCurrentAmount, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails.Columns[grdCurrentAmtColumn].FooterText = "";
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
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, 8}, new int[]{0, 0});
		}

		public bool saveRecord(bool pApprove = false)
		{
			int mBillingCode = 0;

			object mReturnValue = null;
			string mysql = "";
			SqlDataReader rsTempRec = null;
			int cnt = 0;
			try
			{

				if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Select an Employee!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				SystemVariables.gConn.BeginTransaction();


				//Delete from employee_billing_details, the records which are not there in the grid
				//''**** check this because the record should not be deleted if the salary variation exists
				//'''for the billing code

				mysql = " select pbt.bill_cd from pay_employee_Yearly_billing_details peybt ";
				mysql = mysql + " inner join pay_billing_type pbt on peybt.bill_cd = pbt.bill_cd ";
				mysql = mysql + " where pbt.show = 1 and pbt.linked_leave_cd is null ";
				mysql = mysql + " and emp_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsTempRec = sqlCommand.ExecuteReader();
				rsTempRec.Read();
				do 
				{
					if (aVoucherDetails.GetLength(0) == 0)
					{
						//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
						try
						{
							mysql = " delete from pay_employee_yearly_billing_details ";
							mysql = mysql + " from pay_employee_yearly_billing_details peybt ";
							mysql = mysql + " inner join pay_billing_type pbt on peybt.bill_cd = pbt.bill_cd ";
							mysql = mysql + " where pbt.show = 1 and pbt.linked_leave_cd is null ";
							mysql = mysql + " and emp_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
							SqlCommand TempCommand = null;
							TempCommand = SystemVariables.gConn.CreateCommand();
							TempCommand.CommandText = mysql;
							TempCommand.ExecuteNonQuery();

							//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							if (Information.Err().Number != 0)
							{
								MessageBox.Show("Bill cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								return false;
							}


							break;
						}
						catch (Exception exc)
						{
							NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
						}
					}
					else
					{
						int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
						for (cnt = 0; cnt <= tempForEndVar; cnt++)
						{
							mysql = " select bill_cd from pay_billing_type where bill_no=" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingCodeColumn));
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
								//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mBillingCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
								if (mBillingCode == Convert.ToDouble(rsTempRec["bill_cd"]))
								{
									break;
								}
								else
								{
									if (cnt == aVoucherDetails.GetLength(0) - 1)
									{
										//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
										try
										{
											mysql = " delete from pay_employee_yearly_billing_details ";
											mysql = mysql + " where emp_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
											mysql = mysql + " and bill_cd=" + Convert.ToString(rsTempRec["bill_cd"]);
											SqlCommand TempCommand_2 = null;
											TempCommand_2 = SystemVariables.gConn.CreateCommand();
											TempCommand_2.CommandText = mysql;
											TempCommand_2.ExecuteNonQuery();

											//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
											if (Information.Err().Number != 0)
											{
												MessageBox.Show("Bill cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
												//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
												SystemVariables.gConn.RollbackTrans();
												return false;
											}
										}
										catch (Exception exc2)
										{
											NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
										}
									}
								}
							}
						}
					}
				}
				while(rsTempRec.Read());


				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar2; cnt++)
				{
					mysql = " select bill_cd from pay_billing_type where bill_no=" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingCodeColumn));
					mysql = mysql + " and show = 1 ";
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
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mBillingCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}


					mysql = " select bill_cd,amount from pay_employee_yearly_billing_details ";
					mysql = mysql + " where bill_cd=" + mBillingCode.ToString();
					mysql = mysql + " and emp_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						mysql = " insert into pay_employee_yearly_billing_details ";
						mysql = mysql + " (emp_cd, bill_cd, amount, last_change_date ";
						mysql = mysql + " , comments ";
						mysql = mysql + " ,  user_cd) ";
						mysql = mysql + " values(";
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						mysql = mysql + " ," + mBillingCode.ToString();
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdCurrentAmtColumn));
						mysql = mysql + " ,'" + StringsHelper.Format(DateTime.Today, SystemVariables.gSystemDateFormat) + "'";
						mysql = mysql + " ,N'" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdRemarksColumn)) + "'";
						mysql = mysql + " ," + Conversion.Str(SystemVariables.gLoggedInUserCode);
						mysql = mysql + ")";
						SqlCommand TempCommand_4 = null;
						TempCommand_4 = SystemVariables.gConn.CreateCommand();
						TempCommand_4.CommandText = mysql;
						TempCommand_4.ExecuteNonQuery();
					}
					else
					{
						mysql = " update pay_employee_yearly_billing_details set ";
						mysql = mysql + " amount = " + Convert.ToString(aVoucherDetails.GetValue(cnt, grdCurrentAmtColumn));
						if (((Array) mReturnValue).GetValue(1) != aVoucherDetails.GetValue(cnt, grdCurrentAmtColumn))
						{
							mysql = mysql + " , last_amount = amount ";
							mysql = mysql + " , last_change_date='" + StringsHelper.Format(DateTime.Today, SystemVariables.gSystemDateFormat) + "'";
						}
						mysql = mysql + " , comments = N'" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdRemarksColumn)) + "'";
						mysql = mysql + " , user_cd=" + Conversion.Str(SystemVariables.gLoggedInUserCode);
						mysql = mysql + " where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						mysql = mysql + " and bill_cd=" + mBillingCode.ToString();
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();
					}
				}



				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				grdVoucherDetails.Enabled = false;


				return true;
			}
			catch (System.Exception excep)
			{


				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
			}
			return false;
		}

		public bool CheckDataValidity()
		{
			int cnt = 0;
			int cnt1 = 0;
			int mBillingCode = 0;

			if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Select an employee!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			//*-- update all the current voucher grid information in grid's internal buffer
			grdVoucherDetails.UpdateData();

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				//check for ledger details (e.g. ledger code, debit amount or credit amount)
				if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdBillingCodeColumn), SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Invalid Billing Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					grdVoucherDetails.Col = grdBillingCodeColumn;
					grdVoucherDetails.Bookmark = cnt;
					grdVoucherDetails.Focus();
					return false;
				}
			}

			int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar2; cnt++)
			{
				//check for ledger details (e.g. ledger code, debit amount or credit amount)
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
						return false;
					}
				}
			}


			return true;
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

				SystemProcedure2.ClearTextBox(this);
				DefineVoucherArray(-1, true);
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Enabled = false;

				mSearchValue = ""; //Change the msearchvalue to blank
				mFirstGridFocus = true;
				//FirstFocusObject.SetFocus
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}


		}


		public void GetRecord(object pSearchValue)
		{
			SqlDataReader rsLocalRec = null;
			int cnt = 0;

			//On Error GoTo eFoundError

			string mysql = " select pay_emp.emp_no, pay_emp.emp_cd ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name as emp_name";
			}
			else
			{
				mysql = mysql + " , a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name as emp_name ";
			}
			mysql = mysql + " from pay_employee pay_emp ";
			mysql = mysql + " where pay_emp.emp_cd = " + Conversion.Str(pSearchValue);
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			bool rsLocalRecDidRead = rsLocalRec.Read();
			if (rsLocalRecDidRead)
			{
				mSearchValue = rsLocalRec["emp_cd"];
				//mTimeStamp = .Fields("time_stamp")
				DefineVoucherArray(0, true);
				cnt = 0;
				txtDisplayLabel[conDlblEmpCode].Text = Convert.ToString(rsLocalRec["emp_no"]);
				txtDisplayLabel[conDlblEmpName].Text = Convert.ToString(rsLocalRec["emp_name"]);
			}
			else
			{
				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				return;
			}

			rsLocalRec.Close();

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
			mysql = mysql + " , peybd.* ";
			mysql = mysql + " from pay_employee_yearly_billing_details peybd ";
			mysql = mysql + " inner join pay_billing_type pbt on peybd.bill_cd = pbt.bill_cd ";
			mysql = mysql + " where peybd.emp_cd = " + Conversion.Str(pSearchValue);
			mysql = mysql + " and pbt.show = 1 and pbt.linked_leave_cd is null ";

			SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand_2.ExecuteReader();
			bool rsLocalRecDidRead2 = rsLocalRec.Read();
			if (rsLocalRecDidRead)
			{
				do 
				{
					DefineVoucherArray(cnt, false);
					aVoucherDetails.SetValue(Conversion.Str(cnt + 1).Trim(), cnt, grdLineNoColumn);
					aVoucherDetails.SetValue(rsLocalRec["bill_no"], cnt, grdBillingCodeColumn);
					aVoucherDetails.SetValue(rsLocalRec["bill_name"], cnt, grdBillingNameColumn);
					aVoucherDetails.SetValue(rsLocalRec["bill_type"], cnt, grdBillingTypeColumn);
					//            aVoucherDetails(cnt, grdLastChangeDateColumn) = .Fields(" Last_Change_Date").Value
					aVoucherDetails.SetValue(rsLocalRec["Last_Amount"], cnt, grdLastAmtColumn);
					aVoucherDetails.SetValue(rsLocalRec["amount"], cnt, grdCurrentAmtColumn);
					aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["comments"]) + "", cnt, grdRemarksColumn);
					cnt++;
				}
				while(rsLocalRec.Read());
			}

			AssignGridLineNumbers();
			grdVoucherDetails.Rebind(true);
			CalculateTotals(0, 0);

			grdVoucherDetails.Enabled = true;
			FirstFocusObject.Focus();
			if (mFirstGridFocus)
			{
				grdVoucherDetails_GotFocus(grdVoucherDetails, new EventArgs());
			}
			Application.DoEvents();

			rsLocalRec.Close();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void PrintReport()
		{

		}

		public void CloseForm()
		{
			this.Close();
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

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void FindRoutine(string pObjectName)
		{
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			grdVoucherDetails.Columns[grdLineNoColumn].Text = (grdVoucherDetails.RowCount + 1).ToString();
			grdVoucherDetails.Columns[grdLastAmtColumn].Text = "0";
			grdVoucherDetails.Columns[grdCurrentAmtColumn].Text = "0";
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
	}
}