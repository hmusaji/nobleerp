
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmGLRateAdjustment
		: System.Windows.Forms.Form
	{

		public frmGLRateAdjustment()
{
InitializeComponent();
} 
 public  void frmGLRateAdjustment_old()
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


		private void frmGLRateAdjustment_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private XArrayHelper aAccountDetails = null;
		private XArrayHelper aRateAdjustment = null;
		private XArrayHelper aAdjustmentDetails = null;

		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;
		private Syncfusion.WinForms.Input.SfDateTimeEdit FirstFocusObject = null;

		private const string mDisableColumnBackColor = "&HD5D5D5";

		//define the Account select col no.
		private const int cGAccSno = 0;
		private const int cGAccLdgrNo = 1;
		private const int cGAccLdgrName = 2;
		private const int cGAccCurrNo = 3;
		private const int cGAccCurrName = 4;
		private const int cGAccSelect = 5;

		//define the Rate Adjustment col no.
		private const int cGRAdjCurrecyNo = 0;
		private const int cGRAdjCurrecyName = 1;
		private const int cGRAdjExchangeRate = 2;
		//Private Const cGRAdjAdjust As Integer = 3

		//define the Adjustment Details col no.
		private const int cGAdjDSno = 0;
		private const int cGAdjDLdgrNo = 1;
		private const int cGAdjDLdgrName = 2;
		private const int cGAdjDCostNo = 3;
		private const int cGAdjDCurrSymbol = 4;
		private const int cGAdjDPreviousFCBalance = 5;
		private const int cGAdjDAdjustmentRate = 6;
		private const int cGAdjDActualLCAmt = 7;
		private const int cGAdjDPreviousLCBalance = 8;
		private const int cGAdjDAdjLCAmt = 9;

		private const int mMaxColAccountSelect = 5;
		private const int mMaxColRateAdjustment = 2;
		private const int mMaxColAdjustmentDetails = 9;

		private const int cTcVoucherType = 1;
		private const int cTcAdjustmentCode = 2;



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


		private void cmdAdjust_Click(Object eventSender, EventArgs eventArgs)
		{
			StringBuilder mLdgrNo = new StringBuilder();

			int cnt = 0;
			grdAccountSelect.UpdateData();

			int tempForEndVar = aAccountDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (Convert.ToDouble(aAccountDetails.GetValue(cnt, cGAccSelect)) == -1)
				{
					if (mLdgrNo.ToString() != "")
					{
						mLdgrNo.Append(",");
					}
					mLdgrNo.Append("'" + Convert.ToString(aAccountDetails.GetValue(cnt, cGAccLdgrNo)) + "'");
				}
			}

			if (mLdgrNo.ToString() == "")
			{
				MessageBox.Show(" No Account selected", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				grdAccountSelect.Focus();
				return;
			}

			SqlDataReader rsTempRec = null;

			string mysql = " select distinct curr_no ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_curr_name" : "a_curr_name") + " as currency ";
			mysql = mysql + " from gl_ledger ";
			mysql = mysql + " inner join gl_currency on gl_ledger.curr_cd = gl_currency.curr_cd ";
			mysql = mysql + " where gl_ledger.ldgr_no in (" + mLdgrNo.ToString() + ")";

			cnt = 0;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();

			do 
			{
				SystemGrid.DefineVoucherArray(aRateAdjustment, mMaxColAdjustmentDetails, cnt, false);

				//Get the details information into the grid
				aRateAdjustment.SetValue(Convert.ToString(rsTempRec["curr_no"]).Trim(), cnt, cGRAdjCurrecyNo);
				aRateAdjustment.SetValue(Convert.ToString(rsTempRec["currency"]).Trim(), cnt, cGRAdjCurrecyName);

				cnt++;
			}
			while(rsTempRec.Read());

			grdRateAdjustment.Rebind(true);
			grdRateAdjustment.Refresh();

		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (this.ActiveControl.Name.ToLower() == ("grdRateAdjustment").ToLower())
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
						if (grdRateAdjustment.Col == cGRAdjExchangeRate)
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
			string mysql = "";

			try
			{

				this.Top = 0;
				this.Left = 0;

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
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowGLTranButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				//'draw form level toolbar
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(8).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture
				//Set btnFormToolBar(9).Picture = frmSysMain.imlSystemIcons.ListImages("imgPostingTransactions").Picture

				//'define Account select
				SystemGrid.DefineSystemVoucherGrid(grdAccountSelect, false, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, "&HB5BDB3", "&HB5BDB3");

				SystemGrid.DefineSystemVoucherGridColumn(grdAccountSelect, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAccountSelect, "Ledger Code", 1600, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAccountSelect, "Ledger Name", 3600, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAccountSelect, "Currency Code", 1400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAccountSelect, "Currency Name", 1600, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAccountSelect, "Select", 450, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);

				C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar = grdAccountSelect.Splits[0].DisplayColumns[cGAccSelect];
				withVar.DataColumn.ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
				withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;


				//'define rate adjustment
				SystemGrid.DefineSystemVoucherGrid(grdRateAdjustment, false, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, "&HB5BDB3", "&HB5BDB3");

				SystemGrid.DefineSystemVoucherGridColumn(grdRateAdjustment, "Currency Code", 1300, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdRateAdjustment, "Currency Name", 2700, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdRateAdjustment, "Exchange Rate", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true, 20);


				//define the Adjustment Details
				SystemGrid.DefineSystemVoucherGrid(grdAdjustmentDetails, false, false, false, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2.2f, 1.4f, "&HB5BDB3", "&HB5BDB3");

				SystemGrid.DefineSystemVoucherGridColumn(grdAdjustmentDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAdjustmentDetails, "Ledger Code", 1000, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAdjustmentDetails, "Ledger Name", 2700, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAdjustmentDetails, "Cost Code", 900, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")));
				SystemGrid.DefineSystemVoucherGridColumn(grdAdjustmentDetails, "Curr. Symbol", 600, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdAdjustmentDetails, "Previous FC Balance", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, true, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdAdjustmentDetails, "Adjustment Rate", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, true, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdAdjustmentDetails, "Actual LC Amt.", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, true, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdAdjustmentDetails, "Previous LC Balance", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, true, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdAdjustmentDetails, "Adjustment LC Amt.", 1100, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, true, true);


				aAccountDetails = new XArrayHelper();
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aAccountDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aAccountDetails.Clear();
				aAccountDetails.RedimXArray(new int[]{0, mMaxColAccountSelect}, new int[]{0, 0});
				//aAccountDetails(0, cGAccSno) = 1
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdAccountSelect.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdAccountSelect.setArray(aAccountDetails);

				aRateAdjustment = new XArrayHelper();
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aRateAdjustment.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aRateAdjustment.Clear();
				aRateAdjustment.RedimXArray(new int[]{0, mMaxColRateAdjustment}, new int[]{0, 0});
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdRateAdjustment.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdRateAdjustment.setArray(aRateAdjustment);

				aAdjustmentDetails = new XArrayHelper();
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aAdjustmentDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aAdjustmentDetails.Clear();
				aAdjustmentDetails.RedimXArray(new int[]{0, mMaxColAdjustmentDetails}, new int[]{0, 0});
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdAdjustmentDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdAdjustmentDetails.setArray(aAdjustmentDetails);


				txtAdjustmentDate.Value = DateTime.Today;
				FirstFocusObject = txtAdjustmentDate;

				GetForeignAccount();
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

				aAccountDetails = null;
				aRateAdjustment = null;
				aAdjustmentDetails = null;

				frmGLRateAdjustment.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
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
					case cTcVoucherType : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name" : "a_voucher_name"); 
						mysql = mysql + ",'' from gl_accnt_voucher_types where voucher_type = " + txtCommonTextBox[Index].Text; 
						 
						mSetValueIndex = cTcVoucherType; 
						break;
					case cTcAdjustmentCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l.l_ldgr_name" : "l.a_ldgr_name"); 
						mysql = mysql + ",'' from gl_ledger l where l.ldgr_no ='" + txtCommonTextBox[Index].Text + "'"; 
						mysql = mysql + " and l.type_cd = " + SystemGLConstants.gGLIncomeExpenseTypeCode.ToString(); 
						 
						mSetValueIndex = cTcAdjustmentCode; 
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
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[mSetValueIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempReturnValue).GetValue(0));
						}
					}
					else
					{
						txtDisplayLabel[mSetValueIndex].Text = "";
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
			int cnt = 0;
			SqlDataReader rsLocalRec1 = null;



			if (SystemProcedure2.IsItEmpty(pSearchValue, SystemVariables.DataType.NumberType))
			{
				return;
			}

			string mysql = " select gra.* ";
			mysql = mysql + " ," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name" : "a_voucher_name") + " as voucher_name ";
			mysql = mysql + " , l.ldgr_no as adjustment_ldgr_no ";
			mysql = mysql + " ," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name") + " as adjustment_ldgr_name ";
			mysql = mysql + " from gl_rate_adjustment gra ";
			mysql = mysql + " inner join gl_accnt_voucher_types avt on gra.gl_generated_voucher_type = avt.voucher_type ";
			mysql = mysql + " inner join gl_ledger l on gra.gl_adjustment_cd = l.ldgr_cd ";
			mysql = mysql + " where gra.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

			SqlDataReader rsLocalRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			if (rsLocalRec.Read())
			{
				CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				SearchValue = rsLocalRec["entry_id"];
				mTimeStamp = SystemProcedure2.tsFormat(Convert.ToString(rsLocalRec["time_stamp"]));

				//Set the form caption and Get the Voucher Status
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, Convert.ToInt32(rsLocalRec["status"]), CurrentFormMode, "Exchange Rate Adjustment", "Transaction");
				//''''*************************************************************************

				txtAdjustmentNo.Text = Convert.ToString(rsLocalRec["voucher_no"]);
				txtAdjustmentDate.Value = rsLocalRec["voucher_date"];
				txtCommonTextBox[cTcVoucherType].Text = Convert.ToString(rsLocalRec["gl_generated_voucher_type"]) + "";
				txtDisplayLabel[cTcVoucherType].Text = Convert.ToString(rsLocalRec["voucher_name"]) + "";

				txtCommonTextBox[cTcAdjustmentCode].Text = Convert.ToString(rsLocalRec["adjustment_ldgr_no"]) + "";
				txtDisplayLabel[cTcAdjustmentCode].Text = Convert.ToString(rsLocalRec["adjustment_ldgr_name"]) + "";

				txtComments.Text = Convert.ToString(rsLocalRec["comments"]) + "";

				//cnt = 1

				mysql = " select l.ldgr_no";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l.l_ldgr_name" : "l.a_ldgr_name") + " as ldgr_name ";
				mysql = mysql + " , gl_currency.symbol, grad.adjustment_rate ";
				mysql = mysql + " , grad.previous_fc_amt , grad.previous_lc_amt ";
				mysql = mysql + " , grad.actual_lc_amt , grad.adjustment_lc_amt ";
				mysql = mysql + " , gcc.cost_no ";
				mysql = mysql + " from gl_rate_adjustment_details grad ";
				mysql = mysql + " inner join gl_ledger l on grad.ldgr_cd = l.ldgr_cd ";
				mysql = mysql + " inner join gl_cost_centers gcc on grad.cost_cd = gcc.cost_cd ";
				mysql = mysql + " inner join gl_currency on grad.curr_cd = gl_currency.curr_cd ";
				mysql = mysql + " where grad.entry_id=" + Convert.ToString(rsLocalRec["entry_id"]);
				SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec1 = sqlCommand_2.ExecuteReader();
				rsLocalRec1.Read();
				do 
				{
					SystemGrid.DefineVoucherArray(aAdjustmentDetails, mMaxColAdjustmentDetails, cnt, false);


					aAdjustmentDetails.SetValue(cnt + 1, cnt, cGAccSno);
					aAdjustmentDetails.SetValue(rsLocalRec1["ldgr_no"], cnt, cGAdjDLdgrNo);
					aAdjustmentDetails.SetValue(rsLocalRec1["ldgr_name"], cnt, cGAdjDLdgrName);
					aAdjustmentDetails.SetValue(rsLocalRec1["symbol"], cnt, cGAdjDCurrSymbol);
					aAdjustmentDetails.SetValue(rsLocalRec1["cost_no"], cnt, cGAdjDCostNo);
					aAdjustmentDetails.SetValue(rsLocalRec1["adjustment_rate"], cnt, cGAdjDAdjustmentRate);
					aAdjustmentDetails.SetValue(rsLocalRec1["previous_fc_amt"], cnt, cGAdjDPreviousFCBalance);
					aAdjustmentDetails.SetValue(rsLocalRec1["previous_lc_amt"], cnt, cGAdjDPreviousLCBalance);
					aAdjustmentDetails.SetValue(rsLocalRec1["actual_lc_amt"], cnt, cGAdjDActualLCAmt);
					aAdjustmentDetails.SetValue(rsLocalRec1["adjustment_lc_amt"], cnt, cGAdjDAdjLCAmt);

					cnt++;
				}
				while(rsLocalRec1.Read());

				grdAdjustmentDetails.Rebind(true);
				grdAdjustmentDetails.Refresh();
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		public void FindRoutine(string pObjectName)
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
					case cTcVoucherType : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(100, "712")); 
						break;
					case cTcAdjustmentCode : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", "l.type_cd=" + SystemGLConstants.gGLIncomeExpenseTypeCode.ToString())); 
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdRateAdjustment.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdRateAdjustment_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == cGRAdjExchangeRate)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					if (ColIndex == cGRAdjExchangeRate)
					{
						Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###.000##############");
					}
					else
					{
						Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,###,###.000");
					}
				}
				else
				{
					Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "0.000");
				}
			}
		}

		public bool CheckDataValidity()
		{

			int cnt = 0;

			grdAccountSelect.UpdateData();
			grdRateAdjustment.UpdateData();

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 2);
				if (FirstFocusObject.Enabled)
				{
					FirstFocusObject.Focus();
				}
				goto mend;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[cTcAdjustmentCode].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Adjustment Code.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);

				if (txtCommonTextBox[cTcAdjustmentCode].Enabled)
				{
					txtCommonTextBox[cTcAdjustmentCode].Focus();
				}
				goto mend;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[cTcVoucherType].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Voucher Type.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);

				if (txtCommonTextBox[cTcVoucherType].Enabled)
				{
					txtCommonTextBox[cTcVoucherType].Focus();
				}
				goto mend;
			}

			if (SystemProcedure2.IsItEmpty(txtAdjustmentDate.Value, SystemVariables.DataType.DateType))
			{
				MessageBox.Show("Enter Adjustment date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (txtAdjustmentDate.Enabled)
				{
					txtAdjustmentDate.Focus();
				}
				goto mend;
			}
			else
			{
				if (!SystemProcedure2.ValidDateRange(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtAdjustmentDate.Value)))
				{
					MessageBox.Show("Invalid Date Range, Check the current financial year", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (txtAdjustmentDate.Enabled)
					{
						txtAdjustmentDate.Focus();
					}
					goto mend;
				}
			}


			//'''check whether atleast one ledger is selected
			int tempForEndVar = aAccountDetails.GetUpperBound(0);
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (Convert.ToDouble(aAccountDetails.GetValue(cnt, cGAccSelect)) == -1)
				{
					break;
				}

				if (cnt == aAccountDetails.GetUpperBound(0))
				{
					MessageBox.Show(" Select atleast one ledger", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					goto mend;
				}
			}

			//'''check the exchange rate is greater than zero
			int tempForEndVar2 = aRateAdjustment.GetUpperBound(0);
			for (cnt = 0; cnt <= tempForEndVar2; cnt++)
			{
				if (!SystemProcedure2.IsItEmpty(aRateAdjustment.GetValue(cnt, cGRAdjExchangeRate), SystemVariables.DataType.NumberType))
				{
					break;
				}

				if (cnt == aRateAdjustment.GetUpperBound(0))
				{
					MessageBox.Show(" Exchange Rate must be greater than Zero. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					goto mend;
				}
			}


			return true;

			goto mend;
			return false;

			mend:
			return false;
		}


		public bool saveRecord(bool pApprove = false)
		{

			bool result = false;
			string mysql = "";
			int mNewEntryID = 0;
			int mGLAdjustmentCd = 0;
			int mGLVoucherType = 0;

			clsHourGlass myHourGlass = new clsHourGlass();


			//On Error GoTo eFoundError


			//'''****************************Get the GL Voucher type****************************
			//''''****************************************************************************
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select voucher_type from gl_accnt_voucher_types where voucher_type=" + txtCommonTextBox[cTcVoucherType].Text));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mTempValue))
			{
				MessageBox.Show("Enter valid Voucher Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (txtCommonTextBox[cTcVoucherType].Enabled)
				{
					txtCommonTextBox[cTcVoucherType].Focus();
				}
				goto StationExitFunction;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mGLVoucherType = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
			}
			//''''****************************************************************************

			//'''****************************Get the GL Voucher type****************************
			//''''****************************************************************************
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select ldgr_cd from gl_ledger where ldgr_no='" + txtCommonTextBox[cTcAdjustmentCode].Text + "'"));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mTempValue))
			{
				MessageBox.Show("Enter valid Adjustment Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (txtCommonTextBox[cTcAdjustmentCode].Enabled)
				{
					txtCommonTextBox[cTcAdjustmentCode].Focus();
				}
				goto StationExitFunction;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mGLAdjustmentCd = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
			}
			//''''****************************************************************************


			SystemVariables.gConn.BeginTransaction();

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{

				//''''****************************************************************************
				//I '''''''''''''N'''''''''''''S'''''''''''''E'''''''''''''R'''''''''''T
				//''''****************************************************************************

				txtAdjustmentNo.Text = SystemProcedure2.GetNewNumber("gl_rate_adjustment", "voucher_no");


				//''''***************Insert into the master table*****************************
				mNewEntryID = InsertMasterRecord(Convert.ToInt32(Double.Parse(txtAdjustmentNo.Text)), ReflectionHelper.GetPrimitiveValue<string>(txtAdjustmentDate.Value), Convert.ToInt32(Double.Parse(txtCommonTextBox[cTcVoucherType].Text)), mGLAdjustmentCd, txtComments.Text);
				//''''************************************************************************

				//''''***************Insert Details ********************************
				if (!InsertDetailsRecord(mNewEntryID, ReflectionHelper.GetPrimitiveValue<string>(txtAdjustmentDate.Value)))
				{
					goto StationRollBackTrans;
				}
				//''''************************************************************************
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
				mysql = " select time_stamp from gl_rate_adjustment ";
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

				UpdateMasterRecord(mNewEntryID, ReflectionHelper.GetPrimitiveValue<string>(txtAdjustmentDate.Value), Convert.ToInt32(Double.Parse(txtCommonTextBox[cTcVoucherType].Text)), mGLAdjustmentCd, txtComments.Text);

				mysql = " delete from gl_rate_adjustment_details ";
				mysql = mysql + " where entry_id =" + mNewEntryID.ToString();
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();


				//''''***************Expenses and Charges Details ********************************
				if (!InsertDetailsRecord(mNewEntryID, ReflectionHelper.GetPrimitiveValue<string>(txtAdjustmentDate.Value)))
				{
					goto StationRollBackTrans;
				}
				//''''************************************************************************
			}


			//''''*************************************************************************
			//Approve (Change the status to 2)
			if (pApprove)
			{
				SystemICSProcedure.ApproveTransaction("gl_rate_adjustment", mNewEntryID);
			}
			//''''*************************************************************************

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();



			//''''*************************************************************************
			//Display a messbox if the auto generate voucher no is true and it is in addmode
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				mysql = SystemConstants.msg20 + txtAdjustmentNo.Text;
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

		private int InsertMasterRecord(int pVoucherNo, string pVoucherDate, int pVoucherType, int pGLAdjustmentCd, string pComments)
		{

			string mysql = " insert into gl_rate_adjustment ";
			mysql = mysql + " (voucher_no, voucher_date, status, comments ";
			mysql = mysql + " , gl_adjustment_cd, gl_generated_voucher_type";
			mysql = mysql + " , user_cd) ";
			mysql = mysql + " values(";
			mysql = mysql + pVoucherNo.ToString();
			mysql = mysql + " ,'" + pVoucherDate + "'";
			mysql = mysql + " , 1 ";
			mysql = mysql + " ,N'" + pComments + "'";
			mysql = mysql + " , " + pGLAdjustmentCd.ToString();
			mysql = mysql + " , " + pVoucherType.ToString();
			mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
			mysql = mysql + " )";

			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			return ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));

		}

		private int UpdateMasterRecord(int pEntryId, string pVoucherDate, int pVoucherType, int pGLAdjustmentCd, string pComments)
		{

			string mysql = " update gl_rate_adjustment ";
			mysql = mysql + " set ";
			mysql = mysql + " voucher_date ='" + pVoucherDate + "'";
			mysql = mysql + " , gl_adjustment_cd =" + pGLAdjustmentCd.ToString();
			mysql = mysql + " , gl_generated_voucher_type =" + pVoucherType.ToString();
			mysql = mysql + " , user_cd =" + SystemVariables.gLoggedInUserCode.ToString();
			mysql = mysql + " , comments =N'" + pComments + "'";
			mysql = mysql + " where entry_id =" + pEntryId.ToString();
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			return 0;
		}

		public void AddRecord()
		{
			try
			{


				//''''*************************************************************************
				//Set the form caption
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, this, (int) SystemVariables.VoucherStatus.stActive, CurrentFormMode, "Exchange Rate Adjustment", "Transaction");
				//''''*************************************************************************


				SystemGrid.DefineVoucherArray(aAccountDetails, mMaxColAccountSelect, 0, true);
				SystemGrid.DefineVoucherArray(aRateAdjustment, mMaxColRateAdjustment, 0, true);
				SystemGrid.DefineVoucherArray(aAdjustmentDetails, mMaxColAdjustmentDetails, 0, true);

				grdAccountSelect.Rebind(true);
				grdRateAdjustment.Rebind(true);
				grdAdjustmentDetails.Rebind(true);

				SystemProcedure2.ClearTextBox(this);


				SearchValue = ""; //Change the msearchvalue to blank
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive; //set new voucher status to active by default

				GetForeignAccount();

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

		public void findRecord()
		{

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000113));
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

			int cnt = 0;
			int tempForEndVar = aAccountDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aAccountDetails.SetValue(cnt + 1, cnt, cGAccSno);
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
					mysql = " delete from gl_rate_adjustment_details ";
					mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mysql = " delete from gl_rate_adjustment ";
					mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
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

			frmSysOnlinePosting frmTemp = frmSysOnlinePosting.CreateInstance();

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

						SystemICSProcedure.ApproveTransaction("gl_rate_adjustment", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));

						if (!PostGLRateAdjustment(ReflectionHelper.GetPrimitiveValue<int>(SearchValue)))
						{
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							result = false;
							goto mDestroy;
						}
						else
						{
						}


						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.CommitTrans();
					}

					result = true;
					goto mDestroy;
				}
			}

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
			return result;
		}

		public void PrintReport()
		{
			//Dim mEntryID As Long
			//
			//If CurrentFormMode = frmEditMode Then
			//    mEntryID = SearchValue
			//Else
			//    Exit Sub
			//End If
			//Call GetCrystalReport(100060202, 2, "5360", Str(mEntryID), False)
		}

		private bool InsertDetailsRecord(int pEntryId, string pAdjustmentDate)
		{

			StringBuilder mLdgrNo = new StringBuilder();
			double mNewCurrRate = 0;

			int cnt = 0;
			int cnt1 = 0;


			//On Error GoTo eFoundError

			int tempForEndVar = aAccountDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (Convert.ToDouble(aAccountDetails.GetValue(cnt, cGAccSelect)) == -1)
				{
					if (mLdgrNo.ToString() != "")
					{
						mLdgrNo.Append(",");
					}
					mLdgrNo.Append("'" + Convert.ToString(aAccountDetails.GetValue(cnt, cGAccLdgrNo)) + "'");
				}
			}

			if (mLdgrNo.ToString() == "")
			{
				MessageBox.Show(" No Account selected", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				grdAccountSelect.Focus();
				return false;
			}

			StringBuilder mysql = new StringBuilder();
			mysql.Append(" select gl_ledger.ldgr_cd, gl_ledger.ldgr_no as ldgr_no ");
			mysql.Append(" , gl_currency.curr_no as curr_no, gl_currency.curr_cd ");
			//mySql = mySql & " , (sum(fc_dr_amt) - sum(fc_cr_amt)) as fc_amt "
			//mySql = mySql & " , (sum(lc_dr_amt) - sum(lc_cr_amt)) as lc_amt "
			mysql.Append(" , (sum(dt.fc_amount)) as fc_amt ");
			mysql.Append(" , (sum(dt.lc_amount)) as lc_amt ");
			mysql.Append(" , dt.cost_cd ");
			mysql.Append(" from gl_accnt_trans_details dt ");
			mysql.Append(" inner join gl_accnt_trans mt on mt.entry_id = dt.entry_id ");
			mysql.Append(" inner join gl_ledger on dt.ldgr_cd = gl_ledger.ldgr_cd ");
			mysql.Append(" inner join gl_currency on gl_ledger.curr_cd= gl_currency.curr_cd ");
			mysql.Append(" where mt.voucher_date <='" + pAdjustmentDate + "'");
			mysql.Append(" and gl_ledger.ldgr_no in (" + mLdgrNo.ToString() + ")");
			mysql.Append(" group by gl_ledger.ldgr_cd, gl_ledger.ldgr_no, gl_currency.curr_no");
			mysql.Append(" , gl_currency.curr_cd , dt.cost_cd ");

			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql.ToString(), SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{
				mNewCurrRate = 0;
				int tempForEndVar2 = aRateAdjustment.GetLength(0) - 1;
				for (cnt1 = 0; cnt1 <= tempForEndVar2; cnt1++)
				{
					if (Conversion.Val(Convert.ToString(aRateAdjustment.GetValue(cnt1, cGRAdjCurrecyNo))) == Convert.ToDouble(rsTempRec["curr_no"]))
					{
						mNewCurrRate = Double.Parse(StringsHelper.Format(Conversion.Val(Convert.ToString(aRateAdjustment.GetValue(cnt1, cGRAdjExchangeRate))), "##########0.0######################"));
						break;
					}

					if (cnt1 == aRateAdjustment.GetLength(0) - 1)
					{
						MessageBox.Show(" Invalid Currency, Currency not found.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}

				mysql = new StringBuilder(" insert into gl_rate_adjustment_details ");
				mysql.Append(" (entry_id, ldgr_cd, cost_cd , curr_cd, adjustment_rate, previous_fc_amt ");
				mysql.Append(" , previous_lc_amt, actual_lc_amt, adjustment_lc_amt) ");
				mysql.Append(" values( ");
				mysql.Append(Conversion.Str(pEntryId));
				mysql.Append(" ," + Convert.ToString(rsTempRec["ldgr_cd"]));
				mysql.Append(" ," + Convert.ToString(rsTempRec["cost_cd"]));
				mysql.Append(" ," + Convert.ToString(rsTempRec["curr_cd"]));
				mysql.Append(" ," + mNewCurrRate.ToString());
				mysql.Append(" ," + Convert.ToString(rsTempRec["fc_amt"]));
				mysql.Append(" ," + Convert.ToString(rsTempRec["lc_amt"]));
				mysql.Append(" ," + ((mNewCurrRate * Convert.ToDouble(rsTempRec["fc_amt"])).ToString()));
				mysql.Append(" ," + (((mNewCurrRate * Convert.ToDouble(rsTempRec["fc_amt"])) - Convert.ToDouble(rsTempRec["lc_amt"])).ToString()));
				mysql.Append(" ) ");

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql.ToString();
				TempCommand.ExecuteNonQuery();

			}
			while(rsTempRec.Read());



			return true;

			MessageBox.Show(Information.Err().Description, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			return false;
		}


		private void GetForeignAccount()
		{

			int cnt = 0;

			SqlDataReader rsTempRec = null;

			string mysql = " select ldgr_no ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name") + " as ldgr_name ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_curr_name" : "a_curr_name") + " as curr_name ";
			mysql = mysql + " , gl_currency.curr_no as curr_no ";
			mysql = mysql + " from gl_ledger ";
			mysql = mysql + " inner join gl_currency on gl_ledger.curr_cd = gl_currency.curr_cd ";
			mysql = mysql + " where gl_ledger.curr_cd <> 1 ";

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();

			do 
			{
				SystemGrid.DefineVoucherArray(aAccountDetails, mMaxColAccountSelect, cnt, false);

				//Get the details information into the grid
				aAccountDetails.SetValue(cnt + 1, cnt, cGAccSno);
				aAccountDetails.SetValue(Convert.ToString(rsTempRec["ldgr_no"]).Trim(), cnt, cGAccLdgrNo);
				aAccountDetails.SetValue(Convert.ToString(rsTempRec["ldgr_name"]).Trim(), cnt, cGAccLdgrName);
				aAccountDetails.SetValue(Convert.ToString(rsTempRec["curr_no"]).Trim(), cnt, cGAccCurrNo);
				aAccountDetails.SetValue(Convert.ToString(rsTempRec["curr_name"]).Trim(), cnt, cGAccCurrName);
				aAccountDetails.SetValue(0, cnt, cGAccSelect);

				cnt++;
			}
			while(rsTempRec.Read());

			grdAccountSelect.Rebind(true);
			grdAccountSelect.Refresh();
		}

		private bool PostGLRateAdjustment(int pEntryId)
		{

			object mDefaultGlVoucherType = null;
			int mDefaultAdjustmentLdgrCd = 0;
			string mVoucherDate = "";
			decimal mAdjustmentAmt = 0;
			int mVoucherNo = 0;
			int mVoucherEntryId = 0;



			//''''GL entry to generated as follows
			//        Party A/c         Dr
			//            To Foreign Rate Adjustment a/c
			//'''''''''''''''''''''''''''''''''''''''''
			//'''''Note:'''''''''''''''''''''''''''''''
			//'''''if the adjustment_lc_amt > 0 then debit else credit

			string mysql = " select mt.voucher_date as voucher_date, mt.gl_generated_voucher_type as voucher_type ";
			mysql = mysql + " , mt.gl_adjustment_cd ";
			mysql = mysql + " , dt.cost_cd as cost_cd, sum(dt.adjustment_lc_amt) as adjustment_amt ";
			mysql = mysql + " from gl_rate_adjustment_details dt ";
			mysql = mysql + " inner join gl_rate_adjustment mt on dt.entry_id = mt.entry_id ";
			mysql = mysql + " where dt.entry_id =" + pEntryId.ToString();
			mysql = mysql + " group by mt.voucher_date, mt.gl_generated_voucher_type ";
			mysql = mysql + " , mt.gl_adjustment_cd, dt.cost_cd ";

			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			if (rsTempRec.Read())
			{
				mVoucherDate = Convert.ToString(rsTempRec["voucher_date"]);
				mDefaultGlVoucherType = rsTempRec["voucher_type"];
				mDefaultAdjustmentLdgrCd = Convert.ToInt32(rsTempRec["gl_adjustment_cd"]);

				if (!SystemProcedure2.ValidDateRange(DateTime.Parse(mVoucherDate)))
				{
					MessageBox.Show("Invalid Date, Not in the accounting period defined", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				mysql = " voucher_type = " + Conversion.Str(mDefaultGlVoucherType);
				mVoucherNo = Convert.ToInt32(Double.Parse(SystemProcedure2.GetNewNumber("gl_accnt_trans", "voucher_no", 2, mysql, " tablock(xlock) ")));

				mVoucherEntryId = SystemFAProcedure.FAInsertGLHeaderEntry(ReflectionHelper.GetPrimitiveValue<int>(mDefaultGlVoucherType), StringsHelper.Format(mVoucherDate, SystemVariables.gSystemDateFormat), mVoucherNo, "", "Auto Generated , Voucher Rate Adjustment ", 2, SystemVariables.gLoggedInUserCode);

				do 
				{
					mAdjustmentAmt = Convert.ToDecimal(rsTempRec["adjustment_amt"]);

					if (mAdjustmentAmt > 0)
					{
						//'''''''Rate Adjustment A/C Dr.
						SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, mDefaultAdjustmentLdgrCd.ToString(), Convert.ToString(rsTempRec["cost_cd"]), 1, mAdjustmentAmt * -1, (1 * mAdjustmentAmt) * -1, "C", StringsHelper.Format(mVoucherDate, SystemVariables.gSystemDateFormat), 1, 1);
					}
					else if (mAdjustmentAmt < 0)
					{ 
						SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, mDefaultAdjustmentLdgrCd.ToString(), Convert.ToString(rsTempRec["cost_cd"]), 1, (decimal) Math.Abs((double) mAdjustmentAmt), (decimal) Math.Abs((double) (1 * mAdjustmentAmt)), "D", StringsHelper.Format(mVoucherDate, SystemVariables.gSystemDateFormat), 1, 1);
					}
					else
					{
						return false;
					}

				}
				while(rsTempRec.Read());
				rsTempRec.Close();

				mysql = " select ldgr_cd, cost_cd , curr_cd , adjustment_lc_amt, adjustment_rate ";
				mysql = mysql + " from gl_rate_adjustment_details ";
				mysql = mysql + " where entry_id=" + pEntryId.ToString();
				SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
				rsTempRec = sqlCommand_2.ExecuteReader();
				bool rsTempRecDidRead2 = rsTempRec.Read();
				do 
				{
					if (Convert.ToDouble(rsTempRec["adjustment_lc_amt"]) > 0)
					{
						//'''''''Rate Adjustment A/C Dr.
						SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, Convert.ToString(rsTempRec["ldgr_cd"]), Convert.ToString(rsTempRec["cost_cd"]), Convert.ToDouble(rsTempRec["adjustment_rate"]), 0, Convert.ToDecimal(rsTempRec["adjustment_lc_amt"]), "D", StringsHelper.Format(mVoucherDate, SystemVariables.gSystemDateFormat), 1, 1);
					}
					else if (Convert.ToDouble(rsTempRec["adjustment_lc_amt"]) < 0)
					{ 
						SystemFAProcedure.FAInsertGLDetailsEntry(mVoucherEntryId, Convert.ToString(rsTempRec["ldgr_cd"]), Convert.ToString(rsTempRec["cost_cd"]), Convert.ToDouble(rsTempRec["adjustment_rate"]), 0, Convert.ToDecimal(rsTempRec["adjustment_lc_amt"]), "C", StringsHelper.Format(mVoucherDate, SystemVariables.gSystemDateFormat), 1, 1);
					}

				}
				while(rsTempRec.Read());

				mysql = " update gl_rate_adjustment ";
				mysql = mysql + " set gl_generated_entry_id =" + mVoucherEntryId.ToString();
				mysql = mysql + " where entry_id =" + pEntryId.ToString();
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

			}
			else
			{
				return false;
			}

			return true;
		}

		public void GRoutine()
		{

			//''Check the GL module is enabled
			string mysql = " select show from SM_MODULES ";
			mysql = mysql + " where module_id = 2";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
			{
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					mysql = " select gl_generated_voucher_type, gl_generated_entry_id from gl_rate_adjustment ";
					mysql = mysql + " where entry_id =" + Conversion.Str(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(0)))
						{
							if (SystemForms.GetSystemForm(310000, 2, ((Array) mReturnValue).GetValue(1), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0))))
							{
								//user has got access to the form
								//DoReportDrillDown = True
							}
							else
							{
								//access on the form is denied
								MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								//DoReportDrillDown = False
								//oReportGrid.SetFocus
							}
						}
						else
						{
							MessageBox.Show("No GL entry generated, due to Purchase date out of Current financial period range ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
				}
			}
		}
	}
}