
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmREContractStatus
		: System.Windows.Forms.Form
	{

		public frmREContractStatus()
{
InitializeComponent();
} 
 public  void frmREContractStatus_old()
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


		private void frmREContractStatus_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private const int conTXTContractNo = 0;
		private const int conTXTOldStatusNo = 1;
		private const int conTXTNewStatusNo = 2;
		private const int conTXTTenantNo = 7;
		private const int conTXTPaymentMethodNo = 5;
		private const int conTXTContractAmount = 4;

		private const int conTXTStartingDate = 0;
		private const int conTXTEndingDate = 1;
		private const int conTXTSignedDate = 2;
		private const int conTXTChangedStatusDate = 3;

		private const int conTXTOldStatusName = 0;
		private const int conTXTNewStatusName = 1;
		private const int conTXTTenantName = 6;
		private const int conTXTPaymentMethodName = 3;

		static readonly private Color mDisbaledBackColor = Color.FromArgb(239, 239, 239);
		static readonly private Color mEnabledBackColor = Color.White;


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

				this.Top = 0;
				this.Left = 0;
				FirstFocusObject = txtCommon[conTXTContractNo];

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = false;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = false;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = false;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;
				SystemProcedure.SetLabelCaption(this);

				AddRecord(false);
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
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode && this.ActiveControl.Name == "txtCommon" && (KeyCode == ((int) Keys.Return) || KeyCode == ((int) Keys.Tab)))
				{
					if (ControlArrayHelper.GetControlIndex(this.ActiveControl) == conTXTContractNo)
					{
						txtCommon_Leave(txtCommon[ControlArrayHelper.GetControlIndex(this.ActiveControl)], new EventArgs());
						return;
					}
				}

				if (KeyCode == ((int) Keys.Return))
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

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmREContractStatus.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void AddRecord(bool pSetFocus = false)
		{
			try
			{

				//**--Add a record
				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				SystemProcedure2.ClearTextBox(this);
				SystemProcedure2.ClearNumberBox(this);
				SystemProcedure2.ClearDateBox(this);

				txtCommon[conTXTNewStatusNo].Enabled = false;
				txtComments.Enabled = false;
				txtComments.BackColor = mDisbaledBackColor;
				txtCommon[conTXTContractNo].Tag = "";
				txtCommonDate[conTXTChangedStatusDate].Value = DateTime.Today;
				if (pSetFocus)
				{
					txtCommon[conTXTContractNo].Focus();
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}
		}

		public void GetRecord(string SearchValue)
		{
			string mySQL = "";
			DataSet rsLocalRec = null;

			try
			{

				mySQL = "select c.contract_cd, c.contract_no, c.starting_date, c.ending_date, ";
				mySQL = mySQL + " c.signed_date, c.contract_amt, c.time_stamp, c.status, cs.status_no,";
				mySQL = mySQL + " cs.l_status_name, cs.a_status_name, t.tenant_no, t.l_tenant_name,";
				mySQL = mySQL + " t.a_tenant_name, pm.payment_method_no, pm.l_payment_method_name,";
				mySQL = mySQL + " pm.a_payment_method_name, c.contract_status_cd";
				mySQL = mySQL + " from re_contract c";
				mySQL = mySQL + " inner join re_contract_status cs on c.contract_status_cd = cs.contract_status_cd";
				mySQL = mySQL + " inner join re_payment_method pm on c.payment_method_cd = pm.payment_method_cd";
				mySQL = mySQL + " inner join re_tenant t on c.tenant_cd = t.tenant_cd";
				mySQL = mySQL + " where contract_no = " + SearchValue;
				mySQL = mySQL + " and status = 2";

				rsLocalRec = new DataSet();
				SqlDataAdapter adap = new SqlDataAdapter(mySQL, SystemVariables.gConn);
				rsLocalRec.Tables.Clear();
				adap.Fill(rsLocalRec);
				if (rsLocalRec.Tables[0].Rows.Count != 0)
				{
					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
					txtCommon[conTXTNewStatusNo].Enabled = true;
					txtComments.Enabled = true;
					txtComments.BackColor = mEnabledBackColor;

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTXTContractNo].Tag = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["contract_cd"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conTXTContractAmount].Text = StringsHelper.Format(rsLocalRec.Tables[0].Rows[0]["contract_amt"], "###,###,###,##0.000");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTXTOldStatusNo].Tag = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["contract_status_cd"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[conTXTOldStatusNo].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["status_no"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conTXTPaymentMethodNo].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["payment_method_no"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[conTXTTenantNo].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["tenant_no"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDate[conTXTStartingDate].Value = rsLocalRec.Tables[0].Rows[0]["starting_date"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDate[conTXTEndingDate].Value = rsLocalRec.Tables[0].Rows[0]["ending_date"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDate[conTXTSignedDate].Value = rsLocalRec.Tables[0].Rows[0]["signed_date"];

					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conTXTOldStatusName].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["l_status_name"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conTXTTenantName].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["l_tenant_name"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conTXTPaymentMethodName].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["l_payment_method_name"]) + "";
					}
					else
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conTXTOldStatusName].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["a_status_name"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conTXTTenantName].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["a_tenant_name"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[conTXTPaymentMethodName].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["a_payment_method_name"]) + "";
					}
					txtCommon[conTXTNewStatusNo].Focus();
				}
				else
				{
					MessageBox.Show("Error: Invalid Contract No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					AddRecord(true);
				}
				rsLocalRec = null;
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

			//mTempSearchValue = FindItem(9015000)
			//If Not IsNull(mTempSearchValue) Then
			//    mSearchValue = mTempSearchValue(0)
			//    Call GetRecord(mSearchValue)
			//End If
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
			int mObjectIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));
			if (mObjectName == "txtCommon")
			{
				txtCommon[mObjectIndex].Text = "";
				switch(mObjectIndex)
				{
					case conTXTContractNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9015000, "1392", "status = 2")); 
						break;
					case conTXTNewStatusNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9013000, "1383")); 
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
			FindRoutine("txtCommon#" + Index.ToString().Trim());
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
					case conTXTContractNo : 
						if (!SystemProcedure2.IsItEmpty(txtCommon[Index].Text, SystemVariables.DataType.StringType))
						{
							GetRecord(txtCommon[Index].Text);
							return;
						}
						else
						{
							AddRecord(false);
						} 
						break;
					case conTXTNewStatusNo : 
						mySQL = "select l_status_name, a_status_name, contract_status_cd from re_contract_status where status_no = " + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conTXTNewStatusName; 
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
						txtCommon[Index].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
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

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "LostFocus");
			}
		}

		public bool CheckDataValidity()
		{
			bool result = false;
			string mySQL = "";
			object mTempValue = null;

			try
			{
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode || SystemProcedure2.IsItEmpty(Convert.ToString(txtCommon[conTXTContractNo].Tag), SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Error: No contract information found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					FirstFocusObject.Focus();
					return false;
				}

				if (SystemProcedure2.IsItEmpty(Convert.ToString(txtCommon[conTXTNewStatusNo].Tag), SystemVariables.DataType.NumberType) || (Convert.ToString(txtCommon[conTXTNewStatusNo].Tag) == Convert.ToString(txtCommon[conTXTOldStatusNo].Tag)))
				{
					MessageBox.Show("Error: Invalid status code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtCommon[conTXTNewStatusNo].Focus();
					return result;
				}

				if (SystemProcedure2.IsItEmpty(txtCommonDate[conTXTChangedStatusDate].Value, SystemVariables.DataType.DateType))
				{
					MessageBox.Show("Error: Enter change status date!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtCommonDate[conTXTChangedStatusDate].Focus();
					return result;
				}

				mySQL = "select allow_manual_change ";
				mySQL = mySQL + " from re_contract_status cs ";
				mySQL = mySQL + " where contract_status_cd = " + Convert.ToString(txtCommon[conTXTOldStatusNo].Tag);
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mySQL))) == TriState.False)
				{
					result = false;
					MessageBox.Show("Error: Contract status can not be manually changed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					FirstFocusObject.Focus();
					return result;
				}

				mySQL = "select count(*) ";
				mySQL = mySQL + " from re_contract ";
				mySQL = mySQL + " where contract_cd = " + Convert.ToString(txtCommon[conTXTContractNo].Tag);
				mySQL = mySQL + " and status = 2 ";
				if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode(mySQL)) == 0)
				{
					result = false;
					MessageBox.Show("Error: Invalid contract information. Contract must be posted first", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					FirstFocusObject.Focus();
					return result;
				}

				//**--do not allow change status date to be outside of contract date
				mySQL = "select starting_date, ending_date from re_contract ";
				mySQL = mySQL + " where contract_cd = " + Convert.ToString(txtCommon[conTXTContractNo].Tag);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
				if ((ReflectionHelper.IsLessThan(txtCommonDate[conTXTChangedStatusDate].Value, ((Array) mTempValue).GetValue(0))) || (ReflectionHelper.IsGreaterThan(txtCommonDate[conTXTChangedStatusDate].Value, ((Array) mTempValue).GetValue(1))))
				{
					result = false;
					MessageBox.Show("Error: Invalid change status date. Change status date must be between contract date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					FirstFocusObject.Focus();
					return result;
				}
				//**-----------------------------------------------------------------------------

				return true;
			}
			catch
			{

				result = false;
			}
			return result;
		}

		public bool saveRecord()
		{
			bool result = false;
			string mySQL = "";

			try
			{

				SystemVariables.gConn.BeginTransaction();

				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					mySQL = "update re_contract ";
					mySQL = mySQL + " set contract_status_cd = " + Convert.ToString(txtCommon[conTXTNewStatusNo].Tag);
					mySQL = mySQL + " where contract_cd = " + Convert.ToString(txtCommon[conTXTContractNo].Tag);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mySQL;
					TempCommand.ExecuteNonQuery();

					mySQL = " insert into re_contract_change_status_history";
					mySQL = mySQL + " (contract_cd, old_contract_status_cd, new_contract_status_cd ";
					mySQL = mySQL + " , contract_starting_date, contract_ending_date ";
					mySQL = mySQL + " , change_status_date, comments, user_cd) ";
					mySQL = mySQL + " values (";
					mySQL = mySQL + Convert.ToString(txtCommon[conTXTContractNo].Tag);
					mySQL = mySQL + ", " + Convert.ToString(txtCommon[conTXTOldStatusNo].Tag);
					mySQL = mySQL + ", " + Convert.ToString(txtCommon[conTXTNewStatusNo].Tag);
					mySQL = mySQL + ", '" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select starting_date from re_contract where contract_cd = " + Convert.ToString(txtCommon[conTXTContractNo].Tag))) + "'";
					mySQL = mySQL + ", '" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select ending_date from re_contract where contract_cd = " + Convert.ToString(txtCommon[conTXTContractNo].Tag))) + "'";
					mySQL = mySQL + ", '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conTXTChangedStatusDate].DisplayText) + "'";
					mySQL = mySQL + ", N'" + txtComments.Text + "'";
					mySQL = mySQL + ", " + SystemVariables.gLoggedInUserCode.ToString();
					mySQL = mySQL + ")";
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mySQL;
					TempCommand_2.ExecuteNonQuery();


					mySQL = " select is_active from re_contract_status ";
					mySQL = mySQL + " where contract_status_cd = " + Convert.ToString(txtCommon[conTXTNewStatusNo].Tag);
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mySQL))) == TriState.False)
					{
						if (!SystemREProcedure.ReleaseContractItemUnits(Convert.ToInt32(Double.Parse(Convert.ToString(txtCommon[conTXTContractNo].Tag)))))
						{
							throw new Exception();
						}

						//**--reverse gl effect for the charges exceeding the date
						if (!SystemREProcedure.ReverseContractChargesGLEffect(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conTXTChangedStatusDate].Value), Convert.ToInt32(Conversion.Val(Convert.ToString(txtCommon[conTXTContractNo].Tag)))))
						{
							throw new Exception();
						}
					}
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				result = false;
			}
			return result;
		}
	}
}