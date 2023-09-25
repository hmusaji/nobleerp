
using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSysSQLUpdate
		: System.Windows.Forms.Form
	{

		public frmSysSQLUpdate()
{
InitializeComponent();
} 
 public  void frmSysSQLUpdate_old()
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


		private void frmSysSQLUpdate_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private int mFormCallType = 0;




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



		public int FormCallType
		{
			get
			{
				return mFormCallType;
			}
			set
			{
				mFormCallType = value;
			}
		}


		private void cmdExecuteSQL_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				string[] saSQL = null;
				int X = 0;

				if (txtSQLCommand.SelectedText == "")
				{
					if (cmbDatabase.GetItemData(cmbDatabase.ListIndex) == 1)
					{
						saSQL = txtSQLCommand.Text.Split(';');
						SystemVariables.gConn.BeginTransaction();
						int tempForEndVar = saSQL.GetUpperBound(0) - 1;
						for (X = 0; X <= tempForEndVar; X++)
						{
							SqlCommand TempCommand = null;
							TempCommand = SystemVariables.gConn.CreateCommand();
							TempCommand.CommandText = saSQL[X];
							TempCommand.ExecuteNonQuery();
						}
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.CommitTrans();
					}
					else if (cmbDatabase.GetItemData(cmbDatabase.ListIndex) == 2)
					{ 
						saSQL = txtSQLCommand.Text.Split(';');
						int tempForEndVar2 = saSQL.GetUpperBound(0) - 1;
						for (X = 0; X <= tempForEndVar2; X++)
						{
							SqlCommand TempCommand_2 = null;
							TempCommand_2 = SystemVariables.gConn.CreateCommand();
							TempCommand_2.CommandText = saSQL[X];
							TempCommand_2.ExecuteNonQuery();
						}
					}
				}
				else
				{
					if (cmbDatabase.GetItemData(cmbDatabase.ListIndex) == 1)
					{
						saSQL = txtSQLCommand.SelectedText.Split(';');
						int tempForEndVar3 = saSQL.GetUpperBound(0) - 1;
						for (X = 0; X <= tempForEndVar3; X++)
						{
							SqlCommand TempCommand_3 = null;
							TempCommand_3 = SystemVariables.gConn.CreateCommand();
							TempCommand_3.CommandText = saSQL[X];
							TempCommand_3.ExecuteNonQuery();
						}
					}
					else if (cmbDatabase.GetItemData(cmbDatabase.ListIndex) == 2)
					{ 
						SystemVariables.gConn.BeginTransaction();
						saSQL = txtSQLCommand.SelectedText.Split(';');
						int tempForEndVar4 = saSQL.GetUpperBound(0) - 1;
						for (X = 0; X <= tempForEndVar4; X++)
						{
							SqlCommand TempCommand_4 = null;
							TempCommand_4 = SystemVariables.gConn.CreateCommand();
							TempCommand_4.CommandText = saSQL[X];
							TempCommand_4.ExecuteNonQuery();
						}
					}
				}
				MessageBox.Show("Query Excute Successfully!!!", "SQL Query Excute", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (System.Exception excep)
			{

				if (cmbDatabase.GetItemData(cmbDatabase.ListIndex) == 1)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
				}
				else
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
				}
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(excep.Message + Information.Err().Number.ToString(), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void cmdLoadSQL_Click(Object eventSender, EventArgs eventArgs)
		{
			string GetPhotoPath = "";
			try
			{

				string dNextLine = "";
				StringBuilder dText = new StringBuilder();
				int lLineCount = 0;

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.InitDir was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				CommonDialog1Open.InitialDirectory = GetPhotoPath;
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				CommonDialog1Open.Filter = "SQL (*.sql,*.txt)|*.sql; *.txt";

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				CommonDialog1Open.FileName = "";
				CommonDialog1Open.ShowDialog();

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (CommonDialog1Open.FileName == "")
				{
					return;
				}

				lLineCount = 1;
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				FileSystem.FileOpen(1, CommonDialog1Open.FileName, OpenMode.Input, OpenAccess.Default, OpenShare.Default, -1);

				while(!FileSystem.EOF(1))
				{
					dNextLine = FileSystem.LineInput(1);
					if (dNextLine.ToUpper() == ("Go").ToUpper())
					{
						dText.Append(";" + Environment.NewLine);
					}
					else
					{
						dText.Append(dNextLine + Environment.NewLine);
					}
					lLineCount++;
				};

				//dText = Replace(dText, "GO" & vbCrLf, ";" & vbCrLf)


				txtSQLCommand.Text = dText.ToString();

				FileSystem.FileClose(1);
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(excep.Message + Information.Err().Number.ToString(), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				cmbDatabase.AddItem("Current DB");
				cmbDatabase.SetItemData(cmbDatabase.NewIndex, 1);

				cmbDatabase.AddItem("System DB");
				cmbDatabase.SetItemData(cmbDatabase.NewIndex, 2);

				SystemCombo.SearchCombo(cmbDatabase, 1);
				this.WindowState = FormWindowState.Maximized;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}