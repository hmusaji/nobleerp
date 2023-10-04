using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtreme
{
    internal static class SystemConstants
    {


        public const string gAppName = "Xtreme Innova";
        public const string gAppShortName = "Innova";
        //Global Const gSQLServerUserID As String = "expert"
        //Global Const gSQLServerPassword  As String = "SoftTiger1983"
        public const string gProvider = "SQLOLEDB.1";

        //**--define system modules constants
        public const int gModuleGlobalID = 1;
        public const int gModuleGLID = 2;
        public const int gModuleAPID = 3;
        public const int gModuleARID = 4;
        public const int gModulePurchaseID = 5;
        public const int gModuleSalesID = 6;
        public const int gModuleICSID = 7;
        public const int gModuleHRID = 8;
        public const int gModulePayID = 9;
        public const int gModuleFixedAssetsID = 10;
        public const int gModuleRealEstateID = 11;



        //**--define system constants
        public static string gSystemDatabaseName = "";
        public const int gDefaultAdminUserCode = 1;
        public const int gDefaultAdminGroupCode = 1;
        public const int gDefaultCompanyID = 1;
        public const int gDefaultLocationCode = 1;

        //define form level default contants
        public const int mFixedHeight = 6135;
        public const int mFixedWidth = 9570;

        //--** define constants for user access rights / permissions
        public const int DisplayLevelAccess = 1;
        public const int PrintLevelAccess = 2;
        public const int CreateLevelAccess = 4;
        public const int UpdateLevelAccess = 8;

        public const string gErrCaption = "Error:";

        //system defined messeges
        public const string msg1 = "Invalid Connection Information, Contact the System Adminstrator";
        public const string msg2 = "Are you sure you want to Exit ?";
        public const string msg3 = " Do you want to Save Changes ?";
        public const string msg4 = "Do you want to Delete the Record?";
        public const string msg5 = "Do you want to Save the Record?";
        public const string msg6 = "Do you want to Update Changes?";
        public const string msg7 = "Do you want to Post the Record(s)?"; //& Chr(13) & "Press, " & Chr(13) & " (YES), for post after saving . " & Chr(13) & " (NO), for post without saving " & Chr(13) & " (Cancel), for exit without posting "
        public const string msg8 = "Access Denied, Contact the System Adminstrator ";
        public const string msg9 = "Permission Denied";
        public const string msg10 = "Record cannot be updated, the value of a column has been changed since it was last read";
        public const string msg11 = "Record has already been deleted";
        public const string msg12 = "Record is protected by the system";
        public const string msg13 = "Code not found";
        public const string msg14 = "Invalid parent code";
        public const string msg15 = "Record has already been Posted";
        public const string msg16 = ", Cannot be Saved!";
        public const string msg17 = ", Cannot be Deleted!";
        public const string msg18 = "Quantity cannot be Negative";
        public const string msg19 = "Note : Posting of voucher will automatically save the record ! ";
        public const string msg20 = " Voucher has been saved with no :- ";
        public const string msg21 = " and Posted to Inventory ";
        public const string msg22 = " and Posted to GL ";
        public const string msg23 = ", Cannot be posted!";
        public const string msg24 = " Delete the linked voucher, in order to modify this voucher ! ";
        public const string msg25 = "Do you want to print the voucher?";
        //Global Const msg25 = "Auto Generated Voucher
        public const string msg26 = "Posted Voucher ";
        public const string msg27 = "Deleted Voucher";
        public const string msg28 = "Auto Generated Voucher";

        public const string msg29 = "Transaction exists in the Offline Database. Item cannot be deleted or modified! ";
        // To Add Prompt For Delete Line
        public const string msg30 = "Do you want to Delete this Line?";

        public const string gDisableColumnBackColor = "&HD5D5D5";
        public const string gDBBackupFileExtension = "dfb";

        public const string gDSAdminID = "HSAdmin";
        public const string gDSAdminPassword = "HSSql2005";


        public const string gArabicFontName = "Arabic Transparent";
        public const string gEnglishFontName = "Arial";
        public const string gArabicFontName1 = "MS Sans Serif"; //"Simplified Arabic Bold"   '

        public const int gToolButtonNew = 456;
        public const int gToolButtonSave = 698;
        public const int gToolButtonDelete = 202;
        public const int gToolButtonVoid = 204;
        public const int gToolButtonPrint = 541;
        public const int gToolButtonFind = 276;
        public const int gToolButtonDrillDown = 225;
        public const int gToolButtonDrillUp = 226;
        public const int gToolButtonProductPicture = 552;
        public const int gToolButtonMoveRecordTop = 1838;
        public const int gToolButtonMoveRecordPrevious = 1839;
        public const int gToolButtonMoveRecordNext = 1840;
        public const int gToolButtonMoveRecordBottom = 1841;
        public const int gToolButtonInsertLine = 322;
        public const int gToolButtonDeleteLine = 203;
        public const int gToolButtonCheckAll = 1830;
        public const int gToolButtonUncheckAll = 1829;
        public const int gToolButtonExpandAll = 1835;
        public const int gToolButtonCollapesAll = 1836;
        public const int gToolButtonPost = 1827;
        public const int gToolButtonUnpost = 1937;
        public const int gToolButtonSourceTran = 1828;
        public const int gToolButtonGLTran = 1837;
        public const int gToolButtonBarcode = 2184;

        public const int gToolButtonEmpDetail = 1842;
        public const int gToolButtonEmpPayrol = 1843;
        public const int gToolButtonEmpLeave = 1844;
        public const int gToolButtonEmpIndemnity = 1845;
        public const int gToolButtonEmpFixedSalary = 1846;
        public const int gToolButtonEmpDocument = 1847;

        public const int gToolButtonHelp = 308;
        public const int gToolButtonExit = 261;
        public const int gToolButtonSelect = 702;
        public const int gToolButtonColumns = 1419;
        public const int gToolButtonPayment = 2178;
        public const int gToolButtonFavorite = 2181;
        public const int gToolButtonImport = 311;
        public const int gToolButtonExitAll = 312;
        public const int gToolButtonExitAllButThis = 313;

        //-----------------Report Toolbar-------------------------------
        //**--give the contants as the Label ID of the option (from SM_LABLES)
        public const int tbnDrillDown = 11;
        public const int tbnDrillUp = 12;
        public const int tbnReportOptions = 13;
        public const int tbnNormalMode = 14;
        public const int tbnPreivewMode = 15;
        public const int tbnPrintReport = 16;
        public const int tbnPageSetup = 17;
        public const int tbnExportReport = 18;
        public const int tbnFindText = 19;
        public const int tbnSaveReport = 20;
        public const int tbnHelp = 21;
        public const int tbnExit = 22;
        public const int tbnMoveFirstPage = 23;
        public const int tbnMovePreviousPage = 24;
        public const int tbnMoveNextPage = 25;
        public const int tbnMoveLastPage = 26;
        public const int tbnZoomPreview = 27;

        public const int tbnZoomPreview25 = 28;
        public const int tbnZoomPreview50 = 29;
        public const int tbnZoomPreview75 = 30;
        public const int tbnZoomPreview100 = 31;
        public const int tbnZoomPreview125 = 32;
        public const int tbnZoomPreview150 = 33;
        public const int tbnZoomPreview200 = 34;
        public const int tbnZoomPreview300 = 35;
        public const int tbnZoomPreview400 = 36;
        public const int tbnRefresh = 37;
        public const int tbnSaveAsReport = 38;
        //---------------------------------------------------------------------------

        //**-- this contant value is used for beta version compilation
        //**-- (i.e. if this value is false then "Current" file versions will be used
        //**-- or else the beta file versions will be used in debug as well as execution mode)
        //**-- created by : Moiz Hakimi
        //**-- created on : 26-feb-2006
        public const bool gCompileInBetaMode = true;

        public const int gFormTab = 1;
        public const int gReportTab = 2;

        public const int gFormTabGroup = 10001;
        public const int gReportTabGroup = 10002;

        public const int gStatusDate = 1;
        public const int gStatusUser = 2;
        public const int gStatusReport = 3;
        public const int gICSPostingStatus = 4;
        public const int gGLPostingStatus = 5;
        public const int gStatusToolTip = 6;
        public const int gStatusLocation = 7;
        public const int gStatusZoom = 8;
        public const int gStatusSlider = 9;
    }
}