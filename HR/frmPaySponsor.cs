
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPaySponsors
		: System.Windows.Forms.Form
	{

		public frmPaySponsors()
{
InitializeComponent();
} 
 public  void frmPaySponsors_old()
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


		private void frmPaySponsors_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private int mThisFormID = 0;
		private object mSearchValue = null;
		private clsToolbar oThisFormToolBar = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		private const int conTxtSponsorNo = 0;
		private const int conTxtNationalityCd = 1;
		private const int conTxtCompanyCd = 3;
		private const int conTxtGovernateCd = 2;
		private const int conTxtCivilIdNo = 5;
		private const int conTxtLFirstName = 6;
		private const int conTxtLSecondName = 7;
		private const int conTxtLThirdName = 8;
		private const int conTxtLFourthName = 9;
		private const int conTxtAFirstName = 10;
		private const int conTxtASecondName = 11;
		private const int conTxtAThirdName = 12;
		private const int conTxtAFourthName = 13;
		private const int conTxtRegistration_No = 14;
		private const int conTxtArea = 15;
		private const int conTxtBlockNo = 16;
		private const int conTxtStreet = 17;
		private const int conTxtAvenue = 18;
		private const int conTxtHouseType = 19;
		private const int conTxtHouseName = 20;
		private const int conTxtPlotNo = 21;
		private const int conTxtFloorNo = 22;
		private const int conTxtFlatNo = 23;
		private const int conTxtEntrance = 24;
		private const int conTxtPOBox = 25;
		private const int conTxtZipCode = 26;
		private const int conTxtTelephoneNo = 27;
		private const int conTxtMobileno = 28;
		private const int conTxtComments = 4;

		private const int conDlblNationalityCd = 0;
		private const int conDlblGovernateName = 1;
		private const int conDlblCompanyCd = 2;


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
			FirstFocusObject = txtCommonTextBox[conTxtSponsorNo];

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
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				//
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture

				SystemProcedure.SetLabelCaption(this);

				//txtIssueDate.Text = ""
				//txtExpiryDate.Text = ""
				GetNextNumber();
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

		public void AddRecord()
		{

			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearNumberBox(this);

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			GetNextNumber();
			mSearchValue = "";
			FirstFocusObject.Focus();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord(bool pPostGl = false)
		{
			bool result = false;
			object mReturnValue = null;
			string mysql = "";

			int mNatCd = 0;
			int mCompCd = 0;
			int mGovernateCd = 0;
			int mEntryId = 0;


			try
			{


				mysql = " select nat_cd from pay_nationality ";
				mysql = mysql + " where nat_no='" + txtCommonTextBox[conTxtNationalityCd].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mNatCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					MessageBox.Show("Invalid Nationality Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonTextBox[conTxtNationalityCd].Focus();
					goto mError;
				}

				mysql = " select comp_cd from pay_company ";
				mysql = mysql + " where comp_no='" + txtCommonTextBox[conTxtCompanyCd].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCompCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					MessageBox.Show("Invalid Company Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonTextBox[conTxtCompanyCd].Focus();
					goto mError;
				}

				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtGovernateCd].Text, SystemVariables.DataType.NumberType))
				{
					mysql = " select governate_cd from pay_governate ";
					mysql = mysql + " where governate_no=" + txtCommonTextBox[conTxtGovernateCd].Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mGovernateCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Invalid Governate Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommonTextBox[conTxtGovernateCd].Focus();
						goto mError;
					}
				}
				else
				{
					mGovernateCd = 0;
				}


				SystemVariables.gConn.BeginTransaction();

				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " select sponsor_no from pay_sponsor ";
					mysql = mysql + " where sponsor_no ='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						result = false;
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show(" Sponsor Code already exists, Transaction failed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommonTextBox[conTxtSponsorNo].Focus();
						return result;
					}

				}


				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into pay_sponsor ";
					mysql = mysql + " ( nat_cd, comp_cd, governate_cd, sponsor_no, L_First_name, L_Second_Name, L_Third_Name, L_Fourth_Name ";
					mysql = mysql + " , A_First_Name, A_Second_Name, A_Third_Name, A_Fourth_Name, Registration_No, Area, Block_No ";
					mysql = mysql + " , Street, Avenue, House_Type, House_Name, Plot_No, Floor_No, Flat_No ";
					mysql = mysql + " , Entrance, PO_Box, Zip_Code, Tel_No, Mobile_No, comments ";
					mysql = mysql + " , Civil_id_no, user_cd  ) ";
					mysql = mysql + " values( ";
					mysql = mysql + mNatCd.ToString();
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtCompanyCd].Text, SystemVariables.DataType.NumberType))
					{
						mysql = mysql + " , " + mCompCd.ToString() + "";
					}
					else
					{
						mysql = mysql + " , " + " NULL ";
					}

					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtGovernateCd].Text, SystemVariables.DataType.NumberType))
					{
						mysql = mysql + " , " + mGovernateCd.ToString() + "";
					}
					else
					{
						mysql = mysql + " , " + " NULL ";
					}

					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtSponsorNo].Text + "", SystemVariables.DataType.NumberType))
					{
						mysql = mysql + " , " + txtCommonTextBox[conTxtSponsorNo].Text + "";
					}
					else
					{
						mysql = mysql + " , " + " NULL ";
					}

					mysql = mysql + " , '" + txtCommonTextBox[conTxtLFirstName].Text + "'";
					mysql = mysql + " , '" + txtCommonTextBox[conTxtLSecondName].Text + "'";
					mysql = mysql + " , '" + txtCommonTextBox[conTxtLThirdName].Text + "'";
					mysql = mysql + " , '" + txtCommonTextBox[conTxtLFourthName].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtAFirstName].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtASecondName].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtAThirdName].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtAFourthName].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtRegistration_No].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtArea].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtBlockNo].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtStreet].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtAvenue].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtHouseType].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtHouseName].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtPlotNo].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtFloorNo].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtFlatNo].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtEntrance].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtPOBox].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtZipCode].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtTelephoneNo].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtMobileno].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtComments].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtCivilIdNo].Text + "'";
					mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString() + ")";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

				}
				else
				{
					//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);

					mysql = " select time_stamp from pay_sponsor where sponsor_cd =" + mEntryId.ToString();
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

					mysql = " update pay_sponsor set ";
					mysql = mysql + " sponsor_no =" + txtCommonTextBox[conTxtSponsorNo].Text;


					if (mNatCd == 0)
					{
						mysql = mysql + " , nat_cd = NULL ";
					}
					else
					{
						mysql = mysql + " , nat_cd =" + mNatCd.ToString();
					}


					if (mCompCd == 0)
					{
						mysql = mysql + " , comp_cd = NULL ";
					}
					else
					{
						mysql = mysql + " , comp_cd =" + mCompCd.ToString();
					}


					if (mGovernateCd == 0)
					{
						mysql = mysql + " , governate_cd = NULL ";
					}
					else
					{
						mysql = mysql + " , governate_cd =" + mGovernateCd.ToString();
					}

					mysql = mysql + " , L_First_Name = N'" + txtCommonTextBox[conTxtLFirstName].Text + "'";
					mysql = mysql + " , L_Second_Name = N'" + txtCommonTextBox[conTxtLSecondName].Text + "'";
					mysql = mysql + " , L_Third_Name = N'" + txtCommonTextBox[conTxtLThirdName].Text + "'";
					mysql = mysql + " , L_Fourth_Name = N'" + txtCommonTextBox[conTxtLFourthName].Text + "'";
					mysql = mysql + " , A_First_Name = N'" + txtCommonTextBox[conTxtAFirstName].Text + "'";
					mysql = mysql + " , A_Second_Name = N'" + txtCommonTextBox[conTxtASecondName].Text + "'";
					mysql = mysql + " , A_Third_Name = N'" + txtCommonTextBox[conTxtAThirdName].Text + "'";
					mysql = mysql + " , A_Fourth_Name = N'" + txtCommonTextBox[conTxtAFourthName].Text + "'";
					mysql = mysql + " , Registration_No = N'" + txtCommonTextBox[conTxtRegistration_No].Text + "'";
					mysql = mysql + " , Area = N'" + txtCommonTextBox[conTxtArea].Text + "'";
					mysql = mysql + " , Block_No= N'" + txtCommonTextBox[conTxtBlockNo].Text + "'";
					mysql = mysql + " , Street = N'" + txtCommonTextBox[conTxtStreet].Text + "'";
					mysql = mysql + " , Avenue = N'" + txtCommonTextBox[conTxtAvenue].Text + "'";
					mysql = mysql + " , House_Type = N'" + txtCommonTextBox[conTxtHouseType].Text + "'";
					mysql = mysql + " , House_Name = N'" + txtCommonTextBox[conTxtHouseName].Text + "'";
					mysql = mysql + " , Plot_No = N'" + txtCommonTextBox[conTxtPlotNo].Text + "'";
					mysql = mysql + " , Floor_No = N'" + txtCommonTextBox[conTxtFloorNo].Text + "'";
					mysql = mysql + " , Flat_No = N'" + txtCommonTextBox[conTxtFlatNo].Text + "'";
					mysql = mysql + " , Entrance = N'" + txtCommonTextBox[conTxtEntrance].Text + "'";
					mysql = mysql + " , PO_Box = N'" + txtCommonTextBox[conTxtPOBox].Text + "'";
					mysql = mysql + " , Zip_Code = N'" + txtCommonTextBox[conTxtZipCode].Text + "'";
					mysql = mysql + " , Tel_No = N'" + txtCommonTextBox[conTxtTelephoneNo].Text + "'";
					mysql = mysql + " , Mobile_No = N'" + txtCommonTextBox[conTxtMobileno].Text + "'";
					mysql = mysql + " , Comments =N'" + txtCommonTextBox[conTxtComments].Text + "'";
					mysql = mysql + " , Civil_Id_No =N'" + txtCommonTextBox[conTxtCivilIdNo].Text + "'";
					mysql = mysql + " where sponsor_cd =" + mEntryId.ToString();
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

				}


				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				FirstFocusObject.Focus();
				return result;

				mError:
				return false;
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


			SystemVariables.gConn.BeginTransaction();

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "delete from pay_sponsor where sponsor_cd=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Sponsor cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
				string mysql = "";
				object mReturnValue = null;
				SqlDataReader localRec = null;

				mysql = " select  pspon.sponsor_cd, pspon.sponsor_no, pspon.l_first_name, pspon.l_second_name, pspon.l_third_name, pspon.l_fourth_name, ";
				mysql = mysql + " pspon.a_first_name, pspon.a_second_name, pspon.a_third_name, pspon.a_fourth_name,";
				mysql = mysql + " pspon.registration_no, pnat.nat_no,   pcomp.comp_no,";
				mysql = mysql + "  pgov.governate_no, ";
				mysql = mysql + "  pspon.area, pspon.block_no, pspon.street, pspon.avenue,";
				mysql = mysql + " pspon.house_type, pspon.house_name, pspon.plot_no, pspon.floor_no, pspon.flat_no, pspon.entrance,";
				mysql = mysql + " pspon.po_box, pspon.zip_code, pspon.tel_no, pspon.mobile_no, pspon.comments,";
				mysql = mysql + " pspon.time_stamp, pspon.civil_id_no";


				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					mysql = mysql + " , pcomp.l_comp_name, pnat.l_nat_name, pgov.l_governate_name";
				}
				else
				{
					mysql = mysql + " , pcomp.a_comp_name, pnat.a_nat_name, pgov.a_governate_name";
				}


				mysql = mysql + " from pay_sponsor pspon";
				mysql = mysql + " inner join pay_nationality pnat on pspon.nat_cd = pnat.nat_cd";
				mysql = mysql + " left outer join pay_company pcomp on pspon.comp_cd = pcomp.comp_cd";
				mysql = mysql + " left outer join pay_governate pgov on pspon.governate_cd = pgov.governate_cd";
				mysql = mysql + " where pspon.sponsor_cd= " + Conversion.Str(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{

					mSearchValue = localRec["Sponsor_cd"];
					mTimeStamp = Convert.ToString(localRec["time_stamp"]);

					txtCommonTextBox[conTxtSponsorNo].Text = Convert.ToString(localRec["Sponsor_No"]);
					txtCommonTextBox[conTxtLFirstName].Text = Convert.ToString(localRec["L_First_Name"]);
					txtCommonTextBox[conTxtLSecondName].Text = Convert.ToString(localRec["L_Second_Name"]);
					txtCommonTextBox[conTxtLThirdName].Text = Convert.ToString(localRec["L_Third_Name"]);
					txtCommonTextBox[conTxtLFourthName].Text = Convert.ToString(localRec["L_Fourth_Name"]);

					txtCommonTextBox[conTxtAFirstName].Text = Convert.ToString(localRec["a_First_Name"]) + "";
					txtCommonTextBox[conTxtASecondName].Text = Convert.ToString(localRec["a_Second_Name"]) + "";
					txtCommonTextBox[conTxtAThirdName].Text = Convert.ToString(localRec["a_Third_Name"]) + "";
					txtCommonTextBox[conTxtAFourthName].Text = Convert.ToString(localRec["a_Fourth_Name"]) + "";

					txtCommonTextBox[conTxtGovernateCd].Text = Convert.ToString(localRec["governate_no"]);

					txtCommonTextBox[conTxtCivilIdNo].Text = Convert.ToString(localRec["civil_id_no"]) + "";

					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						txtDisplayLabel[conDlblGovernateName].Text = Convert.ToString(localRec["L_governate_name"]);
					}
					else
					{
						txtDisplayLabel[conDlblGovernateName].Text = Convert.ToString(localRec["a_governate_name"]);
					}



					txtCommonTextBox[conTxtNationalityCd].Text = Convert.ToString(localRec["nat_no"]);

					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						txtDisplayLabel[conDlblNationalityCd].Text = Convert.ToString(localRec["L_nat_name"]);
					}
					else
					{
						txtDisplayLabel[conDlblNationalityCd].Text = Convert.ToString(localRec["a_nat_name"]);
					}

					txtCommonTextBox[conTxtCompanyCd].Text = Convert.ToString(localRec["comp_no"]);

					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						txtDisplayLabel[conDlblCompanyCd].Text = Convert.ToString(localRec["L_comp_name"]);
					}
					else
					{
						txtDisplayLabel[conDlblCompanyCd].Text = Convert.ToString(localRec["a_comp_name"]);
					}

					txtCommonTextBox[conTxtRegistration_No].Text = Convert.ToString(localRec["registration_no"]) + "";
					txtCommonTextBox[conTxtArea].Text = Convert.ToString(localRec["area"]) + "";
					txtCommonTextBox[conTxtBlockNo].Text = Convert.ToString(localRec["block_no"]) + "";
					txtCommonTextBox[conTxtStreet].Text = Convert.ToString(localRec["street"]) + "";
					txtCommonTextBox[conTxtAvenue].Text = Convert.ToString(localRec["avenue"]) + "";
					txtCommonTextBox[conTxtHouseType].Text = Convert.ToString(localRec["house_type"]) + "";
					txtCommonTextBox[conTxtHouseName].Text = Convert.ToString(localRec["house_name"]) + "";
					txtCommonTextBox[conTxtPlotNo].Text = Convert.ToString(localRec["plot_no"]) + "";
					txtCommonTextBox[conTxtFloorNo].Text = Convert.ToString(localRec["floor_no"]) + "";
					txtCommonTextBox[conTxtFlatNo].Text = Convert.ToString(localRec["flat_no"]) + "";
					txtCommonTextBox[conTxtEntrance].Text = Convert.ToString(localRec["entrance"]) + "";
					txtCommonTextBox[conTxtPOBox].Text = Convert.ToString(localRec["po_box"]) + "";
					txtCommonTextBox[conTxtZipCode].Text = Convert.ToString(localRec["zip_code"]) + "";
					txtCommonTextBox[conTxtTelephoneNo].Text = Convert.ToString(localRec["tel_no"]) + "";
					txtCommonTextBox[conTxtMobileno].Text = Convert.ToString(localRec["mobile_no"]) + "";
					txtCommonTextBox[conTxtComments].Text = Convert.ToString(localRec["comments"]) + "";


				}

				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				//    End If
				localRec.Close();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}

		}

		public void PrintReport()
		{

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7200000));
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

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtLFirstName].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter First Name ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtLFirstName].Focus();
			}
			else
			{

				if (!Information.IsNumeric(txtCommonTextBox[conTxtGovernateCd].Text))
				{
					MessageBox.Show("Enter Governate Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonTextBox[conTxtGovernateCd].Focus();
				}
				else
				{

					return true;

				}
			}

			return false;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmPaySponsors.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtGradeNo_DropButtonClick()
		{
			//Get the maximum + 1 product_category code
			GetNextNumber();
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
			if (mObjectName == "txtCommonTextBox")
			{
				txtCommonTextBox[mObjectIndex].Text = "";
				switch(mObjectIndex)
				{
					//Case conTxtEmpCd
					//mTempSearchValue = FindItem(7050000, "831")
					case conTxtNationalityCd : 
						txtCommonTextBox[conTxtNationalityCd].Text = ""; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7004000, "743")); 
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonTextBox[conTxtNationalityCd].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
							txtCommonTextBox_Leave(txtCommonTextBox[mObjectIndex], new EventArgs());
						} 
						break;
					case conTxtCompanyCd : 
						txtCommonTextBox[conTxtCompanyCd].Text = ""; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7001100, "1769")); 
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonTextBox[conTxtCompanyCd].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
							txtCommonTextBox_Leave(txtCommonTextBox[mObjectIndex], new EventArgs());
						} 
						 
						break;
					case conTxtGovernateCd : 
						//mFilterCondition = " ( ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" 
						//mFilterCondition = mFilterCondition & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" & ")" 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7150000, "1483")); 
						//Case conTxtDocumentCd 
						//mFilterCondition = " status = 2 " 
						//   mTempSearchValue = FindItem(7120000, "1470") 
						//Case conTxtPlaceOfDocument 
						//   mTempSearchValue = FindItem(7130000, "1477") 
						break;
					default:
						return; 

				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[mObjectIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtCommonTextBox_Leave(txtCommonTextBox[mObjectIndex], new EventArgs());
				}
			}

		}

		public void GetNextNumber()
		{
			// Date :- 09-June-07
			//Added by Burhan Ghee Bcoz on form load focus is not on the respective object
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				txtCommonTextBox[conTxtSponsorNo].Text = SystemProcedure2.GetNewNumber("Pay_Sponsor", "Sponsor_No");
				FirstFocusObject.Focus();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			if (Index == conTxtSponsorNo)
			{
				GetNextNumber();
			}
			else
			{
				FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
			}
		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);

			object mTempValue = null;
			string mysql = "";
			int mLinkedTextBoxIndex = 0;

			try
			{

				switch(Index)
				{
					case conTxtGovernateCd : 
						mysql = " select l_governate_name, a_governate_name , governate_cd "; 
						mysql = mysql + " from pay_governate "; 
						mysql = mysql + " where governate_no =" + txtCommonTextBox[Index].Text; 
						mLinkedTextBoxIndex = conDlblGovernateName; 
						 
						break;
					case conTxtCompanyCd : 
						mysql = " select l_comp_name, a_comp_name , comp_cd "; 
						mysql = mysql + " from pay_company "; 
						mysql = mysql + " where comp_no =" + txtCommonTextBox[Index].Text; 
						mLinkedTextBoxIndex = conDlblCompanyCd; 
						 
						break;
					case conTxtNationalityCd : 
						mysql = " select l_Nat_name, a_Nat_name , Nat_cd "; 
						mysql = mysql + " from pay_Nationality "; 
						mysql = mysql + " where nat_no =" + txtCommonTextBox[Index].Text; 
						mLinkedTextBoxIndex = conDlblNationalityCd; 
						break;
					default:
						return;
				}

				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[Index].Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDisplayLabel[mLinkedTextBoxIndex].Text = "";
						txtCommonTextBox[Index].Tag = "";
						throw new System.Exception("-9990002");
					}
					else
					{

						txtDisplayLabel[mLinkedTextBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1));
					}
				}
				else
				{
					//    txtDisplayLabel(mLinkedTextBoxIndex).Text = ""
					txtCommonTextBox[Index].Tag = "";
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
						txtCommonTextBox[Index].Focus();
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