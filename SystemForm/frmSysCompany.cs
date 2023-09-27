
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmSysCompany
		: System.Windows.Forms.Form
	{


		private int mThisFormID = 0;
		//$0
		private object mSearchValue = null;
		private string mTimeStamp = "";
		//private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		private const int ctCompanyCode = 0;
		private const int ctCompanyNameEnglish = 1;
		private const int ctCompanyNameArabic = 2;
		private const int ctDBFileName = 3;
		private const int ctAddress1 = 4;
		private const int ctAddress2 = 5;
		private const int ctDBBackEnd = 6;
		private const int ctProductKey = 7;

		private const int cdCurrentPeriodStartDate = 0;
		private const int cdCurrentPeriodEndDate = 1;
		private const int cdNextPeriodStartDate = 2;
		private const int cdNextPeriodEndDate = 3;
		private const int cdLastBackupDate = 4;

		private const int clSystemEdition = 0;
		private const int clSystemColorScheme = 1;
		private const int clCompany = 2;

		private const int coDefaultSetting = 0;
		private const int coExistingSetting = 1;

		private const int ccImportPreferenceAndSettings = 0;
		private const int ccImportGLVoucherSetting = 1;
		private const int ccImportICSVoucherSetting = 2;
		private const int ccImportGLMasterData = 3;
		private const int ccImportICSMasterData = 4;
		private const int ccImportExactReplica = 5;

		private const int clblDBBackEnd = 13;
		private const int clblProductKey = 14;
		private const int clblSystemEdition = 15;
		private const int clblSystemColorScheme = 16;

		
		public frmSysCompany()
{
InitializeComponent();
}
}
}
