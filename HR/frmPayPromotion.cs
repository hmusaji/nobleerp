
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayPromotion
		: System.Windows.Forms.Form
	{

		public frmPayPromotion()
{
InitializeComponent();
} 
 public  void frmPayPromotion_old()
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


		private void frmPayPromotion_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
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

		public Control FirstFocusObject = null;

		private const int conTxtVoucherNo = 0;
		private const int conTxtEmpCode = 1;
		private const int conTXTReferenceNo = 2;
		private const int conTxtNewDeptCode = 3;
		private const int conTxtNewDesgCode = 4;
		private const int conTxtComments = 5;

		private const int conDlblDeptCode = 0;
		private const int conDlblDeptName = 1;
		private const int conDlblNewDeptName = 2;
		private const int conDlblDesgCode = 3;
		private const int conDlblDesgName = 4;
		private const int conDlblNewDesgName = 5;
		private const int conDlblBasicSalary = 6;
		private const int conDlblEmpName = 7;

		private clsToolbar oThisFormToolBar = null;
		private string mTimeStamp = "";
		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;


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


		//The property below are used for storing the Search value returned by the Find window

		public object SearchValue
		{
			get
			{
				return mSearchValue;
			}
			set
			{
				mSearchValue = value;
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


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			string mysql = "";
			FirstFocusObject = txtCommonTextBox[conTxtVoucherNo];

			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowUnpostButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				//'Assign the Image for the toolbar
				//'Imagelist are kept on the main form and refered by their key
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture
				//Set btnFormToolBar(7).Picture = frmSysMain.imlSystemIcons.ListImages("imgPostingTransactions").Picture

				SystemProcedure.SetLabelCaption(this);

				//assign a next code
				txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_promotion", "voucher_no");
				txtVoucherDate.Value = DateTime.Today;

				mysql = " select ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_type_name" : " a_type_name");
				mysql = mysql + " ,Promo_Type_Cd from pay_promotion_type ";
				SystemCombo.FillComboWithItemData(cmbPromotionType, mysql);
				if (cmbPromotionType.ListCount > 0)
				{
					cmbPromotionType.ListIndex = 0;
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}



		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//On Keydown navigate the form by using enter key
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}
				if (this.ActiveControl.Name == "txtCommonTextBox")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommonTextBox#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);
			txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_promotion", "voucher_no");

			txtVoucherDate.Value = DateTime.Today;


			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
			mSearchValue = ""; //Change the msearchvalue to blank
			FirstFocusObject.Focus();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord(bool pApprove = false)
		{
			bool result = false;
			object mReturnValue = null;
			int mEmpCode = 0;
			int mDeptCode = 0;
			int mNewDeptCode = 0;
			int mDesgCode = 0;
			int mNewDesgCode = 0;

			//Save a record
			//During save check for the mode
			//If in addmode then insert a record
			//else update the record in the recordset

			string mysql = "";
			try
			{

				mysql = "select pemp.emp_cd , pemp.dept_cd, pemp.desg_cd ";
				mysql = mysql + " from pay_employee pemp , pay_department pdept, pay_designation pdesg ";
				mysql = mysql + " where ";
				mysql = mysql + " pemp.dept_cd = pdept.dept_cd and pemp.desg_cd = pdesg.desg_cd ";
				mysql = mysql + " and pemp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Employee Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtCommonTextBox[conTxtEmpCode].Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEmpCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDeptCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDesgCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2));
				}

				//Get the New Dept Code
				mysql = "select dept_cd from pay_department ";
				mysql = mysql + " where ";
				mysql = mysql + " dept_no = " + txtCommonTextBox[conTxtNewDeptCode].Text;

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Department Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtCommonTextBox[conTxtNewDeptCode].Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mNewDeptCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				//Get the New Desg Code
				mysql = "select desg_cd from pay_designation ";
				mysql = mysql + " where ";
				mysql = mysql + " desg_no = " + txtCommonTextBox[conTxtNewDesgCode].Text;

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Designation Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					txtCommonTextBox[conTxtNewDesgCode].Focus();
					return result;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mNewDesgCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}




				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into pay_promotion ";
					mysql = mysql + " (emp_cd, current_dept_cd, current_desg_cd, new_dept_cd, new_desg_cd";
					mysql = mysql + " , promo_type_cd, voucher_no, voucher_date, reference_no ";
					mysql = mysql + " , current_basic_salary, new_basic_salary, comments, user_cd) ";
					mysql = mysql + " values ( ";
					mysql = mysql + mEmpCode.ToString();
					mysql = mysql + " , " + mDeptCode.ToString();
					mysql = mysql + " , " + mDesgCode.ToString();
					mysql = mysql + " , " + mNewDeptCode.ToString();
					mysql = mysql + " , " + mNewDesgCode.ToString();
					mysql = mysql + " , " + cmbPromotionType.GetItemData(cmbPromotionType.ListIndex).ToString();
					mysql = mysql + " , " + txtCommonTextBox[conTxtVoucherNo].Text;
					mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText) + "'";
					mysql = mysql + " , '" + txtCommonTextBox[conTXTReferenceNo].Text + "'";
					if (txtDisplayLabel[conDlblBasicSalary].Text != "")
					{
						mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblBasicSalary].Text, "##########0.000");
					}
					else
					{
						mysql = mysql + " , 0 ";
					}
					mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtNewBasicSalary.Value);
					mysql = mysql + " , '" + txtCommonTextBox[conTxtComments].Text + "'";
					mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " ) ";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));
				}
				else
				{
					mysql = " select time_stamp from pay_promotion where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}
					else
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						FirstFocusObject.Focus();
						return result;
					}

					if (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp))
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						FirstFocusObject.Focus();
						return result;
					}

					mysql = " update pay_promotion set ";
					mysql = mysql + " emp_cd =" + mEmpCode.ToString();
					mysql = mysql + " , current_dept_cd =" + mDeptCode.ToString();
					mysql = mysql + " , new_dept_cd =" + mNewDeptCode.ToString();
					mysql = mysql + " , current_desg_cd =" + mDesgCode.ToString();
					mysql = mysql + " , new_desg_cd =" + mNewDesgCode.ToString();
					mysql = mysql + " , promo_type_cd =" + cmbPromotionType.GetItemData(cmbPromotionType.ListIndex).ToString();
					mysql = mysql + " , voucher_no =" + txtCommonTextBox[conTxtVoucherNo].Text;
					mysql = mysql + " , voucher_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtVoucherDate.DisplayText) + "'";
					mysql = mysql + " , reference_no ='" + txtCommonTextBox[conTXTReferenceNo].Text + "'";
					mysql = mysql + " , current_basic_salary =" + StringsHelper.Format(txtDisplayLabel[conDlblBasicSalary].Text, "############0.000");
					mysql = mysql + " , new_basic_salary =" + ReflectionHelper.GetPrimitiveValue<string>(txtNewBasicSalary.Value);
					mysql = mysql + " , comments ='" + txtCommonTextBox[conTxtComments].Text + "'";
					mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where entry_id=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}

				if (pApprove)
				{
					SystemHRProcedure.PayPostToHR("pay_promotion", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
					SystemHRProcedure.PayApprove("pay_promotion", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
					PromotionPostEffect(SearchValue);
				}


				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				FirstFocusObject.Focus();
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}


			return result;
		}

		public bool deleteRecord()
		{
			bool result = false;

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 1);
				result = false;
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				return result;
			}
			//
			//If mOldVoucherStatus <> stActive Then
			//    'If gMISuperUser = False Then
			//        If mOldVoucherStatus = stPosted Then           'if voucher is in posted mode
			//            MsgBox msg26 & msg17, vbInformation, "Error"
			//            deleteRecord = False
			//        ElseIf mOldVoucherStatus = stCanceled Then        'if voucher is in deleted mode
			//            MsgBox msg27 & msg17, vbInformation, "Error"
			//            deleteRecord = False
			//        ElseIf mOldVoucherStatus = stAutoGenerated Then        'if voucher is in deleted mode
			//            MsgBox msg28 & msg17, vbInformation, "Error"
			//            deleteRecord = False
			//        End If
			//        If FirstFocusObject.Enabled = True Then
			//            FirstFocusObject.SetFocus
			//        End If
			//        Exit Function
			//    'End If
			//End If

			//If an error occurs, trap the error and dispaly a valid message
			SystemVariables.gConn.BeginTransaction();
			string mysql = "delete from pay_promotion  where entry_id=" + Conversion.Str(mSearchValue);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

			return true;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			if (mReturnErrorType == 1)
			{
				return false;
			}
			else if (mReturnErrorType == 2)
			{ 
				AddRecord();
				return false;
			}
			else
			{
				return false;
			}
		}

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			//On Error GoTo eFoundError
			object mTempValue = null;

			string mysql = " select * from pay_promotion where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

			DataSet localRec = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			localRec.Tables.Clear();
			adap.Fill(localRec);
			if (localRec.Tables[0].Rows.Count != 0)
			{
				//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(SearchValue);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mTimeStamp = Convert.ToString(localRec.Tables[0].Rows[0]["time_stamp"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtVoucherNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["voucher_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtVoucherDate.Value = localRec.Tables[0].Rows[0]["voucher_date"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTXTReferenceNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["reference_no"]) + "";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemCombo.SearchCombo(cmbPromotionType, Convert.ToInt32(localRec.Tables[0].Rows[0]["promo_type_cd"]));

				//Employee No.
				mysql = "select emp_no ";
				mysql = mysql + ", " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "isnull(l_first_name,'') + ' ' + isnull(l_second_name,'') + ' ' + isnull(l_third_name,'') + ' ' + isnull(l_fourth_name,'')" : "isnull(a_first_name,'') + ' ' + isnull(a_second_name,'') + ' ' + isnull(a_third_name,'') + ' ' + isnull(a_fourth_name,'')");
				mysql = mysql + " from pay_employee ";
				mysql = mysql + " where ";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " emp_cd = " + Convert.ToString(localRec.Tables[0].Rows[0]["emp_cd"]);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonTextBox[conTxtEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));

				//old Department No.
				mysql = " select  Dept_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
				mysql = mysql + " from pay_department ";
				mysql = mysql + " where ";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " dept_cd = " + Convert.ToString(localRec.Tables[0].Rows[0]["current_dept_cd"]);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDeptCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));

				//new Department No.
				mysql = " select  Dept_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
				mysql = mysql + " from pay_department ";
				mysql = mysql + " where ";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " dept_cd = " + Convert.ToString(localRec.Tables[0].Rows[0]["new_dept_cd"]);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonTextBox[conTxtNewDeptCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblNewDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));

				//Old Designation No.
				mysql = " select Desg_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
				mysql = mysql + " from pay_designation ";
				mysql = mysql + " where ";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " desg_cd = " + Convert.ToString(localRec.Tables[0].Rows[0]["current_desg_cd"]);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDesgCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));

				//New Designation No.
				mysql = " select  Desg_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
				mysql = mysql + " from pay_designation ";
				mysql = mysql + " where ";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mysql = mysql + " desg_cd = " + Convert.ToString(localRec.Tables[0].Rows[0]["new_desg_cd"]);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonTextBox[conTxtNewDesgCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblNewDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblBasicSalary].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["current_basic_salary"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtNewBasicSalary.Value = localRec.Tables[0].Rows[0]["new_basic_salary"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtComments].Text = Convert.ToString(localRec.Tables[0].Rows[0]["comments"]) + "";

				//Change the form mode to edit
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;

				//Set the form caption and Get the Voucher Status
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, frmPayPromotion.DefInstance, Convert.ToInt32(localRec.Tables[0].Rows[0]["status"]), CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Promotion / Transfer" : "Promotion / Transfer");
			}
			localRec = null;

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void PrintReport()
		{

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7020000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool CheckDataValidity()
		{
			//Check validation during update and add of records

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 3);
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
			}
			else
			{

				//If mOldVoucherStatus <> stActive Then
				//    'If gMISuperUser = False Then
				//        If mOldVoucherStatus = stPosted Then           'if voucher is in posted mode
				//            MsgBox msg26 & msg16, vbInformation, "Error"
				//        ElseIf mOldVoucherStatus = stCanceled Then        'if voucher is in deleted mode
				//            MsgBox msg27 & msg16, vbInformation, "Error"
				//        ElseIf mOldVoucherStatus = stAutoGenerated Then        'if voucher is in Autogenerated mode
				//            MsgBox msg28 & msg16, vbInformation, "Error"
				//        End If
				//        If FirstFocusObject.Enabled = True Then
				//            FirstFocusObject.SetFocus
				//        End If
				//        GoTo mend
				//    'End If
				//End If


				if (!Information.IsNumeric(txtCommonTextBox[conTxtVoucherNo].Text))
				{
					MessageBox.Show("Enter the Loan No.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonTextBox[conTxtVoucherNo].Focus();
				}
				else
				{

					if (!Information.IsDate(txtVoucherDate.DisplayText))
					{
						MessageBox.Show("Enter valid date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtVoucherDate.Focus();
					}
					else
					{

						if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
						{
							MessageBox.Show("Enter Employee Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtCommonTextBox[conTxtEmpCode].Focus();
						}
						else
						{

							if (!Information.IsNumeric(txtCommonTextBox[conTxtNewDeptCode].Text))
							{
								MessageBox.Show("Enter the Department No.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
								txtCommonTextBox[conTxtNewDeptCode].Focus();
							}
							else
							{

								if (!Information.IsNumeric(txtCommonTextBox[conTxtNewDesgCode].Text))
								{
									MessageBox.Show("Enter the Designation No.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
									txtCommonTextBox[conTxtNewDesgCode].Focus();
								}
								else
								{

									if (!Information.IsNumeric(txtNewBasicSalary.Value))
									{
										MessageBox.Show("Enter New Basic Salary ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
										txtNewBasicSalary.Focus();
									}
									else
									{


										return true;
									}
								}
							}
						}
					}
				}
			}

			return false;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmPayPromotion.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void GetNextNumber()
		{
			txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_promotion", "voucher_no");
			FirstFocusObject.Focus();
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			if (Index == conTxtVoucherNo)
			{
				GetNextNumber();
			}
			else
			{
				FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
			}
		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (Index == conTxtEmpCode)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "isnull(l_first_name,'') + ' ' + isnull(l_second_name,'') + ' ' + isnull(l_third_name,'') + ' ' + isnull(l_fourth_name,'')" : "isnull(a_first_name,'') + ' ' + isnull(a_second_name,'') + ' ' + isnull(a_third_name,'') + ' ' + isnull(a_fourth_name,'')");
						mysql = mysql + " , dept_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
						mysql = mysql + " , desg_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
						mysql = mysql + " , emp_cd ";
						mysql = mysql + " , pemp.basic_salary ";
						mysql = mysql + " from pay_employee pemp , pay_department pdept, pay_designation pdesg ";
						mysql = mysql + " where ";
						mysql = mysql + " pemp.dept_cd = pdept.dept_cd and pemp.desg_cd = pdesg.desg_cd ";
						mysql = mysql + " and pemp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
						mysql = mysql + " and pemp.status_cd = " + SystemHRProcedure.gStatusActive.ToString();

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblEmpName].Text = "";

							//'Old Department
							txtDisplayLabel[conDlblDeptCode].Text = "";
							txtDisplayLabel[conDlblDeptName].Text = "";

							//'New Department
							txtCommonTextBox[conTxtNewDeptCode].Text = "";
							txtDisplayLabel[conDlblNewDeptName].Text = "";

							//'Old Designation
							txtDisplayLabel[conDlblDesgCode].Text = "";
							txtDisplayLabel[conDlblDesgName].Text = "";

							//'New Designation
							txtCommonTextBox[conTxtNewDesgCode].Text = "";
							txtDisplayLabel[conDlblNewDesgName].Text = "";

							//Basic and New salary
							txtDisplayLabel[conDlblBasicSalary].Text = "";
							txtNewBasicSalary.Value = 0;


							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));

							//'Old Department
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDeptCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));


							//'New Department
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonTextBox[conTxtNewDeptCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblNewDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));

							//'Old Designation
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDesgCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));

							//'New Designation
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonTextBox[conTxtNewDesgCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblNewDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));

							//Basic and New salary
							txtDisplayLabel[conDlblBasicSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(6)), "###,###,##0.000");
							txtNewBasicSalary.Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(6)), "###,###,##0.000");
						}
					}
					else
					{
						txtDisplayLabel[conDlblEmpName].Text = "";

						//'Old Department
						txtDisplayLabel[conDlblDeptCode].Text = "";
						txtDisplayLabel[conDlblDeptName].Text = "";

						//'New Department
						txtCommonTextBox[conTxtNewDeptCode].Text = "";
						txtDisplayLabel[conDlblNewDeptName].Text = "";

						//'Old Designation
						txtDisplayLabel[conDlblDesgCode].Text = "";
						txtDisplayLabel[conDlblDesgName].Text = "";

						//'New Designation
						txtCommonTextBox[conTxtNewDesgCode].Text = "";
						txtDisplayLabel[conDlblNewDesgName].Text = "";

						//Basic and New salary
						txtDisplayLabel[conDlblBasicSalary].Text = "";
						txtNewBasicSalary.Value = 0;
					}
				}
				else if (Index == conTxtNewDeptCode)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtNewDeptCode].Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select dept_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
						mysql = mysql + " from pay_department pdept ";
						mysql = mysql + " where ";
						mysql = mysql + " pdept.dept_no = " + txtCommonTextBox[conTxtNewDeptCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblNewDeptName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblNewDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						}
					}
					else
					{
						txtDisplayLabel[conDlblNewDeptName].Text = "";
					}
				}
				else if (Index == conTxtNewDesgCode)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtNewDesgCode].Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select desg_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
						mysql = mysql + " from pay_designation ";
						mysql = mysql + " where ";
						mysql = mysql + " desg_no = " + txtCommonTextBox[conTxtNewDesgCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtDisplayLabel[conDlblNewDesgName].Text = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblNewDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						}
					}
					else
					{
						txtDisplayLabel[conDlblNewDesgName].Text = "";
					}
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					//
				}
				else if (mReturnErrorType == 2)
				{ 
					//
				}
				else if (mReturnErrorType == 3)
				{ 
					//
				}
				else if (mReturnErrorType == 4)
				{ 
					txtCommonTextBox[Index].Focus();
				}
				else
				{
					//
				}
			}

		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;
			string mysql = "";


			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

			if (mObjectName == "txtCommonTextBox")
			{
				txtCommonTextBox[mIndex].Text = "";
				switch(mIndex)
				{
					case conTxtEmpCode : 
						mysql = " pay_emp.status_cd = 1 "; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", mysql)); 
						break;
					case conTxtNewDeptCode : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7001000, "727")); 
						break;
					case conTxtNewDesgCode : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7002000, "734")); 
						break;
					default:
						return;
				}
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				if (mObjectName == "txtCommonTextBox")
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[mIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
				}
			}
		}

		public bool Post()
		{
			bool result = false;
			DialogResult ans = (DialogResult) 0;
			frmSysOnlinePosting frmTemp = frmSysOnlinePosting.CreateInstance();

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 2);
				result = false;
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				return result;
			}


			//If mOldVoucherStatus = stActive Then
			//    frmTemp.VisiblePostTransactionToICS = False
			//    frmTemp.VisiblePostToGL = False
			//    frmTemp.EnableApprove = True
			//End If

			frmTemp.ShowDialog();

			//if the user clicks on OK button in the frmPost form
			//If frmTemp.mLastButtonClicked = 1 And frmTemp.mApprove = True Then
			if (frmTemp.mApprove)
			{

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					//Display this message if status is active, which will require to save the record first
					ans = MessageBox.Show(SystemConstants.msg19 + "\r" + "\r" + SystemConstants.msg7, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				}
				else
				{
					//Display this message if status is not active, which will not require to save the record first
					ans = MessageBox.Show("                         Do you want to Post the Record ?                          " + "\r" + "\r" + "\r" + " NOTE :            Yes : To post after saving. " + "\r" + "                         No : To post without saving " + "\r" + "                         Cancel : To exit without posting ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
				}

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						goto mend;
					}
				}
				else
				{
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						goto mend;
					}
					else if (ans == System.Windows.Forms.DialogResult.No)
					{ 
						if (frmTemp.mApprove)
						{
							SystemVariables.gConn.BeginTransaction();
							SystemHRProcedure.PayPostToHR("pay_promotion", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
							SystemHRProcedure.PayApprove("pay_promotion", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
							PromotionPostEffect(SearchValue);
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.CommitTrans();
						}
					}

					result = true;
					goto mDestroy;
				}
			}

			goto mDestroy;

			mend:
			//This goto will only come if the voucherstatus is still active
			if (CheckDataValidity())
			{
				if (saveRecord(frmTemp.mApprove))
				{
					result = true;
					goto mDestroy;
				}
			}
			result = false;

			mDestroy:
			frmTemp.Close();
			return result;
		}

		private void PromotionPostEffect(object pEntryId)
		{

			//''update the employee department and designation
			string mysql = " update pay_employee ";
			mysql = mysql + " set dept_cd = ppromo.new_dept_cd ";
			mysql = mysql + " , desg_cd = ppromo.new_desg_cd ";
			mysql = mysql + " from pay_employee pemp ";
			mysql = mysql + " inner join pay_promotion ppromo on pemp.emp_cd = ppromo.emp_cd ";
			mysql = mysql + " where ppromo.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pEntryId);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			//''''update the salary in billingdetail table
			//mySql = " update pay_employee_billing_details "
			//mySql = mySql & " set amount = ppromo.new_basic_salary "
			//mySql = mySql & " , last_change_date ='" & txtVoucherDate.DisplayText & "'"
			//mySql = mySql & " , last_amount = amount"
			//mySql = mySql & " , comments = 'Modified from Promotion / Transfer'"
			//mySql = mySql & " from pay_employee_billing_details pebd "
			//mySql = mySql & " inner join pay_promotion ppromo on pebd.emp_cd = ppromo.emp_cd "
			//mySql = mySql & " where ppromo.entry_id = " & pEntryId
			//mySql = mySql & " and pebd.bill_cd = 1 "
			//gConn.Execute mySql

		}


		public bool UnPost()
		{

			bool result = false;
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				MessageBox.Show("Can not proceed, current form mode is in Add Mode!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}


			string mysql = " select count(*) from pay_promotion pp ";
			mysql = mysql + " inner join pay_employee pemp on pp.emp_cd = pemp.emp_cd ";
			mysql = mysql + " where pp.entry_id <> " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			mysql = mysql + " and voucher_date > (select voucher_date from pay_promotion where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ")";
			mysql = mysql + " and pemp.emp_cd = (select emp_cd from pay_promotion where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ")";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) > 0)
			{
				MessageBox.Show("Can not unpost transaction, transaction greater than current voucher date already exists.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			if (mOldVoucherStatus == SystemVariables.VoucherStatus.stActive)
			{
				MessageBox.Show("", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				return result;
			}




			DialogResult ans = MessageBox.Show("Do you want to Unpost the Record ?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
			string myString = "";
			if (ans == System.Windows.Forms.DialogResult.Yes)
			{
				SystemVariables.gConn.BeginTransaction();

				//Call PayPostToHR("pay_promotion", CLng(SearchValue))

				myString = "update pay_promotion ";
				myString = myString + " set posted_HR = 0 ";
				myString = myString + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<int>(SearchValue).ToString();
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = myString;
				TempCommand.ExecuteNonQuery();

				//Call PayApprove("pay_promotion", CLng(SearchValue))
				myString = "update pay_promotion ";
				myString = myString + " set status = 1 ";
				myString = myString + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<int>(SearchValue).ToString();
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = myString;
				TempCommand_2.ExecuteNonQuery();

				PromotionUnpostEffect(SearchValue);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				AddRecord();
				return result;
			}
			else if (ans == System.Windows.Forms.DialogResult.No)
			{ 
				result = false;
				AddRecord();
				return result;
			}
			else if (ans == System.Windows.Forms.DialogResult.Cancel)
			{ 
				return false;
			}

			return result;
		}

		private void PromotionUnpostEffect(object pEntryId)
		{

			//''update the employee department and designation
			string mysql = " update pay_employee ";
			mysql = mysql + " set dept_cd = ppromo.current_dept_cd ";
			mysql = mysql + " , desg_cd = ppromo.current_desg_cd ";
			mysql = mysql + " from pay_employee pemp ";
			mysql = mysql + " inner join pay_promotion ppromo on pemp.emp_cd = ppromo.emp_cd ";
			mysql = mysql + " where ppromo.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pEntryId);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();


		}
	}
}