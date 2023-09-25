
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayDocumentDetails
		: System.Windows.Forms.Form
	{

		public frmPayDocumentDetails()
{
InitializeComponent();
} 
 public  void frmPayDocumentDetails_old()
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


		private void frmPayDocumentDetails_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private int mThisFormID = 0;
		private object mSearchValue = null;
		private clsToolbar oThisFormToolBar = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		private bool mDocumentFirstGridFocus = false;
		private bool mDocumentPlaceFirstGridFocus = false;
		private bool mGovernatFirstGridFocus = false;
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

		private DataSet _rsBillingCodeList1 = null;
		private DataSet rsBillingCodeList1
		{
			get
			{
				if (_rsBillingCodeList1 is null)
				{
					_rsBillingCodeList1 = new DataSet();
				}
				return _rsBillingCodeList1;
			}
			set
			{
				_rsBillingCodeList1 = value;
			}
		}

		private DataSet _rsBillingCodeList2 = null;
		private DataSet rsBillingCodeList2
		{
			get
			{
				if (_rsBillingCodeList2 is null)
				{
					_rsBillingCodeList2 = new DataSet();
				}
				return _rsBillingCodeList2;
			}
			set
			{
				_rsBillingCodeList2 = value;
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

		private int mLastCol = 0;
		private int mLastRow = 0;

		private const int grdLineNoColumn = 0;
		private const int grdDocumentCode = 1;
		private const int grdDocumentName = 2;
		private const int grdDocumentNo = 3;
		private const int grdIssueDate = 4;
		private const int grdExpireDate = 5;
		private const int grdPlaceOfDocument = 6;
		private const int grdGovernatCode = 7;
		private const int grdFilePath = 8;
		private const int grdFileOpen = 9;
		private const int grdPeriod = 10;
		private const int grdRemarksColumn = 11;
		private const int conMaxColumns = 11;

		private const int conTxtDocumentNo = 0;
		private const int conTxtDocumentCd = 1;
		private const int conTxtGovernateCd = 2;
		private const int conTxtPlaceOfDocument = 3;
		private const int conTxtComments = 4;
		private const int conTxtEmpCd = 5;
		private const int conTxtFilename = 6;

		private const int conNTxtPeriod = 0;
		private const int conNTxtFees = 1;

		private const int conDlblDocumentName = 0;
		private const int conDlblGovernateName = 1;
		private const int conDlblPlaceOfDocument = 2;
		private const int conDlblEmpName = 3;


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




		//Private Sub cmdGetFilename_Click()
		//On Error Resume Next
		//
		//'CommonDialog1.InitDir = GetPhotoPath
		//CommonDialog1.Filter = "BMP - JPG (*.bmp,*.jpg)|*.bmp; *.jpg"
		//
		//' Set the default files type to Word Documents
		//'CommonDialog1.FilterIndex = 1
		//
		//
		//CommonDialog1.Filename = ""
		//CommonDialog1.ShowOpen
		//If CommonDialog1.Filename = "" Then Exit Sub
		//txtCommonTextBox(conTxtFilename).Text = CommonDialog1.Filename
		//End Sub



		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				FirstFocusObject = grdVoucherDetails;

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
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				mDocumentFirstGridFocus = true;
				mDocumentPlaceFirstGridFocus = true;
				mGovernatFirstGridFocus = true;

				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2.9f, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Document Code", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Document Name", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Document No", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Issue Date", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "txtIssueDate");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Expire Date", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "txtExpireDate");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Place Of Document", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList1");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Place Of Issue", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList2");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "File Path", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "File Open", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, true, true, -1);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Period", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);

				C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				withVar = grdVoucherDetails.Splits[0].DisplayColumns[grdFileOpen];
				withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
				withVar.DataColumn.Caption = "File Open";
				withVar.AllowFocus = true;
				withVar.ButtonAlways = true;
				withVar.ButtonText = true;
				withVar.Width = 33;
				withVar.Style.Font = withVar.Style.Font.Change(bold:true, size:11, name:"Verdana");
				withVar.Style.ForeColor = Color.FromArgb(21, 64, 77);

				SystemProcedure.SetLabelCaption(this);

				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				//-- end of voucher grid property setting

				grdVoucherDetails.Visible = true;
				grdVoucherDetails.Enabled = false;
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
				string mFilePath = "";

				if (KeyCode == 13)
				{
					SendKeys.Send("{TAB}");
					return;
				}
				if (this.ActiveControl.Name == "grdVoucherDetails")
				{
					if (KeyCode == 113 && grdVoucherDetails.Col == grdFilePath)
					{
						//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						CommonDialog1Open.Filter = "All Files (*.*)|*.*";
						//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						CommonDialog1Open.FileName = "";
						CommonDialog1Open.ShowDialog();
						//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						if (CommonDialog1Open.FileName == "")
						{
							return;
						}
						//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						grdVoucherDetails.Columns[grdFilePath].Value = CommonDialog1Open.FileName;
					}
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

			DefineVoucherArray(-1, true);
			AssignGridLineNumbers();
			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Enabled = false;

			mDocumentFirstGridFocus = true;
			mDocumentPlaceFirstGridFocus = true;
			mGovernatFirstGridFocus = true;

			mSearchValue = "";
			//FirstFocusObject.SetFocus

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord(bool pPostGl = false)
		{
			bool result = false;
			object mReturnValue = null;
			string mysql = "";

			int mDocumentCd = 0;
			int mDocumentPlaceMasterCd = 0;
			int mGovernateCd = 0;
			int mCntRow = 0;
			int mDocumentEntId = 0;

			try
			{

				SystemVariables.gConn.BeginTransaction();

				mysql = " delete from sys_popup_details";
				mysql = mysql + " where popup_type_cd = 3 and entry_id in ( select entry_id from pay_document_detail where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ")";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mysql = " delete from pay_document_detail";
				mysql = mysql + " where emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				grdVoucherDetails.UpdateData();

				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (mCntRow = 0; mCntRow <= tempForEndVar; mCntRow++)
				{
					mysql = " select document_cd from pay_document_master ";
					mysql = mysql + " where document_no=" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, grdDocumentCode));
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mDocumentCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Invalid Document Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						goto mError;
					}

					if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCntRow, grdPlaceOfDocument), SystemVariables.DataType.NumberType))
					{
						mysql = " select place_master_cd from pay_document_place_master ";
						mysql = mysql + " where place_no=" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, grdPlaceOfDocument));
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mDocumentPlaceMasterCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
						}
						else
						{
							MessageBox.Show("Invalid Document Place Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							goto mError;
						}
					}
					else
					{
						mDocumentPlaceMasterCd = 0;
					}

					if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCntRow, grdGovernatCode), SystemVariables.DataType.NumberType))
					{
						mysql = " select governate_cd from pay_governate ";
						mysql = mysql + " where governate_no=" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, grdGovernatCode));
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mGovernateCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
						}
						else
						{
							MessageBox.Show("Invalid Governate Code!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							goto mError;
						}
					}
					else
					{
						mGovernateCd = 0;
					}

					mysql = " insert into pay_document_detail ";
					mysql = mysql + " (emp_cd, document_cd, document_no, issue_date, expiry_date ";
					mysql = mysql + " , place_master_cd , governate_cd, period, comments ";
					mysql = mysql + " , document_filename, user_cd) ";
					mysql = mysql + " values( ";
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					mysql = mysql + "," + mDocumentCd.ToString();
					mysql = mysql + ",'" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, grdDocumentNo)) + "'";

					if (Information.IsDate(aVoucherDetails.GetValue(mCntRow, grdIssueDate)))
					{
						mysql = mysql + " , '" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, grdIssueDate)) + "'";
					}
					else
					{
						mysql = mysql + " , NULL ";
					}

					if (Information.IsDate(aVoucherDetails.GetValue(mCntRow, grdExpireDate)))
					{
						mysql = mysql + " , '" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, grdExpireDate)) + "'";
					}
					else
					{
						mysql = mysql + " , NULL ";
					}

					if (mDocumentPlaceMasterCd == 0)
					{
						mysql = mysql + " , NULL ";
					}
					else
					{
						mysql = mysql + " , " + mDocumentPlaceMasterCd.ToString();
					}

					if (mGovernateCd == 0)
					{
						mysql = mysql + " , NULL ";
					}
					else
					{
						mysql = mysql + " , " + mGovernateCd.ToString();
					}

					if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCntRow, grdPeriod), SystemVariables.DataType.NumberType))
					{
						mysql = mysql + " , " + Convert.ToString(aVoucherDetails.GetValue(mCntRow, grdPeriod));
					}
					else
					{
						mysql = mysql + " , 0";
					}

					if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mCntRow, grdRemarksColumn), SystemVariables.DataType.StringType))
					{
						mysql = mysql + " , NULL";
					}
					else
					{
						mysql = mysql + " , N'" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, grdRemarksColumn)) + "'";
					}
					mysql = mysql + " , '" + Convert.ToString(aVoucherDetails.GetValue(mCntRow, grdFilePath)) + "'";
					mysql = mysql + " , " + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " )";
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDocumentEntId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(aVoucherDetails.GetValue(mCntRow, grdExpireDate)))
					{
						aVoucherDetails.SetValue(null, mCntRow, grdExpireDate);
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					SystemProcedure.InsertAlarmDetails(3, mDocumentEntId, (Convert.IsDBNull(aVoucherDetails.GetValue(mCntRow, grdRemarksColumn))) ? "" : Convert.ToString(aVoucherDetails.GetValue(mCntRow, grdRemarksColumn)), DateTimeHelper.ToString(Convert.ToDateTime(aVoucherDetails.GetValue(mCntRow, grdExpireDate)).AddDays(Convert.ToDouble(aVoucherDetails.GetValue(mCntRow, grdPeriod)) * -1)));
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				FirstFocusObject.Focus();
				return result;

				mError:
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				return false;
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


			SystemVariables.gConn.BeginTransaction();

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "delete from pay_document_detail where entry_id=" + Conversion.Str(mSearchValue);
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
				SystemProcedure.AlarmDelete(3, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));


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
				DataSet localRec = null;
				int mCntRow = 0;

				mysql = " select pemp.emp_no , pemp.l_full_name , pes.l_status_name ";
				mysql = mysql + " from pay_employee pemp ";
				mysql = mysql + " inner join pay_employee_status pes on pes.status_cd = pemp.status_cd ";
				mysql = mysql + " where pemp.emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[conTxtEmpCd].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtStatucCd.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
					//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(SearchValue);
				}

				mysql = "select pdm.document_no";
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					mysql = mysql + " , pdm.l_document_name document_name ";
					mysql = mysql + " , pdpm.l_place_name place_name ";
					mysql = mysql + " , pg.l_governate_name governate_name ";
				}
				else
				{
					mysql = mysql + " , pdm.a_document_name document_name ";
					mysql = mysql + " , pdpm.a_place_name place_name ";
					mysql = mysql + " , pg.a_governate_name governate_name ";
				}
				mysql = mysql + " , pdpm.place_no ";
				mysql = mysql + " , pg.governate_no ";
				mysql = mysql + " , pdd.document_no as docno, pdd.issue_date, pdd.expiry_date ";
				mysql = mysql + " , pdd.period, pdd.fees, pdd.comments, pdd.entry_id, pdd.time_stamp, pdd.document_filename ";
				mysql = mysql + " from pay_document_detail pdd ";
				mysql = mysql + " inner join pay_document_master pdm on pdd.document_cd = pdm.document_cd ";
				mysql = mysql + " left join pay_document_place_master pdpm on pdd.place_master_cd = pdpm.place_master_cd ";
				mysql = mysql + " left join pay_governate pg on pdd.governate_cd = pg.governate_cd ";
				mysql = mysql + " where pdd.emp_cd = " + Conversion.Str(SearchValue);

				mCntRow = 0;
				localRec = new DataSet();
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				localRec.Tables.Clear();
				adap.Fill(localRec);
				aVoucherDetails.RedimXArray(new int[]{localRec.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
				foreach (DataRow iteration_row in localRec.Tables[0].Rows)
				{
					aVoucherDetails.SetValue(mCntRow + 1, mCntRow, grdLineNoColumn);
					aVoucherDetails.SetValue(iteration_row["document_no"], mCntRow, grdDocumentCode);
					aVoucherDetails.SetValue(iteration_row["document_name"], mCntRow, grdDocumentName);
					aVoucherDetails.SetValue(iteration_row["docno"], mCntRow, grdDocumentNo);
					aVoucherDetails.SetValue(iteration_row["issue_date"], mCntRow, grdIssueDate);
					if (localRec.Tables[0].Rows[0].IsNull("expiry_date"))
					{
						aVoucherDetails.SetValue(null, mCntRow, grdExpireDate);
					}
					else
					{
						aVoucherDetails.SetValue(iteration_row["expiry_date"], mCntRow, grdExpireDate);
					}

					aVoucherDetails.SetValue(iteration_row["place_no"], mCntRow, grdPlaceOfDocument);
					aVoucherDetails.SetValue(iteration_row["governate_no"], mCntRow, grdGovernatCode);
					aVoucherDetails.SetValue(iteration_row["document_filename"], mCntRow, grdFilePath);
					aVoucherDetails.SetValue((localRec.Tables[0].Rows[0].IsNull("period")) ? ((object) 0) : iteration_row["period"], mCntRow, grdPeriod);
					aVoucherDetails.SetValue(iteration_row["comments"], mCntRow, grdRemarksColumn);
					mCntRow++;
				}
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);

				grdVoucherDetails.Enabled = true;
				FirstFocusObject.Focus();
				if (mDocumentFirstGridFocus)
				{
					grdVoucherDetails_GotFocus(grdVoucherDetails, new EventArgs());
				}
				if (mDocumentPlaceFirstGridFocus)
				{
					grdVoucherDetails_GotFocus(grdVoucherDetails, new EventArgs());
				}
				if (mGovernatFirstGridFocus)
				{
					grdVoucherDetails_GotFocus(grdVoucherDetails, new EventArgs());
				}
				Application.DoEvents();
				grdVoucherDetails.Refresh();

				localRec = null;
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
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000));
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

			//If IsItEmpty(txtCommonTextBox(conTxtEmpCd).Text, StringType) Then
			//    MsgBox "Enter Employee Code", vbInformation, "Required"
			//    txtCommonTextBox(conTxtEmpCd).SetFocus
			//    GoTo mError
			//End If
			//
			//If IsItEmpty(txtCommonTextBox(conTxtDocumentNo).Text, StringType) Then
			//    MsgBox "Enter Document No.", vbInformation, "Required"
			//    txtCommonTextBox(conTxtDocumentNo).SetFocus
			//    GoTo mError
			//End If
			//
			//
			//If Not IsNumeric(txtCommonTextBox(conTxtDocumentCd).Text) Then
			//    MsgBox "Enter Document Code", vbInformation, "Required"
			//    txtCommonTextBox(conTxtDocumentCd).SetFocus
			//    GoTo mError
			//End If
			//
			//If IsDate(txtIssueDate1.DisplayText) = True And IsDate(txtExpiryDate1.DisplayText) = True Then
			//    If txtExpiryDate1.Value < txtIssueDate1.Value Then
			//        MsgBox "Expiry Date cannot be Less than Issue Date", vbInformation
			//        txtExpiryDate1.SetFocus
			//        GoTo mError
			//    End If
			//End If

			return true;


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
				frmPayDocumentDetails.DefInstance = null;
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

		//Sub FindRoutine(pObjectName As String)
		//
		//Dim mObjectName As String
		//Dim mObjectIndex As Integer
		//Dim mTempSearchValue As Variant
		//Dim mFilterCondition As String
		//
		//If InStr(1, pObjectName, "#", vbTextCompare) = 0 Then
		//    Exit Sub
		//End If
		//
		//mObjectName = Left(pObjectName, InStr(1, pObjectName, "#", vbTextCompare) - 1)
		//mObjectIndex = CInt(Mid(pObjectName, InStr(1, pObjectName, "#", vbTextCompare) + 1))
		//If mObjectName = "txtCommonTextBox" Then
		//    txtCommonTextBox(mObjectIndex).Text = ""
		//    Select Case mObjectIndex
		//        Case conTxtEmpCd
		//            mTempSearchValue = FindItem(7050000, "831")
		//        Case conTxtGovernateCd
		//            'mFilterCondition = " ( ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'"
		//            'mFilterCondition = mFilterCondition & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" & ")"
		//            mTempSearchValue = FindItem(7150000, "1483")
		//        Case conTxtDocumentCd
		//            'mFilterCondition = " status = 2 "
		//            mTempSearchValue = FindItem(7120000, "1470")
		//        Case conTxtPlaceOfDocument
		//            mTempSearchValue = FindItem(7130000, "1477")
		//        Case Else
		//            Exit Sub
		//    End Select
		//
		//    If Not IsNull(mTempSearchValue) Then
		//        txtCommonTextBox(mObjectIndex).Text = mTempSearchValue(1)
		//        Call txtCommonTextBox_LostFocus(mObjectIndex)
		//    End If
		//End If
		//
		//End Sub

		public void GetNextNumber()
		{
			//txtGradeNo.Text = GetNewNumber("Pay_Grade", "Grade_No")
			//FirstFocusObject.SetFocus
		}





		//Private Sub txtCommonTextBox_DropButtonClick(Index As Integer)
		//    Call FindRoutine("txtCommonTextBox#" & Trim(Index))
		//End Sub

		//Private Sub txtCommonTextBox_LostFocus(Index As Integer)
		//
		//Dim mTempValue As Variant
		//Dim mySql As String
		//Dim mLinkedTextBoxIndex As Integer
		//
		//On Error GoTo eFoundError
		//Select Case Index
		//    Case conTxtEmpCd
		//        mySql = " select l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name as L_Full_Name "
		//        mySql = mySql & " , a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name "
		//        mySql = mySql & " from pay_employee "
		//        mySql = mySql & " where emp_no ='" & txtCommonTextBox(Index).Text & "'"
		//        mLinkedTextBoxIndex = conDlblEmpName
		//    Case conTxtGovernateCd
		//        mySql = " select l_governate_name, a_governate_name , governate_cd "
		//        mySql = mySql & " from pay_governate "
		//        mySql = mySql & " where governate_no =" & txtCommonTextBox(Index).Text
		//        mLinkedTextBoxIndex = conDlblGovernateName
		//    Case conTxtDocumentCd
		//        mySql = "select l_document_name, a_document_name, notification_period "
		//        mySql = mySql & " from pay_document_master "
		//        mySql = mySql & " where document_no=" & txtCommonTextBox(Index).Text
		//        mLinkedTextBoxIndex = conDlblDocumentName
		//    Case conTxtPlaceOfDocument
		//        mySql = " select l_place_name , a_place_name "
		//        mySql = mySql & " from pay_document_place_master "
		//        mySql = mySql & " where place_no=" & txtCommonTextBox(Index).Text
		//        mLinkedTextBoxIndex = conDlblPlaceOfDocument
		//    Case Else
		//        Exit Sub
		//End Select
		//
		//If Not IsItEmpty(txtCommonTextBox(Index).Text, StringType) Then
		//    mTempValue = GetMasterCode(mySql)
		//    If IsNull(mTempValue) Then
		//        txtDisplayLabel(mLinkedTextBoxIndex).Text = ""
		//        txtCommonTextBox(Index).Tag = ""
		//        Err.Raise -9990002
		//    Else
		//        txtDisplayLabel(mLinkedTextBoxIndex).Text = IIf(gPreferedLanguage = English, mTempValue(0), mTempValue(1))
		//        If mLinkedTextBoxIndex = conDlblDocumentName Then
		//            txtCommonNumber(conNTxtFees).Value = mTempValue(2)
		//        End If
		//    End If
		//Else
		//    txtDisplayLabel(mLinkedTextBoxIndex).Text = ""
		//    txtCommonTextBox(Index).Tag = ""
		//End If
		//
		//Exit Sub
		//
		//eFoundError:
		//Dim mReturnErrorType As Integer
		//mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord", msg10)
		//If mReturnErrorType = 1 Then
		//'
		//ElseIf mReturnErrorType = 2 Then
		//'
		//ElseIf mReturnErrorType = 3 Then
		//'
		//ElseIf mReturnErrorType = 4 Then
		//    'if the code is not found
		//    On Error Resume Next
		//    txtCommonTextBox(Index).SetFocus
		//Else
		//    '
		//End If
		//End Sub

		//Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Long, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long

		//Private Sub cmdopenfile_Click()

		//End Sub

		//''''''''Private Sub txtFilePath_DropButtonClick()
		//''''''''On Error Resume Next
		//''''''''
		//'''''''''CommonDialog1.InitDir = GetPhotoPath
		//''''''''CommonDialog1.Filter = "BMP - JPG (*.bmp,*.jpg)|*.bmp; *.jpg"
		//''''''''
		//''''''''' Set the default files type to Word Documents
		//'''''''''CommonDialog1.FilterIndex = 1
		//''''''''
		//''''''''
		//''''''''CommonDialog1.Filename = ""
		//''''''''CommonDialog1.ShowOpen
		//''''''''If CommonDialog1.Filename = "" Then Exit Sub
		//''''''''txtFilePath.Text = CommonDialog1.Filename
		//''''''''End Sub


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			if (grdVoucherDetails.Col == grdDocumentCode || grdVoucherDetails.Col == grdDocumentName)
			{
				if (grdVoucherDetails.Col == grdDocumentCode)
				{
					grdVoucherDetails.Columns[grdDocumentName].Value = cmbMastersList.Columns[1].Value;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					grdVoucherDetails.Columns[grdPeriod].Value = (Convert.IsDBNull(cmbMastersList.Columns[2].Value)) ? ((object) 0) : cmbMastersList.Columns[2].Value;
				}
				else
				{
					grdVoucherDetails.Columns[grdDocumentCode].Value = cmbMastersList.Columns[0].Value;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					grdVoucherDetails.Columns[grdPeriod].Value = (Convert.IsDBNull(cmbMastersList.Columns[2].Value)) ? ((object) 0) : cmbMastersList.Columns[2].Value;
				}
			}
		}


		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			//If ColIndex = grdCurrentAmtColumn Then
			//    grdVoucherDetails.Update
			//    Call CalculateTotals(CInt(grdVoucherDetails.Bookmark), ColIndex)
			//    grdVoucherDetails.Refresh
			//End If
		}

		private void grdVoucherDetails_ButtonClick(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			if (ColIndex == grdFileOpen)
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (!SystemProcedure2.IsItEmpty(grdVoucherDetails.Splits[0].DisplayColumns[grdFilePath], SystemVariables.DataType.StringType))
				{
					InnovaUpdSupport.PInvoke.SafeNative.shell32.ShellExecute(0, null, grdVoucherDetails.Columns[grdFilePath].Text, null, null, (int) ProcessWindowStyle.Normal);
				}
			}
		}

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";

			if (mDocumentFirstGridFocus)
			{
				if (Convert.ToString(cmbMastersList.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList);
					cmbMastersList.Tag = "OK";
				}

				DefineMasterRecordset();
				mDocumentFirstGridFocus = false;
				grdVoucherDetails_Post(grdVoucherDetails, new AxTrueOleDBGrid80.TrueDBGridEvents_PostEventEvent(1));
			}
			if (mDocumentPlaceFirstGridFocus)
			{
				if (Convert.ToString(cmbMastersList1.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList1);
					cmbMastersList1.Tag = "OK";
				}

				DefineMasterRecordsetDocumentPlace();
				mDocumentPlaceFirstGridFocus = false;
				grdVoucherDetails_Post(grdVoucherDetails, new AxTrueOleDBGrid80.TrueDBGridEvents_PostEventEvent(3));
			}
			if (mGovernatFirstGridFocus)
			{
				if (Convert.ToString(cmbMastersList2.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList2);
					cmbMastersList2.Tag = "OK";
				}

				DefineMasterRecordsetGovernat();
				mGovernatFirstGridFocus = false;
				grdVoucherDetails_Post(grdVoucherDetails, new AxTrueOleDBGrid80.TrueDBGridEvents_PostEventEvent(4));
			}
		}


		private void CalculateTotals(int mRowNumber, int mColNumber)
		{
		}

		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, grdLineNoColumn);
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
				mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[grdLineNoColumn].Value);
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), 1);
				AssignGridLineNumbers();
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
				AssignGridLineNumbers();
				// Call CalculateTotals(0, 1)
				grdVoucherDetails.Rebind(true);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdVoucherDetails.Col)
			{
				case grdDocumentCode : case grdDocumentName : 
					if (grdVoucherDetails.Col == grdDocumentCode)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("Document_No");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("Document_No");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("L_Document_Name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("L_Document_Name");
					} 
					 
					int tempForEndVar = cmbMastersList.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersList.Splits[0].DisplayColumns[cnt];
						if (cnt < 3)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == grdDocumentCode) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdDocumentCode].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == grdDocumentCode) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdDocumentName].Width;
							}
							else if (cnt == 2)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdDocumentNo].Width;
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
			switch(grdVoucherDetails.Col)
			{
				case grdDocumentCode : 
					grdVoucherDetails.Col = grdDocumentName; 
					break;
			}
		}

		private void DefineMasterRecordset()
		{
			string mysql = "";

			if (mDocumentFirstGridFocus)
			{
				mysql = " select document_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Document_Name as L_Document_Name" : "a_Document_Name as L_Document_Name");
				mysql = mysql + " , notification_period ";
				mysql = mysql + " from pay_document_master";
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
		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList1.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList1_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList1.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdVoucherDetails.Col)
			{
				case grdPlaceOfDocument : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList1.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList1.setListField("place_no"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList1.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsBillingCodeList1.setSort("place_no"); 
					int tempForEndVar = cmbMastersList1.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersList1.Splits[0].DisplayColumns[cnt];
						if (cnt < 3)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == grdPlaceOfDocument) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdPlaceOfDocument].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdGovernatCode].Width;
							}
							withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							withVar.Visible = true;
							cmbMastersList1.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					cmbMastersList1.Width += 17; 
					cmbMastersList1.Height = 167; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList1.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList1_DropDownClose()
		{
			switch(grdVoucherDetails.Col)
			{
				case grdPlaceOfDocument : 
					grdVoucherDetails.Col = grdGovernatCode; 
					break;
			}
		}
		private void DefineMasterRecordsetDocumentPlace()
		{
			string mysql = "";

			if (mDocumentPlaceFirstGridFocus)
			{
				mysql = " select place_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_place_name as L_Document_Place" : "a_place_name as L_Document_Place");
				mysql = mysql + " from pay_document_place_master";
				mysql = mysql + " order by 1 ";

				rsBillingCodeList1 = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList1.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList1.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsBillingCodeList1.Tables.Clear();
				adap.Fill(rsBillingCodeList1);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsBillingCodeList1.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList1.Requery(-1);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList2.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList2_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList2.Width = 0;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdVoucherDetails.Col)
			{
				case grdGovernatCode : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList2.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList2.setListField("governate_no"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList2.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsBillingCodeList2.setSort("governate_no"); 
					int tempForEndVar = cmbMastersList2.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersList2.Splits[0].DisplayColumns[cnt];
						if (cnt < 3)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == grdGovernatCode) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdGovernatCode].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdFilePath].Width;
							}
							withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							withVar.Visible = true;
							cmbMastersList2.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					cmbMastersList2.Width += 17; 
					cmbMastersList2.Height = 167; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList2.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList2_DropDownClose()
		{
			switch(grdVoucherDetails.Col)
			{
				case grdPlaceOfDocument : 
					grdVoucherDetails.Col = grdGovernatCode; 
					break;
			}
		}

		private void DefineMasterRecordsetGovernat()
		{
			string mysql = "";

			if (mGovernatFirstGridFocus)
			{
				mysql = " select governate_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_governate_name as l_governate_name" : "a_governate_name as l_governate_name");
				mysql = mysql + " from pay_governate";
				mysql = mysql + " order by 1 ";

				rsBillingCodeList2 = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList2.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList2.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsBillingCodeList2.Tables.Clear();
				adap.Fill(rsBillingCodeList2);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsBillingCodeList2.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList2.Requery(-1);
			}
		}
		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			grdVoucherDetails.Columns[grdLineNoColumn].Text = (grdVoucherDetails.RowCount + 1).ToString();
		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdVoucherDetails.Col > 0 && LastCol > 0 && !mDocumentFirstGridFocus)
			{
				switch(grdVoucherDetails.Col)
				{
					case grdDocumentCode : case grdDocumentName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList); 
						break;
				}
			}
			if (grdVoucherDetails.Col > 0 && LastCol > 0 && !mDocumentPlaceFirstGridFocus)
			{
				switch(grdVoucherDetails.Col)
				{
					case grdPlaceOfDocument : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList1.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList1.setDataSource((msdatasrc.DataSource) rsBillingCodeList1); 
						break;
				}
			}
			if (grdVoucherDetails.Col > 0 && LastCol > 0 && !mGovernatFirstGridFocus)
			{
				switch(grdVoucherDetails.Col)
				{
					case grdGovernatCode : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList2.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList2.setDataSource((msdatasrc.DataSource) rsBillingCodeList2); 
						break;
				}
			}
		}

		private void grdVoucherDetails_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (grdVoucherDetails.PointAt(X, Y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
			{
				mLastCol = grdVoucherDetails.Col;
				mLastRow = grdVoucherDetails.Row;
				// grdVoucherDetails.PostMsg 2
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{

			int Col = 0;
			if (MsgId == 2)
			{
				if (mLastCol == grdVoucherDetails.Col && mLastRow == grdVoucherDetails.Row)
				{
					return;
				}
				Col = grdVoucherDetails.Col;
			}

			if (MsgId == 1)
			{
				grdVoucherDetails.Col = grdDocumentCode;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList);
			}
			if (MsgId == 3)
			{
				grdVoucherDetails.Col = grdPlaceOfDocument;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList1.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList1.setDataSource((msdatasrc.DataSource) rsBillingCodeList1);
			}
			if (MsgId == 4)
			{
				grdVoucherDetails.Col = grdGovernatCode;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList2.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList2.setDataSource((msdatasrc.DataSource) rsBillingCodeList2);
			}
		}
	}
}