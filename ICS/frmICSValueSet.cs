
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmICSValueSet
		: System.Windows.Forms.Form
	{

		
		public frmICSValueSet()
{
InitializeComponent();
} 
 public  void frmICSValueSet_old()
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

		private int mThisFormID = 0; //Assign the Formid for Each Form
		private clsToolbar oThisFormToolBar = null;
		private string mTimeStamp = "";
		private bool mFirstGridFocus = false;
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

		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		private const int grdCodeColumn = 1;
		private const int grdLDescColumn = 2;
		private const int grdLShortDescColumn = 3;
		private const int grdADescColumn = 4;
		private const int grdAShortDescColumn = 5;

		private const int conTXTLSetName = 0;
		private const int conTXTLSetShortName = 1;
		private const int conTXTASetName = 2;
		private const int conTXTASetShortName = 3;
		private const int conTxtComments = 4;

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



		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					FirstFocusObject.Focus();
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				FirstFocusObject = cmbSetCode;
				//picFormToolbar.Visible = False
				grdVoucherDetails.Visible = false;

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
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);


				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //setting form mode to add initially
				mFirstGridFocus = true;

				cmbSetObject.AddItem("ICS_Item");
				cmbSetObject.Text = "ICS_Item";
				//cmbSetObject.Enabled = False
				cmbSetObject.AddItem("ICS Trans");
				cmbSetObject.Text = "ICS Trans";

				object i = null;
				for (i = 1; ReflectionHelper.GetPrimitiveValue<double>(i) <= 20; i = ReflectionHelper.GetPrimitiveValue<double>(i) + 1)
				{
					cmbSetCode.AddItem(ReflectionHelper.GetPrimitiveValue<string>(i));
				}

				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder);
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Code", 1400, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "", false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Desc(English)", 2700, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "", false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Short Desc(English)", 2700, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "", false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Desc(Arabic)", 2700, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "", false, true, false, false, false, false, 100, "", "Arabic Transparent");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Short Desc(Arabic)", 2700, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "", false, true, false, false, false, false, 100, "", "Arabic Transparent");


				//setting voucher details grid properties
				DefineVoucherArray(0, true);


				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				//-- end of voucher grid property setting


				grdVoucherDetails.Visible = true;
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

				//if the user presses any control key in the voucher grid object
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

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				aVoucherDetails = null;
				UserAccess = null;
				oThisFormToolBar = null;
				frmICSValueSet.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void DefineVoucherArray(int pMaximumRows, bool pClearArray = false)
		{
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
			}
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, 9}, new int[]{0, 0});
		}

		public bool saveRecord(bool pApprove = false)
		{
			bool result = false;
			object mReturnValue = null;

			int Cnt = 0;
			string mysql = "";

			try
			{


				SystemVariables.gConn.BeginTransaction();
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into SM_Value_Set ";
					mysql = mysql + " (vs_object_type, vs_code, vs_l_name, vs_l_short_name, vs_a_name, vs_a_short_name, vs_remarks ";
					mysql = mysql + " , user_cd)";
					mysql = mysql + " values ( ";
					mysql = mysql + " '" + cmbSetObject.Text + "'";
					mysql = mysql + " , " + cmbSetCode.Text;
					mysql = mysql + " , '" + txtCommonTextBox[conTXTLSetName].Text + "'";
					mysql = mysql + " , '" + txtCommonTextBox[conTXTLSetShortName].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTXTASetName].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTXTASetShortName].Text + "'";
					mysql = mysql + " , N'" + txtCommonTextBox[conTxtComments].Text + "'";
					mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " ) ";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();


					mysql = " select scope_identity() ";
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
						MessageBox.Show("Error : Can not proceed with save!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}
				}
				else
				{
					mysql = " select time_stamp from SM_Value_Set where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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

					mysql = " update SM_Value_Set set ";
					mysql = mysql + " vs_object_type ='" + cmbSetObject.Text + "'";
					mysql = mysql + " , vs_code ='" + cmbSetCode.Text + "'";
					mysql = mysql + " , vs_l_name = '" + txtCommonTextBox[conTXTLSetName].Text + "'";
					mysql = mysql + " , vs_l_short_name = N'" + txtCommonTextBox[conTXTLSetShortName].Text + "'";
					mysql = mysql + " , vs_a_name = N'" + txtCommonTextBox[conTXTASetName].Text + "'";
					mysql = mysql + " , vs_a_short_name = N'" + txtCommonTextBox[conTXTASetShortName].Text + "'";
					mysql = mysql + " , vs_remarks = N'" + txtCommonTextBox[conTxtComments].Text + "'";
					mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where entry_id=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}

				//''Delete from pay_salary_variation
				mysql = " delete from SM_VS_Static_Value ";
				mysql = mysql + " where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					mysql = " insert into SM_VS_Static_Value";
					mysql = mysql + " (entry_id, vssv_code, vssv_l_name, vssv_l_short_name, vssv_a_name, vssv_a_short_name, user_cd)";
					mysql = mysql + " values ( ";
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					mysql = mysql + " ,'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, grdCodeColumn)) + "'";
					mysql = mysql + " ,'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, grdLDescColumn)) + "'";
					mysql = mysql + " , '" + Convert.ToString(aVoucherDetails.GetValue(Cnt, grdLShortDescColumn)) + "'";
					mysql = mysql + " , N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, grdADescColumn)) + "'";
					mysql = mysql + " , N'" + Convert.ToString(aVoucherDetails.GetValue(Cnt, grdAShortDescColumn)) + "'";
					mysql = mysql + " ," + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + ")";

					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();
				}



				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;

				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
			}
			return result;
		}

		public bool CheckDataValidity()
		{
			int Cnt = 0;


			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTXTLSetName].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Set Name(English)", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				goto mend;
			}


			//*-- update all the current voucher grid information in grid's internal buffer
			grdVoucherDetails.UpdateData();

			if (aVoucherDetails.GetLength(0) <= 0)
			{
				MessageBox.Show("No Details Entered!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				grdVoucherDetails.Col = grdCodeColumn;
				grdVoucherDetails.Focus();
				goto mend;
			}


			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(Cnt, grdCodeColumn), SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Invalid Code !", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					grdVoucherDetails.Col = grdCodeColumn;
					grdVoucherDetails.Bookmark = Cnt;
					grdVoucherDetails.Focus();
					goto mend;
				}

			}





			return true;
			mend:
			return false;
		}

		public void AddRecord()
		{
			int Cnt = 0;

			try
			{

				int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					grdVoucherDetails.Columns[Cnt].FooterText = "";
				}

				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode

				//''''*************************************************************************
				//Set the form caption
				//Call SetFormCaption(mOldVoucherStatus, Me, stActive, CurrentFormMode, IIf(gPreferedLanguage = Arabic, "Salary Variation", "Salary Variation"))
				//''''*************************************************************************

				SystemProcedure2.ClearTextBox(this);
				SystemProcedure2.ClearDateBox(this);
				SystemProcedure2.ClearNumberBox(this);
				DefineVoucherArray(0, true);
				grdVoucherDetails.Rebind(true);

				mSearchValue = ""; //Change the msearchvalue to blank
				mFirstGridFocus = true;
				cmbSetCode.Enabled = true;
				cmbSetObject.Enabled = true;
				FirstFocusObject.Focus();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}


		}


		public void GetRecord(object pSearchValue)
		{
			//On Error GoTo eFoundError
			int Cnt = 0;


			string mysql = " select * from SM_Value_Set where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

			SqlDataReader localRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand.ExecuteReader();
			bool localRecDidRead = localRec.Read();
			if (localRecDidRead)
			{
				//UPGRADE_WARNING: (1068) pSearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(pSearchValue);
				mTimeStamp = Convert.ToString(localRec["time_stamp"]);

				cmbSetObject.Text = Convert.ToString(localRec["vs_object_type"]);
				cmbSetCode.Text = Convert.ToString(localRec["vs_code"]) + "";
				txtCommonTextBox[conTXTLSetName].Text = Convert.ToString(localRec["vs_l_name"]) + "";
				txtCommonTextBox[conTXTLSetShortName].Text = Convert.ToString(localRec["vs_l_short_name"]) + "";
				txtCommonTextBox[conTXTASetName].Text = Convert.ToString(localRec["vs_a_name"]) + "";
				txtCommonTextBox[conTXTASetShortName].Text = Convert.ToString(localRec["vs_a_short_name"]) + "";
				txtCommonTextBox[conTxtComments].Text = Convert.ToString(localRec["vs_remarks"]) + "";

				//Change the form mode to edit
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;

			}
			localRec.Close();

			DefineVoucherArray(0, true);
			mysql = " select * from SM_VS_Static_Value where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

			SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand_2.ExecuteReader();
			bool localRecDidRead2 = localRec.Read();
			if (localRecDidRead)
			{
				do 
				{
					DefineVoucherArray(Cnt, false);
					aVoucherDetails.SetValue(Conversion.Str(Cnt + 1).Trim(), Cnt, SystemICSConstants.grdLineNoColumn);
					aVoucherDetails.SetValue(localRec["vssv_code"], Cnt, grdCodeColumn);
					aVoucherDetails.SetValue(localRec["vssv_l_name"], Cnt, grdLDescColumn);
					aVoucherDetails.SetValue(localRec["vssv_l_short_name"], Cnt, grdLShortDescColumn);
					aVoucherDetails.SetValue(localRec["vssv_a_name"], Cnt, grdADescColumn);
					aVoucherDetails.SetValue(localRec["vssv_a_short_name"], Cnt, grdAShortDescColumn);

					Cnt++;
				}
				while(localRec.Read());
			}

			grdVoucherDetails.Rebind(true);

			if (ControlHelper.GetEnabled(FirstFocusObject))
			{
				FirstFocusObject.Focus();
			}

			//added by Moiz Hakimi ghee
			//date: 02-feb-2008
			if (cmbSetCode.Enabled)
			{
				cmbSetCode.Enabled = false;
			}

			if (cmbSetObject.Enabled)
			{
				cmbSetObject.Enabled = false;
			}
			//end

			localRec.Close();
			return;


			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
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
			SystemReports.GetCrystalReport(110013095, 2, "8147", Conversion.Str(mEntryId), false);
		}


		public void CloseForm()
		{
			this.Close();
		}


		public void IRoutine()
		{
			int mCurrentLineNo = 0;

			if (ActiveControl.Name != "grdVoucherDetails")
			{
				grdVoucherDetails.Focus();
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdVoucherDetails.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdVoucherDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[SystemICSConstants.grdLineNoColumn].Value);
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), 1);
				grdVoucherDetails.Rebind(true);
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdVoucherDetails")
			{
				grdVoucherDetails.Focus();
			}

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdVoucherDetails.Delete();
				grdVoucherDetails.Rebind(true);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			//Dim cnt As Long
			//
			//cmbMastersList.Width = 0
			//
			//Select Case grdVoucherDetails.Col
			//    Case grdEmployeeCodeColumn, grdEmployeeNameColumn
			//        If grdVoucherDetails.Col = grdEmployeeCodeColumn Then
			//            cmbMastersList.ListField = "emp_no"
			//            rsBillingCodeList.Sort = "emp_no"
			//        Else
			//            cmbMastersList.ListField = "full_name"
			//            rsBillingCodeList.Sort = "full_name"
			//        End If
			//
			//        For cnt = 0 To cmbMastersList.Columns.Count - 1
			//            With cmbMastersList.Columns(cnt)
			//                If cnt < 3 Then
			//                    If cnt = 0 Then
			//                        .Order = IIf(grdVoucherDetails.Col = grdEmployeeCodeColumn, 0, 1)
			//                        .Width = grdVoucherDetails.Columns(grdEmployeeCodeColumn).Width
			//                    ElseIf cnt = 1 Then
			//                        .Order = IIf(grdVoucherDetails.Col = grdEmployeeCodeColumn, 1, 0)
			//                        .Width = grdVoucherDetails.Columns(grdEmployeeNameColumn).Width
			//                    ElseIf cnt = 2 Then
			//                        '.Width = grdVoucherDetails.Columns(grdBillingTypeColumn).Width
			//                    End If
			//                    .Alignment = dbgLeft
			//                    .Visible = True
			//                    cmbMastersList.Width = cmbMastersList.Width + .Width
			//                Else
			//                    .Visible = False
			//                End If
			//                .AllowSizing = False
			//            End With
			//        Next
			//        cmbMastersList.Width = cmbMastersList.Width + 250
			//        cmbMastersList.Height = 2500
			//End Select
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001005));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			//grdVoucherDetails.Columns(grdLineNoColumn).Text = grdVoucherDetails.ApproxCount + 1

		}

		public void FindRoutine(string pObjectName)
		{
			//Dim mySql As String

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

			//Select Case mIndex
			//    Case conTxtTrainingCode
			//        txtCommonTextBox(conTxtTrainingCode).Text = ""
			//        mTempSearchValue = FindItem(7003500, "1881")
			//        If Not IsNull(mTempSearchValue) Then
			//            txtCommonTextBox(conTxtTrainingCode).Text = mTempSearchValue(1)
			//            Call txtCommonTextBox_LostFocus(mIndex)
			//        End If
			//    Case Else
			//        Exit Sub
			//End Select
		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			try
			{
				object mTempValue = null;
				string mysql = "";
				int Cnt = 0;
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

		public bool deleteRecord()
		{

			SystemVariables.gConn.BeginTransaction();

			string mysql = "delete from SM_VS_Static_Value where entry_id=" + Conversion.Str(mSearchValue);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = "delete from SM_Value_Set where entry_id=" + Conversion.Str(mSearchValue);
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

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
	}
}