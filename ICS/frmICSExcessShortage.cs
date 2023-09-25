
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmICSExcessShortage
		: System.Windows.Forms.Form
	{

		public frmICSExcessShortage()
{
InitializeComponent();
} 
 public  void frmICSExcessShortage_old()
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
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			
		}


		private void frmICSExcessShortage_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private int mThisFormID = 0;
		private object mSearchValue = null;
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
		private bool mCurrentSearchOnInternalCodes = false;

		public int ThisVoucherType = 0;
		private DataSet _localRec = null;
		DataSet localRec
		{
			get
			{
				if (_localRec is null)
				{
					_localRec = new DataSet();
				}
				return _localRec;
			}
			set
			{
				_localRec = value;
			}
		}

		private bool mPostedToGLStatus = false;
		private bool mPostedToICSStatus = false;
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;

		private const int mMaxArrayCols = 8;

		private const int gccBuildLineNoColumn = 0;
		private const int gccBuildProductCodeColumn = 1;
		private const int gccBuildProductNameColumn = 2;
		private const int gccBuildProductLocColumn = 3;
		private const int gccBuildUnitSymbolColumn = 4;
		private const int gccBuildQtyColumn = 5;
		private const int gccBuildRateColumn = 6;
		private const int gccBuildAmountColumn = 7;
		private const int gccBuildRemarkColumn = 8;

		private int mBuildType = 0;
		private int mHeaderVoucherType = 0;
		private int mDetailVoucherType = 0;

		private DataSet rsProductCodeList = null;
		private DataSet rsUnitCodeList = null;
		private DataSet rsLocCodeList = null;
		private XArrayHelper _aProductInDetail = null;
		private XArrayHelper aProductInDetail
		{
			get
			{
				if (_aProductInDetail is null)
				{
					_aProductInDetail = new XArrayHelper();
				}
				return _aProductInDetail;
			}
			set
			{
				_aProductInDetail = value;
			}
		}

		private XArrayHelper _aProductOutDetail = null;
		private XArrayHelper aProductOutDetail
		{
			get
			{
				if (_aProductOutDetail is null)
				{
					_aProductOutDetail = new XArrayHelper();
				}
				return _aProductOutDetail;
			}
			set
			{
				_aProductOutDetail = value;
			}
		}

		private bool mFirstGridFocus = false;
		private bool mFirstOutGridFocus = false;

		private int mRecordNavigateSearchValue = 0;
		private string mTimeStamp = "";

		private System.Windows.Forms.TextBox FirstFocusObject = null;

		int mLocatCode = 0;
		int mLdgrCode = 0;
		private clsInvntTransaction oClsInvntTrans = null;
		public XtremeCommandBars.StatusBar UCStatusBar = null;


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

				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsVoucherTypes.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsVoucherTypes.MoveFirst();
				SystemVariables.rsVoucherTypes.Find("voucher_type = " + Conversion.Str(ThisVoucherType));

				if (ThisVoucherType == SystemICSConstants.icsExchangeProduct)
				{
					mBuildType = 1;
					mHeaderVoucherType = SystemICSConstants.icsExchangeProduct;
					mDetailVoucherType = SystemICSConstants.icsExchangeProduct;
				}
				else if (ThisVoucherType == SystemICSConstants.icsExchangeProduct)
				{ 
					mBuildType = 2;
					mHeaderVoucherType = SystemICSConstants.icsExchangeProduct;
					mDetailVoucherType = SystemICSConstants.icsExchangeProduct;
				}
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


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			object mTempValue = null;
			string mysql = "";

			switch(grdProductIn.Col)
			{
				case gccBuildProductCodeColumn : 
					if (ReflectionHelper.GetPrimitiveValue<string>(grdProductIn.Columns[gccBuildProductCodeColumn].Value) != "")
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name" : "a_prod_name") + ", symbol";
						mysql = mysql + " from ICS_Item p inner join ICS_Unit u";
						mysql = mysql + " on p.base_unit_cd =  u.unit_cd";
						mysql = mysql + " where part_no = '" + ReflectionHelper.GetPrimitiveValue<string>(grdProductIn.Columns[gccBuildProductCodeColumn].Value) + "'";

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							grdProductIn.Columns[gccBuildProductNameColumn].Value = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							grdProductIn.Columns[gccBuildProductNameColumn].Value = ((Array) mTempValue).GetValue(0);
							grdProductIn.Columns[gccBuildUnitSymbolColumn].Value = ((Array) mTempValue).GetValue(1);
						}
					} 
					 
					grdProductIn.Col = gccBuildUnitSymbolColumn; 
					break;
				case gccBuildProductNameColumn : 
					if (ReflectionHelper.GetPrimitiveValue<string>(grdProductIn.Columns[gccBuildProductNameColumn].Value) != "")
					{
						mysql = "select part_no , symbol ";
						mysql = mysql + " from ICS_Item p inner join ICS_Unit u";
						mysql = mysql + " on p.base_unit_cd =  u.unit_cd where ";
						mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name" : "a_prod_name") + " = '" + ReflectionHelper.GetPrimitiveValue<string>(grdProductIn.Columns[gccBuildProductNameColumn].Value) + "'";

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							grdProductIn.Columns[gccBuildProductCodeColumn].Value = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							grdProductIn.Columns[gccBuildProductCodeColumn].Value = ((Array) mTempValue).GetValue(0);
							grdProductIn.Columns[gccBuildUnitSymbolColumn].Value = ((Array) mTempValue).GetValue(1);
						}
					} 
					 
					grdProductIn.Col = gccBuildUnitSymbolColumn; 
					break;
				case gccBuildUnitSymbolColumn : 
					break;
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				object mTempSearchValue = null;

				if (this.ActiveControl.Name.ToLower() == ("grdProductIn").ToLower() || this.ActiveControl.Name.ToLower() == ("grdProductOut").ToLower())
				{
					if (Shift == 0)
					{
						if (grdProductIn.Col == gccBuildQtyColumn || grdProductIn.Col == gccBuildRateColumn || grdProductOut.Col == gccBuildQtyColumn || grdProductOut.Col == gccBuildRateColumn)
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
						if (KeyCode == 115 && (grdProductIn.Col == gccBuildProductCodeColumn || grdProductIn.Col == gccBuildProductNameColumn || grdProductOut.Col == gccBuildProductCodeColumn || grdProductOut.Col == gccBuildProductNameColumn))
						{
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001000, "28,29"));
							}
							else
							{
								//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001000, "28,30"));
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mTempSearchValue))
							{
								FetchDetailsFromPartNoInGrid(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)), ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(2)));
							}
						}
					}
				}

				//''(Alt + -> ) or ( Alt + <- )
				if (Shift == 4 && (KeyCode == 37 || KeyCode == 39))
				{
					if (!UserAccess.AllowUserDisplay)
					{
						MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					RecordNavidate(KeyCode, mRecordNavigateSearchValue);
					KeyCode = 0;
				}

				//on keydown navigate the form by using enter key
				if (KeyCode == ((int) Keys.Return))
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

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsVoucherTypes.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsVoucherTypes.MoveFirst();
				SystemVariables.rsVoucherTypes.Find("voucher_type = " + Conversion.Str(ThisVoucherType));

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
				this.Top = 0;
				this.Left = 0;
				mCurrentSearchOnInternalCodes = false;


				grdProductIn.Visible = false;
				grdProductOut.Visible = false;
				mFirstGridFocus = true;
				mFirstOutGridFocus = true;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginDeleteLineButtonWithGroup = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;
				oThisFormToolBar.ShowMoveRecordNextButton = true;
				oThisFormToolBar.ShowMoveRecordPreviousButton = true;
				oThisFormToolBar.ShowPostButton = true;
				this.WindowState = FormWindowState.Maximized;
				txtLocation.TabIndex = 1;
				txtRemark.TabIndex = 2;
				txtVoucherDate.Value = SystemVariables.gCurrentDate;

				LoadGrid();

				//''''*************************************************************************
				CreateStatusBar();
				//''''*************************************************************************

				this.Show();
				Application.DoEvents();

				FirstFocusObject = txtLocation;

				//''''*************************************************************************
				//'***setting form mode to add initially
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				//''''*************************************************************************
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}

		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			tabMaster.Width = this.Width - 7;
			tabMaster.Height = this.Height - (fraTransactionHeader.Height + frameBottom.Height + 75);
			frameBottom.Top = tabMaster.Top + tabMaster.Height + 1;

			grdProductIn.Width = tabMaster.Width - 11;
			grdProductIn.Height = tabMaster.Height - 27;

			grdProductOut.Width = tabMaster.Width - 11;
			grdProductOut.Height = tabMaster.Height - 27;

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			rsProductCodeList = null;
			rsUnitCodeList = null;
			rsLocCodeList = null;
		}

		private void grdProductIn_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;

			switch(grdProductIn.Col)
			{
				case gccBuildQtyColumn : 
					if (ReflectionHelper.GetPrimitiveValue<string>(grdProductIn.Columns[gccBuildQtyColumn].Value) != "" && ReflectionHelper.GetPrimitiveValue<string>(grdProductIn.Columns[gccBuildRateColumn].Value) != "")
					{
						grdProductIn.Columns[gccBuildAmountColumn].Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue<double>(grdProductIn.Columns[gccBuildQtyColumn].Value) * Conversion.Val(StringsHelper.Format(grdProductIn.Columns[gccBuildRateColumn].Text, "#############.000")), "#############.000");
						grdProductIn.UpdateData();
						CalculateTotals("grdProductIn", grdProductIn.Row, ReflectionHelper.GetPrimitiveValue<int>(grdProductIn.Columns[gccBuildAmountColumn].Value));
					} 
					break;
				case gccBuildRateColumn : 
					if (ReflectionHelper.GetPrimitiveValue<string>(grdProductIn.Columns[gccBuildRateColumn].Value) != "" && ReflectionHelper.GetPrimitiveValue<string>(grdProductIn.Columns[gccBuildQtyColumn].Value) != "")
					{
						grdProductIn.Columns[gccBuildAmountColumn].Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue<double>(grdProductIn.Columns[gccBuildQtyColumn].Value) * ReflectionHelper.GetPrimitiveValue<double>(grdProductIn.Columns[gccBuildRateColumn].Value), "#############.000");
						grdProductIn.UpdateData();
						CalculateTotals("grdProductIn", grdProductIn.Row, ReflectionHelper.GetPrimitiveValue<int>(grdProductIn.Columns[gccBuildAmountColumn].Value));
					} 
					break;
				case gccBuildAmountColumn : 
					if (ReflectionHelper.GetPrimitiveValue<string>(grdProductIn.Columns[gccBuildAmountColumn].Value) != "" && ReflectionHelper.GetPrimitiveValue<string>(grdProductIn.Columns[gccBuildQtyColumn].Value) != "")
					{
						grdProductIn.Columns[gccBuildRateColumn].Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue<double>(grdProductIn.Columns[gccBuildAmountColumn].Value) / ((double) ReflectionHelper.GetPrimitiveValue<double>(grdProductIn.Columns[gccBuildQtyColumn].Value)), "#############.000");
						grdProductIn.UpdateData();
						CalculateTotals("grdProductIn", grdProductIn.Row, ReflectionHelper.GetPrimitiveValue<int>(grdProductIn.Columns[gccBuildRateColumn].Value));
					} 
					break;
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdProductIn.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdProductIn_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			//--handle Null value error ---> when there is no ICS_Item in the
			//--system & the drop-down ICS_Item list combo is click
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				switch(ColIndex)
				{
					case gccBuildQtyColumn : 
						if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
						{
							if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) - Math.Floor(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value))) > 0)
							{
								Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,##0.0##");
							}
							else
							{
								Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,##0");
							}
						}
						else
						{
							Value = "";
						} 
						break;
					case gccBuildRateColumn : case gccBuildAmountColumn : 
						if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
						{
							Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,###,##0.000");
						}
						else
						{
							Value = "";
						} 
						 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdProductOut_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;

			switch(grdProductOut.Col)
			{
				case gccBuildQtyColumn : 
					if (ReflectionHelper.GetPrimitiveValue<string>(grdProductOut.Columns[gccBuildQtyColumn].Value) != "" && ReflectionHelper.GetPrimitiveValue<string>(grdProductOut.Columns[gccBuildRateColumn].Value) != "")
					{
						grdProductOut.Columns[gccBuildAmountColumn].Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue<double>(grdProductOut.Columns[gccBuildQtyColumn].Value) * Conversion.Val(StringsHelper.Format(grdProductOut.Columns[gccBuildRateColumn].Text, "#############.000")), "#############.000");
						grdProductOut.UpdateData();
						CalculateTotals("grdProductOut", grdProductOut.Row, ReflectionHelper.GetPrimitiveValue<int>(grdProductOut.Columns[gccBuildAmountColumn].Value));
					} 
					break;
				case gccBuildRateColumn : 
					if (ReflectionHelper.GetPrimitiveValue<string>(grdProductOut.Columns[gccBuildRateColumn].Value) != "" && ReflectionHelper.GetPrimitiveValue<string>(grdProductOut.Columns[gccBuildQtyColumn].Value) != "")
					{
						grdProductOut.Columns[gccBuildAmountColumn].Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue<double>(grdProductOut.Columns[gccBuildQtyColumn].Value) * Conversion.Val(StringsHelper.Format(grdProductOut.Columns[gccBuildRateColumn].Text, "#############.000")), "#############.000");
						grdProductOut.UpdateData();
						CalculateTotals("grdProductOut", grdProductOut.Row, ReflectionHelper.GetPrimitiveValue<int>(grdProductOut.Columns[gccBuildAmountColumn].Value));
					} 
					break;
				case gccBuildAmountColumn : 
					if (ReflectionHelper.GetPrimitiveValue<string>(grdProductOut.Columns[gccBuildAmountColumn].Value) != "" && ReflectionHelper.GetPrimitiveValue<string>(grdProductOut.Columns[gccBuildQtyColumn].Value) != "")
					{
						grdProductOut.Columns[gccBuildRateColumn].Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue<double>(grdProductOut.Columns[gccBuildAmountColumn].Value) / ((double) ReflectionHelper.GetPrimitiveValue<double>(grdProductOut.Columns[gccBuildQtyColumn].Value)), "#############.000");
						grdProductOut.UpdateData();
						CalculateTotals("grdProductOut", grdProductOut.Row, ReflectionHelper.GetPrimitiveValue<int>(grdProductOut.Columns[gccBuildAmountColumn].Value));
					} 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdProductOut.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdProductOut_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			//--handle Null value error ---> when there is no ICS_Item in the
			//--system & the drop-down ICS_Item list combo is click
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				switch(ColIndex)
				{
					case gccBuildQtyColumn : 
						if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
						{
							if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) - Math.Floor(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value))) > 0)
							{
								Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,##0.0##");
							}
							else
							{
								Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,##0");
							}
						}
						else
						{
							Value = "";
						} 
						break;
					case gccBuildRateColumn : case gccBuildAmountColumn : 
						if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
						{
							Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,###,##0.000");
						}
						else
						{
							Value = "";
						} 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtLdgrCode_DropButtonClick(Object Sender, EventArgs e)
		{

			txtLdgrCode.Text = "";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", "(type_cd = 3) and discontinued = 0"));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtLdgrCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				txtLdgrCode_Leave(txtLdgrCode, new EventArgs());
			}
		}

		private void txtLdgrCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				if (txtLdgrCode.Text != "")
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_ldgr_Name" : "a_ldgr_Name");
					mysql = mysql + ",'' from gl_ledger where ldgr_No = " + txtLdgrCode.Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtLedgerName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLedgerName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
					}
				}
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				txtLdgrCode.Focus();
			}

		}

		private void txtSalesman_DropButtonClick(Object Sender, EventArgs e)
		{

			txtSalesman.Text = "";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1004000, "88"));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtSalesman.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				txtSalesman_Leave(txtSalesman, new EventArgs());
			}
		}

		private void txtSalesman_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{

				object mTempValue = null;
				string mysql = "";
				if (txtSalesman.Text != "")
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Sman_Name" : "a_Sman_Name");
					mysql = mysql + ",'' from SM_Salesman where Sman_No = " + txtSalesman.Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtSmanDisplayLabel.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtSmanDisplayLabel.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
					}
				}
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				txtSalesman.Focus();
			}

		}

		private void txtLocation_DropButtonClick(Object Sender, EventArgs e)
		{
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2004000, "82"));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtLocation.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				txtLocation_Leave(txtLocation, new EventArgs());
			}
		}

		private void txtLocation_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				if (txtLocation.Text != "")
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name");
					mysql = mysql + ",'' from SM_Location where locat_no = " + txtLocation.Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtLocDisplayLabel.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLocDisplayLabel.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
					}
				}
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				txtLocation.Focus();
			}

		}

		private object LoadGrid()
		{

			string mGridHeaderFooterColor = (0xE7E2DC).ToString();

			//**--define voucher grid columns
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsVoucherTypes.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.rsVoucherTypes.MoveFirst();
			SystemVariables.rsVoucherTypes.Find("voucher_type = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("Auto_Generate_Excess_Voucher_Type")));

			SystemGrid.DefineSystemVoucherGrid(grdProductIn, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, mGridHeaderFooterColor, mGridHeaderFooterColor, 320, ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("ics_grid_font_size")));

			//**--define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdProductIn, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdProductIn, "Product Code", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbMastersList", false, true, false, false, false, false, 100, "", "", false, "", 0, true);
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			SystemGrid.DefineSystemVoucherGridColumn(grdProductIn, "Product Name", 4000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbMastersList", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Name_In_Details"]), false, false, false, false, 200, "", "", false, "", 0, true);
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			SystemGrid.DefineSystemVoucherGridColumn(grdProductIn, "Location", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbMastersList", true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Location_In_Details"]));

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			SystemGrid.DefineSystemVoucherGridColumn(grdProductIn, "Unit", 600, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbMastersList", true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_unit_in_details"]));
			SystemGrid.DefineSystemVoucherGridColumn(grdProductIn, "Qty", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, true, true, 12);
			SystemGrid.DefineSystemVoucherGridColumn(grdProductIn, "Rate", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, true, 12);
			SystemGrid.DefineSystemVoucherGridColumn(grdProductIn, "Amount", 900, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, true, true, 12);
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			SystemGrid.DefineSystemVoucherGridColumn(grdProductIn, "Remarks", 1500, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Remarks_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Remarks_In_Details"]), false, false, true, false, 500, "", SystemConstants.gArabicFontName, false, "", 0, true, 2040);

			//''''*************************************************************************
			//setting voucher details grid properties
			aProductInDetail = new XArrayHelper();
			SystemGrid.DefineVoucherArray(aProductInDetail, mMaxArrayCols, -1, false);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdProductIn.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdProductIn.setArray(aProductInDetail);
			grdProductIn.Rebind(true);
			//''''*************************************************************************

			SystemGrid.DefineSystemVoucherGrid(grdProductOut, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, mGridHeaderFooterColor, mGridHeaderFooterColor, 320, ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("ics_grid_font_size")));

			//**--define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdProductOut, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdProductOut, "Product Code", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbMastersListOut", false, true, false, false, false, false, 100, "", "", false, "", 0, true);
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			SystemGrid.DefineSystemVoucherGridColumn(grdProductOut, "Product Name", 4000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbMastersListOut", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Name_In_Details"]), false, false, false, false, 200, "", "", false, "", 0, true);
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			SystemGrid.DefineSystemVoucherGridColumn(grdProductOut, "Location", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbMastersListOut", true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Location_In_Details"]));

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			SystemGrid.DefineSystemVoucherGridColumn(grdProductOut, "Unit", 600, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbMastersListOut", true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_unit_in_details"]));
			SystemGrid.DefineSystemVoucherGridColumn(grdProductOut, "Qty", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, true, true, 12);
			SystemGrid.DefineSystemVoucherGridColumn(grdProductOut, "Rate", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, true, 12);
			SystemGrid.DefineSystemVoucherGridColumn(grdProductOut, "Amount", 900, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, true, true, 12);
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			SystemGrid.DefineSystemVoucherGridColumn(grdProductOut, "Remarks", 1500, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Remarks_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Remarks_In_Details"]), false, false, true, false, 500, "", SystemConstants.gArabicFontName, false, "", 0, true, 2040);

			//''''*************************************************************************
			//setting voucher details grid properties
			aProductOutDetail = new XArrayHelper();
			SystemGrid.DefineVoucherArray(aProductOutDetail, mMaxArrayCols, -1, false);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdProductOut.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdProductOut.setArray(aProductOutDetail);
			grdProductOut.Rebind(true);
			//''''*************************************************************************

			Application.DoEvents();
			grdProductIn.Visible = true;
			grdProductOut.Visible = true;
			return null;
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdProductIn.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdProductIn_OnAddNew()
		{
			if (!mFirstGridFocus)
			{
				grdProductIn.Columns[gccBuildLineNoColumn].Text = (grdProductIn.RowCount + 1).ToString();
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdProductOut.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdProductOut_OnAddNew()
		{
			if (!mFirstOutGridFocus)
			{
				grdProductOut.Columns[gccBuildLineNoColumn].Text = (grdProductOut.RowCount + 1).ToString();
			}
		}

		private void grdProductIn_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			try
			{

				int cnt = 0;
				object mCurrentbal = null;

				if (grdProductIn.Row != ReflectionHelper.GetPrimitiveValue<double>(LastRow))
				{
					if (grdProductIn.AddNewMode == C1.Win.C1TrueDBGrid.AddNewModeEnum.NoAddNew)
					{
						ShowProductDetails(false, ReflectionHelper.GetPrimitiveValue<string>(grdProductIn.Columns[gccBuildProductCodeColumn].Value));
					}
					else if (grdProductIn.AddNewMode == C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent)
					{ 
						ShowProductDetails(true, ReflectionHelper.GetPrimitiveValue<string>(grdProductIn.Columns[gccBuildProductCodeColumn].Value));
					}
					else
					{
						ShowProductDetails(false, ReflectionHelper.GetPrimitiveValue<string>(grdProductIn.Columns[gccBuildProductCodeColumn].Value));
					}
				}
				else
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!mFirstGridFocus && aProductInDetail.GetLength(0) > 0 && Convert.IsDBNull(LastRow))
					{
						ShowProductDetails(false, ReflectionHelper.GetPrimitiveValue<string>(grdProductIn.Columns[gccBuildProductCodeColumn].Value));
					}
				}

				if (grdProductIn.Col > 0 && !mFirstGridFocus)
				{
					switch(grdProductIn.Col)
					{
						case gccBuildProductCodeColumn : case gccBuildProductNameColumn : 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersList.setDataSource((msdatasrc.DataSource) rsProductCodeList); 
							 
							break;
						case gccBuildUnitSymbolColumn : 
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
							if (!Convert.IsDBNull(grdProductIn.Columns[gccBuildProductCodeColumn].Text) || grdProductIn.Columns[gccBuildProductCodeColumn].Text != "")
							{
								//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								rsUnitCodeList.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
								rsUnitCodeList.Tables[0].DefaultView.RowFilter = " part_no = '" + ReflectionHelper.GetPrimitiveValue<string>(grdProductIn.Columns[gccBuildProductCodeColumn].Value).Trim() + "'";
							} 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersList.setDataSource((msdatasrc.DataSource) rsUnitCodeList); 
							break;
						case gccBuildProductLocColumn : 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersList.setDataSource((msdatasrc.DataSource) rsLocCodeList); 
							break;
					}
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			//'***************************************************************************''
			//'This routine handles the listbox attributes on the grid according to the
			//'datasource. It gives the width of columns in the listbox and sort order.
			//'***************************************************************************''

			int cnt = 0;
			cmbMastersList.Width = 0;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdProductIn.Col)
			{
				case gccBuildProductCodeColumn : case gccBuildProductNameColumn : 
					if (grdProductIn.Col == gccBuildProductCodeColumn)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("part_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProductCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsProductCodeList.setSort("part_no");

					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("prod_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProductCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsProductCodeList.setSort("prod_name");
					} 
					 
					int tempForEndVar = cmbMastersList.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersList.Splits[0].DisplayColumns[cnt];
						if (cnt < 2)
						{
							switch(cnt)
							{
								case 0 : 
									//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
									withVar.setOrder((grdProductIn.Col == gccBuildProductCodeColumn) ? 0 : 1); 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdProductIn.Splits[0].DisplayColumns[gccBuildProductCodeColumn].Width; 
									withVar.Visible = grdProductIn.Col != gccBuildUnitSymbolColumn; 
									break;
								case 1 : 
									//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
									withVar.setOrder((grdProductIn.Col == gccBuildProductCodeColumn) ? 1 : 0); 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdProductIn.Splits[0].DisplayColumns[gccBuildProductNameColumn].Width; 
									withVar.Visible = grdProductIn.Col != gccBuildUnitSymbolColumn; 
									break;
								case 2 : 
									//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
									withVar.setOrder((grdProductIn.Col == gccBuildUnitSymbolColumn) ? 0 : 0); 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdProductIn.Splits[0].DisplayColumns[gccBuildUnitSymbolColumn].Width; 
									withVar.Visible = grdProductIn.Col == gccBuildUnitSymbolColumn; 
									break;
							}
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							cmbMastersList.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					cmbMastersList.Width += 17; 
					if (grdProductIn.Row < 3)
					{
						cmbMastersList.Height = 180;
					}
					else
					{
						cmbMastersList.Height = Convert.ToInt32(173 - ((grdProductIn.Row - 2) * grdProductIn.RowHeight));
					} 
					 
					break;
				case gccBuildUnitSymbolColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList.setListField("symbol"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsUnitCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsUnitCodeList.setSort("symbol"); 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbMastersList.DisplayColumns[1].Width = grdProductIn.Splits[0].DisplayColumns[gccBuildUnitSymbolColumn].Width + 33; 
					cmbMastersList.DisplayColumns[1].Visible = true; 
					cmbMastersList.DisplayColumns[0].Visible = false; 
					cmbMastersList.Width += 33; 
					cmbMastersList.Height = 113; 
					 
					break;
				case gccBuildProductLocColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList.setListField("Locat_No"); 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbMastersList.DisplayColumns[1].Width = grdProductIn.Splits[0].DisplayColumns[gccBuildProductLocColumn].Width + 33; 
					cmbMastersList.DisplayColumns[1].Visible = true; 
					cmbMastersList.DisplayColumns[0].Visible = false; 
					cmbMastersList.Width += 33; 
					cmbMastersList.Height = 113; 
					 
					break;
				default:
					cmbMastersList.Width = 0; 
					break;
			}
		}

		private void RefreshRecordset(bool pCallComboRowChange = true)
		{
			string mysql = "";

			if (mFirstGridFocus)
			{
				GetProductListSQL(ref mysql);
				rsProductCodeList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProductCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsProductCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsProductCodeList.Tables.Clear();
				adap.Fill(rsProductCodeList);

				mysql = "Select ICS_Item.part_no, ICS_Unit.symbol from ICS_Item_Unit_Details ";
				mysql = mysql + " inner join ICS_Unit on ICS_Item_Unit_Details.alt_unit_cd = ICS_Unit.unit_cd ";
				mysql = mysql + " inner join ICS_Item on ICS_Item_Unit_Details.prod_cd = ICS_Item.prod_cd ";

				rsUnitCodeList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsUnitCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsUnitCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsUnitCodeList.Tables.Clear();
				adap_2.Fill(rsUnitCodeList);

				mysql = "Select l.Locat_No, l.L_Locat_Name from SM_Location l ";
				rsLocCodeList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLocCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLocCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap_3 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLocCodeList.Tables.Clear();
				adap_3.Fill(rsLocCodeList);

			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsProductCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsProductCodeList.Requery(-1);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsUnitCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsUnitCodeList.Requery(-1);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsLocCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLocCodeList.Requery(-1);
			}
		}


		private void GetProductListSQL(ref string pSQL)
		{
			//''''*************************************************************************
			//'''Product List query, alone with Base Unit and stock info.
			//''''*************************************************************************
			object mTempReturnValue = null;

			pSQL = "select part_no, ";
			pSQL = pSQL + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name as prod_name" : "a_prod_name as prod_name");
			pSQL = pSQL + " , ICS_Unit.symbol, ";
			pSQL = pSQL + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name" : "a_group_name") + " as group_name, ";
			pSQL = pSQL + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cat_name" : "a_cat_name") + " as cat_name ";
			pSQL = pSQL + " ,isnull(pld.stock_in_hand, 0) as stock_in_hand, ";
			pSQL = pSQL + " isnull(pld.stock_allocated, 0) as stock_allocated, ";
			pSQL = pSQL + " isnull(pld.stock_available, 0) as stock_available, ";
			pSQL = pSQL + " isnull(pld.stock_in_transit, 0) as stock_in_transit, ";
			pSQL = pSQL + " isnull(pld.stock_on_order, 0) as stock_on_order, ICS_Item.prod_cd ";
			pSQL = pSQL + " , ICS_Item.sale_rate1 ";
			pSQL = pSQL + " , ICS_Item.purchase_rate , serialized ";
			pSQL = pSQL + " from ICS_Item ";
			pSQL = pSQL + " inner join ICS_Unit on ICS_Item.base_unit_cd = ICS_Unit.unit_cd ";
			pSQL = pSQL + " inner join ICS_Item_group on ICS_Item_group.group_cd = ICS_Item.group_cd ";
			pSQL = pSQL + " inner join ICS_Item_category on ICS_Item_category.cat_cd = ICS_Item.cat_cd ";
			pSQL = pSQL + " left outer join (select * from ICS_Item_location_details ";
			if (SystemProcedure2.IsItEmpty(txtLocation.Text, SystemVariables.DataType.NumberType))
			{
				pSQL = pSQL + " where locat_cd = " + Conversion.Str(SystemVariables.gLoggedInUserLocationCode);
			}
			else
			{
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select locat_cd from SM_Location where locat_no = " + Conversion.Str(txtLocation.Text)));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempReturnValue))
				{
					pSQL = pSQL + " where locat_cd = 0";
				}
				else
				{
					pSQL = pSQL + " where locat_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
				}
			}
			pSQL = pSQL + " ) as pld on ICS_Item.prod_cd = pld.prod_cd ";
			pSQL = pSQL + " where ICS_Item.discontinued = 0 ";
			//pSQL = pSQL & " and item_type_cd = 1 "


		}


		private void grdProductIn_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			//''''*************************************************************************
			//''''On the First focus of the grid
			//''''Define the Combo, Refresh the recordset, and generate the line no.
			//''''The first focus of the grid is maintained by the variable mFirstGridFocus
			//''''*************************************************************************

			try
			{
				string mysql = "";

				if (mFirstGridFocus)
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList);
					RefreshRecordset();
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdProductIn.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdProductIn.PostMsg(1);

					grdProductIn_OnAddNew(grdProductIn, new EventArgs());
					mFirstGridFocus = false;
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersListOut.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersListOut_DataSourceChanged()
		{
			//'***************************************************************************''
			//'This routine handles the listbox attributes on the grid according to the
			//'datasource. It gives the width of columns in the listbox and sort order.
			//'***************************************************************************''

			int cnt = 0;
			cmbMastersListOut.Width = 0;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdProductOut.Col)
			{
				case gccBuildProductCodeColumn : case gccBuildProductNameColumn : 
					if (grdProductOut.Col == gccBuildProductCodeColumn)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersListOut.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersListOut.setListField("part_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProductCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsProductCodeList.setSort("part_no");

					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersListOut.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersListOut.setListField("prod_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProductCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsProductCodeList.setSort("prod_name");
					} 
					 
					int tempForEndVar = cmbMastersListOut.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersListOut.Splits[0].DisplayColumns[cnt];
						if (cnt < 2)
						{
							switch(cnt)
							{
								case 0 : 
									//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
									withVar.setOrder((grdProductOut.Col == gccBuildProductCodeColumn) ? 0 : 1); 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdProductOut.Splits[0].DisplayColumns[gccBuildProductCodeColumn].Width; 
									withVar.Visible = grdProductOut.Col != gccBuildUnitSymbolColumn; 
									break;
								case 1 : 
									//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
									withVar.setOrder((grdProductOut.Col == gccBuildProductCodeColumn) ? 1 : 0); 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdProductOut.Splits[0].DisplayColumns[gccBuildProductNameColumn].Width; 
									withVar.Visible = grdProductOut.Col != gccBuildUnitSymbolColumn; 
									break;
								case 2 : 
									//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
									withVar.setOrder((grdProductOut.Col == gccBuildUnitSymbolColumn) ? 0 : 0); 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdProductOut.Splits[0].DisplayColumns[gccBuildUnitSymbolColumn].Width; 
									withVar.Visible = grdProductOut.Col == gccBuildUnitSymbolColumn; 
									break;
							}
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							cmbMastersListOut.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					cmbMastersListOut.Width += 17; 
					if (grdProductOut.Row < 3)
					{
						cmbMastersListOut.Height = 180;
					}
					else
					{
						cmbMastersListOut.Height = Convert.ToInt32(173 - ((grdProductOut.Row - 2) * grdProductOut.RowHeight));
					} 
					 
					break;
				case gccBuildUnitSymbolColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersListOut.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersListOut.setListField("symbol"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsUnitCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsUnitCodeList.setSort("symbol"); 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbMastersListOut.DisplayColumns[1].Width = grdProductOut.Splits[0].DisplayColumns[gccBuildUnitSymbolColumn].Width + 33; 
					cmbMastersListOut.DisplayColumns[1].Visible = true; 
					cmbMastersListOut.DisplayColumns[0].Visible = false; 
					cmbMastersListOut.Width += 33; 
					cmbMastersListOut.Height = 113; 
					break;
				default:
					cmbMastersListOut.Width = 0; 
					break;
			}
		}


		private void grdProductOut_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			//''''*************************************************************************
			//''''On the First focus of the grid
			//''''Define the Combo, Refresh the recordset, and generate the line no.
			//''''The first focus of the grid is maintained by the variable mFirstOutGridFocus
			//''''*************************************************************************

			try
			{
				string mysql = "";

				if (mFirstOutGridFocus)
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersListOut);
					RefreshRecordset();
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdProductOut.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdProductOut.PostMsg(1);

					grdProductOut_OnAddNew(grdProductOut, new EventArgs());
					mFirstOutGridFocus = false;
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void grdProductOut_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			try
			{

				int cnt = 0;
				object mCurrentbal = null;

				if (grdProductOut.Row != ReflectionHelper.GetPrimitiveValue<double>(LastRow))
				{
					if (grdProductOut.AddNewMode == C1.Win.C1TrueDBGrid.AddNewModeEnum.NoAddNew)
					{
						ShowProductDetails(false, ReflectionHelper.GetPrimitiveValue<string>(grdProductOut.Columns[gccBuildProductCodeColumn].Value));
					}
					else if (grdProductIn.AddNewMode == C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent)
					{ 
						ShowProductDetails(true, ReflectionHelper.GetPrimitiveValue<string>(grdProductOut.Columns[gccBuildProductCodeColumn].Value));
					}
					else
					{
						ShowProductDetails(false, ReflectionHelper.GetPrimitiveValue<string>(grdProductOut.Columns[gccBuildProductCodeColumn].Value));
					}
				}
				else
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!mFirstOutGridFocus && aProductOutDetail.GetLength(0) > 0 && Convert.IsDBNull(LastRow))
					{
						ShowProductDetails(false, ReflectionHelper.GetPrimitiveValue<string>(grdProductOut.Columns[gccBuildProductCodeColumn].Value));
					}
				}

				if (grdProductOut.Col > 0 && !mFirstOutGridFocus)
				{
					switch(grdProductOut.Col)
					{
						case gccBuildProductCodeColumn : case gccBuildProductNameColumn : 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersListOut.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersListOut.setDataSource((msdatasrc.DataSource) rsProductCodeList); 
							break;
						case gccBuildUnitSymbolColumn : 
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
							if (!Convert.IsDBNull(grdProductOut.Columns[gccBuildProductCodeColumn].Text) || grdProductOut.Columns[gccBuildProductCodeColumn].Text != "")
							{
								//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								rsUnitCodeList.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
								rsUnitCodeList.Tables[0].DefaultView.RowFilter = " part_no = '" + ReflectionHelper.GetPrimitiveValue<string>(grdProductOut.Columns[gccBuildProductCodeColumn].Value).Trim() + "'";
							} 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersListOut.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersListOut.setDataSource((msdatasrc.DataSource) rsUnitCodeList); 
							break;
						case gccBuildProductLocColumn : 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersListOut.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersListOut.setDataSource((msdatasrc.DataSource) rsLocCodeList); 
							break;
					}
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}


		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersListOut.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersListOut_DropDownClose()
		{
			object mTempValue = null;
			string mysql = "";

			switch(grdProductOut.Col)
			{
				case gccBuildProductCodeColumn : 
					if (ReflectionHelper.GetPrimitiveValue<string>(grdProductOut.Columns[gccBuildProductCodeColumn].Value) != "")
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name" : "a_prod_name") + ", symbol";
						mysql = mysql + " from ICS_Item p inner join ICS_Unit u";
						mysql = mysql + " on p.base_unit_cd =  u.unit_cd";
						mysql = mysql + " where part_no = '" + ReflectionHelper.GetPrimitiveValue<string>(grdProductOut.Columns[gccBuildProductCodeColumn].Value) + "'";

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							grdProductOut.Columns[gccBuildProductNameColumn].Value = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							grdProductOut.Columns[gccBuildProductNameColumn].Value = ((Array) mTempValue).GetValue(0);
							grdProductOut.Columns[gccBuildUnitSymbolColumn].Value = ((Array) mTempValue).GetValue(1);
						}
					} 
					 
					grdProductOut.Col = gccBuildUnitSymbolColumn; 
					break;
				case gccBuildProductNameColumn : 
					if (ReflectionHelper.GetPrimitiveValue<string>(grdProductOut.Columns[gccBuildProductNameColumn].Value) != "")
					{
						mysql = "select part_no , symbol ";
						mysql = mysql + " from ICS_Item p inner join ICS_Unit u";
						mysql = mysql + " on p.base_unit_cd =  u.unit_cd where ";
						mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name" : "a_prod_name") + " = '" + ReflectionHelper.GetPrimitiveValue<string>(grdProductOut.Columns[gccBuildProductNameColumn].Value) + "'";

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							grdProductOut.Columns[gccBuildProductCodeColumn].Value = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							grdProductOut.Columns[gccBuildProductCodeColumn].Value = ((Array) mTempValue).GetValue(0);
							grdProductOut.Columns[gccBuildUnitSymbolColumn].Value = ((Array) mTempValue).GetValue(1);

						}
					} 
					 
					grdProductOut.Col = gccBuildUnitSymbolColumn; 
					break;
				case gccBuildUnitSymbolColumn : 
					break;
			}
		}

		private void ShowProductDetails(bool pShowRecordEmpty, string pProductCode)
		{
			//''''*************************************************************************
			//'''Display the ICS_Item info in the status bar
			//''''*************************************************************************

			if (!pShowRecordEmpty)
			{
				if (pProductCode.Trim() != "")
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsProductCodeList.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsProductCodeList.MoveFirst();
					rsProductCodeList.Find("part_no = '" + pProductCode + "'");
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProductCodeList.BOF was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					if (rsProductCodeList.Tables[0].Rows.Count != 0 || rsProductCodeList.getBOF())
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						UCStatusBar.FindPane(SystemICSConstants.lcBaseUnit2).Text = Convert.ToString(rsProductCodeList.Tables[0].Rows[0]["symbol"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						UCStatusBar.FindPane(SystemICSConstants.lcStockInHand2).Text = Convert.ToString(rsProductCodeList.Tables[0].Rows[0]["stock_in_hand"]);
						//UCStatusBar.FindPane(lcStockAllocated2).Text = CStr(rsProductCodeList.Fields("stock_allocated").Value)
						//UCStatusBar.FindPane(lcStockAvailable2).Text = CStr(rsProductCodeList.Fields("stock_available").Value)

						return;
					}
				}
			}
			ClearStatusBar();
		}

		public bool saveRecord()
		{
			bool result = false;
			object mTempValue = null;

			string mysql = "";

			string mSmanCode = "";
			string mProdCode = "";
			string mProdName = "";
			int mUnitCode = 0;
			double mRate = 0;
			double mAmount = 0;
			double mQty = 0;
			int mEntryId = 0;

			double mBaseQty = 0;

			int mVoucherNo = 0;
			int cnt = 0;


			clsHourGlass myHourGlass = new clsHourGlass();
			try
			{

				if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
				{
					SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 2);
					if (FirstFocusObject.Enabled)
					{
						FirstFocusObject.Focus();
					}
					goto StationExitFunction;
				}

				//'''****************************Get the Loation Code ****************************
				//''''****************************************************************************
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select locat_cd from SM_Location where locat_no = '" + txtLocation.Text + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempValue))
				{
					MessageBox.Show("Enter valid location code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (txtLocation.Enabled)
					{
						txtLocation.Focus();
					}
					goto StationExitFunction;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLocatCode = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
				}
				//''''****************************************************************************
				//'''****************************Get the Ledger Code ****************************
				//''''****************************************************************************
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Ldgr_Cd from GL_Ledger where Ldgr_No = '" + txtLdgrCode.Text + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempValue))
				{
					MessageBox.Show("Enter valid Ledger code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (txtLdgrCode.Enabled)
					{
						txtLdgrCode.Focus();
					}
					goto StationExitFunction;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLdgrCode = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
				}
				//''''****************************************************************************
				//'''****************************Get the Salesman Code ****************************
				//''''****************************************************************************
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Sman_Cd from SM_Salesman where Sman_No = '" + txtSalesman.Text + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempValue))
				{
					MessageBox.Show("Enter valid Salesman code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (txtSalesman.Enabled)
					{
						txtSalesman.Focus();
					}
					goto StationExitFunction;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSmanCode = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
				}
				//''''****************************************************************************

				//'''****************************Check for Amount Total ****************************
				//''''****************************************************************************
				//If grdProductIn.Columns(gccBuildAmountColumn).FooterText <> grdProductOut.Columns(gccBuildAmountColumn).FooterText Then
				//    MsgBox "Excess and Shortage Amount should be equal !", vbInformation, "Error"
				//    GoTo StationExitFunction
				//End If
				//''''****************************************************************************

				SystemVariables.gConn.BeginTransaction();

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{

					txtVoucherNo.Text = SystemProcedure2.GetNewNumber("ICS_Shortage_Excess", "voucher_no");
					mVoucherNo = Convert.ToInt32(Double.Parse(SystemProcedure2.GetNewNumber("ICS_Shortage_Excess", "voucher_no")));

					//''''*********************Insert into the Invnt Shortage_Excess table ****
					mysql = " insert into ICS_Shortage_Excess";
					mysql = mysql + "(Voucher_Date, Voucher_No, Source_Voucher_Type, Source_Voucher_No, Locat_Cd";
					mysql = mysql + ", Ldgr_Cd, Sman_Cd, Shortage_Trans_Voucher_Type, Excess_Trans_Voucher_Type";
					mysql = mysql + ", Remarks, [Status], User_Cd ";
					mysql = mysql + " ) values ( ";
					mysql = mysql + "'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
					mysql = mysql + ", " + txtVoucherNo.Text;
					mysql = mysql + ", " + ((txtSourceVoucherType.Text == "") ? "Null" : txtSourceVoucherType.Text);
					mysql = mysql + ", " + ((txtSourceVoucherNo.Text == "") ? "Null" : txtSourceVoucherNo.Text);
					mysql = mysql + ", " + mLocatCode.ToString();
					mysql = mysql + ", " + mLdgrCode.ToString();
					mysql = mysql + ", " + mSmanCode;
					mysql = mysql + ", 2002, 2001";
					mysql = mysql + ", '" + txtRemark.Text + "'";
					mysql = mysql + ", 1, " + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//''''*********************Get the New entry ID during add mode ***************
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
					SearchValue = mEntryId;
					//''''*************************************************************************
				}
				else
				{
					//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);

					//''''*********************Check the Master table TimeStamp *******************
					mysql = " select Entry_Id, time_stamp ";
					mysql = mysql + " from ICS_Shortage_Excess ";
					mysql = mysql + " where entry_id=" + Conversion.Str(mEntryId);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//if the time stamp does not match the previous one then rollback

					if (SystemProcedure2.tsFormat(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1))) != mTimeStamp)
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						goto StationRollBackTrans;
					}

					//''''*************************************************************************
					mysql = " update ICS_Shortage_Excess ";
					mysql = mysql + " set ";
					mysql = mysql + "Voucher_Date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
					mysql = mysql + ", Source_Voucher_Type = " + ((txtSourceVoucherType.Text == "") ? "Null" : txtSourceVoucherType.Text);
					mysql = mysql + ", Source_Voucher_No = " + ((txtSourceVoucherNo.Text == "") ? "Null" : txtSourceVoucherNo.Text);
					mysql = mysql + ", Locat_Cd = " + mLocatCode.ToString();
					mysql = mysql + ", Ldgr_Cd = " + mLdgrCode.ToString();
					mysql = mysql + ", Sman_cd = " + mSmanCode;
					mysql = mysql + ", Shortage_Trans_Voucher_Type = 2002";
					mysql = mysql + ", Excess_Trans_Voucher_Type = 2001";
					mysql = mysql + ", Remarks = '" + txtRemark.Text + "'";
					mysql = mysql + " where ";
					mysql = mysql + " Entry_Id = " + mEntryId.ToString();
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}

				//''*****************************************************************************
				//---------------------Append detail table for Excess--------------------------
				//''*****************************************************************************

				if (aProductInDetail.GetLength(0) > 0)
				{
					this.grdProductIn.UpdateData();
					mysql = "delete ICS_Shortage_Excess_Details ";
					mysql = mysql + " where ";
					mysql = mysql + " Entry_Id = " + mEntryId.ToString();
					mysql = mysql + " and SE_Type = 'E'";
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					int tempForEndVar = aProductInDetail.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(aProductInDetail.GetValue(cnt, gccBuildProductCodeColumn)) || Convert.ToString(aProductInDetail.GetValue(cnt, gccBuildProductCodeColumn)) == "")
						{
							MessageBox.Show("invalid Product ID", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							grdProductIn.Col = gccBuildProductCodeColumn;
							throw new Exception();
						}
						else
						{
							mysql = " select prod_cd from ICS_Item where part_no = '" + Convert.ToString(aProductInDetail.GetValue(cnt, gccBuildProductCodeColumn)) + "'";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mTempValue))
							{
								//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mProdCode = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
							}
							else
							{
								MessageBox.Show("invalid Product ID", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								grdProductIn.Col = gccBuildProductCodeColumn;
								throw new Exception();
							}

							mProdName = Convert.ToString(aProductInDetail.GetValue(cnt, gccBuildProductNameColumn));

							mysql = "select unit_entry_id from ICS_Item_Unit_Details aud";
							mysql = mysql + " inner join ICS_Unit u on aud.alt_unit_cd = u.unit_cd";
							mysql = mysql + " where u.symbol = '" + Convert.ToString(aProductInDetail.GetValue(cnt, gccBuildUnitSymbolColumn)).TrimEnd() + "'";

							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mTempValue))
							{
								//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mUnitCode = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
							}
							else
							{
								MessageBox.Show("Invalid Unit", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								grdProductIn.Col = gccBuildUnitSymbolColumn;
								throw new Exception();
							}

							mQty = Convert.ToDouble(aProductInDetail.GetValue(cnt, gccBuildQtyColumn));

							mysql = " select base_qty from ICS_Item_Unit_Details ";
							mysql = mysql + " where unit_entry_id = " + mUnitCode.ToString();
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mTempValue))
							{
								mBaseQty = ReflectionHelper.GetPrimitiveValue<double>(mTempValue) * mQty;
							}
							else
							{
								MessageBox.Show("Invalid Unit", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								grdProductIn.Col = gccBuildUnitSymbolColumn;
								throw new Exception();
							}

							mRate = Convert.ToDouble(aProductInDetail.GetValue(cnt, gccBuildRateColumn));
							mAmount = Convert.ToDouble(aProductInDetail.GetValue(cnt, gccBuildAmountColumn));

							mysql = "insert into ICS_Shortage_Excess_Details ";
							mysql = mysql + " ( Entry_Id, SE_Type, Locat_Cd, Prod_Cd,Prod_Name, Unit_Entry_ID ";
							mysql = mysql + " ,Qty, Base_Qty, FC_Rate,FC_Amount, user_cd, Comments) ";
							mysql = mysql + " values ( ";
							mysql = mysql + mEntryId.ToString() + ",";
							mysql = mysql + " 'E' ,";
							mysql = mysql + mLocatCode.ToString() + ",";
							mysql = mysql + mProdCode + ",";
							mysql = mysql + "'" + mProdName + "',";
							mysql = mysql + mUnitCode.ToString() + ",";
							mysql = mysql + mQty.ToString() + ",";
							mysql = mysql + mBaseQty.ToString() + ",";
							mysql = mysql + mRate.ToString() + ",";
							mysql = mysql + mAmount.ToString() + ",";
							mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							mysql = mysql + "'" + Convert.ToString((Convert.IsDBNull(aProductInDetail.GetValue(cnt, gccBuildRemarkColumn))) ? ((object) "") : aProductInDetail.GetValue(cnt, gccBuildRemarkColumn)) + "' )";

							SqlCommand TempCommand_4 = null;
							TempCommand_4 = SystemVariables.gConn.CreateCommand();
							TempCommand_4.CommandText = mysql;
							TempCommand_4.ExecuteNonQuery();
						}

					}
				}
				//''*****************************************************************************
				//''*****************************************************************************
				//---------------------Append detail table for Shortage--------------------------
				//''*****************************************************************************
				if (aProductOutDetail.GetLength(0) > 0)
				{
					this.grdProductOut.UpdateData();
					mysql = "delete ICS_Shortage_Excess_Details ";
					mysql = mysql + " where ";
					mysql = mysql + " Entry_Id = " + mEntryId.ToString();
					mysql = mysql + " and SE_Type = 'S'";
					SqlCommand TempCommand_5 = null;
					TempCommand_5 = SystemVariables.gConn.CreateCommand();
					TempCommand_5.CommandText = mysql;
					TempCommand_5.ExecuteNonQuery();

					int tempForEndVar2 = aProductOutDetail.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar2; cnt++)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(aProductOutDetail.GetValue(cnt, gccBuildProductCodeColumn)) || Convert.ToString(aProductOutDetail.GetValue(cnt, gccBuildProductCodeColumn)) == "")
						{
							MessageBox.Show("invalid Product ID", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							grdProductOut.Col = gccBuildProductCodeColumn;
							throw new Exception();
						}
						else
						{
							mysql = " select prod_cd from ICS_Item where part_no = '" + Convert.ToString(aProductOutDetail.GetValue(cnt, gccBuildProductCodeColumn)) + "'";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mTempValue))
							{
								//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mProdCode = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
							}
							else
							{
								MessageBox.Show("invalid Product ID", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								grdProductOut.Col = gccBuildProductCodeColumn;
								throw new Exception();
							}

							mProdName = Convert.ToString(aProductOutDetail.GetValue(cnt, gccBuildProductNameColumn));

							mysql = "select unit_entry_id from ICS_Item_Unit_Details aud";
							mysql = mysql + " inner join ICS_Unit u on aud.alt_unit_cd = u.unit_cd";
							mysql = mysql + " where u.symbol = '" + Convert.ToString(aProductOutDetail.GetValue(cnt, gccBuildUnitSymbolColumn)).TrimEnd() + "'";

							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mTempValue))
							{
								//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mUnitCode = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
							}
							else
							{
								MessageBox.Show("Invalid Unit", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								grdProductOut.Col = gccBuildUnitSymbolColumn;
								throw new Exception();
							}

							mQty = Convert.ToDouble(aProductOutDetail.GetValue(cnt, gccBuildQtyColumn));

							mysql = " select base_qty from ICS_Item_Unit_Details ";
							mysql = mysql + " where unit_entry_id = " + mUnitCode.ToString();
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mTempValue))
							{
								mBaseQty = ReflectionHelper.GetPrimitiveValue<double>(mTempValue) * mQty;
							}
							else
							{
								MessageBox.Show("Invalid Unit", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aProductOutDetail.Col was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								aProductOutDetail.setCol(gccBuildUnitSymbolColumn);
								throw new Exception();
							}

							mRate = Convert.ToDouble(aProductOutDetail.GetValue(cnt, gccBuildRateColumn));
							mAmount = Convert.ToDouble(aProductOutDetail.GetValue(cnt, gccBuildAmountColumn));

							mysql = "insert into ICS_Shortage_Excess_Details ";
							mysql = mysql + " ( Entry_Id, SE_Type, Locat_cd, Prod_Cd,Prod_Name, Unit_Entry_ID ";
							mysql = mysql + " ,Qty, Base_Qty, FC_Rate,FC_Amount, user_cd, Comments) ";
							mysql = mysql + " values ( ";
							mysql = mysql + mEntryId.ToString() + ",";
							mysql = mysql + " 'S' ,";
							mysql = mysql + mLocatCode.ToString() + ",";
							mysql = mysql + mProdCode + ",";
							mysql = mysql + "'" + mProdName + "',";
							mysql = mysql + mUnitCode.ToString() + ",";
							mysql = mysql + mQty.ToString() + ",";
							mysql = mysql + mBaseQty.ToString() + ",";
							mysql = mysql + mRate.ToString() + ",";
							mysql = mysql + mAmount.ToString() + ",";
							mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							mysql = mysql + "'" + Convert.ToString((Convert.IsDBNull(aProductOutDetail.GetValue(cnt, gccBuildRemarkColumn))) ? ((object) "") : aProductOutDetail.GetValue(cnt, gccBuildRemarkColumn)) + "' )";

							SqlCommand TempCommand_6 = null;
							TempCommand_6 = SystemVariables.gConn.CreateCommand();
							TempCommand_6.CommandText = mysql;
							TempCommand_6.ExecuteNonQuery();
						}

					}
				}
				//''*****************************************************************************
				GenerateExcess();
				GenerateShortages();
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();



				//''''*************************************************************************
				//Display a messbox if the auto generate voucher no is true and it is in addmode
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = SystemConstants.msg20 + txtVoucherNo.Text;
					MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}


				return true;

				//''''*************************************************************************
				StationExitFunction:
				//This code is executed when there is error before begin trans
				return false;
				//''''*************************************************************************

				//''''*************************************************************************
				StationRollBackTrans:
				//This code is executed when there is error after begin trans
				result = false;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
			}
			catch (System.Exception excep)
			{
				//''''*************************************************************************

				//''''*************************************************************************
				//All other Errors.
				int mReturnErrorType = 0;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, "ICSExcessShortage", "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				if (mReturnErrorType == 1)
				{
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					AddRecord();
					result = false;
				}
				else if (mReturnErrorType == 3)
				{ 
					AddRecord();
					result = false;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		public object GenerateExcess()
		{

			int mProdCode = 0;
			string mProdName = "";
			int mUnitCode = 0;
			int mUnitEntryId = 0;
			double mRate = 0;
			double mAmount = 0;
			double mQty = 0;

			double mBaseQty = 0;
			int mVoucherNo = 0;
			string mysql = "";
			double mNetAmt = 0;
			int mEntryId = 0;
			int cnt = 0;


			oClsInvntTrans = new clsInvntTransaction();

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select Excess_Trans_Entry_Id from ICS_Shortage_Excess where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue)));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempValue))
			{
				mysql = "update ICS_Shortage_Excess set Excess_Trans_Entry_Id = null";
				mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				oClsInvntTrans.EntryID = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
				oClsInvntTrans.DeleteTransaction();
			}
			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mVoucherType = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Auto_Generate_Excess_Voucher_Type"));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			int tempForEndVar = 0;
			if (Convert.IsDBNull(mVoucherType))
			{
				MessageBox.Show("Invalid Preference setting for excess voucher type!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			else
			{

				mysql = "select max(voucher_no) from ICS_Transaction ";
				mysql = mysql + " where voucher_type = " + mVoucherType.ToString();
				mysql = mysql + " and locat_cd = " + mLocatCode.ToString();
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mVoucherNo = (Convert.IsDBNull(SystemProcedure2.GetMasterCode(mysql))) ? 0 : ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));
				mVoucherNo++;

				mNetAmt = Double.Parse(this.grdProductIn.Columns[gccBuildAmountColumn].FooterText);

				oClsInvntTrans.EntryID = 0;
				oClsInvntTrans.VoucherType = mVoucherType;
				oClsInvntTrans.Locat_Cd = mLocatCode;
				//UPGRADE_WARNING: (1068) txtVoucherDate.Value of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				oClsInvntTrans.Voucher_Date = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value);
				oClsInvntTrans.Voucher_No = mVoucherNo;
				oClsInvntTrans.Voucher_Amt_FC = mNetAmt;
				oClsInvntTrans.Status = 4;
				oClsInvntTrans.UserCd = SystemVariables.gLoggedInUserCode;

				oClsInvntTrans.saveInvntMasterRecord();

				//'mySQL = " insert into ICS_Transaction "
				//'mySQL = mySQL & "(Voucher_Type, Locat_Cd, Voucher_Date, Voucher_No"
				//'mySQL = mySQL & ", Voucher_Amt_FC, Status, User_Cd"
				//'mySQL = mySQL & " ) values ( "
				//'mySQL = mySQL & mVoucherType
				//'mySQL = mySQL & ", " & mLocatCode
				//'mySQL = mySQL & ", '" & txtVoucherDate.Value & "'"
				//'mySQL = mySQL & ", " & mVoucherNo
				//'mySQL = mySQL & ", " & mNetAmt & ""
				//'mySQL = mySQL & ", 4, " & Str(gLoggedInUserCode)
				//'mySQL = mySQL & " )"
				//'gConn.Execute (mySQL)

				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));

				//-----------------------Append Detail Record-----------------------
				//------------------------------------------------------------------
				tempForEndVar = aProductInDetail.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{

					mysql = " select prod_cd from ICS_Item where part_no = '" + Convert.ToString(aProductInDetail.GetValue(cnt, gccBuildProductCodeColumn)) + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mProdCode = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));

					mProdName = Convert.ToString(aProductInDetail.GetValue(cnt, gccBuildProductNameColumn));

					mysql = " select unit_cd from ICS_Unit where symbol = '" + Convert.ToString(aProductInDetail.GetValue(cnt, gccBuildUnitSymbolColumn)) + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mUnitCode = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mUnitEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select unit_entry_id from ICS_Item_Unit_Details where prod_cd = " + mProdCode.ToString() + " and alt_unit_cd =" + mUnitCode.ToString()));
					mQty = Convert.ToDouble(aProductInDetail.GetValue(cnt, gccBuildQtyColumn));

					mysql = " select base_qty from ICS_Item_Unit_Details where prod_cd = " + mProdCode.ToString();
					mysql = mysql + " and Alt_Unit_cd = " + mUnitCode.ToString();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					mBaseQty = ReflectionHelper.GetPrimitiveValue<double>(mTempValue) * mQty;

					mRate = Convert.ToDouble(aProductInDetail.GetValue(cnt, gccBuildRateColumn));
					mAmount = Convert.ToDouble(aProductInDetail.GetValue(cnt, gccBuildAmountColumn));

					oClsInvntTrans.EntryID = mEntryId;
					oClsInvntTrans.Add_Locat_Cd = mLocatCode;
					oClsInvntTrans.Prod_Cd = mProdCode;
					oClsInvntTrans.Prod_Name = mProdName;
					oClsInvntTrans.Unit_Entry_ID = mUnitEntryId;
					oClsInvntTrans.Qty = mQty;
					oClsInvntTrans.Base_Qty = mBaseQty;
					oClsInvntTrans.FC_Rate = mRate;
					oClsInvntTrans.FC_Amount = mAmount;
					oClsInvntTrans.Item_Type_Cd = 1;

					oClsInvntTrans.saveInvntDetailRecord();
					//        mySql = "insert into ICS_Transaction_Details "
					//        mySql = mySql & " ( Entry_Id, Add_Locat_Cd, Prod_Cd,Prod_Name, Unit_Entry_ID "
					//        mySql = mySql & " ,Qty, Base_Qty, FC_Rate,FC_Amount, Item_Type_Cd) "
					//        mySql = mySql & " values ( "
					//        mySql = mySql & mEntryID
					//        mySql = mySql & ", " & mLocatCode
					//        mySql = mySql & "," & mProdCode
					//        mySql = mySql & ", '" & mProdName & "'"
					//        mySql = mySql & "," & mUnitEntryId
					//        mySql = mySql & "," & mQty
					//        mySql = mySql & "," & mBaseQty
					//        mySql = mySql & "," & mRate
					//        mySql = mySql & "," & mAmount & ", 1 )"

					//        gConn.Execute (mySql)

				}

				oClsInvntTrans.PostTransactionToIcs();

				mysql = " update ICS_Shortage_Excess set Excess_Trans_Voucher_Type = " + mVoucherType.ToString();
				mysql = mysql + ", Excess_Trans_Entry_Id = " + mEntryId.ToString();
				mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

			}

			//
			return null;
		}


		public object GenerateShortages()
		{

			string mProdCode = "";
			string mProdName = "";
			int mUnitCode = 0;
			int mUnitEntryId = 0;
			double mRate = 0;
			double mAmount = 0;
			double mQty = 0;

			double mBaseQty = 0;
			int mVoucherNo = 0;
			string mysql = "";
			double mNetAmt = 0;
			int mEntryId = 0;
			int cnt = 0;

			oClsInvntTrans = new clsInvntTransaction();

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select Shortage_Trans_Entry_Id from ICS_Shortage_Excess where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue)));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempValue))
			{
				mysql = "update ICS_Shortage_Excess set Shortage_Trans_Entry_Id = null";
				mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				oClsInvntTrans.EntryID = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
				oClsInvntTrans.DeleteTransaction();

			}
			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mVoucherType = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Auto_Generate_Shortage_Voucher_Type"));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			int tempForEndVar = 0;
			if (Convert.IsDBNull(mVoucherType))
			{
				MessageBox.Show("Invalid Preference setting for excess voucher type!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			else
			{

				mysql = "select max(voucher_no) from ICS_Transaction ";
				mysql = mysql + " where voucher_type = " + mVoucherType.ToString();
				mysql = mysql + " and locat_cd = " + mLocatCode.ToString();

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mVoucherNo = (Convert.IsDBNull(SystemProcedure2.GetMasterCode(mysql))) ? 0 : ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));
				mVoucherNo++;

				mNetAmt = Double.Parse(this.grdProductOut.Columns[gccBuildAmountColumn].FooterText);

				oClsInvntTrans.EntryID = 0;
				oClsInvntTrans.VoucherType = mVoucherType;
				oClsInvntTrans.Locat_Cd = mLocatCode;
				//UPGRADE_WARNING: (1068) txtVoucherDate.Value of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				oClsInvntTrans.Voucher_Date = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value);
				oClsInvntTrans.Voucher_No = mVoucherNo;
				oClsInvntTrans.Voucher_Amt_FC = mNetAmt;
				oClsInvntTrans.Status = 4;
				oClsInvntTrans.UserCd = SystemVariables.gLoggedInUserCode;

				oClsInvntTrans.saveInvntMasterRecord();
				//oClsInvntTrans = Nothing
				//'mySQL = " insert into ICS_Transaction "
				//'mySQL = mySQL & "(Voucher_Type, Locat_Cd, Voucher_Date, Voucher_No"
				//'mySQL = mySQL & ", Voucher_Amt_FC, Status, User_Cd"
				//'mySQL = mySQL & " ) values ( "
				//'mySQL = mySQL & mVoucherType
				//'mySQL = mySQL & ", " & mLocatCode
				//'mySQL = mySQL & ", '" & txtVoucherDate.Value & "'"
				//'mySQL = mySQL & ", " & mVoucherNo
				//'mySQL = mySQL & ", " & mNetAmt & ""
				//'mySQL = mySQL & ", 4, " & Str(gLoggedInUserCode)
				//'mySQL = mySQL & " )"
				//'gConn.Execute (mySQL)

				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));

				//-----------------------Append Detail Record-----------------------
				//------------------------------------------------------------------
				tempForEndVar = aProductOutDetail.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{

					mysql = " select prod_cd from ICS_Item where part_no = '" + Convert.ToString(aProductOutDetail.GetValue(cnt, gccBuildProductCodeColumn)) + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mProdCode = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode(mysql));

					mProdName = Convert.ToString(aProductOutDetail.GetValue(cnt, gccBuildProductNameColumn));

					mysql = " select unit_cd from ICS_Unit where symbol = '" + Convert.ToString(aProductOutDetail.GetValue(cnt, gccBuildUnitSymbolColumn)) + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mUnitCode = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mUnitEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select unit_entry_id from ICS_Item_Unit_Details where prod_cd = " + mProdCode + " and alt_unit_cd =" + mUnitCode.ToString()));
					mQty = Convert.ToDouble(aProductOutDetail.GetValue(cnt, gccBuildQtyColumn));

					mysql = " select base_qty from ICS_Item_Unit_Details where prod_cd = " + mProdCode;
					mysql = mysql + " and Alt_Unit_cd = " + mUnitCode.ToString();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					mBaseQty = ReflectionHelper.GetPrimitiveValue<double>(mTempValue) * mQty;

					mRate = Convert.ToDouble(aProductOutDetail.GetValue(cnt, gccBuildRateColumn));
					mAmount = Convert.ToDouble(aProductOutDetail.GetValue(cnt, gccBuildAmountColumn));

					oClsInvntTrans.EntryID = mEntryId;
					oClsInvntTrans.Less_Locat_Cd = mLocatCode;
					oClsInvntTrans.Prod_Cd = Convert.ToInt32(Double.Parse(mProdCode));
					oClsInvntTrans.Prod_Name = mProdName;
					oClsInvntTrans.Unit_Entry_ID = mUnitEntryId;
					oClsInvntTrans.Qty = mQty;
					oClsInvntTrans.Base_Qty = mBaseQty;
					oClsInvntTrans.FC_Rate = mRate;
					oClsInvntTrans.FC_Amount = mAmount;
					oClsInvntTrans.Item_Type_Cd = 1;

					oClsInvntTrans.saveInvntDetailRecord();

					//        mySql = "insert into ICS_Transaction_Details "
					//        mySql = mySql & " ( Entry_Id, Less_Locat_Cd, Prod_Cd,Prod_Name, Unit_Entry_ID "
					//        mySql = mySql & " ,Qty, Base_Qty, FC_Rate,FC_Amount, Item_Type_Cd) "
					//        mySql = mySql & " values ( "
					//        mySql = mySql & mEntryID
					//        mySql = mySql & ", " & mLocatCode
					//        mySql = mySql & "," & mProdCode
					//        mySql = mySql & ", '" & mProdName & "'"
					//        mySql = mySql & "," & mUnitEntryId
					//        mySql = mySql & "," & mQty
					//        mySql = mySql & "," & mBaseQty
					//        mySql = mySql & "," & mRate
					//        mySql = mySql & "," & mAmount & ", 1 )"

					//        gConn.Execute (mySql)

				}

				oClsInvntTrans.PostTransactionToIcs();

				mysql = " update ICS_Shortage_Excess set Shortage_Trans_Voucher_Type = " + mVoucherType.ToString();
				mysql = mysql + ", Shortage_Trans_Entry_Id = " + mEntryId.ToString();
				mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

			}

			//
			return null;
		}

		public void AddRecord()
		{
			try
			{

				int cnt = 0;

				//''''*************************************************************************
				//Set the form caption
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, "Item Exchange", "Transaction");
				//''''*************************************************************************

				//''''*************************************************************************
				//'''Grid settings
				int tempForEndVar = grdProductIn.Columns.Count - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					grdProductIn.Columns[cnt].FooterText = "";
				}

				RefreshRecordset(false);
				SystemGrid.DefineVoucherArray(aProductInDetail, mMaxArrayCols, -1, true);
				grdProductIn.Rebind(true);

				int tempForEndVar2 = grdProductOut.Columns.Count - 1;
				for (cnt = 0; cnt <= tempForEndVar2; cnt++)
				{
					grdProductOut.Columns[cnt].FooterText = "";
				}
				RefreshRecordset(false);
				SystemGrid.DefineVoucherArray(aProductOutDetail, mMaxArrayCols, -1, true);
				grdProductOut.Rebind(true);
				//''''*************************************************************************


				SystemProcedure2.ClearTextBox(this);

				//.txtCommonTextBox(tcProductCode).Enabled = True
				//.txtCommonTextBox(tcLocationCode).Enabled = True

				this.txtVoucherDate.Value = SystemVariables.gCurrentDate;
				this.txtVoucherDate.Enabled = true;

				ClearStatusBar();
				SearchValue = ""; //Change the msearchvalue to blank

				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive; //set new voucher status to active by default
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, "ICSExcessShortage", "AddRecord");
			}



		}

		private void CalculateTotals(string grdName, int mRowNumber, int mColNumber)
		{
			int cnt = 0;
			double mCashAmt = 0;

			if (grdName == "grdProductIn")
			{
				int tempForEndVar = aProductInDetail.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					if (SystemProcedure2.IsItEmpty(aProductInDetail.GetValue(cnt, gccBuildAmountColumn), SystemVariables.DataType.NumberType))
					{
						aProductInDetail.SetValue("", cnt, gccBuildAmountColumn);
					}

					aProductInDetail.SetValue(aProductInDetail.GetValue(cnt, gccBuildAmountColumn), cnt, gccBuildAmountColumn);
					mCashAmt += Conversion.Val(Convert.ToString(aProductInDetail.GetValue(cnt, gccBuildAmountColumn)));
				}

				if (!SystemProcedure2.IsItEmpty(mCashAmt, SystemVariables.DataType.NumberType))
				{
					grdProductIn.Columns[gccBuildAmountColumn].FooterText = StringsHelper.Format(mCashAmt, "###,###,###.000");
				}
				else
				{
					grdProductIn.Columns[gccBuildAmountColumn].FooterText = "";
				}
			}
			else
			{
				int tempForEndVar2 = aProductOutDetail.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar2; cnt++)
				{
					if (SystemProcedure2.IsItEmpty(aProductOutDetail.GetValue(cnt, gccBuildAmountColumn), SystemVariables.DataType.NumberType))
					{
						aProductOutDetail.SetValue("", cnt, gccBuildAmountColumn);
					}

					aProductOutDetail.SetValue(aProductOutDetail.GetValue(cnt, gccBuildAmountColumn), cnt, gccBuildAmountColumn);
					mCashAmt += Conversion.Val(Convert.ToString(aProductOutDetail.GetValue(cnt, gccBuildAmountColumn)));
				}

				if (!SystemProcedure2.IsItEmpty(mCashAmt, SystemVariables.DataType.NumberType))
				{
					grdProductOut.Columns[gccBuildAmountColumn].FooterText = StringsHelper.Format(mCashAmt, "###,###,###.000");
				}
				else
				{
					grdProductOut.Columns[gccBuildAmountColumn].FooterText = "";
				}
			}
		}

		public void findRecord()
		{

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2008020));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				Application.DoEvents();
				GetRecord(mSearchValue);
			}
		}

		public void GetRecord(object pSearchValue)
		{


			if (SystemProcedure2.IsItEmpty(pSearchValue, SystemVariables.DataType.NumberType))
			{
				return;
			}

			string mysql = " select mt.*, l.Locat_No, l.l_locat_name, l.A_locat_name, gl.ldgr_no, gl.L_Ldgr_Name";
			mysql = mysql + ", gl.A_Ldgr_Name, s.sman_no, s.l_sman_name, s.a_sman_name ";
			mysql = mysql + " from ics_shortage_excess mt ";
			mysql = mysql + " inner join SM_Location l on mt.Locat_Cd = l.Locat_Cd";
			mysql = mysql + " left outer join gl_ledger gl on mt.Ldgr_Cd = gl.ldgr_Cd";
			mysql = mysql + " inner join SM_Salesman s on mt.sman_cd = s.sman_cd";
			mysql = mysql + " where mt.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

			SqlDataReader rsLocalRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			if (rsLocalRec.Read())
			{
				CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				SearchValue = rsLocalRec["entry_id"];
				mRecordNavigateSearchValue = Convert.ToInt32(rsLocalRec["entry_id"]);
				mTimeStamp = SystemProcedure2.tsFormat(Convert.ToString(rsLocalRec["time_stamp"]));

				//        'Set the form caption and Get the Voucher Status
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, Convert.ToInt32(rsLocalRec["status"]), CurrentFormMode, "Item Exchange", "Transaction");
				//        '''''*************************************************************************
				//
				txtVoucherNo.Text = Convert.ToString(rsLocalRec["voucher_no"]);
				txtVoucherDate.Value = rsLocalRec["voucher_date"];
				txtSourceVoucherType.Text = (Convert.IsDBNull(rsLocalRec["Source_Voucher_Type"])) ? "" : Convert.ToString(rsLocalRec["Source_Voucher_Type"]);
				txtSourceVoucherNo.Text = (Convert.IsDBNull(rsLocalRec["Source_Voucher_No"])) ? "" : Convert.ToString(rsLocalRec["Source_Voucher_No"]);
				txtLocation.Text = Convert.ToString(rsLocalRec["Locat_No"]) + "";
				txtLocDisplayLabel.Text = Convert.ToString(rsLocalRec["l_locat_name"]) + "";
				txtLdgrCode.Text = Convert.ToString(rsLocalRec["Ldgr_No"]) + "";
				txtLedgerName.Text = Convert.ToString(rsLocalRec["l_ldgr_name"]) + "";
				txtSalesman.Text = Convert.ToString(rsLocalRec["sman_no"]) + "";
				txtSmanDisplayLabel.Text = Convert.ToString(rsLocalRec["l_sman_name"]) + "";
				txtRemark.Text = Convert.ToString(rsLocalRec["Remarks"]) + "";

				GetShortageExcessDetails(Convert.ToInt32(rsLocalRec["entry_id"]));

			}
		}


		private void GetShortageExcessDetails(int pEntryId)
		{
			SqlDataReader localRec = null;
			int cnt = 0;

			//''-------------------------------Excess Grid---------------------------------
			string mysql = "select  dt.se_type, dt.prod_cd, p.part_no, dt.prod_name, l.Locat_No";
			mysql = mysql + " , dt.unit_entry_id, u.symbol, dt.qty, dt.fc_rate, dt.fc_amount, dt.Comments ";
			mysql = mysql + " from ICS_Item p ";
			mysql = mysql + " INNER JOIN ics_shortage_excess_details dt on p.prod_cd = dt.prod_cd ";
			mysql = mysql + " INNER JOIN ICS_Item_Unit_Details aud on dt.unit_entry_id = aud.Unit_Entry_Id";
			mysql = mysql + " INNER JOIN ICS_Unit u on aud.alt_unit_cd = u.unit_cd ";
			mysql = mysql + " INNER join SM_Location l on dt.Locat_Cd = l.Locat_Cd";
			mysql = mysql + " Where dt.SE_Type = 'E' and dt.entry_id=" + Conversion.Str(pEntryId);

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand.ExecuteReader();
			localRec.Read();

			do 
			{
				aProductInDetail.RedimXArray(new int[]{cnt, mMaxArrayCols}, new int[]{0, 0});

				aProductInDetail.SetValue(cnt + 1, cnt, gccBuildLineNoColumn);

				aProductInDetail.SetValue(localRec["Part_No"], cnt, gccBuildProductCodeColumn);
				aProductInDetail.SetValue(localRec["Prod_Name"], cnt, gccBuildProductNameColumn);
				aProductInDetail.SetValue(localRec["Locat_No"], cnt, gccBuildProductLocColumn);
				aProductInDetail.SetValue(localRec["symbol"], cnt, gccBuildUnitSymbolColumn);
				aProductInDetail.SetValue(localRec["Qty"], cnt, gccBuildQtyColumn);
				aProductInDetail.SetValue(localRec["FC_Rate"], cnt, gccBuildRateColumn);
				aProductInDetail.SetValue(StringsHelper.Format(Conversion.Val(Convert.ToString(localRec["FC_Amount"])), "###,###,###,###,##0.000"), cnt, gccBuildAmountColumn);
				aProductInDetail.SetValue(localRec["Comments"], cnt, gccBuildRemarkColumn);

				cnt++;
			}
			while(localRec.Read());
			localRec.Close();
			this.grdProductIn.Rebind(true);

			CalculateTotals("grdProductIn", 0, 0);

			//------------------------------------Shortage Grid------------------------------------
			mysql = "select  dt.se_type, dt.prod_cd, p.part_no, dt.prod_name, l.Locat_No";
			mysql = mysql + " , dt.unit_entry_id, u.symbol, dt.qty, dt.fc_rate, dt.fc_amount, dt.Comments ";
			mysql = mysql + " from ICS_Item p ";
			mysql = mysql + " INNER JOIN ics_shortage_excess_details dt on p.prod_cd = dt.prod_cd ";
			mysql = mysql + " INNER JOIN ICS_Item_Unit_Details aud on dt.unit_entry_id = aud.Unit_Entry_Id";
			mysql = mysql + " INNER JOIN ICS_Unit u on aud.alt_unit_cd = u.unit_cd ";
			mysql = mysql + " inner join SM_Location l on dt.Locat_Cd = l.Locat_Cd";
			mysql = mysql + " Where dt.SE_Type = 'S' and dt.entry_id=" + Conversion.Str(pEntryId);

			SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand_2.ExecuteReader();
			bool localRecDidRead2 = localRec.Read();
			cnt = 0;
			do 
			{
				aProductOutDetail.RedimXArray(new int[]{cnt, mMaxArrayCols}, new int[]{0, 0});

				aProductOutDetail.SetValue(cnt + 1, cnt, gccBuildLineNoColumn);

				aProductOutDetail.SetValue(localRec["Part_No"], cnt, gccBuildProductCodeColumn);
				aProductOutDetail.SetValue(localRec["Prod_Name"], cnt, gccBuildProductNameColumn);
				aProductOutDetail.SetValue(localRec["Locat_No"], cnt, gccBuildProductLocColumn);
				aProductOutDetail.SetValue(localRec["symbol"], cnt, gccBuildUnitSymbolColumn);
				aProductOutDetail.SetValue(localRec["Qty"], cnt, gccBuildQtyColumn);
				aProductOutDetail.SetValue(localRec["FC_Rate"], cnt, gccBuildRateColumn);
				aProductOutDetail.SetValue(StringsHelper.Format(Conversion.Val(Convert.ToString(localRec["FC_Amount"])), "###,###,###,###,##0.000"), cnt, gccBuildAmountColumn);
				aProductInDetail.SetValue(localRec["Comments"], cnt, gccBuildRemarkColumn);

				cnt++;
			}
			while(localRec.Read());
			localRec.Close();
			this.grdProductOut.Rebind(true);

			CalculateTotals("grdProductOut", 0, 0);
		}

		public bool deleteRecord()
		{
			bool result = false;
			object mExcessEntryId = null;
			object mShortageEntryId = null;
			string mysql = "";

			try
			{

				if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
				{
					SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 1);
					result = false;
					if (FirstFocusObject.Enabled)
					{
						FirstFocusObject.Focus();
					}
					return result;
				}

				SystemVariables.gConn.BeginTransaction();
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(SearchValue))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mExcessEntryId = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select Excess_Trans_Entry_Id from ICS_Shortage_Excess where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue)));
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mShortageEntryId = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select Shortage_Trans_Entry_Id from ICS_Shortage_Excess where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue)));

					//----------------------------------Delete Master Transaction------------------------------------
					mysql = "delete ICS_Shortage_Excess_Details where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mysql = "delete ICS_Shortage_Excess where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

					//---------------------------------Delete Excess Autogenerate voucher---------------------------------------
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mExcessEntryId))
					{

						mysql = " delete ICS_Transaction_Details";
						mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mExcessEntryId);
						SqlCommand TempCommand_3 = null;
						TempCommand_3 = SystemVariables.gConn.CreateCommand();
						TempCommand_3.CommandText = mysql;
						TempCommand_3.ExecuteNonQuery();

						mysql = " delete ICS_Transaction ";
						mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mExcessEntryId);
						SqlCommand TempCommand_4 = null;
						TempCommand_4 = SystemVariables.gConn.CreateCommand();
						TempCommand_4.CommandText = mysql;
						TempCommand_4.ExecuteNonQuery();

					}
					//---------------------------------Delete Shortage Autogenerate voucher---------------------------------------
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mShortageEntryId))
					{

						mysql = " delete ICS_Transaction_Details";
						mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mShortageEntryId);
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();

						mysql = " delete ICS_Transaction ";
						mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mShortageEntryId);
						SqlCommand TempCommand_6 = null;
						TempCommand_6 = SystemVariables.gConn.CreateCommand();
						TempCommand_6.CommandText = mysql;
						TempCommand_6.ExecuteNonQuery();

					}


				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				return true;
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, "ICSExcessShortage", "GetRecord", SystemConstants.msg10);
			}
			return result;
		}

		public void MRoutine()
		{

			if (!UserAccess.AllowUserDisplay)
			{
				MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			RecordNavidate(37, mRecordNavigateSearchValue);

		}

		public void ORoutine()
		{

			if (!UserAccess.AllowUserDisplay)
			{
				MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			RecordNavidate(39, mRecordNavigateSearchValue);

		}

		private void RecordNavidate(int pKeyCode, int pEntryId)
		{

			string mysql = " select top 1 Entry_Id from ICS_Shortage_Excess ";
			mysql = mysql + " where 1=1 ";
			if (pEntryId > 0 && pKeyCode == 37)
			{
				mysql = mysql + " and Entry_Id < " + pEntryId.ToString();
			}
			else if (pEntryId > 0 && pKeyCode == 39)
			{ 
				mysql = mysql + " and Entry_Id > " + pEntryId.ToString();
			}

			if (pKeyCode == 37)
			{
				mysql = mysql + " order by Entry_Id desc ";
			}
			else if (pKeyCode == 39)
			{ 
				mysql = mysql + " order by Entry_Id asc ";
			}

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				GetRecord(mReturnValue);
			}

		}

		public void LRoutine()
		{
			if (ActiveControl.Name == "grdProductIn")
			{
				if (aProductInDetail.GetLength(0) > 0)
				{
					grdProductIn.Delete();
					grdProductIn.Rebind(true);
					grdProductIn.Focus();
					grdProductIn.Refresh();
				}
			}
			else if (ActiveControl.Name == "grdProductOut")
			{ 
				if (aProductOutDetail.GetLength(0) > 0)
				{
					grdProductOut.Delete();
					grdProductOut.Rebind(true);
					grdProductOut.Focus();
					grdProductOut.Refresh();
				}
			}
		}


		private void txtSourceVoucherType_DropButtonClick(Object Sender, EventArgs e)
		{
			txtSourceVoucherType.Text = "";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(100, "712"));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtSourceVoucherType.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
			}
		}

		public bool Post()
		{
			bool result = false;
			frmSysOnlinePosting frmTemp = null;
			try
			{

				frmTemp = null;
				frmTemp = frmSysOnlinePosting.CreateInstance();
				string mysql = "";

				if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
				{
					SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 2);
					result = false;
					if (FirstFocusObject.Enabled)
					{
						FirstFocusObject.Focus();
					}
					return result;
				}

				saveRecord();

				frmTemp.ShowDialog();

				SystemVariables.gConn.BeginTransaction();

				if (frmTemp.mApprove)
				{

					mysql = " update ICS_Shortage_Excess";
					mysql = mysql + " set Status = 2";
					mysql = mysql + " where Entry_Id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					PostExcessShortage();
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
			}
			catch (System.Exception excep)
			{


				result = false;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, "ICSExcessShortage", "GetRecord", SystemConstants.msg10);

			}
			finally
			{
				frmTemp.Close();
			}

			return result;
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
			SystemReports.GetCrystalReport(100060236, 2, "10222", Conversion.Str(mEntryId), false);
		}
		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtLdgrCode" : 
					txtLdgrCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2")); 
					 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLdgrCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtLdgrCode_Leave(txtLdgrCode, new EventArgs());
					} 
					break;
				case "txtLocation" : 
					txtLocation.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2004000, "82")); 
					 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLocation.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtLocation_Leave(txtLocation, new EventArgs());
					} 
					break;
				case "txtSalesman" : 
					txtSalesman.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1004000, "88")); 
					 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtSalesman.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtSalesman_Leave(txtSalesman, new EventArgs());
					} 
					break;
				case "txtSourceVoucherType" : 
					txtSourceVoucherType.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(100, "712")); 
					 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtSourceVoucherType.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					} 
					break;
				default:
					return;
			}
		}
		public object PostExcessShortage()
		{

			oClsInvntTrans = new clsInvntTransaction();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select Excess_Trans_Entry_Id from ICS_Shortage_Excess where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue)));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempValue))
			{
				//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				oClsInvntTrans.EntryID = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);

				oClsInvntTrans.PostTransactionToGLParty();
				oClsInvntTrans.PostTransactionToGLExpenses();
				oClsInvntTrans.PostTransactionToGLInventory();
				oClsInvntTrans.PostTransactionToGL();
			}

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select Shortage_Trans_Entry_Id from ICS_Shortage_Excess where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue)));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempValue))
			{
				//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				oClsInvntTrans.EntryID = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);

				oClsInvntTrans.PostTransactionToGLParty();
				oClsInvntTrans.PostTransactionToGLExpenses();
				oClsInvntTrans.PostTransactionToGLInventory();
				oClsInvntTrans.PostTransactionToGL();
			}
			return null;
		}
		private void FetchDetailsFromPartNoInGrid(string pPartNo, string pProdName)
		{

			if (this.ActiveControl.Name == "grdProductIn")
			{
				grdProductIn.Columns[gccBuildProductCodeColumn].Value = pPartNo;
				grdProductIn.Columns[gccBuildProductNameColumn].Value = pProdName;

				cmbMastersList_DropDownClose(cmbMastersList, new EventArgs());
				grdProductIn_AfterColUpdate(grdProductIn, new C1.Win.C1TrueDBGrid.ColEventArgs());

			}
			else if (this.ActiveControl.Name == "grdProductOut")
			{ 
				grdProductOut.Columns[gccBuildProductCodeColumn].Value = pPartNo;
				grdProductOut.Columns[gccBuildProductNameColumn].Value = pProdName;

				cmbMastersListOut_DropDownClose(cmbMastersListOut, new EventArgs());
				grdProductOut_AfterColUpdate(grdProductOut, new C1.Win.C1TrueDBGrid.ColEventArgs());
			}

		}

		public void CloseForm()
		{
			this.Close();
		}


		public void CreateStatusBar()
		{

			CommandBars.ActiveMenuBar.Visible = false;
			UCStatusBar = (XtremeCommandBars.StatusBar) CommandBars.StatusBar;

			UCStatusBar.Visible = true;
			XtremeCommandBars.StatusBarPane Pane = null;
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Base_Unit_In_Status"]))
			{
				Pane = UCStatusBar.AddPane(SystemICSConstants.lcBaseUnit1);
				Pane.Visible = true;
				Pane.Text = "Base Unit :";
				Pane.SetPadding(8, 0, 8, 0);

				Pane = UCStatusBar.AddPane(SystemICSConstants.lcBaseUnit2);
				Pane.Visible = true;
				Pane.Text = "";
				Pane.Width = 50;
				Pane.SetPadding(8, 0, 8, 0);
			}

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Stock_In_Hand_In_Status"]))
			{
				Pane = UCStatusBar.AddPane(SystemICSConstants.lcStockInHand1);
				Pane.Visible = true;
				Pane.Text = "Stock In Hand :";
				Pane.SetPadding(8, 0, 8, 0);

				Pane = UCStatusBar.AddPane(SystemICSConstants.lcStockInHand2);
				Pane.Visible = true;
				Pane.Text = "";
				Pane.Width = 70;
				Pane.SetPadding(8, 0, 8, 0);
			}

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Stock_Allocated_In_Status"]))
			{
				Pane = UCStatusBar.AddPane(SystemICSConstants.lcStockAllocated1);
				Pane.Visible = true;
				Pane.Text = "Stock Allocated :";
				Pane.SetPadding(8, 0, 8, 0);

				Pane = UCStatusBar.AddPane(SystemICSConstants.lcStockAllocated2);
				Pane.Visible = true;
				Pane.Text = "";
				Pane.Width = 70;
				Pane.SetPadding(8, 0, 8, 0);
			}

			//'    If rsVoucherTypes("Show_In_Transit_Stock_In_Status") = True Then
			//'        Set Pane = UCStatusBar.AddPane(lcStockInTransit1)
			//'        Pane.Visible = True
			//'        Pane.Text = "Stock In Transit :"
			//'        Pane.SetPadding 8, 0, 8, 0
			//'
			//'        Set Pane = UCStatusBar.AddPane(lcStockInTransit2)
			//'        Pane.Visible = True
			//'        Pane.Text = ""
			//'        Pane.Width = 70
			//'        Pane.SetPadding 8, 0, 8, 0
			//'    End If
			//'
			//'    If rsVoucherTypes("Show_Stock_Available_In_Status") = True Then
			//'        Set Pane = UCStatusBar.AddPane(lcStockAvailable1)
			//'        Pane.Visible = True
			//'        Pane.Text = "Stock Available :"
			//'        Pane.SetPadding 8, 0, 8, 0
			//'
			//'        Set Pane = UCStatusBar.AddPane(lcStockAvailable2)
			//'        Pane.Visible = True
			//'        Pane.Text = ""
			//'        Pane.Width = 70
			//'        Pane.SetPadding 8, 0, 8, 0
			//'    End If

		}
		public void ClearStatusBar()
		{
			UCStatusBar.FindPane(SystemICSConstants.lcBaseUnit2).Text = "";
			UCStatusBar.FindPane(SystemICSConstants.lcStockInHand2).Text = "";
			//UCStatusBar.FindPane(lcStockAllocated2).Text = ""
			//UCStatusBar.FindPane(lcStockInTransit2).Text = ""
			//UCStatusBar.FindPane(lcStockAvailable2).Text = ""
		}
	}
}