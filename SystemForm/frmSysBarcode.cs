
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.Gui;

using UpgradeHelpers.VB;


namespace Xtreme
{
	internal partial class frmSysBarcode
		: System.Windows.Forms.Form
	{


		private clsAccessAllowed _UserAccess = null;
		public frmSysBarcode()
{
InitializeComponent();
} 
 public  void frmSysBarcode_old()
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

		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;

		private XArrayHelper aVoucherDetails = null;

		private const int conTxtLabelWidth = 0;
		private const int conTxtLabelHeight = 1;
		private const int conTxtBarcodeFontSize = 2;
		private const int conTxtWordWrapLength = 3;
		private const int conTxtFromPartNo = 4;
		private const int conTxtToPartNo = 5;
		private const int conTxtCustom1 = 6;
		private const int conTxtCustom2 = 7;
		private const int conTxtCustom3 = 8;
		private const int conTxtCustom4 = 9;
		private const int conTxtSupplierPart = 10;

		private const int conDLblFromPartNo = 0;
		private const int conDLblToPartNo = 1;

		private const int gccLineNoColumn = 0;
		private const int gccProductCodeColumn = 1;
		private const int gccProductNameColumn = 2;
		private const int gccUnitColumn = 3;
		private const int gccBarcodeColumn = 4;
		private const int gccSalesRateColumn = 5;
		private const int gccCompanyNameColumn = 6;
		private const int gccProdDescColumn = 7;
		private const int gccMadeColumn = 8;
		private const int gccPackColumn = 9;
		private const int gccExpDateColumn = 10;
		private const int gccPackDateColumn = 11;

		private const int gccCopiesColumn = 12;
		private const int gccStatusColumn = 13;

		private const int mMaxArrayCols = 13;

		private const int cCpPartNo = 0;
		private const int cCpProdName = 1;
		private const int cCpUnit = 2;
		private const int cCpBarcode = 3;
		private const int cCpSalesRate = 4;
		private const int cCpStockInHand = 5;
		private const int cCpProdDesc = 6;
		private const int cCpMade = 7;
		private const int cCpPack = 8;
		private const int cCpExpDate = 9;



		private DataSet rsProductCodeList = null;
		private DataSet rsUnitList = null;
		private DataSet rsProductAlternateUnits = null;

		private bool mFirstGridFocus = false;

		private const string conStatusDone = "Done";
		private const string conStatusError = "Error";

		private const int conComHeader = 0;
		private const int conComFooter1 = 1;
		private const int conComFooter2 = 2;
		private const int conComPage = 3;

		private string mBarcodeFontName = "";
		private string mTextFontName = "";
		private int mTextFontSize = 0;

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



		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				SystemMenu.SetMeCurrentInWindowList(Conversion.Str(this.Handle.ToInt32()));
			}
		}

		private void GetBulkItems(string pFromPartNo, string pToPartNo)
		{

			int Cnt = 0;

			string mysql = "select part_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name as prod_name" : "a_prod_name as prod_name");
			mysql = mysql + " , pbd.barcode ";
			mysql = mysql + " , ICS_Item.sales_rate ";
			mysql = mysql + " ,  ICS_Unit.symbol, package, ExpDate, MadeIn,";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name" : "a_group_name") + " as group_name, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cat_name" : "a_cat_name") + " as cat_name ";
			mysql = mysql + " , ICS_Item.sale_rate1 ";
			mysql = mysql + " , ICS_Item.purchase_rate";
			mysql = mysql + " , ICS_Item.stock_in_hand ";
			mysql = mysql + " , ICS_Item.prod_desc ";
			mysql = mysql + " from ICS_Item ";

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_report_unit_in_barcode")))
			{
				mysql = mysql + " inner join  ICS_Unit on ICS_Item.report_unit_cd =  ICS_Unit.unit_cd ";
			}
			else
			{
				mysql = mysql + " inner join  ICS_Unit on ICS_Item.base_unit_cd =  ICS_Unit.unit_cd ";
			}

			mysql = mysql + " inner join ICS_Item_group on ICS_Item_group.group_cd = ICS_Item.group_cd ";
			mysql = mysql + " inner join ICS_Item_category on ICS_Item_category.cat_cd = ICS_Item.cat_cd ";
			mysql = mysql + " left join ICS_Item_barcode_details pbd on ICS_Item.prod_cd = pbd.prod_cd ";
			mysql = mysql + " where ICS_Item.discontinued = 0 ";
			//mysql = mysql & " and ICS_Item.stock_in_hand > 0 "

			if (!SystemProcedure2.IsItEmpty(pFromPartNo, SystemVariables.DataType.StringType) && !SystemProcedure2.IsItEmpty(pToPartNo, SystemVariables.DataType.StringType))
			{
				mysql = mysql + " and ICS_Item.part_no >='" + pFromPartNo + "'";
				mysql = mysql + " and ICS_Item.part_no <='" + pToPartNo + "'";
			}

			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_flex_details_tab_in_product"))) == TriState.True)
			{

				if (!SystemProcedure2.IsItEmpty(txtCommon[conTxtSupplierPart].Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " and ICS_Item.supplier_part_no = '" + txtCommon[conTxtSupplierPart].Text + "'";
				}

				if (!SystemProcedure2.IsItEmpty(txtFlex[1].Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " and ICS_Item.flex1_vssv_code = " + txtFlex[1].Text;
				}

				if (!SystemProcedure2.IsItEmpty(txtFlex[2].Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " and ICS_Item.flex2_vssv_code = " + txtFlex[2].Text;
				}

				if (!SystemProcedure2.IsItEmpty(txtFlex[3].Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " and ICS_Item.flex3_vssv_code = " + txtFlex[3].Text;
				}

			}

			mysql = mysql + " order by ICS_Item.part_no ";

			SqlDataReader myrec = null;
			//Call DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, True)

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
			}

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			myrec = sqlCommand.ExecuteReader();
			myrec.Read();
			do 
			{
				SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, Cnt, false);

				aVoucherDetails.SetValue(Cnt + 1, Cnt, gccLineNoColumn);
				aVoucherDetails.SetValue(myrec["part_no"], Cnt, gccProductCodeColumn);
				aVoucherDetails.SetValue(myrec["prod_name"], Cnt, gccProductNameColumn);
				aVoucherDetails.SetValue(myrec["symbol"], Cnt, gccUnitColumn);
				aVoucherDetails.SetValue(myrec["barcode"], Cnt, gccBarcodeColumn);
				aVoucherDetails.SetValue(myrec["sales_rate"], Cnt, gccSalesRateColumn);
				aVoucherDetails.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["l_comp_name"] : SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["a_comp_name"], Cnt, gccCompanyNameColumn);
				aVoucherDetails.SetValue(Math.Max(0, Math.Floor(Convert.ToDouble(myrec["stock_in_hand"]))), Cnt, gccCopiesColumn);
				aVoucherDetails.SetValue(0, Cnt, gccStatusColumn);
				aVoucherDetails.SetValue(Convert.ToString(myrec["prod_desc"]) + "", Cnt, gccProdDescColumn);
				aVoucherDetails.SetValue(DateTime.Now, Cnt, gccPackDateColumn);
				aVoucherDetails.SetValue(myrec["package"], Cnt, gccExpDateColumn);
				aVoucherDetails.SetValue(myrec["ExpDate"], Cnt, gccPackColumn);
				aVoucherDetails.SetValue(myrec["MadeIn"], Cnt, gccMadeColumn);
				aVoucherDetails.SetValue("", Cnt, gccStatusColumn);

				Cnt++;
			}
			while(myrec.Read());

			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Refresh();

		}



		private void cmdBulkPrint_Click(Object eventSender, EventArgs eventArgs)
		{
			GetBulkItems(txtCommon[conTxtFromPartNo].Text, txtCommon[conTxtToPartNo].Text);
		}


		private void cmdPrint_Click_old()
		{
			//Dim mFont As StdFont
			//
			//Dim mySql  As String
			//Dim rsTempRec As ADODB.Recordset
			//
			//Dim mSalesRate As Currency
			//Dim mProdDesc As String
			//
			//Dim NoOfCopies As Long
			//Dim ans As Integer
			//Dim cnt As Integer
			//Dim mWordWrapLength As Integer
			//Dim mPrintLabelResult As Integer
			//
			//grdVoucherDetails.Update
			//
			//With labels(0)
			//    .labelWidth = txtCommon(conTxtLabelWidth).Text
			//    .labelHeight = txtCommon(conTxtLabelHeight).Text
			//    .labelsAcross = 1
			//    .labelsDown = 1
			//    .verticalSpacing = 0
			//    .horizontalSpacing = 0
			//    .topMargin = 0  '1.13
			//    .sideMargin = 100 '0.38
			//    .pageWidth = 2500   '1.5
			//    .pageHeight = 1500  '1
			//End With
			//
			//
			//With bc
			//    .BarcodeTextPosition = Bottom_Center
			//    .BarcodeHeight = 500
			//'    .NarrowBarWidth = 25
			//'    .QuietZone = Small_Zone
			//
			//    .NarrowBarWidth = txtCommon(conTxtBarcodeFontSize).Text
			//    .QuietZone = Medium_Zone
			//
			//    .Symbology = Code_128_Auto
			//
			//
			//    '''''''Top Text Property ''''''''''''
			//    .TopTextAlignment = Center_Align
			//
			//    Set mFont = New StdFont
			//    With mFont
			//        .Name = "Arial Narrow"
			//        .Size = 6
			//        .Italic = True
			//        .Bold = True
			//    End With
			//    Set .TopTextFont = mFont
			//    ''''''''''''''''''''''''''''''''''''
			//
			//    '''''''Barcode Text Property '''''''
			//    .BarcodeTextPosition = Bottom_Center
			//
			//    Set mFont = New StdFont
			//    With mFont
			//        .Name = "Arial Narrow"
			//        .Size = 8
			//    End With
			//    Set .BarcodeTextFont = mFont
			//    ''''''''''''''''''''''''''''''''''''
			//
			//    '''''''Bottom Text Property ''''''''
			//    .BottomTextAlignment = Center_Align
			//
			//    Set mFont = New StdFont
			//    With mFont
			//        .Name = "Arial Narrow"
			//        .Size = 8
			//        .Bold = True
			//    End With
			//    Set .BottomTextFontName = mFont
			//    ''''''''''''''''''''''''''''''''''''
			//
			//    .StretchBarcodeText = False
			//
			//    '.Height = txtCommon(conTxtLabelHeight).Text
			//    '.Width = txtCommon(conTxtLabelWidth).Text
			//End With
			//
			//'If cmbPartNo.Text = "" Then
			//'    MsgBox "select a value to print", vbInformation
			//'    Exit Sub
			//'End If
			//'
			//'If cmbPartNo.ListIndex >= 0 Then
			//'    Set rsTempRec = New ADODB.Recordset
			//'    mySql = " select sale_rate1, l_prod_name from ICS_Item "
			//'    mySql = mySql & " where prod_cd =" & cmbPartNo.ItemData(cmbPartNo.ListIndex)
			//'    With rsTempRec
			//'        .Open mySql, gConn, adOpenStatic, adLockReadOnly
			//'        If Not .EOF Then
			//'            If IsNull(.Fields("sale_rate1")) Then
			//'                mSalesRate = 0
			//'            Else
			//'                mSalesRate = Format(Val(.Fields("sale_rate1")), "###,###,##0.000")
			//'            End If
			//'
			//'            mProdDesc = Trim(WordWrap(.Fields("l_prod_name").Value & "", 30))
			//'
			//'        End If
			//'        .Close
			//'    End With
			//'    Set rsTempRec = Nothing
			//'End If
			//
			//'NoOfCopies = txtNoOfCopies.Text
			//mWordWrapLength = txtCommon(conTxtWordWrapLength).Text
			//
			//For cnt = 0 To aVoucherDetails.Count(1) - 1
			//    NoOfCopies = Val(aVoucherDetails(cnt, gccCopiesColumn))
			//
			//    Do While NoOfCopies <> 0
			//        With bc
			//            .barcode = aVoucherDetails(cnt, gccBarcodeColumn)   ' cmbPartNo.Text
			//            '.TopText = " Furniture " & Chr(13) & " La De Villa Italy "
			//            '.TopText =  " Furniture La De Villa Italy , A product of Italia. "
			//
			//            mProdDesc = WordWrap(aVoucherDetails(cnt, gccProductNameColumn), mWordWrapLength)
			//            .TopText = mProdDesc        ' WordWrap(mProdDesc, 20)
			//            mSalesRate = Format(aVoucherDetails(cnt, gccSalesRateColumn), "###,###,###,##0.000")
			//
			//            If mSalesRate > 0 Then
			//                .BottomText = " Price: KD-" & Format(mSalesRate, "###,###,##0.000") & "/-"
			//            End If
			//            .AutoSize = True
			//        End With
			//
			//        NoOfCopies = NoOfCopies - 1
			//
			//        ans = MsgBox("do you want to continue ?", vbInformation + vbYesNoCancel)
			//
			//        If ans = vbYes Then
			//            lbl = labels(0)
			//            mPrintLabelResult = PrintLabel(aVoucherDetails(cnt, gccBarcodeColumn), lbl, 1, 1)
			//            If mPrintLabelResult = 1 Then
			//                aVoucherDetails(cnt, gccStatusColumn) = conStatusDone
			//            ElseIf mPrintLabelResult = 2 Then
			//                aVoucherDetails(cnt, gccStatusColumn) = conStatusError
			//            Else
			//                GoTo mExit
			//            End If
			//        ElseIf ans = vbNo Then
			//
			//        ElseIf ans = vbCancel Then
			//            Exit For
			//        End If
			//
			//        grdVoucherDetails.ReBind
			//        grdVoucherDetails.Refresh
			//        DoEvents
			//    Loop
			//Next cnt
			//
			//MsgBox " Barcode Printing Completed", vbInformation
			//Exit Sub
			//
			//mExit:
			//Exit Sub

		}

		public void PrintReport()
		{

			StringBuilder mysql = new StringBuilder();

			string mHeaderText = "";
			string mFooter1Text = "";
			string mFooter2Text = "";

			int mNoOfCopies = 0;
			DialogResult ans = (DialogResult) 0;
			int Cnt = 0;
			int mWordWrapLength = 0;
			int mIndex = 0;
			int mReportId = 0;

			//Dim mPrintLabelResult As Integer

			try
			{

				grdVoucherDetails.UpdateData();

				ans = MessageBox.Show("Do you want to continue ?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);

				if (ans == System.Windows.Forms.DialogResult.Yes)
				{
				}
				else
				{
					return;
				}

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = "delete ICS_Temp_Barcode";
				TempCommand.ExecuteNonQuery();

				mWordWrapLength = Convert.ToInt32(Conversion.Val(txtCommon[conTxtWordWrapLength].Text));

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					mNoOfCopies = Convert.ToInt32(Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccCopiesColumn))));


					while(mNoOfCopies != 0)
					{

						mIndex = cmbFields[conComHeader].ListIndex;
						if (mIndex != 0)
						{
							if (cmbFields[conComPage].Text == "Custom")
							{
								mHeaderText = Convert.ToString(aVoucherDetails.GetValue(Cnt, cmbFields[conComHeader].GetItemData(mIndex)));
							}
							else
							{
								string tempRefParam = Convert.ToString(aVoucherDetails.GetValue(Cnt, cmbFields[conComHeader].GetItemData(mIndex)));
								double tempRefParam2 = mWordWrapLength;
								mHeaderText = SystemGenerateBarcode.WordWrap(ref tempRefParam, ref tempRefParam2);
								mWordWrapLength = Convert.ToInt32(tempRefParam2);
							}
							if (cmbFields[conComHeader].GetItemData(mIndex) == gccSalesRateColumn)
							{
								mHeaderText = "KD " + StringsHelper.Format(mHeaderText, "###,###,###,##0.000");
							}
						}
						else
						{
							mHeaderText = "";
						}

						mIndex = cmbFields[conComFooter1].ListIndex;
						if (mIndex != 0)
						{
							if (cmbFields[conComPage].Text == "Custom")
							{
								mFooter1Text = Convert.ToString(aVoucherDetails.GetValue(Cnt, cmbFields[conComFooter1].GetItemData(mIndex)));
							}
							else
							{
								string tempRefParam3 = Convert.ToString(aVoucherDetails.GetValue(Cnt, cmbFields[conComFooter1].GetItemData(mIndex)));
								double tempRefParam4 = mWordWrapLength;
								mFooter1Text = SystemGenerateBarcode.WordWrap(ref tempRefParam3, ref tempRefParam4);
								mWordWrapLength = Convert.ToInt32(tempRefParam4);
							}
							if (cmbFields[conComFooter1].GetItemData(mIndex) == gccSalesRateColumn)
							{
								mFooter1Text = "KD " + StringsHelper.Format(mFooter1Text, "###,###,###,##0.000");
							}
						}
						else
						{
							mFooter1Text = "";
						}

						mIndex = cmbFields[conComFooter2].ListIndex;
						if (mIndex != 0)
						{
							if (cmbFields[conComPage].Text == "Custom")
							{
								mFooter2Text = Convert.ToString(aVoucherDetails.GetValue(Cnt, cmbFields[conComFooter2].GetItemData(mIndex)));
							}
							else
							{
								string tempRefParam5 = Convert.ToString(aVoucherDetails.GetValue(Cnt, cmbFields[conComFooter2].GetItemData(mIndex)));
								double tempRefParam6 = mWordWrapLength;
								mFooter2Text = SystemGenerateBarcode.WordWrap(ref tempRefParam5, ref tempRefParam6);
								mWordWrapLength = Convert.ToInt32(tempRefParam6);
							}
							if (cmbFields[conComFooter2].GetItemData(mIndex) == gccSalesRateColumn)
							{
								mFooter2Text = "KD " + StringsHelper.Format(mFooter2Text, "###,###,###,##0.000");
							}
						}
						else
						{
							mFooter2Text = "";
						}
						//mFooter2Text = Val(Format(aVoucherDetails(cnt, gccSalesRateColumn), "###########0.000"))
						//mFooter2Text = WordWrap(Val(Format(aVoucherDetails(cnt, gccSalesRateColumn), "###########0.000")), mWordWrapLength)
						if (cmbFields[conComPage].Text == "Slip")
						{
							DoPrinting(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBarcodeColumn)), mHeaderText, mFooter1Text, mFooter2Text);
						}
						else
						{

							if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, gccBarcodeColumn), SystemVariables.DataType.StringType))
							{
								mysql = new StringBuilder("Insert into ICS_Temp_Barcode (Barcode, HeaderText, FooterText1, FooterText2, Symbol, Custom1, Custom2, Custom3, Custom4, Remark)");
								mysql.Append(" Values('" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccBarcodeColumn)) + "',");
								mysql.Append(" '" + mHeaderText + "', '" + mFooter1Text + "', '" + mFooter2Text + "', '" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccUnitColumn)) + "',");
								mysql.Append(" N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccPackDateColumn)) + "', N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccExpDateColumn)) + "', N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccPackColumn)) + 
								             "', N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccMadeColumn)) + "', N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccProdDescColumn)) + "')");
								SqlCommand TempCommand_2 = null;
								TempCommand_2 = SystemVariables.gConn.CreateCommand();
								TempCommand_2.CommandText = mysql.ToString();
								TempCommand_2.ExecuteNonQuery();
							}
							else
							{
								mysql = new StringBuilder("Insert into ICS_Temp_Barcode (Barcode, HeaderText, FooterText1, FooterText2, Symbol, Custom1, Custom2, Custom3, Custom4, Remark)");
								mysql.Append(" Values('" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccProductCodeColumn)) + "',");
								mysql.Append(" '" + mHeaderText + "', '" + mFooter1Text + "', '" + mFooter2Text + "', '" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccUnitColumn)) + "',");
								mysql.Append(" N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccPackDateColumn)) + "', N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccExpDateColumn)) + "', N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccPackColumn)) + 
								             "', N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccMadeColumn)) + "', N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccProdDescColumn)) + "')");
								SqlCommand TempCommand_3 = null;
								TempCommand_3 = SystemVariables.gConn.CreateCommand();
								TempCommand_3.CommandText = mysql.ToString();
								TempCommand_3.ExecuteNonQuery();
							}

						}
						mNoOfCopies--;
						PrinterHelper.Printer.EndDoc();
					};

				}

				if (cmbFields[conComPage].Text == "Custom")
				{
					mReportId = 100060237;
					mReportId = cmbReport.GetItemData(cmbReport.SelectedIndex);
					SystemReports.GetCrystalReport(mReportId, 2, "", "", true, chkPreview.CheckState == CheckState.Unchecked, cmbPrinter.Text, false);
				}

				//MsgBox " Barcode Printing Completed", vbInformation
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

				if (aVoucherDetails.GetLength(0) > 0)
				{
					MessageBox.Show(" Error Occured for Part No." + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccProductCodeColumn)) + " Line No: " + Conversion.Str(Cnt), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}

				return;
			}
		}

		private void cmdSaveSetting_Click(Object eventSender, EventArgs eventArgs)
		{
			int i = 0;
			StringBuilder reports = new StringBuilder();

			int tempForEndVar = cmbReport.Items.Count - 1;
			for (i = 0; i <= tempForEndVar; i++)
			{
				if (i != 0)
				{
					reports.Append(",");
				}
				reports.Append(cmbReport.GetItemData(i).ToString());
			}

			FileSystem.FileOpen(1, SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + "AppBarcode.Config", OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
			FileSystem.PrintLine(1, "[BarcodeConfiguration]");
			FileSystem.PrintLine(1, "BarcodeFontSize=" + txtCommon[conTxtBarcodeFontSize].Text);
			FileSystem.PrintLine(1, "HeaderTextStringIndex=" + cmbFields[conComHeader].GetItemData(cmbFields[conComHeader].ListIndex).ToString());
			FileSystem.PrintLine(1, "Footer1TextStringIndex=" + cmbFields[conComFooter1].GetItemData(cmbFields[conComFooter1].ListIndex).ToString());
			FileSystem.PrintLine(1, "Footer2TextStringIndex=" + cmbFields[conComFooter2].GetItemData(cmbFields[conComFooter2].ListIndex).ToString());
			FileSystem.PrintLine(1, "Page=" + cmbFields[conComPage].GetItemData(cmbFields[conComPage].ListIndex).ToString());
			FileSystem.PrintLine(1, "ShowPreview=" + ((int) chkPreview.CheckState).ToString());
			FileSystem.PrintLine(1, "BarcodeReports=" + reports.ToString());
			FileSystem.PrintLine(1, "[LanguageSetting]");
			FileSystem.PrintLine(1, "PreferredLanguage=" + ((int) SystemVariables.gPreferedLanguage).ToString());

			FileSystem.FileClose(1);
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				object mTempSearchValue = null;
				//Refresh the product recordset when F5 is pressed
				if (Shift == 0 && KeyCode == 116 && !mFirstGridFocus)
				{
					RefreshRecordset();
				}


				if (KeyCode == 13 && this.ActiveControl.Name != "grdVoucherDetails")
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
					//ElseIf KeyCode = 27 Then
					//    Call cmdClose_Click
					//    Exit Sub

				}
				else if (KeyCode == 115 && (grdVoucherDetails.Col == gccProductCodeColumn || grdVoucherDetails.Col == gccProductNameColumn))
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

		private void FetchDetailsFromPartNoInGrid(string pPartNo, string pProdName)
		{

			grdVoucherDetails.Columns[gccProductCodeColumn].Value = pPartNo;
			grdVoucherDetails.Columns[gccProductNameColumn].Value = pProdName;

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
				grdVoucherDetails.Columns[gccProductCodeColumn].Value = "";
				grdVoucherDetails.Columns[gccProductNameColumn].Value = "";
			}

		}
		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			DataSet rsComboList = null;
			int Cnt = 0;
			int cnt1 = 0;


			//**--format & define the new toolbar
			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this);
			oThisFormToolBar.ShowPrintButton = true;
			oThisFormToolBar.ShowExitButton = true;

			oThisFormToolBar.BeginDeleteLineButtonWithGroup = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;

			oThisFormToolBar.ShowNewButton = true;
			oThisFormToolBar.ShowDeleteLineButton = true;

			this.WindowState = FormWindowState.Maximized;

			string mValue = new string(' ', 100);
			string reportFilter = new string(' ', 100);

			mFirstGridFocus = true;

			//**--define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2);

			//**--define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Item Code", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, true, false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Item Name", 2500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbMastersList", false, true, false, false, false, false, 200, "", "arabic transparent", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Unit", 600, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", true, true, false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Barcode", 1800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Sales Rate", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, true, true, 12, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Company Name", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false, false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Product Desc.", 3500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Made", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_package_date_on_item_master")), false, false, false, false, 100, "", "", false, "", 0, true);

			//    If GetSystemPreferenceSetting("show_package_date_on_item_master") = True Then
			//        Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Pack Date", 1100, , , , , , , , , , , , , , , , , , , , , , "txtTempDate", , True)
			//        Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Exp Date", 1100, , , , , , , , , , , , , , , , , , , , , , "txtTempDate", , True)
			//        Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Packing", 1100, , , , , , , , , , , , , , , , , , , , , , "txtTempDate", , True)
			//        Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Made", 1100, , , , , , , , , , , , , , , , , , , , , , , , True)
			//    Else
			//        Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Exp Date", 1100, , , , , , , , , , , , , GetSystemPreferenceSetting("show_package_date_on_item_master"), , , , , , , , , "txtTempDate", , True)
			//        Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Pack Date", 1100, , , , , , , , , , , , , GetSystemPreferenceSetting("show_package_date_on_item_master"), , , , , , , , , "txtTempDate", , True)
			//        Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Prod Date", 1100, , , , , , , , , , , , , GetSystemPreferenceSetting("show_package_date_on_item_master"), , , , , , , , , "txtTempDate", , True)

			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Prod Date", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_package_date_on_item_master")), false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Exp Date", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_package_date_on_item_master")), false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Pack Date", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_package_date_on_item_master")), false, false, false, false, 100, "", "", false, "", 0, true);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Copies", 600, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, true, true, 12, "", "", false, "", 0, true);


			//    End If

			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Status", 700, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, true, false, 12);


			Application.DoEvents();
			grdVoucherDetails.Visible = true;


			//''''*************************************************************************
			//setting voucher details grid properties
			aVoucherDetails = new XArrayHelper();
			SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, false);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);
			grdVoucherDetails.Rebind(true);
			//''''*************************************************************************

			PrinterHelper.Printer.ScaleMode = (int) PrinterHelper.ScaleModeConstants.VbPixels;
			txtCommon[conTxtLabelHeight].Text = PrinterHelper.Printer.ScaleHeight.ToString();
			txtCommon[conTxtLabelWidth].Text = PrinterHelper.Printer.ScaleWidth.ToString();

			mBarcodeFontName = "AdvC128c";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mTextFontName = "Arial Narrow";
			}
			else
			{
				mTextFontName = "Arabic Transparent";
			}
			mTextFontSize = 8;


			cmbFields[conComHeader].AddItem("");
			cmbFields[conComHeader].SetItemData(cmbFields[conComHeader].NewIndex, 0);

			cmbFields[conComFooter1].AddItem("");
			cmbFields[conComFooter1].SetItemData(cmbFields[conComFooter1].NewIndex, 0);

			cmbFields[conComFooter2].AddItem("");
			cmbFields[conComFooter2].SetItemData(cmbFields[conComFooter2].NewIndex, 0);

			//''Fill all the 3 listbox with the values the grid caption
			int tempForEndVar = grdVoucherDetails.Columns.Count - 3;
			for (Cnt = 1; Cnt <= tempForEndVar; Cnt++)
			{
				for (cnt1 = 0; cnt1 <= 2; cnt1++)
				{
					cmbFields[cnt1].AddItem(grdVoucherDetails.Columns[Cnt].Caption);
					cmbFields[cnt1].SetItemData(cmbFields[cnt1].NewIndex, Cnt);
				}
			}

			cmbFields[conComHeader].ListIndex = 1;
			cmbFields[conComFooter1].ListIndex = 2;
			cmbFields[conComFooter2].ListIndex = 3;

			//'''Printer Selection-----------Moiz Hakimi------30-Jyly-2009----------------
			PrinterHelper prt = null;

			foreach (PrinterHelper prtIterator in PrinterHelper.Printers)
			{
				prt = prtIterator;
				cmbPrinter.AddItem(PrinterHelper.Printer.DeviceName);
				prt = default(PrinterHelper);
			}

			cmbFields[conComPage].AddItem("");
			cmbFields[conComPage].SetItemData(cmbFields[conComPage].NewIndex, 0);

			cmbFields[conComPage].AddItem("Slip");
			cmbFields[conComPage].SetItemData(cmbFields[conComPage].NewIndex, 1);
			cmbFields[conComPage].AddItem("Custom");
			cmbFields[conComPage].SetItemData(cmbFields[conComPage].NewIndex, 2);
			cmbFields[conComPage].ListIndex = 1;

			SystemProcedure.SetLabelCaption(this);
			//''''get the
			string tempRefParam = "BarcodeConfiguration";
			string tempRefParam2 = "14";
			string tempRefParam3 = SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + "AppBarcode.Config";
			InnovaUpdSupport.PInvoke.SafeNative.kernel32.GetPrivateProfileString(ref tempRefParam, "BarcodeFontSize", ref tempRefParam2, ref mValue, 3, ref tempRefParam3);
			txtCommon[conTxtBarcodeFontSize].Text = mValue.Trim();

			string tempRefParam4 = "BarcodeConfiguration";
			string tempRefParam5 = "1";
			string tempRefParam6 = SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + "AppBarcode.Config";
			InnovaUpdSupport.PInvoke.SafeNative.kernel32.GetPrivateProfileString(ref tempRefParam4, "HeaderTextStringIndex", ref tempRefParam5, ref mValue, 2, ref tempRefParam6);
			SystemCombo.SearchCombo(cmbFields[conComHeader], Convert.ToInt32(Conversion.Val(mValue.Trim())));

			string tempRefParam7 = "BarcodeConfiguration";
			string tempRefParam8 = "2";
			string tempRefParam9 = SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + "AppBarcode.Config";
			InnovaUpdSupport.PInvoke.SafeNative.kernel32.GetPrivateProfileString(ref tempRefParam7, "Footer1TextStringIndex", ref tempRefParam8, ref mValue, 2, ref tempRefParam9);
			SystemCombo.SearchCombo(cmbFields[conComFooter1], Convert.ToInt32(Conversion.Val(mValue.Trim())));

			string tempRefParam10 = "BarcodeConfiguration";
			string tempRefParam11 = "2";
			string tempRefParam12 = SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + "AppBarcode.Config";
			InnovaUpdSupport.PInvoke.SafeNative.kernel32.GetPrivateProfileString(ref tempRefParam10, "Footer2TextStringIndex", ref tempRefParam11, ref mValue, 2, ref tempRefParam12);
			SystemCombo.SearchCombo(cmbFields[conComFooter2], Convert.ToInt32(Conversion.Val(mValue.Trim())));

			string tempRefParam13 = "BarcodeConfiguration";
			string tempRefParam14 = "2";
			string tempRefParam15 = SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + "AppBarcode.Config";
			InnovaUpdSupport.PInvoke.SafeNative.kernel32.GetPrivateProfileString(ref tempRefParam13, "Page", ref tempRefParam14, ref mValue, 2, ref tempRefParam15);
			SystemCombo.SearchCombo(cmbFields[conComPage], Convert.ToInt32(Conversion.Val(mValue.Trim())));

			string tempRefParam16 = "BarcodeConfiguration";
			string tempRefParam17 = "0";
			string tempRefParam18 = SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + "AppBarcode.Config";
			InnovaUpdSupport.PInvoke.SafeNative.kernel32.GetPrivateProfileString(ref tempRefParam16, "ShowPreview", ref tempRefParam17, ref mValue, 2, ref tempRefParam18);
			//UPGRADE_WARNING: (6021) Casting 'double' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			chkPreview.CheckState = (CheckState) Convert.ToInt32(Conversion.Val(mValue.Trim()));

			string tempRefParam19 = "BarcodeConfiguration";
			string tempRefParam20 = PrinterHelper.Printer.DeviceName;
			string tempRefParam21 = SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + "AppBarcode.Config";
			InnovaUpdSupport.PInvoke.SafeNative.kernel32.GetPrivateProfileString(ref tempRefParam19, "Printer", ref tempRefParam20, ref mValue, 50, ref tempRefParam21);
			cmbPrinter.Text = mValue;

			clsFlip oFlipThisForm = null;
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
			{
				oFlipThisForm = new clsFlip();

				oFlipThisForm.SwapMe(this);
			}

			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_flex_details_tab_in_product"))) == TriState.True)
			{
				frmFlex.Visible = true;
			}

			//**--fill Reports combobox
			string tempRefParam22 = "BarcodeConfiguration";
			string tempRefParam23 = "301137062";
			string tempRefParam24 = SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + "AppBarcode.Config";
			InnovaUpdSupport.PInvoke.SafeNative.kernel32.GetPrivateProfileString(ref tempRefParam22, "BarcodeReports", ref tempRefParam23, ref reportFilter, 50, ref tempRefParam24);

			string[] aParameterNameList = reportFilter.Trim().Split(',');

			string mysql = "select ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " l_report_name ";
			}
			else
			{
				mysql = mysql + " a_report_name ";
			}
			mysql = mysql + ", report_id from SM_reports ";
			mysql = mysql + " where  ";

			int tempForEndVar3 = aParameterNameList.GetUpperBound(0);
			for (Cnt = 0; Cnt <= tempForEndVar3; Cnt++)
			{
				if (Cnt > 0)
				{
					mysql = mysql + " or ";
				}
				mysql = mysql + " report_id = " + aParameterNameList[Cnt];
			}

			SystemCombo.FillComboWithItemData(cmbReport, mysql);
			cmbReport.SelectedIndex = 0;

			this.WindowState = FormWindowState.Maximized;
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			//'***************************************************************************''
			//'This routine handles the listbox attributes on the grid according to the
			//'datasource. It gives the width of columns in the listbox and sort order.
			//'***************************************************************************''

			int Cnt = 0;
			cmbMastersList.Width = 0;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			switch(grdVoucherDetails.Col)
			{
				case gccProductCodeColumn : case gccProductNameColumn : 
					if (grdVoucherDetails.Col == gccProductCodeColumn)
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
						if (Cnt < 10)
						{
							switch(Cnt)
							{
								case 0 : 
									//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
									withVar.setOrder((grdVoucherDetails.Col == gccProductCodeColumn) ? 0 : 1); 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccProductCodeColumn].Width; 
									withVar.Visible = true; 
									break;
								case 1 : 
									//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
									withVar.setOrder((grdVoucherDetails.Col == gccProductCodeColumn) ? 1 : 0); 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccProductNameColumn].Width; 
									withVar.Visible = true; 
									break;
								case 2 : 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccUnitColumn].Width; 
									withVar.Visible = true; 
									break;
								case 3 : 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccBarcodeColumn].Width; 
									withVar.Visible = true; 
									break;
								case 4 : 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccSalesRateColumn].Width; 
									withVar.Visible = true; 
									break;
								case cCpStockInHand : 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccCopiesColumn].Width; 
									withVar.Visible = true; 
									break;
								case cCpExpDate : 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccExpDateColumn].Width; 
									withVar.Visible = true; 
									break;
								case cCpPack : 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccPackColumn].Width; 
									withVar.Visible = true; 
									break;
								case cCpMade : 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccMadeColumn].Width; 
									withVar.Visible = true; 
									break;
								default:
									withVar.Visible = false; 
									withVar.Width = 0; 
									break;
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
				case gccUnitColumn : 
					int tempForEndVar2 = cmbMastersList.Columns.Count - 1; 
					for (Cnt = 0; Cnt <= tempForEndVar2; Cnt++)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("symbol");
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_2 = cmbMastersList.Splits[0].DisplayColumns[Cnt];
						if (Cnt < 2)
						{
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							withVar_2.Visible = true;
							if (Cnt == 0)
							{
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbMastersList.DisplayColumns[Cnt].Width = grdVoucherDetails.Splits[0].DisplayColumns[SystemICSConstants.grdUnitSymbolColumn].Width;
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbMastersList.Width += grdVoucherDetails.Splits[0].DisplayColumns[SystemICSConstants.grdUnitSymbolColumn].Width;
							}
							else if (Cnt == 1)
							{ 
								cmbMastersList.DisplayColumns[Cnt].Width = 67;
								cmbMastersList.Width += 67;
							}
						}
						else
						{
							withVar_2.Visible = false;
						}
						withVar_2.AllowSizing = false;
					} 
					cmbMastersList.Width += 17; 
					cmbMastersList.Height = 100; 
					break;
				default:
					cmbMastersList.Width = 0; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			//'***************************************************************************''
			//'This routine handles the navigation for next column after a value is selected
			//'from listbox in the grid.
			//'***************************************************************************''
			switch(grdVoucherDetails.Col)
			{
				case gccProductCodeColumn : 
					grdVoucherDetails.Col = gccProductNameColumn; 
					break;
				case gccProductNameColumn : 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			//'***************************************************************************''
			//'This routine handles the display of productname when a productcode is selected
			//'and vice versa. It also show the value in status bar after checking the
			//'"rsvouchertype" recordset values.
			//'
			//'NOTE: The value in Unit list box relies on product code column
			//'So even if the product code column "Visible=False", it should consists the code.
			//'***************************************************************************''

			C1.Win.C1TrueDBGrid.C1DataColumnCollection withVar = null;
			C1.Win.C1TrueDBGrid.C1DataColumnCollection withVar_2 = null;
			if (grdVoucherDetails.Col == gccProductCodeColumn || grdVoucherDetails.Col == gccProductNameColumn)
			{
				//'''''''''''''''''''''''''''''''''''''''''''''''''
				//''The below "if" checks for the bookmark of the listbox
				//''If the product code or product name does not match the value in listbox
				//''then the value should not be fetched.
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(cmbMastersList.Bookmark))
				{
					withVar = grdVoucherDetails.Columns;
					if (grdVoucherDetails.Col == gccProductCodeColumn)
					{
						withVar[gccProductNameColumn].DataColumn.Value = cmbMastersList.Columns[cCpProdName].Value;
					}
					else
					{
						withVar[gccProductCodeColumn].DataColumn.Value = cmbMastersList.Columns[cCpPartNo].Value;
					}
					withVar[gccUnitColumn].DataColumn.Value = cmbMastersList.Columns[cCpUnit].Value;
					withVar[gccBarcodeColumn].DataColumn.Value = cmbMastersList.Columns[cCpBarcode].Value;
					withVar[gccSalesRateColumn].DataColumn.Value = cmbMastersList.Columns[cCpSalesRate].Value;
					withVar[gccCopiesColumn].DataColumn.Value = 1; //Round(Val(cmbMastersList.Columns(cCpStockInHand).Value), 0)
					withVar[gccProdDescColumn].DataColumn.Value = cmbMastersList.Columns[cCpProdDesc].Value;

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_package_date_on_item_master")))
					{
						withVar[gccPackDateColumn].DataColumn.Value = StringsHelper.Format(SystemVariables.gCurrentDate, SystemVariables.gSystemDateFormat);
						withVar[gccExpDateColumn].DataColumn.Value = StringsHelper.Format(cmbMastersList.Columns[cCpExpDate].Value, SystemVariables.gSystemDateFormat); //cmbMastersList.Columns(cCpExpDate).Value
						withVar[gccPackColumn].DataColumn.Value = StringsHelper.Format(cmbMastersList.Columns[cCpPack].Value, SystemVariables.gSystemDateFormat); //cmbMastersList.Columns(cCpPack).Value
						withVar[gccMadeColumn].DataColumn.Value = cmbMastersList.Columns[cCpMade].Value;
					}
				}
				else
				{
					withVar_2 = grdVoucherDetails.Columns;
					if (grdVoucherDetails.Col == gccProductCodeColumn)
					{
						withVar_2[gccProductNameColumn].DataColumn.Value = "";
					}
					else
					{
						withVar_2[gccProductCodeColumn].DataColumn.Value = "";
					}
					withVar_2[gccBarcodeColumn].DataColumn.Value = "";
					withVar_2[gccSalesRateColumn].DataColumn.Value = "";
					withVar_2[gccCopiesColumn].DataColumn.Value = "";
				}
			}
			else if (grdVoucherDetails.Col == gccUnitColumn)
			{ 
				rsProductAlternateUnits.Tables[0].DefaultView.RowFilter = " part_no = '" + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[gccProductCodeColumn].Value).Trim() + "' and symbol ='" + ReflectionHelper.GetPrimitiveValue<string>(cmbMastersList.Columns[0].Value).Trim() + "'";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[gccBarcodeColumn].DataColumn.Value = rsProductAlternateUnits.Tables[0].Rows[0]["Barcode"];
			}

		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			grdVoucherDetails.Width = this.Width - 13;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			frmSysBarcode.DefInstance = null;
		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			//'***************************************************************************''
			//'This routine checks the column type and calls the "CalculateTotals" function.
			//'***************************************************************************''
			double mBaseQty = 0;

			grdVoucherDetails.UpdateData();

			if (ColIndex == gccProductCodeColumn || ColIndex == gccProductNameColumn)
			{
				CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);


				//'''The grid is refreshed twice because.
				//'''there is problem in calculate total function of when the price list is enabled.
				//'''the total is not displayed when the user reached to third line.
				grdVoucherDetails.Refresh();
				grdVoucherDetails.Refresh();
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
					case gccCopiesColumn : 
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
					case gccSalesRateColumn : 
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
				string mysql = "";

				if (mFirstGridFocus)
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList);
					RefreshRecordset();
					//grdVoucherDetails.PostMsg 1

					grdVoucherDetails_OnAddNew(grdVoucherDetails, new EventArgs());
					mFirstGridFocus = false;

					grdVoucherDetails_RowColChange(grdVoucherDetails, new C1.Win.C1TrueDBGrid.RowColChangeEventArgs());
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			//If mFirstGridFocus = False Then
			grdVoucherDetails.Columns[gccLineNoColumn].Text = (grdVoucherDetails.RowCount + 1).ToString();
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			grdVoucherDetails.Columns[gccCompanyNameColumn].Text = Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["l_comp_name"] : SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["a_comp_name"]);
			//End If

		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			try
			{

				int Cnt = 0;
				object mCurrentbal = null;

				StringBuilder mUnitFilterCondition = new StringBuilder();
				if (grdVoucherDetails.Col > 0 && !mFirstGridFocus)
				{
					switch(grdVoucherDetails.Col)
					{
						case gccBarcodeColumn : case gccProductCodeColumn : case gccProductNameColumn : 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersList.setDataSource((msdatasrc.DataSource) rsProductCodeList); 
							break;
						case gccUnitColumn : 
							//filter ICS_Unit records for the selected ICS_Item 
							if (ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[gccProductCodeColumn].Value) != "")
							{
								rsProductAlternateUnits.Tables[0].DefaultView.RowFilter = " part_no = '" + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[gccProductCodeColumn].Value).Trim() + "'";
								mUnitFilterCondition = new StringBuilder("");
								foreach (DataRow iteration_row in rsProductAlternateUnits.Tables[0].Rows)
								{
									if (mUnitFilterCondition.ToString() != "")
									{
										mUnitFilterCondition.Append(" or  ");
									}
									mUnitFilterCondition.Append(" unit_cd = " + Conversion.Str(iteration_row["alt_unit_cd"]));
								}
								//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								rsProductAlternateUnits.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
								rsUnitList.Tables[0].DefaultView.RowFilter = mUnitFilterCondition.ToString();
							}
							else
							{
								rsUnitList.Tables[0].DefaultView.RowFilter = "unit_cd = 0";
							} 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersList.setDataSource((msdatasrc.DataSource) rsUnitList); 
							break;
					}
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}


		}

		private void GetProductListSQL(ref string pSQL)
		{
			//''''*************************************************************************
			//'''Product List query, alone with base unit and stock info.
			//''''*************************************************************************

			pSQL = "select part_no, ";
			pSQL = pSQL + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name as prod_name" : "a_prod_name as prod_name");
			pSQL = pSQL + " ,  ICS_Unit.symbol ";
			pSQL = pSQL + " , pbd.barcode ";
			pSQL = pSQL + " , ICS_Item.sales_rate  ";
			//    pSQL = pSQL & " , " IIf(gPreferedLanguage = English, "l_group_name", "a_group_name") & " as group_name, "
			//    pSQL = pSQL & IIf(gPreferedLanguage = English, "l_cat_name", "a_cat_name") & " as cat_name "
			//    pSQL = pSQL & " , ICS_Item.sale_rate1 "
			//    pSQL = pSQL & " , ICS_Item.purchase_rate"
			pSQL = pSQL + " , ICS_Item.stock_in_hand ";
			pSQL = pSQL + " , ICS_Item.prod_desc ";

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_package_date_on_item_master")))
			{
				pSQL = pSQL + " , ICS_Item.MadeIn ";
				pSQL = pSQL + " , ICS_Item.package ";
				pSQL = pSQL + " , ICS_Item.ExpDate ";
			}

			pSQL = pSQL + " from ICS_Item ";
			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_report_unit_in_barcode")))
			{
				pSQL = pSQL + " inner join  ICS_Unit on ICS_Item.report_unit_cd =  ICS_Unit.unit_cd ";
			}
			else
			{
				pSQL = pSQL + " inner join  ICS_Unit on ICS_Item.base_unit_cd =  ICS_Unit.unit_cd ";
			}
			pSQL = pSQL + " inner join ICS_Item_group on ICS_Item_group.group_cd = ICS_Item.group_cd ";
			pSQL = pSQL + " inner join ICS_Item_category on ICS_Item_category.cat_cd = ICS_Item.cat_cd ";
			pSQL = pSQL + " left join ICS_Item_barcode_details pbd on ICS_Item.prod_cd = pbd.prod_cd ";
			pSQL = pSQL + " where ICS_Item.discontinued = 0 ";
			if (ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("Barcode_Item_filter")) != "")
			{
				pSQL = pSQL + " and " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("Barcode_Item_filter"));
			}
			pSQL = pSQL + " order by ICS_Item.part_no ";

		}


		private void CalculateTotals(int mRowNumber, int mColNumber)
		{
			//''''*************************************************************************
			//'''Calculate the figures of following columns.
			//'''Quantity, Rate , Discount and amount.
			//''''*************************************************************************
			int Cnt = 0;

			double mTotalQty = 0;


			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				mTotalQty += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccCopiesColumn)));
				//aVoucherDetails(cnt, gccBuildBuildQtyColumn) = aVoucherDetails(cnt, gccCopiesColumn) * mBuildQty

			}

			if (mTotalQty != 0)
			{
				if (mTotalQty - Math.Floor(mTotalQty) > 0)
				{
					grdVoucherDetails.Columns[gccCopiesColumn].FooterText = StringsHelper.Format(mTotalQty, "###,###,###,##0.0##");
				}
				else
				{
					grdVoucherDetails.Columns[gccCopiesColumn].FooterText = StringsHelper.Format(mTotalQty, "###,###,###,##0");
				}
			}
			else
			{
				grdVoucherDetails.Columns[gccCopiesColumn].FooterText = "";
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
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsProductCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsProductCodeList.Requery(-1);
			}

			if (mFirstGridFocus)
			{
				//open ICS_Unit master table
				mysql = "select symbol, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_unit_name" : "a_unit_name") + " as unit_name ";
				mysql = mysql + ", unit_cd from ICS_Unit order by 1 ";

				rsUnitList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsUnitList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsUnitList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsUnitList.Tables.Clear();
				adap_2.Fill(rsUnitList);

				//open ICS_Item alternate ICS_Unit details table
				mysql = "select ICS_Unit.symbol, bd.Barcode ";
				mysql = mysql + " , alt.sales_rate aud_sales_rate ";
				mysql = mysql + " , ICS_Item.part_no, ICS_Item.prod_cd, ICS_Item.base_unit_cd ";
				mysql = mysql + " , alt.unit_entry_id , alt_unit_cd, base_qty, alt_qty ";
				mysql = mysql + " , ICS_Item.sale_rate1 ";
				mysql = mysql + " , ICS_Item.purchase_rate ";
				mysql = mysql + " from ICS_Item_Unit_Details alt inner join ICS_Item on ";
				mysql = mysql + " alt.prod_cd = ICS_Item.prod_cd ";
				mysql = mysql + " inner join ICS_Unit on  ICS_Unit.unit_cd = alt.alt_unit_cd";
				mysql = mysql + " left outer join ICS_Item_Barcode_Details bd on  bd.prod_cd = alt.prod_cd";
				mysql = mysql + " and bd.Unit_Entry_Id = alt.Unit_Entry_Id";

				rsProductAlternateUnits = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProductAlternateUnits.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsProductAlternateUnits.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap_3 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsProductAlternateUnits.Tables.Clear();
				adap_3.Fill(rsProductAlternateUnits);

			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsUnitList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsUnitList.Requery(-1);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsProductAlternateUnits.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsProductAlternateUnits.Requery(-1);
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		private void DoPrinting(string pBarcode, string pHeaderText, string pFooter1Text, string pFooter2Text)
		{

			//''''''''Header Setting
			string mPrintString = pHeaderText;

			PrinterHelper prThis = null;
			if (PrinterHelper.Printers.Count > 0)
			{
				foreach (PrinterHelper prThisIterator in PrinterHelper.Printers)
				{
					prThis = prThisIterator;
					if (PrinterHelper.Printer.DeviceName == cmbPrinter.Text)
					{
						PrinterHelper.Printer = prThis;
						break;
					}
					//prThis
					prThis = default(PrinterHelper);
				}
			}

			PrinterHelper withVar = null;
			withVar = PrinterHelper.Printer;
			PrinterHelper.Printer.FontName = mTextFontName;
			PrinterHelper.Printer.FontSize = mTextFontSize;
			PrinterHelper.Printer.CurrentX = GetLeftPosition(mPrintString);
			PrinterHelper.Printer.CurrentY = 5;
			PrinterHelper.Printer.Print(mPrintString);
			//''''''''''''''''''''''''''

			//'''''''''Barcode setting
			mPrintString = SystemBarcode.Code128(pBarcode, 0);
			PrinterHelper withVar_2 = null;
			withVar_2 = PrinterHelper.Printer;
			PrinterHelper.Printer.FontName = mBarcodeFontName;
			PrinterHelper.Printer.FontSize = Single.Parse(txtCommon[conTxtBarcodeFontSize].Text);
			PrinterHelper.Printer.CurrentX = GetLeftPosition(mPrintString);
			PrinterHelper.Printer.CurrentY = 50;
			PrinterHelper.Printer.Print(mPrintString);

			//'''''''''''''''''''''''''''''''

			//'''''''''Bottom Text setting1
			mPrintString = pFooter1Text;
			PrinterHelper withVar_3 = null;
			withVar_3 = PrinterHelper.Printer;
			PrinterHelper.Printer.FontName = mTextFontName;
			PrinterHelper.Printer.FontSize = mTextFontSize;
			PrinterHelper.Printer.CurrentX = GetLeftPosition(mPrintString);
			PrinterHelper.Printer.CurrentY = 115;
			PrinterHelper.Printer.Print(mPrintString);
			//'''''''''''''''''''''''''''''''

			//'''''''''Bottom Text setting
			//mPrintString = "KD " & Format(pFooter2Text, "###,###,###,##0.000")   '& "/-"
			mPrintString = pFooter2Text;
			PrinterHelper withVar_4 = null;
			withVar_4 = PrinterHelper.Printer;
			PrinterHelper.Printer.FontName = mTextFontName;
			PrinterHelper.Printer.FontSize = mTextFontSize + 2;
			PrinterHelper.Printer.FontBold = true;
			PrinterHelper.Printer.CurrentX = GetLeftPosition(mPrintString);
			PrinterHelper.Printer.CurrentY = 140;
			PrinterHelper.Printer.Print(mPrintString);
			//'''''''''''''''''''''''''''''''

		}


		private int GetLeftPosition(string pString)
		{

			int mTextLength = Convert.ToInt32(PrinterHelper.Printer.TextWidth(pString));

			return Convert.ToInt32(((Conversion.Val(txtCommon[conTxtLabelWidth].Text) - mTextLength) / 2d) + 20);
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
				CalculateTotals(0, 0);
				grdVoucherDetails.Rebind(true);
			}
		}

		private void AssignGridLineNumbers()
		{
			int Cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				aVoucherDetails.SetValue(Cnt + 1, Cnt, gccLineNoColumn);
			}
		}


		private void txtCommon_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);
			FindRoutine("txtCommon#" + Index.ToString().Trim());
		}

		private void txtCommon_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommon, eventSender);

			object mTempValue = null;
			string mysql = "";
			int mLinkedTextBoxIndex = 0;

			try
			{
				switch(Index)
				{
					case conTxtFromPartNo : 
						mysql = "select l_prod_name, a_prod_name, prod_cd from ICS_Item where part_no='" + txtCommon[Index].Text + "'"; 
						 
						mLinkedTextBoxIndex = conDLblFromPartNo; 
						break;
					case conTxtToPartNo : 
						mysql = "select l_prod_name, a_prod_name, prod_cd from ICS_Item where part_no='" + txtCommon[Index].Text + "'"; 
						 
						mLinkedTextBoxIndex = conDLblToPartNo; 
						break;
					default:
						return;
				}

				if (!SystemProcedure2.IsItEmpty(txtCommon[Index].Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtCommonDisplay[mLinkedTextBoxIndex].Text = "";
						txtCommon[Index].Tag = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						txtCommonDisplay[mLinkedTextBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1));
						txtCommon[Index].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
					}
				}
				else
				{
					txtCommonDisplay[mLinkedTextBoxIndex].Text = "";
					txtCommon[Index].Tag = "";
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
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
					try
					{
						txtCommon[Index].Focus();
					}
					catch (Exception exc)
					{
						NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
					}
				}
				else
				{
					//
				}
			}

		}

		private void FindRoutine(string pObjectName)
		{

			object mTempSearchValue = null;
			string mFilterCondition = "";

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mObjectIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));
			if (mObjectName == "txtCommon")
			{
				txtCommon[mObjectIndex].Text = "";
				switch(mObjectIndex)
				{
					case conTxtFromPartNo : 
						//mFilterCondition = " type_cd =" & gGLCustomerVendorTypeCode 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001000, "28")); 
						break;
					case conTxtToPartNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001000, "28")); 
						break;
					default:
						return;
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommon[mObjectIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtCommon_Leave(txtCommon[mObjectIndex], new EventArgs());
				}
			}

			if (mObjectName == "txtFlex")
			{
				txtFlex[mObjectIndex].Text = "";
				//Select Case mObjectIndex
				//    Case ctFlex1Index
				mFilterCondition = " ( svs.vs_code =" + mObjectIndex.ToString() + " and svs.vs_object_type ='ICS_Item' " + " )";
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001006, "1940", mFilterCondition));
				//End Select
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtFlex[mObjectIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtFlex_Leave(txtFlex[mObjectIndex], new EventArgs());
				}
			}
		}


		public void GetRecord(int pEntryId)
		{

			int Cnt = 0;

			string mysql = "select part_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name as prod_name" : "a_prod_name as prod_name");
			mysql = mysql + " , pbd.barcode ";
			mysql = mysql + " , ICS_Item.sales_rate ";
			mysql = mysql + " ,  ICS_Unit.symbol, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name" : "a_group_name") + " as group_name, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cat_name" : "a_cat_name") + " as cat_name ";
			mysql = mysql + " , ICS_Item.sale_rate1 ";
			mysql = mysql + " , ICS_Item.purchase_rate";
			mysql = mysql + " , id.Qty ";
			mysql = mysql + " , ICS_Item.prod_desc ";
			mysql = mysql + " from ICS_Item ";
			mysql = mysql + " inner join ICS_Transaction_Details id on ICS_Item.prod_cd = id.prod_cd";

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_report_unit_in_barcode")))
			{
				mysql = mysql + " inner join  ICS_Unit on ICS_Item.report_unit_cd =  ICS_Unit.unit_cd ";
			}
			else
			{
				mysql = mysql + " inner join  ICS_Unit on ICS_Item.base_unit_cd =  ICS_Unit.unit_cd ";
			}
			mysql = mysql + " inner join ICS_Item_group on ICS_Item_group.group_cd = ICS_Item.group_cd ";
			mysql = mysql + " inner join ICS_Item_category on ICS_Item_category.cat_cd = ICS_Item.cat_cd ";
			mysql = mysql + " left join ICS_Item_barcode_details pbd on ICS_Item.prod_cd = pbd.prod_cd ";
			mysql = mysql + " where id.entry_id = " + pEntryId.ToString();
			mysql = mysql + " order by ICS_Item.part_no ";

			SqlDataReader myrec = null;
			SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, true);
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			myrec = sqlCommand.ExecuteReader();
			myrec.Read();
			do 
			{
				SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, Cnt, false);

				aVoucherDetails.SetValue(Cnt + 1, Cnt, gccLineNoColumn);
				aVoucherDetails.SetValue(myrec["part_no"], Cnt, gccProductCodeColumn);
				aVoucherDetails.SetValue(myrec["prod_name"], Cnt, gccProductNameColumn);
				aVoucherDetails.SetValue(myrec["symbol"], Cnt, gccUnitColumn);
				aVoucherDetails.SetValue(myrec["barcode"], Cnt, gccBarcodeColumn);
				aVoucherDetails.SetValue(myrec["sales_rate"], Cnt, gccSalesRateColumn);
				aVoucherDetails.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["l_comp_name"] : SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["a_comp_name"], Cnt, gccCompanyNameColumn);
				aVoucherDetails.SetValue(Math.Floor(Convert.ToDouble(myrec["Qty"])) + 1, Cnt, gccCopiesColumn);
				aVoucherDetails.SetValue("", Cnt, gccPackDateColumn);
				aVoucherDetails.SetValue("", Cnt, gccExpDateColumn);
				aVoucherDetails.SetValue("", Cnt, gccPackColumn);
				aVoucherDetails.SetValue("", Cnt, gccMadeColumn);
				aVoucherDetails.SetValue("", Cnt, gccStatusColumn);
				aVoucherDetails.SetValue(Convert.ToString(myrec["prod_desc"]) + "", Cnt, gccProdDescColumn);

				Cnt++;
			}
			while(myrec.Read());

			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Refresh();

		}

		public void AddRecord()
		{
			SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, true);
			//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			aVoucherDetails.Clear();
			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Refresh();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}



		private void txtFlex_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtFlex, Sender);
			try
			{
				FindRoutine("txtFlex#" + Index.ToString().Trim());
			}
			catch
			{
			}
		}

		private void txtFlex_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtFlex, eventSender);
			object mTempValue = null;
			string mysql = "";
			int mLinkedFlexBoxIndex = 0;

			try
			{

				//Select Case Index
				//    Case ctBaseUnitIndex
				mysql = "select svsv.vssv_l_name, svsv.vssv_a_name  ";
				mysql = mysql + "  from SM_VS_Static_Value svsv ";
				mysql = mysql + " inner join SM_Value_Set svs on svsv.entry_id = svs.entry_id ";
				mysql = mysql + " where ( svs.vs_code =" + Index.ToString() + " and svs.vs_object_type ='ICS_Item' " + " )";
				mysql = mysql + " and svsv.vssv_code ='" + txtFlex[Index].Text + "'";
				mLinkedFlexBoxIndex = Index;
				//    Case Else
				//        Exit Sub
				//End Select

				if (!SystemProcedure2.IsItEmpty(txtFlex[Index].Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtFlexDisplay[mLinkedFlexBoxIndex].Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						txtFlexDisplay[mLinkedFlexBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1));
					}
				}
				else
				{
					txtFlexDisplay[mLinkedFlexBoxIndex].Text = "";
				}
			}
			catch (System.Exception excep)
			{


				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "FlexLostFocus", SystemConstants.msg10);
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
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
					try
					{
						txtFlex[Index].Focus();
					}
					catch (Exception exc)
					{
						NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
					}
				}
				else
				{
					//
				}
			}
		}
	}
}