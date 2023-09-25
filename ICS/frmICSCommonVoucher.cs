
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


using UpgradeHelpers.VB;


namespace Xtreme
{
	internal partial class frmICSTransactionMaster
		: System.Windows.Forms.Form
	{


		
		public frmICSTransactionMaster()
{
InitializeComponent();
} 
 public  void frmICSTransactionMaster_old()
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
		 //This class checks for the rights given to the user
		public clsToolbar oThisFormToolBar = null;
		public frmICSAdditionalVoucherDetails objAdditionalDetails = null;
		public bool objAdditionalDetailsInitialised = false;

		public frmICSAdditionalVoucherDetails2 objAdditionalDetails2 = null;
		public bool objAdditionalDetailsInitialised2 = false;

		public int ThisVoucherType = 0;

		private int mThisFormID = 0;
		private clsICSTransaction clsmain = null;

		public int cTabItemDetails = 0;
		public int cTabImportVoucherDetails = 0;
		public int cTabSupplierDetails = 0;

		//''''''''Tab Const
		private const int cTabGeneral = 0;
		private const int cTabAdditional = 1;
		private const int cTabOther = 2;

		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		public XtremeCommandBars.StatusBar UCStatusBar = null;



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
			}
		}



		public int DefaultVoucherType
		{
			get
			{
				return ThisVoucherType;
			}
			set
			{
				ThisVoucherType = value;
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


		private void ActiveResize1_BeforeResize(bool Cancel)
		{
			MessageBox.Show("test", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
		}

		private void cmdPull_Click(Object eventSender, EventArgs eventArgs)
		{
			clsmain.PullLinkedVoucherDetails();
		}

		private void Form_Initialize()
		{
			clsmain = new clsICSTransaction();
			clsmain.SetAttachObjects(grdVoucherDetails, cmbMastersList, SystemICSConstants.grdArrayUbound, grdImportVoucherDetails, cmbImportVoucherList, tabMaster, grdSupplierDetails, cmbSupplierList, this);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			int mFormBackColor = 0;
			int mHeaderControlsBackColor = 0;
			string mGridHeaderFooterColor = "";
			string mBackColor = "";
			bool mAllowFocus = false;
			bool mAllowAddNew = false;

			try
			{

				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsVoucherTypes.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsVoucherTypes.MoveFirst();
				SystemVariables.rsVoucherTypes.Find("voucher_type = " + Conversion.Str(ThisVoucherType));

				this.Text = "";

				cTabItemDetails = 0;
				cTabImportVoucherDetails = 1;
				cTabSupplierDetails = 2;

				clsmain.SetUserAccess = UserAccess;
				grdVoucherDetails.Visible = false;

				tabMaster.SelectedItem = cTabItemDetails;
				CreateStatusBar();
				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm
				//.AttachObject clsmain, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.BeginFindButtonWithGroup = true;
				if (SystemVariables.gLoggedInUserGroupCode == SystemConstants.gDefaultAdminGroupCode)
				{
					oThisFormToolBar.ShowUnpostButton = true;
				}

				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginInsertLineButtonWithGroup = true;
				oThisFormToolBar.BeginPostButtonWithGroup = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;
				oThisFormToolBar.DisablePostButton = true;
				oThisFormToolBar.DisableUnpostButton = true;
				oThisFormToolBar.ShowMoveRecordNextButton = true;
				oThisFormToolBar.ShowMoveRecordPreviousButton = true;
				oThisFormToolBar.BeginDeleteButtonWithGroup = true;
				oThisFormToolBar.ShowGLTranButton = true;

				//.ShowVoidButton = True
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if ((ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("enable_ics_voucher_final_payment_screen")) & ((Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["enable_ics_voucher_final_payment_screen"])) ? -1 : 0)) != 0)
				{
					oThisFormToolBar.ShowPaymentButton = true;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("ics_import_external_data")) && Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["import_external_data"]))
				{
					oThisFormToolBar.ShowImportButton = true;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_generate_barcode_button"]))
				{
					oThisFormToolBar.ShowBarcodeButton = true;
					oThisFormToolBar.BeginBarcodeButtonWithGroup = true;
				}

				this.WindowState = FormWindowState.Maximized;
				//
				//    With Me.UCStatusBar
				//        .StatusLabel(0, stFontSize) = GetSystemPreferenceSetting("ics_grid_font_size")
				//        .StatusLabel(0, stAutoSize) = True
				//    End With
				txtTempDate.AlignHorizontal = TDBDate6.dbiAlignHConst.dbiAlignHLeft;
				txtTempDate.AlignVertical = TDBDate6.dbiAlignVConst.dbiAlignVCenter;
				txtTempDate.Appearance = TDBDate6.dbiAppearanceConst.dbiFlat;
				txtTempDate.BorderStyle = TDBDate6.dbiBorderStyleConst.dbiNoBorder;
				txtTempDate.CenturyMode = TDBDate6.dbiCenturyModeConst.dbiCurrentCentury;
				txtTempDate.Calendar.SelectStyle = TDBDate6.dbiCalndrSelStyleConst.dbiCalSelStyleFlatBtn;
				txtTempDate.Calendar.WeekTitles = "F,S,S,M,T,W,T";
				txtTempDate.CenturyMode = TDBDate6.dbiCenturyModeConst.dbiSystemCentury;
				txtTempDate.DisplayFormat = SystemVariables.gSystemDateFormat;
				txtTempDate.DropDown.Visible = TDBDate6.dbiVisibleConst.dbiShowOnFocus;
				txtTempDate.Format = SystemVariables.gSystemDateFormat;

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!SystemProcedure2.IsItEmpty(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["linked_parent_ics_voucher_type_cd"], SystemVariables.DataType.NumberType))
				{
					mBackColor = SystemConstants.gDisableColumnBackColor;
					mAllowFocus = false;
					mAllowAddNew = false;
				}
				else
				{
					mBackColor = ColorTranslator.ToOle(Color.White).ToString();
					mAllowFocus = true;
					mAllowAddNew = true;
				}

				mFormBackColor = 0xE7E2DC; //&H8000000C  'tcbSystemForm.GetSpecialColor(XPCOLOR_3DSHADOW)
				mHeaderControlsBackColor = 0xE7E2DC; //rsVoucherTypes("voucher_grid_back_color") 'tcbSystemForm.GetSpecialColor(XPCOLOR_3DFACE)
				mGridHeaderFooterColor = (0xE7E2DC).ToString(); //rsVoucherTypes("voucher_grid_back_color")

				//**--format the form color
				//    Me.BackColor = mFormBackColor
				//    fraTransactionHeader.BackColor = mHeaderControlsBackColor
				//    'fraTransactionHeader.BorderColor = tcbSystemForm.GetSpecialColor(XPCOLOR_HIGHLIGHT_BORDER)
				//    fraVoucherImport.BorderColor = mFormBackColor
				//    'fraVoucherType.BorderColor = mFormBackColor
				//
				//    'lblCommonLabel(8).BackColor = mFormBackColor
				//    lblCommonLabel(9).BackColor = mFormBackColor
				//    lblCommonLabel(10).BackColor = mFormBackColor
				//    lblCommonLabel(11).BackColor = mFormBackColor
				//    lblCommonLabel(12).BackColor = mFormBackColor
				//    lblCommonLabel(15).BackColor = mFormBackColor
				//
				//    lblCommonLabel(8).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(2).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(3).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(4).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(5).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(6).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(7).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(14).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(17).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(19).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(20).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(21).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(22).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(23).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(24).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(25).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(lcDueDays).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(lcJobCode).BackColor = mHeaderControlsBackColor
				//    lblCommonLabel(lcExpenseAccntCode).BackColor = mHeaderControlsBackColor
				//    optVoucherType(0).BackColor = mHeaderControlsBackColor
				//    optVoucherType(1).BackColor = mHeaderControlsBackColor
				//    chkProcessed.BackColor = mHeaderControlsBackColor
				//**-----------------------------


				//define voucher grid columns
				//'''''NOTE NOTE NOTE NOTE
				//'''''Adding any column in this form, should also be added in the ExpensesVoucher Form

				//Call DefineSystemVoucherGrid(grdVoucherDetails, mAllowAddNew, , , , , , , , , , rsVoucherTypes.Fields("voucher_grid_back_color").Value, rsVoucherTypes.Fields("voucher_grid_back_color").Value)
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, mAllowAddNew, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, mGridHeaderFooterColor, mGridHeaderFooterColor, 320, ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("ics_grid_font_size")));
				//define voucher grid columns
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Line_No_In_Details"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Flex", 1300, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Flex1_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Flex1_In_Details"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Activity", 1500, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_Activity_In_Detail"]), mBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("project_costing")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_Activity_In_Detail"])) != 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Barcode", 1300, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Barcode_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("barcode")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Barcode_In_Details"])) != 0, false, false, true, false, 20, "", "", false, "", 0, true);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Style No", 1500, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Supplier_Barcode"]), mBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Supplier_Barcode"]), false, false, false, false, 100, "", "", false, "", 0, true);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Item Id", 1500, mAllowFocus, mBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Part_No_In_Details"]), false, false, false, false, 100, "", "", false, "", 0, true);

				// Date:18/10/2007 To Add Two New Buttons
				//-------------------------------------------------------
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "PreText", 1300, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("enable_ics_voucher_multiline_predesc")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Enable_ICS_Voucher_Multiline_PreDesc"])) != 0, false, false, true, true, -1);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "PostText", 1300, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("enable_ics_voucher_multiline_postdesc")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Enable_ICS_Voucher_Multiline_PostDesc"])) != 0, false, false, true, true, -1);
				//-------------------------------------------------------


				//''Only the autocompletion is changed
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["allow_product_name_alteration"]))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Item Name", 2700, mAllowFocus, mBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, false, false, "cmbMastersList", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Name_In_Details"]), false, false, false, false, 400, "", SystemConstants.gArabicFontName, false, "", 0, mAllowFocus);
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Item Name", 2700, mAllowFocus, mBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbMastersList", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Name_In_Details"]), false, false, false, false, 400, "", SystemConstants.gArabicFontName, false, "", 0, mAllowFocus);
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Batch", 1000, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Production_Batch"]), mBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, !Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Allow_Production_Batch_Add"]), true, true, "cmbMastersList", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Item_Batch")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Production_Batch"])) != 0, false, false, false, false, 100, "", "", false, "", 0, true);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Expiry Date", 1300, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Expiry_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Expiry_In_Details"]), false, false, false, false, 100, "", "", false, "txtTempDate");

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Package", 1000, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Package"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Package"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Package"]), 12);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Pack Qty", 1000, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Package"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Package"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Package"]), 12);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Unit", 500, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_unit_in_details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_unit_in_details"]), false, false, false, false, 100, "", "", false, "", 0, true);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "W/H", 450, mAllowFocus, mBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Location_In_Details"]));
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Parent Qty", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Pack Qty", 1000, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Pack_Qty"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Pack_Qty"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Pack_Qty"]), 12, "", "", false, "", 0, true);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Loose Qty", 1000, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Pack_Qty"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Pack_Qty"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Pack_Qty"]), 12, "", "", false, "", 0, true);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Qty", 900, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_qty_in_details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Qty_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Qty_In_Details"]), 12, "", "", false, "", 0, true);


				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Weight", 900, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_weight_in_details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_weight_in_details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_weight_in_details"]), 12);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Rate UOM", 900, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_UOM_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_UOM_In_Details"]));

				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Serialized", 0, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Serial No.", 900, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("serialized_product")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_serial_in_details"])) != 0, false, false, true, true, -1);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Project Code", 1000, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Project_In_Details"]), mBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("project_costing")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Project_In_Details"])) != 0, false, false, false, false, 100, "", "", false, "", 0, true);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Task", 1000, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Activity_Task_In_Details"]), mBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("project_costing")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Activity_Task_In_Details"])) != 0);


				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "", 350, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Promo_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbMastersList", true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Promo_In_Details"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remaining Qty", 900, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_Remaining_qty_in_details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_remaining_Qty_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Qty_In_Details"]), 12, "", "", true);

				//If (GetSystemPreferenceSetting("Default_Price_Level_Priority_In_Sales") < 3 And rsVoucherTypes("module_id") = 6) Or (GetSystemPreferenceSetting("Default_Price_Level_Priority_In_Purchase") < 3 And rsVoucherTypes("module_id") = 5) Then
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if ((Convert.ToDouble(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Default_Price_Level_Priority"]) < 3 && Convert.ToDouble(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["module_id"]) == 6) || (Convert.ToDouble(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Default_Price_Level_Priority"]) < 3 && Convert.ToDouble(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["module_id"]) == 5))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToDouble(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["module_id"]) == 6)
					{
						if (SystemVariables.gEnableSalesPriceRestrictions && !SystemVariables.gRestrictInSalesPriceLevels)
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Unit Price", 1000, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMastersList", true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), 12, "", "", false, "", 0, true);
						}
						else
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Unit Price", 1000, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMastersList", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), 12, "", "", false, "", 0, true);
						}
					}
					else if (Convert.ToDouble(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["module_id"]) == 5)
					{ 
						if (SystemVariables.gEnablePurchasePriceRestrictions && !SystemVariables.gRestrictInPurchasePriceLevels)
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Unit Price", 1000, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMastersList", true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), 12, "", "", false, "", 0, true);
						}
						else
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Unit Price", 1000, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMastersList", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), 12, "", "", false, "", 0, true);
						}
					}
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Unit Price", 1000, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), 12, "", "", false, "", 0, true);
				}

				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Parent Discount", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Discount", 900, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Discount_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Discount_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Discount_In_Details"]), 12, "", "", false, "", 0, true);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Dis. %", 900, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Dis_Per_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Dis_Per_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Dis_Per_In_Details"]), 12, "", "", false, "", 0, true);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Unit Total", 1200, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Amount_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Amount_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Amount_In_Details"]), 12, "", "", false, "", 0, true);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Exp.", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false, false, false, false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_expenses"]), 100, "", "", false, "", 0, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Dented", 600, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false);
				//-----------------------------------------------------------------------------------------------------------------------
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "S.N.", 500, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Print_sr_no"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Print_sr_no"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1500, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Remarks_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Remarks_In_Details"]), false, false, true, false, 500, "", SystemConstants.gArabicFontName, false, "", 0, true, 2040);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Item Type", 0, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Parent Line", 0, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if ((ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("serialized_product")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_serial_in_details"])) != 0)
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					withVar = grdVoucherDetails.Splits[0].DisplayColumns[SystemICSConstants.grdSerialNoColumn];
					withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
					withVar.DataColumn.Caption = "SN.";
					withVar.AllowFocus = true;
					withVar.ButtonAlways = true;
					withVar.ButtonText = true;
					withVar.Width = 27;
					withVar.Style.Font = withVar.Style.Font.Change(bold:true, size:11, name:"Verdana");
					withVar.Style.ForeColor = Color.FromArgb(21, 64, 77);
				}

				// Date:18/10/2007 To Add Two New Buttons
				//-------------------------------------------------------
				C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if ((ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("enable_ics_voucher_multiline_predesc")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["enable_ics_voucher_multiline_predesc"])) != 0)
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					withVar_2 = grdVoucherDetails.Splits[0].DisplayColumns[SystemICSConstants.grdPreTextColumn];
					withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
					withVar_2.DataColumn.Caption = "Pre Text";
					withVar_2.AllowFocus = true;
					withVar_2.ButtonAlways = true;
					withVar_2.ButtonText = true;
					withVar_2.Width = 27;
					withVar_2.Style.Font = withVar_2.Style.Font.Change(bold:true, size:11, name:"Verdana");
					withVar_2.Style.ForeColor = Color.FromArgb(21, 64, 77);
				}

				C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_3 = null;
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if ((ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("enable_ics_voucher_multiline_postdesc")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Enable_ICS_Voucher_Multiline_PostDesc"])) != 0)
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					withVar_3 = grdVoucherDetails.Splits[0].DisplayColumns[SystemICSConstants.grdPostTextColumn];
					withVar_3.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
					withVar_3.DataColumn.Caption = "PostText";
					withVar_3.AllowFocus = true;
					withVar_3.ButtonAlways = true;
					withVar_3.ButtonText = true;
					withVar_3.Width = 27;
					withVar_3.Style.Font = withVar_3.Style.Font.Change(bold:true, size:11, name:"Verdana");
					withVar_3.Style.ForeColor = Color.FromArgb(21, 64, 77);
				}
				//-------------------------------------------------------

				C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_4 = null;
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_dented_stock_In_Details"]))
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					withVar_4 = grdVoucherDetails.Splits[0].DisplayColumns[SystemICSConstants.grdDentedStockColumn];
					withVar_4.DataColumn.ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
					withVar_4.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
					withVar_4.AllowFocus = true;
					withVar_4.Visible = true;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToDouble(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["form_height_size"]) > 1)
				{
					//UPGRADE_ISSUE: (2038) Form property Me.ScaleMode is not supported. More Information: https://docs.mobilize.net/vbuc/ewis#2038
					this.setScaleMode(PrinterHelper.ScaleModeConstants.VbPixels);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					this.Height = Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["form_height_size"]) / 15;
					//UPGRADE_ISSUE: (2038) Form property Me.ScaleMode is not supported. More Information: https://docs.mobilize.net/vbuc/ewis#2038
					this.setScaleMode(PrinterHelper.ScaleModeConstants.VbTwips);

					frameBottom.Top = Convert.ToInt32(ReflectionHelper.GetMember<double>(UCStatusBar, "top") / 15 - frameBottom.Height);
					tabMaster.Height = frameBottom.Top - tabMaster.Top;
					grdVoucherDetails.Height = frameBottom.Top - (tabMaster.Top + 24); //'+ (grdVoucherDetails.FootLines * 100)
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToDouble(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["grid_row_height_size"]) > 1)
				{
					grdVoucherDetails.RecordSelectors = true;
					grdVoucherDetails.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows;
					grdVoucherDetails.Style.Wrap = C1.Win.C1TrueDBGrid.TextWrapping.Wrap;
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					grdVoucherDetails.RowHeight = Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["grid_row_height_size"]) / 15;
				}

				//DoEvents
				grdVoucherDetails.Visible = true;

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				lblVoucherName.Text = Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["l_voucher_name"] : SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["a_voucher_name"]);

				//Me.Refresh
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
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsVoucherTypes.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.rsVoucherTypes.MoveFirst();
					SystemVariables.rsVoucherTypes.Find("voucher_type = " + Conversion.Str(ThisVoucherType));

					SystemMenu.SetMeCurrentInWindowList(Conversion.Str(this.Handle.ToInt32()));
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
				tabMain.Width = this.Width;
				tabMain.Height = this.Height - (frameBottom.Height + 55);

				tabMaster.Width = this.Width - 2;
				tabMaster.Height = tabMain.Height - (fraTransactionHeader.Height + 31);
				frameBottom.Top = tabMain.Top + tabMain.Height + 1;

				fraMasterInformation(0).Width = tabMaster.Width - 7;
				fraMasterInformation(0).Height = tabMaster.Height - 13;

				fraMasterInformation(1).Width = tabMaster.Width - 7;
				fraMasterInformation(1).Height = tabMaster.Height - 13;

				grdVoucherDetails.Width = tabMaster.Width - 11;
				grdVoucherDetails.Height = tabMaster.Height - 28;

				fraVoucherName.Width = this.Width - 533;
				lblVoucherName.Width = fraVoucherName.Width - 5;
				lblVoucherName.Left = fraVoucherName.Left + 5;
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

				UserAccess = null;

				objAdditionalDetails.Close();
				objAdditionalDetails = null;

				objAdditionalDetails2.Close();
				objAdditionalDetails2 = null;

				clsmain = null;
				frmICSTransactionMaster.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void lblSave_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				AdditionalVoucherDetails2();
			}
			catch
			{
			}
		}


		public void AdditionalVoucherDetails2()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				object mReturnValue = null;
				string mysql = "";

				if (!objAdditionalDetailsInitialised2)
				{
					objAdditionalDetails2 = frmICSAdditionalVoucherDetails2.CreateInstance();
					objAdditionalDetailsInitialised2 = true;
				}

				if (clsmain.CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					objAdditionalDetails2.SetSetValues(0, ReflectionHelper.GetPrimitiveValue<decimal>(txtNetAmount.Value));
				}
				else
				{
					objAdditionalDetails2.SetSetValues(ReflectionHelper.GetPrimitiveValue<int>(clsmain.SearchValue), ReflectionHelper.GetPrimitiveValue<decimal>(txtNetAmount.Value));
				}

				objAdditionalDetails2.txtCommon[2].Text = txtCommonTextBox[SystemICSConstants.tcCashCode].Text;

				//UPGRADE_WARNING: (7009) Multiple invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions More Information: https://docs.mobilize.net/vbuc/ewis#7009
				objAdditionalDetails2.ShowDialog();
				if (objAdditionalDetails2.ButtonPressed == 1)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemForms.ToolBarButtonClick(clsmain, "Save", "", Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["prompt_before_save"]));
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}
		private void optVoucherType_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.optVoucherType, eventSender);
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					string mysql = "";
					object mTempValue = null;
					if (Index == 1)
					{
						fraPayments.Visible = true;
						txtCommonTextBox[SystemICSConstants.tcCashCode].Enabled = true;
						txtCommonTextBox[SystemICSConstants.tcCCCode].Enabled = true;

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (!SystemVariables.rsVoucherTypes.Tables[0].Rows[0].IsNull("Default_cash_cd") && SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcCashCode].Text, SystemVariables.DataType.StringType))
						{
							mysql = " select ldgr_no, " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name") + " from gl_ledger ";
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mysql = mysql + " where ldgr_cd = " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Default_cash_cd"]);
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mTempValue))
							{
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtCommonTextBox[SystemICSConstants.tcCashCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDisplayLabel[SystemICSConstants.dcCashName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
								txtCashAmt.Text = txtNetAmount.Text;
							}
						}

					}
					else
					{
						fraPayments.Visible = false;
						txtCommonTextBox[SystemICSConstants.tcCashCode].Enabled = false;
						txtCommonTextBox[SystemICSConstants.tcCCCode].Enabled = false;
					}
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
		}





		private void tabMain_SelectedChanged(Object eventSender, AxXtremeSuiteControls._DTabControlEvents_SelectedChangedEvent eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				switch(eventArgs.item.Index)
				{
					case cTabGeneral : 
						//Tobe Implimented 
						break;
					case cTabAdditional : 
						if (!objAdditionalDetailsInitialised)
						{
							FillAdditionalDetails();
							objAdditionalDetailsInitialised = true;
						} 
						break;
					case cTabOther : 
						// 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCashAmt_Leave(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (ReflectionHelper.GetPrimitiveValue<double>(txtNetAmount.Value) > 0 && ReflectionHelper.IsGreaterThan(txtCashAmt.Value, txtNetAmount.Value))
				{
					txtCashAmt.Value = txtNetAmount;
				}

				if (ReflectionHelper.GetPrimitiveValue<double>(txtNetAmount.Value) > 0)
				{
					txtCCAmt.Value = Conversion.Val((Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtNetAmount.Value)) - Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCashAmt.Value))).ToString());
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCCAmt_Leave(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (ReflectionHelper.IsGreaterThan(txtCCAmt.Value, txtNetAmount.Value))
				{
					txtCCAmt.Value = 0;
				}

				txtCashAmt.Value = Conversion.Val((Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtNetAmount.Value)) - Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCCAmt.Value))).ToString());
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			try
			{
				SystemICSProcedure.TextBoxLostFocus(this, Index, clsmain);
			}
			catch
			{
			}
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				clsmain.FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Index == SystemICSConstants.tcLedgerCode && Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_additional_voucher_details"]))
				{
					FillAdditionalDetails();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void GetRecord(object pSearchValue)
		{
			try
			{
				clsmain.GetRecord(pSearchValue);
			}
			catch
			{
			}
		}

		private void txtCreditDays_Change(Object Sender, EventArgs e)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (Information.IsDate(txtVoucherDate.Value))
				{
					txtDDueDate.Value = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).AddDays(ReflectionHelper.GetPrimitiveValue<double>(txtCreditDays.Value));
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtDiscount_KeyDown(Object Sender, System.Windows.Forms.TextBox.KeyDownEventArgs e)
		{
			Keys KeyCode = (Keys) e.KeyCode;
			int Shift = e.Shift;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (KeyCode == Keys.F5)
				{
					txtPercentDiscount.Value = StringsHelper.Format((ReflectionHelper.GetPrimitiveValue<double>(txtDiscount.Value) * 100) / (Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[SystemICSConstants.grdProductAmountColumn].FooterText, "###############.######"))), "###.######0");
					txtDiscount.Value = 0;
					clsmain.DistributeDiscPercent();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtDiscount2Percent_Change(Object Sender, EventArgs e)
		{
			try
			{
				txtDiscount2Percent_Leave(txtDiscount2Percent, new EventArgs());
			}
			catch
			{
			}
		}

		private void txtPercentDiscount_KeyDown(Object Sender, System.Windows.Forms.TextBox.KeyDownEventArgs e)
		{
			Keys KeyCode = (Keys) e.KeyCode;
			int Shift = e.Shift;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (KeyCode == Keys.F5)
				{
					clsmain.DistributeDiscPercent();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtPercentDiscount_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float x = eventArgs.X * 15;
			float y = eventArgs.Y * 15;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (grdVoucherDetails.Splits[0].DisplayColumns[SystemICSConstants.grdDiscountPercentColumn].Visible)
				{
					txtPercentDiscount.ToolTipText = "Press F5 key to distribute discount % on each item.";
				}
				else
				{
					txtPercentDiscount.ToolTipText = "";
				}
				//
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}



		private void txtVoucherDate_Change(Object Sender, EventArgs e)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_due_date_on_header"]))
				{
					if (Information.IsDate(txtVoucherDate.Value))
					{
						txtDDueDate.Value = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value).AddDays(ReflectionHelper.GetPrimitiveValue<double>(txtCreditDays.Value));
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
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

		public void txtDiscount_Leave(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (ReflectionHelper.GetPrimitiveValue<double>(txtDiscount.Value) > Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[SystemICSConstants.grdProductAmountColumn].FooterText, "###############.######")) || ReflectionHelper.GetPrimitiveValue<double>(txtDiscount.Value) < 0 || Convert.IsDBNull(txtDiscount.Value))
				{
					txtDiscount.Value = 0;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_hidden_discount"])) == TriState.True)
				{
					//UPGRADE_WARNING: (1068) txtDiscount.Value of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDiscount2.Value = ReflectionHelper.GetPrimitiveValue(txtDiscount.Value);
				}
				//''and it was decided that percent discount should not be calculated from amount. But amount will be calculated from percent discount.
				//If Not IsItEmpty(Format(grdVoucherDetails.Columns(grdProductAmountColumn).FooterText, "###############.######"), NumberType) Then
				//    txtPercentDiscount.Value = Format((txtDiscount.Value * 100) / (Val(Format(grdVoucherDetails.Columns(grdProductAmountColumn).FooterText, "###############.######"))), "###.######0")
				//End If
				txtNetAmount.Value = Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[SystemICSConstants.grdProductAmountColumn].FooterText, "###############.######")) - Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtDiscount.Value));
				if (fraPayments.Visible == (TriState.True != TriState.False))
				{
					txtCashAmt.Value = ReflectionHelper.GetPrimitiveValue<double>(txtNetAmount.Value) - ReflectionHelper.GetPrimitiveValue<double>(txtCCAmt.Value);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void txtPercentDiscount_Leave(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!SystemProcedure2.IsItEmpty(txtPercentDiscount.Value))
				{
					if (ReflectionHelper.GetPrimitiveValue<double>(txtPercentDiscount.Value) > 100 || ReflectionHelper.GetPrimitiveValue<double>(txtPercentDiscount.Value) < 0)
					{
						txtPercentDiscount.Value = 0;
					}
					if (!SystemProcedure2.IsItEmpty(StringsHelper.Format(grdVoucherDetails.Columns[SystemICSConstants.grdProductAmountColumn].FooterText, "###############.######"), SystemVariables.DataType.NumberType))
					{
						txtDiscount.Value = (Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[SystemICSConstants.grdProductAmountColumn].FooterText, "###############.######")) * Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtPercentDiscount.Value))) / 100d;
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_hidden_discount"])) == TriState.True)
					{
						//UPGRADE_WARNING: (1068) txtPercentDiscount.Value of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDiscount2Percent.Value = ReflectionHelper.GetPrimitiveValue(txtPercentDiscount.Value);
					}
				}
				else
				{
					txtDiscount.Value = 0;
				}
				txtNetAmount.Value = Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[SystemICSConstants.grdProductAmountColumn].FooterText, "###############.######")) - Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtDiscount.Value));
				if (fraPayments.Visible == (TriState.True != TriState.False))
				{
					txtCashAmt.Value = ReflectionHelper.GetPrimitiveValue<double>(txtNetAmount.Value) - ReflectionHelper.GetPrimitiveValue<double>(txtCCAmt.Value);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void txtDiscount2_Leave(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (ReflectionHelper.GetPrimitiveValue<double>(txtDiscount2.Value) > Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[SystemICSConstants.grdProductAmountColumn].FooterText, "###############.######")) || ReflectionHelper.GetPrimitiveValue<double>(txtDiscount2.Value) < 0 || Convert.IsDBNull(txtDiscount2.Value))
				{
					txtDiscount2.Value = 0;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		public void txtDiscount2Percent_Leave(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!SystemProcedure2.IsItEmpty(txtDiscount2Percent.Value))
				{
					if (ReflectionHelper.GetPrimitiveValue<double>(txtDiscount2Percent.Value) > 100 || ReflectionHelper.GetPrimitiveValue<double>(txtDiscount2Percent.Value) < 0)
					{
						txtDiscount2Percent.Value = 0;
					}
					if (!SystemProcedure2.IsItEmpty(StringsHelper.Format(grdVoucherDetails.Columns[SystemICSConstants.grdProductAmountColumn].FooterText, "###############.######"), SystemVariables.DataType.NumberType))
					{
						txtDiscount2.Value = (Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[SystemICSConstants.grdProductAmountColumn].FooterText, "###############.######")) * Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtDiscount2Percent.Value))) / 100d;
					}
				}
				else
				{
					txtDiscount2.Value = 0;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}
		private void cmdAddtionalDetails_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				object mReturnValue = null;
				string mysql = "";

				if (!objAdditionalDetailsInitialised)
				{
					objAdditionalDetails = frmICSAdditionalVoucherDetails.CreateInstance();

					if (clsmain.CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
					{
						mysql = "select ldgr_cd from gl_ledger where ldgr_no = '" + txtCommonTextBox[SystemICSConstants.tcLedgerCode].Text + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							objAdditionalDetails.SetSetValues(0, ReflectionHelper.GetPrimitiveValue<string>(mReturnValue));
						}
						else
						{
							objAdditionalDetails.SetSetValues(0, "");
						}
					}
					else
					{
						objAdditionalDetails.SetSetValues(ReflectionHelper.GetPrimitiveValue<int>(clsmain.SearchValue), "");
					}

				}

				//UPGRADE_WARNING: (7009) Multiple invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions More Information: https://docs.mobilize.net/vbuc/ewis#7009
				objAdditionalDetails.ShowDialog();
				objAdditionalDetailsInitialised = true;

				if (txtCommonTextBox[SystemICSConstants.tcReferenceNo].Visible && txtCommonTextBox[SystemICSConstants.tcReferenceNo].Enabled)
				{
					txtCommonTextBox[SystemICSConstants.tcReferenceNo].Focus();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		//. 22/11/2007. For Job0001
		private void cmdApprove_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				clsmain.ChangeCurrentStatus();
			}
			catch
			{
			}
		}

		public void AddRecord()
		{
			try
			{
				clsmain.AddRecord();
			}
			catch
			{
			}
		}

		public void findRecord()
		{
			try
			{
				clsmain.findRecord();
			}
			catch
			{
			}
		}

		public bool deleteRecord()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			bool result = false;
			try
			{
				result = clsmain.deleteRecord();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		public bool saveRecord()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			bool result = false;
			try
			{
				result = clsmain.saveRecord();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		public void PrintReport()
		{
			try
			{
				clsmain.PrintReport();
			}
			catch
			{
			}
		}

		public void LRoutine()
		{
			try
			{
				clsmain.LRoutine();
			}
			catch
			{
			}
		}

		public void IRoutine()
		{
			try
			{
				clsmain.IRoutine();
			}
			catch
			{
			}
		}

		public void ORoutine()
		{
			try
			{
				clsmain.ORoutine();
			}
			catch
			{
			}
		}

		public void MRoutine()
		{
			try
			{
				clsmain.MRoutine();
			}
			catch
			{
			}
		}

		public bool Post()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			bool result = false;
			try
			{
				result = clsmain.Post();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		public bool UnPost()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			bool result = false;
			try
			{
				result = clsmain.UnPost();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		public void CloseForm()
		{
			try
			{
				clsmain.CloseForm();
			}
			catch
			{
			}
		}

		public void GRoutine()
		{
			try
			{
				clsmain.GRoutine();
			}
			catch
			{
			}
		}

		public void ImportData()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode && SystemProcedure2.IsItEmpty(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["linked_parent_ics_voucher_type_cd"], SystemVariables.DataType.NumberType))
				{
					clsmain.ImportExternalDataFromExcel();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public bool CheckDataValidity()
		{
			bool result = false;
			try
			{
				result = clsmain.CheckDataValidity();
			}
			catch
			{
			}
			return result;
		}

		public void ShowPayment()
		{
			try
			{
				clsmain.ShowPayment();
			}
			catch
			{
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
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Link_No_In_Footer"]))
				{
					Pane = UCStatusBar.AddPane(SystemICSConstants.lcLinkTransNo1);
					Pane.Visible = true;
					Pane.Text = "Link Trans No :";
					Pane.SetPadding(8, 0, 8, 0);

					Pane = UCStatusBar.AddPane(SystemICSConstants.lcLinkTransNo2);
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
					Pane.Text = "Color :";
					Pane.SetPadding(8, 0, 8, 0);

					Pane = UCStatusBar.AddPane(SystemICSConstants.lcFlex1Value2);
					Pane.Visible = true;
					Pane.Text = "";
					Pane.Width = 70;
					Pane.SetPadding(8, 0, 8, 0);
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Flex_2_In_Footer"]))
				{
					Pane = UCStatusBar.AddPane(SystemICSConstants.lcFlex2Value1);
					Pane.Visible = true;
					Pane.Text = "Size :";
					Pane.SetPadding(8, 0, 8, 0);

					Pane = UCStatusBar.AddPane(SystemICSConstants.lcFlex2Value2);
					Pane.Visible = true;
					Pane.Text = "";
					Pane.Width = 70;
					Pane.SetPadding(8, 0, 8, 0);
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Flex_3_In_Footer"]))
				{
					Pane = UCStatusBar.AddPane(SystemICSConstants.lcFlex3Value1);
					Pane.Visible = true;
					Pane.Text = "Gender :";
					Pane.SetPadding(8, 0, 8, 0);

					Pane = UCStatusBar.AddPane(SystemICSConstants.lcFlex3Value2);
					Pane.Visible = true;
					Pane.Text = "";
					Pane.Width = 70;
					Pane.SetPadding(8, 0, 8, 0);
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Item_Cost_In_Status"]))
				{
					Pane = UCStatusBar.AddPane(SystemICSConstants.lcShowCost1);
					Pane.Visible = true;
					Pane.Text = "Item Cost :";
					Pane.SetPadding(8, 0, 8, 0);

					Pane = UCStatusBar.AddPane(SystemICSConstants.lcShowCost2);
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

		public void GenerateBarcode()
		{
			try
			{
				clsmain.GenerateBarcode();
			}
			catch
			{
			}
		}

		public void FillAdditionalDetails()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "";
				object mReturnValue = null;

				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcLedgerCode].Text, SystemVariables.DataType.StringType))
				{ //clsmain.CurrentFormMode = frmAddMode And IsItEmpty(txtLdgrName.Text, StringType)

					mysql = "SELECT L_Ldgr_Name, A_Ldgr_Name , Addr_1, Addr_2, City, Country, ";
					mysql = mysql + " Phone From gl_ledger where ldgr_No='" + txtCommonTextBox[SystemICSConstants.tcLedgerCode].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
						{
							txtLdgrName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)) + "";
						}
						else
						{
							txtLdgrName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1)) + "";
						}
						txtAdd1.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2)) + "";
						txtAdd2.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3)) + "";

						//txtCity.Text = mReturnValue(4) & ""
						//''added by Moiz Hakimion 31-dec-2007
						//''done for BEC as this field is used for client/vend ref. no.
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToDouble(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["reference_no_generate_method"]) != 1 && Convert.ToDouble(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["reference_no_generate_method"]) != 2)
						{
							txtCity.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(4)) + "";
						}

						txtCountry.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(5)) + "";
						txtPhone.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(6)) + "";
					}

					txtRefrenceOrderDate.Text = "";
					txtCreditCardDate.Text = "";
					txtChequeDate.Text = "";
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}
		private void txtStartDate_Validating(Object eventSender, CancelEventArgs eventArgs)
		{
			bool Cancel = eventArgs.Cancel;
			try
			{
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					txtEndDate.MinDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtStartDate.Value);
					//UPGRADE_WARNING: (1068) txtStartDate.Value of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtEndDate.Value = ReflectionHelper.GetPrimitiveValue(txtStartDate.Value);
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

		private void txtStartDate_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (!((Syncfusion.WinForms.Input.SfDateTimeEdit) eventSender).CausesValidation)
			{
				txtStartDate_Validated(eventSender, eventArgs);
			}
		}

		private void txtStartDate_Validated(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				clsmain.startEndDateChange();
			}
			catch
			{
			}
		}

		private void txtEndDate_Validating(Object eventSender, CancelEventArgs eventArgs)
		{
			bool Cancel = eventArgs.Cancel;
			try
			{
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtStartDate.Value) > ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtEndDate.Value))
					{
						MessageBox.Show("Start date cannot be greater then end date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						Cancel = true;
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

		private void txtEndDate_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (!((Syncfusion.WinForms.Input.SfDateTimeEdit) eventSender).CausesValidation)
			{
				txtEndDate_Validated(eventSender, eventArgs);
			}
		}

		private void txtEndDate_Validated(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				clsmain.startEndDateChange();
			}
			catch
			{
			}
		}

	}
}