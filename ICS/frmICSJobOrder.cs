
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmICSJobOrder
		: System.Windows.Forms.Form
	{

		public frmICSJobOrder()
{
InitializeComponent();
} 
 public  void frmICSJobOrder_old()
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


		private void frmICSJobOrder_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private DataSet rsProductCodeList = null;

		private int mThisFormID = 0;
		private object mSearchValue = null;
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

		private clsToolbar oThisFormToolBar = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private bool mCurrentSearchOnInternalCodes = false;

		private XArrayHelper aVoucherDetails = null;
		private string mParentVoucherTimeStamp = "";
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;
		private System.Windows.Forms.TextBox FirstFocusObject = null;

		private bool mFirstGridFocus = false;
		private bool mFirstOutGridFocus = false;

		private const int mMaxArrayCols = 12;

		private const int gccLineNoColumn = 0;
		private const int gccProductCodeColumn = 1;
		private const int gccProductNameColumn = 2;
		private const int gccActualSizeColumn = 3;
		private const int gccPrintSizeColumn = 4;
		private const int gccPaperKindColumn = 5;
		private const int gccCopiesColumn = 6;
		private const int gccQtyColumn = 7;
		private const int gccRateColumn = 8;
		private const int gccAmountColumn = 9;
		private const int gccInkColorColumn = 10;
		private const int gccRemarksColumn = 11;

		private const int cCpPartNo = 0;
		private const int cCpProdName = 1;

		private const string cGridColor = "&HDCE2DC";


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


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			string mysql = "";
			try
			{

				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsVoucherTypes.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsVoucherTypes.MoveFirst();
				SystemVariables.rsVoucherTypes.Find("voucher_type = 205"); //& Str(ThisVoucherType)

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
				this.Top = 0;
				this.Left = 0;
				mCurrentSearchOnInternalCodes = false;


				mFirstGridFocus = true;
				mFirstOutGridFocus = true;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginDeleteLineButtonWithGroup = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;
				oThisFormToolBar.ShowMoveRecordNextButton = true;
				oThisFormToolBar.ShowMoveRecordPreviousButton = true;
				oThisFormToolBar.ShowPostButton = true;
				this.WindowState = FormWindowState.Maximized;
				txtCommonTextBox[1].TabIndex = 1;
				txtRemark.TabIndex = 2;
				txtVoucherDate.Value = SystemVariables.gCurrentDate;

				//**--define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, cGridColor, cGridColor);

				//**--define voucher grid columns
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Line_No_In_Details"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Product Code", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Part_No_In_Details"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Product Name", 3000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbMastersList", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Name_In_Details"]), false, false, false, false, 200);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Actual Size", 1300, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Print Size", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Kind of Paper", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "No. of Copies", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Qty Required", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Qty_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Qty_In_Details"]), 12);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Unit Price", 1000, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Rate_In_Details"]), 12, "", "", false, "", 0, true);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Unit Total", 1200, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Amount_In_Details"]), ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Amount_In_Details"]), false, false, true, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Amount_In_Details"]), 12, "", "", false, "", 0, true);

				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ink Color", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true);


				//setting voucher details grid properties
				aVoucherDetails = new XArrayHelper();
				SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, false);
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				//''''*************************************************************************

				//rsVoucherTypes.filter = adFilterNone

				Application.DoEvents();
				grdVoucherDetails.Visible = true;

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				fraVoucherType.Visible = Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_cash_credit_on_header"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				optVoucherType[0].Visible = Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_cash_credit_on_header"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				optVoucherType[1].Visible = Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_cash_credit_on_header"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[SystemICSConstants.tcCashCode].Visible = Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_cash_credit_on_header"]);

				AddRecord();
				this.Show();
				Application.DoEvents();

				FirstFocusObject = txtCommonTextBox[SystemICSConstants.tcLocationCode];
				txtCommonTextBox[SystemICSConstants.tcLocationCode].Focus();
				//''''*************************************************************************
				//'***setting form mode to add initially
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				//''''*************************************************************************
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}

		}

		public void findRecord()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				string mysql = " mt.voucher_type = " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["voucher_type"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["find_id"]), "", mysql, true, true));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{

					//''the code below helps in coming out of txtCommonTextBox(tcProductCode) lost focus event
					txtVoucherDate.Focus();
					Application.DoEvents();

					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));

					GetRecord(mSearchValue);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}



		public void GetRecord(object pSearchValue)
		{
			//''''*************************************************************************
			//This routine is called after getting the value from Find window or
			//''''*************************************************************************

			DataSet rsLocalRec = null;
			string mysql = "";
			object mReturnValues = null;
			int Cnt = 0;
			object tempValue = null;

			try
			{

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
				if (Object.Equals(pSearchValue, null) || Convert.IsDBNull(pSearchValue))
				{
					return;
				}

				SystemProcedure2.ClearTextBox(this);
				SystemProcedure2.ClearNumberBox(this);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = " select * from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]) + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

				rsLocalRec = new DataSet();
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLocalRec.Tables.Clear();
				adap.Fill(rsLocalRec);
				if (rsLocalRec.Tables[0].Rows.Count != 0)
				{
					CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
					//UPGRADE_WARNING: (1068) pSearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					SearchValue = ReflectionHelper.GetPrimitiveValue(pSearchValue);

					//''''*************************************************************************
					//'''Get the Location information
					mysql = "select locat_no,";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " from SM_Location where locat_cd=" + Conversion.Str(rsLocalRec.Tables[0].Rows[0]["locat_cd"]);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValues = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[SystemICSConstants.tcLocationCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValues).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValues() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDisplayLabel[SystemICSConstants.dcLocationName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValues).GetValue(1));
					//''''*************************************************************************
					//''''*************************************************************************

					//''''*************************************************************************
					//'''If the date does not fall in the current GL period then disable the control
					//'''Else enable the control
					//'''Enable the control in the Addrecord Method .
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtVoucherDate.Value = rsLocalRec.Tables[0].Rows[0]["voucher_date"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					this.txtVoucherDate.Enabled = Convert.ToDateTime(rsLocalRec.Tables[0].Rows[0]["voucher_date"]) >= DateTime.Parse(SystemVariables.gCurrentPeriodStarts) && Convert.ToDateTime(rsLocalRec.Tables[0].Rows[0]["voucher_date"]) <= DateTime.Parse(SystemVariables.gNextPeriodEnds);

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					this.txtCommonTextBox[SystemICSConstants.tcVoucherNo].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["voucher_no"]) + "";
					//Me.txtCommonTextBox(tcReferenceNo).Text = .Fields("reference_no") & ""

					//
					//            '''''*************************************************************************
					//            ''''check voucher status of Inventory and GL
					//            If GetSystemPreferenceSetting("show_post_to_gl_status") = True Then
					//                mPostedToGLStatus = .Fields("posted_gl").Value
					//                Call CheckPostedStatus(1, "GLStatus", mPostedToGLStatus, CurrentFormMode, 1)
					//            End If
					//
					//            If GetSystemPreferenceSetting("show_post_to_ics_status") = True Then
					//                mPostedToICSStatus = .Fields("posted_invnt").Value
					//                Call CheckPostedStatus(1, "InvntStatus", mPostedToICSStatus, CurrentFormMode, 2)
					//            End If
					//            '''''*************************************************************************


					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_remarks_On_header"]))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtRemark.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["comments"]) + "";
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_ledger_on_header"]))
					{
						mysql = "select ldgr_no ";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mysql = mysql + " from gl_ledger where ldgr_cd=" + Convert.ToString(rsLocalRec.Tables[0].Rows[0]["ldgr_cd"]);
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						tempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(tempValue))
						{
							//UPGRADE_WARNING: (1068) tempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							this.txtCommonTextBox[SystemICSConstants.tcLedgerCode].Text = ReflectionHelper.GetPrimitiveValue<string>(tempValue);
							this.txtCommonTextBox_Leave(this, new EventArgs());
						}
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Salesman"]))
					{
						mysql = "select sman_no ";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mysql = mysql + " from sm_salesman where sman_cd=" + Convert.ToString(rsLocalRec.Tables[0].Rows[0]["Sman_cd"]);
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						tempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(tempValue))
						{
							//UPGRADE_WARNING: (1068) tempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							this.txtCommonTextBox[SystemICSConstants.tcSalesmanCode].Text = ReflectionHelper.GetPrimitiveValue<string>(tempValue);
							this.txtCommonTextBox_Leave(this, new EventArgs());
						}
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtDiscount.Value = rsLocalRec.Tables[0].Rows[0]["Discount_Amt_FC"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtNetAmount.Value = rsLocalRec.Tables[0].Rows[0]["Net_Amt_FC"];


					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(rsLocalRec.Tables[0].Rows[0]["is_cash"])) == TriState.True)
					{

						mysql = "select ldgr_no ";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mysql = mysql + " from gl_ledger where ldgr_cd='" + Convert.ToString(rsLocalRec.Tables[0].Rows[0]["credit_card_ldgr_cd"]) + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValues = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValues))
						{
							//UPGRADE_WARNING: (1068) mReturnValues of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonTextBox[SystemICSConstants.tcCCCode].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValues);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							txtCCAmt.Value = rsLocalRec.Tables[0].Rows[0]["credit_card_amt_fc"];
						}

						mysql = "select ldgr_no ";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mysql = mysql + " from gl_ledger where ldgr_cd='" + Convert.ToString(rsLocalRec.Tables[0].Rows[0]["cash_cd"]) + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValues = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValues))
						{
							//UPGRADE_WARNING: (1068) mReturnValues of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonTextBox[SystemICSConstants.tcCashCode].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValues);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							txtCashAmt.Value = rsLocalRec.Tables[0].Rows[0]["cash_amt_fc"];
						}

						optVoucherType[1].Checked = true;
					}
					else
					{
						txtCommonTextBox[SystemICSConstants.tcCashCode].Text = "";
						optVoucherType[0].Checked = true;
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					Check1.CheckState = (rsLocalRec.Tables[0].Rows[0].IsNull("Additional_Field_1")) ? CheckState.Unchecked : ((CheckState) Convert.ToInt32(rsLocalRec.Tables[0].Rows[0]["Additional_Field_1"]));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					Check2.CheckState = (rsLocalRec.Tables[0].Rows[0].IsNull("Additional_Field_2")) ? CheckState.Unchecked : ((CheckState) Convert.ToInt32(rsLocalRec.Tables[0].Rows[0]["Additional_Field_2"]));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					Check3.CheckState = (rsLocalRec.Tables[0].Rows[0].IsNull("Additional_Field_3")) ? CheckState.Unchecked : ((CheckState) Convert.ToInt32(rsLocalRec.Tables[0].Rows[0]["Additional_Field_3"]));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					Check4.CheckState = (rsLocalRec.Tables[0].Rows[0].IsNull("Additional_Field_4")) ? CheckState.Unchecked : ((CheckState) Convert.ToInt32(rsLocalRec.Tables[0].Rows[0]["Additional_Field_4"]));

				}

				mysql = "select lt.line_no, ICS_Item.part_no , lt.Prod_Name ";
				mysql = mysql + " , lt.Base_Qty ";
				mysql = mysql + " , ICS_Unit.symbol , ICS_Item.prod_cd, ICS_Item.serialized , lt.non_stock_manual_cost, lt.Reference_No ";
				mysql = mysql + " , lt.item_type_cd, lt.item_cost, FC_Rate, FC_Amount ";
				mysql = mysql + " , Additional_Field_1, Additional_Field_2, Additional_Field_3, Additional_Field_4, Additional_Field_5";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]) + " as lt ";
				mysql = mysql + " inner join ICS_Item on  lt.prod_cd = ICS_Item.prod_cd ";
				mysql = mysql + " inner join ICS_Item_Unit_Details aud on aud.unit_entry_id = lt.unit_entry_id";
				mysql = mysql + " inner join ICS_Unit on aud.alt_unit_cd = ICS_Unit.unit_cd ";
				mysql = mysql + " where lt.entry_id =  " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				mysql = mysql + " order by 1 ";


				SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, true);

				//DoEvents
				SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLocalRec.Tables.Clear();
				adap_2.Fill(rsLocalRec);
				foreach (DataRow iteration_row in rsLocalRec.Tables[0].Rows)
				{
					SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, Cnt, false);

					aVoucherDetails.SetValue(Cnt + 1, Cnt, gccLineNoColumn);
					aVoucherDetails.SetValue(Convert.ToString(iteration_row["part_no"]).Trim(), Cnt, gccProductCodeColumn);
					aVoucherDetails.SetValue(Convert.ToString(iteration_row["prod_name"]).Trim(), Cnt, gccProductNameColumn);
					aVoucherDetails.SetValue(Convert.ToString(iteration_row["Reference_No"]).Trim(), Cnt, gccRemarksColumn);
					aVoucherDetails.SetValue(iteration_row["Base_Qty"], Cnt, gccQtyColumn);
					aVoucherDetails.SetValue(iteration_row["FC_Rate"], Cnt, gccRateColumn);
					aVoucherDetails.SetValue(iteration_row["FC_Amount"], Cnt, gccAmountColumn);

					aVoucherDetails.SetValue(Convert.ToString(iteration_row["Additional_Field_1"]).Trim(), Cnt, gccActualSizeColumn);
					aVoucherDetails.SetValue(Convert.ToString(iteration_row["Additional_Field_2"]).Trim(), Cnt, gccPrintSizeColumn);
					aVoucherDetails.SetValue(Convert.ToString(iteration_row["Additional_Field_3"]).Trim(), Cnt, gccPaperKindColumn);
					aVoucherDetails.SetValue(Convert.ToString(iteration_row["Additional_Field_4"]).Trim(), Cnt, gccCopiesColumn);
					aVoucherDetails.SetValue(Convert.ToString(iteration_row["Additional_Field_5"]).Trim(), Cnt, gccInkColorColumn);

					Cnt++;
				}

				grdVoucherDetails_GotFocus(grdVoucherDetails, new EventArgs());
				CalculateTotals(0, 0, true);
				grdVoucherDetails.Refresh();
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Enabled = true;

				rsLocalRec = null;

				mysql = " select * from ICS_Additional_Voucher_Details where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

				rsLocalRec = new DataSet();
				SqlDataAdapter adap_3 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLocalRec.Tables.Clear();
				adap_3.Fill(rsLocalRec);
				if (rsLocalRec.Tables[0].Rows.Count != 0)
				{

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txt1Copy.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["Additional_Field_1"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txt2Copy.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["Additional_Field_2"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txt3Copy.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["Additional_Field_3"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txt4Copy.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["Additional_Field_4"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtNumbering.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["Additional_Field_5"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtPerforation.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["Additional_Field_6"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCoverNo.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["Additional_Field_7"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCoverColor.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["Additional_Field_8"]) + "";
				}

				rsLocalRec = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]), "GetRecord");
			}

		}


		public void PrintReport(int pEntryId = 0)
		{

			int mEntryId = 0;
			string mysql = "";
			object mCrystalReportEntryIDColumnID = null;
			SqlDataReader rsTempRec = null;

			try
			{

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
				}
				else
				{
					if (!SystemProcedure2.IsItEmpty(pEntryId))
					{
						mEntryId = pEntryId;
					}
					else
					{
						return;
					}
				}

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["use_crystal_reports_for_print"])) == TriState.True)
				{
					mysql = " select report_id, Show_Printer from  ICS_Print_Task_Detail ";
					mysql = mysql + " WHERE Voucher_Type = " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Voucher_Type"]);

					SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
					rsTempRec = sqlCommand.ExecuteReader();
					rsTempRec.Read();

					if (rsTempRec.HasRows)
					{
						do 
						{
							mysql = "select column_id from SM_REPORT_FIELDS ";
							mysql = mysql + " where report_id = " + Convert.ToString(rsTempRec["report_id"]);
							mysql = mysql + " and entry_id_column = 1 ";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mCrystalReportEntryIDColumnID = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mCrystalReportEntryIDColumnID))
							{
								MessageBox.Show("Error: Incomplete Report Information!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								return;
							}

							SystemReports.PrintCrystalReport(mEntryId, Convert.ToInt32(rsTempRec["report_id"]), false, "", Convert.ToBoolean(rsTempRec["Show_Printer"]));
							// Call GetCrystalReport(.Fields("report_id"), 2, Str(mCrystalReportEntryIDColumnID), Str(mEntryID))
						}
						while(rsTempRec.Read());
					}
					else
					{
						MessageBox.Show("Error: No Report Information  Found!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}
		private bool isInitializingComponent;
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


		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				tabMain.Width = this.Width - 33;
				tabMain.Height = this.Height - 340;

				grdVoucherDetails.Width = tabMain.Width - 3;
				grdVoucherDetails.Height = tabMain.Height - 25;

				frameBottom.Top = this.Height - 153;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
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

					//Refresh the ICS_Item recordset when F5 is pressed
					if (Shift == 0 && KeyCode == 116)
					{
						if (ActiveControl.Name.ToLower() == ("grdVoucherDetails").ToLower() && !mFirstGridFocus)
						{
							RefreshRecordset(false);
							KeyCode = 0;
						}
					}


					if (Shift == 4 && (KeyCode == 37 || KeyCode == 39))
					{
						//If Not IsItEmpty(mSearchValue, NumberType) Then
						//    If CLng(mSearchValue) > 0 Then
						if (!UserAccess.AllowUserDisplay)
						{
							MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						RecordNavidate(KeyCode, Convert.ToInt32(Conversion.Val(txtCommonTextBox[SystemICSConstants.tcVoucherNo].Text)), Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["voucher_type"]), Convert.ToInt32(Conversion.Val(txtCommonTextBox[SystemICSConstants.tcLocationCode].Text)));
						KeyCode = 0;
						//    End If
						//End If
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
		public void CloseForm()
		{
			this.Close();
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
				try
				{
					string mysql = "";

					if (mFirstGridFocus)
					{
						SystemGrid.DefineSystemGridCombo(cmbMastersList);
						RefreshRecordset();
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						grdVoucherDetails.PostMsg(1);

						grdVoucherDetails_OnAddNew(grdVoucherDetails, new EventArgs());
						mFirstGridFocus = false;
					}

					return;
				}
				catch (System.Exception excep)
				{
					MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			catch
			{
			}
		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			try
			{

				int Cnt = 0;
				object mCurrentbal = null;

				if (grdVoucherDetails.Row != ReflectionHelper.GetPrimitiveValue<double>(LastRow))
				{
					if (grdVoucherDetails.AddNewMode == C1.Win.C1TrueDBGrid.AddNewModeEnum.NoAddNew)
					{
						ShowProductDetails(false);
					}
					else if (grdVoucherDetails.AddNewMode == C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent)
					{ 
						ShowProductDetails(true);
					}
					else
					{
						ShowProductDetails(false);
					}
				}
				else
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!mFirstGridFocus && aVoucherDetails.GetLength(0) > 0 && Convert.IsDBNull(LastRow))
					{
						ShowProductDetails(false);
					}
				}

				if (grdVoucherDetails.Col > 0 && !mFirstGridFocus)
				{
					switch(grdVoucherDetails.Col)
					{
						case gccProductCodeColumn : case gccProductNameColumn : 
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
							cmbMastersList.setDataSource((msdatasrc.DataSource) rsProductCodeList); 
							break;
					}
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}


		}

		private void RefreshRecordset(bool pCallComboRowChange = true)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
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
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void GetProductListSQL(ref string pSQL)
		{
			//''''*************************************************************************
			//'''Product List query, alone with Base Unit and stock info.
			//''''*************************************************************************
			object mTempReturnValue = null;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				pSQL = "select part_no, ";
				pSQL = pSQL + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name as prod_name" : "a_prod_name as prod_name");
				pSQL = pSQL + " , ICS_Unit.symbol, ";
				pSQL = pSQL + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name" : "a_group_name") + " as group_name, ICS_Item.cost,";
				pSQL = pSQL + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cat_name" : "a_cat_name") + " as cat_name ";
				pSQL = pSQL + " ,isnull(pld.stock_in_hand, 0) as stock_in_hand, ";
				pSQL = pSQL + " isnull(pld.stock_allocated, 0) as stock_allocated, ";
				pSQL = pSQL + " isnull(pld.stock_available, 0) as stock_available, ";
				pSQL = pSQL + " isnull(pld.stock_in_transit, 0) as stock_in_transit, ";
				pSQL = pSQL + " isnull(pld.stock_on_order, 0) as stock_on_order, ICS_Item.prod_cd ";
				pSQL = pSQL + " , ICS_Item.sale_rate1 ";
				pSQL = pSQL + " , ICS_Item.purchase_rate , serialized ";
				pSQL = pSQL + " from ICS_Item ";
				pSQL = pSQL + " inner join ICS_Unit on ICS_Item.base_unit_cd = ICS_Unit.unit_cd ";
				pSQL = pSQL + " inner join ICS_Item_group on ICS_Item_group.group_cd = ICS_Item.group_cd ";
				pSQL = pSQL + " inner join ICS_Item_category on ICS_Item_category.cat_cd = ICS_Item.cat_cd ";
				pSQL = pSQL + " left outer join (select * from ICS_Item_location_details ";
				if (SystemProcedure2.IsItEmpty(this.txtCommonTextBox[SystemICSConstants.tcLocationCode].Text, SystemVariables.DataType.NumberType))
				{
					pSQL = pSQL + " where locat_cd = " + Conversion.Str(SystemVariables.gLoggedInUserLocationCode);
				}
				else
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select locat_cd from SM_Location where locat_no = " + Conversion.Str(this.txtCommonTextBox[SystemICSConstants.tcLocationCode].Text)));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempReturnValue))
					{
						pSQL = pSQL + " where locat_cd = 0";
					}
					else
					{
						pSQL = pSQL + " where locat_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
					}
				}
				pSQL = pSQL + " ) as pld on ICS_Item.prod_cd = pld.prod_cd ";
				pSQL = pSQL + " where ICS_Item.discontinued = 0 ";
				//pSQL = pSQL & " and item_type_cd = 1 "

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("assembly_product")))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToDouble(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["module_id"]) != 6)
					{
						//---------------Commented to include rebuilding of Items-----
						//pSQL = pSQL & " and ICS_Item.item_type_cd not in(3,4) "
						pSQL = pSQL + " and ICS_Item.item_type_cd not in(4) ";
					}
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_non_inventory_in_details"]))
				{
					pSQL = pSQL + " and it.affect_stock = 1 ";
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!mFirstGridFocus)
				{
					grdVoucherDetails.Columns[gccLineNoColumn].Text = (grdVoucherDetails.RowCount + 1).ToString();
				}

				InitialiseGridValues();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void InitialiseGridValues()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069

			//If grdVoucherDetails.Columns(gccBuildSerialNoColumn).Visible = True Then
			//    grdVoucherDetails.Columns(gccBuildSerializedColumn).Text = vbFalse
			//End If

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			//'***************************************************************************''
			//'This routine handles the listbox attributes on the grid according to the
			//'datasource. It gives the width of columns in the listbox and sort order.
			//'***************************************************************************''
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				int Cnt = 0;
				cmbMastersList.Width = 0;
				C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
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
							if (Cnt < 2)
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
										//.Width = grdVoucherDetails.Columns(gccBuilUnitSymbolColumn).Width 
										//.Visible = True 
										break;
									case 3 : 
										//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
										//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021 
										if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Group_In_List"])) == TriState.True)
										{
											withVar.Width = 120;
											withVar.Visible = true;
										}
										else
										{
											withVar.Width = 0;
											withVar.Visible = false;
										} 
										break;
									case 4 : 
										//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
										//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021 
										if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Category_In_List"])) == TriState.True)
										{
											withVar.Width = 120;
											withVar.Visible = true;
										}
										else
										{
											withVar.Width = 0;
											withVar.Visible = false;
										} 
										break;
									case 18 : 
										withVar.Visible = true; 
										break;
								}
								if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
								{
									withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
								}
								else
								{
									withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
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
					default:
						cmbMastersList.Width = 0; 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			//'***************************************************************************''
			//'This routine handles the navigation for next column after a value is selected
			//'from listbox in the grid.
			//'***************************************************************************''
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				switch(grdVoucherDetails.Col)
				{
					case gccProductCodeColumn : 
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
						if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_product_name_in_details"]))
						{
							grdVoucherDetails.Col = gccProductNameColumn;
						} 
						break;
					case gccProductNameColumn : 
						 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			//'***************************************************************************''
			//'This routine handles the display of ICS_Itemname when a ProductCode is selected
			//'and vice versa. It also show the value in status bar after checking the
			//'"rsvouchertype" recordset values.
			//'
			//'NOTE: The value in ICS_Unit list box relies on ICS_Item code column
			//'So even if the ICS_Item code column "Visible=False", it should consists the code.
			//'***************************************************************************''
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				C1.Win.C1TrueDBGrid.C1DataColumnCollection withVar = null;
				C1.Win.C1TrueDBGrid.C1DataColumnCollection withVar_2 = null;
				if (grdVoucherDetails.Col == gccProductCodeColumn || grdVoucherDetails.Col == gccProductNameColumn)
				{
					//'''''''''''''''''''''''''''''''''''''''''''''''''
					//''The below "if" checks for the bookmark of the listbox
					//''If the ICS_Item code or ICS_Item name does not match the value in listbox
					//''then the value should not be fetched.
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(cmbMastersList.Bookmark))
					{
						withVar = grdVoucherDetails.Columns;
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (grdVoucherDetails.Col == gccProductCodeColumn && Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Name_In_Details"]))
						{
							//If cmbMastersList.Columns(cCpProdName).Value = "" Then
							withVar[gccProductNameColumn].DataColumn.Value = cmbMastersList.Columns[cCpProdName].Value;
							//End If
						}
						else
						{
							withVar[gccProductCodeColumn].DataColumn.Value = cmbMastersList.Columns[cCpPartNo].Value;
						}



					}
					else
					{
						withVar_2 = grdVoucherDetails.Columns;
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (grdVoucherDetails.Col == gccProductCodeColumn && Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Name_In_Details"]))
						{
							withVar_2[gccProductNameColumn].DataColumn.Value = "";
						}
						else
						{
							withVar_2[gccProductCodeColumn].DataColumn.Value = "";
						}
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void ShowProductDetails(bool pShowRecordEmpty)
		{
			//''''*************************************************************************
			//'''Display the ICS_Item info in the status bar
			//''''*************************************************************************
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				if (!pShowRecordEmpty)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[gccProductCodeColumn].Value).Trim() != "")
					{
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsProductCodeList.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsProductCodeList.MoveFirst();
						rsProductCodeList.Find("part_no = '" + ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[gccProductCodeColumn].Value).Trim() + "'");

					}
				}
				//Call ClearStatusBar
				//Me.UCStatusBar.ClearText
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}


		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			this.FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
		}

		public void FindRoutine(string pObjectName)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				object mTempSearchValue = null;
				string mFilterCondition = "";
				string mysql = "";
				string mTempSql = "";
				object mReturnValue = null;
				string mAdditionalFromClause = "";

				if ((pObjectName.IndexOf('#') + 1) == 0)
				{
					return;
				}

				string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
				int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

				if (mObjectName == "txtCommonTextBox")
				{
					this.txtCommonTextBox[mIndex].Text = "";
					switch(mIndex)
					{
						case SystemICSConstants.tcLocationCode : case SystemICSConstants.tcImportLocationCode : 
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2004000, "82")); 
							 
							break;
						case SystemICSConstants.tcLedgerCode : 
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
							mysql = Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["additional_ledger_find_where_clause"]) + ""; 
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
							if (!Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_exchange_rate"]) && !ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("advance_multiple_currency")))
							{
								if (mysql != "")
								{
									mysql = mysql + " and ";
								}
								mysql = mysql + " l.curr_cd = " + Conversion.Str(SystemGLConstants.gDefaultCurrencyCd);
							} 
							 
							//'' --------------This code for ledger security ------ Moiz Hakimi----28-Oct-2008--------------------------- 
							if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
							{
								mAdditionalFromClause = " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
							}
							else
							{
								mAdditionalFromClause = "";
							} 
							//'' -------------------------------------------------------------------------------------------------------- 
							 
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mysql, true, false, "", true, false, false, mAdditionalFromClause)); 
							break;
						case SystemICSConstants.tcCashCode : case SystemICSConstants.tcCCCode : 
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
							mysql = Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["additional_cash_find_where_clause"]) + ""; 
							if (mysql != "")
							{
								mysql = mysql + " and ";
							} 
							mysql = mysql + " l.curr_cd = " + Conversion.Str(SystemGLConstants.gDefaultCurrencyCd); 
							 
							//'' --------------This code for ledger security ------ Moiz Hakimi----28-Oct-2008--------------------------- 
							if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
							{
								mAdditionalFromClause = " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
							}
							else
							{
								mAdditionalFromClause = "";
							} 
							//'' --------------------------------------------------------------------------------------------------------- 
							 
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mysql, true, false, "", true, false, false, mAdditionalFromClause)); 
							break;
						case SystemICSConstants.tcSalesmanCode : 
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1004000, "88")); 
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
						this.txtCommonTextBox[mIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						this.txtCommonTextBox_Leave(this, new EventArgs());
					}
				}

				SystemVariables.gSkipTextBoxLostFocus = false;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);

			string mysql = "";
			object mTempReturnValue = null;
			int mSetValueIndex = 0;

			clsICSTransaction pclsICSTransaction = null;

			if (SystemVariables.gSkipTextBoxLostFocus)
			{
				return;
			}

			try
			{

				switch(Index)
				{
					case SystemICSConstants.tcLedgerCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l.l_ldgr_name" : "l.a_ldgr_name"); 
						mysql = mysql + " , l.current_bal , gc.symbol, gc.curr_cd "; 
						 
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021 
						if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_default_salesman_in_ledger"))) == TriState.True)
						{
							mysql = mysql + " , sman.sman_no ";
							mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "sman.l_sman_name" : "sman.a_sman_name");
						}
						else
						{
							mysql = mysql + " , 0, '' ";
						} 
						 
						mysql = mysql + " , l.credit_limit_days "; 
						mysql = mysql + " , gc.exchange_rate, l.Default_Sales_Price_Level, l.Default_Purchase_Price_Level, l.Default_Discount_In_Percent  "; 
						mysql = mysql + " from gl_ledger l "; 
						mysql = mysql + " inner join gl_currency gc on l.curr_cd = gc.curr_cd "; 
						 
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021 
						if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_default_salesman_in_ledger"))) == TriState.True)
						{
							mysql = mysql + " left join SM_Salesman sman on l.default_sman_cd = sman.sman_cd ";
						} 
						 
						//'' --------------This code for ledger security ------ Moiz Hakimi----28-Oct-2008--------------------------- 
						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
						{
							mysql = mysql + " inner join GL_Ledger_Security gls on l.Ldgr_Cd = gls.Ldgr_Cd ";
						} 
						//----------------------------------------------------------------------------------------------------------- 
						 
						mysql = mysql + " Where ldgr_no ='" + this.txtCommonTextBox[Index].Text + "'"; 
						 
						mSetValueIndex = SystemICSConstants.dcLedgerName; 
						break;
					case SystemICSConstants.tcLocationCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name"); 
						mysql = mysql + ",'' from SM_Location where locat_no = " + this.txtCommonTextBox[Index].Text; 
						 
						mSetValueIndex = SystemICSConstants.dcLocationName; 
						break;
					case SystemICSConstants.tcSalesmanCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_Sman_name" : "a_Sman_name"); 
						mysql = mysql + ",'' from SM_Salesman where Sman_no = " + this.txtCommonTextBox[Index].Text; 
						 
						mSetValueIndex = SystemICSConstants.dcSalesmanName; 
						break;
					default:
						mSetValueIndex = 0; 
						break;
				}

				if (mSetValueIndex > 0)
				{
					if (!SystemProcedure2.IsItEmpty(this.txtCommonTextBox[Index].Text, SystemVariables.DataType.StringType))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempReturnValue))
						{
							this.txtDisplayLabel[mSetValueIndex].Text = "";

							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							this.txtDisplayLabel[mSetValueIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempReturnValue).GetValue(0));


						}


					}
					else
					{
						this.txtDisplayLabel[mSetValueIndex].Text = "";
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
					//    If Me.txtCommonTextBox(Index).Enabled = True Then
					//       Me.txtCommonTextBox(Index).SetFocus
					//    End If
				}
				else
				{
					//
				}
				//Call TextBoxLostFocus(Me, Index, me)
			}

		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			//'***************************************************************************''
			//'This routine checks the column type and calls the "CalculateTotals" function.
			//'***************************************************************************''
			double mBaseQty = 0;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				grdVoucherDetails.UpdateData();

				if (ColIndex == gccProductCodeColumn || ColIndex == gccProductNameColumn || ColIndex == gccQtyColumn || ColIndex == gccRateColumn || ColIndex == gccAmountColumn)
				{
					CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);


					//'''The grid is refreshed twice because.
					//'''there is problem in calculate total function of when the price list is enabled.
					//'''the total is not displayed when the user reached to third line.
					grdVoucherDetails.Refresh();
					grdVoucherDetails.Refresh();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}


		private void CalculateTotals(int mRowNumber, int mColNumber, bool mIsGetRecord = false)
		{
			//''''*************************************************************************
			//'''Calculate the figures of following columns.
			//'''Quantity, Rate , Discount and amount.
			//''''*************************************************************************
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;


				double mTotalQty = 0;
				decimal mTotalAmount = 0;


				if (mColNumber == gccQtyColumn || mColNumber == gccRateColumn)
				{
					aVoucherDetails.SetValue((decimal) (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccRateColumn))) * Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, gccQtyColumn))), mRowNumber, gccAmountColumn);

				}
				else if (mColNumber == gccAmountColumn)
				{ 
					aVoucherDetails.SetValue((decimal) (Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(mRowNumber, gccAmountColumn))) / ((double) Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, gccQtyColumn)))), mRowNumber, gccRateColumn);

				}


				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					mTotalQty += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccQtyColumn)));
					mTotalAmount += ((decimal) Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(Cnt, gccAmountColumn))));
				}

				if (mTotalAmount != 0)
				{
					grdVoucherDetails.Columns[gccAmountColumn].FooterText = StringsHelper.Format(mTotalAmount, "###,###,###,###.000");
					if (!SystemProcedure2.IsItEmpty(txtPercentDiscount.Value, SystemVariables.DataType.NumberType) || !SystemProcedure2.IsItEmpty(txtDiscount.Value, SystemVariables.DataType.NumberType))
					{
						txtNetAmount.Value = ((double) mTotalAmount) - ReflectionHelper.GetPrimitiveValue<double>(txtDiscount.Value);

						if (fraPayments.Visible == (TriState.True != TriState.False))
						{
							txtCashAmt.Value = ((double) mTotalAmount) - ReflectionHelper.GetPrimitiveValue<double>(txtDiscount.Value) - ReflectionHelper.GetPrimitiveValue<double>(txtCCAmt.Value);
						}
					}
					else
					{
						txtNetAmount.Value = mTotalAmount;
						if (fraPayments.Visible == (TriState.True != TriState.False))
						{
							txtCashAmt.Value = ((double) mTotalAmount) - ReflectionHelper.GetPrimitiveValue<double>(txtCCAmt.Value);
						}
					}

				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void AddRecord()
		{
			try
			{
				object mReturnValue = null;
				string mysql = "";
				object mTempValue = null;
				int Cnt = 0;

				SystemProcedure2.ClearTextBox(this);
				SystemProcedure2.ClearNumberBox(this);

				SystemGrid.DefineVoucherArray(aVoucherDetails, mMaxArrayCols, -1, true);
				grdVoucherDetails.Rebind(true);
				//----------This is for default cash code-----------Moiz Hakimi 16-Feb-2019--------------------------

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!SystemVariables.rsVoucherTypes.Tables[0].Rows[0].IsNull("Default_cash_cd"))
				{
					mysql = " select ldgr_no, " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name") + " from gl_ledger ";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " where ldgr_cd = " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Default_cash_cd"]);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempValue))
					{
						optVoucherType[1].Checked = true;
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[SystemICSConstants.tcCashCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDisplayLabel[SystemICSConstants.dcCashName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					}
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!SystemVariables.rsVoucherTypes.Tables[0].Rows[0].IsNull("Default_Credit_Card_Cd"))
				{
					mysql = " select ldgr_no, " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name") + " from gl_ledger ";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " where ldgr_cd = " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Default_Credit_Card_Cd"]);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempValue))
					{
						optVoucherType[1].Checked = true;
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[SystemICSConstants.tcCCCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDisplayLabel[SystemICSConstants.dcCCName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					}
				}

				SetDefaultValues();
				//---------------------------------------------------------------------------------------------------
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]), "AddRecord");
			}
		}


		public void txtDiscount_Leave(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (ReflectionHelper.GetPrimitiveValue<double>(txtDiscount.Value) > Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[gccAmountColumn].FooterText, "###############.######")) || ReflectionHelper.GetPrimitiveValue<double>(txtDiscount.Value) < 0 || Convert.IsDBNull(txtDiscount.Value))
				{
					txtDiscount.Value = 0;
				}
				//''and it was decided that percent discount should not be calculated from amount. But amount will be calculated from percent discount.
				//If Not IsItEmpty(Format(grdVoucherDetails.Columns(grdProductAmountColumn).FooterText, "###############.######"), NumberType) Then
				//    txtPercentDiscount.Value = Format((txtDiscount.Value * 100) / (Val(Format(grdVoucherDetails.Columns(grdProductAmountColumn).FooterText, "###############.######"))), "###.######0")
				//End If
				txtNetAmount.Value = Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[gccAmountColumn].FooterText, "###############.######")) - Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtDiscount.Value));
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
					if (!SystemProcedure2.IsItEmpty(StringsHelper.Format(grdVoucherDetails.Columns[gccAmountColumn].FooterText, "###############.######"), SystemVariables.DataType.NumberType))
					{
						txtDiscount.Value = (Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[gccAmountColumn].FooterText, "###############.######")) * Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtPercentDiscount.Value))) / 100d;
					}


				}
				else
				{
					txtDiscount.Value = 0;
				}
				txtNetAmount.Value = Conversion.Val(StringsHelper.Format(grdVoucherDetails.Columns[gccAmountColumn].FooterText, "###############.######")) - Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtDiscount.Value));
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

		public bool saveRecord(bool pApprove = false)
		{
			bool result = false;
			DialogResult ans = (DialogResult) 0;
			object mTempValue = null;

			string mysql = "";
			string mErrorMsg = "";

			int mLocatCode = 0;
			int mLdgrCode = 0;
			int mCurrCode = 0;
			int mSmanCode = 0;
			int mVoucherNo = 0;
			int Cnt = 0;

			string mCashCode = "";
			string mCCCode = "";
			bool mIsCash = false;

			int mProductCode = 0;
			int mUnitEntryId = 0;
			int mItemTypeCd = 0;
			double mQty = 0;

			int mEntryId = 0;

			bool mAffectStock = false;

			double mGrossAmt = 0;
			double mDiscountAmt = 0;
			double mNetAmt = 0;
			double mCashAmt = 0;
			double mKnetAmt = 0;

			try
			{

				//'''****************************Get the Loation Code ****************************
				//''''****************************************************************************
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select locat_cd from SM_Location where locat_no=" + this.txtCommonTextBox[SystemICSConstants.tcLocationCode].Text));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempValue))
				{
					MessageBox.Show("Enter valid location code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (this.txtCommonTextBox[SystemICSConstants.tcLocationCode].Enabled)
					{
						this.txtCommonTextBox[SystemICSConstants.tcLocationCode].Focus();
					}
					goto StationExitFunction;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLocatCode = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
				}
				//''''****************************************************************************

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_ledger_on_header"]))
				{
					mysql = "select ldgr_cd, credit_limit_days, credit_limit_amount, type_cd , curr_cd ";
					mysql = mysql + " from gl_ledger where ldgr_no='" + txtCommonTextBox[SystemICSConstants.tcLedgerCode].Text + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						MessageBox.Show("Select Supplier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						if (this.txtCommonTextBox[SystemICSConstants.tcLedgerCode].Enabled)
						{
							this.txtCommonTextBox[SystemICSConstants.tcLedgerCode].Focus();
						}
						goto StationExitFunction;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLdgrCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCurrCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(4));
					}
				}
				//''''****************************************************************************

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select sman_cd from SM_Salesman where Sman_no=" + this.txtCommonTextBox[SystemICSConstants.tcSalesmanCode].Text));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempValue))
				{
					MessageBox.Show("Enter valid salesman code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (this.txtCommonTextBox[SystemICSConstants.tcSalesmanCode].Enabled)
					{
						this.txtCommonTextBox[SystemICSConstants.tcSalesmanCode].Focus();
					}
					goto StationExitFunction;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSmanCode = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
				}

				//'''****************************If cash entry then get the cash code************
				//''''****************************************************************************
				if (optVoucherType[1].Checked)
				{
					mysql = " select ldgr_cd from gl_ledger ";
					mysql = mysql + " where ldgr_no='" + txtCommonTextBox[SystemICSConstants.tcCashCode].Text + "'";
					mysql = mysql + " and curr_cd=" + Conversion.Str(SystemGLConstants.gDefaultCurrencyCd);

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["additional_cash_find_where_clause"]) != "")
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mysql = mysql + " and " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["additional_cash_find_where_clause"]);
					}

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						MessageBox.Show("Enter valid cash or bank code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						if (txtCommonTextBox[SystemICSConstants.tcCashCode].Enabled)
						{
							txtCommonTextBox[SystemICSConstants.tcCashCode].Focus();
						}
						goto StationExitFunction;
					}
					else
					{
						mIsCash = true;
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCashCode = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}

					if (txtCommonTextBox[SystemICSConstants.tcCCCode].Enabled && !SystemProcedure2.IsItEmpty(txtCommonTextBox[SystemICSConstants.tcCCCode].Text))
					{
						mysql = " select ldgr_cd from gl_ledger ";
						mysql = mysql + " where ldgr_no='" + txtCommonTextBox[SystemICSConstants.tcCCCode].Text + "'";
						mysql = mysql + " and curr_cd=" + Conversion.Str(SystemGLConstants.gDefaultCurrencyCd);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["additional_cash_find_where_clause"]) != "")
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							mysql = mysql + " and " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["additional_cash_find_where_clause"]);
						}

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							MessageBox.Show("Enter valid bank or bank code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
							if (txtCommonTextBox[SystemICSConstants.tcCCCode].Enabled)
							{
								txtCommonTextBox[SystemICSConstants.tcCCCode].Focus();
							}
							goto StationExitFunction;
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mCCCode = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
						}
					}
				}
				else
				{
					mIsCash = false;
				}
				//''''****************************************************************************

				mGrossAmt = ReflectionHelper.GetPrimitiveValue<double>(txtNetAmount.Value) - ReflectionHelper.GetPrimitiveValue<double>(txtDiscount.Value);
				//UPGRADE_WARNING: (1068) txtDiscount.Value of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mDiscountAmt = ReflectionHelper.GetPrimitiveValue<double>(txtDiscount.Value);
				//UPGRADE_WARNING: (1068) txtNetAmount.Value of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mNetAmt = ReflectionHelper.GetPrimitiveValue<double>(txtNetAmount.Value);
				//UPGRADE_WARNING: (1068) txtCashAmt.Value of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCashAmt = ReflectionHelper.GetPrimitiveValue<double>(txtCashAmt.Value);
				//UPGRADE_WARNING: (1068) txtCCAmt.Value of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mKnetAmt = ReflectionHelper.GetPrimitiveValue<double>(txtCCAmt.Value);

				SystemVariables.gConn.BeginTransaction();

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mVoucherNo = Convert.ToInt32(Double.Parse(SystemICSProcedure.GetICSVoucherNo(Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Generate_voucher_no_method"]), mLocatCode, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Voucher_Type"]), Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]), false)));
					//''''************************************************************************

					//''''*********************Insert into the Invnt Trans table for Component *****
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " insert into " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]);
					mysql = mysql + " ( voucher_date, due_date, voucher_no";
					mysql = mysql + " , voucher_type, ldgr_cd, Ldgr_Name, curr_cd, sman_cd  ";
					mysql = mysql + " , Voucher_Amt_FC, Discount_Amt_FC, Is_Cash, Cash_Amt_FC, Credit_Card_Amt_FC, Cash_Cd, Credit_Card_Ldgr_Cd  ";
					mysql = mysql + " , reference_no, comments, user_cd ";
					mysql = mysql + " , locat_cd, on_hand_stock_affected ";
					mysql = mysql + " , status, posted_invnt, posted_gl, Additional_Field_1, Additional_Field_2, Additional_Field_3, Additional_Field_4 ";

					mysql = mysql + " ) values ( ";

					mysql = mysql + "'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'"; //Voucher Date
					mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.Value) + "'"; //Due Date
					mysql = mysql + ", " + Conversion.Str(mVoucherNo); //Voucher No.
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + ", " + Conversion.Str(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Voucher_Type"]);
					mysql = mysql + " , " + Conversion.Str(mLdgrCode);
					mysql = mysql + " , '" + txtDisplayLabel[SystemICSConstants.dcLedgerName].Text + "'";
					mysql = mysql + " , " + Conversion.Str(mCurrCode);
					mysql = mysql + " , " + Conversion.Str(mSmanCode);
					mysql = mysql + ", " + Conversion.Str(mGrossAmt);
					mysql = mysql + ", " + Conversion.Str(mDiscountAmt);

					if (mIsCash)
					{
						mysql = mysql + ", 1 ";
						mysql = mysql + ", " + Conversion.Str(mCashAmt);
						mysql = mysql + ", " + Conversion.Str(mKnetAmt);
						mysql = mysql + ", " + Conversion.Str(mCashCode);
						mysql = mysql + ", " + Conversion.Str(mCCCode);
					}
					else
					{
						mysql = mysql + ", 0 ";
						mysql = mysql + ", 0, 0, null, null";
					}


					mysql = mysql + ", NULL"; //ReferenceNo
					mysql = mysql + ",N'" + this.txtRemark.Text + "'"; //Comments
					mysql = mysql + ", " + Conversion.Str(SystemVariables.gLoggedInUserCode); //User Cd
					mysql = mysql + ", " + Conversion.Str(mLocatCode);
					mysql = mysql + ", 1 ";
					mysql = mysql + " , 4, 0, 0 ";

					mysql = mysql + " , " + Conversion.Str(Check1.CheckState);
					mysql = mysql + " , " + Conversion.Str(Check2.CheckState);
					mysql = mysql + " , " + Conversion.Str(Check3.CheckState);
					mysql = mysql + " , " + Conversion.Str(Check4.CheckState);


					mysql = mysql + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//''''*********************Get the New entry ID during add mode ***************
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
					//''''*************************************************************************

					InsertAdditionalVoucherDetails(mEntryId, mLdgrCode.ToString());
				}
				else
				{

					//'''Variable can be used for both add and edit mode
					//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
					//''''*************************************************************************

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " update " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]);
					mysql = mysql + " set status=0 ";
					mysql = mysql + " where entry_id = " + mEntryId.ToString();
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = "update " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_table_Name"]);
					mysql = mysql + " set ";
					mysql = mysql + " voucher_date ='" + ReflectionHelper.GetPrimitiveValue<string>(this.txtVoucherDate.Value) + "'";
					mysql = mysql + " , reference_no = ''";
					mysql = mysql + " , comments = N'" + this.txtRemark.Text + "'";
					mysql = mysql + " , user_cd = " + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " , locat_cd = " + Conversion.Str(mLocatCode);
					mysql = mysql + " , Sman_cd = " + Conversion.Str(mSmanCode);
					mysql = mysql + " , Ldgr_cd = " + Conversion.Str(mLdgrCode);
					mysql = mysql + " , Ldgr_Name = '" + txtDisplayLabel[SystemICSConstants.dcLedgerName].Text + "'";
					mysql = mysql + " , Curr_Cd = " + Conversion.Str(mCurrCode);
					mysql = mysql + " , Voucher_Amt_FC =" + Conversion.Str(mGrossAmt);
					mysql = mysql + " , Discount_Amt_FC =" + Conversion.Str(mDiscountAmt);
					mysql = mysql + " , Additional_Field_1 = " + Conversion.Str(Check1.CheckState);
					mysql = mysql + " , Additional_Field_2 = " + Conversion.Str(Check1.CheckState);
					mysql = mysql + " , Additional_Field_3 = " + Conversion.Str(Check1.CheckState);
					mysql = mysql + " , Additional_Field_4 = " + Conversion.Str(Check1.CheckState);

					if (mIsCash)
					{
						mysql = mysql + " , Is_Cash = 1, Cash_Amt_FC = " + Conversion.Str(mCashAmt);
						mysql = mysql + " , Credit_Card_Amt_FC = " + Conversion.Str(mKnetAmt);
						mysql = mysql + " , Cash_Cd = " + Conversion.Str(mCashCode);
						mysql = mysql + " , Credit_Card_Ldgr_Cd = " + Conversion.Str(mCCCode);

					}
					else
					{
						mysql = mysql + " , Is_Cash = 0, Cash_Amt_FC = 0";
						mysql = mysql + " , Credit_Card_Amt_FC = 0";
						mysql = mysql + " , Cash_Cd = null";
						mysql = mysql + " , Credit_Card_Ldgr_Cd = null";
					}


					mysql = mysql + " where entry_Id = " + Conversion.Str(mEntryId);
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					UpdateAdditionalVoucherDetails(mEntryId);

				}
				//''''*************************************************************************
				//'''Insert into stock trans table for Component Items
				//''''*************************************************************************
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{

					//''''*************************************************************************
					//'''Check for the existence of the inventory Item in the database
					mysql = " select ICS_Item.prod_cd, affect_stock, unit_entry_id ";
					mysql = mysql + " , serialized , it.affect_gl , it.item_type_cd ";
					mysql = mysql + " from ICS_Item, ICS_Item_Types it, ICS_Item_Unit_Details aud ";
					mysql = mysql + " where ICS_Item.prod_cd = aud.prod_cd ";
					mysql = mysql + " and ICS_Item.base_unit_cd = aud.alt_unit_cd ";
					mysql = mysql + " and ICS_Item.item_type_cd = it.item_type_cd ";
					mysql = mysql + " and part_no = '" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccProductCodeColumn)).Trim() + "'";
					//mySql = mySql & " and it.item_type_cd = 1 "

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (!Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_non_inventory_in_details"]))
					{
						mysql = mysql + " and it.affect_stock = 1 ";
					}


					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						MessageBox.Show("invalid Product Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						grdVoucherDetails.Col = gccProductCodeColumn;
						goto StationGridError;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mProductCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mAffectStock = ReflectionHelper.GetPrimitiveValue<bool>(((Array) mTempValue).GetValue(1));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mUnitEntryId = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(2));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mItemTypeCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(5));

					}
					//''''*************************************************************************

					//''''*************************************************************************
					if (Information.IsNumeric(aVoucherDetails.GetValue(Cnt, gccQtyColumn)))
					{
						mQty = Convert.ToDouble(aVoucherDetails.GetValue(Cnt, gccQtyColumn));
					}
					else
					{
						mQty = 0;
					}

					if (mQty <= 0)
					{
						MessageBox.Show("Qty Cannot be zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						grdVoucherDetails.Col = gccQtyColumn;
						goto StationGridError;
					}
					//''''*************************************************************************


					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " insert into " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Details_table_Name"]);
					mysql = mysql + " ( entry_id, status, prod_cd, prod_name, qty, unit_entry_id, Item_Type_Cd  ";
					mysql = mysql + " , base_qty ";
					mysql = mysql + " , less_locat_cd ";
					mysql = mysql + " , fc_amount, fc_prod_dis, fc_rate  ";
					mysql = mysql + " , reference_no ";
					mysql = mysql + " , Additional_Field_1, Additional_Field_2, Additional_Field_3, Additional_Field_4 ";
					mysql = mysql + " , Additional_Field_5 ";
					mysql = mysql + ") values (";
					mysql = mysql + Conversion.Str(mEntryId); //Entry ID
					mysql = mysql + "," + Conversion.Str(1); //Status
					mysql = mysql + "," + Conversion.Str(mProductCode); //Product Code

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdVoucherDetails.Splits[0].DisplayColumns[gccProductNameColumn].Visible)
					{
						mysql = mysql + ",N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccProductNameColumn)).Trim() + "'";
					}
					else
					{
						mysql = mysql + ",''";
					}
					mysql = mysql + "," + Conversion.Str(mQty); //qty
					mysql = mysql + "," + Conversion.Str(mUnitEntryId); //Unit Code
					mysql = mysql + "," + Conversion.Str(mItemTypeCd);
					mysql = mysql + "," + Conversion.Str(mQty); //Base Qty
					mysql = mysql + "," + Conversion.Str(mLocatCode); //Add Locat Code
					mysql = mysql + "," + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccAmountColumn)).Trim();
					mysql = mysql + ",0";
					mysql = mysql + "," + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccRateColumn)).Trim();
					mysql = mysql + ", N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccRemarksColumn)).Trim() + "'";
					mysql = mysql + ", N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccActualSizeColumn)).Trim() + "'";
					mysql = mysql + ", N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccPrintSizeColumn)).Trim() + "'";
					mysql = mysql + ", N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccPaperKindColumn)).Trim() + "'";
					mysql = mysql + ", N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccCopiesColumn)).Trim() + "'";
					mysql = mysql + ", N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, gccInkColorColumn)).Trim() + "'";

					mysql = mysql + ")";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();

				}


				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["auto_post_ics"]))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						SystemICSProcedure.PostTransactionToIcs(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_Name"]), mEntryId);
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["auto_post_gl_party"]))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						SystemICSProcedure.PostTransactionToGLParty(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_Name"]), mEntryId);
					}
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " update  " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]);
					mysql = mysql + " set posted_invnt = posted_invnt ";
					mysql = mysql + " where entry_id = " + Conversion.Str(mEntryId);
					SqlCommand TempCommand_5 = null;
					TempCommand_5 = SystemVariables.gConn.CreateCommand();
					TempCommand_5.CommandText = mysql;
					TempCommand_5.ExecuteNonQuery();

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " update  " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]);
					mysql = mysql + " set posted_gl_party = posted_gl_party ";
					mysql = mysql + " where entry_id = " + Conversion.Str(mEntryId);
					SqlCommand TempCommand_6 = null;
					TempCommand_6 = SystemVariables.gConn.CreateCommand();
					TempCommand_6.CommandText = mysql;
					TempCommand_6.ExecuteNonQuery();
				}
				//''''*************************************************************************

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					if (IsNegativeStock(1, mEntryId, false, 0, 0, ref mErrorMsg))
					{
						//grdVoucherDetails.SetFocus
						goto StationRollBackNegativeStockTrans;
					}


				}
				else if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{ 
					if (IsNegativeStock(2, mEntryId, false, 0, 0, ref mErrorMsg))
					{
						//grdVoucherDetails.SetFocus
						goto StationRollBackNegativeStockTrans;
					}

				}

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " delete from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]);
					mysql = mysql + " where entry_id = " + mEntryId.ToString();
					mysql = mysql + " and status=0 ";
					SqlCommand TempCommand_7 = null;
					TempCommand_7 = SystemVariables.gConn.CreateCommand();
					TempCommand_7.CommandText = mysql;
					TempCommand_7.ExecuteNonQuery();
				}

				//''''*************************************************************************
				//Approve (Change the status to 2)
				if (pApprove)
				{

					//If rsVoucherTypes("allow_online_gl_post") = True Then
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemICSProcedure.PostTransactionToGL(Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]), mEntryId);
					//End If


				}
				//''''*************************************************************************

				//''''*************************************************************************
				SystemICSProcedure.SaveLastTransactionInfo(Convert.ToInt32(Conversion.Val(this.txtCommonTextBox[SystemICSConstants.tcLocationCode].Text)), Convert.ToInt32(Conversion.Val(txtCommonTextBox[SystemICSConstants.tcSalesmanCode].Text)), optVoucherType[1].Checked, Conversion.Val(txtCommonTextBox[SystemICSConstants.tcCashCode].Text.Trim()).ToString(), txtCommonTextBox[SystemICSConstants.tcLedgerCode].Text);
				//''''*************************************************************************

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();


				//''''*************************************************************************
				//Display a messbox if the auto generate voucher no is true and it is in addmode
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Display_Voucher_No_After_Save"])) == TriState.True)
					{
						mysql = SystemConstants.msg20 + mVoucherNo.ToString();
						MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}

				//**-- check if voucher is supposed to be printed
				//**-- after saving it. if so call print routine
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["print_after_save"]))
				{

					ans = MessageBox.Show(SystemConstants.msg25, "Expert Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						PrintReport(mEntryId);
					}
				}
				//''''*************************************************************************

				return true;


				//''''*************************************************************************
				StationExitFunction:
				//This code is executed when there is error before begin trans
				return false;
				//''''*************************************************************************


				//''''*************************************************************************

				//This code is executed when there is error after begin trans
				result = false;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				return result;
				//''''*************************************************************************

				//''''*************************************************************************
				StationRollBackNegativeStockTrans:
				//This code is executed when there is error after begin trans
				result = false;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				MessageBox.Show(mErrorMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				grdVoucherDetails.Focus();
				return result;
				//''''*************************************************************************

				//''''*************************************************************************
				//This code is executed when there is error in the Grid
				StationGridError:
				grdVoucherDetails.Bookmark = Cnt;
				grdVoucherDetails.Focus();
				result = false;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
			}
			catch (System.Exception excep)
			{
				//''''*************************************************************************

				//''''*************************************************************************
				//All other Errors.
				int mReturnErrorType = 0;

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_table_Name"]), "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				if (mReturnErrorType == 1)
				{
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					AddRecord();
					result = false;
				}
				else if (mReturnErrorType == 3)
				{ 
					AddRecord();
					result = false;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		public void MRoutine()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!UserAccess.AllowUserDisplay)
				{
					MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				RecordNavidate(37, Convert.ToInt32(Conversion.Val(txtCommonTextBox[SystemICSConstants.tcVoucherNo].Text)), Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["voucher_type"]), Convert.ToInt32(Conversion.Val(txtCommonTextBox[SystemICSConstants.tcLocationCode].Text)));
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}


		}


		public void ORoutine()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!UserAccess.AllowUserDisplay)
				{
					MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				RecordNavidate(39, Convert.ToInt32(Conversion.Val(txtCommonTextBox[SystemICSConstants.tcVoucherNo].Text)), Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["voucher_type"]), Convert.ToInt32(Conversion.Val(txtCommonTextBox[SystemICSConstants.tcLocationCode].Text)));
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}


		private void RecordNavidate(int pKeyCode, int pVoucherNo, int pVoucherType, int pLocatNo)
		{
			string mysql = "";
			int mLocatCd = 0;
			object mReturnValue = null;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				if (pLocatNo > 0)
				{
					mysql = " select locat_cd from SM_Location ";
					mysql = mysql + " where locat_no =" + pLocatNo.ToString();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLocatCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						mLocatCd = 0;
					}
				}

				mysql = " select top 1 entry_id from ICS_Transaction ";
				mysql = mysql + " where 1=1 ";
				if (pVoucherNo > 0 && pKeyCode == 37)
				{
					mysql = mysql + " and voucher_no < " + pVoucherNo.ToString();
				}
				else if (pVoucherNo > 0 && pKeyCode == 39)
				{ 
					mysql = mysql + " and voucher_no > " + pVoucherNo.ToString();
				}

				//-----------------Added By Moiz Hakimi---05-Apr-2010---------------------------------
				//------------------------------------------------------------------------------------
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToDouble(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Generate_voucher_no_method"]) == 1)
				{
					//''On Voucher Type + Location Code
					mysql = mysql + " and locat_cd = " + mLocatCd.ToString();
					mysql = mysql + " and voucher_type =" + pVoucherType.ToString();
				}
				else if (Convert.ToDouble(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Generate_voucher_no_method"]) == 2)
				{ 
					//''2 = On Voucher Type
					mysql = mysql + " and voucher_type =" + pVoucherType.ToString();

					//-------------Added for location security-------------------------------
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_location_level_security_in_reports")) && SystemVariables.gLoggedInSingleLocation)
					{
						mysql = mysql + " and locat_cd = " + mLocatCd.ToString();
					}
					//-----------------------------------------------------------------------

				}
				else if (Convert.ToDouble(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Generate_voucher_no_method"]) == 3)
				{ 
					//''On Voucher Type + Location Code + IsCash
					mysql = mysql + " and locat_cd = " + mLocatCd.ToString();
					mysql = mysql + " and voucher_type =" + pVoucherType.ToString();

					if (txtCommonTextBox[SystemICSConstants.tcCashCode].Enabled)
					{
						mysql = mysql + " and is_cash= 1 ";
					}
					else
					{
						mysql = mysql + " and is_cash= 0 ";
					}
				}
				//-----------------------------------------------------------------------------------

				if (pKeyCode == 37)
				{
					mysql = mysql + " order by voucher_no desc ";
				}
				else if (pKeyCode == 39)
				{ 
					mysql = mysql + " order by voucher_no asc ";
				}

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					if (this.UserAccess.AllowUserDisplay)
					{
						GetRecord(mReturnValue);
					}
					else
					{
						MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}


		private bool IsNegativeStock(int pActionMode, int pEntryId, bool pBoth, int pNewVoucherType, int pOldVoucherType, ref string pErrorMsg)
		{
			//''''In order to control the negative stock, the following things are done
			//''''1.Update the details table status to 0 before update, this will undo the quantity
			//''''2.Call the IsNegativeStock function to check the quantity

			//Check for Negative Stock
			//pActionMode=1 Add
			//pActionMode=2 Update
			//pActionMode=3 Delete
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			bool result = false;
			try
			{

				string mysql = "";
				string mLocatType = "";
				int Cnt = 0;
				string mNegativePartNo = "";

				clsSetICSVoucherRec mSetVoucher = null;
				if (pNewVoucherType > 0)
				{
					mSetVoucher = new clsSetICSVoucherRec();
					mSetVoucher.SetVoucherType(pOldVoucherType, pNewVoucherType);
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("negative_stock_check")) && Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Check_Negative_Stock"]))
				{
					if (pActionMode == 1)
					{ //Add
						//During add do not check only purchase type of transaction
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["add_or_less"]) == "A" && Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["affect_on_hand_stock"]) && !Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["locat_to_locat"]))
						{
							return false;
						}
					}
					else if (pActionMode == 3)
					{  //Delete
						//During delete do not check only sales type of transaction
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["add_or_less"]) == "L" && Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["affect_on_hand_stock"]) && !Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["locat_to_locat"]))
						{
							return false;
						}
					}

					if (pActionMode == 1)
					{ //Add
						mLocatType = "less_locat_cd";
					}
					else if (pActionMode == 2)
					{  //Update
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["locat_to_locat"]) && !Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["generate_on_multiple_location"]))
						{
							//This condition will be true for Stock Trans
							//For the first time it is false, which would take the location less_locat_cd
							//The recursive call would make it true, which would take the location add_locat_cd
							if (!pBoth)
							{
								mLocatType = "less_locat_cd";
							}
							else
							{
								mLocatType = "add_locat_cd";
							}
						}
						else
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							if (Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["add_or_less"]) == "L")
							{
								mLocatType = "less_locat_cd";
							}
							else if (Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["add_or_less"]) == "A")
							{ 
								mLocatType = "add_locat_cd";
							}
						}
					}
					else if (pActionMode == 3)
					{  //Delete
						mLocatType = "add_locat_cd";
					}

					mNegativePartNo = SystemICSProcedure.NegativeStockCheck(pEntryId, mLocatType, ref pErrorMsg);
					if (mNegativePartNo != "")
					{
						int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
						for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
						{
							if (Convert.ToString(aVoucherDetails.GetValue(Cnt, gccProductCodeColumn)).Trim() == mNegativePartNo.Trim())
							{
								grdVoucherDetails.Bookmark = Cnt;
								break;
							}
						}

						result = true;
					}
					else
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (pActionMode == 2 && !pBoth && (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["locat_to_locat"]) && !Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["generate_on_multiple_location"])))
						{
							//This procedure will run during UPDATE for stocktrans
							//The recursive function is called for checking the stock of both the location
							//add_locat_cd and less_locat_cd
							IsNegativeStock(2, pEntryId, true, 0, 0, ref pErrorMsg);
						}
						result = false;
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		private bool IsNegativeStock(int pActionMode, int pEntryId, bool pBoth, int pNewVoucherType, int pOldVoucherType)
		{
			string tempRefParam = "";
			return IsNegativeStock(pActionMode, pEntryId, pBoth, pNewVoucherType, pOldVoucherType, ref tempRefParam);
		}

		private bool IsNegativeStock(int pActionMode, int pEntryId, bool pBoth, int pNewVoucherType)
		{
			string tempRefParam2 = "";
			return IsNegativeStock(pActionMode, pEntryId, pBoth, pNewVoucherType, 0, ref tempRefParam2);
		}

		private bool IsNegativeStock(int pActionMode, int pEntryId, bool pBoth)
		{
			string tempRefParam3 = "";
			return IsNegativeStock(pActionMode, pEntryId, pBoth, 0, 0, ref tempRefParam3);
		}

		private bool IsNegativeStock(int pActionMode, int pEntryId)
		{
			string tempRefParam4 = "";
			return IsNegativeStock(pActionMode, pEntryId, false, 0, 0, ref tempRefParam4);
		}


		private void SetDefaultValues()
		{
			object mTempValue = null;
			string mysql = "";

			try
			{

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["restore_last_tran_setting"])) == TriState.True)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonTextBox[SystemICSConstants.tcLocationCode].Text = Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["last_tran_locat_no"]) + "";

					// ----------------This is to get default salesman on Location if is enabled--------------------------------------
					//------------------------------------Moiz Hakimi --- 14-Sep-2008-------------------------------------------------
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Default_Location_Salesman"])) == TriState.True)
					{
						mysql = " select Default_Sman_No ";
						mysql = mysql + " from SM_Location where locat_no = " + SystemVariables.gLoggedInUserLocationCode.ToString();
						//mySql = mySql & " from SM_Location where locat_no = " & frmCommon.txtCommonTextBox(tcLocationCode).Text
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						if (!SystemProcedure2.IsItEmpty(mTempValue, SystemVariables.DataType.NumberType))
						{
							//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonTextBox[SystemICSConstants.tcSalesmanCode].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
						}
					}
					else
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonTextBox[SystemICSConstants.tcSalesmanCode].Text = Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["last_tran_sman_no"]) + "";
					}
					//------------------------------------------------------------------------------------------------------------------
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_cash_credit_on_header"]))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["last_tran_cash_type"]))
						{
							optVoucherType[1].Checked = true;
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							txtCommonTextBox[SystemICSConstants.tcCashCode].Text = Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["last_tran_cash_no"]) + "";
						}
						else
						{
							optVoucherType[0].Checked = true;
							txtCommonTextBox[SystemICSConstants.tcCashCode].Text = "";
						}
					}
					else
					{
						optVoucherType[0].Checked = true;
						optVoucherType[1].Checked = false;
						txtCommonTextBox[SystemICSConstants.tcCashCode].Text = "";
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonTextBox[SystemICSConstants.tcLedgerCode].Text = Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["last_tran_ldgr_no"]) + "";

				}

				this.txtCommonTextBox_Leave(this, new EventArgs());
				this.txtCommonTextBox_Leave(this, new EventArgs());
				this.txtCommonTextBox_Leave(this, new EventArgs());


				//---------------------------------------------------------------------------------------------------
				//---------------------------------------------------------------------------------------------------
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}

		public bool deleteRecord()
		{
			//Delete the Record

			bool result = false;
			string mysql = "";
			DataSet tempRec = new DataSet();
			string mErrorMsg = "";

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

				if (!SystemProcedure2.ValidDateRange(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtVoucherDate.Value)))
				{
					MessageBox.Show("Invalid date range or the date is locked !", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return result;
				}

				SystemVariables.gConn.BeginTransaction();
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{

					//Check if any voucher linked to this voucher '''''''''''''''''''''''''''''''
					//If true then delete the details table and then delete the master table''''''
					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					if (SystemICSProcedure.DeleteAutoGeneratedLinkedVoucher(ReflectionHelper.GetPrimitiveValue<int>(SearchValue)) == (TriState.False != TriState.False))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						MessageBox.Show(SystemConstants.msg24, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return result;
					}
					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

					//''''*************************************************************************
					//'''During Delete of the voucher, update the detail table status to 0
					//'''This will deduct the quantity and help to check the negative stock
					//'''after the details portion is inserted
					//''''*************************************************************************
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " update " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]);
					mysql = mysql + " set status=0 ";
					mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
					//''''*************************************************************************

					//        ''''''Delete from assembly trans information
					//        '''''*************************************************************************
					//        If GetSystemPreferenceSetting("group_product") = True Then
					//            If DeleteGroupProduct(rsVoucherTypes("voucher_type"), SearchValue, True, mErrorMsg) = False Then
					//                gConn.RollBackTrans
					//                MsgBox mErrorMsg, vbInformation
					//                deleteRecord = False
					//                tabMaster.SelectedItem = frmCommon.cTabItemDetails
					//                grdVoucherDetails.SetFocus
					//                Exit Function
					//            End If
					//        End If
					//        '''''*************************************************************************

					if (IsNegativeStock(3, ReflectionHelper.GetPrimitiveValue<int>(SearchValue), false, 0, 0, ref mErrorMsg))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show(mErrorMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						grdVoucherDetails.Focus();
						return result;
					}


					//''Delete the serialized items
					//        If grdVoucherDetails.Columns(grdSerialNoColumn).Visible Then
					//            mysql = " delete ics_voucher_product_serial_no_details "
					//            mysql = mysql & " where voucher_entry_id = " & SearchValue
					//            mysql = mysql & " and voucher_type = " & rsVoucherTypes("voucher_type")
					//            gConn.Execute mysql
					//        End If


					//''''*************************************************************************
					//'''After the negative stock check is done then
					//'''Delete the items with status 0
					//''''*************************************************************************
					//        If GetSystemPreferenceSetting("Enable_Transaction_Logging") = vbTrue Then
					//            If LogRecord = False Then
					//                gConn.RollBackTrans
					//                MsgBox "Logging Error!", vbInformation
					//                deleteRecord = False
					//                Exit Function
					//            End If
					//        End If

					mysql = " delete from ICS_Additional_Details_Supplier where parent_entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

					mysql = " delete from ICS_Transaction_Reference ";
					mysql = mysql + " where txn_entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " delete from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["details_table_name"]);
					mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();

					mysql = " delete from ICS_Additional_Voucher_Details ";
					mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlCommand TempCommand_5 = null;
					TempCommand_5 = SystemVariables.gConn.CreateCommand();
					TempCommand_5.CommandText = mysql;
					TempCommand_5.ExecuteNonQuery();

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = " delete from " + Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["master_table_name"]);
					mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlCommand TempCommand_6 = null;
					TempCommand_6 = SystemVariables.gConn.CreateCommand();
					TempCommand_6.CommandText = mysql;
					TempCommand_6.ExecuteNonQuery();

				}
				//''''*************************************************************************

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				return true;
			}
			catch (System.Exception excep)
			{


				mysql = excep.Message;

				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();

					MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			return result;
		}

		private void InsertAdditionalVoucherDetails(int pEntryId, string pLdgrCd)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				string mysql = " Insert into ICS_Additional_Voucher_Details ";
				mysql = mysql + " (entry_id, Additional_Field_1, Additional_Field_2, Additional_Field_3 ";
				mysql = mysql + " , Additional_Field_4 , Additional_Field_5, Additional_Field_6, Additional_Field_7 ";
				mysql = mysql + " , Additional_Field_8 ";

				mysql = mysql + " ) values(";

				mysql = mysql + pEntryId.ToString();
				mysql = mysql + " , N'" + txt1Copy.Text + "'";
				mysql = mysql + " , N'" + txt2Copy.Text + "'";
				mysql = mysql + " , N'" + txt3Copy.Text + "'";
				mysql = mysql + " , N'" + txt4Copy.Text + "'";
				mysql = mysql + " , N'" + txtNumbering.Text + "'";
				mysql = mysql + " , N'" + txtPerforation.Text + "'";
				mysql = mysql + " , N'" + txtCoverNo.Text + "'";
				mysql = mysql + " , N'" + txtCoverColor.Text + "'";

				mysql = mysql + " )";

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void UpdateAdditionalVoucherDetails(int pEntryId)
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				string mysql = " update ICS_Additional_Voucher_Details set ";
				mysql = mysql + " Additional_Field_1 =N'" + txt1Copy.Text + "'";
				mysql = mysql + " , Additional_Field_2 =N'" + txt2Copy.Text + "'";
				mysql = mysql + " , Additional_Field_3 =N'" + txt3Copy.Text + "'";
				mysql = mysql + " , Additional_Field_4 =N'" + txt4Copy.Text + "'";
				mysql = mysql + " , Additional_Field_5 =N'" + txtNumbering.Text + "'";
				mysql = mysql + " , Additional_Field_6 =N'" + txtPerforation.Text + "'";
				mysql = mysql + " , Additional_Field_7 =N'" + txtCoverNo.Text + "'";
				mysql = mysql + " , Additional_Field_8 =N'" + txtCoverColor.Text + "'";

				mysql = mysql + " where entry_id = " + pEntryId.ToString();

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}


		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}