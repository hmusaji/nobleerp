
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmICSSerialNo
		: System.Windows.Forms.Form
	{

		public frmICSSerialNo()
{
InitializeComponent();
} 
 public  void frmICSSerialNo_old()
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


		private void frmICSSerialNo_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private XArrayHelper aVoucherDetails = null;
		private int mMaxArrayCols = 0;
		private int mLineNo = 0;
		private int mParentLineNo = 0;
		private int mTotalSerialNo = 0;
		private int mProductCode = 0;
		private int mLocatCode = 0;
		private int mVoucherType = 0;
		private string mAddOrLess = "";
		private bool mAllowAddSerialNoWhenNotExists = false;

		private DataSet rsParentSerialNo = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private string mTimeStamp = "";

		private const int grdLineNoColumn = 0;
		private const int grdFromColumn = 1;
		private const int grdToColumn = 2;
		private const int grdTotalColumn = 3;

		public int LineNo
		{
			set
			{
				mLineNo = value;
			}
		}


		public int ParentLineNo
		{
			set
			{
				mParentLineNo = value;
			}
		}


		public int TotalSerialNo
		{
			set
			{
				mTotalSerialNo = value;
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

				string mysql = " select Add_Or_Less , allow_add_serial_no_when_not_exists from ICS_Transaction_Types ";
				mysql = mysql + " where voucher_type=" + mVoucherType.ToString();
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
			}
		}


		public DataSet SetVoucherSourceRecordSet
		{
			set
			{
				rsParentSerialNo = value;
			}
		}


		public SystemVariables.SystemFormModes FormMode
		{
			set
			{
				mCurrentFormMode = value;
			}
		}


		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			CloseForm();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			grdVoucherDetails.UpdateData();

			int Cnt = 0;
			int cnt1 = 0;
			string myString = "";

			//'''Check if the total of serial no. matches the total qty entered
			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("check_total_serial_no_entered")))
			{
				if (mTotalSerialNo != Conversion.Val(grdVoucherDetails.Columns[grdTotalColumn].FooterText))
				{
					MessageBox.Show("Total Serial No. does not match the quantity.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					grdVoucherDetails.Col = grdFromColumn;
					grdVoucherDetails.Focus();
					return;
				}
			}

			//''Check for Duplication
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, grdFromColumn), SystemVariables.DataType.StringType) && !SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, grdToColumn), SystemVariables.DataType.StringType))
				{
					int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
					for (cnt1 = 0; cnt1 <= tempForEndVar2; cnt1++)
					{
						if (Cnt != cnt1)
						{
							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
							if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Allow_Alpha_Numeric_Serial_No"))) == TriState.True)
							{
								if (aVoucherDetails.GetValue(Cnt, grdFromColumn) == aVoucherDetails.GetValue(cnt1, grdFromColumn))
								{
									myString = "Duplicate Serial No., Serial No. already used in line No. " + Convert.ToString(aVoucherDetails.GetValue(Cnt, grdLineNoColumn));
									MessageBox.Show(myString, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									grdVoucherDetails.Col = grdFromColumn;
									grdVoucherDetails.Bookmark = cnt1;
									grdVoucherDetails.Focus();
									return;
								}
							}
							else
							{
								if ((Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, grdFromColumn))) >= Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt1, grdFromColumn)))) && (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, grdFromColumn))) <= Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt1, grdToColumn)))) || (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, grdToColumn))) >= Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt1, grdFromColumn)))) && (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, grdToColumn))) <= Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt1, grdToColumn)))))
								{
									myString = "Duplicate Serial No., Serial No. already used in line No. " + Convert.ToString(aVoucherDetails.GetValue(Cnt, grdLineNoColumn));
									MessageBox.Show(myString, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									grdVoucherDetails.Col = grdFromColumn;
									grdVoucherDetails.Bookmark = cnt1;
									grdVoucherDetails.Focus();
									return;
								}
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Invalid Serial No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					grdVoucherDetails.Col = grdFromColumn;
					grdVoucherDetails.Bookmark = Cnt;
					grdVoucherDetails.Focus();
					return;
				}
			}


			//''Check for the availaibility of Serial NO.
			if (!IsSerialNoAvailable())
			{
				return;
			}


			//''Delete the existing lines
			if (rsParentSerialNo.Tables[0].Rows.Count > 0)
			{
				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentSerialNo.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsParentSerialNo.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentSerialNo.MoveFirst();
				rsParentSerialNo.Tables[0].DefaultView.RowFilter = SystemICSProcedure.GetLineNoFilter(mLineNo, mParentLineNo);
				foreach (DataRow iteration_row in rsParentSerialNo.Tables[0].Rows)
				{
					//UPGRADE_ISSUE: (2070) Constant adAffectCurrent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsParentSerialNo.Delete was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsParentSerialNo.Delete(UpgradeStubs.ADODB_AffectEnum.getadAffectCurrent());
				}
				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentSerialNo.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
			}


			int tempForEndVar3 = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar3; Cnt++)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsParentSerialNo.AddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentSerialNo.AddNew(null, null);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentSerialNo.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentSerialNo.Tables[0].Rows[0]["LineNo"].setValue(mLineNo);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentSerialNo.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentSerialNo.Tables[0].Rows[0]["ParentLineNo"].setValue(mParentLineNo);
				//.Fields("ProdCd") = mProductCode
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentSerialNo.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentSerialNo.Tables[0].Rows[0]["FromSerialNo"].setValue(aVoucherDetails.GetValue(Cnt, grdFromColumn));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentSerialNo.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentSerialNo.Tables[0].Rows[0]["ToSerialNo"].setValue(aVoucherDetails.GetValue(Cnt, grdToColumn));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsParentSerialNo.Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentSerialNo.Tables[0].Rows[0]["TotalSerialNo"].setValue(aVoucherDetails.GetValue(Cnt, grdTotalColumn));
				//.Fields("vouchertype") = mVoucherType
				//.Fields("Addorless") = mAddOrLess
				//.Fields("AllowAddSerialNoWhenNotExists") = mAllowAddSerialNoWhenNotExists
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsParentSerialNo.Update was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentSerialNo.Update_Renamed(null, null);
			}
			this.Hide();
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				object mTempSearchValue = null;

				string mysql = "";
				if (this.ActiveControl.Name.ToLower() == ("grdVoucherDetails").ToLower())
				{
					if (KeyCode == 13)
					{
						return;
					}
					else if (KeyCode == 222)
					{  //'for "'"
						KeyCode = 0;
						return;
					}

					//''''Only for the transaction which reduces stock
					if (mAddOrLess == "L")
					{
						if (KeyCode == 115 && (grdVoucherDetails.Col == grdFromColumn || grdVoucherDetails.Col == grdToColumn))
						{
							mysql = " prod.prod_cd =" + mProductCode.ToString();

							if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Check_Serial_No_In_Location")))
							{
								mysql = mysql + " and locat.locat_cd =" + mLocatCode.ToString();
							}

							mysql = mysql + " and psd.status = 1";
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2000408, "1014", mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mTempSearchValue))
							{
								grdVoucherDetails.Columns[grdVoucherDetails.Col].Value = ((Array) mTempSearchValue).GetValue(0);
								grdVoucherDetails_AfterColUpdate(grdVoucherDetails, new C1.Win.C1TrueDBGrid.ColEventArgs());
								Application.DoEvents();
							}
						}
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (Shift == 0 && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Allow_Alpha_Numeric_Serial_No"))) == TriState.False)
					{
						if (grdVoucherDetails.Col == grdFromColumn || grdVoucherDetails.Col == grdToColumn)
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

				//If Me.ActiveControl.Name <> "txtCommonTextBox" Then
				//    Call SystemFormKeyDown(Me, KeyCode, Shift, Me.ActiveControl.Name)
				//Else
				//    Call SystemFormKeyDown(Me, KeyCode, Shift, "txtCommonTextBox#" + Trim(Me.ActiveControl.Index))
				//End If
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{


			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, (0xDCE2DC).ToString(), (0xDCE2DC).ToString());

			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "From ", 1700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);

			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Allow_Alpha_Numeric_Serial_No"))) == TriState.False)
			{
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "To ", 1700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, false, false);
			}
			else
			{
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "To ", 1700, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, false, false);
			}
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Total ", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far);


			aVoucherDetails = new XArrayHelper();
			mMaxArrayCols = 3;
			SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, 0, true);
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);
			grdVoucherDetails.Rebind(true);

			int Cnt = 0;
			if (rsParentSerialNo.Tables[0].Rows.Count > 0)
			{
				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentSerialNo.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsParentSerialNo.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentSerialNo.MoveFirst();
				rsParentSerialNo.Tables[0].DefaultView.RowFilter = SystemICSProcedure.GetLineNoFilter(mLineNo, mParentLineNo);

				foreach (DataRow iteration_row in rsParentSerialNo.Tables[0].Rows)
				{

					SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, Cnt, false);
					aVoucherDetails.SetValue(iteration_row["fromserialno"], Cnt, grdFromColumn);
					aVoucherDetails.SetValue(iteration_row["toserialno"], Cnt, grdToColumn);
					aVoucherDetails.SetValue(iteration_row["totalserialno"], Cnt, grdTotalColumn);

					Cnt++;
				}

				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentSerialNo.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
			}

			grdVoucherDetails.Rebind(true);
			CalculateTotals(0, 0);
			grdVoucherDetails.Refresh();

			AssignGridLineNumbers();

			txtTotalSerialNo.Text = StringsHelper.Format(mTotalSerialNo, "###,###,###");
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				frmICSSerialNo.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			if (ColIndex == grdFromColumn)
			{
				grdVoucherDetails.Columns[grdToColumn].Text = grdVoucherDetails.Columns[grdFromColumn].Text;
			}

			grdVoucherDetails.UpdateData();
			if (ColIndex == grdFromColumn || ColIndex == grdToColumn)
			{
				CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);
				grdVoucherDetails.Refresh();
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
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Allow_Alpha_Numeric_Serial_No"))) == TriState.False)
				{
					if (grdVoucherDetails.Col == grdToColumn)
					{
						if (Conversion.Val(grdVoucherDetails.Columns[grdToColumn].Text) < Conversion.Val(grdVoucherDetails.Columns[grdFromColumn].Text))
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			grdVoucherDetails.Columns[grdLineNoColumn].Text = (grdVoucherDetails.RowCount + 1).ToString();
		}

		private void AssignGridLineNumbers()
		{
			//''''*************************************************************************
			//'''Assign the Grid Line No
			//''''*************************************************************************

			int Cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				aVoucherDetails.SetValue(Cnt + 1, Cnt, grdLineNoColumn);
			}
		}

		private void CalculateTotals(int mRowNumber, int mColNumber)
		{
			object Cnt = null;

			if (aVoucherDetails.GetLength(0) > 0)
			{
				if (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, grdFromColumn))) != 0 && Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, grdToColumn))) != 0)
				{
					aVoucherDetails.SetValue((Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, grdToColumn))) - Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, grdFromColumn)))) + 1, mRowNumber, grdTotalColumn);
				}
				else
				{
					aVoucherDetails.SetValue(0, mRowNumber, grdTotalColumn);
				}
			}

			double mTotalQty = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; ReflectionHelper.GetPrimitiveValue<double>(Cnt) <= tempForEndVar; Cnt = ReflectionHelper.GetPrimitiveValue<double>(Cnt) + 1)
			{
				mTotalQty += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Cnt), grdTotalColumn)));
			}

			if (mTotalQty != 0)
			{
				if (mTotalQty - Math.Floor(mTotalQty) > 0)
				{
					grdVoucherDetails.Columns[grdTotalColumn].FooterText = StringsHelper.Format(mTotalQty, "###,###,###,##0.0##");
				}
				else
				{
					grdVoucherDetails.Columns[grdTotalColumn].FooterText = StringsHelper.Format(mTotalQty, "###,###,###,##0");
				}
			}
			else
			{
				grdVoucherDetails.Columns[grdTotalColumn].FooterText = "";
			}

		}

		public void CloseForm()
		{
			this.Hide();
		}

		public void IRoutine()
		{
			//''''*************************************************************************
			//'''Insert a line in the grid if the tight link is false
			//''''*************************************************************************
			if (this.ActiveControl.Name != "grdVoucherDetails")
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
			}
		}

		public void LRoutine()
		{
			//''''*************************************************************************
			//'''Delete a line in the grid if the tight link is false
			//''''*************************************************************************
			if (this.ActiveControl.Name != "grdVoucherDetails")
			{
				grdVoucherDetails.Focus();
			}

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdVoucherDetails.Delete();
				AssignGridLineNumbers();

				CalculateTotals(0, 1);
				grdVoucherDetails.Rebind(true);
			}
		}

		private bool IsSerialNoAvailable()
		{

			bool result = false;
			int Cnt = 0;

			double mSerialNo = 0;

			string sSerialNo = "";

			object mReturnValue = null;

			string mysql = "";

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Allow_Alpha_Numeric_Serial_No"))) == TriState.True)
				{
					sSerialNo = Convert.ToString(aVoucherDetails.GetValue(Cnt, grdFromColumn));

					mysql = " select locat_cd, status ";
					mysql = mysql + " from ICS_Item_serial_no_details ";
					mysql = mysql + " where prod_cd=" + mProductCode.ToString();
					mysql = mysql + " and serial_no='" + sSerialNo + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						if (mAllowAddSerialNoWhenNotExists == (TriState.False != TriState.False))
						{
							mysql = " Serial No:" + sSerialNo + " does not exists.";
							MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							goto StationExit;
						}
						else
						{
							goto SerialOK;
						}

					}
					else
					{

						if (mAddOrLess == "A")
						{
							if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1)) == 2)
							{ //'If Add and stock not in hand
								goto SerialOK;
							}
							else
							{
								mysql = " select ";
								mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name");
								mysql = mysql + " from SM_Location ";
								mysql = mysql + " where locat_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

								mysql = " Serial No:" + sSerialNo + " already exists in location " + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
								MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								goto StationExit;
							}
						}

						if (mAddOrLess == "L")
						{
							if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(1)) == 1)
							{ //'If Add and stock in hand
								if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Check_Serial_No_In_Location")))
								{
									if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0)) == mLocatCode)
									{
										goto SerialOK;
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
								else
								{
									goto SerialOK;
								}

							}
							else
							{
								mysql = " Serial No:" + sSerialNo + " does not exists.";
								MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								goto StationExit;
							}
						}
					}

				}
				else
				{

					object tempForEndVar2 = aVoucherDetails.GetValue(Cnt, grdToColumn);
					for (mSerialNo = Convert.ToDouble(aVoucherDetails.GetValue(Cnt, grdFromColumn)); mSerialNo <= Convert.ToDouble(tempForEndVar2); mSerialNo++)
					{
						mysql = " select locat_cd, status ";
						mysql = mysql + " from ICS_Item_serial_no_details ";
						mysql = mysql + " where prod_cd=" + mProductCode.ToString();
						mysql = mysql + " and serial_no='" + mSerialNo.ToString() + "'";
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
									if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Check_Serial_No_In_Location")))
									{
										if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0)) == mLocatCode)
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
									else
									{
										goto StationOK;
									}

								}
								else
								{
									mysql = " Serial No:" + mSerialNo.ToString() + " does not exists.";
									MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									goto StationExit;
								}
							}
						}

						StationOK:;
					}

				}
				SerialOK:;
			}


			return true;

			StationExit:
			grdVoucherDetails.Bookmark = Cnt;
			grdVoucherDetails.Focus();

			return result;

		}
	}
}