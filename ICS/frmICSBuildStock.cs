
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmICSBuildStock
		: System.Windows.Forms.Form
	{



		private clsAccessAllowed _UserAccess = null;
		public frmICSBuildStock()
{
InitializeComponent();
} 
 public  void frmICSBuildStock_old()
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

		public int ThisVoucherType = 0;

		private frmICSAdditionalVoucherDetails objAdditionalDetails = null;
		private bool objAdditionalDetailsInitialised = false;

		private XArrayHelper aVoucherDetails = null;
		private bool mFirstGridFocus = false;
		private Control FirstFocusObject = null;
		private clsToolbar oThisFormToolBar = null;

		private DataSet rsProductCodeList = null;
		private DataSet rsComponentSerialNo = null;
		private DataSet rsAssemblySerialNo = null;

		private int mBuildType = 0;
		private int mHeaderVoucherType = 0;
		private int mDetailVoucherType = 0;


		private string mTimeStamp = "";
		private string mProductAssemblyTimeStamp = "";
		private bool mPostedToGLStatus = false;
		private bool mPostedToICSStatus = false;
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;

		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		private int mThisFormID = 0;

		private const int mMaxArrayCols = 10;

		private const int gccBuildLineNoColumn = 0;
		private const int gccBuildProductCodeColumn = 1;
		//Private Const gccItemTypeColumn  As Integer = 2
		private const int gccBuildProductNameColumn = 2;
		private const int gccBuildUnitSymbolColumn = 3;
		private const int gccBuildQtyColumn = 4;
		private const int gccBuildBuildCostColumn = 5;
		private const int gccBuildBuildQtyColumn = 6;
		private const int gccBuildTotalCostColumn = 7;
		private const int gccBuildSerializedColumn = 8;
		private const int gccBuildSerialNoColumn = 9;
		private const int gccBuildRemarkColumn = 10;

		private const int tcProductCode = 20;

		private const int cCpPartNo = 0;
		private const int cCpProdName = 1;
		private const int cCpSymbol = 2;
		private const int cCpGroupName = 3;
		private const int cCpCost = 4;
		private const int cCpCatName = 5;
		private const int cCpStockInHand = 6;
		private const int cCpStockAllocated = 7;
		private const int cCpStockAvailable = 8;
		private const int cCpStockInTransit = 9;
		private const int cCpStockOnOrder = 10;
		private const int cCpProdCd = 11;
		private const int cCpSerialised = 12;
		private const int cCpItemTypeCd = 13;
		private const int cCpStockRate = 14;
		private const int cCpStockRate1 = 15;
		private const int cCpStockRate2 = 16;
		private const int cCpStockRate3 = 17;
		private const int cCpStockRate4 = 18;
		private const int cCpStockRate5 = 19;

		private int linkedEntryId = 0;

		private int mRecordNavigateSearchValue = 0;
		public XtremeCommandBars.StatusBar UCStatusBar = null;


		public object SearchValue
		{
			get
			{
				//The property below are used for storing the Search value returned by the Find window
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
				//These property set the Form mode to add mode or edit mode
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
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					mThisFormID = value;
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsVoucherTypes.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.rsVoucherTypes.MoveFirst();
					SystemVariables.rsVoucherTypes.Find("voucher_type = " + Conversion.Str(ThisVoucherType));

					if (ThisVoucherType == SystemICSConstants.icsBuildAssemblyProduct)
					{
						mBuildType = 1;
						mHeaderVoucherType = SystemICSConstants.icsBuildAssemblyProduct;
						mDetailVoucherType = SystemICSConstants.icsBuildComponentProduct;
					}
					else if (ThisVoucherType == SystemICSConstants.icsUnBuildAssemblyProduct)
					{ 
						mBuildType = 2;
						mHeaderVoucherType = SystemICSConstants.icsUnBuildAssemblyProduct;
						mDetailVoucherType = SystemICSConstants.icsUnBuildComponentProduct;
					}
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}

			}
		}


		private void cmdAddtionalDetails_Click(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				object mReturnValue = null;
				string mysql = "";

				if (!objAdditionalDetailsInitialised)
				{
					objAdditionalDetails = frmICSAdditionalVoucherDetails.CreateInstance();

					if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
					{
						objAdditionalDetails.SetSetValues(0, "");
					}
					else
					{
						mysql = " select assembly_trans_entry_id  ";
						mysql = mysql + " from ICS_Transaction_Assembly ";
						mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							objAdditionalDetails.SetSetValues(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue), "");
						}
						else
						{
							objAdditionalDetails.SetSetValues(0, "");
						}
					}

				}

				//UPGRADE_WARNING: (7009) Multiple invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions More Information: https://docs.mobilize.net/vbuc/ewis#7009
				objAdditionalDetails.ShowDialog();
				objAdditionalDetailsInitialised = true;

				if (txtCommonTextBox[SystemICSConstants.tcReferenceNo].Visible)
				{
					txtCommonTextBox[SystemICSConstants.tcReferenceNo].Focus();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}


		}

		//UPGRADE_WARNING: (2065) Form event Form.Deactivate has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
		private void Form_Deactivate(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//'***************************************************************************''
				//'Remove the GL posted status in MDI status bar.
				//'***************************************************************************''

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Affect_GLS"]) && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_post_to_gl_status")))
				{
					SystemProcedure2.CheckPostedStatus(0, "GLStatus");
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Affect_ICS"]) && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_post_to_ics_status")))
				{
					SystemProcedure2.CheckPostedStatus(0, "InvntStatus");
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					object mTempSearchValue = null;
					//Refresh the ICS_Item recordset when F5 is pressed
					if (Shift == 0 && KeyCode == 116 && !mFirstGridFocus)
					{
						RefreshRecordset();
					}

					//If F12 pressed show ICS_Item Picture
					if (Shift == 0 && KeyCode == 123)
					{
						ShowItemPicture();
					}

					//If F11 pressed show ICS_Item Query
					if (Shift == 0 && KeyCode == 122)
					{
						ShowProductQuery();
					}

					//If F10 pressed show ICS_Item History
					if (KeyCode == ((int) Keys.F10))
					{
						ShowProductHistory();
					}


					if (this.ActiveControl.Name.ToLower() == ("grdVoucherDetails").ToLower())
					{
						if (KeyCode == 13 || KeyCode == 115)
						{
							if (grdVoucherDetails.Col == gccBuildProductCodeColumn || grdVoucherDetails.Col == gccBuildProductNameColumn)
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
									grdVoucherDetails.Columns[gccBuildProductCodeColumn].Value = ((Array) mTempSearchValue).GetValue(1);
									grdVoucherDetails.Columns[gccBuildProductNameColumn].Value = ((Array) mTempSearchValue).GetValue(2);

									FetchDetailsFromPartNoInGrid(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1)), ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(2)));

									//Call cmbMastersList_RowChange
									//grdVoucherDetails.Refresh

								}
							}
							return;
						}
						else if (KeyCode == 222)
						{  //'for "'"
							KeyCode = 0;
							return;
						}


						if (Shift == 0)
						{
							if (grdVoucherDetails.Col == gccBuildQtyColumn || grdVoucherDetails.Col == gccBuildBuildCostColumn)
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
					if (KeyCode == 13)
					{ //if enter key pressed send a tab key
						SendKeys.Send("{tab}");
						return;
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
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}

		private void FetchDetailsFromPartNoInGrid(string pPartNo, string pProdName)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				grdVoucherDetails.Columns[SystemICSConstants.grdProductCodeColumn].Value = pPartNo;
				grdVoucherDetails.Columns[SystemICSConstants.grdProductNameColumn].Value = pProdName;

				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsProductCodeList.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsProductCodeList.MoveFirst();
				rsProductCodeList.Find(" part_no='" + pPartNo + "'");
				if (rsProductCodeList.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProductCodeList.Bookmark was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					cmbMastersList.Bookmark = rsProductCodeList.getBookmark();

					cmbMastersList_RowChange(cmbMastersList, new EventArgs());
					grdVoucherDetails_AfterColUpdate(grdVoucherDetails, new C1.Win.C1TrueDBGrid.ColEventArgs());
				}
				else
				{
					grdVoucherDetails.Columns[SystemICSConstants.grdProductCodeColumn].Value = "";
					grdVoucherDetails.Columns[SystemICSConstants.grdProductNameColumn].Value = "";
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
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

				grdVoucherDetails.Visible = false;
				mFirstGridFocus = true;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowMoveRecordPreviousButton = true;
				oThisFormToolBar.ShowMoveRecordNextButton = true;
				oThisFormToolBar.BeginInsertLineButtonWithGroup = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowHelpButton = true;

				//--** temporary disable post button
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("online_posting_in_ics_vouchers"))) == TriState.True)
				{
					//Me.tcbSystemForm(9).Visible = True
					oThisFormToolBar.ShowPostButton = true;
				}
				else
				{
					oThisFormToolBar.ShowPostButton = false;
					//Me.tcbSystemForm(9).Visible = False
					//Me.tcbSystemForm(8).Position = Me.tcbSystemForm(9).Position + 200
				}

				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				//
				//'draw form level toolbar
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgInsertLine").Picture
				//Set btnFormToolBar(7).Picture = frmSysMain.imlMainToolBar.ListImages("imgDeleteLine").Picture
				//Set btnFormToolBar(8).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture
				//Set btnFormToolBar(9).Picture = frmSysMain.imlSystemIcons.ListImages("imgPostingTransactions").Picture
				//

				//**--define voucher grid columns
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["voucher_grid_back_color"]), Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["voucher_grid_back_color"]));

				//**--define voucher grid columns
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Line_No_In_Details"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Product Code", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Part_No_In_Details"]));
				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Product Code", 1700, , , , , False, , , , , , , , rsVoucherTypes("Show_Part_No_In_Details"))
				//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Product Name", 3600, , , , , False, "T o t a l", , , False, False, , , rsVoucherTypes("Show_Product_Name_In_Details"))
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Product Name", 3000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbMastersList", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Name_In_Details"]), false, false, false, false, 200);


				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Unit", 500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_unit_in_details"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Qty", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Qty_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Qty_In_Details"]), 12);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, true, true, 12);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Build Qty", 900, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Qty_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Qty_In_Details"]), 12);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Total Cost", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, true, true, 12);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Serialized", 0, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Serial No.", 900, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("serialized_product")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_serial_in_details"])) != 0, false, false, true, true, 12);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1900, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Remarks_In_Details"]), false, false, true, true, 12);


				C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar = grdVoucherDetails.Splits[0].DisplayColumns[gccBuildSerialNoColumn];
				withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
				withVar.DataColumn.Caption = "";
				withVar.AllowFocus = true;
				withVar.ButtonAlways = true;
				withVar.ButtonText = true;
				withVar.Width = 27;
				withVar.Style.Font = withVar.Style.Font.Change(bold:true, size:11, name:"Verdana");
				withVar.Style.ForeColor = Color.FromArgb(21, 64, 77);


				Application.DoEvents();
				grdVoucherDetails.Visible = true;

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_ledger_on_header"]))
				{
					lblCommonLabel[12].Visible = true;
					txtCommonTextBox[SystemICSConstants.tcLedgerCode].Enabled = true;
					txtCommonTextBox[SystemICSConstants.tcLedgerCode].Visible = true;
					txtDisplayLabel[SystemICSConstants.dcLedgerName].Visible = true;
				}
				else
				{
					lblCommonLabel[12].Visible = false;
					txtCommonTextBox[SystemICSConstants.tcLedgerCode].Visible = false;
					txtDisplayLabel[SystemICSConstants.dcLedgerName].Visible = false;
				}


				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Import_Linked_Voucher_On_Header"]))
				{
					//--do linked voucher show/hide setting
					fraVoucherImport.Visible = false;
					lblCommonLabel[SystemICSConstants.lcImportLinkedVoucherTitle].Visible = false;
					lblCommonLabel[SystemICSConstants.lcImportVoucherType].Visible = false;
					lblCommonLabel[SystemICSConstants.lcImportLocationCode].Visible = false;
					lblCommonLabel[SystemICSConstants.lcImportVoucherNo].Visible = false;
					txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Visible = false;
					txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Visible = false;
					txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Visible = false;
					//**--------------------------------------------------------------------------------------------------------------
				}
				else
				{
					//--do linked voucher show/hide setting
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					fraVoucherImport.Visible = Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_import_linked_voucher_on_header"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					lblCommonLabel[SystemICSConstants.lcImportLinkedVoucherTitle].Visible = Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_import_linked_voucher_on_header"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					lblCommonLabel[SystemICSConstants.lcImportVoucherType].Visible = Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_import_linked_voucher_on_header"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					lblCommonLabel[SystemICSConstants.lcImportLocationCode].Visible = Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_import_linked_voucher_on_header"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					lblCommonLabel[SystemICSConstants.lcImportVoucherNo].Visible = Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_import_linked_voucher_on_header"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Visible = Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_import_linked_voucher_on_header"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Visible = Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_import_linked_voucher_on_header"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Visible = Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_import_linked_voucher_on_header"]);
					//**--------------------------------------------------------------------------------------------------------------
				}


				//''''*************************************************************************
				//setting voucher details grid properties
				aVoucherDetails = new XArrayHelper();
				SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, false);
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				//''''*************************************************************************

				//''''*************************************************************************
				//'***setting form mode to add initially
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				//''''*************************************************************************

				//''''*************************************************************************
				//Set the form caption
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["a_voucher_name"] : SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["l_voucher_name"]));
				//''''*************************************************************************


				//''''*************************************************************************
				//'''Set thr form properties
				this.txtVoucherDate.Value = SystemVariables.gCurrentDate;
				this.Top = 0;
				this.Left = 0;
				//.Width = 11490
				//.Height = 7605

				FirstFocusObject = this.txtCommonTextBox[tcProductCode];
				//'***set new voucher status to active by default
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
				//''''*************************************************************************
				CreateStatusBar();

				//If GetSystemPreferenceSetting("serialized_product") = vbTrue Then
				SystemICSProcedure.GenerateSerialedRecordset(ref rsAssemblySerialNo);
				SystemICSProcedure.GenerateSerialedRecordset(ref rsComponentSerialNo);
				//End If


				//Call SetDefaultValues
				CustomizeForm();

				clsFlip oFlipThisForm = null;
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
				{
					oFlipThisForm = new clsFlip();

					oFlipThisForm.SwapMe(this);
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}


		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;


				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsVoucherTypes.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsVoucherTypes.MoveFirst();
				SystemVariables.rsVoucherTypes.Find("voucher_type = " + Conversion.Str(ThisVoucherType));

				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//FirstFocusObject.SetFocus

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Affect_GLS"]) && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_post_to_gl_status")))
					{
						SystemProcedure2.CheckPostedStatus(1, "GLStatus", mPostedToGLStatus, CurrentFormMode, 1);
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Affect_ICS"]) && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_post_to_ics_status")))
					{
						SystemProcedure2.CheckPostedStatus(1, "InvntStatus", mPostedToICSStatus, CurrentFormMode, 2);
					}
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}

			}
		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				grdVoucherDetails.Width = this.Width - 11;
				grdVoucherDetails.Height = this.Height - (fraTransactionHeader.Height + 75);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Affect_GLS"]) && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_post_to_gl_status")))
				{
					SystemProcedure2.CheckPostedStatus(0, "GLStatus");
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Affect_ICS"]) && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_post_to_ics_status")))
				{
					SystemProcedure2.CheckPostedStatus(0, "InvntStatus");
				}

				objAdditionalDetails.Close();
				objAdditionalDetails = null;

				UserAccess = null;
				frmICSBuildStock.DefInstance = null;
				oThisFormToolBar = null;
				rsProductCodeList = null;
				rsAssemblySerialNo = null;
				rsComponentSerialNo = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void optVoucherType_Click(int Index)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				txtCommonTextBox[SystemICSConstants.tcCashCode].Enabled = Index == 1;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			//'***************************************************************************''
			//'This routine checks the column type and calls the "CalculateTotals" function.
			//'***************************************************************************''
			double mBaseQty = 0;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				grdVoucherDetails.UpdateData();

				if (ColIndex == gccBuildProductCodeColumn || ColIndex == gccBuildProductNameColumn || ColIndex == gccBuildQtyColumn || ColIndex == gccBuildBuildCostColumn || ColIndex == gccBuildBuildQtyColumn || ColIndex == gccBuildTotalCostColumn)
				{
					CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);


					//'''The grid is refreshed twice because.
					//'''there is problem in calculate total function of when the price list is enabled.
					//'''the total is not displayed when the user reached to third line.
					grdVoucherDetails.Refresh();
					grdVoucherDetails.Refresh();
				}


				C1.Win.C1TrueDBGrid.C1DataColumnCollection withVar = null;
				if (ColIndex == gccBuildBuildQtyColumn)
				{
					withVar = grdVoucherDetails.Columns;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdVoucherDetails.Splits[0].DisplayColumns[gccBuildSerialNoColumn].Visible)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_location_in_details"])) == TriState.True)
						{
							if (IsSerialNoRequired(withVar[SystemICSConstants.grdLocationCodeColumn].DataColumn.Text, withVar[gccBuildSerializedColumn].DataColumn.Text))
							{
								ShowSerialNo(withVar[gccBuildProductCodeColumn].DataColumn.Text, (Conversion.Val(withVar[gccBuildBuildQtyColumn].DataColumn.Text) * mBaseQty).ToString());
							}
						}
						else
						{
							if (IsSerialNoRequired("", withVar[gccBuildSerializedColumn].DataColumn.Text))
							{
								ShowSerialNo(withVar[gccBuildProductCodeColumn].DataColumn.Text, (Conversion.Val(withVar[gccBuildBuildQtyColumn].DataColumn.Text) * mBaseQty).ToString());
							}
						}
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdVoucherDetails_ButtonClick(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				C1.Win.C1TrueDBGrid.C1DataColumnCollection withVar = null;
				withVar = grdVoucherDetails.Columns;
				if (ColIndex == gccBuildSerialNoColumn)
				{
					if (withVar[gccBuildSerializedColumn].DataColumn.Text == ((int) TriState.True).ToString())
					{
						ShowSerialNo(withVar[gccBuildProductCodeColumn].DataColumn.Text, withVar[gccBuildBuildQtyColumn].DataColumn.Text);
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
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
					case gccBuildBuildCostColumn : 
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

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			//''''*************************************************************************
			//''''On the First focus of the grid
			//''''Define the Combo, Refresh the recordset, and generate the line no.
			//''''The first focus of the grid is maintained by the variable mFirstGridFocus
			//''''*************************************************************************
			try
			{
				try
				{
					string mysql = "";

					if (mFirstGridFocus)
					{
						SystemGrid.DefineSystemGridCombo(cmbMastersList);
						RefreshRecordset();
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						grdVoucherDetails.PostMsg(1);

						grdVoucherDetails_OnAddNew(grdVoucherDetails, new EventArgs());
						mFirstGridFocus = false;
					}

					return;
				}
				catch (System.Exception excep)
				{
					MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			catch
			{
			}
		}


		private void grdVoucherDetails_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					C1.Win.C1TrueDBGrid.C1DataColumnCollection withVar = null;
					if (KeyCode == 32)
					{
						withVar = grdVoucherDetails.Columns;
						if (grdVoucherDetails.Col == gccBuildSerializedColumn)
						{
							if (withVar[gccBuildSerializedColumn].DataColumn.Text == ((int) TriState.True).ToString())
							{
								ShowSerialNo(withVar[gccBuildProductCodeColumn].DataColumn.Text, withVar[gccBuildBuildQtyColumn].DataColumn.Text);
							}
						}
					}
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!mFirstGridFocus)
				{
					grdVoucherDetails.Columns[gccBuildLineNoColumn].Text = (grdVoucherDetails.RowCount + 1).ToString();
				}

				InitialiseGridValues();
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
			try
			{

				int Cnt = 0;
				object mCurrentbal = null;

				if (grdVoucherDetails.Row != ReflectionHelper.GetPrimitiveValue<double>(LastRow))
				{
					if (grdVoucherDetails.AddNewMode == C1.Win.C1TrueDBGrid.AddNewModeEnum.NoAddNew)
					{
						ShowProductDetails(false);
					}
					else if (grdVoucherDetails.AddNewMode == C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent)
					{ 
						ShowProductDetails(true);
					}
					else
					{
						ShowProductDetails(false);
					}
				}
				else
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!mFirstGridFocus && aVoucherDetails.GetLength(0) > 0 && Convert.IsDBNull(LastRow))
					{
						ShowProductDetails(false);
					}
				}

				if (grdVoucherDetails.Col > 0 && !mFirstGridFocus)
				{
					switch(grdVoucherDetails.Col)
					{
						case SystemICSConstants.grdBarCodeColumn : case gccBuildProductCodeColumn : case gccBuildProductNameColumn : 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersList.setDataSource((msdatasrc.DataSource) rsProductCodeList); 
							break;
					}
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}


		}

		private void txtBuildQty_Leave(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				CalculateTotals(0, 0);
				grdVoucherDetails.Rebind(true);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void cmdBuildSerialNo_Click(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				ShowAssemblySerialNo(txtCommonTextBox[tcProductCode].Text, txtBuildQty.Text);
				SendKeys.Send("{tab}");
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);

			string mysql = "";
			object mTempReturnValue = null;
			int mSetValueIndex = 0;

			clsICSTransaction pclsICSTransaction = null;

			if (SystemVariables.gSkipTextBoxLostFocus)
			{
				return;
			}

			try
			{

				switch(Index)
				{
					case SystemICSConstants.tcLedgerCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l.l_ldgr_name" : "l.a_ldgr_name"); 
						mysql = mysql + " , l.current_bal , gc.symbol, gc.curr_cd "; 
						 
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021 
						if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_default_salesman_in_ledger"))) == TriState.True)
						{
							mysql = mysql + " , sman.sman_no ";
							mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "sman.l_sman_name" : "sman.a_sman_name");
						}
						else
						{
							mysql = mysql + " , 0, '' ";
						} 
						 
						mysql = mysql + " , l.credit_limit_days "; 
						mysql = mysql + " , gc.exchange_rate, l.Default_Sales_Price_Level, l.Default_Purchase_Price_Level, l.Default_Discount_In_Percent  "; 
						mysql = mysql + " from gl_ledger l "; 
						mysql = mysql + " inner join gl_currency gc on l.curr_cd = gc.curr_cd "; 
						 
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021 
						if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_default_salesman_in_ledger"))) == TriState.True)
						{
							mysql = mysql + " left join SM_Salesman sman on l.default_sman_cd = sman.sman_cd ";
						} 
						 
						//'' --------------This code for ledger security ------ Moiz Hakimi----28-Oct-2008--------------------------- 
						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
						{
							mysql = mysql + " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
						} 
						//----------------------------------------------------------------------------------------------------------- 
						 
						mysql = mysql + " Where ldgr_no ='" + this.txtCommonTextBox[Index].Text + "'"; 
						 
						mSetValueIndex = SystemICSConstants.dcLedgerName; 
						break;
					case SystemICSConstants.tcLocationCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name"); 
						mysql = mysql + ",'' from SM_Location where locat_no = " + this.txtCommonTextBox[Index].Text; 
						 
						mSetValueIndex = SystemICSConstants.dcLocationName; 
						break;
					case tcProductCode : 
						//'''Only Assembly (Build) 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name" : "a_prod_name"); 
						mysql = mysql + ", time_stamp , serialized "; 
						mysql = mysql + " from ICS_Item where part_no ='" + this.txtCommonTextBox[Index].Text + "'"; 
						mysql = mysql + " and item_type_cd = 3"; 
						 
						mSetValueIndex = SystemICSConstants.dcProductName; 
						break;
					case SystemICSConstants.tcImportVoucherType : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name" : "a_voucher_name"); 
						mysql = mysql + ",'' from ICS_Transaction_Types where voucher_type = " + this.txtCommonTextBox[Index].Text; 
						mSetValueIndex = -1; 
						break;
					case SystemICSConstants.tcImportLocationCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name"); 
						mysql = mysql + ",'' from SM_Location where locat_no = " + this.txtCommonTextBox[Index].Text; 
						mSetValueIndex = -1; 
						 
						break;
					case SystemICSConstants.tcImportVoucherNo : 
						mSetValueIndex = -2; 
						break;
					default:
						mSetValueIndex = 0; 
						break;
				}

				if (mSetValueIndex == -1)
				{
					if (Index == SystemICSConstants.tcImportVoucherType)
					{
						//Enable it only it is already diabled and vouchertype is entered by the user
						if (!txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Enabled && !SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text, SystemVariables.DataType.NumberType))
						{
							txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Enabled = true;
							//txtCommonTextBox(tcImportVoucherNo).SetFocus
						}
					}

					//Enable the Import Voucher No text box
					if (Index == SystemICSConstants.tcImportLocationCode)
					{
						//Enable it only it is already diabled and vouchertype is entered by the user
						if (!txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Enabled && !SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text, SystemVariables.DataType.NumberType))
						{
							txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Enabled = true;
							//txtCommonTextBox(tcImportVoucherNo).SetFocus
						}
					}

					//Enable the Import Voucher No text box
					//                If Index = tcImportLocationCode Or Index = tcImportVoucherType Then
					//                    If txtCommonTextBox(tcImportVoucherNo).Enabled = True Then
					//                        txtCommonTextBox(tcImportVoucherNo).Text = ""
					//                        txtCommonTextBox(tcImportVoucherNo).Enabled = False
					//                    End If
					//                End If
				}
				else if (mSetValueIndex == -2)
				{ 
					if (!SystemProcedure2.IsItEmpty(this.txtCommonTextBox[Index].Text, SystemVariables.DataType.NumberType) && this.txtCommonTextBox[Index].Enabled)
					{

						mysql = " select Entry_Id from ICS_Transaction ";
						mysql = mysql + " where voucher_type = " + txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text;
						mysql = mysql + " and Voucher_No = " + txtCommonTextBox[Index].Text;
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempReturnValue))
						{
							//UPGRADE_WARNING: (1068) mTempReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							linkedEntryId = ReflectionHelper.GetPrimitiveValue<int>(mTempReturnValue);
						}

						//            Dim mCheckLocation As Boolean
						//
						//            If Not IsItEmpty(rsVoucherTypes("linked_parent_ics_voucher_type_cd"), NumberType) Then
						//                mCheckLocation = True
						//            Else
						//                mysql = " select allow_unbound from ICS_Transaction_Type_Link "
						//                mysql = mysql & " where voucher_type = " & rsVoucherTypes("voucher_type")
						//                mysql = mysql & " and parent_voucher_type = " & .txtCommonTextBox(tcImportVoucherType).Text
						//                mTempReturnValue = GetMasterCode(mysql)
						//
						//                If Not IsNull(mTempReturnValue) Then
						//                    If mTempReturnValue = vbTrue Then
						//                        Dim ans As Integer
						//                        ans = MsgBox(" Do you want to maintain a link with the source document ?", vbYesNo + vbInformation)
						//                        If ans = vbYes Then
						//                            mCheckLocation = True
						//                        Else
						//                            mCheckLocation = False
						//                        End If
						//                    Else
						//                        mCheckLocation = True
						//                    End If
						//                Else
						//                    mCheckLocation = False
						//                End If
						//            End If
						//
						//            If pclsICSTransaction.GetLinkedVoucherDetails(mCheckLocation) = False Then
						//                Err.Raise -9990002
						//            Else
						//                Call TextBoxLostFocus(Me, tcLedgerCode, pclsICSTransaction)
						//            End If
					}
				}
				else if (mSetValueIndex > 0)
				{ 
					if (!SystemProcedure2.IsItEmpty(this.txtCommonTextBox[Index].Text, SystemVariables.DataType.StringType))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempReturnValue))
						{
							this.txtDisplayLabel[mSetValueIndex].Text = "";

							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							this.txtDisplayLabel[mSetValueIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempReturnValue).GetValue(0));

							if (mSetValueIndex == SystemICSConstants.dcProductName)
							{
								mProductAssemblyTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempReturnValue).GetValue(1));

								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempReturnValue).GetValue(2))) == TriState.True)
								{
									cmdBuildSerialNo.Visible = true;
									SystemICSProcedure.GenerateSerialedRecordset(ref rsAssemblySerialNo);
									SystemICSProcedure.GenerateSerialedRecordset(ref rsComponentSerialNo);
								}
								else
								{
									cmdBuildSerialNo.Visible = false;
								}

								if (!SystemProcedure2.IsItEmpty(this.txtCommonTextBox[tcProductCode].Text, SystemVariables.DataType.StringType))
								{
									this.txtCommonTextBox[tcProductCode].Enabled = false;
									DisplayBuildInfo();
								}
							}


						}


					}
					else
					{
						this.txtDisplayLabel[mSetValueIndex].Text = "";
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
					//if the code is not found
					//    If Me.txtCommonTextBox(Index).Enabled = True Then
					//       Me.txtCommonTextBox(Index).SetFocus
					//    End If
				}
				else
				{
					//
				}
				//Call TextBoxLostFocus(Me, Index, me)
			}

		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			this.FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
		}

		private void txtVoucherDate_Validating(Object eventSender, CancelEventArgs eventArgs)
		{
			bool Cancel = eventArgs.Cancel;
			try
			{
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					if (Information.IsDate(txtVoucherDate.Value))
					{
						Cancel = !SystemProcedure2.ValidDateRange(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value));
					}
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel;
			}
		}


		private void GetProductListSQL(ref string pSQL)
		{
			//''''*************************************************************************
			//'''Product List query, alone with Base Unit and stock info.
			//''''*************************************************************************
			object mTempReturnValue = null;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				pSQL = "select part_no, ";
				pSQL = pSQL + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name as prod_name" : "a_prod_name as prod_name");
				pSQL = pSQL + " , ICS_Unit.symbol, ";
				pSQL = pSQL + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name" : "a_group_name") + " as group_name, ICS_Item.cost,";
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
				if (SystemProcedure2.IsItEmpty(this.txtCommonTextBox[SystemICSConstants.tcLocationCode].Text, SystemVariables.DataType.NumberType))
				{
					pSQL = pSQL + " where locat_cd = " + Conversion.Str(SystemVariables.gLoggedInUserLocationCode);
				}
				else
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select locat_cd from SM_Location where locat_no = " + Conversion.Str(this.txtCommonTextBox[SystemICSConstants.tcLocationCode].Text)));
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

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("assembly_product")))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToDouble(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["module_id"]) != 6)
					{
						//---------------Commented to include rebuilding of Items-----
						//pSQL = pSQL & " and ICS_Item.item_type_cd not in(3,4) "
						pSQL = pSQL + " and ICS_Item.item_type_cd not in(4) ";
					}
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_non_inventory_in_details"]))
				{
					pSQL = pSQL + " and it.affect_stock = 1 ";
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}


		private void ShowProductDetails(bool pShowRecordEmpty)
		{
			//''''*************************************************************************
			//'''Display the ICS_Item info in the status bar
			//''''*************************************************************************
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				if (!pShowRecordEmpty)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[gccBuildProductCodeColumn].Value).Trim() != "")
					{
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsProductCodeList.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsProductCodeList.MoveFirst();
						rsProductCodeList.Find("part_no = '" + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[gccBuildProductCodeColumn].Value).Trim() + "'");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProductCodeList.BOF was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						if (rsProductCodeList.Tables[0].Rows.Count != 0 || rsProductCodeList.getBOF())
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Base_Unit_In_Status"]))
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								UCStatusBar.FindPane(SystemICSConstants.lcBaseUnit2).Text = Convert.ToString(rsProductCodeList.Tables[0].Rows[0]["symbol"]);
							}

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Stock_In_Hand_In_Status"]))
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								UCStatusBar.FindPane(SystemICSConstants.lcStockInHand2).Text = Convert.ToString(rsProductCodeList.Tables[0].Rows[0]["stock_in_hand"]);
							}

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Stock_Allocated_In_Status"]))
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								UCStatusBar.FindPane(SystemICSConstants.lcStockAllocated2).Text = Convert.ToString(rsProductCodeList.Tables[0].Rows[0]["stock_allocated"]);
							}

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Stock_Available_In_Status"]))
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								UCStatusBar.FindPane(SystemICSConstants.lcStockAvailable2).Text = Convert.ToString(rsProductCodeList.Tables[0].Rows[0]["stock_available"]);
							}
							return;
						}
					}
				}
				ClearStatusBar();
				//Me.UCStatusBar.ClearText
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void CalculateTotals(int mRowNumber, int mColNumber, bool mIsGetRecord = false)
		{
			//''''*************************************************************************
			//'''Calculate the figures of following columns.
			//'''Quantity, Rate , Discount and amount.
			//''''*************************************************************************
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;
				double mTotalBuildCost = 0;
				double mBuildQty = 0;
				decimal mTotalCost = 0;


				double mTotalQty = 0;
				double mTotalBuildQty = 0;
				if (!SystemProcedure2.IsItEmpty(this.txtBuildQty.Text, SystemVariables.DataType.NumberType))
				{
					mBuildQty = Double.Parse(this.txtBuildQty.Text);
				}
				else
				{
					mBuildQty = 0;
				}

				if (mColNumber == 6 || mIsGetRecord)
				{
					int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
					for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
					{
						aVoucherDetails.SetValue(Convert.ToDouble(aVoucherDetails.GetValue(Cnt, gccBuildBuildQtyColumn)) / mBuildQty, Cnt, gccBuildQtyColumn);
						aVoucherDetails.SetValue(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildBuildCostColumn))) * Convert.ToDouble(aVoucherDetails.GetValue(Cnt, gccBuildBuildQtyColumn)), Cnt, gccBuildTotalCostColumn);

						mTotalQty += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildQtyColumn)));
						mTotalBuildQty += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildBuildQtyColumn)));

						mTotalCost += ((decimal) Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildBuildCostColumn))));
						mTotalBuildCost += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildBuildCostColumn))) * Convert.ToDouble(aVoucherDetails.GetValue(Cnt, gccBuildBuildQtyColumn));

					}

				}
				else if (mColNumber == 7)
				{ 
					int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
					for (Cnt = 0; Cnt <= tempForEndVar2; Cnt++)
					{
						aVoucherDetails.SetValue(Convert.ToDouble(aVoucherDetails.GetValue(Cnt, gccBuildBuildQtyColumn)) / mBuildQty, Cnt, gccBuildQtyColumn);
						aVoucherDetails.SetValue(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildTotalCostColumn))) / ((double) Convert.ToDouble(aVoucherDetails.GetValue(Cnt, gccBuildBuildQtyColumn))), Cnt, gccBuildBuildCostColumn);

						mTotalQty += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildQtyColumn)));
						mTotalBuildQty += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildBuildQtyColumn)));

						mTotalCost += ((decimal) Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildBuildCostColumn))));
						mTotalBuildCost += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildBuildCostColumn))) * Convert.ToDouble(aVoucherDetails.GetValue(Cnt, gccBuildBuildQtyColumn));

					}

				}
				else
				{
					int tempForEndVar3 = aVoucherDetails.GetLength(0) - 1;
					for (Cnt = 0; Cnt <= tempForEndVar3; Cnt++)
					{
						mTotalQty += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildQtyColumn)));
						aVoucherDetails.SetValue(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildBuildCostColumn))) * Convert.ToDouble(aVoucherDetails.GetValue(Cnt, gccBuildBuildQtyColumn)), Cnt, gccBuildTotalCostColumn);
						aVoucherDetails.SetValue(Convert.ToDouble(aVoucherDetails.GetValue(Cnt, gccBuildQtyColumn)) * mBuildQty, Cnt, gccBuildBuildQtyColumn);
						mTotalBuildQty += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildBuildQtyColumn)));

						mTotalCost += ((decimal) Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildBuildCostColumn))));
						mTotalBuildCost += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildBuildCostColumn))) * Convert.ToDouble(aVoucherDetails.GetValue(Cnt, gccBuildBuildQtyColumn));

					}
				}
				if (mTotalQty != 0)
				{
					if (mTotalQty - Math.Floor(mTotalQty) > 0)
					{
						grdVoucherDetails.Columns[gccBuildQtyColumn].FooterText = StringsHelper.Format(mTotalQty, "###,###,###,##0.0##");
					}
					else
					{
						grdVoucherDetails.Columns[gccBuildQtyColumn].FooterText = StringsHelper.Format(mTotalQty, "###,###,###,##0");
					}
				}
				else
				{
					grdVoucherDetails.Columns[gccBuildQtyColumn].FooterText = "";
				}

				if (mTotalBuildQty != 0)
				{
					if (mTotalBuildQty - Math.Floor(mTotalBuildQty) > 0)
					{
						grdVoucherDetails.Columns[gccBuildBuildQtyColumn].FooterText = StringsHelper.Format(mTotalBuildQty, "###,###,###,##0.0##");
					}
					else
					{
						grdVoucherDetails.Columns[gccBuildBuildQtyColumn].FooterText = StringsHelper.Format(mTotalBuildQty, "###,###,###,##0");
					}
				}
				else
				{
					grdVoucherDetails.Columns[gccBuildBuildQtyColumn].FooterText = "";
				}

				if (mTotalCost != 0)
				{
					if (mTotalCost - ((decimal) Math.Floor((double) mTotalCost)) > 0)
					{
						grdVoucherDetails.Columns[gccBuildBuildCostColumn].FooterText = StringsHelper.Format(mTotalCost, "###,###,###,##0.0##");
						grdVoucherDetails.Columns[gccBuildTotalCostColumn].FooterText = StringsHelper.Format(mTotalBuildCost, "###,###,###,##0.0##");
					}
					else
					{
						grdVoucherDetails.Columns[gccBuildBuildCostColumn].FooterText = StringsHelper.Format(mTotalCost, "###,###,###,##0");
						grdVoucherDetails.Columns[gccBuildTotalCostColumn].FooterText = StringsHelper.Format(mTotalBuildCost, "###,###,###,##0");
					}
				}
				else
				{
					grdVoucherDetails.Columns[gccBuildBuildCostColumn].FooterText = "";
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		public void AddRecord()
		{
			try
			{

				int Cnt = 0;


				//''''*************************************************************************
				//Set the form caption
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["a_voucher_name"] : SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["l_voucher_name"]));
				//''''*************************************************************************


				//''''*************************************************************************
				//'''Set the GL and Inventory status
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Affect_GLS"]) && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_post_to_gl_status")))
				{
					SystemProcedure2.CheckPostedStatus(0, "GLStatus");
				}
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Affect_ICS"]) && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_post_to_ics_status")))
				{
					SystemProcedure2.CheckPostedStatus(0, "InvntStatus");
				}
				//''''*************************************************************************


				//''''*************************************************************************
				//'''Grid settings
				int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					grdVoucherDetails.Columns[Cnt].FooterText = "";
				}
				RefreshRecordset(false);
				SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, true);
				grdVoucherDetails.Rebind(true);
				//''''*************************************************************************

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("serialized_product"))) == TriState.True)
				{
					SystemICSProcedure.GenerateSerialedRecordset(ref rsAssemblySerialNo);
					SystemICSProcedure.GenerateSerialedRecordset(ref rsComponentSerialNo);
				}

				//''''*************************************************************************
				//Clear Additional voucher details
				ClearAdditionalVoucherDetails();
				//''''*************************************************************************

				SystemProcedure2.ClearTextBox(this);

				this.txtCommonTextBox[tcProductCode].Enabled = true;
				//.txtCommonTextBox(tcLocationCode).Enabled = True

				this.txtVoucherDate.Value = SystemVariables.gCurrentDate;
				this.txtVoucherDate.Enabled = true;

				//Call .UCStatusBar.ClearText
				ClearStatusBar();
				SearchValue = ""; //Change the msearchvalue to blank

				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive; //set new voucher status to active by default


				//**-- set default value selected in the last transaction
				SetDefaultValues();
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]), "AddRecord");
			}
		}

		public void GetRecord(object pSearchValue)
		{
			//''''*************************************************************************
			//This routine is called after getting the value from Find window or
			//''''*************************************************************************

			DataSet rsLocalRec = null;
			string mysql = "";
			int mAssembleTransEntryID = 0;
			int mComponentTransEntryID = 0;
			int mStatus = 0;
			object mReturnValues = null;
			int Cnt = 0;
			object tempValue = null;

			try
			{

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
				if (Object.Equals(pSearchValue, null) || Convert.IsDBNull(pSearchValue))
				{
					return;
				}

				mysql = " select assembly_trans_entry_id, component_trans_entry_id , time_stamp, status ";
				mysql = mysql + " , approved_by , assembled_by, assembled_date, no_of_employees, no_of_hours, designed_by, entry_id ";
				mysql = mysql + " from ICS_Transaction_Assembly ";
				mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValues = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValues))
				{
					MessageBox.Show("Invalid Record", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAssembleTransEntryID = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValues).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mRecordNavigateSearchValue = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValues).GetValue(10));
					//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mComponentTransEntryID = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValues).GetValue(1));
					mTimeStamp = SystemProcedure2.tsFormat(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValues).GetValue(2)));
					//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mStatus = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValues).GetValue(3));
					txtApprovedBy.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValues).GetValue(4)) + "";
					txtAssembledBy.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValues).GetValue(5)) + "";

					if (Information.IsDate(((Array) mReturnValues).GetValue(6)))
					{
						//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDAssembledDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValues).GetValue(6));
					}
					else
					{
						txtDAssembledDate.Text = "";
					}
					txtNoOfEmployees.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValues).GetValue(7)) + "";
					txtNoOfHours.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValues).GetValue(8)) + "";
					txtDesignedBy.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValues).GetValue(9)) + "";
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = " select * from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]) + " where entry_id = " + mAssembleTransEntryID.ToString();

				rsLocalRec = new DataSet();
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLocalRec.Tables.Clear();
				adap.Fill(rsLocalRec);
				if (rsLocalRec.Tables[0].Rows.Count != 0)
				{
					CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
					//UPGRADE_WARNING: (1068) pSearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					SearchValue = ReflectionHelper.GetPrimitiveValue(pSearchValue);

					//''''*************************************************************************
					//'''Get the Location information
					mysql = "select locat_no,";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " from SM_Location where locat_cd=" + Conversion.Str(rsLocalRec.Tables[0].Rows[0]["locat_cd"]);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValues = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[SystemICSConstants.tcLocationCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValues).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDisplayLabel[SystemICSConstants.dcLocationName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValues).GetValue(1));
					//''''*************************************************************************
					//''''*************************************************************************

					//''''*************************************************************************
					//'''If the date does not fall in the current GL period then disable the control
					//'''Else enable the control
					//'''Enable the control in the Addrecord Method .
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtVoucherDate.Value = rsLocalRec.Tables[0].Rows[0]["voucher_date"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					this.txtVoucherDate.Enabled = Convert.ToDateTime(rsLocalRec.Tables[0].Rows[0]["voucher_date"]) >= DateTime.Parse(SystemVariables.gCurrentPeriodStarts) && Convert.ToDateTime(rsLocalRec.Tables[0].Rows[0]["voucher_date"]) <= DateTime.Parse(SystemVariables.gNextPeriodEnds);

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					this.txtCommonTextBox[SystemICSConstants.tcVoucherNo].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["voucher_no"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					this.txtCommonTextBox[SystemICSConstants.tcReferenceNo].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["reference_no"]) + "";

					//Set the form caption and Get the Voucher Status
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, mStatus, CurrentFormMode, Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["a_voucher_name"] : SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["l_voucher_name"]));


					//''''*************************************************************************
					//'''check voucher status of Inventory and GL
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_post_to_gl_status")))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mPostedToGLStatus = Convert.ToBoolean(rsLocalRec.Tables[0].Rows[0]["posted_gl"]);
						SystemProcedure2.CheckPostedStatus(1, "GLStatus", mPostedToGLStatus, CurrentFormMode, 1);
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_post_to_ics_status")))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mPostedToICSStatus = Convert.ToBoolean(rsLocalRec.Tables[0].Rows[0]["posted_invnt"]);
						SystemProcedure2.CheckPostedStatus(1, "InvntStatus", mPostedToICSStatus, CurrentFormMode, 2);
					}
					//''''*************************************************************************


					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_remarks_On_header"]))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonTextBox[SystemICSConstants.tcComments].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["comments"]) + "";
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_ledger_on_header"]))
					{
						mysql = "select ldgr_no ";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mysql = mysql + " from gl_ledger where ldgr_cd=" + Convert.ToString(rsLocalRec.Tables[0].Rows[0]["ldgr_cd"]);
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						tempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(tempValue))
						{
							//UPGRADE_WARNING: (1068) tempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							this.txtCommonTextBox[SystemICSConstants.tcLedgerCode].Text = ReflectionHelper.GetPrimitiveValue<string>(tempValue);
							this.txtCommonTextBox_Leave(this, new EventArgs());
						}
					}
					//''''*************************************************************************
					//Clear Additional voucher details
					ClearAdditionalVoucherDetails();
					InitialiseAdditionalVoucherDetailsInfo(mAssembleTransEntryID);
					//''''*************************************************************************
				}



				//'''''''''''''Get the Assemble ICS_Item info
				mysql = "select ICS_Item.part_no, lt.Prod_Name ";
				mysql = mysql + " , lt.Qty , serialized , lt.line_no , lt.prod_cd ";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]) + " as lt";
				mysql = mysql + " inner join ICS_Item on  lt.prod_cd = ICS_Item.prod_cd ";
				mysql = mysql + " where lt.entry_id =  " + mAssembleTransEntryID.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValues = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValues))
				{
					txtCommonTextBox[tcProductCode].Enabled = false;
					Application.DoEvents();
					//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[tcProductCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValues).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDisplayLabel[SystemICSConstants.dcProductName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValues).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtBuildQty.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValues).GetValue(2));


					//'''''''''Get serial information for Assembled ICS_Item info
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("serialized_product"))) == TriState.True)
					{
						SystemICSProcedure.GenerateSerialedRecordset(ref rsAssemblySerialNo);

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[gccBuildSerialNoColumn].Visible)
						{
							SystemICSProcedure.GenerateSerialedRecordset(ref rsComponentSerialNo);
						}

						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValues).GetValue(3))) == TriState.True)
						{
							cmdBuildSerialNo.Visible = true;

							Application.DoEvents();
							SystemICSProcedure.GetSerialNo(rsAssemblySerialNo, mHeaderVoucherType, mAssembleTransEntryID, ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValues).GetValue(4)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValues).GetValue(5)), 1, 0);

							//            mysql = "select from_serial_no, to_serial_no "
							//            mysql = mysql & " from ics_voucher_product_serial_no_details "
							//            mysql = mysql & " where voucher_type=" & mHeaderVoucherType
							//            mysql = mysql & " and voucher_entry_id=" & mAssembleTransEntryID
							//            mysql = mysql & " and line_no=" & mReturnValues(4)
							//            mysql = mysql & " and prod_cd=" & mReturnValues(5)
							//            mysql = mysql & " group by from_serial_no, to_serial_no "
							//
							//            Set rsTempRec = New ADODB.Recordset
							//            With rsTempRec
							//                .Open mysql, gConn, adOpenForwardOnly, adLockReadOnly
							//                Do While Not .EOF
							//                'DoEvents
							//                    rsAssemblySerialNo.AddNew
							//                    rsAssemblySerialNo("lineno") = 1
							//                    rsAssemblySerialNo("fromserialno") = .Fields("from_serial_no").Value
							//                    rsAssemblySerialNo("toserialno") = .Fields("to_serial_no").Value
							//
							//                    If rsCompanyProperties("Allow_Alpha_Numeric_Serial_No") = vbTrue Then
							//                        rsAssemblySerialNo("TotalSerialno") = 1
							//                    Else
							//                        rsAssemblySerialNo("TotalSerialno") = (Val(.Fields("to_serial_no")) - Val(.Fields("from_serial_no"))) + 1
							//                    End If
							//                    rsAssemblySerialNo.Update
							//                    .MoveNext
							//                Loop
							//            End With
						}
						else
						{
							cmdBuildSerialNo.Visible = false;
						}
					}
				}


				//'''''''''''''Get Component info
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = "select mt.Entry_Id, mt.Linked_To_Voucher_Type, lt.Voucher_No, l.locat_no  from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]) + " mt";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " Inner Join " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]) + " lt on mt.Linked_To_Entry_Id = lt.Entry_Id ";
				mysql = mysql + " Inner Join SM_Location l on l.locat_cd = lt.locat_cd ";
				mysql = mysql + " Where mt.entry_id = " + mComponentTransEntryID.ToString();

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValues = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValues))
				{
					//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					this.txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValues).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					this.txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValues).GetValue(2));
					//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					this.txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValues).GetValue(3));
				}

				mysql = "select lt.line_no, ICS_Item.part_no , lt.Prod_Name ";
				mysql = mysql + " , lt.Base_Qty ";
				mysql = mysql + " , ICS_Unit.symbol , ICS_Item.prod_cd, ICS_Item.serialized , lt.non_stock_manual_cost, lt.Reference_No ";
				mysql = mysql + " , lt.item_type_cd, lt.item_cost, FC_Rate, FC_Amount ";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]) + " as lt ";
				mysql = mysql + " inner join ICS_Item on  lt.prod_cd = ICS_Item.prod_cd ";
				mysql = mysql + " inner join ICS_Item_Unit_Details aud on aud.unit_entry_id = lt.unit_entry_id";
				mysql = mysql + " inner join ICS_Unit on aud.alt_unit_cd = ICS_Unit.unit_cd ";
				mysql = mysql + " where lt.entry_id =  " + mComponentTransEntryID.ToString();
				mysql = mysql + " order by 1 ";


				SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, true);

				//DoEvents
				SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLocalRec.Tables.Clear();
				adap_2.Fill(rsLocalRec);
				foreach (DataRow iteration_row in rsLocalRec.Tables[0].Rows)
				{
					SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, Cnt, false);

					aVoucherDetails.SetValue(Cnt + 1, Cnt, gccBuildLineNoColumn);
					aVoucherDetails.SetValue(Convert.ToString(iteration_row["part_no"]).Trim(), Cnt, gccBuildProductCodeColumn);
					aVoucherDetails.SetValue(Convert.ToString(iteration_row["prod_name"]).Trim(), Cnt, gccBuildProductNameColumn);
					aVoucherDetails.SetValue(Convert.ToString(iteration_row["symbol"]).Trim(), Cnt, gccBuildUnitSymbolColumn);
					aVoucherDetails.SetValue(Convert.ToString(iteration_row["Reference_No"]).Trim(), Cnt, gccBuildRemarkColumn);
					aVoucherDetails.SetValue(iteration_row["Base_Qty"], Cnt, gccBuildBuildQtyColumn);
					aVoucherDetails.SetValue(iteration_row["FC_Rate"], Cnt, gccBuildBuildCostColumn);
					aVoucherDetails.SetValue(iteration_row["FC_Amount"], Cnt, gccBuildTotalCostColumn);

					if (mPostedToGLStatus)
					{
						if (Convert.ToDouble(iteration_row["item_type_cd"]) == SystemICSConstants.ptInventoryTypeID)
						{
							aVoucherDetails.SetValue(iteration_row["item_cost"], Cnt, gccBuildBuildCostColumn);
							aVoucherDetails.SetValue(Convert.ToDouble(iteration_row["item_cost"]) * Convert.ToDouble(iteration_row["Base_Qty"]), Cnt, gccBuildTotalCostColumn);
						}
						else
						{
							aVoucherDetails.SetValue(iteration_row["item_cost"], Cnt, gccBuildBuildCostColumn);
							aVoucherDetails.SetValue(Convert.ToDouble(iteration_row["non_stock_manual_Cost"]) * Double.Parse(txtBuildQty.Text), Cnt, gccBuildTotalCostColumn);
						}
					}
					else if (Convert.ToDouble(iteration_row["non_stock_manual_Cost"]) > 0)
					{ 
						aVoucherDetails.SetValue(iteration_row["non_stock_manual_Cost"], Cnt, gccBuildBuildCostColumn);
					}

					aVoucherDetails.SetValue(Convert.ToDouble(iteration_row["Base_Qty"]) / ((double) Double.Parse(txtBuildQty.Text)), Cnt, gccBuildQtyColumn);
					aVoucherDetails.SetValue(iteration_row["serialized"], Cnt, gccBuildSerializedColumn);


					//'''''''''Get serial information for Assembled ICS_Item info
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("serialized_product"))) == TriState.True)
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(iteration_row["serialized"])) == TriState.True)
						{

							SystemICSProcedure.GetSerialNo(rsComponentSerialNo, mDetailVoucherType, mComponentTransEntryID, Convert.ToInt32(iteration_row["line_no"]), Convert.ToInt32(iteration_row["prod_cd"]), Cnt + 1, 0);
						}
					}

					Cnt++;
				}

				grdVoucherDetails_GotFocus(grdVoucherDetails, new EventArgs());
				CalculateTotals(0, 0, true);
				grdVoucherDetails.Refresh();
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Enabled = true;

				rsLocalRec = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]), "GetRecord");
			}
		}

		public bool Post()
		{
			bool result = false;
			DialogResult ans = (DialogResult) 0;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				string mysql = "";
				int mAssembleTransEntryID = 0;
				int mComponentTransEntryID = 0;
				object mReturnValues = null;

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

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					mysql = " select assembly_trans_entry_id, component_trans_entry_id ";
					mysql = mysql + " from ICS_Transaction_Assembly ";
					mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValues = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValues))
					{
						MessageBox.Show("Invalid Record", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mAssembleTransEntryID = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValues).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mComponentTransEntryID = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValues).GetValue(1));
					}
				}


				frmSysOnlinePosting frmTemp = frmSysOnlinePosting.CreateInstance();
				frmTemp.ShowDialog();

				//if the user clicks on OK button in the frmPost form
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
							SystemVariables.gConn.BeginTransaction();

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemICSProcedure.PostTransactionToIcs(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]), mAssembleTransEntryID);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemICSProcedure.PostTransactionToIcs(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]), mComponentTransEntryID);

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemICSProcedure.PostTransactionToGLParty(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]), mAssembleTransEntryID);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemICSProcedure.PostTransactionToGLParty(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]), mComponentTransEntryID);

							mysql = " update ICS_Transaction_Assembly ";
							mysql = mysql + " set status = 2 ";
							mysql = mysql + " where entry_id = " + Conversion.Str(SearchValue);
							SqlCommand TempCommand = null;
							TempCommand = SystemVariables.gConn.CreateCommand();
							TempCommand.CommandText = mysql;
							TempCommand.ExecuteNonQuery();

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemICSProcedure.PostTransactionToGL(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]), mAssembleTransEntryID);

							//--------------- No special posting needed for serialized item-------------------------------------
							//                If GetSystemPreferenceSetting("serialized_product") = vbTrue Then
							//                    If PostSerialItems(mHeaderVoucherType, mAssembleTransEntryID) = False Then
							//                        Post = False
							//                        gConn.RollBackTrans
							//                        GoTo mDestroy
							//                    End If
							//                End If

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemICSProcedure.PostTransactionToGL(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]), mComponentTransEntryID);

							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
							if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("serialized_product"))) == TriState.True)
							{
								if (!SystemICSProcedure.PostSerialItems(mDetailVoucherType, mComponentTransEntryID))
								{
									result = false;
									//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
									SystemVariables.gConn.RollbackTrans();
									goto mDestroy;
								}
							}

							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.CommitTrans();
						}

						result = true;
						goto mDestroy;
					}
				}

				result = false;
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
				frmTemp = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		public bool CheckDataValidity()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;

				grdVoucherDetails.UpdateData();

				if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
				{
					SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 3);
					if (ControlHelper.GetEnabled(FirstFocusObject))
					{
						FirstFocusObject.Focus();
					}
					goto mend;
				}

				if (SystemProcedure2.IsItEmpty(this.txtVoucherDate.Value, SystemVariables.DataType.DateType))
				{
					MessageBox.Show("Enter voucher date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (this.txtVoucherDate.Enabled)
					{
						this.txtVoucherDate.Focus();
					}
					goto mend;
				}
				else
				{
					if (!SystemProcedure2.ValidDateRange(ReflectionHelper.GetPrimitiveValue<System.DateTime>(this.txtVoucherDate.Value)))
					{
						MessageBox.Show("Invalid Date Range, Check the current financial year", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.txtVoucherDate.Focus();
						goto mend;
					}
				}

				if (SystemProcedure2.IsItEmpty(this.txtCommonTextBox[SystemICSConstants.tcLocationCode].Text, SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Enter location code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (txtCommonTextBox[SystemICSConstants.tcLocationCode].Enabled)
					{
						txtCommonTextBox[SystemICSConstants.tcLocationCode].Focus();
					}
					goto mend;
				}

				//'Check for Location level security
				//If gLoggedInUserCode <> gDefaultAdminUserCode Then
				//    If CheckLocationAccess(Me.txtCommonTextBox(tcLocationCode).Text) = False Then
				//        MsgBox "Invalid Location : Access Denied!"
				//        If Me.txtCommonTextBox(tcLocationCode).Enabled = True Then
				//            Me.txtCommonTextBox(tcLocationCode).SetFocus
				//        End If
				//        GoTo mend
				//    End If
				//End If


				if (SystemProcedure2.IsItEmpty(txtBuildQty.Text, SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Build Item Cannot be zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txtBuildQty.Focus();
					goto mend;
				}


				if (aVoucherDetails.GetLength(0) > 0)
				{
					int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
					for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
					{
						//Check for ICS_Item Code
						if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, gccBuildProductCodeColumn), SystemVariables.DataType.StringType))
						{
							MessageBox.Show("invalid Product Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							grdVoucherDetails.Col = gccBuildProductCodeColumn;
							grdVoucherDetails.Bookmark = Cnt;
							grdVoucherDetails.Focus();
							goto mend;
						}
					}
				}
				else
				{
					MessageBox.Show("Enter details information", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					goto mend;
				}
				return true;

				mend:;}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

			return false;
		}

		public void CloseForm()
		{
			this.Close();
			//Set me = Nothing
			Application.DoEvents();
		}

		public bool deleteRecord()
		{
			//Delete the Record

			bool result = false;
			string mysql = "";
			object mTempValue = null;
			int mAssembleTransEntryID = 0;
			int mComponentTransEntryID = 0;
			int mComponentTransDentedEntryID = 0;
			string mErrorMsg = "";

			try
			{

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


				SystemVariables.gConn.BeginTransaction();


				mysql = " select assembly_trans_entry_id, component_trans_entry_id, Dented_Trans_Entry_Id ";
				mysql = mysql + " from ICS_Transaction_Assembly ";
				mysql = mysql + " where entry_id=" + Conversion.Str(SearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempValue))
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAssembleTransEntryID = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mComponentTransEntryID = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mComponentTransDentedEntryID = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(2));
				}

				//''''*************************************************************************
				//'''During Delete of the voucher, update the detail table status to 0
				//'''This will deduct the quantity and help to check the negative stock
				//'''after the details portion is inserted
				//''''*************************************************************************
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = " update " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]);
				mysql = mysql + " set status=0 ";
				mysql = mysql + " where entry_id = " + mAssembleTransEntryID.ToString();
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = " update " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]);
				mysql = mysql + " set status = 0 ";
				mysql = mysql + " where entry_id = " + mComponentTransEntryID.ToString();
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = " update " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]);
				mysql = mysql + " set status = 0 ";
				mysql = mysql + " where entry_id = " + mComponentTransDentedEntryID.ToString();
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();
				//''''*************************************************************************

				if (IsNegativeStock(3, mAssembleTransEntryID, false, 0, 0, ref mErrorMsg))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show(mErrorMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					grdVoucherDetails.Focus();
					return result;
				}

				if (IsNegativeStock(3, mComponentTransEntryID, false, mDetailVoucherType, mHeaderVoucherType, ref mErrorMsg))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show(mErrorMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					grdVoucherDetails.Focus();
					return result;
				}

				//''''*************************************************************************
				//'''After the negative stock check is done then
				//'''Delete the items with status 0
				//''''*************************************************************************

				//''Delete the serialized items
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("serialized_product"))) == TriState.True)
				{
					mysql = " delete ics_voucher_product_serial_no_details ";
					mysql = mysql + " where voucher_entry_id = " + mAssembleTransEntryID.ToString();
					//'No need
					//mysql = mysql & " and voucher_type = " & mHeaderVoucherType
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();

					mysql = " delete ics_voucher_product_serial_no_details ";
					mysql = mysql + " where voucher_entry_id = " + mComponentTransEntryID.ToString();
					//'No need
					//mysql = mysql & " and voucher_type = " & mDetailVoucherType
					SqlCommand TempCommand_5 = null;
					TempCommand_5 = SystemVariables.gConn.CreateCommand();
					TempCommand_5.CommandText = mysql;
					TempCommand_5.ExecuteNonQuery();
				}


				mysql = " delete from ICS_Additional_Voucher_Details ";
				mysql = mysql + " where entry_id = " + mAssembleTransEntryID.ToString();
				SqlCommand TempCommand_6 = null;
				TempCommand_6 = SystemVariables.gConn.CreateCommand();
				TempCommand_6.CommandText = mysql;
				TempCommand_6.ExecuteNonQuery();

				mysql = " delete ICS_Transaction_Assembly ";
				mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand TempCommand_7 = null;
				TempCommand_7 = SystemVariables.gConn.CreateCommand();
				TempCommand_7.CommandText = mysql;
				TempCommand_7.ExecuteNonQuery();

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = " delete from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]);
				mysql = mysql + " where entry_id = " + mAssembleTransEntryID.ToString();
				mysql = mysql + " and status=0 ";
				SqlCommand TempCommand_8 = null;
				TempCommand_8 = SystemVariables.gConn.CreateCommand();
				TempCommand_8.CommandText = mysql;
				TempCommand_8.ExecuteNonQuery();

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = " delete from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]);
				mysql = mysql + " where entry_id = " + mComponentTransEntryID.ToString();
				mysql = mysql + " and status=0 ";
				SqlCommand TempCommand_9 = null;
				TempCommand_9 = SystemVariables.gConn.CreateCommand();
				TempCommand_9.CommandText = mysql;
				TempCommand_9.ExecuteNonQuery();

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = " delete from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]);
				mysql = mysql + " where entry_id = " + mComponentTransDentedEntryID.ToString();
				mysql = mysql + " and status=0 ";
				SqlCommand TempCommand_10 = null;
				TempCommand_10 = SystemVariables.gConn.CreateCommand();
				TempCommand_10.CommandText = mysql;
				TempCommand_10.ExecuteNonQuery();

				//''''*************************************************************************

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = " delete from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]);
				mysql = mysql + " where entry_id = " + mAssembleTransEntryID.ToString();
				SqlCommand TempCommand_11 = null;
				TempCommand_11 = SystemVariables.gConn.CreateCommand();
				TempCommand_11.CommandText = mysql;
				TempCommand_11.ExecuteNonQuery();

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = " delete from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]);
				mysql = mysql + " where entry_id = " + mComponentTransEntryID.ToString();
				SqlCommand TempCommand_12 = null;
				TempCommand_12 = SystemVariables.gConn.CreateCommand();
				TempCommand_12.CommandText = mysql;
				TempCommand_12.ExecuteNonQuery();

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = " delete from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]);
				mysql = mysql + " where entry_id = " + mComponentTransDentedEntryID.ToString();
				SqlCommand TempCommand_13 = null;
				TempCommand_13 = SystemVariables.gConn.CreateCommand();
				TempCommand_13.CommandText = mysql;
				TempCommand_13.ExecuteNonQuery();


				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();


				return true;
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_table_Name"]), "Deleterecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					result = false;
				}
				else
				{
					result = false;
				}

				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			return result;
		}

		public void PrintReport(int pEntryId = 0)
		{

			int mEntryId = 0;
			string mysql = "";
			object mCrystalReportEntryIDColumnID = null;
			SqlDataReader rsTempRec = null;

			try
			{

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
				}
				else
				{
					if (!SystemProcedure2.IsItEmpty(pEntryId))
					{
						mEntryId = pEntryId;
					}
					else
					{
						return;
					}
				}

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["use_crystal_reports_for_print"])) == TriState.True)
				{
					mysql = " select report_id from  ICS_Print_Task_Detail ";
					mysql = mysql + " WHERE Voucher_Type = " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Voucher_Type"]);

					SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
					rsTempRec = sqlCommand.ExecuteReader();
					rsTempRec.Read();

					if (rsTempRec.HasRows)
					{
						do 
						{
							mysql = "select column_id from SM_REPORT_FIELDS ";
							mysql = mysql + " where report_id = " + Convert.ToString(rsTempRec["report_id"]);
							mysql = mysql + " and entry_id_column = 1 ";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mCrystalReportEntryIDColumnID = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mCrystalReportEntryIDColumnID))
							{
								MessageBox.Show("Error: Incomplete Report Information!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								return;
							}

							SystemReports.GetCrystalReport(Convert.ToInt32(rsTempRec["report_id"]), 2, Conversion.Str(mCrystalReportEntryIDColumnID), Conversion.Str(mEntryId));
						}
						while(rsTempRec.Read());
					}
					else
					{
						MessageBox.Show("Error: No Report Information  Found!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		public void findRecord()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["find_id"])));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{

					//''the code below helps in coming out of txtCommonTextBox(tcProductCode) lost focus event
					txtVoucherDate.Focus();
					Application.DoEvents();

					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));

					GetRecord(mSearchValue);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void RefreshRecordset(bool pCallComboRowChange = true)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
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
				}
				else
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsProductCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsProductCodeList.Requery(-1);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void CustomizeForm()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				FirstFocusObject = this.txtCommonTextBox[SystemICSConstants.tcLocationCode];

				//--do remarks-on-header show/hide setting
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				this.lblCommonLabel[SystemICSConstants.lcReferenceNo].Visible = Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_remarks_on_header"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				this.txtCommonTextBox[SystemICSConstants.tcReferenceNo].Visible = Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_remarks_on_header"]);
				//**--------------------------------------------------------------------------------------------------------------

				//--do additional voucher details show/hide setting
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				cmdAddtionalDetails.Visible = Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_additional_voucher_details"]);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void ShowItemPicture()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[gccBuildProductCodeColumn].Text, SystemVariables.DataType.StringType) && Strings.Len(SystemVariables.gProductPicturesPath) > 0)
				{
					frmICSItemPictures.DefInstance.Show();
					//UPGRADE_WARNING: (2065) Form method frmICSItemPictures.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
					frmICSItemPictures.DefInstance.BringToFront();
					frmICSItemPictures.DefInstance.ItemNo = grdVoucherDetails.Columns[gccBuildProductCodeColumn].Text;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void ShowProductQuery()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[gccBuildProductCodeColumn].Text, SystemVariables.DataType.StringType))
				{
					repItemQuery.DefInstance.Show();
					//UPGRADE_WARNING: (2065) Form method repItemQuery.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
					repItemQuery.DefInstance.BringToFront();
					repItemQuery.DefInstance.txtPartNo.Text = grdVoucherDetails.Columns[gccBuildProductCodeColumn].Text;
					repItemQuery.DefInstance.GetProductInfo(grdVoucherDetails.Columns[gccBuildProductCodeColumn].Text);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void SetDefaultValues()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["restore_last_tran_setting"])) == TriState.True)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					this.txtCommonTextBox[SystemICSConstants.tcLocationCode].Text = Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["last_tran_locat_no"]) + "";
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void ShowProductHistory()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[gccBuildProductCodeColumn].Text, SystemVariables.DataType.StringType))
				{
					frmICSProductHistory.DefInstance.Show();
					//UPGRADE_WARNING: (2065) Form method frmICSProductHistory.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
					frmICSProductHistory.DefInstance.BringToFront();
					frmICSProductHistory.DefInstance.txtProductCode.Text = grdVoucherDetails.Columns[gccBuildProductCodeColumn].Text;
					frmICSProductHistory.DefInstance.txtLedgerCode.Text = this.txtCommonTextBox[SystemICSConstants.tcLedgerCode].Text;
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					frmICSProductHistory.DefInstance.txtTransactionType.Text = Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Voucher_type"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					frmICSProductHistory.DefInstance.txtDisplayControl[0].Text = Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["l_voucher_name"] : SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["a_voucher_name"]);
					frmICSProductHistory.DefInstance.txtDisplayControl[1].Text = this.txtDisplayLabel[SystemICSConstants.dcLedgerName].Text;
					frmICSProductHistory.DefInstance.txtDisplayControl[2].Text = grdVoucherDetails.Columns[gccBuildProductNameColumn].Text;
					frmICSProductHistory.DefInstance.cmdGetProductHistory_Click(frmICSProductHistory.DefInstance.cmdGetProductHistory, new EventArgs());
					//.GetProductInfo (grdVoucherDetails.Columns(gccBuildProductCodeColumn).Text)
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void FindRoutine(string pObjectName)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				object mTempSearchValue = null;
				string mFilterCondition = "";
				string mysql = "";
				string mTempSql = "";
				object mReturnValue = null;
				string mAdditionalFromClause = "";

				if ((pObjectName.IndexOf('#') + 1) == 0)
				{
					return;
				}

				string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
				int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

				clsSetICSVoucherRec mSetVoucher = null;
				if (mObjectName == "txtCommonTextBox")
				{
					this.txtCommonTextBox[mIndex].Text = "";
					switch(mIndex)
					{
						case SystemICSConstants.tcLocationCode : case SystemICSConstants.tcImportLocationCode : 
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2004000, "82")); 
							break;
						case tcProductCode : 
							//''Only Assembly (Build) 
							mFilterCondition = " item_type_cd = 3 "; 
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001000, "28", mFilterCondition)); 
							break;
						case SystemICSConstants.tcImportVoucherType : 
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(200, "693")); 
							break;
						case SystemICSConstants.tcLedgerCode : 
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
							mysql = Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["additional_ledger_find_where_clause"]) + ""; 
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
							if (!Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_exchange_rate"]) && !ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("advance_multiple_currency")))
							{
								if (mysql != "")
								{
									mysql = mysql + " and ";
								}
								mysql = mysql + " l.curr_cd = " + Conversion.Str(SystemGLConstants.gDefaultCurrencyCd);
							} 
							 
							//'' --------------This code for ledger security ------ Moiz Hakimi----28-Oct-2008--------------------------- 
							if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
							{
								mAdditionalFromClause = " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
							}
							else
							{
								mAdditionalFromClause = "";
							} 
							//'' -------------------------------------------------------------------------------------------------------- 
							 
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mysql, true, false, "", true, false, false, mAdditionalFromClause)); 
							break;
						case SystemICSConstants.tcImportVoucherNo : 
							 
							mysql = " mloc.locat_no = " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text, SystemVariables.DataType.NumberType)) ? "0" : txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text); 
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
							if (!SystemProcedure2.IsItEmpty(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["linked_parent_ics_voucher_type_cd"], SystemVariables.DataType.NumberType))
							{

								mSetVoucher = new clsSetICSVoucherRec();
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mSetVoucher.SetVoucherType(Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["voucher_type"]), Convert.ToInt32(Double.Parse(txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text)));

								//                    If rsVoucherTypes("add_or_less") = "A" Then
								//                        mysql = mysql & " and aloc.locat_no = " & IIf(IsItEmpty(frmCommon.txtCommonTextBox(tcLocationCode).Text, NumberType), 0, frmCommon.txtCommonTextBox(tcLocationCode).Text)
								//                    Else
								//                        mysql = mysql & " and lloc.locat_no = " & IIf(IsItEmpty(frmCommon.txtCommonTextBox(tcLocationCode).Text, NumberType), 0, frmCommon.txtCommonTextBox(tcLocationCode).Text)
								//                    End If
								mysql = mysql + " and dt.balance_qty > 0 ";

								mSetVoucher = null;
							}
							else
							{
								//Check in the voucher parent details table
								mTempSql = " select allow_unbound from ICS_Transaction_Type_Link ";
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								mTempSql = mTempSql + " where voucher_type = " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["voucher_type"]);
								mTempSql = mTempSql + " and parent_voucher_type = " + txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text;
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mTempSql));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (!Convert.IsDBNull(mReturnValue))
								{
									//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
									if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(mReturnValue)) == TriState.False)
									{

										mSetVoucher = new clsSetICSVoucherRec();
										//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
										mSetVoucher.SetVoucherType(Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["voucher_type"]), Convert.ToInt32(Double.Parse(txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text)));

										//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
										if (Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["add_or_less"]) == "A")
										{
											mysql = mysql + " and aloc.locat_no = " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcLocationCode].Text, SystemVariables.DataType.NumberType)) ? "0" : txtCommonTextBox[SystemICSConstants.tcLocationCode].Text);
										}
										else
										{
											mysql = mysql + " and lloc.locat_no = " + ((SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcLocationCode].Text, SystemVariables.DataType.NumberType)) ? "0" : txtCommonTextBox[SystemICSConstants.tcLocationCode].Text);
										}
										mysql = mysql + " and dt.balance_qty > 0 ";

										mSetVoucher = null;
									}
								}
							} 
							mysql = mysql + " and mt.voucher_type = " + txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text; 
							 
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(4000107, "1035", mysql)); 
							break;
						default:
							return;
					}
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					if (mObjectName == "txtCommonTextBox")
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						this.txtCommonTextBox[mIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						this.txtCommonTextBox_Leave(this, new EventArgs());
					}
				}

				SystemVariables.gSkipTextBoxLostFocus = false;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private bool IsNegativeStock(int pActionMode, int pEntryId, bool pBoth, int pNewVoucherType, int pOldVoucherType, ref string pErrorMsg)
		{
			//''''In order to control the negative stock, the following things are done
			//''''1.Update the details table status to 0 before update, this will undo the quantity
			//''''2.Call the IsNegativeStock function to check the quantity

			//Check for Negative Stock
			//pActionMode=1 Add
			//pActionMode=2 Update
			//pActionMode=3 Delete
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			bool result = false;
			try
			{

				string mysql = "";
				string mLocatType = "";
				int Cnt = 0;
				string mNegativePartNo = "";

				clsSetICSVoucherRec mSetVoucher = null;
				if (pNewVoucherType > 0)
				{
					mSetVoucher = new clsSetICSVoucherRec();
					mSetVoucher.SetVoucherType(pOldVoucherType, pNewVoucherType);
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("negative_stock_check")) && Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Check_Negative_Stock"]))
				{
					if (pActionMode == 1)
					{ //Add
						//During add do not check only purchase type of transaction
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["add_or_less"]) == "A" && Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["affect_on_hand_stock"]) && !Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["locat_to_locat"]))
						{
							return false;
						}
					}
					else if (pActionMode == 3)
					{  //Delete
						//During delete do not check only sales type of transaction
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["add_or_less"]) == "L" && Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["affect_on_hand_stock"]) && !Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["locat_to_locat"]))
						{
							return false;
						}
					}

					if (pActionMode == 1)
					{ //Add
						mLocatType = "less_locat_cd";
					}
					else if (pActionMode == 2)
					{  //Update
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["locat_to_locat"]) && !Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["generate_on_multiple_location"]))
						{
							//This condition will be true for Stock Trans
							//For the first time it is false, which would take the location less_locat_cd
							//The recursive call would make it true, which would take the location add_locat_cd
							if (!pBoth)
							{
								mLocatType = "less_locat_cd";
							}
							else
							{
								mLocatType = "add_locat_cd";
							}
						}
						else
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							if (Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["add_or_less"]) == "L")
							{
								mLocatType = "less_locat_cd";
							}
							else if (Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["add_or_less"]) == "A")
							{ 
								mLocatType = "add_locat_cd";
							}
						}
					}
					else if (pActionMode == 3)
					{  //Delete
						mLocatType = "add_locat_cd";
					}

					mNegativePartNo = SystemICSProcedure.NegativeStockCheck(pEntryId, mLocatType, ref pErrorMsg);
					if (mNegativePartNo != "")
					{
						int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
						for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
						{
							if (Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildProductCodeColumn)).Trim() == mNegativePartNo.Trim())
							{
								grdVoucherDetails.Bookmark = Cnt;
								break;
							}
						}

						result = true;
					}
					else
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (pActionMode == 2 && !pBoth && (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["locat_to_locat"]) && !Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["generate_on_multiple_location"])))
						{
							//This procedure will run during UPDATE for stocktrans
							//The recursive function is called for checking the stock of both the location
							//add_locat_cd and less_locat_cd
							IsNegativeStock(2, pEntryId, true, 0, 0, ref pErrorMsg);
						}
						result = false;
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		private bool IsNegativeStock(int pActionMode, int pEntryId, bool pBoth, int pNewVoucherType, int pOldVoucherType)
		{
			string tempRefParam = "";
			return IsNegativeStock(pActionMode, pEntryId, pBoth, pNewVoucherType, pOldVoucherType, ref tempRefParam);
		}

		private bool IsNegativeStock(int pActionMode, int pEntryId, bool pBoth, int pNewVoucherType)
		{
			string tempRefParam2 = "";
			return IsNegativeStock(pActionMode, pEntryId, pBoth, pNewVoucherType, 0, ref tempRefParam2);
		}

		private bool IsNegativeStock(int pActionMode, int pEntryId, bool pBoth)
		{
			string tempRefParam3 = "";
			return IsNegativeStock(pActionMode, pEntryId, pBoth, 0, 0, ref tempRefParam3);
		}

		private bool IsNegativeStock(int pActionMode, int pEntryId)
		{
			string tempRefParam4 = "";
			return IsNegativeStock(pActionMode, pEntryId, false, 0, 0, ref tempRefParam4);
		}


		public bool saveRecord(bool pApprove = false)
		{
			bool result = false;
			DialogResult ans = (DialogResult) 0;
			object mTempValue = null;

			string mysql = "";
			string tempSql = "";
			string mErrorMsg = "";
			object mTempReturnValue = null;

			int mProductCode = 0;
			int mAssembleProductCode = 0;
			string mAssembleProductName = "";
			int mAssembleUnitEntryId = 0;
			bool mAssemblySerialized = false;
			int mAssemblyItemTypeCd = 0;

			int mComponentUnitEntryId = 0;
			bool mComponentSerialized = false;
			int mComponentItemTypeCd = 0;

			int mAssembleTransEntryID = 0;
			int mComponentTransEntryID = 0;
			int mComponentTransDentedEntryID = 0;

			double mQty = 0;
			double mCost = 0;
			double mTotalCost = 0;
			int mEntryId = 0;
			decimal mNonStockManualCost = 0;


			int mLocatCode = 0;
			int mLdgrCode = 0;
			int mVoucherNo = 0;
			int Cnt = 0;

			bool mAffectStock = false;
			int mNewLineNo = 0;

			object mReturnValue = null;

			clsHourGlass myHourGlass = new clsHourGlass();

			//Save a record
			//During save check for the mode
			//If in addmode then insert a record
			//else update the record in the recordset

			try
			{



				//'''****************************Get the Loation Code ****************************
				//''''****************************************************************************
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select locat_cd from SM_Location where locat_no=" + this.txtCommonTextBox[SystemICSConstants.tcLocationCode].Text));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempValue))
				{
					MessageBox.Show("Enter valid location code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (this.txtCommonTextBox[SystemICSConstants.tcLocationCode].Enabled)
					{
						this.txtCommonTextBox[SystemICSConstants.tcLocationCode].Focus();
					}
					goto StationExitFunction;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLocatCode = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
				}
				//''''****************************************************************************

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_ledger_on_header"]))
				{
					mysql = "select ldgr_cd ";
					mysql = mysql + " from gl_ledger where ldgr_no='" + txtCommonTextBox[SystemICSConstants.tcLedgerCode].Text + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						MessageBox.Show("Select Supplier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						if (this.txtCommonTextBox[SystemICSConstants.tcLedgerCode].Enabled)
						{
							this.txtCommonTextBox[SystemICSConstants.tcLedgerCode].Focus();
						}
						goto StationExitFunction;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLdgrCode = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
					}
				}
				//''''****************************************************************************

				//'''****************************Get the Assembled ICS_Item Code ****************************
				//''''****************************************************************************
				mysql = " select ICS_Item.prod_cd ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_prod_name " : " a_prod_name");
				mysql = mysql + " , unit_entry_id, ICS_Item.time_stamp , serialized , ICS_Item.item_type_cd ";
				mysql = mysql + " from ICS_Item, ICS_Item_Unit_Details aud ";
				mysql = mysql + " where ICS_Item.prod_cd = aud.prod_cd ";
				mysql = mysql + " and ICS_Item.base_unit_cd = aud.alt_unit_cd ";
				mysql = mysql + " and part_no='" + txtCommonTextBox[tcProductCode].Text + "'";
				mysql = mysql + " and ICS_Item.item_type_cd = 3 ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempValue))
				{
					MessageBox.Show("Enter valid ICS_Item code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (this.txtCommonTextBox[tcProductCode].Enabled)
					{
						this.txtCommonTextBox[tcProductCode].Focus();
					}
					goto StationExitFunction;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAssembleProductCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAssembleProductName = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAssembleUnitEntryId = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(2));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAssemblySerialized = ReflectionHelper.GetPrimitiveValue<bool>(((Array) mTempValue).GetValue(4));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAssemblyItemTypeCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(5));
					//'''commented by Moiz Hakimion 01-sep-2007
					//'''this error occured in honest and such check is not required.
					//    If CurrentFormMode = frmAddMode Then
					//        If tsFormat(CStr(mTempValue(3))) <> tsFormat(mProductAssemblyTimeStamp) Then
					//            MsgBox msg10, vbInformation
					//            GoTo StationExitFunction
					//        End If
					//    End If
				}
				//''''****************************************************************************


				SystemVariables.gConn.BeginTransaction();

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{

					//''''****************************************************************************
					//I '''''''''''''N'''''''''''''S'''''''''''''E'''''''''''''R'''''''''''T
					//''''****************************************************************************

					//''''*********************get the new voucher no for header voucher**********
					//    mySql = " locat_cd = " & Str(mLocatCode)
					//    mySql = mySql & " and voucher_type =" & mHeaderVoucherType
					//    mVoucherNo = GetNewNumber(rsVoucherTypes("Master_Table_Name"), "voucher_no", , mySql)

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mVoucherNo = Convert.ToInt32(Double.Parse(SystemICSProcedure.GetICSVoucherNo(Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Generate_voucher_no_method"]), mLocatCode, mHeaderVoucherType.ToString(), Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]))));
					//''''************************************************************************


					//''''*********************Insert into the Invnt trans table for Assembly ****
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " insert into " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]);
					mysql = mysql + " ( voucher_date, due_date,  voucher_no ";
					mysql = mysql + " , voucher_type  ";
					mysql = mysql + " , reference_no, comments, user_cd ";
					mysql = mysql + " , locat_cd, on_hand_stock_affected ";
					mysql = mysql + " , status, posted_invnt, posted_gl, ldgr_cd";
					mysql = mysql + " ) values ( ";
					mysql = mysql + "'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'"; //Voucher Date
					mysql = mysql + ", '" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'"; //Due Date
					mysql = mysql + ", " + Conversion.Str(mVoucherNo); //Voucher No.
					mysql = mysql + ", " + Conversion.Str(mHeaderVoucherType);
					mysql = mysql + ",'" + this.txtCommonTextBox[SystemICSConstants.tcReferenceNo].Text + "'"; //ReferenceNo
					mysql = mysql + ",N'" + this.txtCommonTextBox[SystemICSConstants.tcComments].Text + "'"; //Comments
					mysql = mysql + ", " + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + ", " + Conversion.Str(mLocatCode);
					mysql = mysql + ", 1 ";
					mysql = mysql + ", 4, 0, 0, ";

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_ledger_on_header"]))
					{
						mysql = mysql + Conversion.Str(mLdgrCode);
					}
					else
					{
						mysql = mysql + " NULL ";

					}

					mysql = mysql + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//''''*********************Get the New entry ID during add mode ***************
					mAssembleTransEntryID = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
					//''''*************************************************************************


					//''''*********************get the new voucher no for details voucher**********
					//    mySql = " locat_cd = " & Str(mLocatCode)
					//    mySql = mySql & " and voucher_type =" & mDetailVoucherType
					//    mVoucherNo = GetNewNumber(rsVoucherTypes("Master_Table_Name"), "voucher_no", , mySql)

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mVoucherNo = Convert.ToInt32(Double.Parse(SystemICSProcedure.GetICSVoucherNo(Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Generate_voucher_no_method"]), mLocatCode, mDetailVoucherType.ToString(), Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]))));
					//''''************************************************************************

					//''''*********************Insert into the Invnt Trans table for Component *****
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " insert into " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]);
					mysql = mysql + " ( voucher_date, due_date, voucher_no";
					mysql = mysql + " , voucher_type  ";
					mysql = mysql + " , reference_no, comments, user_cd ";
					mysql = mysql + " , locat_cd, on_hand_stock_affected ";
					mysql = mysql + " , status, posted_invnt, posted_gl, Linked_To_Voucher_Type, Linked_To_Entry_Id, Ldgr_Cd ";
					mysql = mysql + " ) values ( ";
					mysql = mysql + "'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'"; //Voucher Date
					mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'"; //Due Date
					mysql = mysql + ", " + Conversion.Str(mVoucherNo); //Voucher No.
					mysql = mysql + ", " + Conversion.Str(mDetailVoucherType);
					mysql = mysql + ",'" + this.txtCommonTextBox[SystemICSConstants.tcReferenceNo].Text + "'"; //ReferenceNo
					mysql = mysql + ",N'" + this.txtCommonTextBox[SystemICSConstants.tcComments].Text + "'"; //Comments
					mysql = mysql + ", " + Conversion.Str(SystemVariables.gLoggedInUserCode); //User Cd
					mysql = mysql + ", " + Conversion.Str(mLocatCode);
					mysql = mysql + ", 1 ";
					mysql = mysql + " , 4, 0, 0 ";

					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text, SystemVariables.DataType.NumberType))
					{
						mysql = mysql + ", " + this.txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text;
						mysql = mysql + ", " + linkedEntryId.ToString();
					}
					else
					{
						mysql = mysql + ", null, null ";
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_ledger_on_header"]))
					{
						mysql = mysql + "," + Conversion.Str(mLdgrCode);
					}
					else
					{
						mysql = mysql + ", NULL ";

					}
					mysql = mysql + " )";
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

					//''''*********************Get the New entry ID during add mode ***************
					mComponentTransEntryID = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
					//''''*************************************************************************


					//''''*********************Generate dented transaction**********

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Dented_Stock_Generated_Linked_Voucher_Type"]))
					{

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mVoucherNo = Convert.ToInt32(Double.Parse(SystemICSProcedure.GetICSVoucherNo(Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Generate_voucher_no_method"]), mLocatCode, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Dented_Stock_Generated_Linked_Voucher_Type"]), Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]))));
						//''''************************************************************************

						//''''*********************Insert into the Invnt Trans table for Component *****
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mysql = " insert into " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]);
						mysql = mysql + " ( voucher_date, due_date, voucher_no";
						mysql = mysql + " , voucher_type  ";
						mysql = mysql + " , reference_no, comments, user_cd ";
						mysql = mysql + " , locat_cd, on_hand_stock_affected ";
						mysql = mysql + " , status, posted_invnt, posted_gl, Linked_To_Voucher_Type, Linked_To_Entry_Id, Ldgr_Cd ";
						mysql = mysql + " ) values ( ";
						mysql = mysql + "'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'"; //Voucher Date
						mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'"; //Due Date
						mysql = mysql + ", " + Conversion.Str(mVoucherNo); //Voucher No.
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mysql = mysql + ", " + Conversion.Str(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Dented_Stock_Generated_Linked_Voucher_Type"]);
						mysql = mysql + ",'" + this.txtCommonTextBox[SystemICSConstants.tcReferenceNo].Text + "'"; //ReferenceNo
						mysql = mysql + ",N'" + this.txtCommonTextBox[SystemICSConstants.tcComments].Text + "'"; //Comments
						mysql = mysql + ", " + Conversion.Str(SystemVariables.gLoggedInUserCode); //User Cd
						mysql = mysql + ", " + Conversion.Str(mLocatCode);
						mysql = mysql + ", 1 ";
						mysql = mysql + " , 4, 0, 0 ";

						if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text, SystemVariables.DataType.NumberType))
						{
							mysql = mysql + ", " + this.txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text;
							mysql = mysql + ", " + linkedEntryId.ToString();
						}
						else
						{
							mysql = mysql + ", null, null ";
						}

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_ledger_on_header"]))
						{
							mysql = mysql + "," + Conversion.Str(mLdgrCode);
						}
						else
						{
							mysql = mysql + ", NULL ";

						}
						mysql = mysql + " )";
						SqlCommand TempCommand_3 = null;
						TempCommand_3 = SystemVariables.gConn.CreateCommand();
						TempCommand_3.CommandText = mysql;
						TempCommand_3.ExecuteNonQuery();

						//''''*********************Get the New entry ID during add mode ***************
						mComponentTransDentedEntryID = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
						//''''*************************************************************************
					}

					mysql = " insert into ICS_Transaction_Assembly ";
					mysql = mysql + " (trans_type, assembly_trans_entry_id , assembly_trans_voucher_type ";
					mysql = mysql + " , component_trans_entry_id , component_trans_voucher_type ";
					mysql = mysql + " , approved_by , assembled_by, assembled_date, no_of_employees, no_of_hours, designed_by ";
					mysql = mysql + " , user_cd, Dented_Trans_Entry_Id) ";
					mysql = mysql + " values (";
					mysql = mysql + mBuildType.ToString(); //Build
					mysql = mysql + ", " + mAssembleTransEntryID.ToString();
					mysql = mysql + ", " + mHeaderVoucherType.ToString();
					mysql = mysql + ", " + mComponentTransEntryID.ToString();
					mysql = mysql + ", " + mDetailVoucherType.ToString();
					mysql = mysql + ", N'" + txtApprovedBy.Text + "'";
					mysql = mysql + ", N'" + txtAssembledBy.Text + "'";
					if (Information.IsDate(txtDAssembledDate.Value))
					{
						mysql = mysql + ", '" + ReflectionHelper.GetPrimitiveValue<string>(txtDAssembledDate.Value) + "'";
					}
					else
					{
						mysql = mysql + ", NULL ";
					}
					mysql = mysql + ", N'" + txtNoOfEmployees.Text + "'";
					mysql = mysql + ", N'" + txtNoOfHours.Text + "'";
					mysql = mysql + ", N'" + txtDesignedBy.Text + "'";
					mysql = mysql + ", " + SystemVariables.gLoggedInUserCode.ToString();

					if (mComponentTransDentedEntryID > 0)
					{
						mysql = mysql + ", " + mComponentTransDentedEntryID.ToString();
					}
					else
					{
						mysql = mysql + ", NULL ";
					}
					mysql = mysql + ") ";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();

					//''''*********************Additional Voucher Details *************************
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_additional_voucher_details"]))
					{
						InsertAdditionalVoucherDetails(mAssembleTransEntryID, "");
					}
					//''''*************************************************************************

				}
				else
				{


					//''''****************************************************************************
					//U '''''''''''''P'''''''''''''D'''''''''''''A'''''''''''''T'''''''''''E
					//''''****************************************************************************

					//''''*********************Make the mAssembleTransEntryID = Searchvalue so that the same
					//'''Variable can be used for both add and edit mode
					//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
					//''''*************************************************************************


					//''''*********************Check the Master table TimeStamp *******************
					mysql = " select assembly_trans_entry_id, component_trans_entry_id, Dented_Trans_Entry_Id ,time_stamp ";
					mysql = mysql + " from ICS_Transaction_Assembly ";
					mysql = mysql + " where entry_id=" + Conversion.Str(mEntryId);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//if the time stamp does not match the previous one then rollback
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAssembleTransEntryID = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mComponentTransEntryID = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mComponentTransDentedEntryID = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(2));
					if (SystemProcedure2.tsFormat(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3))) != mTimeStamp)
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						goto StationRollBackTrans;
					}

					//''''*************************************************************************


					//''''*************************************************************************
					//'''During update of the voucher, update the detail table status to 0
					//'''This will deduct the quantity and help to check the negative stock
					//'''after the details portion is inserted
					//''''*************************************************************************
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " update " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]);
					mysql = mysql + " set status=0 ";
					mysql = mysql + " where entry_id = " + mAssembleTransEntryID.ToString();
					SqlCommand TempCommand_5 = null;
					TempCommand_5 = SystemVariables.gConn.CreateCommand();
					TempCommand_5.CommandText = mysql;
					TempCommand_5.ExecuteNonQuery();

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " update " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]);
					mysql = mysql + " set status=0 ";
					mysql = mysql + " where entry_id = " + mComponentTransEntryID.ToString();
					SqlCommand TempCommand_6 = null;
					TempCommand_6 = SystemVariables.gConn.CreateCommand();
					TempCommand_6.CommandText = mysql;
					TempCommand_6.ExecuteNonQuery();

					if (mComponentTransDentedEntryID > 0)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mysql = " update " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]);
						mysql = mysql + " set status=0 ";
						mysql = mysql + " where entry_id = " + mComponentTransDentedEntryID.ToString();
						SqlCommand TempCommand_7 = null;
						TempCommand_7 = SystemVariables.gConn.CreateCommand();
						TempCommand_7.CommandText = mysql;
						TempCommand_7.ExecuteNonQuery();
					}
					//''''*************************************************************************


					//'''''Delete from Serial No
					//''''*************************************************************************
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("serialized_product"))) == TriState.True)
					{
						mysql = " delete ics_voucher_product_serial_no_details ";
						mysql = mysql + " where voucher_entry_id = " + mAssembleTransEntryID.ToString();
						mysql = mysql + " and voucher_type = " + mHeaderVoucherType.ToString();
						SqlCommand TempCommand_8 = null;
						TempCommand_8 = SystemVariables.gConn.CreateCommand();
						TempCommand_8.CommandText = mysql;
						TempCommand_8.ExecuteNonQuery();

						mysql = " delete ics_voucher_product_serial_no_details ";
						mysql = mysql + " where voucher_entry_id = " + mComponentTransEntryID.ToString();
						mysql = mysql + " and voucher_type = " + mDetailVoucherType.ToString();
						SqlCommand TempCommand_9 = null;
						TempCommand_9 = SystemVariables.gConn.CreateCommand();
						TempCommand_9.CommandText = mysql;
						TempCommand_9.ExecuteNonQuery();
					}
					//''''*************************************************************************


					//''''************************update the sales table****************************
					mysql = " update ICS_Transaction_Assembly ";
					mysql = mysql + " set ";
					mysql = mysql + " approved_by = N'" + txtApprovedBy.Text + "'";
					mysql = mysql + " , assembled_by = N'" + txtAssembledBy.Text + "'";
					if (Information.IsDate(txtDAssembledDate.Value))
					{
						mysql = mysql + " , assembled_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtDAssembledDate.Value) + "'";
					}
					else
					{
						mysql = mysql + " , assembled_date = NULL ";
					}
					mysql = mysql + " , no_of_employees = N'" + txtNoOfEmployees.Text + "'";
					mysql = mysql + " , no_of_hours = N'" + txtNoOfHours.Text + "'";
					mysql = mysql + " , designed_by = N'" + txtDesignedBy.Text + "'";
					mysql = mysql + " , user_cd = " + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " where assembly_trans_entry_id =" + mAssembleTransEntryID.ToString();
					mysql = mysql + " and component_trans_entry_id =" + mComponentTransEntryID.ToString();
					SqlCommand TempCommand_10 = null;
					TempCommand_10 = SystemVariables.gConn.CreateCommand();
					TempCommand_10.CommandText = mysql;
					TempCommand_10.ExecuteNonQuery();


					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = "update " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_table_Name"]);
					mysql = mysql + " set ";
					mysql = mysql + " voucher_date ='" + ReflectionHelper.GetPrimitiveValue<string>(this.txtVoucherDate.Value) + "'";
					mysql = mysql + " , reference_no = '" + this.txtCommonTextBox[SystemICSConstants.tcReferenceNo].Text + "'";
					mysql = mysql + " , comments = N'" + this.txtCommonTextBox[SystemICSConstants.tcComments].Text + "'";
					mysql = mysql + " , user_cd = " + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " , locat_cd = " + Conversion.Str(mLocatCode);
					mysql = mysql + " where entry_Id = " + Conversion.Str(mAssembleTransEntryID);
					SqlCommand TempCommand_11 = null;
					TempCommand_11 = SystemVariables.gConn.CreateCommand();
					TempCommand_11.CommandText = mysql;
					TempCommand_11.ExecuteNonQuery();

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = "update " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_table_Name"]);
					mysql = mysql + " set ";
					mysql = mysql + " voucher_date ='" + ReflectionHelper.GetPrimitiveValue<string>(this.txtVoucherDate.Value) + "'";
					mysql = mysql + " , reference_no = '" + this.txtCommonTextBox[SystemICSConstants.tcReferenceNo].Text + "'";
					mysql = mysql + " , comments = N'" + this.txtCommonTextBox[SystemICSConstants.tcComments].Text + "'";
					mysql = mysql + " , user_cd = " + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " , locat_cd = " + Conversion.Str(mLocatCode);
					mysql = mysql + " where entry_Id = " + Conversion.Str(mComponentTransEntryID);
					SqlCommand TempCommand_12 = null;
					TempCommand_12 = SystemVariables.gConn.CreateCommand();
					TempCommand_12.CommandText = mysql;
					TempCommand_12.ExecuteNonQuery();

					//''''*************************************************************************
					//'''Additional Voucher Details
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_additional_voucher_details"]))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						Cnt = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select count(*) from ICS_Additional_Voucher_Details where entry_id = " + Conversion.Str(mAssembleTransEntryID)));
						if (Cnt == 0)
						{
							InsertAdditionalVoucherDetails(mAssembleTransEntryID, "");
						}
						else
						{
							UpdateAdditionalVoucherDetails(mAssembleTransEntryID);
						}
					}
					//''''*************************************************************************
				}


				mQty = Double.Parse(txtBuildQty.Text);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = " insert into " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Details_table_Name"]);
				mysql = mysql + " ( entry_id, status, prod_cd, prod_name, qty, unit_entry_id  ";
				mysql = mysql + " , base_qty ";

				if (ThisVoucherType == SystemICSConstants.icsBuildAssemblyProduct)
				{
					mysql = mysql + " , add_locat_cd ";
				}
				else
				{
					mysql = mysql + " , less_locat_cd ";
				}
				mysql = mysql + " , fc_amount, fc_prod_dis, fc_rate  ";
				mysql = mysql + " , reference_no ";
				mysql = mysql + " , item_type_cd ";
				mysql = mysql + ") values (";
				mysql = mysql + Conversion.Str(mAssembleTransEntryID); //Entry ID
				mysql = mysql + "," + Conversion.Str(1); //Status
				mysql = mysql + "," + Conversion.Str(mAssembleProductCode); //Product Code
				mysql = mysql + ",'" + mAssembleProductName + "'"; //Product Name
				mysql = mysql + "," + Conversion.Str(mQty); //Qty
				mysql = mysql + "," + Conversion.Str(mAssembleUnitEntryId); //Unit Code
				mysql = mysql + "," + Conversion.Str(mQty); //Base Qty
				mysql = mysql + "," + Conversion.Str(mLocatCode); //Add Locat Code
				mysql = mysql + ", 0, 0, 0 ";
				mysql = mysql + ",N'Auto Generated'";
				mysql = mysql + " ," + mAssemblyItemTypeCd.ToString();
				mysql = mysql + ")";
				SqlCommand TempCommand_13 = null;
				TempCommand_13 = SystemVariables.gConn.CreateCommand();
				TempCommand_13.CommandText = mysql;
				TempCommand_13.ExecuteNonQuery();


				//''''*************************************************************************
				//'''''''''Insert Serial No.
				//''''*************************************************************************
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (grdVoucherDetails.Splits[0].DisplayColumns[gccBuildSerialNoColumn].Visible)
				{
					if (mAssemblySerialized)
					{
						//''''*********Get the Line No ********************************************
						mNewLineNo = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));

						if (!InsertSerializedItem(1, mHeaderVoucherType, mAssembleTransEntryID, mNewLineNo, mLocatCode, 0, mAssembleProductCode, Double.Parse(txtBuildQty.Text), rsAssemblySerialNo))
						{
							cmdBuildSerialNo.Focus();
							goto StationRollBackTrans;
						}
					}
				}
				//''''*************************************************************************



				//''''*************************************************************************
				//'''Insert into stock trans table for Component Items
				//''''*************************************************************************
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{

					//''''*************************************************************************
					//'''Check for the existence of the inventory ICS_Item in the database
					mysql = " select ICS_Item.prod_cd, affect_stock, unit_entry_id ";
					mysql = mysql + " , serialized , it.affect_gl , it.item_type_cd ";
					mysql = mysql + " from ICS_Item, ICS_Item_Types it, ICS_Item_Unit_Details aud ";
					mysql = mysql + " where ICS_Item.prod_cd = aud.prod_cd ";
					mysql = mysql + " and ICS_Item.base_unit_cd = aud.alt_unit_cd ";
					mysql = mysql + " and ICS_Item.item_type_cd = it.item_type_cd ";
					mysql = mysql + " and part_no = '" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildProductCodeColumn)).Trim() + "'";
					//mySql = mySql & " and it.item_type_cd = 1 "

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (!Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_non_inventory_in_details"]))
					{
						mysql = mysql + " and it.affect_stock = 1 ";
					}


					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						MessageBox.Show("invalid Product Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						grdVoucherDetails.Col = gccBuildProductCodeColumn;
						goto StationGridError;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mProductCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mAffectStock = ReflectionHelper.GetPrimitiveValue<bool>(((Array) mTempValue).GetValue(1));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mComponentUnitEntryId = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(2));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mComponentSerialized = ReflectionHelper.GetPrimitiveValue<bool>(((Array) mTempValue).GetValue(3));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mComponentItemTypeCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(5));

						if (!mAffectStock && ReflectionHelper.GetPrimitiveValue<bool>(((Array) mTempValue).GetValue(4)))
						{
							mNonStockManualCost = (decimal) Conversion.Val(StringsHelper.Format(aVoucherDetails.GetValue(Cnt, gccBuildBuildCostColumn), "############0.0##"));
						}
						else
						{
							mNonStockManualCost = 0;
						}

						//''Added by Moiz Hakimion 24-sep-2004
						//''allow group and build ICS_Item only in sales module.
						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("assembly_product")))
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							if (Convert.ToDouble(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["module_id"]) != 6)
							{
								if (mComponentItemTypeCd == 4)
								{ //Commented to allow rebuild mComponentItemTypeCd = 3 Or
									MessageBox.Show("invalid Product Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
									grdVoucherDetails.Col = SystemICSConstants.grdProductCodeColumn;
									goto StationGridError;
								}
							}
						}

					}
					//''''*************************************************************************

					//''''*************************************************************************
					if (Information.IsNumeric(aVoucherDetails.GetValue(Cnt, gccBuildBuildQtyColumn)))
					{
						mQty = Convert.ToDouble(aVoucherDetails.GetValue(Cnt, gccBuildBuildQtyColumn));
					}
					else
					{
						mQty = 0;
					}

					if (mQty <= 0)
					{
						MessageBox.Show("Item Cannot be zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						grdVoucherDetails.Col = gccBuildBuildQtyColumn;
						goto StationGridError;
					}
					//''''*************************************************************************
					if (Information.IsNumeric(aVoucherDetails.GetValue(Cnt, gccBuildBuildCostColumn)))
					{
						mCost = Convert.ToDouble(aVoucherDetails.GetValue(Cnt, gccBuildBuildCostColumn));
					}
					else
					{
						mCost = 0;
					}

					if (Information.IsNumeric(aVoucherDetails.GetValue(Cnt, gccBuildTotalCostColumn)))
					{
						mTotalCost = Convert.ToDouble(aVoucherDetails.GetValue(Cnt, gccBuildTotalCostColumn));
					}
					else
					{
						mTotalCost = 0;
					}



					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " insert into " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Details_table_Name"]);
					mysql = mysql + " ( entry_id, status, prod_cd, prod_name, qty, unit_entry_id  ";
					mysql = mysql + " , base_qty ";

					if (ThisVoucherType == SystemICSConstants.icsBuildAssemblyProduct)
					{
						mysql = mysql + " , less_locat_cd ";
					}
					else
					{
						mysql = mysql + " , add_locat_cd ";
					}
					mysql = mysql + " , fc_amount, fc_prod_dis, fc_rate  ";
					mysql = mysql + " , reference_no ";
					mysql = mysql + " , item_type_cd, non_stock_manual_cost, Linked_Line_No ";
					mysql = mysql + ") values (";
					mysql = mysql + Conversion.Str(mComponentTransEntryID); //Entry ID
					mysql = mysql + "," + Conversion.Str(1); //Status
					mysql = mysql + "," + Conversion.Str(mProductCode); //Product Code

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdVoucherDetails.Splits[0].DisplayColumns[gccBuildProductNameColumn].Visible)
					{
						mysql = mysql + ",N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildProductNameColumn)).Trim() + "'";
					}
					else
					{
						mysql = mysql + ",''";
					}
					mysql = mysql + "," + Conversion.Str(mQty); //qty
					mysql = mysql + "," + Conversion.Str(mComponentUnitEntryId); //Unit Code
					mysql = mysql + "," + Conversion.Str(mQty); //Base Qty
					mysql = mysql + "," + Conversion.Str(mLocatCode); //Add Locat Code
					mysql = mysql + "," + Conversion.Str(mTotalCost);
					mysql = mysql + ",0";
					mysql = mysql + "," + Conversion.Str(mCost);
					mysql = mysql + ",N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildRemarkColumn)).Trim() + "'"; //'Auto Generated'"
					mysql = mysql + ", " + Conversion.Str(mComponentItemTypeCd);
					mysql = mysql + ", " + Conversion.Str(mNonStockManualCost);

					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text, SystemVariables.DataType.NumberType))
					{
						tempSql = "select top 1 Line_No from ICS_Transaction_Details where entry_id = " + linkedEntryId.ToString() + " and prod_cd = " + Conversion.Str(mProductCode);
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(tempSql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempReturnValue))
						{
							mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
						}
						else
						{
							mysql = mysql + ", null ";
						}

					}
					else
					{
						mysql = mysql + ", null ";
					}

					mysql = mysql + ")";
					SqlCommand TempCommand_14 = null;
					TempCommand_14 = SystemVariables.gConn.CreateCommand();
					TempCommand_14.CommandText = mysql;
					TempCommand_14.ExecuteNonQuery();


					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Dented_Stock_Generated_Linked_Voucher_Type"]))
					{
						mysql = " select Item_Type_Cd from ICS_Item where prod_cd=" + mProductCode.ToString();
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{ // And mReturnValue = "1"
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mysql = " insert into " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Details_table_Name"]);
							mysql = mysql + " ( entry_id, status, prod_cd, prod_name, qty, unit_entry_id  ";
							mysql = mysql + " , base_qty ";

							if (ThisVoucherType == SystemICSConstants.icsBuildAssemblyProduct)
							{
								mysql = mysql + " , less_locat_cd ";
							}
							else
							{
								mysql = mysql + " , add_locat_cd ";
							}
							mysql = mysql + " , fc_amount, fc_prod_dis, fc_rate  ";
							mysql = mysql + " , reference_no ";
							mysql = mysql + " , item_type_cd, non_stock_manual_cost, Linked_Line_No ";
							mysql = mysql + ") values (";
							mysql = mysql + Conversion.Str(mComponentTransDentedEntryID); //Entry ID
							mysql = mysql + "," + Conversion.Str(1); //Status
							mysql = mysql + "," + Conversion.Str(mProductCode); //Product Code

							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							if (grdVoucherDetails.Splits[0].DisplayColumns[gccBuildProductNameColumn].Visible)
							{
								mysql = mysql + ",N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildProductNameColumn)).Trim() + "'";
							}
							else
							{
								mysql = mysql + ",''";
							}
							mysql = mysql + "," + Conversion.Str(mQty); //qty
							mysql = mysql + "," + Conversion.Str(mComponentUnitEntryId); //Unit Code
							mysql = mysql + "," + Conversion.Str(mQty); //Base Qty
							mysql = mysql + "," + Conversion.Str(mLocatCode); //Add Locat Code
							mysql = mysql + "," + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildTotalCostColumn)).Trim();
							mysql = mysql + ",0";
							mysql = mysql + "," + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildBuildCostColumn)).Trim();
							mysql = mysql + ",N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBuildRemarkColumn)).Trim() + "'"; //'Auto Generated'"
							mysql = mysql + ", " + Conversion.Str(mComponentItemTypeCd);
							mysql = mysql + ", " + Conversion.Str(mNonStockManualCost);

							if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text, SystemVariables.DataType.NumberType))
							{
								tempSql = "select top 1 Line_No from ICS_Transaction_Details where entry_id = " + linkedEntryId.ToString() + " and prod_cd = " + Conversion.Str(mProductCode);
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(tempSql));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (!Convert.IsDBNull(mTempReturnValue))
								{
									mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
								}
								else
								{
									mysql = mysql + ", null ";
								}

							}
							else
							{
								mysql = mysql + ", null ";
							}

							mysql = mysql + ")";
							SqlCommand TempCommand_15 = null;
							TempCommand_15 = SystemVariables.gConn.CreateCommand();
							TempCommand_15.CommandText = mysql;
							TempCommand_15.ExecuteNonQuery();
						}
					}


					//''''*************************************************************************
					//'''''''''Insert Serial No.
					//''''*************************************************************************
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdVoucherDetails.Splits[0].DisplayColumns[gccBuildSerialNoColumn].Visible)
					{
						if (mComponentSerialized)
						{
							//''''*********Get the Line No ********************************************
							mNewLineNo = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));


							if (!InsertSerializedItem(Convert.ToInt32(aVoucherDetails.GetValue(Cnt, gccBuildLineNoColumn)), mDetailVoucherType, mComponentTransEntryID, mNewLineNo, mLocatCode, mLocatCode, mProductCode, mQty, rsComponentSerialNo))
							{
								grdVoucherDetails.Col = gccBuildSerialNoColumn;
								goto StationGridError;
							}
						}
					}
					//''''*************************************************************************
				}


				//''''*************************************************************************
				//''''Post of Inventory
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["auto_post_ics"]))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						SystemICSProcedure.PostTransactionToIcs(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_Name"]), mAssembleTransEntryID);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						SystemICSProcedure.PostTransactionToIcs(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_Name"]), mComponentTransEntryID);

						if (mComponentTransDentedEntryID > 0)
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemICSProcedure.PostTransactionToIcs(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_Name"]), mComponentTransDentedEntryID);
						}
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["auto_post_gl_party"]))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						SystemICSProcedure.PostTransactionToGLParty(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]), mAssembleTransEntryID);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						SystemICSProcedure.PostTransactionToGLParty(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]), mComponentTransEntryID);

						if (mComponentTransDentedEntryID > 0)
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemICSProcedure.PostTransactionToGLParty(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_Name"]), mComponentTransDentedEntryID);
						}
					}

					//    If rsVoucherTypes("auto_post_status") = True Then
					//        Call ApproveTransaction(rsVoucherTypes("master_table_name"), mAssembleTransEntryID)
					//        Call ApproveTransaction(rsVoucherTypes("master_table_name"), mComponentTransEntryID)
					//    End If
				}
				else
				{

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " update  " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]);
					mysql = mysql + " set posted_invnt = posted_invnt ";
					mysql = mysql + " where entry_id = " + Conversion.Str(mAssembleTransEntryID);
					SqlCommand TempCommand_16 = null;
					TempCommand_16 = SystemVariables.gConn.CreateCommand();
					TempCommand_16.CommandText = mysql;
					TempCommand_16.ExecuteNonQuery();

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " update  " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]);
					mysql = mysql + " set posted_invnt = posted_invnt ";
					mysql = mysql + " where entry_id = " + Conversion.Str(mComponentTransEntryID);
					SqlCommand TempCommand_17 = null;
					TempCommand_17 = SystemVariables.gConn.CreateCommand();
					TempCommand_17.CommandText = mysql;
					TempCommand_17.ExecuteNonQuery();

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " update  " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]);
					mysql = mysql + " set posted_gl_party = posted_gl_party ";
					mysql = mysql + " where entry_id = " + Conversion.Str(mAssembleTransEntryID);
					SqlCommand TempCommand_18 = null;
					TempCommand_18 = SystemVariables.gConn.CreateCommand();
					TempCommand_18.CommandText = mysql;
					TempCommand_18.ExecuteNonQuery();

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " update  " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]);
					mysql = mysql + " set posted_gl_party = posted_gl_party ";
					mysql = mysql + " where entry_id = " + Conversion.Str(mComponentTransEntryID);
					SqlCommand TempCommand_19 = null;
					TempCommand_19 = SystemVariables.gConn.CreateCommand();
					TempCommand_19.CommandText = mysql;
					TempCommand_19.ExecuteNonQuery();

					if (mComponentTransDentedEntryID > 0)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mysql = " update  " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]);
						mysql = mysql + " set posted_invnt = posted_invnt ";
						mysql = mysql + " where entry_id = " + Conversion.Str(mComponentTransDentedEntryID);
						SqlCommand TempCommand_20 = null;
						TempCommand_20 = SystemVariables.gConn.CreateCommand();
						TempCommand_20.CommandText = mysql;
						TempCommand_20.ExecuteNonQuery();

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mysql = " update  " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]);
						mysql = mysql + " set posted_gl_party = posted_gl_party ";
						mysql = mysql + " where entry_id = " + Conversion.Str(mComponentTransDentedEntryID);
						SqlCommand TempCommand_21 = null;
						TempCommand_21 = SystemVariables.gConn.CreateCommand();
						TempCommand_21.CommandText = mysql;
						TempCommand_21.ExecuteNonQuery();
					}
				}
				//''''*************************************************************************

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					if (IsNegativeStock(1, mAssembleTransEntryID, false, 0, 0, ref mErrorMsg))
					{
						//grdVoucherDetails.SetFocus
						goto StationRollBackNegativeStockTrans;
					}

					//''Change the voucher type to detail and then back to header voucher type
					if (IsNegativeStock(1, mComponentTransEntryID, false, mDetailVoucherType, mHeaderVoucherType, ref mErrorMsg))
					{
						//grdVoucherDetails.SetFocus
						goto StationRollBackNegativeStockTrans;
					}
				}
				else if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{ 
					if (IsNegativeStock(2, mAssembleTransEntryID, false, 0, 0, ref mErrorMsg))
					{
						//grdVoucherDetails.SetFocus
						goto StationRollBackNegativeStockTrans;
					}

					if (IsNegativeStock(2, mComponentTransEntryID, false, mDetailVoucherType, mHeaderVoucherType, ref mErrorMsg))
					{
						//grdVoucherDetails.SetFocus
						goto StationRollBackNegativeStockTrans;
					}
				}


				//''''*************************************************************************
				//'''After the negative stock check is done then
				//'''Delete the items with status 0
				//''''*************************************************************************
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " delete from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]);
					mysql = mysql + " where entry_id = " + mAssembleTransEntryID.ToString();
					mysql = mysql + " and status=0 ";
					SqlCommand TempCommand_22 = null;
					TempCommand_22 = SystemVariables.gConn.CreateCommand();
					TempCommand_22.CommandText = mysql;
					TempCommand_22.ExecuteNonQuery();

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " delete from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]);
					mysql = mysql + " where entry_id = " + mComponentTransEntryID.ToString();
					mysql = mysql + " and status=0 ";
					SqlCommand TempCommand_23 = null;
					TempCommand_23 = SystemVariables.gConn.CreateCommand();
					TempCommand_23.CommandText = mysql;
					TempCommand_23.ExecuteNonQuery();

					if (mComponentTransDentedEntryID > 0)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mysql = " delete from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]);
						mysql = mysql + " where entry_id = " + mComponentTransDentedEntryID.ToString();
						mysql = mysql + " and status=0 ";
						SqlCommand TempCommand_24 = null;
						TempCommand_24 = SystemVariables.gConn.CreateCommand();
						TempCommand_24.CommandText = mysql;
						TempCommand_24.ExecuteNonQuery();
					}
				}
				//''''*************************************************************************


				//''''*************************************************************************
				//Approve (Change the status to 2)
				if (pApprove)
				{
					//Call ApproveTransaction(rsVoucherTypes("master_table_name"), mAssembleTransEntryID)
					mysql = " update ICS_Transaction_Assembly ";
					mysql = mysql + " set status = 2 ";
					//mySql = mySql & " where entry_id = " & Str(mEntryID)
					mysql = mysql + " where component_trans_entry_id = " + Conversion.Str(mComponentTransEntryID);
					mysql = mysql + " and assembly_trans_entry_id = " + Conversion.Str(mAssembleTransEntryID);
					SqlCommand TempCommand_25 = null;
					TempCommand_25 = SystemVariables.gConn.CreateCommand();
					TempCommand_25.CommandText = mysql;
					TempCommand_25.ExecuteNonQuery();

					//If rsVoucherTypes("allow_online_gl_post") = True Then
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemICSProcedure.PostTransactionToGL(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]), mAssembleTransEntryID);
					//End If

					//''Change the Status of the ics_voucher_product_serial_no_details
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("serialized_product"))) == TriState.True)
					{
						if (!SystemICSProcedure.PostSerialItems(mHeaderVoucherType, mAssembleTransEntryID))
						{
							goto StationRollBackTrans;
						}
					}


					//Call ApproveTransaction(rsVoucherTypes("master_table_name"), mComponentTransEntryID)
					//If rsVoucherTypes("allow_online_gl_post") = True Then
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemICSProcedure.PostTransactionToGL(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]), mComponentTransEntryID);
					//End If

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("serialized_product"))) == TriState.True)
					{
						if (!SystemICSProcedure.PostSerialItems(mDetailVoucherType, mComponentTransEntryID))
						{
							goto StationRollBackTrans;
						}
					}
				}
				//''''*************************************************************************


				//''''*************************************************************************
				SystemICSProcedure.SaveLastTransactionInfo(Convert.ToInt32(Conversion.Val(this.txtCommonTextBox[SystemICSConstants.tcLocationCode].Text)));
				//''''*************************************************************************

				//'**-- save current voucher preferences in ICS_Transaction_Types table
				//'**-- e.g. last transaction was cash/credit , last cash code etc
				//If rsVoucherTypes("restore_last_tran_setting").Value = vbTrue Then
				//    Dim mOldVoucherType As Long
				//
				//    mOldVoucherType = rsVoucherTypes("voucher_type").Value
				//
				//    mysql = "update ICS_Transaction_Types "
				//    mysql = mysql & " set last_tran_locat_no = " & IIf(IsItEmpty(Me.txtCommonTextBox(tcLocationCode).Text, StringType) = False, Trim(Me.txtCommonTextBox(tcLocationCode).Text), " null")
				//    mysql = mysql & " where voucher_type = " & rsVoucherTypes("voucher_type").Value
				//    gConn.Execute mysql
				//
				//    With rsVoucherTypes
				//        .ActiveConnection = gConn
				//        .Requery
				//        .ActiveConnection = Nothing
				//        .MoveFirst
				//        .Find "voucher_type = " & mOldVoucherType
				//    End With
				//End If
				//'**--------------------------------------------------------------------------------

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();


				//''''*************************************************************************
				//Display a messbox if the auto generate voucher no is true and it is in addmode
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = SystemConstants.msg20 + mVoucherNo.ToString();
					MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				//**-- check if voucher is supposed to be printed
				//**-- after saving it. if so call print routine
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["print_after_save"]))
				{

					ans = MessageBox.Show(SystemConstants.msg25, "Expert Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						PrintReport(mComponentTransEntryID);
					}
				}
				//''''*************************************************************************

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
				return result;
				//''''*************************************************************************

				//''''*************************************************************************
				StationRollBackNegativeStockTrans:
				//This code is executed when there is error after begin trans
				result = false;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				MessageBox.Show(mErrorMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				grdVoucherDetails.Focus();
				return result;
				//''''*************************************************************************

				//''''*************************************************************************
				//This code is executed when there is error in the Grid
				StationGridError:
				grdVoucherDetails.Bookmark = Cnt;
				grdVoucherDetails.Focus();
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

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_table_Name"]), "GetRecord", SystemConstants.msg10);
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

		public void DisplayBuildInfo()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;

				string mysql = " select ICS_Item.part_no ";
				mysql = mysql + "," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "ICS_Item.l_prod_name" : "ICS_Item.a_prod_name") + " as prod_name ";
				mysql = mysql + ", symbol as symbol ";
				mysql = mysql + ", pad.component_base_qty as qty ";
				mysql = mysql + ", ICS_Item.serialized as serialized ";
				mysql = mysql + " from ICS_Item_assembly_details pad ";
				mysql = mysql + " inner join ICS_Item on pad.component_prod_cd = ICS_Item.prod_cd ";
				mysql = mysql + " inner join ICS_Unit on ICS_Item.base_unit_cd = ICS_Unit.unit_cd ";

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				object mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select prod_cd from ICS_Item where part_no ='" + this.txtCommonTextBox[tcProductCode].Text + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempReturnValue))
				{
					mysql = mysql + " where assembly_prod_cd = 0";
				}
				else
				{
					mysql = mysql + " where assembly_prod_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
				}

				SqlDataReader rsLocalRec = null;
				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand.ExecuteReader();
				rsLocalRec.Read();
				do 
				{
					SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, Cnt, false);

					aVoucherDetails.SetValue(Cnt + 1, Cnt, gccBuildLineNoColumn);
					aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["part_no"]).Trim(), Cnt, gccBuildProductCodeColumn);
					aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["prod_name"]).Trim(), Cnt, gccBuildProductNameColumn);
					aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["symbol"]).Trim(), Cnt, gccBuildUnitSymbolColumn);

					aVoucherDetails.SetValue(rsLocalRec["qty"], Cnt, gccBuildQtyColumn);
					aVoucherDetails.SetValue(rsLocalRec["serialized"], Cnt, gccBuildSerializedColumn);
					aVoucherDetails.SetValue("...", Cnt, gccBuildSerialNoColumn);
					aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["symbol"]).Trim(), Cnt, gccBuildUnitSymbolColumn);

					Cnt++;
				}
				while(rsLocalRec.Read());

				RefreshRecordset();

				CalculateTotals(0, 0);
				grdVoucherDetails.Rebind(true);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void ShowSerialNo(string pProductCode, string pTotalSerialNo)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				frmICSSerialNo oVoucherSerialNo = frmICSSerialNo.CreateInstance();
				DataSet rsCloneRecordset = null;
				object mReturnValue = null;
				string mysql = "";

				if (!SystemProcedure2.IsItEmpty(pProductCode, SystemVariables.DataType.StringType) && !SystemProcedure2.IsItEmpty(pTotalSerialNo, SystemVariables.DataType.NumberType))
				{
					//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsProductCodeList.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsCloneRecordset = rsProductCodeList.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsCloneRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsCloneRecordset.MoveFirst();
					rsCloneRecordset.Find("part_no='" + pProductCode + "'");
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCloneRecordset.BOF was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					if (rsCloneRecordset.Tables[0].Rows.Count != 0 || rsCloneRecordset.getBOF())
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(rsCloneRecordset.Tables[0].Rows[0]["serialized"])) == TriState.True)
						{
							oVoucherSerialNo.SetVoucherSourceRecordSet = rsComponentSerialNo;
							//.FormMode = Me.CurrentFormMode
							oVoucherSerialNo.VoucherType = mDetailVoucherType;

							//UPGRADE_WARNING: (1068) grdVoucherDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							oVoucherSerialNo.LineNo = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[gccBuildLineNoColumn].Value);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							oVoucherSerialNo.ProductCode = Convert.ToInt32(rsCloneRecordset.Tables[0].Rows[0]["prod_cd"]);
							oVoucherSerialNo.TotalSerialNo = Convert.ToInt32(Double.Parse(pTotalSerialNo));

							//''Get Location Code
							if (SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcLocationCode].Text, SystemVariables.DataType.NumberType))
							{
								MessageBox.Show("Invalid Location Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								if (txtCommonTextBox[SystemICSConstants.tcLocationCode].Enabled)
								{
									txtCommonTextBox[SystemICSConstants.tcLocationCode].Focus();
								}
								goto UnloadSerialNoVoucher;
							}
							else
							{
								mysql = " select locat_cd from SM_Location where locat_no=" + txtCommonTextBox[SystemICSConstants.tcLocationCode].Text;
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (Convert.IsDBNull(txtCommonTextBox[SystemICSConstants.tcLocationCode].Text))
								{
									MessageBox.Show("Invalid Location Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									if (txtCommonTextBox[SystemICSConstants.tcLocationCode].Enabled)
									{
										txtCommonTextBox[SystemICSConstants.tcLocationCode].Focus();
									}
									goto UnloadSerialNoVoucher;
								}
							}

							oVoucherSerialNo.LocatCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);

							//.Left = 90
							//oVoucherSerialNo.Top = 1050 + (Me.Top + grdVoucherDetails.Top + grdVoucherDetails.Height) - oVoucherSerialNo.Height

							//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							//VB.Global.Load(oVoucherSerialNo);
							oVoucherSerialNo.ShowDialog();


							goto UnloadSerialNoVoucher;
						}
					}

					rsCloneRecordset = null;
				}
				return;

				UnloadSerialNoVoucher:
				oVoucherSerialNo.Close();
				oVoucherSerialNo = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private bool InsertSerializedItem(int pGridLineNo, int pVoucherType, int pEntryId, int pLineNo, int pLocatCd, int pLocatCd2, int pProdCd, double pQty, DataSet pRsSerialNo)
		{
			//Private Function InsertSerializedItem(pGridLineNo As Integer, pParentLineNo As Integer, pVoucherType As Integer, pEntryId As Long, pLineNo As Long, pLocatCd As Long, pLocatCd2 As Long, pProdCd As Long, pQty As Double, pRec As ADODB.Recordset) As Boolean
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				int mSerialNo = 0;
				double mSerialQty = 0;
				bool mAllowAddSerialNoWhenNotExists = false;
				string mAddOrLess = "";

				string mysql = " select Add_Or_Less , allow_add_serial_no_when_not_exists from ICS_Transaction_Types ";
				mysql = mysql + " where voucher_type=" + pVoucherType.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAddOrLess = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAllowAddSerialNoWhenNotExists = ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(1));
				}
				else
				{
					goto StationExit;
				}


				if (pRsSerialNo.Tables[0].Rows.Count > 0)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method pRsSerialNo.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					pRsSerialNo.MoveFirst();
					pRsSerialNo.Tables[0].DefaultView.RowFilter = "lineno=" + pGridLineNo.ToString();

					if (pRsSerialNo.Tables[0].Rows.Count != 0)
					{
						foreach (DataRow iteration_row in pRsSerialNo.Tables[0].Rows)
						{
							ADODB.Field tempForEndVar = null;
							//UPGRADE_ISSUE: (2064) ADODB.Field20 property tempForEndVar.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							tempForEndVar.setValue(iteration_row["ToSerialNo"]);
							for (mSerialNo = Convert.ToInt32(iteration_row["FromSerialNo"]); mSerialNo <= Convert.ToDouble(tempForEndVar); mSerialNo++)
							{
								mSerialQty++;

								mysql = " select locat_cd, status ";
								mysql = mysql + " from ICS_Item_serial_no_details ";
								mysql = mysql + " where prod_cd=" + pProdCd.ToString();
								mysql = mysql + " and serial_no=" + mSerialNo.ToString();
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (Convert.IsDBNull(mReturnValue))
								{
									if (mAllowAddSerialNoWhenNotExists == (TriState.False != TriState.False))
									{
										mysql = " Serial No:" + mSerialNo.ToString() + " does not exists.";
										MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
										goto StationExit;
									}
									else
									{
										goto StationOK;
									}
								}
								else
								{
									if (mAddOrLess == "A")
									{
										if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1)) == 2)
										{ //'If Add and stock not in hand
											goto StationOK;
										}
										else
										{
											mysql = " select ";
											mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name");
											mysql = mysql + " from SM_Location ";
											mysql = mysql + " where locat_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
											//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
											mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

											mysql = " Serial No:" + mSerialNo.ToString() + " already exists in location " + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
											MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
											goto StationExit;
										}
									}

									if (mAddOrLess == "L")
									{
										if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1)) == 1)
										{ //'If Add and stock in hand
											if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0)) == pLocatCd)
											{
												goto StationOK;
											}
											else
											{
												mysql = " select ";
												mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name");
												mysql = mysql + " from SM_Location ";
												mysql = mysql + " where locat_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
												//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
												mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

												mysql = " Serial No:" + mSerialNo.ToString() + " already exists in location " + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
												MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
												goto StationExit;
											}
										}
									}
								}

								StationOK:
								mysql = " insert into ics_voucher_product_serial_no_details ";
								mysql = mysql + " (voucher_type, voucher_entry_id, line_no, prod_cd ";
								mysql = mysql + " , locat_cd , locat_cd2, serial_no ";
								mysql = mysql + " , status, from_serial_no, to_serial_no, user_cd ) ";
								mysql = mysql + " values(";
								mysql = mysql + pVoucherType.ToString(); //Voucher Type
								mysql = mysql + ", " + pEntryId.ToString(); //Entry ID
								mysql = mysql + ", " + pLineNo.ToString(); //Line No
								mysql = mysql + ", " + pProdCd.ToString(); //Product Code
								mysql = mysql + ", " + pLocatCd.ToString(); //Locat Code

								if (!SystemProcedure2.IsItEmpty(pLocatCd2, SystemVariables.DataType.NumberType))
								{
									mysql = mysql + ", " + pLocatCd2.ToString(); //Locat Code 2
								}
								else
								{
									mysql = mysql + ",NULL "; //Locat Code 2
								}

								mysql = mysql + ", " + mSerialNo.ToString(); //Serial No.
								mysql = mysql + ", 1"; //Status
								mysql = mysql + ", " + Convert.ToString(iteration_row["FromSerialNo"]); //From Serial No.
								mysql = mysql + ", " + Convert.ToString(iteration_row["ToSerialNo"]); //To Serial No.
								mysql = mysql + ", " + SystemVariables.gLoggedInUserCode.ToString(); //UserCd
								mysql = mysql + ") ";
								SqlCommand TempCommand = null;
								TempCommand = SystemVariables.gConn.CreateCommand();
								TempCommand.CommandText = mysql;
								TempCommand.ExecuteNonQuery();

							}

						}
					}
					else
					{
						mysql = " Serial No. required. ";
						MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						goto StationExit;
					}

					//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					pRsSerialNo.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();

					if (mSerialQty != pQty)
					{
						mysql = " Quantity does not match with Serial No. ";
						MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						goto StationExit;
					}
				}
				else
				{
					mysql = " Serial No. required. ";
					MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					goto StationExit;
				}


				return true;

				StationExit:;}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}


			return false;
		}

		private void ShowAssemblySerialNo(string pProductCode, string pTotalSerialNo)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				frmICSSerialNo oVoucherSerialNo = frmICSSerialNo.CreateInstance();
				object mReturnValue = null;
				string mysql = "";

				if (!SystemProcedure2.IsItEmpty(pProductCode, SystemVariables.DataType.StringType) && !SystemProcedure2.IsItEmpty(pTotalSerialNo, SystemVariables.DataType.NumberType))
				{
					mysql = " select prod_cd, serialized from ICS_Item ";
					mysql = mysql + " where part_no='" + pProductCode + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1))) == TriState.True)
						{
							oVoucherSerialNo.SetVoucherSourceRecordSet = rsAssemblySerialNo;
							//.FormMode = Me.CurrentFormMode
							oVoucherSerialNo.VoucherType = mHeaderVoucherType;

							oVoucherSerialNo.LineNo = 1;
							//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							oVoucherSerialNo.ProductCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
							oVoucherSerialNo.TotalSerialNo = Convert.ToInt32(Double.Parse(pTotalSerialNo));

							//''Get Location Code
							if (SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcLocationCode].Text, SystemVariables.DataType.NumberType))
							{
								MessageBox.Show("Invalid Location Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								if (txtCommonTextBox[SystemICSConstants.tcLocationCode].Enabled)
								{
									txtCommonTextBox[SystemICSConstants.tcLocationCode].Focus();
								}
								goto UnloadSerialNoVoucher;
							}
							else
							{
								mysql = " select locat_cd from SM_Location where locat_no=" + txtCommonTextBox[SystemICSConstants.tcLocationCode].Text;
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (Convert.IsDBNull(txtCommonTextBox[SystemICSConstants.tcLocationCode].Text))
								{
									MessageBox.Show("Invalid Location Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									if (txtCommonTextBox[SystemICSConstants.tcLocationCode].Enabled)
									{
										txtCommonTextBox[SystemICSConstants.tcLocationCode].Focus();
									}
									goto UnloadSerialNoVoucher;
								}
							}

							oVoucherSerialNo.LocatCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);

							//.Left = 90
							//oVoucherSerialNo.Top = 1050 + (Me.Top + grdVoucherDetails.Top + grdVoucherDetails.Height) - oVoucherSerialNo.Height

							//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							//VB.Global.Load(oVoucherSerialNo);
							oVoucherSerialNo.ShowDialog();


							goto UnloadSerialNoVoucher;
						}
					}
				}
				return;

				UnloadSerialNoVoucher:
				oVoucherSerialNo.Close();
				oVoucherSerialNo = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void InitialiseGridValues()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (grdVoucherDetails.Splits[0].DisplayColumns[gccBuildSerialNoColumn].Visible)
				{
					grdVoucherDetails.Columns[gccBuildSerializedColumn].Text = ((int) TriState.False).ToString();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}


		private bool IsSerialNoRequired(string pDetailLocationNo, string pSerialized)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				bool mSerialized = false;
				if (pSerialized == "")
				{
					mSerialized = false;
				}
				else
				{
					bool tempBool = false;
					mSerialized = (Boolean.TryParse(pSerialized, out tempBool)) ? tempBool : Convert.ToBoolean(Double.Parse(pSerialized));

					//''''Product may be serialised but show serial no. in details may be false
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (!grdVoucherDetails.Splits[0].DisplayColumns[gccBuildSerialNoColumn].Visible)
					{
						mSerialized = false;
					}
				}

				if (mSerialized)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Affect_On_Hand_Stock"])) == TriState.True)
					{
						goto Yes;
					}
					else
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_location_in_details"])) == TriState.True)
						{
							if (txtCommonTextBox[SystemICSConstants.tcLocationCode].Text == pDetailLocationNo)
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
								if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["auto_generate_linked_voucher"])) == TriState.True)
								{
									goto Yes;
								}
								else
								{
									goto No;
								}
							}
							else
							{
								goto No;
							}
						}
						else
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
							if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["auto_generate_linked_voucher"])) == TriState.True)
							{
								goto Yes;
							}
							else
							{
								goto No;
							}
						}
					}
				}
				else
				{
					goto No;
				}

				Yes:
				return true;

				No:;}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

			return false;
		}


		private void grdVoucherDetails_BeforeColUpdate(object eventSender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			object OldValue = eventArgs.OldValue;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{

					if (ColIndex == gccBuildProductCodeColumn || ColIndex == gccBuildProductNameColumn)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[gccBuildSerialNoColumn].Visible == (TriState.True != TriState.False))
						{
							Cancel = (!SystemICSProcedure.DeleteCurrentLine(rsComponentSerialNo, Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[gccBuildLineNoColumn].Value))), true, " Serial No. Details ")) ? -1 : 0;
						}
					}
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			//'***************************************************************************''
			//'This routine handles the listbox attributes on the grid according to the
			//'datasource. It gives the width of columns in the listbox and sort order.
			//'***************************************************************************''
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				int Cnt = 0;
				cmbMastersList.Width = 0;
				C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
				switch(grdVoucherDetails.Col)
				{
					case gccBuildProductCodeColumn : case gccBuildProductNameColumn : 
						if (grdVoucherDetails.Col == gccBuildProductCodeColumn)
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
						for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
						{
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							withVar = cmbMastersList.Splits[0].DisplayColumns[Cnt];
							if (Cnt < 2)
							{
								switch(Cnt)
								{
									case 0 : 
										//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
										withVar.setOrder((grdVoucherDetails.Col == gccBuildProductCodeColumn) ? 0 : 1); 
										//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
										withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccBuildProductCodeColumn].Width; 
										withVar.Visible = true; 
										break;
									case 1 : 
										//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
										withVar.setOrder((grdVoucherDetails.Col == gccBuildProductCodeColumn) ? 1 : 0); 
										//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
										withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccBuildProductNameColumn].Width; 
										withVar.Visible = true; 
										break;
									case 2 : 
										//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
										withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccBuildUnitSymbolColumn].Width; 
										withVar.Visible = true; 
										break;
									case 3 : 
										//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
										//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021 
										if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Group_In_List"])) == TriState.True)
										{
											withVar.Width = 120;
											withVar.Visible = true;
										}
										else
										{
											withVar.Width = 0;
											withVar.Visible = false;
										} 
										break;
									case 4 : 
										//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
										//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021 
										if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Category_In_List"])) == TriState.True)
										{
											withVar.Width = 120;
											withVar.Visible = true;
										}
										else
										{
											withVar.Width = 0;
											withVar.Visible = false;
										} 
										break;
									case 18 : 
										withVar.Visible = true; 
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
						if (grdVoucherDetails.Row < 3)
						{
							cmbMastersList.Height = 180;
						}
						else
						{
							cmbMastersList.Height = Convert.ToInt32(173 - ((grdVoucherDetails.Row - 2) * grdVoucherDetails.RowHeight));
						} 
						break;
					default:
						cmbMastersList.Width = 0; 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			//'***************************************************************************''
			//'This routine handles the navigation for next column after a value is selected
			//'from listbox in the grid.
			//'***************************************************************************''
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				switch(grdVoucherDetails.Col)
				{
					case gccBuildProductCodeColumn : 
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
						if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_product_name_in_details"]))
						{
							grdVoucherDetails.Col = gccBuildProductNameColumn;
						} 
						break;
					case gccBuildProductNameColumn : case gccBuildUnitSymbolColumn : case SystemICSConstants.grdLocationCodeColumn : 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			//'***************************************************************************''
			//'This routine handles the display of ICS_Itemname when a ProductCode is selected
			//'and vice versa. It also show the value in status bar after checking the
			//'"rsvouchertype" recordset values.
			//'
			//'NOTE: The value in ICS_Unit list box relies on ICS_Item code column
			//'So even if the ICS_Item code column "Visible=False", it should consists the code.
			//'***************************************************************************''
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				C1.Win.C1TrueDBGrid.C1DataColumnCollection withVar = null;
				C1.Win.C1TrueDBGrid.C1DataColumnCollection withVar_2 = null;
				if (grdVoucherDetails.Col == gccBuildProductCodeColumn || grdVoucherDetails.Col == gccBuildProductNameColumn)
				{
					//'''''''''''''''''''''''''''''''''''''''''''''''''
					//''The below "if" checks for the bookmark of the listbox
					//''If the ICS_Item code or ICS_Item name does not match the value in listbox
					//''then the value should not be fetched.
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(cmbMastersList.Bookmark))
					{
						withVar = grdVoucherDetails.Columns;
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (grdVoucherDetails.Col == gccBuildProductCodeColumn && Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Name_In_Details"]))
						{
							//If cmbMastersList.Columns(cCpProdName).Value = "" Then
							withVar[gccBuildProductNameColumn].DataColumn.Value = cmbMastersList.Columns[cCpProdName].Value;
							//End If
						}
						else
						{
							withVar[gccBuildProductCodeColumn].DataColumn.Value = cmbMastersList.Columns[cCpPartNo].Value;
						}

						if (withVar[gccBuildUnitSymbolColumn].Visible)
						{
							withVar[gccBuildUnitSymbolColumn].DataColumn.Value = cmbMastersList.Columns[cCpSymbol].Value;
						}

						if (withVar[gccBuildSerialNoColumn].Visible)
						{
							withVar[gccBuildSerializedColumn].DataColumn.Value = cmbMastersList.Columns[cCpSerialised].Value;
						}
						withVar[gccBuildBuildCostColumn].DataColumn.Value = cmbMastersList.Columns[cCpCost].Value;


						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Base_Unit_In_Status"]))
						{
							UCStatusBar.FindPane(SystemICSConstants.lcBaseUnit2).Text = ReflectionHelper.GetPrimitiveValue<string>(cmbMastersList.Columns[cCpSymbol].Value);
						}

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Stock_In_Hand_In_Status"]))
						{
							UCStatusBar.FindPane(SystemICSConstants.lcStockInHand2).Text = ReflectionHelper.GetPrimitiveValue<string>(cmbMastersList.Columns[cCpStockInHand].Value);
						}

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Stock_Allocated_In_Status"]))
						{
							UCStatusBar.FindPane(SystemICSConstants.lcStockAllocated2).Text = ReflectionHelper.GetPrimitiveValue<string>(cmbMastersList.Columns[cCpStockAllocated].Value);
						}

						//        If rsVoucherTypes("Show_In_Transit_Stock_In_Status") = True Then
						//            UCStatusBar.FindPane(lcStockInTransit2).Text = CStr(cmbMastersList.Columns(cCpStockInTransit).Value)
						//        End If
						//
						//        If rsVoucherTypes("Show_Stock_Available_In_Status") = True Then
						//            UCStatusBar.FindPane(lcStockAvailable2).Text = CStr(cmbMastersList.Columns(cCpStockAvailable).Value)
						//        End If
					}
					else
					{
						withVar_2 = grdVoucherDetails.Columns;
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (grdVoucherDetails.Col == gccBuildProductCodeColumn && Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Name_In_Details"]))
						{
							withVar_2[gccBuildProductNameColumn].DataColumn.Value = "";
						}
						else
						{
							withVar_2[gccBuildProductCodeColumn].DataColumn.Value = "";
						}
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void IRoutine()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				if (ActiveControl.Name != "grdVoucherDetails")
				{
					grdVoucherDetails.Focus();
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(grdVoucherDetails.Bookmark))
				{
					//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), 1);
					AssignGridLineNumbers();
					grdVoucherDetails.Rebind(true);
					grdVoucherDetails.Focus();
					grdVoucherDetails.Refresh();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void LRoutine()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
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
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void AssignGridLineNumbers()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					aVoucherDetails.SetValue(Cnt + 1, Cnt, gccBuildLineNoColumn);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void ClearAdditionalVoucherDetails()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//''''*************************************************************************
				//'''Clear the Additional details form
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_additional_voucher_details"]))
				{
					objAdditionalDetails.Close();
					objAdditionalDetails = null;
					objAdditionalDetailsInitialised = false;
					//On Error GoTo eFoundError
				}
				//''''*************************************************************************
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void InsertAdditionalVoucherDetails(int pEntryId, string pLdgrCd)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				string tempSql = "";
				object mTempValue = null;

				string mysql = " Insert into ICS_Additional_Voucher_Details ";
				mysql = mysql + " (entry_id, ldgr_name, addr_1, addr_2, phone, street, block_no ";
				mysql = mysql + " , city , country, reference_order_no, reference_order_date ";
				mysql = mysql + " , cheque_no, cheque_date , credit_card_no, credit_card_date ";
				mysql = mysql + " , pay_mode_cd, drawn_on_bank ";
				if (objAdditionalDetailsInitialised)
				{
					mysql = mysql + " , shipment_mode, shipment_no_type, shipment_no, packing_list_no";
					//mysql = mysql & " , received_by, delivery_by_period, delivery_to_location, payment_terms"
					mysql = mysql + " , delivery_by_period, delivery_to_location, payment_terms";
					mysql = mysql + " , delivery_terms , additional_expenses, trans_type ";
				}
				//mysql = mysql & " , cash_amt , credit_card_amt, change_amt, cash_ldgr_cd, credit_card_ldgr_cd "
				mysql = mysql + " ) values(";

				if (objAdditionalDetailsInitialised)
				{
					mysql = mysql + pEntryId.ToString();
					mysql = mysql + " , N'" + objAdditionalDetails.txtLdgrName.Text + "'";
					mysql = mysql + " , N'" + objAdditionalDetails.txtAdd1.Text + "'";
					mysql = mysql + " , N'" + objAdditionalDetails.txtAdd2.Text + "'";
					mysql = mysql + " , N'" + objAdditionalDetails.txtPhone.Text + "'";
					mysql = mysql + " , N'" + objAdditionalDetails.txtStreetNo.Text + "'";
					mysql = mysql + " , N'" + objAdditionalDetails.txtBlockNo.Text + "'";
					mysql = mysql + " , N'" + objAdditionalDetails.txtCity.Text + "'";
					mysql = mysql + " , N'" + objAdditionalDetails.txtCountry.Text + "'";
					mysql = mysql + " , N'" + objAdditionalDetails.txtRefOrderNo.Text + "'";
					if (Information.IsDate(objAdditionalDetails.txtRefrenceOrderDate.Value))
					{
						mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(objAdditionalDetails.txtRefrenceOrderDate.Value) + "'";
					}
					else
					{
						mysql = mysql + " , NULL ";
					}
					mysql = mysql + " , N'" + objAdditionalDetails.txtChequeNo.Text + "'";
					if (Information.IsDate(objAdditionalDetails.txtChequeDate.Value))
					{
						mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(objAdditionalDetails.txtChequeDate.Value) + "'";
					}
					else
					{
						mysql = mysql + " , NULL ";
					}
					mysql = mysql + " , N'" + objAdditionalDetails.txtCreditCardNo.Text + "'";

					if (Information.IsDate(objAdditionalDetails.txtCreditCardDate.Value))
					{
						mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(objAdditionalDetails.txtCreditCardDate.Value) + "'";
					}
					else
					{
						mysql = mysql + " , NULL ";
					}


					//''payment mode
					//    If objAdditionalDetails.cmbPaymentMode.ListIndex >= 0 Then
					//        mySql = mySql & " , " & objAdditionalDetails.cmbPaymentMode.ItemData(objAdditionalDetails.cmbPaymentMode.ListIndex)
					//    Else
					//        mySql = mySql & " , NULL "
					//    End If
					if (objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex1].ListIndex >= 0)
					{
						mysql = mysql + " , " + objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex1].GetItemData(objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex1].ListIndex).ToString();
					}
					else
					{
						mysql = mysql + " , NULL ";
					}

					mysql = mysql + " , N'" + objAdditionalDetails.txtDrawnOnBank.Text + "'";

					//''Shipment Mode
					if (objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex2].ListIndex >= 0)
					{
						mysql = mysql + " , " + objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex2].GetItemData(objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex2].ListIndex).ToString();
					}
					else
					{
						mysql = mysql + " , NULL ";
					}

					//''Shipment No. Type
					if (objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex3].ListIndex >= 0)
					{
						mysql = mysql + " , " + objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex3].GetItemData(objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex3].ListIndex).ToString();
					}
					else
					{
						mysql = mysql + " , NULL ";
					}

					mysql = mysql + " , N'" + objAdditionalDetails.txtShipmentNo.Text + "'";
					mysql = mysql + " , N'" + objAdditionalDetails.txtPackingListNo.Text + "'";
					//mysql = mysql & " , N'" & objAdditionalDetails.txtReceivedBy.Text & "'"

					//''Delivery By Period
					if (objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex4].ListIndex >= 0)
					{
						mysql = mysql + " , " + objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex4].GetItemData(objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex4].ListIndex).ToString();
					}
					else
					{
						mysql = mysql + " , NULL ";
					}

					mysql = mysql + " , N'" + objAdditionalDetails.txtDeliveryLocation.Text + "'";
					mysql = mysql + " , N'" + objAdditionalDetails.txtPaymentTerms.Text + "'";
					mysql = mysql + " , N'" + objAdditionalDetails.txtDeliveryTerms.Text + "'";
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(objAdditionalDetails.txtNAdditionalExpenses.Value);

					//''Trans Type
					if (objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex5].ListIndex >= 0)
					{
						mysql = mysql + " , " + objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex5].GetItemData(objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex5].ListIndex).ToString();
					}
					else
					{
						mysql = mysql + " , NULL ";
					}
				}
				else
				{
					if (!SystemProcedure2.IsItEmpty(pLdgrCd, SystemVariables.DataType.NumberType))
					{
						tempSql = " select l_ldgr_name, a_ldgr_name , Addr_1, Addr_2, Phone , City ";
						tempSql = tempSql + " , Country From gl_ledger where ldgr_Cd='" + pLdgrCd + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(tempSql));

						mysql = mysql + pEntryId.ToString();
						if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
						{
							mysql = mysql + " , N'" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0)) + "'"; //l_ldgr_name
						}
						else
						{
							mysql = mysql + " , N'" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1)) + "'"; //a_ldgr_name
						}

						mysql = mysql + " , N'" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2)) + "'"; //addr_1
						mysql = mysql + " , N'" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3)) + "'"; //addr_2
						mysql = mysql + " , N'" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4)) + "'"; //phone
						mysql = mysql + " , NULL , NULL ";
						mysql = mysql + " , N'" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(5)) + "'"; //city
						mysql = mysql + " , N'" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(6)) + "'"; //Country
						mysql = mysql + " , NULL ";
						mysql = mysql + " , NULL , NULL , NULL , NULL , NULL ";
						mysql = mysql + " , NULL , NULL ";
					}
					else
					{
						mysql = mysql + pEntryId.ToString();
						mysql = mysql + " , NULL "; //l_ldgr_name
						mysql = mysql + " , NULL "; //addr_1
						mysql = mysql + " , NULL "; //addr_2
						mysql = mysql + " , NULL "; //phone
						mysql = mysql + " , NULL , NULL ";
						mysql = mysql + " , NULL "; //city
						mysql = mysql + " , NULL "; //Country
						mysql = mysql + " , NULL ";
						mysql = mysql + " , NULL , NULL , NULL , NULL , NULL ";
						mysql = mysql + " , NULL , NULL ";
					}
				}

				mysql = mysql + " )";

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void UpdateAdditionalVoucherDetails(int pEntryId)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "";

				if (objAdditionalDetailsInitialised)
				{
					mysql = " update ICS_Additional_Voucher_Details set ";
					mysql = mysql + " ldgr_name =N'" + objAdditionalDetails.txtLdgrName.Text + "'";
					mysql = mysql + " , addr_1 =N'" + objAdditionalDetails.txtAdd1.Text + "'";
					mysql = mysql + " , addr_2 =N'" + objAdditionalDetails.txtAdd2.Text + "'";
					mysql = mysql + " , phone =N'" + objAdditionalDetails.txtPhone.Text + "'";
					mysql = mysql + " , street =N'" + objAdditionalDetails.txtStreetNo.Text + "'";
					mysql = mysql + " , block_no =N'" + objAdditionalDetails.txtBlockNo.Text + "'";
					mysql = mysql + " , city =N'" + objAdditionalDetails.txtCity.Text + "'";
					mysql = mysql + " , country =N'" + objAdditionalDetails.txtCountry.Text + "'";
					mysql = mysql + " , reference_order_no =N'" + objAdditionalDetails.txtRefOrderNo.Text + "'";

					if (Information.IsDate(objAdditionalDetails.txtRefrenceOrderDate.Value))
					{
						mysql = mysql + " , reference_order_date ='" + ReflectionHelper.GetPrimitiveValue<string>(objAdditionalDetails.txtRefrenceOrderDate.Value) + "'";
					}
					else
					{
						mysql = mysql + " , reference_order_date = NULL ";
					}

					mysql = mysql + " , cheque_no =N'" + objAdditionalDetails.txtChequeNo.Text + "'";

					if (Information.IsDate(objAdditionalDetails.txtChequeDate.Value))
					{
						mysql = mysql + " , cheque_date ='" + ReflectionHelper.GetPrimitiveValue<string>(objAdditionalDetails.txtChequeDate.Value) + "'";
					}
					else
					{
						mysql = mysql + " , cheque_date = NULL ";
					}

					mysql = mysql + " , credit_card_no = N'" + objAdditionalDetails.txtCreditCardNo.Text + "'";

					if (Information.IsDate(objAdditionalDetails.txtCreditCardDate.Value))
					{
						mysql = mysql + " , credit_card_date ='" + ReflectionHelper.GetPrimitiveValue<string>(objAdditionalDetails.txtCreditCardDate.Value) + "'";
					}
					else
					{
						mysql = mysql + " , credit_card_date = NULL ";
					}

					if (objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex1].ListIndex >= 0)
					{
						mysql = mysql + " , pay_mode_cd =" + objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex1].GetItemData(objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex1].ListIndex).ToString();
					}
					else
					{
						mysql = mysql + " , pay_mode_cd = NULL ";
					}

					mysql = mysql + " , drawn_on_bank =N'" + objAdditionalDetails.txtDrawnOnBank.Text + "'";

					mysql = mysql + " , shipment_mode =" + objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex2].GetItemData(objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex2].ListIndex).ToString();
					mysql = mysql + " , shipment_no_type =" + objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex3].GetItemData(objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex3].ListIndex).ToString();
					mysql = mysql + " , shipment_no =N'" + objAdditionalDetails.txtShipmentNo.Text + "'";

					mysql = mysql + " , packing_list_no =N'" + objAdditionalDetails.txtPackingListNo.Text + "'";

					mysql = mysql + " , delivery_by_period =" + objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex4].GetItemData(objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex4].ListIndex).ToString();
					mysql = mysql + " , trans_type =" + objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex5].GetItemData(objAdditionalDetails.comCommon[SystemICSConstants.icsAVDFlex5].ListIndex).ToString();
					mysql = mysql + " , delivery_to_location =N'" + objAdditionalDetails.txtDeliveryLocation.Text + "'";
					mysql = mysql + " , payment_terms =N'" + objAdditionalDetails.txtPaymentTerms.Text + "'";
					mysql = mysql + " , delivery_terms =N'" + objAdditionalDetails.txtDeliveryTerms.Text + "'";
					mysql = mysql + " , additional_expenses =" + ReflectionHelper.GetPrimitiveValue<string>(objAdditionalDetails.txtNAdditionalExpenses.Value);

					mysql = mysql + " where entry_id = " + pEntryId.ToString();

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}


		private void InitialiseAdditionalVoucherDetailsInfo(int pEntryId)
		{
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			//'**Import the Additional voucher details
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Import_Linked_Voucher_On_Header"])) == TriState.True)
				{
					if (objAdditionalDetailsInitialised)
					{
						objAdditionalDetails.Close();
					}
					objAdditionalDetails = null;
					objAdditionalDetails = frmICSAdditionalVoucherDetails.CreateInstance();

					objAdditionalDetailsInitialised = true;
					objAdditionalDetails.SetSetValues(pEntryId, "");

					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//VB.Global.Load(objAdditionalDetails);
				}
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void RecordNavidate(int pKeyCode, int pEntryId)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				string mysql = " select top 1 entry_id from ICS_Transaction_Assembly ";
				mysql = mysql + " where 1=1 and trans_type =" + mBuildType.ToString();
				if (pEntryId > 0 && pKeyCode == 37)
				{
					mysql = mysql + " and entry_id < " + pEntryId.ToString();
				}
				else if (pEntryId > 0 && pKeyCode == 39)
				{ 
					mysql = mysql + " and entry_id > " + pEntryId.ToString();
				}

				if (pKeyCode == 37)
				{
					mysql = mysql + " order by entry_id desc ";
				}
				else if (pKeyCode == 39)
				{ 
					mysql = mysql + " order by entry_id asc ";
				}

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					GetRecord(mReturnValue);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		public void MRoutine()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!UserAccess.AllowUserDisplay)
				{
					MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				RecordNavidate(37, mRecordNavigateSearchValue);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		public void ORoutine()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!UserAccess.AllowUserDisplay)
				{
					MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				RecordNavidate(39, mRecordNavigateSearchValue);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		public void CreateStatusBar()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
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

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_In_Transit_Stock_In_Status"]))
				{
					Pane = UCStatusBar.AddPane(SystemICSConstants.lcStockInTransit1);
					Pane.Visible = true;
					Pane.Text = "Stock In Transit :";
					Pane.SetPadding(8, 0, 8, 0);

					Pane = UCStatusBar.AddPane(SystemICSConstants.lcStockInTransit2);
					Pane.Visible = true;
					Pane.Text = "";
					Pane.Width = 70;
					Pane.SetPadding(8, 0, 8, 0);
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Stock_Available_In_Status"]))
				{
					Pane = UCStatusBar.AddPane(SystemICSConstants.lcStockAvailable1);
					Pane.Visible = true;
					Pane.Text = "Stock Available :";
					Pane.SetPadding(8, 0, 8, 0);

					Pane = UCStatusBar.AddPane(SystemICSConstants.lcStockAvailable2);
					Pane.Visible = true;
					Pane.Text = "";
					Pane.Width = 70;
					Pane.SetPadding(8, 0, 8, 0);
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Flex_1_In_Footer"]))
				{
					Pane = UCStatusBar.AddPane(SystemICSConstants.lcFlex1Value1);
					Pane.Visible = true;
					Pane.Text = "Colour :";
					Pane.SetPadding(8, 0, 8, 0);

					Pane = UCStatusBar.AddPane(SystemICSConstants.lcFlex1Value2);
					Pane.Visible = true;
					Pane.Text = "";
					Pane.Width = 70;
					Pane.SetPadding(8, 0, 8, 0);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}
		public void ClearStatusBar()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Base_Unit_In_Status"]))
				{
					UCStatusBar.FindPane(SystemICSConstants.lcBaseUnit2).Text = "";
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Stock_In_Hand_In_Status"]))
				{
					UCStatusBar.FindPane(SystemICSConstants.lcStockInHand2).Text = "";
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Stock_Allocated_In_Status"]))
				{
					UCStatusBar.FindPane(SystemICSConstants.lcStockAllocated2).Text = "";
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_In_Transit_Stock_In_Status"]))
				{
					UCStatusBar.FindPane(SystemICSConstants.lcStockInTransit2).Text = "";
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Stock_Available_In_Status"]))
				{
					UCStatusBar.FindPane(SystemICSConstants.lcStockAvailable2).Text = "";
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}
	}
}