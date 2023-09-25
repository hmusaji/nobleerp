using System;



namespace Xtreme
{
	internal partial class frmPayLogReport
		: System.Windows.Forms.Form
	{

		public frmPayLogReport()
{
InitializeComponent();
} 
 public  void frmPayLogReport_old()
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


		private void frmPayLogReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private int mReportId = 0;
		
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

		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private const int conTxtEmpCode = 0;
		private const int conDlblEmpCode = 0;
		private string mVariablesSetSQL = "";


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




		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			object mReturnValue = null;
			string mysql = "";

			//UPGRADE_WARNING: (1068) txtFromDate.DisplayText of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			string mTempFromDate = ReflectionHelper.GetPrimitiveValue<string>(txtFromDate.DisplayText);
			//UPGRADE_WARNING: (1068) txtToDate.DisplayText of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			string mTempToDate = ReflectionHelper.GetPrimitiveValue<string>(txtToDate.DisplayText);
			mReportId = cmbReports.GetItemData(cmbReports.SelectedIndex);

			mVariablesSetSQL = " set @FromDate = '" + mTempFromDate + "'";
			mVariablesSetSQL = mVariablesSetSQL + " set @ToDate = '" + mTempToDate + "' ";

			SystemReports.GetSystemReport(mReportId, 2, mVariablesSetSQL, mTempFromDate, mTempToDate);

		}

		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			this.Close();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			bool mPromptForLocationMasterOnly = false;
			string mysql = "";
			object mReturnValue = null;
			int cnt = 0;

			this.Top = 67;
			this.Left = 33;

			cmbReports.AddItem("Employee History");
			cmbReports.SetItemData(cmbReports.GetNewIndex(), 65092370);
			cmbReports.AddItem("Leave History");
			cmbReports.SetItemData(cmbReports.GetNewIndex(), 65092390);
			cmbReports.AddItem("Salary Variation History");
			cmbReports.SetItemData(cmbReports.GetNewIndex(), 65092400);
			cmbReports.AddItem("Employee Termination History");
			cmbReports.SetItemData(cmbReports.GetNewIndex(), 65092410);
			cmbReports.AddItem("Payroll History");
			cmbReports.SetItemData(cmbReports.GetNewIndex(), 65092380);
			txtFromDate.Value = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate());
			txtToDate.Value = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate());

		}

		public void FindRoutine(string pObjectName)
		{

			txtcommontextbox[conTxtEmpCode].Text = "";
			string mysql = "pay_emp.status_cd not in (" + SystemHRProcedure.gStatusTerminated.ToString() + "," + SystemHRProcedure.gStatusOnHold.ToString() + ")";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtcommontextbox[conTxtEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				txtCommonTextBox_Leave(txtcommontextbox[conDlblEmpCode], new EventArgs());
			}
		}

		private void txtcommontextbox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtcommontextbox, Sender);
			FindRoutine("txtcommonTextBox#" + Index.ToString().Trim());
		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;


			if (!SystemProcedure2.IsItEmpty(txtcommontextbox[conTxtEmpCode].Text, SystemVariables.DataType.NumberType))
			{
				mysql = "select l_full_name from pay_employee ";
				mysql = mysql + " where emp_no ='" + txtcommontextbox[conTxtEmpCode].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDisplayLabel[conDlblEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
				else
				{
					txtDisplayLabel[conDlblEmpCode].Text = "";
				}
			}
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}