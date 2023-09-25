
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayProjectEmpDetails
		: System.Windows.Forms.Form
	{

		public frmPayProjectEmpDetails()
{
InitializeComponent();
} 
 public  void frmPayProjectEmpDetails_old()
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


		private void frmPayProjectEmpDetails_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
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

		private clsToolbar oThisFormToolBar = null;
		int mThisFormID = 0;
		private int mFormCallType = 0;
		private object mSearchValue = null;
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
		private bool mFirstGridFocus = false;
		private DataSet _rsProjectCodeList = null;
		private DataSet rsProjectCodeList
		{
			get
			{
				if (_rsProjectCodeList is null)
				{
					_rsProjectCodeList = new DataSet();
				}
				return _rsProjectCodeList;
			}
			set
			{
				_rsProjectCodeList = value;
			}
		}



		private const int conLineNo = 0;
		private const int conProjectNo = 1;
		private const int conProjectNAme = 2;
		private const int conPercentage = 3;
		private const int conProjectCd = 4;

		private const int conMaxColumns = 5;

		private const int txtDlblEmpCode = 0;
		private const int txtDlblEmpName = 1;

		int mEmpCd = 0;


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



		public int FormCallType
		{
			get
			{
				return mFormCallType;
			}
			set
			{
				mFormCallType = value;
			}
		}


		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (Shift == 0 && KeyCode == 116 && !mFirstGridFocus)
				{
					DefineMasterRecordset();
				}

				if (this.ActiveControl.Name == "grdVoucherDetails")
				{
					if (KeyCode == 13 || KeyCode == 113)
					{
						return;
					}
					else if (KeyCode == 222)
					{  //'for "'"
						KeyCode = 0;
						return;
					}
					if (Shift == 0)
					{
						if (grdVoucherDetails.Col == conPercentage)
						{
							if ((KeyCode == 8) || (KeyCode == 46) || (KeyCode == 27))
							{
								//
							}
							else if ((KeyCode >= 48 && KeyCode <= 57) || (KeyCode >= 96 && KeyCode <= 105) || (KeyCode == 190) || (KeyCode == 110))
							{ 
								//
							}
							else
							{
								KeyCode = 0;
							}
						}
					}
				}


				if (KeyCode == 13)
				{
					SendKeys.Send("{TAB}");
					return;
				}
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

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
				oThisFormToolBar.ShowHelpButton = false;
				oThisFormToolBar.ShowInsertLineButton = false;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.4f, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Project Code", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Project Name", 3000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Percentage", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.General);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "ProjectCd.", 800, true, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Enabled = false;
				mFirstGridFocus = true;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}

		}

		public void CloseForm()
		{
			this.Close();
		}

		public void AddRecord()
		{
			int cnt = 0;

			try
			{

				int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					grdVoucherDetails.Columns[cnt].FooterText = "";
				}

				SystemProcedure2.ClearTextBox(this);
				DefineVoucherArray(-1, true);

				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Enabled = false;

				mSearchValue = ""; //Change the msearchvalue to blank
				mFirstGridFocus = true;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}

		}

		public bool saveRecord()
		{
			bool result = false;
			StringBuilder mysql = new StringBuilder();
			int cnt = 0;

			try
			{

				SystemVariables.gConn.BeginTransaction();
				mysql = new StringBuilder("delete from pay_project_emp_details");
				mysql.Append(" where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue));
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql.ToString();
				TempCommand.ExecuteNonQuery();

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, conProjectCd), SystemVariables.DataType.NumberType))
					{
						mysql = new StringBuilder(" insert into pay_project_emp_details(emp_cd,project_cd,percentage,user_cd)");
						mysql.Append(" values(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue));
						mysql.Append(" ," + Convert.ToString(aVoucherDetails.GetValue(cnt, conProjectCd)));
						mysql.Append(" ," + Convert.ToString(aVoucherDetails.GetValue(cnt, conPercentage)));
						mysql.Append(" ," + SystemVariables.gLoggedInUserCode.ToString());
						mysql.Append(" )");
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql.ToString();
						TempCommand_2.ExecuteNonQuery();
					}
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
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			return result;
		}

		public bool CheckDataValidity()
		{
			int cnt = 0;
			double mTotal = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mTotal += Convert.ToDouble(aVoucherDetails.GetValue(cnt, conPercentage));
			}

			if (mTotal > 100)
			{
				MessageBox.Show("Percentage cannot be more than 100.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			return true;
		}

		public void findRecord()
		{
			//Call the find window
			string mysql = " pay_emp.status_cd not in (3,4) ";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831,832,833,834", mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[txtDlblEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				txtDisplayLabel[txtDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(2)) + " " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(3)) + " " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(4));
				GetRecord(mSearchValue);
			}
		}

		public void GetRecord(object SearchValue)
		{
			try
			{
				string mysql = "";
				object mReturnValue = null;
				SqlDataReader localRec = null;
				int cnt = 0;

				mysql = " select pped.project_cd,gp.project_no, gp.l_project_name, pped.percentage";
				mysql = mysql + " from pay_project_emp_details pped";
				mysql = mysql + " inner join gl_projects gp on gp.project_cd = pped.project_cd";
				mysql = mysql + " where pped.emp_cd= " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				localRec.Read();
				cnt = 0;
				do 
				{
					DefineVoucherArray(cnt, false);
					aVoucherDetails.SetValue(Conversion.Str(cnt + 1).Trim(), cnt, conLineNo);
					aVoucherDetails.SetValue(localRec["project_no"], cnt, conProjectNo);
					aVoucherDetails.SetValue(Convert.ToString(localRec["l_project_name"]) + "", cnt, conProjectNAme);
					aVoucherDetails.SetValue(localRec["percentage"], cnt, conPercentage);
					aVoucherDetails.SetValue(localRec["project_cd"], cnt, conProjectCd);
					cnt++;
				}
				while(localRec.Read());

				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
				CalculateTotals();
				mFirstGridFocus = true;
				DefineMasterRecordset();
				grdVoucherDetails.Enabled = true;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
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

		private void DefineVoucherArray(int pMaximumRows, bool pClearArray = false)
		{
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
			}
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, conMaxColumns}, new int[]{0, 0});
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			switch(grdVoucherDetails.Col)
			{
				case conProjectNo : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList.setListField("project_no"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProjectCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsProjectCodeList.setSort("project_no"); 
					break;
				case conProjectNAme : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList.setListField("project_name"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProjectCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsProjectCodeList.setSort("project_name"); 
					break;
			}
			int tempForEndVar = cmbMastersList.Columns.Count - 1;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar = cmbMastersList.Splits[0].DisplayColumns[cnt];
				if (cnt < 4)
				{
					if (cnt == 0)
					{
						withVar.Visible = false;
					}
					else if (cnt == 1)
					{ 
						//.Order = IIf(grdVoucherDetails.Col = conProjectNo, 1, 0)
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[conProjectNo].Width;
						withVar.Visible = true;
					}
					else if (cnt == 2)
					{ 
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[conProjectNAme].Width;
						withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
						withVar.Visible = true;
						cmbMastersList.Width += withVar.Width / 15;
					}
				}
				else
				{
					withVar.Visible = false;
				}
				withVar.AllowSizing = false;
			}
			cmbMastersList.Width += 15;
			cmbMastersList.Height = 167;
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			switch(grdVoucherDetails.Col)
			{
				case conProjectNo : 
					grdVoucherDetails.Col = conProjectNAme; 
					break;
			}
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			if (grdVoucherDetails.Col == conProjectNo || grdVoucherDetails.Col == conProjectNAme)
			{
				if (grdVoucherDetails.Col == conProjectNo)
				{
					grdVoucherDetails.Columns[conProjectCd].Value = cmbMastersList.Columns[0].Value;
					grdVoucherDetails.Columns[conProjectNAme].Value = cmbMastersList.Columns[2].Value;
				}
				else
				{
					grdVoucherDetails.Columns[conProjectCd].Value = cmbMastersList.Columns[0].Value;
					grdVoucherDetails.Columns[conProjectNo].Value = cmbMastersList.Columns[1].Value;
				}
			}
		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdVoucherDetails.Col > 0 && LastCol > 0 && !mFirstGridFocus)
			{
				switch(grdVoucherDetails.Col)
				{
					case conProjectNo : case conProjectNAme : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsProjectCodeList); 
						break;
				}
			}

			//grdVoucherDetails_ButtonClick (grdVoucherDetails.Col)
			CalculateTotals();
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{
			int Col = 0;

			if (MsgId == 1)
			{
				grdVoucherDetails.Col = conProjectNo;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsProjectCodeList);
			}

		}
		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			if (mFirstGridFocus)
			{
				if (Convert.ToString(cmbMastersList.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList);
					cmbMastersList.Tag = "OK";
				}

				DefineMasterRecordset();
				mFirstGridFocus = false;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.PostMsg(1);
			}

		}

		private void DefineMasterRecordset()
		{
			string mSQL = "";

			if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
			{
				return;
			}

			if (mFirstGridFocus)
			{
				mSQL = " select project_cd, project_no ";
				mSQL = mSQL + ", " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_project_name " : " a_project_name ") + " as project_name ";
				mSQL = mSQL + " from gl_projects ";
				rsProjectCodeList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProjectCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsProjectCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mSQL, SystemVariables.gConn);
				rsProjectCodeList.Tables.Clear();
				adap.Fill(rsProjectCodeList);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsProjectCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsProjectCodeList.Requery(-1);
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == conPercentage)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###,###,##0.000");
				}
				else
				{
					Value = "";
				}
			}
		}

		private void grdVoucherDetails_ButtonClick(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			if (SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[conProjectCd].Value) || SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[conPercentage].Value))
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[conProjectNAme].Locked = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[conProjectNo].Locked = false;
			}
			else
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[conProjectNAme].Locked = true;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[conProjectNo].Locked = true;
			}
		}

		private void grdVoucherDetails_BeforeColUpdate(object eventSender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			object OldValue = eventArgs.OldValue;
			int Cancel = (eventArgs.Cancel) ? -1 : 0;
			try
			{
				try
				{
					string mSQL = "";
					object mReturnValue = null;
					object mTempValaue = null;
					DataSet rs = null;
					int mPrevProjectCd = 0;

					if (ColIndex == conPercentage)
					{
						if (SystemProcedure2.IsItEmpty(grdVoucherDetails.Columns[conProjectCd].Value))
						{
							MessageBox.Show("Invalid Project selection!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							Cancel = -1;
							return;
						}
						grdVoucherDetails.Refresh();
					}
					return;
				}
				catch (System.Exception excep)
				{
					Cancel = -1;
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			int mVDBookmark = 0;
			grdVoucherDetails.UpdateData();
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (ColIndex == conPercentage && !Convert.IsDBNull(grdVoucherDetails.Bookmark))
			{
				mVDBookmark = Convert.ToInt32(ReflectionHelper.GetPrimitiveValue<double>(grdVoucherDetails.Bookmark) + 1);
				CalculateTotals();
				grdVoucherDetails.Refresh();

				if ((mVDBookmark) >= aVoucherDetails.GetLength(0))
				{
					aVoucherDetails.AppendRows(1);
					grdVoucherDetails.Rebind(true);
					Application.DoEvents();
				}
				grdVoucherDetails.Bookmark = mVDBookmark;
			}
		}

		private void CalculateTotals()
		{
			int cnt = 0;

			double mTotalAmount = 0;
			mTotalAmount = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mTotalAmount += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, conPercentage)));
			}

			if (mTotalAmount != 0)
			{
				grdVoucherDetails.Columns[conPercentage].FooterText = StringsHelper.Format(mTotalAmount, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails.Columns[conPercentage].FooterText = "";
			}

		}


		public void LRoutine()
		{
			if (ActiveControl.Name != "grdVoucherDetails" && grdVoucherDetails.Enabled)
			{
				grdVoucherDetails.Focus();
			}

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdVoucherDetails.Delete();
				AssignGridLineNumbers();
				CalculateTotals();
				grdVoucherDetails.Rebind(true);
			}
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}