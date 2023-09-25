
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayTicketType
		: System.Windows.Forms.Form
	{

		public frmPayTicketType()
{
InitializeComponent();
} 
 public  void frmPayTicketType_old()
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


		private void frmPayTicketType_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		public Control FirstFocusObject = null;
		private string mTimeStamp = "";

		private clsToolbar oThisFormToolBar = null;
		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private int mBillCd = 0;
		private int mDedBillCd = 0;

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



		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			FirstFocusObject = txtTicketTypeCode;

			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = false;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);

				//assign a next code
				txtTicketTypeCode.Text = SystemProcedure2.GetNewNumber("pay_ticket_type", "transaction_no");
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
				//On Keydown navigate the form by using enter key
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}
				if (this.ActiveControl.Name == "txtCommonTextBox")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommonTextBox#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}


		private void txtTicketTypeCode_DropButtonClick(Object Sender, EventArgs e)
		{
			txtTicketTypeCode.Text = SystemProcedure2.GetNewNumber("Pay_Ticket_Type", "Transaction_No", 2);
		}

		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearNumberBox(this);
			txtTicketTypeCode.Text = SystemProcedure2.GetNewNumber("Pay_Ticket_Type", "Transaction_No", 2);
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			txtTicketTypeCode.Focus();
		}

		public bool saveRecord()
		{
			bool result = false;
			string mysql = "";
			object mReturnValue = null;
			try
			{

				if (!SystemProcedure2.IsItEmpty(txtEarBillNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select bill_cd from pay_billing_type where bill_no=" + txtEarBillNo.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mBillCd))
					{
						MessageBox.Show("Please enter correct Bill Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtEarBillNo.Focus();
						return false;
					}
				}
				else
				{
					mBillCd = 0;
				}

				if (!SystemProcedure2.IsItEmpty(txtDedBillNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select bill_cd from pay_billing_type where bill_no=" + txtDedBillNo.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDedBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mBillCd))
					{
						MessageBox.Show("Please enter correct Bill Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtDedBillNo.Focus();
						return false;
					}
				}
				else
				{
					mDedBillCd = 0;
				}

				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = "insert into pay_ticket_type (transaction_no";
					mysql = mysql + " ,l_ticket_type,a_ticket_type";
					mysql = mysql + " ,ticket_per_year,ticket_bill_cd,ded_bill_cd,User_cd)";
					mysql = mysql + " values ('" + txtTicketTypeCode.Text + "'";
					mysql = mysql + ",'" + txtLTicketTypeName.Text + "'";
					mysql = mysql + ",N'" + txtATicketTypeName.Text + "'";
					mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(txtNTicketInDigit.Value);
					mysql = mysql + "," + ((mBillCd == 0) ? "NULL" : mBillCd.ToString());
					mysql = mysql + " ," + ((mDedBillCd == 0) ? "NULL" : mDedBillCd.ToString());
					mysql = mysql + "," + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));
				}
				else
				{
					mysql = " select time_stamp from pay_ticket_type where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}
					else
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
					if (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp))
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
					mysql = " update pay_ticket_type  ";
					mysql = mysql + " set  ";
					mysql = mysql + " transaction_no ='" + txtTicketTypeCode.Text + "'";
					mysql = mysql + ", l_ticket_type ='" + txtLTicketTypeName.Text + "'";
					mysql = mysql + ", a_ticket_type =N'" + txtATicketTypeName.Text + "'";
					mysql = mysql + ", ticket_per_year =" + ReflectionHelper.GetPrimitiveValue<string>(txtNTicketInDigit.Value);
					mysql = mysql + ", ticket_bill_cd =" + ((mBillCd == 0) ? "NULL" : mBillCd.ToString());
					mysql = mysql + ", Ded_bill_cd = " + ((mDedBillCd == 0) ? "NULL" : mDedBillCd.ToString());
					mysql = mysql + ", user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}

				return true;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
			}
			return result;
		}

		public object GetRecord(object pSearchValue)
		{

			string mSQL = " select ptt.*,pbt.bill_no as EarBillNo, pbt.l_bill_name as EarBillName, pbt1.bill_no as DedBillNo, pbt1.l_bill_name as DedBillName ";
			mSQL = mSQL + " from pay_ticket_type ptt";
			mSQL = mSQL + " left outer join pay_billing_type pbt on ptt.ticket_bill_cd = pbt.bill_cd";
			mSQL = mSQL + " left outer join pay_billing_type pbt1 on ptt.Ded_bill_cd  = pbt1.bill_cd";
			mSQL = mSQL + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

			SqlDataReader rs = null;
			SqlCommand sqlCommand = new SqlCommand(mSQL, SystemVariables.gConn);
			rs = sqlCommand.ExecuteReader();
			rs.Read();
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rs.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			do 
			{
				txtTicketTypeCode.Text = Convert.ToString(rs["transaction_no"]);
				txtLTicketTypeName.Text = Convert.ToString(rs["l_ticket_type"]);
				txtATicketTypeName.Text = Convert.ToString(rs["a_ticket_type"]);
				txtNTicketInDigit.Value = rs["ticket_per_year"];
				txtEarBillNo.Text = (Convert.IsDBNull(rs["Earbillno"])) ? "" : Convert.ToString(rs["Earbillno"]);
				txtEarBillCdName.Text = (Convert.IsDBNull(rs["earbillname"])) ? "" : Convert.ToString(rs["earbillname"]);
				txtDedBillNo.Text = (Convert.IsDBNull(rs["Dedbillno"])) ? "" : Convert.ToString(rs["Dedbillno"]);
				txtDedBillCdName.Text = (Convert.IsDBNull(rs["dedbillname"])) ? "" : Convert.ToString(rs["dedbillname"]);
				mTimeStamp = Convert.ToString(rs["time_stamp"]);
			}
			while(rs.Read());
			mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			return null;
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220330));
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

		public object deleteRecord()
		{
			object result = null;
			string mysql = "";
			object mReturnValue = null;

			try
			{

				mysql = " select protected from pay_ticket_type where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
					{
						MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
					//If an error occurs, trap the error and dispaly a valid message
					SystemVariables.gConn.BeginTransaction();

					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
					try
					{
						mysql = "delete from pay_ticket_type where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql;
						TempCommand.ExecuteNonQuery();

						//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (Information.Err().Number != 0)
						{
							MessageBox.Show("This Ticket Type cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							return false;
						}

						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.CommitTrans();
						result = true;
					}
					catch (Exception exc)
					{
						NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
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
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					AddRecord();
					((Array) result).GetValue(0);
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		private void txtEarBillNo_DropButtonClick(Object Sender, EventArgs e)
		{
			string mysql = " pbt.show =  1  and bill_type_id = 51  ";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7008000, "775", mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtEarBillNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mBillCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempSearchValue).GetValue(0));
				txtEarBillNo_Leave(txtEarBillNo, new EventArgs());
			}
		}

		private void txtEarBillNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;
			if (!SystemProcedure2.IsItEmpty(txtEarBillNo.Text, SystemVariables.DataType.NumberType))
			{
				mysql = " select bill_cd from pay_billing_type where bill_no=" + txtEarBillNo.Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mBillCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_bill_name" : " a_bill_name") + " as Name";
					mysql = mysql + " from pay_billing_type where bill_cd =" + mBillCd.ToString();

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtEarBillCdName.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}
				}
				else
				{
					MessageBox.Show("Bill Code is not correct!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtEarBillCdName.Text = "";
					txtEarBillNo.Text = "";
				}
			}
			else
			{
				txtEarBillCdName.Text = "";
				txtEarBillNo.Text = "";
			}
		}
		public void FindRoutine(string pObjectName)
		{
			if (pObjectName == "txtEarBillNo")
			{
				txtEarBillNo_DropButtonClick(txtEarBillNo, null);
			}
			else if (pObjectName == "txtDedBillNo")
			{ 
				txtDedBillNo_DropButtonClick(txtDedBillNo, null);
			}
		}

		private void txtDedBillNo_DropButtonClick(Object Sender, EventArgs e)
		{
			string mysql = " pbt.show =  1 and bill_type_id = 52 ";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7008000, "775", mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDedBillNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mBillCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempSearchValue).GetValue(0));
				txtDedBillNo_Leave(txtDedBillNo, new EventArgs());
			}
		}

		private void txtDedBillNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;
			if (!SystemProcedure2.IsItEmpty(txtDedBillNo.Text, SystemVariables.DataType.NumberType))
			{
				mysql = " select bill_cd from pay_billing_type where bill_no=" + txtDedBillNo.Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mBillCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_bill_name" : " a_bill_name") + " as Name";
					mysql = mysql + " from pay_billing_type where bill_cd =" + mBillCd.ToString();

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDedBillCdName.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}
				}
				else
				{
					MessageBox.Show("Bill Code is not correct!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtDedBillCdName.Text = "";
					txtDedBillNo.Text = "";
				}
			}
			else
			{
				txtDedBillCdName.Text = "";
				txtDedBillNo.Text = "";
			}
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}