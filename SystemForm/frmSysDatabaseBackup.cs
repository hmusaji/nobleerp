
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmSysDatabaseBackup
		: System.Windows.Forms.Form
	{

		public frmSysDatabaseBackup()
{
InitializeComponent();
} 
 public  void frmSysDatabaseBackup_old()
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


		private void frmSysDatabaseBackup_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//Assign the Formid for Each Form
		int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;

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

		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;


		private const int BIF_RETURNONLYFSDIRS = 1;
		private const int BIF_DONTGOBELOWDOMAIN = 2;
		private const int MAX_PATH = 260;

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis#2041
		////UPGRADE_TODO: (1050) Structure BrowseInfo may require marshalling attributes to be passed as an argument in this Declare statement. More Information: https://docs.mobilize.net/vbuc/ewis#1050
		//[DllImport("shell32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int SHBrowseForFolder(ref InnovaUpdSupport.PInvoke.UnsafeNative.Structures.BrowseInfo lpbi);

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis#2041
		//[DllImport("shell32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int SHGetPathFromIDList(int pidList, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpBuffer);

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis#2041
		//[DllImport("kernel32.dll", EntryPoint = "lstrcatA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int lstrcat([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpString1, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpString2);


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


		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			CloseForm();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			string mBackupPath = "";
			string mBackupFileName = "";
			object mReturnValue = null;
			string mysql = "";
			int ans = 0;
			int cnt = 0;
			clsHourGlass myHourGlass = null;

			try
			{

				//ans = MsgBox("Are you sure, you want to backup database?", vbInformation + vbYesNo)
				//If ans = vbYes Then
				myHourGlass = new clsHourGlass();

				if (txtExportPath.Text == "")
				{
					MessageBox.Show("Please Select File Path", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txtExportPath.Focus();
					return;
				}


				mBackupPath = txtExportPath.Text;
				if (mBackupPath.Trim().Substring(Math.Max(mBackupPath.Trim().Length - 1, 0)) != "\\")
				{
					mBackupPath = mBackupPath + "\\";
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property gConn.CommandTimeout was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.setCommandTimeout(0);
				ExportProgress.Value = 0;

				int tempForEndVar = lstDatabase.Items.Count - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					if (lstDatabase.GetItemChecked(cnt))
					{
						mysql = " select db_alias from SM_COMPANY ";
						mysql = mysql + " where comp_id=" + lstDatabase.GetItemData(cnt).ToString();
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{

							mBackupFileName = (ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + "_backup_" + StringsHelper.Format(DateTime.Today, "dd_mmm_yyyy") + "_" + StringsHelper.Format(DateTimeHelper.Time, "hh_mm") + ".bak").ToLower();
							//Backup Database
							ExportProgress.Value = Convert.ToInt32(ExportProgress.Value + ((cnt + 1) / ((double) lstDatabase.Items.Count)) * 50);
							Application.DoEvents();

							mysql = "backup database " + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + " to disk='" + mBackupPath + mBackupFileName + "'";
							SqlCommand TempCommand = null;
							TempCommand = SystemVariables.gConn.CreateCommand();
							TempCommand.CommandText = mysql;
							TempCommand.ExecuteNonQuery();

							//Verifying Database
							mysql = "restore verifyonly from disk='" + mBackupPath + mBackupFileName + "'";
							SqlCommand TempCommand_2 = null;
							TempCommand_2 = SystemVariables.gConn.CreateCommand();
							TempCommand_2.CommandText = mysql;
							TempCommand_2.ExecuteNonQuery();
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							mReturnValue = DBNull.Value;

							mysql = " update SM_COMPANY ";
							mysql = mysql + " set last_backup_date=getdate()";
							mysql = mysql + " where comp_id=" + lstDatabase.GetItemData(cnt).ToString();
							SqlCommand TempCommand_3 = null;
							TempCommand_3 = SystemVariables.gConn.CreateCommand();
							TempCommand_3.CommandText = mysql;
							TempCommand_3.ExecuteNonQuery();

							ExportProgress.Value = Convert.ToInt32(ExportProgress.Value + ((cnt + 1) / ((double) lstDatabase.Items.Count)) * 50);
							Application.DoEvents();
						}
					}
				}

				//If chkBackupSysDb.Value = 1 Then
				//    mBackupFileName = LCase("sysdb_backup_" & Format(Date, "dd_mmm_yyyy") & "_" & Format(Time, "hh_mm"))
				//    'Backup Database
				//    mySQL = "backup database sysdb to disk='" & mBackupPath & mBackupFileName & "'"
				//    gConn.Execute mySQL
				//
				//    'Verifying Database
				//    mySQL = "restore verifyonly from disk='" & mBackupPath & mBackupFileName & "'"
				//    gConn.Execute mySQL
				//End If
				//gConn.CommandTimeout = 30

				MessageBox.Show("Backup Done Successfully:", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void Drive1_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			Dir1.Path = Drive1.Drive;
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

		public void CloseForm()
		{
			this.Close();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			oThisFormToolBar.ShowExitButton = true;

			this.WindowState = FormWindowState.Maximized;

			this.Top = (Convert.ToInt32((frmSysMain.DefInstance.oSystemInformation.WorkAreaHeight / 15 - (frmSysMain.DefInstance.Height - frmSysMain.DefInstance.ClientRectangle.Height) - this.Height) / 2f));
			this.Left = (Convert.ToInt32((frmSysMain.DefInstance.oSystemInformation.WorkAreaWidth / 15 - (frmSysMain.DefInstance.Width - frmSysMain.DefInstance.ClientRectangle.Width) - this.Width) / 2f));

			string mDefaultBackupPath = new string(' ', 255);
			string tempRefParam = "DatabaseInformation";
			string tempRefParam2 = "c:\\backup\\";
			string tempRefParam3 = SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + "App.Config";
			InnovaUpdSupport.PInvoke.SafeNative.kernel32.GetPrivateProfileString(ref tempRefParam, "DatabaseBackupPath", ref tempRefParam2, ref mDefaultBackupPath, 255, ref tempRefParam3);
			mDefaultBackupPath = mDefaultBackupPath.Trim().Substring(0, Math.Min(Strings.Len(mDefaultBackupPath.Trim()) - 1, mDefaultBackupPath.Trim().Length));

			//UPGRADE_WARNING: (2099) Return value for Dir has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2099
			if (!SystemProcedure2.IsItEmpty(FileSystem.Dir(mDefaultBackupPath, FileAttribute.Directory), SystemVariables.DataType.StringType))
			{
				Dir1.Path = mDefaultBackupPath;
			}
			else
			{
				Dir1.Path = "c:\\";
			}
			Drive1.Drive = mDefaultBackupPath;

			string mysql = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "a_comp_name" : "l_comp_name");
			mysql = mysql + ",comp_id from sm_company ";
			SqlDataReader localRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand.ExecuteReader();
			localRec.Read();
			do 
			{
				lstDatabase.AddItem(Convert.ToString(localRec[0])); //, lstDatabase.ListCount
				lstDatabase.SetItemData(lstDatabase.GetNewIndex(), Convert.ToInt32(localRec[1]));
				lstDatabase.SetItemChecked(lstDatabase.Items.Count - 1, true);
			}
			while(localRec.Read());
		}

		//Private Sub Form_Resize()
		//Frame3.top = (Me.Height - Frame3.Height) / 2
		//Frame3.left = (Me.Width - Frame3.Width) / 2
		//End Sub

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				frmSysDatabaseBackup.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtExportPath_DropButtonClick(Object Sender, EventArgs e)
		{
			txtExportPath.Text = BrowseFolder("Select Path", "C");
		}

		public string BrowseFolder(string Caption = "", string InitialFolder = "")
		{
			string result = "";
			string sBuffer = "";
			InnovaUpdSupport.PInvoke.UnsafeNative.Structures.BrowseInfo tBrowseInfo = new InnovaUpdSupport.PInvoke.UnsafeNative.Structures.BrowseInfo();

			string szTitle = Caption;
			tBrowseInfo.hWndOwner = this.Handle.ToInt32();
			string tempRefParam = "";
			tBrowseInfo.lpszTitle = InnovaUpdSupport.PInvoke.SafeNative.kernel32.lstrcat(ref szTitle, ref tempRefParam);
			tBrowseInfo.ulFlags = BIF_RETURNONLYFSDIRS + BIF_DONTGOBELOWDOMAIN;

			int lpIDList = InnovaUpdSupport.PInvoke.SafeNative.shell32.SHBrowseForFolder(ref tBrowseInfo);

			if (lpIDList != 0)
			{
				sBuffer = new String(' ', MAX_PATH);
				InnovaUpdSupport.PInvoke.SafeNative.shell32.SHGetPathFromIDList(lpIDList, ref sBuffer);
				sBuffer = sBuffer.Substring(0, Math.Min(sBuffer.IndexOf("\0"), sBuffer.Length));
				result = sBuffer;
			}
			return result;
		}
	}
}