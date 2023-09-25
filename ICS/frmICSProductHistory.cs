
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using UpgradeHelpers;



namespace Xtreme
{
	internal partial class frmICSProductHistory
		: System.Windows.Forms.Form
	{

		public frmICSProductHistory()
{
InitializeComponent();
} 
 public  void frmICSProductHistory_old()
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
			
			InitExtendedProperties();
		}
		void InitExtendedProperties()
		{
			this.grdTransactionDetails.setScrollTips(false);
		}


		private void frmICSProductHistory_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
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

		private DataSet rsDetailsRecordset = null;
		private DataSet rsReportData = null;

		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;

		private const int mFixedRow = 0;
		private const string mColumnPrefix = "Column";

		string mysql = "";
		object mProductCode = null;
		object mGroupCode = null;
		string mMasterTableName = "";
		string mDetailsTableName = "";
		string mProductDescription = "";
		System.DateTime mFromDate = DateTime.FromOADate(0);
		System.DateTime mToDate = DateTime.FromOADate(0);

		private const int conLblCostDesc = 3;
		private const int conlblCostPrice = 5;

		string mColumnsClause = "";
		string mOrderByClause = "";
		string mWhereClause = "";

		static readonly private Color mFixedHeaderBackColor = SystemColors.Control;

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




		private void cmdGetProductHistory_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					cmdGetProductHistory_Click(cmdGetProductHistory, new EventArgs());
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void PrintReport()
		{
			SystemReports.GetSystemReport(51001050, 2, "", DateTimeHelper.ToString(mFromDate), DateTimeHelper.ToString(mToDate), "", mWhereClause);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			this.Top = 23;
			this.Left = 13;

			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			oThisFormToolBar.ShowPrintButton = true;
			oThisFormToolBar.ShowExitButton = true;

			this.WindowState = FormWindowState.Maximized;

			rsDetailsRecordset = new DataSet();
			rsReportData = new DataSet();

			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsDetailsRecordset.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsDetailsRecordset.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsReportData.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsReportData.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());

			string mysql = "select * from SM_REPORT_FIELDS where report_id=51001050 ";
			mysql = mysql + " and ((protected = 1) or ";
			mysql = mysql + " (show_detail=1 and show =1 and (field_language='U' or ";
			mysql = mysql + " field_language ='" + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "E" : "A") + "')))";
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsDetailsRecordset.Tables.Clear();
			adap.Fill(rsDetailsRecordset);

			FormatResultGrid();
			SetGridColumns();
			grdTransactionDetails.Enabled = false;
			grdTransactionDetails.Cols[0].Visible = false;

			txtFromDate.Value = DateTime.Parse("01-" + DateTimeFormatInfo.CurrentInfo.GetMonthName(1) + "-" + Conversion.Str(DateTime.Today.Year));
			txtToDate.Value = DateTime.Today;

			lblCommon[conLblCostDesc].Visible = SystemVariables.gEnableUserLevelCostDetails;
			lblCommon[conlblCostPrice].Visible = SystemVariables.gEnableUserLevelCostDetails;

			this.WindowState = FormWindowState.Maximized;
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//On Keydown navigate the form by using enter key
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}
				else if (KeyCode == ((int) Keys.Escape))
				{ 
					CloseForm();
					return;
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			cntMasterDetails.Width = this.Width - 7;
			grdTransactionDetails.Width = this.Width - 11;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				rsDetailsRecordset = null;
				UserAccess = null;
				frmICSProductHistory.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void cmdGetProductHistory_AccessKeyPress(int KeyAscii)
		{
			cmdGetProductHistory_Click(cmdGetProductHistory, new EventArgs());
		}

		public void cmdGetProductHistory_Click(Object eventSender, EventArgs eventArgs)
		{
			//Product Transaction  Value in Grid

			//If txtTransactionType.Text = "" Then    'Or txtLedgerCode.Text = "" Or txtProductCode.Text = "" Then
			//    If txtTransactionType.Text = "" Then
			//        MsgBox "Error:Trasaction Type"
			//        txtTransactionType.SetFocus
			//'    ElseIf txtLedgerCode.Text = "" Then
			//'        MsgBox "Error: Ledger Code"
			//'        txtLedgerCode.SetFocus
			//'    ElseIf txtProductCode.Text = "" Then
			//'        MsgBox "Error:Product Code"
			//'        txtProductCode.SetFocus
			//    End If
			//    Exit Sub
			//End If

			if (txtTransactionType.Text == "" && txtLedgerCode.Text == "" && txtProductCode.Text == "" && txtGroupCode.Text == "")
			{
				MessageBox.Show("All the parameters cannot be optional, atleast select one paramameter", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
				txtTransactionType.Focus();
			}

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Prod_Desc , cost from ICS_Item where Part_no ='" + txtProductCode.Text + "'"));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mProductDescription = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				lblCommon[conlblCostPrice].Caption = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1)), "###,###,###,##0.000") + " )";
			}
			else
			{
				mProductDescription = "";
				lblCommon[conlblCostPrice].Caption = "0.000)";
			}

			lblProductDescription[3].Text = mProductDescription + "";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mProductCode = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select prod_cd from ICS_Item where ICS_Item.part_no = '" + txtProductCode.Text + "'"));

			if (!SystemProcedure2.IsItEmpty(txtGroupCode.Text, SystemVariables.DataType.StringType))
			{
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mGroupCode = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select group_cd from ICS_Item_group where group_no = " + txtGroupCode.Text));
			}


			mMasterTableName = "ICS_Transaction"; //GetMasterCode("select master_table_name from ICS_Transaction_Types  where  Voucher_Type ='" & txtTransactionType.Text & "'")
			mDetailsTableName = "ICS_Transaction_Details"; //GetMasterCode("select details_table_name from ICS_Transaction_Types  where  Voucher_Type ='" & txtTransactionType.Text & "'")
			mFromDate = DateTime.Parse(txtFromDate.Text);
			mToDate = DateTime.Parse(txtToDate.Text);

			GetReportDataSource();
			grdTransactionDetails.Enabled = true;
			grdTransactionDetails.Rows.Count = grdTransactionDetails.Rows.Fixed;
			grdTransactionDetails.Cols.Count = 0;
			grdTransactionDetails.Clear(C1.Win.C1FlexGrid.ClearFlags.All, grdTransactionDetails.GetCellRange(grdTransactionDetails.BottomRow, grdTransactionDetails.LeftCol, grdTransactionDetails.TopRow, grdTransactionDetails.RightCol));
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdTransactionDetails.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdTransactionDetails.setDataSource(null);
			Application.DoEvents();
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdTransactionDetails.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdTransactionDetails.setDataSource((msdatasrc.DataSource) rsReportData);
		}

		//UPGRADE_WARNING: (2050) VSFlex8.VSFlexGrid Event grdTransactionDetails.AfterDataRefresh was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdTransactionDetails_AfterDataRefresh()
		{
			SetGridColumns(1);
			grdTransactionDetails_AfterScroll(grdTransactionDetails, new C1.Win.C1FlexGrid.RangeEventArgs(grdTransactionDetails.GetCellRange(0, 0), grdTransactionDetails.GetCellRange(1, 1)));
			lblCommon[22].Caption = " Transaction  Details" + " : " + Conversion.Str(grdTransactionDetails.Rows.Count - 1).Trim() + " ";
		}

		private void grdTransactionDetails_AfterScroll(Object eventSender, C1.Win.C1FlexGrid.RangeEventArgs eventArgs)
		{
			int OldTopRow = eventArgs.OldRange.r1;
			int OldLeftCol = eventArgs.OldRange.c1;
			int NewTopRow = eventArgs.NewRange.r1;
			int NewLeftCol = eventArgs.NewRange.c1;
			int RowCnt = 0;
			int mOldRow = 0;
			int ColCnt = 0;
			object mFormatedValue = null;

			if (OldTopRow != NewTopRow)
			{
				int tempForEndVar = grdTransactionDetails.Rows.Count - 1;
				for (RowCnt = grdTransactionDetails.TopRow; RowCnt <= tempForEndVar; RowCnt++)
				{
					if (grdTransactionDetails.Rows[RowCnt].IsVisible)
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdTransactionDetails.Rows[RowCnt].UserData) != "1")
						{
							grdTransactionDetails.Rows[RowCnt].UserData = "1";

							int tempForEndVar2 = grdTransactionDetails.Cols.Count - 1;
							for (ColCnt = grdTransactionDetails.Cols.Fixed; ColCnt <= tempForEndVar2; ColCnt++)
							{
								if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdTransactionDetails.Cols[ColCnt].UserData).Substring(0, Math.Min(1, ReflectionHelper.GetPrimitiveValue<string>(grdTransactionDetails.Cols[ColCnt].UserData).Length))) != 0)
								{
									//UPGRADE_WARNING: (1068) GetFormatedValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mFormatedValue = ReflectionHelper.GetPrimitiveValue(SystemReports.GetFormatedValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdTransactionDetails.Cols[ColCnt].UserData).Substring(0, Math.Min(1, ReflectionHelper.GetPrimitiveValue<string>(grdTransactionDetails.Cols[ColCnt].UserData).Length)))), (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdTransactionDetails.Cols[ColCnt].UserData).Substring(0, Math.Min(1, ReflectionHelper.GetPrimitiveValue<string>(grdTransactionDetails.Cols[ColCnt].UserData).Length))) == 5) ? grdTransactionDetails.getCellText(RowCnt, ColCnt) : grdTransactionDetails.getCellValue(RowCnt, ColCnt)));
									grdTransactionDetails.setCellText(ReflectionHelper.GetPrimitiveValue<string>(mFormatedValue), RowCnt, ColCnt);
								}
							}
						}
					}
					else
					{
						return;
					}
				}
			}
		}


		private void grdTransactionDetails_AfterSort(Object eventSender, C1.Win.C1FlexGrid.SortColEventArgs eventArgs)
		{
			int Col = eventArgs.Col;
			int Order = (int) eventArgs.Order;
			grdTransactionDetails_AfterScroll(grdTransactionDetails, new C1.Win.C1FlexGrid.RangeEventArgs(grdTransactionDetails.GetCellRange(0, 0), grdTransactionDetails.GetCellRange(1, 1)));
		}

		private void grdTransactionDetails_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			object mFormSearchValue = null;
			int mVoucherType = 0;

			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsReportData.Bookmark was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsReportData.setBookmark(Conversion.Val(Convert.ToString(grdTransactionDetails[grdTransactionDetails.Row, 0])));

			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsDetailsRecordset.MoveFirst();
			mFormSearchValue = 0;
			foreach (DataRow iteration_row in rsDetailsRecordset.Tables[0].Rows)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(iteration_row["entry_id_column"])) == TriState.True)
				{
					mFormSearchValue = rsReportData.Tables[0].Rows[0][mColumnPrefix + Conversion.Str(iteration_row["column_id"]).Trim()];

					//''this column id is fixed and and should not be changed from database.
					mVoucherType = Convert.ToInt32(rsReportData.Tables[0].Rows[0][mColumnPrefix + "8609"]);
					break;
				}
			}

			//Select Case txtTransactionType.Text
			//    Case icsPurchaseVoucher     '101
			//        If GetSystemForm(331000, 2, mFormSearchValue) = True Then
			//                 Else
			//                MsgBox "Error:"
			//        End If
			//    Case icsPurchaseReturnVoucher       '102
			//        If GetSystemForm(332000, 2, mFormSearchValue) = True Then
			//                 Else
			//                MsgBox "Error:"
			//        End If
			//    Case icsReceiptOfGoodsVoucher       '103
			//        If GetSystemForm(333000, 2, mFormSearchValue) = True Then
			//                 Else
			//                MsgBox "Error:"
			//        End If
			//    Case icsSupplierReturnVoucher       '104
			//        If GetSystemForm(334000, 2, mFormSearchValue) = True Then
			//                 Else
			//                MsgBox "Error:"
			//        End If
			//     Case icsPurchaseOrderVoucher       '105
			//        If GetSystemForm(335000, 2, mFormSearchValue) = True Then
			//                 Else
			//                MsgBox "Error:"
			//        End If
			//     Case icsPurchaseQuotationVoucher   '106
			//        If GetSystemForm(336000, 2, mFormSearchValue) = True Then
			//                 Else
			//                MsgBox "Error:"
			//        End If
			//     Case icsSalesVoucher       ' 201
			//        If GetSystemForm(341000, 2, mFormSearchValue) = True Then
			//             Else
			//            MsgBox "Error:"
			//        End If
			//    Case icsSalesReturnVoucher      '202
			//        If GetSystemForm(342000, 2, mFormSearchValue) = True Then
			//                 Else
			//                MsgBox "Error:"
			//        End If
			//     Case icsDeliveryNoteVoucher    '203
			//        If GetSystemForm(343000, 2, mFormSearchValue) = True Then
			//                 Else
			//                MsgBox "Error:"
			//        End If
			//    Case icsStockReturnVoucher      '204
			//        If GetSystemForm(344000, 2, mFormSearchValue) = True Then
			//                 Else
			//                MsgBox "Error:"
			//        End If
			//    Case icsSalesOrder              '205
			//        If GetSystemForm(345000, 2, mFormSearchValue) = True Then
			//                 Else
			//                MsgBox "Error:"
			//        End If
			//    Case icsSalesQuotation          '206
			//        If GetSystemForm(346000, 2, mFormSearchValue) = True Then
			//                 Else
			//                MsgBox "Error:"
			//        End If
			//    Case icsAdvanceSalesBooking     '207
			//        If GetSystemForm(347000, 2, mFormSearchValue) = True Then
			//                 Else
			//                MsgBox "Error:"
			//        End If
			//    Case icsFreeGoodsSales
			//        If GetSystemForm(320000, 2, mFormSearchValue, txtTransactionType.Text) = True Then
			//        Else
			//            MsgBox "Error:"
			//        End If
			//    Case Else
			if (SystemForms.GetSystemForm(320000, 2, mFormSearchValue, mVoucherType))
			{

			}
			else
			{
				MessageBox.Show("Error:", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			//    End Select
		}

		private void txtGroupCode_DropButtonClick(Object Sender, EventArgs e)
		{
			SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtGroupCode");
		}

		private void txtLedgerCode_DropButtonClick(Object Sender, EventArgs e)
		{
			SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtLedgerCode");
		}

		private void txtLedgerCode_KeyDown(Object Sender, System.Windows.Forms.TextBox.KeyDownEventArgs e)
		{
			Keys KeyCode = (Keys) e.KeyCode;
			int Shift = e.Shift;
			if (KeyCode == Keys.Return)
			{
				return;
			}
			else if (KeyCode == Keys.F4)
			{  //F2 key
				SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtLedgerCode");
				//(Me.ActiveControl.Name)
			}
			else if (KeyCode == Keys.Escape)
			{ 
				this.Close();
				return;
			}
		}

		private void txtProductCode_DropButtonClick(Object Sender, EventArgs e)
		{
			SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtProductCode");
		}

		private void txtProductCode_KeyDown(Object Sender, System.Windows.Forms.TextBox.KeyDownEventArgs e)
		{
			Keys KeyCode = (Keys) e.KeyCode;
			int Shift = e.Shift;
			if (KeyCode == Keys.Return)
			{
				return;
			}
			else if (KeyCode == Keys.F4)
			{  //F2 key
				SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtProductCode");
				//(Me.ActiveControl.Name)
			}
			else if (KeyCode == Keys.Escape)
			{ 
				this.Close();
				return;
			}

		}

		private void txtProductCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			object mTempValue = null;

			try
			{

				if (!SystemProcedure2.IsItEmpty(txtProductCode.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_Name" : "a_prod_Name") + " from ICS_Item where Part_no ='" + txtProductCode.Text + "'"));
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mProductDescription = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select Prod_Desc from ICS_Item where Part_no ='" + txtProductCode.Text + "'"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						if (chkBeginWith.CheckState == CheckState.Unchecked)
						{
							txtProductCode.Text = "";
							throw new System.Exception("-9990002");
						}
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDisplayControl[2].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
						lblProductDescription[3].Text = mProductDescription + "";
					}
				}
				else
				{
					txtProductCode.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "txtProductCode_LostFocus", SystemConstants.msg10);
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
					txtProductCode.Focus();
				}
				else
				{
					//
				}
			}
		}




		private void txtTransactionType_DropButtonClick(Object Sender, EventArgs e)
		{
			SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtTransactionType");
		}


		private void txtTransactionType_KeyDown(Object Sender, System.Windows.Forms.TextBox.KeyDownEventArgs e)
		{
			Keys KeyCode = (Keys) e.KeyCode;
			int Shift = e.Shift;
			if (KeyCode == Keys.Return)
			{
				return;
			}
			else if (KeyCode == Keys.F4)
			{  //F2 key
				SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtTransactionType");
				//(Me.ActiveControl.Name)
			}
			else if (KeyCode == Keys.Escape)
			{ 
				this.Close();
				return;
			}

		}

		private void txtTransactionType_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				if (!SystemProcedure2.IsItEmpty(txtTransactionType.Text, SystemVariables.DataType.NumberType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Voucher_Name" : "a_Voucher_Name") + " from ICS_Transaction_Types where Voucher_Type =" + txtTransactionType.Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtTransactionType.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDisplayControl[0].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtTransactionType.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "txtTransactionType_LostFocus", SystemConstants.msg10);
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
					txtTransactionType.Focus();
				}
				else
				{
					//
				}
			}
		}


		public void FindRoutine(string pObjectName)
		{
			//call the search window
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtTransactionType" : 
					txtTransactionType.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(200, "693,694,696")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtTransactionType.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtDisplayControl[0].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						txtTransactionType_Leave(txtTransactionType, new EventArgs());
					} 
					break;
				case "txtProductCode" : 
					txtProductCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001000, "28")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtProductCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						//txtDisplayControl(2).Text = mTempSearchValue(2)
						txtProductCode_Leave(txtProductCode, new EventArgs());
					} 
					break;
				case "txtLedgerCode" : 
					txtLedgerCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtLedgerCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						//txtDisplayControl(2).Text = mTempSearchValue(2)
						txtLedgerCode_Leave(txtLedgerCode, new EventArgs());
					} 
					break;
				case "txtGroupCode" : 
					txtGroupCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2002000, "40")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtGroupCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						//txtDisplayControl(2).Text = mTempSearchValue(2)
						txtGroupCode_Leave(txtGroupCode, new EventArgs());
					} 
					break;
				default:
					return;
			}


		}

		private void txtGroupCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mCurrentBalance = "";

				if (!SystemProcedure2.IsItEmpty(txtGroupCode.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name" : "a_group_name") + " from ICS_Item_group where group_no =" + txtGroupCode.Text));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtGroupCode.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDisplayControl[3].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtGroupCode.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "txtGroupCode_LostFocus", SystemConstants.msg10);
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
					txtGroupCode.Focus();
				}
				else
				{
					//
				}
			}
		}

		private void txtLedgerCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mCurrentBalance = "";

				if (!SystemProcedure2.IsItEmpty(txtLedgerCode.Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Ldgr_Name" : "a_Ldgr_Name") + " from gl_ledger where Ldgr_No ='" + txtLedgerCode.Text + "'"));
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCurrentBalance = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select Current_Bal from gl_ledger where Ldgr_No = '" + txtLedgerCode.Text + "'"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtLedgerCode.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDisplayControl[1].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
						lblCommon[4].Caption = ((StringsHelper.ToDoubleSafe(mCurrentBalance) > 0) ? "Cr   " + StringsHelper.Format(Math.Abs(Double.Parse(mCurrentBalance)), "###,###,###.000") : "Dr   " + StringsHelper.Format(Math.Abs(Double.Parse(mCurrentBalance)), "###,###,###.000")) + " )";
					}
				}
				else
				{
					txtLedgerCode.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "txtLedgerCode_LostFocus", SystemConstants.msg10);
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
					txtLedgerCode.Focus();
				}
				else
				{
					//
				}
			}
		}


		private void grdTransactionDetails_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				try
				{
					switch(KeyCode)
					{
						case 13 : case 32 : 
							grdTransactionDetails_DoubleClick(grdTransactionDetails, new EventArgs()); 
							break;
					}
					return;
				}
				catch (System.Exception excep)
				{
					MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void CloseForm()
		{
			rsDetailsRecordset = null;
			UserAccess = null;
			frmICSProductHistory.DefInstance = null;
			this.Close();
		}

		private void FormatResultGrid()
		{
			//**--temp setting
			grdTransactionDetails.Clear(C1.Win.C1FlexGrid.ClearFlags.All, grdTransactionDetails.GetCellRange(grdTransactionDetails.BottomRow, grdTransactionDetails.LeftCol, grdTransactionDetails.TopRow, grdTransactionDetails.RightCol));
			grdTransactionDetails.Rows.Count = 20;
			//**------------------------
			grdTransactionDetails.Styles.Highlight.BackColor = Color.FromArgb(177, 192, 167);
			grdTransactionDetails.Styles.Highlight.ForeColor = Color.Black;
			//**------------------------
			grdTransactionDetails.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
			grdTransactionDetails.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			grdTransactionDetails.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			grdTransactionDetails.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
			grdTransactionDetails.AutoResize = false;
			grdTransactionDetails.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			grdTransactionDetails.BackColor = Color.FromArgb(255, 255, 255);
			grdTransactionDetails.Styles.Alternate.BackColor = Color.FromArgb(255, 255, 255);
			grdTransactionDetails.Styles.EmptyArea.BackColor = Color.FromArgb(255, 255, 255);
			grdTransactionDetails.Styles.Fixed.BackColor = mFixedHeaderBackColor;
			grdTransactionDetails.Styles.Frozen.BackColor = Color.FromArgb(255, 255, 255);
			grdTransactionDetails.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			grdTransactionDetails.AllowEditing = false;
			grdTransactionDetails.ExtendLastCol = true;
			grdTransactionDetails.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
			grdTransactionDetails.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			//UPGRADE_ISSUE: (2064) VSFlex8L.FillStyleSettings property FillStyleSettings.flexFillSingle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdTransactionDetails.FillStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdTransactionDetails.setFillStyle(UpgradeStubs.VSFlex8L_FillStyleSettings.getflexFillSingle());
			grdTransactionDetails.Cols.Fixed = 0;
			grdTransactionDetails.Rows.Fixed = 1;
			grdTransactionDetails.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdTransactionDetails.FontSize was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdTransactionDetails.setFontSize(9);
			grdTransactionDetails.ForeColor = Color.FromArgb(0, 0, 0);
			grdTransactionDetails.Styles.Fixed.ForeColor = Color.FromArgb(0, 0, 0);
			grdTransactionDetails.Styles.Frozen.ForeColor = Color.FromArgb(0, 0, 0);
			grdTransactionDetails.Styles.Normal.Border.Color = Color.FromArgb(0, 0, 0);
			grdTransactionDetails.Styles.Fixed.Border.Color = Color.FromArgb(0, 0, 0);
			grdTransactionDetails.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			grdTransactionDetails.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			grdTransactionDetails.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			grdTransactionDetails.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			grdTransactionDetails.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
			//    .Height = 1860
			//    .Left = 100
			grdTransactionDetails.Rows.MinSize = 21;
			grdTransactionDetails.ScrollBars = ScrollBars.Both;
			grdTransactionDetails.setScrollTips(false);
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdTransactionDetails.ScrollTrack was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdTransactionDetails.setScrollTrack(true);
			grdTransactionDetails.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
			grdTransactionDetails.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = Color.FromArgb(0, 0, 0);
			grdTransactionDetails.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			grdTransactionDetails.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			grdTransactionDetails.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			//    .Top = 1800
			//    .Width = 8750
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				grdTransactionDetails.RightToLeft = RightToLeft.No;
			}
			else
			{
				grdTransactionDetails.RightToLeft = RightToLeft.Yes;
			}
			grdTransactionDetails.Rows[0].HeightDisplay = 20;
		}

		private void SetGridColumns(int GridType = 0)
		{
			//On Error GoTo eFoundError
			int cnt = 0;

			//'**--set row identifier from recordsets bookmark
			int mReportFixedRows = grdTransactionDetails.Rows.Fixed;
			if (GridType == 1)
			{
				grdTransactionDetails.Cols.Count++;
				grdTransactionDetails.Cols[grdTransactionDetails.Cols.Count - 1].Move(0);
				grdTransactionDetails.Cols[0].Visible = false;
				grdTransactionDetails.Cols.Fixed = 1;

				int tempForEndVar = rsReportData.Tables[0].Rows.Count - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					grdTransactionDetails[cnt + mReportFixedRows, 0] = (cnt + 1).ToString();
				}
				grdTransactionDetails.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear);
			}

			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsDetailsRecordset.MoveFirst();
			cnt = grdTransactionDetails.Rows.Fixed;
			//cnt = 0
			foreach (DataRow iteration_row in rsDetailsRecordset.Tables[0].Rows)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(iteration_row["show_detail"])) == TriState.True)
				{
					if (GridType != 1)
					{
						grdTransactionDetails.Cols.Count = cnt + 1;
					}
					//**--set column header properties
					grdTransactionDetails[mFixedRow, cnt] = Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? iteration_row["l_field_caption"] : iteration_row["a_field_caption"]) + "";
					//**-----------------------------------------------------------------------------------------
					//**--set column level properties
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(iteration_row["apply_format"])) == TriState.True)
					{
						grdTransactionDetails.Cols[cnt].UserData = Conversion.Str(iteration_row["format_text_type"]).Trim() + Conversion.Str(iteration_row["column_id"]).Trim();
					}
					else
					{
						grdTransactionDetails.Cols[cnt].UserData = "0" + Conversion.Str(iteration_row["column_id"]).Trim();
					}
					grdTransactionDetails.Cols[cnt].Visible = true;
					grdTransactionDetails.Cols[cnt].WidthDisplay = Convert.ToInt32(iteration_row["default_width"]) / 15;

					string switchVar = Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? iteration_row["l_field_alignment"] : iteration_row["a_field_alignment"]).ToLower();
					//Select Case LCase(rsDetailsRecordset("field_alignment").Value)
					if (switchVar == ("L").ToLower())
					{
						grdTransactionDetails.Cols[cnt].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter;
					}
					else if (switchVar == ("R").ToLower())
					{ 
						grdTransactionDetails.Cols[cnt].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter;
					}
					else if (switchVar == ("C").ToLower())
					{ 
						grdTransactionDetails.Cols[cnt].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
					}
					//**-----------------------------------------------------------------------------------------
					//**--set columns data types
					string switchVar_2 = Convert.ToString(iteration_row["field_type"]).ToUpper();
					if (switchVar_2 == ("C").ToUpper())
					{
						grdTransactionDetails.Cols[cnt].DataType = typeof(string);
					}
					else if (switchVar_2 == ("N").ToUpper())
					{ 
						grdTransactionDetails.Cols[cnt].DataType = typeof(Double);
					}
					else if (switchVar_2 == ("D").ToUpper())
					{ 
						grdTransactionDetails.Cols[cnt].DataType = typeof(DateTime);
					}
					else if (switchVar_2 == ("L").ToUpper())
					{ 
						grdTransactionDetails.Cols[cnt].DataType = typeof(Boolean);
					}
					//**-----------------------------------------------------------------------------------------
				}
				else
				{
					grdTransactionDetails.Cols.Count = cnt + 1;
					grdTransactionDetails.Cols[cnt].UserData = "0" + Conversion.Str(iteration_row["column_id"]).Trim();
					grdTransactionDetails.Cols[cnt].Visible = false;
				}
				cnt++;
			}
			grdTransactionDetails.setCellAlignment(C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter, mFixedRow, 0, mFixedRow, grdTransactionDetails.Cols.Count - 1);
			grdTransactionDetails.Rows[mFixedRow].HeightDisplay = 20;
			//**-----------------------------------------------------------------------------------------
			//**--check if columns autosizing is enabled
		}

		private void GetReportDataSource()
		{

			//Dim mysql As String

			mColumnsClause = "";

			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsDetailsRecordset.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsDetailsRecordset.setSort("show_detail desc, column_no asc");
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDetailsRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsDetailsRecordset.MoveFirst();
			foreach (DataRow iteration_row in rsDetailsRecordset.Tables[0].Rows)
			{
				if (mColumnsClause != "")
				{
					mColumnsClause = mColumnsClause + ", ";
				}
				if (SystemProcedure2.IsItEmpty(iteration_row["table_id"], SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if ((((TriState) Convert.ToInt32(iteration_row["is_ldgr_no_column"])) == TriState.True && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no"))) == TriState.False) || (((TriState) Convert.ToInt32(iteration_row["is_part_no_column"])) == TriState.True && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_part_no"))) == TriState.False))
					{
						mColumnsClause = mColumnsClause + "cast(" + Convert.ToString(iteration_row["field_id"]).Trim() + " as bigint)" + "";
					}
					else
					{
						mColumnsClause = mColumnsClause + Convert.ToString(iteration_row["field_id"]).Trim();
					}
				}
				else
				{
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if ((((TriState) Convert.ToInt32(iteration_row["is_ldgr_no_column"])) == TriState.True && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no"))) == TriState.False) || (((TriState) Convert.ToInt32(iteration_row["is_part_no_column"])) == TriState.True && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_part_no"))) == TriState.False))
					{
						mColumnsClause = mColumnsClause + "cast(" + Convert.ToString(iteration_row["table_id"]).Trim() + "." + Convert.ToString(iteration_row["field_id"]).Trim() + " as bigint)" + "";
					}
					else
					{
						mColumnsClause = mColumnsClause + Convert.ToString(iteration_row["table_id"]).Trim() + "." + Convert.ToString(iteration_row["field_id"]).Trim();
					}
				}
				mColumnsClause = mColumnsClause + " as " + mColumnPrefix + Conversion.Str(iteration_row["column_id"]).Trim();
				//**------------------------------------------------------------------------------------------------
			}

			if (mColumnsClause != "")
			{
				mysql = "select " + mColumnsClause + "";
				mysql = mysql + " From " + mDetailsTableName + " dt ";
				mysql = mysql + " inner join " + mMasterTableName + "  mt on dt.entry_id = mt.entry_id ";
				mysql = mysql + " inner join ICS_Item_Unit_Details aud on  dt.unit_entry_id = aud.unit_entry_id ";
				mysql = mysql + " inner join ICS_Unit on  aud.alt_unit_cd = ICS_Unit.unit_cd ";
				mysql = mysql + " left outer join gl_ledger on mt.ldgr_cd = gl_ledger.ldgr_cd ";
				mysql = mysql + " left outer join SM_Salesman on mt.sman_cd = SM_Salesman.sman_cd ";
				mysql = mysql + " inner join SM_Location on mt.locat_cd = SM_Location.locat_cd ";
				mysql = mysql + " inner join ICS_Item on dt.prod_cd  = ICS_Item.prod_cd ";
				mysql = mysql + " inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";

				mWhereClause = "1 = 1";
				mWhereClause = mWhereClause + " and mt.voucher_date between '" + DateTimeHelper.ToString(mFromDate) + "' and '" + DateTimeHelper.ToString(mToDate) + "'";

				if (!SystemProcedure2.IsItEmpty(txtProductCode.Text, SystemVariables.DataType.StringType))
				{
					if (chkBeginWith.CheckState == CheckState.Checked)
					{
						mWhereClause = mWhereClause + " and ICS_Item.part_no like '" + txtProductCode.Text + "%'";
					}
					else
					{
						mWhereClause = mWhereClause + " and dt.prod_cd ='" + ReflectionHelper.GetPrimitiveValue<string>(mProductCode) + "'";
					}
				}

				if (!SystemProcedure2.IsItEmpty(txtGroupCode.Text, SystemVariables.DataType.StringType))
				{
					if (chkIncludeSubgroup.CheckState == CheckState.Checked)
					{
						mWhereClause = mWhereClause + " and ICS_Item.Group_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(mGroupCode);
					}
					else
					{
						mWhereClause = mWhereClause + " and ICS_Item.Group_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(mGroupCode);
					}
				}


				if (!SystemProcedure2.IsItEmpty(txtLedgerCode.Text, SystemVariables.DataType.StringType))
				{
					mWhereClause = mWhereClause + " and gl_ledger.ldgr_no ='" + txtLedgerCode.Text + "'";
				}

				if (!SystemProcedure2.IsItEmpty(txtTransactionType.Text, SystemVariables.DataType.NumberType))
				{
					if (chkIncludeParent.CheckState == CheckState.Checked)
					{
						mWhereClause = mWhereClause + " and ivt.parent_type = (select parent_type from ICS_Transaction_Types where voucher_type =" + txtTransactionType.Text + ")";
					}
					else
					{
						mWhereClause = mWhereClause + " and ivt.Voucher_Type =" + txtTransactionType.Text;
					}
				}

				mysql = mysql + " Where " + mWhereClause + " order by mt.voucher_date, mt.voucher_no";

				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsReportData.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (rsReportData.getState() == ConnectionState.Open)
				{
				}

				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsReportData.Tables.Clear();
				adap.Fill(rsReportData);
			}
		}
	}
}