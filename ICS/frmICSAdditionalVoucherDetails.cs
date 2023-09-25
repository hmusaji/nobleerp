
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace Xtreme
{
	internal partial class frmICSAdditionalVoucherDetails
		: System.Windows.Forms.Form
	{

		public frmICSAdditionalVoucherDetails()
{
InitializeComponent();
} 
 public  void frmICSAdditionalVoucherDetails_old()
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


		private void frmICSAdditionalVoucherDetails_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		//Define the constants for Textbox
		private const int lcLdgrName = 1;
		private const int lcAdd1 = 2;
		private const int lcAdd2 = 3;
		private const int lcPhone = 4;
		private const int lcStreet = 5;
		private const int lcBlockNo = 6;
		private const int lcCity = 7;
		private const int lcCountry = 8;
		private const int lcReferenceNo = 9;
		private const int lcChequeNo = 10;
		private const int lcCreditCardNo = 11;

		//Declared By:Rizwan. 13-Dec-2007.
		private const int tcBidNo = 1;

		private int mEntryId = 0;
		private string mLdgrCd = "";

		public int cTabDocPresc = 0;
		public int cTabAdditionalDetails = 0;
		//. Date: 04-Dec-2007. To add an Additional Tab for Narration
		public int cTabAdditionalDetails2 = 0;

		public void SetSetValues(int pEntryId, string value)
		{
			mEntryId = pEntryId;
			mLdgrCd = value;
		}



		private void cmdColor_Click(Object eventSender, EventArgs eventArgs)
		{
			if (ReflectionHelper.GetValueForcedToCursor(ColorTranslator.ToOle(txtNarration2.SelectionColor)) == CursorHelper.CursorDefault)
			{
				txtNarration2.SelectionColor = Color.Blue;
			}
			else
			{
				txtNarration2.SelectionColor = ColorTranslator.FromOle(0);
			}
			txtNarration2.Refresh();
		}

		private void cmdBold_Click(Object eventSender, EventArgs eventArgs)
		{
			if (!ReflectionHelper.GetPrimitiveValue<bool>(txtNarration2.SelectionFont.Bold))
			{
				txtNarration2.SelectionFont = txtNarration2.SelectionFont.Change(bold:true);
			}
			else
			{
				txtNarration2.SelectionFont = txtNarration2.SelectionFont.Change(bold:false);
			}
		}

		private void cmdItalic_Click(Object eventSender, EventArgs eventArgs)
		{
			if (!ReflectionHelper.GetPrimitiveValue<bool>(txtNarration2.SelectionFont.Italic))
			{
				txtNarration2.SelectionFont = txtNarration2.SelectionFont.Change(italic:true);
			}
			else
			{
				txtNarration2.SelectionFont = txtNarration2.SelectionFont.Change(italic:false);
			}
		}

		private void cmdUnderline_Click(Object eventSender, EventArgs eventArgs)
		{
			if (!ReflectionHelper.GetPrimitiveValue<bool>(txtNarration2.SelectionFont.Underline))
			{
				txtNarration2.SelectionFont = txtNarration2.SelectionFont.Change(underline:true);
			}
			else
			{
				txtNarration2.SelectionFont = txtNarration2.SelectionFont.Change(underline:false);
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 13 && this.ActiveControl.Name != "txtNarration2")
				{ //if enter key pressed send a tab key
					SendKeys.Send("{tab}");
					return;
					//ElseIf KeyCode = 27 Then
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
			string mysql = "";
			object mReturnValue = null;
			SystemProcedure2.ClearTextBox(this);

			cTabDocPresc = 0;
			cTabAdditionalDetails = 1;
			//. Date: 04-Dec-2007. To add an Additional Tab for Narration
			cTabAdditionalDetails2 = 2;

			//Added By:Moiz Hakimi. Date: 12-Mar-2008
			txtOldPrescription.Text = "";

			txtOldPrescription.Text = "                         Right Eye";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "               Distance";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "SPH    :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "CYL    :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "AXIS   :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "               Reading";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "SPH    :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "CYL    :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "AXIS   :";

			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "                         Left Eye";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "               Distance";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "SPH    :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "CYL    :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "AXIS   :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "               Reading";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "SPH    :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "CYL    :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "AXIS   :";


			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "                         Contact Lens";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "               Distance";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "IPD    :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "SGH    :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "R EYE  :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "L EYE  :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "               Reading";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "IPD    :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "SGH    :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "R EYE  :";
			txtOldPrescription.Text = txtOldPrescription.Text + Environment.NewLine + "L EYE  :";

			txtOldPrescription.Refresh();
			SystemProcedure.SetLabelCaption(this);
			//. 31/12/2007. To Modify Form's Caption as Per Parent Form
			//-------------------------------------------------------------------------
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				this.Text = this.Text + " (" + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["l_voucher_name"]) + ")";
			}
			else
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				this.Text = this.Text + " (" + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["a_voucher_name"]) + ")";
			}
			//--------------------------------------------------------------------------

			clsFlip oFlipThisForm = null;
			//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
			{
				oFlipThisForm = new clsFlip();

				oFlipThisForm.SwapMe(this);
			}


			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			if (!Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Enable_Doc_Presc_In_Additional_Voucher_Details"]))
			{
				tabMaster.set_TabVisible((short) cTabDocPresc, TriState.False != TriState.False);
				tabMaster.TabsPerPage = (short) (tabMaster.TabsPerPage - 1);
				tabMaster.CurrTab = (short) cTabAdditionalDetails;
			}
			else
			{
				tabMaster.CurrTab = (short) cTabDocPresc;
			}

			//Added By:Rizwan. 04-Dec-2007. To Add Additional Tab for Narration
			//------------------------------------------------------------------
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			if (!Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Enable_Additional_Voucher_Details_2"]))
			{
				tabMaster.set_TabVisible((short) cTabAdditionalDetails2, TriState.False != TriState.False);
				tabMaster.TabsPerPage = (short) (tabMaster.TabsPerPage - 1);
			}
			//-------------------------------------------------------------------

			//Added By:Rizwan. 15-Dec-2007. To Include Bid Entry
			//------------------------------------------------------------------
			txtCommonTextBox[1].Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_ics_bid"));
			lblCommonLabel[21].Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_ics_bid"));
			//------------------------------------------------------------------


			//Fill the Payment Mode Combo Box
			//mySql = "select "
			//mySql = mySql & IIf(gPreferedLanguage = English, " L_Pay_Mode_Name", "a_Pay_Mode_Name")
			//mySql = mySql & " , pay_mode_cd from ICS_Payment_Modes"
			//Call FillComboWithItemData(cmbPaymentMode, mySql)
			//Call FillDropDown(cmbPaymentMode, 1, "ICS_Transaction")
			//-----------------------------------------------------------------

			//Modified By: Rizwan Date: 31/12/2007. To Fill DropDowns with Value Set(Job003).
			//----------------------------------------------------------------
			FillDropDown(comCommon[SystemICSConstants.icsAVDFlex1], SystemICSConstants.icsAVDFlex1, SystemICSConstants.icsVSObjectType);
			FillDropDown(comCommon[SystemICSConstants.icsAVDFlex2], SystemICSConstants.icsAVDFlex2, SystemICSConstants.icsVSObjectType);
			FillDropDown(comCommon[SystemICSConstants.icsAVDFlex3], SystemICSConstants.icsAVDFlex3, SystemICSConstants.icsVSObjectType);
			FillDropDown(comCommon[SystemICSConstants.icsAVDFlex4], SystemICSConstants.icsAVDFlex4, SystemICSConstants.icsVSObjectType);
			FillDropDown(comCommon[SystemICSConstants.icsAVDFlex5], SystemICSConstants.icsAVDFlex5, SystemICSConstants.icsVSObjectType);

			//Dim mObjectId()
			//ReDim mObjectId(3)
			//mObjectId(icsAVDFlex2) = 1020
			//mObjectId(icsAVDFlex3) = 1021
			//mObjectId(icsAVDFlex4) = 1022
			//mObjectId(icsAVDFlex5) = 1023

			//Call FillComboWithSystemObjects(comCommon, mObjectId)

			if (mEntryId > 0)
			{
				mysql = "SELECT Ldgr_Name, Addr_1, Addr_2, Phone, Street, Block_No, City ";
				mysql = mysql + ", Country , Reference_Order_No, Reference_Order_Date ";
				mysql = mysql + ", Cheque_No , Cheque_Date , Credit_Card_No, Credit_Card_Date ";
				mysql = mysql + ", pay_mode_cd, drawn_on_bank ";
				mysql = mysql + " , shipment_mode, shipment_no_type, shipment_no, packing_list_no";
				mysql = mysql + " , received_by, delivery_by_period, delivery_to_location, payment_terms";
				mysql = mysql + " , delivery_terms , additional_expenses , trans_type ";

				//If rsVoucherTypes("Enable_Doc_Presc_In_Additional_Voucher_Details") = True Then
				mysql = mysql + " , dist_re_sph, dist_re_cyl, dist_re_axis, dist_le_sph, dist_le_cyl, dist_le_axis, dist_ipd, dist_sgh ";
				mysql = mysql + " , dist_re_lens, dist_le_lens, add_re_sph , add_re_cyl, add_re_axis, add_le_sph, add_le_cyl, add_le_axis ";
				mysql = mysql + " , add_ipd, add_sgh, add_re_lens, add_le_lens ";
				//End If

				//. Date: 04-Dec-2007. To add an Additional Tab for Narration
				//If rsVoucherTypes("Enable_Additional_Voucher_Details_2") = True Then
				mysql = mysql + ", Narration_2 ";
				//End If

				//. 13-12-2007
				mysql = mysql + " , (select bid_no from ics_bid where entry_id = ICS_Additional_Voucher_Details.bid_entry_id) ";

				//Added By: Moiz Hakimi. 12-Mar-2007
				mysql = mysql + " , old_prescription ";

				mysql = mysql + " from ICS_Additional_Voucher_Details ";
				mysql = mysql + " where Entry_Id ='" + mEntryId.ToString() + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					txtLdgrName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)) + ""; //Ledger name
					txtAdd1.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1)) + ""; //Add_1
					txtAdd2.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2)) + ""; //Add_2
					txtPhone.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3)) + ""; //Phone
					txtStreetNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(4)) + ""; //Street
					txtBlockNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(5)) + ""; //Block NO
					txtCity.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(6)) + ""; //City
					txtCountry.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(7)) + ""; //Country
					txtRefOrderNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(8)) + ""; //Reference no order
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(9)))
					{
						txtRefrenceOrderDate.Value = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(9)) + ""; //Reference order date
					}
					else
					{
						txtRefrenceOrderDate.Text = "";
					}
					txtChequeNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(10)) + "";

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(11)))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtChequeDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(11));
					}
					else
					{
						txtChequeDate.Text = "";
					}

					txtCreditCardNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(12)) + "";
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(13)))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCreditCardDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(13));
					}
					else
					{
						txtCreditCardDate.Text = "";
					}

					if (!SystemProcedure2.IsItEmpty(((Array) mReturnValue).GetValue(14), SystemVariables.DataType.NumberType))
					{
						SystemCombo.SearchCombo(comCommon[SystemICSConstants.icsAVDFlex1], ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(14)));
					}

					txtDrawnOnBank.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(15)) + ""; //Drawn on bank

					//''''--------------------------------------------------------------------
					if (!SystemProcedure2.IsItEmpty(((Array) mReturnValue).GetValue(16), SystemVariables.DataType.NumberType))
					{
						SystemCombo.SearchCombo(comCommon[SystemICSConstants.icsAVDFlex2], ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(16)));
					}

					if (!SystemProcedure2.IsItEmpty(((Array) mReturnValue).GetValue(17), SystemVariables.DataType.NumberType))
					{
						SystemCombo.SearchCombo(comCommon[SystemICSConstants.icsAVDFlex3], ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(17)));
					}

					txtShipmentNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(18)) + ""; //Shipment no.
					txtPackingListNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(19)) + ""; //Packing list no.
					//txtReceivedBy.Text = mReturnValue(20) & ""         'Receieved by
					if (!SystemProcedure2.IsItEmpty(((Array) mReturnValue).GetValue(21), SystemVariables.DataType.NumberType))
					{
						SystemCombo.SearchCombo(comCommon[SystemICSConstants.icsAVDFlex4], ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(21)));
					}
					txtDeliveryLocation.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(22)) + ""; //Delivery SM_Location
					txtPaymentTerms.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(23)) + ""; //Payment terms.
					txtDeliveryTerms.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(24)) + ""; //Delivery terms.
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNAdditionalExpenses.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(25)); //'additional expenses.




					if (!SystemProcedure2.IsItEmpty(((Array) mReturnValue).GetValue(26), SystemVariables.DataType.NumberType))
					{
						SystemCombo.SearchCombo(comCommon[SystemICSConstants.icsAVDFlex5], ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(26)));
					}
					//''''--------------------------------------------------------------------

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Enable_Doc_Presc_In_Additional_Voucher_Details"]))
					{
						txtDistRSph.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(27)) + "";
						txtDistRCyl.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(28)) + "";
						txtDistRAxis.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(29)) + "";
						txtDistLSph.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(30)) + "";
						txtDistLCyl.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(31)) + "";
						txtDistLAxis.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(32)) + "";
						txtDistIPD.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(33)) + "";
						txtDistSGH.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(34)) + "";
						txtDistRLens.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(35)) + "";
						txtDistLLens.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(36)) + "";
						txtAddRSph.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(37)) + "";
						txtAddRCyl.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(38)) + "";
						txtAddRAxis.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(39)) + "";
						txtAddLSph.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(40)) + "";
						txtAddLCyl.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(41)) + "";
						txtAddLAxis.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(42)) + "";
						txtAddIPD.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(43)) + "";
						txtAddSGH.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(44)) + "";
						txtAddRLens.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(45)) + "";
						txtAddLLens.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(46)) + "";
						txtOldPrescription.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(49)) + "";
					}

					//. Date: 04-Dec-2007. To add an Additional Tab for Narration
					//-----------------------------------------------------------------------------
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Enable_Additional_Voucher_Details_2"]))
					{
						txtNarration2.Rtf = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(47)) + "";
					}
					//-----------------------------------------------------------------------------

					//. 13-12-2007
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_ics_bid")))
					{
						txtCommonTextBox[tcBidNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(48)) + "";
					}
				}
			}
			else if (!SystemProcedure2.IsItEmpty(mLdgrCd, SystemVariables.DataType.StringType))
			{ 
				mysql = "SELECT L_Ldgr_Name, A_Ldgr_Name , Addr_1, Addr_2, City, Country, ";
				mysql = mysql + " Phone From gl_ledger where ldgr_Cd='" + mLdgrCd + "'";
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
			else
			{
				txtRefrenceOrderDate.Text = "";
				txtCreditCardDate.Text = "";
				txtChequeDate.Text = "";
			}
		}
		//. 31/12/2007. To Fill DropDowns with Value Set.
		private void FillDropDown(Control pComboName, int pValueSetCode, string pObjectName)
		{
			int mEntryId = 0;
			string mysql = "Select entry_id from SM_Value_Set ";
			mysql = mysql + "where vs_object_type = '" + pObjectName + "' ";
			mysql = mysql + "and vs_code = " + pValueSetCode.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempValue))
			{
				//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
			}
			else
			{
				mEntryId = 0;
			}
			mysql = "select ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "VSSV_L_Name" : "VSSV_A_Name");
			mysql = mysql + " , vssv_code from SM_VS_Static_Value where entry_id =" + mEntryId.ToString();
			SystemCombo.FillComboWithItemData(pComboName, mysql);
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
			}
			catch
			{
			}

		}

		private void FindRoutine(string pObjectName)
		{
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
					case tcBidNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9018115, "2055")); 
						break;
					default:
						return;
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					if (mObjectName == "txtCommonTextBox")
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[mIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					}
				}
			}
			SystemVariables.gSkipTextBoxLostFocus = false;
		}





		//. 13-Dec-2007
		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
		}


		private void UCOkCancel1_OKClick(Object Sender, EventArgs e)
		{
			this.Hide();
		}

		//Private Sub txtReceivedBy_DropButtonClick()
		//Call FindRoutine("txtReceivedBy")
		//End Sub

		//Public Sub FindRoutine(pObjectName As String)
		//Dim mTempSearchValue As Variant
		//
		//Select Case pObjectName
		//    Case "txtReceivedBy"
		//        txtReceivedBy.Text = ""
		//        mTempSearchValue = FindItem(1000010, "925")
		//        If Not IsNull(mTempSearchValue) Then
		//            txtReceivedBy.Text = mTempSearchValue(1)
		//        End If
		//End Select
		//End Sub
	}
}