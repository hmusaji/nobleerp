
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmARAPAutoAdjustVoucher
		: System.Windows.Forms.Form
	{

		public frmARAPAutoAdjustVoucher()
{
InitializeComponent();
} 
 public  void frmARAPAutoAdjustVoucher_old()
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


		private void frmARAPAutoAdjustVoucher_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		int mThisFormID = 0;
		object mSearchValue = null;
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


		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			//On Error GoTo eFoundError

			string mysql = "";
			object mReturnValue = null;
			string mGroupCd = "";

			if (txtGroupType.Text != "")
			{
				mysql = " select group_cd from gl_accnt_group ";
				mysql = mysql + " where group_no=" + txtGroupType.Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mGroupCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
				else
				{
					MessageBox.Show("Invalid group type ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtGroupType.Focus();
					return;
				}
			}
			else
			{
				mGroupCd = "";
			}

			if (SystemProcedure2.IsItEmpty(txtAsOnDate.Value, SystemVariables.DataType.DateType))
			{
				MessageBox.Show("Invalid Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtAsOnDate.Focus();
				return;
			}

			SystemVariables.gConn.BeginTransaction();

			if (chkUnAdjust.CheckState == CheckState.Unchecked)
			{
				ARAPAutoAdjust(ReflectionHelper.GetPrimitiveValue<string>(txtAsOnDate.Value), mGroupCd);
			}
			else
			{
				ARAPUnAdjust(ReflectionHelper.GetPrimitiveValue<string>(txtAsOnDate.Value), mGroupCd);
			}

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

			if (chkUnAdjust.CheckState == CheckState.Unchecked)
			{
				MessageBox.Show(" Voucher Adjusted successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show(" Voucher UnAdjusted successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			this.Close();

			return;


			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			MessageBox.Show((Double.Parse(Information.Err().Description) + Information.Err().Number).ToString(), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

			try
			{
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
			}
			catch
			{
			}


		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			this.Top = 67;
			this.Left = 33;

			txtAsOnDate.Value = DateTime.Today;

			//Call SetLabelCaption(Me)
			//If gPreferedLanguage = Arabic And GetSystemPreferenceSetting("flip_controls_in_arabic") = vbTrue Then
			//    Dim oFlipThisForm As New clsFlip
			//
			//    oFlipThisForm.SwapMe Me
			//End If

			cntMainParameter.Redraw = true;
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == ((int) Keys.Return))
				{ //Return or Enter key
					SendKeys.Send("{TAB}");
					return;
				}
				else if (KeyCode == ((int) Keys.Escape))
				{  //Escape key
					SystemForms.ToolBarButtonClick(this, "Exit");
					KeyCode = 0;
				}
				else if (KeyCode == 113)
				{  //F2 key
					FindRoutine(this.ActiveControl.Name);
					KeyCode = 0;
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
				UserAccess = null;
				frmARAPAutoAdjustVoucher.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void CloseForm()
		{
			cmdOKCancel_CancelClick(cmdOKCancel, null);
		}


		private void ARAPAutoAdjust(string pAsOnDate, string pGroupCd = "")
		{
			string mHeaderType = "";
			string mDetailType = "";

			string mysql = "";
			int mGroupLevel = 0;
			object mReturnValue = null;

			decimal mHeaderDueAmt = 0;
			decimal mDetailDueAmt = 0;
			decimal mAdjustAmt = 0;
			decimal mBalanceDetailDueAmt = 0;


			SqlDataReader rsTempRec = null;
			DataSet rsHeader = new DataSet();
			DataSet rsDetail = new DataSet();

			if (pGroupCd != "")
			{
				mysql = " select group_level from gl_accnt_group ";
				mysql = mysql + " where group_cd =" + pGroupCd;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mGroupLevel = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					mGroupLevel = 0;
				}

				mysql = " select l.ldgr_cd, l.type_cd from gl_ledger l ";
				mysql = mysql + " where l.parent_group_cd_" + mGroupLevel.ToString() + " =" + pGroupCd;
				mysql = mysql + " and l.type_cd =" + SystemGLConstants.gGLCustomerVendorTypeCode.ToString();
			}
			else
			{
				mysql = " select ldgr_cd, type_cd from gl_ledger ";
				mysql = mysql + " where type_cd =" + SystemGLConstants.gGLCustomerVendorTypeCode.ToString();
			}
			//   mySql = mySql & " and l.ldgr_cd = 148 "
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{
				mHeaderType = "D";
				mDetailType = "C";

				//    If rsTempRec("type_cd") = gGLCustomerVendorTypeCode Then
				//        mHeaderType = "C"
				//        mDetailType = "D"
				//    ElseIf rsTempRec("ldgr_type") = gGLCustomerVendorTypeCode Then
				//        mHeaderType = "D"
				//        mDetailType = "C"
				//    End If

				mysql = "select dt.Line_No ";
				mysql = mysql + ", dt.fc_due_amt ";
				mysql = mysql + " FROM  gl_accnt_trans_Details dt ";
				mysql = mysql + " inner join gl_accnt_trans mt on dt.Entry_Id = mt.Entry_Id";
				mysql = mysql + " where dt.dr_cr_type='" + mHeaderType + "'";
				mysql = mysql + " and dt.ldgr_cd=" + Convert.ToString(rsTempRec["ldgr_cd"]);
				//mySql = mySql & " and atd.fc_paid_amt<> atd.fc_voucher_amt "
				mysql = mysql + " and dt.fc_due_amt <> 0 ";
				mysql = mysql + " and mt.voucher_date <='" + pAsOnDate + "'";
				mysql = mysql + " order by mt.voucher_date";
				SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsHeader.Tables.Clear();
				adap_2.Fill(rsHeader);

				mysql = " select dt.Line_No ";
				mysql = mysql + ", dt.fc_due_amt ";
				mysql = mysql + " from gl_accnt_trans  as mt ";
				mysql = mysql + " inner join gl_accnt_trans_Details as dt ON mt.entry_id = dt.entry_id ";
				mysql = mysql + " where dt.Dr_Cr_Type='" + mDetailType + "'";
				mysql = mysql + " and dt.ldgr_cd=" + Convert.ToString(rsTempRec["ldgr_cd"]);
				//mySql = mySql & " and (ATD.fc_voucher_amt <> ATD.fc_paid_amt) "
				mysql = mysql + " and dt.fc_due_amt <> 0 ";
				mysql = mysql + " and mt.voucher_date <='" + pAsOnDate + "'";
				mysql = mysql + " order by mt.voucher_date ";
				SqlDataAdapter adap_3 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsDetail.Tables.Clear();
				adap_3.Fill(rsDetail);

				foreach (DataRow iteration_row_2 in rsHeader.Tables[0].Rows)
				{
					mHeaderDueAmt = Convert.ToDecimal(iteration_row_2["fc_due_amt"]);


					while(rsDetail.Tables[0].Rows.Count != 0)
					{
						if (mBalanceDetailDueAmt == 0)
						{
							mDetailDueAmt = Convert.ToDecimal(rsDetail.Tables[0].Rows[0]["fc_due_amt"]);
						}

						if (mHeaderDueAmt >= mDetailDueAmt)
						{
							mAdjustAmt = mDetailDueAmt;
						}
						else
						{
							mAdjustAmt = mHeaderDueAmt;
						}

						mHeaderDueAmt -= mAdjustAmt;
						mDetailDueAmt -= mAdjustAmt;

						mysql = "select adjusted_amt from gl_invoice_Tracking where";
						mysql = mysql + " source_line_no=" + Conversion.Str(iteration_row_2["line_no"]);
						mysql = mysql + " and against_line_no=" + Conversion.Str(rsDetail.Tables[0].Rows[0]["line_no"]);

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							mysql = " update gl_invoice_tracking set ";
							mysql = mysql + " adjusted_Amt = adjusted_Amt + " + mAdjustAmt.ToString();
							mysql = mysql + " where source_line_no =" + Conversion.Str(iteration_row_2["line_no"]);
							mysql = mysql + " and against_line_no =" + Conversion.Str(rsDetail.Tables[0].Rows[0]["line_no"]);
							SqlCommand TempCommand = null;
							TempCommand = SystemVariables.gConn.CreateCommand();
							TempCommand.CommandText = mysql;
							TempCommand.ExecuteNonQuery();
						}
						else
						{
							mysql = " insert into gl_invoice_tracking (source_line_no, ";
							mysql = mysql + " against_line_no, adjusted_amt, user_cd) values( ";
							mysql = mysql + Conversion.Str(iteration_row_2["line_no"]) + ",";
							mysql = mysql + Conversion.Str(rsDetail.Tables[0].Rows[0]["line_no"]) + ",";
							mysql = mysql + Conversion.Str(mAdjustAmt) + ",";
							mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";
							SqlCommand TempCommand_2 = null;
							TempCommand_2 = SystemVariables.gConn.CreateCommand();
							TempCommand_2.CommandText = mysql;
							TempCommand_2.ExecuteNonQuery();
						}

						if (mDetailDueAmt == 0)
						{
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDetail.MoveNext was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							rsDetail.MoveNext();
							mBalanceDetailDueAmt = 0;
						}
						else
						{
							mBalanceDetailDueAmt = mDetailDueAmt;
						}

						if (mHeaderDueAmt == 0)
						{
							goto HeaderMoveNext;
						}
					};

					HeaderMoveNext:;
				}

				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsHeader.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (rsHeader.getState() == ConnectionState.Open)
				{
				}

				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsDetail.State was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (rsDetail.getState() == ConnectionState.Open)
				{
				}
				mBalanceDetailDueAmt = 0;

			}
			while(rsTempRec.Read());
		}

		private void txtGroupType_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine(this.ActiveControl.Name);
		}

		private void txtGroupType_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";

				if (!SystemProcedure2.IsItEmpty(txtGroupType.Text, SystemVariables.DataType.StringType))
				{
					mysql = " select ";
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						mysql = mysql + " pg.l_group_name ";
					}
					else
					{
						mysql = mysql + " pg.a_group_name ";
					}
					mysql = mysql + " from gl_accnt_group pg ";
					mysql = mysql + " where pg.group_no ='" + txtGroupType.Text + "'";
					mysql = mysql + " and pg.show = 1 ";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtGroupName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtGroupName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					txtGroupName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					txtGroupType.Focus();
				}
			}
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtGroupType" : 
					txtGroupType.Text = ""; 
					 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1002000, "15")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtGroupType.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtGroupType_Leave(txtGroupType, new EventArgs());
					} 
					break;
				default:
					return;
			}

		}

		private void ARAPUnAdjust(string pAsOnDate, string pGroupCd = "")
		{
			string mysql = "";
			object mReturnValue = null;
			int mGroupLevel = 0;

			if (pGroupCd != "")
			{
				mysql = " select group_level from gl_accnt_group ";
				mysql = mysql + " where group_cd =" + pGroupCd;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mGroupLevel = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
				else
				{
					mGroupLevel = 0;
				}
			}

			//''source line no
			mysql = " delete from gl_invoice_tracking ";
			mysql = mysql + " where source_line_no in (";
			mysql = mysql + " select dt.line_no from gl_accnt_trans_details dt ";
			mysql = mysql + " inner join gl_accnt_trans mt on dt.entry_id = mt.entry_id ";
			mysql = mysql + " inner join gl_ledger l on dt.ldgr_cd = l.ldgr_cd ";
			mysql = mysql + " inner join gl_accnt_group ag on l.group_cd = ag.group_cd ";
			mysql = mysql + " where mt.voucher_date > '" + pAsOnDate + "'";
			mysql = mysql + " and mt.linked = 0 ";
			if (pGroupCd != "")
			{
				mysql = mysql + " and l.parent_group_cd_" + mGroupLevel.ToString() + " =" + pGroupCd;
			}
			mysql = mysql + " and l.type_cd =" + SystemGLConstants.gGLCustomerVendorTypeCode.ToString();
			mysql = mysql + " ) ";
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();


			//'against line No.
			mysql = " delete from gl_invoice_tracking ";
			mysql = mysql + " where against_line_no in (";
			mysql = mysql + " select dt.line_no from gl_accnt_trans_details dt ";
			mysql = mysql + " inner join gl_accnt_trans mt on dt.entry_id = mt.entry_id ";
			mysql = mysql + " inner join gl_ledger l on dt.ldgr_cd = l.ldgr_cd ";
			mysql = mysql + " inner join gl_accnt_group ag on l.group_cd = ag.group_cd ";
			mysql = mysql + " where mt.voucher_date > '" + pAsOnDate + "'";
			mysql = mysql + " and mt.linked = 0 ";
			if (pGroupCd != "")
			{
				mysql = mysql + " and l.parent_group_cd_" + mGroupLevel.ToString() + " =" + pGroupCd;
			}
			mysql = mysql + " and l.type_cd =" + SystemGLConstants.gGLCustomerVendorTypeCode.ToString();
			mysql = mysql + " ) ";
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

		}
	}
}