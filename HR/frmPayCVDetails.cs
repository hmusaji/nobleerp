
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayCVDetails
		: System.Windows.Forms.Form
	{

		public frmPayCVDetails()
{
InitializeComponent();
} 
 public  void frmPayCVDetails_old()
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


		private void frmPayCVDetails_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private XArrayHelper aLanguageDetails = null;
		private XArrayHelper aQualificationDetails = null;
		private XArrayHelper aSkillDetails = null;
		private XArrayHelper aWorkDetails = null;
		public Control FirstFocusObject = null;
		private clsToolbar oThisFormToolBar = null;
		
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

		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private int mThisFormID = 0;
		private int mFormCallType = 0;
		private object mSearchValue = null;
		private string mTimeStamp = "";
		private bool mLangFirstGridFocus = false;
		private bool mQualiFirstGridFocus = false;
		private DataSet rsLanguage = null;
		private DataSet rsQualification = null;

		private const int conTabLanguageDetails = 0;
		private const int conTabQualificationDetails = 1;
		private const int conTabSkillsetDetails = 2;
		private const int conTabWorkexpDetails = 3;

		private const int conMaxLangColumns = 2;
		private const int conMaxQualiColumns = 4;
		private const int conMaxSkillColumns = 3;
		private const int conMaxWorkDColumns = 5;

		private const int conCmbSex = 1;
		private const int conCmbMaritalStatus = 0;

		private const int conTxtLFirstName = 1;
		private const int conTxtLSecondName = 2;
		private const int conTxtLThirdName = 3;
		private const int conTxtLFourthName = 4;
		private const int conTxtNatCode = 5;
		private const int conTxtPositionName = 6;
		private const int conTxtCareerName = 7;
		private const int conTxtTelNo = 8;
		private const int conTxtPassportNo = 9;
		private const int conTxtTelNo2 = 11;
		private const int conTxtMobileno = 10;

		private const int conDlblNatName = 0;

		private const int mconLineNoColumn = 0;
		//For Language Details
		private const int mconLLanguageName = 1;
		private const int mconLComments = 2;
		//For Qualification Details
		private const int mconQQualificationName = 1;
		private const int mconQUnivercity = 2;
		private const int mconQMarksObtain = 3;
		private const int mconQPassedYear = 4;
		//For Skill Details
		private const int mconSSkillName = 1;
		private const int mconSProficiency = 2;
		private const int mconSComment = 3;
		//For Work Details
		private const int mconWDComapanyName = 1;
		private const int mconWDJoinDate = 2;
		private const int mconWDLeaveDate = 3;
		private const int mconWDPosition = 4;
		private const int mconWDResposibilities = 5;


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


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdLanguageDetails.Col)
			{
				case mconLLanguageName : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList.setListField("Language_name"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLanguage.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsLanguage.setSort("Language_name"); 
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
								withVar.setOrder((grdLanguageDetails.Col == mconLLanguageName) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdLanguageDetails.Splits[0].DisplayColumns[mconLLanguageName].Width;
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
					cmbMastersList.Height = 133; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			switch(grdLanguageDetails.Col)
			{
				case mconLLanguageName : 
					grdLanguageDetails.Col = mconLLanguageName; 
					break;
			}
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList1.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList1_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList1.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdQualificationDetails.Col)
			{
				case mconQQualificationName : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList1.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbMastersList1.setListField("Qualification_Name"); 
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsQualification.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					rsQualification.setSort("Qualification_name"); 
					int tempForEndVar = cmbMastersList1.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersList1.Splits[0].DisplayColumns[cnt];
						if (cnt < 4)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdQualificationDetails.Col == mconQQualificationName) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdQualificationDetails.Splits[0].DisplayColumns[mconQQualificationName].Width;
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
					cmbMastersList1.Height = 133; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList1.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList1_DropDownClose()
		{
			switch(grdQualificationDetails.Col)
			{
				case mconQQualificationName : 
					grdQualificationDetails.Col = mconQQualificationName; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList1.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList1_RowChange()
		{
			if (grdQualificationDetails.Col == mconQQualificationName)
			{
				grdQualificationDetails.Columns[mconQQualificationName].Value = cmbMastersList1.Columns[0].Value;
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
				oThisFormToolBar.ShowDeleteLineButton = false;
				oThisFormToolBar.ShowMoveRecordNextButton = true;
				oThisFormToolBar.ShowMoveRecordPreviousButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = false;

				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);
				FirstFocusObject = txtCommonTextBox[conTxtLFirstName];

				mLangFirstGridFocus = true;
				mQualiFirstGridFocus = true;
				//assign a next code
				//'Assign Grids
				SystemGrid.DefineSystemVoucherGrid(grdLanguageDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");
				SystemGrid.DefineSystemVoucherGrid(grdQualificationDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");
				SystemGrid.DefineSystemVoucherGrid(grdSkillDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");
				SystemGrid.DefineSystemVoucherGrid(grdWorkExperenceDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&HBBC8CA", "&HBBC8CA");

				//'Assign Grid Column for language
				SystemGrid.DefineSystemVoucherGridColumn(grdLanguageDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdLanguageDetails, "Language Name", 2700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdLanguageDetails, "Comment", 6000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);

				//'Assign Grid Column for Qualification
				SystemGrid.DefineSystemVoucherGridColumn(grdQualificationDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdQualificationDetails, "Qualification Name", 3100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList1");
				SystemGrid.DefineSystemVoucherGridColumn(grdQualificationDetails, "University", 4200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdQualificationDetails, "Marks Obtained", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdQualificationDetails, "Passed Year", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);

				//'Assign Grid Column for Skilled
				SystemGrid.DefineSystemVoucherGridColumn(grdSkillDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdSkillDetails, "Skill Name", 2700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdSkillDetails, "Proficiency", 3000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdSkillDetails, "Comments", 3000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);

				//'Assign Grid Column for Qualification
				SystemGrid.DefineSystemVoucherGridColumn(grdWorkExperenceDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdWorkExperenceDetails, "Company Name", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdWorkExperenceDetails, "Joining Date", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdWorkExperenceDetails, "Leaving Date", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdWorkExperenceDetails, "Position", 2200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdWorkExperenceDetails, "Resposibilities", 3000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);

				aLanguageDetails = new XArrayHelper();
				aQualificationDetails = new XArrayHelper();
				aSkillDetails = new XArrayHelper();
				aWorkDetails = new XArrayHelper();

				DefineVoucherArray(-1, aLanguageDetails, conMaxLangColumns, true);
				DefineVoucherArray(-1, aQualificationDetails, conMaxQualiColumns, true);
				DefineVoucherArray(-1, aSkillDetails, conMaxSkillColumns, true);
				DefineVoucherArray(-1, aWorkDetails, conMaxWorkDColumns, true);

				AssignGridLineNumbers(aLanguageDetails);
				AssignGridLineNumbers(aQualificationDetails);
				AssignGridLineNumbers(aSkillDetails);
				AssignGridLineNumbers(aWorkDetails);

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdLanguageDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdLanguageDetails.setArray(aLanguageDetails);
				grdLanguageDetails.Rebind(true);
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdQualificationDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdQualificationDetails.setArray(aQualificationDetails);
				grdQualificationDetails.Rebind(true);
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdSkillDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdSkillDetails.setArray(aSkillDetails);
				grdSkillDetails.Rebind(true);
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdWorkExperenceDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdWorkExperenceDetails.setArray(aWorkDetails);
				grdWorkExperenceDetails.Rebind(true);

				object[] mObjectId = new object[2];
				mObjectId[conCmbSex] = 1002; //For Gender
				mObjectId[conCmbMaritalStatus] = 1003; //For Marital Status
				SystemCombo.FillComboWithSystemObjects(cmbCommon, mObjectId);
				this.tabCV.CurrTab = Convert.ToInt16(conTabLanguageDetails);
				//txtCommonTextBox(conTxtLFirstName).SetFocus
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void DefineVoucherArray(int pMaximumRows, XArrayHelper pArray, int pMaxColumns, bool pClearArray = false)
		{
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method pArray.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				pArray.Clear();
			}
			pArray.RedimXArray(new int[]{pMaximumRows, pMaxColumns}, new int[]{0, 0});
		}

		private void AssignGridLineNumbers(XArrayHelper pArray)
		{
			int cnt = 0;
			int tempForEndVar = pArray.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				pArray.SetValue(cnt + 1, cnt, 0);
			}
		}

		public void FindRoutine(string pObjectName)
		{
			//Dim mySql As String
			object mTempSearchValue = null;

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

			switch(mIndex)
			{
				case conTxtNatCode : 
					txtCommonTextBox[conTxtNatCode].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7004000, "743")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtNatCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
					} 
					 
					break;
				case conTxtPositionName : 
					txtCommonTextBox[conTxtPositionName].Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7002000, "735")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtPositionName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					} 
					 
					break;
				default:
					return;
			}
		}



		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			rsLanguage = null;
			rsQualification = null;
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			if (grdLanguageDetails.Col == mconLLanguageName)
			{
				grdLanguageDetails.Columns[mconLLanguageName].Value = cmbMastersList.Columns[0].Value;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdLanguageDetails.AfterInsert was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdLanguageDetails_AfterInsert()
		{
			AssignGridLineNumbers(aLanguageDetails);
		}


		private void grdLanguageDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";

			if (mLangFirstGridFocus)
			{
				if (Convert.ToString(cmbMastersList.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList);
					cmbMastersList.Tag = "OK";
				}

				DefineLanguageRecordset();
				mLangFirstGridFocus = false;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdLanguageDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdLanguageDetails.PostMsg(1);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdLanguageDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdLanguageDetails_PostEvent(int MsgId)
		{
			int Col = 0;

			if (MsgId == 1)
			{
				grdLanguageDetails.Col = mconLLanguageName;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsLanguage);
			}
		}

		private void DefineLanguageRecordset()
		{
			string mysql = "";

			if (mLangFirstGridFocus)
			{
				mysql = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_language_name" : "a_language_name") + " as Language_Name";
				mysql = mysql + " from pay_language";
				mysql = mysql + " order by 1 ";

				rsLanguage = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLanguage.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLanguage.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLanguage.Tables.Clear();
				adap.Fill(rsLanguage);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsLanguage.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLanguage.Requery(-1);
			}

		}

		private void grdLanguageDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdLanguageDetails.Col > 0 && LastCol > 0 && !mLangFirstGridFocus)
			{
				switch(grdLanguageDetails.Col)
				{
					case mconLLanguageName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsLanguage); 
						break;
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdQualificationDetails.AfterInsert was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdQualificationDetails_AfterInsert()
		{
			AssignGridLineNumbers(aQualificationDetails);
		}


		private void grdQualificationDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";

			if (mQualiFirstGridFocus)
			{
				if (Convert.ToString(cmbMastersList1.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList1);
					cmbMastersList1.Tag = "OK";
				}

				DefineQualificationRecordset();
				mQualiFirstGridFocus = false;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdQualificationDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdQualificationDetails.PostMsg(1);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdQualificationDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdQualificationDetails_PostEvent(int MsgId)
		{
			int Col = 0;

			if (MsgId == 1)
			{
				grdQualificationDetails.Col = mconQQualificationName;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList1.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList1.setDataSource((msdatasrc.DataSource) rsQualification);
			}
		}

		private void DefineQualificationRecordset()
		{
			string mysql = "";

			if (mQualiFirstGridFocus)
			{
				mysql = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_qalfn_name" : "a_qalfn_name") + " as Qualification_Name";
				mysql = mysql + " from pay_qualification";
				mysql = mysql + " order by 1 ";

				rsQualification = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsQualification.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsQualification.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsQualification.Tables.Clear();
				adap.Fill(rsQualification);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsQualification.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsQualification.Requery(-1);
			}

		}

		private void grdQualificationDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdQualificationDetails.Col > 0 && LastCol > 0 && !mQualiFirstGridFocus)
			{
				switch(grdQualificationDetails.Col)
				{
					case mconQQualificationName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList1.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList1.setDataSource((msdatasrc.DataSource) rsQualification); 
						break;
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdSkillDetails.AfterInsert was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdSkillDetails_AfterInsert()
		{
			AssignGridLineNumbers(aSkillDetails);
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdWorkExperenceDetails.AfterInsert was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdWorkExperenceDetails_AfterInsert()
		{
			AssignGridLineNumbers(aWorkDetails);
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			//On Error GoTo eFoundError
			object mTempValue = null;
			string mysql = "";
			int cnt = 0;

			if (Index == conTxtNatCode)
			{
				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtNatCode].Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select nat_no ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_nat_name" : "a_nat_name");
					mysql = mysql + " from pay_nationality ";
					mysql = mysql + " where ";
					mysql = mysql + " nat_no = " + txtCommonTextBox[conTxtNatCode].Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDisplayLabel[conDlblNatName].Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDisplayLabel[conDlblNatName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
					}
				}
				else
				{
					txtDisplayLabel[conDlblNatName].Text = "";
				}
			}

		}

		public void CloseForm()
		{
			this.Close();
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				object mReturnValue = null;
				if (KeyCode == 13)
				{
					if (this.ActiveControl.Name != "txtComments")
					{
						SendKeys.Send("{TAB}");
						return;
					}
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
			try
			{

				SystemProcedure2.ClearTextBox(this);
				DefineVoucherArray(-1, aLanguageDetails, conMaxLangColumns, true);
				DefineVoucherArray(-1, aQualificationDetails, conMaxQualiColumns, true);
				DefineVoucherArray(-1, aSkillDetails, conMaxSkillColumns, true);
				DefineVoucherArray(-1, aWorkDetails, conMaxWorkDColumns, true);

				AssignGridLineNumbers(aLanguageDetails);
				AssignGridLineNumbers(aQualificationDetails);
				AssignGridLineNumbers(aSkillDetails);
				AssignGridLineNumbers(aWorkDetails);

				grdLanguageDetails.Rebind(true);
				grdQualificationDetails.Rebind(true);
				grdSkillDetails.Rebind(true);
				grdWorkExperenceDetails.Rebind(true);

				txtBirthDate.Value = DateTime.Today.AddYears(-10);

				mLangFirstGridFocus = true;
				mQualiFirstGridFocus = true;
				//FirstFocusObject.SetFocus
				CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220350));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}


		public void GetRecord(object SearchValue)
		{
			int mCntRow = 0;

			string mysql = " select pcvd.*, pn.nat_no, " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_nat_name" : "a_nat_name") + " as nat_name";
			mysql = mysql + " from pay_cv_details pcvd ";
			mysql = mysql + " left Outer join pay_nationality pn on pcvd.nat_cd =pn.nat_cd";
			mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

			SqlDataReader rsCVMain = null;
			SqlDataReader rsCVDetails = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsCVMain = sqlCommand.ExecuteReader();
			if (rsCVMain.Read())
			{
				mTimeStamp = Convert.ToString(rsCVMain["time_stamp"]);
				txtCommonTextBox[conTxtLFirstName].Text = Convert.ToString(rsCVMain["L_First_Name"]);
				txtCommonTextBox[conTxtLSecondName].Text = Convert.ToString(rsCVMain["L_Second_Name"]) + "";
				txtCommonTextBox[conTxtLThirdName].Text = Convert.ToString(rsCVMain["L_Third_Name"]) + "";
				txtCommonTextBox[conTxtLFourthName].Text = Convert.ToString(rsCVMain["L_Fourth_Name"]) + "";
				txtCommonTextBox[conTxtPositionName].Text = Convert.ToString(rsCVMain["Position_Desired"]) + "";
				txtCommonTextBox[conTxtCareerName].Text = Convert.ToString(rsCVMain["Career_Objective"]) + "";
				txtBirthDate.Value = rsCVMain["Date_Of_Birth"];
				txtCommonTextBox[conTxtTelNo].Text = Convert.ToString(rsCVMain["Telephone1"]) + "";
				txtCommonTextBox[conTxtTelNo2].Text = Convert.ToString(rsCVMain["Telephone2"]) + "";
				txtCommonTextBox[conTxtMobileno].Text = Convert.ToString(rsCVMain["Mobile_no"]) + "";
				txtCommonTextBox[conTxtPassportNo].Text = Convert.ToString(rsCVMain["Passport_No"]) + "";
				txtCommonTextBox[conTxtNatCode].Text = Convert.ToString(rsCVMain["nat_no"]) + "";
				txtDisplayLabel[conDlblNatName].Text = Convert.ToString(rsCVMain["nat_name"]) + "";
				txtEmail.Text = Convert.ToString(rsCVMain["Email_Id"]) + "";
				SystemCombo.SearchCombo(cmbCommon[conCmbSex], Convert.ToInt32(rsCVMain["Gender"]));
				SystemCombo.SearchCombo(cmbCommon[conCmbMaritalStatus], Convert.ToInt32(rsCVMain["Marital_Status"]));
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkDrivingLicence.CheckState = (CheckState) ((Convert.ToBoolean(rsCVMain["Driving_Licence"])) ? 1 : 0);
				txtComments.Text = Convert.ToString(rsCVMain["Comments"]) + "";
				//For Language Details
				mysql = " select * from pay_cv_language_details where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand sqlCommand_2 = new SqlCommand(mysql, SystemVariables.gConn);
				rsCVDetails = sqlCommand_2.ExecuteReader();
				rsCVDetails.Read();
				mCntRow = 0;
				do 
				{
					DefineVoucherArray(mCntRow, aLanguageDetails, conMaxLangColumns);
					aLanguageDetails.SetValue(Conversion.Str(mCntRow + 1).Trim(), mCntRow, mconLineNoColumn);
					aLanguageDetails.SetValue(rsCVDetails["L_Language_Name"], mCntRow, mconLLanguageName);
					aLanguageDetails.SetValue(rsCVDetails["Comments"], mCntRow, mconLComments);
					mCntRow++;
				}
				while(rsCVDetails.Read());
				rsCVDetails.Close();
				AssignGridLineNumbers(aLanguageDetails);
				grdLanguageDetails.Rebind(true);
				grdLanguageDetails.Refresh();
				//For Qualification Details
				mysql = " select * from pay_cv_qualification_details where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand sqlCommand_3 = new SqlCommand(mysql, SystemVariables.gConn);
				rsCVDetails = sqlCommand_3.ExecuteReader();
				bool rsCVDetailsDidRead2 = rsCVDetails.Read();
				mCntRow = 0;
				do 
				{
					DefineVoucherArray(mCntRow, aQualificationDetails, conMaxQualiColumns);
					aQualificationDetails.SetValue(Conversion.Str(mCntRow + 1).Trim(), mCntRow, mconLineNoColumn);
					aQualificationDetails.SetValue(rsCVDetails["L_Qalfn_name"], mCntRow, mconQQualificationName);
					aQualificationDetails.SetValue(rsCVDetails["University"], mCntRow, mconQUnivercity);
					aQualificationDetails.SetValue(rsCVDetails["Marks_Obtained"], mCntRow, mconQMarksObtain);
					aQualificationDetails.SetValue(rsCVDetails["Year_Passed"], mCntRow, mconQPassedYear);
					mCntRow++;
				}
				while(rsCVDetails.Read());
				rsCVDetails.Close();
				AssignGridLineNumbers(aQualificationDetails);
				grdQualificationDetails.Rebind(true);
				grdQualificationDetails.Refresh();
				//For Skill Details
				mysql = " select * from pay_cv_skillset_details where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand sqlCommand_4 = new SqlCommand(mysql, SystemVariables.gConn);
				rsCVDetails = sqlCommand_4.ExecuteReader();
				bool rsCVDetailsDidRead3 = rsCVDetails.Read();
				mCntRow = 0;
				do 
				{
					DefineVoucherArray(mCntRow, aSkillDetails, conMaxSkillColumns);
					aSkillDetails.SetValue(Conversion.Str(mCntRow + 1).Trim(), mCntRow, mconLineNoColumn);
					aSkillDetails.SetValue(rsCVDetails["L_Skill_Name"], mCntRow, mconSSkillName);
					aSkillDetails.SetValue(rsCVDetails["Proficiency_Level"], mCntRow, mconSProficiency);
					aSkillDetails.SetValue(rsCVDetails["Comments"], mCntRow, mconSComment);
					mCntRow++;
				}
				while(rsCVDetails.Read());
				rsCVDetails.Close();
				AssignGridLineNumbers(aSkillDetails);
				grdSkillDetails.Rebind(true);
				grdSkillDetails.Refresh();
				//For Work Details
				mysql = " select * from pay_cv_work_experience_details where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand sqlCommand_5 = new SqlCommand(mysql, SystemVariables.gConn);
				rsCVDetails = sqlCommand_5.ExecuteReader();
				bool rsCVDetailsDidRead4 = rsCVDetails.Read();
				mCntRow = 0;
				do 
				{
					DefineVoucherArray(mCntRow, aWorkDetails, conMaxWorkDColumns);
					aWorkDetails.SetValue(Conversion.Str(mCntRow + 1).Trim(), mCntRow, mconLineNoColumn);
					aWorkDetails.SetValue(rsCVDetails["Company_Name"], mCntRow, mconWDComapanyName);
					aWorkDetails.SetValue(rsCVDetails["Joining_Date"], mCntRow, mconWDJoinDate);
					aWorkDetails.SetValue(rsCVDetails["Leaving_Date"], mCntRow, mconWDLeaveDate);
					aWorkDetails.SetValue(rsCVDetails["Position_Entitled"], mCntRow, mconWDPosition);
					aWorkDetails.SetValue(rsCVDetails["Responsibilities"], mCntRow, mconWDResposibilities);
					mCntRow++;
				}
				while(rsCVDetails.Read());
				rsCVDetails.Close();
				AssignGridLineNumbers(aWorkDetails);
				grdWorkExperenceDetails.Rebind(true);
				grdWorkExperenceDetails.Refresh();
			}
			mLangFirstGridFocus = true;
			mQualiFirstGridFocus = true;

			grdLanguageDetails_GotFocus(grdLanguageDetails, new EventArgs());
			grdQualificationDetails_GotFocus(grdQualificationDetails, new EventArgs());

			//FirstFocusObject.SetFocus
			CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
		}

		public bool saveRecord()
		{
			string mysql = "";
			int mNatCd = 0;
			object mReturnValue = null;
			int mCntRow = 0;

			if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtNatCode].Text, SystemVariables.DataType.StringType))
			{
				mysql = "select nat_cd from pay_nationality where nat_no =" + txtCommonTextBox[conTxtNatCode].Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mNatCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
			}
			else
			{
				mNatCd = 0;
			}

			grdLanguageDetails.UpdateData();
			grdQualificationDetails.UpdateData();
			grdSkillDetails.UpdateData();
			grdWorkExperenceDetails.UpdateData();

			SystemVariables.gConn.BeginTransaction();
			string mCheckTimeStamp = "";
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				mysql = " insert into pay_cv_details([l_first_name],[l_second_name],[l_third_name],[l_fourth_name]";
				mysql = mysql + " ,[position_desired],[career_objective],[gender],[nat_cd],[date_of_birth],[marital_status]";
				mysql = mysql + " ,[email_id],[telephone1],[telephone2],[mobile_no],[passport_no],[driving_licence],[comments])";
				mysql = mysql + " values('" + txtCommonTextBox[conTxtLFirstName].Text + "'";
				mysql = mysql + ",'" + txtCommonTextBox[conTxtLSecondName].Text + "'";
				mysql = mysql + ",'" + txtCommonTextBox[conTxtLThirdName].Text + "'";
				mysql = mysql + ",'" + txtCommonTextBox[conTxtLFourthName].Text + "'";
				mysql = mysql + ",'" + txtCommonTextBox[conTxtPositionName].Text + "'";
				mysql = mysql + ",'" + txtCommonTextBox[conTxtCareerName].Text + "'";
				mysql = mysql + "," + cmbCommon[conCmbSex].GetItemData(cmbCommon[conCmbSex].ListIndex).ToString();
				if (mNatCd == 0)
				{
					mysql = mysql + ",null";
				}
				else
				{
					mysql = mysql + "," + mNatCd.ToString();
				}
				mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtBirthDate.Value) + "'";
				mysql = mysql + "," + cmbCommon[conCmbMaritalStatus].GetItemData(cmbCommon[conCmbMaritalStatus].ListIndex).ToString();
				mysql = mysql + ",'" + txtEmail.Text + "'";
				mysql = mysql + ",'" + txtCommonTextBox[conTxtTelNo].Text + "'";
				mysql = mysql + ",'" + txtCommonTextBox[conTxtTelNo2].Text + "'";
				mysql = mysql + ",'" + txtCommonTextBox[conTxtMobileno].Text + "'";
				mysql = mysql + ",'" + txtCommonTextBox[conTxtPassportNo].Text + "'";
				mysql = mysql + "," + ((int) chkDrivingLicence.CheckState).ToString();
				mysql = mysql + ",'" + txtComments.Text + "'";
				mysql = mysql + ")";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mSearchValue = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
			}
			else
			{
				mysql = " select time_stamp from pay_cv_details where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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
					return false;
				}

				if (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp))
				{
					MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}

				mysql = "update pay_cv_details";
				mysql = mysql + " set [l_first_name]= '" + txtCommonTextBox[conTxtLFirstName].Text + "'";
				mysql = mysql + " ,[l_second_name]='" + txtCommonTextBox[conTxtLSecondName].Text + "'";
				mysql = mysql + " ,[l_third_name]='" + txtCommonTextBox[conTxtLThirdName].Text + "'";
				mysql = mysql + " ,[l_fourth_name]='" + txtCommonTextBox[conTxtLFourthName].Text + "'";
				mysql = mysql + " ,[position_desired]='" + txtCommonTextBox[conTxtPositionName].Text + "'";
				mysql = mysql + " ,[career_objective]='" + txtCommonTextBox[conTxtCareerName].Text + "'";
				mysql = mysql + " ,[gender]=" + cmbCommon[conCmbSex].GetItemData(cmbCommon[conCmbSex].ListIndex).ToString();
				if (mNatCd == 0)
				{
					mysql = mysql + " ,[nat_cd]=null";
				}
				else
				{
					mysql = mysql + " ,[nat_cd] =" + mNatCd.ToString();
				}
				mysql = mysql + " ,[date_of_birth]='" + ReflectionHelper.GetPrimitiveValue<string>(txtBirthDate.Value) + "'";
				mysql = mysql + " ,[marital_status]=" + cmbCommon[conCmbMaritalStatus].GetItemData(cmbCommon[conCmbMaritalStatus].ListIndex).ToString();
				mysql = mysql + " ,[email_id]='" + txtEmail.Text + "'";
				mysql = mysql + " ,[telephone1]='" + txtCommonTextBox[conTxtTelNo].Text + "'";
				mysql = mysql + " ,[telephone2]='" + txtCommonTextBox[conTxtTelNo2].Text + "'";
				mysql = mysql + " ,[mobile_no]='" + txtCommonTextBox[conTxtMobileno].Text + "'";
				mysql = mysql + " ,[passport_no]='" + txtCommonTextBox[conTxtPassportNo].Text + "'";
				mysql = mysql + " ,[driving_licence]=" + ((int) chkDrivingLicence.CheckState).ToString();
				mysql = mysql + " , [Comments]='" + txtComments.Text + "'";
				mysql = mysql + " where entry_id= " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();
				//'Delete Details tables
				mysql = " delete from pay_cv_language_details where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();
				mysql = " delete from pay_cv_qualification_details where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();
				mysql = " delete from pay_cv_skillset_details where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_5 = null;
				TempCommand_5 = SystemVariables.gConn.CreateCommand();
				TempCommand_5.CommandText = mysql;
				TempCommand_5.ExecuteNonQuery();
				mysql = " delete from pay_cv_work_experience_details where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_6 = null;
				TempCommand_6 = SystemVariables.gConn.CreateCommand();
				TempCommand_6.CommandText = mysql;
				TempCommand_6.ExecuteNonQuery();
				//'End
			}
			//'Insert In Details tables
			//For Language Details
			int tempForEndVar = aLanguageDetails.GetLength(0) - 1;
			for (mCntRow = 0; mCntRow <= tempForEndVar; mCntRow++)
			{
				mysql = "insert into pay_cv_language_details(entry_id,l_language_name,comments) ";
				mysql = mysql + " values(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mysql = mysql + ",'" + Convert.ToString(aLanguageDetails.GetValue(mCntRow, mconLLanguageName)) + "'";
				mysql = mysql + ",'" + Convert.ToString(aLanguageDetails.GetValue(mCntRow, mconLComments)) + "'";
				mysql = mysql + ")";
				SqlCommand TempCommand_7 = null;
				TempCommand_7 = SystemVariables.gConn.CreateCommand();
				TempCommand_7.CommandText = mysql;
				TempCommand_7.ExecuteNonQuery();
			}

			//For Qualification Details
			int tempForEndVar2 = aQualificationDetails.GetLength(0) - 1;
			for (mCntRow = 0; mCntRow <= tempForEndVar2; mCntRow++)
			{
				mysql = "insert into pay_cv_qualification_details(entry_id,l_qalfn_name,university,marks_obtained,year_passed) ";
				mysql = mysql + " values(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mysql = mysql + ",'" + Convert.ToString(aQualificationDetails.GetValue(mCntRow, mconQQualificationName)) + "'";
				mysql = mysql + ",'" + Convert.ToString(aQualificationDetails.GetValue(mCntRow, mconQUnivercity)) + "'";
				mysql = mysql + ",'" + Convert.ToString(aQualificationDetails.GetValue(mCntRow, mconQMarksObtain)) + "'";
				mysql = mysql + ",'" + Convert.ToString(aQualificationDetails.GetValue(mCntRow, mconQPassedYear)) + "'";
				mysql = mysql + ")";
				SqlCommand TempCommand_8 = null;
				TempCommand_8 = SystemVariables.gConn.CreateCommand();
				TempCommand_8.CommandText = mysql;
				TempCommand_8.ExecuteNonQuery();
			}

			//For Skill Details
			int tempForEndVar3 = aSkillDetails.GetLength(0) - 1;
			for (mCntRow = 0; mCntRow <= tempForEndVar3; mCntRow++)
			{
				mysql = "insert into pay_cv_skillset_details(entry_id,l_skill_name,proficiency_level,comments) ";
				mysql = mysql + " values(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mysql = mysql + ",'" + Convert.ToString(aSkillDetails.GetValue(mCntRow, mconSSkillName)) + "'";
				mysql = mysql + ",'" + Convert.ToString(aSkillDetails.GetValue(mCntRow, mconSProficiency)) + "'";
				mysql = mysql + ",'" + Convert.ToString(aSkillDetails.GetValue(mCntRow, mconSComment)) + "'";
				mysql = mysql + ")";
				SqlCommand TempCommand_9 = null;
				TempCommand_9 = SystemVariables.gConn.CreateCommand();
				TempCommand_9.CommandText = mysql;
				TempCommand_9.ExecuteNonQuery();
			}


			//For Work Details
			int tempForEndVar4 = aWorkDetails.GetLength(0) - 1;
			for (mCntRow = 0; mCntRow <= tempForEndVar4; mCntRow++)
			{
				mysql = "insert into pay_cv_work_experience_details(entry_id,company_name,joining_date,leaving_date,position_entitled,responsibilities) ";
				mysql = mysql + " values(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mysql = mysql + ",'" + Convert.ToString(aWorkDetails.GetValue(mCntRow, mconWDComapanyName)) + "'";
				mysql = mysql + ",'" + StringsHelper.Format(aWorkDetails.GetValue(mCntRow, mconWDJoinDate), SystemVariables.gSystemDateFormat) + "'";
				mysql = mysql + ",'" + StringsHelper.Format(aWorkDetails.GetValue(mCntRow, mconWDLeaveDate), SystemVariables.gSystemDateFormat) + "'";
				mysql = mysql + ",'" + Convert.ToString(aWorkDetails.GetValue(mCntRow, mconWDPosition)) + "'";
				mysql = mysql + ",'" + Convert.ToString(aWorkDetails.GetValue(mCntRow, mconWDResposibilities)) + "'";
				mysql = mysql + ")";
				SqlCommand TempCommand_10 = null;
				TempCommand_10 = SystemVariables.gConn.CreateCommand();
				TempCommand_10.CommandText = mysql;
				TempCommand_10.ExecuteNonQuery();
			}
			//'End
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			return true;
		}

		public bool CheckDataValidity()
		{
			bool result = false;
			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtLFirstName].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("First Name cannot  be blank!!", "CV Deatails", MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = false;
				txtCommonTextBox[conTxtLFirstName].Focus();
				return result;
			}
			return true;
		}

		private void RecordNavidate(int pKeyCode, int pSearchValue)
		{

			string mysql = " select top 1 entry_id from pay_cv_details ";
			mysql = mysql + " where 1=1 ";
			if (pSearchValue > 0 && pKeyCode == 37)
			{
				mysql = mysql + " and entry_id < " + pSearchValue.ToString();
			}
			else if (pSearchValue > 0 && pKeyCode == 39)
			{ 
				mysql = mysql + " and entry_id > " + pSearchValue.ToString();
			}

			if (pKeyCode == 37)
			{
				mysql = mysql + " order by entry_id desc ";
			}
			else if (pKeyCode == 39)
			{ 
				mysql = mysql + " order by entry_id asc ";
			}

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(mReturnValue);
				GetRecord(mReturnValue);
			}

		}

		public void ORoutine()
		{

			if (!UserAccess.AllowUserDisplay)
			{
				MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			RecordNavidate(39, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));

		}

		public void MRoutine()
		{

			if (!UserAccess.AllowUserDisplay)
			{
				MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			RecordNavidate(37, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));
		}
	}
}