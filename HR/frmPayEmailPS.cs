
using Outlook = Microsoft.Office.Interop.Outlook;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayEmailPS
		: System.Windows.Forms.Form
	{

		public frmPayEmailPS()
{
InitializeComponent();
} 
 public  void frmPayEmailPS_old()
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


		private void frmPayEmailPS_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private string mPath = "";

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


		private void chkAllEmployees_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			if (chkAllEmployees.CheckState == CheckState.Checked)
			{
				txtFromEmp.Enabled = false;
				txtToEmp.Enabled = false;
			}
			else
			{
				txtFromEmp.Enabled = true;
				txtToEmp.Enabled = true;
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		private void cmdOk_Click(Object eventSender, EventArgs eventArgs)
		{

			string mFromEmp = "";
			string mToEmp = "";
			string mGenerateDate = "";
			DataSet rs = new DataSet();
			StringBuilder mSQL = new StringBuilder();

			if (chkAllEmployees.CheckState == CheckState.Checked)
			{
				mFromEmp = "0000000000";
				mToEmp = "99999999999";
				mSQL = new StringBuilder("select emp_no,email,l_full_name ");
				mSQL.Append(" from pay_employee ");
				mSQL.Append(" where len(email) > 0 and include_in_payslip_printing = 1");
				mSQL.Append(" and status_cd not in (3,4)");
			}
			else
			{
				mFromEmp = txtFromEmp.Text;
				mToEmp = txtToEmp.Text;
				mSQL = new StringBuilder("select emp_no,email,l_full_name from pay_employee ");
				mSQL.Append(" where emp_no>= '" + mFromEmp + "' and emp_no <= '" + mToEmp + "'");
				mSQL.Append(" and email is not null and include_in_payslip_printing = 1");
				mSQL.Append(" and status_cd not in (3,4)");
			}
			if (ChkIncludeSentEmployee.CheckState == CheckState.Unchecked)
			{
				mSQL.Append(" and is_payslip_sent = 0");
			}

			//creating directory
			mPath = SystemVariables.gEmailPayslipPath + DateTimeFormatInfo.CurrentInfo.GetMonthName(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtMonth.Value).Month);
			//UPGRADE_WARNING: (2099) Return value for Dir has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2099
			if (FileSystem.Dir(mPath + "\\*.*") == "")
			{
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					Directory.Delete(mPath);
					Directory.CreateDirectory(mPath);
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}


			SqlDataAdapter adap = new SqlDataAdapter(mSQL.ToString(), SystemVariables.gConn);
			rs.Tables.Clear();
			adap.Fill(rs);
			int i = 1;
			txtEmployeeComplete.Text = "Complete 0 Of " + rs.Tables[0].Rows.Count.ToString();

			while(rs.Tables[0].Rows.Count != 0)
			{
				mGenerateDate = txtMonth.Text;
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				GetCrystalRep(65009110, 1, "9732,9733,9734,9735,9736,9737", Convert.ToString(rs.Tables[0].Rows[0][0]) + "," + Convert.ToString(rs.Tables[0].Rows[0][0]) + ", 0, 0, 0," + StringsHelper.Format(txtMonth.Text, SystemVariables.gSystemDateFormat), false, Convert.ToString(rs.Tables[0].Rows[0][0]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				sendMail(Convert.ToString(rs.Tables[0].Rows[0][0]), Convert.ToString(rs.Tables[0].Rows[0][2]), Convert.ToString(rs.Tables[0].Rows[0][1]));
				mSQL = new StringBuilder("update pay_employee");
				mSQL.Append(" set is_payslip_sent =1");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mSQL.Append(" where emp_no='" + Convert.ToString(rs.Tables[0].Rows[0][0]) + "'");
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mSQL.ToString();
				TempCommand.ExecuteNonQuery();
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rs.MoveNext was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rs.MoveNext();
				txtEmployeeComplete.Text = "Complete " + i.ToString() + "Of " + rs.Tables[0].Rows.Count.ToString();
				i++;
			};
			//Call Form_Unload(0)
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
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

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			this.Left = 0;
			this.Top = 0;
			chkAllEmployees.CheckState = CheckState.Checked;
			txtMonth.Value = SystemHRProcedure.GetPayrollGenerateDate();
		}

		private void GetCrystalRep(int pReportID, int pCallType = 1, string pParameterNamesList = "", string pParameterValuesList = "", bool pCheckUserRights = true, string pEmpNo = "")
		{
			clsAccessAllowed UserAccess = new clsAccessAllowed();
			bool mAllowUserDisplay = false;
			frmSysCRYSTALDesign oReportForm = null;

			clsHourGlass myHourGlass = new clsHourGlass();

			//On Error GoTo eFoundError

			if (pCheckUserRights)
			{
				UserAccess.CheckAccess(pReportID, SystemVariables.SystemObjectTypes.objReport);
				mAllowUserDisplay = UserAccess.AllowUserDisplay;
			}
			else
			{
				mAllowUserDisplay = true;
			}

			if (mAllowUserDisplay)
			{
				oReportForm = frmSysCRYSTALDesign.CreateInstance();

				oReportForm.SetReportID(pReportID);
				oReportForm.SetReportAccess = UserAccess;
				oReportForm.Hide();
				oReportForm.SetParameterValues(pParameterNamesList, pParameterValuesList);
				oReportForm.Hide();
				oReportForm.SetReportData();


				oReportForm.GetReportData();
				oReportForm.Hide();
				oReportForm.crrPrimaryReport.ExportOptions.DiskFileName = mPath + "\\" + pEmpNo + ".pdf";
				oReportForm.crrPrimaryReport.ExportOptions.DestinationType = CRAXDDRT.CRExportDestinationType.crEDTDiskFile;
				//    oReportForm.crrPrimaryReport.ExportOptions.DestinationType = crEDTDiskFile
				oReportForm.crrPrimaryReport.ExportOptions.FormatType = CRAXDDRT.CRExportFormatType.crEFTPortableDocFormat;
				Application.DoEvents();
				oReportForm.crrPrimaryReport.Export(false);

			}
			else
			{
				return;
			}
			oReportForm.CloseForm();

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069

			//eFoundError:
			//MsgBox Err.Description
		}

		private void sendMail(string pEmpNo, string pEmpName, string pEmailAdd)
		{
			try
			{
				Outlook.Application olApp = null; //Outlook.Application
				string mString = "";

				olApp = new Outlook.Application();

				// Logon. Doesn't hurt if you are already running and logged on...
				Outlook.NameSpace olNs = null; //Outlook.NameSpace
				//Set olNs = CreateObject("Outlook.NameSpace")
				olNs = olApp.GetNamespace("MAPI");
				olNs.Logon(Type.Missing, Type.Missing, Type.Missing, Type.Missing);

				// Send a message to your new contact.
				object olMail = null; //Outlook.MailItem
				//Set olMail = olapp. 'CreateObject("Outlook.MailItem")
				//Dim myattachments As Object 'Outlook.Attachments
				//Set myattachments = CreateObject("Outlook.Attachments")
				olMail = olApp.CreateItem(Outlook.OlItemType.olMailItem);
				// Fill out & send message...
				ReflectionHelper.LetMember(olMail, "To", pEmailAdd);
				ReflectionHelper.LetMember(olMail, "Subject", "Payslip");
				ReflectionHelper.LetMember(olMail, "Body", "Dear " + pEmpName + ", " + "\r" + "\r" + "\t" + 
				                           "Please find attached your salary payslip!" + "\r" + "\t" + 
				                           ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("Email_Body")) + "\r" + "\t" + 
				                           "Best Regards" + "\r" + "\t" + 
				                           ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("Email_Signature_Name")) + "\r" + "\t" + 
				                           ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("Email_Signature_Designation")));
				ReflectionHelper.Invoke(ReflectionHelper.GetMember(olMail, "Attachments"), "Add", new object[]{mPath + "\\" + pEmpNo + ".pdf"});
				ReflectionHelper.Invoke(olMail, "Send", new object[]{});

				// Clean up...
				//   MsgBox "All done...", vbMsgBoxSetForeground
				olNs.Logoff();
				olNs = null;
				olMail = null;
				olApp = null;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}


		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			this.Close();
		}

		private void txtFromEmp_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtFromEmp");
		}


		private void txtFromEmp_Leave(Object eventSender, EventArgs eventArgs)
		{

			string mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_full_name" : "a_full_name");
			mysql = mysql + " from pay_employee ";
			mysql = mysql + " where emp_no ='" + txtFromEmp.Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtFrmEmpCodeName.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
			}
			else
			{
				txtFromEmp.Text = "";
				txtFrmEmpCodeName.Text = "";
			}
		}

		private void txtToEmp_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtToEmp");
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;
			string mysql = "";

			if (pObjectName == "txtToEmp")
			{
				txtToEmp.Text = "";
				mysql = " pay_emp.status_cd not in (3,4)";
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtToEmp.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtToEmp_Leave(txtToEmp, new EventArgs());
				}
			}
			else if (pObjectName == "txtFromEmp")
			{ 
				txtFromEmp.Text = "";
				mysql = " pay_emp.status_cd not in (3,4)";
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtFromEmp.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtFromEmp_Leave(txtFromEmp, new EventArgs());
				}
			}

		}

		private void txtToEmp_Leave(Object eventSender, EventArgs eventArgs)
		{

			string mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_full_name" : "a_full_name");
			mysql = mysql + " from pay_employee ";
			mysql = mysql + " where emp_no ='" + txtToEmp.Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtToEmpCodeName.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
			}
			else
			{
				txtToEmp.Text = "";
				txtToEmpCodeName.Text = "";
			}

		}
	}
}