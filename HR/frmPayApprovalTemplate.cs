
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayApprovalTemplate
		: System.Windows.Forms.Form
	{

		public frmPayApprovalTemplate()
{
InitializeComponent();
} 
 public  void frmPayApprovalTemplate_old()
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


		private void frmPayApprovalTemplate_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		private string mTimeStamp = "";

		private DataSet _rsBillingCodeList = null;
		private DataSet rsBillingCodeList
		{
			get
			{
				if (_rsBillingCodeList is null)
				{
					_rsBillingCodeList = new DataSet();
				}
				return _rsBillingCodeList;
			}
			set
			{
				_rsBillingCodeList = value;
			}
		}

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

		private const int conMaxColumns = 3;

		private int mThisFormID = 0;
		private object mSearchValue = null;
		private clsToolbar oThisFormToolBar = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		private const int mconTxtTemplateTransNo = 0;
		private const int mconTxtTemplateNameEng = 1;
		private const int mconTxtTemplateNameArb = 2;

		private const int mconLineNo = 0;
		private const int mconGroupNo = 1;
		private const int mconGroupName = 2;
		//Private Const mconFreeze As Long = 3
		private const int mconGroupLineNo = 3;

		private int mApprovalTypeCd = 0;


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
			FirstFocusObject = txtTextBox[mconTxtTemplateNameEng];

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
				oThisFormToolBar.ShowHelpButton = false;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = false;

				this.WindowState = FormWindowState.Maximized;

				mFirstGridFocus = true;

				//''Asssign Earnings Details Grid
				SystemGrid.DefineSystemVoucherGrid(grdApprovalTemplate, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.9f, 1.4f, "&HBBC8CA", "&HBBC8CA");

				SystemGrid.DefineSystemVoucherGridColumn(grdApprovalTemplate, "LN", 400, false, "&HBBC8CA", ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdApprovalTemplate, "Group No", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdApprovalTemplate, "Group Name", 3250, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				//Call DefineSystemVoucherGridColumn(grdApprovalTemplate, "Freeze", 2500, , , , dbgCenter, False, , , , , , , , , , True)
				SystemGrid.DefineSystemVoucherGridColumn(grdApprovalTemplate, "GroupLineNo", 2500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdApprovalTemplate.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdApprovalTemplate.setArray(aVoucherDetails);
				grdApprovalTemplate.Rebind(true);

				SystemProcedure.SetLabelCaption(this);
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				//assign a next code
				txtTextBox[mconTxtTemplateTransNo].Text = SystemProcedure2.GetNewNumber("sys_approval_template", "Trans_No");
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{

			SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

			aVoucherDetails = null;
			rsBillingCodeList = null;
			UserAccess = null;
			oThisFormToolBar = null;

		}

		public void CloseForm()
		{
			this.Close();
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

				if (this.ActiveControl.Name != "txtCommonTextBox")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommonTextBox#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}


				//Call SystemFormKeyDown(Me, KeyCode, Shift, Me.ActiveControl.Name)
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void IRoutine()
		{
			int mCurrentLineNo = 0;

			if (ActiveControl.Name != "grdApprovalTemplate" && grdApprovalTemplate.Enabled)
			{
				grdApprovalTemplate.Focus();
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdApprovalTemplate.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdApprovalTemplate.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdApprovalTemplate.Columns[SystemICSConstants.grdLineNoColumn].Value);
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdApprovalTemplate.Bookmark), 1);
				AssignGridLineNumbers();
				grdApprovalTemplate.Rebind(true);
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdApprovalTemplate" && grdApprovalTemplate.Enabled)
			{
				grdApprovalTemplate.Focus();
			}

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdApprovalTemplate.Delete();
				AssignGridLineNumbers();
				grdApprovalTemplate.Rebind(true);
			}
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdApprovalTemplate.Col)
			{
				case mconGroupNo : case mconGroupName : 
					if (grdApprovalTemplate.Col == mconGroupNo)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("Group_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("Group_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("l_approval_group_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("l_approval_group_name");
					} 
					 
					int tempForEndVar = cmbMastersList.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersList.Splits[0].DisplayColumns[cnt];
						if (cnt < 4)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdApprovalTemplate.Col == mconGroupNo) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdApprovalTemplate.Splits[0].DisplayColumns[mconGroupNo].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdApprovalTemplate.Col == mconGroupNo) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdApprovalTemplate.Splits[0].DisplayColumns[mconGroupName].Width;
							}
							withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							withVar.Visible = true;
							cmbMastersList.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					cmbMastersList.Width += 17; 
					cmbMastersList.Height = 167; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			switch(grdApprovalTemplate.Col)
			{
				case mconGroupNo : case mconGroupName : 
					if (grdApprovalTemplate.Col == mconGroupNo)
					{
						grdApprovalTemplate.Col = mconGroupNo;
					}
					else
					{
						grdApprovalTemplate.Col = mconGroupName;
					} 
					break;
			}
		}

		private void DefineMasterRecordset()
		{
			string mysql = "";

			//If IsItEmpty(mSearchValue, NumberType) = True Then
			//    Exit Sub
			//End If

			if (mFirstGridFocus)
			{
				mysql = " select group_no ";
				mysql = mysql + " , l_approval_group_name, line_no, freeze ";
				mysql = mysql + " from Sys_Approval_Group ";
				mysql = mysql + " order by 1 ";


				rsBillingCodeList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsBillingCodeList.Tables.Clear();
				adap.Fill(rsBillingCodeList);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsBillingCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList.Requery(-1);
			}
		}

		private void grdApprovalTemplate_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			if (mFirstGridFocus)
			{
				if (Convert.ToString(cmbMastersList.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList);
					cmbMastersList.Tag = "OK";
				}

				DefineMasterRecordset();
				mFirstGridFocus = false;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdApprovalTemplate.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdApprovalTemplate.PostMsg(1);
			}
		}

		private void grdApprovalTemplate_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdApprovalTemplate.Col > 0 && LastCol > 0 && !mFirstGridFocus)
			{
				switch(grdApprovalTemplate.Col)
				{
					case mconGroupNo : case mconGroupName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList); 
						break;
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdApprovalTemplate.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdApprovalTemplate_PostEvent(int MsgId)
		{
			int Col = 0;

			if (MsgId == 1)
			{
				grdApprovalTemplate.Col = mconGroupNo;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList);
			}
		}

		//Private Sub grdApprovalTemplate_FetchCellStyle(ByVal Condition As Integer, ByVal Split As Integer, Bookmark As Variant, ByVal Col As Integer, ByVal CellStyle As TrueOleDBGrid80.StyleDisp)
		//If Col = mconFreeze Then
		//    If aVoucherDetails(Val(Bookmark), Col) = vbTrue Then
		//        Set CellStyle.ForegroundPicture = frmSysMain.imlSystemIcons.ListImages.Item("imgChecked2").Picture
		//        CellStyle.ForegroundPicturePosition = dbgFPPictureOnly
		//    ElseIf aVoucherDetails(Val(Bookmark), Col) = vbFalse Then
		//        Set CellStyle.ForegroundPicture = frmSysMain.imlSystemIcons.ListImages.Item("imgUnchecked").Picture
		//        CellStyle.ForegroundPicturePosition = dbgFPPictureOnly
		//    End If
		//End If
		//End Sub
		//
		//Private Sub grdApprovalTemplate_BeforeColEdit(ByVal ColIndex As Integer, ByVal KeyAscii As Integer, Cancel As Integer)
		//If (ColIndex = mconFreeze) And Not IsNull(grdApprovalTemplate.Bookmark) Then
		//    If aVoucherDetails(grdApprovalTemplate.Bookmark, ColIndex) = "" Then
		//        aVoucherDetails(grdApprovalTemplate.Bookmark, ColIndex) = 0
		//    End If
		//    If KeyAscii = 0 Or KeyAscii = 13 Or KeyAscii = 32 Then
		//        aVoucherDetails(grdApprovalTemplate.Bookmark, ColIndex) = Not aVoucherDetails(grdApprovalTemplate.Bookmark, ColIndex)
		//        grdApprovalTemplate.Update
		//        grdApprovalTemplate.Refresh
		//    End If
		//    Cancel = True
		//End If
		//End Sub

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			if (grdApprovalTemplate.Col == mconGroupNo || grdApprovalTemplate.Col == mconGroupName)
			{
				grdApprovalTemplate.Columns[mconGroupNo].Value = cmbMastersList.Columns[0].Value;
				grdApprovalTemplate.Columns[mconGroupName].Value = cmbMastersList.Columns[1].Value;
				grdApprovalTemplate.Columns[mconGroupLineNo].Value = cmbMastersList.Columns[2].Value;
			}
		}


		public bool saveRecord()
		{
			bool result = false;
			int i = 0;
			StringBuilder mysql = new StringBuilder();
			try
			{

				SystemVariables.gConn.BeginTransaction();
				grdApprovalTemplate.UpdateData();
				Application.DoEvents();
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = new StringBuilder("insert into sys_approval_template");
					mysql.Append(" (Trans_No,l_approval_name,a_approval_name,approval_type_entry_id)");
					mysql.Append(" values (");
					mysql.Append("'" + txtTextBox[mconTxtTemplateTransNo].Text + "'");
					mysql.Append(", '" + txtTextBox[mconTxtTemplateNameEng].Text + "'");
					mysql.Append(" , N'" + txtTextBox[mconTxtTemplateNameArb].Text + "'");
					mysql.Append(" , " + mApprovalTypeCd.ToString());
					mysql.Append(" )");
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql.ToString();
					TempCommand.ExecuteNonQuery();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));
				}
				else
				{
					mysql = new StringBuilder(" update sys_approval_template");
					mysql.Append(" set trans_no = '" + txtTextBox[mconTxtTemplateTransNo].Text + "'");
					mysql.Append(" , l_approval_name = '" + txtTextBox[mconTxtTemplateNameEng].Text + "'");
					mysql.Append(" , a_approval_name = '" + txtTextBox[mconTxtTemplateNameArb].Text + "'");
					mysql.Append(" where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue));
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql.ToString();
					TempCommand_2.ExecuteNonQuery();
				}

				mysql = new StringBuilder("delete from sys_approval_template_details");
				mysql.Append(" where template_entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue));
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql.ToString();
				TempCommand_3.ExecuteNonQuery();

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (i = 0; i <= tempForEndVar; i++)
				{
					mysql = new StringBuilder("insert sys_approval_template_details(template_entry_id,group_line_no,[rank] )");
					mysql.Append(" values (");
					mysql.Append(ReflectionHelper.GetPrimitiveValue<string>(mSearchValue));
					mysql.Append(" ," + Convert.ToString(aVoucherDetails.GetValue(i, mconGroupLineNo)));
					mysql.Append(" ," + ((i + 1).ToString()));
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
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}
			return result;
		}

		public void findRecord()
		{
			//Call the find window
			//mySql = " pd1.show = 1"
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220586));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void GetRecord(object pSearchValue)
		{
			string mysql = "";
			DataSet rsLocalRec = null;
			int cnt = 0;
			object mReturnValue = null;
			try
			{

				mysql = " select sate.Trans_No,sate.l_approval_name,sate.a_approval_name , sat.Approval_type_code , sat.l_Approval_Type_Name ";
				mysql = mysql + " from sys_approval_template sate";
				mysql = mysql + " inner join sys_approval_type sat on sat.entry_id = sate.approval_type_entry_id ";
				mysql = mysql + " where sate.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtTextBox[mconTxtTemplateTransNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtTextBox[mconTxtTemplateNameEng].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtTextBox[mconTxtTemplateNameArb].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtApprovalTypeCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDlblApprovalTypeNAme.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(4));
					txtApprovalTypeCode_Leave(txtApprovalTypeCode, new EventArgs());
				}
				else
				{
					txtTextBox[mconTxtTemplateTransNo].Text = "";
					txtTextBox[mconTxtTemplateNameEng].Text = "";
					txtTextBox[mconTxtTemplateNameArb].Text = "";
				}

				rsLocalRec = new DataSet();
				mysql = "select sag.group_no,sag.l_approval_group_name, sag.line_no";
				mysql = mysql + " from sys_approval_template_details satd";
				mysql = mysql + " inner join sys_approval_group sag on sag.line_no = satd.group_line_no";
				mysql = mysql + " Where satd.template_entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLocalRec.Tables.Clear();
				adap.Fill(rsLocalRec);
				aVoucherDetails.RedimXArray(new int[]{rsLocalRec.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
				cnt = 0;
				foreach (DataRow iteration_row in rsLocalRec.Tables[0].Rows)
				{
					aVoucherDetails.SetValue(iteration_row["group_no"], cnt, mconGroupNo);
					aVoucherDetails.SetValue(iteration_row["l_approval_group_name"], cnt, mconGroupName);
					aVoucherDetails.SetValue(iteration_row["line_no"], cnt, mconGroupLineNo);
					cnt++;
				}

				AssignGridLineNumbers();
				grdApprovalTemplate.Rebind(true);
				grdApprovalTemplate.Refresh();
				CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		public void AddRecord()
		{
			try
			{

				SystemProcedure2.ClearTextBox(this);
				DefineVoucherArray(-1, true);
				AssignGridLineNumbers();
				grdApprovalTemplate.Rebind(true);
				grdApprovalTemplate.Refresh();
				txtTextBox[mconTxtTemplateTransNo].Text = SystemProcedure2.GetNewNumber("sys_approval_template", "Trans_No");
				mSearchValue = ""; //Change the msearchvalue to blank
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}

		}


		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtApprovalTypeCode" : 
					txtApprovalTypeCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220588, "2628")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mApprovalTypeCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempSearchValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtApprovalTypeCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtApprovalTypeCode_Leave(txtApprovalTypeCode, new EventArgs());
					} 
					break;
				default:
					break;
			}
		}


		private void txtApprovalTypeCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtApprovalTypeCode");
		}

		private void txtApprovalTypeCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (SystemProcedure2.IsItEmpty(txtApprovalTypeCode.Text, SystemVariables.DataType.StringType))
			{
				return;
			}
			string mysql = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_approval_type_name " : " a_approval_type_name ");
			mysql = mysql + " from sys_approval_type sat";
			mysql = mysql + " where Approval_Type_Code ='" + txtApprovalTypeCode.Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDlblApprovalTypeNAme.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
			}
			else
			{
				txtApprovalTypeCode.Text = "";
				txtDlblApprovalTypeNAme.Text = "";
				// txtApprovalTypeCode.SetFocus
			}
		}
	}
}