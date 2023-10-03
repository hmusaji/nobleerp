
using CoreHelper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;



namespace Xtreme
{
    internal partial class frmSysLogin : System.Windows.Forms.Form
    {
        private bool mShowLastLoggedInLocationWhenLogin = false;
        private bool mShowLastLoggedInCompanyWhenLogin = false;
        private DataSet rsUsersList = null;
        public DialogResult LastButtonClicked = (DialogResult)0;
        bool mFirstTime = false;

        public frmSysLogin()
        {
            InitializeComponent();
        }

        private void frmSysLogin_Load(object sender, EventArgs e)
        {
            Form_Load();
        }
        
        private void Form_Load()
        {
            bool mCompanyShowHideSetting = false;
            bool mLocationShowHideSetting = false;
            bool mLanguageShowHideSetting = false;
            object[] mObjectId = null;
            //Dim Alpha As Byte, MaskColour As Long
            //
            //  Alpha = 230
            //  MaskColour = &HFF8888
            //  Me.BackColor = MaskColour

            //SetWindowLongptr hWnd, GWL_EXSTYLE, WS_EX_LAYERED
            //SetLayeredWindowAttributes hWnd, MaskColour, Alpha, LWA_COLORKEY Or LWA_ALPHA

            mShowLastLoggedInCompanyWhenLogin = false;
            mShowLastLoggedInLocationWhenLogin = false;


            SystemVariables.rsSystemPreferences = new DataSet();
            rsUsersList = new DataSet();

            SqlDataAdapter adap = SharpHelper.GetSqlDataAdapter("select * from SM_USERS where disabled = 0");
            rsUsersList.Tables.Clear();
            adap.Fill(rsUsersList);

            //UPGRADE_ISSUE: (1046) LoadPicture Parameter 'ColorDepth' is not supported, and was removed. More Information: https://docs.mobilize.net/vbuc/ewis#1046
            //UPGRADE_ISSUE: (1046) LoadPicture Parameter 'Size' is not supported, and was removed. More Information: https://docs.mobilize.net/vbuc/ewis#1046
            Image3.Image = Image.FromFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\Styles\\Company.jpg");


            DataSet rsSystemFeatures = new DataSet();

            SqlDataAdapter adap_2 = SharpHelper.GetSqlDataAdapter("select feature_name, enabled from SM_PARAMETER ");
            rsSystemFeatures.Tables.Clear();
            adap_2.Fill(rsSystemFeatures);
            txtLocationNo.Enabled = false;
            if (SharpHelper.GetFilterData(rsSystemFeatures.Tables[0],"feature_name = 'show_company_when_login'").Rows.Count != 0)
            {
                
                if ((TypeParser.ParseBoolean (rsSystemFeatures.Tables[0].Rows[0]["enabled"].ToString())) == false)
                {
                    mCompanyShowHideSetting = false;
                }
                else
                {
                    mCompanyShowHideSetting = true;
                    SystemCombo.FillComboWithItemData(cmbCompany, "Select L_Comp_Name name, comp_id id from SM_Company");
                    //''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    //UPGRADE_ISSUE: (2064) ADODB.Recordset method rsSystemFeatures.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064

                    if (SharpHelper.GetFilterData(rsSystemFeatures.Tables[0], "feature_name = 'show_last_logged_in_company_when_login'").Rows.Count != 0)
                    {
                        //UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
                        mShowLastLoggedInCompanyWhenLogin = TypeParser.ParseBoolean(rsSystemFeatures.Tables[0].Rows[0]["enabled"].ToString());
                    }
                    //''''''''''''''''''''''''''''''''''''''''''''''''''''''

                }
            }
            else
            {
                MessageBox.Show("Incorrect System Company Settings", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            //**------------------------------------------------------------------------------
            //    If mCompanyShowHideSetting = True Then
            //--**check whether the login location should be prompted
            //UPGRADE_ISSUE: (2064) ADODB.Recordset method rsSystemFeatures.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
         
            if (SharpHelper.GetFilterData(rsSystemFeatures.Tables[0], "feature_name = 'show_location_when_login'").Rows.Count != 0)
            {
                //UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
                //UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
                if ((TypeParser.ParseBoolean(rsSystemFeatures.Tables[0].Rows[0]["enabled"].ToString())) == false)
                {
                    mLocationShowHideSetting = false;
                }
                else
                {
                    mLocationShowHideSetting = true;

                    //''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    //UPGRADE_ISSUE: (2064) ADODB.Recordset method rsSystemFeatures.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
                   
                    if (SharpHelper.GetFilterData(rsSystemFeatures.Tables[0], "feature_name = 'show_last_logged_in_location_when_login'").Rows.Count != 0)
                    {
                        //UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
                        mShowLastLoggedInLocationWhenLogin = Convert.ToBoolean(rsSystemFeatures.Tables[0].Rows[0]["enabled"]);
                    }
                    //''''''''''''''''''''''''''''''''''''''''''''''''''''''

                }
            }
            else
            {
                MessageBox.Show("Incorrect System Location Settings", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        
           
            if (SharpHelper.GetFilterData(rsSystemFeatures.Tables[0], "feature_name = 'show_language_when_login'").Rows.Count != 0)
            {
                //UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
                //UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
                if ((TypeParser.ParseBoolean(rsSystemFeatures.Tables[0].Rows[0]["enabled"].ToString())) == false)
                {
                    mLanguageShowHideSetting = false;
                }
                else
                {
                    mLanguageShowHideSetting = true;
                    mObjectId = new object[1];
                    mObjectId[0] = 1017;
                    //SystemCombo.FillComboWithSystemObjects(cmbLanguage, mObjectId);
                }
            }
            else
            {
                MessageBox.Show("Incorrect System Language Settings", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            //**------------------------------------------------------------------------------

            lblCompanyCode.Visible = mCompanyShowHideSetting;
            cmbCompany.Visible = mCompanyShowHideSetting;

            lblLocationCode.Visible = mLocationShowHideSetting;
            txtLocationNo.Visible = mLocationShowHideSetting;
            txtLocationName.Visible = mLocationShowHideSetting;
            lblLanguage.Visible = mLanguageShowHideSetting;
            cmbLanguage[0].Visible = mLanguageShowHideSetting;

            //--**check whether the last login user name should appear
            //UPGRADE_ISSUE: (2064) ADODB.Recordset method rsSystemFeatures.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
          
            

            LastButtonClicked = System.Windows.Forms.DialogResult.Cancel;
            mFirstTime = true;
            Image1.Height = this.Height - Image2.Height;

            Image3.Top = (Convert.ToInt32((this.Height - Image3.Height) / 2d));
            Image3.Left = (Convert.ToInt32((this.Width) / 2d));

        }
        private void cmbCompany_Leave(Object eventSender, EventArgs eventArgs)
        {
            object mTempValue = null;
            string mysql = "";
            int mCompanyId = 0;
            Form frmClose = null;

            int Cnt = 0;
            foreach (Form frmCloseIterator in Application.OpenForms)
            {
                frmClose = frmCloseIterator;
                if (frmClose.Name != "frmSysLogin")
                {
                    Cnt = 1;
                }
                frmClose = default(Form);
            }

            if (Cnt > 0)
            {
                MessageBox.Show("Please Close Application Before Changing Company", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCompany.SelectedValue = Convert.ToInt32(Double.Parse(InteractionHelper.GetSettingRegistryKey("Innova", "Settings", "CompanyNo", "")));
                return;
            }

            try
            {

                mCompanyId = TypeParser.ParseInt(cmbCompany.SelectedValue);
                if (mCompanyId>0)
                {
                    mysql = "select l_comp_name, a_comp_name, db_alias from SM_COMPANY where show = 1 and comp_id=" + mCompanyId.ToString();
                    //UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
                    mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql, true));
                    //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
                    if (Convert.IsDBNull(mTempValue))
                    {
                        EnableDisableLocationSetting();
                        cmbCompany.Tag = "";
                        throw new System.Exception("-9990002");
                    }
                    else
                    {
                        cmbCompany.Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array)mTempValue).GetValue(2));
                        SystemVariables.gDatabaseName = Convert.ToString(cmbCompany.Tag);
                        //UPGRADE_ISSUE: (2064) ADODB.Connection property gConn.DefaultDatabase was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
                        //SystemVariables.gConn.setDefaultDatabase(Convert.ToString(cmbCompany.Tag));
                        EnableDisableLocationSetting();

                        //''this is required so the state can be checked before calling GetSystemPreference function.
                        rsUsersList = new DataSet();

                        SqlDataAdapter adap = new SqlDataAdapter("select * from SM_USERS where disabled = 0", SystemVariables.gConn);
                        rsUsersList.Tables.Clear();
                        adap.Fill(rsUsersList);
                    }
                }
                else
                {
                    cmbCompany.Tag = "";
                    EnableDisableLocationSetting();
                }
            }
            catch (System.Exception excep)
            {
                int mReturnErrorType = 0;
                //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
                //mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "SysLogin", SystemConstants.msg10);
                cmbCompany.Focus();
            }
        }

        private void EnableDisableLocationSetting()
        {
            if (Convert.ToString(cmbCompany.Tag) == "")
            {
                txtLocationNo.Text = "";
                txtLocationName.Text = "";
                txtLocationNo.Enabled = false;
                txtUserID.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtLocationNo.Enabled = true;
                txtUserID.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void btnLogin_ClickEvent(Object eventSender, EventArgs eventArgs)
        {
            //int mReturnedErrorNo = 0;
            //bool mUserIsAdmin = false;
            //object mReturnValue = null;
            //Form frmClose = null;
            //int Cnt = 0;
            //int mLoginCompany = 0;
            ////**--to display the HourGlass
            //clsHourGlass clsHour = new clsHourGlass();

            //try
            //{


            //    Cnt = 0;
            //    foreach (Form frmCloseIterator in Application.OpenForms)
            //    {
            //        frmClose = frmCloseIterator;
            //        if (frmClose.Name != "frmSysLogin")
            //        {
            //            Cnt = 1;
            //        }
            //        frmClose = default(Form);
            //    }

            //    if (Cnt > 0)
            //    {
            //        MessageBox.Show("Please Close Application Before Switching User", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }

            //    if (!VerifyValidSystemUser())
            //    {
            //        MessageBox.Show("Error : Denied access, Invalid User Information", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtUserID.Focus();
            //        return;
            //    }

            //    if (cmbCompany.Visible && (SystemProcedure2.IsItEmpty(cmbCompany.Text, SystemVariables.DataType.StringType) || SystemProcedure2.IsItEmpty(Convert.ToString(cmbCompany.Tag), SystemVariables.DataType.StringType)))
            //    {
            //        MessageBox.Show("Error : Enter Company Information", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        cmbCompany.Focus();
            //        return;
            //    }

            //    if (txtLocationNo.Visible && (SystemProcedure2.IsItEmpty(txtLocationNo.Text, SystemVariables.DataType.NumberType) || SystemProcedure2.IsItEmpty(Convert.ToString(txtLocationNo.Tag), SystemVariables.DataType.NumberType)))
            //    {
            //        MessageBox.Show("Error : Enter Location Information", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtLocationNo.Focus();
            //        return;
            //    }

            //    //--**check whether user is admin
            //    //UPGRADE_ISSUE: (2064) ADODB.Recordset method rsUsersList.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
            //    rsUsersList.MoveFirst();
            //    //rsUsersList.Find("user_id = '" + txtUserID.Text.Trim() + "'");
            //    if (rsUsersList.Tables[0].Rows.Count != 0)
            //    {
            //        //UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
            //        mUserIsAdmin = Convert.ToDouble(rsUsersList.Tables[0].Rows[0]["group_cd"]) == SystemConstants.gDefaultAdminGroupCode;
            //    }
            //    else
            //    {
            //        mUserIsAdmin = false;
            //    }

            //    if (cmbCompany.Visible)
            //    {
            //        //mLoginCompany = cmbCompany.GetItemData(cmbCompany.ListIndex);
            //    }
            //    else
            //    {
            //        mLoginCompany = 1;
            //    }
            //    int tempRefParam = Convert.ToInt32(Conversion.Val(Convert.ToString(txtLocationNo.Tag)));
            //    bool tempRefParam2 = txtLocationNo.Visible;
            //    mReturnedErrorNo = SystemProcedure.CheckUserValidity(1, mLoginCompany, txtUserID.Text.Trim(), txtPassword.Text.Trim(), ref tempRefParam, mUserIsAdmin, false, ref tempRefParam2);

            //    //'Desc: To check for valid POS Counter
            //    //UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
            //    mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Preference_value from SM_Preferences where preference_name ='enable_pos_counter'"));
            //    string mSQL = "";
            //    if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
            //    {

            //        mSQL = "select pos_counter_cd  from ics_pos_counter ";
            //        mSQL = mSQL + " where pos_computer_name = '" + SystemProcedure.GetComputerNamePOS().ToLower() + "' and locat_cd = " + SystemVariables.gLoggedInUserLocationCode.ToString() + " and freeze = 0";
            //        //UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
            //        mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
            //        //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
            //        if (Convert.IsDBNull(mReturnValue))
            //        {
            //            SystemVariables.gPOSCounterCode = 0;
            //        }
            //        else
            //        {
            //            //UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
            //            SystemVariables.gPOSCounterCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
            //        }
            //    }
            //    else
            //    {
            //        SystemVariables.gPOSCounterCode = 0;
            //    }


            //    if (mReturnedErrorNo == 0)
            //    {
            //        LastButtonClicked = System.Windows.Forms.DialogResult.OK;
            //        if (!SystemVariables.gXtremeAdminLoggedIn)
            //        {
            //            if (chkSaveUser.CheckState == CheckState.Checked)
            //            {
            //                InteractionHelper.SaveSettingRegistryKey("Innova", "Settings", "UserID", txtUserID.Text);
            //            }
            //            if (chkSavePassword.CheckState == CheckState.Checked)
            //            {
            //                InteractionHelper.SaveSettingRegistryKey("Innova", "Settings", "Password", txtPassword.Text);
            //            }
            //            //''''''''''''''''''''''''''''''''''''''''''''''''''''''
            //            // InteractionHelper.SaveSettingRegistryKey("Innova", "Settings", "CompanyNo", cmbCompany.ListIndex.ToString());
            //            //InteractionHelper.SaveSettingRegistryKey("Innova", "Settings", "LocatNo", txtLocationNo.Text);
            //        }
            //        if (cmbLanguage[0].Visible)
            //        {
            //            //if (cmbLanguage[0].GetItemData(cmbLanguage[0].ListIndex) == 77)
            //            //{
            //            //    SystemVariables.gPreferedLanguage = SystemVariables.Language.English;
            //            //}
            //            //else
            //            //{
            //            //    SystemVariables.gPreferedLanguage = SystemVariables.Language.Arabic;
            //            //}
            //        }

            //        SystemProcedure.OpenApplication();
            //        this.Close();
            //        return;
            //    }
            //    else if (mReturnedErrorNo == 1)
            //    {
            //        MessageBox.Show("Error: Denied access, invalid user information", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else if (mReturnedErrorNo == 2)
            //    {
            //        MessageBox.Show("Error: invalid company information", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    else if (mReturnedErrorNo == 3)
            //    {
            //        MessageBox.Show("Error: Denied access to the specified company", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    else if (mReturnedErrorNo == 4)
            //    {
            //        MessageBox.Show("Error: Denied access to the specified location!!!" + "\r" + "\r" +
            //                        "You can not login in the Head Office / Primary Branch location" + "\r" +
            //                        "from a POS / Remote Location in offline mode!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}
            //catch (System.Exception excep)
            //{


            //    MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    SystemProcedure.CloseApplication(true);
            //}


        }

    }
}
