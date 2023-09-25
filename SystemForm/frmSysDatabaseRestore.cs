
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmSysDatabaseRestore
		: System.Windows.Forms.Form
	{

		public frmSysDatabaseRestore()
{
InitializeComponent();
} 
 public  void frmSysDatabaseRestore_old()
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


		private void frmSysDatabaseRestore_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		int mThisFormID = 0;
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



		private void cmdCancel_Click(Object eventSender, EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdOk_Click(Object eventSender, EventArgs eventArgs)
		{
			clsHourGlass myHourGlass = null;
			string mySQL = "";
			DialogResult ans = (DialogResult) 0;
			string mSourceDBName = "";
			string mDatabaseName = "";

			try
			{

				if (SystemProcedure2.IsItEmpty(txtRestoreDBName.Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Invalid Database Name", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				else
				{
					mDatabaseName = txtRestoreDBName.Text;
				}

				ans = MessageBox.Show("Are you sure, you want to restore the database? ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (ans == System.Windows.Forms.DialogResult.Yes)
				{
					myHourGlass = new clsHourGlass();

					//mFirstHash = InStr(1, File1.FileName, "_")
					//mSecondHash = InStr(mFirstHash + 1, File1.FileName, "_")
					//mDatabaseName = Mid(File1.FileName, 1, mFirstHash - 1)


					mSourceDBName = File1.CurrentPath + ((File1.CurrentPath.Trim().Substring(Math.Max(File1.CurrentPath.Trim().Length - 1, 0)) == "\\") ? "" : "\\") + File1.FileName;
					if (RestoreDatabase(mDatabaseName, mSourceDBName))
					{
						MessageBox.Show("Restore done successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.Close();
					}
					else
					{
						MessageBox.Show("Restore Failed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.Close();
					}
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void Dir1_PathChange(Object eventSender, EventArgs eventArgs)
		{
			File1.CurrentPath = Dir1.Path;
		}

		private void Drive1_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			Dir1.Path = Drive1.Drive;
		}

		private void File1_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			//Dim mSecondHash As Integer

			int mFirstHash = (File1.FileName.IndexOf('_') + 1);
			//mSecondHash = InStr(mFirstHash + 1, File1.FileName, "_")

			if (mFirstHash == 0)
			{
				if (File1.FileName.IndexOf('.') >= 0)
				{
					mFirstHash = Strings.Len(File1.FileName) - 3;
				}
				else
				{
					mFirstHash = Strings.Len(File1.FileName) + 1;
				}
			}

			txtRestoreDBName.Text = File1.FileName.Substring(0, Math.Min(mFirstHash - 1, File1.FileName.Length));

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{


			string mDefaultBackupPath = new string(' ', 255);

			string tempRefParam = "DatabaseInformation";
			string tempRefParam2 = "c:\\backup\\";
			string tempRefParam3 = SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + "App.Config";
			InnovaUpdSupport.PInvoke.SafeNative.kernel32.GetPrivateProfileString(ref tempRefParam, "DatabaseBackupPath", ref tempRefParam2, ref mDefaultBackupPath, 255, ref tempRefParam3);
			mDefaultBackupPath = mDefaultBackupPath.Trim().Substring(0, Math.Min(Strings.Len(mDefaultBackupPath.Trim()) - 1, mDefaultBackupPath.Trim().Length));

			try
			{
				Dir1.Path = mDefaultBackupPath;
			}
			catch
			{
			}
		}

		private bool RestoreDatabase(string pRestoreDBName, string pSourceDBPath)
		{
			bool result = false;
			string mDataLogicalName = "";
			string mLogLogicalName = "";

			string mDataFilePath = "";

			//On Error GoTo mend


			string mySQL = " RESTORE FILELISTONLY   FROM DISK = '" + pSourceDBPath + "' ";
			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mySQL, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			bool rsTempRecDidRead = rsTempRec.Read();
			if (rsTempRecDidRead)
			{
				mDataLogicalName = Convert.ToString(rsTempRec[0]);
				rsTempRecDidRead = rsTempRec.Read();
				mLogLogicalName = Convert.ToString(rsTempRec[0]);
			}
			else
			{
				MessageBox.Show("Invalid file found!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = false;
				rsTempRec.Close();
				return result;
			}
			rsTempRec.Close();

			mySQL = " select filename from sysfiles ";
			SqlCommand sqlCommand_2 = new SqlCommand(mySQL, SystemVariables.gConn);
			rsTempRec = sqlCommand_2.ExecuteReader();
			bool rsTempRecDidRead2 = rsTempRec.Read();
			if (rsTempRecDidRead)
			{
				mySQL = Convert.ToString(rsTempRec[0]).Trim();
				mDataFilePath = mySQL.Substring(0, Math.Min(GetLastSlashPosition(mySQL), mySQL.Length));
			}
			else
			{
				MessageBox.Show("Invalid output from sysfiles!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			rsTempRec.Close();


			mySQL = " restore database " + pRestoreDBName;
			mySQL = mySQL + " from disk = '" + pSourceDBPath + "' ";
			mySQL = mySQL + " with move '" + mDataLogicalName + "' TO '" + mDataFilePath + pRestoreDBName + ".mdf' ";
			mySQL = mySQL + " , move '" + mLogLogicalName + "' TO '" + mDataFilePath + pRestoreDBName + ".ldf'";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mySQL;
			TempCommand.ExecuteNonQuery();




			return true;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		private int GetLastSlashPosition(string pString)
		{
			int cnt = 0;
			int cnt1 = 0;


			while(true)
			{
				cnt = Strings.InStr(cnt1 + 1, pString, "\\", CompareMethod.Binary);
				if (cnt != 0)
				{
					cnt1 = cnt;
				}
				else
				{
					return cnt1;
				}
			};
			return 0;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				UserAccess = null;
				frmSysDatabaseRestore.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}
	}
}