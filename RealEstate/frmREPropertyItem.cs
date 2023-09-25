
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmREPropertyItem
		: System.Windows.Forms.Form
	{

		public frmREPropertyItem()
{
InitializeComponent();
} 
 public  void frmREPropertyItem_old()
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


		private void frmREPropertyItem_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private clsToolbar oThisFormToolBar = null;
		public Control FirstFocusObject = null;

		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;


		private const int conTXTItemNo = 0;
		private const int conTxtLItemName = 1;
		private const int conTxtAItemName = 2;
		private const int conTxtItemTypeNo = 3;

		private const int conTxtItemTypeName = 0;


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


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				FirstFocusObject = txtCommon[conTXTItemNo];
				txtCommon[conTXTItemNo].Text = SystemProcedure2.GetNewNumber("re_property_Items", "Item_no", 2);
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

				SystemProcedure.SetLabelCaption(this);
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}

		}


		private void txtCommon_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommon, eventSender);

			object mTempValue = null;
			string mySQL = "";
			int mLinkedTextBoxIndex = 0;

			try
			{
				switch(Index)
				{
					case conTxtItemTypeNo : 
						mySQL = "select L_Item_Type_Name,A_Item_Type_Name "; 
						mySQL = mySQL + "from re_property_item_type where Item_Type_No = " + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conTxtItemTypeName; 
						break;
					default:
						return;
				}

				if (!SystemProcedure2.IsItEmpty(txtCommon[Index].Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtCommonDisplay[mLinkedTextBoxIndex].Text = "";
						txtCommon[Index].Tag = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						txtCommonDisplay[mLinkedTextBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1));
					}
				}
				else
				{
					txtCommonDisplay[mLinkedTextBoxIndex].Text = "";
					txtCommon[Index].Tag = "";
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
						txtCommon[Index].Focus();
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

				if (this.ActiveControl.Name != "txtCommon")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommon#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
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

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
			mSearchValue = "";
			FirstFocusObject.Focus();
			txtCommon[conTXTItemNo].Text = SystemProcedure2.GetNewNumber("re_property_Items", "Item_no", 2);
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord(bool pPostGl = false)
		{
			bool result = false;
			string mySQL = "";
			object mTypeReturnValue = null;
			string myErrMsg = "";
			try
			{
				SystemVariables.gConn.BeginTransaction();
				mySQL = " select Item_Type_Cd from re_property_item_type where item_type_no = " + txtCommon[conTxtItemTypeNo].Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTypeReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mTypeReturnValue))
				{
					myErrMsg = "Invalid Item Type No";
					txtCommon[conTxtItemTypeNo].Focus();
					throw new Exception();
				}
				myErrMsg = new String(' ', 24) + "Error";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mySQL = " insert into RE_Property_Items ";
					mySQL = mySQL + " (Item_Type_Cd,Item_No, L_Item_Name,A_Item_name,Comments,User_Cd) ";
					mySQL = mySQL + " values( ";
					mySQL = mySQL + ReflectionHelper.GetPrimitiveValue<string>(mTypeReturnValue) + ",";
					mySQL = mySQL + txtCommon[conTXTItemNo].Text;
					mySQL = mySQL + ",'" + txtCommon[conTxtLItemName].Text + "'";
					mySQL = mySQL + ",N'" + txtCommon[conTxtAItemName].Text + "'";
					mySQL = mySQL + ",N'" + txtRemarks.Text + "'";
					mySQL = mySQL + "," + SystemVariables.gLoggedInUserCode.ToString();
					mySQL = mySQL + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mySQL;
					TempCommand.ExecuteNonQuery();
				}
				else if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{ 
					mySQL = "update RE_Property_Items ";
					mySQL = mySQL + " set Item_Type_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(mTypeReturnValue);
					mySQL = mySQL + " , Item_no = " + txtCommon[conTXTItemNo].Text;
					mySQL = mySQL + " , L_Item_Name = " + "'" + txtCommon[conTxtLItemName].Text + "'";
					mySQL = mySQL + " , A_Item_Name = " + "N'" + txtCommon[conTxtAItemName].Text + "'";
					mySQL = mySQL + " , Comments = " + "N'" + txtRemarks.Text + "'";
					mySQL = mySQL + " where Item_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mySQL;
					TempCommand_2.ExecuteNonQuery();
				}
				result = true;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				return result;

				return false;
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
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
				string mySQL = "delete from re_property_Items where Item_Cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mySQL;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Item can't be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();


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
				string mySQL = "";
				object mReturnValue = null;
				SqlDataReader localRec = null;
				mySQL = " select * ";
				mySQL = mySQL + " from re_property_Items pi inner join re_property_item_type pit on pi.item_type_cd = pit.item_type_cd ";
				mySQL = mySQL + " where Item_cd = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mySQL, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{

					mSearchValue = localRec["Item_Cd"];
					txtCommon[conTXTItemNo].Text = Convert.ToString(localRec["Item_No"]);
					txtCommon[conTxtLItemName].Text = Convert.ToString(localRec["l_Item_name"]);
					txtCommon[conTxtAItemName].Text = Convert.ToString(localRec["A_Item_name"]);

					txtCommon[conTxtItemTypeNo].Text = Convert.ToString(localRec["Item_Type_No"]);

					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						txtCommonDisplay[conTxtItemTypeName].Text = Convert.ToString(localRec["L_Item_Type_Name"]);
					}
					else
					{
						txtCommonDisplay[conTxtItemTypeName].Text = Convert.ToString(localRec["A_Item_Type_Name"]);
					}

					txtRemarks.Text = Convert.ToString(localRec["Comments"]) + " ";
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

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9012000));
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
			if (txtCommon[conTXTItemNo].Text.Trim() == "")
			{
				MessageBox.Show("You have to enter the Item No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txtCommon[conTXTItemNo].Focus();
			}
			else
			{

				if (txtCommon[conTxtLItemName].Text.Trim() == "")
				{
					MessageBox.Show("You have to enter the Item Name", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txtCommon[conTxtLItemName].Focus();
				}
				else
				{

					if (txtCommon[conTxtItemTypeNo].Text.Trim() == "")
					{
						MessageBox.Show("You have to enter the Item Type No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						txtCommon[conTxtItemTypeNo].Focus();
					}
					else
					{
						return true;

					}
				}
			}

			return false;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

			UserAccess = null;
			oThisFormToolBar = null;
			frmREPropertyItem.DefInstance = null;
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
			if (mObjectName == "txtCommon")
			{
				txtCommon[mObjectIndex].Text = "";
				switch(mObjectIndex)
				{
					case conTxtItemTypeNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9011000, "1373,1374,1375")); 
						break;
					default:
						return;
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommon[mObjectIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtCommon_Leave(txtCommon[mObjectIndex], new EventArgs());
				}
			}

		}






		private void txtCommon_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);
			if (Index == conTXTItemNo)
			{
				txtCommon[conTXTItemNo].Text = SystemProcedure2.GetNewNumber("re_property_Items", "Item_No", 2);
			}
			else
			{
				FindRoutine("txtCommon#" + Index.ToString().Trim());
			}
		}
	}
}