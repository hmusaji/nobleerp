using CoreHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xtreme
{
    public class SystemProcedure
    {
        internal static string GetComputerNamePOS()
        {
            string strString = "HMHM";
            return strString;
        }
        internal static int CheckUserValidity(int pCompanyID, int pLoginCompanyID, string pUserID, string pUserPassword, ref int pUserLocationCode, bool pMISuperUser, bool pLoginCompanyPrompted, ref bool pLoginLocationPrompted)
        {
            int result = 0;
            string mysql = "";
            SqlDataReader rsLocalRec = null;
            clsAccessAllowed UserAccess = new clsAccessAllowed();
            object mTempValue = null;

            try
            {

                SystemVariables.gXtremeAdminLoggedIn = pUserID == SystemConstants.gDSAdminID && pUserPassword == SystemConstants.gDSAdminPassword;

                if ((pUserID == SystemConstants.gDSAdminID && pUserPassword == SystemConstants.gDSAdminPassword) || pMISuperUser)
                {
                    SystemVariables.gMISuperUser = true;
                }

             
                if (!pLoginLocationPrompted)
                {
                    if (pUserLocationCode == 0)
                    {
                        pUserLocationCode = SystemConstants.gDefaultLocationCode;
                    }
                }
                if (pLoginLocationPrompted)
                {
                    if (!SystemVariables.gXtremeAdminLoggedIn)
                    {
                        pLoginLocationPrompted = ~ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select Access_all_location from SM_USERS where User_Id ='" + pUserID + "'")) != 0;
                    }
                    else
                    {
                        pLoginLocationPrompted = false;
                    }
                }

                SystemVariables.gLoggedInSingleLocation = pLoginLocationPrompted;

                //-------------------Added by Moiz Hakimi-------05-May-2010--------
                if (!SystemVariables.gXtremeAdminLoggedIn)
                {
                    //UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
                    SystemVariables.gDefaultFinalReportLevel = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select Default_final_report_level from SM_USERS where User_Id ='" + pUserID + "'"));
                }
                else
                {
                    SystemVariables.gDefaultFinalReportLevel = 7;
                }
                //-----------------------------------------------------------------

                if (!SystemVariables.gXtremeAdminLoggedIn)
                {
                    //UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
                    mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Default_Style from SM_USERS where User_Id ='" + pUserID + "'"));
                    //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
                    if (!Convert.IsDBNull(mTempValue))
                    {
                        //UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
                        SystemVariables.gDefaultStyle = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
                    }
                }
                //---------------------------------------------------------------------

                //****Check for the UserID and Password Validation
                if (SystemVariables.gXtremeAdminLoggedIn)
                {
                    mysql = "select * from SM_USERS ";
                    mysql = mysql + " where user_cd = " + TypeParser.ParseString(SystemConstants.gDefaultAdminUserCode);
                }
                else if (pMISuperUser)
                {
                    mysql = "select * from SM_USERS su ";
                    mysql = mysql + " where (su.user_id = '" + pUserID + "')";
                    mysql = mysql + " and (su.password = '" + pUserPassword + "')";
                    mysql = mysql + " and su.disabled = 0 ";
                }
                else
                {
                    mysql = "select * from SM_USERS su ";
                    mysql = mysql + " where (su.user_id = '" + pUserID + "')";
                    mysql = mysql + " and (su.password = '" + pUserPassword + "')";
                    mysql = mysql + " and su.disabled = 0 ";
                    mysql = mysql + " and exists ";
                    mysql = mysql + " ( select * from SM_USER_GROUP_RIGHTS sugr ";
                    mysql = mysql + " where sugr.right_level <> 0 and sugr.group_cd = su.group_cd ";
                    mysql = mysql + " and comp_id = " + TypeParser.ParseString(pCompanyID) + ")";
                    if (SystemVariables.gLoggedInSingleLocation)
                    {
                        mysql = mysql + " and exists ";
                        mysql = mysql + " ( select * from SM_USER_GROUP_RIGHTS sugr ";
                        mysql = mysql + " where sugr.right_level <> 0 and sugr.group_cd = su.group_cd ";
                        mysql = mysql + " and sugr.locat_cd = " + TypeParser.ParseString(pUserLocationCode);
                        mysql = mysql + " and sugr.comp_id = " + TypeParser.ParseString(pCompanyID) + ")";
                    }
                }



                rsLocalRec = SharpHelper.GetSqlDataReader(mysql);
                if (rsLocalRec.Read())
                {
                    SystemVariables.gLoggedInUserCode = Convert.ToInt32(rsLocalRec["user_cd"]);
                    SystemVariables.gLoggedInUserID = Convert.ToString(rsLocalRec["user_id"]);
                    SystemVariables.gLoggedInUserGroupCode = Convert.ToInt32(rsLocalRec["group_cd"]);
                    SystemVariables.gLoggedInUserLocationCode = pUserLocationCode;
                    SystemVariables.gPreferedLanguage = (Convert.ToString(rsLocalRec["preferred_language"]).ToUpper() == ("L").ToUpper()) ? SystemVariables.Language.English : SystemVariables.Language.Arabic;

                    //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    //''''''For User level price security
                    if (Convert.IsDBNull(rsLocalRec["default_sales_price_level"]))
                    {
                        SystemVariables.gDefaultSalesPriceLevel = 0;
                    }
                    else
                    {
                        SystemVariables.gDefaultSalesPriceLevel = Convert.ToInt32(rsLocalRec["default_sales_price_level"]);
                    }

                    if (!Convert.IsDBNull(rsLocalRec["default_sman_no"]))
                    {
                        SystemVariables.gDefaultUserLevelSmanNo = Convert.ToString(rsLocalRec["default_sman_no"]);
                    }

                    SystemVariables.gEnableUserLevelCostDetails = Convert.ToBoolean(rsLocalRec["enable_cost_details"]);

                    SystemVariables.gEnablePayrollExpiryPopup = Convert.ToBoolean(rsLocalRec["enable_pay_exp_rep_pop"]);

                    SystemVariables.gRestrictOnExceedingCreditLimit = Convert.ToBoolean(rsLocalRec["restrict_on_exceeding_credit_limit"]);


                    if (Convert.IsDBNull(rsLocalRec["default_purchase_price_level"]))
                    {
                        SystemVariables.gDefaultPurchasePriceLevel = 0;
                    }
                    else
                    {
                        SystemVariables.gDefaultPurchasePriceLevel = Convert.ToInt32(rsLocalRec["default_purchase_price_level"]);
                    }

                    SystemVariables.gEnableSalesPriceRestrictions = Convert.ToBoolean(rsLocalRec["enable_sales_price_restrictions"]);
                    SystemVariables.gEnablePurchasePriceRestrictions = Convert.ToBoolean(rsLocalRec["enable_purchase_price_restrictions"]);

                    if (Convert.IsDBNull(rsLocalRec["restrict_in_sales_price_levels"]))
                    {
                        SystemVariables.gRestrictInSalesPriceLevels = false;
                    }
                    else
                    {
                        SystemVariables.gRestrictInSalesPriceLevels = Convert.ToBoolean(rsLocalRec["restrict_in_sales_price_levels"]);
                    }

                    if (Convert.IsDBNull(rsLocalRec["restrict_in_purchase_price_levels"]))
                    {
                        SystemVariables.gRestrictInPurchasePriceLevels = false;
                    }
                    else
                    {
                        SystemVariables.gRestrictInPurchasePriceLevels = Convert.ToBoolean(rsLocalRec["restrict_in_purchase_price_levels"]);
                    }

                    if (Convert.IsDBNull(rsLocalRec["maximum_sales_price_level"]))
                    {
                        SystemVariables.gMaximumSalesPriceLevel = 0;
                    }
                    else
                    {
                        SystemVariables.gMaximumSalesPriceLevel = Convert.ToInt32(rsLocalRec["maximum_sales_price_level"]);
                    }

                    if (Convert.IsDBNull(rsLocalRec["minimum_sales_price_level"]))
                    {
                        SystemVariables.gMinimumSalesPriceLevel = 0;
                    }
                    else
                    {
                        SystemVariables.gMinimumSalesPriceLevel = Convert.ToInt32(rsLocalRec["minimum_sales_price_level"]);
                    }

                    if (Convert.IsDBNull(rsLocalRec["maximum_product_sales_discount_in_percent"]))
                    {
                        SystemVariables.gMaximumProductSalesDiscountInPercent = 0;
                    }
                    else
                    {
                        SystemVariables.gMaximumProductSalesDiscountInPercent = Convert.ToDecimal(rsLocalRec["maximum_product_sales_discount_in_percent"]);
                    }

                    if (Convert.IsDBNull(rsLocalRec["maximum_voucher_sales_discount_in_percent"]))
                    {
                        SystemVariables.gMaximumVoucherSalesDiscountInPercent = 0;
                    }
                    else
                    {
                        SystemVariables.gMaximumVoucherSalesDiscountInPercent = Convert.ToDecimal(rsLocalRec["maximum_voucher_sales_discount_in_percent"]);
                    }

                    if (Convert.IsDBNull(rsLocalRec["maximum_product_purchase_discount_in_percent"]))
                    {
                        SystemVariables.gMaximumProductPurchaseDiscountInPercent = 0;
                    }
                    else
                    {
                        SystemVariables.gMaximumProductPurchaseDiscountInPercent = Convert.ToDecimal(rsLocalRec["maximum_product_purchase_discount_in_percent"]);
                    }

                    if (Convert.IsDBNull(rsLocalRec["maximum_voucher_purchase_discount_in_percent"]))
                    {
                        SystemVariables.gMaximumVoucherPurchaseDiscountInPercent = 0;
                    }
                    else
                    {
                        SystemVariables.gMaximumVoucherPurchaseDiscountInPercent = Convert.ToDecimal(rsLocalRec["maximum_voucher_purchase_discount_in_percent"]);
                    }

                    if (Convert.IsDBNull(rsLocalRec["maximum_purchase_price_level"]))
                    {
                        SystemVariables.gMaximumPurchasePriceLevel = 0;
                    }
                    else
                    {
                        SystemVariables.gMaximumPurchasePriceLevel = Convert.ToInt32(rsLocalRec["maximum_purchase_price_level"]);
                    }

                    if (Convert.IsDBNull(rsLocalRec["minimum_purchase_price_level"]))
                    {
                        SystemVariables.gMinimumPurchasePriceLevel = 0;
                    }
                    else
                    {
                        SystemVariables.gMinimumPurchasePriceLevel = Convert.ToInt32(rsLocalRec["minimum_purchase_price_level"]);
                    }

                    //'Added by: Moiz Hakimi. Date:12-apr-2008
                    if (Convert.IsDBNull(rsLocalRec["Allow_ICS_Negative_Stock"]))
                    {
                        SystemVariables.gAllowICSNegativeStock = false;
                    }
                    else
                    {
                        SystemVariables.gAllowICSNegativeStock = Convert.ToBoolean(rsLocalRec["Allow_ICS_Negative_Stock"]);
                    }

                    if (Convert.IsDBNull(rsLocalRec["Allow_Sale_Below_Cost"]))
                    {
                        SystemVariables.gAllowSaleBelowCost = false;
                    }
                    else
                    {
                        SystemVariables.gAllowSaleBelowCost = Convert.ToBoolean(rsLocalRec["Allow_Sale_Below_Cost"]);
                    }
                    //'Added by: Moiz Hakimi. Date:22-Dec-2008
                    if (Convert.IsDBNull(rsLocalRec["Allow_Future_date_Transaction"]))
                    {
                        SystemVariables.gAllowFuturedateTransaction = false;
                    }
                    else
                    {
                        SystemVariables.gAllowFuturedateTransaction = Convert.ToBoolean(rsLocalRec["Allow_Future_date_Transaction"]);
                    }

                    //'Added by: Moiz Hakimi. Date:10-Feb-2008
                    if (Convert.IsDBNull(rsLocalRec["Show_Message_On_Items_Below_Reorder_Level"]))
                    {
                        SystemVariables.gShowMessageOnReorderLevel = false;
                    }
                    else
                    {
                        SystemVariables.gShowMessageOnReorderLevel = Convert.ToBoolean(rsLocalRec["Show_Message_On_Items_Below_Reorder_Level"]);
                    }

                    if (Convert.IsDBNull(rsLocalRec["Show_Message_On_Items_Below_Minimum_Level"]))
                    {
                        SystemVariables.gShowMessageOnMinimumLevel = false;
                    }
                    else
                    {
                        SystemVariables.gShowMessageOnMinimumLevel = Convert.ToBoolean(rsLocalRec["Show_Message_On_Items_Below_Minimum_Level"]);
                    }

                    if (Convert.IsDBNull(rsLocalRec["Show_Message_On_Items_Above_Maximum_Level"]))
                    {
                        SystemVariables.gShowMessageOnMaximumLevel = false;
                    }
                    else
                    {
                        SystemVariables.gShowMessageOnMaximumLevel = Convert.ToBoolean(rsLocalRec["Show_Message_On_Items_Above_Maximum_Level"]);
                    }

                    SystemVariables.gRestrictBackDatedReport = Convert.ToBoolean(rsLocalRec["Restrict_back_dated_report"]);
                    //'End Add

                    //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                }
                else
                {
                    result = 1;
                    goto EndFunction;
                }
                rsLocalRec.Close();
                //**------------------------------------------------------------------------------------------------------
                //**--setting company level properties

                mysql = "select * from SM_COMPANY where comp_id = " + TypeParser.ParseString(pLoginCompanyID); //Str(pCompanyID)
                SystemVariables.rsCompanyProperties = new DataSet();
                string strInfo = new string('\0', 11);
                char padChar = '\0';
                string lngIdentifier = "";
                string lngResult = "";
                string tempFormat = "";
                SystemVariables.rsCompanyProperties = SharpHelper.GetDataSet(mysql);

                
                if (SystemVariables.rsCompanyProperties.Tables[0].Rows.Count != 0)
                {
                    SystemVariables.gCompanyID = Convert.ToInt32(TypeParser.ParseInt(Convert.ToString(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["comp_id"])));
                    SystemVariables.gDatabaseName = Convert.ToString(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["db_alias"]);
                    SystemVariables.gCompName = Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["l_comp_name"] : SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["a_comp_name"]).Trim();
                    SystemVariables.gCompName2 = Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["a_comp_name"] : SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["l_comp_name"]).Trim();
                    SystemVariables.gAdd1 = (Convert.ToString(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["addr_1"]) + "").Trim();
                    SystemVariables.gAdd2 = (Convert.ToString(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["addr_2"]) + "").Trim();
                    SystemVariables.gSystemDateFormat = "dd-mmm-yyyy";
                    SystemVariables.gDisplayDateFormat = Convert.ToString(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["Date_Format"]);
                    SystemVariables.gInputDateFormat = Convert.ToString(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["Input_Date_Format"]);
                    SystemVariables.gDateValueFormat = Convert.ToString(SystemVariables.rsCompanyProperties.Tables[0].Rows[0]["Date_Format"]);


                    lngIdentifier = "manual-en-KW";
                    lngResult = "manual-lngResult";
                    strInfo = StringsHelper.GetFixedLengthString(strInfo, 11);

                    SystemVariables.gComputerDateFormat = (strInfo.Substring(Math.Max(strInfo.Length - 1, 0)) == Convert.ToString(padChar)) ? strInfo.Substring(0, Math.Min(10, strInfo.Length)) : strInfo;
                    //Dim lngLocale As Long
                    //Dim rslt As String

                    //lngLocale = GetSystemDefaultLCID()

                    //rslt = GetUserLocaleInfo(lngLocale, LOCALE_SSHORTDATE)

                    //If GetLocaleInfo(lngLocale, LOCALE_SSHORTDATE, "dd/MMM/yyyy") = False Then
                    //If SetLocaleInfo(lngLocale, LOCALE_SSHORTDATE, "dd/MMM/yyyy") = False Then
                    //MsgBox "Can not change regional setting. Access denied!"
                    //End If
                    //End If

                }
                else
                {
                    result = 2;
                    goto EndFunction;
                }
                //**------------------------------------------------------------------------------------------------------
                //**--checking user rights on the selected company
                if (SystemVariables.gLoggedInUserCode != SystemConstants.gDefaultAdminUserCode)
                {
                    UserAccess.CheckAccess(SystemVariables.gCompanyID, SystemVariables.SystemObjectTypes.objCompany);
                    if (!UserAccess.AllowUserDisplay)
                    {
                        result = 3;
                        goto EndFunction;
                    }
                }
                //**------------------------------------------------------------------------------------------------------
                //**--checking user login location (whether the login location is a head office or a pos)
                //UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
                SystemVariables.gPrimaryLocationCode = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select locat_cd from SM_Location where is_primary_location = 1"));
                //UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
                mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name") + " from SM_Location where locat_cd = " + SystemVariables.gLoggedInUserLocationCode.ToString()));
                //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
                if (!Convert.IsDBNull(mTempValue))
                {
                    //UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
                    SystemVariables.gLoggedInUserLocationName = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
                }
                else
                {
                    frmSysSplash.DefInstance.Hide();
                    throw new Exception();
                }

                //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
                if (Convert.IsDBNull(SystemVariables.gPrimaryLocationCode))
                {
                    SystemVariables.gPrimaryLocationCode = SystemConstants.gDefaultLocationCode;
                }
                if (!IsHeadOffice(pCompanyID))
                {
                    if (SystemVariables.gLoggedInUserLocationCode == SystemVariables.gPrimaryLocationCode)
                    {
                        if (!SystemVariables.gXtremeAdminLoggedIn)
                        {
                            result = 4;
                        }
                        else
                        {
                            mysql = "Logging super user into the system.";
                            mysql = mysql + "\r" + "Entering system in offline mode for the first time.";
                            mysql = mysql + "\r" + "No transactions should be made in this mode!!!";
                            if (frmSysSplash.DefInstance.Visible)
                            {
                                frmSysSplash.DefInstance.Hide();
                            }
                            MessageBox.Show(mysql, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        goto EndFunction;
                    }
                }
            //**------------------------------------------------------------------------------------------------------
            EndFunction:
                UserAccess = null;
            }
            catch (System.Exception excep)
            {

                frmSysSplash.DefInstance.Close();
                MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = 1;
            }
            return result;
        }

        internal static bool IsHeadOffice(int CompanyID)
        {

            bool result = false;
            string mysql = "select enabled from SM_PARAMETER ";
            mysql = mysql + " where feature_name = 'is_head_office' ";

            //UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
            object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
            //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
            if (Convert.IsDBNull(mReturnValue))
            {
                result = false;
            }
            else
            {
                result = ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue);
                SystemVariables.gIsHeadOffice = result;
            }
            return result;
        }
    }
}
