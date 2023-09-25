
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmICSProductAssemblyDetails
		: System.Windows.Forms.Form
	{

		public frmICSProductAssemblyDetails()
{
InitializeComponent();
} 
 public  void frmICSProductAssemblyDetails_old()
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


		private void frmICSProductAssemblyDetails_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		public bool mOkClicked = false;
		public decimal mAssemblyProductPrice = 0;

		private XArrayHelper aVoucherDetails = null;
		//Private mMaxArrayCols As Integer
		private int mLineNo = 0;
		private double mVoucherQty = 0;
		private int mProductCode = 0;
		private int mLocatCode = 0;
		private int mVoucherType = 0;
		private bool mSerialNoRequired = false;

		private DataSet rsParentAssemblyDetails = null;
		private DataSet rsParentAssemblySerialNo = null;
		private DataSet rsProductCodeList = null;

		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private string mTimeStamp = "";
		private bool mLinkedVoucher = false;

		private const int gccLineNoColumn = 0;
		private const int gccProductCodeColumn = 1;
		private const int gccPartNoColumn = 2;
		private const int gccProductNameColumn = 3;
		private const int gccUnitEntryIdColumn = 4;
		private const int gccSymbolColumn = 5;
		private const int gccMinQtyColumn = 6;
		private const int gccMaxQtyColumn = 7;
		private const int gccOriginalQtyColumn = 8;
		private const int gccQtyColumn = 9;
		private const int gccTotalQtyColumn = 10;
		private const int gccOriginalSalesRateColumn = 11;
		private const int gccSalesRateColumn = 12;
		private const int gccTotalAmountColumn = 13;
		private const int gccAdjustMaxRateColumn = 14;
		private const int gccAdjustMinRateColumn = 15;
		private const int gccSerialisedColumn = 16;
		private const int gccSerialNoColumn = 17;
		private const int gccRemarksColumn = 18;

		private const int mMaxArrayCols = 18;

		public int LineNo
		{
			set
			{
				mLineNo = value;
			}
		}


		public double TotalQty
		{
			set
			{
				mVoucherQty = value;
			}
		}


		public int ProductCode
		{
			set
			{
				mProductCode = value;
			}
		}


		public int LocatCode
		{
			set
			{
				mLocatCode = value;
			}
		}


		public int VoucherType
		{
			set
			{
				mVoucherType = value;
			}
		}


		public DataSet SetVoucherSourceRecordSet
		{
			set
			{
				rsParentAssemblyDetails = value;
			}
		}


		public DataSet SetAssemblySerialNoRecordSet
		{
			set
			{
				rsParentAssemblySerialNo = value;
			}
		}


		public DataSet SetVoucherProductRecordSet
		{
			set
			{
				rsProductCodeList = value;
			}
		}


		public bool SerialNoRequired
		{
			set
			{
				mSerialNoRequired = value;
			}
		}


		public SystemVariables.SystemFormModes FormMode
		{
			set
			{
				mCurrentFormMode = value;
			}
		}


		public bool LinkedVoucher
		{
			set
			{
				mLinkedVoucher = value;
			}
		}



		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			CloseForm();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			grdVoucherDetails.UpdateData();

			int cnt = 0;
			int cnt1 = 0;
			string myString = "";


			//''Delete the existing lines
			if (rsParentAssemblyDetails.Tables[0].Rows.Count > 0)
			{
				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsParentAssemblyDetails.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.MoveFirst();
				rsParentAssemblyDetails.Tables[0].DefaultView.RowFilter = "lineno=" + mLineNo.ToString();
				foreach (DataRow iteration_row in rsParentAssemblyDetails.Tables[0].Rows)
				{
					//UPGRADE_ISSUE: (2070) Constant adAffectCurrent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsParentAssemblyDetails.Delete was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsParentAssemblyDetails.Delete(UpgradeStubs.ADODB_AffectEnum.getadAffectCurrent());
				}
				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
			}


			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsParentAssemblyDetails.AddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.AddNew(null, null);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["GridLineNo"].setValue(cnt + 1);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["LineNo"].setValue(mLineNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["prodcd"].setValue(aVoucherDetails.GetValue(cnt, gccProductCodeColumn));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["partno"].setValue(aVoucherDetails.GetValue(cnt, gccPartNoColumn));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["productname"].setValue(aVoucherDetails.GetValue(cnt, gccProductNameColumn));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["symbol"].setValue(aVoucherDetails.GetValue(cnt, gccSymbolColumn));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["unitentryid"].setValue(aVoucherDetails.GetValue(cnt, gccUnitEntryIdColumn));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["minqty"].setValue(aVoucherDetails.GetValue(cnt, gccMinQtyColumn));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["maxqty"].setValue(aVoucherDetails.GetValue(cnt, gccMaxQtyColumn));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["originalqty"].setValue(aVoucherDetails.GetValue(cnt, gccOriginalQtyColumn));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["qty"].setValue(aVoucherDetails.GetValue(cnt, gccQtyColumn));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["totalqty"].setValue(aVoucherDetails.GetValue(cnt, gccTotalQtyColumn));

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["originalsalesrate"].setValue(aVoucherDetails.GetValue(cnt, gccOriginalSalesRateColumn));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["salesrate"].setValue(aVoucherDetails.GetValue(cnt, gccSalesRateColumn));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["totalamt"].setValue(aVoucherDetails.GetValue(cnt, gccTotalAmountColumn));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["adjustmaxrate"].setValue(aVoucherDetails.GetValue(cnt, gccAdjustMaxRateColumn));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["adjustminrate"].setValue(aVoucherDetails.GetValue(cnt, gccAdjustMinRateColumn));

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["serialised"].setValue(aVoucherDetails.GetValue(cnt, gccSerialisedColumn));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentAssemblyDetails.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].Rows[0]["remarks"].setValue(aVoucherDetails.GetValue(cnt, gccRemarksColumn));

				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsParentAssemblyDetails.Update was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Update_Renamed(null, null);
			}

			mOkClicked = true;
			mAssemblyProductPrice = (decimal) Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[gccTotalAmountColumn].FooterText, "#########0.0##"));

			this.Hide();
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
						if (grdVoucherDetails.Col == gccQtyColumn)
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

				//If KeyCode = 27 Then    'If enter key pressed send a tab key
				//    Unload Me
				//    Exit Sub
				//End If

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
			int cnt = 0;
			SqlDataReader rsTempRec = null;
			bool mFound = false;
			string mySql = "";

			mOkClicked = false;

			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2.2f, 1.4f, "&H8CD2F0", "&H8CD2F0");

			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Prod Code", 0, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Part No.", 1500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Part_No_In_Details"]));
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Product Name", 2000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Name_In_Details"]));
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Unit Entry Id", 0, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Unit", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Min. Qty", 800, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("minimum_and_maximum_qty_restriction_in_assembly")), false, false, true, false, 12);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Max. Qty", 800, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("minimum_and_maximum_qty_restriction_in_assembly")), false, false, true, false, 12);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "OriginalQty", 200, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false);

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Allow_Change_Assembly_Components_Qty_In_Voucher")) && !mLinkedVoucher)
			{
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Qty", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
			}
			else
			{
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Qty", 800, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
			}
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Total Qty", 800, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far);

			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Original Sale Rate", 800, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Sale Rate", 800, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_component_sales_price_in_product")) & ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("adjust_sales_rates_of_assembly_group_components"))) != 0, false, false, true, true, 12);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Total Amt.", 800, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_component_sales_price_in_product")) & ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("adjust_sales_rates_of_assembly_group_components"))) != 0, false, false, true, true, 12);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Adjust Max Rate", 800, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Show_Component_Max_Rate_Adjustment_In_Product")) & ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("adjust_sales_rates_of_assembly_group_components"))) != 0, false, false, true, false, 12);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Adjust Min Rate", 800, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Show_Component_Min_Rate_Adjustment_In_Product")) & ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("adjust_sales_rates_of_assembly_group_components"))) != 0, false, false, true, false, 12);

			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Serialized", 0, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Serial No.", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("serialized_product")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_serial_in_details"]) & ((mSerialNoRequired) ? -1 : 0)) != 0, false, false, true, true, -1);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 50);

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			if ((ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("serialized_product")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_serial_in_details"])) != 0)
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar = grdVoucherDetails.Splits[0].DisplayColumns[gccSerialNoColumn];
				withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
				withVar.DataColumn.Caption = "";
				withVar.AllowFocus = true;
				withVar.ButtonAlways = true;
				withVar.ButtonText = true;
				withVar.Width = 27;
				withVar.Style.Font = withVar.Style.Font.Change(bold:true, size:11, name:"Verdana");
				withVar.Style.ForeColor = Color.FromArgb(21, 64, 77);
			}

			txtTotalQty.Text = StringsHelper.Format(mVoucherQty, "###,###,##0.0##");

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			withVar_2 = grdVoucherDetails.Splits[0].DisplayColumns[gccAdjustMaxRateColumn];
			withVar_2.DataColumn.ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
			withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_3 = null;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			withVar_3 = grdVoucherDetails.Splits[0].DisplayColumns[gccAdjustMinRateColumn];
			withVar_3.DataColumn.ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
			withVar_3.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

			aVoucherDetails = new XArrayHelper();

			SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, true);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);
			grdVoucherDetails.Rebind(true);

			if (rsParentAssemblyDetails.Tables[0].Rows.Count > 0)
			{
				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsParentAssemblyDetails.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentAssemblyDetails.MoveFirst();
				rsParentAssemblyDetails.Tables[0].DefaultView.RowFilter = "lineno=" + mLineNo.ToString();
				if (rsParentAssemblyDetails.Tables[0].Rows.Count != 0)
				{
					foreach (DataRow iteration_row in rsParentAssemblyDetails.Tables[0].Rows)
					{
						SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, cnt, false);
						aVoucherDetails.SetValue(iteration_row["prodcd"], cnt, gccProductCodeColumn);
						aVoucherDetails.SetValue(iteration_row["partno"], cnt, gccPartNoColumn);
						aVoucherDetails.SetValue(iteration_row["productname"], cnt, gccProductNameColumn);
						aVoucherDetails.SetValue(iteration_row["unitentryid"], cnt, gccUnitEntryIdColumn);
						aVoucherDetails.SetValue(iteration_row["symbol"], cnt, gccSymbolColumn);
						aVoucherDetails.SetValue(iteration_row["minqty"], cnt, gccMinQtyColumn);
						aVoucherDetails.SetValue(iteration_row["maxqty"], cnt, gccMaxQtyColumn);
						aVoucherDetails.SetValue(iteration_row["originalqty"], cnt, gccOriginalQtyColumn);
						aVoucherDetails.SetValue(iteration_row["qty"], cnt, gccQtyColumn);
						aVoucherDetails.SetValue(Convert.ToDouble(iteration_row["qty"]) * mVoucherQty, cnt, gccTotalQtyColumn);
						aVoucherDetails.SetValue(iteration_row["originalsalesrate"], cnt, gccOriginalSalesRateColumn);

						aVoucherDetails.SetValue(iteration_row["salesrate"], cnt, gccSalesRateColumn);

						aVoucherDetails.SetValue((Convert.ToDouble(iteration_row["qty"]) * mVoucherQty) * Convert.ToDouble(iteration_row["salesrate"]), cnt, gccTotalAmountColumn);
						aVoucherDetails.SetValue(iteration_row["adjustmaxrate"], cnt, gccAdjustMaxRateColumn);
						aVoucherDetails.SetValue(iteration_row["adjustminrate"], cnt, gccAdjustMinRateColumn);
						aVoucherDetails.SetValue(iteration_row["serialised"], cnt, gccSerialisedColumn);
						aVoucherDetails.SetValue(iteration_row["remarks"], cnt, gccRemarksColumn);

						cnt++;
					}
					mFound = true;
				}
				else
				{
					mFound = false;
				}
			}
			else
			{
				mFound = false;
			}


			if (!mFound)
			{
				mySql = " select part_no, ICS_Item.prod_cd , aud.unit_entry_id , ";
				mySql = mySql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_prod_name " : " a_prod_name ") + " as prod_name ";
				mySql = mySql + " , symbol as symbol ";
				mySql = mySql + " , pad.assembly_base_qty, pad.component_base_qty, pad.component_min_base_qty ";
				mySql = mySql + " , pad.component_max_base_qty, pad.component_ratio_in_percent_in_sales_rate ";
				mySql = mySql + " , pad.Component_Sales_Price , pad.Component_Max_Rate_Adjustment ";
				mySql = mySql + " , pad.Component_Min_Rate_Adjustment ";
				mySql = mySql + " , pad.comments , ICS_Item.serialized from ICS_Item_assembly_details pad ";
				mySql = mySql + " inner join ICS_Item on pad.component_prod_cd = ICS_Item.prod_cd ";
				mySql = mySql + " inner join ICS_Unit on ICS_Item.base_unit_cd = ICS_Unit.unit_cd ";
				mySql = mySql + " inner join ICS_Item_Unit_Details aud on ICS_Item.prod_cd = aud.prod_cd ";
				mySql = mySql + " and ICS_Item.base_unit_cd = aud.alt_unit_cd ";
				mySql = mySql + " where pad.assembly_prod_cd = " + mProductCode.ToString();
				mySql = mySql + " order by entry_id ";

				SqlCommand sqlCommand = new SqlCommand(mySql, SystemVariables.gConn);
				rsTempRec = sqlCommand.ExecuteReader();
				rsTempRec.Read();
				SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, 0, true);
				do 
				{
					SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, cnt, false);

					aVoucherDetails.SetValue(rsTempRec["prod_cd"], cnt, gccProductCodeColumn);
					aVoucherDetails.SetValue(rsTempRec["part_no"], cnt, gccPartNoColumn);
					aVoucherDetails.SetValue(rsTempRec["prod_name"], cnt, gccProductNameColumn);
					aVoucherDetails.SetValue(rsTempRec["symbol"], cnt, gccSymbolColumn);
					aVoucherDetails.SetValue(rsTempRec["unit_entry_id"], cnt, gccUnitEntryIdColumn);
					aVoucherDetails.SetValue(rsTempRec["component_min_base_qty"], cnt, gccMinQtyColumn);
					aVoucherDetails.SetValue(rsTempRec["component_max_base_qty"], cnt, gccMaxQtyColumn);
					aVoucherDetails.SetValue(rsTempRec["component_base_qty"], cnt, gccOriginalQtyColumn);
					aVoucherDetails.SetValue(rsTempRec["component_base_qty"], cnt, gccQtyColumn);
					aVoucherDetails.SetValue(Convert.ToDouble(rsTempRec["component_base_qty"]) * mVoucherQty, cnt, gccTotalQtyColumn);

					aVoucherDetails.SetValue(rsTempRec["Component_Sales_Price"], cnt, gccOriginalSalesRateColumn);
					aVoucherDetails.SetValue(rsTempRec["Component_Sales_Price"], cnt, gccSalesRateColumn);
					aVoucherDetails.SetValue(Convert.ToDouble(rsTempRec["Component_Sales_Price"]) * (Convert.ToDouble(rsTempRec["component_base_qty"]) * mVoucherQty), cnt, gccTotalAmountColumn);
					aVoucherDetails.SetValue(rsTempRec["Component_Max_Rate_Adjustment"], cnt, gccAdjustMaxRateColumn);
					aVoucherDetails.SetValue(rsTempRec["Component_Min_Rate_Adjustment"], cnt, gccAdjustMinRateColumn);

					aVoucherDetails.SetValue(rsTempRec["serialized"], cnt, gccSerialisedColumn);
					aVoucherDetails.SetValue(rsTempRec["comments"], cnt, gccRemarksColumn);

					cnt++;
				}
				while(rsTempRec.Read());
				rsTempRec.Close();
			}


			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				CalculateTotals(cnt, 0);
			}
			grdVoucherDetails.Rebind(true);

			grdVoucherDetails.Refresh();
			AssignGridLineNumbers();
			grdVoucherDetails.Col = gccQtyColumn;

		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			grdVoucherDetails.UpdateData();
			C1.Win.C1TrueDBGrid.C1DataColumnCollection withVar = null;
			if (ColIndex == gccQtyColumn)
			{
				CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);
				grdVoucherDetails.Refresh();

				withVar = grdVoucherDetails.Columns;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (grdVoucherDetails.Splits[0].DisplayColumns[gccSerialNoColumn].Visible && mSerialNoRequired)
				{
					ShowSerialNo(withVar[gccPartNoColumn].DataColumn.Text, withVar[gccTotalQtyColumn].DataColumn.Text);
				}
			}
		}

		private void grdVoucherDetails_BeforeColUpdate(object eventSender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			object OldValue = eventArgs.OldValue;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("minimum_and_maximum_qty_restriction_in_assembly"))) == TriState.True)
				{
					if (ColIndex == gccQtyColumn)
					{
						if ((Conversion.Val(grdVoucherDetails.Columns[gccQtyColumn].Text) >= Conversion.Val(grdVoucherDetails.Columns[gccMinQtyColumn].Text)) && (Conversion.Val(grdVoucherDetails.Columns[gccQtyColumn].Text) <= Conversion.Val(grdVoucherDetails.Columns[gccMaxQtyColumn].Text)))
						{
							Cancel = 0;
						}
						else
						{
							Cancel = -1;
						}
					}
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		private void grdVoucherDetails_ButtonClick(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			C1.Win.C1TrueDBGrid.C1DataColumnCollection withVar = null;
			withVar = grdVoucherDetails.Columns;
			if (ColIndex == gccSerialNoColumn)
			{
				ShowSerialNo(withVar[gccPartNoColumn].DataColumn.Text, withVar[gccTotalQtyColumn].DataColumn.Text);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			switch(ColIndex)
			{
				case gccSalesRateColumn : case gccTotalAmountColumn : 
					if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
					{
						Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,###,##0.000");
					}
					else
					{
						Value = "";
					} 
					break;
				case gccQtyColumn : 
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
			}
		}

		private void grdVoucherDetails_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				if (grdVoucherDetails.Col == gccSerialNoColumn)
				{
					KeyAscii = 0;
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			grdVoucherDetails.Columns[gccLineNoColumn].Text = (grdVoucherDetails.RowCount + 1).ToString();
		}

		private void AssignGridLineNumbers()
		{
			//''''*************************************************************************
			//'''Assign the Grid Line No
			//''''*************************************************************************

			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, gccLineNoColumn);
			}
		}

		private void CalculateTotals(int mRowNumber, int mColNumber)
		{

			int cnt = 0;

			if (aVoucherDetails.GetLength(0) > 0)
			{
				if (Information.IsNumeric(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccQtyColumn)))))
				{
					aVoucherDetails.SetValue((Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccQtyColumn)))) * mVoucherQty, mRowNumber, gccTotalQtyColumn);
				}
				else
				{
					aVoucherDetails.SetValue(0, mRowNumber, gccTotalQtyColumn);
				}


				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("adjust_sales_rates_of_assembly_group_components")))
				{
					//'''For adjust rate greater
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Component_Max_Rate_Adjustment_In_Product")))
					{
						if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccQtyColumn))) > Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccOriginalQtyColumn))))
						{
							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
							if (((TriState) Convert.ToInt32(aVoucherDetails.GetValue(mRowNumber, gccAdjustMaxRateColumn))) == TriState.True)
							{
								if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mRowNumber, gccTotalQtyColumn), SystemVariables.DataType.NumberType) && Information.IsNumeric(aVoucherDetails.GetValue(mRowNumber, gccSalesRateColumn)))
								{
									aVoucherDetails.SetValue((Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalQtyColumn)))) * (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccOriginalSalesRateColumn)))), mRowNumber, gccTotalAmountColumn);
									aVoucherDetails.SetValue((Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalAmountColumn)))) / (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalQtyColumn)))), mRowNumber, gccSalesRateColumn);
								}
								else
								{
									aVoucherDetails.SetValue(0, mRowNumber, gccTotalAmountColumn);
								}
							}
							else
							{
								if (!SystemProcedure2.IsItEmpty(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalQtyColumn))), SystemVariables.DataType.NumberType) && Information.IsNumeric(aVoucherDetails.GetValue(mRowNumber, gccOriginalQtyColumn)) && Information.IsNumeric(aVoucherDetails.GetValue(mRowNumber, gccSalesRateColumn)))
								{
									aVoucherDetails.SetValue((Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccOriginalQtyColumn)))) * mVoucherQty * (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccOriginalSalesRateColumn)))), mRowNumber, gccTotalAmountColumn);
									aVoucherDetails.SetValue((Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalAmountColumn)))) / (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalQtyColumn)))), mRowNumber, gccSalesRateColumn);
								}
								else
								{
									aVoucherDetails.SetValue(0, mRowNumber, gccTotalAmountColumn);
								}
							}
						}
					}


					//'''For adjust rate less
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Component_min_Rate_Adjustment_In_Product")))
					{
						if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccQtyColumn))) < Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccOriginalQtyColumn))))
						{
							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
							if (((TriState) Convert.ToInt32(aVoucherDetails.GetValue(mRowNumber, gccAdjustMinRateColumn))) == TriState.True)
							{
								if (!SystemProcedure2.IsItEmpty(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalQtyColumn))), SystemVariables.DataType.NumberType) && Information.IsNumeric(aVoucherDetails.GetValue(mRowNumber, gccSalesRateColumn)))
								{
									aVoucherDetails.SetValue((Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalQtyColumn)))) * (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccOriginalSalesRateColumn)))), mRowNumber, gccTotalAmountColumn);
									aVoucherDetails.SetValue((Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalAmountColumn)))) / (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalQtyColumn)))), mRowNumber, gccSalesRateColumn);
								}
								else
								{
									aVoucherDetails.SetValue(0, mRowNumber, gccTotalAmountColumn);
								}
							}
							else
							{
								if (!SystemProcedure2.IsItEmpty(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalQtyColumn))), SystemVariables.DataType.NumberType) && Information.IsNumeric(aVoucherDetails.GetValue(mRowNumber, gccOriginalQtyColumn)) && Information.IsNumeric(aVoucherDetails.GetValue(mRowNumber, gccSalesRateColumn)))
								{
									aVoucherDetails.SetValue((Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccOriginalQtyColumn)))) * mVoucherQty * (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccOriginalSalesRateColumn)))), mRowNumber, gccTotalAmountColumn);
									aVoucherDetails.SetValue((Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalAmountColumn)))) / (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalQtyColumn)))), mRowNumber, gccSalesRateColumn);
								}
								else
								{
									aVoucherDetails.SetValue(0, mRowNumber, gccTotalAmountColumn);
								}
							}
						}
					}


					//'''Equal
					if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccQtyColumn))) == Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccOriginalQtyColumn))))
					{
						if (!SystemProcedure2.IsItEmpty(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalQtyColumn))), SystemVariables.DataType.NumberType) && Information.IsNumeric(aVoucherDetails.GetValue(mRowNumber, gccSalesRateColumn)))
						{
							aVoucherDetails.SetValue((Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalQtyColumn)))) * (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccOriginalSalesRateColumn)))), mRowNumber, gccTotalAmountColumn);
							aVoucherDetails.SetValue((Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalAmountColumn)))) / (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccTotalQtyColumn)))), mRowNumber, gccSalesRateColumn);
						}
						else
						{
							aVoucherDetails.SetValue(0, mRowNumber, gccTotalAmountColumn);
						}
					}
				}
			}


			double mQty = 0;
			double mTotalQty = 0;
			double mTotalAmt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mQty += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, gccQtyColumn)));
				mTotalQty += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, gccTotalQtyColumn)));
				mTotalAmt += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, gccTotalAmountColumn)));
			}

			if (mQty != 0)
			{
				if (mQty - Math.Floor(mQty) > 0)
				{
					grdVoucherDetails.Columns[gccQtyColumn].FooterText = StringsHelper.Format(mQty, "###,###,###,##0.0##");
				}
				else
				{
					grdVoucherDetails.Columns[gccQtyColumn].FooterText = StringsHelper.Format(mQty, "###,###,###,##0");
				}
			}
			else
			{
				grdVoucherDetails.Columns[gccQtyColumn].FooterText = "";
			}

			if (mTotalQty != 0)
			{
				if (mTotalQty - Math.Floor(mTotalQty) > 0)
				{
					grdVoucherDetails.Columns[gccTotalQtyColumn].FooterText = StringsHelper.Format(mTotalQty, "###,###,###,##0.0##");
				}
				else
				{
					grdVoucherDetails.Columns[gccTotalQtyColumn].FooterText = StringsHelper.Format(mTotalQty, "###,###,###,##0");
				}
			}
			else
			{
				grdVoucherDetails.Columns[gccTotalQtyColumn].FooterText = "";
			}

			if (mTotalAmt != 0)
			{
				grdVoucherDetails.Columns[gccTotalAmountColumn].FooterText = StringsHelper.Format(mTotalAmt, "###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails.Columns[gccTotalAmountColumn].FooterText = "";
			}

		}

		public void CloseForm()
		{
			this.Hide();
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				frmICSProductAssemblyDetails.DefInstance = null;
				rsParentAssemblyDetails = null;
				rsParentAssemblySerialNo = null;
				rsProductCodeList = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void ShowSerialNo(string pProductCode, string pTotalSerialNo)
		{
			frmICSSerialNo oVoucherSerialNo = frmICSSerialNo.CreateInstance();
			DataSet rsCloneRecordset = null;

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
						oVoucherSerialNo.SetVoucherSourceRecordSet = rsParentAssemblySerialNo;
						//.FormMode = Me.CurrentFormMode
						oVoucherSerialNo.LineNo = mLineNo;
						oVoucherSerialNo.ParentLineNo = Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[gccLineNoColumn].Value)));
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						oVoucherSerialNo.VoucherType = Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["voucher_type"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						oVoucherSerialNo.ProductCode = Convert.ToInt32(rsCloneRecordset.Tables[0].Rows[0]["prod_cd"]);
						oVoucherSerialNo.TotalSerialNo = Convert.ToInt32(Double.Parse(pTotalSerialNo));

						oVoucherSerialNo.LocatCode = mLocatCode;

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
			return;
		}
	}
}