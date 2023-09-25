
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSysSystemLabels
		: System.Windows.Forms.Form
	{

		public frmSysSystemLabels()
{
InitializeComponent();
} 
 public  void frmSysSystemLabels_old()
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


		private void frmSysSystemLabels_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		public int mLableId = 0;

		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			object mReturnValue = null;
			//
			//mySql = " select english_name from SM_LABLES "
			//mySql = mySql & " where english_name='" & txtEngName.Text & "'"
			//mySql = mySql & " and lable_id <> " & mLableId
			//mReturnValue = GetMasterCode(mySql)
			//If Not IsNull(mReturnValue) Then
			//    MsgBox "Duplicate name not allowed", vbInformation
			//    Exit Sub
			//End If

			string mysql = " update SM_LABLES ";
			mysql = mysql + " set ";
			mysql = mysql + " english_name='" + txtEngName.Text + "'";
			mysql = mysql + ", arabic_name=N'" + txtArabicName.Text + "'";
			mysql = mysql + ", module_id='" + txtModuleId.Text + "'";
			mysql = mysql + " where lable_id = " + mLableId.ToString();

			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsSystemLables.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.rsSystemLables.setActiveConnection(SystemVariables.gConn);
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsSystemLables.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.rsSystemLables.Requery(-1);
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsSystemLables.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.rsSystemLables.setActiveConnection(null);


			this.Close();
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 27)
				{
					this.Close();
				}

				if (KeyCode == 13)
				{ //if enter key pressed send a tab key
					SendKeys.Send("{tab}");
					return;
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
			string mysql = "";
			object mReturnValue = null;

			lblLableId.Text = mLableId.ToString();

			if (mLableId > 0)
			{
				mysql = " select english_name , arabic_name , module_id  ";
				mysql = mysql + " from SM_LABLES ";
				mysql = mysql + " where lable_id = " + mLableId.ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtEngName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtArabicName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtModuleId.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
				}
			}
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				frmSysSystemLabels.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}
	}
}