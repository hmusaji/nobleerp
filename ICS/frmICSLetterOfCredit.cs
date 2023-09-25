
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmICSLetterOfCredit
		: System.Windows.Forms.Form
	{

		public frmICSLetterOfCredit()
{
InitializeComponent();
} 
 public  void frmICSLetterOfCredit_old()
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


		private void frmICSLetterOfCredit_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

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

		private DataSet _localRec = null;
		DataSet localRec
		{
			get
			{
				if (_localRec is null)
				{
					_localRec = new DataSet();
				}
				return _localRec;
			}
			set
			{
				_localRec = value;
			}
		}


		private const int tcLCNo = 0;
		private const int tcSupplier = 1;
		private const int tcShippingWay = 2;
		private const int tcPortOFLanding = 3;
		private const int tcVessel = 4;
		private const int tcInsuranceCo = 5;
		private const int tcBank = 6;
		private const int tcPolicyCo = 7;
		private const int tcCIFFBO = 8;
		private const int tcLCAccount = 9;

		private const int tncNetAmt = 0;
		private const int tncCExpValue = 1;
		private const int tncExpRatio = 2;
		private const int tncCashExp = 3;
		private const int tncCheqExp = 4;

		private const int mMaxDetailCols = 4;

		private const int grdLNColumn = 0;
		private const int grdLdgrCodeColumn = 1;
		private const int grdLdgrNameColumn = 2;
		private const int grdAmtColumn = 3;

		private DataSet rsLdgrList = null;
		private XArrayHelper _aLCDetails = null;
		private XArrayHelper aLCDetails
		{
			get
			{
				if (_aLCDetails is null)
				{
					_aLCDetails = new XArrayHelper();
				}
				return _aLCDetails;
			}
			set
			{
				_aLCDetails = value;
			}
		}


		private int mRecordNavigateSearchValue = 0;

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
			try
			{
				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;
				mCurrentSearchOnInternalCodes = false;

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
				oThisFormToolBar.ShowMoveRecordNextButton = true;
				oThisFormToolBar.ShowMoveRecordPreviousButton = true;

				this.WindowState = FormWindowState.Maximized;
				LoadGrid();

				System.Windows.Forms.TextBox[tcLCNo].Text = SystemProcedure2.GetNewNumber("ICS_Letter_Of_Credit", "LC_No");
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
				//On Keydown navigate the form by using enter key
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}


		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);
			System.Windows.Forms.TextBox[tcLCNo].Text = SystemProcedure2.GetNewNumber("ICS_Letter_Of_Credit", "LC_No");
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank


			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "mAssign_value");
		}

		public bool saveRecord()
		{
			bool result = false;
			StringBuilder mysql = new StringBuilder();
			object mTempValue = null;
			int cnt = 0;

			try
			{
				//Save a record
				//During save check for the mode
				//If in addmode then insert a record
				//else update the record in the recordset

				if (System.Windows.Forms.TextBox1[tncNetAmt].Text == "")
				{
					System.Windows.Forms.TextBox1[tncNetAmt].Text = "0";
				}
				if (System.Windows.Forms.TextBox1[tncCExpValue].Text == "")
				{
					System.Windows.Forms.TextBox1[tncCExpValue].Text = "0";
				}
				if (System.Windows.Forms.TextBox1[tncExpRatio].Text == "")
				{
					System.Windows.Forms.TextBox1[tncExpRatio].Text = "0";
				}
				if (System.Windows.Forms.TextBox1[tncCashExp].Text == "")
				{
					System.Windows.Forms.TextBox1[tncCashExp].Text = "0";
				}
				if (System.Windows.Forms.TextBox1[tncCheqExp].Text == "")
				{
					System.Windows.Forms.TextBox1[tncCheqExp].Text = "0";
				}

				SystemVariables.gConn.BeginTransaction();

				DataSet withVar = null;
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = new StringBuilder("insert into ICS_Letter_of_Credit (Ldgr_Cd, Cash_Cd, Supplier, LC_No, Credit_Date, Expiry_Date, Goods,Shipping_way,Landing_Port");
					mysql.Append(",Vessel,Insurance_Co,Policy_Co,CIF_FOB,Policy_Date,Amendment1,Amendment2,Amendment3,Arrival_Date,Notes,Net_Amt,Expence_Value,Exp_Ratio");
					mysql.Append(",Cash_Expence, Cheque_Expence,User_Cd)  ");

					//'''****************************Check for the Ledger Code**********************
					//''''****************************************************************************
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("Select Ldgr_Cd from GL_Ledger where Ldgr_No = " + System.Windows.Forms.TextBox[tcLCAccount].Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						MessageBox.Show("Enter valid Account code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						if (System.Windows.Forms.TextBox[tcLCAccount].Enabled)
						{
							System.Windows.Forms.TextBox[tcLCAccount].Focus();
						}
						goto StationExitFunction;
					}
					else
					{
						mysql.Append(ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + ",");
					}
					//''''*******************************************************************************

					//'''****************************Check for the Bank Ledger Code**********************
					//''''*******************************************************************************
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("Select Ldgr_Cd from GL_Ledger where Ldgr_No = " + System.Windows.Forms.TextBox[tcBank].Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						MessageBox.Show("Enter valid Bank code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						if (System.Windows.Forms.TextBox[tcBank].Enabled)
						{
							System.Windows.Forms.TextBox[tcBank].Focus();
						}
						goto StationExitFunction;
					}
					else
					{
						mysql.Append(ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + ",");
					}
					//''''*******************************************************************************
					//'''****************************Check for the Bank Ledger Code**********************
					//''''*******************************************************************************
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("Select Ldgr_Cd from GL_Ledger where Ldgr_No = " + System.Windows.Forms.TextBox[tcSupplier].Text));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						MessageBox.Show("Enter valid Supplier code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						if (System.Windows.Forms.TextBox[tcSupplier].Enabled)
						{
							System.Windows.Forms.TextBox[tcSupplier].Focus();
						}
						goto StationExitFunction;
					}
					else
					{
						mysql.Append(ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + ",");
					}
					//''''********************************************************************************
					mysql.Append(System.Windows.Forms.TextBox[tcLCNo].Text + ",");
					mysql.Append("'" + ReflectionHelper.GetPrimitiveValue<string>(txtDateOfCredit.Value) + "',");
					mysql.Append("'" + ReflectionHelper.GetPrimitiveValue<string>(txtExpiryDate.Value) + "',");
					mysql.Append("N'" + txtGoods.Text + "',");
					mysql.Append("N'" + System.Windows.Forms.TextBox[tcShippingWay].Text + "',");
					mysql.Append("N'" + System.Windows.Forms.TextBox[tcPortOFLanding].Text + "',");
					mysql.Append("N'" + System.Windows.Forms.TextBox[tcVessel].Text + "',");
					mysql.Append("N'" + System.Windows.Forms.TextBox[tcInsuranceCo].Text + "',");
					mysql.Append("N'" + System.Windows.Forms.TextBox[tcPolicyCo].Text + "',");
					mysql.Append("N'" + System.Windows.Forms.TextBox[tcCIFFBO].Text + "',");
					mysql.Append("'" + ReflectionHelper.GetPrimitiveValue<string>(txtPolicyDate.Value) + "',");
					mysql.Append("'" + ReflectionHelper.GetPrimitiveValue<string>(txtAmendment1.Value) + "',");
					mysql.Append("'" + ReflectionHelper.GetPrimitiveValue<string>(txtAmendment2.Value) + "',");
					mysql.Append("'" + ReflectionHelper.GetPrimitiveValue<string>(txtAmendment3.Value) + "',");
					mysql.Append("'" + ReflectionHelper.GetPrimitiveValue<string>(txtArrivalDate.Value) + "',");
					mysql.Append("N'" + txtNotes.Text + "',");
					mysql.Append(Conversion.Str(System.Windows.Forms.TextBox1[tncNetAmt].Text) + ",");
					mysql.Append(Conversion.Str(System.Windows.Forms.TextBox1[tncCExpValue].Text) + ",");
					mysql.Append(Conversion.Str(System.Windows.Forms.TextBox1[tncExpRatio].Text) + ",");
					mysql.Append(Conversion.Str(System.Windows.Forms.TextBox1[tncCashExp].Text) + ",");
					mysql.Append(Conversion.Str(System.Windows.Forms.TextBox1[tncCheqExp].Text) + ",");
					mysql.Append(Conversion.Str(SystemVariables.gLoggedInUserCode));
					mysql.Append(")");

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql.ToString();
					TempCommand.ExecuteNonQuery();

					this.grdLC.UpdateData();
					int tempForEndVar = aLCDetails.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("Select Ldgr_Cd from GL_Ledger where Ldgr_No = " + Convert.ToString(aLCDetails.GetValue(cnt, grdLdgrCodeColumn))));

						mysql = new StringBuilder("insert into ICS_Letter_of_Credit_Detail ");
						mysql.Append(" ( Entry_id, ldgr_cd, amount,");
						mysql.Append(" user_cd) ");
						mysql.Append(" values ( ");
						mysql.Append(Conversion.Str(mSearchValue) + ",");
						mysql.Append(ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + ",");
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mysql.Append(((Convert.IsDBNull(aLCDetails.GetValue(cnt, grdAmtColumn))) ? "0" : Convert.ToString(aLCDetails.GetValue(cnt, grdAmtColumn))) + ",");
						mysql.Append(Conversion.Str(SystemVariables.gLoggedInUserCode) + ")");

						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql.ToString();
						TempCommand_2.ExecuteNonQuery();

					}
				}
				else
				{
					withVar = localRec;
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Ldgr_Cd"].setValue(System.Windows.Forms.TextBox[tcLCAccount].Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Cash_Cd"].setValue(System.Windows.Forms.TextBox[tcBank].Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Supplier"].setValue(System.Windows.Forms.TextBox[tcSupplier].Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["LC_No"].setValue(System.Windows.Forms.TextBox[tcLCNo].Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Credit_Date"].setValue(ReflectionHelper.GetPrimitiveValue(txtDateOfCredit.Value));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Expiry_Date"].setValue(ReflectionHelper.GetPrimitiveValue(txtExpiryDate.Value));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Goods"].setValue(txtGoods.Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Shipping_way"].setValue(System.Windows.Forms.TextBox[tcShippingWay].Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Landing_Port"].setValue(System.Windows.Forms.TextBox[tcPortOFLanding].Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Vessel"].setValue(System.Windows.Forms.TextBox[tcVessel].Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Insurance_Co"].setValue(System.Windows.Forms.TextBox[tcInsuranceCo].Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Policy_Co"].setValue(System.Windows.Forms.TextBox[tcPolicyCo].Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["CIF_FOB"].setValue(System.Windows.Forms.TextBox[tcCIFFBO].Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Policy_Date"].setValue(ReflectionHelper.GetPrimitiveValue(txtPolicyDate.Value));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Amendment1"].setValue(ReflectionHelper.GetPrimitiveValue(txtAmendment1.Value));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Amendment2"].setValue(ReflectionHelper.GetPrimitiveValue(txtAmendment2.Value));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Amendment3"].setValue(ReflectionHelper.GetPrimitiveValue(txtAmendment3.Value));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Arrival_Date"].setValue(ReflectionHelper.GetPrimitiveValue(txtArrivalDate.Value));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Notes"].setValue(txtNotes.Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Net_Amt"].setValue(System.Windows.Forms.TextBox1[tncNetAmt].Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Expence_Value"].setValue(System.Windows.Forms.TextBox1[tncCExpValue].Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Exp_Ratio"].setValue(System.Windows.Forms.TextBox1[tncExpRatio].Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Cash_Expence"].setValue(System.Windows.Forms.TextBox1[tncCashExp].Text);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Tables[0].Rows[0]["Cheque_Expence"].setValue(System.Windows.Forms.TextBox1[tncCheqExp].Text);
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method withVar.Update was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					withVar.Update_Renamed(null, null);

					this.grdLC.UpdateData();
					mysql = new StringBuilder("delete ICS_Letter_of_Credit_Detail ");
					mysql.Append(" where ");
					mysql.Append(" Entry_id = " + Conversion.Str(mSearchValue));
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql.ToString();
					TempCommand_3.ExecuteNonQuery();

					int tempForEndVar2 = aLCDetails.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar2; cnt++)
					{

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("Select Ldgr_Cd from GL_Ledger where Ldgr_No = " + Convert.ToString(aLCDetails.GetValue(cnt, grdLdgrCodeColumn))));

						mysql = new StringBuilder("insert into ICS_Letter_of_Credit_Detail ");
						mysql.Append(" ( Entry_id, ldgr_cd, amount,");
						mysql.Append(" user_cd) ");
						mysql.Append(" values ( ");
						mysql.Append(Conversion.Str(mSearchValue) + ",");
						mysql.Append(ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + ",");
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mysql.Append(((Convert.IsDBNull(aLCDetails.GetValue(cnt, grdAmtColumn))) ? "0" : Convert.ToString(aLCDetails.GetValue(cnt, grdAmtColumn))) + ",");
						mysql.Append(Conversion.Str(SystemVariables.gLoggedInUserCode) + ")");

						SqlCommand TempCommand_4 = null;
						TempCommand_4 = SystemVariables.gConn.CreateCommand();
						TempCommand_4.CommandText = mysql.ToString();
						TempCommand_4.ExecuteNonQuery();

					}

				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				return true;

				StationExitFunction:
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select LC_No from ICS_Letter_of_Credit where LC_No=" + System.Windows.Forms.TextBox[tcLCNo].Text));
					GetRecord(mSearchValue);
					result = false;
				}
				else if (mReturnErrorType == 2)
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
		public void CloseForm()
		{
			this.Close();
		}

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			string mysql = "";

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				localRec = null;

				try
				{

					//On Error Resume Next
					//localRec.Close
					//Set localRec = Nothing

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
					if (Object.Equals(mSearchValue, null) || Convert.IsDBNull(mSearchValue) || ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) == "")
					{
						return;
					}


					mysql = " select * from ICS_Letter_of_Credit where Entry_Id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
					SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
					localRec.Tables.Clear();
					adap.Fill(localRec);
					DataSet withVar = null;
					withVar = localRec;
					if (withVar.Tables[0].Rows.Count != 0)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						System.Windows.Forms.TextBox[tcLCAccount].Text = Convert.ToString(withVar.Tables[0].Rows[0]["Ldgr_Cd"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						System.Windows.Forms.TextBox[tcBank].Text = Convert.ToString(withVar.Tables[0].Rows[0]["Cash_Cd"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						System.Windows.Forms.TextBox[tcSupplier].Text = Convert.ToString(withVar.Tables[0].Rows[0]["Supplier"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						System.Windows.Forms.TextBox[tcLCNo].Text = Convert.ToString(withVar.Tables[0].Rows[0]["LC_No"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtDateOfCredit.Value = withVar.Tables[0].Rows[0]["Credit_Date"];
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtExpiryDate.Value = withVar.Tables[0].Rows[0]["Expiry_Date"];
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtGoods.Text = Convert.ToString(withVar.Tables[0].Rows[0]["Goods"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						System.Windows.Forms.TextBox[tcShippingWay].Text = Convert.ToString(withVar.Tables[0].Rows[0]["Shipping_way"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						System.Windows.Forms.TextBox[tcPortOFLanding].Text = Convert.ToString(withVar.Tables[0].Rows[0]["Landing_Port"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						System.Windows.Forms.TextBox[tcVessel].Text = Convert.ToString(withVar.Tables[0].Rows[0]["Vessel"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						System.Windows.Forms.TextBox[tcInsuranceCo].Text = Convert.ToString(withVar.Tables[0].Rows[0]["Insurance_Co"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						System.Windows.Forms.TextBox[tcPolicyCo].Text = Convert.ToString(withVar.Tables[0].Rows[0]["Policy_Co"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtPolicyDate.Value = withVar.Tables[0].Rows[0]["Policy_date"];
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						System.Windows.Forms.TextBox[tcPolicyCo].Text = Convert.ToString(withVar.Tables[0].Rows[0]["CIF_FOB"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtAmendment1.Value = withVar.Tables[0].Rows[0]["Amendment1"];
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtAmendment2.Value = withVar.Tables[0].Rows[0]["Amendment2"];
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtAmendment3.Value = withVar.Tables[0].Rows[0]["Amendment3"];
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtArrivalDate.Value = withVar.Tables[0].Rows[0]["Arrival_Date"];
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtNotes.Text = Convert.ToString(withVar.Tables[0].Rows[0]["Notes"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						System.Windows.Forms.TextBox1[tncNetAmt].Text = Convert.ToString(withVar.Tables[0].Rows[0]["Net_Amt"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						System.Windows.Forms.TextBox1[tncCExpValue].Text = Convert.ToString(withVar.Tables[0].Rows[0]["Expence_Value"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						System.Windows.Forms.TextBox1[tncExpRatio].Text = Convert.ToString(withVar.Tables[0].Rows[0]["Exp_Ratio"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						System.Windows.Forms.TextBox1[tncCashExp].Text = Convert.ToString(withVar.Tables[0].Rows[0]["Cash_Expence"]);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						System.Windows.Forms.TextBox1[tncCheqExp].Text = Convert.ToString(withVar.Tables[0].Rows[0]["Cheque_Expence"]);

						//Change the form mode to edit
						mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
					}

					LoadGrid();

					return;
				}
				catch (System.Exception excep)
				{

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void RecordNavidate(int pKeyCode, int pEntry_Id)
		{
			object mReturnValue = null;

			string mysql = " select top 1 Entry_Id from ICS_Letter_Of_Credit ";
			mysql = mysql + " where 1=1 ";
			if (pEntry_Id > 0 && pKeyCode == 37)
			{
				mysql = mysql + " and Entry_Id < " + pEntry_Id.ToString();
			}
			else if (pEntry_Id > 0 && pKeyCode == 39)
			{ 
				mysql = mysql + " and Entry_Id > " + pEntry_Id.ToString();
			}

			if (pKeyCode == 37)
			{
				mysql = mysql + " order by Entry_Id desc ";
			}
			else if (pKeyCode == 39)
			{ 
				mysql = mysql + " order by Entry_Id asc ";
			}

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				GetRecord(mSearchValue);
			}

		}

		public void ORoutine()
		{

			if (!UserAccess.AllowUserDisplay)
			{
				MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			RecordNavidate(39, mRecordNavigateSearchValue);
		}

		public void MRoutine()
		{

			if (!UserAccess.AllowUserDisplay)
			{
				MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			RecordNavidate(37, mRecordNavigateSearchValue);
		}



		private void LoadGrid()
		{
			string cGridColor = (0xB8E7F8).ToString();
			string mysql = "";
			int cnt = 0;
			SqlDataReader rsLocalRec = null;

			SystemGrid.DefineSystemVoucherGrid(grdLC, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, cGridColor);

			SystemGrid.DefineSystemVoucherGridColumn(grdLC, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdLC, "Account Code", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbParentsList", false, true, false, false, false, false, 200);
			SystemGrid.DefineSystemVoucherGridColumn(grdLC, "Account Name", 4700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbParentsList", false, true, false, false, false, false, 200);
			SystemGrid.DefineSystemVoucherGridColumn(grdLC, "Amount", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);

			aLCDetails = new XArrayHelper();
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{

				mysql = "SELECT lcd.Entry_Id, lcd.Ldgr_Cd, lcd.Amount, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Ldgr_Name" : "A_Ldgr_Name") + " as Ldgr_name ";
				mysql = mysql + " FROM ICS_Letter_Of_Credit_Detail lcd ";
				mysql = mysql + " inner join GL_Ledger GL on lcd.Ldgr_cd = GL.Ldgr_cd ";
				mysql = mysql + " where lcd.Entry_Id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand.ExecuteReader();
				rsLocalRec.Read();

				DefineReportArray(mMaxDetailCols, -1, true);
				do 
				{
					DefineReportArray(mMaxDetailCols, cnt, false);

					aLCDetails.SetValue(rsLocalRec["ldgr_cd"], cnt, grdLdgrCodeColumn);
					aLCDetails.SetValue(Convert.ToString(rsLocalRec["ldgr_name"]) + "", cnt, grdLdgrNameColumn);
					aLCDetails.SetValue(rsLocalRec["Amount"], cnt, grdAmtColumn);

					cnt++;
				}
				while(rsLocalRec.Read());
				rsLocalRec.Close();
			}
			else
			{
				DefineReportArray(mMaxDetailCols, -1, true);
			}
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdLC.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdLC.setArray(aLCDetails);
			AssignReportGridLineNumbers();
			grdLC.Rebind(true);

		}

		private void DefineReportArray(int pMaximumCols, int pMaximumRows, bool pClearArray = false)
		{
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aLCDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aLCDetails.Clear();
			}
			aLCDetails.RedimXArray(new int[]{pMaximumRows, pMaximumCols}, new int[]{0, 0});
		}

		private void AssignReportGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aLCDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aLCDetails.SetValue(cnt + 1, cnt, grdLNColumn);
			}
		}


		private void RefreshgrdLCDetails(bool pCallComboRowChange = true)
		{

			string mysql = "SELECT Ldgr_No, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Ldgr_Name" : "A_Ldgr_Name") + " as Ldgr_name ";
			mysql = mysql + " FROM GL_Ledger";

			rsLdgrList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLdgrList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsLdgrList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsLdgrList.Tables.Clear();
			adap.Fill(rsLdgrList);

			grdLC.Focus();
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbParentsList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			cmbParentsList.setDataSource((msdatasrc.DataSource) rsLdgrList);

		}

		private void grdLC_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				string mysql = "";

				SystemGrid.DefineSystemGridCombo(cmbParentsList);
				RefreshgrdLCDetails();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdLC.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdLC.PostMsg(1);
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbParentsList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbParentsList_DataSourceChanged()
		{
			int cnt = 0;

			cmbParentsList.Width = 0;
			switch(grdLC.Col)
			{
				case grdLdgrCodeColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbParentsList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbParentsList.setListField("ldgr_cd"); 
					cmbParentsList.DisplayColumns[0].Visible = true; 
					cmbParentsList.DisplayColumns[0].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbParentsList.Width = grdLC.Splits[0].DisplayColumns[grdLdgrCodeColumn].Width + 167; 
					cmbParentsList.Height = 167; 
					 
					break;
				case grdLdgrNameColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbParentsList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbParentsList.setListField("ldgr_name"); 
					cmbParentsList.Columns[0].DataField = "ldgr_name"; 
					cmbParentsList.Columns[1].DataField = "ldgr_cd"; 
					cmbParentsList.DisplayColumns[0].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbParentsList.DisplayColumns[0].Width = grdLC.Splits[0].DisplayColumns[grdLdgrNameColumn].Width; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbParentsList.Width = grdLC.Splits[0].DisplayColumns[grdLdgrNameColumn].Width + 100; 
					cmbParentsList.Height = 167; 
					 
					break;
				default:
					cmbParentsList.Width = 0; 
					break;
			}
		}

		private void grdLC_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			switch(grdLC.Col)
			{
				case grdLdgrCodeColumn : case grdLdgrNameColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbParentsList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbParentsList.setDataSource((msdatasrc.DataSource) rsLdgrList); 
					break;
			}
		}

		public void findRecord()
		{

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2000409));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		private void System.Windows.Forms.TextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.System.Windows.Forms.TextBox, Sender);
			SystemForms.ToolBarButtonClick(this, "FindRoutine", "System.Windows.Forms.TextBox#" + Index.ToString().Trim());
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbParentsList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbParentsList_DropDownClose()
		{
			//'***************************************************************************''
			//'This routine handles the navigation for next column after a value is selected
			//'from listbox in the grid.
			//'***************************************************************************''

			switch(grdLC.Col)
			{
				case grdLdgrCodeColumn : 
					grdLC.Columns[grdLdgrNameColumn].Value = SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Ldgr_Name" : "A_Ldgr_Name") + " from GL_Ledger where Ldgr_No=" + ReflectionHelper.GetPrimitiveValue<string>(grdLC.Columns[grdLdgrCodeColumn].Value)); 
					grdLC.Col = grdAmtColumn; 
					break;
				case grdLdgrNameColumn : 
					grdLC.Columns[grdLdgrCodeColumn].Value = SystemProcedure2.GetMasterCode("select Ldgr_No from GL_Ledger where " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Ldgr_Name" : "A_Ldgr_Name") + " = '" + ReflectionHelper.GetPrimitiveValue<string>(grdLC.Columns[grdLdgrNameColumn].Value) + "'"); 
					grdLC.Col = grdAmtColumn; 
					break;
			}
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}