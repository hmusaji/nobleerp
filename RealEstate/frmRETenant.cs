
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmRETenant
		: System.Windows.Forms.Form
	{

		public frmRETenant()
{
InitializeComponent();
} 
 public  void frmRETenant_old()
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


		private void frmRETenant_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		
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


		private const int conTXTTenantNo = 0;
		private const int conTxtLTenantName = 1;
		private const int conTxtATenantName = 2;
		private const int conTxtNationalityNo = 3;
		private const int conTxtBankNo = 4;
		private const int conTxtPassportNo = 5;
		private const int conTxtCivilId = 6;
		private const int conTxtMobileNo = 7;
		private const int conTxtFaxNo = 8;
		private const int conTxtRemarks = 9;
		private const int conTxtTelNo = 10;
		private const int conTxtAddress1 = 11;
		private const int conTxtAddress2 = 12;
		private const int conTxtEmailId = 13;
		private const int conTxtWebsite = 14;

		private const int conTxtNationalityName = 0;
		private const int conTxtBankName = 1;




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
				FirstFocusObject = txtCommon[conTXTTenantNo];
				txtCommon[conTXTTenantNo].Text = SystemProcedure2.GetNewNumber("re_tenant", "tenant_No", 3);
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

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			mSearchValue = "";
			FirstFocusObject.Focus();
			txtCommon[conTXTTenantNo].Text = SystemProcedure2.GetNewNumber("re_tenant", "tenant_No", 3);
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord(bool pPostGl = false)
		{
			bool result = false;
			int mEntryID = 0;
			int mNationalityCd = 0;
			int mBankCd = 0;


			//On Error GoTo eFoundError


			SystemVariables.gConn.BeginTransaction();
			string mySQL = " select Nationality_Cd from re_nationality ";
			mySQL = mySQL + " where nationality_no = " + txtCommon[conTxtNationalityNo].Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				MessageBox.Show("Invalid Nationality No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txtCommon[conTxtNationalityNo].Focus();
				goto eFoundError;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mNationalityCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}

			if (!SystemProcedure2.IsItEmpty(txtCommon[conTxtBankNo].Text, SystemVariables.DataType.NumberType))
			{
				mySQL = " select Bank_Cd from re_bank where bank_no = " + txtCommon[conTxtBankNo].Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Bank No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txtCommon[conTxtBankNo].Focus();
					goto eFoundError;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mBankCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
			}
			else
			{
				mBankCd = 0;
			}

			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				mySQL = " insert into RE_Tenant ";
				mySQL = mySQL + " (Tenant_No, L_Tenant_Name, A_Tenant_Name,Nationality_Cd,Bank_Cd ";
				mySQL = mySQL + " , Passport_No,Civil_Id_No,Mobile_No,Fax_No";
				mySQL = mySQL + " , comments, tel_no, address_1, address_2, email_id, website ";
				mySQL = mySQL + " ,User_Cd) ";
				mySQL = mySQL + " values( ";
				mySQL = mySQL + " '" + txtCommon[conTXTTenantNo].Text + "'";
				mySQL = mySQL + ",'" + txtCommon[conTxtLTenantName].Text + "'";
				mySQL = mySQL + ",N'" + txtCommon[conTxtATenantName].Text + "'";
				mySQL = mySQL + "," + mNationalityCd.ToString();
				if (mBankCd == 0)
				{
					mySQL = mySQL + ", NULL ";
				}
				else
				{
					mySQL = mySQL + "," + mBankCd.ToString();
				}

				mySQL = mySQL + ",'" + txtCommon[conTxtPassportNo].Text + "'";
				mySQL = mySQL + ",'" + txtCommon[conTxtCivilId].Text + "'";
				mySQL = mySQL + ",'" + txtCommon[conTxtMobileNo].Text + "'";
				mySQL = mySQL + ",'" + txtCommon[conTxtFaxNo].Text + "'";
				mySQL = mySQL + ",N'" + txtCommon[conTxtRemarks].Text + "'";
				mySQL = mySQL + ",'" + txtCommon[conTxtTelNo].Text + "'";
				mySQL = mySQL + ",N'" + txtCommon[conTxtAddress1].Text + "'";
				mySQL = mySQL + ",N'" + txtCommon[conTxtAddress2].Text + "'";
				mySQL = mySQL + ",'" + txtCommon[conTxtEmailId].Text + "'";
				mySQL = mySQL + ",'" + txtCommon[conTxtWebsite].Text + "'";
				mySQL = mySQL + "," + SystemVariables.gLoggedInUserCode.ToString();
				mySQL = mySQL + " )";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mySQL;
				TempCommand.ExecuteNonQuery();
			}
			else if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{ 

				//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryID = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);

				mySQL = " update RE_Tenant ";
				mySQL = mySQL + " set Tenant_No = " + "'" + txtCommon[conTXTTenantNo].Text + "'";
				mySQL = mySQL + " , L_Tenant_Name = " + "'" + txtCommon[conTxtLTenantName].Text + "'";
				mySQL = mySQL + " , A_Tenant_Name = " + "N'" + txtCommon[conTxtATenantName].Text + "'";
				mySQL = mySQL + " , Nationality_Cd = " + mNationalityCd.ToString();
				if (mBankCd == 0)
				{
					mySQL = mySQL + " , Bank_Cd = NULL ";
				}
				else
				{
					mySQL = mySQL + " , Bank_Cd = " + mBankCd.ToString();
				}
				mySQL = mySQL + " , Passport_No = '" + txtCommon[conTxtPassportNo].Text + "'";
				mySQL = mySQL + " , Civil_Id_No = '" + txtCommon[conTxtCivilId].Text + "'";
				mySQL = mySQL + " , Mobile_No = '" + txtCommon[conTxtMobileNo].Text + "'";
				mySQL = mySQL + " , Fax_No = '" + txtCommon[conTxtFaxNo].Text + "'";
				mySQL = mySQL + " , tel_No = '" + txtCommon[conTxtTelNo].Text + "'";
				mySQL = mySQL + " , comments = N'" + txtCommon[conTxtRemarks].Text + "'";
				mySQL = mySQL + " , address_1 = N'" + txtCommon[conTxtAddress1].Text + "'";
				mySQL = mySQL + " , address_2 = N'" + txtCommon[conTxtAddress2].Text + "'";
				mySQL = mySQL + " , email_id = '" + txtCommon[conTxtEmailId].Text + "'";
				mySQL = mySQL + " , website = '" + txtCommon[conTxtWebsite].Text + "'";
				mySQL = mySQL + " where Tenant_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mySQL;
				TempCommand_2.ExecuteNonQuery();
			}
			result = true;
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			return result;

			eFoundError:
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			return false;

		}

		public bool deleteRecord()
		{
			bool result = false;

			SystemVariables.gConn.BeginTransaction();
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mySQL = "delete from re_tenant where tenant_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mySQL;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Tenant cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
				SqlDataReader localRec = null;

				mySQL = " select tenant.* ";
				mySQL = mySQL + " , nat.nationality_no, nat.l_nationality_name, nat.a_nationality_name ";
				mySQL = mySQL + " , bank.bank_no ,bank.l_bank_name ,bank.A_bank_name";
				mySQL = mySQL + " from RE_Tenant tenant ";
				mySQL = mySQL + " left join RE_Nationality nat on tenant.nationality_cd = nat.nationality_cd";
				mySQL = mySQL + " left join RE_Bank bank on tenant.bank_cd = bank.bank_cd ";
				mySQL = mySQL + " where Tenant_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mySQL, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{

					mSearchValue = localRec["Tenant_Cd"];

					txtCommon[conTXTTenantNo].Text = Convert.ToString(localRec["Tenant_No"]);
					txtCommon[conTxtLTenantName].Text = Convert.ToString(localRec["l_tenant_name"]);
					txtCommon[conTxtATenantName].Text = Convert.ToString(localRec["A_tenant_name"]);

					txtCommon[conTxtNationalityNo].Text = Convert.ToString(localRec["Nationality_No"]);

					txtCommon[conTxtBankNo].Text = Convert.ToString(localRec["Bank_No"]) + "";

					txtCommon[conTxtPassportNo].Text = Convert.ToString(localRec["Passport_No"]) + "";
					txtCommon[conTxtCivilId].Text = Convert.ToString(localRec["Civil_Id_No"]) + "";
					txtCommon[conTxtMobileNo].Text = Convert.ToString(localRec["Mobile_No"]) + "";
					txtCommon[conTxtFaxNo].Text = Convert.ToString(localRec["Fax_No"]) + "";
					txtCommon[conTxtTelNo].Text = Convert.ToString(localRec["tel_No"]) + "";
					txtCommon[conTxtRemarks].Text = Convert.ToString(localRec["comments"]) + "";
					txtCommon[conTxtAddress1].Text = Convert.ToString(localRec["address_1"]) + "";
					txtCommon[conTxtAddress2].Text = Convert.ToString(localRec["address_2"]) + "";
					txtCommon[conTxtEmailId].Text = Convert.ToString(localRec["email_id"]) + "";
					txtCommon[conTxtWebsite].Text = Convert.ToString(localRec["website"]) + "";

					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						txtCommonDisplay[conTxtNationalityName].Text = Convert.ToString(localRec["L_Nationality_Name"]) + "";
						txtCommonDisplay[conTxtBankName].Text = Convert.ToString(localRec["L_Bank_Name"]) + "";
					}
					else
					{
						txtCommonDisplay[conTxtNationalityName].Text = Convert.ToString(localRec["A_Nationality_Name"]) + "";
						txtCommonDisplay[conTxtBankName].Text = Convert.ToString(localRec["A_Bank_Name"]) + "";
					}
					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				}
				localRec.Close();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9010000));
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

			if (txtCommon[conTXTTenantNo].Text.Trim() == "")
			{
				MessageBox.Show("You have to enter the Tenant No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txtCommon[conTXTTenantNo].Focus();
			}
			else
			{

				if (txtCommon[conTxtLTenantName].Text.Trim() == "")
				{
					MessageBox.Show("You have to enter the Tenant Name", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txtCommon[conTxtLTenantName].Focus();
				}
				else
				{

					if (txtCommon[conTxtNationalityNo].Text.Trim() == "")
					{
						MessageBox.Show("You have to enter the Nationality No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						txtCommon[conTxtNationalityNo].Focus();
					}
					else
					{
						//
						//If (Trim(txtCommon(conTxtBankNo).Text) = "") Then
						//   MsgBox "You have to enter the Bank No"
						//   txtCommon(conTxtBankNo).SetFocus
						//   GoTo mError
						//End If


						return true;

					}
				}
			}

			return false;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

			UserAccess = null;
			oThisFormToolBar = null;
			frmRETenant.DefInstance = null;
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
					case conTxtNationalityNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9005000, "1341,1342,1343")); 
						break;
					case conTxtBankNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9007000, "1349,1350,1352")); 
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
			if (Index == conTXTTenantNo)
			{
				txtCommon[conTXTTenantNo].Text = SystemProcedure2.GetNewNumber("re_tenant", "tenant_No", 2);
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
					case conTxtNationalityNo : 
						mySQL = "select L_Nationality_Name,A_Nationality_Name from re_Nationality where Nationality_no = " + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conTxtNationalityName; 
						break;
					case conTxtBankNo : 
						mySQL = "select L_Bank_Name,A_Bank_Name from re_bank where bank_no = " + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conTxtBankName; 
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