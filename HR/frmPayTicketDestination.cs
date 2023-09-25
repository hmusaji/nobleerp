
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayTicketDestination
		: System.Windows.Forms.Form
	{

		public frmPayTicketDestination()
{
InitializeComponent();
} 
 public  void frmPayTicketDestination_old()
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


		private void frmPayTicketDestination_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		public Control FirstFocusObject = null;
		private string mTimeStamp = "";

		private clsToolbar oThisFormToolBar = null;
		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private int mBillCd = 0;

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
			FirstFocusObject = txtDestinationCd;

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
				txtDestinationCd.Text = SystemProcedure2.GetNewNumber("pay_ticket_destination", "transaction_no");
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


		private void txtDestinationCd_DropButtonClick(Object Sender, EventArgs e)
		{
			txtDestinationCd.Text = SystemProcedure2.GetNewNumber("Pay_Ticket_Destination", "Transaction_No", 2);
		}

		private void txtNatNo_DropButtonClick(Object Sender, EventArgs e)
		{

			txtNatNo.Text = "";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7004000, "743"));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtNatNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				txtNatNo_Leave(txtNatNo, new EventArgs());
			}
		}

		private void txtNatNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			object mTempValue = null;
			string mysql = "";

			if (!SystemProcedure2.IsItEmpty(txtNatNo.Text, SystemVariables.DataType.NumberType))
			{
				mysql = "select nat_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_nat_name" : "a_nat_name");
				mysql = mysql + " from pay_nationality ";
				mysql = mysql + " where ";
				mysql = mysql + " nat_no = " + txtNatNo.Text;

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTempValue))
				{
					txtNatName.Text = "";
					throw new System.Exception("-9990002");
				}
				else
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtNatName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
				}
			}
			else
			{
				txtNatName.Text = "";
			}
		}
		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearNumberBox(this);
			txtDestinationCd.Text = SystemProcedure2.GetNewNumber("Pay_Ticket_Destination", "Transaction_No", 2);
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			txtDestinationCd.Focus();
		}

		public bool saveRecord()
		{
			bool result = false;
			string mysql = "";
			object mReturnValue = null;
			int mNatCode = 0;
			try
			{


				//''check this code , by hakim 18-jul-2010
				//Get Nationality Code
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select nat_cd from pay_nationality where nat_no='" + txtNatNo.Text + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Ticket Destination Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtNatNo.Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mNatCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = "insert into pay_ticket_destination (transaction_no";
					mysql = mysql + " ,l_ticket_destination,a_ticket_destination,nat_cd";
					mysql = mysql + " ,one_way_ticket_amount,return_ticket_amount,User_cd)";
					mysql = mysql + " values ('" + txtDestinationCd.Text + "'";
					mysql = mysql + ",'" + txtLDestName.Text + "'";
					mysql = mysql + ",N'" + txtADestName.Text + "'";
					mysql = mysql + "," + mNatCode.ToString();
					mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(txtOneWayAmt.Value);
					mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(txtReturnAmt.Value);
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
					mysql = " select time_stamp from pay_ticket_destination where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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
					mysql = " update pay_ticket_destination  ";
					mysql = mysql + " set  ";
					mysql = mysql + " transaction_no ='" + txtDestinationCd.Text + "'";
					mysql = mysql + ", l_ticket_destination ='" + txtLDestName.Text + "'";
					mysql = mysql + ", a_ticket_destination =N'" + txtADestName.Text + "'";
					mysql = mysql + ", nat_cd =" + mNatCode.ToString();
					mysql = mysql + ", one_way_ticket_amount =" + ReflectionHelper.GetPrimitiveValue<string>(txtOneWayAmt.Value);
					mysql = mysql + ", return_ticket_amount =" + ReflectionHelper.GetPrimitiveValue<string>(txtReturnAmt.Value);
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

			string mSQL = " select ptd.* ,pnat.nat_no " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " ,pnat.l_nat_name " : " ,pnat.a_nat_name") + " as Nat_name";
			mSQL = mSQL + " from pay_ticket_destination ptd ";
			mSQL = mSQL + " inner join pay_nationality pnat on pnat.nat_cd = ptd.nat_cd";
			mSQL = mSQL + " where ptd.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

			SqlDataReader rs = null;
			SqlCommand sqlCommand = new SqlCommand(mSQL, SystemVariables.gConn);
			rs = sqlCommand.ExecuteReader();
			rs.Read();
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rs.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			do 
			{
				txtDestinationCd.Text = Convert.ToString(rs["transaction_no"]);
				txtLDestName.Text = Convert.ToString(rs["l_ticket_destination"]);
				txtADestName.Text = Convert.ToString(rs["a_ticket_destination"]) + "";
				txtNatNo.Text = Convert.ToString(rs["nat_no"]);
				txtOneWayAmt.Value = rs["one_way_ticket_amount"];
				txtReturnAmt.Value = rs["return_ticket_amount"];
				txtNatName.Text = Convert.ToString(rs["nat_name"]);
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
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220340));
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

				mysql = " select protected from pay_ticket_destination where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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
						mysql = "delete from pay_ticket_destination where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql;
						TempCommand.ExecuteNonQuery();

						//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (Information.Err().Number != 0)
						{
							MessageBox.Show("Ticket Destination cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}