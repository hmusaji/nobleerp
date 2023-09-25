
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayDeptGlLinks
		: System.Windows.Forms.Form
	{


		
		public frmPayDeptGlLinks()
{
InitializeComponent();
} 
 public  void frmPayDeptGlLinks_old()
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

		private clsToolbar oThisFormToolBar = null;

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
		private const int gccAnalysisCode1 = 7;
		private const int gccAnalysisCode2 = 8;
		private const int gccAnalysisCode3 = 9;
		private const int gccAnalysisCode4 = 10;
		private const int gccAnalysisCode5 = 11;
		private const int gccSelect = 12;
		//''''Private Const gccServiceCode As Integer = 13
		//''''Private Const gccAccntCode As Integer = 14
		//''''Private Const gccDepartCode As Integer = 15
		//''''Private Const gccPartyCode As Integer = 16
		private const int mMaxArrayCol = 16;

		private DataSet rsLedgerCodeList = null;
		private DataSet rsCCCodeList = null;
		private bool mFirstGridFocus = false;

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


		//Private Sub btnFormToolBar_Click(Index As Integer)
		//Call ToolBarButtonClick(Me, btnFormToolBar(Index).Tag)
		//End Sub

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

		private void cmdUpdateEmpGLLink_Click(Object eventSender, EventArgs eventArgs)
		{
			UpdateDeptEmployeeDetails();
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
			bool mShowAnalysisColumn = false;
			this.Top = 0;
			this.Left = 0;

			mFirstGridFocus = true;


			mShowAdditionalColumns = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("pay_gl_entry_method")) == 3;

			mShowAnalysisColumn = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Enable_Pay_Analysis_In_GL"));

			//**--format & define the new toolbar
			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			oThisFormToolBar.ShowSaveButton = true;
			oThisFormToolBar.ShowFindButton = true;
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.ShowCheckAllButton = true;
			oThisFormToolBar.ShowUncheckAllButton = true;


			this.WindowState = FormWindowState.Maximized;

			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.4f, 1.4f, "&HB4D9F8", "&HB4D9F8", 280);
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Dept Cd", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Dept No.", 600, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Department Name", 2000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Code", 1050, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, true, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Name", 2200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, true, false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Code", 1050, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")), false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Name", 2000, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")), false, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis Code1", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2202);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis Code2", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2203);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis Code3", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2204);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis Code4", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2205);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis Code5", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2206);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Include", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
			//''''Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Service Code", 1000, , , , dbgLeft, False, , , , , , , , mShowAdditionalColumns)
			//''''Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Account Code", 1000, , , , dbgLeft, False, , , , , , , , mShowAdditionalColumns)
			//''''Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Department Code", 1000, , , , dbgLeft, False, , , , , , , , mShowAdditionalColumns)
			//''''Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Party Code", 1000, , , , dbgLeft, False, , , , , , , , mShowAdditionalColumns)

			SystemProcedure.SetLabelCaption(this);

			//.HoldFields
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

				frmPayDeptGlLinks.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdVoucherDetails_BeforeColEdit(object eventSender, C1.Win.C1TrueDBGrid.BeforeColEditEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int KeyAscii = (int) eventArgs.KeyChar;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if ((ColIndex == gccSelect) && !Convert.IsDBNull(grdVoucherDetails.Bookmark))
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

		private void grdVoucherDetails_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				int Col = grdVoucherDetails.Col;

				if (Col == gccSelect)
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
				MessageBox.Show("Select a Department", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
				//, aVoucherDetails(cnt, gccAccntCode), aVoucherDetails(cnt, gccPartyCode) , aVoucherDetails(cnt, gccServiceCode), aVoucherDetails(cnt, gccDepartCode)
				SystemHRProcedure.UpdateDepartmentGLLinks(mBillCd, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), mLdgrCd, mCCCd, Convert.ToString(aVoucherDetails.GetValue(cnt, gccAnalysisCode1)), Convert.ToString(aVoucherDetails.GetValue(cnt, gccAnalysisCode2)), Convert.ToString(aVoucherDetails.GetValue(cnt, gccAnalysisCode3)), Convert.ToString(aVoucherDetails.GetValue(cnt, gccAnalysisCode4)), Convert.ToString(aVoucherDetails.GetValue(cnt, gccAnalysisCode5)));
			}

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

			MessageBox.Show("Changes Saved Successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

			return true;

			mError:
			grdVoucherDetails.Bookmark = cnt;
			grdVoucherDetails.Focus();
			//gConn.RollbackTrans

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
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]), "AddRecord");
			}


		}

		public void UpdateDeptEmployeeDetails()
		{
			string mysql = "";
			int mBillCd = 0;
			string mLdgrCd = "";
			string mCCCd = "";
			//Dim mcnt As Long
			int mCnt = 0;
			clsHourGlass myHourGlass = null;
			object mReturnValue = null;

			SqlDataReader rsTempRec = null;

			if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Invalid Department Code. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			//mCnt = grdVoucherDetails.Bookmark

			DialogResult ans = MessageBox.Show("Are you sure, you want to update billing code for all the Employee of this Department. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if (ans == System.Windows.Forms.DialogResult.Yes)
			{
				myHourGlass = new clsHourGlass();
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (mCnt = 0; mCnt <= tempForEndVar; mCnt++)
				{
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(aVoucherDetails.GetValue(mCnt, gccSelect))) == TriState.True)
					{
						mBillCd = Convert.ToInt32(aVoucherDetails.GetValue(mCnt, gccBillCd));
						if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCnt, gccLdgrNo), SystemVariables.DataType.StringType))
						{
							mysql = " select ldgr_cd from gl_ledger ";
							mysql = mysql + " where ldgr_no='" + Convert.ToString(aVoucherDetails.GetValue(mCnt, gccLdgrNo)) + "'";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mReturnValue))
							{
								MessageBox.Show("Invalid Ledger ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								grdVoucherDetails.Focus();
								return;
							}
							else
							{
								//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mLdgrCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
							}
						}
						else
						{
							mLdgrCd = "";
						}

						if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCnt, gccCCNo), SystemVariables.DataType.NumberType))
						{
							mysql = " select cost_cd from gl_cost_centers ";
							mysql = mysql + " where cost_no=" + Convert.ToString(aVoucherDetails.GetValue(mCnt, gccCCNo));
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mReturnValue))
							{
								MessageBox.Show("Invalid Cost Center ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								grdVoucherDetails.Focus();
								return;
							}
							else
							{
								//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mCCCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
							}
						}
						else
						{
							mCCCd = "";
						}

						mysql = " select emp_cd from Pay_employee ";
						mysql = mysql + " where dept_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
						rsTempRec = sqlCommand.ExecuteReader();
						rsTempRec.Read();
						do 
						{
							//, aVoucherDetails(mCnt, gccAccntCode), aVoucherDetails(mCnt, gccPartyCode), aVoucherDetails(mCnt, gccServiceCode), aVoucherDetails(mCnt, gccDepartCode)
							SystemHRProcedure.UpdateEmployeeGLLinks(mBillCd, Convert.ToInt32(rsTempRec["emp_cd"]), mLdgrCd, mCCCd, Convert.ToString(aVoucherDetails.GetValue(mCnt, gccAnalysisCode1)), Convert.ToString(aVoucherDetails.GetValue(mCnt, gccAnalysisCode2)), Convert.ToString(aVoucherDetails.GetValue(mCnt, gccAnalysisCode3)), Convert.ToString(aVoucherDetails.GetValue(mCnt, gccAnalysisCode4)), Convert.ToString(aVoucherDetails.GetValue(mCnt, gccAnalysisCode5)));
						}
						while(rsTempRec.Read());
						rsTempRec.Close();
					}
				}
			}
			else
			{
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

			//If grdVoucherDetails.Row <> LastRow Then
			//    If grdVoucherDetails.AddNewMode = dbgNoAddNew Then
			//        If Val(grdVoucherDetails.Columns(gccApplyCostCenter).Value) = True Then
			//            grdVoucherDetails.Columns(gccCCNo).AllowFocus = True
			//        Else
			//            grdVoucherDetails.Columns(gccCCNo).AllowFocus = False
			//        End If
			//    ElseIf grdVoucherDetails.AddNewMode = dbgAddNewCurrent Then
			//    Else                    'if grdVoucherDetails.AddNewMode = dbgAddNewPending
			//        If Val(grdVoucherDetails.Columns(gccApplyCostCenter).Value) = True Then
			//            grdVoucherDetails.Columns(gccCCNo).AllowFocus = True
			//        Else
			//            grdVoucherDetails.Columns(gccCCNo).AllowFocus = False
			//        End If
			//    End If
			//Else
			//    If mFirstGridFocus = True And aVoucherDetails.Count(1) > 0 And IsNull(LastRow) = True Then
			//        If Val(grdVoucherDetails.Columns(gccApplyCostCenter).Value) = True Then
			//            grdVoucherDetails.Columns(gccCCNo).AllowFocus = True
			//        Else
			//            grdVoucherDetails.Columns(gccCCNo).AllowFocus = False
			//        End If
			//    End If
			//End If

		}

		private void GetBillingDetails()
		{
			int cnt = 0;

			string mysql = " select  pbt.bill_cd , pbt.bill_no ";
			mysql = mysql + " , gl_ledger.ldgr_no";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , gl_ledger.l_ldgr_name ldgr_name , cc.l_cost_name cc_name, pbt.l_bill_name bill_name ";
			}
			else
			{
				mysql = mysql + " , gl_ledger.a_ldgr_name ldgr_name , cc.a_cost_name cc_name, pbt.a_bill_name bill_name ";
			}
			mysql = mysql + " , case when cc.cost_no=0 then '' else cast(cc.cost_no as varchar) end cost_no ";
			mysql = mysql + " , pdgl.analysis1_cd , pdgl.analysis2_cd , pdgl.analysis3_cd , pdgl.analysis4_cd , pdgl.analysis5_cd ";
			//''''''''If GetSystemPreferenceSetting("pay_gl_entry_method") = 3 Then
			//''''''''  mySql = mySql & " , pdgl.account_cd, pdgl.party_cd, pdgl.service_cd, pdgl.depart_cd "
			//''''''''End If
			mysql = mysql + " from pay_billing_type pbt ";
			mysql = mysql + " left join Pay_Department_GL_Details pdgl on pbt.bill_cd = pdgl.bill_cd ";
			mysql = mysql + " left join gl_ledger on pdgl.ldgr_cd = gl_ledger.ldgr_cd ";
			mysql = mysql + " left join gl_cost_centers cc on pdgl.cost_cd = cc.cost_cd ";
			mysql = mysql + " where pdgl.dept_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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
			mysql = mysql + " , '' , '', '' , '' , '' , ''";
			//''''''''''If GetSystemPreferenceSetting("pay_gl_entry_method") = 3 Then
			//''''''''''  mySql = mySql & " , '' , '', '', '' "
			//''''''''''End If
			mysql = mysql + " from pay_billing_type pbt ";
			mysql = mysql + " where not exists ( select bill_cd from Pay_Department_GL_Details pdgl ";
			mysql = mysql + " where pdgl.bill_cd = pbt.bill_cd and pdgl.dept_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["analysis1_cd"]) + "", cnt, gccAnalysisCode1);
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["analysis2_cd"]) + "", cnt, gccAnalysisCode2);
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["analysis3_cd"]) + "", cnt, gccAnalysisCode3);
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["analysis4_cd"]) + "", cnt, gccAnalysisCode4);
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["analysis5_cd"]) + "", cnt, gccAnalysisCode5);
				//''''''        If GetSystemPreferenceSetting("pay_gl_entry_method") = 3 Then
				//''''''            aVoucherDetails(cnt, gccAccntCode) = .Fields("account_cd").Value & ""
				//''''''            aVoucherDetails(cnt, gccPartyCode) = .Fields("party_cd").Value & ""
				//''''''            aVoucherDetails(cnt, gccServiceCode) = .Fields("service_cd").Value & ""
				//''''''            aVoucherDetails(cnt, gccDepartCode) = .Fields("depart_cd").Value & ""
				//''''''        End If
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
			if (Col == gccSelect && ReflectionHelper.GetPrimitiveValue<double>(Bookmark) >= 0)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(aVoucherDetails.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), Col))) == TriState.True)
				{
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgChecked2"];
					CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
				}
				else if (((TriState) Convert.ToInt32(aVoucherDetails.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), Col))) == TriState.False)
				{ 
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgUnchecked"];
					CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
				}
			}

		}

		public void findRecord()
		{
			//Call the find window
			string mysql = "";
			//mySql = " pbt.show =  1 "
			//mTempSearchValue = FindItem(7008000, , mySql)
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7001000, "", mysql));

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
			try
			{

				string mysql = "";
				object mReturnValue = null;


				mysql = " select dept_no ";
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					mysql = mysql + " , l_dept_name ";
				}
				else
				{
					mysql = mysql + " , a_dept_name ";
				}
				mysql = mysql + " from Pay_department ";
				mysql = mysql + " where dept_cd = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDeptCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDeptName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));

					GetBillingDetails();
					grdVoucherDetails.Enabled = true;
					grdVoucherDetails.Focus();
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}

		}

		public void KRoutine()
		{
			int cnt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(TriState.True, cnt, gccSelect);
			}
			grdVoucherDetails.Rebind(true);
		}

		public void URoutine()
		{
			int cnt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(TriState.False, cnt, gccSelect);
			}
			grdVoucherDetails.Rebind(true);
		}
	}
}