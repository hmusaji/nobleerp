
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayPenalty
		: System.Windows.Forms.Form
	{

		public frmPayPenalty()
{
InitializeComponent();
} 
 public  void frmPayPenalty_old()
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


		private void frmPayPenalty_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		private string mTimeStamp = "";
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

		private const int conMaxColumns = 4;

		private const int mconLineNo = 0; //grid Column No
		private const int mRepetitionNo = 1; //grid Column No
		private const int mLPenaltyDesc = 2; //grid Column No
		private const int mAPenaltyDesc = 3; //grid Column No
		private const int mPenaltyValue = 4; //grid Column No


		private clsToolbar oThisFormToolBar = null;
		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private int mBillCd = 0;
		private int mPenaltyGroupCd = 0;

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
			FirstFocusObject = txtPenaltyNo;

			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;
				//grdPenaltySetup
				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = false;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemGrid.DefineSystemVoucherGrid(grdPenaltySetup, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");

				SystemGrid.DefineSystemVoucherGridColumn(grdPenaltySetup, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdPenaltySetup, "RepititionNo", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdPenaltySetup, "Desc(Eng)", 2500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdPenaltySetup, "Desc(Arb)", 2500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdPenaltySetup, "Value", 500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false);


				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdPenaltySetup.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdPenaltySetup.setArray(aVoucherDetails);
				grdPenaltySetup.Rebind(true);

				SystemProcedure.SetLabelCaption(this);

				//assign a next code
				txtPenaltyNo.Text = SystemProcedure2.GetNewNumber("pay_penalty", "penalty_No");
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
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
			int cnt = 0;
			//Add a record
			int tempForEndVar = grdPenaltySetup.Columns.Count - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				grdPenaltySetup.Columns[cnt].FooterText = "";
			}

			SystemProcedure2.ClearTextBox(this);
			txtPenaltyNo.Text = SystemProcedure2.GetNewNumber("pay_penalty", "penalty_no");

			DefineVoucherArray(-1, true);
			AssignGridLineNumbers();
			grdPenaltySetup.Rebind(true);

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			FirstFocusObject.Focus();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord()
		{
			bool result = false;
			object mCnt = null;
			object mReturnValue = null;
			string mysql = "";
			try
			{

				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
				if (!String.IsNullOrEmpty(txtBillNo.Text))
				{
					mysql = "select bill_cd from pay_billing_type where bill_no=" + txtBillNo.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mBillCd))
					{
						MessageBox.Show("Please enter correct Bill Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtBillNo.Focus();
						return false;
					}
				}

				if (!SystemProcedure2.IsItEmpty(txtPenaltyGroupCd.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select penalty_group_cd from pay_penalty_group where penalty_group_no=" + txtPenaltyGroupCd.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						mPenaltyGroupCd = 0;
					}
					else
					{
						mPenaltyGroupCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}
				else
				{
					mPenaltyGroupCd = 0;
				}

				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into pay_penalty(user_cd, penalty_no, l_penalty_name, a_penalty_name, bill_cd ,penalty_group_cd )";
					mysql = mysql + " VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
					mysql = mysql + txtPenaltyNo.Text + ",";
					mysql = mysql + "'" + StringsHelper.Replace(txtLPenaltyName.Text, "'", "", 1, -1, CompareMethod.Binary) + "',";
					mysql = mysql + "N'" + StringsHelper.Replace(txtAPenaltyName.Text, "'", "", 1, -1, CompareMethod.Binary) + "',";
					mysql = mysql + mBillCd.ToString();
					mysql = mysql + "," + ((mPenaltyGroupCd == 0) ? "NULL" : mPenaltyGroupCd.ToString());
					mysql = mysql + ")";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mysql = " select scope_identity()";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mSearchValue = ReflectionHelper.GetPrimitiveValue(mReturnValue);
					}
					else
					{
						result = false;
						mSearchValue = "";
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return result;
					}
				}
				else
				{
					mysql = " select time_stamp,protected from pay_penalty where penalty_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
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
					if (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(1)))
					{
						MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}
					mysql = "update pay_penalty SET ";
					mysql = mysql + " penalty_No =" + txtPenaltyNo.Text + ",";
					mysql = mysql + " l_penalty_name ='" + StringsHelper.Replace(txtLPenaltyName.Text, "'", "", 1, -1, CompareMethod.Binary) + "',";
					mysql = mysql + " a_penalty_name =N'" + StringsHelper.Replace(txtAPenaltyName.Text, "'", "", 1, -1, CompareMethod.Binary) + "',";
					mysql = mysql + " modified_user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
					mysql = mysql + " modified_user_date_time='" + DateTime.Now.ToString("dd/MMM/yyyy") + "',";
					mysql = mysql + " bill_cd =" + mBillCd.ToString() + ",";
					mysql = mysql + " penalty_group_cd = " + ((mPenaltyGroupCd == 0) ? "NUll" : mPenaltyGroupCd.ToString());
					mysql = mysql + " where penalty_cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}

				mysql = "delete from Pay_Penalty_Setup ";
				mysql = mysql + " where penalty_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (mCnt = 0; ReflectionHelper.GetPrimitiveValue<double>(mCnt) <= tempForEndVar; mCnt = ReflectionHelper.GetPrimitiveValue<double>(mCnt) + 1)
				{
					mysql = " insert into Pay_Penalty_Setup(penalty_cd, repetition_no,l_penalty_desc,a_penalty_desc,penalty_value)";
					mysql = mysql + " values ( " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					mysql = mysql + "," + Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(mCnt), mRepetitionNo));
					mysql = mysql + ",'" + StringsHelper.Replace(Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(mCnt), mLPenaltyDesc)), "'", "", 1, -1, CompareMethod.Binary) + "'";
					mysql = mysql + ",N'" + StringsHelper.Replace(Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(mCnt), mAPenaltyDesc)), "'", "", 1, -1, CompareMethod.Binary) + "'";
					mysql = mysql + "," + Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(mCnt), mPenaltyValue));
					mysql = mysql + ")";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();
				}

				//'commented by hakim on 13-nov-2011
				//If Not UpdatePublicHolidayInTimeAttendance Then
				//    GoTo eFoundError
				//End If

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
			string mysql = " select protected from pay_penalty where penalty_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
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

				mysql = "delete from pay_penalty where penalty_cd=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Penalty cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
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
				DataSet rsLocal = null;
				int mCnt = 0;

				mysql = " select pp.* , pbt.bill_no, pbt.l_bill_name , ppg.penalty_group_no , ppg.l_group_name";
				mysql = mysql + " from pay_penalty pp";
				mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = pp.bill_cd";
				mysql = mysql + " left join pay_penalty_group ppg on ppg.penalty_group_cd = pp.penalty_group_cd";
				mysql = mysql + " where penalty_cd= " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{
					mSearchValue = localRec["penalty_cd"];
					mTimeStamp = Convert.ToString(localRec["time_stamp"]);
					txtPenaltyNo.Text = Convert.ToString(localRec["Penalty_No"]);
					txtLPenaltyName.Text = Convert.ToString(localRec["l_penalty_name"]);
					txtAPenaltyName.Text = Convert.ToString(localRec["a_penalty_name"]) + "";
					txtBillNo.Text = Convert.ToString(localRec["bill_no"]);
					txtBillCdName.Text = Convert.ToString(localRec["l_bill_name"]);
					txtPenaltyGroupCd.Text = Convert.ToString(localRec["penalty_group_no"]) + "";
					txtDlblPenaltyGroupName.Text = Convert.ToString(localRec["l_group_name"]) + "";
					//Change the form mode to edit
					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				}
				localRec.Close();

				// Get Details Penalty Setup
				rsLocal = new DataSet();
				mysql = "select repetition_no,l_penalty_desc,a_penalty_desc,penalty_value";
				mysql = mysql + " from Pay_Penalty_Setup";
				mysql = mysql + " where penalty_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLocal.Tables.Clear();
				adap_2.Fill(rsLocal);
				aVoucherDetails.RedimXArray(new int[]{rsLocal.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
				mCnt = 0;
				foreach (DataRow iteration_row in rsLocal.Tables[0].Rows)
				{
					aVoucherDetails.SetValue(iteration_row["repetition_no"], mCnt, mRepetitionNo);
					aVoucherDetails.SetValue(iteration_row["l_penalty_desc"], mCnt, mLPenaltyDesc);
					aVoucherDetails.SetValue(iteration_row["a_penalty_desc"], mCnt, mAPenaltyDesc);
					aVoucherDetails.SetValue(iteration_row["penalty_value"], mCnt, mPenaltyValue);
					mCnt++;
				}

				AssignGridLineNumbers();
				grdPenaltySetup.Rebind(true);
				grdPenaltySetup.Refresh();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}

		}

		public void PrintReport()
		{

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7064000));
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
			if (!Information.IsNumeric(txtPenaltyNo.Text))
			{
				MessageBox.Show("Enter Penalty Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstFocusObject.Focus();
				return false;
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(txtLPenaltyName.Text))
			{
				MessageBox.Show("Enter Penalty Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtLPenaltyName.Focus();
				return false;
			}
			if (SystemProcedure2.IsItEmpty(txtBillNo.Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Bill Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtBillNo.Focus();
				return false;
			}
			return true;
		}



		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmPayQualification.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtBillNo_DropButtonClick(Object Sender, EventArgs e)
		{
			//Dim mTempSearchValue As Variant
			//Dim mySQL As String
			//mySQL = " pbt.show =  1 "
			//mTempSearchValue = FindItem(7008000, "775", mySQL)
			//If Not IsNull(mTempSearchValue) Then
			//    txtBillNo.Text = mTempSearchValue(1)
			//    mBillCd = mTempSearchValue(0)
			//    Call txtBillNo_LostFocus
			//End If
			FindRoutine("txtBillNo");
		}

		private void txtBillNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;
			if (!SystemProcedure2.IsItEmpty(txtBillNo.Text, SystemVariables.DataType.NumberType))
			{
				mysql = " select bill_cd from pay_billing_type where bill_no=" + txtBillNo.Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mBillCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_bill_name" : " a_bill_name") + " as Name";
					mysql = mysql + " from pay_billing_type where bill_cd =" + mBillCd.ToString();

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtBillCdName.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}
				}
				else
				{
					MessageBox.Show("Bill Code is not correct!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtBillCdName.Text = "";
					txtBillNo.Text = "";
				}
			}
			else
			{
				txtBillCdName.Text = "";
				txtBillNo.Text = "";
			}
		}



		private void txtPenaltyGroupCd_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtPenaltyGroupCd");
		}

		private void txtPenaltyGroupCd_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;
			if (!SystemProcedure2.IsItEmpty(txtPenaltyGroupCd.Text, SystemVariables.DataType.NumberType))
			{
				mysql = " select penalty_group_cd from pay_penalty_group where penalty_group_no=" + txtPenaltyGroupCd.Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mPenaltyGroupCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_group_name" : " a_group_name") + " as Name";
					mysql = mysql + " from pay_penalty_group where penalty_group_cd =" + mPenaltyGroupCd.ToString();

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDlblPenaltyGroupName.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					}
				}
				else
				{
					MessageBox.Show("Penalty Group Code is not correct!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtDlblPenaltyGroupName.Text = "";
					txtPenaltyGroupCd.Text = "";
				}
			}
			else
			{
				txtDlblPenaltyGroupName.Text = "";
				txtPenaltyGroupCd.Text = "";
			}
		}

		private void txtPenaltyNo_DropButtonClick(Object Sender, EventArgs e)
		{
			GetNextNumber();
		}

		public void GetNextNumber()
		{
			txtPenaltyNo.Text = SystemProcedure2.GetNewNumber("pay_penalty", "penalty_no");
			FirstFocusObject.Focus();
		}


		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;
			string mysql = "";

			if (pObjectName == "txtBillNo")
			{
				mysql = " pbt.show =  1 and pbt.bill_type_id = 52";
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7008000, "775", mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtBillNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mBillCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempSearchValue).GetValue(0));
					txtBillNo_Leave(txtBillNo, new EventArgs());
				}
			}
			else if (pObjectName == "txtPenaltyGroupCd")
			{ 
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220620, "2742"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtPenaltyGroupCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mPenaltyGroupCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempSearchValue).GetValue(0));
					txtPenaltyGroupCd_Leave(txtPenaltyGroupCd, new EventArgs());
				}
			}
		}

		public void IRoutine()
		{
			int mCurrentLineNo = 0;

			if (ActiveControl.Name != "grdPenaltySetup" && grdPenaltySetup.Enabled)
			{
				grdPenaltySetup.Focus();
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdPenaltySetup.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdPenaltySetup.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdPenaltySetup.Columns[mconLineNo].Value);
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdPenaltySetup.Bookmark), 1);
				AssignGridLineNumbers();
				grdPenaltySetup.Rebind(true);
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdPenaltySetup" && grdPenaltySetup.Enabled)
			{
				grdPenaltySetup.Focus();
			}

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdPenaltySetup.Delete();
				AssignGridLineNumbers();
				grdPenaltySetup.Rebind(true);
			}
		}
	}
}