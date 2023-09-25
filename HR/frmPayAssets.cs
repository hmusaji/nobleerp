
using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Xtreme
{
	internal partial class frmPayAssets
		: System.Windows.Forms.Form
	{

		public frmPayAssets()
{
InitializeComponent();
} 
 public  void frmPayAssets_old()
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


		private void frmPayAssets_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		private clsToolbar oThisFormToolBar = null;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		private const int mconNAssetValue = 0;
		private const int mconNAssetQuantity = 1;
		private const int mconNAssetIssueQuantity = 2;
		private const int mconNAssetDamageQuantity = 3;
		private const int mconNBalanceQuantity = 4;

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
			FirstFocusObject = txtAssetNo;
			//
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
				txtDWarrantyEnd.Text = "";
				//assign a next code
				txtAssetNo.Text = SystemProcedure2.GetNewNumber("Pay_Assets", "Asset_No");
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
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearNumberBox(this);
			txtAssetNo.Text = SystemProcedure2.GetNewNumber("Pay_Assets", "Asset_No");
			txtDWarrantyEnd.Text = "";
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			FirstFocusObject.Focus();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public void GetRecord(object pSearchValue)
		{

			string mysql = "select pa.entry_id, pa.asset_no, pa.l_asset_name, pa.a_asset_name, pa.asset_value, pa.quantity";
			mysql = mysql + " , pa.issued_qty, pa.damage_qty, pa.balance_qty, pa.user_cd, pat.asset_type_no";
			mysql = mysql + " ," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pat.l_asset_type_name " : "pat.a_asset_type_name");
			mysql = mysql + " ,pa.time_stamp , pa.Warranty_End_Date, pa.Supplier , pa.Purchase_date , pa.Specification ,pa.comments";
			mysql = mysql + " from pay_assets pa";
			mysql = mysql + " inner join pay_assets_type pat on pat.entry_id = pa.asset_type_entry_id";
			mysql = mysql + " where pa.entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtAssetNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtLAssetName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtAAssetName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonNumber[mconNAssetValue].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(4));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonNumber[mconNAssetQuantity].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(5));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonNumber[mconNAssetIssueQuantity].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(6));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonNumber[mconNAssetDamageQuantity].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(7));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonNumber[mconNBalanceQuantity].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(8));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtAssetTypeCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(10));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtAssetTypeName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(11));
				mTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(12));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(15)))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDPurchaseDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(15));
				}
				else
				{
					txtDPurchaseDate.Text = "";
				}
				txtSpecification.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(16)) + "";
				txtComments.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(17)) + "";

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(((Array) mReturnValue).GetValue(13)))
				{
					txtDWarrantyEnd.Value = ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue).GetValue(13)).ToString("dd-MMM-yyyy");
				}
				else
				{
					txtDWarrantyEnd.Text = "";
				}
				txtSupplier.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(14)) + "";
			}
			else
			{
				MessageBox.Show("No Record found!", "Find Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			CurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
		}

		public bool saveRecord()
		{
			bool result = false;
			try
			{
				string mysql = "";
				object mReturnValue = null;
				int mAssetTypeEntID = 0;
				int mAssestOldQty = 0;

				mysql = " select entry_id from pay_assets_type where asset_type_no = '" + txtAssetTypeCode.Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Please enter valid Assets Type Code!", "Incorrect Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtAssetTypeCode.Focus();
					return false;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAssetTypeEntID = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				string mCheckTimeStamp = "";
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into pay_assets (asset_type_entry_id,asset_no,l_asset_name,a_asset_name,asset_value,quantity";
					mysql = mysql + " ,issued_qty,damage_qty, supplier, warranty_end_date,purchase_date , Specification, comments ,user_cd)";
					mysql = mysql + " values(" + mAssetTypeEntID.ToString();
					mysql = mysql + " ,'" + txtAssetNo.Text + "'";
					mysql = mysql + " ,'" + txtLAssetName.Text + "'";
					mysql = mysql + " ,'" + txtAAssetName.Text + "'";
					mysql = mysql + " ," + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[mconNAssetValue].Value);
					mysql = mysql + " ," + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[mconNAssetQuantity].Value);
					mysql = mysql + " ," + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[mconNAssetIssueQuantity].Value);
					mysql = mysql + " ," + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[mconNAssetDamageQuantity].Value);
					mysql = mysql + " ,'" + txtSupplier.Text + "'";
					if (Information.IsDate(txtDWarrantyEnd.Value))
					{
						mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtDWarrantyEnd.Value) + "'";
					}
					else
					{
						mysql = mysql + " , null";
					}
					if (Information.IsDate(txtDPurchaseDate.Value))
					{
						mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtDPurchaseDate.Value) + "'";
					}
					else
					{
						mysql = mysql + " , null";
					}
					mysql = mysql + " ,'" + txtSpecification.Text + "'";
					mysql = mysql + " ,'" + txtComments.Text + "'";
					mysql = mysql + " ," + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					mysql = " select time_stamp , quantity from pay_assets where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mAssestOldQty = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						FirstFocusObject.Focus();
						return result;
					}
					if (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp))
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
					if (String.CompareOrdinal(txtCommonNumber[mconNAssetQuantity].Text, ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1))) < 0)
					{
						MessageBox.Show("Quantity can't be less than privious quantity!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}

					mysql = "update pay_assets";
					mysql = mysql + " set asset_type_entry_id=" + mAssetTypeEntID.ToString();
					mysql = mysql + " ,asset_no='" + txtAssetNo.Text + "'";
					mysql = mysql + " ,l_asset_name='" + txtLAssetName.Text + "'";
					mysql = mysql + " ,a_asset_name='" + txtAAssetName.Text + "'";
					mysql = mysql + " ,asset_value=" + txtCommonNumber[mconNAssetValue].Text;
					mysql = mysql + " ,quantity=" + txtCommonNumber[mconNAssetQuantity].Text;
					mysql = mysql + " ,issued_qty=" + txtCommonNumber[mconNAssetIssueQuantity].Text;
					mysql = mysql + " ,damage_qty=" + txtCommonNumber[mconNAssetDamageQuantity].Text;
					mysql = mysql + " ,supplier='" + txtSupplier.Text + "'";
					if (Information.IsDate(txtDWarrantyEnd.Value))
					{
						mysql = mysql + " ,warranty_end_date='" + ReflectionHelper.GetPrimitiveValue<string>(txtDWarrantyEnd.Value) + "'";
					}
					else
					{
						mysql = mysql + " ,warranty_end_date = null";
					}
					if (Information.IsDate(txtDPurchaseDate.Value))
					{
						mysql = mysql + " ,purchase_date='" + ReflectionHelper.GetPrimitiveValue<string>(txtDPurchaseDate.Value) + "'";
					}
					else
					{
						mysql = mysql + " ,purchase_date = null";
					}
					mysql = mysql + " , specification ='" + txtSpecification.Text + "'";
					mysql = mysql + " , comments = '" + txtComments.Text + "'";
					mysql = mysql + " ,user_cd=" + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " where entry_id=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}
				return true;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
			}
			return result;
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220510));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtAssetTypeCode" : 
					txtAssetTypeCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220500, "2543")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtAssetTypeCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtAssetTypeCode_Leave(txtAssetTypeCode, new EventArgs());
					} 
					break;
				default:
					break;
			}
		}

		private void txtAssetTypeCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtAssetTypeCode");
		}

		private void txtAssetTypeCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";
			object mReturnValue = null;
			if (!SystemProcedure2.IsItEmpty(txtAssetTypeCode.Text, SystemVariables.DataType.StringType))
			{
				mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_asset_type_name" : "a_asset_type_name") + " as name";
				mysql = mysql + " from pay_assets_type";
				mysql = mysql + " where asset_type_no ='" + txtAssetTypeCode.Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtAssetTypeName.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
				else
				{
					txtAssetTypeCode.Text = "";
					txtAssetTypeName.Text = "";
				}
			}
			else
			{
				txtAssetTypeCode.Text = "";
				txtAssetTypeName.Text = "";
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
				UserAccess = null;
				oThisFormToolBar = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public bool CheckDataValidity()
		{

			//**--------------------------------------------------------------------------------------------------------------
			return true;

		}
	}
}