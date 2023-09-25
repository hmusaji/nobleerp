
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayGlobalSalaryVariation
		: System.Windows.Forms.Form
	{

		
		public frmPayGlobalSalaryVariation()
{
InitializeComponent();
} 
 public  void frmPayGlobalSalaryVariation_old()
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

		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private object mSearchValue = null;
		private string mTimeStamp = "";
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

		private bool mFirstGridFocus = false;
		private DataSet rsBillingCodeList = null;
		private bool mPosted = false;

		private const int conMaxColumns = 6;

		private const int mconTxtTransNo = 0;
		private const int mconTxtFromEmpCode = 1;
		private const int mconTxtToEmpCode = 2;
		private const int mconTxtFromDepart = 3;
		private const int mconTxtToDepart = 4;
		private const int mconTxtComments = 5;

		private const int mconDlblFromEmpName = 0;
		private const int mconDlblToEmpName = 1;
		private const int mconDlblFromDeptName = 2;
		private const int mconDlblToDeptName = 3;

		private const int grdBillingLN = 0;
		private const int grdBillingNo = 1;
		private const int grdBillingName = 2;
		private const int grdBillingPercentage = 3;
		private const int grdBillingAmount = 4;
		private const int grdBillingType = 5;
		private const int grdBillingCd = 6;


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
			object[] mObjectId = null;
			try
			{

				this.Top = 0;
				this.Left = 0;
				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;

				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = false;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);
				txtCommonTextBox[mconTxtTransNo].Text = SystemProcedure2.GetNewNumber("pay_global_salary_variation", "transaction_no");
				FirstFocusObject = txtCommonTextBox[mconTxtTransNo];

				SystemGrid.DefineSystemVoucherGrid(grdBillingDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");

				SystemGrid.DefineSystemVoucherGridColumn(grdBillingDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdBillingDetails, "Billing No.", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdBillingDetails, "Billing Name", 3250, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdBillingDetails, "Percentage", 2200, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdBillingDetails, "Amount", 2200, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdBillingDetails, "Bill Type ID", 0, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdBillingDetails, "Bill CD", 0, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdBillingDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdBillingDetails.setArray(aVoucherDetails);
				grdBillingDetails.Rebind(true);
				mFirstGridFocus = true;
				mPosted = false;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//If Shift = 0 And KeyCode = 116 And mFirstGridFocus = False Then
				//    Call DefineMasterRecordset
				//End If

				if (this.ActiveControl.Name == "grdBillingDetails")
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
						if (grdBillingDetails.Col == grdBillingAmount || grdBillingDetails.Col == grdBillingPercentage)
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

				if (KeyCode == 13)
				{
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdBillingDetails.Col)
			{
				case grdBillingNo : case grdBillingName : 
					if (grdBillingDetails.Col == grdBillingNo)
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
								if (grdBillingDetails.Col == grdBillingNo)
								{
									//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
									withVar.setOrder((grdBillingDetails.Col == grdBillingNo) ? 0 : 1);
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
									withVar.Width = grdBillingDetails.Splits[0].DisplayColumns[grdBillingNo].Width;
								}
								else
								{
									//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
									withVar.setOrder((grdBillingDetails.Col == grdBillingName) ? 0 : 1);
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
									withVar.Width = grdBillingDetails.Splits[0].DisplayColumns[grdBillingName].Width;
								}
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
					cmbMastersList.Height = 133; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			switch(grdBillingDetails.Col)
			{
				case grdBillingNo : case grdBillingName : 
					if (grdBillingDetails.Col == grdBillingNo)
					{
						grdBillingDetails.Col = grdBillingNo;
					}
					else
					{
						grdBillingDetails.Col = grdBillingName;
					} 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			if (grdBillingDetails.Col == grdBillingNo || grdBillingDetails.Col == grdBillingName)
			{
				grdBillingDetails.Columns[grdBillingNo].Value = cmbMastersList.Columns[0].Value;
				grdBillingDetails.Columns[grdBillingName].Value = cmbMastersList.Columns[1].Value;
				grdBillingDetails.Columns[grdBillingType].Value = cmbMastersList.Columns[3].Value;
				grdBillingDetails.Columns[grdBillingCd].Value = cmbMastersList.Columns[4].Value;
				grdBillingDetails.Columns[grdBillingPercentage].Value = 0;
				grdBillingDetails.Columns[grdBillingAmount].Value = 0;
			}
		}



		private void DefineMasterRecordset()
		{
			string mysql = "";
			//If IsItEmpty(mSearchValue, NumberType) = True Then
			//    Exit Sub
			//End If

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
				mysql = mysql + " , pbt.bill_type_id as bill_type_id, pbt.bill_cd "; //''''''
				mysql = mysql + " from pay_billing_type pbt ";
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdBillingDetails.AfterInsert was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdBillingDetails_AfterInsert()
		{
			AssignGridLineNumbers();
		}

		private void grdBillingDetails_AfterUpdate(Object eventSender, EventArgs eventArgs)
		{
			AssignGridLineNumbers();
		}

		private void grdBillingDetails_GotFocus(Object eventSender, EventArgs eventArgs)
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
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdBillingDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdBillingDetails.PostMsg(1);
			}
		}

		private void grdBillingDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdBillingDetails.Col > 0 && LastCol > 0 && !mFirstGridFocus)
			{
				switch(grdBillingDetails.Col)
				{
					case grdBillingNo : case grdBillingName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList); 
						break;
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdBillingDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdBillingDetails_PostEvent(int MsgId)
		{
			int Col = 0;

			if (MsgId == 1)
			{
				grdBillingDetails.Col = grdBillingNo;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList);
			}
		}


		public void IRoutine()
		{
			int mCurrentLineNo = 0;

			if (ActiveControl.Name != "grdBillingDetails" && grdBillingDetails.Enabled)
			{
				grdBillingDetails.Focus();
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdBillingDetails.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdBillingDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdBillingDetails.Columns[SystemICSConstants.grdLineNoColumn].Value);
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdBillingDetails.Bookmark), 1);
				AssignGridLineNumbers();
				grdBillingDetails.Rebind(true);
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdBillingDetails" && grdBillingDetails.Enabled)
			{
				grdBillingDetails.Focus();
			}

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdBillingDetails.Delete();
				AssignGridLineNumbers();
				grdBillingDetails.Rebind(true);
			}
		}


		public void AddRecord()
		{
			int cnt = 0;

			try
			{

				int tempForEndVar = grdBillingDetails.Columns.Count - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					grdBillingDetails.Columns[cnt].FooterText = "";
				}

				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode

				SystemProcedure2.ClearTextBox(this);
				DefineVoucherArray(-1, true);
				AssignGridLineNumbers();
				grdBillingDetails.Rebind(true);
				chkMissingEmpBilling.CheckState = CheckState.Unchecked;
				mSearchValue = ""; //Change the msearchvalue to blank
				mFirstGridFocus = true;
				mPosted = false;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}
		}
		public void FindRoutine(string pObjectName)
		{
			string mysql = "";
			object mTempSearchValue = null;

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

			switch(mIndex)
			{
				case mconTxtFromDepart : 
					txtCommonTextBox[mconTxtFromDepart].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7001000, "727")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[mconTxtFromDepart].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case mconTxtToDepart : 
					txtCommonTextBox[mconTxtToDepart].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7001000, "727")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[mconTxtToDepart].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case mconTxtFromEmpCode : 
					txtCommonTextBox[mconTxtFromEmpCode].Text = ""; 
					mysql = " pay_emp.status_cd not in (3,4)"; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", mysql)); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[mconTxtFromEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case mconTxtToEmpCode : 
					txtCommonTextBox[mconTxtToEmpCode].Text = ""; 
					mysql = " pay_emp.status_cd not in (3,4)"; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", mysql)); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[mconTxtToEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					 
					break;
				default:
					return;
			}

		}


		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			if (Index == mconTxtTransNo)
			{
				txtCommonTextBox[mconTxtTransNo].Text = SystemProcedure2.GetNewNumber("pay_global_salary_variation", "transaction_no");
			}
			else
			{
				FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
			}
		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			string mSQL = "";
			object mReturnValue = null;

			switch(Index)
			{
				case mconTxtFromEmpCode : 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(txtCommonTextBox[mconTxtFromEmpCode].Text) && txtCommonTextBox[mconTxtFromEmpCode].Text != "")
					{
						mSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_full_name" : " a_full_name");
						mSQL = mSQL + " from pay_employee";
						mSQL = mSQL + " where  emp_no ='" + txtCommonTextBox[mconTxtFromEmpCode].Text + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[mconDlblFromEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
						}
						else
						{
							txtDisplayLabel[mconDlblFromEmpName].Text = "";
							txtCommonTextBox[mconTxtFromEmpCode].Text = "";
						}
					}
					else
					{
						txtDisplayLabel[mconDlblFromEmpName].Text = "";
						txtCommonTextBox[mconTxtFromEmpCode].Text = "";
					} 
					break;
				case mconTxtToEmpCode : 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(txtCommonTextBox[mconTxtToEmpCode].Text) && txtCommonTextBox[mconTxtToEmpCode].Text != "")
					{
						mSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_full_name" : " a_full_name");
						mSQL = mSQL + " from pay_employee";
						mSQL = mSQL + " where  emp_no ='" + txtCommonTextBox[mconTxtToEmpCode].Text + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[mconDlblToEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
						}
						else
						{
							txtDisplayLabel[mconDlblToEmpName].Text = "";
							txtCommonTextBox[mconTxtToEmpCode].Text = "";
						}
					}
					else
					{
						txtDisplayLabel[mconDlblToEmpName].Text = "";
						txtCommonTextBox[mconTxtToEmpCode].Text = "";
					} 
					break;
				case mconTxtFromDepart : 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(txtCommonTextBox[mconTxtFromDepart].Text) && txtCommonTextBox[mconTxtFromDepart].Text != "")
					{
						mSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_dept_name" : " a_dept_name");
						mSQL = mSQL + " from pay_department";
						mSQL = mSQL + " where  dept_no =" + txtCommonTextBox[mconTxtFromDepart].Text;
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[mconDlblFromDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
						}
						else
						{
							txtDisplayLabel[mconDlblFromDeptName].Text = "";
							txtCommonTextBox[mconTxtFromDepart].Text = "";
						}
					}
					else
					{
						txtDisplayLabel[mconDlblFromDeptName].Text = "";
						txtCommonTextBox[mconTxtFromDepart].Text = "";
					} 
					break;
				case mconTxtToDepart : 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(txtCommonTextBox[mconTxtToDepart].Text) && txtCommonTextBox[mconTxtToDepart].Text != "")
					{
						mSQL = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_dept_name" : " a_dept_name");
						mSQL = mSQL + " from pay_department";
						mSQL = mSQL + " where  dept_no =" + txtCommonTextBox[mconTxtToDepart].Text;
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[mconDlblToDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
						}
						else
						{
							txtDisplayLabel[mconDlblToDeptName].Text = "";
							txtCommonTextBox[mconTxtToDepart].Text = "";
						}
					}
					else
					{
						txtDisplayLabel[mconDlblToDeptName].Text = "";
						txtCommonTextBox[mconTxtToDepart].Text = "";
					} 
					break;
				default:
					return; 

			}
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			rsBillingCodeList = null;
		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool saveRecord()
		{
			bool result = false;
			try
			{
				string mSQL = "";
				int mFromEmpCd = 0;
				int mToEmpCd = 0;
				int mFromDeptCd = 0;
				int mToDeptCd = 0;
				object mReturnValue = null;

				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[mconTxtFromEmpCode].Text, SystemVariables.DataType.StringType))
				{
					mSQL = "select emp_cd from pay_employee where emp_no ='" + txtCommonTextBox[mconTxtFromEmpCode].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mFromEmpCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						mFromEmpCd = 0;
					}
				}
				else
				{
					mFromEmpCd = 0;
				}
				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[mconTxtToEmpCode].Text, SystemVariables.DataType.StringType))
				{
					mSQL = "select emp_cd from pay_employee where emp_no ='" + txtCommonTextBox[mconTxtToEmpCode].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mToEmpCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						mToEmpCd = 0;
					}
				}
				else
				{
					mToEmpCd = 0;
				}

				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[mconTxtFromDepart].Text, SystemVariables.DataType.StringType))
				{
					mSQL = "select emp_cd from pay_employee where emp_no ='" + txtCommonTextBox[mconTxtFromDepart].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mFromDeptCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						mFromDeptCd = 0;
					}
				}
				else
				{
					mFromDeptCd = 0;
				}
				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[mconTxtToDepart].Text, SystemVariables.DataType.StringType))
				{
					mSQL = "select emp_cd from pay_employee where emp_no ='" + txtCommonTextBox[mconTxtToDepart].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mToDeptCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						mToDeptCd = 0;
					}
				}
				else
				{
					mToDeptCd = 0;
				}

				SystemVariables.gConn.BeginTransaction();

				string mCheckTimeStamp = "";
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mSQL = " insert into pay_global_salary_variation";
					mSQL = mSQL + " (transaction_no,from_emp_cd,to_emp_cd,from_dept_cd,to_dept_cd,employee_missing_billing,Variation_Date,status,comments,user_cd)";
					mSQL = mSQL + " values('" + txtCommonTextBox[mconTxtTransNo].Text + "'";
					mSQL = mSQL + " ," + ((mFromEmpCd == 0) ? "Null" : mFromEmpCd.ToString());
					mSQL = mSQL + " ," + ((mToEmpCd == 0) ? "Null" : mToEmpCd.ToString());
					mSQL = mSQL + " ," + ((mFromDeptCd == 0) ? "Null" : mFromDeptCd.ToString());
					mSQL = mSQL + " ," + ((mToDeptCd == 0) ? "Null" : mToDeptCd.ToString());
					mSQL = mSQL + " ," + ((int) chkMissingEmpBilling.CheckState).ToString();
					mSQL = mSQL + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtTransDate.Value) + "'";
					mSQL = mSQL + " ,1";
					if (SystemProcedure2.IsItEmpty(txtCommonTextBox[mconTxtComments].Text, SystemVariables.DataType.StringType))
					{
						mSQL = mSQL + " ,Null";
					}
					else
					{
						mSQL = mSQL + " ,N'" + txtCommonTextBox[mconTxtComments].Text + "'";
					}
					mSQL = mSQL + " ," + SystemVariables.gLoggedInUserCode.ToString();
					mSQL = mSQL + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mSQL;
					TempCommand.ExecuteNonQuery();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select scope_identity()"));
				}
				else
				{
					mSQL = " select time_stamp,protected from Pay_global_salary_variation where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
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
						return false;
					}
					mSQL = "update pay_global_salary_variation";
					mSQL = mSQL + " set transaction_no ='" + txtCommonTextBox[mconTxtTransNo].Text + "'";
					mSQL = mSQL + " ,from_emp_cd =" + ((mFromEmpCd == 0) ? "Null" : mFromEmpCd.ToString());
					mSQL = mSQL + " ,To_emp_cd =" + ((mToEmpCd == 0) ? "Null" : mToEmpCd.ToString());
					mSQL = mSQL + " ,from_dept_cd =" + ((mFromDeptCd == 0) ? "Null" : mFromDeptCd.ToString());
					mSQL = mSQL + " ,To_dept_cd =" + ((mToDeptCd == 0) ? "Null" : mToDeptCd.ToString());
					mSQL = mSQL + " ,employee_missing_billing=" + ((int) chkMissingEmpBilling.CheckState).ToString();
					mSQL = mSQL + " ,Variation_Date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtTransDate.Value) + "'";
					mSQL = mSQL + " ,user_cd=" + SystemVariables.gLoggedInUserCode.ToString();
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[mconTxtComments].Text, SystemVariables.DataType.StringType))
					{
						mSQL = mSQL + " ,comments = N'" + txtCommonTextBox[mconTxtComments].Text + "'";
					}
					mSQL = mSQL + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mSQL;
					TempCommand_2.ExecuteNonQuery();

					mSQL = "delete from pay_global_salary_vaiation_details";
					mSQL = mSQL + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mSQL;
					TempCommand_3.ExecuteNonQuery();

				}
				int mCnt = 0;
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (mCnt = 0; mCnt <= tempForEndVar; mCnt++)
				{
					mSQL = " insert into pay_global_salary_vaiation_details(entry_id,bill_cd,variation_percentage,variation_amount)";
					mSQL = mSQL + " values(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					mSQL = mSQL + " ," + Convert.ToString(aVoucherDetails.GetValue(mCnt, grdBillingCd));
					mSQL = mSQL + " ," + Convert.ToString(aVoucherDetails.GetValue(mCnt, grdBillingPercentage));
					mSQL = mSQL + " ," + Convert.ToString(aVoucherDetails.GetValue(mCnt, grdBillingAmount));
					mSQL = mSQL + ")";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mSQL;
					TempCommand_4.ExecuteNonQuery();
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				return true;
			}
			catch
			{

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}
			return result;
		}

		public void GetRecord(object pSearchValue)
		{
			int mCntRow = 0;
			DataSet rsLocal = null;

			string mSQL = " select transaction_no,from_emp_cd,to_emp_cd,from_dept_cd,to_dept_cd,Variation_Date,pgsv.user_cd,pgsv.time_stamp";
			mSQL = mSQL + " ,pemp1.emp_no as fromempno , pemp1.l_full_name as fromempname, pemp2.emp_no as toempno , pemp2.l_full_name as toempname";
			mSQL = mSQL + " ,pdept1.dept_no as fromdeptno, pdept1.l_dept_name as fromdeptname, pdept2.dept_no as todeptno, pdept2.l_dept_name as todeptname";
			mSQL = mSQL + " ,employee_missing_billing ,status, pgsv.comments";
			mSQL = mSQL + " from pay_global_salary_variation pgsv";
			mSQL = mSQL + " left outer join pay_employee pemp1 on pgsv.from_emp_cd = pemp1.emp_cd ";
			mSQL = mSQL + " left outer join pay_employee pemp2 on pgsv.to_emp_cd = pemp2.emp_cd ";
			mSQL = mSQL + " left outer join pay_department pdept1 on pgsv.from_dept_cd = pdept1.dept_cd";
			mSQL = mSQL + " left outer join pay_department pdept2 on pgsv.to_dept_cd = pdept2.dept_cd";
			mSQL = mSQL + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonTextBox[mconTxtTransNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(1)))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[mconTxtFromEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(8));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDisplayLabel[mconDlblFromEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(9));
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(2)))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[mconTxtToEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(10));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDisplayLabel[mconDlblToEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(11));
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(3)))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[mconTxtFromDepart].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(12));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDisplayLabel[mconDlblFromDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(13));
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(4)))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[mconTxtToDepart].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(14));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDisplayLabel[mconDlblToDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(15));
				}
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtTransDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(5));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(7));
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkMissingEmpBilling.CheckState = (CheckState) ((ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(16))) ? 1 : 0);
				mPosted = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(17)) != 1;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				txtCommonTextBox[mconTxtComments].Text = (Convert.IsDBNull(((Array) mReturnValue).GetValue(18))) ? "" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(18));

				mSQL = " select pgsvd.entry_id,pgsvd.bill_cd,pgsvd.variation_percentage,pgsvd.variation_amount";
				mSQL = mSQL + " ,pbt.l_bill_name,pbt.bill_no,pbt.bill_type_id ";
				mSQL = mSQL + " from pay_global_salary_vaiation_details pgsvd";
				mSQL = mSQL + " inner join pay_billing_type pbt on pbt.bill_cd = pgsvd.bill_cd";
				mSQL = mSQL + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				rsLocal = new DataSet();
				SqlDataAdapter adap = new SqlDataAdapter(mSQL, SystemVariables.gConn);
				rsLocal.Tables.Clear();
				adap.Fill(rsLocal);
				aVoucherDetails.RedimXArray(new int[]{rsLocal.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
				mCntRow = 0;
				foreach (DataRow iteration_row in rsLocal.Tables[0].Rows)
				{
					aVoucherDetails.SetValue(iteration_row["bill_no"], mCntRow, grdBillingNo);
					aVoucherDetails.SetValue(iteration_row["l_bill_name"], mCntRow, grdBillingName);
					aVoucherDetails.SetValue(iteration_row["variation_percentage"], mCntRow, grdBillingPercentage);
					aVoucherDetails.SetValue(iteration_row["variation_amount"], mCntRow, grdBillingAmount);
					aVoucherDetails.SetValue(iteration_row["bill_cd"], mCntRow, grdBillingCd);
					aVoucherDetails.SetValue(iteration_row["bill_type_id"], mCntRow, grdBillingType);
					mCntRow++;
				}
				AssignGridLineNumbers();
				grdBillingDetails.Rebind(true);
				grdBillingDetails.Refresh();
			}
			else
			{
				MessageBox.Show("Record is Not Found Try Again!!", "Find Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
		}


		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220400));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public bool Post()
		{
			bool result = false;
			DialogResult ans = (DialogResult) 0;
			string mysql = "";
			SqlDataReader rsLocal = null;
			frmSysOnlinePosting frmTemp = frmSysOnlinePosting.CreateInstance();

			if (mPosted)
			{
				MessageBox.Show("Transaction Already Posted", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return result;
			}
			frmTemp.ShowDialog();

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
			if (saveRecord())
			{
				mysql = "select emp_cd, emp_no from pay_employee pemp";
				mysql = mysql + " inner join pay_department pdept on pdept.dept_cd = pemp.dept_cd";
				mysql = mysql + " where status_cd not in(3,4)";

				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[mconTxtFromEmpCode].Text, SystemVariables.DataType.StringType) && !SystemProcedure2.IsItEmpty(txtCommonTextBox[mconTxtToEmpCode].Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " and emp_no >= '" + txtCommonTextBox[mconTxtFromEmpCode].Text + "'";
					mysql = mysql + " and emp_no <= '" + txtCommonTextBox[mconTxtToEmpCode].Text + "'";
				}
				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[mconTxtFromDepart].Text, SystemVariables.DataType.NumberType) && !SystemProcedure2.IsItEmpty(txtCommonTextBox[mconTxtToDepart].Text, SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " and dept_no >= " + txtCommonTextBox[mconTxtFromDepart].Text;
					mysql = mysql + " and dept_no <= " + txtCommonTextBox[mconTxtToDepart].Text;
				}
				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocal = sqlCommand.ExecuteReader();
				rsLocal.Read();
				do 
				{
					GenerateSalaryVariationTransaction(Convert.ToInt32(rsLocal["emp_cd"]));
					SystemHRProcedure.ReGenerateEmployeePayroll(Convert.ToString(rsLocal["emp_no"]));
				}
				while(rsLocal.Read());
				rsLocal.Close();
				mysql = " update pay_global_salary_variation";
				mysql = mysql + " set status = 2";
				mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
				result = true;
			}
			else
			{
				result = false;
			}
			mDestroy:
			frmTemp.Close();
			return result;
		}


		public void GenerateSalaryVariationTransaction(int pEmp_cd)
		{

			string mSalaryVariationTransNo = SystemProcedure2.GetNewNumber("pay_salary_variation", "voucher_no");

			string mysql = " select emp_cd,dept_cd,desg_cd,basic_salary,total_salary";
			mysql = mysql + " from pay_employee";
			mysql = mysql + " where emp_cd =" + pEmp_cd.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//'' Craete Employee Salary Variation Header
			mysql = " insert into pay_salary_variation ";
			mysql = mysql + " (emp_cd, dept_cd, desg_cd, voucher_no, voucher_date, reference_no";
			mysql = mysql + " , basic_salary, total_salary, comments, new_dept_cd, new_desg_cd, type_id, user_cd)";
			mysql = mysql + " values ( ";
			mysql = mysql + pEmp_cd.ToString();
			mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
			mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
			mysql = mysql + " , " + mSalaryVariationTransNo;
			mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtTransDate.Value) + "'";
			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[mconTxtComments].Text, SystemVariables.DataType.StringType))
			{
				mysql = mysql + " , NULL ";
			}
			else
			{
				mysql = mysql + " ,N'" + txtCommonTextBox[mconTxtComments].Text + "'";
			}
			mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3));
			mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(4));
			mysql = mysql + " , Null ";
			mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
			mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
			mysql = mysql + " , 5 ";
			mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
			mysql = mysql + " ) ";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mSalaryVariationEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(" select scope_identity()"));
			//''
			//''''Create Employee Salary Variation Details

			mysql = " select pebd.bill_cd, pebd.amount , pebd.include_in_leave , pebd.include_in_indemnity";
			mysql = mysql + " , (pgsvd.variation_percentage*pebd.amount)/100 as percentage_amount , pgsvd.variation_amount";
			mysql = mysql + " from pay_employee_billing_details pebd";
			mysql = mysql + " inner join pay_global_salary_vaiation_details pgsvd on pgsvd.bill_cd = pebd.bill_cd";
			mysql = mysql + " Where pebd.emp_cd = " + pEmp_cd.ToString();
			mysql = mysql + " and pgsvd.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			SqlDataReader rsSalaryVariationD = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsSalaryVariationD = sqlCommand.ExecuteReader();
			rsSalaryVariationD.Read();
			do 
			{
				mysql = " insert into pay_salary_variation_details";
				mysql = mysql + " (entry_id, bill_cd, variation_amount, last_amount ";
				mysql = mysql + " , include_in_leave ";
				mysql = mysql + " , include_in_indemnity, comments) ";
				mysql = mysql + " values(";
				mysql = mysql + mSalaryVariationEntryId.ToString();
				mysql = mysql + " ," + Convert.ToString(rsSalaryVariationD["bill_cd"]);
				mysql = mysql + " ," + Convert.ToString((Convert.ToDouble(rsSalaryVariationD["percentage_amount"]) > 0) ? rsSalaryVariationD["percentage_amount"] : rsSalaryVariationD["variation_amount"]);
				mysql = mysql + " ," + Convert.ToString(rsSalaryVariationD["amount"]);
				mysql = mysql + " ," + ((Convert.ToBoolean(rsSalaryVariationD["include_in_leave"])) ? 1 : 0).ToString();
				mysql = mysql + " ," + ((Convert.ToBoolean(rsSalaryVariationD["include_in_indemnity"])) ? 1 : 0).ToString();
				mysql = mysql + " ,Null";
				mysql = mysql + ")";
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();
			}
			while(rsSalaryVariationD.Read());
			rsSalaryVariationD.Close();

			if (chkMissingEmpBilling.CheckState == CheckState.Checked)
			{
				mysql = "select bill_cd,variation_percentage,variation_amount";
				mysql = mysql + " From pay_global_salary_vaiation_details";
				mysql = mysql + " Where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mysql = mysql + " and bill_cd not in (select bill_cd from pay_employee_billing_details where emp_cd =" + pEmp_cd.ToString() + ")";
				SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
				rsSalaryVariationD = sqlCommand_2.ExecuteReader();
				bool rsSalaryVariationDDidRead2 = rsSalaryVariationD.Read();
				do 
				{
					mysql = " insert into pay_salary_variation_details";
					mysql = mysql + " (entry_id, bill_cd, variation_amount, last_amount ";
					mysql = mysql + " , include_in_leave ";
					mysql = mysql + " , include_in_indemnity, comments) ";
					mysql = mysql + " values(";
					mysql = mysql + mSalaryVariationEntryId.ToString();
					mysql = mysql + " ," + Convert.ToString(rsSalaryVariationD["bill_cd"]);
					if (Convert.ToDouble(rsSalaryVariationD["variation_amount"]) != 0)
					{
						mysql = mysql + " ," + Convert.ToString(rsSalaryVariationD["variation_amount"]);
						mysql = mysql + " ," + "0";
						mysql = mysql + " , 0";
						mysql = mysql + " , 0";
						mysql = mysql + " ,Null";
						mysql = mysql + ")";
						SqlCommand TempCommand_3 = null;
						TempCommand_3 = SystemVariables.gConn.CreateCommand();
						TempCommand_3.CommandText = mysql;
						TempCommand_3.ExecuteNonQuery();
					}

				}
				while(rsSalaryVariationD.Read());
				rsSalaryVariationD.Close();

			}

			SystemHRProcedure.PayPostToHR("Pay_Salary_Variation", mSalaryVariationEntryId);
			SystemHRProcedure.PayApprove("Pay_Salary_Variation", mSalaryVariationEntryId, "Pay_Salary_Variation_details");

			//''' Post Employee Salary Variation
			mysql = " update pay_salary_variation";
			mysql = mysql + " set status = 2";
			mysql = mysql + " where entry_id = " + mSalaryVariationEntryId.ToString();
			SqlCommand TempCommand_4 = null;
			TempCommand_4 = SystemVariables.gConn.CreateCommand();
			TempCommand_4.CommandText = mysql;
			TempCommand_4.ExecuteNonQuery();

			mysql = " update pay_salary_variation_details";
			mysql = mysql + " set status = 2";
			mysql = mysql + " where entry_id = " + mSalaryVariationEntryId.ToString();
			SqlCommand TempCommand_5 = null;
			TempCommand_5 = SystemVariables.gConn.CreateCommand();
			TempCommand_5.CommandText = mysql;
			TempCommand_5.ExecuteNonQuery();

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdBillingDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdBillingDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == grdBillingAmount)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###,###,##0.000");
				}
			}
		}
	}
}