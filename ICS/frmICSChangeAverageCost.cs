
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmICSChangeAverageCost
		: System.Windows.Forms.Form
	{

		public frmICSChangeAverageCost()
{
InitializeComponent();
} 
 public  void frmICSChangeAverageCost_old()
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


		private void frmICSChangeAverageCost_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		int mThisFormID = 0;
		
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

		public Control FirstFocusObject = null;

		private SystemICSConstants.ShowOptions mPostOptionType = (SystemICSConstants.ShowOptions) 0;

		private const int mNormalHeight = 2600;
		private const int mAdvancedHeight = 4600;

		private const string mAdvancedCaption = "&Advanced Mode >>";
		private const string mNormalCaption = "<< &Normal Mode";
		private const int ctlAdvancedModeDetailsIndex = 6;

		private const int conDefaultQtyMinusVoucherType = 424;
		private const int conDefaultQtyPlusVoucherType = 401;

		private const int conCurrentCost = 0;
		private const int conCurrentQty = 2;
		private const int conNewCost = 1;

		private const int conProductCode = 0;
		private const int conLocationCode = 1;
		private const int conMinusVoucherCode = 2;
		private const int conPlusVoucherCode = 3;

		private const int conProductName = 0;
		private const int conLocationName = 1;
		private const int conMinusVoucherName = 2;
		private const int conPlusVoucherName = 3;


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


		private void cmdPostMode_AccessKeyPress(Object eventSender, AxSmartNetButtonProject.__SmartNetButton_AccessKeyPressEvent eventArgs)
		{
			cmdPostMode_ClickEvent(cmdPostMode, new EventArgs());
		}

		private void cmdPostMode_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			if (mPostOptionType == SystemICSConstants.ShowOptions.optNormalMode)
			{
				mPostOptionType = SystemICSConstants.ShowOptions.optAdvancedMode;
			}
			else
			{
				mPostOptionType = SystemICSConstants.ShowOptions.optNormalMode;
			}
			ShowHideAdvancedOptions(mPostOptionType);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			clsHourGlass clsHour = new clsHourGlass();
			string mySql = "";

			FirstFocusObject = txtCommon[conProductCode];
			this.Top = 13;
			this.Left = 13;

			txtTransactionDate.Value = DateTime.Today;

			ShowHideAdvancedOptions(SystemICSConstants.ShowOptions.optNormalMode);

			cmdPostMode.CtlEnabled = SystemVariables.gLoggedInUserGroupCode == SystemConstants.gDefaultAdminGroupCode;

			//**--make the form visible before all the control gets loaded
			//**--(this way system pretends to be faster in loading forms)
			this.Show();
			Application.DoEvents();
			//**-------------------------------------------------------------------------------------------
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == ((int) Keys.Return))
				{ //Return or Enter key
					SendKeys.Send("{TAB}");
					return;
				}
				else if (KeyCode == ((int) Keys.Escape))
				{  //Escape key
					SystemForms.ToolBarButtonClick(this, "Exit");
					KeyCode = 0;
					return;
				}
				else if (KeyCode == 113)
				{  //F2 key
					FindRoutine(this.ActiveControl.Name + "#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
					KeyCode = 0;
					return;
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				UserAccess = null;
				frmICSChangeAverageCost.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCommon_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);
			FindRoutine(this.ActiveControl.Name + "#" + Index.ToString().Trim());
		}

		private void txtCommon_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommon, eventSender);
			object mTempValue = null;
			string mySql = "";

			try
			{
				switch(Index)
				{
					case conProductCode : 
						if (!SystemProcedure2.IsItEmpty(txtCommon[Index].Text, SystemVariables.DataType.StringType))
						{
							mySql = "select prod_cd, cost, current_qty, ";
							mySql = mySql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name" : "a_prod_name");
							mySql = mySql + "  from ICS_Item where part_no = '" + txtCommon[Index].Text.Trim() + "'";
							mySql = mySql + " and item_type_cd in (1, 3)";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mTempValue))
							{
								txtCommon[Index].Tag = "";
								txtCommonName[conProductName].Text = "";
								txtNCommon[conCurrentCost].Value = 0;
								txtNCommon[conCurrentQty].Value = 0;
								throw new System.Exception("-9990002");
							}
							else
							{
								txtCommon[Index].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtNCommon[conCurrentCost].Value = ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(1));
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtNCommon[conCurrentQty].Value = ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(2));
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtCommonName[conProductName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
							}
						}
						else
						{
							txtCommon[Index].Tag = "";
							txtCommonName[conProductName].Text = "";
							txtNCommon[conCurrentCost].Value = 0;
							txtNCommon[conCurrentQty].Value = 0;
						} 
						break;
					case conLocationCode : 
						if (!SystemProcedure2.IsItEmpty(txtCommon[Index].Text, SystemVariables.DataType.NumberType))
						{
							mySql = "select locat_cd, ";
							mySql = mySql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name");
							mySql = mySql + "  from SM_Location where locat_no = " + txtCommon[Index].Text;
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mTempValue))
							{
								txtCommon[Index].Tag = "";
								txtCommonName[conLocationName].Text = "";
								throw new System.Exception("-9990002");
							}
							else
							{
								txtCommon[Index].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtCommonName[conLocationName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
							}
						}
						else
						{
							txtCommon[Index].Tag = "";
							txtCommonName[conLocationName].Text = "";
						} 
						break;
					case conMinusVoucherCode : 
						if (!SystemProcedure2.IsItEmpty(txtCommon[Index].Text, SystemVariables.DataType.NumberType))
						{
							mySql = "select voucher_type, ";
							mySql = mySql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name" : "a_voucher_name");
							mySql = mySql + "  from ICS_Transaction_Types where voucher_type = " + txtCommon[Index].Text;
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mTempValue))
							{
								txtCommon[Index].Tag = "";
								txtCommonName[conMinusVoucherName].Text = "";
								throw new System.Exception("-9990002");
							}
							else
							{
								txtCommon[Index].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtCommonName[conMinusVoucherName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
							}
						}
						else
						{
							txtCommon[Index].Tag = "";
							txtCommonName[conMinusVoucherName].Text = "";
						} 
						break;
					case conPlusVoucherCode : 
						if (!SystemProcedure2.IsItEmpty(txtCommon[Index].Text, SystemVariables.DataType.NumberType))
						{
							mySql = "select voucher_type, ";
							mySql = mySql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name" : "a_voucher_name");
							mySql = mySql + "  from ICS_Transaction_Types where voucher_type = " + txtCommon[Index].Text;
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mTempValue))
							{
								txtCommon[Index].Tag = "";
								txtCommonName[conPlusVoucherName].Text = "";
								throw new System.Exception("-9990002");
							}
							else
							{
								txtCommon[Index].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtCommonName[conPlusVoucherName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
							}
						}
						else
						{
							txtCommon[Index].Tag = "";
							txtCommonName[conPlusVoucherName].Text = "";
						} 
						break;
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					txtCommon[Index].Focus();
				}
			}
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

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
					case conProductCode : 
						txtCommon[mObjectIndex].Text = ""; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001000, "28", "item_type_cd in (1, 3)")); 
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommon[mObjectIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
							txtCommon_Leave(txtCommon[mObjectIndex], new EventArgs());
						} 
						break;
					case conLocationCode : 
						txtCommon[mObjectIndex].Text = ""; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2004000, "82")); 
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommon[mObjectIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
							txtCommon_Leave(txtCommon[mObjectIndex], new EventArgs());
						} 
						break;
					default:
						return;
				}
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			CloseForm();
		}

		private void txtCommon_Click(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);
			FindRoutine(this.ActiveControl.Name + Index.ToString().Trim());
		}

		private void ShowHideAdvancedOptions(SystemICSConstants.ShowOptions ChangeToMode)
		{
			bool mShowSetting = false;

			if (ChangeToMode == SystemICSConstants.ShowOptions.optAdvancedMode)
			{
				mShowSetting = true;
				cmdPostMode.Caption = mNormalCaption;
				this.Height = mAdvancedHeight / 15;

				if (Convert.ToString(txtCommon[conLocationCode].Tag) == "")
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommon[conLocationCode].Text = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select locat_no from SM_Location where locat_cd = " + SystemConstants.gDefaultLocationCode.ToString()));
					txtCommon_Leave(txtCommon[conLocationCode], new EventArgs());
				}
				if (Convert.ToString(txtCommon[conMinusVoucherCode].Tag) == "")
				{
					txtCommon[conMinusVoucherCode].Text = conDefaultQtyMinusVoucherType.ToString();
					txtCommon_Leave(txtCommon[conMinusVoucherCode], new EventArgs());
				}
				if (Convert.ToString(txtCommon[conPlusVoucherCode].Tag) == "")
				{
					txtCommon[conPlusVoucherCode].Text = conDefaultQtyPlusVoucherType.ToString();
					txtCommon_Leave(txtCommon[conPlusVoucherCode], new EventArgs());
				}
			}
			else
			{
				mShowSetting = false;
				cmdPostMode.Caption = mAdvancedCaption;
				this.Height = mNormalHeight / 15;
			}
			fraCommon.Visible = mShowSetting;
			Line1.Visible = mShowSetting;
			lblCommon[ctlAdvancedModeDetailsIndex].Visible = mShowSetting;
			mPostOptionType = ChangeToMode;
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			string mySql = "";
			DataSet rsProductDetails = null;
			int mGeneratedEntryID = 0;
			//**--to display the HourGlass
			clsHourGlass clsHour = new clsHourGlass();

			try
			{

				txtCommon_Leave(txtCommon[conProductCode], new EventArgs());

				if (mPostOptionType == SystemICSConstants.ShowOptions.optAdvancedMode)
				{
					txtCommon_Leave(txtCommon[conLocationCode], new EventArgs());
				}
				else
				{
					txtCommon[conLocationCode].Tag = SystemConstants.gDefaultLocationCode.ToString();
					txtCommon[conMinusVoucherCode].Tag = conDefaultQtyMinusVoucherType.ToString();
					txtCommon[conPlusVoucherCode].Tag = conDefaultQtyPlusVoucherType.ToString();
				}
				SystemVariables.gConn.BeginTransaction();

				mySql = " select prod_cd, cost, item_type_cd, current_qty ";
				mySql = mySql + " , base_unit_cd, item_type_cd ";
				mySql = mySql + " , l_prod_name, a_prod_name ";
				mySql = mySql + " from ICS_Item ";
				mySql = mySql + " where prod_cd = " + Convert.ToString(txtCommon[conProductCode].Tag);
				rsProductDetails = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProductDetails.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsProductDetails.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mySql, SystemVariables.gConn);
				rsProductDetails.Tables.Clear();
				adap.Fill(rsProductDetails);

				if (rsProductDetails.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("-1, , Error: ICS_Item code not found");
				}

				//**--if ICS_Item current qty is greater than 0 then
				//**--nullify the current_qty with "Shortages-in-Stock" voucher
				//**--and then increase the stock-in-hand with "Opening Stock" voucher
				//**--when the current_qty is "Zero" and a voucher which affects cost
				//**--is created, it'll the new transaction rate
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (Convert.ToDouble(rsProductDetails.Tables[0].Rows[0]["current_qty"]) > 0)
				{
					//**--generate a shortages voucher and post it
					mGeneratedEntryID = GenerateTransactionMaster(Convert.ToInt32(Double.Parse(Convert.ToString(txtCommon[conMinusVoucherCode].Tag))), Convert.ToInt32(Double.Parse(Convert.ToString(txtCommon[conLocationCode].Tag))), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtTransactionDate.Value));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					GenerateTransactionDetails(mGeneratedEntryID, "Null", Convert.ToString(txtCommon[conLocationCode].Tag), Convert.ToInt32(rsProductDetails.Tables[0].Rows[0]["prod_cd"]), Convert.ToInt32(rsProductDetails.Tables[0].Rows[0]["base_unit_cd"]), Convert.ToInt32(rsProductDetails.Tables[0].Rows[0]["item_type_cd"]), Convert.ToDouble(rsProductDetails.Tables[0].Rows[0]["current_qty"]), 0, 0, 0, Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsProductDetails.Tables[0].Rows[0]["l_prod_name"] : rsProductDetails.Tables[0].Rows[0]["a_prod_name"]));
					PostGeneratedTransaction(mGeneratedEntryID);

					//**--generate an opening voucher and post it
					mGeneratedEntryID = GenerateTransactionMaster(Convert.ToInt32(Double.Parse(Convert.ToString(txtCommon[conPlusVoucherCode].Tag))), Convert.ToInt32(Double.Parse(Convert.ToString(txtCommon[conLocationCode].Tag))), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtTransactionDate.Value));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					GenerateTransactionDetails(mGeneratedEntryID, Convert.ToString(txtCommon[conLocationCode].Tag), "Null", Convert.ToInt32(rsProductDetails.Tables[0].Rows[0]["prod_cd"]), Convert.ToInt32(rsProductDetails.Tables[0].Rows[0]["base_unit_cd"]), Convert.ToInt32(rsProductDetails.Tables[0].Rows[0]["item_type_cd"]), Convert.ToDouble(rsProductDetails.Tables[0].Rows[0]["current_qty"]), ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[conNewCost].Value), 0, ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[conNewCost].Value) * Convert.ToDouble(rsProductDetails.Tables[0].Rows[0]["current_qty"]), Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsProductDetails.Tables[0].Rows[0]["l_prod_name"] : rsProductDetails.Tables[0].Rows[0]["a_prod_name"]));
					PostGeneratedTransaction(mGeneratedEntryID);
				}
				else
				{
					//**--generate an opening voucher and post it
					mGeneratedEntryID = GenerateTransactionMaster(Convert.ToInt32(Double.Parse(Convert.ToString(txtCommon[conPlusVoucherCode].Tag))), Convert.ToInt32(Double.Parse(Convert.ToString(txtCommon[conLocationCode].Tag))), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtTransactionDate.Value));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					GenerateTransactionDetails(mGeneratedEntryID, Convert.ToString(txtCommon[conLocationCode].Tag), "Null", Convert.ToInt32(rsProductDetails.Tables[0].Rows[0]["prod_cd"]), Convert.ToInt32(rsProductDetails.Tables[0].Rows[0]["base_unit_cd"]), Convert.ToInt32(rsProductDetails.Tables[0].Rows[0]["item_type_cd"]), 1, ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[conNewCost].Value), 0, ReflectionHelper.GetPrimitiveValue<double>(txtNCommon[conNewCost].Value) * 1, Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsProductDetails.Tables[0].Rows[0]["l_prod_name"] : rsProductDetails.Tables[0].Rows[0]["a_prod_name"]));
					PostGeneratedTransaction(mGeneratedEntryID);

					//**--generate a shortages voucher and post it
					mGeneratedEntryID = GenerateTransactionMaster(Convert.ToInt32(Double.Parse(Convert.ToString(txtCommon[conMinusVoucherCode].Tag))), Convert.ToInt32(Double.Parse(Convert.ToString(txtCommon[conLocationCode].Tag))), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtTransactionDate.Value));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					GenerateTransactionDetails(mGeneratedEntryID, "Null", Convert.ToString(txtCommon[conLocationCode].Tag), Convert.ToInt32(rsProductDetails.Tables[0].Rows[0]["prod_cd"]), Convert.ToInt32(rsProductDetails.Tables[0].Rows[0]["base_unit_cd"]), Convert.ToInt32(rsProductDetails.Tables[0].Rows[0]["item_type_cd"]), 1, 0, 0, 0, Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? rsProductDetails.Tables[0].Rows[0]["l_prod_name"] : rsProductDetails.Tables[0].Rows[0]["a_prod_name"]));
					PostGeneratedTransaction(mGeneratedEntryID);
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				MessageBox.Show("Average cost successfully changed for ICS_Item code : " + txtCommon[conProductCode].Text, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				CloseForm();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show((Double.Parse(excep.Message) + Information.Err().Number).ToString(), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void PostGeneratedTransaction(int pGeneratedEntryID)
		{
			//**--to display the HourGlass
			clsHourGlass clsHour = new clsHourGlass();

			string mySql = "update ICS_Transaction ";
			mySql = mySql + " set posted_invnt = 1";
			mySql = mySql + " where entry_id = " + Conversion.Str(pGeneratedEntryID);
			mySql = mySql + " and posted_invnt = 0 ";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mySql;
			TempCommand.ExecuteNonQuery();

			mySql = "update ICS_Transaction ";
			mySql = mySql + " set posted_gl_party = 1";
			mySql = mySql + " where entry_id = " + Conversion.Str(pGeneratedEntryID);
			mySql = mySql + " and posted_gl_party = 0 ";
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mySql;
			TempCommand_2.ExecuteNonQuery();

			mySql = "update ICS_Transaction ";
			mySql = mySql + " set status = 2";
			mySql = mySql + " where entry_id = " + Conversion.Str(pGeneratedEntryID);
			mySql = mySql + " and status = 1 ";
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mySql;
			TempCommand_3.ExecuteNonQuery();

			mySql = "update ICS_Transaction ";
			mySql = mySql + " set posted_gl_expense = 1";
			mySql = mySql + " where entry_id = " + Conversion.Str(pGeneratedEntryID);
			mySql = mySql + " and posted_gl_expense = 0 ";
			SqlCommand TempCommand_4 = null;
			TempCommand_4 = SystemVariables.gConn.CreateCommand();
			TempCommand_4.CommandText = mySql;
			TempCommand_4.ExecuteNonQuery();

			mySql = "update ICS_Transaction ";
			mySql = mySql + " set posted_gl_inventory = 1";
			mySql = mySql + " where entry_id = " + Conversion.Str(pGeneratedEntryID);
			mySql = mySql + " and posted_gl_inventory = 0 ";
			SqlCommand TempCommand_5 = null;
			TempCommand_5 = SystemVariables.gConn.CreateCommand();
			TempCommand_5.CommandText = mySql;
			TempCommand_5.ExecuteNonQuery();

			mySql = "update ICS_Transaction ";
			mySql = mySql + " set posted_gl = 1";
			mySql = mySql + " where entry_id = " + Conversion.Str(pGeneratedEntryID);
			mySql = mySql + " and posted_gl = 0 ";
			SqlCommand TempCommand_6 = null;
			TempCommand_6 = SystemVariables.gConn.CreateCommand();
			TempCommand_6.CommandText = mySql;
			TempCommand_6.ExecuteNonQuery();
		}

		private int GenerateTransactionMaster(int pVoucherType, int pLocationCode, System.DateTime pTransactionDate)
		{
			//**--to display the HourGlass
			clsHourGlass clsHour = new clsHourGlass();

			string mySql = " select isnull(max(voucher_no), 0) + 1 from ICS_Transaction with (xlock) ";
			mySql = mySql + " where voucher_type = " + Conversion.Str(pVoucherType);
			mySql = mySql + " and locat_cd = " + Conversion.Str(pLocationCode);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mGeneratedVoucherNo = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mySql));

			mySql = "insert into ICS_Transaction ";
			mySql = mySql + " (voucher_type, locat_cd, voucher_date, voucher_no, ";
			mySql = mySql + " on_hand_stock_affected, comments, posted_invnt, status, ";
			mySql = mySql + " posted_gl_party, posted_gl_expense, posted_gl_inventory, ";
			mySql = mySql + " posted_gl, user_cd)";
			mySql = mySql + " values (";
			mySql = mySql + Conversion.Str(pVoucherType);
			mySql = mySql + ", " + Conversion.Str(pLocationCode);
			mySql = mySql + ", '" + StringsHelper.Format(pTransactionDate, SystemVariables.gSystemDateFormat) + "'";
			mySql = mySql + ", " + Conversion.Str(mGeneratedVoucherNo);
			mySql = mySql + ", 1";
			mySql = mySql + ", 'Auto generated transaction to change ICS_Item average cost'";
			mySql = mySql + ", 0, 1, 0, 0, 0, 0";
			mySql = mySql + ", " + Conversion.Str(SystemVariables.gLoggedInUserCode);
			mySql = mySql + ")";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mySql;
			TempCommand.ExecuteNonQuery();

			return ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
		}

		private int GenerateTransactionDetails(int pGeneratedEntryID, string pAddLocationCode, string pLessLocationCode, int pProductCode, int pBaseUnitCode, int pItemTypeCode, double pCurrentQty, double pFCRate, double pFCDiscount, double pFCAmount, string pProductName)
		{
			//**--to display the HourGlass
			clsHourGlass clsHour = new clsHourGlass();

			string mySql = "insert into ICS_Transaction_Details ";
			mySql = mySql + " (entry_id, add_locat_cd, less_locat_cd, prod_cd, prod_name ";
			mySql = mySql + " , unit_entry_id, qty, base_qty, fc_rate ";
			mySql = mySql + " , fc_prod_dis, fc_amount, item_type_cd) ";
			mySql = mySql + " values (";
			mySql = mySql + Conversion.Str(pGeneratedEntryID);
			mySql = mySql + ", " + pAddLocationCode;
			mySql = mySql + ", " + pLessLocationCode;
			mySql = mySql + ", " + Conversion.Str(pProductCode);
			mySql = mySql + ", '" + pProductName + "'";
			mySql = mySql + ", " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select unit_entry_id from ICS_Item_Unit_Details where prod_cd =" + Conversion.Str(pProductCode) + " and alt_unit_cd = " + Conversion.Str(pBaseUnitCode) + " and base_unit_cd = " + Conversion.Str(pBaseUnitCode)));
			mySql = mySql + ", " + Conversion.Str(pCurrentQty);
			mySql = mySql + ", " + Conversion.Str(pCurrentQty);
			mySql = mySql + ", " + Conversion.Str(pFCRate);
			mySql = mySql + ", " + Conversion.Str(pFCDiscount);
			mySql = mySql + ", " + Conversion.Str(pFCAmount);
			mySql = mySql + ", " + Conversion.Str(pItemTypeCode);
			mySql = mySql + ")";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mySql;
			TempCommand.ExecuteNonQuery();

			return 0;
		}
	}
}