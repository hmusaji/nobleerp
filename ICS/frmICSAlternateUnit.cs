
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmICSAlternateUnit
		: System.Windows.Forms.Form
	{

		private int mProductCode = 0;

		private const int cGrdUnitEntryId = 0;
		private const int cGrdLineNo = 1;
		private const int cGrdBaseQty = 2;
		private const int cGrdBaseSymbol = 3;
		private const int cGrdEqual = 4;
		private const int cGrdAltQty = 5;
		private const int cGrdAltSymbol = 6;
		private const int cGrdSalesRate = 7;

		private const int conMaxArrayValue = 7;

		public XArrayHelper aAdditionalVoucherDetails = null;
		public string mBaseUnitSymbol = "";
		public frmICSAlternateUnit()
{
InitializeComponent();
} 
 public  void frmICSAlternateUnit_old()
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



		public int ProductCode
		{
			set
			{
				mProductCode = value;
			}
		}


		private void cmdOkCancel_AccessKeyPress(int Index, int KeyAscii)
		{
			cmdOkCancel_ClickEvent(cmdOkCancel[Index], new EventArgs());
		}

		private void cmdOkCancel_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			int cnt = 0;
			grdVoucherDetails.UpdateData();
			int tempForEndVar = aAdditionalVoucherDetails.GetUpperBound(0);
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (cnt > aAdditionalVoucherDetails.GetUpperBound(0))
				{
					break;
				}
				if (SystemProcedure2.IsItEmpty(aAdditionalVoucherDetails.GetValue(cnt, cGrdUnitEntryId), SystemVariables.DataType.NumberType))
				{
					if (SystemProcedure2.IsItEmpty(aAdditionalVoucherDetails.GetValue(cnt, cGrdBaseQty), SystemVariables.DataType.NumberType) || SystemProcedure2.IsItEmpty(aAdditionalVoucherDetails.GetValue(cnt, cGrdAltSymbol), SystemVariables.DataType.StringType))
					{
						//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aAdditionalVoucherDetails.DeleteRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						aAdditionalVoucherDetails.DeleteRows(cnt, 1);
						if (cnt < aAdditionalVoucherDetails.GetLength(0))
						{
							cnt--;
						}
						grdVoucherDetails.Rebind(true);
					}
				}
			}
			AssignGridLineNumbers();
			this.Hide();
		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				grdVoucherDetails.Columns[cGrdBaseSymbol].Text = mBaseUnitSymbol;

				grdVoucherDetails.Col = cGrdBaseQty;
				grdVoucherDetails.Focus();
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 27)
				{
					cmdOkCancel_ClickEvent(cmdOkCancel[0], new EventArgs());
				}

				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}

				if (this.ActiveControl.Name == "grdVoucherDetails")
				{
					if (Shift == 0)
					{
						if (grdVoucherDetails.Col == cGrdBaseQty || grdVoucherDetails.Col == cGrdSalesRate)
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
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			DataSet rsLocalRec = new DataSet();

			try
			{

				//**--define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, "&HE7E2DC", "&HE7E2DC");
				//**--define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "UnitEntryID", 0, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Base Qty", 900, true, ColorTranslator.ToOle(Color.White).ToString(), (0x968F41).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Base Unit", 900, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, " = ", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Alt Qty", 900, true, ColorTranslator.ToOle(Color.White).ToString(), (0x968F41).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Alt Unit", 900, true, ColorTranslator.ToOle(Color.White).ToString(), (0x913DA3).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbAltUnit", true, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Sales Rate", 900, true, ColorTranslator.ToOle(Color.White).ToString(), (0x968F41).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_sales_rate_on_product_unit")));


				//setting voucher details grid properties
				aAdditionalVoucherDetails = new XArrayHelper();
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aAdditionalVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aAdditionalVoucherDetails.Clear();
				aAdditionalVoucherDetails.RedimXArray(new int[]{0, conMaxArrayValue}, new int[]{0, 0});
				aAdditionalVoucherDetails.SetValue(1, 0, cGrdLineNo);
				aAdditionalVoucherDetails.SetValue(" = ", 0, cGrdEqual);
				aAdditionalVoucherDetails.SetValue("1", 0, cGrdBaseQty);
				aAdditionalVoucherDetails.SetValue("1", 0, cGrdAltQty);

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aAdditionalVoucherDetails);

				string mysql = "";
				int cnt = 0;
				if (mProductCode > 0)
				{

					mysql = "SELECT aud.unit_entry_id, ";
					mysql = mysql + " aud.Base_Qty , aud.Alt_Qty, ICS_Unit.Symbol AS AltSymbol, aud.sales_rate ";
					mysql = mysql + " from ICS_Item_Unit_Details aud ";
					mysql = mysql + " INNER JOIN ICS_Unit ON aud.Alt_Unit_Cd = ";
					mysql = mysql + " ICS_Unit.Unit_Cd where aud.prod_cd=" + mProductCode.ToString();
					mysql = mysql + " and aud.base_unit_cd <> aud.alt_unit_cd order by unit_entry_id";
					SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsLocalRec.Tables.Clear();
					adap.Fill(rsLocalRec);

					if (rsLocalRec.Tables[0].Rows.Count != 0)
					{
						foreach (DataRow iteration_row in rsLocalRec.Tables[0].Rows)
						{
							aAdditionalVoucherDetails.RedimXArray(new int[]{cnt, conMaxArrayValue}, new int[]{0, 0});

							aAdditionalVoucherDetails.SetValue(iteration_row["unit_entry_id"], cnt, cGrdUnitEntryId);
							//aAdditionalVoucherDetails(cnt, cGrdLineNo) = Trim(.Fields("line_no").Value - 1)
							aAdditionalVoucherDetails.SetValue(Convert.ToString(iteration_row["Base_qty"]).Trim(), cnt, cGrdBaseQty);
							aAdditionalVoucherDetails.SetValue(mBaseUnitSymbol, cnt, cGrdBaseSymbol);
							aAdditionalVoucherDetails.SetValue(" = ", cnt, cGrdEqual);
							aAdditionalVoucherDetails.SetValue(Convert.ToString(iteration_row["alt_qty"]).Trim(), cnt, cGrdAltQty);
							aAdditionalVoucherDetails.SetValue(Convert.ToString(iteration_row["altsymbol"]).Trim(), cnt, cGrdAltSymbol);
							aAdditionalVoucherDetails.SetValue(iteration_row["sales_rate"], cnt, cGrdSalesRate);
							cnt++;
						}
					}
				}

				SystemGrid.DefineSystemGridCombo(cmbAltUnit);

				mysql = "select symbol, " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_unit_name," : "a_unit_name,");
				mysql = mysql + " unit_cd from ICS_Unit ";
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLocalRec.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLocalRec.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLocalRec.Tables.Clear();
				adap_2.Fill(rsLocalRec);
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbAltUnit.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbAltUnit.setDataSource((msdatasrc.DataSource) rsLocalRec);
				cmbAltUnit.DisplayColumns[0].Width = 83;
				cmbAltUnit.DisplayColumns[1].Width = 67;
				cmbAltUnit.DisplayColumns[2].Visible = false;
				cmbAltUnit.Width = 160;

				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
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
				//grdVoucherDetails.Update
				aAdditionalVoucherDetails = null;
				frmICSAlternateUnit.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			grdVoucherDetails.Columns[cGrdLineNo].Text = (grdVoucherDetails.RowCount + 1).ToString();
			grdVoucherDetails.Columns[cGrdBaseSymbol].Text = mBaseUnitSymbol;
			grdVoucherDetails.Columns[cGrdEqual].Text = " = ";
			grdVoucherDetails.Columns[cGrdAltQty].Text = "1";
		}

		public void AssignGridLineNumbers()
		{
			int mCnt = 0;
			int tempForEndVar = aAdditionalVoucherDetails.GetLength(0) - 1;
			for (mCnt = 0; mCnt <= tempForEndVar; mCnt++)
			{
				aAdditionalVoucherDetails.SetValue(mCnt + 1, mCnt, cGrdLineNo);
			}
			grdVoucherDetails.Rebind(true);
		}
	}
}