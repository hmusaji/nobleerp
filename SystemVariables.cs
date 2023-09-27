using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtreme
{
    internal static class SystemVariables
    {


        //**** This module consists of all the Global Variables ****'

        //****global connections & recordsets ***************************************'
        public static SqlConnection gConn = null;

        public static DataSet rsVoucherTypes = null;
        //Public rsSystemPreferences As ADODB.Recordset
        public static DataSet rsCompanyProperties = null;
        public static DataSet rsSystemColorScheme = null;
        public static DataSet rsSystemObjects = null;
        //Public rsSystemFeatures As ADODB.Recordset
        public static DataSet rsSystemLables = null;
        public static DataSet rsSystemPreferences = null;
        public static DataSet rsReportParameter = null;
        public static DataSet rsGlobalProducts = null;
        //************************************************************'
        public static bool gMISuperUser = false;
        public static int gCurrentOSPlatform = 0;
        public static string gServerID = "";
        public static string gSQLServerUserID = "";
        public static string gSQLServerPassword = "";
        public static string gDatabaseName = "";
        public static int gCompanyID = 0;
        public static int gLoggedInUserCode = 0;
        public static string gLoggedInUserID = "";
        public static int gLoggedInUserGroupCode = 0;
        public static bool gLoggedInSingleLocation = false;
        public static int gDefaultFinalReportLevel = 0;
        public static int gLoggedInUserLocationCode = 0;
        public static string gLoggedInUserLocationName = "";
        public static string gSystemExpirationDate = "";
        public static bool gApplicationInitialized = false;
        public static bool gXtremeAdminLoggedIn = false;
        public static int gPrimaryLocationCode = 0;
        public static bool gIsHeadOffice = false;


        public static string gDefaultUserLevelSmanNo = "";
        public static bool gEnableUserLevelCostDetails = false;
        public static bool gRestrictOnExceedingCreditLimit = false;


        //''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //''Global Variables for User level price restriction
        public static int gDefaultSalesPriceLevel = 0;
        public static int gDefaultPurchasePriceLevel = 0;
        public static int gCustomerSalesPriceLevel = 0;
        public static int gCustomerPurchasePriceLevel = 0;
        public static bool gEnableSalesPriceRestrictions = false;
        public static bool gEnablePayrollExpiryPopup = false;
        public static bool gEnablePurchasePriceRestrictions = false;
        public static bool gRestrictInSalesPriceLevels = false;
        public static bool gRestrictInPurchasePriceLevels = false;
        public static int gMaximumSalesPriceLevel = 0;
        public static int gMinimumSalesPriceLevel = 0;
        public static decimal gMaximumProductSalesDiscountInPercent = 0;
        public static decimal gMaximumVoucherSalesDiscountInPercent = 0;
        public static decimal gMaximumProductPurchaseDiscountInPercent = 0;
        public static decimal gMaximumVoucherPurchaseDiscountInPercent = 0;
        public static int gMaximumPurchasePriceLevel = 0;
        public static int gMinimumPurchasePriceLevel = 0;
        public static bool gAllowICSNegativeStock = false;
        public static bool gAllowSaleBelowCost = false;
        public static bool gAllowFuturedateTransaction = false;
        public static bool gShowMessageOnReorderLevel = false;
        public static bool gShowMessageOnMinimumLevel = false;
        public static bool gShowMessageOnMaximumLevel = false;
        //''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




        public static string gCompName = "";
        public static string gCompName2 = "";
        public static string gAdd1 = "";
        public static string gAdd2 = "";
        public static string gDefaultCurrencySymbol = "";
        public static Language gPreferedLanguage = (Language)0; //define system prefered language
        public static System.DateTime gCurrentDate = DateTime.FromOADate(0); //define current system date
        public static string gDefaultStyle = "";
        public static string gCurrentPeriodStarts = "";
        public static string gCurrentPeriodEnds = "";
        public static string gNextPeriodStarts = "";
        public static string gNextPeriodEnds = "";
        public static bool gSkipTextBoxLostFocus = false;
        public static string gProductPicturesPath = "";
        public static string gEmailPayslipPath = "";
        public static string gEmpDocumentPath = "";
        public static string gPayrollGLFilePath = "";
        public static string gSystemDateFormat = "";
        public static string gDisplayDateFormat = "";
        public static string gInputDateFormat = "";
        public static string gDateValueFormat = "";
        public static string gComputerDateFormat = "";
        public static string gReportFilesFolder = "";
        public static int gPOSCounterCode = 0;
        public static bool gRestrictBackDatedReport = false;
        public enum DataType
        {
            NumberType = 1,
            StringType = 2,
            DateType = 3,
            BooleanType = 4
        }

        //These variable is for Error Handling (Moiz Hakimi 25/09/2008)
        public static int gError_Id = 0;
        public static string gModule_Name = "";
        public static string gLine_No = "";

        //to get the current form mode (e.g. whether the form is in Add Mode or Edit Mode)
        public enum SystemFormModes
        {
            frmAddMode = 1,
            frmEditMode = 2
        }

        //to get the current report mode (e.g. whether the report is in normal mode or preview mode
        public enum SystemReportModes
        {
            rptNormalMode = 1,
            rptPreviewMode = 2
        }

        //to set the language
        public enum Language
        {
            English = 1,
            Arabic = 2
        }

        //to set the Cursortype for ClsDatacontrol class
        public enum CursorType
        {
            ForwardOnly = 1,
            Keyset = 2
        }

        //to set the CursorLocation for ClsDatacontrol class
        public enum CursorLocation
        {
            ClientSide = 1
        }

        public enum TextAlignment
        {
            LeftJustify = 0,
            RightJustify = 1,
            CenterJustify = 2
        }

        public enum VoucherStatus
        {
            stActive = 1,
            stPosted = 2,
            stVoid = 3,
            stAutoGenerated = 4
        }


        public enum SystemObjectTypes
        {
            objForm = 1,
            objReport = 2,
            objMenu = 3,
            objAccntVoucherType = 4,
            objInvntVoucherType = 5,
            objReportColumn = 6,
            objCompany = 7,
            objLocation = 8
        }

        //Public Enum DataTransferType
        //    ExportData = 0
        //    ImportData = 1
        //End Enum


        public enum EmployeeStatus
        {
            Active = 1,
            OnLeave = 2,
            Terminated = 3
        }

        public enum enmPopupType
        {
            eLeave = 1,
            eResume = 2,
            eDocument = 3,
            eVehicle = 4,
            eHold = 5
        }

        //UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis#2041
        //[DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        //extern public static int SetWindowPos(int hWnd, int hWndInsertAfter, int x, ref object y, int cx, int cy, int wFlags);
        public const int HWND_TOPMOST = -1;
        public const int HWND_NOTOPMOST = -2;
        public const int SWP_NOMOVE = 0x2;
        public const int SWP_NOSIZE = 0x1;
        static readonly public int TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        public const string mTypeForm = "FRM";
        public const string mTypeReport = "RPT";
        public const string mTypeCommand = "CMD";
        public const string mTypeMenu = "MNU";
        public const string mTypeCrystal = "CRT";
        public const string mTypeApollo = "APL";
        public const string mTypeAccountVoucher = "ACT";
        public const string mTypeInventoryVoucher = "IVT";
    }
}