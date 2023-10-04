using CoreHelper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xtreme
{
    public class clsAccessAllowed
    {


        private bool mAllowUserAdd = false; //local copy
        private bool mAllowUserUpdate = false; //local copy
        private bool mAllowUserDelete = false; //local copy
        private bool mAllowUserDisplay = false; //local copy
        private bool mAllowUserPrint = false; //local copy
        private bool mDeniedAccess = false;
        private bool mAllowFullAccess = false;

        public void CheckAccess(int pObjectID, SystemVariables.SystemObjectTypes pObjectType = (SystemVariables.SystemObjectTypes)0, int pChildObjectID = 0)
        {
            try
            {
                if (SystemVariables.gLoggedInUserCode == SystemConstants.gDefaultAdminUserCode)
                {
                    mAllowUserAdd = true;
                    mAllowUserUpdate = true;
                    mAllowUserDelete = true;
                    mAllowUserDisplay = true;
                    mAllowUserPrint = true;
                    mAllowFullAccess = true;

                    return;
                }

                SqlDataReader localRec = null;
                string mySql = "";

                switch (pObjectType)
                {
                    case SystemVariables.SystemObjectTypes.objCompany:
                        mySql = " select object_table.*, sugr.right_level from ";
                        mySql = mySql + " sm_company object_table ";
                        mySql = mySql + " inner join SM_USER_GROUP_RIGHTS sugr ";
                        mySql = mySql + " on object_table.comp_id = sugr.comp_id ";
                        mySql = mySql + " inner join SM_USER_GROUPS sug ";
                        mySql = mySql + " on sugr.group_cd = sug.group_cd ";
                        mySql = mySql + " inner join SM_USERS su on sug.group_cd = su.group_cd";
                        mySql = mySql + " Where su.user_cd = " + TypeParser.ParseString(SystemVariables.gLoggedInUserCode);
                        mySql = mySql + " and sugr.right_level <> 0 ";
                        mySql = mySql + " and object_table.show = 1 ";
                        mySql = mySql + " and object_table.comp_id = " + TypeParser.ParseString(pObjectID);
                        break;
                    case SystemVariables.SystemObjectTypes.objForm:
                        mySql = " select object_table.*, sugr.right_level from ";
                        mySql = mySql + " SM_FORM object_table ";
                        mySql = mySql + " inner join SM_USER_GROUP_RIGHTS sugr ";
                        mySql = mySql + " on object_table.form_id = sugr.form_id ";
                        mySql = mySql + " inner join SM_USER_GROUPS sug ";
                        mySql = mySql + " on sugr.group_cd = sug.group_cd ";
                        mySql = mySql + " inner join SM_USERS su on sug.group_cd = su.group_cd";
                        mySql = mySql + " Where su.user_cd = " + TypeParser.ParseString(SystemVariables.gLoggedInUserCode);
                        mySql = mySql + " and sugr.right_level <> 0 ";
                        mySql = mySql + " and object_table.show = 1 ";
                        mySql = mySql + " and object_table.form_id = " + TypeParser.ParseString(pObjectID);
                        break;
                    case SystemVariables.SystemObjectTypes.objReport:
                        mySql = " select sugr.right_level from ";
                        mySql = mySql + " SM_Reports object_table ";
                        mySql = mySql + " inner join SM_USER_GROUP_RIGHTS sugr ";
                        mySql = mySql + " on object_table.report_id = sugr.report_id ";
                        mySql = mySql + " inner join SM_USER_GROUPS sug ";
                        mySql = mySql + " on sugr.group_cd = sug.group_cd ";
                        mySql = mySql + " inner join SM_USERS su on sug.group_cd = su.group_cd";
                        mySql = mySql + " Where su.user_cd = " + TypeParser.ParseString(SystemVariables.gLoggedInUserCode);
                        mySql = mySql + " and sugr.right_level <> 0 ";
                        mySql = mySql + " and object_table.show = 1 ";
                        mySql = mySql + " and object_table.report_id = " + TypeParser.ParseString(pObjectID);
                        break;
                    case SystemVariables.SystemObjectTypes.objMenu:
                        break;
                    case SystemVariables.SystemObjectTypes.objAccntVoucherType:
                        mySql = "select sugr.right_level from ";
                        mySql = mySql + SystemVariables.gDatabaseName + "..gl_accnt_voucher_types object_table ";
                        mySql = mySql + " inner join SM_USER_GROUP_RIGHTS sugr ";
                        mySql = mySql + " on object_table.voucher_type = sugr.accnt_voucher_type ";
                        mySql = mySql + " inner join SM_USER_GROUPS sug ";
                        mySql = mySql + " on sugr.group_cd = sug.group_cd ";
                        mySql = mySql + " inner join SM_USERS su ";
                        mySql = mySql + " on sug.group_cd = su.group_cd ";
                        mySql = mySql + " Where su.user_cd =   " + TypeParser.ParseString(SystemVariables.gLoggedInUserCode);
                        mySql = mySql + " and sugr.right_level <> 0 and object_table.show = 1 ";
                        mySql = mySql + " and object_table.voucher_type = " + TypeParser.ParseString(pObjectID);
                        break;
                    case SystemVariables.SystemObjectTypes.objInvntVoucherType:
                        mySql = "select sugr.right_level from ";
                        mySql = mySql + SystemVariables.gDatabaseName + "..ICS_Transaction_Types object_table ";
                        mySql = mySql + " inner join SM_USER_GROUP_RIGHTS sugr ";
                        mySql = mySql + " on object_table.voucher_type = sugr.invnt_voucher_type ";
                        mySql = mySql + " inner join SM_USER_GROUPS sug ";
                        mySql = mySql + " on sugr.group_cd = sug.group_cd ";
                        mySql = mySql + " inner join SM_USERS su ";
                        mySql = mySql + " on sug.group_cd = su.group_cd ";
                        mySql = mySql + " Where su.user_cd =   " + TypeParser.ParseString(SystemVariables.gLoggedInUserCode);
                        mySql = mySql + " and sugr.right_level <> 0 and object_table.show = 1 ";
                        mySql = mySql + " and object_table.voucher_type = " + TypeParser.ParseString(pObjectID);
                        //Added By Moiz Hakimi 
                        //Date: 24-Jan-2008 
                        break;
                    case SystemVariables.SystemObjectTypes.objLocation:
                        mySql = "select sugr.right_level from ";
                        mySql = mySql + SystemVariables.gDatabaseName + "..SM_Location object_table ";
                        mySql = mySql + " inner join SM_USER_GROUP_RIGHTS sugr ";
                        mySql = mySql + " on object_table.locat_cd = sugr.locat_cd ";
                        mySql = mySql + " inner join SM_USER_GROUPS sug ";
                        mySql = mySql + " on sugr.group_cd = sug.group_cd ";
                        mySql = mySql + " inner join SM_USERS su ";
                        mySql = mySql + " on sug.group_cd = su.group_cd ";
                        mySql = mySql + " Where su.user_cd =   " + TypeParser.ParseString(SystemVariables.gLoggedInUserCode);
                        mySql = mySql + " and sugr.right_level <> 0 and object_table.show = 1 ";
                        mySql = mySql + " and object_table.locat_cd = " + TypeParser.ParseString(pObjectID);
                        break;
                }

                SqlCommand sqlCommand = new SqlCommand(mySql, SystemVariables.gConn);
                localRec = sqlCommand.ExecuteReader();
                if (localRec.Read())
                {
                    mDeniedAccess = false;
                    switch (Convert.ToInt32(localRec["right_level"]))
                    {
                        case SystemConstants.DisplayLevelAccess:
                            mAllowUserAdd = false;
                            mAllowUserUpdate = false;
                            mAllowUserDelete = false;
                            mAllowUserDisplay = true;
                            mAllowUserPrint = false;
                            mAllowFullAccess = false;
                            break;
                        case SystemConstants.PrintLevelAccess:
                            mAllowUserAdd = false;
                            mAllowUserUpdate = false;
                            mAllowUserDelete = false;
                            mAllowUserDisplay = false;
                            mAllowUserPrint = true;
                            mAllowFullAccess = false;
                            break;
                        case SystemConstants.CreateLevelAccess:
                            mAllowUserAdd = true;
                            mAllowUserUpdate = false;
                            mAllowUserDelete = false;
                            mAllowUserDisplay = false;
                            mAllowUserPrint = false;
                            mAllowFullAccess = false;
                            break;
                        case SystemConstants.DisplayLevelAccess + SystemConstants.CreateLevelAccess:
                            mAllowUserAdd = true;
                            mAllowUserUpdate = false;
                            mAllowUserDelete = false;
                            mAllowUserDisplay = true;
                            mAllowUserPrint = false;
                            mAllowFullAccess = false;
                            break;
                        case SystemConstants.DisplayLevelAccess + SystemConstants.UpdateLevelAccess:
                            mAllowUserAdd = false;
                            mAllowUserUpdate = true;
                            mAllowUserDelete = true;
                            mAllowUserDisplay = true;
                            mAllowUserPrint = false;
                            mAllowFullAccess = false;
                            break;
                        case SystemConstants.DisplayLevelAccess + SystemConstants.PrintLevelAccess:
                            mAllowUserAdd = false;
                            mAllowUserUpdate = false;
                            mAllowUserDelete = false;
                            mAllowUserDisplay = true;
                            mAllowUserPrint = true;
                            mAllowFullAccess = false;
                            break;
                        case SystemConstants.DisplayLevelAccess + SystemConstants.CreateLevelAccess + SystemConstants.UpdateLevelAccess:
                            mAllowUserAdd = true;
                            mAllowUserUpdate = true;
                            mAllowUserDelete = true;
                            mAllowUserDisplay = true;
                            mAllowUserPrint = false;
                            mAllowFullAccess = false;
                            break;
                        case SystemConstants.DisplayLevelAccess + SystemConstants.PrintLevelAccess + SystemConstants.CreateLevelAccess:
                            mAllowUserAdd = true;
                            mAllowUserUpdate = false;
                            mAllowUserDelete = false;
                            mAllowUserDisplay = true;
                            mAllowUserPrint = true;
                            mAllowFullAccess = false;
                            break;
                        case SystemConstants.DisplayLevelAccess + SystemConstants.PrintLevelAccess + SystemConstants.UpdateLevelAccess:
                            mAllowUserAdd = false;
                            mAllowUserUpdate = true;
                            mAllowUserDelete = false;
                            mAllowUserDisplay = true;
                            mAllowUserPrint = true;
                            mAllowFullAccess = false;
                            break;
                        case SystemConstants.DisplayLevelAccess + SystemConstants.PrintLevelAccess + SystemConstants.CreateLevelAccess + SystemConstants.UpdateLevelAccess:
                            mAllowUserAdd = true;
                            mAllowUserUpdate = true;
                            mAllowUserDelete = true;
                            mAllowUserDisplay = true;
                            mAllowUserPrint = true;
                            mAllowFullAccess = true;
                            break;
                        default:
                            mAllowUserAdd = false;
                            mAllowUserUpdate = false;
                            mAllowUserDelete = false;
                            mAllowUserDisplay = false;
                            mAllowUserPrint = false;
                            mDeniedAccess = true;
                            mAllowFullAccess = false;
                            break;
                    }
                }
                else
                {
                    mAllowUserAdd = false;
                    mAllowUserUpdate = false;
                    mAllowUserDelete = false;
                    mAllowUserDisplay = false;
                    mAllowUserPrint = false;
                    mDeniedAccess = true;
                }
                localRec.Close();
            }
            catch (System.Exception excep)
            {
                //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
                MessageBox.Show((Double.Parse("\r")).ToString() + " " + excep.Message + "\r" + " " + excep.Source + "\r" + "clsAllowed::checkAccess()", SystemConstants.gErrCaption);
            }

        }

        public bool AllowUserPrint
        {
            get
            {
                return mAllowUserPrint;
            }
        }


        public bool AllowUserDisplay
        {
            get
            {
                return mAllowUserDisplay;
            }
        }


        public bool AllowUserDelete
        {
            get
            {
                return mAllowUserDelete;
            }
        }


        public bool AllowUserUpdate
        {
            get
            {
                return mAllowUserUpdate;
            }
        }


        public bool AllowUserAdd
        {
            get
            {
                return mAllowUserAdd;
            }
        }


        public bool DeniedAccess
        {
            get
            {
                return mDeniedAccess;
            }
        }


        public bool AllowFullAccess
        {
            get
            {
                return mAllowFullAccess;
            }
        }

    }
}