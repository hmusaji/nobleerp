
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayAppraisalSurveyRatingType
		: System.Windows.Forms.Form
	{

		public frmPayAppraisalSurveyRatingType()
{
InitializeComponent();
} 
 public  void frmPayAppraisalSurveyRatingType_old()
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


		private void frmPayAppraisalSurveyRatingType_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		int mThisFormID = 0;
		object mSearchValue = null;
		private XArrayHelper _aVoucherDetails = null;
		private XArrayHelper aVoucherDetails
		{
			get
			{
				if (_aVoucherDetails is null)
				{
					_aVoucherDetails = new XArrayHelper();
				}
				return _aVoucherDetails;
			}
			set
			{
				_aVoucherDetails = value;
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

		private clsToolbar oThisFormToolBar = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		private const int mConLRateTypeName = 1;
		private const int mConARateTypeName = 2;
		private const int mConPercentage = 3;
		private const int conMaxColumns = 3;

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
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);
				txtRatingTypeCode.Text = SystemProcedure2.GetNewNumber("pay_appraisal_survey_rating_type", "Rating_No", 2);

				SystemGrid.DefineSystemVoucherGrid(grdRatingDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");

				SystemGrid.DefineSystemVoucherGridColumn(grdRatingDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdRatingDetails, "RateTypeName", 2500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdRatingDetails, "RateTypeName", 2500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdRatingDetails, "Percentage", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);

				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdRatingDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdRatingDetails.setArray(aVoucherDetails);
				grdRatingDetails.Rebind(true);
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
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void DefineVoucherArray(int pMaximumRows, bool pClearArray = false)
		{
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
			}
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, conMaxColumns}, new int[]{0, 0});
		}

		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, SystemICSConstants.grdLineNoColumn);
			}
		}

		public void AddRecord()
		{
			SystemProcedure2.ClearTextBox(this);

			DefineVoucherArray(-1, true);
			AssignGridLineNumbers();
			grdRatingDetails.Rebind(true);

			txtRatingTypeCode.Text = SystemProcedure2.GetNewNumber("pay_appraisal_survey_rating_type", "rating_no", 2);
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			mSearchValue = "";

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "mAssign_value");
		}

		public bool saveRecord()
		{
			bool result = false;
			StringBuilder mysql = new StringBuilder();
			int cnt = 0;
			try
			{

				SystemVariables.gConn.BeginTransaction();

				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = new StringBuilder("insert into pay_appraisal_survey_rating_type(rating_no,l_rating_type_name,a_rating_type_name)");
					mysql.Append(" values( '" + txtRatingTypeCode.Text + "'");
					mysql.Append(", '" + txtLRatingTypeName.Text + "'");
					mysql.Append(", N'" + txtARatingTypeName.Text + "'");
					mysql.Append(")");
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql.ToString();
					TempCommand.ExecuteNonQuery();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));
				}
				else
				{
					mysql = new StringBuilder(" update pay_appraisal_survey_rating_type");
					mysql.Append(" set rating_no = '" + txtRatingTypeCode.Text + "'");
					mysql.Append(" ,l_rating_type_name='" + txtLRatingTypeName.Text + "'");
					mysql.Append(" ,a_rating_type_name= N'" + txtARatingTypeName.Text + "'");
					mysql.Append(" where Rating_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue));
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql.ToString();
					TempCommand_2.ExecuteNonQuery();
				}
				mysql = new StringBuilder(" delete from pay_appraisal_survey_rating_details");
				mysql.Append(" where Rating_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue));
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql.ToString();
				TempCommand_3.ExecuteNonQuery();
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					mysql = new StringBuilder(" insert into pay_appraisal_survey_rating_details(rating_cd,l_rating_name,a_rating_name,percentage)");
					mysql.Append(" values (" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue));
					mysql.Append(" ,'" + Convert.ToString(aVoucherDetails.GetValue(cnt, mConLRateTypeName)) + "'");
					mysql.Append(" ,'" + Convert.ToString(aVoucherDetails.GetValue(cnt, mConARateTypeName)) + "'");
					mysql.Append(" ," + Convert.ToString(aVoucherDetails.GetValue(cnt, mConPercentage)));
					mysql.Append(" )");
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql.ToString();
					TempCommand_4.ExecuteNonQuery();
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				return true;
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Rating_cd from pay_appraisal_survey_rating_type where rating_no= " + txtRatingTypeCode.Text));
					GetRecord(mSearchValue);
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					AddRecord();
					result = false;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		public object deleteRecord()
		{
			object result = null;
			string mysql = "";
			object mReturnValue = null;

			try
			{

				mysql = " select protected from pay_appraisal_survey_rating_type where Rating_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{

					if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
					{
						MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}

					//If an error occurs, trap the error and dispaly a valid message
					SystemVariables.gConn.BeginTransaction();

					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
					try
					{
						mysql = " delete from pay_appraisal_survey_rating_details";
						mysql = mysql + " where Rating_cd = " + Conversion.Str(mSearchValue);
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql;
						TempCommand.ExecuteNonQuery();

						mysql = "delete from pay_appraisal_survey_rating_type where Rating_cd=" + Conversion.Str(mSearchValue);
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();

						//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (Information.Err().Number != 0)
						{
							MessageBox.Show("Appraisal Rating Type cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							return false;
						}

						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.CommitTrans();
						result = true;
					}
					catch (Exception exc)
					{
						NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
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
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					AddRecord();
					((Array) result).GetValue(0);
				}
				else
				{
					result = false;
				}
			}

			return result;
		}

		public void GetRecord(object SearchValue)
		{
			string mysql = "";
			object mReturnValue = null;
			DataSet rsLocal = null;
			int mCnt = 0;

			try
			{
				if (SystemProcedure2.IsItEmpty(SearchValue, SystemVariables.DataType.NumberType))
				{
					return;
				}

				mysql = "select rating_no,l_rating_type_name,a_rating_type_name from pay_appraisal_survey_rating_type where Rating_cd =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtRatingTypeCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtLRatingTypeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtARatingTypeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
				}
				else
				{
					txtLRatingTypeName.Text = "";
					txtARatingTypeName.Text = "";
				}

				rsLocal = new DataSet();
				mysql = "select l_rating_name,a_rating_name,percentage";
				mysql = mysql + " from pay_appraisal_survey_rating_details";
				mysql = mysql + " where rating_cd=" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLocal.Tables.Clear();
				adap.Fill(rsLocal);
				aVoucherDetails.RedimXArray(new int[]{rsLocal.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
				mCnt = 0;
				foreach (DataRow iteration_row in rsLocal.Tables[0].Rows)
				{
					aVoucherDetails.SetValue(iteration_row["l_rating_name"], mCnt, mConLRateTypeName);
					aVoucherDetails.SetValue(iteration_row["a_rating_name"], mCnt, mConARateTypeName);
					aVoucherDetails.SetValue(iteration_row["percentage"], mCnt, mConPercentage);
					mCnt++;
				}

				AssignGridLineNumbers();
				grdRatingDetails.Rebind(true);
				grdRatingDetails.Refresh();
				this.CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220600));
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

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				oThisFormToolBar = null;
				UserAccess = null;
				frmICSUnit.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}


		private void tcbSystemForm_Execute(XtremeCommandBars.ICommandBarControl Control)
		{

		}

		private void txtRatingTypeCode_DropButtonClick(Object Sender, EventArgs e)
		{
			GetNextNumber();
		}

		public void GetNextNumber()
		{
			txtRatingTypeCode.Text = SystemProcedure2.GetNewNumber("pay_appraisal_survey_rating_type", "rating_no", 2);
			txtRatingTypeCode.Focus();
		}
	}
}