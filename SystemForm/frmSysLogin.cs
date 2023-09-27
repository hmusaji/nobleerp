
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

        public frmSysLogin()
        {
            InitializeComponent();
        }

        private void frmSysLogin_Load(object sender, EventArgs e)
        {

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

            SqlDataAdapter adap = new SqlDataAdapter("select * from SM_USERS where disabled = 0", SystemVariables.gConn);
            rsUsersList.Tables.Clear();
            adap.Fill(rsUsersList);

            //UPGRADE_ISSUE: (1046) LoadPicture Parameter 'ColorDepth' is not supported, and was removed. More Information: https://docs.mobilize.net/vbuc/ewis#1046
            //UPGRADE_ISSUE: (1046) LoadPicture Parameter 'Size' is not supported, and was removed. More Information: https://docs.mobilize.net/vbuc/ewis#1046
            Image3.Image = Image.FromFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\Styles\\Company.jpg");


            DataSet rsSystemFeatures = new DataSet();
            //UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
            //UPGRADE_ISSUE: (2064) ADODB.Recordset property rsSystemFeatures.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
            rsSystemFeatures.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
            SqlDataAdapter adap_2 = new SqlDataAdapter("select feature_name, enabled from SM_PARAMETER ", SystemVariables.gConn);
            rsSystemFeatures.Tables.Clear();
            adap_2.Fill(rsSystemFeatures);
            //UPGRADE_ISSUE: (2064) ADODB.Recordset property rsSystemFeatures.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
            rsSystemFeatures.setActiveConnection(null);

            //--**disable company & location unless user is verified
            //txtCompanyID.Enabled = False
            txtLocationNo.Enabled = false;
            //--**check whether the login company should be prompted
            //UPGRADE_ISSUE: (2064) ADODB.Recordset method rsSystemFeatures.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
            rsSystemFeatures.MoveFirst();
            rsSystemFeatures.Find("feature_name = 'show_company_when_login'");
            if (rsSystemFeatures.Tables[0].Rows.Count != 0)
            {
                //UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
                //UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
                if (((TriState)Convert.ToInt32(rsSystemFeatures.Tables[0].Rows[0]["enabled"])) == TriState.False)
                {
                    mCompanyShowHideSetting = false;
                }
                else
                {
                    mCompanyShowHideSetting = true;
                    SystemCombo.FillComboWithItemData(cmbCompany, "Select L_Comp_Name, comp_id from SM_Company");
                    //''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    //UPGRADE_ISSUE: (2064) ADODB.Recordset method rsSystemFeatures.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
                    rsSystemFeatures.MoveFirst();
                    rsSystemFeatures.Find("feature_name = 'show_last_logged_in_company_when_login'");
                    if (rsSystemFeatures.Tables[0].Rows.Count != 0)
                    {
                        //UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
                        mShowLastLoggedInCompanyWhenLogin = Convert.ToBoolean(rsSystemFeatures.Tables[0].Rows[0]["enabled"]);
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
            rsSystemFeatures.MoveFirst();
            rsSystemFeatures.Find("feature_name = 'show_location_when_login'");
            if (rsSystemFeatures.Tables[0].Rows.Count != 0)
            {
                //UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
                //UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
                if (((TriState)Convert.ToInt32(rsSystemFeatures.Tables[0].Rows[0]["enabled"])) == TriState.False)
                {
                    mLocationShowHideSetting = false;
                }
                else
                {
                    mLocationShowHideSetting = true;

                    //''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    //UPGRADE_ISSUE: (2064) ADODB.Recordset method rsSystemFeatures.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
                    rsSystemFeatures.MoveFirst();
                    rsSystemFeatures.Find("feature_name = 'show_last_logged_in_location_when_login'");
                    if (rsSystemFeatures.Tables[0].Rows.Count != 0)
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
            //    Else
            //        mLocationShowHideSetting = False
            //    End If
            //**------------------------------------------------------------------------------
            //**--check to see if the user should be prompted for preferred language option
            //UPGRADE_ISSUE: (2064) ADODB.Recordset method rsSystemFeatures.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
            rsSystemFeatures.MoveFirst();
            rsSystemFeatures.Find("feature_name = 'show_language_when_login'");
            if (rsSystemFeatures.Tables[0].Rows.Count != 0)
            {
                //UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
                //UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
                if (((TriState)Convert.ToInt32(rsSystemFeatures.Tables[0].Rows[0]["enabled"])) == TriState.False)
                {
                    mLanguageShowHideSetting = false;
                }
                else
                {
                    mLanguageShowHideSetting = true;
                    mObjectId = new object[1];
                    mObjectId[0] = 1017;
                    SystemCombo.FillComboWithSystemObjects(cmbLanguage, mObjectId);
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
            rsSystemFeatures.MoveFirst();
            rsSystemFeatures.Find("feature_name = 'show_last_logged_in_user_name_when_login'");
            if (rsSystemFeatures.Tables[0].Rows.Count != 0)
            {
                //UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
                //UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
                if (((TriState)Convert.ToInt32(rsSystemFeatures.Tables[0].Rows[0]["enabled"])) != TriState.False)
                {
                    txtUserID.Text = InteractionHelper.GetSettingRegistryKey("Innova", "Settings", "UserID", "");
                    txtPassword.Text = InteractionHelper.GetSettingRegistryKey("Innova", "Settings", "Password", "");
                }
            }

            LastButtonClicked = System.Windows.Forms.DialogResult.Cancel;
            mFirstTime = true;
            Image1.Height = this.Height - Image2.Height;

            Image3.Top = (Convert.ToInt32((this.Height - Image3.Height) / 2d));
            Image3.Left = (Convert.ToInt32((this.Width) / 2d));

        }
    }
}
