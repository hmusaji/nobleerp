
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmICSLandedCost
		: System.Windows.Forms.Form
	{

		public frmICSLandedCost()
{
InitializeComponent();
} 
 public  void frmICSLandedCost_old()
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


		private void frmICSLandedCost_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private DataSet rsLedgerList = null;
		private DataSet rsCurrList = null;
		private DataSet rsCCList = null;

		private const string mDisableColumnBackColor = "&HD5D5D5";
		private const int mMaxExpensesArray = 9;

		//define the expenses grid col no.
		private const int cLN = 0;
		private const int cLdgrCode = 1;
		private const int cLdgrName = 2;
		private const int cCostCode = 3;
		private const int cCurr = 4;
		private const int cRate = 5;
		private const int cFCAmt = 6;
		private const int cLCAmt = 7;
		private const int cConsignmentCd = 8;
		private const int cComments = 9;


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


			//grdVoucherDetails.FetchRowStyle
			double mExpensesAmt = Conversion.Val(StringsHelper.Format(grdExpensesDetails.Columns[cLCAmt].FooterText, "###########0.0##"));

			double mExpenseAllocatedAmt = 0;

			if (!SystemProcedure2.IsItEmpty(mExpensesAmt, SystemVariables.DataType.NumberType))
			{
				if (optAllocation[0].Checked == (TriState.True != TriState.False))
				{
					//Amount wise allocation
					int tempForEndVar = (aVoucherDetails.GetLength(0) - 1);
					for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
					{
						if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdProductAmountColumn), SystemVariables.DataType.NumberType))
						{
							aVoucherDetails.SetValue((Conversion.Val(StringsHelper.Format(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdProductAmountColumn), "###############.######")) / Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[SystemICSConstants.grdProductAmountColumn].FooterText, "###############.######"))) * mExpensesAmt, Cnt, SystemICSConstants.grdExpensesColumn);
							aVoucherDetails.SetValue(StringsHelper.Format(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdExpensesColumn), "###############.000"), Cnt, SystemICSConstants.grdExpensesColumn);
							mExpenseAllocatedAmt += Convert.ToDouble(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdExpensesColumn));
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
							mExpenseAllocatedAmt += Convert.ToDouble(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdExpensesColumn));
						}
						else
						{
							aVoucherDetails.SetValue(0, Cnt, SystemICSConstants.grdExpensesColumn);
						}
					}
				}

				if (aVoucherDetails.GetLength(0) > 0)
				{
					grdVoucherDetails.Columns[SystemICSConstants.grdExpensesColumn].Caption = "Exp (in " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select symbol from gl_currency where curr_cd = 1")).Trim() + ")";
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[SystemICSConstants.grdExpensesColumn].Visible = true;
					grdVoucherDetails.Columns[SystemICSConstants.grdExpensesColumn].FooterText = StringsHelper.Format(mExpenseAllocatedAmt, "###,###,###,###,###.000");
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[SystemICSConstants.grdExpensesColumn].Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center;
				}
				grdVoucherDetails.Rebind(true);
			}
		}

		private void cmdadd_Click(Object eventSender, EventArgs eventArgs)
		{
			object mReturnValue = null;
			string mysql = "";
			object mConsignmentCd = null;
			SqlDataReader rsTempRec = null;
			int i = 0;
			int Cnt = 0;
			if (txtConsignmentCd.Text != "")
			{
				mysql = "select consignment_cd from gl_consignment where consignment_no = '" + txtConsignmentCd.Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Consignment Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtConsignmentCd.Text = "";
					txtConsignmentCd.Focus();
					return;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mConsignmentCd = ReflectionHelper.GetPrimitiveValue(mReturnValue);
				}

				mysql = "select t.*, l.ldgr_no, l.l_ldgr_name, l.a_ldgr_name, c.symbol, cons.consignment_no ";
				mysql = mysql + " , gcc.cost_no ";
				mysql = mysql + " from gl_accnt_trans_details t ";
				mysql = mysql + " inner join GL_Ledger l on t.ldgr_cd = l.ldgr_cd ";
				mysql = mysql + " inner join gl_currency c on t.curr_cd = c.curr_cd ";
				mysql = mysql + " inner join gl_consignment cons on t.consignment_cd = cons.consignment_cd ";
				mysql = mysql + " inner join gl_cost_centers gcc on t.cost_cd = gcc.cost_cd ";
				mysql = mysql + " where t.consignment_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mConsignmentCd);


				Cnt = aExpensesDetails.GetLength(0); // - 1
				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsTempRec = sqlCommand.ExecuteReader();
				rsTempRec.Read();
				do 
				{

					aExpensesDetails.RedimXArray(new int[]{Cnt, mMaxExpensesArray}, new int[]{0, 0});

					aExpensesDetails.SetValue(Cnt + 1, Cnt, cLN);

					aExpensesDetails.SetValue(rsTempRec["ldgr_no"], Cnt, cLdgrCode);
					aExpensesDetails.SetValue((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsTempRec["l_ldgr_name"] : rsTempRec["a_ldgr_name"], Cnt, cLdgrName);
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdExpensesDetails.Splits[0].DisplayColumns[cCostCode].Visible)
					{
						aExpensesDetails.SetValue(rsTempRec["cost_no"], Cnt, cCostCode);
					}

					aExpensesDetails.SetValue(rsTempRec["symbol"], Cnt, cCurr);
					if (Convert.ToDouble(rsTempRec["Curr_Cd"]) == SystemGLConstants.gDefaultCurrencyCd)
					{
						aExpensesDetails.SetValue(rsTempRec["lc_amount"], Cnt, cLCAmt);
					}
					else
					{
						aExpensesDetails.SetValue(rsTempRec["exchange_rate"], Cnt, cRate);
						aExpensesDetails.SetValue(rsTempRec["fc_amount"], Cnt, cFCAmt);
						aExpensesDetails.SetValue(rsTempRec["lc_amount"], Cnt, cLCAmt);
					}

					aExpensesDetails.SetValue(Convert.ToString(rsTempRec["consignment_no"]) + "", Cnt, cConsignmentCd);
					aExpensesDetails.SetValue(Convert.ToString(rsTempRec["comments"]) + "", Cnt, cComments);


					Cnt++;
				}
				while(rsTempRec.Read());

				grdExpensesDetails.UpdateData();
				grdExpensesDetails.Rebind(true);

				CalculateTotals(0, 0);
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
					if (Shift == 2 && (KeyCode == 67 || KeyCode == 86 || KeyCode == 88))
					{
						return;
					}

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
				//.ShowInsertLineButton = True
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				mysql = " select voucher_type ";
				mysql = mysql + "," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name" : "a_voucher_name") + " voucher_name ";
				mysql = mysql + " from ICS_Transaction_Types ";
				//mysql = mysql & " where parent_type=101 and affect_gls=1 and affect_cost=1"
				mysql = mysql + " where parent_type=103 ";
				rsTempRec = new DataSet();
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsTempRec.Tables.Clear();
				adap.Fill(rsTempRec);
				if (rsTempRec.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text = Convert.ToString(rsTempRec.Tables[0].Rows[0]["voucher_type"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtDisplayLabel[1].Text = Convert.ToString(rsTempRec.Tables[0].Rows[0]["voucher_name"]);
					if (rsTempRec.Tables[0].Rows.Count > 1)
					{
						//MsgBox "Invalid voucher setting, contact administrator", vbInformation
						//Unload Me
						//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("ics_landed_cost_parent_voucher_type"));
						txtCommonTextBox_Leave(txtCommonTextBox[SystemICSConstants.tcImportVoucherType], new EventArgs());
					}
				}
				rsTempRec = null;


				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsVoucherTypes.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsVoucherTypes.MoveFirst();
				//rsVoucherTypes.Filter = "parent_type=103"
				SystemVariables.rsVoucherTypes.Tables[0].DefaultView.RowFilter = "voucher_type=" + txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text;

				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, "&HB5BDB3", "&HB5BDB3");
				//define voucher grid columns
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Line_No_In_Details"]));
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Flex", 1300, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Activity", 1500, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Barcode", 1300, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("barcode")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Barcode_In_Details"])) != 0, false, false, true, false, 20);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Style No", 1500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Supplier_Barcode"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Item Id", 1500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Part_No_In_Details"]), false, false, false, false, 100, "", "", false, "", 0, true);

				// Date:18/10/2007 To Add Two New Buttons
				//-------------------------------------------------------
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "PreText", 1300, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false, false, false, true, true, -1);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "PostText", 1300, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false, false, false, true, true, -1);
				//-------------------------------------------------------

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Item Name", 2700, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, false, false, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Name_In_Details"]), false, false, false, false, 100, "", "", false, "", 0, true);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Batch", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "cmbMastersList", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Item_Batch")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Production_Batch"])) != 0, false, false, false, false, 100, "", "", false, "", 0, true);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Expiry Date", 1300, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Expiry_In_Details"]), false, false, false, false, 100, "", "", false, "", 0, false);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Package", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Package"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Package"]), 12);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Pack Qty", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Package"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Package"]), 12);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Unit", 500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_unit_in_details"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "W/H", 450, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Location_In_Details"]));
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Parent Qty", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Pack Qty", 900, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Pack_Qty"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Pack_Qty"]), 12);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Loose Qty", 900, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Pack_Qty"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Pack_Qty"]), 12);

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
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Task", 500, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("project_costing")) & Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Activity_Task_In_Details"])) != 0);

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
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Dented", 600, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, false);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "S.N.", 500, false, ColorTranslator.ToOle(Color.White).ToString(), SystemConstants.gDisableColumnBackColor, C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Print_sr_no"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 800, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Remarks_In_Details"]), false, false, true, false, 20);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Item Type", 0, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Parent Line", 0, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsVoucherTypes.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();

				Application.DoEvents();
				grdVoucherDetails.Visible = true;

				//With txtTempDate
				SystemGrid.DefineSystemVoucherGrid(grdExpensesDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2.2f, 1.4f, "&HDCE2DC", "&HDCE2DC");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Ledger Code", 1250, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMasterList");
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Ledger Name", 3200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, " Total  ", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMasterList");
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Cost Code", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbMasterList", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")));
				//Call DefineSystemVoucherGridColumn(grdExpensesDetails, "Curr.", 430, False, gDisableColumnBackColor, , dbgLeft, False)
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Curr.", 650, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("advance_multiple_currency")), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMasterList", true);
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Exchange Rate", 1100, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Amount In FC", 1100, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Amount In LC", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, true, false, true);
				//'added by Moiz Hakimi. Date:24-mar-2008
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Consignment No.", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Ledger_branch")));
				//'
				SystemGrid.DefineSystemVoucherGridColumn(grdExpensesDetails, "Remarks", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 200);


				SystemGrid.DefineSystemGridCombo(cmbMasterList);
				cmbMasterList.Width = 267;
				cmbMasterList.Height = 133;

				//setting voucher details grid properties
				aExpensesDetails = new XArrayHelper();
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aExpensesDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aExpensesDetails.Clear();
				aExpensesDetails.RedimXArray(new int[]{-1, mMaxExpensesArray}, new int[]{0, 0});
				//aExpensesDetails(0, 0) = 1
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdExpensesDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdExpensesDetails.setArray(aExpensesDetails);

				//setting voucher details grid properties
				aVoucherDetails = new XArrayHelper();
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
				aVoucherDetails.RedimXArray(new int[]{-1, SystemICSConstants.grdArrayUbound}, new int[]{0, 0});
				//aVoucherDetails(0, 0) = 1
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);


				//Set rsLedgerList = New ADODB.Recordset
				//rsLedgerList.CursorLocation = adUseClient
				//
				//Set rsCurrList = New ADODB.Recordset
				//rsCurrList.CursorLocation = adUseClient
				SetList();

				CalculateTotals(0, 0);
				grdExpensesDetails.Rebind(true);

				txtVoucherDate.Value = DateTime.Today;
				FirstFocusObject = txtCommonTextBox[SystemICSConstants.tcImportLocationCode];

				SetDefaultValues();
				SystemProcedure.SetLabelCaption(this);
				clsFlip oFlipThisForm = null;
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
				{
					oFlipThisForm = new clsFlip();

					oFlipThisForm.SwapMe(this);
				}

				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Ledger_branch")))
				{
					txtConsignmentCd.Visible = false;
					lblCommonLabel[8].Visible = false;
					cmdAdd.Visible = false;
				}
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
			grdExpensesDetails.Width = this.Width - 33;
			grdVoucherDetails.Width = this.Width - 33;
			grdVoucherDetails.Height = this.Height - 400;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;

				aExpensesDetails = null;
				//Set rsDrList = Nothing
				rsLedgerList = null;
				rsCCList = null;
				rsCurrList = null;

				oThisFormToolBar = null;
				frmICSLandedCost.DefInstance = null;
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
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name" : "a_voucher_name"); 
						mysql = mysql + ",'' from ICS_Transaction_Types where voucher_type = " + txtCommonTextBox[Index].Text; 
						 
						mSetValueIndex = 1; 
						//    Case tcImportVoucherNo 
						//        mySQL = " select voucher_no from ICS_Transaction mt " 
						//        mySQL = mySQL & " inner join SM_Location on mt.locat_cd = SM_Location.locat_cd " 
						//        mySQL = mySQL & " where mt.voucher_type=" & txtCommonTextBox(tcImportVoucherType).Text 
						//        mySQL = mySQL & " and mt.expenses_amt = 0 " 
						//        'mySql = mySql & " and mt.status = 2 " 
						//        mySQL = mySQL & " and mt.posted_gl = 0 " 
						//        mySQL = mySQL & " and mt.posted_gl_expense = 0 " 
						//        mySQL = mySQL & " and mt.voucher_no = " & txtCommonTextBox(tcImportVoucherNo).Text 
						//        mySQL = mySQL & " and SM_Location.locat_no = " & txtCommonTextBox(tcImportLocationCode).Text 
						// 
						//        mSetValueIndex = -2 
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
								txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Tag = "";
								txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Enabled = false;
							}
							else
							{
								txtDisplayLabel[mSetValueIndex].Text = "";
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
									txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Text = "";
									txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Tag = "";
								}
							}
							else
							{
								//UPGRADE_WARNING: (1068) mTempReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDisplayLabel[mSetValueIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempReturnValue).GetValue(0));
							}
						}
					}
					else
					{
						if (Index == SystemICSConstants.tcImportLocationCode)
						{
							txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Enabled = false;
						}
					}
				}
				else if (mSetValueIndex == -1)
				{ 
					//''Nothing
					//ElseIf mSetValueIndex = -2 Then
					//    If Not IsItEmpty(txtCommonTextBox(Index).Text, NumberType) Then
					//        mTempReturnValue = GetMasterCode(mySQL)
					//        If Not IsNull(mTempReturnValue) Then
					//            If GetLinkedVoucherDetails() = False Then
					//                Err.Raise -9990002
					//            Else
					//                txtCommonTextBox(tcImportLocationCode).Enabled = False
					//                txtCommonTextBox(tcImportVoucherNo).Enabled = False
					//                'Call TextBoxLostFocus(pForm, tcLedgerCode, pclsICSTransaction)
					//            End If
					//        Else
					//            Err.Raise -9990002
					//        End If
					//    End If
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
			mysql = mysql + " from ics_landed_cost ";
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
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, Convert.ToInt32(rsLocalRec["status"]), CurrentFormMode, "Landed Cost", "Transaction");
				//''''*************************************************************************

				txtCommonTextBox[SystemICSConstants.tcVoucherNo].Text = Convert.ToString(rsLocalRec["voucher_no"]);
				txtVoucherDate.Value = rsLocalRec["voucher_date"];
				txtCommonTextBox[SystemICSConstants.tcReferenceNo].Text = Convert.ToString(rsLocalRec["reference_no"]) + "";
				txtCommonTextBox[SystemICSConstants.tcComments].Text = Convert.ToString(rsLocalRec["comments"]) + "";

				GetVoucherExpensesDetails(Convert.ToInt32(rsLocalRec["entry_id"]));

				GetParentVoucherDetails(Convert.ToInt32(rsLocalRec["linked_voucher_type"]), Convert.ToInt32(rsLocalRec["linked_entry_id"]));
			}
		}

		private void txtConsignmentCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtConsignmentCd");

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
			string mObjectName = "";
			int mIndex = 0;




			if (pObjectName.StartsWith("txtCommonTextBox"))
			{
				if ((pObjectName.IndexOf('#') + 1) == 0)
				{
					return;
				}

				mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
				mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));
			}

			if (mObjectName == "txtCommonTextBox")
			{
				txtCommonTextBox[mIndex].Text = "";
				switch(mIndex)
				{
					case SystemICSConstants.tcImportVoucherType : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(200, "693", "parent_type = 103")); 
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
							//mySql = mySql & " and mt.status = 2 "
							mysql = mysql + " and mt.posted_gl = 0 ";
							mysql = mysql + " and mt.posted_gl_expense = 0 ";
							mysql = mysql + " and mloc.locat_no = " + txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text;
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(4000107, "1035,1036", mysql));
						} 
						break;
					default:
						return;
				}
			}

			if (pObjectName == "txtConsignmentCd")
			{
				txtConsignmentCd.Text = "";
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1009100, "2372"));
			}


			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				if (mObjectName == "txtCommonTextBox")
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[mIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					if (mIndex == SystemICSConstants.tcImportVoucherNo)
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtReferenceNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(2));

						txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0));
						GetLinkedVoucherDetails();
						txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Enabled = false;
						txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Enabled = false;

					}
					txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
				}

				if (pObjectName == "txtConsignmentCd")
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtConsignmentCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				}
			}
		}

		private bool GetLinkedVoucherDetails()
		{
			SqlDataReader rsLocalRec = null;
			int Cnt = 0;
			string mysql = "";

			//Dim mTempValue As Variant
			//Dim mHeaderLocatCode As Long
			//Dim mImportLocatCode As Long

			//if  import location code or import voucher no is empty then exit sub
			if (!(SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text, SystemVariables.DataType.NumberType) || SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Text, SystemVariables.DataType.NumberType) || SystemProcedure2.IsItEmpty(Convert.ToString(txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Tag), SystemVariables.DataType.NumberType)))
			{

				//
				//'Get the Header Location Code
				//If Not IsItEmpty(txtCommonTextBox(tcImportLocationCode).Text, NumberType) Then
				//    mySQL = "select locat_cd from SM_Location where locat_no ="
				//    mySQL = mySQL & txtCommonTextBox(tcImportLocationCode).Text
				//
				//    mTempValue = GetMasterCode(mySQL)
				//    If Not IsNull(mTempValue) Then
				//        mImportLocatCode = mTempValue
				//    Else
				//        GoTo mend
				//    End If
				//End If


				mysql = " select ldgr_no ";
				mysql = mysql + " ," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name") + " as ldgr_name ";
				mysql = mysql + " , mt.voucher_date, mt.reference_no, mt.time_stamp ";
				mysql = mysql + " , mt.exchange_rate, mt.Comments ";
				mysql = mysql + " , gl_currency.symbol as curr_symbol";
				mysql = mysql + " , dt.Entry_Id, dt.Line_No, dt.Prod_Cd, dt.Unit_Entry_Id ";
				mysql = mysql + " , dt.Project_cd, dt.Exchange_Rate, dt.Prod_Name, dt.Reference_No ";
				mysql = mysql + " , dt.Qty, dt.Base_Qty, dt.Processed_Qty , dt.Balance_Qty";
				mysql = mysql + " , ICS_Item.serialized  , ICS_Item.item_type_cd ";
				mysql = mysql + " , (aud.alt_qty * dt.Balance_Qty) / aud.base_qty as Alt_Unit_balance_qty ";
				mysql = mysql + " , dt.FC_Rate, dt.FC_Prod_Dis, dt.FC_Amount, dt.Prod_Exp_Amt ";
				mysql = mysql + " , dt.Dis_In_Percent, dt.promo_type, dt.Status , ICS_Item.part_no ";
				mysql = mysql + " , ICS_Unit.symbol, ICS_Item.supplier_part_no ";
				mysql = mysql + " , SM_Location.locat_no locat_no ";
				mysql = mysql + " from ICS_Transaction_Details dt ";
				mysql = mysql + " inner join ICS_Item on dt.prod_cd = ICS_Item.prod_cd ";
				mysql = mysql + " inner join ICS_Item_Types it on it.item_type_cd = ICS_Item.item_type_cd ";
				mysql = mysql + " inner join ICS_Transaction mt on mt.entry_id = dt.entry_id  ";
				mysql = mysql + " inner join ICS_Item_Unit_Details aud on dt.unit_entry_id = aud.unit_entry_id ";
				mysql = mysql + " inner join ICS_Unit on ICS_Unit.unit_cd = aud.alt_unit_cd ";
				mysql = mysql + " inner join SM_Location on mt.locat_cd = SM_Location.locat_cd ";
				mysql = mysql + " left join gl_ledger on mt.ldgr_cd = gl_ledger.ldgr_cd  ";
				mysql = mysql + " left join gl_currency on mt.curr_cd = gl_currency.curr_cd  ";
				mysql = mysql + " where mt.entry_id = " + Convert.ToString(txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Tag);
				//mySQL = mySQL & " where mt.voucher_no = " & txtCommonTextBox(tcImportVoucherNo).Text
				//mySQL = mySQL & " and mt.locat_cd = " & Str(mImportLocatCode)
				//mySQL = mySQL & " and mt.voucher_type = " & txtCommonTextBox(tcImportVoucherType).Text
				mysql = mysql + " and mt.expenses_amt = 0 ";
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

					txtCommonTextBox[SystemICSConstants.tcCurrencySymbol].Text = Convert.ToString(rsLocalRec["curr_symbol"]);

					mParentVoucherTimeStamp = Convert.ToString(rsLocalRec["time_stamp"]);
					txtExchangeRate.Value = rsLocalRec["exchange_rate"];
					txtCommonTextBox[SystemICSConstants.tcComments].Text = Convert.ToString(rsLocalRec["Comments"]);



					//Set the form caption and Get the Voucher Status
					SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, "Landed Cost", "Transaction");
					//''''*************************************************************************

					do 
					{
						SystemGrid.DefineVoucherArray(aVoucherDetails, SystemICSConstants.grdArrayUbound, Cnt, false);

						//Get the details information into the grid
						aVoucherDetails.SetValue(Cnt + 1, Cnt, SystemICSConstants.grdLineNoColumn);
						aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["supplier_part_no"]).Trim(), Cnt, SystemICSConstants.grdSupplierBarcodeColumn);
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
					grdVoucherDetails.Refresh();

					rsLocalRec.Close();

					return true;
				}
			}

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
			double mCashAmt = 0;

			int tempForEndVar = aExpensesDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				if (SystemProcedure2.IsItEmpty(aExpensesDetails.GetValue(Cnt, cLCAmt), SystemVariables.DataType.NumberType))
				{
					aExpensesDetails.SetValue("", Cnt, cLCAmt);
				}

				aExpensesDetails.SetValue(StringsHelper.Format(aExpensesDetails.GetValue(Cnt, cLCAmt), "##,###,###.000"), Cnt, cLCAmt);
				mCashAmt += Conversion.Val(StringsHelper.Format(aExpensesDetails.GetValue(Cnt, cLCAmt), "###############.######"));
			}

			if (!SystemProcedure2.IsItEmpty(mCashAmt, SystemVariables.DataType.NumberType))
			{
				grdExpensesDetails.Columns[cLCAmt].FooterText = StringsHelper.Format(mCashAmt, "###,###,###.000");
			}
			else
			{
				grdExpensesDetails.Columns[cLCAmt].FooterText = "";
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMasterList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMasterList_DataSourceChanged()
		{
			int Cnt = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_3 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_4 = null;
			switch(grdExpensesDetails.Col)
			{
				case cLdgrCode : case cLdgrName : 
					 
					if (grdExpensesDetails.Col == cLdgrCode)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMasterList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMasterList.setListField("ldgr_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsLedgerList.setSort("ldgr_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMasterList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMasterList.setListField("ldgr_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsLedgerList.setSort("ldgr_name");
					} 
					 
					cmbMasterList.Width = 0; 
					int tempForEndVar = cmbMasterList.Columns.Count - 1; 
					for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMasterList.Splits[0].DisplayColumns[Cnt];
						if (Cnt < 2)
						{
							if (Cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdExpensesDetails.Col == cLdgrCode) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdExpensesDetails.Splits[0].DisplayColumns[cLdgrCode].Width;
							}
							else if (Cnt == 1)
							{ 
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdExpensesDetails.Col == cLdgrCode) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdExpensesDetails.Splits[0].DisplayColumns[cLdgrName].Width;
							}
							withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							withVar.Visible = true;
							cmbMasterList.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					cmbMasterList.Width += 17; 
					cmbMasterList.Height = 167; 
					 
					break;
				case cCostCode : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMasterList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMasterList.setListField("cost_no"); 
					 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar_2 = cmbMasterList.Splits[0].DisplayColumns[0]; 
					withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar_2.Width = grdExpensesDetails.Splits[0].DisplayColumns[cCostCode].Width; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar_3 = cmbMasterList.Splits[0].DisplayColumns[2]; 
					withVar_3.Visible = false; 
					cmbMasterList.Width = 267; 
					break;
				case cCurr : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMasterList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMasterList.setListField("symbol"); 
					 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar_4 = cmbMasterList.Splits[0].DisplayColumns[0]; 
					withVar_4.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					withVar_4.Width = grdExpensesDetails.Splits[0].DisplayColumns[cCurr].Width; 
					//        With cmbMasterList.Columns(2) 
					//            .Visible = False 
					//        End With 
					cmbMasterList.Width = 267; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMasterList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMasterList_RowChange()
		{
			int mReturnValue = 0;

			if (grdExpensesDetails.Col == cLdgrCode || grdExpensesDetails.Col == cLdgrName)
			{
				grdExpensesDetails.Columns[cCurr].Value = cmbMasterList.Columns[2].Value;

				if (ReflectionHelper.GetPrimitiveValue<double>(cmbMasterList.Columns[4].Value) > 0)
				{
					grdExpensesDetails.Columns[cCostCode].Value = cmbMasterList.Columns[4].Value;
				}
				else
				{
					grdExpensesDetails.Columns[cCostCode].Value = "";
				}

				if (grdExpensesDetails.Col == cLdgrCode)
				{
					grdExpensesDetails.Columns[cLdgrName].Value = cmbMasterList.Columns[1].Value;
				}
				else if (grdExpensesDetails.Col == cLdgrName)
				{ 
					grdExpensesDetails.Columns[cLdgrCode].Value = cmbMasterList.Columns[0].Value;
				}

				mReturnValue = CheckCurrency(cmbMasterList.Columns[2].Value);
				if (mReturnValue == 1)
				{
					grdExpensesDetails.Columns[cRate].Value = "";
					grdExpensesDetails.Columns[cFCAmt].Value = "";

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cRate].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cFCAmt].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cLCAmt].AllowFocus = true;

				}
				else if (mReturnValue == 2)
				{ 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cRate].AllowFocus = true;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cFCAmt].AllowFocus = true;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cLCAmt].AllowFocus = false;
				}
				else if (mReturnValue == 0)
				{ 

					grdExpensesDetails.Columns[cRate].Value = "";
					grdExpensesDetails.Columns[cFCAmt].Value = "";
					grdExpensesDetails.Columns[cLCAmt].Value = "";

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cRate].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cFCAmt].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cLCAmt].AllowFocus = false;
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
				case cLCAmt : 
					CalculateTotals(mCurrentRow, ColIndex); 
					break;
				case cRate : case cFCAmt : 
					grdExpensesDetails.Columns[cLCAmt].Text = (Conversion.Val(StringsHelper.Format(grdExpensesDetails.Columns[cRate].Text, "#############.##########")) * Conversion.Val(StringsHelper.Format(grdExpensesDetails.Columns[cFCAmt].Text, "#############.000"))).ToString(); 
					grdExpensesDetails.UpdateData(); 
					CalculateTotals(mCurrentRow, cLCAmt); 
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
			//If ColIndex = cFCAmt Or ColIndex = cRate Or ColIndex = cLCAmt Then
			//    mReturnvalue = CheckCurrency(2, grdExpensesDetails.Columns(cLdgrCode).Value)
			//    If mReturnvalue = 1 Then
			//        If ColIndex = cFCAmt Or ColIndex = cRate Then
			//            grdExpensesDetails.Columns(cRate).Value = ""
			//            grdExpensesDetails.Columns(cFCAmt).Value = ""
			//            Cancel = True
			//        Else
			//            Cancel = False
			//        End If
			//    ElseIf mReturnvalue = 2 Then
			//        If ColIndex = cFCAmt Or ColIndex = cRate Then
			//            Cancel = False
			//        Else
			//            Cancel = True
			//        End If
			//    ElseIf mReturnvalue = 0 Then
			//        grdExpensesDetails.Columns(cRate).Value = ""
			//        grdExpensesDetails.Columns(cFCAmt).Value = ""
			//        grdExpensesDetails.Columns(cLCAmt).Value = ""
			//        Cancel = True
			//    End If
			//End If
			eventArgs.Cancel = Cancel != 0;
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdExpensesDetails.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdExpensesDetails_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			int mReturnValue = 0;

			//If Col = cDrRate Or Col = cDrFCAmt Or Col = cDrLCAmt Then
			//    mReturnValue = CheckCurrency(1, grdExpensesDetails.Columns(cDrLdgrCode).CellValue(Bookmark))
			//    If mReturnValue = 1 Then
			//        If Col = cDrRate Or Col = cDrFCAmt Then
			//            CellStyle.BackColor = mDisableColumnBackColor
			//            grdExpensesDetails.Columns(cDrRate).AllowFocus = False
			//            grdExpensesDetails.Columns(cDrFCAmt).AllowFocus = False
			//        Else
			//            CellStyle.BackColor = vbWhite
			//            grdExpensesDetails.Columns(cDrLCAmt).AllowFocus = True
			//        End If
			//    ElseIf mReturnValue = 2 Then
			//        If Col = cDrRate Or Col = cDrFCAmt Then
			//            CellStyle.BackColor = vbWhite
			//            grdExpensesDetails.Columns(cDrRate).AllowFocus = True
			//            grdExpensesDetails.Columns(cDrFCAmt).AllowFocus = True
			//        Else
			//            CellStyle.BackColor = mDisableColumnBackColor
			//            grdExpensesDetails.Columns(cDrLCAmt).AllowFocus = False
			//        End If
			//    ElseIf mReturnValue = 0 Then
			//        CellStyle.BackColor = mDisableColumnBackColor
			//        grdExpensesDetails.Columns(cDrRate).AllowFocus = False
			//        grdExpensesDetails.Columns(cDrFCAmt).AllowFocus = False
			//        grdExpensesDetails.Columns(cDrLCAmt).AllowFocus = False
			//    End If
			//ElseIf Col = cRate Or Col = cFCAmt Or Col = cLCAmt Then

			if (Col == cRate || Col == cFCAmt || Col == cLCAmt)
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column method grdExpensesDetails.Columns.CellValue was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				mReturnValue = CheckCurrency(grdExpensesDetails.Splits[0].DisplayColumns[cCurr].CellValue(Bookmark), ReflectionHelper.GetPrimitiveValue<int>(Bookmark));
				if (mReturnValue == 1)
				{
					if (Col == cRate || Col == cFCAmt)
					{
						CellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(mDisableColumnBackColor)));
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cRate].AllowFocus = false;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cFCAmt].AllowFocus = false;
					}
					else
					{
						CellStyle.BackColor = Color.White;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cLCAmt].AllowFocus = true;
					}
				}
				else if (mReturnValue == 2)
				{ 
					if (Col == cRate || Col == cFCAmt)
					{
						CellStyle.BackColor = Color.White;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cRate].AllowFocus = true;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cFCAmt].AllowFocus = true;
					}
					else
					{
						CellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(mDisableColumnBackColor)));
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cLCAmt].AllowFocus = false;
					}
				}
				else if (mReturnValue == 0)
				{ 
					CellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(mDisableColumnBackColor)));
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cRate].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cFCAmt].AllowFocus = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdExpensesDetails.Splits[0].DisplayColumns[cLCAmt].AllowFocus = false;
				}
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdExpensesDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdExpensesDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == cRate || ColIndex == cFCAmt || ColIndex == cLCAmt)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					if (ColIndex == cRate)
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

				//    mysql = "select gcc.cost_no , "
				//    mysql = mysql & IIf(gPreferedLanguage = English, "gcc.L_cost_name,", "gcc.A_cost_name,")
				//    mysql = mysql & " gcc.cost_cd from gl_cost_centers gcc "
				//    mysql = mysql & " where gcc.show=1 "
				//    mysql = mysql & " order by 1 "
				//
				//    Set rsCCList = New adodb.Recordset
				//    rsCCList.CursorLocation = adUseClient
				//    rsCCList.Open mysql, gConn, adOpenKeyset, adLockOptimistic

				cmbMasterList_RowChange(cmbMasterList, new EventArgs());
			}

			grdExpensesDetails.Col = 1;
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdExpensesDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdExpensesDetails_OnAddNew()
		{
			grdExpensesDetails.Columns[cLN].Text = (grdExpensesDetails.RowCount + 1).ToString();
		}


		private int CheckCurrency(object pCurrSymbol, int pRowNo = -1)
		{
			//0=Not found
			//1=Base currency
			//2=Foreign Currency

			DataSet rsCloneRecordset = null;
			string mysql = "";
			object mReturnValue = null;

			if (SystemProcedure2.IsItEmpty(pCurrSymbol, SystemVariables.DataType.StringType))
			{
				return 0;
			}

			if (pRowNo == -1)
			{
				//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsCurrList.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsCloneRecordset = rsCurrList.Clone(UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified());

				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsCloneRecordset.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsCloneRecordset.MoveFirst();
				rsCloneRecordset.Find("symbol='" + ReflectionHelper.GetPrimitiveValue<string>(pCurrSymbol).Trim() + "'");
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
				mysql = "select curr_cd from gl_currency ";
				mysql = mysql + " where symbol='" + ReflectionHelper.GetPrimitiveValue<string>(pCurrSymbol) + "'";

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

			//If IsItEmpty(pCurrSymbol, StringType) Then
			//    CheckCurrency = 0
			//    Exit Function
			//End If
			//
			//If pRowNo = -1 Then
			//    Set rsCloneRecordset = rsLedgerList.Clone
			//
			//    With rsCloneRecordset
			//        .MoveFirst
			//        .Find "ldgr_no='" & Trim(pCurrSymbol) & "'"
			//        If Not .EOF Or .BOF Then
			//            If .Fields("curr_cd").Value = gDefaultCurrencyCd Then
			//                CheckCurrency = 1
			//            Else
			//                CheckCurrency = 2
			//            End If
			//        Else
			//            CheckCurrency = 0
			//        End If
			//    End With
			//Else
			//    mysql = "select curr_cd from gl_ledger "
			//    mysql = mysql & " where ldgr_no='" & pCurrSymbol & "'"
			//
			//    mReturnValue = GetMasterCode(mysql)
			//    If Not IsNull(mReturnValue) Then
			//        If mReturnValue = gDefaultCurrencyCd Then
			//            CheckCurrency = 1
			//        Else
			//            CheckCurrency = 2
			//        End If
			//    Else
			//        CheckCurrency = 0
			//    End If
			//End If
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
			int mCurrentRow = 0;
			int mReturnValue = 0;

			if (SystemProcedure2.IsItEmpty(grdExpensesDetails.Bookmark, SystemVariables.DataType.NumberType))
			{
				mCurrentRow = 0;
			}
			else
			{
				mCurrentRow = Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdExpensesDetails.Bookmark)));
			}

			int mCol = grdExpensesDetails.Col;

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(LastRow))
			{
				if ((Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(LastRow)) != mCurrentRow) || (LastCol != mCol))
				{
					mReturnValue = CheckCurrency(aExpensesDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(grdExpensesDetails.Bookmark), cCurr), ReflectionHelper.GetPrimitiveValue<int>(grdExpensesDetails.Bookmark));
					if (mReturnValue == 1)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cRate].AllowFocus = false;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cFCAmt].AllowFocus = false;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cLCAmt].AllowFocus = true;
					}
					else if (mReturnValue == 2)
					{ 
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cRate].AllowFocus = true;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cFCAmt].AllowFocus = true;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cLCAmt].AllowFocus = false;
					}
					else if (mReturnValue == 0)
					{ 
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cRate].AllowFocus = false;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cFCAmt].AllowFocus = false;
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						grdExpensesDetails.Splits[0].DisplayColumns[cLCAmt].AllowFocus = false;
					}
				}
			}

			switch(grdExpensesDetails.Col)
			{
				case cLdgrCode : case cLdgrName : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMasterList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMasterList.setDataSource((msdatasrc.DataSource) rsLedgerList); 
					break;
				case cCostCode : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMasterList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMasterList.setDataSource((msdatasrc.DataSource) rsCCList); 
					break;
				case cCurr : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMasterList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMasterList.setDataSource((msdatasrc.DataSource) rsCurrList); 
					break;
			}
		}

		private void SetList()
		{

			string mysql = "select l.ldgr_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l.L_ldgr_name" : "l.A_ldgr_name") + " as ldgr_name ";
			mysql = mysql + " , gl_currency.symbol,gl_currency.curr_cd ";
			mysql = mysql + " , isnull(gcc.cost_no ,'') ";
			mysql = mysql + " from gl_ledger l ";
			mysql = mysql + " inner join gl_currency on l.curr_cd = gl_currency.curr_cd ";
			mysql = mysql + " left join gl_cost_centers gcc on l.default_cost_cd = gcc.cost_cd ";
			mysql = mysql + " order by 1 ";

			rsLedgerList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsLedgerList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			//If rsLedgerList.State = adStateOpen Then
			//    rsLedgerList.Close
			//End If
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsLedgerList.Tables.Clear();
			adap.Fill(rsLedgerList);


			mysql = "select gc.symbol , ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "gc.L_curr_name" : "gc.A_curr_name") + " as curr_name ";
			mysql = mysql + " , gc.curr_cd ";
			mysql = mysql + " from gl_currency gc ";
			mysql = mysql + " order by 1 ";

			rsCurrList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCurrList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsCurrList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsCurrList.Tables.Clear();
			adap_2.Fill(rsCurrList);


			mysql = "select gcc.cost_no , ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "gcc.L_cost_name," : "gcc.A_cost_name,");
			mysql = mysql + " gcc.cost_cd from gl_cost_centers gcc ";
			mysql = mysql + " where gcc.show=1 ";
			mysql = mysql + " order by 1 ";

			rsCCList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCCList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsCCList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap_3 = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsCCList.Tables.Clear();
			adap_3.Fill(rsCCList);

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
			int Cnt = 0;
			int mReturnValue = 0;
			double mExpensesAmt = 0;
			double mCrAmt = 0;

			grdExpensesDetails.UpdateData();

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 2);
				if (FirstFocusObject.Enabled)
				{
					FirstFocusObject.Focus();
				}
				goto mend;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show(" Enter Parent Voucher Type. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Enabled)
				{
					txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Focus();
				}
				goto mend;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show(" Enter Parent Location Code. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Enabled)
				{
					txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Focus();
				}
				goto mend;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Text, SystemVariables.DataType.NumberType) || SystemProcedure2.IsItEmpty(Convert.ToString(txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Tag), SystemVariables.DataType.NumberType))
			{
				MessageBox.Show(" Enter Parent Voucher No. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Enabled)
				{
					txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Focus();
				}
				goto mend;
			}

			if (SystemProcedure2.IsItEmpty(txtVoucherDate.Value, SystemVariables.DataType.DateType))
			{
				MessageBox.Show("Enter voucher date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (txtVoucherDate.Enabled)
				{
					txtVoucherDate.Focus();
				}
				goto mend;
			}
			else
			{
				if (!SystemProcedure2.ValidDateRange(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value)))
				{
					MessageBox.Show("Invalid Date Range, Check the current financial year", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (txtVoucherDate.Enabled)
					{
						txtVoucherDate.Focus();
					}
					goto mend;
				}
			}


			mCrAmt = Conversion.Val(StringsHelper.Format(grdExpensesDetails.Columns[cLCAmt].FooterText, "###########0.0##"));
			mExpensesAmt = Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[SystemICSConstants.grdExpensesColumn].FooterText, "###########0.0##"));
			if (mCrAmt == 0)
			{
				MessageBox.Show(" Expenses cannot be zero ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				grdExpensesDetails.Focus();
				goto mend;
			}

			if (mExpensesAmt != mCrAmt)
			{
				MessageBox.Show(" Expenses should be allcated properly. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				grdVoucherDetails.Focus();
				goto mend;
			}


			int tempForEndVar = aExpensesDetails.GetUpperBound(0);
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{

				//Check for Cash ledger and currency
				mReturnValue = CheckCurrency(aExpensesDetails.GetValue(Cnt, cCurr), Cnt);
				if (mReturnValue == 0)
				{ //Illegal code
					MessageBox.Show("Invalid Ledger code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					grdExpensesDetails.Col = cLdgrCode;
					goto mGridFocus;
				}
				else if (mReturnValue == 1)
				{  //Base Currency
					if (SystemProcedure2.IsItEmpty(aExpensesDetails.GetValue(Cnt, cLCAmt), SystemVariables.DataType.NumberType))
					{
						MessageBox.Show("Amount should be greater than zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdExpensesDetails.Col = cLCAmt;
						grdExpensesDetails.Bookmark = Cnt;
						grdExpensesDetails.Focus();
						grdExpensesDetails.Rebind(true);
						goto mend;
					}
				}
				else if (mReturnValue == 2)
				{  //Foreign Currency
					if (SystemProcedure2.IsItEmpty(aExpensesDetails.GetValue(Cnt, cRate), SystemVariables.DataType.NumberType) || SystemProcedure2.IsItEmpty(aExpensesDetails.GetValue(Cnt, cFCAmt), SystemVariables.DataType.NumberType))
					{
						MessageBox.Show("Amount should be greater than zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdExpensesDetails.Col = cFCAmt;
						goto mGridFocus;
					}
				}

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (grdExpensesDetails.Splits[0].DisplayColumns[cCostCode].Visible)
				{
					if (SystemProcedure2.IsItEmpty(aExpensesDetails.GetValue(Cnt, cCostCode), SystemVariables.DataType.NumberType))
					{
						MessageBox.Show("Select a cost center.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdExpensesDetails.Col = cCostCode;
						grdExpensesDetails.Bookmark = Cnt;
						grdExpensesDetails.Focus();
						grdExpensesDetails.Rebind(true);
						goto mend;
					}
				}

			}

			return true;

			mGridFocus:
			grdExpensesDetails.Bookmark = Cnt;
			grdExpensesDetails.Focus();
			goto mend;
			return false;

			mend:
			return false;
		}


		public bool saveRecord(bool pApprove = false)
		{
			bool result = false;
			string mysql = "";
			//Dim mParentMasterTableName As String
			//Dim mParentDetailsTableName As String

			int mParentVoucherType = 0;
			int mParentVoucherEntryId = 0;
			int mNewEntryID = 0;
			int mHeaderLocatCode = 0;


			clsHourGlass myHourGlass = new clsHourGlass();


			//On Error GoTo eFoundError


			//'''****************************Get the Loation Code ****************************
			//''''****************************************************************************
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select locat_cd from SM_Location where locat_no=" + txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mTempValue))
			{
				MessageBox.Show("Enter valid location code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (txtCommonTextBox[SystemICSConstants.tcLocationCode].Enabled)
				{
					txtCommonTextBox[SystemICSConstants.tcLocationCode].Focus();
				}
				goto StationExitFunction;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mHeaderLocatCode = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
			}
			//''''****************************************************************************


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

			mParentVoucherType = Convert.ToInt32(Double.Parse(txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text));

			mysql = " select mt.entry_id , mt.time_stamp ";
			mysql = mysql + " from ICS_Transaction mt ";
			mysql = mysql + " inner join SM_Location ";
			mysql = mysql + " on mt.locat_cd = SM_Location.locat_cd ";
			mysql = mysql + " where mt.entry_id = " + Convert.ToString(txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Tag);
			//mySQL = mySQL & " where mt.voucher_no = " & txtCommonTextBox(tcImportVoucherNo).Text
			//mySQL = mySQL & " and SM_Location.locat_no = " & txtCommonTextBox(tcImportLocationCode).Text
			//mySQL = mySQL & " and mt.voucher_type =" & mParentVoucherType

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mTempValue))
			{
				MessageBox.Show("Enter valid Import Voucher Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto StationExitFunction;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mParentVoucherEntryId = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(0));
			}

			//if the time stamp does not match the previous one then rollback
			if (SystemProcedure2.tsFormat(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1))) != SystemProcedure2.tsFormat(mParentVoucherTimeStamp))
			{
				MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

				goto StationExitFunction;
			}
			//''''****************************************************************************



			SystemVariables.gConn.BeginTransaction();

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{

				//''''****************************************************************************
				//I '''''''''''''N'''''''''''''S'''''''''''''E'''''''''''''R'''''''''''T
				//''''****************************************************************************

				txtCommonTextBox[SystemICSConstants.tcVoucherNo].Text = SystemProcedure2.GetNewNumber("ics_landed_cost", "voucher_no");


				//''''***************Insert into the master table*****************************
				mNewEntryID = InsertMasterRecord(mParentVoucherType, mParentVoucherEntryId);
				//''''************************************************************************

				//''''***************Expenses and Charges Details ********************************
				if (!SaveVoucherExpenses(mNewEntryID))
				{
					goto StationRollBackTrans;
				}
				//''''************************************************************************

				UpdateParentTableExpenses(mNewEntryID, mParentVoucherEntryId, "ICS_Transaction", "ICS_Transaction_Details");
			}
			else
			{


				//''''****************************************************************************
				//U '''''''''''''P'''''''''''''D'''''''''''''A'''''''''''''T'''''''''''E
				//''''****************************************************************************

				//''''*********************Make the mNewEntryID = Searchvalue so that the same
				//'''Variable can be user for both add and edit mode
				//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mNewEntryID = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
				//''''*************************************************************************


				//''''*********************Check the Master table TimeStamp *******************
				mysql = " select time_stamp from ics_landed_cost ";
				mysql = mysql + " where entry_id=" + Conversion.Str(mNewEntryID);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//if the time stamp does not match the previous one then rollback
				if (SystemProcedure2.tsFormat(ReflectionHelper.GetPrimitiveValue<string>(mTempValue)) != mTimeStamp)
				{
					MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					goto StationRollBackTrans;
				}
				//''''*************************************************************************

				//''''************************update the sales table****************************
				UpdateMasterTable(mNewEntryID);
				//''''*************************************************************************

				DeleteExpensesLedgerDetails(mNewEntryID, mParentVoucherEntryId);

				//''''***************Expenses and Charges Details ********************************
				if (!SaveVoucherExpenses(mNewEntryID))
				{
					goto StationRollBackTrans;
				}
				//''''************************************************************************

				UpdateParentTableExpenses(mNewEntryID, mParentVoucherEntryId, "ICS_Transaction", "ICS_Transaction_Details");
			}


			if (!CheckDataConsistency(mNewEntryID, mParentVoucherEntryId))
			{
				goto StationRollBackTrans;
			}

			//''''*************************************************************************
			//Approve (Change the status to 2)
			if (pApprove)
			{
				SystemICSProcedure.ApproveTransaction("ics_landed_cost", mNewEntryID);
				PostParentExpenses();
			}
			//''''*************************************************************************




			//''''*************************************************************************
			//Update the estimated cost columns in ics_landed_cost_item_details

			UpdateEstimateCostOnICSItemDetails(mNewEntryID);
			//''''*************************************************************************



			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();



			//''''*************************************************************************
			//Display a messbox if the auto generate voucher no is true and it is in addmode
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				mysql = SystemConstants.msg20 + txtCommonTextBox[SystemICSConstants.tcVoucherNo].Text;
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
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			return result;
			//''''*************************************************************************


			//''''*************************************************************************
			//All other Errors.

			int mReturnErrorType = 0;

			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_table_Name"]), "GetRecord", SystemConstants.msg10);
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			if (mReturnErrorType == 1)
			{
				return false;
			}
			else if (mReturnErrorType == 2)
			{ 
				AddRecord();
				return false;
			}
			else if (mReturnErrorType == 3)
			{ 
				AddRecord();
				return false;
			}
			else
			{
				return false;
			}
		}

		private int InsertMasterRecord(int pParentVoucherType, int pParentVoucherEntryId)
		{
			string mysql = "";
			try
			{

				mysql = " insert into ics_landed_cost ";
				mysql = mysql + " (linked_voucher_type, linked_entry_id, voucher_date, voucher_no ";
				mysql = mysql + " , reference_no, comments, user_cd) ";
				mysql = mysql + " values(";
				mysql = mysql + pParentVoucherType.ToString();
				mysql = mysql + " ," + pParentVoucherEntryId.ToString();
				mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
				mysql = mysql + " ," + txtCommonTextBox[SystemICSConstants.tcVoucherNo].Text;
				mysql = mysql + " ,N'" + txtCommonTextBox[SystemICSConstants.tcReferenceNo].Text + "'";
				mysql = mysql + " ,N'" + txtCommonTextBox[SystemICSConstants.tcComments].Text + "'";
				mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
				mysql = mysql + " )";

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();


				return ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			return 0;
		}

		private bool SaveVoucherExpenses(int pEntryId)
		{

			//Inserting into additional purchase Expenses details table
			bool result = false;
			double crAmt = 0;
			double crExchRate = 0;

			object mReturnValue = null;
			int mCrLdgrCd = 0;
			int mCrCostCd = 0;
			int mCurrCD = 0;
			int mConsignmentCd = 0;
			string mysql = "";
			int Cnt = 0;

			try
			{

				int tempForEndVar = aExpensesDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					mysql = "select ldgr_cd, '' from gl_ledger where ldgr_no='" + Convert.ToString(aExpensesDetails.GetValue(Cnt, cLdgrCode)) + "'";
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
					}

					mysql = "select curr_cd from gl_currency where symbol='" + Convert.ToString(aExpensesDetails.GetValue(Cnt, cCurr)) + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Currency Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						return false;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCurrCD = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
						if (mCurrCD == SystemGLConstants.gDefaultCurrencyCd)
						{
							crExchRate = 1;
							crAmt = Convert.ToDouble(aExpensesDetails.GetValue(Cnt, cLCAmt));
						}
						else
						{
							crExchRate = Convert.ToDouble(aExpensesDetails.GetValue(Cnt, cRate));
							crAmt = Convert.ToDouble(aExpensesDetails.GetValue(Cnt, cFCAmt));
						}
					}

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdExpensesDetails.Splits[0].DisplayColumns[cCostCode].Visible)
					{
						mysql = "select cost_cd from gl_cost_centers where cost_no=" + Convert.ToString(aExpensesDetails.GetValue(Cnt, cCostCode));
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

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdExpensesDetails.Splits[0].DisplayColumns[cConsignmentCd].Visible && !SystemProcedure2.IsItEmpty(aExpensesDetails.GetValue(Cnt, cConsignmentCd), SystemVariables.DataType.StringType))
					{
						mysql = "select consignment_cd from gl_consignment where consignment_no='" + Convert.ToString(aExpensesDetails.GetValue(Cnt, cConsignmentCd)) + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue))
						{
							MessageBox.Show("Invalid Consignment Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							return false;
						}
						else
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mConsignmentCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
						}
					}
					else
					{
						mConsignmentCd = 0;
					}

					//transaction is assumed in default currency
					//can be changed later on since the calculation will be based on local currency fields
					mysql = " insert into ics_landed_cost_ledger_details(Entry_Id, Reference_No ";
					mysql = mysql + " , Ldgr_Cd, curr_cd, cost_cd, consignment_cd, Exchange_Rate, FC_amount, lc_amount ";
					mysql = mysql + " , comments)";
					mysql = mysql + " VALUES( ";
					mysql = mysql + Conversion.Str(pEntryId);
					mysql = mysql + ",'" + txtCommonTextBox[SystemICSConstants.tcReferenceNo].Text + "'";
					mysql = mysql + "," + mCrLdgrCd.ToString();
					mysql = mysql + "," + mCurrCD.ToString();
					mysql = mysql + "," + mCrCostCd.ToString();
					if (mConsignmentCd != 0)
					{
						mysql = mysql + "," + mConsignmentCd.ToString();
					}
					else
					{
						mysql = mysql + ", NULL ";
					}

					mysql = mysql + "," + Conversion.Str(crExchRate);
					mysql = mysql + "," + Conversion.Str(crAmt);
					mysql = mysql + "," + Conversion.Str(Math.Round((double) (crExchRate * crAmt), 4));
					mysql = mysql + ",N'" + Convert.ToString(aExpensesDetails.GetValue(Cnt, cComments)) + "'";
					mysql = mysql + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}

				return true;
			}
			catch
			{
				//MsgBox Err.Description
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
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, "Landed Cost", "Transaction");
				//''''*************************************************************************


				//''''*************************************************************************
				//'''Grid settings
				int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					grdVoucherDetails.Columns[Cnt].FooterText = "";
				}

				int tempForEndVar2 = grdExpensesDetails.Columns.Count - 1;
				for (Cnt = 0; Cnt <= tempForEndVar2; Cnt++)
				{
					grdExpensesDetails.Columns[Cnt].FooterText = "";
				}


				SystemGrid.DefineVoucherArray(aVoucherDetails, SystemICSConstants.grdArrayUbound, -1, true);
				SystemGrid.DefineVoucherArray(aExpensesDetails, mMaxExpensesArray, -1, true);

				grdVoucherDetails.Rebind(true);
				grdExpensesDetails.Rebind(true);

				mExpensesVoucherType = Convert.ToInt32(Double.Parse(txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text));
				mExpensesVoucherTypeName = txtDisplayLabel[1].Text;
				SystemProcedure2.ClearTextBox(this);
				SystemProcedure2.ClearNumberBox(this);

				SearchValue = ""; //Change the msearchvalue to blank
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive; //set new voucher status to active by default

				txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text = mExpensesVoucherType.ToString();
				txtDisplayLabel[1].Text = mExpensesVoucherTypeName;
				txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Enabled = true;
				txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Enabled = true;
				txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Tag = "";


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


		private void DeleteExpensesLedgerDetails(int pVoucherEntryId, int pParentEntryID)
		{
			string mysql = "";
			try
			{

				mysql = " delete from ics_landed_cost_ledger_details ";
				mysql = mysql + " where entry_id =" + pVoucherEntryId.ToString();
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mysql = " update ICS_Transaction_Details ";
				mysql = mysql + " Set prod_exp_amt = 0 ";
				mysql = mysql + " from ICS_Transaction_Details dt ";
				mysql = mysql + " inner join ics_landed_cost_item_details ilcid on dt.line_no = ilcid.linked_line_no ";
				mysql = mysql + " where ilcid.entry_id = " + pVoucherEntryId.ToString();
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				mysql = " update ICS_Transaction ";
				mysql = mysql + " set expenses_amt =0 ";
				mysql = mysql + " where entry_id =" + pParentEntryID.ToString();
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				mysql = " delete from ics_landed_cost_item_details ";
				mysql = mysql + " where entry_id =" + pVoucherEntryId.ToString();
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void UpdateParentTableExpenses(int pVoucherEntryId, int pParentEntryID, string pParentMasterTableName, string pParentDetailsTableName)
		{
			StringBuilder mysql = new StringBuilder();
			int Cnt = 0;
			decimal mExpenseAmt = 0;

			try
			{

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					mExpenseAmt = (decimal) Conversion.Val(StringsHelper.Format(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdExpensesColumn), "##############0.0##"));

					mysql = new StringBuilder(" update " + pParentDetailsTableName);
					mysql.Append(" set prod_exp_amt = " + mExpenseAmt.ToString());
					mysql.Append(" where line_no=" + Convert.ToString(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdParentLineNo)));
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql.ToString();
					TempCommand.ExecuteNonQuery();

					mysql = new StringBuilder(" insert into ics_landed_cost_item_details ");
					mysql.Append(" (entry_id, linked_line_no, fc_expense_amount, exchange_rate ");
					mysql.Append(" , lc_expense_amount) ");
					mysql.Append(" values ( ");
					mysql.Append(Conversion.Str(pVoucherEntryId));
					mysql.Append(" ," + Convert.ToString(aVoucherDetails.GetValue(Cnt, SystemICSConstants.grdParentLineNo)));
					mysql.Append(" ," + mExpenseAmt.ToString());
					mysql.Append(" , 1");
					mysql.Append(" ," + ((mExpenseAmt * 1).ToString()));
					mysql.Append(" ) ");
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql.ToString();
					TempCommand_2.ExecuteNonQuery();
				}

				mysql = new StringBuilder(" update " + pParentMasterTableName);
				mysql.Append(" set expenses_amt = " + StringsHelper.Format(grdVoucherDetails.Columns[SystemICSConstants.grdExpensesColumn].FooterText, "###########0.0##"));
				mysql.Append(" where entry_id =" + pParentEntryID.ToString());
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql.ToString();
				TempCommand_3.ExecuteNonQuery();
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		public void findRecord()
		{

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(4000109));
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

			string mysql = "select l.Ldgr_No as LdgrNo, gc.symbol Symbol ";
			mysql = mysql + " , gcc.cost_no ccno, gconsgn.consignment_no ";
			mysql = mysql + " , ldt.* ";
			mysql = mysql + " ," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l.l_ldgr_name" : " l.a_ldgr_name") + " as ldgr_name ";
			mysql = mysql + " FROM ics_landed_cost_ledger_details ldt ";
			mysql = mysql + " INNER JOIN gl_ledger l ON ldt.Ldgr_Cd = L.Ldgr_Cd ";
			mysql = mysql + " INNER JOIN gl_currency gc ON ldt.curr_cd = gc.curr_cd ";
			mysql = mysql + " INNER JOIN gl_cost_centers gcc ON ldt.cost_cd = gcc.cost_cd ";
			mysql = mysql + " left outer join gl_consignment gconsgn ON ldt.consignment_cd = gconsgn.consignment_cd ";
			mysql = mysql + " Where entry_id=" + Conversion.Str(pEntryId);
			mysql = mysql + " order by line_no ";

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand.ExecuteReader();
			localRec.Read();

			do 
			{
				aExpensesDetails.RedimXArray(new int[]{Cnt, mMaxExpensesArray}, new int[]{0, 0});

				aExpensesDetails.SetValue(Cnt + 1, Cnt, cLN);

				aExpensesDetails.SetValue(localRec["ldgrno"], Cnt, cLdgrCode);
				aExpensesDetails.SetValue(localRec["ldgr_name"], Cnt, cLdgrName);
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (grdExpensesDetails.Splits[0].DisplayColumns[cCostCode].Visible)
				{
					aExpensesDetails.SetValue(localRec["ccno"], Cnt, cCostCode);
				}

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (grdExpensesDetails.Splits[0].DisplayColumns[cConsignmentCd].Visible)
				{
					aExpensesDetails.SetValue(localRec["consignment_no"], Cnt, cConsignmentCd);
				}

				aExpensesDetails.SetValue(localRec["symbol"], Cnt, cCurr);
				if (Convert.ToDouble(localRec["Curr_Cd"]) == SystemGLConstants.gDefaultCurrencyCd)
				{
					aExpensesDetails.SetValue(localRec["lc_amount"], Cnt, cLCAmt);
				}
				else
				{
					aExpensesDetails.SetValue(localRec["exchange_rate"], Cnt, cRate);
					aExpensesDetails.SetValue(localRec["fc_amount"], Cnt, cFCAmt);
					aExpensesDetails.SetValue(localRec["lc_amount"], Cnt, cLCAmt);
				}

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



			string mysql = " select ldgr_no ";
			mysql = mysql + " ," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name") + " as ldgr_name ";
			mysql = mysql + " , mt.voucher_no, mt.time_stamp, mt.voucher_date ";
			mysql = mysql + " , mt.exchange_rate ";
			mysql = mysql + " , gl_currency.symbol as curr_symbol ";
			mysql = mysql + " , dt.Entry_Id, dt.Line_No, dt.Prod_Cd, dt.Unit_Entry_Id ";
			mysql = mysql + " , dt.Project_cd, dt.Exchange_Rate, dt.Prod_Name, dt.Reference_No ";
			mysql = mysql + " , dt.Qty, dt.Base_Qty, dt.Processed_Qty , dt.Balance_Qty";
			mysql = mysql + " , ICS_Item.serialized  , ICS_Item.item_type_cd ";
			mysql = mysql + " , (aud.alt_qty * dt.Balance_Qty) / aud.base_qty as Alt_Unit_balance_qty ";
			mysql = mysql + " , dt.FC_Rate, dt.FC_Prod_Dis, dt.FC_Amount, ilcid.lc_expense_amount as prod_exp_amt ";
			mysql = mysql + " , dt.Dis_In_Percent, dt.promo_type, dt.Status , ICS_Item.part_no ";
			mysql = mysql + " , ICS_Unit.symbol, mt.reference_no as ref_no ";
			mysql = mysql + " , locat_no as locat_no, ICS_Item.supplier_part_no, dt.Batch_Cd ";
			mysql = mysql + " from ICS_Transaction_Details dt ";
			mysql = mysql + " inner join ICS_Item on dt.prod_cd = ICS_Item.prod_cd ";
			mysql = mysql + " inner join ICS_Item_Types it on it.item_type_cd = ICS_Item.item_type_cd ";
			mysql = mysql + " inner join ics_landed_cost_item_details ilcid on dt.line_no = ilcid.linked_line_no ";
			mysql = mysql + " inner join ICS_Transaction mt on mt.entry_id = dt.entry_id  ";
			mysql = mysql + " inner join ICS_Item_Unit_Details aud on dt.unit_entry_id = aud.unit_entry_id ";
			mysql = mysql + " inner join ICS_Unit on ICS_Unit.unit_cd = aud.alt_unit_cd ";
			mysql = mysql + " inner join SM_Location on mt.locat_cd = SM_Location.locat_cd ";
			mysql = mysql + " left join gl_ledger on mt.ldgr_cd = gl_ledger.ldgr_cd  ";
			mysql = mysql + " left join gl_currency on mt.curr_cd = gl_currency.curr_cd  ";
			mysql = mysql + " where mt.entry_id = " + pLinkedEntryId.ToString();
			//mysql = mysql & " and it.affect_stock = 1 "
			mysql = mysql + " order by dt.line_no ";

			SqlDataReader rsLocalRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			if (rsLocalRec.Read())
			{
				SystemGrid.DefineVoucherArray(aVoucherDetails, SystemICSConstants.grdArrayUbound, 0, true);

				txtVoucherDate.Value = rsLocalRec["voucher_date"];

				txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Text = pLinkedVoucherType.ToString();
				txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Text = Convert.ToString(rsLocalRec["locat_no"]);
				txtReferenceNo.Text = Convert.ToString(rsLocalRec["ref_no"]) + "";

				txtCommonTextBox[SystemICSConstants.tcImportVoucherType].Enabled = false;
				txtCommonTextBox[SystemICSConstants.tcImportLocationCode].Enabled = false;

				//'This is done because the lost focus of import voucher no was giving error.
				txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Text = "";
				txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Enabled = false;

				//        DoEvents
				txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Text = Convert.ToString(rsLocalRec["voucher_no"]);
				txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Tag = Convert.ToString(rsLocalRec["entry_id"]);

				txtCommonTextBox[SystemICSConstants.tcLedgerCode].Text = Convert.ToString(rsLocalRec["ldgr_no"]);
				txtDisplayLabel[SystemICSConstants.dcLedgerName].Text = Convert.ToString(rsLocalRec["ldgr_name"]);

				txtCommonTextBox[SystemICSConstants.tcCurrencySymbol].Text = Convert.ToString(rsLocalRec["curr_symbol"]);

				mParentVoucherTimeStamp = Convert.ToString(rsLocalRec["time_stamp"]);

				txtExchangeRate.Value = rsLocalRec["exchange_rate"];

				do 
				{
					SystemGrid.DefineVoucherArray(aVoucherDetails, SystemICSConstants.grdArrayUbound, Cnt, false);

					//Get the details information into the grid
					aVoucherDetails.SetValue(Cnt + 1, Cnt, SystemICSConstants.grdLineNoColumn);
					aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["supplier_part_no"]).Trim(), Cnt, SystemICSConstants.grdSupplierBarcodeColumn);
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
					aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["Batch_Cd"]).Trim(), Cnt, SystemICSConstants.grdBatchColumn);
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
			string mysql = "";
			try
			{

				mysql = " update ics_landed_cost ";
				mysql = mysql + " set voucher_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'";
				mysql = mysql + " , reference_no =N'" + txtCommonTextBox[SystemICSConstants.tcReferenceNo].Text + "'";
				mysql = mysql + " , comments =N'" + txtCommonTextBox[SystemICSConstants.tcComments].Text + "'";
				mysql = mysql + " , user_cd =" + SystemVariables.gLoggedInUserCode.ToString();
				mysql = mysql + " where entry_id =" + pEntryId.ToString();
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		public bool deleteRecord()
		{
			//Delete the Record

			bool result = false;
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
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{

					mysql = " update ICS_Transaction ";
					mysql = mysql + " set expenses_amt = 0 ";
					mysql = mysql + " where entry_id = ";
					mysql = mysql + " ( select linked_entry_id from ics_landed_cost ilc ";
					mysql = mysql + " where ilc.entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue) + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mysql = " update ICS_Transaction_Details ";
					mysql = mysql + " Set prod_exp_amt = 0 ";
					mysql = mysql + " from ICS_Transaction_Details dt ";
					mysql = mysql + " inner join ics_landed_cost_item_details ilcid on dt.line_no = ilcid.linked_line_no ";
					mysql = mysql + " where ilcid.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

					//''''*************************************************************************

					mysql = " delete from ics_landed_cost_item_details ";
					mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					mysql = " delete from ics_landed_cost_ledger_details ";
					mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();

					mysql = " delete from ics_landed_cost ";
					mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlCommand TempCommand_5 = null;
					TempCommand_5 = SystemVariables.gConn.CreateCommand();
					TempCommand_5.CommandText = mysql;
					TempCommand_5.ExecuteNonQuery();


				}
				//''''*************************************************************************

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();

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
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			return result;
		}

		public bool Post()
		{
			bool result = false;
			DialogResult ans = (DialogResult) 0;
			frmSysOnlinePosting frmTemp = null;

			try
			{

				frmTemp = frmSysOnlinePosting.CreateInstance();

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

							SystemICSProcedure.ApproveTransaction("ics_landed_cost", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
							PostParentExpenses();
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
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Post");
				frmTemp.Close();
			}
			return result;
		}

		private void PostParentExpenses()
		{
			int mEntryId = 0;
			object mTempValue = null;
			string mysql = "";
			try
			{

				mysql = "select entry_id ";
				mysql = mysql + " from ICS_Transaction mt ";
				mysql = mysql + " inner join SM_Location on mt.locat_cd = SM_Location.locat_cd ";
				mysql = mysql + " where mt.entry_id = " + Convert.ToString(txtCommonTextBox[SystemICSConstants.tcImportVoucherNo].Tag);

				//mySQL = mySQL & " where mt.voucher_no = " & txtCommonTextBox(tcImportVoucherNo).Text
				//mySQL = mySQL & " and SM_Location.locat_no = " & Str(txtCommonTextBox(tcImportLocationCode).Text)
				//mySQL = mySQL & " and mt.voucher_type = " & txtCommonTextBox(tcImportVoucherType).Text

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempValue))
				{
					//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
				}

				SystemICSProcedure.PostTransactionToGL("ICS_Transaction", mEntryId);
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Parent Exp post");
				this.Close();
			}
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
			if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("ics_landed_cost_default_Allocation_type")) == 1)
			{
				optAllocation[0].Checked = TriState.True != TriState.False;
			}
			else
			{
				optAllocation[1].Checked = TriState.True != TriState.False;
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
			SystemReports.GetCrystalReport(100060222, 2, "7074", Conversion.Str(mEntryId), false);
		}

		private bool CheckDataConsistency(int pEntryId, int pParentEntryID)
		{

			string mysql = " select (sum(lc_amount)) ";
			mysql = mysql + " from ics_landed_cost_ledger_details ";
			mysql = mysql + " where entry_id = " + pEntryId.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			decimal mLCAmount = (decimal) Math.Abs(ReflectionHelper.GetPrimitiveValue<double>(mReturnValue));

			mysql = " select sum(prod_exp_amt) ";
			mysql = mysql + " from ICS_Transaction_Details ";
			mysql = mysql + " where entry_id =" + pParentEntryID.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			decimal mProdExpAmt = ReflectionHelper.GetPrimitiveValue<decimal>(mReturnValue);

			//If mLCAmount <> mProdExpAmt Then
			if (Math.Abs((double) (mLCAmount - mProdExpAmt)) > 0.009d)
			{
				MessageBox.Show(" Allocate ICS_Item expenses amount properly, transaction failed. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			return true;

		}

		private void UpdateEstimateCostOnICSItemDetails(int pEntryId)
		{

			double mCost = 0;


			StringBuilder mysql = new StringBuilder();
			mysql.Append(" select ilcid.line_no ");
			mysql.Append(" , isnull(dt.base_qty ,0) as base_qty,  isnull(dt.lc_amount ,0) +  isnull(ilcid.lc_expense_amount,0)  as lc_amount ");
			mysql.Append(" , isnull(p.current_qty,0) as current_qty, isnull(p.cost ,0) as cost ");
			mysql.Append(" from ics_landed_cost_item_details  ilcid ");
			mysql.Append(" inner join ICS_Transaction_Details dt on ilcid.linked_line_no = dt.line_no ");
			mysql.Append(" inner join ICS_Item p on dt.prod_cd = p.prod_cd ");
			mysql.Append(" where ilcid.entry_id =" + pEntryId.ToString());
			SqlDataReader rsTempRec = null;

			SqlCommand sqlCommand = new SqlCommand(mysql.ToString(), SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				mCost = ((Convert.ToDouble(rsTempRec["current_qty"]) * Convert.ToDouble(rsTempRec["cost"])) + Convert.ToDouble(rsTempRec["lc_amount"])) / ((double) (Convert.ToDouble(Convert.ToDouble(rsTempRec["current_qty"]) + Convert.ToDouble(rsTempRec["base_qty"]))));


				mysql = new StringBuilder(" update ics_landed_cost_item_details ");
				mysql.Append(" set estimated_cost= " + mCost.ToString());
				mysql.Append(" where line_no =" + Convert.ToString(rsTempRec["line_no"]));
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql.ToString();
				TempCommand.ExecuteNonQuery();

			}
			while(rsTempRec.Read());

			rsTempRec.Close();

		}
	}
}