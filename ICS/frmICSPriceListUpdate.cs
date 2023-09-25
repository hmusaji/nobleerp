
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers;



namespace Xtreme
{
	internal partial class frmICSPriceListUpdate
		: System.Windows.Forms.Form
	{

		public frmICSPriceListUpdate()
{
InitializeComponent();
} 
 public  void frmICSPriceListUpdate_old()
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
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			
			InitExtendedProperties();
		}
		void InitExtendedProperties()
		{
			this.grdMigrate1.setScrollTips(false);
			this.grdMigrate2.setScrollTips(false);
		}


		private void frmICSPriceListUpdate_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//************************************************************************'
		//                           Price List Update Wizard
		//
		//Date  : 03-Dec-2009
		//Coder: Moiz Hakimi
		//*************************************************************************
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
		 //This class checks for the rights given to the user
		private XArrayHelper _FieldArray = null;
		private XArrayHelper FieldArray
		{
			get
			{
				if (_FieldArray is null)
				{
					_FieldArray = new XArrayHelper();
				}
				return _FieldArray;
			}
			set
			{
				_FieldArray = value;
			}
		}


		[Serializable]
		private struct GrdColumnProperty
		{
			public bool tIsExist;
			public short tColumn;
		}

		//Constants for Sys_Migrate_Table_Details
		private const int LFieldName = 0;
		private const int AFieldName = 1;
		private const int FieldName = 2;


		public int ThisFormId
		{
			get
			{
				object mThisFormID = null;
				return ReflectionHelper.GetPrimitiveValue<int>(mThisFormID);
			}
			set
			{
				int mThisFormID = value;
			}
		}



		private void btnDeleteLine_Click(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int i = 0;
				int LastRow = grdMigrate2.RowSel;
				//grdMigrate2.RemoveItem (grdMigrate2.RowSel)
				int tempForEndVar = grdMigrate2.RowSel;
				for (i = grdMigrate2.Row; i <= tempForEndVar; i++)
				{
					grdMigrate2.RemoveItem(LastRow);
					LastRow--;
				}
				GenerateSRNO();
				GridResize(0, true);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void btnLoadGrid_Click(Object eventSender, EventArgs eventArgs)
		{
			clsHourGlass mHourGlass = null;
			try
			{
				mHourGlass = null;

				int i = 0;

				grdMigrate2.Cols.Fixed = 1;
				grdMigrate2.Rows.Fixed = 0;
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				CommonDialog1Open.FileName = "";
				//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property CommonDialog1.Flags was upgraded to CommonDialog1Open.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
				//UPGRADE_WARNING: (2074) FileOpenConstants STRING RESOURCE ["IDS-CONSTANT"] NOT FOUND FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
				CommonDialog1Open.ShowReadOnly = false;
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				CommonDialog1Open.Filter = "Text (*.txt)|*.txt|Excel (*.xls)|*.xls";
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FilterIndex was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				CommonDialog1Open.FilterIndex = 2;
				CommonDialog1Open.ShowDialog();


				mHourGlass = new clsHourGlass();

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (CommonDialog1Open.FileName != "")
				{
					//UPGRADE_ISSUE: (2064) VSFlex8.SaveLoadSettings property SaveLoadSettings.flexFileExcel was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid method grdMigrate2.LoadGrid was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdMigrate2.LoadGrid(CommonDialog1Open.FileName, UpgradeStubs.VSFlex8_SaveLoadSettings.getflexFileExcel(), null);
				}
				else
				{
					return;
				}
				grdMigrate2.Rows.Fixed = 1;
				ResembleGrid();
				GenerateSRNO();
				int tempForEndVar = grdMigrate2.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar; i++)
				{
					GridResize(i);
				}
				LoadGrdCombo();
				mHourGlass = null;
			}
			catch (System.Exception excep)
			{
				mHourGlass = null;
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private object ResembleGrid()
		{
			grdMigrate1.Cols.Fixed = 1;
			grdMigrate1.Rows.Fixed = 0;
			grdMigrate1.Cols.Count = grdMigrate2.Cols.Count;
			grdMigrate1.Rows.Count = 1;
			return null;
		}

		private void GenerateSRNO()
		{
			clsHourGlass mHourGlass = new clsHourGlass();
			int i = 0;
			grdMigrate2.Cols[0].WidthDisplay = 53;

			int tempForEndVar = grdMigrate2.Rows.Count - 1;
			for (i = 1; i <= tempForEndVar; i++)
			{
				grdMigrate2.setCellText(i.ToString(), i, 0);
			}
		}

		private object GridResize(int pCol = 0, bool pAllCols = false)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int i = 0;

				if (pAllCols)
				{
					int tempForEndVar = grdMigrate2.Cols.Count - 1;
					for (i = 0; i <= tempForEndVar; i++)
					{
						grdMigrate1.Cols[i].WidthDisplay = grdMigrate2.Cols[i].WidthDisplay;
					}
				}
				else
				{
					grdMigrate1.Cols[pCol].WidthDisplay = grdMigrate2.Cols[pCol].WidthDisplay;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return null;
		}

		private void cmdMigrate_Click(Object eventSender, EventArgs eventArgs)
		{
			clsHourGlass mMouseHourGlass = null;
			try
			{
				mMouseHourGlass = null;
				DataSet rs = null;
				mMouseHourGlass = new clsHourGlass();


				txtTip.Text = "Verifying.....";
				if (!VerifyData())
				{
					return;
				}
				SystemVariables.gConn.BeginTransaction();
				txtTip.Text = "Creating recordset.....";
				if (!CreateGrdTmpRecordset())
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return;
				}

				txtTip.Text = "Updating Prices.....";
				if (!MigrateData())
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return;
				}

				txtTip.Text = "";

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = "drop table #tmpTable";
				TempCommand.ExecuteNonQuery();
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();


				MessageBox.Show("Price Updated successfully.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				mMouseHourGlass = null;
			}
			catch (Exception e)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number == -2147217865)
				{
					//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis#1065
					UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
				}
				else
				{
					MessageBox.Show(e.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					mMouseHourGlass = null;
				}
			}

		}

		private void cmdVerify_Click(Object eventSender, EventArgs eventArgs)
		{
			clsHourGlass mMouseHourGlass = new clsHourGlass();
			if (VerifyData())
			{
				MessageBox.Show("Verification completed succesfully.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			mMouseHourGlass = null;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{
				this.Width = 703;
				this.Height = 542;
				this.Left = 0;
				this.Top = 0;
				//Dim rs As New Recordset
				//UPGRADE_ISSUE: (2064) VSFlex8L.ControlFlagsSettings property ControlFlagsSettings.flexCFAutoClipboard was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdMigrate2.flags was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdMigrate2.setFlags(UpgradeStubs.VSFlex8L_ControlFlagsSettings.getflexCFAutoClipboard());
				txtTip.Text = "";
				//rs.Open "select smt.* from sm_migration_table smt left outer join system_modules sm on smt.module_id = sm.module_id where sm.show=1 and smt.show = 1", gConn, adOpenKeyset, adLockReadOnly
				//TableArray.ReDim 1, rs.RecordCount, 0, 4
				//i = 1
				//cmbMigrateScheme.Clear
				//Do While Not rs.EOF
				//    TableArray(i, 0) = rs("Table_Id").Value
				//    TableArray(i, 1) = rs("L_Table_Name").Value
				//    TableArray(i, 2) = rs("A_Table_Name").Value
				//    TableArray(i, 3) = rs("Comments").Value
				//    TableArray(i, 4) = rs("Table_Name").Value
				//    If gPreferedLanguage = English Then
				//        cmbMigrateScheme.AddItem rs("L_Table_Name"), i - 1
				//    Else
				//        cmbMigrateScheme.AddItem rs("A_Table_Name"), i - 1
				//    End If
				//    rs.MoveNext
				//    i = i + 1
				//Loop
				this.WindowState = FormWindowState.Maximized;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}


		private object LoadGrdCombo()
		{
			int i = 0;
			DataSet rs = new DataSet();
			string mysql = "";
			//txtTip.Text = TableArray(pType + 1, 3) & ""
			grdMigrate1.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			grdMigrate1.AllowEditing = true;
			grdMigrate1.Cols[grdMigrate1.Col].ComboList = "";
			grdMigrate1.Cols[grdMigrate1.Col].ComboList = "(None)" + "|";

			mysql = "select price_list_cd, Price_List_L_Name, Price_List_A_Name from ICS_Price_List where show = 1 ";
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rs.Tables.Clear();
			adap.Fill(rs);

			FieldArray.RedimXArray(new int[]{rs.Tables[0].Rows.Count + 6, 2}, new int[]{1, 0});
			FieldArray.SetValue("Part No", 1, 0);
			FieldArray.SetValue("Part No", 1, 1);
			FieldArray.SetValue("Part_No", 1, 2);

			FieldArray.SetValue("Product Name", 2, 0);
			FieldArray.SetValue("Product Name", 2, 1);
			FieldArray.SetValue("l_Prod_Name", 2, 2);

			FieldArray.SetValue("Sales Rate", 3, 0);
			FieldArray.SetValue("Sales Rate", 3, 1);
			FieldArray.SetValue("Sales_Rate", 3, 2);

			FieldArray.SetValue("Sales Rate 1", 4, 0);
			FieldArray.SetValue("Sales Rate 1", 4, 1);
			FieldArray.SetValue("Sale_Rate1", 4, 2);

			FieldArray.SetValue("Purchase Rate", 5, 0);
			FieldArray.SetValue("Purchase Rate", 5, 1);
			FieldArray.SetValue("Purchase_Rate", 5, 2);

			FieldArray.SetValue("Unit", 6, 0);
			FieldArray.SetValue("Unit", 6, 1);
			FieldArray.SetValue("unit_symbol", 6, 2);

			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				grdMigrate1.Cols[grdMigrate1.Col].ComboList = grdMigrate1.Cols[grdMigrate1.Col].ComboList + "Part No|Product Name|Sales Rate|Sales Rate 1|Purchase Rate|Unit|";
			}
			else
			{
				grdMigrate1.Cols[grdMigrate1.Col].ComboList = grdMigrate1.Cols[grdMigrate1.Col].ComboList + "Part No|Product Name|Sales Rate|Sales Rate 1|Purchase Rate|Unit|";
			}

			int tempForEndVar = rs.Tables[0].Rows.Count - 1;
			for (i = 0; i <= tempForEndVar; i++)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				FieldArray.SetValue(rs.Tables[0].Rows[0]["Price_List_L_Name"], i + 7, 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				FieldArray.SetValue(rs.Tables[0].Rows[0]["Price_List_A_Name"], i + 7, 1);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				FieldArray.SetValue(rs.Tables[0].Rows[0]["Price_List_cd"], i + 7, 2);

				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					grdMigrate1.Cols[grdMigrate1.Col].ComboList = grdMigrate1.Cols[grdMigrate1.Col].ComboList + Convert.ToString(rs.Tables[0].Rows[0]["Price_List_L_Name"]) + "|";
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					grdMigrate1.Cols[grdMigrate1.Col].ComboList = grdMigrate1.Cols[grdMigrate1.Col].ComboList + Convert.ToString(rs.Tables[0].Rows[0]["Price_List_A_Name"]) + "|";
				}
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rs.MoveNext was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rs.MoveNext();
			}

			return null;
		}


		private bool VerifyData()
		{
			object AllowDuplicate = null;
			object AllowNull = null;
			int i = 0; //local variable
			string ColumnName = "";
			GrdColumnProperty mColumnProp = new GrdColumnProperty();


			//Check for columns
			int tempForEndVar = FieldArray.GetLength(0) - 1;
			for (i = 0; i <= tempForEndVar; i++)
			{
				ColumnName = Convert.ToString(FieldArray.GetValue(i + 1, (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? LFieldName : AFieldName));
				mColumnProp = IsColumnExists(ColumnName);
				if (!Convert.ToBoolean(FieldArray.GetValue(i + 1, ReflectionHelper.GetPrimitiveValue<int>(AllowNull))))
				{
					if (!mColumnProp.tIsExist)
					{ // check if user has mapped this column name
						MessageBox.Show("Column " + ColumnName + " does not exist.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}
					if (IsGrdColumnNull(mColumnProp.tColumn))
					{
						MessageBox.Show(ColumnName + " canot be null !!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}

				if (!mColumnProp.tIsExist)
				{ // check if user has mapped this column name
				}
				else
				{


					if (!Convert.ToBoolean(FieldArray.GetValue(i + 1, ReflectionHelper.GetPrimitiveValue<int>(AllowDuplicate))))
					{
						if (IsColumnDuplicate(mColumnProp.tColumn))
						{
							MessageBox.Show(ColumnName + " can not be duplicate !!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return false;
						}
					}

				}

			}

			return true;
		}

		private bool IsColumnDuplicate(int Col)
		{
			int i = 0;
			int Result = 0;
			string SearchText = "";

			int tempForEndVar = grdMigrate2.Rows.Count - 2;
			for (i = 0; i <= tempForEndVar; i++)
			{
				//UPGRADE_WARNING: (1068) grdMigrate2.Cell() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				SearchText = ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, Col));
				if (SearchText != "")
				{
					Result = grdMigrate2.FindRow(SearchText, i + 1, Col, false, true, false);
					if (Result > 0)
					{
						grdMigrate2.Row = i;
						grdMigrate2.Col = Col;
						grdMigrate2.ShowCell(i, Col);
						return true;
					}
				}
			}
			return false;
		}

		private bool IsGrdColumnNull(int Col)
		{
			int i = 0;
			int tempForEndVar = grdMigrate2.Rows.Count - 1;
			for (i = 1; i <= tempForEndVar; i++)
			{
				if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, Col)).Trim() == "")
				{
					grdMigrate2.Row = i;
					grdMigrate2.Col = Col;
					grdMigrate2.ShowCell(i, Col);
					return true;
				}
			}
			return false;
		}

		private GrdColumnProperty IsColumnExists(string colText)
		{
			GrdColumnProperty result = new GrdColumnProperty();
			int i = 0; //local variable
			string CellText = "";
			int tempForEndVar = grdMigrate1.Cols.Count - 1;
			for (i = 0; i <= tempForEndVar; i++)
			{
				//UPGRADE_WARNING: (1068) grdMigrate1.Cell() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				CellText = ReflectionHelper.GetPrimitiveValue<string>(grdMigrate1.getCellText(0, i));
				if (colText == CellText)
				{
					result.tIsExist = true;
					result.tColumn = (short) i;
					return result;
				}
			}

			result.tIsExist = false;
			return result;
		}

		private bool IsLenthMatched(int Col, int pLenth)
		{
			int i = 0;
			string mText = "";

			int tempForEndVar = grdMigrate2.Rows.Count - 2;
			for (i = 1; i <= tempForEndVar; i++)
			{
				//UPGRADE_WARNING: (1068) grdMigrate2.Cell() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mText = ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, Col));
				if (Strings.Len(mText) > pLenth)
				{
					grdMigrate2.Row = i;
					grdMigrate2.Col = Col;
					grdMigrate2.ShowCell(i, Col);
					return false;
				}
			}
			return true;
		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			object FrameCmb = null;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				frameMain.Left = 0;
				frameMain.Top = 0;
				frameMain.Height = this.Height;
				frameMain.Width = this.Width;
				grdMigrate1.Width = frameMain.Width - 23;
				grdMigrate2.Width = frameMain.Width - 23;
				grdMigrate2.Height = frameMain.Height - txtTip.Height - grdMigrate2.Top - 13;
				txtTip.Width = frameMain.Width - 7;
				txtTip.Top = grdMigrate2.Top + grdMigrate2.Height + 3;
				//UPGRADE_ISSUE: (2064) Line property Line1.X2 was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				Line1.setX2(frameMain.Width * 15);
				//UPGRADE_ISSUE: (2064) Line property Line2.X2 was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				Line2.setX2(frameMain.Width * 15);
				Shape1.Height = grdMigrate1.Height + grdMigrate2.Height + (grdMigrate2.Top - (grdMigrate1.Top + grdMigrate1.Height)) + 7;
				Shape1.Width = grdMigrate1.Width + grdMigrate2.Width + (grdMigrate2.Left - (grdMigrate1.Left + grdMigrate1.Width)) + 9;
				ReflectionHelper.LetMember(FrameCmb, "left", (frameMain.Width * 15 - ReflectionHelper.GetMember<double>(FrameCmb, "Width")) - 100);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdMigrate1_AfterEdit(Object eventSender, C1.Win.C1FlexGrid.RowColEventArgs eventArgs)
		{
			int Row = eventArgs.Row;
			int Col = eventArgs.Col;
			try
			{
				string mComboSelection = "";
				//UPGRADE_WARNING: (1068) grdMigrate1.Cell() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mComboSelection = ReflectionHelper.GetPrimitiveValue<string>(grdMigrate1.getCellText(Row, Col));
				if (mComboSelection == "" || ReflectionHelper.GetPrimitiveValue<string>(grdMigrate1.getCellText(Row, Col)) == "(None)")
				{
					grdMigrate1.setCellText("", Row, Col);
					return;
				}
				int i = 0;
				int tempForEndVar = grdMigrate1.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar; i++)
				{
					if (Col == i)
					{
						//if pointer goes to combo which is selected now only
					}
					else
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate1.getCellText(0, i)) == mComboSelection)
						{
							MessageBox.Show("Already Selected!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							grdMigrate1.setCellText("", Row, Col);
							grdMigrate1.Row = Row;
							grdMigrate1.Col = Col;
						}
					}
				}

				if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate1.getCellText(Row, Col)) == "")
				{
					return;
				}
				i = FieldArray.Find(grdMigrate1.getCellText(Row, Col), 1, (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? 0 : 1);
				txtTip.Text = "Desc: " + Convert.ToString(FieldArray.GetValue(i, 3));
			}
			catch
			{
				txtTip.Text = "Desc:";
			}

		}

		private void grdMigrate1_AfterRowColChange(Object eventSender, C1.Win.C1FlexGrid.RangeEventArgs eventArgs)
		{
			int OldRow = eventArgs.OldRange.r1;
			int OldCol = eventArgs.OldRange.c1;
			int NewRow = eventArgs.NewRange.r1;
			int NewCol = eventArgs.NewRange.c1;
			CellMove(grdMigrate2, grdMigrate2.Row, NewCol);
		}

		//UPGRADE_WARNING: (2050) VSFlex8.VSFlexGrid Event grdMigrate1.AfterSelChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdMigrate1_AfterSelChange(int OldRowSel, int OldColSel, int NewRowSel, int NewColSel)
		{
			grdMigrate2.ColSel = NewColSel;
		}

		private void grdMigrate2_AfterRowColChange(Object eventSender, C1.Win.C1FlexGrid.RangeEventArgs eventArgs)
		{
			int OldRow = eventArgs.OldRange.r1;
			int OldCol = eventArgs.OldRange.c1;
			int NewRow = eventArgs.NewRange.r1;
			int NewCol = eventArgs.NewRange.c1;
			CellMove(grdMigrate1, 0, NewCol);
		}

		private void grdMigrate2_AfterScroll(Object eventSender, C1.Win.C1FlexGrid.RangeEventArgs eventArgs)
		{
			int OldTopRow = eventArgs.OldRange.r1;
			int OldLeftCol = eventArgs.OldRange.c1;
			int NewTopRow = eventArgs.NewRange.r1;
			int NewLeftCol = eventArgs.NewRange.c1;
			grdMigrate1.TopRow = NewTopRow;
			grdMigrate1.LeftCol = NewLeftCol;
		}

		//UPGRADE_WARNING: (2050) VSFlex8.VSFlexGrid Event grdMigrate2.AfterSelChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdMigrate2_AfterSelChange(int OldRowSel, int OldColSel, int NewRowSel, int NewColSel)
		{
			try
			{
				grdMigrate1.ColSel = NewColSel;
			}
			catch
			{
			}
		}

		private void grdMigrate2_AfterResizeColumn(Object eventSender, C1.Win.C1FlexGrid.RowColEventArgs eventArgs)
		{
			int Row = eventArgs.Row;
			int Col = eventArgs.Col;
			GridResize(Col);
		}

		public object CellMove(C1.Win.C1FlexGrid.C1FlexGrid object_Renamed, int Row, int Col)
		{
			object_Renamed.Row = Row;
			object_Renamed.Col = Col;
			return null;
		}

		private bool CreateGrdTmpRecordset()
		{
			bool result2 = false;
			int i = 0;
			int j = 0;
			try
			{
				StringBuilder mysql = new StringBuilder();
				object Result = null;
				int cnt = 0;
				string mGrdText = "";
				int mLength = 0;

				//' Creating temp table
				mysql = new StringBuilder(" create table #tmpTable (");
				cnt = 0; // to check for value greater thn zero
				int tempForEndVar = grdMigrate1.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar; i++)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate1.getCellText(0, i)) != "")
					{ //if first grid(grdmigrate1) cell contain nothing then
						if (cnt > 0)
						{
							mysql.Append(", ");
						}
						//UPGRADE_ISSUE: (2070) Constant XCOMP_EQ was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
						//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method FieldArray.Find was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						Result = FieldArray.Find(1, (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? LFieldName : AFieldName, grdMigrate1.getCellText(0, i), XORDER.DESC, UpgradeStubs.XArrayDBObject_XCOMP.getXCOMP_EQ(), XTYPE.DEFAULT);
						if (Information.IsNumeric(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), FieldName)))
						{
							mysql.Append("Price" + Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), FieldName)) + " money ");
						}
						else
						{
							if (Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), FieldName)) == "Sales_Rate" || Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), FieldName)) == "Purchase_Rate")
							{
								mysql.Append(Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), FieldName)) + " money ");
							}
							else
							{
								mysql.Append(Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), FieldName)) + " varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS ");
							}
						}

						cnt++;
					}
				}
				mysql.Append(")");
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql.ToString();
				TempCommand.ExecuteNonQuery();
				//' end creating table


				//' insert records in tmptable
				int tempForEndVar2 = grdMigrate2.Rows.Count - 1;
				for (j = 1; j <= tempForEndVar2; j++)
				{ // for rows
					cnt = 0;
					mysql = new StringBuilder("insert into #tmpTable values (");
					int tempForEndVar3 = grdMigrate1.Cols.Count - 1;
					for (i = 0; i <= tempForEndVar3; i++)
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate1.getCellText(0, i)) != "")
						{ //if first grid(grdmigrate1) cell contain nothing then
							if (cnt > 0)
							{
								mysql.Append(", ");
							}
							//UPGRADE_ISSUE: (2070) Constant XCOMP_EQ was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
							//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method FieldArray.Find was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							Result = FieldArray.Find(1, (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? LFieldName : AFieldName, grdMigrate1.getCellText(0, i), XORDER.DESC, UpgradeStubs.XArrayDBObject_XCOMP.getXCOMP_EQ(), XTYPE.DEFAULT);
							mGrdText = (StringsHelper.Replace(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(j, i)), "'", " ", 1, -1, CompareMethod.Binary) == "") ? " null " : "'" + StringsHelper.Replace(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(j, i)).Substring(0, Math.Min(50, ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(j, i)).Length)), "'", "", 1, -1, CompareMethod.Binary) + "' ";

							if (Information.IsNumeric(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), FieldName)))
							{
								mysql.Append((ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(j, i)) == "") ? " Null " : ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(j, i)));
							}
							else
							{
								if (Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), FieldName)) == "Sales_Rate" || Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), FieldName)) == "Purchase_Rate")
								{
									mysql.Append((ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(j, i)) == "") ? " Null " : ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(j, i)));
								}
								else
								{
									mysql.Append(mGrdText);
								}
							}
							cnt++;
						}
					}
					mysql.Append(")");
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql.ToString();
					TempCommand_2.ExecuteNonQuery();
				}
				//' end inserting records
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = "select * from #tmpTable";
				SqlDataAdapter TempAdapter_4 = null;
				TempAdapter_4 = new SqlDataAdapter();
				TempAdapter_4.SelectCommand = TempCommand_4;
				DataSet TempDataset_4 = null;
				TempDataset_4 = new DataSet();
				TempAdapter_4.Fill(TempDataset_4);
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdMigrate2.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdMigrate2.setDataSource((msdatasrc.DataSource) TempDataset_4);
				ResembleGrid();

				//' resize grids column
				int tempForEndVar4 = grdMigrate2.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar4; i++)
				{
					GridResize(i);
				}
				//' end resize

				return true;
			}
			catch (Exception e)
			{

				// on error
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number == -2147217873)
				{
					grdMigrate2.Row = j;
					grdMigrate2.Col = 0;
					grdMigrate2.ShowCell(j, 0);
					MessageBox.Show("Can not pass null value", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					MessageBox.Show(e.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				result2 = false;
			}
			return result2;
		}

		private bool MigrateData()
		{ // to migrate ICS_Items data
			bool result = false;
			string mysql = "";
			try
			{
				int i = 0;
				object mReturn = null;
				DataSet rs = null;
				int mMaxNo = 0;
				int mVSCode = 0;
				int cnt = 0;
				object mReturnValue = null;

				///*********************************************************************/
				//-----------------------Import Data of ICS_Items-------------------------
				///*********************************************************************/

				string GrdFieldName = "";

				if (IsFieldExist("l_prod_name") || IsFieldExist("a_prod_name") || IsFieldExist("Sales_Rate") || IsFieldExist("Sale_Rate1") || IsFieldExist("Purchase_Rate"))
				{
					mysql = "  update ICS_Item set part_no = p.part_no";
					if (IsFieldExist("l_prod_name"))
					{
						mysql = mysql + " , l_prod_name = isnull(p.l_prod_name, '') ";
					}
					else
					{
						mysql = mysql + " ";
					}

					if (IsFieldExist("a_prod_name"))
					{
						mysql = mysql + ", a_prod_name = isnull(p.a_prod_name, '') ";
					}
					else
					{
						mysql = mysql + " ";
					}
					if (IsFieldExist("Sales_Rate"))
					{
						mysql = mysql + " , Sales_Rate = p.Sales_Rate";
					}
					if (IsFieldExist("Sale_Rate1"))
					{
						mysql = mysql + " , Sale_Rate1 = p.Sale_Rate1";
					}
					if (IsFieldExist("Purchase_Rate"))
					{
						mysql = mysql + " , Purchase_Rate = p.Purchase_Rate";
					}

					mysql = mysql + " from #tmpTable p LEFT OUTER JOIN ICS_Item on p.part_no = ICS_Item.part_no ";
					mysql = mysql + " where ICS_Item.part_no = p.part_no";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}
				///********************************End ICS_Items*********************************/

				///*********************************************************************/
				//-------------------------Price List Update----------------------------------
				///*********************************************************************/
				for (cnt = 1; cnt <= 15; cnt++)
				{

					if (IsFieldExist("Price" + cnt.ToString()))
					{

						mVSCode = cnt;
						//------------------Delete existing price list-------------------
						mysql = "DELETE FROM ICS_Price_List_Details FROM  ICS_Price_List_Details pl";
						mysql = mysql + " inner join ICS_Item p on pl.prod_cd = p.prod_cd";
						mysql = mysql + " inner join #tmpTable T ON p.part_no = T.part_no";
						mysql = mysql + " Where pl.Price_List_Cd = " + cnt.ToString();
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql;
						TempCommand_2.ExecuteNonQuery();
						//------------------------------------------------------------------
						mysql = "insert into ICS_Price_List_Details (Price_List_Cd, Curr_Cd, Prod_Cd, Unit_Cd, Price_Amt, user_cd)";
						mysql = mysql + "select " + cnt.ToString() + ", 1, ICS_Item.Prod_Cd, ";
						if (IsFieldExist("unit_symbol"))
						{
							mysql = mysql + "(select unit_cd from ICS_Unit where ICS_Unit.Symbol = p.unit_symbol) as unit";
						}
						else
						{
							mysql = mysql + " ICS_Item.Base_Unit_Cd";
						}
						mysql = mysql + ", p.Price" + cnt.ToString() + "," + SystemVariables.gLoggedInUserCode.ToString();
						mysql = mysql + " from #tmpTable p inner join ICS_Item on p.part_no = ICS_Item.part_no ";
						mysql = mysql + " where p.Price" + cnt.ToString() + " <> 0";

						SqlCommand TempCommand_3 = null;
						TempCommand_3 = SystemVariables.gConn.CreateCommand();
						TempCommand_3.CommandText = mysql;
						TempCommand_3.ExecuteNonQuery();
					}
				}
				///*********************************************************************/

				return true;
			}
			catch (System.Exception excep)
			{
				result = false;
				//UPGRADE_WARNING: (2081) Clipboard.SetText has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				Clipboard.SetText(mysql);
				MessageBox.Show(mysql + "\r" + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return result;
		}

		private bool IsFieldExist(string pFieldName)
		{
			int i = 0;
			int tempForEndVar = grdMigrate2.Cols.Count - 1;
			for (i = 0; i <= tempForEndVar; i++)
			{
				if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == pFieldName.ToUpper())
				{
					return true;
				}
			}
			return false;
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}