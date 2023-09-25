
using System;
using System.Windows.Forms;


namespace Xtreme
{
	internal partial class frmSysAbout
		: System.Windows.Forms.Form
	{

		public frmSysAbout()
{
InitializeComponent();
} 
 public  void frmSysAbout_old()
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


		private void frmSysAbout_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private void cmdClose_Click(Object eventSender, EventArgs eventArgs)
		{
			this.Close();
		}
		//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//' Created by Moiz Hakimi-----10-May-2010------------------------''
		//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				string mySql = "select L_Comp_Name, A_Comp_Name, Last_Migrated_Date from sm_company where Comp_Id = " + SystemVariables.gCompanyID.ToString();

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				object mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySql, true));
				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
				if (!Object.Equals(mTempValue, null))
				{
					lblLicensedToCompnayName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
					lblLastUpdateDate.Text = "Last update date: " + ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mTempValue).GetValue(2)).ToString("dd-MMM-yyyy");
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
			}
			catch
			{
			}

		}
	}
}