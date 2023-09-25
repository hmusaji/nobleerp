
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmICSVoucherExpenses
		: System.Windows.Forms.Form
	{

		public frmICSVoucherExpenses()
{
InitializeComponent();
} 
 public  void frmICSVoucherExpenses_old()
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


		private void frmICSVoucherExpenses_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		int mThisFormID = 0;
		object mSearchValue = null;
		string mTimeStamp = "";

		
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
		private XArrayHelper aExpensesDetails = null;
		private XArrayHelper aVoucherDetails = null;
		private string mParentVoucherTimeStamp = "";
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;
		private System.Windows.Forms.TextBox FirstFocusObject = null;

		private DataSet rsTransactionType = null;
		private DataSet rsDrList = null;
		private DataSet rsCrList = null;
		private DataSet rsCCList = null;

		private const string mDisableColumnBackColor = "&HD5D5D5";
		private const string mCreditTransCaption = "Credit";
		private const string mCashTransCaption = "Cash";
		private const int mMaxExpensesArray = 15;

		//define the expenses grid col no.
		private const int cLN = 0;
		private const int cTransactionType = 1;
		private const int cDrLdgrCode = 2;
		private const int cDrCostCode = 3;
		private const int cDrCurr = 4;
		private const int cDrRate = 5;
		private const int cDrFCAmt = 6;
		private const int cDrLCAmt = 7;
		private const int cCrLdgrCode = 8;
		private const int cCrCostCode = 9;
		private const int cCrCurr = 10;
		private const int cCrRate = 11;
		private const int cCrFCAmt = 12;
		private const int cCrLCAmt = 13;
		private const int cTransactionDate = 14;
		private const int cComments = 15;


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


		private void cmdAllocate_Click(Object eventSender, EventArgs eventArgs)
		{
			int Cnt = 0;


			decimal mDrLCAmt = (decimal) Conversion.Val(StringsHelper.Format(grdExpensesDetails.Columns[cDrLCAmt].FooterText, "###########0.0##"));
			decimal mCrLCAmt = Decimal.Parse(grdExpensesDetails.Columns[cCrLCAmt].FooterText, NumberStyles.Currency | NumberStyles.AllowExponent);

			if (mDrLCAmt != mCrLCAmt)
			{
				MessageBox.Show("Total Debit and Total credit amount should be equal", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				grdExpensesDetails.Col = cDrLCAmt;
				grdExpensesDetails.Focus();
				return;
			}

			double mExpensesAmt = Conversion.Val(StringsHelper.Format(grdExpensesDetails.Columns[cCrLCAmt].FooterText, "###########0.0##"));

			if (!SystemProcedure2.IsItEmpty(mExpensesAmt, SystemVariables.DataType.NumberType))
			{
				if (optAllocation[0].Checked == (TriState.True != TriState.False))
				{
					//Amount wise allocation
					int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
					for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
					{
						if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdProductAmountColumn), SystemVariables.DataType.NumberType))
						{
							aVoucherDetails.SetValue((Conversion.Val(StringsHelper.Format(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdProductAmountColumn), "###############.######")) / Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[SystemICSConstants.grdProductAmountColumn].FooterText, "###############.######"))) * mExpensesAmt, Cnt, SystemICSConstants.grdExpensesColumn);
							aVoucherDetails.SetValue(StringsHelper.Format(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdExpensesColumn), "###############.000"), Cnt, SystemICSConstants.grdExpensesColumn);
						}
						else
						{
							aVoucherDetails.SetValue(0, Cnt, SystemICSConstants.grdExpensesColumn);
						}
					}
				}
				else
				{
					//Quantity Wise Allocation
					int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
					for (Cnt = 0; Cnt <= tempForEndVar2; Cnt++)
					{
						if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdQtyColumn), SystemVariables.DataType.NumberType))
						{
							aVoucherDetails.SetValue((Conversion.Val(StringsHelper.Format(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdQtyColumn), "###############.######")) / Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[SystemICSConstants.grdQtyColumn].FooterText, "###############.######"))) * mExpensesAmt, Cnt, SystemICSConstants.grdExpensesColumn);
							aVoucherDetails.SetValue(StringsHelper.Format(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdExpensesColumn), "###############.000"), Cnt, SystemICSConstants.grdExpensesColumn);
						}
						else
						{
							aVoucherDetails.SetValue(0, Cnt, SystemICSConstants.grdExpensesColumn);
						}
					}
				}

				grdVoucherDetails.Columns[SystemICSConstants.grdExpensesColumn].Caption = "Exp (in " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select symbol from gl_currency where curr_cd = 1")).Trim() + ")";
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[SystemICSConstants.grdExpensesColumn].Visible = true;
				grdVoucherDetails.Columns[SystemICSConstants.grdExpensesColumn].FooterText = StringsHelper.Format(mExpensesAmt, "###,###,###,###,###.000");
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[SystemICSConstants.grdExpensesColumn].Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center;

				grdVoucherDetails.Rebind(true);
			}
		}


		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (this.ActiveControl.Name.ToLower() == ("grdVoucherDetails").ToLower())
				{
					if (KeyCode == 13 || KeyCode == 115)
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
						if (grdVoucherDetails.Col == SystemICSConstants.grdExpensesColumn)
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
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			DataSet rsTempRec = null;
			string mysql = "";

			try
			{

				this.Top = 0;
				this.Left = 0;

				grdVoucherDetails.Visible = false;
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				oThisFormToolBar.DisableNewButton = true;
				oThisFormToolBar.DisableSaveButton = true;
				oThisFormToolBar.DisableDeleteButton = true;
				oThisFormToolBar.DisableInsertLineButton = true;
				oThisFormToolBar.DisableDeleteLineButton = true;
				oThisFormToolBar.DisablePostButton = true;


				this.WindowState = FormWindowState.Maximized;

				//
				//'draw form level toolbar
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
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

				SystemVariables.rsVoucherTypes.Tables[0].DefaultView.RowFilter = "parent_type=103 and affect_gls=1";

				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, "&HB5BDB3", "&HB5BDB3");
				//define voucher grid columns
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Line_No_In_Details"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Barcode", 1300, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("barcode")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Barcode_In_Details"])) != 0, false, false, true, false, 20);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Product Code", 1500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Part_No_In_Details"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Product Name", 2700, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, false, false, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Name_In_Details"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Unit", 500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_unit_in_details"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "W/H", 450, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Location_In_Details"]));
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Parent Qty", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Qty", 900, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Qty_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Qty_In_Details"]), 12);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Weight", 900, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_weight_in_details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_weight_in_details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_weight_in_details"]), 12);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Rate UOM", 700, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_UOM_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_UOM_In_Details"]));

				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Serialized", 0, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Serial No.", 900, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false, false, false, true, true, -1);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Project Code", 500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("project_costing")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Project_In_Details"])) != 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "", 350, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, false, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Promo_In_Details"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remaining Qty", 900, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_remaining_Qty_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Qty_In_Details"]), 12, "", "", true);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Rate", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), 12);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Parent Discount", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Discount", 900, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Discount_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Discount_In_Details"]), 12);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Dis. %", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount", 1200, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Amount_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Amount_In_Details"]), 12);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Exp.", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true, 12);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 800, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Remarks_In_Details"]), false, false, true, false, 20);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Item Type", 0, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsVoucherTypes.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();

				Application.DoEvents();
				grdVoucherDetails.Visible = true;


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

				SystemGrid.DefineSystemVoucherGrid(grdExpensesDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2.2f, 1.4f, "&HDCE2DC", "&HDCE2DC");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Transaction Type", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMasterList", true);
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Expenses Ledger", 1050, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "Total  Debit", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMasterList");
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Cost Code", 600, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMasterList", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")));
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Curr.", 430, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Exchange Rate", 950, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Amount In FC", 950, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Amount In LC", 950, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Cash/Bank Ledger", 1050, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "Total  Credit", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMasterList");
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Cost Code", 600, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMasterList", ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")));
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Curr.", 430, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Exchange Rate", 950, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Amount In FC", 950, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Amount In LC", 950, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Transaction Date", 1300, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "txtTempDate");
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Remarks", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 200);


				SystemGrid.DefineSystemGridCombo(cmbMasterList);
				cmbMasterList.Width = 267;
				cmbMasterList.Height = 133;

				//setting voucher details grid properties
				aExpensesDetails = new XArrayHelper();
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aExpensesDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aExpensesDetails.Clear();
				aExpensesDetails.RedimXArray(new int[]{0, mMaxExpensesArray}, new int[]{0, 0});
				aExpensesDetails.SetValue(1, 0, 0);
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdExpensesDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdExpensesDetails.setArray(aExpensesDetails);

				//setting voucher details grid properties
				aVoucherDetails = new XArrayHelper();
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
				aVoucherDetails.RedimXArray(new int[]{0, SystemICSConstants.grdArrayUbound}, new int[]{0, 0});
				aVoucherDetails.SetValue(1, 0, 0);
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);


				mysql = " select voucher_type ";
				mysql = mysql + "," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name" : "a_voucher_name") + " voucher_name ";
				mysql = mysql + " from ICS_Transaction_Types ";
				mysql = mysql + " where parent_type=103 and affect_gls=1 and affect_cost=1";
				rsTempRec = new DataSet();
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsTempRec.Tables.Clear();
				adap.Fill(rsTempRec);
				if (rsTempRec.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text = Convert.ToString(rsTempRec.Tables[0].Rows[0]["voucher_type"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtDisplayLabel[0].Text = Convert.ToString(rsTempRec.Tables[0].Rows[0]["voucher_name"]);
					if (rsTempRec.Tables[0].Rows.Count > 1)
					{
						//MsgBox "Invalid voucher setting, contact administrator", vbInformation
						//Unload Me
					}
				}
				rsTempRec = null;



				//'Set the Cash and Credit transaction type list box
				rsTransactionType = new DataSet();
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsTransactionType.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("Transaction_Type", DbType.String, 10, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2070) Constant adOpenUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTransactionType.Open was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTransactionType.Open(null, null, UpgradeStubs.ADODB_CursorTypeEnum.getadOpenUnspecified(), UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified(), -1);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTransactionType.AddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTransactionType.AddNew("Transaction_Type", mCreditTransCaption);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTransactionType.AddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTransactionType.AddNew("Transaction_Type", mCashTransCaption);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTransactionType.Update was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsTransactionType.Update_Renamed(null, null);

				CalculateTotals(0, 0);
				CalculateTotals1(0, 0);
				grdExpensesDetails.Rebind(true);

				txtVoucherDate.Value = DateTime.Today;
				FirstFocusObject = txtCommonTextBox[SystemICSConstants.tcImportLocationCode];

				SetDefaultValues();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;

				aExpensesDetails = null;
				rsDrList = null;
				rsCrList = null;
				rsCCList = null;

				oThisFormToolBar = null;
				frmICSVoucherExpenses.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			grdVoucherDetails.UpdateData();

			int mCurrentRow = grdVoucherDetails.Row;
			switch(ColIndex)
			{
				case SystemICSConstants.grdExpensesColumn : 
					CalculateTotals1(mCurrentRow, ColIndex); 
					break;
			}
		}



		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			string mysql = "";
			object mTempReturnValue = null;
			int mSetValueIndex = 0;

			if (SystemVariables.gSkipTextBoxLostFocus)
			{
				return;
			}

			try
			{

				switch(Index)
				{
					case SystemICSConstants.tcImportLocationCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name"); 
						mysql = mysql + ",'' from SM_Location where locat_no = " + txtCommonTextBox[Index].Text; 
						 
						mSetValueIndex = SystemICSConstants.tcImportLocationCode; 
						break;
					case SystemICSConstants.tcImportVoucherType : 
						//            mSetValueIndex = -1 
						break;
					case SystemICSConstants.tcImportVoucherNo : 
						mysql = " select voucher_no from ICS_Transaction mt "; 
						mysql = mysql + " inner join SM_Location on mt.locat_cd = SM_Location.locat_cd "; 
						mysql = mysql + " where mt.voucher_type=" + txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text; 
						mysql = mysql + " and mt.expenses_amt = 0 "; 
						mysql = mysql + " and mt.status = 2 "; 
						mysql = mysql + " and mt.posted_gl = 0 "; 
						mysql = mysql + " and mt.posted_gl_expense = 0 "; 
						mysql = mysql + " and mt.voucher_no = " + txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Text; 
						mysql = mysql + " and SM_Location.locat_no = " + txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text; 
						 
						mSetValueIndex = -2; 
						break;
					default:
						mSetValueIndex = 0; 
						break;
				}

				if (mSetValueIndex > 0)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[Index].Text, SystemVariables.DataType.StringType))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempReturnValue))
						{
							if (Index == SystemICSConstants.tcImportLocationCode)
							{
								txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Text = "";
								txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Enabled = false;
							}
							else
							{
								//.txtDisplayLabel(mSetValueIndex).Text = ""
							}

							throw new System.Exception("-9990002");
						}
						else
						{
							if (Index == SystemICSConstants.tcImportLocationCode)
							{
								if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
								{
									txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Enabled = true;
									//If Me.ActiveControl.Name = "txtVoucherDate" Then
									//txtCommonTextBox(tcImportVoucherNo).SetFocus
									//End If
								}
							}
							else
							{
								//.txtDisplayLabel(mSetValueIndex).Text = mTempReturnValue(0)
							}
						}
					}
					else
					{
						//.txtDisplayLabel(mSetValueIndex).Text = ""
						if (Index == SystemICSConstants.tcImportLocationCode)
						{
							txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Enabled = false;
						}
					}
				}
				else if (mSetValueIndex == -1)
				{ 
					//''Nothing
				}
				else if (mSetValueIndex == -2)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[Index].Text, SystemVariables.DataType.NumberType))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempReturnValue))
						{
							if (!GetLinkedVoucherDetails())
							{
								throw new System.Exception("-9990002");
							}
							else
							{
								txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Enabled = false;
								txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Enabled = false;
								//Call TextBoxLostFocus(pForm, tcLedgerCode, pclsICSTransaction)
							}
						}
						else
						{
							throw new System.Exception("-9990002");
						}
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
					if (txtCommonTextBox[Index].Enabled)
					{
						txtCommonTextBox[Index].Focus();
					}
				}
				else
				{
					//
				}
			}


		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
		}

		public void GetRecord(object pSearchValue)
		{


			if (SystemProcedure2.IsItEmpty(pSearchValue, SystemVariables.DataType.NumberType))
			{
				return;
			}

			string mysql = " select * ";
			mysql = mysql + " from ics_voucher_expenses ";
			mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

			SqlDataReader rsLocalRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			if (rsLocalRec.Read())
			{
				CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				SearchValue = rsLocalRec["entry_id"];
				mTimeStamp = SystemProcedure2.tsFormat(Convert.ToString(rsLocalRec["time_stamp"]));

				//Set the form caption and Get the Voucher Status
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, Convert.ToInt32(rsLocalRec["status"]), CurrentFormMode, "Expenses and Charges", "Transaction");
				//''''*************************************************************************

				txtCommonTextBox[SystemICSConstants.tcVoucherNo].Text = Convert.ToString(rsLocalRec["voucher_no"]);
				txtVoucherDate.Value = rsLocalRec["voucher_date"];
				txtCommonTextBox[SystemICSConstants.tcReferenceNo].Text = Convert.ToString(rsLocalRec["reference_no"]) + "";
				txtCommonTextBox[SystemICSConstants.tcComments].Text = Convert.ToString(rsLocalRec["comments"]) + "";

				GetVoucherExpensesDetails(Convert.ToInt32(rsLocalRec["entry_id"]));

				GetParentVoucherDetails(Convert.ToInt32(rsLocalRec["linked_voucher_type"]), Convert.ToInt32(rsLocalRec["linked_entry_id"]));
			}
		}

		private void txtVoucherDate_Validating(Object eventSender, CancelEventArgs eventArgs)
		{
			bool Cancel = eventArgs.Cancel;
			try
			{
				if (Information.IsDate(txtVoucherDate.Value))
				{
					Cancel = !SystemProcedure2.ValidDateRange(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value));
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel;
			}
		}

		public void CloseForm()
		{
			this.Close();
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

			if (mObjectName == "txtCommonTextBox")
			{
				txtCommonTextBox[mIndex].Text = "";
				switch(mIndex)
				{
					case SystemICSConstants.tcImportVoucherType : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(200, "693")); 
						break;
					case SystemICSConstants.tcImportLocationCode : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2004000, "82")); 
						break;
					case SystemICSConstants.tcImportVoucherNo : 
						if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text))
						{
							mysql = " mt.voucher_type=" + txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text;
							mysql = mysql + " and mt.expenses_amt = 0 ";
							mysql = mysql + " and mt.status = 2 ";
							mysql = mysql + " and mt.posted_gl = 0 ";
							mysql = mysql + " and mt.posted_gl_expense = 0 ";
							mysql = mysql + " and mloc.locat_no = " + txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text;
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(4000107, "1035", mysql));
						} 
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
					txtCommonTextBox[mIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
				}
			}
		}

		private bool GetLinkedVoucherDetails()
		{
			SqlDataReader rsLocalRec = null;
			int Cnt = 0;
			string mysql = "";
			string mParentMasterTableName = "";
			string mParentDetailsTableName = "";
			string mLedgerCurrencyCaption = "";

			object mTempValue = null;
			int mImportLocatCode = 0;

			//if  import location code or import voucher no is empty then exit sub
			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text, SystemVariables.DataType.NumberType) || SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Text, SystemVariables.DataType.NumberType))
			{
				goto mend;
			}


			//Get the Header Location Code
			if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text, SystemVariables.DataType.NumberType))
			{
				mysql = "select locat_cd from SM_Location where locat_no =";
				mysql = mysql + txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text;

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempValue))
				{
					//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mImportLocatCode = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
				}
				else
				{
					goto mend;
				}
			}


			//Get the master and details table from the voucher type entered
			mysql = "select master_table_name , details_table_name ";
			mysql = mysql + " from ICS_Transaction_Types ";
			mysql = mysql + " where voucher_type= " + txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempValue))
			{
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mParentMasterTableName = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mParentDetailsTableName = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));


				mysql = " select ldgr_no ";
				mysql = mysql + " ," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name") + " as ldgr_name ";
				mysql = mysql + " , mt.voucher_date, mt.reference_no, mt.time_stamp ";
				mysql = mysql + " , mt.exchange_rate ";
				mysql = mysql + " , gl_currency.symbol as curr_symbol";
				mysql = mysql + " , dt.Entry_Id, dt.Line_No, dt.Prod_Cd, dt.Unit_Entry_Id ";
				mysql = mysql + " , dt.Project_cd, dt.Exchange_Rate, dt.Prod_Name, dt.Reference_No ";
				mysql = mysql + " , dt.Qty, dt.Base_Qty, dt.Processed_Qty , dt.Balance_Qty";
				mysql = mysql + " , ICS_Item.serialized  , ICS_Item.item_type_cd ";
				mysql = mysql + " , (aud.alt_qty * dt.Balance_Qty) / aud.base_qty as Alt_Unit_balance_qty ";
				mysql = mysql + " , dt.FC_Rate, dt.FC_Prod_Dis, dt.FC_Amount, dt.Prod_Exp_Amt ";
				mysql = mysql + " , dt.Dis_In_Percent, dt.promo_type, dt.Status , ICS_Item.part_no ";
				mysql = mysql + " , ICS_Unit.symbol ";
				mysql = mysql + " , SM_Location.locat_no locat_no ";
				mysql = mysql + " from " + mParentDetailsTableName + " dt ";
				mysql = mysql + " inner join ICS_Item on dt.prod_cd = ICS_Item.prod_cd ";
				mysql = mysql + " inner join ICS_Item_Types it on it.item_type_cd = ICS_Item.item_type_cd ";
				mysql = mysql + " inner join " + mParentMasterTableName + " mt on mt.entry_id = dt.entry_id  ";
				mysql = mysql + " inner join ICS_Item_Unit_Details aud on dt.unit_entry_id = aud.unit_entry_id ";
				mysql = mysql + " inner join ICS_Unit on ICS_Unit.unit_cd = aud.alt_unit_cd ";
				mysql = mysql + " inner join SM_Location on mt.locat_cd = SM_Location.locat_cd ";
				mysql = mysql + " left join gl_ledger on mt.ldgr_cd = gl_ledger.ldgr_cd  ";
				mysql = mysql + " inner join gl_currency on gl_ledger.curr_cd = gl_currency.curr_cd  ";
				mysql = mysql + " where mt.voucher_no = " + txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Text;
				mysql = mysql + " and mt.locat_cd = " + Conversion.Str(mImportLocatCode);
				mysql = mysql + " and mt.voucher_type = " + txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text;
				mysql = mysql + " and mt.status = 2 ";
				mysql = mysql + " and mt.expenses_amt = 0 ";
				mysql = mysql + " and it.affect_stock = 1 ";
				mysql = mysql + " order by dt.line_no ";

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand.ExecuteReader();
				if (rsLocalRec.Read())
				{
					SystemGrid.DefineVoucherArray(aVoucherDetails, SystemICSConstants.grdArrayUbound, 0, true);

					txtCommonTextBox[SystemICSConstants.tcLedgerCode].Text = Convert.ToString(rsLocalRec["ldgr_no"]);
					txtDisplayLabel[SystemICSConstants.dcLedgerName].Text = Convert.ToString(rsLocalRec["ldgr_name"]);

					txtVoucherDate.Value = rsLocalRec["voucher_date"];
					txtCommonTextBox[SystemICSConstants.tcReferenceNo].Text = Convert.ToString(rsLocalRec["reference_no"]) + "";

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("is_bilingual"))) == TriState.True)
					{
						mLedgerCurrencyCaption = SystemProcedure2.GetSystemLabel(877);
					}
					else
					{
						mLedgerCurrencyCaption = "Currency :";
					}

					lblCommonLabel[SystemICSConstants.lcLedgerDetailsCurrency].Caption = mLedgerCurrencyCaption;
					txtCommonTextBox[SystemICSConstants.tcCurrencySymbol].Text = Convert.ToString(rsLocalRec["curr_symbol"]);

					mParentVoucherTimeStamp = Convert.ToString(rsLocalRec["time_stamp"]);
					txtExchangeRate.Value = rsLocalRec["exchange_rate"];


					//Set the form caption and Get the Voucher Status
					SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, "Expenses and Charges", "Transaction");
					//''''*************************************************************************

					do 
					{
						SystemGrid.DefineVoucherArray(aVoucherDetails, SystemICSConstants.grdArrayUbound, Cnt, false);

						//Get the details information into the grid
						aVoucherDetails.SetValue(Cnt + 1, Cnt, SystemICSConstants.grdLineNoColumn);
						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["part_no"]).Trim(), Cnt, SystemICSConstants.grdProductCodeColumn);
						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["prod_name"]).Trim(), Cnt, SystemICSConstants.grdProductNameColumn);
						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["symbol"]).Trim(), Cnt, SystemICSConstants.grdUnitSymbolColumn);
						aVoucherDetails.SetValue(rsLocalRec["serialized"], Cnt, SystemICSConstants.grdSerialisedColumn);
						aVoucherDetails.SetValue(rsLocalRec["item_type_cd"], Cnt, SystemICSConstants.grdItemTypeColumn);
						aVoucherDetails.SetValue(0, Cnt, SystemICSConstants.grdRemainingQtyColumn);
						aVoucherDetails.SetValue(rsLocalRec["qty"], Cnt, SystemICSConstants.grdQtyColumn);
						aVoucherDetails.SetValue(rsLocalRec["fc_rate"], Cnt, SystemICSConstants.grdRateColumn);
						aVoucherDetails.SetValue(rsLocalRec["fc_prod_dis"], Cnt, SystemICSConstants.grdDiscountAmountColumn);
						aVoucherDetails.SetValue(rsLocalRec["fc_amount"], Cnt, SystemICSConstants.grdProductAmountColumn);
						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["prod_exp_amt"]).Trim() + "", Cnt, SystemICSConstants.grdExpensesColumn);
						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["reference_no"]).Trim() + "", Cnt, SystemICSConstants.grdRemarksColumn);
						aVoucherDetails.SetValue(rsLocalRec["line_no"], Cnt, SystemICSConstants.grdParentLineNo);

						Cnt++;
					}
					while(rsLocalRec.Read());


					CalculateTotals1(0, 0);
					grdVoucherDetails.Rebind(true);

					rsLocalRec.Close();

					return true;
				}
			}
			mend:
			//if the execution reaches here that means no valid records were found
			return false;
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			//--handle Null value error ---> when there is no ICS_Item in the
			//--system & the drop-down ICS_Item list combo is click
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				switch(ColIndex)
				{
					case SystemICSConstants.grdQtyColumn : 
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
					case SystemICSConstants.grdRateColumn : case SystemICSConstants.grdDiscountAmountColumn : case SystemICSConstants.grdProductAmountColumn : case SystemICSConstants.grdExpensesColumn : 
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

		private void CalculateTotals(int mRowNumber, int mColNumber)
		{
			int Cnt = 0;
			double mExpensesAmt = 0;
			double mCashAmt = 0;

			int tempForEndVar = aExpensesDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				if (SystemProcedure2.IsItEmpty(aExpensesDetails.GetValue(Cnt, cCrLCAmt), SystemVariables.DataType.NumberType))
				{
					aExpensesDetails.SetValue("", Cnt, cCrLCAmt);
				}
				if (SystemProcedure2.IsItEmpty(aExpensesDetails.GetValue(Cnt, cDrLCAmt), SystemVariables.DataType.NumberType))
				{
					aExpensesDetails.SetValue("", Cnt, cDrLCAmt);
				}

				aExpensesDetails.SetValue(StringsHelper.Format(aExpensesDetails.GetValue(Cnt, cCrLCAmt), "##,###,###.000"), Cnt, cCrLCAmt);
				mCashAmt += Conversion.Val(StringsHelper.Format(aExpensesDetails.GetValue(Cnt, cCrLCAmt), "###############.######"));

				aExpensesDetails.SetValue(StringsHelper.Format(aExpensesDetails.GetValue(Cnt, cDrLCAmt), "##,###,###.000"), Cnt, cDrLCAmt);
				mExpensesAmt += Conversion.Val(StringsHelper.Format(aExpensesDetails.GetValue(Cnt, cDrLCAmt), "###############.######"));
			}

			if (!SystemProcedure2.IsItEmpty(mCashAmt, SystemVariables.DataType.NumberType))
			{
				grdExpensesDetails.Columns[cCrLCAmt].FooterText = StringsHelper.Format(mCashAmt, "###,###,###.000");
			}
			else
			{
				grdExpensesDetails.Columns[cCrLCAmt].FooterText = "";
			}
			if (!SystemProcedure2.IsItEmpty(mExpensesAmt, SystemVariables.DataType.NumberType))
			{
				grdExpensesDetails.Columns[cDrLCAmt].FooterText = StringsHelper.Format(mExpensesAmt, "###,###,###.000");
			}
			else
			{
				grdExpensesDetails.Columns[cDrLCAmt].FooterText = "";
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMasterList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMasterList_DataSourceChanged()
		{
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_3 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_4 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_5 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_6 = null;
			switch(grdExpensesDetails.Col)
			{
				case cDrLdgrCode : case cCrLdgrCode : 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar = cmbMasterList.Splits[0].DisplayColumns[0]; 
					withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar.Width = grdExpensesDetails.Splits[0].DisplayColumns[cDrLdgrCode].Width; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar_2 = cmbMasterList.Splits[0].DisplayColumns[2]; 
					withVar_2.Visible = false; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar_3 = cmbMasterList.Splits[0].DisplayColumns[3]; 
					withVar_3.Visible = false; 
					cmbMasterList.Width = 267; 
					break;
				case cDrCostCode : case cCrCostCode : 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar_4 = cmbMasterList.Splits[0].DisplayColumns[0]; 
					withVar_4.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar_4.Width = grdExpensesDetails.Splits[0].DisplayColumns[cDrCostCode].Width; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar_5 = cmbMasterList.Splits[0].DisplayColumns[2]; 
					withVar_5.Visible = false; 
					cmbMasterList.Width = 267; 
					break;
				case cTransactionType : 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar_6 = cmbMasterList.Splits[0].DisplayColumns[0]; 
					withVar_6.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar_6.Width = grdExpensesDetails.Splits[0].DisplayColumns[cTransactionType].Width; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbMasterList.Width = grdExpensesDetails.Splits[0].DisplayColumns[cTransactionType].Width; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMasterList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMasterList_RowChange()
		{
			int mReturnValue = 0;

			if (grdExpensesDetails.Col == cDrLdgrCode)
			{
				grdExpensesDetails.Columns[cDrCurr].Value = cmbMasterList.Columns[2].Value;

				mReturnValue = CheckCurrency(1, cmbMasterList.Columns[0].Value);
				if (mReturnValue == 1)
				{
					grdExpensesDetails.Columns[cDrRate].Value = "";
					grdExpensesDetails.Columns[cDrFCAmt].Value = "";

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cDrRate].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cDrFCAmt].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cDrLCAmt].AllowFocus = true;

				}
				else if (mReturnValue == 2)
				{ 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cDrRate].AllowFocus = true;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cDrFCAmt].AllowFocus = true;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cDrLCAmt].AllowFocus = false;
				}
				else if (mReturnValue == 0)
				{ 
					grdExpensesDetails.Columns[cDrRate].Value = "";
					grdExpensesDetails.Columns[cDrFCAmt].Value = "";
					grdExpensesDetails.Columns[cDrLCAmt].Value = "";

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cDrRate].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cDrFCAmt].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cDrLCAmt].AllowFocus = false;
				}

			}
			else if (grdExpensesDetails.Col == cCrLdgrCode)
			{ 
				grdExpensesDetails.Columns[cCrCurr].Value = cmbMasterList.Columns[2].Value;

				mReturnValue = CheckCurrency(2, cmbMasterList.Columns[0].Value);
				if (mReturnValue == 1)
				{
					grdExpensesDetails.Columns[cCrRate].Value = "";
					grdExpensesDetails.Columns[cCrFCAmt].Value = "";

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cCrRate].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cCrFCAmt].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cCrLCAmt].AllowFocus = true;

				}
				else if (mReturnValue == 2)
				{ 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cCrRate].AllowFocus = true;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cCrFCAmt].AllowFocus = true;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cCrLCAmt].AllowFocus = false;
				}
				else if (mReturnValue == 0)
				{ 

					grdExpensesDetails.Columns[cCrRate].Value = "";
					grdExpensesDetails.Columns[cCrFCAmt].Value = "";
					grdExpensesDetails.Columns[cCrLCAmt].Value = "";

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cCrRate].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cCrFCAmt].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cCrLCAmt].AllowFocus = false;
				}
			}
		}

		private void grdExpensesDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;

			grdExpensesDetails.UpdateData();
			int mCurrentRow = grdExpensesDetails.Row;
			switch(ColIndex)
			{
				case 1 : 
					break;
				case cDrLCAmt : case cCrLCAmt : 
					CalculateTotals(mCurrentRow, ColIndex); 
					break;
				case cDrRate : case cDrFCAmt : 
					grdExpensesDetails.Columns[cDrLCAmt].Text = (Conversion.Val(StringsHelper.Format(grdExpensesDetails.Columns[cDrRate].Text, "#############.##########")) * Conversion.Val(StringsHelper.Format(grdExpensesDetails.Columns[cDrFCAmt].Text, "#############.000"))).ToString(); 
					grdExpensesDetails.UpdateData(); 
					CalculateTotals(mCurrentRow, cDrLCAmt); 
					break;
				case cCrRate : case cCrFCAmt : 
					grdExpensesDetails.Columns[cCrLCAmt].Text = (Conversion.Val(StringsHelper.Format(grdExpensesDetails.Columns[cCrRate].Text, "#############.##########")) * Conversion.Val(StringsHelper.Format(grdExpensesDetails.Columns[cCrFCAmt].Text, "#############.000"))).ToString(); 
					grdExpensesDetails.UpdateData(); 
					CalculateTotals(mCurrentRow, cCrLCAmt); 
					break;
			}

		}

		private void grdExpensesDetails_BeforeColEdit(object eventSender, C1.Win.C1TrueDBGrid.BeforeColEditEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int KeyAscii = (int) eventArgs.KeyChar;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			//Dim mReturnvalue As Integer
			//If ColIndex = cDrFCAmt Or ColIndex = cDrRate Or ColIndex = cDrLCAmt Then
			//    mReturnvalue = CheckCurrency(1, grdExpensesDetails.Columns(cDrLdgrCode).Value)
			//    If mReturnvalue = 1 Then
			//        If ColIndex = cDrFCAmt Or ColIndex = cDrRate Then
			//            grdExpensesDetails.Columns(cDrRate).Value = ""
			//            grdExpensesDetails.Columns(cDrFCAmt).Value = ""
			//
			//            grdExpensesDetails.Columns(cDrRate).AllowFocus = False
			//            grdExpensesDetails.Columns(cDrFCAmt).AllowFocus = False
			//
			//            Cancel = True
			//        Else
			//            Cancel = False
			//        End If
			//    ElseIf mReturnvalue = 2 Then
			//        If ColIndex = cDrFCAmt Or ColIndex = cDrRate Then
			//            Cancel = False
			//        Else
			//            Cancel = True
			//
			//            grdExpensesDetails.Columns(cDrLCAmt).AllowFocus = False
			//        End If
			//    ElseIf mReturnvalue = 0 Then
			//        grdExpensesDetails.Columns(cDrRate).Value = ""
			//        grdExpensesDetails.Columns(cDrFCAmt).Value = ""
			//        grdExpensesDetails.Columns(cDrLCAmt).Value = ""
			//
			//        grdExpensesDetails.Columns(cDrRate).AllowFocus = False
			//        grdExpensesDetails.Columns(cDrFCAmt).AllowFocus = False
			//        grdExpensesDetails.Columns(cDrLCAmt).AllowFocus = False
			//
			//        Cancel = True
			//    End If
			//End If
			//
			//If ColIndex = cCrFCAmt Or ColIndex = cCrRate Or ColIndex = cCrLCAmt Then
			//    mReturnvalue = CheckCurrency(2, grdExpensesDetails.Columns(cCrLdgrCode).Value)
			//    If mReturnvalue = 1 Then
			//        If ColIndex = cCrFCAmt Or ColIndex = cCrRate Then
			//            grdExpensesDetails.Columns(cCrRate).Value = ""
			//            grdExpensesDetails.Columns(cCrFCAmt).Value = ""
			//            Cancel = True
			//        Else
			//            Cancel = False
			//        End If
			//    ElseIf mReturnvalue = 2 Then
			//        If ColIndex = cCrFCAmt Or ColIndex = cCrRate Then
			//            Cancel = False
			//        Else
			//            Cancel = True
			//        End If
			//    ElseIf mReturnvalue = 0 Then
			//        grdExpensesDetails.Columns(cCrRate).Value = ""
			//        grdExpensesDetails.Columns(cCrFCAmt).Value = ""
			//        grdExpensesDetails.Columns(cCrLCAmt).Value = ""
			//        Cancel = True
			//    End If
			//End If
			eventArgs.Cancel = Cancel != 0;
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdExpensesDetails.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdExpensesDetails_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			int mReturnValue = 0;

			if (Col == cDrRate || Col == cDrFCAmt || Col == cDrLCAmt)
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column method grdExpensesDetails.Columns.CellValue was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				mReturnValue = CheckCurrency(1, grdExpensesDetails.Splits[0].DisplayColumns[cDrLdgrCode].CellValue(Bookmark));
				if (mReturnValue == 1)
				{
					if (Col == cDrRate || Col == cDrFCAmt)
					{
						CellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(mDisableColumnBackColor)));
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cDrRate].AllowFocus = false;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cDrFCAmt].AllowFocus = false;
					}
					else
					{
						CellStyle.BackColor = Color.White;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cDrLCAmt].AllowFocus = true;
					}
				}
				else if (mReturnValue == 2)
				{ 
					if (Col == cDrRate || Col == cDrFCAmt)
					{
						CellStyle.BackColor = Color.White;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cDrRate].AllowFocus = true;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cDrFCAmt].AllowFocus = true;
					}
					else
					{
						CellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(mDisableColumnBackColor)));
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cDrLCAmt].AllowFocus = false;
					}
				}
				else if (mReturnValue == 0)
				{ 
					CellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(mDisableColumnBackColor)));
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cDrRate].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cDrFCAmt].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cDrLCAmt].AllowFocus = false;
				}
			}
			else if (Col == cCrRate || Col == cCrFCAmt || Col == cCrLCAmt)
			{ 
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column method grdExpensesDetails.Columns.CellValue was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				mReturnValue = CheckCurrency(2, grdExpensesDetails.Splits[0].DisplayColumns[cCrLdgrCode].CellValue(Bookmark), ReflectionHelper.GetPrimitiveValue<int>(Bookmark));
				if (mReturnValue == 1)
				{
					if (Col == cCrRate || Col == cCrFCAmt)
					{
						CellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(mDisableColumnBackColor)));
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cCrRate].AllowFocus = false;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cCrFCAmt].AllowFocus = false;
					}
					else
					{
						CellStyle.BackColor = Color.White;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cCrLCAmt].AllowFocus = true;
					}
				}
				else if (mReturnValue == 2)
				{ 
					if (Col == cCrRate || Col == cCrFCAmt)
					{
						CellStyle.BackColor = Color.White;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cCrRate].AllowFocus = true;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cCrFCAmt].AllowFocus = true;
					}
					else
					{
						CellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(mDisableColumnBackColor)));
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cCrLCAmt].AllowFocus = false;
					}
				}
				else if (mReturnValue == 0)
				{ 
					CellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(mDisableColumnBackColor)));
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cCrRate].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cCrFCAmt].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cCrLCAmt].AllowFocus = false;
				}
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdExpensesDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdExpensesDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == cDrRate || ColIndex == cDrFCAmt || ColIndex == cDrLCAmt || ColIndex == cCrRate || ColIndex == cCrFCAmt || ColIndex == cCrLCAmt)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					if (ColIndex == cDrRate || ColIndex == cCrRate)
					{
						Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###.000#########");
					}
					else
					{
						Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###,###,###.000");
					}
				}
				else
				{
					Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "0.000");
				}
			}

		}

		private void grdExpensesDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			//Check for tag value of the column and fill the listbox accordingly
			if (SystemProcedure2.IsItEmpty(Convert.ToString(grdExpensesDetails.Tag), SystemVariables.DataType.StringType))
			{
				grdExpensesDetails.Tag = "1";

				mysql = "select l.ldgr_no, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l.L_ldgr_name," : "l.A_ldgr_name,");
				mysql = mysql + " gcurr.symbol, gcurr.curr_cd from gl_ledger l";
				mysql = mysql + " inner join gl_currency gcurr on l.curr_cd = gcurr.curr_cd ";
				//mySql = mySql & " and left(group_cd, 4) = 'B-SH' "
				mysql = mysql + " and l.type_cd=" + SystemGLConstants.gGLIncomeExpenseTypeCode.ToString();
				mysql = mysql + " order by 1 ";

				rsDrList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsDrList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsDrList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsDrList.Tables.Clear();
				adap.Fill(rsDrList);

				//Set cmbMasterList.DataSource = rsDrList

				rsCrList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCrList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsCrList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				//Call SetList

				mysql = "select gcc.cost_no , ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "gcc.L_cost_name," : "gcc.A_cost_name,");
				mysql = mysql + " gcc.cost_cd from gl_cost_centers gcc ";
				mysql = mysql + " where gcc.show=1 ";
				mysql = mysql + " order by 1 ";

				rsCCList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCCList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsCCList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsCCList.Tables.Clear();
				adap_2.Fill(rsCCList);

				cmbMasterList_RowChange(cmbMasterList, new EventArgs());
			}

			grdExpensesDetails.Col = 1;
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdExpensesDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdExpensesDetails_OnAddNew()
		{
			grdExpensesDetails.Columns[cLN].Text = (grdExpensesDetails.RowCount + 1).ToString();
			grdExpensesDetails.Columns[cTransactionType].Text = mCreditTransCaption;
		}


		private int CheckCurrency(int pDrCr, object pLdgrNo, int pRowNo = -1)
		{
			//0=Not found
			//1=Base currency
			//2=Foreign Currency

			DataSet rsCloneRecordset = null;
			string mysql = "";
			object mReturnValue = null;

			if (SystemProcedure2.IsItEmpty(pLdgrNo, SystemVariables.DataType.StringType))
			{
				return 0;
			}

			if (pRowNo == -1)
			{

				if (pDrCr == 1)
				{
					//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDrList.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsCloneRecordset = rsDrList.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
				}
				else
				{
					//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsCrList.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsCloneRecordset = rsCrList.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());
				}

				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsCloneRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsCloneRecordset.MoveFirst();
				rsCloneRecordset.Find("ldgr_no='" + ReflectionHelper.GetPrimitiveValue<string>(pLdgrNo).Trim() + "'");
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCloneRecordset.BOF was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (rsCloneRecordset.Tables[0].Rows.Count != 0 || rsCloneRecordset.getBOF())
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToDouble(rsCloneRecordset.Tables[0].Rows[0]["curr_cd"]) == SystemGLConstants.gDefaultCurrencyCd)
					{
						return 1;
					}
					else
					{
						return 2;
					}
				}
				else
				{
					return 0;
				}
			}
			else
			{
				mysql = "select curr_cd from gl_ledger ";
				mysql = mysql + " where ldgr_no='" + ReflectionHelper.GetPrimitiveValue<string>(pLdgrNo) + "'";

				if (Convert.ToString(aExpensesDetails.GetValue(pRowNo, cTransactionType)).Trim() == "Cash")
				{
					//        mySql = mySql & " and (ldgr_type='B-CH' "
					//        mySql = mySql & " or ldgr_type='B-BA')"
					mysql = mysql + " and ( gl_ledger.type_cd =" + SystemGLConstants.gGLCashTypeCode.ToString();
					mysql = mysql + " or gl_ledger.type_cd =" + SystemGLConstants.gGLBankTypeCode.ToString() + ")";
				}
				else
				{
					mysql = mysql + " and gl_ledger.type_cd <> " + SystemGLConstants.gGLCashTypeCode.ToString();
					mysql = mysql + " and gl_ledger.type_cd <> " + SystemGLConstants.gGLBankTypeCode.ToString();
					//mySql = mySql & " and ldgr_type <> 'F-BO' "
				}

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == SystemGLConstants.gDefaultCurrencyCd)
					{
						return 1;
					}
					else
					{
						return 2;
					}
				}
				else
				{
					return 0;
				}
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdExpensesDetails")
			{
				grdExpensesDetails.Focus();
			}

			if (aExpensesDetails.GetLength(0) > 0)
			{
				grdExpensesDetails.Delete();
				AssignGridLineNumbers();
				grdExpensesDetails.Rebind(true);
				grdExpensesDetails.Focus();
				CalculateTotals(0, 1);
				grdExpensesDetails.Refresh();
			}
		}

		private void grdExpensesDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (LastCol == cTransactionType || grdExpensesDetails.Col == cCrLdgrCode)
			{
				SetList();
			}
			switch(grdExpensesDetails.Col)
			{
				case cTransactionType : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMasterList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMasterList.setDataSource((msdatasrc.DataSource) rsTransactionType); 
					break;
				case cDrLdgrCode : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMasterList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMasterList.setDataSource((msdatasrc.DataSource) rsDrList); 
					break;
				case cCrLdgrCode : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMasterList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMasterList.setDataSource((msdatasrc.DataSource) rsCrList); 
					break;
				case cDrCostCode : case cCrCostCode : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMasterList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMasterList.setDataSource((msdatasrc.DataSource) rsCCList); 
					break;
			}
		}

		private void SetList()
		{

			string mysql = "select ldgr_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_ldgr_name," : "A_ldgr_name,");
			mysql = mysql + " gl_currency.symbol,gl_currency.curr_cd from gl_ledger inner join gl_currency";
			mysql = mysql + " on gl_ledger.curr_cd = gl_currency.curr_cd ";
			mysql = mysql + " where ";

			if (ReflectionHelper.GetPrimitiveValue<string>(grdExpensesDetails.Columns[cTransactionType].Value).Trim() == "Cash")
			{
				//    mySql = mySql & " ldgr_type='B-CH' "
				//    mySql = mySql & " or ldgr_type='B-BA'"

				mysql = mysql + " gl_ledger.type_cd =" + SystemGLConstants.gGLCashTypeCode.ToString();
				mysql = mysql + " or gl_ledger.type_cd =" + SystemGLConstants.gGLBankTypeCode.ToString();

			}
			else
			{
				//    mySql = mySql & " ldgr_type = 'B-SD' "
				//    mySql = mySql & " or ldgr_type = 'C-SC' "

				mysql = mysql + " gl_ledger.type_cd =" + SystemGLConstants.gGLCustomerVendorTypeCode.ToString();
			}
			mysql = mysql + " order by 1 ";

			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCrList.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			if (rsCrList.getState() == ConnectionState.Open)
			{
			}
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsCrList.Tables.Clear();
			adap.Fill(rsCrList);

		}

		private void CalculateTotals1(int mRowNumber, int mColNumber)
		{
			int Cnt = 0;
			double mTotalQty = 0;
			double mTotalAmt = 0;
			double mExpensesAmt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				//aVoucherDetails(cnt, grdExpensesColumn) = Format(aVoucherDetails(cnt, grdExpensesColumn), "##,###,###.000")
				mExpensesAmt += Conversion.Val(StringsHelper.Format(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdExpensesColumn), "###############.######"));

				//aVoucherDetails(cnt, grdQtyColumn) = Format(aVoucherDetails(cnt, grdQtyColumn), "##,###,###.000")
				mTotalQty += Conversion.Val(StringsHelper.Format(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdQtyColumn), "###############.######"));

				//aVoucherDetails(cnt, grdProductAmountColumn) = Format(aVoucherDetails(cnt, grdProductAmountColumn), "##,###,###.000")
				mTotalAmt += Conversion.Val(StringsHelper.Format(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdProductAmountColumn), "###############.######"));
			}

			if (mExpensesAmt != 0)
			{
				grdVoucherDetails.Columns[SystemICSConstants.grdExpensesColumn].FooterText = StringsHelper.Format(mExpensesAmt, "###,###,###.000");
			}
			else
			{
				grdVoucherDetails.Columns[SystemICSConstants.grdExpensesColumn].FooterText = "";
			}

			if (mTotalQty != 0)
			{
				if (mTotalQty - Math.Floor(mTotalQty) > 0)
				{
					grdVoucherDetails.Columns[SystemICSConstants.grdQtyColumn].FooterText = StringsHelper.Format(mTotalQty, "###,###,###,##0.0##");
				}
				else
				{
					grdVoucherDetails.Columns[SystemICSConstants.grdQtyColumn].FooterText = StringsHelper.Format(mTotalQty, "###,###,###,##0");
				}
			}
			else
			{
				grdVoucherDetails.Columns[SystemICSConstants.grdQtyColumn].FooterText = "";
			}

			if (mTotalAmt != 0)
			{
				grdVoucherDetails.Columns[SystemICSConstants.grdProductAmountColumn].FooterText = StringsHelper.Format(mTotalAmt, "###,###,###.000");
			}
			else
			{
				grdVoucherDetails.Columns[SystemICSConstants.grdProductAmountColumn].FooterText = "";
			}
		}


		public bool CheckDataValidity()
		{
			//Dim cnt As Long
			//Dim mReturnValue As Integer
			//Dim mExpensesAmt As Double
			//Dim mDrAmt As Double
			//
			//grdExpensesDetails.Update
			//
			//If mOldVoucherStatus <> stActive Then
			//    Call VoucherStatusErrorMessage(mOldVoucherStatus, 2)
			//    If FirstFocusObject.Enabled = True Then
			//        FirstFocusObject.SetFocus
			//    End If
			//    GoTo mend
			//End If
			//
			//If IsItEmpty(txtCommonTextBox(tcImportVoucherType).Text, NumberType) Then
			//    MsgBox " Enter Parent Voucher Type. ", vbInformation
			//    If txtCommonTextBox(tcImportVoucherType).Enabled = True Then
			//        txtCommonTextBox(tcImportVoucherType).SetFocus
			//    End If
			//    GoTo mend
			//End If
			//
			//If IsItEmpty(txtCommonTextBox(tcImportLocationCode).Text, NumberType) Then
			//    MsgBox " Enter Parent Location Code. ", vbInformation
			//    If txtCommonTextBox(tcImportLocationCode).Enabled = True Then
			//        txtCommonTextBox(tcImportLocationCode).SetFocus
			//    End If
			//    GoTo mend
			//End If
			//
			//If IsItEmpty(txtCommonTextBox(tcImportVoucherNo).Text, NumberType) Then
			//    MsgBox " Enter Parent Voucher No. ", vbInformation
			//    If txtCommonTextBox(tcImportVoucherNo).Enabled = True Then
			//        txtCommonTextBox(tcImportVoucherNo).SetFocus
			//    End If
			//    GoTo mend
			//End If
			//
			//If IsItEmpty(txtVoucherDate.Value, DateType) Then
			//    MsgBox "Enter voucher date", vbInformation, "Required"
			//    If txtVoucherDate.Enabled = True Then
			//         txtVoucherDate.SetFocus
			//    End If
			//    GoTo mend
			//Else
			//    If ValidDateRange(txtVoucherDate.Value) = False Then
			//        MsgBox "Invalid Date Range, Check the current financial year", vbInformation, "Required"
			//        If txtVoucherDate.Enabled = True Then
			//             txtVoucherDate.SetFocus
			//        End If
			//        GoTo mend
			//    End If
			//End If
			//
			//
			//mDrAmt = Val(Format(grdExpensesDetails.Columns(cDrLCAmt).FooterText, "###########0.0##"))
			//mExpensesAmt = Val(Format(grdVoucherDetails.Columns(grdExpensesColumn).FooterText, "###########0.0##"))
			//If mDrAmt = 0 Then
			//    MsgBox " Expenses cannot be zero ", vbInformation
			//    grdExpensesDetails.SetFocus
			//    GoTo mend
			//End If
			//
			//If mExpensesAmt <> mDrAmt Then
			//    MsgBox " Expenses should be allcated properly. ", vbInformation
			//    grdVoucherDetails.SetFocus
			//    GoTo mend
			//End If
			//
			//
			//For cnt = 0 To aExpensesDetails.UpperBound(1)
			//'    If cnt > aExpensesDetails.UpperBound(1) Then
			//'        Exit For
			//'    End If
			//'
			//'    If IsItEmpty(aExpensesDetails(cnt, cDrLdgrCode), StringType) Then
			//'        aExpensesDetails.DeleteRows cnt
			//'        If cnt < aExpensesDetails.Count(1) And cnt <> 0 Then
			//'            cnt = cnt - 1
			//'        End If
			//'        grdExpensesDetails.ReBind
			//'    End If
			//'
			//'    Call CalculateTotals(0, 0)
			//'    If cnt > aExpensesDetails.UpperBound(1) Then
			//'        Exit For
			//'    End If
			//
			//
			//    'Check for the Expenses ledger and currency
			//    mReturnValue = CheckCurrency(1, aExpensesDetails(cnt, cDrLdgrCode))
			//    If mReturnValue = 0 Then        'Illegal code
			//        MsgBox "Invalid Ledger code", vbInformation
			//        grdExpensesDetails.Col = cDrLdgrCode
			//        GoTo mGridFocus
			//    ElseIf mReturnValue = 1 Then    'Base Currency
			//        If IsItEmpty(aExpensesDetails(cnt, cDrLCAmt), NumberType) Then
			//            MsgBox "Amount should be greater than zero", vbInformation
			//            grdExpensesDetails.Col = cDrLCAmt
			//            GoTo mGridFocus
			//        End If
			//    ElseIf mReturnValue = 2 Then    'Foreign Currency
			//        If IsItEmpty(aExpensesDetails(cnt, cDrRate), NumberType) Or IsItEmpty(aExpensesDetails(cnt, cDrFCAmt), NumberType) Then
			//            MsgBox "Amount should be greater than zero", vbInformation
			//            grdExpensesDetails.Col = cDrFCAmt
			//            GoTo mGridFocus
			//        End If
			//    End If
			//
			//
			//    'Check for Cash ledger and currency
			//    mReturnValue = CheckCurrency(2, aExpensesDetails(cnt, cCrLdgrCode), cnt)
			//    If mReturnValue = 0 Then        'Illegal code
			//        MsgBox "Invalid Ledger code", vbInformation
			//        grdExpensesDetails.Col = cCrLdgrCode
			//        GoTo mGridFocus
			//    ElseIf mReturnValue = 1 Then    'Base Currency
			//        If IsItEmpty(aExpensesDetails(cnt, cCrLCAmt), NumberType) Then
			//            MsgBox "Amount should be greater than zero", vbInformation
			//            grdExpensesDetails.Col = cCrLCAmt
			//            grdExpensesDetails.Bookmark = cnt
			//            grdExpensesDetails.SetFocus
			//            grdExpensesDetails.ReBind
			//            GoTo mend
			//        End If
			//    ElseIf mReturnValue = 2 Then    'Foreign Currency
			//        If IsItEmpty(aExpensesDetails(cnt, cCrRate), NumberType) Or IsItEmpty(aExpensesDetails(cnt, cCrFCAmt), NumberType) Then
			//            MsgBox "Amount should be greater than zero", vbInformation
			//            grdExpensesDetails.Col = cCrFCAmt
			//            GoTo mGridFocus
			//        End If
			//    End If
			//
			//    If grdExpensesDetails.Columns(cDrCostCode).Visible = True Then
			//        If IsItEmpty(aExpensesDetails(cnt, cDrCostCode), NumberType) Then
			//            MsgBox "Select a cost center.", vbInformation
			//            grdExpensesDetails.Col = cDrCostCode
			//            grdExpensesDetails.Bookmark = cnt
			//            grdExpensesDetails.SetFocus
			//            grdExpensesDetails.ReBind
			//            GoTo mend
			//        End If
			//    End If
			//
			//    If grdExpensesDetails.Columns(cCrCostCode).Visible = True Then
			//        If IsItEmpty(aExpensesDetails(cnt, cCrCostCode), NumberType) Then
			//            MsgBox "Select a cost center.", vbInformation
			//            grdExpensesDetails.Col = cCrCostCode
			//            grdExpensesDetails.Bookmark = cnt
			//            grdExpensesDetails.SetFocus
			//            grdExpensesDetails.ReBind
			//            GoTo mend
			//        End If
			//    End If
			//
			//    If aExpensesDetails(cnt, cDrLCAmt) <> aExpensesDetails(cnt, cCrLCAmt) Then
			//        MsgBox "Debit and credit amount should be equal", vbInformation
			//        grdExpensesDetails.Col = cDrLCAmt
			//        GoTo mGridFocus
			//    End If
			//
			//'    If Not IsDate(aExpensesDetails(Cnt, cTransactionDate)) Then
			//'        MsgBox "Please enter transaction date !", vbInformation
			//'        grdExpensesDetails.Col = cTransactionDate
			//'        GoTo mGridFocus
			//'    Else
			//'        If CDate(txtVoucherDate.Value) <= gCurrentPeriodEnds Then
			//'            If CDate(aExpensesDetails(Cnt, cTransactionDate)) >= CDate(gCurrentPeriodStarts) And CDate(aExpensesDetails(Cnt, cTransactionDate)) <= CDate(gCurrentPeriodEnds) Then
			//'                'ok
			//'            Else
			//'                MsgBox "Enter a valid Date between the financial years !", vbInformation
			//'                grdExpensesDetails.Col = cTransactionDate
			//'                GoTo mGridFocus
			//'            End If
			//'        Else
			//'            If CDate(aExpensesDetails(Cnt, cTransactionDate)) >= CDate(gNextPeriodStarts) And CDate(aExpensesDetails(Cnt, cTransactionDate)) <= CDate(gNextPeriodEnds) Then
			//'                'ok
			//'            Else
			//'                MsgBox "Enter a valid Date between the financial years !", vbInformation
			//'                grdExpensesDetails.Col = cTransactionDate
			//'                GoTo mGridFocus
			//'            End If
			//'        End If
			//'    End If
			//
			//    If Not IsDate(aExpensesDetails(cnt, cTransactionDate)) Then
			//        MsgBox "Please enter transaction date !", vbInformation
			//        grdExpensesDetails.Col = cTransactionDate
			//        GoTo mGridFocus
			//    Else
			//        If ValidDateRange(aExpensesDetails(cnt, cTransactionDate)) = False Then
			//            MsgBox "Enter a valid Date between the financial years !", vbInformation
			//            grdExpensesDetails.Col = cTransactionDate
			//            GoTo mGridFocus
			//        End If
			//    End If
			//Next
			//
			//If grdExpensesDetails.Columns(cDrLCAmt).FooterText <> grdExpensesDetails.Columns(cCrLCAmt).FooterText Then
			//    MsgBox "Total Debit and Total credit amount should be equal", vbInformation
			//    grdExpensesDetails.Col = cDrLCAmt
			//    grdExpensesDetails.SetFocus
			//    GoTo mend
			//End If
			//
			//CheckDataValidity = True
			//Exit Function
			//
			//mGridFocus:
			//grdExpensesDetails.Bookmark = cnt
			//grdExpensesDetails.SetFocus
			//GoTo mend
			//Exit Function
			//
			//mend:
			//CheckDataValidity = False
			//Exit Function
			return false;
		}


		public bool saveRecord(bool pApprove = false)
		{
			//Dim mTempValue As Variant
			//Dim mySql As String
			//Dim mParentMasterTableName As String
			//Dim mParentDetailsTableName As String
			//Dim mParentVoucherType As Integer
			//Dim mParentVoucherEntryId As Long
			//Dim mNewEntryID  As Long
			//Dim mHeaderLocatCode As Long
			//
			//
			//Dim myHourGlass As clsHourGlass
			//Set myHourGlass = New clsHourGlass
			//
			//
			//'On Error GoTo eFoundError
			//
			//
			//''''****************************Get the Loation Code ****************************
			//'''''****************************************************************************
			//mTempValue = GetMasterCode("select locat_cd from SM_Location where locat_no=" & txtCommonTextBox(tcImportLocationCode).Text)
			//If IsNull(mTempValue) Then
			//    MsgBox "Enter valid location code", vbInformation, "Error"
			//    If txtCommonTextBox(tcLocationCode).Enabled = True Then
			//        txtCommonTextBox(tcLocationCode).SetFocus
			//    End If
			//    GoTo StationExitFunction
			//Else
			//    mHeaderLocatCode = mTempValue
			//End If
			//'''''****************************************************************************
			//
			//
			//''''****************************if the parent voucher type code is not null then
			//'''' get the entry_id and check the timeStamp
			//'''''****************************************************************************
			//mySql = "select master_table_name , details_table_name "
			//mySql = mySql & " from ICS_Transaction_Types "
			//mySql = mySql & " where voucher_type=" & txtCommonTextBox(tcImportVoucherType).Text
			//mTempValue = GetMasterCode(mySql)
			//If Not IsNull(mTempValue) Then
			//    mParentMasterTableName = mTempValue(0)
			//    mParentDetailsTableName = mTempValue(1)
			//    mParentVoucherType = txtCommonTextBox(tcImportVoucherType).Text
			//End If
			//
			//mySql = " select mt.entry_id , mt.time_stamp "
			//mySql = mySql & " from " & mParentMasterTableName & " mt "
			//mySql = mySql & " inner join SM_Location "
			//mySql = mySql & " on mt.locat_cd = SM_Location.locat_cd "
			//mySql = mySql & " where mt.voucher_no = " & txtCommonTextBox(tcImportVoucherNo).Text
			//mySql = mySql & " and SM_Location.locat_no = " & txtCommonTextBox(tcImportLocationCode).Text
			//mySql = mySql & " and mt.voucher_type =" & mParentVoucherType
			//
			//mTempValue = GetMasterCode(mySql)
			//If IsNull(mTempValue) Then
			//    MsgBox "Enter valid Import Voucher Information", vbInformation, "Error"
			//    GoTo StationExitFunction
			//Else
			//    mParentVoucherEntryId = mTempValue(0)
			//End If
			//
			//'if the time stamp does not match the previous one then rollback
			//If tsFormat(CStr(mTempValue(1))) <> tsFormat(mParentVoucherTimeStamp) Then
			//    MsgBox msg10, vbInformation
			//
			//    GoTo StationExitFunction
			//End If
			//'''''****************************************************************************
			//
			//
			//gConn.BeginTrans
			//
			//If CurrentFormMode = frmAddMode Then
			//
			//'''''****************************************************************************
			//    'I '''''''''''''N'''''''''''''S'''''''''''''E'''''''''''''R'''''''''''T
			//'''''****************************************************************************
			//
			//    txtCommonTextBox(tcVoucherNo).Text = GetNewNumber("ics_voucher_expenses", "voucher_no")
			//
			//
			//    '''''***************Insert into the master table*****************************
			//    mNewEntryID = InsertMasterRecord(mParentVoucherType, mParentVoucherEntryId)
			//    '''''************************************************************************
			//
			//    '''''***************Expenses and Charges Details ********************************
			//    If SaveVoucherExpenses(mNewEntryID) = False Then
			//        GoTo StationRollBackTrans
			//    End If
			//    '''''************************************************************************
			//
			//    Call UpdateParentTableExpenses(mParentVoucherEntryId, mParentMasterTableName, mParentDetailsTableName)
			//Else
			//
			//
			//'''''****************************************************************************
			//    'U '''''''''''''P'''''''''''''D'''''''''''''A'''''''''''''T'''''''''''E
			//'''''****************************************************************************
			//
			//    '''''*********************Make the mNewEntryID = Searchvalue so that the same
			//    ''''Variable can be user for both add and edit mode
			//    mNewEntryID = SearchValue
			//    '''''*************************************************************************
			//
			//
			//    '''''*********************Check the Master table TimeStamp *******************
			//    mySql = " select time_stamp from ics_voucher_expenses "
			//    mySql = mySql & " where entry_id=" & Str(mNewEntryID)
			//    mTempValue = GetMasterCode(mySql)
			//    'if the time stamp does not match the previous one then rollback
			//    If tsFormat(CStr(mTempValue)) <> mTimeStamp Then
			//        MsgBox msg10, vbInformation
			//        GoTo StationRollBackTrans
			//    End If
			//    '''''*************************************************************************
			//
			//    '''''************************update the sales table****************************
			//    Call UpdateMasterTable(mNewEntryID)
			//    '''''*************************************************************************
			//
			//    mySql = " delete from ics_voucher_expenses_details "
			//    mySql = mySql & " where entry_id =" & mNewEntryID
			//    gConn.Execute mySql
			//
			//
			//    '''''***************Expenses and Charges Details ********************************
			//    If SaveVoucherExpenses(mNewEntryID) = False Then
			//        GoTo StationRollBackTrans
			//    End If
			//    '''''************************************************************************
			//
			//    Call UpdateParentTableExpenses(mParentVoucherEntryId, mParentMasterTableName, mParentDetailsTableName)
			//End If
			//
			//
			//If CheckDataConsistency(mNewEntryID, mParentVoucherEntryId) = False Then
			//    GoTo StationRollBackTrans
			//End If
			//
			//'''''*************************************************************************
			//'Approve (Change the status to 2)
			//If pApprove = True Then
			//    Call ApproveTransaction("ics_voucher_expenses", mNewEntryID)
			//    Call PostParentExpenses
			//End If
			//'''''*************************************************************************
			//
			//gConn.CommitTrans
			//
			//
			//
			//'''''*************************************************************************
			//'Display a messbox if the auto generate voucher no is true and it is in addmode
			//If CurrentFormMode = frmAddMode Then
			//    mySql = msg20 & txtCommonTextBox(tcVoucherNo).Text
			//    MsgBox mySql, vbOKOnly + vbInformation
			//End If
			//
			//
			//saveRecord = True
			//Exit Function
			//
			//
			//'''''*************************************************************************
			//StationExitFunction:
			//'This code is executed when there is error before begin trans
			//saveRecord = False
			//Exit Function
			//'''''*************************************************************************
			//
			//
			//'''''*************************************************************************
			//StationRollBackTrans:
			//'This code is executed when there is error after begin trans
			//saveRecord = False
			//gConn.RollbackTrans
			//Exit Function
			//'''''*************************************************************************
			//
			//
			//'''''*************************************************************************
			//'All other Errors.
			//eFoundError:
			//Dim mReturnErrorType As Integer
			//
			//mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, rsVoucherTypes("Master_table_Name"), "GetRecord", msg10)
			//gConn.RollbackTrans
			//If mReturnErrorType = 1 Then
			//    saveRecord = False
			//ElseIf mReturnErrorType = 2 Then
			//    Call AddRecord
			//    saveRecord = False
			//ElseIf mReturnErrorType = 3 Then
			//    Call AddRecord
			//    saveRecord = False
			//Else
			//    saveRecord = False
			//End If
			return false;
		}

		private int InsertMasterRecord(int pParentVoucherType, int pParentVoucherEntryId)
		{

			string mysql = " insert into ics_voucher_expenses ";
			mysql = mysql + " (linked_voucher_type, linked_entry_id, voucher_date, voucher_no ";
			mysql = mysql + " , reference_no, comments, user_cd) ";
			mysql = mysql + " values(";
			mysql = mysql + pParentVoucherType.ToString();
			mysql = mysql + " ," + pParentVoucherEntryId.ToString();
			mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
			mysql = mysql + " ," + txtCommonTextBox[SystemICSConstants.tcVoucherNo].Text;
			mysql = mysql + " ,'" + txtCommonTextBox[SystemICSConstants.tcReferenceNo].Text + "'";
			mysql = mysql + " ,'" + txtCommonTextBox[SystemICSConstants.tcComments].Text + "'";
			mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
			mysql = mysql + " )";

			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			return ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));

		}

		private bool SaveVoucherExpenses(int pEntryId)
		{

			//Inserting into additional purchase Expenses details table
			bool result = false;
			double drAmt = 0;
			double crAmt = 0;
			double drExchRate = 0;
			double crExchRate = 0;

			object mReturnValue = null;
			int mDrLdgrCd = 0;
			int mCrLdgrCd = 0;
			int mDrCostCd = 0;
			int mCrCostCd = 0;

			string mysql = "";
			int Cnt = 0;

			try
			{

				int tempForEndVar = aExpensesDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{

					mysql = " select ldgr_cd,curr_cd from gl_ledger where ldgr_no='" + Convert.ToString(aExpensesDetails.GetValue(Cnt, cDrLdgrCode)) + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Ledger Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						result = false;
						grdExpensesDetails.Bookmark = Cnt;
						grdExpensesDetails.Focus();
						return result;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mDrLdgrCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
						if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1)) == SystemGLConstants.gDefaultCurrencyCd)
						{
							drExchRate = 1;
							drAmt = Convert.ToDouble(aExpensesDetails.GetValue(Cnt, cDrLCAmt));
						}
						else
						{
							drExchRate = Convert.ToDouble(aExpensesDetails.GetValue(Cnt, cDrRate));
							drAmt = Convert.ToDouble(aExpensesDetails.GetValue(Cnt, cDrFCAmt));
						}
					}

					mysql = "select ldgr_cd,curr_cd from gl_ledger where ldgr_no='" + Convert.ToString(aExpensesDetails.GetValue(Cnt, cCrLdgrCode)) + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Ledger Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						return false;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCrLdgrCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
						if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1)) == SystemGLConstants.gDefaultCurrencyCd)
						{
							crExchRate = 1;
							crAmt = Convert.ToDouble(aExpensesDetails.GetValue(Cnt, cCrLCAmt));
						}
						else
						{
							crExchRate = Convert.ToDouble(aExpensesDetails.GetValue(Cnt, cCrRate));
							crAmt = Convert.ToDouble(aExpensesDetails.GetValue(Cnt, cCrFCAmt));
						}
					}

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdExpensesDetails.Splits[0].DisplayColumns[cDrCostCode].Visible)
					{
						mysql = "select cost_cd from gl_cost_centers where cost_no=" + Convert.ToString(aExpensesDetails.GetValue(Cnt, cDrCostCode));
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue))
						{
							MessageBox.Show("Invalid Debit Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							return false;
						}
						else
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mDrCostCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
						}
					}
					else
					{
						mDrCostCd = 1;
					}

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdExpensesDetails.Splits[0].DisplayColumns[cCrCostCode].Visible)
					{
						mysql = "select cost_cd from gl_cost_centers where cost_no=" + Convert.ToString(aExpensesDetails.GetValue(Cnt, cCrCostCode));
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue))
						{
							MessageBox.Show("Invalid Credit Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							return false;
						}
						else
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mCrCostCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
						}
					}
					else
					{
						mCrCostCd = 1;
					}

					//transaction is assumed in default currency
					//can be changed later on since the calculation will be based on local currency fields
					mysql = " INSERT INTO ics_voucher_expenses_details(Entry_Id, Reference_No ";
					mysql = mysql + " , Debit_Ldgr_Cd, dr_cost_cd, Dr_Exchange_Rate, FC_Dr_Amt ";
					mysql = mysql + " , Credit_Ldgr_Cd, cr_cost_cd ";
					mysql = mysql + " , Cr_Exchange_Rate, FC_Cr_Amt,is_cash, voucher_date, comments)";
					mysql = mysql + " VALUES( ";
					mysql = mysql + Conversion.Str(pEntryId);
					mysql = mysql + ",'" + txtCommonTextBox[SystemICSConstants.tcReferenceNo].Text + "'";
					mysql = mysql + "," + mDrLdgrCd.ToString();
					mysql = mysql + "," + mDrCostCd.ToString();
					mysql = mysql + "," + Conversion.Str(drExchRate);
					mysql = mysql + "," + Conversion.Str(drAmt);
					mysql = mysql + "," + mCrLdgrCd.ToString();
					mysql = mysql + "," + mCrCostCd.ToString();
					mysql = mysql + "," + Conversion.Str(crExchRate);
					mysql = mysql + "," + Conversion.Str(crAmt);
					if (Convert.ToString(aExpensesDetails.GetValue(Cnt, cTransactionType)).Trim() == "Cash")
					{
						mysql = mysql + ",1";
					}
					else
					{
						mysql = mysql + ",0";
					}
					mysql = mysql + ", '" + StringsHelper.Format(aExpensesDetails.GetValue(Cnt, cTransactionDate), SystemVariables.gSystemDateFormat) + "'";
					mysql = mysql + ",'" + Convert.ToString(aExpensesDetails.GetValue(Cnt, cComments)) + "'";
					mysql = mysql + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

				}

				return true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
			}
			return result;
		}


		public void AddRecord()
		{
			try
			{

				int Cnt = 0;
				int mExpensesVoucherType = 0;
				string mExpensesVoucherTypeName = "";


				//''''*************************************************************************
				//Set the form caption
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, "Expenses and Charges", "Transaction");
				//''''*************************************************************************


				//''''*************************************************************************
				//'''Grid settings
				int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					grdVoucherDetails.Columns[Cnt].FooterText = "";
				}


				SystemGrid.DefineVoucherArray(aVoucherDetails, SystemICSConstants.grdArrayUbound, 0, true);
				SystemGrid.DefineVoucherArray(aExpensesDetails, mMaxExpensesArray, 0, true);

				grdVoucherDetails.Rebind(true);
				grdExpensesDetails.Rebind(true);

				mExpensesVoucherType = Convert.ToInt32(Double.Parse(txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text));
				mExpensesVoucherTypeName = txtDisplayLabel[0].Text;
				SystemProcedure2.ClearTextBox(this);
				SystemProcedure2.ClearNumberBox(this);

				SearchValue = ""; //Change the msearchvalue to blank
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive; //set new voucher status to active by default

				txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text = mExpensesVoucherType.ToString();
				txtDisplayLabel[0].Text = mExpensesVoucherTypeName;
				txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Enabled = true;
				txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Enabled = true;

				SetDefaultValues();

				if (FirstFocusObject.Enabled)
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

		private void UpdateParentTableExpenses(int pParentEntryID, string pParentMasterTableName, string pParentDetailsTableName)
		{
			StringBuilder mysql = new StringBuilder();
			int Cnt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				mysql = new StringBuilder(" update " + pParentDetailsTableName);
				mysql.Append(" set prod_exp_amt =" + StringsHelper.Format(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdExpensesColumn), "##############0.0##"));
				mysql.Append(" where line_no=" + Convert.ToString(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdParentLineNo)));
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql.ToString();
				TempCommand.ExecuteNonQuery();
			}

			mysql = new StringBuilder(" update " + pParentMasterTableName);
			mysql.Append(" set expenses_amt =" + StringsHelper.Format(grdVoucherDetails.Columns[SystemICSConstants.grdExpensesColumn].FooterText, "###########0.0##"));
			mysql.Append(" where entry_id =" + pParentEntryID.ToString());
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql.ToString();
			TempCommand_2.ExecuteNonQuery();
		}

		public void findRecord()
		{

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(4000108));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				Application.DoEvents();
				GetRecord(mSearchValue);
			}
		}

		private void AssignGridLineNumbers()
		{
			//''''*************************************************************************
			//'''Assign the Grid Line No
			//''''*************************************************************************

			int Cnt = 0;
			int tempForEndVar = aExpensesDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				aExpensesDetails.SetValue(Cnt + 1, Cnt, cLN);
			}
		}

		private void GetVoucherExpensesDetails(int pEntryId)
		{
			SqlDataReader localRec = null;
			int Cnt = 0;

			if (SystemProcedure2.IsItEmpty(Convert.ToString(grdExpensesDetails.Tag), SystemVariables.DataType.StringType))
			{
				grdExpensesDetails_GotFocus(grdExpensesDetails, new EventArgs());
			}

			string mysql = "SELECT L1.Ldgr_No as drLdgrNo, L1.curr_cd as drCurrCd, C1.symbol drSymbol ";
			mysql = mysql + " , L2.Ldgr_No crLdgrNo, L2.curr_cd as crCurrCd, C2.symbol crSymbol ";
			mysql = mysql + " , gdcc.cost_no drccno, gccc.cost_no crccno ";
			mysql = mysql + " , ped.* ";
			mysql = mysql + " FROM ics_voucher_expenses_Details ped";
			mysql = mysql + " INNER JOIN gl_ledger L1 ON ped.Debit_Ldgr_Cd = L1.Ldgr_Cd ";
			mysql = mysql + " INNER JOIN gl_currency C1 ON L1.curr_cd = c1.curr_cd ";
			mysql = mysql + " INNER JOIN gl_cost_centers gdcc ON ped.dr_cost_cd = gdcc.cost_cd ";
			mysql = mysql + " INNER JOIN gl_ledger L2 ON ped.Credit_Ldgr_Cd = L2.Ldgr_Cd ";
			mysql = mysql + " INNER JOIN gl_currency C2 ON L2.curr_cd = c2.curr_cd ";
			mysql = mysql + " INNER JOIN gl_cost_centers gccc ON ped.cr_cost_cd = gccc.cost_cd ";
			mysql = mysql + " Where entry_id=" + Conversion.Str(pEntryId);
			mysql = mysql + " order by line_no ";

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand.ExecuteReader();
			localRec.Read();

			do 
			{
				aExpensesDetails.RedimXArray(new int[]{Cnt, mMaxExpensesArray}, new int[]{0, 0});

				aExpensesDetails.SetValue(Cnt + 1, Cnt, cLN);

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(localRec["is_cash"])) == TriState.True)
				{
					aExpensesDetails.SetValue(mCashTransCaption, Cnt, cTransactionType);
				}
				else
				{
					aExpensesDetails.SetValue(mCreditTransCaption, Cnt, cTransactionType);
				}

				aExpensesDetails.SetValue(localRec["drldgrno"], Cnt, cDrLdgrCode);
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (grdExpensesDetails.Splits[0].DisplayColumns[cDrCostCode].Visible)
				{
					aExpensesDetails.SetValue(localRec["drccno"], Cnt, cDrCostCode);
				}
				aExpensesDetails.SetValue(localRec["drsymbol"], Cnt, cDrCurr);
				if (Convert.ToDouble(localRec["drCurrCd"]) == SystemGLConstants.gDefaultCurrencyCd)
				{
					aExpensesDetails.SetValue(localRec["lc_dr_amt"], Cnt, cDrLCAmt);
				}
				else
				{
					aExpensesDetails.SetValue(localRec["dr_exchange_rate"], Cnt, cDrRate);
					aExpensesDetails.SetValue(localRec["fc_dr_amt"], Cnt, cDrFCAmt);
					aExpensesDetails.SetValue(Convert.ToDouble(localRec["dr_exchange_rate"]) * Convert.ToDouble(localRec["fc_dr_amt"]), Cnt, cDrLCAmt);
				}

				aExpensesDetails.SetValue(localRec["crldgrno"], Cnt, cCrLdgrCode);
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (grdExpensesDetails.Splits[0].DisplayColumns[cCrCostCode].Visible)
				{
					aExpensesDetails.SetValue(localRec["crccno"], Cnt, cCrCostCode);
				}

				aExpensesDetails.SetValue(localRec["crsymbol"], Cnt, cCrCurr);
				if (Convert.ToDouble(localRec["crCurrCd"]) == SystemGLConstants.gDefaultCurrencyCd)
				{
					aExpensesDetails.SetValue(localRec["lc_cr_amt"], Cnt, cCrLCAmt);
				}
				else
				{
					aExpensesDetails.SetValue(localRec["cr_exchange_rate"], Cnt, cCrRate);
					aExpensesDetails.SetValue(localRec["fc_cr_amt"], Cnt, cCrFCAmt);
					aExpensesDetails.SetValue(Convert.ToDouble(localRec["cr_exchange_rate"]) * Convert.ToDouble(localRec["fc_cr_amt"]), Cnt, cCrLCAmt);
				}
				aExpensesDetails.SetValue(localRec["voucher_date"], Cnt, cTransactionDate);
				aExpensesDetails.SetValue(Convert.ToString(localRec["comments"]) + "", Cnt, cComments);

				Cnt++;
			}
			while(localRec.Read());
			localRec.Close();
			grdExpensesDetails.Rebind(true);

			CalculateTotals(0, 0);
		}

		private void GetParentVoucherDetails(int pLinkedVoucherType, int pLinkedEntryId)
		{
			int Cnt = 0;

			string mParentMasterTableName = "";
			string mParentDetailsTableName = "";

			string mLedgerCurrencyCaption = "";



			//Get the master and details table from the voucher type entered
			string mysql = "select master_table_name , details_table_name, module_id, add_or_less ";
			mysql = mysql + " from ICS_Transaction_Types ";
			mysql = mysql + " where voucher_type= " + pLinkedVoucherType.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempValue))
			{
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mParentMasterTableName = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mParentDetailsTableName = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
			}


			mysql = " select ldgr_no ";
			mysql = mysql + " ," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name") + " as ldgr_name ";
			mysql = mysql + " , mt.voucher_no, mt.time_stamp ";
			mysql = mysql + " , mt.exchange_rate ";
			mysql = mysql + " , gl_currency.symbol as curr_symbol ";
			mysql = mysql + " , dt.Entry_Id, dt.Line_No, dt.Prod_Cd, dt.Unit_Entry_Id ";
			mysql = mysql + " , dt.Project_cd, dt.Exchange_Rate, dt.Prod_Name, dt.Reference_No ";
			mysql = mysql + " , dt.Qty, dt.Base_Qty, dt.Processed_Qty , dt.Balance_Qty";
			mysql = mysql + " , ICS_Item.serialized  , ICS_Item.item_type_cd ";
			mysql = mysql + " , (aud.alt_qty * dt.Balance_Qty) / aud.base_qty as Alt_Unit_balance_qty ";
			mysql = mysql + " , dt.FC_Rate, dt.FC_Prod_Dis, dt.FC_Amount, dt.Prod_Exp_Amt ";
			mysql = mysql + " , dt.Dis_In_Percent, dt.promo_type, dt.Status , ICS_Item.part_no ";
			mysql = mysql + " , ICS_Unit.symbol ";
			mysql = mysql + " , locat_no as locat_no ";
			mysql = mysql + " from " + mParentDetailsTableName + " dt ";
			mysql = mysql + " inner join ICS_Item on dt.prod_cd = ICS_Item.prod_cd ";
			mysql = mysql + " inner join ICS_Item_Types it on it.item_type_cd = ICS_Item.item_type_cd ";
			mysql = mysql + " inner join " + mParentMasterTableName + " mt on mt.entry_id = dt.entry_id  ";
			mysql = mysql + " inner join ICS_Item_Unit_Details aud on dt.unit_entry_id = aud.unit_entry_id ";
			mysql = mysql + " inner join ICS_Unit on ICS_Unit.unit_cd = aud.alt_unit_cd ";
			mysql = mysql + " inner join SM_Location on mt.locat_cd = SM_Location.locat_cd ";
			mysql = mysql + " left join gl_ledger on mt.ldgr_cd = gl_ledger.ldgr_cd  ";
			mysql = mysql + " inner join gl_currency on gl_ledger.curr_cd = gl_currency.curr_cd  ";
			mysql = mysql + " where mt.entry_id = " + pLinkedEntryId.ToString();
			mysql = mysql + " and it.affect_stock = 1 ";
			mysql = mysql + " order by dt.line_no ";

			SqlDataReader rsLocalRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			if (rsLocalRec.Read())
			{
				SystemGrid.DefineVoucherArray(aVoucherDetails, SystemICSConstants.grdArrayUbound, 0, true);

				txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text = pLinkedVoucherType.ToString();
				txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text = Convert.ToString(rsLocalRec["locat_no"]);

				txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Enabled = false;
				txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Enabled = false;

				//'This is done because the lost focus of import voucher no was giving error.
				txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Text = "";
				txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Enabled = false;
				Application.DoEvents();
				txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Text = Convert.ToString(rsLocalRec["voucher_no"]);

				txtCommonTextBox[SystemICSConstants.tcLedgerCode].Text = Convert.ToString(rsLocalRec["ldgr_no"]);
				txtDisplayLabel[SystemICSConstants.dcLedgerName].Text = Convert.ToString(rsLocalRec["ldgr_name"]);

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("is_bilingual"))) == TriState.True)
				{
					mLedgerCurrencyCaption = SystemProcedure2.GetSystemLabel(877);
				}
				else
				{
					mLedgerCurrencyCaption = "Currency :";
				}

				lblCommonLabel[SystemICSConstants.lcLedgerDetailsCurrency].Caption = mLedgerCurrencyCaption + Convert.ToString(rsLocalRec["curr_symbol"]);

				mParentVoucherTimeStamp = Convert.ToString(rsLocalRec["time_stamp"]);

				txtExchangeRate.Value = rsLocalRec["exchange_rate"];

				do 
				{
					SystemGrid.DefineVoucherArray(aVoucherDetails, SystemICSConstants.grdArrayUbound, Cnt, false);

					//Get the details information into the grid
					aVoucherDetails.SetValue(Cnt + 1, Cnt, SystemICSConstants.grdLineNoColumn);
					aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["part_no"]).Trim(), Cnt, SystemICSConstants.grdProductCodeColumn);
					aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["prod_name"]).Trim(), Cnt, SystemICSConstants.grdProductNameColumn);
					aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["symbol"]).Trim(), Cnt, SystemICSConstants.grdUnitSymbolColumn);
					aVoucherDetails.SetValue(rsLocalRec["serialized"], Cnt, SystemICSConstants.grdSerialisedColumn);
					aVoucherDetails.SetValue(rsLocalRec["item_type_cd"], Cnt, SystemICSConstants.grdItemTypeColumn);
					aVoucherDetails.SetValue(0, Cnt, SystemICSConstants.grdRemainingQtyColumn);
					aVoucherDetails.SetValue(rsLocalRec["qty"], Cnt, SystemICSConstants.grdQtyColumn);
					aVoucherDetails.SetValue(rsLocalRec["fc_rate"], Cnt, SystemICSConstants.grdRateColumn);
					aVoucherDetails.SetValue(rsLocalRec["fc_prod_dis"], Cnt, SystemICSConstants.grdDiscountAmountColumn);
					aVoucherDetails.SetValue(rsLocalRec["fc_amount"], Cnt, SystemICSConstants.grdProductAmountColumn);
					aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["prod_exp_amt"]).Trim() + "", Cnt, SystemICSConstants.grdExpensesColumn);
					aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["reference_no"]).Trim() + "", Cnt, SystemICSConstants.grdRemarksColumn);
					aVoucherDetails.SetValue(rsLocalRec["line_no"], Cnt, SystemICSConstants.grdParentLineNo);

					Cnt++;
				}
				while(rsLocalRec.Read());
			}


			CalculateTotals1(0, 0);
			grdVoucherDetails.Rebind(true);

			rsLocalRec.Close();


			return;

		}

		private void UpdateMasterTable(int pEntryId)
		{

			string mysql = " update ics_voucher_expenses ";
			mysql = mysql + " set voucher_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
			mysql = mysql + " , reference_no ='" + txtCommonTextBox[SystemICSConstants.tcReferenceNo].Text + "'";
			mysql = mysql + " , comments ='" + txtCommonTextBox[SystemICSConstants.tcComments].Text + "'";
			mysql = mysql + " , user_cd =" + SystemVariables.gLoggedInUserCode.ToString();
			mysql = mysql + " where entry_id =" + pEntryId.ToString();
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();
		}

		public object deleteRecord()
		{
			//'Delete the Record
			//
			//Dim mySql As String
			//
			//On Error GoTo eFoundError
			//
			//If mOldVoucherStatus <> stActive Then
			//    Call VoucherStatusErrorMessage(mOldVoucherStatus, 1)
			//    deleteRecord = False
			//    If FirstFocusObject.Enabled = True Then
			//        FirstFocusObject.SetFocus
			//    End If
			//    Exit Function
			//End If
			//
			//
			//gConn.BeginTrans
			//If CurrentFormMode = frmEditMode Then
			//
			//    '''''*************************************************************************
			//    ''''During Delete of the voucher, update the detail table status to 0
			//    ''''This will deduct the quantity and help to check the negative stock
			//    ''''after the details portion is inserted
			//    '''''*************************************************************************
			//    mySql = " update ICS_Transaction "
			//    mySql = mySql & " set expenses_amt = 0 "
			//    mySql = mySql & " from ICS_Transaction it "
			//    mySql = mySql & " inner join ics_voucher_expenses ive on it.entry_id = ive.linked_entry_id "
			//    mySql = mySql & " where ive.entry_id = " & SearchValue
			//    gConn.Execute mySql
			//
			//    mySql = " update ICS_Transaction_Details "
			//    mySql = mySql & " set prod_exp_amt = 0 "
			//    mySql = mySql & " from ICS_Transaction_Details itd "
			//    mySql = mySql & " inner join ics_voucher_expenses ive on itd.entry_id = ive.linked_entry_id "
			//    mySql = mySql & " where ive.entry_id = " & SearchValue
			//    gConn.Execute mySql
			//    '''''*************************************************************************
			//
			//
			//    mySql = " delete from ics_voucher_expenses_details "
			//    mySql = mySql & " where entry_id = " & SearchValue
			//    gConn.Execute mySql
			//
			//    mySql = " delete from ics_voucher_expenses "
			//    mySql = mySql & " where entry_id = " & SearchValue
			//    gConn.Execute mySql
			//
			//
			//End If
			//'''''*************************************************************************
			//
			//gConn.CommitTrans
			//
			//
			//deleteRecord = True
			//Exit Function
			//
			//eFoundError:
			//On Error Resume Next
			//gConn.RollbackTrans
			//
			//Dim mReturnErrorType As Integer
			//mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, rsVoucherTypes("Master_table_Name"), "Deleterecord", msg10)
			//If mReturnErrorType = 1 Then
			//    deleteRecord = False
			//ElseIf mReturnErrorType = 2 Then
			//    deleteRecord = False
			//Else
			//    deleteRecord = False
			//End If
			return null;
		}

		public bool Post()
		{
			//Dim frmTemp As frmSysOnlinePosting
			//Dim mySql As String
			//Set frmTemp = New frmSysOnlinePosting
			//
			//If mOldVoucherStatus <> stActive Then
			//    Call VoucherStatusErrorMessage(mOldVoucherStatus, 2)
			//    Post = False
			//    If FirstFocusObject.Enabled = True Then
			//        FirstFocusObject.SetFocus
			//    End If
			//    Exit Function
			//End If
			//
			//
			//frmTemp.Show 1
			//
			//'if the user clicks on OK button in the frmPost form
			//If frmTemp.mApprove = True Then
			//    Dim ans As Integer
			//
			//    If CurrentFormMode = frmAddMode Then
			//        'Display this message if status is active, which will require to save the record first
			//        ans = MsgBox(msg19 & Chr(13) & Chr(13) & msg7, vbYesNo + vbInformation)
			//    Else
			//        'Display this message if status is not active, which will not require to save the record first
			//        ans = MsgBox("                         Do you want to Post the Record ?                          " & Chr(13) & Chr(13) & Chr(13) & " NOTE :            Yes : To post after saving. " & Chr(13) & "                         No : To post without saving " & Chr(13) & "                         Cancel : To exit without posting ", vbYesNoCancel + vbInformation)
			//    End If
			//
			//
			//    If CurrentFormMode = frmAddMode Then
			//        If ans = vbYes Then
			//            GoTo mend
			//        End If
			//    Else
			//        If ans = vbYes Then
			//            GoTo mend
			//        ElseIf ans = vbNo Then
			//            gConn.BeginTrans
			//
			//            Call ApproveTransaction("ics_voucher_expenses", CLng(SearchValue))
			//            Call PostParentExpenses
			//            gConn.CommitTrans
			//        End If
			//
			//        Post = True
			//        GoTo mDestroy
			//    End If
			//End If
			//
			//Post = False
			//GoTo mDestroy
			//
			//mend:
			//'This goto will only come if the voucherstatus is still active
			//If CheckDataValidity = True Then
			//    If saveRecord(frmTemp.mApprove) = True Then
			//        Post = True
			//        GoTo mDestroy
			//    End If
			//End If
			//Post = False
			//
			//mDestroy:
			//Unload frmTemp
			//Set frmTemp = Nothing
			return false;
		}

		private void PostParentExpenses()
		{
			//Dim mEntryID As Long
			//Dim mTempValue As Variant
			//Dim mySql  As String
			//
			//mySql = "select entry_id "
			//mySql = mySql & " from ICS_Transaction mt "
			//mySql = mySql & " inner join SM_Location on mt.locat_cd = SM_Location.locat_cd "
			//mySql = mySql & " where mt.voucher_no = " & txtCommonTextBox(tcImportVoucherNo).Text
			//mySql = mySql & " and SM_Location.locat_no = " & Str(txtCommonTextBox(tcImportLocationCode).Text)
			//mySql = mySql & " and mt.voucher_type = " & txtCommonTextBox(tcImportVoucherType).Text
			//
			//mTempValue = GetMasterCode(mySql)
			//If Not IsNull(mTempValue) Then
			//    mEntryID = mTempValue
			//End If
			//
			//'''Changed by Moiz Hakimion 14-may-2004
			//'''this is done as to completely post the receipt or purchase voucher
			//'''after the expenses are posted.
			//'Call PostTransactionToGLExpenses("ICS_Transaction", mEntryID)
			//Call PostTransactionToGL("ICS_Transaction", mEntryID)
			//
		}

		private void SetDefaultValues()
		{
			object mTempValue = null;
			//'''Check if the user is logged in particular location
			string mysql = "";
			if (SystemVariables.gLoggedInSingleLocation)
			{
				//**--assign the upload from SM_Location code
				mysql = " select locat_no ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ",l_locat_name" : ",a_locat_name");
				mysql = mysql + " from SM_Location where locat_cd = " + SystemVariables.gLoggedInUserLocationCode.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempValue))
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
					txtCommonTextBox_Leave(txtCommonTextBox[SystemICSConstants.tcImportLocationCode], new EventArgs());
					txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Enabled = false;
				}
				else
				{
					txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text = "";
					txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Enabled = false;
				}
			}

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
			SystemReports.GetCrystalReport(100060202, 2, "5360", Conversion.Str(mEntryId), false);
		}

		private bool CheckDataConsistency(int pEntryId, int pParentEntryID)
		{
			decimal mLCDrAmt = 0;

			string mysql = " select (sum(lC_Dr_Amt) - sum(lC_Cr_Amt)), sum(lC_Dr_Amt) ";
			mysql = mysql + " from ics_voucher_expenses_details ";
			mysql = mysql + " where entry_id = " + pEntryId.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			if (Math.Abs(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)))) > 0.009d)
			{
				MessageBox.Show(" Sum of Debit and Credit does not match, transaction failed. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mLCDrAmt = ReflectionHelper.GetPrimitiveValue<decimal>(((Array) mReturnValue).GetValue(1));
			}

			mysql = " select sum(prod_exp_amt) ";
			mysql = mysql + " from ICS_Transaction_Details ";
			mysql = mysql + " where entry_id =" + pParentEntryID.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			decimal mProdExpAmt = ReflectionHelper.GetPrimitiveValue<decimal>(mReturnValue);

			//If mLCDrAmt <> mProdExpAmt Then
			if (Math.Abs((double) (mLCDrAmt - mProdExpAmt)) > 0.009d)
			{
				MessageBox.Show(" Allocate ICS_Item expenses amount properly, transaction failed. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			return true;

		}
	}
}