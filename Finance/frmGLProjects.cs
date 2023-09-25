
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmGLProjects
		: System.Windows.Forms.Form
	{

		public frmGLProjects()
{
InitializeComponent();
} 
 public  void frmGLProjects_old()
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


		private void frmGLProjects_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private XArrayHelper _aProjectActivityDetails = null;
		private XArrayHelper aProjectActivityDetails
		{
			get
			{
				if (_aProjectActivityDetails is null)
				{
					_aProjectActivityDetails = new XArrayHelper();
				}
				return _aProjectActivityDetails;
			}
			set
			{
				_aProjectActivityDetails = value;
			}
		}


		//Enum for checking the current form mode
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		public Control FirstFocusObject = null;
		private string mTimeStamp = "";
		private const int mTabGLDetails = 2;
		private const int mTabActivityDetails = 3;
		private int mRecordNavigateSearchValue = 0;

		private const int mLineNoColumn = 0;
		private const int ckActivityCode = 1;
		private const int ckActivityName = 2;
		private const int ckFreeze = 3;

		private const int mMaxActivityDetailArrayCols = 3;

		private bool mActivityTabClick = false;
		private bool mFirstActivityTabClick = false;
		private bool mActivityDetailsTabClicked = false;

		private DataSet rsActivityList = null;

		private const string cGridColor = "15439757";



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

			FirstFocusObject = txtProjectNo;
			fraProjectCompletedDetails.Visible = false;

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
				oThisFormToolBar.BeginDeleteButtonWithGroup = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;
				oThisFormToolBar.BeginInsertLineButtonWithGroup = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;

				oThisFormToolBar.BeginMoveRecordPreviousButtonWithGroup = true;
				oThisFormToolBar.ShowMoveRecordPreviousButton = true;
				oThisFormToolBar.ShowMoveRecordNextButton = true;

				this.WindowState = FormWindowState.Maximized;

				//assign a next code
				txtProjectNo.Text = SystemProcedure2.GetNewNumber("PROJ_Projects", "Project_No", 3);

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("enable_gl_accounts_on_project_master"))) == TriState.True)
				{
					tabMaster.Item(mTabGLDetails).Visible = TriState.True != TriState.False;
				}
				else
				{
					tabMaster.Item(mTabGLDetails).Visible = TriState.False != TriState.False;
					//tabMaster.TabsPerPage = tabMaster.TabsPerPage - 1
				}

				tabMaster.SelectedItem = 0;
				mFirstActivityTabClick = true;
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
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
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
			txtProjectNo.Text = SystemProcedure2.GetNewNumber("PROJ_Projects", "Project_No", 3);
			txtParentProjectNo.Enabled = true;

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			FirstFocusObject.Focus();

			tabMaster.SelectedItem = 0;
			mActivityTabClick = false;

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord()
		{
			bool result = false;
			object mReturnValue = null;
			int mParentProjectCode = 0;

			int mBillCd = 0;
			int mWIPCd = 0;
			int mReceivableCd = 0;
			int mActivityCode = 0;
			int cnt = 0;
			string mysql = "";
			try
			{


				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select project_cd from PROJ_Projects where project_no='" + txtParentProjectNo.Text + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Project Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtParentProjectNo.Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mParentProjectCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				//''''''''''''''''''''''''''''''''''''''''''
				//''''Get the Gl details
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select ldgr_cd from gl_ledger where ldgr_no='" + txtBillingCd.Text + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					if (!SystemProcedure2.IsItEmpty(txtBillingCd.Text, SystemVariables.DataType.StringType))
					{
						MessageBox.Show("Invalid Ledger Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						ReflectionHelper.LetMember(tabMaster, "CurrTab", mTabGLDetails);
						txtBillingCd.Focus();
						return result;
					}
					else
					{
						mBillCd = 0;
					}
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mBillCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select ldgr_cd from gl_ledger where ldgr_no='" + txtWIPCd.Text + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					if (!SystemProcedure2.IsItEmpty(txtWIPCd.Text, SystemVariables.DataType.StringType))
					{
						MessageBox.Show("Invalid Ledger Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						ReflectionHelper.LetMember(tabMaster, "CurrTab", mTabGLDetails);
						txtWIPCd.Focus();
						return result;
					}
					else
					{
						mWIPCd = 0;
					}
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mWIPCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select ldgr_cd from gl_ledger where ldgr_no='" + txtReceivableCd.Text + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					if (!SystemProcedure2.IsItEmpty(txtReceivableCd.Text, SystemVariables.DataType.StringType))
					{
						MessageBox.Show("Invalid Ledger Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						ReflectionHelper.LetMember(tabMaster, "CurrTab", mTabGLDetails);
						txtReceivableCd.Focus();
						return result;
					}
					else
					{
						mReceivableCd = 0;
					}
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReceivableCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				//''''''''''''''''''''''''''''''''''''''''''''

				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " INSERT INTO PROJ_Projects(User_Cd , M_Project_Cd, Project_No, L_Project_Name, A_Project_Name, ";
					mysql = mysql + " Supervisor_Name , Start_Date, End_Date, Project_Type_Id, ";
					mysql = mysql + " Estimated_Expenses, Estimated_Income, L_Addr_1, L_Addr_2, ";
					mysql = mysql + " L_Addr_3, A_Addr_1, A_Addr_2, A_Addr_3, city, country, phone, ";
					mysql = mysql + " fax, email, web, Comments, ";
					mysql = mysql + " billing_ldgr_cd , wip_ldgr_cd, receivable_ldgr_cd ";
					mysql = mysql + " )";
					mysql = mysql + " VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mysql = mysql + "'" + ((Convert.IsDBNull(mParentProjectCode)) ? "Null" : mParentProjectCode.ToString()) + "',";
					mysql = mysql + "'" + txtProjectNo.Text + "',";
					mysql = mysql + "'" + txtLProjectName.Text + "',";
					mysql = mysql + "N'" + txtAprojectName.Text + "',";
					mysql = mysql + "'" + txtSupervisorName.Text + "',";
					mysql = mysql + "'" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDate.Value) + "',";
					mysql = mysql + "'" + ReflectionHelper.GetPrimitiveValue<string>(txtEndDate.Value) + "',";
					mysql = mysql + "'" + txtProjectType.Text + "',";
					mysql = mysql + txtExtimatedExp.Text + ",";
					mysql = mysql + txtEstimatedIncome.Text + ", ";
					mysql = mysql + "'" + txtLAdd1.Text + "',";
					mysql = mysql + "'" + txtLAdd1.Text + "',";
					mysql = mysql + "'" + txtLAdd3.Text + "',";
					mysql = mysql + "N'" + txtAAdd1.Text + "',";
					mysql = mysql + "N'" + txtAAdd1.Text + "',";
					mysql = mysql + "N'" + txtAAdd3.Text + "',";
					mysql = mysql + "'" + txtCity.Text + "',";
					mysql = mysql + "'" + txtCountry.Text + "',";
					mysql = mysql + "'" + txtPhone.Text + "',";
					mysql = mysql + "'" + txtFax.Text + "',";
					mysql = mysql + "'" + txtEmailAddress.Text + "',";
					mysql = mysql + "'" + txtWeb.Text + "',";
					mysql = mysql + "'" + txtComment.Text + "',";
					if (mBillCd != 0)
					{
						mysql = mysql + mBillCd.ToString() + ",";
					}
					else
					{
						mysql = mysql + " NULL , ";
					}

					if (mWIPCd != 0)
					{
						mysql = mysql + mWIPCd.ToString() + ",";
					}
					else
					{
						mysql = mysql + " NULL , ";
					}

					if (mReceivableCd != 0)
					{
						mysql = mysql + mReceivableCd.ToString();
					}
					else
					{
						mysql = mysql + " NULL  ";
					}
					mysql = mysql + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mSearchValue = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
				}
				else
				{
					mysql = " select time_stamp,protected from PROJ_Projects where project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					}
					else
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						FirstFocusObject.Focus();
						return result;
					}
					if (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp))
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						FirstFocusObject.Focus();
						return result;
					}
					if (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(1)))
					{
						MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}
					mysql = "UPDATE PROJ_Projects SET ";
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mysql = mysql + " M_Project_Cd = " + Conversion.Str((Convert.IsDBNull(mParentProjectCode)) ? ((object) "Null") : ((object) mParentProjectCode)) + ",";
					mysql = mysql + " Project_No = '" + txtProjectNo.Text + "',";
					mysql = mysql + " L_Project_Name ='" + txtLProjectName.Text + "',";
					mysql = mysql + " A_Project_Name =N'" + txtAprojectName.Text + "',";
					mysql = mysql + " Supervisor_Name ='" + txtSupervisorName.Text + "',";
					mysql = mysql + " Start_Date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtStartDate.Value) + "',";
					mysql = mysql + " End_Date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtEndDate.Value) + "',";
					mysql = mysql + " Project_Type_Id ='" + txtProjectType.Text + " ',";
					mysql = mysql + " Estimated_Expenses = " + txtExtimatedExp.Text + ",";
					mysql = mysql + " Estimated_Income = " + txtEstimatedIncome.Text + ", ";
					mysql = mysql + " L_Addr_1 ='" + txtLAdd1.Text + " ',";
					mysql = mysql + " L_Addr_2 ='" + txtLAdd1.Text + " ',";
					mysql = mysql + " L_Addr_3 ='" + txtLAdd3.Text + " ',";
					mysql = mysql + " A_Addr_1 =N'" + txtAAdd1.Text + "',";
					mysql = mysql + " A_Addr_2 =N'" + txtAAdd1.Text + "',";
					mysql = mysql + " A_Addr_3 =N'" + txtAAdd3.Text + "',";
					mysql = mysql + " city ='" + txtCity.Text + "',";
					mysql = mysql + " country ='" + txtCountry.Text + "',";
					mysql = mysql + " phone ='" + txtPhone.Text + "',";
					mysql = mysql + " mobile ='" + txtMobile.Text + "',";
					mysql = mysql + " fax ='" + txtFax.Text + "',";
					mysql = mysql + " email ='" + txtEmailAddress.Text + "',";
					mysql = mysql + " web ='" + txtWeb.Text + "',";
					mysql = mysql + " Comments ='" + txtComment.Text + "',";
					mysql = mysql + " User_Cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
					if (mBillCd != 0)
					{
						mysql = mysql + " billing_ldgr_cd =" + mBillCd.ToString() + ",";
					}
					else
					{
						mysql = mysql + " billing_ldgr_cd = NULL ,";
					}

					if (mWIPCd != 0)
					{
						mysql = mysql + " wip_ldgr_cd =" + mWIPCd.ToString() + ",";
					}
					else
					{
						mysql = mysql + " wip_ldgr_cd = NULL ,";
					}

					if (mReceivableCd != 0)
					{
						mysql = mysql + " receivable_ldgr_cd =" + mReceivableCd.ToString();
					}
					else
					{
						mysql = mysql + " receivable_ldgr_cd  = NULL  ";
					}
					mysql = mysql + " where project_cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}

				if (mActivityTabClick)
				{
					//-----------------Delete Project Activities-----------------------
					this.grdActivityDetails.UpdateData();

					mysql = "delete PROJ_Project_Activities ";
					mysql = mysql + " where ";
					mysql = mysql + " Project_Cd = " + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					//-----------------Insert Activity Tasks-----------------------
					int tempForEndVar = aProjectActivityDetails.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(aProjectActivityDetails.GetValue(cnt, ckActivityCode)) || Convert.ToString(aProjectActivityDetails.GetValue(cnt, ckActivityName)) == "")
						{
							MessageBox.Show("Invalid Activity", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							grdActivityDetails.Col = ckActivityCode;
							throw new Exception();
						}
						else
						{
							mysql = "select Acty_Cd ";
							mysql = mysql + " from PROJ_Activities where Acty_No ='" + Convert.ToString(aProjectActivityDetails.GetValue(cnt, ckActivityCode)) + "'";

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(SystemProcedure2.GetMasterCode(mysql)))
							{
								return result;
							}

							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mActivityCode = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));

							mysql = " INSERT INTO PROJ_Project_Activities(User_Cd, Project_Cd, Acty_Cd ";
							mysql = mysql + " , Freeze , User_Date_Time )";
							mysql = mysql + " VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
							mysql = mysql + Conversion.Str(mSearchValue) + ", ";
							mysql = mysql + mActivityCode.ToString() + ",";
							mysql = mysql + "0, ";
							//mysql = mysql & "" & aVoucherDetails(cnt, mActivityValueFreezeColumn) & ","
							mysql = mysql + "'" + DateTimeHelper.ToString(DateTime.Now) + "'";
							mysql = mysql + ")";
							SqlCommand TempCommand_4 = null;
							TempCommand_4 = SystemVariables.gConn.CreateCommand();
							TempCommand_4.CommandText = mysql;
							TempCommand_4.ExecuteNonQuery();
						}
					}
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				txtEstimatedIncome.Value = 0;
				txtExtimatedExp.Value = 0;

				FirstFocusObject.Focus();
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}
			return result;
		}

		public bool deleteRecord()
		{

			bool result = false;
			string mysql = " select protected from PROJ_Projects where project_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
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
					mysql = "delete from PROJ_Project_Activities where project_cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mysql = "delete from PROJ_Projects where project_cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (Information.Err().Number != 0)
					{
						MessageBox.Show("Project Code cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

			return result;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			if (mReturnErrorType == 1)
			{
				return false;
			}
			else if (mReturnErrorType == 2)
			{ 
				AddRecord();
				return false;
			}
			else
			{
				return false;
			}
		}

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			try
			{
				string mysql = "";
				object mReturnValue = null;
				SqlDataReader localRec = null;

				mysql = " select * from PROJ_Projects where project_cd= " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{
					mSearchValue = localRec["Project_Cd"];
					mRecordNavigateSearchValue = Convert.ToInt32(localRec["Project_Cd"]);
					mTimeStamp = Convert.ToString(localRec["time_stamp"]);
					txtProjectNo.Text = Convert.ToString(localRec["Project_No"]);
					txtLProjectName.Text = Convert.ToString(localRec["L_Project_Name"]);
					txtAprojectName.Text = Convert.ToString(localRec["a_Project_Name"]) + "";
					if (Convert.ToDouble(localRec["M_Project_Cd"]) == 0 || Convert.IsDBNull(localRec["M_Project_Cd"]))
					{
						txtParentProjectNo.Enabled = false;
					}
					else
					{
						txtParentProjectNo.Enabled = true;
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " project_no, L_Project_Name" : "project_no, L_Project_Name") + " from PROJ_Projects where project_cd=" + Convert.ToString(localRec["M_Project_Cd"])));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtParentProjectNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtParentProjectName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					}
					txtComment.Text = Convert.ToString(localRec["Comments"]) + "";
					if (!Convert.IsDBNull(localRec["Start_Date"]))
					{
						txtStartDate.Value = Convert.ToString(localRec["Start_Date"]) + "";
					}
					else
					{
						txtStartDate.Text = "";
					}
					if (!Convert.IsDBNull(localRec["End_Date"]))
					{
						txtEndDate.Value = Convert.ToString(localRec["End_Date"]) + "";
					}
					else
					{
						txtEndDate.Text = "";
					}
					txtProjectType.Text = Convert.ToString(localRec["Project_Type_Id"]) + "";
					if (Convert.ToDouble(localRec["Project_Type_Id"]) == 0)
					{
						txtParentProjectNo.Enabled = false;
					}
					else
					{
						txtProjectType.Enabled = true;
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Project_Type_Id, L_Type_Name" : "Project_Type_Id, a_Type_Name") + " from PROJ_Project_Types where Project_Type_Id = " + Convert.ToString(localRec["Project_Type_Id"])));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtProjectType.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtProjectTypeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					}

					if (!Convert.IsDBNull(localRec["billing_ldgr_cd"]))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " ldgr_no, L_ldgr_Name" : "ldgr_no, a_ldgr_Name") + " from gl_ledger where ldgr_cd= " + Convert.ToString(localRec["billing_ldgr_cd"])));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtBillingCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtBillingCodeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						txtBillingCd.Text = "";
						txtBillingCodeName.Text = "";
					}

					if (!Convert.IsDBNull(localRec["wip_ldgr_cd"]))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " ldgr_no, L_ldgr_Name" : "ldgr_no, a_ldgr_Name") + " from gl_ledger where ldgr_cd= " + Convert.ToString(localRec["wip_ldgr_cd"])));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtWIPCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtWIPCodeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						txtWIPCd.Text = "";
						txtWIPCodeName.Text = "";
					}

					if (!Convert.IsDBNull(localRec["receivable_ldgr_cd"]))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " ldgr_no, L_ldgr_Name" : "ldgr_no, a_ldgr_Name") + " from gl_ledger where ldgr_cd= " + Convert.ToString(localRec["receivable_ldgr_cd"])));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtReceivableCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtReceivableCodeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						txtReceivableCd.Text = "";
						txtReceivableCodeName.Text = "";
					}

					txtEstimatedIncome.Value = Convert.ToString(localRec["Estimated_Income"]) + "";
					txtExtimatedExp.Value = Convert.ToString(localRec["Estimated_Expenses"]) + "";
					txtPercentCompleted.Text = Convert.ToString(localRec["Percent_Completed"]) + "";
					txtLAdd1.Text = Convert.ToString(localRec["L_Addr_1"]) + "";
					txtLAdd2.Text = Convert.ToString(localRec["L_Addr_2"]) + "";
					txtLAdd3.Text = Convert.ToString(localRec["L_Addr_3"]) + "";
					txtAAdd1.Text = Convert.ToString(localRec["A_Addr_1"]) + "";
					txtAAdd2.Text = Convert.ToString(localRec["A_Addr_2"]) + "";
					txtAAdd3.Text = Convert.ToString(localRec["A_Addr_3"]) + "";
					txtSupervisorName.Text = Convert.ToString(localRec["Supervisor_Name"]) + "";
					txtCity.Text = Convert.ToString(localRec["city"]) + "";
					txtCountry.Text = Convert.ToString(localRec["country"]) + "";
					txtPhone.Text = Convert.ToString(localRec["phone"]) + "";
					txtFax.Text = Convert.ToString(localRec["fax"]) + "";
					txtMobile.Text = Convert.ToString(localRec["mobile"]) + "";
					txtEmailAddress.Text = Convert.ToString(localRec["email"]) + "";
					txtWeb.Text = Convert.ToString(localRec["web"]) + "";


					//Change the form mode to edit
					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				}
				localRec.Close();

				tabMaster.SelectedItem = 0;
				mActivityTabClick = false;

				AssignGridLineNumbers();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}

		}

		public void PrintReport()
		{
			SystemReports.GetSystemReport(51001020, 1);
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000130));
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
			//Check validation during update and add of records
			if (!Information.IsNumeric(txtParentProjectNo.Text))
			{
				MessageBox.Show("Enter Parent Project Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				ReflectionHelper.LetMember(tabMaster, "CurrTab", 0);
				txtParentProjectNo.Focus();
				return false;
			}
			if (!Information.IsNumeric(txtParentProjectNo.Text))
			{
				MessageBox.Show("Enter Parent Project Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (txtParentProjectNo.Enabled)
				{
					ReflectionHelper.LetMember(tabMaster, "CurrTab", 0);
					txtParentProjectNo.Focus();
				}
				return false;
			}

			if (!Information.IsNumeric(txtProjectType.Text))
			{
				MessageBox.Show("Enter Project Type Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (txtParentProjectNo.Enabled)
				{
					ReflectionHelper.LetMember(tabMaster, "CurrTab", 0);
					txtProjectType.Focus();
				}
				return false;
			}
			return true;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				UserAccess = null;
				oThisFormToolBar = null;
				frmGLProjects.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void tabMaster_Click()
		{
			try
			{

				switch(ReflectionHelper.GetMember<int>(tabMaster, "CurrTab"))
				{
					case 0 : 
						txtParentProjectNo.Focus(); 
						break;
					case 1 : 
						txtLAdd1.Focus(); 
						break;
				}
			}
			catch
			{

				//do not handle this error here
			}
		}

		private void tabMaster_SelectedChanged(Object eventSender, AxXtremeSuiteControls._DTabControlEvents_SelectedChangedEvent eventArgs)
		{
			try
			{

				switch(tabMaster.SelectedItem)
				{
					case mTabActivityDetails : 
						ShowActivityDetailsTab(); 
						mActivityDetailsTabClicked = true; 
						break;
				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				FirstFocusObject.Focus();
			}
		}

		private void txtBillingCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtBillingCd");
		}

		private void txtWIPCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtWIPCd");
		}

		private void txtReceivableCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtReceivableCd");
		}

		private void txtProjectNo_DropButtonClick(Object Sender, EventArgs e)
		{
			//Get the maximum + 1 ICS_Item_category code
			GetNextNumber();
		}

		private void txtParentProjectNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtParentProjectNo");
		}

		public void txtBillingCd_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtBillingCd.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_ldgr_Name" : "L_ldgr_Name");
					mysql = mysql + " from gl_ledger where ldgr_no='" + txtBillingCd.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtBillingCodeName.Text = "";
						//txtParentCostNo.SetFocus
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtBillingCodeName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtBillingCodeName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
			}
		}

		public void txtWIPCd_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtWIPCd.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_ldgr_Name" : "L_ldgr_Name");
					mysql = mysql + " from gl_ledger where ldgr_no='" + txtWIPCd.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtWIPCodeName.Text = "";
						//txtParentCostNo.SetFocus
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtWIPCodeName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtWIPCodeName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
			}
		}

		public void txtReceivableCd_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtReceivableCd.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_ldgr_Name" : "L_ldgr_Name");
					mysql = mysql + " from gl_ledger where ldgr_no='" + txtReceivableCd.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtReceivableCodeName.Text = "";
						//txtParentCostNo.SetFocus
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtReceivableCodeName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtReceivableCodeName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
			}
		}

		public void txtParentProjectNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtParentProjectNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Project_Name" : "A_Project_Name");
					mysql = mysql + " from PROJ_Projects where Project_No=" + txtParentProjectNo.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtParentProjectName.Text = "";
						//txtParentCostNo.SetFocus
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtParentProjectName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtParentProjectName.Text = "";
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
					//    txtParentCostNo.SetFocus
				}
				else
				{
					//
				}
			}
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtParentProjectNo" : 
					txtParentProjectNo.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000130, "985,986,987")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtParentProjectNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtParentProjectName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						//Call txtParentProjectNo_LostFocus
					} 
					break;
				case "txtProjectType" : 
					txtProjectType.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000140, "991,993,994")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtProjectType.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtProjectTypeName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						//Call txtProjectType_LostFocus
					} 
					break;
				case "txtBillingCd" : 
					txtBillingCd.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2,3,4")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtBillingCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtBillingCodeName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						//Call txtBillingCd_LostFocus
					} 
					break;
				case "txtWIPCd" : 
					txtWIPCd.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2,3,4")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtWIPCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtWIPCodeName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						//Call txtBillingCd_LostFocus
					} 
					break;
				case "txtReceivableCd" : 
					txtReceivableCd.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2,3,4")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtReceivableCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtReceivableCodeName.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						//Call txtBillingCd_LostFocus
					} 
					break;
				default:
					return;
			}
		}

		public void GetNextNumber()
		{
			txtProjectNo.Text = SystemProcedure2.GetNewNumber("PROJ_Projects", "Project_No");
			FirstFocusObject.Focus();
		}


		private void txtProjectType_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtProjectType");
		}

		public void txtProjectType_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtProjectType.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Type_Name" : "A_Type_Name");
					mysql = mysql + " from PROJ_Project_Types where Project_Type_Id=" + txtProjectType.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtProjectTypeName.Text = "";
						//txtParentCostNo.SetFocus
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtProjectTypeName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtProjectTypeName.Text = "";
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
					//    txtParentCostNo.SetFocus
				}
				else
				{
					//
				}
			}
		}

		private void ShowActivityDetailsTab()
		{

			string mysql = "";
			int cnt = 0;
			SqlDataReader rsLocalRec = null;

			if (!mActivityTabClick)
			{
				if (mFirstActivityTabClick)
				{

					SystemGrid.DefineSystemVoucherGrid(grdActivityDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, cGridColor);
					//define voucher grid columns
					SystemGrid.DefineSystemVoucherGridColumn(grdActivityDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
					SystemGrid.DefineSystemVoucherGridColumn(grdActivityDetails, "Activity Code", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbPriceList");
					SystemGrid.DefineSystemVoucherGridColumn(grdActivityDetails, "Activity Name", 4000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbPriceList");

					mFirstActivityTabClick = false;
					aProjectActivityDetails = new XArrayHelper();
				}
				else
				{
					//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aProjectActivityDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					aProjectActivityDetails.Clear();
				}

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{

					mysql = "select  pa.Acty_Cd, a.Acty_No, ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "a.L_Acty_Name" : "a.A_Acty_Name") + " as activity_name, pa.Freeze";
					mysql = mysql + " from  PROJ_Project_Activities pa ";
					mysql = mysql + " inner join PROJ_Activities a on pa.Acty_Cd = a.Acty_Cd ";
					mysql = mysql + " where pa.Project_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

					SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
					rsLocalRec = sqlCommand.ExecuteReader();
					rsLocalRec.Read();

					SystemGrid.DefineVoucherArray(aProjectActivityDetails, mMaxActivityDetailArrayCols, -1, true);
					do 
					{
						SystemGrid.DefineVoucherArray(aProjectActivityDetails, mMaxActivityDetailArrayCols, cnt, false);

						//aProductSupplierDetails(cnt, ckSupplierIndex) = .Fields("Entry_Id").Value
						aProjectActivityDetails.SetValue(rsLocalRec["Acty_No"], cnt, ckActivityCode);
						aProjectActivityDetails.SetValue(Convert.ToString(rsLocalRec["activity_name"]) + "", cnt, ckActivityName);
						aProjectActivityDetails.SetValue(rsLocalRec["Freeze"], cnt, ckFreeze);

						cnt++;
					}
					while(rsLocalRec.Read());
					rsLocalRec.Close();
					AssignGridLineNumbers();
				}
				else
				{
					SystemGrid.DefineVoucherArray(aProjectActivityDetails, mMaxActivityDetailArrayCols, -1, true);
				}
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdActivityDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdActivityDetails.setArray(aProjectActivityDetails);
				//Call AssignSupplierGridLineNumbers
				grdActivityDetails.Rebind(true);
				mActivityTabClick = true;
			}
		}

		private void grdActivityDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{

			try
			{
				string mysql = "";

				if (!mActivityDetailsTabClicked)
				{
					SystemGrid.DefineSystemGridCombo(cmbPriceList);
					RefreshgrdActivityDetails();
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdActivityDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdActivityDetails.PostMsg(1);

				}
				else
				{
					SystemGrid.DefineSystemGridCombo(cmbPriceList);
					RefreshgrdActivityDetails();
				}
			}
			catch
			{
				//MsgBox Err.Description
			}

		}

		private void RefreshgrdActivityDetails(bool pCallComboRowChange = true)
		{
			string mysql = "";

			if (grdActivityDetails.Col == ckActivityCode || grdActivityDetails.Col == ckActivityName)
			{
				mysql = "select Acty_No, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Acty_Name" : "A_Acty_Name") + " as Activity_name ";
				mysql = mysql + " from PROJ_Activities ";

				rsActivityList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsActivityList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsActivityList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsActivityList.Tables.Clear();
				adap.Fill(rsActivityList);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsActivityList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsActivityList.Requery(-1);

				grdActivityDetails.Focus();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPriceList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbPriceList.setDataSource((msdatasrc.DataSource) rsActivityList);
			}

		}

		private void grdActivityDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			object mTempSearchValue = null;
			string mysql = "";
			int mProdCd = 0;
			bool mIsDuplicate = false;

			grdActivityDetails.UpdateData();

			if (ColIndex == ckActivityCode)
			{
				if (!SystemProcedure2.IsItEmpty(grdActivityDetails.Columns[ckActivityCode].Value, SystemVariables.DataType.StringType))
				{


					mysql = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Acty_Name" : "A_Acty_Name") + " as Activity_Name";
					mysql = mysql + " from PROJ_Activities where Acty_No = '" + grdActivityDetails.Columns[ckActivityCode].Text + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						grdActivityDetails.Columns[ckActivityName].Value = mTempSearchValue;
					}
				}
				//grdPriceDetails.Refresh
			}
			else if (ColIndex == ckActivityName)
			{ 
				if (!SystemProcedure2.IsItEmpty(grdActivityDetails.Columns[ckActivityName].Value, SystemVariables.DataType.StringType))
				{

					mysql = " select Acty_No ";
					mysql = mysql + " from PROJ_Activities where " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Acty_Name" : "A_Acty_Name") + " = '" + ReflectionHelper.GetPrimitiveValue<string>(grdActivityDetails.Columns[ckActivityName].Value) + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						grdActivityDetails.Columns[ckActivityCode].Value = mTempSearchValue;
					}

				}
				//grdPriceDetails.Refresh
			}
			grdActivityDetails.Refresh();
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbPriceList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbPriceList_DataSourceChanged()
		{
			int cnt = 0;

			cmbPriceList.Width = 0;
			switch(grdActivityDetails.Col)
			{
				case ckActivityCode : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPriceList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbPriceList.setListField("Acty_No"); 
					cmbPriceList.DisplayColumns[0].Visible = true; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbPriceList.Width = grdActivityDetails.Splits[0].DisplayColumns[ckActivityCode].Width + 167; 
					 
					break;
				case ckActivityName : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPriceList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbPriceList.setListField("Activity_name"); 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property cmbPriceList.Columns.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbPriceList.Splits[0].DisplayColumns[0].setOrder(1); 
					cmbPriceList.DisplayColumns[1].Width = 200; 
					cmbPriceList.DisplayColumns[0].Width = 47; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbPriceList.Width = grdActivityDetails.Splits[0].DisplayColumns[ckActivityName].Width + 100; 
					 
					break;
			}
		}

		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aProjectActivityDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aProjectActivityDetails.SetValue(cnt + 1, cnt, mLineNoColumn);
			}
		}


		public void IRoutine()
		{
			if (ActiveControl.Name != "grdActivityDetails")
			{
				grdActivityDetails.Focus();
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdActivityDetails.Bookmark))
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aProjectActivityDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aProjectActivityDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdActivityDetails.Bookmark), 1);
				AssignGridLineNumbers();
				grdActivityDetails.Rebind(true);
				grdActivityDetails.Focus();
				grdActivityDetails.Refresh();
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdActivityDetails")
			{
				grdActivityDetails.Focus();
			}

			if (aProjectActivityDetails.GetLength(0) > 0)
			{
				grdActivityDetails.Delete();
				AssignGridLineNumbers();
				grdActivityDetails.Rebind(true);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdActivityDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdActivityDetails_OnAddNew()
		{
			grdActivityDetails.Columns[mLineNoColumn].Text = (grdActivityDetails.RowCount + 1).ToString();
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

		private void RecordNavidate(int pKeyCode, int pProjectCd)
		{

			string mysql = " select top 1 Project_Cd from PROJ_Projects ";
			mysql = mysql + " where 1=1 ";
			if (pProjectCd > 0 && pKeyCode == 37)
			{
				mysql = mysql + " and Project_Cd < " + pProjectCd.ToString();
			}
			else if (pProjectCd > 0 && pKeyCode == 39)
			{ 
				mysql = mysql + " and Project_Cd > " + pProjectCd.ToString();
			}

			if (pKeyCode == 37)
			{
				mysql = mysql + " order by Project_Cd desc ";
			}
			else if (pKeyCode == 39)
			{ 
				mysql = mysql + " order by Project_Cd asc ";
			}

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				GetRecord(mReturnValue);
			}

		}
	}
}