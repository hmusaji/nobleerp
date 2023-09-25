
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayEmployeeWazaraDetails
		: System.Windows.Forms.Form
	{

		public frmPayEmployeeWazaraDetails()
{
InitializeComponent();
} 
 public  void frmPayEmployeeWazaraDetails_old()
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


		private void frmPayEmployeeWazaraDetails_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private const int conTabPersonnelBasic = 0;
		private const int conTabPersonnelDetailed = 1;
		private const int conTabPersonnelOthers = 3;

		private const int conTxtEmpCode = 0;
		private const int conTxtLFirstName = 1;
		private const int conTxtLSecondName = 2;
		private const int conTxtLThirdName = 3;
		private const int conTxtLFourthName = 4;
		private const int conTxtAFirstName = 5;
		private const int conTxtASecondName = 6;
		private const int conTxtAThirdName = 7;
		private const int conTxtAFourthName = 8;
		private const int conTxtLFatherName = 12;
		private const int conTxtAFatherName = 13;
		private const int conTxtLMotherName = 14;
		private const int conTxtAMotherName = 15;
		private const int conTxtComment = 20;
		private const int conTxtPreviousSponsor = 9;
		private const int conTxtPreviousCompanyName = 46;
		private const int conTxtDesignationName = 10;
		private const int conTxtQualificationName = 11;
		private const int conTxtPlaceOfBirth = 18;
		private const int conTxtBloodGroup = 23;
		private const int conTxtGender = 49;
		private const int conTxtReligion = 50;
		private const int conTxtMaritalStatus = 53;
		private const int conTxtArea = 37;
		private const int conTxtBlock = 36;
		private const int conTxtStreet = 35;
		private const int conTxtLane = 34;
		private const int conTxtTypeofBldg = 33;
		private const int conTxtBldgNo = 32;
		private const int conTxtQasima = 24;
		private const int conTxtFloor = 31;
		private const int conTxtFlatNo = 30;
		private const int conTxtEntrance = 25;
		private const int conTxtPOBox = 26;
		private const int conTxtZipCode = 27;
		private const int conTxtTelephoneNo = 28;
		private const int conTxtTelephoneNo2 = 43;
		private const int conTxtMobileno = 29;
		private const int conTxtPagerNo = 39;
		private const int conTxtEmailAddress = 38;
		private const int conTxtAddress1 = 42;
		private const int conTxtAddress2 = 41;
		private const int conTxtAddress3 = 40;
		private const int conTxtAddress4 = 45;
		private const int conTxtFax = 44;
		private const int conTxtCivilId = 17;
		private const int conTxtPassportNo = 16;
		private const int conTxtWorkPermitNo = 19;
		private const int conTxtVisaNo = 21;
		private const int conTxtResidanceNo = 22;
		private const int conTxtVisaType = 51;
		private const int conTxtSponsorCode = 52;
		private const int conTxtNatCode = 47;
		private const int conTxtGovernateCd = 48;
		private const int conTxtAuthorizedSig = 54;
		private const int conTxtNewFileNo = 55;
		private const int conTxtNewContractNo = 56;
		private const int conTxtNewLicenseNo = 57;
		private const int conTxtOldFileNo = 58;
		private const int conTxtOldContractNo = 59;
		private const int conTxtOldLicenseNo = 60;
		private const int conTxtNewContractPeriod = 61;
		private const int conTxtOldContractPeriod = 62;
		private const int conTxtNewProfession = 65;
		private const int conTxtOldProfession = 63;
		private const int conTxtFifthName = 64;
		private const int conTxtAFifthName = 66;

		private const int conNTxtNewContractSalary = 1;
		private const int conNTxtOldContractSalary = 0;

		private const int conDlblVisaTypeName = 9;
		private const int conDlblSponsorName = 10;
		private const int conDlblNatName = 7;
		private const int conDlblGovernateName = 1;
		private const int conDlblLEmpFullName = 14;
		private const int conDlblAEmpFullName = 16;
		private clsToolbar oThisFormToolBar = null;

		private string mTimeStamp = "";
		private int mThisFormID = 0;
		private int mSearchValue = 0;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

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
		public int SearchValue
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


		private void cmdPullMasterData_Click(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			SqlDataReader rsLocal = null;
			object mReturnValue = null;

			lblsalary.Text = "";
			lblDesignation.Text = "";

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				mysql = " select pemp.visa_no, pemp.emp_no";
				mysql = mysql + " , pemp.l_first_name, pemp.l_second_name, pemp.l_third_name, pemp.l_fourth_name , pemp.l_fifth_name";
				mysql = mysql + " , pemp.a_first_name, pemp.a_second_name, pemp.a_third_name, pemp.a_fourth_name , pemp.a_fifth_name";
				mysql = mysql + " , pemp.l_father_name,pemp.a_father_name, pemp.l_mother_name,pemp.a_mother_name";
				mysql = mysql + " , pnat.nat_no, pnat.l_nat_name, pnat.a_nat_name , pemp.visa_type , pspon.Sponsor_No ";
				mysql = mysql + " , pspon.l_first_Name + pspon.l_second_Name + pspon.l_third_name + pspon.l_fourth_name as spon_name";
				mysql = mysql + " , pvisa.l_visa_type_no, pvisa.l_visa_type_name";
				mysql = mysql + " , (select A_Object_Caption from SM_Objects so where so.object_id = pemp.sex_id) as gender";
				mysql = mysql + " , pemp.place_of_birth, pemp.date_of_birth";
				mysql = mysql + " , (select a_religion_name from pay_religion pr where pr.Religion_Cd = pemp.religion_cd) as religion_name";
				mysql = mysql + " , (select A_Object_Caption from SM_Objects so where so.object_id = pemp.marital_status_id) as marital_status";
				mysql = mysql + " , (select a_qalfn_name from pay_qualification pq where pq.qalfn_Cd = pemp.religion_cd) as qalfn_name";
				mysql = mysql + " , (select a_desg_name from pay_designation pd where pd.desg_Cd = pemp.desg_cd) as desg_name";
				mysql = mysql + " , pemp.blood_group, pemp.Passport_No , pdd.issue_date, pdd.expiry_date, pemp.civil_id, pemp.entrance , pemp.Permanent_Phone";
				mysql = mysql + " , pdd1.issue_date as cissuedate , pdd1.expiry_date as cexpirydate";
				mysql = mysql + " , pemp.area, pemp.block, pemp.street, pemp.lane, pemp.type_of_building,pemp.Permanent_Addr_1";
				mysql = mysql + " , pemp.Permanent_Addr_2,pemp.Permanent_Addr_3,pemp.Permanent_Addr_4";
				mysql = mysql + " , pemp.building_no, pemp.qasima, pemp.floor, pemp.flat_no, pemp.po_box, pemp.zip_cd , pemp.total_salary";
				mysql = mysql + " , pemp.phone,pemp.pager, pemp.mobile, pemp.Fax, pemp.email, pemp.comments, pemp.user_cd , pemp.Work_Permit_No";
				mysql = mysql + " from pay_employee pemp";
				mysql = mysql + " left outer join pay_document_detail pdd on pemp.Passport_No = pdd.Document_No";
				mysql = mysql + " left outer join pay_document_detail pdd1 on pemp.civil_id = pdd1.Document_No";
				mysql = mysql + " left outer join pay_nationality pnat on pemp.nat_cd = pnat.nat_cd ";
				mysql = mysql + " left outer join pay_sponsor pspon on pemp.sponsor_cd = pspon.sponsor_cd";
				mysql = mysql + " left outer join pay_visa_type pvisa on pemp.visa_type = pvisa.visa_type_cd";
				mysql = mysql + " where pemp.emp_cd = " + ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempSearchValue).GetValue(0)).ToString();
				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocal = sqlCommand.ExecuteReader();
				rsLocal.Read();
				do 
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select emp_no from pay_employee_wazara_details where emp_no = '" + Convert.ToString(rsLocal["emp_no"]) + "'"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("This employee information is already pulled.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					txtCommonTextBox[conTxtEmpCode].Text = Convert.ToString(rsLocal["emp_no"]);
					txtCommonTextBox[conTxtLFirstName].Text = Convert.ToString(rsLocal["l_first_name"]) + "";
					txtCommonTextBox[conTxtLSecondName].Text = Convert.ToString(rsLocal["l_second_name"]) + "";
					txtCommonTextBox[conTxtLThirdName].Text = Convert.ToString(rsLocal["l_third_name"]) + "";
					txtCommonTextBox[conTxtLFourthName].Text = Convert.ToString(rsLocal["l_fourth_name"]) + "";
					txtCommonTextBox[conTxtFifthName].Text = Convert.ToString(rsLocal["l_fifth_name"]) + "";
					txtCommonTextBox[conTxtAFirstName].Text = Convert.ToString(rsLocal["a_first_name"]) + "";
					txtCommonTextBox[conTxtASecondName].Text = Convert.ToString(rsLocal["a_second_name"]) + "";
					txtCommonTextBox[conTxtAThirdName].Text = Convert.ToString(rsLocal["a_third_name"]) + "";
					txtCommonTextBox[conTxtAFourthName].Text = Convert.ToString(rsLocal["a_fourth_name"]) + "";
					txtCommonTextBox[conTxtAFifthName].Text = Convert.ToString(rsLocal["a_fifth_name"]) + "";
					txtCommonTextBox[conTxtLFatherName].Text = Convert.ToString(rsLocal["l_father_name"]) + "";
					txtCommonTextBox[conTxtAFatherName].Text = Convert.ToString(rsLocal["a_father_name"]) + "";
					txtCommonTextBox[conTxtLMotherName].Text = Convert.ToString(rsLocal["l_mother_name"]) + "";
					txtCommonTextBox[conTxtAMotherName].Text = Convert.ToString(rsLocal["a_mother_name"]) + "";
					txtCommonTextBox[conTxtPlaceOfBirth].Text = Convert.ToString(rsLocal["Place_Of_Birth"]) + "";
					if (!Convert.IsDBNull(rsLocal["date_of_birth"]))
					{
						txtBirthDate.Value = rsLocal["date_of_birth"];
					}
					else
					{
						txtBirthDate.Text = "";
					}
					txtCommonTextBox[conTxtGender].Text = Convert.ToString(rsLocal["gender"]) + "";
					txtCommonTextBox[conTxtReligion].Text = Convert.ToString(rsLocal["religion_name"]) + "";
					txtCommonTextBox[conTxtMaritalStatus].Text = Convert.ToString(rsLocal["marital_status"]);
					txtCommonTextBox[conTxtQualificationName].Text = Convert.ToString(rsLocal["qalfn_name"]) + "";
					txtCommonTextBox[conTxtDesignationName].Text = Convert.ToString(rsLocal["desg_name"]) + "";
					txtCommonTextBox[conTxtNewProfession].Text = Convert.ToString(rsLocal["desg_name"]) + "";
					txtCommonTextBox[conTxtOldProfession].Text = Convert.ToString(rsLocal["desg_name"]) + "";
					lblDesignation.Text = Convert.ToString(rsLocal["desg_name"]) + "";
					lblsalary.Text = Convert.ToString(rsLocal["total_Salary"]);
					txtCommonNumber[conNTxtNewContractSalary].Value = rsLocal["total_Salary"];
					txtCommonNumber[conNTxtOldContractSalary].Value = rsLocal["total_Salary"];
					txtCommonTextBox[conTxtComment].Text = Convert.ToString(rsLocal["comments"]) + "";
					txtCommonTextBox[conTxtBloodGroup].Text = Convert.ToString(rsLocal["Blood_Group"]) + "";
					txtCommonTextBox[conTxtBlock].Text = Convert.ToString(rsLocal["Block"]) + "";
					txtCommonTextBox[conTxtStreet].Text = Convert.ToString(rsLocal["street"]) + "";
					txtCommonTextBox[conTxtLane].Text = Convert.ToString(rsLocal["lane"]) + "";
					txtCommonTextBox[conTxtTypeofBldg].Text = Convert.ToString(rsLocal["type_of_building"]) + "";
					txtCommonTextBox[conTxtBldgNo].Text = Convert.ToString(rsLocal["building_no"]) + "";
					txtCommonTextBox[conTxtQasima].Text = Convert.ToString(rsLocal["Qasima"]) + "";
					txtCommonTextBox[conTxtFloor].Text = Convert.ToString(rsLocal["floor"]) + "";
					txtCommonTextBox[conTxtFlatNo].Text = Convert.ToString(rsLocal["flat_no"]) + "";
					txtCommonTextBox[conTxtPOBox].Text = Convert.ToString(rsLocal["PO_Box"]) + "";
					if (Information.IsNumeric(rsLocal["zip_cd"]))
					{
						txtCommonTextBox[conTxtZipCode].Text = Convert.ToString(rsLocal["zip_cd"]);
					}
					else
					{
						txtCommonTextBox[conTxtZipCode].Text = "";
					}
					txtCommonTextBox[conTxtPagerNo].Text = Convert.ToString(rsLocal["Pager"]) + "";
					txtCommonTextBox[conTxtMobileno].Text = Convert.ToString(rsLocal["Mobile"]) + "";
					txtCommonTextBox[conTxtTelephoneNo].Text = Convert.ToString(rsLocal["Phone"]) + "";
					txtCommonTextBox[conTxtFax].Text = Convert.ToString(rsLocal["Fax"]) + "";
					txtCommonTextBox[conTxtEmailAddress].Text = Convert.ToString(rsLocal["Email"]) + "";
					txtCommonTextBox[conTxtTelephoneNo2].Text = Convert.ToString(rsLocal["Permanent_Phone"]) + "";
					txtCommonTextBox[conTxtAddress1].Text = Convert.ToString(rsLocal["Permanent_Addr_1"]) + "";
					txtCommonTextBox[conTxtAddress2].Text = Convert.ToString(rsLocal["Permanent_Addr_2"]) + "";
					txtCommonTextBox[conTxtAddress3].Text = Convert.ToString(rsLocal["Permanent_Addr_3"]) + "";
					txtCommonTextBox[conTxtAddress4].Text = Convert.ToString(rsLocal["Permanent_Addr_4"]) + "";
					txtCommonTextBox[conTxtCivilId].Text = Convert.ToString(rsLocal["Civil_Id"]) + "";
					txtCommonTextBox[conTxtPassportNo].Text = Convert.ToString(rsLocal["Passport_No"]) + "";
					txtCommonTextBox[conTxtWorkPermitNo].Text = Convert.ToString(rsLocal["Work_Permit_No"]) + "";
					txtCommonTextBox[conTxtVisaNo].Text = Convert.ToString(rsLocal["Visa_No"]) + "";
					txtCommonTextBox[conTxtArea].Text = Convert.ToString(rsLocal["area"]) + "";
					txtCommonTextBox[conTxtEntrance].Text = Convert.ToString(rsLocal["entrance"]) + "";

					if (!Convert.IsDBNull(rsLocal["expiry_date"]))
					{
						txtPassExpiryDate.Value = Convert.ToDateTime(rsLocal["expiry_date"]).ToString("dd/MMM/yyyy");
					}
					else
					{
						txtPassExpiryDate.Text = "";
					}
					if (!Convert.IsDBNull(rsLocal["issue_date"]))
					{
						txtPassIssueDate.Value = Convert.ToDateTime(rsLocal["issue_date"]).ToString("dd/MMM/yyyy");
					}
					else
					{
						txtPassIssueDate.Text = "";
					}

					if (!Convert.IsDBNull(rsLocal["cexpirydate"]))
					{
						txtDCivilExpiryDate.Value = Convert.ToDateTime(rsLocal["cexpirydate"]).ToString("dd/MMM/yyyy");
					}
					else
					{
						txtDCivilExpiryDate.Text = "";
					}
					if (!Convert.IsDBNull(rsLocal["cissuedate"]))
					{
						txtDCivilIssueDate.Value = Convert.ToDateTime(rsLocal["cissuedate"]).ToString("dd/MMM/yyyy");
					}
					else
					{
						txtDCivilIssueDate.Text = "";
					}

					if (!Convert.IsDBNull(rsLocal["nat_no"]))
					{
						txtCommonTextBox[conTxtNatCode].Text = Convert.ToString(rsLocal["nat_no"]);
						txtDisplayLabel[conDlblNatName].Text = Convert.ToString(rsLocal["l_nat_name"]) + "";
						txtPassNat.Text = Convert.ToString(rsLocal["a_nat_name"]) + "";
					}
					if (!Convert.IsDBNull(rsLocal["Sponsor_No"]))
					{
						txtCommonTextBox[conTxtSponsorCode].Text = Convert.ToString(rsLocal["Sponsor_No"]);
						txtDisplayLabel[conDlblSponsorName].Text = Convert.ToString(rsLocal["spon_name"]) + "";
					}
					if (!Convert.IsDBNull(rsLocal["l_visa_type_no"]))
					{
						txtCommonTextBox[conTxtVisaType].Text = Convert.ToString(rsLocal["l_visa_type_no"]);
						txtDisplayLabel[conDlblVisaTypeName].Text = Convert.ToString(rsLocal["l_visa_type_name"]) + "";
					}
				}
				while(rsLocal.Read());
			}
		}

		private void cmdRenewal_Click(Object eventSender, EventArgs eventArgs)
		{
			string mEntryId = "";

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode && !SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				mEntryId = txtCommonTextBox[conTxtEmpCode].Text;
			}
			else
			{
				return;
			}

			SystemReports.GetCrystalReport(110013600, 2, "7958", mEntryId, false);
			SystemReports.GetCrystalReport(110013400, 2, "7864", mEntryId, false);

		}

		private void cmdTransfer_Click(Object eventSender, EventArgs eventArgs)
		{
			string mEntryId = "";

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode && !SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				mEntryId = txtCommonTextBox[conTxtEmpCode].Text;
			}
			else
			{
				return;
			}

			SystemReports.GetCrystalReport(110013500, 2, "7898", mEntryId, false);
		}

		private void cmdContract_Click(Object eventSender, EventArgs eventArgs)
		{
			string mEntryId = "";

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode && !SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				mEntryId = txtCommonTextBox[conTxtEmpCode].Text;
			}
			else
			{
				return;
			}

			SystemReports.GetCrystalReport(110013556, 2, "8629", mEntryId, false);
		}

		private void cmdVisaApplication_Click(Object eventSender, EventArgs eventArgs)
		{
			string mEntryId = "";

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode && !SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				mEntryId = txtCommonTextBox[conTxtEmpCode].Text;
			}
			else
			{
				return;
			}

			SystemReports.GetCrystalReport(110013600, 2, "7958", mEntryId, false);
			SystemReports.GetCrystalReport(110013400, 2, "7864", mEntryId, false);
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

				if (Shift == 4 && (KeyCode == 37 || KeyCode == 39))
				{
					if (!UserAccess.AllowUserDisplay)
					{
						MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					// Call RecordNavidate(KeyCode, mRecordNavigateSearchValue)
					KeyCode = 0;
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


		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);
			tabEmployee.CurrTab = Convert.ToInt16(conTabPersonnelBasic);
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = 0; //Change the msearchvalue to blank
			FirstFocusObject.Focus();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool deleteRecord()
		{
			string mysql = "";
			try
			{

				if (!SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
				{
					mysql = " delete from pay_employee_wazara_details ";
					mysql = mysql + " where Line_No = " + mSearchValue.ToString();
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					MessageBox.Show("Please select valid record.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				return true;
			}
			catch
			{
				MessageBox.Show("Please try later!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			return false;
		}

		public bool saveRecord()
		{
			bool result = false;
			try
			{
				object mReturnValue = null;
				string mysql = "";
				int mNatCode = 0;
				int mSponsorCode = 0;
				int mVisaCode = 0;
				int mGovernateCd = 0;

				//Governerate code
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
						throw new Exception();
					}
				}
				else
				{
					MessageBox.Show("Invalid Governate Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					tabEmployee.CurrTab = Convert.ToInt16(conTabPersonnelBasic);
					txtCommonTextBox[conTxtGovernateCd].Focus();
					return result;
				}

				//sponsor Query
				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtSponsorCode].Text, SystemVariables.DataType.StringType))
				{
					mysql = "select Sponsor_cd from pay_Sponsor ";
					mysql = mysql + " where sponsor_no = " + txtCommonTextBox[conTxtSponsorCode].Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Sponsor Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabEmployee.CurrTab = Convert.ToInt16(conTabPersonnelOthers);
						tabEmployee.CurrTab = Convert.ToInt16(conTabPersonnelBasic);
						throw new Exception();
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mSponsorCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				else
				{
					MessageBox.Show("Invalid Sponsor Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					tabEmployee.CurrTab = Convert.ToInt16(conTabPersonnelBasic);
					txtCommonTextBox[conTxtSponsorCode].Focus();
					return result;
				}

				//'Visa Type Query
				if (Information.IsNumeric(txtCommonTextBox[conTxtVisaType].Text))
				{
					mysql = "select Visa_Type_cd from Pay_Visa_type ";
					mysql = mysql + " where L_Visa_Type_no = " + txtCommonTextBox[conTxtVisaType].Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Visa Type Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabEmployee.CurrTab = Convert.ToInt16(conTabPersonnelBasic);
						txtCommonTextBox[conTxtVisaType].Focus();
						throw new Exception();
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mVisaCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				else
				{
					MessageBox.Show("Invalid Visa Type Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					tabEmployee.CurrTab = Convert.ToInt16(conTabPersonnelBasic);
					txtCommonTextBox[conTxtVisaType].Focus();
					return result;
				}
				//Nationality COde
				if (Information.IsNumeric(txtCommonTextBox[conTxtNatCode].Text))
				{
					mysql = " select nat_cd from pay_nationality ";
					mysql = mysql + " where nat_no = " + txtCommonTextBox[conTxtNatCode].Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Nationality Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabEmployee.CurrTab = Convert.ToInt16(conTabPersonnelBasic);
						txtCommonTextBox[conTxtNatCode].Focus();
						throw new Exception();
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mNatCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				else
				{
					MessageBox.Show("Invalid Nationality Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					tabEmployee.CurrTab = Convert.ToInt16(conTabPersonnelBasic);
					txtCommonTextBox[conTxtNatCode].Focus();
					return result;
				}

				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into pay_employee_wazara_details (emp_no ";
					mysql = mysql + " , l_first_name, l_second_name, l_third_name, l_fourth_name , l_fifth_name";
					mysql = mysql + " , a_first_name, a_second_name, a_third_name, a_fourth_name , a_fifth_name";
					mysql = mysql + " , l_father_name, a_father_name, l_mother_name, a_mother_name ";
					mysql = mysql + " , place_of_birth, Designation_Name, Qualification, Previous_Sponsor_Name, Previous_Company_Name";
					mysql = mysql + " , Gender, religion, governate_cd, visa_type_cd, sponsor_cd, nat_cd, date_of_birth";
					mysql = mysql + " , blood_group, block, street, lane, type_of_building, building_no, qasima";
					mysql = mysql + " , floor, flat_no, po_box, zip_cd, phone, fax, email, pager, mobile , permanent_phone";
					mysql = mysql + " , permanent_addr_1, permanent_addr_2, permanent_addr_3, permanent_addr_4";
					mysql = mysql + " , civil_id, passport_no, work_permit_no, visa_no, Residence_No";
					mysql = mysql + " , area, entrance,comments, user_cd, issue_date, expiry_date";
					mysql = mysql + " , authorized_signature,current_file_no,current_contract_no,current_license_no ";
					mysql = mysql + " , old_file_no,old_contract_no,old_license_no,previous_residency_period";
					mysql = mysql + " , current_residency_period,old_contract_salary,new_contract_salary,new_profesion, entry_date,CivilId_Issue_Date,CivilId_Expiry_Date";
					mysql = mysql + " , TypeOfPassport,PlaceOfPassport,NationalityOfPassport,marital_status, Old_Profession";
					mysql = mysql + ")";
					mysql = mysql + " values (";
					mysql = mysql + " '" + txtCommonTextBox[conTxtEmpCode].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtLFirstName].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtLSecondName].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtLThirdName].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtLFourthName].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtFifthName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAFirstName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtASecondName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAThirdName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAFourthName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAFifthName].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtLFatherName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAFatherName].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtLMotherName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAMotherName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtPlaceOfBirth].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtDesignationName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtQualificationName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtPreviousSponsor].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtPreviousCompanyName].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtGender].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtReligion].Text + "'";
					mysql = mysql + " , " + mGovernateCd.ToString() + ", " + mVisaCode.ToString() + ", " + mSponsorCode.ToString() + ", " + mNatCode.ToString();
					if (!Information.IsDate(txtBirthDate.DisplayText))
					{
						mysql = mysql + " , NULL ";
					}
					else
					{
						mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtBirthDate.DisplayText) + "'";
					}
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtBloodGroup].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtBlock].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtStreet].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtLane].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtTypeofBldg].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtBldgNo].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtQasima].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtFloor].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtFlatNo].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtPOBox].Text + "'";
					if (Information.IsNumeric(txtCommonTextBox[conTxtZipCode].Text))
					{
						mysql = mysql + " ," + txtCommonTextBox[conTxtZipCode].Text;
					}
					else
					{
						mysql = mysql + " ,NULL ";
					}
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtTelephoneNo].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtFax].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtEmailAddress].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtPagerNo].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtMobileno].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtTelephoneNo2].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAddress1].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAddress2].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAddress3].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtAddress4].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtCivilId].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtPassportNo].Text + "'";
					mysql = mysql + " ,'" + txtCommonTextBox[conTxtWorkPermitNo].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtVisaNo].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtResidanceNo].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtArea].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtEntrance].Text + "'";
					mysql = mysql + " ,N'" + txtCommonTextBox[conTxtComment].Text + "'";
					mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
					if (!Information.IsDate(txtPassIssueDate.DisplayText))
					{
						mysql = mysql + " , NULL ";
					}
					else
					{
						mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtPassIssueDate.DisplayText) + "'";
					}
					if (!Information.IsDate(txtPassExpiryDate.DisplayText))
					{
						mysql = mysql + " , NULL ";
					}
					else
					{
						mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtPassExpiryDate.DisplayText) + "'";
					}
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtAuthorizedSig].Text + "'";
					mysql = mysql + " , '" + txtCommonTextBox[conTxtNewFileNo].Text + "'";
					mysql = mysql + " , '" + txtCommonTextBox[conTxtNewContractNo].Text + "'";
					mysql = mysql + " , '" + txtCommonTextBox[conTxtNewLicenseNo].Text + "'";
					mysql = mysql + " , '" + txtCommonTextBox[conTxtOldFileNo].Text + "'";
					mysql = mysql + " , '" + txtCommonTextBox[conTxtOldContractNo].Text + "'";
					mysql = mysql + " , '" + txtCommonTextBox[conTxtOldLicenseNo].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtOldContractPeriod].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtNewContractPeriod].Text + "'";
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtOldContractSalary].Value);
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtNewContractSalary].Value);
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtNewProfession].Text + "'";
					if (!Information.IsDate(txtDEntryDate.DisplayText))
					{
						mysql = mysql + " , NULL ";
					}
					else
					{
						mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtDEntryDate.DisplayText) + "'";
					}
					if (!Information.IsDate(txtDCivilIssueDate.DisplayText))
					{
						mysql = mysql + " , NULL ";
					}
					else
					{
						mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtDCivilIssueDate.DisplayText) + "'";
					}
					if (!Information.IsDate(txtDCivilExpiryDate.DisplayText))
					{
						mysql = mysql + " , NULL ";
					}
					else
					{
						mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtDCivilExpiryDate.DisplayText) + "'";
					}
					mysql = mysql + " , N'" + txtTypeofPassport.Text + "'";
					mysql = mysql + " , N'" + txtPlaceofIssue.Text + "'";
					mysql = mysql + " , N'" + txtPassNat.Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtMaritalStatus].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtOldProfession].Text + "'";
					mysql = mysql + " ) ";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					mysql = " select time_stamp from pay_employee_wazara_details where line_no =" + mSearchValue.ToString();
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
					mysql = "Update pay_employee_wazara_details set ";
					mysql = mysql + "  emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
					mysql = mysql + " , l_first_name ='" + txtCommonTextBox[conTxtLFirstName].Text + "'";
					mysql = mysql + " , l_second_name ='" + txtCommonTextBox[conTxtLSecondName].Text + "'";
					mysql = mysql + " , l_third_name ='" + txtCommonTextBox[conTxtLThirdName].Text + "'";
					mysql = mysql + " , l_fourth_name ='" + txtCommonTextBox[conTxtLFourthName].Text + "'";
					mysql = mysql + " , l_fifth_name ='" + txtCommonTextBox[conTxtFifthName].Text + "'";
					mysql = mysql + " , a_first_name =N'" + txtCommonTextBox[conTxtAFirstName].Text + "'";
					mysql = mysql + " , a_second_name =N'" + txtCommonTextBox[conTxtASecondName].Text + "'";
					mysql = mysql + " , a_third_name =N'" + txtCommonTextBox[conTxtAThirdName].Text + "'";
					mysql = mysql + " , a_fourth_name =N'" + txtCommonTextBox[conTxtAFourthName].Text + "'";
					mysql = mysql + " , a_fifth_name =N'" + txtCommonTextBox[conTxtAFifthName].Text + "'";
					mysql = mysql + " , l_father_name ='" + txtCommonTextBox[conTxtLFatherName].Text + "'";
					mysql = mysql + " , a_father_name = N'" + txtCommonTextBox[conTxtAFatherName].Text + "'";
					mysql = mysql + " , l_mother_name ='" + txtCommonTextBox[conTxtLMotherName].Text + "'";
					mysql = mysql + " , a_mother_name = N'" + txtCommonTextBox[conTxtAMotherName].Text + "'";
					mysql = mysql + " , place_of_birth = N'" + txtCommonTextBox[conTxtPlaceOfBirth].Text + "'";
					mysql = mysql + " , Designation_Name = N'" + txtCommonTextBox[conTxtDesignationName].Text + "'";
					mysql = mysql + " , qualification = N'" + txtCommonTextBox[conTxtQualificationName].Text + "'";
					mysql = mysql + " , previous_sponsor_name = N'" + txtCommonTextBox[conTxtPreviousSponsor].Text + "'";
					mysql = mysql + " , previous_company_name = N'" + txtCommonTextBox[conTxtPreviousCompanyName].Text + "'";
					mysql = mysql + " , blood_group ='" + txtCommonTextBox[conTxtBloodGroup].Text + "'";
					mysql = mysql + " , gender =N'" + txtCommonTextBox[conTxtGender].Text + "'";
					mysql = mysql + " , religion =N'" + txtCommonTextBox[conTxtReligion].Text + "'";
					mysql = mysql + " , marital_status =N'" + txtCommonTextBox[conTxtMaritalStatus].Text + "'";
					mysql = mysql + " , governate_cd =" + mGovernateCd.ToString();
					mysql = mysql + " , visa_type_cd =" + mVisaCode.ToString();
					mysql = mysql + " , sponsor_cd =" + mSponsorCode.ToString();
					mysql = mysql + " , nat_cd  =" + mNatCode.ToString();
					if (Information.IsNumeric(txtCommonTextBox[conTxtZipCode].Text))
					{
						mysql = mysql + " , zip_cd = " + txtCommonTextBox[conTxtZipCode].Text;
					}
					else
					{
						mysql = mysql + " , zip_cd = NULL ";
					}
					if (!Information.IsDate(txtBirthDate.DisplayText))
					{
						mysql = mysql + " , date_of_birth  = NULL ";
					}
					else
					{
						mysql = mysql + " , date_of_birth  ='" + ReflectionHelper.GetPrimitiveValue<string>(txtBirthDate.DisplayText) + "'";
					}
					mysql = mysql + " , area= N'" + txtCommonTextBox[conTxtArea].Text + "'";
					mysql = mysql + " , block = N'" + txtCommonTextBox[conTxtBlock].Text + "'";
					mysql = mysql + " , street = N'" + txtCommonTextBox[conTxtStreet].Text + "'";
					mysql = mysql + " , lane = N'" + txtCommonTextBox[conTxtLane].Text + "'";
					mysql = mysql + " , type_of_building = N'" + txtCommonTextBox[conTxtTypeofBldg].Text + "'";
					mysql = mysql + " , building_no = N'" + txtCommonTextBox[conTxtBldgNo].Text + "'";
					mysql = mysql + " , qasima = N'" + txtCommonTextBox[conTxtQasima].Text + "'";
					mysql = mysql + " , floor = N'" + txtCommonTextBox[conTxtFloor].Text + "'";
					mysql = mysql + " , flat_no = N'" + txtCommonTextBox[conTxtFlatNo].Text + "'";
					mysql = mysql + " , po_box = N'" + txtCommonTextBox[conTxtPOBox].Text + "'";
					mysql = mysql + " , phone = '" + txtCommonTextBox[conTxtTelephoneNo].Text + "'";
					mysql = mysql + " , fax = '" + txtCommonTextBox[conTxtFax].Text + "'";
					mysql = mysql + " , email = '" + txtCommonTextBox[conTxtEmailAddress].Text + "'";
					mysql = mysql + " , mobile = '" + txtCommonTextBox[conTxtMobileno].Text + "'";
					mysql = mysql + " , permanent_addr_1 = N'" + txtCommonTextBox[conTxtAddress1].Text + "'";
					mysql = mysql + " , permanent_addr_2 = N'" + txtCommonTextBox[conTxtAddress2].Text + "'";
					mysql = mysql + " , permanent_addr_3 = N'" + txtCommonTextBox[conTxtAddress3].Text + "'";
					mysql = mysql + " , permanent_addr_4 = N'" + txtCommonTextBox[conTxtAddress4].Text + "'";
					mysql = mysql + " , permanent_phone = N'" + txtCommonTextBox[conTxtTelephoneNo2].Text + "'";
					mysql = mysql + " , civil_id = '" + txtCommonTextBox[conTxtCivilId].Text + "'";
					mysql = mysql + " , passport_no = '" + txtCommonTextBox[conTxtPassportNo].Text + "'";
					mysql = mysql + " , work_permit_no = '" + txtCommonTextBox[conTxtWorkPermitNo].Text + "'";
					mysql = mysql + " , visa_no = N'" + txtCommonTextBox[conTxtVisaNo].Text + "'";
					mysql = mysql + " , pager = N'" + txtCommonTextBox[conTxtPagerNo].Text + "'";
					mysql = mysql + " , entrance = N'" + txtCommonTextBox[conTxtEntrance].Text + "'";
					mysql = mysql + " , comments = N'" + txtCommonTextBox[conTxtComment].Text + "'";
					if (!Information.IsDate(txtPassIssueDate.DisplayText))
					{
						mysql = mysql + " , issue_date = NULL ";
					}
					else
					{
						mysql = mysql + " , issue_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtPassIssueDate.DisplayText) + "'";
					}
					if (!Information.IsDate(txtPassExpiryDate.DisplayText))
					{
						mysql = mysql + " , expiry_date = NULL ";
					}
					else
					{
						mysql = mysql + " , expiry_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtPassExpiryDate.DisplayText) + "'";
					}
					if (!Information.IsDate(txtDEntryDate.DisplayText))
					{
						mysql = mysql + " , Entry_Date = NULL ";
					}
					else
					{
						mysql = mysql + " , Entry_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtDEntryDate.DisplayText) + "'";
					}
					if (!Information.IsDate(txtDCivilIssueDate.DisplayText))
					{
						mysql = mysql + " ,CivilId_Issue_Date = NULL ";
					}
					else
					{
						mysql = mysql + " , CivilId_Issue_Date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtDCivilIssueDate.DisplayText) + "'";
					}
					if (!Information.IsDate(txtDCivilExpiryDate.DisplayText))
					{
						mysql = mysql + " , CivilId_Expiry_Date = NULL ";
					}
					else
					{
						mysql = mysql + " ,CivilId_Expiry_Date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtDCivilExpiryDate.DisplayText) + "'";
					}
					mysql = mysql + " , TypeOfPassport = N'" + txtTypeofPassport.Text + "'";
					mysql = mysql + " , PlaceOfPassport = N'" + txtPlaceofIssue.Text + "'";
					mysql = mysql + " , NationalityOfPassport = N'" + txtPassNat.Text + "'";
					mysql = mysql + " , authorized_signature = N'" + txtCommonTextBox[conTxtAuthorizedSig].Text + "'";
					mysql = mysql + " , current_file_no = '" + txtCommonTextBox[conTxtNewFileNo].Text + "'";
					mysql = mysql + " , current_contract_no = '" + txtCommonTextBox[conTxtNewContractNo].Text + "'";
					mysql = mysql + " , current_license_no = '" + txtCommonTextBox[conTxtNewLicenseNo].Text + "'";
					mysql = mysql + " , old_file_no = '" + txtCommonTextBox[conTxtOldFileNo].Text + "'";
					mysql = mysql + " , old_contract_no = '" + txtCommonTextBox[conTxtOldContractNo].Text + "'";
					mysql = mysql + " , old_license_no = '" + txtCommonTextBox[conTxtOldLicenseNo].Text + "'";
					mysql = mysql + " , previous_residency_period = N'" + txtCommonTextBox[conTxtOldContractPeriod].Text + "'";
					mysql = mysql + " , current_residency_period =  N'" + txtCommonTextBox[conTxtNewContractPeriod].Text + "'";
					mysql = mysql + " , old_contract_salary = " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtOldContractSalary].Value);
					mysql = mysql + " , new_contract_salary = " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtNewContractSalary].Value);
					mysql = mysql + " , new_profesion = N'" + txtCommonTextBox[conTxtNewProfession].Text + "'";
					mysql = mysql + " , old_profession = N'" + txtCommonTextBox[conTxtOldProfession].Text + "'";
					mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where line_no = " + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtCivilId].Text, SystemVariables.DataType.StringType))
					{
						if (Information.IsDate(txtDCivilExpiryDate.Value))
						{
							mysql = " update pay_Document_Detail";
							mysql = mysql + " set expiry_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtDCivilExpiryDate.Value) + "'";
							mysql = mysql + " , issue_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtDCivilIssueDate.Value) + "'";
							mysql = mysql + " where  document_No = '" + txtCommonTextBox[conTxtCivilId].Text + "'";
							SqlCommand TempCommand_3 = null;
							TempCommand_3 = SystemVariables.gConn.CreateCommand();
							TempCommand_3.CommandText = mysql;
							TempCommand_3.ExecuteNonQuery();
						}
					}
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtPassportNo].Text, SystemVariables.DataType.StringType))
					{
						if (Information.IsDate(txtDCivilExpiryDate.Value))
						{
							mysql = " update pay_Document_Detail";
							mysql = mysql + " set expiry_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtPassExpiryDate.Value) + "'";
							mysql = mysql + " , issue_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtPassIssueDate.Value) + "'";
							mysql = mysql + " where  document_No = '" + txtCommonTextBox[conTxtPassportNo].Text + "'";
							SqlCommand TempCommand_4 = null;
							TempCommand_4 = SystemVariables.gConn.CreateCommand();
							TempCommand_4.CommandText = mysql;
							TempCommand_4.ExecuteNonQuery();
						}
					}
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, "Employee Wazara Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return result;
		}


		public void findRecord()
		{
			//Call the find window
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220585));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				mSearchValue = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		public void GetRecord(int pSearchValue)
		{
			object mReturnValue = null;

			string mysql = " select pewd.* ,pn.nat_no, ps.sponsor_no, pg.governate_no, pvt.l_visa_type_no";
			mysql = mysql + " from pay_employee_wazara_details pewd";
			mysql = mysql + " inner join pay_nationality pn on pn.nat_cd = pewd.nat_cd";
			mysql = mysql + " inner join pay_sponsor ps on ps.sponsor_cd = pewd.sponsor_cd";
			mysql = mysql + " inner join pay_governate pg on pg.governate_cd = pewd.governate_Cd";
			mysql = mysql + " inner join pay_visa_type pvt on pvt.visa_type_cd = pewd.visa_type_cd";
			mysql = mysql + " where pewd.line_no =" + pSearchValue.ToString();

			SqlDataReader rsLocal = null;

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocal = sqlCommand.ExecuteReader();
			rsLocal.Read();
			do 
			{
				mysql = "select total_salary , pdesg.a_desg_name  from pay_employee pemp inner join pay_designation pdesg on pdesg.desg_cd = pemp.desg_cd ";
				mysql = mysql + " where emp_no = '" + Convert.ToString(rsLocal["emp_no"]) + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					lblsalary.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)) + "";
					lblDesignation.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1)) + "";

					if (((Array) mReturnValue).GetValue(0) != rsLocal["new_contract_salary"])
					{
						lblsalary.ForeColor = Color.Red;
					}
					else
					{
						lblsalary.ForeColor = Color.Black;
					}

					if (((Array) mReturnValue).GetValue(1) != rsLocal["new_profesion"])
					{
						lblDesignation.ForeColor = Color.Red;
					}
					else
					{
						lblDesignation.ForeColor = Color.Black;
					}
				}

				txtCommonTextBox[conTxtEmpCode].Text = Convert.ToString(rsLocal["emp_no"]);
				txtCommonTextBox[conTxtLFirstName].Text = Convert.ToString(rsLocal["l_first_name"]);
				txtCommonTextBox[conTxtLSecondName].Text = Convert.ToString(rsLocal["l_second_name"]) + "";
				txtCommonTextBox[conTxtLThirdName].Text = Convert.ToString(rsLocal["l_third_name"]) + "";
				txtCommonTextBox[conTxtLFourthName].Text = Convert.ToString(rsLocal["l_fourth_name"]) + "";
				txtCommonTextBox[conTxtFifthName].Text = Convert.ToString(rsLocal["l_fifth_name"]) + "";
				txtCommonTextBox[conTxtAFirstName].Text = Convert.ToString(rsLocal["a_first_name"]) + "";
				txtCommonTextBox[conTxtASecondName].Text = Convert.ToString(rsLocal["a_second_name"]) + "";
				txtCommonTextBox[conTxtAThirdName].Text = Convert.ToString(rsLocal["a_third_name"]) + "";
				txtCommonTextBox[conTxtAFourthName].Text = Convert.ToString(rsLocal["a_fourth_name"]) + "";
				txtCommonTextBox[conTxtAFifthName].Text = Convert.ToString(rsLocal["a_fifth_name"]) + "";
				txtCommonTextBox[conTxtLFatherName].Text = Convert.ToString(rsLocal["l_father_name"]) + "";
				txtCommonTextBox[conTxtAFatherName].Text = Convert.ToString(rsLocal["a_father_name"]) + "";
				txtCommonTextBox[conTxtLMotherName].Text = Convert.ToString(rsLocal["l_mother_name"]) + "";
				txtCommonTextBox[conTxtAMotherName].Text = Convert.ToString(rsLocal["a_mother_name"]) + "";
				txtCommonTextBox[conTxtPlaceOfBirth].Text = Convert.ToString(rsLocal["Place_Of_Birth"]) + "";
				txtCommonTextBox[conTxtDesignationName].Text = Convert.ToString(rsLocal["Designation_Name"]) + "";
				txtCommonTextBox[conTxtQualificationName].Text = Convert.ToString(rsLocal["Qualification"]) + "";
				txtCommonTextBox[conTxtPreviousSponsor].Text = Convert.ToString(rsLocal["Previous_Sponsor_Name"]) + "";
				txtCommonTextBox[conTxtPreviousCompanyName].Text = Convert.ToString(rsLocal["Previous_Company_Name"]) + "";
				txtCommonTextBox[conTxtGender].Text = Convert.ToString(rsLocal["gender"]) + "";
				txtCommonTextBox[conTxtReligion].Text = Convert.ToString(rsLocal["religion"]) + "";
				txtCommonTextBox[conTxtMaritalStatus].Text = Convert.ToString(rsLocal["marital_status"]) + "";
				txtCommonTextBox[conTxtNatCode].Text = Convert.ToString(rsLocal["nat_no"]) + "";
				txtCommonTextBox[conTxtSponsorCode].Text = Convert.ToString(rsLocal["sponsor_no"]);
				txtCommonTextBox[conTxtVisaType].Text = Convert.ToString(rsLocal["l_visa_type_no"]);
				txtCommonTextBox[conTxtGovernateCd].Text = Convert.ToString(rsLocal["governate_no"]);
				txtCommonTextBox[conTxtComment].Text = Convert.ToString(rsLocal["comments"]) + "";
				txtCommonTextBox[conTxtBloodGroup].Text = Convert.ToString(rsLocal["Blood_Group"]) + "";
				txtCommonTextBox[conTxtBlock].Text = Convert.ToString(rsLocal["Block"]) + "";
				txtCommonTextBox[conTxtStreet].Text = Convert.ToString(rsLocal["street"]) + "";
				txtCommonTextBox[conTxtLane].Text = Convert.ToString(rsLocal["lane"]) + "";
				txtCommonTextBox[conTxtTypeofBldg].Text = Convert.ToString(rsLocal["type_of_building"]) + "";
				txtCommonTextBox[conTxtBldgNo].Text = Convert.ToString(rsLocal["building_no"]) + "";
				txtCommonTextBox[conTxtQasima].Text = Convert.ToString(rsLocal["Qasima"]) + "";
				txtCommonTextBox[conTxtFloor].Text = Convert.ToString(rsLocal["floor"]) + "";
				txtCommonTextBox[conTxtFlatNo].Text = Convert.ToString(rsLocal["flat_no"]) + "";
				txtCommonTextBox[conTxtPOBox].Text = Convert.ToString(rsLocal["PO_Box"]) + "";
				txtDisplayLabel[conDlblLEmpFullName].Text = Convert.ToString(rsLocal["l_full_name"]) + "";
				txtDisplayLabel[conDlblAEmpFullName].Text = Convert.ToString(rsLocal["a_full_name"]) + "";
				if (Information.IsNumeric(rsLocal["zip_cd"]))
				{
					txtCommonTextBox[conTxtZipCode].Text = Convert.ToString(rsLocal["zip_cd"]);
				}
				else
				{
					txtCommonTextBox[conTxtZipCode].Text = "";
				}
				if (!Convert.IsDBNull(rsLocal["date_of_birth"]))
				{
					txtBirthDate.Value = rsLocal["date_of_birth"];
				}
				else
				{
					txtBirthDate.Text = "";
				}
				if (!Convert.IsDBNull(rsLocal["issue_date"]))
				{
					txtPassIssueDate.Value = rsLocal["issue_date"];
				}
				else
				{
					txtPassIssueDate.Text = "";
				}
				if (!Convert.IsDBNull(rsLocal["Expiry_Date"]))
				{
					txtPassExpiryDate.Value = rsLocal["Expiry_Date"];
				}
				else
				{
					txtPassExpiryDate.Text = "";
				}
				if (!Convert.IsDBNull(rsLocal["CivilId_Issue_Date"]))
				{
					txtDCivilIssueDate.Value = rsLocal["CivilId_Issue_Date"];
				}
				else
				{
					txtDCivilIssueDate.Text = "";
				}
				if (!Convert.IsDBNull(rsLocal["CivilId_Expiry_Date"]))
				{
					txtDCivilExpiryDate.Value = rsLocal["CivilId_Expiry_Date"];
				}
				else
				{
					txtDCivilExpiryDate.Text = "";
				}
				if (!Convert.IsDBNull(rsLocal["Entry_Date"]))
				{
					txtDEntryDate.Value = rsLocal["Entry_Date"];
				}
				else
				{
					txtDEntryDate.Text = "";
				}
				txtPassNat.Text = Convert.ToString(rsLocal["NationalityOfPassport"]) + "";
				txtPlaceofIssue.Text = Convert.ToString(rsLocal["PlaceOfPassport"]) + "";
				txtTypeofPassport.Text = Convert.ToString(rsLocal["TypeOfPassport"]) + "";
				txtCommonTextBox[conTxtPagerNo].Text = Convert.ToString(rsLocal["Pager"]) + "";
				txtCommonTextBox[conTxtMobileno].Text = Convert.ToString(rsLocal["Mobile"]) + "";
				txtCommonTextBox[conTxtTelephoneNo].Text = Convert.ToString(rsLocal["Phone"]) + "";
				txtCommonTextBox[conTxtFax].Text = Convert.ToString(rsLocal["Fax"]) + "";
				txtCommonTextBox[conTxtEmailAddress].Text = Convert.ToString(rsLocal["Email"]) + "";
				txtCommonTextBox[conTxtTelephoneNo2].Text = Convert.ToString(rsLocal["Permanent_Phone"]) + "";
				txtCommonTextBox[conTxtAddress1].Text = Convert.ToString(rsLocal["Permanent_Addr_1"]) + "";
				txtCommonTextBox[conTxtAddress2].Text = Convert.ToString(rsLocal["Permanent_Addr_2"]) + "";
				txtCommonTextBox[conTxtAddress3].Text = Convert.ToString(rsLocal["Permanent_Addr_3"]) + "";
				txtCommonTextBox[conTxtAddress4].Text = Convert.ToString(rsLocal["Permanent_Addr_4"]) + "";
				txtCommonTextBox[conTxtCivilId].Text = Convert.ToString(rsLocal["Civil_Id"]) + "";
				txtCommonTextBox[conTxtPassportNo].Text = Convert.ToString(rsLocal["Passport_No"]) + "";
				txtCommonTextBox[conTxtWorkPermitNo].Text = Convert.ToString(rsLocal["Work_Permit_No"]) + "";
				txtCommonTextBox[conTxtVisaNo].Text = Convert.ToString(rsLocal["Visa_No"]) + "";
				txtCommonTextBox[conTxtResidanceNo].Text = Convert.ToString(rsLocal["Residence_No"]) + "";
				txtCommonTextBox[conTxtArea].Text = Convert.ToString(rsLocal["area"]) + "";
				txtCommonTextBox[conTxtEntrance].Text = Convert.ToString(rsLocal["entrance"]) + "";
				txtCommonTextBox[conTxtAuthorizedSig].Text = Convert.ToString(rsLocal["authorized_signature"]) + "";
				txtCommonTextBox[conTxtNewFileNo].Text = Convert.ToString(rsLocal["current_file_no"]) + "";
				txtCommonTextBox[conTxtNewContractNo].Text = Convert.ToString(rsLocal["current_contract_no"]) + "";
				txtCommonTextBox[conTxtNewLicenseNo].Text = Convert.ToString(rsLocal["current_license_no"]) + "";
				txtCommonTextBox[conTxtOldFileNo].Text = Convert.ToString(rsLocal["old_file_no"]) + "";
				txtCommonTextBox[conTxtOldContractNo].Text = Convert.ToString(rsLocal["old_contract_no"]) + "";
				txtCommonTextBox[conTxtOldLicenseNo].Text = Convert.ToString(rsLocal["old_license_no"]) + "";
				txtCommonTextBox[conTxtOldContractPeriod].Text = Convert.ToString(rsLocal["previous_residency_period"]) + "";
				txtCommonTextBox[conTxtNewContractPeriod].Text = Convert.ToString(rsLocal["current_residency_period"]) + "";
				txtCommonNumber[conNTxtOldContractSalary].Value = rsLocal["old_contract_salary"];
				txtCommonNumber[conNTxtNewContractSalary].Value = rsLocal["new_contract_salary"];
				txtCommonTextBox[conTxtNewProfession].Text = Convert.ToString(rsLocal["new_profesion"]) + "";
				txtCommonTextBox[conTxtOldProfession].Text = Convert.ToString(rsLocal["Old_Profession"]) + "";

				mTimeStamp = Convert.ToString(rsLocal["time_stamp"]);
				txtCommonTextBox_Leave(txtCommonTextBox[conTxtNatCode], new EventArgs());
				txtCommonTextBox_Leave(txtCommonTextBox[conTxtSponsorCode], new EventArgs());
				txtCommonTextBox_Leave(txtCommonTextBox[conTxtVisaType], new EventArgs());
				txtCommonTextBox_Leave(txtCommonTextBox[conTxtGovernateCd], new EventArgs());
			}
			while(rsLocal.Read());
			Application.DoEvents();
			this.CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			tabEmployee.CurrTab = Convert.ToInt16(conTabPersonnelBasic);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			int cnt = 0;

			FirstFocusObject = txtCommonTextBox[conTxtEmpCode];
			//On Error GoTo eFoundError

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

			oThisFormToolBar.ShowMoveRecordNextButton = false;
			oThisFormToolBar.ShowMoveRecordPreviousButton = false;

			this.WindowState = FormWindowState.Maximized;
			SystemProcedure.SetLabelCaption(this);
			tabEmployee.CurrTab = Convert.ToInt16(conTabPersonnelBasic);
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;


			if (pObjectName == "txtPassNat")
			{
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7004000, "745"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtPassNat.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				}
				return;
			}

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));


			switch(mIndex)
			{
				case conTxtVisaType : 
					txtCommonTextBox[conTxtVisaType].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7210000, "1841")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtVisaType].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtSponsorCode : 
					txtCommonTextBox[conTxtSponsorCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7200000, "1837")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtSponsorCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtNatCode : 
					txtCommonTextBox[conTxtNatCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7004000, "743")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtNatCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtGovernateCd : 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7150000, "1483")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtGovernateCd].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					break;
				case conTxtDesignationName : 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7002000, "736")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(((Array) mTempSearchValue).GetValue(1)))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtDesignationName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					} 
					break;
				case conTxtOldProfession : 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7002000, "736")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(((Array) mTempSearchValue).GetValue(1)))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtOldProfession].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					} 
					break;
				case conTxtNewProfession : 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7002000, "736")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(((Array) mTempSearchValue).GetValue(1)))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtNewProfession].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					} 
					break;
				case conTxtQualificationName : 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7009000, "782")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(((Array) mTempSearchValue).GetValue(1)))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtQualificationName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					} 
					break;
				case conTxtReligion : 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7003000, "741")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(((Array) mTempSearchValue).GetValue(1)))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtReligion].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					} 
					break;
				default:
					return;
			}

		}
		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (Index == conTxtVisaType)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtVisaType].Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select Visa_Type_cd ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Visa_Type_Name" : "A_Visa_Type_Name");
						mysql = mysql + " from pay_visa_Type ";
						mysql = mysql + " where ";
						mysql = mysql + " L_Visa_Type_no = " + txtCommonTextBox[conTxtVisaType].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblVisaTypeName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							txtDisplayLabel[conDlblVisaTypeName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1)) + "";
						}
					}
					else
					{
						txtDisplayLabel[conDlblVisaTypeName].Text = "";
					}
				}

				if (Index == conTxtSponsorCode)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtSponsorCode].Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select Sponsor_cd ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_First_name + ' ' +  L_Second_Name + ' ' + L_Third_Name + ' ' + L_Fourth_Name " : "A_First_name + ' ' +  A_Second_Name + ' ' + A_Third_Name + ' ' + A_Fourth_Name");
						mysql = mysql + " from pay_sponsor ";
						mysql = mysql + " where ";
						mysql = mysql + " sponsor_no = " + txtCommonTextBox[conTxtSponsorCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblSponsorName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							txtDisplayLabel[conDlblSponsorName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1)) + "";
						}
					}
					else
					{
						txtDisplayLabel[conDlblSponsorName].Text = "";
					}
				}

				if (Index == conTxtNatCode)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtNatCode].Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select nat_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_nat_name" : "a_nat_name");
						mysql = mysql + " from pay_nationality ";
						mysql = mysql + " where ";
						mysql = mysql + " nat_no = " + txtCommonTextBox[conTxtNatCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblNatName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							txtDisplayLabel[conDlblNatName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1)) + "";
						}
					}
					else
					{
						txtDisplayLabel[conDlblNatName].Text = "";
					}
				}
				if (Index == conTxtGovernateCd)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtGovernateCd].Text, SystemVariables.DataType.NumberType))
					{
						mysql = " select l_governate_name, a_governate_name , governate_cd ";
						mysql = mysql + " from pay_governate ";
						mysql = mysql + " where governate_no =" + txtCommonTextBox[conTxtGovernateCd].Text;
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblGovernateName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							txtDisplayLabel[conDlblGovernateName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1)) + "";
						}
					}
					else
					{
						txtDisplayLabel[conDlblGovernateName].Text = "";
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
					txtCommonTextBox[Index].Focus();
				}
				else
				{
					//
				}
			}

		}

		private void txtPassNat_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtPassNat");
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}