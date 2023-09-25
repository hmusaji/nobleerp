
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayDocumentTransaction
		: System.Windows.Forms.Form
	{

		public frmPayDocumentTransaction()
{
InitializeComponent();
} 
 public  void frmPayDocumentTransaction_old()
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


		private void frmPayDocumentTransaction_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private const int conTxtVoucherNo = 0;
		private const int conTxtEmpCd = 1;
		private const int conTxtDocumentCd = 3;
		private const int conTxtComments = 4;

		private const int conDlblDeptCode = 0;
		private const int conDlblDeptName = 1;
		private const int conDlblDesgCode = 2;
		private const int conDlblDesgName = 3;
		private const int conDlblDocumentName = 4;
		private const int conDlblEmpName = 5;
		private const int conDlblDocumentNo = 6;

		private const int conDTxtVoucheDate = 0;
		private const int conDTxtDeliveryDate = 1;
		private const int conDTxtReturnDate = 2;
		private const int conDTxtActualReturnDate = 3;

		private const int conLblActualReturnDate = 8;

		private const int conStatusDelivery = 1;
		private const int conStatusReturn = 2;

		private clsToolbar oThisFormToolBar = null;
		private string mTimeStamp = "";
		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		//Option Explicit
		//Public UserAccess As New clsAccessAllowed
		//Public FirstFocusObject As Control
		//Private mTimeStamp As String
		//
		//Private mThisFormID As Long
		//Private mSearchValue As Variant
		//Private mCurrentFormMode  As SystemFormModes
		//
		//Private Const conTxtDocumentNo As Integer = 0
		//Private Const conTxtDocumentCd As Integer = 1
		//Private Const conTxtGovernateCd As Integer = 2
		//Private Const conTxtPlaceOfDocument As Integer = 3
		//Private Const conTxtComments As Integer = 4
		//Private Const conTxtEmpCd As Integer = 5
		//
		//Private Const conNTxtPeriod As Integer = 0
		//Private Const conNTxtFees As Integer = 1
		//
		//Private Const conDlblDocumentName As Integer = 0
		//Private Const conDlblGovernateName As Integer = 1
		//Private Const conDlblPlaceOfDocument As Integer = 2
		//Private Const conDlblEmpName As Integer = 3


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


		private void cmbStatus_Click(Object Sender, EventArgs e)
		{
			if (cmbStatus.GetItemData(cmbStatus.ListIndex) == conStatusDelivery)
			{
				lblCommonLabel[conLblActualReturnDate].Visible = false;
				txtCommonDate[conDTxtActualReturnDate].Visible = false;
			}
			else if (cmbStatus.GetItemData(cmbStatus.ListIndex) == conStatusReturn)
			{ 
				lblCommonLabel[conLblActualReturnDate].Visible = true;
				txtCommonDate[conDTxtActualReturnDate].Visible = true;
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			FirstFocusObject = txtCommonTextBox[conTxtVoucherNo];

			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;

				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				//
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture
				//'Set btnFormToolBar(10).Picture = frmSysMain.imlMainToolBar.ListImages("imgReplacementProduct").Picture

				SystemProcedure.SetLabelCaption(this);

				txtCommonDate[conDTxtVoucheDate].Value = DateTime.Today;
				txtCommonDate[conDTxtDeliveryDate].Value = DateTime.Today;
				txtCommonDate[conDTxtReturnDate].Value = DateTime.Today;
				txtCommonDate[conDTxtActualReturnDate].Value = DateTime.Today;

				//assign a next code
				txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_document_transaction", "voucher_no");


				SetStausValues(mCurrentFormMode);
				cmbStatus.ListIndex = 0;
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
				if (KeyCode == 13)
				{
					SendKeys.Send("{TAB}");
					return;
				}

				if (this.ActiveControl.Name != "txtCommonTextBox")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommonTextBox#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void AddRecord()
		{

			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearNumberBox(this);

			txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_document_transaction", "voucher_no");

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			SetStausValues(mCurrentFormMode);
			cmbStatus.ListIndex = 0;

			mSearchValue = "";
			FirstFocusObject.Focus();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord(bool pPostGl = false)
		{

			bool result = false;
			int mEmpCd = 0;
			int mDeptCd = 0;
			int mDesgCd = 0;

			int mDocumentCd = 0;
			int mEntryId = 0;

			//On Error GoTo eFoundError


			string mysql = " select emp_cd, dept_cd, desg_cd from pay_employee ";
			mysql = mysql + " where emp_no='" + txtCommonTextBox[conTxtEmpCd].Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			string mCheckTimeStamp = "";
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mDeptCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mDesgCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2));

				mysql = " select document_cd from pay_document_master ";
				mysql = mysql + " where document_no='" + txtCommonTextBox[conTxtDocumentCd].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mCheckTimeStamp = "";
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDocumentCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);


					SystemVariables.gConn.BeginTransaction();

					mysql = " select emp_cd from pay_document_transaction ";
					mysql = mysql + " where emp_cd =" + mEmpCd.ToString();
					mysql = mysql + " and document_cd =" + mDocumentCd.ToString();
					mysql = mysql + " and status = " + conStatusDelivery.ToString();
					if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
					{
						mysql = mysql + " and entry_id <> " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					}

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						result = false;
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show(" Document already Delivered to the employee , Transaction failed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommonTextBox[conTxtEmpCd].Focus();
						return result;
					}


					mCheckTimeStamp = "";
					if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
					{
						mysql = " insert into pay_document_transaction ";
						mysql = mysql + " (voucher_no, voucher_date, emp_cd, dept_cd, desg_cd, document_cd ";
						mysql = mysql + " , document_no, delivery_date, return_date, actual_return_date ";
						mysql = mysql + " , status, comments, user_cd) ";
						mysql = mysql + " values( ";
						mysql = mysql + txtCommonTextBox[conTxtVoucherNo].Text;
						mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtVoucheDate].DisplayText) + "'";
						mysql = mysql + " , " + mEmpCd.ToString();
						mysql = mysql + " , " + mDeptCd.ToString();
						mysql = mysql + " , " + mDesgCd.ToString();
						mysql = mysql + " , " + mDocumentCd.ToString();
						mysql = mysql + " , '" + txtDisplayLabel[conDlblDocumentNo].Text + "'";

						mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtDeliveryDate].DisplayText) + "'";
						mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtReturnDate].DisplayText) + "'";

						if (cmbStatus.GetItemData(cmbStatus.ListIndex) == conStatusReturn)
						{
							mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtActualReturnDate].DisplayText) + "'";
						}
						else
						{
							mysql = mysql + " , NULL ";
						}

						mysql = mysql + " , " + cmbStatus.GetItemData(cmbStatus.ListIndex).ToString();
						mysql = mysql + " , N'" + txtCommonTextBox[conTxtComments].Text + "'";
						mysql = mysql + " , " + Conversion.Str(SystemVariables.gLoggedInUserCode);
						mysql = mysql + " )";
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql;
						TempCommand.ExecuteNonQuery();
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));
					}
					else
					{
						//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mEntryId = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);

						mysql = " select time_stamp from pay_document_transaction where entry_id =" + mEntryId.ToString();
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

						mysql = " update pay_document_transaction set ";
						mysql = mysql + " voucher_no =" + txtCommonTextBox[conTxtVoucherNo].Text;
						mysql = mysql + " , voucher_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtVoucheDate].DisplayText) + "'";
						mysql = mysql + " , emp_cd =" + mEmpCd.ToString();
						mysql = mysql + " , dept_cd =" + mDeptCd.ToString();
						mysql = mysql + " , desg_cd =" + mDesgCd.ToString();
						mysql = mysql + " , document_cd =" + mDocumentCd.ToString();
						mysql = mysql + " , document_no ='" + txtDisplayLabel[conDlblDocumentNo].Text + "'";
						mysql = mysql + " , delivery_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtDeliveryDate].DisplayText) + "'";
						mysql = mysql + " , return_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtReturnDate].DisplayText) + "'";

						if (cmbStatus.GetItemData(cmbStatus.ListIndex) == conStatusReturn)
						{
							mysql = mysql + " , actual_return_date ='" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtActualReturnDate].DisplayText) + "'";
						}
						else
						{
							mysql = mysql + " , actual_return_date = NULL ";
						}

						mysql = mysql + " , status =" + cmbStatus.GetItemData(cmbStatus.ListIndex).ToString();
						mysql = mysql + " , comments =N'" + txtCommonTextBox[conTxtComments].Text + "'";
						mysql = mysql + " where entry_id =" + mEntryId.ToString();
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();

					}


					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();
					SystemProcedure.InsertAlarmDetails(6, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), txtCommonTextBox[conTxtComments].Text, DateTimeHelper.ToString(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtReturnDate].Value)));
					result = true;
					FirstFocusObject.Focus();
					return result;

				}
				else
				{
					MessageBox.Show("Invalid Document Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonTextBox[conTxtDocumentCd].Focus();
				}
			}
			else
			{
				MessageBox.Show("Invalid Employee Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtEmpCd].Focus();
			}

			return false;


			int mReturnErrorType = 0;
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			return false;
		}

		public bool deleteRecord()
		{


			bool result = false;
			SystemVariables.gConn.BeginTransaction();

			string mysql = " select status from pay_document_transaction ";
			mysql = mysql + " where entry_id=" + Conversion.Str(mSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == conStatusReturn)
				{
					MessageBox.Show(" Return Transaction cannot be deleted, Change the Status back to Delivery and Delete", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;

				}
			}

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				mysql = "delete from pay_document_transaction where entry_id=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Document Details cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				SystemProcedure.AlarmDelete(6, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));


				return true;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					result = false;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			try
			{
				string mysql = "";
				object mReturnValue = null;
				SqlDataReader localRec = null;


				mysql = " select pemp.emp_no, pdept.dept_no, pdesg.desg_no, pdm.document_no ";
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					mysql = mysql + " , pemp.l_first_name + ' ' + pemp.l_second_name + ' ' + pemp.l_third_name + ' ' + pemp.l_fourth_name as full_name ";
					mysql = mysql + " , pdm.l_document_name document_name ";
					mysql = mysql + " , pdept.l_dept_name dept_name ";
					mysql = mysql + " , pdesg.l_desg_name desg_name ";
				}
				else
				{
					mysql = mysql + " , pemp.a_first_name  + ' ' +  pemp.a_second_name  + ' ' +  pemp.a_third_name  + ' ' + pemp.a_fourth_name as full_name ";
					mysql = mysql + " , pdm.a_document_name document_name ";
					mysql = mysql + " , pdept.a_dept_name dept_name ";
					mysql = mysql + " , pdesg.a_desg_name desg_name ";
				}
				mysql = mysql + " , pdt.voucher_no , pdt.voucher_date , pdt.document_no as doc_no ";
				mysql = mysql + " , pdt.delivery_date , pdt.return_date, pdt.actual_return_date ";
				mysql = mysql + " , pdt.status , pdt.comments, pdt.entry_id, pdt.time_stamp ";
				mysql = mysql + " from pay_document_transaction pdt ";
				mysql = mysql + " inner join pay_employee pemp on pdt.emp_cd = pemp.emp_cd ";
				mysql = mysql + " inner join pay_department pdept on pdt.dept_cd = pdept.dept_cd ";
				mysql = mysql + " inner join pay_designation pdesg on pdt.desg_cd = pdesg.desg_cd ";
				mysql = mysql + " inner join pay_document_master pdm on pdt.document_cd = pdm.document_cd ";
				mysql = mysql + " where pdt.entry_id= " + Conversion.Str(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{

					mSearchValue = localRec["entry_id"];
					mTimeStamp = Convert.ToString(localRec["time_stamp"]);

					SetStausValues(SystemVariables.SystemFormModes.frmEditMode);

					txtCommonTextBox[conTxtVoucherNo].Text = Convert.ToString(localRec["voucher_no"]);
					txtCommonDate[conDTxtVoucheDate].Value = localRec["voucher_date"];

					txtCommonTextBox[conTxtEmpCd].Text = Convert.ToString(localRec["emp_no"]);
					txtDisplayLabel[conDlblEmpName].Text = Convert.ToString(localRec["full_name"]);

					txtDisplayLabel[conDlblDeptCode].Text = Convert.ToString(localRec["dept_no"]);
					txtDisplayLabel[conDlblDeptName].Text = Convert.ToString(localRec["dept_name"]);

					txtDisplayLabel[conDlblDesgCode].Text = Convert.ToString(localRec["desg_no"]);
					txtDisplayLabel[conDlblDesgName].Text = Convert.ToString(localRec["desg_name"]);

					txtCommonTextBox[conTxtDocumentCd].Text = Convert.ToString(localRec["document_no"]);
					txtDisplayLabel[conDlblDocumentName].Text = Convert.ToString(localRec["document_name"]);

					txtDisplayLabel[conDlblDocumentNo].Text = Convert.ToString(localRec["doc_no"]);

					txtCommonDate[conDTxtDeliveryDate].Value = localRec["delivery_date"];
					txtCommonDate[conDTxtReturnDate].Value = localRec["return_date"];

					if (!Convert.IsDBNull(localRec["actual_return_date"]))
					{
						txtCommonDate[conDTxtActualReturnDate].Value = localRec["actual_return_date"];
					}

					SystemCombo.SearchCombo(cmbStatus, Convert.ToInt32(localRec["status"]));

					txtCommonTextBox[conTxtComments].Text = Convert.ToString(localRec["comments"]) + "";

					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				}
				localRec.Close();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}

		}

		public void PrintReport()
		{
			int mEntryId = 0;

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
			}
			else
			{
				return;
			}
			SystemReports.GetCrystalReport(110013085, 2, "8756", Conversion.Str(mEntryId), false);
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7190000));
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

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCd].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Employee Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtEmpCd].Focus();
				goto mError;
			}

			if (SystemProcedure2.IsItEmpty(txtDisplayLabel[conDlblDocumentNo].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Assign Document to Employee.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto mError;
			}

			if (!Information.IsNumeric(txtCommonTextBox[conTxtDocumentCd].Text))
			{
				MessageBox.Show("Enter Document Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtDocumentCd].Focus();
				goto mError;
			}

			if (!Information.IsDate(txtCommonDate[conDTxtVoucheDate].DisplayText))
			{
				MessageBox.Show("Enter Voucher Date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonDate[conDTxtVoucheDate].Focus();
				goto mError;
			}

			if (!Information.IsDate(txtCommonDate[conDTxtDeliveryDate].DisplayText))
			{
				MessageBox.Show("Enter Delivery Date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonDate[conDTxtDeliveryDate].Focus();
				goto mError;
			}

			if (!Information.IsDate(txtCommonDate[conDTxtReturnDate].DisplayText))
			{
				MessageBox.Show("Enter Return Date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonDate[conDTxtReturnDate].Focus();
				goto mError;
			}

			if (cmbStatus.GetItemData(cmbStatus.ListIndex) == conStatusReturn)
			{
				if (!Information.IsDate(txtCommonDate[conDTxtActualReturnDate].DisplayText))
				{
					MessageBox.Show("Enter Actual Return Date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonDate[conDTxtActualReturnDate].Focus();
					goto mError;
				}
			}

			return true;

			mError:
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
				//Modified By Burhan Date 03-Jul-2007
				frmPayDocumentTransaction.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtGradeNo_DropButtonClick()
		{
			//Get the maximum + 1 product_category code
			GetNextNumber();
		}

		public void FindRoutine(string pObjectName)
		{

			object mTempSearchValue = null;

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mObjectIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));
			if (mObjectName == "txtCommonTextBox")
			{
				txtCommonTextBox[mObjectIndex].Text = "";
				switch(mObjectIndex)
				{
					case conTxtEmpCd : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831")); 
						break;
					case conTxtDocumentCd : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7120000, "1470")); 
						break;
					default:
						return;
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[mObjectIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtCommonTextBox_Leave(txtCommonTextBox[mObjectIndex], new EventArgs());
				}
			}

		}

		public void GetNextNumber()
		{
			//txtGradeNo.Text = GetNewNumber("Pay_Grade", "Grade_No")
			//FirstFocusObject.SetFocus
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			if (Index == conTxtVoucherNo)
			{
				txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_document_transaction", "voucher_no");
				return;
			}
			FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());

		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);

			object mTempValue = null;
			string mysql = "";
			int mLinkedTextBoxIndex = 0;

			try
			{
				switch(Index)
				{
					case conTxtEmpCd : 
						mysql = " select pemp.l_first_name + ' ' + pemp.l_second_name + ' ' + pemp.l_third_name + ' ' + pemp.l_fourth_name as L_Full_Name "; 
						mysql = mysql + " , pemp.a_first_name + ' ' + pemp.a_second_name + ' ' + pemp.a_third_name + ' ' + pemp.a_fourth_name "; 
						mysql = mysql + " , pdept.dept_no , pdept.l_dept_name, pdept.a_dept_name "; 
						mysql = mysql + " , pdesg.desg_no , pdesg.l_desg_name, pdesg.a_desg_name "; 
						mysql = mysql + " from pay_employee pemp "; 
						mysql = mysql + " inner join pay_department pdept on pemp.dept_cd = pdept.dept_cd "; 
						mysql = mysql + " inner join pay_designation pdesg on pemp.desg_cd = pdesg.desg_cd "; 
						mysql = mysql + " where emp_no ='" + txtCommonTextBox[Index].Text + "'"; 
						mLinkedTextBoxIndex = conDlblEmpName; 
						break;
					case conTxtDocumentCd : 
						mysql = "select l_document_name, a_document_name "; 
						mysql = mysql + " from pay_document_master "; 
						mysql = mysql + " where document_no=" + txtCommonTextBox[Index].Text; 
						mLinkedTextBoxIndex = conDlblDocumentName; 
						break;
					default:
						return;
				}

				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[Index].Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDisplayLabel[mLinkedTextBoxIndex].Text = "";
						txtCommonTextBox[Index].Tag = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						txtDisplayLabel[mLinkedTextBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1));

						if (Index == conTxtEmpCd)
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDeptCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDesgCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(5));
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDisplayLabel[conDlblDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDisplayLabel[conDlblDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(6));
							}
							else
							{
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDisplayLabel[conDlblDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDisplayLabel[conDlblDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(7));
							}
						}
						else if (Index == conTxtDocumentCd)
						{ 
							mysql = " select pdd.document_no from pay_document_detail pdd ";
							mysql = mysql + " inner join pay_employee pemp on pdd.emp_cd = pemp.emp_cd ";
							mysql = mysql + " inner join pay_document_master pdm on pdd.document_cd = pdm.document_cd ";
							mysql = mysql + " where pemp.emp_no='" + txtCommonTextBox[conTxtEmpCd].Text + "'";
							mysql = mysql + " and pdm.document_no =" + txtCommonTextBox[conTxtDocumentCd].Text;
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mTempValue))
							{
								//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDisplayLabel[conDlblDocumentNo].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
							}
						}

						//        If Index = conTxtDocumentCd Then
						//            txtAdjustmentDate.Value = CDate(mTempValue(10)) + 1
						//            txtCommonTextBox(conTxtGovernateCd).Text = mTempValue(3)
						//            txtCommonTextBox(conTxtPlaceOfDocument).Text = mTempValue(6) & ""
						//            If gPreferedLanguage = English Then
						//                txtDisplayLabel(conDlblGovernateName).Text = mTempValue(4)
						//                txtDisplayLabel(conDlblPlaceOfDocument).Text = mTempValue(7) & ""
						//            Else
						//                txtDisplayLabel(conDlblGovernateName).Text = mTempValue(5)
						//                txtDisplayLabel(conDlblPlaceOfDocument).Text = mTempValue(8) & ""
						//            End If
						//
						//            If mTempValue(9) = True Then
						//                txtCommonTextBox(conTxtPlaceOfDocument).Enabled = True
						//            Else
						//                txtCommonTextBox(conTxtPlaceOfDocument).Enabled = False
						//                txtCommonTextBox(conTxtPlaceOfDocument).Text = ""
						//                txtDisplayLabel(conDlblPlaceOfDocument).Text = ""
						//            End If
						//        End If

						//        If Index = conTxtGovernateCd Then
						//            If mTempValue(3) = True Then
						//                txtCommonTextBox(conTxtPlaceOfDocument).Enabled = True
						//            Else
						//                txtCommonTextBox(conTxtPlaceOfDocument).Enabled = False
						//                txtCommonTextBox(conTxtPlaceOfDocument).Text = ""
						//                txtDisplayLabel(conDlblPlaceOfDocument).Text = ""
						//            End If
						//        End If
					}
				}
				else
				{
					txtDisplayLabel[mLinkedTextBoxIndex].Text = "";
					txtCommonTextBox[Index].Tag = "";
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
					//if the code is not found
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
					try
					{
						txtCommonTextBox[Index].Focus();
					}
					catch (Exception exc)
					{
						NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
					}
				}
				else
				{
					//
				}
			}

		}


		private void SetStausValues(SystemVariables.SystemFormModes pCurrentFormMode)
		{

			cmbStatus.Clear();

			if (pCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				cmbStatus.AddItem("Delivery");
				cmbStatus.SetItemData(0, 1);

				cmbStatus.AddItem("Return");
				cmbStatus.SetItemData(1, 2);
			}
			else
			{
				cmbStatus.AddItem("Delivery");
				cmbStatus.SetItemData(0, 1);
			}

		}
	}
}