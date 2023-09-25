
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayEmpGlLinks
		: System.Windows.Forms.Form
	{


		
		public frmPayEmpGlLinks()
{
InitializeComponent();
} 
 public  void frmPayEmpGlLinks_old()
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

		private int mThisFormID = 0;

		private const int gccBillCd = 0;
		private const int gccBillNo = 1;
		private const int gccBillName = 2;
		private const int gccLdgrNo = 3;
		private const int gccLdgrName = 4;
		private const int gccCCNo = 5;
		private const int gccCCName = 6;
		private const int gccAnalysisCd1 = 7;
		private const int gccAnalysisCd2 = 8;
		private const int gccAnalysisCd3 = 9;
		private const int gccAnalysisCd4 = 10;
		private const int gccAnalysisCd5 = 11;
		//'''''Private Const gccServiceCode As Integer = 12
		//'''''Private Const gccAccntCode As Integer = 13
		//'''''Private Const gccDepartCode As Integer = 14
		//'''''Private Const gccPartyCode As Integer = 15
		private const int mMaxArrayCol = 11;

		private DataSet rsLedgerCodeList = null;
		private DataSet rsCCCodeList = null;
		private bool mFirstGridFocus = false;
		private clsToolbar oThisFormToolBar = null;

		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;


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


		private void cmdClose_Click()
		{
			this.Close();
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			switch(grdVoucherDetails.Col)
			{
				case gccLdgrNo : case gccLdgrName : 
					if (grdVoucherDetails.Col == gccLdgrNo)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("ldgr_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsLedgerCodeList.setSort("ldgr_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("ldgr_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsLedgerCodeList.setSort("ldgr_name");
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
								withVar.setOrder((grdVoucherDetails.Col == gccLdgrNo) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccLdgrNo].Width;
							}
							else
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == gccLdgrNo) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccLdgrName].Width;
							}

							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							withVar.Visible = true;
							cmbMastersList.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					break;
				case gccCCNo : case gccCCName : 
					if (grdVoucherDetails.Col == gccCCNo)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("cost_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCCCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsCCCodeList.setSort("cost_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("cost_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCCCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsCCCodeList.setSort("cost_name");
					} 
					 
					int tempForEndVar2 = cmbMastersList.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar2; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_2 = cmbMastersList.Splits[0].DisplayColumns[cnt];
						if (cnt < 2)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_2.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar_2.setOrder((grdVoucherDetails.Col == gccCCNo) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar_2.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccCCNo].Width;
							}
							else
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_2.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar_2.setOrder((grdVoucherDetails.Col == gccCCNo) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar_2.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccCCName].Width;
							}

							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							withVar_2.Visible = true;
							cmbMastersList.Width += withVar_2.Width / 15;
						}
						else
						{
							withVar_2.Visible = false;
						}
						withVar_2.AllowSizing = false;
					} 
					break;
			}

			cmbMastersList.Width += 17;
			cmbMastersList.Height = 167;

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.PostMsg(1001);
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			if (grdVoucherDetails.Col == gccLdgrNo || grdVoucherDetails.Col == gccLdgrName)
			{
				if (grdVoucherDetails.Col == gccLdgrNo)
				{
					grdVoucherDetails.Columns[gccLdgrName].Value = cmbMastersList.Columns[1].Value;
				}
				else
				{
					grdVoucherDetails.Columns[gccLdgrNo].Value = cmbMastersList.Columns[0].Value;
				}

				//grdVoucherDetails.Columns(gccApplyCostCenter).Value = cmbMastersList.Columns(2).Value
			}

			if (grdVoucherDetails.Col == gccCCNo || grdVoucherDetails.Col == gccCCName)
			{
				if (grdVoucherDetails.Col == gccCCNo)
				{
					grdVoucherDetails.Columns[gccCCName].Value = cmbMastersList.Columns[1].Value;
				}
				else
				{
					grdVoucherDetails.Columns[gccCCNo].Value = cmbMastersList.Columns[0].Value;
				}
			}
		}

		private void cmdEmpGL_Click(Object eventSender, EventArgs eventArgs)
		{
			ImportEmployeeDetails(2);
		}

		private void cmdUpdateEmpGLLink_Click(Object eventSender, EventArgs eventArgs)
		{
			ImportEmployeeDetails(1);
		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				SystemMenu.SetMeCurrentInWindowList(Conversion.Str(this.Handle.ToInt32()));
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{

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
						if (grdVoucherDetails.Col == gccCCNo)
						{
							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
							if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no"))) == TriState.False)
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
				}

				if (KeyCode == 13)
				{
					SendKeys.Send("{TAB}");
					return;
				}
				else if (KeyCode == 27)
				{ 
					this.Close();
					return;
				}

				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			//Set the Grid Format
			bool mShowAdditionalColumns = false;
			bool mShowAnalysisColumns = false;

			this.Top = 0;
			this.Left = 0;

			mFirstGridFocus = true;

			mShowAdditionalColumns = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("pay_gl_entry_method")) == 3;

			mShowAnalysisColumns = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_Pay_Analysis_In_GL"));


			//**--format & define the new toolbar
			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			oThisFormToolBar.ShowNewButton = false;
			oThisFormToolBar.ShowSaveButton = true;
			oThisFormToolBar.ShowDeleteButton = false;
			oThisFormToolBar.ShowPrintButton = true;
			oThisFormToolBar.ShowFindButton = true;
			oThisFormToolBar.ShowHelpButton = true;
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.DisableHelpButton = true;

			this.WindowState = FormWindowState.Maximized;

			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.4f, 1.4f, "&HB4D9F8", "&HB4D9F8", 280);
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Bill Cd", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Bill No.", 600, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Bill Name", 2000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Code", 1050, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, true, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Name", 2200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, true, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Code", 1050, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")), false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Name", 2000, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")), false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis-1 Code", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2202);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis-2 Code", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2203);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis-3 Code", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2204);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis-4 Code", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2205);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis-5 Code", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2206);
			//'''''Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Service Code", 1000, , , , dbgLeft, False, , , , , , , , mShowAdditionalColumns)
			//'''''Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Account Code", 1000, , , , dbgLeft, False, , , , , , , , mShowAdditionalColumns)
			//'''''Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Department Code", 1000, , , , dbgLeft, False, , , , , , , , mShowAdditionalColumns)
			//'''''Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Party Code", 1000, , , , dbgLeft, False, , , , , , , , mShowAdditionalColumns)

			SystemProcedure.SetLabelCaption(this);

			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);
			aVoucherDetails.RedimXArray(new int[]{-1, -1}, new int[]{-1, -1});
			grdVoucherDetails.Rebind(true);
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				rsLedgerCodeList = null;
				rsCCCodeList = null;

				oThisFormToolBar = null;
				frmPayEmpGlLinks.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";

			if (mFirstGridFocus)
			{
				//If cmbMastersList.Tag = "" Then
				SystemGrid.DefineSystemGridCombo(cmbMastersList);
				//End If

				DefineMasterRecordset();
				mFirstGridFocus = false;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.PostMsg(1);
			}
			else
			{
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{
			int Col = 0;

			if (MsgId == 1)
			{
				grdVoucherDetails.Col = gccLdgrNo;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsLedgerCodeList);
			}
			else if (MsgId == 1001)
			{ 
				grdVoucherDetails.UpdateData();
			}


		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool saveRecord()
		{
			string mysql = "";
			object mReturnValue = null;

			int cnt = 0;
			//Dim mApplyCostCenter As Boolean
			string mCCCd = "";
			string mLdgrCd = "";
			int mBillCd = 0;

			grdVoucherDetails.UpdateData();

			if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Select an Employee.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			SystemVariables.gConn.BeginTransaction();

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mBillCd = Convert.ToInt32(aVoucherDetails.GetValue(cnt, gccBillCd));
				if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, gccLdgrNo), SystemVariables.DataType.StringType))
				{
					mysql = " select ldgr_cd from gl_ledger ";
					mysql = mysql + " where ldgr_no ='" + Convert.ToString(aVoucherDetails.GetValue(cnt, gccLdgrNo)) + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show("Invalid Ledger Code ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						goto mError;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLdgrCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
						//           mApplyCostCenter = mReturnValue(1)

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
						{
							if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, gccCCNo), SystemVariables.DataType.NumberType))
							{
								mysql = "select cost_cd ";
								mysql = mysql + " from gl_cost_centers ";
								mysql = mysql + " where cost_no=" + Convert.ToString(aVoucherDetails.GetValue(cnt, gccCCNo));

								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (!Convert.IsDBNull(mReturnValue))
								{
									//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mCCCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
								}
								else
								{
									//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
									SystemVariables.gConn.RollbackTrans();
									MessageBox.Show("Invalid Cost Center Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									goto mError;
								}
							}
							else
							{
								mCCCd = "";
							}
						}
						else
						{
							mCCCd = "";
						}
					}
				}
				else
				{
					mLdgrCd = "";
					mCCCd = "";
				}
				//aVoucherDetails(cnt, gccAccntCode), aVoucherDetails(cnt, gccPartyCode), aVoucherDetails(cnt, gccServiceCode), aVoucherDetails(cnt, gccDepartCode)
				SystemHRProcedure.UpdateEmployeeGLLinks(mBillCd, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), mLdgrCd, mCCCd, Convert.ToString(aVoucherDetails.GetValue(cnt, gccAnalysisCd1)), Convert.ToString(aVoucherDetails.GetValue(cnt, gccAnalysisCd2)), Convert.ToString(aVoucherDetails.GetValue(cnt, gccAnalysisCd3)), Convert.ToString(aVoucherDetails.GetValue(cnt, gccAnalysisCd4)), Convert.ToString(aVoucherDetails.GetValue(cnt, gccAnalysisCd5)));
			}


			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

			MessageBox.Show("Changes Saved Successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

			return true;

			mError:
			grdVoucherDetails.Bookmark = cnt;
			grdVoucherDetails.Focus();
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();

			return false;
		}


		public bool CheckDataValidity()
		{
			//Check validation during update and add of records

			return true;
		}


		public void AddRecord()
		{
			try
			{

				int cnt = 0;

				mSearchValue = "";
				aVoucherDetails.RedimXArray(new int[]{-1, -1}, new int[]{-1, -1});
				grdVoucherDetails.Rebind(true);
				txtEmpCode.Text = "";
				txtEmpName.Text = "";
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]), "AddRecord");
			}

		}

		private void DefineMasterRecordset()
		{

			string mysql = "select ldgr_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name as ldgr_name" : "a_ldgr_name as ldgr_name");
			//mySql = mySql & " , apply_cost_center "
			mysql = mysql + " from gl_ledger ";
			//mySql = mySql & " where gl_ledger.ldgr_type not in ('B-CH', 'B-BA', 'B-SD', 'C-SC') "
			mysql = mysql + " where gl_ledger.type_cd in (";
			mysql = mysql + SystemGLConstants.gGLAssetsLiabilitiesTypeCode.ToString();
			mysql = mysql + ", " + SystemGLConstants.gGLEmployeeTypeCode.ToString();
			mysql = mysql + ", " + SystemGLConstants.gGLFixedAssetsTypeCode.ToString();
			mysql = mysql + ", " + SystemGLConstants.gGLIncomeExpenseTypeCode.ToString();
			mysql = mysql + ") ";
			mysql = mysql + " order by 1 ";

			rsLedgerCodeList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsLedgerCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsLedgerCodeList.Tables.Clear();
			adap.Fill(rsLedgerCodeList);

			mysql = " select cost_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cost_name as cost_name" : "a_cost_name as cost_name");
			mysql = mysql + " from gl_cost_centers ";
			mysql = mysql + " order by 1 ";

			rsCCCodeList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCCCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsCCCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsCCCodeList.Tables.Clear();
			adap_2.Fill(rsCCCodeList);

		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdVoucherDetails.Col > 0 && !mFirstGridFocus)
			{
				switch(grdVoucherDetails.Col)
				{
					case gccLdgrNo : case gccLdgrName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsLedgerCodeList); 
						break;
					case gccCCNo : case gccCCName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsCCCodeList); 
						break;
				}
			}


		}

		private void GetBillingDetails()
		{
			int cnt = 0;

			string mysql = " select  pbt.bill_cd , pbt.bill_no ";
			mysql = mysql + " , gl_ledger.ldgr_no";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , gl_ledger.l_ldgr_name ldgr_name , cc.l_cost_name cc_name";
				mysql = mysql + " , pbt.l_bill_name bill_name ";
			}
			else
			{
				mysql = mysql + " , gl_ledger.a_ldgr_name ldgr_name , cc.a_cost_name cc_name ";
				mysql = mysql + " , pbt.a_bill_name bill_name ";
			}
			mysql = mysql + " , case when cc.cost_no=0 then '' else cast(cc.cost_no as varchar) end cost_no ";
			mysql = mysql + " , pegl.analysis1_cd, pegl.analysis2_cd , pegl.analysis3_cd, pegl.analysis4_cd, pegl.analysis5_cd ";
			mysql = mysql + " from Pay_Billing_Type pbt ";
			mysql = mysql + " left join pay_employee_GL_Details pegl on pbt.bill_cd = pegl.bill_cd ";
			mysql = mysql + " left join gl_ledger on pegl.ldgr_cd = gl_ledger.ldgr_cd ";
			mysql = mysql + " left join gl_cost_centers cc on pegl.cost_cd = cc.cost_cd ";
			mysql = mysql + " where pegl.emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			mysql = mysql + " union ";
			mysql = mysql + " select  pbt.bill_cd , pbt.bill_no  , '' , '', '' ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , pbt.l_bill_name bill_name ";
			}
			else
			{
				mysql = mysql + " , pbt.a_bill_name bill_name ";
			}
			mysql = mysql + " , '', '', '' , '', '', ''";
			mysql = mysql + " from Pay_Billing_Type  pbt ";
			mysql = mysql + " where not exists ( select bill_cd from pay_employee_GL_Details pegl ";
			mysql = mysql + " where pegl.bill_cd = pbt.bill_cd and pegl.emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			mysql = mysql + " ) ";


			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{
				aVoucherDetails.RedimXArray(new int[]{cnt, mMaxArrayCol}, new int[]{0, 0});

				aVoucherDetails.SetValue(rsTempRec["bill_cd"], cnt, gccBillCd);
				aVoucherDetails.SetValue(rsTempRec["bill_no"], cnt, gccBillNo);
				aVoucherDetails.SetValue(rsTempRec["bill_name"], cnt, gccBillName);
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["ldgr_no"]) + "", cnt, gccLdgrNo);
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["ldgr_name"]) + "", cnt, gccLdgrName);
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["analysis1_cd"]) + "", cnt, gccAnalysisCd1);
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["analysis2_cd"]) + "", cnt, gccAnalysisCd2);
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["analysis3_cd"]) + "", cnt, gccAnalysisCd3);
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["analysis4_cd"]) + "", cnt, gccAnalysisCd4);
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["analysis5_cd"]) + "", cnt, gccAnalysisCd5);

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (grdVoucherDetails.Splits[0].DisplayColumns[gccCCNo].Visible)
				{
					aVoucherDetails.SetValue(Convert.ToString(rsTempRec["cost_no"]) + "", cnt, gccCCNo);
					aVoucherDetails.SetValue(Convert.ToString(rsTempRec["cc_name"]) + "", cnt, gccCCName);
					//aVoucherDetails(cnt, gccApplyCostCenter) = IIf(.Fields("apply_cost_center").Value = 1, True, False)
				}

				cnt++;
			}
			while(rsTempRec.Read());

			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Refresh();

			try
			{
				grdVoucherDetails.Focus();
			}
			catch
			{
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			//If (Col = gccCCNo Or Col = gccCCName) And aVoucherDetails.Count(1) > 1 Then
			//    If aVoucherDetails(Bookmark, gccApplyCostCenter) = True Then
			//        CellStyle.BackColor = grdVoucherDetails.Columns(gccLdgrNo).BackColor
			//        CellStyle.ForeColor = grdVoucherDetails.Columns(gccLdgrNo).ForeColor
			//        grdVoucherDetails.Columns(gccCCNo).AllowFocus = True
			//        grdVoucherDetails.Columns(gccCCName).AllowFocus = True
			//    Else
			//        CellStyle.BackColor = gDisableColumnBackColor
			//        CellStyle.ForeColor = gDisableColumnBackColor
			//        grdVoucherDetails.Columns(gccCCNo).AllowFocus = False
			//        grdVoucherDetails.Columns(gccCCName).AllowFocus = False
			//    End If
			//End If
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

		public void GetRecord(object SearchValue)
		{
			//On Error GoTo eFoundError


			string mysql = " select pe.emp_no ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , pe.l_first_name + ' ' + pe.l_second_name + ' ' + pe.l_fourth_name emp_name ";
			}
			else
			{
				mysql = mysql + " , pe.a_first_name + ' ' + pe.a_second_name + ' ' + pe.a_fourth_name emp_name ";
			}
			mysql = mysql + " from Pay_employee pe ";
			mysql = mysql + " where pe.emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtEmpCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtEmpName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));

				GetBillingDetails();
				grdVoucherDetails.Enabled = true;
				grdVoucherDetails.Focus();
			}

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void ImportEmployeeDetails(int pCallType)
		{
			StringBuilder mysql = new StringBuilder();
			//Dim mcnt As Long
			clsHourGlass myHourGlass = null;
			SqlDataReader rsTempRec = null;


			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mTempSearchValue))
			{
				return;
			}
			//mCnt = grdVoucherDetails.Bookmark

			DialogResult ans = MessageBox.Show("Are you sure, you want to update billing code for this Employee. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if (ans == System.Windows.Forms.DialogResult.Yes)
			{
				myHourGlass = new clsHourGlass();
				mysql = new StringBuilder(" delete from pay_employee_gl_details where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue));
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql.ToString();
				TempCommand.ExecuteNonQuery();
				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Take_EmpGLLink_From_Dept")))
				{
					mysql = new StringBuilder("insert into pay_employee_gl_details (emp_cd,Bill_Cd, Ldgr_Cd, Cost_Cd,User_cd, Analysis1_Cd, Analysis2_Cd , Analysis3_Cd, Analysis4_Cd, Analysis5_Cd");
					mysql.Append(" )");
					if (pCallType == 1)
					{
						mysql.Append(" select " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ", Bill_Cd, Ldgr_Cd, Cost_Cd ," + SystemVariables.gLoggedInUserCode.ToString() + " , Analysis1_Cd");
						mysql.Append(" ,isnull((select Analysis2 from pay_employee where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "), Analysis2_Cd)");
						mysql.Append(" ,isnull((select Analysis3 from pay_employee where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "), Analysis3_Cd)");
						mysql.Append(" ,isnull((select Analysis4 from pay_employee where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "), Analysis4_Cd)");
						mysql.Append(" ,isnull((select Analysis5 from pay_employee where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "),Analysis5_Cd)");
						mysql.Append(" from Pay_Employee_GL_Details ");
						mysql.Append(" where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0)));
					}
					else if (pCallType == 2)
					{ 
						mysql.Append(" select " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ", Bill_Cd, Ldgr_Cd, Cost_Cd ," + SystemVariables.gLoggedInUserCode.ToString() + " , Analysis1_Cd");
						mysql.Append(" , Analysis2_Cd , Analysis3_Cd , Analysis4_Cd , Analysis5_Cd");
						mysql.Append(" from Pay_Employee_GL_Details ");
						mysql.Append(" where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0)));
					}
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql.ToString();
					TempCommand_2.ExecuteNonQuery();
				}
				else
				{
					mysql = new StringBuilder(" select dept_cd, Bill_Cd, Ldgr_Cd, Cost_Cd ," + SystemVariables.gLoggedInUserCode.ToString() + " , Analysis1_Cd");
					mysql.Append(" , Analysis2_Cd , Analysis3_Cd , Analysis4_Cd , Analysis5_Cd");
					mysql.Append(" from Pay_Department_GL_Details ");
					mysql.Append(" where dept_cd in (select dept_cd from pay_employee where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0)) + " )");


					SqlCommand sqlCommand = new SqlCommand(mysql.ToString(), SystemVariables.gConn);
					rsTempRec = sqlCommand.ExecuteReader();
					rsTempRec.Read();
					do 
					{
						mysql = new StringBuilder("insert into pay_employee_gl_details (emp_cd,Bill_Cd, Ldgr_Cd, Cost_Cd,User_cd, Analysis1_Cd, Analysis2_Cd , Analysis3_Cd, Analysis4_Cd, Analysis5_Cd");
						mysql.Append(" )");
						mysql.Append(" VALUES (");
						mysql.Append(ReflectionHelper.GetPrimitiveValue<string>(mSearchValue));
						mysql.Append(" , " + Convert.ToString(rsTempRec["Bill_Cd"]) + " , " + Convert.ToString(rsTempRec["Ldgr_Cd"]) + " , '" + Convert.ToString(rsTempRec["Cost_Cd"]) + "'");
						mysql.Append(" , " + SystemVariables.gLoggedInUserCode.ToString());
						mysql.Append(" , '" + GetGLLinkCode(Convert.ToString(rsTempRec["Analysis1_Cd"]) + "") + "'");
						mysql.Append(" , '" + GetGLLinkCode(Convert.ToString(rsTempRec["Analysis2_Cd"]) + "") + "'");
						mysql.Append(" , '" + GetGLLinkCode(Convert.ToString(rsTempRec["Analysis3_Cd"]) + "") + "'");
						mysql.Append(" , '" + GetGLLinkCode(Convert.ToString(rsTempRec["Analysis4_Cd"]) + "") + "'");
						mysql.Append(" , '" + GetGLLinkCode(Convert.ToString(rsTempRec["Analysis5_Cd"]) + "") + "'");
						mysql.Append(" ) ");
						SqlCommand TempCommand_3 = null;
						TempCommand_3 = SystemVariables.gConn.CreateCommand();
						TempCommand_3.CommandText = mysql.ToString();
						TempCommand_3.ExecuteNonQuery();
					}
					while(rsTempRec.Read());
				}


				GetRecord(mSearchValue);
			}
			else
			{
			}

		}


		public string GetGLLinkCode(string pGLLinkCode)
		{

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select [Field_Id] from Pay_GLLink_Code where Unique_Code = '" + pGLLinkCode + "'"));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				return pGLLinkCode;
			}
			else
			{
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + " from pay_employee where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue)));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					return "";
				}
				else
				{
					return ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
			}
		}
	}
}