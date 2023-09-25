using System;
using System.Windows.Forms;


namespace Xtreme
{
	internal partial class frmICSBarcodeDataCollection
		: System.Windows.Forms.Form
	{

		public frmICSBarcodeDataCollection()
{
InitializeComponent();
} 
 public  void frmICSBarcodeDataCollection_old()
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


		private void frmICSBarcodeDataCollection_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private const int conDlblFileName = 0;

		private const int tabFileImport = 0;
		private const int tabGLTransImport = 1;
		private const int tabICSTransImport = 2;

		private string mFileName = "";
		private int mCallerId = 0;
		private int mGLVoucherID = 0;
		public int mTabSelected = 0;

		//Private mButtonPressed As Integer


		public string Filename
		{
			get
			{
				return mFileName;
			}
			set
			{
				mFileName = value;
			}
		}


		public int CallerId
		{
			set
			{
				mCallerId = value;
			}
		}



		public int GLVoucherID
		{
			get
			{
				return mGLVoucherID;
			}
			set
			{
				mGLVoucherID = value;
			}
		}


		//Public Property Let ButtonPressed(pButtonPressed As Integer)
		//'''1 = OK .. 2= Cancel
		//
		//    mButtonPressed = pButtonPressed
		//End Property
		//
		//Public Property Get ButtonPressed() As Integer
		//'''1 = OK .. 2= Cancel
		//
		//    ButtonPressed = mButtonPressed
		//End Property


		private void cmdFileSearch_Click(Object eventSender, EventArgs eventArgs)
		{
			//cdgFileSystem.InitDir = txtCommonLable(ctlBackupFolderNameIndex).Text
			//cdgFileSystem.flags = cdlOFNPathMustExist
			string mFileExtension = "";

			if (mCallerId == 1)
			{
				//'this is used during import voucher in ICS.
				mFileExtension = "xls;txt";
			}
			else
			{
				mFileExtension = "txt; *.xls; *.xlsx";
			}

			//UPGRADE_ISSUE: (6012) CommonDialog variable was not upgraded More Information: https://docs.mobilize.net/vbuc/ewis#6012
			//.InitDir = txtCommonLable(ctlBackupFolderNameIndex).Text
			//.FileName = txtCommonLable(ctlBackupFolderNameIndex).Text
			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property cdgFileSystem.DefaultExt was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			cdgFileSystemOpen.DefaultExt = mFileExtension;
			//.DialogTitle = "Select " & gAppShortName & " Download Backup File"
			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property cdgFileSystem.DialogTitle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			cdgFileSystemOpen.Title = "Select File";
			//UPGRADE_WARNING: (2074) FileOpenConstants STRING RESOURCE ["IDS-CONSTANT"] NOT FOUND FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
			//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property cdgFileSystem.Flags was upgraded to cdgFileSystemOpen.CheckFileExists which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
			cdgFileSystemOpen.CheckFileExists = true;
			cdgFileSystemOpen.CheckPathExists = true;
			//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property cdgFileSystem.Flags was upgraded to cdgFileSystemOpen.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
			//UPGRADE_WARNING: (2074) FileOpenConstants STRING RESOURCE ["IDS-CONSTANT"] NOT FOUND FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
			cdgFileSystemOpen.ShowReadOnly = false;
			//UPGRADE_ISSUE: (2064) MSComDlg.FileOpenConstants property FileOpenConstants.cdlOFNLongNames was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property cdgFileSystem.flags was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			cdgFileSystem.setFlags((int) UpgradeStubs.MSComDlg_FileOpenConstants.getcdlOFNLongNames());
			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property cdgFileSystem.Filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			cdgFileSystemOpen.Filter = SystemConstants.gAppShortName + " File (*." + mFileExtension + ")|*." + mFileExtension;
			cdgFileSystemOpen.ShowDialog();

			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property cdgFileSystem.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			txtCommonLable[conDlblFileName].Text = cdgFileSystemOpen.FileName;

		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 13 && this.ActiveControl.Name != "UCOkCancel1")
				{ //if enter key pressed send a tab key
					SendKeys.Send("{tab}");
					return;
				}
				else if (KeyCode == ((int) Keys.Escape))
				{ 
					CloseForm();
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}

		public void CloseForm()
		{
			this.Hide();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			if (mCallerId == 1)
			{ //'this is used during import voucher in ICS.
				this.Text = " Select File ";
				tabMaster.set_TabVisible(Convert.ToInt16(tabGLTransImport), false);
				tabMaster.set_TabVisible(Convert.ToInt16(tabFileImport), true);
				tabMaster.set_TabVisible(Convert.ToInt16(tabICSTransImport), false);
				tabMaster.CurrTab = Convert.ToInt16(tabFileImport);
			}
			else if (mCallerId == 2)
			{  // if called by GL Transaction
				tabMaster.set_TabVisible(Convert.ToInt16(tabGLTransImport), true);
				tabMaster.set_TabVisible(Convert.ToInt16(tabFileImport), true);
				tabMaster.set_TabVisible(Convert.ToInt16(tabICSTransImport), false);
				tabMaster.TabIndex = tabGLTransImport;
				tabMaster.CurrTab = Convert.ToInt16(tabGLTransImport);
			}
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			frmICSBarcodeDataCollection.DefInstance = null;
		}

		private void txtGLVoucherType_DropButtonClick(Object Sender, EventArgs e)
		{
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(205));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtGLVoucherType.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
			}
		}

		private void txtGLVoucherNo_DropButtonClick(Object Sender, EventArgs e)
		{
			if (txtGLVoucherType.Text == "")
			{
				return;
			}
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000101, "613", " mt.voucher_type = " + txtGLVoucherType.Text));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtGLVoucherNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
			}
		}

		private void UCOkCancel1_CancelClick(Object Sender, EventArgs e)
		{
			//ButtonPressed = 0
			Filename = "";
			mTabSelected = 99; // if user pressed cancel button
			CloseForm();
		}

		private void UCOkCancel1_OKClick(Object Sender, EventArgs e)
		{
			string mSQL = "";
			object mReturnValue = null;

			//cdgFileSystem.FileName = txtCommonLable(conDlblFileName).Text
			//FileName = Replace(Replace(cdgFileSystem.FileTitle, ".", "_"), " ", "_")
			//FileName = cdgFileSystem.FileTitle

			if (tabMaster.CurrTab == tabFileImport)
			{
				Filename = txtCommonLable[conDlblFileName].Text;
				mTabSelected = 1;
				if (SystemProcedure2.IsItEmpty(Filename, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Invalid File, Select a File", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
			else if (tabMaster.CurrTab == tabGLTransImport)
			{ 
				mSQL = " select entry_id  from gl_accnt_trans where voucher_type = " + txtGLVoucherType.Text + " and voucher_no = '" + txtGLVoucherNo.Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show(" Invalid Voucher Type and Voucher No !!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				GLVoucherID = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				mTabSelected = 2;
			}
			//ButtonPressed = 1

			CloseForm();
		}
	}
}