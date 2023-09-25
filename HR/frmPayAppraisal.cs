
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayAppraisal
		: System.Windows.Forms.Form
	{

		public frmPayAppraisal()
{
InitializeComponent();
} 
 public  void frmPayAppraisal_old()
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


		private void frmPayAppraisal_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		int mThisFormID = 0;
		object mSearchValue = null;
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

		private clsToolbar oThisFormToolBar = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
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


		private const int grdUserCode = 1;
		private const int grdUserName = 2;
		private const int grdUserLeavel = 3;
		private const int grdUsercd = 4;
		private const int conMaxColumns = 4;
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
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);
				txtAppraisal.Text = SystemProcedure2.GetNewNumber("pay_appraisal", "appraisal_no", 2);

				SystemGrid.DefineSystemVoucherGrid(grdSurveyDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");

				SystemGrid.DefineSystemVoucherGridColumn(grdSurveyDetails, "LN", 500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdSurveyDetails, "User code", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdSurveyDetails, "User Name", 3000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdSurveyDetails, "Level", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdSurveyDetails, "UserCd", 750, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdSurveyDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdSurveyDetails.setArray(aVoucherDetails);
				grdSurveyDetails.Rebind(true);

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
				if (Shift == 0 && KeyCode == 116 && !mFirstGridFocus)
				{
					DefineMasterRecordset();
				}

				if (this.ActiveControl.Name == "grdSurveyDetails")
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
				}

				if (KeyCode == 13)
				{
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

		public void AddRecord()
		{
			SystemProcedure2.ClearTextBox(this);

			DefineVoucherArray(-1, true);
			AssignGridLineNumbers();
			grdSurveyDetails.Rebind(true);

			txtAppraisal.Text = SystemProcedure2.GetNewNumber("pay_appraisal", "appraisal_no", 2);
			mFirstGridFocus = true;
			txtTransactionDate.Value = DateTime.Today;
			txtStartDate.Value = DateTime.Today;
			txtEndDate.Value = DateTime.Today;
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			mSearchValue = "";

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "mAssign_value");
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220610));
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

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				oThisFormToolBar = null;
				UserAccess = null;
				frmICSUnit.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtRateeCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtRateeCode");
		}

		private void txtRateeCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtRateeCode.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pemp.l_full_Name" : "pemp.a_full_Name");
					mysql = mysql + " , pdept.dept_no , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pdept.l_dept_Name" : "pdept.a_dept_Name");
					mysql = mysql + " , pdesg.desg_no , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pdesg.l_desg_Name" : "pdesg.a_desg_Name");
					mysql = mysql + " from pay_employee pemp";
					mysql = mysql + " inner join pay_department pdept on pdept.dept_cd = pemp.dept_cd";
					mysql = mysql + " inner join pay_designation pdesg on pdesg.desg_cd = pemp.desg_Cd ";
					mysql = mysql + " where emp_no='" + txtRateeCode.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtRateeCode.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDlblRateeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDlblDepartment.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDlblDepartmentName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDlblDesignation.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDlblDesignationName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));
					}
				}
				else
				{
					txtDlblRateeName.Text = "";
					txtDlblDepartment.Text = "";
					txtDlblDepartmentName.Text = "";
					txtDlblDesignation.Text = "";
					txtDlblDesignationName.Text = "";
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void txtRequestedBy_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtRequestedBy");
		}

		private void txtRequestedBy_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtRequestedBy.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_full_Name" : "a_full_Name");
					mysql = mysql + " from pay_employee where emp_no='" + txtRequestedBy.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtRequestedBy.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDlblRequestedByName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtDlblRequestedByName.Text = "";
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void txtSuveyTemplate_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtSuveyTemplate");
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtRateeCode" : 
					txtRateeCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", " pay_emp.status_cd not in (3,4)")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtRateeCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtRateeCode_Leave(txtRateeCode, new EventArgs());
					} 
					break;
				case "txtRequestedBy" : 
					txtRequestedBy.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", " pay_emp.status_cd not in (3,4)")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtRequestedBy.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtRequestedBy_Leave(txtRequestedBy, new EventArgs());
					} 
					break;
				case "txtSuveyTemplate" : 
					txtSuveyTemplate.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220605, "2665")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtSuveyTemplate.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtSuveyTemplate_Leave(txtSuveyTemplate, new EventArgs());
					} 
					break;
				default:
					return;
			}

		}

		private void txtSuveyTemplate_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtSuveyTemplate.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_survey_name" : "a_survey_name");
					mysql = mysql + " from Pay_Appraisal_Survey where survey_no='" + txtSuveyTemplate.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtSuveyTemplate.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDlBLSurveyTemplateName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtDlBLSurveyTemplateName.Text = "";
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			if (grdSurveyDetails.Col == grdUserCode || grdSurveyDetails.Col == grdUserName)
			{
				if (grdSurveyDetails.Col == grdUserCode)
				{
					grdSurveyDetails.Columns[grdUserName].Value = cmbMastersList.Columns[1].Value;
				}
				else
				{
					grdSurveyDetails.Columns[grdUserCode].Value = cmbMastersList.Columns[0].Value;
				}
				grdSurveyDetails.Columns[grdUsercd].Value = cmbMastersList.Columns[2].Value;
			}

		}

		private void grdSurveyDetails_GotFocus(Object eventSender, EventArgs eventArgs)
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
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdSurveyDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdSurveyDetails.PostMsg(1);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdSurveyDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdSurveyDetails_PostEvent(int MsgId)
		{
			int Col = 0;
			if (MsgId == 1)
			{
				grdSurveyDetails.Col = grdUserCode;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList);
			}
		}

		public void IRoutine()
		{
			int mCurrentLineNo = 0;

			if (ActiveControl.Name != "grdSurveyDetails" && grdSurveyDetails.Enabled)
			{
				grdSurveyDetails.Focus();
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdSurveyDetails.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdSurveyDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdSurveyDetails.Columns[SystemICSConstants.grdLineNoColumn].Value);
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdSurveyDetails.Bookmark), 1);
				AssignGridLineNumbers();
				grdSurveyDetails.Rebind(true);
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdSurveyDetails" && grdSurveyDetails.Enabled)
			{
				grdSurveyDetails.Focus();
			}

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdSurveyDetails.Delete();
				AssignGridLineNumbers();
				//Call CalculateTotals(0, 1)
				grdSurveyDetails.Rebind(true);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdSurveyDetails.Col)
			{
				case grdUserCode : case grdUserName : 
					if (grdSurveyDetails.Col == grdUserCode)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("user_id");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("user_id");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("user_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("user_name");
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
								withVar.setOrder((grdSurveyDetails.Col == grdUserCode) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdSurveyDetails.Splits[0].DisplayColumns[grdUserCode].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdSurveyDetails.Col == grdUserCode) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdSurveyDetails.Splits[0].DisplayColumns[grdUserName].Width;
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
			switch(grdSurveyDetails.Col)
			{
				case grdUserCode : 
					grdSurveyDetails.Col = grdUserName; 
					break;
			}
		}

		private void DefineMasterRecordset()
		{
			string mysql = "";

			if (mFirstGridFocus)
			{
				mysql = " select user_id ";
				mysql = mysql + " , User_Name";
				mysql = mysql + " , user_cd "; //''''''
				mysql = mysql + " from SM_USERS";
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

		private void grdSurveyDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdSurveyDetails.Col > 0 && LastCol > 0 && !mFirstGridFocus)
			{
				switch(grdSurveyDetails.Col)
				{
					case grdUserCode : case grdUserName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList); 
						break;
				}
			}
		}

		public void GetRecord(object SearchValue)
		{
			string mysql = "";
			object mReturnValue = null;
			int cnt = 0;
			SqlDataReader rsLocal = null;

			try
			{
				if (SystemProcedure2.IsItEmpty(SearchValue, SystemVariables.DataType.NumberType))
				{
					return;
				}

				mysql = " select pas.Survey_No," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pas.l_Survey_Name as surveyName" : " pas.a_Survey_Name as surveyName");
				mysql = mysql + " , pemp1.emp_no as RateeNo," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pemp1.l_full_name as RateeName" : " pemp1.a_full_Name as RateeName");
				mysql = mysql + " , pemp2.emp_no as RequestedByNo," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pemp2.l_full_name as RequestedByName" : " pemp2.a_full_Name as RequestedByName");
				mysql = mysql + " , pdept.dept_no , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pdept.l_dept_name as deptName" : " pdept.a_dept_Name as deptName");
				mysql = mysql + " , pdesg.desg_no , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pdesg.l_desg_name as desgName" : " pdesg.a_desg_Name as desgName");
				mysql = mysql + " , pa.start_date , pa.end_date , pa.appraisal_no , pa.trans_date , pa.appraisal_cd";
				mysql = mysql + "  from pay_appraisal pa";
				mysql = mysql + "  inner join Pay_Appraisal_Survey pas on pas.survey_cd = pa.survey_cd";
				mysql = mysql + "  inner join pay_employee pemp1 on pemp1.emp_cd = pa.ratee_cd";
				mysql = mysql + "  inner join pay_department pdept on pdept.dept_cd = pemp1.dept_cd";
				mysql = mysql + "  inner join pay_designation pdesg on pdesg.desg_cd = pemp1.desg_cd";
				mysql = mysql + "  inner join pay_employee pemp2 on pemp2.emp_cd = pa.appraisal_requested_cd";
				mysql = mysql + "  where appraisal_cd = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtSuveyTemplate.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDlBLSurveyTemplateName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtRateeCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDlblRateeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtRequestedBy.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(4));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDlblRequestedByName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(5));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDlblDepartment.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(6));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDlblDepartmentName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(7));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDlblDesignation.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(8));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDlblDesignationName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(9));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtStartDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(10));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtEndDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(11));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtAppraisal.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(12));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtTransactionDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(13));

					mysql = " select su.user_id  , su.user_name , su.user_cd  ,paud.appraisal_level";
					mysql = mysql + "  from pay_appraisal_user_details paud";
					mysql = mysql + "  inner join pay_appraisal pa on pa.appraisal_cd = paud.appraisal_cd";
					mysql = mysql + "  inner join SM_USERS su on su.user_cd = paud.appraisal_user_cd";
					mysql = mysql + "  Where paud.appraisal_cd = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

					SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
					rsLocal = sqlCommand.ExecuteReader();
					rsLocal.Read();
					do 
					{
						DefineVoucherArray(cnt, false);
						aVoucherDetails.SetValue(rsLocal["user_id"], cnt, grdUserCode);
						aVoucherDetails.SetValue(rsLocal["user_name"], cnt, grdUserName);
						aVoucherDetails.SetValue(rsLocal["user_cd"], cnt, grdUsercd);
						aVoucherDetails.SetValue(rsLocal["appraisal_level"], cnt, grdUserLeavel);
						cnt++;
					}
					while(rsLocal.Read());
					AssignGridLineNumbers();
					grdSurveyDetails.Rebind(true);
					rsLocal.Close();
				}
				else
				{
					txtSuveyTemplate.Text = "";
					txtDlBLSurveyTemplateName.Text = "";
					txtRateeCode.Text = "";
					txtDlblRateeName.Text = "";
					txtRequestedBy.Text = "";
					txtDlblRequestedByName.Text = "";
					txtDlblDepartment.Text = "";
					txtDlblDepartmentName.Text = "";
					txtDlblDesignation.Text = "";
					txtDlblDesignationName.Text = "";
					txtStartDate.Value = DateTime.Today;
					txtEndDate.Value = DateTime.Today;
					txtTransactionDate.Value = DateTime.Today;
				}

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
		}

		public bool saveRecord()
		{
			bool result = false;
			string mysql = "";
			object mReturnValue = null;
			int mCnt = 0;
			int mSurveyCd = 0;
			int mRateeCd = 0;
			int mRequestedBy = 0;
			try
			{

				if (!SystemProcedure2.IsItEmpty(txtSuveyTemplate.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select survey_cd from pay_appraisal_survey where survey_no = '" + txtSuveyTemplate.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mSurveyCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Please Check Survey Code !!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}
				else
				{
					MessageBox.Show("Please Check Survey Code !!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				if (!SystemProcedure2.IsItEmpty(txtRateeCode.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select emp_cd from pay_employee where emp_no = '" + txtRateeCode.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mRateeCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Please Check Ratee Code !!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}
				else
				{
					MessageBox.Show("Please Check Ratee Code !!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				if (!SystemProcedure2.IsItEmpty(txtRequestedBy.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select emp_cd from pay_employee where emp_no = '" + txtRequestedBy.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mRequestedBy = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Please Check Requested Code !!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}
				else
				{
					MessageBox.Show("Please Check Requested Code !!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
				SystemVariables.gConn.BeginTransaction();
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into Pay_Appraisal(appraisal_no,survey_cd,ratee_cd,appraisal_requested_cd,trans_date";
					mysql = mysql + " , start_date,end_date, user_cd )";
					mysql = mysql + " values('" + txtAppraisal.Text + "'";
					mysql = mysql + "," + mSurveyCd.ToString();
					mysql = mysql + "," + mRateeCd.ToString();
					mysql = mysql + "," + mRequestedBy.ToString();
					mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtTransactionDate.Value) + "'";
					mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDate.Value) + "'";
					mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtEndDate.Value) + "'";
					mysql = mysql + "," + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mysql = " select scope_identity()";
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
						result = false;
						mSearchValue = "";
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return result;
					}
				}
				else
				{
					mysql = " update Pay_Appraisal";
					mysql = mysql + " set appraisal_no='" + txtAppraisal.Text + "'";
					mysql = mysql + " , survey_cd=" + mSurveyCd.ToString();
					mysql = mysql + " , ratee_cd=N" + mRateeCd.ToString();
					mysql = mysql + " , appraisal_requested_cd=" + mRequestedBy.ToString();
					mysql = mysql + " , trans_date='" + ReflectionHelper.GetPrimitiveValue<string>(txtTransactionDate.Value) + "'";
					mysql = mysql + " , start_date='" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDate.Value) + "'";
					mysql = mysql + " , end_date='" + ReflectionHelper.GetPrimitiveValue<string>(txtEndDate.Value) + "'";
					mysql = mysql + " , user_cd = " + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " where appraisal_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}

				mysql = "delete from pay_appraisal_user_details ";
				mysql = mysql + " where appraisal_cd= " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();
				grdSurveyDetails.UpdateData();

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (mCnt = 0; mCnt <= tempForEndVar; mCnt++)
				{
					mysql = " insert into pay_appraisal_user_details(appraisal_cd,appraisal_user_cd,appraisal_level)";
					mysql = mysql + " values ( " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					mysql = mysql + "," + Convert.ToString(aVoucherDetails.GetValue(mCnt, grdUsercd));
					mysql = mysql + "," + Convert.ToString(aVoucherDetails.GetValue(mCnt, grdUserLeavel));
					mysql = mysql + ")";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
			}
			return result;
		}

		public object deleteRecord()
		{
			object result = null;
			string mysql = "";
			object mReturnValue = null;

			try
			{

				mysql = " select protected from Pay_Appraisal where appraisal_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
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
						mysql = "delete from pay_appraisal_user_details where appraisal_cd=" + Conversion.Str(mSearchValue);
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql;
						TempCommand.ExecuteNonQuery();

						mysql = "delete from Pay_Appraisal where appraisal_cd=" + Conversion.Str(mSearchValue);
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();

						//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (Information.Err().Number != 0)
						{
							MessageBox.Show("Appraisal cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					AddRecord();
					((Array) result).GetValue(0);
				}
				else
				{
					result = false;
				}
			}

			return result;
		}
	}
}