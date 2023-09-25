
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmREPropertyItemsUnitDetails
		: System.Windows.Forms.Form
	{

		public frmREPropertyItemsUnitDetails()
{
InitializeComponent();
} 
 public  void frmREPropertyItemsUnitDetails_old()
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


		private void frmREPropertyItemsUnitDetails_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private clsToolbar oThisFormToolBar = null;
		public Control FirstFocusObject = null;

		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;


		private const int conTXTUnitNo = 0;
		private const int conTXTItemNo = 1;
		private const int conTxtPropertyNo = 2;
		private const int conTXTStatusNo = 3;
		//Private Const conTXTContractNo As Integer = 4
		private const int conTXTUnitAmount = 0;
		private const int conTXTFloorNo = 6;
		private const int conTXTAreaSize = 7;
		private const int conTXTTotalRestRooms = 8;
		private const int conTXTTotalBalcony = 9;
		private const int conTXTTotalKitchens = 10;
		private const int conTXTTotalBedRooms = 11;
		private const int conTXTTotalBathRooms = 12;

		private const int conDlbltemName = 0;
		private const int conDlblPropertyName = 1;
		private const int conDlblStatusName = 2;
		private const int conDlblContractAmt = 3;
		private const int conDlblContractNo = 4;



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

			try
			{

				FirstFocusObject = txtCommon[conTxtPropertyNo];
				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);

				//**--make the form visible before all the control gets loaded
				//**--(this way system pretends to be faster in loading forms)
				this.Show();
				Application.DoEvents();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}

		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 13)
				{
					SendKeys.Send("{TAB}");
					return;
				}

				if (this.ActiveControl.Name != "txtCommon")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommon#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void AddRecord()
		{

			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearNumberBox(this);
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;

			mSearchValue = "";
			FirstFocusObject.Focus();
			txtCommon[conTXTStatusNo].Enabled = false;

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord(bool pPostGl = false)
		{
			bool result = false;
			object mReturnValue = null;
			string mySQL = "";

			object mItemCd = null;
			object mPropertyCd = null;
			object mStatusCd = null;

			string myErrMsg = "";
			try
			{

				SystemVariables.gConn.BeginTransaction();

				mySQL = " select item_cd from re_property_items ";
				mySQL = mySQL + " where item_no = " + txtCommon[conTXTItemNo].Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					myErrMsg = "Invalid Item No";
					txtCommon[conTXTItemNo].Focus();
					throw new Exception();
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mItemCd = ReflectionHelper.GetPrimitiveValue(mReturnValue);
				}


				mySQL = " select property_cd from re_property ";
				mySQL = mySQL + " where property_no ='" + txtCommon[conTxtPropertyNo].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					myErrMsg = "Invalid Property No";
					txtCommon[conTxtPropertyNo].Focus();
					throw new Exception();
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mPropertyCd = ReflectionHelper.GetPrimitiveValue(mReturnValue);
				}

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mStatusCd = 1;
				}
				else
				{
					mySQL = " select property_status_cd from re_property_status ";
					mySQL = mySQL + " where status_no = " + txtCommon[conTXTStatusNo].Text;
					mySQL = mySQL + " and allow_manual_change = 1 ";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						myErrMsg = " Invalid Status No.";
						txtCommon[conTXTStatusNo].Focus();
						throw new Exception();
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mStatusCd = ReflectionHelper.GetPrimitiveValue(mReturnValue);
					}
				}

				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mySQL = " insert into RE_Property_Item_Unit_Details ";
					mySQL = mySQL + " (Unit_No,Property_Cd, property_status_cd, Item_Cd ";
					mySQL = mySQL + " , Unit_Amt, Floor_No,Area_Size";
					mySQL = mySQL + " , Total_Rest_Rooms,Total_Balcony,Total_Kitchens,Total_Bed_Rooms ";
					mySQL = mySQL + " , total_Bath_Rooms,comments,User_Cd) ";
					mySQL = mySQL + " values( ";
					mySQL = mySQL + " '" + txtCommon[conTXTUnitNo].Text + "'";
					mySQL = mySQL + "," + ReflectionHelper.GetPrimitiveValue<string>(mPropertyCd);
					mySQL = mySQL + "," + ReflectionHelper.GetPrimitiveValue<string>(mStatusCd);
					mySQL = mySQL + "," + ReflectionHelper.GetPrimitiveValue<string>(mItemCd);
					mySQL = mySQL + "," + ReflectionHelper.GetPrimitiveValue<string>(txtNumber[conTXTUnitAmount].Value);
					mySQL = mySQL + ",'" + txtCommon[conTXTFloorNo].Text + "'";
					mySQL = mySQL + ",'" + txtCommon[conTXTAreaSize].Text + "'";
					mySQL = mySQL + ",'" + txtCommon[conTXTTotalRestRooms].Text + "'";
					mySQL = mySQL + ",'" + txtCommon[conTXTTotalBalcony].Text + "'";
					mySQL = mySQL + ",'" + txtCommon[conTXTTotalKitchens].Text + "'";
					mySQL = mySQL + ",'" + txtCommon[conTXTTotalBedRooms].Text + "'";
					mySQL = mySQL + ",'" + txtCommon[conTXTTotalBathRooms].Text + "'";
					mySQL = mySQL + ",N'" + txtRemarks.Text + "'";
					mySQL = mySQL + "," + SystemVariables.gLoggedInUserCode.ToString();
					mySQL = mySQL + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mySQL;
					TempCommand.ExecuteNonQuery();
				}
				else if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{ 
					mySQL = "update RE_Property_Item_Unit_Details ";
					mySQL = mySQL + " set Unit_No = " + "'" + txtCommon[conTXTUnitNo].Text + "'";
					mySQL = mySQL + " , Property_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(mPropertyCd);
					mySQL = mySQL + " , property_status_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mStatusCd);
					mySQL = mySQL + " , Item_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(mItemCd);
					mySQL = mySQL + " , Unit_Amt = " + ReflectionHelper.GetPrimitiveValue<string>(txtNumber[conTXTUnitAmount].Value);
					mySQL = mySQL + " , Floor_No = '" + txtCommon[conTXTFloorNo].Text + "'";
					mySQL = mySQL + " , Area_Size = N'" + txtCommon[conTXTAreaSize].Text + "'";
					mySQL = mySQL + " , Total_Rest_Rooms ='" + txtCommon[conTXTTotalRestRooms].Text + "'";
					mySQL = mySQL + " , Total_Balcony = '" + txtCommon[conTXTTotalBalcony].Text + "'";
					mySQL = mySQL + " , Total_Kitchens = '" + txtCommon[conTXTTotalKitchens].Text + "'";
					mySQL = mySQL + " , Total_Bed_Rooms = '" + txtCommon[conTXTTotalBedRooms].Text + "'";
					mySQL = mySQL + " , Total_Bath_Rooms = '" + txtCommon[conTXTTotalBathRooms].Text + "'";
					mySQL = mySQL + " , comments = N'" + txtRemarks.Text + "'";
					mySQL = mySQL + " where Unit_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mySQL;
					TempCommand_2.ExecuteNonQuery();
				}
				result = true;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//If myErrMsg = "" Then
				//    myErrMsg = "This Unit Number Already Exist for " & txtCommonDisplay(conDlblPropertyName).Text & " Property "
				//End If

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				myErrMsg = excep.Message + Information.Err().Number.ToString();
				MessageBox.Show(myErrMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}
			return result;
		}


		public bool deleteRecord()
		{
			bool result = false;

			SystemVariables.gConn.BeginTransaction();
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mySQL = "delete from re_Property_item_unit_details where unit_Cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mySQL;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Unit cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();


				return true;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
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
			return result;
		}

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			try
			{
				string mySQL = "";
				DataSet localRec = null;

				mySQL = "select unit_cd,unit_no,property_no,status_no,item_no";
				mySQL = mySQL + " , c.contract_no, isnull(c.contract_amt,0) contract_amt ";
				mySQL = mySQL + " , floor_no,area_size,unit_amt,total_kitchens,total_bed_rooms,total_bath_rooms, ";
				mySQL = mySQL + " l_property_name,a_property_name,l_status_name,a_status_name,";
				mySQL = mySQL + " l_item_name,a_item_name,";
				mySQL = mySQL + " l_tenant_name,a_tenant_name,";
				mySQL = mySQL + " total_rest_rooms,total_balcony,iud.comments ";
				mySQL = mySQL + " , ps.allow_manual_change ";
				mySQL = mySQL + " from re_property_item_unit_details iud ";
				mySQL = mySQL + " inner join re_property p on iud.property_cd = p.property_cd  ";
				mySQL = mySQL + " inner join re_property_items pi on iud.item_cd = pi.item_cd ";
				mySQL = mySQL + " inner join re_property_status ps on iud.property_status_cd = ps.property_status_cd ";
				mySQL = mySQL + " left join re_contract c on iud.contract_cd = c.contract_cd ";
				mySQL = mySQL + " left join re_tenant t on c.tenant_cd = t.tenant_cd ";
				mySQL = mySQL + " where Unit_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				localRec = new DataSet();
				SqlDataAdapter adap = new SqlDataAdapter(mySQL, SystemVariables.gConn);
				localRec.Tables.Clear();
				adap.Fill(localRec);
				if (localRec.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mSearchValue = localRec.Tables[0].Rows[0]["Unit_Cd"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTXTUnitNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Unit_No"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTxtPropertyNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Property_No"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTXTStatusNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Status_No"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTXTItemNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Item_No"]);

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conDlblContractNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Contract_No"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToDouble(localRec.Tables[0].Rows[0]["Contract_amt"]) > 0)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conDlblContractAmt].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["Contract_amt"], "###,###,###,##0.000");
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTXTFloorNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Floor_No"]).Trim();
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTXTAreaSize].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Area_Size"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtNumber[conTXTUnitAmount].Value = localRec.Tables[0].Rows[0]["Unit_Amt"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTXTTotalKitchens].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Total_Kitchens"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTXTTotalBathRooms].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Total_Bath_Rooms"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTXTTotalRestRooms].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Total_Rest_Rooms"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTXTTotalBalcony].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Total_Balcony"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTXTTotalBedRooms].Text = Convert.ToString(localRec.Tables[0].Rows[0]["Total_Bed_Rooms"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtRemarks.Text = Convert.ToString(localRec.Tables[0].Rows[0]["comments"]);

					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conDlblPropertyName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["l_Property_name"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conDlblStatusName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["L_Status_Name"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conDlbltemName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["L_Item_Name"]);
						//txtCommonDisplay(conDlblTenantName).Text = .Fields("L_Tenant_Name") & ""
					}
					else
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conDlblPropertyName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["A_Property_name"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conDlblStatusName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["A_Status_Name"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conDlbltemName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["A_Item_Name"]);
						//txtCommonDisplay(conDlblTenantName).Text = .Fields("A_Tenant_Name") & ""
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTXTStatusNo].Enabled = Convert.ToBoolean(localRec.Tables[0].Rows[0]["allow_manual_change"]);

					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				}
				localRec = null;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9017000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool CheckDataValidity()
		{

			if (SystemProcedure2.IsItEmpty(txtCommon[conTXTItemNo].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter the Item No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txtCommon[conTXTItemNo].Focus();
				goto mError;
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[conTxtPropertyNo].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter the Property No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txtCommon[conTxtPropertyNo].Focus();
				goto mError;
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[conTXTUnitNo].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter the Unit No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txtCommon[conTXTUnitNo].Focus();
				goto mError;
			}


			if (CurrentFormMode != SystemVariables.SystemFormModes.frmAddMode)
			{
				if (SystemProcedure2.IsItEmpty(txtCommon[conTXTStatusNo].Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter the Status No.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txtCommon[conTXTStatusNo].Focus();
					goto mError;
				}
			}

			//If (Trim(txtNumber(conTXTUnitAmount).Value) = "") Then
			//   MsgBox "You have to enter the Unit Amount"
			//   txtCommon(conTXTUnitAmount).SetFocus
			//   GoTo mError
			//End If
			//
			//If (Trim(txtCommon(conTXTFloorNo).Text) = "") Then
			//   MsgBox "You have to enter the Floor No"
			//   txtCommon(conTXTFloorNo).SetFocus
			//   GoTo mError
			//End If
			//
			//If (Trim(txtCommon(conTXTAreaSize).Text) = "") Then
			//   MsgBox "You have to enter the Area Size"
			//   txtCommon(conTXTAreaSize).SetFocus
			//   GoTo mError
			//End If
			//
			//If (Trim(txtCommon(conTXTTotalRestRooms).Text) = "") Then
			//   MsgBox "You have to enter the Total Rest Rooms"
			//   txtCommon(conTXTTotalRestRooms).SetFocus
			//   GoTo mError
			//End If
			//
			//If (Trim(txtCommon(conTXTTotalBalcony).Text) = "") Then
			//   MsgBox "You have to enter the Total Balcony"
			//   txtCommon(conTXTTotalBalcony).SetFocus
			//   GoTo mError
			//End If
			//
			//If (Trim(txtCommon(conTXTTotalKitchens).Text) = "") Then
			//   MsgBox "You have to enter the Total Kitchens"
			//   txtCommon(conTXTTotalKitchens).SetFocus
			//   GoTo mError
			//End If
			//
			//If (Trim(txtCommon(conTXTTotalBedRooms).Text) = "") Then
			//   MsgBox "You have to enter the Total Bed Rooms"
			//   txtCommon(conTXTTotalBedRooms).SetFocus
			//   GoTo mError
			//End If
			//
			//If (Trim(txtCommon(conTXTTotalBathRooms).Text) = "") Then
			//   MsgBox "You have to enter the Total Bath Rooms"
			//   txtCommon(conTXTTotalBathRooms).SetFocus
			//   GoTo mError
			//End If

			return true;

			mError:
			return false;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

			UserAccess = null;
			oThisFormToolBar = null;
			frmREPropertyItemsUnitDetails.DefInstance = null;
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
					case conTxtPropertyNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9001000, "1323")); 
						break;
					case conTXTItemNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9012000, "1379")); 
						break;
					case conTXTStatusNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9016000, "1406")); 
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

		}

		private void txtCommon_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);
			string mWhereClause = "";
			if (Index == conTXTUnitNo)
			{
				if (txtCommon[conTxtPropertyNo].Text != "")
				{
					mWhereClause = " inner join re_property p on iud.property_cd = p.property_cd and property_no ='" + txtCommon[conTxtPropertyNo].Text + "'";
					txtCommon[conTXTUnitNo].Text = SystemProcedure2.GetNewNumber("re_property_item_unit_details iud", "UNIT_No", 2, "", mWhereClause);
				}
				else
				{
					MessageBox.Show("You have to choose a Property First", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			else
			{
				FindRoutine("txtCommon#" + Index.ToString().Trim());
			}
		}

		private void txtCommon_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommon, eventSender);

			object mTempValue = null;
			string mySQL = "";
			int mLinkedTextBoxIndex = 0;

			try
			{
				switch(Index)
				{
					case conTxtPropertyNo : 
						mySQL = "select L_Property_Name,A_Property_Name from re_property where property_no = '" + txtCommon[Index].Text + "'"; 
						mLinkedTextBoxIndex = conDlblPropertyName; 
						break;
					case conTXTStatusNo : 
						mySQL = "select L_Status_Name,A_Status_Name from re_property_status where status_no = " + txtCommon[Index].Text; 
						mySQL = mySQL + " and allow_manual_change = 1 "; 
						mLinkedTextBoxIndex = conDlblStatusName; 
						break;
					case conTXTItemNo : 
						mySQL = "select L_Item_Name,A_Item_Name from re_property_items where item_no = " + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conDlbltemName; 
						break;
					default:
						return;
				}

				if (!SystemProcedure2.IsItEmpty(txtCommon[Index].Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
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

						if (Index == conTxtPropertyNo && SystemProcedure2.IsItEmpty(txtCommon[conTXTUnitNo].Text, SystemVariables.DataType.StringType))
						{
							if (txtCommon[conTxtPropertyNo].Text != "")
							{

								mySQL = " inner join re_property p on iud.property_cd = p.property_cd and property_no ='" + txtCommon[conTxtPropertyNo].Text + "'";
								txtCommon[conTXTUnitNo].Text = SystemProcedure2.GetNewNumber("re_property_item_unit_details iud", "unit_no", 2, "", mySQL);


								if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
								{
									mySQL = " select status_no";
									if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
									{
										mySQL = mySQL + " , l_status_name";
									}
									else
									{
										mySQL = mySQL + " , a_status_name ";
									}
									mySQL = mySQL + " from re_property_status ";
									mySQL = mySQL + " where property_status_cd = 1 ";

									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
									if (!Convert.IsDBNull(mTempValue))
									{
										//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
										txtCommon[conTXTStatusNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
										//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
										txtCommonDisplay[conDlblStatusName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
									}
								}
							}
						}
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
	}
}