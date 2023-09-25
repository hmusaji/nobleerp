
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UpgradeHelpers;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmICSOrderHistory
		: System.Windows.Forms.Form
	{

		public frmICSOrderHistory()
{
InitializeComponent();
} 
 public  void frmICSOrderHistory_old()
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
			
			InitExtendedProperties();
		}
		void InitExtendedProperties()
		{
			this.grdPurchase.setScrollTips(false);
			this.grdSales.setScrollTips(false);
			this.grdCustomerEnquiry.setScrollTips(false);
		}


		private void frmICSOrderHistory_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private int mThisFormID = 0; //Assign the Formid for Each Form
		private object mSearchValue = null; //Variable for storing the searchvalue from the Find window
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0; //Enum for checking the current form mode
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
		 //This class checks for the rights given to the user
		public Control FirstFocusObject = null;

		private clsToolbar oThisFormToolBar = null;

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


		//The property below are used for storing the Search value returned by the Find window

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


		//These property set the Form mode to add mode or edit mode

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



		private void LoadData(string pReferenceNo)
		{
			object mTempValue = null;

			//----Customer enquiry

			string mSQL = " select mt.entry_id, mt.voucher_type, 'Customer Enquiry' as [Trans Type], mt.reference_no as [Ref.No.], mt.voucher_date as [Voucher Date] ";
			mSQL = mSQL + " , cust.l_ldgr_name as [Customer Name], sm.l_sman_name as [Salesman] ";
			mSQL = mSQL + " , iavd.city as [Cust/Vend. Ref.No], iavd.reference_order_no as [Enquiry Type], iavd.reference_order_date as [Closing Date] ";
			mSQL = mSQL + "  from ICS_Transaction mt ";
			mSQL = mSQL + " left outer join ics_additional_voucher_details iavd on mt.entry_id = iavd.entry_id ";
			mSQL = mSQL + " left outer join gl_ledger cust on mt.ldgr_cd = cust.ldgr_cd ";
			mSQL = mSQL + " left outer join SM_Salesman sm on mt.sman_cd = sm.sman_cd ";
			mSQL = mSQL + " Where mt.voucher_type = 2021 ";
			mSQL = mSQL + " and mt.reference_no = '" + pReferenceNo + "'";
			SqlDataReader rsTemp = null;
			SqlCommand sqlCommand = new SqlCommand(mSQL, SystemVariables.gConn);
			rsTemp = sqlCommand.ExecuteReader();
			bool rsTempDidRead = rsTemp.Read();
			if (rsTemp.HasRows)
			{
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdCustomerEnquiry.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdCustomerEnquiry.setDataSource((msdatasrc.DataSource) rsTemp);
				grdCustomerEnquiry.Cols[0].Visible = false;
				grdCustomerEnquiry.Cols[1].Visible = false;
				grdCustomerEnquiry.Cols[4].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
				grdCustomerEnquiry.Cols[9].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
				mTempValue = rsTemp["entry_id"];
			}
			else
			{
				MessageBox.Show("Reference No. not found ! ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			//----Offer


			string mSQL1 = " select mt.entry_id, mt.voucher_type, 'Offer' as [Trans Type], mt.reference_no as [Ref.No.], mt.voucher_date as [Voucher Date], '' as [Invoice No] ";
			mSQL1 = mSQL1 + " , cust.l_ldgr_name as [Customer Name], sm.l_sman_name as [Salesman] ";
			mSQL1 = mSQL1 + " , iavd.city as [Cust/Vend. Ref.No], iavd.cheque_date as [Delivery Date] ";
			mSQL1 = mSQL1 + " ,iavd.credit_card_date as [Deadline Date], mt.voucher_amt_fc as [Voucher Amount] ";
			mSQL1 = mSQL1 + "  from ICS_Transaction mt ";
			mSQL1 = mSQL1 + " left outer join ics_additional_voucher_details iavd on mt.entry_id = iavd.entry_id ";
			mSQL1 = mSQL1 + " left outer join gl_ledger cust on mt.ldgr_cd = cust.ldgr_cd ";
			mSQL1 = mSQL1 + " left outer join SM_Salesman sm on mt.sman_cd = sm.sman_cd ";
			mSQL1 = mSQL1 + " Where mt.voucher_type = 206 ";
			mSQL1 = mSQL1 + " and mt.reference_no = '" + pReferenceNo + "'";

			SqlCommand sqlCommand_2 = new SqlCommand(mSQL1, SystemVariables.gConn);
			rsTemp = sqlCommand_2.ExecuteReader();
			bool rsTempDidRead2 = rsTemp.Read();
			if (rsTempDidRead)
			{
				mTempValue = "";
				do 
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(mTempValue) != "")
					{
						mTempValue = ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + ", ";
					}
					mTempValue = ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + Conversion.Str(rsTemp["entry_id"]);
				}
				while(rsTemp.Read());
			}
			else
			{
				mTempValue = 0;
			}

			//----Sales Order
			string mSQL2 = " select mt.entry_id, mt.voucher_type, 'Sales Order' as [Trans Type], mt.reference_no as [Ref.No.], mt.voucher_date as [Voucher Date], '' as [Invoice No] ";
			mSQL2 = mSQL2 + " , cust.l_ldgr_name as [Customer Name], sm.l_sman_name as [Salesman] ";
			mSQL2 = mSQL2 + " , iavd.city as [Cust/Vend. Ref.No], iavd.cheque_date as [Delivery Date]";
			mSQL2 = mSQL2 + " ,iavd.credit_card_date as [Deadline Date], mt.voucher_amt_fc as [Voucher Amount] ";
			mSQL2 = mSQL2 + "  from ICS_Transaction mt ";
			mSQL2 = mSQL2 + " left outer join ics_additional_voucher_details iavd on mt.entry_id = iavd.entry_id ";
			mSQL2 = mSQL2 + " left outer join gl_ledger cust on mt.ldgr_cd = cust.ldgr_cd ";
			mSQL2 = mSQL2 + " inner join ICS_Transaction_Reference itr on mt.entry_id = itr.txn_entry_id ";
			mSQL2 = mSQL2 + " left outer join SM_Salesman sm on mt.sman_cd = sm.sman_cd ";
			mSQL2 = mSQL2 + " inner join ICS_Transaction mt1 on mt1.entry_id = itr.ref_entry_id ";
			mSQL2 = mSQL2 + " Where mt.voucher_type = 205 ";
			mSQL2 = mSQL2 + " and mt1.entry_id in  (" + ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + ")";

			SqlCommand sqlCommand_3 = new SqlCommand(mSQL2, SystemVariables.gConn);
			rsTemp = sqlCommand_3.ExecuteReader();
			bool rsTempDidRead3 = rsTemp.Read();
			if (rsTempDidRead)
			{
				mTempValue = "";
				do 
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(mTempValue) != "")
					{
						mTempValue = ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + ", ";
					}
					mTempValue = rsTemp["entry_id"];
				}
				while(rsTemp.Read());
			}
			else
			{
				mTempValue = 0;
			}



			//----Sales Invoice
			string mSQL3 = " select mt.entry_id, mt.voucher_type, 'Sales Invoice' as [Trans Type], mt.reference_no as [Ref.No.], mt.voucher_date as [Voucher Date], mt.voucher_no as [Invoice No]";
			mSQL3 = mSQL3 + "  , cust.l_ldgr_name as [Customer Name], sm.l_sman_name as [Salesman] ";
			mSQL3 = mSQL3 + " , iavd.city as [Cust/Vend. Ref.No], iavd.cheque_date as [Delivery Date] ";
			mSQL3 = mSQL3 + " ,iavd.credit_card_date as [Deadline Date], mt.voucher_amt_fc as [Voucher Amount] ";
			mSQL3 = mSQL3 + "  from ICS_Transaction mt ";
			mSQL3 = mSQL3 + " left outer join ics_additional_voucher_details iavd on mt.entry_id = iavd.entry_id ";
			mSQL3 = mSQL3 + " left outer join gl_ledger cust on mt.ldgr_cd = cust.ldgr_cd ";
			mSQL3 = mSQL3 + " inner join ICS_Transaction_Reference itr on mt.entry_id = itr.txn_entry_id ";
			mSQL3 = mSQL3 + " left outer join SM_Salesman sm on mt.sman_cd = sm.sman_cd ";
			mSQL3 = mSQL3 + " inner join ICS_Transaction mt1 on mt1.entry_id = itr.ref_entry_id ";
			mSQL3 = mSQL3 + " Where mt.voucher_type = 201 ";
			mSQL3 = mSQL3 + " and mt1.entry_id in (" + ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + ")";

			mSQL = mSQL1 + " union all " + mSQL2 + " union all " + mSQL3;
			SqlCommand sqlCommand_4 = new SqlCommand(mSQL, SystemVariables.gConn);
			rsTemp = sqlCommand_4.ExecuteReader();
			bool rsTempDidRead4 = rsTemp.Read();
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdSales.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdSales.setDataSource((msdatasrc.DataSource) rsTemp);
			grdSales.Cols[0].Visible = false;
			grdSales.Cols[1].Visible = false;
			grdSales.Cols[10].Format = "0.000";
			grdSales.Cols[11].Format = "0.000";
			grdSales.Cols[11].EditMask = "0.000";
			grdSales.Cols[4].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
			grdSales.Cols[7].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
			//----Purchase requisition
			mSQL1 = " select mt.entry_id, mt.voucher_type, 'Purchase Requisition' as [Trasaction Type], mt.reference_no as [Ref. No.] ";
			mSQL1 = mSQL1 + " , mt.voucher_date as [Date], '' as [Customer Name], '' as [Salesman] ";
			mSQL1 = mSQL1 + " , iavd.city as [Cust/Vend.Ref.No.], '' as [Order Type] , '' as [Aknowledge No.] ";
			mSQL1 = mSQL1 + " ,mt.voucher_amt_fc as [Voucher Amount] ";
			mSQL1 = mSQL1 + " from ICS_Transaction mt ";
			mSQL1 = mSQL1 + " left outer join ics_additional_voucher_details iavd on mt.entry_id = iavd.entry_id ";
			mSQL1 = mSQL1 + " Where mt.voucher_type = 2024 ";
			mSQL1 = mSQL1 + " and mt.reference_no = '" + pReferenceNo + "'";
			SqlCommand sqlCommand_5 = new SqlCommand(mSQL1, SystemVariables.gConn);
			rsTemp = sqlCommand_5.ExecuteReader();
			bool rsTempDidRead5 = rsTemp.Read();
			if (rsTempDidRead)
			{
				mTempValue = "";
				do 
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(mTempValue) != "")
					{
						mTempValue = ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + ", ";
					}
					mTempValue = rsTemp["entry_id"];
				}
				while(rsTemp.Read());
			}
			else
			{
				mTempValue = 0;
			}


			//----Purchase Order
			mSQL2 = "select mt.entry_id, mt.voucher_type, 'Purchase Order' as trans_type, mt.reference_no as [Ref.No] ";
			mSQL2 = mSQL2 + " ,mt.voucher_date as [Date], cust.l_ldgr_name as [Customer Name], sm.l_sman_name as [Salesman]  ";
			mSQL2 = mSQL2 + " ,iavd.city as [Cust/Vend.Ref.No], svs.vssv_l_name as [Order Type] ,iavd.drawn_on_bank as [Aknowledge No.] ";
			mSQL2 = mSQL2 + " , mt.voucher_amt_fc as [Voucher Amount] ";
			mSQL2 = mSQL2 + " from ICS_Transaction mt ";
			mSQL2 = mSQL2 + " inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";
			mSQL2 = mSQL2 + " left outer join ics_additional_voucher_details iavd on mt.entry_id = iavd.entry_id ";
			mSQL2 = mSQL2 + " inner join ICS_Transaction_Reference itr on mt.entry_id = itr.txn_entry_id ";
			mSQL2 = mSQL2 + " inner join SM_VS_Static_Value svs on iavd.trans_type = svs.vssv_code and svs.entry_id = 5 ";
			mSQL2 = mSQL2 + " left outer join gl_ledger cust on mt.ldgr_cd = cust.ldgr_cd ";
			mSQL2 = mSQL2 + " left outer join SM_Salesman sm on mt.sman_cd = sm.sman_cd ";
			mSQL2 = mSQL2 + " inner join ICS_Transaction mt1 on mt1.entry_id = itr.ref_entry_id ";
			mSQL2 = mSQL2 + " where mt.voucher_type in (105, 2026, 2027 ) ";
			mSQL2 = mSQL2 + " and mt1.entry_id in (" + ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + ") ";
			SqlCommand sqlCommand_6 = new SqlCommand(mSQL2, SystemVariables.gConn);
			rsTemp = sqlCommand_6.ExecuteReader();
			bool rsTempDidRead6 = rsTemp.Read();

			if (rsTempDidRead)
			{
				mTempValue = "";
				do 
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(mTempValue) != "")
					{
						mTempValue = ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + ", ";
					}
					mTempValue = ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + Conversion.Str(rsTemp["entry_id"]);
				}
				while(rsTemp.Read());
			}
			else
			{
				mTempValue = 0;
			}

			// ----Receipt of goods

			mSQL3 = "select mt.entry_id, mt.voucher_type, 'Recpt of Goods' as trans_type, mt.reference_no as [Ref.No] ";
			mSQL3 = mSQL3 + " ,mt.voucher_date as [Date], cust.l_ldgr_name as [Customer Name], sm.l_sman_name as [Salesman]  ";
			mSQL3 = mSQL3 + " ,iavd.city as [Cust/Vend.Ref.No], svs.vssv_l_name as [Order Type], iavd.drawn_on_bank as [Aknowledge No.] ";
			mSQL3 = mSQL3 + " , mt.voucher_amt_fc as [Voucher Amount] ";
			mSQL3 = mSQL3 + " from ICS_Transaction mt ";
			mSQL3 = mSQL3 + " inner join ICS_Transaction_Types ivt on mt.voucher_type = ivt.voucher_type ";
			mSQL3 = mSQL3 + " left outer join ics_additional_voucher_details iavd on mt.entry_id = iavd.entry_id ";
			mSQL3 = mSQL3 + " inner join ICS_Transaction_Reference itr on mt.entry_id = itr.txn_entry_id ";
			mSQL3 = mSQL3 + " left outer join SM_VS_Static_Value svs on iavd.trans_type = svs.vssv_code and svs.entry_id = 5 ";
			mSQL3 = mSQL3 + " left outer join gl_ledger cust on mt.ldgr_cd = cust.ldgr_cd ";
			mSQL3 = mSQL3 + " left outer join SM_Salesman sm on mt.sman_cd = sm.sman_cd ";
			mSQL3 = mSQL3 + " inner join ICS_Transaction mt1 on mt1.entry_id = itr.ref_entry_id ";
			mSQL3 = mSQL3 + " where ivt.parent_type = 103 ";
			mSQL3 = mSQL3 + " and mt1.entry_id in (" + ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + ") ";


			mSQL = mSQL1 + " union all " + mSQL2 + " union all " + mSQL3;
			SqlCommand sqlCommand_7 = new SqlCommand(mSQL, SystemVariables.gConn);
			rsTemp = sqlCommand_7.ExecuteReader();
			bool rsTempDidRead7 = rsTemp.Read();
			//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdPurchase.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdPurchase.setDataSource((msdatasrc.DataSource) rsTemp);
			grdPurchase.Cols[0].Visible = false;
			grdPurchase.Cols[1].Visible = false;
			grdPurchase.Cols[8].Visible = false; //order type
			grdPurchase.Cols[10].Format = "0.000";
			grdPurchase.Cols[10].EditMask = "0.000";
			grdPurchase.Cols[4].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;

		}

		private void cmdSearch_Click(Object eventSender, EventArgs eventArgs)
		{
			LoadData(txtRefNo.Text);
		}

		private void Form_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				if (KeyAscii == 27)
				{
					this.Close();
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

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			this.Top = 0;
			this.Left = 0;
			int i = 0;
			for (i = 0; i <= 25; i++)
			{
				cmbYear.AddItem(Conversion.Str(2004 + i));
				if ((2004 + i) == DateTime.Today.Year)
				{
					cmbYear.SelectedIndex = i;
				}
			}



			grdCustomerEnquiry.Font = grdCustomerEnquiry.Font.Change(name:"Microsoft Sans Serif", size:9);
			grdCustomerEnquiry.AutoResize = true;

			grdSales.Font = grdSales.Font.Change(name:"Microsoft Sans Serif", size:9);
			grdSales.AutoResize = true;

			grdPurchase.Font = grdPurchase.Font.Change(name:"Microsoft Sans Serif", size:9);
			grdPurchase.AutoResize = true;

		}

		private void grdCustomerEnquiry_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				SystemForms.GetSystemForm(320000, 2, Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdCustomerEnquiry.getCellText(grdCustomerEnquiry.Row, 0))), ReflectionHelper.GetPrimitiveValue<int>(grdCustomerEnquiry.getCellText(grdCustomerEnquiry.Row, 1)));
			}
			catch
			{
			}
		}

		private void grdPurchase_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				SystemForms.GetSystemForm(320000, 2, Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdPurchase.getCellText(grdPurchase.Row, 0))), ReflectionHelper.GetPrimitiveValue<int>(grdPurchase.getCellText(grdPurchase.Row, 1)));
			}
			catch
			{
			}
		}

		private void grdSales_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				SystemForms.GetSystemForm(320000, 2, Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(grdSales.getCellText(grdSales.Row, 0))), ReflectionHelper.GetPrimitiveValue<int>(grdSales.getCellText(grdSales.Row, 1)));
			}
			catch
			{
			}
		}

		private void txtOffer_DropButtonClick(Object Sender, EventArgs e)
		{
			string mSQL = "";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(3000206, "418", " voucher_type = 205 and year(voucher_date) = " + cmbYear.Text));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				EmptyTextBox();
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtOffer.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				GetOfferNo(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
			}
		}
		private void GetOfferNo(int pEntryId)
		{
			string mSQL = " select mt.reference_no from ICS_Transaction mt inner join ICS_Transaction_Reference itr on itr.ref_entry_id = mt.entry_id ";
			mSQL = mSQL + " where itr.txn_entry_id = " + pEntryId.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtRefNo.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				cmdSearch_Click(cmdSearch, new EventArgs());
			}
		}


		private void txtOffer_KeyDown(Object Sender, System.Windows.Forms.TextBox.KeyDownEventArgs e)
		{
			Keys KeyCode = (Keys) e.KeyCode;
			int Shift = e.Shift;
			if (KeyCode == Keys.F2)
			{
				txtOffer_DropButtonClick(txtOffer, null);
				return;
			}
			string mSQL = "";
			object mReturnValue = null;


			if (KeyCode == Keys.PageUp)
			{ //Page Up
				if (txtOffer.Text != "")
				{
					mSQL = "select top 1 entry_id, reference_no from ICS_Transaction where reference_no < '" + txtOffer.Text + "' and voucher_type = 205 and year(voucher_date) = " + cmbYear.Text + " order by reference_no desc";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtOffer.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						GetOfferNo(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
					}
				}
			}
			if (KeyCode == Keys.PageDown)
			{ //Page Down
				if (txtOffer.Text != "")
				{
					mSQL = "select top 1 entry_id, reference_no from ICS_Transaction where reference_no > '" + txtOffer.Text + "' and voucher_type = 205 and year(voucher_date) = " + cmbYear.Text + " order by reference_no asc";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtOffer.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						GetOfferNo(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
					}
				}
			}

		}

		private void txtOrder_DropButtonClick(Object Sender, EventArgs e)
		{
			string mSQL = "";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(3000206, "418", " voucher_type = 205 and year(voucher_date) = " + cmbYear.Text));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				EmptyTextBox();
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtOrder.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				GetOrderNo(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
			}

		}
		private void GetOrderNo(int pEntryId)
		{
			string mSQL = " select mt.reference_no from ICS_Transaction mt inner join ICS_Transaction_Reference itr on itr.ref_entry_id = mt.entry_id ";
			mSQL = mSQL + " where itr.txn_entry_id = " + pEntryId.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtRefNo.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				cmdSearch_Click(cmdSearch, new EventArgs());
			}
		}

		private void txtOrder_KeyDown(Object Sender, System.Windows.Forms.TextBox.KeyDownEventArgs e)
		{
			Keys KeyCode = (Keys) e.KeyCode;
			int Shift = e.Shift;
			if (KeyCode == Keys.F2)
			{
				txtOrder_DropButtonClick(txtOrder, null);
				return;
			}
			string mSQL = "";
			object mReturnValue = null;


			if (KeyCode == Keys.PageUp)
			{ //Page Up
				if (txtOrder.Text != "")
				{
					mSQL = "select top 1 entry_id, reference_no from ICS_Transaction where reference_no < '" + txtOrder.Text + "' and voucher_type = 205 and year(voucher_date) = " + cmbYear.Text + " order by reference_no desc";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtOrder.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						GetOrderNo(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
					}
				}
			}
			if (KeyCode == Keys.PageDown)
			{ //Page Down
				if (txtOrder.Text != "")
				{
					mSQL = "select top 1 entry_id, reference_no from ICS_Transaction where reference_no > '" + txtOrder.Text + "' and voucher_type = 205 and year(voucher_date) = " + cmbYear.Text + " order by reference_no asc";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtOrder.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						GetOrderNo(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
					}
				}
			}
		}

		private void txtPONo_DropButtonClick(Object Sender, EventArgs e)
		{
			string mSQL = "";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(3000206, "418", " voucher_type = 105 and year(voucher_date) = " + cmbYear.Text));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				EmptyTextBox();
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtPONo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				GetPONO(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
			}
		}
		private void GetPONO(int pEntryId)
		{
			string mSQL = " select mt.reference_no from ICS_Transaction mt inner join ICS_Transaction_Reference itr on itr.ref_entry_id = mt.entry_id ";
			mSQL = mSQL + " where itr.txn_entry_id = " + pEntryId.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtRefNo.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				cmdSearch_Click(cmdSearch, new EventArgs());
			}
		}
		private void txtPONo_KeyDown(Object Sender, System.Windows.Forms.TextBox.KeyDownEventArgs e)
		{
			Keys KeyCode = (Keys) e.KeyCode;
			int Shift = e.Shift;
			string mSQL = "";
			object mReturnValue = null;

			if (KeyCode == Keys.F2)
			{
				txtPONo_DropButtonClick(txtPONo, null);
				return;
			}

			if (KeyCode == Keys.PageUp)
			{ //Page Up
				if (txtPONo.Text != "")
				{
					mSQL = "select top 1 entry_id, reference_no from ICS_Transaction where reference_no < '" + txtPONo.Text + "' and voucher_type = 105 and year(voucher_date) = " + cmbYear.Text + " order by reference_no desc";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtPONo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						GetPONO(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
					}
				}
			}


			if (KeyCode == Keys.PageDown)
			{ //Page Down
				if (txtPONo.Text != "")
				{
					mSQL = "select top 1 entry_id, reference_no from ICS_Transaction where reference_no > '" + txtPONo.Text + "' and voucher_type = 105 and year(voucher_date) = " + cmbYear.Text + " order by reference_no asc";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtPONo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						GetPONO(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
					}
				}
			}
		}

		private void txtRefNo_DropButtonClick(Object Sender, EventArgs e)
		{

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(3000206, "418", " voucher_type  = 2021 and year(voucher_date) = " + cmbYear.Text));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				EmptyTextBox();
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtRefNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				cmdSearch_Click(cmdSearch, new EventArgs());
			}
		}

		private void txtRefNo_KeyDown(Object Sender, System.Windows.Forms.TextBox.KeyDownEventArgs e)
		{
			Keys KeyCode = (Keys) e.KeyCode;
			int Shift = e.Shift;
			string mSQL = "";
			object mReturnValue = null;

			if (KeyCode == Keys.F2)
			{
				txtRefNo_DropButtonClick(txtRefNo, null);
				return;
			}
			if (KeyCode == Keys.PageUp)
			{ //Page Up
				if (txtRefNo.Text != "")
				{
					mSQL = "select top 1 reference_no from ICS_Transaction where reference_no < '" + txtRefNo.Text + "' and voucher_type = 2021 and year(voucher_date) = " + cmbYear.Text + " order by reference_no desc";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtRefNo.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
						cmdSearch_Click(cmdSearch, new EventArgs());
					}
				}
			}


			if (KeyCode == Keys.PageDown)
			{ //Page Down
				if (txtRefNo.Text != "")
				{
					mSQL = "select top 1 reference_no from ICS_Transaction where reference_no > '" + txtRefNo.Text + "' and voucher_type = 2021 and year(voucher_date) = " + cmbYear.Text + " order by reference_no asc";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtRefNo.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
						cmdSearch_Click(cmdSearch, new EventArgs());
					}
				}
			}
		}

		private void txtSalesInvNo_DropButtonClick(Object Sender, EventArgs e)
		{
			string mSQL = "";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(3000206, "418", " voucher_type = 201 "));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				EmptyTextBox();
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtSalesInvNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				GetSalesInvNo(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
			}
		}
		private void GetSalesInvNo(int pEntryId)
		{
			object mReturnValue = null;
			string mSQL = "";
			if (txtSalesInvNo.Text != "")
			{
				mSQL = " select mt.reference_no from ICS_Transaction mt inner join ICS_Transaction_Reference itr on itr.ref_entry_id = mt.entry_id ";
				mSQL = mSQL + " where itr.txn_entry_id = " + pEntryId.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtRefNo.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					cmdSearch_Click(cmdSearch, new EventArgs());
				}
			}
		}
		private void txtSalesInvNo_KeyDown(Object Sender, System.Windows.Forms.TextBox.KeyDownEventArgs e)
		{
			Keys KeyCode = (Keys) e.KeyCode;
			int Shift = e.Shift;
			if (KeyCode == Keys.F2)
			{
				txtSalesInvNo_DropButtonClick(txtSalesInvNo, null);
				return;
			}

			string mSQL = "";
			object mReturnValue = null;


			if (KeyCode == Keys.PageUp)
			{ //Page Up
				if (txtSalesInvNo.Text != "")
				{
					mSQL = "select top 1 entry_id, reference_no from ICS_Transaction where reference_no < '" + txtSalesInvNo.Text + "' and voucher_type = 201 order by reference_no desc";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtSalesInvNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						GetSalesInvNo(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
					}
				}
			}
			if (KeyCode == Keys.PageDown)
			{ //Page Down
				if (txtSalesInvNo.Text != "")
				{
					mSQL = "select top 1 entry_id, reference_no from ICS_Transaction where reference_no > '" + txtSalesInvNo.Text + "' and voucher_type = 201 order by reference_no asc";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtSalesInvNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						GetSalesInvNo(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
					}
				}
			}
		}


		private void EmptyTextBox()
		{
			txtRefNo.Text = "";
			txtSalesInvNo.Text = "";
			txtPONo.Text = "";
			txtOffer.Text = "";
			txtOrder.Text = "";
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}